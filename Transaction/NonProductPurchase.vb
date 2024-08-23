Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Public Class NonProductPurchase
    Inherits System.Windows.Forms.Form
    Dim Vconn As New GlobalClass
    Dim Updateyes As Boolean
    Dim total As Double = 0
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Export As System.Windows.Forms.Button
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Delete As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmd_MemberCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Dim DRCR As String
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
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_Total As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txt_customerName As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_VoucherNoHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_VoucherPrefix As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Cmb_VoucherType As System.Windows.Forms.ComboBox
    Friend WithEvents Txt_Naration As System.Windows.Forms.TextBox
    Friend WithEvents Txt_VoucherNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Dtp_VoucherDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Txt_CustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Cmd_CustomerCodeHelp As System.Windows.Forms.Button
    Friend WithEvents lbl_void As System.Windows.Forms.Label
    Friend WithEvents SSGrid_ReceiptsPayments As AxFPSpreadADO.AxfpSpread
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents CmdDelete As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents Lbl_LastVoucher As System.Windows.Forms.Label
    Friend WithEvents Txt_BillAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Cmb_CashCredit As System.Windows.Forms.ComboBox
    Friend WithEvents Gpr_Supplier As System.Windows.Forms.GroupBox
    Friend WithEvents Lbl_Supplier As System.Windows.Forms.Label
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Txt_EsiSec As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_TdsSec As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txt_EsiAmt As System.Windows.Forms.TextBox
    Friend WithEvents Txt_WorksSec As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PfSec As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PurSec As System.Windows.Forms.TextBox
    Friend WithEvents Txt_TdsPer As System.Windows.Forms.TextBox
    Friend WithEvents Txt_EsiPer As System.Windows.Forms.TextBox
    Friend WithEvents Txt_WorksPer As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PfPer As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PurPer As System.Windows.Forms.TextBox
    Friend WithEvents Txt_TdsAmt As System.Windows.Forms.TextBox
    Friend WithEvents Txt_WorksAmt As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PfAmt As System.Windows.Forms.TextBox
    Friend WithEvents Txt_PurAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Ssgrid_Bill As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Txt_TotDed As System.Windows.Forms.TextBox
    Friend WithEvents txt_netamt As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdcrystal As System.Windows.Forms.Button
    Friend WithEvents LBL_COMPANYNAME As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NonProductPurchase))
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Txt_Total = New System.Windows.Forms.TextBox()
        Me.Gpr_Supplier = New System.Windows.Forms.GroupBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmd_MemberCodeHelp = New System.Windows.Forms.Button()
        Me.txt_netamt = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Ssgrid_Bill = New AxFPSpreadADO.AxfpSpread()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Cmb_CashCredit = New System.Windows.Forms.ComboBox()
        Me.Txt_BillAmt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txt_customerName = New System.Windows.Forms.TextBox()
        Me.Cmd_VoucherNoHelp = New System.Windows.Forms.Button()
        Me.Txt_VoucherPrefix = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Cmb_VoucherType = New System.Windows.Forms.ComboBox()
        Me.Txt_Naration = New System.Windows.Forms.TextBox()
        Me.Txt_VoucherNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Dtp_VoucherDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_CustomerCode = New System.Windows.Forms.TextBox()
        Me.Lbl_Supplier = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmd_CustomerCodeHelp = New System.Windows.Forms.Button()
        Me.lbl_void = New System.Windows.Forms.Label()
        Me.SSGrid_ReceiptsPayments = New AxFPSpreadADO.AxfpSpread()
        Me.frmbut = New System.Windows.Forms.GroupBox()
        Me.cmdcrystal = New System.Windows.Forms.Button()
        Me.CmdAdd = New System.Windows.Forms.Button()
        Me.CmdDelete = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.Lbl_LastVoucher = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Txt_TotDed = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Txt_EsiSec = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Txt_TdsSec = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Txt_EsiAmt = New System.Windows.Forms.TextBox()
        Me.Txt_WorksSec = New System.Windows.Forms.TextBox()
        Me.Txt_PfSec = New System.Windows.Forms.TextBox()
        Me.Txt_PurSec = New System.Windows.Forms.TextBox()
        Me.Txt_TdsPer = New System.Windows.Forms.TextBox()
        Me.Txt_EsiPer = New System.Windows.Forms.TextBox()
        Me.Txt_WorksPer = New System.Windows.Forms.TextBox()
        Me.Txt_PfPer = New System.Windows.Forms.TextBox()
        Me.Txt_PurPer = New System.Windows.Forms.TextBox()
        Me.Txt_TdsAmt = New System.Windows.Forms.TextBox()
        Me.Txt_WorksAmt = New System.Windows.Forms.TextBox()
        Me.Txt_PfAmt = New System.Windows.Forms.TextBox()
        Me.Txt_PurAmt = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.LBL_COMPANYNAME = New System.Windows.Forms.Label()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Export = New System.Windows.Forms.Button()
        Me.Cmd_Print = New System.Windows.Forms.Button()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.Cmd_Delete = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Gpr_Supplier.SuspendLayout()
        CType(Me.Ssgrid_Bill, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SSGrid_ReceiptsPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmbut.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(557, 583)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(57, 15)
        Me.Label15.TabIndex = 136
        Me.Label15.Text = "TOTAL :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(184, 62)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(325, 26)
        Me.Label10.TabIndex = 135
        Me.Label10.Text = "PURCHASE NON PRODUCT"
        '
        'Txt_Total
        '
        Me.Txt_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Total.Location = New System.Drawing.Point(630, 583)
        Me.Txt_Total.Name = "Txt_Total"
        Me.Txt_Total.Size = New System.Drawing.Size(184, 20)
        Me.Txt_Total.TabIndex = 137
        Me.Txt_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Gpr_Supplier
        '
        Me.Gpr_Supplier.BackColor = System.Drawing.Color.Transparent
        Me.Gpr_Supplier.Controls.Add(Me.Label18)
        Me.Gpr_Supplier.Controls.Add(Me.DateTimePicker1)
        Me.Gpr_Supplier.Controls.Add(Me.Button2)
        Me.Gpr_Supplier.Controls.Add(Me.TextBox2)
        Me.Gpr_Supplier.Controls.Add(Me.Label17)
        Me.Gpr_Supplier.Controls.Add(Me.Button1)
        Me.Gpr_Supplier.Controls.Add(Me.cmd_MemberCodeHelp)
        Me.Gpr_Supplier.Controls.Add(Me.txt_netamt)
        Me.Gpr_Supplier.Controls.Add(Me.Label16)
        Me.Gpr_Supplier.Controls.Add(Me.Ssgrid_Bill)
        Me.Gpr_Supplier.Controls.Add(Me.Label8)
        Me.Gpr_Supplier.Controls.Add(Me.Cmb_CashCredit)
        Me.Gpr_Supplier.Controls.Add(Me.Txt_BillAmt)
        Me.Gpr_Supplier.Controls.Add(Me.Label7)
        Me.Gpr_Supplier.Controls.Add(Me.Label13)
        Me.Gpr_Supplier.Controls.Add(Me.txt_customerName)
        Me.Gpr_Supplier.Controls.Add(Me.Cmd_VoucherNoHelp)
        Me.Gpr_Supplier.Controls.Add(Me.Txt_VoucherPrefix)
        Me.Gpr_Supplier.Controls.Add(Me.Label14)
        Me.Gpr_Supplier.Controls.Add(Me.Cmb_VoucherType)
        Me.Gpr_Supplier.Controls.Add(Me.Txt_Naration)
        Me.Gpr_Supplier.Controls.Add(Me.Txt_VoucherNo)
        Me.Gpr_Supplier.Controls.Add(Me.Label4)
        Me.Gpr_Supplier.Controls.Add(Me.Dtp_VoucherDate)
        Me.Gpr_Supplier.Controls.Add(Me.Label3)
        Me.Gpr_Supplier.Controls.Add(Me.Txt_CustomerCode)
        Me.Gpr_Supplier.Controls.Add(Me.Lbl_Supplier)
        Me.Gpr_Supplier.Controls.Add(Me.Label2)
        Me.Gpr_Supplier.Controls.Add(Me.Cmd_CustomerCodeHelp)
        Me.Gpr_Supplier.Location = New System.Drawing.Point(176, 91)
        Me.Gpr_Supplier.Name = "Gpr_Supplier"
        Me.Gpr_Supplier.Size = New System.Drawing.Size(642, 324)
        Me.Gpr_Supplier.TabIndex = 132
        Me.Gpr_Supplier.TabStop = False
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(260, 104)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(104, 18)
        Me.Label18.TabIndex = 227
        Me.Label18.Text = "PARTY DATE"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(370, 103)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(108, 20)
        Me.DateTimePicker1.TabIndex = 226
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Button2.Location = New System.Drawing.Point(204, 98)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 23)
        Me.Button2.TabIndex = 225
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(131, 102)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(77, 20)
        Me.TextBox2.TabIndex = 222
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(10, 103)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(118, 18)
        Me.Label17.TabIndex = 223
        Me.Label17.Text = "BOOKING NO"
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.No
        Me.Button1.Location = New System.Drawing.Point(528, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 23)
        Me.Button1.TabIndex = 221
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmd_MemberCodeHelp
        '
        Me.cmd_MemberCodeHelp.BackgroundImage = CType(resources.GetObject("cmd_MemberCodeHelp.BackgroundImage"), System.Drawing.Image)
        Me.cmd_MemberCodeHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmd_MemberCodeHelp.DialogResult = System.Windows.Forms.DialogResult.No
        Me.cmd_MemberCodeHelp.Location = New System.Drawing.Point(441, 69)
        Me.cmd_MemberCodeHelp.Name = "cmd_MemberCodeHelp"
        Me.cmd_MemberCodeHelp.Size = New System.Drawing.Size(32, 23)
        Me.cmd_MemberCodeHelp.TabIndex = 220
        Me.cmd_MemberCodeHelp.UseVisualStyleBackColor = True
        '
        'txt_netamt
        '
        Me.txt_netamt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_netamt.Location = New System.Drawing.Point(196, 273)
        Me.txt_netamt.Name = "txt_netamt"
        Me.txt_netamt.ReadOnly = True
        Me.txt_netamt.Size = New System.Drawing.Size(144, 21)
        Me.txt_netamt.TabIndex = 144
        Me.txt_netamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(42, 274)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(145, 15)
        Me.Label16.TabIndex = 145
        Me.Label16.Text = "TOTAL NET  AMOUNT :"
        '
        'Ssgrid_Bill
        '
        Me.Ssgrid_Bill.DataSource = Nothing
        Me.Ssgrid_Bill.Location = New System.Drawing.Point(6, 130)
        Me.Ssgrid_Bill.Name = "Ssgrid_Bill"
        Me.Ssgrid_Bill.OcxState = CType(resources.GetObject("Ssgrid_Bill.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Ssgrid_Bill.Size = New System.Drawing.Size(350, 112)
        Me.Ssgrid_Bill.TabIndex = 143
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 76)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 18)
        Me.Label8.TabIndex = 142
        Me.Label8.Text = "CASH/CREDIT :"
        '
        'Cmb_CashCredit
        '
        Me.Cmb_CashCredit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_CashCredit.Items.AddRange(New Object() {"CREDIT", "CASH"})
        Me.Cmb_CashCredit.Location = New System.Drawing.Point(134, 73)
        Me.Cmb_CashCredit.Name = "Cmb_CashCredit"
        Me.Cmb_CashCredit.Size = New System.Drawing.Size(119, 21)
        Me.Cmb_CashCredit.TabIndex = 141
        '
        'Txt_BillAmt
        '
        Me.Txt_BillAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_BillAmt.Location = New System.Drawing.Point(196, 249)
        Me.Txt_BillAmt.Name = "Txt_BillAmt"
        Me.Txt_BillAmt.ReadOnly = True
        Me.Txt_BillAmt.Size = New System.Drawing.Size(144, 21)
        Me.Txt_BillAmt.TabIndex = 139
        Me.Txt_BillAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(43, 250)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(147, 15)
        Me.Label7.TabIndex = 140
        Me.Label7.Text = "TOTAL BILL AMOUNT :"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label13.Location = New System.Drawing.Point(572, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(24, 16)
        Me.Label13.TabIndex = 134
        Me.Label13.Text = "[F2]"
        '
        'txt_customerName
        '
        Me.txt_customerName.Location = New System.Drawing.Point(479, 71)
        Me.txt_customerName.Name = "txt_customerName"
        Me.txt_customerName.ReadOnly = True
        Me.txt_customerName.Size = New System.Drawing.Size(157, 20)
        Me.txt_customerName.TabIndex = 132
        '
        'Cmd_VoucherNoHelp
        '
        Me.Cmd_VoucherNoHelp.Image = CType(resources.GetObject("Cmd_VoucherNoHelp.Image"), System.Drawing.Image)
        Me.Cmd_VoucherNoHelp.Location = New System.Drawing.Point(613, 13)
        Me.Cmd_VoucherNoHelp.Name = "Cmd_VoucherNoHelp"
        Me.Cmd_VoucherNoHelp.Size = New System.Drawing.Size(23, 21)
        Me.Cmd_VoucherNoHelp.TabIndex = 131
        Me.Cmd_VoucherNoHelp.Visible = False
        '
        'Txt_VoucherPrefix
        '
        Me.Txt_VoucherPrefix.Enabled = False
        Me.Txt_VoucherPrefix.Location = New System.Drawing.Point(332, 16)
        Me.Txt_VoucherPrefix.Name = "Txt_VoucherPrefix"
        Me.Txt_VoucherPrefix.Size = New System.Drawing.Size(56, 20)
        Me.Txt_VoucherPrefix.TabIndex = 130
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(10, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(117, 18)
        Me.Label14.TabIndex = 129
        Me.Label14.Text = "VOUCHER TYPE :"
        '
        'Cmb_VoucherType
        '
        Me.Cmb_VoucherType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_VoucherType.Location = New System.Drawing.Point(134, 16)
        Me.Cmb_VoucherType.Name = "Cmb_VoucherType"
        Me.Cmb_VoucherType.Size = New System.Drawing.Size(192, 21)
        Me.Cmb_VoucherType.TabIndex = 1
        '
        'Txt_Naration
        '
        Me.Txt_Naration.HideSelection = False
        Me.Txt_Naration.Location = New System.Drawing.Point(197, 296)
        Me.Txt_Naration.Name = "Txt_Naration"
        Me.Txt_Naration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Txt_Naration.Size = New System.Drawing.Size(382, 20)
        Me.Txt_Naration.TabIndex = 6
        '
        'Txt_VoucherNo
        '
        Me.Txt_VoucherNo.Location = New System.Drawing.Point(411, 49)
        Me.Txt_VoucherNo.Name = "Txt_VoucherNo"
        Me.Txt_VoucherNo.Size = New System.Drawing.Size(116, 20)
        Me.Txt_VoucherNo.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(312, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 18)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "VOUCHER NO :"
        '
        'Dtp_VoucherDate
        '
        Me.Dtp_VoucherDate.CustomFormat = "dd-MMM-yyyy"
        Me.Dtp_VoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtp_VoucherDate.Location = New System.Drawing.Point(134, 48)
        Me.Dtp_VoucherDate.Name = "Dtp_VoucherDate"
        Me.Dtp_VoucherDate.Size = New System.Drawing.Size(108, 20)
        Me.Dtp_VoucherDate.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 18)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "VOUCHER DATE :"
        '
        'Txt_CustomerCode
        '
        Me.Txt_CustomerCode.Location = New System.Drawing.Point(368, 73)
        Me.Txt_CustomerCode.Name = "Txt_CustomerCode"
        Me.Txt_CustomerCode.Size = New System.Drawing.Size(77, 20)
        Me.Txt_CustomerCode.TabIndex = 4
        '
        'Lbl_Supplier
        '
        Me.Lbl_Supplier.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Supplier.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Supplier.Location = New System.Drawing.Point(260, 74)
        Me.Lbl_Supplier.Name = "Lbl_Supplier"
        Me.Lbl_Supplier.Size = New System.Drawing.Size(118, 18)
        Me.Lbl_Supplier.TabIndex = 101
        Me.Lbl_Supplier.Text = "SUPPLIER CODE :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(42, 298)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "NARATION :"
        '
        'Cmd_CustomerCodeHelp
        '
        Me.Cmd_CustomerCodeHelp.Image = CType(resources.GetObject("Cmd_CustomerCodeHelp.Image"), System.Drawing.Image)
        Me.Cmd_CustomerCodeHelp.Location = New System.Drawing.Point(613, 85)
        Me.Cmd_CustomerCodeHelp.Name = "Cmd_CustomerCodeHelp"
        Me.Cmd_CustomerCodeHelp.Size = New System.Drawing.Size(23, 21)
        Me.Cmd_CustomerCodeHelp.TabIndex = 109
        Me.Cmd_CustomerCodeHelp.Visible = False
        '
        'lbl_void
        '
        Me.lbl_void.AutoSize = True
        Me.lbl_void.BackColor = System.Drawing.Color.Transparent
        Me.lbl_void.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_void.ForeColor = System.Drawing.Color.Red
        Me.lbl_void.Location = New System.Drawing.Point(180, 583)
        Me.lbl_void.Name = "lbl_void"
        Me.lbl_void.Size = New System.Drawing.Size(146, 22)
        Me.lbl_void.TabIndex = 139
        Me.lbl_void.Text = "Deleted Voucher"
        Me.lbl_void.Visible = False
        '
        'SSGrid_ReceiptsPayments
        '
        Me.SSGrid_ReceiptsPayments.DataSource = Nothing
        Me.SSGrid_ReceiptsPayments.Location = New System.Drawing.Point(186, 421)
        Me.SSGrid_ReceiptsPayments.Name = "SSGrid_ReceiptsPayments"
        Me.SSGrid_ReceiptsPayments.OcxState = CType(resources.GetObject("SSGrid_ReceiptsPayments.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGrid_ReceiptsPayments.Size = New System.Drawing.Size(630, 156)
        Me.SSGrid_ReceiptsPayments.TabIndex = 133
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.cmdcrystal)
        Me.frmbut.Controls.Add(Me.CmdAdd)
        Me.frmbut.Controls.Add(Me.CmdDelete)
        Me.frmbut.Controls.Add(Me.CmdView)
        Me.frmbut.Controls.Add(Me.cmdexit)
        Me.frmbut.Controls.Add(Me.CmdClear)
        Me.frmbut.Controls.Add(Me.BtnPrint)
        Me.frmbut.Location = New System.Drawing.Point(152, 608)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(664, 40)
        Me.frmbut.TabIndex = 134
        Me.frmbut.TabStop = False
        Me.frmbut.Visible = False
        '
        'cmdcrystal
        '
        Me.cmdcrystal.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.cmdcrystal.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdcrystal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcrystal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdcrystal.Location = New System.Drawing.Point(480, 16)
        Me.cmdcrystal.Name = "cmdcrystal"
        Me.cmdcrystal.Size = New System.Drawing.Size(79, 32)
        Me.cmdcrystal.TabIndex = 7
        Me.cmdcrystal.Text = "Crystal [F10]"
        Me.cmdcrystal.UseVisualStyleBackColor = False
        '
        'CmdAdd
        '
        Me.CmdAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.CmdAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdAdd.Location = New System.Drawing.Point(104, 16)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(79, 32)
        Me.CmdAdd.TabIndex = 0
        Me.CmdAdd.Text = "Add [F7]"
        Me.CmdAdd.UseVisualStyleBackColor = False
        '
        'CmdDelete
        '
        Me.CmdDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.CmdDelete.Enabled = False
        Me.CmdDelete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDelete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdDelete.Location = New System.Drawing.Point(200, 16)
        Me.CmdDelete.Name = "CmdDelete"
        Me.CmdDelete.Size = New System.Drawing.Size(77, 32)
        Me.CmdDelete.TabIndex = 2
        Me.CmdDelete.Text = "Delete[F8]"
        Me.CmdDelete.UseVisualStyleBackColor = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.CmdView.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdView.Location = New System.Drawing.Point(296, 16)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(79, 32)
        Me.CmdView.TabIndex = 3
        Me.CmdView.Text = "View[F9]"
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdexit.Location = New System.Drawing.Point(568, 16)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(78, 32)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.CmdClear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdClear.Location = New System.Drawing.Point(16, 16)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(74, 32)
        Me.CmdClear.TabIndex = 1
        Me.CmdClear.Text = "Clear [F6]"
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(154, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.BtnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnPrint.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPrint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BtnPrint.Location = New System.Drawing.Point(392, 16)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(79, 32)
        Me.BtnPrint.TabIndex = 3
        Me.BtnPrint.Text = "Print [F12]"
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'Lbl_LastVoucher
        '
        Me.Lbl_LastVoucher.AutoSize = True
        Me.Lbl_LastVoucher.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_LastVoucher.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_LastVoucher.ForeColor = System.Drawing.Color.Blue
        Me.Lbl_LastVoucher.Location = New System.Drawing.Point(332, 583)
        Me.Lbl_LastVoucher.Name = "Lbl_LastVoucher"
        Me.Lbl_LastVoucher.Size = New System.Drawing.Size(149, 22)
        Me.Lbl_LastVoucher.TabIndex = 138
        Me.Lbl_LastVoucher.Text = "Last Voucher No"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Txt_TotDed)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Txt_EsiSec)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Txt_TdsSec)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Txt_EsiAmt)
        Me.GroupBox1.Controls.Add(Me.Txt_WorksSec)
        Me.GroupBox1.Controls.Add(Me.Txt_PfSec)
        Me.GroupBox1.Controls.Add(Me.Txt_PurSec)
        Me.GroupBox1.Controls.Add(Me.Txt_TdsPer)
        Me.GroupBox1.Controls.Add(Me.Txt_EsiPer)
        Me.GroupBox1.Controls.Add(Me.Txt_WorksPer)
        Me.GroupBox1.Controls.Add(Me.Txt_PfPer)
        Me.GroupBox1.Controls.Add(Me.Txt_PurPer)
        Me.GroupBox1.Controls.Add(Me.Txt_TdsAmt)
        Me.GroupBox1.Controls.Add(Me.Txt_WorksAmt)
        Me.GroupBox1.Controls.Add(Me.Txt_PfAmt)
        Me.GroupBox1.Controls.Add(Me.Txt_PurAmt)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(548, 227)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(268, 106)
        Me.GroupBox1.TabIndex = 140
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Deductions"
        Me.GroupBox1.Visible = False
        '
        'Txt_TotDed
        '
        Me.Txt_TotDed.Location = New System.Drawing.Point(192, 192)
        Me.Txt_TotDed.Name = "Txt_TotDed"
        Me.Txt_TotDed.ReadOnly = True
        Me.Txt_TotDed.Size = New System.Drawing.Size(144, 22)
        Me.Txt_TotDed.TabIndex = 154
        Me.Txt_TotDed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Txt_TotDed.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(49, 194)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(133, 15)
        Me.Label12.TabIndex = 155
        Me.Label12.Text = "TOTAL DEDUCTION :"
        Me.Label12.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(213, 24)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(35, 15)
        Me.Label24.TabIndex = 153
        Me.Label24.Text = "AMT"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(157, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(22, 15)
        Me.Label23.TabIndex = 152
        Me.Label23.Text = "%"
        '
        'Txt_EsiSec
        '
        Me.Txt_EsiSec.Location = New System.Drawing.Point(60, 77)
        Me.Txt_EsiSec.Name = "Txt_EsiSec"
        Me.Txt_EsiSec.ReadOnly = True
        Me.Txt_EsiSec.Size = New System.Drawing.Size(73, 22)
        Me.Txt_EsiSec.TabIndex = 93
        Me.Txt_EsiSec.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "ESI :"
        Me.Label1.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 15)
        Me.Label5.TabIndex = 90
        Me.Label5.Text = "PURCHASE :"
        Me.Label5.Visible = False
        '
        'Txt_TdsSec
        '
        Me.Txt_TdsSec.Location = New System.Drawing.Point(60, 48)
        Me.Txt_TdsSec.Name = "Txt_TdsSec"
        Me.Txt_TdsSec.ReadOnly = True
        Me.Txt_TdsSec.Size = New System.Drawing.Size(73, 22)
        Me.Txt_TdsSec.TabIndex = 87
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 83
        Me.Label6.Text = "TDS :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 105)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 15)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "WORKS :"
        Me.Label9.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 135)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 15)
        Me.Label11.TabIndex = 85
        Me.Label11.Text = "PF :"
        Me.Label11.Visible = False
        '
        'Txt_EsiAmt
        '
        Me.Txt_EsiAmt.Location = New System.Drawing.Point(203, 77)
        Me.Txt_EsiAmt.Name = "Txt_EsiAmt"
        Me.Txt_EsiAmt.ReadOnly = True
        Me.Txt_EsiAmt.Size = New System.Drawing.Size(56, 22)
        Me.Txt_EsiAmt.TabIndex = 98
        Me.Txt_EsiAmt.Visible = False
        '
        'Txt_WorksSec
        '
        Me.Txt_WorksSec.Location = New System.Drawing.Point(96, 105)
        Me.Txt_WorksSec.Name = "Txt_WorksSec"
        Me.Txt_WorksSec.ReadOnly = True
        Me.Txt_WorksSec.Size = New System.Drawing.Size(104, 22)
        Me.Txt_WorksSec.TabIndex = 94
        Me.Txt_WorksSec.Visible = False
        '
        'Txt_PfSec
        '
        Me.Txt_PfSec.Location = New System.Drawing.Point(96, 135)
        Me.Txt_PfSec.Name = "Txt_PfSec"
        Me.Txt_PfSec.ReadOnly = True
        Me.Txt_PfSec.Size = New System.Drawing.Size(104, 22)
        Me.Txt_PfSec.TabIndex = 95
        Me.Txt_PfSec.Visible = False
        '
        'Txt_PurSec
        '
        Me.Txt_PurSec.Location = New System.Drawing.Point(96, 160)
        Me.Txt_PurSec.Name = "Txt_PurSec"
        Me.Txt_PurSec.ReadOnly = True
        Me.Txt_PurSec.Size = New System.Drawing.Size(104, 22)
        Me.Txt_PurSec.TabIndex = 96
        Me.Txt_PurSec.Visible = False
        '
        'Txt_TdsPer
        '
        Me.Txt_TdsPer.Location = New System.Drawing.Point(139, 48)
        Me.Txt_TdsPer.Name = "Txt_TdsPer"
        Me.Txt_TdsPer.ReadOnly = True
        Me.Txt_TdsPer.Size = New System.Drawing.Size(56, 22)
        Me.Txt_TdsPer.TabIndex = 97
        '
        'Txt_EsiPer
        '
        Me.Txt_EsiPer.Location = New System.Drawing.Point(139, 77)
        Me.Txt_EsiPer.Name = "Txt_EsiPer"
        Me.Txt_EsiPer.ReadOnly = True
        Me.Txt_EsiPer.Size = New System.Drawing.Size(56, 22)
        Me.Txt_EsiPer.TabIndex = 98
        Me.Txt_EsiPer.Visible = False
        '
        'Txt_WorksPer
        '
        Me.Txt_WorksPer.Location = New System.Drawing.Point(216, 105)
        Me.Txt_WorksPer.Name = "Txt_WorksPer"
        Me.Txt_WorksPer.ReadOnly = True
        Me.Txt_WorksPer.Size = New System.Drawing.Size(56, 22)
        Me.Txt_WorksPer.TabIndex = 99
        Me.Txt_WorksPer.Visible = False
        '
        'Txt_PfPer
        '
        Me.Txt_PfPer.Location = New System.Drawing.Point(216, 135)
        Me.Txt_PfPer.Name = "Txt_PfPer"
        Me.Txt_PfPer.ReadOnly = True
        Me.Txt_PfPer.Size = New System.Drawing.Size(56, 22)
        Me.Txt_PfPer.TabIndex = 100
        Me.Txt_PfPer.Visible = False
        '
        'Txt_PurPer
        '
        Me.Txt_PurPer.Location = New System.Drawing.Point(216, 160)
        Me.Txt_PurPer.Name = "Txt_PurPer"
        Me.Txt_PurPer.ReadOnly = True
        Me.Txt_PurPer.Size = New System.Drawing.Size(56, 22)
        Me.Txt_PurPer.TabIndex = 101
        Me.Txt_PurPer.Visible = False
        '
        'Txt_TdsAmt
        '
        Me.Txt_TdsAmt.Location = New System.Drawing.Point(203, 48)
        Me.Txt_TdsAmt.Name = "Txt_TdsAmt"
        Me.Txt_TdsAmt.ReadOnly = True
        Me.Txt_TdsAmt.Size = New System.Drawing.Size(56, 22)
        Me.Txt_TdsAmt.TabIndex = 151
        '
        'Txt_WorksAmt
        '
        Me.Txt_WorksAmt.Location = New System.Drawing.Point(280, 105)
        Me.Txt_WorksAmt.Name = "Txt_WorksAmt"
        Me.Txt_WorksAmt.ReadOnly = True
        Me.Txt_WorksAmt.Size = New System.Drawing.Size(56, 22)
        Me.Txt_WorksAmt.TabIndex = 151
        Me.Txt_WorksAmt.Visible = False
        '
        'Txt_PfAmt
        '
        Me.Txt_PfAmt.Location = New System.Drawing.Point(280, 135)
        Me.Txt_PfAmt.Name = "Txt_PfAmt"
        Me.Txt_PfAmt.ReadOnly = True
        Me.Txt_PfAmt.Size = New System.Drawing.Size(56, 22)
        Me.Txt_PfAmt.TabIndex = 151
        Me.Txt_PfAmt.Visible = False
        '
        'Txt_PurAmt
        '
        Me.Txt_PurAmt.Location = New System.Drawing.Point(280, 160)
        Me.Txt_PurAmt.Name = "Txt_PurAmt"
        Me.Txt_PurAmt.ReadOnly = True
        Me.Txt_PurAmt.Size = New System.Drawing.Size(56, 22)
        Me.Txt_PurAmt.TabIndex = 151
        Me.Txt_PurAmt.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(57, 24)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 15)
        Me.Label22.TabIndex = 151
        Me.Label22.Text = "SECTION"
        '
        'LBL_COMPANYNAME
        '
        Me.LBL_COMPANYNAME.AutoSize = True
        Me.LBL_COMPANYNAME.BackColor = System.Drawing.Color.OrangeRed
        Me.LBL_COMPANYNAME.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_COMPANYNAME.Location = New System.Drawing.Point(526, 71)
        Me.LBL_COMPANYNAME.Name = "LBL_COMPANYNAME"
        Me.LBL_COMPANYNAME.Size = New System.Drawing.Size(28, 15)
        Me.LBL_COMPANYNAME.TabIndex = 165
        Me.LBL_COMPANYNAME.Text = "REC"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Exit.Location = New System.Drawing.Point(837, 468)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(140, 53)
        Me.Cmd_Exit.TabIndex = 172
        Me.Cmd_Exit.Text = "Exit [F11]"
        Me.Cmd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Exit.UseVisualStyleBackColor = True
        '
        'Cmd_Export
        '
        Me.Cmd_Export.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Export.Image = CType(resources.GetObject("Cmd_Export.Image"), System.Drawing.Image)
        Me.Cmd_Export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Export.Location = New System.Drawing.Point(837, 412)
        Me.Cmd_Export.Name = "Cmd_Export"
        Me.Cmd_Export.Size = New System.Drawing.Size(140, 53)
        Me.Cmd_Export.TabIndex = 171
        Me.Cmd_Export.Text = "Browse [F12]"
        Me.Cmd_Export.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Export.UseVisualStyleBackColor = True
        '
        'Cmd_Print
        '
        Me.Cmd_Print.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Print.Location = New System.Drawing.Point(837, 356)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(140, 53)
        Me.Cmd_Print.TabIndex = 170
        Me.Cmd_Print.Text = "Print [F10]"
        Me.Cmd_Print.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Print.UseVisualStyleBackColor = True
        '
        'Cmd_View
        '
        Me.Cmd_View.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_View.Location = New System.Drawing.Point(837, 300)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(140, 53)
        Me.Cmd_View.TabIndex = 169
        Me.Cmd_View.Text = "View [F9]"
        Me.Cmd_View.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_View.UseVisualStyleBackColor = True
        '
        'Cmd_Delete
        '
        Me.Cmd_Delete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Delete.Image = CType(resources.GetObject("Cmd_Delete.Image"), System.Drawing.Image)
        Me.Cmd_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Delete.Location = New System.Drawing.Point(836, 244)
        Me.Cmd_Delete.Name = "Cmd_Delete"
        Me.Cmd_Delete.Size = New System.Drawing.Size(140, 53)
        Me.Cmd_Delete.TabIndex = 168
        Me.Cmd_Delete.Text = "Delete [F8]"
        Me.Cmd_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Delete.UseVisualStyleBackColor = True
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(837, 132)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(140, 53)
        Me.Cmd_Clear.TabIndex = 167
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = True
        '
        'Cmd_Add
        '
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(837, 188)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(140, 53)
        Me.Cmd_Add.TabIndex = 166
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'NonProductPurchase
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(992, 654)
        Me.Controls.Add(Me.Cmd_Exit)
        Me.Controls.Add(Me.Cmd_Export)
        Me.Controls.Add(Me.Cmd_Print)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.Cmd_Delete)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.LBL_COMPANYNAME)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Txt_Total)
        Me.Controls.Add(Me.lbl_void)
        Me.Controls.Add(Me.Lbl_LastVoucher)
        Me.Controls.Add(Me.Gpr_Supplier)
        Me.Controls.Add(Me.SSGrid_ReceiptsPayments)
        Me.Controls.Add(Me.frmbut)
        Me.KeyPreview = True
        Me.Name = "NonProductPurchase"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Non Product Purchase"
        Me.Gpr_Supplier.ResumeLayout(False)
        Me.Gpr_Supplier.PerformLayout()
        CType(Me.Ssgrid_Bill, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SSGrid_ReceiptsPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmbut.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub TotalBillAmt()
        Dim Amt As Double
        Dim i As Integer
        With Ssgrid_Bill
            For i = 1 To .DataRowCnt
                .Col = 3
                .Row = i
                Amt = Amt + Val(.Text)
            Next
            Me.Txt_BillAmt.Text = Format(Amt, "0.00")
            Me.txt_netamt.Text = Format(Val(Amt) - Val(Me.Txt_TotDed.Text), "0.00")
        End With
    End Sub
    Private Sub SSGrid_ReceiptsPayments_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGrid_ReceiptsPayments.KeyDownEvent
        Dim ACHEAD, SUBLEDGER, COSTCENTER, ACHEAD1 As String
        Dim GLCODE(), SLCODE(), COSTCODE() As String
        Dim DCSTATUS As String
        Dim SUBLED As Boolean
        Dim GR As String
        Dim TOT As String
        Dim SQLSTRING As String
        Dim ACHEADARRAY(5) As String
        Dim SUBHEADARRAY(5) As String
        Dim ROW, COL As Integer
        With SSGrid_ReceiptsPayments
            If e.keyCode = Keys.Enter Then
                If .ActiveCol = 1 Then
                    .SetActiveCell(2, .ActiveRow)
                    .Col = 5
                    .Row = .ActiveRow
                    If .Text = "0.00" Or .Text = "" Then
                        .Text = "0.00"
                    End If
                    '''''''' IF COL = 2
                ElseIf .ActiveCol = 2 Then
                    .GetText(2, .ActiveRow, ACHEAD)
                    DRCR = Nothing
                    .GetText(1, .ActiveRow, DRCR)


                    If ACHEAD = "" Then
                        '.SetActiveCell(2, .ActiveRow)
                        'HERE GIVE THE POPUP MENU OF HELP
                        '----------------------------------------------SHUVENDU STARTS------------------------------------------------------------------
                        Call GlGridHelp()
                        '----------------------------------------------SHUVENDU ENDS--------------------------------------------------------------------
                        Exit Sub
                    Else
                        GLCODE = ACHEAD.Split("-->>")
                        If DRCR = "DEBIT" Then
                            SQLSTRING = "SELECT ACCODE, ACDESC FROM ACCOUNTSGLACCOUNTMASTER WHERE ACCODE = '" & Trim(GLCODE(0)) & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y' AND Category IN ('E','A','L')"
                        Else
                            SQLSTRING = "SELECT ACCODE, ACDESC FROM ACCOUNTSGLACCOUNTMASTER WHERE ACCODE = '" & Trim(GLCODE(0)) & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y' AND Category IN ('I','A','L')"
                        End If
                        Vconn.getDataSet(SQLSTRING, "MASTER1")
                        If gdataset.Tables("MASTER1").Rows.Count = 0 Then
                            If DRCR = "DEBIT" Then
                                SQLSTRING = "SELECT ACCODE, ACDESC FROM ACCOUNTSGLACCOUNTMASTER WHERE ACDESC = '" & Trim(GLCODE(0)) & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y' AND Category IN ('E','A','L')"
                            Else
                                SQLSTRING = "SELECT ACCODE, ACDESC FROM ACCOUNTSGLACCOUNTMASTER WHERE ACDESC = '" & Trim(GLCODE(0)) & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y' AND Category IN ('I','A','L')"
                            End If
                            Vconn.getDataSet(SQLSTRING, "MASTER1")
                        End If
                        If gdataset.Tables("MASTER1").Rows.Count > 0 Then
                            .Col = 2
                            .Row = .ActiveRow
                            .Text = Trim(gdataset.Tables("MASTER1").Rows(0).Item("ACCODE")) & "-->>" & Trim(gdataset.Tables("MASTER1").Rows(0).Item("ACDESC"))
                            gdataset.Tables("MASTER1").Dispose()

                            ''''''''' CHECKING WEATHER ACHEAD IS HAVING SUBLEDGER OR NOT 
                            SQLSTRING = "SELECT SLNAME FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE = '" & Trim(GLCODE(0)) & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y'"


                            Vconn.getDataSet(SQLSTRING, "MASTER1")

                            If gdataset.Tables("MASTER1").Rows.Count = 0 Then
                                SQLSTRING = "SELECT ACCODE, ACDESC FROM ACCOUNTSSUBLEDGERMASTER WHERE ACDESC = '" & Trim(GLCODE(0)) & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y' "
                                Vconn.getDataSet(SQLSTRING, "MASTER1")
                            End If

                            If gdataset.Tables("MASTER1").Rows.Count > 0 Then

                                SUBLEDGER = Nothing
                                .GetText(3, .ActiveRow, SUBLEDGER)
                                If Trim(SUBLEDGER) = "" Then
                                    .SetText(3, .ActiveRow, "")
                                    .SetText(4, .ActiveRow, "")
                                    .SetText(5, .ActiveRow, "0.00")
                                    .SetActiveCell(3, .ActiveRow)
                                    .Col = 3
                                    .Row = .ActiveRow
                                    .Lock = False
                                    SUBLED = True
                                    gdataset.Tables("MASTER1").Dispose()
                                    Exit Sub
                                Else
                                    'CHECKING WEATHER A VALID SLCODE OR NOT
                                    SUBHEADARRAY = SUBLEDGER.Split("-->>")
                                    ACHEAD = Nothing
                                    .GetText(2, .ActiveRow, ACHEAD)
                                    ACHEADARRAY = ACHEAD.Split("-->>")

                                    SQLSTRING = "SELECT SLCODE,SLDESC FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE = '" & Trim(ACHEADARRAY(0)) & "' AND SLCODE = '" & SUBHEADARRAY(0) & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
                                    Vconn.getDataSet(SQLSTRING, "MASTER1")
                                    If gdataset.Tables("MASTER1").Rows.Count = 0 Then
                                        .SetText(3, .ActiveRow, "")
                                        .SetText(4, .ActiveRow, "")
                                        .SetText(5, .ActiveRow, "0.00")
                                        .Col = 3
                                        .Row = .ActiveRow
                                        .Col2 = 3
                                        .Row2 = .ActiveRow
                                        .Lock = True
                                        SUBLED = False
                                        gdataset.Tables("MASTER1").Dispose()
                                        Exit Sub
                                    Else
                                        .SetActiveCell(3, .ActiveRow)
                                        .Col = 3
                                        .Row = .ActiveRow
                                        .Lock = False
                                        SUBLED = True
                                        gdataset.Tables("MASTER1").Dispose()
                                        Exit Sub
                                    End If
                                End If
                                ''''''' CHECKING WEATHER ACHEAD IS HAVING COSTCENTER CODE OR NOT
                            Else
                                .SetText(3, .ActiveRow, "")
                                .SetText(4, .ActiveRow, "")
                                .Col = 5
                                .Row = .ActiveRow
                                If Val(.Text) > 0 Then
                                Else
                                    .SetText(5, .ActiveRow, "0.00")
                                End If
                                .Col = 3
                                .Row = .ActiveRow
                                .Col2 = 3
                                .Row2 = .ActiveRow
                                .Lock = True
                                SUBLED = False
                                gdataset.Tables("MASTER1").Dispose()
                                GR = COSTCENTERVALIDATE(GR, GLCODE(0))
                                If GR <> Nothing Then
                                    SQLSTRING = "SELECT COSTCENTERCODE,COSTCENTERDESC FROM ACCOUNTSCOSTCENTERMASTER WHERE PRIMARYGROUPCODE IN (" & GR & ") AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
                                    Vconn.getDataSet(SQLSTRING, "MASTER1")
                                    If gdataset.Tables("MASTER1").Rows.Count > 0 Then
                                        .SetActiveCell(4, .ActiveRow)
                                        .SetText(4, .ActiveRow, "")
                                        .SetText(5, .ActiveRow, "0.00")
                                        .Col = 4
                                        .Col2 = 4
                                        .Row = .ActiveRow
                                        .Row2 = .ActiveRow
                                        .Lock = False
                                        'END
                                        gdataset.Tables("MASTER1").Dispose()
                                    Else
                                        .SetActiveCell(5, .ActiveRow)
                                        .SetText(4, .ActiveRow, "")
                                        .SetText(5, .ActiveRow, "0.00")
                                        .Col = 4
                                        .Row = .ActiveRow
                                        .Lock = True
                                        gdataset.Tables("MASTER1").Dispose()
                                    End If
                                Else
                                    .SetActiveCell(5, .ActiveRow)
                                    .Col = 5
                                    .Row = .ActiveRow
                                    If Val(.Text) > 0 Then
                                    Else
                                        .SetText(5, .ActiveRow, "0.00")
                                    End If
                                    .Row = .ActiveRow
                                    .Col = 4
                                    .Lock = False
                                End If

                            End If
                        Else
                            '-----------------------------------------SHUVENDU STARTS----------------------------------------------------------
                            ''.SetActiveCell(2, .ActiveRow)
                            ''.SetText(2, .ActiveRow, "")
                            ''.SetText(3, .ActiveRow, "")
                            ''.SetText(4, .ActiveRow, "")
                            ''.SetText(5, .ActiveRow, "0.00")
                            Call GlGridHelp()
                            '-----------------------------------------SHUVENDU ENDS----------------------------------------------------------
                        End If
                    End If

                    '''''''''IF COL = 3 AND LOCK STATUS IS FALSE
                ElseIf .ActiveCol = 3 Then
                    .Row = .ActiveRow
                    If .Lock = True Then
                        Exit Sub
                    Else
                        .Row = .ActiveRow
                        .Col = 2
                        If .Text = "" Then
                            .SetActiveCell(2, .ActiveRow)
                            .SetText(3, .ActiveRow, "")
                            .SetText(4, .ActiveRow, "")
                            .SetText(5, .ActiveRow, "0.00")
                        End If
                        SUBLEDGER = Nothing
                        .GetText(3, .ActiveRow, SUBLEDGER)
                        If SUBLEDGER = "" Then
                            .SetActiveCell(3, .ActiveRow)
                            'HERE GIVE THE HELP POPUP INCASE IT IS BLANK
                            '-------------------------------SHUVENDU STARTS-----------------------------------------
                            Call SubLedHelp()
                            '-------------------------------SHUVENDU   ENDS-----------------------------------------
                            Exit Sub
                        Else
                            .GetText(2, .ActiveRow, ACHEAD)
                            ACHEADARRAY = ACHEAD.Split("-->>")
                            'MsgBox(ACHEADARRAY(0))
                            SUBHEADARRAY = Nothing
                            'IF EXISTS EARLIER
                            SUBHEADARRAY = SUBLEDGER.Split("-->>")
                            If SUBHEADARRAY Is Nothing = False Then
                                SUBLEDGER = SUBHEADARRAY(0)
                            End If
                            'IF EXISTS EARLIER ENDS
                            SQLSTRING = "SELECT SLCODE,SLDESC FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE = '" & Trim(ACHEADARRAY(0)) & "' AND SLCODE = '" & SUBLEDGER & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
                            Vconn.getDataSet(SQLSTRING, "MASTER1")

                            If gdataset.Tables("MASTER1").Rows.Count = 0 Then
                                SQLSTRING = "SELECT SLCODE,SLDESC FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE = '" & Trim(ACHEADARRAY(0)) & "' AND SLDESC = '" & SUBLEDGER & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
                                Vconn.getDataSet(SQLSTRING, "MASTER1")
                            End If

                            If gdataset.Tables("MASTER1").Rows.Count > 0 Then
                                .Col = 3
                                .Row = .ActiveRow
                                .Text = Trim(gdataset.Tables("MASTER1").Rows(0).Item("SLCODE")) & "-->>" & Trim(gdataset.Tables("MASTER1").Rows(0).Item("SLDESC"))
                                gdataset.Tables("MASTER1").Dispose()

                                GR = COSTCENTERVALIDATE(GR, ACHEADARRAY(0))
                                ''''''' CHECKING WEATHER ACHEAD IS HAVING COSTCENTER CODE OR NOT
                                If GR <> Nothing Then
                                    SQLSTRING = "SELECT COSTCENTERCODE,COSTCENTERDESC FROM ACCOUNTSCOSTCENTERMASTER WHERE PRIMARYGROUPCODE IN (" & GR & ") AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
                                    Vconn.getDataSet(SQLSTRING, "MASTER1")
                                    If gdataset.Tables("MASTER1").Rows.Count > 0 Then
                                        .Col = 4
                                        .Col2 = 4
                                        .Row = .ActiveRow
                                        .Row2 = .ActiveRow
                                        .Lock = False
                                        .SetActiveCell(4, .ActiveRow)
                                        .SetText(4, .ActiveRow, "")
                                        .SetText(5, .ActiveRow, "0.00")

                                        gdataset.Tables("MASTER1").Dispose()
                                    Else
                                        .Col = 4
                                        .Row = .ActiveRow
                                        .Lock = True
                                        .SetActiveCell(5, .ActiveRow)
                                        .SetText(4, .ActiveRow, "")
                                        .SetText(5, .ActiveRow, "0.00")
                                        gdataset.Tables("MASTER1").Dispose()
                                    End If
                                Else
                                    .Row = .ActiveRow
                                    .Col = 4
                                    .Lock = True
                                    .SetActiveCell(5, .ActiveRow)
                                    .SetText(4, .ActiveRow, "")
                                    .Row = .ActiveRow
                                    .Col = 5
                                    If Val(.Text) > 0 Then
                                    Else
                                        .SetText(5, .ActiveRow, "0.00")
                                    End If
                                End If
                            Else
                                '--------------------------------------SHUVENDU STARTS------------------------------------------
                                ''.SetActiveCell(3, .ActiveRow)
                                ''.SetText(3, .ActiveRow, "")
                                ''.SetText(4, .ActiveRow, "")
                                ''.SetText(5, .ActiveRow, "0.00")
                                Call SubLedHelp()
                                '----------------------------------------SHUVENDU ENDS-------------------------------------------
                            End If
                        End If
                    End If

                    '''''''''IF COL = 4 AND LOCK STATUS IS FALSE
                ElseIf .ActiveCol = 4 Then
                    .Row = .ActiveRow
                    If .Lock = True Then
                        'MsgBox("IT LOCK")
                        Exit Sub
                    Else
                        .Row = .ActiveRow
                        .Col = 2
                        If .Text = "" Then
                            .SetActiveCell(2, .ActiveRow)
                            .SetText(3, .ActiveRow, "")
                            .SetText(4, .ActiveRow, "")
                            .SetText(5, .ActiveRow, "0.00")
                            Exit Sub
                        End If
                        ACHEAD = Nothing
                        COSTCENTER = Nothing
                        .GetText(2, .ActiveRow, ACHEAD)
                        .GetText(4, .ActiveRow, COSTCENTER)
                        ACHEADARRAY = ACHEAD.Split("-->>")
                        GR = COSTCENTERVALIDATE(GR, ACHEADARRAY(0))
                        ''''''' CHECKING WEATHER ACHEAD IS HAVING COSTCENTER CODE OR NOT
                        If GR <> Nothing Then

                            SQLSTRING = "SELECT COSTCENTERCODE,COSTCENTERDESC FROM ACCOUNTSCOSTCENTERMASTER WHERE PRIMARYGROUPCODE IN (" & GR & ") AND COSTCENTERCODE = '" & COSTCENTER & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
                            Vconn.getDataSet(SQLSTRING, "MASTER1")
                            If gdataset.Tables("MASTER1").Rows.Count > 0 Then
                                .Col = 4
                                .Row = .ActiveRow
                                .Text = Trim(gdataset.Tables("MASTER1").Rows(0).Item("COSTCENTERCODE")) & "-->>" & Trim(gdataset.Tables("MASTER1").Rows(0).Item("COSTCENTERDESC"))
                                .SetActiveCell(5, .ActiveRow)
                                gdataset.Tables("MASTER1").Dispose()
                            Else
                                .SetActiveCell(4, .ActiveRow)
                                .SetText(4, .ActiveRow, "")
                                .SetText(5, .ActiveRow, "0.00")
                            End If
                        Else
                            .SetActiveCell(4, .ActiveRow)
                            .SetText(4, .ActiveRow, "")
                            .SetText(5, .ActiveRow, "0.00")
                        End If
                    End If
                    '''''''''IF COL = 5
                ElseIf .ActiveCol = 5 Then
                    TOT = Nothing
                    .Col = 5
                    .Row = .ActiveRow
                    TOT = .Text
                    If Trim(TOT) = "0.00" Then
                        .GetText(2, .ActiveRow, ACHEAD)
                        If ACHEAD <> "" Then
                            .SetActiveCell(5, .ActiveRow)
                            Exit Sub
                        Else
                            Exit Sub
                        End If
                    Else
                        total = 0
                        For ROW = 1 To .DataRowCnt
                            TOT = Nothing
                            .Row = ROW
                            .Col = 5
                            TOT = Trim(.Text)
                            '.GetText(5, ROW, TOT)
                            If TOT Is Nothing = True Then
                                TOT = 0
                            ElseIf Val(TOT) = 0 Then
                                TOT = 0
                            End If
                            total = total + CInt(TOT)
                        Next
                        Txt_Total.Text = Format(total, "0.00")
                        .SetActiveCell(2, .ActiveRow + 1)
                        .Col = 1
                        .Row = .ActiveRow
                        .GetText(1, 1, DCSTATUS)
                        .Col = 1
                        .Row = .ActiveRow
                        .TypeComboBoxList = DCSTATUS
                        .TypeComboBoxCurSel = 0
                        .Lock = True
                        '.Col = 5
                        '.Row = .ActiveRow
                        '.Text = "0.00"

                        .Row = .ActiveRow
                        .Col = 2
                        .Lock = False

                        .Row = .ActiveRow + 1
                        .Col = 5
                        .Lock = False
                    End If
                End If

            ElseIf e.keyCode = Keys.F4 Then
                If .ActiveCol = 2 Then
                    Search = Nothing
                    .GetText(2, .ActiveRow, Search)
                    Dim vform As New ListOperattion1
                    gSQLString = "SELECT ACCODE AS GLCODE,ACDESC AS GLDESCRIPTION  FROM ACCOUNTSGLACCOUNTMASTER"
                    M_WhereCondition = " WHERE  ISNULL(FREEZEFLAG,'N') <> 'Y'"
                    vform.Field = "ACDESC,ACCODE"
                    'vform.keyfield = "ACDESC"
                    vform.vFormatstring = "  GL CODE             |                GL DESCRIPTION           "
                    vform.vCaption = "GENERAL LEDGER HEAD HELP"
                    vform.KeyPos = 0
                    vform.KeyPos1 = 1
                    vform.ShowDialog(Me)
                    If Trim(vform.keyfield & "") <> "" Then
                        .SetText(.ActiveCol, .ActiveRow, Trim(vform.keyfield & "") & "-->>" & Trim(vform.keyfield1 & ""))
                        ACHEAD = Trim(vform.keyfield & "")
                        ''''''''' CHECKING WEATHER ACHEAD IS HAVING SUBLEDGER OR NOT 
                        SQLSTRING = "SELECT SLNAME FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE = '" & Trim(ACHEAD) & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
                        Vconn.getDataSet(SQLSTRING, "MASTER1")
                        If gdataset.Tables("MASTER1").Rows.Count > 0 Then
                            .SetText(3, .ActiveRow, "")
                            .SetText(4, .ActiveRow, "")
                            .SetText(5, .ActiveRow, "0.00")
                            .SetActiveCell(3, .ActiveRow)
                            .Row = .ActiveRow
                            .Col = 3
                            .Lock = False
                            gdataset.Tables("MASTER1").Dispose()
                        Else
                            .SetActiveCell(3, .ActiveRow)
                            .SetText(3, .ActiveRow, "")
                            .SetText(4, .ActiveRow, "")
                            .SetText(5, .ActiveRow, "0.00")
                            .Row = .ActiveRow
                            .Col = 3
                            .Lock = True
                            gdataset.Tables("MASTER1").Dispose()
                            GR = COSTCENTERVALIDATE(GR, ACHEAD)

                            ''''''' CHECKING WEATHER ACHEAD IS HAVING COSTCENTER CODE OR NOT
                            If GR <> Nothing Then
                                SQLSTRING = "SELECT COSTCENTERCODE,COSTCENTERDESC FROM ACCOUNTSCOSTCENTERMASTER WHERE PRIMARYGROUPCODE IN (" & GR & ") AND  ISNULL(FREEZEFLAG,'N') <> 'Y'"
                                Vconn.getDataSet(SQLSTRING, "MASTER1")
                                If gdataset.Tables("MASTER1").Rows.Count > 0 Then
                                    .SetActiveCell(4, .ActiveRow)
                                    .SetText(4, .ActiveRow, "")
                                    .SetText(5, .ActiveRow, "0.00")
                                    .Row = .ActiveRow
                                    .Col = 4
                                    .Lock = False
                                    gdataset.Tables("MASTER1").Dispose()
                                Else
                                    .SetActiveCell(5, .ActiveRow)
                                    .SetText(4, .ActiveRow, "")
                                    .SetText(5, .ActiveRow, "0.00")
                                    .Row = .ActiveRow
                                    .Col = 4
                                    .Lock = True
                                    gdataset.Tables("MASTER1").Dispose()
                                End If
                            Else
                                .SetActiveCell(5, .ActiveRow)
                                .SetText(5, .ActiveRow, "0.00")
                                .Row = .ActiveRow
                                .Col = 4
                                .Lock = True
                            End If

                        End If
                    Else
                        .SetActiveCell(.ActiveCol, .ActiveRow)
                        .SetText(.ActiveCol, .ActiveRow, "")
                    End If
                    vform.Close()
                    vform = Nothing
                    '  ElseIf .ActiveCol = 3 And .Lock = False Then
                ElseIf .ActiveCol = 3 Then
                    .Col = 3
                    .Row = .ActiveRow
                    If .Lock = True Then
                        ' MsgBox("IT LOCK")
                        Exit Sub
                    Else

                        .GetText(2, .ActiveRow, ACHEAD)
                        ACHEADARRAY = ACHEAD.Split("-->>")
                        'MsgBox(ACHEADARRAY(0))
                        'SQLSTRING = "SELECT SLCODE,SLDESC FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE = '" & Trim(ACHEADARRAY(0)) & "' AND SLCODE = '" & SUBLEDGER & "'"
                        Dim vform As New ListOperattion1
                        gSQLString = "SELECT SLCODE,SLDESC FROM accountssubledgermaster"
                        M_WhereCondition = " WHERE ACCODE = '" & Trim(ACHEADARRAY(0)) & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
                        vform.Field = "SLCODE,SLDESC"
                        'vform.Field = "SLDESC"
                        vform.vFormatstring = "           SL CODE          |                SL DESCRIPTION              "
                        vform.vCaption = "SUB LEDGER CODE HELP"
                        vform.KeyPos = 0
                        vform.KeyPos1 = 1
                        vform.ShowDialog(Me)
                        If Trim(vform.keyfield & "") <> "" Then
                            .SetText(.ActiveCol, .ActiveRow, Trim(vform.keyfield & "") & "-->>" & Trim(vform.keyfield1 & ""))

                            GR = COSTCENTERVALIDATE(GR, ACHEADARRAY(0))
                            ''''''' CHECKING WEATHER ACHEAD IS HAVING COSTCENTER CODE OR NOT
                            If GR <> Nothing Then
                                SQLSTRING = "SELECT COSTCENTERCODE,COSTCENTERDESC FROM ACCOUNTSCOSTCENTERMASTER WHERE PRIMARYGROUPCODE IN (" & GR & ")  AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
                                Vconn.getDataSet(SQLSTRING, "MASTER1")
                                If gdataset.Tables("MASTER1").Rows.Count > 0 Then
                                    .Row = .ActiveRow
                                    .Col = 4
                                    .Lock = False
                                    .SetActiveCell(4, .ActiveRow)
                                    .SetText(4, .ActiveRow, "")
                                    .SetText(5, .ActiveRow, "0.00")
                                    gdataset.Tables("MASTER1").Dispose()
                                Else
                                    .Row = .ActiveRow
                                    .Col = 4
                                    .Lock = True
                                    .SetActiveCell(5, .ActiveRow)
                                    .SetText(4, .ActiveRow, "")
                                    .SetText(5, .ActiveRow, "0.00")
                                    gdataset.Tables("MASTER1").Dispose()
                                End If
                            Else
                                .Row = .ActiveRow
                                .Col = 4
                                .Lock = True
                                .SetActiveCell(5, .ActiveRow)
                                .SetText(5, .ActiveRow, "0.00")
                            End If
                        End If
                        vform.Close()
                        vform = Nothing
                    End If

                ElseIf .ActiveCol = 4 Then
                    .Col = 4
                    .Row = .ActiveRow
                    If .Lock = True Then
                        ' MsgBox("IT LOCK")
                        Exit Sub
                    Else
                        ACHEAD = Nothing
                        COSTCENTER = Nothing
                        .GetText(2, .ActiveRow, ACHEAD)
                        .GetText(4, .ActiveRow, COSTCENTER)
                        ACHEADARRAY = ACHEAD.Split("-->>")
                        GR = COSTCENTERVALIDATE(GR, ACHEADARRAY(0))
                        ''''''' CHECKING WEATHER ACHEAD IS HAVING COSTCENTER CODE OR NOT
                        If GR <> Nothing Then

                            'SQLSTRING = "SELECT COSTCENTERCODE,COSTCENTERDESC FROM ACCOUNTSCOSTCENTERMASTER WHERE PRIMARYGROUPCODE IN (" & GR & ") AND COSTCENTERCODE = '" & COSTCENTER & "'"
                            'VCONN.getDataSet(SQLSTRING, "MASTER1")
                            Dim vform As New ListOperattion1
                            gSQLString = "SELECT COSTCENTERCODE,COSTCENTERDESC FROM ACCOUNTSCOSTCENTERMASTER"
                            M_WhereCondition = " WHERE PRIMARYGROUPCODE IN (" & GR & ")AND ISNULL(FREEZEFLAG,'N') <> 'Y' "
                            vform.Field = "COSTCENTERCODE"
                            vform.vFormatstring = "  COSTCENTERCODE|COSTCENTERDESC    "
                            vform.vCaption = "COST CENTER HELP"
                            vform.KeyPos = 0
                            vform.KeyPos1 = 1
                            vform.ShowDialog(Me)
                            If Trim(vform.keyfield & "") <> "" Then
                                .SetText(.ActiveCol, .ActiveRow, Trim(vform.keyfield & "") & "-->>" & Trim(vform.keyfield1 & ""))
                                .SetActiveCell(5, .ActiveRow)
                            Else
                                .SetActiveCell(4, .ActiveRow)
                                .SetText(4, .ActiveRow, "")
                                .SetText(5, .ActiveRow, "0.00")
                            End If
                        Else
                            .SetActiveCell(4, .ActiveRow)
                            .SetText(4, .ActiveRow, "")
                            .SetText(5, .ActiveRow, "0.00")
                        End If
                    End If
                End If
            ElseIf e.keyCode = Keys.F3 Then
                .GetText(2, .ActiveRow, ACHEAD)
                .GetText(3, .ActiveRow, SUBLEDGER)
                .GetText(4, .ActiveRow, COSTCENTER)
                .GetText(1, 1, DCSTATUS)
                If ACHEAD <> "" Or SUBLEDGER <> "" Or COSTCENTER <> "" Then
                    .DeleteRows(.ActiveRow, 1)
                    .Col = 1
                    .Row = .ActiveRow
                    If .Row = 1 Then
                        Call FillDrCrFlag()
                    Else
                        .TypeComboBoxString = DCSTATUS
                    End If
                    .SetActiveCell(2, .ActiveRow)
                    .Col = 2
                    .Row = .ActiveRow
                    .Lock = False
                    CalulateGridTot()
                    'Delete The Record From Match Dataset i.e Gmatch
                    ''''''Dim TableName As String
                    ''''''TableName = Trim(Split(SUBLEDGER, "-->>")(0)) & "*" & .ActiveRow
                    ''''''If gMatch.Tables.Contains(TableName) = True Then
                    ''''''    gMatch.Tables.Remove(TableName)
                    ''''''End If
                    'Delete Of The Match Ends Here
                End If

                'ElseIf e.keyCode = Keys.F10 Then
                '    .Col = 1
                '    .Row = .ActiveRow
                '    gCreditDebit = .Text
                '    .Col = 2
                '    .Row = .ActiveRow
                '    gAccountHead = .Text
                '    .Col = 3
                '    .Row = .ActiveRow
                '    gSlCode = .Text
                '    .Col = 5
                '    .Row = .ActiveRow
                '    gAmt = Val(.Text)
                '    gVoucherno = Trim(Me.Txt_VoucherNo.Text)
                '    gVoucherType = Trim(Me.Txt_VoucherPrefix.Text)
                '    ACHEADARRAY = gAccountHead.Split("-->>")
                '    gAccountHead = ACHEADARRAY(0)
                '    ACHEADARRAY = gSlCode.Split("-->>")
                '    gSlCode = ACHEADARRAY(0)
                '    gRowNo = SSGrid_ReceiptsPayments.ActiveRow
                '    If gAccountHead = gDebitors Or gAccountHead = gCreditors Then
                '        If Trim(gCreditDebit) <> "" And Trim(gSlCode) <> "" And Val(gAmt) > 0 Then
                '            Dim match As New Matching
                '            match.ShowDialog()
                '        End If
                '''    End If
            End If
        End With
    End Sub
    Private Sub CalulateGridTot()
        Dim i As Integer
        Dim amt As Double
        Dim grtot As Double
        For i = 1 To SSGrid_ReceiptsPayments.DataRowCnt
            SSGrid_ReceiptsPayments.Col = 4
            SSGrid_ReceiptsPayments.Row = i
            amt = Val(SSGrid_ReceiptsPayments.Text)
            grtot = grtot + amt
        Next
        Me.Txt_Total.Text = Format(grtot, "0.00")
    End Sub
    Private Function COSTCENTERVALIDATE(ByVal GR As String, ByVal ACHEAD As String)
        Dim SQLSTRING As String
        Dim DR As DataRow
        Dim i As Integer
        SQLSTRING = "SELECT PRIMARYGROUPCODE FROM ACCOUNTTAGGING WHERE GLACCODE = '" & Trim(ACHEAD) & "'"
        Vconn.getDataSet(SQLSTRING, "MASTER1")
        If gdataset.Tables("MASTER1").Rows.Count = 0 Then
            SQLSTRING = "SELECT PRIMARYGROUPCODE FROM ACCOUNTTAGGING WHERE GLACDESC = '" & Trim(ACHEAD) & "'"
            Vconn.getDataSet(SQLSTRING, "MASTER1")
        End If
        If gdataset.Tables("MASTER1").Rows.Count > 0 Then
            GR = Nothing
            For Each DR In gdataset.Tables("MASTER1").Rows
                If Trim(GR) = "" Then
                    GR = "'" & Trim(DR("PRIMARYGROUPCODE")) & "'"
                Else
                    GR = GR & ",'" & Trim(DR("PRIMARYGROUPCODE")) & "'"
                End If
            Next
        Else
        End If
        gdataset.Tables("MASTER1").Dispose()
        COSTCENTERVALIDATE = GR
    End Function
    Private Sub GlGridHelp()
        Dim ACHEAD, SUBLEDGER, COSTCENTER, SQLSTRING, GR As String
        With SSGrid_ReceiptsPayments
            Search = Nothing
            .GetText(2, .ActiveRow, Search)
            DRCR = Nothing
            .GetText(1, .ActiveRow, DRCR)

            Dim vform As New ListOperattion1
            gSQLString = "SELECT ACCODE AS GLCODE,ACDESC AS GLDESCRIPTION  FROM ACCOUNTSGLACCOUNTMASTER"
            M_WhereCondition = " WHERE  ISNULL(FREEZEFLAG,'N') <> 'Y'"
            If DRCR = "DEBIT" Then
                M_WhereCondition = M_WhereCondition & " AND Category IN ('E','A','L')"
            Else
                M_WhereCondition = M_WhereCondition & " AND Category IN ('I','A','L')"
            End If
            vform.Field = "ACDESC,ACCODE"
            ' vform.keyfield = "ACDESC"
            vform.vFormatstring = "  GL CODE             |                GL DESCRIPTION           "
            vform.vCaption = "GENERAL LEDGER HEAD HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                .SetText(.ActiveCol, .ActiveRow, Trim(vform.keyfield & "") & "-->>" & Trim(vform.keyfield1 & ""))
                ACHEAD = Trim(vform.keyfield & "")
                ''''''''' CHECKING WEATHER ACHEAD IS HAVING SUBLEDGER OR NOT -----------------------------
                SQLSTRING = "SELECT SLNAME FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE = '" & Trim(ACHEAD) & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
                Vconn.getDataSet(SQLSTRING, "MASTER1")
                If gdataset.Tables("MASTER1").Rows.Count > 0 Then
                    .SetText(3, .ActiveRow, "")
                    .SetText(4, .ActiveRow, "")
                    .SetText(5, .ActiveRow, "0.00")
                    .SetActiveCell(3, .ActiveRow)
                    .Row = .ActiveRow
                    .Col = 3
                    .Lock = False
                    gdataset.Tables("MASTER1").Dispose()
                Else
                    .SetActiveCell(3, .ActiveRow)
                    .SetText(3, .ActiveRow, "")
                    .SetText(4, .ActiveRow, "")
                    .SetText(5, .ActiveRow, "0.00")
                    .Row = .ActiveRow
                    .Col = 3
                    .Lock = True
                    gdataset.Tables("MASTER1").Dispose()
                    GR = COSTCENTERVALIDATE(GR, ACHEAD)

                    ''''''' CHECKING WEATHER ACHEAD IS HAVING COSTCENTER CODE OR NOT
                    If GR <> Nothing Then
                        SQLSTRING = "SELECT COSTCENTERCODE,COSTCENTERDESC FROM ACCOUNTSCOSTCENTERMASTER WHERE PRIMARYGROUPCODE IN (" & GR & ") AND  ISNULL(FREEZEFLAG,'N') <> 'Y'"
                        Vconn.getDataSet(SQLSTRING, "MASTER1")
                        If gdataset.Tables("MASTER1").Rows.Count > 0 Then
                            .SetActiveCell(4, .ActiveRow)
                            .SetText(4, .ActiveRow, "")
                            .SetText(5, .ActiveRow, "0.00")
                            .Row = .ActiveRow
                            .Col = 4
                            .Lock = False
                            gdataset.Tables("MASTER1").Dispose()
                        Else
                            .SetActiveCell(5, .ActiveRow)
                            .SetText(4, .ActiveRow, "")
                            .SetText(5, .ActiveRow, "0.00")
                            .Row = .ActiveRow
                            .Col = 4
                            .Lock = True
                            gdataset.Tables("MASTER1").Dispose()
                        End If
                    Else
                        .SetActiveCell(5, .ActiveRow)
                        .SetText(5, .ActiveRow, "0.00")
                        .Row = .ActiveRow
                        .Col = 4
                        .Lock = True
                    End If

                End If
            Else
                .SetActiveCell(.ActiveCol, .ActiveRow)
                .SetText(.ActiveCol, .ActiveRow, "")
            End If
            vform.Close()
            vform = Nothing
        End With
    End Sub
    Private Sub SubLedHelp()
        Dim ACHEADARRAY() As String
        Dim ACHEAD As String
        Dim GR As String
        Dim SQLSTRING As String
        With SSGrid_ReceiptsPayments
            .Col = 3
            .Row = .ActiveRow
            If .Lock = True Then
                ' MsgBox("IT LOCK")
                Exit Sub
            Else
                Search = Nothing
                .GetText(3, .ActiveRow, Search)
                .GetText(2, .ActiveRow, ACHEAD)
                ACHEADARRAY = ACHEAD.Split("-->>")
                'MsgBox(ACHEADARRAY(0))
                'SQLSTRING = "SELECT SLCODE,SLDESC FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE = '" & Trim(ACHEADARRAY(0)) & "' AND SLCODE = '" & SUBLEDGER & "'"
                Dim vform As New ListOperattion1
                gSQLString = "SELECT SLCODE,SLDESC FROM accountssubledgermaster"
                M_WhereCondition = " WHERE ACCODE = '" & Trim(ACHEADARRAY(0)) & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
                vform.Field = "SLDESC,SLCODE"
                'vform.Field = "SLDESC"
                vform.vFormatstring = "           SL CODE          |                SL DESCRIPTION              "
                vform.vCaption = "SUB LEDGER CODE HELP"
                vform.KeyPos = 0
                vform.KeyPos1 = 1
                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then
                    .SetText(.ActiveCol, .ActiveRow, Trim(vform.keyfield & "") & "-->>" & Trim(vform.keyfield1 & ""))

                    GR = COSTCENTERVALIDATE(GR, ACHEADARRAY(0))
                    ''''''' CHECKING WEATHER ACHEAD IS HAVING COSTCENTER CODE OR NOT
                    If GR <> Nothing Then
                        SQLSTRING = "SELECT COSTCENTERCODE,COSTCENTERDESC FROM ACCOUNTSCOSTCENTERMASTER WHERE PRIMARYGROUPCODE IN (" & GR & ")  AND ISNULL(FREEZEFLAG,'N') <> 'Y'"
                        Vconn.getDataSet(SQLSTRING, "MASTER1")
                        If gdataset.Tables("MASTER1").Rows.Count > 0 Then
                            .Row = .ActiveRow
                            .Col = 4
                            .Lock = False
                            .SetActiveCell(4, .ActiveRow)
                            .SetText(4, .ActiveRow, "")
                            .SetText(5, .ActiveRow, "0.00")
                            gdataset.Tables("MASTER1").Dispose()
                        Else
                            .Row = .ActiveRow
                            .Col = 4
                            .Lock = True
                            .SetActiveCell(5, .ActiveRow)
                            .SetText(4, .ActiveRow, "")
                            .SetText(5, .ActiveRow, "0.00")
                            gdataset.Tables("MASTER1").Dispose()
                        End If
                    Else
                        .Row = .ActiveRow
                        .Col = 4
                        .Lock = True
                        .SetActiveCell(5, .ActiveRow)
                        .SetText(5, .ActiveRow, "0.00")
                    End If
                End If
                vform.Close()
                vform = Nothing
            End If
        End With
    End Sub
    Private Sub FillDrCrFlag()
        With SSGrid_ReceiptsPayments
            .Col = 1
            .Row = 1
            .TypeComboBoxString = "DEBIT"
            .TypeComboBoxString = "DEBIT"
            .TypeComboBoxCurSel = 0
        End With
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
        Updateyes = False
    End Sub

    Private Sub NonProductPurchase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call FillDrCrFlag()
        Dim sqlstring As String
        Dim Dr As DataRow

        LBL_COMPANYNAME.Text = gCompanyname

        sqlstring = "SELECT DISTINCT TYPEOFDOC FROM ACCOUNTSDOCTYPEMASTER WHERE ISNULL(FREEZEFLAG,'N') <> 'Y' and Category='NON PRODUCT PURCHASE'"
        Vconn.getDataSet(sqlstring, "ACCOUNTSDOCTYPEMASTER")
        Cmb_VoucherType.Items.Clear()
        If gdataset.Tables("ACCOUNTSDOCTYPEMASTER").Rows.Count > 0 Then
            For Each Dr In gdataset.Tables("ACCOUNTSDOCTYPEMASTER").Rows
                Cmb_VoucherType.Items.Add(Trim(Dr("TYPEOFDOC")))
            Next
            Me.Cmb_VoucherType.SelectedIndex = 0
            Me.Cmb_CashCredit.SelectedIndex = 0
        End If
        'date validate
        SYS_DATE_TIME()

        Call Dtp_VoucherDate_LostFocus(sender, e)

    End Sub
    Private Sub Cmb_VoucherType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_VoucherType.SelectedIndexChanged
        Dim SQLSTRING As String
        Dim DR As DataRow
        SQLSTRING = "SELECT PREFIX FROM ACCOUNTSDOCTYPEMASTER WHERE TYPEOFDOC = '" & Cmb_VoucherType.Text & "' AND ISNULL(FREEZEFLAG,'N') <> 'Y' "
        Vconn.getDataSet(SQLSTRING, "ACCOUNTSDOCTYPEMASTERPREFIX")
        If gdataset.Tables("ACCOUNTSDOCTYPEMASTERPREFIX").Rows.Count > 0 Then
            Txt_VoucherPrefix.Text = gdataset.Tables("ACCOUNTSDOCTYPEMASTERPREFIX").Rows(0).Item(0)
            gvoucherprefix = Txt_VoucherPrefix.Text
        End If
        gdataset.Tables("ACCOUNTSDOCTYPEMASTERPREFIX").Dispose()
        'Call vouchernoautogenerate()
        Call FillDrCrFlag()
        Call GetLastVoucherNo(Txt_VoucherPrefix.Text)
    End Sub
    Private Sub GetLastVoucherNo(ByVal vouchertype As String)
        Dim SQLSTRING As String
        Dim DR As DataRow
        SQLSTRING = "SELECT Isnull(Max(VoucherNo),0)as VoucherNo FROM JournalEntry WHERE VoucherType='" & vouchertype & "'"
        Vconn.getDataSet(SQLSTRING, "JournalEntry")
        If gdataset.Tables("JournalEntry").Rows.Count > 0 Then
            Me.Lbl_LastVoucher.Text = "Last Voucher No" & " " & gdataset.Tables("JournalEntry").Rows(0).Item(0)
        Else
            Me.Lbl_LastVoucher.Text = "Last Voucher No" & " " & 0
        End If
    End Sub
    Private Sub Cmb_VoucherType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cmb_VoucherType.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.Dtp_VoucherDate.Focus()
        End If
    End Sub
    Private Sub Dtp_VoucherDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dtp_VoucherDate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.Cmb_CashCredit.Focus()
        End If
    End Sub
    Private Sub Cmb_CashCredit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cmb_CashCredit.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Me.Cmb_CashCredit.SelectedIndex = 0 Then
                Me.Txt_CustomerCode.Focus()
                Me.Lbl_Supplier.Text = "SUPPLIER CODE :"
            Else
                Me.Txt_CustomerCode.Focus()
                Me.Lbl_Supplier.Text = "DAY BOOK :"
            End If
        End If
    End Sub
    Private Sub Txt_CustomerCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_CustomerCode.Validated
        Dim sql As String
        If Me.Cmb_CashCredit.SelectedIndex = 0 Then
            sql = "Select slcode,sldesc From AccountsSubledgerMaster Where AcCode='" & gCreditors & "' AND Isnull(FreezeFlag,'') <> 'Y' And Slcode='" & Trim(Me.Txt_CustomerCode.Text) & "'"
        Else
            sql = "SELECT ACCODE,ACDESC FROM ACCOUNTSGLACCOUNTMASTER WHERE ACTYPE='CASH (ASSETS)'"
        End If
        Vconn.getDataSet(sql, "slmast")
        If gdataset.Tables("slmast").Rows.Count > 0 Then
            Me.txt_customerName.Text = gdataset.Tables("slmast").Rows(0).Item(1)
            Me.Txt_CustomerCode.Text = gdataset.Tables("slmast").Rows(0).Item(0)
            Me.Ssgrid_Bill.Focus()
            Me.Ssgrid_Bill.SetActiveCell(1, 1)
        Else
            Me.Txt_CustomerCode.Text = ""
        End If
    End Sub
    Private Sub Cmd_CustomerCodeHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_CustomerCodeHelp.Click
        Dim vform As New ListOperattion1
        If Me.Cmb_CashCredit.SelectedIndex = 0 Then
            gSQLString = "Select SLCODE,SLNAME FROM ACCOUNTSSUBLEDGERMASTER "
            M_WhereCondition = " Where ISNULL(ACCODE,'')='" & gCreditors & "' AND ISNULL(FREEZEFLAG,'')<>'Y'"
            vform.Field = "SLNAME,SLCODE"
            vform.vFormatstring = "     SUPPLIER CODE               |     SUPPLIER NAME        "
            vform.vCaption = "SUPPLIER HELP"
            vform.KeyPos = 0
            vform.keyfield = ""
            vform.keyfield1 = ""
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_CustomerCode.Text = Trim(vform.keyfield & "")
                Call Txt_CustomerCode_Validated(sender, e)
                Me.Ssgrid_Bill.Focus()
                Me.Ssgrid_Bill.SetActiveCell(1, 1)
            Else
                Me.Txt_CustomerCode.Focus()
            End If
        Else
            gSQLString = " SELECT ACCODE,ACDESC FROM ACCOUNTSGLACCOUNTMASTER "
            M_WhereCondition = " WHERE ACTYPE='CASH (ASSETS)'"
            vform.Field = "ACDESC,ACCODE"
            vform.vFormatstring = "     ACCOUNT CODE               |     ACCOUNT DESC        "
            vform.vCaption = "CASH BOOK HELP"
            vform.KeyPos = 0
            vform.keyfield = 0
            vform.keyfield1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                Txt_CustomerCode.Text = Trim(vform.keyfield & "")
                Call Txt_CustomerCode_Validated(sender, e)
                Me.Ssgrid_Bill.Focus()
                Me.Ssgrid_Bill.SetActiveCell(1, 1)
            Else
                Me.Txt_CustomerCode.Focus()
            End If
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub Txt_CustomerCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_CustomerCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Me.Txt_CustomerCode.Text) = "" Then
                Call Cmd_CustomerCodeHelp_Click(sender, e)
            Else
                Call Txt_CustomerCode_Validated(sender, e)
            End If
        End If
    End Sub

    Private Sub Txt_Naration_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Naration.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.SSGrid_ReceiptsPayments.Focus()
            Me.SSGrid_ReceiptsPayments.SetActiveCell(1, 1)
        End If
    End Sub
    Private Function MeValidate() As Boolean
        MeValidate = True
        Dim i As Integer
        Dim amt As Double
        Dim GrTot As Double
        Dim fend As String
        Dim Fstart As String
        fend = "31-MAR-" & Trim(gFinancialYearEnd)
        Fstart = "01-APR-" & Trim(gFinancalyearStart)

        If GreateDateCheck(DateValue(Me.Dtp_VoucherDate.Text)) = False Then
            MsgBox("The Voucher Date Should Be Less Than System Date")
            Me.Dtp_VoucherDate.Focus()
            MeValidate = False
            Exit Function
        End If
        If FyearDateCheck(DateValue(Me.Dtp_VoucherDate.Text)) = False Then
            MsgBox("The Voucher Date Should Be Within Financial Year")
            Me.Dtp_VoucherDate.Focus()
            MeValidate = False
            Exit Function
        End If
        If Trim(Me.Txt_CustomerCode.Text) = "" Then
            MsgBox("Pls Enter The Supplier/Cash Information")
            Me.Txt_CustomerCode.Focus()
            MeValidate = False
            Exit Function
        End If
        If Val(Me.Txt_BillAmt.Text) = 0 Then
            MsgBox("Pls Enter The Bill Details")
            Me.Ssgrid_Bill.Focus()
            Me.Ssgrid_Bill.SetActiveCell(1, 1)
            MeValidate = False
            Exit Function
        End If
        If Ssgrid_Bill.DataRowCnt = 0 Then
            MsgBox("Pls Enter The Bill Details")
            Ssgrid_Bill.Focus()
            Ssgrid_Bill.SetActiveCell(1, 1)
            MeValidate = False
            Exit Function
        End If
        If SSGrid_ReceiptsPayments.DataRowCnt = 0 Then
            MsgBox("Pls Enter The Debit Part In The Grid")
            Me.SSGrid_ReceiptsPayments.Focus()
            Me.SSGrid_ReceiptsPayments.SetActiveCell(1, 1)
            MeValidate = False
            Exit Function
        End If
        For i = 1 To SSGrid_ReceiptsPayments.DataRowCnt
            SSGrid_ReceiptsPayments.Col = 5
            SSGrid_ReceiptsPayments.Row = i
            amt = Val(SSGrid_ReceiptsPayments.Text)
            GrTot = GrTot + amt
        Next
        If Val(Me.Txt_BillAmt.Text) <> Val(GrTot) Then
            MsgBox("Bill Amt Is Not Matchig With The Grid Amt")
            Me.SSGrid_ReceiptsPayments.Focus()
            Me.SSGrid_ReceiptsPayments.SetActiveCell(1, 1)
            MeValidate = False
            Exit Function
        End If
    End Function
    Private Function vouchernoautogenerate() As String
        Dim sqlstring, financalyear As String
        Dim splitvouchernostr(5) As String
        Dim docprefixreader As SqlDataReader
        gcommand = New SqlCommand
        Dim voucherno As String
        financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialEnd, 3, 4)
        If Len(Me.Txt_VoucherPrefix.Text) = 2 Then
            sqlstring = "SELECT MAX(SUBSTRING(VOUCHERNO,4,6)) FROM journalentry where vouchertype = '" & Me.Txt_VoucherPrefix.Text & "'"
        End If
        If Len(Me.Txt_VoucherPrefix.Text) = 3 Then
            sqlstring = "SELECT MAX(SUBSTRING(VOUCHERNO,5,6)) FROM journalentry where vouchertype = '" & Me.Txt_VoucherPrefix.Text & "'"
        End If
        If Len(Me.Txt_VoucherPrefix.Text) = 4 Then
            sqlstring = "SELECT MAX(SUBSTRING(VOUCHERNO,6,6)) FROM journalentry where vouchertype = '" & Me.Txt_VoucherPrefix.Text & "'"
        End If
        Vconn.openConnection()
        gcommand.CommandText = sqlstring
        gcommand.CommandType = CommandType.Text
        gcommand.Connection = Vconn.Myconn
        docprefixreader = gcommand.ExecuteReader
        If docprefixreader.Read Then
            If docprefixreader(0) Is System.DBNull.Value Then
                voucherno = Trim(Txt_VoucherPrefix.Text) & "/" & "000001" & "/" & financalyear
                docprefixreader.Close()
                gcommand.Dispose()
                Vconn.closeConnection()
            Else
                splitvouchernostr = CStr(docprefixreader(0)).Split("/")
                voucherno = Trim(Txt_VoucherPrefix.Text) & "/" & Format(Val(docprefixreader(0)) + 1, "000000") & "/" & financalyear
                docprefixreader.Close()
                gcommand.Dispose()
                Vconn.closeConnection()
            End If
        Else
            voucherno = Trim(Txt_VoucherPrefix.Text) & "/" & "000001" & "/" & financalyear
            docprefixreader.Close()
            gcommand.Dispose()
            Vconn.closeConnection()
        End If
        vouchernoautogenerate = voucherno
    End Function

    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        If Me.MeValidate = False Then
            Exit Sub
        End If
        Call SaveOperation()
    End Sub
    Private Sub SaveOperation()
        Dim sql(100) As String
        Dim sqlArray() As String
        Dim Cro(1) As String
        Dim i, j As Integer
        Dim VoucherType As String
        Dim vamt As String
        Dim Voucherno As String
        Dim AcCode As String
        Dim achead() As String
        Dim slcode() As String
        Dim costcenter() As String
        Dim oppaccountcode As String
        Dim batchno As Long
        Dim PrevAmt, CurAmt, NetAmt As Double
        Dim VsubCode, VAccCode As String
        Dim CreditDebit1, CreditDebit2 As String
        Dim Ref_no, Ref_Date As String
        If Me.MeValidate = False Then
            Exit Sub
        End If
        Try
            If Updateyes = True Then
                Voucherno = Trim(Me.Txt_VoucherNo.Text)
                batchno = GbatchNo
            Else
                Voucherno = vouchernoautogenerate()
                batchno = Vconn.getvalue("Select ISNULL(max(Batchno),0) + 1 From JournalEntry")
            End If
            VoucherType = Me.Txt_VoucherPrefix.Text
            For i = 1 To Ssgrid_Bill.DataRowCnt
                With Ssgrid_Bill
                    .Col = 1
                    .Row = i
                    Ref_no = .Text

                    .Col = 2
                    .Row = i
                    Ref_Date = .Text

                    .Col = 9
                    .Row = i
                    NetAmt = Val(.Text)

                    sql(i) = "Insert Into JournalEntry(VoucherNo,VoucherDate,VoucherType,VoucherCategory,CreditDebit,Amount,Accountcode,AccountCodeDesc,SlCode,Sldesc,CostCenterCode,CostCenterDesc,InstrumentDate,InstrumentType,BankName,BankPlace,PartyName,ReceivedFrom,ReceivedDate,Micr,InstrumentNo,OppAccountCode,Description,BatchNo,adddatetime,adduserid,void,Ref_No,Ref_Date,CashBank) Values("
                    sql(i) = sql(i) & "'" & Voucherno & "',"
                    sql(i) = sql(i) & "'" & Format(Me.Dtp_VoucherDate.Value, "dd-MMM-yyyy") & "',"
                    sql(i) = sql(i) & "'" & VoucherType & "',"
                    sql(i) = sql(i) & "'" & VoucherType & "',"
                    sql(i) = sql(i) & "'CREDIT',"
                    sql(i) = sql(i) & Format(Val(NetAmt), "0.00") & ","
                    If Me.Cmb_CashCredit.SelectedIndex = 0 Then
                        sql(i) = sql(i) & "'" & gCreditors & "',"
                        sql(i) = sql(i) & "'SUNDRY CREDITORS',"
                        sql(i) = sql(i) & "'" & Trim(Me.Txt_CustomerCode.Text) & "',"
                        sql(i) = sql(i) & "'" & Trim(Me.txt_customerName.Text) & "',"
                    Else
                        sql(i) = sql(i) & "'" & Trim(Me.Txt_CustomerCode.Text) & "',"
                        sql(i) = sql(i) & "'" & Trim(Me.txt_customerName.Text) & "',"
                        sql(i) = sql(i) & "'',"
                        sql(i) = sql(i) & "'',"
                    End If
                    sql(i) = sql(i) & "'',"
                    sql(i) = sql(i) & "'',"
                    sql(i) = sql(i) & "'',"
                    sql(i) = sql(i) & "'',"
                    sql(i) = sql(i) & "'',"
                    sql(i) = sql(i) & "'',"
                    sql(i) = sql(i) & "'',"
                    sql(i) = sql(i) & "'',"
                    sql(i) = sql(i) & "'',"
                    sql(i) = sql(i) & "'',"
                    sql(i) = sql(i) & "'',"
                    sql(i) = sql(i) & "'',"                              'opposite account code
                    sql(i) = sql(i) & "'" & Me.Txt_Naration.Text & "',"
                    sql(i) = sql(i) & batchno & ","
                    sql(i) = sql(i) & "'" & Format(Now, "dd-MMM-yyyy") & "',"
                    sql(i) = sql(i) & "'" & gUsername & "','N',"
                    sql(i) = sql(i) & "'" & Trim(Ref_no) & "',"
                    sql(i) = sql(i) & "'" & Format(DateValue(Ref_Date), "dd-MMM-yyyy") & "',"
                    sql(i) = sql(i) & "'')"
                End With
            Next i

            With SSGrid_ReceiptsPayments
                For j = 1 To .DataRowCnt
                    i = i + 1
                    AcCode = Nothing
                    .Col = 2
                    .Row = j
                    AcCode = .Text
                    If Trim(AcCode) <> "" Then
                        sql(i) = "Insert Into JournalEntry(VoucherNo,VoucherDate,VoucherType,VoucherCategory,CreditDebit,Amount,Accountcode,AccountCodeDesc,SlCode,Sldesc,CostCenterCode,CostCenterDesc,InstrumentDate,InstrumentType,BankName,BankPlace,PartyName,ReceivedFrom,ReceivedDate,Micr,InstrumentNo,OppAccountCode,Description,BatchNo,adddatetime,adduserid,Void,Ref_no,Ref_Date,CashBank) Values("
                        sql(i) = sql(i) & "'" & Voucherno & "',"
                        sql(i) = sql(i) & "'" & Me.Dtp_VoucherDate.Text & "',"
                        sql(i) = sql(i) & "'" & VoucherType & "',"
                        sql(i) = sql(i) & "'" & VoucherType & "',"
                        sql(i) = sql(i) & "'DEBIT',"
                        vamt = Nothing
                        .Col = 5
                        .Row = j
                        vamt = .Text
                        sql(i) = sql(i) & Format(Val(vamt), "0.00") & ","
                        .Col = 2
                        .Row = j
                        achead = Nothing
                        If (.Text) <> "" Then
                            achead = Split(Trim(.Text), "-->>")
                            sql(i) = sql(i) & "'" & Trim(achead(0)) & "',"
                            sql(i) = sql(i) & "'" & Trim(achead(1)) & "',"
                        Else
                            sql(i) = sql(i) & "'',"
                            sql(i) = sql(i) & "'',"
                        End If
                        .Col = 3
                        .Row = j
                        slcode = Nothing
                        If (.Text) <> "" Then
                            slcode = Split(Trim(.Text), "-->>")
                            sql(i) = sql(i) & "'" & Trim(slcode(0)) & "',"
                            sql(i) = sql(i) & "'" & Trim(slcode(1)) & "',"
                        Else
                            sql(i) = sql(i) & "'',"
                            sql(i) = sql(i) & "'',"
                        End If
                        .Col = 4
                        .Row = j
                        costcenter = Nothing
                        If (.Text) <> "" Then
                            costcenter = Split(Trim(.Text), "-->>")
                            sql(i) = sql(i) & "'" & Trim(costcenter(0)) & "',"
                            sql(i) = sql(i) & "'" & Trim(costcenter(1)) & "',"
                        Else
                            sql(i) = sql(i) & "'',"
                            sql(i) = sql(i) & "'',"
                        End If
                        sql(i) = sql(i) & "'',"
                        sql(i) = sql(i) & "'',"
                        sql(i) = sql(i) & "'',"
                        sql(i) = sql(i) & "'',"
                        sql(i) = sql(i) & "'',"
                        sql(i) = sql(i) & "'',"
                        sql(i) = sql(i) & "'',"

                        sql(i) = sql(i) & "'',"
                        sql(i) = sql(i) & "'',"
                        sql(i) = sql(i) & "'',"
                        sql(i) = sql(i) & "'" & Me.Txt_Naration.Text & "',"
                        sql(i) = sql(i) & batchno & ","
                        sql(i) = sql(i) & "'" & Format(Now, "dd-MMM-yyyy") & "',"
                        sql(i) = sql(i) & "'" & gUsername & "','N',"
                        sql(i) = sql(i) & "'" & Trim(Me.Txt_VoucherNo.Text) & "',"
                        sql(i) = sql(i) & "'" & Format(Me.Dtp_VoucherDate.Value, "dd-MMM-yyyy") & "',"
                        sql(i) = sql(i) & "'')"
                    End If
                Next
            End With
            Dim TdsAmt, Esiamt, WcAmt, PtAmt, PfAmt, Billvalue, Net As Double
            Dim Billno, BillDate As String

            For j = 1 To Ssgrid_Bill.DataRowCnt
                i = i + 1
                With Ssgrid_Bill
                    .Row = j
                    .Col = 1
                    Billno = .Text
                    .Col = 2
                    BillDate = .Text
                    .Col = 3
                    Billvalue = Val(.Text)
                    .Col = 4
                    TdsAmt = Val(.Text)
                    .Col = 5
                    Esiamt = Val(.Text)
                    .Col = 6
                    WcAmt = Val(.Text)
                    .Col = 7
                    PfAmt = Val(.Text)
                    .Col = 8
                    PtAmt = Val(.Text)
                    .Col = 9
                    Net = Val(.Text)
                End With

                sql(i) = " Insert Into PurchaseDetails(VoucherNo,VoucherDate,VoucherType,Accountcode,Slcode,GrnNumber,GrnDate,PartyInvNo,PartyInvDate,BasicAmount,TdsCode,TdsPer,TdsAmt,PtCode,PtPer,PtAmt,EsiCode,EsiPer,EsiAmt,WcCode,WcPer,WcAmt,PfCode,PfPer,PfAmt,BillValue,NetAmount,DelFlag)"
                sql(i) = sql(i) & " Values( "
                sql(i) = sql(i) & "'" & Voucherno & "',"
                sql(i) = sql(i) & "'" & Me.Dtp_VoucherDate.Text & "',"
                sql(i) = sql(i) & "'" & VoucherType & "',"
                sql(i) = sql(i) & "'" & gCreditors & "',"
                sql(i) = sql(i) & "'" & Trim(Me.Txt_CustomerCode.Text) & "',"
                sql(i) = sql(i) & "'" & Billno & "',"
                sql(i) = sql(i) & "'" & Format(CDate(BillDate), "dd-MMM-yyyy") & "',"
                sql(i) = sql(i) & "'" & Trim("Billno") & "',"
                sql(i) = sql(i) & "'" & Format(CDate(BillDate), "dd-MMM-yyyy") & "',"
                sql(i) = sql(i) & "0.00,"

                sql(i) = sql(i) & "'" & Trim(Me.Txt_TdsSec.Text) & "',"
                sql(i) = sql(i) & Format(Val(Me.Txt_TdsPer.Text), "0.000") & ","
                sql(i) = sql(i) & Format(Val(TdsAmt), "0.000") & ","

                sql(i) = sql(i) & "'" & Trim(Me.Txt_PurSec.Text) & "',"
                sql(i) = sql(i) & Format(Val(Me.Txt_PurPer.Text), "0.000") & ","
                sql(i) = sql(i) & Format(Val(PtAmt), "0.000") & ","

                sql(i) = sql(i) & "'" & Trim(Me.Txt_EsiSec.Text) & "',"
                sql(i) = sql(i) & Format(Val(Me.Txt_EsiPer.Text), "0.000") & ","
                sql(i) = sql(i) & Format(Val(Esiamt), "0.000") & ","

                sql(i) = sql(i) & "'" & Trim(Me.Txt_WorksSec.Text) & "',"
                sql(i) = sql(i) & Format(Val(Me.Txt_WorksPer.Text), "0.000") & ","
                sql(i) = sql(i) & Format(Val(WcAmt), "0.000") & ","

                sql(i) = sql(i) & "'" & Trim(Me.Txt_PfSec.Text) & "',"
                sql(i) = sql(i) & Format(Val(Me.Txt_PfPer.Text), "0.000") & ","
                sql(i) = sql(i) & Format(Val(PfAmt), "0.000") & ","

                sql(i) = sql(i) & Format(Val(Billvalue), "0.00") & ","
                sql(i) = sql(i) & Format(Val(Net), "0.00") & ",'N')"
            Next j

            Dim TaxArray() As String
            TaxArray = TaxInsertOperations(Voucherno, Me.Txt_VoucherPrefix.Text, batchno)
            sql.Copy(TaxArray, 0, sql, i + 1, 5)

            If Updateyes = True Then
                ReDim sqlArray(UpdateOperation.Length)
                sqlArray.Copy(UpdateOperation, sqlArray, 3)
                ReDim Preserve sqlArray(sqlArray.Length + sql.Length)
                sqlArray.Copy(sql, 0, sqlArray, 5, sql.Length)
            Else
                ReDim sqlArray(sql.Length)
                sqlArray.Copy(sql, sqlArray, sql.Length)
            End If
            If Vconn.MoreTrans(sqlArray) = True Then
                Me.Lbl_LastVoucher.Text = "Last Voucher No" & " " & Voucherno
                MsgBox("Transaction completed suessfully", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Application.ProductName)
                Me.clearoperation()
            End If
        Catch ex As Exception
            MsgBox("Error In Saving")
            Call clearoperation()
        End Try
    End Sub
    Private Function UpdateOperation() As String()
        Dim DelSql(3) As String
        DelSql(0) = "Delete From Journalentry Where Voucherno='" & Trim(Me.Txt_VoucherNo.Text) & "' And VoucherType='" & Trim(Me.Txt_VoucherPrefix.Text) & "'"
        DelSql(1) = "Delete From Outstanding Where Voucherno='" & Trim(Me.Txt_VoucherNo.Text) & "' And VoucherType='" & Trim(Me.Txt_VoucherPrefix.Text) & "'"
        DelSql(2) = "Delete From PurchaseDetails Where Voucherno='" & Trim(Me.Txt_VoucherNo.Text) & "' And VoucherType='" & Trim(Me.Txt_VoucherPrefix.Text) & "'"
        UpdateOperation = DelSql
    End Function
    Private Function DeleteOperation() As String()
        Dim DelSql(3) As String
        DelSql(0) = "Update JournalEntry Set Void='Y',FreezeUserId='" & gUsername & "',FreezeDateTime='" & Format(DateValue(Now), "dd-MMM-yyyy") & "'  From Journalentry Where Voucherno='" & Trim(Me.Txt_VoucherNo.Text) & "' And VoucherType='" & Trim(Me.Txt_VoucherPrefix.Text) & "'"
        DelSql(1) = "Update Outstanding Set Void='Y' Where Voucherno='" & Trim(Me.Txt_VoucherNo.Text) & "' And VoucherType='" & Trim(Me.Txt_VoucherPrefix.Text) & "'"
        DelSql(2) = "Update PurchaseDetails set DelFlag='Y' Where Voucherno='" & Trim(Me.Txt_VoucherNo.Text) & "' And VoucherType='" & Trim(Me.Txt_VoucherPrefix.Text) & "'"
        DeleteOperation = DelSql
    End Function
    Private Sub clearoperation()
        Me.Ssgrid_Bill.ClearRange(1, 1, -1, -1, True)
        Me.Txt_BillAmt.Text = "0.00"
        Me.txt_netamt.Text = "0.00"
        Me.Txt_TotDed.Text = "0.00"
        Me.Txt_CustomerCode.Text = ""
        Me.txt_customerName.Text = ""
        Me.SSGrid_ReceiptsPayments.ClearRange(1, 1, -1, -1, True)
        Me.CmdDelete.Enabled = False
        Me.CmdAdd.Enabled = True
        Me.Cmb_CashCredit.SelectedIndex = 0
        Me.Txt_Total.Text = "0.00"
        Me.Txt_VoucherNo.Enabled = True
        Me.Cmd_VoucherNoHelp.Enabled = True
        Me.Txt_VoucherNo.Text = ""
        Me.Cmb_VoucherType.SelectedIndex = 0
        Me.Cmb_VoucherType.Enabled = True
        Updateyes = False
        Me.Txt_TdsAmt.Text = ""
        Me.Txt_TdsSec.Text = ""
        Me.Txt_TdsPer.Text = ""
        Me.Txt_Naration.Text = ""

        Me.Txt_PfAmt.Text = ""
        Me.Txt_PfPer.Text = ""
        Me.Txt_PfSec.Text = ""

        Me.Txt_PurAmt.Text = ""
        Me.Txt_PurPer.Text = ""
        Me.Txt_PurSec.Text = ""

        Me.Txt_EsiAmt.Text = ""
        Me.Txt_EsiPer.Text = ""
        Me.Txt_EsiSec.Text = ""

        Me.Txt_WorksAmt.Text = ""
        Me.Txt_WorksPer.Text = ""
        Me.Txt_WorksSec.Text = ""

        Call FillDrCrFlag()
        Me.Dtp_VoucherDate.Focus()
    End Sub
    Private Sub Cmd_VoucherNoHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_VoucherNoHelp.Click
        Dim vform As New ListOperattion
        If Me.Txt_VoucherNo.Text <> "" Then
            Search = Trim(Me.Txt_VoucherNo.Text)
        End If
        '        gSQLString = "Select DISTINCT VOUCHERNO,VOUCHERDATE From JournalEntry "

        gSQLString = "Select DISTINCT VoucherNo,VoucherDate,AccountCode,AccountcodeDesc,SLCode,SLDesc,CostCenterCode,CostCenterDesc,CreditDebit,Amount,Description,InstrumentDate,InstrumentType,Instrumentno,BankName,BankPlace From JournalEntry "

        M_WhereCondition = "Where VoucherType='" & Trim(Me.Txt_VoucherPrefix.Text) & "' and Voucherno Like '" & Trim(Me.Txt_VoucherPrefix.Text) & "%'"
        'vform.Field = "VOUCHERNO,VOUCHERDATE"
        'vform.vFormatstring = "           VOUCHER NO                     |              VOUCHER DATE           "

        vform.Field = "VoucherNo,VoucherDate,AccountCode,AccountcodeDesc,SLCode,SLDesc,CostCenterCode,CostCenterDesc,CreditDebit,Amount,Description,InstrumentDate,InstrumentType,Instrumentno,BankName,BankPlace"
        vform.vFormatstring = "  VOUCHER NO           |            VOUCHER DATE        |  Account Code        |  Account Code Desc       |  SL Code        |  SL Desc        |  Cost Center Code        |  Cost Center Desc        |  CreditDebit |   Amount | Description | InstrumentDate | InstrumentType | Instrumentno | BankName | BankPlace"

        vform.vCaption = "PURCHASE NON PRODUCT HELP"
        vform.KeyPos = 0
        vform.keyfield = 0
        vform.keyfield1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_VoucherNo.Text = Trim(vform.keyfield & "")
            Txt_VoucherNo_Validated(sender, e)
        Else
            Me.Txt_VoucherNo.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub Txt_VoucherNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_VoucherNo.Validated
        Dim sqlstring, financalyear As String
        Dim voucherno As String
        Dim CreditDebit As String
        Dim i, j As Integer
        Dim amount As Double
        Dim accounthead, slhead, costhead As String
        If Trim(Me.Txt_VoucherNo.Text) <> "" Then
            'voucherno = VOUCHERNOVALIDATE()
            'sqlstring = "Select * From JournalEntry Where VoucherNo='" & voucherno & "' and VoucherType='" & Trim(Me.Txt_VoucherPrefix.Text) & "' Order By OppAccountCode,CreditDebit"
            financalyear = Mid(gFinancalyearStart, 3, 4) & "-" & Mid(gFinancialEnd, 3, 4)

            If Val(Me.Txt_VoucherNo.Text) > 0 Then
                Me.Txt_VoucherNo.Text = UCase(Me.Txt_VoucherPrefix.Text) & "/" & Format(Val(Me.Txt_VoucherNo.Text), "000000") & "/" & financalyear
            End If
            Call VoucherNoValidations(Trim(Me.Txt_VoucherNo.Text), Trim(Txt_VoucherPrefix.Text))
        Else
            Me.Dtp_VoucherDate.Focus()
        End If
        'date validate
        CMD_LOCK()

    End Sub
    Private Sub VoucherNoValidations(ByVal Voucherno As String, ByVal VoucherType As String)
        Dim sqlstring, financalyear As String
        Dim CreditDebit As String
        Dim i, j As Integer
        Dim amount As Double
        Dim accounthead, slhead, costhead As String

        sqlstring = "Select * From JournalEntry Where VoucherNo='" & Trim(Voucherno) & "' and VoucherType='" & Trim(VoucherType) & "' AND CreditDebit='credit' AND Description Not Like 'AUTO CREDIT PJB%' Order By Rowid,OppAccountCode,CreditDebit"
        Vconn.getDataSet(sqlstring, "JournalEntry")
        If gdataset.Tables("JournalEntry").Rows.Count > 0 Then
            With gdataset.Tables("JournalEntry").Rows(0)
                ' Me.Txt_VoucherNo.Text = voucherno

                Updateyes = True
                If .IsNull("BatchNo") = False Then
                    GbatchNo = .Item("Batchno")
                Else
                    GbatchNo = 0
                End If
                Me.Txt_VoucherNo.Enabled = False
                Me.CmdAdd.Enabled = True
                Me.Cmb_VoucherType.Enabled = False
                Me.Cmd_VoucherNoHelp.Enabled = False
                Me.CmdDelete.Enabled = True
                Me.Dtp_VoucherDate.Value = DateValue(.Item("VoucherDate"))
                Me.Txt_Naration.Text = .Item("Description")
                If Trim(.Item("Slcode")) = "" Then
                    Me.Txt_CustomerCode.Text = Trim(.Item("AccountCode"))
                    Me.txt_customerName.Text = Trim(.Item("AccountCodedesc"))
                Else
                    Me.Txt_CustomerCode.Text = Trim(.Item("Slcode"))
                    Me.txt_customerName.Text = Trim(.Item("Sldesc"))
                End If
                If Trim(.Item("Void")) = "Y" Then
                    Me.lbl_void.Visible = True
                    Me.CmdDelete.Enabled = False
                    Me.CmdAdd.Enabled = False
                Else
                    Me.lbl_void.Visible = False
                    Me.CmdDelete.Enabled = True
                    Me.CmdAdd.Enabled = True
                End If
            End With
        Else
            Txt_VoucherNo.Clear()
            Exit Sub
        End If
        sqlstring = "Select * From JournalEntry Where VoucherNo='" & Trim(Voucherno) & "' and VoucherType='" & Trim(VoucherType) & "' AND CreditDebit='DEBIT' Order By Rowid,OppAccountCode,CreditDebit"
        Vconn.getDataSet(sqlstring, "JournalEntry")
        If gdataset.Tables("JournalEntry").Rows.Count > 0 Then
            CreditDebit = "DEBIT"
            For i = 0 To gdataset.Tables("Journalentry").Rows.Count - 1
                With gdataset.Tables("JournalEntry").Rows(i)
                    accounthead = Nothing
                    slhead = Nothing
                    costhead = Nothing
                    amount = 0
                    If .IsNull("AccountCode") = False And .IsNull("AccountCodeDesc") = False Then
                        accounthead = Trim(Trim(.Item("AccountCode"))) & "-->>" & Trim(Trim(.Item("Accountcodedesc")))
                    End If
                    If .IsNull("SlCode") = False And .IsNull("SlDesc") = False Then
                        slhead = Trim(Trim(.Item("SlCode"))) & "-->>" & Trim(Trim(.Item("SlDesc")))
                    End If
                    If .IsNull("CostCenterCode") = False And .IsNull("CostCenterDesc") = False Then
                        costhead = Trim(Trim(.Item("CostCenterCode"))) & "-->>" & Trim(Trim(.Item("CostCenterDesc")))
                    End If
                    If .IsNull("Amount") = False Then
                        amount = .Item("Amount")
                    End If

                    With SSGrid_ReceiptsPayments
                        .Col = 1
                        .Row = i + 1
                        .TypeComboBoxString = CreditDebit
                        .TypeComboBoxCurSel = 0
                        .Col = 2
                        .Row = i + 1
                        .Text = accounthead
                        If Trim(slhead) <> "-->>" Then
                            .Col = 3
                            .Row = i + 1
                            .Text = slhead
                        End If
                        If Trim(costhead) <> "-->>" Then
                            .Col = 4
                            .Row = i + 1
                            .Text = costhead
                        End If
                        .Col = 5
                        .Row = i + 1
                        .Text = Format(amount, "0.00")
                    End With
                End With
            Next
        Else
            Txt_VoucherNo.Clear()
            Exit Sub
        End If

        'fLL tHE bILLS
        sqlstring = "Select * From PurchaseDetails Where VoucherNo='" & Trim(Voucherno) & "' and VoucherType='" & Trim(VoucherType) & "'"
        Vconn.getDataSet(sqlstring, "PurchaseDetails")
        If gdataset.Tables("PurchaseDetails").Rows.Count > 0 Then
            With Ssgrid_Bill
                Me.Txt_TotDed.Text = ""
                Me.Txt_TdsAmt.Text = ""
                Me.Txt_PfAmt.Text = ""
                Me.Txt_EsiAmt.Text = ""
                Me.Txt_PfAmt.Text = ""
                Me.Txt_WorksAmt.Text = ""
                Me.txt_netamt.Text = ""
                For i = 0 To gdataset.Tables("PurchaseDetails").Rows.Count - 1
                    .Row = i + 1
                    .Col = 1
                    .Text = gdataset.Tables("PurchaseDetails").Rows(i).Item("GrnNumber")
                    .Col = 2
                    .Text = Format(DateValue(gdataset.Tables("PurchaseDetails").Rows(i).Item("GrnDate")), "dd/MM/yy")
                    .Col = 3
                    .Text = Format(Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("Billvalue")), "0.00")
                    .Col = 4
                    .Text = Format(Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("TdsAmt")), "0.000")
                    .Col = 5
                    .Text = Format(Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("EsiAmt")), "0.000")
                    .Col = 6
                    .Text = Format(Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("WcAmt")), "0.000")
                    .Col = 7
                    .Text = Format(Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("PfAmt")), "0.000")
                    .Col = 8
                    .Text = Format(Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("PtAmt")), "0.000")
                    .Col = 9
                    .Text = Format(Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("Netamount")), "0.000")
                    Me.txt_netamt.Text = Format(Val(Me.txt_netamt.Text) + Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("Netamount")), "0.00")

                    If gdataset.Tables("PurchaseDetails").Rows(i).Item("TdsCode") <> "" Then
                        Me.Txt_TdsSec.Text = gdataset.Tables("PurchaseDetails").Rows(i).Item("TdsCode")
                        Me.Txt_TdsPer.Text = Format(gdataset.Tables("PurchaseDetails").Rows(i).Item("TdsPer"), "0.00")
                        Me.Txt_TotDed.Text = Format(Val(Me.Txt_TotDed.Text) + Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("TdsAmt")), "0.000")
                        Me.Txt_TdsAmt.Text = Format(Val(Me.Txt_TdsAmt.Text) + Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("TdsAmt")), "0.000")
                    End If

                    If gdataset.Tables("PurchaseDetails").Rows(i).Item("EsiCode") <> "" Then
                        Me.Txt_EsiSec.Text = gdataset.Tables("PurchaseDetails").Rows(i).Item("EsiCode")
                        Me.Txt_EsiPer.Text = Format(gdataset.Tables("PurchaseDetails").Rows(i).Item("esiPer"), "0.00")
                        Me.Txt_TotDed.Text = Format(Val(Me.Txt_TotDed.Text) + Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("EsiAmt")), "0.000")
                        Me.Txt_EsiAmt.Text = Format(Val(Me.Txt_EsiAmt.Text) + Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("EsiAmt")), "0.000")
                    End If

                    If gdataset.Tables("PurchaseDetails").Rows(i).Item("PtCode") <> "" Then
                        Me.Txt_PurSec.Text = gdataset.Tables("PurchaseDetails").Rows(i).Item("PtCode")
                        Me.Txt_PurPer.Text = Format(gdataset.Tables("PurchaseDetails").Rows(i).Item("PtPer"), "0.00")
                        Me.Txt_TotDed.Text = Format(Val(Me.Txt_TotDed.Text) + Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("pTAmt")), "0.000")
                        Me.Txt_PurAmt.Text = Format(Val(Me.Txt_PurAmt.Text) + Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("pTAmt")), "0.000")
                    End If
                    If gdataset.Tables("PurchaseDetails").Rows(i).Item("wcCode") <> "" Then
                        Me.Txt_WorksSec.Text = gdataset.Tables("PurchaseDetails").Rows(i).Item("wcCode")
                        Me.Txt_WorksPer.Text = Format(gdataset.Tables("PurchaseDetails").Rows(i).Item("wcPer"), "0.00")
                        Me.Txt_TotDed.Text = Format(Val(Me.Txt_TotDed.Text) + Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("wCAmt")), "0.000")
                        Me.Txt_WorksAmt.Text = Format(Val(Me.Txt_WorksAmt.Text) + Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("wCAmt")), "0.000")
                    End If
                    If gdataset.Tables("PurchaseDetails").Rows(i).Item("PfCode") <> "" Then
                        Me.Txt_PfSec.Text = gdataset.Tables("PurchaseDetails").Rows(i).Item("PfCode")
                        Me.Txt_PfPer.Text = Format(gdataset.Tables("PurchaseDetails").Rows(i).Item("PfPer"), "0.00")
                        Me.Txt_TotDed.Text = Format(Val(Me.Txt_TotDed.Text) + Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("PfAmt")), "0.000")
                        Me.Txt_PfAmt.Text = Format(Val(Me.Txt_PfAmt.Text) + Val(gdataset.Tables("PurchaseDetails").Rows(i).Item("PfAmt")), "0.000")
                    End If
                Next i
                Me.Txt_BillAmt.Text = Format(Val(Me.txt_netamt.Text) + Val(Me.Txt_TotDed.Text), "0.00")
                Me.Txt_Total.Text = Format(Val(Me.txt_netamt.Text) + Val(Me.Txt_TotDed.Text), "0.00")
            End With
        End If
        MatchTable = Vconn.GetMatching(Trim(Txt_VoucherNo.Text), Trim(Me.Txt_VoucherPrefix.Text))
        If MatchTable.Rows.Count = 0 Then
            Me.CmdAdd.Enabled = True
            Me.CmdDelete.Enabled = True
            If Me.lbl_void.Visible = True Then
                Me.CmdAdd.Enabled = False
                Me.CmdDelete.Enabled = False
            End If
        Else
            'AvoucherNo,AVoucherDate,AvoucherType,AdjustedAmount
            Me.CmdAdd.Enabled = False
            Me.CmdDelete.Enabled = False
            '' '' '' ''Dim MDet As New MatchingDetails
            '' '' '' ''If MdiParentObj.ActiveMdiChild.Name Is "MatchingDetails" Then
            '' '' '' ''Else
            '' '' '' ''    MDet.MdiParent = MdiParentObj
            '' '' '' ''    MDet.Show()
            '' '' '' ''End If
        End If
        Me.Dtp_VoucherDate.Focus()
    End Sub

    Private Sub NonProductPurchase_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F7 Then
            Me.CmdAdd_Click(sender, e)
        End If
        If e.KeyCode = Keys.F6 Then
            Me.CmdClear_Click(sender, e)
        End If
        If e.KeyCode = Keys.F11 Then
            Me.cmdexit_Click(sender, e)
        End If
        If e.KeyCode = Keys.F8 Then
            If Me.CmdDelete.Enabled = True Then
                Me.CmdDelete_Click(sender, e)
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            Me.CmdView_Click(sender, e)
        End If
        If e.KeyCode = Keys.F2 Then
            Me.Txt_VoucherNo.Focus()
        End If
        If e.KeyCode = Keys.F12 Then
            Call CmdView_Click(sender, e)
        End If
    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Call clearoperation()
    End Sub
    Private Sub CmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdDelete.Click
        'Modified on 17 Dec'07
        'Mk Kannan
        'Begin
        If MessageBox.Show("Are You Sure To Delete!", Application.ProductName, MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Dim sqlArray(3) As String
            sqlArray = DeleteOperation()
            Try
                If Vconn.MoreTrans(sqlArray) = True Then
                    MsgBox("Transaction completed suessfully", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, Application.ProductName)
                    Me.clearoperation()
                End If
            Catch ex As Exception
                MsgBox("Error In Saving")
                Call clearoperation()
            End Try
        Else
            MsgBox("Deletion is Cancelled!", MsgBoxStyle.OkOnly, gCompanyname)
        End If
        'End
    End Sub
    Private Sub Txt_VoucherNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_VoucherNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Me.Txt_VoucherNo.Text) = "" Then
                Call Cmd_VoucherNoHelp_Click(sender, e)
            Else
                Me.Txt_VoucherNo_Validated(sender, e)
            End If
        End If
    End Sub
    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        gPrint = False
        Call Viewoperation()
    End Sub
    Private Sub Txt_Naration_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_Naration.KeyDown
        Dim SSQL As String
        SSQL = "SELECT DESCRIPTIONNAME FROM ACCOUNTSDESCRIPTIONMASTER WHERE SHORTCUTKEY = '" & e.KeyCode.ToString & "'  AND ISNULL(FREEZE,'') <> 'Y'"
        Vconn.getDataSet(SSQL, "DESCRIPTION")
        If gdataset.Tables("DESCRIPTION").Rows.Count <> 0 Then
            Txt_Naration.Text = gdataset.Tables("DESCRIPTION").Rows(0).Item("DESCRIPTIONNAME")
        End If
    End Sub
    Private Sub Viewoperation()
        If Me.Txt_VoucherNo.Text = "" Then
            MsgBox("Please give voucher no", MsgBoxStyle.Information)
            Exit Sub
        End If
        If Me.SSGrid_ReceiptsPayments.DataRowCnt = 0 Then
            MsgBox("No details to print", MsgBoxStyle.Information)
            Exit Sub
        End If
        Randomize()
        Dim PAGENO, ROWCOUNT, I As Integer
        Dim SSQL As String
        Dim SLCODE As String
        Dim VSQL As String

        Dim SLNAME, ADDRESS1, ADDRESS2, ADDRESS3 As String
        vOutfile = Mid("CON" & (Rnd() * 800000), 1, 8)
        VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
        Filewrite = File.AppendText(VFilePath)
        printfile = VFilePath
        PAGENO = 1 : ROWCOUNT = 0
        Dim VREF As Boolean = False

        Dim STR As String
        Dim TOTAL As Double = 0
        Dim NARRATION, VDES As String

        With SSGrid_ReceiptsPayments
            .Row = 1
            .Col = 1
            VDES = Trim(.Text)
        End With
        SSQL = "Select j.VOUCHERNO,j.voucherdate,j.VOUCHERTYPE,j.VOUCHERCATEGORY,CASHBANK,j.ACCOUNTCODE,ACCOUNTCODEDESC,ISNULL(j.SLCODE,'') SLCODE,j.SLDESC,RTRIM(DESCRIPTION)DESCRIPTION,ISNULL(INSTRUMENTNO,'') INSTRUMENTNO,INSTRUMENTDATE,INSTRUMENTTYPE,j.AMOUNT,j.CREDITDEBIT,COSTCENTERDESC,BANKNAME,m.vOUCHERNO as adjustedvoucher,M.ADJUSTEDAMOUNT, "
        SSQL = SSQL & "  sum(Case creditdebit When 'CREDIT' Then j.amount End) As credit,sum(Case creditdebit When 'debit' Then j.amount End) As debit "
        SSQL = SSQL & " from journalentry J Full join Matching M On J.Voucherno=m.Avoucherno and J.Accountcode=M.Accountcode and J.Slcode=M.Slcode "
        SSQL = SSQL & " where isnull(void,'')<>'Y'   AND J.VOUCHERTYPE IN(SELECT PREFIX FROM ACCOUNTSDOCTYPEMASTER WHERE CATEGORY='NON PRODUCT PURCHASE')"

        ''SSQL = SSQL & " AND CASHBANK ='CASH (ASSETS)' "
        SSQL = SSQL & " AND J.VOUCHERNO = '" & Trim(Txt_VoucherNo.Text) & "'  "
        If Trim(VDES) <> "" Then
            SSQL = SSQL & " AND J.CREDITDEBIT = '" & Trim(VDES) & "'  "
        End If
        SSQL = SSQL & " group by j.VOUCHERNO,j.voucherdate,j.VOUCHERTYPE,j.VOUCHERCATEGORY,j.CASHBANK,j.ACCOUNTCODE,j.ACCOUNTCODEDESC,j.SLCODE,j.SLDESC,j.DESCRIPTION,INSTRUMENTNO,INSTRUMENTDATE,INSTRUMENTTYPE,j.AMOUNT,j.CREDITDEBIT,j.COSTCENTERDESC,j.BANKNAME,m.vOUCHERNO,M.ADJUSTEDAMOUNT "
        SSQL = SSQL & " ORDER BY j.VOUCHERNO,J.Accountcode,J.Slcode"

        Vconn.getDataSet(SSQL, "NONPRODPURCHASE")
        Dim vcaption1 As String
        vcaption1 = ""
        If gdataset.Tables("NONPRODPURCHASE").Rows.Count > 0 Then
            I = 0
            Call Vconn.printheader(80, vcaption1)
            Filewrite.WriteLine(Chr(15) & Chr(14) & Space(40) & "PURCHASE NON PRODUCT VOUCHER" & Chr(18))
            Filewrite.WriteLine()
            Filewrite.WriteLine(StrDup(80, "-"))
            ROWCOUNT = 6

            For I = 0 To gdataset.Tables("NONPRODPURCHASE").Rows.Count - 1
                With gdataset.Tables("NONPRODPURCHASE").Rows(I)
                    If VREF = False Then
                        STR = "SELECT ISNULL(SLNAME,'')SLNAME,ISNULL(ADDRESS1,'')ADDRESS1,ISNULL(ADDRESS2,'')ADDRESS2,ISNULL(ADDRESS3,'')ADDRESS3,ISNULL(STATE,'')STATE,ISNULL(PHONENO,'')PHONENO FROM ACCOUNTSSUBLEDGERMASTER"
                        STR = STR & " WHERE SLCODE  = '" & Trim(Txt_CustomerCode.Text) & "'"
                        Vconn.getDataSet(STR, "ACCOUNTSSUBLEDGERMASTER")
                        If gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows.Count > 0 Then
                            If gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).IsNull("SLNAME") = False Then
                                SSQL = "|" & Mid(gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).Item("SLNAME"), 1, 40) & Space(40 - Len(Mid(gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).Item("SLNAME"), 1, 40))) & "|"
                                SSQL = SSQL & "SERIAL NO  : " & Mid(Trim(Txt_VoucherNo.Text), 1, 20) & Space(20 - Len(Mid(Trim(Txt_VoucherNo.Text), 1, 20)))
                            Else
                                SSQL = "|" & Space(40) & "|"
                                SSQL = SSQL & "SERIAL NO  : " & Mid(Trim(Txt_VoucherNo.Text), 1, 20) & Space(20 - Len(Mid(Trim(Txt_VoucherNo.Text), 1, 20)))
                            End If
                            Filewrite.WriteLine(SSQL)

                            If gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).IsNull("ADDRESS1") = False Then
                                SSQL = "|" & Mid(gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).Item("ADDRESS1"), 1, 40) & Space(40 - Len(Mid(gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).Item("ADDRESS1"), 1, 40))) & "|"
                                SSQL = SSQL & "DATE NO    : " & Mid(Trim(Dtp_VoucherDate.Text), 1, 20) & Space(20 - Len(Mid(Trim(Dtp_VoucherDate.Text), 1, 20)))
                            Else
                                SSQL = "|" & Space(40) & "|"
                                SSQL = SSQL & "DATE       : " & Mid(Trim(Dtp_VoucherDate.Text), 1, 20) & Space(20 - Len(Mid(Trim(Dtp_VoucherDate.Text), 1, 20)))
                            End If
                            Filewrite.WriteLine(SSQL)

                            If gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).IsNull("ADDRESS2") = False Then
                                SSQL = "|" & Mid(gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).Item("ADDRESS2"), 1, 40) & Space(40 - Len(Mid(gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).Item("ADDRESS2"), 1, 40))) & "|"
                                SSQL = SSQL & "INVOICE NO : " & Mid(Trim(Txt_VoucherNo.Text), 1, 20) & Space(20 - Len(Mid(Trim(Txt_VoucherNo.Text), 1, 20)))
                            Else
                                SSQL = "|" & Space(40) & "|"
                                SSQL = SSQL & "INVOICE NO : " & Mid(Trim(Txt_VoucherNo.Text), 1, 20) & Space(20 - Len(Mid(Trim(Txt_VoucherNo.Text), 1, 20)))
                            End If
                            Filewrite.WriteLine(SSQL)

                            If gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).IsNull("ADDRESS3") = False Then
                                SSQL = "|" & Mid(gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).Item("ADDRESS3"), 1, 40) & Space(40 - Len(Mid(gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).Item("ADDRESS3"), 1, 40))) & "|"
                                SSQL = SSQL & "DATE       : " & Mid(Trim(Dtp_VoucherDate.Text), 1, 20) & Space(20 - Len(Mid(Trim(Dtp_VoucherDate.Text), 1, 20)))
                            Else
                                SSQL = "|" & Space(40) & "|"
                                SSQL = SSQL & "DATE       : " & Mid(Trim(Dtp_VoucherDate.Text), 1, 20) & Space(20 - Len(Mid(Trim(Dtp_VoucherDate.Text), 1, 20)))
                            End If
                            Filewrite.WriteLine(SSQL)

                            If gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).IsNull("PHONENO") = False And gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).Item("PHONENO") <> "" Then
                                SSQL = "|" & Mid(gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).Item("PHONENO"), 1, 40) & Space(40 - Len(Mid(gdataset.Tables("ACCOUNTSSUBLEDGERMASTER").Rows(0).Item("PHONENO"), 1, 40))) & "|"
                                SSQL = SSQL & "DUE DATE   : " & Mid(Trim(Dtp_VoucherDate.Text), 1, 20) & Space(20 - Len(Mid(Trim(Dtp_VoucherDate.Text), 1, 20)))
                            Else
                                SSQL = "|" & Space(40) & "|"
                                SSQL = SSQL & "DUE DATE   : " & Mid(Trim(Dtp_VoucherDate.Text), 1, 20) & Space(20 - Len(Mid(Trim(Dtp_VoucherDate.Text), 1, 20)))
                            End If
                            Filewrite.WriteLine(SSQL)
                        Else
                            SLNAME = "" : ADDRESS1 = "" : ADDRESS2 = "" : ADDRESS3 = ""
                        End If

                        Filewrite.WriteLine(StrDup(80, "-"))
                        Filewrite.WriteLine("|" & "POSTED DETAILS" & Space(50) & " | AMOUNT     |")
                        Filewrite.WriteLine(StrDup(80, "-"))
                        VREF = True
                    End If

                    If gdataset.Tables("NONPRODPURCHASE").Rows(I).IsNull("ACCOUNTCODEDESC") = False Then
                        SSQL = "|" & Mid(gdataset.Tables("NONPRODPURCHASE").Rows(I).Item("ACCOUNTCODEDESC"), 1, 65) & Space(65 - Len(Mid(gdataset.Tables("NONPRODPURCHASE").Rows(I).Item("ACCOUNTCODEDESC"), 1, 65))) & "|"
                    Else
                        SSQL = "|" & Space(65) & "|"
                    End If

                    If gdataset.Tables("NONPRODPURCHASE").Rows(I).IsNull("AMOUNT") = False Then
                        SSQL = SSQL & Space(12 - Len(Mid(Format(gdataset.Tables("NONPRODPURCHASE").Rows(I).Item("AMOUNT"), "0.00"), 1, 12))) & Mid(Format(gdataset.Tables("NONPRODPURCHASE").Rows(I).Item("AMOUNT"), "0.00"), 1, 12) & "|"
                        TOTAL = TOTAL + gdataset.Tables("NONPRODPURCHASE").Rows(I).Item("AMOUNT")
                    Else
                        SSQL = SSQL & Space(12) & "|"
                    End If

                    Filewrite.WriteLine(SSQL)

                    If gdataset.Tables("NONPRODPURCHASE").Rows(I).IsNull("DESCRIPTION") = False Then
                        NARRATION = gdataset.Tables("NONPRODPURCHASE").Rows(I).Item("DESCRIPTION")
                    Else
                        NARRATION = ""
                    End If

                    ROWCOUNT = ROWCOUNT + 1
                    If ROWCOUNT > 58 Then
                        Filewrite.WriteLine(Chr(12))
                        ROWCOUNT = 0
                        PAGENO = PAGENO + 1
                        Filewrite.WriteLine(Chr(12))
                        Call Vconn.printheader(80, vcaption1)
                        Filewrite.WriteLine(Chr(15) & Chr(14) & Space(40) & "PURCHASE NON PRODUCT VOUCHER" & Chr(18))
                        Filewrite.WriteLine()
                        Filewrite.WriteLine(StrDup(80, "-"))
                        ROWCOUNT = 6
                    End If
                End With
            Next

            'Filewrite.WriteLine(Space(10) & SLNAME & Mid(NARRATION, 1, 30) & Space(30 - Len(Mid(NARRATION, 1, 30))))

            Filewrite.WriteLine(Space(20) & "NARRATION : " & Mid(NARRATION, 1, 30) & Space(30 - Len(Mid(NARRATION, 1, 30))))
            If Len(NARRATION) > 31 Then
                Filewrite.WriteLine(Space(20) & Mid(NARRATION, 31, 30) & Space(32 - Len(Mid(NARRATION, 31, 30))))
                If Len(NARRATION) > 61 And Len(NARRATION) < 90 Then
                    Filewrite.WriteLine(Space(20) & Mid(NARRATION, 60, 30) & Space(32 - Len(Mid(NARRATION, 60, 30))))
                End If
                If Len(NARRATION) > 91 And Len(NARRATION) < 120 Then
                    Filewrite.WriteLine(Space(20) & Mid(NARRATION, 91, 30) & Space(32 - Len(Mid(NARRATION, 91, 30))))
                End If
                If Len(NARRATION) > 121 And Len(NARRATION) < 150 Then
                    Filewrite.WriteLine(Space(20) & Mid(NARRATION, 121, 30) & Space(32 - Len(Mid(NARRATION, 121, 30))))
                End If
            End If
        Else
            MsgBox("NO RECORD TO VIEW ", MsgBoxStyle.Information)
            Exit Sub
        End If
        Filewrite.WriteLine(StrDup(80, "-"))
        Filewrite.WriteLine(Mid(RupeesToWord(TOTAL), 1, 46) & Space(46 - Len(Mid(RupeesToWord(TOTAL), 1, 46))) & "NET AMOUNT PASSED : " & "|" & Space(12 - Len(Mid(Format(TOTAL, "0.00"), 1, 12))) & Mid(Format(TOTAL, "0.00"), 1, 12) & "|")
        Filewrite.WriteLine(StrDup(80, "-"))
        Filewrite.WriteLine()
        Filewrite.WriteLine()
        Filewrite.WriteLine()
        Filewrite.WriteLine("PREPARED BY " & Space(20) & " CHECKED BY " & Space(20) & " PASSED BY")
        Filewrite.Write(Chr(12))
        Filewrite.Close()
        If gPrint = False Then
            OpenTextFile(vOutfile)
        Else
            PrintTextFile1(VFilePath)
        End If
    End Sub
    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        gPrint = True
        Call Viewoperation()
    End Sub

    Private Sub Ssgrid_Bill_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles Ssgrid_Bill.Advance

    End Sub

    Private Sub Ssgrid_Bill_KeyPressEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyPressEvent) Handles Ssgrid_Bill.KeyPressEvent
        If e.keyAscii = 13 Then
            If Ssgrid_Bill.ActiveCol = 1 Then
                Ssgrid_Bill.SetActiveCell(2, Ssgrid_Bill.ActiveRow)
                Exit Sub
            End If
            If Ssgrid_Bill.ActiveCol = 2 Then
                Ssgrid_Bill.SetActiveCell(3, Ssgrid_Bill.ActiveRow)
                Exit Sub
            End If
            If Ssgrid_Bill.ActiveCol = 3 Then
                Dim amt As Double
                Dim row As Integer
                With Ssgrid_Bill
                    .Col = 3
                    .Row = .ActiveRow
                    amt = Val(.Text)
                    row = .ActiveRow
                    If amt > 0 Then
                        Call CalculateBillAmt(amt, row)
                    End If
                End With
                Ssgrid_Bill.SetActiveCell(1, Ssgrid_Bill.ActiveRow + 1)
                Call TotalBillAmt()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Ssgrid_Bill_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles Ssgrid_Bill.KeyDownEvent
        If e.keyCode = Keys.F3 Then
            Ssgrid_Bill.DeleteRows(Ssgrid_Bill.ActiveRow, 1)
            Call TotalBillAmt()
            Dim amt As Double
            Dim row As Integer
            With Ssgrid_Bill
                .Col = 3
                .Row = .ActiveRow
                amt = Val(.Text)
                row = .ActiveRow
                Call CalculateBillAmt(amt, row)
            End With
        End If
    End Sub
    Private Sub Ssgrid_Bill_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles Ssgrid_Bill.LeaveCell
        Call TotalBillAmt()
        Dim amt As Double
        Dim row As Integer
        With Ssgrid_Bill
            .Col = 3
            .Row = .ActiveRow
            amt = Val(.Text)
            row = .ActiveRow
            If amt > 0 Then
                Call CalculateBillAmt(amt, row)
            End If
        End With
    End Sub

    Private Sub Ssgrid_Bill_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ssgrid_Bill.Validated
        Call TotalBillAmt()
    End Sub
    Private Sub CalculateBillAmt(ByVal Billamt As Double, ByVal RowNo As Integer)
        Dim ssql As String
        Dim TdsAmt As Double
        Dim EsiAmt As Double
        Dim PfAmt As Double
        Dim Works As Double
        Dim Puramt As Double
        Dim TotalDeductions As Double
        Dim i As Integer
        ssql = "select Isnull(Slcode,'') as Slcode,Isnull(TdsFlag,'') As TdsFlag,TdsSection, TdsPercentage, Isnull(WorksContractFlag,'') As WorksContractFlag,"
        ssql = ssql & " WorksContractSection, WorksContractPercentage, Isnull(PurchaseFlag,'') As PurchaseFlag,PurchaseSection,Purchasepercentage,"
        ssql = ssql & " Isnull(esiFlag,'') As EsiFlag, EsiSection,EsiPercentage, Isnull(PfFlag,'') As PfFlag,PfSection,PfPercentage"
        ssql = ssql & " from AccountsSubledgerMaster where accode='" & gCreditors & "' And SLcode='" & Trim(Me.Txt_CustomerCode.Text) & "'"
        Vconn.getDataSet(ssql, "TDS")
        If gdataset.Tables("TDS").Rows.Count > 0 Then
            With gdataset.Tables("TDS").Rows(0)
                If .Item("TdsFlag") = "Y" Then
                    TdsAmt = Billamt * Val(.Item("TdsPercentage")) / 100
                    Ssgrid_Bill.Col = 4
                    Ssgrid_Bill.Row = RowNo
                    If TotalDeductions > 0 Then
                        TotalDeductions = TotalDeductions + TdsAmt
                    Else
                        TotalDeductions = TdsAmt
                    End If
                    Ssgrid_Bill.Text = Format(TdsAmt, "0.000")
                    Me.Txt_TdsPer.Text = Format(Val(.Item("TdsPercentage")), "0.000")
                    Me.Txt_TdsSec.Text = .Item("TdsSection")
                End If
                If .Item("WorksContractFlag") = "Y" Then
                    Works = Billamt * Val(.Item("WorksContractPercentage")) / 100
                    Ssgrid_Bill.Col = 6
                    Ssgrid_Bill.Row = RowNo
                    Ssgrid_Bill.Text = Format(Works, "0.000")
                    If TotalDeductions > 0 Then
                        TotalDeductions = TotalDeductions + Works
                    Else
                        TotalDeductions = Works
                    End If
                    Me.Txt_WorksPer.Text = Format(Val(.Item("WorksContractPercentage")), "0.000")
                    Me.Txt_WorksSec.Text = .Item("WorksContractSection")
                End If
                If .Item("esiFlag") = "Y" Then
                    'esiFlag,EsiSection,EsiPercentage
                    EsiAmt = Billamt * Val(.Item("EsiPercentage")) / 100
                    Ssgrid_Bill.Col = 5
                    Ssgrid_Bill.Row = RowNo
                    Ssgrid_Bill.Text = Format(EsiAmt, "0.000")
                    If TotalDeductions > 0 Then
                        TotalDeductions = TotalDeductions + EsiAmt
                    Else
                        TotalDeductions = EsiAmt
                    End If
                    Me.Txt_EsiAmt.Text = Val(Txt_EsiAmt.Text) + Format(EsiAmt, "0.000")
                    Me.Txt_EsiPer.Text = Format(Val(.Item("EsiPercentage")), "0.000")
                    Me.Txt_EsiSec.Text = .Item("EsiSection")
                    Me.Txt_TotDed.Text = Format(Val(Me.Txt_TotDed.Text) + Val(Me.Txt_EsiAmt.Text), "0.000")
                End If
                If .Item("PfFlag") = "Y" Then
                    'PfFlag(, PfSection, PfPercentage)
                    PfAmt = Billamt * Val(.Item("PfPercentage")) / 100
                    SSGrid_ReceiptsPayments.Col = 7
                    SSGrid_ReceiptsPayments.Row = RowNo
                    SSGrid_ReceiptsPayments.Text = Format(PfAmt, "0.000")
                    If TotalDeductions > 0 Then
                        TotalDeductions = TotalDeductions + PfAmt
                    Else
                        TotalDeductions = PfAmt
                    End If
                    Me.Txt_PfAmt.Text = Val(Txt_PfAmt.Text) + Format(PfAmt, "0.000")
                    Me.Txt_PfPer.Text = Format(Val(.Item("PfPercentage")), "0.000")
                    Me.Txt_PfSec.Text = .Item("PfSection")
                    Me.Txt_TotDed.Text = Format(Val(Me.Txt_TotDed.Text) + Val(Me.Txt_PfAmt.Text), "0.000")
                End If
                If .Item("PurchaseFlag") = "Y" Then
                    'PurchaseFlag,PurchaseSection,Purchasepercentage
                    Puramt = Billamt * Val(.Item("Purchasepercentage")) / 100
                    SSGrid_ReceiptsPayments.Col = 8
                    SSGrid_ReceiptsPayments.Row = RowNo
                    SSGrid_ReceiptsPayments.Text = Format(Puramt, "0.000")
                    If TotalDeductions > 0 Then
                        TotalDeductions = TotalDeductions + Puramt
                    Else
                        TotalDeductions = Puramt
                    End If
                    Me.Txt_PurAmt.Text = Val(Txt_PurAmt.Text) + Format(Puramt, "0.000")
                    Me.Txt_PurPer.Text = Format(Val(.Item("Purchasepercentage")), "0.000")
                    Me.Txt_PurSec.Text = .Item("PurchaseSection")
                    Me.Txt_TotDed.Text = Format(Val(Me.Txt_TotDed.Text) + Val(Me.Txt_PurAmt.Text), "0.000")
                End If
                Ssgrid_Bill.Col = 9
                Ssgrid_Bill.Row = RowNo
                Ssgrid_Bill.Text = Format(Billamt - TotalDeductions, "0.000")
            End With
        End If
        Me.Txt_TdsAmt.Text = ""
        Me.Txt_PurAmt.Text = ""
        Me.Txt_PfAmt.Text = ""
        Me.Txt_WorksAmt.Text = ""
        Me.Txt_EsiAmt.Text = ""

        For i = 1 To Ssgrid_Bill.DataRowCnt
            Ssgrid_Bill.Col = 4
            Ssgrid_Bill.Row = i
            TdsAmt = Val(Ssgrid_Bill.Text)
            If Val(TdsAmt) > 0 Then
                If Val(Me.Txt_TdsAmt.Text) > 0 Then
                    Me.Txt_TdsAmt.Text = Format(Val(Txt_TdsAmt.Text) + Val(TdsAmt), "0.000")
                Else
                    Me.Txt_TdsAmt.Text = Format(Val(TdsAmt), "0.000")
                End If
            End If
            Ssgrid_Bill.Col = 6
            Ssgrid_Bill.Row = i
            Works = Val(Ssgrid_Bill.Text)
            If Val(Works) > 0 Then
                If Val(Me.Txt_WorksAmt.Text) > 0 Then
                    Me.Txt_WorksAmt.Text = Format(Val(Txt_WorksAmt.Text) + Val(Works), "0.000")
                Else
                    Me.Txt_WorksAmt.Text = Format(Val(Works), "0.000")
                End If
            End If
            Ssgrid_Bill.Col = 5
            Ssgrid_Bill.Row = i
            EsiAmt = Val(Ssgrid_Bill.Text)
            If Val(EsiAmt) > 0 Then
                If Val(Me.Txt_EsiAmt.Text) > 0 Then
                    Me.Txt_EsiAmt.Text = Format(Val(Txt_EsiAmt.Text) + Val(EsiAmt), "0.000")
                Else
                    Me.Txt_EsiAmt.Text = Format(Val(EsiAmt), "0.000")
                End If
            End If
            Ssgrid_Bill.Col = 7
            Ssgrid_Bill.Row = i
            PfAmt = Val(Ssgrid_Bill.Text)
            If Val(PfAmt) > 0 Then
                If Val(Me.Txt_PfAmt.Text) > 0 Then
                    Me.Txt_PfAmt.Text = Format(Val(Txt_PfAmt.Text) + Val(PfAmt), "0.000")
                Else
                    Me.Txt_PfAmt.Text = Format(Val(PfAmt), "0.000")
                End If
            End If
            Ssgrid_Bill.Col = 8
            Ssgrid_Bill.Row = i
            Puramt = Val(Ssgrid_Bill.Text)
            If Val(Puramt) > 0 Then
                If Val(Me.Txt_PurAmt.Text) > 0 Then
                    Me.Txt_PurAmt.Text = Format(Val(Txt_PurAmt.Text) + Val(Puramt), "0.000")
                Else
                    Me.Txt_PurAmt.Text = Format(Val(Puramt), "0.000")
                End If
            End If
        Next i
        Me.Txt_TotDed.Text = Format(Val(Me.Txt_TdsAmt.Text) + Val(Txt_WorksAmt.Text) + Val(Txt_EsiAmt.Text) + Val(Txt_PfAmt.Text) + Val(Me.Txt_PurAmt.Text), "0.000")
        Me.txt_netamt.Text = Format(Val(Me.Txt_BillAmt.Text) - Val(Me.Txt_TotDed.Text), "0.00")
    End Sub
    Private Function TaxInsertOperations(ByVal voucherno As String, ByVal vouchertype As String, ByVal Batchno As String) As String()
        Dim i As Integer
        Dim Ref_no, Ref_Date As String
        Dim Tds, Works, Esi, Pf, Pur As Double
        Dim Acode, Adesc, Sdesc, Scode As String
        Dim sql(5) As String
        Dim ssql As String
        If Val(Me.Txt_TdsAmt.Text) > 0 Then
            ssql = "select Glaccountin,Glaccountdesc,SubledgerCode,SubledgerDesc from accountsTdsmaster Where TdsCode='" & Trim(Me.Txt_TdsSec.Text) & "'"
            Vconn.getDataSet(ssql, "TDS")
            If gdataset.Tables("TDS").Rows.Count > 0 Then
                With gdataset.Tables("TDS").Rows(0)
                    Acode = .Item(0)
                    Adesc = .Item(1)
                    Scode = .Item(2)
                    Sdesc = .Item(3)
                End With
            Else
                Acode = ""
                Adesc = ""
                Scode = ""
                Sdesc = ""
            End If
            sql(0) = "Insert Into JournalEntry(VoucherNo,VoucherDate,VoucherType,VoucherCategory,CreditDebit,Amount,Accountcode,AccountCodeDesc,SlCode,Sldesc,CostCenterCode,CostCenterDesc,InstrumentDate,InstrumentType,BankName,BankPlace,PartyName,ReceivedFrom,ReceivedDate,Micr,InstrumentNo,OppAccountCode,Description,BatchNo,adddatetime,adduserid,void,Ref_No,Ref_Date,CashBank) Values("
            sql(0) = sql(0) & "'" & voucherno & "',"
            sql(0) = sql(0) & "'" & Format(Me.Dtp_VoucherDate.Value, "dd-MMM-yyyy") & "',"
            sql(0) = sql(0) & "'" & vouchertype & "',"
            sql(0) = sql(0) & "'" & vouchertype & "',"
            sql(0) = sql(0) & "'CREDIT',"
            sql(0) = sql(0) & Format(Val(Me.Txt_TdsAmt.Text), "0.000") & ","
            sql(0) = sql(0) & "'" & Trim(Acode) & "',"
            sql(0) = sql(0) & "'" & Trim(Adesc) & "',"
            sql(0) = sql(0) & "'" & Trim(Scode) & "',"
            sql(0) = sql(0) & "'" & Trim(Sdesc) & "',"
            sql(0) = sql(0) & "'',"
            sql(0) = sql(0) & "'',"
            sql(0) = sql(0) & "'',"
            sql(0) = sql(0) & "'',"
            sql(0) = sql(0) & "'',"
            sql(0) = sql(0) & "'',"
            sql(0) = sql(0) & "'',"
            sql(0) = sql(0) & "'',"
            sql(0) = sql(0) & "'',"
            sql(0) = sql(0) & "'',"
            sql(0) = sql(0) & "'',"
            sql(0) = sql(0) & "'',"                              'opposite account code
            sql(0) = sql(0) & "'AUTO CREDIT PJB',"
            sql(0) = sql(0) & Batchno & ","
            sql(0) = sql(0) & "'" & Format(Now, "dd-MMM-yyyy") & "',"
            sql(0) = sql(0) & "'" & gUsername & "','N',"
            sql(0) = sql(0) & "'',"
            sql(0) = sql(0) & "'',"
            sql(0) = sql(0) & "'')"
        End If
        If Val(Me.Txt_WorksAmt.Text) > 0 Then
            ssql = "select Glaccountin,Glaccountdesc,SubledgerCode,SubledgerDesc from AccountsWorksContractmaster Where WorksContractcode='" & Trim(Me.Txt_WorksSec.Text) & "'"
            Vconn.getDataSet(ssql, "TDS")
            If gdataset.Tables("TDS").Rows.Count > 0 Then
                With gdataset.Tables("TDS").Rows(0)
                    Acode = .Item(0)
                    Adesc = .Item(1)
                    Scode = .Item(2)
                    Sdesc = .Item(3)
                End With
            Else
                Acode = ""
                Adesc = ""
                Scode = ""
                Sdesc = ""
            End If
            sql(1) = "Insert Into JournalEntry(VoucherNo,VoucherDate,VoucherType,VoucherCategory,CreditDebit,Amount,Accountcode,AccountCodeDesc,SlCode,Sldesc,CostCenterCode,CostCenterDesc,InstrumentDate,InstrumentType,BankName,BankPlace,PartyName,ReceivedFrom,ReceivedDate,Micr,InstrumentNo,OppAccountCode,Description,BatchNo,adddatetime,adduserid,void,Ref_No,Ref_Date,CashBank) Values("
            sql(1) = sql(1) & "'" & voucherno & "',"
            sql(1) = sql(1) & "'" & Format(Me.Dtp_VoucherDate.Value, "dd-MMM-yyyy") & "',"
            sql(1) = sql(1) & "'" & vouchertype & "',"
            sql(1) = sql(1) & "'" & vouchertype & "',"
            sql(1) = sql(1) & "'CREDIT',"
            sql(1) = sql(1) & Format(Val(Me.Txt_WorksAmt.Text), "0.000") & ","
            sql(1) = sql(1) & "'" & Trim(Acode) & "',"
            sql(1) = sql(1) & "'" & Trim(Adesc) & "',"
            sql(1) = sql(1) & "'" & Trim(Scode) & "',"
            sql(1) = sql(1) & "'" & Trim(Sdesc) & "',"
            sql(1) = sql(1) & "'',"
            sql(1) = sql(1) & "'',"
            sql(1) = sql(1) & "'',"
            sql(1) = sql(1) & "'',"
            sql(1) = sql(1) & "'',"
            sql(1) = sql(1) & "'',"
            sql(1) = sql(1) & "'',"
            sql(1) = sql(1) & "'',"
            sql(1) = sql(1) & "'',"
            sql(1) = sql(1) & "'',"
            sql(1) = sql(1) & "'',"                              'opposite account code
            sql(1) = sql(1) & "'',"
            sql(1) = sql(1) & "'AUTO CREDIT PJB',"
            sql(1) = sql(1) & Batchno & ","
            sql(1) = sql(1) & "'" & Format(Now, "dd-MMM-yyyy") & "',"
            sql(1) = sql(1) & "'" & gUsername & "','N',"
            sql(1) = sql(1) & "'',"
            sql(1) = sql(1) & "'',"
            sql(1) = sql(1) & "'')"
        End If
        If Val(Me.Txt_EsiAmt.Text) > 0 Then
            ssql = "select Glaccountin,Glaccountdesc,SubledgerCode,SubledgerDesc from AccountsEsiMaster Where Esicode='" & Trim(Me.Txt_EsiSec.Text) & "'"
            Vconn.getDataSet(ssql, "TDS")
            If gdataset.Tables("TDS").Rows.Count > 0 Then
                With gdataset.Tables("TDS").Rows(0)
                    Acode = .Item(0)
                    Adesc = .Item(1)
                    Scode = .Item(2)
                    Sdesc = .Item(3)
                End With
            Else
                Acode = ""
                Adesc = ""
                Scode = ""
                Sdesc = ""
            End If
            sql(2) = "Insert Into JournalEntry(VoucherNo,VoucherDate,VoucherType,VoucherCategory,CreditDebit,Amount,Accountcode,AccountCodeDesc,SlCode,Sldesc,CostCenterCode,CostCenterDesc,InstrumentDate,InstrumentType,BankName,BankPlace,PartyName,ReceivedFrom,ReceivedDate,Micr,InstrumentNo,OppAccountCode,Description,BatchNo,adddatetime,adduserid,void,Ref_No,Ref_Date,CashBank) Values("
            sql(2) = sql(2) & "'" & voucherno & "',"
            sql(2) = sql(2) & "'" & Format(Me.Dtp_VoucherDate.Value, "dd-MMM-yyyy") & "',"
            sql(2) = sql(2) & "'" & vouchertype & "',"
            sql(2) = sql(2) & "'" & vouchertype & "',"
            sql(2) = sql(2) & "'CREDIT',"
            sql(2) = sql(2) & Format(Val(Me.Txt_EsiAmt.Text), "0.000") & ","
            sql(2) = sql(2) & "'" & Trim(Acode) & "',"
            sql(2) = sql(2) & "'" & Trim(Adesc) & "',"
            sql(2) = sql(2) & "'" & Trim(Scode) & "',"
            sql(2) = sql(2) & "'" & Trim(Sdesc) & "',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'AUTO CREDIT PJB',"
            sql(2) = sql(2) & Batchno & ","
            sql(2) = sql(2) & "'" & Format(Now, "dd-MMM-yyyy") & "',"
            sql(2) = sql(2) & "'" & gUsername & "','N',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'',"
            sql(2) = sql(2) & "'')"
        End If
        If Val(Me.Txt_PfAmt.Text) > 0 Then
            ssql = "select Glaccountin,Glaccountdesc,SubledgerCode,SubledgerDesc from AccountsPfMaster Where Pfcode='" & Trim(Me.Txt_PfSec.Text) & "'"
            Vconn.getDataSet(ssql, "TDS")
            If gdataset.Tables("TDS").Rows.Count > 0 Then
                With gdataset.Tables("TDS").Rows(0)
                    Acode = .Item(0)
                    Adesc = .Item(1)
                    Scode = .Item(2)
                    Sdesc = .Item(3)
                End With
            Else
                Acode = ""
                Adesc = ""
                Scode = ""
                Sdesc = ""
            End If
            sql(3) = "Insert Into JournalEntry(VoucherNo,VoucherDate,VoucherType,VoucherCategory,CreditDebit,Amount,Accountcode,AccountCodeDesc,SlCode,Sldesc,CostCenterCode,CostCenterDesc,InstrumentDate,InstrumentType,BankName,BankPlace,PartyName,ReceivedFrom,ReceivedDate,Micr,InstrumentNo,OppAccountCode,Description,BatchNo,adddatetime,adduserid,void,Ref_No,Ref_Date,CashBank) Values("
            sql(3) = sql(3) & "'" & voucherno & "',"
            sql(3) = sql(3) & "'" & Format(Me.Dtp_VoucherDate.Value, "dd-MMM-yyyy") & "',"
            sql(3) = sql(3) & "'" & vouchertype & "',"
            sql(3) = sql(3) & "'" & vouchertype & "',"
            sql(3) = sql(3) & "'CREDIT',"
            sql(3) = sql(3) & Format(Val(Me.Txt_PfAmt.Text), "0.000") & ","
            sql(3) = sql(3) & "'" & Trim(Acode) & "',"
            sql(3) = sql(3) & "'" & Trim(Adesc) & "',"
            sql(3) = sql(3) & "'" & Trim(Scode) & "',"
            sql(3) = sql(3) & "'" & Trim(Sdesc) & "',"
            sql(3) = sql(3) & "'',"
            sql(3) = sql(3) & "'',"
            sql(3) = sql(3) & "'',"
            sql(3) = sql(3) & "'',"
            sql(3) = sql(3) & "'',"
            sql(3) = sql(3) & "'',"
            sql(3) = sql(3) & "'',"
            sql(3) = sql(3) & "'',"
            sql(3) = sql(3) & "'',"
            sql(3) = sql(3) & "'',"
            sql(3) = sql(3) & "'',"                              'opposite account code
            sql(3) = sql(3) & "'',"
            sql(3) = sql(3) & "'AUTO CREDIT PJB',"
            sql(3) = sql(3) & Batchno & ","
            sql(3) = sql(3) & "'" & Format(Now, "dd-MMM-yyyy") & "',"
            sql(3) = sql(3) & "'" & gUsername & "','N',"
            sql(3) = sql(3) & "'',"
            sql(3) = sql(3) & "'',"
            sql(3) = sql(3) & "'')"
        End If
        If Val(Me.Txt_PurPer.Text) > 0 Then
            ssql = "select Glaccountin,Glaccountdesc,SubledgerCode,SubledgerDesc from AccountsPurchasetaxMaster Where PurchaseCode='" & Trim(Me.Txt_PurSec.Text) & "'"
            Vconn.getDataSet(ssql, "TDS")
            If gdataset.Tables("TDS").Rows.Count > 0 Then
                With gdataset.Tables("TDS").Rows(0)
                    Acode = .Item(0)
                    Adesc = .Item(1)
                    Scode = .Item(2)
                    Sdesc = .Item(3)
                End With
            Else
                Acode = ""
                Adesc = ""
                Scode = ""
                Sdesc = ""
            End If
            sql(4) = "Insert Into JournalEntry(VoucherNo,VoucherDate,VoucherType,VoucherCategory,CreditDebit,Amount,Accountcode,AccountCodeDesc,SlCode,Sldesc,CostCenterCode,CostCenterDesc,InstrumentDate,InstrumentType,BankName,BankPlace,PartyName,ReceivedFrom,ReceivedDate,Micr,InstrumentNo,OppAccountCode,Description,BatchNo,adddatetime,adduserid,void,Ref_No,Ref_Date,CashBank) Values("
            sql(4) = sql(4) & "'" & voucherno & "',"
            sql(4) = sql(4) & "'" & Format(Me.Dtp_VoucherDate.Value, "dd-MMM-yyyy") & "',"
            sql(4) = sql(4) & "'" & vouchertype & "',"
            sql(4) = sql(4) & "'" & vouchertype & "',"
            sql(4) = sql(4) & "'CREDIT',"
            sql(4) = sql(4) & Format(Val(Me.Txt_PurPer.Text), "0.000") & ","
            sql(4) = sql(4) & "'" & Trim(Acode) & "',"
            sql(4) = sql(4) & "'" & Trim(Adesc) & "',"
            sql(4) = sql(1) & "'" & Trim(Scode) & "',"
            sql(4) = sql(4) & "'" & Trim(Sdesc) & "',"
            sql(4) = sql(4) & "'',"
            sql(4) = sql(4) & "'',"
            sql(4) = sql(4) & "'',"
            sql(4) = sql(4) & "'',"
            sql(4) = sql(4) & "'',"
            sql(4) = sql(4) & "'',"
            sql(4) = sql(4) & "'',"
            sql(4) = sql(4) & "'',"
            sql(4) = sql(4) & "'',"
            sql(4) = sql(4) & "'',"                              'opposite account code
            sql(4) = sql(4) & "'',"
            sql(4) = sql(4) & "'AUTO CREDIT PJB',"
            sql(4) = sql(4) & Batchno & ","
            sql(4) = sql(4) & "'" & Format(Now, "dd-MMM-yyyy") & "',"
            sql(4) = sql(4) & "'" & gUsername & "','N',"
            sql(4) = sql(4) & "'',"
            sql(4) = sql(4) & "'',"
            sql(4) = sql(4) & "'')"
        End If
        Return sql
    End Function
    Private Sub SYS_DATE_TIME()
        Try
            SQLSTRING = "SELECT SERVERDATE,SERVERTIME FROM VIEW_SERVER_DATETIME "
            Vconn.getDataSet(SQLSTRING, "SERVERDATE")
            If gdataset.Tables("SERVERDATE").Rows.Count > 0 Then
                Dtp_VoucherDate.Value = gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE")
            End If

            Dtp_VoucherDate.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Enter a valid datetime :" & ex.Message, CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Function CMD_LOCK()
        Try
            Dim MsgString As String
            SQLSTRING = "SELECT ISNULL(MAX(VOUCHERDATE),GETDATE()) AS VOUCHERDATE  FROM JOURNALENTRY WHERE ISNULL(VOID,'')<>'Y' AND VOUCHERTYPE IN (SELECT PREFIX FROM ACCOUNTSDOCTYPEMASTER WHERE ISNULL(FREEZEFLAG,'N') <> 'Y' and Category='CASH/BANK' GROUP BY PREFIX)"
            Vconn.getDataSet(SQLSTRING, "MAXDATE")
            If gdataset.Tables("MAXDATE").Rows.Count > 0 Then
                If gUserCategory = "S" And gMaxDateCheck = True Then
                    If CDate(Format(Dtp_VoucherDate.Value, "dd/MMM/yyyy")) < CDate(Format(gdataset.Tables("MAXDATE").Rows(0).Item("VOUCHERDATE"), "dd/MMM/yyyy")) Then
                        MsgString = "Voucher Date Should be Greaterthan or Equal to " & Format(gdataset.Tables("MAXDATE").Rows(0).Item("VOUCHERDATE"), "dd/MMM/yyyy") & " ....... Or Please Contact Admin....... "
                        MsgBox(MsgString, MsgBoxStyle.OkOnly, "Max Voucher Date")
                        CmdAdd.Enabled = False
                        CmdDelete.Enabled = False
                        '                        Dtp_VoucherDate.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub Dtp_VoucherDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp_VoucherDate.LostFocus
        Dim sqlstring As String
        Try
            sqlstring = "SELECT SERVERDATE,SERVERTIME FROM VIEW_SERVER_DATETIME "
            Vconn.getDataSet(sqlstring, "SERVERDATE")
            If gdataset.Tables("SERVERDATE").Rows.Count > 0 Then

                If CDate(Format(Dtp_VoucherDate.Value, "dd/MMM/yyyy")) < CDate(Format(strFinancialYearStart, "dd/MMM/yyyy")) And gFinancialYearDateCheck = True Then
                    MsgBox("Voucher Date Should be within Financial Year .......", MsgBoxStyle.OkOnly, "Date Validation")
                    Dtp_VoucherDate.Value = strFinancialYearStart
                    '                    Exit Sub
                End If

                If CDate(Format(Dtp_VoucherDate.Value, "dd/MMM/yyyy")) > CDate(Format(strFinancialYearEnd, "dd/MMM/yyyy")) And gFinancialYearDateCheck = True Then
                    MsgBox("Voucher Date Should be within Financial Year .......", MsgBoxStyle.OkOnly, "Date Validation")
                    Dtp_VoucherDate.Value = strFinancialYearEnd
                    '                   Exit Sub
                End If

                If CDate(Format(Dtp_VoucherDate.Value, "dd/MMM/yyyy")) > CDate(Format(gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE"), "dd/MMM/yyyy")) And gServerDateCheck = True Then
                    MsgBox("Voucher Date should be Lessthan or equal to Server System Date.......", MsgBoxStyle.OkOnly, "Date Validation")
                    Dtp_VoucherDate.Value = gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE")
                    '                  Exit Sub
                End If

                If CDate(Format(strFinancialYearEnd, "dd/MMM/yyyy")) < CDate(Format(Dtp_VoucherDate.Value, "dd/MMM/yyyy")) And gFinancialYearDateCheck = True Then
                    MsgBox("Voucher Date Should be within Financial Year Date.......", MsgBoxStyle.OkOnly, "Date Validation")
                    Dtp_VoucherDate.Value = strFinancialYearEnd
                    '                 Exit Sub
                End If
            End If
            Call CMD_LOCK()
        Catch
            MsgBox("Error in date view..." & Err.Description)
        End Try
    End Sub
    Private Sub Dtp_VoucherDate_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtp_VoucherDate.Validated
        Call Dtp_VoucherDate_LostFocus(sender, e)
    End Sub

    Private Sub print_windows()
        Dim str As String
        Dim Viewer As New ReportViwer
        Dim r As New Rpt_PurchaseNonProductNote

        str = "DROP VIEW vw_PurchaseNonProductNote"
        Vconn.dataOperation(6, str)

        str = "CREATE VIEW vw_PurchaseNonProductNote AS Select isnull(voucherno,'') as voucherno,isnull(Voucherdate,'') as Voucherdate,isnull(Vouchertype,'') as Vouchertype,isnull(Accountcode,'') as Accountcode,isnull(accountcodedesc,'') as accountcodedesc,isnull(slcode,'') as slcode,isnull(sldesc,'') as sldesc,isnull(costcentercode,'') as costcentercode,isnull(costcenterdesc,'') as costcenterdesc,isnull(creditdebit,'') as creditdebit,isnull(amount,0) As Amount ,case when creditdebit='CREDIT' then isnull(amount,0) else 0 end CrAmount,case when creditdebit<>'CREDIT' then isnull(amount,0) else 0 end DrAmount,isnull(description,'') as description,Isnull(InstrumentDate,'') as InstrumentDate,IsNull(Instrumentno,'') AS InstrumentNo,case when isnull(Receivedfrom,'')<>'' then isnull(Receivedfrom,'') else isnull(partyname,'') end as Receivedfrom,isnull(void,'') as void from JournalEntry where "
        str = str & " isnull(void,'') <> 'Y' and VoucherNo='" & Txt_VoucherNo.Text & "'"
        Vconn.getDataSet(str, "vw_PurchaseNonProductNote")

        str = "select * from vw_PurchaseNonProductNote "

        Viewer.ssql = str
        Viewer.Report = r
        Viewer.TableName = "vw_PurchaseNonProductNote"

        Dim TXTOBJ11 As TextObject
        TXTOBJ11 = r.ReportDefinition.ReportObjects("TEXT11")
        TXTOBJ11.Text = gCompanyname

        Dim TXTOBJ14 As TextObject
        TXTOBJ14 = r.ReportDefinition.ReportObjects("TEXT14")
        TXTOBJ14.Text = gCompanyAddress(0)

        Dim TXTOBJ8 As TextObject
        TXTOBJ8 = r.ReportDefinition.ReportObjects("TEXT8")
        TXTOBJ8.Text = gCompanyAddress(1)


        Dim TXTOBJ15 As TextObject
        TXTOBJ15 = r.ReportDefinition.ReportObjects("TEXT15")
        TXTOBJ15.Text = "User : - " & gUsername


        Dim TXTOBJ5 As TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("TEXT5")
        TXTOBJ5.Text = Cmb_VoucherType.Text

        'Dim TXTOBJ4 As TextObject
        'TXTOBJ4 = r.ReportDefinition.ReportObjects("TEXT4")
        'If InStr(Cmb_VoucherType.Text, "REC", CompareMethod.Text) <> 0 Then
        '    TXTOBJ4.Text = "Received From :"
        'Else
        '    TXTOBJ4.Text = "Paid To       :"
        'End If

        Dim TXTOBJ12 As TextObject
        TXTOBJ12 = r.ReportDefinition.ReportObjects("TEXT12")
        TXTOBJ12.Text = RupeesToWord(Val(Txt_Total.Text))


        'Dim TXTOBJ18 As TextObject
        'TXTOBJ18 = r.ReportDefinition.ReportObjects("TEXT18")
        'TXTOBJ18.Text = Trim(Cmb_InstType.Text) & " No. :"


        Viewer.Show()

    End Sub

    Private Sub cmdcrystal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcrystal.Click
        print_windows()
    End Sub

    Private Sub Txt_Total_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Total.TextChanged

    End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click

    End Sub

    Private Sub Gpr_Supplier_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Gpr_Supplier.Enter

    End Sub
End Class