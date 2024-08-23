Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Public Class PTY_TARIFFMASTER
    Inherits System.Windows.Forms.Form
    Dim gconn As New GlobalClass
    Dim gconnection As New GlobalClass
    Dim TempString(3) As String
    Dim i, j As Integer
    Dim dr As DataRow
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim sqlstring As String
    Dim boolchk As Boolean
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
    Friend WithEvents Txt_Cdesc As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txt_CCode As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CMD_Ccode As System.Windows.Forms.Button
    Friend WithEvents Txt_tariffdesc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_Tariffcode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_tariff As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_freeze As System.Windows.Forms.Label
    Friend WithEvents cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents grp_StatusConversion4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Add As System.Windows.Forms.Button
    Friend WithEvents cmd_View As System.Windows.Forms.Button
    Friend WithEvents cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Txt_menudesc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_menucode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_menucode As System.Windows.Forms.Button
    Friend WithEvents Txt_Maxitems As System.Windows.Forms.TextBox
    Friend WithEvents Txt_rate As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_taxcode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Taxcode As System.Windows.Forms.Button
    Friend WithEvents Grp_Print As System.Windows.Forms.GroupBox
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMD_WINDOWS As System.Windows.Forms.Button
    Friend WithEvents CMD_DOS As System.Windows.Forms.Button
    Friend WithEvents CMD_PRINT As System.Windows.Forms.Button
    Friend WithEvents SSGRID As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents OptNo As System.Windows.Forms.RadioButton
    Friend WithEvents optYes As System.Windows.Forms.RadioButton
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents cmb_category As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents LST_TAX As System.Windows.Forms.CheckedListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PTY_TARIFFMASTER))
        Me.Txt_Cdesc = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_CCode = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CMD_Ccode = New System.Windows.Forms.Button
        Me.Txt_tariffdesc = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_Tariffcode = New System.Windows.Forms.TextBox
        Me.Cmd_tariff = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_rate = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmb_category = New System.Windows.Forms.ComboBox
        Me.Cmd_Taxcode = New System.Windows.Forms.Button
        Me.txt_taxcode = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Txt_Maxitems = New System.Windows.Forms.TextBox
        Me.Txt_menudesc = New System.Windows.Forms.TextBox
        Me.Txt_menucode = New System.Windows.Forms.TextBox
        Me.Cmd_menucode = New System.Windows.Forms.Button
        Me.lbl_freeze = New System.Windows.Forms.Label
        Me.cmd_Exit = New System.Windows.Forms.Button
        Me.cmd_Freeze = New System.Windows.Forms.Button
        Me.grp_StatusConversion4 = New System.Windows.Forms.GroupBox
        Me.cmd_Add = New System.Windows.Forms.Button
        Me.cmd_View = New System.Windows.Forms.Button
        Me.cmd_Clear = New System.Windows.Forms.Button
        Me.CMD_PRINT = New System.Windows.Forms.Button
        Me.cmdexport = New System.Windows.Forms.Button
        Me.Grp_Print = New System.Windows.Forms.GroupBox
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMD_WINDOWS = New System.Windows.Forms.Button
        Me.CMD_DOS = New System.Windows.Forms.Button
        Me.SSGRID = New AxFPSpreadADO.AxfpSpread
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.OptNo = New System.Windows.Forms.RadioButton
        Me.optYes = New System.Windows.Forms.RadioButton
        Me.Label17 = New System.Windows.Forms.Label
        Me.LST_TAX = New System.Windows.Forms.CheckedListBox
        Me.GroupBox2.SuspendLayout()
        Me.grp_StatusConversion4.SuspendLayout()
        Me.Grp_Print.SuspendLayout()
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Txt_Cdesc
        '
        Me.Txt_Cdesc.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_Cdesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Cdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Cdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Cdesc.Location = New System.Drawing.Point(776, 408)
        Me.Txt_Cdesc.MaxLength = 50
        Me.Txt_Cdesc.Name = "Txt_Cdesc"
        Me.Txt_Cdesc.Size = New System.Drawing.Size(48, 21)
        Me.Txt_Cdesc.TabIndex = 424
        Me.Txt_Cdesc.Text = ""
        Me.Txt_Cdesc.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(648, 376)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(115, 21)
        Me.Label14.TabIndex = 426
        Me.Label14.Text = "Category Code"
        Me.Label14.Visible = False
        '
        'txt_CCode
        '
        Me.txt_CCode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txt_CCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_CCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_CCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CCode.Location = New System.Drawing.Point(768, 376)
        Me.txt_CCode.MaxLength = 10
        Me.txt_CCode.Name = "txt_CCode"
        Me.txt_CCode.Size = New System.Drawing.Size(40, 21)
        Me.txt_CCode.TabIndex = 423
        Me.txt_CCode.Text = ""
        Me.txt_CCode.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(640, 424)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(162, 21)
        Me.Label10.TabIndex = 427
        Me.Label10.Text = "Category Description"
        Me.Label10.Visible = False
        '
        'CMD_Ccode
        '
        Me.CMD_Ccode.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CMD_Ccode.Image = CType(resources.GetObject("CMD_Ccode.Image"), System.Drawing.Image)
        Me.CMD_Ccode.Location = New System.Drawing.Point(808, 376)
        Me.CMD_Ccode.Name = "CMD_Ccode"
        Me.CMD_Ccode.Size = New System.Drawing.Size(24, 24)
        Me.CMD_Ccode.TabIndex = 428
        Me.CMD_Ccode.Visible = False
        '
        'Txt_tariffdesc
        '
        Me.Txt_tariffdesc.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_tariffdesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_tariffdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_tariffdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_tariffdesc.Location = New System.Drawing.Point(248, 48)
        Me.Txt_tariffdesc.MaxLength = 30
        Me.Txt_tariffdesc.Name = "Txt_tariffdesc"
        Me.Txt_tariffdesc.Size = New System.Drawing.Size(216, 21)
        Me.Txt_tariffdesc.TabIndex = 433
        Me.Txt_tariffdesc.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 21)
        Me.Label1.TabIndex = 434
        Me.Label1.Text = "Menu  Code"
        '
        'Txt_Tariffcode
        '
        Me.Txt_Tariffcode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_Tariffcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Tariffcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Tariffcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Tariffcode.Location = New System.Drawing.Point(248, 16)
        Me.Txt_Tariffcode.MaxLength = 6
        Me.Txt_Tariffcode.Name = "Txt_Tariffcode"
        Me.Txt_Tariffcode.Size = New System.Drawing.Size(72, 21)
        Me.Txt_Tariffcode.TabIndex = 1
        Me.Txt_Tariffcode.Text = ""
        '
        'Cmd_tariff
        '
        Me.Cmd_tariff.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Cmd_tariff.Image = CType(resources.GetObject("Cmd_tariff.Image"), System.Drawing.Image)
        Me.Cmd_tariff.Location = New System.Drawing.Point(320, 16)
        Me.Cmd_tariff.Name = "Cmd_tariff"
        Me.Cmd_tariff.Size = New System.Drawing.Size(24, 24)
        Me.Cmd_tariff.TabIndex = 436
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Txt_rate)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Txt_Tariffcode)
        Me.GroupBox2.Controls.Add(Me.Cmd_tariff)
        Me.GroupBox2.Controls.Add(Me.Txt_tariffdesc)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(128, 208)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(568, 128)
        Me.GroupBox2.TabIndex = 437
        Me.GroupBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(96, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 21)
        Me.Label3.TabIndex = 449
        Me.Label3.Text = "Menu Description"
        '
        'Txt_rate
        '
        Me.Txt_rate.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_rate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_rate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_rate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_rate.Location = New System.Drawing.Point(248, 88)
        Me.Txt_rate.MaxLength = 6
        Me.Txt_rate.Name = "Txt_rate"
        Me.Txt_rate.Size = New System.Drawing.Size(72, 21)
        Me.Txt_rate.TabIndex = 444
        Me.Txt_rate.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(96, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 21)
        Me.Label6.TabIndex = 445
        Me.Label6.Text = "Menu  Rate"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(120, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 21)
        Me.Label4.TabIndex = 451
        Me.Label4.Text = "Tariff Type"
        Me.Label4.Visible = False
        '
        'cmb_category
        '
        Me.cmb_category.Items.AddRange(New Object() {"VEG", "NON VEG"})
        Me.cmb_category.Location = New System.Drawing.Point(208, 8)
        Me.cmb_category.Name = "cmb_category"
        Me.cmb_category.Size = New System.Drawing.Size(121, 21)
        Me.cmb_category.TabIndex = 450
        Me.cmb_category.Visible = False
        '
        'Cmd_Taxcode
        '
        Me.Cmd_Taxcode.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Cmd_Taxcode.Image = CType(resources.GetObject("Cmd_Taxcode.Image"), System.Drawing.Image)
        Me.Cmd_Taxcode.Location = New System.Drawing.Point(832, 8)
        Me.Cmd_Taxcode.Name = "Cmd_Taxcode"
        Me.Cmd_Taxcode.Size = New System.Drawing.Size(24, 24)
        Me.Cmd_Taxcode.TabIndex = 448
        Me.Cmd_Taxcode.Visible = False
        '
        'txt_taxcode
        '
        Me.txt_taxcode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txt_taxcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_taxcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_taxcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_taxcode.Location = New System.Drawing.Point(736, 8)
        Me.txt_taxcode.MaxLength = 50
        Me.txt_taxcode.Name = "txt_taxcode"
        Me.txt_taxcode.Size = New System.Drawing.Size(96, 21)
        Me.txt_taxcode.TabIndex = 446
        Me.txt_taxcode.Text = ""
        Me.txt_taxcode.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(568, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 21)
        Me.Label7.TabIndex = 447
        Me.Label7.Text = "Tax Code"
        Me.Label7.Visible = False
        '
        'Txt_Maxitems
        '
        Me.Txt_Maxitems.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_Maxitems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Maxitems.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Maxitems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Maxitems.Location = New System.Drawing.Point(80, 8)
        Me.Txt_Maxitems.MaxLength = 50
        Me.Txt_Maxitems.Name = "Txt_Maxitems"
        Me.Txt_Maxitems.Size = New System.Drawing.Size(24, 21)
        Me.Txt_Maxitems.TabIndex = 442
        Me.Txt_Maxitems.Text = ""
        Me.Txt_Maxitems.Visible = False
        '
        'Txt_menudesc
        '
        Me.Txt_menudesc.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_menudesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_menudesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_menudesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_menudesc.Location = New System.Drawing.Point(56, 8)
        Me.Txt_menudesc.MaxLength = 50
        Me.Txt_menudesc.Name = "Txt_menudesc"
        Me.Txt_menudesc.Size = New System.Drawing.Size(24, 21)
        Me.Txt_menudesc.TabIndex = 438
        Me.Txt_menudesc.Text = ""
        Me.Txt_menudesc.Visible = False
        '
        'Txt_menucode
        '
        Me.Txt_menucode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_menucode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_menucode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_menucode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_menucode.Location = New System.Drawing.Point(8, 8)
        Me.Txt_menucode.MaxLength = 10
        Me.Txt_menucode.Name = "Txt_menucode"
        Me.Txt_menucode.Size = New System.Drawing.Size(24, 21)
        Me.Txt_menucode.TabIndex = 437
        Me.Txt_menucode.Text = ""
        Me.Txt_menucode.Visible = False
        '
        'Cmd_menucode
        '
        Me.Cmd_menucode.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Cmd_menucode.Image = CType(resources.GetObject("Cmd_menucode.Image"), System.Drawing.Image)
        Me.Cmd_menucode.Location = New System.Drawing.Point(32, 8)
        Me.Cmd_menucode.Name = "Cmd_menucode"
        Me.Cmd_menucode.Size = New System.Drawing.Size(24, 24)
        Me.Cmd_menucode.TabIndex = 441
        Me.Cmd_menucode.Visible = False
        '
        'lbl_freeze
        '
        Me.lbl_freeze.AutoSize = True
        Me.lbl_freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_freeze.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.lbl_freeze.Location = New System.Drawing.Point(360, 416)
        Me.lbl_freeze.Name = "lbl_freeze"
        Me.lbl_freeze.Size = New System.Drawing.Size(160, 26)
        Me.lbl_freeze.TabIndex = 441
        Me.lbl_freeze.Text = "Record Freezed"
        Me.lbl_freeze.Visible = False
        '
        'cmd_Exit
        '
        Me.cmd_Exit.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Exit.BackgroundImage = CType(resources.GetObject("cmd_Exit.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.cmd_Exit.Location = New System.Drawing.Point(600, 16)
        Me.cmd_Exit.Name = "cmd_Exit"
        Me.cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Exit.TabIndex = 439
        Me.cmd_Exit.Text = "Exit[F11]"
        '
        'cmd_Freeze
        '
        Me.cmd_Freeze.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Freeze.BackgroundImage = CType(resources.GetObject("cmd_Freeze.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.cmd_Freeze.Location = New System.Drawing.Point(320, 16)
        Me.cmd_Freeze.Name = "cmd_Freeze"
        Me.cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Freeze.TabIndex = 438
        Me.cmd_Freeze.Text = "Freeze[F8]"
        '
        'grp_StatusConversion4
        '
        Me.grp_StatusConversion4.BackColor = System.Drawing.Color.Transparent
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Add)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_View)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Clear)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Exit)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Freeze)
        Me.grp_StatusConversion4.Location = New System.Drawing.Point(48, 448)
        Me.grp_StatusConversion4.Name = "grp_StatusConversion4"
        Me.grp_StatusConversion4.Size = New System.Drawing.Size(728, 64)
        Me.grp_StatusConversion4.TabIndex = 440
        Me.grp_StatusConversion4.TabStop = False
        '
        'cmd_Add
        '
        Me.cmd_Add.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Add.BackgroundImage = CType(resources.GetObject("cmd_Add.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Add.ForeColor = System.Drawing.Color.White
        Me.cmd_Add.Location = New System.Drawing.Point(176, 16)
        Me.cmd_Add.Name = "cmd_Add"
        Me.cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Add.TabIndex = 378
        Me.cmd_Add.Text = "Add[F7]"
        '
        'cmd_View
        '
        Me.cmd_View.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_View.BackgroundImage = CType(resources.GetObject("cmd_View.BackgroundImage"), System.Drawing.Image)
        Me.cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_View.ForeColor = System.Drawing.Color.White
        Me.cmd_View.Location = New System.Drawing.Point(472, 16)
        Me.cmd_View.Name = "cmd_View"
        Me.cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.cmd_View.TabIndex = 379
        Me.cmd_View.Text = "View [F9]"
        '
        'cmd_Clear
        '
        Me.cmd_Clear.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Clear.BackgroundImage = CType(resources.GetObject("cmd_Clear.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Clear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Clear.ForeColor = System.Drawing.Color.White
        Me.cmd_Clear.Location = New System.Drawing.Point(32, 16)
        Me.cmd_Clear.Name = "cmd_Clear"
        Me.cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Clear.TabIndex = 381
        Me.cmd_Clear.Text = "Clear[F6]"
        '
        'CMD_PRINT
        '
        Me.CMD_PRINT.BackColor = System.Drawing.SystemColors.Menu
        Me.CMD_PRINT.BackgroundImage = CType(resources.GetObject("CMD_PRINT.BackgroundImage"), System.Drawing.Image)
        Me.CMD_PRINT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMD_PRINT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_PRINT.ForeColor = System.Drawing.Color.White
        Me.CMD_PRINT.Location = New System.Drawing.Point(920, 456)
        Me.CMD_PRINT.Name = "CMD_PRINT"
        Me.CMD_PRINT.Size = New System.Drawing.Size(32, 32)
        Me.CMD_PRINT.TabIndex = 382
        Me.CMD_PRINT.Text = "Print [F10]"
        Me.CMD_PRINT.Visible = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdexport.BackgroundImage = CType(resources.GetObject("cmdexport.BackgroundImage"), System.Drawing.Image)
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Location = New System.Drawing.Point(864, 464)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(40, 32)
        Me.cmdexport.TabIndex = 435
        Me.cmdexport.Text = "Report[F12]"
        Me.cmdexport.Visible = False
        '
        'Grp_Print
        '
        Me.Grp_Print.BackColor = System.Drawing.Color.Transparent
        Me.Grp_Print.Controls.Add(Me.CMDEXIT)
        Me.Grp_Print.Controls.Add(Me.CMD_WINDOWS)
        Me.Grp_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Print.Location = New System.Drawing.Point(240, 352)
        Me.Grp_Print.Name = "Grp_Print"
        Me.Grp_Print.Size = New System.Drawing.Size(368, 56)
        Me.Grp_Print.TabIndex = 664
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
        '
        'CMD_DOS
        '
        Me.CMD_DOS.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.CMD_DOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_DOS.Location = New System.Drawing.Point(128, 248)
        Me.CMD_DOS.Name = "CMD_DOS"
        Me.CMD_DOS.Size = New System.Drawing.Size(96, 32)
        Me.CMD_DOS.TabIndex = 0
        Me.CMD_DOS.Text = "DOS"
        Me.CMD_DOS.Visible = False
        '
        'SSGRID
        '
        Me.SSGRID.DataSource = Nothing
        Me.SSGRID.Location = New System.Drawing.Point(80, 296)
        Me.SSGRID.Name = "SSGRID"
        Me.SSGRID.OcxState = CType(resources.GetObject("SSGRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID.Size = New System.Drawing.Size(96, 88)
        Me.SSGRID.TabIndex = 665
        Me.SSGRID.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 20.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(336, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 34)
        Me.Label2.TabIndex = 666
        Me.Label2.Text = "Menu Master"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.OptNo)
        Me.GroupBox3.Controls.Add(Me.optYes)
        Me.GroupBox3.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(8, 231)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(32, 209)
        Me.GroupBox3.TabIndex = 667
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "SBF APPLICABLE"
        Me.GroupBox3.Visible = False
        '
        'OptNo
        '
        Me.OptNo.BackColor = System.Drawing.Color.Transparent
        Me.OptNo.Checked = True
        Me.OptNo.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OptNo.ForeColor = System.Drawing.Color.Black
        Me.OptNo.Location = New System.Drawing.Point(128, 32)
        Me.OptNo.Name = "OptNo"
        Me.OptNo.Size = New System.Drawing.Size(56, 16)
        Me.OptNo.TabIndex = 1
        Me.OptNo.TabStop = True
        Me.OptNo.Text = "NO"
        '
        'optYes
        '
        Me.optYes.BackColor = System.Drawing.Color.Transparent
        Me.optYes.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optYes.ForeColor = System.Drawing.Color.Black
        Me.optYes.Location = New System.Drawing.Point(32, 32)
        Me.optYes.Name = "optYes"
        Me.optYes.Size = New System.Drawing.Size(64, 16)
        Me.optYes.TabIndex = 0
        Me.optYes.Text = "YES"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Courier New", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(776, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(136, 23)
        Me.Label17.TabIndex = 668
        Me.Label17.Text = "TAX APPLIES"
        Me.Label17.Visible = False
        '
        'LST_TAX
        '
        Me.LST_TAX.Location = New System.Drawing.Point(776, 88)
        Me.LST_TAX.Name = "LST_TAX"
        Me.LST_TAX.Size = New System.Drawing.Size(200, 229)
        Me.LST_TAX.TabIndex = 669
        Me.LST_TAX.Visible = False
        '
        'PTY_TARIFFMASTER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(984, 518)
        Me.Controls.Add(Me.LST_TAX)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_freeze)
        Me.Controls.Add(Me.Txt_menudesc)
        Me.Controls.Add(Me.Txt_Maxitems)
        Me.Controls.Add(Me.Txt_menucode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txt_taxcode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txt_CCode)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Txt_Cdesc)
        Me.Controls.Add(Me.SSGRID)
        Me.Controls.Add(Me.Grp_Print)
        Me.Controls.Add(Me.grp_StatusConversion4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Cmd_menucode)
        Me.Controls.Add(Me.cmdexport)
        Me.Controls.Add(Me.CMD_PRINT)
        Me.Controls.Add(Me.Cmd_Taxcode)
        Me.Controls.Add(Me.cmb_category)
        Me.Controls.Add(Me.CMD_Ccode)
        Me.Controls.Add(Me.CMD_DOS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "PTY_TARIFFMASTER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TARIFF MASTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.grp_StatusConversion4.ResumeLayout(False)
        Me.Grp_Print.ResumeLayout(False)
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub checkvalidate()
        boolchk = False
        If Trim(Txt_rate.Text) = "" Then
            MessageBox.Show("RATE Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_rate.Focus()
            Exit Sub
        End If
        'If Trim(Txt_Cdesc.Text) = "" Then
        '    MessageBox.Show("Category Description Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Txt_Cdesc.Focus()
        '    Exit Sub
        'End If
        If Trim(Txt_Tariffcode.Text) = "" Then
            MessageBox.Show("Tariff Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_Tariffcode.Focus()
            Exit Sub
        End If
        If Trim(Txt_tariffdesc.Text) = "" Then
            MessageBox.Show("Tariff Desc Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_tariffdesc.Focus()
            Exit Sub
        End If
        'If Trim(Txt_menucode.Text) = "" Then
        '    MessageBox.Show("Menu Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Txt_menucode.Focus()
        '    Exit Sub
        'End If
        'If Trim(Txt_menudesc.Text) = "" Then
        '    MessageBox.Show("Menu Desc Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Txt_menudesc.Focus()
        '    Exit Sub
        'End If
        'If Trim(Txt_Maxitems.Text) = "" Then
        '    MessageBox.Show("Items Permitted Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Txt_Maxitems.Focus()
        '    Exit Sub
        'End If
        'With SSGRID
        '    If .DataRowCnt = 0 Then
        '        MessageBox.Show("Menus Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '        SSGRID.SetActiveCell(1, 1)
        '        SSGRID.Focus()
        '        Exit Sub
        '    End If
        'End With

        boolchk = True
    End Sub
    Private Sub Cmd_menucode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_menucode.Click
       
    End Sub
    Private Sub Cmd_tariff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_tariff.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT  DISTINCT isnull(TARIFFDESC,'') as TARIFFDESC,isnull(TARIFFCODE,'') as TARIFFCODE,ISNULL(RATE,0) AS RATE,ISNULL(SBFCHARGE,'') AS SBFCHARGE FROM PARTY_VIEW_TARIFFMASTER "
        M_WhereCondition = " "
        vform.Field = "TARIFFDESC,TARIFFCODE,RATE,SBFCHARGE"
        vform.vFormatstring = "             Tariff Description            |   Tariff Code    |    CATEGORY    | CATEGORY CODE| RATE| SBF CHARGE"
        vform.vCaption = "Tariff Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_Tariffcode.Text = Trim(vform.keyfield1 & "")
            Txt_tariffdesc.Text = Trim(vform.keyfield)
            txt_CCode.Text = Trim(vform.keyfield2)
            Txt_Cdesc.Text = Trim(vform.keyfield3)
            Call Txt_Tariffcode_Validated(Txt_Tariffcode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub CMD_Ccode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_Ccode.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT isnull(CDESC,'') as CDESC,isnull(CCODE,'') as CCODE FROM PARTY_CATEGORYMASTER"
        M_WhereCondition = " "
        vform.Field = "CDESC,CCODE"
        vform.vFormatstring = "        category Description    |     category Code    "
        vform.vCaption = "Category Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_CCode.Text = Trim(vform.keyfield1 & "")
            Txt_Cdesc.Text = Trim(vform.keyfield)
            Txt_Cdesc.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub Txt_Cdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Cdesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SSGRID.SetActiveCell(1, 1)
            SSGRID.Focus()
        End If
    End Sub
    Private Sub Txt_tariffdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_tariffdesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_rate.Focus()
        End If
    End Sub
    Private Sub Txt_menudesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_menudesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_Maxitems.Focus()
        End If
    End Sub
    Private Sub txt_CCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_CCode.Validated
        If Trim(txt_CCode.Text) <> "" Then
            sqlstring = "SELECT * FROM PARTY_CATEGORYMASTER WHERE CCODE='" & Trim(txt_CCode.Text) & "'"
            gconn.getDataSet(sqlstring, "CATE")
            If gdataset.Tables("CATE").Rows.Count > 0 Then
                txt_CCode.Text = gdataset.Tables("CATE").Rows(0).Item("CCODE")
                Txt_Cdesc.Text = gdataset.Tables("CATE").Rows(0).Item("CDESC")
                Txt_Cdesc.Focus()
            Else
                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                txt_CCode.Text = ""
                txt_CCode.Focus()
            End If
        End If
    End Sub
    Private Sub txt_CCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_CCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_CCode.Text) <> "" Then
                Call txt_CCode_Validated(txt_CCode, e)
            Else
                Call CMD_Ccode_Click(sender, e)
            End If
            cmb_category.Focus()
        End If
    End Sub
    Private Sub Txt_menucode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_menucode.Validated
        If Trim(Txt_menucode.Text) <> "" Then
            sqlstring = "SELECT * FROM PARTY_MENU_MASTER WHERE MENUCODE='" & Trim(Txt_menucode.Text) & "'"
            gconn.getDataSet(sqlstring, "MENU")
            If gdataset.Tables("MENU").Rows.Count > 0 Then
                Txt_menucode.Text = gdataset.Tables("MENU").Rows(0).Item("MENUCODE")
                Txt_menudesc.Text = gdataset.Tables("MENU").Rows(0).Item("MENUDESC")
                Txt_menudesc.Focus()
            Else
                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                Txt_menucode.Text = ""
                Txt_menucode.Focus()
            End If
        End If
    End Sub
    Private Sub Txt_menucode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_menucode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_menucode.Text) <> "" Then
                Call Txt_menucode_Validated(Txt_menucode, e)
            Else
                Call Cmd_menucode_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub Txt_Maxitems_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Maxitems.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmd_Add.Focus()
        End If
    End Sub
    Private Sub Txt_Tariffcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Tariffcode.Validated
        Dim i As Integer
        If Trim(Txt_Tariffcode.Text) <> "" Then
            sqlstring = "SELECT * FROM PARTY_VIEW_TARIFFMASTER WHERE TARIFFCODE='" & Trim(Txt_Tariffcode.Text) & "' "
            'sqlstring = sqlstring & " AND CCODE='" & Trim(txt_CCode.Text) & "'"
            gconn.getDataSet(sqlstring, "TAR")
            If gdataset.Tables("TAR").Rows.Count > 0 Then
                cmd_Add.Text = "Update[F7]"
                Txt_Tariffcode.Enabled = False
                Cmd_tariff.Enabled = False
                For i = 0 To gdataset.Tables("TAR").Rows.Count - 1
                    Txt_tariffdesc.Text = gdataset.Tables("TAR").Rows(i).Item("TARIFFDESC")
                    'txt_CCode.Text = gdataset.Tables("TAR").Rows(0).Item("CCODE")
                    'Txt_Cdesc.Text = gdataset.Tables("TAR").Rows(0).Item("CDESC")
                    Txt_rate.Text = gdataset.Tables("TAR").Rows(i).Item("RATE")
                    'cmb_category.Text = gdataset.Tables("TAR").Rows(0).Item("CATEGORY")
                    If gdataset.Tables("TAR").Rows(i).Item("sbfcharge") = "Y" Then
                        optYes.Checked = True
                        OptNo.Checked = False
                    Else
                        optYes.Checked = False
                        OptNo.Checked = True
                    End If

                    txt_taxcode.Text = gdataset.Tables("TAR").Rows(i).Item("TAXCODE")
                    With SSGRID
                        .Col = 1
                        .Row = i + 1
                        .Text = gdataset.Tables("TAR").Rows(i).Item("MENUCODE")
                        .Col = 2
                        .Row = i + 1
                        .Text = gdataset.Tables("TAR").Rows(i).Item("MENUDESC")
                        .Col = 3
                        .Row = i + 1
                        .Text = gdataset.Tables("TAR").Rows(i).Item("MAXITEMS")
                    End With
                    If gdataset.Tables("TAR").Rows(i).Item("FREEZE") = "Y" Then
                        lbl_freeze.Visible = True
                        txt_CCode.Enabled = False
                        CMD_Ccode.Enabled = False
                        Txt_Tariffcode.Enabled = False
                        Cmd_tariff.Enabled = False
                        cmd_Freeze.Text = "UnFreeze[F8]"
                    Else
                        lbl_freeze.Visible = False
                        txt_CCode.Enabled = True
                        CMD_Ccode.Enabled = True
                        Txt_Tariffcode.Enabled = True
                        Cmd_tariff.Enabled = True
                    End If
                Next
                Txt_rate.Focus()
            Else
                Txt_tariffdesc.Focus()
            End If
        End If
        Dim j As Integer
        If Txt_Tariffcode.Text <> "" Then
            sqlstring = "select * from Party_TariffHdr_tax where tariffcode='" & Trim(Txt_Tariffcode.Text) & "'  "
            gconnection.getDataSet(sqlstring, "Party_TariffHdr_tax")
            If gdataset.Tables("Party_TariffHdr_tax").Rows.Count > 0 Then
                For i = 0 To gdataset.Tables("Party_TariffHdr_tax").Rows.Count - 1
                    For j = 0 To LST_TAX.Items.Count - 1
                        TempString = Split((LST_TAX.Items.Item(j)), "-->")
                        If Trim(gdataset.Tables("Party_TariffHdr_tax").Rows(i).Item("taxcode")) = TempString(0) Then
                            LST_TAX.SetItemChecked(j, True)
                            LST_TAX.SelectedItem = gdataset.Tables("Party_TariffHdr_tax").Rows(0).Item("taxcode")
                        End If
                    Next
                Next
            End If
        End If

    End Sub

    Private Sub cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Clear.Click
        txt_CCode.Text = ""
        Txt_Cdesc.Text = ""
        Txt_menucode.Text = ""
        Txt_menudesc.Text = ""
        Call FILLTAX()
        Txt_Tariffcode.Text = ""
        Txt_tariffdesc.Text = ""
        Txt_Maxitems.Text = ""
        Txt_rate.Text = ""
        txt_taxcode.Text = ""
        SSGRID.ClearRange(1, 1, -1, -1, True)
        lbl_freeze.Visible = False
        txt_CCode.Enabled = True
        CMD_Ccode.Enabled = True
        Txt_Tariffcode.Enabled = True
        Cmd_tariff.Enabled = True
        cmd_Freeze.Text = "Freeze[F8]"
        cmd_Add.Text = "Add[F7]"
        Txt_Tariffcode.Focus()
    End Sub
    Private Sub cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Add.Click
        Dim grpcode(), INSERT(0), UPDATE(0), ITEMTYPECODE() As String
        Dim i As Integer
        Call checkvalidate()
        If boolchk = False Then Exit Sub
        If Mid(cmd_Add.Text, 1, 1) = "A" Then
            sqlstring = "INSERT INTO party_tariffhdr (tariffcode,tariffdesc,rate,freeze,adduser,adddate) VALUES("
            sqlstring = sqlstring & " '" & Txt_Tariffcode.Text & "','" & Txt_tariffdesc.Text & "',"
            sqlstring = sqlstring & " " & Trim(Txt_rate.Text) & ",'N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "')"
            gconn.dataOperation(1, sqlstring, "HDR")

            sqlstring = "INSERT INTO Party_TariffDet (tariffcode,tariffdesc,freeze,adduser,adddate) VALUES("
            sqlstring = sqlstring & " '" & Txt_Tariffcode.Text & "','" & Txt_tariffdesc.Text & "','N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "')"
            gconn.dataOperation(1, sqlstring, "DET")

            Call cmd_Clear_Click(sender, e)
        ElseIf Mid(cmd_Add.Text, 1, 1) = "U" Then
            If lbl_freeze.Visible = True Then
                MsgBox("Freezed Record Cannot Be Updated", MsgBoxStyle.Information)
                Call cmd_Clear_Click(sender, e)
                Exit Sub
            End If
            sqlstring = "UPDATE party_tariffhdr SET tariffdesc='" & Trim(Txt_tariffdesc.Text) & "',RATE=" & Trim(Txt_rate.Text) & ",FREEZE='N',"
            sqlstring = sqlstring & " ADDUSER='" & Trim(gUsername) & "',ADDDATE='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' "
            sqlstring = sqlstring & " WHERE tariffcode='" & Trim(Txt_Tariffcode.Text) & "'"
            gconn.dataOperation(2, sqlstring, "HDR")

            sqlstring = "UPDATE Party_TariffDet SET tariffdesc='" & Trim(Txt_tariffdesc.Text) & "',FREEZE='N',"
            sqlstring = sqlstring & " ADDUSER='" & Trim(gUsername) & "',ADDDATE='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' "
            sqlstring = sqlstring & " WHERE tariffcode='" & Trim(Txt_Tariffcode.Text) & "'"
            gconn.dataOperation(2, sqlstring, "DET")
            Call cmd_Clear_Click(sender, e)
        End If

        '    sqlstring = "Insert into party_tariffhdr (ccode,tariffcode,tariffdesc,rate,taxcode,sbfcharge,freeze,adduser,adddate,CATEGORY)"
        '    sqlstring = sqlstring & " Values('" & Trim(txt_CCode.Text) & "','" & Txt_Tariffcode.Text & "','" & Txt_tariffdesc.Text & "',"
        '    sqlstring = sqlstring & " " & Trim(Txt_rate.Text) & ",'" & txt_taxcode.Text & "',"
        '    If optYes.Checked = True Then
        '        sqlstring = sqlstring & "'Y',"
        '    Else
        '        sqlstring = sqlstring & "'N',"
        '    End If
        '    sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "','" & cmb_category.Text & "')"

        '    INSERT(0) = sqlstring
        '    '=================================multipletax================================
        '    For i = 0 To LST_TAX.CheckedItems.Count - 1
        '        sqlstring = "Insert into Party_TariffHdr_tax (ccode,tariffcode,tariffdesc,rate,taxcode,sbfcharge,freeze,adduser,adddate,CATEGORY)"
        '        sqlstring = sqlstring & " Values('" & Trim(txt_CCode.Text) & "','" & Txt_Tariffcode.Text & "','" & Txt_tariffdesc.Text & "',"
        '        sqlstring = sqlstring & " " & Trim(Txt_rate.Text) & ","
        '        ITEMTYPECODE = Split(LST_TAX.CheckedItems(i), "-->")
        '        sqlstring = sqlstring & "'" & ITEMTYPECODE(0)
        '        If optYes.Checked = True Then
        '            sqlstring = sqlstring & "'Y',"
        '        Else
        '            sqlstring = sqlstring & "','N',"
        '        End If
        '        sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "','" & cmb_category.Text & "')"
        '        ReDim Preserve UPDATE(UPDATE.Length)
        '        UPDATE(UPDATE.Length - 1) = sqlstring
        '    Next
        '    '============================================================
        '    INSERT(0) = sqlstring

        '    With SSGRID
        '        For i = 1 To .DataRowCnt
        '            sqlstring = "Insert into party_tariffdet (tariffcode,tariffdesc,menucode,menudesc,maxitems,freeze,adduser,adddate)"
        '            sqlstring = sqlstring & " Values('" & Txt_Tariffcode.Text & "','" & Txt_tariffdesc.Text & "',"
        '            .Col = 1
        '            .Row = i
        '            sqlstring = sqlstring & " '" & Trim(.Text) & "',"
        '            .Col = 2
        '            .Row = i
        '            sqlstring = sqlstring & " '" & Trim(.Text) & "',"
        '            .Col = 3
        '            .Row = i
        '            sqlstring = sqlstring & " " & Val(.Text) & ","
        '            sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "')"
        '            ReDim Preserve INSERT(INSERT.Length)
        '            INSERT(INSERT.Length - 1) = sqlstring
        '        Next
        '    End With
        '    gconn.MoreTrans(INSERT)
        '    Call cmd_Clear_Click(sender, e)
        'ElseIf Mid(cmd_Add.Text, 1, 1) = "U" Then

        '        Call checkvalidate()
        '        If boolchk = False Then Exit Sub
        '    'sqlstring = " select * from party_view_tariffmaster where tariffcode='" & Trim(Txt_Tariffcode.Text) & "' and ccode='" & Trim(txt_CCode.Text) & "'"
        '    sqlstring = " select * from party_view_tariffmaster where tariffcode='" & Trim(Txt_Tariffcode.Text) & "' "
        '    gconn.getDataSet(sqlstring, "UPD")
        '        If gdataset.Tables("UPD").Rows.Count = 0 Then
        '            MsgBox("INVALID TARIFF CODE TO UPDATE", MsgBoxStyle.Information)
        '            Exit Sub
        '        End If
        '        ''***********************UPDATION START*****************
        '        sqlstring = "Delete from party_tariffdet where tariffcode in (Select tariffcode from party_tariffhdr where tariffcode='" & Trim(Txt_Tariffcode.Text) & "' and ccode='" & Trim(txt_CCode.Text) & "')"
        '        UPDATE(0) = sqlstring

        '        sqlstring = "Delete from party_tariffhdr where tariffcode='" & Trim(Txt_Tariffcode.Text) & "' and ccode='" & Trim(txt_CCode.Text) & "'"
        '        ReDim Preserve UPDATE(UPDATE.Length)
        '        UPDATE(UPDATE.Length - 1) = sqlstring

        '        sqlstring = "Insert into party_tariffhdr (ccode,tariffcode,tariffdesc,rate,taxcode,sbfcharge,freeze,adduser,adddate,CATEGORY)"
        '        sqlstring = sqlstring & " Values('" & Trim(txt_CCode.Text) & "','" & Txt_Tariffcode.Text & "','" & Txt_tariffdesc.Text & "',"
        '        sqlstring = sqlstring & " " & Trim(Txt_rate.Text) & ",'" & txt_taxcode.Text & "',"
        '        If optYes.Checked = True Then
        '            sqlstring = sqlstring & "'Y',"
        '        Else
        '            sqlstring = sqlstring & "'N',"
        '        End If
        '        sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "','" & cmb_category.Text & "')"
        '        ReDim Preserve UPDATE(UPDATE.Length)
        '    UPDATE(UPDATE.Length - 1) = sqlstring

        '    ''CAHNGED MADE ON 06-06-2012 -----LOGAN
        '    '    With SSGRID
        '    '        For i = 1 To .DataRowCnt
        '    '            sqlstring = "Insert into party_tariffdet (tariffcode,tariffdesc,menucode,menudesc,maxitems,freeze,adduser,adddate)"
        '    '            sqlstring = sqlstring & " Values('" & Txt_Tariffcode.Text & "','" & Txt_tariffdesc.Text & "',"
        '    '            .Col = 1
        '    '            .Row = i
        '    '            sqlstring = sqlstring & " '" & Trim(.Text) & "',"
        '    '            .Col = 2
        '    '            .Row = i
        '    '            sqlstring = sqlstring & " '" & Trim(.Text) & "',"
        '    '            .Col = 3
        '    '            .Row = i
        '    '            sqlstring = sqlstring & " " & Val(.Text) & ","
        '    '            sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "')"
        '    '            ReDim Preserve UPDATE(UPDATE.Length)
        '    '            UPDATE(UPDATE.Length - 1) = sqlstring
        '    '        Next
        '    'End With
        '    '=================================multipletax================================
        '    sqlstring = "delete from Party_TariffHdr_tax where tariffcode='" & Me.Txt_Tariffcode.Text & "'"
        '    ReDim Preserve UPDATE(UPDATE.Length)
        '    UPDATE(UPDATE.Length - 1) = sqlstring
        '    For i = 0 To LST_TAX.CheckedItems.Count - 1
        '        sqlstring = "Insert into Party_TariffHdr_tax (ccode,tariffcode,tariffdesc,rate,taxcode,sbfcharge,freeze,adduser,adddate,CATEGORY)"
        '        sqlstring = sqlstring & " Values('" & Trim(txt_CCode.Text) & "','" & Txt_Tariffcode.Text & "','" & Txt_tariffdesc.Text & "',"
        '        sqlstring = sqlstring & " " & Trim(Txt_rate.Text) & ","
        '        ITEMTYPECODE = Split(LST_TAX.CheckedItems(i), "-->")
        '        sqlstring = sqlstring & "'" & ITEMTYPECODE(0)
        '        If optYes.Checked = True Then
        '            sqlstring = sqlstring & "'Y',"
        '        Else
        '            sqlstring = sqlstring & "','N',"
        '        End If
        '        sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "','" & cmb_category.Text & "')"
        '        ReDim Preserve UPDATE(UPDATE.Length)
        '        UPDATE(UPDATE.Length - 1) = sqlstring
        '    Next
        '    '============================================================
        '    gconn.MoreTrans(UPDATE)
        '    Call cmd_Clear_Click(sender, e)
        'End If
    End Sub
    Private Sub Txt_rate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_rate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_rate.Text) <> 0 Then
                'txt_taxcode.Focus()
                txt_CCode.Focus()
            Else
                Txt_rate.Focus()
            End If
        End If
    End Sub
    Private Sub Txt_Tariffcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Tariffcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Tariffcode.Text) <> "" Then
                Call Txt_Tariffcode_Validated(Txt_Tariffcode, e)
            Else
                Call Cmd_tariff_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Freeze.Click
        Dim INSERT(0) As String
        If Mid(cmd_Freeze.Text, 1, 1) = "F" Then
            Call checkvalidate()
            If boolchk = False Then Exit Sub
            sqlstring = "SELECT * FROM PARTY_VIEW_TARIFFMASTER WHERE TARIFFCODE='" & Trim(Txt_Tariffcode.Text) & "' "
            gconn.getDataSet(sqlstring, "VIEW")
            If gdataset.Tables("VIEW").Rows.Count > 0 Then
                sqlstring = "UPDATE PARTY_TARIFFHDR SET FREEZE='Y' WHERE TARIFFCODE='" & Trim(Txt_Tariffcode.Text) & "' "
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring

                sqlstring = "UPDATE PARTY_TARIFFDET SET FREEZE='Y' WHERE TARIFFCODE IN (SELECT TARIFFCODE FROM PARTY_TARIFFHDR WHERE TARIFFCODE='" & Trim(Txt_Tariffcode.Text) & "' )"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring

                gconn.MoreTrans(INSERT)
                Call cmd_Clear_Click(sender, e)
            End If
        ElseIf Mid(cmd_Freeze.Text, 1, 1) = "U" Then
            sqlstring = "UPDATE PARTY_TARIFFHDR SET FREEZE='N' WHERE TARIFFCODE='" & Trim(Txt_Tariffcode.Text) & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            sqlstring = "UPDATE PARTY_TARIFFDET SET FREEZE='N' WHERE TARIFFCODE IN (SELECT TARIFFCODE FROM PARTY_TARIFFHDR WHERE TARIFFCODE='" & Trim(Txt_Tariffcode.Text) & "' )"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            gconn.MoreTrans(INSERT)
            Call cmd_Clear_Click(sender, e)
        End If
    End Sub
    Private Sub Cmd_Taxcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Taxcode.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT isnull(taxDESC,'') as taxDESC,isnull(TAXCODE,'') as TAXCODE FROM ACCOUNTSTAXMASTER"
        M_WhereCondition = " "
        vform.Field = "TAXDESC,TAXCODE"
        vform.vFormatstring = "        Tax Description    |     Tax Code    "
        vform.vCaption = "Tax Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_taxcode.Text = Trim(vform.keyfield1 & "")
            txt_CCode.Focus()
            'SSGRID.SetActiveCell(1, 1)
            'SSGRID.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_taxcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_taxcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_taxcode.Text) = "" Then
                Call Cmd_Taxcode_Click(sender, e)
            Else
                Call txt_taxcode_Validated(txt_taxcode, e)
            End If
        End If
    End Sub
    Private Sub txt_taxcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_taxcode.Validated
        If Trim(txt_taxcode.Text) <> "" Then
            sqlstring = "SELECT isnull(taxDESC,'') as taxDESC,isnull(TAXCODE,'') as TAXCODE FROM ACCOUNTSTAXMASTER"
            sqlstring = sqlstring & " WHERE ISNULL(TAXCODE,'')='" & Trim(txt_taxcode.Text) & "'"
            gconn.getDataSet(sqlstring, "TAX")
            If gdataset.Tables("TAX").Rows.Count > 0 Then
                txt_taxcode.Text = gdataset.Tables("TAX").Rows(0).Item("TAXCODE")
                txt_CCode.Focus()
                'SSGRID.SetActiveCell(1, 1)
                'SSGRID.Focus()
            Else
                MsgBox("NO RECORDS FOUND", MsgBoxStyle.Information)
                txt_taxcode.Text = ""
                txt_taxcode.Focus()
            End If
        End If
    End Sub
    Private Sub CMD_PRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_PRINT.Click
        gPrint = True
        Grp_Print.Visible = True
    End Sub
    Private Sub CMD_WINDOWS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_WINDOWS.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_MAS_TARIFFHISTORY
        STR = "SELECT * FROM VIEW_PARTY_TARIFFHISTORY ORDER BY TARIFFCODE,CCODE,MENUCODE"
        Viewer.ssql = STR
        Viewer.Report = r
        Viewer.TableName = "VIEW_PARTY_TARIFFHISTORY"
        Dim textobj1 As TextObject
        textobj1 = r.ReportDefinition.ReportObjects("Text3")
        textobj1.Text = MyCompanyName
        Dim TXTOBJ2 As TextObject
        TXTOBJ2 = r.ReportDefinition.ReportObjects("Text1")
        TXTOBJ2.Text = gUsername
        Viewer.Show()
        Grp_Print.Visible = False
    End Sub
    Private Sub CMD_DOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_DOS.Click
        Dim i, j As Integer
        Dim Type() As String
        Dim tablename As String
        Dim typename As String
        Dim heading As String
        Dim str As String
        heading = "TARIFF MASTER"
        str = "SELECT * from VIEW_PARTY_TARIFFHISTORY ORDER BY TARIFFCODE,CCODE,MENUCODE"
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
            Filewrite.WriteLine("SNO Tariff Code Description         Category        Rate       Tax Code")
            Filewrite.WriteLine("    Menu Code   Description         Max Items")
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
        Dim TARIFFCODE As String
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
                    If TARIFFCODE <> dr("TARIFFCODE") Then
                        C = C + 1
                        SSQL = Space(3 - Len(Mid(Format(C, "0"), 1, 3))) & Mid(Format(C, "0"), 1, 3)
                        SSQL = SSQL & Space(1) & Mid(Format(dr("TARIFFCODE"), ""), 1, 10) & Space(10 - Len(Mid(Format(dr("TARIFFCODE"), ""), 1, 10)))
                        SSQL = SSQL & Space(1) & Mid(Format(dr("TARIFFDESC"), ""), 1, 25) & Space(25 - Len(Mid(Format(dr("TARIFFDESC"), ""), 1, 25)))
                        SSQL = SSQL & Space(1) & Mid(Format(dr("CCODE"), ""), 1, 10) & Space(10 - Len(Mid(Format(dr("CCODE"), ""), 1, 10)))
                        SSQL = SSQL & Space(1) & Mid(Format(dr("RATE"), "0.00"), 1, 10) & Space(10 - Len(Mid(Format(dr("RATE"), "0.00"), 1, 10)))
                        SSQL = SSQL & Space(1) & Mid(Format(dr("TAXCODE"), ""), 1, 10) & Space(10 - Len(Mid(Format(dr("TAXCODE"), ""), 1, 10)))
                        Filewrite.WriteLine(SSQL)
                        pagesize = pagesize + 1
                    End If
                    TARIFFCODE = dr("TARIFFCODE")
                    SSQL = Space(3)
                    SSQL = SSQL & Space(1) & Mid(Format(dr("MENUCODE"), ""), 1, 10) & Space(10 - Len(Mid(Format(dr("MENUCODE"), ""), 1, 10)))
                    SSQL = SSQL & Space(1) & Mid(Format(dr("MENUDESC"), ""), 1, 25) & Space(25 - Len(Mid(Format(dr("MENUDESC"), ""), 1, 25)))
                    SSQL = SSQL & Space(1) & Mid(Format(dr("MAXITEMS"), "0"), 1, 10) & Space(10 - Len(Mid(Format(dr("MAXITEMS"), "0"), 1, 10)))
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
    Private Sub cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_View.Click
        gPrint = False
        Grp_Print.Visible = True
    End Sub
    Private Sub FILLMENU()
        Dim vform As New ListOperattion1
        'gSQLString = "SELECT isnull(MENUDESC,'') as MENUDESC,isnull(MENUCODE,'') as MENUCODE FROM PARTY_MENU_MASTER"
        gSQLString = "SELECT isnull(GROUPDESC,'') as GROUPDESC,isnull(GROUPCODE,'') as GROUPCODE FROM PARTY_MENU_MASTER_GROUP"
        M_WhereCondition = " "
        vform.Field = "GROUPDESC,GROUPCODE"
        vform.vFormatstring = "        Group Description    |   Group Code    "
        vform.vCaption = "Group Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With SSGRID
                .Col = 1
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield1 & "")
                .Col = 2
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield)
                .SetActiveCell(3, .ActiveRow)
                .Focus()
            End With
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub SSGRID_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID.KeyDownEvent
        Dim i As Integer
        Dim menucode As String
        With SSGRID
            i = .ActiveRow
            If e.keyCode = Keys.Enter Then
                If .ActiveCol = 1 Then
                    .Col = 1
                    .Row = i
                    menucode = Trim(.Text)
                    If Trim(menucode) = "" Then
                        Call FILLMENU()
                    ElseIf Trim(menucode) <> "" Then
                        sqlstring = "SELECT isnull(MENUDESC,'') as MENUDESC,isnull(MENUCODE,'') as MENUCODE FROM PARTY_MENU_MASTER"
                        sqlstring = sqlstring & " WHERE MENUCODE='" & Trim(menucode) & "' "
                        gconn.getDataSet(sqlstring, "MENU")
                        If gdataset.Tables("MENU").Rows.Count > 0 Then
                            .Col = 1
                            .Row = i
                            .Text = gdataset.Tables("MENU").Rows(0).Item("MENUCODE")
                            .Col = 2
                            .Row = i
                            .Text = gdataset.Tables("MENU").Rows(0).Item("MENUDESC")
                            .SetActiveCell(3, i)
                            .Focus()
                        End If
                    End If
                ElseIf .ActiveCol = 3 Then
                    .Col = 3
                    .Row = i
                    If Val(.Text) <> 0 Then
                        .SetActiveCell(1, i + 1)
                        .Focus()
                    Else
                        .SetActiveCell(3, i)
                        .Focus()
                    End If
                End If
            End If
            If e.keyCode = Keys.F3 Then
                .DeleteRows(i, 1)
                .SetActiveCell(1, i)
                .Focus()
            End If
        End With
    End Sub

    Private Sub PTY_TARIFFMASTER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        Txt_Tariffcode.Focus()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        cmb_category.DropDownStyle = ComboBoxStyle.DropDownList
        Call FILLTAX()
        Show()
    End Sub
    Private Sub FILLTAX()
        Dim I As Integer
        sqlstring = "SELECT TAXCODE+'-->'+TAXDESC +'-->'+ CAST(taxpercentage AS VARCHAR(20))  AS TAXDESC FROM ACCOUNTSTAXMASTER "
        gconnection.getDataSet(sqlstring, "TAXDET")
        Me.LST_TAX.Items.Clear()
        If gdataset.Tables("TAXDET").Rows.Count > 0 Then
            For I = 0 To gdataset.Tables("TAXDET").Rows.Count - 1
                Me.LST_TAX.Items.Add(gdataset.Tables("TAXDET").Rows(I).Item("TAXDESC"))
            Next
        End If
        Dim j As Integer
        sqlstring = "select * from Party_TariffHdr_tax WHERE tariffcode='" & Me.Txt_Tariffcode.Text & "'"
        gconnection.getDataSet(sqlstring, "TAXDET1")
        If gdataset.Tables("TAXDET1").Rows.Count > 0 Then
            For I = 0 To gdataset.Tables("TAXDET1").Rows.Count - 1
                For j = 0 To LST_TAX.Items.Count - 1
                    TempString = Split((LST_TAX.Items.Item(j)), "-->")
                    If Trim(TempString(0)) = Trim(gdataset.Tables("TAXDET1").Rows(I).Item("TAXCODE")) Then
                        LST_TAX.SetItemChecked(j, True)
                        'Else
                        '    LST_TAX.SetItemChecked(j, False)
                    End If
                Next
            Next
        End If
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.cmd_Add.Enabled = False
        Me.cmd_Freeze.Enabled = False
        Me.cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.cmd_Add.Enabled = True
                    Me.cmd_Freeze.Enabled = True
                    Me.cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.cmd_Add.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.cmd_View.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub PTY_TARIFFMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call cmd_Clear_Click(sender, e)
        ElseIf e.KeyCode = Keys.F7 Then
            If cmd_Add.Enabled = True Then
                Call cmd_Add_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F8 Then
            Call cmd_Freeze_Click(sender, e)
        ElseIf e.KeyCode = Keys.F9 Then
            Call cmd_View_Click(sender, e)
        ElseIf e.KeyCode = Keys.F10 Then
            Call CMD_PRINT_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            Call cmd_Exit_Click(sender, e)
        End If
    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "VIEW_PARTY_TARIFFHISTORY"
        sqlstring = "SELECT * FROM VIEW_PARTY_TARIFFHISTORY ORDER BY TARIFFCODE,CCODE,MENUCODE"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub Txt_Tariffcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Tariffcode.TextChanged

    End Sub

    Private Sub SSGRID_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSGRID.Advance

    End Sub

    Private Sub Txt_Cdesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Cdesc.TextChanged

    End Sub

    Private Sub txt_CCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_CCode.TextChanged

    End Sub

    Private Sub Txt_rate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_rate.TextChanged

    End Sub
End Class
