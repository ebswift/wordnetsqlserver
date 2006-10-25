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
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).BeginInit
		CType(Me.dataSet1,System.ComponentModel.ISupportInitialize).BeginInit
		Me.grpPresets.SuspendLayout
		Me.grpSQL.SuspendLayout
		Me.grpOutput.SuspendLayout
		CType(Me.dataSet2,System.ComponentModel.ISupportInitialize).BeginInit
		Me.SuspendLayout
		'
		'sqlEditor
		'
		Me.sqlEditor.IsIconBarVisible = false
		Me.sqlEditor.Location = New System.Drawing.Point(6, 20)
		Me.sqlEditor.Name = "sqlEditor"
		Me.sqlEditor.ShowEOLMarkers = true
		Me.sqlEditor.ShowInvalidLines = false
		Me.sqlEditor.ShowSpaces = true
		Me.sqlEditor.ShowTabs = true
		Me.sqlEditor.ShowVRuler = true
		Me.sqlEditor.Size = New System.Drawing.Size(433, 212)
		Me.sqlEditor.TabIndex = 0
		'
		'tvPresets
		'
		Me.tvPresets.Location = New System.Drawing.Point(6, 18)
		Me.tvPresets.Name = "tvPresets"
		Me.tvPresets.Size = New System.Drawing.Size(188, 244)
		Me.tvPresets.TabIndex = 1
		'
		'dataGridView1
		'
		Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.dataGridView1.Location = New System.Drawing.Point(6, 20)
		Me.dataGridView1.Name = "dataGridView1"
		Me.dataGridView1.ReadOnly = true
		Me.dataGridView1.Size = New System.Drawing.Size(639, 148)
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
		Me.btnExecute.Location = New System.Drawing.Point(6, 239)
		Me.btnExecute.Name = "btnExecute"
		Me.btnExecute.Size = New System.Drawing.Size(75, 23)
		Me.btnExecute.TabIndex = 3
		Me.btnExecute.Text = "E&xecute"
		Me.btnExecute.UseVisualStyleBackColor = true
		AddHandler Me.btnExecute.Click, AddressOf Me.BtnExecuteClick
		'
		'grpPresets
		'
		Me.grpPresets.Controls.Add(Me.tvPresets)
		Me.grpPresets.Location = New System.Drawing.Point(12, 12)
		Me.grpPresets.Name = "grpPresets"
		Me.grpPresets.Size = New System.Drawing.Size(200, 268)
		Me.grpPresets.TabIndex = 4
		Me.grpPresets.TabStop = false
		Me.grpPresets.Text = "Presets"
		'
		'grpSQL
		'
		Me.grpSQL.Controls.Add(Me.sqlEditor)
		Me.grpSQL.Controls.Add(Me.btnExecute)
		Me.grpSQL.Location = New System.Drawing.Point(218, 12)
		Me.grpSQL.Name = "grpSQL"
		Me.grpSQL.Size = New System.Drawing.Size(445, 268)
		Me.grpSQL.TabIndex = 5
		Me.grpSQL.TabStop = false
		Me.grpSQL.Text = "SQL Editor"
		'
		'grpOutput
		'
		Me.grpOutput.Controls.Add(Me.dataGridView1)
		Me.grpOutput.Location = New System.Drawing.Point(12, 286)
		Me.grpOutput.Name = "grpOutput"
		Me.grpOutput.Size = New System.Drawing.Size(651, 174)
		Me.grpOutput.TabIndex = 6
		Me.grpOutput.TabStop = false
		Me.grpOutput.Text = "Output"
		'
		'dataSet2
		'
		Me.dataSet2.DataSetName = "NewDataSet"
		'
		'MainForm
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(675, 472)
		Me.Controls.Add(Me.grpOutput)
		Me.Controls.Add(Me.grpSQL)
		Me.Controls.Add(Me.grpPresets)
		Me.Name = "MainForm"
		Me.Text = "Browser"
		CType(Me.dataGridView1,System.ComponentModel.ISupportInitialize).EndInit
		CType(Me.dataSet1,System.ComponentModel.ISupportInitialize).EndInit
		Me.grpPresets.ResumeLayout(false)
		Me.grpSQL.ResumeLayout(false)
		Me.grpOutput.ResumeLayout(false)
		CType(Me.dataSet2,System.ComponentModel.ISupportInitialize).EndInit
		Me.ResumeLayout(false)
	End Sub
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
End Class
