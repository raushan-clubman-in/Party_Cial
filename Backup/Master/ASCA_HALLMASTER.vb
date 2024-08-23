Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Public Class ASCA_HALLMASTER
    Inherits System.Windows.Forms.Form
    Dim gconnection As New GlobalClass
    Dim gconn As New GlobalClass
    Dim vconn As New GlobalClass
    Dim i As Integer
    Dim sqlstring As String
    Dim boolchk As Boolean
    Dim pageno As Integer
    Dim TempString(3) As String
    Dim dr As DataRow
    Dim pagesize As Integer
    Dim HALLCODE, HALLDESC, HALLTYPE, A, B, C, D, E, F, G, H, J, K, L
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents SSGRID As AxFPSpreadADO.AxfpSpread
    Friend WithEvents lbl_freeze As System.Windows.Forms.Label
    Friend WithEvents cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents grp_StatusConversion4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Add As System.Windows.Forms.Button
    Friend WithEvents cmd_View As System.Windows.Forms.Button
    Friend WithEvents cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Txt_MaxCapacity As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Mincapacity As System.Windows.Forms.TextBox
    Friend WithEvents Txt_HallTypedesc As System.Windows.Forms.TextBox
    Friend WithEvents txt_HallType As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Locdesc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Loccode As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ActCapacity As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Rate As System.Windows.Forms.TextBox
    Friend WithEvents Txt_taxtype As System.Windows.Forms.TextBox
    Friend WithEvents Txt_menurate As System.Windows.Forms.TextBox
    Friend WithEvents Txt_menuhead As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Taxtype As System.Windows.Forms.Button
    Friend WithEvents Cmd_Loccode As System.Windows.Forms.Button
    Friend WithEvents CMD_Hallcode As System.Windows.Forms.Button
    Friend WithEvents Grp_Print As System.Windows.Forms.GroupBox
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMD_WINDOWS As System.Windows.Forms.Button
    Friend WithEvents CMD_DOS As System.Windows.Forms.Button
    Friend WithEvents CMD_PRINT As System.Windows.Forms.Button
    Friend WithEvents TXT_GLACCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CMD_GLACCODE As System.Windows.Forms.Button
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents sec_dep As System.Windows.Forms.TextBox
    Friend WithEvents LST_TAX As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_feau As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txt_rate1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ASCA_HALLMASTER))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txt_rate1 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txt_feau = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.sec_dep = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CMD_GLACCODE = New System.Windows.Forms.Button
        Me.TXT_GLACCODE = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Txt_Rate = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Txt_ActCapacity = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Txt_MaxCapacity = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_Mincapacity = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_HallTypedesc = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_HallType = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CMD_Hallcode = New System.Windows.Forms.Button
        Me.Txt_menuhead = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Txt_menurate = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Txt_Locdesc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_Loccode = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Cmd_Loccode = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Txt_taxtype = New System.Windows.Forms.TextBox
        Me.Cmd_Taxtype = New System.Windows.Forms.Button
        Me.SSGRID = New AxFPSpreadADO.AxfpSpread
        Me.lbl_freeze = New System.Windows.Forms.Label
        Me.cmd_Exit = New System.Windows.Forms.Button
        Me.cmd_Freeze = New System.Windows.Forms.Button
        Me.grp_StatusConversion4 = New System.Windows.Forms.GroupBox
        Me.CMD_PRINT = New System.Windows.Forms.Button
        Me.cmd_Add = New System.Windows.Forms.Button
        Me.cmd_Clear = New System.Windows.Forms.Button
        Me.cmd_View = New System.Windows.Forms.Button
        Me.cmdexport = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.Grp_Print = New System.Windows.Forms.GroupBox
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMD_WINDOWS = New System.Windows.Forms.Button
        Me.CMD_DOS = New System.Windows.Forms.Button
        Me.LST_TAX = New System.Windows.Forms.CheckedListBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp_StatusConversion4.SuspendLayout()
        Me.Grp_Print.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.txt_rate1)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txt_feau)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.sec_dep)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.CMD_GLACCODE)
        Me.GroupBox1.Controls.Add(Me.TXT_GLACCODE)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Txt_Rate)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Txt_ActCapacity)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Txt_MaxCapacity)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Txt_Mincapacity)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Txt_HallTypedesc)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txt_HallType)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.CMD_Hallcode)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(696, 224)
        Me.GroupBox1.TabIndex = 430
        Me.GroupBox1.TabStop = False
        '
        'txt_rate1
        '
        Me.txt_rate1.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txt_rate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_rate1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_rate1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_rate1.Location = New System.Drawing.Point(504, 88)
        Me.txt_rate1.MaxLength = 5
        Me.txt_rate1.Name = "txt_rate1"
        Me.txt_rate1.Size = New System.Drawing.Size(64, 21)
        Me.txt_rate1.TabIndex = 456
        Me.txt_rate1.Text = ""
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(400, 88)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 21)
        Me.Label15.TabIndex = 457
        Me.Label15.Text = "Guest  Rate"
        '
        'txt_feau
        '
        Me.txt_feau.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txt_feau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_feau.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_feau.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_feau.Location = New System.Drawing.Point(144, 160)
        Me.txt_feau.MaxLength = 50
        Me.txt_feau.Name = "txt_feau"
        Me.txt_feau.Size = New System.Drawing.Size(176, 21)
        Me.txt_feau.TabIndex = 455
        Me.txt_feau.Text = ""
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 160)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 21)
        Me.Label13.TabIndex = 454
        Me.Label13.Text = "Features  "
        '
        'sec_dep
        '
        Me.sec_dep.BackColor = System.Drawing.Color.AntiqueWhite
        Me.sec_dep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sec_dep.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.sec_dep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sec_dep.Location = New System.Drawing.Point(144, 120)
        Me.sec_dep.MaxLength = 8
        Me.sec_dep.Name = "sec_dep"
        Me.sec_dep.Size = New System.Drawing.Size(64, 21)
        Me.sec_dep.TabIndex = 453
        Me.sec_dep.Text = ""
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(132, 21)
        Me.Label12.TabIndex = 452
        Me.Label12.Text = "Secuirty Deposit "
        '
        'CMD_GLACCODE
        '
        Me.CMD_GLACCODE.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CMD_GLACCODE.Image = CType(resources.GetObject("CMD_GLACCODE.Image"), System.Drawing.Image)
        Me.CMD_GLACCODE.Location = New System.Drawing.Point(584, 120)
        Me.CMD_GLACCODE.Name = "CMD_GLACCODE"
        Me.CMD_GLACCODE.Size = New System.Drawing.Size(24, 24)
        Me.CMD_GLACCODE.TabIndex = 451
        '
        'TXT_GLACCODE
        '
        Me.TXT_GLACCODE.BackColor = System.Drawing.Color.AntiqueWhite
        Me.TXT_GLACCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_GLACCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_GLACCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_GLACCODE.Location = New System.Drawing.Point(504, 120)
        Me.TXT_GLACCODE.MaxLength = 50
        Me.TXT_GLACCODE.Name = "TXT_GLACCODE"
        Me.TXT_GLACCODE.Size = New System.Drawing.Size(80, 21)
        Me.TXT_GLACCODE.TabIndex = 449
        Me.TXT_GLACCODE.Text = ""
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(368, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(136, 21)
        Me.Label11.TabIndex = 450
        Me.Label11.Text = "GL Account Code"
        '
        'Txt_Rate
        '
        Me.Txt_Rate.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_Rate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Rate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Rate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Rate.Location = New System.Drawing.Point(144, 88)
        Me.Txt_Rate.MaxLength = 5
        Me.Txt_Rate.Name = "Txt_Rate"
        Me.Txt_Rate.Size = New System.Drawing.Size(64, 21)
        Me.Txt_Rate.TabIndex = 440
        Me.Txt_Rate.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 21)
        Me.Label6.TabIndex = 441
        Me.Label6.Text = "Member  Rate"
        '
        'Txt_ActCapacity
        '
        Me.Txt_ActCapacity.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_ActCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_ActCapacity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ActCapacity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ActCapacity.Location = New System.Drawing.Point(144, 56)
        Me.Txt_ActCapacity.MaxLength = 5
        Me.Txt_ActCapacity.Name = "Txt_ActCapacity"
        Me.Txt_ActCapacity.Size = New System.Drawing.Size(64, 21)
        Me.Txt_ActCapacity.TabIndex = 438
        Me.Txt_ActCapacity.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 21)
        Me.Label5.TabIndex = 439
        Me.Label5.Text = "Actual Capacity"
        '
        'Txt_MaxCapacity
        '
        Me.Txt_MaxCapacity.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_MaxCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MaxCapacity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MaxCapacity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MaxCapacity.Location = New System.Drawing.Point(504, 56)
        Me.Txt_MaxCapacity.MaxLength = 5
        Me.Txt_MaxCapacity.Name = "Txt_MaxCapacity"
        Me.Txt_MaxCapacity.Size = New System.Drawing.Size(64, 21)
        Me.Txt_MaxCapacity.TabIndex = 431
        Me.Txt_MaxCapacity.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(392, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 21)
        Me.Label2.TabIndex = 432
        Me.Label2.Text = "Max Capacity"
        '
        'Txt_Mincapacity
        '
        Me.Txt_Mincapacity.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_Mincapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Mincapacity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Mincapacity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Mincapacity.Location = New System.Drawing.Point(320, 56)
        Me.Txt_Mincapacity.MaxLength = 5
        Me.Txt_Mincapacity.Name = "Txt_Mincapacity"
        Me.Txt_Mincapacity.Size = New System.Drawing.Size(56, 21)
        Me.Txt_Mincapacity.TabIndex = 429
        Me.Txt_Mincapacity.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(216, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 21)
        Me.Label1.TabIndex = 430
        Me.Label1.Text = "Min Capacity"
        '
        'Txt_HallTypedesc
        '
        Me.Txt_HallTypedesc.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_HallTypedesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_HallTypedesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_HallTypedesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_HallTypedesc.Location = New System.Drawing.Point(504, 16)
        Me.Txt_HallTypedesc.MaxLength = 50
        Me.Txt_HallTypedesc.Name = "Txt_HallTypedesc"
        Me.Txt_HallTypedesc.Size = New System.Drawing.Size(184, 21)
        Me.Txt_HallTypedesc.TabIndex = 424
        Me.Txt_HallTypedesc.Text = ""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(77, 21)
        Me.Label14.TabIndex = 426
        Me.Label14.Text = "Hall Code"
        '
        'txt_HallType
        '
        Me.txt_HallType.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txt_HallType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_HallType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_HallType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_HallType.Location = New System.Drawing.Point(144, 16)
        Me.txt_HallType.MaxLength = 10
        Me.txt_HallType.Name = "txt_HallType"
        Me.txt_HallType.Size = New System.Drawing.Size(168, 21)
        Me.txt_HallType.TabIndex = 423
        Me.txt_HallType.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(368, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 21)
        Me.Label10.TabIndex = 427
        Me.Label10.Text = "Hall  Description"
        '
        'CMD_Hallcode
        '
        Me.CMD_Hallcode.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CMD_Hallcode.Image = CType(resources.GetObject("CMD_Hallcode.Image"), System.Drawing.Image)
        Me.CMD_Hallcode.Location = New System.Drawing.Point(312, 16)
        Me.CMD_Hallcode.Name = "CMD_Hallcode"
        Me.CMD_Hallcode.Size = New System.Drawing.Size(24, 24)
        Me.CMD_Hallcode.TabIndex = 428
        '
        'Txt_menuhead
        '
        Me.Txt_menuhead.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_menuhead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_menuhead.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_menuhead.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_menuhead.Location = New System.Drawing.Point(696, 0)
        Me.Txt_menuhead.MaxLength = 50
        Me.Txt_menuhead.Name = "Txt_menuhead"
        Me.Txt_menuhead.Size = New System.Drawing.Size(16, 21)
        Me.Txt_menuhead.TabIndex = 447
        Me.Txt_menuhead.Text = ""
        Me.Txt_menuhead.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(592, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 21)
        Me.Label9.TabIndex = 448
        Me.Label9.Text = "Menu Head %"
        Me.Label9.Visible = False
        '
        'Txt_menurate
        '
        Me.Txt_menurate.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_menurate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_menurate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_menurate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_menurate.Location = New System.Drawing.Point(816, 0)
        Me.Txt_menurate.MaxLength = 50
        Me.Txt_menurate.Name = "Txt_menurate"
        Me.Txt_menurate.Size = New System.Drawing.Size(40, 21)
        Me.Txt_menurate.TabIndex = 445
        Me.Txt_menurate.Text = ""
        Me.Txt_menurate.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(696, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 21)
        Me.Label8.TabIndex = 446
        Me.Label8.Text = "Menu Rate %"
        Me.Label8.Visible = False
        '
        'Txt_Locdesc
        '
        Me.Txt_Locdesc.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_Locdesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Locdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Locdesc.Enabled = False
        Me.Txt_Locdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Locdesc.Location = New System.Drawing.Point(48, 16)
        Me.Txt_Locdesc.MaxLength = 50
        Me.Txt_Locdesc.Name = "Txt_Locdesc"
        Me.Txt_Locdesc.Size = New System.Drawing.Size(40, 21)
        Me.Txt_Locdesc.TabIndex = 434
        Me.Txt_Locdesc.Text = ""
        Me.Txt_Locdesc.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 21)
        Me.Label3.TabIndex = 435
        Me.Label3.Text = "Location Code"
        Me.Label3.Visible = False
        '
        'Txt_Loccode
        '
        Me.Txt_Loccode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_Loccode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Loccode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Loccode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Loccode.Location = New System.Drawing.Point(136, 16)
        Me.Txt_Loccode.MaxLength = 10
        Me.Txt_Loccode.Name = "Txt_Loccode"
        Me.Txt_Loccode.Size = New System.Drawing.Size(48, 21)
        Me.Txt_Loccode.TabIndex = 433
        Me.Txt_Loccode.Text = ""
        Me.Txt_Loccode.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(176, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(159, 21)
        Me.Label4.TabIndex = 436
        Me.Label4.Text = "Location Description"
        Me.Label4.Visible = False
        '
        'Cmd_Loccode
        '
        Me.Cmd_Loccode.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Cmd_Loccode.Image = CType(resources.GetObject("Cmd_Loccode.Image"), System.Drawing.Image)
        Me.Cmd_Loccode.Location = New System.Drawing.Point(200, 16)
        Me.Cmd_Loccode.Name = "Cmd_Loccode"
        Me.Cmd_Loccode.Size = New System.Drawing.Size(32, 24)
        Me.Cmd_Loccode.TabIndex = 437
        Me.Cmd_Loccode.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 520)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 21)
        Me.Label7.TabIndex = 443
        Me.Label7.Text = "Tax Type"
        Me.Label7.Visible = False
        '
        'Txt_taxtype
        '
        Me.Txt_taxtype.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_taxtype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_taxtype.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_taxtype.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_taxtype.Location = New System.Drawing.Point(88, 520)
        Me.Txt_taxtype.MaxLength = 10
        Me.Txt_taxtype.Name = "Txt_taxtype"
        Me.Txt_taxtype.Size = New System.Drawing.Size(16, 21)
        Me.Txt_taxtype.TabIndex = 442
        Me.Txt_taxtype.Text = ""
        Me.Txt_taxtype.Visible = False
        '
        'Cmd_Taxtype
        '
        Me.Cmd_Taxtype.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.Cmd_Taxtype.Image = CType(resources.GetObject("Cmd_Taxtype.Image"), System.Drawing.Image)
        Me.Cmd_Taxtype.Location = New System.Drawing.Point(112, 512)
        Me.Cmd_Taxtype.Name = "Cmd_Taxtype"
        Me.Cmd_Taxtype.Size = New System.Drawing.Size(24, 24)
        Me.Cmd_Taxtype.TabIndex = 444
        Me.Cmd_Taxtype.Visible = False
        '
        'SSGRID
        '
        Me.SSGRID.DataSource = Nothing
        Me.SSGRID.Location = New System.Drawing.Point(8, 312)
        Me.SSGRID.Name = "SSGRID"
        Me.SSGRID.OcxState = CType(resources.GetObject("SSGRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID.Size = New System.Drawing.Size(896, 192)
        Me.SSGRID.TabIndex = 431
        '
        'lbl_freeze
        '
        Me.lbl_freeze.AutoSize = True
        Me.lbl_freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_freeze.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.lbl_freeze.Location = New System.Drawing.Point(304, 280)
        Me.lbl_freeze.Name = "lbl_freeze"
        Me.lbl_freeze.Size = New System.Drawing.Size(160, 26)
        Me.lbl_freeze.TabIndex = 435
        Me.lbl_freeze.Text = "Record Freezed"
        '
        'cmd_Exit
        '
        Me.cmd_Exit.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Exit.BackgroundImage = CType(resources.GetObject("cmd_Exit.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.cmd_Exit.Location = New System.Drawing.Point(760, 576)
        Me.cmd_Exit.Name = "cmd_Exit"
        Me.cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Exit.TabIndex = 433
        Me.cmd_Exit.Text = "Exit[F11]"
        '
        'cmd_Freeze
        '
        Me.cmd_Freeze.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Freeze.BackgroundImage = CType(resources.GetObject("cmd_Freeze.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.cmd_Freeze.Location = New System.Drawing.Point(304, 16)
        Me.cmd_Freeze.Name = "cmd_Freeze"
        Me.cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Freeze.TabIndex = 432
        Me.cmd_Freeze.Text = "Freeze[F8]"
        '
        'grp_StatusConversion4
        '
        Me.grp_StatusConversion4.BackColor = System.Drawing.Color.Transparent
        Me.grp_StatusConversion4.Controls.Add(Me.CMD_PRINT)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Add)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Clear)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Freeze)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_View)
        Me.grp_StatusConversion4.Location = New System.Drawing.Point(48, 560)
        Me.grp_StatusConversion4.Name = "grp_StatusConversion4"
        Me.grp_StatusConversion4.Size = New System.Drawing.Size(848, 64)
        Me.grp_StatusConversion4.TabIndex = 434
        Me.grp_StatusConversion4.TabStop = False
        '
        'CMD_PRINT
        '
        Me.CMD_PRINT.BackColor = System.Drawing.SystemColors.Menu
        Me.CMD_PRINT.BackgroundImage = CType(resources.GetObject("CMD_PRINT.BackgroundImage"), System.Drawing.Image)
        Me.CMD_PRINT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMD_PRINT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_PRINT.ForeColor = System.Drawing.Color.White
        Me.CMD_PRINT.Location = New System.Drawing.Point(584, 16)
        Me.CMD_PRINT.Name = "CMD_PRINT"
        Me.CMD_PRINT.Size = New System.Drawing.Size(104, 32)
        Me.CMD_PRINT.TabIndex = 382
        Me.CMD_PRINT.Text = "Print [F10]"
        '
        'cmd_Add
        '
        Me.cmd_Add.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Add.BackgroundImage = CType(resources.GetObject("cmd_Add.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Add.ForeColor = System.Drawing.Color.White
        Me.cmd_Add.Location = New System.Drawing.Point(160, 16)
        Me.cmd_Add.Name = "cmd_Add"
        Me.cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Add.TabIndex = 378
        Me.cmd_Add.Text = "Add[F7]"
        '
        'cmd_Clear
        '
        Me.cmd_Clear.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Clear.BackgroundImage = CType(resources.GetObject("cmd_Clear.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Clear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Clear.ForeColor = System.Drawing.Color.White
        Me.cmd_Clear.Location = New System.Drawing.Point(8, 16)
        Me.cmd_Clear.Name = "cmd_Clear"
        Me.cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Clear.TabIndex = 381
        Me.cmd_Clear.Text = "Clear[F6]"
        '
        'cmd_View
        '
        Me.cmd_View.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_View.BackgroundImage = CType(resources.GetObject("cmd_View.BackgroundImage"), System.Drawing.Image)
        Me.cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_View.ForeColor = System.Drawing.Color.White
        Me.cmd_View.Location = New System.Drawing.Point(456, 16)
        Me.cmd_View.Name = "cmd_View"
        Me.cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.cmd_View.TabIndex = 379
        Me.cmd_View.Text = "View [F9]"
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdexport.BackgroundImage = CType(resources.GetObject("cmdexport.BackgroundImage"), System.Drawing.Image)
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Location = New System.Drawing.Point(800, 488)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(48, 32)
        Me.cmdexport.TabIndex = 433
        Me.cmdexport.Text = "Report[F12]"
        Me.cmdexport.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 20.0!, CType(((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic) _
                        Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(360, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(201, 34)
        Me.Label16.TabIndex = 436
        Me.Label16.Text = "HALL MASTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Grp_Print
        '
        Me.Grp_Print.BackColor = System.Drawing.Color.Transparent
        Me.Grp_Print.Controls.Add(Me.CMDEXIT)
        Me.Grp_Print.Controls.Add(Me.CMD_WINDOWS)
        Me.Grp_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Print.Location = New System.Drawing.Point(264, 504)
        Me.Grp_Print.Name = "Grp_Print"
        Me.Grp_Print.Size = New System.Drawing.Size(368, 56)
        Me.Grp_Print.TabIndex = 658
        Me.Grp_Print.TabStop = False
        Me.Grp_Print.Visible = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.CMDEXIT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.Location = New System.Drawing.Point(208, 16)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(96, 32)
        Me.CMDEXIT.TabIndex = 2
        Me.CMDEXIT.Text = "EXIT"
        '
        'CMD_WINDOWS
        '
        Me.CMD_WINDOWS.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
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
        Me.CMD_DOS.Location = New System.Drawing.Point(184, 528)
        Me.CMD_DOS.Name = "CMD_DOS"
        Me.CMD_DOS.Size = New System.Drawing.Size(40, 32)
        Me.CMD_DOS.TabIndex = 0
        Me.CMD_DOS.Text = "DOS"
        Me.CMD_DOS.Visible = False
        '
        'LST_TAX
        '
        Me.LST_TAX.Location = New System.Drawing.Point(712, 80)
        Me.LST_TAX.Name = "LST_TAX"
        Me.LST_TAX.Size = New System.Drawing.Size(208, 229)
        Me.LST_TAX.TabIndex = 659
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Courier New", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(712, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(136, 23)
        Me.Label17.TabIndex = 660
        Me.Label17.Text = "TAX APPLIES"
        '
        'ASCA_HALLMASTER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(944, 630)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.LST_TAX)
        Me.Controls.Add(Me.Grp_Print)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.lbl_freeze)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Txt_taxtype)
        Me.Controls.Add(Me.Txt_Loccode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Txt_Locdesc)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Txt_menuhead)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Txt_menurate)
        Me.Controls.Add(Me.cmd_Exit)
        Me.Controls.Add(Me.grp_StatusConversion4)
        Me.Controls.Add(Me.SSGRID)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdexport)
        Me.Controls.Add(Me.Cmd_Taxtype)
        Me.Controls.Add(Me.Cmd_Loccode)
        Me.Controls.Add(Me.CMD_DOS)
        Me.KeyPreview = True
        Me.Name = "ASCA_HALLMASTER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HALLMASTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp_StatusConversion4.ResumeLayout(False)
        Me.Grp_Print.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub checkvalidate()
        boolchk = False
        If Trim(txt_HallType.Text) = "" Then
            MessageBox.Show("Hall Type Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_HallType.Focus()
            Exit Sub
        End If
        If Trim(txt_feau.Text) = "" Then
            MessageBox.Show("Hall feature  Can't be blank Please enter", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_feau.Focus()
            Exit Sub
        End If
        'If Trim(Txt_taxtype.Text) = "" Then
        '    MessageBox.Show("Tax Type Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Txt_taxtype.Focus()
        '    Exit Sub
        'End If
        If Trim(Txt_Mincapacity.Text) = "" Then
            MessageBox.Show("Min Capacity Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_Mincapacity.Focus()
            Exit Sub
        End If
        If Trim(Txt_Rate.Text) = "" Then
            MessageBox.Show("Rate Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_Mincapacity.Focus()
            Exit Sub
        End If
        'If Trim(sec_dep.Text) = "" Then
        '    MessageBox.Show("Security Deposit Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    sec_dep.Focus()
        '    Exit Sub
        'End If
        '''LOGAN
        If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
            If Val(sec_dep.Text) < 1000 Then
                MsgBox("SECURITY DEPOSIT CAN'T ACCEPT LESS VALUE.......", MsgBoxStyle.OKOnly, "SECURITY DEPOSIT")
                sec_dep.Focus()
                Exit Sub
            End If

        Else

            'If Val(Txt_Rate.Text) > Val(sec_dep.Text) Then
            '    MsgBox("SECURITY DEPOSIT CAN'T ACCEPT LESS VALUE.......", MsgBoxStyle.OKOnly, "SECURITY DEPOSIT")
            '    sec_dep.Focus()
            '    Exit Sub
            'End If
        End If
        If Trim(Txt_MaxCapacity.Text) = "" Then
            MessageBox.Show("Max Capacity Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_MaxCapacity.Focus()
            Exit Sub
        End If
        If Trim(Txt_ActCapacity.Text) = "" Then
            MessageBox.Show("Act Capacity Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_ActCapacity.Focus()
            Exit Sub
        End If
        ''''''''''''LOGAN CHANGED ON 27-10-2012

        With SSGRID
            For i = 1 To .DataRowCnt
                .Col = 1
                .Row = i
                HALLTYPE = .Text

                .Col = 2
                .Row = i
                HALLCODE = .Text

                .Col = 3
                .Row = i
                HALLDESC = .Text

                .Col = 4
                .Row = i
                .Col = 5
                .Row = i
                If Val(.Text) = 1 Then

                    A = .Text
                Else
                    A = 0
                End If
                .Col = 6
                .Row = i
                If Val(.Text) = 1 Then
                    B = .Text
                Else
                    B = 0
                End If
                .Col = 7
                .Row = i
                If Val(.Text) = 1 Then
                    C = .Text
                Else
                    C = 0
                End If
                .Col = 8
                .Row = i
                If Val(.Text) = 1 Then
                    D = .Text
                Else
                    D = 0
                End If
                .Col = 9
                .Row = i
                If Val(.Text) = 1 Then
                    E = .Text
                Else
                    E = 0
                End If
                .Col = 10
                .Row = i
                If Val(.Text) = 1 Then
                    F = .Text
                Else
                    F = 0
                End If
                .Col = 11
                .Row = i
                If Val(.Text) = 1 Then
                    G = .Text
                Else
                    G = 0
                End If

                If Trim(HALLTYPE) = "" Or HALLCODE = "" Or HALLDESC = "" Then
                    If A = 1 Or B = 1 Or C = 1 Or D = 1 Or E = 1 Or F = 1 Or G = 1 Then
                        MessageBox.Show("PLEASE ENTER THE SESSION ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                End If
            Next
        End With

        '''''''''''''exit function 
        boolchk = True
    End Sub
    Private Sub CMD_Hallcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_Hallcode.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT isnull(HALLTYPEDESC,'') as HALLTYPEDESC,isnull(HALLTYPECODE,'') as HALLTYPECODE,ISNULL(RATE,0)AS RATE,ISNULL(LOCCODE,'') AS LOCCODE,ISNULL(LOCDESC,'') AS LOCDESC FROM PARTY_HALLMASTER_HDR"
        M_WhereCondition = " "
        vform.Field = "HALLTYPEDESC,HALLTYPECODE,RATE,LOCCODE,LOCDESC"
        vform.vFormatstring = "        Hall Type Description    |     Hall Type Code   |     HALL RENT     |     LOC CODE    |     LOC DESCRIPTION"
        vform.vCaption = "Hall Type Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.ShowDialog(Me)
        If Trim(vform.keyfield1 & "") <> "" Then
            txt_HallType.Text = Trim(vform.keyfield1 & "")
            Txt_HallTypedesc.Text = Trim(vform.keyfield & "")
            Txt_Rate.Text = Trim(vform.keyfield2)
            Call txt_HallType_Validated(txt_HallType, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_HallType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_HallType.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_HallType.Text) = "" Then
                Call CMD_Hallcode_Click(sender, e)
            Else
                Call txt_HallType_Validated(txt_HallType, e)
            End If
        End If
    End Sub
    Private Sub txt_HallType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_HallType.Validated
        If Trim(txt_HallType.Text) <> "" Then
            sqlstring = "SELECT * FROM PARTY_VIEW_HALLMASTER WHERE HALLTYPECODE='" & Trim(txt_HallType.Text) & "' and isnull(NETHALLAMOUNT,0) <> 0"
            'sqlstring = "SELECT * FROM PARTY_VIEW_HALLMASTER_DISPLAY WHERE HALLTYPECODE='" & Trim(txt_HallType.Text) & "' and ISNULL(NETHALLAMOUNT,'') = '" & Txt_Rate.Text & "' "

            gconn.getDataSet(sqlstring, "HALL")
            If gdataset.Tables("HALL").Rows.Count > 0 Then
                Txt_Loccode.Text = gdataset.Tables("HALL").Rows(0).Item("LOCCODE")
                Txt_Locdesc.Text = gdataset.Tables("HALL").Rows(0).Item("LOCDESC")
                Txt_HallTypedesc.Text = gdataset.Tables("HALL").Rows(0).Item("HALLTYPEDESC")
                Txt_Mincapacity.Text = gdataset.Tables("HALL").Rows(0).Item("MINCAPACITY")
                Txt_MaxCapacity.Text = gdataset.Tables("HALL").Rows(0).Item("MAXCAPACITY")
                Txt_ActCapacity.Text = gdataset.Tables("HALL").Rows(0).Item("ACTCAPACITY")

                Txt_taxtype.Text = gdataset.Tables("HALL").Rows(0).Item("TAXTYPE")
                Txt_Rate.Text = gdataset.Tables("HALL").Rows(0).Item("RATE")
                txt_rate1.Text = gdataset.Tables("HALL").Rows(0).Item("RATE1")
                Txt_menurate.Text = gdataset.Tables("HALL").Rows(0).Item("MENURATE")
                Txt_menuhead.Text = gdataset.Tables("HALL").Rows(0).Item("MENUHEADRATE")
                TXT_GLACCODE.Text = gdataset.Tables("HALL").Rows(0).Item("GLACCODE")
                sec_dep.Text = gdataset.Tables("HALL").Rows(0).Item("sedeposit")
                txt_feau.Text = gdataset.Tables("HALL").Rows(0).Item("feature")
                cmd_Add.Text = "Update[F7]"
                If gdataset.Tables("HALL").Rows(0).Item("FREEZE") = "Y" Then
                    lbl_freeze.Visible = True
                    txt_HallType.Enabled = False
                    CMD_Hallcode.Enabled = False
                    cmd_Add.Enabled = False
                    cmd_Freeze.Text = "UnFreeze[F8]"
                Else
                    cmd_Freeze.Text = "Freeze[F8]"
                    lbl_freeze.Visible = False
                    txt_HallType.Enabled = False
                    CMD_Hallcode.Enabled = False
                    cmd_Add.Enabled = True
                End If
                With SSGRID
                    For i = 0 To gdataset.Tables("HALL").Rows.Count - 1
                        .Col = 1
                        .Row = i + 1
                        .Text = gdataset.Tables("HALL").Rows(i).Item("PCODE")
                        .Col = 2
                        .Row = i + 1
                        .Text = gdataset.Tables("HALL").Rows(i).Item("PDESC")
                        .Col = 3
                        .Row = i + 1
                        .Text = gdataset.Tables("HALL").Rows(i).Item("FROMTIME")
                        .Col = 4
                        .Row = i + 1
                        .Text = gdataset.Tables("HALL").Rows(i).Item("TOTIME")
                        .Col = 5
                        .Row = i + 1
                        If Trim(gdataset.Tables("HALL").Rows(i).Item("SUN")) = "N" Then
                            .Text = 0
                        Else
                            .Text = 1
                        End If
                        .Col = 6
                        .Row = i + 1
                        If Trim(gdataset.Tables("HALL").Rows(i).Item("MON")) = "N" Then
                            .Text = 0
                        Else
                            .Text = 1
                        End If
                        .Col = 7
                        .Row = i + 1
                        If Trim(gdataset.Tables("HALL").Rows(i).Item("TUE")) = "N" Then
                            .Text = 0
                        Else
                            .Text = 1
                        End If
                        .Col = 8
                        .Row = i + 1
                        If Trim(gdataset.Tables("HALL").Rows(i).Item("WED")) = "N" Then
                            .Text = 0
                        Else
                            .Text = 1
                        End If
                        .Col = 9
                        .Row = i + 1
                        If Trim(gdataset.Tables("HALL").Rows(i).Item("THU")) = "N" Then
                            .Text = 0
                        Else
                            .Text = 1
                        End If
                        .Col = 10
                        .Row = i + 1
                        If Trim(gdataset.Tables("HALL").Rows(i).Item("FRI")) = "N" Then
                            .Text = 0
                        Else
                            .Text = 1
                        End If
                        .Col = 11
                        .Row = i + 1
                        If Trim(gdataset.Tables("HALL").Rows(i).Item("SAT")) = "N" Then
                            .Text = 0
                        Else
                            .Text = 1
                        End If
                    Next
                End With
                Txt_HallTypedesc.Focus()
            Else
                Txt_HallTypedesc.Focus()
                'Txt_Loccode.Focus()
            End If
        End If
        Dim j As Integer
            If txt_HallType.Text <> "" Then
                sqlstring = "select * from Party_Hallmaster_TAX where HALLTYPECODE='" & Trim(txt_HallType.Text) & "'  "
                gconnection.getDataSet(sqlstring, "TAXDET1")
                If gdataset.Tables("TAXDET1").Rows.Count > 0 Then
                    For i = 0 To gdataset.Tables("TAXDET1").Rows.Count - 1
                        For j = 0 To LST_TAX.Items.Count - 1
                            TempString = Split((LST_TAX.Items.Item(j)), "-->")
                            If Trim(gdataset.Tables("TAXDET1").Rows(i).Item("taxtype")) = TempString(0) Then
                                LST_TAX.SetItemChecked(j, True)
                            LST_TAX.SelectedItem = gdataset.Tables("TAXDET1").Rows(0).Item("taxtype")
                        End If
                    Next
                Next
            End If
            End If


    End Sub
    Private Sub cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Add.Click
        Dim INSERT(0) As String
        Dim ITEMTYPECODE() As String
        Call checkvalidate()
        If boolchk = False Then Exit Sub
        If Mid(cmd_Add.Text, 1, 1) = "A" Then
            '************************HDR INSERTION******************************
            sqlstring = "INSERT INTO PARTY_HALLMASTER_HDR (halltypecode,halltypedesc,loccode,locdesc,mincapacity,maxcapacity,actcapacity,rate,rate1,taxtype,"
            sqlstring = sqlstring & " menurate,menuheadrate,freeze,adduser,adddate,glaccode,sedeposit,feature) VALUES ("
            sqlstring = sqlstring & " '" & Trim(txt_HallType.Text) & "','" & Trim(Txt_HallTypedesc.Text) & "',"
            sqlstring = sqlstring & " '" & Trim(Txt_Loccode.Text) & "','" & Trim(Txt_Locdesc.Text) & "',"
            sqlstring = sqlstring & " " & Val(Txt_Mincapacity.Text) & "," & Val(Txt_MaxCapacity.Text) & ","
            sqlstring = sqlstring & " " & Val(Txt_ActCapacity.Text) & "," & Val(Txt_Rate.Text) & "," & Val(txt_rate1.Text) & ",'" & Trim(Txt_taxtype.Text) & "',"
            sqlstring = sqlstring & " " & Val(Txt_menurate.Text) & "," & Val(Txt_menuhead.Text) & ",'N','" & Trim(gUsername) & "',"
            sqlstring = sqlstring & " '" & Format(DateTime.Now, "dd/MMM/yyyy") & "','" & Trim(TXT_GLACCODE.Text) & "'," & Trim(sec_dep.Text) & ",'" & Trim(txt_feau.Text) & "')"

            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
            '=========================MULTIPLE TAX=====================================
            sqlstring = "DELETE FROM Party_Hallmaster_TAX WHERE halltypecode='" & Me.txt_HallType.Text & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
            For i = 0 To LST_TAX.CheckedItems.Count - 1
                sqlstring = "INSERT INTO Party_Hallmaster_TAX (halltypecode,halltypedesc,loccode,locdesc,mincapacity,maxcapacity,actcapacity,rate,rate1,taxtype,"
                sqlstring = sqlstring & " menurate,menuheadrate,freeze,adduser,adddate,glaccode,sedeposit) VALUES ("
                sqlstring = sqlstring & " '" & Trim(txt_HallType.Text) & "','" & Trim(Txt_HallTypedesc.Text) & "',"
                sqlstring = sqlstring & " '" & Trim(Txt_Loccode.Text) & "','" & Trim(Txt_Locdesc.Text) & "',"
                sqlstring = sqlstring & " " & Val(Txt_Mincapacity.Text) & "," & Val(Txt_MaxCapacity.Text) & ","
                sqlstring = sqlstring & " " & Val(Txt_ActCapacity.Text) & "," & Val(Txt_Rate.Text) & "," & Val(txt_rate1.Text) & ","
                ITEMTYPECODE = Split(LST_TAX.CheckedItems(i), "-->")
                sqlstring = sqlstring & "'" & ITEMTYPECODE(0)
                sqlstring = sqlstring & " '," & Val(Txt_menurate.Text) & "," & Val(Txt_menuhead.Text) & ",'N','" & Trim(gUsername) & "',"
                sqlstring = sqlstring & " '" & Format(DateTime.Now, "dd/MMM/yyyy") & "','" & Trim(TXT_GLACCODE.Text) & "','" & Trim(sec_dep.Text) & "')"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring
            Next
            '************************DETAIL INSERTION******************************
            With SSGRID
                For i = 1 To .DataRowCnt
                    sqlstring = "INSERT INTO PARTY_HALLMASTER_DET (halltypecode,Pcode,pdesc,fromtime,totime,sun,mon,tue,wed,thu,fri,sat,freeze,adduser,adddate)"
                    sqlstring = sqlstring & " VALUES('" & Trim(txt_HallType.Text) & "',"
                    .Col = 1
                    .Row = i
                    sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    .Col = 2
                    .Row = i
                    sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    .Col = 3
                    .Row = i
                    sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    .Col = 4
                    .Row = i
                    sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                    .Col = 5
                    .Row = i
                    If Val(.Text) = 1 Then
                        sqlstring = sqlstring & "'Y',"
                    Else
                        sqlstring = sqlstring & "'N',"
                    End If
                    .Col = 6
                    .Row = i
                    If Val(.Text) = 1 Then
                        sqlstring = sqlstring & "'Y',"
                    Else
                        sqlstring = sqlstring & "'N',"
                    End If
                    .Col = 7
                    .Row = i
                    If Val(.Text) = 1 Then
                        sqlstring = sqlstring & "'Y',"
                    Else
                        sqlstring = sqlstring & "'N',"
                    End If
                    .Col = 8
                    .Row = i
                    If Val(.Text) = 1 Then
                        sqlstring = sqlstring & "'Y',"
                    Else
                        sqlstring = sqlstring & "'N',"
                    End If
                    .Col = 9
                    .Row = i
                    If Val(.Text) = 1 Then
                        sqlstring = sqlstring & "'Y',"
                    Else
                        sqlstring = sqlstring & "'N',"
                    End If
                    .Col = 10
                    .Row = i
                    If Val(.Text) = 1 Then
                        sqlstring = sqlstring & "'Y',"
                    Else
                        sqlstring = sqlstring & "'N',"
                    End If
                    .Col = 11
                    .Row = i
                    If Val(.Text) = 1 Then
                        sqlstring = sqlstring & "'Y',"
                    Else
                        sqlstring = sqlstring & "'N',"
                    End If
                    sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "')"

                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = sqlstring
                Next
            End With


            gconn.MoreTrans(INSERT)
            Call cmd_Clear_Click(sender, e)
        ElseIf Mid(cmd_Add.Text, 1, 1) = "U" Then
                If lbl_freeze.Visible = True Then
                    MsgBox("Freezed Record Cannot Be Updated", MsgBoxStyle.Information)
                    Call cmd_Clear_Click(sender, e)
                    Exit Sub
                End If
                sqlstring = "SELECT * FROM PARTY_VIEW_HALLMASTER WHERE HALLTYPECODE='" & Trim(txt_HallType.Text) & "'"
                gconn.getDataSet(sqlstring, "HALLVIEW")
                If gdataset.Tables("HALLVIEW").Rows.Count > 0 Then
                    '************************HDR & DETAIL DELETION******************************
                    sqlstring = "DELETE FROM PARTY_HALLMASTER_DET WHERE HALLTYPECODE='" & Trim(txt_HallType.Text) & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = sqlstring

                    'sqlstring = "DELETE FROM PARTY_HALLMASTER_HDR WHERE HALLTYPECODE='" & Trim(txt_HallType.Text) & "'"
                    'ReDim Preserve INSERT(INSERT.Length)
                    'INSERT(INSERT.Length - 1) = sqlstring

                    '************************HDR INSERTION******************************
                    sqlstring = "UPDATE PARTY_HALLMASTER_HDR SET "
                    sqlstring = sqlstring & " glaccode='" & Trim(TXT_GLACCODE.Text) & "',LOCCODE='" & Trim(Txt_Loccode.Text) & "',LOCDESC='" & Trim(Txt_Locdesc.Text) & "',HALLTYPEDESC='" & Trim(Txt_HallTypedesc.Text) & "',"
                    sqlstring = sqlstring & " MINCAPACITY=" & Val(Txt_Mincapacity.Text) & ",MAXCAPACITY=" & Val(Txt_MaxCapacity.Text) & ","
                    sqlstring = sqlstring & " ACTCAPACITY=" & Val(Txt_ActCapacity.Text) & ",MENURATE=" & Val(Txt_menurate.Text) & ","
                sqlstring = sqlstring & " MENUHEADRATE=" & Val(Txt_menuhead.Text) & ",RATE=" & Val(Txt_Rate.Text) & ",RATE1=" & Val(txt_rate1.Text) & ","
                    sqlstring = sqlstring & " TAXTYPE='" & Trim(Txt_taxtype.Text) & "',FREEZE='N',ADDUSER='" & Trim(gUsername) & "',"
                sqlstring = sqlstring & " ADDDATE='" & Format(DateTime.Now, "dd/MMM/yyyy") & "',sedeposit='" & Trim(sec_dep.Text) & "',feature='" & Trim(txt_feau.Text) & "' WHERE HALLTYPECODE='" & Trim(txt_HallType.Text) & "'"

                    ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring
                '=========================MULTIPLE TAX=====================================
                sqlstring = "DELETE FROM Party_Hallmaster_TAX WHERE halltypecode='" & Me.txt_HallType.Text & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring
                For i = 0 To LST_TAX.CheckedItems.Count - 1
                    sqlstring = "INSERT INTO Party_Hallmaster_TAX (halltypecode,halltypedesc,loccode,locdesc,mincapacity,maxcapacity,actcapacity,rate,rate1,taxtype,"
                    sqlstring = sqlstring & " menurate,menuheadrate,freeze,adduser,adddate,glaccode,sedeposit) VALUES ("
                    sqlstring = sqlstring & " '" & Trim(txt_HallType.Text) & "','" & Trim(Txt_HallTypedesc.Text) & "',"
                    sqlstring = sqlstring & " '" & Trim(Txt_Loccode.Text) & "','" & Trim(Txt_Locdesc.Text) & "',"
                    sqlstring = sqlstring & " " & Val(Txt_Mincapacity.Text) & "," & Val(Txt_MaxCapacity.Text) & ","
                    sqlstring = sqlstring & " " & Val(Txt_ActCapacity.Text) & "," & Val(Txt_Rate.Text) & "," & Val(txt_rate1.Text) & ","
                    ITEMTYPECODE = Split(LST_TAX.CheckedItems(i), "-->")
                    sqlstring = sqlstring & "'" & ITEMTYPECODE(0)
                    sqlstring = sqlstring & " '," & Val(Txt_menurate.Text) & "," & Val(Txt_menuhead.Text) & ",'N','" & Trim(gUsername) & "',"
                    sqlstring = sqlstring & " '" & Format(DateTime.Now, "dd/MMM/yyyy") & "','" & Trim(TXT_GLACCODE.Text) & "','" & Trim(sec_dep.Text) & "')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = sqlstring
                Next
                '===========================================================================

                '************************DETAIL INSERTION******************************
                With SSGRID
                    For i = 1 To .DataRowCnt
                        sqlstring = "INSERT INTO PARTY_HALLMASTER_DET (halltypecode,Pcode,pdesc,fromtime,totime,sun,mon,tue,wed,thu,fri,sat,freeze,adduser,adddate)"
                        sqlstring = sqlstring & " VALUES('" & Trim(txt_HallType.Text) & "',"
                        .Col = 1
                        .Row = i
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 2
                        .Row = i
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 3
                        .Row = i
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 4
                        .Row = i
                        sqlstring = sqlstring & "'" & Trim(.Text) & "',"
                        .Col = 5
                        .Row = i
                        If Val(.Text) = 1 Then
                            sqlstring = sqlstring & "'Y',"
                        Else
                            sqlstring = sqlstring & "'N',"
                        End If
                        .Col = 6
                        .Row = i
                        If Val(.Text) = 1 Then
                            sqlstring = sqlstring & "'Y',"
                        Else
                            sqlstring = sqlstring & "'N',"
                        End If
                        .Col = 7
                        .Row = i
                        If Val(.Text) = 1 Then
                            sqlstring = sqlstring & "'Y',"
                        Else
                            sqlstring = sqlstring & "'N',"
                        End If
                        .Col = 8
                        .Row = i
                        If Val(.Text) = 1 Then
                            sqlstring = sqlstring & "'Y',"
                        Else
                            sqlstring = sqlstring & "'N',"
                        End If
                        .Col = 9
                        .Row = i
                        If Val(.Text) = 1 Then
                            sqlstring = sqlstring & "'Y',"
                        Else
                            sqlstring = sqlstring & "'N',"
                        End If
                        .Col = 10
                        .Row = i
                        If Val(.Text) = 1 Then
                            sqlstring = sqlstring & "'Y',"
                        Else
                            sqlstring = sqlstring & "'N',"
                        End If
                        .Col = 11
                        .Row = i
                        If Val(.Text) = 1 Then
                            sqlstring = sqlstring & "'Y',"
                        Else
                            sqlstring = sqlstring & "'N',"
                        End If
                        sqlstring = sqlstring & "'N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "')"

                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = sqlstring
                    Next
                End With
                gconn.MoreTrans(INSERT)
                Call cmd_Clear_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Clear.Click
        SSGRID.ClearRange(1, 1, -1, -1, True)
        txt_HallType.Text = ""
        Txt_HallTypedesc.Text = ""
        Txt_Loccode.Text = ""
        Txt_Locdesc.Text = ""
        Txt_Mincapacity.Text = ""
        Call FILLTAX()
        txt_feau.Text = ""
        Txt_MaxCapacity.Text = ""
        Txt_ActCapacity.Text = ""
        sec_dep.Text = ""
        Txt_menurate.Text = ""
        Txt_menuhead.Text = ""
        Txt_Rate.Text = ""
        TXT_GLACCODE.Text = ""
        Txt_taxtype.Text = ""
        cmd_Freeze.Text = "Freeze[F8]"
        cmd_Add.Text = "Add[F7]"
        lbl_freeze.Visible = False
        txt_HallType.Enabled = True
        CMD_Hallcode.Enabled = True
        txt_HallType.Focus()
        Show()
    End Sub
    Private Sub cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub Cmd_Loccode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Loccode.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT isnull(LOCDESC,'') as LOCDESC,isnull(LOCCODE,'') as LOCCODE FROM PARTY_LOCATIONMASTER"
        M_WhereCondition = " "
        vform.Field = "LOCDESC,LOCCODE"
        vform.vFormatstring = "        Location Description    |     Location Code    "
        vform.vCaption = "Location Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_Loccode.Text = Trim(vform.keyfield1 & "")
            Txt_Locdesc.Text = Trim(vform.keyfield & "")
            Txt_ActCapacity.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub Txt_Loccode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Loccode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Loccode.Text) <> "" Then
                Call Txt_Loccode_Validated(Txt_Loccode, e)
            Else
                Call Cmd_Loccode_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub Txt_Loccode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Loccode.Validated
        If Trim(Txt_Loccode.Text) <> "" Then
            sqlstring = "SELECT * FROM PARTY_LOCATIONMASTER WHERE LOCCODE='" & Trim(Txt_Loccode.Text) & "'"
            gconn.getDataSet(sqlstring, "LOC")
            If gdataset.Tables("LOC").Rows.Count > 0 Then
                Txt_Loccode.Text = gdataset.Tables("LOC").Rows(0).Item("LOCCODE")
                Txt_Locdesc.Text = gdataset.Tables("LOC").Rows(0).Item("LOCDESC")
                Txt_ActCapacity.Focus()
            Else
                Txt_Loccode.Text = ""
                Txt_Loccode.Focus()
            End If
        End If
    End Sub
    Private Sub Txt_Mincapacity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Mincapacity.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_Mincapacity.Text) > Val(Txt_MaxCapacity.Text) Or Val(Txt_Mincapacity.Text) > Val(Txt_ActCapacity.Text) Then
                MsgBox("Minimum Capacity Should not be greater than either Max.Capacity or Act.Capacity", MsgBoxStyle.Information)
                Txt_Mincapacity.Text = ""
                Txt_Mincapacity.Focus()
            Else
                Txt_Rate.Focus()
            End If
        End If
    End Sub
    Private Sub Txt_ActCapacity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ActCapacity.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_MaxCapacity.Focus()
        End If
    End Sub
    Private Sub Txt_MaxCapacity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_MaxCapacity.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Val(Txt_MaxCapacity.Text) < Val(Txt_ActCapacity.Text) Then
                MsgBox("Maximum Capacity Should not be greater than Act.Capacity", MsgBoxStyle.Information)
                Txt_MaxCapacity.Text = ""
                Txt_MaxCapacity.Focus()
            Else
                Txt_Mincapacity.Focus()
            End If
        End If
    End Sub
    Private Sub Txt_Rate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Rate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'Txt_menuhead.Focus()
            sec_dep.Focus()
        End If
    End Sub
    Private Sub Cmd_Taxtype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Taxtype.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT TAXDESC,TAXCODE,TAXPERCENTAGE,TYPEOFTAX FROM ACCOUNTSTAXMASTER"
        M_WhereCondition = " "
        vform.Field = "TAXDESC,TAXCODE,TAXPERCENTAGE,TYPEOFTAX"
        vform.vFormatstring = "        Tax Description    |     Tax Code    |    Tax percent  |    Type Of Tax  "
        vform.vCaption = "Tax Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_taxtype.Text = Trim(vform.keyfield1 & "")
            Txt_menurate.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub Txt_taxtype_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_taxtype.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_taxtype.Text) = "" Then
                Call Cmd_Taxtype_Click(sender, e)
            Else
                Call Txt_taxtype_Validated(Txt_taxtype, e)
            End If
        End If
    End Sub
    Private Sub Txt_taxtype_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_taxtype.Validated
        If Trim(Txt_taxtype.Text) <> "" Then
            sqlstring = "SELECT TAXDESC,TAXCODE,TAXPERCENTAGE,TYPEOFTAX FROM ACCOUNTSTAXMASTER WHERE TAXCODE="
            sqlstring = sqlstring & "'" & Trim(Txt_taxtype.Text) & "'"
            gconn.getDataSet(sqlstring, "TAX")
            If gdataset.Tables("TAX").Rows.Count > 0 Then
                Txt_taxtype.Text = gdataset.Tables("TAX").Rows(0).Item("TAXCODE")
                Txt_menurate.Focus()
            Else
                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                Txt_taxtype.Text = ""
                Txt_taxtype.Focus()
            End If
        End If
    End Sub
    Private Sub Txt_menurate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_menurate.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            sec_dep.Focus()
        End If
    End Sub
    Private Sub Txt_menuhead_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_menuhead.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_menurate.Focus()
        End If
    End Sub
    Private Sub fillpurpose()
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(PDESC,'')AS PDESC,ISNULL(PCODE,'')AS PCODE,ISNULL(FROMTIME,'')AS FROMTIME,ISNULL(TOTIME,'')AS TOTIME FROM PARTY_PURPOSEMASTER"
        M_WhereCondition = " WHERE ISNULL(FREEZE,'')<>'Y'"
        vform.Field = "PDESC,PCODE,FROMTIME,TOTIME"
        vform.vFormatstring = "        Purpose Description    |     Purpose Code   |  FROM TIME |  TO TIME  "
        vform.vCaption = "Purpose Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With SSGRID
                .Col = 1
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield1 & "")
                .Col = 2
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield)
                .Col = 3
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield2)
                .Col = 4
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield3)
                .SetActiveCell(5, .ActiveRow)
                .Focus()
            End With
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub SSGRID_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID.KeyDownEvent
        Dim pcode As String
        With SSGRID
            If e.keyCode = Keys.Enter Then
                i = .ActiveRow
                If .ActiveCol = 1 Then
                    .Col = 1
                    .Row = i
                    pcode = Trim(.Text)
                    If .Lock = False Then
                        If Trim(pcode) = "" Then
                            Call fillpurpose()
                        ElseIf Trim(pcode) <> "" Then
                            sqlstring = "SELECT ISNULL(PCODE,'')AS PCODE,ISNULL(PDESC,'')AS PDESC,ISNULL(FROMTIME,'')AS FROMTIME,"
                            sqlstring = sqlstring & "ISNULL(TOTIME,'')AS TOTIME FROM PARTY_PURPOSEMASTER WHERE PCODE='" & Trim(pcode) & "'"
                            gconn.getDataSet(sqlstring, "PURPOSE")
                            If gdataset.Tables("PURPOSE").Rows.Count > 0 Then
                                .Col = 2
                                .Row = i
                                .Text = gdataset.Tables("PURPOSE").Rows(0).Item("PDESC")
                                .Col = 3
                                .Row = i
                                .Text = gdataset.Tables("PURPOSE").Rows(0).Item("FROMTIME")
                                .Col = 4
                                .Row = i
                                .Text = gdataset.Tables("PURPOSE").Rows(0).Item("TOTIME")
                                .SetActiveCell(5, i)
                                .Focus()
                            Else
                                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                                .Col = 1
                                .Row = i
                                .Text = ""
                                .SetActiveCell(1, i)
                                .Focus()
                            End If
                        End If
                    End If
                ElseIf .ActiveCol = 5 Then
                    .SetActiveCell(6, i)
                    .Focus()
                ElseIf .ActiveCol = 6 Then
                    .SetActiveCell(7, i)
                    .Focus()
                ElseIf .ActiveCol = 7 Then
                    .SetActiveCell(8, i)
                    .Focus()
                ElseIf .ActiveCol = 8 Then
                    .SetActiveCell(9, i)
                    .Focus()
                ElseIf .ActiveCol = 9 Then
                    .SetActiveCell(10, i)
                    .Focus()
                ElseIf .ActiveCol = 10 Then
                    .SetActiveCell(11, i)
                    .Focus()
                ElseIf .ActiveCol = 11 Then
                    .SetActiveCell(1, i + 1)
                    .Focus()
                End If
            ElseIf e.keyCode = Keys.F3 Then
                .DeleteRows(.ActiveRow, 11)
                .SetActiveCell(1, .ActiveRow)
                .Focus()
            End If
        End With
    End Sub

    Private Sub txt_HallType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_HallType.TextChanged

    End Sub
    Private Sub ASCA_HALLMASTER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        SSGRID.ClearRange(1, 1, -1, -1, True)
        txt_HallType.Text = ""
        Txt_HallTypedesc.Text = ""
        Txt_Loccode.Text = ""
        Txt_Locdesc.Text = ""
        Txt_Mincapacity.Text = ""
        Txt_MaxCapacity.Text = ""
        Txt_ActCapacity.Text = ""
        Txt_menurate.Text = ""
        Txt_menuhead.Text = ""
        Txt_Rate.Text = ""
        Txt_taxtype.Text = ""
        cmd_Freeze.Text = "Freeze[F8]"
        cmd_Add.Text = "Add[F7]"
        lbl_freeze.Visible = False
        txt_HallType.Enabled = True
        CMD_Hallcode.Enabled = True
        txt_HallType.Focus()
        Call FILLTAX()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
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
        If txt_HallType.Text = "" Then
        Else
            sqlstring = "select * from Party_Hallmaster_TAX "
            gconnection.getDataSet(sqlstring, "TAXDET1")
            If gdataset.Tables("TAXDET1").Rows.Count > 0 Then
                For I = 0 To gdataset.Tables("TAXDET1").Rows.Count - 1
                    For j = 0 To LST_TAX.Items.Count - 1
                        TempString = Split((LST_TAX.Items.Item(j)), "-->")
                        If Trim(TempString(0)) = Trim(gdataset.Tables("TAXDET1").Rows(I).Item("taxtype")) Then
                            LST_TAX.SetItemChecked(j, True)
                            'Else
                            '    LST_TAX.SetItemChecked(j, False)
                        End If
                    Next


                Next
            End If
        End If
        
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
        Me.cmd_Add.Enabled = False
        ' Me.cmd_Delete.Enabled = False
        Me.cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.cmd_Add.Enabled = True
                    'Me.cmd_Delete.Enabled = True
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
                    'Me.cmd_Delete.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.cmd_View.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub ASCA_HALLMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call cmd_Clear_Click(cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then 'cmd_Freeze
            Call cmd_Add_Click(cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            Call cmd_Freeze_Click(cmd_Freeze, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 Then
            Call cmd_View_Click(cmd_View, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmd_Exit_Click(cmd_Exit, e)
            Exit Sub
        End If
    End Sub
    Private Sub cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_View.Click
        gPrint = False
        Grp_Print.Visible = True
    End Sub

    Private Sub Txt_HallTypedesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_HallTypedesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'Txt_Loccode.Focus()
            Txt_ActCapacity.Focus()
        End If
    End Sub
    Private Sub CMD_DOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_DOS.Click
        Dim i, j As Integer
        Dim Type() As String
        Dim tablename As String
        Dim STR As String
        Dim typename As String
        Dim heading As String
        heading = "HALL MASTER LIST"

        STR = "SELECT * FROM PARTY_VIEW_HALLHISTORY ORDER BY LOCCODE,HALLTYPECODE,PCODE "
        Call printdata(STR, heading, Format(Now, "dd-MMM-yyyy"), Format(Now, "dd-MMM-yyyy"))
        Grp_Print.Visible = False
    End Sub
    Public Function printdata(ByVal SQLSTRING As String, ByVal heading As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim docdate As Date
        Dim DOCNO As Integer
        Dim boolPosdesc, boolgroupdesc, boolItemcode As Boolean
        Dim GroupDesc, POSdesc, Itemdesc, Itemcode, SSQL, compcode As String
        Dim LocItemcount, LocationTotal, GroupItemcount, GrandItemcount, GroupTotal, GrandTotal As Double
        Dim location, hall As String
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
            If gdataset.Tables("roomcompanymasterhistory").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                For Each dr In gdataset.Tables("roomcompanymasterhistory").Rows
                    If pagesize > 58 Then
                        Filewrite.WriteLine(StrDup(89, "="))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(heading, mskfromdate, msktodate)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If

                    If location <> dr("loccode") Then
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                        Filewrite.WriteLine(Mid(Trim(dr("LOCDESC")), 1, 20) & Space(20 - Len(Mid(Trim(dr("LOCDESC")), 1, 20))))
                        pagesize = pagesize + 1
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If

                    If hall <> dr("halltypecode") Then
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                        SSQL = Mid(Trim(dr("HALLTYPECODE")), 1, 5) & Space(5 - Len(Mid(Trim(dr("HALLTYPECODE")), 1, 5)))
                        SSQL = SSQL & Space(1) & Mid(Trim(dr("HALLTYPEDESC")), 1, 20) & Space(20 - Len(Mid(Trim(dr("HALLTYPEDESC")), 1, 20)))
                        SSQL = SSQL & Space(1) & Space(5 - Len(Mid(Format(dr("mincapacity"), "0"), 1, 5))) & Mid(Format(dr("mincapacity"), "0"), 1, 5)
                        SSQL = SSQL & Space(1) & Space(5 - Len(Mid(Format(dr("maxcapacity"), "0"), 1, 5))) & Mid(Format(dr("maxcapacity"), "0"), 1, 5)
                        SSQL = SSQL & Space(1) & Space(5 - Len(Mid(Format(dr("actcapacity"), "0"), 1, 5))) & Mid(Format(dr("actcapacity"), "0"), 1, 5)
                        SSQL = SSQL & Space(1) & Space(8 - Len(Mid(Format(dr("RATE"), "0.00"), 1, 8))) & Mid(Format(dr("RATE"), "0.00"), 1, 8)
                        SSQL = SSQL & Space(1) & Mid(Trim(dr("TAXTYPE")), 1, 10) & Space(10 - Len(Mid(Trim(dr("TAXTYPE")), 1, 10)))
                        SSQL = SSQL & Space(1) & Space(8 - Len(Mid(Format(dr("MENURATE"), "0.00"), 1, 8))) & Mid(Format(dr("MENURATE"), "0.00"), 1, 8)
                        SSQL = SSQL & Space(1) & Space(8 - Len(Mid(Format(dr("MENUHEADRATE"), "0.00"), 1, 8))) & Mid(Format(dr("MENUHEADRATE"), "0.00"), 1, 8)

                        Filewrite.WriteLine(SSQL)
                        pagesize = pagesize + 1
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    location = dr("LOCCODE")
                    hall = dr("HALLTYPECODE")

                    SSQL = Space(10 - Len(Mid(Format(dr("PCODE"), ""), 1, 10))) & Mid(Format(dr("PCODE"), ""), 1, 10)
                    SSQL = SSQL & Space(1) & Space(20 - Len(Mid(Format(dr("PDESC"), ""), 1, 20))) & Mid(Format(dr("PDESC"), ""), 1, 20)
                    SSQL = SSQL & Space(1) & Space(11 - Len(Mid(Format(dr("FROMtime"), "0"), 1, 11))) & Mid(Format(dr("FROMTIME"), "0"), 1, 11)
                    SSQL = SSQL & Space(1) & Space(10 - Len(Mid(Format(dr("TOTIME"), "0"), 1, 10))) & Mid(Format(dr("TOTIME"), "0"), 1, 10)
                    SSQL = SSQL & Space(1) & Space(3 - Len(Mid(Format(dr("SUN"), ""), 1, 3))) & Mid(Format(dr("SUN"), ""), 1, 3)
                    SSQL = SSQL & Space(1) & Space(3 - Len(Mid(Format(dr("MON"), ""), 1, 3))) & Mid(Format(dr("MON"), ""), 1, 3)
                    SSQL = SSQL & Space(1) & Space(3 - Len(Mid(Format(dr("TUE"), ""), 1, 3))) & Mid(Format(dr("TUE"), ""), 1, 3)
                    SSQL = SSQL & Space(1) & Space(3 - Len(Mid(Format(dr("WED"), ""), 1, 3))) & Mid(Format(dr("WED"), ""), 1, 3)
                    SSQL = SSQL & Space(1) & Space(3 - Len(Mid(Format(dr("THU"), ""), 1, 3))) & Mid(Format(dr("THU"), ""), 1, 3)
                    SSQL = SSQL & Space(1) & Space(3 - Len(Mid(Format(dr("FRI"), ""), 1, 3))) & Mid(Format(dr("FRI"), ""), 1, 3)
                    SSQL = SSQL & Space(1) & Space(3 - Len(Mid(Format(dr("SAT"), ""), 1, 3))) & Mid(Format(dr("SAT"), ""), 1, 3)

                    Filewrite.WriteLine(SSQL)
                    pagesize = pagesize + 1
                Next
                Filewrite.WriteLine(StrDup(89, "="))
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
            Filewrite.WriteLine(StrDup(89, "="))
            pagesize = pagesize + 1
            Filewrite.WriteLine("HALL DETAILS                 MIN  SITING MAX   CHARGE TAX      Additional    Head Limit")
            Filewrite.WriteLine("                             NOS   NOS    NOS   Rs.   CODE     Cahrge  %       %")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(89, "="))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    Private Sub CMD_PRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_PRINT.Click
        gPrint = True
        Grp_Print.Visible = True
    End Sub
    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Grp_Print.Visible = False
    End Sub
    Private Sub CMD_WINDOWS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_WINDOWS.Click
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r As New RPT_MAS_HALLHISTORY
        str = " SELECT * FROM PARTY_VIEW_HALLHISTORY ORDER BY LOCCODE,HALLTYPECODE,PCODE "
        Viewer.ssql = str
        Viewer.Report = r

        Viewer.TableName = "PARTY_VIEW_HALLHISTORY"
        Dim textobj1 As TextObject
        textobj1 = r.ReportDefinition.ReportObjects("Text3")
        textobj1.Text = MyCompanyName
        Dim TXTOBJ2 As TextObject
        TXTOBJ2 = r.ReportDefinition.ReportObjects("Text1")
        TXTOBJ2.Text = gUsername
        '        Dim TXTOBJ3 As TextObject
        '       TXTOBJ3 = r.ReportDefinition.ReportObjects("Text38")
        '      TXTOBJ3.Text = Trim(txt_HallType.Text)
        Viewer.Show()
    End Sub
    Private Sub CMD_GLACCODE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_GLACCODE.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(ACCODE,'') AS ACCODE,ISNULL(ACDESC,'') AS ACDESC FROM Accountsglaccountmaster  "
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = " WHERE ISNULL(freezeflag,'') <> 'Y'"
        End If
        vform.Field = "ACCODE,ACDESC"
        vform.vFormatstring = "             ACCOUNT CODE                |              ACCOUNT DESCRIPTION                             "
        vform.vCaption = "ACCOUNT MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXT_GLACCODE.Text = Trim(vform.keyfield & "")
            SSGRID.SetActiveCell(1, 1)
            SSGRID.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub TXT_GLACCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_GLACCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXT_GLACCODE.Text) = "" Then
                Call CMD_GLACCODE_Click(sender, e)
            End If
            txt_feau.Focus()
          
            'sec_dep.Focus()
        End If
    End Sub

    Private Sub Txt_menuhead_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_menuhead.TextChanged

    End Sub

    Private Sub TXT_GLACCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_GLACCODE.TextChanged

    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "PARTY_VIEW_HALLHISTORY"
        sqlstring = " SELECT * FROM PARTY_VIEW_HALLHISTORY ORDER BY LOCCODE,HALLTYPECODE,PCODE "
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Freeze.Click
        'Call checkValidation() ''-->Check Validation
        Call checkvalidate()
        If boolchk = False Then Exit Sub
        If Mid(cmd_Freeze.Text, 1, 1) = "F" Then
            sqlstring = "SELECT ISNULL(PCODE,'')AS PCODE,ISNULL(PDESC,'')AS PDESC FROM PARTY_HALLMASTER_DET"
            sqlstring = sqlstring & " WHERE ISNULL(PCODE,'')='" & Trim(txt_HallType.Text) & "'"
            gconn.getDataSet(sqlstring, "GRP1")
            If Mid(Me.cmd_Freeze.Text, 1, 1) = "F" Then
                sqlstring = "UPDATE PARTY_HALLMASTER_DET SET FREEZE='Y',"
                sqlstring = sqlstring & " ADDUSER='" & Trim(gUsername) & "',ADDDATE='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' "
                sqlstring = sqlstring & " WHERE HALLTYPECODE='" & Trim(txt_HallType.Text) & "'"
                gconn.dataOperation(3, sqlstring, "GRP1")
                Call cmd_Clear_Click(sender, e)
            End If
        ElseIf Mid(cmd_Freeze.Text, 1, 1) = "U" Then
            sqlstring = "UPDATE PARTY_HALLMASTER_DET SET FREEZE='N',"
            sqlstring = sqlstring & " ADDUSER='" & Trim(gUsername) & "',ADDDATE='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' "
            sqlstring = sqlstring & " WHERE HALLTYPECODE='" & Trim(txt_HallType.Text) & "'"
            gconn.dataOperation(4, sqlstring, "GRP1")
            Call cmd_Clear_Click(sender, e)
        End If
        'If boolchk = False Then Exit Sub
        'If Mid(Me.cmd_Freeze.Text, 1, 1) = "F" Then
        '    sqlstring = "UPDATE  PARTY_HALLMASTER_DET "
        '    sqlstring = sqlstring & " SET Freeze= 'Y',AddUser='" & gUsername & " ', AddDate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
        '    sqlstring = sqlstring & " WHERE HALLTYPECODE = '" & Trim(txt_HallType.Text) & "'"
        '    gconn.dataOperation(3, sqlstring, "PARTY_HALLMASTER_DET")
        '    Me.cmd_Clear_Click(sender, e)
        '    cmd_Add.Text = "Add [F7]"
        'Else
        '    sqlstring = "UPDATE  PARTY_HALLMASTER_DET "
        '    sqlstring = sqlstring & " SET Freeze= 'N',AddUser='" & gUsername & " ', AddDate='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
        '    sqlstring = sqlstring & " WHERE HALLTYPECODE = '" & Trim(txt_HallType.Text) & "'"
        '    gconn.dataOperation(4, sqlstring, "PARTY_HALLMASTER_DET")
        '    Me.cmd_Clear_Click(sender, e)
        '    cmd_Add.Text = "Add [F7]"

    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  Store Code Can't be blank *********************'''
        If Trim(txt_HallType.Text) = "" Then
            MessageBox.Show(" HALLTYPE Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_HallType.Focus()
            Exit Sub
        End If
        '''********** Check  Store desc Can't be blank *********************'''
        If Trim(txt_HallType.Text) = "" Then
            MessageBox.Show(" HALLTYPE Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txt_HallType.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub

    Private Sub Txt_HallTypedesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_HallTypedesc.TextChanged

    End Sub

    Private Sub Txt_Loccode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Loccode.TextChanged

    End Sub

    Private Sub sec_dep_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sec_dep.TextChanged

    End Sub

    Private Sub sec_dep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles sec_dep.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            TXT_GLACCODE.Focus()
        End If


    End Sub

    Private Sub Txt_ActCapacity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ActCapacity.TextChanged

    End Sub

    Private Sub Txt_menurate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_menurate.TextChanged

    End Sub

    Private Sub Txt_Rate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Rate.TextChanged

    End Sub

    Private Sub txt_feau_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_feau.TextChanged

    End Sub

    Private Sub txt_feau_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_feau.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SSGRID.SetActiveCell(1, 1)
            SSGRID.Focus()
        End If
    End Sub

    Private Sub SSGRID_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSGRID.Advance

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class
