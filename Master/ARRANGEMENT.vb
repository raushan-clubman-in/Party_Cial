Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.OleDb
Imports System.IO
Public Class ARRANGEMENT
    Inherits System.Windows.Forms.Form
    Dim boolchk As Boolean
    Dim vseqno As Double
    Dim sqlstring As String
    Dim gconnection, vconn As New GlobalClass
    Dim TempString(3) As String
    Dim I, J, K As Integer
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
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents cbxcategory As System.Windows.Forms.ComboBox
    Friend WithEvents txtarrdesc As System.Windows.Forms.TextBox
    Friend WithEvents txtarrcode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TXTUOM As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents cmdarrCodehelp As System.Windows.Forms.Button
    Friend WithEvents cmduomhelp As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtItemType As System.Windows.Forms.TextBox
    Friend WithEvents txtTypedes As System.Windows.Forms.TextBox
    Friend WithEvents cmdType As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTRATE As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmd_print As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTCGROUPCODE As System.Windows.Forms.TextBox
    Friend WithEvents TXTCGROUPDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CGROUPHELP As System.Windows.Forms.Button
    Friend WithEvents CMD_GLACCODE As System.Windows.Forms.Button
    Friend WithEvents TXT_GLACCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents OptNo As System.Windows.Forms.RadioButton
    Friend WithEvents optYes As System.Windows.Forms.RadioButton
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents LST_TAX As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ARRANGEMENT))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.OptNo = New System.Windows.Forms.RadioButton
        Me.optYes = New System.Windows.Forms.RadioButton
        Me.CMD_GLACCODE = New System.Windows.Forms.Button
        Me.TXT_GLACCODE = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TXTRATE = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmduomhelp = New System.Windows.Forms.Button
        Me.TXTUOM = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread
        Me.cbxcategory = New System.Windows.Forms.ComboBox
        Me.cmdarrCodehelp = New System.Windows.Forms.Button
        Me.txtarrdesc = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtarrcode = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtItemType = New System.Windows.Forms.TextBox
        Me.txtTypedes = New System.Windows.Forms.TextBox
        Me.cmdType = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TXTCGROUPCODE = New System.Windows.Forms.TextBox
        Me.CGROUPHELP = New System.Windows.Forms.Button
        Me.TXTCGROUPDESC = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.Cmd_View = New System.Windows.Forms.Button
        Me.Cmd_Freeze = New System.Windows.Forms.Button
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.cmd_print = New System.Windows.Forms.Button
        Me.cmdexport = New System.Windows.Forms.Button
        Me.lbl_Freeze = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.LST_TAX = New System.Windows.Forms.CheckedListBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.CMD_GLACCODE)
        Me.GroupBox1.Controls.Add(Me.TXT_GLACCODE)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TXTRATE)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmduomhelp)
        Me.GroupBox1.Controls.Add(Me.TXTUOM)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ssgrid)
        Me.GroupBox1.Controls.Add(Me.cbxcategory)
        Me.GroupBox1.Controls.Add(Me.cmdarrCodehelp)
        Me.GroupBox1.Controls.Add(Me.txtarrdesc)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtarrcode)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(696, 168)
        Me.GroupBox1.TabIndex = 384
        Me.GroupBox1.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.OptNo)
        Me.GroupBox3.Controls.Add(Me.optYes)
        Me.GroupBox3.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(592, 152)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(80, 32)
        Me.GroupBox3.TabIndex = 459
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
        'CMD_GLACCODE
        '
        Me.CMD_GLACCODE.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CMD_GLACCODE.Image = CType(resources.GetObject("CMD_GLACCODE.Image"), System.Drawing.Image)
        Me.CMD_GLACCODE.Location = New System.Drawing.Point(560, 120)
        Me.CMD_GLACCODE.Name = "CMD_GLACCODE"
        Me.CMD_GLACCODE.Size = New System.Drawing.Size(24, 24)
        Me.CMD_GLACCODE.TabIndex = 454
        '
        'TXT_GLACCODE
        '
        Me.TXT_GLACCODE.BackColor = System.Drawing.Color.AntiqueWhite
        Me.TXT_GLACCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_GLACCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_GLACCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_GLACCODE.Location = New System.Drawing.Point(480, 120)
        Me.TXT_GLACCODE.MaxLength = 50
        Me.TXT_GLACCODE.Name = "TXT_GLACCODE"
        Me.TXT_GLACCODE.Size = New System.Drawing.Size(80, 21)
        Me.TXT_GLACCODE.TabIndex = 452
        Me.TXT_GLACCODE.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(336, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 21)
        Me.Label10.TabIndex = 453
        Me.Label10.Text = "GL Account Code"
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.Wheat
        Me.TXTRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRATE.Location = New System.Drawing.Point(168, 120)
        Me.TXTRATE.MaxLength = 7
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(136, 26)
        Me.TXTRATE.TabIndex = 12
        Me.TXTRATE.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(8, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 25)
        Me.Label4.TabIndex = 377
        Me.Label4.Text = "RATE"
        '
        'cmduomhelp
        '
        Me.cmduomhelp.Image = CType(resources.GetObject("cmduomhelp.Image"), System.Drawing.Image)
        Me.cmduomhelp.Location = New System.Drawing.Point(304, 72)
        Me.cmduomhelp.Name = "cmduomhelp"
        Me.cmduomhelp.Size = New System.Drawing.Size(23, 26)
        Me.cmduomhelp.TabIndex = 4
        '
        'TXTUOM
        '
        Me.TXTUOM.BackColor = System.Drawing.Color.Wheat
        Me.TXTUOM.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUOM.Location = New System.Drawing.Point(168, 72)
        Me.TXTUOM.MaxLength = 7
        Me.TXTUOM.Name = "TXTUOM"
        Me.TXTUOM.ReadOnly = True
        Me.TXTUOM.Size = New System.Drawing.Size(136, 26)
        Me.TXTUOM.TabIndex = 3
        Me.TXTUOM.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(8, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 25)
        Me.Label3.TabIndex = 374
        Me.Label3.Text = "UOM"
        '
        'ssgrid
        '
        Me.ssgrid.ContainingControl = Me
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(3, 288)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(853, 16)
        Me.ssgrid.TabIndex = 13
        Me.ssgrid.Visible = False
        '
        'cbxcategory
        '
        Me.cbxcategory.BackColor = System.Drawing.Color.Wheat
        Me.cbxcategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxcategory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxcategory.Items.AddRange(New Object() {"SELF", "OTHERS"})
        Me.cbxcategory.Location = New System.Drawing.Point(480, 72)
        Me.cbxcategory.Name = "cbxcategory"
        Me.cbxcategory.Size = New System.Drawing.Size(192, 28)
        Me.cbxcategory.TabIndex = 5
        '
        'cmdarrCodehelp
        '
        Me.cmdarrCodehelp.Image = CType(resources.GetObject("cmdarrCodehelp.Image"), System.Drawing.Image)
        Me.cmdarrCodehelp.Location = New System.Drawing.Point(304, 32)
        Me.cmdarrCodehelp.Name = "cmdarrCodehelp"
        Me.cmdarrCodehelp.Size = New System.Drawing.Size(23, 26)
        Me.cmdarrCodehelp.TabIndex = 1
        '
        'txtarrdesc
        '
        Me.txtarrdesc.BackColor = System.Drawing.Color.Wheat
        Me.txtarrdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtarrdesc.Location = New System.Drawing.Point(480, 32)
        Me.txtarrdesc.MaxLength = 50
        Me.txtarrdesc.Name = "txtarrdesc"
        Me.txtarrdesc.Size = New System.Drawing.Size(192, 26)
        Me.txtarrdesc.TabIndex = 2
        Me.txtarrdesc.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(8, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(148, 25)
        Me.Label9.TabIndex = 368
        Me.Label9.Text = "ARRANGE CODE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(336, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 25)
        Me.Label5.TabIndex = 367
        Me.Label5.Text = "DESCRIPTION"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(336, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 25)
        Me.Label2.TabIndex = 367
        Me.Label2.Text = "CATEGORY"
        '
        'txtarrcode
        '
        Me.txtarrcode.BackColor = System.Drawing.Color.Wheat
        Me.txtarrcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtarrcode.Location = New System.Drawing.Point(168, 32)
        Me.txtarrcode.MaxLength = 15
        Me.txtarrcode.Name = "txtarrcode"
        Me.txtarrcode.Size = New System.Drawing.Size(136, 26)
        Me.txtarrcode.TabIndex = 0
        Me.txtarrcode.Text = ""
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(8, 488)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 25)
        Me.Label11.TabIndex = 400
        Me.Label11.Text = "TAX TYPE "
        Me.Label11.Visible = False
        '
        'txtItemType
        '
        Me.txtItemType.BackColor = System.Drawing.Color.Wheat
        Me.txtItemType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemType.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemType.Location = New System.Drawing.Point(176, 496)
        Me.txtItemType.MaxLength = 10
        Me.txtItemType.Name = "txtItemType"
        Me.txtItemType.Size = New System.Drawing.Size(136, 26)
        Me.txtItemType.TabIndex = 6
        Me.txtItemType.Text = ""
        Me.txtItemType.Visible = False
        '
        'txtTypedes
        '
        Me.txtTypedes.BackColor = System.Drawing.Color.Wheat
        Me.txtTypedes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTypedes.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTypedes.Location = New System.Drawing.Point(488, 496)
        Me.txtTypedes.MaxLength = 50
        Me.txtTypedes.Name = "txtTypedes"
        Me.txtTypedes.ReadOnly = True
        Me.txtTypedes.Size = New System.Drawing.Size(192, 26)
        Me.txtTypedes.TabIndex = 8
        Me.txtTypedes.Text = ""
        Me.txtTypedes.Visible = False
        '
        'cmdType
        '
        Me.cmdType.Image = CType(resources.GetObject("cmdType.Image"), System.Drawing.Image)
        Me.cmdType.Location = New System.Drawing.Point(304, 488)
        Me.cmdType.Name = "cmdType"
        Me.cmdType.Size = New System.Drawing.Size(23, 26)
        Me.cmdType.TabIndex = 7
        Me.cmdType.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(336, 488)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 25)
        Me.Label7.TabIndex = 401
        Me.Label7.Text = "DESCRIPTION "
        Me.Label7.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(168, 432)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 25)
        Me.Label6.TabIndex = 400
        Me.Label6.Text = "G.CODE"
        Me.Label6.Visible = False
        '
        'TXTCGROUPCODE
        '
        Me.TXTCGROUPCODE.BackColor = System.Drawing.Color.Wheat
        Me.TXTCGROUPCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCGROUPCODE.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCGROUPCODE.Location = New System.Drawing.Point(208, 464)
        Me.TXTCGROUPCODE.MaxLength = 10
        Me.TXTCGROUPCODE.Name = "TXTCGROUPCODE"
        Me.TXTCGROUPCODE.Size = New System.Drawing.Size(32, 26)
        Me.TXTCGROUPCODE.TabIndex = 9
        Me.TXTCGROUPCODE.Text = ""
        Me.TXTCGROUPCODE.Visible = False
        '
        'CGROUPHELP
        '
        Me.CGROUPHELP.Image = CType(resources.GetObject("CGROUPHELP.Image"), System.Drawing.Image)
        Me.CGROUPHELP.Location = New System.Drawing.Point(240, 464)
        Me.CGROUPHELP.Name = "CGROUPHELP"
        Me.CGROUPHELP.Size = New System.Drawing.Size(23, 26)
        Me.CGROUPHELP.TabIndex = 10
        Me.CGROUPHELP.Visible = False
        '
        'TXTCGROUPDESC
        '
        Me.TXTCGROUPDESC.BackColor = System.Drawing.Color.Wheat
        Me.TXTCGROUPDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCGROUPDESC.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCGROUPDESC.Location = New System.Drawing.Point(168, 464)
        Me.TXTCGROUPDESC.MaxLength = 50
        Me.TXTCGROUPDESC.Name = "TXTCGROUPDESC"
        Me.TXTCGROUPDESC.ReadOnly = True
        Me.TXTCGROUPDESC.Size = New System.Drawing.Size(34, 26)
        Me.TXTCGROUPDESC.TabIndex = 11
        Me.TXTCGROUPDESC.Text = ""
        Me.TXTCGROUPDESC.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(24, 456)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 25)
        Me.Label8.TabIndex = 401
        Me.Label8.Text = "DESCRIPTION "
        Me.Label8.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 296)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(696, 56)
        Me.GroupBox2.TabIndex = 386
        Me.GroupBox2.TabStop = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.Location = New System.Drawing.Point(16, 16)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear.TabIndex = 15
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(424, 16)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 17
        Me.Cmd_View.Text = "Report[F9]"
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.Location = New System.Drawing.Point(288, 16)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze.TabIndex = 16
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.Location = New System.Drawing.Point(152, 16)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add.TabIndex = 14
        Me.Cmd_Add.Text = "Add [F7]"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.Location = New System.Drawing.Point(568, 16)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 19
        Me.Cmd_Exit.Text = "Exit[F11]"
        '
        'cmd_print
        '
        Me.cmd_print.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_print.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_print.ForeColor = System.Drawing.Color.White
        Me.cmd_print.Image = CType(resources.GetObject("cmd_print.Image"), System.Drawing.Image)
        Me.cmd_print.Location = New System.Drawing.Point(736, 456)
        Me.cmd_print.Name = "cmd_print"
        Me.cmd_print.Size = New System.Drawing.Size(104, 32)
        Me.cmd_print.TabIndex = 18
        Me.cmd_print.Text = "Print[F10]"
        Me.cmd_print.Visible = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdexport.BackgroundImage = CType(resources.GetObject("cmdexport.BackgroundImage"), System.Drawing.Image)
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Location = New System.Drawing.Point(872, 456)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(56, 32)
        Me.cmdexport.TabIndex = 435
        Me.cmdexport.Text = "Report[F12]"
        Me.cmdexport.Visible = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(248, 264)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(173, 25)
        Me.lbl_Freeze.TabIndex = 387
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(184, 376)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(383, 18)
        Me.Label1.TabIndex = 418
        Me.Label1.Text = "Press F4 for HELP / Press ENTER key to navigate"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(272, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(398, 31)
        Me.Label16.TabIndex = 436
        Me.Label16.Text = "ARRANGEMENT ITEM  MASTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LST_TAX
        '
        Me.LST_TAX.Location = New System.Drawing.Point(720, 80)
        Me.LST_TAX.Name = "LST_TAX"
        Me.LST_TAX.Size = New System.Drawing.Size(232, 292)
        Me.LST_TAX.TabIndex = 660
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Courier New", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(728, 56)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(136, 23)
        Me.Label17.TabIndex = 661
        Me.Label17.Text = "TAX APPLIES"
        '
        'ARRANGEMENT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(976, 526)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.LST_TAX)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TXTCGROUPCODE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXTCGROUPDESC)
        Me.Controls.Add(Me.txtTypedes)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtItemType)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CGROUPHELP)
        Me.Controls.Add(Me.cmdexport)
        Me.Controls.Add(Me.cmdType)
        Me.Controls.Add(Me.cmd_print)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "ARRANGEMENT"
        Me.Text = "ARRANGEMENT MASTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strsql, UOMCODE, Insert(0), ITEMTYPECODE(), SQL1 As String
        Dim Pname, Add1, Add2, Add3, Phoneno As String
        Dim Rate As Integer
        Dim dt As New DataTable
        strsql = "select isnull(uomcode,'') as uomcode from uommaster where uomdesc='" & Trim(TXTUOM.Text) & "'"
        dt = gconnection.GetValues(strsql)
        If dt.Rows.Count > 0 Then
            UOMCODE = dt.Rows(0).Item("uomcode")
        Else
            UOMCODE = ""
        End If

        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            vseqno = GetSeqno(txtarrcode.Text)
            strsql = "INSERT INTO PARTY_ARRANGEMASTER_HDR(GLACCODE,ARRCODE,ARRDESCRIPTION,UOM,RATE,ITEMTYPECODE,CGROUPCODE,CATEGORY,FREEZE,SBFCHARGE,"
            strsql = strsql & "adduserid,adddatetime)"
            strsql = strsql & " VALUES ( '" & Trim(TXT_GLACCODE.Text) & "','" & Trim(txtarrcode.Text) & "','" & Trim(txtarrdesc.Text) & "'"
            strsql = strsql & ",'" & UOMCODE & "'," & TXTRATE.Text & ",'" & txtItemType.Text & "','" & TXTCGROUPCODE.Text & "'"
            strsql = strsql & ",'" & cbxcategory.Text & "','N'"
            If optYes.Checked = True Then
                strsql = strsql & " ,'Y'"
            Else
                strsql = strsql & " ,'N'"
            End If
            strsql = strsql & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            Insert(0) = strsql
            With ssgrid
                For I = 1 To ssgrid.DataRowCnt
                    Pname = "" : Add1 = "" : Add2 = "" : Add3 = "" : Phoneno = "" : Rate = 0
                    .Row = I
                    .Col = 1
                    Pname = Trim(.Text)
                    .Row = I
                    .Col = 2
                    Add1 = Trim(.Text)
                    .Row = I
                    .Col = 3
                    Add2 = Trim(.Text)
                    .Row = I
                    .Col = 4
                    Add3 = Trim(.Text)
                    .Row = I
                    .Col = 5
                    Phoneno = Trim(.Text)
                    .Row = I
                    .Col = 6
                    Rate = IIf(Len(Trim(.Text)) > 0, Format(Val(.Text), "0.00"), 0)
                    sqlstring = "Insert Into PARTY_ARRANGEMASTER_DET(Arrcode,Pname,Add1,add2,Add3,phoneno,Rate,"
                    sqlstring = sqlstring & "Freeze,Adduserid,Adddatetime)"
                    sqlstring = sqlstring & " values('" & Trim(txtarrcode.Text) & "',"
                    sqlstring = sqlstring & " '" & Pname & "',"
                    sqlstring = sqlstring & " '" & Add1 & "',"
                    sqlstring = sqlstring & " '" & Add2 & "',"
                    sqlstring = sqlstring & " '" & Add3 & "',"
                    sqlstring = sqlstring & " '" & Phoneno & "',"
                    sqlstring = sqlstring & Rate & ","
                    sqlstring = sqlstring & " 'N'" & ","
                    sqlstring = sqlstring & " '" & Trim(gUsername) & "',"
                    sqlstring = sqlstring & " '" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                Next
            End With
            '========================MULTIPLE TAX=======================================
            For I = 0 To LST_TAX.CheckedItems.Count - 1
                SQL1 = "INSERT INTO PARTY_ARRANGEMASTER_TAX(GLACCODE,ARRCODE,ARRDESCRIPTION,UOM,RATE,ITEMTYPECODE,CGROUPCODE,CATEGORY,FREEZE,SBFCHARGE,"
                SQL1 = SQL1 & "adduserid,adddatetime)"
                SQL1 = SQL1 & " VALUES ( '" & Trim(TXT_GLACCODE.Text) & "','" & Trim(txtarrcode.Text) & "','" & Trim(txtarrdesc.Text) & "'"
                SQL1 = SQL1 & ",'" & UOMCODE & "'," & TXTRATE.Text & ","
                ITEMTYPECODE = Split(LST_TAX.CheckedItems(I), "-->")
                SQL1 = SQL1 & "'" & ITEMTYPECODE(0)
                SQL1 = SQL1 & ",'" & TXTCGROUPCODE.Text & "','" & cbxcategory.Text & "','N'"
                If optYes.Checked = True Then
                    SQL1 = SQL1 & " ,'Y'"
                Else
                    SQL1 = SQL1 & " ,'N'"
                End If
                SQL1 = SQL1 & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = SQL1
            Next
            '===========================================================================
            gconnection.dataOperation1(1, Insert)
        ElseIf Cmd_Add.Text = "Update[F7]" Then
                Call checkValidation()
                If boolchk = False Then Exit Sub
                If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                    If Me.lbl_Freeze.Visible = True Then
                        MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        boolchk = False
                        Exit Sub
                    End If
                End If
                strsql = "Update  PARTY_ARRANGEMASTER_HDR "
                strsql = strsql & " SET   Arrdescription='" & Trim(txtarrdesc.Text) & "',"
                strsql = strsql & " Rate=" & Trim(TXTRATE.Text) & ","
                strsql = strsql & " Uom ='" & Trim(UOMCODE) & "',"
                strsql = strsql & " GLACCODE ='" & Trim(TXT_GLACCODE.Text) & "',"
                strsql = strsql & " ITEMTYPECODE ='" & Trim(txtItemType.Text) & "',"
                strsql = strsql & " SBFCHARGE = '" & IIf(optYes.Checked = True, "Y", "N") & "',"

                strsql = strsql & " CGROUPCODE ='" & Trim(TXTCGROUPCODE.Text) & "',"
                strsql = strsql & " Category ='" & Trim(cbxcategory.Text) & "',"
                strsql = strsql & " AddUserId='" & Trim(gUsername) & "',AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
                strsql = strsql & " Where arrcode = '" & Trim(txtarrcode.Text) & "'"
                Insert(0) = strsql
                strsql = "Delete From PARTY_ARRANGEMASTER_DET Where arrcode = '" & Trim(txtarrcode.Text) & "'"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = strsql
                With ssgrid
                    For I = 1 To ssgrid.DataRowCnt
                        Pname = "" : Add1 = "" : Add2 = "" : Add3 = "" : Phoneno = "" : Rate = 0
                        .Row = I
                        .Col = 1
                        Pname = Trim(.Text)
                        .Row = I
                        .Col = 2
                        Add1 = Trim(.Text)
                        .Row = I
                        .Col = 3
                        Add2 = Trim(.Text)
                        .Row = I
                        .Col = 4
                        Add3 = Trim(.Text)
                        .Row = I
                        .Col = 5
                        Phoneno = Trim(.Text)
                        .Row = I
                        .Col = 6
                        Rate = IIf(Len(Trim(.Text)) > 0, Format(Val(.Text), "0.00"), 0)
                        sqlstring = "Insert Into PARTY_ARRANGEMASTER_DET(Arrcode,Pname,Add1,add2,Add3,phoneno,Rate,"
                        sqlstring = sqlstring & "Freeze,Adduserid,Adddatetime)"
                        sqlstring = sqlstring & " values('" & Trim(txtarrcode.Text) & "',"
                        sqlstring = sqlstring & " '" & Pname & "',"
                        sqlstring = sqlstring & " '" & Add1 & "',"
                        sqlstring = sqlstring & " '" & Add2 & "',"
                        sqlstring = sqlstring & " '" & Add3 & "',"
                        sqlstring = sqlstring & " '" & Phoneno & "',"
                        sqlstring = sqlstring & Rate & ","
                        sqlstring = sqlstring & " 'N'" & ","
                        sqlstring = sqlstring & " '" & Trim(gUsername) & "',"
                        sqlstring = sqlstring & " '" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                        ReDim Preserve Insert(Insert.Length)
                        Insert(Insert.Length - 1) = sqlstring
                    Next
            End With
            '===============================MULTIPLE TAX=========================
            SQL1 = "DELETE FROM PARTY_ARRANGEMASTER_TAX WHERE ARRCODE='" & Trim(txtarrcode.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = SQL1

            For I = 0 To LST_TAX.CheckedItems.Count - 1
                SQL1 = "INSERT INTO PARTY_ARRANGEMASTER_TAX(GLACCODE,ARRCODE,ARRDESCRIPTION,UOM,RATE,ITEMTYPECODE,CGROUPCODE,CATEGORY,FREEZE,SBFCHARGE,"
                SQL1 = SQL1 & "adduserid,adddatetime)"
                SQL1 = SQL1 & " VALUES ( '" & Trim(TXT_GLACCODE.Text) & "','" & Trim(txtarrcode.Text) & "','" & Trim(txtarrdesc.Text) & "'"
                SQL1 = SQL1 & ",'" & Me.TXTUOM.Text & "'," & TXTRATE.Text & ","
                ITEMTYPECODE = Split(LST_TAX.CheckedItems(I), "-->")
                SQL1 = SQL1 & "'" & ITEMTYPECODE(0)
                SQL1 = SQL1 & "','" & TXTCGROUPCODE.Text & "','" & cbxcategory.Text & "','N'"
                If optYes.Checked = True Then
                    SQL1 = SQL1 & " ,'Y'"
                Else
                    SQL1 = SQL1 & " ,'N'"
                End If
                SQL1 = SQL1 & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = SQL1
            Next
            '====================================================================
            gconnection.dataOperation1(2, Insert)
            Cmd_Add.Text = "Add [F7]"
        End If
        Me.Cmd_Clear_Click(sender, e)
    End Sub
    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation()
        Dim strsql, Insert(0) As String
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            sqlstring = "UPDATE  PARTY_ARRANGEMASTER_HDR "
            sqlstring = sqlstring & " SET Freeze= 'Y',AddUserid='" & gUsername & " ', "
            sqlstring = sqlstring & " AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE ArrCode = '" & Trim(txtarrcode.Text) & "'"
            Insert(0) = sqlstring
            sqlstring = "UPDATE  PARTY_ARRANGEMASTER_DET "
            sqlstring = sqlstring & " SET Freeze= 'Y',AddUserid='" & gUsername & " ', "
            sqlstring = sqlstring & " AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE ArrCode = '" & Trim(txtarrcode.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            gconnection.dataOperation1(3, Insert)
        Else
            sqlstring = "UPDATE  PARTY_ARRANGEMASTER_HDR "
            sqlstring = sqlstring & " SET Freeze= 'N',AddUserid='" & gUsername & " ', "
            sqlstring = sqlstring & " AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE ArrCode = '" & Trim(txtarrcode.Text) & "'"
            Insert(0) = sqlstring
            sqlstring = "UPDATE  PARTY_ARRANGEMASTER_DET "
            sqlstring = sqlstring & " SET Freeze= 'N',AddUserid='" & gUsername & " ', "
            sqlstring = sqlstring & " AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE ArrCode = '" & Trim(txtarrcode.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            gconnection.dataOperation1(4, Insert)
        End If
        Me.Cmd_Clear_Click(sender, e)
        Cmd_Add.Text = "Add [F7]"
    End Sub
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_ARRANGEMENT
        STR = "SELECT * FROM PARTY_ARRANGEMASTERDET"
        Viewer.ssql = STR
        Viewer.Report = r
        Viewer.TableName = "PARTY_ARRANGEMASTERDET"
        Dim textobj1 As TextObject
        textobj1 = r.ReportDefinition.ReportObjects("Text6")
        textobj1.Text = MyCompanyName
        Dim TXTOBJ2 As TextObject
        TXTOBJ2 = r.ReportDefinition.ReportObjects("Text11")
        TXTOBJ2.Text = gUsername
        Viewer.Show()
        'gPrint = False
        'Call Arrangedetails()
    End Sub
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Hide()
    End Sub
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        clearoperaction()
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Cmd_Add.Text = "Add [F7]"
        TXT_GLACCODE.Text = ""
        txtarrcode.Enabled = True
        txtarrcode.ReadOnly = False
        txtarrdesc.ReadOnly = False
        cmdarrCodehelp.Enabled = True
        TXTRATE.Text = Format(Val(TXTRATE.Text), "0.00")
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtarrcode.Focus()
    End Sub
    Private Sub ARRANGEMENT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        Me.txtarrcode.Enabled = True
        Me.txtarrcode.ReadOnly = False
        GroupMasterbool = True
        Call FILLTAX()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtarrcode.Focus()
        Show()
        'clearoperaction()
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
        sqlstring = "select * from party_arrangemaster_TAX "
        gconnection.getDataSet(sqlstring, "party_arrangemaster_TAX")
        If gdataset.Tables("party_arrangemaster_TAX").Rows.Count > 0 Then
            For I = 0 To gdataset.Tables("party_arrangemaster_TAX").Rows.Count - 1
                For j = 0 To LST_TAX.Items.Count - 1
                    TempString = Split((LST_TAX.Items.Item(j)), "-->")
                    If Trim(TempString(0)) = Trim(gdataset.Tables("party_arrangemaster_TAX").Rows(I).Item("ITEMTYPECODE")) Then
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
        gconnection.getDataSet(SQLSTRING, "USER")
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
    Private Sub cmdarrCodehelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdarrCodehelp.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(ARRCODE,'') AS HALLCODE,ISNULL(ARRDESCRIPTION,'') AS ARRDESCRIPTION,isnull(RATE,0) as RATE,isnull(category,'') as category,isnull(UOM,'') as UOM,isnull(Itemtypecode,'') as Itemtypecode,isnull(glaccode,'') glaccode FROM "
        gSQLString = gSQLString & " PARTY_ARRANGEMASTER_HDR "
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "ARRCODE,ARRDESCRIPTION,RATE,category,UOM,Itemtypecode,glaccode"
        vform.vFormatstring = " HALL CODE | HALL DESCRIPTION         "
        vform.vCaption = "ARRANGEMENT  MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txtarrcode.Text = Trim(vform.keyfield & "")
            txtarrdesc.Text = Trim(vform.keyfield1 & "")
            Call txtarrcode_Validated(txtarrcode, e)
            txtarrcode.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Public Sub checkValidation()
        boolchk = False
        If Trim(txtarrcode.Text) = "" Then
            MessageBox.Show(" Arrange Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtarrcode.Focus()
            Exit Sub
        End If
        If Trim(txtarrdesc.Text) = "" Then
            MessageBox.Show("Arrange Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtarrdesc.Focus()
            Exit Sub
        End If
        If Trim(TXTUOM.Text) = "" Then
            MessageBox.Show("UOM can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtarrdesc.Focus()
            Exit Sub
        End If
        If Trim(cbxcategory.Text) = "" Then
            MessageBox.Show("Category can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            cbxcategory.Focus()
            Exit Sub
        End If
        If Trim(txtItemType.Text) = "" Then
            MessageBox.Show("Tax Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtItemType.Focus()
            Exit Sub
        End If
        If Trim(TXTRATE.Text) = "" Then
            MessageBox.Show("Rate Code can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTRATE.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub txtarrcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtarrcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtarrcode.Text) <> "" Then
                Call txtarrcode_Validated(txtarrcode, e)
                txtarrdesc.Focus()
            Else
                Call cmdarrCodehelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txtarrdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtarrdesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTUOM.Focus()
        End If
    End Sub
    Private Sub cbxcategory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cbxcategory.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtItemType.Focus()
        End If
    End Sub
    Private Sub TXTUOM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTUOM.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cbxcategory.Focus()
        End If
    End Sub
    Private Sub TXTRATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Or TXTRATE.Text = "" Then
            ssgrid.Focus()
        End If
    End Sub
    Private Sub txtarrcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtarrcode.KeyDown
        'If e.KeyCode = Keys.F4 Then
        '    Call cmdarrCodehelp_Click(sender, e)
        'End If
        'If e.KeyCode = Keys.Enter Then
        '    If txtarrcode.Text = "" Then
        '        Call cmdarrCodehelp_Click(sender, e)
        '    End If
        'End If
    End Sub

    Private Sub ARRANGEMENT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            Call Cmd_Freeze_Click(Cmd_Freeze, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 Then
            Call Cmd_View_Click(Cmd_View, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F10 Then
            Call cmd_print_Click(Cmd_View, e)
            Exit Sub
        End If

        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub
    Private Sub cmduomhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmduomhelp.Click
        Dim vform As New ListOperattion1
        Try
            'gSQLString = "Select Uomcode,Uomdesc From Uommaster"
            gSQLString = " SELECT ISNULL(UOMCODE,'') AS UOMCODE,ISNULL(UOMDESC,'') AS UOMDESC FROM UOMMASTER"

            M_WhereCondition = " "
            vform.Field = "uomcode,uomdesc"
            vform.vFormatstring = " Uom Code  | Uom Name           "
            vform.vCaption = "Uom Master Help"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXTUOM.Text = Trim(vform.keyfield1 & "")
                TXTUOM.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtItemType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemType.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            TXTCGROUPCODE.Focus()
        End If
    End Sub
    Private Sub txtTypedes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTypedes.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            TXTCGROUPCODE.Focus()
        End If
    End Sub
    Private Sub cmdType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdType.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(ITEMTYPECODE,'') AS ITEMTYPECODE,ISNULL(ITEMTYPEDESC,'') AS ITEMTYPEDESC FROM ItemTypeMaster"
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'"
        End If
        vform.Field = "ITEMTYPECODE,ITEMTYPEDESC"
        vform.vFormatstring = " ITEM TYPE CODE | ITEM TYPE DESCRIPTION   "
        vform.vCaption = "ITEM TYPE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txtItemType.Text = Trim(vform.keyfield & "")
            'Call txtItemType_Validated(txtItemType, e)
            txtTypedes.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txtItemType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemType.Validated
        If txtItemType.Text <> "" Then
            sqlstring = "SELECT ISNULL(ITEMTYPECODE,'') AS ITEMTYPECODE,ISNULL(ITEMTYPEDESC,'') AS ITEMTYPEDESC FROM ItemTypeMaster WHERE ItemTypeCode='" & Trim(txtItemType.Text) & "' AND ISNULL(Freeze,'') <> 'Y'"
            vconn.getDataSet(sqlstring, "ItemTypeMaster")
            If gdataset.Tables("ItemTypeMaster").Rows.Count > 0 Then
                txtTypedes.Text = ""
                txtTypedes.Text = Trim(gdataset.Tables("ItemTypeMaster").Rows(0).Item("ItemTypeDesc"))
                txtTypedes.ReadOnly = True
                TXTRATE.Focus()
            Else
                txtItemType.Clear()
                txtTypedes.Clear()
                txtItemType.Focus()
            End If
        Else
            txtTypedes.Clear()
        End If
    End Sub
    Private Sub TXTRATE_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TXTRATE.Text = Format(Val(TXTRATE.Text), "0.00")
    End Sub
    Private Sub ssgrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent
        Try
            If e.keyCode = Keys.Enter Then
                If ssgrid.ActiveCol = 1 Then
                    ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                ElseIf ssgrid.ActiveCol = 2 Then
                    ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                ElseIf ssgrid.ActiveCol = 3 Then
                    ssgrid.SetActiveCell(4, ssgrid.ActiveRow)
                ElseIf ssgrid.ActiveCol = 4 Then
                    ssgrid.SetActiveCell(5, ssgrid.ActiveRow)
                ElseIf ssgrid.ActiveCol = 5 Then
                    ssgrid.SetActiveCell(6, ssgrid.ActiveRow)
                ElseIf ssgrid.ActiveCol = 6 Then
                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)
                End If
            ElseIf e.keyCode = Keys.F3 Then
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.DeleteRows(ssgrid.ActiveRow, 1)
            End If
            If e.keyCode = Keys.F4 Then
                Dim vform As New ListOperattion1
                If ssgrid.ActiveCol = 1 Then
                    gSQLString = " SELECT PNAME,ADD1,ADD2,ADD3,PHONENO FROM VIEW_PARTY_ADDRESS"
                    If Trim(Search) = "" Then
                        M_WhereCondition = ""
                    Else
                        M_WhereCondition = ""
                    End If
                    vform.Field = "PNAME,ADD1,ADD2,ADD3,PHONENO"
                    vform.vFormatstring = " NAME              |ADDRESS1           |ADDRESS1            | PHONENO      "
                    vform.vCaption = "PARTY ADDRESS DETAILS HELP"
                    vform.KeyPos = 0
                    vform.KeyPos1 = 1
                    vform.KeyPos2 = 2
                    vform.Keypos3 = 3
                    vform.keypos4 = 4
                    vform.ShowDialog(Me)
                    If Trim(vform.keyfield & "") <> "" Then
                        With ssgrid
                            .Col = 1
                            .Row = ssgrid.ActiveRow
                            .Text = ""
                            .Text = Trim(vform.keyfield & "")
                            .SetActiveCell(2, ssgrid.ActiveRow)
                            .Col = 2
                            .Row = ssgrid.ActiveRow
                            .Text = ""
                            .Text = Trim(vform.keyfield1 & "")
                            .SetActiveCell(3, ssgrid.ActiveRow)
                            .Col = 3
                            .Row = ssgrid.ActiveRow
                            .Text = ""
                            .Text = Trim(vform.keyfield3 & "")
                            .Col = 4
                            .Row = ssgrid.ActiveRow
                            .Text = ""
                            .Text = Trim(vform.keyfield4 & "")
                            .Col = 5
                            .Row = ssgrid.ActiveRow
                            .Text = ""
                            .Text = Trim(vform.keyfield5 & "")
                            .Col = 6
                            .Row = ssgrid.ActiveRow
                            .Text = ""
                        End With
                    End If
                    vform.Close()
                    vform = Nothing
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtarrcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtarrcode.Validated
        Dim Fre As String
        Try
            If Trim(txtarrcode.Text) <> "" Then
                Dim ds As New DataSet
                sqlstring = "SELECT ISNULL(GLACCODE,'') AS GLACCODE,ARRCODE,ARRDESCRIPTION,RATE,UOM,ISNULL(SBFCHARGE,'') AS SBFCHARGE,CATEGORY,ITEMTYPECODE,FREEZE,ADDDATETIME,CGROUPCODE,"
                sqlstring = sqlstring & " ADDUSERID  FROM PARTY_ARRANGEMASTER_HDR "
                sqlstring = sqlstring & " WHERE ARRCODE='" & txtarrcode.Text & "'"
                gconnection.getDataSet(sqlstring, "ArrMaster")
                If gdataset.Tables("ArrMaster").Rows.Count > 0 Then
                    txtarrdesc.Clear()
                    txtarrdesc.Text = gdataset.Tables("ArrMaster").Rows(0).Item("ArrDescription")
                    TXTUOM.Text = gdataset.Tables("ArrMaster").Rows(0).Item("Uom")
                    cbxcategory.Text = gdataset.Tables("ArrMaster").Rows(0).Item("Category")
                    TXTCGROUPCODE.Text = gdataset.Tables("ArrMaster").Rows(0).Item("CGROUPCODE")

                    If gdataset.Tables("ArrMaster").Rows(0).Item("sbfcharge") = "Y" Then
                        optYes.Checked = True
                        OptNo.Checked = False
                    Else
                        optYes.Checked = False
                        OptNo.Checked = True
                    End If

                    TXTRATE.Text = gdataset.Tables("ArrMaster").Rows(0).Item("Rate")
                    txtItemType.Text = gdataset.Tables("ArrMaster").Rows(0).Item("ITEMTYPECODE")
                    TXT_GLACCODE.Text = gdataset.Tables("ArrMaster").Rows(0).Item("GLACCODE")
                    If gdataset.Tables("ArrMaster").Rows(0).Item("Freeze") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("ArrMaster").Rows(0).Item("ADDDATETIME")), "dd-MMM-yyyy")
                        Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_Freeze.Text = "Freeze[F8]"
                    End If
                    Call txtItemType_Validated(txtItemType, e)
                    'Call TXTCGROUPCODE_Validated(TXTCGROUPCODE, e)
                    Me.Cmd_Add.Text = "Update[F7]"
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    'sqlstring = "SELECT ARRCODE,PNAME,ADD1,ADD2,ADD3,PHONENO,ADDUSERID,ADDDATETIME,RATE,FREEZE "
                    'sqlstring = sqlstring & " FROM VIEW_PARTY_ADDRESS "

                    'sqlstring = sqlstring & " where Arrcode='" & txtarrcode.Text & "'"
                    'gconnection.getDataSet(sqlstring, "ARRMaster")
                    'If gdataset.Tables("ArrMaster").Rows.Count > 0 Then
                    '    ssgrid.ClearRange(-1, -1, 1, 1, True)
                    '    ssgrid.SetActiveCell(1, 1)
                    '    With ssgrid
                    '        For I = 0 To gdataset.Tables("ArrMaster").Rows.Count - 1
                    '            .Col = 1
                    '            .Row = I + 1
                    '            .Text = Trim(gdataset.Tables("ArrMaster").Rows(I).Item("Pname"))
                    '            .Col = 2
                    '            .Row = I + 1
                    '            .Text = Trim(gdataset.Tables("ArrMaster").Rows(I).Item("Add1"))
                    '            .Col = 3
                    '            .Row = I + 1
                    '            .Text = Trim(gdataset.Tables("ArrMaster").Rows(I).Item("add2"))
                    '            .Col = 4
                    '            .Row = I + 1
                    '            .Text = Trim(gdataset.Tables("ArrMaster").Rows(I).Item("add3"))
                    '            .Col = 5
                    '            .Row = I + 1
                    '            .Text = Trim(gdataset.Tables("ArrMaster").Rows(I).Item("phoneno"))
                    '            .Col = 6
                    '            .Row = I + 1
                    '            .Text = Val(gdataset.Tables("ArrMaster").Rows(I).Item("Rate"))
                    '        Next
                    '        .SetActiveCell(1, 1)
                    '    End With
                    'End If
                    Me.txtarrcode.ReadOnly = True
                    Me.cmdarrCodehelp.Enabled = False
                    Me.txtarrdesc.Focus()
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Add.Text = "Add [F7]"
                    txtarrcode.ReadOnly = False
                    txtarrdesc.Focus()
                End If
            Else
                txtarrcode.Text = ""
                txtarrdesc.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TXTUOM_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTUOM.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmduomhelp_Click(sender, e)
        End If
        If e.KeyCode = Keys.Enter Then
            If TXTUOM.Text = "" Then
                Call cmduomhelp_Click(sender, e)
            End If
        End If

    End Sub
    Private Sub txtItemType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemType.KeyDown
        If e.KeyCode = Keys.F4 Or Trim(txtItemType.Text) = "" Then
            Call cmdType_Click(sender, e)
        End If
        If e.KeyCode = Keys.Enter Then
            If txtItemType.Text = "" Then
                Call cmdType_Click(sender, e)
            End If
        End If

    End Sub
    Private Sub clearoperaction()
        TXTRATE.Text = ""
        txtTypedes.ReadOnly = False
        txtTypedes.Text = ""
        TXTUOM.Text = ""
        TXTCGROUPCODE.Text = ""
        TXTCGROUPDESC.Text = ""
        txtarrcode.Text = ""
        TXTRATE.Text = Format(Val(TXTRATE.Text), "0.00")
        txtarrdesc.Text = ""
        txtItemType.Text = ""
        txtTypedes.Text = ""
        TXTCGROUPCODE.Text = ""
        TXTCGROUPDESC.Text = ""
        'ssgrid.ClearRange(-1, -1, 1, 1, True)
        'ssgrid.SetActiveCell(1, 1)
        'cbxcategory.SelectedIndex = 1
        txtTypedes.ReadOnly = True
        'txtarrcode.Focus()
    End Sub
    Private Sub TXTRATE_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            'ssgrid.Focus()
            TXT_GLACCODE.Focus()
        End If
    End Sub
    Private Sub TXTRATE_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTRATE.LostFocus
        TXTRATE.Text = Format(Val(TXTRATE.Text), "0.00")
    End Sub
    Private Sub Arrangedetails()
        Dim Desc As String
        Dim Pno, pagesize As Integer
        Try
            Dim dt As New DataTable
            Rnd()
            vOutfile = Mid("Out" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            Pno = Pno + 1
            sqlstring = "SELECT ARRCODE,ARRDESCRIPTION,RATE,UOM,CATEGORY,ITEMTYPECODE,FREEZE,ADDDATETIME,"
            sqlstring = sqlstring & " ADDUSERID  FROM PARTY_VIEW_ARRANGEMASTER ORDER BY CATEGORY"
            dt = gconnection.GetValues(sqlstring)
            Filewrite.WriteLine(Chr(15) & Chr(27) + "E" & gCompanyAddress(0) & Chr(27) + "F")
            Filewrite.Write(Chr(27) + "E" & "MENU FICILITY" & Chr(27) + "F" & Space(50) & "Page No:")
            Filewrite.WriteLine(Trim(CStr(Pno)))
            Filewrite.WriteLine("|" & StrDup(78, "-") & "|")
            sqlstring = "|ARRCODE   DESCRIPTION                               UOM            RATE       |"
            Filewrite.WriteLine(sqlstring)
            Filewrite.WriteLine("|" & StrDup(78, "-") & "|")
            Desc = ""
            If dt.Rows.Count > 0 Then
                For I = 0 To dt.Rows.Count - 1
                    If Desc <> Trim(dt.Rows(I).Item("CATEGORY")) Then
                        Filewrite.WriteLine("|" & Space(78) & "|")
                        sqlstring = "|"
                        sqlstring = sqlstring & Mid(Trim(dt.Rows(I).Item("CATEGORY")), 1, 30)
                        sqlstring = sqlstring & Space(30 - Len(Mid(Trim(dt.Rows(I).Item("CATEGORY")), 1, 30)))
                        sqlstring = sqlstring & Space(48) & "|"
                        Filewrite.WriteLine(Chr(27) & "E" & sqlstring & Chr(27) & "F")
                        Filewrite.WriteLine("|" & Space(78) & "|")
                        Desc = Trim(dt.Rows(I).Item("CATEGORY"))
                    End If
                    sqlstring = "|" & Mid(Trim(dt.Rows(I).Item("Arrcode")), 1, 8)
                    sqlstring = sqlstring & Space(8 - Len(Mid(Trim(dt.Rows(I).Item("arrcode")), 1, 8)))
                    sqlstring = sqlstring & Space(2) & Mid(Trim(dt.Rows(I).Item("Arrdescription")), 1, 30)
                    sqlstring = sqlstring & Space(30 - Len(Mid(Trim(dt.Rows(I).Item("arrdescription")), 1, 30)))
                    sqlstring = sqlstring & Space(11) & Mid(Trim(dt.Rows(I).Item("uom")), 1, 10)
                    sqlstring = sqlstring & Space(10 - Len(Mid(Trim(dt.Rows(I).Item("uom")), 1, 10))) & Space(3)
                    sqlstring = sqlstring & Space(10 - Len(Mid(Format(dt.Rows(I).Item("rate"), "0.00"), 1, 10)))
                    sqlstring = sqlstring & Mid(Format(dt.Rows(I).Item("rate"), "0.00"), 1, 10) & Space(4) & "|"
                    Filewrite.WriteLine(sqlstring)
                    If pagesize > 60 Then
                        Pno = Pno + 1
                        Filewrite.WriteLine("|" & StrDup(78, "=") & "|" & Chr(12))
                        Pno = Pno + 1
                        Filewrite.WriteLine(Chr(15) & Chr(27) + "E" & gCompanyAddress(0) & Chr(27) + "F")
                        Filewrite.Write(Chr(27) + "E" & "MENU FICILITY" & Chr(27) + "F" & Space(50) & "Page No:")
                        Filewrite.WriteLine(Trim(CStr(Pno)))
                        Filewrite.WriteLine("|DESCRIPTION                                           UOM            Rate                         |")
                        Filewrite.WriteLine("|" & StrDup(78, "=") & "|")
                        pagesize = 0
                    End If
                    pagesize = pagesize + 1
                Next
                Filewrite.WriteLine("|" & StrDup(78, "=") & "|" & Chr(12))
            Else
                MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile1(VFilePath)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmd_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_print.Click
        gPrint = True
        Call Arrangedetails()
    End Sub
    Private Sub TXTCGROUPCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCGROUPCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTRATE.Focus()
        End If
    End Sub
    Private Sub CGROUPHELP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CGROUPHELP.Click
        Dim vform As New ListOperattion1
        gSQLString = " SELECT ITEMTYPECODE,ITEMTYPEDESC FROM VIEW_PARTY_CANCELGROUPHELP "
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y'"
        End If
        vform.Field = "ITEMTYPECODE,ITEMTYPEDESC"
        vform.vFormatstring = " ITEM TYPE CODE |  ITEM TYPE DESCRIPTION    "
        vform.vCaption = "ITEM TYPE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXTCGROUPCODE.Text = Trim(vform.keyfield & "")
            'Call TXTCGROUPCODE_Validated(TXTCGROUPCODE, e)
            'TXTRATE.Focus()
            TXTCGROUPCODE.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub TXTCGROUPCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTCGROUPCODE.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call CGROUPHELP_Click(sender, e)
        End If
        If e.KeyCode = Keys.Enter Then
            If TXTCGROUPCODE.Text = "" Then
                Call CGROUPHELP_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub TXTCGROUPCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCGROUPCODE.TextChanged

    End Sub
    Private Sub txtItemType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemType.TextChanged

    End Sub

    Private Sub txtarrcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtarrcode.TextChanged

    End Sub
    Private Sub TXTCGROUPCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCGROUPCODE.Validated
        If TXTCGROUPCODE.Text <> "" Then
            sqlstring = " SELECT ITEMTYPECODE,ITEMDESC FROM VIEW_PARTY_GROUPMASTER  WHERE ItemTypeCode='" & Trim(TXTCGROUPCODE.Text) & "'"
            vconn.getDataSet(sqlstring, "ItemTypeMaster")
            If gdataset.Tables("ItemTypeMaster").Rows.Count > 0 Then
                TXTCGROUPDESC.Text = ""
                TXTCGROUPDESC.Text = Trim(gdataset.Tables("ItemTypeMaster").Rows(0).Item("ITEMDesc"))
                TXTCGROUPDESC.ReadOnly = True
                TXTRATE.Focus()
            Else
                TXTCGROUPCODE.Clear()
                TXTCGROUPCODE.Clear()
                TXTCGROUPCODE.Focus()
            End If
        Else
            TXTCGROUPDESC.Clear()
        End If
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
            Cmd_Add.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub TXT_GLACCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_GLACCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXT_GLACCODE.Text) = "" Then
                Call CMD_GLACCODE_Click(sender, e)
            End If
            Cmd_Add.Focus()
        End If
    End Sub

    Private Sub TXTRATE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTRATE.TextChanged

    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "PARTY_ARRANGEMASTER_HDR"
        sqlstring = "SELECT * FROM PARTY_ARRANGEMASTER_HDR"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub
End Class
