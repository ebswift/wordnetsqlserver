/*
 * Created by SharpDevelop.
 * User: simpsont
 * Date: 30/10/2006
 * Time: 3:38 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Data;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Gui.CompletionWindow;

using NRefactory = ICSharpCode.NRefactory;
using Dom = ICSharpCode.SharpDevelop.Dom;

namespace Browser
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm
	{
		string quot = ((char)34).ToString();
		public const string DummyFileName = "edited.cs";
		internal Dom.ProjectContentRegistry pcRegistry;
		internal Dom.DefaultProjectContent myProjectContent;
		internal Dom.ICompilationUnit lastCompilationUnit;
		Thread parserThread;
		
        public static Hashtable htWordNet = new Hashtable();

		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			string appPath = Path.GetDirectoryName(Application.ExecutablePath);
			this.sqlConnection1.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=" + quot + Data_Path + quot + ";Integrated Security=True;User Instance=False;Timeout=60";

			ICSharpCode.TextEditor.Document.FileSyntaxModeProvider provider = new ICSharpCode.TextEditor.Document.FileSyntaxModeProvider(appPath);
			ICSharpCode.TextEditor.Document.HighlightingManager.Manager.AddSyntaxModeFileProvider(provider);
			sqlEditor.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingManager.Manager.FindHighlighter("SQL");
	

			sqlEditor.Text = @"SELECT word.lemma, synset.pos, synset.definition 
FROM word
LEFT JOIN sense ON word.wordid=sense.wordid
LEFT JOIN synset ON sense.synsetid=synset.synsetid
WHERE word.lemma='light'
ORDER BY synset.pos

";
//			sqlEditor.SetHighlighting("C#");
//			sqlEditor.SetHighlighting("SQL");
			sqlEditor.ShowEOLMarkers = false;
			CodeCompletionKeyHandler.Attach(this, sqlEditor);
			HostCallbackImplementation.Register(this);
			
			pcRegistry = new Dom.ProjectContentRegistry(); // Default .NET 2.0 registry
			
			// Persistence caches referenced project contents for faster loading.
			// It also activates loading XML documentation files and caching them
			// for faster loading and lower memory usage.
			pcRegistry.ActivatePersistence(Path.Combine(Path.GetTempPath(),
			                                            "CSharpCodeCompletion"));
			
			myProjectContent = new Dom.DefaultProjectContent();
			myProjectContent.Language = Dom.LanguageProperties.CSharp;
		
		
		}

		public string Data_Path {
			get {
				return System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Application.ExecutablePath.ToString()).ToString()).ToString()).ToString()) + "\\Database\\wordnet.mdf";
			}
		}
		
		void BtnExecuteClick(object sender, System.EventArgs e)
		{
			System.Data.SqlClient.SqlCommand sc = new System.Data.SqlClient.SqlCommand(sqlEditor.Text, sqlConnection1);
	
			try {
				StatusText.Text = "Processing command, please wait.";
				StatusText.Image = imageList1.Images["wait.gif"];
				statusStrip1.Refresh();
	
				dataSet1.Tables.Clear();
				sqlDataAdapter1.SelectCommand = sc;
				sqlDataAdapter1.Fill(dataSet1);
				dataGridView1.DataSource = dataSet1.Tables[0];
	
				dataGridView1.Refresh();
	
				StatusText.Text = "The command completed successfully.";
				StatusText.Image = imageList1.Images["ok.gif"];
			}
			catch (Exception ex) {
				StatusText.Text = ex.Message;
				StatusText.Image = imageList1.Images["warning.gif"];
			}
		}
		
		void MainFormLoad(object sender, System.EventArgs e)
		{
			sqlEditor.Focus();
            buildDataHT();
		}

        // enumerate all tables in our database and build a table/column hashtable for code completion
        void buildDataHT() {
            sqlConnection1.Open();
            DataTable dt = sqlConnection1.GetSchema("Columns");
            sqlConnection1.Close();

            string lasttbl = (string)dt.Rows[0][2];
            ICompletionData[] cd = new ICompletionData[1];
            int i = 0;
            int rc = 0; // rowcount

            foreach(DataRow dr in dt.Rows) {
                if((string)dr[2] == lasttbl) {
                    ICompletionData[] cdtemp = new ICompletionData[rc + 1];
                    cd.CopyTo(cdtemp, 0);
                    cd = cdtemp;
                    cd[rc] = new DefaultCompletionData((string)dr[3], (string)dr[7] + " " + (string)dr[3], 0);
                } else {
                    rc = 0;
                    htWordNet.Add(lasttbl, cd);
                    cd = new ICompletionData[1]; 
                    cd[rc] = new DefaultCompletionData((string)dr[3], (string)dr[7] + " " + (string)dr[3], 0);
                    lasttbl = (string)dt.Rows[i][2];
                }

                i ++;
                rc ++;
            }
        }

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			
			parserThread = new Thread(ParserThread);
			parserThread.IsBackground = true;
			parserThread.Start();
		}

		void ParserThread()
		{
			BeginInvoke(new MethodInvoker(delegate { StatusText.Text = "Loading mscorlib..."; }));
			myProjectContent.AddReferencedContent(pcRegistry.Mscorlib);
			
			// do one initial parser step to enable code-completion while other
			// references are loading
			ParseStep();
			
			string[] referencedAssemblies = {
				"System", "System.Data", "System.Drawing", "System.Xml", "System.Windows.Forms"
			};
			foreach (string assemblyName in referencedAssemblies) {
				{ // block for anonymous method
					string assemblyNameCopy = assemblyName;
					BeginInvoke(new MethodInvoker(delegate { StatusText.Text = "Loading " + assemblyNameCopy + "..."; }));
				}
				myProjectContent.AddReferencedContent(pcRegistry.GetProjectContentForReference(assemblyName, assemblyName));
			}
			BeginInvoke(new MethodInvoker(delegate { StatusText.Text = "Ready"; }));
			
			// Parse the current file every 2 seconds
			while (!IsDisposed) {
				ParseStep();
				
				Thread.Sleep(2000);
			}
		}
		
		void ParseStep()
		{
			string code = null;
			Invoke(new MethodInvoker(delegate {
			                         	code = sqlEditor.Text;
			                         }));
			TextReader textReader = new StringReader(code);
			Dom.ICompilationUnit newCompilationUnit;
			using (NRefactory.IParser p = NRefactory.ParserFactory.CreateParser(NRefactory.SupportedLanguage.CSharp, textReader)) {
				p.Parse();
				newCompilationUnit = ConvertCompilationUnit(p.CompilationUnit);
			}
			// Remove information from lastCompilationUnit and add information from newCompilationUnit.
			myProjectContent.UpdateCompilationUnit(lastCompilationUnit, newCompilationUnit, DummyFileName);
			lastCompilationUnit = newCompilationUnit;
		}
		
		Dom.ICompilationUnit ConvertCompilationUnit(NRefactory.Ast.CompilationUnit cu)
		{
			Dom.NRefactoryResolver.NRefactoryASTConvertVisitor converter;
			converter = new Dom.NRefactoryResolver.NRefactoryASTConvertVisitor(myProjectContent);
			cu.AcceptVisitor(converter, null);
			return converter.Cu;
		}
	}
}
