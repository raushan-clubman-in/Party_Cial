Imports System
Imports System.data
Imports System.Data.SqlClient
Imports System.IO
Public Class menumaster
    Inherits System.Windows.Forms.Form
    Dim vseqno As Double
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Dim i, j As Integer
    Dim ssql As String
    Dim vconn As New GlobalClass
    Dim dt As New DataTable
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
    Friend WithEvents txtoccupancy As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txthallcode As System.Windows.Forms.TextBox
    Friend WithEvents txthalldescription As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdhallHelp As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTHALLRENT As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtItemType As System.Windows.Forms.TextBox
    Friend WithEvents txtTypedes As System.Windows.Forms.TextBox
    Friend WithEvents cmdType As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SSGRID As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Txthalltype As System.Windows.Forms.ComboBox
    Friend WithEvents grp_HALLdetails As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CMDPRINT As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CMDSCREEN As System.Windows.Forms.Button
    Friend WithEvents RDBHALLWF As System.Windows.Forms.RadioButton
    Friend WithEvents RDBHALLWOF As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTCGROUPCODE As System.Windows.Forms.TextBox
    Friend WithEvents CGROUPHELP As System.Windows.Forms.Button
    Friend WithEvents TXTCGROUPDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(menumaster))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TXTCGROUPCODE = New System.Windows.Forms.TextBox
        Me.CGROUPHELP = New System.Windows.Forms.Button
        Me.TXTCGROUPDESC = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.grp_HALLdetails = New System.Windows.Forms.GroupBox
        Me.RDBHALLWOF = New System.Windows.Forms.RadioButton
        Me.RDBHALLWF = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CMDSCREEN = New System.Windows.Forms.Button
        Me.CMDPRINT = New System.Windows.Forms.Button
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.SSGRID = New AxFPSpreadADO.AxfpSpread
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtItemType = New System.Windows.Forms.TextBox
        Me.txtTypedes = New System.Windows.Forms.TextBox
        Me.cmdType = New System.Windows.Forms.Button
        Me.txtoccupancy = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txthalltype = New System.Windows.Forms.ComboBox
        Me.txthallcode = New System.Windows.Forms.TextBox
        Me.txthalldescription = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmdhallHelp = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TXTHALLRENT = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TXTDESCRIPTION = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.lbl_Freeze = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.Cmd_View = New System.Windows.Forms.Button
        Me.Cmd_Freeze = New System.Windows.Forms.Button
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.grp_HALLdetails.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TXTCGROUPCODE)
        Me.GroupBox1.Controls.Add(Me.CGROUPHELP)
        Me.GroupBox1.Controls.Add(Me.TXTCGROUPDESC)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.grp_HALLdetails)
        Me.GroupBox1.Controls.Add(Me.SSGRID)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtItemType)
        Me.GroupBox1.Controls.Add(Me.txtTypedes)
        Me.GroupBox1.Controls.Add(Me.cmdType)
        Me.GroupBox1.Controls.Add(Me.txtoccupancy)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Txthalltype)
        Me.GroupBox1.Controls.Add(Me.txthallcode)
        Me.GroupBox1.Controls.Add(Me.txthalldescription)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cmdhallHelp)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TXTHALLRENT)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TXTDESCRIPTION)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(112, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(824, 552)
        Me.GroupBox1.TabIndex = 394
        Me.GroupBox1.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Courier New", 13.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(1, 160)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(159, 24)
        Me.Label12.TabIndex = 410
        Me.Label12.Text = "CANCEL G.CODE "
        '
        'TXTCGROUPCODE
        '
        Me.TXTCGROUPCODE.BackColor = System.Drawing.Color.Wheat
        Me.TXTCGROUPCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCGROUPCODE.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCGROUPCODE.Location = New System.Drawing.Point(167, 160)
        Me.TXTCGROUPCODE.MaxLength = 10
        Me.TXTCGROUPCODE.Name = "TXTCGROUPCODE"
        Me.TXTCGROUPCODE.Size = New System.Drawing.Size(168, 26)
        Me.TXTCGROUPCODE.TabIndex = 8
        Me.TXTCGROUPCODE.Text = ""
        '
        'CGROUPHELP
        '
        Me.CGROUPHELP.Image = CType(resources.GetObject("CGROUPHELP.Image"), System.Drawing.Image)
        Me.CGROUPHELP.Location = New System.Drawing.Point(335, 160)
        Me.CGROUPHELP.Name = "CGROUPHELP"
        Me.CGROUPHELP.Size = New System.Drawing.Size(23, 26)
        Me.CGROUPHELP.TabIndex = 9
        '
        'TXTCGROUPDESC
        '
        Me.TXTCGROUPDESC.BackColor = System.Drawing.Color.Wheat
        Me.TXTCGROUPDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCGROUPDESC.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCGROUPDESC.Location = New System.Drawing.Point(512, 160)
        Me.TXTCGROUPDESC.MaxLength = 50
        Me.TXTCGROUPDESC.Name = "TXTCGROUPDESC"
        Me.TXTCGROUPDESC.ReadOnly = True
        Me.TXTCGROUPDESC.Size = New System.Drawing.Size(304, 26)
        Me.TXTCGROUPDESC.TabIndex = 10
        Me.TXTCGROUPDESC.Text = ""
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(368, 160)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(148, 25)
        Me.Label13.TabIndex = 411
        Me.Label13.Text = "DESCRIPTION "
        '
        'grp_HALLdetails
        '
        Me.grp_HALLdetails.BackColor = System.Drawing.Color.Transparent
        Me.grp_HALLdetails.Controls.Add(Me.RDBHALLWOF)
        Me.grp_HALLdetails.Controls.Add(Me.RDBHALLWF)
        Me.grp_HALLdetails.Controls.Add(Me.GroupBox3)
        Me.grp_HALLdetails.Controls.Add(Me.GroupBox4)
        Me.grp_HALLdetails.Location = New System.Drawing.Point(88, 472)
        Me.grp_HALLdetails.Name = "grp_HALLdetails"
        Me.grp_HALLdetails.Size = New System.Drawing.Size(648, 320)
        Me.grp_HALLdetails.TabIndex = 397
        Me.grp_HALLdetails.TabStop = False
        Me.grp_HALLdetails.Visible = False
        '
        'RDBHALLWOF
        '
        Me.RDBHALLWOF.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.RDBHALLWOF.Location = New System.Drawing.Point(200, 136)
        Me.RDBHALLWOF.Name = "RDBHALLWOF"
        Me.RDBHALLWOF.Size = New System.Drawing.Size(272, 24)
        Me.RDBHALLWOF.TabIndex = 399
        Me.RDBHALLWOF.Text = "HALL WITHOUT FACILITY"
        '
        'RDBHALLWF
        '
        Me.RDBHALLWF.Checked = True
        Me.RDBHALLWF.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.RDBHALLWF.Location = New System.Drawing.Point(200, 96)
        Me.RDBHALLWF.Name = "RDBHALLWF"
        Me.RDBHALLWF.Size = New System.Drawing.Size(240, 24)
        Me.RDBHALLWF.TabIndex = 398
        Me.RDBHALLWF.TabStop = True
        Me.RDBHALLWF.Text = "HALL WITH FACILITY"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.CMDSCREEN)
        Me.GroupBox3.Controls.Add(Me.CMDPRINT)
        Me.GroupBox3.Controls.Add(Me.CMDEXIT)
        Me.GroupBox3.Location = New System.Drawing.Point(144, 232)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(344, 56)
        Me.GroupBox3.TabIndex = 397
        Me.GroupBox3.TabStop = False
        '
        'CMDSCREEN
        '
        Me.CMDSCREEN.BackColor = System.Drawing.Color.ForestGreen
        Me.CMDSCREEN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMDSCREEN.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSCREEN.ForeColor = System.Drawing.Color.White
        Me.CMDSCREEN.Image = CType(resources.GetObject("CMDSCREEN.Image"), System.Drawing.Image)
        Me.CMDSCREEN.Location = New System.Drawing.Point(8, 16)
        Me.CMDSCREEN.Name = "CMDSCREEN"
        Me.CMDSCREEN.Size = New System.Drawing.Size(104, 32)
        Me.CMDSCREEN.TabIndex = 14
        Me.CMDSCREEN.Text = " View"
        '
        'CMDPRINT
        '
        Me.CMDPRINT.BackColor = System.Drawing.Color.ForestGreen
        Me.CMDPRINT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMDPRINT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT.ForeColor = System.Drawing.Color.White
        Me.CMDPRINT.Image = CType(resources.GetObject("CMDPRINT.Image"), System.Drawing.Image)
        Me.CMDPRINT.Location = New System.Drawing.Point(120, 16)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(104, 32)
        Me.CMDPRINT.TabIndex = 13
        Me.CMDPRINT.Text = "Print"
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.ForestGreen
        Me.CMDEXIT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMDEXIT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.White
        Me.CMDEXIT.Image = CType(resources.GetObject("CMDEXIT.Image"), System.Drawing.Image)
        Me.CMDEXIT.Location = New System.Drawing.Point(232, 16)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(104, 32)
        Me.CMDEXIT.TabIndex = 15
        Me.CMDEXIT.Text = "Exit"
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(181, 80)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(304, 96)
        Me.GroupBox4.TabIndex = 400
        Me.GroupBox4.TabStop = False
        '
        'SSGRID
        '
        Me.SSGRID.ContainingControl = Me
        Me.SSGRID.DataSource = Nothing
        Me.SSGRID.Location = New System.Drawing.Point(8, 312)
        Me.SSGRID.Name = "SSGRID"
        Me.SSGRID.OcxState = CType(resources.GetObject("SSGRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID.Size = New System.Drawing.Size(792, 232)
        Me.SSGRID.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(8, 120)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 25)
        Me.Label11.TabIndex = 394
        Me.Label11.Text = "TAX TYPE "
        '
        'txtItemType
        '
        Me.txtItemType.BackColor = System.Drawing.Color.Moccasin
        Me.txtItemType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemType.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemType.Location = New System.Drawing.Point(168, 120)
        Me.txtItemType.MaxLength = 10
        Me.txtItemType.Name = "txtItemType"
        Me.txtItemType.Size = New System.Drawing.Size(168, 26)
        Me.txtItemType.TabIndex = 5
        Me.txtItemType.Text = ""
        '
        'txtTypedes
        '
        Me.txtTypedes.BackColor = System.Drawing.Color.Wheat
        Me.txtTypedes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTypedes.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTypedes.Location = New System.Drawing.Point(512, 120)
        Me.txtTypedes.MaxLength = 50
        Me.txtTypedes.Name = "txtTypedes"
        Me.txtTypedes.ReadOnly = True
        Me.txtTypedes.Size = New System.Drawing.Size(304, 26)
        Me.txtTypedes.TabIndex = 7
        Me.txtTypedes.Text = ""
        '
        'cmdType
        '
        Me.cmdType.Image = CType(resources.GetObject("cmdType.Image"), System.Drawing.Image)
        Me.cmdType.Location = New System.Drawing.Point(336, 122)
        Me.cmdType.Name = "cmdType"
        Me.cmdType.Size = New System.Drawing.Size(23, 26)
        Me.cmdType.TabIndex = 6
        '
        'txtoccupancy
        '
        Me.txtoccupancy.BackColor = System.Drawing.Color.Wheat
        Me.txtoccupancy.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtoccupancy.Location = New System.Drawing.Point(512, 72)
        Me.txtoccupancy.MaxLength = 5
        Me.txtoccupancy.Name = "txtoccupancy"
        Me.txtoccupancy.Size = New System.Drawing.Size(80, 26)
        Me.txtoccupancy.TabIndex = 4
        Me.txtoccupancy.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(400, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 25)
        Me.Label1.TabIndex = 378
        Me.Label1.Text = "OCCUPANCY"
        '
        'Txthalltype
        '
        Me.Txthalltype.BackColor = System.Drawing.Color.Wheat
        Me.Txthalltype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Txthalltype.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Txthalltype.Items.AddRange(New Object() {"A/C", "NON A/C"})
        Me.Txthalltype.Location = New System.Drawing.Point(168, 69)
        Me.Txthalltype.MaxLength = 20
        Me.Txthalltype.Name = "Txthalltype"
        Me.Txthalltype.Size = New System.Drawing.Size(168, 27)
        Me.Txthalltype.TabIndex = 3
        '
        'txthallcode
        '
        Me.txthallcode.BackColor = System.Drawing.Color.Wheat
        Me.txthallcode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txthallcode.Location = New System.Drawing.Point(168, 24)
        Me.txthallcode.MaxLength = 15
        Me.txthallcode.Name = "txthallcode"
        Me.txthallcode.Size = New System.Drawing.Size(168, 26)
        Me.txthallcode.TabIndex = 0
        Me.txthallcode.Text = ""
        '
        'txthalldescription
        '
        Me.txthalldescription.BackColor = System.Drawing.Color.Wheat
        Me.txthalldescription.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txthalldescription.Location = New System.Drawing.Point(512, 24)
        Me.txthalldescription.MaxLength = 50
        Me.txthalldescription.Name = "txthalldescription"
        Me.txthalldescription.Size = New System.Drawing.Size(304, 26)
        Me.txthalldescription.TabIndex = 2
        Me.txthalldescription.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(376, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 25)
        Me.Label5.TabIndex = 378
        Me.Label5.Text = "DESCRIPTION"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(8, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 25)
        Me.Label9.TabIndex = 379
        Me.Label9.Text = "HALL CODE "
        '
        'cmdhallHelp
        '
        Me.cmdhallHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdhallHelp.Image = CType(resources.GetObject("cmdhallHelp.Image"), System.Drawing.Image)
        Me.cmdhallHelp.Location = New System.Drawing.Point(336, 23)
        Me.cmdhallHelp.Name = "cmdhallHelp"
        Me.cmdhallHelp.Size = New System.Drawing.Size(23, 25)
        Me.cmdhallHelp.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(8, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 25)
        Me.Label3.TabIndex = 379
        Me.Label3.Text = "HALL TYPE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(8, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 25)
        Me.Label4.TabIndex = 378
        Me.Label4.Text = "HALL RENT"
        '
        'TXTHALLRENT
        '
        Me.TXTHALLRENT.BackColor = System.Drawing.Color.Wheat
        Me.TXTHALLRENT.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TXTHALLRENT.Location = New System.Drawing.Point(165, 200)
        Me.TXTHALLRENT.MaxLength = 7
        Me.TXTHALLRENT.Name = "TXTHALLRENT"
        Me.TXTHALLRENT.Size = New System.Drawing.Size(112, 26)
        Me.TXTHALLRENT.TabIndex = 11
        Me.TXTHALLRENT.Text = ""
        Me.TXTHALLRENT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(8, 248)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 20)
        Me.Label6.TabIndex = 378
        Me.Label6.Text = "HALL DETAILS"
        '
        'TXTDESCRIPTION
        '
        Me.TXTDESCRIPTION.BackColor = System.Drawing.Color.Wheat
        Me.TXTDESCRIPTION.Font = New System.Drawing.Font("Times New Roman", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXTDESCRIPTION.Location = New System.Drawing.Point(164, 248)
        Me.TXTDESCRIPTION.MaxLength = 75
        Me.TXTDESCRIPTION.Name = "TXTDESCRIPTION"
        Me.TXTDESCRIPTION.Size = New System.Drawing.Size(640, 27)
        Me.TXTDESCRIPTION.TabIndex = 12
        Me.TXTDESCRIPTION.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 16.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(8, 280)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(173, 28)
        Me.Label10.TabIndex = 391
        Me.Label10.Text = "HALL FACILITY"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(376, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 25)
        Me.Label2.TabIndex = 396
        Me.Label2.Text = "DESCRIPTION "
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(416, 316)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(219, 31)
        Me.lbl_Freeze.TabIndex = 395
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 20.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(416, 5)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(201, 34)
        Me.Label16.TabIndex = 393
        Me.Label16.Text = "HALL MASTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Location = New System.Drawing.Point(208, 619)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(584, 56)
        Me.GroupBox2.TabIndex = 396
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
        Me.Cmd_View.Location = New System.Drawing.Point(354, 16)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 17
        Me.Cmd_View.Text = " View[F9]"
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.Location = New System.Drawing.Point(240, 16)
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
        Me.Cmd_Add.Location = New System.Drawing.Point(128, 16)
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
        Me.Cmd_Exit.Location = New System.Drawing.Point(466, 16)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 18
        Me.Cmd_Exit.Text = "Exit[F11]"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(296, 600)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(383, 18)
        Me.Label7.TabIndex = 419
        Me.Label7.Text = "Press F4 for HELP / Press ENTER key to navigate"
        '
        'menumaster
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(238, Byte), CType(249, Byte), CType(232, Byte))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1016, 746)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.KeyPreview = True
        Me.Name = "menumaster"
        Me.Text = "Menumaster"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.grp_HALLdetails.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub cmdhallHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdhallHelp.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(HALLCODE,'') AS HALLCODE,ISNULL(HALLDESCRIPTION,'') AS HALLDESCRIPTION "
        gSQLString = gSQLString & " FROM Party_HallMaster "
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "HALLCODE,HALLDESCRIPTION"
        vform.vFormatstring = " HALL CODE  |  HALL DESCRIPTION      "
        vform.vCaption = "HALL MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txthallcode.Text = Trim(vform.keyfield & "")
            Call txthallcode_Validated(txthallcode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearoperaction()
        Me.lbl_Freeze.Visible = False
        Me.txthallcode.ReadOnly = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Cmd_Add.Text = "Add [F7]"
        txthallcode.Enabled = True
        txthallcode.ReadOnly = False
        txthallcode.ReadOnly = False
        cmdhallHelp.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txthallcode.Focus()
    End Sub
    Public Sub clearform(ByVal frm As System.Windows.Forms.Form)
        Dim ctrl As New Control
        For Each ctrl In frm.Controls
            If TypeOf ctrl Is TextBox Then
                ctrl.Text = ""
            End If
            If TypeOf ctrl Is ComboBox Then
                ctrl.Text = ""
            End If
        Next ctrl
    End Sub
    Private Sub txthallcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthallcode.Validated
        Dim Fre As String
        Try
            If Trim(txthallcode.Text) <> "" Then
                Dim ds As New DataSet
                vseqno = GetSeqno(txthallcode.Text)
                sqlstring = "SELECT HALLCODE,HALLDESCRIPTION,OCCUPANCY,HALLTYPE,CGROUPCODE,HALLAMOUNT,DESCRIPTION,FREEZE,"
                sqlstring = sqlstring & "ADDDATETIME,ADDUSERID,ITEMTYPECODE FROM VIEW_PARTY_HALLMASTER  "
                sqlstring = sqlstring & " WHERE HALLCODE='" & txthallcode.Text & "'"
                gconnection.getDataSet(sqlstring, "HallMaster")
                If gdataset.Tables("HallMaster").Rows.Count > 0 Then
                    txthalldescription.Clear()
                    txthalldescription.Text = gdataset.Tables("HallMaster").Rows(0).Item("HallDescription")
                    TXTDESCRIPTION.Text = gdataset.Tables("HallMaster").Rows(0).Item("Description")
                    txtoccupancy.Text = gdataset.Tables("HallMaster").Rows(0).Item("OCCUPANCY")
                    txtItemType.Text = gdataset.Tables("HallMaster").Rows(0).Item("ITEMTYPECODE")
                    TXTCGROUPCODE.Text = gdataset.Tables("HallMaster").Rows(0).Item("CGROUPCODE")
                    TXTHALLRENT.Text = gdataset.Tables("HallMaster").Rows(0).Item("HALLAMOUNT")
                    Txthalltype.Text = gdataset.Tables("HallMaster").Rows(0).Item("HALLTYPE")
                    If gdataset.Tables("HallMaster").Rows(0).Item("Freeze") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("hallMaster").Rows(0).Item("ADDDATETIME")), "dd-MMM-yyyy")
                        Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_Freeze.Text = "Freeze[F8]"
                    End If
                    Call txtItemType_Validated(txtItemType, e)
                    Call TXTCGROUPCODE_Validated(TXTCGROUPCODE, e)
                    Me.Cmd_Add.Text = "Update[F7]"
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    sqlstring = "Select Hallcode,Itemcode,Itemdescription,Uom,Qty,Freeze,ADDDATETIME,ADDUSERID  From VIEW_PARTY_HALLDETAILS   where hallcode='" & txthallcode.Text & "'"
                    gconnection.getDataSet(sqlstring, "HallMaster")
                    If gdataset.Tables("HallMaster").Rows.Count > 0 Then
                        SSGRID.ClearRange(-1, -1, 1, 1, True)
                        SSGRID.SetActiveCell(1, 1)
                        With SSGRID
                            For i = 0 To gdataset.Tables("HallMaster").Rows.Count - 1
                                .Col = 1
                                .Row = i + 1
                                .Text = Trim(gdataset.Tables("HallMaster").Rows(i).Item("itemdescription"))
                                .Col = 2
                                .Row = i + 1
                                .Text = Trim(gdataset.Tables("HallMaster").Rows(i).Item("uom"))
                                .Col = 3
                                .Row = i + 1
                                .Text = Val(gdataset.Tables("HallMaster").Rows(i).Item("qty"))
                            Next
                            .SetActiveCell(1, 1)
                        End With
                    End If
                    Me.txthallcode.ReadOnly = True
                    Me.cmdhallHelp.Enabled = False
                    Me.txthalldescription.Focus()
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Add.Text = "Add [F7]"
                    txthallcode.ReadOnly = False
                    txthalldescription.Focus()
                End If
            Else
                txthallcode.Text = ""
                txthalldescription.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
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
        Cmd_View.Enabled = False
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
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strsql, Insert(0) As String
        Dim qty As Integer
        Dim uom, itemdesc As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            strsql = "Insert Into Party_HallMaster (Hallcode,Halldescription,Halltype,cgroupcode,"
            strsql = strsql & "Occupancy,Description,Hallamount,Itemtypecode,Freeze,Adduserid,Adddatetime)"
            strsql = strsql & " Values ( '" & Trim(txthallcode.Text) & "',"
            strsql = strsql & "'" & Trim(txthalldescription.Text) & "',"
            strsql = strsql & "'" & Trim(Txthalltype.Text) & "',"
            strsql = strsql & "'" & Trim(TXTCGROUPCODE.Text) & "',"
            strsql = strsql & Val(txtoccupancy.Text) & ","
            strsql = strsql & "'" & Trim(TXTDESCRIPTION.Text) & "'," & Trim(TXTHALLRENT.Text) & ",'" & Trim(txtItemType.Text) & "','N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            Insert(0) = strsql
            With SSGRID
                For i = 1 To SSGRID.DataRowCnt
                    uom = "" : itemdesc = "" : qty = 0 : sqlstring = ""
                    .Row = i
                    .Col = 1
                    itemdesc = Trim(.Text)
                    .Row = i
                    .Col = 2
                    uom = Trim(.Text)
                    sqlstring = " Select Uomcode from Uommaster Where Uomdesc='" & uom & "'"
                    dt = gconnection.GetValues(sqlstring)
                    If dt.Rows.Count Then
                        uom = dt.Rows(0).Item("uomcode")
                    Else
                        uom = ""
                    End If
                    .Row = i
                    .Col = 3
                    qty = Trim(.Text)
                    sqlstring = "Insert Into PARTY_HALLDETAILS(Hallcode,Itemcode,Itemdescription,Uom,Qty,Freeze,Adduserid,Adddatetime)"
                    sqlstring = sqlstring & " values('" & Trim(txthallcode.Text) & "',"
                    sqlstring = sqlstring & " '',"
                    sqlstring = sqlstring & " '" & itemdesc & "',"
                    sqlstring = sqlstring & " '" & uom & "',"
                    sqlstring = sqlstring & " " & IIf(qty > 0, qty, 0) & ","
                    sqlstring = sqlstring & " 'N'" & ","
                    sqlstring = sqlstring & " '" & Trim(gUsername) & "',"
                    sqlstring = sqlstring & " '" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                Next
            End With
            'gconnection.MoreTrans(Insert)
            gconnection.dataOperation1(1, Insert)
            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                    boolchk = False
                End If
            End If
            strsql = "Update  Party_HallMaster "
            strsql = strsql & " Set HallDescription='" & Trim(txthalldescription.Text) & "',"
            strsql = strsql & " Occupancy=" & Trim(txtoccupancy.Text) & ","
            strsql = strsql & " Halltype='" & Trim(Txthalltype.Text) & "',"
            strsql = strsql & " Itemtypecode='" & Trim(txtItemType.Text) & "',"
            strsql = strsql & " cgroupcode='" & Trim(TXTCGROUPCODE.Text) & "',"
            strsql = strsql & " Description='" & Trim(TXTDESCRIPTION.Text) & "',"
            strsql = strsql & " Hallamount=" & Trim(TXTHALLRENT.Text) & ","
            strsql = strsql & " AddUserID='" & Trim(gUsername) & "',"
            strsql = strsql & " AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N' "
            strsql = strsql & " Where hallcode='" & txthallcode.Text & "'"
            Insert(0) = strsql
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            strsql = " Delete From PARTY_HALLDETAILS Where Hallcode='" & txthallcode.Text & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = strsql
            With SSGRID
                For i = 1 To SSGRID.DataRowCnt
                    uom = "" : itemdesc = "" : qty = 0 : sqlstring = ""
                    .Row = i
                    .Col = 1
                    itemdesc = IIf(Len(Trim(.Text)) > 0, Trim(.Text), "")
                    .Row = i
                    .Col = 2
                    uom = IIf(Len(Trim(.Text)) > 0, Trim(.Text), "")
                    sqlstring = " select uomcode from uommaster where uomdesc='" & uom & "'"
                    dt = gconnection.GetValues(sqlstring)
                    If dt.Rows.Count Then
                        uom = dt.Rows(0).Item("uomcode")
                    Else
                        uom = ""
                    End If
                    .Row = i
                    .Col = 3
                    qty = IIf(Len(Trim(.Text)) > 0, Trim(.Text), 0)
                    sqlstring = "Insert Into PARTY_HALLDETAILS(Hallcode,Itemcode,Itemdescription,Uom,Qty,Freeze,Adduserid,                        Adddatetime)"
                    sqlstring = sqlstring & " values('" & Trim(txthallcode.Text) & "',"
                    sqlstring = sqlstring & " '',"
                    sqlstring = sqlstring & " '" & itemdesc & "',"
                    sqlstring = sqlstring & " '" & uom & "',"
                    sqlstring = sqlstring & " " & IIf(qty > 0, qty, 0) & ","
                    sqlstring = sqlstring & " 'N'" & ","
                    sqlstring = sqlstring & " '" & Trim(gUsername) & "',"
                    sqlstring = sqlstring & " '" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                Next
            End With
            'gconnection.MoreTrans(Insert)
            gconnection.dataOperation1(2, Insert)
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        If Trim(txthallcode.Text) = "" Then
            MessageBox.Show(" Hall Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txthallcode.Focus()
            Exit Sub
        End If
        If Trim(txthalldescription.Text) = "" Then
            MessageBox.Show(" Hall Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txthalldescription.Focus()
            Exit Sub
        End If
        If Val(txtoccupancy.Text) <= 0 Then
            MessageBox.Show(" Occupancy can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtoccupancy.Focus()
            Exit Sub
        End If
        If Trim(TXTDESCRIPTION.Text) = "" Then
            MessageBox.Show("Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txthalldescription.Focus()
            Exit Sub
        End If
        If Trim(txthalldescription.Text) = "" Then
            MessageBox.Show(" Hall Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txthalldescription.Focus()
            Exit Sub
        End If
        If Val(TXTHALLRENT.Text) <= 0 Then
            MessageBox.Show(" Hall Rent can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txthalldescription.Focus()
            Exit Sub
        End If
        If Trim(txtItemType.Text) = "" Then
            MessageBox.Show("Item type Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtItemType.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub menumaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        Call clearoperaction()
        grp_HALLdetails.Visible = False
        grp_HALLdetails.Top = 80
        grp_HALLdetails.Top = 128
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txthallcode.Focus()
    End Sub
    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation()
        Dim strsql, Insert(0) As String
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            sqlstring = "UPDATE  Party_HallMaster "
            sqlstring = sqlstring & " SET Freeze= 'Y',AddUserid='" & gUsername & " ', "
            sqlstring = sqlstring & " AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE hallCode = '" & Trim(txthallcode.Text) & "'"
            Insert(0) = sqlstring
            sqlstring = "UPDATE  PARTY_HALLDETAILS "
            sqlstring = sqlstring & " SET Freeze= 'Y',AddUserid='" & gUsername & " ', "
            sqlstring = sqlstring & " AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE hallCode = '" & Trim(txthallcode.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            gconnection.dataOperation1(3, Insert)
        Else
            sqlstring = "UPDATE  Party_HallMaster "
            sqlstring = sqlstring & " SET Freeze= 'N',AddUserid='" & gUsername & " ', "
            sqlstring = sqlstring & " AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE hallCode = '" & Trim(txthallcode.Text) & "'"
            Insert(0) = sqlstring
            sqlstring = "UPDATE  PARTY_HALLDETAILS "
            sqlstring = sqlstring & " SET Freeze= 'N',AddUserid='" & gUsername & " ', "
            sqlstring = sqlstring & " AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE hallCode = '" & Trim(txthallcode.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring
            gconnection.dataOperation1(4, Insert)
        End If
        Me.Cmd_Clear_Click(sender, e)
        Cmd_Add.Text = "Add [F7]"
    End Sub
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        grp_HALLdetails.Visible = True
        grp_HALLdetails.Top = 80
        grp_HALLdetails.Top = 144
        CMDSCREEN.Focus()
    End Sub
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Hide()
    End Sub
    Private Sub txthallcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthallcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txthallcode.Text) <> "" Then
                Call txthallcode_Validated(txthallcode, e)
                txthalldescription.Focus()
            Else
                Call cmdhallHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txthalldescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthalldescription.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txthalltype.Focus()
        End If
    End Sub
    Private Sub txtoccupancy_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtoccupancy.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            txtItemType.Focus()
        End If
    End Sub
    Private Sub txthalltype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txthalltype.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtoccupancy.Focus()
        End If
    End Sub
    Private Sub menumaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub
    Private Sub txtsplamt3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            TXTHALLRENT.Focus()
        End If
    End Sub
    Private Sub TXTHALLRENT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTHALLRENT.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            TXTDESCRIPTION.Focus()
        End If
    End Sub
    Private Sub TXTDESCRIPTION_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDESCRIPTION.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SSGRID.Focus()
        End If
    End Sub
    Private Sub TXTHALLRENT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTHALLRENT.LostFocus
        TXTHALLRENT.Text = Format(Val(TXTHALLRENT.Text), "0.00")
    End Sub
    Private Sub txtItemType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemType.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTCGROUPCODE.Focus()
        End If
    End Sub
    Private Sub txtTypedes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTypedes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTHALLRENT.Focus()
        End If
    End Sub
    Private Sub SSGRID_TabScrolled(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_TabScrolledEvent) Handles SSGRID.TabScrolled
        Cmd_Add.Focus()
    End Sub
    Private Sub clearoperaction()
        txtTypedes.ReadOnly = False
        TXTHALLRENT.Text = ""
        TXTCGROUPCODE.Text = ""
        TXTCGROUPDESC.Text = ""
        txtoccupancy.Text = ""
        TXTHALLRENT.Text = Format(Val(TXTHALLRENT.Text), "0.00")
        txtoccupancy.Text = Format(Val(txtoccupancy.Text), "0")
        txthallcode.Text = ""
        txthalldescription.Text = ""
        txthallcode.Focus()
        TXTDESCRIPTION.Text = ""
        txtItemType.Text = ""
        txtTypedes.Text = ""
        SSGRID.ClearRange(-1, -1, 1, 1, True)
        SSGRID.SetActiveCell(1, 1)
        txthallcode.Focus()
        Txthalltype.SelectedIndex = 0
        txtTypedes.ReadOnly = True
    End Sub
    Private Sub txtoccupancy_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtoccupancy.LostFocus
        txtoccupancy.Text = Format(Val(txtoccupancy.Text), "0")
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
        vform.vFormatstring = " ITEM TYPE CODE |  ITEM TYPE DESCRIPTION  "
        vform.vCaption = "ITEM TYPE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txtItemType.Text = Trim(vform.keyfield & "")
            Call txtItemType_Validated(txtItemType, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txtItemType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemType.Validated
        If txtItemType.Text <> "" Then
            ssql = "SELECT ItemTypeDesc FROM ItemTypeMaster WHERE ItemTypeCode='" & Trim(txtItemType.Text) & "' AND ISNULL(Freeze,'') <> 'Y'"
            vconn.getDataSet(ssql, "ItemTypeMaster")
            If gdataset.Tables("ItemTypeMaster").Rows.Count > 0 Then
                txtTypedes.Text = ""
                txtTypedes.Text = Trim(gdataset.Tables("ItemTypeMaster").Rows(0).Item("ItemTypeDesc"))
                txtTypedes.ReadOnly = True
                TXTCGROUPCODE.Focus()
            Else
                txtItemType.Clear()
                txtTypedes.Clear()
                txtItemType.Focus()
            End If
        Else
            txtTypedes.Clear()
        End If
    End Sub

    Private Sub txthallcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthallcode.TextChanged

    End Sub

    Private Sub txtItemType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemType.TextChanged

    End Sub
    Private Sub txthallcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txthallcode.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmdhallHelp_Click(sender, e)
        End If
        If e.KeyCode = Keys.F4 Then
            If txthallcode.Text = "" Then
                Call cmdhallHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txtItemType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemType.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmdType_Click(sender, e)
        End If
        If e.KeyCode = Keys.Enter Then
            If txtItemType.Text = "" Then
                Call cmdType_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub SSGRID_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID.KeyDownEvent
        Try
            If e.keyCode = Keys.Enter Then
                With SSGRID
                    If SSGRID.ActiveCol = 1 Then
                        .Col = 1
                        .Row = .ActiveRow
                        If Trim(.Text) = "" Then
                            .SetActiveCell(1, .ActiveRow)
                        Else
                            .SetActiveCell(2, .ActiveRow)
                        End If
                    ElseIf .ActiveCol = 2 Then
                        .Col = 2
                        .Row = .ActiveRow
                        If Trim(.Text) = "" Then
                            .SetActiveCell(2, .ActiveRow)
                        Else
                            ssql = " SELECT ISNULL(UOMCODE,'') AS UOMCODE,ISNULL(UOMDESC,'') AS UOMDESC FROM "
                            ssql = ssql & " UOMMaster where uomdesc='" & Trim(.Text) & "'"
                            dt = gconnection.GetValues(ssql)
                            If dt.Rows.Count = 0 Then
                                .Text = ""
                                .SetActiveCell(2, .ActiveRow)
                            Else
                                .SetActiveCell(3, .ActiveRow)
                            End If
                        End If
                    Else
                        .Col = 3
                        .Row = .ActiveRow
                        If Val(.Text) = 0 Then
                            .SetActiveCell(3, .ActiveRow)
                        Else
                            .SetActiveCell(1, .ActiveRow + 1)
                        End If
                    End If
                End With
            End If
            If e.keyCode = Keys.F3 Then
                SSGRID.Row = SSGRID.ActiveRow
                SSGRID.DeleteRows(SSGRID.ActiveRow, 1)
                If SSGRID.ActiveRow <= 1 Then
                    SSGRID.SetActiveCell(1, SSGRID.ActiveRow)
                Else
                    SSGRID.SetActiveCell(1, SSGRID.ActiveRow - 1)
                End If
            End If
            If e.keyCode = Keys.F4 Then
                If SSGRID.ActiveCol = 1 Then
                    Dim vform As New ListOperattion1
                    gSQLString = " SELECT ITEMDESCRIPTION,UOM FROM VIEW_PARTY_HELPHALLFACILITY"
                    If Trim(Search) = "" Then
                        M_WhereCondition = ""
                    Else
                        M_WhereCondition = ""
                    End If
                    vform.Field = "ITEMDESCRIPTION,UOM"
                    vform.vFormatstring = "ITEMDESCRIPTION       |  UOM       "
                    vform.vCaption = "HALL DETAILS HELP"
                    vform.KeyPos = 0
                    vform.KeyPos1 = 1
                    vform.ShowDialog(Me)
                    If Trim(vform.keyfield & "") <> "" Then
                        With SSGRID
                            .Col = 1
                            .Row = SSGRID.ActiveRow
                            .Text = ""
                            .Text = Trim(vform.keyfield & "")
                            .SetActiveCell(2, SSGRID.ActiveRow)
                            .Col = 2
                            .Row = SSGRID.ActiveRow
                            .Text = ""
                            .Text = Trim(vform.keyfield1 & "")
                            .SetActiveCell(3, SSGRID.ActiveRow)
                            .Col = 3
                            .Row = SSGRID.ActiveRow
                        End With
                    End If
                    vform.Close()
                    vform = Nothing
                ElseIf SSGRID.ActiveCol = 2 Then
                    Dim vform As New ListOperattion1
                    gSQLString = " SELECT ISNULL(UOMCODE,'') AS UOMCODE,ISNULL(UOMDESC,'') AS UOMDESC FROM UOMMASTER"
                    If Trim(Search) = " " Then
                        M_WhereCondition = ""
                    Else
                        M_WhereCondition = ""
                    End If
                    vform.Field = "UOMCODE,UOMDESC"
                    vform.vFormatstring = " UOMCODE            |     DESCRIPTION               "
                    vform.vCaption = "HALL DETAILS HELP"
                    vform.KeyPos = 0
                    vform.KeyPos1 = 1
                    vform.ShowDialog(Me)
                    If Trim(vform.keyfield & "") <> "" Then
                        With SSGRID
                            .Col = 2
                            .Row = SSGRID.ActiveRow
                            .Text = ""
                            .Text = Trim(vform.keyfield1 & "")
                            .SetActiveCell(3, SSGRID.ActiveRow)
                            .Col = 3
                            .Row = SSGRID.ActiveRow
                            .Text = ""
                        End With
                    End If
                    vform.Close()
                    vform = Nothing
                Else
                    SSGRID.SetActiveCell(1, SSGRID.ActiveRow + 1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function Rooms_and_facility()
        Dim Desc As String
        Dim Pno, pagesize As Integer
        Try
            Dim dt As New DataTable
            Rnd()
            vOutfile = Mid("Out" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            Pno = 0
            Pno = Pno + 1
            sqlstring = "SELECT HALLCODE,HALLDESCRIPTION,ITEMCODE,ITEMDESCRIPTION,UOM,QTY,ADDDATETIME,ADDUSERID,"
            sqlstring = sqlstring & " FREEZE FROM VIEW_PARTY_HALLMASTER   ORDER BY HALLCODE"
            dt = gconnection.GetValues(sqlstring)
            Filewrite.WriteLine(Chr(15) & Chr(27) + "E" & gCompanyAddress(0) & Chr(27) + "F")
            Filewrite.Write(Chr(27) + "E" & "HALL FACILITY" & Chr(27) + "F" & Space(50) & "Page No:")
            Filewrite.WriteLine(Trim(CStr(Pno)))
            Filewrite.WriteLine("|" & StrDup(78, "-") & "|")
            Filewrite.WriteLine("|DESCRIPTION                                           UOM            QTY      |")
            Filewrite.WriteLine("|" & StrDup(78, "-") & "|")
            Desc = ""
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    If Desc <> Trim(dt.Rows(i).Item("Hallcode")) Then
                        Filewrite.WriteLine("|" & Space(78) & "|")
                        sqlstring = "|" & Space(2) & Mid(Trim(dt.Rows(i).Item("hallcode")), 1, 15)
                        sqlstring = sqlstring & Space(15 - Len(Mid(Trim(dt.Rows(i).Item("hallcode")), 1, 15)))
                        sqlstring = sqlstring & Mid(Trim(dt.Rows(i).Item("halldescription")), 1, 30)
                        sqlstring = sqlstring & Space(30 - Len(Mid(Trim(dt.Rows(i).Item("halldescription")), 1, 30)))
                        sqlstring = sqlstring & Space(31) & "|"
                        Filewrite.WriteLine(Chr(27) & "E" & sqlstring & Chr(27) & "F")
                        Filewrite.WriteLine("|" & Space(78) & "|")
                        Desc = Trim(dt.Rows(i).Item("Hallcode"))
                    End If
                    sqlstring = "|" & Space(2) & Mid(Trim(dt.Rows(i).Item("itemdescription")), 1, 45)
                    sqlstring = sqlstring & Space(45 - Len(Mid(Trim(dt.Rows(i).Item("itemdescription")), 1, 45)))
                    sqlstring = sqlstring & Space(7) & Mid(Trim(dt.Rows(i).Item("uom")), 1, 10)
                    sqlstring = sqlstring & Space(10 - Len(Mid(Trim(dt.Rows(i).Item("uom")), 1, 10)))
                    sqlstring = sqlstring & Space(10 - Len(Mid(Format(dt.Rows(i).Item("qty"), "0"), 1, 10)))
                    sqlstring = sqlstring & Mid(Format(dt.Rows(i).Item("qty"), "0"), 1, 10) & Space(4) & "|"
                    Filewrite.WriteLine(sqlstring)
                    pagesize = pagesize + 1
                    If pagesize = 60 Then
                        Filewrite.WriteLine("|" & StrDup(78, "=") & "|")
                        Filewrite.WriteLine(Chr(15) & Chr(27) + "E" & gCompanyAddress(0) & Chr(27) + "F" & Chr(12))
                        Filewrite.Write(Chr(27) + "E" & "HALL FACILITY" & Chr(27) + "F" & Space(50) & "Page No:")
                        Filewrite.WriteLine(Trim(CStr(Pno)))
                        pagesize = pagesize + 1
                    End If
                Next
                Filewrite.WriteLine("|" & StrDup(78, "=") & "|")
            Else
                MessageBox.Show("NO RECORDS FOUND TO DISPLAY..")
                Exit Function
            End If
            Filewrite.Close()
            If PRINTREP = False Then
                PrintTextFile(vOutfile)
            Else
                PrintTextFile(vOutfile)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Function Rooms()
        Dim page, pagesize, pno As Integer
        Try
            Dim dt As New DataTable
            sqlstring = "SELECT HALLCODE,HALLDESCRIPTION,OCCUPANCY,HALLTYPE,HALLAMOUNT,DESCRIPTION,FREEZE,ADDDATETIME,"
            sqlstring = sqlstring & "ADDUSERID,ITEMTYPECODE FROM VIEW_PARTY_HALLMASTER  "
            dt = gconnection.GetValues(sqlstring)
            pno = 0
            pno = pno + 1
            If dt.Rows.Count > 0 Then
                vOutfile = Mid("Out" & (Rnd() * 800000), 1, 8)
                VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
                Filewrite = File.AppendText(VFilePath)
                Filewrite.WriteLine(Chr(15) & Chr(27) + "E" & gCompanyAddress(0) & Chr(27) + "F")
                Filewrite.Write(Chr(27) + "E" & "HALL DETAILS" & Chr(27) + "F" & Space(50) & "Page No:")
                Filewrite.WriteLine(Trim(CStr(pno)))
                Filewrite.WriteLine("|" & StrDup(78, "=") & "|")
                sqlstring = "|  HALLCODE" & Space(17) & "DESCRIPTION" & Space(40) & "|"
                Filewrite.WriteLine(sqlstring)
                Filewrite.WriteLine("|" & StrDup(78, "=") & "|")
                For i = 0 To dt.Rows.Count - 1
                    If pagesize = 65 Then
                        Filewrite.WriteLine("|" & StrDup(78, "=") & "|" & Chr(12))
                        pno = pno + 1
                        Filewrite.WriteLine(Chr(15) & Chr(27) + "E" & gCompanyAddress(0) & Chr(27) + "F")
                        Filewrite.Write(Chr(27) + "E" & "HALL DETAILS" & Chr(27) + "F" & Space(50) & "Page No:")
                        Filewrite.WriteLine(Trim(CStr(pno)))
                        Filewrite.WriteLine("|" & StrDup(78, "=") & "|")
                        sqlstring = "|  HALLCODE" & Space(17) & "DESCRIPTION" & Space(40) & "|"
                        Filewrite.WriteLine(sqlstring)
                        Filewrite.WriteLine("|" & StrDup(78, "=") & "|")
                        pagesize = 1
                    End If
                    sqlstring = "|" & Space(2) & Mid(dt.Rows(i).Item("HALLCODE"), 1, 10)
                    sqlstring = sqlstring & Space(10 - Len(Mid(dt.Rows(i).Item("HALLCODE"), 1, 10)))
                    sqlstring = sqlstring & Space(15) & Mid(dt.Rows(i).Item("Halldescription"), 1, 30)
                    sqlstring = sqlstring & Space(30 - Len(Mid(dt.Rows(i).Item("Halldescription"), 1, 30)))
                    sqlstring = sqlstring & Space(21) & "|"
                    Filewrite.WriteLine(sqlstring)

                    sqlstring = "|" & Space(27) & Mid(dt.Rows(i).Item("halltype"), 1, 30)
                    sqlstring = sqlstring & Space(30 - Len(Mid(dt.Rows(i).Item("halltype"), 1, 30))) & Space(21) & "|"
                    Filewrite.WriteLine(sqlstring)

                    sqlstring = "|" & Space(27) & "OCCUPANCY :" & Mid(Format(dt.Rows(i).Item("OCCUPANCY"), "0"), 1, 5)
                    sqlstring = sqlstring & Space(5 - Len(Mid(Format(dt.Rows(i).Item("OCCUPANCY"), "0"), 1, 5)))
                    sqlstring = sqlstring & Space(35) & "|"
                    Filewrite.WriteLine(sqlstring)

                    sqlstring = "|" & Space(27) & Mid(dt.Rows(i).Item("description"), 1, 30)
                    sqlstring = sqlstring & Space(30 - Len(Mid(dt.Rows(i).Item("description"), 1, 30)))
                    sqlstring = sqlstring & Space(21) & "|"
                    Filewrite.WriteLine(sqlstring)

                    sqlstring = "|" & Space(27) & Mid(Format(dt.Rows(i).Item("Hallamount"), "0.00"), 1, 10)
                    sqlstring = sqlstring & Space(10 - Len(Mid(Format(dt.Rows(i).Item("Hallamount"), "0.00"), 1, 10)))
                    sqlstring = sqlstring & Space(41) & "|"
                    Filewrite.WriteLine(sqlstring)
                    Filewrite.WriteLine("|" & StrDup(78, "-") & "|")
                    page = page + 6
                Next
            Else
                MessageBox.Show("NO RECORDS FOUND TO DISPLAY..")
                Exit Function
            End If
            Filewrite.Close()
            If PRINTREP = False Then
                PrintTextFile(vOutfile)
            Else
                PrintTextFile(vOutfile)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        grp_HALLdetails.Visible = False
        Cmd_View.Focus()
    End Sub
    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        gPrint = True
        If RDBHALLWF.Checked = True Then
            Rooms_and_facility()
        Else
            Call Rooms()
        End If
    End Sub
    Private Sub CMDSCREEN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSCREEN.Click
        gPrint = False
        If RDBHALLWF.Checked = True Then
            Dim FrReport As New ReportDesigner
            tables = " FROM VIEW_PARTY_VIEWHALLFACILITY   "
            Gheader = " HALL FACILITY "
            FrReport.SsGridReport.SetText(2, 1, "HALLCODE")
            FrReport.SsGridReport.SetText(3, 1, 10)
            FrReport.SsGridReport.SetText(2, 2, "HALLDESCRIPTION")
            FrReport.SsGridReport.SetText(3, 2, 25)
            FrReport.SsGridReport.SetText(2, 3, "ITEMDESCRIPTION")
            FrReport.SsGridReport.SetText(3, 3, 30)
            FrReport.SsGridReport.SetText(2, 4, "UOM")
            FrReport.SsGridReport.SetText(3, 4, 7)
            FrReport.SsGridReport.SetText(2, 5, "QTY")
            FrReport.SsGridReport.SetText(3, 5, 5)
            FrReport.SsGridReport.SetText(2, 6, "FREEZE")
            FrReport.SsGridReport.SetText(3, 6, 6)
            FrReport.Show()
        Else
            Dim FrReport As New ReportDesigner
            tables = " FROM VIEW_PARTY_HALLMASTER  "
            Gheader = " HALL DETAILS "
            FrReport.SsGridReport.SetText(2, 1, "HALLCODE")
            FrReport.SsGridReport.SetText(3, 1, 10)
            FrReport.SsGridReport.SetText(2, 2, "HALLDESCRIPTION")
            FrReport.SsGridReport.SetText(3, 2, 30)
            FrReport.SsGridReport.SetText(2, 3, "OCCUPANCY")
            FrReport.SsGridReport.SetText(3, 3, 10)
            FrReport.SsGridReport.SetText(2, 4, "HALLTYPE")
            FrReport.SsGridReport.SetText(3, 4, 10)
            FrReport.SsGridReport.SetText(2, 5, "DESCRIPTION")
            FrReport.SsGridReport.SetText(3, 5, 40)
            FrReport.SsGridReport.SetText(2, 6, "FREEZE")
            FrReport.SsGridReport.SetText(3, 6, 6)
            FrReport.Show()
        End If
    End Sub
    Private Sub SSGRID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles SSGRID.Leave
        With SSGRID
            If .Col = 2 Then
                sqlstring = "Select * from uommaster where uomcode='" & Trim(.Text) & "'"
                dt = gconnection.GetValues(sqlstring)
                If Not dt.Rows.Count Then
                    MessageBox.Show("This Uom Code Not Found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    .SetActiveCell(2, SSGRID.ActiveRow)
                    .Text = ""

                End If
            End If
        End With
    End Sub
    Private Sub SSGRID_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles SSGRID.LeaveCell
        With SSGRID
            If .ActiveCol = 1 Then
                .Col = 1
                .Row = .ActiveRow
                If Trim(.Text()) = "" Then
                    '.Focus()
                End If
            End If
            If .ActiveCol = 2 Then
                .Col = 2
                .Row = .ActiveRow
                ssql = " SELECT ISNULL(UOMCODE,'') AS UOMCODE,ISNULL(UOMDESC,'') AS UOMDESC FROM "
                ssql = ssql & " UOMMaster where uomdesc='" & Trim(.Text) & "'"
                dt = gconnection.GetValues(ssql)
                If dt.Rows.Count = 0 Then
                    '.Focus()
                End If
            End If
            If .ActiveCol = 3 Then
                .Col = 3
                .Row = .ActiveRow
                If Val(.Text()) = 0 Then
                    '.Focus()
                End If
            End If
        End With
    End Sub
    Private Sub SSGRID_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSGRID.Advance
    End Sub

    Private Sub TXTCGROUPCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTCGROUPCODE.TextChanged

    End Sub

    Private Sub TXTCGROUPCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCGROUPCODE.Validated
        If TXTCGROUPCODE.Text <> "" Then
            sqlstring = " SELECT ITEMTYPECODE,ITEMDESC FROM VIEW_PARTY_GROUPMASTER  WHERE ItemTypeCode='" & Trim(TXTCGROUPCODE.Text) & "'"
            vconn.getDataSet(sqlstring, "ItemTypeMaster")
            If gdataset.Tables("ItemTypeMaster").Rows.Count > 0 Then
                TXTCGROUPDESC.Text = ""
                TXTCGROUPDESC.Text = Trim(gdataset.Tables("ItemTypeMaster").Rows(0).Item("ITEMDesc"))
                TXTCGROUPDESC.ReadOnly = True
                TXTHALLRENT.Focus()
            Else
                TXTCGROUPCODE.Clear()
                TXTCGROUPCODE.Focus()
            End If
        Else
            TXTCGROUPDESC.Clear()
        End If

    End Sub
    Private Sub TXTCGROUPCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCGROUPCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTHALLRENT.Focus()
        End If
    End Sub
    Private Sub TXTCGROUPCODE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTCGROUPCODE.KeyDown
        If e.KeyCode = Keys.F4 Then
            CGROUPHELP_Click(sender, e)
        End If
        If e.KeyCode = Keys.Enter Then
            If TXTCGROUPCODE.Text = "" Then
                CGROUPHELP_Click(sender, e)
            End If
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
        vform.vFormatstring = " ITEM TYPE CODE | ITEM TYPE DESCRIPTION   "
        vform.vCaption = "ITEM TYPE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXTCGROUPCODE.Text = Trim(vform.keyfield & "")
            Call TXTCGROUPCODE_Validated(TXTCGROUPCODE, e)
            TXTHALLRENT.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
End Class
