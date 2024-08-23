Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Public Class PTY_GROUPMASTER
    Inherits System.Windows.Forms.Form
    Dim gconn As New GlobalClass
    Dim sqlstring As String
    Dim dr As DataRow
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim i As Integer
    Dim boolchk As Boolean
    Friend WithEvents CMD_GROUPCODE As System.Windows.Forms.Button
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
    Friend WithEvents cmd_Exit3 As System.Windows.Forms.Button
    Friend WithEvents cmd_Freeze2 As System.Windows.Forms.Button
    Friend WithEvents grp_StatusConversion4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Add1 As System.Windows.Forms.Button
    Friend WithEvents cmd_View2 As System.Windows.Forms.Button
    Friend WithEvents cmd_Clear3 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_Caption As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CMD_GROUPCODE1 As System.Windows.Forms.Button
    Friend WithEvents txt_GROUPCODE As System.Windows.Forms.TextBox
    Friend WithEvents Txt_GROUPDESC As System.Windows.Forms.TextBox
    Friend WithEvents Grp_Print As System.Windows.Forms.GroupBox
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMD_WINDOWS As System.Windows.Forms.Button
    Friend WithEvents CMD_DOS As System.Windows.Forms.Button
    Friend WithEvents cmd_print As System.Windows.Forms.Button
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PTY_GROUPMASTER))
        Me.lbl_freeze = New System.Windows.Forms.Label()
        Me.cmd_Exit3 = New System.Windows.Forms.Button()
        Me.cmd_Freeze2 = New System.Windows.Forms.Button()
        Me.grp_StatusConversion4 = New System.Windows.Forms.GroupBox()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.cmd_Add1 = New System.Windows.Forms.Button()
        Me.cmd_Clear3 = New System.Windows.Forms.Button()
        Me.cmd_print = New System.Windows.Forms.Button()
        Me.cmd_View2 = New System.Windows.Forms.Button()
        Me.CMD_GROUPCODE1 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_GROUPCODE = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_GROUPDESC = New System.Windows.Forms.TextBox()
        Me.lbl_Caption = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMD_GROUPCODE = New System.Windows.Forms.Button()
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
        Me.lbl_freeze.Location = New System.Drawing.Point(384, 424)
        Me.lbl_freeze.Name = "lbl_freeze"
        Me.lbl_freeze.Size = New System.Drawing.Size(165, 25)
        Me.lbl_freeze.TabIndex = 419
        Me.lbl_freeze.Text = "Record Freezed"
        Me.lbl_freeze.Visible = False
        '
        'cmd_Exit3
        '
        Me.cmd_Exit3.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Exit3.BackgroundImage = CType(resources.GetObject("cmd_Exit3.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Exit3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Exit3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Exit3.ForeColor = System.Drawing.Color.White
        Me.cmd_Exit3.Location = New System.Drawing.Point(560, 16)
        Me.cmd_Exit3.Name = "cmd_Exit3"
        Me.cmd_Exit3.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Exit3.TabIndex = 417
        Me.cmd_Exit3.Text = "Exit[F11]"
        Me.cmd_Exit3.UseVisualStyleBackColor = False
        '
        'cmd_Freeze2
        '
        Me.cmd_Freeze2.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Freeze2.BackgroundImage = CType(resources.GetObject("cmd_Freeze2.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Freeze2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Freeze2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Freeze2.ForeColor = System.Drawing.Color.White
        Me.cmd_Freeze2.Location = New System.Drawing.Point(296, 16)
        Me.cmd_Freeze2.Name = "cmd_Freeze2"
        Me.cmd_Freeze2.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Freeze2.TabIndex = 416
        Me.cmd_Freeze2.Text = "Freeze[F8]"
        Me.cmd_Freeze2.UseVisualStyleBackColor = False
        '
        'grp_StatusConversion4
        '
        Me.grp_StatusConversion4.BackColor = System.Drawing.Color.Transparent
        Me.grp_StatusConversion4.Controls.Add(Me.cmdexport)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Add1)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Clear3)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Freeze2)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Exit3)
        Me.grp_StatusConversion4.Location = New System.Drawing.Point(160, 456)
        Me.grp_StatusConversion4.Name = "grp_StatusConversion4"
        Me.grp_StatusConversion4.Size = New System.Drawing.Size(608, 64)
        Me.grp_StatusConversion4.TabIndex = 418
        Me.grp_StatusConversion4.TabStop = False
        Me.grp_StatusConversion4.Visible = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdexport.BackgroundImage = CType(resources.GetObject("cmdexport.BackgroundImage"), System.Drawing.Image)
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Location = New System.Drawing.Point(432, 16)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(104, 32)
        Me.cmdexport.TabIndex = 435
        Me.cmdexport.Text = "Crystal[F10]"
        Me.cmdexport.UseVisualStyleBackColor = False
        '
        'cmd_Add1
        '
        Me.cmd_Add1.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Add1.BackgroundImage = CType(resources.GetObject("cmd_Add1.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Add1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Add1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Add1.ForeColor = System.Drawing.Color.White
        Me.cmd_Add1.Location = New System.Drawing.Point(168, 16)
        Me.cmd_Add1.Name = "cmd_Add1"
        Me.cmd_Add1.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Add1.TabIndex = 378
        Me.cmd_Add1.Text = "Add[F7]"
        Me.cmd_Add1.UseVisualStyleBackColor = False
        '
        'cmd_Clear3
        '
        Me.cmd_Clear3.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Clear3.BackgroundImage = CType(resources.GetObject("cmd_Clear3.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Clear3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Clear3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Clear3.ForeColor = System.Drawing.Color.White
        Me.cmd_Clear3.Location = New System.Drawing.Point(24, 16)
        Me.cmd_Clear3.Name = "cmd_Clear3"
        Me.cmd_Clear3.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Clear3.TabIndex = 381
        Me.cmd_Clear3.Text = "Clear[F6]"
        Me.cmd_Clear3.UseVisualStyleBackColor = False
        '
        'cmd_print
        '
        Me.cmd_print.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_print.BackgroundImage = CType(resources.GetObject("cmd_print.BackgroundImage"), System.Drawing.Image)
        Me.cmd_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_print.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_print.ForeColor = System.Drawing.Color.White
        Me.cmd_print.Location = New System.Drawing.Point(687, 408)
        Me.cmd_print.Name = "cmd_print"
        Me.cmd_print.Size = New System.Drawing.Size(104, 32)
        Me.cmd_print.TabIndex = 382
        Me.cmd_print.Text = "Print[F10]"
        Me.cmd_print.UseVisualStyleBackColor = False
        Me.cmd_print.Visible = False
        '
        'cmd_View2
        '
        Me.cmd_View2.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_View2.BackgroundImage = CType(resources.GetObject("cmd_View2.BackgroundImage"), System.Drawing.Image)
        Me.cmd_View2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_View2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_View2.ForeColor = System.Drawing.Color.White
        Me.cmd_View2.Location = New System.Drawing.Point(664, 304)
        Me.cmd_View2.Name = "cmd_View2"
        Me.cmd_View2.Size = New System.Drawing.Size(104, 32)
        Me.cmd_View2.TabIndex = 379
        Me.cmd_View2.Text = "View [F9]"
        Me.cmd_View2.UseVisualStyleBackColor = False
        Me.cmd_View2.Visible = False
        '
        'CMD_GROUPCODE1
        '
        Me.CMD_GROUPCODE1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMD_GROUPCODE1.Location = New System.Drawing.Point(520, 116)
        Me.CMD_GROUPCODE1.Name = "CMD_GROUPCODE1"
        Me.CMD_GROUPCODE1.Size = New System.Drawing.Size(24, 24)
        Me.CMD_GROUPCODE1.TabIndex = 428
        Me.CMD_GROUPCODE1.UseVisualStyleBackColor = False
        Me.CMD_GROUPCODE1.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(56, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 15)
        Me.Label14.TabIndex = 426
        Me.Label14.Text = "Group Code"
        '
        'txt_GROUPCODE
        '
        Me.txt_GROUPCODE.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txt_GROUPCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_GROUPCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_GROUPCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_GROUPCODE.Location = New System.Drawing.Point(200, 16)
        Me.txt_GROUPCODE.Name = "txt_GROUPCODE"
        Me.txt_GROUPCODE.Size = New System.Drawing.Size(56, 21)
        Me.txt_GROUPCODE.TabIndex = 423
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(48, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(107, 15)
        Me.Label10.TabIndex = 427
        Me.Label10.Text = "Group Description"
        '
        'Txt_GROUPDESC
        '
        Me.Txt_GROUPDESC.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_GROUPDESC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_GROUPDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_GROUPDESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_GROUPDESC.Location = New System.Drawing.Point(200, 56)
        Me.Txt_GROUPDESC.MaxLength = 50
        Me.Txt_GROUPDESC.Name = "Txt_GROUPDESC"
        Me.Txt_GROUPDESC.Size = New System.Drawing.Size(192, 21)
        Me.Txt_GROUPDESC.TabIndex = 424
        '
        'lbl_Caption
        '
        Me.lbl_Caption.AutoSize = True
        Me.lbl_Caption.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Caption.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Caption.Location = New System.Drawing.Point(180, 77)
        Me.lbl_Caption.Name = "lbl_Caption"
        Me.lbl_Caption.Size = New System.Drawing.Size(216, 29)
        Me.lbl_Caption.TabIndex = 425
        Me.lbl_Caption.Text = "GROUP  MASTER"
        Me.lbl_Caption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CMD_GROUPCODE)
        Me.GroupBox1.Controls.Add(Me.Txt_GROUPDESC)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txt_GROUPCODE)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Location = New System.Drawing.Point(216, 194)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(456, 104)
        Me.GroupBox1.TabIndex = 429
        Me.GroupBox1.TabStop = False
        '
        'CMD_GROUPCODE
        '
        Me.CMD_GROUPCODE.Location = New System.Drawing.Point(258, 14)
        Me.CMD_GROUPCODE.Name = "CMD_GROUPCODE"
        Me.CMD_GROUPCODE.Size = New System.Drawing.Size(40, 23)
        Me.CMD_GROUPCODE.TabIndex = 428
        Me.CMD_GROUPCODE.Text = "?"
        Me.CMD_GROUPCODE.UseVisualStyleBackColor = True
        '
        'Grp_Print
        '
        Me.Grp_Print.BackColor = System.Drawing.Color.Transparent
        Me.Grp_Print.Controls.Add(Me.CMDEXIT)
        Me.Grp_Print.Controls.Add(Me.CMD_WINDOWS)
        Me.Grp_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Print.Location = New System.Drawing.Point(304, 392)
        Me.Grp_Print.Name = "Grp_Print"
        Me.Grp_Print.Size = New System.Drawing.Size(368, 56)
        Me.Grp_Print.TabIndex = 661
        Me.Grp_Print.TabStop = False
        Me.Grp_Print.Visible = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.CMD_WINDOWS.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMD_WINDOWS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_WINDOWS.Location = New System.Drawing.Point(56, 16)
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
        Me.CMD_DOS.Location = New System.Drawing.Point(120, 248)
        Me.CMD_DOS.Name = "CMD_DOS"
        Me.CMD_DOS.Size = New System.Drawing.Size(16, 32)
        Me.CMD_DOS.TabIndex = 0
        Me.CMD_DOS.Text = "DOS"
        Me.CMD_DOS.UseVisualStyleBackColor = False
        Me.CMD_DOS.Visible = False
        '
        'cmdreport
        '
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(857, 372)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(136, 55)
        Me.cmdreport.TabIndex = 676
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.UseVisualStyleBackColor = True
        '
        'CMD_EXIT
        '
        Me.CMD_EXIT.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_EXIT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_EXIT.Image = CType(resources.GetObject("CMD_EXIT.Image"), System.Drawing.Image)
        Me.CMD_EXIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_EXIT.Location = New System.Drawing.Point(857, 576)
        Me.CMD_EXIT.Name = "CMD_EXIT"
        Me.CMD_EXIT.Size = New System.Drawing.Size(136, 55)
        Me.CMD_EXIT.TabIndex = 675
        Me.CMD_EXIT.Text = "Exit [F11]"
        Me.CMD_EXIT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_EXIT.UseVisualStyleBackColor = True
        '
        'Cmdauth
        '
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(857, 509)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(136, 55)
        Me.Cmdauth.TabIndex = 674
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.UseVisualStyleBackColor = True
        '
        'Cmdbwse
        '
        Me.Cmdbwse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbwse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbwse.Location = New System.Drawing.Point(857, 439)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(136, 55)
        Me.Cmdbwse.TabIndex = 673
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.UseVisualStyleBackColor = True
        '
        'Cmd_view
        '
        Me.Cmd_view.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_view.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_view.Image = CType(resources.GetObject("Cmd_view.Image"), System.Drawing.Image)
        Me.Cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_view.Location = New System.Drawing.Point(857, 304)
        Me.Cmd_view.Name = "Cmd_view"
        Me.Cmd_view.Size = New System.Drawing.Size(136, 55)
        Me.Cmd_view.TabIndex = 672
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
        Me.CMD_FREEZE.Location = New System.Drawing.Point(857, 238)
        Me.CMD_FREEZE.Name = "CMD_FREEZE"
        Me.CMD_FREEZE.Size = New System.Drawing.Size(136, 55)
        Me.CMD_FREEZE.TabIndex = 671
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
        Me.Cmd_Clear.Location = New System.Drawing.Point(857, 100)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(136, 55)
        Me.Cmd_Clear.TabIndex = 670
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
        Me.Cmd_Add.Location = New System.Drawing.Point(857, 161)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(136, 55)
        Me.Cmd_Add.TabIndex = 669
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'PTY_GROUPMASTER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1016, 733)
        Me.Controls.Add(Me.cmdreport)
        Me.Controls.Add(Me.CMD_EXIT)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbwse)
        Me.Controls.Add(Me.Cmd_view)
        Me.Controls.Add(Me.CMD_FREEZE)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Grp_Print)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_Caption)
        Me.Controls.Add(Me.lbl_freeze)
        Me.Controls.Add(Me.CMD_GROUPCODE1)
        Me.Controls.Add(Me.grp_StatusConversion4)
        Me.Controls.Add(Me.cmd_View2)
        Me.Controls.Add(Me.cmd_print)
        Me.Controls.Add(Me.CMD_DOS)
        Me.KeyPreview = True
        Me.Name = "PTY_GROUPMASTER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MENU MASTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_StatusConversion4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Grp_Print.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub checkvalidate()
        boolchk = False
        If Trim(txt_GROUPCODE.Text) = "" Then
            MessageBox.Show("Menu Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_GROUPCODE.Focus()
            Exit Sub
        End If
        If Trim(Txt_GROUPDESC.Text) = "" Then
            MessageBox.Show("Menu Description Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_GROUPDESC.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub


    Private Sub txt_GROUPCODE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_GROUPCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_GROUPCODE.Text) <> "" Then
                Call txt_GROUPCODE_Validated(txt_GROUPCODE, e)
            Else
                Call CMD_GROUPCODE_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txt_GROUPCODE_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_GROUPCODE.Validated
        If Trim(txt_GROUPCODE.Text) <> "" Then
            sqlstring = "SELECT ISNULL(GROUPCODE,'')AS GROUPCODE,ISNULL(GROUPDESC,'')AS GROUPDESC,ISNULL(FREEZE,'')AS FREEZE FROM party_GROUP_MASTER"
            sqlstring = sqlstring & " WHERE ISNULL(GROUPCODE,'')='" & Trim(txt_GROUPCODE.Text) & "'"
            gconn.getDataSet(sqlstring, "GRP")
            If gdataset.Tables("GRP").Rows.Count > 0 Then
                cmd_Add1.Text = "Update[F7]"
                txt_GROUPCODE.Text = gdataset.Tables("GRP").Rows(0).Item("GROUPCODE")
                Txt_GROUPDESC.Text = gdataset.Tables("GRP").Rows(0).Item("GROUPDESC")
                If gdataset.Tables("GRP").Rows(0).Item("FREEZE") = "Y" Then
                    lbl_freeze.Visible = True
                    cmd_Freeze2.Text = "Unfreeze[F8]"
                Else
                    lbl_freeze.Visible = False
                End If
                txt_GROUPCODE.Enabled = False
                CMD_GROUPCODE1.Enabled = False
                Txt_GROUPDESC.Focus()
            Else
                'MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                txt_GROUPCODE.Enabled = True
                CMD_GROUPCODE1.Enabled = True
                Txt_GROUPDESC.Focus()
            End If
        End If
    End Sub



    'Private Sub cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_View2.Click
    'Dim FrReport As New ReportDesigner
    'tables = " FROM party_GROUP_MASTER"
    'Gheader = "MENU MASTER"
    'FrReport.SsGridReport.SetText(2, 1, "GROUPCODE")
    'FrReport.SsGridReport.SetText(3, 1, 10)
    'FrReport.SsGridReport.SetText(2, 2, "GROUPDESC")
    'FrReport.SsGridReport.SetText(3, 2, 25)
    'FrReport.SsGridReport.SetText(2, 3, "FREEZE")
    'FrReport.SsGridReport.SetText(3, 3, 6)
    'FrReport.Show()



    'End Sub
    Private Sub PTY_MENUMASTER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Call Resize_Form()
        gconnection.FocusSetting(Me)
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Show()
        txt_GROUPCODE.Focus()
    End Sub
    Private Sub Resize_Form()
        Dim cControl As Control
        Dim i_i As Integer
        Dim J, K, L, M, n, o, P, Q, R, S As Integer
        If (Screen.PrimaryScreen.Bounds.Height = 760) And (Screen.PrimaryScreen.Bounds.Width = 1024) Then
            Exit Sub
        End If

        Me.ResizeRedraw = True
        J = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        K = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        Me.Width = K
        Me.Height = J


        With Me
            For i_i = 0 To .Controls.Count - 1

                If TypeOf .Controls(i_i) Is Panel Then


                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - 1024) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - 760) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - 1024) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - 760) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o

                    For Each cControl In .Controls(i_i).Controls

                        If cControl.Location.X = 0 Then
                            R = 0
                        Else
                            R = cControl.Location.X + CInt((cControl.Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - 1024) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                        End If
                        If cControl.Location.Y = 0 Then
                            S = 0
                        Else
                            S = cControl.Location.Y + CInt((cControl.Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - 760) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                        End If

                        cControl.Left = R
                        cControl.Top = S


                        If cControl.Size.Width = 0 Then
                            P = 0
                        Else
                            P = (cControl.Size.Width + CInt((cControl.Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - 1024) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)))))
                        End If

                        If cControl.Size.Height = 0 Then
                            Q = 0
                        Else
                            Q = (cControl.Size.Height + CInt((cControl.Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - 760) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)))))
                        End If

                        cControl.Width = P
                        cControl.Height = Q
                    Next
                ElseIf TypeOf .Controls(i_i) Is Label Then
                    If .Controls(i_i).Location.X = 0 Then
                        L = 0
                    Else
                        L = .Controls(i_i).Location.X + CInt((.Controls(i_i).Location.X) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - 1024) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Location.Y = 0 Then
                        L = 0

                    Else
                        M = .Controls(i_i).Location.Y + CInt((.Controls(i_i).Location.Y) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - 760) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Left = L
                    .Controls(i_i).Top = M
                    If .Controls(i_i).Size.Width = 0 Then
                        n = 0
                    Else
                        n = .Controls(i_i).Size.Width + CInt((.Controls(i_i).Size.Width) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Width) - 1024) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Width))))
                    End If
                    If .Controls(i_i).Size.Height = 0 Then
                        o = 0
                    Else
                        o = .Controls(i_i).Size.Height + CInt((.Controls(i_i).Size.Height) * ((CInt(Screen.PrimaryScreen.WorkingArea.Size.Height) - 760) / (CInt(Screen.PrimaryScreen.WorkingArea.Size.Height))))
                    End If

                    .Controls(i_i).Width = n
                    .Controls(i_i).Height = o
                End If
            Next i_i
        End With
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
        Me.cmd_Add1.Enabled = False
        ' Me.cmd_Delete.Enabled = False
        Me.cmd_View2.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.cmd_Add1.Enabled = True
                    'Me.cmd_Delete.Enabled = True
                    Me.cmd_View2.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.cmd_Add1.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.cmd_Add1.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.cmd_Add1.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    'Me.cmd_Delete.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.cmd_View2.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub PTY_MENUMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(sender, e)
        ElseIf e.KeyCode = Keys.F7 Then
            Call Cmd_Add_Click(sender, e)
        ElseIf e.KeyCode = Keys.F8 Then
            Call CMD_FREEZE_Click(sender, e)
        ElseIf e.KeyCode = Keys.F9 Then
            Call Cmd_view_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            Call CMD_EXIT_Click(sender, e)
        ElseIf e.KeyCode = Keys.F10 Then
            Call cmdexport_Click(sender, e)
        End If
    End Sub
    Private Sub Txt_GROUPDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_GROUPDESC.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cmd_Add.Focus()
        End If
    End Sub
    Private Sub CMD_PRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_print.Click
        gPrint = True
        Grp_Print.Visible = True
    End Sub
    Private Sub CMD_WINDOWS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_WINDOWS.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_MAS_MENUHISTORY
        STR = "SELECT * FROM VIEW_PARTY_MENUHISTORY"
        Viewer.ssql = STR
        gconn.getDataSet(STR, "menu")
        If (gdataset.Tables("menu").Rows.Count > 0) Then
            Viewer.Report = r
            Viewer.TableName = "VIEW_PARTY_MENUHISTORY"
            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text1")
            textobj1.Text = MyCompanyName
            Dim TXTOBJ2 As TextObject
            TXTOBJ2 = r.ReportDefinition.ReportObjects("Text5")
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
        heading = "MENU MASTER"
        str = "SELECT * from VIEW_PARTY_MENUHISTORY"
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
            Filewrite.WriteLine("SNO MENU CODE MENU DESCRIPTION      FREEZE ADDUSER         ADDDATETIME")
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
        Dim boolPosdesc, boolgroupdesc, boolItemcode As Boolean
        Dim GroupDesc, POSdesc, Itemdesc, Itemcode, SSQL, compcode As String
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
                    SSQL = SSQL & Space(1) & Mid(Format(dr("GROUPCODE"), ""), 1, 10) & Space(10 - Len(Mid(Format(dr("GROUPCODE"), ""), 1, 10)))
                    SSQL = SSQL & Space(1) & Mid(Format(dr("GROUPDESC"), ""), 1, 25) & Space(25 - Len(Mid(Format(dr("GROUPDESC"), ""), 1, 25)))
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
        gPrint = False
        Grp_Print.Visible = True
    End Sub

    Private Sub txt_GROUPCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_GROUPCODE.TextChanged

    End Sub

    Private Sub CMD_GROUPCODE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_GROUPCODE.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT isnull(GROUPCODE,'') as GROUPCODE,isnull(GROUPDESC,'') as GROUPDESC FROM party_GROUP_MASTER"
            M_WhereCondition = " "
            vform.Field = "GROUPCODE,GROUPDESC"
            vform.vFormatstring = "        Group Code    |     Group Description    "
            vform.vCaption = "Group Master Help"
            ' '' ''vform.KeyPos = 0
            ' '' ''vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_GROUPCODE.Text = Trim(vform.keyfield & "")
                'Txt_GROUPDESC.Text = Trim(vform.keyfield & "")
                txt_GROUPCODE.Select()
                Cmd_Add.Text = "Update[F7]"
                ' Txt_GROUPDESC.Focus()
                Call txt_GROUPCODE_Validated(txt_GROUPCODE, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        txt_GROUPCODE.Enabled = True
        CMD_GROUPCODE1.Enabled = True
        lbl_freeze.Visible = False
        txt_GROUPCODE.Text = ""
        Txt_GROUPDESC.Text = ""
        cmd_Add1.Text = "Add[F7]"
        cmd_Freeze2.Text = "Freeze[F8]"
        txt_GROUPCODE.Focus()
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Call checkvalidate() 'consider this is group master
        If boolchk = False Then Exit Sub
        sqlstring = "INSERT INTO party_GROUP_master_log (groupcode,groupdesc,freeze,adduser,adddate) VALUES("
        sqlstring = sqlstring & " '" & Trim(txt_GROUPCODE.Text) & "','" & Trim(Txt_GROUPDESC.Text) & "','N',"
        sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "')"
        gconn.dataOperation(6, sqlstring, "GRP")


        If Mid(cmd_Add1.Text, 1, 1) = "A" Then
            sqlstring = "INSERT INTO party_GROUP_MASTER (groupcode,groupdesc,freeze,adduser,adddate) VALUES("
            sqlstring = sqlstring & " '" & Trim(txt_GROUPCODE.Text) & "','" & Trim(Txt_GROUPDESC.Text) & "','N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "')"
            gconn.dataOperation(1, sqlstring, "GRP")
            Call Cmd_Clear_Click(sender, e)
        ElseIf Mid(cmd_Add1.Text, 1, 1) = "U" Then
            If lbl_freeze.Visible = True Then
                MsgBox("Freezed Record Cannot Be Updated", MsgBoxStyle.Information)
                Call Cmd_Clear_Click(sender, e)
                Exit Sub
            End If
            sqlstring = "UPDATE party_GROUP_MASTER SET groupDESC='" & Trim(Txt_GROUPDESC.Text) & "',FREEZE='N',"
            sqlstring = sqlstring & " updateuser='" & Trim(gUsername) & "',updatetime='" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "' "
            sqlstring = sqlstring & " WHERE groupCODE='" & Trim(txt_GROUPCODE.Text) & "'"
            gconn.dataOperation(2, sqlstring, "GRP")
            Call Cmd_Clear_Click(sender, e)
        End If
    End Sub

    Private Sub CMD_FREEZE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_FREEZE.Click
        Call checkvalidate()
        If boolchk = False Then Exit Sub
        sqlstring = "INSERT INTO party_GROUP_master_log (groupcode,groupdesc,freeze,adduser,adddate) VALUES("
        sqlstring = sqlstring & " '" & Trim(txt_GROUPCODE.Text) & "','" & Trim(Txt_GROUPDESC.Text) & "','N',"
        sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "')"
        gconn.dataOperation(6, sqlstring, "GRP")

        If Mid(cmd_Freeze2.Text, 1, 1) = "F" Then
            sqlstring = "SELECT ISNULL(groupCODE,'')AS groupCODE,ISNULL(groupDESC,'')AS groupDESC FROM party_GROUP_MASTER"
            sqlstring = sqlstring & " WHERE ISNULL(groupCODE,'')='" & Trim(txt_GROUPCODE.Text) & "'"
            gconn.getDataSet(sqlstring, "GRP1")
            If gdataset.Tables("GRP1").Rows.Count > 0 Then
                sqlstring = "UPDATE party_GROUP_MASTER SET FREEZE='Y',"
                sqlstring = sqlstring & " voiduser='" & Trim(gUsername) & "',voiddatetime='" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "' "
                sqlstring = sqlstring & " WHERE groupCODE='" & Trim(txt_GROUPCODE.Text) & "'"
                gconn.dataOperation(3, sqlstring, "GRP")
                Call Cmd_Clear_Click(sender, e)
            End If
        End If
        If Mid(cmd_Freeze2.Text, 1, 1) = "U" Then
            sqlstring = "UPDATE party_GROUP_MASTER SET FREEZE='N',"
            sqlstring = sqlstring & " ADDUSER='" & Trim(gUsername) & "',ADDDATE='" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "' "
            sqlstring = sqlstring & " WHERE groupCODE='" & Trim(txt_GROUPCODE.Text) & "'"
            gconn.dataOperation(4, sqlstring, "GRP")
            Call Cmd_Clear_Click(sender, e)
        End If
    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_MAS_MENUHISTORY
        STR = "SELECT * FROM VIEW_PARTY_MENUHISTORY"
        Viewer.ssql = STR
        gconn.getDataSet(STR, "menu")
        If (gdataset.Tables("menu").Rows.Count > 0) Then
            Viewer.Report = r
            Viewer.TableName = "VIEW_PARTY_MENUHISTORY"
            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text1")
            textobj1.Text = MyCompanyName
            Dim TXTOBJ2 As TextObject
            TXTOBJ2 = r.ReportDefinition.ReportObjects("Text5")
            TXTOBJ2.Text = gUsername
            Viewer.Show()
            Grp_Print.Visible = False
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub



    Private Sub CMD_EXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_EXIT.Click
        Me.Close()
    End Sub

    Private Sub Cmdbwse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbwse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM party_GROUP_MASTER"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM party_GROUP_MASTER", "groupcode", 0)

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
            SSQLSTR2 = " SELECT * FROM party_GROUP_MASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM party_GROUP_MASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE party_GROUP_MASTER set  ", "groupcode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 0)
                        End If
                    Else
                        MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                    End If
                End If
            End If
        ElseIf USERT = 2 Then
            SSQLSTR2 = " SELECT * FROM party_GROUP_MASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')='' AND ISNULL(AUTHORISE_USER1,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM party_GROUP_MASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE party_GROUP_MASTER set  ", "groupcode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            End If
        ElseIf USERT = 3 Then
            SSQLSTR2 = " SELECT * FROM party_GROUP_MASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''  AND ISNULL(AUTHORISE_USER2,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM party_GROUP_MASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE party_GROUP_MASTER set  ", "groupcode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                        End If
                    End If
                End If
            Else
                MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    Private Sub Cmd_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_view.Click
        Dim FRM As New ReportDesigner
        If txt_GROUPCODE.Text.Length > 0 Then
            tables = " FROM party_GROUP_MASTER WHERE groupcode ='" & txt_GROUPCODE.Text & "' "
        Else
            tables = "FROM party_GROUP_MASTER "
        End If
        Gheader = "GROUP DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"groupCODE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"groupDESC", "20"}
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

    Private Sub Txt_GROUPDESC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_GROUPDESC.TextChanged

    End Sub
End Class
