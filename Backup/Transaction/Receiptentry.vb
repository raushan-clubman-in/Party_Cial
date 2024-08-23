Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class Receiptentry
    Inherits System.Windows.Forms.Form
    Dim vseqno As Double
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Dim gconn As New GlobalClass
    Dim i, j, k As Integer
    Dim ssql As String
    Dim DT As New DataTable
    Dim dgv As New DataTable
    Dim AMOUNT As Integer
    Dim receiptamount
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
    Friend WithEvents txtmcode As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtmname As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMBRECEIPTTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents cmd_mcodehelp As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DTPVOUCHERDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXTVOUCHERNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTHALLAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXTMENUAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXTARRAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents LABLASTVOUCHERNO As System.Windows.Forms.Label
    Friend WithEvents CMD_VOUCHERNOHELP As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TXTBOOKINGNO As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Dtppartydate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GRPRECEIPT As System.Windows.Forms.GroupBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents ssgrid_Receipt As AxFPSpreadADO.AxfpSpread
    Friend WithEvents com_payment As System.Windows.Forms.ComboBox
    Friend WithEvents INS_DATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents TXT_DRAWEEBANK As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TXT_INSNO As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents INS_TYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents bankdet As System.Windows.Forms.Panel
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TXT_AMT As System.Windows.Forms.TextBox
    Friend WithEvents TXT_CARDNO As System.Windows.Forms.TextBox
    Friend WithEvents LBL_CARD As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TXT_VOTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Txt_city As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TXTGUESTNAME As System.Windows.Forms.TextBox
    Friend WithEvents DTGRD As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Receiptentry))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TXTGUESTNAME = New System.Windows.Forms.TextBox
        Me.TXT_VOTYPE = New System.Windows.Forms.ComboBox
        Me.com_payment = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Dtppartydate = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.TXTBOOKINGNO = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.CMD_VOUCHERNOHELP = New System.Windows.Forms.Button
        Me.cmd_mcodehelp = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.DTPVOUCHERDATE = New System.Windows.Forms.DateTimePicker
        Me.txtmcode = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TXTVOUCHERNO = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtmname = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtDescription = New System.Windows.Forms.TextBox
        Me.LABLASTVOUCHERNO = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.CMBRECEIPTTYPE = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TXTHALLAMOUNT = New System.Windows.Forms.TextBox
        Me.TXTMENUAMOUNT = New System.Windows.Forms.TextBox
        Me.TXTARRAMOUNT = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.lbl_Freeze = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.Cmd_View = New System.Windows.Forms.Button
        Me.Cmd_Freeze = New System.Windows.Forms.Button
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.GRPRECEIPT = New System.Windows.Forms.GroupBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.ssgrid_Receipt = New AxFPSpreadADO.AxfpSpread
        Me.bankdet = New System.Windows.Forms.Panel
        Me.Txt_city = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.INS_DATE = New System.Windows.Forms.DateTimePicker
        Me.TXT_DRAWEEBANK = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.TXT_INSNO = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.INS_TYPE = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.TXT_AMT = New System.Windows.Forms.TextBox
        Me.LBL_CARD = New System.Windows.Forms.Label
        Me.TXT_CARDNO = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.DTGRD = New System.Windows.Forms.DataGrid
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GRPRECEIPT.SuspendLayout()
        CType(Me.ssgrid_Receipt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bankdet.SuspendLayout()
        CType(Me.DTGRD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.TXTGUESTNAME)
        Me.GroupBox1.Controls.Add(Me.TXT_VOTYPE)
        Me.GroupBox1.Controls.Add(Me.com_payment)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Dtppartydate)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TXTBOOKINGNO)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.CMD_VOUCHERNOHELP)
        Me.GroupBox1.Controls.Add(Me.cmd_mcodehelp)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.DTPVOUCHERDATE)
        Me.GroupBox1.Controls.Add(Me.txtmcode)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TXTVOUCHERNO)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtmname)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(112, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(856, 184)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label25.Location = New System.Drawing.Point(400, 152)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(124, 25)
        Me.Label25.TabIndex = 382
        Me.Label25.Text = "GUEST NAME"
        '
        'TXTGUESTNAME
        '
        Me.TXTGUESTNAME.BackColor = System.Drawing.Color.Wheat
        Me.TXTGUESTNAME.Enabled = False
        Me.TXTGUESTNAME.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGUESTNAME.Location = New System.Drawing.Point(552, 152)
        Me.TXTGUESTNAME.MaxLength = 50
        Me.TXTGUESTNAME.Name = "TXTGUESTNAME"
        Me.TXTGUESTNAME.Size = New System.Drawing.Size(256, 26)
        Me.TXTGUESTNAME.TabIndex = 381
        Me.TXTGUESTNAME.Text = ""
        '
        'TXT_VOTYPE
        '
        Me.TXT_VOTYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_VOTYPE.Items.AddRange(New Object() {"DEPOSIT", "REFUND", "ADVANCE"})
        Me.TXT_VOTYPE.Location = New System.Drawing.Point(552, 80)
        Me.TXT_VOTYPE.Name = "TXT_VOTYPE"
        Me.TXT_VOTYPE.Size = New System.Drawing.Size(176, 28)
        Me.TXT_VOTYPE.TabIndex = 380
        '
        'com_payment
        '
        Me.com_payment.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.com_payment.Items.AddRange(New Object() {"CARD", "CREDIT", "CHEQUE", "CASH"})
        Me.com_payment.Location = New System.Drawing.Point(552, 48)
        Me.com_payment.Name = "com_payment"
        Me.com_payment.Size = New System.Drawing.Size(176, 28)
        Me.com_payment.TabIndex = 379
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(400, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(148, 25)
        Me.Label16.TabIndex = 378
        Me.Label16.Text = "PAYMENT MODE"
        '
        'Dtppartydate
        '
        Me.Dtppartydate.CustomFormat = ""
        Me.Dtppartydate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtppartydate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtppartydate.Location = New System.Drawing.Point(552, 16)
        Me.Dtppartydate.Name = "Dtppartydate"
        Me.Dtppartydate.Size = New System.Drawing.Size(120, 26)
        Me.Dtppartydate.TabIndex = 377
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(400, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 25)
        Me.Label15.TabIndex = 376
        Me.Label15.Text = "PARTY DATE"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(256, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 26)
        Me.Button1.TabIndex = 375
        '
        'TXTBOOKINGNO
        '
        Me.TXTBOOKINGNO.BackColor = System.Drawing.Color.Wheat
        Me.TXTBOOKINGNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBOOKINGNO.Location = New System.Drawing.Point(160, 16)
        Me.TXTBOOKINGNO.MaxLength = 10
        Me.TXTBOOKINGNO.Name = "TXTBOOKINGNO"
        Me.TXTBOOKINGNO.Size = New System.Drawing.Size(96, 26)
        Me.TXTBOOKINGNO.TabIndex = 374
        Me.TXTBOOKINGNO.Text = ""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(8, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(124, 25)
        Me.Label14.TabIndex = 373
        Me.Label14.Text = "BOOKING NO"
        '
        'CMD_VOUCHERNOHELP
        '
        Me.CMD_VOUCHERNOHELP.Image = CType(resources.GetObject("CMD_VOUCHERNOHELP.Image"), System.Drawing.Image)
        Me.CMD_VOUCHERNOHELP.Location = New System.Drawing.Point(368, 56)
        Me.CMD_VOUCHERNOHELP.Name = "CMD_VOUCHERNOHELP"
        Me.CMD_VOUCHERNOHELP.Size = New System.Drawing.Size(24, 26)
        Me.CMD_VOUCHERNOHELP.TabIndex = 372
        '
        'cmd_mcodehelp
        '
        Me.cmd_mcodehelp.Image = CType(resources.GetObject("cmd_mcodehelp.Image"), System.Drawing.Image)
        Me.cmd_mcodehelp.Location = New System.Drawing.Point(264, 120)
        Me.cmd_mcodehelp.Name = "cmd_mcodehelp"
        Me.cmd_mcodehelp.Size = New System.Drawing.Size(24, 26)
        Me.cmd_mcodehelp.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(400, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(148, 25)
        Me.Label7.TabIndex = 369
        Me.Label7.Text = "RECEIPT TYPE"
        '
        'DTPVOUCHERDATE
        '
        Me.DTPVOUCHERDATE.CustomFormat = "dd/MM/yyyy"
        Me.DTPVOUCHERDATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPVOUCHERDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPVOUCHERDATE.Location = New System.Drawing.Point(160, 88)
        Me.DTPVOUCHERDATE.Name = "DTPVOUCHERDATE"
        Me.DTPVOUCHERDATE.Size = New System.Drawing.Size(120, 26)
        Me.DTPVOUCHERDATE.TabIndex = 2
        '
        'txtmcode
        '
        Me.txtmcode.BackColor = System.Drawing.Color.Wheat
        Me.txtmcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmcode.Location = New System.Drawing.Point(160, 120)
        Me.txtmcode.MaxLength = 15
        Me.txtmcode.Name = "txtmcode"
        Me.txtmcode.Size = New System.Drawing.Size(104, 26)
        Me.txtmcode.TabIndex = 4
        Me.txtmcode.Text = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(8, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(136, 25)
        Me.Label9.TabIndex = 362
        Me.Label9.Text = "MEMBER CODE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(8, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 25)
        Me.Label1.TabIndex = 362
        Me.Label1.Text = "RECEIPT DATE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 25)
        Me.Label2.TabIndex = 362
        Me.Label2.Text = "RECEIPT NO"
        '
        'TXTVOUCHERNO
        '
        Me.TXTVOUCHERNO.BackColor = System.Drawing.Color.Wheat
        Me.TXTVOUCHERNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTVOUCHERNO.Location = New System.Drawing.Point(160, 56)
        Me.TXTVOUCHERNO.MaxLength = 25
        Me.TXTVOUCHERNO.Name = "TXTVOUCHERNO"
        Me.TXTVOUCHERNO.Size = New System.Drawing.Size(208, 26)
        Me.TXTVOUCHERNO.TabIndex = 1
        Me.TXTVOUCHERNO.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(8, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 25)
        Me.Label5.TabIndex = 362
        '
        'txtmname
        '
        Me.txtmname.BackColor = System.Drawing.Color.Wheat
        Me.txtmname.Enabled = False
        Me.txtmname.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmname.Location = New System.Drawing.Point(552, 120)
        Me.txtmname.MaxLength = 50
        Me.txtmname.Name = "txtmname"
        Me.txtmname.Size = New System.Drawing.Size(256, 26)
        Me.txtmname.TabIndex = 6
        Me.txtmname.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(400, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(136, 25)
        Me.Label6.TabIndex = 362
        Me.Label6.Text = "MEMBER NAME"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(24, 224)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 25)
        Me.Label3.TabIndex = 362
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(-96, 192)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 25)
        Me.Label4.TabIndex = 362
        Me.Label4.Text = "HALL AMOUNT"
        '
        'TxtDescription
        '
        Me.TxtDescription.BackColor = System.Drawing.Color.Wheat
        Me.TxtDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(904, 288)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(104, 26)
        Me.TxtDescription.TabIndex = 3
        Me.TxtDescription.Text = ""
        Me.TxtDescription.Visible = False
        '
        'LABLASTVOUCHERNO
        '
        Me.LABLASTVOUCHERNO.AutoSize = True
        Me.LABLASTVOUCHERNO.BackColor = System.Drawing.Color.Transparent
        Me.LABLASTVOUCHERNO.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.LABLASTVOUCHERNO.ForeColor = System.Drawing.Color.Blue
        Me.LABLASTVOUCHERNO.Location = New System.Drawing.Point(648, 8)
        Me.LABLASTVOUCHERNO.Name = "LABLASTVOUCHERNO"
        Me.LABLASTVOUCHERNO.Size = New System.Drawing.Size(183, 25)
        Me.LABLASTVOUCHERNO.TabIndex = 371
        Me.LABLASTVOUCHERNO.Text = "LAST VOUCHERNO:"
        Me.LABLASTVOUCHERNO.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(-40, 256)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(136, 25)
        Me.Label10.TabIndex = 370
        Me.Label10.Text = "MENU AMOUNT"
        Me.Label10.Visible = False
        '
        'CMBRECEIPTTYPE
        '
        Me.CMBRECEIPTTYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBRECEIPTTYPE.Items.AddRange(New Object() {"CATERING ADVANCE", "BAR ADVANCE", "HALL ADVANCE", "ARRANGEMENT ADVANCE", "OTHER ADVANCE", "BILL"})
        Me.CMBRECEIPTTYPE.Location = New System.Drawing.Point(32, 128)
        Me.CMBRECEIPTTYPE.Name = "CMBRECEIPTTYPE"
        Me.CMBRECEIPTTYPE.Size = New System.Drawing.Size(24, 28)
        Me.CMBRECEIPTTYPE.TabIndex = 0
        Me.CMBRECEIPTTYPE.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(-40, 400)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(148, 25)
        Me.Label8.TabIndex = 362
        Me.Label8.Text = "RECEIPT TYPE"
        Me.Label8.Visible = False
        '
        'TXTHALLAMOUNT
        '
        Me.TXTHALLAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTHALLAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHALLAMOUNT.Location = New System.Drawing.Point(40, 200)
        Me.TXTHALLAMOUNT.MaxLength = 12
        Me.TXTHALLAMOUNT.Name = "TXTHALLAMOUNT"
        Me.TXTHALLAMOUNT.Size = New System.Drawing.Size(16, 26)
        Me.TXTHALLAMOUNT.TabIndex = 7
        Me.TXTHALLAMOUNT.Text = ""
        Me.TXTHALLAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTHALLAMOUNT.Visible = False
        '
        'TXTMENUAMOUNT
        '
        Me.TXTMENUAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTMENUAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMENUAMOUNT.Location = New System.Drawing.Point(48, 280)
        Me.TXTMENUAMOUNT.MaxLength = 12
        Me.TXTMENUAMOUNT.Name = "TXTMENUAMOUNT"
        Me.TXTMENUAMOUNT.Size = New System.Drawing.Size(8, 26)
        Me.TXTMENUAMOUNT.TabIndex = 8
        Me.TXTMENUAMOUNT.Text = ""
        Me.TXTMENUAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTMENUAMOUNT.Visible = False
        '
        'TXTARRAMOUNT
        '
        Me.TXTARRAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTARRAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTARRAMOUNT.Location = New System.Drawing.Point(72, 336)
        Me.TXTARRAMOUNT.MaxLength = 12
        Me.TXTARRAMOUNT.Name = "TXTARRAMOUNT"
        Me.TXTARRAMOUNT.Size = New System.Drawing.Size(16, 26)
        Me.TXTARRAMOUNT.TabIndex = 9
        Me.TXTARRAMOUNT.Text = ""
        Me.TXTARRAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTARRAMOUNT.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(-16, 312)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(124, 25)
        Me.Label11.TabIndex = 370
        Me.Label11.Text = "ARR.AMOUNT"
        Me.Label11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(312, 616)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(383, 18)
        Me.Label12.TabIndex = 421
        Me.Label12.Text = "Press F4 for HELP / Press ENTER key to navigate"
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Verdana", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(0, 568)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(192, 23)
        Me.lbl_Freeze.TabIndex = 420
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Location = New System.Drawing.Point(224, 560)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(592, 56)
        Me.GroupBox2.TabIndex = 419
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
        Me.Cmd_Clear.TabIndex = 11
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(355, 16)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 13
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
        Me.Cmd_Freeze.TabIndex = 12
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
        Me.Cmd_Add.TabIndex = 10
        Me.Cmd_Add.Text = "Add [F7]"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.Location = New System.Drawing.Point(469, 16)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 14
        Me.Cmd_Exit.Text = "Exit[F11]"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Courier New", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(312, 8)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(360, 34)
        Me.Label13.TabIndex = 422
        Me.Label13.Text = "BANQUET RECEIPT ENTRY"
        '
        'GRPRECEIPT
        '
        Me.GRPRECEIPT.BackColor = System.Drawing.Color.Transparent
        Me.GRPRECEIPT.Controls.Add(Me.Label28)
        Me.GRPRECEIPT.Controls.Add(Me.ssgrid_Receipt)
        Me.GRPRECEIPT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRPRECEIPT.ForeColor = System.Drawing.Color.Blue
        Me.GRPRECEIPT.Location = New System.Drawing.Point(120, 232)
        Me.GRPRECEIPT.Name = "GRPRECEIPT"
        Me.GRPRECEIPT.Size = New System.Drawing.Size(688, 208)
        Me.GRPRECEIPT.TabIndex = 844
        Me.GRPRECEIPT.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label28.Location = New System.Drawing.Point(0, -24)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(116, 20)
        Me.Label28.TabIndex = 392
        Me.Label28.Text = "HALL FACILITY"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ssgrid_Receipt
        '
        Me.ssgrid_Receipt.ContainingControl = Me
        Me.ssgrid_Receipt.DataSource = Nothing
        Me.ssgrid_Receipt.Location = New System.Drawing.Point(16, 16)
        Me.ssgrid_Receipt.Name = "ssgrid_Receipt"
        Me.ssgrid_Receipt.OcxState = CType(resources.GetObject("ssgrid_Receipt.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid_Receipt.Size = New System.Drawing.Size(664, 184)
        Me.ssgrid_Receipt.TabIndex = 393
        '
        'bankdet
        '
        Me.bankdet.BackColor = System.Drawing.Color.Transparent
        Me.bankdet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bankdet.Controls.Add(Me.Txt_city)
        Me.bankdet.Controls.Add(Me.Label24)
        Me.bankdet.Controls.Add(Me.INS_DATE)
        Me.bankdet.Controls.Add(Me.TXT_DRAWEEBANK)
        Me.bankdet.Controls.Add(Me.Label17)
        Me.bankdet.Controls.Add(Me.Label18)
        Me.bankdet.Controls.Add(Me.TXT_INSNO)
        Me.bankdet.Controls.Add(Me.Label19)
        Me.bankdet.Controls.Add(Me.INS_TYPE)
        Me.bankdet.Controls.Add(Me.Label21)
        Me.bankdet.Location = New System.Drawing.Point(72, 472)
        Me.bankdet.Name = "bankdet"
        Me.bankdet.Size = New System.Drawing.Size(888, 88)
        Me.bankdet.TabIndex = 845
        '
        'Txt_city
        '
        Me.Txt_city.BackColor = System.Drawing.Color.Wheat
        Me.Txt_city.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_city.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_city.Location = New System.Drawing.Point(664, 8)
        Me.Txt_city.MaxLength = 50
        Me.Txt_city.Name = "Txt_city"
        Me.Txt_city.Size = New System.Drawing.Size(208, 29)
        Me.Txt_city.TabIndex = 617
        Me.Txt_city.Text = ""
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(584, 8)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(72, 23)
        Me.Label24.TabIndex = 616
        Me.Label24.Text = "PLCAE"
        '
        'INS_DATE
        '
        Me.INS_DATE.CalendarFont = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INS_DATE.CustomFormat = "dd-MMM-yyyy HH:mm"
        Me.INS_DATE.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INS_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.INS_DATE.Location = New System.Drawing.Point(144, 48)
        Me.INS_DATE.Name = "INS_DATE"
        Me.INS_DATE.Size = New System.Drawing.Size(136, 26)
        Me.INS_DATE.TabIndex = 615
        '
        'TXT_DRAWEEBANK
        '
        Me.TXT_DRAWEEBANK.BackColor = System.Drawing.Color.Wheat
        Me.TXT_DRAWEEBANK.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_DRAWEEBANK.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DRAWEEBANK.Location = New System.Drawing.Point(432, 48)
        Me.TXT_DRAWEEBANK.MaxLength = 50
        Me.TXT_DRAWEEBANK.Name = "TXT_DRAWEEBANK"
        Me.TXT_DRAWEEBANK.Size = New System.Drawing.Size(224, 29)
        Me.TXT_DRAWEEBANK.TabIndex = 614
        Me.TXT_DRAWEEBANK.Text = ""
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(288, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(136, 23)
        Me.Label17.TabIndex = 613
        Me.Label17.Text = "DRAWEE BANK"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(0, 48)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(136, 23)
        Me.Label18.TabIndex = 612
        Me.Label18.Text = "INSTR. DATE"
        '
        'TXT_INSNO
        '
        Me.TXT_INSNO.BackColor = System.Drawing.Color.Wheat
        Me.TXT_INSNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_INSNO.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_INSNO.Location = New System.Drawing.Point(144, 8)
        Me.TXT_INSNO.MaxLength = 10
        Me.TXT_INSNO.Name = "TXT_INSNO"
        Me.TXT_INSNO.Size = New System.Drawing.Size(136, 29)
        Me.TXT_INSNO.TabIndex = 610
        Me.TXT_INSNO.Text = ""
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(0, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 23)
        Me.Label19.TabIndex = 609
        Me.Label19.Text = "INST. NO"
        '
        'INS_TYPE
        '
        Me.INS_TYPE.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.INS_TYPE.Items.AddRange(New Object() {"CARD", "CHEQUE", "DD", "PO"})
        Me.INS_TYPE.Location = New System.Drawing.Point(432, 8)
        Me.INS_TYPE.Name = "INS_TYPE"
        Me.INS_TYPE.Size = New System.Drawing.Size(144, 30)
        Me.INS_TYPE.TabIndex = 607
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(288, 8)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(136, 23)
        Me.Label21.TabIndex = 608
        Me.Label21.Text = "INSTR. TYPE"
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
        Me.Label20.Location = New System.Drawing.Point(40, 8)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(344, 23)
        Me.Label20.TabIndex = 595
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(448, 440)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(176, 23)
        Me.Label23.TabIndex = 846
        Me.Label23.Text = "TOTAL AMOUNT "
        Me.Label23.Visible = False
        '
        'TXT_AMT
        '
        Me.TXT_AMT.BackColor = System.Drawing.Color.Wheat
        Me.TXT_AMT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_AMT.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_AMT.Location = New System.Drawing.Point(616, 440)
        Me.TXT_AMT.MaxLength = 10
        Me.TXT_AMT.Name = "TXT_AMT"
        Me.TXT_AMT.Size = New System.Drawing.Size(192, 29)
        Me.TXT_AMT.TabIndex = 847
        Me.TXT_AMT.Text = ""
        Me.TXT_AMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXT_AMT.Visible = False
        '
        'LBL_CARD
        '
        Me.LBL_CARD.BackColor = System.Drawing.Color.Transparent
        Me.LBL_CARD.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_CARD.Location = New System.Drawing.Point(120, 440)
        Me.LBL_CARD.Name = "LBL_CARD"
        Me.LBL_CARD.Size = New System.Drawing.Size(128, 23)
        Me.LBL_CARD.TabIndex = 848
        Me.LBL_CARD.Text = "CARD. NO "
        '
        'TXT_CARDNO
        '
        Me.TXT_CARDNO.BackColor = System.Drawing.Color.Wheat
        Me.TXT_CARDNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_CARDNO.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_CARDNO.Location = New System.Drawing.Point(248, 440)
        Me.TXT_CARDNO.MaxLength = 25
        Me.TXT_CARDNO.Name = "TXT_CARDNO"
        Me.TXT_CARDNO.Size = New System.Drawing.Size(192, 29)
        Me.TXT_CARDNO.TabIndex = 849
        Me.TXT_CARDNO.Text = ""
        Me.TXT_CARDNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXT_CARDNO.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(8, 8)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(280, 28)
        Me.Label22.TabIndex = 850
        Me.Label22.Text = "RECEIPT  IS CANCELLED"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label22.Visible = False
        '
        'DTGRD
        '
        Me.DTGRD.DataMember = ""
        Me.DTGRD.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DTGRD.Location = New System.Drawing.Point(816, 248)
        Me.DTGRD.Name = "DTGRD"
        Me.DTGRD.Size = New System.Drawing.Size(200, 192)
        Me.DTGRD.TabIndex = 851
        '
        'Receiptentry
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1020, 646)
        Me.Controls.Add(Me.DTGRD)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TXT_CARDNO)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.TXTHALLAMOUNT)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TXTMENUAMOUNT)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TXTARRAMOUNT)
        Me.Controls.Add(Me.LABLASTVOUCHERNO)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TXT_AMT)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LBL_CARD)
        Me.Controls.Add(Me.bankdet)
        Me.Controls.Add(Me.GRPRECEIPT)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CMBRECEIPTTYPE)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label23)
        Me.ForeColor = System.Drawing.Color.Black
        Me.KeyPreview = True
        Me.Name = "Receiptentry"
        Me.Text = "Banquet Receipt Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GRPRECEIPT.ResumeLayout(False)
        CType(Me.ssgrid_Receipt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bankdet.ResumeLayout(False)
        CType(Me.DTGRD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call autogeneratePARTY()
        DTGRD.DataSource = Nothing
        DTPVOUCHERDATE.Value = Format("dd/MM/yyyy", Now())
        Dtppartydate.Value = Format("dd/MM/yyyy", Now())
        txtmcode.Text = ""
        TxtDescription.Text = ""
        TXTBOOKINGNO.Text = ""
        Label22.Visible = False
        com_payment.Text = ""
        txtmcode.Text = ""
        txtmname.Text = ""
        TXTGUESTNAME.Text = ""
        TXT_CARDNO.Visible = False
        LBL_CARD.Visible = False
        TXT_CARDNO.Text = ""
        bankdet.Visible = False
        Txt_city.Text = ""
        ssgrid_Receipt.ClearRange(1, 1, -1, -1, True)
        Call BILLGENERATE()
        Call autogeneratePARTY()
        If Trim(com_payment.Text) = "CHEQUE" Then
            bankdet.Visible = True
        ElseIf Trim(com_payment.Text) = "DD" Then
            bankdet.Visible = True
        Else
            bankdet.Visible = False
        End If
        txtmname.Text = ""
        TXTGUESTNAME.Text = ""
        com_payment.Text = ""
        TXT_VOTYPE.Text = ""
        LABLASTVOUCHERNO.Visible = True
        LABLASTVOUCHERNO.Text = ""
        TXTVOUCHERNO.ReadOnly = False
        lbl_Freeze.Visible = False
        Cmd_Add.Enabled = True
        Cmd_Add.Text = "Add [F7]"
        TXTBOOKINGNO.Focus()
        Call autogeneratePARTY()
        com_payment.Text = "CASH"
        TXT_AMT.Text = "0.00"
    End Sub
    Private Sub autogeneratePARTY()
        Dim DOCTYPE As String
        DOCTYPE = "PAR"
        Dim sqlstring, financalyear As String

        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
        Try
            sqlstring = "SELECT MAX(Cast(SUBSTRING(PARTYRECEIPTNO,5,6) As VARCHAR)) AS  PARTYRECEIPTNO FROM party_receipt_HDR  "
            gconnection.openConnection()
            gcommand = New SqlCommand(sqlstring, gconnection.Myconn)
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then

                If gdreader(0) Is System.DBNull.Value Then
                    TXTVOUCHERNO.Text = DOCTYPE & "/000001" & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    TXTVOUCHERNO.Text = DOCTYPE & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                End If
            Else
                TXTVOUCHERNO.Text = DOCTYPE & "/000001" & "/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        Dim DT As New DataTable
        Dim VOUNO As Integer
        Dim INSERT(0) As String
        LABLASTVOUCHERNO.Visible = True
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            Call autogeneratePARTY()
            strSQL = " INSERT INTO party_receipt_HDR(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,DESCRIPTION,MCODE,MNAME,GUESTNAME,adduserid,adddatetime,"
            strSQL = strSQL & "UPDATEuserid,UPDATEadddatetime,freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT,CARDNUMBER,PLACE)"
            strSQL = strSQL & " VALUES ( '" & Trim(TXTBOOKINGNO.Text) & "',"
            strSQL = strSQL & "'" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
            strSQL = strSQL & "'" & Trim(TXTVOUCHERNO.Text) & "'"
            strSQL = strSQL & ",'" & Format(DTPVOUCHERDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "','" & Trim(com_payment.Text) & "','" & TxtDescription.Text & "'"
            strSQL = strSQL & ",'" & Trim(txtmcode.Text) & "','" & Trim(txtmname.Text) & "','" & Trim(TXTGUESTNAME.Text) & "'"
            strSQL = strSQL & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            strSQL = strSQL & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N'"
            strSQL = strSQL & ",'" & Trim(INS_TYPE.Text) & "','" & Trim(TXT_VOTYPE.Text) & "',"
            strSQL = strSQL & "'" & Trim(TXT_INSNO.Text) & "',"
            strSQL = strSQL & "'" & Trim(TXT_DRAWEEBANK.Text) & "','" & Format(INS_DATE.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
            strSQL = strSQL & "'" & Format(Val(TXT_AMT.Text), 0.0) & "','" & Trim(TXT_CARDNO.Text) & "','" & Trim(Txt_city.Text) & "')"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL
            With ssgrid_Receipt
                For i = 1 To .DataRowCnt
                    strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,DESCRIPTION,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                    strSQL = strSQL & "UPDATEuserid,UPDATEadddatetime,freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT)"
                    strSQL = strSQL & " VALUES ( '" & Trim(TXTBOOKINGNO.Text) & "',"
                    strSQL = strSQL & "'" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                    strSQL = strSQL & "'" & Trim(TXTVOUCHERNO.Text) & "'"
                    strSQL = strSQL & ",'" & Format(DTPVOUCHERDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "','" & Trim(com_payment.Text) & "','" & TxtDescription.Text & "'"
                    strSQL = strSQL & ",'" & Trim(txtmcode.Text) & "','" & Trim(txtmname.Text) & "','" & Trim(TXTGUESTNAME.Text) & "'"
                    ssgrid_Receipt.Row = i
                    ssgrid_Receipt.Col = 1
                    strSQL = strSQL & ",'" & Trim(ssgrid_Receipt.Text) & "'"
                    ssgrid_Receipt.Col = 2
                    strSQL = strSQL & ",'" & Trim(ssgrid_Receipt.Text) & "'"
                    ssgrid_Receipt.Col = 3
                    strSQL = strSQL & "," & Val(ssgrid_Receipt.Text) & ""
                    strSQL = strSQL & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                    strSQL = strSQL & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N'"
                    strSQL = strSQL & ",'" & Trim(INS_TYPE.Text) & "','" & Trim(TXT_VOTYPE.Text) & "',"
                    strSQL = strSQL & "'" & Trim(TXT_INSNO.Text) & "',"
                    strSQL = strSQL & "'" & Trim(TXT_DRAWEEBANK.Text) & "','" & Format(INS_DATE.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                    strSQL = strSQL & "'" & Format(Val(TXT_AMT.Text), 0.0) & "')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = strSQL
                Next
            End With
            sqlstring = "UPDATE POSKOTDOC SET DOCNO = ISNULL(DOCNO,0) + 1 WHERE DOCTYPE = 'PARTY'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = sqlstring
            'TWO TABLE  RECORD INSERTING HERE
            gconn.MoreTrans(INSERT)

            If MsgBox("Do you want windows print to Annexure........", MsgBoxStyle.OKCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then
                'Call hallbilling()
            Else
                Call RECEIT()
            End If

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
            strSQL = "UPDATE  party_receipt_HDR"
            strSQL = strSQL & " SET PARTYRECEIPTDATE='" & Format(DTPVOUCHERDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
            strSQL = strSQL & " BOOKINGNO ='" & Trim(TXTBOOKINGNO.Text) & "',"
            strSQL = strSQL & " PARTYDATE ='" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
            strSQL = strSQL & " description ='" & Trim(TxtDescription.Text) & "',"
            strSQL = strSQL & " Mcode ='" & Trim(txtmcode.Text) & "',"
            strSQL = strSQL & " MNAME ='" & Trim(txtmname.Text) & "',"
            strSQL = strSQL & " GUESTNAME ='" & Trim(TXTGUESTNAME.Text) & "',"
            strSQL = strSQL & " PAYMENTMODE ='" & Trim(com_payment.Text) & "',"
            strSQL = strSQL & " INSTTYPE ='" & Trim(INS_TYPE.Text) & "',"
            strSQL = strSQL & " INSTNO ='" & Trim(TXT_INSNO.Text) & "',"
            strSQL = strSQL & " RECEIPTTYPE='" & Trim(TXT_VOTYPE.Text) & "',"
            strSQL = strSQL & " DRAWBANK ='" & Trim(TXT_DRAWEEBANK.Text) & "',"
            strSQL = strSQL & " INSTDATE ='" & Format(INS_DATE.Value, "dd/MMM/yyyy") & "',"
            strSQL = strSQL & " UPDATEuserid='" & Trim(gUsername) & "',"
            strSQL = strSQL & " TOTALAMOUNT='" & Format(Val(TXT_AMT.Text), 0.0) & "',"
            strSQL = strSQL & " CARDNUMBER='" & Trim(TXT_INSNO.Text) & "',"
            strSQL = strSQL & " UPDATEadddatetime ='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
            strSQL = strSQL & " Where PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL
            With ssgrid_Receipt
                strSQL = " DELETE FROM party_receipt_DET "
                strSQL = strSQL & " Where PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = strSQL
                For i = 1 To .DataRowCnt
                    strSQL = " INSERT INTO party_receipt_DET(BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,DESCRIPTION,MCODE,MNAME,GUESTNAME,Receiptheadcode,Receiptheaddesc,AMOUNT,adduserid,adddatetime,"
                    strSQL = strSQL & "UPDATEuserid,UPDATEadddatetime,freeze,INSTTYPE,RECEIPTTYPE,INSTNO,DRAWBANK,INSTDATE,TOTALAMOUNT)"
                    strSQL = strSQL & " VALUES ( '" & Trim(TXTBOOKINGNO.Text) & "',"
                    strSQL = strSQL & "'" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                    strSQL = strSQL & "'" & Trim(TXTVOUCHERNO.Text) & "'"
                    strSQL = strSQL & ",'" & Format(DTPVOUCHERDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "','" & Trim(com_payment.Text) & "','" & TxtDescription.Text & "'"
                    strSQL = strSQL & ",'" & Trim(txtmcode.Text) & "','" & Trim(txtmname.Text) & "','" & Trim(TXTGUESTNAME.Text) & "'"
                    ssgrid_Receipt.Row = i
                    ssgrid_Receipt.Col = 1
                    strSQL = strSQL & ",'" & Trim(ssgrid_Receipt.Text) & "'"
                    ssgrid_Receipt.Col = 2
                    strSQL = strSQL & ",'" & Trim(ssgrid_Receipt.Text) & "'"
                    ssgrid_Receipt.Col = 3
                    strSQL = strSQL & "," & Val(ssgrid_Receipt.Text) & ""
                    strSQL = strSQL & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                    strSQL = strSQL & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','N'"
                    strSQL = strSQL & ",'" & Trim(INS_TYPE.Text) & "','" & Trim(TXT_VOTYPE.Text) & "',"
                    strSQL = strSQL & "'" & Trim(TXT_INSNO.Text) & "',"
                    strSQL = strSQL & "'" & Trim(TXT_DRAWEEBANK.Text) & "','" & Format(INS_DATE.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                    strSQL = strSQL & "'" & Format(Val(TXT_AMT.Text), 0.0) & "')"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = strSQL
                Next
            End With
            gconn.MoreTrans(INSERT)
            If MsgBox("Do you want windows print to Annexure........", MsgBoxStyle.OKCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then
                'Call hallbilling()
            Else
                Call RECEIT()
            End If
        End If
        Call Cmd_Clear_Click(sender, e)
    End Sub
    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation()
        If boolchk = False Then Exit Sub
        Dim Fre, strsql As String
        Try
            'If Val(TXTVOUCHERNO.Text) >= 1 And Val(TXTVOUCHERNO.Text) <= 9 Then
            '    strsql = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/0000" & Trim(CStr(Val(TXTVOUCHERNO.Text))))
            '    strsql = strsql & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            '    strsql = strsql & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            'ElseIf Val(TXTVOUCHERNO.Text) >= 10 And Val(TXTVOUCHERNO.Text) <= 99 Then
            '    strsql = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/000" & Trim(CStr(Val(TXTVOUCHERNO.Text))))
            '    strsql = strsql & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            '    strsql = strsql & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            'ElseIf Val(TXTVOUCHERNO.Text) >= 100 And Val(TXTVOUCHERNO.Text) <= 999 Then
            '    strsql = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/00" & Trim(CStr(Val(TXTVOUCHERNO.Text))))
            '    strsql = strsql & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            '    strsql = strsql & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            'ElseIf Val(TXTVOUCHERNO.Text) >= 1000 And Val(TXTVOUCHERNO.Text) <= 9999 Then
            '    strsql = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/0" & Trim(CStr(Val(TXTVOUCHERNO.Text))))
            '    strsql = strsql & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            '    strsql = strsql & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            'Else
            '    strsql = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/" & Trim(CStr(Val(TXTVOUCHERNO.Text))))
            '    strsql = strsql & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            '    strsql = strsql & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            'End If
            sqlstring = "UPDATE party_receipt_DET SET Freeze= 'Y' Where  PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "' "
            gconnection.getDataSet(sqlstring, "party_receipt_DET")
            If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then

                sqlstring = "UPDATE party_receipt_hdr "
                sqlstring = sqlstring & " SET Freeze= 'Y',AddUserId='" & gUsername & " ',"
                sqlstring = sqlstring & " AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " Where  PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "'"
                gconnection.dataOperation(3, sqlstring, "RECEIPT")
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub checkValidation()
        boolchk = False
        If Trim(TXTBOOKINGNO.Text) = "" Then '
            MessageBox.Show("Booing No  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTBOOKINGNO.Focus()
            Exit Sub
        End If
        ssql = "Select  * from  PARTY_HALLBOOKING_HDR where bookingno=" & TXTBOOKINGNO.Text & " AND  Isnull(cancelflag,'')='Y'"
        DT = gconnection.GetValues(ssql)
        If DT.Rows.Count > 0 Then
            MessageBox.Show(" This Booking is Cancelled Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        'If Trim(TxtDescription.Text) = "" Then
        '    MessageBox.Show("Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    TxtDescription.Focus()
        '    Exit Sub
        'End If
        If Trim(TXT_VOTYPE.Text) = "" Then
            MessageBox.Show("VOUCHER can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtDescription.Focus()
            Exit Sub
        End If
        If Trim(DTPVOUCHERDATE.Text) = "" Then
            MessageBox.Show("VoucherDate Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            DTPVOUCHERDATE.Focus()
            Exit Sub
        End If
        If Trim(txtmcode.Text) = "" Then
            MessageBox.Show("Mcode can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtmcode.Focus()
            Exit Sub
        End If
        If Trim(txtmname.Text) = "" Then
            MessageBox.Show("Member Name Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtmcode.Focus()
            Exit Sub
        End If

        If Trim(com_payment.Text) = "" Then
            MessageBox.Show("Payment Mode can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            com_payment.Focus()
            Exit Sub
        End If
        With ssgrid_Receipt
            For i = 1 To .DataRowCnt
                .Row = i
                .Col = 3
                receiptamount = Val(.Text)
            Next
        End With
        If Val(receiptamount) <= "0" Or Val(receiptamount) < "0.00" Then
            MessageBox.Show("PLEASE ENTER THE VALID RECEIPT AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        'If Val(TXT_AMT.Text) <= "0" Or Val(TXT_AMT.Text) < "0.00" Then
        '    MessageBox.Show("PLEASE ENTER THE VALID RECEIPT AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        'If Val(AMOUNT) <= "0" Or Val(AMOUNT) < "0.00" Then
        '    MessageBox.Show("PLEASE ENTER THE RECEIPT AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        If Trim(com_payment.Text) = "CHEQUE" Then
            If Trim(com_payment.Text) = "" Then
                MessageBox.Show("Payment Mode can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                com_payment.Focus()
                Exit Sub
            End If
            If Trim(TXT_INSNO.Text) = "" Then
                MessageBox.Show("insrtument no can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_INSNO.Focus()
                Exit Sub
            End If
            If Trim(Txt_city.Text) = "" Then
                MessageBox.Show("PLACE  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Txt_city.Focus()
                Exit Sub
            End If
            If Trim(TXT_DRAWEEBANK.Text) = "" Then '
                MessageBox.Show("Drawee Bank  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXT_DRAWEEBANK.Focus()
                Exit Sub
            End If
            'If Val(TXT_AMT.Text) <= "0" Or Val(TXT_AMT.Text) < "0.00" Then
            '    MessageBox.Show("PLEASE ENTER THE VALID  RECEIPT AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End If
            'If Val(AMOUNT) <= "0" Or Val(AMOUNT) < "0.00" Then
            '    MessageBox.Show("PLEASE ENTER THE RECEIPT AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    Exit Sub
            'End If
        End If
        boolchk = True
    End Sub
    Private Sub RECEIT()
        Dim Viewer As New ReportViwer
        Dim r1 As New partreceiptVoucher
        Dim i As Integer
        Dim sqlstring, sqlstring1 As String
        sqlstring = " SELECT * from partyreceiptvoucher  WHERE PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "' "
        gconnection.getDataSet(sqlstring, "PARTYRECEIPTNO")
        sqlstring1 = " SELECT * from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "' "
        gconnection.getDataSet(sqlstring1, "PARTYRECEIPTNO")
        If (gdataset.Tables("PARTYRECEIPTNO").Rows.Count > 0) Then

            Call Viewer.GetDetails1(sqlstring, "partyreceiptvoucher", r1)
            Call Viewer.GetDetails1(sqlstring1, "partyreceiptvoucher1", r1)

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text11")
            TXTOBJ5.Text = MyCompanyName

            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text12")
            TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r1.ReportDefinition.ReportObjects("Text13")
            TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text14")
            TXTOBJ9.Text = "PhoneNo : " & gphoneno

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text16")
            TXTOBJ1.Text = "UserName : " & gUsername
            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If

    End Sub
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        Call RECEIT()
        'Dim Viewer As New ReportViwer
        'Dim r1 As New partreceiptVoucher
        'Dim i As Integer
        'Dim sqlstring, sqlstring1 As String
        'sqlstring = " SELECT * from partyreceiptvoucher  WHERE PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "' "
        'gconnection.getDataSet(sqlstring, "PARTYRECEIPTNO")
        'sqlstring1 = " SELECT * from partyreceiptvoucher1  WHERE PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "' "
        'gconnection.getDataSet(sqlstring1, "PARTYRECEIPTNO")
        'Call Viewer.GetDetails1(sqlstring, "partyreceiptvoucher", r1)
        'Call Viewer.GetDetails1(sqlstring1, "partyreceiptvoucher1", r1)

        ''Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text11")
        ''TXTOBJ5.Text = MyCompanyName
        ''Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text12")
        ''TXTOBJ6.Text = Address1
        ''Dim TXTOBJ7 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''TXTOBJ7 = r1.ReportDefinition.ReportObjects("Text13")
        ''TXTOBJ7.Text = Address2
        ''Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''TXTOBJ8 = r1.ReportDefinition.ReportObjects("Text14")
        ''TXTOBJ8.Text = gCity
        '''Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        '''TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text15")
        '''TXTOBJ8.Text = gState
        '''Dim TXTOBJ10 As CrystalDecisions.CrystalReports.Engine.TextObject
        '''TXTOBJ10 = r1.ReportDefinition.ReportObjects("Text16")
        '''TXTOBJ10.Text = gPincode

        ''Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        ''TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text9")
        ''TXTOBJ1.Text = "UserName : " & gUsername
        ''Viewer.Show()
        'Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text11")
        'TXTOBJ5.Text = MyCompanyName
        'Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text12")
        'TXTOBJ6.Text = Address1 & Address2

        'Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ8 = r1.ReportDefinition.ReportObjects("Text13")
        'TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text14")
        'TXTOBJ9.Text = "PhoneNo : " & gphoneno

        'Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text16")
        'TXTOBJ1.Text = "UserName : " & gUsername
        'Viewer.Show()

    End Sub
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Hide()
    End Sub
    Private Sub Receiptentry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TXTBOOKINGNO.Focus()
        Call Cmd_Clear_Click(sender, e)
        TXTVOUCHERNO.ReadOnly = False
        TXTBOOKINGNO.Focus()
        Label22.Visible = False
        bankdet.Visible = False
        LBL_CARD.Visible = False
        com_payment.DropDownStyle = ComboBoxStyle.DropDownList
        TXT_VOTYPE.DropDownStyle = ComboBoxStyle.DropDownList
        Call BILLGENERATE()
        Call autogeneratePARTY()
        TXTBOOKINGNO.Focus()
    End Sub
    Private Sub Calculate()

        Dim dblTotalamount, amount, sum As Double
        Me.TXT_AMT.Text = "0.00"
        'Me.txt_total.Text = "0.00"
        With ssgrid_Receipt
            TXT_AMT.Text = ""
            For i = 1 To .DataRowCnt
                .Col = 3
                .Row = i
                amount = .Text
                Me.TXT_AMT.Text = Format(Val(Me.TXT_AMT.Text) + Val(amount), "0.00")
                'txt_total.Text = Val(txt_total.Text) + TOTAL
            Next
        End With
    End Sub
    Private Function TOT_AMT1(ByVal ssgrid_Receipt As AxFPSpreadADO.AxfpSpread) As Double
        Dim _Totamount, _taxamount As Double
        _Totamount = 0
        With ssgrid_Receipt
            For i = 1 To .DataRowCnt
                .Col = 3
                .Row = i
                _Totamount = _Totamount + Math.Round(Val(.Text), 2)
            Next i
            Return Math.Round((_Totamount + _taxamount), 2)
        End With
    End Function

    Private Function Itemamt(ByVal _ssgrid As AxFPSpreadADO.AxfpSpread) As Double
        Dim _amount As Double
        _amount = 0
        With _ssgrid
            For i = 1 To .DataRowCnt
                .Col = 3
                .Row = i
                _amount = _amount + Val(.Text)
            Next i
            Return Math.Round(_amount, 2)
        End With
    End Function
    Private Sub BILLGENERATE()
        Dim sqlstring, financalyear As String
        Dim billint As Integer
        Try
            gcommand = New SqlCommand
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialYearEnd, 3, 4)
            sqlstring = "SELECT Isnull(DocNo,0) FROM PoSKotDoc Where DocType = 'PAR'"
            gconnection.openConnection()
            gcommand.CommandText = sqlstring
            gcommand.CommandType = CommandType.Text
            gcommand.Connection = gconnection.Myconn
            gdreader = gcommand.ExecuteReader
            If gdreader.Read Then
                If gdreader(0) Is System.DBNull.Value Then
                    TXTVOUCHERNO.Text = "000001/" & financalyear
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()
                Else
                    TXTVOUCHERNO.Text = "PAR" & "/" & Format(gdreader(0) + 1, "000000") & "/" & financalyear
                    billint = gdreader(0)
                    gdreader.Close()
                    gcommand.Dispose()
                    gconnection.closeConnection()

                End If
            Else
                TXTVOUCHERNO.Text = "000001/" & financalyear
                gdreader.Close()
                gcommand.Dispose()
                gconnection.closeConnection()
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            gdreader.Close()
            gcommand.Dispose()
            gconnection.closeConnection()
        End Try
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
    Private Sub cmd_mcodehelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_mcodehelp.Click
        Dim vform As New ListOperattion1
        Try
            gSQLString = "Select Mcode,Mname From MemberMaster"
            M_WhereCondition = " "
            vform.Field = "Mcode,Mname"
            vform.vFormatstring = " Member Code  | Member Name                           "
            vform.vCaption = "Member Master Help"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtmcode.Text = Trim(vform.keyfield & "")
                txtmname.Text = Trim(vform.keyfield1 & "")
                txtmcode.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtmcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmcode.Validated
        If txtmcode.Text <> "" Then
            sqlstring = "Select mname From MemberMaster Where Mcode='" & Trim(txtmcode.Text) & "' "
            gconnection.getDataSet(sqlstring, "MemberMaster")
            If gdataset.Tables("MemberMaster").Rows.Count > 0 Then
                txtmname.Text = ""
                txtmname.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("Mname"))
                txtmname.ReadOnly = True
                'TXTHALLAMOUNT.Focus()
            Else
                txtmcode.Clear()
                txtmname.Clear()
                'TXTHALLAMOUNT.Focus()
            End If
        Else
            txtmname.Clear()
        End If
    End Sub
    Private Sub CMBRECEIPTTYPE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMBRECEIPTTYPE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            DTPVOUCHERDATE.Focus()
        End If
    End Sub
    Private Sub TXTVOUCHERNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTVOUCHERNO.KeyPress
        If Asc(e.KeyChar) = 13 Then
            DTPVOUCHERDATE.Focus()
        End If
    End Sub
    Private Sub DTPVOUCHERDATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPVOUCHERDATE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            com_payment.Focus()
        End If
    End Sub
    Private Sub TxtDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescription.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtmcode.Focus()
        End If
    End Sub
    Private Sub txtmcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmcode.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Asc(e.KeyChar) = 13 Then
                    If Trim(txtmcode.Text) <> "" Then
                        Call txtmcode_Validated(txtmcode, e)
                    Else
                        Call cmd_mcodehelp_Click(sender, e)
                    End If
                End If
                ssgrid_Receipt.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub txtmname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmname.TextChanged
    End Sub
    Private Sub TXTHALLAMOUNT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTHALLAMOUNT.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTMENUAMOUNT.Focus()
        End If
    End Sub
    Private Sub TXTMENUAMOUNT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMENUAMOUNT.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTARRAMOUNT.Focus()
        End If
    End Sub
    Private Sub TXTARRAMOUNT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTARRAMOUNT.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cmd_Add.Focus()
        End If
    End Sub
    Private Sub TXTVOUCHERNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTVOUCHERNO.Validated
        sqlstring = "SELECT BOOKINGNO,PARTYDATE,PARTYRECEIPTNO,PARTYRECEIPTDATE,PAYMENTMODE,DESCRIPTION,MCODE,MNAME,ISNULL(GUESTNAME,'')AS GUESTNAME,RECEIPTTYPE FROM party_receipt_DET WHERE PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "'"
        gconnection.getDataSet(sqlstring, "party_receipt_DET")
        If gdataset.Tables("party_receipt_DET").Rows.Count > 0 Then
            TXTBOOKINGNO.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("bookingno")
            Dtppartydate.Value = Format(gdataset.Tables("party_receipt_DET").Rows(0).Item("partydate"), "dd/MM/yyyy")
            com_payment.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("PAYMENTMODE")
            DTPVOUCHERDATE.Value = Format(gdataset.Tables("party_receipt_DET").Rows(0).Item("PARTYRECEIPTDATE"), "dd/MM/yyyy")
            TxtDescription.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("DESCRIPTION")
            txtmcode.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("mcode")
            txtmname.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("mname")
            TXTGUESTNAME.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("GUESTNAME")
            TXT_VOTYPE.Text = gdataset.Tables("party_receipt_DET").Rows(0).Item("RECEIPTTYPE")
        Else

        End If
        sqlstring = "SELECT * FROM party_receipt_HDR where PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "' AND FREEZE='Y'"
        gconnection.getDataSet(sqlstring, "party_receipt_HDR")
        If gdataset.Tables("party_receipt_hdr").Rows.Count > 0 Then
            Label22.Visible = True
        End If
        sqlstring = "SELECT cardnumber,ISNULL(PLACE,'') AS PLACE from party_receipt_hdr where PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "'"
        gconnection.getDataSet(sqlstring, "party_receipt_hdr")
        If gdataset.Tables("party_receipt_hdr").Rows.Count > 0 Then
            TXT_CARDNO.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("cardnumber")
            Txt_city.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("PLACE") 'INSTNO,INSDATE,DRAWBANK
            ' TXT_INSNO.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("INSTNO")
            'INS_DATE.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("INSDATE")
            'TXT_DRAWEEBANK.Text = gdataset.Tables("party_receipt_hdr").Rows(0).Item("DRAWBANK")
        End If
        sqlstring = "SELECT Receiptheadcode,Receiptheaddesc,amount,RECEIPTTYPE from party_receipt_DET WHERE PARTYRECEIPTNO='" & Me.TXTVOUCHERNO.Text & "'"
        DT = gconnection.GetValues(sqlstring)
        If DT.Rows.Count > 0 Then
            ssgrid_Receipt.ClearRange(-1, -1, 1, 1, True)
            With ssgrid_Receipt
                For i = 0 To DT.Rows.Count - 1
                    .Col = 1
                    .Row = i + 1
                    .Text = DT.Rows(i).Item("Receiptheadcode")
                    .Col = 2
                    .Row = i + 1
                    .Text = DT.Rows(i).Item("Receiptheaddesc")
                    .Col = 3
                    .Row = i + 1
                    .Text = DT.Rows(i).Item("amount")
                Next
            End With
            Me.Cmd_Add.Text = "Update[F7]"

        End If

        'Me.Cmd_Add.Text = "Update[F7]"
    End Sub
    Private Sub GridUnLock()
        Dim i, j As Integer
        For i = 1 To 100
            For j = 1 To 5
                ssgrid_Receipt.Col = j
                ssgrid_Receipt.Row = i
                ssgrid_Receipt.Lock = False
            Next j
        Next i
    End Sub
    Private Sub txtmname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmname.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTGUESTNAME.Focus()
        End If
    End Sub
    Private Sub Receiptentry_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub txtmcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmcode.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmd_mcodehelp_Click(sender, e)
        End If
    End Sub

    Private Sub txtmname_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmname.KeyUp

    End Sub

    Private Sub TxtDescription_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescription.TextChanged

    End Sub

    Private Sub txtmcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmcode.TextChanged

    End Sub
    Private Sub CMBRECEIPTTYPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBRECEIPTTYPE.SelectedIndexChanged
        Call Lastvoucherno()
    End Sub
    Private Sub TXTVOUCHERNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTVOUCHERNO.TextChanged
    End Sub
    Private Sub Lastvoucherno()
        Dim STRSQL As String
        Dim VOUNO As Integer
        Dim DT As New DataTable
        LABLASTVOUCHERNO.Visible = True
        LABLASTVOUCHERNO.Text = ""
        STRSQL = "SELECT ISNULL(MAX(CONVERT(INT,SUBSTRING(VOUCHERNO,5,5))),0) AS MAXNO FROM PARTY_RECEIPT "
        STRSQL = STRSQL & " WHERE SUBSTRING(LTRIM(VOUCHERNO),1,3)='" & Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "'"
        DT = gconnection.GetValues(STRSQL)
        If DT.Rows.Count > 0 Then
            VOUNO = DT.Rows(0).Item(0)
        Else
            VOUNO = 1
        End If
        If VOUNO >= 1 And VOUNO <= 9 Then
            STRSQL = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/0000" & Trim(CStr(VOUNO)))
            STRSQL = STRSQL & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            STRSQL = STRSQL & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            LABLASTVOUCHERNO.Text = STRSQL
        ElseIf VOUNO >= 10 And VOUNO <= 99 Then
            STRSQL = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/000" & Trim(CStr(VOUNO)))
            STRSQL = STRSQL & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            STRSQL = STRSQL & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            LABLASTVOUCHERNO.Text = STRSQL
        ElseIf VOUNO >= 100 And VOUNO <= 999 Then
            STRSQL = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/00" & Trim(CStr(VOUNO)))
            STRSQL = STRSQL & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            STRSQL = STRSQL & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            LABLASTVOUCHERNO.Text = STRSQL
        ElseIf VOUNO >= 1000 And VOUNO <= 9999 Then
            STRSQL = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/0" & Trim(CStr(VOUNO)))
            STRSQL = STRSQL & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            STRSQL = STRSQL & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            LABLASTVOUCHERNO.Text = STRSQL
        Else
            STRSQL = Trim(Mid(Trim(CMBRECEIPTTYPE.Text), 1, 3) & "/" & Trim(CStr(VOUNO)))
            STRSQL = STRSQL & Trim("/" & Mid(gFinancalyearStart, 3, 2))
            STRSQL = STRSQL & "-" & Trim(Mid(gFinancialYearEnd, 3, 2))
            LABLASTVOUCHERNO.Text = STRSQL
        End If
    End Sub
    Private Sub CMD_VOUCHERNOHELP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_VOUCHERNOHELP.Click
        Dim vform As New ListOperattion1
        Try
            gSQLString = "Select DISTINCT PARTYRECEIPTNO,PARTYRECEIPTDATE,BOOKINGNO,PARTYDATE,MCODE,MNAME,DESCRIPTION FROM party_receipt_DET "
            M_WhereCondition = ""
            vform.Field = "PARTYRECEIPTNO,PARTYRECEIPTDATE"
            vform.vFormatstring = " PARTYRECEIPTNO        | PARTYRECEIPTDATE       |   BOOKINGNO       |    PARTYDATE       |  MCODE    |   MNAME           |   DESCRIPTION     |"
            vform.vCaption = "Member Master Help"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXTVOUCHERNO.Text = Trim(vform.keyfield & "")
                DTPVOUCHERDATE.Text = Trim(vform.keyfield1 & "")
                Call TXTVOUCHERNO_Validated(sender, e)
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        TXTVOUCHERNO.ReadOnly = True
    End Sub
    Private Sub TXTVOUCHERNO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTVOUCHERNO.KeyDown
        If e.KeyCode = Keys.F4 Then
            CMD_VOUCHERNOHELP_Click(sender, e)
        End If
    End Sub

    Private Sub ssgrid_Receipt_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid_Receipt.Advance

    End Sub
    Private Sub ssgrid_Receipt_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid_Receipt.KeyDownEvent
        Dim partyheadcode As String
        Dim AMOUNT As Integer
        With ssgrid_Receipt
            If e.keyCode = Keys.Enter Then
                i = .ActiveRow
                If .ActiveCol = 1 Then
                    .Row = i
                    .Col = 1
                    If Trim(.Text) = "" Then
                        Call FillMenu()
                    ElseIf Trim(.Text) <> "" Then
                        partyheadcode = Trim(.Text)
                        .ClearRange(1, .ActiveRow, 3, .ActiveRow, True)

                        sqlstring = "SELECT  DISTINCT RECEIPTHEADCODE,Receiptheaddesc FROM party_Head_master"
                        sqlstring = sqlstring & " WHERE RECEIPTHEADCODE='" & partyheadcode & "'"
                        gconnection.getDataSet(sqlstring, "partyheadcode")
                        If gdataset.Tables("partyheadcode").Rows.Count > 0 Then
                            .Col = 1
                            .Row = i
                            .Text = gdataset.Tables("partyheadcode").Rows(0).Item("RECEIPTHEADCODE")
                            .Col = 2
                            .Row = i
                            .Text = gdataset.Tables("partyheadcode").Rows(0).Item("Receiptheaddesc")
                            .SetActiveCell(3, .ActiveRow)
                            .Focus()

                        Else
                            .ClearRange(1, .ActiveRow, 1, .ActiveRow, True)
                            .SetActiveCell(1, .ActiveRow)
                            .Focus()
                        End If
                    End If
                ElseIf .ActiveCol = 2 Then
                    If Val(.Text) = 0 Then
                        .SetActiveCell(3, .ActiveRow)
                        .Focus()
                    Else
                        .SetActiveCell(2, .ActiveRow)
                    End If
                ElseIf .ActiveCol = 3 Then
                    .Col = 3
                    .Row = i
                    AMOUNT = .Text
                    If Val(AMOUNT) <> 0 Then
                        .SetActiveCell(1, .ActiveRow + 1)
                        .Focus()
                        AMOUNT = .Text
                        'TXT_AMT.Text = Format((ssgrid_Receipt), "0.00")
                        TXT_AMT.Text = AMOUNT
                    ElseIf Val(.Text) = 0 Then
                        .SetActiveCell(1, .ActiveRow)
                        .Focus()
                    End If
                End If

                'Call Calculate()
            ElseIf e.keyCode = Keys.F3 Then
                .Row = .ActiveRow
                .ClearRange(1, .ActiveRow, 3, .ActiveRow, True)
                .DeleteRows(.ActiveRow, 1)
                .SetActiveCell(1, .ActiveRow)
            End If
        End With

    End Sub
    Private Sub FillMenu()
        Try
            Dim vform As New ListOperattion1

            Dim ssql As String

            gSQLString = "SELECT DISTINCT RECEIPTHEADCODE,Receiptheaddesc FROM party_Head_master"
            If Trim(Search) = " " Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " "
            End If
            vform.Field = "RECEIPTHEADCODE"
            vform.vFormatstring = "RECEIPTHEADCODE    |RECEIPT HEADDESC  "
            vform.vCaption = "RECEIPT HEAD CODE HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            'vform.Keypos3 = 3
            'vform.keypos4 = 4
            vform.ShowDialog(Me)

            If Trim(vform.keyfield & "") <> "" Then
                With ssgrid_Receipt
                    .Col = 1
                    .Row = .ActiveRow
                    .Text = vform.keyfield
                    .Col = 2
                    .Row = .ActiveRow
                    .Text = vform.keyfield1
                    '.Col = 3
                    '.Row = .ActiveRow
                    '.Text = vform.keyfield2
                    '.Col = 4
                    '.Row = .ActiveRow
                    '.Text = Format(CDate(vform.keyfield3), "dd/MM/yyyy")

                    '.Col = 5
                    '.Row = .ActiveRow
                    '.Text = vform.keyfield4

                    '.Col = 7
                    '.Row = .ActiveRow
                    '.Text = Format(Now, "dd/MM/yyyy")

                    '.SetText(8, i, "N")

                    .SetActiveCell(3, .ActiveRow)

                End With
            Else
                ssgrid_Receipt.SetActiveCell(0, ssgrid_Receipt.ActiveRow)
                Exit Sub
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub HALLHEAD()
        Dim vform As New ListOperattion1
        Dim ssql As String
        gSQLString = "SELECT DISTINCT RECEIPTHEADCODE,Receiptheaddesc FROM party_Head_master "
        If Trim(Search) = " " Then
            M_WhereCondition = " "
        Else
            M_WhereCondition = " where ISNULL(FREEZE,'') <>'Y' "
        End If
        vform.Field = "RECEIPTHEADCODE,Receiptheaddesc"
        vform.vFormatstring = "RECEIPTHEADCODE     |RECEIPT HEAD DESCRIPTION     "
        vform.vCaption = "RECEIPT HEAD CODE HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With ssgrid_Receipt
                .Col = 1
                .Row = .ActiveRow
                .Text = vform.keyfield
                .Col = 2
                .Row = .ActiveRow
                .Text = vform.keyfield1

            End With
            ssgrid_Receipt.SetActiveCell(3, ssgrid_Receipt.ActiveRow)
        Else

            Exit Sub

        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub TXTBOOKINGNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBOOKINGNO.TextChanged
    End Sub

    Private Sub TXTBOOKINGNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBOOKINGNO.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            'Dtppartydate.Focus()
            com_payment.Focus()
        End If
    End Sub

    Private Sub TXTBOOKINGNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBOOKINGNO.Validated

        If Trim(TXTBOOKINGNO.Text) <> "" Then
            sqlstring = "select * from VIEW_PARTY_BOOKINGDETAILS WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & ""
            gconnection.getDataSet(sqlstring, "HallStatus")
            If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                Dtppartydate.Value = Format(gdataset.Tables("HallStatus").Rows(0).Item("partydate"), "dd/MM/yyyy")
                txtmcode.Text = gdataset.Tables("HallStatus").Rows(0).Item("mcode")
                txtmname.Text = gdataset.Tables("HallStatus").Rows(0).Item("mname")
                TXTGUESTNAME.Text = gdataset.Tables("HallStatus").Rows(0).Item("GUESTNAME")
                TxtDescription.Text = gdataset.Tables("HallStatus").Rows(0).Item("Description")
                sqlstring = "SELECT PARTYRECEIPTNO,Receiptheaddesc,AMOUNT FROM party_receipt_DET  WHERE ISNULL(FREEZE,'')<>'Y' AND BOOKINGNO=" & TXTBOOKINGNO.Text & ""
                gconnection.getDataSet(sqlstring, "PAY")
                If gdataset.Tables("PAY").Rows.Count > 0 Then
                    DTGRD.DataSource = gdataset.Tables("PAY")
                End If
            Else
                If MsgBox("PARTICULAR BOOKING IS NOT FOUND...", MsgBoxStyle.OKCancel, "BANQUET") = MsgBoxResult.OK Then
                    TXTBOOKINGNO.Clear()
                    TXTBOOKINGNO.Focus()
                End If
            End If
        End If
        Dtppartydate.Enabled = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim vform As New ListOperattion1
            gSQLString = "SELECT DISTINCT ISNULL(BOOKINGNO,0) AS BOOKINGNO,ISNULL(partyDATE,'')AS PARTYDATE,BOOKINGDATE AS BOOKINGDATE,MCODE "
            gSQLString = gSQLString & "  FROM  PARTY_HALLBOOKING_HDR"
            If Trim(Search) = " " Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " "
            End If
            vform.Field = "BOOKINGNO,PARTYDATE,BOOKINGDATE,MCODE"
            vform.vFormatstring = "BOOKINGNO |   PARTYDATE   |  BOOKING DATE     |        MCODE    "
            vform.vCaption = "HALL RESERVATION HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXTBOOKINGNO.Text = Trim(vform.keyfield & "")
                Dtppartydate.Text = Trim(vform.keyfield1 & "")
                Call TXTBOOKINGNO_Validated(sender, e)
                Dtppartydate.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Dtppartydate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtppartydate.ValueChanged

    End Sub

    Private Sub Dtppartydate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dtppartydate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTVOUCHERNO.Focus()
        End If
    End Sub

    Private Sub DTPVOUCHERDATE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPVOUCHERDATE.ValueChanged

    End Sub

    Private Sub com_payment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles com_payment.SelectedIndexChanged
        If Trim(com_payment.Text) = "CHEQUE" Then
            TXT_CARDNO.Visible = False
            LBL_CARD.Visible = False
            bankdet.Visible = True
        ElseIf Trim(com_payment.Text) = "DD" Then
            LBL_CARD.Visible = False
            TXT_CARDNO.Visible = False
            bankdet.Visible = True
        ElseIf Trim(com_payment.Text) = "CARD" Then
            LBL_CARD.Visible = True
            TXT_CARDNO.Visible = True
            bankdet.Visible = False
        ElseIf Trim(com_payment.Text) = "CREDIT" Then
            LBL_CARD.Visible = False
            TXT_CARDNO.Visible = False
            bankdet.Visible = False
        Else
            bankdet.Visible = False
        End If
    End Sub

    Private Sub com_payment_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles com_payment.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXT_VOTYPE.Focus()
        End If
    End Sub

    Private Sub txtmcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmcode.LostFocus
        Try
            Dim dt As New DataTable
            If txtmcode.Text <> "" Then
                sqlstring = "Select ISNULL(MNAME,'') AS MNAME from membermaster where mcode='" & txtmcode.Text & "'"
                dt = gconnection.GetValues(sqlstring)
                If dt.Rows.Count > 0 Then
                    txtmname.Text = dt.Rows(0).Item("mname")
                Else
                    MessageBox.Show("Member Code Not Found,Please Check ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtmcode.Text = ""
                    txtmcode.Focus()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub com_payment_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles com_payment.Validated

    End Sub

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

    End Sub


    Private Sub ssgrid_Receipt_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid_Receipt.LeaveCell
        'Dim amount As Double
        'Dim Receiptheaddesc, Receiptheadcode As String
        'With ssgrid_Receipt

        'End With

    End Sub

    Private Sub TXT_VOTYPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_VOTYPE.SelectedIndexChanged

        If Trim(TXT_VOTYPE.Text) = "DEPOSIT" Then
        ElseIf Trim(TXT_VOTYPE.Text) = "REFUND" Then
        ElseIf Trim(TXT_VOTYPE.Text) = "ADVANCE" Then
        End If

    End Sub

    Private Sub Label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label25.Click

    End Sub

    Private Sub TXTGUESTNAME_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTGUESTNAME.TextChanged

    End Sub

    Private Sub TXTGUESTNAME_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGUESTNAME.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTHALLAMOUNT.Focus()
        End If
    End Sub

    Private Sub TXT_VOTYPE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_VOTYPE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ssgrid_Receipt.SetActiveCell(1, 1)
            ssgrid_Receipt.Focus()
        End If
    End Sub

    Private Sub ssgrid_Receipt_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ssgrid_Receipt.Leave

    End Sub

    Private Sub TXT_AMT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_AMT.TextChanged

    End Sub
End Class
