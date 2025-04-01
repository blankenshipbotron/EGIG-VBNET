<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnSendata = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.rtbData = New System.Windows.Forms.RichTextBox()
        Me.btnEraseRead = New System.Windows.Forms.Button()
        Me.lblRecordCount = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCALstatus2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblCALdate = New System.Windows.Forms.Label()
        Me.lblMFGdate = New System.Windows.Forms.Label()
        Me.lblSerialNumber = New System.Windows.Forms.Label()
        Me.lblPCBver = New System.Windows.Forms.Label()
        Me.lblFWver = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPrintCAL = New System.Windows.Forms.Button()
        Me.myProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblRecordsPerSecond = New System.Windows.Forms.Label()
        Me.lblEEusage = New System.Windows.Forms.Label()
        Me.btnDataFolders = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnFindArduinoPort = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort1
        '
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(738, 27)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 36)
        Me.btnConnect.TabIndex = 0
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(819, 36)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(72, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'btnSendata
        '
        Me.btnSendata.Enabled = False
        Me.btnSendata.Location = New System.Drawing.Point(738, 70)
        Me.btnSendata.Name = "btnSendata"
        Me.btnSendata.Size = New System.Drawing.Size(75, 36)
        Me.btnSendata.TabIndex = 3
        Me.btnSendata.Text = "Get Data"
        Me.btnSendata.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(6, 6)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(701, 283)
        Me.ListView1.TabIndex = 4
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Scan ID"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Date"
        Me.ColumnHeader2.Width = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Time"
        Me.ColumnHeader3.Width = 80
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Temp"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Humidity"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "FW ver"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Test Voltage"
        Me.ColumnHeader7.Width = 80
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Test result"
        Me.ColumnHeader8.Width = 100
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Number"
        Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(1056, 6)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(130, 95)
        Me.ListBox1.TabIndex = 5
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(8, 31)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(721, 341)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(713, 315)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "EEprom Data"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.rtbData)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(713, 315)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Debug"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'rtbData
        '
        Me.rtbData.Location = New System.Drawing.Point(6, 6)
        Me.rtbData.Name = "rtbData"
        Me.rtbData.Size = New System.Drawing.Size(648, 303)
        Me.rtbData.TabIndex = 0
        Me.rtbData.Text = ""
        '
        'btnEraseRead
        '
        Me.btnEraseRead.Location = New System.Drawing.Point(897, 95)
        Me.btnEraseRead.Name = "btnEraseRead"
        Me.btnEraseRead.Size = New System.Drawing.Size(99, 26)
        Me.btnEraseRead.TabIndex = 7
        Me.btnEraseRead.Text = "EEPROM R/W"
        Me.btnEraseRead.UseVisualStyleBackColor = True
        '
        'lblRecordCount
        '
        Me.lblRecordCount.AutoSize = True
        Me.lblRecordCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordCount.Location = New System.Drawing.Point(112, 75)
        Me.lblRecordCount.Name = "lblRecordCount"
        Me.lblRecordCount.Size = New System.Drawing.Size(16, 20)
        Me.lblRecordCount.TabIndex = 9
        Me.lblRecordCount.Text = "*"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCALstatus2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblCALdate)
        Me.GroupBox1.Controls.Add(Me.lblMFGdate)
        Me.GroupBox1.Controls.Add(Me.lblSerialNumber)
        Me.GroupBox1.Controls.Add(Me.lblPCBver)
        Me.GroupBox1.Controls.Add(Me.lblFWver)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(735, 127)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(292, 124)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "System Data"
        '
        'lblCALstatus2
        '
        Me.lblCALstatus2.AutoSize = True
        Me.lblCALstatus2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCALstatus2.Location = New System.Drawing.Point(112, 96)
        Me.lblCALstatus2.Name = "lblCALstatus2"
        Me.lblCALstatus2.Size = New System.Drawing.Size(16, 20)
        Me.lblCALstatus2.TabIndex = 11
        Me.lblCALstatus2.Text = "*"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "CAL Due in "
        '
        'lblCALdate
        '
        Me.lblCALdate.AutoSize = True
        Me.lblCALdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCALdate.Location = New System.Drawing.Point(112, 79)
        Me.lblCALdate.Name = "lblCALdate"
        Me.lblCALdate.Size = New System.Drawing.Size(16, 20)
        Me.lblCALdate.TabIndex = 9
        Me.lblCALdate.Text = "*"
        '
        'lblMFGdate
        '
        Me.lblMFGdate.AutoSize = True
        Me.lblMFGdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMFGdate.Location = New System.Drawing.Point(112, 62)
        Me.lblMFGdate.Name = "lblMFGdate"
        Me.lblMFGdate.Size = New System.Drawing.Size(16, 20)
        Me.lblMFGdate.TabIndex = 8
        Me.lblMFGdate.Text = "*"
        '
        'lblSerialNumber
        '
        Me.lblSerialNumber.AutoSize = True
        Me.lblSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSerialNumber.Location = New System.Drawing.Point(112, 45)
        Me.lblSerialNumber.Name = "lblSerialNumber"
        Me.lblSerialNumber.Size = New System.Drawing.Size(16, 20)
        Me.lblSerialNumber.TabIndex = 7
        Me.lblSerialNumber.Text = "*"
        '
        'lblPCBver
        '
        Me.lblPCBver.AutoSize = True
        Me.lblPCBver.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPCBver.Location = New System.Drawing.Point(112, 28)
        Me.lblPCBver.Name = "lblPCBver"
        Me.lblPCBver.Size = New System.Drawing.Size(16, 20)
        Me.lblPCBver.TabIndex = 6
        Me.lblPCBver.Text = "*"
        '
        'lblFWver
        '
        Me.lblFWver.AutoSize = True
        Me.lblFWver.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFWver.Location = New System.Drawing.Point(112, 11)
        Me.lblFWver.Name = "lblFWver"
        Me.lblFWver.Size = New System.Drawing.Size(16, 20)
        Me.lblFWver.TabIndex = 5
        Me.lblFWver.Text = "*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "CAL Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "MFG Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "SN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "PCB ver"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "FW ver"
        '
        'btnPrintCAL
        '
        Me.btnPrintCAL.Enabled = False
        Me.btnPrintCAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintCAL.Location = New System.Drawing.Point(1072, 133)
        Me.btnPrintCAL.Name = "btnPrintCAL"
        Me.btnPrintCAL.Size = New System.Drawing.Size(114, 54)
        Me.btnPrintCAL.TabIndex = 12
        Me.btnPrintCAL.Text = "Print RMA CAL sheet"
        Me.btnPrintCAL.UseVisualStyleBackColor = True
        '
        'myProgressBar1
        '
        Me.myProgressBar1.Location = New System.Drawing.Point(6, 19)
        Me.myProgressBar1.Name = "myProgressBar1"
        Me.myProgressBar1.Size = New System.Drawing.Size(248, 23)
        Me.myProgressBar1.TabIndex = 13
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.lblRecordsPerSecond)
        Me.GroupBox3.Controls.Add(Me.lblEEusage)
        Me.GroupBox3.Controls.Add(Me.myProgressBar1)
        Me.GroupBox3.Controls.Add(Me.lblRecordCount)
        Me.GroupBox3.Location = New System.Drawing.Point(738, 257)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(289, 121)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "EEPROM Status"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(103, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Records read/timing"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Records inserted"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 55)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "EEPROM used"
        '
        'lblRecordsPerSecond
        '
        Me.lblRecordsPerSecond.AutoSize = True
        Me.lblRecordsPerSecond.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecordsPerSecond.Location = New System.Drawing.Point(112, 95)
        Me.lblRecordsPerSecond.Name = "lblRecordsPerSecond"
        Me.lblRecordsPerSecond.Size = New System.Drawing.Size(16, 20)
        Me.lblRecordsPerSecond.TabIndex = 15
        Me.lblRecordsPerSecond.Text = "*"
        '
        'lblEEusage
        '
        Me.lblEEusage.AutoSize = True
        Me.lblEEusage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEEusage.Location = New System.Drawing.Point(112, 55)
        Me.lblEEusage.Name = "lblEEusage"
        Me.lblEEusage.Size = New System.Drawing.Size(16, 20)
        Me.lblEEusage.TabIndex = 14
        Me.lblEEusage.Text = "*"
        '
        'btnDataFolders
        '
        Me.btnDataFolders.Location = New System.Drawing.Point(897, 31)
        Me.btnDataFolders.Name = "btnDataFolders"
        Me.btnDataFolders.Size = New System.Drawing.Size(75, 23)
        Me.btnDataFolders.TabIndex = 16
        Me.btnDataFolders.Text = "Data Folders"
        Me.btnDataFolders.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1042, 24)
        Me.MenuStrip1.TabIndex = 17
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'btnFindArduinoPort
        '
        Me.btnFindArduinoPort.Location = New System.Drawing.Point(897, 66)
        Me.btnFindArduinoPort.Name = "btnFindArduinoPort"
        Me.btnFindArduinoPort.Size = New System.Drawing.Size(75, 23)
        Me.btnFindArduinoPort.TabIndex = 18
        Me.btnFindArduinoPort.Text = "Find Port"
        Me.btnFindArduinoPort.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1042, 394)
        Me.Controls.Add(Me.btnFindArduinoPort)
        Me.Controls.Add(Me.btnDataFolders)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnPrintCAL)
        Me.Controls.Add(Me.btnEraseRead)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnSendata)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Botron B8590 controller"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents btnConnect As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents btnSendata As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents btnEraseRead As Button
    Friend WithEvents rtbData As RichTextBox
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblPCBver As Label
    Friend WithEvents lblFWver As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCALdate As Label
    Friend WithEvents lblMFGdate As Label
    Friend WithEvents lblSerialNumber As Label
    Friend WithEvents lblCALstatus2 As Label
    Friend WithEvents btnPrintCAL As Button
    Friend WithEvents myProgressBar1 As ProgressBar
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblEEusage As Label
    Friend WithEvents lblRecordsPerSecond As Label
    Friend WithEvents btnDataFolders As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblRecordCount As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnFindArduinoPort As Button
End Class
