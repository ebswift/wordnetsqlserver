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
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Browser
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm
	{
		string quot = ((char)34).ToString();
		
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
			ICSharpCode.TextEditor.Document.FileSyntaxModeProvider provider = new ICSharpCode.TextEditor.Document.FileSyntaxModeProvider(appPath);
			ICSharpCode.TextEditor.Document.HighlightingManager.Manager.AddSyntaxModeFileProvider(provider);
			sqlEditor.Document.HighlightingStrategy = ICSharpCode.TextEditor.Document.HighlightingManager.Manager.FindHighlighter("SQL");
	
			this.sqlConnection1.ConnectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=" + quot + Data_Path + quot + ";Integrated Security=True;User Instance=False;Timeout=60";
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
				StatusText.Image = imageList1.Images["wait.jpg"];
				statusStrip1.Refresh();
	
				dataSet1.Tables.Clear();
				sqlDataAdapter1.SelectCommand = sc;
				sqlDataAdapter1.Fill(dataSet1);
				dataGridView1.DataSource = dataSet1.Tables[0];
	
				dataGridView1.Refresh();
	
				StatusText.Text = "The command completed successfully.";
				StatusText.Image = imageList1.Images["ok.jpg"];
			}
			catch (Exception ex) {
				StatusText.Text = ex.Message;
				StatusText.Image = imageList1.Images["warning.jpg"];
			}
		}
		
		void MainFormLoad(object sender, System.EventArgs e)
		{
			sqlEditor.Focus();
		}
	}
}
