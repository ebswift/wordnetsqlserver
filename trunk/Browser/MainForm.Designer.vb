'
' Created by SharpDevelop.
' User: simpsont
' Date: 25/10/2006
' Time: 9:47 AM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class MainForm
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
		Me.sqlEditor = New ICSharpCode.TextEditor.TextEditorControl
		Me.tvPresets = New System.Windows.Forms.TreeView
		Me.dataGridView1 = New System.Windows.Forms.DataGridView
		Me.dataSet1 = New System.Data.DataSet
		Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection
		Me.sqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter
		Me.btnExecute = New System.Windows.Forms.Button
		Me.grpPresets = New System.Windows.Forms.GroupBox
		Me.grpSQL = New System.Windows.Forms.GroupBox
		Me.grpOutput = New System.Windows.Forms.GroupBox
		Me.dataSet2 = New System.Data.DataSet
		Me.daPreset = New System.Data.SqlClient.SqlDataAdapter
		Me.splitContainer1 = New System.Windows.Forms.SplitContainer
		Me.splitContainer2 = New System.Windows.Forms.SplitContainer
		Me.statusStrip1 = New System.Windows.Forms.StatusStrip
		Me.StatusText = New System.Windows.Forms.ToolStripStatusLabel
		Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.dataSet1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.grpPresets.SuspendLayout
		Me.grpSQL.SuspendLayout
		Me.grpOutput.SuspendLayout
		CType(Me.dataSet2,System.ComponentModel.ISupportInitialize).BeginInit
		Me.splitContainer1.Panel1.SuspendLayout
		Me.splitContainer1.Panel2.SuspendLayout
		Me.splitContainer1.SuspendLayout
		Me.splitContainer2.Panel1.SuspendLayout
		Me.splitContainer2.Panel2.SuspendLayout
		Me.splitContainer2.SuspendLayout
		Me.statusStrip1.SuspendLayout
		Me.SuspendLayout
		'
		'sqlEditor
		'
		Me.sqlEditor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.sqlEditor.IsIconBarVisible = false
		Me.sqlEditor.Location = New System.Drawing.Point(6, 20)
		Me.sqlEditor.Name = "sqlEditor"
		Me.sqlEditor.ShowEOLMarkers = true
		Me.sqlEditor.ShowInvalidLines = false
		Me.sqlEditor.ShowSpaces = true
		Me.sqlEditor.ShowTabs = true
		Me.sqlEditor.ShowVRuler = true
		Me.sqlEditor.Size = New System.Drawing.Size(484, 127)
		Me.sqlEditor.TabIndex = 0
		'
		'tvPresets
		'
		Me.tvPresets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.tvPresets.Location = New System.Drawing.Point(6, 18)
		Me.tvPresets.Name = "tvPresets"
		Me.tvPresets.Size = New System.Drawing.Size(234, 159)
		Me.tvPresets.TabIndex = 1
		'
		'dataGridView1
		'
		Me.dataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dataGridView1.Location = New System.Drawing.Point(6, 20)
		Me.dataGridView1.Name = "dataGridView1"
		Me.dataGridView1.ReadOnly = true
		Me.dataGridView1.Size = New System.Drawing.Size(736, 152)
		Me.dataGridView1.TabIndex = 2
		'
		'dataSet1
		'
		Me.dataSet1.DataSetName = "NewDataSet"
		'
		'sqlConnection1
		'
		Me.sqlConnection1.FireInfoMessageEventOnUserErrors = false
		'
		'btnExecute
		'
		Me.btnExecute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
		Me.btnExecute.Location = New System.Drawing.Point(6, 154)
		Me.btnExecute.Name = "btnExecute"
		Me.btnExecute.Size = New System.Drawing.Size(75, 23)
		Me.btnExecute.TabIndex = 3
		Me.btnExecute.Text = "E&xecute"
		Me.btnExecute.UseVisualStyleBackColor = true
		AddHandler Me.btnExecute.Click, AddressOf Me.BtnExecuteClick
		'
		'grpPresets
		'
		Me.grpPresets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.grpPresets.Controls.Add(Me.tvPresets)
		Me.grpPresets.Location = New System.Drawing.Point(3, 2)
		Me.grpPresets.Name = "grpPresets"
		Me.grpPresets.Size = New System.Drawing.Size(246, 183)
		Me.grpPresets.TabIndex = 4
		Me.grpPresets.TabStop = false
		Me.grpPresets.Text = "Presets"
		'
		'grpSQL
		'
		Me.grpSQL.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.grpSQL.Controls.Add(Me.sqlEditor)
		Me.grpSQL.Controls.Add(Me.btnExecute)
		Me.grpSQL.Location = New System.Drawing.Point(3, 2)
		Me.grpSQL.Name = "grpSQL"
		Me.grpSQL.Size = New System.Drawing.Size(496, 183)
		Me.grpSQL.TabIndex = 5
		Me.grpSQL.TabStop = false
		Me.grpSQL.Text = "SQL Editor"
		'
		'grpOutput
		'
		Me.grpOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.grpOutput.Controls.Add(Me.dataGridView1)
		Me.grpOutput.Location = New System.Drawing.Point(3, 3)
		Me.grpOutput.Name = "grpOutput"
		Me.grpOutput.Size = New System.Drawing.Size(748, 178)
		Me.grpOutput.TabIndex = 6
		Me.grpOutput.TabStop = false
		Me.grpOutput.Text = "Output"
		'
		'dataSet2
		'
		Me.dataSet2.DataSetName = "NewDataSet"
		'
		'splitContainer1
		'
		Me.splitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
						Or System.Windows.Forms.AnchorStyles.Left)  _
						Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
		Me.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.splitContainer1.Location = New System.Drawing.Point(4, 6)
		Me.splitContainer1.Name = "splitContainer1"
		Me.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'splitContainer1.Panel1
		'
		Me.splitContainer1.Panel1.Controls.Add(Me.splitContainer2)
		'
		'splitContainer1.Panel2
		'
		Me.splitContainer1.Panel2.Controls.Add(Me.grpOutput)
		Me.splitContainer1.Size = New System.Drawing.Size(762, 380)
		Me.splitContainer1.SplitterDistance = 190
		Me.splitContainer1.TabIndex = 7
		'
		'splitContainer2
		'
		Me.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.splitContainer2.Location = New System.Drawing.Point(0, 0)
		Me.splitContainer2.Name = "splitContainer2"
		'
		'splitContainer2.Panel1
		'
		Me.splitContainer2.Panel1.Controls.Add(Me.grpPresets)
		'
		'splitContainer2.Panel2
		'
		Me.splitContainer2.Panel2.Controls.Add(Me.grpSQL)
		Me.splitContainer2.Size = New System.Drawing.Size(762, 190)
		Me.splitContainer2.SplitterDistance = 254
		Me.splitContainer2.TabIndex = 0
		'
		'statusStrip1
		'
		Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusText})
		Me.statusStrip1.Location = New System.Drawing.Point(0, 389)
		Me.statusStrip1.Name = "statusStrip1"
		Me.statusStrip1.Size = New System.Drawing.Size(771, 22)
		Me.statusStrip1.TabIndex = 8
		Me.statusStrip1.Text = "statusStrip1"
		'
		'StatusText
		'
		Me.StatusText.Name = "StatusText"
		Me.StatusText.Size = New System.Drawing.Size(38, 17)
		Me.StatusText.Text = "Ready"
		AddHandler Me.StatusText.Click, AddressOf Me.ToolStripStatusLabel1Click
		'
		'imageList1
		'
		Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"),System.Windows.Forms.ImageListStreamer)
		Me.imageList1.TransparentColor = System.Drawing.Color.White
		Me.imageList1.Images.SetKeyName(0, "ok.jpg")
		Me.imageList1.Images.SetKeyName(1, "wait.jpg")
		Me.imageList1.Images.SetKeyName(2, "warning.jpg")
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(771, 411)
		Me.Controls.Add(Me.statusStrip1)
		Me.Controls.Add(Me.splitContainer1)
		Me.Name = "MainForm"
		Me.Text = "Browser"
		AddHandler Load, AddressOf Me.MainFormLoad
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.dataSet1,System.ComponentModel.ISupportInitialize).EndInit
		Me.grpPresets.ResumeLayout(false)
		Me.grpSQL.ResumeLayout(false)
		Me.grpOutput.ResumeLayout(false)
		CType(Me.dataSet2,System.ComponentModel.ISupportInitialize).EndInit
		Me.splitContainer1.Panel1.ResumeLayout(false)
		Me.splitContainer1.Panel2.ResumeLayout(false)
		Me.splitContainer1.ResumeLayout(false)
		Me.splitContainer2.Panel1.ResumeLayout(false)
		Me.splitContainer2.Panel2.ResumeLayout(false)
		Me.splitContainer2.ResumeLayout(false)
		Me.statusStrip1.ResumeLayout(false)
		Me.statusStrip1.PerformLayout
		Me.ResumeLayout(false)
		Me.PerformLayout
	End Sub
	Private imageList1 As System.Windows.Forms.ImageList
	Private StatusText As System.Windows.Forms.ToolStripStatusLabel
	Private statusStrip1 As System.Windows.Forms.StatusStrip
	Private splitContainer2 As System.Windows.Forms.SplitContainer
	Private splitContainer1 As System.Windows.Forms.SplitContainer
	Private daPreset As System.Data.SqlClient.SqlDataAdapter
	Private dataSet2 As System.Data.DataSet
	Private tvPresets As System.Windows.Forms.TreeView
	Private grpOutput As System.Windows.Forms.GroupBox
	Private grpSQL As System.Windows.Forms.GroupBox
	Private grpPresets As System.Windows.Forms.GroupBox
	Private btnExecute As System.Windows.Forms.Button
	Private sqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
	Private dataSet1 As System.Data.DataSet
	Private sqlConnection1 As System.Data.SqlClient.SqlConnection
	Private dataGridView1 As System.Windows.Forms.DataGridView
	Private sqlEditor As ICSharpCode.TextEditor.TextEditorControl
	
	Sub MainFormLoad(sender As Object, e As System.EventArgs)
		
	End Sub
	
	Sub ToolStripStatusLabel1Click(sender As Object, e As System.EventArgs)
		
	End Sub
End Class
