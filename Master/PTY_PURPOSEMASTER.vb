Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Public Class PTY_PURPOSEMASTER
    Inherits System.Windows.Forms.Form
    Dim gconn As New GlobalClass
    Dim sqlstring As String
    Dim dr As DataRow
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim i As Integer
    Dim boolchk As Boolean
    Friend WithEvents cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cmd_add As System.Windows.Forms.Button
    Friend WithEvents cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents btn_browse As System.Windows.Forms.Button
    Friend WithEvents btn_authorize As System.Windows.Forms.Button
    Friend WithEvents CMD_Pcode As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents cmd_View As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Dim GCONNECTION As New GlobalClass
    Dim rs As New Resizer1

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
    Friend WithEvents cmd_Freeze1 As System.Windows.Forms.Button
    Friend WithEvents grp_StatusConversion4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Add1 As System.Windows.Forms.Button
    Friend WithEvents cmd_View2 As System.Windows.Forms.Button
    Friend WithEvents cmd_Clear1 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_Caption As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CMD_Pcode1 As System.Windows.Forms.Button
    Friend WithEvents txt_PCode As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PDesc As System.Windows.Forms.TextBox
    Friend WithEvents Grp_Print As System.Windows.Forms.GroupBox
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMD_WINDOWS As System.Windows.Forms.Button
    Friend WithEvents CMD_DOS As System.Windows.Forms.Button
    Friend WithEvents CMD_PRINT As System.Windows.Forms.Button
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents Txt_totime1 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Fromtime1 As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Fromtime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_totime As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PTY_PURPOSEMASTER))
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader()
        Me.lbl_freeze = New System.Windows.Forms.Label()
        Me.cmd_Exit1 = New System.Windows.Forms.Button()
        Me.cmd_Freeze1 = New System.Windows.Forms.Button()
        Me.grp_StatusConversion4 = New System.Windows.Forms.GroupBox()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.cmd_Add1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmd_Clear1 = New System.Windows.Forms.Button()
        Me.CMD_PRINT = New System.Windows.Forms.Button()
        Me.cmd_View2 = New System.Windows.Forms.Button()
        Me.CMD_Pcode1 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_PCode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_PDesc = New System.Windows.Forms.TextBox()
        Me.lbl_Caption = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMD_Pcode = New System.Windows.Forms.Button()
        Me.Txt_totime = New System.Windows.Forms.DateTimePicker()
        Me.Txt_Fromtime = New System.Windows.Forms.DateTimePicker()
        Me.Txt_totime1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Fromtime1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Grp_Print = New System.Windows.Forms.GroupBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMD_WINDOWS = New System.Windows.Forms.Button()
        Me.CMD_DOS = New System.Windows.Forms.Button()
        Me.cmd_Exit = New System.Windows.Forms.Button()
        Me.cmd_add = New System.Windows.Forms.Button()
        Me.cmd_Freeze = New System.Windows.Forms.Button()
        Me.cmd_Clear = New System.Windows.Forms.Button()
        Me.btn_browse = New System.Windows.Forms.Button()
        Me.btn_authorize = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.cmd_View = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.grp_StatusConversion4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Grp_Print.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_freeze
        '
        Me.lbl_freeze.AutoSize = True
        Me.lbl_freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_freeze.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_freeze.Location = New System.Drawing.Point(352, 430)
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
        Me.cmd_Exit1.TabIndex = 417
        Me.cmd_Exit1.Text = "Exit[F11]"
        Me.cmd_Exit1.UseVisualStyleBackColor = False
        '
        'cmd_Freeze1
        '
        Me.cmd_Freeze1.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Freeze1.BackgroundImage = CType(resources.GetObject("cmd_Freeze1.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Freeze1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Freeze1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Freeze1.ForeColor = System.Drawing.Color.White
        Me.cmd_Freeze1.Location = New System.Drawing.Point(336, 16)
        Me.cmd_Freeze1.Name = "cmd_Freeze1"
        Me.cmd_Freeze1.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Freeze1.TabIndex = 416
        Me.cmd_Freeze1.Text = "Freeze[F8]"
        Me.cmd_Freeze1.UseVisualStyleBackColor = False
        '
        'grp_StatusConversion4
        '
        Me.grp_StatusConversion4.BackColor = System.Drawing.Color.Transparent
        Me.grp_StatusConversion4.Controls.Add(Me.cmdexport)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Add1)
        Me.grp_StatusConversion4.Controls.Add(Me.Button4)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Clear1)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Exit1)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Freeze1)
        Me.grp_StatusConversion4.Location = New System.Drawing.Point(84, 176)
        Me.grp_StatusConversion4.Name = "grp_StatusConversion4"
        Me.grp_StatusConversion4.Size = New System.Drawing.Size(10, 64)
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
        Me.cmdexport.Location = New System.Drawing.Point(472, 16)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(104, 32)
        Me.cmdexport.TabIndex = 434
        Me.cmdexport.Text = "Report[F10]"
        Me.cmdexport.UseVisualStyleBackColor = False
        '
        'cmd_Add1
        '
        Me.cmd_Add1.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Add1.BackgroundImage = CType(resources.GetObject("cmd_Add1.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Add1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Add1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Add1.ForeColor = System.Drawing.Color.White
        Me.cmd_Add1.Location = New System.Drawing.Point(184, 16)
        Me.cmd_Add1.Name = "cmd_Add1"
        Me.cmd_Add1.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Add1.TabIndex = 378
        Me.cmd_Add1.Text = "Add[F7]"
        Me.cmd_Add1.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(621, 5)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(10, 54)
        Me.Button4.TabIndex = 663
        Me.Button4.Text = "EXPORT"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'cmd_Clear1
        '
        Me.cmd_Clear1.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Clear1.BackgroundImage = CType(resources.GetObject("cmd_Clear1.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Clear1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Clear1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Clear1.ForeColor = System.Drawing.Color.White
        Me.cmd_Clear1.Location = New System.Drawing.Point(32, 16)
        Me.cmd_Clear1.Name = "cmd_Clear1"
        Me.cmd_Clear1.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Clear1.TabIndex = 381
        Me.cmd_Clear1.Text = "Clear[F6]"
        Me.cmd_Clear1.UseVisualStyleBackColor = False
        '
        'CMD_PRINT
        '
        Me.CMD_PRINT.BackColor = System.Drawing.SystemColors.Menu
        Me.CMD_PRINT.BackgroundImage = CType(resources.GetObject("CMD_PRINT.BackgroundImage"), System.Drawing.Image)
        Me.CMD_PRINT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMD_PRINT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_PRINT.ForeColor = System.Drawing.Color.White
        Me.CMD_PRINT.Location = New System.Drawing.Point(12, 122)
        Me.CMD_PRINT.Name = "CMD_PRINT"
        Me.CMD_PRINT.Size = New System.Drawing.Size(41, 32)
        Me.CMD_PRINT.TabIndex = 382
        Me.CMD_PRINT.Text = "Print [F10]"
        Me.CMD_PRINT.UseVisualStyleBackColor = False
        Me.CMD_PRINT.Visible = False
        '
        'cmd_View2
        '
        Me.cmd_View2.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_View2.BackgroundImage = CType(resources.GetObject("cmd_View2.BackgroundImage"), System.Drawing.Image)
        Me.cmd_View2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_View2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_View2.ForeColor = System.Drawing.Color.White
        Me.cmd_View2.Location = New System.Drawing.Point(12, 334)
        Me.cmd_View2.Name = "cmd_View2"
        Me.cmd_View2.Size = New System.Drawing.Size(104, 32)
        Me.cmd_View2.TabIndex = 379
        Me.cmd_View2.Text = "View [F9]"
        Me.cmd_View2.UseVisualStyleBackColor = False
        Me.cmd_View2.Visible = False
        '
        'CMD_Pcode1
        '
        Me.CMD_Pcode1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMD_Pcode1.Image = CType(resources.GetObject("CMD_Pcode1.Image"), System.Drawing.Image)
        Me.CMD_Pcode1.Location = New System.Drawing.Point(380, 19)
        Me.CMD_Pcode1.Name = "CMD_Pcode1"
        Me.CMD_Pcode1.Size = New System.Drawing.Size(24, 24)
        Me.CMD_Pcode1.TabIndex = 428
        Me.CMD_Pcode1.UseVisualStyleBackColor = False
        Me.CMD_Pcode1.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(32, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(86, 15)
        Me.Label14.TabIndex = 426
        Me.Label14.Text = "Session Code"
        '
        'txt_PCode
        '
        Me.txt_PCode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txt_PCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_PCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_PCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_PCode.Location = New System.Drawing.Point(200, 16)
        Me.txt_PCode.MaxLength = 10
        Me.txt_PCode.Name = "txt_PCode"
        Me.txt_PCode.Size = New System.Drawing.Size(64, 21)
        Me.txt_PCode.TabIndex = 423
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(32, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(119, 15)
        Me.Label10.TabIndex = 427
        Me.Label10.Text = "Session Description"
        '
        'Txt_PDesc
        '
        Me.Txt_PDesc.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_PDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_PDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_PDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_PDesc.Location = New System.Drawing.Point(200, 56)
        Me.Txt_PDesc.MaxLength = 50
        Me.Txt_PDesc.Name = "Txt_PDesc"
        Me.Txt_PDesc.Size = New System.Drawing.Size(192, 21)
        Me.Txt_PDesc.TabIndex = 424
        '
        'lbl_Caption
        '
        Me.lbl_Caption.AutoSize = True
        Me.lbl_Caption.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Caption.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Caption.Location = New System.Drawing.Point(241, 67)
        Me.lbl_Caption.Name = "lbl_Caption"
        Me.lbl_Caption.Size = New System.Drawing.Size(306, 29)
        Me.lbl_Caption.TabIndex = 425
        Me.lbl_Caption.Text = "HALL SESSION  MASTER"
        Me.lbl_Caption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CMD_Pcode)
        Me.GroupBox1.Controls.Add(Me.Txt_totime)
        Me.GroupBox1.Controls.Add(Me.Txt_Fromtime)
        Me.GroupBox1.Controls.Add(Me.Txt_totime1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Txt_Fromtime1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Txt_PDesc)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txt_PCode)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.CMD_Pcode1)
        Me.GroupBox1.Location = New System.Drawing.Point(236, 229)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 184)
        Me.GroupBox1.TabIndex = 429
        Me.GroupBox1.TabStop = False
        '
        'CMD_Pcode
        '
        Me.CMD_Pcode.Location = New System.Drawing.Point(265, 15)
        Me.CMD_Pcode.Name = "CMD_Pcode"
        Me.CMD_Pcode.Size = New System.Drawing.Size(36, 23)
        Me.CMD_Pcode.TabIndex = 437
        Me.CMD_Pcode.Text = "?"
        Me.CMD_Pcode.UseVisualStyleBackColor = True
        '
        'Txt_totime
        '
        Me.Txt_totime.Checked = False
        Me.Txt_totime.CustomFormat = "HH:mm"
        Me.Txt_totime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Txt_totime.Location = New System.Drawing.Point(200, 136)
        Me.Txt_totime.Name = "Txt_totime"
        Me.Txt_totime.Size = New System.Drawing.Size(88, 20)
        Me.Txt_totime.TabIndex = 436
        Me.Txt_totime.Value = New Date(2012, 8, 24, 0, 0, 0, 0)
        '
        'Txt_Fromtime
        '
        Me.Txt_Fromtime.Checked = False
        Me.Txt_Fromtime.CustomFormat = "HH:mm"
        Me.Txt_Fromtime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Txt_Fromtime.Location = New System.Drawing.Point(200, 96)
        Me.Txt_Fromtime.Name = "Txt_Fromtime"
        Me.Txt_Fromtime.Size = New System.Drawing.Size(88, 20)
        Me.Txt_Fromtime.TabIndex = 435
        Me.Txt_Fromtime.Value = New Date(2012, 8, 24, 0, 0, 0, 0)
        '
        'Txt_totime1
        '
        Me.Txt_totime1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_totime1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_totime1.CausesValidation = CType(configurationAppSettings.GetValue("Txt_totime.CausesValidation", GetType(Boolean)), Boolean)
        Me.Txt_totime1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_totime1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_totime1.Location = New System.Drawing.Point(448, 136)
        Me.Txt_totime1.MaxLength = 5
        Me.Txt_totime1.Name = "Txt_totime1"
        Me.Txt_totime1.Size = New System.Drawing.Size(80, 21)
        Me.Txt_totime1.TabIndex = 431
        Me.Txt_totime1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 432
        Me.Label2.Text = "To Time"
        '
        'Txt_Fromtime1
        '
        Me.Txt_Fromtime1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_Fromtime1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Fromtime1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Fromtime1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Fromtime1.Location = New System.Drawing.Point(448, 96)
        Me.Txt_Fromtime1.MaxLength = 5
        Me.Txt_Fromtime1.Name = "Txt_Fromtime1"
        Me.Txt_Fromtime1.Size = New System.Drawing.Size(80, 21)
        Me.Txt_Fromtime1.TabIndex = 429
        Me.Txt_Fromtime1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(32, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 430
        Me.Label1.Text = "From Time"
        '
        'Grp_Print
        '
        Me.Grp_Print.BackColor = System.Drawing.Color.Transparent
        Me.Grp_Print.Controls.Add(Me.CMDEXIT)
        Me.Grp_Print.Controls.Add(Me.CMD_WINDOWS)
        Me.Grp_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Print.Location = New System.Drawing.Point(104, 176)
        Me.Grp_Print.Name = "Grp_Print"
        Me.Grp_Print.Size = New System.Drawing.Size(12, 56)
        Me.Grp_Print.TabIndex = 659
        Me.Grp_Print.TabStop = False
        Me.Grp_Print.Visible = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMDEXIT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.Location = New System.Drawing.Point(165, 16)
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
        Me.CMD_WINDOWS.Location = New System.Drawing.Point(72, 16)
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
        Me.CMD_DOS.Location = New System.Drawing.Point(84, 250)
        Me.CMD_DOS.Name = "CMD_DOS"
        Me.CMD_DOS.Size = New System.Drawing.Size(50, 32)
        Me.CMD_DOS.TabIndex = 0
        Me.CMD_DOS.Text = "6+"
        Me.CMD_DOS.UseVisualStyleBackColor = False
        Me.CMD_DOS.Visible = False
        '
        'cmd_Exit
        '
        Me.cmd_Exit.BackColor = System.Drawing.Color.Gainsboro
        Me.cmd_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_Exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Exit.Image = CType(resources.GetObject("cmd_Exit.Image"), System.Drawing.Image)
        Me.cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_Exit.Location = New System.Drawing.Point(17, 486)
        Me.cmd_Exit.Name = "cmd_Exit"
        Me.cmd_Exit.Size = New System.Drawing.Size(155, 65)
        Me.cmd_Exit.TabIndex = 664
        Me.cmd_Exit.Text = "EXIT[F11]"
        Me.cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_Exit.UseVisualStyleBackColor = False
        '
        'cmd_add
        '
        Me.cmd_add.BackColor = System.Drawing.Color.Gainsboro
        Me.cmd_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_add.Image = CType(resources.GetObject("cmd_add.Image"), System.Drawing.Image)
        Me.cmd_add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_add.Location = New System.Drawing.Point(17, 88)
        Me.cmd_add.Name = "cmd_add"
        Me.cmd_add.Size = New System.Drawing.Size(155, 65)
        Me.cmd_add.TabIndex = 661
        Me.cmd_add.Text = "Add [F7]"
        Me.cmd_add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_add.UseVisualStyleBackColor = False
        '
        'cmd_Freeze
        '
        Me.cmd_Freeze.BackColor = System.Drawing.Color.Gainsboro
        Me.cmd_Freeze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_Freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Freeze.Image = CType(resources.GetObject("cmd_Freeze.Image"), System.Drawing.Image)
        Me.cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_Freeze.Location = New System.Drawing.Point(17, 156)
        Me.cmd_Freeze.Name = "cmd_Freeze"
        Me.cmd_Freeze.Size = New System.Drawing.Size(155, 65)
        Me.cmd_Freeze.TabIndex = 662
        Me.cmd_Freeze.Text = "FREEZE[F8]"
        Me.cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_Freeze.UseVisualStyleBackColor = False
        '
        'cmd_Clear
        '
        Me.cmd_Clear.BackColor = System.Drawing.Color.Gainsboro
        Me.cmd_Clear.BackgroundImage = CType(resources.GetObject("cmd_Clear.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_Clear.Location = New System.Drawing.Point(17, 18)
        Me.cmd_Clear.Name = "cmd_Clear"
        Me.cmd_Clear.Size = New System.Drawing.Size(155, 65)
        Me.cmd_Clear.TabIndex = 660
        Me.cmd_Clear.Text = "CLEAR[F6]"
        Me.cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_Clear.UseVisualStyleBackColor = False
        '
        'btn_browse
        '
        Me.btn_browse.BackColor = System.Drawing.Color.Gainsboro
        Me.btn_browse.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_browse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_browse.Location = New System.Drawing.Point(17, 291)
        Me.btn_browse.Name = "btn_browse"
        Me.btn_browse.Size = New System.Drawing.Size(155, 56)
        Me.btn_browse.TabIndex = 665
        Me.btn_browse.Text = "Browse"
        Me.btn_browse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_browse.UseVisualStyleBackColor = False
        '
        'btn_authorize
        '
        Me.btn_authorize.BackColor = System.Drawing.Color.Gainsboro
        Me.btn_authorize.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_authorize.Location = New System.Drawing.Point(17, 353)
        Me.btn_authorize.Name = "btn_authorize"
        Me.btn_authorize.Size = New System.Drawing.Size(155, 61)
        Me.btn_authorize.TabIndex = 666
        Me.btn_authorize.Text = "AUTHORIZE"
        Me.btn_authorize.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_authorize.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(649, 473)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 54)
        Me.Button1.TabIndex = 667
        Me.Button1.Text = "EXPORT"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'cmdreport
        '
        Me.cmdreport.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.Image = CType(resources.GetObject("cmdreport.Image"), System.Drawing.Image)
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(17, 420)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(155, 60)
        Me.cmdreport.TabIndex = 668
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdreport.UseVisualStyleBackColor = False
        '
        'cmd_View
        '
        Me.cmd_View.BackColor = System.Drawing.Color.Gainsboro
        Me.cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_View.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_View.Image = CType(resources.GetObject("cmd_View.Image"), System.Drawing.Image)
        Me.cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_View.Location = New System.Drawing.Point(17, 230)
        Me.cmd_View.Name = "cmd_View"
        Me.cmd_View.Size = New System.Drawing.Size(155, 55)
        Me.cmd_View.TabIndex = 673
        Me.cmd_View.Text = "View [F9]"
        Me.cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_View.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(-23, -46)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 100)
        Me.GroupBox2.TabIndex = 674
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "GroupBox2"
        Me.GroupBox2.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmd_Clear)
        Me.GroupBox3.Controls.Add(Me.cmd_add)
        Me.GroupBox3.Controls.Add(Me.cmdreport)
        Me.GroupBox3.Controls.Add(Me.cmd_Exit)
        Me.GroupBox3.Controls.Add(Me.cmd_View)
        Me.GroupBox3.Controls.Add(Me.cmd_Freeze)
        Me.GroupBox3.Controls.Add(Me.btn_authorize)
        Me.GroupBox3.Controls.Add(Me.btn_browse)
        Me.GroupBox3.Location = New System.Drawing.Point(1078, 87)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(178, 558)
        Me.GroupBox3.TabIndex = 675
        Me.GroupBox3.TabStop = False
        '
        'PTY_PURPOSEMASTER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1279, 726)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Grp_Print)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_Caption)
        Me.Controls.Add(Me.lbl_freeze)
        Me.Controls.Add(Me.grp_StatusConversion4)
        Me.Controls.Add(Me.cmd_View2)
        Me.Controls.Add(Me.CMD_PRINT)
        Me.Controls.Add(Me.CMD_DOS)
        Me.DoubleBuffered = True
        Me.KeyPreview = True
        Me.Name = "PTY_PURPOSEMASTER"
        Me.Text = "PURPOSE MASTER"
        Me.grp_StatusConversion4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Grp_Print.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub PTY_GROUPMASTER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImageLayout = ImageLayout.Stretch
        rs.FindAllControls(Me)
        Me.resizeFormResolution()
        rs.ResizeAllControls(Me)
        'Call Resize_Form()
        '  GCONNECTION.FocusSetting(Me)
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Txt_Fromtime.ShowUpDown = True
        Txt_totime.ShowUpDown = True
        Call cmd_Clear_Click(sender, e)
        Show()
        txt_PCode.Focus()
    End Sub
    Public Sub resizeFormResolution()
        Dim T, U As Integer
        Me.ResizeRedraw = True

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        If U = 800 Then
            T = T - 20
        End If
        If U = 1280 Then
            T = T - 20
        End If
        If U = 1360 Then
            T = T - 55
        End If
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
    Private Sub checkvalidate() '
        Dim HRS As Integer
        Dim FROMTIME, TOTIME
        boolchk = False
        If Trim(txt_PCode.Text) = "" Then
            MessageBox.Show("Session Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_PCode.Focus()
            Exit Sub
        End If
        If Trim(Txt_PDesc.Text) = "" Then
            MessageBox.Show("Session Description Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_PDesc.Focus()
            Exit Sub
        End If
        If Trim(Txt_Fromtime.Text) = "" Then
            MessageBox.Show("From Time Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_Fromtime.Focus()
            Exit Sub
        End If
        If Trim(Txt_totime.Text) = "" Then
            MessageBox.Show("To Time Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_totime.Focus()
            Exit Sub
        End If
        If (Txt_Fromtime.Text) >= (Txt_totime.Text) Then
            MessageBox.Show("From Time Can't be Greater Than To Time", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_Fromtime.Focus()
            Exit Sub
        End If
        'If (Txt_Fromtime.Text) >= (Txt_totime.Text) Then
        '    MessageBox.Show("From Time Can't be Greater Than To Time", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Txt_Fromtime.Focus()
        '    Exit Sub
        'End If
        FROMTIME = Txt_Fromtime.Text
        TOTIME = Txt_totime.Text

        HRS = DateDiff(DateInterval.Hour, FROMTIME, TOTIME)

        If (HRS) < 1 Then
            MessageBox.Show("SESSION CAN'T MINIMUM A HOUR ", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        End If
        boolchk = True

        If gUserCategory <> "S" Then
            Call GetRights()
        End If
    End Sub



    Private Sub txt_Pcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_PCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_PCode.Text) <> "" Then
                Call txt_Pcode_Validated(txt_PCode, e)
            Else
                Call CMD_Pcode_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txt_Pcode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_PCode.Validated
        If Trim(txt_PCode.Text) <> "" Then
            sqlstring = "SELECT ISNULL(PCODE,'')AS PCODE,ISNULL(PDESC,'')AS PDESC,isnull(FROMTIME,'')AS FROMTIME,ISNULL(TOTIME,'')AS TOTIME,isNull(freeze,'')as freeze,isnull(voiduser,'')as voiduser,isnull(voiddatetime,'')as voiddatetime FROM PARTY_PURPOSEMASTER"
            sqlstring = sqlstring & " WHERE ISNULL(PCODE,'')='" & Trim(txt_PCode.Text) & "'"
            gconn.getDataSet(sqlstring, "GRP")
            If gdataset.Tables("GRP").Rows.Count > 0 Then
                cmd_add.Text = "Update[F7]"
                txt_PCode.Text = gdataset.Tables("GRP").Rows(0).Item("PCODE")
                Txt_PDesc.Text = gdataset.Tables("GRP").Rows(0).Item("PDESC")
                Txt_Fromtime.Text = Format(CDate(gdataset.Tables("GRP").Rows(0).Item("FROMTIME")), " HH:mm")
                Txt_totime.Text = Format(CDate(gdataset.Tables("GRP").Rows(0).Item("TOTIME")), " HH:mm")

                'Txt_Fromtime.Text = gdataset.Tables("GRP").Rows(0).Item("FROMTIME")
                'Txt_totime.Text = gdataset.Tables("GRP").Rows(0).Item("TOTIME")
                If gdataset.Tables("GRP").Rows(0).Item("FREEZE") = "Y" Then
                    lbl_freeze.Visible = True
                    Me.lbl_freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("GRP").Rows(0).Item("voiddatetime")), "dd-MMM-yyyy") & "  " & gdataset.Tables("grp").Rows(0).Item("voiduser")
                    cmd_Freeze.Text = "Unfreeze[F8]"
                Else
                    lbl_freeze.Visible = False
                End If
                ' cmd_add.Enabled = False
                txt_PCode.Enabled = False
                CMD_Pcode1.Enabled = False
                Txt_PDesc.Focus()
            Else
                'MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                txt_PCode.Enabled = True
                CMD_Pcode.Enabled = True
                Txt_PDesc.Focus()
            End If
        End If
    End Sub



    'Private Sub cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_View2.Click
    'Dim FrReport As New ReportDesigner
    'tables = " FROM PARTY_PURPOSEMASTER"
    'Gheader = "PURPOSE MASTER"
    'FrReport.SsGridReport.SetText(2, 1, "PCODE")
    'FrReport.SsGridReport.SetText(3, 1, 10)
    'FrReport.SsGridReport.SetText(2, 2, "PDESC")
    'FrReport.SsGridReport.SetText(3, 2, 25)
    'FrReport.SsGridReport.SetText(2, 3, "FREEZE")
    'FrReport.SsGridReport.SetText(3, 3, 6)
    'FrReport.Show()


    ' End Sub
    Private Sub Txt_PDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_PDesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_PDesc.Text) <> "" Then
                Txt_Fromtime.Focus()
            Else
                Txt_PDesc.Focus()
            End If
        End If
    End Sub
    '' ''Private Sub Txt_Fromtime_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Fromtime.KeyPress
    '' ''    getNumeric(e)
    '' ''    If Asc(e.KeyChar) = 13 Then
    '' ''        If Trim(Txt_Fromtime.Text) <> "" Then
    '' ''            Txt_totime.Focus()
    '' ''        Else
    '' ''            Txt_Fromtime.Focus()
    '' ''        End If
    '' ''    End If
    '' ''End Sub
    '' ''Private Sub Txt_totime_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_totime.KeyPress
    '' ''    getNumeric(e)
    '' ''    If Asc(e.KeyChar) = 13 Then
    '' ''        If Trim(Txt_totime.Text) <> "" Then
    '' ''            cmd_Add1.Focus()
    '' ''        Else
    '' ''            Txt_totime.Focus()
    '' ''        End If
    '' ''    End If
    '' ''End Sub

    Private Sub PTY_PURPOSEMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call cmd_Clear_Click(sender, e)
        ElseIf e.KeyCode = Keys.F7 Then
            Call cmd_add_Click(sender, e)
        ElseIf e.KeyCode = Keys.F8 Then
            Call cmd_freeze_Click(sender, e)
        ElseIf e.KeyCode = Keys.F9 Then
            Call cmd_View_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            Call cmd_Exit_Click(sender, e)
        ElseIf e.KeyCode = Keys.F10 Then
            Call cmdexport_Click(sender, e)
        End If
    End Sub
    Private Sub CMD_WINDOWS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_WINDOWS.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_MAS_PURPOSEHISTORY
        STR = "SELECT * FROM VIEW_PARTY_PURPOSEHISTORY"
        Viewer.ssql = STR
        gconn.getDataSet(STR, "session")
        If gdataset.Tables("session").Rows.Count > 0 Then
            Viewer.Report = r
            Viewer.TableName = "VIEW_PARTY_PURPOSEHISTORY"
            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text2")
            textobj1.Text = MyCompanyName
            Dim TXTOBJ2 As TextObject
            TXTOBJ2 = r.ReportDefinition.ReportObjects("Text4")
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
        heading = "PURPOSE MASTER"
        str = "SELECT * from VIEW_PARTY_PURPOSEHISTORY"
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
            Filewrite.WriteLine("SNO PURCODE   PURPOSE  DESCRIPTION  FREEZE ADDUSER         ADDDATETIME")
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
                    SSQL = SSQL & Space(1) & Mid(Format(dr("PCODE"), ""), 1, 10) & Space(10 - Len(Mid(Format(dr("PCODE"), ""), 1, 10)))
                    SSQL = SSQL & Space(1) & Mid(Format(dr("PDESC"), ""), 1, 25) & Space(25 - Len(Mid(Format(dr("PDESC"), ""), 1, 25)))
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

    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_PRINT.Click
        gPrint = False
        Grp_Print.Visible = True
    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        gPrint = False
        Grp_Print.Visible = True
        'Dim sqlstring As String
        'Dim _export As New EXPORT
        '_export.TABLENAME = "VIEW_PARTY_PURPOSEHISTORY"
        'sqlstring = "SELECT * FROM VIEW_PARTY_PURPOSEHISTORY"
        'Call _export.export_excel(sqlstring)
        '_export.Show()
        'Exit Sub
    End Sub

    Private Sub Txt_Fromtime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Fromtime1.TextChanged

    End Sub

    Private Sub Txt_PDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_PDesc.TextChanged

    End Sub

    Private Sub Txt_Fromtime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Fromtime.ValueChanged

    End Sub

    Private Sub Txt_Fromtime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Fromtime.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Fromtime.Text) <> "" Then
                Txt_totime.Focus()
            Else
                Txt_Fromtime.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_totime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_totime.ValueChanged

    End Sub


    Private Sub Txt_totime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_totime.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_totime.Text) <> "" Then
                cmd_add.Focus()
            Else
                Txt_totime.Focus()
            End If
        End If
    End Sub

    Private Sub cmd_freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Freeze.Click
        Call checkvalidate()
        If boolchk = False Then Exit Sub
        sqlstring = "INSERT INTO PARTY_PURPOSEMASTER_log (pcode,pdesc,fromtime,totime,freeze,adduser,adddate) VALUES("
        sqlstring = sqlstring & " '" & Trim(txt_PCode.Text) & "','" & Trim(Txt_PDesc.Text) & "',"
        sqlstring = sqlstring & " '" & Trim(Txt_Fromtime.Text) & "','" & Trim(Txt_totime.Text) & "','N',"
        sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "')"
        gconn.dataOperation(6, sqlstring, "GRP")


        If Mid(cmd_Freeze.Text, 1, 1) = "F" Then
            sqlstring = "SELECT ISNULL(PCODE,'')AS PCODE,ISNULL(PDESC,'')AS PDESC FROM PARTY_PURPOSEMASTER"
            sqlstring = sqlstring & " WHERE ISNULL(PCODE,'')='" & Trim(txt_PCode.Text) & "'"
            gconn.getDataSet(sqlstring, "GRP1")
            If gdataset.Tables("GRP1").Rows.Count > 0 Then
                sqlstring = "UPDATE PARTY_PURPOSEMASTER SET FREEZE='Y',"
                sqlstring = sqlstring & " VOIDUSER='" & Trim(gUsername) & "',VOIDDATETIME='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' "
                sqlstring = sqlstring & " WHERE PCODE='" & Trim(txt_PCode.Text) & "'"
                gconn.dataOperation(3, sqlstring, "GRP")
                Call cmd_Clear_Click(sender, e)
            End If
        End If
        If Mid(cmd_Freeze.Text, 1, 1) = "U" Then
            sqlstring = "UPDATE PARTY_PURPOSEMASTER SET FREEZE='N',"
            sqlstring = sqlstring & " UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' "
            sqlstring = sqlstring & " WHERE PCODE='" & Trim(txt_PCode.Text) & "'"
            gconn.dataOperation(4, sqlstring, "GRP")
            Call cmd_Clear_Click(sender, e)
        End If
    End Sub

    Private Sub btn_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_browse.Click
        brows = True
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM party_purposemaster"
        GCONNECTION.getDataSet(STRQUERY, "authorize")

        Call VIEW1.LOADGRID(gdataset.Tables("authorize"), True, "", "SELECT * FROM party_purposemaster", "hallcode", 1, Me.txt_PCode)

    End Sub

    Private Sub btn_authorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_authorize.Click
        Dim SSQLSTR, SSQLSTR2 As String
        Dim USERT As Integer
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
        GCONNECTION.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 1
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
        GCONNECTION.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 2
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
        GCONNECTION.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 3
        End If
        If USERT = 1 Then
            SSQLSTR2 = " SELECT * FROM PARTY_PURPOSEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
            GCONNECTION.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                GCONNECTION.getDataSet(gSQLString, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                    GCONNECTION.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PARTY_PURPOSEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                        GCONNECTION.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_PURPOSEMASTER set  ", "PCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 0)
                        End If
                    Else
                        MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                    End If
                End If
            End If
        ElseIf USERT = 2 Then
            SSQLSTR2 = " SELECT * FROM PARTY_PURPOSEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')='' AND ISNULL(AUTHORISE_USER1,'')<>''"
            GCONNECTION.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                GCONNECTION.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    GCONNECTION.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PARTY_PURPOSEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''"
                        GCONNECTION.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_PURPOSEMASTER set  ", "PCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            End If
        ElseIf USERT = 3 Then
            SSQLSTR2 = " SELECT * FROM PARTY_PURPOSEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''  AND ISNULL(AUTHORISE_USER2,'')<>''"
            GCONNECTION.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                GCONNECTION.getDataSet(gSQLString, "AUTHORIZE2")
                If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    GCONNECTION.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PARTY_PURPOSEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                        GCONNECTION.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_PURPOSEMASTER set  ", "PCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                        End If
                    End If
                End If
            Else
                MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    Private Sub cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Exit.Click, cmd_Exit1.Click
        Me.Close()
    End Sub

    Private Sub cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Clear.Click
        txt_PCode.Enabled = True
        CMD_Pcode.Enabled = True
        lbl_freeze.Visible = False
        txt_PCode.Text = ""
        Txt_PDesc.Text = ""
        Txt_Fromtime.Text = "00:00"
        Txt_totime.Text = "00:00"
        cmd_add.Enabled = True
        'Format(Txt_Fromtime.Text, "HH:mm")
        'Format(Txt_totime.Text, "HH:mm")
        cmd_add.Text = "Add[F7]"
        cmd_Freeze.Text = "Freeze[F8]"
        txt_PCode.Focus()
    End Sub

    Private Sub cmd_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_add.Click
        Call checkvalidate()
        If boolchk = False Then Exit Sub
        Dim ssql As String
        Dim pcode, pdesc, fromtime, totime As String
        Dim i As Integer

        ssql = "select * from party_purposemaster"
        GCONNECTION.getDataSet(ssql, "pur")
        If gdataset.Tables("pur").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("pur").Rows.Count - 1
                pcode = gdataset.Tables("pur").Rows(i).Item("pcode")
                pdesc = gdataset.Tables("pur").Rows(i).Item("pdesc")
                fromtime = gdataset.Tables("pur").Rows(i).Item("fromtime")
                totime = gdataset.Tables("pur").Rows(i).Item("totime")

                If fromtime = Txt_Fromtime.Text Then
                    MessageBox.Show("FROM TIME ALREADY ENTERED", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If
                If totime = Txt_totime.Text Then
                    MessageBox.Show("TO TIME ALREADY ENTERED", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If
            Next
        End If


        sqlstring = "INSERT INTO PARTY_PURPOSEMASTER_log (pcode,pdesc,fromtime,totime,freeze,adduser,adddate) VALUES("
        sqlstring = sqlstring & " '" & Trim(txt_PCode.Text) & "','" & Trim(Txt_PDesc.Text) & "',"
        sqlstring = sqlstring & " '" & Trim(Txt_Fromtime.Text) & "','" & Trim(Txt_totime.Text) & "','N',"
        sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "')"
        gconn.dataOperation(6, sqlstring, "GRP")

        If Mid(cmd_add.Text, 1, 1) = "A" Then

            sqlstring = "INSERT INTO PARTY_PURPOSEMASTER (pcode,pdesc,fromtime,totime,freeze,adduser,adddate) VALUES("
            sqlstring = sqlstring & " '" & Trim(txt_PCode.Text) & "','" & Trim(Txt_PDesc.Text) & "',"
            sqlstring = sqlstring & " '" & Trim(Txt_Fromtime.Text) & "','" & Trim(Txt_totime.Text) & "','N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "')"
            gconn.dataOperation(1, sqlstring, "GRP")
            Call cmd_Clear_Click(sender, e)
        ElseIf Mid(cmd_add.Text, 1, 1) = "U" Then
            If lbl_freeze.Visible = True Then
                MsgBox("Freezed Record Cannot Be Updated", MsgBoxStyle.Information)
                Call cmd_Clear_Click(sender, e)
                Exit Sub
            End If
            sqlstring = "UPDATE PARTY_PURPOSEMASTER SET PDESC='" & Trim(Txt_PDesc.Text) & "',FREEZE='N',"
            sqlstring = sqlstring & " FROMTIME='" & Trim(Txt_Fromtime.Text) & "',TOTIME='" & Trim(Txt_totime.Text) & "',"
            sqlstring = sqlstring & " UPDATEUSER='" & Trim(gUsername) & "',updatetime='" & Format(DateTime.Now, "dd/MMM/yyyy HH:mm") & "' "
            sqlstring = sqlstring & " WHERE PCODE='" & Trim(txt_PCode.Text) & "'"
            gconn.dataOperation(2, sqlstring, "GRP")
            Call cmd_Clear_Click(sender, e)
        End If
    End Sub


    Private Sub grp_StatusConversion4_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grp_StatusConversion4.Enter

    End Sub



    Private Sub CMD_Pcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_Pcode.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT isnull(PCODE,'') as PCODE,isnull(PDESC,'') as PDESC FROM PARTY_PURPOSEMASTER"
            M_WhereCondition = " "
            vform.Field = "PCODE ,PDESC"
            '  vform.vFormatstring = "SESSION CODE    |     SESSION DESCRIPTION    "
            vform.vCaption = "Session Master Help"
            ''vform.KeyPos = 0
            ''vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_PCode.Text = Trim(vform.keyfield & "")
                txt_PCode.Select()
                Call txt_Pcode_Validated(txt_PCode, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try

    End Sub

    Private Sub CMD_Pcode1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_Pcode1.Click

    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Dim SQLSTRING, SSQL As String
        Dim VIEWER As New ReportViwer
        Dim R As New CRT_SESSIONMASTER

        SQLSTRING = "select * from PARTY_PURPOSEMASTER  order by PCODE,PDESC"

        Call VIEWER.GetDetails(SQLSTRING, "PARTY_PURPOSEMASTER", R)
        VIEWER.TableName = "PARTY_PURPOSEMASTER"

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = R.ReportDefinition.ReportObjects("Text11")
        TXTOBJ5.Text = gCompanyname

        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = R.ReportDefinition.ReportObjects("Text12")
        TXTOBJ6.Text = Address1 & Address2

        Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ8 = R.ReportDefinition.ReportObjects("Text13")
        TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ9 = R.ReportDefinition.ReportObjects("Text14")
        TXTOBJ9.Text = "PhoneNo : " & gphoneno



        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = R.ReportDefinition.ReportObjects("Text10")
        TXTOBJ1.Text = "UserName : " & gUsername

        VIEWER.Show()

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txt_PCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_PCode.TextChanged

    End Sub

    Private Sub cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_View.Click
        Dim FRM As New ReportDesigner
        If txt_PCode.Text.Length > 0 Then
            tables = " FROM party_purposemaster WHERE PCODE ='" & txt_PCode.Text & "' "
        Else
            tables = "FROM party_purposemaster "
        End If
        Gheader = "SESSION  DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"PCODE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"PDESC", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"FROMTIME", "12"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"TOTIME", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ' '' '' ''ROW = New String() {"GROUPCODE", "5"}
        ' '' '' ''FRM.DataGridView1.Rows.Add(ROW)
        ' '' '' ''ROW = New String() {"GROUPCODEDEC", "15"}
        ' '' '' ''FRM.DataGridView1.Rows.Add(ROW)
        ' '' '' ''ROW = New String() {"SUBGROUPCODE", "8"}
        ' '' '' ''FRM.DataGridView1.Rows.Add(ROW)
        ' '' '' ''ROW = New String() {"SUBGROUPDESC", "15"}
        ' '' '' ''FRM.DataGridView1.Rows.Add(ROW)
        ' '' '' ''ROW = New String() {"BASEUOMSTD", "7"}
        ' '' '' ''FRM.DataGridView1.Rows.Add(ROW)
        ' '' '' ''ROW = New String() {"BASERATESTD", "8"}
        ' '' '' ''FRM.DataGridView1.Rows.Add(ROW)
        ' '' '' ''ROW = New String() {"OPENFACILITY", "10"}
        ' '' '' ''FRM.DataGridView1.Rows.Add(ROW)
        ' '' '' ''ROW = New String() {"STORECODE", "9"}
        ' '' '' ''FRM.DataGridView1.Rows.Add(ROW)
        '' '' '' ''ROW = New String() {"MRPRATE", "10"}
        '' '' '' ''FRM.DataGridView1.Rows.Add(ROW)
        '' '' '' ''ROW = New String() {"roundval", "7"}
        '' '' '' ''FRM.DataGridView1.Rows.Add(ROW)
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

        ROW = New String() {"VOIDUSER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"VOIDDATETIME", "10"}
        FRM.DataGridView1.Rows.Add(ROW)

        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

   
    Private Sub PTY_PURPOSEMASTER_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class
