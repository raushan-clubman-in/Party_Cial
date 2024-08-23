Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Public Class itemmst
    Inherits System.Windows.Forms.Form
    Dim boolchk As Boolean
    Dim vseqno As Double
    Dim TempString(3) As String
    Dim sqlstring, ssql As String
    Dim gconnection, vconn As New GlobalClass
    Dim i, j, k As Integer
    Friend WithEvents OPENFACILITY As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents CMD_EXIT As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmd_view As System.Windows.Forms.Button
    Friend WithEvents CMD_FREEZE As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TXT_SUBGROUPDESC As System.Windows.Forms.TextBox
    Friend WithEvents TXT_SUBGROUPCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cmdKitchenHelp As System.Windows.Forms.Button
    Friend WithEvents cmdType As System.Windows.Forms.Button
    Friend WithEvents CMDSUBCODE As System.Windows.Forms.Button
    Friend WithEvents cmdGroup As System.Windows.Forms.Button
    Dim dt As New DataTable
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
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TXTITEMCODE_HELP As System.Windows.Forms.Button
    Friend WithEvents TXTITEMDESC As System.Windows.Forms.TextBox
    Friend WithEvents TXTITEMCODE As System.Windows.Forms.TextBox
    Friend WithEvents TXTTYPEMCODE_HELP As System.Windows.Forms.Button
    Friend WithEvents TXTGROUPCODE_HELP As System.Windows.Forms.Button
    Friend WithEvents TXTGROUPDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents TXTGROUPCODE As System.Windows.Forms.TextBox
    Friend WithEvents TXTUOMCODE_HELP As System.Windows.Forms.Button
    Friend WithEvents TXTRATE As System.Windows.Forms.TextBox
    Friend WithEvents TXTUOMCODE As System.Windows.Forms.TextBox
    Friend WithEvents TXTUOMDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Clear12 As System.Windows.Forms.Button
    Friend WithEvents Cmd_View2 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze54 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add1 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit5 As System.Windows.Forms.Button
    Friend WithEvents txtItemType As System.Windows.Forms.TextBox
    Friend WithEvents txtTypedes As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grp_HALLdetails As System.Windows.Forms.GroupBox
    Friend WithEvents CMDSCREEN As System.Windows.Forms.Button
    Friend WithEvents CMDPRINT As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CHKMENUGROUP As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chk_SELECTALL As System.Windows.Forms.CheckBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TXTCGROUPCODE As System.Windows.Forms.TextBox
    Friend WithEvents CGROUPHELP As System.Windows.Forms.Button
    Friend WithEvents TXTCGROUPDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CMD_GLACCODE As System.Windows.Forms.Button
    Friend WithEvents TXT_GLACCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents OptNo As System.Windows.Forms.RadioButton
    Friend WithEvents optYes As System.Windows.Forms.RadioButton
    Friend WithEvents LBL_CATEGORY As System.Windows.Forms.Label
    Friend WithEvents CMBCATEGORY As System.Windows.Forms.ComboBox
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CMB_TYPE As System.Windows.Forms.ComboBox
    Friend WithEvents LST_TAX As System.Windows.Forms.CheckedListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(itemmst))
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXTITEMCODE_HELP = New System.Windows.Forms.Button()
        Me.TXTITEMDESC = New System.Windows.Forms.TextBox()
        Me.TXTITEMCODE = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTTYPEMCODE_HELP = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTGROUPCODE_HELP = New System.Windows.Forms.Button()
        Me.TXTGROUPDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.TXTGROUPCODE = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TXTUOMCODE_HELP = New System.Windows.Forms.Button()
        Me.TXTRATE = New System.Windows.Forms.TextBox()
        Me.TXTUOMCODE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cmdType = New System.Windows.Forms.Button()
        Me.CMDSUBCODE = New System.Windows.Forms.Button()
        Me.cmdGroup = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TXT_SUBGROUPDESC = New System.Windows.Forms.TextBox()
        Me.TXT_SUBGROUPCODE = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.OPENFACILITY = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CMB_TYPE = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LBL_CATEGORY = New System.Windows.Forms.Label()
        Me.CMBCATEGORY = New System.Windows.Forms.ComboBox()
        Me.TXTUOMDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtItemType = New System.Windows.Forms.TextBox()
        Me.cmdKitchenHelp = New System.Windows.Forms.Button()
        Me.CMD_GLACCODE = New System.Windows.Forms.Button()
        Me.TXT_GLACCODE = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.OptNo = New System.Windows.Forms.RadioButton()
        Me.optYes = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTypedes = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TXTCGROUPCODE = New System.Windows.Forms.TextBox()
        Me.CGROUPHELP = New System.Windows.Forms.Button()
        Me.TXTCGROUPDESC = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Cmd_Clear12 = New System.Windows.Forms.Button()
        Me.Cmd_View2 = New System.Windows.Forms.Button()
        Me.Cmd_Freeze54 = New System.Windows.Forms.Button()
        Me.Cmd_Add1 = New System.Windows.Forms.Button()
        Me.Cmd_Exit5 = New System.Windows.Forms.Button()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.grp_HALLdetails = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Chk_SELECTALL = New System.Windows.Forms.CheckBox()
        Me.CHKMENUGROUP = New System.Windows.Forms.CheckedListBox()
        Me.CMDSCREEN = New System.Windows.Forms.Button()
        Me.CMDPRINT = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.LST_TAX = New System.Windows.Forms.CheckedListBox()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.CMD_EXIT = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.Cmd_view = New System.Windows.Forms.Button()
        Me.CMD_FREEZE = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grp_HALLdetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(172, 69)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(384, 29)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "ARRANGEMENT ITEM  MASTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TXTITEMCODE_HELP
        '
        Me.TXTITEMCODE_HELP.Image = CType(resources.GetObject("TXTITEMCODE_HELP.Image"), System.Drawing.Image)
        Me.TXTITEMCODE_HELP.Location = New System.Drawing.Point(108, 32)
        Me.TXTITEMCODE_HELP.Name = "TXTITEMCODE_HELP"
        Me.TXTITEMCODE_HELP.Size = New System.Drawing.Size(23, 26)
        Me.TXTITEMCODE_HELP.TabIndex = 1
        Me.TXTITEMCODE_HELP.Visible = False
        '
        'TXTITEMDESC
        '
        Me.TXTITEMDESC.BackColor = System.Drawing.Color.Wheat
        Me.TXTITEMDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTITEMDESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTITEMDESC.Location = New System.Drawing.Point(636, 189)
        Me.TXTITEMDESC.MaxLength = 50
        Me.TXTITEMDESC.Name = "TXTITEMDESC"
        Me.TXTITEMDESC.Size = New System.Drawing.Size(190, 26)
        Me.TXTITEMDESC.TabIndex = 2
        '
        'TXTITEMCODE
        '
        Me.TXTITEMCODE.BackColor = System.Drawing.Color.Wheat
        Me.TXTITEMCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTITEMCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTITEMCODE.Location = New System.Drawing.Point(331, 189)
        Me.TXTITEMCODE.Name = "TXTITEMCODE"
        Me.TXTITEMCODE.Size = New System.Drawing.Size(104, 26)
        Me.TXTITEMCODE.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(189, 189)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 15)
        Me.Label9.TabIndex = 363
        Me.Label9.Text = "ITEM CODE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(329, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 15)
        Me.Label5.TabIndex = 362
        Me.Label5.Text = "DESCRIPTION "
        '
        'TXTTYPEMCODE_HELP
        '
        Me.TXTTYPEMCODE_HELP.Image = CType(resources.GetObject("TXTTYPEMCODE_HELP.Image"), System.Drawing.Image)
        Me.TXTTYPEMCODE_HELP.Location = New System.Drawing.Point(108, 223)
        Me.TXTTYPEMCODE_HELP.Name = "TXTTYPEMCODE_HELP"
        Me.TXTTYPEMCODE_HELP.Size = New System.Drawing.Size(23, 26)
        Me.TXTTYPEMCODE_HELP.TabIndex = 4
        Me.TXTTYPEMCODE_HELP.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 368
        Me.Label1.Text = "TAX TYPE"
        '
        'TXTGROUPCODE_HELP
        '
        Me.TXTGROUPCODE_HELP.Image = CType(resources.GetObject("TXTGROUPCODE_HELP.Image"), System.Drawing.Image)
        Me.TXTGROUPCODE_HELP.Location = New System.Drawing.Point(108, 72)
        Me.TXTGROUPCODE_HELP.Name = "TXTGROUPCODE_HELP"
        Me.TXTGROUPCODE_HELP.Size = New System.Drawing.Size(23, 26)
        Me.TXTGROUPCODE_HELP.TabIndex = 7
        Me.TXTGROUPCODE_HELP.Visible = False
        '
        'TXTGROUPDESCRIPTION
        '
        Me.TXTGROUPDESCRIPTION.BackColor = System.Drawing.Color.Wheat
        Me.TXTGROUPDESCRIPTION.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGROUPDESCRIPTION.Location = New System.Drawing.Point(636, 229)
        Me.TXTGROUPDESCRIPTION.Name = "TXTGROUPDESCRIPTION"
        Me.TXTGROUPDESCRIPTION.ReadOnly = True
        Me.TXTGROUPDESCRIPTION.Size = New System.Drawing.Size(190, 26)
        Me.TXTGROUPDESCRIPTION.TabIndex = 4
        '
        'TXTGROUPCODE
        '
        Me.TXTGROUPCODE.BackColor = System.Drawing.Color.Wheat
        Me.TXTGROUPCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGROUPCODE.Location = New System.Drawing.Point(331, 229)
        Me.TXTGROUPCODE.Name = "TXTGROUPCODE"
        Me.TXTGROUPCODE.Size = New System.Drawing.Size(104, 26)
        Me.TXTGROUPCODE.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(189, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 15)
        Me.Label3.TabIndex = 373
        Me.Label3.Text = "GROUP CODE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(329, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 15)
        Me.Label4.TabIndex = 372
        Me.Label4.Text = "DESCRIPTION "
        '
        'TXTUOMCODE_HELP
        '
        Me.TXTUOMCODE_HELP.Image = CType(resources.GetObject("TXTUOMCODE_HELP.Image"), System.Drawing.Image)
        Me.TXTUOMCODE_HELP.Location = New System.Drawing.Point(108, 148)
        Me.TXTUOMCODE_HELP.Name = "TXTUOMCODE_HELP"
        Me.TXTUOMCODE_HELP.Size = New System.Drawing.Size(23, 26)
        Me.TXTUOMCODE_HELP.TabIndex = 13
        Me.TXTUOMCODE_HELP.Visible = False
        '
        'TXTRATE
        '
        Me.TXTRATE.BackColor = System.Drawing.Color.Wheat
        Me.TXTRATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRATE.Location = New System.Drawing.Point(331, 345)
        Me.TXTRATE.Name = "TXTRATE"
        Me.TXTRATE.Size = New System.Drawing.Size(104, 26)
        Me.TXTRATE.TabIndex = 9
        '
        'TXTUOMCODE
        '
        Me.TXTUOMCODE.BackColor = System.Drawing.Color.Wheat
        Me.TXTUOMCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUOMCODE.Location = New System.Drawing.Point(144, 150)
        Me.TXTUOMCODE.Name = "TXTUOMCODE"
        Me.TXTUOMCODE.Size = New System.Drawing.Size(104, 26)
        Me.TXTUOMCODE.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(189, 305)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 15)
        Me.Label6.TabIndex = 373
        Me.Label6.Text = "BASE UOM"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(189, 345)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 15)
        Me.Label7.TabIndex = 372
        Me.Label7.Text = "BASE RATE"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.cmdType)
        Me.GroupBox2.Controls.Add(Me.CMDSUBCODE)
        Me.GroupBox2.Controls.Add(Me.cmdGroup)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.TXT_SUBGROUPDESC)
        Me.GroupBox2.Controls.Add(Me.TXT_SUBGROUPCODE)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.OPENFACILITY)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.CMB_TYPE)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.LBL_CATEGORY)
        Me.GroupBox2.Controls.Add(Me.CMBCATEGORY)
        Me.GroupBox2.Controls.Add(Me.TXTUOMCODE)
        Me.GroupBox2.Controls.Add(Me.TXTUOMDESCRIPTION)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.TXTTYPEMCODE_HELP)
        Me.GroupBox2.Controls.Add(Me.txtItemType)
        Me.GroupBox2.Controls.Add(Me.TXTITEMCODE_HELP)
        Me.GroupBox2.Controls.Add(Me.TXTGROUPCODE_HELP)
        Me.GroupBox2.Controls.Add(Me.TXTUOMCODE_HELP)
        Me.GroupBox2.Location = New System.Drawing.Point(187, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(654, 274)
        Me.GroupBox2.TabIndex = 383
        Me.GroupBox2.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(249, 150)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 23)
        Me.Button2.TabIndex = 475
        Me.Button2.Text = "?"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(248, 225)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 23)
        Me.Button3.TabIndex = 474
        Me.Button3.Text = "?"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cmdType
        '
        Me.cmdType.Location = New System.Drawing.Point(249, 35)
        Me.cmdType.Name = "cmdType"
        Me.cmdType.Size = New System.Drawing.Size(40, 23)
        Me.cmdType.TabIndex = 473
        Me.cmdType.Text = "?"
        Me.cmdType.UseVisualStyleBackColor = True
        '
        'CMDSUBCODE
        '
        Me.CMDSUBCODE.Location = New System.Drawing.Point(249, 75)
        Me.CMDSUBCODE.Name = "CMDSUBCODE"
        Me.CMDSUBCODE.Size = New System.Drawing.Size(40, 23)
        Me.CMDSUBCODE.TabIndex = 471
        Me.CMDSUBCODE.Text = "?"
        Me.CMDSUBCODE.UseVisualStyleBackColor = True
        '
        'cmdGroup
        '
        Me.cmdGroup.Location = New System.Drawing.Point(249, 113)
        Me.cmdGroup.Name = "cmdGroup"
        Me.cmdGroup.Size = New System.Drawing.Size(40, 23)
        Me.cmdGroup.TabIndex = 470
        Me.cmdGroup.Text = "?"
        Me.cmdGroup.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(329, 120)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(87, 15)
        Me.Label20.TabIndex = 469
        Me.Label20.Text = "DESCRIPTION "
        '
        'TXT_SUBGROUPDESC
        '
        Me.TXT_SUBGROUPDESC.BackColor = System.Drawing.Color.Wheat
        Me.TXT_SUBGROUPDESC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_SUBGROUPDESC.Location = New System.Drawing.Point(449, 109)
        Me.TXT_SUBGROUPDESC.Name = "TXT_SUBGROUPDESC"
        Me.TXT_SUBGROUPDESC.ReadOnly = True
        Me.TXT_SUBGROUPDESC.Size = New System.Drawing.Size(190, 26)
        Me.TXT_SUBGROUPDESC.TabIndex = 6
        '
        'TXT_SUBGROUPCODE
        '
        Me.TXT_SUBGROUPCODE.BackColor = System.Drawing.Color.Wheat
        Me.TXT_SUBGROUPCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_SUBGROUPCODE.Location = New System.Drawing.Point(144, 109)
        Me.TXT_SUBGROUPCODE.Name = "TXT_SUBGROUPCODE"
        Me.TXT_SUBGROUPCODE.Size = New System.Drawing.Size(104, 26)
        Me.TXT_SUBGROUPCODE.TabIndex = 5
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(108, -44)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(142, 22)
        Me.Label18.TabIndex = 467
        Me.Label18.Text = "DESCRIPTION "
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(2, 109)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(110, 15)
        Me.Label19.TabIndex = 468
        Me.Label19.Text = "SUB GROUP CODE"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(108, 109)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(23, 26)
        Me.Button1.TabIndex = 466
        Me.Button1.Visible = False
        '
        'OPENFACILITY
        '
        Me.OPENFACILITY.BackColor = System.Drawing.Color.Wheat
        Me.OPENFACILITY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.OPENFACILITY.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OPENFACILITY.Items.AddRange(New Object() {"Y", "N"})
        Me.OPENFACILITY.Location = New System.Drawing.Point(449, 225)
        Me.OPENFACILITY.Name = "OPENFACILITY"
        Me.OPENFACILITY.Size = New System.Drawing.Size(112, 24)
        Me.OPENFACILITY.TabIndex = 12
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(329, 225)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(90, 15)
        Me.Label17.TabIndex = 463
        Me.Label17.Text = "OPEN FACILITY"
        '
        'CMB_TYPE
        '
        Me.CMB_TYPE.BackColor = System.Drawing.Color.Wheat
        Me.CMB_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_TYPE.Items.AddRange(New Object() {"NVEG", "VEG"})
        Me.CMB_TYPE.Location = New System.Drawing.Point(449, 270)
        Me.CMB_TYPE.Name = "CMB_TYPE"
        Me.CMB_TYPE.Size = New System.Drawing.Size(112, 28)
        Me.CMB_TYPE.TabIndex = 8
        Me.CMB_TYPE.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(329, 271)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 15)
        Me.Label15.TabIndex = 461
        Me.Label15.Text = "TYPE "
        Me.Label15.Visible = False
        '
        'LBL_CATEGORY
        '
        Me.LBL_CATEGORY.AutoSize = True
        Me.LBL_CATEGORY.BackColor = System.Drawing.Color.Transparent
        Me.LBL_CATEGORY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CATEGORY.Location = New System.Drawing.Point(329, 193)
        Me.LBL_CATEGORY.Name = "LBL_CATEGORY"
        Me.LBL_CATEGORY.Size = New System.Drawing.Size(68, 15)
        Me.LBL_CATEGORY.TabIndex = 460
        Me.LBL_CATEGORY.Text = "CATEGORY"
        '
        'CMBCATEGORY
        '
        Me.CMBCATEGORY.BackColor = System.Drawing.Color.Wheat
        Me.CMBCATEGORY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBCATEGORY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBCATEGORY.Items.AddRange(New Object() {"BAR", "CANTEEN", "CATERING", "BEVERAGES", "CAN", "OTHERS"})
        Me.CMBCATEGORY.Location = New System.Drawing.Point(450, 186)
        Me.CMBCATEGORY.Name = "CMBCATEGORY"
        Me.CMBCATEGORY.Size = New System.Drawing.Size(111, 24)
        Me.CMBCATEGORY.TabIndex = 10
        '
        'TXTUOMDESCRIPTION
        '
        Me.TXTUOMDESCRIPTION.BackColor = System.Drawing.Color.Wheat
        Me.TXTUOMDESCRIPTION.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTUOMDESCRIPTION.Location = New System.Drawing.Point(450, 148)
        Me.TXTUOMDESCRIPTION.MaxLength = 50
        Me.TXTUOMDESCRIPTION.Name = "TXTUOMDESCRIPTION"
        Me.TXTUOMDESCRIPTION.ReadOnly = True
        Me.TXTUOMDESCRIPTION.Size = New System.Drawing.Size(190, 26)
        Me.TXTUOMDESCRIPTION.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(329, 155)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 15)
        Me.Label8.TabIndex = 376
        Me.Label8.Text = "DESCRIPTION "
        '
        'txtItemType
        '
        Me.txtItemType.BackColor = System.Drawing.Color.Moccasin
        Me.txtItemType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemType.Location = New System.Drawing.Point(144, 225)
        Me.txtItemType.MaxLength = 10
        Me.txtItemType.Name = "txtItemType"
        Me.txtItemType.Size = New System.Drawing.Size(104, 22)
        Me.txtItemType.TabIndex = 11
        '
        'cmdKitchenHelp
        '
        Me.cmdKitchenHelp.Location = New System.Drawing.Point(672, 36)
        Me.cmdKitchenHelp.Name = "cmdKitchenHelp"
        Me.cmdKitchenHelp.Size = New System.Drawing.Size(39, 24)
        Me.cmdKitchenHelp.TabIndex = 472
        Me.cmdKitchenHelp.Text = "?"
        Me.cmdKitchenHelp.UseVisualStyleBackColor = True
        Me.cmdKitchenHelp.Visible = False
        '
        'CMD_GLACCODE
        '
        Me.CMD_GLACCODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMD_GLACCODE.Image = CType(resources.GetObject("CMD_GLACCODE.Image"), System.Drawing.Image)
        Me.CMD_GLACCODE.Location = New System.Drawing.Point(611, 64)
        Me.CMD_GLACCODE.Name = "CMD_GLACCODE"
        Me.CMD_GLACCODE.Size = New System.Drawing.Size(24, 24)
        Me.CMD_GLACCODE.TabIndex = 457
        Me.CMD_GLACCODE.UseVisualStyleBackColor = False
        Me.CMD_GLACCODE.Visible = False
        '
        'TXT_GLACCODE
        '
        Me.TXT_GLACCODE.BackColor = System.Drawing.Color.Wheat
        Me.TXT_GLACCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_GLACCODE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_GLACCODE.Location = New System.Drawing.Point(592, 37)
        Me.TXT_GLACCODE.MaxLength = 50
        Me.TXT_GLACCODE.Name = "TXT_GLACCODE"
        Me.TXT_GLACCODE.Size = New System.Drawing.Size(80, 21)
        Me.TXT_GLACCODE.TabIndex = 7
        Me.TXT_GLACCODE.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(434, 37)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(122, 15)
        Me.Label14.TabIndex = 456
        Me.Label14.Text = "GL ACCOUNT CODE"
        Me.Label14.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.OptNo)
        Me.GroupBox3.Controls.Add(Me.optYes)
        Me.GroupBox3.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(30, 606)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(189, 56)
        Me.GroupBox3.TabIndex = 458
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(504, 504)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 22)
        Me.Label2.TabIndex = 377
        Me.Label2.Text = "DESCRIPTION"
        Me.Label2.Visible = False
        '
        'txtTypedes
        '
        Me.txtTypedes.BackColor = System.Drawing.Color.Wheat
        Me.txtTypedes.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTypedes.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTypedes.Location = New System.Drawing.Point(656, 504)
        Me.txtTypedes.MaxLength = 50
        Me.txtTypedes.Name = "txtTypedes"
        Me.txtTypedes.ReadOnly = True
        Me.txtTypedes.Size = New System.Drawing.Size(112, 26)
        Me.txtTypedes.TabIndex = 5
        Me.txtTypedes.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(16, -48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 22)
        Me.Label12.TabIndex = 405
        Me.Label12.Text = "G.CODE"
        Me.Label12.Visible = False
        '
        'TXTCGROUPCODE
        '
        Me.TXTCGROUPCODE.BackColor = System.Drawing.Color.Wheat
        Me.TXTCGROUPCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCGROUPCODE.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCGROUPCODE.Location = New System.Drawing.Point(56, -216)
        Me.TXTCGROUPCODE.MaxLength = 10
        Me.TXTCGROUPCODE.Name = "TXTCGROUPCODE"
        Me.TXTCGROUPCODE.Size = New System.Drawing.Size(30, 26)
        Me.TXTCGROUPCODE.TabIndex = 9
        Me.TXTCGROUPCODE.Visible = False
        '
        'CGROUPHELP
        '
        Me.CGROUPHELP.Image = CType(resources.GetObject("CGROUPHELP.Image"), System.Drawing.Image)
        Me.CGROUPHELP.Location = New System.Drawing.Point(24, -48)
        Me.CGROUPHELP.Name = "CGROUPHELP"
        Me.CGROUPHELP.Size = New System.Drawing.Size(23, 48)
        Me.CGROUPHELP.TabIndex = 10
        Me.CGROUPHELP.Visible = False
        '
        'TXTCGROUPDESC
        '
        Me.TXTCGROUPDESC.BackColor = System.Drawing.Color.Wheat
        Me.TXTCGROUPDESC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTCGROUPDESC.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTCGROUPDESC.Location = New System.Drawing.Point(16, -216)
        Me.TXTCGROUPDESC.MaxLength = 50
        Me.TXTCGROUPDESC.Name = "TXTCGROUPDESC"
        Me.TXTCGROUPDESC.ReadOnly = True
        Me.TXTCGROUPDESC.Size = New System.Drawing.Size(32, 26)
        Me.TXTCGROUPDESC.TabIndex = 11
        Me.TXTCGROUPDESC.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Black
        Me.Label13.Location = New System.Drawing.Point(48, -248)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(32, 22)
        Me.Label13.TabIndex = 406
        Me.Label13.Text = "DE"
        Me.Label13.Visible = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(364, 478)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(238, 27)
        Me.lbl_Freeze.TabIndex = 389
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Cmd_Clear12)
        Me.GroupBox1.Controls.Add(Me.Cmd_View2)
        Me.GroupBox1.Controls.Add(Me.Cmd_Freeze54)
        Me.GroupBox1.Controls.Add(Me.Cmd_Add1)
        Me.GroupBox1.Controls.Add(Me.Cmd_Exit5)
        Me.GroupBox1.Location = New System.Drawing.Point(54, 590)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(693, 56)
        Me.GroupBox1.TabIndex = 388
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'Cmd_Clear12
        '
        Me.Cmd_Clear12.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Clear12.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear12.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear12.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear12.Image = CType(resources.GetObject("Cmd_Clear12.Image"), System.Drawing.Image)
        Me.Cmd_Clear12.Location = New System.Drawing.Point(16, 16)
        Me.Cmd_Clear12.Name = "Cmd_Clear12"
        Me.Cmd_Clear12.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear12.TabIndex = 17
        Me.Cmd_Clear12.Text = "Clear[F6]"
        Me.Cmd_Clear12.UseVisualStyleBackColor = False
        '
        'Cmd_View2
        '
        Me.Cmd_View2.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View2.ForeColor = System.Drawing.Color.White
        Me.Cmd_View2.Image = CType(resources.GetObject("Cmd_View2.Image"), System.Drawing.Image)
        Me.Cmd_View2.Location = New System.Drawing.Point(440, 16)
        Me.Cmd_View2.Name = "Cmd_View2"
        Me.Cmd_View2.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View2.TabIndex = 19
        Me.Cmd_View2.Text = "Crystal[F9]"
        Me.Cmd_View2.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze54
        '
        Me.Cmd_Freeze54.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze54.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze54.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze54.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze54.Image = CType(resources.GetObject("Cmd_Freeze54.Image"), System.Drawing.Image)
        Me.Cmd_Freeze54.Location = New System.Drawing.Point(296, 16)
        Me.Cmd_Freeze54.Name = "Cmd_Freeze54"
        Me.Cmd_Freeze54.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze54.TabIndex = 18
        Me.Cmd_Freeze54.Text = "Freeze[F8]"
        Me.Cmd_Freeze54.UseVisualStyleBackColor = False
        '
        'Cmd_Add1
        '
        Me.Cmd_Add1.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add1.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add1.Image = CType(resources.GetObject("Cmd_Add1.Image"), System.Drawing.Image)
        Me.Cmd_Add1.Location = New System.Drawing.Point(160, 16)
        Me.Cmd_Add1.Name = "Cmd_Add1"
        Me.Cmd_Add1.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add1.TabIndex = 10
        Me.Cmd_Add1.Text = "Add [F7]"
        Me.Cmd_Add1.UseVisualStyleBackColor = False
        '
        'Cmd_Exit5
        '
        Me.Cmd_Exit5.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit5.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit5.Image = CType(resources.GetObject("Cmd_Exit5.Image"), System.Drawing.Image)
        Me.Cmd_Exit5.Location = New System.Drawing.Point(576, 16)
        Me.Cmd_Exit5.Name = "Cmd_Exit5"
        Me.Cmd_Exit5.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit5.TabIndex = 20
        Me.Cmd_Exit5.Text = "Exit[F11]"
        Me.Cmd_Exit5.UseVisualStyleBackColor = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdexport.BackgroundImage = CType(resources.GetObject("cmdexport.BackgroundImage"), System.Drawing.Image)
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Location = New System.Drawing.Point(880, 488)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(104, 32)
        Me.cmdexport.TabIndex = 435
        Me.cmdexport.Text = "Report[F12]"
        Me.cmdexport.UseVisualStyleBackColor = False
        Me.cmdexport.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(224, 520)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(384, 16)
        Me.Label10.TabIndex = 418
        Me.Label10.Text = "Press F4 for HELP / Press ENTER key to navigate"
        Me.Label10.Visible = False
        '
        'grp_HALLdetails
        '
        Me.grp_HALLdetails.BackColor = System.Drawing.Color.Transparent
        Me.grp_HALLdetails.Controls.Add(Me.Label11)
        Me.grp_HALLdetails.Controls.Add(Me.Chk_SELECTALL)
        Me.grp_HALLdetails.Controls.Add(Me.CHKMENUGROUP)
        Me.grp_HALLdetails.Controls.Add(Me.CMDSCREEN)
        Me.grp_HALLdetails.Controls.Add(Me.CMDPRINT)
        Me.grp_HALLdetails.Controls.Add(Me.CMDEXIT)
        Me.grp_HALLdetails.Location = New System.Drawing.Point(8, -192)
        Me.grp_HALLdetails.Name = "grp_HALLdetails"
        Me.grp_HALLdetails.Size = New System.Drawing.Size(112, 101)
        Me.grp_HALLdetails.TabIndex = 420
        Me.grp_HALLdetails.TabStop = False
        Me.grp_HALLdetails.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Maroon
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(16, 64)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(48, 24)
        Me.Label11.TabIndex = 432
        Me.Label11.Text = "MENU GROUP"
        '
        'Chk_SELECTALL
        '
        Me.Chk_SELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.Chk_SELECTALL.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_SELECTALL.Location = New System.Drawing.Point(16, 48)
        Me.Chk_SELECTALL.Name = "Chk_SELECTALL"
        Me.Chk_SELECTALL.Size = New System.Drawing.Size(40, 16)
        Me.Chk_SELECTALL.TabIndex = 431
        Me.Chk_SELECTALL.Text = "SELECT ALL "
        Me.Chk_SELECTALL.UseVisualStyleBackColor = False
        '
        'CHKMENUGROUP
        '
        Me.CHKMENUGROUP.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.CHKMENUGROUP.Location = New System.Drawing.Point(64, 48)
        Me.CHKMENUGROUP.Name = "CHKMENUGROUP"
        Me.CHKMENUGROUP.Size = New System.Drawing.Size(48, 46)
        Me.CHKMENUGROUP.TabIndex = 430
        '
        'CMDSCREEN
        '
        Me.CMDSCREEN.BackColor = System.Drawing.Color.ForestGreen
        Me.CMDSCREEN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMDSCREEN.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDSCREEN.ForeColor = System.Drawing.Color.White
        Me.CMDSCREEN.Image = CType(resources.GetObject("CMDSCREEN.Image"), System.Drawing.Image)
        Me.CMDSCREEN.Location = New System.Drawing.Point(56, 16)
        Me.CMDSCREEN.Name = "CMDSCREEN"
        Me.CMDSCREEN.Size = New System.Drawing.Size(48, 32)
        Me.CMDSCREEN.TabIndex = 14
        Me.CMDSCREEN.Text = " View"
        Me.CMDSCREEN.UseVisualStyleBackColor = False
        '
        'CMDPRINT
        '
        Me.CMDPRINT.BackColor = System.Drawing.Color.ForestGreen
        Me.CMDPRINT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMDPRINT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT.ForeColor = System.Drawing.Color.White
        Me.CMDPRINT.Image = CType(resources.GetObject("CMDPRINT.Image"), System.Drawing.Image)
        Me.CMDPRINT.Location = New System.Drawing.Point(112, 16)
        Me.CMDPRINT.Name = "CMDPRINT"
        Me.CMDPRINT.Size = New System.Drawing.Size(24, 32)
        Me.CMDPRINT.TabIndex = 13
        Me.CMDPRINT.Text = "Print"
        Me.CMDPRINT.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.ForestGreen
        Me.CMDEXIT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMDEXIT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.Color.White
        Me.CMDEXIT.Image = CType(resources.GetObject("CMDEXIT.Image"), System.Drawing.Image)
        Me.CMDEXIT.Location = New System.Drawing.Point(24, 16)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(32, 32)
        Me.CMDEXIT.TabIndex = 15
        Me.CMDEXIT.Text = "Exit"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'LST_TAX
        '
        Me.LST_TAX.BackColor = System.Drawing.Color.Wheat
        Me.LST_TAX.Location = New System.Drawing.Point(761, 72)
        Me.LST_TAX.Name = "LST_TAX"
        Me.LST_TAX.Size = New System.Drawing.Size(80, 42)
        Me.LST_TAX.TabIndex = 581
        Me.LST_TAX.Visible = False
        '
        'cmdreport
        '
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.Image = CType(resources.GetObject("cmdreport.Image"), System.Drawing.Image)
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(864, 380)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(136, 65)
        Me.cmdreport.TabIndex = 17
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdreport.UseVisualStyleBackColor = True
        '
        'CMD_EXIT
        '
        Me.CMD_EXIT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_EXIT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_EXIT.Image = CType(resources.GetObject("CMD_EXIT.Image"), System.Drawing.Image)
        Me.CMD_EXIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_EXIT.Location = New System.Drawing.Point(864, 581)
        Me.CMD_EXIT.Name = "CMD_EXIT"
        Me.CMD_EXIT.Size = New System.Drawing.Size(136, 65)
        Me.CMD_EXIT.TabIndex = 20
        Me.CMD_EXIT.Text = "Exit [F11]"
        Me.CMD_EXIT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_EXIT.UseVisualStyleBackColor = True
        '
        'Cmdauth
        '
        Me.Cmdauth.BackgroundImage = Global.partymodule.My.Resources.Resources.excel
        Me.Cmdauth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(864, 515)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(136, 65)
        Me.Cmdauth.TabIndex = 19
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdauth.UseVisualStyleBackColor = True
        '
        'Cmdbwse
        '
        Me.Cmdbwse.BackgroundImage = Global.partymodule.My.Resources.Resources.Clear
        Me.Cmdbwse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Cmdbwse.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbwse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbwse.Location = New System.Drawing.Point(864, 447)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(136, 65)
        Me.Cmdbwse.TabIndex = 18
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdbwse.UseVisualStyleBackColor = True
        '
        'Cmd_view
        '
        Me.Cmd_view.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_view.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_view.Image = CType(resources.GetObject("Cmd_view.Image"), System.Drawing.Image)
        Me.Cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_view.Location = New System.Drawing.Point(864, 311)
        Me.Cmd_view.Name = "Cmd_view"
        Me.Cmd_view.Size = New System.Drawing.Size(136, 65)
        Me.Cmd_view.TabIndex = 16
        Me.Cmd_view.Text = "View [F9]"
        Me.Cmd_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_view.UseVisualStyleBackColor = True
        '
        'CMD_FREEZE
        '
        Me.CMD_FREEZE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_FREEZE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_FREEZE.Image = CType(resources.GetObject("CMD_FREEZE.Image"), System.Drawing.Image)
        Me.CMD_FREEZE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_FREEZE.Location = New System.Drawing.Point(864, 243)
        Me.CMD_FREEZE.Name = "CMD_FREEZE"
        Me.CMD_FREEZE.Size = New System.Drawing.Size(136, 65)
        Me.CMD_FREEZE.TabIndex = 15
        Me.CMD_FREEZE.Text = "Freeze [F8]"
        Me.CMD_FREEZE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_FREEZE.UseVisualStyleBackColor = True
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(863, 95)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(136, 65)
        Me.Cmd_Clear.TabIndex = 14
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = True
        '
        'Cmd_Add
        '
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(863, 170)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(136, 65)
        Me.Cmd_Add.TabIndex = 13
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'itemmst
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 17)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1016, 733)
        Me.Controls.Add(Me.cmdreport)
        Me.Controls.Add(Me.CMD_EXIT)
        Me.Controls.Add(Me.cmdKitchenHelp)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbwse)
        Me.Controls.Add(Me.Cmd_view)
        Me.Controls.Add(Me.CMD_FREEZE)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.LST_TAX)
        Me.Controls.Add(Me.grp_HALLdetails)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.TXTGROUPDESCRIPTION)
        Me.Controls.Add(Me.TXTGROUPCODE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TXTITEMDESC)
        Me.Controls.Add(Me.CMD_GLACCODE)
        Me.Controls.Add(Me.TXTITEMCODE)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TXT_GLACCODE)
        Me.Controls.Add(Me.TXTRATE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TXTCGROUPDESC)
        Me.Controls.Add(Me.TXTCGROUPCODE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTypedes)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.CGROUPHELP)
        Me.Controls.Add(Me.cmdexport)
        Me.Controls.Add(Me.GroupBox3)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "itemmst"
        Me.Text = "Regular Item Master"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.grp_HALLdetails.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub TXTITEMCODE_HELP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTITEMCODE_HELP.Click
        Dim vform As New LIST_OPERATION1
        Try
            ',ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(UOMCODE,'') AS UOMCODE,ISNULL(RATE,0) AS RATE
            gSQLString = "Select Itemcode,Itemdesc From PARTY_ITEMMASTER"
            M_WhereCondition = " "
            vform.Field = "Itemcode,Itemdesc"
            'vform.vFormatstring = " Item Code                          |Item Name              |Group Code            |UOM     |Rate"
            vform.vCaption = " Item Master Help"
            '  vform.KeyPos = 0
            ' vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                'TXTITEMDESC.Text = ""
                TXTITEMCODE.Text = Trim(vform.keyfield & "")
                TXTITEMCODE.Select()
                'TXTITEMDESC.Text = Trim(vform.keyfield1 & "")
                'TXTITEMDESC.Focus()
                Call TXTITEMCODE_Validated(TXTITEMCODE, e)
                Cmd_Add.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub TXTTYPEMCODE_HELP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTTYPEMCODE_HELP.Click
        Dim vform As New LIST_OPERATION1
        Try
            gSQLString = " Select Itemtypecode,Itemtypedesc from ItemTypeMaster "
            M_WhereCondition = " "
            vform.Field = "Itemtypecode,Itemtypedesc"
            vform.vFormatstring = "Type Code | Type Name                   "
            vform.vCaption = " Itemtype Master Help"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtItemType.Text = Trim(vform.keyfield & "")
                txtTypedes.Text = Trim(vform.keyfield1 & "")
                Cmd_Add1.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub TXTGROUPCODE_HELP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTGROUPCODE_HELP.Click
        Dim vform As New LIST_OPERATION1
        Try
            gSQLString = "Select GROUPCODE,groupdesc From groupmaster"
            M_WhereCondition = " WHERE ISNULL(FREEZE,'')<>'Y' "
            vform.Field = "groupcode,groupdesc"
            ' vform.vFormatstring = "SubGroup Code  | SubGroup Name                     "
            vform.vCaption = "Group Master Help"
            '  vform.KeyPos = 0
            ' vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXTGROUPCODE.Text = Trim(vform.keyfield & "")
                '  TXTGROUPDESCRIPTION.Text = Trim(vform.keyfield1 & "")
                TXTGROUPCODE.Select()
                TXTGROUPDESCRIPTION.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TXTUOMCODE_HELP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTUOMCODE_HELP.Click
        Dim vform As New LIST_OPERATION1
        Try
            gSQLString = "Select Uomcode,Uomdesc From Uommaster"
            M_WhereCondition = " WHERE ISNULL(FREEZE,'')<>'Y' "
            vform.Field = "uomcode,uomdesc"
            ' vform.vFormatstring = " Uom Code | Uom Name                      "
            vform.vCaption = "Uom Master Help"
            ' vform.KeyPos = 0
            '  vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXTUOMCODE.Text = Trim(vform.keyfield & "")
                '   TXTUOMDESCRIPTION.Text = Trim(vform.keyfield1 & "")
                TXTUOMCODE.Select()
                TXTRATE.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub itemmst_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            Call CMD_FREEZE_Click(Cmd_Freeze54, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 Then
            Call Cmd_view_Click(Cmd_View2, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call CMD_EXIT_Click(CMD_EXIT, e)
            Exit Sub
        End If
    End Sub

    Private Sub TXTITEMCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTITEMCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXTITEMCODE.Text) <> "" Then
                Call TXTITEMCODE_Validated(TXTITEMCODE, e)
            Else
                Call TXTITEMCODE_HELP_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub TXTITEMDESC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTITEMDESC.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTGROUPCODE.Focus()
        End If
    End Sub
    Private Sub TXTGROUPCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGROUPCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXTGROUPCODE.Text) <> "" Then
                Call TXTGROUPCODE_Validated(TXTGROUPCODE, e)
            Else
                Call TXTGROUPCODE_HELP_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub TXTUOMCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTUOMCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXTUOMCODE.Text) <> "" Then
                Call TXTUOMCODE_Validated(TXTUOMCODE, e)
            Else
                Call TXTUOMCODE_HELP_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub TXTRATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRATE.KeyPress
        getNumeric(e)

        '' ''If e.KeyChar <> ChrW(Keys.Back) Then
        '' ''    If Char.IsNumber(e.KeyChar) Then
        '' ''    Else
        '' ''        e.Handled = True
        '' ''        'MsgBox(" Numbers only ")
        '' ''    End If
        '' ''End If

        If Asc(e.KeyChar) = 13 Then
            If TXTRATE.Text <> "" And Val(TXTRATE.Text) > 0 Then
                CMBCATEGORY.Focus()
            Else
                TXTRATE.Focus()
            End If

        End If
    End Sub

    Private Sub itemmst_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        Me.resizeFormResolution()
        rs.ResizeAllControls(Me)
        'gconnection.FocusSetting(Me)
        grp_HALLdetails.Visible = False
        grp_HALLdetails.Top = 120
        grp_HALLdetails.Top = 32
        Me.TXTITEMCODE.Enabled = True
        Me.TXTITEMCODE.ReadOnly = False
        GroupMasterbool = True
        Call FILLcat()
        TXT_SUBGROUPCODE.Text = ""
        TXT_SUBGROUPDESC.Text = ""
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Cmd_Clear_Click(sender, e)
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


    Private Sub FILLcat()
        Dim I As Integer
        sqlstring = "SELECT isnull(categoryname,'') as categoryname  FROM poscategorymaster"
        gconnection.getDataSet(sqlstring, "TAXDET")
        If gdataset.Tables("TAXDET").Rows.Count > 0 Then
            For I = 0 To gdataset.Tables("TAXDET").Rows.Count - 1
                Me.CMBCATEGORY.Items.Add(gdataset.Tables("TAXDET").Rows(I).Item("categoryname"))
            Next
        End If
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
        If TXTITEMCODE.Text = "" Then
        Else
            sqlstring = "select * from party_itemmaster_tax "
            gconnection.getDataSet(sqlstring, "party_itemmaster_tax")
            If gdataset.Tables("party_itemmaster_tax").Rows.Count > 0 Then
                For I = 0 To gdataset.Tables("party_itemmaster_tax").Rows.Count - 1
                    For j = 0 To LST_TAX.Items.Count - 1
                        TempString = Split((LST_TAX.Items.Item(j)), "-->")
                        If Trim(TempString(0)) = Trim(gdataset.Tables("party_itemmaster_tax").Rows(I).Item("ITEMTYPECODE")) Then
                            LST_TAX.SetItemChecked(j, False)

                        Else
                            LST_TAX.SetItemChecked(j, True)
                        End If
                    Next
                Next
            End If
        End If

    End Sub
    Private Sub FillPOSLocation()
        Dim i As Integer
        CHKMENUGROUP.Items.Clear()
        sqlstring = "select isnull(groupcode,'') as groupcode,isnull(groupdesc,'') as groupdesc "
        sqlstring = sqlstring & "From groupmaster WHERE ISNULL(Freeze,'')<>'Y' "
        vconn.getDataSet(sqlstring, "groupmaster")
        If gdataset.Tables("groupmaster").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("groupmaster").Rows.Count - 1
                With gdataset.Tables("groupmaster").Rows(i)
                    CHKMENUGROUP.Items.Add(Trim(.Item("groupdesc")))
                End With
            Next i
        End If
        CHKMENUGROUP.Sorted = True
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
        Me.Cmd_Add1.Enabled = False
        Me.CMD_FREEZE.Enabled = False
        Me.Cmd_view.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.CMD_FREEZE.Enabled = True
                    Me.Cmd_view.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add1.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.CMD_FREEZE.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_view.Enabled = True
                End If
            Next
        End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        Dim ssql As String

        If Trim(TXTITEMCODE.Text) = "" Then
            MessageBox.Show("ITEMCODE can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTITEMCODE.Focus()
            Exit Sub
        End If
        If Trim(TXTITEMDESC.Text) = "" Then
            MessageBox.Show("ITEM Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTITEMDESC.Focus()
            Exit Sub
        End If
        If Trim(TXTUOMCODE.Text) = "" Then
            MessageBox.Show("UOMCODE can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTITEMCODE.Focus()
            Exit Sub
        End If
        If Trim(TXTUOMDESCRIPTION.Text) = "" Then
            MessageBox.Show("UOM Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTITEMDESC.Focus()
            Exit Sub
        End If

        If Trim(CMBCATEGORY.Text) = "" Then
            MessageBox.Show("Category can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CMBCATEGORY.Focus()
            Exit Sub
        End If

        If Trim(txtItemType.Text) = "" Then
            MessageBox.Show("Tax Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtItemType.Focus()
            Exit Sub
        End If
        'If Trim(txtTypedes.Text) = "" Then
        '    MessageBox.Show("Tax  Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    txtItemType.Focus()
        '    Exit Sub
        'End If
        If Trim(TXTGROUPCODE.Text) = "" Then
            MessageBox.Show("Group Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTGROUPCODE.Focus()
            Exit Sub
        End If

        If Trim(TXTGROUPDESCRIPTION.Text) = "" Then
            MessageBox.Show("Group Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTGROUPDESCRIPTION.Focus()
            Exit Sub
        End If
        If Trim(TXT_SUBGROUPCODE.Text) = "" Then
            MessageBox.Show("Sub Group Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_SUBGROUPCODE.Focus()
            Exit Sub
        End If

        If Trim(TXT_SUBGROUPDESC.Text) = "" Then
            MessageBox.Show("Sub Group Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXT_SUBGROUPDESC.Focus()
            Exit Sub
        End If

        If Trim(TXTUOMCODE.Text) = "" Then
            MessageBox.Show("Uom code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTUOMCODE.Focus()
            Exit Sub
        End If

        If Trim(TXTUOMDESCRIPTION.Text) = "" Then
            MessageBox.Show("Uom Description  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTUOMDESCRIPTION.Focus()
            Exit Sub
        End If
        If Trim(OPENFACILITY.Text) = "" Then
            MessageBox.Show("Open Facility  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            OPENFACILITY.Focus()
            Exit Sub
        End If

        If Val(TXTRATE.Text) <= 0 Then
            MessageBox.Show("Rate can't be less than 0 or less ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTRATE.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub TXTTYPECODE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F4 Then
            TXTTYPEMCODE_HELP_Click(sender, e)
        End If
    End Sub
    Private Sub clearoperaction()
        TXTRATE.Text = ""
        TXTITEMCODE.Text = ""
        TXTITEMDESC.Text = ""
        TXTGROUPCODE.Text = ""
        TXTGROUPDESCRIPTION.Text = ""
        TXTCGROUPCODE.Text = ""
        TXTCGROUPDESC.Text = ""
        txtItemType.Text = ""
        txtTypedes.Text = ""
        TXTUOMCODE.Text = ""
        CMB_TYPE.Text = ""
        TXTUOMDESCRIPTION.Text = ""
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.CMD_FREEZE.Text = "Freeze[F8]"
        Cmd_Add.Text = "Add [F7]"
        TXTITEMCODE.Enabled = True
        TXTITEMCODE.ReadOnly = False
        TXTITEMDESC.ReadOnly = False
        TXTITEMCODE_HELP.Enabled = True
        TXTRATE.Text = Format(Val(TXTRATE.Text), "0.00")
        TXTITEMCODE.Focus()
    End Sub
    Private Sub TXTITEMCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTITEMCODE.Validated
        Dim Fre As String
        Try
            'If MyCompanyName = "FILM NAGAR CULTURAL CENTER" Then
            '    Me.TXTRATE.Enabled = False

            If Trim(TXTITEMCODE.Text) <> "" Then
                Dim ds As New DataSet
                sqlstring = "select isnull(category,'') as category,isnull(glaccode,'') as glaccode,isnull(itemcode,'') as itemcode,isnull(itemdesc,'') as itemdesc,isnull(TAXcode,'') as TAXcode,isnull(groupcode,'') as groupcode,isnull(GROUPDESC,'') as GROUPDESC,isnull(SUBgroupcode,'') as SUBgroupcode,isnull(SUBGROUPDESC,'') as SUBGROUPDESC,isnull(uomCODE,'') as uomCODE,isnull(uomDESC,'') as uomDESC,isnull(rate,0) as rate,isnull(sbfcharge,'') as sbfcharge,isnull(freeze,'') as freeze,ISNULL(OPENFACILITY,'')AS OPENFACILITY,"
                sqlstring = sqlstring & " isnull(adddatetime,'') as adddatetime,isnull(adduserid,'') as adduserid from PARTY_ITEMMASTER "
                sqlstring = sqlstring & " WHERE isnull(itemcode,'')='" & TXTITEMCODE.Text & "'"
                gconnection.getDataSet(sqlstring, "MenuMaster")
                If gdataset.Tables("MenuMaster").Rows.Count > 0 Then
                    TXTITEMDESC.Clear()
                    TXTITEMDESC.Text = gdataset.Tables("MenuMaster").Rows(0).Item("ItemDesc")
                    txtItemType.Text = gdataset.Tables("MenuMaster").Rows(0).Item("TAXCODE")
                    TXTGROUPCODE.Text = gdataset.Tables("MenuMaster").Rows(0).Item("Groupcode")

                    TXTGROUPDESCRIPTION.Text = gdataset.Tables("MenuMaster").Rows(0).Item("GroupDESC")
                    TXT_SUBGROUPCODE.Text = gdataset.Tables("MenuMaster").Rows(0).Item("SUBGroupcode")
                    TXT_SUBGROUPDESC.Text = gdataset.Tables("MenuMaster").Rows(0).Item("SUBGroupDESC")

                    CMBCATEGORY.Text = gdataset.Tables("MenuMaster").Rows(0).Item("category")
                    OPENFACILITY.Text = gdataset.Tables("MenuMaster").Rows(0).Item("OPENFACILITY")

                    TXTUOMCODE.Text = gdataset.Tables("MenuMaster").Rows(0).Item("UOMCODE")
                    TXTUOMDESCRIPTION.Text = gdataset.Tables("MenuMaster").Rows(0).Item("UOMDESC")

                    'TXTCGROUPCODE.Text = gdataset.Tables("MenuMaster").Rows(0).Item("cgroupcode")
                    TXT_GLACCODE.Text = gdataset.Tables("MenuMaster").Rows(0).Item("glaccode")
                    '  CMB_TYPE.Text = gdataset.Tables("MENUMASTER").Rows(0).Item("Type")
                    If gdataset.Tables("MenuMaster").Rows(0).Item("sbfcharge") = "Y" Then
                        optYes.Checked = True
                        OptNo.Checked = False
                    Else
                        optYes.Checked = False
                        OptNo.Checked = True
                    End If
                    TXTUOMCODE.Text = gdataset.Tables("MenuMaster").Rows(0).Item("UomCODE")
                    TXTRATE.Text = gdataset.Tables("MenuMaster").Rows(0).Item("Rate")

                    If gdataset.Tables("MenuMaster").Rows(0).Item("Freeze") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("MenuMaster").Rows(0).Item("ADDDATETIME")), "dd-MMM-yyyy")
                        Me.CMD_FREEZE.Text = "UnFreeze[F8]"
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.CMD_FREEZE.Text = "Freeze[F8]"
                    End If
                    Call txtItemType_Validated(txtItemType, e)
                    Call TXTGROUPCODE_Validated(TXTGROUPCODE, e)
                    Call TXTCGROUPCODE_Validated(TXTCGROUPCODE, e)
                    Call TXTUOMCODE_Validated(TXTUOMCODE, e)
                    Me.Cmd_Add.Text = "Update[F7]"
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If

                    Me.TXTITEMCODE.ReadOnly = True
                    Me.TXTITEMCODE_HELP.Enabled = False
                    Me.TXTITEMDESC.Focus()
                    'Else
                    'LOGAN CHANGED ON 17 JULY 2012 
                    'START

                    '    sqlstring = "select isnull(category,'') as category,isnull(itemcode,'') as itemcode,isnull(itemdesc,'') as itemdesc,isnull(itemtypecode,'') as itemtypecode,isnull(groupcode,'') as groupcode,isnull(BASEuomstd,'') as uom,isnull(BASEratestd,0) as rate"
                    '    sqlstring = sqlstring & " from ITEMMASTER "
                    '    sqlstring = sqlstring & " WHERE isnull(itemcode,'')='" & TXTITEMCODE.Text & "'"
                    '    gconnection.getDataSet(sqlstring, "MenuMaster")
                    '    If gdataset.Tables("MenuMaster").Rows.Count > 0 Then
                    '        TXTITEMDESC.Clear()
                    '        TXTITEMDESC.Text = gdataset.Tables("MenuMaster").Rows(0).Item("ItemDesc")
                    '        txtItemType.Text = gdataset.Tables("MenuMaster").Rows(0).Item("Itemtypecode")
                    '        TXTGROUPCODE.Text = gdataset.Tables("MenuMaster").Rows(0).Item("Groupcode")
                    '        TXTUOMCODE.Text = gdataset.Tables("MenuMaster").Rows(0).Item("Uom")
                    '        TXTRATE.Text = gdataset.Tables("MenuMaster").Rows(0).Item("Rate")
                    '        CMBCATEGORY.Text = gdataset.Tables("MenuMaster").Rows(0).Item("category")

                    '        Call txtItemType_Validated(txtItemType, e)
                    '        Call TXTGROUPCODE_Validated(TXTGROUPCODE, e)
                    '        Call TXTUOMCODE_Validated(TXTUOMCODE, e)
                    '    End If

                    '    Me.lbl_Freeze.Visible = False
                    '    Me.lbl_Freeze.Text = "Record Freezed  On "
                    '    Me.Cmd_Add.Text = "Add [F7]"
                    '    TXTITEMCODE.ReadOnly = False
                    '    TXTITEMDESC.Focus()
                Else
                    TXTITEMDESC.Focus()
                End If
                ''    End If
                'END 
            Else
                TXTITEMCODE.Text = ""
                TXTITEMDESC.Focus()
            End If
            '======================
            Dim j As Integer
            'If txt_HallType.Text <> "" Then
            '    sqlstring = "select * from Party_Hallmaster_TAX where HALLTYPECODE='" & Trim(txt_HallType.Text) & "'  "
            '    gconnection.getDataSet(sqlstring, "TAXDET1")
            '    If gdataset.Tables("TAXDET1").Rows.Count > 0 Then
            '        For i = 0 To gdataset.Tables("TAXDET1").Rows.Count - 1
            '            For j = 0 To LST_TAX.Items.Count - 1
            '                TempString = Split((LST_TAX.Items.Item(j)), "-->")
            '                If Trim(gdataset.Tables("TAXDET1").Rows(i).Item("taxtype")) = TempString(0) Then
            '                    LST_TAX.SetItemChecked(j, True)
            '                    LST_TAX.SelectedItem = gdataset.Tables("TAXDET1").Rows(0).Item("taxtype")
            '                End If
            '            Next
            '        Next
            '    End If
            'End If
            '=================================
            If TXTITEMCODE.Text <> "" Then
                sqlstring = "select * from party_itemmaster_tax WHERE isnull(itemcode,'')='" & TXTITEMCODE.Text & "'  "
                gconnection.getDataSet(sqlstring, "party_itemmaster_tax")
                If gdataset.Tables("party_itemmaster_tax").Rows.Count > 0 Then
                    For i = 0 To gdataset.Tables("party_itemmaster_tax").Rows.Count - 1
                        For j = 0 To LST_TAX.Items.Count - 1
                            TempString = Split((LST_TAX.Items.Item(j)), "-->")
                            If Trim(gdataset.Tables("party_itemmaster_tax").Rows(i).Item("ITEMTYPECODE")) = Trim(TempString(0)) Then
                                LST_TAX.SetItemChecked(j, True)
                                LST_TAX.SelectedItem = gdataset.Tables("party_itemmaster_tax").Rows(0).Item("ITEMTYPECODE")
                            End If
                        Next
                    Next
                End If
            Else

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtItemType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemType.Validated
        If txtItemType.Text <> "" Then
            ssql = "SELECT ISNULL(CHARGECODE,'') AS CHARGECODE,ISNULL(CHARGEDESC,'') AS CHARGEDESC FROM CHARGEMASTER  WHERE RATE=0  AND CHARGECODE='" & Trim(txtItemType.Text) & "' AND ISNULL(Freeze,'') <> 'Y'AND ISNULL(TAXTYPECODE,'')<>''"
            'ssql = "and "ESC
            vconn.getDataSet(ssql, "ItemTypeMaster")
            If gdataset.Tables("ItemTypeMaster").Rows.Count > 0 Then
                txtTypedes.Text = ""
                txtTypedes.Text = Trim(gdataset.Tables("ItemTypeMaster").Rows(0).Item("CHARGEDESC"))
                txtTypedes.ReadOnly = True
                ' Txt_subcode.Focus()
            Else
                txtItemType.Clear()
                txtTypedes.Clear()
                txtItemType.Focus()
            End If
        Else
            txtTypedes.Clear()
        End If

    End Sub
    Private Sub TXTGROUPCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTGROUPCODE.Validated
        If TXTGROUPCODE.Text <> "" Then
            sqlstring = "select groupcode,groupdesc,category from Groupmaster "
            sqlstring = sqlstring & " where groupcode='" & Trim(TXTGROUPCODE.Text) & "'AND ISNULL(FREEZE,'')<>'Y'"
            vconn.getDataSet(sqlstring, "GroupMaster")
            If gdataset.Tables("GroupMaster").Rows.Count > 0 Then
                TXTGROUPDESCRIPTION.Text = ""
                TXTGROUPDESCRIPTION.Text = Trim(gdataset.Tables("GroupMaster").Rows(0).Item("GroupDesc"))
                CMBCATEGORY.Text = Trim(gdataset.Tables("GroupMaster").Rows(0).Item("category"))
                TXTGROUPDESCRIPTION.ReadOnly = True
                TXT_SUBGROUPCODE.Focus()
            Else
                TXTGROUPCODE.Clear()
                TXTGROUPDESCRIPTION.Clear()
                TXTGROUPCODE.Focus()
            End If
        End If
    End Sub
    Private Sub TXTUOMCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTUOMCODE.Validated
        If TXTUOMCODE.Text <> "" Then
            sqlstring = "select uomcode,uomdesc from  uommaster "
            sqlstring = sqlstring & " where uomcode='" & Trim(TXTUOMCODE.Text) & "' AND ISNULL(FREEZE,'')<>'Y'"
            vconn.getDataSet(sqlstring, "UomMaster")
            If gdataset.Tables("UomMaster").Rows.Count > 0 Then
                TXTUOMDESCRIPTION.Text = ""
                TXTUOMDESCRIPTION.Text = Trim(gdataset.Tables("UomMaster").Rows(0).Item("UomDesc"))
                TXTUOMDESCRIPTION.ReadOnly = True
                TXTRATE.Focus()
            Else
                TXTUOMCODE.Clear()
                TXTUOMDESCRIPTION.Clear()
                TXTRATE.Focus()
            End If
        End If
    End Sub
    Private Sub TXTGROUPDESCRIPTION_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGROUPDESCRIPTION.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTUOMCODE.Focus()
        End If
    End Sub
    Private Sub TXTUOMDESCRIPTION_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTUOMDESCRIPTION.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTRATE.Focus()
        End If
    End Sub
    Private Sub Chk_POSlocation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_SELECTALL.CheckedChanged
        Dim i As Integer
        If Chk_SELECTALL.Checked = True Then
            For i = 0 To CHKMENUGROUP.Items.Count - 1
                CHKMENUGROUP.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To CHKMENUGROUP.Items.Count - 1
                CHKMENUGROUP.SetItemChecked(i, False)
            Next
        End If
    End Sub
    Private Sub menudetail()
        Dim Desc As String
        Dim Pno, pagesize As Integer
        Try
            sqlstring = "SELECT GROUPCODE,GROUPDESC FROM GROUPMASTER"
            If CHKMENUGROUP.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE GROUPDESC IN ("
                For i = 0 To CHKMENUGROUP.CheckedItems.Count - 1
                    If i = 0 Then
                        sqlstring = sqlstring & " '" & CHKMENUGROUP.CheckedItems(i) & "'"
                    Else
                        sqlstring = sqlstring & ",'" & CHKMENUGROUP.CheckedItems(i) & "'"
                    End If
                Next
                sqlstring = sqlstring & ")"
            Else
                MessageBox.Show("Select the GroupName", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            dt = gconnection.GetValues(sqlstring)
            If dt.Rows.Count > 0 Then
                ssql = ""
                For i = 0 To dt.Rows.Count - 1
                    If ssql = "" Then
                        ssql = ssql & "'" & dt.Rows(i).Item("groupcode")
                    Else
                        ssql = ssql & "','" & dt.Rows(i).Item("groupcode")
                    End If
                Next
                ssql = ssql & "'"
            End If
            Rnd()
            vOutfile = Mid("Out" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            sqlstring = "select A.itemcode,A.itemdesc,A.itemtypecode,A.groupcode,C.uomdesc as uom,A.rate,A.freeze,b.Groupdesc,"
            sqlstring = sqlstring & " A.adddatetime,A.adduserid from PARTY_ITEMMASTER A Inner join groupmaster b On"
            sqlstring = sqlstring & " a.groupcode=b.groupcode and a.groupcode in(" & (ssql) & ") Inner Join uommaster C on a.uom=c.uomcode "
            sqlstring = sqlstring & " order by a.groupcode"

            dt = gconnection.GetValues(sqlstring)
            Pno = 0
            Pno = Pno + 1
            Filewrite.WriteLine(Chr(15) & Chr(27) + "E" & gCompanyAddress(0) & Chr(27) + "F")
            Filewrite.Write(Chr(27) + "E" & "MENU DETAILS" & Chr(27) + "F" & Space(50) & "Page No:")
            Filewrite.WriteLine(Trim(CStr(Pno)))
            Filewrite.WriteLine("|" & StrDup(78, "-") & "|")
            Filewrite.WriteLine("|DESCRIPTION                                           UOM            Rate     |")
            Filewrite.WriteLine("|" & StrDup(78, "-") & "|")
            Desc = ""
            If dt.Rows.Count > 0 Then
                For i = 0 To dt.Rows.Count - 1
                    If Desc <> Trim(dt.Rows(i).Item("groupcode")) Then
                        Filewrite.WriteLine("|" & Space(78) & "|")
                        sqlstring = "|" & Space(2)
                        sqlstring = sqlstring & Mid(Trim(dt.Rows(i).Item("groupdesc")), 1, 30)
                        sqlstring = sqlstring & Space(30 - Len(Mid(Trim(dt.Rows(i).Item("groupdesc")), 1, 30)))
                        sqlstring = sqlstring & Space(46) & "|"
                        Filewrite.WriteLine(Chr(27) & "E" & sqlstring & Chr(27) & "F")
                        Filewrite.WriteLine("|" & Space(78) & "|")
                        Desc = Trim(dt.Rows(i).Item("groupcode"))
                    End If
                    sqlstring = "|" & Space(2) & Mid(Trim(dt.Rows(i).Item("itemdesc")), 1, 45)
                    sqlstring = sqlstring & Space(45 - Len(Mid(Trim(dt.Rows(i).Item("itemdesc")), 1, 45)))
                    sqlstring = sqlstring & Space(7) & Mid(Trim(dt.Rows(i).Item("uom")), 1, 10)
                    sqlstring = sqlstring & Space(10 - Len(Mid(Trim(dt.Rows(i).Item("uom")), 1, 10)))
                    sqlstring = sqlstring & Space(10 - Len(Mid(Format(dt.Rows(i).Item("rate"), "0.00"), 1, 10)))
                    sqlstring = sqlstring & Mid(Format(dt.Rows(i).Item("rate"), "0.00"), 1, 10) & Space(4) & "|"
                    Filewrite.WriteLine(sqlstring)
                    If pagesize > 60 Then
                        Pno = Pno + 1
                        Filewrite.WriteLine("|" & StrDup(78, "=") & "|" & Chr(12))
                        Pno = Pno + 1
                        Filewrite.WriteLine(Chr(15) & Chr(27) + "E" & gCompanyAddress(0) & Chr(27) + "F")
                        Filewrite.Write(Chr(27) + "E" & "MENU DETAILS" & Chr(27) + "F" & Space(50) & "Page No:")
                        Filewrite.WriteLine(Trim(CStr(Pno)))
                        Filewrite.WriteLine("|DESCRIPTION                                           UOM            Rate                         |")
                        Filewrite.WriteLine("|" & StrDup(78, "=") & "|")
                        pagesize = 1
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
    Private Sub CMDSCREEN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDSCREEN.Click
        gPrint = False
        Call menudetail()
    End Sub
    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT.Click
        gPrint = True
        Call menudetail()
    End Sub
    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        grp_HALLdetails.Visible = False
        Cmd_View2.Focus()
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
        vform.vFormatstring = " ITEM TYPE CODE | ITEM TYPE DESCRIPTION          "
        vform.vCaption = "ITEM TYPE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXTCGROUPCODE.Text = Trim(vform.keyfield & "")
            'Call TXTCGROUPCODE_Validated(TXTCGROUPCODE, e)
            TXTCGROUPCODE.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub TXTCGROUPCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTCGROUPCODE.Validated
        If TXTCGROUPCODE.Text <> "" Then
            sqlstring = " SELECT ITEMTYPECODE,ITEMDESC FROM VIEW_PARTY_GROUPMASTER  WHERE ItemTypeCode='" & Trim(TXTCGROUPCODE.Text) & "'"
            vconn.getDataSet(sqlstring, "ItemTypeMaster")
            If gdataset.Tables("ItemTypeMaster").Rows.Count > 0 Then
                TXTCGROUPDESC.Text = ""
                TXTCGROUPDESC.Text = Trim(gdataset.Tables("ItemTypeMaster").Rows(0).Item("ITEMDesc"))
                TXTCGROUPDESC.ReadOnly = True
                TXTUOMCODE.Focus()
            Else
                TXTCGROUPCODE.Clear()
                TXTCGROUPCODE.Clear()
                TXTCGROUPCODE.Focus()
            End If
        Else
            TXTCGROUPDESC.Clear()
        End If
    End Sub
    Private Sub TXTCGROUPCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTCGROUPCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTUOMCODE.Focus()
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
    Private Sub txtItemType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemType.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtItemType.Text) <> "" Then
                txtItemType_Validated(sender, e)


            Else

                Call Button3_Click(sender, e)
                OPENFACILITY.Focus()
            End If
            OPENFACILITY.Focus()
        End If

        'If Asc(e.KeyChar) = 13 Then
        '    Cmd_Add.Focus()
        'End If
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
            txtItemType.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub TXT_GLACCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_GLACCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXT_GLACCODE.Text) = "" Then
                Call CMD_GLACCODE_Click(sender, e)
            End If
            txtItemType.Focus()
        End If
    End Sub

    Private Sub TXTRATE_RightToLeftChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTRATE.RightToLeftChanged

    End Sub

    Private Sub TXTRATE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTRATE.TextChanged

    End Sub

    Private Sub TXTITEMCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTITEMCODE.TextChanged

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "VIEW_PARTY_PURPOSEHISTORY"
        sqlstring = "SELECT * FROM VIEW_PARTY_PURPOSEHISTORY"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub TXTGROUPCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTGROUPCODE.TextChanged

    End Sub

    Private Sub txtItemType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemType.TextChanged

    End Sub

    Private Sub TXT_GLACCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_GLACCODE.TextChanged

    End Sub

    Private Sub LST_TAX_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LST_TAX.SelectedIndexChanged

    End Sub

    Private Sub CMBCATEGORY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMBCATEGORY.KeyPress

        If Asc(e.KeyChar) = 13 Then
            If CMBCATEGORY.Text <> "" Then
                txtItemType.Focus()
            Else
                CMBCATEGORY.Focus()
            End If
        End If

    End Sub

    Private Sub CMBCATEGORY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.SelectedIndexChanged

    End Sub

    Private Sub CMBCATEGORY_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMBCATEGORY.Validated

    End Sub

    Private Sub CMB_TYPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMB_TYPE.SelectedIndexChanged

    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        clearoperaction()
        TXT_GLACCODE.Text = ""

        TXT_SUBGROUPCODE.Text = ""
        TXT_SUBGROUPDESC.Text = ""

        Call FILLTAX()
        'Call clearform(Me)
        If gUserCategory <> "S" Then
            Call GetRights()
        End If

    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strSQL, ITEMTYPECODE(), SQL, SQL1 As String
        Dim INSERT(0) As String
        Call checkValidation()
        If boolchk = False Then Exit Sub

        strSQL = "INSERT INTO PARTY_ITEMMASTER_LOG(ITEMCODE,ITEMDESC,TAXCODE,GROUPCODE,GROUPDESC,SUBGROUPCODE,SUBGROUPDESC,UOMCODE,UOMDESC,RATE,OPENFACILITY,CATEGORY,FREEZE,adduserid,ADDDATETIME)"
        strSQL = strSQL & " VALUES ('" & Trim(TXTITEMCODE.Text) & "','" & Trim(TXTITEMDESC.Text) & "', '" & Trim(txtItemType.Text) & "','" & TXTGROUPCODE.Text & "','" & Trim(TXTGROUPDESCRIPTION.Text) & "',"
        strSQL = strSQL & "'" & TXT_SUBGROUPCODE.Text & "','" & TXT_SUBGROUPDESC.Text & "',' " & TXTUOMCODE.Text & " ',' " & TXTUOMDESCRIPTION.Text & "'," & TXTRATE.Text & ","
        strSQL = strSQL & "'" & OPENFACILITY.Text & "','" & CMBCATEGORY.Text & "'"
        'If optYes.Checked = True Then
        '    strSQL = strSQL & " ,'Y'"
        'Else
        '    strSQL = strSQL & " ,'N'"
        'End If
        strSQL = strSQL & ",'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
        gconnection.dataOperation(6, strSQL, "PARTY_ITEMMASTER")

        If Cmd_Add.Text = "Add [F7]" Then
         

           

            vseqno = GetSeqno(TXTITEMCODE.Text)
            ' '' ''strSQL = "INSERT INTO PARTY_ITEMMASTER(CATEGORY,glaccode,ITEMCODE,ITEMDESC,ITEMTYPECODE,RATE,GROUPCODE,CGROUPCODE,UOM,SBFCHARGE,FREEZE,ADDUSERID,ADDDATETIME,TYPE)"
            ' '' ''strSQL = strSQL & " VALUES ( '" & Trim(CMBCATEGORY.Text) & "','" & Trim(TXT_GLACCODE.Text) & "','" & Trim(TXTITEMCODE.Text) & "','" & Trim(TXTITEMDESC.Text) & "'"
            ' '' ''strSQL = strSQL & ",'" & txtItemType.Text & "'," & TXTRATE.Text & ",'" & TXTGROUPCODE.Text & "','" & TXTCGROUPCODE.Text & "'"
            ' '' ''strSQL = strSQL & ",'" & TXTUOMCODE.Text & "'"
            ' '' ''If optYes.Checked = True Then
            ' '' ''    strSQL = strSQL & " ,'Y'"
            ' '' ''Else
            ' '' ''    strSQL = strSQL & " ,'N'"
            ' '' ''End If
            ' '' ''strSQL = strSQL & ",'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(CMB_TYPE.Text) & "')"
            ' '' ''gconnection.dataOperation(1, strSQL, "PARTY_ITEMMASTER")
            strSQL = "INSERT INTO PARTY_ITEMMASTER(ITEMCODE,ITEMDESC,TAXCODE,GROUPCODE,GROUPDESC,SUBGROUPCODE,SUBGROUPDESC,UOMCODE,UOMDESC,RATE,OPENFACILITY,CATEGORY,FREEZE,adduserid,ADDDATETIME)"
            strSQL = strSQL & " VALUES ('" & Trim(TXTITEMCODE.Text) & "','" & Trim(TXTITEMDESC.Text) & "', '" & Trim(txtItemType.Text) & "','" & TXTGROUPCODE.Text & "','" & Trim(TXTGROUPDESCRIPTION.Text) & "',"
            strSQL = strSQL & "'" & TXT_SUBGROUPCODE.Text & "','" & TXT_SUBGROUPDESC.Text & "',' " & TXTUOMCODE.Text & " ',' " & TXTUOMDESCRIPTION.Text & "'," & TXTRATE.Text & ","
            strSQL = strSQL & "'" & OPENFACILITY.Text & "','" & CMBCATEGORY.Text & "'"
            'If optYes.Checked = True Then
            '    strSQL = strSQL & " ,'Y'"
            'Else
            '    strSQL = strSQL & " ,'N'"
            'End If
            strSQL = strSQL & ",'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            gconnection.dataOperation(1, strSQL, "PARTY_ITEMMASTER")
            '=================================
            ' '' '' ''For i = 0 To LST_TAX.CheckedItems.Count - 1
            ' '' '' ''    SQL1 = "INSERT INTO party_itemmaster_tax(CATEGORY,glaccode,ITEMCODE,ITEMDESC,ITEMTYPECODE,RATE,GROUPCODE,CGROUPCODE,UOM,SBFCHARGE,FREEZE,ADDUSERID,ADDDATETIME,TYPE)"
            ' '' '' ''    SQL1 = strSQL & " VALUES ( '" & Trim(CMBCATEGORY.Text) & "','" & Trim(TXT_GLACCODE.Text) & "','" & Trim(TXTITEMCODE.Text) & "','" & Trim(TXTITEMDESC.Text) & "'"
            ' '' '' ''    ITEMTYPECODE = Split(LST_TAX.CheckedItems(i), "-->")
            ' '' '' ''    SQL1 = SQL1 & "'" & ITEMTYPECODE(0)
            ' '' '' ''    SQL1 = SQL1 & "," & TXTRATE.Text & ",'" & TXTGROUPCODE.Text & "','" & TXTCGROUPCODE.Text & "'"
            ' '' '' ''    SQL1 = SQL1 & ",'" & TXTUOMCODE.Text & "'"
            ' '' '' ''    If optYes.Checked = True Then
            ' '' '' ''        SQL1 = SQL1 & " ,'Y'"
            ' '' '' ''    Else
            ' '' '' ''        SQL1 = SQL1 & " ,'N'"
            ' '' '' ''    End If
            ' '' '' ''    SQL1 = SQL1 & ",'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(CMB_TYPE.Text) & "')"
            ' '' '' ''    ReDim Preserve INSERT(INSERT.Length)
            ' '' '' ''    INSERT(INSERT.Length - 1) = SQL1
            ' '' '' ''Next
            'gconnection.MoreTrans(INSERT)
            ''''''''''''''''''''''
            Me.Cmd_Clear_Click(sender, e)
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
            strSQL = "UPDATE  PARTY_ITEMMASTER "
            strSQL = strSQL & " SET ITEMDESC='" & Trim(TXTITEMDESC.Text) & "',"
            strSQL = strSQL & " TAXCODE ='" & Trim(txtItemType.Text) & "',"
            strSQL = strSQL & " CATEGORY ='" & Trim(CMBCATEGORY.Text) & "',"
            strSQL = strSQL & " OPENFACILITY ='" & Trim(OPENFACILITY.Text) & "',"
            strSQL = strSQL & " GLACCODE ='" & Trim(TXT_GLACCODE.Text) & "',"
            strSQL = strSQL & " GROUPCODE ='" & Trim(TXTGROUPCODE.Text) & "',"
            strSQL = strSQL & " GROUPDESC ='" & Trim(TXTGROUPDESCRIPTION.Text) & "',"
            strSQL = strSQL & " SUBGROUPCODE ='" & Trim(TXT_SUBGROUPCODE.Text) & "',"
            strSQL = strSQL & " SUBGROUPDESC ='" & Trim(TXT_SUBGROUPDESC.Text) & "',"

            ' strSQL = strSQL & " CGROUPCODE ='" & Trim(TXTCGROUPCODE.Text) & "',"
            '  strSQL = strSQL & " SBFCHARGE = '" & IIf(optYes.Checked = True, "Y", "N") & "',"
            strSQL = strSQL & " UOMCODE ='" & Trim(TXTUOMCODE.Text) & "',"
            strSQL = strSQL & " UOMDESC ='" & Trim(TXTUOMDESCRIPTION.Text) & "',"
            strSQL = strSQL & " RATE=" & Trim(TXTRATE.Text) & ","
            strSQL = strSQL & " AddUserId='" & Trim(gUsername) & "',AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
            strSQL = strSQL & " Where Itemcode = '" & Trim(TXTITEMCODE.Text) & "'"
            'gconnection.dataOperation(2, strSQL, "PARTY_ITEMMASTER")
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL
            '====================================
            SQL = "delete from party_itemmaster_tax where ITEMCODE='" & Me.TXTITEMCODE.Text & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = SQL
            '======================================
            For i = 0 To LST_TAX.CheckedItems.Count - 1
                SQL = "INSERT INTO party_itemmaster_tax(CATEGORY,glaccode,ITEMCODE,ITEMDESC,ITEMTYPECODE,RATE,GROUPCODE,CGROUPCODE,UOM,SBFCHARGE,FREEZE,ADDUSERID,ADDDATETIME,TYPE)"
                SQL = SQL & " VALUES ( '" & Trim(CMBCATEGORY.Text) & "','" & Trim(TXT_GLACCODE.Text) & "','" & Trim(TXTITEMCODE.Text) & "','" & Trim(TXTITEMDESC.Text) & "'"
                ITEMTYPECODE = Split(LST_TAX.CheckedItems(i), "-->")
                SQL = SQL & ",'" & ITEMTYPECODE(0)
                SQL = SQL & "','" & TXTRATE.Text & "','" & TXTGROUPCODE.Text & "','" & TXTCGROUPCODE.Text & "'"
                SQL = SQL & ",'" & TXTUOMCODE.Text & "'"
                If optYes.Checked = True Then
                    SQL = SQL & " ,'Y'"
                Else
                    SQL = SQL & " ,'N'"
                End If
                SQL = SQL & ",'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(CMB_TYPE.Text) & "')"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = SQL
            Next
            gconnection.MoreTrans(INSERT)
            '====================================
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub CMD_FREEZE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_FREEZE.Click
        Call checkValidation()
        If boolchk = False Then Exit Sub
        Dim ssql As String

        ssql = "select * from  PARTY_ITEMMASTER where  itemcode = '" & Trim(TXTITEMCODE.Text) & "'"
        gconnection.getDataSet(ssql, "log")
        If gdataset.Tables("log").Rows.Count > 0 Then
            If Mid(Me.CMD_FREEZE.Text, 1, 1) = "F" Then
                sqlstring = "UPDATE  PARTY_ITEMMASTER "
                sqlstring = sqlstring & " SET Freeze= 'Y',VOIDUSER='" & gUsername & " ', VOIDDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE itemcode = '" & Trim(TXTITEMCODE.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "Arrmaster")
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            Else
                sqlstring = "UPDATE  PARTY_ITEMMASTER "
                sqlstring = sqlstring & " SET Freeze= 'N',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE itemcode = '" & Trim(TXTITEMCODE.Text) & "'"
                gconnection.dataOperation(4, sqlstring, "Arrmaster")
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            End If
        Else
            MessageBox.Show("ITEM WAS NOT EXISTS ", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        End If
        
    End Sub

    Private Sub Cmd_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_view.Click
        Dim FRM As New ReportDesigner
        If TXTITEMCODE.Text.Length > 0 Then
            tables = " FROM PARTY_ITEMMASTER WHERE ITEMCODE ='" & TXTITEMCODE.Text & "' "
        Else
            tables = "FROM PARTY_ITEMMASTER "
        End If
        Gheader = "SESSION  DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"ITEMCODE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ITEMDESC", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"TAXCODE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
      
        ROW = New String() {"GROUPCODE", "5"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"GROUPDESC", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SUBGROUPCODE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"SUBGROUPDESC", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UOMCODE", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UOMDESC", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"OPENFACILITY", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"RATE", "9"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CATEGORY", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ' ''ROW = New String() {"roundval", "7"}
        ' ''FRM.DataGridView1.Rows.Add(ROW)


        ROW = New String() {"FREEZE", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSERID", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDDATETIME", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        '' '' '' ''ROW = New String() {"UPDATEUSER", "10"}
        '' '' '' ''FRM.DataGridView1.Rows.Add(ROW)
        '' '' '' ''ROW = New String() {"UPDATETIME", "10"}
        '' '' '' ''FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

    Private Sub CMD_EXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_EXIT.Click
        Me.Hide()
    End Sub

    Private Sub Cmdauth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdauth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        SSQLSTR2 = " SELECT * FROM PARTY_ITEMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
            gconnection.getDataSet(gSQLString, "AUTHORIZE")
            If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                    SSQLSTR2 = " SELECT * FROM PARTY_ITEMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                    gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                    If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                        Dim VIEW1 As New AUTHORISATION
                        VIEW1.Show()
                        VIEW1.DTAUTH.DataSource = Nothing
                        VIEW1.DTAUTH.Rows.Clear()
                        'Dim STRQUERY As String
                        'STRQUERY = "SELECT * FROM CORPORATEMASTER"
                        ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
                        'gconnection.getDataSet(STRQUERY, "authorize")

                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_ITEMMASTER set  ", "ITEMCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
                    End If
                Else
                    MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                End If
            End If
        Else
            SSQLSTR2 = " SELECT * FROM PARTY_ITEMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PARTY_ITEMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            'Dim STRQUERY As String
                            'STRQUERY = "SELECT * FROM CORPORATEMASTER"
                            ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
                            'gconnection.getDataSet(STRQUERY, "authorize")

                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_ITEMMASTER set  ", "ITEMCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            Else
                SSQLSTR2 = " SELECT * FROM PARTY_ITEMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
                    gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                    If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
                        gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                            SSQLSTR2 = " SELECT * FROM PARTY_ITEMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                                Dim VIEW1 As New AUTHORISATION
                                VIEW1.Show()
                                VIEW1.DTAUTH.DataSource = Nothing
                                VIEW1.DTAUTH.Rows.Clear()

                                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_ITEMMASTER set  ", "ITEMCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                            End If
                        End If
                    End If
                Else
                    MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
                End If
            End If
        End If
    End Sub

    Private Sub Cmdbwse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbwse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM PARTY_ITEMMASTER"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), True, "", "SELECT * FROM PARTY_ITEMMASTER", "ITEMcode", 1, Me.TXTITEMCODE)
        '  Call VIEW1.LOADGRID(gdataset.Tables("authorize"), True, "", "SELECT * FROM party_purposemaster", "hallcode", 1, Me.txt_PCode)

    End Sub

    Private Sub LBL_CATEGORY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBL_CATEGORY.Click

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub cmdType_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdType.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT isnull(ITEMCODE,'') as ITEMCODE,isnull(ITEMDESC,'') as ITEMDESC FROM PARTY_itemmaster"
            M_WhereCondition = " "
            vform.Field = "ITEMCODE ,ITEMDESC"
            ' vform.vFormatstring = "SESSION CODE    |     SESSION DESCRIPTION    "
            vform.vCaption = "Item Master Help"
            ''vform.KeyPos = 0
            ''vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXTITEMCODE.Text = Trim(vform.keyfield & "")
                'TXTITEMDESC.Text = Trim(vform.keyfield1 & "")
                TXTITEMCODE.Select()
                Call TXTITEMCODE_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub CMDSUBCODE_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CMDSUBCODE.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT isnull(GroupCode,'') as GroupCode,isnull(GroupDesc,'') as GroupDesc FROM groupmaster"
            M_WhereCondition = " WHERE ISNULL(FREEZE,'')<>'Y'"
            vform.Field = "GroupCode ,GroupDesc"
            ' vform.vFormatstring = "SESSION CODE    |     SESSION DESCRIPTION    "
            vform.vCaption = "Group Master Help"
            ''vform.KeyPos = 0
            ''vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXTGROUPCODE.Text = Trim(vform.keyfield & "")
                ' TXTCGROUPDESC.Text = Trim(vform.keyfield1 & "")
                TXTGROUPCODE.Select()
                Call TXTGROUPCODE_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub cmdGroup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGroup.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT isnull(subGroupCode,'') as subGroupCode,isnull(subGroupdesc,'') as subGroupdesc FROM subgroupmaster"
            M_WhereCondition = " WHERE ISNULL(FREEZE,'')<>'Y' "
            vform.Field = "subGroupCode ,subGroupdesc"
            ' vform.vFormatstring = "SESSION CODE    |     SESSION DESCRIPTION    "
            vform.vCaption = "SubGroup Master Help"
            ''vform.KeyPos = 0
            ''vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXT_SUBGROUPCODE.Text = Trim(vform.keyfield & "")
                '   TXT_SUBGROUPDESC.Text = Trim(vform.keyfield1 & "")
                TXT_SUBGROUPCODE.Select()
                Call TXT_SUBGROUPCODE_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT isnull(UOMCode,'') as UOMCode,isnull(UOMDesc,'') as UOMDesc FROM UoMMaster"
            M_WhereCondition = " WHERE ISNULL(FREEZE,'')<>'Y'"
            vform.Field = "UOMCode ,UOMDesc"
            ' vform.vFormatstring = "SESSION CODE    |     SESSION DESCRIPTION    "
            vform.vCaption = "UOM Master Help"
            ''vform.KeyPos = 0
            ''vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXTUOMCODE.Text = Trim(vform.keyfield & "")
                TXTUOMDESCRIPTION.Text = Trim(vform.keyfield1 & "")
                TXTRATE.Select()
                Call TXTUOMCODE_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button3.Click
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
                txtItemType.Text = Trim(vform.keyfield & "")
                txtItemType.Select()
                txtItemType_Validated(sender, e)
                'CmdAdd.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub TXTUOMCODE_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TXTUOMCODE.TextChanged

    End Sub



    Private Sub TXT_SUBGROUPCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_SUBGROUPCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXT_SUBGROUPCODE.Text) <> "" Then
                Call TXT_SUBGROUPCODE_Validated(TXTGROUPCODE, e)
            Else
                Call cmdGroup_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub TXT_SUBGROUPCODE_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_SUBGROUPCODE.TextChanged

    End Sub

    Private Sub TXT_SUBGROUPCODE_Validated(ByVal sender As Object, ByVal e As EventArgs) Handles TXT_SUBGROUPCODE.Validated

        If TXT_SUBGROUPCODE.Text <> "" Then
            sqlstring = "select SUBgroupcode,SUBgroupdesc,GroupCode,GroupDesc from SUBGroupmaster "
            sqlstring = sqlstring & " where SUBgroupcode='" & Trim(TXT_SUBGROUPCODE.Text) & "'AND ISNULL(FREEZE,'')<>'Y'"
            vconn.getDataSet(sqlstring, "GroupMaster")
            If gdataset.Tables("GroupMaster").Rows.Count > 0 Then
                TXT_SUBGROUPDESC.Text = ""
                TXT_SUBGROUPDESC.Text = Trim(gdataset.Tables("GroupMaster").Rows(0).Item("SUBGroupDesc"))
                TXTGROUPCODE.Text = Trim(gdataset.Tables("GroupMaster").Rows(0).Item("GroupCode"))
                TXTGROUPCODE_Validated(sender, e)
                TXT_SUBGROUPDESC.ReadOnly = True
                TXTUOMCODE.Focus()
            Else
                TXT_SUBGROUPCODE.Clear()
                TXT_SUBGROUPDESC.Clear()
                TXT_SUBGROUPCODE.Focus()
            End If
        End If
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub OPENFACILITY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OPENFACILITY.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If (OPENFACILITY.Text <> "") Then
                Cmd_Add.Focus()
            Else
                OPENFACILITY.Focus()
            End If
        End If
    End Sub

    Private Sub OPENFACILITY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OPENFACILITY.SelectedIndexChanged

    End Sub

    Private Sub Cmd_View2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View2.Click

    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_ADDTIONALITEMMASTER
        STR = "SELECT * FROM PAR_ITEMMASTER"
        Viewer.ssql = STR
        Viewer.Report = r
        Viewer.TableName = "PAR_ITEMMASTER"
        Dim textobj1 As TextObject
        textobj1 = r.ReportDefinition.ReportObjects("Text6")
        textobj1.Text = MyCompanyName

        Dim TXTOBJ2 As TextObject
        TXTOBJ2 = r.ReportDefinition.ReportObjects("Text11")
        TXTOBJ2.Text = "UserName : " & gUsername


        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = r.ReportDefinition.ReportObjects("Text15")
        TXTOBJ6.Text = Address1 & Address2

        Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ8 = r.ReportDefinition.ReportObjects("Text16")
        TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
        TXTOBJ9.Text = "PhoneNo : " & gphoneno
        Viewer.Show()

    End Sub

    Private Sub itemmst_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class
