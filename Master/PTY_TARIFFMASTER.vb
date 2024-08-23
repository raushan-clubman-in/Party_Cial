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
    Dim i, j As Integer
    Dim dr As DataRow
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim sqlstring As String
    Dim vSeqNo As Double
    Dim gconnection As New GlobalClass
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents CMD_EXIT As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmd_view As System.Windows.Forms.Button
    Friend WithEvents CMD_FREEZE As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents cmdGroup As System.Windows.Forms.Button
    Friend WithEvents CMDSUBCODE As System.Windows.Forms.Button
    Friend WithEvents cmdType As System.Windows.Forms.Button
    Dim boolchk As Boolean
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
    Friend WithEvents grp_StatusConversion4 As System.Windows.Forms.GroupBox
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
    Friend WithEvents CMD__EXIT As System.Windows.Forms.Button
    Friend WithEvents CMD_WINDOWS As System.Windows.Forms.Button
    Friend WithEvents CMD_DOS As System.Windows.Forms.Button
    Friend WithEvents SSGRID As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents OptNo As System.Windows.Forms.RadioButton
    Friend WithEvents optYes As System.Windows.Forms.RadioButton
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents cmb_category As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PTY_TARIFFMASTER))
        Me.Txt_Cdesc = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txt_CCode = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CMD_Ccode = New System.Windows.Forms.Button()
        Me.Txt_tariffdesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Tariffcode = New System.Windows.Forms.TextBox()
        Me.Cmd_tariff = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdGroup = New System.Windows.Forms.Button()
        Me.CMDSUBCODE = New System.Windows.Forms.Button()
        Me.cmdType = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmb_category = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Cmd_Taxcode = New System.Windows.Forms.Button()
        Me.txt_taxcode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Txt_rate = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Txt_Maxitems = New System.Windows.Forms.TextBox()
        Me.Txt_menudesc = New System.Windows.Forms.TextBox()
        Me.Txt_menucode = New System.Windows.Forms.TextBox()
        Me.Cmd_menucode = New System.Windows.Forms.Button()
        Me.lbl_freeze = New System.Windows.Forms.Label()
        Me.grp_StatusConversion4 = New System.Windows.Forms.GroupBox()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.Grp_Print = New System.Windows.Forms.GroupBox()
        Me.CMD__EXIT = New System.Windows.Forms.Button()
        Me.CMD_WINDOWS = New System.Windows.Forms.Button()
        Me.CMD_DOS = New System.Windows.Forms.Button()
        Me.SSGRID = New AxFPSpreadADO.AxfpSpread()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.OptNo = New System.Windows.Forms.RadioButton()
        Me.optYes = New System.Windows.Forms.RadioButton()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.CMD_EXIT = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.Cmd_view = New System.Windows.Forms.Button()
        Me.CMD_FREEZE = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
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
        Me.Txt_Cdesc.Location = New System.Drawing.Point(562, 133)
        Me.Txt_Cdesc.MaxLength = 50
        Me.Txt_Cdesc.Name = "Txt_Cdesc"
        Me.Txt_Cdesc.Size = New System.Drawing.Size(216, 21)
        Me.Txt_Cdesc.TabIndex = 424
        Me.Txt_Cdesc.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 80)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 15)
        Me.Label14.TabIndex = 426
        Me.Label14.Text = "Category Code"
        '
        'txt_CCode
        '
        Me.txt_CCode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txt_CCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_CCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_CCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CCode.Location = New System.Drawing.Point(115, 80)
        Me.txt_CCode.MaxLength = 10
        Me.txt_CCode.Name = "txt_CCode"
        Me.txt_CCode.Size = New System.Drawing.Size(120, 21)
        Me.txt_CCode.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(408, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 15)
        Me.Label10.TabIndex = 427
        Me.Label10.Text = "Category Description"
        Me.Label10.Visible = False
        '
        'CMD_Ccode
        '
        Me.CMD_Ccode.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMD_Ccode.Image = CType(resources.GetObject("CMD_Ccode.Image"), System.Drawing.Image)
        Me.CMD_Ccode.Location = New System.Drawing.Point(85, 80)
        Me.CMD_Ccode.Name = "CMD_Ccode"
        Me.CMD_Ccode.Size = New System.Drawing.Size(24, 24)
        Me.CMD_Ccode.TabIndex = 428
        Me.CMD_Ccode.UseVisualStyleBackColor = False
        Me.CMD_Ccode.Visible = False
        '
        'Txt_tariffdesc
        '
        Me.Txt_tariffdesc.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_tariffdesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_tariffdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_tariffdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_tariffdesc.Location = New System.Drawing.Point(389, 13)
        Me.Txt_tariffdesc.MaxLength = 50
        Me.Txt_tariffdesc.Name = "Txt_tariffdesc"
        Me.Txt_tariffdesc.Size = New System.Drawing.Size(216, 21)
        Me.Txt_tariffdesc.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 434
        Me.Label1.Text = "Menu  Code"
        '
        'Txt_Tariffcode
        '
        Me.Txt_Tariffcode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_Tariffcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Tariffcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Tariffcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Tariffcode.Location = New System.Drawing.Point(115, 16)
        Me.Txt_Tariffcode.MaxLength = 10
        Me.Txt_Tariffcode.Name = "Txt_Tariffcode"
        Me.Txt_Tariffcode.Size = New System.Drawing.Size(120, 21)
        Me.Txt_Tariffcode.TabIndex = 1
        '
        'Cmd_tariff
        '
        Me.Cmd_tariff.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Cmd_tariff.Image = CType(resources.GetObject("Cmd_tariff.Image"), System.Drawing.Image)
        Me.Cmd_tariff.Location = New System.Drawing.Point(85, 16)
        Me.Cmd_tariff.Name = "Cmd_tariff"
        Me.Cmd_tariff.Size = New System.Drawing.Size(24, 24)
        Me.Cmd_tariff.TabIndex = 436
        Me.Cmd_tariff.UseVisualStyleBackColor = False
        Me.Cmd_tariff.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmdGroup)
        Me.GroupBox2.Controls.Add(Me.CMDSUBCODE)
        Me.GroupBox2.Controls.Add(Me.cmdType)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.cmb_category)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Cmd_Taxcode)
        Me.GroupBox2.Controls.Add(Me.txt_taxcode)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Txt_rate)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Txt_Tariffcode)
        Me.GroupBox2.Controls.Add(Me.Cmd_tariff)
        Me.GroupBox2.Controls.Add(Me.Txt_tariffdesc)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txt_CCode)
        Me.GroupBox2.Controls.Add(Me.CMD_Ccode)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Location = New System.Drawing.Point(181, 151)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(665, 144)
        Me.GroupBox2.TabIndex = 437
        Me.GroupBox2.TabStop = False
        '
        'cmdGroup
        '
        Me.cmdGroup.Location = New System.Drawing.Point(488, 44)
        Me.cmdGroup.Name = "cmdGroup"
        Me.cmdGroup.Size = New System.Drawing.Size(40, 23)
        Me.cmdGroup.TabIndex = 676
        Me.cmdGroup.Text = "?"
        Me.cmdGroup.UseVisualStyleBackColor = True
        '
        'CMDSUBCODE
        '
        Me.CMDSUBCODE.Location = New System.Drawing.Point(235, 78)
        Me.CMDSUBCODE.Name = "CMDSUBCODE"
        Me.CMDSUBCODE.Size = New System.Drawing.Size(40, 23)
        Me.CMDSUBCODE.TabIndex = 677
        Me.CMDSUBCODE.Text = "?"
        Me.CMDSUBCODE.UseVisualStyleBackColor = True
        '
        'cmdType
        '
        Me.cmdType.Location = New System.Drawing.Point(234, 15)
        Me.cmdType.Name = "cmdType"
        Me.cmdType.Size = New System.Drawing.Size(40, 23)
        Me.cmdType.TabIndex = 678
        Me.cmdType.Text = "F4"
        Me.cmdType.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(281, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 15)
        Me.Label4.TabIndex = 451
        Me.Label4.Text = "Tariff Type"
        '
        'cmb_category
        '
        Me.cmb_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb_category.Items.AddRange(New Object() {"VEG", "NON VEG"})
        Me.cmb_category.Location = New System.Drawing.Point(391, 78)
        Me.cmb_category.Name = "cmb_category"
        Me.cmb_category.Size = New System.Drawing.Size(122, 21)
        Me.cmb_category.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(280, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 15)
        Me.Label3.TabIndex = 449
        Me.Label3.Text = "Menu Description"
        '
        'Cmd_Taxcode
        '
        Me.Cmd_Taxcode.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Cmd_Taxcode.Image = CType(resources.GetObject("Cmd_Taxcode.Image"), System.Drawing.Image)
        Me.Cmd_Taxcode.Location = New System.Drawing.Point(591, 48)
        Me.Cmd_Taxcode.Name = "Cmd_Taxcode"
        Me.Cmd_Taxcode.Size = New System.Drawing.Size(24, 24)
        Me.Cmd_Taxcode.TabIndex = 448
        Me.Cmd_Taxcode.UseVisualStyleBackColor = False
        Me.Cmd_Taxcode.Visible = False
        '
        'txt_taxcode
        '
        Me.txt_taxcode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txt_taxcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_taxcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_taxcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_taxcode.Location = New System.Drawing.Point(389, 45)
        Me.txt_taxcode.MaxLength = 50
        Me.txt_taxcode.Name = "txt_taxcode"
        Me.txt_taxcode.Size = New System.Drawing.Size(96, 21)
        Me.txt_taxcode.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(280, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 15)
        Me.Label7.TabIndex = 447
        Me.Label7.Text = "Tax Type"
        '
        'Txt_rate
        '
        Me.Txt_rate.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_rate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_rate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_rate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_rate.Location = New System.Drawing.Point(115, 48)
        Me.Txt_rate.MaxLength = 50
        Me.Txt_rate.Name = "Txt_rate"
        Me.Txt_rate.Size = New System.Drawing.Size(120, 21)
        Me.Txt_rate.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 15)
        Me.Label6.TabIndex = 445
        Me.Label6.Text = "Menu  Rate"
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
        Me.Txt_menucode.Visible = False
        '
        'Cmd_menucode
        '
        Me.Cmd_menucode.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Cmd_menucode.Image = CType(resources.GetObject("Cmd_menucode.Image"), System.Drawing.Image)
        Me.Cmd_menucode.Location = New System.Drawing.Point(32, 8)
        Me.Cmd_menucode.Name = "Cmd_menucode"
        Me.Cmd_menucode.Size = New System.Drawing.Size(24, 24)
        Me.Cmd_menucode.TabIndex = 441
        Me.Cmd_menucode.UseVisualStyleBackColor = False
        Me.Cmd_menucode.Visible = False
        '
        'lbl_freeze
        '
        Me.lbl_freeze.AutoSize = True
        Me.lbl_freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_freeze.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lbl_freeze.Location = New System.Drawing.Point(354, 298)
        Me.lbl_freeze.Name = "lbl_freeze"
        Me.lbl_freeze.Size = New System.Drawing.Size(165, 25)
        Me.lbl_freeze.TabIndex = 441
        Me.lbl_freeze.Text = "Record Freezed"
        Me.lbl_freeze.Visible = False
        '
        'grp_StatusConversion4
        '
        Me.grp_StatusConversion4.BackColor = System.Drawing.Color.Transparent
        Me.grp_StatusConversion4.Location = New System.Drawing.Point(102, 673)
        Me.grp_StatusConversion4.Name = "grp_StatusConversion4"
        Me.grp_StatusConversion4.Size = New System.Drawing.Size(768, 72)
        Me.grp_StatusConversion4.TabIndex = 440
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
        Me.cmdexport.Location = New System.Drawing.Point(728, 304)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(40, 32)
        Me.cmdexport.TabIndex = 435
        Me.cmdexport.Text = "Report[F12]"
        Me.cmdexport.UseVisualStyleBackColor = False
        Me.cmdexport.Visible = False
        '
        'Grp_Print
        '
        Me.Grp_Print.BackColor = System.Drawing.Color.Transparent
        Me.Grp_Print.Controls.Add(Me.CMD__EXIT)
        Me.Grp_Print.Controls.Add(Me.CMD_WINDOWS)
        Me.Grp_Print.Controls.Add(Me.CMD_DOS)
        Me.Grp_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Print.Location = New System.Drawing.Point(302, 586)
        Me.Grp_Print.Name = "Grp_Print"
        Me.Grp_Print.Size = New System.Drawing.Size(368, 56)
        Me.Grp_Print.TabIndex = 664
        Me.Grp_Print.TabStop = False
        Me.Grp_Print.Visible = False
        '
        'CMD__EXIT
        '
        Me.CMD__EXIT.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CMD__EXIT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD__EXIT.Location = New System.Drawing.Point(248, 16)
        Me.CMD__EXIT.Name = "CMD__EXIT"
        Me.CMD__EXIT.Size = New System.Drawing.Size(96, 32)
        Me.CMD__EXIT.TabIndex = 2
        Me.CMD__EXIT.Text = "EXIT"
        Me.CMD__EXIT.UseVisualStyleBackColor = False
        '
        'CMD_WINDOWS
        '
        Me.CMD_WINDOWS.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CMD_WINDOWS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_WINDOWS.Location = New System.Drawing.Point(136, 16)
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
        Me.CMD_DOS.Location = New System.Drawing.Point(24, 16)
        Me.CMD_DOS.Name = "CMD_DOS"
        Me.CMD_DOS.Size = New System.Drawing.Size(96, 32)
        Me.CMD_DOS.TabIndex = 0
        Me.CMD_DOS.Text = "DOS"
        Me.CMD_DOS.UseVisualStyleBackColor = False
        '
        'SSGRID
        '
        Me.SSGRID.DataSource = Nothing
        Me.SSGRID.Location = New System.Drawing.Point(189, 333)
        Me.SSGRID.Name = "SSGRID"
        Me.SSGRID.OcxState = CType(resources.GetObject("SSGRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID.Size = New System.Drawing.Size(649, 184)
        Me.SSGRID.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(176, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 29)
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
        Me.GroupBox3.Location = New System.Drawing.Point(379, 64)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(192, 56)
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
        Me.OptNo.UseVisualStyleBackColor = False
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
        Me.optYes.UseVisualStyleBackColor = False
        '
        'cmdreport
        '
        Me.cmdreport.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.Image = CType(resources.GetObject("cmdreport.Image"), System.Drawing.Image)
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(854, 378)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(144, 65)
        Me.cmdreport.TabIndex = 12
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdreport.UseVisualStyleBackColor = False
        '
        'CMD_EXIT
        '
        Me.CMD_EXIT.BackColor = System.Drawing.Color.Gainsboro
        Me.CMD_EXIT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_EXIT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_EXIT.Image = CType(resources.GetObject("CMD_EXIT.Image"), System.Drawing.Image)
        Me.CMD_EXIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_EXIT.Location = New System.Drawing.Point(854, 579)
        Me.CMD_EXIT.Name = "CMD_EXIT"
        Me.CMD_EXIT.Size = New System.Drawing.Size(144, 65)
        Me.CMD_EXIT.TabIndex = 15
        Me.CMD_EXIT.Text = "Exit [F11]"
        Me.CMD_EXIT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_EXIT.UseVisualStyleBackColor = False
        '
        'Cmdauth
        '
        Me.Cmdauth.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmdauth.BackgroundImage = Global.partymodule.My.Resources.Resources.excel
        Me.Cmdauth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(854, 513)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(144, 65)
        Me.Cmdauth.TabIndex = 14
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdauth.UseVisualStyleBackColor = False
        '
        'Cmdbwse
        '
        Me.Cmdbwse.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmdbwse.BackgroundImage = Global.partymodule.My.Resources.Resources.Clear
        Me.Cmdbwse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmdbwse.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbwse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbwse.Location = New System.Drawing.Point(854, 445)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(144, 65)
        Me.Cmdbwse.TabIndex = 13
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdbwse.UseVisualStyleBackColor = False
        '
        'Cmd_view
        '
        Me.Cmd_view.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_view.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_view.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_view.Image = CType(resources.GetObject("Cmd_view.Image"), System.Drawing.Image)
        Me.Cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_view.Location = New System.Drawing.Point(854, 309)
        Me.Cmd_view.Name = "Cmd_view"
        Me.Cmd_view.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_view.TabIndex = 11
        Me.Cmd_view.Text = "View [F9]"
        Me.Cmd_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_view.UseVisualStyleBackColor = False
        '
        'CMD_FREEZE
        '
        Me.CMD_FREEZE.BackColor = System.Drawing.Color.Gainsboro
        Me.CMD_FREEZE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_FREEZE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_FREEZE.Image = CType(resources.GetObject("CMD_FREEZE.Image"), System.Drawing.Image)
        Me.CMD_FREEZE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_FREEZE.Location = New System.Drawing.Point(854, 241)
        Me.CMD_FREEZE.Name = "CMD_FREEZE"
        Me.CMD_FREEZE.Size = New System.Drawing.Size(144, 65)
        Me.CMD_FREEZE.TabIndex = 10
        Me.CMD_FREEZE.Text = "Freeze [F8]"
        Me.CMD_FREEZE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_FREEZE.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(854, 95)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Clear.TabIndex = 9
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(855, 170)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Add.TabIndex = 8
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'PTY_TARIFFMASTER
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
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbl_freeze)
        Me.Controls.Add(Me.Txt_menudesc)
        Me.Controls.Add(Me.Txt_Maxitems)
        Me.Controls.Add(Me.Txt_menucode)
        Me.Controls.Add(Me.SSGRID)
        Me.Controls.Add(Me.Txt_Cdesc)
        Me.Controls.Add(Me.Grp_Print)
        Me.Controls.Add(Me.grp_StatusConversion4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Cmd_menucode)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmdexport)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "PTY_TARIFFMASTER"
        Me.Text = "TARIFF MASTER"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Grp_Print.ResumeLayout(False)
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub checkvalidate()
        Dim menu As String

        boolchk = False

        Dim ssql As String

        ssql = "select * from PARTY_TARIFFHDR where isnull(FREEZE,'')='Y' AND  TARIFFCODE='" & Txt_Tariffcode.Text & "'"
        gconnection.getDataSet(ssql, "LOG")
        If gdataset.Tables("LOG").Rows.Count > 0 Then
            MessageBox.Show("FREEZE RECORD CANNOT BE UPDATE", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        End If

        If Trim(txt_CCode.Text) = "" Then
            MessageBox.Show("Category Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_CCode.Focus()
            Exit Sub
        End If

        ''If Trim(Txt_Cdesc.Text) = "" Then
        ''    MessageBox.Show("Category Description Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        ''    Txt_Cdesc.Focus()
        ''    Exit Sub
        ''End If
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
        If Trim(txt_taxcode.Text) = "" Then
            MessageBox.Show("TAXCODE CANNOT BE BLANK", MyCompanyName, MessageBoxButtons.OK)
            txt_taxcode.Focus()
            Exit Sub
        End If

        If Val(Txt_rate.Text) <= 0 Then
            MessageBox.Show("Rate Can't be Lessthan Zero", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_rate.Focus()
            Exit Sub
        End If

        If Trim(cmb_category.Text) = "" Then
            MessageBox.Show("Tariff code can't be blank", MyCompanyName, MessageBoxButtons.OK)
            cmb_category.Focus()
            Exit Sub
        End If

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
        With SSGRID
            If .DataRowCnt = 0 Then
                MessageBox.Show("Menus Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                SSGRID.SetActiveCell(1, 1)
                SSGRID.Focus()
                Exit Sub
            End If

        End With
        With SSGRID
            For i = 1 To .DataRowCnt
                .Col = 3
                .Row = i
                menu = .Text
                If Trim(menu) <= 0 Then
                    MessageBox.Show("MAX ITEM CAN'T BE BLANK", MyCompanyName, MessageBoxButtons.OK)

                    Exit Sub
                End If

            Next

        End With

        boolchk = True
    End Sub
    Private Sub Cmd_menucode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_menucode.Click

    End Sub

    Private Sub Cmd_tariff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_tariff.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT  DISTINCT isnull(TARIFFCODE,'') as MENUCODE,isnull(TARIFFDESC,'') as MENUDESC,isnull(CCODE,'')AS CCODE,ISNULL(CDESC,'')AS CDESC FROM PARTY_VIEW_TARIFFMASTER "
        ' M_WhereCondition = " where FREEZE <>'y'"
        M_WhereCondition = ""
        vform.Field = "MENUCODE,MENUDESC,CCODE,CDESC "
        ' vform.vFormatstring = "             Tariff Description            |   Tariff Code    |    CATEGORY    | CATEGORY CODE| RATE| SBF CHARGE"
        vform.vCaption = "menu Master Help"
        'vform.KeyPos = 0
        ' vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        ' vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_Tariffcode.Text = Trim(vform.keyfield & "")
            Txt_Tariffcode.Select()
            'Txt_tariffdesc.Text = Trim(vform.keyfield)
            'txt_CCode.Text = Trim(vform.keyfield2)
            'Txt_Cdesc.Text = Trim(vform.keyfield3)
            Call Txt_Tariffcode_Validated(Txt_Tariffcode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub CMD_Ccode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_Ccode.Click
        ' '' ''Dim vform As New ListOperattion1
        ' '' ''gSQLString = "SELECT isnull(CDESC,'') as CDESC,isnull(CCODE,'') as CCODE FROM PARTY_CATEGORYMASTER"
        ' '' ''M_WhereCondition = " "
        ' '' ''vform.Field = "CDESC,CCODE"
        ' '' ''vform.vFormatstring = "        category Description    |     category Code    "
        ' '' ''vform.vCaption = "Category Master Help"
        ' '' ''vform.KeyPos = 0
        ' '' ''vform.KeyPos1 = 1
        ' '' ''vform.ShowDialog(Me)
        ' '' ''If Trim(vform.keyfield & "") <> "" Then
        ' '' ''    txt_CCode.Text = Trim(vform.keyfield1 & "")
        ' '' ''    Txt_Cdesc.Text = Trim(vform.keyfield)
        ' '' ''    Txt_Cdesc.Focus()
        ' '' ''End If
        ' '' ''vform.Close()
        ' '' ''vform = Nothing
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(categorycode,'') AS categorycode, ISNULL(categorycode,'') AS categoryname FROM POScategorymaster"
            M_WhereCondition = " "
            vform.Field = "categorycode,categorycode"
            ' vform.Frmcalled = "   CATEGORY CODE   | CATEGORY NAME         |                                  "
            vform.vCaption = "Category Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_CCode.Text = Trim(vform.keyfield & "")
                txt_CCode.Select()
                txt_CCode_Validated(sender, e)
                '   Cmd_Add.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
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
            vSeqNo = GetSeqno(txt_CCode.Text)
            sqlstring = "SELECT * FROM poscategorymaster WHERE CATEGORYCODE='" & Trim(txt_CCode.Text) & " '"
            gconnection.getDataSet(sqlstring, "categorymaster")
            If gdataset.Tables("categorymaster").Rows.Count > 0 Then
                Txt_Cdesc.Clear()
                Txt_Cdesc.Text = gdataset.Tables("categorymaster").Rows(0).Item("categoryname")
                txt_CCode.ReadOnly = True
                ' Txt_Cdesc.Focus()
               
                '   Me.Cmd_Add.Text = "Update[F7]"
                Me.txt_CCode.ReadOnly = True
                Me.CMDSUBCODE.Enabled = False
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
                Me.cmb_category.Focus()
            Else
                'Me.lbl_freeze.Visible = False
                'Me.lbl_freeze.Text = "Record Freezed  On "
                ' Me.Cmd_Add.Text = "Add [F7]"
                txt_CCode.ReadOnly = False
                Txt_Cdesc.Focus()
            End If
        Else
            txt_CCode.Text = ""
            Txt_Cdesc.Focus()
        End If
    End Sub

    Private Sub txt_CCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_CCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_CCode.Text) <> "" Then
                Call txt_CCode_Validated(txt_CCode, e)
            Else
                Call CMD_Ccode_Click(sender, e)
            End If
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

    Private Sub Txt_Tariffcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Tariffcode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If Txt_Tariffcode.Enabled = True Then
                Search = Trim(Txt_Tariffcode.Text)
                Call cmdType_Click(Txt_Tariffcode, e)
                Exit Sub
            End If
        End If

    End Sub

    Private Sub Txt_Tariffcode_SystemColorsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Tariffcode.SystemColorsChanged

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
                    txt_CCode.Text = gdataset.Tables("TAR").Rows(0).Item("CCODE")
                    Txt_Cdesc.Text = gdataset.Tables("TAR").Rows(0).Item("CDESC")
                    Txt_rate.Text = gdataset.Tables("TAR").Rows(i).Item("RATE")
                    cmb_category.Text = gdataset.Tables("TAR").Rows(0).Item("CATEGORY")
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
                        Me.lbl_freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("TAR").Rows(0).Item("voidDATE")), "dd-MMM-yyyy") & "  " & gdataset.Tables("TAR").Rows(0).Item("voidUSER")

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
    End Sub


    Private Sub Txt_rate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_rate.KeyPress
        '  getNumeric(e)
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
                'MsgBox(" Numbers only ")
            End If
        End If
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_rate.Text) <> 0 Then
                txt_taxcode.Focus()
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
    Private Sub Cmd_Taxcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Taxcode.Click
        '' ''Dim vform As New ListOperattion1
        '' ''gSQLString = "SELECT isnull(taxDESC,'') as taxDESC,isnull(TAXCODE,'') as TAXCODE FROM ACCOUNTSTAXMASTER"
        '' ''M_WhereCondition = " "
        '' ''vform.Field = "TAXDESC,TAXCODE"
        '' ''vform.vFormatstring = "        Tax Description    |     Tax Code    "
        '' ''vform.vCaption = "Tax Master Help"
        '' ''vform.KeyPos = 0
        '' ''vform.KeyPos1 = 1
        '' ''vform.ShowDialog(Me)
        '' ''If Trim(vform.keyfield & "") <> "" Then
        '' ''    txt_taxcode.Text = Trim(vform.keyfield1 & "")
        '' ''    txt_CCode.Focus()
        '' ''    'SSGRID.SetActiveCell(1, 1)
        '' ''    'SSGRID.Focus()
        '' ''End If
        '' ''vform.Close()
        '' ''vform = Nothing
        Try
            Dim vform As New LIST_OPERATION1


            gSQLString = "SELECT ISNULL(CHARGECODE,'') AS CHARGECODE,ISNULL(CHARGEDESC,'') AS CHARGEDESC  FROM CHARGEMASTER  WHERE "
            M_WhereCondition = " ISNULL(RATE,0)= 0   AND ISNULL(Freeze,'') <> 'Y' AND ISNULL(TAXTYPECODE,'')<>''"
            vform.Field = "CHARGECODE,CHARGEDESC"
            'vform.Frmcalled = "  CHARGECODE  | CHARGE DESCRIPTION          |                                  "
            vform.vCaption = "Charge Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_taxcode.Text = Trim(vform.keyfield & "")
                txt_taxcode.Select()
                txt_taxcode_Validated(sender, e)
                'CmdAdd.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
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
        '' ''If Trim(txt_taxcode.Text) <> "" Then
        '' ''    sqlstring = "SELECT isnull(taxDESC,'') as taxDESC,isnull(TAXCODE,'') as TAXCODE FROM ACCOUNTSTAXMASTER"
        '' ''    sqlstring = sqlstring & " WHERE ISNULL(TAXCODE,'')='" & Trim(txt_taxcode.Text) & "'"
        '' ''    gconn.getDataSet(sqlstring, "TAX")
        '' ''    If gdataset.Tables("TAX").Rows.Count > 0 Then
        '' ''        txt_taxcode.Text = gdataset.Tables("TAX").Rows(0).Item("TAXCODE")
        '' ''        txt_CCode.Focus()
        '' ''        'SSGRID.SetActiveCell(1, 1)
        '' ''        'SSGRID.Focus()
        '' ''    Else
        '' ''        MsgBox("NO RECORDS FOUND", MsgBoxStyle.Information)
        '' ''        txt_taxcode.Text = ""
        '' ''        txt_taxcode.Focus()
        '' ''    End If
        '' ''End If
        Dim SSQL As String

        If txt_taxcode.Text <> "" Then
            SSQL = "SELECT ISNULL(CHARGECODE,'') AS CHARGECODE,ISNULL(CHARGEDESC,'') AS CHARGEDESC FROM CHARGEMASTER  WHERE RATE=0  AND CHARGECODE='" & Trim(txt_taxcode.Text) & "' AND ISNULL(Freeze,'') <> 'Y'AND ISNULL(TAXTYPECODE,'')<>''"
            'ssql = "and "ESC
            gconn.getDataSet(SSQL, "ItemTypeMaster")
            If gdataset.Tables("ItemTypeMaster").Rows.Count > 0 Then
                'txtTypedes.Text = ""
                'txtTypedes.Text = Trim(gdataset.Tables("ItemTypeMaster").Rows(0).Item("CHARGEDESC"))
                'txtTypedes.ReadOnly = True
                ' Txt_subcode.Focus()
                txt_CCode.Focus()
            Else

                txt_taxcode.Focus()
            End If
        Else
            txt_taxcode.Clear()
        End If

    End Sub
    Private Sub CMD_PRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = r.ReportDefinition.ReportObjects("Text9")
        TXTOBJ6.Text = Address1 & Address2

        Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ8 = r.ReportDefinition.ReportObjects("Text10")
        TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ9 = r.ReportDefinition.ReportObjects("Text15")
        TXTOBJ9.Text = "PhoneNo : " & gphoneno
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
                MessageBox.Show("NO RECORD TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
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

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD__EXIT.Click
        Grp_Print.Visible = False
    End Sub
   

    Private Sub FILLMENU()
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT isnull(SUBGROUPCODE,'') as SUBGROUPCODE,isnull(SUBGROUPDESC,'') as SUBGROUPDESC FROM SUBGROUPMASTER"
        M_WhereCondition = " "
        vform.Field = "SUBGROUPCODE,SUBGROUPDESC"
        ' vform.vFormatstring = "        Menu Description    |     Menu Code    "
        vform.vCaption = "SubGroup Master Help"
        ' vform.KeyPos = 0
        ' vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With SSGRID
                .Col = 1
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield & "")
                .Col = 2
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield1)
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
                        sqlstring = "SELECT isnull(SUBGROUPCODE,'') as SUBGROUPCODE,isnull(SUBGROUPDESC,'') as SUBGROUPDESC FROM subgroupmaster"
                        sqlstring = sqlstring & " WHERE SUBGROUPCODE='" & Trim(menucode) & "' "
                        gconn.getDataSet(sqlstring, "MENU")
                        If gdataset.Tables("MENU").Rows.Count > 0 Then
                            .Col = 1
                            .Row = i
                            .Text = gdataset.Tables("MENU").Rows(0).Item("SUBGROUPCODE")
                            .Col = 2
                            .Row = i
                            .Text = gdataset.Tables("MENU").Rows(0).Item("SUBGROUPDESC")
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
        ''  Me.BackgroundImageLayout = ImageLayout.Stretch
        rs.FindAllControls(Me)
        Me.resizeFormResolution()
        rs.ResizeAllControls(Me)

        Txt_Tariffcode.Focus()
        Txt_Tariffcode.Select()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Show()
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



    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='PARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_Add.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        Me.Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
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

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
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



        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = r.ReportDefinition.ReportObjects("Text9")
        TXTOBJ6.Text = Address1 & Address2

        Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ8 = r.ReportDefinition.ReportObjects("Text10")
        TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ9 = r.ReportDefinition.ReportObjects("Text15")
        TXTOBJ9.Text = "PhoneNo : " & gphoneno

        Dim TXTOBJ2 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ2 = r.ReportDefinition.ReportObjects("Text1")
        TXTOBJ2.Text = "UserName : " & gUsername


        Viewer.Show()
        Grp_Print.Visible = False
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        txt_CCode.Text = ""
        Txt_Cdesc.Text = ""
        Txt_menucode.Text = ""
        Txt_menudesc.Text = ""
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

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim grpcode(), INSERT(0), UPDATE(0) As String
        Dim i As Integer
        '
        If Mid(cmd_Add.Text, 1, 1) = "A" Then
            Call checkvalidate()
            If boolchk = False Then Exit Sub

            sqlstring = "Insert into party_tariffhdr (ccode,tariffcode,tariffdesc,rate,taxcode,sbfcharge,freeze,adduser,adddate,CATEGORY)"
            sqlstring = sqlstring & " Values('" & Trim(txt_CCode.Text) & "','" & Txt_Tariffcode.Text & "','" & Txt_tariffdesc.Text & "',"
            sqlstring = sqlstring & " " & Trim(Txt_rate.Text) & ",'" & txt_taxcode.Text & "',"
            If optYes.Checked = True Then
                sqlstring = sqlstring & "'Y',"
            Else
                sqlstring = sqlstring & "'N',"
            End If
            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "','" & cmb_category.Text & "')"

            INSERT(0) = sqlstring

            With SSGRID
                For i = 1 To .DataRowCnt
                    sqlstring = "Insert into party_tariffdet (tariffcode,tariffdesc,menucode,menudesc,maxitems,freeze,adduser,adddate)"
                    sqlstring = sqlstring & " Values('" & Txt_Tariffcode.Text & "','" & Txt_tariffdesc.Text & "',"
                    .Col = 1
                    .Row = i
                    sqlstring = sqlstring & " '" & Trim(.Text) & "',"
                    .Col = 2
                    .Row = i
                    sqlstring = sqlstring & " '" & Trim(.Text) & "',"
                    .Col = 3
                    .Row = i
                    sqlstring = sqlstring & " " & Val(.Text) & ","
                    sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = sqlstring
                Next
            End With
            gconn.MoreTrans(INSERT)
            Call Cmd_Clear_Click(sender, e)
        ElseIf Mid(cmd_Add.Text, 1, 1) = "U" Then

            Call checkvalidate()
            If boolchk = False Then Exit Sub
            sqlstring = " select * from party_view_tariffmaster where tariffcode='" & Trim(Txt_Tariffcode.Text) & "' and ccode='" & Trim(txt_CCode.Text) & "'"
            gconn.getDataSet(sqlstring, "UPD")
            If gdataset.Tables("UPD").Rows.Count = 0 Then
                MsgBox("INVALID TARIFF CODE TO UPDATE", MsgBoxStyle.Information)
                Exit Sub
            End If
            ''***********************UPDATION START*****************
            sqlstring = "Delete from party_tariffdet where tariffcode in (Select tariffcode from party_tariffhdr where tariffcode='" & Trim(Txt_Tariffcode.Text) & "' and ccode='" & Trim(txt_CCode.Text) & "')"
            UPDATE(0) = sqlstring

            sqlstring = "Delete from party_tariffhdr where tariffcode='" & Trim(Txt_Tariffcode.Text) & "' and ccode='" & Trim(txt_CCode.Text) & "'"
            ReDim Preserve UPDATE(UPDATE.Length)
            UPDATE(UPDATE.Length - 1) = sqlstring

            sqlstring = "Insert into party_tariffhdr (ccode,tariffcode,tariffdesc,rate,taxcode,sbfcharge,freeze,adduser,adddate,CATEGORY)"
            sqlstring = sqlstring & " Values('" & Trim(txt_CCode.Text) & "','" & Txt_Tariffcode.Text & "','" & Txt_tariffdesc.Text & "',"
            sqlstring = sqlstring & " " & Trim(Txt_rate.Text) & ",'" & txt_taxcode.Text & "',"
            If optYes.Checked = True Then
                sqlstring = sqlstring & "'Y',"
            Else
                sqlstring = sqlstring & "'N',"
            End If
            sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "','" & cmb_category.Text & "')"
            ReDim Preserve UPDATE(UPDATE.Length)
            UPDATE(UPDATE.Length - 1) = sqlstring

            With SSGRID
                For i = 1 To .DataRowCnt
                    sqlstring = "Insert into party_tariffdet (tariffcode,tariffdesc,menucode,menudesc,maxitems,freeze,adduser,adddate)"
                    sqlstring = sqlstring & " Values('" & Txt_Tariffcode.Text & "','" & Txt_tariffdesc.Text & "',"
                    .Col = 1
                    .Row = i
                    sqlstring = sqlstring & " '" & Trim(.Text) & "',"
                    .Col = 2
                    .Row = i
                    sqlstring = sqlstring & " '" & Trim(.Text) & "',"
                    .Col = 3
                    .Row = i
                    sqlstring = sqlstring & " " & Val(.Text) & ","
                    sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "')"
                    ReDim Preserve UPDATE(UPDATE.Length)
                    UPDATE(UPDATE.Length - 1) = sqlstring
                Next
            End With
            gconn.MoreTrans(UPDATE)
            Call Cmd_Clear_Click(sender, e)
        End If
    End Sub


    Private Sub CMD_FREEZE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_FREEZE.Click
        Dim INSERT(0) As String
        If Mid(cmd_Freeze.Text, 1, 1) = "F" Then
            Call checkvalidate()
            If boolchk = False Then Exit Sub
            sqlstring = "SELECT * FROM PARTY_VIEW_TARIFFMASTER WHERE TARIFFCODE='" & Trim(Txt_Tariffcode.Text) & "' AND CCODE='" & Trim(txt_CCode.Text) & "'"
            gconn.getDataSet(sqlstring, "VIEW")
            If gdataset.Tables("VIEW").Rows.Count > 0 Then
                sqlstring = "UPDATE PARTY_TARIFFHDR SET FREEZE='Y',voiduser='" & Trim(gUsername) & "',voiddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' WHERE TARIFFCODE='" & Trim(Txt_Tariffcode.Text) & "' AND CCODE='" & Trim(txt_CCode.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring

                sqlstring = "UPDATE PARTY_TARIFFDET SET FREEZE='Y',voiduser='" & Trim(gUsername) & "',voiddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' WHERE TARIFFCODE IN (SELECT TARIFFCODE FROM PARTY_TARIFFHDR WHERE TARIFFCODE='" & Trim(Txt_Tariffcode.Text) & "' AND CCODE='" & Trim(txt_CCode.Text) & "')"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring

                gconn.MoreTrans(INSERT)
                Call Cmd_Clear_Click(sender, e)
            End If
        ElseIf Mid(cmd_Freeze.Text, 1, 1) = "U" Then
            sqlstring = "UPDATE PARTY_TARIFFHDR SET FREEZE='N',voiduser='" & Trim(gUsername) & "',voiddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' WHERE TARIFFCODE='" & Trim(Txt_Tariffcode.Text) & "' AND CCODE='" & Trim(txt_CCode.Text) & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            sqlstring = "UPDATE PARTY_TARIFFDET SET FREEZE='N',voiduser='" & Trim(gUsername) & "',voiddate='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' WHERE TARIFFCODE IN (SELECT TARIFFCODE FROM PARTY_TARIFFHDR WHERE TARIFFCODE='" & Trim(Txt_Tariffcode.Text) & "' AND CCODE='" & Trim(txt_CCode.Text) & "')"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring

            gconn.MoreTrans(INSERT)
            Call Cmd_Clear_Click(sender, e)
        End If
    End Sub

    Private Sub CMD_EXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_EXIT.Click
        Me.Close()
    End Sub

    Private Sub Cmd_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_view.Click
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
    End Sub

    Private Sub txt_taxcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_taxcode.TextChanged

    End Sub

    Private Sub cmdGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGroup.Click
        Try
            Dim vform As New LIST_OPERATION1


            gSQLString = "SELECT ISNULL(CHARGECODE,'') AS CHARGECODE,ISNULL(CHARGEDESC,'') AS CHARGEDESC  FROM CHARGEMASTER  WHERE "
            M_WhereCondition = " RATE=0   AND ISNULL(Freeze,'') <> 'Y'AND ISNULL(TAXTYPECODE,'')<>'' "
            vform.Field = "CHARGECODE,CHARGEDESC"
            'vform.Frmcalled = "  CHARGECODE  | CHARGE DESCRIPTION          |                                  "
            vform.vCaption = "Charge Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_taxcode.Text = Trim(vform.keyfield & "")
                txt_taxcode.Select()
                txt_taxcode_Validated(sender, e)
                'CmdAdd.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub CMDSUBCODE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSUBCODE.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(categorycode,'') AS categorycode, ISNULL(categorycode,'') AS categoryname FROM POScategorymaster"
            M_WhereCondition = " "
            vform.Field = "categorycode,categorycode"
            ' vform.Frmcalled = "   CATEGORY CODE   | CATEGORY NAME         |                                  "
            vform.vCaption = "Category Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txt_CCode.Text = Trim(vform.keyfield & "")
                txt_CCode.Select()
                txt_CCode_Validated(sender, e)
                Cmd_Add.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub txt_CCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_CCode.TextChanged

    End Sub

    Private Sub txt_taxcode_RightToLeftChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_taxcode.RightToLeftChanged

    End Sub

    Private Sub txt_taxcode_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_taxcode.Move

    End Sub

    Private Sub Txt_Cdesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Cdesc.TextChanged

    End Sub

    Private Sub cmb_category_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmb_category.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If cmb_category.Text = "" Then
                cmb_category.Focus()
            Else
                SSGRID.SetActiveCell(1, 1)
                SSGRID.Focus()
            End If
           
        End If
    End Sub

    Private Sub cmb_category_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_category.SelectedIndexChanged

    End Sub

    Private Sub Cmdbwse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbwse.Click
        brows = True
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM PARTY_VIEW_TARIFFMASTER"
        gconnection.getDataSet(STRQUERY, "authorize")

        Call VIEW1.LOADGRID(gdataset.Tables("authorize"), True, "", "SELECT * FROM PARTY_VIEW_TARIFFMASTER", "tariffcode", 1, Me.Txt_Tariffcode)

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
            SSQLSTR2 = " SELECT * FROM PARTY_TARIFFHDR WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PARTY_TARIFFHDR WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_TARIFFHDR set  ", "TARIFFCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 0)
                        End If
                    Else
                        MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                    End If
                End If
            End If
        ElseIf USERT = 2 Then
            SSQLSTR2 = " SELECT * FROM PARTY_TARIFFHDR WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')='' AND ISNULL(AUTHORISE_USER1,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PARTY_TARIFFHDR WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_TARIFFHDR set  ", "TARIFFCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            End If
        ElseIf USERT = 3 Then
            SSQLSTR2 = " SELECT * FROM PARTY_TARIFFHDR WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''  AND ISNULL(AUTHORISE_USER2,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PARTY_TARIFFHDR WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_TARIFFHDR set  ", "TARIFFCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                        End If
                    End If
                End If
            Else
                MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    Private Sub cmdType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdType.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT  DISTINCT isnull(TARIFFCODE,'') as MENUCODE,isnull(TARIFFDESC,'') as MENUDESC,isnull(CCODE,'')AS CCODE,ISNULL(CDESC,'')AS CDESC FROM PARTY_VIEW_TARIFFMASTER "
        ' M_WhereCondition = " where FREEZE <>'y'"
        vform.Field = "MENUCODE,MENUDESC,CCODE,CDESC "
        ' vform.vFormatstring = "             Tariff Description            |   Tariff Code    |    CATEGORY    | CATEGORY CODE| RATE| SBF CHARGE"
        vform.vCaption = "menu Master Help"
        'vform.KeyPos = 0
        ' vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        ' vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_Tariffcode.Text = Trim(vform.keyfield & "")
            Txt_Tariffcode.Select()
            'Txt_tariffdesc.Text = Trim(vform.keyfield)
            'txt_CCode.Text = Trim(vform.keyfield2)
            'Txt_Cdesc.Text = Trim(vform.keyfield3)
            Call Txt_Tariffcode_Validated(Txt_Tariffcode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub cmdType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdType.KeyDown
        If e.KeyCode = Keys.F4 Or e.KeyCode = Keys.Enter Then
            If Txt_Tariffcode.Enabled = True Then
                Search = Trim(Txt_Tariffcode.Text)
                Call cmdType_Click(Txt_Tariffcode, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmdType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmdType.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Tariffcode.Text) <> "" Then
                Call Txt_Tariffcode_Validated(Txt_Tariffcode, e)
            Else
                Call Cmd_tariff_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Txt_rate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_rate.TextChanged

    End Sub

    Private Sub PTY_TARIFFMASTER_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class
