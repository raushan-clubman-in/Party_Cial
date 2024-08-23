Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Public Class PTY_SUBGROUPMASTER
    Inherits System.Windows.Forms.Form
    Dim gconn As New GlobalClass
    Dim sqlstring As String
    Dim dr As DataRow
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim i As Integer
    Dim boolchk As Boolean
    Friend WithEvents CMD_SUBgroupcode As System.Windows.Forms.Button
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents CMD_EXIT As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmd_view As System.Windows.Forms.Button
    Friend WithEvents CMD_FREEZE As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Dim gconnection As New GlobalClass
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lbl_freeze As System.Windows.Forms.Label
    Friend WithEvents cmd_Exit1 As System.Windows.Forms.Button
    Friend WithEvents cmd_Freeze23 As System.Windows.Forms.Button
    Friend WithEvents grp_StatusConversion4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Add1234 As System.Windows.Forms.Button
    Friend WithEvents cmd_View1 As System.Windows.Forms.Button
    Friend WithEvents cmd_Clear11 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_Caption As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CMD_SUBgroupcode2 As System.Windows.Forms.Button
    Friend WithEvents txt_SUBgroupcode As System.Windows.Forms.TextBox
    Friend WithEvents Txt_SUBgroupdesc As System.Windows.Forms.TextBox
    Friend WithEvents Grp_Print As System.Windows.Forms.GroupBox
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMD_WINDOWS As System.Windows.Forms.Button
    Friend WithEvents CMD_DOS As System.Windows.Forms.Button
    Friend WithEvents cmd_print As System.Windows.Forms.Button
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CMB_TYPE As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PTY_SUBGROUPMASTER))
        Me.lbl_freeze = New System.Windows.Forms.Label()
        Me.cmd_Exit1 = New System.Windows.Forms.Button()
        Me.cmd_Freeze23 = New System.Windows.Forms.Button()
        Me.grp_StatusConversion4 = New System.Windows.Forms.GroupBox()
        Me.cmd_Add1234 = New System.Windows.Forms.Button()
        Me.cmd_View1 = New System.Windows.Forms.Button()
        Me.cmd_Clear11 = New System.Windows.Forms.Button()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.cmd_print = New System.Windows.Forms.Button()
        Me.CMD_SUBgroupcode2 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_SUBgroupcode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_SUBgroupdesc = New System.Windows.Forms.TextBox()
        Me.lbl_Caption = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMD_SUBgroupcode = New System.Windows.Forms.Button()
        Me.CMB_TYPE = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Grp_Print = New System.Windows.Forms.GroupBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMD_WINDOWS = New System.Windows.Forms.Button()
        Me.CMD_DOS = New System.Windows.Forms.Button()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.CMD_EXIT = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.Cmd_view = New System.Windows.Forms.Button()
        Me.CMD_FREEZE = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.grp_StatusConversion4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Grp_Print.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_freeze
        '
        Me.lbl_freeze.AutoSize = True
        Me.lbl_freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_freeze.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_freeze.Location = New System.Drawing.Point(336, 408)
        Me.lbl_freeze.Name = "lbl_freeze"
        Me.lbl_freeze.Size = New System.Drawing.Size(165, 25)
        Me.lbl_freeze.TabIndex = 419
        Me.lbl_freeze.Text = "Record Freezed"
        Me.lbl_freeze.Visible = False
        '
        'cmd_Exit1
        '
        Me.cmd_Exit1.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Exit1.BackgroundImage = CType(resources.GetObject("cmd_Exit1.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Exit1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Exit1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Exit1.ForeColor = System.Drawing.Color.White
        Me.cmd_Exit1.Location = New System.Drawing.Point(600, 16)
        Me.cmd_Exit1.Name = "cmd_Exit1"
        Me.cmd_Exit1.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Exit1.TabIndex = 9
        Me.cmd_Exit1.Text = "Exit[F11]"
        Me.cmd_Exit1.UseVisualStyleBackColor = False
        '
        'cmd_Freeze23
        '
        Me.cmd_Freeze23.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Freeze23.BackgroundImage = CType(resources.GetObject("cmd_Freeze23.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Freeze23.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Freeze23.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Freeze23.ForeColor = System.Drawing.Color.White
        Me.cmd_Freeze23.Location = New System.Drawing.Point(312, 16)
        Me.cmd_Freeze23.Name = "cmd_Freeze23"
        Me.cmd_Freeze23.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Freeze23.TabIndex = 7
        Me.cmd_Freeze23.Text = "Freeze[F8]"
        Me.cmd_Freeze23.UseVisualStyleBackColor = False
        '
        'grp_StatusConversion4
        '
        Me.grp_StatusConversion4.BackColor = System.Drawing.Color.Transparent
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Add1234)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_View1)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Clear11)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Freeze23)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Exit1)
        Me.grp_StatusConversion4.Location = New System.Drawing.Point(80, 440)
        Me.grp_StatusConversion4.Name = "grp_StatusConversion4"
        Me.grp_StatusConversion4.Size = New System.Drawing.Size(736, 64)
        Me.grp_StatusConversion4.TabIndex = 418
        Me.grp_StatusConversion4.TabStop = False
        Me.grp_StatusConversion4.Visible = False
        '
        'cmd_Add1234
        '
        Me.cmd_Add1234.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Add1234.BackgroundImage = CType(resources.GetObject("cmd_Add1234.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Add1234.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Add1234.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Add1234.ForeColor = System.Drawing.Color.White
        Me.cmd_Add1234.Location = New System.Drawing.Point(176, 16)
        Me.cmd_Add1234.Name = "cmd_Add1234"
        Me.cmd_Add1234.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Add1234.TabIndex = 6
        Me.cmd_Add1234.Text = "Add[F7]"
        Me.cmd_Add1234.UseVisualStyleBackColor = False
        '
        'cmd_View1
        '
        Me.cmd_View1.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_View1.BackgroundImage = CType(resources.GetObject("cmd_View1.BackgroundImage"), System.Drawing.Image)
        Me.cmd_View1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_View1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_View1.ForeColor = System.Drawing.Color.White
        Me.cmd_View1.Location = New System.Drawing.Point(448, 16)
        Me.cmd_View1.Name = "cmd_View1"
        Me.cmd_View1.Size = New System.Drawing.Size(104, 32)
        Me.cmd_View1.TabIndex = 8
        Me.cmd_View1.Text = "Report [F9]"
        Me.cmd_View1.UseVisualStyleBackColor = False
        '
        'cmd_Clear11
        '
        Me.cmd_Clear11.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Clear11.BackgroundImage = CType(resources.GetObject("cmd_Clear11.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Clear11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Clear11.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Clear11.ForeColor = System.Drawing.Color.White
        Me.cmd_Clear11.Location = New System.Drawing.Point(40, 16)
        Me.cmd_Clear11.Name = "cmd_Clear11"
        Me.cmd_Clear11.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Clear11.TabIndex = 5
        Me.cmd_Clear11.Text = "Clear[F6]"
        Me.cmd_Clear11.UseVisualStyleBackColor = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdexport.BackgroundImage = CType(resources.GetObject("cmdexport.BackgroundImage"), System.Drawing.Image)
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Location = New System.Drawing.Point(704, 336)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(104, 32)
        Me.cmdexport.TabIndex = 435
        Me.cmdexport.Text = "Report[F12]"
        Me.cmdexport.UseVisualStyleBackColor = False
        Me.cmdexport.Visible = False
        '
        'cmd_print
        '
        Me.cmd_print.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_print.BackgroundImage = CType(resources.GetObject("cmd_print.BackgroundImage"), System.Drawing.Image)
        Me.cmd_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_print.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_print.ForeColor = System.Drawing.Color.White
        Me.cmd_print.Location = New System.Drawing.Point(584, 336)
        Me.cmd_print.Name = "cmd_print"
        Me.cmd_print.Size = New System.Drawing.Size(104, 32)
        Me.cmd_print.TabIndex = 7
        Me.cmd_print.Text = "Print [F10]"
        Me.cmd_print.UseVisualStyleBackColor = False
        Me.cmd_print.Visible = False
        '
        'CMD_SUBgroupcode2
        '
        Me.CMD_SUBgroupcode2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMD_SUBgroupcode2.Location = New System.Drawing.Point(552, 126)
        Me.CMD_SUBgroupcode2.Name = "CMD_SUBgroupcode2"
        Me.CMD_SUBgroupcode2.Size = New System.Drawing.Size(24, 24)
        Me.CMD_SUBgroupcode2.TabIndex = 2
        Me.CMD_SUBgroupcode2.UseVisualStyleBackColor = False
        Me.CMD_SUBgroupcode2.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(24, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 15)
        Me.Label14.TabIndex = 426
        Me.Label14.Text = "Sub Group Code"
        '
        'txt_SUBgroupcode
        '
        Me.txt_SUBgroupcode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txt_SUBgroupcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_SUBgroupcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_SUBgroupcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_SUBgroupcode.Location = New System.Drawing.Point(200, 16)
        Me.txt_SUBgroupcode.MaxLength = 6
        Me.txt_SUBgroupcode.Name = "txt_SUBgroupcode"
        Me.txt_SUBgroupcode.Size = New System.Drawing.Size(64, 21)
        Me.txt_SUBgroupcode.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 15)
        Me.Label10.TabIndex = 427
        Me.Label10.Text = "Sub Group Description"
        '
        'Txt_SUBgroupdesc
        '
        Me.Txt_SUBgroupdesc.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_SUBgroupdesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_SUBgroupdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_SUBgroupdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_SUBgroupdesc.Location = New System.Drawing.Point(200, 56)
        Me.Txt_SUBgroupdesc.MaxLength = 50
        Me.Txt_SUBgroupdesc.Name = "Txt_SUBgroupdesc"
        Me.Txt_SUBgroupdesc.Size = New System.Drawing.Size(192, 21)
        Me.Txt_SUBgroupdesc.TabIndex = 3
        '
        'lbl_Caption
        '
        Me.lbl_Caption.AutoSize = True
        Me.lbl_Caption.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Caption.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Caption.Location = New System.Drawing.Point(172, 71)
        Me.lbl_Caption.Name = "lbl_Caption"
        Me.lbl_Caption.Size = New System.Drawing.Size(266, 29)
        Me.lbl_Caption.TabIndex = 425
        Me.lbl_Caption.Text = "SUB GROUP MASTER"
        Me.lbl_Caption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CMD_SUBgroupcode)
        Me.GroupBox1.Controls.Add(Me.CMB_TYPE)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Txt_SUBgroupdesc)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txt_SUBgroupcode)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(247, 178)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 160)
        Me.GroupBox1.TabIndex = 429
        Me.GroupBox1.TabStop = False
        '
        'CMD_SUBgroupcode
        '
        Me.CMD_SUBgroupcode.Location = New System.Drawing.Point(265, 14)
        Me.CMD_SUBgroupcode.Name = "CMD_SUBgroupcode"
        Me.CMD_SUBgroupcode.Size = New System.Drawing.Size(40, 23)
        Me.CMD_SUBgroupcode.TabIndex = 463
        Me.CMD_SUBgroupcode.Text = "?"
        Me.CMD_SUBgroupcode.UseVisualStyleBackColor = True
        '
        'CMB_TYPE
        '
        Me.CMB_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_TYPE.Items.AddRange(New Object() {"NVEG", "VEG"})
        Me.CMB_TYPE.Location = New System.Drawing.Point(200, 104)
        Me.CMB_TYPE.Name = "CMB_TYPE"
        Me.CMB_TYPE.Size = New System.Drawing.Size(136, 28)
        Me.CMB_TYPE.TabIndex = 4
        Me.CMB_TYPE.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(24, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 15)
        Me.Label15.TabIndex = 462
        Me.Label15.Text = "TYPE "
        Me.Label15.Visible = False
        '
        'Grp_Print
        '
        Me.Grp_Print.BackColor = System.Drawing.Color.Transparent
        Me.Grp_Print.Controls.Add(Me.CMDEXIT)
        Me.Grp_Print.Controls.Add(Me.CMD_WINDOWS)
        Me.Grp_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Print.Location = New System.Drawing.Point(264, 344)
        Me.Grp_Print.Name = "Grp_Print"
        Me.Grp_Print.Size = New System.Drawing.Size(368, 56)
        Me.Grp_Print.TabIndex = 662
        Me.Grp_Print.TabStop = False
        Me.Grp_Print.Visible = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.Location = New System.Drawing.Point(216, 16)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(96, 32)
        Me.CMDEXIT.TabIndex = 2
        Me.CMDEXIT.Text = "EXIT"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'CMD_WINDOWS
        '
        Me.CMD_WINDOWS.BackColor = System.Drawing.Color.Transparent
        Me.CMD_WINDOWS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_WINDOWS.Location = New System.Drawing.Point(64, 16)
        Me.CMD_WINDOWS.Name = "CMD_WINDOWS"
        Me.CMD_WINDOWS.Size = New System.Drawing.Size(96, 32)
        Me.CMD_WINDOWS.TabIndex = 1
        Me.CMD_WINDOWS.Text = "WINDOWS"
        Me.CMD_WINDOWS.UseVisualStyleBackColor = False
        '
        'CMD_DOS
        '
        Me.CMD_DOS.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CMD_DOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_DOS.Location = New System.Drawing.Point(152, 280)
        Me.CMD_DOS.Name = "CMD_DOS"
        Me.CMD_DOS.Size = New System.Drawing.Size(32, 32)
        Me.CMD_DOS.TabIndex = 0
        Me.CMD_DOS.Text = "DOS"
        Me.CMD_DOS.UseVisualStyleBackColor = False
        Me.CMD_DOS.Visible = False
        '
        'cmdreport
        '
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(856, 377)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(141, 65)
        Me.cmdreport.TabIndex = 670
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.UseVisualStyleBackColor = True
        '
        'CMD_EXIT
        '
        Me.CMD_EXIT.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_EXIT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_EXIT.Image = CType(resources.GetObject("CMD_EXIT.Image"), System.Drawing.Image)
        Me.CMD_EXIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_EXIT.Location = New System.Drawing.Point(856, 589)
        Me.CMD_EXIT.Name = "CMD_EXIT"
        Me.CMD_EXIT.Size = New System.Drawing.Size(141, 65)
        Me.CMD_EXIT.TabIndex = 669
        Me.CMD_EXIT.Text = "Exit [F11]"
        Me.CMD_EXIT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_EXIT.UseVisualStyleBackColor = True
        '
        'Cmdauth
        '
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(856, 518)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(141, 65)
        Me.Cmdauth.TabIndex = 668
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.UseVisualStyleBackColor = True
        '
        'Cmdbwse
        '
        Me.Cmdbwse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbwse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbwse.Location = New System.Drawing.Point(856, 446)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(141, 65)
        Me.Cmdbwse.TabIndex = 667
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.UseVisualStyleBackColor = True
        '
        'Cmd_view
        '
        Me.Cmd_view.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_view.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_view.Image = CType(resources.GetObject("Cmd_view.Image"), System.Drawing.Image)
        Me.Cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_view.Location = New System.Drawing.Point(856, 306)
        Me.Cmd_view.Name = "Cmd_view"
        Me.Cmd_view.Size = New System.Drawing.Size(141, 65)
        Me.Cmd_view.TabIndex = 666
        Me.Cmd_view.Text = "View [F9]"
        Me.Cmd_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_view.UseVisualStyleBackColor = True
        '
        'CMD_FREEZE
        '
        Me.CMD_FREEZE.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_FREEZE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_FREEZE.Image = CType(resources.GetObject("CMD_FREEZE.Image"), System.Drawing.Image)
        Me.CMD_FREEZE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_FREEZE.Location = New System.Drawing.Point(856, 226)
        Me.CMD_FREEZE.Name = "CMD_FREEZE"
        Me.CMD_FREEZE.Size = New System.Drawing.Size(141, 74)
        Me.CMD_FREEZE.TabIndex = 665
        Me.CMD_FREEZE.Text = "Freeze [F8]"
        Me.CMD_FREEZE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_FREEZE.UseVisualStyleBackColor = True
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(856, 85)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(141, 65)
        Me.Cmd_Clear.TabIndex = 664
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = True
        '
        'Cmd_Add
        '
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(856, 155)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(141, 65)
        Me.Cmd_Add.TabIndex = 663
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'PTY_SUBGROUPMASTER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1019, 733)
        Me.Controls.Add(Me.cmdreport)
        Me.Controls.Add(Me.CMD_EXIT)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbwse)
        Me.Controls.Add(Me.Cmd_view)
        Me.Controls.Add(Me.CMD_FREEZE)
        Me.Controls.Add(Me.CMD_SUBgroupcode2)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Grp_Print)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_Caption)
        Me.Controls.Add(Me.lbl_freeze)
        Me.Controls.Add(Me.grp_StatusConversion4)
        Me.Controls.Add(Me.cmd_print)
        Me.Controls.Add(Me.cmdexport)
        Me.Controls.Add(Me.CMD_DOS)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PTY_SUBGROUPMASTER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GROUPMASTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_StatusConversion4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Grp_Print.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub PTY_GROUPMASTER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Show()
        txt_SUBgroupcode.Focus()
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        gconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.cmd_Add1234.Enabled = False
        ' Me.cmd_Delete.Enabled = False
        Me.cmd_View1.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.cmd_Add1234.Enabled = True
                    'Me.cmd_Delete.Enabled = True
                    Me.cmd_View1.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.cmd_Add1234.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.cmd_Add1234.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.cmd_Add1234.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    'Me.cmd_Delete.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.cmd_View1.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub checkvalidate()
        boolchk = False
        If Trim(txt_SUBgroupcode.Text) = "" Then
            MessageBox.Show("Group Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_SUBgroupcode.Focus()
            Exit Sub
        End If
        If Trim(Txt_SUBgroupdesc.Text) = "" Then
            MessageBox.Show("Group Description Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_SUBgroupdesc.Focus()
            Exit Sub
        End If
        'If Trim(CMB_TYPE.Text) = "" Then
        '    MessageBox.Show("TYPE Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Txt_SUBgroupdesc.Focus()
        '    Exit Sub
        'End If
        boolchk = True
    End Sub


    Private Sub txt_SUBgroupcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_SUBgroupcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_SUBgroupcode.Text) <> "" Then
                Call txt_SUBgroupcode_Validated(txt_SUBgroupcode, e)
            ElseIf Trim(txt_SUBgroupcode.Text) = "" Then
                Call CMD_SUBgroupcode_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txt_SUBgroupcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_SUBgroupcode.Validated
        If Trim(txt_SUBgroupcode.Text) <> "" Then
            sqlstring = "SELECT ISNULL(SUBgroupcode,'')AS SUBgroupcode,ISNULL(SUBgroupdesc,'')AS SUBgroupdesc,ISNULL(FREEZE,'')AS FREEZE FROM party_SUBGROUP_MASTER"
            sqlstring = sqlstring & " WHERE ISNULL(SUBgroupcode,'')='" & Trim(txt_SUBgroupcode.Text) & "'"
            gconn.getDataSet(sqlstring, "GRP")
            If gdataset.Tables("GRP").Rows.Count > 0 Then
                Cmd_Add.Text = "Update[F7]"
                txt_SUBgroupcode.Text = gdataset.Tables("GRP").Rows(0).Item("SUBgroupcode")
                Txt_SUBgroupdesc.Text = gdataset.Tables("GRP").Rows(0).Item("SUBgroupdesc")
                'CMB_TYPE.Text = gdataset.Tables("GRP").Rows(0).Item("TYPE")
                If gdataset.Tables("GRP").Rows(0).Item("FREEZE") = "Y" Then
                    lbl_freeze.Visible = True
                    CMD_FREEZE.Text = "Unfreeze[F8]"
                Else
                    lbl_freeze.Visible = False
                End If
                txt_SUBgroupcode.Enabled = False
                CMD_SUBgroupcode2.Enabled = False
                Txt_SUBgroupdesc.Focus()
            Else
                'MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                txt_SUBgroupcode.Enabled = True
                CMD_SUBgroupcode2.Enabled = True
                Txt_SUBgroupdesc.Focus()
            End If
        End If
    End Sub

    Private Sub cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Exit1.Click
        Me.Close()
    End Sub




    Private Sub Txt_SUBgroupdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_SUBgroupdesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cmd_Add.Focus()
        End If
    End Sub
    Private Sub PTY_GROUPMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call cmd_Clear_Click(sender, e)
        ElseIf e.KeyCode = Keys.F7 Then
            Call cmd_Add_Click(sender, e)
        ElseIf e.KeyCode = Keys.F8 Then
            Call cmd_Freeze_Click(sender, e)
        ElseIf e.KeyCode = Keys.F9 Then
            Call cmd_View_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            Call cmd_Exit_Click(sender, e)
        End If
    End Sub
    Private Sub CMD_PRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_print.Click
        gPrint = True
        Grp_Print.Visible = True
    End Sub
    Private Sub CMD_WINDOWS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_WINDOWS.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_MAS_GROUPHISTORY
        STR = "SELECT * FROM VIEW_PARTY_GROUPHISTORY"
        Viewer.ssql = STR
        gconn.getDataSet(STR, "group")
        If gdataset.Tables("group").Rows.Count > 0 Then
            Viewer.Report = r
            Viewer.TableName = "VIEW_PARTY_GROUPHISTORY"
            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text6")
            textobj1.Text = MyCompanyName
            Dim TXTOBJ2 As TextObject
            TXTOBJ2 = r.ReportDefinition.ReportObjects("Text10")
            TXTOBJ2.Text = gUsername
            Viewer.Show()
            Grp_Print.Visible = False
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub
    Private Sub CMD_DOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_DOS.Click
        Dim i, j As Integer
        Dim Type() As String
        Dim tablename As String
        Dim typename As String
        Dim heading As String
        Dim str As String
        heading = "GROUP MASTER"
        str = "SELECT * from VIEW_PARTY_GROUPHISTORY"
        Call printdata(str, heading, Format(Now, "dd-MMM-yyyy"), Format(Now, "dd-MMM-yyyy"))
        Grp_Print.Visible = False
    End Sub
    Private Function PrintHeader(ByVal HEADING As String, ByVal MSKFROMDATE As Date, ByVal MSKTODATE As Date)
        Dim I As Integer
        pagesize = 0
        Try
            Filewrite.WriteLine(Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(15) & "PRINTED ON : " & Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Mid(MyCompanyName, 1, 30) & Space(30 - Len(Mid(MyCompanyName, 1, 30))))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(15) & Mid(Trim(HEADING), 1, 20) & Space(20 - Len(Mid(Trim(HEADING), 1, 20))))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(40) & "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("SNO SUBgroupcode SUBgroupdescRIPTION      FREEZE ADDUSER         ADDDATETIME")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    Public Function printdata(ByVal SQLSTRING As String, ByVal heading As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim docdate As Date
        Dim DOCNO As Integer
        Dim boolPosdesc, boolSUBgroupdesc, boolItemcode As Boolean
        Dim SUBgroupdesc, POSdesc, Itemdesc, Itemcode, SSQL, compcode As String
        Dim LocItemcount, LocationTotal, GroupItemcount, GrandItemcount, GroupTotal, GrandTotal As Double
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Call PrintHeader(heading, mskfromdate, msktodate)
            gconn.getDataSet(SQLSTRING, "roomcompanymasterhistory")
            Dim C As Integer
            C = 0
            If gdataset.Tables("roomcompanymasterhistory").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                For Each dr In gdataset.Tables("roomcompanymasterhistory").Rows
                    If pagesize > 58 Then
                        Filewrite.WriteLine(StrDup(79, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(heading, mskfromdate, msktodate)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    C = C + 1
                    SSQL = Space(3 - Len(Mid(Format(C, "0"), 1, 3))) & Mid(Format(C, "0"), 1, 3)
                    SSQL = SSQL & Space(1) & Mid(Format(dr("SUBgroupcode"), ""), 1, 10) & Space(10 - Len(Mid(Format(dr("SUBgroupcode"), ""), 1, 10)))
                    SSQL = SSQL & Space(1) & Mid(Format(dr("SUBgroupdesc"), ""), 1, 25) & Space(25 - Len(Mid(Format(dr("SUBgroupdesc"), ""), 1, 25)))
                    SSQL = SSQL & Space(1) & Mid(Format(dr("FREEZE"), ""), 1, 1) & Space(1 - Len(Mid(Format(dr("FREEZE"), ""), 1, 1)))
                    SSQL = SSQL & Space(1) & Mid(Format(dr("ADDUSER"), ""), 1, 15) & Space(15 - Len(Mid(Format(dr("ADDUSER"), ""), 1, 15)))
                    SSQL = SSQL & Space(1) & Space(11 - Len(Mid(Format(dr("ADDDATE"), ""), 1, 11))) & Mid(Format(dr("ADDDATE"), ""), 1, 11)
                    Filewrite.WriteLine(SSQL)
                    pagesize = pagesize + 1
                Next
                Filewrite.WriteLine(StrDup(79, "-"))
                pagesize = pagesize + 1
            Else
                MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Function
            End If
            Filewrite.Write(Chr(12))
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile(VFilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString & ex.HelpLink)
            Exit Function
        End Try
    End Function

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Grp_Print.Visible = False
    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "VIEW_PARTY_GROUPHISTORY"
        sqlstring = "SELECT * FROM VIEW_PARTY_GROUPHISTORY"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub txt_SUBgroupcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_SUBgroupcode.TextChanged

    End Sub

    Private Sub CMD_SUBgroupcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_SUBgroupcode.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT isnull(SUBgroupcode,'') as SUBgroupcode,isnull(SUBgroupdesc,'') as SUBgroupdesc FROM party_SUBGROUP_MASTER"
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "SUBgroupcode,SUBgroupdesc"
        vform.vFormatstring = "      sub  Group code    |     Sub Group Description    "
        vform.vCaption = " Sub Group Master Help"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_SUBgroupcode.Text = Trim(vform.keyfield & "")
            txt_SUBgroupcode.Select()
            'Txt_SUBgroupdesc.Text = Trim(vform.keyfield & "")
            cmd_Add1234.Text = "Update[F7]"
            'Txt_SUBgroupdesc.Focus()
            Call txt_SUBgroupcode_Validated(txt_SUBgroupcode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        txt_SUBgroupcode.Enabled = True
        CMD_SUBgroupcode2.Enabled = True

        Grp_Print.Visible = False

        lbl_freeze.Visible = False
        txt_SUBgroupcode.Text = ""
        Txt_SUBgroupdesc.Text = ""
        CMB_TYPE.Text = ""
        cmd_Add1234.Text = "Add[F7]"
        txt_SUBgroupcode.Focus()
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Call checkvalidate()
        If boolchk = False Then Exit Sub
        sqlstring = "INSERT INTO party_SUBGROUP_MASTER_LOG (SUBgroupcode,SUBgroupdesc,freeze,adduser,adddate) VALUES("
        sqlstring = sqlstring & " '" & Trim(txt_SUBgroupcode.Text) & "','" & Trim(Txt_SUBgroupdesc.Text) & "','N',"
        sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "')"
        gconn.dataOperation(6, sqlstring, "GRP")

        If Mid(Cmd_Add.Text, 1, 1) = "A" Then
            sqlstring = "INSERT INTO party_SUBGROUP_MASTER (SUBgroupcode,SUBgroupdesc,freeze,adduser,adddate) VALUES("
            sqlstring = sqlstring & " '" & Trim(txt_SUBgroupcode.Text) & "','" & Trim(Txt_SUBgroupdesc.Text) & "','N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "')"
            gconn.dataOperation(1, sqlstring, "GRP")
            Call Cmd_Clear_Click(sender, e)
        ElseIf Mid(Cmd_Add.Text, 1, 1) = "U" Then
            If lbl_freeze.Visible = True Then
                MsgBox("Freezed Record Cannot Be Updated", MsgBoxStyle.Information)
                Call Cmd_Clear_Click(sender, e)
                Exit Sub
            End If
            sqlstring = "UPDATE party_SUBGROUP_MASTER SET SUBgroupdesc='" & Trim(Txt_SUBgroupdesc.Text) & "',FREEZE='N',"
            sqlstring = sqlstring & " UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME='" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "' "
            sqlstring = sqlstring & " WHERE SUBgroupcode='" & Trim(txt_SUBgroupcode.Text) & "'"
            gconn.dataOperation(2, sqlstring, "GRP")
            Call Cmd_Clear_Click(sender, e)
        End If

    End Sub

    Private Sub CMD_FREEZE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_FREEZE.Click
        Call checkvalidate()
        If boolchk = False Then Exit Sub

        sqlstring = "INSERT INTO party_SUBGROUP_MASTER_LOG (SUBgroupcode,SUBgroupdesc,freeze,adduser,adddate) VALUES("
        sqlstring = sqlstring & " '" & Trim(txt_SUBgroupcode.Text) & "','" & Trim(Txt_SUBgroupdesc.Text) & "','N',"
        sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "')"
        gconn.dataOperation(6, sqlstring, "GRP")

        If Mid(CMD_FREEZE.Text, 1, 1) = "F" Then
            sqlstring = "SELECT ISNULL(SUBgroupcode,'')AS SUBgroupcode,ISNULL(SUBgroupdesc,'')AS SUBgroupdesc FROM party_SUBGROUP_MASTER"
            sqlstring = sqlstring & " WHERE ISNULL(SUBgroupcode,'')='" & Trim(txt_SUBgroupcode.Text) & "'"
            gconn.getDataSet(sqlstring, "GRP1")
            If gdataset.Tables("GRP1").Rows.Count > 0 Then
                sqlstring = "UPDATE party_SUBGROUP_MASTER SET FREEZE='Y',"
                sqlstring = sqlstring & " VOIDUSER='" & Trim(gUsername) & "',VOIDDATETIME='" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "' "
                sqlstring = sqlstring & " WHERE SUBgroupcode='" & Trim(txt_SUBgroupcode.Text) & "'"
                gconn.dataOperation(3, sqlstring, "GRP")
                Call Cmd_Clear_Click(sender, e)
            End If
        End If
        If Mid(CMD_FREEZE.Text, 1, 1) = "U" Then
            sqlstring = "UPDATE party_SUBGROUP_MASTER SET FREEZE='N',"
            sqlstring = sqlstring & " ADDUSER='" & Trim(gUsername) & "',ADDDATE='" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "' "
            sqlstring = sqlstring & " WHERE SUBgroupcode='" & Trim(txt_SUBgroupcode.Text) & "'"
            gconn.dataOperation(4, sqlstring, "GRP")
            Call Cmd_Clear_Click(sender, e)
        End If
    End Sub

    Private Sub Cmd_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_view.Click
        Dim FRM As New ReportDesigner
        If txt_SUBgroupcode.Text.Length > 0 Then
            tables = " FROM party_SUBGROUP_MASTER WHERE SUBGROUPCODE ='" & txt_SUBgroupcode.Text & "' "
        Else
            tables = "FROM party_SUBGROUP_MASTER "
        End If
        Gheader = "SESSION  DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"SUBGROUPCODE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SUBGROUPDESC", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"FREEZE", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDDATE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEUSER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATETIME", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_MAS_GROUPHISTORY
        STR = "SELECT * FROM VIEW_PARTY_GROUPHISTORY"
        Viewer.ssql = STR
        gconn.getDataSet(STR, "group")
        If gdataset.Tables("group").Rows.Count > 0 Then
            Viewer.Report = r
            Viewer.TableName = "VIEW_PARTY_GROUPHISTORY"
            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text6")
            textobj1.Text = MyCompanyName
            Dim TXTOBJ2 As TextObject
            TXTOBJ2 = r.ReportDefinition.ReportObjects("Text10")
            TXTOBJ2.Text = gUsername
            Viewer.Show()
            Grp_Print.Visible = False
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub


    Private Sub Cmdbwse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbwse.Click
        brows = True
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM party_SUBGROUP_MASTER"
        gconnection.getDataSet(STRQUERY, "authorize")

        Call VIEW1.LOADGRID(gdataset.Tables("authorize"), True, "", "SELECT * FROM party_SUBGROUP_MASTER", "SUBGROUPCODE", 1, Me.txt_SUBgroupcode)


    End Sub

    Private Sub Cmdauth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdauth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        Dim USERT As Integer
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 1
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 2
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 3
        End If
        If USERT = 1 Then
            SSQLSTR2 = " SELECT * FROM party_SUBGROUP_MASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM party_SUBGROUP_MASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE party_SUBGROUP_MASTER set  ", "SUBGROUPCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 0)
                        End If
                    Else
                        MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                    End If
                End If
            End If
        ElseIf USERT = 2 Then
            SSQLSTR2 = " SELECT * FROM party_SUBGROUP_MASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')='' AND ISNULL(AUTHORISE_USER1,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM party_SUBGROUP_MASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE party_SUBGROUP_MASTER set  ", "SUBGROUPCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            End If
        ElseIf USERT = 3 Then
            SSQLSTR2 = " SELECT * FROM party_SUBGROUP_MASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''  AND ISNULL(AUTHORISE_USER2,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM party_SUBGROUP_MASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE party_SUBGROUP_MASTER set  ", "SUBGROUPCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                        End If
                    End If
                End If
            Else
                MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    Private Sub CMD_EXIT_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_EXIT.Click
        Me.Close()
    End Sub
End Class
