Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Imports System.IO
Public Class PARTYBilling
    Inherits System.Windows.Forms.Form
    Dim DT, DT1 As New DataTable
    Dim DS As New DataSet
    Dim SSQL As String
    Dim GCONNECTION As New GlobalClass
    Dim gconn As New GlobalClass
    Dim BOOLCHK As Boolean
    Dim INSERT(0), Update2(0) As String
    Dim ssqlstring As String
    Dim DTPRECDATE As Date
    Dim I, J, K As Integer
    Dim STRPOSCODE As String
    Dim GuestType As String
    Dim PACKINGPERCENT As Double
    Dim GrdAmount, GrdTaxAmt As Double
    Dim QTY, RATE, AMT, AMTT, TAX1, TAXAMOUNT, SERTAX, TAXAMT1, AMOUNT, ROUNDOFF, TAXPER, HALLTAXPERC, CAMOUNT, totalamount As Double
    Dim UOM, ITEMCODE, ITEMDESC, CHITNO, POSCODE As String
    Dim POS
    Dim itembool, chkbool, smartcardbool, boolPromotional As Boolean
    Dim TEXPERC As Double
    Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB, Tpercent As Double
    Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB, GrdRate As Double
    Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, KStatus As String
    Dim CDAY, pagesize, pageno As Integer
    Dim CANCEL, boolchk1, boolProm As Boolean
    Dim EMPTYSPACE As Integer = 11
    Dim EMPTYLOOP As Integer
    Dim PRTAXPERC As Double = 0
    Dim PRTAXPERCCONT As Double = 0
    Friend WithEvents cmd_mcodehelp As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Btn_recdet As System.Windows.Forms.Button
    Friend WithEvents Btn_Hallava As System.Windows.Forms.Button
    Friend WithEvents Btn_Hallres As System.Windows.Forms.Button
    Friend WithEvents cmd_report As System.Windows.Forms.Button
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmdview As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Btn_nonveg As System.Windows.Forms.Button
    Friend WithEvents btn_veg As System.Windows.Forms.Button
    Friend WithEvents txt_NVegpax As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents pnl_POSCode As System.Windows.Forms.Panel
    Friend WithEvents lvw_POSCode As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pnl_UOMCode As System.Windows.Forms.Panel
    Friend WithEvents lvw_Uom As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TXT_DISCOUNT As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Txt_Others As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Txt_BillTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Cmd_SBill As System.Windows.Forms.Button
    Dim SERVICETAXPERC As Double = 0
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grp_Tabledetails As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTMCODE As System.Windows.Forms.TextBox
    Friend WithEvents TXTFROMTIME As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DTPPARTYDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTTOTIME As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TXTADVANCE As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmdhallHelp As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents DTPBOOKINGDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_Loccode As System.Windows.Forms.TextBox
    Friend WithEvents TXTBOOKINGNO As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents CMBBOOKINGTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Clear2 As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents GBHALLFACILITY As System.Windows.Forms.GroupBox
    Friend WithEvents TXTMNAME As System.Windows.Forms.TextBox
    Friend WithEvents TxtOCCUPANCY As System.Windows.Forms.TextBox
    Friend WithEvents TXTDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents txtHALLDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents TXTHALLCODE As System.Windows.Forms.TextBox
    Friend WithEvents TXTRECEIPTNO As System.Windows.Forms.TextBox
    Friend WithEvents TXTHALLRENT As System.Windows.Forms.TextBox
    Friend WithEvents CHBHALLTAX As System.Windows.Forms.CheckBox
    Friend WithEvents CMDDATEVALE As System.Windows.Forms.Button
    Friend WithEvents RDBHALLFACILITY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBARRITEM As System.Windows.Forms.RadioButton
    Friend WithEvents RDBRESMENU As System.Windows.Forms.RadioButton
    Friend WithEvents CMBTEMPDATE As System.Windows.Forms.ComboBox
    Friend WithEvents LABBOOKINGSTATUS As System.Windows.Forms.Label
    Friend WithEvents GBARRANGEDETAILS As System.Windows.Forms.GroupBox
    Friend WithEvents SSGRID_ARRANGE As AxFPSpreadADO.AxfpSpread
    Friend WithEvents GBMENUDETAILS As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TXTASSOCIATENAME As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TXTRESTOTALAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXTRESTAXAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXTRESAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TXTARRTAXAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXTARRAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXTARRTOTALAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cmd_print As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TXTRESCANCELAMT As System.Windows.Forms.TextBox
    Friend WithEvents TXTSERTAX As System.Windows.Forms.TextBox
    Friend WithEvents TXTARRCANCELAMT As System.Windows.Forms.TextBox
    Friend WithEvents TXTHALLCANCELAMT As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents labbooking As System.Windows.Forms.Label
    Friend WithEvents LABELDATE As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents bookingstatus As System.Windows.Forms.Label
    Friend WithEvents SSGRID_HALL As AxFPSpreadADO.AxfpSpread
    Friend WithEvents chbreceipt As System.Windows.Forms.CheckBox
    Friend WithEvents GBHALLBOOKING As System.Windows.Forms.GroupBox
    Friend WithEvents SSGRID_BOOKING As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Cmd_BookingNo As System.Windows.Forms.Button
    Friend WithEvents rdo_halldisplay As System.Windows.Forms.RadioButton
    Friend WithEvents GRP_TARIFF As System.Windows.Forms.GroupBox
    Friend WithEvents SSGRID_TARIFF As AxFPSpreadADO.AxfpSpread
    Friend WithEvents CMD_TARIFF As System.Windows.Forms.Button
    Friend WithEvents TXT_TARIFF As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TXT_TARIFFDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Txt_Maxitems As System.Windows.Forms.TextBox
    Friend WithEvents Lbl_Menu As System.Windows.Forms.Label
    Friend WithEvents Pic_spousesign As System.Windows.Forms.PictureBox
    Friend WithEvents Pic_Spouse As System.Windows.Forms.PictureBox
    Friend WithEvents Pic_Sign As System.Windows.Forms.PictureBox
    Friend WithEvents Pic_Member As System.Windows.Forms.PictureBox
    Friend WithEvents CMB_LOCATION As System.Windows.Forms.ComboBox
    Friend WithEvents CMD_BILLINGNO As System.Windows.Forms.Button
    Friend WithEvents TXTBILLINGNO As System.Windows.Forms.TextBox
    Friend WithEvents labbilling As System.Windows.Forms.Label
    Friend WithEvents LBL_PARTYDAY As System.Windows.Forms.Label
    Friend WithEvents lbl_bookday As System.Windows.Forms.Label
    Friend WithEvents Cmd_report22 As System.Windows.Forms.Button
    Friend WithEvents cmdreport1 As System.Windows.Forms.Button
    Friend WithEvents TxtNVOCCUPANCY As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtVOCCUPANCY As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents RDO_TARIFF As System.Windows.Forms.RadioButton
    Friend WithEvents RDO_nv_TARIFF As System.Windows.Forms.RadioButton
    Friend WithEvents GRP_NVEG As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TXT_NVMAX As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TXT_NVDESC As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents NVHELP As System.Windows.Forms.Button
    Friend WithEvents TextNVTBOX As System.Windows.Forms.TextBox
    Friend WithEvents SSGRID_NV As AxFPSpreadADO.AxfpSpread
    Friend WithEvents DTPRECEIPTDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents BTN_MENU As System.Windows.Forms.Button
    Friend WithEvents TXT_MENU As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TXT_TOTAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TXT_DISAMT As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TXTB_BAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents SSGRID As AxFPSpreadADO.AxfpSpread
    Friend WithEvents SSGRID_MENU1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TXTGUESTNAME As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PARTYBilling))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grp_Tabledetails = New System.Windows.Forms.GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Cmd_BookingNo = New System.Windows.Forms.Button()
        Me.cmd_mcodehelp = New System.Windows.Forms.Button()
        Me.TXTGUESTNAME = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.BTN_MENU = New System.Windows.Forms.Button()
        Me.DTPRECEIPTDATE = New System.Windows.Forms.DateTimePicker()
        Me.TxtVOCCUPANCY = New System.Windows.Forms.TextBox()
        Me.labbilling = New System.Windows.Forms.Label()
        Me.TxtNVOCCUPANCY = New System.Windows.Forms.TextBox()
        Me.TXTRECEIPTNO = New System.Windows.Forms.TextBox()
        Me.CMDDATEVALE = New System.Windows.Forms.Button()
        Me.DTPBOOKINGDATE = New System.Windows.Forms.DateTimePicker()
        Me.TXTBOOKINGNO = New System.Windows.Forms.TextBox()
        Me.LABELDATE = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTMCODE = New System.Windows.Forms.TextBox()
        Me.TXTFROMTIME = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DTPPARTYDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TXTMNAME = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXTTOTIME = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TxtOCCUPANCY = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TXTDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.TXTADVANCE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.labbooking = New System.Windows.Forms.Label()
        Me.CMBTEMPDATE = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.TXT_MENU = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.lbl_bookday = New System.Windows.Forms.Label()
        Me.LBL_PARTYDAY = New System.Windows.Forms.Label()
        Me.CMD_BILLINGNO = New System.Windows.Forms.Button()
        Me.TXTBILLINGNO = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.CMBBOOKINGTYPE = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TXTASSOCIATENAME = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GBHALLFACILITY = New System.Windows.Forms.GroupBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TXTHALLCANCELAMT = New System.Windows.Forms.TextBox()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.SSGRID_HALL = New AxFPSpreadADO.AxfpSpread()
        Me.cmdreport1 = New System.Windows.Forms.Button()
        Me.CHBHALLTAX = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TXTHALLRENT = New System.Windows.Forms.TextBox()
        Me.cmdhallHelp = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtHALLDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.TXTHALLCODE = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmd_print = New System.Windows.Forms.Button()
        Me.Cmd_Clear2 = New System.Windows.Forms.Button()
        Me.Cmd_Add1 = New System.Windows.Forms.Button()
        Me.Cmd_report22 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Cmd_View = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RDO_nv_TARIFF = New System.Windows.Forms.RadioButton()
        Me.RDO_TARIFF = New System.Windows.Forms.RadioButton()
        Me.rdo_halldisplay = New System.Windows.Forms.RadioButton()
        Me.RDBARRITEM = New System.Windows.Forms.RadioButton()
        Me.RDBRESMENU = New System.Windows.Forms.RadioButton()
        Me.RDBHALLFACILITY = New System.Windows.Forms.RadioButton()
        Me.bookingstatus = New System.Windows.Forms.Label()
        Me.LABBOOKINGSTATUS = New System.Windows.Forms.Label()
        Me.GBARRANGEDETAILS = New System.Windows.Forms.GroupBox()
        Me.SSGRID_ARRANGE = New AxFPSpreadADO.AxfpSpread()
        Me.TXTARRCANCELAMT = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TXTARRTOTALAMOUNT = New System.Windows.Forms.TextBox()
        Me.TXTARRTAXAMOUNT = New System.Windows.Forms.TextBox()
        Me.TXTARRAMOUNT = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.GBMENUDETAILS = New System.Windows.Forms.GroupBox()
        Me.SSGRID = New AxFPSpreadADO.AxfpSpread()
        Me.TXTRESCANCELAMT = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TXTRESTOTALAMOUNT = New System.Windows.Forms.TextBox()
        Me.TXTRESTAXAMOUNT = New System.Windows.Forms.TextBox()
        Me.TXTRESAMOUNT = New System.Windows.Forms.TextBox()
        Me.GRP_NVEG = New System.Windows.Forms.GroupBox()
        Me.SSGRID_NV = New AxFPSpreadADO.AxfpSpread()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TXT_NVMAX = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TXT_NVDESC = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.NVHELP = New System.Windows.Forms.Button()
        Me.TextNVTBOX = New System.Windows.Forms.TextBox()
        Me.SSGRID_MENU1 = New AxFPSpreadADO.AxfpSpread()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.chbreceipt = New System.Windows.Forms.CheckBox()
        Me.GBHALLBOOKING = New System.Windows.Forms.GroupBox()
        Me.Txt_BillTotal = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Txt_Others = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TXT_DISCOUNT = New System.Windows.Forms.TextBox()
        Me.SSGRID_BOOKING = New AxFPSpreadADO.AxfpSpread()
        Me.TXTB_BAMOUNT = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TXT_DISAMT = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TXT_TOTAMT = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.GRP_TARIFF = New System.Windows.Forms.GroupBox()
        Me.SSGRID_TARIFF = New AxFPSpreadADO.AxfpSpread()
        Me.Txt_Maxitems = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TXT_TARIFFDESC = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.CMD_TARIFF = New System.Windows.Forms.Button()
        Me.TXT_TARIFF = New System.Windows.Forms.TextBox()
        Me.Lbl_Menu = New System.Windows.Forms.Label()
        Me.Pic_spousesign = New System.Windows.Forms.PictureBox()
        Me.Pic_Spouse = New System.Windows.Forms.PictureBox()
        Me.Pic_Sign = New System.Windows.Forms.PictureBox()
        Me.Pic_Member = New System.Windows.Forms.PictureBox()
        Me.CMB_LOCATION = New System.Windows.Forms.ComboBox()
        Me.Btn_recdet = New System.Windows.Forms.Button()
        Me.Btn_Hallava = New System.Windows.Forms.Button()
        Me.Btn_Hallres = New System.Windows.Forms.Button()
        Me.cmd_report = New System.Windows.Forms.Button()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.Cmdview = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.Btn_nonveg = New System.Windows.Forms.Button()
        Me.btn_veg = New System.Windows.Forms.Button()
        Me.txt_NVegpax = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pnl_POSCode = New System.Windows.Forms.Panel()
        Me.lvw_POSCode = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnl_UOMCode = New System.Windows.Forms.Panel()
        Me.lvw_Uom = New System.Windows.Forms.ListView()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Cmd_SBill = New System.Windows.Forms.Button()
        Me.grp_Tabledetails.SuspendLayout()
        Me.GBHALLFACILITY.SuspendLayout()
        CType(Me.SSGRID_HALL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBARRANGEDETAILS.SuspendLayout()
        CType(Me.SSGRID_ARRANGE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBMENUDETAILS.SuspendLayout()
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRP_NVEG.SuspendLayout()
        CType(Me.SSGRID_NV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SSGRID_MENU1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBHALLBOOKING.SuspendLayout()
        CType(Me.SSGRID_BOOKING, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GRP_TARIFF.SuspendLayout()
        CType(Me.SSGRID_TARIFF, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_spousesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Spouse, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Sign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Member, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_POSCode.SuspendLayout()
        Me.pnl_UOMCode.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(174, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(319, 29)
        Me.Label3.TabIndex = 814
        Me.Label3.Text = "BANQUET FINAL  BILLING"
        '
        'grp_Tabledetails
        '
        Me.grp_Tabledetails.BackColor = System.Drawing.Color.Transparent
        Me.grp_Tabledetails.Controls.Add(Me.Label32)
        Me.grp_Tabledetails.Controls.Add(Me.Label33)
        Me.grp_Tabledetails.Controls.Add(Me.Cmd_BookingNo)
        Me.grp_Tabledetails.Controls.Add(Me.cmd_mcodehelp)
        Me.grp_Tabledetails.Controls.Add(Me.TXTGUESTNAME)
        Me.grp_Tabledetails.Controls.Add(Me.Label31)
        Me.grp_Tabledetails.Controls.Add(Me.BTN_MENU)
        Me.grp_Tabledetails.Controls.Add(Me.DTPRECEIPTDATE)
        Me.grp_Tabledetails.Controls.Add(Me.TxtVOCCUPANCY)
        Me.grp_Tabledetails.Controls.Add(Me.labbilling)
        Me.grp_Tabledetails.Controls.Add(Me.TxtNVOCCUPANCY)
        Me.grp_Tabledetails.Controls.Add(Me.TXTRECEIPTNO)
        Me.grp_Tabledetails.Controls.Add(Me.CMDDATEVALE)
        Me.grp_Tabledetails.Controls.Add(Me.DTPBOOKINGDATE)
        Me.grp_Tabledetails.Controls.Add(Me.TXTBOOKINGNO)
        Me.grp_Tabledetails.Controls.Add(Me.LABELDATE)
        Me.grp_Tabledetails.Controls.Add(Me.Label2)
        Me.grp_Tabledetails.Controls.Add(Me.Label10)
        Me.grp_Tabledetails.Controls.Add(Me.TXTMCODE)
        Me.grp_Tabledetails.Controls.Add(Me.TXTFROMTIME)
        Me.grp_Tabledetails.Controls.Add(Me.Label4)
        Me.grp_Tabledetails.Controls.Add(Me.DTPPARTYDATE)
        Me.grp_Tabledetails.Controls.Add(Me.Label5)
        Me.grp_Tabledetails.Controls.Add(Me.TXTMNAME)
        Me.grp_Tabledetails.Controls.Add(Me.Label7)
        Me.grp_Tabledetails.Controls.Add(Me.TXTTOTIME)
        Me.grp_Tabledetails.Controls.Add(Me.Label9)
        Me.grp_Tabledetails.Controls.Add(Me.TxtOCCUPANCY)
        Me.grp_Tabledetails.Controls.Add(Me.Label6)
        Me.grp_Tabledetails.Controls.Add(Me.TXTDESCRIPTION)
        Me.grp_Tabledetails.Controls.Add(Me.TXTADVANCE)
        Me.grp_Tabledetails.Controls.Add(Me.Label8)
        Me.grp_Tabledetails.Controls.Add(Me.Label17)
        Me.grp_Tabledetails.Controls.Add(Me.labbooking)
        Me.grp_Tabledetails.Controls.Add(Me.CMBTEMPDATE)
        Me.grp_Tabledetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp_Tabledetails.Location = New System.Drawing.Point(178, 100)
        Me.grp_Tabledetails.Name = "grp_Tabledetails"
        Me.grp_Tabledetails.Size = New System.Drawing.Size(662, 158)
        Me.grp_Tabledetails.TabIndex = 831
        Me.grp_Tabledetails.TabStop = False
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(5, 125)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(99, 23)
        Me.Label32.TabIndex = 866
        Me.Label32.Text = "NON.VEG PAXS"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(234, 130)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(63, 15)
        Me.Label33.TabIndex = 864
        Me.Label33.Text = "VEG PAXS"
        '
        'Cmd_BookingNo
        '
        Me.Cmd_BookingNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_BookingNo.Location = New System.Drawing.Point(173, 12)
        Me.Cmd_BookingNo.Name = "Cmd_BookingNo"
        Me.Cmd_BookingNo.Size = New System.Drawing.Size(40, 27)
        Me.Cmd_BookingNo.TabIndex = 861
        Me.Cmd_BookingNo.Text = "F4"
        Me.Cmd_BookingNo.UseVisualStyleBackColor = True
        '
        'cmd_mcodehelp
        '
        Me.cmd_mcodehelp.Location = New System.Drawing.Point(172, 42)
        Me.cmd_mcodehelp.Name = "cmd_mcodehelp"
        Me.cmd_mcodehelp.Size = New System.Drawing.Size(40, 26)
        Me.cmd_mcodehelp.TabIndex = 860
        Me.cmd_mcodehelp.Text = "?"
        Me.cmd_mcodehelp.UseVisualStyleBackColor = True
        Me.cmd_mcodehelp.Visible = False
        '
        'TXTGUESTNAME
        '
        Me.TXTGUESTNAME.BackColor = System.Drawing.Color.Wheat
        Me.TXTGUESTNAME.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGUESTNAME.Location = New System.Drawing.Point(314, 72)
        Me.TXTGUESTNAME.MaxLength = 50
        Me.TXTGUESTNAME.Multiline = True
        Me.TXTGUESTNAME.Name = "TXTGUESTNAME"
        Me.TXTGUESTNAME.ReadOnly = True
        Me.TXTGUESTNAME.Size = New System.Drawing.Size(290, 21)
        Me.TXTGUESTNAME.TabIndex = 6
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(217, 73)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(120, 25)
        Me.Label31.TabIndex = 858
        Me.Label31.Text = "GUEST NAME"
        '
        'BTN_MENU
        '
        Me.BTN_MENU.Image = CType(resources.GetObject("BTN_MENU.Image"), System.Drawing.Image)
        Me.BTN_MENU.Location = New System.Drawing.Point(173, 89)
        Me.BTN_MENU.Name = "BTN_MENU"
        Me.BTN_MENU.Size = New System.Drawing.Size(24, 35)
        Me.BTN_MENU.TabIndex = 856
        Me.BTN_MENU.Visible = False
        '
        'DTPRECEIPTDATE
        '
        Me.DTPRECEIPTDATE.CustomFormat = "dd/MM/yyyy"
        Me.DTPRECEIPTDATE.Enabled = False
        Me.DTPRECEIPTDATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPRECEIPTDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPRECEIPTDATE.Location = New System.Drawing.Point(880, 184)
        Me.DTPRECEIPTDATE.Name = "DTPRECEIPTDATE"
        Me.DTPRECEIPTDATE.Size = New System.Drawing.Size(16, 26)
        Me.DTPRECEIPTDATE.TabIndex = 855
        Me.DTPRECEIPTDATE.Value = New Date(2011, 9, 8, 18, 21, 52, 46)
        Me.DTPRECEIPTDATE.Visible = False
        '
        'TxtVOCCUPANCY
        '
        Me.TxtVOCCUPANCY.BackColor = System.Drawing.Color.Wheat
        Me.TxtVOCCUPANCY.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVOCCUPANCY.Location = New System.Drawing.Point(313, 125)
        Me.TxtVOCCUPANCY.MaxLength = 5
        Me.TxtVOCCUPANCY.Name = "TxtVOCCUPANCY"
        Me.TxtVOCCUPANCY.ReadOnly = True
        Me.TxtVOCCUPANCY.Size = New System.Drawing.Size(71, 22)
        Me.TxtVOCCUPANCY.TabIndex = 9
        Me.TxtVOCCUPANCY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'labbilling
        '
        Me.labbilling.AutoSize = True
        Me.labbilling.BackColor = System.Drawing.Color.Transparent
        Me.labbilling.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labbilling.Location = New System.Drawing.Point(387, -11)
        Me.labbilling.Name = "labbilling"
        Me.labbilling.Size = New System.Drawing.Size(74, 15)
        Me.labbilling.TabIndex = 839
        Me.labbilling.Text = "BILLING NO"
        Me.labbilling.Visible = False
        '
        'TxtNVOCCUPANCY
        '
        Me.TxtNVOCCUPANCY.BackColor = System.Drawing.Color.Wheat
        Me.TxtNVOCCUPANCY.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNVOCCUPANCY.Location = New System.Drawing.Point(103, 124)
        Me.TxtNVOCCUPANCY.MaxLength = 5
        Me.TxtNVOCCUPANCY.Name = "TxtNVOCCUPANCY"
        Me.TxtNVOCCUPANCY.ReadOnly = True
        Me.TxtNVOCCUPANCY.Size = New System.Drawing.Size(70, 22)
        Me.TxtNVOCCUPANCY.TabIndex = 8
        Me.TxtNVOCCUPANCY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTRECEIPTNO
        '
        Me.TXTRECEIPTNO.BackColor = System.Drawing.Color.Wheat
        Me.TXTRECEIPTNO.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXTRECEIPTNO.Location = New System.Drawing.Point(720, 184)
        Me.TXTRECEIPTNO.MaxLength = 25
        Me.TXTRECEIPTNO.Name = "TXTRECEIPTNO"
        Me.TXTRECEIPTNO.Size = New System.Drawing.Size(144, 27)
        Me.TXTRECEIPTNO.TabIndex = 12
        Me.TXTRECEIPTNO.Visible = False
        '
        'CMDDATEVALE
        '
        Me.CMDDATEVALE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CMDDATEVALE.Location = New System.Drawing.Point(856, 184)
        Me.CMDDATEVALE.Name = "CMDDATEVALE"
        Me.CMDDATEVALE.Size = New System.Drawing.Size(24, 24)
        Me.CMDDATEVALE.TabIndex = 13
        Me.CMDDATEVALE.Text = "C"
        Me.CMDDATEVALE.UseVisualStyleBackColor = False
        Me.CMDDATEVALE.Visible = False
        '
        'DTPBOOKINGDATE
        '
        Me.DTPBOOKINGDATE.CustomFormat = ""
        Me.DTPBOOKINGDATE.Enabled = False
        Me.DTPBOOKINGDATE.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPBOOKINGDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPBOOKINGDATE.Location = New System.Drawing.Point(314, 12)
        Me.DTPBOOKINGDATE.Name = "DTPBOOKINGDATE"
        Me.DTPBOOKINGDATE.Size = New System.Drawing.Size(102, 25)
        Me.DTPBOOKINGDATE.TabIndex = 2
        '
        'TXTBOOKINGNO
        '
        Me.TXTBOOKINGNO.BackColor = System.Drawing.Color.Wheat
        Me.TXTBOOKINGNO.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBOOKINGNO.Location = New System.Drawing.Point(103, 14)
        Me.TXTBOOKINGNO.MaxLength = 30
        Me.TXTBOOKINGNO.Multiline = True
        Me.TXTBOOKINGNO.Name = "TXTBOOKINGNO"
        Me.TXTBOOKINGNO.Size = New System.Drawing.Size(68, 23)
        Me.TXTBOOKINGNO.TabIndex = 1
        '
        'LABELDATE
        '
        Me.LABELDATE.AutoSize = True
        Me.LABELDATE.BackColor = System.Drawing.Color.Transparent
        Me.LABELDATE.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LABELDATE.Location = New System.Drawing.Point(217, 17)
        Me.LABELDATE.Name = "LABELDATE"
        Me.LABELDATE.Size = New System.Drawing.Size(95, 15)
        Me.LABELDATE.TabIndex = 389
        Me.LABELDATE.Text = "BOOKING DATE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(944, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 22)
        Me.Label2.TabIndex = 384
        Me.Label2.Text = "TO.TIME"
        Me.Label2.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(8, 120)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 22)
        Me.Label10.TabIndex = 382
        '
        'TXTMCODE
        '
        Me.TXTMCODE.BackColor = System.Drawing.Color.Wheat
        Me.TXTMCODE.Enabled = False
        Me.TXTMCODE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMCODE.Location = New System.Drawing.Point(103, 42)
        Me.TXTMCODE.MaxLength = 15
        Me.TXTMCODE.Multiline = True
        Me.TXTMCODE.Name = "TXTMCODE"
        Me.TXTMCODE.Size = New System.Drawing.Size(68, 21)
        Me.TXTMCODE.TabIndex = 4
        '
        'TXTFROMTIME
        '
        Me.TXTFROMTIME.BackColor = System.Drawing.Color.Wheat
        Me.TXTFROMTIME.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXTFROMTIME.Location = New System.Drawing.Point(1080, 24)
        Me.TXTFROMTIME.MaxLength = 5
        Me.TXTFROMTIME.Name = "TXTFROMTIME"
        Me.TXTFROMTIME.Size = New System.Drawing.Size(40, 27)
        Me.TXTFROMTIME.TabIndex = 5
        Me.TXTFROMTIME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTFROMTIME.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(422, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 15)
        Me.Label4.TabIndex = 361
        Me.Label4.Text = "PARTY  DATE"
        '
        'DTPPARTYDATE
        '
        Me.DTPPARTYDATE.CustomFormat = ""
        Me.DTPPARTYDATE.Enabled = False
        Me.DTPPARTYDATE.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPPARTYDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPPARTYDATE.Location = New System.Drawing.Point(510, 14)
        Me.DTPPARTYDATE.Name = "DTPPARTYDATE"
        Me.DTPPARTYDATE.Size = New System.Drawing.Size(118, 25)
        Me.DTPPARTYDATE.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 15)
        Me.Label5.TabIndex = 361
        Me.Label5.Text = "MEMBER CODE"
        '
        'TXTMNAME
        '
        Me.TXTMNAME.BackColor = System.Drawing.Color.Wheat
        Me.TXTMNAME.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTMNAME.Location = New System.Drawing.Point(314, 47)
        Me.TXTMNAME.MaxLength = 50
        Me.TXTMNAME.Multiline = True
        Me.TXTMNAME.Name = "TXTMNAME"
        Me.TXTMNAME.Size = New System.Drawing.Size(290, 23)
        Me.TXTMNAME.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(217, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 15)
        Me.Label7.TabIndex = 361
        Me.Label7.Text = "MEMBER NAME"
        '
        'TXTTOTIME
        '
        Me.TXTTOTIME.BackColor = System.Drawing.Color.Wheat
        Me.TXTTOTIME.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXTTOTIME.Location = New System.Drawing.Point(1040, 24)
        Me.TXTTOTIME.MaxLength = 5
        Me.TXTTOTIME.Name = "TXTTOTIME"
        Me.TXTTOTIME.Size = New System.Drawing.Size(40, 27)
        Me.TXTTOTIME.TabIndex = 6
        Me.TXTTOTIME.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTTOTIME.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(1120, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 21)
        Me.Label9.TabIndex = 371
        Me.Label9.Text = "FROM.TIME"
        Me.Label9.Visible = False
        '
        'TxtOCCUPANCY
        '
        Me.TxtOCCUPANCY.BackColor = System.Drawing.Color.Wheat
        Me.TxtOCCUPANCY.Enabled = False
        Me.TxtOCCUPANCY.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOCCUPANCY.Location = New System.Drawing.Point(103, 72)
        Me.TxtOCCUPANCY.MaxLength = 5
        Me.TxtOCCUPANCY.Multiline = True
        Me.TxtOCCUPANCY.Name = "TxtOCCUPANCY"
        Me.TxtOCCUPANCY.Size = New System.Drawing.Size(68, 21)
        Me.TxtOCCUPANCY.TabIndex = 9
        Me.TxtOCCUPANCY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 15)
        Me.Label6.TabIndex = 381
        Me.Label6.Text = "PAID AMOUNT"
        '
        'TXTDESCRIPTION
        '
        Me.TXTDESCRIPTION.BackColor = System.Drawing.Color.Wheat
        Me.TXTDESCRIPTION.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTDESCRIPTION.Location = New System.Drawing.Point(313, 97)
        Me.TXTDESCRIPTION.MaxLength = 50
        Me.TXTDESCRIPTION.Multiline = True
        Me.TXTDESCRIPTION.Name = "TXTDESCRIPTION"
        Me.TXTDESCRIPTION.ReadOnly = True
        Me.TXTDESCRIPTION.Size = New System.Drawing.Size(293, 23)
        Me.TXTDESCRIPTION.TabIndex = 7
        '
        'TXTADVANCE
        '
        Me.TXTADVANCE.BackColor = System.Drawing.Color.Wheat
        Me.TXTADVANCE.Enabled = False
        Me.TXTADVANCE.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTADVANCE.Location = New System.Drawing.Point(103, 97)
        Me.TXTADVANCE.MaxLength = 7
        Me.TXTADVANCE.Multiline = True
        Me.TXTADVANCE.Name = "TXTADVANCE"
        Me.TXTADVANCE.ReadOnly = True
        Me.TXTADVANCE.Size = New System.Drawing.Size(70, 22)
        Me.TXTADVANCE.TabIndex = 11
        Me.TXTADVANCE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(217, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 15)
        Me.Label8.TabIndex = 381
        Me.Label8.Text = "PURPOSE"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(1, 74)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 15)
        Me.Label17.TabIndex = 361
        Me.Label17.Text = "PAXS"
        '
        'labbooking
        '
        Me.labbooking.AutoSize = True
        Me.labbooking.BackColor = System.Drawing.Color.Transparent
        Me.labbooking.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labbooking.Location = New System.Drawing.Point(1, 13)
        Me.labbooking.Name = "labbooking"
        Me.labbooking.Size = New System.Drawing.Size(83, 15)
        Me.labbooking.TabIndex = 389
        Me.labbooking.Text = "BOOKING NO"
        '
        'CMBTEMPDATE
        '
        Me.CMBTEMPDATE.Enabled = False
        Me.CMBTEMPDATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBTEMPDATE.Location = New System.Drawing.Point(728, 184)
        Me.CMBTEMPDATE.Name = "CMBTEMPDATE"
        Me.CMBTEMPDATE.Size = New System.Drawing.Size(104, 24)
        Me.CMBTEMPDATE.TabIndex = 836
        Me.CMBTEMPDATE.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(512, 1)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 26)
        Me.Button3.TabIndex = 862
        Me.Button3.Text = "?"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'TXT_MENU
        '
        Me.TXT_MENU.BackColor = System.Drawing.Color.Wheat
        Me.TXT_MENU.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXT_MENU.Location = New System.Drawing.Point(437, 2)
        Me.TXT_MENU.MaxLength = 50
        Me.TXT_MENU.Multiline = True
        Me.TXT_MENU.Name = "TXT_MENU"
        Me.TXT_MENU.ReadOnly = True
        Me.TXT_MENU.Size = New System.Drawing.Size(72, 24)
        Me.TXT_MENU.TabIndex = 857
        Me.TXT_MENU.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(334, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 854
        Me.Label1.Text = "MENU CODE"
        Me.Label1.Visible = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(613, 43)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(201, 19)
        Me.lbl_Freeze.TabIndex = 834
        Me.lbl_Freeze.Text = "BILLING  IS CANCELLED"
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'lbl_bookday
        '
        Me.lbl_bookday.AutoSize = True
        Me.lbl_bookday.BackColor = System.Drawing.Color.Transparent
        Me.lbl_bookday.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_bookday.Location = New System.Drawing.Point(469, 82)
        Me.lbl_bookday.Name = "lbl_bookday"
        Me.lbl_bookday.Size = New System.Drawing.Size(65, 15)
        Me.lbl_bookday.TabIndex = 847
        Me.lbl_bookday.Text = "DAY NAME"
        Me.lbl_bookday.Visible = False
        '
        'LBL_PARTYDAY
        '
        Me.LBL_PARTYDAY.AutoSize = True
        Me.LBL_PARTYDAY.BackColor = System.Drawing.Color.Transparent
        Me.LBL_PARTYDAY.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_PARTYDAY.Location = New System.Drawing.Point(573, 74)
        Me.LBL_PARTYDAY.Name = "LBL_PARTYDAY"
        Me.LBL_PARTYDAY.Size = New System.Drawing.Size(65, 15)
        Me.LBL_PARTYDAY.TabIndex = 846
        Me.LBL_PARTYDAY.Text = "DAY NAME"
        Me.LBL_PARTYDAY.Visible = False
        '
        'CMD_BILLINGNO
        '
        Me.CMD_BILLINGNO.Image = CType(resources.GetObject("CMD_BILLINGNO.Image"), System.Drawing.Image)
        Me.CMD_BILLINGNO.Location = New System.Drawing.Point(820, 72)
        Me.CMD_BILLINGNO.Name = "CMD_BILLINGNO"
        Me.CMD_BILLINGNO.Size = New System.Drawing.Size(24, 26)
        Me.CMD_BILLINGNO.TabIndex = 838
        '
        'TXTBILLINGNO
        '
        Me.TXTBILLINGNO.BackColor = System.Drawing.Color.Wheat
        Me.TXTBILLINGNO.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBILLINGNO.Location = New System.Drawing.Point(636, 73)
        Me.TXTBILLINGNO.MaxLength = 30
        Me.TXTBILLINGNO.Name = "TXTBILLINGNO"
        Me.TXTBILLINGNO.ReadOnly = True
        Me.TXTBILLINGNO.Size = New System.Drawing.Size(180, 22)
        Me.TXTBILLINGNO.TabIndex = 837
        Me.TXTBILLINGNO.Visible = False
        Me.TXTBILLINGNO.WordWrap = False
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(105, 18)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(95, 15)
        Me.Label36.TabIndex = 388
        Me.Label36.Text = "BOOKING TYPE"
        Me.Label36.Visible = False
        '
        'CMBBOOKINGTYPE
        '
        Me.CMBBOOKINGTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBBOOKINGTYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBBOOKINGTYPE.Items.AddRange(New Object() {"BILLING"})
        Me.CMBBOOKINGTYPE.Location = New System.Drawing.Point(204, 16)
        Me.CMBBOOKINGTYPE.MaxDropDownItems = 1
        Me.CMBBOOKINGTYPE.Name = "CMBBOOKINGTYPE"
        Me.CMBBOOKINGTYPE.Size = New System.Drawing.Size(113, 28)
        Me.CMBBOOKINGTYPE.TabIndex = 1
        Me.CMBBOOKINGTYPE.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(952, 40)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 21)
        Me.Label13.TabIndex = 852
        Me.Label13.Text = "VEG PAXS"
        Me.Label13.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(72, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 22)
        Me.Label15.TabIndex = 396
        Me.Label15.Text = "RECEIPT NO"
        Me.Label15.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(216, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 22)
        Me.Label11.TabIndex = 394
        Me.Label11.Text = "REC DATE"
        Me.Label11.Visible = False
        '
        'TXTASSOCIATENAME
        '
        Me.TXTASSOCIATENAME.BackColor = System.Drawing.Color.Wheat
        Me.TXTASSOCIATENAME.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXTASSOCIATENAME.Location = New System.Drawing.Point(184, -48)
        Me.TXTASSOCIATENAME.MaxLength = 25
        Me.TXTASSOCIATENAME.Name = "TXTASSOCIATENAME"
        Me.TXTASSOCIATENAME.Size = New System.Drawing.Size(16, 27)
        Me.TXTASSOCIATENAME.TabIndex = 5
        Me.TXTASSOCIATENAME.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(24, -32)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(54, 21)
        Me.Label19.TabIndex = 837
        Me.Label19.Text = "ASSO"
        Me.Label19.Visible = False
        '
        'GBHALLFACILITY
        '
        Me.GBHALLFACILITY.BackColor = System.Drawing.Color.Transparent
        Me.GBHALLFACILITY.Controls.Add(Me.Label21)
        Me.GBHALLFACILITY.Controls.Add(Me.TXTHALLCANCELAMT)
        Me.GBHALLFACILITY.Controls.Add(Me.Label97)
        Me.GBHALLFACILITY.Controls.Add(Me.SSGRID_HALL)
        Me.GBHALLFACILITY.Controls.Add(Me.cmdreport1)
        Me.GBHALLFACILITY.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBHALLFACILITY.ForeColor = System.Drawing.Color.Blue
        Me.GBHALLFACILITY.Location = New System.Drawing.Point(32, 600)
        Me.GBHALLFACILITY.Name = "GBHALLFACILITY"
        Me.GBHALLFACILITY.Size = New System.Drawing.Size(8, 8)
        Me.GBHALLFACILITY.TabIndex = 832
        Me.GBHALLFACILITY.TabStop = False
        Me.GBHALLFACILITY.Text = "Hall Facility"
        Me.GBHALLFACILITY.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(648, 200)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(153, 21)
        Me.Label21.TabIndex = 404
        Me.Label21.Text = "CANCEL AMOUNT"
        Me.Label21.Visible = False
        '
        'TXTHALLCANCELAMT
        '
        Me.TXTHALLCANCELAMT.BackColor = System.Drawing.Color.Wheat
        Me.TXTHALLCANCELAMT.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXTHALLCANCELAMT.Location = New System.Drawing.Point(802, 200)
        Me.TXTHALLCANCELAMT.MaxLength = 12
        Me.TXTHALLCANCELAMT.Name = "TXTHALLCANCELAMT"
        Me.TXTHALLCANCELAMT.ReadOnly = True
        Me.TXTHALLCANCELAMT.Size = New System.Drawing.Size(96, 27)
        Me.TXTHALLCANCELAMT.TabIndex = 403
        Me.TXTHALLCANCELAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTHALLCANCELAMT.Visible = False
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.BackColor = System.Drawing.Color.Transparent
        Me.Label97.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label97.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label97.Location = New System.Drawing.Point(0, -24)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(109, 18)
        Me.Label97.TabIndex = 392
        Me.Label97.Text = "HALL FACILITY"
        Me.Label97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SSGRID_HALL
        '
        Me.SSGRID_HALL.DataSource = Nothing
        Me.SSGRID_HALL.Location = New System.Drawing.Point(8, 24)
        Me.SSGRID_HALL.Name = "SSGRID_HALL"
        Me.SSGRID_HALL.OcxState = CType(resources.GetObject("SSGRID_HALL.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID_HALL.Size = New System.Drawing.Size(904, 169)
        Me.SSGRID_HALL.TabIndex = 21
        Me.SSGRID_HALL.Visible = False
        '
        'cmdreport1
        '
        Me.cmdreport1.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdreport1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdreport1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport1.ForeColor = System.Drawing.Color.White
        Me.cmdreport1.Image = CType(resources.GetObject("cmdreport1.Image"), System.Drawing.Image)
        Me.cmdreport1.Location = New System.Drawing.Point(8, -8)
        Me.cmdreport1.Name = "cmdreport1"
        Me.cmdreport1.Size = New System.Drawing.Size(8, 32)
        Me.cmdreport1.TabIndex = 28
        Me.cmdreport1.Text = "Report[CI]"
        Me.cmdreport1.UseVisualStyleBackColor = False
        Me.cmdreport1.Visible = False
        '
        'CHBHALLTAX
        '
        Me.CHBHALLTAX.BackColor = System.Drawing.Color.Transparent
        Me.CHBHALLTAX.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.CHBHALLTAX.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CHBHALLTAX.Location = New System.Drawing.Point(640, 264)
        Me.CHBHALLTAX.Name = "CHBHALLTAX"
        Me.CHBHALLTAX.Size = New System.Drawing.Size(64, 24)
        Me.CHBHALLTAX.TabIndex = 19
        Me.CHBHALLTAX.Text = "TAX "
        Me.CHBHALLTAX.UseVisualStyleBackColor = False
        Me.CHBHALLTAX.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(944, 112)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(109, 21)
        Me.Label14.TabIndex = 402
        Me.Label14.Text = "HALL RENT"
        Me.Label14.Visible = False
        '
        'TXTHALLRENT
        '
        Me.TXTHALLRENT.BackColor = System.Drawing.Color.Wheat
        Me.TXTHALLRENT.Enabled = False
        Me.TXTHALLRENT.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXTHALLRENT.Location = New System.Drawing.Point(1008, 96)
        Me.TXTHALLRENT.MaxLength = 12
        Me.TXTHALLRENT.Name = "TXTHALLRENT"
        Me.TXTHALLRENT.Size = New System.Drawing.Size(96, 27)
        Me.TXTHALLRENT.TabIndex = 20
        Me.TXTHALLRENT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTHALLRENT.Visible = False
        '
        'cmdhallHelp
        '
        Me.cmdhallHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdhallHelp.Image = CType(resources.GetObject("cmdhallHelp.Image"), System.Drawing.Image)
        Me.cmdhallHelp.Location = New System.Drawing.Point(40, 219)
        Me.cmdhallHelp.Name = "cmdhallHelp"
        Me.cmdhallHelp.Size = New System.Drawing.Size(23, 25)
        Me.cmdhallHelp.TabIndex = 18
        Me.cmdhallHelp.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(24, -48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 21)
        Me.Label12.TabIndex = 398
        Me.Label12.Text = "HALL CODE"
        Me.Label12.Visible = False
        '
        'txtHALLDESCRIPTION
        '
        Me.txtHALLDESCRIPTION.BackColor = System.Drawing.Color.Wheat
        Me.txtHALLDESCRIPTION.Enabled = False
        Me.txtHALLDESCRIPTION.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.txtHALLDESCRIPTION.Location = New System.Drawing.Point(88, -48)
        Me.txtHALLDESCRIPTION.MaxLength = 50
        Me.txtHALLDESCRIPTION.Name = "txtHALLDESCRIPTION"
        Me.txtHALLDESCRIPTION.ReadOnly = True
        Me.txtHALLDESCRIPTION.Size = New System.Drawing.Size(240, 27)
        Me.txtHALLDESCRIPTION.TabIndex = 19
        Me.txtHALLDESCRIPTION.Visible = False
        '
        'TXTHALLCODE
        '
        Me.TXTHALLCODE.BackColor = System.Drawing.Color.Wheat
        Me.TXTHALLCODE.Enabled = False
        Me.TXTHALLCODE.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXTHALLCODE.Location = New System.Drawing.Point(136, -48)
        Me.TXTHALLCODE.MaxLength = 15
        Me.TXTHALLCODE.Name = "TXTHALLCODE"
        Me.TXTHALLCODE.ReadOnly = True
        Me.TXTHALLCODE.Size = New System.Drawing.Size(104, 27)
        Me.TXTHALLCODE.TabIndex = 17
        Me.TXTHALLCODE.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cmd_print)
        Me.GroupBox1.Controls.Add(Me.Cmd_Clear2)
        Me.GroupBox1.Controls.Add(Me.Cmd_Add1)
        Me.GroupBox1.Controls.Add(Me.Cmd_report22)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Location = New System.Drawing.Point(76, 669)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(677, 56)
        Me.GroupBox1.TabIndex = 833
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'cmd_print
        '
        Me.cmd_print.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_print.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_print.ForeColor = System.Drawing.Color.White
        Me.cmd_print.Image = CType(resources.GetObject("cmd_print.Image"), System.Drawing.Image)
        Me.cmd_print.Location = New System.Drawing.Point(368, 16)
        Me.cmd_print.Name = "cmd_print"
        Me.cmd_print.Size = New System.Drawing.Size(104, 32)
        Me.cmd_print.TabIndex = 29
        Me.cmd_print.Text = "Print[F10]"
        Me.cmd_print.UseVisualStyleBackColor = False
        '
        'Cmd_Clear2
        '
        Me.Cmd_Clear2.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Clear2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear2.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear2.Image = CType(resources.GetObject("Cmd_Clear2.Image"), System.Drawing.Image)
        Me.Cmd_Clear2.Location = New System.Drawing.Point(72, 16)
        Me.Cmd_Clear2.Name = "Cmd_Clear2"
        Me.Cmd_Clear2.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear2.TabIndex = 25
        Me.Cmd_Clear2.Text = "Clear[F6]"
        Me.Cmd_Clear2.UseVisualStyleBackColor = False
        '
        'Cmd_Add1
        '
        Me.Cmd_Add1.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add1.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add1.Image = CType(resources.GetObject("Cmd_Add1.Image"), System.Drawing.Image)
        Me.Cmd_Add1.Location = New System.Drawing.Point(216, 16)
        Me.Cmd_Add1.Name = "Cmd_Add1"
        Me.Cmd_Add1.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add1.TabIndex = 24
        Me.Cmd_Add1.Text = "Add [F7]"
        Me.Cmd_Add1.UseVisualStyleBackColor = False
        '
        'Cmd_report22
        '
        Me.Cmd_report22.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_report22.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_report22.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_report22.ForeColor = System.Drawing.Color.White
        Me.Cmd_report22.Image = CType(resources.GetObject("Cmd_report22.Image"), System.Drawing.Image)
        Me.Cmd_report22.Location = New System.Drawing.Point(528, 16)
        Me.Cmd_report22.Name = "Cmd_report22"
        Me.Cmd_report22.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_report22.TabIndex = 28
        Me.Cmd_report22.Text = "View[F12]"
        Me.Cmd_report22.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(-4, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 32)
        Me.Button1.TabIndex = 855
        Me.Button1.Text = "Settlement"
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(248, -3)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(384, 16)
        Me.Label20.TabIndex = 838
        Me.Label20.Text = "Press F4 for HELP / Press ENTER key to navigate"
        Me.Label20.Visible = False
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(12, 393)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(105, 32)
        Me.Cmd_View.TabIndex = 27
        Me.Cmd_View.Text = " View[F9]"
        Me.Cmd_View.UseVisualStyleBackColor = False
        Me.Cmd_View.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.RDO_nv_TARIFF)
        Me.GroupBox2.Controls.Add(Me.RDO_TARIFF)
        Me.GroupBox2.Controls.Add(Me.rdo_halldisplay)
        Me.GroupBox2.Controls.Add(Me.RDBARRITEM)
        Me.GroupBox2.Controls.Add(Me.RDBRESMENU)
        Me.GroupBox2.Controls.Add(Me.RDBHALLFACILITY)
        Me.GroupBox2.Controls.Add(Me.bookingstatus)
        Me.GroupBox2.Location = New System.Drawing.Point(220, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(332, 56)
        Me.GroupBox2.TabIndex = 833
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'RDO_nv_TARIFF
        '
        Me.RDO_nv_TARIFF.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.RDO_nv_TARIFF.Location = New System.Drawing.Point(280, 24)
        Me.RDO_nv_TARIFF.Name = "RDO_nv_TARIFF"
        Me.RDO_nv_TARIFF.Size = New System.Drawing.Size(88, 24)
        Me.RDO_nv_TARIFF.TabIndex = 845
        Me.RDO_nv_TARIFF.Text = "N VEG TARIFF"
        Me.RDO_nv_TARIFF.Visible = False
        '
        'RDO_TARIFF
        '
        Me.RDO_TARIFF.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.RDO_TARIFF.Location = New System.Drawing.Point(804, 23)
        Me.RDO_TARIFF.Name = "RDO_TARIFF"
        Me.RDO_TARIFF.Size = New System.Drawing.Size(110, 24)
        Me.RDO_TARIFF.TabIndex = 844
        Me.RDO_TARIFF.Text = "TARIFF"
        Me.RDO_TARIFF.Visible = False
        '
        'rdo_halldisplay
        '
        Me.rdo_halldisplay.Checked = True
        Me.rdo_halldisplay.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.rdo_halldisplay.Location = New System.Drawing.Point(104, 24)
        Me.rdo_halldisplay.Name = "rdo_halldisplay"
        Me.rdo_halldisplay.Size = New System.Drawing.Size(160, 24)
        Me.rdo_halldisplay.TabIndex = 840
        Me.rdo_halldisplay.TabStop = True
        Me.rdo_halldisplay.Text = "HALL DISPLAY"
        '
        'RDBARRITEM
        '
        Me.RDBARRITEM.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.RDBARRITEM.Location = New System.Drawing.Point(632, 25)
        Me.RDBARRITEM.Name = "RDBARRITEM"
        Me.RDBARRITEM.Size = New System.Drawing.Size(156, 24)
        Me.RDBARRITEM.TabIndex = 835
        Me.RDBARRITEM.Text = "ARRANGEMENT ITEM"
        '
        'RDBRESMENU
        '
        Me.RDBRESMENU.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.RDBRESMENU.Location = New System.Drawing.Point(412, 23)
        Me.RDBRESMENU.Name = "RDBRESMENU"
        Me.RDBRESMENU.Size = New System.Drawing.Size(208, 24)
        Me.RDBRESMENU.TabIndex = 835
        Me.RDBRESMENU.Text = "MENU SELECTION"
        '
        'RDBHALLFACILITY
        '
        Me.RDBHALLFACILITY.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.RDBHALLFACILITY.Location = New System.Drawing.Point(896, 24)
        Me.RDBHALLFACILITY.Name = "RDBHALLFACILITY"
        Me.RDBHALLFACILITY.Size = New System.Drawing.Size(32, 24)
        Me.RDBHALLFACILITY.TabIndex = 835
        Me.RDBHALLFACILITY.Text = "HALL FACILITY"
        Me.RDBHALLFACILITY.Visible = False
        '
        'bookingstatus
        '
        Me.bookingstatus.AutoSize = True
        Me.bookingstatus.BackColor = System.Drawing.Color.Transparent
        Me.bookingstatus.Font = New System.Drawing.Font("Times New Roman", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bookingstatus.ForeColor = System.Drawing.Color.Red
        Me.bookingstatus.Location = New System.Drawing.Point(256, 29)
        Me.bookingstatus.Name = "bookingstatus"
        Me.bookingstatus.Size = New System.Drawing.Size(0, 13)
        Me.bookingstatus.TabIndex = 834
        Me.bookingstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.bookingstatus.Visible = False
        '
        'LABBOOKINGSTATUS
        '
        Me.LABBOOKINGSTATUS.AutoSize = True
        Me.LABBOOKINGSTATUS.BackColor = System.Drawing.Color.Transparent
        Me.LABBOOKINGSTATUS.Font = New System.Drawing.Font("Courier New", 14.0!, System.Drawing.FontStyle.Bold)
        Me.LABBOOKINGSTATUS.ForeColor = System.Drawing.Color.Red
        Me.LABBOOKINGSTATUS.Location = New System.Drawing.Point(48, 272)
        Me.LABBOOKINGSTATUS.Name = "LABBOOKINGSTATUS"
        Me.LABBOOKINGSTATUS.Size = New System.Drawing.Size(0, 22)
        Me.LABBOOKINGSTATUS.TabIndex = 835
        '
        'GBARRANGEDETAILS
        '
        Me.GBARRANGEDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.GBARRANGEDETAILS.Controls.Add(Me.SSGRID_ARRANGE)
        Me.GBARRANGEDETAILS.Controls.Add(Me.TXTARRCANCELAMT)
        Me.GBARRANGEDETAILS.Controls.Add(Me.Label16)
        Me.GBARRANGEDETAILS.Controls.Add(Me.TXTARRTOTALAMOUNT)
        Me.GBARRANGEDETAILS.Controls.Add(Me.TXTARRTAXAMOUNT)
        Me.GBARRANGEDETAILS.Controls.Add(Me.TXTARRAMOUNT)
        Me.GBARRANGEDETAILS.Controls.Add(Me.TextBox1)
        Me.GBARRANGEDETAILS.Controls.Add(Me.TextBox2)
        Me.GBARRANGEDETAILS.Controls.Add(Me.TextBox3)
        Me.GBARRANGEDETAILS.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBARRANGEDETAILS.ForeColor = System.Drawing.Color.Black
        Me.GBARRANGEDETAILS.Location = New System.Drawing.Point(178, 329)
        Me.GBARRANGEDETAILS.Name = "GBARRANGEDETAILS"
        Me.GBARRANGEDETAILS.Size = New System.Drawing.Size(664, 334)
        Me.GBARRANGEDETAILS.TabIndex = 836
        Me.GBARRANGEDETAILS.TabStop = False
        Me.GBARRANGEDETAILS.Text = "Arrangement"
        '
        'SSGRID_ARRANGE
        '
        Me.SSGRID_ARRANGE.DataSource = Nothing
        Me.SSGRID_ARRANGE.Location = New System.Drawing.Point(6, 20)
        Me.SSGRID_ARRANGE.Name = "SSGRID_ARRANGE"
        Me.SSGRID_ARRANGE.OcxState = CType(resources.GetObject("SSGRID_ARRANGE.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID_ARRANGE.Size = New System.Drawing.Size(650, 306)
        Me.SSGRID_ARRANGE.TabIndex = 15
        '
        'TXTARRCANCELAMT
        '
        Me.TXTARRCANCELAMT.BackColor = System.Drawing.Color.Wheat
        Me.TXTARRCANCELAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTARRCANCELAMT.Location = New System.Drawing.Point(392, 200)
        Me.TXTARRCANCELAMT.MaxLength = 9
        Me.TXTARRCANCELAMT.Name = "TXTARRCANCELAMT"
        Me.TXTARRCANCELAMT.ReadOnly = True
        Me.TXTARRCANCELAMT.Size = New System.Drawing.Size(88, 24)
        Me.TXTARRCANCELAMT.TabIndex = 815
        Me.TXTARRCANCELAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTARRCANCELAMT.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(760, 240)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 22)
        Me.Label16.TabIndex = 814
        Me.Label16.Text = "AMOUNT"
        '
        'TXTARRTOTALAMOUNT
        '
        Me.TXTARRTOTALAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTARRTOTALAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTARRTOTALAMOUNT.Location = New System.Drawing.Point(848, 240)
        Me.TXTARRTOTALAMOUNT.MaxLength = 9
        Me.TXTARRTOTALAMOUNT.Name = "TXTARRTOTALAMOUNT"
        Me.TXTARRTOTALAMOUNT.ReadOnly = True
        Me.TXTARRTOTALAMOUNT.Size = New System.Drawing.Size(96, 24)
        Me.TXTARRTOTALAMOUNT.TabIndex = 813
        Me.TXTARRTOTALAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTARRTAXAMOUNT
        '
        Me.TXTARRTAXAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTARRTAXAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTARRTAXAMOUNT.Location = New System.Drawing.Point(512, 206)
        Me.TXTARRTAXAMOUNT.MaxLength = 9
        Me.TXTARRTAXAMOUNT.Name = "TXTARRTAXAMOUNT"
        Me.TXTARRTAXAMOUNT.ReadOnly = True
        Me.TXTARRTAXAMOUNT.Size = New System.Drawing.Size(96, 24)
        Me.TXTARRTAXAMOUNT.TabIndex = 811
        Me.TXTARRTAXAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTARRTAXAMOUNT.Visible = False
        '
        'TXTARRAMOUNT
        '
        Me.TXTARRAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTARRAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTARRAMOUNT.Location = New System.Drawing.Point(624, 206)
        Me.TXTARRAMOUNT.MaxLength = 9
        Me.TXTARRAMOUNT.Name = "TXTARRAMOUNT"
        Me.TXTARRAMOUNT.ReadOnly = True
        Me.TXTARRAMOUNT.Size = New System.Drawing.Size(88, 24)
        Me.TXTARRAMOUNT.TabIndex = 812
        Me.TXTARRAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTARRAMOUNT.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.Wheat
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(512, 208)
        Me.TextBox1.MaxLength = 9
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(96, 24)
        Me.TextBox1.TabIndex = 811
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.Color.Wheat
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(624, 208)
        Me.TextBox2.MaxLength = 9
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(88, 24)
        Me.TextBox2.TabIndex = 812
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox2.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.Wheat
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(392, 200)
        Me.TextBox3.MaxLength = 9
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(88, 24)
        Me.TextBox3.TabIndex = 815
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TextBox3.Visible = False
        '
        'GBMENUDETAILS
        '
        Me.GBMENUDETAILS.BackColor = System.Drawing.Color.Transparent
        Me.GBMENUDETAILS.Controls.Add(Me.SSGRID)
        Me.GBMENUDETAILS.Controls.Add(Me.TXTRESCANCELAMT)
        Me.GBMENUDETAILS.Controls.Add(Me.Label18)
        Me.GBMENUDETAILS.Controls.Add(Me.TXTRESTOTALAMOUNT)
        Me.GBMENUDETAILS.Controls.Add(Me.TXTRESTAXAMOUNT)
        Me.GBMENUDETAILS.Controls.Add(Me.TXTRESAMOUNT)
        Me.GBMENUDETAILS.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBMENUDETAILS.ForeColor = System.Drawing.Color.Black
        Me.GBMENUDETAILS.Location = New System.Drawing.Point(182, 332)
        Me.GBMENUDETAILS.Name = "GBMENUDETAILS"
        Me.GBMENUDETAILS.Size = New System.Drawing.Size(664, 220)
        Me.GBMENUDETAILS.TabIndex = 837
        Me.GBMENUDETAILS.TabStop = False
        Me.GBMENUDETAILS.Text = "Restaurant Menu"
        Me.GBMENUDETAILS.Visible = False
        '
        'SSGRID
        '
        Me.SSGRID.DataSource = Nothing
        Me.SSGRID.Location = New System.Drawing.Point(5, 18)
        Me.SSGRID.Name = "SSGRID"
        Me.SSGRID.OcxState = CType(resources.GetObject("SSGRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID.Size = New System.Drawing.Size(654, 304)
        Me.SSGRID.TabIndex = 817
        '
        'TXTRESCANCELAMT
        '
        Me.TXTRESCANCELAMT.BackColor = System.Drawing.Color.Wheat
        Me.TXTRESCANCELAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRESCANCELAMT.Location = New System.Drawing.Point(400, 256)
        Me.TXTRESCANCELAMT.MaxLength = 9
        Me.TXTRESCANCELAMT.Name = "TXTRESCANCELAMT"
        Me.TXTRESCANCELAMT.ReadOnly = True
        Me.TXTRESCANCELAMT.Size = New System.Drawing.Size(96, 24)
        Me.TXTRESCANCELAMT.TabIndex = 811
        Me.TXTRESCANCELAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTRESCANCELAMT.Visible = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(776, 256)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 22)
        Me.Label18.TabIndex = 810
        Me.Label18.Text = "AMOUNT"
        '
        'TXTRESTOTALAMOUNT
        '
        Me.TXTRESTOTALAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTRESTOTALAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRESTOTALAMOUNT.Location = New System.Drawing.Point(856, 256)
        Me.TXTRESTOTALAMOUNT.MaxLength = 9
        Me.TXTRESTOTALAMOUNT.Name = "TXTRESTOTALAMOUNT"
        Me.TXTRESTOTALAMOUNT.ReadOnly = True
        Me.TXTRESTOTALAMOUNT.Size = New System.Drawing.Size(104, 24)
        Me.TXTRESTOTALAMOUNT.TabIndex = 23
        Me.TXTRESTOTALAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTRESTAXAMOUNT
        '
        Me.TXTRESTAXAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTRESTAXAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRESTAXAMOUNT.Location = New System.Drawing.Point(506, 240)
        Me.TXTRESTAXAMOUNT.MaxLength = 9
        Me.TXTRESTAXAMOUNT.Name = "TXTRESTAXAMOUNT"
        Me.TXTRESTAXAMOUNT.ReadOnly = True
        Me.TXTRESTAXAMOUNT.Size = New System.Drawing.Size(94, 24)
        Me.TXTRESTAXAMOUNT.TabIndex = 23
        Me.TXTRESTAXAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTRESTAXAMOUNT.Visible = False
        '
        'TXTRESAMOUNT
        '
        Me.TXTRESAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTRESAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRESAMOUNT.Location = New System.Drawing.Point(600, 240)
        Me.TXTRESAMOUNT.MaxLength = 9
        Me.TXTRESAMOUNT.Name = "TXTRESAMOUNT"
        Me.TXTRESAMOUNT.ReadOnly = True
        Me.TXTRESAMOUNT.Size = New System.Drawing.Size(88, 24)
        Me.TXTRESAMOUNT.TabIndex = 23
        Me.TXTRESAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TXTRESAMOUNT.Visible = False
        '
        'GRP_NVEG
        '
        Me.GRP_NVEG.BackColor = System.Drawing.Color.Transparent
        Me.GRP_NVEG.Controls.Add(Me.SSGRID_NV)
        Me.GRP_NVEG.Controls.Add(Me.Label22)
        Me.GRP_NVEG.Controls.Add(Me.TXT_NVMAX)
        Me.GRP_NVEG.Controls.Add(Me.Label23)
        Me.GRP_NVEG.Controls.Add(Me.TXT_NVDESC)
        Me.GRP_NVEG.Controls.Add(Me.Label26)
        Me.GRP_NVEG.Controls.Add(Me.NVHELP)
        Me.GRP_NVEG.Controls.Add(Me.TextNVTBOX)
        Me.GRP_NVEG.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRP_NVEG.ForeColor = System.Drawing.Color.Black
        Me.GRP_NVEG.Location = New System.Drawing.Point(181, 329)
        Me.GRP_NVEG.Name = "GRP_NVEG"
        Me.GRP_NVEG.Size = New System.Drawing.Size(664, 332)
        Me.GRP_NVEG.TabIndex = 854
        Me.GRP_NVEG.TabStop = False
        Me.GRP_NVEG.Text = "MENU NVEG  ITEM MASTER"
        '
        'SSGRID_NV
        '
        Me.SSGRID_NV.DataSource = Nothing
        Me.SSGRID_NV.Location = New System.Drawing.Point(8, 64)
        Me.SSGRID_NV.Name = "SSGRID_NV"
        Me.SSGRID_NV.OcxState = CType(resources.GetObject("SSGRID_NV.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID_NV.Size = New System.Drawing.Size(650, 257)
        Me.SSGRID_NV.TabIndex = 813
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(304, 224)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(109, 21)
        Me.Label22.TabIndex = 820
        Me.Label22.Text = "OCCUPANCY"
        '
        'TXT_NVMAX
        '
        Me.TXT_NVMAX.BackColor = System.Drawing.Color.Wheat
        Me.TXT_NVMAX.Enabled = False
        Me.TXT_NVMAX.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXT_NVMAX.Location = New System.Drawing.Point(541, 18)
        Me.TXT_NVMAX.MaxLength = 15
        Me.TXT_NVMAX.Name = "TXT_NVMAX"
        Me.TXT_NVMAX.Size = New System.Drawing.Size(104, 27)
        Me.TXT_NVMAX.TabIndex = 819
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(436, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(73, 16)
        Me.Label23.TabIndex = 818
        Me.Label23.Text = "Max Items"
        '
        'TXT_NVDESC
        '
        Me.TXT_NVDESC.BackColor = System.Drawing.Color.Wheat
        Me.TXT_NVDESC.Enabled = False
        Me.TXT_NVDESC.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXT_NVDESC.Location = New System.Drawing.Point(219, 19)
        Me.TXT_NVDESC.MaxLength = 50
        Me.TXT_NVDESC.Name = "TXT_NVDESC"
        Me.TXT_NVDESC.Size = New System.Drawing.Size(205, 27)
        Me.TXT_NVDESC.TabIndex = 817
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(9, 28)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(53, 16)
        Me.Label26.TabIndex = 816
        Me.Label26.Text = "TARIFF"
        '
        'NVHELP
        '
        Me.NVHELP.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.NVHELP.Location = New System.Drawing.Point(173, 19)
        Me.NVHELP.Name = "NVHELP"
        Me.NVHELP.Size = New System.Drawing.Size(24, 32)
        Me.NVHELP.TabIndex = 815
        Me.NVHELP.Text = "?"
        '
        'TextNVTBOX
        '
        Me.TextNVTBOX.BackColor = System.Drawing.Color.Wheat
        Me.TextNVTBOX.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TextNVTBOX.Location = New System.Drawing.Point(96, 24)
        Me.TextNVTBOX.MaxLength = 15
        Me.TextNVTBOX.Name = "TextNVTBOX"
        Me.TextNVTBOX.Size = New System.Drawing.Size(72, 27)
        Me.TextNVTBOX.TabIndex = 814
        '
        'SSGRID_MENU1
        '
        Me.SSGRID_MENU1.DataSource = Nothing
        Me.SSGRID_MENU1.Location = New System.Drawing.Point(8, 40)
        Me.SSGRID_MENU1.Name = "SSGRID_MENU1"
        Me.SSGRID_MENU1.OcxState = CType(resources.GetObject("SSGRID_MENU1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID_MENU1.Size = New System.Drawing.Size(960, 184)
        Me.SSGRID_MENU1.TabIndex = 22
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze.Enabled = False
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.Location = New System.Drawing.Point(12, 354)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(105, 32)
        Me.Cmd_Freeze.TabIndex = 839
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.UseVisualStyleBackColor = False
        Me.Cmd_Freeze.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.Red
        Me.Label24.Location = New System.Drawing.Point(8, 264)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(0, 19)
        Me.Label24.TabIndex = 840
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label24.Visible = False
        '
        'chbreceipt
        '
        Me.chbreceipt.BackColor = System.Drawing.Color.Transparent
        Me.chbreceipt.Location = New System.Drawing.Point(848, 656)
        Me.chbreceipt.Name = "chbreceipt"
        Me.chbreceipt.Size = New System.Drawing.Size(168, 24)
        Me.chbreceipt.TabIndex = 842
        Me.chbreceipt.Text = "PAYMENT ENTRY"
        Me.chbreceipt.UseVisualStyleBackColor = False
        Me.chbreceipt.Visible = False
        '
        'GBHALLBOOKING
        '
        Me.GBHALLBOOKING.BackColor = System.Drawing.Color.Transparent
        Me.GBHALLBOOKING.Controls.Add(Me.Txt_BillTotal)
        Me.GBHALLBOOKING.Controls.Add(Me.Label35)
        Me.GBHALLBOOKING.Controls.Add(Me.Txt_Others)
        Me.GBHALLBOOKING.Controls.Add(Me.Label34)
        Me.GBHALLBOOKING.Controls.Add(Me.TXT_DISCOUNT)
        Me.GBHALLBOOKING.Controls.Add(Me.SSGRID_BOOKING)
        Me.GBHALLBOOKING.Controls.Add(Me.TXTB_BAMOUNT)
        Me.GBHALLBOOKING.Controls.Add(Me.Label30)
        Me.GBHALLBOOKING.Controls.Add(Me.TXT_DISAMT)
        Me.GBHALLBOOKING.Controls.Add(Me.Label29)
        Me.GBHALLBOOKING.Controls.Add(Me.TXT_TOTAMT)
        Me.GBHALLBOOKING.Controls.Add(Me.Label28)
        Me.GBHALLBOOKING.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBHALLBOOKING.ForeColor = System.Drawing.Color.Black
        Me.GBHALLBOOKING.Location = New System.Drawing.Point(177, 359)
        Me.GBHALLBOOKING.Name = "GBHALLBOOKING"
        Me.GBHALLBOOKING.Size = New System.Drawing.Size(662, 326)
        Me.GBHALLBOOKING.TabIndex = 843
        Me.GBHALLBOOKING.TabStop = False
        Me.GBHALLBOOKING.Text = "HALL BOOKING"
        Me.GBHALLBOOKING.Visible = False
        '
        'Txt_BillTotal
        '
        Me.Txt_BillTotal.BackColor = System.Drawing.Color.Wheat
        Me.Txt_BillTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_BillTotal.Location = New System.Drawing.Point(83, 285)
        Me.Txt_BillTotal.MaxLength = 5
        Me.Txt_BillTotal.Name = "Txt_BillTotal"
        Me.Txt_BillTotal.Size = New System.Drawing.Size(144, 20)
        Me.Txt_BillTotal.TabIndex = 864
        Me.Txt_BillTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(12, 289)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(67, 13)
        Me.Label35.TabIndex = 863
        Me.Label35.Text = "BILL TOTAL"
        '
        'Txt_Others
        '
        Me.Txt_Others.BackColor = System.Drawing.Color.Wheat
        Me.Txt_Others.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Others.Location = New System.Drawing.Point(513, 267)
        Me.Txt_Others.MaxLength = 5
        Me.Txt_Others.Name = "Txt_Others"
        Me.Txt_Others.ReadOnly = True
        Me.Txt_Others.Size = New System.Drawing.Size(143, 20)
        Me.Txt_Others.TabIndex = 862
        Me.Txt_Others.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(339, 270)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(105, 13)
        Me.Label34.TabIndex = 861
        Me.Label34.Text = "OTHERS AMOUNT "
        '
        'TXT_DISCOUNT
        '
        Me.TXT_DISCOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXT_DISCOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DISCOUNT.Location = New System.Drawing.Point(586, 248)
        Me.TXT_DISCOUNT.MaxLength = 5
        Me.TXT_DISCOUNT.Name = "TXT_DISCOUNT"
        Me.TXT_DISCOUNT.ReadOnly = True
        Me.TXT_DISCOUNT.Size = New System.Drawing.Size(70, 20)
        Me.TXT_DISCOUNT.TabIndex = 860
        Me.TXT_DISCOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SSGRID_BOOKING
        '
        Me.SSGRID_BOOKING.DataSource = Nothing
        Me.SSGRID_BOOKING.Location = New System.Drawing.Point(0, 18)
        Me.SSGRID_BOOKING.Name = "SSGRID_BOOKING"
        Me.SSGRID_BOOKING.OcxState = CType(resources.GetObject("SSGRID_BOOKING.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID_BOOKING.Size = New System.Drawing.Size(658, 205)
        Me.SSGRID_BOOKING.TabIndex = 812
        '
        'TXTB_BAMOUNT
        '
        Me.TXTB_BAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTB_BAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTB_BAMOUNT.Location = New System.Drawing.Point(514, 288)
        Me.TXTB_BAMOUNT.MaxLength = 5
        Me.TXTB_BAMOUNT.Name = "TXTB_BAMOUNT"
        Me.TXTB_BAMOUNT.Size = New System.Drawing.Size(144, 20)
        Me.TXTB_BAMOUNT.TabIndex = 859
        Me.TXTB_BAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(338, 292)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(95, 13)
        Me.Label30.TabIndex = 858
        Me.Label30.Text = "TOTAL AMOUNT "
        '
        'TXT_DISAMT
        '
        Me.TXT_DISAMT.BackColor = System.Drawing.Color.Wheat
        Me.TXT_DISAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DISAMT.Location = New System.Drawing.Point(514, 248)
        Me.TXT_DISAMT.MaxLength = 5
        Me.TXT_DISAMT.Name = "TXT_DISAMT"
        Me.TXT_DISAMT.Size = New System.Drawing.Size(67, 20)
        Me.TXT_DISAMT.TabIndex = 857
        Me.TXT_DISAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(338, 252)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(116, 13)
        Me.Label29.TabIndex = 856
        Me.Label29.Text = "DISCOUNT AMOUNT "
        '
        'TXT_TOTAMT
        '
        Me.TXT_TOTAMT.BackColor = System.Drawing.Color.Wheat
        Me.TXT_TOTAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_TOTAMT.Location = New System.Drawing.Point(514, 228)
        Me.TXT_TOTAMT.MaxLength = 5
        Me.TXT_TOTAMT.Name = "TXT_TOTAMT"
        Me.TXT_TOTAMT.Size = New System.Drawing.Size(144, 20)
        Me.TXT_TOTAMT.TabIndex = 855
        Me.TXT_TOTAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(337, 232)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(57, 13)
        Me.Label28.TabIndex = 854
        Me.Label28.Text = "AMOUNT "
        '
        'GRP_TARIFF
        '
        Me.GRP_TARIFF.BackColor = System.Drawing.Color.Transparent
        Me.GRP_TARIFF.Controls.Add(Me.SSGRID_TARIFF)
        Me.GRP_TARIFF.Controls.Add(Me.Txt_Maxitems)
        Me.GRP_TARIFF.Controls.Add(Me.Label27)
        Me.GRP_TARIFF.Controls.Add(Me.TXT_TARIFFDESC)
        Me.GRP_TARIFF.Controls.Add(Me.Label25)
        Me.GRP_TARIFF.Controls.Add(Me.CMD_TARIFF)
        Me.GRP_TARIFF.Controls.Add(Me.TXT_TARIFF)
        Me.GRP_TARIFF.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRP_TARIFF.ForeColor = System.Drawing.Color.Black
        Me.GRP_TARIFF.Location = New System.Drawing.Point(180, 332)
        Me.GRP_TARIFF.Name = "GRP_TARIFF"
        Me.GRP_TARIFF.Size = New System.Drawing.Size(661, 328)
        Me.GRP_TARIFF.TabIndex = 844
        Me.GRP_TARIFF.TabStop = False
        Me.GRP_TARIFF.Text = "MENU ITEM MASTER"
        '
        'SSGRID_TARIFF
        '
        Me.SSGRID_TARIFF.DataSource = Nothing
        Me.SSGRID_TARIFF.Location = New System.Drawing.Point(3, 62)
        Me.SSGRID_TARIFF.Name = "SSGRID_TARIFF"
        Me.SSGRID_TARIFF.OcxState = CType(resources.GetObject("SSGRID_TARIFF.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID_TARIFF.Size = New System.Drawing.Size(664, 260)
        Me.SSGRID_TARIFF.TabIndex = 813
        '
        'Txt_Maxitems
        '
        Me.Txt_Maxitems.BackColor = System.Drawing.Color.Wheat
        Me.Txt_Maxitems.Enabled = False
        Me.Txt_Maxitems.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Txt_Maxitems.Location = New System.Drawing.Point(554, 24)
        Me.Txt_Maxitems.MaxLength = 15
        Me.Txt_Maxitems.Name = "Txt_Maxitems"
        Me.Txt_Maxitems.Size = New System.Drawing.Size(104, 27)
        Me.Txt_Maxitems.TabIndex = 819
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(450, 24)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(73, 16)
        Me.Label27.TabIndex = 818
        Me.Label27.Text = "Max Items"
        '
        'TXT_TARIFFDESC
        '
        Me.TXT_TARIFFDESC.BackColor = System.Drawing.Color.Wheat
        Me.TXT_TARIFFDESC.Enabled = False
        Me.TXT_TARIFFDESC.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXT_TARIFFDESC.Location = New System.Drawing.Point(234, 24)
        Me.TXT_TARIFFDESC.MaxLength = 50
        Me.TXT_TARIFFDESC.Name = "TXT_TARIFFDESC"
        Me.TXT_TARIFFDESC.Size = New System.Drawing.Size(196, 27)
        Me.TXT_TARIFFDESC.TabIndex = 817
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(58, 30)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(53, 16)
        Me.Label25.TabIndex = 816
        Me.Label25.Text = "TARIFF"
        '
        'CMD_TARIFF
        '
        Me.CMD_TARIFF.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.CMD_TARIFF.Location = New System.Drawing.Point(210, 24)
        Me.CMD_TARIFF.Name = "CMD_TARIFF"
        Me.CMD_TARIFF.Size = New System.Drawing.Size(24, 26)
        Me.CMD_TARIFF.TabIndex = 815
        Me.CMD_TARIFF.Text = "?"
        '
        'TXT_TARIFF
        '
        Me.TXT_TARIFF.BackColor = System.Drawing.Color.Wheat
        Me.TXT_TARIFF.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXT_TARIFF.Location = New System.Drawing.Point(138, 24)
        Me.TXT_TARIFF.MaxLength = 15
        Me.TXT_TARIFF.Name = "TXT_TARIFF"
        Me.TXT_TARIFF.Size = New System.Drawing.Size(72, 27)
        Me.TXT_TARIFF.TabIndex = 814
        '
        'Lbl_Menu
        '
        Me.Lbl_Menu.AutoSize = True
        Me.Lbl_Menu.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Menu.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Lbl_Menu.Location = New System.Drawing.Point(8, 331)
        Me.Lbl_Menu.Name = "Lbl_Menu"
        Me.Lbl_Menu.Size = New System.Drawing.Size(109, 21)
        Me.Lbl_Menu.TabIndex = 820
        Me.Lbl_Menu.Text = "OCCUPANCY"
        Me.Lbl_Menu.Visible = False
        '
        'Pic_spousesign
        '
        Me.Pic_spousesign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_spousesign.Location = New System.Drawing.Point(976, 288)
        Me.Pic_spousesign.Name = "Pic_spousesign"
        Me.Pic_spousesign.Size = New System.Drawing.Size(48, 32)
        Me.Pic_spousesign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_spousesign.TabIndex = 852
        Me.Pic_spousesign.TabStop = False
        Me.Pic_spousesign.Visible = False
        '
        'Pic_Spouse
        '
        Me.Pic_Spouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_Spouse.Location = New System.Drawing.Point(976, 200)
        Me.Pic_Spouse.Name = "Pic_Spouse"
        Me.Pic_Spouse.Size = New System.Drawing.Size(48, 88)
        Me.Pic_Spouse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Spouse.TabIndex = 851
        Me.Pic_Spouse.TabStop = False
        Me.Pic_Spouse.Visible = False
        '
        'Pic_Sign
        '
        Me.Pic_Sign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_Sign.Location = New System.Drawing.Point(976, 168)
        Me.Pic_Sign.Name = "Pic_Sign"
        Me.Pic_Sign.Size = New System.Drawing.Size(48, 32)
        Me.Pic_Sign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Sign.TabIndex = 850
        Me.Pic_Sign.TabStop = False
        Me.Pic_Sign.Visible = False
        '
        'Pic_Member
        '
        Me.Pic_Member.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_Member.Location = New System.Drawing.Point(952, 80)
        Me.Pic_Member.Name = "Pic_Member"
        Me.Pic_Member.Size = New System.Drawing.Size(48, 88)
        Me.Pic_Member.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Member.TabIndex = 849
        Me.Pic_Member.TabStop = False
        Me.Pic_Member.Visible = False
        '
        'CMB_LOCATION
        '
        Me.CMB_LOCATION.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_LOCATION.Location = New System.Drawing.Point(558, -3)
        Me.CMB_LOCATION.Name = "CMB_LOCATION"
        Me.CMB_LOCATION.Size = New System.Drawing.Size(110, 25)
        Me.CMB_LOCATION.TabIndex = 853
        Me.CMB_LOCATION.Visible = False
        '
        'Btn_recdet
        '
        Me.Btn_recdet.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_recdet.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_recdet.Location = New System.Drawing.Point(697, 274)
        Me.Btn_recdet.Name = "Btn_recdet"
        Me.Btn_recdet.Size = New System.Drawing.Size(147, 49)
        Me.Btn_recdet.TabIndex = 864
        Me.Btn_recdet.Text = "ARRANGEMENT ITEM"
        Me.Btn_recdet.UseVisualStyleBackColor = False
        '
        'Btn_Hallava
        '
        Me.Btn_Hallava.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_Hallava.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Hallava.Location = New System.Drawing.Point(583, 272)
        Me.Btn_Hallava.Name = "Btn_Hallava"
        Me.Btn_Hallava.Size = New System.Drawing.Size(108, 52)
        Me.Btn_Hallava.TabIndex = 863
        Me.Btn_Hallava.Text = "KOT DETAILS"
        Me.Btn_Hallava.UseVisualStyleBackColor = False
        '
        'Btn_Hallres
        '
        Me.Btn_Hallres.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_Hallres.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Hallres.Location = New System.Drawing.Point(204, 272)
        Me.Btn_Hallres.Name = "Btn_Hallres"
        Me.Btn_Hallres.Size = New System.Drawing.Size(109, 48)
        Me.Btn_Hallres.TabIndex = 862
        Me.Btn_Hallres.Text = "HALL DISPLAY"
        Me.Btn_Hallres.UseVisualStyleBackColor = False
        '
        'cmd_report
        '
        Me.cmd_report.BackColor = System.Drawing.Color.Gainsboro
        Me.cmd_report.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_report.Image = CType(resources.GetObject("cmd_report.Image"), System.Drawing.Image)
        Me.cmd_report.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_report.Location = New System.Drawing.Point(862, 343)
        Me.cmd_report.Name = "cmd_report"
        Me.cmd_report.Size = New System.Drawing.Size(138, 62)
        Me.cmd_report.TabIndex = 877
        Me.cmd_report.Text = "REPORT"
        Me.cmd_report.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_report.UseVisualStyleBackColor = False
        '
        'cmd_exit
        '
        Me.cmd_exit.BackColor = System.Drawing.Color.Gainsboro
        Me.cmd_exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_exit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_exit.Image = CType(resources.GetObject("cmd_exit.Image"), System.Drawing.Image)
        Me.cmd_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_exit.Location = New System.Drawing.Point(862, 411)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(138, 65)
        Me.cmd_exit.TabIndex = 876
        Me.cmd_exit.Text = "Exit [F11]"
        Me.cmd_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_exit.UseVisualStyleBackColor = False
        '
        'Cmdauth
        '
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(-1, 585)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(144, 65)
        Me.Cmdauth.TabIndex = 875
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.UseVisualStyleBackColor = True
        Me.Cmdauth.Visible = False
        '
        'Cmdbwse
        '
        Me.Cmdbwse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbwse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbwse.Location = New System.Drawing.Point(-1, 431)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(144, 65)
        Me.Cmdbwse.TabIndex = 874
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.UseVisualStyleBackColor = True
        Me.Cmdbwse.Visible = False
        '
        'Cmdview
        '
        Me.Cmdview.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdview.Image = CType(resources.GetObject("Cmdview.Image"), System.Drawing.Image)
        Me.Cmdview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdview.Location = New System.Drawing.Point(-1, 515)
        Me.Cmdview.Name = "Cmdview"
        Me.Cmdview.Size = New System.Drawing.Size(144, 65)
        Me.Cmdview.TabIndex = 873
        Me.Cmdview.Text = "View [F9]"
        Me.Cmdview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdview.UseVisualStyleBackColor = True
        Me.Cmdview.Visible = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Gainsboro
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(862, 272)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(138, 65)
        Me.Button4.TabIndex = 872
        Me.Button4.Text = "Freeze [F8]"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(861, 134)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(138, 65)
        Me.Cmd_Clear.TabIndex = 871
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
        Me.Cmd_Add.Location = New System.Drawing.Point(861, 203)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(137, 65)
        Me.Cmd_Add.TabIndex = 870
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'Btn_nonveg
        '
        Me.Btn_nonveg.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Btn_nonveg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_nonveg.Location = New System.Drawing.Point(453, 272)
        Me.Btn_nonveg.Name = "Btn_nonveg"
        Me.Btn_nonveg.Size = New System.Drawing.Size(109, 48)
        Me.Btn_nonveg.TabIndex = 878
        Me.Btn_nonveg.Text = "NON VEG PAX"
        Me.Btn_nonveg.UseVisualStyleBackColor = False
        '
        'btn_veg
        '
        Me.btn_veg.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btn_veg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_veg.Location = New System.Drawing.Point(328, 275)
        Me.btn_veg.Name = "btn_veg"
        Me.btn_veg.Size = New System.Drawing.Size(109, 48)
        Me.btn_veg.TabIndex = 879
        Me.btn_veg.Text = "VEG PAX"
        Me.btn_veg.UseVisualStyleBackColor = False
        '
        'txt_NVegpax
        '
        Me.txt_NVegpax.BackColor = System.Drawing.Color.Wheat
        Me.txt_NVegpax.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.txt_NVegpax.Location = New System.Drawing.Point(76, 270)
        Me.txt_NVegpax.MaxLength = 5
        Me.txt_NVegpax.Name = "txt_NVegpax"
        Me.txt_NVegpax.Size = New System.Drawing.Size(98, 27)
        Me.txt_NVegpax.TabIndex = 865
        Me.txt_NVegpax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt_NVegpax.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(173, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 27)
        Me.Button2.TabIndex = 861
        Me.Button2.Text = "?"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'pnl_POSCode
        '
        Me.pnl_POSCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_POSCode.Controls.Add(Me.lvw_POSCode)
        Me.pnl_POSCode.Location = New System.Drawing.Point(38, 36)
        Me.pnl_POSCode.Name = "pnl_POSCode"
        Me.pnl_POSCode.Size = New System.Drawing.Size(269, 119)
        Me.pnl_POSCode.TabIndex = 882
        Me.pnl_POSCode.Visible = False
        '
        'lvw_POSCode
        '
        Me.lvw_POSCode.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lvw_POSCode.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvw_POSCode.FullRowSelect = True
        Me.lvw_POSCode.GridLines = True
        Me.lvw_POSCode.HideSelection = False
        Me.lvw_POSCode.HoverSelection = True
        Me.lvw_POSCode.Location = New System.Drawing.Point(1, 0)
        Me.lvw_POSCode.Name = "lvw_POSCode"
        Me.lvw_POSCode.Scrollable = False
        Me.lvw_POSCode.Size = New System.Drawing.Size(263, 135)
        Me.lvw_POSCode.TabIndex = 0
        Me.lvw_POSCode.UseCompatibleStateImageBehavior = False
        Me.lvw_POSCode.View = System.Windows.Forms.View.Details
        Me.lvw_POSCode.Visible = False
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "POS Code"
        Me.ColumnHeader6.Width = 121
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "POS Desc"
        Me.ColumnHeader7.Width = 133
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Account In"
        Me.ColumnHeader8.Width = 110
        '
        'pnl_UOMCode
        '
        Me.pnl_UOMCode.BackgroundImage = CType(resources.GetObject("pnl_UOMCode.BackgroundImage"), System.Drawing.Image)
        Me.pnl_UOMCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnl_UOMCode.Controls.Add(Me.lvw_Uom)
        Me.pnl_UOMCode.Location = New System.Drawing.Point(53, 161)
        Me.pnl_UOMCode.Name = "pnl_UOMCode"
        Me.pnl_UOMCode.Size = New System.Drawing.Size(261, 120)
        Me.pnl_UOMCode.TabIndex = 846
        Me.pnl_UOMCode.Visible = False
        '
        'lvw_Uom
        '
        Me.lvw_Uom.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader4})
        Me.lvw_Uom.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvw_Uom.FullRowSelect = True
        Me.lvw_Uom.GridLines = True
        Me.lvw_Uom.HoverSelection = True
        Me.lvw_Uom.Location = New System.Drawing.Point(1, 3)
        Me.lvw_Uom.Name = "lvw_Uom"
        Me.lvw_Uom.Size = New System.Drawing.Size(257, 119)
        Me.lvw_Uom.TabIndex = 0
        Me.lvw_Uom.UseCompatibleStateImageBehavior = False
        Me.lvw_Uom.View = System.Windows.Forms.View.Details
        Me.lvw_Uom.Visible = False
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "UOM Code"
        Me.ColumnHeader2.Width = 114
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "UOM Rate"
        Me.ColumnHeader4.Width = 131
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Gainsboro
        Me.Button5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button5.Location = New System.Drawing.Point(860, 552)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(138, 65)
        Me.Button5.TabIndex = 883
        Me.Button5.Text = "POST"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Cmd_SBill
        '
        Me.Cmd_SBill.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_SBill.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_SBill.Image = CType(resources.GetObject("Cmd_SBill.Image"), System.Drawing.Image)
        Me.Cmd_SBill.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_SBill.Location = New System.Drawing.Point(861, 483)
        Me.Cmd_SBill.Name = "Cmd_SBill"
        Me.Cmd_SBill.Size = New System.Drawing.Size(138, 62)
        Me.Cmd_SBill.TabIndex = 884
        Me.Cmd_SBill.Text = "Simulated Bill"
        Me.Cmd_SBill.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_SBill.UseVisualStyleBackColor = False
        '
        'PARTYBilling
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(10, 19)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.Controls.Add(Me.Cmd_SBill)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.pnl_UOMCode)
        Me.Controls.Add(Me.pnl_POSCode)
        Me.Controls.Add(Me.txt_NVegpax)
        Me.Controls.Add(Me.Lbl_Menu)
        Me.Controls.Add(Me.btn_veg)
        Me.Controls.Add(Me.Btn_nonveg)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cmd_report)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbwse)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.TXT_MENU)
        Me.Controls.Add(Me.Cmdview)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Btn_recdet)
        Me.Controls.Add(Me.Btn_Hallava)
        Me.Controls.Add(Me.Btn_Hallres)
        Me.Controls.Add(Me.GBHALLFACILITY)
        Me.Controls.Add(Me.CMB_LOCATION)
        Me.Controls.Add(Me.Pic_spousesign)
        Me.Controls.Add(Me.Pic_Spouse)
        Me.Controls.Add(Me.Pic_Sign)
        Me.Controls.Add(Me.Pic_Member)
        Me.Controls.Add(Me.chbreceipt)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.CMD_BILLINGNO)
        Me.Controls.Add(Me.LBL_PARTYDAY)
        Me.Controls.Add(Me.TXTBILLINGNO)
        Me.Controls.Add(Me.lbl_bookday)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.LABBOOKINGSTATUS)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TXTASSOCIATENAME)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TXTHALLCODE)
        Me.Controls.Add(Me.txtHALLDESCRIPTION)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.CMBBOOKINGTYPE)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TXTHALLRENT)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.grp_Tabledetails)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdhallHelp)
        Me.Controls.Add(Me.CHBHALLTAX)
        Me.Controls.Add(Me.Cmd_View)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GBMENUDETAILS)
        Me.Controls.Add(Me.GBHALLBOOKING)
        Me.Controls.Add(Me.GBARRANGEDETAILS)
        Me.Controls.Add(Me.GRP_NVEG)
        Me.Controls.Add(Me.GRP_TARIFF)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "PARTYBilling"
        Me.Text = "PARTYBILLING"
        Me.grp_Tabledetails.ResumeLayout(False)
        Me.grp_Tabledetails.PerformLayout()
        Me.GBHALLFACILITY.ResumeLayout(False)
        Me.GBHALLFACILITY.PerformLayout()
        CType(Me.SSGRID_HALL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBARRANGEDETAILS.ResumeLayout(False)
        Me.GBARRANGEDETAILS.PerformLayout()
        CType(Me.SSGRID_ARRANGE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBMENUDETAILS.ResumeLayout(False)
        Me.GBMENUDETAILS.PerformLayout()
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRP_NVEG.ResumeLayout(False)
        Me.GRP_NVEG.PerformLayout()
        CType(Me.SSGRID_NV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SSGRID_MENU1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBHALLBOOKING.ResumeLayout(False)
        Me.GBHALLBOOKING.PerformLayout()
        CType(Me.SSGRID_BOOKING, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GRP_TARIFF.ResumeLayout(False)
        Me.GRP_TARIFF.PerformLayout()
        CType(Me.SSGRID_TARIFF, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_spousesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Spouse, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Sign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Member, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_POSCode.ResumeLayout(False)
        Me.pnl_UOMCode.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub CMBBOOKINGTYPE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMBBOOKINGTYPE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTBOOKINGNO.Focus()
        End If
    End Sub

    Private Sub TXTBOOKINGNO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTBOOKINGNO.KeyDown
        'If e.KeyCode = Keys.F4 Then
        '    Call Cmd_BookingNo_Click(sender, e)
        'End If
        If e.KeyCode = Keys.Enter Then
            If Trim(TXTBOOKINGNO.Text) = "" Then
                Call Button2_Click(sender, e)
            Else
                Call TXTBOOKINGNO_Validated(TXTBOOKINGNO, e)
            End If
            'DTPBOOKINGDATE.Focus()
        End If

    End Sub
    Private Sub TXTBOOKINGNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBOOKINGNO.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If TXTBOOKINGNO.Text = "" Then
                ' Call Button2_Click(sender, e)
            Else
                Call TXTBOOKINGNO_Validated(TXTBOOKINGNO, e)
            End If
            'DTPBOOKINGDATE.Focus()
        End If
    End Sub
    Private Sub DTPBOOKINGDATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPBOOKINGDATE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTASSOCIATENAME.Focus()
        End If
    End Sub
    Private Sub DTPPARTYDATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPPARTYDATE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTASSOCIATENAME.Focus()
        End If
    End Sub
    Private Sub TXTFROMTIME_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTFROMTIME.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            TXTTOTIME.Focus()
        End If
    End Sub
    Private Sub TXTTOTIME_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTTOTIME.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            TXTMCODE.Focus()
        End If
    End Sub
    Private Sub TXTMCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTMCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TxtVOCCUPANCY.Focus()
        End If
    End Sub
    Private Sub TxtOCCUPANCY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOCCUPANCY.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            TXTDESCRIPTION.Focus()
        End If
    End Sub
    Private Sub TXTDESCRIPTION_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDESCRIPTION.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'TXTADVANCE.Focus()
            TXTGUESTNAME.Focus()
        End If
    End Sub
    Private Sub TXTGUESTNAME_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTDESCRIPTION.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'TXTADVANCE.Focus()
            TXTHALLRENT.Focus()
        End If
    End Sub
    Private Sub TXTADVANCE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTADVANCE.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            TXTRECEIPTNO.Focus()
        End If
    End Sub
    Private Sub TXTRECEIPTNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRECEIPTNO.KeyPress
        If Asc(e.KeyChar) = 13 Then
            CMDDATEVALE.Focus()
        End If
    End Sub
    Private Sub DTPRECEIPTDATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            If GBHALLFACILITY.Visible = False Then
                TXTHALLCODE.Focus()
            ElseIf GBARRANGEDETAILS.Visible = False Then
                SSGRID_ARRANGE.Focus()
            Else
                SSGRID.Focus()
            End If
        End If
    End Sub
    Private Sub TXTHALLCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTHALLCODE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTHALLRENT.Focus()
        End If
    End Sub
    Private Sub txtHALLDESCRIPTION_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHALLDESCRIPTION.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTHALLRENT.Focus()
        End If
    End Sub

    Private Sub clearoperaction()
        Pic_Member.Image = Nothing
        Pic_Sign.Image = Nothing
        Pic_Spouse.Image = Nothing
        Pic_spousesign.Image = Nothing

        DTPBOOKINGDATE.Enabled = False
        TXTMCODE.Enabled = True
        TXTHALLCODE.Enabled = True
        DTPPARTYDATE.Enabled = True
        GBARRANGEDETAILS.Visible = False
        Me.lbl_Freeze.Visible = False
        GBMENUDETAILS.Visible = False
        GBHALLFACILITY.Visible = False
        GRP_TARIFF.Visible = False
        Me.GRP_NVEG.Visible = False
        RDBHALLFACILITY.Checked = True
        Me.CMBBOOKINGTYPE.Enabled = True
        Me.TXTBOOKINGNO.ReadOnly = False
        Me.Cmd_BookingNo.Enabled = True
        LABBOOKINGSTATUS.Visible = False
        TXTASSOCIATENAME.Text = ""
        TXTBILLINGNO.Text = ""
        TextNVTBOX.Enabled = True
        NVHELP.Enabled = True
        TXT_TARIFF.Enabled = True
        CMD_TARIFF.Enabled = True

        Cmd_Add.Text = "Add [F7]"
        TXTHALLCANCELAMT.Text = ""
        TXT_TOTAMT.Text = ""
        TXTARRTAXAMOUNT.Text = ""
        TXT_DISAMT.Text = ""
        TXTB_BAMOUNT.Text = ""
        pnl_POSCode.Top = 1000
        pnl_UOMCode.Top = 1000
        bookingstatus.Visible = False
        TXTARRAMOUNT.Text = ""
        TXT_MENU.Text = ""
        TXTARRTOTALAMOUNT.Text = ""
        TXTARRCANCELAMT.Text = ""
        TXTRESTAXAMOUNT.Text = ""
        TXTRESCANCELAMT.Text = ""
        TXTRESAMOUNT.Text = ""
        TXTRESTOTALAMOUNT.Text = ""
        TXTBOOKINGNO.Text = ""
        TxtVOCCUPANCY.Text = ""
        TxtNVOCCUPANCY.Text = ""
        DTPBOOKINGDATE.Value = Format(Now, "dd/MM/yyyy")
        DTPPARTYDATE.Value = Format(Now, "dd/MM/yyyy")
        TXTFROMTIME.Text = ""
        TXTTOTIME.Text = ""
        TXTMCODE.Text = ""
        TXTMNAME.Text = ""
        TxtOCCUPANCY.Text = ""
        TXTDESCRIPTION.Text = ""
        TXTGUESTNAME.Text = ""
        TXTADVANCE.Text = ""
        TXTRECEIPTNO.Text = ""
        TXTHALLCODE.Text = ""
        txtHALLDESCRIPTION.Text = ""
        CHBHALLTAX.Checked = True
        TXTHALLRENT.Text = ""
        TXTTOTIME.Text = Format(Val(TXTTOTIME.Text), "0")
        TXTFROMTIME.Text = Format(Val(TXTFROMTIME.Text), "0")
        TXTADVANCE.Text = Format(Val(TXTADVANCE.Text), "0.00")
        TxtOCCUPANCY.Text = Format(Val(TxtOCCUPANCY.Text), "0")
        TXTHALLRENT.Text = Format(Val(TXTHALLRENT.Text), "0.00")
        SSGRID_HALL.ClearRange(-1, -1, 1, 1, True)
        SSGRID_ARRANGE.ClearRange(-1, -1, 1, 1, True)
        SSGRID.ClearRange(-1, -1, 1, 1, True)
        SSGRID_TARIFF.ClearRange(1, 1, -1, -1, True)
        SSGRID_NV.ClearRange(1, 1, -1, -1, True)
        SSGRID_BOOKING.ClearRange(1, 1, -1, -1, True)
        Me.TXT_NVDESC.Text = ""
        Me.TextNVTBOX.Text = ""
        Me.TXT_NVMAX.Text = ""
        TXT_TARIFF.Text = ""
        TXT_TARIFFDESC.Text = ""
        Txt_Maxitems.Text = ""
        Lbl_Menu.Text = "Menu"
        CMBBOOKINGTYPE.Text = "BOOKING"
        Show()
        CMBBOOKINGTYPE.Focus()
        CMDDATEVALE.Text = "C"
        RECDATEVALIDATED()
        DTPPARTYDATE.Enabled = True
        ' '' '' ''If RDBHALLFACILITY.Checked = True Then
        ' '' '' ''    GBHALLFACILITY.Visible = True
        ' '' '' ''    GBARRANGEDETAILS.Visible = False
        ' '' '' ''    GBMENUDETAILS.Visible = False
        ' '' '' ''    GBHALLFACILITY.Top = 12
        ' '' '' ''    GBHALLFACILITY.Top = 296
        ' '' '' ''ElseIf RDBARRITEM.Checked = True Then
        ' '' '' ''    GBHALLFACILITY.Visible = False
        ' '' '' ''    GBARRANGEDETAILS.Visible = True
        ' '' '' ''    GBMENUDETAILS.Visible = False
        ' '' '' ''    GBARRANGEDETAILS.Top = 12
        ' '' '' ''    GBARRANGEDETAILS.Top = 296
        ' '' '' ''ElseIf RDBRESMENU.Checked = True Then
        ' '' '' ''    GBHALLFACILITY.Visible = False
        ' '' '' ''    GBARRANGEDETAILS.Visible = False
        ' '' '' ''    GBMENUDETAILS.Visible = True
        ' '' '' ''    GBMENUDETAILS.Top = 12
        ' '' '' ''    GBMENUDETAILS.Top = 296
        ' '' '' ''End If

        Cmd_Add.Text = "Add [F7]"
        TXTMCODE.Enabled = False
        TXTHALLCODE.Enabled = False
        Call autogenerate()
        AUTO_MANUALNO()
        TXTBOOKINGNO.Focus()
        'DTPPARTYDATE.Enabled = False
    End Sub
    Public Sub checkValidation()
        BOOLCHK = False
        If Trim(TXTBOOKINGNO.Text) = "" Then
            MessageBox.Show(" Hall Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTHALLCODE.Focus()
            Exit Sub
        End If

        Dim LOC As String
        SSQL = "SELECT ISNULL(LOCCODE,'')AS LOCCODE FROM party_locationmaster"
        GCONNECTION.getDataSet(SSQL, "LOC")
        If gdataset.Tables("LOC").Rows.Count > 0 Then
            LOC = Trim(gdataset.Tables("LOC").Rows(0).Item("LOCCODE"))
        End If
        If Trim(LOC) = "KGA" Or Mid(gCompName, 1, 5) = "TRADE" Or Mid(gCompName, 1, 5) = "CIAL" Then
            If Trim(TxtOCCUPANCY.Text) <= 0 Then
                '  MessageBox.Show(" Occupancy can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            If Trim(TxtOCCUPANCY.Text) = "" Then
                MessageBox.Show(" Occupancy can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TxtOCCUPANCY.Focus()
                Exit Sub
            End If
        End If

        If Trim(TXT_MENU.Text) = "" Then
            'MessageBox.Show("Menu code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'TXT_MENU.Focus()
            'Exit Sub
        End If
        If Trim(TXTMCODE.Text) = "" And GuestType <> "OTHERS" Then
            MessageBox.Show(" Member Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTMCODE.Focus()
            Exit Sub
        End If

        Dim MSGRESULT, MENUCODE As String
        Dim MAXITEMS As Integer
        Dim COUNT As Integer
        With SSGRID_TARIFF
            For I = 1 To .DataRowCnt
                .Row = I
                .Col = 6
                MENUCODE = Trim(.Text)
                .Col = 8
                MAXITEMS = Val(.Text)
                COUNT = 0
                For J = 1 To .DataRowCnt
                    .Row = J
                    .Col = 6
                    If Trim(MENUCODE) = Trim(.Text) Then
                        COUNT = COUNT + 1
                    End If
                Next
                'If COUNT < MAXITEMS Then
                '    MSGRESULT = "Max items Exceed...MENU - " & Trim(CStr(MENUCODE)) & " ,   Maximum - " & Trim(CStr(MAXITEMS)) & " ,   Current - " & Trim(CStr(COUNT))
                '    MsgBox(MSGRESULT, MsgBoxStyle.OKOnly, "VALICATION")
                '    .SetActiveCell(1, I)
                '    .Focus()
                '    Exit Sub
                'End If
            Next
        End With
        SSQL = "SELECT * FROM sappostinglog WHERE BILL_NO = '" & Trim(TXTBILLINGNO.Text) & "'"
        DT = GCONNECTION.GetValues(SSQL)
        If DT.Rows.Count > 0 Then
            MessageBox.Show("This Bill Already Posted, Can't Modify or Delete", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        BOOLCHK = True
    End Sub
    Private Sub CMDDATEVALE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDDATEVALE.Click
        Call RECDATEVALIDATED()
    End Sub
    Private Sub RECDATEVALIDATED()
        'If CMDDATEVALE.Text = "C" Then
        '    CMBTEMPDATE.Visible = True
        '    DTPRECEIPTDATE.Value = "01-01-1900"
        '    DTPRECEIPTDATE.Visible = False
        '    CMDDATEVALE.Text = "D"
        'ElseIf CMDDATEVALE.Text = "D" Then
        '    CMBTEMPDATE.Visible = False
        '    DTPRECEIPTDATE.Visible = True
        '    CMDDATEVALE.Text = "C"
        '    DTPRECEIPTDATE.Value = Format(Now(), "dd/MM/yyyy")
        'End If
    End Sub
    Private Sub PartyBilling_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        Me.resizeFormResolution()
        rs.ResizeAllControls(Me)
        Dim STRSQL As String
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        ''Call AUTO_MANUALNO()
        gCenterlized = "Y"
        CMBBOOKINGTYPE.SelectedIndex = 0
        CMBBOOKINGTYPE.Text = "BILLING"

        STRSQL = "SELECT ISNULL(PACKINGPERCENT,0) AS PACKPER,ISNULL(TIPS,0) AS TIPS_SER,ISNULL(ADCHARGE,0) AS ADCHARGE,ISNULL(PRCHARGE,0) AS PRCHARGE,ISNULL(GRCHARGE,0) AS GRCHARGE,ISNULL(KOTTYPE,'') AS KOTTYPE,ISNULL(PAYMENTMODE,'') AS PAYMENTMODE,ISNULL(directprefix,'') AS KOTPREFIX,ISNULL(TABLEREQUIRED,'') AS TABLEREQ FROM POSSETUP "
        GCONNECTION.getDataSet(STRSQL, "PSETUP")
        If gdataset.Tables("PSETUP").Rows.Count > 0 Then
            pPackPer = gdataset.Tables("PSETUP").Rows(0).Item("PACKPER")
            pTipsPer = gdataset.Tables("PSETUP").Rows(0).Item("TIPS_SER")
            pAdCgsPer = gdataset.Tables("PSETUP").Rows(0).Item("ADCHARGE")
            pPartyPer = gdataset.Tables("PSETUP").Rows(0).Item("PRCHARGE")
            pRoomPer = gdataset.Tables("PSETUP").Rows(0).Item("GRCHARGE")
            pTableReq = gdataset.Tables("PSETUP").Rows(0).Item("TABLEREQ")
            pKotType = gdataset.Tables("PSETUP").Rows(0).Item("KOTTYPE")
            pKotPrefix = gdataset.Tables("PSETUP").Rows(0).Item("KOTPREFIX")
            DefaultPayment = gdataset.Tables("PSETUP").Rows(0).Item("PAYMENTMODE")
        End If
        clearoperaction()
        If Mid(gCompName, 1, 5) = "TRADE" Then
            Label5.Visible = False
            TXTMCODE.Visible = False
            cmd_mcodehelp.Visible = False
            Label7.Visible = False
            TXTMNAME.Visible = False
            Label4.Text = "EVENT DATE"
        Else
            Label5.Visible = True
            TXTMCODE.Visible = True
            cmd_mcodehelp.Visible = True
            Label7.Visible = True
            TXTMNAME.Visible = True
        End If
        GRP_NVEG.Visible = True
        pnl_POSCode.Top = 1000
        pnl_UOMCode.Top = 1000

        If Mid(gCompName, 1, 5) = "TRADE" Then
            btn_veg.Visible = False
            Btn_nonveg.Visible = False
            Btn_Hallava.Visible = False
            Label32.Visible = False
            TxtNVOCCUPANCY.Visible = False
            Label33.Visible = False
            TxtVOCCUPANCY.Visible = False
            GBHALLBOOKING.Visible = True
            GRP_TARIFF.Visible = False
            GRP_NVEG.Visible = False
            GBARRANGEDETAILS.Visible = False
            GBHALLFACILITY.Visible = False
            GBMENUDETAILS.Visible = False
            TXT_DISAMT.Visible = True
            TXT_TOTAMT.Visible = True
            TXTB_BAMOUNT.Visible = True
        End If
        Call autogenerate()
        Call locationfill()
        TXTBILLINGNO.Visible = True
        TXTBOOKINGNO.Focus()

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
    Private Function locationfill()
        Try
            Dim I As Integer
            Dim SQLSTRING As String
            CMB_LOCATION.Items.Clear()
            SQLSTRING = "SELECT DISTINCT LOCCODE FROM PARTY_LOCATIONMASTER"
            GCONNECTION.getDataSet(SQLSTRING, "PARTY_LOCATIONMASTER")
            If gdataset.Tables("PARTY_LOCATIONMASTER").Rows.Count > 0 Then
                For I = 0 To gdataset.Tables("PARTY_LOCATIONMASTER").Rows.Count - 1
                    CMB_LOCATION.Items.Add(gdataset.Tables("PARTY_LOCATIONMASTER").Rows(I).Item("loccode"))
                Next
            End If
            CMB_LOCATION.SelectedIndex = 0


            SQLSTRING = "SELECT ISNULL(TAXPERCENTAGE,0) AS TAXPERCENTAGE FROM TAXITEMLINK WHERE '" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "' BETWEEN STARTINGDATE  AND ISNULL(ENDINGDATE,'" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "') AND ITEMTYPECODE='VAT12'"
            GCONNECTION.getDataSet(SQLSTRING, "TAXITEMLINK")
            If gdataset.Tables("TAXITEMLINK").Rows.Count > 0 Then
                PRTAXPERC = gdataset.Tables("TAXITEMLINK").Rows(0).Item("TAXPERCENTAGE")
            Else
                PRTAXPERC = 0
            End If

            SQLSTRING = "SELECT ISNULL(TAXPERCENTAGE,0) AS TAXPERCENTAGE FROM TAXITEMLINK WHERE '" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "' BETWEEN STARTINGDATE  AND ISNULL(ENDINGDATE,'" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "') AND ITEMTYPECODE='CNTG'"
            GCONNECTION.getDataSet(SQLSTRING, "TAXITEMLINK")
            If gdataset.Tables("TAXITEMLINK").Rows.Count > 0 Then
                PRTAXPERCCONT = gdataset.Tables("TAXITEMLINK").Rows(0).Item("TAXPERCENTAGE")
            Else
                PRTAXPERCCONT = 0
            End If
            '

            SQLSTRING = "SELECT ISNULL(TAXPERCENTAGE,0) AS TAXPERCENTAGE FROM TAXITEMLINK WHERE '" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "' BETWEEN STARTINGDATE  AND ISNULL(ENDINGDATE,'" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "') AND ITEMTYPECODE='SERTX'"
            GCONNECTION.getDataSet(SQLSTRING, "TAXITEMLINK")
            If gdataset.Tables("TAXITEMLINK").Rows.Count > 0 Then
                SERVICETAXPERC = gdataset.Tables("TAXITEMLINK").Rows(0).Item("TAXPERCENTAGE")
            Else
                SERVICETAXPERC = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CATEGORYFILL " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function

    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        GCONNECTION.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_Add1.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add1.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add1.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add1.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add1.Enabled = True
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
    Private Sub TXTFROMTIME_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTFROMTIME.LostFocus
        TXTFROMTIME.Text = Format(Val(TXTFROMTIME.Text), "0")
    End Sub
    Private Sub TXTTOTIME_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTTOTIME.LostFocus
        TXTTOTIME.Text = Format(Val(TXTTOTIME.Text), "0")
    End Sub
    Private Sub TxtOCCUPANCY_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOCCUPANCY.LostFocus
        TxtOCCUPANCY.Text = Format(Val(TxtOCCUPANCY.Text), "0")
    End Sub
    Private Sub TXTADVANCE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTADVANCE.LostFocus
        TXTADVANCE.Text = Format(Val(TXTADVANCE.Text), "0.00")
    End Sub
    Private Sub TXTHALLRENT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTHALLRENT.LostFocus
        TXTHALLRENT.Text = Format(Val(TXTHALLRENT.Text), "0.00")
    End Sub
    Private Sub TXTBOOKINGNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBOOKINGNO.Validated
        Dim D1, D2 As Date
        Dim sql As String
        Dim VALID As String

        'D1 = DTPBOOKINGDATE.Value
        'D2 = DTPPARTYDATE.Value
        'CDAY = DateDiff(DateInterval.Day, D1, D2)

        Try
            VALID = "N"
            J = 0
            If Trim(TXTBOOKINGNO.Text) <> "" Then


                SQLSTRING = "SELECT * FROM PARTY_KOT_det WHERE kotdetails = " & Trim(TXTBOOKINGNO.Text) & " AND PAYMENTMODE='PARTY' AND ISNULL(BOOKINGTYPE,'')='BILLING'"
                GCONNECTION.getDataSet(SQLSTRING, "PARTY")
                If gdataset.Tables("PARTY").Rows.Count = 0 Then

                    SQLSTRING = "SELECT ISNULL(SALESACCOUNTCODE,0) AS SALESACCOUNTCODE,ISNULL(TAXACCOUNTCODE,0) AS TAXACCOUNTCODE,ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(PACKPERCENT,0) AS PACKPERCENT,"
                    SQLSTRING = SQLSTRING & " ISNULL(PACKAMOUNT,0) AS PACKAMOUNT,ISNULL(kot_det.OPENFACILITYST,0) AS OPENFACILITYST,ISNULL(PROMOTIONALST,0) AS PROMOTIONALST,ISNULL(PACKACCOUNTCODE,'') AS PACKACCOUNTCODE,ISNULL(MKOTNO,'')AS MKOTNO,* FROM KOT_DET,KOT_HDR  WHERE KOT_DET.KOTDETAILS=KOT_HDR.KOTDETAILS AND ISNULL(KOT_DET.DELFLAG,'')<>'Y'  AND KOT_HDR.PARTYORDERNO='" & Trim(TXTBOOKINGNO.Text) & "' AND KOT_DET.PAYMENTMODE='PARTY' ORDER BY kot_det.AUTOID "
                    GCONNECTION.getDataSet(SQLSTRING, "KOT_DET")
                    If gdataset.Tables("KOT_DET").Rows.Count > 0 Then
                        For I = 1 To gdataset.Tables("KOT_DET").Rows.Count
                            SSGRID.SetText(1, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("MKOTNO")) & "")
                            SSGRID.SetText(2, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("ItemCode")) & "")
                            SSGRID.SetText(3, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("itemdesc")) & "")
                            SSGRID.SetText(4, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("poscode")))
                            SSGRID.SetText(5, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("UOM")))
                            SSGRID.SetText(6, I, Val(gdataset.Tables("KOT_DET").Rows(J).Item("Qty")))
                            SSGRID.SetText(7, I, Format(Val(gdataset.Tables("KOT_DET").Rows(J).Item("Rate")), "0.00"))
                            SSGRID.SetText(8, I, Format(Val(gdataset.Tables("KOT_DET").Rows(J).Item("Taxamount")), "0.00"))
                            SSGRID.SetText(9, I, Format(Val(gdataset.Tables("KOT_DET").Rows(J).Item("Amount")), "0.00"))
                            SSGRID.SetText(10, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("ItemType")) & "")
                            SSGRID.SetText(11, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("TaxCode")) & "")
                            SSGRID.SetText(12, I, Val(gdataset.Tables("KOT_DET").Rows(J).Item("TaxPerc")))
                            SSGRID.SetText(14, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("TaxAccountCode")))
                            SSGRID.SetText(15, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("SalesAccountCode")))
                            SSGRID.SetText(16, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("GroupCode")))
                            SSGRID.SetText(17, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("SUBGroupCode")))
                            SSGRID.SetText(18, I, Format(Val(gdataset.Tables("KOT_DET").Rows(J).Item("autoid")), "0.00"))
                            SSGRID.SetText(19, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("Openfacilityst")))
                            SSGRID.SetText(20, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("Promotionalst")))
                            'REFERINVENTORY***********************************************************************
                            SSGRID.SetText(21, I, Val(gdataset.Tables("KOT_DET").Rows(J).Item("Qty")))
                            '*************************************************************************************
                            If CStr(gdataset.Tables("KOT_DET").Rows(J).Item("KOTStatus") & "") = "Y" Then
                                SSGRID.SetText(13, I, "Yes")
                            Else
                                SSGRID.SetText(13, I, "No")
                            End If
                            J = J + 1
                        Next
                        'End If
                        VALID = "Y"
                    End If
                End If
                If Trim(TXTBOOKINGNO.Text) <> "" Then
                    If Val(TXTBOOKINGNO.Text) > 0 Then
                        SSQL = "SELECT ISNULL(BOOKINGFLAG,'') AS BOOKINGFLAG,ISNULL(BILLINGFLAG,'') AS BILLINGFLAG,"
                        SSQL = SSQL & "ISNULL(CANCELFLAG,'') AS CANCELFLAG FROM  PARTY_HALLBOOKING_HDR "
                        SSQL = SSQL & "WHERE ISNULL(BOOKINGNO, 0) = " & IIf(TXTBOOKINGNO.Text = "", 0, TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' "
                        DT = GCONNECTION.GetValues(SSQL)
                    Else
                        Exit Sub
                    End If

                    If DT.Rows.Count > 0 Then
                        If DT.Rows(0).Item("CANCELFLAG") = "Y" Then
                            CANCEL = True
                        Else
                            CANCEL = False
                        End If
                        If DT.Rows(0).Item("BOOKINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                            bookingstatus.Visible = True
                            bookingstatus.Text = "BOOKING OVER"

                            SSQL = "SELECT ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,"
                            SSQL = SSQL & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                            SSQL = SSQL & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                            SSQL = SSQL & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,ISNULL(P.GUESTNAME,'') AS GUESTNAME,"
                            SSQL = SSQL & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                            SSQL = SSQL & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS POCCUPANCY,ISNULL(P.veg,0) AS veg,ISNULL(P.nonveg,0) AS nonveg,"
                            SSQL = SSQL & "ISNULL(h.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                            SSQL = SSQL & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,"
                            SSQL = SSQL & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG,ISNULL(P.MENUCODE,'')AS MENUCODE FROM PARTY_HDR P"
                            SSQL = SSQL & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO AND P.LOCCODE=H.LOCCODE"
                            SSQL = SSQL & " where P.Bookingno=" & Trim(TXTBOOKINGNO.Text) & " AND P.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                            SSQL = SSQL & " AND P.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' and ISNULL(h.Void ,'')<>'Y'"
                            DT = GCONNECTION.GetValues(SSQL)
                            SSQL = "select isnull(sum(amount),0)as amount from party_receipt where LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and bookingno=" & TXTBOOKINGNO.Text & " and isnull(freeze,'')<>'Y'"
                            GCONNECTION.getDataSet(SSQL, "rec")
                            If gdataset.Tables("rec").Rows.Count > 0 Then
                                TXTRESAMOUNT.Text = gdataset.Tables("rec").Rows(0).Item("Amount")
                            Else
                                TXTRESAMOUNT.Text = 0.0
                            End If
                            LABBOOKINGSTATUS.Visible = True
                            LABBOOKINGSTATUS.Text = ""
                            Me.Cmd_Add.Text = "Update[F7]"
                        ElseIf DT.Rows(0).Item("BILLINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                            bookingstatus.Visible = True
                            bookingstatus.Text = "BILLING OVER"

                            SSQL = "SELECT  ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,"
                            SSQL = SSQL & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                            SSQL = SSQL & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                            SSQL = SSQL & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,ISNULL(P.GUESTNAME,'') AS GUESTNAME,"
                            SSQL = SSQL & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                            SSQL = SSQL & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS POCCUPANCY,"
                            SSQL = SSQL & "ISNULL(P.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                            SSQL = SSQL & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg,"
                            SSQL = SSQL & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG,ISNULL(P.BILLNO,'') AS BILLNO FROM PARTY_HDR P"
                            SSQL = SSQL & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO AND P.LOCCODE=H.LOCCODE"
                            SSQL = SSQL & " where P.Bookingno=" & Trim(TXTBOOKINGNO.Text) & ""
                            SSQL = SSQL & " AND P.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND H.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"

                            DT = GCONNECTION.GetValues(SSQL)
                            SSQL = "select isnull(sum(amount),0)as amount from party_receipt where LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and bookingno=" & TXTBOOKINGNO.Text & " and isnull(freeze,'')<>'Y'"
                            GCONNECTION.getDataSet(SSQL, "rec")
                            If gdataset.Tables("rec").Rows.Count > 0 Then
                                TXTRESAMOUNT.Text = gdataset.Tables("rec").Rows(0).Item("Amount")
                            Else
                                TXTRESAMOUNT.Text = 0.0
                            End If
                            LABBOOKINGSTATUS.Visible = True
                            LABBOOKINGSTATUS.Text = ""
                            Me.Cmd_Add.Text = "Update[F7]"
                        ElseIf DT.Rows(0).Item("CANCELFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                            bookingstatus.Visible = True
                            bookingstatus.Text = "CANCEL OVER"
                            SSQL = "SELECT  ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,"
                            SSQL = SSQL & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                            SSQL = SSQL & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                            SSQL = SSQL & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,ISNULL(P.GUESTNAME,'') AS GUESTNAME,"
                            SSQL = SSQL & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                            SSQL = SSQL & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS POCCUPANCY,"
                            SSQL = SSQL & "ISNULL(H.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                            SSQL = SSQL & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg,"
                            SSQL = SSQL & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG FROM PARTY_HDR P"
                            SSQL = SSQL & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO AND P.LOCCODE=H.LOCCODE"
                            SSQL = SSQL & " where P.Bookingno=" & Trim(TXTBOOKINGNO.Text) & ""
                            SSQL = SSQL & " AND P.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'  AND H.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                            DT = GCONNECTION.GetValues(SSQL)
                            SSQL = "select isnull(sum(amount),0)as amount from party_receipt where LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and bookingno=" & TXTBOOKINGNO.Text & " and isnull(freeze,'')<>'Y'"
                            GCONNECTION.getDataSet(SSQL, "rec")
                            If gdataset.Tables("rec").Rows.Count > 0 Then
                                TXTRESAMOUNT.Text = gdataset.Tables("rec").Rows(0).Item("Amount")
                            Else
                                TXTRESAMOUNT.Text = 0.0
                            End If
                            LABBOOKINGSTATUS.Visible = True
                            LABBOOKINGSTATUS.Text = ""
                            Me.Cmd_Add.Text = "Update[F7]"
                        ElseIf DT.Rows(0).Item("CANCELFLAG") <> "Y" And DT.Rows(0).Item("BILLINGFLAG") <> "Y" And Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                            If DT.Rows(0).Item("BOOKINGFLAG") = "Y" Then
                                SSQL = "SELECT  ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,"
                                SSQL = SSQL & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                                SSQL = SSQL & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                                SSQL = SSQL & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,ISNULL(P.GUESTNAME,'') AS GUESTNAME,"
                                SSQL = SSQL & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                                SSQL = SSQL & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS POCCUPANCY,"
                                SSQL = SSQL & "ISNULL(P.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                                SSQL = SSQL & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY ,ISNULL(H.veg,0) AS veg ,ISNULL(H.nonveg,0) AS nonveg ,"
                                SSQL = SSQL & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG FROM PARTY_HDR P"
                                SSQL = SSQL & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO AND P.LOCCODE=H.LOCCODE"
                                SSQL = SSQL & " where P.Bookingno=" & Trim(TXTBOOKINGNO.Text) & "  AND P.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'and ISNULL(h.Void ,'')<>'Y'"
                                SSQL = SSQL & " AND P.BOOKINGTYPE='BOOKING'"
                                DT = GCONNECTION.GetValues(SSQL)
                                SSQL = "select isnull(sum(amount),0)as amount from party_receipt where LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and bookingno=" & TXTBOOKINGNO.Text & " and isnull(freeze,'')<>'Y'  AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                                GCONNECTION.getDataSet(SSQL, "rec")
                                If gdataset.Tables("rec").Rows.Count > 0 Then
                                    TXTRESAMOUNT.Text = gdataset.Tables("rec").Rows(0).Item("Amount")
                                Else
                                    TXTRESAMOUNT.Text = 0.0
                                End If
                            Else
                                SSQL = " Select isnull(bookingflag,'') as bookingflag,isnull(billingflag,'') as billingflag,isnull(cancelflag,'') as cancelflag,isnull(h.bookingno,0)as bookingno,isnull(h.bookingdate,'')as bookingdate,isnull(d.hallcode,'')as hallcode,isnull(m.halltypedesc,'')As halldesc,"
                                SSQL = SSQL & " isnull(h.partydate,'')as partydate,isnull(h.mcode,'')as mcode,isnull(d.halltype,'')as pcode,isnull(m.pdesc,'')as pdesc,"
                                SSQL = SSQL & " isnull(h.associatename,'')as associatename,ISNULL(H.GUESTNAME,'') AS GUESTNAME,isnull(d.hallamount,0)as hallamount,isnull(r.receiptno,'')as receiptno,"
                                SSQL = SSQL & " isnull(r.receiptdate,'')as receiptdate,isnull(r.amount,0)as rcptamount,"
                                SSQL = SSQL & " isnull(d.fromtime,0)as fromtime,isnull(d.totime,0)as totime,isnull(h.freeze,'')as freeze,isnull(h.adddatetime,'')As adddatetime,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg  "
                                SSQL = SSQL & " from party_hallbooking_hdr h "
                                SSQL = SSQL & " left outer join party_hallbooking_det d on h.bookingno = d.bookingno"
                                SSQL = SSQL & " left outer join party_receipt r on h.bookingno = r.bookingno AND R.LOCCODE=H.LOCCODE"
                                SSQL = SSQL & " left outer join party_view_hallmaster m on d.hallcode=m.halltypecode and m.pcode=d.halltype"
                                SSQL = SSQL & " WHERE H.BOOKINGNO=" & TXTBOOKINGNO.Text & " AND H.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'and ISNULL(h.Void ,'')<>'Y'"
                                DT = GCONNECTION.GetValues(SSQL)
                                SSQL = "select isnull(sum(amount),0)as amount from party_receipt where bookingno=" & TXTBOOKINGNO.Text & " and isnull(freeze,'')<>'Y' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                                GCONNECTION.getDataSet(SSQL, "rec")
                                If gdataset.Tables("rec").Rows.Count > 0 Then
                                    TXTRESAMOUNT.Text = gdataset.Tables("rec").Rows(0).Item("Amount")
                                Else
                                    TXTRESAMOUNT.Text = 0.0
                                End If
                            End If
                        Else
                            If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                                SSQL = " Select  0 AS INVOICENO,isnull(bookingflag,'') as bookingflag,isnull(billingflag,'') as billingflag,isnull(cancelflag,'') as cancelflag,isnull(h.bookingno,0)as bookingno,isnull(h.bookingdate,'')as bookingdate,isnull(d.hallcode,'')as hallcode,isnull(m.halltypedesc,'')As halldesc,"
                                SSQL = SSQL & " isnull(h.partydate,'')as partydate,isnull(h.mcode,'')as mcode,isnull(d.halltype,'')as pcode,isnull(m.pdesc,'')as pdesc,"
                                SSQL = SSQL & " isnull(h.associatename,'')as associatename,isnull(h.GUESTname,'')as GUESTname,isnull(d.hallamount,0)as hallamount,isnull(d.SEDEPOSIT,0)as SEDEPOSIT,isnull(r.receiptno,'')as receiptno,"
                                SSQL = SSQL & " isnull(r.receiptdate,'')as receiptdate,isnull(r.amount,0)as rcptamount,ISNULL(H.DESCRIPTION,'') AS DESCRIPTION,"
                                SSQL = SSQL & " isnull(d.fromtime,0)as fromtime,isnull(d.totime,0)as totime,isnull(h.freeze,'')as freeze,isnull(h.adddatetime,'')As adddatetime,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg "
                                SSQL = SSQL & " from party_hallbooking_hdr h "
                                SSQL = SSQL & " left outer join party_hallbooking_det d on h.bookingno = d.bookingno"
                                SSQL = SSQL & " left outer join party_receipt r on h.bookingno = r.bookingno  AND H.LOCCODE=R.LOCCODE"
                                SSQL = SSQL & " left outer join party_view_hallmaster m on d.hallcode=m.halltypecode and m.pcode=d.halltype"
                                SSQL = SSQL & " WHERE H.BOOKINGNO=" & TXTBOOKINGNO.Text & " AND H.LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and ISNULL(h.Void ,'')<>'Y'"
                                DT = GCONNECTION.GetValues(SSQL)

                                SSQL = "select isnull(sum(amount),0)as amount from party_receipt where LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and bookingno=" & TXTBOOKINGNO.Text & " and isnull(freeze,'')<>'Y'"
                                GCONNECTION.getDataSet(SSQL, "rec")
                                If gdataset.Tables("rec").Rows.Count > 0 Then
                                    TXTRESAMOUNT.Text = gdataset.Tables("rec").Rows(0).Item("Amount")
                                Else
                                    TXTRESAMOUNT.Text = 0.0
                                End If
                            ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                                SSQL = "SELECT  ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,ISNULL(P.BOOKINGTYPE,'')AS BOOKINGTYPE,"
                                SSQL = SSQL & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                                SSQL = SSQL & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                                SSQL = SSQL & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,isnull(P.GUESTname,'')as GUESTname,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,ISNULL(P.GUESTNAME,'') AS GUESTNAME,"
                                SSQL = SSQL & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                                SSQL = SSQL & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS POCCUPANCY,"
                                SSQL = SSQL & "ISNULL(P.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                                SSQL = SSQL & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,"
                                SSQL = SSQL & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG,ISNULL(P.BILLNO,'') AS BILLNO,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg,ISNULL(P.MENUCODE,0) AS MENUCODE FROM PARTY_HDR P"
                                SSQL = SSQL & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO"
                                SSQL = SSQL & " WHERE P.BOOKINGNO=" & TXTBOOKINGNO.Text & " AND P.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                                SSQL = SSQL & " AND P.BOOKINGTYPE='BOOKING'"
                                DT = GCONNECTION.GetValues(SSQL)
                            Else
                                MessageBox.Show("BILLING OVER,YOU CAN'T CANCEL", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                                Call Cmd_Clear_Click(sender, e)
                                Exit Sub
                            End If
                        End If
                    Else
                        MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        Call Cmd_Clear_Click(sender, e)
                        Exit Sub
                    End If
                End If

                If DT.Rows.Count > 0 Then
                    TXTMCODE.Enabled = True
                    TXTHALLCODE.Enabled = True
                    DTPPARTYDATE.Enabled = True
                    DTPBOOKINGDATE.Text = Format(DT.Rows(0).Item("BOOKINGDATE"), "dd/MMM/yyyy")
                    DTPPARTYDATE.Text = Format(DT.Rows(0).Item("PARTYDATE"), "dd/MMM/yyyy")
                    TXTFROMTIME.Text = DT.Rows(0).Item("FROMTIME")
                    TXTTOTIME.Text = DT.Rows(0).Item("TOTIME")
                    TXTMCODE.Text = DT.Rows(0).Item("MCODE")
                    'TXTBILLINGNO.Text = DT.Rows(0).Item("BILLNO")
                    'Me.Cmd_Add.Text = "Update [F7]"
                    '==========================================================
                    'TXT_MENU.Text = DT.Rows(0).Item("MENUCODE")
                    SSQL = "select isnull(MENUCODE,'')as MENUCODE from party_hdr where  bookingno=" & TXTBOOKINGNO.Text & " and isnull(freeze,'')<>'Y'"
                    GCONNECTION.getDataSet(SSQL, "memnu")
                    If gdataset.Tables("memnu").Rows.Count > 0 Then
                        TXT_MENU.Text = gdataset.Tables("memnu").Rows(0).Item("MENUCODE")
                    Else
                        TXT_MENU.Text = ""
                    End If
                    '============================================================
                    SQLSTRING = "select ISNULL(HALLNETAMOUNT,0) AS HALLNETAMOUNT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(DISCOUNTAMT,0) AS DISCOUNTAMT,ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT from party_hallbooking_hdr WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " "
                    GCONNECTION.getDataSet(SQLSTRING, "HallStatus123")
                    If gdataset.Tables("HallStatus123").Rows.Count > 0 Then
                        Me.TXT_TOTAMT.Text = gdataset.Tables("HallStatus123").Rows(0).Item("HALLNETAMOUNT")
                        Me.TXT_DISAMT.Text = gdataset.Tables("HallStatus123").Rows(0).Item("DISCOUNT")
                        Me.TXT_DISCOUNT.Text = gdataset.Tables("HallStatus123").Rows(0).Item("DISCOUNTAMT")
                        Me.TXTB_BAMOUNT.Text = gdataset.Tables("HallStatus123").Rows(0).Item("TOTALAMOUNT")
                    End If
                    SQLSTRING = "SELECT (SUM(ISNULL(HKSTAFFAMT,0))+SUM(ISNULL(SECURITYSTAFFAMT,0))) AS OTHERS FROM PARTY_HALLBOOKING_DET WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " "
                    GCONNECTION.getDataSet(SQLSTRING, "HallStatus321")
                    If gdataset.Tables("HallStatus321").Rows.Count > 0 Then
                        Me.Txt_Others.Text = gdataset.Tables("HallStatus321").Rows(0).Item("OTHERS")
                    End If
                    '==========================A==========
                    TXT_TOTAMT.Enabled = False
                    TXT_DISAMT.Enabled = False
                    TXTB_BAMOUNT.Enabled = False
                    Txt_Others.Enabled = False
                    ' ====================================

                    If DT.Rows(0).Item("BOOKINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                        TxtOCCUPANCY.Text = DT.Rows(0).Item("POCCUPANCY")
                    ElseIf DT.Rows(0).Item("BILLINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                        TxtOCCUPANCY.Text = DT.Rows(0).Item("POCCUPANCY")
                    ElseIf DT.Rows(0).Item("CANCELFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                        TxtOCCUPANCY.Text = DT.Rows(0).Item("POCCUPANCY")
                    Else
                        TxtOCCUPANCY.Text = DT.Rows(0).Item("OCCUPANCY")

                    End If

                    TxtVOCCUPANCY.Text = DT.Rows(0).Item("veg")
                    TxtNVOCCUPANCY.Text = DT.Rows(0).Item("nonveg")

                    If DT.Rows(0).Item("BOOKINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                        TXTDESCRIPTION.Text = DT.Rows(0).Item("DESCRIPTION")
                    ElseIf DT.Rows(0).Item("BILLINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                        TXTDESCRIPTION.Text = DT.Rows(0).Item("DESCRIPTION")
                    ElseIf DT.Rows(0).Item("CANCELFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                        TXTDESCRIPTION.Text = DT.Rows(0).Item("DESCRIPTION")
                    Else
                        TXTDESCRIPTION.Text = DT.Rows(0).Item("DESCRIPTION")
                    End If
                    TXTADVANCE.Text = ADVANCE_ANOUNT()
                    If Mid(Cmd_Add.Text, 1, 1) = "A" And CMBBOOKINGTYPE.Text = "BILLING" Then
                    Else
                        TXTBILLINGNO.Text = DT.Rows(0).Item("BILLNO")
                    End If


                    'TXTRECEIPTNO.Text = DT.Rows(0).Item("RECEIPTNO")
                    TXTMNAME.Text = DT.Rows(0).Item("associatename")
                    TXTGUESTNAME.Text = DT.Rows(0).Item("GUESTNAME")

                    D1 = DateTime.Now()
                    D2 = DTPPARTYDATE.Value
                    CDAY = DateDiff(DateInterval.Day, D1, D2)
                    If Format(DT.Rows(0).Item("RECEIPTDATE"), "dd/MM/yyyy") = "01/01/1900" Then
                        CMDDATEVALE.Text = "C"
                        RECDATEVALIDATED()
                    Else
                        CMDDATEVALE.Text = "D"
                        DTPRECEIPTDATE.Value = Format(DT.Rows(0).Item("RECEIPTDATE"), "dd/MM/yyyy")
                        'DTPRECEIPTDATE.Visible = True
                        DTPRECEIPTDATE.Visible = False
                        CMBTEMPDATE.Visible = False
                    End If
                    TXTHALLCODE.Text = DT.Rows(0).Item("HALLCODE")
                    'CHBHALLTAX.Checked = IIf(DT.Rows(0).Item("HALLTAXFLAG") = "Y", True, False)
                    TXTHALLRENT.Text = DT.Rows(0).Item("HALLAMOUNT")
                    If DT.Rows(0).Item("FREEZE") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "THIS BOOKING IS CANCELLED ON:" & Format(CDate(DT.Rows(0).Item("ADDDATETIME")), "dd-MMM-yyyy")
                        Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_Freeze.Text = "Cancel[F8]"
                    End If
                    Call TXTMCODE_Validated(TXTMCODE, e)
                    Call TXTHALLCODE_Validated(TXTHALLCODE, e)
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If

                    With SSGRID_BOOKING
                        GBHALLBOOKING.Visible = True
                        rdo_halldisplay.Checked = True
                        Dim Deposit As Double
                        'If CMBBOOKINGTYPE.SelectedItem = "BOOKING" Then
                        SSQL = "SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) AS SEDAMT FROM party_receipt_DET WHERE BOOKINGNO = " & Trim(TXTBOOKINGNO.Text) & " AND Receiptheaddesc LIKE '%SECURITY DEPOSIT%' AND ISNULL(RECEIPTTYPE,'')  NOT IN ('REFUND','DISHONOURED') "
                        GCONNECTION.getDataSet(SSQL, "SEDDEPO")
                        If gdataset.Tables("SEDDEPO").Rows.Count > 0 Then
                            Deposit = gdataset.Tables("SEDDEPO").Rows(0).Item(0)
                        Else
                            Deposit = 0
                        End If
                        Dim dt4 As DataTable
                        SSQL = "Select hallcode,halldesc,occupancy,pcode,pdesc,loccode,locdesc,fromtime,totime,hallamount,HALLTAXPERC,HALLTAXAMOUNT,HALLNETAMOUNT," & Deposit & " as SEDEPOSIT from party_view_hallbookingdetails where  bookingno=" & Trim(TXTBOOKINGNO.Text) & "  group by hallcode,halldesc,occupancy,pcode,pdesc,loccode,locdesc,fromtime,totime,hallamount,HALLTAXPERC,HALLTAXAMOUNT,HALLNETAMOUNT,SEDEPOSIT"
                        dt4 = GCONNECTION.GetValues(SSQL)
                        For I = 0 To dt4.Rows.Count - 1
                            .Col = 1
                            .Row = I + 1
                            .Text = dt4.Rows(I).Item("HALLCODE")
                            .Col = 2
                            .Row = I + 1
                            .Text = dt4.Rows(I).Item("HALLDESC")
                            .Col = 3
                            .Row = I + 1
                            .Text = dt4.Rows(I).Item("PCODE")
                            .Col = 4
                            .Row = I + 1
                            .Text = dt4.Rows(I).Item("PDESC")
                            .Col = 5
                            .Row = I + 1
                            .Text = dt4.Rows(I).Item("FROMTIME")
                            .Col = 6
                            .Row = I + 1
                            .Text = dt4.Rows(I).Item("TOTIME")
                            .Col = 7
                            .Row = I + 1
                            .Text = dt4.Rows(I).Item("HALLAMOUNT")
                            .Col = 8
                            .Row = I + 1
                            .Text = dt4.Rows(I).Item("HALLTAXPERC")
                            .Col = 9
                            .Row = I + 1
                            .Text = dt4.Rows(I).Item("HALLTAXAMOUNT")
                            .Col = 10
                            .Row = I + 1
                            .Text = dt4.Rows(I).Item("HALLNETAMOUNT")
                            .Col = 11
                            .Row = I + 1
                            .Text = dt4.Rows(I).Item("SEDEPOSIT")
                        Next
                        '.SetActiveCell(1, 1)
                        '.Focus()
                        'End If
                    End With
                    Me.CMBBOOKINGTYPE.Enabled = False
                    Me.TXTBOOKINGNO.ReadOnly = True
                    Me.Cmd_BookingNo.Enabled = False
                    Me.DTPBOOKINGDATE.Focus()
                    Call HALLFACILITY()
                    If Trim(VALID) = "Y" Then
                        ' Call POSDETAILS()
                    Else
                        Call POSDETAILS()
                    End If
                    Call Btn_recdet_Click(sender, e)
                    Call Btn_Hallres_Click(sender, e)
                    Call ARRANGEMENT()
                    Call RESTAURANT()
                    Call TARIFFITEMSvg()
                    Call TARIFFITEMSnvg()
                    DTPBOOKINGDATE.Focus()
                    TXTMCODE.Enabled = False
                    TXTHALLCODE.Enabled = False
                    DTPPARTYDATE.Enabled = False

                    Call Total_Calculate()

                    SQLSTRING = "select * from VIEW_PARTY_BOOKINGDETAILS WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & ""
                    GCONNECTION.getDataSet(SQLSTRING, "HallStatus")
                    If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                        GuestType = gdataset.Tables("HallStatus").Rows(0).Item("GUEST_TYPE")
                    End If
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Add.Text = "Add [F7]"
                    TXTBOOKINGNO.ReadOnly = False
                    MessageBox.Show("HALL BOOKING NO NOT FOUND,PLEASE BOOK THE HALL FIRST.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    TXTBOOKINGNO.Text = ""
                    TXTBOOKINGNO.Focus()
                    'DTPBOOKINGDATE.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Function ADVANCE_ANOUNT() As Double
        SSQL = "select isnull(sum(amount),0) as amount from party_receipt_det where bookingno=" & TXTBOOKINGNO.Text & " AND RECEIPTTYPE='DEPOSIT'"
        DT1 = GCONNECTION.GetValues(SSQL)
        If DT1.Rows.Count > 0 Then
            Return DT1.Rows(0).Item("amount")
        Else
            Return 0
        End If
    End Function
    Private Sub POSDETAILS()
        Dim SSQL As String

        SSQL = "SELECT ISNULL(BOOKINGFLAG,'') AS BOOKINGFLAG,ISNULL(BILLINGFLAG,'') AS BILLINGFLAG,"
        SSQL = SSQL & "ISNULL(CANCELFLAG,'') AS CANCELFLAG FROM  PARTY_HALLBOOKING_HDR "
        SSQL = SSQL & "WHERE ISNULL(BOOKINGNO, 0) = " & IIf(TXTBOOKINGNO.Text = "", 0, TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' "
        DT = GCONNECTION.GetValues(SSQL)

        If DT.Rows(0).Item("BILLINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
            J = 0
            SQLSTRING = "SELECT ISNULL(SALESACCOUNTCODE,0) AS SALESACCOUNTCODE,ISNULL(TAXACCOUNTCODE,0) AS TAXACCOUNTCODE,ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(PACKPERCENT,0) AS PACKPERCENT,"
            SQLSTRING = SQLSTRING & " ISNULL(PACKAMOUNT,0) AS PACKAMOUNT,ISNULL(OPENFACILITYST,0) AS OPENFACILITYST,ISNULL(PROMOTIONALST,0) AS PROMOTIONALST,ISNULL(PACKACCOUNTCODE,'') AS PACKACCOUNTCODE,* FROM PARTY_KOT_DET WHERE  KOTDETAILS='" & Trim(TXTBOOKINGNO.Text) & "' AND BOOKINGTYPE='BILLING' ORDER BY AUTOID "
            GCONNECTION.getDataSet(SQLSTRING, "KOT_DET")
            If gdataset.Tables("KOT_DET").Rows.Count > 0 Then
                For I = 1 To gdataset.Tables("KOT_DET").Rows.Count
                    SSGRID.SetText(1, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("MKOTNO")) & "")
                    SSGRID.SetText(2, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("ItemCode")) & "")
                    SSGRID.SetText(3, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("itemdesc")) & "")
                    SSGRID.SetText(4, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("poscode")))
                    SSGRID.SetText(5, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("UOM")))
                    SSGRID.SetText(6, I, Val(gdataset.Tables("KOT_DET").Rows(J).Item("Qty")))
                    SSGRID.SetText(7, I, Format(Val(gdataset.Tables("KOT_DET").Rows(J).Item("Rate")), "0.00"))
                    SSGRID.SetText(8, I, Format(Val(gdataset.Tables("KOT_DET").Rows(J).Item("Taxamount")), "0.00"))
                    SSGRID.SetText(9, I, Format(Val(gdataset.Tables("KOT_DET").Rows(J).Item("Amount")), "0.00"))
                    SSGRID.SetText(10, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("ItemType")) & "")
                    SSGRID.SetText(11, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("TaxCode")) & "")
                    SSGRID.SetText(12, I, Val(gdataset.Tables("KOT_DET").Rows(J).Item("TaxPerc")))
                    SSGRID.SetText(14, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("TaxAccountCode")))
                    SSGRID.SetText(15, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("SalesAccountCode")))
                    SSGRID.SetText(16, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("GroupCode")))
                    SSGRID.SetText(17, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("SUBGroupCode")))
                    SSGRID.SetText(18, I, Format(Val(gdataset.Tables("KOT_DET").Rows(J).Item("autoid")), "0.00"))
                    SSGRID.SetText(19, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("Openfacilityst")))
                    SSGRID.SetText(20, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("Promotionalst")))
                    'REFERINVENTORY***********************************************************************
                    SSGRID.SetText(21, I, Val(gdataset.Tables("KOT_DET").Rows(J).Item("Qty")))
                    '*************************************************************************************
                    If CStr(gdataset.Tables("KOT_DET").Rows(J).Item("KOTStatus") & "") = "Y" Then
                        SSGRID.SetText(13, I, "Yes")
                    Else
                        SSGRID.SetText(13, I, "No")
                    End If
                    J = J + 1
                Next
            End If
        Else

            J = 0
            SQLSTRING = "SELECT ISNULL(SALESACCOUNTCODE,0) AS SALESACCOUNTCODE,ISNULL(TAXACCOUNTCODE,0) AS TAXACCOUNTCODE,ISNULL(GROUPCODE,'') AS GROUPCODE,ISNULL(PACKPERCENT,0) AS PACKPERCENT,"
            SQLSTRING = SQLSTRING & " ISNULL(PACKAMOUNT,0) AS PACKAMOUNT,ISNULL(OPENFACILITYST,0) AS OPENFACILITYST,ISNULL(PROMOTIONALST,0) AS PROMOTIONALST,ISNULL(PACKACCOUNTCODE,'') AS PACKACCOUNTCODE,* FROM party_KOT_DET WHERE  KOTDETAILS='" & Trim(TXTBOOKINGNO.Text) & "' AND BOOKINGTYPE='BOOKING' ORDER BY AUTOID "
            GCONNECTION.getDataSet(SQLSTRING, "KOT_DET")
            If gdataset.Tables("KOT_DET").Rows.Count > 0 Then
                For I = 1 To gdataset.Tables("KOT_DET").Rows.Count
                    SSGRID.SetText(1, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("MKOTNO")) & "")
                    SSGRID.SetText(2, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("ItemCode")) & "")
                    SSGRID.SetText(3, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("itemdesc")) & "")
                    SSGRID.SetText(4, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("poscode")))
                    SSGRID.SetText(5, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("UOM")))
                    SSGRID.SetText(6, I, Val(gdataset.Tables("KOT_DET").Rows(J).Item("Qty")))
                    SSGRID.SetText(7, I, Format(Val(gdataset.Tables("KOT_DET").Rows(J).Item("Rate")), "0.00"))
                    SSGRID.SetText(8, I, Format(Val(gdataset.Tables("KOT_DET").Rows(J).Item("Taxamount")), "0.00"))
                    SSGRID.SetText(9, I, Format(Val(gdataset.Tables("KOT_DET").Rows(J).Item("Amount")), "0.00"))
                    SSGRID.SetText(10, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("ItemType")) & "")
                    SSGRID.SetText(11, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("TaxCode")) & "")
                    SSGRID.SetText(12, I, Val(gdataset.Tables("KOT_DET").Rows(J).Item("TaxPerc")))
                    SSGRID.SetText(14, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("TaxAccountCode")))
                    SSGRID.SetText(15, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("SalesAccountCode")))
                    SSGRID.SetText(16, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("GroupCode")))
                    SSGRID.SetText(17, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("SUBGroupCode")))
                    SSGRID.SetText(18, I, Format(Val(gdataset.Tables("KOT_DET").Rows(J).Item("autoid")), "0.00"))
                    SSGRID.SetText(19, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("Openfacilityst")))
                    SSGRID.SetText(20, I, Trim(gdataset.Tables("KOT_DET").Rows(J).Item("Promotionalst")))
                    'REFERINVENTORY***********************************************************************
                    SSGRID.SetText(21, I, Val(gdataset.Tables("KOT_DET").Rows(J).Item("Qty")))
                    '*************************************************************************************
                    If CStr(gdataset.Tables("KOT_DET").Rows(J).Item("KOTStatus") & "") = "Y" Then
                        SSGRID.SetText(13, I, "Yes")
                    Else
                        SSGRID.SetText(13, I, "No")
                    End If
                    J = J + 1
                Next
            End If
        End If
       
    End Sub
    Private Sub TARIFFITEMSnvg()
        If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            'SSQL = SSQL & " WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category='NON VEG')"
            SSQL = SSQL & " WHERE   BOOKINGNO=" & TXTBOOKINGNO.Text & " and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category='NON VEG')"
            DT = GCONNECTION.GetValues(SSQL)
        ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Or Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            SSQL = SSQL & " WHERE   BOOKINGNO=" & TXTBOOKINGNO.Text & "  AND ISNULL(TARIFFDESC,'')<>'' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category='NON VEG') AND BOOKINGTYPE='BOOKING'"
            'SSQL = SSQL & " WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND ISNULL(TARIFFDESC,'')<>'' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category='NON VEG')"

            DT = GCONNECTION.GetValues(SSQL)
        End If
        If DT.Rows.Count > 0 Then
            TextNVTBOX.Enabled = False
            NVHELP.Enabled = False
            TextNVTBOX.Text = DT.Rows(0).Item("TARIFFCODE")
            TXT_NVDESC.Text = DT.Rows(0).Item("TARIFFDESC")
            'TXT_TARIFF.Text = DT.Rows(0).Item("TARIFFCODE")
            'TXT_TARIFFDESC.Text = DT.Rows(0).Item("TARIFFDESC")
            'SSQL = "SELECT isnull(SUM(MAXITEMS),25) AS MAXITEMS FROM PARTY_TARIFFDET WHERE TARIFFCODE='" & Trim(TXT_TARIFF.Text) & "' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category='NON VEG')"
            SSQL = "SELECT isnull(SUM(MAXITEMS),25) AS MAXITEMS FROM PARTY_TARIFFDET WHERE TARIFFCODE='" & Trim(TextNVTBOX.Text) & "' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category='NON VEG')"

            GCONNECTION.getDataSet(SSQL, "USER")
            If gdataset.Tables("USER").Rows.Count > 0 Then
                Txt_Maxitems.Text = gdataset.Tables("USER").Rows(0).Item("MAXITEMS")
            Else
                Txt_Maxitems.Text = 25

            End If

            'With SSGRID_TARIFF
            With SSGRID_NV
                For I = 0 To DT.Rows.Count - 1
                    .Col = 1
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("TARIFFCODE")

                    .Col = 2
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("ITEMCODE")
                    .Col = 3
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("ITEMDESCRIPTION")
                    .Col = 4
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("UOM")
                    .Col = 5
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("QTY")
                    .Col = 6
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("GROUPCODE")
                    .Col = 7
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("MENUCODE")
                    .Col = 8
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("TARIFFCODE")
                    .Col = 9
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("MAXITEMS")
                Next
            End With
        Else
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            SSQL = SSQL & " WHERE  BOOKINGTYPE='BOOKING' AND BOOKINGNO=" & TXTBOOKINGNO.Text & "  and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category='NON VEG')"

            DT = GCONNECTION.GetValues(SSQL)
            If DT.Rows.Count > 0 Then
                TextNVTBOX.Enabled = False
                NVHELP.Enabled = False
                TextNVTBOX.Text = DT.Rows(0).Item("TARIFFCODE")
                TXT_NVDESC.Text = DT.Rows(0).Item("TARIFFDESC")
                SSQL = "SELECT isnull(SUM(MAXITEMS),25) AS MAXITEMS FROM PARTY_TARIFFDET WHERE TARIFFCODE='" & Trim(TextNVTBOX.Text) & "' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category='NON VEG')"

                GCONNECTION.getDataSet(SSQL, "USER")
                If gdataset.Tables("USER").Rows.Count > 0 Then
                    Txt_Maxitems.Text = gdataset.Tables("USER").Rows(0).Item("MAXITEMS")
                Else
                    Txt_Maxitems.Text = 25

                End If
                With SSGRID_NV
                    For I = 0 To DT.Rows.Count - 1
                        .Col = 1
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("TARIFFCODE")
                        .Col = 2
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("ITEMCODE")
                        .Col = 3
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("ITEMDESCRIPTION")
                        .Col = 4
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("UOM")
                        .Col = 5
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("QTY")
                        .Col = 6
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("GROUPCODE")
                        .Col = 7
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("MENUCODE")
                        .Col = 8
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("TARIFFCODE")
                        .Col = 9
                        .Row = I + 1
                        .Text = DT.Rows(I).Item("MAXITEMS")
                    Next
                End With
            End If
        End If
    End Sub
    Private Sub TARIFFITEMSvg()
        If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            'SSQL = SSQL & " WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category IN ('VEG'))"
            SSQL = SSQL & " WHERE  BOOKINGNO=" & TXTBOOKINGNO.Text & "  and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category IN ('VEG'))"
            'SSQL = SSQL & " WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category in ('VEG','NON VEG'))"

            DT = GCONNECTION.GetValues(SSQL)
        ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Or Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            'SSQL = SSQL & " WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND ISNULL(TARIFFDESC,'')<>'' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category in ('VEG'))"
            SSQL = SSQL & " WHERE  BOOKINGNO=" & TXTBOOKINGNO.Text & " AND ISNULL(TARIFFDESC,'')<>'' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category in ('VEG')) AND BOOKINGTYPE='BOOKING'"

            DT = GCONNECTION.GetValues(SSQL)
        End If
        If DT.Rows.Count > 0 Then
            TXT_TARIFF.Enabled = False
            CMD_TARIFF.Enabled = False
            Me.TXT_TARIFF.Text = DT.Rows(0).Item("TARIFFCODE")
            Me.TXT_TARIFFDESC.Text = DT.Rows(0).Item("TARIFFDESC")
            'Me.TextNVTBOX.Text = DT.Rows(0).Item("TARIFFCODE")
            'Me.TXT_NVDESC.Text = DT.Rows(0).Item("TARIFFDESC")
            SSQL = "SELECT isnull(SUM(MAXITEMS),25) AS MAXITEMS FROM PARTY_TARIFFDET WHERE TARIFFCODE='" & Trim(TXT_TARIFF.Text) & "' and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category in ('VEG'))"

            GCONNECTION.getDataSet(SSQL, "USER")
            If gdataset.Tables("USER").Rows.Count > 0 Then
                Me.TXT_NVMAX.Text = gdataset.Tables("USER").Rows(0).Item("MAXITEMS")
            Else
                TXT_NVMAX.Text = 25

            End If

            'With SSGRID_NV
            With SSGRID_TARIFF
                For I = 0 To DT.Rows.Count - 1

                    .Col = 1
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("TARIFFCODE")

                    .Col = 2
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("ITEMCODE")
                    .Col = 3
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("ITEMDESCRIPTION")
                    .Col = 4
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("UOM")
                    .Col = 5
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("QTY")
                    .Col = 6
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("GROUPCODE")
                    .Col = 7
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("MENUCODE")
                    .Col = 8
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("TARIFFCODE")
                    .Col = 9
                    .Row = I + 1
                    .Text = DT.Rows(I).Item("MAXITEMS")
                Next
            End With
        Else
            SSQL = " SELECT *  FROM PARTY_VIEW_RESTAURANT_TARIFF"
            SSQL = SSQL & " WHERE  BOOKINGTYPE='BILLING' AND BOOKINGNO=" & TXTBOOKINGNO.Text & "  and tariffcode in( select tariffcode from PARTY_TARIFFHDR where category='VEG')"

            DT = GCONNECTION.GetValues(SSQL)
            If DT.Rows.Count > 0 Then
                TXT_TARIFF.Enabled = False
                CMD_TARIFF.Enabled = False

                Me.TXT_TARIFF.Text = DT.Rows(0).Item("TARIFFCODE")
                Me.TXT_TARIFFDESC.Text = DT.Rows(0).Item("TARIFFDESC")
                'Me.TextNVTBOX.Text = DT.Rows(0).Item("TARIFFCODE")
                'Me.TXT_NVDESC.Text = DT.Rows(0).Item("TARIFFDESC")

                Me.TXT_NVMAX.Text = DT.Rows(0).Item("MAXITEMS")
                With SSGRID_TARIFF
                    For I = 1 To DT.Rows.Count - 1
                        .Col = 1
                        .Row = I
                        .Text = DT.Rows(I).Item("TARIFFCODE")
                        .Col = 2
                        .Row = I
                        .Text = DT.Rows(I).Item("ITEMCODE")
                        .Col = 3
                        .Row = I
                        .Text = DT.Rows(I).Item("ITEMDESCRIPTION")
                        .Col = 4
                        .Row = I
                        .Text = DT.Rows(I).Item("UOM")
                        .Col = 5
                        .Row = I
                        .Text = DT.Rows(I).Item("QTY")
                        .Col = 6
                        .Row = I
                        .Text = DT.Rows(I).Item("GROUPCODE")
                        .Col = 7
                        .Row = I
                        .Text = DT.Rows(I).Item("MENUCODE")
                        .Col = 8
                        .Row = I
                        .Text = DT.Rows(I).Item("TARIFFCODE")
                        .Col = 9
                        .Row = I
                        .Text = DT.Rows(I).Item("MAXITEMS")
                    Next
                End With
            End If
        End If
    End Sub
    Private Sub RESTAURANT()
        'ASCA START CHANGED ON 11-10-12  BY LOGAN 
        If UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then
            Try
                Me.TXTRESTOTALAMOUNT.Text = "0.00"
                If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Or Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                    SSQL = " SELECT chitno,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,POS  FROM VIEW_PARTY_RESTAURANT"
                    SSQL = SSQL & " WHERE   BOOKINGNO=" & TXTBOOKINGNO.Text & " "
                    DT = GCONNECTION.GetValues(SSQL)
                ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Or Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                    SSQL = " SELECT chitno,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,POS  FROM VIEW_PARTY_RESTAURANT"
                    SSQL = SSQL & " WHERE    BOOKINGNO=" & TXTBOOKINGNO.Text & " "
                    DT = GCONNECTION.GetValues(SSQL)
                    If DT.Rows.Count = 0 Then
                        SSQL = " SELECT chitno,BOOKINGTYPE,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,POS  FROM VIEW_PARTY_RESTAURANT"
                        SSQL = SSQL & " WHERE  BOOKINGTYPE='BOOKING' AND BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        DT = GCONNECTION.GetValues(SSQL)
                    End If
                End If
                If DT.Rows.Count > 0 Then
                    'TXTRESTOTALAMOUNT.Text = 0
                    'TXTRESAMOUNT.Text = 0
                    'TXTRESTAXAMOUNT.Text = 0
                    'TXTRESCANCELAMT.Text = 0
                    'TXTSERTAX.TEXT = 0
                    With SSGRID
                        .ClearRange(-1, -1, 1, 1, True)
                        .SetActiveCell(1, 1)
                        For I = 0 To DT.Rows.Count - 1

                            .Row = I + 1
                            .Col = 1
                            .Lock = False
                            .Text = DT.Rows(I).Item("chitno")

                            .Row = I + 1
                            .Col = 2
                            .Lock = False
                            .Text = DT.Rows(I).Item("Itemcode")

                            .Row = I + 1
                            .Col = 3
                            .Lock = False
                            .Text = DT.Rows(I).Item("Itemdescription")
                            '.Lock = True

                            .Row = I + 1
                            .Col = 4
                            .Lock = False
                            .Text = DT.Rows(I).Item("Uom")
                            '.Lock = True

                            .Row = I + 1
                            .Col = 5
                            .Lock = False
                            .Text = DT.Rows(I).Item("rate")
                            .Lock = True

                            .Row = I + 1
                            .Col = 6
                            .Lock = False
                            .Text = DT.Rows(I).Item("qty")

                            .Row = I + 1
                            .Col = 7
                            .Lock = False
                            .Text = DT.Rows(I).Item("Amount")
                            TXTRESAMOUNT.Text = Format(TXTRESAMOUNT.Text + Val(.Text), "0.00")
                            .Lock = True

                            .Row = I + 1
                            .Col = 8
                            .Lock = False
                            .Text = DT.Rows(I).Item("SERTAX")
                            'TXTSERTAX.Text = Format(TXTSERTAX.Text + Val(.Text), "0.00")
                            .Lock = True

                            .Row = I + 1
                            .Col = 9
                            .Lock = False
                            .Text = DT.Rows(I).Item("Taxamount")
                            'TXTRESTAXAMOUNT.Text = Format(TXTRESTAXAMOUNT.Text + Val(.Text), "0.00")
                            .Lock = True

                            .Row = I + 1
                            .Col = 10
                            .Lock = False
                            .Text = DT.Rows(I).Item("TotalAmount")
                            TXTRESTOTALAMOUNT.Text = Format(Math.Round(Val(TXTRESTOTALAMOUNT.Text) + Val(.Text), 2), "0.00")
                            .Lock = True

                            .Row = I + 1
                            .Col = 11
                            .Lock = True
                            .Text = DT.Rows(I).Item("POS")
                            .Lock = True

                            'If CMBBOOKINGTYPE.Text = "CANCEL" And CANCEL = False Then
                            '    SSQL = " SELECT  ITEMTYPECODE,ITEMDESC,FROMDAYS,TODAYS,PERCENTAGE,FREEZE "
                            '    SSQL = SSQL & "FROM VIEW_PARTY_GROUPMASTER WHERE " & CDAY & " BETWEEN FROMDAYS AND TODAYS "
                            '    SSQL = SSQL & "AND ITEMTYPECODE='" & DT.Rows(I).Item("CGROUPCODE") & "'"
                            '    DT1 = GCONNECTION.GetValues(SSQL)
                            '    If DT1.Rows.Count > 0 Then
                            '        .Text = Format(Math.Round((DT.Rows(I).Item("Amount") * DT1.Rows(0).Item("PERCENTAGE")) / 100, 2), "0.00")
                            '    Else
                            '        .Text = 0
                            '    End If
                            'Else
                            '    .Text = Format(DT.Rows(I).Item("CANCELAMOUNT"), "0.00")
                            '    If (CMBBOOKINGTYPE.Text = "BOOKING" Or CMBBOOKINGTYPE.Text = "BILLING") And CANCEL = True Then
                            '        SSQL = " SELECT  ITEMTYPECODE,ITEMDESC,FROMDAYS,TODAYS,PERCENTAGE,FREEZE "
                            '        SSQL = SSQL & "FROM VIEW_PARTY_GROUPMASTER WHERE " & CDAY & " BETWEEN FROMDAYS AND TODAYS "
                            '        SSQL = SSQL & "AND ITEMTYPECODE='" & DT.Rows(I).Item("CGROUPCODE") & "'"
                            '        DT1 = GCONNECTION.GetValues(SSQL)
                            '        If DT1.Rows.Count > 0 Then
                            '            .Text = Format(Math.Round((DT.Rows(I).Item("Amount") * DT1.Rows(0).Item("PERCENTAGE")) / 100, 2), "0.00")
                            '        Else
                            '            .Text = 0.0
                            '        End If
                            '    End If
                            'End If
                            'TXTRESCANCELAMT.Text = Format(Math.Round(TXTRESCANCELAMT.Text + Val(.Text), 2), "0.00")
                            'FOR ASCA
                            '.Row = I + 1
                            '.Col = 11
                            '.Lock = False
                            '.Text = DT.Rows(I).Item("Roundoff")
                            '.Lock = True
                            '.Row = I + 1
                            '.Col = 12
                            '.Lock = False
                            '.Text = DT.Rows(I).Item("TaxPerc")
                            '.Lock = True
                            '.SetActiveCell(2, I + 1)
                            ''''END 
                        Next
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            'ASCA ONLY END 

        Else
            Try
                Me.TXTRESTOTALAMOUNT.Text = "0.00"
                If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Or Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                    SSQL = " SELECT chitno,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT  FROM VIEW_PARTY_RESTAURANT"
                    SSQL = SSQL & " WHERE   BOOKINGNO=" & TXTBOOKINGNO.Text & " "
                    DT = GCONNECTION.GetValues(SSQL)
                ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Or Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                    SSQL = " SELECT chitno,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT  FROM VIEW_PARTY_RESTAURANT"
                    SSQL = SSQL & " WHERE    BOOKINGNO=" & TXTBOOKINGNO.Text & " "
                    DT = GCONNECTION.GetValues(SSQL)
                    If DT.Rows.Count = 0 Then
                        SSQL = " SELECT chitno,BOOKINGTYPE,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT  FROM VIEW_PARTY_RESTAURANT"
                        SSQL = SSQL & " WHERE  BOOKINGTYPE='BOOKING' AND BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        DT = GCONNECTION.GetValues(SSQL)
                    End If
                End If
                If DT.Rows.Count > 0 Then
                    'TXTRESTOTALAMOUNT.Text = 0
                    'TXTRESAMOUNT.Text = 0
                    'TXTRESTAXAMOUNT.Text = 0
                    'TXTRESCANCELAMT.Text = 0
                    'TXTSERTAX.TEXT = 0
                    With SSGRID
                        .ClearRange(-1, -1, 1, 1, True)
                        .SetActiveCell(1, 1)
                        For I = 0 To DT.Rows.Count - 1

                            .Row = I + 1
                            .Col = 1
                            .Lock = False
                            .Text = DT.Rows(I).Item("chitno")

                            .Row = I + 1
                            .Col = 2
                            .Lock = False
                            .Text = DT.Rows(I).Item("Itemcode")

                            .Row = I + 1
                            .Col = 3
                            .Lock = False
                            .Text = DT.Rows(I).Item("Itemdescription")
                            '.Lock = True

                            .Row = I + 1
                            .Col = 4
                            .Lock = False
                            .Text = DT.Rows(I).Item("Uom")
                            '.Lock = True

                            .Row = I + 1
                            .Col = 5
                            .Lock = False
                            .Text = DT.Rows(I).Item("rate")

                            .Row = I + 1
                            .Col = 6
                            .Lock = False
                            .Text = DT.Rows(I).Item("qty")

                            .Row = I + 1
                            .Col = 7
                            .Lock = False
                            .Text = DT.Rows(I).Item("Amount")
                            TXTRESAMOUNT.Text = Format(TXTRESAMOUNT.Text + Val(.Text), "0.00")
                            .Lock = True

                            .Row = I + 1
                            .Col = 8
                            .Lock = False
                            .Text = DT.Rows(I).Item("SERTAX")
                            'TXTSERTAX.Text = Format(TXTSERTAX.Text + Val(.Text), "0.00")
                            .Lock = True

                            .Row = I + 1
                            .Col = 9
                            .Lock = False
                            .Text = DT.Rows(I).Item("Taxamount")
                            'TXTRESTAXAMOUNT.Text = Format(TXTRESTAXAMOUNT.Text + Val(.Text), "0.00")
                            .Lock = True

                            .Row = I + 1
                            .Col = 10
                            .Lock = False
                            .Text = DT.Rows(I).Item("TotalAmount")
                            TXTRESTOTALAMOUNT.Text = Format(Math.Round(Val(TXTRESTOTALAMOUNT.Text) + Val(.Text), 2), "0.00")

                            .Lock = True
                            .Row = I + 1
                            .Col = 11
                            If CMBBOOKINGTYPE.Text = "CANCEL" And CANCEL = False Then
                                SSQL = " SELECT  ITEMTYPECODE,ITEMDESC,FROMDAYS,TODAYS,PERCENTAGE,FREEZE "
                                SSQL = SSQL & "FROM VIEW_PARTY_GROUPMASTER WHERE " & CDAY & " BETWEEN FROMDAYS AND TODAYS "
                                SSQL = SSQL & "AND ITEMTYPECODE='" & DT.Rows(I).Item("CGROUPCODE") & "'"
                                DT1 = GCONNECTION.GetValues(SSQL)
                                If DT1.Rows.Count > 0 Then
                                    .Text = Format(Math.Round((DT.Rows(I).Item("Amount") * DT1.Rows(0).Item("PERCENTAGE")) / 100, 2), "0.00")
                                Else
                                    .Text = 0
                                End If
                            Else
                                .Text = Format(DT.Rows(I).Item("CANCELAMOUNT"), "0.00")
                                If (CMBBOOKINGTYPE.Text = "BOOKING" Or CMBBOOKINGTYPE.Text = "BILLING") And CANCEL = True Then
                                    SSQL = " SELECT  ITEMTYPECODE,ITEMDESC,FROMDAYS,TODAYS,PERCENTAGE,FREEZE "
                                    SSQL = SSQL & "FROM VIEW_PARTY_GROUPMASTER WHERE " & CDAY & " BETWEEN FROMDAYS AND TODAYS "
                                    SSQL = SSQL & "AND ITEMTYPECODE='" & DT.Rows(I).Item("CGROUPCODE") & "'"
                                    DT1 = GCONNECTION.GetValues(SSQL)
                                    If DT1.Rows.Count > 0 Then
                                        .Text = Format(Math.Round((DT.Rows(I).Item("Amount") * DT1.Rows(0).Item("PERCENTAGE")) / 100, 2), "0.00")
                                    Else
                                        .Text = 0.0
                                    End If
                                End If
                            End If
                            'TXTRESCANCELAMT.Text = Format(Math.Round(TXTRESCANCELAMT.Text + Val(.Text), 2), "0.00")
                            .Row = I + 1
                            .Col = 11
                            .Lock = False
                            .Text = DT.Rows(I).Item("Roundoff")
                            .Lock = True
                            .Row = I + 1
                            .Col = 12
                            .Lock = False
                            .Text = DT.Rows(I).Item("TaxPerc")
                            .Lock = True
                            .SetActiveCell(2, I + 1)
                        Next
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
    Private Sub HALLFACILITY()
        Try
            If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                SSQL = " SELECT ITEMDESCRIPTION,UOM,QTY,BOOKINGTYPE,BOOKINGNO,HALLCODE FROM VIEW_PARTY_HALLFACILITY "
                SSQL = SSQL & " WHERE BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & TXTBOOKINGNO.Text
                SSQL = SSQL & " AND HALLCODE='" & TXTHALLCODE.Text & "'  AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                DT = GCONNECTION.GetValues(SSQL)
                If DT.Rows.Count = 0 Then
                    SSQL = " SELECT ISNULL(A.ITEMDESCRIPTION,'') AS ITEMDESCRIPTION,ISNULL(B.UOMDESC,'') AS UOM,ISNULL(A.QTY,0) AS QTY "
                    SSQL = SSQL & " FROM PARTY_HALLDETAILS A INNER JOIN UOMMASTER B ON A.UOM=B.UOMCODE AND A.HALLCODE='" & TXTHALLCODE.Text & "' AND A.FREEZE<>'Y' "
                    DT = GCONNECTION.GetValues(SSQL)
                End If
            ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                SSQL = " SELECT ITEMDESCRIPTION,UOM,QTY,BOOKINGTYPE,BOOKINGNO,HALLCODE FROM VIEW_PARTY_HALLFACILITY "
                SSQL = SSQL & " WHERE BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                DT = GCONNECTION.GetValues(SSQL)
                If DT.Rows.Count = 0 Then
                    SSQL = " SELECT ITEMDESCRIPTION,UOM,QTY,BOOKINGTYPE,BOOKINGNO,HALLCODE FROM VIEW_PARTY_HALLFACILITY "
                    SSQL = SSQL & " WHERE BOOKINGTYPE='BOOKING' AND BOOKINGNO=" & TXTBOOKINGNO.Text
                    SSQL = SSQL & " AND HALLCODE='" & TXTHALLCODE.Text & "'  AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    DT = GCONNECTION.GetValues(SSQL)
                End If
            ElseIf Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                SSQL = " SELECT ITEMDESCRIPTION,UOM,QTY,BOOKINGTYPE,BOOKINGNO,HALLCODE FROM VIEW_PARTY_HALLFACILITY "
                SSQL = SSQL & " WHERE BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                DT = GCONNECTION.GetValues(SSQL)
                If DT.Rows.Count = 0 Then
                    SSQL = " SELECT ISNULL(A.ITEMDESCRIPTION,'') AS ITEMDESCRIPTION,ISNULL(B.UOMDESC,'') AS UOM,ISNULL(A.QTY,0) AS QTY "
                    SSQL = SSQL & " FROM PARTY_HALLDETAILS A INNER JOIN UOMMASTER B ON A.UOM=B.UOMCODE AND A.HALLCODE='" & TXTHALLCODE.Text & "' AND A.FREEZE<>'Y' "
                    DT = GCONNECTION.GetValues(SSQL)
                End If
            End If
            If DT.Rows.Count > 0 Then
                With SSGRID_HALL
                    .ClearRange(-1, -1, 1, 1, True)
                    .SetActiveCell(1, 1)
                    For I = 0 To DT.Rows.Count - 1
                        .Row = I + 1
                        .Col = 1
                        .Lock = False
                        .Text = Trim(DT.Rows(I).Item("Itemdescription"))
                        '.Lock = True
                        .Row = I + 1
                        .Col = 2
                        .Lock = False
                        .Text = Trim(DT.Rows(I).Item("Uom"))
                        '.Lock = True
                        .Row = I + 1
                        .Col = 3
                        .Lock = False
                        .Text = Val(DT.Rows(I).Item("Qty"))
                        .SetActiveCell(1, I + 1)
                    Next
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ARRANGEMENT()
        Dim PD As Integer
        Dim CAMT As Double
        If UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then

        Else

            Try
                If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                    SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT,TAXCODE "
                    SSQL = SSQL & " FROM VIEW_PARTY_ARRANGEMENT WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    DT = GCONNECTION.GetValues(SSQL)
                ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Or Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                    SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT,TAXCODE "
                    SSQL = SSQL & " FROM VIEW_PARTY_ARRANGEMENT WHERE  BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' AND BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    DT = GCONNECTION.GetValues(SSQL)
                    If DT.Rows.Count = 0 Then
                        SSQL = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,CGROUPCODE,ITEMDESCRIPTION,UOM,QTY,RATE,SERTAX,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT AS CANCELAMOUNT,TAXCODE "
                        SSQL = SSQL & " FROM VIEW_PARTY_ARRANGEMENT WHERE  BOOKINGTYPE='BOOKING' AND BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        DT = GCONNECTION.GetValues(SSQL)
                    End If
                End If
                If DT.Rows.Count > 0 Then
                    TXTARRTOTALAMOUNT.Text = 0
                    TXTARRAMOUNT.Text = 0
                    TXTARRTAXAMOUNT.Text = 0
                    TXTARRCANCELAMT.Text = 0
                    With SSGRID_ARRANGE
                        .ClearRange(-1, -1, 1, 1, True)
                        .SetActiveCell(1, 1)
                        For I = 0 To DT.Rows.Count - 1
                            .Row = I + 1
                            .Col = 1
                            .Lock = False
                            .Text = DT.Rows(I).Item("Itemcode")

                            .Row = I + 1
                            .Col = 2
                            .Lock = False
                            .Text = DT.Rows(I).Item("Itemdescription")

                            .Row = I + 1
                            .Col = 3
                            .Lock = False
                            .Text = DT.Rows(I).Item("Uom")

                            .Row = I + 1
                            .Col = 4
                            .Lock = False
                            .Text = Format(DT.Rows(I).Item("rate"), "0")

                            .Row = I + 1
                            .Col = 5
                            .Text = Format(DT.Rows(I).Item("qty"), "0.00")

                            .Row = I + 1
                            .Col = 6
                            .Lock = False
                            '.Text = Format(DT.Rows(I).Item("Taxamount"), "0.00")
                            .Text = Format(DT.Rows(I).Item("Taxamount") + DT.Rows(I).Item("SERTAX"), "0.00")
                            TXTARRTAXAMOUNT.Text = Format(TXTARRTAXAMOUNT.Text + Val(.Text), "0.00")

                            .Row = I + 1
                            .Col = 7
                            .Lock = False
                            .Text = Format(DT.Rows(I).Item("Amount"), "0.00")
                            TXTARRAMOUNT.Text = Format(TXTARRAMOUNT.Text + Val(.Text), "0.00")

                            .Lock = True

                            .Row = I + 1
                            .Col = 8
                            .Lock = False
                            '.Text = Format(DT.Rows(I).Item("TOTALAMOUNT"), "0.00")
                            .Text = Format(DT.Rows(I).Item("AMOUNT") + DT.Rows(I).Item("Taxamount") + DT.Rows(I).Item("SERTAX"), "0.00")
                            TXTARRTOTALAMOUNT.Text = Format(Math.Round(TXTARRTOTALAMOUNT.Text + Val(.Text), 2), "0.00")
                            .Lock = True


                            .Row = I + 1
                            .Col = 9
                            .Lock = False
                            .Text = DT.Rows(I).Item("Taxcode").ToString
                            'If CMBBOOKINGTYPE.Text = "CANCEL" And CANCEL = False Then
                            '    SSQL = " SELECT  ITEMTYPECODE,ITEMDESC,FROMDAYS,TODAYS,PERCENTAGE,FREEZE "
                            '    SSQL = SSQL & "FROM VIEW_PARTY_GROUPMASTER WHERE " & CDAY & " BETWEEN FROMDAYS AND TODAYS "
                            '    SSQL = SSQL & "AND ITEMTYPECODE='" & DT.Rows(I).Item("CGROUPCODE") & "'"
                            '    DT1 = GCONNECTION.GetValues(SSQL)
                            '    If DT1.Rows.Count > 0 Then
                            '        .Text = Format(Math.Round((DT.Rows(I).Item("Amount") * DT1.Rows(0).Item("PERCENTAGE")) / 100, 2), "0.00")
                            '    Else
                            '        .Row = I + 1
                            '        .Col = 9
                            '        Text = 0.0
                            '    End If
                            'Else
                            '    .Row = I + 1
                            '    .Col = 9
                            '    .Text = Format(DT.Rows(I).Item("CANCELAMOUNT"), "0.00")
                            '    If (CMBBOOKINGTYPE.Text = "BOOKING" Or CMBBOOKINGTYPE.Text = "BILLING") And CANCEL = True Then
                            '        SSQL = " SELECT  ITEMTYPECODE,ITEMDESC,FROMDAYS,TODAYS,PERCENTAGE,FREEZE "
                            '        SSQL = SSQL & "FROM VIEW_PARTY_GROUPMASTER WHERE " & CDAY & " BETWEEN FROMDAYS AND TODAYS "
                            '        SSQL = SSQL & "AND ITEMTYPECODE='" & DT.Rows(I).Item("CGROUPCODE") & "'"
                            '        DT1 = GCONNECTION.GetValues(SSQL)
                            '        If DT1.Rows.Count > 0 Then
                            '            .Text = Format(Math.Round((DT.Rows(I).Item("Amount") * DT1.Rows(0).Item("PERCENTAGE")) / 100, 2), "0.00")
                            '        Else
                            '            .Text = 0
                            '        End If
                            '    End If
                            'End If
                            'TXTARRCANCELAMT.Text = Format(TXTARRCANCELAMT.Text + Val(.Text), "0.00")
                            .Row = I + 1
                            .Col = 10
                            .Text = Format(DT.Rows(I).Item("Roundoff"), "0.00")
                            .Lock = False
                            .Lock = True

                            .Row = I + 1
                            .Col = 11
                            .Lock = False
                            .Text = Format(DT.Rows(I).Item("TaxPerc"), "0.00")
                            .Lock = True
                            .SetActiveCell(1, I + 1)
                        Next
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub
    Private Sub TXTMCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTMCODE.Validated
        Try
            If TXTMCODE.Text <> "" Then
                TXTMNAME.ReadOnly = False
                TXTMNAME.Enabled = True
                SSQL = "Select mname From MemberMaster Where Mcode='" & Trim(TXTMCODE.Text) & "' "
                GCONNECTION.getDataSet(SSQL, "MemberMaster")
                If gdataset.Tables("MemberMaster").Rows.Count > 0 Then
                    TXTMNAME.Text = ""
                    TXTMNAME.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("Mname"))
                    TXTMNAME.ReadOnly = True
                    TxtOCCUPANCY.Focus()
                Else
                    TXTMCODE.Clear()
                    TXTMNAME.Clear()
                    TXTMCODE.Focus()
                End If
            Else
                TXTMNAME.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TXTHALLCODE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTHALLCODE.Validated
        Try
            If TXTHALLCODE.Text <> "" Then
                txtHALLDESCRIPTION.ReadOnly = False
                txtHALLDESCRIPTION.Enabled = True
                SSQL = "Select halldescription From PARTY_HALLMASTER Where hallcode='" & Trim(TXTHALLCODE.Text) & "' "
                GCONNECTION.getDataSet(SSQL, "HallMaster")
                If gdataset.Tables("HallMaster").Rows.Count > 0 Then
                    txtHALLDESCRIPTION.Text = ""
                    txtHALLDESCRIPTION.Text = Trim(gdataset.Tables("HallMaster").Rows(0).Item("HAlldescription"))
                    txtHALLDESCRIPTION.ReadOnly = True
                    TXTHALLRENT.Focus()
                Else
                    TXTHALLCODE.Clear()
                    txtHALLDESCRIPTION.Clear()
                    TXTHALLRENT.Focus()
                End If
            Else
                txtHALLDESCRIPTION.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub SSGRID_HALL_KeyDownEvent(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID_HALL.KeyDownEvent
        Try
            If e.keyCode = Keys.Enter Then
                With SSGRID_HALL
                    If .ActiveCol = 1 Then
                        .Col = 1
                        .Row = .ActiveRow
                        If Trim(.Text) = "" Then
                            .SetActiveCell(1, .ActiveRow)
                            Call Hallhelp()
                        Else
                            .Col = 1
                            .Row = .ActiveRow
                            SSQL = " SELECT ITEMDESCRIPTION,UOM FROM VIEW_PARTY_HELPHALLFACILITY "
                            SSQL = SSQL & " WHERE ISNULL(ITEMDESCRIPTION,'')='" & Trim(.Text) & "'"
                            DT = GCONNECTION.GetValues(SSQL)
                            If DT.Rows.Count > 0 Then
                                .Col = 1
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""
                                .Text = Trim(DT.Rows(0).Item("ITEMDESCRIPTION"))
                                '.Lock = True
                                .SetActiveCell(2, .ActiveRow)
                                .Col = 2
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""
                                .Text = Trim(DT.Rows(0).Item("Uom"))
                            Else
                                .SetActiveCell(1, .ActiveRow)
                                .Col = 1
                                .Text = ""
                            End If
                            .SetActiveCell(3, .ActiveRow)
                        End If
                    ElseIf .ActiveCol = 2 Then
                        .Col = 2
                        .Row = .ActiveRow
                        If Trim(.Text) = "" Then
                            .SetActiveCell(2, .ActiveRow)
                        Else
                            SSQL = " SELECT ISNULL(A.UOM,'') AS UOMCODE,ISNULL(UOMDESC,'') AS UOMDESC FROM "
                            SSQL = SSQL & " UOMMaster where uomdesc='" & Trim(.Text) & "'"
                            DT = GCONNECTION.GetValues(SSQL)
                            If DT.Rows.Count = 0 Then
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
                With SSGRID_HALL
                    .Row = .ActiveRow
                    .DeleteRows(.ActiveRow, 1)
                    If .ActiveRow <= 1 Then
                        .SetActiveCell(1, .ActiveRow)
                    Else
                        .SetActiveCell(1, .ActiveRow - 1)
                    End If
                End With
            End If
            If e.keyCode = Keys.F4 Then
                If SSGRID_HALL.ActiveCol = 1 Then
                    Call Hallhelp()
                ElseIf SSGRID_HALL.ActiveCol = 2 Then
                    Dim vform As New ListOperattion1
                    gSQLString = " SELECT ISNULL(UOMCODE,'') AS UOMCODE,ISNULL(UOMDESC,'') AS UOMDESC FROM UOMMASTER"
                    If Trim(Search) = " " Then
                        M_WhereCondition = ""
                    Else
                        M_WhereCondition = ""
                    End If
                    vform.Field = "UOMCODE,UOMDESC"
                    vform.vFormatstring = " UOMCODE   | DESCRIPTION             "
                    vform.vCaption = "HALL DETAILS HELP"
                    vform.KeyPos = 0
                    vform.KeyPos1 = 1
                    vform.ShowDialog(Me)
                    If Trim(vform.keyfield & "") <> "" Then
                        With SSGRID_HALL
                            .Col = 2
                            .Row = .ActiveRow
                            .Text = ""
                            .Text = Trim(vform.keyfield & "")
                            .SetActiveCell(3, .ActiveRow)
                            .Col = 3
                            .Row = .ActiveRow
                            .Text = ""
                        End With
                    End If
                    vform.Close()
                    vform = Nothing
                Else
                    SSGRID_HALL.SetActiveCell(1, SSGRID_HALL.ActiveRow + 1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function Hallhelp()
        Dim vform As New ListOperattion1
        gSQLString = " SELECT ITEMDESCRIPTION,UOM FROM VIEW_PARTY_HELPHALLFACILITY "
        If Trim(Search) = "" Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "ITEMDESCRIPTION,UOM"
        vform.vFormatstring = "     ITEMDESCRIPTION                 |  UOM       "
        vform.vCaption = "HALL DETAILS HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With SSGRID_HALL
                .Col = 1
                .Row = .ActiveRow
                .Text = ""
                .Text = Trim(vform.keyfield & "")
                .SetActiveCell(2, .ActiveRow)
                .Col = 2
                .Row = .ActiveRow
                .Text = ""
                .Text = Trim(vform.keyfield1 & "")
                .SetActiveCell(3, .ActiveRow)
                .Col = 3
                .Row = .ActiveRow
                '.Text = ""
            End With
        End If
        vform.Close()
        vform = Nothing
    End Function
    Private Sub SSGRID_HALL_LeaveCell(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles SSGRID_HALL.LeaveCell
        Try
            With SSGRID_HALL
                If .ActiveCol = 1 Then
                    .Col = 1
                    .Row = .ActiveRow
                    If Trim(.Text()) = "" Then
                        '.SetActiveCell(1, .ActiveRow)
                    End If
                End If
                If .ActiveCol = 2 Then
                    .Col = 2
                    .Row = .ActiveRow
                    SSQL = " SELECT ISNULL(UOMCODE,'') AS UOMCODE,ISNULL(UOMDESC,'') AS UOMDESC FROM "
                    SSQL = SSQL & " UOMMaster where uomdesc='" & Trim(.Text) & "'"
                    DT = GCONNECTION.GetValues(SSQL)
                    If DT.Rows.Count = 0 Then
                        '.SetActiveCell(2, .ActiveRow)
                    End If
                End If
                If .ActiveCol = 3 Then
                    .Col = 3
                    .Row = .ActiveRow
                    If Val(.Text()) = 0 Then
                        '.SetActiveCell(3, .ActiveRow)
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Private Sub RDBHALLFACILITY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBHALLFACILITY.CheckedChanged
    '    If RDBHALLFACILITY.Checked = True Then
    '        'GBHALLFACILITY.Visible = True
    '        GBHALLFACILITY.Visible = False
    '        GBARRANGEDETAILS.Visible = False
    '        GBMENUDETAILS.Visible = False
    '        GBHALLFACILITY.Top = 12
    '        GBHALLFACILITY.Top = 296
    '        GRP_TARIFF.Visible = False
    '        SSGRID_HALL.Focus()
    '        '   SSGRID_HALL.SetActiveCell(1, 1)
    '    End If
    'End Sub
    Private Sub RDBARRITEM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBARRITEM.CheckedChanged
        If RDBARRITEM.Checked = True Then
            GBHALLFACILITY.Visible = False
            GBARRANGEDETAILS.Visible = True
            GBMENUDETAILS.Visible = False
            GRP_TARIFF.Visible = False
            GBARRANGEDETAILS.Top = 12
            GBARRANGEDETAILS.Top = 300
            SSGRID_ARRANGE.Focus()
            'SSGRID_ARRANGE.SetActiveCell(1, 1)
        End If
    End Sub
    Private Sub RDBRESMENU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBRESMENU.CheckedChanged
        If RDBRESMENU.Checked = True Then
            GBHALLFACILITY.Visible = False
            GBARRANGEDETAILS.Visible = False
            GBMENUDETAILS.Visible = True
            GBHALLBOOKING.Visible = False
            GRP_TARIFF.Visible = False
            TXT_DISAMT.Visible = False
            TXT_TOTAMT.Visible = False
            TXTB_BAMOUNT.Visible = False
            'GBMENUDETAILS.Top = 12
            'GBMENUDETAILS.Top = 296
            'Me.TXTRESTOTALAMOUNT.Text = "0.00"
            GBMENUDETAILS.Top = 12
            GBMENUDETAILS.Top = 302
            SSGRID.Focus()
            'SSGRID_MENU.SetActiveCell(1, 1)
        End If
    End Sub

    Private Sub SSGRID_ARRANGE_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID_ARRANGE.KeyDownEvent
        Dim Itemcode, OP As String
        Dim CDAY As Integer
        Dim rate, qty, TAXAMOUNT, AMOUNT, TAXPER As Double
        Try
            If e.keyCode = Keys.Enter Then
                With SSGRID_ARRANGE
                    If .ActiveCol = 1 Then
                        .Col = 1
                        .Row = .ActiveRow
                        If Trim(.Text) = "" Then
                            '.SetActiveCell(1, .ActiveRow)
                            Call ARRITEMCODEHELP()

                        Else
                            SSQL = "SELECT ITEMCODE,ITEMDESC,UOMCODE,RATE,OPENFACILITY,TAXCODE FROM PARTY_ITEMMASTER  WHERE ITEMCODE='" & Trim(.Text) & "'"
                            DT = GCONNECTION.GetValues(SSQL)
                            If DT.Rows.Count > 0 Then
                                .Col = 1
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""
                                .Text = Trim(DT.Rows(0).Item("ITEMCODE"))
                                .Lock = True

                                Dim K, CCT As Integer
                                Dim ITC As String
                                For J = 1 To SSGRID_ARRANGE.DataRowCnt + 1
                                    'Dim ITC
                                    SSGRID_ARRANGE.Col = 2
                                    SSGRID_ARRANGE.Row = J
                                    ITC = SSGRID_ARRANGE.Text
                                    For K = 1 To SSGRID_ARRANGE.DataRowCnt + 1
                                        SSGRID_ARRANGE.Col = 2
                                        SSGRID_ARRANGE.Row = K
                                        If Trim(SSGRID_ARRANGE.Text) = ITC Then
                                            CCT = CCT + 1
                                        End If
                                    Next
                                    If CCT > 1 Then
                                        If MsgBox("Duplication Item Not Allowed...." & Itemcode, MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton1, "DELETE DUPLICATE") = MsgBoxResult.Ok Then
                                            SSGRID_ARRANGE.Row = I
                                            SSGRID_ARRANGE.ClearRange(1, I, 15, I, True)
                                            SSGRID_ARRANGE.DeleteRows(I, 1)
                                            SSGRID_ARRANGE.Row = I
                                            SSGRID_ARRANGE.Col = 1
                                            SSGRID_ARRANGE.Lock = False
                                            SSGRID_ARRANGE.Col = 2
                                            SSGRID_ARRANGE.Lock = False
                                            SSGRID_ARRANGE.Col = 3
                                            SSGRID_ARRANGE.Lock = False
                                            SSGRID_ARRANGE.Col = 4
                                            SSGRID_ARRANGE.Lock = False
                                            SSGRID_ARRANGE.Col = 5
                                            SSGRID_ARRANGE.Lock = False
                                            SSGRID_ARRANGE.SetActiveCell(1, I)
                                        Else
                                            SSGRID_ARRANGE.ClearRange(1, SSGRID_ARRANGE.ActiveRow, 15, SSGRID_ARRANGE.ActiveRow, True)
                                            SSGRID_ARRANGE.SetActiveCell(1, I)
                                            SSGRID_ARRANGE.Focus()
                                        End If

                                        ' MsgBox("duplicate item entry")
                                        Exit Sub
                                    End If
                                    CCT = 0
                                Next
                                J = 0
                                ' SSGRID_ARRANGE.ClearRange(1, SSGRID_ARRANGE.ActiveRow, 15, SSGRID_ARRANGE.ActiveRow, True)


                                .SetActiveCell(2, .ActiveRow)
                                .Col = 2
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""
                                .Text = Trim(DT.Rows(0).Item("ITEMDESC"))
                                .Lock = True
                                .SetActiveCell(3, .ActiveRow)

                                .Col = 3
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""
                                .Text = Trim(DT.Rows(0).Item("UOMCODE"))
                                .Lock = True
                                .SetActiveCell(4, .ActiveRow)

                                OP = Trim(DT.Rows(0).Item("OPENFACILITY"))
                                .Col = 4
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""

                                If OP = "Y" Then
                                    .Text = ""
                                    .Lock = False
                                    .Focus()


                                Else
                                    .Col = 4
                                    .Row = .ActiveRow
                                    .Text = ""
                                    .Lock = False
                                    .Text = Trim(DT.Rows(0).Item("RATE"))
                                    .Lock = True
                                    .SetActiveCell(5, .ActiveRow)

                                End If

                                .Col = 9
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""
                                .Text = Trim(DT.Rows(0).Item("TAXCODE"))
                                .Lock = True
                                '  .SetActiveCell(4, .ActiveRow)
                                '' ''If Trim(DT.Rows(0).Item("OPENFACILITY")) = "Y" Then
                                '' ''    '.Col = 4
                                '' ''    '.Row = .ActiveRow
                                '' ''    '.Lock = False
                                '' ''    '.Text = ""
                                '' ''    '.Text = DT.Rows(0).Item("RATE")
                                '' ''    '.Lock = True
                                '' ''    '.SetActiveCell(5, .ActiveRow)
                                '' ''Else
                                '' ''    .Col = 4
                                '' ''    .Row = .ActiveRow
                                '' ''    .Lock = False
                                '' ''    .Text = ""
                                '' ''    .Text = Trim(DT.Rows(0).Item("RATE"))
                                '' ''    .Lock = True
                                '' ''    .SetActiveCell(5, .ActiveRow)
                                '' ''End If

                            Else
                                .SetActiveCell(1, .ActiveRow)
                                .Col = 1
                                .Text = ""
                            End If
                        End If
                    ElseIf .ActiveCol = 2 Then
                        If Trim(.Text) = "" Then
                            .SetActiveCell(2, .ActiveRow)
                        Else
                            .SetActiveCell(3, .ActiveRow)
                        End If
                    ElseIf .ActiveCol = 3 Then
                        If Trim(.Text) = "" Then
                            .SetActiveCell(3, .ActiveRow)
                        Else
                            .SetActiveCell(4, .ActiveRow)
                        End If
                    ElseIf .ActiveCol = 4 Then
                        If Trim(.Text) = "" Then
                            .SetActiveCell(4, .ActiveRow)
                        Else
                            .SetActiveCell(5, .ActiveRow)
                        End If
                        '.SetActiveCell(5, .ActiveRow)
                    ElseIf .ActiveCol = 5 Then
                        .Col = 5
                        .Row = .ActiveRow
                        If Val(.Text) = 0 Then
                            .SetActiveCell(5, .ActiveRow)
                            .Focus()
                        Else
                            .Col = 1
                            .Row = .ActiveRow
                            Itemcode = .Text

                            .Col = 4
                            .Row = .ActiveRow
                            rate = Val(.Text)

                            .Col = 5
                            .Row = .ActiveRow
                            qty = Val(.Text)

                            .Col = 11
                            .Row = .ActiveRow
                            TAXPER = Val(.Text)




                            Call ARRANGEcalculate()
                            ' '' '' '' ''.Col = 6
                            ' '' '' '' ''.Row = .ActiveRow
                            ' '' '' '' ''.Lock = True
                            '' '' '' '' ''TAXAMOUNT = Math.Round(Arrcalc(Itemcode, rate, qty), 2)
                            '' '' '' '' ''.Text = TAXAMOUNT
                            ''''''''''  TXTARRTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID_ARRANGE), 2), "0.00")
                            '' '' '' '' ''.Lock = True
                            '' '' '' '' ''==========================
                            ' '' '' '' ''SSQL = "select sum(cast(taxpercentage as numeric(10,2))) as perc from accountstaxmaster where taxcode in(select isnull(itemtypecode,'') from PARTY_ARRANGEMASTER_TAX where ARRCODE='" & Itemcode & "')"
                            ' '' '' '' ''GCONNECTION.getDataSet(SSQL, "tax")
                            ' '' '' '' ''If gdataset.Tables("tax").Rows.Count > 0 Then
                            ' '' '' '' ''    TAXAMOUNT = Math.Round(rate * gdataset.Tables("tax").Rows(0).Item("perc")) / 100
                            ' '' '' '' ''    .Text = TAXAMOUNT
                            ' '' '' '' ''    TXTARRTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID_ARRANGE), 2), "0.00")
                            ' '' '' '' ''    .Lock = True
                            ' '' '' '' ''Else
                            ' '' '' '' ''    TAXAMOUNT = Math.Round(Arrcalc(Itemcode, rate, qty), 2)
                            ' '' '' '' ''    .Text = TAXAMOUNT
                            ' '' '' '' ''    TXTARRTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID_ARRANGE), 2), "0.00")
                            ' '' '' '' ''    .Lock = True
                            ' '' '' '' ''End If
                            '' '' '' '' ''================================================
                            '.Col = 6
                            '.Row = .ActiveRow
                            '.Lock = True
                            'TAXAMOUNT = .Text
                            'TXTARRTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID_ARRANGE), 2), "0.00")

                            ' TXTARRTAXAMOUNT.Text = Val(TAXAMOUNT)

                            .Col = 7
                            .Row = .ActiveRow
                            .Lock = False
                            .Text = Math.Round((qty * rate), 2)
                            AMOUNT = Val(.Text)
                            TXTARRAMOUNT.Text = Format(Math.Round(Itemamt(SSGRID_ARRANGE), 2), "0.00")
                            .Lock = True

                            .Col = 8
                            .Row = .ActiveRow
                            .Lock = False
                            .Text = Math.Round((TAXAMOUNT + AMOUNT), 2)
                            TXTARRTOTALAMOUNT.Text = Format(Math.Round(TOT_AMT(SSGRID_ARRANGE), 0), "0.00")
                            .Lock = True
                            Call ARRANGEcalculate()

                            .Col = 10
                            .Row = .ActiveRow
                            .Lock = False
                            .Text = 0.0
                            '.Text = Math.Round(Math.Round(TAXAMOUNT + AMOUNT, 0) - Math.Round((TAXAMOUNT + AMOUNT), 2), 2)
                            .Lock = True


                            .Col = 11
                            .Row = .ActiveRow
                            .Lock = False
                            .Text = 0.0
                            .Lock = True

                            '' '' ''.Col = 11
                            '' '' ''.Row = .ActiveRow
                            '' '' ''.Text = ""
                            '' '' ''.Lock = False
                            '' '' ''.Text = Math.Round(taxperc(Itemcode), 2)
                            '' '' ''.SetActiveCell(6, .ActiveRow)
                            '' '' ''.Lock = True
                            .SetActiveCell(1, .ActiveRow + 1)
                        End If
                    ElseIf .ActiveCol = 6 Then
                        If Trim(.Text) = "" Then
                            .SetActiveCell(1, .ActiveRow)
                        Else
                            .SetActiveCell(1, .ActiveRow + 1)
                        End If
                    ElseIf .ActiveCol = 9 Then
                        Call ARRANGEcalculate()
                        .SetActiveCell(1, .ActiveRow + 1)
                    Else
                        .SetActiveCell(1, .ActiveRow + 1)
                    End If
                End With
            End If
            If e.keyCode = Keys.F3 Then
                With SSGRID_ARRANGE
                    .Row = .ActiveRow
                    .DeleteRows(.ActiveRow, 1)
                    If .ActiveRow <= 1 Then
                        .SetActiveCell(1, .ActiveRow)
                    Else
                        .SetActiveCell(1, .ActiveRow - 1)
                    End If
                    TXTARRTOTALAMOUNT.Text = Format(Math.Round(TOT_AMT(SSGRID_ARRANGE), 0), "0.00")
                    TXTARRAMOUNT.Text = Format(Math.Round(Itemamt(SSGRID_ARRANGE), 2), "0.00")
                    TXTARRTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID_ARRANGE), 2), "0.00")
                End With
            End If
            If e.keyCode = Keys.F4 Then
                Call ARRITEMCODEHELP()
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function ARRITEMCODEHELP()
        Dim OP As String
        Dim vform As New LIST_OPERATION1
        If SSGRID_ARRANGE.ActiveCol = 1 Then
            gSQLString = " SELECT ITEMCODE,ITEMDESC,UOMCODE,RATE,OPENFACILITY,TAXCODE FROM PARTY_ITEMMASTER"
            If Trim(Search) = "" Then
                M_WhereCondition = ""
            Else
                M_WhereCondition = ""
            End If
            vform.Field = "ITEMCODE,ITEMDESC,UOMCODE,RATE,OPENFACILITY,TAXCODE"
            ' vform.vFormatstring = "ITEMCODE                      |DESCRIPTION                |UOM              | RATE   "
            vform.vCaption = "ARRANGEMENT DETAILS HELP"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            'vform.Keypos3 = 3
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                With SSGRID_ARRANGE

                    .Col = 1
                    .Row = .ActiveRow
                    .Lock = False
                    .Text = ""
                    .Text = Trim(vform.keyfield & "")
                    .Lock = True
                    .SetActiveCell(2, .ActiveRow)

                    .Col = 2
                    .Row = .ActiveRow
                    .Lock = False
                    .Text = ""
                    .Text = Trim(vform.keyfield1 & "")
                    .Lock = True
                    .SetActiveCell(3, .ActiveRow)

                    .Col = 3
                    .Row = .ActiveRow
                    .Lock = False
                    .Text = ""
                    .Text = Trim(vform.keyfield2 & "")
                    .Lock = True
                    .SetActiveCell(4, .ActiveRow)

                    .Col = 4
                    .Row = .ActiveRow
                    .Lock = False
                    .Text = ""
                    .Text = Trim(vform.keyfield3 & "")
                    .Lock = True
                    OP = Trim(vform.keyfield4 & "")
                    .SetActiveCell(4, .ActiveRow)

                    If OP = "Y" Then
                        .Text = ""
                        .Lock = False
                        .Focus()


                    Else
                        .Col = 4
                        .Row = .ActiveRow
                        .Text = ""
                        .Lock = False
                        .Text = Trim(vform.keyfield3 & "")
                        .Lock = True
                        .SetActiveCell(5, .ActiveRow)

                    End If

                    .Col = 9
                    .Text = ""
                    .Lock = False
                    .Text = Trim(vform.keyfield5 & "")
                    .Lock = True


                    Dim K, CCT As Integer
                    Dim ITC As String
                    For J = 1 To SSGRID_ARRANGE.DataRowCnt + 1
                        'Dim ITC
                        SSGRID_ARRANGE.Col = 1
                        SSGRID_ARRANGE.Row = J
                        ITC = SSGRID_ARRANGE.Text
                        For K = 1 To SSGRID_ARRANGE.DataRowCnt + 1
                            SSGRID_ARRANGE.Col = 1
                            SSGRID_ARRANGE.Row = K
                            If Trim(SSGRID_ARRANGE.Text) = ITC Then
                                CCT = CCT + 1
                            End If
                        Next
                        If CCT > 1 Then
                            If MsgBox("Duplication Item Not Allowed...." & ITEMCODE, MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton1, "DELETE DUPLICATE") = MsgBoxResult.Ok Then
                                SSGRID_ARRANGE.Row = I
                                SSGRID_ARRANGE.ClearRange(1, I, 15, I, True)
                                SSGRID_ARRANGE.DeleteRows(I, 1)
                                SSGRID_ARRANGE.Row = I
                                SSGRID_ARRANGE.Col = 1
                                SSGRID_ARRANGE.Lock = False
                                SSGRID_ARRANGE.Col = 2
                                SSGRID_ARRANGE.Lock = False
                                SSGRID_ARRANGE.Col = 3
                                SSGRID_ARRANGE.Lock = False
                                SSGRID_ARRANGE.Col = 4
                                SSGRID_ARRANGE.Lock = False
                                SSGRID_ARRANGE.Col = 5
                                SSGRID_ARRANGE.Lock = False
                                SSGRID_ARRANGE.SetActiveCell(1, I)
                            Else
                                SSGRID_ARRANGE.ClearRange(1, SSGRID_ARRANGE.ActiveRow, 15, SSGRID_ARRANGE.ActiveRow, True)
                                SSGRID_ARRANGE.SetActiveCell(1, I)
                                SSGRID_ARRANGE.Focus()
                            End If

                            ' MsgBox("duplicate item entry")
                            Exit Function
                        End If
                        CCT = 0
                    Next
                    J = 0


                End With
            End If
        ElseIf SSGRID_ARRANGE.ActiveCol = 2 Then
            With SSGRID_ARRANGE
                .SetActiveCell(3, .ActiveRow)
            End With

        ElseIf SSGRID_ARRANGE.ActiveCol = 5 Then
          
        Else
            SSGRID_ARRANGE.SetActiveCell(1, SSGRID_ARRANGE.ActiveRow + 1)
            vform.Close()
            vform = Nothing
        End If
    End Function
    Private Sub SSGRID_ARRANGE_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles SSGRID_ARRANGE.LeaveCell
        Try
            Dim Itemcode, OP As String
            Dim rate, qty, TAXAMOUNT, AMOUNT As Double
            With SSGRID_ARRANGE
                If .ActiveCol = 1 Then
                    .Col = 1
                    .Row = .ActiveRow
                    Itemcode = .Text
                    If Trim(.Text()) = "" Then
                        ''.SetActiveCell(1, .ActiveRow)
                    End If

                    'Dim K, CCT As Integer
                    'Dim ITC As String
                    'For J = 1 To SSGRID_ARRANGE.DataRowCnt + 1
                    '    'Dim ITC
                    '    SSGRID_ARRANGE.Col = 1
                    '    SSGRID_ARRANGE.Row = J
                    '    ITC = SSGRID_ARRANGE.Text
                    '    For K = 1 To SSGRID_ARRANGE.DataRowCnt + 1
                    '        SSGRID_ARRANGE.Col = 1
                    '        SSGRID_ARRANGE.Row = K
                    '        If Trim(SSGRID_ARRANGE.Text) = ITC Then
                    '            CCT = CCT + 1
                    '        End If
                    '    Next
                    '    If CCT > 1 Then
                    '        If MsgBox("Duplication Item Not Allowed...." & Itemcode, MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton1, "DELETE DUPLICATE") = MsgBoxResult.Ok Then
                    '            SSGRID_ARRANGE.Row = I
                    '            SSGRID_ARRANGE.ClearRange(1, I, 15, I, True)
                    '            SSGRID_ARRANGE.DeleteRows(I, 1)
                    '            SSGRID_ARRANGE.Row = I
                    '            SSGRID_ARRANGE.Col = 1
                    '            SSGRID_ARRANGE.Lock = False
                    '            SSGRID_ARRANGE.Col = 2
                    '            SSGRID_ARRANGE.Lock = False
                    '            SSGRID_ARRANGE.Col = 3
                    '            SSGRID_ARRANGE.Lock = False
                    '            SSGRID_ARRANGE.Col = 4
                    '            SSGRID_ARRANGE.Lock = False
                    '            SSGRID_ARRANGE.Col = 5
                    '            SSGRID_ARRANGE.Lock = False
                    '            SSGRID_ARRANGE.SetActiveCell(1, I)
                    '        Else
                    '            SSGRID_ARRANGE.SetActiveCell(1, I)
                    '            SSGRID_ARRANGE.Focus()
                    '        End If

                    '        ' MsgBox("duplicate item entry")
                    '        Exit Sub
                    '    End If
                    '    CCT = 0
                    'Next
                    'J = 0
                    ' SSGRID_ARRANGE.ClearRange(1, SSGRID_ARRANGE.ActiveRow, 15, SSGRID_ARRANGE.ActiveRow, True)

                End If
                If .ActiveCol = 2 Then
                    .Col = 2
                    .Row = .ActiveRow
                    If Trim(.Text()) = "" Then
                        ''.SetActiveCell(1, .ActiveRow)
                    End If
                End If
                If .ActiveCol = 3 Then
                    .Col = 3
                    .Row = .ActiveRow
                    SSQL = " SELECT ISNULL(UOMCODE,'') AS UOMCODE,ISNULL(UOMDESC,'') AS UOMDESC FROM "
                    SSQL = SSQL & " UOMMaster where uomdesc='" & Trim(.Text) & "'"
                    DT = GCONNECTION.GetValues(SSQL)
                    If DT.Rows.Count = 0 Then
                        ''.SetActiveCell(1, .ActiveRow)
                    End If
                End If

                '' '' '' ''If .ActiveCol = 4 Then
                '' '' '' ''    .Col = 4
                '' '' '' ''    .Row = .ActiveRow
                '' '' '' ''    SSQL = "SELECT ITEMCODE,ITEMDESC,UOMCODE,RATE,OPENFACILITY FROM PARTY_ITEMMASTER  WHERE ITEMCODE='" & Itemcode & "'"
                '' '' '' ''    DT = GCONNECTION.GetValues(SSQL)
                '' '' '' ''    If DT.Rows.Count > 0 Then

                '' '' '' ''        OP = Trim(DT.Rows(0).Item("OPENFACILITY"))
                '' '' '' ''        .Col = 4
                '' '' '' ''        .Row = .ActiveRow
                '' '' '' ''        .Lock = False
                '' '' '' ''        .Text = ""

                '' '' '' ''        If OP = "Y" Then
                '' '' '' ''            .Text = ""
                '' '' '' ''            .Lock = False
                '' '' '' ''            .Focus()


                '' '' '' ''        Else
                '' '' '' ''            .Col = 4
                '' '' '' ''            .Row = .ActiveRow
                '' '' '' ''            .Text = ""
                '' '' '' ''            .Lock = False
                '' '' '' ''            .Text = Trim(DT.Rows(0).Item("RATE"))
                '' '' '' ''            .Lock = True
                '' '' '' ''            .SetActiveCell(5, .ActiveRow)

                '' '' '' ''        End If

                '' '' '' ''        '' ''If Trim(DT.Rows(0).Item("OPENFACILITY")) = "Y" Then
                '' '' '' ''        '' ''   .SetActiveCell(4, .ActiveRow)
                '' '' '' ''        '' ''    .Focus()
                '' '' '' ''        '' ''Else
                '' '' '' ''        '' ''    .Col = 4
                '' '' '' ''        '' ''    .Row = .ActiveRow
                '' '' '' ''        '' ''    .Lock = False
                '' '' '' ''        '' ''    .Text = ""
                '' '' '' ''        '' ''    .Text = Trim(DT.Rows(0).Item("RATE"))
                '' '' '' ''        '' ''    .Lock = True
                '' '' '' ''        '' ''    .SetActiveCell(5, .ActiveRow)
                '' '' '' ''        '' ''End If



                '' '' '' ''    Else
                '' '' '' ''        .SetActiveCell(5, .ActiveRow)
                '' '' '' ''        .Focus()

                '' '' '' ''    End If

                '' '' '' ''End If

                If .ActiveCol = 5 Then
                    .Col = 5
                    .Row = .ActiveRow
                    If Val(.Text) = 0 Then
                        .SetActiveCell(5, .ActiveRow)
                        .Focus()
                    Else
                        .Col = 1
                        .Row = .ActiveRow
                        Itemcode = .Text
                        '
                        .SetActiveCell(4, .ActiveRow)
                        .Focus()
                        .Col = 4
                        '
                        .Row = .ActiveRow
                        rate = Val(.Text)


                        .Col = 5
                        .Row = .ActiveRow
                        qty = Val(.Text)
                        '========
                        .Col = 6
                        .Row = .ActiveRow
                        .Lock = True
                        'SSQL = "select sum(cast(taxpercentage as numeric(10,2))) as perc from accountstaxmaster where taxcode in(select isnull(itemtypecode,'') from PARTY_ARRANGEMASTER_TAX where ARRCODE='" & Itemcode & "')"
                        'GCONNECTION.getDataSet(SSQL, "tax")
                        'If gdataset.Tables("tax").Rows.Count > 0 Then
                        '    TAXAMOUNT = Math.Round(rate * gdataset.Tables("tax").Rows(0).Item("perc")) / 100
                        '    .Text = TAXAMOUNT
                        '    TXTARRTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID_ARRANGE), 2), "0.00")
                        '    .Lock = True
                        'Else
                        '    TAXAMOUNT = Math.Round(Arrcalc(Itemcode, rate, qty), 2)
                        '    .Text = TAXAMOUNT
                        '    TXTARRTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID_ARRANGE), 2), "0.00")
                        '    .Lock = True
                        'End If
                        '================================================

                        '.Col = 6
                        '.Row = .ActiveRow
                        '.Lock = False
                        '.Text = ""
                        'TAXAMOUNT = Math.Round(Arrcalc(Itemcode, rate, qty), 2)
                        '.Text = TAXAMOUNT
                        'TXTARRTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID_ARRANGE), 2), "0.00")
                        '.Lock = True

                        .Col = 7
                        .Row = .ActiveRow
                        .Lock = False
                        .Text = Math.Round((qty * rate), 2)
                        AMOUNT = Val(.Text)
                        TXTARRAMOUNT.Text = Format(Math.Round(Itemamt(SSGRID_ARRANGE), 2), "0.00")
                        .Lock = True

                        Call ARRANGEcalculate()
                        '.Col = 8
                        '.Row = .ActiveRow
                        '.Lock = False
                        '.Text = Math.Round((TAXAMOUNT + AMOUNT), 2)
                        TXTARRTOTALAMOUNT.Text = Format(Math.Round(TOT_AMT(SSGRID_ARRANGE), 0), "0.00")
                        .Lock = True

                        .Col = 10
                        .Lock = False
                        .Row = .ActiveRow
                        .Text = 0
                        '.Text = Math.Round(Math.Round(TAXAMOUNT + AMOUNT, 0) - Math.Round((TAXAMOUNT + AMOUNT), 2), 2)
                        .Lock = True

                        '' '' ''.Col = 11
                        '' '' ''.Lock = False
                        '' '' ''.Row = .ActiveRow
                        '' '' ''.Text = ""
                        '' '' ''.Text = Math.Round(taxperc(Itemcode), 2)
                        '' '' ''.Lock = True
                        .SetActiveCell(1, .ActiveRow + 1)
                    End If
                End If


                'If .ActiveCol = 6 Then
                '    .Col = 6
                '    .Row = .ActiveRow
                '    If Val(.Text()) = 0 Then
                '        .SetActiveCell(6, .ActiveRow)
                '        .Focus()
                '    End If
                'End If
            End With
            Call Total_Calculate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ARRANGEcalculate()
        Dim ITEMcode, hallrate As String
        Dim TAXCODE, ItemTypeCode As String
        Dim HALLTYPE1, FROMTIME, TOTIME As String
        Dim STRSQL As String
        Dim RoomPer, PartyPer As Double
        Dim TAXAMOUNT, perc, taxpercent, rate, QTY, halltotalamount, dbldicountAmount As Double
        'LOGAN
        For I = 1 To SSGRID_ARRANGE.DataRowCnt
            rate = 0
            Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
            GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
            With SSGRID_ARRANGE
                .Col = 1
                .Row = I
                ITEMcode = .Text

                .Col = 4
                .Row = I
                rate = Val(.Text)

                .Col = 5
                .Row = I
                QTY = Val(.Text)

                .Col = 9
                .Row = I
                ChargeCode = .Text

                SQLSTRING = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                GCONNECTION.getDataSet(SQLSTRING, "CODE_CHECK")
                If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                    ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                End If

                SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                GCONNECTION.getDataSet(SQLSTRING, "TAXON")
                If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                    For J = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                        IType = Trim(gdataset.Tables("TAXON").Rows(J).Item("ItemTypeCode"))
                        TAXCODE = Trim(gdataset.Tables("TAXON").Rows(J).Item("TaxCode"))
                        Taxon = Trim(gdataset.Tables("TAXON").Rows(J).Item("TAXON"))
                        TPercent = gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")

                        STRSQL = "INSERT INTO party_arrangement_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                        STRSQL = STRSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(TAXCODE) & "','" & Trim(Taxon) & "','" & Trim(ITEMcode) & "'," & Val(rate) & ",'" & Val(QTY) & "'," & (TPercent) & ","
                        If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                            Zero = (rate * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GZero = GZero + Zero
                            STRSQL = STRSQL & "" & Val(Zero) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                            ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GZeroA = GZeroA + ZeroA
                            STRSQL = STRSQL & "" & Val(ZeroA) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                            ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GZeroB = GZeroB + ZeroB
                            STRSQL = STRSQL & "" & Val(ZeroB) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                            One = ((rate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GOne = GOne + One
                            STRSQL = STRSQL & "" & Val(One) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                            OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GOneA = GOneA + OneA
                            STRSQL = STRSQL & "" & Val(OneA) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                            OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GOneB = GOneB + OneB
                            STRSQL = STRSQL & "" & Val(OneB) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                            Two = ((rate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GTwo = GTwo + Two
                            STRSQL = STRSQL & "" & Val(Two) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                            TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GTwoA = GTwoA + TwoA
                            STRSQL = STRSQL & "" & Val(TwoA) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                            TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GTwoB = GTwoB + TwoB
                            STRSQL = STRSQL & "" & Val(TwoB) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                            Three = ((rate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GThree = GThree + Three
                            STRSQL = STRSQL & "" & Val(Three) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                            ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GThreeA = GThreeA + ThreeA
                            STRSQL = STRSQL & "" & Val(ThreeA) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                            ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GThreeB = GThreeB + ThreeB
                            STRSQL = STRSQL & "" & Val(ThreeB) * QTY & ","
                        End If

                        'If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                        '    Zero = (rate * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                        '    GZero = GZero + Zero
                        '    .SetText(6, I, Zero)
                        '    .SetText(8, I, Zero + rate)


                        '    STRSQL = STRSQL & "" & Val(Zero) * QTY & ","
                        'ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                        '    ZeroA = (rate * GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                        '    GZeroA = GZeroA + ZeroA
                        '    .SetText(6, I, ZeroA)
                        '    .SetText(8, I, ZeroA + rate)

                        '    STRSQL = STRSQL & "" & Val(ZeroA) * QTY & ","
                        'ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                        '    ZeroB = rate * ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                        '    GZeroB = GZeroB + ZeroB
                        '    .SetText(6, I, ZeroB)
                        '    .SetText(8, I, ZeroB + rate)

                        '    STRSQL = STRSQL & "" & Val(ZeroB) * QTY & ","
                        'ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                        '    One = ((rate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                        '    GOne = GOne + One
                        '    .SetText(6, I, One)
                        '    .SetText(8, I, One + rate)

                        '    STRSQL = STRSQL & "" & Val(One) * QTY & ","
                        'ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                        '    OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                        '    GOneA = GOneA + OneA
                        '    .SetText(6, I, OneA)
                        '    .SetText(8, I, OneA + rate)

                        '    STRSQL = STRSQL & "" & Val(OneA) * QTY & ","
                        'ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                        '    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                        '    GOneB = GOneB + OneB
                        '    .SetText(6, I, OneB)
                        '    .SetText(8, I, OneB + rate)

                        '    STRSQL = STRSQL & "" & Val(OneB) * QTY & ","
                        'ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                        '    Two = ((rate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                        '    GTwo = GTwo + Two
                        '    .SetText(6, I, Two)
                        '    .SetText(8, I, Two + rate)

                        '    STRSQL = STRSQL & "" & Val(Two) * QTY & ","
                        'ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                        '    TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                        '    GTwoA = GTwoA + TwoA
                        '    .SetText(6, I, TwoA)
                        '    .SetText(8, I, TwoA + rate)

                        '    STRSQL = STRSQL & "" & Val(TwoA) * QTY & ","
                        'ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                        '    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                        '    GTwoB = GTwoB + TwoB
                        '    .SetText(6, I, TwoB)
                        '    .SetText(8, I, TwoB + rate)

                        '    STRSQL = STRSQL & "" & Val(TwoB) * QTY & ","
                        'ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                        '    Three = ((rate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                        '    GThree = GThree + Three
                        '    .SetText(6, I, Three)
                        '    .SetText(8, I, Three + rate)

                        '    STRSQL = STRSQL & "" & Val(Three) * QTY & ","
                        'ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                        '    ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                        '    GThreeA = GThreeA + ThreeA
                        '    .SetText(6, I, ThreeA)
                        '    .SetText(8, I, ThreeA + rate)

                        '    STRSQL = STRSQL & "" & Val(ThreeA) * QTY & ","
                        'ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                        '    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                        '    GThreeB = GThreeB + ThreeB
                        '    .SetText(6, I, ThreeB)
                        '    .SetText(8, I, ThreeB + rate)

                        '    STRSQL = STRSQL & "" & Val(ThreeB) * QTY & ","
                        'End If
                        STRSQL = STRSQL & "'" & Trim(gUsername) & "',getdate(),'N','')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = STRSQL
                    Next
                    GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                    .SetText(6, I, GrdTaxAmt * QTY)
                    .SetText(8, I, (GrdTaxAmt + rate) * QTY)
                End If
            End With
        Next







        With SSGRID_BOOKING
            'FOR i = 1 To .DataRowCnt


            'ssql = "select ISNULL(sum(cast(taxpercentage as numeric(10,2))),0) as perc  from accountstaxmaster where taxcode in(select isnull(taxtype,'') from Party_Hallmaster_TAX where HALLTYPECODE='" & hallcode & "')"
            'gconnection.getDataSet(ssql, "tax")
            'If gdataset.Tables("tax").Rows.Count > 0 Then
            '    perc = gdataset.Tables("tax").Rows(0).Item("perc")
            '    '.Text = gdataset.Tables("tax").Rows(CNT).Item("perc")
            '    .Col = 9
            '    .Row = .ActiveRow
            '    taxpercent = perc
            'Else
            'End If
            'TAXAMOUNT = (rate * taxpercent) / 100

            'halltotalamount = rate + TAXAMOUNT
            '.SetText(8, .ActiveRow, taxpercent)
            '.SetText(9, .ActiveRow, TAXAMOUNT)
            '.SetText(10, .ActiveRow, halltotalamount)
            '.Col = 8
            '.Row = .ActiveRow
            '.Text = taxpercent

            '.Col = 9
            '.Row = .ActiveRow
            '.Text = TAXAMOUNT

            '.Col = 10
            '.Row = .ActiveRow
            '.Text = halltotalamount


            Me.TXT_TOTAMT.Text = Format(Val(Me.TXT_TOTAMT.Text) + Val(halltotalamount), "0.00")
            dbldicountAmount = Format((Val(TXT_TOTAMT.Text) * Val(TXT_DISAMT.Text)) / 100, "0.00")
            'SSGRID_BOOKING.GetText(7, i, Taxamt)
            If Me.TXT_TOTAMT.Text < dbldicountAmount Then
                MessageBox.Show("DISCOUNT AMOUNT CANNOT BE GREATER THAN TOTAL AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'TESTING  TXT_TOTAMT.Text = Format(Math.Round(TOT_AMT23(SSGRID_BOOKING), 0), "0.00")
            Me.TXTB_BAMOUNT.Text = Format(Val(TXT_TOTAMT.Text) - Format(Val(dbldicountAmount)), "0.00")
            '  .SetActiveCell(1, .ActiveRow + 1)
            .Focus()
            'Me.TXT_TOTAMT.Text = Format(Val(Me.TXT_TOTAMT.Text) + Val(halltotalamount), "0.00")
            'Next I
        End With

    End Sub
    Private Sub ARRANGEcalculate1()
        Dim ITEMcode, hallrate As String
        Dim TAXCODE, ItemTypeCode As String
        Dim HALLTYPE1, FROMTIME, TOTIME As String
        Dim STRSQL As String
        Dim RoomPer, PartyPer As Double
        Dim TAXAMOUNT, perc, taxpercent, rate, QTY, halltotalamount, dbldicountAmount As Double
        'LOGAN
        For I = 1 To SSGRID_ARRANGE.DataRowCnt
            rate = 0
            Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
            GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
            With SSGRID_ARRANGE
                .Col = 1
                .Row = I
                ITEMcode = .Text

                .Col = 4
                .Row = I
                rate = Val(.Text)

                .Col = 5
                .Row = I
                QTY = Val(.Text)

                .Col = 9
                .Row = I
                ChargeCode = .Text

                SQLSTRING = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                GCONNECTION.getDataSet(SQLSTRING, "CODE_CHECK")
                If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                    ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                End If

                SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                GCONNECTION.getDataSet(SQLSTRING, "TAXON")
                If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                    For J = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                        IType = Trim(gdataset.Tables("TAXON").Rows(J).Item("ItemTypeCode"))
                        TAXCODE = Trim(gdataset.Tables("TAXON").Rows(J).Item("TaxCode"))
                        Taxon = Trim(gdataset.Tables("TAXON").Rows(J).Item("TAXON"))
                        TPercent = gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")

                        SSQL = "INSERT INTO party_arrangement_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                        SSQL = SSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(TAXCODE) & "','" & Trim(Taxon) & "','" & Trim(ITEMcode) & "'," & Val(rate) & ",'" & Val(QTY) & "'," & (TPercent) & ","
                        If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                            Zero = (rate * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GZero = GZero + Zero
                            SSQL = SSQL & "" & Val(Zero) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                            ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GZeroA = GZeroA + ZeroA
                            SSQL = SSQL & "" & Val(ZeroA) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                            ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GZeroB = GZeroB + ZeroB
                            SSQL = SSQL & "" & Val(ZeroB) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                            One = ((rate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GOne = GOne + One
                            SSQL = SSQL & "" & Val(One) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                            OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GOneA = GOneA + OneA
                            SSQL = SSQL & "" & Val(OneA) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                            OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GOneB = GOneB + OneB
                            SSQL = SSQL & "" & Val(OneB) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                            Two = ((rate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GTwo = GTwo + Two
                            SSQL = SSQL & "" & Val(Two) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                            TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GTwoA = GTwoA + TwoA
                            SSQL = SSQL & "" & Val(TwoA) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                            TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GTwoB = GTwoB + TwoB
                            SSQL = SSQL & "" & Val(TwoB) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                            Three = ((rate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GThree = GThree + Three
                            SSQL = SSQL & "" & Val(Three) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                            ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GThreeA = GThreeA + ThreeA
                            SSQL = SSQL & "" & Val(ThreeA) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                            ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GThreeB = GThreeB + ThreeB
                            SSQL = SSQL & "" & Val(ThreeB) * QTY & ","
                        End If

                   
                        SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N','')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = SSQL
                    Next
                    GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                    '.SetText(6, I, GrdTaxAmt)
                    '.SetText(8, I, GrdTaxAmt + rate)
                End If
            End With
        Next







      
    End Sub
    Private Function taxperc(ByVal itemcode As String)
        If Trim(itemcode) <> "" Then
            SSQL = "select Isnull(A.Taxpercentage,0) as Taxpercentage "
            SSQL = SSQL & " from Itemtypemaster A Inner join PARTY_ARRANGEMASTER_HDR b "
            SSQL = SSQL & " on A.Itemtypecode=b.Itemtypecode And b.arrcode='" & itemcode & "'"
            SSQL = SSQL & " And A.Startingdate<='" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy") & "'"
            SSQL = SSQL & " And isnull(A.Endingdate,getdate())>='" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy") & "'"
            DT = GCONNECTION.GetValues(SSQL)
            If DT.Rows.Count > 0 Then
                Return DT.Rows(0).Item("Taxpercentage")
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function
    Private Function menutaxperc(ByVal itemcode As String)
        If Trim(itemcode) <> "" Then
            SSQL = "select Isnull(A.Taxpercentage,0) as Taxpercentage "
            SSQL = SSQL & " from Itemtypemaster A Inner join PARTY_MENUMASTER b "
            SSQL = SSQL & " on A.Itemtypecode=b.Itemtypecode And b.itemcode='" & itemcode & "'"
            SSQL = SSQL & " And isnull(A.Startingdate,getdate())<='" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy") & "'"
            SSQL = SSQL & " And isnull(A.Endingdate,getdate())>='" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy") & "'"
            DT = GCONNECTION.GetValues(SSQL)
            If DT.Rows.Count > 0 Then
                Return DT.Rows(0).Item("Taxpercentage")
            Else
                Return 0
            End If
        Else
            Return 0
        End If
    End Function
    Private Function Arrcalc(ByVal itemcode As String, ByVal rate As Double, ByVal qty As Double) As Double
        TAXAMOUNT = 0
        Try
            If Trim(itemcode) <> "" Then
                SSQL = "select Isnull(A.Taxpercentage,0) as Taxpercentage "
                SSQL = SSQL & " from Itemtypemaster A Inner join PARTY_ARRANGEMASTER_HDR b "
                SSQL = SSQL & " on A.Itemtypecode=b.Itemtypecode And b.arrcode='" & itemcode & "'"
                SSQL = SSQL & " And A.Startingdate<='" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy") & "'"
                SSQL = SSQL & " And ISNULL(A.Endingdate,GETDATE())>='" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy") & "'"
                DT = GCONNECTION.GetValues(SSQL)
                If DT.Rows.Count > 0 Then
                    TAXAMOUNT = (Val(rate) * Val(qty))
                    Return Math.Round(TAXAMOUNT * Val(DT.Rows(0).Item("Taxpercentage")) / 100, 2)
                Else
                    Return 0
                End If
            Else
                Return 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Function Menucalc(ByVal Itemcode As String, ByVal Rate As Double, ByVal Qty As Double) As Double
        Dim TAXAMOUNT As String
        'TAXAMOUNT = 0
        Try
            SSQL = "select sum(cast(taxpercentage as numeric(10,2))) as perc from accountstaxmaster where taxcode in(select isnull(itemtypecode,'') from party_itemmaster_tax where itemcode='" & Itemcode & "')"
            GCONNECTION.getDataSet(SSQL, "tax")
            If gdataset.Tables("tax").Rows.Count > 0 Then
                TAXAMOUNT = (Rate * gdataset.Tables("tax").Rows(0).Item("perc")) / 100

            Else
                Return 0
            End If

            'If Trim(Itemcode) <> "" Then
            '    SSQL = "select Isnull(A.Taxpercentage,0) as Taxpercentage "
            '    SSQL = SSQL & " from Itemtypemaster A Inner join Party_ITEMmaster b "
            '    SSQL = SSQL & " on A.Itemtypecode=b.Itemtypecode And b.Itemcode='" & Itemcode & "'"
            '    SSQL = SSQL & " And A.Startingdate<='" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy") & "'"
            '    SSQL = SSQL & " And ISNULL(A.Endingdate,GETDATE())>='" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy") & "'"
            '    DT = GCONNECTION.GetValues(SSQL)
            '    If DT.Rows.Count > 0 Then
            '        TAXAMOUNT = (Val(Rate) * Val(Qty))
            'Return Math.Round(TAXAMOUNT * Val(DT.Rows(0).Item("Taxpercentage")) / 100, 2)
            '    Else
            '        Return 0
            '    End If
            'Else
            '    Return 0
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Function Menucalc1(ByVal Itemcode As String, ByVal tax As Double) As Double
        Dim TAXAMOUNT As Double
        'TAXAMOUNT = 0
        'START LOGAN
        Try

            SSQL = "select ISNULL(cast(taxpercentage as numeric(10,2)),0)as perc  from accountstaxmaster where taxcode in(select isnull(itemtypecode,'') from party_itemmaster_tax where TYPEOFTAX='SERVICE TAX' AND itemcode='" & Itemcode & "')"
            GCONNECTION.getDataSet(SSQL, "tax1")
            If gdataset.Tables("tax1").Rows.Count > 0 Then
                TAXAMOUNT = Math.Round(AMOUNT * gdataset.Tables("tax1").Rows(0).Item("perc")) / 100
            Else
                Return 0

            End If


            'END
            'Try
            '    SSQL = "select sum(cast(taxpercentage as numeric(10,2))) as perc from accountstaxmaster where taxcode in(select isnull(itemtypecode,'') from party_itemmaster_tax where itemcode='" & Itemcode & "')"
            '    GCONNECTION.getDataSet(SSQL, "tax")
            '    If gdataset.Tables("tax").Rows.Count > 0 Then
            '        TAXAMOUNT = Math.Round(RATE * gdataset.Tables("tax").Rows(0).Item("perc")) / 100
            '    Else
            '        Return 0
            '    End If


            'If Trim(Itemcode) <> "" Then
            '    SSQL = "select Isnull(A.Taxpercentage,0) as Taxpercentage "
            '    SSQL = SSQL & " from Itemtypemaster A Inner join Party_ITEMmaster b "
            '    SSQL = SSQL & " on A.Itemtypecode=b.Itemtypecode And b.Itemcode='" & Itemcode & "'"
            '    SSQL = SSQL & " And A.Startingdate<='" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy") & "'"
            '    SSQL = SSQL & " And ISNULL(A.Endingdate,GETDATE())>='" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy") & "'"
            '    DT = GCONNECTION.GetValues(SSQL)
            '    If DT.Rows.Count > 0 Then
            '        TAXAMOUNT = (Val(Rate) * Val(Qty))
            'Return Math.Round(TAXAMOUNT * Val(DT.Rows(0).Item("Taxpercentage")) / 100, 2)
            '    Else
            '        Return 0
            '    End If
            'Else
            '    Return 0
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Total_Calculate()
        Dim HTotal, KotTotal, ArrTotal As Double
        Dim k As Integer
        With SSGRID_BOOKING
            For k = 0 To .DataRowCnt
                .Col = 10
                .Row = k
                HTotal = HTotal + Val(.Text)
            Next
        End With
        With SSGRID_ARRANGE
            For k = 0 To .DataRowCnt
                .Col = 8
                .Row = k
                ArrTotal = ArrTotal + Val(.Text)
            Next
        End With
        Txt_BillTotal.Text = Math.Round((HTotal + ArrTotal), 0)
    End Sub
    Private Sub SSGRID_MENU1_KeyDownEvent(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID_MENU1.KeyDownEvent
        Dim Itemcode, ITEMCODE1 As String
        Dim rate, qty, TAXAMOUNT, AMOUNT, tax As Double
        Dim C As Integer
        Try
            'DUPLCIATION ITEM CHECKING

            For I = 1 To SSGRID.DataRowCnt
                SSGRID.Row = I
                SSGRID.Col = 2
                Itemcode = SSGRID.Text
                C = 0
                For J = 1 To SSGRID.DataRowCnt
                    SSGRID.Row = J
                    SSGRID.Col = 2
                    ITEMCODE1 = SSGRID.Text
                    If Itemcode = ITEMCODE1 Then
                        C = C + 1
                    End If
                Next J
                If C > 1 Then
                    If MsgBox("Duplication Item Not Allowed...." & Itemcode, MsgBoxStyle.OKCancel + MsgBoxStyle.DefaultButton1, "DELETE DUPLICATE") = MsgBoxResult.OK Then
                        SSGRID.Row = I
                        SSGRID.ClearRange(1, I, 15, I, True)
                        SSGRID.DeleteRows(I, 1)
                        SSGRID.Row = I
                        SSGRID.Col = 1
                        SSGRID.Lock = False
                        SSGRID.Col = 2
                        SSGRID.Lock = False
                        SSGRID.Col = 3
                        SSGRID.Lock = False
                        SSGRID.Col = 4
                        SSGRID.Lock = False
                        SSGRID.Col = 5
                        SSGRID.Lock = False
                        SSGRID.SetActiveCell(1, I)
                    Else
                        SSGRID.SetActiveCell(1, I)
                        SSGRID.Focus()
                    End If
                End If
            Next I


            If e.keyCode = Keys.Enter Then
                With SSGRID

                    If .ActiveCol = 1 Then
                        .SetActiveCell(2, .ActiveRow)
                    ElseIf .ActiveCol = 2 Then
                        .Col = 2
                        .Row = .ActiveRow

                        If Trim(.Text) = "" Then
                            .SetActiveCell(2, .ActiveRow)
                            Call ITEMCODEHELP()
                        Else
                            .Col = 2
                            .Row = .ActiveRow
                            SSQL = "SELECT ITEMCODE,ITEMDESC,UOM,RATE,SERTAX,TAXPERC FROM VIEW_PARTY_HELPMENUMASTER WHERE ITEMCODE='" & Trim(.Text) & "' "
                            DT = GCONNECTION.GetValues(SSQL)
                            If DT.Rows.Count > 0 Then
                                .Col = 2
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""
                                .Text = Trim(DT.Rows(0).Item("ITEMCODE"))
                                .Lock = True
                                .SetActiveCell(3, .ActiveRow)
                                .Col = 3
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""
                                .Text = Trim(DT.Rows(0).Item("ITEMDESC"))
                                .Lock = True
                                .SetActiveCell(4, .ActiveRow)

                                .Col = 4
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""
                                .Text = Trim(DT.Rows(0).Item("UOM"))
                                .Lock = True

                                .SetActiveCell(5, .ActiveRow)
                                .Col = 5
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""
                                .Text = DT.Rows(0).Item("RATE")

                                .SetActiveCell(8, .ActiveRow)
                                .Col = 8
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""
                                .Text = DT.Rows(0).Item("SERTAX")

                                .SetActiveCell(9, .ActiveRow)
                                .Col = 9
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""
                                .Text = DT.Rows(0).Item("TAXPERC")

                                .Lock = True
                                .SetActiveCell(6, .ActiveRow)
                            Else
                                .SetActiveCell(2, .ActiveRow)
                                .Col = 2
                                .Text = ""
                            End If
                        End If
                    ElseIf .ActiveCol = 3 Then
                        If Trim(.Text) = "" Then
                            .SetActiveCell(3, .ActiveRow)
                        Else
                            .SetActiveCell(4, .ActiveRow)
                        End If
                    ElseIf .ActiveCol = 4 Then
                        If Trim(.Text) = "" Then
                            .SetActiveCell(4, .ActiveRow)
                        Else
                            .SetActiveCell(5, .ActiveRow)
                        End If
                    ElseIf .ActiveCol = 5 Then
                        If Val(.Text) = 0 Then
                            .SetActiveCell(5, .ActiveRow)
                        Else
                            .SetActiveCell(6, .ActiveRow)
                        End If
                        .SetActiveCell(6, .ActiveRow)
                    ElseIf .ActiveCol = 6 Then
                        .Col = 6
                        .Row = .ActiveRow
                        If Val(.Text()) = 0 Then
                            .SetActiveCell(6, .ActiveRow)
                            .Focus()
                        Else
                            .Col = 2
                            .Row = .ActiveRow
                            Itemcode = .Text

                            .Col = 5
                            .Row = .ActiveRow
                            rate = Val(.Text)

                            .Col = 6
                            .Row = .ActiveRow
                            qty = Val(.Text)

                            .Col = 7
                            .Row = .ActiveRow
                            .Lock = True
                            .Text = Math.Round(qty * rate, 2)
                            AMOUNT = Val(.Text)
                            'TXTRESAMOUNT.Text = Format(Math.Round(Itemamt(SSGRID_MENU), 2), "0.00")
                            '.SetActiveCell(7, .ActiveRow)
                            '.Lock = True

                            .Col = 8
                            .Row = .ActiveRow
                            .Lock = False
                            .Text = ""
                            'TAXAMOUNT = Math.Round(Menucalc(Itemcode, rate, qty), 2)
                            '=================MULTIPLE SERTAX CALC==============
                            'LOGAN     AMT = qty * rate
                            SSQL = "select ISNULL(cast(taxpercentage as numeric(10,2)),0)as perc  from accountstaxmaster where taxcode in(select isnull(itemtypecode,'') from party_itemmaster_tax where TYPEOFTAX='SERVICE TAX' AND itemcode='" & Itemcode & "')"
                            GCONNECTION.getDataSet(SSQL, "tax1")


                            If gdataset.Tables("tax1").Rows.Count > 0 Then
                                SERTAX = Math.Round(AMOUNT * gdataset.Tables("tax1").Rows(0).Item("perc")) / 100
                                .Text = SERTAX
                                'TXTSERTAX.Text = Format(Math.Round(taxamt2(SSGRID_MENU), 2), "0.00")
                                .Lock = True
                            Else
                                ' SERTAX = Math.Round(Menucalc1(Itemcode, TAX1), 2)

                            End If
                            '=================MULTIPLE VAT CALC==============

                            If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
                                .Col = 9
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""

                                SSQL = "select ISNULL(cast(taxpercentage as numeric(10,2)),0)as perc  from accountstaxmaster where taxcode in(select isnull(itemtypecode,'') from party_itemmaster_tax where itemcode='" & Itemcode & "'AND TYPEOFTAX <> 'SERVICE TAX')"
                                GCONNECTION.getDataSet(SSQL, "tax")

                                AMTT = AMOUNT + SERTAX
                                If gdataset.Tables("tax").Rows.Count > 0 Then
                                    TAXAMOUNT = Math.Round(AMTT * gdataset.Tables("tax").Rows(0).Item("perc")) / 100
                                    .Text = TAXAMOUNT
                                    TXTRESTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID), 2), "0.00")
                                    .Lock = True
                                Else
                                    'TAXAMOUNT = Math.Round(Menucalc1(Itemcode, tax), 2)
                                    '.Text = TAXAMOUNT
                                    'TXTRESTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID_MENU), 2), "0.00")
                                    '.Lock = True
                                End If
                            Else
                                .Col = 9
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""

                                SSQL = "select ISNULL(cast(taxpercentage as numeric(10,2)),0)as perc  from accountstaxmaster where taxcode in(select isnull(itemtypecode,'') from party_itemmaster_tax where itemcode='" & Itemcode & "'AND TYPEOFTAX <> 'SERVICE TAX')"
                                GCONNECTION.getDataSet(SSQL, "tax")

                                AMTT = AMOUNT
                                If gdataset.Tables("tax").Rows.Count > 0 Then
                                    TAXAMOUNT = Math.Round(AMTT * gdataset.Tables("tax").Rows(0).Item("perc")) / 100
                                    .Text = TAXAMOUNT
                                    TXTRESTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID), 2), "0.00")
                                    .Lock = True
                                Else
                                    'TAXAMOUNT = Math.Round(Menucalc1(Itemcode, tax), 2)
                                    '.Text = TAXAMOUNT
                                    'TXTRESTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID_MENU), 2), "0.00")
                                    '.Lock = True
                                End If
                            End If
                            '================================================


                            .Col = 10
                            .Row = .ActiveRow
                            .Lock = False
                            .Text = Math.Round(SERTAX + TAXAMOUNT + AMOUNT, 2)
                            TXTRESTOTALAMOUNT.Text = Format(Math.Round(TOT_AMT1(SSGRID), 0), "0.00")
                            .SetActiveCell(7, .ActiveRow)
                            .Lock = True

                            .Col = 11
                            .Lock = False
                            .Row = .ActiveRow
                            .Text = 0
                            '.Text = Math.Round(Math.Round(TAXAMOUNT + AMOUNT, 0) - Math.Round((TAXAMOUNT + AMOUNT), 2), 2)
                            .Lock = True
                            .Col = 12
                            .Lock = False
                            .Row = .ActiveRow
                            .Text = ""
                            .Text = Math.Round(menutaxperc(Itemcode), 2)
                            .Lock = True
                            .SetActiveCell(1, .ActiveRow + 1)
                        End If
                    ElseIf .ActiveCol = 7 Then
                        .SetActiveCell(8, .ActiveRow)
                    ElseIf .ActiveCol = 8 Then
                        If Trim(.Text) = "" Then
                            .SetActiveCell(1, .ActiveRow)
                        Else
                            .SetActiveCell(1, .ActiveRow + 1)
                        End If
                        'Else
                        '    .SetActiveCell(2, .ActiveRow + 1)
                    End If
                End With
            End If
            If e.keyCode = Keys.F3 Then
                With SSGRID
                    .Row = .ActiveRow
                    .DeleteRows(.ActiveRow, 1)
                    If .ActiveRow <= 1 Then
                        .SetActiveCell(1, .ActiveRow)
                    Else
                        .SetActiveCell(1, .ActiveRow - 1)
                    End If
                    TXTRESTOTALAMOUNT.Text = Format(Math.Round(TOT_AMT1(SSGRID), 0), "0.00")
                    TXTRESAMOUNT.Text = Format(Math.Round(Itemamt(SSGRID), 2), "0.00")
                    TXTRESTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID), 2), "0.00")
                End With
            End If
            If e.keyCode = Keys.F4 Then
                Call ITEMCODEHELP()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub calctax(ByVal row As Integer)
        Dim TAXAMOUNT As Double
        'TAXAMOUNT = 0
        Try
            SSQL = "select sum(cast(taxpercentage as numeric(10,2))) as perc from accountstaxmaster where taxcode in(select isnull(itemtypecode,'') from party_itemmaster_tax where itemcode='" & ITEMCODE & "')"
            GCONNECTION.getDataSet(SSQL, "tax")
            If gdataset.Tables("tax").Rows.Count > 0 Then
                TAXAMOUNT = (RATE * gdataset.Tables("tax").Rows(0).Item("perc")) / 100
            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Function ITEMCODEHELP()
        Dim vform As New LIST_OPERATION1
        ' If UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then

        If SSGRID.ActiveCol = 2 Then
            gSQLString = " SELECT DISTINCT ITEMCODE,ITEMDESC,BaseUOMstd,BaseRATEstd,ITEMTYPECODE FROM ITEMMASTER "
            'gSQLString = gSQLString & " WHERE '" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "' BETWEEN STARTINGDATE AND ISNULL(ENDINGDATE,'" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "')  "
            'AND (ITEMCODE = '" & Trim(varitemcode) & "' )
            If Trim(Search) = "" Then
                M_WhereCondition = " "
            Else
                M_WhereCondition = " "
            End If
            vform.Field = "itemcode,itemdesc,BaseUOMSTD,BaseRATESTD,ITEMTYPECODE"
            '  vform.vFormatstring = " TEM DESCRIPTION                         |ITEM CODE    |  UOM         | RATE   |POS     "
            vform.vCaption = "Restaurant Menu"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            'vform.Keypos3 = 3
            'vform.keypos4 = 4
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                With SSGRID
                    .Col = 3
                    .Row = .ActiveRow
                    .Lock = False
                    .Text = ""
                    .Text = Trim(vform.keyfield1 & "")
                    .Lock = True

                    .SetActiveCell(3, .ActiveRow)
                    .Col = 2
                    .Row = .ActiveRow
                    .Lock = False
                    .Text = ""
                    .Text = Trim(vform.keyfield & "")
                    .Lock = True
                    .SetActiveCell(4, .ActiveRow)

                    .Col = 4
                    .Row = .ActiveRow
                    .Lock = False
                    .Text = ""
                    .Text = Trim(vform.keyfield2 & "")
                    .Lock = True

                    .SetActiveCell(5, .ActiveRow)
                    .Col = 5
                    .Row = .ActiveRow
                    .Lock = False
                    .Text = ""
                    .Text = Trim(vform.keyfield3 & "")
                    .Lock = True

                    .SetActiveCell(11, .ActiveRow)

                    .Col = 8
                    .Row = .ActiveRow
                    .Lock = False
                    .Text = ""
                    .Text = Trim(vform.keyfield4 & "")

                    .Lock = True
                    .SetActiveCell(6, .ActiveRow)
                End With
            End If
            vform.Close()
            vform = Nothing
        ElseIf SSGRID.ActiveCol = 3 Then
            With SSGRID
                .SetActiveCell(4, .ActiveRow)
            End With
        Else
            SSGRID.SetActiveCell(1, SSGRID_ARRANGE.ActiveRow + 1)
        End If

        '  End If
    End Function
    '''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''
    Private Sub SSGRID_MENU_LeaveCell2(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles SSGRID_MENU1.LeaveCell
        Try
            Dim Itemcode As String
            Dim rate, qty, TAXAMOUNT As Double
            With SSGRID
                If .ActiveCol = 2 Then
                    .Col = 1
                    .Row = .ActiveRow
                    If Trim(.Text) = "" Then
                        '.SetActiveCell(1, .ActiveRow)
                    End If
                ElseIf .ActiveCol = 3 Then
                    .Col = 3
                    .Row = .ActiveRow
                    If Trim(.Text) = "" Then
                        '.SetActiveCell(1, .ActiveRow)
                    End If
                ElseIf .ActiveCol = 4 Then
                    .Col = 4
                    .Row = .ActiveRow
                    If Trim(.Text) = "" Then
                        '.SetActiveCell(1, .ActiveRow + 1)
                    End If
                ElseIf .ActiveCol = 5 Then
                    .Col = 5
                    .Row = .ActiveRow
                    If Val(.Text) = 0 Then
                        '.SetActiveCell(4, .ActiveRow + 1)
                    End If
                ElseIf .ActiveCol = 6 Then
                    .Col = 6
                    .Row = .ActiveRow
                    If Val(.Text()) = 0 Then
                        '.SetActiveCell(5, .ActiveRow)
                        '.Focus()
                    Else
                        .Col = 2
                        .Row = .ActiveRow
                        Itemcode = .Text

                        .Col = 5
                        .Row = .ActiveRow
                        rate = Val(.Text)

                        .Col = 6
                        .Row = .ActiveRow
                        qty = Val(.Text)

                        .Col = 7
                        .Row = .ActiveRow
                        .Lock = True
                        .Text = Math.Round(qty * rate, 2)
                        AMOUNT = Val(.Text)
                        'TXTRESAMOUNT.Text = Format(Math.Round(Itemamt(SSGRID_MENU), 2), "0.00")
                        '.SetActiveCell(7, .ActiveRow)
                        '.Lock = True

                        .Col = 8
                        .Row = .ActiveRow
                        .Lock = False
                        .Text = ""
                        'TAXAMOUNT = Math.Round(Menucalc(Itemcode, rate, qty), 2)
                        '=================MULTIPLE SERTAX CALC==============
                        'LOGAN     AMT = qty * rate
                        SSQL = "select ISNULL(cast(taxpercentage as numeric(10,2)),0)as perc  from accountstaxmaster where taxcode in(select isnull(itemtypecode,'') from party_itemmaster_tax where TYPEOFTAX='SERVICE TAX' AND itemcode='" & Itemcode & "')"
                        GCONNECTION.getDataSet(SSQL, "tax1")


                        If gdataset.Tables("tax1").Rows.Count > 0 Then
                            SERTAX = Math.Round(AMOUNT * gdataset.Tables("tax1").Rows(0).Item("perc")) / 100
                            .Text = SERTAX
                            'TXTSERTAX.Text = Format(Math.Round(taxamt2(SSGRID_MENU), 2), "0.00")
                            .Lock = True
                        Else
                            ' SERTAX = Math.Round(Menucalc1(Itemcode, TAX1), 2)

                        End If
                        '=================MULTIPLE VAT CALC==============

                        If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
                            .Col = 9
                            .Row = .ActiveRow
                            .Lock = False
                            .Text = ""

                            SSQL = "select ISNULL(cast(taxpercentage as numeric(10,2)),0)as perc  from accountstaxmaster where taxcode in(select isnull(itemtypecode,'') from party_itemmaster_tax where itemcode='" & Itemcode & "'AND TYPEOFTAX <> 'SERVICE TAX')"
                            GCONNECTION.getDataSet(SSQL, "tax")

                            AMTT = AMOUNT + SERTAX
                            If gdataset.Tables("tax").Rows.Count > 0 Then
                                TAXAMOUNT = Math.Round(AMTT * gdataset.Tables("tax").Rows(0).Item("perc")) / 100
                                .Text = TAXAMOUNT
                                TXTRESTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID), 2), "0.00")
                                .Lock = True
                            Else
                                'TAXAMOUNT = Math.Round(Menucalc1(Itemcode, tax), 2)
                                '.Text = TAXAMOUNT
                                'TXTRESTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID_MENU), 2), "0.00")
                                '.Lock = True
                            End If
                        Else
                            .Col = 9
                            .Row = .ActiveRow
                            .Lock = False
                            .Text = ""

                            SSQL = "select ISNULL(cast(taxpercentage as numeric(10,2)),0)as perc  from accountstaxmaster where taxcode in(select isnull(itemtypecode,'') from party_itemmaster_tax where itemcode='" & Itemcode & "'AND TYPEOFTAX <> 'SERVICE TAX')"
                            GCONNECTION.getDataSet(SSQL, "tax")

                            AMTT = AMOUNT
                            If gdataset.Tables("tax").Rows.Count > 0 Then
                                TAXAMOUNT = Math.Round(AMTT * gdataset.Tables("tax").Rows(0).Item("perc")) / 100
                                .Text = TAXAMOUNT
                                TXTRESTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID), 2), "0.00")
                                .Lock = True
                            Else
                                'TAXAMOUNT = Math.Round(Menucalc1(Itemcode, tax), 2)
                                '.Text = TAXAMOUNT
                                'TXTRESTAXAMOUNT.Text = Format(Math.Round(taxamt(SSGRID_MENU), 2), "0.00")
                                '.Lock = True
                            End If
                        End If
                        '================================================
                        .Col = 10
                        .Row = .ActiveRow
                        .Lock = False
                        .Text = Math.Round(SERTAX + TAXAMOUNT + AMOUNT, 2)
                        TXTRESTOTALAMOUNT.Text = Format(Math.Round(TOT_AMT1(SSGRID), 0), "0.00")
                        .SetActiveCell(7, .ActiveRow)
                        .Lock = True


                        .Col = 11
                        .Lock = False
                        .Row = .ActiveRow
                        .Text = ""
                        '.Text = Math.Round(Math.Round(TAXAMOUNT + (qty * rate), 0) - Math.Round((TAXAMOUNT + (qty * rate)), 2), 2)
                        .Lock = True
                        .Col = 12
                        .Lock = False
                        .Row = .ActiveRow
                        .Text = ""
                        .Text = Math.Round(menutaxperc(Itemcode), 2)
                        .Lock = True
                    End If
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TXTASSOCIATENAME_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTASSOCIATENAME.KeyPress
        If Asc(e.KeyChar) = 13 Then
            'TXTMCODE.Focus()
            TxtOCCUPANCY.Focus()
        End If
    End Sub
    Private Sub TxtmenuAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTRESTOTALAMOUNT.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cmd_Add1.Focus()
        End If
    End Sub
    Private Sub txtArrangeamount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            Cmd_Add1.Focus()
        End If
    End Sub
    Private Sub TXTRESTAXAMOUNT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTRESTAXAMOUNT.LostFocus
        TXTRESTAXAMOUNT.Text = Format(Val(TXTRESTAXAMOUNT.Text), "0.00")
    End Sub
    Private Sub TXTRESAMOUNT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTRESAMOUNT.LostFocus
        TXTRESAMOUNT.Text = Format(Val(TXTRESAMOUNT.Text), "0.00")
    End Sub
    Private Sub TXTTOTALAMOUNT_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTRESTOTALAMOUNT.LostFocus
        TXTRESTOTALAMOUNT.Text = Format(Val(TXTRESTOTALAMOUNT.Text), "0.00")
    End Sub
    Private Function taxamt(ByVal _ssgrid As AxFPSpreadADO.AxfpSpread) As Double
        Dim _Taxamt As Double
        _Taxamt = 0
        With _ssgrid
            For I = 1 To .DataRowCnt
                .Col = 6
                .Row = I
                _Taxamt = _Taxamt + Val(.Text)
            Next I
            Return Math.Round(_Taxamt, 2)
        End With
    End Function
    Private Function taxamt2(ByVal _ssgrid As AxFPSpreadADO.AxfpSpread) As Double
        Dim _SERTAX As Double
        _SERTAX = 0
        With _ssgrid
            For I = 1 To .DataRowCnt
                .Col = 8
                .Row = I
                _SERTAX = _SERTAX + Val(.Text)
            Next I
            Return Math.Round(_SERTAX, 2)
        End With
    End Function
    Private Function Itemamt(ByVal _ssgrid As AxFPSpreadADO.AxfpSpread) As Double
        Dim _amount As Double
        _amount = 0
        With _ssgrid
            For I = 1 To .DataRowCnt
                .Col = 7
                .Row = I
                _amount = _amount + Val(.Text)
            Next I
            Return Math.Round(_amount, 2)
        End With
    End Function
    Private Function TOT_AMT1(ByVal _ssgrid As AxFPSpreadADO.AxfpSpread) As Double
        Dim _Totamount, _taxamount, _SERTAX As Double
        _Totamount = 0
        _taxamount = 0
        _SERTAX = 0
        With _ssgrid
            For I = 1 To .DataRowCnt
                .Col = 9
                .Row = I
                _taxamount = _taxamount + Math.Round(Val(.Text), 2)

                .Col = 8
                .Row = I
                _SERTAX = _SERTAX + Math.Round(Val(.Text), 2)

                .Col = 7
                .Row = I
                _Totamount = _Totamount + Math.Round(Val(.Text), 2)
            Next I
            Return Math.Round((_Totamount + _SERTAX + _taxamount), 2)
        End With
    End Function
    Private Function TOT_AMT(ByVal _ssgrid As AxFPSpreadADO.AxfpSpread) As Double
        Dim _Totamount, _taxamount As Double
        _Totamount = 0
        _taxamount = 0
        With _ssgrid
            For I = 1 To .DataRowCnt
                .Col = 6
                .Row = I
                _taxamount = _taxamount + Math.Round(Val(.Text), 2)
                .Col = 7
                .Row = I
                _Totamount = _Totamount + Math.Round(Val(.Text), 2)
            Next I
            Return Math.Round((_Totamount + _taxamount), 2)
        End With
    End Function
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        gPrint = False
        If MsgBox("Press OK to Final Bill or CANCEL to Annexure........", MsgBoxStyle.OKCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then
            Call hallbilling()
        Else
            Call Finalbilling()
        End If
    End Sub
    Private Sub print_windows()
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r As New RPT_BOOKING_DETAILS
        str = " SELECT * FROM PARTY_VIEW_BOOKING_DETAILS WHERE "
        str = str & " BOOKINGNO = " & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
        If CMBBOOKINGTYPE.SelectedItem = "BOOKING" Then
            str = str & " AND BOOKINGTYPE='BOOKING'"
        ElseIf CMBBOOKINGTYPE.SelectedItem = "BILLING" Then
            str = str & " AND BOOKINGTYPE='BILLING'"
        ElseIf CMBBOOKINGTYPE.SelectedItem = "CANCEL" Then
            str = str & " AND BOOKINGTYPE='CANCEL'"
        End If
        Viewer.ssql = str
        Viewer.Report = r
        Viewer.TableName = "PARTY_VIEW_BOOKING_DETAILS"
        'Dim textobj1 As TextObject
        'textobj1 = r.ReportDefinition.ReportObjects("Text32")
        'textobj1.Text = MyCompanyName
        'Dim TXTOBJ2 As TextObject
        'TXTOBJ2 = r.ReportDefinition.ReportObjects("Text36")
        'TXTOBJ2.Text = gUsername
        Viewer.Show()
    End Sub
    Private Sub FinalBillRegister()
        Dim i As Integer
        Dim sqlstring As String
        Call Validation() '''--> Check Validation
        If BOOLCHK = False Then Exit Sub
        If CMBBOOKINGTYPE.Text = "CANCEL" Then
            Dim Objfinalbillregister As New PARTY_CANCELBILLING
            Objfinalbillregister.ReportDetails(TXTBOOKINGNO.Text, CMBBOOKINGTYPE.Text)
        Else
            Dim Objfinalbillregister As New Party_Billing
            Objfinalbillregister.ReportDetails(TXTBOOKINGNO.Text, CMBBOOKINGTYPE.Text)
        End If
    End Sub
    Public Sub Validation()
        BOOLCHK = False
        '''********** Check  Store Code Can't be blank *********************'''
        'If Trim(TXTHALLCODE.Text) = "" Then
        '    MessageBox.Show(" HALL Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    TXTHALLCODE.Focus()
        '    Exit Sub
        'End If
        '''********** Check  Store desc Can't be blank *********************'''
        If Trim(CMBBOOKINGTYPE.Text) = "" Then
            MessageBox.Show(" BOOKING TYPE can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CMBBOOKINGTYPE.Focus()
            Exit Sub
        End If
        BOOLCHK = True
    End Sub
    Private Sub cmd_print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_print.Click
        gPrint = True
        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        'Dim r As New CrptPARTY_VIEW_HALLBOOKINGDETAILS

        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String

        If MessageBox.Show("Do You Want Print it Now ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.OK Then
            'If MsgBox("Press OK to BOOKING Bill or FINAL to Annexure........", MsgBoxStyle.OKCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then

            '    Call PARTYBillingform()
            '    '        'Call ADD_ITEM()
            '    '    Else
            '    '        Call view_party_billing()

            'End If
            If TXTBOOKINGNO.Text = "" Then
                MessageBox.Show("PLEASE ENTER THE BOOKING NO", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TXTBOOKINGNO.Focus()
                Exit Sub

            End If
            If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then

                Call PARTYBillingform()
            ElseIf UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then
                Call PARTYBillingformASCA()
            Else
                'Call PARTYBillingform()
                Call PARTYBillingformKGA()
            End If
        End If
        'End If

        'Call view_party_billing()
        'FinalBillRegister()
    End Sub
    Private Sub hallbilling()
        Try
            Dim sqlstring, HALLCODE, RCTNO, TCODE, RCODE, ACODE As String
            Dim i, j, K, ARR, TAR, TAR1, cnt, cnt1 As Integer
            Dim hallamt, halltaxamt, hallnetamt, rcamt, RESAMT, RESTAXAMT, CONTAXAMT, BARAMT, BARTAXAMT, CONAMT, RESTOTALAMT, TARAMT, ARRAMT, ARRTAXAMT, ARRTOTALAMT, TARIFFTAXAMT As Double
            Dim dt As New DataTable
            Dim ABOOKINGOCCUPANCY, ABILLINGOCCUPANCY, BOOKINGOCCUPANCY, BILLINGVOCCUPANCY, BILLINGNVOCCUPANCY, BILLINGOCCUPANCY, DIFFOCCUPANCY, ALLOWEDOCCUPANCY, RESSBFAMT, BARSBFAMT, CONSBFAMT, BARTOTALAMT, CONTOTALAMT As Double
            Dim BOOKNO As Integer
            Dim TARSBFCHARGE As String
            pagesize = 1

            sqlstring = "UPDATE PARTY_RESTAURANT SET TAXPERC=" & PRTAXPERC & " WHERE TTYPE='T' AND isnull(TAXPERC,0)=0"
            GCONNECTION.getDataSet(sqlstring, "HallStatus")

            sqlstring = "DELETE FROM PARTY_ARRANGEMENT WHERE SUBSTRING(ISNULL(ITEMCODE,''),1,1) NOT BETWEEN 'A' AND 'Z'"
            GCONNECTION.getDataSet(sqlstring, "HallStatus")

            If TXTBOOKINGNO.Text <> "" Then
                sqlstring = "SELECT BOOKINGNO,SUM(BOOKINGOCCUPANCY) AS BOOKINGOCCUPANCY,SUM(BILLINGOCCUPANCY) AS BILLINGOCCUPANCY FROM PARTY_VIEW_BOOKINGVSBILLINGOCCUPANCY Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' GROUP BY BOOKINGNO"
                GCONNECTION.getDataSet(sqlstring, "HallStatus")
                If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                    BOOKINGOCCUPANCY = gdataset.Tables("Hallstatus").Rows(0).Item("BOOKINGOCCUPANCY")
                    BILLINGOCCUPANCY = gdataset.Tables("Hallstatus").Rows(0).Item("BILLINGOCCUPANCY")

                    ABOOKINGOCCUPANCY = gdataset.Tables("Hallstatus").Rows(0).Item("BOOKINGOCCUPANCY")
                    ABILLINGOCCUPANCY = gdataset.Tables("Hallstatus").Rows(0).Item("BILLINGOCCUPANCY")

                    If BILLINGOCCUPANCY <= 0 Then
                        BILLINGOCCUPANCY = BOOKINGOCCUPANCY
                    End If
                    DIFFOCCUPANCY = BILLINGOCCUPANCY - BOOKINGOCCUPANCY

                    'If DIFFOCCUPANCY <= 0 Then
                    '    DIFFOCCUPANCY = 0
                    'Else
                    '    Dim ALLOWEDOCCUPANCY1 As Double
                    '    ALLOWEDOCCUPANCY = Math.Floor(BOOKINGOCCUPANCY * (10 / 100))
                    '    ALLOWEDOCCUPANCY1 = BOOKINGOCCUPANCY * (10 / 100)

                    '    If ALLOWEDOCCUPANCY1 - ALLOWEDOCCUPANCY >= 0.5 Then
                    '        ALLOWEDOCCUPANCY = ALLOWEDOCCUPANCY + 1
                    '    End If

                    '    BOOKINGOCCUPANCY = BOOKINGOCCUPANCY + ALLOWEDOCCUPANCY
                    '    DIFFOCCUPANCY = DIFFOCCUPANCY - ALLOWEDOCCUPANCY
                    'End If
                End If

                sqlstring = "SELECT * FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' ORDER BY BOOKINGNO,TTYPE,RECEIPTNO"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' ORDER BY BOOKINGNO,TTYPE,RECEIPTNO"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' ORDER BY BOOKINGNO,TTYPE,RECEIPTNO"
                End If

                GCONNECTION.getDataSet(sqlstring, "HallStatus")
                vOutfile = Mid("out" & (Rnd() * 600000), 1, 8)
                VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
                Filewrite = File.AppendText(VFilePath)

                If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                    cnt = 1 : cnt1 = 1
                    Filewrite.WriteLine(Chr(18) & Space(25) & Chr(27) + "E" & MyCompanyName & Chr(27) + "F")
                    pagesize = pagesize + 1
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        If Trim(CMB_LOCATION.Text) = "A" Then
                            Filewrite.WriteLine(Chr(27) + "E" & "MAINCLUB : SEPCIAL PARTY BOOKING" & Chr(27) + "F")
                        Else
                            Filewrite.WriteLine(Chr(27) + "E" & "SAILING ANNEXE : SEPCIAL PARTY BOOKING" & Chr(27) + "F")
                        End If
                        pagesize = pagesize + 1
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        If Trim(CMB_LOCATION.Text) = "A" Then
                            Filewrite.WriteLine(Chr(27) + "E" & "MAINCLUB : SPECIAL PARTY BILLING" & Chr(27) + "F")
                        Else
                            Filewrite.WriteLine(Chr(27) + "E" & "SAILING ANNEXE : SPECIAL PARTY BILLING" & Chr(27) + "F")
                        End If
                        pagesize = pagesize + 1
                    Else
                        Filewrite.WriteLine(Chr(27) + "E" & "SPECIAL PARTY CANCEL" & Chr(27) + "F")
                        pagesize = pagesize + 1
                    End If
                    Filewrite.WriteLine()
                    Filewrite.WriteLine()
                    pagesize = pagesize + 2

                    For K = 0 To gdataset.Tables("Hallstatus").Rows.Count - 1
                        If BOOKNO <> gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGNO") Then
                            Filewrite.WriteLine(StrDup(79, "-"))
                            Filewrite.Write("|" & "BOOKING NO     : " & Space(5 - Len(Mid(gdataset.Tables("HALLSTATUS").Rows(K).Item("BOOKINGNO"), 1, 5))) & Mid(gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGNO"), 1, 5) & Space(10))
                            Filewrite.WriteLine("|" & "BOOKING DATE: " & Mid(Format(gdataset.Tables("HALLSTATUS").Rows(K).Item("BOOKINGDATE"), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("BookingDate"), "dd/MMM/yyyy"), 1, 11))) & Space(19) & "|")
                            Filewrite.WriteLine("|" & Space(32) & "|" & Space(44) & "|")
                            pagesize = pagesize + 3

                            Filewrite.Write("|" & "PARTY DATE     : " & Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("PARTYDATE"), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("PARTYDate"), "dd/MMM/yyyy"), 1, 11))))
                            If gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGFLAG") = "Y" Then
                                Filewrite.WriteLine(Space(4) & "|" & "STATUS      :" & Mid("HALL BOOKED", 1, 26) & Space(26 - Len(Mid("HALL BOOKED", 1, 26))) & Space(5) & "|")
                                pagesize = pagesize + 1
                            Else
                                Filewrite.WriteLine("|" & Space(43) & "|")
                                pagesize = pagesize + 1
                            End If
                            Filewrite.WriteLine("|" & Space(32) & "|" & Space(44) & "|")
                            pagesize = pagesize + 1

                            Filewrite.Write("|" & "MEMBERSHIP NO  : " & Mid(gdataset.Tables("HallStatus").Rows(K).Item("Mcode"), 1, 8) & Space(8 - Len(Mid(gdataset.Tables("HallStatus").Rows(K).Item("Mcode"), 1, 8))))
                            Filewrite.WriteLine(Space(7) & "|" & "MEMBER NAME :" & Mid(gdataset.Tables("HallStatus").Rows(K).Item("MNAME"), 1, 30) & Space(30 - Len(Mid(gdataset.Tables("HallStatus").Rows(K).Item("MNAME"), 1, 30))) & Space(1) & "|")
                            Filewrite.WriteLine("|" & Space(32) & "|" & Space(44) & "|")
                            pagesize = pagesize + 2
                            Filewrite.WriteLine("|" & "BILLING PAXS   : " & Mid(ABILLINGOCCUPANCY, 1, 3) & Space(3 - Len(Mid(ABILLINGOCCUPANCY, 1, 3))) & Space(12) & "|" & "BOOKING PAXS: " & Mid(ABOOKINGOCCUPANCY, 1, 3) & Space(3 - Len(Mid(ABOOKINGOCCUPANCY, 1, 3))) & Space(27) & "|")
                            Filewrite.WriteLine("|" & Space(32) & "|" & Space(44) & "|")
                            Filewrite.WriteLine(StrDup(79, "-"))
                            pagesize = pagesize + 3
                            BOOKNO = gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGNO")
                        End If
                    Next

                    Dim HALLTAXPERC As Double

                    'HALL DETAILS
                    sqlstring = "SELECT Hallcode,HallDesc,PDesc,fromtime,totime,Hallamount,HALLTAXAMOUNT,HALLTAXPERC,HALLNETAMOUNT,SEDEPOSIT FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' GROUP BY Hallcode,HallDesc,PDesc,fromtime,totime,Hallamount,HALLTAXAMOUNT,HALLTAXPERC,HALLNETAMOUNT,SEDEPOSIT"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' GROUP BY Hallcode,HallDesc,PDesc,fromtime,totime,Hallamount,HALLTAXAMOUNT,HALLTAXPERC,HALLNETAMOUNT,SEDEPOSIT"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' GROUP BY Hallcode,HallDesc,PDesc,fromtime,totime,Hallamount,HALLTAXAMOUNT,HALLTAXPERC,HALLNETAMOUNT,SEDEPOSIT"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "HALL")
                    If gdataset.Tables("HALL").Rows.Count > 0 Then
                        Call Hallfacility_Heading(61)
                        For i = 0 To gdataset.Tables("HALL").Rows.Count - 1
                            If HALLCODE <> gdataset.Tables("HALL").Rows(i).Item("HALLCODE") Then
                                If pagesize > 60 Then
                                    'Filewrite.WriteLine(Chr(12))

                                    For EMPTYLOOP = 1 To EMPTYSPACE
                                        Filewrite.WriteLine()
                                    Next

                                    Filewrite.WriteLine(StrDup(79, "-"))
                                    pagesize = 1
                                    Call Hallfacility_Heading(pagesize)
                                End If
                                If Val(gdataset.Tables("HALL").Rows(i).Item("HALLTAXPERC")) <> 0 Then
                                    HALLTAXPERC = Val(gdataset.Tables("HALL").Rows(i).Item("HALLTAXPERC"))
                                End If
                                SSQL = "|" & Space(2 - Len(Mid(Val(cnt), 1, 2))) & Mid(Val(cnt), 1, 2)
                                SSQL = SSQL & "|" & Mid(gdataset.Tables("HALL").Rows(i).Item("Hallcode"), 1, 8) & Space(8 - Len(Mid(gdataset.Tables("HALL").Rows(i).Item("Hallcode"), 1, 8)))
                                SSQL = SSQL & "|" & Mid(gdataset.Tables("HALL").Rows(i).Item("HallDesc"), 1, 20) & Space(20 - Len(Mid(gdataset.Tables("HALL").Rows(i).Item("HallDesc"), 1, 20)))
                                SSQL = SSQL & "|" & Mid(gdataset.Tables("HALL").Rows(i).Item("PDesc"), 1, 10) & Space(10 - Len(Mid(gdataset.Tables("HALL").Rows(i).Item("PDesc"), 1, 10)))

                                SSQL = SSQL & "|" & Space(8 - Len(Mid(Format(gdataset.Tables("HALL").Rows(i).Item("Hallamount"), "0.00"), 1, 8))) & Mid(Format(gdataset.Tables("HALL").Rows(i).Item("Hallamount"), "0.00"), 1, 8)
                                If Val(gdataset.Tables("HALL").Rows(i).Item("HALLTAXAMOUNT")) > 0 Then
                                    SSQL = SSQL & "|" & Space(5 - Len(Mid(Format(gdataset.Tables("HALL").Rows(i).Item("HALLTAXPERC"), "0.00"), 1, 5))) & Mid(Format(gdataset.Tables("HALL").Rows(i).Item("HALLTAXPERC"), "0.00"), 1, 5)
                                Else
                                    SSQL = SSQL & "|" & Space(5)
                                End If
                                SSQL = SSQL & "|" & Space(7 - Len(Mid(Format(gdataset.Tables("HALL").Rows(i).Item("HALLTAXAMOUNT"), "0.00"), 1, 7))) & Mid(Format(gdataset.Tables("HALL").Rows(i).Item("HALLTAXAMOUNT"), "0.00"), 1, 7)
                                SSQL = SSQL & "|" & Space(10 - Len(Mid(Format(gdataset.Tables("HALL").Rows(i).Item("HALLNETAMOUNT"), "0.00"), 1, 10))) & Mid(Format(gdataset.Tables("HALL").Rows(i).Item("HALLNETAMOUNT"), "0.00"), 1, 10) & "|"
                                Filewrite.WriteLine(SSQL)
                                pagesize = pagesize + 1
                                cnt = cnt + 1
                                hallamt = Val(hallamt) + gdataset.Tables("HALL").Rows(i).Item("HALLAMOUNT")
                                halltaxamt = Val(halltaxamt) + gdataset.Tables("HALL").Rows(i).Item("HALLtaxAMOUNT")
                                hallnetamt = Val(hallnetamt) + gdataset.Tables("HALL").Rows(i).Item("HALLNETAMOUNT")
                                HALLCODE = gdataset.Tables("HALL").Rows(i).Item("HALLCODE")
                            End If
                        Next
                        Filewrite.WriteLine(StrDup(79, "-"))
                        Filewrite.WriteLine(Space(25) & "Hall Total Amount  |" & Space(8 - Len(Mid(Format(Val(hallamt), "0.00"), 1, 8))) & "|" & Mid(Format(Val(hallamt), "0.00"), 1, 8) & Space(5) & "|" & Space(7 - Len(Mid(Format(Val(halltaxamt), "0.00"), 1, 7))) & Mid(Format(Val(halltaxamt), "0.00"), 1, 7) & "|" & Space(10 - Len(Mid(Format(Val(hallnetamt), "0.00"), 1, 10))) & Mid(Format(Val(hallnetamt), "0.00"), 1, 10) & "|")
                        Filewrite.WriteLine(StrDup(79, "-"))
                        Filewrite.WriteLine()
                        sqlstring = "UPDATE PARTY_HDR SET HALLAMOUNT=" & Val(hallamt) & ",HALLTAXAMOUNT=" & Val(halltaxamt) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        GCONNECTION.getDataSet(sqlstring, "HallStatus")

                        pagesize = pagesize + 4
                    End If

                    'ADVANCE RECEIPT DETAILS
                    sqlstring = "SELECT RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND AMOUNTTYPE in ('CATERING ADVANCE','BANQUET REFUNDABLE DEPOSIT','BANQUET ADVANCE RENT')"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND ISNULL(RECEIPTNO,'')<>'' GROUP BY RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND ISNULL(RECEIPTNO,'')<>'' GROUP BY RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND ISNULL(RECEIPTNO,'')<>'' GROUP BY RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "RECEIPT")

                    If gdataset.Tables("RECEIPT").Rows.Count > 0 Then
                        Call Reciept_Heading(61)
                        For j = 0 To gdataset.Tables("RECEIPT").Rows.Count - 1
                            If RCTNO <> gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO") Then
                                If pagesize > 60 Then
                                    '                                    Filewrite.WriteLine(Chr(12))
                                    For EMPTYLOOP = 1 To EMPTYSPACE
                                        Filewrite.WriteLine()
                                    Next

                                    Filewrite.WriteLine(StrDup(72, "-"))
                                    pagesize = 1
                                    Call Reciept_Heading(pagesize)
                                End If
                                If Val(gdataset.Tables("RECEIPT").Rows(j).Item("Ramount")) <> 0 Then
                                    SSQL = "|" & Space(3 - Len(Mid(Val(cnt1), 1, 3))) & Mid(Val(cnt1), 1, 3)
                                    SSQL = SSQL & "|" & Mid(gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO"), 1, 20) & Space(20 - Len(Mid(gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO"), 1, 20)))
                                    SSQL = SSQL & "|" & Mid(Format(gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTDATE"), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTDATE"), "dd/MMM/yyyy"), 1, 11)))
                                    SSQL = SSQL & "|" & Mid(gdataset.Tables("RECEIPT").Rows(j).Item("AMOUNTTYPE"), 1, 20) & Space(20 - Len(Mid(gdataset.Tables("RECEIPT").Rows(j).Item("AMOUNTTYPE"), 1, 20)))
                                    SSQL = SSQL & "|" & Space(12 - Len(Mid(Format(gdataset.Tables("RECEIPT").Rows(j).Item("Ramount"), "0.00"), 1, 12))) & Mid(Format(gdataset.Tables("RECEIPT").Rows(j).Item("Ramount"), "0.00"), 1, 12) & "|"
                                    Filewrite.WriteLine(SSQL)
                                    pagesize = pagesize + 1
                                    RCTNO = gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO")
                                    rcamt = Val(rcamt) + gdataset.Tables("RECEIPT").Rows(j).Item("Ramount")
                                End If
                                cnt1 = cnt1 + 1
                            End If
                        Next j
                        Filewrite.WriteLine(StrDup(72, "-"))
                        Filewrite.WriteLine(Space(38) & "Advance Total Amount" & "|" & Space(12 - Len(Mid(Format(Val(rcamt), "0.00"), 1, 12))) & Mid(Format(Val(rcamt), "0.00"), 1, 12) & "|")
                        sqlstring = "UPDATE PARTY_HDR SET ADVANCE=" & Val(rcamt) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        GCONNECTION.getDataSet(sqlstring, "HallStatus")

                        Filewrite.WriteLine(StrDup(72, "-"))
                        Filewrite.WriteLine()
                        pagesize = pagesize + 4
                    End If


                    'ADDITIONAL ITEMS DETAILS FOR KITCHEN

                    sqlstring = "SELECT TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where CATEGORY IN('KITCHEN','CONTRACTOR') AND bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "RITEM")
                    If gdataset.Tables("RITEM").Rows.Count > 0 Then
                        Call Restaurant_Heading(61, 1)
                        cnt1 = 1
                        For TAR = 0 To gdataset.Tables("RITEM").Rows.Count - 1
                            If pagesize > 60 Then
                                For EMPTYLOOP = 1 To EMPTYSPACE
                                    Filewrite.WriteLine()
                                Next

                                Filewrite.WriteLine(StrDup(79, "-"))
                                pagesize = 1
                                Call Restaurant_Heading(pagesize, 1)
                            End If

                            If RCODE <> Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE")) Then
                                If Trim(gdataset.Tables("RITEM").Rows(TAR).Item("TTYPE")) = "R" Then
                                    If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")) <> 0 Then
                                        SSQL = "|" & Space(3 - Len(Mid(Val(cnt1), 1, 3))) & Mid(Val(cnt1), 1, 3)
                                        SSQL = SSQL & "|" & Mid(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"), 1, 8) & Space(8 - Len(Mid(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"), 1, 8)))
                                        SSQL = SSQL & "|" & Mid(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMDESC"), 1, 20) & Space(20 - Len(Mid(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMDESC"), 1, 20)))
                                        SSQL = SSQL & "|" & Space(4 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("RQTY"), "0"), 1, 4))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("RQTY"), "0"), 1, 4)

                                        '                                        SSQL = SSQL & "|" & Space(8 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("RRATE"), "0.00"), 1, 8))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("RRATE"), "0.00"), 1, 8)
                                        SSQL = SSQL & "|" & Space(9 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT"), "0.00"), 1, 9))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT"), "0.00"), 1, 9)
                                        If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                            SSQL = SSQL & "|" & Space(8 - Len(Mid(Format((gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0.02), "0.00"), 1, 8))) & Mid(Format((gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0.02), "0.00"), 1, 8)
                                        Else
                                            SSQL = SSQL & "|" & Space(8)
                                        End If

                                        SSQL = SSQL & "|" & Space(8 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT"), "0.00"), 1, 8))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT"), "0.00"), 1, 8)
                                        SSQL = SSQL & "|" & Space(10 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT"), "0.00"), 1, 10))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT"), "0.00"), 1, 10) & "|"

                                        'If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                        '    SSQL = SSQL & "|Y"
                                        'Else
                                        '    SSQL = SSQL & "|N"
                                        'End If

                                        Filewrite.WriteLine(SSQL)
                                        pagesize = pagesize + 1
                                        RESAMT = RESAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                        RESTAXAMT = RESTAXAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT")
                                        RESTOTALAMT = RESTOTALAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT")
                                        If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                            RESSBFAMT = RESSBFAMT + (gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0.02)
                                        End If
                                        cnt1 = cnt1 + 1
                                    End If
                                End If
                                RCODE = Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"))
                            End If
                        Next
                        If RESAMT <> 0 Then
                            Filewrite.WriteLine(StrDup(79, "-"))
                            Filewrite.WriteLine(Space(16) & "Kitchen Total Amount : " & "|" & Space(9 - Len(Mid(Format(Val(RESAMT), "0.00"), 1, 9))) & Mid(Format(Val(RESAMT), "0.00"), 1, 9) & "|" & Space(8 - Len(Mid(Format(Val(RESSBFAMT), "0.00"), 1, 8))) & Mid(Format(Val(RESSBFAMT), "0.00"), 1, 8) & "|" & Space(8 - Len(Mid(Format(Val(RESTAXAMT), "0.00"), 1, 8))) & Mid(Format(Val(RESTAXAMT), "0.00"), 1, 8) & "|" & Space(10 - Len(Mid(Format(Val(RESTOTALAMT), "0.00"), 1, 10))) & Mid(Format(Val(RESTOTALAMT), "0.00"), 1, 10) & "|")
                            Filewrite.WriteLine(StrDup(79, "-"))
                            Filewrite.WriteLine()
                            pagesize = pagesize + 4
                            sqlstring = "UPDATE PARTY_HDR SET RESTAMOUNT=" & Val(RESAMT) & ",RESTTAXAMOUNT=" & Val(RESTAXAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                            GCONNECTION.getDataSet(sqlstring, "HallStatus")
                        End If
                    End If


                    'ADDITIONAL ITEMS DETAILS FOR BAR - LIQUOR
                    sqlstring = "SELECT TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where CATEGORY='BARCONT' AND bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "RITEM")
                    If gdataset.Tables("RITEM").Rows.Count > 0 Then
                        Call Restaurant_Heading(61, 2)
                        cnt1 = 1
                        For TAR = 0 To gdataset.Tables("RITEM").Rows.Count - 1
                            If pagesize > 60 Then
                                For EMPTYLOOP = 1 To EMPTYSPACE
                                    Filewrite.WriteLine()
                                Next

                                Filewrite.WriteLine(StrDup(79, "-"))
                                pagesize = 1
                                Call Restaurant_Heading(pagesize, 2)
                            End If

                            If RCODE <> Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE")) Then
                                If Trim(gdataset.Tables("RITEM").Rows(TAR).Item("TTYPE")) = "R" Then
                                    If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")) <> 0 Then

                                        SSQL = "|" & Space(3 - Len(Mid(Val(cnt1), 1, 3))) & Mid(Val(cnt1), 1, 3)
                                        SSQL = SSQL & "|" & Mid(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"), 1, 8) & Space(8 - Len(Mid(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"), 1, 8)))
                                        SSQL = SSQL & "|" & Mid(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMDESC"), 1, 20) & Space(20 - Len(Mid(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMDESC"), 1, 20)))
                                        SSQL = SSQL & "|" & Space(4 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("RQTY"), "0"), 1, 4))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("RQTY"), "0"), 1, 4)
                                        '                                        SSQL = SSQL & "|" & Space(8 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("RRATE"), "0.00"), 1, 8))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("RRATE"), "0.00"), 1, 8)
                                        SSQL = SSQL & "|" & Space(9 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT"), "0.00"), 1, 9))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT"), "0.00"), 1, 9)
                                        If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                            SSQL = SSQL & "|" & Space(8 - Len(Mid(Format((gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0.02), "0.00"), 1, 8))) & Mid(Format((gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0.02), "0.00"), 1, 8)
                                        Else
                                            SSQL = SSQL & "|" & Space(8)
                                        End If


                                        SSQL = SSQL & "|" & Space(8 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT"), "0.00"), 1, 8))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT"), "0.00"), 1, 8)
                                        SSQL = SSQL & "|" & Space(10 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT"), "0.00"), 1, 10))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT"), "0.00"), 1, 10) & "|"
                                        'If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                        '    SSQL = SSQL & "|Y"
                                        'Else
                                        '    SSQL = SSQL & "|N"
                                        'End If

                                        Filewrite.WriteLine(SSQL)
                                        pagesize = pagesize + 1
                                        CONAMT = CONAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                        CONTAXAMT = CONTAXAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT")
                                        CONTOTALAMT = CONTOTALAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT")
                                        If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                            CONSBFAMT = CONSBFAMT + (gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0.02)
                                        End If
                                        cnt1 = cnt1 + 1
                                    End If
                                End If
                                RCODE = Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"))
                            End If
                        Next
                        If CONAMT <> 0 Then
                            Filewrite.WriteLine(StrDup(79, "-"))
                            Filewrite.WriteLine(Space(17) & "Liquor Total Amount : " & "|" & Space(9 - Len(Mid(Format(Val(CONAMT), "0.00"), 1, 9))) & Mid(Format(Val(CONAMT), "0.00"), 1, 9) & "|" & Space(8 - Len(Mid(Format(Val(CONSBFAMT), "0.00"), 1, 8))) & Mid(Format(Val(CONSBFAMT), "0.00"), 1, 8) & "|" & Space(8 - Len(Mid(Format(Val(CONTAXAMT), "0.00"), 1, 8))) & Mid(Format(Val(CONTAXAMT), "0.00"), 1, 8) & "|" & Space(10 - Len(Mid(Format(Val(CONTOTALAMT), "0.00"), 1, 10))) & Mid(Format(Val(CONTOTALAMT), "0.00"), 1, 10) & "|")
                            Filewrite.WriteLine(StrDup(79, "-"))
                            Filewrite.WriteLine()
                            pagesize = pagesize + 4

                            RESSBFAMT = RESSBFAMT + CONSBFAMT
                            RESAMT = RESAMT + CONAMT
                            RESTAXAMT = RESTAXAMT + CONTAXAMT

                            sqlstring = "UPDATE PARTY_HDR SET RESTAMOUNT=" & Val(RESAMT) & ",RESTTAXAMOUNT=" & Val(RESTAXAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                            GCONNECTION.getDataSet(sqlstring, "HallStatus")
                        End If
                    End If


                    'ADDITIONAL ITEMS DETAILS FOR BAR - CIG AND SOFT DRINKS
                    sqlstring = "SELECT TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where CATEGORY='BARVAT' AND bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "RITEM")
                    If gdataset.Tables("RITEM").Rows.Count > 0 Then
                        Call Restaurant_Heading(61, 3)
                        cnt1 = 1
                        For TAR = 0 To gdataset.Tables("RITEM").Rows.Count - 1
                            If pagesize > 60 Then
                                '                                Filewrite.WriteLine(Chr(12))
                                For EMPTYLOOP = 1 To EMPTYSPACE
                                    Filewrite.WriteLine()
                                Next

                                Filewrite.WriteLine(StrDup(79, "-"))
                                pagesize = 1
                                Call Restaurant_Heading(pagesize, 3)
                            End If
                            If RCODE <> Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE")) Then
                                If Trim(gdataset.Tables("RITEM").Rows(TAR).Item("TTYPE")) = "R" Then
                                    If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")) <> 0 Then
                                        SSQL = "|" & Space(3 - Len(Mid(Val(cnt1), 1, 3))) & Mid(Val(cnt1), 1, 3)
                                        SSQL = SSQL & "|" & Mid(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"), 1, 8) & Space(8 - Len(Mid(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"), 1, 8)))
                                        SSQL = SSQL & "|" & Mid(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMDESC"), 1, 20) & Space(20 - Len(Mid(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMDESC"), 1, 20)))
                                        SSQL = SSQL & "|" & Space(4 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("RQTY"), "0"), 1, 4))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("RQTY"), "0"), 1, 4)
                                        '                                        SSQL = SSQL & "|" & Space(8 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("RRATE"), "0.00"), 1, 8))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("RRATE"), "0.00"), 1, 8)
                                        SSQL = SSQL & "|" & Space(9 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT"), "0.00"), 1, 9))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT"), "0.00"), 1, 9)
                                        If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                            SSQL = SSQL & "|" & Space(8 - Len(Mid(Format((gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0.02), "0.00"), 1, 8))) & Mid(Format((gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0.02), "0.00"), 1, 8)
                                        Else
                                            SSQL = SSQL & "|" & Space(8)
                                        End If

                                        SSQL = SSQL & "|" & Space(8 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT"), "0.00"), 1, 8))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT"), "0.00"), 1, 8)
                                        SSQL = SSQL & "|" & Space(10 - Len(Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT"), "0.00"), 1, 10))) & Mid(Format(gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT"), "0.00"), 1, 10) & "|"
                                        'If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                        '    SSQL = SSQL & "|Y"
                                        'Else
                                        '    SSQL = SSQL & "|N"
                                        'End If

                                        Filewrite.WriteLine(SSQL)
                                        pagesize = pagesize + 1
                                        BARAMT = BARAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                        BARTAXAMT = BARTAXAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT")
                                        BARTOTALAMT = BARTOTALAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT")
                                        If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                            BARSBFAMT = BARSBFAMT + (gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0.02)
                                        End If
                                        cnt1 = cnt1 + 1
                                    End If
                                End If
                                RCODE = Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"))
                            End If
                        Next

                        If BARAMT <> 0 Then
                            Filewrite.WriteLine(StrDup(79, "-"))
                            Filewrite.WriteLine("Soft Drinks & Cigarettes Total Amount: " & "|" & Space(9 - Len(Mid(Format(Val(BARAMT), "0.00"), 1, 9))) & Mid(Format(Val(BARAMT), "0.00"), 1, 9) & "|" & Space(8 - Len(Mid(Format(Val(BARSBFAMT), "0.00"), 1, 8))) & Mid(Format(Val(BARSBFAMT), "0.00"), 1, 8) & "|" & Space(8 - Len(Mid(Format(Val(BARTAXAMT), "0.00"), 1, 8))) & Mid(Format(Val(BARTAXAMT), "0.00"), 1, 8) & "|" & Space(10 - Len(Mid(Format(Val(BARTOTALAMT), "0.00"), 1, 10))) & Mid(Format(Val(BARTOTALAMT), "0.00"), 1, 10) & "|")
                            Filewrite.WriteLine(StrDup(79, "-"))
                            Filewrite.WriteLine()
                            pagesize = pagesize + 4

                            RESSBFAMT = RESSBFAMT + BARSBFAMT
                            RESAMT = RESAMT + BARAMT
                            RESTAXAMT = RESTAXAMT + BARTAXAMT

                            sqlstring = "UPDATE PARTY_HDR SET RESTAMOUNT=" & Val(RESAMT) & ",RESTTAXAMOUNT=" & Val(RESTAXAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                            GCONNECTION.getDataSet(sqlstring, "HallStatus")
                        End If
                    End If

                    'TARIFF MENU DETAILS
                    Dim TRATE, DRATE, BOOKINGVALUE, DIFFVALUE, TARIFFVALUE, PRTAXPERC As Double

                    sqlstring = "SELECT PRROWID,TTYPE,RITEMCODE,RITEMDESC,RQTY,TRATE,TSBFCHARGE,PRTAXPERC FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='T' GROUP BY PRROWID,TTYPE,RITEMCODE,RITEMDESC,RQTY,TRATE,TSBFCHARGE,PRTAXPERC ORDER BY PRROWID"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='T' GROUP BY PRROWID,TTYPE,RITEMCODE,RITEMDESC,RQTY,TRATE,TSBFCHARGE,PRTAXPERC ORDER BY PRROWID"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='T' GROUP BY PRROWID,TTYPE,RITEMCODE,RITEMDESC,RQTY,TRATE,TSBFCHARGE,PRTAXPERC ORDER BY PRROWID"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "TITEM")
                    Dim C As Integer = 0
                    SSQL = ""
                    If gdataset.Tables("TITEM").Rows.Count > 0 Then
                        Call Tariff_Heading(61)
                        cnt1 = 1
                        For TAR1 = 0 To gdataset.Tables("TITEM").Rows.Count - 1
                            C = C + 1

                            If pagesize > 60 Then
                                For EMPTYLOOP = 1 To EMPTYSPACE
                                    Filewrite.WriteLine()
                                Next
                                Filewrite.WriteLine(StrDup(79, "-"))
                                pagesize = 1
                                Call Tariff_Heading(pagesize)
                            End If
                            If Val(gdataset.Tables("TITEM").Rows(TAR1).Item("PRTAXPERC")) <> 0 Then
                                PRTAXPERC = Val(gdataset.Tables("TITEM").Rows(TAR1).Item("PRTAXPERC"))
                            End If
                            If TCODE <> Trim(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMCODE")) Then
                                If Trim(gdataset.Tables("TITEM").Rows(TAR1).Item("TTYPE")) = "T" Then
                                    If C < 3 Then
                                        SSQL = SSQL & "|" & Space(3 - Len(Mid(Val(cnt1), 1, 3))) & Mid(Val(cnt1), 1, 3)
                                        SSQL = SSQL & "|" & Mid(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMCODE"), 1, 8) & Space(8 - Len(Mid(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMCODE"), 1, 8)))
                                        SSQL = SSQL & "|" & Mid(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMDESC"), 1, 25) & Space(25 - Len(Mid(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMDESC"), 1, 25)))
                                    Else
                                        SSQL = SSQL & "|"
                                        Filewrite.WriteLine(SSQL)
                                        SSQL = "|" & Space(3 - Len(Mid(Val(cnt1), 1, 3))) & Mid(Val(cnt1), 1, 3)
                                        SSQL = SSQL & "|" & Mid(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMCODE"), 1, 8) & Space(8 - Len(Mid(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMCODE"), 1, 8)))
                                        SSQL = SSQL & "|" & Mid(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMDESC"), 1, 25) & Space(25 - Len(Mid(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMDESC"), 1, 25)))
                                        C = 1
                                        pagesize = pagesize + 1
                                    End If


                                    '                                    SSQL = SSQL & "|" & Space(4 - Len(Mid(Format(gdataset.Tables("TITEM").Rows(TAR1).Item("RQTY"), "0"), 1, 4))) & Mid(Format(gdataset.Tables("TITEM").Rows(TAR1).Item("RQTY"), "0"), 1, 4) & "|"
                                    cnt1 = cnt1 + 1
                                End If

                                TCODE = Trim(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMCODE"))
                                TRATE = Val(gdataset.Tables("TITEM").Rows(TAR1).Item("TRATE"))
                                TARSBFCHARGE = Trim(gdataset.Tables("TITEM").Rows(TAR1).Item("TSBFCHARGE"))

                                '                                If gdataset.Tables("TITEM").Rows(TAR).Item("ASBFCHARGE") = "Y" Then
                                '                                    RESSBFAMT = RESSBFAMT + (Val(gdataset.Tables("TITEM").Rows(TAR1).Item("TRATE")) * 0.02)
                                '                           End If
                            End If
                        Next
                        If C < 3 Then
                            Filewrite.WriteLine(SSQL)
                            pagesize = pagesize + 1
                        End If

                        Dim TARIFFSBF As Double
                        If DIFFOCCUPANCY > 0 Then
                            'VIJAY180811
                            BOOKINGVALUE = BILLINGOCCUPANCY * TRATE
                            'BOOKINGVALUE = BILLINGVOCCUPANCY * TRATE + BILLINGOCCUPANCY * TRATE

                            DRATE = (TRATE * (50 / 100))
                            DIFFVALUE = DIFFOCCUPANCY * TRATE
                            DIFFVALUE = 0
                        Else
                            BOOKINGVALUE = BILLINGOCCUPANCY * TRATE
                            DRATE = TRATE + (TRATE * (50 / 100))
                            DIFFVALUE = 0
                        End If
                        TARIFFVALUE = BOOKINGVALUE + DIFFVALUE

                        '                        If TARSBFCHARGE = "Y" Then
                        RESSBFAMT = RESSBFAMT + (TARIFFVALUE * 0)
                        '                   End If

                        TARIFFSBF = TARIFFSBF + (TARIFFVALUE * 0)

                        TARIFFTAXAMT = TARIFFTAXAMT + (TARIFFVALUE * (PRTAXPERC / 100))

                        Filewrite.WriteLine(StrDup(79, "-"))
                        Filewrite.WriteLine("|" & "Booking Value: " & Space(10 - Len(Mid(Format(Val(BOOKINGVALUE), "0.00"), 1, 10))) & Mid(Format(Val(BOOKINGVALUE), "0.00"), 1, 10) & "|" & "Extra Value  : " & Space(10 - Len(Mid(Format(Val(DIFFVALUE), "0.00"), 1, 10))) & Mid(Format(Val(DIFFVALUE), "0.00"), 1, 10) & "|" & "Tariff Value : " & Space(10 - Len(Mid(Format(Val(TARIFFVALUE), "0.00"), 1, 10))) & Mid(Format(Val(TARIFFVALUE), "0.00"), 1, 10) & "|")
                        If Val(TARIFFSBF) > 0 Then
                            Filewrite.WriteLine("|" & "Tariff @     : " & Space(10 - Len(Mid(Format(Val(TRATE), "0.00"), 1, 10))) & Mid(Format(Val(TRATE), "0.00"), 1, 10) & "|" & Space(26) & "Tariff SBF   : " & Space(10 - Len(Mid(Format(Val(TARIFFSBF), "0.00"), 1, 10))) & Mid(Format(Val(TARIFFSBF), "0.00"), 1, 10) & "|")
                        End If
                        If Val(DIFFOCCUPANCY) > 0 Then
                            Filewrite.WriteLine("|" & "Billing Paxs : " & Space(10 - Len(Mid(Format(Val(BILLINGOCCUPANCY), "0"), 1, 10))) & Mid(Format(Val(BILLINGOCCUPANCY), "0"), 1, 10) & "|" & "Extra Paxs   : " & Space(10 - Len(Mid(Format(Val(DIFFOCCUPANCY), "0"), 1, 10))) & Mid(Format(Val(DIFFOCCUPANCY), "0"), 1, 10) & "|" & "Tariff VAT   :" & Space(10 - Len(Mid(Format(Val(TARIFFTAXAMT), "0.00"), 1, 10))) & Mid(Format(Val(TARIFFTAXAMT), "0.00"), 1, 10) & "|")
                        Else
                            Filewrite.WriteLine("|" & "Billing Paxs : " & Space(10 - Len(Mid(Format(Val(BILLINGOCCUPANCY), "0"), 1, 10))) & Mid(Format(Val(BILLINGOCCUPANCY), "0"), 1, 10) & "|" & Space(25) & "|" & "Tariff VAT   : " & Space(10 - Len(Mid(Format(Val(TARIFFTAXAMT), "0.00"), 1, 10))) & Mid(Format(Val(TARIFFTAXAMT), "0.00"), 1, 10) & "|")
                        End If
                        Filewrite.WriteLine(StrDup(79, "-"))

                        sqlstring = "UPDATE PARTY_HDR SET BOOKINGTARIFFAMOUNT=" & Val(BOOKINGVALUE) & ",EXCESSTARIFFAMOUNT=" & Val(DIFFVALUE) & ",TARIFFTAXAMOUNT=" & Val(TARIFFTAXAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        GCONNECTION.getDataSet(sqlstring, "HallStatus")

                        Filewrite.WriteLine()
                        pagesize = pagesize + 6

                        If pagesize > 60 Then
                            For EMPTYLOOP = 1 To EMPTYSPACE
                                Filewrite.WriteLine()
                            Next
                            Filewrite.WriteLine(StrDup(56, "-"))
                            pagesize = 1
                        End If
                    End If
                    Dim ARRSBFAMT As Double
                    sqlstring = "SELECT AITEMCODE,AITEMDESC,AQTY,ARATE,AAMOUNT,ATAXAMOUNT,ATOTALAMOUNT,ASBFCHARGE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND ISNULL(AITEMCODE,'')<>'' GROUP BY AITEMCODE,AITEMDESC,AQTY,ARATE,AAMOUNT,ATAXAMOUNT,ATOTALAMOUNT,ASBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND ISNULL(AITEMCODE,'')<>'' GROUP BY AITEMCODE,AITEMDESC,AQTY,ARATE,AAMOUNT,ATAXAMOUNT,ATOTALAMOUNT,ASBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y'  AND ISNULL(AITEMCODE,'')<>'' GROUP BY AITEMCODE,AITEMDESC,AQTY,ARATE,AAMOUNT,ATAXAMOUNT,ATOTALAMOUNT,ASBFCHARGE"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "AITEM")
                    If gdataset.Tables("AITEM").Rows.Count > 0 Then
                        Call Arrangement_Heading(61)
                        cnt1 = 1
                        For ARR = 0 To gdataset.Tables("AITEM").Rows.Count - 1
                            If pagesize > 60 Then
                                For EMPTYLOOP = 1 To EMPTYSPACE
                                    Filewrite.WriteLine()
                                Next

                                Filewrite.WriteLine(StrDup(79, "-"))
                                pagesize = 1
                                Call Arrangement_Heading(pagesize)
                            End If
                            If ACODE <> Trim(gdataset.Tables("AITEM").Rows(ARR).Item("AITEMCODE")) Then
                                If Val(gdataset.Tables("AITEM").Rows(ARR).Item("AAMOUNT")) <> 0 Then
                                    SSQL = "|" & Space(3 - Len(Mid(Val(cnt1), 1, 3))) & Mid(Val(cnt1), 1, 3)
                                    SSQL = SSQL & "|" & Mid(gdataset.Tables("AITEM").Rows(ARR).Item("AITEMCODE"), 1, 8) & Space(8 - Len(Mid(gdataset.Tables("AITEM").Rows(ARR).Item("AITEMCODE"), 1, 8)))
                                    SSQL = SSQL & "|" & Mid(gdataset.Tables("AITEM").Rows(ARR).Item("AITEMDESC"), 1, 20) & Space(20 - Len(Mid(gdataset.Tables("AITEM").Rows(ARR).Item("AITEMDESC"), 1, 20)))
                                    SSQL = SSQL & "|" & Space(4 - Len(Mid(Format(gdataset.Tables("AITEM").Rows(ARR).Item("AQTY"), "0"), 1, 4))) & Mid(Format(gdataset.Tables("AITEM").Rows(ARR).Item("AQTY"), "0"), 1, 4)

                                    'SSQL = SSQL & "|" & Space(8 - Len(Mid(Format(gdataset.Tables("AITEM").Rows(ARR).Item("ARATE"), "0.00"), 1, 8))) & Mid(Format(gdataset.Tables("AITEM").Rows(ARR).Item("ARATE"), "0.00"), 1, 8)

                                    SSQL = SSQL & "|" & Space(8 - Len(Mid(Format(gdataset.Tables("AITEM").Rows(ARR).Item("AAMOUNT"), "0.00"), 1, 8))) & Mid(Format(gdataset.Tables("AITEM").Rows(ARR).Item("AAMOUNT"), "0.00"), 1, 8)

                                    If gdataset.Tables("AITEM").Rows(ARR).Item("ASBFCHARGE") = "Y" Then
                                        SSQL = SSQL & "|" & Space(8 - Len(Mid(Format((gdataset.Tables("AITEM").Rows(ARR).Item("AAMOUNT") * 0.02), "0.00"), 1, 8))) & Mid(Format((gdataset.Tables("AITEM").Rows(ARR).Item("AAMOUNT") * 0.02), "0.00"), 1, 8)
                                    Else
                                        SSQL = SSQL & "|" & Space(8)
                                    End If

                                    SSQL = SSQL & "|" & Space(9 - Len(Mid(Format(gdataset.Tables("AITEM").Rows(ARR).Item("ATAXAMOUNT"), "0.00"), 1, 9))) & Mid(Format(gdataset.Tables("AITEM").Rows(ARR).Item("ATAXAMOUNT"), "0.00"), 1, 9)
                                    SSQL = SSQL & "|" & Space(10 - Len(Mid(Format(gdataset.Tables("AITEM").Rows(ARR).Item("ATOTALAMOUNT"), "0.00"), 1, 10))) & Mid(Format(gdataset.Tables("AITEM").Rows(ARR).Item("ATOTALAMOUNT"), "0.00"), 1, 10) & "|"

                                    Filewrite.WriteLine(SSQL)
                                    pagesize = pagesize + 1
                                    ACODE = Trim(gdataset.Tables("AITEM").Rows(ARR).Item("AITEMCODE"))
                                    ARRAMT = ARRAMT + gdataset.Tables("AITEM").Rows(ARR).Item("AAMOUNT")
                                    ARRTAXAMT = ARRTAXAMT + gdataset.Tables("AITEM").Rows(ARR).Item("ATAXAMOUNT")
                                    ARRTOTALAMT = ARRTOTALAMT + gdataset.Tables("AITEM").Rows(ARR).Item("ATOTALAMOUNT")

                                    If gdataset.Tables("AITEM").Rows(ARR).Item("ASBFCHARGE") = "Y" Then
                                        ARRSBFAMT = ARRSBFAMT + (Val(gdataset.Tables("AITEM").Rows(ARR).Item("AAMOUNT")) * 0.02)
                                    End If

                                    cnt1 = cnt1 + 1
                                End If

                            End If
                        Next
                        RESSBFAMT = RESSBFAMT + ARRSBFAMT
                        If ARRAMT <> 0 Then
                            Filewrite.WriteLine(StrDup(79, "-"))
                            Filewrite.WriteLine(Space(11) & "Arrangement Total Amount : " & Space(10 - Len(Mid(Format(Val(ARRAMT), "0.00"), 1, 10))) & Mid(Format(Val(ARRAMT), "0.00"), 1, 10) & "|" & Space(8 - Len(Mid(Format(Val(ARRSBFAMT), "0.00"), 1, 8))) & Mid(Format(Val(ARRSBFAMT), "0.00"), 1, 8) & "|" & Space(9 - Len(Mid(Format(Val(ARRTAXAMT), "0.00"), 1, 9))) & Mid(Format(Val(ARRTAXAMT), "0.00"), 1, 9) & "|" & Space(10 - Len(Mid(Format(Val(ARRTOTALAMT), "0.00"), 1, 10))) & Mid(Format(Val(ARRTOTALAMT), "0.00"), 1, 10) & "|")
                            Filewrite.WriteLine(StrDup(79, "-"))
                            Filewrite.WriteLine()
                            pagesize = pagesize + 4

                            sqlstring = "UPDATE PARTY_HDR SET ARRMENTAMOUNT=" & Val(ARRAMT) & ",ARRMENTTAXAMOUNT=" & Val(ARRTAXAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                            GCONNECTION.getDataSet(sqlstring, "HallStatus")

                        End If
                    End If
                    If pagesize > 60 Then
                        For EMPTYLOOP = 1 To EMPTYSPACE
                            Filewrite.WriteLine()
                        Next

                        Filewrite.WriteLine(StrDup(79, "-"))
                        pagesize = 1
                    End If
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = "SELECT ISNULL(CANCELFLAG,'')AS CANCELFLAG FROM PARTY_VIEW_HALLBOOKINGDETAILS WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        GCONNECTION.getDataSet(sqlstring, "CANCEL")
                        If gdataset.Tables("CANCEL").Rows.Count > 0 Then
                            sqlstring = "SELECT ISNULL(HALLCANCELAMOUNT,0)AS HALLCANCELAMOUNT,ISNULL(FROMHRS,0)AS FROMHRS,ISNULL(TOHRS,0)AS TOHRS,ISNULL(CANCELDATE,'')AS CANCELDATE "
                            sqlstring = sqlstring & " FROM PARTY_HDR WHERE ISNULL(BOOKINGTYPE,'')='CANCEL' AND BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & ""
                            GCONNECTION.getDataSet(sqlstring, "CAN")
                            If gdataset.Tables("CAN").Rows.Count > 0 Then
                                Filewrite.Write("HALL CANCELLED BETWEEN " & Mid(gdataset.Tables("CAN").Rows(0).Item("FROMHRS"), 1, 5) & Space(5 - Len(Mid(gdataset.Tables("CAN").Rows(0).Item("FROMHRS"), 1, 5))))
                                Filewrite.Write(" TO " & Mid(gdataset.Tables("CAN").Rows(0).Item("TOHRS"), 1, 5) & Space(5 - Len(Mid(gdataset.Tables("CAN").Rows(0).Item("TOHRS"), 1, 5))))
                                Filewrite.WriteLine(" Hrs FROM THE DATE OF BOOKING")
                                Filewrite.WriteLine("HALL CANCEL AMOUNT : " & "Rs." & Mid(Format(gdataset.Tables("CAN").Rows(0).Item("HALLCANCELAMOUNT"), "0.00"), 1, 10) & Space(10 - Len(Mid(Format(gdataset.Tables("CAN").Rows(0).Item("HALLCANCELAMOUNT"), "0.00"), 1, 10))))
                                Filewrite.WriteLine("HALL CANCELLED DATE : " & Space(19 - Len(Mid(gdataset.Tables("CAN").Rows(0).Item("CANCELDATE"), 1, 19))) & Mid(gdataset.Tables("CAN").Rows(0).Item("CANCELDATE"), 1, 19))
                                pagesize = pagesize + 3
                            End If
                        End If
                    End If
                    If pagesize > 60 Then
                        For EMPTYLOOP = 1 To EMPTYSPACE
                            Filewrite.WriteLine()
                        Next

                        Filewrite.WriteLine(StrDup(79, "-"))
                        pagesize = 1
                    End If
                    Dim TAXTOTAL, GROSSTOTAL, NETTOTAL, STAX, VAT, CONT As Double

                    Dim SBFTAXAMOUNT As Double
                    Dim TEMP_RESSBFAMT As Double

                    Dim CONTSTAXAMOUNT As Double

                    TEMP_RESSBFAMT = Math.Round(RESSBFAMT, 2)
                    RESSBFAMT = Math.Floor(RESSBFAMT)
                    If TEMP_RESSBFAMT - RESSBFAMT >= 0.5 Then
                        RESSBFAMT = RESSBFAMT + 1
                    End If

                    SBFTAXAMOUNT = (RESSBFAMT * (SERVICETAXPERC / 100))

                    Dim temp_TAXTOTAL As Double
                    temp_TAXTOTAL = Math.Round(ARRTAXAMT + RESTAXAMT + halltaxamt + TARIFFTAXAMT + SBFTAXAMOUNT, 2)
                    TAXTOTAL = Math.Floor(ARRTAXAMT + RESTAXAMT + halltaxamt + TARIFFTAXAMT + SBFTAXAMOUNT)
                    If temp_TAXTOTAL - TAXTOTAL >= 0.5 Then
                        TAXTOTAL = TAXTOTAL + 1
                    End If
                    Dim temp_STAX As Double
                    Dim temp_VAT As Double


                    temp_VAT = Math.Round(CONTAXAMT, 2)
                    CONT = Math.Floor(CONTAXAMT)
                    If temp_VAT - CONT >= 0.5 Then
                        CONT = CONT + 1
                    End If

                    CONTSTAXAMOUNT = (CONT * (SERVICETAXPERC / 100))

                    STAX = Math.Floor(ARRTAXAMT + halltaxamt + SBFTAXAMOUNT + CONTSTAXAMOUNT)
                    temp_STAX = Math.Round(ARRTAXAMT + halltaxamt + SBFTAXAMOUNT + CONTSTAXAMOUNT, 2)
                    If temp_STAX - STAX >= 0.5 Then
                        STAX = STAX + 1
                    End If


                    VAT = Math.Floor(RESTAXAMT + TARIFFTAXAMT - CONTAXAMT)
                    temp_VAT = RESTAXAMT + TARIFFTAXAMT - CONTAXAMT
                    If temp_VAT - VAT >= 0.5 Then
                        VAT = VAT + 1
                    End If

                    sqlstring = "UPDATE PARTY_HDR SET CONT=" & Val(CONT) & ",STAX=" & Val(STAX) & ",VAT=" & Val(VAT) & ",SBFTAX=" & Val(SBFTAXAMOUNT) & ",SBFCHARGE=" & Val(RESSBFAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    GCONNECTION.getDataSet(sqlstring, "HallStatus")

                    GROSSTOTAL = ARRAMT + RESAMT + hallamt + TARIFFVALUE
                    NETTOTAL = GROSSTOTAL + VAT + CONT + STAX + RESSBFAMT - rcamt 'ARRTOTALAMT + RESTOTALAMT + hallnetamt + TARIFFVALUE + RESSBFAMT - rcamt

                    'new 08/07/2010


                    Filewrite.WriteLine(StrDup(79, "-"))
                    If SBFTAXAMOUNT <> 0 Then
                        Filewrite.WriteLine(Space(31) & "Service Tax @ " & Trim(Format(SERVICETAXPERC, "0.00")) & "% on SBF         : " & Space(10 - Len(Mid(Format(Val(SBFTAXAMOUNT), "0.00"), 1, 10))) & Mid(Format(Val(SBFTAXAMOUNT), "0.00"), 1, 10) & "|")
                    End If
                    If CONTSTAXAMOUNT <> 0 Then
                        Filewrite.WriteLine(Space(31) & "Service Tax @ " & Trim(Format(SERVICETAXPERC, "0.00")) & "% on CONTINGENCY : " & Space(10 - Len(Mid(Format(Val(CONTSTAXAMOUNT), "0.00"), 1, 10))) & Mid(Format(Val(CONTSTAXAMOUNT), "0.00"), 1, 10) & "|")
                    End If
                    If CONTSTAXAMOUNT + SBFTAXAMOUNT <> 0 Then
                        Filewrite.WriteLine(Space(31) & "Service Tax Sub Total              : " & Space(10 - Len(Mid(Format(Val(CONTSTAXAMOUNT + SBFTAXAMOUNT), "0.00"), 1, 10))) & Mid(Format(Val(CONTSTAXAMOUNT + SBFTAXAMOUNT), "0.00"), 1, 10) & "|")
                    End If
                    Filewrite.WriteLine(StrDup(79, "-"))


                    pagesize = pagesize + 5

                    Filewrite.WriteLine("SPECIAL PARTY " & Trim(CMBBOOKINGTYPE.Text) & " SUMMARY")

                    Filewrite.WriteLine(StrDup(79, "-"))
                    Filewrite.WriteLine(Space(48) & "Total Gross Amount: " & Space(10 - Len(Mid(Format(Val(GROSSTOTAL), "0.00"), 1, 10))) & Mid(Format(Val(GROSSTOTAL), "0.00"), 1, 10) & "|")
                    If VAT <> 0 Then
                        Filewrite.WriteLine(Space(48) & "Total VAT  Amount : " & Space(10 - Len(Mid(Format(Val(VAT), "0.00"), 1, 10))) & Mid(Format(Val(VAT), "0.00"), 1, 10) & "|")
                        pagesize = pagesize + 1
                    End If

                    If CONT <> 0 Then
                        Filewrite.WriteLine(Space(41) & "Total Contingency Amount : " & Space(10 - Len(Mid(Format(Val(CONT), "0.00"), 1, 10))) & Mid(Format(Val(CONT), "0.00"), 1, 10) & "|")
                        pagesize = pagesize + 1
                    End If

                    If STAX <> 0 Then
                        Filewrite.WriteLine(Space(41) & "Total Service Tax Amount : " & Space(10 - Len(Mid(Format(Val(STAX), "0.00"), 1, 10))) & Mid(Format(Val(STAX), "0.00"), 1, 10) & "|")
                        pagesize = pagesize + 1
                    End If

                    If RESSBFAMT <> 0 Then
                        Filewrite.WriteLine(Space(48) & "Total SBF Amount  : " & Space(10 - Len(Mid(Format(Val(RESSBFAMT), "0.00"), 1, 10))) & Mid(Format(Val(RESSBFAMT), "0.00"), 1, 10) & "|")
                        pagesize = pagesize + 1
                    End If

                    Filewrite.WriteLine(Space(48) & "Total Bill Amount : " & Space(10 - Len(Mid(Format(Val(GROSSTOTAL + VAT + STAX + RESSBFAMT + CONT), "0.00"), 1, 10))) & Mid(Format(Val(GROSSTOTAL + VAT + STAX + RESSBFAMT + CONT), "0.00"), 1, 10) & "|")
                    Filewrite.WriteLine(StrDup(79, "-"))
                    Filewrite.WriteLine(Space(48) & "Total Advance Paid: " & Space(10 - Len(Mid(Format(Val(rcamt), "0.00"), 1, 10))) & Mid(Format(Val(rcamt), "0.00"), 1, 10) & "|")
                    Filewrite.WriteLine(StrDup(79, "-"))
                    Filewrite.WriteLine(Space(48) & "Net Payable Amount: " & Space(10 - Len(Mid(Format(Val(NETTOTAL), "0.00"), 1, 10))) & Mid(Format(Val(NETTOTAL), "0.00"), 1, 10) & "|")
                    Filewrite.WriteLine(StrDup(79, "-"))
                    pagesize = pagesize + 9

                    sqlstring = "UPDATE PARTY_HDR SET CONT=" & Val(CONT) & ",STAX=" & Val(STAX) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    GCONNECTION.getDataSet(sqlstring, "HallStatus")

                    cnt1 = 1
                    'PAYMENT RECEIPT DETAILS
                    sqlstring = "SELECT RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'  AND AMOUNTTYPE LIKE '%BILL%'"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND ISNULL(RECEIPTNO,'')<>'' GROUP BY RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND ISNULL(RECEIPTNO,'')<>'' GROUP BY RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND ISNULL(RECEIPTNO,'')<>'' GROUP BY RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "RECEIPT")
                    If gdataset.Tables("RECEIPT").Rows.Count > 0 Then
                        Call BILLReciept_Heading(61)
                        For j = 0 To gdataset.Tables("RECEIPT").Rows.Count - 1
                            If RCTNO <> gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO") Then
                                If pagesize > 60 Then
                                    For EMPTYLOOP = 1 To EMPTYSPACE
                                        Filewrite.WriteLine()
                                    Next
                                    Filewrite.WriteLine(StrDup(72, "-"))
                                    pagesize = 1
                                    Call BILLReciept_Heading(pagesize)
                                End If
                                If Val(gdataset.Tables("RECEIPT").Rows(j).Item("Ramount")) <> 0 Then
                                    SSQL = "|" & Space(3 - Len(Mid(Val(cnt1), 1, 3))) & Mid(Val(cnt1), 1, 3)
                                    SSQL = SSQL & "|" & Mid(gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO"), 1, 20) & Space(20 - Len(Mid(gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO"), 1, 20)))
                                    SSQL = SSQL & "|" & Mid(Format(gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTDATE"), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTDATE"), "dd/MMM/yyyy"), 1, 11)))
                                    SSQL = SSQL & "|" & Mid(gdataset.Tables("RECEIPT").Rows(j).Item("AMOUNTTYPE"), 1, 20) & Space(20 - Len(Mid(gdataset.Tables("RECEIPT").Rows(j).Item("AMOUNTTYPE"), 1, 20)))
                                    SSQL = SSQL & "|" & Space(12 - Len(Mid(Format(gdataset.Tables("RECEIPT").Rows(j).Item("Ramount"), "0.00"), 1, 12))) & Mid(Format(gdataset.Tables("RECEIPT").Rows(j).Item("Ramount"), "0.00"), 1, 12) & "|"
                                    Filewrite.WriteLine(SSQL)
                                    pagesize = pagesize + 1
                                    RCTNO = gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO")
                                    rcamt = Val(rcamt) + gdataset.Tables("RECEIPT").Rows(j).Item("Ramount")
                                End If
                                cnt1 = cnt1 + 1
                            End If
                        Next j
                        Filewrite.WriteLine(StrDup(72, "-"))
                        Filewrite.WriteLine(Space(33) & "Bill Payment Total Amount" & "|" & Space(12 - Len(Mid(Format(Val(rcamt), "0.00"), 1, 12))) & Mid(Format(Val(rcamt), "0.00"), 1, 12) & "|")
                        sqlstring = "UPDATE PARTY_HDR SET ADVANCE=" & Val(rcamt) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        GCONNECTION.getDataSet(sqlstring, "HallStatus")

                        NETTOTAL = GROSSTOTAL + VAT + CONT + STAX + RESSBFAMT - rcamt

                        Filewrite.WriteLine(StrDup(79, "-"))
                        Filewrite.WriteLine(Space(48) & "Net Balance Amount: " & Space(10 - Len(Mid(Format(Val(NETTOTAL), "0.00"), 1, 10))) & Mid(Format(Val(NETTOTAL), "0.00"), 1, 10) & "|")
                        Filewrite.WriteLine(StrDup(79, "-"))
                        pagesize = pagesize + 6
                    End If

                    If pagesize > 60 Then
                        For EMPTYLOOP = 1 To EMPTYSPACE
                            Filewrite.WriteLine()
                        Next
                        Filewrite.WriteLine(StrDup(79, "-"))
                        pagesize = 1
                    End If
                    sqlstring = "UPDATE PARTY_HDR SET NETPAYABLE=" & Val(NETTOTAL) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    GCONNECTION.getDataSet(sqlstring, "HallStatus")
                    Dim tNETTOTAL As Double
                    tNETTOTAL = NETTOTAL
                    If NETTOTAL < 0 Then
                        NETTOTAL = NETTOTAL * -1
                    End If
                    Dim rupeesword As String
                    rupeesword = ConvertRupees(Format(Math.Round(NETTOTAL), "0.00"))

                    If Val(tNETTOTAL) <= 0 Then
                        Filewrite.WriteLine("|" & Mid(Trim("Excess Rupees " & Trim(rupeesword) & " Only."), 1, 75) & Space(77 - Len(Mid(Trim("Excess Rupees " & Trim(rupeesword) & "Only."), 1, 75))) & "|")
                    Else
                        Filewrite.WriteLine("|" & Mid(Trim("Rupees " & Trim(rupeesword) & " Only."), 1, 75) & Space(75 - Len(Mid(Trim("Rupees " & Trim(rupeesword) & "Only."), 1, 75))) & "|")
                    End If

                    Filewrite.WriteLine()
                    Filewrite.WriteLine("UserName : " & Mid(gUsername, 1, 15) & Space(15 - Len(Mid(gUsername, 1, 15))) & Space(10) & "PRINTED ON : " & Format(DateTime.Now, "dd/MMM/yyyy HH:mm"))
                    pagesize = pagesize + 3


                    Filewrite.WriteLine()
                    Filewrite.WriteLine()
                    Filewrite.WriteLine()
                    Filewrite.WriteLine("Prepared By        F & B Manager      Chief Accountant    Accounts Manager")

                    pagesize = pagesize + 4


                    Filewrite.Write(Chr(12))
                    Filewrite.Close()
                    If gPrint = False Then
                        OpenTextFile(vOutfile)
                    Else
                        PrintTextFile1(VFilePath)
                    End If
                Else
                    MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Finalbilling()
        Try
            Dim sqlstring, HALLCODE, RCTNO, TCODE, RCODE, ACODE As String
            Dim i, j, K, ARR, TAR, TAR1, cnt, cnt1 As Integer
            Dim hallamt, halltaxamt, hallnetamt, rcamt, RESAMT, RESTAXAMT, BARAMT, BARTAXAMT, CONAMT, CONTAXAMT, RESTOTALAMT, TARAMT, ARRAMT, ARRTAXAMT, ARRTOTALAMT, TARIFFTAXAMT As Double
            Dim dt As New DataTable
            Dim ABOOKINGOCCUPANCY, ABILLINGOCCUPANCY, BOOKINGOCCUPANCY, BILLINGOCCUPANCY, DIFFOCCUPANCY, ALLOWEDOCCUPANCY, RESSBFAMT, BARSBFAMT, BARTOTALAMT, CONTOTALAMT As Double
            Dim BOOKNO As Integer
            Dim TARSBFCHARGE As String
            Dim TRATE, DRATE, BOOKINGVALUE, DIFFVALUE, TARIFFVALUE As Double
            Dim TARIFFSBF As Double
            Dim PARTYDATE As DateTime

            Dim TAXTOTAL, GROSSTOTAL, NETTOTAL, STAX, VAT As Double
            Dim SBFTAXAMOUNT, temp_VAT, FBTOTAL, ARRSBFAMT As Double
            Dim noofchits As Integer

            Dim TAXABLERESAMT, WOTAXABLERESAMT As Double
            Dim TAXABLEBARAMT, WOTAXABLEBARAMT As Double

            sqlstring = "UPDATE PARTY_RESTAURANT SET TAXPERC=" & PRTAXPERC & " WHERE TTYPE='T' AND isnull(TAXPERC,0)=0"
            GCONNECTION.getDataSet(sqlstring, "HallStatus")

            sqlstring = "DELETE FROM PARTY_ARRANGEMENT WHERE SUBSTRING(ISNULL(ITEMCODE,''),1,1) NOT BETWEEN 'A' AND 'Z'"
            GCONNECTION.getDataSet(sqlstring, "HallStatus")

            pagesize = 1
            If TXTBOOKINGNO.Text <> "" Then
                sqlstring = "SELECT BOOKINGNO,SUM(BOOKINGOCCUPANCY) AS BOOKINGOCCUPANCY,SUM(BILLINGOCCUPANCY) AS BILLINGOCCUPANCY FROM PARTY_VIEW_BOOKINGVSBILLINGOCCUPANCY Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' GROUP BY BOOKINGNO"
                GCONNECTION.getDataSet(sqlstring, "HallStatus")
                If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                    BOOKINGOCCUPANCY = gdataset.Tables("Hallstatus").Rows(0).Item("BOOKINGOCCUPANCY")
                    BILLINGOCCUPANCY = gdataset.Tables("Hallstatus").Rows(0).Item("BILLINGOCCUPANCY")

                    ABOOKINGOCCUPANCY = gdataset.Tables("Hallstatus").Rows(0).Item("BOOKINGOCCUPANCY")
                    ABILLINGOCCUPANCY = gdataset.Tables("Hallstatus").Rows(0).Item("BILLINGOCCUPANCY")

                    If BILLINGOCCUPANCY <= 0 Then
                        BILLINGOCCUPANCY = BOOKINGOCCUPANCY
                    End If
                    DIFFOCCUPANCY = BILLINGOCCUPANCY - BOOKINGOCCUPANCY
                    'If DIFFOCCUPANCY <= 0 Then
                    '    DIFFOCCUPANCY = 0
                    'Else
                    '    Dim ALLOWEDOCCUPANCY1 As Double
                    '    ALLOWEDOCCUPANCY = Math.Floor(BOOKINGOCCUPANCY * (10 / 100))
                    '    ALLOWEDOCCUPANCY1 = BOOKINGOCCUPANCY * (10 / 100)
                    '    If ALLOWEDOCCUPANCY1 - ALLOWEDOCCUPANCY >= 0.5 Then
                    '        ALLOWEDOCCUPANCY = ALLOWEDOCCUPANCY + 1
                    '    End If
                    '    BOOKINGOCCUPANCY = BOOKINGOCCUPANCY + ALLOWEDOCCUPANCY
                    '    DIFFOCCUPANCY = DIFFOCCUPANCY - ALLOWEDOCCUPANCY
                    'End If
                End If

                sqlstring = "SELECT * FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' ORDER BY BOOKINGNO,TTYPE,RECEIPTNO"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' ORDER BY BOOKINGNO,TTYPE,RECEIPTNO"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' ORDER BY BOOKINGNO,TTYPE,RECEIPTNO"
                End If

                GCONNECTION.getDataSet(sqlstring, "HallStatus")

                vOutfile = Mid("out" & (Rnd() * 600000), 1, 8)
                VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
                Filewrite = File.AppendText(VFilePath)
                If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                    cnt = 1 : cnt1 = 1
                    For K = 0 To gdataset.Tables("Hallstatus").Rows.Count - 1
                        If BOOKNO <> gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGNO") Then

                            Filewrite.WriteLine(Chr(18) & Space(25) & Chr(27) + "E" & MyCompanyName & Chr(27) + "F")
                            pagesize = pagesize + 1

                            Filewrite.WriteLine(Space(40) & "Bill No : " & Space(5 - Len(Mid(gdataset.Tables("HALLSTATUS").Rows(K).Item("BOOKINGNO"), 1, 5))) & Mid(gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGNO"), 1, 5))
                            pagesize = pagesize + 1

                            If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                                Filewrite.WriteLine(Chr(27) + "E" & "BOOKING FOR FOOD & BEVERAGES" & Chr(27) + "F")
                            ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                                Filewrite.WriteLine(Chr(27) + "E" & "BILL FOR FOOD & BEVERAGES" & Chr(27) + "F")
                            Else
                                Filewrite.WriteLine(Chr(27) + "E" & "CANCL BILL FOR FOOD & BEVERAGES" & Chr(27) + "F")
                            End If
                            pagesize = pagesize + 1

                            If Trim(CMB_LOCATION.Text) = "A" Then
                                Filewrite.WriteLine("Items availed on : " & Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("PARTYDATE"), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("PARTYDate"), "dd/MMM/yyyy"), 1, 11))) & " at MAINCLUB")
                            Else
                                Filewrite.WriteLine("Items availed on : " & Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("PARTYDATE"), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("PARTYDate"), "dd/MMM/yyyy"), 1, 11))) & " at SAILING ANNEXE")
                            End If
                            Filewrite.WriteLine()
                            pagesize = pagesize + 2

                            Filewrite.WriteLine("Name : " & Mid(gdataset.Tables("HallStatus").Rows(K).Item("MNAME"), 1, 30) & Space(30 - Len(Mid(gdataset.Tables("HallStatus").Rows(K).Item("MNAME"), 1, 30))))
                            Filewrite.WriteLine()
                            pagesize = pagesize + 2

                            Filewrite.WriteLine("Membership No  : " & Mid(gdataset.Tables("HallStatus").Rows(K).Item("Mcode"), 1, 8) & Space(8 - Len(Mid(gdataset.Tables("HallStatus").Rows(K).Item("Mcode"), 1, 8))))
                            Filewrite.WriteLine(StrDup(67, "-"))
                            pagesize = pagesize + 2
                            BOOKNO = gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGNO")
                        End If
                    Next
                End If

                sqlstring = "SELECT CAST(CHITNO AS VARCHAR(20)) AS CHITNO,PARTYDATE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where CATEGORY='KITCHEN' AND bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY CHITNO,PARTYDATE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY CHITNO,PARTYDATE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY CHITNO,PARTYDATE"
                End If
                GCONNECTION.getDataSet(sqlstring, "RITEM")
                Dim CHITNO As String
                CHITNO = ""
                If gdataset.Tables("RITEM").Rows.Count > 0 Then
                    For TAR = 0 To gdataset.Tables("RITEM").Rows.Count - 1
                        If TAR = 0 Then
                            CHITNO = Mid(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO")), 1, Len(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO"))) - 2)
                            CHITNO = CHITNO & "/" & Mid(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO")), Len(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO"))) - 1, 2) & ","
                        Else
                            CHITNO = CHITNO & Mid(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO")), 1, Len(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO"))) - 2)
                            CHITNO = CHITNO & "/" & Mid(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO")), Len(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO"))) - 1, 2) & ","
                        End If
                        PARTYDATE = gdataset.Tables("RITEM").Rows(TAR).Item("PARTYDATE")
                        noofchits = noofchits + 1
                    Next
                    CHITNO = Mid(Trim(CHITNO), 1, Len(Trim(CHITNO)) - 1)
                End If
                Filewrite.WriteLine("Dinning Room Chit No(s)." & Mid(CHITNO, 1, 35) & Space(35 - Len(Mid(CHITNO, 1, 35))) & " Rs.")
                pagesize = pagesize + 1



                sqlstring = "SELECT PRROWID,TTYPE,RITEMCODE,RITEMDESC,RQTY,TRATE,TSBFCHARGE,PRTAXPERC FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='T' GROUP BY PRROWID,TTYPE,RITEMCODE,RITEMDESC,RQTY,TRATE,TSBFCHARGE,PRTAXPERC ORDER BY PRROWID"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='T' GROUP BY PRROWID,TTYPE,RITEMCODE,RITEMDESC,RQTY,TRATE,TSBFCHARGE,PRTAXPERC ORDER BY PRROWID"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='T' GROUP BY PRROWID,TTYPE,RITEMCODE,RITEMDESC,RQTY,TRATE,TSBFCHARGE,PRTAXPERC ORDER BY PRROWID"
                End If
                GCONNECTION.getDataSet(sqlstring, "TITEM")

                Dim C As Integer = 0
                SSQL = ""
                If gdataset.Tables("TITEM").Rows.Count > 0 Then
                    cnt1 = 1
                    For TAR1 = 0 To gdataset.Tables("TITEM").Rows.Count - 1
                        If Val(gdataset.Tables("TITEM").Rows(TAR1).Item("PRTAXPERC")) <> 0 Then
                            PRTAXPERC = Val(gdataset.Tables("TITEM").Rows(TAR1).Item("PRTAXPERC"))
                        End If
                        If TCODE <> Trim(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMCODE")) Then
                            If Trim(gdataset.Tables("TITEM").Rows(TAR1).Item("TTYPE")) = "T" Then
                                cnt1 = cnt1 + 1
                            End If
                            TCODE = Trim(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMCODE"))
                            TRATE = Val(gdataset.Tables("TITEM").Rows(TAR1).Item("TRATE"))
                            TARSBFCHARGE = Trim(gdataset.Tables("TITEM").Rows(TAR1).Item("TSBFCHARGE"))
                        End If
                    Next
                End If

                If DIFFOCCUPANCY > 0 Then
                    BOOKINGVALUE = BILLINGOCCUPANCY * TRATE
                    DRATE = (TRATE * (50 / 100))
                    DIFFVALUE = DIFFOCCUPANCY * DRATE
                    DIFFVALUE = 0
                Else
                    BOOKINGVALUE = BILLINGOCCUPANCY * TRATE
                    DRATE = TRATE + (TRATE * (50 / 100))
                    DIFFVALUE = 0
                End If

                TARIFFVALUE = BOOKINGVALUE + DIFFVALUE

                '                If TARSBFCHARGE = "Y" Then
                RESSBFAMT = RESSBFAMT + (TARIFFVALUE * 0)
                '           End If

                TARIFFSBF = TARIFFSBF + (TARIFFVALUE * 0)

                TARIFFTAXAMT = TARIFFTAXAMT + (TARIFFVALUE * (PRTAXPERC / 100))

                Filewrite.WriteLine(Space(4) & Mid(Trim(ABILLINGOCCUPANCY), 1, 3) & Space(3 - Len(Mid(Trim(ABILLINGOCCUPANCY), 1, 3))) & " PAX Spl Dinner @ Rs. " & Mid(Trim(Format(TRATE, "0")), 1, 3) & Space(3 - Len(Mid(Trim(Format(TRATE, "0")), 1, 3))) & Space(24) & Mid(Format(TARIFFVALUE, "0.00"), 1, 12) & Space(12 - Len(Mid(Format(TARIFFVALUE, "0.00"), 1, 12))))
                Filewrite.WriteLine()
                pagesize = pagesize + 2

                sqlstring = "SELECT TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where CATEGORY='KITCHEN' AND bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                End If
                GCONNECTION.getDataSet(sqlstring, "RITEM")
                If gdataset.Tables("RITEM").Rows.Count > 0 Then
                    cnt1 = 1
                    TAXABLERESAMT = 0 : WOTAXABLERESAMT = 0
                    For TAR = 0 To gdataset.Tables("RITEM").Rows.Count - 1
                        If RCODE <> Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE")) Then
                            If Trim(gdataset.Tables("RITEM").Rows(TAR).Item("TTYPE")) = "R" Then
                                If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")) <> 0 Then
                                    If gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT") <> 0 Then
                                        TAXABLERESAMT = TAXABLERESAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                    Else
                                        WOTAXABLERESAMT = WOTAXABLERESAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                    End If
                                    RESAMT = RESAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                    RESTAXAMT = RESTAXAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT")
                                    RESTOTALAMT = RESTOTALAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT")
                                    If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                        RESSBFAMT = RESSBFAMT + (gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0)
                                    End If
                                    cnt1 = cnt1 + 1
                                End If
                            End If
                            RCODE = Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"))
                        End If
                    Next
                    If Val(TAXABLERESAMT) <> 0 Then
                        Filewrite.WriteLine(Space(4) & "Dinning Items (Snacks etc.,)                    " & Space(12 - Len(Mid(Format(Val(TAXABLERESAMT), "0.00"), 1, 12))) & Mid(Format(Val(TAXABLERESAMT), "0.00"), 1, 12))
                        Filewrite.WriteLine()
                        pagesize = pagesize + 2
                    End If
                    If Val(WOTAXABLERESAMT) <> 0 Then
                        Filewrite.WriteLine(Space(4) & "Non Taxable Dinning Items                       " & Space(12 - Len(Mid(Format(Val(WOTAXABLERESAMT), "0.00"), 1, 12))) & Mid(Format(Val(WOTAXABLERESAMT), "0.00"), 1, 12))
                        Filewrite.WriteLine()
                        pagesize = pagesize + 2
                    End If
                    sqlstring = "UPDATE PARTY_HDR SET RESTAMOUNT=" & Val(RESAMT) & ",RESTTAXAMOUNT=" & Val(RESTAXAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    GCONNECTION.getDataSet(sqlstring, "HallStatus")
                End If

                sqlstring = "SELECT CHITNO,PARTYDATE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where CATEGORY like 'BAR%' AND bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY CHITNO,PARTYDATE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY CHITNO,PARTYDATE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY CHITNO,PARTYDATE"
                End If
                GCONNECTION.getDataSet(sqlstring, "RITEM")
                If gdataset.Tables("RITEM").Rows.Count > 0 Then
                    For TAR = 0 To gdataset.Tables("RITEM").Rows.Count - 1
                        If TAR = 0 Then
                            CHITNO = Mid(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO")), 1, Len(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO"))) - 2)
                            CHITNO = CHITNO & "/" & Mid(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO")), Len(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO"))) - 1, 2) & ","
                        Else
                            CHITNO = CHITNO & Mid(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO")), 1, Len(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO"))) - 2)
                            CHITNO = CHITNO & "/" & Mid(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO")), Len(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO"))) - 1, 2) & ","
                        End If

                        noofchits = noofchits + 1
                    Next
                    CHITNO = Mid(CHITNO, 1, Len(Trim(CHITNO)) - 1)
                End If

                sqlstring = "SELECT TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where CATEGORY like 'BARVAT' AND bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                End If
                GCONNECTION.getDataSet(sqlstring, "RITEM")
                If gdataset.Tables("RITEM").Rows.Count > 0 Then
                    cnt1 = 1
                    For TAR = 0 To gdataset.Tables("RITEM").Rows.Count - 1
                        If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXPERC")) <> 0 Then
                            PRTAXPERC = Val(gdataset.Tables("TITEM").Rows(TAR).Item("PRTAXPERC"))
                        End If
                        If RCODE <> Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE")) Then
                            If Trim(gdataset.Tables("RITEM").Rows(TAR).Item("TTYPE")) = "R" Then
                                If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")) <> 0 Then
                                    If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT")) <> 0 Then
                                        TAXABLEBARAMT = TAXABLEBARAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                    Else
                                        WOTAXABLEBARAMT = WOTAXABLEBARAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                    End If
                                    BARAMT = BARAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                    BARTAXAMT = BARTAXAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT")
                                    BARTOTALAMT = BARTOTALAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT")
                                    If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                        BARSBFAMT = BARSBFAMT + (gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0)
                                    End If
                                    cnt1 = cnt1 + 1
                                End If
                            End If
                            RCODE = Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"))
                        End If
                    Next
                End If

                'CONTAX
                sqlstring = "SELECT TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where CATEGORY like 'BARCONT' AND bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                End If
                GCONNECTION.getDataSet(sqlstring, "RITEM")
                If gdataset.Tables("RITEM").Rows.Count > 0 Then
                    cnt1 = 1
                    For TAR = 0 To gdataset.Tables("RITEM").Rows.Count - 1
                        If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXPERC")) <> 0 Then
                            PRTAXPERCCONT = Val(gdataset.Tables("TITEM").Rows(TAR).Item("PRTAXPERC"))
                        End If

                        If RCODE <> Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE")) Then
                            If Trim(gdataset.Tables("RITEM").Rows(TAR).Item("TTYPE")) = "R" Then
                                If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")) <> 0 Then
                                    If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT")) <> 0 Then
                                        TAXABLEBARAMT = TAXABLEBARAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                    Else
                                        WOTAXABLEBARAMT = WOTAXABLEBARAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                    End If
                                    CONAMT = CONAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                    CONTAXAMT = CONTAXAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT")
                                    CONTOTALAMT = CONTOTALAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT")
                                    If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                        BARSBFAMT = BARSBFAMT + (gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0)
                                    End If
                                    cnt1 = cnt1 + 1
                                End If
                            End If
                            RCODE = Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"))
                        End If
                    Next
                End If

                If CONAMT <> 0 Or BARAMT <> 0 Then
                    Filewrite.WriteLine("Bar Chit No(s)." & Mid(CHITNO, 1, 35) & Space(35 - Len(Mid(CHITNO, 1, 35))))
                    If Val(TAXABLEBARAMT) <> 0 Then
                        Filewrite.WriteLine(Space(4) & "Soft Drinks Items                               " & Space(12 - Len(Mid(Format(Val(TAXABLEBARAMT), "0.00"), 1, 12))) & Mid(Format(Val(TAXABLEBARAMT), "0.00"), 1, 12))
                        Filewrite.WriteLine()
                        pagesize = pagesize + 2
                    End If
                    If Val(WOTAXABLEBARAMT) <> 0 Then
                        Filewrite.WriteLine(Space(4) & "Non Taxable Bar Items                           " & Space(12 - Len(Mid(Format(Val(WOTAXABLEBARAMT), "0.00"), 1, 12))) & Mid(Format(Val(WOTAXABLEBARAMT), "0.00"), 1, 12))
                        Filewrite.WriteLine()
                        pagesize = pagesize + 2
                    End If
                    'RESSBFAMT = RESSBFAMT + BARSBFAMT
                    'RESAMT = RESAMT + BARAMT + CONAMT
                    'RESTAXAMT = RESTAXAMT + BARTAXAMT + CONTAXAMT

                    'sqlstring = "UPDATE PARTY_HDR SET RESTAMOUNT=" & Val(RESAMT) & ",RESTTAXAMOUNT=" & Val(RESTAXAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    'GCONNECTION.getDataSet(sqlstring, "UPDATION")
                Else
                    Filewrite.WriteLine()
                    pagesize = pagesize + 1
                End If


                'NEW ONE CONTRACTOR

                sqlstring = "SELECT CHITNO,PARTYDATE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where CATEGORY like 'CONTRACTOR' AND bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY CHITNO,PARTYDATE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY CHITNO,PARTYDATE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY CHITNO,PARTYDATE"
                End If
                GCONNECTION.getDataSet(sqlstring, "RITEM")
                If gdataset.Tables("RITEM").Rows.Count > 0 Then
                    For TAR = 0 To gdataset.Tables("RITEM").Rows.Count - 1
                        If TAR = 0 Then
                            CHITNO = Mid(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO")), 1, Len(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO"))) - 2)
                            CHITNO = CHITNO & "/" & Mid(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO")), Len(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO"))) - 1, 2) & ","
                        Else
                            CHITNO = CHITNO & Mid(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO")), 1, Len(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO"))) - 2)
                            CHITNO = CHITNO & "/" & Mid(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO")), Len(Trim(gdataset.Tables("RITEM").Rows(TAR).Item("CHITNO"))) - 1, 2) & ","
                        End If
                        noofchits = noofchits + 1
                    Next
                    CHITNO = Mid(CHITNO, 1, Len(Trim(CHITNO)) - 1)
                End If

                Dim TAXABLECONTRACTORAMT, WOTAXABLECONTRACTORAMT, CONTRACTORAMT, CONTRACTORTAXAMT, CONTRACTORTOTALAMT, CONTRACTORSBFAMT As Double
                sqlstring = "SELECT TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where CATEGORY like 'CONTRACTOR' AND bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                End If
                GCONNECTION.getDataSet(sqlstring, "RITEM")
                If gdataset.Tables("RITEM").Rows.Count > 0 Then
                    cnt1 = 1
                    For TAR = 0 To gdataset.Tables("RITEM").Rows.Count - 1
                        If RCODE <> Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE")) Then
                            If Trim(gdataset.Tables("RITEM").Rows(TAR).Item("TTYPE")) = "R" Then
                                If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")) <> 0 Then
                                    If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT")) <> 0 Then
                                        TAXABLEBARAMT = TAXABLEBARAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                        TAXABLECONTRACTORAMT = TAXABLECONTRACTORAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                    Else
                                        WOTAXABLEBARAMT = WOTAXABLEBARAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                        WOTAXABLECONTRACTORAMT = WOTAXABLECONTRACTORAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                    End If
                                    BARAMT = BARAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                    BARTAXAMT = BARTAXAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT")
                                    BARTOTALAMT = BARTOTALAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT")
                                    If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                        BARSBFAMT = BARSBFAMT + (gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0)
                                    End If

                                    CONTRACTORAMT = CONTRACTORAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                    CONTRACTORTAXAMT = CONTRACTORTAXAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT")
                                    CONTRACTORTOTALAMT = CONTRACTORTOTALAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT")
                                    If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                        CONTRACTORSBFAMT = CONTRACTORSBFAMT + (gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0)
                                    End If
                                    cnt1 = cnt1 + 1
                                End If
                            End If
                            RCODE = Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"))
                        End If
                    Next
                End If


                If CONTRACTORAMT <> 0 Then
                    Filewrite.WriteLine("Contractor Chit No(s)." & Mid(CHITNO, 1, 35) & Space(35 - Len(Mid(CHITNO, 1, 35))))
                    If Val(TAXABLEBARAMT) <> 0 Then
                        Filewrite.WriteLine(Space(4) & "Contractor Items                                " & Space(12 - Len(Mid(Format(Val(TAXABLECONTRACTORAMT), "0.00"), 1, 12))) & Mid(Format(Val(TAXABLECONTRACTORAMT), "0.00"), 1, 12))
                        Filewrite.WriteLine()
                        pagesize = pagesize + 2
                    End If
                    If Val(WOTAXABLEBARAMT) <> 0 Then
                        Filewrite.WriteLine(Space(4) & "Non Taxable Contractor Items                    " & Space(12 - Len(Mid(Format(Val(WOTAXABLECONTRACTORAMT), "0.00"), 1, 12))) & Mid(Format(Val(WOTAXABLECONTRACTORAMT), "0.00"), 1, 12))
                        Filewrite.WriteLine()
                        pagesize = pagesize + 2
                    End If


                Else
                    Filewrite.WriteLine()
                    pagesize = pagesize + 1
                End If


                RESSBFAMT = RESSBFAMT + BARSBFAMT
                RESAMT = RESAMT + BARAMT + CONAMT
                RESTAXAMT = RESTAXAMT + BARTAXAMT + CONTAXAMT

                sqlstring = "UPDATE PARTY_HDR SET RESTAMOUNT=" & Val(RESAMT) & ",RESTTAXAMOUNT=" & Val(RESTAXAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                GCONNECTION.getDataSet(sqlstring, "UPDATION")

                Dim CONT, CONTSTAXAMOUNT As Double

                VAT = Math.Floor(RESTAXAMT + TARIFFTAXAMT - CONTAXAMT)
                temp_VAT = RESTAXAMT + TARIFFTAXAMT - CONTAXAMT
                If temp_VAT - VAT >= 0.5 Then
                    VAT = VAT + 1
                End If

                CONT = Math.Floor(CONTAXAMT)
                temp_VAT = CONTAXAMT
                If temp_VAT - CONT >= 0.5 Then
                    CONT = CONT + 1
                End If

                CONTSTAXAMOUNT = (CONT * (SERVICETAXPERC / 100))

                FBTOTAL = 0
                FBTOTAL = CONT + VAT + RESAMT + TARIFFVALUE

                sqlstring = "UPDATE PARTY_HDR SET CONT=" & Val(CONT) & ",VAT=" & Val(VAT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                GCONNECTION.getDataSet(sqlstring, "HallStatus")

                If VAT > 0 Then
                    Filewrite.WriteLine("ADD ON CIGARETTES & TOTAL DINING ITEMS VAT @ " & Trim(Format(Val(PRTAXPERC), "0.00")) & "%   " & Space(12 - Len(Mid(Format(Val(VAT), "0.00"), 1, 12))) & Mid(Format(Val(VAT), "0.00"), 1, 12))
                    pagesize = pagesize + 1
                End If

                If CONT > 0 Then
                    Filewrite.WriteLine("    ON LIQUOR                 CONTINGENCY @ " & Trim(Format(Val(PRTAXPERCCONT), "0.00")) & "%   " & Space(12 - Len(Mid(Format(Val(CONT), "0.00"), 1, 12))) & Mid(Format(Val(CONT), "0.00"), 1, 12))
                    pagesize = pagesize + 1
                End If

                Filewrite.WriteLine(StrDup(67, "-"))
                pagesize = pagesize + 1
                Filewrite.WriteLine("                                    Total           " & Space(12 - Len(Mid(Format(Val(FBTOTAL), "0.00"), 1, 12))) & Mid(Format(Val(FBTOTAL), "0.00"), 1, 12))
                pagesize = pagesize + 1
                Filewrite.WriteLine(StrDup(67, "-"))

                Filewrite.WriteLine()
                Filewrite.WriteLine("BILL PRINTED ON : " & Format(DateTime.Now, "dd/MMM/yyyy HH:mm"))

                pagesize = pagesize + 2
                '                Filewrite.WriteLine("DATE : " & Mid(Format(Now(), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(Now(), "dd/MMM/yyyy"), 1, 11))) & Space(30) & "Accounts Manager")


                Filewrite.WriteLine()
                Filewrite.WriteLine()
                Filewrite.WriteLine("Prepared By    Chief Accountant    Accounts Manager    Asst.Secy/Dy.Secy./Secy.")

                pagesize = pagesize + 3

                Filewrite.Write(Chr(12))

                ' SUPPLIMENTARY BILL

                sqlstring = "SELECT * FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' ORDER BY BOOKINGNO,TTYPE,RECEIPTNO"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' ORDER BY BOOKINGNO,TTYPE,RECEIPTNO"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' ORDER BY BOOKINGNO,TTYPE,RECEIPTNO"
                End If
                GCONNECTION.getDataSet(sqlstring, "HallStatus")
                If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                    cnt = 1 : cnt1 = 1
                    BOOKNO = 0
                    For K = 0 To gdataset.Tables("Hallstatus").Rows.Count - 1
                        If BOOKNO <> gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGNO") Then

                            Filewrite.WriteLine(Chr(18) & Space(25) & Chr(27) + "E" & MyCompanyName & Chr(27) + "F")
                            pagesize = pagesize + 1

                            Filewrite.WriteLine(Space(40) & "Bill No : " & Space(5 - Len(Mid(gdataset.Tables("HALLSTATUS").Rows(K).Item("BOOKINGNO"), 1, 5))) & Mid(gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGNO"), 1, 5) & " A")
                            pagesize = pagesize + 1

                            If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                                Filewrite.WriteLine(Chr(27) + "E" & "Supplimentary Booking for Facilities" & Chr(27) + "F")
                            ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                                Filewrite.WriteLine(Chr(27) + "E" & "Supplimentary Bill for Facilities" & Chr(27) + "F")
                            Else
                                Filewrite.WriteLine(Chr(27) + "E" & "CANCL Supplimentary Bill for Facilities" & Chr(27) + "F")
                            End If
                            pagesize = pagesize + 1

                            If Trim(CMB_LOCATION.Text) = "A" Then
                                Filewrite.WriteLine("Availed on       : " & Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("PARTYDATE"), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("PARTYDate"), "dd/MMM/yyyy"), 1, 11))) & " at MAINCLUB")
                            Else
                                Filewrite.WriteLine("Availed on       : " & Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("PARTYDATE"), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("PARTYDate"), "dd/MMM/yyyy"), 1, 11))) & " at SAILING ANNEXE")
                            End If

                            Filewrite.WriteLine()
                            pagesize = pagesize + 2

                            Filewrite.WriteLine("Name : " & Mid(gdataset.Tables("HallStatus").Rows(K).Item("MNAME"), 1, 30) & Space(30 - Len(Mid(gdataset.Tables("HallStatus").Rows(K).Item("MNAME"), 1, 30))))
                            Filewrite.WriteLine()
                            pagesize = pagesize + 2

                            Filewrite.WriteLine("Membership No  : " & Mid(gdataset.Tables("HallStatus").Rows(K).Item("Mcode"), 1, 8) & Space(8 - Len(Mid(gdataset.Tables("HallStatus").Rows(K).Item("Mcode"), 1, 8))))
                            Filewrite.WriteLine(StrDup(67, "-"))
                            pagesize = pagesize + 2

                            Filewrite.WriteLine(Space(58) & "Rs.")
                            pagesize = pagesize + 1
                            BOOKNO = gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGNO")


                            Filewrite.WriteLine("Facility Provided Vide Bill No." & Space(5 - Len(Mid(gdataset.Tables("HALLSTATUS").Rows(K).Item("BOOKINGNO"), 1, 5))) & Mid(gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGNO"), 1, 5) & Space(16) & Space(12 - Len(Mid(Format(Val(FBTOTAL), "0.00"), 1, 12))) & Mid(Format(Val(FBTOTAL), "0.00"), 1, 12))
                            Filewrite.WriteLine()
                            pagesize = pagesize + 2
                        End If
                    Next
                End If



                sqlstring = "SELECT AITEMCODE,AITEMDESC,AQTY,ARATE,AAMOUNT,ATAXAMOUNT,ATOTALAMOUNT,ASBFCHARGE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND ISNULL(AITEMCODE,'')<>'' GROUP BY AITEMCODE,AITEMDESC,AQTY,ARATE,AAMOUNT,ATAXAMOUNT,ATOTALAMOUNT,ASBFCHARGE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND ISNULL(AITEMCODE,'')<>'' GROUP BY AITEMCODE,AITEMDESC,AQTY,ARATE,AAMOUNT,ATAXAMOUNT,ATOTALAMOUNT,ASBFCHARGE"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y'  AND ISNULL(AITEMCODE,'')<>'' GROUP BY AITEMCODE,AITEMDESC,AQTY,ARATE,AAMOUNT,ATAXAMOUNT,ATOTALAMOUNT,ASBFCHARGE"
                End If
                GCONNECTION.getDataSet(sqlstring, "AITEM")
                If gdataset.Tables("AITEM").Rows.Count > 0 Then
                    cnt1 = 1
                    For ARR = 0 To gdataset.Tables("AITEM").Rows.Count - 1
                        If ACODE <> Trim(gdataset.Tables("AITEM").Rows(ARR).Item("AITEMCODE")) Then
                            If Val(gdataset.Tables("AITEM").Rows(ARR).Item("AAMOUNT")) <> 0 Then
                                ACODE = Trim(gdataset.Tables("AITEM").Rows(ARR).Item("AITEMCODE"))
                                ARRAMT = ARRAMT + gdataset.Tables("AITEM").Rows(ARR).Item("AAMOUNT")
                                ARRTAXAMT = ARRTAXAMT + gdataset.Tables("AITEM").Rows(ARR).Item("ATAXAMOUNT")
                                ARRTOTALAMT = ARRTOTALAMT + gdataset.Tables("AITEM").Rows(ARR).Item("ATOTALAMOUNT")
                                If gdataset.Tables("AITEM").Rows(ARR).Item("ASBFCHARGE") = "Y" Then
                                    ARRSBFAMT = ARRSBFAMT + (Val(gdataset.Tables("AITEM").Rows(ARR).Item("AAMOUNT")) * 0)
                                End If
                                cnt1 = cnt1 + 1
                            End If

                        End If
                    Next

                    RESSBFAMT = RESSBFAMT + ARRSBFAMT
                    If ARRAMT <> 0 Then
                        sqlstring = "UPDATE PARTY_HDR SET ARRMENTAMOUNT=" & Val(ARRAMT) & ",ARRMENTTAXAMOUNT=" & Val(ARRTAXAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        GCONNECTION.getDataSet(sqlstring, "HallStatus")
                    End If
                End If

                If Val(ARRAMT) <> 0 Then
                    Filewrite.WriteLine("Arrangement Items                                   " & Space(12 - Len(Mid(Format(Val(ARRAMT), "0.00"), 1, 12))) & Mid(Format(Val(ARRAMT), "0.00"), 1, 12))
                    Filewrite.WriteLine()
                    pagesize = pagesize + 2
                End If


                sqlstring = "SELECT Hallcode,HallDesc,PDesc,fromtime,totime,Hallamount,HALLTAXAMOUNT,HALLTAXPERC,HALLNETAMOUNT FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' GROUP BY Hallcode,HallDesc,PDesc,fromtime,totime,Hallamount,HALLTAXAMOUNT,HALLTAXPERC,HALLNETAMOUNT"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' GROUP BY Hallcode,HallDesc,PDesc,fromtime,totime,Hallamount,HALLTAXAMOUNT,HALLTAXPERC,HALLNETAMOUNT"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' GROUP BY Hallcode,HallDesc,PDesc,fromtime,totime,Hallamount,HALLTAXAMOUNT,HALLTAXPERC,HALLNETAMOUNT"
                End If
                GCONNECTION.getDataSet(sqlstring, "HALL")
                If gdataset.Tables("HALL").Rows.Count > 0 Then
                    For i = 0 To gdataset.Tables("HALL").Rows.Count - 1
                        If HALLCODE <> gdataset.Tables("HALL").Rows(i).Item("HALLCODE") Then
                            cnt = cnt + 1
                            hallamt = Val(hallamt) + gdataset.Tables("HALL").Rows(i).Item("HALLAMOUNT")
                            halltaxamt = Val(halltaxamt) + gdataset.Tables("HALL").Rows(i).Item("HALLtaxAMOUNT")
                            hallnetamt = Val(hallnetamt) + gdataset.Tables("HALL").Rows(i).Item("HALLNETAMOUNT")
                            HALLCODE = gdataset.Tables("HALL").Rows(i).Item("HALLCODE")
                        End If
                    Next
                    sqlstring = "UPDATE PARTY_HDR SET HALLAMOUNT=" & Val(hallamt) & ",HALLTAXAMOUNT=" & Val(halltaxamt) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    GCONNECTION.getDataSet(sqlstring, "HallStatus")
                End If

                If Val(hallamt) <> 0 Then
                    Filewrite.WriteLine("Air Condiiton Charges                               " & Space(12 - Len(Mid(Format(Val(hallamt), "0.00"), 1, 12))) & Mid(Format(Val(hallamt), "0.00"), 1, 12))
                    Filewrite.WriteLine()
                    pagesize = pagesize + 2
                End If

                Dim TEMP_RESSBFAMT As Double
                TEMP_RESSBFAMT = Math.Round(RESSBFAMT, 2)
                RESSBFAMT = Math.Floor(RESSBFAMT)
                If TEMP_RESSBFAMT - RESSBFAMT >= 0.5 Then
                    RESSBFAMT = RESSBFAMT + 1
                End If

                SBFTAXAMOUNT = (RESSBFAMT * 0.103)

                Dim temp_TAXTOTAL As Double
                temp_TAXTOTAL = Math.Round(ARRTAXAMT + RESTAXAMT + halltaxamt + TARIFFTAXAMT + SBFTAXAMOUNT, 2)
                TAXTOTAL = Math.Floor(ARRTAXAMT + RESTAXAMT + halltaxamt + TARIFFTAXAMT + SBFTAXAMOUNT)
                If temp_TAXTOTAL - TAXTOTAL >= 0.5 Then
                    TAXTOTAL = TAXTOTAL + 1
                End If
                Dim temp_STAX As Double

                temp_STAX = Math.Round(ARRTAXAMT + halltaxamt + SBFTAXAMOUNT + CONTSTAXAMOUNT, 2)
                STAX = Math.Floor(ARRTAXAMT + halltaxamt + SBFTAXAMOUNT + CONTSTAXAMOUNT)
                If temp_STAX - STAX >= 0.5 Then
                    STAX = STAX + 1
                End If


                temp_VAT = Math.Round(RESTAXAMT + TARIFFTAXAMT - CONTAXAMT, 2)
                VAT = Math.Floor(RESTAXAMT + TARIFFTAXAMT - CONTAXAMT)
                If temp_VAT - VAT >= 0.5 Then
                    VAT = VAT + 1
                End If

                temp_VAT = Math.Round(CONTAXAMT, 2)
                CONT = Math.Floor(CONTAXAMT)
                If temp_VAT - CONT >= 0.5 Then
                    CONT = CONT + 1
                End If

                GROSSTOTAL = ARRAMT + RESAMT + hallamt + TARIFFVALUE
                NETTOTAL = GROSSTOTAL + VAT + STAX + RESSBFAMT + CONT


                sqlstring = "UPDATE PARTY_HDR SET CONT=" & Val(CONT) & ",VAT=" & Val(VAT) & ",STAX=" & Val(STAX) & ",SBFTAX=" & Val(SBFTAXAMOUNT) & ",SBFCHARGE=" & Val(RESSBFAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                GCONNECTION.getDataSet(sqlstring, "HallStatus")

                If Val(RESSBFAMT) <> 0 Then
                    Filewrite.WriteLine("Staff Benefits                                      " & Space(12 - Len(Mid(Format(Val(RESSBFAMT), "0.00"), 1, 12))) & Mid(Format(Val(RESSBFAMT), "0.00"), 1, 12))
                    Filewrite.WriteLine()
                    pagesize = pagesize + 2
                End If

                If Val(STAX) <> 0 Then
                    Filewrite.WriteLine("                                Service Tax @ " & Trim(Format(Val(SERVICETAXPERC), "0.00")) & "% " & Space(12 - Len(Mid(Format(Val(STAX), "0.00"), 1, 12))) & Mid(Format(Val(STAX), "0.00"), 1, 12))
                    Filewrite.WriteLine()
                    pagesize = pagesize + 2
                End If

                Filewrite.WriteLine(Space(50) & StrDup(17, "-"))
                pagesize = pagesize + 1

                Filewrite.WriteLine("                                    Total           " & Space(12 - Len(Mid(Format(Val(NETTOTAL), "0.00"), 1, 12))) & Mid(Format(Val(NETTOTAL), "0.00"), 1, 12))
                pagesize = pagesize + 1

                Filewrite.WriteLine(Space(50) & StrDup(17, "-"))
                pagesize = pagesize + 1

                sqlstring = "SELECT RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND AMOUNTTYPE LIKE '%ADVANCE%'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND ISNULL(RECEIPTNO,'')<>'' GROUP BY RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND ISNULL(RECEIPTNO,'')<>'' GROUP BY RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND ISNULL(RECEIPTNO,'')<>'' GROUP BY RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount"
                End If
                GCONNECTION.getDataSet(sqlstring, "RECEIPT")
                If gdataset.Tables("RECEIPT").Rows.Count > 0 Then
                    For j = 0 To gdataset.Tables("RECEIPT").Rows.Count - 1
                        If RCTNO <> gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO") Then
                            If Val(gdataset.Tables("RECEIPT").Rows(j).Item("Ramount")) <> 0 Then
                                SSQL = "Adv " & Mid(gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO"), 1, 20) & Space(20 - Len(Mid(gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO"), 1, 20)))
                                SSQL = SSQL & " Dt." & Mid(Format(gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTDATE"), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTDATE"), "dd/MMM/yyyy"), 1, 11)))
                                SSQL = SSQL & " Rs." & Mid(Format(gdataset.Tables("RECEIPT").Rows(j).Item("Ramount"), "0.00"), 1, 12) & Space(12 - Len(Mid(Format(gdataset.Tables("RECEIPT").Rows(j).Item("Ramount"), "0.00"), 1, 12)))
                                Filewrite.WriteLine(SSQL)
                                pagesize = pagesize + 1
                                RCTNO = gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO")
                                rcamt = Val(rcamt) + gdataset.Tables("RECEIPT").Rows(j).Item("Ramount")
                            End If
                            cnt1 = cnt1 + 1
                        End If
                    Next j
                    sqlstring = "UPDATE PARTY_HDR SET ADVANCE=" & Val(rcamt) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    GCONNECTION.getDataSet(sqlstring, "HallStatus")
                End If
                Filewrite.WriteLine("                        Less Advance Paid           " & Space(12 - Len(Mid(Format(Val(rcamt), "0.00"), 1, 12))) & Mid(Format(Val(rcamt), "0.00"), 1, 12))
                pagesize = pagesize + 1

                Filewrite.WriteLine(Space(50) & StrDup(17, "-"))
                pagesize = pagesize + 1


                NETTOTAL = GROSSTOTAL + VAT + STAX + RESSBFAMT + CONT - Val(rcamt)

                Filewrite.WriteLine("                                 Net Due            " & Space(12 - Len(Mid(Format(Val(NETTOTAL), "0.00"), 1, 12))) & Mid(Format(Val(NETTOTAL), "0.00"), 1, 12))
                pagesize = pagesize + 1

                Dim tNETTOTAL As Double
                tNETTOTAL = NETTOTAL
                If NETTOTAL < 0 Then
                    NETTOTAL = NETTOTAL * -1
                End If
                Dim rupeesword As String
                rupeesword = ConvertRupees(Format(Math.Round(NETTOTAL), "0.00"))

                If Val(tNETTOTAL) <= 0 Then
                    Filewrite.WriteLine(Mid(Trim("Excess Rupees " & Trim(rupeesword) & " Only."), 1, 75) & Space(77 - Len(Mid(Trim("Excess Rupees " & Trim(rupeesword) & "Only."), 1, 75))))
                Else
                    Filewrite.WriteLine(Mid(Trim("Rupees " & Trim(rupeesword) & " Only."), 1, 75) & Space(75 - Len(Mid(Trim("Rupees " & Trim(rupeesword) & "Only."), 1, 75))))
                End If
                Filewrite.WriteLine()
                pagesize = pagesize + 2

                If noofchits <= 0 Then
                    noofchits = 1
                End If
                Filewrite.WriteLine("Encl. No. of Chits " & Space(3 - Len(Mid(Format(Val(noofchits), "0"), 1, 3))) & Mid(Format(Val(noofchits), "0"), 1, 3))
                pagesize = pagesize + 1


                Filewrite.WriteLine(StrDup(67, "-"))
                pagesize = pagesize + 1

                Filewrite.WriteLine("NOTE : TO BE PAID WITHIN 7 DAYS FAILING WHICH")
                Filewrite.WriteLine("         CREDIT IS LIABLE TO BE STOPPED")

                Filewrite.WriteLine("")
                Filewrite.WriteLine("BILL PRINTED ON : " & Format(DateTime.Now, "dd/MMM/yyyy HH:mm"))

                '                Filewrite.WriteLine("DATE : " & Mid(Format(Now(), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(Now(), "dd/MMM/yyyy"), 1, 11))) & Space(30) & "Accounts Manager")

                pagesize = pagesize + 4

                Filewrite.WriteLine()
                Filewrite.WriteLine()
                Filewrite.WriteLine("Prepared By    Chief Accountant    Accounts Manager    Asst.Secy/Dy.Secy./Secy.")

                Filewrite.WriteLine()
                Filewrite.WriteLine()
                Filewrite.WriteLine()
                Filewrite.WriteLine()
                Filewrite.WriteLine()
                Filewrite.WriteLine()

                Filewrite.WriteLine(Chr(14) & Space(7) & "We thank you for your patronage" & Chr(18))
                Filewrite.WriteLine()
                Filewrite.WriteLine()

                Filewrite.WriteLine(Chr(14) & Space(7) & "                      Secretary" & Chr(18))

                pagesize = pagesize + 12


                sqlstring = "UPDATE PARTY_HDR SET NETPAYABLE=" & Val(NETTOTAL) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                GCONNECTION.getDataSet(sqlstring, "HallStatus")

                Filewrite.Write(Chr(12))
                Filewrite.Close()
                If gPrint = False Then
                    OpenTextFile(vOutfile)
                Else
                    PrintTextFile1(VFilePath)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub hallbillingcalculate()
        Try
            Dim sqlstring, HALLCODE, RCTNO, TCODE, RCODE, ACODE As String
            Dim i, j, K, ARR, TAR, TAR1, cnt, cnt1 As Integer
            Dim hallamt, halltaxamt, hallnetamt, rcamt, RESAMT, RESTAXAMT, BARAMT, BARTAXAMT, RESTOTALAMT, TARAMT, ARRAMT, ARRTAXAMT, ARRTOTALAMT, TARIFFTAXAMT As Double
            Dim dt As New DataTable
            Dim ABOOKINGOCCUPANCY, ABILLINGOCCUPANCY, BOOKINGOCCUPANCY, BILLINGOCCUPANCY, DIFFOCCUPANCY, ALLOWEDOCCUPANCY, RESSBFAMT, BARSBFAMT, BARTOTALAMT As Double
            Dim BOOKNO As Integer
            Dim TARSBFCHARGE As String
            If TXTBOOKINGNO.Text <> "" Then
                sqlstring = "SELECT BOOKINGNO,SUM(BOOKINGOCCUPANCY) AS BOOKINGOCCUPANCY,SUM(BILLINGOCCUPANCY) AS BILLINGOCCUPANCY FROM PARTY_VIEW_BOOKINGVSBILLINGOCCUPANCY Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' GROUP BY BOOKINGNO"
                GCONNECTION.getDataSet(sqlstring, "HallStatus")
                If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                    BOOKINGOCCUPANCY = gdataset.Tables("Hallstatus").Rows(0).Item("BOOKINGOCCUPANCY")
                    BILLINGOCCUPANCY = gdataset.Tables("Hallstatus").Rows(0).Item("BILLINGOCCUPANCY")
                    ABOOKINGOCCUPANCY = gdataset.Tables("Hallstatus").Rows(0).Item("BOOKINGOCCUPANCY")
                    ABILLINGOCCUPANCY = gdataset.Tables("Hallstatus").Rows(0).Item("BILLINGOCCUPANCY")

                    If BILLINGOCCUPANCY <= 0 Then
                        BILLINGOCCUPANCY = BOOKINGOCCUPANCY
                    End If
                    DIFFOCCUPANCY = BILLINGOCCUPANCY - BOOKINGOCCUPANCY

                    'If DIFFOCCUPANCY <= 0 Then
                    '    DIFFOCCUPANCY = 0
                    'Else
                    '    ALLOWEDOCCUPANCY = Math.Floor(BOOKINGOCCUPANCY * (10 / 100))
                    '    If Math.Ceiling(BOOKINGOCCUPANCY * (10 / 100)) > 0 Then
                    '        ALLOWEDOCCUPANCY = ALLOWEDOCCUPANCY + 1
                    '    End If
                    '    BOOKINGOCCUPANCY = BOOKINGOCCUPANCY + ALLOWEDOCCUPANCY
                    '    DIFFOCCUPANCY = DIFFOCCUPANCY - ALLOWEDOCCUPANCY
                    'End If
                    sqlstring = "UPDATE PARTY_HDR SET BOOKINGOCCUPANCY=" & Val(BOOKINGOCCUPANCY) & ",BILLINGOCCUPANCY=" & Val(BILLINGOCCUPANCY) & ",ABOOKINGOCCUPANCY=" & Val(ABOOKINGOCCUPANCY) & ",ABILLINGOCCUPANCY=" & Val(ABILLINGOCCUPANCY) & ",ALLOWEDOCCUPANCY=" & Val(ALLOWEDOCCUPANCY) & ",DIFFOCCUPANCY=" & Val(DIFFOCCUPANCY) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    GCONNECTION.getDataSet(sqlstring, "HallStatus")
                End If

                sqlstring = "SELECT * FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                    sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' ORDER BY BOOKINGNO,TTYPE,RECEIPTNO"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                    sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' ORDER BY BOOKINGNO,TTYPE,RECEIPTNO"
                ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                    sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' ORDER BY BOOKINGNO,TTYPE,RECEIPTNO"
                End If
                GCONNECTION.getDataSet(sqlstring, "HallStatus")
                If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                    'HALL DETAILS
                    sqlstring = "SELECT Hallcode,HallDesc,PDesc,fromtime,totime,Hallamount,HALLTAXAMOUNT,HALLTAXPERC,HALLNETAMOUNT,SEDEPOSIT FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' GROUP BY Hallcode,HallDesc,PDesc,fromtime,totime,Hallamount,HALLTAXAMOUNT,HALLTAXPERC,HALLNETAMOUNT,SEDEPOSIT"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' GROUP BY Hallcode,HallDesc,PDesc,fromtime,totime,Hallamount,HALLTAXAMOUNT,HALLTAXPERC,HALLNETAMOUNT,SEDEPOSIT"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' GROUP BY Hallcode,HallDesc,PDesc,fromtime,totime,Hallamount,HALLTAXAMOUNT,HALLTAXPERC,HALLNETAMOUNT,SEDEPOSIT"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "HALL")
                    If gdataset.Tables("HALL").Rows.Count > 0 Then
                        For i = 0 To gdataset.Tables("HALL").Rows.Count - 1
                            If HALLCODE <> gdataset.Tables("HALL").Rows(i).Item("HALLCODE") Then
                                hallamt = Val(hallamt) + gdataset.Tables("HALL").Rows(i).Item("HALLAMOUNT")
                                halltaxamt = Val(halltaxamt) + gdataset.Tables("HALL").Rows(i).Item("HALLtaxAMOUNT")
                                hallnetamt = Val(hallnetamt) + gdataset.Tables("HALL").Rows(i).Item("HALLNETAMOUNT")
                                HALLCODE = gdataset.Tables("HALL").Rows(i).Item("HALLCODE")
                            End If
                        Next
                        sqlstring = "UPDATE PARTY_HDR SET hallamt=" & Val(hallamt) & ",halltaxamt=" & Val(halltaxamt) & ",hallnetamt=" & Val(hallnetamt) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        GCONNECTION.getDataSet(sqlstring, "HallStatus")
                    End If
                    'RECEIPT DETAILS

                    sqlstring = "SELECT RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND ISNULL(RECEIPTNO,'')<>'' GROUP BY RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND ISNULL(RECEIPTNO,'')<>'' GROUP BY RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND ISNULL(RECEIPTNO,'')<>'' GROUP BY RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,Ramount"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "RECEIPT")
                    If gdataset.Tables("RECEIPT").Rows.Count > 0 Then
                        For j = 0 To gdataset.Tables("RECEIPT").Rows.Count - 1
                            If RCTNO <> gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO") Then
                                If Val(gdataset.Tables("RECEIPT").Rows(j).Item("Ramount")) <> 0 Then
                                    RCTNO = gdataset.Tables("RECEIPT").Rows(j).Item("RECEIPTNO")
                                    rcamt = Val(rcamt) + gdataset.Tables("RECEIPT").Rows(j).Item("Ramount")
                                End If
                            End If
                        Next j
                        sqlstring = "UPDATE PARTY_HDR SET rcamt=" & Val(rcamt) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        GCONNECTION.getDataSet(sqlstring, "HallStatus")
                    End If

                    'ADDITIONAL ITEMS DETAILS FOR KITCHEN
                    sqlstring = "SELECT TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where CATEGORY='KITCHEN' AND bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "RITEM")
                    If gdataset.Tables("RITEM").Rows.Count > 0 Then
                        For TAR = 0 To gdataset.Tables("RITEM").Rows.Count - 1
                            If RCODE <> Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE")) Then
                                If Trim(gdataset.Tables("RITEM").Rows(TAR).Item("TTYPE")) = "R" Then
                                    If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")) <> 0 Then
                                        RESAMT = RESAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                        RESTAXAMT = RESTAXAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT")
                                        RESTOTALAMT = RESTOTALAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT")
                                        If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                            RESSBFAMT = RESSBFAMT + (gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0)
                                        End If
                                    End If
                                End If
                                RCODE = Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"))
                            End If
                        Next
                        If RESAMT <> 0 Then
                            sqlstring = "UPDATE PARTY_HDR SET RESTAMOUNT=" & Val(RESAMT) & ",RESTTAXAMOUNT=" & Val(RESTAXAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                            GCONNECTION.getDataSet(sqlstring, "HallStatus")
                        End If
                    End If

                    'ADDITIONAL ITEMS DETAILS FOR BAR
                    sqlstring = "SELECT TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where CATEGORY='BAR' AND bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='R' AND ISNULL(RITEMCODE,'')<>'' GROUP BY TTYPE,RITEMCODE,RITEMDESC,RQTY,RRATE,PRAMOUNT,PRTAXPERC,PRTAXAMOUNT,PRTOTALAMOUNT,ISBFCHARGE"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "RITEM")
                    If gdataset.Tables("RITEM").Rows.Count > 0 Then
                        For TAR = 0 To gdataset.Tables("RITEM").Rows.Count - 1
                            If RCODE <> Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE")) Then
                                If Trim(gdataset.Tables("RITEM").Rows(TAR).Item("TTYPE")) = "R" Then
                                    If Val(gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")) <> 0 Then
                                        BARAMT = BARAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT")
                                        BARTAXAMT = BARTAXAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTAXAMOUNT")
                                        BARTOTALAMT = BARTOTALAMT + gdataset.Tables("RITEM").Rows(TAR).Item("PRTOTALAMOUNT")
                                        If gdataset.Tables("RITEM").Rows(TAR).Item("ISBFCHARGE") = "Y" Then
                                            BARSBFAMT = BARSBFAMT + (gdataset.Tables("RITEM").Rows(TAR).Item("PRAMOUNT") * 0)
                                        End If
                                    End If
                                End If
                                RCODE = Trim(gdataset.Tables("RITEM").Rows(TAR).Item("RITEMCODE"))
                            End If
                        Next
                        If RESAMT <> 0 Then
                            RESSBFAMT = RESSBFAMT + BARSBFAMT
                            RESAMT = RESAMT + BARAMT
                            RESTAXAMT = RESTAXAMT + BARTAXAMT
                            sqlstring = "UPDATE PARTY_HDR SET RESTAMOUNT=" & Val(RESAMT) & ",RESTTAXAMOUNT=" & Val(RESTAXAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                            GCONNECTION.getDataSet(sqlstring, "HallStatus")
                        End If
                    End If

                    'TARIFF MENU DETAILS
                    Dim TRATE, DRATE, BOOKINGVALUE, DIFFVALUE, TARIFFVALUE As Double
                    sqlstring = "SELECT PRROWID,TTYPE,RITEMCODE,RITEMDESC,RQTY,TRATE,TSBFCHARGE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND TTYPE='T' GROUP BY PRROWID,TTYPE,RITEMCODE,RITEMDESC,RQTY,TRATE,TSBFCHARGE ORDER BY PRROWID"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND TTYPE='T' GROUP BY PRROWID,TTYPE,RITEMCODE,RITEMDESC,RQTY,TRATE,TSBFCHARGE ORDER BY PRROWID"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y' AND TTYPE='T' GROUP BY PRROWID,TTYPE,RITEMCODE,RITEMDESC,RQTY,TRATE,TSBFCHARGE ORDER BY PRROWID"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "TITEM")
                    If gdataset.Tables("TITEM").Rows.Count > 0 Then
                        For TAR1 = 0 To gdataset.Tables("TITEM").Rows.Count - 1
                            If TCODE <> Trim(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMCODE")) Then
                                TCODE = Trim(gdataset.Tables("TITEM").Rows(TAR1).Item("RITEMCODE"))
                                TRATE = Val(gdataset.Tables("TITEM").Rows(TAR1).Item("TRATE"))
                                TARSBFCHARGE = Trim(gdataset.Tables("TITEM").Rows(TAR1).Item("TSBFCHARGE"))
                            End If
                        Next

                        Dim TARIFFSBF As Double
                        If DIFFOCCUPANCY > 0 Then
                            BOOKINGVALUE = BOOKINGOCCUPANCY * TRATE
                            DRATE = TRATE + (TRATE * (50 / 100))
                            DIFFVALUE = DIFFOCCUPANCY * DRATE
                        Else
                            BOOKINGVALUE = BILLINGOCCUPANCY * TRATE
                            DRATE = TRATE + (TRATE * (50 / 100))
                            DIFFVALUE = 0
                        End If
                        TARIFFVALUE = BOOKINGVALUE + DIFFVALUE
                        '                        If TARSBFCHARGE = "Y" Then
                        RESSBFAMT = RESSBFAMT + (TARIFFVALUE * 0)
                        '                   End If
                        TARIFFSBF = TARIFFSBF + (TARIFFVALUE * 0)
                        TARIFFTAXAMT = TARIFFTAXAMT + (TARIFFVALUE * 0)

                        sqlstring = "UPDATE PARTY_HDR SET BOOKINGTARIFFAMOUNT=" & Val(BOOKINGVALUE) & ",EXCESSTARIFFAMOUNT=" & Val(DIFFVALUE) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        GCONNECTION.getDataSet(sqlstring, "HallStatus")
                    End If
                    Dim ARRSBFAMT As Double
                    sqlstring = "SELECT AITEMCODE,AITEMDESC,AQTY,ARATE,AAMOUNT,ATAXAMOUNT,ATOTALAMOUNT,ASBFCHARGE FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
                        sqlstring = sqlstring & " AND ISNULL(BOOKINGFLAG,'')='Y' AND ISNULL(AITEMCODE,'')<>'' GROUP BY AITEMCODE,AITEMDESC,AQTY,ARATE,AAMOUNT,ATAXAMOUNT,ATOTALAMOUNT,ASBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
                        sqlstring = sqlstring & " AND ISNULL(BILLINGFLAG,'')='Y' AND ISNULL(AITEMCODE,'')<>'' GROUP BY AITEMCODE,AITEMDESC,AQTY,ARATE,AAMOUNT,ATAXAMOUNT,ATOTALAMOUNT,ASBFCHARGE"
                    ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = sqlstring & " AND ISNULL(CANCELFLAG,'')='Y'  AND ISNULL(AITEMCODE,'')<>'' GROUP BY AITEMCODE,AITEMDESC,AQTY,ARATE,AAMOUNT,ATAXAMOUNT,ATOTALAMOUNT,ASBFCHARGE"
                    End If
                    GCONNECTION.getDataSet(sqlstring, "AITEM")
                    If gdataset.Tables("AITEM").Rows.Count > 0 Then
                        cnt1 = 1
                        For ARR = 0 To gdataset.Tables("AITEM").Rows.Count - 1
                            If ACODE <> Trim(gdataset.Tables("AITEM").Rows(ARR).Item("AITEMCODE")) Then
                                If Val(gdataset.Tables("AITEM").Rows(ARR).Item("AAMOUNT")) <> 0 Then
                                    ACODE = Trim(gdataset.Tables("AITEM").Rows(ARR).Item("AITEMCODE"))
                                    ARRAMT = ARRAMT + gdataset.Tables("AITEM").Rows(ARR).Item("AAMOUNT")
                                    ARRTAXAMT = ARRTAXAMT + gdataset.Tables("AITEM").Rows(ARR).Item("ATAXAMOUNT")
                                    ARRTOTALAMT = ARRTOTALAMT + gdataset.Tables("AITEM").Rows(ARR).Item("ATOTALAMOUNT")
                                    If gdataset.Tables("AITEM").Rows(ARR).Item("ASBFCHARGE") = "Y" Then
                                        ARRSBFAMT = ARRSBFAMT + (Val(gdataset.Tables("AITEM").Rows(ARR).Item("AAMOUNT")) * 0.02)
                                    End If
                                    cnt1 = cnt1 + 1
                                End If
                            End If
                        Next
                        RESSBFAMT = RESSBFAMT + ARRSBFAMT
                        If ARRAMT <> 0 Then
                            sqlstring = "UPDATE PARTY_HDR SET ARRMENTAMOUNT=" & Val(ARRAMT) & ",ARRMENTTAXAMOUNT=" & Val(ARRTAXAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                            GCONNECTION.getDataSet(sqlstring, "HallStatus")
                        End If
                    End If
                    If Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
                        sqlstring = "SELECT ISNULL(CANCELFLAG,'')AS CANCELFLAG FROM PARTY_VIEW_HALLBOOKINGDETAILS WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        GCONNECTION.getDataSet(sqlstring, "CANCEL")
                        If gdataset.Tables("CANCEL").Rows.Count > 0 Then

                            sqlstring = "SELECT ISNULL(HALLCANCELAMOUNT,0)AS HALLCANCELAMOUNT,ISNULL(FROMHRS,0)AS FROMHRS,ISNULL(TOHRS,0)AS TOHRS,ISNULL(CANCELDATE,'')AS CANCELDATE "
                            sqlstring = sqlstring & " FROM PARTY_HDR WHERE ISNULL(BOOKINGTYPE,'')='CANCEL' AND BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & ""
                            GCONNECTION.getDataSet(sqlstring, "CAN")
                            If gdataset.Tables("CAN").Rows.Count > 0 Then
                            End If
                        End If
                    End If

                    Dim TAXTOTAL, GROSSTOTAL, NETTOTAL, STAX, VAT As Double

                    TAXTOTAL = ARRTAXAMT + RESTAXAMT + halltaxamt + TARIFFTAXAMT
                    STAX = ARRTAXAMT + halltaxamt
                    VAT = RESTAXAMT + TARIFFTAXAMT

                    RESSBFAMT = RESSBFAMT + (TARIFFVALUE * 0.02)

                    sqlstring = "UPDATE PARTY_HDR SET SBFCHARGE=" & Val(RESSBFAMT) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    GCONNECTION.getDataSet(sqlstring, "HallStatus")

                    GROSSTOTAL = ARRAMT + RESAMT + hallamt + TARIFFVALUE
                    NETTOTAL = TAXTOTAL + GROSSTOTAL + RESSBFAMT - rcamt 'ARRTOTALAMT + RESTOTALAMT + hallnetamt + TARIFFVALUE + RESSBFAMT - rcamt

                    Dim tbillamount As Double
                    tbillamount = Val(TAXTOTAL + GROSSTOTAL + RESSBFAMT)

                    sqlstring = "UPDATE PARTY_HDR SET NETPAYABLE=" & Val(NETTOTAL) & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    GCONNECTION.getDataSet(sqlstring, "HallStatus")

                    Dim tNETTOTAL As Double
                    tNETTOTAL = NETTOTAL
                    If NETTOTAL < 0 Then
                        NETTOTAL = NETTOTAL * -1
                    End If
                Else
                    MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Function ConvertRupees(ByVal Value As Double) As String
        Dim strText, TempString, TxtArray(5) As String
        Dim locNumber, AbsValue, DecimalValue, NumArray(5), Remain, Loopindex As Double
        NumArray(0) = 7
        NumArray(1) = 5
        NumArray(2) = 3
        NumArray(3) = 2
        TxtArray(0) = " CRORE"
        TxtArray(1) = " LAKH(S)"
        TxtArray(2) = " THOUSAND"
        TxtArray(3) = " HUNDRED"
        AbsValue = Value
        For Loopindex = 0 To 3
            locNumber = (AbsValue - (AbsValue Mod (10 ^ NumArray(Loopindex)))) / (10 ^ NumArray(Loopindex))
            If locNumber > 99 Then
                strText = strText & ConvertRupees(locNumber) & TxtArray(Loopindex)
                AbsValue = AbsValue - (locNumber * (10 ^ NumArray(Loopindex)))
            Else
                If locNumber <> 0 Then
                    If locNumber > 19 Then
                        strText = strText & NumValString(((locNumber - (locNumber Mod 10)) / 10) * 10) & NumValString(locNumber Mod 10) & TxtArray(Loopindex)
                    Else
                        strText = strText & NumValString(locNumber) & TxtArray(Loopindex)
                    End If
                    AbsValue = AbsValue - (locNumber * (10 ^ NumArray(Loopindex)))
                End If
            End If
        Next Loopindex
        If AbsValue <> 0 Then
            If AbsValue > 19 Then
                strText = strText & NumValString(((AbsValue - (AbsValue Mod 10)) / 10) * 10) & NumValString(AbsValue Mod 10) & TxtArray(Loopindex)
            Else
                strText = strText & NumValString(AbsValue)
            End If
        End If
        ConvertRupees = strText
    End Function
    Private Function NumValString(ByVal Value As Double)
        Select Case Value
            Case 1
                NumValString = " ONE"
            Case 2
                NumValString = " TWO"
            Case 3
                NumValString = " THREE"
            Case 4
                NumValString = " FOUR"
            Case 5
                NumValString = " FIVE"
            Case 6
                NumValString = " SIX"
            Case 7
                NumValString = " SEVEN"
            Case 8
                NumValString = " EIGHT"
            Case 9
                NumValString = " NINE"
            Case 10
                NumValString = " TEN"
            Case 11
                NumValString = " ELEVEN"
            Case 12
                NumValString = " TWELVE"
            Case 13
                NumValString = " THIRTEEN"
            Case 14
                NumValString = " FOURTEEN"
            Case 15
                NumValString = " FIFTEEN"
            Case 16
                NumValString = " SIXTEEN"
            Case 17
                NumValString = " SEVENTEEN"
            Case 18
                NumValString = " EIGHTEEN"
            Case 19
                NumValString = " NINETEEN"
            Case 20
                NumValString = " TWENTY"
            Case 30
                NumValString = " THIRTY"
            Case 40
                NumValString = " FOURTY"
            Case 50
                NumValString = " FIFTY"
            Case 60
                NumValString = " SIXTY"
            Case 70
                NumValString = " SEVENTY"
            Case 80
                NumValString = " EIGHTY"
            Case 90
                NumValString = " NINETY"
            Case Else
                NumValString = ""
        End Select
    End Function

    Private Sub Hallfacility_Heading(ByVal PAGESIZE1 As Integer)
        If PAGESIZE1 > 60 Then
            Filewrite.WriteLine()
            Filewrite.WriteLine(Chr(27) + "E" & "SPECIAL PARTY HALL DETAILS" & Chr(27) + "F")
            Filewrite.WriteLine(StrDup(79, "-"))
            Filewrite.WriteLine("|S |Hall    |Hall Details        |PartyType | Rate   | Service Tax | Amount   |")
            Filewrite.WriteLine("|No|Code    |                    |          |        |  %  |Amount |          |")
            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 6
        End If
    End Sub
    Private Sub Arrangement_Heading(ByVal PAGESIZE1 As Integer)
        If PAGESIZE1 > 60 Then
            Filewrite.WriteLine(Chr(27) + "E" & "ARRANGEMENT FACILITY" & Chr(27) + "F")
            Filewrite.WriteLine(StrDup(79, "-"))
            Filewrite.WriteLine("|SNo|FACILITY|DETAILS             | QTY|  AMOUNT|  SBF   | Service |  Value   |")
            Filewrite.WriteLine("|   |        |                    |    |        |        |   Tax   |          |")
            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 5
        End If
    End Sub
    Private Sub Restaurant_Heading(ByVal PAGESIZE1 As Integer, ByVal II As Integer)
        If PAGESIZE1 > 60 Then
            If II = 1 Then
                Filewrite.WriteLine(Chr(27) + "E" & "ADDITIONAL CHARGABLE KITCHEN ITEM DETAILS" & Chr(27) + "F")
            ElseIf II = 2 Then
                Filewrite.WriteLine(Chr(27) + "E" & "ADDITIONAL CHARGABLE BAR-LIQUOR ITEM DETAILS" & Chr(27) + "F")
            Else
                Filewrite.WriteLine(Chr(27) + "E" & "ADDITIONAL CHARGABLE BAR-SOFT DRINKS & CIGARETTES ITEM DETAILS" & Chr(27) + "F")
            End If
            Filewrite.WriteLine(StrDup(79, "-"))
            If II = 1 Then
                Filewrite.WriteLine("|SNo|SITEMCODE|DESCRIPTION        |QTY |AMOUNT   |SBF     |VAT AMT | VALUE    |")
            ElseIf II = 2 Then
                Filewrite.WriteLine("|SNo|SITEMCODE|DESCRIPTION        |QTY |AMOUNT   |SBF     |CONT.AMT| VALUE    |")
            Else
                Filewrite.WriteLine("|SNo|SITEMCODE|DESCRIPTION        |QTY |AMOUNT   |SBF     |VAT AMT | VALUE    |")
            End If
            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 4
        End If
    End Sub
    Private Sub Reciept_Heading(ByVal PAGESIZE1 As Integer)
        If PAGESIZE1 > 60 Then
            Filewrite.WriteLine(Chr(27) + "E" & "ADVANCE PAYMENT DETAILS" & Chr(27) + "F")
            Filewrite.WriteLine(StrDup(72, "-"))
            Filewrite.WriteLine("|Sno|Receipt No          |Date        |Type               |Amount      |")
            Filewrite.WriteLine(StrDup(72, "-"))
            pagesize = pagesize + 4
        End If
    End Sub
    Private Sub BILLReciept_Heading(ByVal PAGESIZE1 As Integer)
        If PAGESIZE1 > 60 Then
            Filewrite.WriteLine(Chr(27) + "E" & "BILL PAYMENT DETAILS" & Chr(27) + "F")
            Filewrite.WriteLine(StrDup(72, "-"))
            Filewrite.WriteLine("|Sno|Receipt No          |Date        |Type               |Amount      |")
            Filewrite.WriteLine(StrDup(72, "-"))
            pagesize = pagesize + 4
        End If
    End Sub

    Private Sub Tariff_Heading(ByVal PAGESIZE1 As Integer)
        If PAGESIZE1 > 60 Then
            Filewrite.WriteLine(Chr(27) + "E" & "TARIFF MENU DETAILS" & Chr(27) + "F")
            Filewrite.WriteLine(StrDup(79, "-"))
            Filewrite.WriteLine("|SNo|MenuCode| Menu Description        |SNo|MenuCode| Menu Description        |")
            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 4
        End If
    End Sub
    Private Sub DTPBOOKINGDATE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPBOOKINGDATE.Validated
        SSQL = "SELECT ISNULL(BOOKINGFLAG,'') AS BOOKINGFLAG,ISNULL(BILLINGFLAG,'') AS BILLINGFLAG,"
        SSQL = SSQL & "ISNULL(CANCELFLAG,'') AS CANCELFLAG FROM  PARTY_HALLBOOKING_HDR "
        SSQL = SSQL & "WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and ISNULL(BOOKINGNO, 0) = " & IIf(TXTBOOKINGNO.Text = "", 0, TXTBOOKINGNO.Text)
        DT = GCONNECTION.GetValues(SSQL)
        If DT.Rows(0).Item("CANCELFLAG") <> "Y" Then
            If CMBBOOKINGTYPE.Text = "CANCEL" Then
                TXTBOOKINGNO_Validated(TXTBOOKINGNO, e)
            End If
        End If
        DTPPARTYDATE.Focus()
    End Sub
    Private Sub TXTARRCANCELAMT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTARRCANCELAMT.LostFocus
        TXTARRCANCELAMT.Text = Format(Val(TXTARRCANCELAMT.Text), "0.00")
    End Sub
    Private Sub TXTARRTOTALAMOUNT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTARRTOTALAMOUNT.LostFocus
        TXTARRTOTALAMOUNT.Text = Format(Val(TXTARRTOTALAMOUNT.Text), "0.00")
    End Sub
    Private Sub TXTARRAMOUNT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTARRAMOUNT.LostFocus
        TXTARRAMOUNT.Text = Format(Val(TXTARRAMOUNT.Text), "0.00")
    End Sub
    Private Sub TXTRESCANCELAMT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTRESCANCELAMT.LostFocus
        TXTRESCANCELAMT.Text = Format(Val(TXTRESCANCELAMT.Text), "0.00")
    End Sub
    Private Sub TXTRESTOTALAMOUNT_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTRESTOTALAMOUNT.LocationChanged
        TXTRESTOTALAMOUNT.Text = Format(Val(TXTRESTOTALAMOUNT.Text), "0.00")
    End Sub
    Private Sub DTPRECEIPTDATE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PartyBilling_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F1 Then
            RDBHALLFACILITY.Checked = True
        End If
        If e.KeyCode = Keys.F2 Then
            RDBARRITEM.Checked = True
        End If
        If e.KeyCode = Keys.F5 Then
            RDBRESMENU.Checked = True
        End If
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
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
        If e.KeyCode = Keys.F4 Then
            Call Button2_Click(sender, e)
            Exit Sub
        End If

        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmd_exit_Click(cmd_exit, e)
            Exit Sub
        End If
    End Sub
    Private Sub CMBBOOKINGTYPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBBOOKINGTYPE.SelectedIndexChanged
        If CMBBOOKINGTYPE.Text = "BILLING" Then
            labbooking.Text = "BOOKING NO"
            'LABELDATE.Text = "BILLING DATE:"
            ''ElseIf CMBBOOKINGTYPE.Text = "BILLING" Then
            ''    labbooking.Text = "BOOKING NO"
            ''    LABELDATE.Text = "BILLING DATE:"
            ''    AUTO_MANUALNO()
            ''Else
            'labbooking.Text = "RESERVATION NO"
            'LABELDATE.Text = "CANCEL DATE:"
        End If
    End Sub
    Private Sub rdo_halldisplay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdo_halldisplay.CheckedChanged
        If rdo_halldisplay.Checked = True Then
            GBHALLBOOKING.Visible = True
            GRP_TARIFF.Visible = False
            GBARRANGEDETAILS.Visible = False
            GBHALLFACILITY.Visible = False
            GBMENUDETAILS.Visible = False
            TXT_DISAMT.Visible = True
            TXT_TOTAMT.Visible = True
            TXTB_BAMOUNT.Visible = True
        Else
            GBHALLBOOKING.Visible = False
            GBARRANGEDETAILS.Visible = False
            GBHALLFACILITY.Visible = False
            GBMENUDETAILS.Visible = False
        End If
    End Sub
    Private Sub CMD_TARIFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_TARIFF.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT DISTINCT TARIFFDESC,TARIFFCODE,RATE FROM PARTY_TARIFFHDR"
        gSQLString = gSQLString & " "
        If Trim(Search) = " " Then
            M_WhereCondition = " WHERE CATEGORY='VEG'"
        Else
            M_WhereCondition = " WHERE CATEGORY='VEG'"
        End If
        vform.Field = "TARIFFDESC,TARIFFCODE,RATE"
        ' vform.vFormatstring = "         TARIFF DESCRIPTION        |TARIFF CODE|  RATE  "
        vform.vCaption = "TARIFF MASTER HELP"
        ' vform.KeyPos = 0
        ' vform.KeyPos1 = 1
        ' vform.KeyPos2 = 2
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXT_TARIFF.Text = Trim(vform.keyfield1 & "")
            TXT_TARIFFDESC.Text = Trim(vform.keyfield & "")
            'Txt_Maxitems.Text = Val(vform.keyfield3)
            Call TXT_TARIFF_Validated(TXT_TARIFF, e)
            'SSGRID_TARIFF.SetActiveCell(1, 1)
            'SSGRID_TARIFF.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub FILLTARIFF()
        Dim vform As New ListOperattion1
        gSQLString = "SELECT DISTINCT TARIFFDESC,TARIFFCODE,RATE FROM PARTY_TARIFFHDR"
        gSQLString = gSQLString & " "
        If Trim(Search) = " " Then
            M_WhereCondition = "where category='veg' AND  freeze<>'Y' "
        Else
            M_WhereCondition = "where category='veg'  AND freeze<>'Y' "
        End If
        vform.Field = "TARIFFDESC,TARIFFCODE,RATE"
        vform.vFormatstring = "         TARIFF DESCRIPTION        |TARIFF CODE|  RATE  "
        vform.vCaption = "TARIFF MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            SSGRID_TARIFF.Row = SSGRID_TARIFF.ActiveRow
            SSGRID_TARIFF.Col = 1
            SSGRID_TARIFF.Text = Trim(vform.keyfield1 & "")
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub FILLTARIFFnv()
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT DISTINCT TARIFFDESC,TARIFFCODE,RATE FROM PARTY_TARIFFHDR "
        gSQLString = gSQLString & " "
        If Trim(Search) = " " Then
            M_WhereCondition = "where category='NON veg'  and freeze<>'Y'"
        Else
            M_WhereCondition = " where category='NON veg' and freeze<>'Y'"
        End If
        vform.Field = "TARIFFDESC,TARIFFCODE,RATE"
        'vform.vFormatstring = "         TARIFF DESCRIPTION        |TARIFF CODE|  RATE  "
        vform.vCaption = "TARIFF MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            SSGRID_NV.Row = SSGRID_NV.ActiveRow
            SSGRID_NV.Col = 1
            SSGRID_NV.Text = Trim(vform.keyfield1 & "")
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub TXT_TARIFF_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_TARIFF.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXT_TARIFF.Text) = "" Then
                Call CMD_TARIFF_Click(sender, e)
            Else
                Call TXT_TARIFF_Validated(TXT_TARIFF, e)
            End If
        End If
    End Sub

    Private Sub TXT_TARIFF_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_TARIFF.Validated
        Dim SQLSTRING As String
        'VIJAY RSI CLUB WITHOUT MENUTARIFF WE WANT
        'If Val(TxtOCCUPANCY.Text) <= 0 Then
        '    MsgBox("Please enter the Occupancy....", MsgBoxStyle.OKOnly, "VALIDATE")
        '    TxtOCCUPANCY.Focus()
        '    Exit Sub
        'End If
        If Trim(TXT_TARIFF.Text) <> "" Then
            SQLSTRING = "SELECT TARIFFDESC,TARIFFCODE,SUM(MAXITEMS) AS MAXITEMS FROM PARTY_TARIFFDET WHERE TARIFFCODE='" & Trim(TXT_TARIFF.Text) & "' AND freeze<>'Y'"
            SQLSTRING = SQLSTRING & " GROUP BY TARIFFDESC,TARIFFCODE"
            GCONNECTION.getDataSet(SQLSTRING, "TARIFF")
            If gdataset.Tables("TARIFF").Rows.Count > 0 Then
                TXT_TARIFF.Text = gdataset.Tables("TARIFF").Rows(0).Item("TARIFFCODE")
                TXT_TARIFFDESC.Text = gdataset.Tables("TARIFF").Rows(0).Item("TARIFFDESC")
                Txt_Maxitems.Text = gdataset.Tables("TARIFF").Rows(0).Item("MAXITEMS")

                'Lbl_Menu.Text = gdataset.Tables("TARIFF").Rows(0).Item("MENUCODE")
                SSGRID_TARIFF.MaxRows = Val(Txt_Maxitems.Text)
                SSGRID_TARIFF.SetActiveCell(1, 1)
                SSGRID_TARIFF.Focus()
                SSGRID_TARIFF.SetText(1, 1, TXT_TARIFF.Text)
                SSGRID_TARIFF.SetActiveCell(2, 1)
            Else
                TXT_TARIFF.Text = ""
                TXT_TARIFF.Focus()
            End If
        End If
    End Sub


    Private Sub FILLTARIFFITEM()
        Dim group1, item As String
        Dim max As Integer
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT ISNULL(a.ITEMCODE,'')AS ITEMCODE,ISNULL(a.ITEMDESC,'')AS ITEMDESC,ISNULL(a.UOM,'')AS UOM,ISNULL(A.GROUPCODE,'') AS GROUPCODE,a.MENUCODE,a.TARIFFCODE,ISNULL(a.MAXITEMS,0) AS MAXITEMS "
        gSQLString = gSQLString & " FROM VIEW_PARTY_MENUITEMHELP a,groupmaster b  "
        If Trim(Search) = " " Then
            M_WhereCondition = " WHERE a.groupcode=b.groupcode and a.TARIFFCODE='" & Trim(TXT_TARIFF.Text) & "' AND freeze<>'Y' AND a.TYPE='VEG'"
        Else
            M_WhereCondition = " WHERE a.groupcode=b.groupcode and a.TARIFFCODE='" & Trim(TXT_TARIFF.Text) & "' AND freeze<>'Y' AND a.TYPE='VEG'"
        End If
        'vform.vSamleCol = "s"
        vform.Field = "ITEMCODE,ITEMDESC,UOM,A.GROUPCODE,MENUCODE,TARIFFCODE,MAXITEMS"
        ' vform.vFormatstring = "         ITEM DESCRIPTION        |   ITEM CODE    |           UOM           |    GROUP CODE | MENU CODE | TARIFF CODE | MAX ITEMS "
        vform.vCaption = "ITEM MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        'vform.Keypos3 = 3
        'vform.keypos4 = 4
        'vform.Keypos5 = 5
        'vform.Keypos6 = 6
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With SSGRID_TARIFF
                .Col = 1
                .Row = .ActiveRow
                .Text = TXT_TARIFF.Text
                .Col = 2
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield & "")
                item = (.Text)
                .Col = 3
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield1 & "")

                .Col = 4
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield2 & "")


                .Col = 6
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield3 & "")

                .Col = 7
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield4 & "")
                group1 = .Text
                .Col = 8
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield5 & "")

                .Col = 9
                .Row = .ActiveRow
                .Text = Val(vform.keyfield6)
                max = Val(.Text)

                .SetActiveCell(5, .ActiveRow)

                .Focus()
                Call CHECKDUPLICATE(group1, max, item)
            End With
        End If
        vform.Close()
        vform = Nothing
    End Sub


    Private Sub FILLTARIFFITEMnv()
        Dim group1, item As String
        Dim max As Integer
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT  ISNULL(a.ITEMCODE,'')AS ITEMCODE,ISNULL(a.ITEMDESC,'')AS ITEMDESC,ISNULL(a.UOM,'')AS UOM,a.GROUPCODE,a.MENUCODE,a.TARIFFCODE,a.MAXITEMS "
        gSQLString = gSQLString & " FROM VIEW_PARTY_MENUITEMHELP a,groupMaster b  "
        If Trim(Search) = " " Then
            M_WhereCondition = " WHERE a.groupcode=b.groupcode and a.TARIFFCODE='" & Trim(TextNVTBOX.Text) & "' AND freeze<>'Y'"
        Else
            M_WhereCondition = " WHERE a.groupcode=b.groupcode and a.TARIFFCODE='" & Trim(TextNVTBOX.Text) & "' AND freeze<>'Y'"
        End If
        '  vform.vSamleCol = "s"
        vform.Field = "ITEMCODE,ITEMDESC,UOM,A.GROUPCODE,MENUCODE,TARIFFCODE,MAXITEMS"
        'vform.vFormatstring = "         ITEM DESCRIPTION        |   ITEM CODE    |           UOM           |    GROUP CODE | MENU CODE | TARIFF CODE | MAX ITEMS "
        vform.vCaption = "ITEM MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        'vform.Keypos3 = 3
        'vform.keypos4 = 4
        'vform.Keypos5 = 5
        'vform.Keypos6 = 6
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With SSGRID_NV
                .Col = 2
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield & "")
                item = (.Text)

                .Col = 3
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield1 & "")

                .Col = 4
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield2 & "")


                .Col = 6
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield3 & "")
                .Col = 7
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield4 & "")
                group1 = .Text

                .Col = 8
                .Row = .ActiveRow
                .Text = Trim(vform.keyfield5 & "")

                .Col = 9
                .Row = .ActiveRow
                .Text = Val(vform.keyfield6)
                max = Val(.Text)
                .SetActiveCell(5, .ActiveRow)

                .Focus()
                Call CHECKDUPLICATE1(group1, max, item)
            End With
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub CHECKDUPLICATE1(ByVal GROUP As String, ByVal MAXITEMS As Integer, ByVal ITEMCODE As String)
        Dim COUNT, COUNT1 As Integer
        With SSGRID_NV
            If SSGRID_NV.DataRowCnt > 1 Then
                For I = 1 To SSGRID_NV.DataRowCnt - 1
                    .Col = 2
                    .Row = I
                    If ITEMCODE = (.Text) Then
                        COUNT1 = COUNT1 + 1

                    End If
                    .Col = 7
                    .Row = I
                    If GROUP = (.Text) Then
                        COUNT = COUNT + 1
                    End If
                Next
            End If
        End With

        If MAXITEMS <= COUNT Then
            MessageBox.Show("Max Nos Exceeded", gCompanyname)
            boolchk1 = False
            Exit Sub

        End If
        If COUNT1 >= 1 Then
            MessageBox.Show("Duplicate Item's not Allowed", gCompanyname)
            boolchk1 = False
            Exit Sub

        End If
        boolchk1 = True
    End Sub

    Private Sub SSGRID_TARIFF_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID_TARIFF.KeyDownEvent
        Dim ITEMCODE As String
        Dim SQLSTRING, GROUP As String
        Dim QTY, RATE, AMT As Double
        Dim COUNT, MAXITEMS As Integer

        With SSGRID_TARIFF
            I = .ActiveRow
            If e.keyCode = Keys.Enter Then
                If .ActiveCol = 1 Then
                    '.Col = 1
                    '.Row = I
                    'ITEMCODE = Trim(.Text)
                    'If Trim(ITEMCODE) = "" Then

                    '    'Call FILLTARIFFITEM()
                    '    Call FILLTARIFF()
                    'ElseIf Trim(ITEMCODE) <> "" Then
                    '    SQLSTRING = "SELECT DISTINCT TARIFFDESC,TARIFFCODE,RATE FROM PARTY_TARIFFHDR WHERE TARIFFCODE ='" & Trim(ITEMCODE) & "' AND freeze<>'Y' "
                    '    GCONNECTION.getDataSet(SQLSTRING, "TITEM")
                    '    If gdataset.Tables("TITEM").Rows.Count > 0 Then
                    '        .Col = 1
                    '        .Row = I
                    '        .Text = gdataset.Tables("TITEM").Rows(0).Item("TARIFFCODE")
                    '        .SetActiveCell(2, I)
                    '        .Focus()
                    '    Else
                    '        MsgBox("INVALID TARIFF CODE..", MsgBoxStyle.Information)
                    '        .Col = 1
                    '        .Row = I
                    '        .Text = ""
                    '        .SetActiveCell(1, I)
                    '        .Focus()
                    '    End If
                    'End If
                ElseIf .ActiveCol = 2 Then
                    .Col = 2
                    .Row = I
                    ITEMCODE = Trim(.Text)
                    If Trim(ITEMCODE) = "" Then
                        Call FILLTARIFFITEM()
                    ElseIf Trim(ITEMCODE) <> "" Then
                        'SQLSTRING = "SELECT  distinct itemcode,itemdesc VIEW_PARTY_MENUITEMHELP WHERE TARIFFCODE ='" & Trim(TXT_TARIFF.Text) & "' "


                        SQLSTRING = "SELECT  distinct ITEMCODE,ITEMDESC,UOM,GROUPCODE,MENUCODE,TARIFFCODE,MAXITEMS FROM VIEW_PARTY_MENUITEMHELP WHERE TARIFFCODE ='" & Trim(TXT_TARIFF.Text) & "' AND TYPE='VEG'"
                        SQLSTRING = SQLSTRING & " AND ITEMCODE='" & Trim(ITEMCODE) & "'"
                        GCONNECTION.getDataSet(SQLSTRING, "TITEM")
                        If gdataset.Tables("TITEM").Rows.Count > 0 Then
                            .Col = 1
                            .Row = I
                            .Text = TXT_TARIFF.Text
                            .Col = 2
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("ITEMCODE")
                            ITEMCODE = .Text
                            .Col = 3
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("ITEMDESC")
                            .Col = 4
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("UOM")
                            .Col = 6
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("GROUPCODE")

                            .Col = 7
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("MENUCODE")
                            GROUP = .Text
                            .Col = 8
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("TARIFFCODE")
                            .Col = 9
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("MAXITEMS")
                            MAXITEMS = Val(.Text)
                            .SetActiveCell(4, I)
                            .Focus()
                        Else
                            MsgBox("INVALID ITEMCODE..", MsgBoxStyle.Information)
                            .Col = 2
                            .Row = I
                            .Text = ""
                            .SetActiveCell(2, I)
                            .Focus()
                        End If
                        Call CHECKDUPLICATE(GROUP, MAXITEMS, ITEMCODE)
                    End If

                    If boolchk1 = False Then
                        .DeleteRows(I, 1)
                        .SetActiveCell(1, I)
                        .Focus()
                    End If

                ElseIf .ActiveCol = 3 Then
                    .SetActiveCell(4, I)
                    .Focus()
                ElseIf .ActiveCol = 4 Then

                    .SetActiveCell(5, I)
                    .Focus()
                ElseIf .ActiveCol = 5 Then
                    Dim tariff As String
                    .Col = 1
                    .Row = I
                    tariff = Trim(.Text)
                    .Col = 5
                    .Row = I
                    If Val(.Text) <> 0 Then
                        .SetActiveCell(2, I + 1)
                        .Focus()
                        .Col = 1
                        .Row = I
                        .SetText(1, I + 1, tariff)
                    Else
                        .SetActiveCell(5, I)
                        .Focus()
                    End If
                End If
            End If
            If e.keyCode = Keys.F3 Then
                .DeleteRows(I, 2)
                .SetActiveCell(2, I)
                .Focus()
            End If
        End With
    End Sub
    Private Sub CHECKDUPLICATE(ByVal GROUP As String, ByVal MAXITEMS As Integer, ByVal ITEMCODE As String)
        Dim COUNT, COUNT1 As Integer
        With SSGRID_TARIFF
            If SSGRID_TARIFF.DataRowCnt > 1 Then
                For I = 1 To SSGRID_TARIFF.DataRowCnt - 1
                    .Col = 2
                    .Row = I
                    If ITEMCODE = (.Text) Then
                        COUNT1 = COUNT1 + 1

                    End If
                    .Col = 7
                    .Row = I
                    If GROUP = (.Text) Then
                        COUNT = COUNT + 1
                    End If
                Next
            End If
        End With

        If MAXITEMS <= COUNT Then
            MessageBox.Show("Max Nos Exceeded", gCompanyname)
            boolchk1 = False
            Exit Sub

        End If
        If COUNT1 >= 1 Then
            MessageBox.Show("Duplicate Item's not Allowed", gCompanyname)
            boolchk1 = False
            Exit Sub

        End If
        boolchk1 = True
    End Sub
    Private Sub TXTBOOKINGNO_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBOOKINGNO.TextChanged
    End Sub
    Private Sub Cmd_BookingNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub CMB_LOCATION_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMB_LOCATION.KeyPress
        If Asc(e.KeyChar) = 13 Then
            CMBBOOKINGTYPE.Focus()
        End If
    End Sub
    Private Sub CMB_LOCATION_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMB_LOCATION.LostFocus
        Dim SQLSTRING As String
        SQLSTRING = "SELECT DISTINCT LOCCODE FROM PARTY_LOCATIONMASTER WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
        GCONNECTION.getDataSet(SQLSTRING, "PARTY_LOCATIONMASTER")
        If gdataset.Tables("PARTY_LOCATIONMASTER").Rows.Count <= 0 Then
            CMB_LOCATION.Focus()
            CMB_LOCATION.BackColor = Color.Red
        Else
            CMB_LOCATION.BackColor = Color.White

        End If
    End Sub
    Private Sub datevalidation()
        Try
            SQLSTRING = "SELECT SERVERDATE,SERVERTIME FROM VIEW_SERVER_DATETIME "
            GCONNECTION.getDataSet(SQLSTRING, "SERVERDATE")
            If gdataset.Tables("SERVERDATE").Rows.Count > 0 Then
                If CDate(Format(DTPPARTYDATE.Value, "yyyy/MMM/dd")) < CDate(Format(gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE"), "dd/MMM/yyyy")) Then
                    MsgBox("To Date should be Lessthan or equal to Server System Date.......", MsgBoxStyle.OKOnly, "Date Validation")
                    'DTPPARTYDATE.Value = gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE")
                End If

                If CDate(Format(gFinancialyearEnding, "yyyy/MMM/dd")) < CDate(Format(DTPPARTYDATE.Value, "yyyy/MMM/dd")) Then
                    '                    MsgBox("To Date Should be within Financial Year Date.......", MsgBoxStyle.OKOnly, "Date Validation")
                    DTPPARTYDATE.Value = gFinancialyearEnding
                    '                   Exit Sub
                End If

                If CDate(Format(DTPPARTYDATE.Value, "yyyy/MMM/dd")) > CDate(Format(gFinancialyearEnding, "yyyy/MMM/dd")) Then
                    MsgBox("To Date Should be within Financial Year Date.......", MsgBoxStyle.OKOnly, "Date Validation")
                    DTPPARTYDATE.Value = gFinancialyearEnding
                    '                 Exit Sub
                End If

                If CDate(Format(DTPPARTYDATE.Value, "yyyy/MMM/dd")) < CDate(Format(gFinancialyearStart, "yyyy/MMM/dd")) Then
                    MsgBox("From Date Should be within Financial Year Date.......", MsgBoxStyle.OKOnly, "Date Validation")
                    DTPPARTYDATE.Value = gFinancialyearStart
                    '                Exit Sub
                End If

                If CDate(Format(DTPBOOKINGDATE.Value, "yyyy/MMM/dd")) > CDate(Format(DTPPARTYDATE.Value, "yyyy/MMM/dd")) Then
                    MsgBox("From Date Should be Less Than or Equal to Date.......", MsgBoxStyle.OKOnly, "Date Validation")
                    DTPBOOKINGDATE.Value = DTPPARTYDATE.Value
                    '               Exit Sub
                End If
            End If
        Catch
            MsgBox("Error in date view..." & Err.Description)
        End Try
    End Sub
    Private Sub DTPPARTYDATE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPPARTYDATE.LostFocus
        Call datevalidation()
    End Sub
    Private Sub AUTO_MANUALNO()
        Try
            Dim Sqlstring As String
            If Mid(Cmd_Add1.Text, 1, 1) = "A" And CMBBOOKINGTYPE.Text = "BOOKING" Then
                Sqlstring = " SELECT ISNULL(MAX(ISNULL(INVOICENO,0)),0)+1 AS INVOICENO FROM PARTY_HDR WHERE BOOKINGTYPE='BOOKING' AND LOCCODE='" & CMB_LOCATION.Text & "'"
                GCONNECTION.getDataSet(Sqlstring, "MAXNO")
                If gdataset.Tables("MAXNO").Rows.Count > 0 Then
                    TXTBILLINGNO.Text = gdataset.Tables("MAXNO").Rows(0).Item("INVOICENO")
                    Cmd_Add1.Text = "Add [F7]"
                    TXTBOOKINGNO.Focus()
                End If
            End If
            If CMBBOOKINGTYPE.Text <> "BILLING" Then
                TXTBILLINGNO.Text = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, MyCompanyName, MessageBoxButtons.OK)
        End Try
    End Sub

    Private Sub CMB_LOCATION_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMB_LOCATION.SelectedIndexChanged
        AUTO_MANUALNO()
    End Sub

    Private Sub CMB_LOCATION_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMB_LOCATION.LocationChanged

    End Sub
    Private Sub CMD_BILLINGNO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_BILLINGNO.Click
        If CMBBOOKINGTYPE.Text = "BILLING" Then
            Dim vform As New ListOperattion1
            gSQLString = "SELECT ISNULL(BILLNO,0) AS BILLNO,ISNULL(BOOKINGNO,0) AS BOOKINGNO,ISNULL(partyDATE,'')AS PARTYDATE,BOOKINGDATE AS BOOKINGDATE"
            gSQLString = gSQLString & "  FROM  PARTY_HDR"
            If Trim(Search) = " " Then
                M_WhereCondition = " WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND  BOOKINGTYPE='BILLING'"
            Else
                M_WhereCondition = " WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND  BOOKINGTYPE='BILLING'"
            End If
            vform.Field = "BILLNO,BOOKINGNO,PARTYDATE,BOOKINGDATE"
            vform.vFormatstring = "BILLNO NO             | BOOKINGNO |   PARTYDATE            |  BOOKING DATE             "
            vform.vCaption = "PARTY BILL HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                'MsgBox(Trim(vform.keyfield & ""))
                'MsgBox(Trim(vform.keyfield1 & ""))
                'MsgBox(Trim(vform.keyfield2 & ""))
                'MsgBox(Trim(vform.keyfield3 & ""))

                TXTBOOKINGNO.Text = Trim(vform.keyfield1 & "")
                DTPBOOKINGDATE.Text = Trim(vform.keyfield3 & "")
                Call TXTBOOKINGNO_Validated(sender, e)
                DTPBOOKINGDATE.Focus()
            End If
            vform.Close()
            vform = Nothing
        Else
            MsgBox("Please Select Booking Type=BILLING...")
            CMBBOOKINGTYPE.Focus()
        End If
    End Sub

    Private Sub DTPPARTYDATE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPPARTYDATE.ValueChanged
        LBL_PARTYDAY.Text = Format(DTPPARTYDATE.Value, "ddddd")
    End Sub

    Private Sub DTPBOOKINGDATE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPBOOKINGDATE.ValueChanged
        lbl_bookday.Text = Format(DTPBOOKINGDATE.Value, "ddddd")
    End Sub

   

    Private Sub PARTYBillingformASCA()

        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL, SSQL1, SSQL2, SSQL3, SSQ As String
        Dim Viewer As New ReportViwer

        Dim r As New MENUORDERASCA

        Dim POSdesc(), MemberCode() As String
        Dim sqlstring1 As String
        Dim SQLSTRING2 As String


        SSQ = "update party_restaurant set itemdesc=a.ITEMDESC ,GROUPCODE=a.GROUPCODE  from party_itemmaster a where a.ITEMCODE=party_restaurant.ITEMCODE AND party_restaurant.BOOKINGNO = '" & Me.TXTBOOKINGNO.Text & "'"
        GCONNECTION.getDataSet(SSQ, "party_restaurant")

        If Trim(TXTBOOKINGNO.Text) <> "" And Trim(TXTBOOKINGNO.Text) <> "" Then
            SSQL = "SELECT DISTINCT * FROM foodorder1 WHERE BOOKINGNO = '" & Me.TXTBOOKINGNO.Text & "' "
            GCONNECTION.getDataSet(SSQL, "MAXNO")

            SSQL3 = "SELECT DISTINCT * FROM party_menu_book WHERE BOOKINGNO = '" & Me.TXTBOOKINGNO.Text & "'"
            GCONNECTION.getDataSet(SSQL3, "MAXNO")
        End If
        Viewer.Report = r

        Call Viewer.GetDetails1(SSQL, "foodorder1", r)
        Call Viewer.GetDetails1(SSQL3, "party_menu_book", r)
        'Call Viewer.GetDetails(SSQL2, "PARTY_MENU", r)
        'Call Viewer.GetDetails(SSQL3, "PARTY_ARRANGE", r)

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text13")
        TXTOBJ5.Text = MyCompanyName
        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = r.ReportDefinition.ReportObjects("Text15")
        TXTOBJ6.Text = Address1 & Address2

        Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ8 = r.ReportDefinition.ReportObjects("Text16")
        TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
        TXTOBJ9.Text = "PhoneNo : " & gphoneno

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text2")
        TXTOBJ1.Text = "UserName : " & gUsername
        Viewer.Show()
    End Sub
    Private Sub PARTYBillingformKGA()

        Dim servercode() As String
        Dim i As Integer
        Dim BOOLCHK As Boolean
        BOOLCHK = False
        Dim sqlstring, SSQL, SSQL1, SSQL2, SSQL3, SSQ, SQL1, SSQL4, SSQL5, SSQL6, BillNo, TDATE, MemgstNo As String
        Dim PTodate, Pdate As Date
        Dim Viewer As New ReportViwer

        Dim POSdesc(), MemberCode() As String
        Dim sqlstring1 As String
        Dim SQLSTRING2 As String

        If Mid(gCompName, 1, 5) = "TRADE" Then
        Else
            'SQL1 = "SELECT * FROM RPT_PARTY_POSDETAILS Where BOOKINGNO=" & TXTBOOKINGNO.Text & " " ' "AND BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "'"
            'GCONNECTION.getDataSet(SQL1, "RPT")
            'If gdataset.Tables("RPT").Rows.Count > 0 Then
            '    'BOOLCHK = True
            'Else
            '    'MessageBox.Show("NO RECORDS TO DISPLAY", MyCompanyName, MessageBoxButtons.OK)
            '    'Exit Sub
            'End If
        End If
        SQL1 = "SELECT * FROM party_hdr WHERE BOOKINGNO = " & TXTBOOKINGNO.Text & " AND ISNULL(BOOKINGTYPE,'') = 'BILLING'"
        GCONNECTION.getDataSet(SQL1, "RPT1")
        If gdataset.Tables("RPT1").Rows.Count = 0 Then
            MessageBox.Show("Bill Not Done Plz Check", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        End If

        If Mid(gCompName, 1, 5) = "TRADE" Then
            Dim R As New CRPT_PAR_BILLING_TRADE
            If Trim(TXTBOOKINGNO.Text) <> "" Then

                sqlstring = "SELECT * FROM RPT_PARTY_RECEIPT Where BOOKNO='" & TXTBOOKINGNO.Text & "'"
                GCONNECTION.getDataSet(sqlstring, "RPT_PARTY_RECEIPT")

                SQL1 = "SELECT * FROM RPT_PARTY_POSDETAILS Where BOOKINGNO=" & TXTBOOKINGNO.Text & ""
                GCONNECTION.getDataSet(SQL1, "RPT_PARTY_POSDETAILS")

                SSQL5 = "SELECT * FROM RPT_PARTY_HALLDET Where BOOKINGNO=" & TXTBOOKINGNO.Text & ""
                GCONNECTION.getDataSet(SSQL5, "RPT_PARTY_HALLDET")

                SSQL6 = "SELECT bookingno AS MCODE,TAXDESC AS ASSOCIATENAME ,HALLTAXPERC AS TAX, SUM(TAXAMOUNT) AS AMOUNT FROM TAX_DETAILS_BOOKING Where bookingno=" & TXTBOOKINGNO.Text & " GROUP BY bookingno,TAXDESC ,HALLTAXPERC "
                GCONNECTION.getDataSet(SSQL6, "PARTY_PENDINGBILL")

                MemgstNo = GCONNECTION.getvalue("SELECT Isnull(MEMGSTNO,'') as MEMGSTNO FROM party_hallbooking_hdr Where BOOKINGNO=" & TXTBOOKINGNO.Text & "")
                If MemgstNo = Nothing Then
                    MemgstNo = ""
                End If
            End If
            Viewer.Report = R


            Call Viewer.GetDetails1(sqlstring, "RPT_PARTY_RECEIPT", R)
            Call Viewer.GetDetails1(SQL1, "RPT_PARTY_POSDETAILS", R)
            Call Viewer.GetDetails1(SSQL5, "RPT_PARTY_HALLDET", R)
            Call Viewer.GetDetails1(SSQL6, "PARTY_PENDINGBILL", R)


            ''Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject

            ''TXTOBJ5 = R.ReportDefinition.ReportObjects("Text10")
            ''TXTOBJ5.Text = MyCompanyName
            ''Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            ''TXTOBJ6 = R.ReportDefinition.ReportObjects("Text11")
            ''TXTOBJ6.Text = Address1 & Address2

            ''Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            ''TXTOBJ8 = R.ReportDefinition.ReportObjects("Text12")
            ''TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            ''Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            ''TXTOBJ9 = R.ReportDefinition.ReportObjects("Text22")
            ''TXTOBJ9.Text = gphoneno

            sqlstring = "SELECT ISNULL(BILLNO,'') FROM PARTY_hDR WHERE BOOKINGNO = '" & TXTBOOKINGNO.Text & "' AND BOOKINGTYPE = 'BILLING'"
            GCONNECTION.getDataSet(sqlstring, "Bno")
            'GCONNECTION.getDataSet(sqlstring, "PARTY_PENDINGBILL")
            If gdataset.Tables("Bno").Rows.Count > 0 Then
                BillNo = gdataset.Tables("Bno").Rows(0).Item(0)
            End If

            sqlstring = "SELECT CAST(CONVERT(VARCHAR,PartyTodate,106) AS DATETIME) AS TODATE,CAST(CONVERT(VARCHAR,Partydate,106) AS DATETIME) AS PARTYDATE FROM party_hallbooking_det WHERE BOOKINGNO = '" & TXTBOOKINGNO.Text & "'"
            GCONNECTION.getDataSet(sqlstring, "Bno")
            'GCONNECTION.getDataSet(sqlstring, "PARTY_PENDINGBILL")
            If gdataset.Tables("Bno").Rows.Count > 0 Then
                PTodate = Format(gdataset.Tables("Bno").Rows(0).Item("TODATE"), "dd.MM.yyyy")
                Pdate = Format(gdataset.Tables("Bno").Rows(0).Item("PARTYDATE"), "dd.MM.yyyy")
                If PTodate = Pdate Then
                    PTodate = "01-JAN-1900"
                End If
            End If
            If PTodate = "01-JAN-1900" Then
                TDATE = ""
            Else
                TDATE = Format(PTodate, "dd.MM.yyyy")
            End If

            Dim TXTOBJ2 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ2 = R.ReportDefinition.ReportObjects("Text31")
            TXTOBJ2.Text = BillNo

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = R.ReportDefinition.ReportObjects("Text23")
            TXTOBJ1.Text = "UserName : " & gUsername

            Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ3 = R.ReportDefinition.ReportObjects("Text24")
            TXTOBJ3.Text = TDATE

            Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ4 = R.ReportDefinition.ReportObjects("Text2")
            If TDATE = "" Then
                TXTOBJ4.Text = ""
            Else
                TXTOBJ4.Text = "To"
            End If

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = R.ReportDefinition.ReportObjects("Text29")
            TXTOBJ5.Text = "Mem GSTIN No: " & MemgstNo

            Viewer.Show()
        Else
            Dim R As New CRPT_PAR_BILLING_CIAL
            If Trim(TXTBOOKINGNO.Text) <> "" Then

                sqlstring = "SELECT * FROM RPT_PARTY_RECEIPT Where BOOKNO='" & TXTBOOKINGNO.Text & "'"
                GCONNECTION.getDataSet(sqlstring, "RPT_PARTY_RECEIPT")

                SQL1 = "SELECT * FROM RPT_PARTY_POSDETAILS Where BOOKINGNO=" & TXTBOOKINGNO.Text & ""
                GCONNECTION.getDataSet(SQL1, "RPT_PARTY_POSDETAILS")

                SSQL5 = "SELECT * FROM RPT_PARTY_HALLDET Where BOOKINGNO=" & TXTBOOKINGNO.Text & ""
                GCONNECTION.getDataSet(SSQL5, "RPT_PARTY_HALLDET")

                SSQL6 = "SELECT bookingno AS MCODE,TAXDESC AS ASSOCIATENAME ,HALLTAXPERC AS TAX, SUM(TAXAMOUNT) AS AMOUNT FROM TAX_DETAILS_BOOKING Where bookingno=" & TXTBOOKINGNO.Text & " GROUP BY bookingno,TAXDESC ,HALLTAXPERC "
                GCONNECTION.getDataSet(SSQL6, "PARTY_PENDINGBILL")


            End If
            Viewer.Report = R


            Call Viewer.GetDetails1(sqlstring, "RPT_PARTY_RECEIPT", R)
            Call Viewer.GetDetails1(SQL1, "RPT_PARTY_POSDETAILS", R)
            Call Viewer.GetDetails1(SSQL5, "RPT_PARTY_HALLDET", R)
            Call Viewer.GetDetails1(SSQL6, "PARTY_PENDINGBILL", R)


            ''Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject

            ''TXTOBJ5 = R.ReportDefinition.ReportObjects("Text10")
            ''TXTOBJ5.Text = MyCompanyName
            ''Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            ''TXTOBJ6 = R.ReportDefinition.ReportObjects("Text11")
            ''TXTOBJ6.Text = Address1 & Address2

            ''Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            ''TXTOBJ8 = R.ReportDefinition.ReportObjects("Text12")
            ''TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            ''Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            ''TXTOBJ9 = R.ReportDefinition.ReportObjects("Text22")
            ''TXTOBJ9.Text = gphoneno

            sqlstring = "SELECT ISNULL(BILLNO,'') FROM PARTY_hDR WHERE BOOKINGNO = '" & TXTBOOKINGNO.Text & "' AND BOOKINGTYPE = 'BILLING'"
            GCONNECTION.getDataSet(sqlstring, "Bno")
            'GCONNECTION.getDataSet(sqlstring, "PARTY_PENDINGBILL")
            If gdataset.Tables("Bno").Rows.Count > 0 Then
                BillNo = gdataset.Tables("Bno").Rows(0).Item(0)
            End If

            sqlstring = "SELECT CAST(CONVERT(VARCHAR,PartyTodate,106) AS DATETIME) AS TODATE,CAST(CONVERT(VARCHAR,Partydate,106) AS DATETIME) AS PARTYDATE FROM party_hallbooking_det WHERE BOOKINGNO = '" & TXTBOOKINGNO.Text & "'"
            GCONNECTION.getDataSet(sqlstring, "Bno")
            'GCONNECTION.getDataSet(sqlstring, "PARTY_PENDINGBILL")
            If gdataset.Tables("Bno").Rows.Count > 0 Then
                PTodate = Format(gdataset.Tables("Bno").Rows(0).Item("TODATE"), "dd.MM.yyyy")
                Pdate = Format(gdataset.Tables("Bno").Rows(0).Item("PARTYDATE"), "dd.MM.yyyy")
                If PTodate = Pdate Then
                    PTodate = "01-JAN-1900"
                End If
            End If
            If PTodate = "01-JAN-1900" Then
                TDATE = ""
            Else
                TDATE = Format(PTodate, "dd.MM.yyyy")
            End If

            Dim TXTOBJ2 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ2 = R.ReportDefinition.ReportObjects("Text31")
            TXTOBJ2.Text = BillNo

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = R.ReportDefinition.ReportObjects("Text23")
            TXTOBJ1.Text = "UserName : " & gUsername

            Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ3 = R.ReportDefinition.ReportObjects("Text24")
            TXTOBJ3.Text = TDATE

            Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ4 = R.ReportDefinition.ReportObjects("Text11")
            If TDATE = "" Then
                TXTOBJ4.Text = ""
            Else
                TXTOBJ4.Text = "To"
            End If

            Viewer.Show()
        End If

    End Sub
    Private Sub PARTYBillingform()

        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL, SSQL1, SSQL2, SSQL3, SSQ As String
        Dim Viewer As New ReportViwer

        'Dim r As New FOODOERDERREPORT

        Dim r As New MENUORDERCATH

        Dim POSdesc(), MemberCode() As String
        Dim sqlstring1 As String
        Dim SQLSTRING2 As String

        If TXTBOOKINGNO.Text = "" Then
            MessageBox.Show("PLEASE ENTER THE BOOKING NO", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTBOOKINGNO.Focus()
            Exit Sub

        End If
        SSQ = "update party_restaurant set itemdesc=a.ITEMDESC ,GROUPCODE=a.GROUPCODE  from party_itemmaster a where a.ITEMCODE=party_restaurant.ITEMCODE AND party_restaurant.BOOKINGNO = '" & Me.TXTBOOKINGNO.Text & "'"
        GCONNECTION.getDataSet(SSQ, "party_restaurant")

        If Trim(TXTBOOKINGNO.Text) <> "" And Trim(TXTBOOKINGNO.Text) <> "" Then
            'SSQL = "SELECT TOP 1 * FROM foodorder1 WHERE BOOKINGNO = '" & Me.TXTBOOKINGNO.Text & "' "
           
            SSQL3 = "SELECT DISTINCT * FROM party_menu_book WHERE BOOKINGNO = '" & Me.TXTBOOKINGNO.Text & "' "
            GCONNECTION.getDataSet(SSQL3, "MAXNO")
            SSQL2 = "SELECT * FROM PARTYRECEIPTREPORT WHERE BOOKINGNO = '" & Me.TXTBOOKINGNO.Text & "' "
            GCONNECTION.getDataSet(SSQL2, "PARTYRECEIPTREPORT")
            SSQL = "SELECT * FROM foodorder1 WHERE BOOKINGNO = '" & Me.TXTBOOKINGNO.Text & "' "
            GCONNECTION.getDataSet(SSQL, "MAXNO")
        End If
        If gdataset.Tables("MAXNO").Rows.Count > 0 Then
            Viewer.Report = r

            Call Viewer.GetDetails1(SSQL, "foodorder1", r)
            Call Viewer.GetDetails1(SSQL3, "party_menu_book", r)
            'Call Viewer.GetDetails(SSQL2, "PARTY_MENU", r)
            'Call Viewer.GetDetails(SSQL3, "PARTY_ARRANGE", r)
            Call Viewer.GetDetails1(SSQL2, "PARTYRECEIPTREPORT", r)
            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text13")
            TXTOBJ5.Text = MyCompanyName
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text15")
            TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text16")
            TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
            TXTOBJ9.Text = "PhoneNo : " & gphoneno

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text2")
            TXTOBJ1.Text = "UserName : " & gUsername
            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub
    Private Sub PARTY_VIEW_HALLBOOKINGDETAILS()
        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL, SSQL1, SSQL2 As String
        Dim Viewer As New ReportViwer

        Dim r As New CrptPARTY_VIEW_HALLBOOKINGDETAILS

        Dim POSdesc(), MemberCode() As String
        Dim sqlstring1 As String
        Dim SQLSTRING2 As String

        If CDate(Format(DTPPARTYDATE.Value, "yyyy/MMM/dd")) < CDate(Format(gFinancialyearStart, "yyyy/MMM/dd")) Then
            MsgBox("From Date Should be within Financial Year Date.......", MsgBoxStyle.OKOnly, "Date Validation")
            DTPPARTYDATE.Value = gFinancialyearStart
        End If

        If CDate(Format(DTPBOOKINGDATE.Value, "yyyy/MMM/dd")) > CDate(Format(DTPPARTYDATE.Value, "yyyy/MMM/dd")) Then
            MsgBox("From Date Should be Less Than or Equal to Date.......", MsgBoxStyle.OKOnly, "Date Validation")
            DTPBOOKINGDATE.Value = DTPPARTYDATE.Value
        End If



        sqlstring = " SELECT b.priority, a.* FROM PARTY_VIEW_HALLBOOKINGDETAILS_NEW a,party_group_master b Where a.groupcode=b.groupcode and a.bookingno='" & TXTBOOKINGNO.Text & "' AND a.LOCCODE='" & Trim(CMB_LOCATION.Text) & "' "
        'GCONNECTION.getDataSet(sqlstring, "PARTY_VIEW_HALLBOOKINGDETAILS")
        'If gdataset.Tables("PARTY_VIEW_HALLBOOKINGDETAILS").Rows.Count <= 0 Then
        '    sqlstring = "SELECT * FROM PARTY_VIEW_HALLBOOKINGDETAILS WHERE bookingno='" & TXTBOOKINGNO.Text & "'AND  ISNULL(BILLINGFLAG,'')='Y'AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"

        'End If

        If Trim(CMBBOOKINGTYPE.SelectedItem) = "BOOKING" Then
            sqlstring = sqlstring & "and  a.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.SelectedItem) & "' AND ISNULL(BOOKINGFLAG,'')='Y' order by b.priority"
        ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "BILLING" Then
            sqlstring = sqlstring & "and  a.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.SelectedItem) & "' AND ISNULL(a.BILLINGFLAG,'')='Y' order by b.priority"
        ElseIf Trim(CMBBOOKINGTYPE.SelectedItem) = "CANCEL" Then
            sqlstring = sqlstring & " and  a.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.SelectedItem) & "' AND ISNULL(CANCELFLAG,'')='Y' order by b.priority"
        End If


        GCONNECTION.getDataSet(sqlstring, "MAXNO")
        'sqlstring = "SELECT * FROM PARTY_VIEW_HALLBOOKINGDETAILS"
        'sqlstring = sqlstring & " ORDER BY GROUPCODE "

        'SSQL1 = "ALTER VIEW PAR_ADDITIONALITEMS AS SELECT A.*,B.ITEMDESC FROM PARTY_RESTAURANT A LEFT OUTER JOIN PARTY_ITEMMASTER B ON A.ITEMCODE=B.ITEMCODE WHERE TTYPE='R' AND BOOKINGTYPE='BOOKING' AND LOCCODE='RSI' AND BOOKINGNO=" & TXTBOOKINGNO.Text & ""
        'GCONNECTION.getDataSet(SSQL1, "MAXNO")
        'SSQL1 = "SELECT * FROM PAR_ADDITIONALITEMS"

        'SSQL2 = "select * from PARTY_TAR_VIEW where '" & TXTBOOKINGNO.Text & "'"
        'GCONNECTION.getDataSet(SSQL2, "MAXNO")
        'SSQL2 = "SELECT * FROM PARTY_TAR_VIEW"

        Viewer.Report = r

        Call Viewer.GetDetails(sqlstring, "PARTY_VIEW_HALLBOOKINGDETAILS_NEW", r)
        'Call Viewer.GetDetails1(SSQL1, "PAR_ADDITIONALITEMS", r)

        'Call Viewer.GetDetails1(SSQL2, "PARTY_TAR_VIEW", r)

        Viewer.TableName = "PARTY_VIEW_HALLBOOKINGDETAILS_NEW"


        'Viewer.TableName = "view_party_billing"

        Dim textobj1 As TextObject
        textobj1 = r.ReportDefinition.ReportObjects("Text2")
        textobj1.Text = MyCompanyName

        Dim textobj2 As TextObject
        textobj2 = r.ReportDefinition.ReportObjects("Text16")
        textobj2.Text = Address1

        Dim textobj3 As TextObject
        textobj3 = r.ReportDefinition.ReportObjects("Text17")
        textobj3.Text = Address2

        Dim textobj5 As TextObject
        textobj5 = r.ReportDefinition.ReportObjects("Text28")
        textobj5.Text = gCity

        Dim TXTOBJ1 As TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text20")
        TXTOBJ1.Text = "UserName : " & gUsername

        Viewer.Show()

    End Sub
    Private Sub view_party_billing()
        Dim servercode() As String
        Dim i As Integer
        Dim sqlstring, SSQL, SSQL1, SSQL2, SSQL3, SSQL4, SSQL5 As String
        Dim Viewer As New ReportViwer
        'Dim r As New PARTYVIEWBOOKING
        'Dim r As New Crptbillingform
        If CDate(Format(DTPPARTYDATE.Value, "yyyy/MMM/dd")) < CDate(Format(gFinancialyearStart, "yyyy/MMM/dd")) Then
            MsgBox("From Date Should be within Financial Year Date.......", MsgBoxStyle.OKOnly, "Date Validation")
            DTPPARTYDATE.Value = gFinancialyearStart
        End If

        If CDate(Format(DTPBOOKINGDATE.Value, "yyyy/MMM/dd")) > CDate(Format(DTPPARTYDATE.Value, "yyyy/MMM/dd")) Then
            MsgBox("From Date Should be Less Than or Equal to Date.......", MsgBoxStyle.OKOnly, "Date Validation")
            DTPBOOKINGDATE.Value = DTPPARTYDATE.Value
        End If

        If Trim(TXTBOOKINGNO.Text) <> "" And Trim(TXTBOOKINGNO.Text) <> "" Then



            SSQL = "ALTER VIEW PAR_RECEIPTS AS SELECT * FROM PARTY_RECEIPT  WHERE  BOOKINGNO=" & TXTBOOKINGNO.Text & ""
            GCONNECTION.getDataSet(SSQL, "MAXNO")

            SSQL = "SELECT * FROM PAR_RECEIPTS"

            SSQL1 = "ALTER VIEW PAR_ADDITIONALITEMS AS SELECT  A.*,B.ITEMDESC FROM PARTY_RESTAURANT A LEFT OUTER JOIN PARTY_ITEMMASTER B ON A.ITEMCODE=B.ITEMCODE WHERE TTYPE='R' AND BOOKINGTYPE='BILLING' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND BOOKINGNO=" & TXTBOOKINGNO.Text & ""
            GCONNECTION.getDataSet(SSQL1, "MAXNO")
            SSQL1 = "SELECT * FROM PAR_ADDITIONALITEMS"

            SSQL2 = "ALTER VIEW PAR_ARRANGEMENT AS SELECT  A.*,B.ARRDESCRIPTION FROM PARTY_ARRANGEMENT A LEFT OUTER JOIN party_arrangemaster_hdr B ON A.ITEMCODE=B.ARRCODE WHERE  BOOKINGTYPE='BILLING' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'AND BOOKINGNO=" & TXTBOOKINGNO.Text & ""
            GCONNECTION.getDataSet(SSQL2, "MAXNO")
            SSQL2 = "SELECT * FROM PAR_ARRANGEMENT"

            SSQL3 = "ALTER VIEW PAR_HDR AS SELECT A.*,B.MNAME,B.PADD1,ISNULL(C.VEGRATE,0) AS VEGRATE1,ISNULL(C.NONVEGRATE,0) AS NONVEGRATE1,ISNULL(VEG,0)*ISNULL(C.VEGRATE,0)AS VEGAMOUNT,ISNULL(NONVEG,0)*ISNULL(C.NONVEGRATE,0) AS NONVEGAMOUNT,(ISNULL(VEG,0)*ISNULL(C.VEGRATE,0))+(ISNULL(NONVEG,0)*ISNULL(C.NONVEGRATE,0)) AS TOTALTARIFFAMOUNT FROM PARTY_HDR A LEFT OUTER JOIN MEMBERMASTER B ON A.MCODE=B.MCODE LEFT OUTER JOIN PARTY_TAR_VIEW C ON  A.BOOKINGNO=C.BOOKINGNO AND a.bookingtype=c.bookingtype  WHERE A.BOOKINGTYPE='BILLING' AND A.LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND A.BOOKINGNO=" & TXTBOOKINGNO.Text & ""


            'SSQL3 = "ALTER VIEW PAR_HDR AS SELECT A.*,B.MNAME,B.PADD1,ISNULL(C.VEGRATE,0) AS VEGRATE1,ISNULL(C.NONVEGRATE,0) AS NONVEGRATE1,ISNULL(VEG,0)*ISNULL(C.VEGRATE,0)AS VEGAMOUNT,ISNULL(NONVEG,0)*ISNULL(C.NONVEGRATE,0) AS NONVEGAMOUNT,(ISNULL(VEG,0)*ISNULL(C.VEGRATE,0))+(ISNULL(NONVEG,0)*ISNULL(C.NONVEGRATE,0)) AS TOTALTARIFFAMOUNT FROM PARTY_HDR A LEFT OUTER JOIN MEMBERMASTER B ON A.MCODE=B.MCODE LEFT OUTER JOIN PARTY_TAR_VIEW C ON  A.BOOKINGNO=C.BOOKINGNO AND a.bookingtype=c.bookingtype  WHERE  A.LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND A.BOOKINGNO=" & TXTBOOKINGNO.Text & ""
            GCONNECTION.getDataSet(SSQL3, "MAXNO")
            SSQL3 = "SELECT * FROM PAR_HDR"

            sqlstring = "ALTER VIEW PAR_TARIFF AS SELECT A.BOOKINGNO,A.TARIFFCODE,B.CATEGORY,CASE WHEN B.CATEGORY='VEG' THEN C.VEG ELSE C.NONVEG END AS PAX,B.RATE,B.TAXCODE,D.TAXPERCENTAGE,CASE WHEN B.CATEGORY='VEG' THEN ISNULL(C.VEG,0)*ISNULL(B.RATE,0) ELSE ISNULL(C.NONVEG,0)*ISNULL(B.RATE,0) END AS TARIFFAMOUNT FROM PARTY_RESTAURANT A LEFT OUTER JOIN PARTY_TARIFFHDR B ON A.TARIFFCODE=B.TARIFFCODE LEFT OUTER JOIN PARTY_HDR C ON A.BOOKINGNO=C.BOOKINGNO AND A.BOOKINGTYPE=C.BOOKINGTYPE LEFT OUTER JOIN ITEMTYPEMASTER D ON B.TAXCODE=D.TAXCODE  WHERE isnull(A.LOCCODE,'')='" & Trim(CMB_LOCATION.Text) & "' AND TTYPE='T' AND A.BOOKINGTYPE='BILLING' AND A.LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND A.BOOKINGNO=" & TXTBOOKINGNO.Text & " GROUP BY A.BOOKINGNO,A.TARIFFCODE,C.VEG,B.CATEGORY,C.NONVEG,B.RATE,B.TAXCODE,D.TAXPERCENTAGE"
            GCONNECTION.getDataSet(sqlstring, "MAXNO")

            sqlstring = "SELECT * FROM PAR_TARIFF"

            'SSQL3 = "ALTER VIEW PAR_HDR AS SELECT *,VEG*VEGRATE AS VEGAMOUNT,NONVEG*NONVEGRATE AS NONVEGAMOUNT,(ISNULL(VEG,0)*ISNULL(VEGRATE,0))+(ISNULL(NONVEG,0)*ISNULL(NONVEGRATE,0)) AS TOTALTARIFFAMOUNT FROM PARTY_HDR WHERE  BOOKINGTYPE='BILLING' AND LOCCODE='RSI'AND BOOKINGNO=" & TXTBOOKINGNO.Text & ""
            'GCONNECTION.getDataSet(SSQL3, "MAXNO")
            'SSQL3 = "SELECT * FROM PAR_HDR"

            SSQL4 = "ALTER VIEW PAR_HALLBOOKING AS  SELECT DISTINCT A.*,B.HALLDESC FROM PARTY_HALLBOOKING_DET A LEFT OUTER JOIN PARTY_VIEW_HALLBOOKINGDETAILS B ON A.BOOKINGNO=B.BOOKINGNO and a.hallcode=b.hallcode WHERE  A.LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND A.BOOKINGNO=" & TXTBOOKINGNO.Text & ""
            GCONNECTION.getDataSet(SSQL4, "MAXNO")
            SSQL4 = "SELECT * FROM PAR_HALLBOOKING"

            SSQL5 = "ALTER VIEW PAR_CONSUMPTION AS SELECT * FROM PARTY_BAR_CONSUMPTION WHERE BOOKINGNO = '" & Me.TXTBOOKINGNO.Text & "' "
            GCONNECTION.getDataSet(SSQL5, "MAXNO")
            SSQL5 = "SELECT * FROM PAR_CONSUMPTION"
            'SSQL = "SELECT BOOKINGNO = " & TXTBOOKINGNO.Text & ",RECEIPTNO,RECEIPTDATE,AMOUNTTYPE,ADDDATETIME,AMOUNT,LOCCODE FROM PARTY_RECEIPT"
            'SSQL1 = " SELECT * FROM PARTY_RESTAURANT WHERE TTYPE='R' AND BOOKINGTYPE='BILLING' "
            'SSQL2 = "SELECT * FROM PARTY_ARRANGEMENT WHERE  BOOKINGTYPE='BILLING' AND LOCCODE='RSI'"
        End If
        Dim r As New PARTY_CATH
        'Dim r As New PARTYTARIFF

        'If r.Subreports("additionalitems").ReportDefinition.Sections(6).SectionFormat.EnableSuppress = True Then

        'End If


        Call Viewer.GetDetails1(sqlstring, "PAR_TARIFF", r)
        Call Viewer.GetDetails1(SSQL, "PAR_RECEIPTS", r)
        Call Viewer.GetDetails1(SSQL1, "PAR_ADDITIONALITEMS", r)
        Call Viewer.GetDetails1(SSQL2, "PAR_ARRANGEMENT", r)
        Call Viewer.GetDetails1(SSQL3, "PAR_HDR", r)
        Call Viewer.GetDetails1(SSQL4, "PAR_HALLBOOKING", r)
        Call Viewer.GetDetails1(SSQL5, "PAR_CONSUMPTION", r)



        'Dim POSdesc(), MemberCode() As String
        'Dim SQLSTRING2 As String

        'sqlstring = "SELECT * FROM PARTY_HDR Where  bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"

        'GCONNECTION.getDataSet(sqlstring, "MAXNO")

        'Call Viewer.GetDetails(sqlstring, "PARTY_HDR", r)

        'Viewer.Report = r

        'Viewer.TableName = "PAR_TARIFF"


        Dim TXTOBJ4 As TextObject
        TXTOBJ4 = r.ReportDefinition.ReportObjects("Text9")
        TXTOBJ4.Text = MyCompanyName

        Dim TXTOBJ1 As TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text5")
        TXTOBJ1.Text = "UserName : " & gUsername

        'Dim textobj1 As TextObject
        'textobj1 = r.ReportDefinition.ReportObjects("Text1")
        'textobj1.Text = gDatabase

        Dim textobj2 As TextObject
        textobj2 = r.ReportDefinition.ReportObjects("Text10")
        textobj2.Text = Address1

        Dim textobj3 As TextObject
        textobj3 = r.ReportDefinition.ReportObjects("Text11")
        textobj3.Text = Address2

        Dim textobj5 As TextObject
        textobj5 = r.ReportDefinition.ReportObjects("Text28")
        textobj5.Text = gCity


        'Dim textobj4 As TextObject
        'textobj4 = r.ReportDefinition.ReportObjects("Text2")
        'textobj4.Text = 


        Viewer.Show()

    End Sub
    'VIJAY
    'Private Sub cmdreport1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport1.Click
    '    Dim servercode() As String
    '    Dim i As Integer

    '    Dim sqlstring, SSQL As String
    '    Dim Viewer As New ReportViwer
    '    Dim r As New PARTYVIEWBOOKING
    '    Dim POSdesc(), MemberCode() As String
    '    Dim SQLSTRING2 As String
    '    If CDate(Format(DTPPARTYDATE.Value, "dd/MMM/yyyy")) < CDate(Format(gFinancialyearStart, "dd/MMM/yyyy")) Then
    '        MsgBox("From Date Should be within Financial Year Date.......", MsgBoxStyle.OKOnly, "Date Validation")
    '        DTPPARTYDATE.Value = gFinancialyearStart
    '    End If

    '    If CDate(Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy")) > CDate(Format(DTPPARTYDATE.Value, "dd/MMM/yyyy")) Then
    '        MsgBox("From Date Should be Less Than or Equal to Date.......", MsgBoxStyle.OKOnly, "Date Validation")
    '        DTPBOOKINGDATE.Value = DTPPARTYDATE.Value
    '    End If
    '    sqlstring = "SELECT * FROM view_party_billing Where  bookingno=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"

    '    GCONNECTION.getDataSet(sqlstring, "MAXNO")

    '    Call Viewer.GetDetails(sqlstring, "view_party_billing", r)
    '    Viewer.Report = r

    '    Viewer.TableName = "view_party_billing"
    '    Viewer.Show()

    'End Sub

    Private Sub TxtOCCUPANCY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOCCUPANCY.TextChanged

    End Sub

    Private Sub TXTMCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTMCODE.TextChanged

    End Sub

    Private Sub TxtVOCCUPANCY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtVOCCUPANCY.TextChanged

    End Sub

    Private Sub TxtVOCCUPANCY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVOCCUPANCY.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TxtNVOCCUPANCY.Focus()
        End If
    End Sub

    Private Sub TXTDESCRIPTION_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTDESCRIPTION.TextChanged

    End Sub

    Private Sub SSGRID_TARIFF_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSGRID_TARIFF.Advance

    End Sub

    Private Sub SSGRID_TARIFF_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles SSGRID_TARIFF.Invalidated

    End Sub

    Private Sub GRP_TARIFF_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRP_TARIFF.Enter

    End Sub

    Private Sub SSGRID_ARRANGE_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSGRID_ARRANGE.Advance

    End Sub

    Private Sub grp_Tabledetails_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grp_Tabledetails.Enter

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub

    Private Sub RDO_TARIFF_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDO_TARIFF.CheckedChanged
        If RDO_TARIFF.Checked = True Then
            GBHALLFACILITY.Visible = False
            GBARRANGEDETAILS.Visible = False
            GBMENUDETAILS.Visible = False
            GBHALLFACILITY.Top = 12
            GBHALLFACILITY.Top = 296
            GRP_TARIFF.Visible = True
            SSGRID_HALL.Focus()
            TXT_TARIFF.Focus()
        Else
            GRP_TARIFF.Visible = False
        End If
    End Sub

    Private Sub RDO_nv_TARIFF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDO_nv_TARIFF.CheckedChanged
        If RDO_nv_TARIFF.Checked = True Then
            GBHALLFACILITY.Visible = False
            GBARRANGEDETAILS.Visible = False
            GBMENUDETAILS.Visible = False
            GBHALLFACILITY.Top = 12
            GBHALLFACILITY.Top = 296
            Me.GRP_NVEG.Visible = True
            SSGRID_HALL.Focus()
            TextNVTBOX.Focus()
        Else
            GRP_NVEG.Visible = False
        End If
    End Sub

    Private Sub NVHELP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NVHELP.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT DISTINCT TARIFFCODE,TARIFFDESC,RATE FROM PARTY_TARIFFHDR"
        gSQLString = gSQLString & " "
        If Trim(Search) = " " Then
            M_WhereCondition = " WHERE CATEGORY='NON VEG' and FREEZE <>'y'"
        Else
            M_WhereCondition = " WHERE CATEGORY='NON VEG' and FREEZE <>'y'"
        End If
        vform.Field = "TARIFFCODE,TARIFFDESC,RATE"
        ' vform.vFormatstring = "         TARIFF DESCRIPTION        |TARIFF CODE|  RATE  "
        vform.vCaption = "TARIFF MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TextNVTBOX.Text = Trim(vform.keyfield & "")
            TXT_NVDESC.Text = Trim(vform.keyfield1 & "")
            'Txt_Maxitems.Text = Val(vform.keyfield3)
            Call TextNVTBOX_Validated(TXT_TARIFF, e)
            'SSGRID_TARIFF.SetActiveCell(1, 1)
            'SSGRID_TARIFF.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub TextNVTBOX_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextNVTBOX.TextChanged

    End Sub

    Private Sub TextNVTBOX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextNVTBOX.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TextNVTBOX.Text) = "" Then
                Call NVHELP_Click(sender, e)
            Else
                Call TextNVTBOX_Validated(TXT_TARIFF, e)
            End If
        End If
    End Sub

    Private Sub TextNVTBOX_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextNVTBOX.Validated
        Dim SQLSTRING As String
        '' ''If Val(TxtOCCUPANCY.Text) <= 0 Then
        '' ''    MsgBox("Please enter the Occupancy....", MsgBoxStyle.OKOnly, "VALIDATE")
        '' ''    TxtOCCUPANCY.Focus()
        '' ''    Exit Sub
        '' ''End If

        If Trim(TextNVTBOX.Text) <> "" Then
            SQLSTRING = "SELECT TARIFFDESC,TARIFFCODE,SUM(MAXITEMS) AS MAXITEMS FROM PARTY_TARIFFDET WHERE TARIFFCODE='" & Trim(TextNVTBOX.Text) & "' and FREEZE <>'y' "
            SQLSTRING = SQLSTRING & " GROUP BY TARIFFDESC,TARIFFCODE"
            GCONNECTION.getDataSet(SQLSTRING, "TARIFF")
            If gdataset.Tables("TARIFF").Rows.Count > 0 Then
                TextNVTBOX.Text = gdataset.Tables("TARIFF").Rows(0).Item("TARIFFCODE")
                TXT_NVDESC.Text = gdataset.Tables("TARIFF").Rows(0).Item("TARIFFDESC")
                TXT_NVMAX.Text = gdataset.Tables("TARIFF").Rows(0).Item("MAXITEMS")

                'Lbl_Menu.Text = gdataset.Tables("TARIFF").Rows(0).Item("MENUCODE")
                SSGRID_NV.MaxRows = Val(TXT_NVMAX.Text)
                SSGRID_NV.SetActiveCell(1, 1)
                SSGRID_NV.Focus()
                '  SSGRID_TARIFF.SetText(1, 1, TXT_TARIFF.Text)
                '' '' ''If MsgBox("copy items from veg menu...", MsgBoxStyle.OKCancel + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "KOT") = MsgBoxResult.OK Then
                '' '' ''    Call copyitems(TextNVTBOX.Text)
                '' '' ''End If
            Else
                TextNVTBOX.Text = ""
                TextNVTBOX.Focus()
            End If
        End If
    End Sub
    Private Sub copyitems(ByVal str As String)

        If SSGRID_TARIFF.DataRowCnt > 0 Then
            For I = 1 To SSGRID_TARIFF.DataRowCnt
                Dim veg(10) As String
                For J = 1 To SSGRID_TARIFF.DataColCnt
                    SSGRID_TARIFF.GetText(J, I, veg(J))
                Next
                For J = 1 To SSGRID_TARIFF.DataColCnt
                    If J = 1 Then
                        SSGRID_NV.SetText(J, I, str)
                    Else
                        SSGRID_NV.SetText(J, I, veg(J))
                    End If

                Next
            Next
        End If

    End Sub
    Private Sub TXT_NVDESC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_NVDESC.TextChanged

    End Sub

    Private Sub SSGRID_NV_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSGRID_NV.Advance

    End Sub


    Private Sub SSGRID_NV_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID_NV.KeyDownEvent
        Dim ITEMCODE As String
        Dim SQLSTRING, GROUP As String
        Dim QTY, RATE, AMT As Double
        Dim COUNT, MAXITEMS As Integer

        With SSGRID_NV
            I = .ActiveRow
            If e.keyCode = Keys.Enter Then
                If .ActiveCol = 1 Then
                    .Col = 1
                    .Row = I
                    ITEMCODE = Trim(.Text)
                    If Trim(ITEMCODE) = "" Then

                        '  Call FILLTARIFFITEM()
                        Call FILLTARIFFnv()
                    ElseIf Trim(ITEMCODE) <> "" Then
                        SQLSTRING = "SELECT DISTINCT TARIFFDESC,TARIFFCODE,RATE FROM PARTY_TARIFFHDR WHERE TARIFFCODE ='" & Trim(ITEMCODE) & "' AND freeze<>'Y'"
                        GCONNECTION.getDataSet(SQLSTRING, "TITEM")
                        If gdataset.Tables("TITEM").Rows.Count > 0 Then
                            .Col = 1
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("TARIFFCODE")
                            .SetActiveCell(2, I)
                            .Focus()
                        Else
                            MsgBox("INVALID TARIFF CODE..", MsgBoxStyle.Information)
                            .Col = 1
                            .Row = I
                            .Text = ""
                            .SetActiveCell(1, I)
                            .Focus()
                        End If
                    End If
                ElseIf .ActiveCol = 2 Then
                    .Col = 2
                    .Row = I
                    ITEMCODE = Trim(.Text)
                    If Trim(ITEMCODE) = "" Then
                        Call FILLTARIFFITEMnv()
                    ElseIf Trim(ITEMCODE) <> "" Then
                        'SQLSTRING = "SELECT  distinct itemcode,itemdesc VIEW_PARTY_MENUITEMHELP WHERE TARIFFCODE ='" & Trim(TXT_TARIFF.Text) & "' "

                        SQLSTRING = "SELECT * FROM VIEW_PARTY_MENUITEMHELP WHERE TARIFFCODE ='" & Trim(TXT_TARIFF.Text) & "' AND TYPE='NVEG' "
                        SQLSTRING = SQLSTRING & " AND ITEMCODE='" & Trim(ITEMCODE) & "'"
                        GCONNECTION.getDataSet(SQLSTRING, "TITEM")
                        If gdataset.Tables("TITEM").Rows.Count > 0 Then
                            .Col = 2
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("ITEMCODE")
                            .Col = 3
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("ITEMDESC")
                            .Col = 4
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("UOM")
                            .Col = 6
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("GROUPCODE")
                            .Col = 7
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("MENUCODE")
                            .Col = 8
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("TARIFFCODE")
                            .Col = 9
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("MAXITEMS")
                            .SetActiveCell(4, I)
                            .Focus()
                        Else
                            MsgBox("INVALID ITEMCODE..", MsgBoxStyle.Information)
                            .Col = 2
                            .Row = I
                            .Text = ""
                            .SetActiveCell(2, I)
                            .Focus()
                        End If
                        Call CHECKDUPLICATE1(Group, MAXITEMS, ITEMCODE)
                    End If
                ElseIf .ActiveCol = 3 Then
                    .SetActiveCell(4, I)
                    .Focus()
                ElseIf .ActiveCol = 4 Then

                    .SetActiveCell(5, I)
                    .Focus()
                ElseIf .ActiveCol = 5 Then
                    Dim tariff As String
                    .Col = 1
                    .Row = I
                    tariff = Trim(.Text)
                    .Col = 5
                    .Row = I
                    If Val(.Text) <> 0 Then
                        .SetActiveCell(2, I + 1)
                        .Focus()
                        .Col = 1
                        .Row = I
                        .SetText(1, I + 1, tariff)
                    Else
                        .SetActiveCell(5, I)
                        .Focus()
                    End If
                End If
            End If
            If e.keyCode = Keys.F3 Then
                .DeleteRows(I, 2)
                .SetActiveCell(2, I)
                .Focus()
            End If
        End With
    End Sub

    Private Sub GRP_NVEG_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRP_NVEG.Enter

    End Sub

    Private Sub GBHALLFACILITY_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GBHALLFACILITY.Enter

    End Sub

    Private Sub SSGRID_BOOKING_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSGRID_BOOKING.Advance

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub labbooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles labbooking.Click

    End Sub

    Private Sub DTPRECEIPTDATE_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPRECEIPTDATE.ValueChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.CMBBOOKINGTYPE.Text = "BILLING" Then
            Dim SETT As New SETTLEMENT(TXTBOOKINGNO.Text, DTPPARTYDATE.Value)
            SETT.MdiParent = Me.MdiParent
            SETT.Show()
            SSQL = "SELECT BOOKINGNO ,PARTYDATE ,ACCOUNTCODE +'>'+ACDESC AS ACCODE,TOTALAMOUNT AS DEBIT,CASHAMT  AS CREDIT,BANKAMT ,MEMAMT ,POSTFLAG FROM PARTY_ACC_POST WHERE BOOKINGNO ='" & Me.TXTBOOKINGNO.Text & "'"
            GCONNECTION.getDataSet(SSQL, "ACCTYPE")
            If gdataset.Tables("ACCTYPE").Rows.Count > 0 Then
                SSQL = "SELECT BOOKINGNO ,PARTYDATE ,ACCOUNTCODE +'>'+ACDESC AS ACCODE,ISNULL(SLCODE,'') AS SLCODE,TOTALAMOUNT AS DEBIT,CASHAMT  AS CREDIT,POSTFLAG FROM PARTY_ACC_POST WHERE BOOKINGNO ='" & Me.TXTBOOKINGNO.Text & "'"
            Else
                SSQL = "SELECT A.BOOKINGNO,A.PARTYDATE,A.ACCODE +'>'+B.ACDESC  AS ACCODE,ISNULL(SLCODE,'') AS SLCODE,SUM(DRAMOUNT)AS DEBIT,SUM(CRAMOUNT)AS CREDIT ,'N' AS POSTFLAG FROM PARTY_DETSUMMARY A LEFT OUTER JOIN ACCOUNTSGLACCOUNTMASTER B ON A.ACCODE=B.ACCODE  WHERE BOOKINGNO='" & Me.TXTBOOKINGNO.Text & "' GROUP BY A.BOOKINGNO,A.PARTYDATE,A.ACCODE,B.ACDESC,SLCODE "
            End If
            Call SETT.GETDATA(SSQL, TXTBOOKINGNO.Text)
        End If
    End Sub

    Private Sub GBARRANGEDETAILS_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GBARRANGEDETAILS.Enter

    End Sub

    Private Sub TXT_TARIFFDESC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_TARIFFDESC.TextChanged

    End Sub

    Private Sub TXT_TARIFF_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_TARIFF.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GBHALLBOOKING_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GBHALLBOOKING.Enter

    End Sub

    Private Sub RDBHALLFACILITY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBHALLFACILITY.CheckedChanged

    End Sub

    Private Sub cmd_mcodehelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 

    End Sub

    Private Sub BTN_MENU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_MENU.Click
        
    End Sub
    Private Sub Txt_Tariffcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_MENU.Validated

        Dim i As Integer
        If Trim(TXT_MENU.Text) <> "" Then
            SQLSTRING = "SELECT * FROM PARTY_VIEW_TARIFFMASTER WHERE TARIFFCODE='" & Trim(TXT_MENU.Text) & "' and  FREEZE <>'y'"
            'sqlstring = sqlstring & " AND CCODE='" & Trim(txt_CCode.Text) & "'"
            gconn.getDataSet(SQLSTRING, "TAR")
            If gdataset.Tables("TAR").Rows.Count > 0 Then
            End If

        End If
    End Sub


    Private Sub TXT_MENU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_MENU.TextChanged

    End Sub

    Private Sub TXT_MENU_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_MENU.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXT_MENU.Text) <> "" Then
                Call Txt_Tariffcode_Validated(TXT_MENU, e)
            Else
                Call BTN_MENU_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub chbreceipt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbreceipt.CheckedChanged

    End Sub

    Private Sub TXTBILLINGNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBILLINGNO.TextChanged

    End Sub
    Private Sub KOTcalculate()
        Dim ITEMcode, hallrate As String
        Dim TAXCODE, ItemTypeCode As String
        Dim HALLTYPE1, FROMTIME, TOTIME As String
        Dim STRSQL As String
        Dim TPercent, RoomPer, PartyPer As Double
        Dim TAXAMOUNT, perc, taxpercent, rate, QTY, halltotalamount, dbldicountAmount As Double
        'LOGAN
        For I = 1 To SSGRID_BOOKING.DataRowCnt
            rate = 0
            Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
            GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
            With SSGRID_BOOKING
                .Col = 2
                .Row = I
                ITEMcode = .Text

                .Col = 5
                .Row = I
                rate = Val(.Text)

                .Col = 6
                .Row = I
                QTY = Val(.Text)

                .Col = 8
                .Row = I
                ChargeCode = .Text

                SQLSTRING = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                GCONNECTION.getDataSet(SQLSTRING, "CODE_CHECK")
                If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                    ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                End If

                SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                GCONNECTION.getDataSet(SQLSTRING, "TAXON")
                If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                    For J = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                        IType = Trim(gdataset.Tables("TAXON").Rows(J).Item("ItemTypeCode"))
                        TAXCODE = Trim(gdataset.Tables("TAXON").Rows(J).Item("TaxCode"))
                        Taxon = Trim(gdataset.Tables("TAXON").Rows(J).Item("TAXON"))
                        TPercent = gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")

                        STRSQL = "INSERT INTO party_arrangement_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                        STRSQL = STRSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(TAXCODE) & "','" & Trim(Taxon) & "','" & Trim(ITEMcode) & "'," & Val(rate) & ",'" & Val(QTY) & "'," & (TPercent) & ","

                        If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                            Zero = (rate * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GZero = GZero + Zero
                            .SetText(9, I, Zero)
                            .SetText(10, I, Zero + rate)


                            STRSQL = STRSQL & "" & Val(Zero) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                            ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GZeroA = GZeroA + ZeroA
                            .SetText(9, I, ZeroA)
                            .SetText(10, I, ZeroA + rate)

                            STRSQL = STRSQL & "" & Val(ZeroA) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                            ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GZeroB = GZeroB + ZeroB
                            .SetText(9, I, ZeroB)
                            .SetText(10, I, ZeroB + rate)

                            STRSQL = STRSQL & "" & Val(ZeroB) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                            One = ((rate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GOne = GOne + One
                            .SetText(9, I, One)
                            .SetText(10, I, One + rate)

                            STRSQL = STRSQL & "" & Val(One) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                            OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GOneA = GOneA + OneA
                            .SetText(9, I, OneA)
                            .SetText(10, I, OneA + rate)

                            STRSQL = STRSQL & "" & Val(OneA) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                            OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GOneB = GOneB + OneB
                            .SetText(9, I, OneB)
                            .SetText(10, I, OneB + rate)

                            STRSQL = STRSQL & "" & Val(OneB) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                            Two = ((rate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GTwo = GTwo + Two
                            .SetText(9, I, Two)
                            .SetText(10, I, Two + rate)

                            STRSQL = STRSQL & "" & Val(Two) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                            TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GTwoA = GTwoA + TwoA
                            .SetText(9, I, TwoA)
                            .SetText(10, I, TwoA + rate)

                            STRSQL = STRSQL & "" & Val(TwoA) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                            TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GTwoB = GTwoB + TwoB
                            .SetText(9, I, TwoB)
                            .SetText(10, I, TwoB + rate)

                            STRSQL = STRSQL & "" & Val(TwoB) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                            Three = ((rate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GThree = GThree + Three
                            .SetText(9, I, Three)
                            .SetText(10, I, Three + rate)

                            STRSQL = STRSQL & "" & Val(Three) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                            ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GThreeA = GThreeA + ThreeA
                            .SetText(9, I, ThreeA)
                            .SetText(10, I, ThreeA + rate)

                            STRSQL = STRSQL & "" & Val(ThreeA) * QTY & ","
                        ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                            ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                            GThreeB = GThreeB + ThreeB
                            .SetText(9, I, ThreeB)
                            .SetText(10, I, ThreeB + rate)

                            STRSQL = STRSQL & "" & Val(ThreeB) * QTY & ","
                        End If
                        STRSQL = STRSQL & "'" & Trim(gUsername) & "',getdate(),'N','')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = STRSQL
                    Next
                End If
            End With
        Next







        With SSGRID_BOOKING
            'FOR i = 1 To .DataRowCnt


            'ssql = "select ISNULL(sum(cast(taxpercentage as numeric(10,2))),0) as perc  from accountstaxmaster where taxcode in(select isnull(taxtype,'') from Party_Hallmaster_TAX where HALLTYPECODE='" & hallcode & "')"
            'gconnection.getDataSet(ssql, "tax")
            'If gdataset.Tables("tax").Rows.Count > 0 Then
            '    perc = gdataset.Tables("tax").Rows(0).Item("perc")
            '    '.Text = gdataset.Tables("tax").Rows(CNT).Item("perc")
            '    .Col = 9
            '    .Row = .ActiveRow
            '    taxpercent = perc
            'Else
            'End If
            'TAXAMOUNT = (rate * taxpercent) / 100

            'halltotalamount = rate + TAXAMOUNT
            '.SetText(8, .ActiveRow, taxpercent)
            '.SetText(9, .ActiveRow, TAXAMOUNT)
            '.SetText(10, .ActiveRow, halltotalamount)
            '.Col = 8
            '.Row = .ActiveRow
            '.Text = taxpercent

            '.Col = 9
            '.Row = .ActiveRow
            '.Text = TAXAMOUNT

            '.Col = 10
            '.Row = .ActiveRow
            '.Text = halltotalamount


            Me.TXT_TOTAMT.Text = Format(Val(Me.TXT_TOTAMT.Text) + Val(halltotalamount), "0.00")
            dbldicountAmount = Format((Val(TXT_TOTAMT.Text) * Val(TXT_DISAMT.Text)) / 100, "0.00")
            'SSGRID_BOOKING.GetText(7, i, Taxamt)
            If Me.TXT_TOTAMT.Text < dbldicountAmount Then
                MessageBox.Show("DISCOUNT AMOUNT CANNOT BE GREATER THAN TOTAL AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            'TESTING  TXT_TOTAMT.Text = Format(Math.Round(TOT_AMT23(SSGRID_BOOKING), 0), "0.00")
            Me.TXTB_BAMOUNT.Text = Format(Val(TXT_TOTAMT.Text) - Format(Val(dbldicountAmount)), "0.00")
            .SetActiveCell(1, .ActiveRow + 1)
            .Focus()
            'Me.TXT_TOTAMT.Text = Format(Val(Me.TXT_TOTAMT.Text) + Val(halltotalamount), "0.00")
            'Next I
        End With

    End Sub

    Private Sub SSGRID_DockChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SSGRID.DockChanged

    End Sub



    Private Sub SSGRID_MENU_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID.KeyDownEvent
        Dim Sqlstring, Itemcode, Itemdesc, Promtcode, itc As String
        Dim varitemcode, varitemdesc, varposcode, varuom, varkotdesc As String
        Dim i, j, t, cct As Integer
        Dim PROQTY_GRID As Double

        Dim varitemrate As Double
        Try
            If e.keyCode = Keys.Enter Or e.keyCode = Keys.Tab Then
                i = SSGRID.ActiveRow
                If SSGRID.ActiveCol = 1 Then
                    SSGRID.Row = i
                    SSGRID.Col = 1
                    If Trim(SSGRID.Text) = "" Then
                        If SSGRID.ActiveRow = 1 Then
                            SSGRID.SetText(1, i, Trim(TXTBOOKINGNO.Text) & "")
                            SSGRID.SetActiveCell(2, SSGRID.ActiveRow)
                        Else
                            SSGRID.Col = 1
                            SSGRID.Row = i - 1
                            varkotdesc = Trim(SSGRID.Text)
                            SSGRID.SetText(1, i, Trim(varkotdesc) & "")
                            SSGRID.SetActiveCell(2, SSGRID.ActiveRow)
                        End If
                    Else
                        SSGRID.SetActiveCell(2, SSGRID.ActiveRow)
                    End If
                ElseIf SSGRID.ActiveCol = 2 Then
                    SSGRID.Row = i
                    SSGRID.Col = 3
                    varitemdesc = Trim(SSGRID.Text)
                    SSGRID.Col = 4
                    varposcode = Trim(SSGRID.Text)
                    SSGRID.Col = 2
                    If SSGRID.Lock = False Then
                        If Trim(SSGRID.Text) = "" Then
                            Call FillMenu() ' IT WILL SHOW A POPUP MENU FOR ITEM CODE
                        ElseIf Trim(SSGRID.Text) <> "" Then
                            If Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                                Itemcode = Trim(SSGRID.Text)
                                Dim K As Integer
                                For j = 1 To SSGRID.DataRowCnt + 1
                                    'Dim ITC
                                    SSGRID.Col = 2
                                    SSGRID.Row = j
                                    itc = SSGRID.Text
                                    For K = 1 To SSGRID.DataRowCnt + 1
                                        SSGRID.Col = 2
                                        SSGRID.Row = K
                                        If Trim(SSGRID.Text) = itc Then
                                            cct = cct + 1
                                        End If
                                    Next
                                    If cct > 1 Then
                                        If MsgBox("Duplication Item Not Allowed...." & Itemcode, MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton1, "DELETE DUPLICATE") = MsgBoxResult.Ok Then
                                            SSGRID.Row = i
                                            SSGRID.ClearRange(1, i, 15, i, True)
                                            SSGRID.DeleteRows(i, 1)
                                            SSGRID.Row = i
                                            SSGRID.Col = 1
                                            SSGRID.Lock = False
                                            SSGRID.Col = 2
                                            SSGRID.Lock = False
                                            SSGRID.Col = 3
                                            SSGRID.Lock = False
                                            SSGRID.Col = 4
                                            SSGRID.Lock = False
                                            SSGRID.Col = 5
                                            SSGRID.Lock = False
                                            SSGRID.SetActiveCell(1, i)
                                        Else
                                            SSGRID.SetActiveCell(1, i)
                                            SSGRID.Focus()
                                        End If

                                        ' MsgBox("duplicate item entry")
                                        Exit Sub
                                    End If
                                    cct = 0
                                Next
                                j = 0
                                SSGRID.ClearRange(2, SSGRID.ActiveRow, 15, SSGRID.ActiveRow, True)
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE,"
                                Sqlstring = Sqlstring & " '' AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,I.PROMITEMCODE,I.OPENFACILITY,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode"
                                If gCenterlized = "Y" Then
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink ) and I.ITEMCODE = '" & Trim(Itemcode) & "' AND '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                Else
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "') and I.ITEMCODE = '" & Trim(Itemcode) & "' AND '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE  AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                End If
                                'AND txt_POSCode='" & Trim(POScode) & "'
                                GCONNECTION.getDataSet(Sqlstring, "ITEMCODE")
                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                    SSGRID.SetText(2, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & "")
                                    SSGRID.SetText(3, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMDESC")) & "")
                                    SSGRID.SetText(10, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMTYPECODE")) & "")
                                    SSGRID.SetText(11, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXCODE")) & "")
                                    SSGRID.SetText(12, i, Val(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXPERCENTAGE")))
                                    SSGRID.SetText(14, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ACCOUNTCODE")))
                                    SSGRID.SetText(15, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("SALESACCTIN")))
                                    SSGRID.SetText(16, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("GROUPCODE")))
                                    SSGRID.SetText(17, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("SUBGROUPCODE")))
                                    SSGRID.SetText(19, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")))
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")) = "Y" Then
                                        SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                                    Else
                                        SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                    End If
                                    ''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("Promotional")) = "Y" Then
                                        Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PromItemcode"))

                                        Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC, IM.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                        Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN "

                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                        Sqlstring = Sqlstring & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                                        Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                        GCONNECTION.getDataSet(Sqlstring, "PROMOTIONAL")
                                        If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                            If MessageBox.Show("Promotional available for this Itemcode!", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) >= CDate(Now.Today) Then
                                                    SSGRID.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                    SSGRID.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                    SSGRID.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                    SSGRID.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                    SSGRID.SetText(6, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                    SSGRID.SetText(7, i + 1, 0.0)
                                                    SSGRID.SetText(8, i + 1, 0.0)
                                                    SSGRID.SetText(9, i + 1, 0.0)
                                                    SSGRID.SetText(10, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                    SSGRID.SetText(12, i + 1, 0.0)
                                                    SSGRID.SetText(16, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("GROUPCODE")) & "")
                                                    SSGRID.SetText(19, i + 1, "Y")
                                                    boolPromotional = True
                                                    'End
                                                End If
                                            End If
                                        End If
                                    End If
                                    '''*************************** $ COMPLETE PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    '''****************************** TO FILL POSCODE **********************************************************************'''
                                    'Sqlstring = "SELECT POSCODE,POSDESC,SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    Sqlstring = "SELECT POSCODE,POSDESC,'' as SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "'"
                                    GCONNECTION.getDataSet(Sqlstring, "PosMenuLinkVALIDATE")
                                    If gdataset.Tables("PosMenuLinkVALIDATE").Rows.Count > 0 Then
                                        If gCenterlized = "Y" Then
                                            Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                        Else
                                            Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "' ORDER BY POSCODE"
                                        End If
                                    Else
                                        Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    End If
                                    GCONNECTION.getDataSet(Sqlstring, "PosMenuLink")
                                    If gdataset.Tables("PosMenuLink").Rows.Count = 1 Then
                                        SSGRID.Col = 4
                                        SSGRID.Row = SSGRID.ActiveRow
                                        SSGRID.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE")
                                        'If IsDBNull(gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")) = False Then
                                        '    If Trim((gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN"))) <> "" Then
                                        '        sSGrid.Col = 14
                                        '        sSGrid.Row = sSGrid.ActiveRow
                                        '        'sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")
                                        '    Else
                                        '        MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                        '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                        '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                        '        Exit Sub
                                        '    End If
                                        'Else
                                        '    MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                        '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                        '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                        '    Exit Sub
                                        'End If
                                        '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                        Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) ORDER BY R.ITEMRATE,R.UOM"
                                        GCONNECTION.getDataSet(Sqlstring, "ITEMRATE")
                                        If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                            SSGRID.Col = 5
                                            SSGRID.Row = SSGRID.ActiveRow
                                            SSGRID.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                            SSGRID.Col = 7
                                            SSGRID.Row = SSGRID.ActiveRow
                                            If Val(PACKINGPERCENT) <> 0 Then
                                                SSGRID.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                            Else
                                                SSGRID.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                            End If
                                            ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            SSGRID.Col = 19
                                            SSGRID.Row = SSGRID.ActiveRow
                                            If Trim(SSGRID.Text) = "Y" Then
                                                SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                                            Else
                                                SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                            End If
                                        Else
                                            SSGRID.Col = 7
                                            SSGRID.Text = "0.00"
                                            SSGRID.Col = 5
                                            SSGRID.Col = 19
                                            SSGRID.Row = SSGRID.ActiveRow
                                            If Trim(SSGRID.Text) = "Y" Then
                                                SSGRID.SetActiveCell(2, SSGRID.ActiveRow)
                                            Else
                                                SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                                            End If

                                        End If
                                        '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                    Else
                                        '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''
                                        Call FillPosList(gdataset.Tables("PosMenuLink"))
                                        Me.lvw_POSCode.FullRowSelect = True
                                        pnl_POSCode.Top = 50
                                        lvw_POSCode.Focus()
                                    End If
                                    '''****************************** COMPLETE FILLING TO FILL POSCODE ******************************************************'''
                                Else
                                    MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    SSGRID.ClearRange(2, SSGRID.ActiveRow, 15, SSGRID.ActiveRow, True)
                                    SSGRID.SetActiveCell(2, SSGRID.ActiveRow)
                                    SSGRID.Lock = False
                                    SSGRID.Focus()
                                    Exit Sub
                                End If
                            Else
                                If pnl_POSCode.Top = 50 Then
                                    Me.lvw_POSCode.FullRowSelect = True
                                    lvw_POSCode.Focus()
                                End If
                            End If
                        End If
                    End If
                ElseIf SSGRID.ActiveCol = 3 Then
                    SSGRID.Row = i
                    SSGRID.Col = 4
                    varposcode = Trim(SSGRID.Text)
                    SSGRID.Col = 1
                    SSGRID.Col = 3
                    SSGRID.Row = SSGRID.ActiveRow
                    If SSGRID.Lock = False Then
                        If Trim(SSGRID.Text) = "" Then
                            Call FillMenuItem() ''' IT WILL SHOW A POPUP MENU FOR ITEM DESC
                        Else
                            If Trim(varposcode) = "" Then
                                Itemdesc = Trim(SSGRID.Text)
                                SSGRID.ClearRange(2, SSGRID.ActiveRow, 15, SSGRID.ActiveRow, True)
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,"
                                Sqlstring = Sqlstring & " '' AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,I.PROMITEMCODE FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode"
                                If gCenterlized = "Y" Then
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink ) and I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                Else
                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
                                    Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "') and I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                End If
                                GCONNECTION.getDataSet(Sqlstring, "ITEMCODE")
                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                    SSGRID.SetText(2, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & "")
                                    Itemcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & ""
                                    SSGRID.SetText(3, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMDESC")) & "")
                                    SSGRID.SetText(10, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMTYPECODE")) & "")
                                    SSGRID.SetText(11, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXCODE")) & "")
                                    SSGRID.SetText(12, i, Val(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXPERCENTAGE")))
                                    SSGRID.SetText(15, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ACCOUNTCODE")))
                                    SSGRID.SetText(16, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("GROUPCODE")))
                                    SSGRID.SetText(17, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("subgroupcode")))
                                    SSGRID.SetText(19, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")))
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")) = "Y" Then
                                        SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                                    Else
                                        SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                    End If
                                    '''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("Promotional")) = "Y" Then

                                        Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PromItemcode"))

                                        Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                        Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                        Sqlstring = Sqlstring & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                                        Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "

                                        GCONNECTION.getDataSet(Sqlstring, "PROMOTIONAL")
                                        If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                            If MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) >= CDate(Now.Today) Then
                                                    SSGRID.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                    SSGRID.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                    SSGRID.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                    SSGRID.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                    SSGRID.SetText(6, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                    SSGRID.SetText(7, i + 1, 0.0)
                                                    SSGRID.SetText(8, i + 1, 0.0)
                                                    SSGRID.SetText(9, i + 1, 0.0)
                                                    SSGRID.SetText(10, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                    SSGRID.SetText(12, i + 1, 0.0)
                                                    SSGRID.SetText(19, i + 1, "Y")
                                                    boolPromotional = True

                                                End If
                                            End If
                                        End If
                                    End If
                                    '''*************************** $ COMPLETE PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    Sqlstring = "SELECT POSCODE,POSDESC,'' as SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "'"
                                    GCONNECTION.getDataSet(Sqlstring, "PosMenuLinkVALIDATE")
                                    If gdataset.Tables("PosMenuLinkVALIDATE").Rows.Count > 0 Then
                                        If gCenterlized = "Y" Then
                                            Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                        Else
                                            Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "' ORDER BY POSCODE"
                                        End If
                                    Else
                                        Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    End If
                                    GCONNECTION.getDataSet(Sqlstring, "PosMenuLink")
                                    If gdataset.Tables("PosMenuLink").Rows.Count = 1 Then
                                        SSGRID.Col = 4
                                        SSGRID.Row = SSGRID.ActiveRow
                                        SSGRID.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE")
                                        'If IsDBNull(gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")) = False Then
                                        '    If Trim((gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN"))) <> "" Then
                                        '        sSGrid.Col = 14
                                        '        sSGrid.Row = sSGrid.ActiveRow
                                        '        'sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")
                                        '    Else
                                        '        MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                        '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                        '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                        '        Exit Sub
                                        '    End If
                                        'Else
                                        '    MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                        '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                        '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                        '    Exit Sub
                                        'End If
                                        '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                        Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) "
                                        GCONNECTION.getDataSet(Sqlstring, "ITEMRATE")
                                        If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                            SSGRID.Col = 5
                                            SSGRID.Row = SSGRID.ActiveRow
                                            SSGRID.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                            SSGRID.Col = 7
                                            ''sSGrid.Row = sSGrid.ActiveRow
                                            ''If Val(PACKINGPERCENT) <> 0 Then
                                            ''    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                            ''    ''+ (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                                            ''Else
                                            SSGRID.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                            'End If
                                            SSGRID.SetActiveCell(6, SSGRID.ActiveRow)
                                            SSGRID.Col = 19
                                            SSGRID.Row = SSGRID.ActiveRow
                                            If Trim(SSGRID.Text) = "Y" Then
                                                SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                                            Else
                                                SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                            End If
                                        Else
                                            SSGRID.Col = 5
                                            SSGRID.Col = 6
                                            SSGRID.Text = "0.00"
                                            SSGRID.Col = 19
                                            SSGRID.Row = SSGRID.ActiveRow
                                            If Trim(SSGRID.Text) = "Y" Then
                                                SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                                            Else
                                                SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                            End If

                                        End If
                                        '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                    Else
                                        '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''

                                        Call FillPosList(gdataset.Tables("PosMenuLink"))
                                        Me.lvw_POSCode.FullRowSelect = True
                                        pnl_POSCode.Top = 50
                                        lvw_POSCode.Focus()
                                    End If
                                    '''****************************** COMPLETE FILLING TO FILL POSCODE ******************************************************'''
                                Else
                                    MessageBox.Show("Specified ITEM DESC not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    SSGRID.ClearRange(1, SSGRID.ActiveRow, 15, SSGRID.ActiveRow, True)
                                    SSGRID.SetActiveCell(2, SSGRID.ActiveRow)
                                    SSGRID.Lock = False
                                    SSGRID.Focus()
                                    Exit Sub
                                End If
                            Else
                                SSGRID.Col = 19
                                SSGRID.Row = SSGRID.ActiveRow
                                If Trim(SSGRID.Text) = "Y" Then
                                    SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                                    SSGRID.Focus()
                                End If
                            End If
                        End If
                    End If
                ElseIf SSGRID.ActiveCol = 4 Then
                    SSGRID.Row = SSGRID.ActiveRow
                    SSGRID.Row = SSGRID.ActiveRow
                    SSGRID.Col = 2
                    varitemcode = Trim(SSGRID.Text)
                    SSGRID.Col = 3
                    varitemdesc = Trim(SSGRID.Text)
                    SSGRID.Col = 4
                    If Trim(varitemcode) = "" And Trim(varitemdesc) = "" Then
                        SSGRID.SetActiveCell(3, SSGRID.ActiveRow)
                        Exit Sub
                    Else
                        If SSGRID.Lock = False Then
                            SSGRID.Col = 2
                            varitemcode = Trim(SSGRID.Text)
                            SSGRID.Col = 4
                            varposcode = Trim(SSGRID.Text)
                            If Trim(varposcode) = "" Then
                                SSGRID.Text = ""
                                SSGRID.SetActiveCell(3, SSGRID.ActiveRow)
                                SSGRID.Focus()
                                Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(varitemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                GCONNECTION.getDataSet(Sqlstring, "PosMenuLink")
                                If gdataset.Tables("PosMenuLink").Rows.Count > 1 Then
                                    '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''
                                    Call FillPosList(gdataset.Tables("PosMenuLink"))
                                    Me.lvw_POSCode.FullRowSelect = True
                                    pnl_POSCode.Top = 50
                                    lvw_POSCode.Focus()
                                End If
                                '''****************************** SHOW COMPLETE FOR POS LOCATION ***********************''
                                Exit Sub
                            ElseIf Trim(varposcode) <> "" Then
                                Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER JOIN POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(varitemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND POSCODE = '" & Trim(CStr(varposcode)) & "' ORDER BY POSCODE"
                                GCONNECTION.getDataSet(Sqlstring, "POSMASTER")
                                If gdataset.Tables("POSMASTER").Rows.Count = 1 Then
                                    SSGRID.Col = 4
                                    SSGRID.Row = SSGRID.ActiveRow
                                    SSGRID.Text = gdataset.Tables("POSMASTER").Rows(0).Item("POSCODE")
                                    SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                    'If IsDBNull(gdataset.Tables("POSMASTER").Rows(0).Item("SALESACCTIN")) = False Then
                                    '    If Trim((gdataset.Tables("POSMASTER").Rows(0).Item("SALESACCTIN"))) <> "" Then
                                    '        sSGrid.Col = 14
                                    '        sSGrid.Row = sSGrid.ActiveRow
                                    '        'sSGrid.Text = gdataset.Tables("POSMASTER").Rows(0).Item("SALESACCTIN")
                                    '    Else
                                    '        MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                    '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                    '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                    '        Exit Sub
                                    '    End If
                                    'Else
                                    '    MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                    '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                                    '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                                    '    Exit Sub
                                    'End If
                                Else
                                    MessageBox.Show("!! Oop's specified POSCODE is not valid ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    SSGRID.Text = ""
                                    SSGRID.SetActiveCell(3, SSGRID.ActiveRow)
                                    SSGRID.Focus()
                                    Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(varitemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    GCONNECTION.getDataSet(Sqlstring, "PosMenuLink")
                                    If gdataset.Tables("PosMenuLink").Rows.Count > 1 Then
                                        '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''
                                        Call FillPosList(gdataset.Tables("PosMenuLink"))
                                        Me.lvw_POSCode.FullRowSelect = True
                                        pnl_POSCode.Top = 50
                                        lvw_POSCode.Focus()
                                    End If
                                    '''****************************** SHOW COMPLETE FOR POS LOCATION ***********************''
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                ElseIf SSGRID.ActiveCol = 5 Then
                    SSGRID.Row = SSGRID.ActiveRow
                    SSGRID.Row = SSGRID.ActiveRow
                    SSGRID.Col = 2
                    varitemcode = Trim(SSGRID.Text)
                    SSGRID.Col = 3
                    varitemdesc = Trim(SSGRID.Text)
                    SSGRID.Col = 4
                    varposcode = Trim(SSGRID.Text)
                    SSGRID.Col = 5
                    If Trim(varitemcode) = "" And Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                        SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                        Exit Sub
                    Else
                        If SSGRID.Lock = False Then
                            SSGRID.Col = 2
                            varitemcode = Trim(SSGRID.Text)
                            SSGRID.Col = 4
                            varposcode = Trim(SSGRID.Text)
                            SSGRID.Col = 7
                            varitemrate = Val(SSGRID.Text)
                            SSGRID.Col = 5
                            If Trim(SSGRID.Text) = "" Then
                                '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                Sqlstring = "SELECT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(varitemcode) & "' ) ORDER BY R.ITEMRATE,R.UOM"
                                GCONNECTION.getDataSet(Sqlstring, "ITEMRATE")
                                If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                    SSGRID.Col = 5
                                    SSGRID.Row = SSGRID.ActiveRow
                                    SSGRID.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                    ''sSGrid.Col = 6
                                    ''sSGrid.Row = sSGrid.ActiveRow
                                    ''sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                    ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                    SSGRID.Col = 19
                                    SSGRID.Row = SSGRID.ActiveRow
                                    If Trim(SSGRID.Text) = "Y" Then
                                        SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                                    Else
                                        SSGRID.Col = 7
                                        SSGRID.Row = SSGRID.ActiveRow
                                        SSGRID.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                        SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                    End If
                                ElseIf gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                                    SSGRID.Col = 5
                                    Call FillUomList(gdataset.Tables("ITEMRATE"))
                                    Me.lvw_Uom.FullRowSelect = True
                                    pnl_UOMCode.Top = 50
                                    Me.lvw_Uom.Focus()
                                Else
                                    SSGRID.Col = 2
                                    SSGRID.Row = SSGRID.ActiveRow
                                    If Trim(SSGRID.Text) <> "" Then
                                        SSGRID.Col = 5
                                        SSGRID.Text = ""
                                        SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                    End If
                                End If
                                '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                            ElseIf Trim(SSGRID.Text) <> "" Then
                                Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(varitemcode) & "' ) AND R.ITEMRATE = " & Val(varitemrate) & " "
                                GCONNECTION.getDataSet(Sqlstring, "RATEMASTER")
                                If gdataset.Tables("RATEMASTER").Rows.Count > 0 Then
                                    If gdataset.Tables("RATEMASTER").Rows.Count = 1 Then
                                        SSGRID.Col = 5
                                        SSGRID.Row = SSGRID.ActiveRow
                                        SSGRID.Text = CStr(gdataset.Tables("RATEMASTER").Rows(0).Item("UOM")) & ""
                                        SSGRID.Col = 7
                                        SSGRID.Row = SSGRID.ActiveRow
                                        SSGRID.Text = Val(gdataset.Tables("RATEMASTER").Rows(0).Item("ITEMRATE")) & ""
                                        SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                        SSGRID.Col = 19
                                        SSGRID.Row = SSGRID.ActiveRow
                                        If Trim(SSGRID.Text) = "Y" Then
                                            SSGRID.SetActiveCell(6, SSGRID.ActiveRow)
                                        Else
                                            SSGRID.Col = 7
                                            SSGRID.Row = SSGRID.ActiveRow
                                            'If Val(PACKINGPERCENT) <> 0 Then
                                            '    sSGrid.Text = Val(gdataset.Tables("RATEMASTER").Rows(0).Item("ITEMRATE"))
                                            '    ''+ (Val(gdataset.Tables("RATEMASTER").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                                            'Else
                                            SSGRID.Text = Val(gdataset.Tables("RATEMASTER").Rows(0).Item("ITEMRATE")) & ""
                                            'End If
                                            SSGRID.SetActiveCell(6, SSGRID.ActiveRow)
                                        End If
                                    ElseIf gdataset.Tables("RATEMASTER").Rows.Count > 1 Then
                                        SSGRID.Col = 5
                                        Call FillUomList(gdataset.Tables("ITEMRATE"))
                                        Me.lvw_Uom.FullRowSelect = True
                                        pnl_UOMCode.Top = 50
                                        Me.lvw_Uom.Focus()
                                        Exit Sub
                                    Else
                                        SSGRID.Col = 5
                                        SSGRID.Col = 7
                                        SSGRID.Text = "0.00"
                                    End If
                                Else
                                    MessageBox.Show("!! Oop's specified ITEM UOM is not valid ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    SSGRID.Col = 5
                                    SSGRID.Row = SSGRID.ActiveRow
                                    SSGRID.Text = ""
                                    SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                                End If
                            End If
                        Else
                            If pnl_UOMCode.Top = 50 Then
                                Me.lvw_Uom.FullRowSelect = True
                                pnl_UOMCode.Top = 50
                                Me.lvw_Uom.Focus()
                                Exit Sub
                            Else
                                SSGRID.SetActiveCell(6, SSGRID.ActiveRow)
                            End If
                        End If
                    End If
                ElseIf SSGRID.ActiveCol = 6 Then
                    Dim ITEMQTY, Freeqty, FreeDis, FreeRate, ActRate, PKotQty, rkotqty, baseqty As Double
                    Dim PROMAMT As Double
                    Dim Basedon, BItemcode, Pitemcode, Puom, WeekDay, Type, Pssql, buom, ssql As String
                    Dim CHECK_AVAILABILITY, k As Integer
                    SSGRID.Row = SSGRID.ActiveRow
                    SSGRID.Col = 4
                    SSGRID.Lock = True
                    SSGRID.Row = SSGRID.ActiveRow
                    SSGRID.Col = 5
                    SSGRID.Lock = True
                    SSGRID.Row = SSGRID.ActiveRow
                    SSGRID.Col = 2
                    varitemcode = Trim(SSGRID.Text)
                    SSGRID.Col = 3
                    varitemdesc = Trim(SSGRID.Text)
                    SSGRID.Col = 4
                    varposcode = Trim(SSGRID.Text)
                    SSGRID.Col = 5
                    buom = Trim(SSGRID.Text)
                    SSGRID.Col = 7
                    ActRate = Val(SSGRID.Text)
                    SSGRID.Col = 6
                    ITEMQTY = Val(SSGRID.Text)
                    WeekDay = UCase(Now.DayOfWeek.ToString)
                    PKotQty = 0
                    'boolProm = False
                    Pssql = "DELETE FROM PROM_STATUS"
                    GCONNECTION.dataOperation(9, Pssql, "DELETE")

                    Pssql = "SELECT KOTDETAILS,ITEMCODE,SUM(QTY)AS QTY FROM KOT_DET WHERE ISNULL(BILLDETAILS,'') = '' AND ISNULL(PROMKOTNO,'') = ''"
                    Pssql = Pssql & " AND CAST(CONVERT(VARCHAR,KOTDATE,106)AS DATETIME) = '" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "' AND ITEMCODE = '" & varitemcode & "' AND MCODE = '" & Trim(TXTMCODE.Text) & "'"
                    Pssql = Pssql & " AND ISNULL(PROMOTIONALST,'') <> 'Y' AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' GROUP BY KOTDETAILS,ITEMCODE "
                    GCONNECTION.getDataSet(Pssql, "PROM")
                    If gdataset.Tables("PROM").Rows.Count > 0 Then
                        For k = 0 To gdataset.Tables("PROM").Rows.Count - 1
                            PKotQty = PKotQty + gdataset.Tables("PROM").Rows(k).Item("QTY")
                            Pssql = "INSERT INTO PROM_STATUS VALUES ('" & gdataset.Tables("PROM").Rows(k).Item("KOTDETAILS") & "','" & Trim(TXTBOOKINGNO.Text) & "','" & gdataset.Tables("PROM").Rows(k).Item("ITEMCODE") & "','" & gdataset.Tables("PROM").Rows(k).Item("QTY") & "')"
                            GCONNECTION.dataOperation(9, Pssql, "DELETE")
                        Next
                    End If
                    ssql = "select pitemcode as itemcode FROM PROMMASTER WHERE  BASEDITEMCODE = '" & varitemcode & "' and baseduom= '" & buom & "' AND '" & Format(Now, "dd/MMM/yyyy") & "' BETWEEN FROMDATE AND TODATE AND '" & Format(Now, "HH:MM") & "' BETWEEN FROMTIME AND TOTIME AND WDAY = '" & WeekDay & "' AND POSCODE = '" & varposcode & "'"
                    GCONNECTION.getDataSet(ssql, "rau")
                    If gdataset.Tables("RAU").Rows.Count > 0 Then
                        Pssql = "SELECT KOTDETAILS,ITEMCODE,SUM(QTY)AS QTY FROM KOT_DET WHERE ISNULL(BILLDETAILS,'') = '' AND ISNULL(PROMKOTNO,'') = ''"
                        Pssql = Pssql & " AND CAST(CONVERT(VARCHAR,KOTDATE,106)AS DATETIME) = '" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "' AND ITEMCODE = '" & gdataset.Tables("RAU").Rows(0).Item("itemcode") & "' AND MCODE = '" & Trim(TXTMCODE.Text) & "'"
                        Pssql = Pssql & " AND ISNULL(PROMOTIONALST,'') = 'Y' AND ISNULL(KOTSTATUS,'') <> 'Y' AND ISNULL(DELFLAG,'') <> 'Y' GROUP BY KOTDETAILS,ITEMCODE "
                        GCONNECTION.getDataSet(Pssql, "PROM")
                        If gdataset.Tables("PROM").Rows.Count > 0 Then
                            For k = 0 To gdataset.Tables("PROM").Rows.Count - 1
                                rkotqty = rkotqty + gdataset.Tables("PROM").Rows(k).Item("QTY")
                            Next

                        End If
                    End If
                    Pssql = "INSERT INTO PROM_STATUS_TEMP SELECT * FROM PROM_STATUS"
                    GCONNECTION.dataOperation(9, Pssql, "DELETE")
                    ITEMQTY = ITEMQTY + PKotQty
                    If Trim(varitemcode) = "" And Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                        SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                        Exit Sub
                    Else
                        If SSGRID.Lock = False Then
                            SSGRID.Col = 2
                            SSGRID.Row = SSGRID.ActiveRow
                            If Trim(SSGRID.Text) <> "" Then
                                SSGRID.Col = 6
                                SSGRID.Row = SSGRID.ActiveRow
                                If Val(SSGRID.Text) = 0 Then
                                    SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                    Exit Sub
                                Else
                                    SSGRID.Col = 19
                                    SSGRID.Row = SSGRID.ActiveRow
                                    If Trim(SSGRID.Text) = "Y" Then
                                        SSGRID.Col = 7
                                        SSGRID.Lock = False
                                        SSGRID.SetActiveCell(7, SSGRID.ActiveRow)
                                        Exit Sub
                                    Else
                                        'GPS  PROMOTIONAL
                                        '''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                        SSGRID.Col = 2
                                        SSGRID.Row = SSGRID.ActiveRow
                                        Itemcode = Trim(SSGRID.Text)
                                        Sqlstring = " SELECT ISNULL(Promotional,'') AS Promotional,ISNULL(PromItemcode,'') AS PromItemcode FROM ITEMMASTER WHERE ITEMCODE='" & Itemcode & "'"
                                        GCONNECTION.getDataSet(Sqlstring, "ITEMCODE1")
                                        If gdataset.Tables("ITEMCODE1").Rows.Count > 0 Then
                                            If Trim(gdataset.Tables("ITEMCODE1").Rows(j).Item("Promotional")) = "Y" Then
                                                SSGRID.Col = 2
                                                SSGRID.Row = i
                                                Itemcode = Trim(SSGRID.Text)
                                                Basedon = (gdataset.Tables("ITEMCODE1").Rows(j).Item("PromItemcode"))

                                                '----- Pankaj Start
                                                If Basedon = "Q" Then
                                                    Sqlstring = "SELECT PITEMCODE,ISNULL(FREEQTY,0) AS FREEQTY,ISNULL(PUOM,'') AS PUOM,'QTY' AS TYPE,ISNULL(FIXEDRATE,0) AS FIXEDRATE,ISNULL(DISCOUNT,0) AS DISCOUNT ,cast(((" & ITEMQTY & " /FROMQTY )- " & rkotqty & " )*ISNULL(FREEQTY,0) as integer) as prom  FROM PROMMASTER WHERE BASEDON = 'Q' AND BASEDITEMCODE = '" & varitemcode & "' and baseduom= '" & buom & "'AND '" & Format(Now, "dd/MMM/yyyy") & "' BETWEEN FROMDATE AND TODATE"
                                                    ' AND " & ITEMQTY & " BETWEEN FROMQTY AND TOQTY "
                                                ElseIf Basedon = "P" Then
                                                    Sqlstring = "SELECT PITEMCODE,isnull(FROMQTY,0)as fromqty,ISNULL(FREEQTY,0) AS FREEQTY,ISNULL(PUOM,'') AS PUOM,ISNULL(TYPE,'') AS TYPE,ISNULL(FIXEDRATE,0) AS FIXEDRATE,ISNULL(DISCOUNT,0) AS DISCOUNT,cast(((" & ITEMQTY & " /FROMQTY )- " & rkotqty & " )*ISNULL(FREEQTY,0) as integer) as prom FROM PROMMASTER WHERE BASEDON = 'P' AND BASEDITEMCODE = '" & varitemcode & "' and baseduom= '" & buom & "' AND '" & Format(Now, "dd/MMM/yyyy") & "' BETWEEN FROMDATE AND TODATE AND '" & Format(Now, "HH:MM") & "' BETWEEN FROMTIME AND TOTIME AND WDAY = '" & WeekDay & "' AND POSCODE = '" & varposcode & "'"
                                                    'AND " & ITEMQTY & " BETWEEN FROMQTY AND TOQTY 
                                                End If
                                                GCONNECTION.getDataSet(Sqlstring, "FITEMCODE")
                                                If gdataset.Tables("FITEMCODE").Rows.Count > 0 Then
                                                    If gdataset.Tables("FITEMCODE").Rows(0).Item("prom") > 0 Then
                                                        boolProm = False
                                                        baseqty = gdataset.Tables("FITEMCODE").Rows(0).Item("fromqty")
                                                        Pitemcode = gdataset.Tables("FITEMCODE").Rows(0).Item("PITEMCODE")
                                                        Freeqty = gdataset.Tables("FITEMCODE").Rows(0).Item("prom")
                                                        Puom = gdataset.Tables("FITEMCODE").Rows(0).Item("PUOM")
                                                        Type = gdataset.Tables("FITEMCODE").Rows(0).Item("TYPE")
                                                        FreeRate = gdataset.Tables("FITEMCODE").Rows(0).Item("FIXEDRATE")
                                                        FreeDis = gdataset.Tables("FITEMCODE").Rows(0).Item("DISCOUNT")
                                                    Else
                                                        boolProm = False
                                                        baseqty = gdataset.Tables("FITEMCODE").Rows(0).Item("fromqty")
                                                        Pitemcode = gdataset.Tables("FITEMCODE").Rows(0).Item("PITEMCODE")
                                                        Freeqty = gdataset.Tables("FITEMCODE").Rows(0).Item("prom")
                                                        Puom = gdataset.Tables("FITEMCODE").Rows(0).Item("PUOM")
                                                        Type = gdataset.Tables("FITEMCODE").Rows(0).Item("TYPE")
                                                        FreeRate = gdataset.Tables("FITEMCODE").Rows(0).Item("FIXEDRATE")
                                                        FreeDis = gdataset.Tables("FITEMCODE").Rows(0).Item("DISCOUNT")

                                                    End If
                                                End If


                                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,TL.TAXCODE,TL.TAXPERCENTAGE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,"
                                                Sqlstring = Sqlstring & " ISNULL(TL.ACCOUNTCODE,'') AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,I.PROMOTIONAL,I.PROMITEMCODE FROM ITEMMASTER AS I"
                                                Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE "
                                                Sqlstring = Sqlstring & " WHERE I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,getdate())  AND ISNULL(I.FREEZE,'') <>'Y'"
                                                GCONNECTION.getDataSet(Sqlstring, "ITEMCODE")
                                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                                    Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(0).Item("PromItemcode"))
                                                End If
                                                SSGRID.Row = SSGRID.ActiveRow
                                                SSGRID.Col = 2
                                                Itemcode = Trim(SSGRID.Text)

                                                Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC, IM.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,ISNULL(I.PROMTYPE,'') AS PROMTYPE,"
                                                Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY,I.BASEQTY , I.PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                Sqlstring = Sqlstring & " INNER JOIN ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                                                Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now()), "dd/MMM/yyyy") & "' BETWEEN I.StartingDate AND I.EndingDate AND PL.POS='" & Trim(STRPOSCODE) & "'"


                                                If Basedon = "Q" Then
                                                    Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, 'QTY' AS PROMTYPE,"
                                                    Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & ITEMQTY & " AS BASEQTY , I.BASERATESTD AS PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                    Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                    Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                                    Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                    Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now()), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate  AND PL.POS='" & Trim(STRPOSCODE) & "'"

                                                ElseIf Basedon = "P" Then
                                                    If Type = "QTY" Then
                                                        Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, '" & Type & "' AS PROMTYPE,"
                                                        Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & ITEMQTY & " AS BASEQTY , I.BASERATESTD AS PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                        Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                                        Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                        Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate  AND PL.POS='" & Trim(STRPOSCODE) & "'"
                                                    ElseIf Type = "DISCOUNT ON RATE" Then
                                                        Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, '" & Type & "' AS PROMTYPE,"
                                                        Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & ITEMQTY & " AS BASEQTY , " & FreeDis & " AS PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                        Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                                        Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                        Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate AND PL.POS='" & Trim(STRPOSCODE) & "'"
                                                    ElseIf Type = "FIXED RATE" Then
                                                        If UCase(Mid(gCompanyname, 1, 4)) = "CATH" Then
                                                            Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, '" & Type & "' AS PROMTYPE,"
                                                            Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & baseqty & " AS BASEQTY , " & FreeRate & " AS PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                            Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                            Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                                            Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                            Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate  AND PL.POS='" & Trim(STRPOSCODE) & "'"
                                                        Else
                                                            Sqlstring = "SELECT " & Freeqty & " AS PROMQTY, I.ITEMCODE,'" & Pitemcode & "' AS PROMITEMCODE, I.ITEMDESC, I.GROUPCODE, I.ITEMTYPECODE, P.POSCODE, P.POSDESC,TL.STARTINGDATE,TL.ENDINGDATE, '" & Type & "' AS PROMTYPE,"
                                                            Sqlstring = Sqlstring & " '" & Puom & "' AS PROMUOM, " & Freeqty & " AS PROMQTY," & ITEMQTY & " AS BASEQTY , " & FreeRate & " AS PROMRATE FROM ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                                            Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                                            Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE"
                                                            Sqlstring = Sqlstring & " WHERE ((SELECT PROMOTIONAL FROM ITEMMASTER WHERE ITEMCODE = '" & varitemcode & "') = 'Y') AND (I.ITEMCODE = '" & Pitemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                                            Sqlstring = Sqlstring & " AND  '" & Format(CDate(Now), "dd/MMM/yyyy") & "' BETWEEN TL.StartingDate AND TL.EndingDate  AND PL.POS='" & Trim(STRPOSCODE) & "'"

                                                        End If
                                                    End If
                                                End If

                                                'PANKAJ
                                                'CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) <= CDate(serverdate.Today) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) >= CDate(serverdate.Today)
                                                'End
                                                GCONNECTION.getDataSet(Sqlstring, "PROMOTIONAL")
                                                SSGRID.Row = SSGRID.ActiveRow
                                                SSGRID.Col = 6
                                                Trim(SSGRID.Text)
                                                'If Trim(sSGrid.Text) = Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("BASEQTY")) Then
                                                'PROQTY_GRID = Val(Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")))
                                                If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                                    If Val(Trim(SSGRID.Text)) + PKotQty >= Val(Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("BASEQTY"))) Then
                                                        PROQTY_GRID = (Val(Math.Floor(Trim(SSGRID.Text) + PKotQty) / Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("BASEQTY"))) * Val(Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY"))))
                                                        If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 And PROQTY_GRID <> 0 And Type = "QTY" Then
                                                            CHECK_AVAILABILITY = STOCKAVAILABILITY(SSGRID, i)
                                                            If CHECK_AVAILABILITY > 0 Then
                                                                If MessageBox.Show("Promotional available for this Itemcode!", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                                    'If Format(CDate(serverdate), "dd/MM/yyyy") = Format(CDate(DTPBOOKINGDATE.Value), "dd/MM/yyyy") Then
                                                                    If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) <= CDate(Now) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) >= CDate(Now) Then
                                                                        CHECK_AVAILABILITY = STOCKAVAILABILITY(SSGRID, i)
                                                                        If CHECK_AVAILABILITY = 0 Then
                                                                            If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                                                SSGRID.ClearRange(2, i, SSGRID.MaxCols, i, True)
                                                                                SSGRID.Focus()
                                                                                SSGRID.SetActiveCell(1, i)
                                                                                Exit Sub
                                                                            End If

                                                                        ElseIf CHECK_AVAILABILITY = 1 Then
                                                                            If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                                                SSGRID.Col = 5
                                                                                SSGRID.Text = ""
                                                                                SSGRID.SetActiveCell(5, i)
                                                                                SSGRID.Focus()
                                                                                Exit Sub
                                                                            End If
                                                                        End If
                                                                        If Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "FIXED RATE" Then
                                                                            SSGRID.SetText(7, i, Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE")))
                                                                            SSGRID.Row = i
                                                                            SSGRID.Col = 6
                                                                            If Val(SSGRID.Text) > 0 Then
                                                                                ITEMQTY = Val(SSGRID.Text)
                                                                                PROMAMT = Val((ITEMQTY * Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE"))))
                                                                                SSGRID.SetText(9, i, PROMAMT)
                                                                                SSGRID.SetText(19, i, "Y")
                                                                                boolPromotional = True
                                                                                Call Calculate()
                                                                            End If
                                                                        ElseIf Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "DISCOUNT ON RATE" Then
                                                                            ActRate = ActRate - ((Val(ActRate) * Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE"))) / 100)
                                                                            SSGRID.SetText(7, i, Val(ActRate))
                                                                            SSGRID.Row = i
                                                                            SSGRID.Col = 6
                                                                            If Val(SSGRID.Text) > 0 Then
                                                                                ITEMQTY = Val(SSGRID.Text)
                                                                                PROMAMT = Val(ActRate)
                                                                                SSGRID.SetText(9, i, PROMAMT)
                                                                                SSGRID.SetText(19, i, "Y")
                                                                                boolPromotional = True
                                                                                Call Calculate()
                                                                            End If
                                                                        Else
                                                                            SSGRID.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                                            SSGRID.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                                            SSGRID.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                                            SSGRID.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                                            SSGRID.Row = i
                                                                            SSGRID.Col = 4
                                                                            SSGRID.Lock = True
                                                                            SSGRID.Row = i
                                                                            SSGRID.Col = 5
                                                                            SSGRID.Lock = True
                                                                            SSGRID.Row = i
                                                                            SSGRID.Col = 4
                                                                            SSGRID.Lock = True
                                                                            SSGRID.Row = i + 1
                                                                            SSGRID.Col = 5
                                                                            SSGRID.Lock = True
                                                                            'sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                                            SSGRID.SetText(6, i + 1, Val(PROQTY_GRID))
                                                                            SSGRID.Row = i + 1
                                                                            SSGRID.Col = 6
                                                                            SSGRID.Lock = True
                                                                            SSGRID.SetText(7, i + 1, 0.0)
                                                                            SSGRID.SetText(8, i + 1, 0.0)
                                                                            SSGRID.SetText(9, i + 1, 0.0)
                                                                            SSGRID.SetText(10, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                                            SSGRID.SetText(12, i + 1, 0.0)
                                                                            SSGRID.SetText(16, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("GROUPCODE")) & "")
                                                                            SSGRID.SetText(19, i + 1, "Y")
                                                                            SSGRID.SetText(20, i, Type)
                                                                            SSGRID.SetText(21, i, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                                            boolPromotional = True
                                                                            boolProm = True
                                                                        End If
                                                                    End If

                                                                End If
                                                            End If
                                                        ElseIf Type <> "QTY" Then
                                                            CHECK_AVAILABILITY = STOCKAVAILABILITY(SSGRID, i)
                                                            SSGRID.Row = SSGRID.ActiveRow
                                                            SSGRID.Col = 5
                                                            Trim(SSGRID.Text)
                                                            If Val(Trim(SSGRID.Text)) Mod Val(Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("BASEQTY"))) = 0 Then
                                                                If CHECK_AVAILABILITY > 0 Then
                                                                    If MessageBox.Show("Promotional available for this Itemcode!", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                                        'If Format(CDate(serverdate), "dd/MM/yyyy") = Format(CDate(DTPBOOKINGDATE.Value), "dd/MM/yyyy") Then
                                                                        If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) <= CDate(Now) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) >= CDate(Now) Then
                                                                            CHECK_AVAILABILITY = STOCKAVAILABILITY(SSGRID, i)
                                                                            If CHECK_AVAILABILITY = 0 Then
                                                                                If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                                                    SSGRID.ClearRange(1, i, SSGRID.MaxCols, i, True)
                                                                                    SSGRID.Focus()
                                                                                    SSGRID.SetActiveCell(1, i)
                                                                                    Exit Sub
                                                                                End If
                                                                            ElseIf CHECK_AVAILABILITY = 1 Then
                                                                                If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                                                    SSGRID.Col = 5
                                                                                    SSGRID.Text = ""
                                                                                    SSGRID.SetActiveCell(5, i)
                                                                                    SSGRID.Focus()
                                                                                    Exit Sub
                                                                                End If
                                                                            End If
                                                                            'If Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "RATE" Then
                                                                            If Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "FIXED RATE" Then
                                                                                SSGRID.SetText(7, i, Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE")))
                                                                                SSGRID.Row = i
                                                                                SSGRID.Col = 6
                                                                                If Val(SSGRID.Text) > 0 Then
                                                                                    ITEMQTY = Val(SSGRID.Text)
                                                                                    PROMAMT = Val((ITEMQTY * Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE"))))
                                                                                    SSGRID.SetText(9, i, PROMAMT)
                                                                                    SSGRID.SetText(19, i, "Y")
                                                                                    boolPromotional = True
                                                                                    Call Calculate()
                                                                                End If
                                                                            ElseIf Trim(UCase(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMTYPE"))) = "DISCOUNT ON RATE" Then
                                                                                ActRate = ActRate - ((Val(ActRate) * Val(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMRATE"))) / 100)
                                                                                SSGRID.SetText(7, i, Val(ActRate))
                                                                                SSGRID.Row = i
                                                                                SSGRID.Col = 6
                                                                                If Val(SSGRID.Text) > 0 Then
                                                                                    ITEMQTY = Val(SSGRID.Text)
                                                                                    PROMAMT = Val(ActRate)
                                                                                    SSGRID.SetText(9, i, PROMAMT)
                                                                                    SSGRID.SetText(19, i, "Y")
                                                                                    boolPromotional = True
                                                                                    Call Calculate()
                                                                                End If
                                                                            Else
                                                                                SSGRID.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                                                SSGRID.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                                                SSGRID.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                                                SSGRID.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                                                SSGRID.Row = i
                                                                                SSGRID.Col = 4
                                                                                SSGRID.Lock = True
                                                                                SSGRID.Row = i
                                                                                SSGRID.Col = 5
                                                                                SSGRID.Lock = True
                                                                                SSGRID.Row = i
                                                                                SSGRID.Col = 3
                                                                                SSGRID.Lock = True
                                                                                SSGRID.Row = i + 1
                                                                                SSGRID.Col = 5
                                                                                SSGRID.Lock = True
                                                                                'sSGrid.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                                                SSGRID.SetText(6, i + 1, Val(PROQTY_GRID))
                                                                                SSGRID.Row = i + 1
                                                                                SSGRID.Col = 6
                                                                                SSGRID.Lock = True
                                                                                SSGRID.SetText(7, i + 1, 0.0)
                                                                                SSGRID.SetText(8, i + 1, 0.0)
                                                                                SSGRID.SetText(9, i + 1, 0.0)
                                                                                SSGRID.SetText(10, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                                                SSGRID.SetText(12, i + 1, 0.0)
                                                                                SSGRID.SetText(16, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("GROUPCODE")) & "")
                                                                                SSGRID.SetText(19, i + 1, "Y")
                                                                                SSGRID.SetText(20, i, Type)
                                                                                SSGRID.SetText(21, i, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                                                boolPromotional = True
                                                                                boolProm = True
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            Else
                                                                Sqlstring = "SELECT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                                                Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) ORDER BY R.ITEMRATE,R.UOM"
                                                                GCONNECTION.getDataSet(Sqlstring, "ITEMRATE")
                                                                If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                                                    SSGRID.Col = 5
                                                                    SSGRID.Row = SSGRID.ActiveRow
                                                                    SSGRID.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                                                    SSGRID.Col = 7
                                                                    ''sSGrid.Row = sSGrid.ActiveRow
                                                                    ''If Val(PACKINGPERCENT) <> 0 Then
                                                                    ''    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                                                    ''    ''+ (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                                                                    ''Else
                                                                    SSGRID.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                                                    'End If
                                                                    ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                                                    SSGRID.Col = 19
                                                                    SSGRID.Row = SSGRID.ActiveRow
                                                                    If Trim(SSGRID.Text) = "Y" Then
                                                                        SSGRID.SetActiveCell(2, SSGRID.ActiveRow)
                                                                    Else
                                                                        SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                                                    End If
                                                                Else
                                                                    SSGRID.Col = 5
                                                                    SSGRID.Col = 7
                                                                    SSGRID.Text = "0.00"
                                                                    SSGRID.Col = 19
                                                                    SSGRID.Row = SSGRID.ActiveRow
                                                                    If Trim(SSGRID.Text) = "Y" Then
                                                                        SSGRID.SetActiveCell(2, SSGRID.ActiveRow)
                                                                    Else
                                                                        SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                                                                    End If

                                                                End If

                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If

                                        CHECK_AVAILABILITY = STOCKAVAILABILITY(SSGRID, i)
                                        If CHECK_AVAILABILITY = 0 Then
                                            If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                SSGRID.ClearRange(2, i, SSGRID.MaxCols, i, True)
                                                SSGRID.Focus()
                                                SSGRID.SetActiveCell(1, i)
                                                Exit Sub
                                            End If
                                        ElseIf CHECK_AVAILABILITY = 1 Then
                                            If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                                SSGRID.Col = 5
                                                SSGRID.Text = ""
                                                SSGRID.SetActiveCell(5, i)
                                                SSGRID.Focus()
                                                Exit Sub
                                            End If
                                        End If
                                        '''************************************************************************************************
                                        Call Calculate()
                                        If boolPromotional = True Then
                                            SSGRID.Row = SSGRID.ActiveRow + 1
                                        Else
                                            SSGRID.Row = SSGRID.ActiveRow + 1
                                        End If
                                        SSGRID.Col = 1
                                        SSGRID.Lock = False
                                        SSGRID.Col = 2
                                        SSGRID.Lock = False
                                        SSGRID.Col = 3
                                        SSGRID.Lock = False
                                        SSGRID.Col = 4
                                        SSGRID.Lock = False
                                        SSGRID.Col = 5
                                        SSGRID.Lock = False
                                        SSGRID.Col = 6
                                        SSGRID.Lock = False
                                        If boolPromotional = True Then
                                            If PROMAMT > 0 Then
                                                SSGRID.SetActiveCell(1, SSGRID.ActiveRow)
                                            Else
                                                SSGRID.SetActiveCell(1, SSGRID.ActiveRow + 1)
                                            End If
                                        Else
                                            SSGRID.SetActiveCell(1, SSGRID.ActiveRow + 1)
                                        End If
                                        SSGRID.Col = 1
                                        SSGRID.Lock = False
                                        SSGRID.Col = 2
                                        SSGRID.Lock = False
                                        SSGRID.Col = 3
                                        SSGRID.Lock = False
                                        SSGRID.Col = 4
                                        SSGRID.Lock = False
                                        SSGRID.Col = 5
                                        SSGRID.Lock = False
                                        SSGRID.Col = 6
                                        SSGRID.Lock = False
                                        If boolPromotional = True Then
                                            SSGRID.SetActiveCell(1, SSGRID.ActiveRow)
                                            SSGRID.Focus()
                                        End If
                                        'boolPromotional = False
                                    End If
                                End If
                            End If
                        End If
                    End If
                ElseIf SSGRID.ActiveCol = 7 Then
                    SSGRID.Col = 7
                    SSGRID.Row = SSGRID.ActiveRow
                    If SSGRID.Lock = False Then
                        SSGRID.Col = 2
                        SSGRID.Row = SSGRID.ActiveRow
                        If Trim(SSGRID.Text) <> "" Then
                            SSGRID.Col = 7
                            SSGRID.Row = SSGRID.ActiveRow
                            If Val(SSGRID.Text) = 0 Then
                                SSGRID.SetActiveCell(6, SSGRID.ActiveRow)
                                Exit Sub
                            Else
                                Call Calculate()
                                SSGRID.Row = SSGRID.ActiveRow + 1
                                SSGRID.Col = 1
                                SSGRID.Lock = False
                                SSGRID.Col = 2
                                SSGRID.Lock = False
                                SSGRID.Col = 3
                                SSGRID.Lock = False
                                SSGRID.Col = 4
                                SSGRID.Lock = False
                                SSGRID.Col = 5
                                SSGRID.Lock = False
                                SSGRID.Col = 6
                                SSGRID.Lock = False
                                SSGRID.SetActiveCell(1, SSGRID.ActiveRow + 1)
                            End If
                        End If
                    End If
                End If
            ElseIf e.keyCode = Keys.F3 Then
                SSGRID.Col = 1
                SSGRID.Row = SSGRID.ActiveRow
                If SSGRID.Lock = False Then
                    SSGRID.Col = 4
                    SSGRID.Row = SSGRID.ActiveRow
                    If SSGRID.ActiveCol = 4 Then
                        If SSGRID.Lock = False Then
                            Itemcode = Nothing
                            i = SSGRID.ActiveRow
                            SSGRID.Col = 2
                            SSGRID.Row = i
                            Itemcode = Trim(SSGRID.Text)

                            Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER JOIN POSMASTER M ON P.POS=M.POSCODE WHERE P.ITEMCODE='" & Trim(Itemcode) & "' ORDER BY POSCODE"
                            GCONNECTION.getDataSet(Sqlstring, "POSMENULINK")
                            If gdataset.Tables("POSMENULINK").Rows.Count > 0 Then
                                If gdataset.Tables("POSMENULINK").Rows.Count > 1 Then
                                    SSGRID.Col = 4
                                    SSGRID.Row = i
                                    Call FillPosList(gdataset.Tables("PosMenuLink"))
                                    Me.lvw_POSCode.FullRowSelect = True
                                    pnl_POSCode.Top = 50
                                    pnl_POSCode.Focus()
                                    lvw_POSCode.Focus()
                                Else
                                    SSGRID.Col = 4
                                    SSGRID.Row = SSGRID.ActiveRow
                                    SSGRID.Text = gdataset.Tables("POSMENULINK").Rows(0).Item(0)
                                    SSGRID.SetActiveCell(6, SSGRID.ActiveRow)
                                End If
                            Else
                                SSGRID.Col = 2
                                SSGRID.Row = SSGRID.ActiveRow
                                SSGRID.Focus()
                            End If
                        End If
                    ElseIf SSGRID.ActiveCol = 5 Then
                        SSGRID.Col = 5
                        SSGRID.Row = SSGRID.ActiveRow
                        If SSGRID.Lock = False Then
                            Itemcode = Nothing
                            i = SSGRID.ActiveRow
                            SSGRID.Col = 2
                            SSGRID.Row = i
                            Itemcode = Trim(SSGRID.Text)
                            Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                            Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) "
                            GCONNECTION.getDataSet(Sqlstring, "ITEMRATE")
                            If gdataset.Tables("ITEMRATE").Rows.Count > 0 Then
                                If gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                                    SSGRID.Col = 5
                                    SSGRID.Row = i
                                    Call FillUomList(gdataset.Tables("ITEMRATE"))
                                    Me.lvw_Uom.FullRowSelect = True
                                    pnl_UOMCode.Top = 50
                                    Me.lvw_Uom.Focus()

                                Else
                                    SSGRID.Col = 5
                                    SSGRID.Row = SSGRID.ActiveRow
                                    SSGRID.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")
                                    SSGRID.Col = 7
                                    SSGRID.Row = SSGRID.ActiveRow
                                    SSGRID.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")
                                    SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                End If
                            Else
                                SSGRID.Col = 2
                                SSGRID.Row = SSGRID.ActiveRow
                                SSGRID.Focus()
                            End If
                        End If
                    ElseIf SSGRID.ActiveCol = 2 Or SSGRID.ActiveCol = 6 Or SSGRID.ActiveCol = 1 Then

                        If Mid(Me.Cmd_Add.Text, 1, 1) <> "U" Then
                            SSGRID.Row = SSGRID.ActiveRow
                            SSGRID.ClearRange(1, SSGRID.ActiveRow, 15, SSGRID.ActiveRow, True)
                            SSGRID.DeleteRows(SSGRID.ActiveRow, 1)
                            'Call Calculate()
                            SSGRID.Row = SSGRID.ActiveRow
                            SSGRID.Col = 1
                            SSGRID.Lock = False
                            SSGRID.Col = 2
                            SSGRID.Lock = False
                            SSGRID.Col = 3
                            SSGRID.Lock = False
                            SSGRID.Col = 4
                            SSGRID.Lock = False
                            SSGRID.Col = 5
                            SSGRID.Lock = False
                            SSGRID.Col = 6
                            SSGRID.Lock = False
                            SSGRID.SetActiveCell(1, SSGRID.ActiveRow)
                        End If

                    End If
                End If
            End If

            If e.keyCode = Keys.F3 Then
                With SSGRID
                    .Row = .ActiveRow
                    .DeleteRows(.ActiveRow, 1)
                    If .ActiveRow <= 1 Then
                        .SetActiveCell(1, .ActiveRow)
                    Else
                        .SetActiveCell(1, .ActiveRow - 1)
                    End If
                End With
            End If
            Call GridLockRate()

        Catch ex As Exception

        End Try

    End Sub
    Private Sub FillMenu()
        Dim vform As New LIST_OPERATION1
        Dim ssql, COMPNAME As String
        Dim k, cct As Integer
        cct = 0
        Dim itc As String
        ssql = "SELECT ISNULL(COMPNAME,'')AS COMPNAME FROM POSSETUP "
        gconnection.getDataSet(ssql, "COMP")
        If gdataset.Tables("COMP").Rows.Count > 0 Then
            COMPNAME = gdataset.Tables("COMP").Rows(0).Item("COMPNAME")
        End If
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO sSGrid ********** 
        gSQLString = "SELECT DISTINCT I.ITEMCODE,I.ITEMDESC,I.BASERATESTD,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE, '' "
        gSQLString = gSQLString & " AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.subGroupCode,'') AS subGroupCode,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN,ISNULL(I.OPENFACILITY,'')AS OPENFACILITY FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode INNER "
        If gCenterlized = "Y" Then
            gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
        Else
            gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
        End If

        If Trim(Search) = " " Then
            If gCenterlized = "Y" Then
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink)"
            Else
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "')"
            End If
        Else
            If gCenterlized = "Y" Then
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink) AND (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            Else
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "' ) and (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            End If
        End If
        vform.Field = "I.ITEMDESC,I.ITEMCODE"
        'vform.vFormatstring = "ITEMCODE     |ITEM DESCRIPTION                       |  BASERATESTD  |  ITEMTYPE  |  TAXCODE  | TAXPERCENTAGE | ACCOUNTCODE |  GROUPCODE  |  SUBGROUPCODE  |SALESACCTIN|OPENFACILITY|"
        vform.vCaption = "ITEM CODE HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        'vform.Keypos3 = 3
        'vform.keypos4 = 4
        'vform.Keypos5 = 5
        'vform.Keypos6 = 6
        'vform.Keypos7 = 7
        'vform.Keypos8 = 8
        'vform.keypos9 = 9
        'vform.Keypos10 = 10
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With sSGrid
                .Col = 2
                .Row = .ActiveRow
                .Text = vform.keyfield
                .Col = 3
                .Row = .ActiveRow
                .Text = vform.keyfield1
                .Col = 10
                .Row = .ActiveRow
                .Text = vform.keyfield3
                .Col = 11
                .Row = .ActiveRow
                .Text = vform.keyfield4
                .Col = 12
                .Row = .ActiveRow
                .Text = vform.keyfield5
                .Col = 14
                .Row = .ActiveRow
                .Text = vform.keyfield6
                .Col = 16
                .Row = .ActiveRow
                .Text = vform.keyfield7
                .Col = 17
                .Row = .ActiveRow
                .Text = vform.keyfield8
                .Col = 18
                .Row = .ActiveRow
                .Text = vform.keyfield9
                .Col = 19
                .Row = .ActiveRow
                .Text = vform.keyfield10
            End With
        Else
            sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
            Exit Sub
        End If
        If Trim(sSGrid.Text) <> "" Then
            sSGrid.GetText(2, sSGrid.ActiveRow, itc)
            For k = 1 To sSGrid.DataRowCnt
                sSGrid.Col = 2
                sSGrid.Row = k
                If Trim(sSGrid.Text) = itc Then
                    cct = cct + 1
                    'MsgBox("duplicate item entry")
                    'Exit For
                End If

            Next
        End If
        If cct > 1 Then
            MsgBox("duplicate item entry")
        End If
        ' End If
        If Trim(vform.keyfield) <> "" Then
            '''*********************************************** $ FILL POSCODE INTO sSGrid $ *********************************************'''
            '''
            If gCenterlized = "Y" Then
                SQLSTRING = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(vform.keyfield) & "' AND ISNULL(M.FREEZE,'') <>'Y' "
            Else
                SQLSTRING = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(vform.keyfield) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(STRPOSCODE) & "'"
            End If
            gconnection.getDataSet(SQLSTRING, "PosMenuLink")

            If gdataset.Tables("PosMenuLink").Rows.Count > 1 Then
                '''***************************************** $ SHOW POPUP FOR VARIOUS UOM $ ******************************************************''
                Call FillPosList(gdataset.Tables("PosMenuLink"))
                Me.lvw_POSCode.FullRowSelect = True
                pnl_POSCode.Top = 50
                lvw_POSCode.Focus()
                Exit Sub
                'sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
            Else
                sSGrid.Col = 4
                sSGrid.Row = sSGrid.ActiveRow
                sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item(0)
                'If IsDBNull(gdataset.Tables("PosMenuLink").Rows(0).Item(2)) = False Then
                '    If Trim((gdataset.Tables("PosMenuLink").Rows(0).Item(2))) <> "" Then
                '        sSGrid.Col = 14
                '        sSGrid.Row = sSGrid.ActiveRow
                '        If sSGrid.Text = "" Then
                '            sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item(2)
                '        End If
                '    Else
                '        MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                '        Exit Sub
                '    End If
                'Else
                '    MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                '    Exit Sub
                'End If
                sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
            End If
            '''************************************************* $ FILL UOM , RATE INTO sSGrid $ **************************************************'''
            gSQLString = "SELECT DISTINCT ISNULL(R.UOM,'') AS UOM, ISNULL(R.ITEMRATE,0) AS ITEMRATE "
            gSQLString = gSQLString & " FROM VIEW_ITEMMASTER AS I INNER JOIN "
            gSQLString = gSQLString & " RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
            gSQLString = gSQLString & "WHERE '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(vform.keyfield) & "' ) "
            gconnection.getDataSet(gSQLString, "ITEMRATE")
            If gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                Call FillUomList(gdataset.Tables("ITEMRATE"))
                If sSGrid.ActiveCol = 6 Then
                    '''***************************************** $ SHOW POPUP FOR VARIOUS UOM $ ******************************************************''
                    Me.lvw_Uom.FullRowSelect = True
                    pnl_UOMCode.Top = 50
                    Me.lvw_Uom.Focus()
                    '''***************************************** $ COMPLETE POPUP FOR VARIOUS UOM $ ******************************************************''
                End If
            Else
                sSGrid.Col = 5
                sSGrid.Row = sSGrid.ActiveRow
                sSGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")
                sSGrid.Col = 7
                sSGrid.Row = sSGrid.ActiveRow
                'If Val(PACKINGPERCENT) <> 0 Then
                '    sSGrid.Text = Math.Round(Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) + (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                'Else
                sSGrid.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")
                'End If
                sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
            End If
            '''**************************************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''

            gSQLString = "SELECT promitemcode,VIEW_ITEMMASTER.itemdesc,promotional,promuom,promqty,promrate, "
            gSQLString = gSQLString & "posmenulink.pos FROM VIEW_ITEMMASTER INNER JOIN posmenulink on VIEW_ITEMMASTER.itemcode=posmenulink.itemcode "
            gSQLString = gSQLString & "WHERE VIEW_ITEMMASTER.itemcode='" & vform.keyfield & "' "
            gconnection.getDataSet(gSQLString, "Promotional")

            If Trim(gdataset.Tables("Promotional").Rows(0).Item("Promotional")) = "Y" Then
                gSQLString = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                gSQLString = gSQLString & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                gSQLString = gSQLString & " POSMASTER AS P ON PL.POS = P.POSCODE "
                gSQLString = gSQLString & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                gSQLString = gSQLString & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & gdataset.Tables("Promotional").Rows(0).Item("promitemcode") & "') AND (I.ITEMCODE = '" & vform.keyfield & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                gconnection.getDataSet(gSQLString, "Promotional")
                If gdataset.Tables("Promotional").Rows.Count > 0 Then
                    If MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                        If CDate(gdataset.Tables("Promotional").Rows(0).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("Promotional").Rows(0).Item("StartingDate")) >= CDate(Now.Today) Then
                            sSGrid.SetText(2, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromItemcode")) & "")
                            sSGrid.SetText(3, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemDesc")) & "")
                            sSGrid.SetText(4, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("POSCode")) & "")
                            sSGrid.SetText(5, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromUOM")) & "")
                            sSGrid.SetText(6, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromQty")) & "")
                            sSGrid.SetText(7, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(8, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(9, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(10, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemTypecode")) & "")

                            sSGrid.SetText(12, sSGrid.ActiveRow + 1, 0.0)
                            boolPromotional = True
                            sSGrid.SetText(19, sSGrid.ActiveRow + 1, "Y")
                        End If
                    End If
                End If
            End If
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub FillMenuItem()
        Dim vform As New LIST_OPERATION1
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMDESC,ITEMCODE INTO sSGrid ********** 
        gSQLString = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.BASERATESTD,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE, '' "
        gSQLString = gSQLString & " AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN,ISNULL(I.OPENFACILITY,'')AS OPENFACILITY FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode INNER "
        If gCenterlized = "Y" Then
            gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE "
        Else
            gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
        End If

        If Trim(Search) = " " Then
            If gCenterlized = "Y" Then
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink )"
            Else
                M_WhereCondition = "where i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "')"
            End If
        Else
            If gCenterlized = "Y" Then
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink ) and (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            Else
                M_WhereCondition = " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "' ) and (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND  ISNULL(I.FREEZE,'') <>'Y' "
            End If
        End If
        vform.Field = "I.ITEMDESC,I.ITEMCODE"
        'vform.vFormatstring = "              ITEMDESC            |     ITEMCODE     | RATE    |  ITEMTYPE  |  TAXCODE  | TAXPERCENTAGE | TAX.ACCOUNTCODE |  GROUPCODE  |  SUBGROUPCODE  | OPENFACILITY | SALESACCTIN|"
        vform.vCaption = "ITEM DESC HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        'vform.Keypos3 = 3
        'vform.keypos4 = 4
        'vform.Keypos5 = 5
        'vform.Keypos6 = 6
        'vform.Keypos7 = 7
        'vform.Keypos8 = 8
        'vform.keypos9 = 9
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With sSGrid
                .Col = 2
                .Row = .ActiveRow
                .Text = CStr(vform.keyfield1)
                .Col = 3
                .Row = .ActiveRow
                .Text = CStr(vform.keyfield)
                .Col = 10
                .Row = .ActiveRow
                .Text = vform.keyfield3
                .Col = 11
                .Row = .ActiveRow
                .Text = vform.keyfield4
                .Col = 12
                .Row = .ActiveRow
                .Text = vform.keyfield5
                .Col = 14
                .Row = .ActiveRow
                .Text = vform.keyfield6
                .Col = 15
                .Row = .ActiveRow
                .Text = vform.keyfield8
                .Col = 16
                .Row = .ActiveRow
                .Text = vform.keyfield7
                .Col = 19
                .Row = .ActiveRow
                .Text = vform.keyfield10

                If Trim(CStr(vform.keyfield7)) = "Y" Then
                    sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                Else
                    sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                End If
                'End
            End With
        Else
            sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
            Exit Sub
        End If
        If Trim(vform.keyfield1) <> "" Then
            '''*********************************************** $ FILL POSCODE INTO sSGrid $ ********************************************************'''
            If gCenterlized = "Y" Then
                ssql = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER JOIN POSMASTER M ON P.POS=M.POSCODE WHERE ITEMCODE='" & vform.keyfield1 & "'AND ISNULL(M.FREEZE,'')<>'Y' ORDER BY POSCODE"
            Else
                ssql = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER JOIN POSMASTER M ON P.POS=M.POSCODE WHERE ITEMCODE='" & vform.keyfield1 & "'AND ISNULL(M.FREEZE,'')<>'Y' AND P.POS='" & Trim(STRPOSCODE) & "' ORDER BY POSCODE"
            End If
            gconnection.getDataSet(ssql, "POSMENULINK")
            If gdataset.Tables("PosMenuLink").Rows.Count > 1 Then
                '''***************************************** $ SHOW POPUP FOR VARIOUS POS LOC $ ******************************************************''
                Call FillPosList(gdataset.Tables("POSMENULINK"))
                Me.lvw_POSCode.FullRowSelect = True
                pnl_POSCode.Top = 50
                lvw_POSCode.Focus()
                sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                Exit Sub
            Else
                sSGrid.Col = 4
                sSGrid.Row = sSGrid.ActiveRow
                sSGrid.Text = gdataset.Tables("POSMENULINK").Rows(0).Item(0)
                'If IsDBNull(gdataset.Tables("POSMENULINK").Rows(0).Item(2)) = False Then
                '    If Trim((gdataset.Tables("POSMENULINK").Rows(0).Item(2))) <> "" Then
                '        sSGrid.Col = 14
                '        sSGrid.Row = sSGrid.ActiveRow
                '        ''sSGrid.Text = gdataset.Tables("POSMENULINK").Rows(0).Item(2)
                '        ''sSGrid.Text = vform.keyfield8
                '    Else
                '        MsgBox("Account Code For The Location  " & gdataset.Tables("POSMENULINK").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                '        sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                '        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                '        Exit Sub
                '    End If
                'Else
                '    MsgBox("Account Code For The Location  " & gdataset.Tables("POSMENULINK").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                '    sSGrid.ClearRange(1, sSGrid.ActiveRow, 15, sSGrid.ActiveRow, True)
                '    sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                '    Exit Sub
                'End If
                sSGrid.SetActiveCell(5, sSGrid.ActiveRow)
            End If
            '''************************************************* $ FILL UOM , RATE INTO sSGrid $ **************************************************'''
            gSQLString = "SELECT DISTINCT R.UOM, R.ItemRate "
            gSQLString = gSQLString & "FROM VIEW_ITEMMASTER AS I INNER JOIN "
            gSQLString = gSQLString & "RateMaster AS R ON I.ItemCode = R.ItemCode "
            gSQLString = gSQLString & "WHERE '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND (I.ItemCode = '" & Trim(vform.keyfield1) & "' ) AND ISNULL(I.freeze,'')<>'Y' "
            gconnection.getDataSet(gSQLString, "ItemRate")
            If gdataset.Tables("ItemRate").Rows.Count > 1 Then
                Call FillUomList(gdataset.Tables("ItemRate"))
                If sSGrid.ActiveCol = 6 Then
                    '''***************************************** $ SHOW POPUP FOR VARIOUS UOM $ ******************************************************''
                    Me.lvw_Uom.FullRowSelect = True
                    pnl_UOMCode.Top = 50
                    Me.lvw_Uom.Focus()
                End If
            Else
                sSGrid.Col = 5
                sSGrid.Row = sSGrid.ActiveRow
                sSGrid.Text = gdataset.Tables("ItemRate").Rows(0).Item("UOM")
                sSGrid.Col = 7
                sSGrid.Row = sSGrid.ActiveRow
                'If Val(PACKINGPERCENT) <> 0 Then
                '    sSGrid.Text = Math.Round(Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) + (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                'Else
                sSGrid.Text = gdataset.Tables("ItemRate").Rows(0).Item("ItemRate")
                'End If
                sSGrid.SetActiveCell(6, sSGrid.ActiveRow)
            End If
            '''**************************************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
            gSQLString = "SELECT promitemcode,VIEW_ITEMMASTER.itemdesc,ISNULL(promotional,'') AS promotional,promuom,promqty,promrate, "
            gSQLString = gSQLString & " posmenulink.pos FROM VIEW_ITEMMASTER INNER JOIN posmenulink on VIEW_ITEMMASTER.itemcode=posmenulink.itemcode "
            gSQLString = gSQLString & "WHERE VIEW_ITEMMASTER.itemcode='" & vform.keyfield1 & "' AND ISNULL(VIEW_ITEMMASTER.freeze,'')<>'Y'"
            gconnection.getDataSet(gSQLString, "Promotional")
            If Trim(gdataset.Tables("Promotional").Rows(0).Item("Promotional")) = "Y" Then

                gSQLString = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                gSQLString = gSQLString & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                gSQLString = gSQLString & " POSMASTER AS P ON PL.POS = P.POSCODE "
                gSQLString = gSQLString & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                gSQLString = gSQLString & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & gdataset.Tables("Promotional").Rows(0).Item("promitemcode") & "') AND (I.ITEMCODE = '" & vform.keyfield & "') AND ISNULL(I.FREEZE,'') <>'Y' "

                gconnection.getDataSet(gSQLString, "Promotional")
                If gdataset.Tables("Promotional").Rows.Count > 0 Then
                    If MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                        If CDate(gdataset.Tables("Promotional").Rows(0).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("Promotional").Rows(0).Item("StartingDate")) >= CDate(Now.Today) Then
                            sSGrid.SetText(2, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromItemcode")) & "")
                            sSGrid.SetText(3, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemDesc")) & "")
                            sSGrid.SetText(4, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("POSCode")) & "")
                            sSGrid.SetText(5, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromUOM")) & "")
                            sSGrid.SetText(6, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromQty")) & "")
                            sSGrid.SetText(7, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(8, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(9, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(10, sSGrid.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemTypecode")) & "")
                            sSGrid.SetText(12, sSGrid.ActiveRow + 1, 0.0)
                            sSGrid.SetText(19, sSGrid.ActiveRow + 1, "Y")
                            boolPromotional = True
                            'End
                        End If
                    End If
                End If
            End If
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub FillPosList(ByVal PosTable As DataTable)
        Dim lvw As New ListViewItem
        Dim i As Integer
        lvw_POSCode.Items.Clear()
        For i = 0 To PosTable.Rows.Count - 1
            lvw = lvw_POSCode.Items.Add(PosTable.Rows(i).Item(0))
            lvw.SubItems.Add(PosTable.Rows(i).Item(1))
            lvw.SubItems.Add(PosTable.Rows(i).Item(2))
        Next i
    End Sub
    Private Sub FillUomList(ByVal UomTable As DataTable)
        Dim lvw As New ListViewItem
        Dim i As Integer
        lvw_Uom.Items.Clear()
        For i = 0 To UomTable.Rows.Count - 1
            lvw = lvw_Uom.Items.Add(UomTable.Rows(i).Item("UOM"))
            lvw.SubItems.Add(UomTable.Rows(i).Item("ITEMRATE"))
        Next i
    End Sub

    Private Sub GridLockRate()
        Dim Row, Col As Integer
        sSGrid.Col = 7
        sSGrid.Row = sSGrid.ActiveRow
        For Row = 1 To 100
            sSGrid.Col = 19
            sSGrid.Row = Row
            If Trim(sSGrid.Text) = "Y" Then
                For Col = 7 To 7
                    sSGrid.Row = Row
                    sSGrid.Col = Col
                    sSGrid.Lock = False
                Next
            Else
                For Col = 7 To 9
                    sSGrid.Row = Row
                    sSGrid.Col = Col
                    sSGrid.Lock = True
                Next
            End If
        Next
    End Sub
    Private Sub Calculate()
        Dim qty, taxperc, cancel, kotstatus, rate, varposcode As String
        Dim total, Taxamount, cancelamt, canceltax, Billamount, Packingamt, TIPSAMT As Double
        Dim i As Integer
        With sSGrid
            '   If .ActiveCol = 5 Or .ActiveCol = 4 Or .ActiveCol = 1 Then
            'Me.txt_TaxValue.Text = "0.00"
            'Me.txt_TotalValue.Text = "0.00"
            'Me.Txt_PackingValue.Text = "0.00"
            'Me.txt_BillAmount.Text = "0.00"
            For i = 1 To .DataRowCnt
                sSGrid.Row = i
                sSGrid.Col = 4
                .Col = 13
                .Row = i
                kotstatus = .Text
                If Trim(kotstatus) = "NO" Or Trim(kotstatus) = "" Then
                    .Col = 6
                    .Row = i
                    qty = .Text
                    .Col = 7
                    .Row = i
                    rate = .Text
                    .Col = 12
                    .Row = i
                    taxperc = Val(.Text)
                    If Val(rate) > 0 Then
                        total = (Val(qty) * Val(rate))
                    Else
                        total = 0
                    End If
                    Taxamount = (total) * (taxperc / 100)
                    .SetText(9, i, total)
                    .SetText(8, i, Taxamount)
                    'Billamount = Format(Val(Me.txt_TaxValue.Text) + Val(Me.txt_TotalValue.Text) + Val(Me.txt_TaxValue.Text) + Val(Me.TXT_TIPS.Text), "0.00")
                    'If BILLROUNDYESNO = "YES" Then
                    '    Me.txt_BillAmount.Text = Format(Math.Round(Billamount), "0.00")
                    'Else
                    '    Me.txt_BillAmount.Text = Format(Billamount, "0.00")
                    'End If
                End If
            Next i
            '+ Val(Me.Txt_PackingValue.Text)
            '+ Val(txt_sertax_value.Text)
            'txt_sertax_value.Text = Format(((Val(Me.txt_TotalValue.Text) * PACKINGPERCENT) / 100), "0.00")
            'Me.TXT_TIPS.Text = Format(((Val(Me.txt_TotalValue.Text) * TIPSPERCENT) / 100), "0.00")
            'Billroundoff = Val(Me.txt_TaxValue.Text) + Val(Me.txt_TotalValue.Text) + Val(txt_sertax_value.Text) + Val(Me.TXT_TIPS.Text)
            'If BILLROUNDYESNO = "YES" Then
            '    Me.txt_BillAmount.Text = Format(Math.Round(Billroundoff), "0.00")
            'Else
            '    Me.txt_BillAmount.Text = Format(Billroundoff, "0.00")
            'End If

            'End If
        End With
        i = i - 1
        Call CheckBillAmt()
    End Sub

    Private Sub CheckBillAmt()
        Dim j, Qty As Integer
        Dim TotAmt, TotTaxAmt, TotBillAmt As Double
        Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
        Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB As Double
        Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, ITEMCODE As String
        Dim TPercent As Double
        Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt, TotCharges As Double
        GrdAmount = 0
        'For i = 1 To sSGrid.DataRowCnt
        '    With sSGrid
        '        .Col = 9
        '        .Row = i
        '        GrdAmount = GrdAmount + Val(.Text)
        '    End With
        'Next
        For i = 1 To sSGrid.DataRowCnt
            Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
            GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
            With sSGrid
                .Col = 2
                .Row = i
                ITEMCODE = Trim(.Text)
                .Col = 7
                .Row = i
                GrdRate = Val(.Text)
                .Col = 6
                .Row = i
                Qty = Val(.Text)
                .Col = 10
                .Row = i
                ChargeCode = Trim(.Text)
                SQLSTRING = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                gconnection.getDataSet(SQLSTRING, "CODE_CHECK")
                If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                    ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                End If
                SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                gconnection.getDataSet(SQLSTRING, "TAXON")
                If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                    For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                        If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                            Zero = (GrdRate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZero = GZero + Zero
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                            ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroA = GZeroA + ZeroA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                            ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroB = GZeroB + ZeroB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                            One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOne = GOne + One
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                            OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneA = GOneA + OneA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                            OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneB = GOneB + OneB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                            Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwo = GTwo + Two
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                            TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoA = GTwoA + TwoA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                            TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoB = GTwoB + TwoB
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                            Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThree = GThree + Three
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                            ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeA = GThreeA + ThreeA
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                            ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeB = GThreeB + ThreeB
                        End If
                    Next
                    GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                End If
                TotAmt = TotAmt + (Val(GrdRate) * Qty)
                TotTaxAmt = 0.0
                TotTaxAmt = TotTaxAmt + (Val(GrdTaxAmt) * Qty)
                .SetText(8, I, Format(TotTaxAmt, "0.00"))

                TotBillAmt = TotBillAmt + ((Val(GrdTaxAmt) * Qty) + (Val(GrdRate) * Qty))
            End With
        Next
        'GrdAmount = GrdAmount + TotTaxAmt
        '' txt_TotalValue.Text = Format(TotAmt, "0.00")
        '' txt_TaxValue.Text = Format(TotTaxAmt, "0.00")
        'TotCharges = 0
        'For i = 1 To sSGrid.DataRowCnt
        '    With sSGrid
        '        .Col = 2
        '        .Row = i
        '        ITEMCODE = Trim(.Text)
        '        .Col = 6
        '        .Row = i
        '        Qty = Val(.Text)
        '        .Col = 9
        '        .Row = i
        '        GAmt = Val(.Text)
        '        If gCenterlized = "Y" Then
        '            TPackAmt = Val((GAmt * gPackPer) / 100)
        '            TTipsAmt = Val((GAmt * gTipsPer) / 100)
        '            TAdchgAmt = Val((GAmt * gAdCgsPer) / 100)
        '            'TPartyAmt = Val((GAmt * gPartyPer) / 100)
        '            'TRoomAmt = Val((GAmt * gRoomPer) / 100)

        '            TPartyAmt = Val((GAmt * gPartyPer) / 100)

        '        Else
        '        TPackAmt = Val((GAmt * pPackPer) / 100)
        '        TTipsAmt = Val((GAmt * pTipsPer) / 100)
        '        TAdchgAmt = Val((GAmt * pAdCgsPer) / 100)
        '        'TPartyAmt = Val((GAmt * pPartyPer) / 100)
        '        'TRoomAmt = Val((GAmt * pRoomPer) / 100)

        '        TPartyAmt = Val((GAmt * pPartyPer) / 100)
        '        'PartyPer = gPartyPer

        '        End If
        '        GrdAmount = GrdAmount + (TPackAmt + TTipsAmt + TAdchgAmt + TPartyAmt + TRoomAmt)
        '        TotCharges = TotCharges + (TPackAmt + TTipsAmt + TAdchgAmt + TPartyAmt + TRoomAmt)
        '    End With
        'Next
        ' Txt_Charges.Text = Format(TotCharges, "0.00")
        ' txt_BillAmount.Text = Format(GrdAmount, "0.00")
    End Sub


    Private Sub SSGRID_MENU_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles SSGRID.LeaveCell
        Dim Sqlstring, Itemcode, Itemdesc, Promtcode, UOMCODE, itc As String
        Dim varitemcode, varitemdesc, varposcode As String
        Dim RATE As Double
        Dim i, j, k, cct As Integer
        cct = 0
        Dim qty As String
        Call Calculate()
        Try
            i = SSGRID.ActiveRow
            If SSGRID.ActiveCol = 2 Then
                SSGRID.Col = 2
                SSGRID.Row = i
                'If sSGrid.Lock = False Then
                If Trim(SSGRID.Text) <> "" Then
                    SSGRID.GetText(2, i, itc)
                    For k = 1 To SSGRID.DataRowCnt
                        SSGRID.Col = 1
                        SSGRID.Row = k
                        If Trim(SSGRID.Text) = itc Then
                            cct = cct + 1
                            'MsgBox("duplicate item entry")
                            'Exit For
                        End If

                    Next
                End If
                'End If
                If cct > 1 Then
                    MsgBox("duplicate item entry")
                End If
            ElseIf SSGRID.ActiveCol = 3 Then
                SSGRID.Col = 2
                SSGRID.Row = i
                If SSGRID.Lock = False Then
                    If Trim(SSGRID.Text) <> "" Then
                        Itemcode = Trim(SSGRID.Text)
                        Sqlstring = "SELECT ITEMDESC FROM ITEMMASTER WHERE ITEMCODE='" & Itemcode & "'"
                        GCONNECTION.getDataSet(Sqlstring, "RR")
                        If gdataset.Tables("RR").Rows.Count > 0 Then
                            SSGRID.Col = 3
                            SSGRID.Row = i
                            SSGRID.Text = Trim(gdataset.Tables("RR").Rows(0).Item("Itemdesc"))
                        Else
                            MsgBox("ITEMNAME NOT FOUND")
                            SSGRID.Col = 3
                            SSGRID.Row = i
                            SSGRID.Text = ""
                        End If
                        SSGRID.Col = 4
                        SSGRID.Row = i
                        If Trim(SSGRID.Text) = "" Then
                            SSGRID.Row = i
                            SSGRID.Col = 3
                            varitemdesc = Trim(SSGRID.Text)
                            SSGRID.Col = 4
                            varposcode = Trim(SSGRID.Text)
                            SSGRID.Col = 2
                            Itemcode = Trim(SSGRID.Text)
                            If Trim(varitemdesc) = "" And Trim(varposcode) = "" Then
                                '''****************************** $ TO fill ITEMCODE,ITEMDESC,ITEMTYPE  $ **************************************'''
                                Sqlstring = "SELECT DISTINCT I.ITEMDESC,I.ITEMCODE,I.ITEMTYPECODE,'' AS TAXCODE,0 AS TAXPERCENTAGE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,"
                                Sqlstring = Sqlstring & " '' AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE,ISNULL(I.PROMOTIONAL,'') AS PROMOTIONAL,I.PROMITEMCODE FROM VIEW_ITEMMASTER AS I INNER JOIN CHARGEMASTER AS CH ON CH.CHARGECODE = I.ItemTypecode"
                                Sqlstring = Sqlstring & " INNER JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = CH.TAXTYPECODE INNER JOIN POSMENULINK AS PL ON PL.ITEMCODE = I.ITEMCODE INNER JOIN POSMASTER AS P ON PL.POS = P.POSCODE AND P.POSCODE  = '" & Trim(STRPOSCODE) & "' "
                                Sqlstring = Sqlstring & " WHERE i.itemcode in(select itemcode from posmenulink where poscode='" & Trim(STRPOSCODE) & "') and I.ITEMDESC = '" & Trim(Itemdesc) & "' AND '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "')  AND ISNULL(I.FREEZE,'') <>'Y'"
                                GCONNECTION.getDataSet(Sqlstring, "ITEMCODE")
                                If gdataset.Tables("ITEMCODE").Rows.Count > 0 Then
                                    SSGRID.SetText(2, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMCODE")) & "")
                                    SSGRID.SetText(3, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMDESC")) & "")
                                    SSGRID.SetText(10, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ITEMTYPECODE")) & "")
                                    SSGRID.SetText(11, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("TAXCODE")) & "")
                                    SSGRID.SetText(12, i, Val(gdataset.Tables("ITE2MCODE").Rows(j).Item("TAXPERCENTAGE")))
                                    SSGRID.SetText(14, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("ACCOUNTCODE")))
                                    SSGRID.SetText(15, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("salesacctin")))
                                    SSGRID.SetText(16, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("GROUPCODE")))
                                    SSGRID.SetText(17, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("SUBGROUPCODE")))
                                    SSGRID.SetText(19, i, Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")))
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("OPENFACILITY")) = "Y" Then
                                        SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                                    Else
                                        SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                    End If


                                    '''*************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    If Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("Promotional")) = "Y" Then
                                        Promtcode = Trim(gdataset.Tables("ITEMCODE").Rows(j).Item("PromItemcode"))

                                        'Modified on 14 Mar'08
                                        'Mk Kannan
                                        'Begin
                                        'Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, I.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                        'Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                        'Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                        Sqlstring = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                                        Sqlstring = Sqlstring & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                                        Sqlstring = Sqlstring & " POSMASTER AS P ON PL.POS = P.POSCODE "
                                        Sqlstring = Sqlstring & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                                        Sqlstring = Sqlstring & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & Promtcode & "') AND (I.ITEMCODE = '" & Itemcode & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                                        'End

                                        GCONNECTION.getDataSet(Sqlstring, "PROMOTIONAL")
                                        If gdataset.Tables("PROMOTIONAL").Rows.Count > 0 Then
                                            If MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                                                If CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("PROMOTIONAL").Rows(j).Item("StartingDate")) >= CDate(Now.Today) Then
                                                    SSGRID.SetText(2, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMITEMCODE")) & "")
                                                    SSGRID.SetText(3, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMDESC")) & "")
                                                    SSGRID.SetText(4, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("POSCODE")) & "")
                                                    SSGRID.SetText(5, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMUOM")) & "")
                                                    SSGRID.SetText(6, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("PROMQTY")) & "")
                                                    SSGRID.SetText(7, i + 1, 0.0)
                                                    SSGRID.SetText(8, i + 1, 0.0)
                                                    SSGRID.SetText(9, i + 1, 0.0)
                                                    SSGRID.SetText(10, i + 1, Trim(gdataset.Tables("PROMOTIONAL").Rows(j).Item("ITEMTYPECODE")) & "")
                                                    SSGRID.SetText(12, i + 1, 0.0)
                                                    SSGRID.SetText(19, i + 1, "Y")
                                                    boolPromotional = True
                                                    'End
                                                End If
                                            End If
                                        End If
                                    End If
                                    '''*************************** $ COMPLETE PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''
                                    '''****************************** TO FILL POSCODE **********************************************************************'''
                                    Sqlstring = "SELECT POSCODE,POSDESC,'' AS SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(Itemcode) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
                                    GCONNECTION.getDataSet(Sqlstring, "PosMenuLink")
                                    If gdataset.Tables("PosMenuLink").Rows.Count = 1 Then
                                        SSGRID.Col = 4
                                        SSGRID.Row = SSGRID.ActiveRow
                                        SSGRID.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE")
                                        If IsDBNull(gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")) = False Then
                                            If Trim((gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN"))) <> "" Then
                                                SSGRID.Col = 15
                                                SSGRID.Row = SSGRID.ActiveRow
                                                ' sSGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item("SALESACCTIN")
                                            Else
                                                MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                                SSGRID.ClearRange(2, SSGRID.ActiveRow, 15, SSGRID.ActiveRow, True)
                                                SSGRID.SetActiveCell(2, SSGRID.ActiveRow)
                                                Exit Sub
                                            End If
                                        Else
                                            MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item("POSCODE") & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
                                            SSGRID.ClearRange(2, SSGRID.ActiveRow, 15, SSGRID.ActiveRow, True)
                                            SSGRID.SetActiveCell(2, SSGRID.ActiveRow)
                                            Exit Sub
                                        End If
                                        '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                        Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' ) "
                                        GCONNECTION.getDataSet(Sqlstring, "ITEMRATE")
                                        If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                                            SSGRID.Col = 5
                                            SSGRID.Row = SSGRID.ActiveRow
                                            SSGRID.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                                            SSGRID.Col = 7
                                            SSGRID.Row = SSGRID.ActiveRow
                                            'If Val(PACKINGPERCENT) <> 0 Then
                                            '    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                            '    '' + (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                                            'Else
                                            SSGRID.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                                            'End If
                                            ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            SSGRID.Col = 19
                                            SSGRID.Row = SSGRID.ActiveRow
                                            If Trim(SSGRID.Text) = "Y" Then
                                                SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                                            Else
                                                SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                            End If
                                        Else
                                            SSGRID.Col = 7
                                            SSGRID.Text = "0.00"
                                            SSGRID.Col = 5
                                            ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)
                                            SSGRID.Col = 19
                                            SSGRID.Row = SSGRID.ActiveRow
                                            If Trim(SSGRID.Text) = "Y" Then
                                                SSGRID.SetActiveCell(4, SSGRID.ActiveRow)
                                            Else
                                                SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                                            End If
                                        End If
                                        '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                                    Else
                                        '''******************************  SHOW A POPUP FOR POS LOCATION ***********************''
                                        Call FillPosList(gdataset.Tables("PosMenuLink"))
                                        Me.lvw_POSCode.FullRowSelect = True
                                        pnl_POSCode.Top = 50
                                        lvw_POSCode.Focus()
                                        Exit Sub
                                    End If
                                    '''****************************** COMPLETE FILLING TO FILL POSCODE ******************************************************'''
                                Else
                                    MessageBox.Show("Specified ITEM CODE not found", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    SSGRID.ClearRange(2, SSGRID.ActiveRow, 15, SSGRID.ActiveRow, True)
                                    SSGRID.SetActiveCell(2, SSGRID.ActiveRow)
                                    SSGRID.Lock = False
                                    SSGRID.Focus()
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                End If

            ElseIf SSGRID.ActiveCol = 3 Then
                SSGRID.Col = 2
                SSGRID.Row = SSGRID.ActiveRow
                Itemcode = SSGRID.Text
                SSGRID.Col = 4
                SSGRID.Row = SSGRID.ActiveRow
                POSCODE = SSGRID.Text

                If SSGRID.Lock = False Then
                    '    If Trim(sSGrid.Text) = "" Then
                    '        'sSGrid.SetActiveCell(3, sSGrid.ActiveRow)
                    '        Exit Sub
                    '    End If
                    'Sqlstring = "SELECT POS FROM POSMENULINK WHERE POS='" & POScode & "'AND ITEMCODE='" & Itemcode & "'"
                    'gconnection.getDataSet(Sqlstring, "TR")
                    'If gdataset.Tables("TR").Rows.Count > 0 Then
                    'Else
                    '    MsgBox("POSCODE ALTERED PLEASE CHECK")
                    '    sSGrid.Text = ""
                    'End If
                End If

            ElseIf SSGRID.ActiveCol = 5 Then
                SSGRID.Col = 5
                SSGRID.Row = SSGRID.ActiveRow
                If SSGRID.Lock = False Then
                    If Trim(SSGRID.Text) = "" Then
                        SSGRID.Col = 2
                        SSGRID.Row = SSGRID.ActiveRow
                        Itemcode = Trim(SSGRID.Text)
                        '''****************************** To FILL UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                        Sqlstring = "SELECT DISTINCT R.UOM, R.ITEMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
                        Sqlstring = Sqlstring & " WHERE '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(Itemcode) & "' )"
                        GCONNECTION.getDataSet(Sqlstring, "ITEMRATE")
                        If gdataset.Tables("ITEMRATE").Rows.Count = 1 Then
                            SSGRID.Col = 5
                            SSGRID.Row = SSGRID.ActiveRow
                            SSGRID.Text = CStr(gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")) & ""
                            SSGRID.Col = 7
                            SSGRID.Row = SSGRID.ActiveRow
                            'If Val(PACKINGPERCENT) <> 0 Then
                            '    sSGrid.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                            '    ''+ (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                            'Else
                            SSGRID.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) & ""
                            'End If
                            ''sSGrid.SetActiveCell(4, sSGrid.ActiveRow)

                            SSGRID.Col = 19
                            SSGRID.Row = SSGRID.ActiveRow
                            If Trim(SSGRID.Text) = "Y" Then
                                SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                            Else
                                SSGRID.Col = 7
                                SSGRID.Row = SSGRID.ActiveRow
                                SSGRID.Text = Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE"))
                                SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                            End If

                        ElseIf gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                            SSGRID.Col = 5
                            Call FillUomList(gdataset.Tables("ITEMRATE"))
                            Me.lvw_Uom.FullRowSelect = True
                            pnl_UOMCode.Top = 50
                            Me.lvw_Uom.Focus()
                            Exit Sub
                        Else
                            SSGRID.Col = 2
                            SSGRID.Row = SSGRID.ActiveRow
                            If Trim(SSGRID.Text) <> "" Then
                                SSGRID.Col = 5
                                SSGRID.Text = ""
                                SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                            End If
                        End If
                        '''****************************** COMPLETE FILLING UOM and RATE FOR THAT PARTICULAR ITEMCODE CODE*********************************'''
                    Else
                        SSGRID.Col = 2
                        SSGRID.Row = SSGRID.ActiveRow
                        Itemcode = Trim(SSGRID.Text)
                        SSGRID.Col = 5
                        SSGRID.Row = SSGRID.ActiveRow
                        UOMCODE = Trim(SSGRID.Text)
                        SSGRID.Col = 7
                        SSGRID.Row = SSGRID.ActiveRow
                        RATE = Trim(SSGRID.Text)
                        'Sqlstring = "SELECT UOM FROM RATEMASTER WHERE ITEMCODE='" & Itemcode & "' AND UOM='" & UOMCODE & "'AND ITEMRATE='" & Val(RATE) & "' AND '" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "' BETWEEN STARTINGDATE AND ISNULL(ENDINGDATE,'" & Format(DateValue(DTPBOOKINGDATE.Value), "dd-MMM-yyyy") & "')  "
                        'gconnection.getDataSet(Sqlstring, "RAT")
                        'If gdataset.Tables("RAT").Rows.Count > 0 Then
                        'Else
                        '    MsgBox("UOM ALTERED PLEASE CHECK")
                        '    sSGrid.Col = 4
                        '    sSGrid.Row = sSGrid.ActiveRow
                        '    sSGrid.Text = ""
                        'End If
                    End If
                End If

            ElseIf SSGRID.ActiveCol = 6 Then
                Dim CHECK_AVAILABILITY As Integer
                SSGRID.Col = 6
                SSGRID.Row = SSGRID.ActiveRow
                'SSGRID.Lock = False
                If SSGRID.Lock = False Then
                    SSGRID.Col = 2
                    SSGRID.Row = SSGRID.ActiveRow
                    If Trim(SSGRID.Text) <> "" Then
                        SSGRID.Col = 6
                        SSGRID.Row = SSGRID.ActiveRow
                        If Val(SSGRID.Text) = 0 Then
                            SSGRID.SetActiveCell(6, SSGRID.ActiveRow)
                            Exit Sub
                        Else
                            '' Call Calculate()
                            SSGRID.Col = 19
                            SSGRID.Row = SSGRID.ActiveRow
                            If Trim(SSGRID.Text) = "Y" Then
                                SSGRID.Col = 7
                                SSGRID.Lock = False
                                SSGRID.SetActiveCell(7, SSGRID.ActiveRow)
                                Exit Sub
                            Else
                                CHECK_AVAILABILITY = STOCKAVAILABILITY(SSGRID, i)
                                If CHECK_AVAILABILITY = 0 Then
                                    If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                        SSGRID.ClearRange(2, i, SSGRID.MaxCols, i, True)
                                        SSGRID.Focus()
                                        SSGRID.SetActiveCell(2, i)
                                        Exit Sub
                                    End If
                                ElseIf CHECK_AVAILABILITY = 1 Then
                                    If Mid(gCompanyname, 1, 4) <> "CATH" Then
                                        SSGRID.Col = 5
                                        SSGRID.Text = ""
                                        SSGRID.SetActiveCell(5, i)
                                        SSGRID.Focus()
                                        Exit Sub
                                    End If
                                End If
                                Call Calculate()
                                SSGRID.Row = SSGRID.ActiveRow + 1
                                SSGRID.Col = 1
                                SSGRID.Lock = False
                                SSGRID.Col = 2
                                SSGRID.Lock = False
                                SSGRID.Col = 3
                                SSGRID.Lock = False
                                SSGRID.Col = 4
                                SSGRID.Lock = False
                                SSGRID.Col = 5
                                SSGRID.Lock = False
                                SSGRID.Col = 6
                                SSGRID.Lock = False
                                'sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                            End If

                            'Added on 14 Mar'08
                            'Mk Kannan
                            'Begin
                            'sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                            If boolPromotional = True Then

                                SSGRID.SetActiveCell(1, SSGRID.ActiveRow + 1)
                                SSGRID.Row = SSGRID.ActiveRow + 1
                                SSGRID.Col = 1
                                SSGRID.Lock = False
                                SSGRID.Col = 2
                                SSGRID.Lock = False
                                SSGRID.Col = 3
                                SSGRID.Lock = False
                                SSGRID.Col = 4
                                SSGRID.Lock = False
                                SSGRID.Col = 5
                                SSGRID.Lock = False
                                SSGRID.Col = 6
                                SSGRID.Lock = False
                            Else
                                SSGRID.SetActiveCell(1, SSGRID.ActiveRow + 1)
                            End If
                            boolPromotional = False
                            'End                            
                        End If
                    End If
                End If

            ElseIf SSGRID.ActiveCol = 7 Then
                SSGRID.Col = 7
                SSGRID.Row = SSGRID.ActiveRow
                If SSGRID.Lock = False Then
                    SSGRID.Col = 2
                    SSGRID.Row = SSGRID.ActiveRow
                    If Trim(SSGRID.Text) <> "" Then
                        SSGRID.Col = 7
                        SSGRID.Row = SSGRID.ActiveRow
                        If Val(SSGRID.Text) = 0 Then
                            SSGRID.SetActiveCell(7, SSGRID.ActiveRow)
                            Exit Sub
                        Else
                            Call Calculate()
                            SSGRID.Row = SSGRID.ActiveRow + 1
                            SSGRID.Col = 1
                            SSGRID.Lock = False
                            SSGRID.Col = 2
                            SSGRID.Lock = False
                            SSGRID.Col = 3
                            SSGRID.Lock = False
                            SSGRID.Col = 4
                            SSGRID.Lock = False
                            SSGRID.Col = 5
                            SSGRID.Lock = False
                            SSGRID.Col = 6
                            SSGRID.Lock = False
                            SSGRID.SetActiveCell(1, SSGRID.ActiveRow + 1)
                        End If
                    End If
                End If
            ElseIf SSGRID.ActiveCol = 13 Then
                SSGRID.Col = 13
                SSGRID.Row = SSGRID.ActiveRow
                If Trim(SSGRID.Text) = "No" Or Trim(SSGRID.Text) = "" Then
                    Call Calculate()
                    SSGRID.SetActiveCell(1, SSGRID.ActiveRow + 1)
                    Exit Sub
                Else
                    Call Calculate()
                    SSGRID.SetActiveCell(1, SSGRID.ActiveRow + 1)
                    Exit Sub
                End If
            End If
            Call GridLockRate()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub Label28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label28.Click

    End Sub

    Private Sub Btn_Hallres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Hallres.Click
        ''''''''''' If rdo_halldisplay.Checked = True Then
        GBHALLBOOKING.Visible = True
        GRP_TARIFF.Visible = False
        GRP_NVEG.Visible = False
        GBARRANGEDETAILS.Visible = False
        GBHALLFACILITY.Visible = False
        GBMENUDETAILS.Visible = False
        TXT_DISAMT.Visible = True
        TXT_TOTAMT.Visible = True
        TXTB_BAMOUNT.Visible = True
        Call Total_Calculate()
        ' '' ''Else
        ' '' ''GBHALLBOOKING.Visible = False
        ' '' ''GBARRANGEDETAILS.Visible = False
        ' '' ''GBHALLFACILITY.Visible = False
        ' '' ''GBMENUDETAILS.Visible = False
        ' '' ''End If
    End Sub

    Private Sub Btn_Hallava_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Hallava.Click
        ' If RDBRESMENU.Checked = True Then
        GBHALLFACILITY.Visible = False
        GBARRANGEDETAILS.Visible = False
        GRP_TARIFF.Visible = False
        GRP_NVEG.Visible = False
        GBMENUDETAILS.Visible = True
        GBHALLBOOKING.Visible = False
        GRP_TARIFF.Visible = False
        TXT_DISAMT.Visible = False
        TXT_TOTAMT.Visible = False
        TXTB_BAMOUNT.Visible = False
        'GBMENUDETAILS.Top = 12
        'GBMENUDETAILS.Top = 296
        'Me.TXTRESTOTALAMOUNT.Text = "0.00"
        'GBMENUDETAILS.Top = 30
        'GBMENUDETAILS.Top = 302
        SSGRID.Focus()
        'SSGRID_MENU.SetActiveCell(1, 1)
        'End If
    End Sub

    Private Sub Btn_recdet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_recdet.Click
        ' If RDBARRITEM.Checked = True Then
        GBHALLFACILITY.Visible = False
        GBARRANGEDETAILS.Visible = True
        GBMENUDETAILS.Visible = False
        GRP_TARIFF.Visible = False
        GRP_NVEG.Visible = False
        GBARRANGEDETAILS.Visible = True
        GBARRANGEDETAILS.BringToFront()
        'GBARRANGEDETAILS.Top = 12
        'GBARRANGEDETAILS.Top = 300
        SSGRID_ARRANGE.Focus()
        'SSGRID_ARRANGE.SetActiveCell(1, 1)
        'End If
    End Sub

    Private Sub Btn_nonveg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_nonveg.Click
        GBHALLBOOKING.Visible = False
        GBHALLFACILITY.Visible = False
        GBARRANGEDETAILS.Visible = False
        GBMENUDETAILS.Visible = False
        GRP_TARIFF.Visible = False
        'GBHALLFACILITY.Top = 12
        'GBHALLFACILITY.Top = 296
        GRP_NVEG.Enabled = True
        GRP_NVEG.Visible = True

        SSGRID_HALL.Focus()
        TextNVTBOX.Focus()
    End Sub

   

    Private Sub btn_veg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_veg.Click
        GBHALLFACILITY.Visible = False
        GBARRANGEDETAILS.Visible = False
        GBHALLBOOKING.Visible = False
        GBMENUDETAILS.Visible = False
        GRP_NVEG.Visible = False
        'GBHALLFACILITY.Top = 12
        'GBHALLFACILITY.Top = 296
        GRP_TARIFF.Visible = True
        SSGRID_HALL.Focus()
        TXT_TARIFF.Focus()
    End Sub

    Private Sub Label25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label25.Click

    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearoperaction()
    End Sub
    Private Sub lvw_POSCode_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles lvw_POSCode.KeyPress
        Dim strSQL As String
        Dim posloc As String
        Dim acctin As String
        If Asc(e.KeyChar) = 13 Then
            Try
                posloc = Trim(lvw_POSCode.SelectedItems(0).SubItems(0).Text)
                acctin = Trim(lvw_POSCode.SelectedItems(0).SubItems(2).Text)
            Catch ex As Exception
                posloc = Trim(lvw_POSCode.Items(0).SubItems(0).Text)
                acctin = Trim(lvw_POSCode.Items(0).SubItems(2).Text)
            Finally
                If Trim(acctin) <> "" Or Trim(acctin) = "" Then
                    sSGrid.SetText(4, sSGrid.ActiveRow, posloc)
                    ''sSGrid.SetText(14, sSGrid.ActiveRow, acctin)
                    pnl_POSCode.Top = 1000
                    sSGrid.Focus()
                    SSGRID.SetActiveCell(5, SSGRID.ActiveRow)
                    SSGRID.Lock = False
                Else
                    MsgBox("Sales Account In Not Defined", MsgBoxStyle.Critical)
                End If
            End Try
        End If
    End Sub
    Private Sub lvw_Uom_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles lvw_Uom.KeyPress
        Try
            Dim strSQL As String
            Dim uomcode, uomrate As String
            If Asc(e.KeyChar) = 13 Then
                Try
                    uomcode = Trim(lvw_Uom.SelectedItems(0).SubItems(0).Text)
                    uomrate = Trim(lvw_Uom.SelectedItems(0).SubItems(1).Text)
                Catch ex As Exception
                    uomcode = Trim(lvw_Uom.Items(0).SubItems(0).Text)
                    uomrate = Trim(lvw_Uom.Items(0).SubItems(1).Text)
                Finally
                    sSGrid.SetText(5, sSGrid.ActiveRow, uomcode)
                    sSGrid.SetText(7, sSGrid.ActiveRow, uomrate)
                    pnl_UOMCode.Top = 1000
                    sSGrid.Focus()
                    SSGRID.SetActiveCell(6, SSGRID.ActiveRow)
                    SSGRID.Lock = False
                End Try
            End If
        Catch
        End Try
    End Sub
    Private Sub autogenerate()
        Dim ssql, SQLSTRING As String
        Dim billstr As String
        SQLSTRING = "select isnull(max(substring(billno,5,6)),0)+1 as no from PARTY_HDR where BOOKINGTYPE='BILLING' AND substring(billno,12,5)='" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2) & "'"
        GCONNECTION.getDataSet(SQLSTRING, "USER1")
        If gdataset.Tables("USER1").Rows.Count - 1 >= 0 Then
            ' ''If Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 1 Then
            ' ''    billstr = "PAR/00000" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ' ''ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 2 Then
            ' ''    billstr = "PAR/0000" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ' ''ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 3 Then
            ' ''    billstr = "PAR/000" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ' ''ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 4 Then
            ' ''    billstr = "PAR/00" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ' ''ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 5 Then
            ' ''    billstr = "PAR/0" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ' ''ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 6 Then
            ' ''    billstr = "PAR/" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ' ''End If
            If Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 1 Then
                billstr = "PBL/00000" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 2 Then
                billstr = "PBL/0000" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 3 Then
                billstr = "PBL/000" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 4 Then
                billstr = "PBL/00" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 5 Then
                billstr = "PBL/0" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            ElseIf Len(Trim(gdataset.Tables("USER1").Rows(0).Item("no"))) = 6 Then
                billstr = "PBL/" & gdataset.Tables("USER1").Rows(0).Item("no") & "/" & Mid(gFinancalyearStart, 3, 2) & "-" & Mid(gFinancialYearEnd, 3, 2)
            End If
        End If
        TXTBILLINGNO.Text = billstr
        'lblbilno.Text = billstr
    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Call checkValidation()
        Dim RATE, AMOUNT, GRDTAXAMOUNT As Double
        Dim TAXCODE As String
        Dim TPercent, RoomPer, PartyPer As Double
        Dim TPackAmt, TTipsAmt, TAdchgAmt, TPartyAmt, TRoomAmt, GAmt, PKOTAMT As Double
        Dim MemGstNo, MemStCode, FApply As String
        If BOOLCHK = False Then Exit Sub
        Try
            Dim SQLSTRING As String
            If Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                If Trim(gUserCategory) <> "S" Then
                    MsgBox("Please Contact System Administrator...", MsgBoxStyle.OKOnly, "CANCEL")
                    CMBBOOKINGTYPE.Focus()
                    Exit Sub
                End If
            End If

            If Trim(TXTBOOKINGNO.Text) <> "" Then
                SQLSTRING = "SELECT * FROM PARTY_ACC_POST  where bookingno=" & TXTBOOKINGNO.Text & " AND ISNULL(POSTFLAG,'')='Y' "
                GCONNECTION.getDataSet(SQLSTRING, "accpost")
                If gdataset.Tables("accpost").Rows.Count > 0 Then
                    MessageBox.Show("ALREADY ACCOUNT POSTING WAS DONE,YOU CANNOT UPDATE THE BILL ", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then

                SQLSTRING = "SELECT DISTINCT PARTYRECEIPTNO FROM party_receipt_det where bookingno=" & TXTBOOKINGNO.Text & " AND RECEIPTTYPE<>'REFUND' "
                GCONNECTION.getDataSet(SQLSTRING, "PARTYRECEIPT")
                If gdataset.Tables("PARTYRECEIPT").Rows.Count <= 0 Then
                    MessageBox.Show("PLEASE MAKE THE RECEIPT FOR THIS RESERVATION NO  ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Else

            End If


            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Call datevalidation()

            SQLSTRING = "UPDATE PARTY_HDR SET PARTY_HDR.DESCRIPTION =B.DESCRIPTION FROM PARTY_HALLBOOKING_HDR B WHERE PARTY_HDR.BOOKINGNO=B.BOOKINGNO and isnull(PARTY_HDR.DESCRIPTION,'')=''"
            GCONNECTION.getDataSet(SQLSTRING, "PARTY_LOCATIONMASTER")

            SQLSTRING = "SELECT DISTINCT LOCCODE FROM PARTY_LOCATIONMASTER WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            GCONNECTION.getDataSet(SQLSTRING, "PARTY_LOCATIONMASTER")
            If gdataset.Tables("PARTY_LOCATIONMASTER").Rows.Count <= 0 Then
                CMB_LOCATION.Focus()
                CMB_LOCATION.BackColor = Color.Red
            End If

            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" And CMBBOOKINGTYPE.Text = "CANCEL" Then
                MessageBox.Show(" This Booking is Cancelled Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.Cmd_Clear_Click(sender, e)
                Exit Sub
            ElseIf Mid(Me.Cmd_Add.Text, 1, 1) = "U" And CMBBOOKINGTYPE.Text = "BOOKING" Then
                SSQL = "Select  * from  PARTY_HALLBOOKING_HDR where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and Isnull(BILLINGFLAG,'')='Y'"
                DT = GCONNECTION.GetValues(SSQL)
                If DT.Rows.Count > 0 Then
                    MessageBox.Show(" Billing Over Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

                    Me.Cmd_Clear_Click(sender, e)
                    Exit Sub
                End If
            ElseIf Mid(Me.Cmd_Add.Text, 1, 1) = "U" And CMBBOOKINGTYPE.Text = "BILLING" Then
                SSQL = "Select  * from  PARTY_HALLBOOKING_HDR where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and Isnull(bookingflag,'')<>'Y'"
                DT = GCONNECTION.GetValues(SSQL)
                If DT.Rows.Count > 0 Then
                    MessageBox.Show(" Booking is Not Complete,Can Not Be Insert", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.Cmd_Clear_Click(sender, e)
                    Exit Sub
                End If
            Else
                SSQL = "Select  * from  PARTY_HALLBOOKING_HDR where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and Isnull(cancelflag,'')='Y'"
                DT = GCONNECTION.GetValues(SSQL)
                If DT.Rows.Count > 0 Then
                    MessageBox.Show(" This Booking is Cancelled Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.Cmd_Clear_Click(sender, e)
                    Exit Sub
                End If
            End If

            SSQL = "SELECT bookingno,isnull(MEMGSTNO,'') as MEMGSTNO,isnull(STCODE,'') as STCODE,Isnull(FTaxApply,'NO') as FTaxApply FROM PARTY_HALLBOOKING_HDR where bookingno=" & TXTBOOKINGNO.Text & " "
            GCONNECTION.getDataSet(SSQL, "PartyGST")
            If gdataset.Tables("PartyGST").Rows.Count > 0 Then
                MemGstNo = gdataset.Tables("PartyGST").Rows(0).Item("MEMGSTNO")
                MemStCode = gdataset.Tables("PartyGST").Rows(0).Item("STCODE")
                FApply = UCase(gdataset.Tables("PartyGST").Rows(0).Item("FTaxApply"))
            End If

            Call checkValidation()
            If BOOLCHK = False Then Exit Sub
            Dim INSERT(0) As String
            CHBHALLTAX.Checked = True
            If CHBHALLTAX.Checked = True Then
                SSQL = "SELECT ISNULL(A.TAXPERCENTAGE,0) AS TAXPERCENTAGE FROM ITEMTYPEMASTER A INNER JOIN PARTY_HALLMASTER B"
                SSQL = SSQL & " ON A.ITEMTYPECODE=B.ITEMTYPECODE AND B.HALLCODE='" & TXTHALLCODE.Text & "'"
                SSQL = SSQL & " And A.STARTINGDATE<='" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy") & "'"
                SSQL = SSQL & " And isnull(A.ENDINGDATE,getdate())>='" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy") & "'"
                DT = GCONNECTION.GetValues(SSQL)
                If DT.Rows.Count > 0 Then
                    TAXPER = DT.Rows(0).Item("TAXPERCENTAGE")
                    TAXAMOUNT = Val(Math.Round(TAXPER * TXTHALLRENT.Text / 100, 2))
                Else
                    TAXAMOUNT = 0
                    TAXPER = 0.0
                End If
            Else
                TAXAMOUNT = 0
                TAXPER = 0.0
            End If
            If Mid(Cmd_Add.Text, 1, 1) = "A" Then
                Call autogenerate()
                SSQL = "INSERT INTO PARTY_HDR(BILLNO,BILLDATE,LOCCODE,BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,PARTYDATE,MCODE,GUESTNAME,"
                SSQL = SSQL & "OCCUPANCY,veg,nonveg,HALLTAXFLAG,"
                SSQL = SSQL & "HALLTAXAMOUNT,HALLTAXPERC,ARRMENTAMOUNT,RESTAMOUNT,RESCANCELAMOUNT,"
                SSQL = SSQL & "ARRCANCELAMOUNT,HALLCANCELAMOUNT,FREEZE,INVOICENO,ADDUSERID,ADDDATETIME,vegcode,MENUCODE,nonvegcode) "
                SSQL = SSQL & " VALUES('" & Trim(TXTBILLINGNO.Text) & "','" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy") & "','" & Trim(CMB_LOCATION.Text) & "','" & Trim(CMBBOOKINGTYPE.Text) & "'," & Trim(TXTBOOKINGNO.Text)
                SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "'"
                SSQL = SSQL & ",'" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "'"
                SSQL = SSQL & ",'" & Trim(TXTMCODE.Text) & "'"
                SSQL = SSQL & ",'" & Trim(TXTGUESTNAME.Text) & "'"

                SSQL = SSQL & "," & IIf(Val(TxtOCCUPANCY.Text) > 0, Val(TxtOCCUPANCY.Text), 0)
                SSQL = SSQL & "," & IIf(Val(TxtVOCCUPANCY.Text) > 0, Val(TxtVOCCUPANCY.Text), 0)
                SSQL = SSQL & "," & IIf(Val(TxtNVOCCUPANCY.Text) > 0, Val(TxtNVOCCUPANCY.Text), 0)

                SSQL = SSQL & ",'" & IIf(CHBHALLTAX.Checked = True, "Y", "N") & "'"
                SSQL = SSQL & "," & IIf(Val(TAXAMOUNT) > 0, Val(TAXAMOUNT), 0)
                SSQL = SSQL & "," & IIf(Val(TAXPER) > 0, Val(TAXPER), 0)
                SSQL = SSQL & "," & IIf(Val(TXTARRTOTALAMOUNT.Text) > 0, Val(TXTARRTOTALAMOUNT.Text), 0)
                SSQL = SSQL & "," & IIf(Val(TXTRESTOTALAMOUNT.Text) > 0, Val(TXTRESTOTALAMOUNT.Text), 0)
                'SSQL = SSQL & "," & IIf(Val(TXTRESTOTALAMOUNT.Text) > 0, Val(TXTRESTOTALAMOUNT.Text), 0)

                SSQL = SSQL & "," & IIf(Val(TXTRESCANCELAMT.Text) > 0, Val(TXTRESCANCELAMT.Text), 0)
                SSQL = SSQL & "," & IIf(Val(TXTARRCANCELAMT.Text) > 0, Val(TXTARRCANCELAMT.Text), 0)
                SSQL = SSQL & "," & IIf(Val(TXTHALLCANCELAMT.Text) > 0, Val(TXTHALLCANCELAMT.Text), 0)
                SSQL = SSQL & ",'N'"
                SSQL = SSQL & "," & Val(TXTBILLINGNO.Text) & ""
                SSQL = SSQL & ",'" & Trim(gUsername) & "'"


                SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                SSQL = SSQL & ",'" & Trim(TextNVTBOX.Text) & "'"
                SSQL = SSQL & ",'" & Trim(TXT_MENU.Text) & "'"
                SSQL = SSQL & ",'" & Trim(TXT_TARIFF.Text) & "')"

                INSERT(0) = SSQL

                With SSGRID_HALL
                    If .DataRowCnt > 0 Then
                        For I = 1 To .DataRowCnt
                            UOM = "" : ITEMDESC = "" : QTY = 0 : SSQL = ""
                            .Row = I
                            .Col = 1
                            ITEMDESC = Trim(.Text)
                            .Row = I
                            .Col = 2
                            UOM = Trim(.Text)
                            .Row = I
                            .Col = 3
                            QTY = IIf(Val(.Text) > 0, Val(.Text), 0)
                            SSQL = "INSERT INTO PARTY_HALLFACILITY(LOCCODE,HALLCODE,BOOKINGTYPE,BOOKINGNO,"
                            SSQL = SSQL & "ITEMCODE,ITEMDESCRIPTION,QTY,FREEZE,ADDUSERID,ADDDATETIME)"
                            SSQL = SSQL & " values('" & Trim(CMB_LOCATION.Text) & "','" & Trim(TXTHALLCODE.Text) & "'"
                            SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "'"
                            SSQL = SSQL & "," & TXTBOOKINGNO.Text
                            SSQL = SSQL & ",''"
                            SSQL = SSQL & ",'" & ITEMDESC & "'"
                            SSQL = SSQL & "," & IIf(QTY > 0, QTY, 0)
                            SSQL = SSQL & ",'N'"
                            SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                            SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = SSQL
                        Next
                    End If
                End With
                '  ARRANGEMENT(DETAILS)
                ' BEGIN()
                With SSGRID_ARRANGE
                    If .DataRowCnt > 0 Then
                        For I = 1 To .DataRowCnt
                            UOM = "" : ITEMDESC = "" : QTY = 0 : TAXPER = 0 : SSQL = "" : ITEMCODE = "" : RATE = 0 : TAXAMOUNT = 0 : AMOUNT = 0 : CAMOUNT = 0
                            .Row = I
                            .Col = 1
                            ITEMCODE = Trim(.Text)

                            .Row = I
                            .Col = 2
                            ITEMDESC = Trim(.Text)

                            .Row = I
                            .Col = 3
                            UOM = Trim(.Text)

                            .Row = I
                            .Col = 4
                            RATE = Trim(.Text)

                            .Row = I
                            .Col = 5
                            QTY = IIf(Val(.Text) > 0, Val(.Text), 0)

                            .Row = I
                            .Col = 6
                            TAXAMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)

                            .Row = I
                            .Col = 7
                            AMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)

                            .Row = I
                            .Col = 8
                            totalamount = IIf(Val(.Text) > 0, Val(.Text), 0)

                            .Row = I
                            .Col = 9
                            CAMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)

                            .Row = I
                            .Col = 10
                            ROUNDOFF = IIf(Val(.Text) <> 0, Val(.Text), 0)

                            .Row = I
                            .Col = 11
                            TAXPER = Trim(.Text)

                            SSQL = "Insert Into PARTY_ARRANGEMENT(LOCCODE,BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,"
                            SSQL = SSQL & " ITEMCODE,QTY,RATE,TAXAMOUNT,AMOUNT,totalamount,CANCELAMOUNT,"
                            SSQL = SSQL & " TAXPERC,ROUNDOFF,"
                            SSQL = SSQL & " FREEZE,ADDUSERID,ADDDATETIME)"
                            SSQL = SSQL & " Values('" & Trim(CMB_LOCATION.Text) & "'," & TXTBOOKINGNO.Text
                            SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                            SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "'"
                            SSQL = SSQL & ",'" & ITEMCODE & "'"
                            SSQL = SSQL & "," & IIf(QTY > 0, QTY, 0)
                            SSQL = SSQL & "," & IIf(RATE > 0, RATE, 0)
                            SSQL = SSQL & "," & IIf(TAXAMOUNT > 0, TAXAMOUNT, 0)
                            SSQL = SSQL & "," & IIf(AMOUNT > 0, AMOUNT, 0)
                            SSQL = SSQL & "," & IIf(totalamount > 0, totalamount, 0)
                            SSQL = SSQL & "," & IIf(CAMOUNT > 0, CAMOUNT, 0)
                            SSQL = SSQL & "," & IIf(TAXPER > 0, TAXPER, 0)
                            SSQL = SSQL & "," & ROUNDOFF
                            SSQL = SSQL & ",'N'"
                            SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                            SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = SSQL
                        Next
                    End If
                End With
                'Call ARRANGEcalculate1()
                'ARRANGEMENT DETAILS
                'END
                'RESTAURANT MENU
                'BEGIN
                ' INSERT(0) = SSQL
                '''******************************************************** Insert into KOT_DET **********************************'''
                For I = 1 To SSGRID.DataRowCnt
                    SSQL = "INSERT INTO PARTY_KOT_DET(BOOKINGTYPE,KotNo,KOTdetails,KotDate,Billdetails,KotType,PaymentMode,Mcode,Scode,Covers,TableNo,TotAmt,TaxAmt,PackAmt,DiscAmt,BillAmt,ChkId,MKOTNO,ItemCode,Itemdesc,Poscode,Uom,Qty,Rate,Taxamount,Amount,ItemType,TaxCode,TaxPerc,TaxAccountCode,SalesAccountCode,GroupCode,SUBGROUPCODE,"
                    SSQL = SSQL & "Openfacilityst,Promotionalst,Taxtype,Alcholst,Adduserid,Adddatetime,Upduserid,Upddatetime,KOTStatus,Delflag,PDA_PRINT_FLAG,PDA_DELETE_FLAG,IS_PDA) "

                    SSQL = SSQL & " VALUES('BILLING','" & Trim(CStr(TXTBOOKINGNO.Text)) & "','" & Trim(CStr(TXTBOOKINGNO.Text)) & "','" & Format(DTPBOOKINGDATE.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(CStr(TXTBOOKINGNO.Text)) & "','PAR','PARTY',"


                    SSQL = SSQL & " '" & Trim(TXTMCODE.Text) & "','',0,0," & Val(0) & "," & Val(0) & "," & Val(0) & ",0," & Val(0) & ",0"

                    SSGRID.Row = I
                    SSGRID.Col = 1
                    SSQL = SSQL & ",'" & Trim(SSGRID.Text) & "'"
                    SSGRID.Col = 2
                    SSQL = SSQL & ",'" & Trim(SSGRID.Text) & "'"
                    SSGRID.Col = 3
                    SSQL = SSQL & ",'" & Trim(SSGRID.Text) & "'"
                    SSGRID.Col = 4
                    SSQL = SSQL & ",'" & Trim(SSGRID.Text) & "'"
                    SSGRID.Col = 5
                    SSQL = SSQL & ",'" & Trim(SSGRID.Text) & "'"
                    SSGRID.Col = 6
                    SSQL = SSQL & "," & Val(SSGRID.Text) & ""
                    SSGRID.Col = 7
                    SSQL = SSQL & "," & Val(SSGRID.Text) & ""
                    POS_RATE_GBL = Val(SSGRID.Text)
                    SSGRID.Col = 8
                    SSQL = SSQL & "," & Val(SSGRID.Text) & ""
                    SSGRID.Col = 9
                    SSQL = SSQL & "," & Val(SSGRID.Text) & ""
                    SSGRID.Col = 10
                    SSQL = SSQL & ",'" & Trim(SSGRID.Text) & "'"
                    SSGRID.Col = 11
                    SSQL = SSQL & ",'" & Trim(SSGRID.Text) & "'"
                    SSGRID.Col = 12
                    SSQL = SSQL & "," & Val(SSGRID.Text) & " "
                    SSGRID.Col = 14
                    SSQL = SSQL & ",'" & Trim(SSGRID.Text) & "' "
                    SSGRID.Col = 15
                    SSQL = SSQL & ",'" & Trim(SSGRID.Text) & "' "
                    SSGRID.Col = 16
                    SSQL = SSQL & ",'" & Trim(SSGRID.Text) & "' "
                    SSGRID.Col = 17
                    SSQL = SSQL & ",'" & Trim(SSGRID.Text) & "' "
                    SSGRID.Col = 19
                    SSQL = SSQL & ",'" & Trim(SSGRID.Text) & "' "
                    SSGRID.Col = 20
                    SSQL = SSQL & ",'" & Trim(SSGRID.Text) & "'"
                    SSGRID.Col = 10
                    If Trim(SSGRID.Text) = "BAR" Then
                        SSQL = SSQL & ",'','Y'"
                    ElseIf Trim(SSGRID.Text) = "SD" Then
                        SSQL = SSQL & ",'SALES','S'"
                    Else
                        SSQL = SSQL & ",'SALES','N'"
                    End If
                    SSQL = SSQL & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                    SSGRID.Col = 13
                    If Trim(SSGRID.Text) = "Yes" Then
                        SSQL = SSQL & ",'Y','N','','','')"
                    Else
                        SSQL = SSQL & ",'N','N','','','')"
                    End If
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL

                Next
                For I = 1 To SSGRID.DataRowCnt
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    With SSGRID
                        .Col = 2
                        .Row = I
                        ITEMCODE = Trim(.Text)
                        .Col = 7
                        .Row = I
                        GrdRate = Val(.Text)
                        .Col = 6
                        .Row = I
                        QTY = Val(.Text)
                        .Col = 4
                        .Row = I
                        POS = Trim(.Text)
                        .Col = 13
                        .Row = I
                        KStatus = Mid(Trim(.Text), 1, 1)
                        .Col = 10
                        .Row = I
                        ChargeCode = Trim(.Text)
                        SSQL = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                        GCONNECTION.getDataSet(SSQL, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        SSQL = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(SSQL, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For J = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(J).Item("ItemTypeCode"))
                                TAXCODE = Trim(gdataset.Tables("TAXON").Rows(J).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(J).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")

                                SSQL = "INSERT INTO PARTY_KOT_DET_TAX (KOTDETAILS,KOTDATE,TTYPE,CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,ADD_USER,ADD_DATE,VOID,VOIDUSER) VALUES ( "
                                SSQL = SSQL & "'" & Trim(TXTBOOKINGNO.Text) & "','" & Format(DTPBOOKINGDATE.Value, "dd-MMM-yyyy") & "','P','" & Trim(ChargeCode) & "','" & Trim(IType) & "','" & Trim(POS) & "','" & Trim(ITEMCODE) & "','" & Trim(KStatus) & "','" & Trim(TAXCODE) & "','" & Trim(Taxon) & "'," & (GrdRate) & "," & (QTY) & "," & (TPercent) & ","

                                If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                                    Zero = (GrdRate * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    SSQL = SSQL & "" & Val(Zero) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    SSQL = SSQL & "" & Val(ZeroA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    SSQL = SSQL & "" & Val(ZeroB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                                    One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    SSQL = SSQL & "" & Val(One) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    SSQL = SSQL & "" & Val(OneA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    SSQL = SSQL & "" & Val(OneB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                                    Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    SSQL = SSQL & "" & Val(Two) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    SSQL = SSQL & "" & Val(TwoA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    SSQL = SSQL & "" & Val(TwoB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                                    Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    SSQL = SSQL & "" & Val(Three) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    SSQL = SSQL & "" & Val(ThreeA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    SSQL = SSQL & "" & Val(ThreeB) * QTY & ","
                                End If
                                SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N','')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = SSQL
                            Next
                        End If
                    End With
                Next
                For I = 1 To SSGRID.DataRowCnt
                    With SSGRID
                        .Col = 2
                        .Row = I
                        ITEMCODE = Trim(.Text)
                        .Col = 6
                        .Row = I
                        QTY = Val(.Text)
                        .Col = 9
                        .Row = I
                        GAmt = Val(.Text)
                        If gCenterlized = "N" Then
                            TPackAmt = Val((GAmt * gPackPer) / 100)
                            TTipsAmt = Val((GAmt * gTipsPer) / 100)
                            TAdchgAmt = Val((GAmt * gAdCgsPer) / 100)

                            TPartyAmt = Val((GAmt * gPartyPer) / 100)
                            PartyPer = gPartyPer


                            RoomPer = 0
                            TRoomAmt = 0

                        Else
                            TPackAmt = Val((GAmt * pPackPer) / 100)
                            TTipsAmt = Val((GAmt * pTipsPer) / 100)
                            TAdchgAmt = Val((GAmt * pAdCgsPer) / 100)

                            TPartyAmt = Val((GAmt * pPartyPer) / 100)
                            PartyPer = pPartyPer

                            RoomPer = 0
                            TRoomAmt = 0
                        End If

                        If gCenterlized = "N" Then
                            SSQL = "UPDATE PARTY_KOT_DET SET PACKPERCENT = " & gPackPer & ",PACKAMOUNT =  " & TPackAmt & ",TipsPer= " & gTipsPer & ",TipsAmt= " & TTipsAmt & ",AdCgsPer= " & gAdCgsPer & ",AdCgsAmt= " & TAdchgAmt & ",PartyPer = " & PartyPer & ",PartyAmt= " & TPartyAmt & " ,RoomPer = " & RoomPer & ",RoomAmt = " & TRoomAmt & " "
                            SSQL = SSQL & " WHERE KOTDETAILS = '" & Trim(TXTBOOKINGNO.Text) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "'"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = SSQL
                        Else
                            SSQL = "UPDATE PARTY_KOT_DET SET PACKPERCENT = " & pPackPer & ",PACKAMOUNT =  " & TPackAmt & ",TipsPer= " & pTipsPer & ",TipsAmt= " & TTipsAmt & ",AdCgsPer= " & pAdCgsPer & ",AdCgsAmt= " & TAdchgAmt & ",PartyPer = " & PartyPer & ",PartyAmt= " & TPartyAmt & " ,RoomPer = " & RoomPer & ",RoomAmt = " & TRoomAmt & " "
                            SSQL = SSQL & " WHERE KOTDETAILS = '" & Trim(TXTBOOKINGNO.Text) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "'"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = SSQL
                        End If
                    End With
                Next
                SSQL = "update PARTY_RESTAURANT set category=T.category from Party_TariffHdr T where PARTY_RESTAURANT.ITEMCODE=T.TARIFFCODE   and PARTY_RESTAURANT.bookingno='" & Me.TXTBOOKINGNO.Text & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = SSQL
                With SSGRID_TARIFF
                    GRDTAXAMOUNT = 0.0
                    If .DataRowCnt > 0 Then
                        gSQLString = "SELECT ISNULL(RATE,0) AS RATE,ISNULL(TAXCODE,'') AS TAXCODE FROM Party_TariffHDR WHERE TARIFFCODE='" & TXT_TARIFF.Text & "' AND CATEGORY='VEG'"
                        GCONNECTION.getDataSet(gSQLString, "TARIFF")
                        If gdataset.Tables("TARIFF").Rows.Count > 0 Then
                            RATE = Val(gdataset.Tables("TARIFF").Rows(0).Item("RATE"))
                            TAXCODE = gdataset.Tables("TARIFF").Rows(0).Item("TAXCODE")
                        End If
                        SSQL = "INSERT INTO PARTY_RESTAURANT(UOM,LOCCODE,BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                        SSQL = SSQL & " ITEMCODE,QTY,RATE,AMOUNT,TAXCODE,TARIFFCODE,MAXITEMS,"
                        SSQL = SSQL & " TYPE,FREEZE,ADDUSERID,ADDDATETIME)"
                        SSQL = SSQL & " VALUES('NOS','" & Trim(CMB_LOCATION.Text) & "'," & TXTBOOKINGNO.Text
                        SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                        SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "','T'"
                        SSQL = SSQL & ",'" & TXT_TARIFF.Text & "'"
                        SSQL = SSQL & "," & Val(TxtVOCCUPANCY.Text) & ""
                        SSQL = SSQL & "," & RATE & ""
                        SSQL = SSQL & "," & (Val(TxtVOCCUPANCY.Text) * RATE) & ""
                        SSQL = SSQL & ",'" & TAXCODE & "'"
                        SSQL = SSQL & ",'" & TXT_TARIFF.Text & "'"
                        SSQL = SSQL & "," & Val(Txt_Maxitems.Text) & ""
                        SSQL = SSQL & ",'VEG'"
                        SSQL = SSQL & ",'N'"
                        SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                        SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = SSQL
                        ''TAX INSERT START
                        'RATE = 0
                        Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                        GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                        SQLSTRING = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(TAXCODE) & "' "
                        GCONNECTION.getDataSet(SQLSTRING, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        QTY = Val(TxtVOCCUPANCY.Text)
                        ChargeCode = TAXCODE
                        SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(SQLSTRING, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For J = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(J).Item("ItemTypeCode"))
                                TAXCODE = Trim(gdataset.Tables("TAXON").Rows(J).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(J).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")

                                SSQL = "INSERT INTO PARTY_RESTAURANT_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TTYPE,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                                SSQL = SSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(TAXCODE) & "','" & Trim(Taxon) & "','" & Trim(TXT_TARIFF.Text) & "'," & Val(RATE) & ",'" & Val(QTY) & "'," & (TPercent) & ",'VEG',"
                                If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                                    Zero = (RATE * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Zero) * QTY, "0.00")
                                    SSQL = SSQL & "" & Format(Val(Zero) * QTY, "0.00") & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(ZeroA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Format(Val(ZeroA) * QTY, "0.00") & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    SSQL = SSQL & "" & Format(Val(ZeroB) * QTY, "0.00") & ","
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(ZeroB) * QTY, "0.00")
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                                    One = ((RATE + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(One) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(One) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(OneA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(OneA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(OneB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(OneB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                                    Two = ((RATE + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Two) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(Two) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(TwoA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(TwoA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(TwoB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(TwoB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                                    Three = ((RATE + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Three) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(Three) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(GThreeA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(ThreeA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(GThreeB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(ThreeB) * QTY & ","
                                End If



                                SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = SSQL
                            Next
                            GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                            GRDTAXAMOUNT = GRDTAXAMOUNT + GrdTaxAmt
                            '.SetText(6, I, GrdTaxAmt)
                            '.SetText(8, I, GrdTaxAmt + rate)
                        End If

                        ''TAX INSERT END

                        For I = 1 To .DataRowCnt
                            .Col = 2
                            .Row = I
                            If (.Text <> "") Then


                                SSQL = "INSERT INTO PARTY_RESTAURANT_DET(BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                                SSQL = SSQL & " ITEMCODE,ITEMDESC,UOM,QTY,GROUPCODE,MENUCODE,TARIFFCODE,MAXITEMS,"
                                SSQL = SSQL & " FREEZE,ADDUSERID,ADDDATETIME)"
                                SSQL = SSQL & " VALUES(" & TXTBOOKINGNO.Text
                                SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                                SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "','VEG'"
                                .Col = 2
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 3
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 4
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 5
                                .Row = I
                                SSQL = SSQL & "," & Val(.Text) & ""
                                .Col = 6
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 7
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 1
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 9
                                .Row = I
                                SSQL = SSQL & "," & Val(.Text) & ""

                                SSQL = SSQL & ",'N'"
                                SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                                SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = SSQL
                            End If
                        Next
                    End If
                    SSQL = "UPDATE PARTY_RESTAURANT SET TAXAMOUNT=" & GRDTAXAMOUNT & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND TYPE='VEG'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "UPDATE PARTY_RESTAURANT SET TOTALAMOUNT=AMOUNT+TAXAMOUNT WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND TYPE='VEG'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "update PARTY_RESTAURANT set category=T.category from Party_TariffHdr T where PARTY_RESTAURANT.ITEMCODE=T.TARIFFCODE   and PARTY_RESTAURANT.bookingno='" & Me.TXTBOOKINGNO.Text & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "update PARTY_RESTAURANT set ITEMDESC=T.TARIFFDESC from Party_TariffHdr T where PARTY_RESTAURANT.ITEMCODE=T.TARIFFCODE   and PARTY_RESTAURANT.bookingno='" & Me.TXTBOOKINGNO.Text & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                End With
                With SSGRID_NV
                    GRDTAXAMOUNT = 0.0
                    'If .DataRowCnt > 0 Then
                    '    For I = 1 To .DataRowCnt

                    '        SSQL = "INSERT INTO PARTY_RESTAURANT_DET(BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                    '        SSQL = SSQL & " ITEMCODE,ITEMDESC,UOM,QTY,GROUPCODE,MENUCODE,TARIFFCODE,MAXITEMS,"
                    '        SSQL = SSQL & " FREEZE,ADDUSERID,ADDDATETIME)"
                    '        SSQL = SSQL & " VALUES(" & TXTBOOKINGNO.Text
                    '        SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                    '        SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "','NONVEG'"
                    '        .Col = 2
                    '        .Row = I
                    '        SSQL = SSQL & ",'" & Trim(.Text) & "'"
                    '        .Col = 3
                    '        .Row = I
                    '        SSQL = SSQL & ",'" & Trim(.Text) & "'"
                    '        .Col = 4
                    '        .Row = I
                    '        SSQL = SSQL & ",'" & Trim(.Text) & "'"
                    '        .Col = 5
                    '        .Row = I
                    '        SSQL = SSQL & "," & Val(.Text) & ""
                    '        .Col = 6
                    '        .Row = I
                    '        SSQL = SSQL & ",'" & Trim(.Text) & "'"
                    '        .Col = 7
                    '        .Row = I
                    '        SSQL = SSQL & ",'" & Trim(.Text) & "'"
                    '        .Col = 1
                    '        .Row = I
                    '        SSQL = SSQL & ",'" & Trim(.Text) & "'"
                    '        .Col = 9
                    '        .Row = I
                    '        SSQL = SSQL & "," & Val(.Text) & ""

                    '        SSQL = SSQL & ",'N'"
                    '        SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                    '        SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"

                    '        SSQL = "INSERT INTO PARTY_RESTAURANT(LOCCODE,BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                    '        SSQL = SSQL & " ITEMCODE,QTY,GROUPCODE,MENUCODE,TARIFFCODE,MAXITEMS,"
                    '        SSQL = SSQL & " TYPE,FREEZE,ADDUSERID,ADDDATETIME"
                    '        SSQL = SSQL & " VALUES('" & Trim(CMB_LOCATION.Text) & "'," & TXTBOOKINGNO.Text
                    '        SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                    '        SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "','T'"
                    '        .Col = 2
                    '        .Row = I
                    '        SSQL = SSQL & ",'" & Trim(.Text) & "'"
                    '        .Col = 5
                    '        .Row = I
                    '        SSQL = SSQL & "," & Val(.Text) & ""
                    '        .Col = 6
                    '        .Row = I
                    '        SSQL = SSQL & ",'" & Trim(.Text) & "'"
                    '        .Col = 7
                    '        .Row = I
                    '        SSQL = SSQL & ",'" & Trim(.Text) & "'"
                    '        .Col = 1
                    '        .Row = I
                    '        SSQL = SSQL & ",'" & Trim(.Text) & "'"
                    '        .Col = 9
                    '        .Row = I
                    '        SSQL = SSQL & "," & Val(.Text) & ""
                    '        SSQL = SSQL & ",'NONVEG'"
                    '        SSQL = SSQL & ",'N'"
                    '        SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                    '        SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                    '        ReDim Preserve INSERT(INSERT.Length)
                    '        INSERT(INSERT.Length - 1) = SSQL


                    '    Next
                    'End If
                    If .DataRowCnt > 0 Then
                        gSQLString = "SELECT ISNULL(RATE,0) AS RATE,ISNULL(TAXCODE,'') AS TAXCODE FROM Party_TariffHDR WHERE TARIFFCODE='" & TextNVTBOX.Text & "' AND CATEGORY='NON VEG'"
                        GCONNECTION.getDataSet(gSQLString, "TARIFF")
                        If gdataset.Tables("TARIFF").Rows.Count > 0 Then
                            RATE = Val(gdataset.Tables("TARIFF").Rows(0).Item("RATE"))
                            TAXCODE = gdataset.Tables("TARIFF").Rows(0).Item("TAXCODE")
                        End If
                        SSQL = "INSERT INTO PARTY_RESTAURANT(UOM,LOCCODE,BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                        SSQL = SSQL & " ITEMCODE,QTY,RATE,AMOUNT,TAXCODE,TARIFFCODE,MAXITEMS,"
                        SSQL = SSQL & " TYPE,FREEZE,ADDUSERID,ADDDATETIME)"
                        SSQL = SSQL & " VALUES('NOS','" & Trim(CMB_LOCATION.Text) & "'," & TXTBOOKINGNO.Text
                        SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                        SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "','T'"
                        SSQL = SSQL & ",'" & TextNVTBOX.Text & "'"
                        SSQL = SSQL & "," & Val(TxtVOCCUPANCY.Text) & ""
                        SSQL = SSQL & "," & RATE & ""
                        SSQL = SSQL & "," & (Val(TxtNVOCCUPANCY.Text) * RATE) & ""
                        SSQL = SSQL & ",'" & TAXCODE & "'"
                        SSQL = SSQL & ",'" & TextNVTBOX.Text & "'"
                        SSQL = SSQL & "," & Val(Txt_Maxitems.Text) & ""
                        SSQL = SSQL & ",'NONVEG'"
                        SSQL = SSQL & ",'N'"
                        SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                        SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = SSQL

                        ''TAX INSERT START
                        'RATE = 0
                        Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                        GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                        SQLSTRING = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(TAXCODE) & "' "
                        GCONNECTION.getDataSet(SQLSTRING, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        QTY = Val(TxtNVOCCUPANCY.Text)
                        ChargeCode = TAXCODE
                        SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(SQLSTRING, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For J = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(J).Item("ItemTypeCode"))
                                TAXCODE = Trim(gdataset.Tables("TAXON").Rows(J).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(J).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")

                                SSQL = "INSERT INTO party_RESTAURANT_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TTYPE,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                                SSQL = SSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(TAXCODE) & "','" & Trim(Taxon) & "','" & Trim(TextNVTBOX.Text) & "'," & Val(RATE) & ",'" & Val(QTY) & "'," & (TPercent) & ",'NONVEG',"
                                If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                                    Zero = (RATE * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Zero) * QTY, "0.00")
                                    SSQL = SSQL & "" & Format(Val(Zero) * QTY, "0.00") & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(ZeroA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Format(Val(ZeroA) * QTY, "0.00") & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    SSQL = SSQL & "" & Format(Val(ZeroB) * QTY, "0.00") & ","
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(ZeroB) * QTY, "0.00")
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                                    One = ((RATE + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(One) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(One) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(OneA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(OneA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(OneB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(OneB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                                    Two = ((RATE + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Two) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(Two) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(TwoA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(TwoA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(TwoB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(TwoB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                                    Three = ((RATE + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Three) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(Three) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(GThreeA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(ThreeA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(GThreeB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(ThreeB) * QTY & ","
                                End If



                                SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = SSQL
                            Next
                            GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                            '.SetText(6, I, GrdTaxAmt)
                            '.SetText(8, I, GrdTaxAmt + rate)


                        End If

                        ''TAX INSERT END

                        For I = 1 To .DataRowCnt
                            .Col = 2
                            .Row = I
                            If (.Text <> "") Then

                                SSQL = "INSERT INTO PARTY_RESTAURANT_DET(BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                                SSQL = SSQL & " ITEMCODE,ITEMDESC,UOM,QTY,GROUPCODE,MENUCODE,TARIFFCODE,MAXITEMS,"
                                SSQL = SSQL & " FREEZE,ADDUSERID,ADDDATETIME)"
                                SSQL = SSQL & " VALUES(" & TXTBOOKINGNO.Text
                                SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                                SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "','NONVEG'"
                                .Col = 2
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 3
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 4
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 5
                                .Row = I
                                SSQL = SSQL & "," & Val(.Text) & ""
                                .Col = 6
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 7
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 1
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 9
                                .Row = I
                                SSQL = SSQL & "," & Val(.Text) & ""

                                SSQL = SSQL & ",'N'"
                                SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                                SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = SSQL
                            End If
                        Next
                    End If
                    SSQL = "UPDATE PARTY_RESTAURANT SET TAXAMOUNT=" & GRDTAXAMOUNT & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND TYPE='NONVEG'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "UPDATE PARTY_RESTAURANT SET TOTALAMOUNT=AMOUNT+TAXAMOUNT WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND TYPE='NONVEG'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "update PARTY_RESTAURANT set category=T.category from Party_TariffHdr T where PARTY_RESTAURANT.ITEMCODE=T.TARIFFCODE   and PARTY_RESTAURANT.bookingno='" & Me.TXTBOOKINGNO.Text & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "update PARTY_RESTAURANT set ITEMDESC=T.TARIFFDESC from Party_TariffHdr T where PARTY_RESTAURANT.ITEMCODE=T.TARIFFCODE   and PARTY_RESTAURANT.bookingno='" & Me.TXTBOOKINGNO.Text & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                End With

                GRDTAXAMOUNT = 0
                For I = 1 To SSGRID_ARRANGE.DataRowCnt
                    RATE = 0
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    With SSGRID_ARRANGE
                        .Col = 1
                        .Row = I
                        ITEMCODE = .Text

                        .Col = 4
                        .Row = I
                        RATE = Val(.Text)

                        .Col = 5
                        .Row = I
                        QTY = Val(.Text)

                        .Col = 9
                        .Row = I
                        ChargeCode = .Text

                        SQLSTRING = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                        GCONNECTION.getDataSet(SQLSTRING, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If

                        SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(SQLSTRING, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For J = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(J).Item("ItemTypeCode"))
                                TAXCODE = Trim(gdataset.Tables("TAXON").Rows(J).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(J).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")

                                SSQL = "INSERT INTO party_arrangement_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE,BOOKINGTYPE) VALUES ( "
                                SSQL = SSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(TAXCODE) & "','" & Trim(Taxon) & "','" & Trim(ITEMCODE) & "'," & Val(RATE) & ",'" & Val(QTY) & "'," & (TPercent) & ","
                                ' '' ''If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                                ' '' ''    Zero = (RATE * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GZero = GZero + Zero
                                ' '' ''    SSQL = SSQL & "" & Format(Val(Zero) * QTY, "0.00") & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                                ' '' ''    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GZeroA = GZeroA + ZeroA
                                ' '' ''    SSQL = SSQL & "" & Format(Val(ZeroA) * QTY, "0.00") & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                                ' '' ''    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GZeroB = GZeroB + ZeroB
                                ' '' ''    SSQL = SSQL & "" & Format(Val(ZeroB) * QTY, "0.00") & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                                ' '' ''    One = ((RATE + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GOne = GOne + One
                                ' '' ''    SSQL = SSQL & "" & Val(One) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                                ' '' ''    OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GOneA = GOneA + OneA
                                ' '' ''    SSQL = SSQL & "" & Val(OneA) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                                ' '' ''    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GOneB = GOneB + OneB
                                ' '' ''    SSQL = SSQL & "" & Val(OneB) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                                ' '' ''    Two = ((RATE + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GTwo = GTwo + Two
                                ' '' ''    SSQL = SSQL & "" & Val(Two) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                                ' '' ''    TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GTwoA = GTwoA + TwoA
                                ' '' ''    SSQL = SSQL & "" & Val(TwoA) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                                ' '' ''    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GTwoB = GTwoB + TwoB
                                ' '' ''    SSQL = SSQL & "" & Val(TwoB) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                                ' '' ''    Three = ((RATE + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GThree = GThree + Three
                                ' '' ''    SSQL = SSQL & "" & Val(Three) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                                ' '' ''    ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GThreeA = GThreeA + ThreeA
                                ' '' ''    SSQL = SSQL & "" & Val(ThreeA) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                                ' '' ''    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GThreeB = GThreeB + ThreeB
                                ' '' ''    SSQL = SSQL & "" & Val(ThreeB) * QTY & ","
                                ' '' ''End If
                                If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                                    Zero = (RATE * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Zero) * QTY, "0.00")
                                    SSQL = SSQL & "" & Format(Val(Zero) * QTY, "0.00") & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(ZeroA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Format(Val(ZeroA) * QTY, "0.00") & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    SSQL = SSQL & "" & Format(Val(ZeroB) * QTY, "0.00") & ","
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(ZeroB) * QTY, "0.00")
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                                    One = ((RATE + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(One) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(One) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(OneA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(OneA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(OneB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(OneB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                                    Two = ((RATE + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Two) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(Two) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(TwoA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(TwoA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(TwoB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(TwoB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                                    Three = ((RATE + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Three) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(Three) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(GThreeA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(ThreeA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(GThreeB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(ThreeB) * QTY & ","
                                End If

                                SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N','BILLING')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = SSQL
                            Next
                            GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                            .SetText(6, I, GrdTaxAmt)
                            .SetText(8, I, GrdTaxAmt + RATE)
                        End If

                        ''If Trim(MemGstNo) = "" And Trim(MemStCode) = ClubStateCode And FloodTaxCode <> "" Then
                        ''    SSQL = "INSERT INTO party_arrangement_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE,BOOKINGTYPE) VALUES ( "
                        ''    SSQL = SSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(FloodTaxCode) & "','0','" & Trim(ITEMCODE) & "'," & Val(RATE) & ",'" & Val(QTY) & "',1,"
                        ''    SSQL = SSQL & "" & Format(Val((RATE * 1) / 100) * QTY, "0.00") & ","
                        ''    SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N','BILLING')"
                        ''    ReDim Preserve INSERT(INSERT.Length)
                        ''    INSERT(INSERT.Length - 1) = SSQL
                        ''End If
                        If FApply = "YES" And FloodTaxCode <> "" Then
                            SSQL = "INSERT INTO party_arrangement_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE,BOOKINGTYPE) VALUES ( "
                            SSQL = SSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(FloodTaxCode) & "','0','" & Trim(ITEMCODE) & "'," & Val(RATE) & ",'" & Val(QTY) & "',1,"
                            SSQL = SSQL & "" & Format(Val((RATE * 1) / 100) * QTY, "0.00") & ","
                            SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N','BILLING')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = SSQL
                        End If

                    End With
                    SSQL = "UPDATE PARTY_ARRANGEMENT SET TAXAMOUNT=" & GRDTAXAMOUNT & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='BILLING' AND ITEMCODE='& ITEMCODE &'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "UPDATE PARTY_ARRANGEMENT SET TOTALAMOUNT=AMOUNT+TAXAMOUNT WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='BILLING' AND ITEMCODE='& ITEMCODE &' "
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL

                    ''SSQL = "UPDATE PARTY_ARRANGEMENT SET TAXAMOUNT = (SELECT ISNULL(SUM(party_arrangement_TAX.TAXAMOUNT),0) FROM party_arrangement_TAX WHERE PARTY_ARRANGEMENT.BOOKINGNO = party_arrangement_TAX.BOOKINGNO AND party_arrangement_TAX.ITEMCODE = PARTY_ARRANGEMENT.ITEMCODE AND ISNULL(party_arrangement_TAX.BOOKINGTYPE,'') = ISNULL(PARTY_ARRANGEMENT.BOOKINGTYPE,'') GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''))"
                    ''SSQL = SSQL & " WHERE PARTY_ARRANGEMENT.BOOKINGNO = '" & Trim(TXTBOOKINGNO.Text) & "' AND ISNULL(party_arrangement.BOOKINGTYPE,'') = 'BILLING' "
                    ''ReDim Preserve INSERT(INSERT.Length)
                    ''INSERT(INSERT.Length - 1) = SSQL

                    GRDTAXAMOUNT = 0

                Next

                ''If Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                ''    SSQL = "UPDATE PARTY_ARRANGEMENT SET TAXAMOUNT=" & GRDTAXAMOUNT & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='BILLING'"
                ''    ReDim Preserve INSERT(INSERT.Length)
                ''    INSERT(INSERT.Length - 1) = SSQL
                ''    SSQL = "UPDATE PARTY_ARRANGEMENT SET TOTALAMOUNT=AMOUNT+TAXAMOUNT WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='BILLING'"
                ''    ReDim Preserve INSERT(INSERT.Length)
                ''    INSERT(INSERT.Length - 1) = SSQL

                ''End If

                'RESTAURANT MENU
                'END
                If Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                    SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET BILLINGFLAG='Y',TARIFFCODE='" & Trim(TXT_TARIFF.Text) & "',MENUCODE='" & Trim(Lbl_Menu.Text) & "' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL

                ElseIf Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                    SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET BOOKINGFLAG='Y',TARIFFCODE='" & Trim(TXT_TARIFF.Text) & "',MENUCODE='" & Trim(Lbl_Menu.Text) & "' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL

                ElseIf Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                    'CANCEL-TARIFF
                    Dim HRS, OCC As Integer
                    Dim TRATE, CANRATE, CANAMT, CANHEAD, CANFROM, CANTO As Double
                    SSQL = "SELECT ISNULL(T.RATE,0)AS RATE,ISNULL(H.TARIFFCODE,'')AS TARIFF,H.BOOKINGDATE,H.PARTYDATE,ISNULL(P.OCCUPANCY,0)AS OCCUPANCY "
                    SSQL = SSQL & " FROM PARTY_HALLBOOKING_HDR H,"
                    SSQL = SSQL & " PARTY_HDR P,PARTY_TARIFFHDR T "
                    SSQL = SSQL & " WHERE H.BOOKINGNO=P.BOOKINGNO  AND P.LOCCODE=H.LOCCODE"
                    SSQL = SSQL & " AND H.TARIFFCODE = T.TARIFFCODE AND P.BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND P.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    SSQL = SSQL & " GROUP BY T.RATE,H.TARIFFCODE,H.BOOKINGDATE,H.PARTYDATE,P.OCCUPANCY"
                    GCONNECTION.getDataSet(SSQL, "book")
                    If gdataset.Tables("book").Rows.Count > 0 Then
                        HRS = DateDiff(DateInterval.Hour, gdataset.Tables("book").Rows(0).Item("PARTYDATE"), Now())
                        OCC = gdataset.Tables("book").Rows(0).Item("OCCUPANCY")
                        TRATE = gdataset.Tables("book").Rows(0).Item("RATE")
                    End If
                    SSQL = "SELECT ISNULL(CANCELFROM,0)AS CANCELFROM,ISNULL(CANCELTO,0)AS CANCELTO,ISNULL(CANCEL_AMT_PER,0)AS PERAMT,ISNULL(CANCEL_AMT_HEAD,0)AS HEADAMT,ISNULL(FIXEDAMOUNT,0)AS FIXAMT FROM PARTY_CANCELLATIONMASTER WHERE " & Val(HRS) & " BETWEEN CANCELFROM AND CANCELTO "
                    GCONNECTION.getDataSet(SSQL, "CANCEL")
                    If gdataset.Tables("CANCEL").Rows.Count > 0 Then
                        CANHEAD = gdataset.Tables("CANCEL").Rows(0).Item("HEADAMT")
                        CANRATE = gdataset.Tables("CANCEL").Rows(0).Item("FIXAMT")
                        CANFROM = gdataset.Tables("CANCEL").Rows(0).Item("CANCELFROM")
                        CANTO = gdataset.Tables("CANCEL").Rows(0).Item("CANCELTO")
                        CANAMT = (Val(OCC) * TRATE) + (Val(OCC) * Val(CANHEAD)) + Val(CANRATE)
                    End If

                    SSQL = " UPDATE  PARTY_HDR SET FREEZE='Y',HALLCANCELAMOUNT=" & Val(CANAMT) & ",FROMHRS=" & Val(CANFROM) & ",TOHRS=" & Val(CANTO) & ",CANCELDATE='" & Format(DateTime.Now, "dd/MMM/yyyy hh:mm:ss") & "' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)

                    SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET CANCELFLAG='Y',TARIFFCODE='" & Trim(TXT_TARIFF.Text) & "',MENUCODE='" & Trim(Lbl_Menu.Text) & "',FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)

                    SSQL = " UPDATE  PARTY_HALLBOOKING_DET SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)

                    SSQL = " UPDATE PARTY_RECEIPT SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)

                    'SSQL = " UPDATE  PARTY_HDR SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    'INSERT(INSERT.Length - 1) = SSQL
                    'ReDim Preserve INSERT(INSERT.Length)

                    SSQL = " UPDATE PARTY_RESTAURANT SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)

                    SSQL = " UPDATE PARTY_ARRANGEMENT SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)

                    SSQL = " UPDATE PARTY_HALLFACILITY SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)
                End If

                SSQL = "UPDATE PARTY_ARRANGEMENT SET TAXAMOUNT = (SELECT ISNULL(SUM(party_arrangement_TAX.TAXAMOUNT),0) FROM party_arrangement_TAX WHERE PARTY_ARRANGEMENT.BOOKINGNO = party_arrangement_TAX.BOOKINGNO AND party_arrangement_TAX.ITEMCODE = PARTY_ARRANGEMENT.ITEMCODE AND ISNULL(party_arrangement_TAX.BOOKINGTYPE,'') = ISNULL(PARTY_ARRANGEMENT.BOOKINGTYPE,'') and party_arrangement_TAX.TAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX IN ('VAT','SGST','SGST CESS')) GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''))"
                SSQL = SSQL & " WHERE PARTY_ARRANGEMENT.BOOKINGNO = '" & Trim(TXTBOOKINGNO.Text) & "' AND ISNULL(party_arrangement.BOOKINGTYPE,'') = 'BILLING' "
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = SSQL

                SSQL = "UPDATE PARTY_ARRANGEMENT SET SERTAX = (SELECT ISNULL(SUM(party_arrangement_TAX.TAXAMOUNT),0) FROM party_arrangement_TAX WHERE PARTY_ARRANGEMENT.BOOKINGNO = party_arrangement_TAX.BOOKINGNO AND party_arrangement_TAX.ITEMCODE = PARTY_ARRANGEMENT.ITEMCODE AND ISNULL(party_arrangement_TAX.BOOKINGTYPE,'') = ISNULL(PARTY_ARRANGEMENT.BOOKINGTYPE,'') and party_arrangement_TAX.TAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX IN ('SERVICE TAX','CGST','CGST CESS')) GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''))"
                SSQL = SSQL & " WHERE PARTY_ARRANGEMENT.BOOKINGNO = '" & Trim(TXTBOOKINGNO.Text) & "' AND ISNULL(party_arrangement.BOOKINGTYPE,'') = 'BILLING' "
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = SSQL

                ssqlstring = " update party_restaurant set SERTAX=(select SUM(taxamount) from party_RESTAURANT_TAX where party_restaurant.BOOKINGNO=party_restaurant_tax.BOOKINGNO and party_restaurant.ITEMCODE=party_RESTAURANT_TAX.ITEMCODE AND "
                ssqlstring = ssqlstring & "party_RESTAURANT_TAX.TAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX IN ('SERVICE TAX','CGST','CGST CESS')) )WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " " 'and BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = ssqlstring

                ssqlstring = "update party_restaurant set TAXAMOUNT=(select SUM(taxamount) from party_RESTAURANT_TAX where party_restaurant.BOOKINGNO=party_restaurant_tax.BOOKINGNO and party_restaurant.ITEMCODE=party_RESTAURANT_TAX.ITEMCODE AND "
                ssqlstring = ssqlstring & "party_RESTAURANT_TAX.TAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX IN ('VAT','SGST','SGST CESS')) )WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " " 'and BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = ssqlstring

                ''ssqlstring = "update party_arrangement set SERTAX=(select SUM(taxamount) from party_arrangement_TAX where party_arrangement.BOOKINGNO=party_arrangement_TAX.BOOKINGNO and party_arrangement.ITEMCODE=party_arrangement_TAX.ITEMCODE AND "
                ''ssqlstring = ssqlstring & "party_arrangement_TAX.TAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX='SERVICE TAX') )WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & "" ' and BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                ''ReDim Preserve INSERT(INSERT.Length)
                ''INSERT(INSERT.Length - 1) = ssqlstring

                ''ssqlstring = "update party_arrangement set TAXAMOUNT=(select SUM(taxamount) from party_arrangement_TAX where party_arrangement.BOOKINGNO=party_arrangement_TAX.BOOKINGNO and party_arrangement.ITEMCODE=party_arrangement_TAX.ITEMCODE AND "
                ''ssqlstring = ssqlstring & "party_arrangement_TAX.TAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX='VAT') )WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " " ' and BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' "
                ''ReDim Preserve INSERT(INSERT.Length)
                ''INSERT(INSERT.Length - 1) = ssqlstring


                GCONNECTION.dataOperation1(1, INSERT)
                '<---------------Update-----------------------> 
            ElseIf Mid(Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                    BOOLCHK = False
                End If
                Call checkValidation()

                If BOOLCHK = False Then Exit Sub
                SSQL = "UPDATE  PARTY_HDR SET "
                SSQL = SSQL & " LOCCODE='" & Trim(CMB_LOCATION.Text) & "',"
                SSQL = SSQL & " BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                'SSQL = SSQL & ",BOOKINGNO=" & Trim(TXTBOOKINGNO.Text)
                'SSQL = SSQL & ",BOOKINGDATE='" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                SSQL = SSQL & ",PARTYDATE='" & Format(DTPPARTYDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "'"
                SSQL = SSQL & ",FROMTIME='" & Trim(TXTFROMTIME.Text) & "'"
                SSQL = SSQL & ",TOTIME='" & Trim(TXTTOTIME.Text) & "'"
                SSQL = SSQL & ",MCODE='" & Trim(TXTMCODE.Text) & "'"
                SSQL = SSQL & ",ASSOCIATENAME='" & Trim(TXTASSOCIATENAME.Text) & "'"
                SSQL = SSQL & ",OCCUPANCY=" & Trim(TxtOCCUPANCY.Text)


                SSQL = SSQL & ",veg=" & Trim(TxtVOCCUPANCY.Text)
                SSQL = SSQL & ",nonveg=" & Trim(TxtNVOCCUPANCY.Text)
                SSQL = SSQL & ",DESCRIPTION='" & Trim(TXTDESCRIPTION.Text) & "'"
                SSQL = SSQL & ",GUESTNAME='" & Trim(TXTGUESTNAME.Text) & "'"
                'SSQL = SSQL & ",ADVANCE=" & Trim(TXTADVANCE.Text)
                'SSQL = SSQL & ",RECEIPTNO='" & Trim(TXTRECEIPTNO.Text) & "'"
                'SSQL = SSQL & ",RECEIPTDATE='" & Format(DTPRECEIPTDATE.Value, "dd/MMM/yyyy") & "'"
                SSQL = SSQL & ",HALLCODE='" & Trim(TXTHALLCODE.Text) & "'"
                SSQL = SSQL & ",HALLAMOUNT=" & IIf(Val(TXTHALLRENT.Text) > 0, Val(TXTHALLRENT.Text), 0)
                SSQL = SSQL & ",HALLTAXFLAG='" & IIf(CHBHALLTAX.Checked = True, "Y", "N") & "'"
                SSQL = SSQL & ",HALLTAXPERC=" & IIf(TAXPER > 0, TAXPER, 0)
                SSQL = SSQL & ",HALLTAXAMOUNT=" & IIf(Val(TAXAMOUNT) > 0, TAXAMOUNT, 0)
                SSQL = SSQL & ",ARRMENTAMOUNT=" & IIf(Val(TXTARRTOTALAMOUNT.Text) > 0, Val(TXTARRTOTALAMOUNT.Text), 0)
                SSQL = SSQL & ",RESTAMOUNT=" & IIf(Val(TXTRESTOTALAMOUNT.Text) > 0, Val(TXTRESTOTALAMOUNT.Text), 0)
                SSQL = SSQL & ",RESCANCELAMOUNT=" & IIf(Val(TXTRESCANCELAMT.Text) > 0, Val(TXTRESCANCELAMT.Text), 0)
                SSQL = SSQL & ",ARRCANCELAMOUNT=" & IIf(Val(TXTARRCANCELAMT.Text) > 0, Val(TXTARRCANCELAMT.Text), 0)
                SSQL = SSQL & ",HALLCANCELAMOUNT=" & IIf(Val(TXTHALLCANCELAMT.Text) > 0, Val(TXTHALLCANCELAMT.Text), 0)
                SSQL = SSQL & ", MENUCODE='" & Trim(TXT_MENU.Text) & "' WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                SSQL = SSQL & " AND BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' "
                INSERT(0) = SSQL

                If Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                    SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET BILLINGFLAG='Y',TARIFFCODE='" & Trim(TXT_TARIFF.Text) & "',MENUCODE='" & Trim(Lbl_Menu.Text) & "' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL

                ElseIf Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                    SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET BOOKINGFLAG='Y',TARIFFCODE='" & Trim(TXT_TARIFF.Text) & "',MENUCODE='" & Trim(Lbl_Menu.Text) & "' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL

                ElseIf Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then

                    'CANCEL-TARIFF
                    Dim HRS, OCC As Integer
                    Dim TRATE, CANRATE, CANAMT, CANHEAD, CANFROM, CANTO As Double
                    SSQL = "SELECT ISNULL(T.RATE,0)AS RATE,ISNULL(H.TARIFFCODE,'')AS TARIFF,H.BOOKINGDATE,ISNULL(P.OCCUPANCY,0)AS OCCUPANCY "
                    SSQL = SSQL & " FROM PARTY_HALLBOOKING_HDR H,"
                    SSQL = SSQL & " PARTY_HDR P,PARTY_TARIFFHDR T "
                    SSQL = SSQL & " WHERE H.BOOKINGNO=P.BOOKINGNO AND P.BOOKINGDATE=H.BOOKINGDATE AND "
                    SSQL = SSQL & " H.TARIFFCODE = T.TARIFFCODE AND H.BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND P.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    SSQL = SSQL & " GROUP BY T.RATE,H.TARIFFCODE,H.BOOKINGDATE,P.OCCUPANCY"
                    GCONNECTION.getDataSet(SSQL, "book")
                    If gdataset.Tables("book").Rows.Count > 0 Then
                        HRS = DateDiff(DateInterval.Hour, gdataset.Tables("book").Rows(0).Item("BOOKINGDATE"), Now())
                        OCC = gdataset.Tables("book").Rows(0).Item("OCCUPANCY")
                        TRATE = gdataset.Tables("book").Rows(0).Item("RATE")
                    End If
                    SSQL = "SELECT ISNULL(CANCELFROM,0)AS CANCELFROM,ISNULL(CANCELTO,0)AS CANCELTO,ISNULL(CANCEL_AMT_PER,0)AS PERAMT,ISNULL(CANCEL_AMT_HEAD,0)AS HEADAMT,ISNULL(FIXEDAMOUNT,0)AS FIXAMT FROM PARTY_CANCELLATIONMASTER WHERE " & Val(HRS) & " BETWEEN CANCELFROM AND CANCELTO "
                    GCONNECTION.getDataSet(SSQL, "CANCEL")
                    If gdataset.Tables("CANCEL").Rows.Count > 0 Then
                        CANHEAD = gdataset.Tables("CANCEL").Rows(0).Item("CANCEL_AMT_HEAD")
                        CANRATE = gdataset.Tables("CANCEL").Rows(0).Item("FIXEDAMOUNT")
                        CANFROM = gdataset.Tables("CANCEL").Rows(0).Item("CANCELFROM")
                        CANTO = gdataset.Tables("CANCEL").Rows(0).Item("CANCELTO")
                        CANAMT = (Val(OCC) * TRATE) + (Val(OCC) * Val(CANHEAD)) + Val(CANRATE)
                    End If

                    SSQL = " UPDATE  PARTY_HDR SET FREEZE='Y',HALLCANCELAMOUNT=" & Val(CANAMT) & ",FROMHRS=" & Val(CANFROM) & ",TOHRS=" & Val(CANTO) & ",CANCELDATE='" & Format(DateTime.Now, "dd/MMM/yyyy hh:mm:ss") & "' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)

                    SSQL = " UPDATE  PARTY_HALLBOOKING_HDR SET CANCELFLAG='Y',TARIFFCODE='" & Trim(TXT_TARIFF.Text) & "',MENUCODE='" & Trim(Lbl_Menu.Text) & "',FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)

                    SSQL = " UPDATE  PARTY_HALLBOOKING_DET SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)

                    SSQL = " UPDATE PARTY_RECEIPT SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)

                    SSQL = " UPDATE PARTY_RESTAURANT SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)

                    SSQL = " UPDATE PARTY_ARRANGEMENT SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)

                    SSQL = " UPDATE PARTY_HALLFACILITY SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = SSQL
                    ReDim Preserve INSERT(INSERT.Length)
                End If
                SSQL = " SELECT Autoid AS Autoid,Kotdetails AS Kotdetails,Kotdate AS Kotdate,ISNULL(Billdetails,'') AS Billdetails,Taxcode,Itemcode,ISNULL(QTY,0) QTY FROM PARTY_KOT_DET WHERE KOTDETAILS  = '" & Trim(TXTBOOKINGNO.Text) & "'"
                GCONNECTION.getDataSet(SSQL, "TEMPKOTDET")
                Dim I, Z As Integer
                If gdataset.Tables("TEMPKOTDET").Rows.Count > 0 Then
                    For Z = 0 To gdataset.Tables("TEMPKOTDET").Rows.Count - 1
                        For I = 1 To SSGRID.DataRowCnt
                            SSGRID.Row = I
                            SSGRID.Col = 18
                            If Val(SSGRID.Text) = Val(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("Autoid")) Then
                                '''******************************************************** UPDATE INTO KOT_DET ******************************************************'''
                                SQLSTRING = "UPDATE PARTY_KOT_DET SET BOOKINGTYPE='BILLING',KotType = 'PAR',kotdate='" & Format(CDate(DTPBOOKINGDATE.Value), "dd-MMM-yyyy ") & "',PaymentMode= 'PARTY' ,"
                                SQLSTRING = SQLSTRING & " Mcode = '" & Trim(TXTMCODE.Text) & "',Scode = '',Covers =0,TableNo = 0,"

                                SQLSTRING = SQLSTRING & " TotAmt= " & Val(0) & ",PackAmt = " & Val(0) & " ,TaxAmt= " & Val(0) & ",DiscAmt =0, BillAmt= " & Val(0) & ",ChkId= " & Val(0) & " "

                                SSGRID.Row = I
                                SSGRID.Col = 1
                                SQLSTRING = SQLSTRING & ",MKOTNO='" & Trim(SSGRID.Text) & "'"
                                SSGRID.Col = 2
                                SQLSTRING = SQLSTRING & ",ItemCode='" & Trim(SSGRID.Text) & "'"
                                SSGRID.Col = 3
                                SQLSTRING = SQLSTRING & ",Itemdesc='" & Trim(SSGRID.Text) & "'"
                                SSGRID.Col = 4
                                SQLSTRING = SQLSTRING & ",Poscode='" & Trim(SSGRID.Text) & "'"
                                SSGRID.Col = 5
                                SQLSTRING = SQLSTRING & ",Uom= '" & Trim(SSGRID.Text) & "'"
                                SSGRID.Col = 6
                                SQLSTRING = SQLSTRING & ",Qty= " & Val(SSGRID.Text) & ""
                                SSGRID.Col = 7
                                SQLSTRING = SQLSTRING & ",Rate= " & Val(SSGRID.Text) & ""
                                SSGRID.Col = 8
                                SQLSTRING = SQLSTRING & ",Taxamount= " & Val(SSGRID.Text) & ""
                                SSGRID.Col = 9
                                SQLSTRING = SQLSTRING & ",Amount = " & Val(SSGRID.Text) & ""
                                SSGRID.Col = 10
                                SQLSTRING = SQLSTRING & ",ItemType ='" & Trim(SSGRID.Text) & "'"
                                SSGRID.Col = 11
                                SQLSTRING = SQLSTRING & ",TaxCode='" & Trim(SSGRID.Text) & "'"
                                SSGRID.Col = 12
                                SQLSTRING = SQLSTRING & ",TaxPerc =" & Val(SSGRID.Text) & " "
                                SSGRID.Col = 14
                                SQLSTRING = SQLSTRING & ",TaxAccountCode = '" & Trim(SSGRID.Text) & "' "
                                SSGRID.Col = 15
                                SQLSTRING = SQLSTRING & ",SalesAccountCode = '" & Trim(SSGRID.Text) & "' "
                                SSGRID.Col = 16
                                SQLSTRING = SQLSTRING & ",GroupCode = '" & Trim(SSGRID.Text) & "' "
                                SSGRID.Col = 17
                                SQLSTRING = SQLSTRING & ",SUBGroupCode ='" & Trim(SSGRID.Text) & "' "
                                SSGRID.Col = 19
                                SQLSTRING = SQLSTRING & ",Openfacilityst ='" & Trim(SSGRID.Text) & "' "
                                SSGRID.Col = 20
                                SQLSTRING = SQLSTRING & ",Promotionalst ='" & Trim(SSGRID.Text) & "' "
                                SSGRID.Col = 10
                                If Trim(SSGRID.Text) = "BAR" Then
                                    SQLSTRING = SQLSTRING & ",Taxtype = '',Alcholst = 'Y'"
                                ElseIf Trim(SSGRID.Text) = "SD" Then
                                    SQLSTRING = SQLSTRING & ",Taxtype = 'SALES',Alcholst ='S'"
                                Else
                                    SQLSTRING = SQLSTRING & ",Taxtype = 'SALES',Alcholst ='N'"
                                End If
                                SQLSTRING = SQLSTRING & ",Upduserid = '" & Trim(gUsername) & "',Upddatetime = '" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                                SSGRID.Col = 13
                                If Trim(SSGRID.Text) = "Yes" Then
                                    SQLSTRING = SQLSTRING & "KOTStatus='Y',DELFLAG = 'N'"
                                Else
                                    SQLSTRING = SQLSTRING & "KOTStatus='N',DELFLAG = 'N'"
                                End If
                                SQLSTRING = SQLSTRING & " WHERE  AUTOID = " & Val(gdataset.Tables("TEMPKOTDET").Rows(Z).Item("AUTOID")) & ""
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = SQLSTRING


                            End If

                        Next I
                    Next Z
                End If
                For I = 1 To SSGRID.DataRowCnt
                    SSGRID.Row = I
                    SSGRID.Col = 18
                    If Val(SSGRID.Text) = 0 Then
                        SQLSTRING = "INSERT INTO PARTY_KOT_DET(BOOKINGTYPE,KotNo,KOTdetails,KotDate,Billdetails,KotType,PaymentMode,Mcode,Scode,Covers,TableNo,TotAmt,TaxAmt,PackAmt,DiscAmt,BillAmt,ChkId,MKOTNO,ItemCode,Itemdesc,Poscode,Uom,Qty,Rate,Taxamount,Amount,ItemType,TaxCode,TaxPerc,TaxAccountCode,SalesAccountCode,GroupCode,SUBGROUPCODE,"
                        SQLSTRING = SQLSTRING & "Openfacilityst,Promotionalst,Taxtype,Alcholst,Adduserid,Adddatetime,Upduserid,Upddatetime,KOTStatus,Delflag,PDA_PRINT_FLAG,PDA_DELETE_FLAG,IS_PDA) "
                        SQLSTRING = SQLSTRING & " VALUES('BILLING','" & Trim(CStr(TXTBOOKINGNO.Text)) & "','" & Trim(CStr(TXTBOOKINGNO.Text)) & "','" & Format(DTPBOOKINGDATE.Value, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(CStr(TXTBOOKINGNO.Text)) & "','PAR','PARTY',"
                        SQLSTRING = SQLSTRING & " '" & Trim(TXTMCODE.Text) & "','',0,0," & Val(0) & "," & Val(0) & "," & Val(0) & ",0," & Val(0) & ",0"
                        SSGRID.Row = I
                        SSGRID.Col = 1
                        SQLSTRING = SQLSTRING & ",'" & Trim(SSGRID.Text) & "'"
                        SSGRID.Col = 2
                        SQLSTRING = SQLSTRING & ",'" & Trim(SSGRID.Text) & "'"
                        SSGRID.Col = 3
                        SQLSTRING = SQLSTRING & ",'" & Trim(SSGRID.Text) & "'"
                        SSGRID.Col = 4
                        SQLSTRING = SQLSTRING & ",'" & Trim(SSGRID.Text) & "'"
                        SSGRID.Col = 5
                        SQLSTRING = SQLSTRING & ",'" & Trim(SSGRID.Text) & "'"
                        SSGRID.Col = 6
                        SQLSTRING = SQLSTRING & "," & Val(SSGRID.Text) & ""
                        SSGRID.Col = 7
                        SQLSTRING = SQLSTRING & "," & Val(SSGRID.Text) & ""
                        POS_RATE_GBL = Val(SSGRID.Text)
                        SSGRID.Col = 8
                        SQLSTRING = SQLSTRING & "," & Val(SSGRID.Text) & ""
                        SSGRID.Col = 9
                        SQLSTRING = SQLSTRING & "," & Val(SSGRID.Text) & ""
                        SSGRID.Col = 10
                        SQLSTRING = SQLSTRING & ",'" & Trim(SSGRID.Text) & "'"
                        SSGRID.Col = 11
                        SQLSTRING = SQLSTRING & ",'" & Trim(SSGRID.Text) & "'"
                        SSGRID.Col = 12
                        SQLSTRING = SQLSTRING & "," & Val(SSGRID.Text) & " "
                        SSGRID.Col = 14
                        SQLSTRING = SQLSTRING & ",'" & Trim(SSGRID.Text) & "' "
                        SSGRID.Col = 15
                        SQLSTRING = SQLSTRING & ",'" & Trim(SSGRID.Text) & "' "
                        SSGRID.Col = 16
                        SQLSTRING = SQLSTRING & ",'" & Trim(SSGRID.Text) & "' "
                        SSGRID.Col = 17
                        SQLSTRING = SQLSTRING & ",'" & Trim(SSGRID.Text) & "' "
                        SSGRID.Col = 19
                        SQLSTRING = SQLSTRING & ",'" & Trim(SSGRID.Text) & "' "
                        SSGRID.Col = 20
                        SQLSTRING = SQLSTRING & ",'" & Trim(SSGRID.Text) & "'"
                        SSGRID.Col = 10
                        If Trim(SSGRID.Text) = "BAR" Then
                            SQLSTRING = SQLSTRING & ",'','Y'"
                        ElseIf Trim(SSGRID.Text) = "SD" Then
                            SQLSTRING = SQLSTRING & ",'SALES','S'"
                        Else
                            SQLSTRING = SQLSTRING & ",'SALES','N'"
                        End If
                        SQLSTRING = SQLSTRING & ",'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                        SSGRID.Col = 13
                        If Trim(SSGRID.Text) = "Yes" Then
                            SQLSTRING = SQLSTRING & ",'Y','N','','','')"
                        Else
                            SQLSTRING = SQLSTRING & ",'N','N','','','')"
                        End If
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = SQLSTRING

                    End If

                Next
                SSQL = "DELETE FROM PARTY_KOT_DET_TAX WHERE KOTDETAILS = '" & Trim(TXTBOOKINGNO.Text) & "' "
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = SSQL

                For I = 1 To SSGRID.DataRowCnt
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    With SSGRID
                        .Col = 2
                        .Row = I
                        ITEMCODE = Trim(.Text)
                        .Col = 7
                        .Row = I
                        GrdRate = Val(.Text)
                        .Col = 6
                        .Row = I
                        QTY = Val(.Text)
                        .Col = 4
                        .Row = I
                        POS = Trim(.Text)
                        .Col = 13
                        .Row = I
                        KStatus = Mid(Trim(.Text), 1, 1)
                        .Col = 10
                        .Row = I
                        ChargeCode = Trim(.Text)
                        SSQL = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                        GCONNECTION.getDataSet(SSQL, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        SSQL = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(SSQL, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For J = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(J).Item("ItemTypeCode"))
                                TAXCODE = Trim(gdataset.Tables("TAXON").Rows(J).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(J).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")

                                SSQL = "INSERT INTO PARTY_KOT_DET_TAX (KOTDETAILS,KOTDATE,TTYPE,CHARGECODE,TYPE_CODE,POSCODE,ITEMCODE,KOTSTATUS,TAXCODE,TAXON,RATE,QTY,TAXPERCENT,TAXAMT,ADD_USER,ADD_DATE,VOID,VOIDUSER) VALUES ( "
                                SSQL = SSQL & "'" & Trim(TXTBOOKINGNO.Text) & "','" & Format(DTPBOOKINGDATE.Value, "dd-MMM-yyyy") & "','p','" & Trim(ChargeCode) & "','" & Trim(IType) & "','" & Trim(POS) & "','" & Trim(ITEMCODE) & "','" & Trim(KStatus) & "','" & Trim(TAXCODE) & "','" & Trim(Taxon) & "'," & (GrdRate) & "," & (QTY) & "," & (TPercent) & ","

                                If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                                    Zero = (GrdRate * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    SSQL = SSQL & "" & Val(Zero) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    SSQL = SSQL & "" & Val(ZeroA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    SSQL = SSQL & "" & Val(ZeroB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                                    One = ((GrdRate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    SSQL = SSQL & "" & Val(One) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    SSQL = SSQL & "" & Val(OneA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    SSQL = SSQL & "" & Val(OneB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                                    Two = ((GrdRate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    SSQL = SSQL & "" & Val(Two) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    SSQL = SSQL & "" & Val(TwoA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    SSQL = SSQL & "" & Val(TwoB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                                    Three = ((GrdRate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    SSQL = SSQL & "" & Val(Three) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    SSQL = SSQL & "" & Val(ThreeA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    SSQL = SSQL & "" & Val(ThreeB) * QTY & ","
                                End If
                                SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N','')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = SSQL
                            Next
                        End If
                    End With
                Next
                For I = 1 To SSGRID.DataRowCnt
                    With SSGRID
                        .Col = 2
                        .Row = I
                        ITEMCODE = Trim(.Text)
                        .Col = 6
                        .Row = I
                        QTY = Val(.Text)
                        .Col = 9
                        .Row = I
                        GAmt = Val(.Text)
                        If gCenterlized = "N" Then
                            TPackAmt = Val((GAmt * gPackPer) / 100)
                            TTipsAmt = Val((GAmt * gTipsPer) / 100)
                            TAdchgAmt = Val((GAmt * gAdCgsPer) / 100)

                            TPartyAmt = Val((GAmt * gPartyPer) / 100)
                            PartyPer = gPartyPer


                            RoomPer = 0
                            TRoomAmt = 0

                        Else
                            TPackAmt = Val((GAmt * pPackPer) / 100)
                            TTipsAmt = Val((GAmt * pTipsPer) / 100)
                            TAdchgAmt = Val((GAmt * pAdCgsPer) / 100)

                            TPartyAmt = Val((GAmt * pPartyPer) / 100)
                            PartyPer = pPartyPer


                            RoomPer = 0
                            TRoomAmt = 0

                        End If
                        If gCenterlized = "N" Then
                            SSQL = "UPDATE PARTY_KOT_DET SET PACKPERCENT = " & gPackPer & ",PACKAMOUNT =  " & TPackAmt & ",TipsPer= " & gTipsPer & ",TipsAmt= " & TTipsAmt & ",AdCgsPer= " & gAdCgsPer & ",AdCgsAmt= " & TAdchgAmt & ",PartyPer = " & PartyPer & ",PartyAmt= " & TPartyAmt & " ,RoomPer = " & RoomPer & ",RoomAmt = " & TRoomAmt & " "
                            SSQL = SSQL & " WHERE KOTDETAILS = '" & Trim(TXTBOOKINGNO.Text) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "'"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = SSQL
                        Else
                            SSQL = "UPDATE PARTY_KOT_DET SET PACKPERCENT = " & pPackPer & ",PACKAMOUNT =  " & TPackAmt & ",TipsPer= " & pTipsPer & ",TipsAmt= " & TTipsAmt & ",AdCgsPer= " & pAdCgsPer & ",AdCgsAmt= " & TAdchgAmt & ",PartyPer = " & PartyPer & ",PartyAmt= " & TPartyAmt & " ,RoomPer = " & RoomPer & ",RoomAmt = " & TRoomAmt & " "
                            SSQL = SSQL & " WHERE KOTDETAILS = '" & Trim(TXTBOOKINGNO.Text) & "' AND ITEMCODE = '" & Trim(ITEMCODE) & "'"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = SSQL
                        End If
                    End With
                Next
                With SSGRID_HALL

                    If .DataRowCnt > 0 Then
                        SSQL = " DELETE FROM PARTY_HALLFACILITY "
                        SSQL = SSQL & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                        SSQL = SSQL & " AND BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = SSQL
                        For I = 1 To .DataRowCnt
                            UOM = "" : ITEMDESC = "" : QTY = 0 : SSQL = ""
                            .Row = I
                            .Col = 1
                            ITEMDESC = Trim(.Text)
                            .Row = I
                            .Col = 3
                            QTY = IIf(Val(.Text) > 0, Val(.Text), 0)
                            SSQL = "INSERT INTO PARTY_HALLFACILITY(LOCCODE,HALLCODE,BOOKINGTYPE,BOOKINGNO,"
                            SSQL = SSQL & "ITEMCODE,ITEMDESCRIPTION,QTY,FREEZE,ADDUSERID,ADDDATETIME)"
                            SSQL = SSQL & " values('" & Trim(CMB_LOCATION.Text) & "','" & Trim(TXTHALLCODE.Text) & "'"
                            SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "'"
                            SSQL = SSQL & "," & TXTBOOKINGNO.Text
                            SSQL = SSQL & ",''"
                            SSQL = SSQL & ",'" & ITEMDESC & "'"
                            SSQL = SSQL & "," & IIf(QTY > 0, QTY, 0)
                            SSQL = SSQL & ",'N'"
                            SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                            SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = SSQL
                        Next
                    End If
                End With


                ' '' ''For I = 1 To SSGRID_ARRANGE.DataRowCnt
                ' '' ''    RATE = 0
                ' '' ''    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                ' '' ''    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                ' '' ''    With SSGRID_ARRANGE
                ' '' ''        .Col = 1
                ' '' ''        .Row = I
                ' '' ''        ITEMCODE = .Text

                ' '' ''        .Col = 4
                ' '' ''        .Row = I
                ' '' ''        RATE = Val(.Text)

                ' '' ''        .Col = 5
                ' '' ''        .Row = I
                ' '' ''        QTY = Val(.Text)

                ' '' ''        .Col = 9
                ' '' ''        .Row = I
                ' '' ''        ChargeCode = .Text

                ' '' ''        SQLSTRING = "SELECT isnull(TAXTypecode,'') FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                ' '' ''        GCONNECTION.getDataSet(SQLSTRING, "CODE_CHECK")
                ' '' ''        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                ' '' ''            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                ' '' ''        End If

                ' '' ''        SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                ' '' ''        GCONNECTION.getDataSet(SQLSTRING, "TAXON")
                ' '' ''        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                ' '' ''            For J = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                ' '' ''                IType = Trim(gdataset.Tables("TAXON").Rows(J).Item("ItemTypeCode"))
                ' '' ''                TAXCODE = Trim(gdataset.Tables("TAXON").Rows(J).Item("TaxCode"))
                ' '' ''                Taxon = Trim(gdataset.Tables("TAXON").Rows(J).Item("TAXON"))
                ' '' ''                TPercent = gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")

                ' '' ''                SSQL = "INSERT INTO party_arrangement_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                ' '' ''                SSQL = SSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(TAXCODE) & "','" & Trim(Taxon) & "','" & Trim(ITEMCODE) & "'," & Val(RATE) & ",'" & Val(QTY) & "'," & (TPercent) & ","
                ' '' ''                If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                ' '' ''                    Zero = (RATE * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                ' '' ''                    GZero = GZero + Zero
                ' '' ''                    SSQL = SSQL & "" & Format(Val(Zero) * QTY, "0.00") & ","
                ' '' ''                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                ' '' ''                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                ' '' ''                    GZeroA = GZeroA + ZeroA
                ' '' ''                    SSQL = SSQL & "" & Format(Val(ZeroA) * QTY, "0.00") & ","
                ' '' ''                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                ' '' ''                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                ' '' ''                    GZeroB = GZeroB + ZeroB
                ' '' ''                    SSQL = SSQL & "" & Format(Val(ZeroB) * QTY, "0.00") & ","
                ' '' ''                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                ' '' ''                    One = ((RATE + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                ' '' ''                    GOne = GOne + One
                ' '' ''                    SSQL = SSQL & "" & Val(One) * QTY & ","
                ' '' ''                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                ' '' ''                    OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                ' '' ''                    GOneA = GOneA + OneA
                ' '' ''                    SSQL = SSQL & "" & Val(OneA) * QTY & ","
                ' '' ''                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                ' '' ''                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                ' '' ''                    GOneB = GOneB + OneB
                ' '' ''                    SSQL = SSQL & "" & Val(OneB) * QTY & ","
                ' '' ''                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                ' '' ''                    Two = ((RATE + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                ' '' ''                    GTwo = GTwo + Two
                ' '' ''                    SSQL = SSQL & "" & Val(Two) * QTY & ","
                ' '' ''                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                ' '' ''                    TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                ' '' ''                    GTwoA = GTwoA + TwoA
                ' '' ''                    SSQL = SSQL & "" & Val(TwoA) * QTY & ","
                ' '' ''                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                ' '' ''                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                ' '' ''                    GTwoB = GTwoB + TwoB
                ' '' ''                    SSQL = SSQL & "" & Val(TwoB) * QTY & ","
                ' '' ''                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                ' '' ''                    Three = ((RATE + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                ' '' ''                    GThree = GThree + Three
                ' '' ''                    SSQL = SSQL & "" & Val(Three) * QTY & ","
                ' '' ''                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                ' '' ''                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                ' '' ''                    GThreeA = GThreeA + ThreeA
                ' '' ''                    SSQL = SSQL & "" & Val(ThreeA) * QTY & ","
                ' '' ''                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                ' '' ''                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                ' '' ''                    GThreeB = GThreeB + ThreeB
                ' '' ''                    SSQL = SSQL & "" & Val(ThreeB) * QTY & ","
                ' '' ''                End If


                ' '' ''                SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N')"
                ' '' ''                ReDim Preserve INSERT(INSERT.Length)
                ' '' ''                INSERT(INSERT.Length - 1) = SSQL
                ' '' ''            Next
                ' '' ''            GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                ' '' ''            '.SetText(6, I, GrdTaxAmt)
                ' '' ''            '.SetText(8, I, GrdTaxAmt + rate)
                ' '' ''        End If
                ' '' ''    End With
                ' '' ''Next
                '  ARRANGEMENT(DETAILS)
                ' BEGIN()
                With SSGRID_ARRANGE
                    SSQL = " DELETE FROM PARTY_ARRANGEMENT "
                    SSQL = SSQL & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                    SSQL = SSQL & " AND BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    If .DataRowCnt > 0 Then
                        For I = 1 To .DataRowCnt
                            UOM = "" : ITEMDESC = "" : QTY = 0 : TAXPER = 0 : SSQL = "" : ITEMCODE = "" : RATE = 0 : TAXAMOUNT = 0 : AMOUNT = 0 : CAMOUNT = 0
                            .Row = I
                            .Col = 1
                            ITEMCODE = Trim(.Text)

                            .Row = I
                            .Col = 2
                            ITEMDESC = Trim(.Text)

                            .Row = I
                            .Col = 3
                            UOM = Trim(.Text)

                            .Row = I
                            .Col = 4
                            RATE = Trim(.Text)

                            .Row = I
                            .Col = 5
                            QTY = IIf(Val(.Text) > 0, Val(.Text), 0)

                            .Row = I
                            .Col = 6
                            TAXAMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)

                            .Row = I
                            .Col = 7
                            AMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)

                            .Row = I
                            .Col = 8
                            totalamount = IIf(Val(.Text) > 0, Val(.Text), 0)

                            .Row = I
                            .Col = 9
                            CAMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)

                            .Row = I
                            .Col = 10
                            ROUNDOFF = IIf(Val(.Text) <> 0, Val(.Text), 0)

                            .Row = I
                            .Col = 11
                            TAXPER = Trim(.Text)

                            SSQL = "Insert Into PARTY_ARRANGEMENT(LOCCODE,BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,"
                            SSQL = SSQL & " ITEMCODE,QTY,RATE,TAXAMOUNT,AMOUNT,totalamount,CANCELAMOUNT,"
                            SSQL = SSQL & " TAXPERC,ROUNDOFF,"
                            SSQL = SSQL & " FREEZE,ADDUSERID,ADDDATETIME)"
                            SSQL = SSQL & " Values('" & Trim(CMB_LOCATION.Text) & "'," & TXTBOOKINGNO.Text
                            SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                            SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "'"
                            SSQL = SSQL & ",'" & ITEMCODE & "'"
                            SSQL = SSQL & "," & IIf(QTY > 0, QTY, 0)
                            SSQL = SSQL & "," & IIf(RATE > 0, RATE, 0)
                            SSQL = SSQL & "," & IIf(TAXAMOUNT > 0, TAXAMOUNT, 0)
                            SSQL = SSQL & "," & IIf(AMOUNT > 0, AMOUNT, 0)
                            SSQL = SSQL & "," & IIf(totalamount > 0, totalamount, 0)
                            SSQL = SSQL & "," & IIf(CAMOUNT > 0, CAMOUNT, 0)
                            SSQL = SSQL & "," & IIf(TAXPER > 0, TAXPER, 0)
                            SSQL = SSQL & "," & ROUNDOFF
                            SSQL = SSQL & ",'N'"
                            SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                            SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = SSQL
                        Next
                    End If
                End With

                GRDTAXAMOUNT = 0

                SSQL = " DELETE FROM party_arrangement_TAX "
                SSQL = SSQL & " WHERE BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " "
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = SSQL

                For I = 1 To SSGRID_ARRANGE.DataRowCnt
                    RATE = 0
                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    With SSGRID_ARRANGE
                        .Col = 1
                        .Row = I
                        ITEMCODE = .Text

                        .Col = 4
                        .Row = I
                        RATE = Val(.Text)

                        .Col = 5
                        .Row = I
                        QTY = Val(.Text)

                        .Col = 9
                        .Row = I
                        ChargeCode = .Text

                        SQLSTRING = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                        GCONNECTION.getDataSet(SQLSTRING, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If

                        SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(SQLSTRING, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For J = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(J).Item("ItemTypeCode"))
                                TAXCODE = Trim(gdataset.Tables("TAXON").Rows(J).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(J).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")

                                SSQL = "INSERT INTO party_arrangement_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE,BOOKINGTYPE) VALUES ( "
                                SSQL = SSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(TAXCODE) & "','" & Trim(Taxon) & "','" & Trim(ITEMCODE) & "'," & Val(RATE) & ",'" & Val(QTY) & "'," & (TPercent) & ","
                                ' '' ''If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                                ' '' ''    Zero = (RATE * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GZero = GZero + Zero
                                ' '' ''    SSQL = SSQL & "" & Format(Val(Zero) * QTY, "0.00") & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                                ' '' ''    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GZeroA = GZeroA + ZeroA
                                ' '' ''    SSQL = SSQL & "" & Format(Val(ZeroA) * QTY, "0.00") & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                                ' '' ''    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GZeroB = GZeroB + ZeroB
                                ' '' ''    SSQL = SSQL & "" & Format(Val(ZeroB) * QTY, "0.00") & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                                ' '' ''    One = ((RATE + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GOne = GOne + One
                                ' '' ''    SSQL = SSQL & "" & Val(One) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                                ' '' ''    OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GOneA = GOneA + OneA
                                ' '' ''    SSQL = SSQL & "" & Val(OneA) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                                ' '' ''    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GOneB = GOneB + OneB
                                ' '' ''    SSQL = SSQL & "" & Val(OneB) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                                ' '' ''    Two = ((RATE + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GTwo = GTwo + Two
                                ' '' ''    SSQL = SSQL & "" & Val(Two) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                                ' '' ''    TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GTwoA = GTwoA + TwoA
                                ' '' ''    SSQL = SSQL & "" & Val(TwoA) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                                ' '' ''    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GTwoB = GTwoB + TwoB
                                ' '' ''    SSQL = SSQL & "" & Val(TwoB) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                                ' '' ''    Three = ((RATE + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GThree = GThree + Three
                                ' '' ''    SSQL = SSQL & "" & Val(Three) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                                ' '' ''    ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GThreeA = GThreeA + ThreeA
                                ' '' ''    SSQL = SSQL & "" & Val(ThreeA) * QTY & ","
                                ' '' ''ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                                ' '' ''    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                ' '' ''    GThreeB = GThreeB + ThreeB
                                ' '' ''    SSQL = SSQL & "" & Val(ThreeB) * QTY & ","
                                ' '' ''End If
                                If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                                    Zero = (RATE * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Zero) * QTY, "0.00")
                                    SSQL = SSQL & "" & Format(Val(Zero) * QTY, "0.00") & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(ZeroA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Format(Val(ZeroA) * QTY, "0.00") & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    SSQL = SSQL & "" & Format(Val(ZeroB) * QTY, "0.00") & ","
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(ZeroB) * QTY, "0.00")
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                                    One = ((RATE + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(One) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(One) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(OneA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(OneA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(OneB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(OneB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                                    Two = ((RATE + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Two) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(Two) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(TwoA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(TwoA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(TwoB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(TwoB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                                    Three = ((RATE + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Three) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(Three) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(GThreeA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(ThreeA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(GThreeB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(ThreeB) * QTY & ","
                                End If


                                SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N','BILLING')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = SSQL
                            Next
                            GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                            '.SetText(6, I, GrdTaxAmt)
                            '.SetText(8, I, GrdTaxAmt + rate)
                        End If

                        ''If Trim(MemGstNo) = "" And Trim(MemStCode) = ClubStateCode And FloodTaxCode <> "" Then
                        ''    SSQL = "INSERT INTO party_arrangement_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE,BOOKINGTYPE) VALUES ( "
                        ''    SSQL = SSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(FloodTaxCode) & "','0','" & Trim(ITEMCODE) & "'," & Val(RATE) & ",'" & Val(QTY) & "',1,"
                        ''    SSQL = SSQL & "" & Format(Val((RATE * 1) / 100) * QTY, "0.00") & ","
                        ''    SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N','BILLING')"
                        ''    ReDim Preserve INSERT(INSERT.Length)
                        ''    INSERT(INSERT.Length - 1) = SSQL
                        ''End If
                        If FApply = "YES" And FloodTaxCode <> "" Then
                            SSQL = "INSERT INTO party_arrangement_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE,BOOKINGTYPE) VALUES ( "
                            SSQL = SSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(FloodTaxCode) & "','0','" & Trim(ITEMCODE) & "'," & Val(RATE) & ",'" & Val(QTY) & "',1,"
                            SSQL = SSQL & "" & Format(Val((RATE * 1) / 100) * QTY, "0.00") & ","
                            SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N','BILLING')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = SSQL
                        End If

                    End With
                    SSQL = "UPDATE PARTY_ARRANGEMENT SET TAXAMOUNT=" & GRDTAXAMOUNT & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='BILLING' AND ITEMCODE='&ITEMCODE&'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "UPDATE PARTY_ARRANGEMENT SET TOTALAMOUNT=AMOUNT+TAXAMOUNT WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='BILLING'AND ITEMCODE='&ITEMCODE&'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    GRDTAXAMOUNT = 0
                Next

                'If Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                '    SSQL = "UPDATE PARTY_ARRANGEMENT SET TAXAMOUNT=" & GRDTAXAMOUNT & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='BILLING'"
                '    ReDim Preserve INSERT(INSERT.Length)
                '    INSERT(INSERT.Length - 1) = SSQL
                '    SSQL = "UPDATE PARTY_ARRANGEMENT SET TOTALAMOUNT=AMOUNT+TAXAMOUNT WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND BOOKINGTYPE='BILLING'"
                '    ReDim Preserve INSERT(INSERT.Length)
                '    INSERT(INSERT.Length - 1) = SSQL
                'End If

                'Call ARRANGEcalculate1()
                'ARRANGEMENT DETAILS
                'END

                'Call ARRANGEcalculate1()
                'START LOGAN 12-06-12
                'With SSGRID_ARRANGE
                '    SSQL = " DELETE FROM PARTY_ARRANGEMENT "
                '    SSQL = SSQL & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                '    SSQL = SSQL & " AND BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                '    ReDim Preserve INSERT(INSERT.Length)
                '    INSERT(INSERT.Length - 1) = SSQL

                '    If .DataRowCnt > 0 Then

                '        For I = 1 To .DataRowCnt
                '            UOM = "" : ITEMDESC = "" : QTY = 0 : SSQL = "" : ITEMCODE = "" : RATE = 0 : SERTAX = 0 : TAXAMOUNT = 0 : AMOUNT = 0 : CAMOUNT = 0
                '            .Row = I
                '            .Col = 1
                '            ITEMCODE = Trim(.Text)

                '            .Row = I
                '            .Col = 4
                '            RATE = Trim(.Text)

                '            .Row = I
                '            .Col = 5
                '            QTY = IIf(Val(.Text) > 0, Val(.Text), 0)

                '            .Row = I
                '            .Col = 6
                '            AMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)

                '            .Row = I
                '            .Col = 7
                '            SERTAX = IIf(Val(.Text) > 0, Val(.Text), 0)

                '            .Row = I
                '            .Col = 8
                '            TAXAMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)


                '            .Row = I
                '            .Col = 9
                '            totalamount = IIf(Val(.Text) > 0, Val(.Text), 0)

                '            'If Val(totalamount) <= 0 Then
                '            '    MsgBox("Please Check the Menu Arrangement TAB...")
                '            '    Exit Sub
                '            'End If

                '            .Row = I
                '            .Col = 10
                '            CAMOUNT = IIf(Val(.Text) <> 0, Val(.Text), 0)

                '            .Row = I
                '            .Col = 11
                '            ROUNDOFF = IIf(Val(.Text) <> 0, Val(.Text), 0)

                '            .Row = I
                '            .Col = 12
                '            TAXPER = Trim(.Text)
                '            SSQL = "Insert Into PARTY_ARRANGEMENT(LOCCODE,BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,"
                '            SSQL = SSQL & " ITEMCODE,QTY,RATE,AMOUNT,SERTAX,TAXAMOUNT,totalamount,CANCELAMOUNT,"
                '            SSQL = SSQL & " TAXPERC,ROUNDOFF,"
                '            SSQL = SSQL & " FREEZE,ADDUSERID,ADDDATETIME)"
                '            SSQL = SSQL & " Values('" & Trim(CMB_LOCATION.Text) & "'," & TXTBOOKINGNO.Text & ""
                '            SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                '            SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "'"
                '            SSQL = SSQL & ",'" & ITEMCODE & "'"
                '            SSQL = SSQL & "," & IIf(QTY > 0, QTY, 0)
                '            SSQL = SSQL & "," & IIf(RATE > 0, RATE, 0)
                '            SSQL = SSQL & "," & IIf(AMOUNT > 0, AMOUNT, 0)
                '            SSQL = SSQL & "," & IIf(SERTAX > 0, SERTAX, 0)
                '            SSQL = SSQL & "," & IIf(TAXAMOUNT > 0, TAXAMOUNT, 0)
                '            SSQL = SSQL & "," & IIf(totalamount > 0, totalamount, 0)
                '            SSQL = SSQL & "," & IIf(CAMOUNT > 0, CAMOUNT, 0)
                '            SSQL = SSQL & "," & IIf(TAXPER > 0, TAXPER, 0)
                '            SSQL = SSQL & "," & IIf(ROUNDOFF <> 0, ROUNDOFF, 0)
                '            SSQL = SSQL & ",'N'"
                '            SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                '            SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                '            ReDim Preserve INSERT(INSERT.Length)
                '            INSERT(INSERT.Length - 1) = SSQL
                '        Next
                '    End If
                'End With
                'ENDDDD
                'ARRANGEMENT DETAILS
                'END

                'RESTAURANT MENU
                'BEGIN
                'With SSGRID
                '    SSQL = " DELETE FROM PARTY_RESTAURANT "
                '    'SSQL = SSQL & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND TTYPE in ('R','T')"
                '    SSQL = SSQL & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND TTYPE='R'"
                '    SSQL = SSQL & " AND BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                '    ReDim Preserve INSERT(INSERT.Length)
                '    INSERT(INSERT.Length - 1) = SSQL

                '    If .DataRowCnt > 0 Then

                '        For I = 1 To .DataRowCnt
                '            UOM = "" : ITEMDESC = "" : QTY = 0 : SSQL = "" : ITEMCODE = "" : RATE = 0 : SERTAX = 0 : TAXAMOUNT = 0 : AMOUNT = 0 : CAMOUNT = 0 : CHITNO = ""

                '            .Row = I
                '            .Col = 1
                '            CHITNO = Trim(.Text)

                '            .Row = I
                '            .Col = 2
                '            ITEMCODE = Trim(.Text)

                '            .Row = I
                '            .Col = 4
                '            UOM = Trim(.Text)

                '            .Row = I
                '            .Col = 5
                '            RATE = Trim(.Text)

                '            .Row = I
                '            .Col = 6
                '            QTY = IIf(Val(.Text) > 0, Val(.Text), 0)

                '            .Row = I
                '            .Col = 7
                '            AMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)

                '            .Row = I
                '            .Col = 8
                '            SERTAX = IIf(Val(.Text) > 0, Val(.Text), 0)

                '            .Row = I
                '            .Col = 9
                '            TAXAMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)

                '            .Row = I
                '            .Col = 10
                '            totalamount = IIf(Val(.Text) > 0, Val(.Text), 0)

                '            .Row = I
                '            .Col = 11
                '            CAMOUNT = IIf(Val(.Text) <> 0, Val(.Text), 0)

                '            .Row = I
                '            .Col = 12
                '            ROUNDOFF = IIf(Val(.Text) <> 0, Val(.Text), 0)

                '            .Row = I
                '            .Col = 13
                '            TAXPER = IIf(Val(.Text) > 0, Val(.Text), 0)

                '            'If Val(totalamount) <= 0 Then
                '            '    MsgBox("Please Check the Chargable Item TAB...")
                '            '    Exit Sub
                '            'End If

                '            SSQL = "INSERT INTO PARTY_RESTAURANT(CHITNO,LOCCODE,BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                '            SSQL = SSQL & " ITEMCODE,QTY,RATE,UOM,AMOUNT,SERTAX,TAXAMOUNT,totalamount,CANCELAMOUNT,"
                '            SSQL = SSQL & " TAXPERC,ROUNDOFF,"
                '            SSQL = SSQL & " FREEZE,ADDUSERID,ADDDATETIME)"
                '            SSQL = SSQL & " VALUES('" & CHITNO & "','" & Trim(CMB_LOCATION.Text) & "'," & TXTBOOKINGNO.Text
                '            SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "'"
                '            SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "','R'"
                '            SSQL = SSQL & ",'" & ITEMCODE & "'"
                '            SSQL = SSQL & "," & IIf(QTY > 0, QTY, 0)
                '            SSQL = SSQL & "," & IIf(RATE > 0, RATE, 0)
                '            SSQL = SSQL & ",'" & UOM & "'"
                '            SSQL = SSQL & "," & IIf(AMOUNT > 0, AMOUNT, 0)
                '            SSQL = SSQL & "," & IIf(SERTAX > 0, SERTAX, 0)
                '            SSQL = SSQL & "," & IIf(TAXAMOUNT > 0, TAXAMOUNT, 0)
                '            SSQL = SSQL & "," & IIf(totalamount > 0, totalamount, 0)
                '            SSQL = SSQL & "," & IIf(CAMOUNT > 0, CAMOUNT, 0)
                '            SSQL = SSQL & "," & IIf(TAXPER > 0, TAXPER, 0)
                '            SSQL = SSQL & "," & IIf(ROUNDOFF <> 0, ROUNDOFF, 0)
                '            SSQL = SSQL & ",'N'"
                '            SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                '            SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                '            ReDim Preserve INSERT(INSERT.Length)
                '            INSERT(INSERT.Length - 1) = SSQL
                '        Next
                '    End If

                'End With

                With SSGRID_TARIFF
                    GRDTAXAMOUNT = 0.0
                    SSQL = " DELETE FROM PARTY_RESTAURANT "
                    SSQL = SSQL & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND TTYPE='T'"
                    SSQL = SSQL & " AND BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND TYPE='VEG' AND ITEMCODE='" & Trim(TXT_TARIFF.Text) & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = " DELETE FROM PARTY_RESTAURANT_DET "
                    SSQL = SSQL & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                    SSQL = SSQL & " AND BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " AND TTYPE='VEG' AND ITEMCODE='" & Trim(TXT_TARIFF.Text) & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = " DELETE FROM PARTY_RESTAURANT_TAX "
                    SSQL = SSQL & " WHERE BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " AND TTYPE='VEG' AND ITEMCODE='" & Trim(TXT_TARIFF.Text) & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL


                    If Trim(TXT_TARIFF.Text) <> "" Then
                        gSQLString = "SELECT ISNULL(RATE,0) AS RATE,ISNULL(TAXCODE,'') AS TAXCODE FROM Party_TariffHDR WHERE TARIFFCODE='" & TXT_TARIFF.Text & "' AND CATEGORY='VEG'"
                        GCONNECTION.getDataSet(gSQLString, "TARIFF")
                        If gdataset.Tables("TARIFF").Rows.Count > 0 Then
                            RATE = Val(gdataset.Tables("TARIFF").Rows(0).Item("RATE"))
                            TAXCODE = gdataset.Tables("TARIFF").Rows(0).Item("TAXCODE")
                        End If
                        SSQL = "INSERT INTO PARTY_RESTAURANT(UOM,LOCCODE,BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                        SSQL = SSQL & " ITEMCODE,QTY,RATE,AMOUNT,TAXCODE,TARIFFCODE,MAXITEMS,"
                        SSQL = SSQL & " TYPE,FREEZE,ADDUSERID,ADDDATETIME)"
                        SSQL = SSQL & " VALUES('NOS','" & Trim(CMB_LOCATION.Text) & "'," & TXTBOOKINGNO.Text
                        SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                        SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "','T'"
                        SSQL = SSQL & ",'" & TXT_TARIFF.Text & "'"
                        SSQL = SSQL & "," & Val(TxtVOCCUPANCY.Text) & ""
                        SSQL = SSQL & "," & RATE & ""
                        SSQL = SSQL & "," & (Val(TxtVOCCUPANCY.Text) * RATE) & ""
                        SSQL = SSQL & ",'" & TAXCODE & "'"
                        SSQL = SSQL & ",'" & TXT_TARIFF.Text & "'"
                        SSQL = SSQL & "," & Val(Txt_Maxitems.Text) & ""
                        SSQL = SSQL & ",'VEG'"
                        SSQL = SSQL & ",'N'"
                        SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                        SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = SSQL

                        ''TAX INSERT START
                        'RATE = 0
                        Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                        GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                        SQLSTRING = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(TAXCODE) & "' "
                        GCONNECTION.getDataSet(SQLSTRING, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        QTY = Val(TxtVOCCUPANCY.Text)
                        ChargeCode = TAXCODE
                        SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(SQLSTRING, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For J = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(J).Item("ItemTypeCode"))
                                TAXCODE = Trim(gdataset.Tables("TAXON").Rows(J).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(J).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")

                                SSQL = "INSERT INTO party_RESTAURANT_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TTYPE,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                                SSQL = SSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(TAXCODE) & "','" & Trim(Taxon) & "','" & Trim(TXT_TARIFF.Text) & "'," & Val(RATE) & ",'" & Val(QTY) & "'," & (TPercent) & ",'VEG',"
                                If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                                    Zero = (RATE * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Zero) * QTY, "0.00")
                                    SSQL = SSQL & "" & Format(Val(Zero) * QTY, "0.00") & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(ZeroA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Format(Val(ZeroA) * QTY, "0.00") & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    SSQL = SSQL & "" & Format(Val(ZeroB) * QTY, "0.00") & ","
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(ZeroB) * QTY, "0.00")
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                                    One = ((RATE + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(One) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(One) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(OneA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(OneA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(OneB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(OneB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                                    Two = ((RATE + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Two) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(Two) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(TwoA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(TwoA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(TwoB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(TwoB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                                    Three = ((RATE + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Three) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(Three) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(GThreeA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(ThreeA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(GThreeB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(ThreeB) * QTY & ","
                                End If


                                SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = SSQL
                            Next
                            GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                            ' GRDTAXAMOUNT = GRDTAXAMOUNT + GrdTaxAmt
                            '.SetText(6, I, GrdTaxAmt)
                            '.SetText(8, I, GrdTaxAmt + rate)
                        End If

                        ''TAX INSERT END



                        For I = 1 To .DataRowCnt
                            .Col = 2
                            .Row = I
                            If (.Text <> "") Then
                                SSQL = "INSERT INTO PARTY_RESTAURANT_DET(BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                                SSQL = SSQL & " ITEMCODE,ITEMDESC,UOM,QTY,GROUPCODE,MENUCODE,TARIFFCODE,MAXITEMS,"
                                SSQL = SSQL & " FREEZE,ADDUSERID,ADDDATETIME)"
                                SSQL = SSQL & " VALUES(" & TXTBOOKINGNO.Text
                                SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                                SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "','VEG'"
                                .Col = 2
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 3
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 4
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 5
                                .Row = I
                                SSQL = SSQL & "," & Val(.Text) & ""
                                .Col = 6
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 7
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 1
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 9
                                .Row = I
                                SSQL = SSQL & "," & Val(.Text) & ""

                                SSQL = SSQL & ",'N'"
                                SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                                SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = SSQL
                            End If

                        Next
                    End If
                    SSQL = "UPDATE PARTY_RESTAURANT SET TAXAMOUNT=" & GRDTAXAMOUNT & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND TYPE='VEG'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "UPDATE PARTY_RESTAURANT SET TOTALAMOUNT=AMOUNT+TAXAMOUNT WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND TYPE='VEG'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "update PARTY_RESTAURANT set category=T.category from Party_TariffHdr T where PARTY_RESTAURANT.ITEMCODE=T.TARIFFCODE   and PARTY_RESTAURANT.bookingno='" & Me.TXTBOOKINGNO.Text & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "update PARTY_RESTAURANT set ITEMDESC=T.TARIFFDESC from Party_TariffHdr T where PARTY_RESTAURANT.ITEMCODE=T.TARIFFCODE   and PARTY_RESTAURANT.bookingno='" & Me.TXTBOOKINGNO.Text & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                End With


                With SSGRID_NV
                    GRDTAXAMOUNT = 0.0
                    SSQL = " DELETE FROM PARTY_RESTAURANT "
                    SSQL = SSQL & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND TTYPE='T'"
                    SSQL = SSQL & " AND BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'AND TYPE='NONVEG'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = " DELETE FROM PARTY_RESTAURANT_DET "
                    SSQL = SSQL & " WHERE BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                    SSQL = SSQL & " AND BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " AND TTYPE='NONVEG'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = " DELETE FROM PARTY_RESTAURANT_TAX "
                    SSQL = SSQL & " WHERE  BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " AND TTYPE='NONVEG'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL

                    If Trim(TextNVTBOX.Text) <> "" Then
                        gSQLString = "SELECT ISNULL(RATE,0) AS RATE,ISNULL(TAXCODE,'') AS TAXCODE FROM Party_TariffHDR WHERE TARIFFCODE='" & TextNVTBOX.Text & "' AND CATEGORY='NON VEG'"
                        GCONNECTION.getDataSet(gSQLString, "TARIFF")
                        If gdataset.Tables("TARIFF").Rows.Count > 0 Then
                            RATE = Val(gdataset.Tables("TARIFF").Rows(0).Item("RATE"))
                            TAXCODE = gdataset.Tables("TARIFF").Rows(0).Item("TAXCODE")
                        End If
                        SSQL = "INSERT INTO PARTY_RESTAURANT(UOM,LOCCODE,BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                        SSQL = SSQL & " ITEMCODE,QTY,RATE,AMOUNT,TAXCODE,TARIFFCODE,MAXITEMS,"
                        SSQL = SSQL & " TYPE,FREEZE,ADDUSERID,ADDDATETIME)"
                        SSQL = SSQL & " VALUES('NOS','" & Trim(CMB_LOCATION.Text) & "'," & TXTBOOKINGNO.Text
                        SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                        SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "','T'"
                        SSQL = SSQL & ",'" & TextNVTBOX.Text & "'"
                        SSQL = SSQL & "," & Val(TxtNVOCCUPANCY.Text) & ""
                        SSQL = SSQL & "," & RATE & ""
                        SSQL = SSQL & "," & (Val(TxtNVOCCUPANCY.Text) * RATE) & ""
                        SSQL = SSQL & ",'" & TAXCODE & "'"
                        SSQL = SSQL & ",'" & TextNVTBOX.Text & "'"
                        SSQL = SSQL & "," & Val(Txt_Maxitems.Text) & ""
                        SSQL = SSQL & ",'NONVEG'"
                        SSQL = SSQL & ",'N'"
                        SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                        SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = SSQL
                        ''TAX INSERT START
                        'RATE = 0
                        Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                        GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                        SQLSTRING = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(TAXCODE) & "' "
                        GCONNECTION.getDataSet(SQLSTRING, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If
                        QTY = Val(TxtNVOCCUPANCY.Text)
                        ChargeCode = TAXCODE
                        SQLSTRING = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        GCONNECTION.getDataSet(SQLSTRING, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For J = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(J).Item("ItemTypeCode"))
                                TAXCODE = Trim(gdataset.Tables("TAXON").Rows(J).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(J).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")

                                SSQL = "INSERT INTO party_RESTAURANT_TAX (BOOKINGNO,CHARGECODE,TAXCODE,TAXON,ITEMCODE,RATE,QTY,TAXPERC,TTYPE,TAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                                SSQL = SSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(ChargeCode) & "','" & Trim(TAXCODE) & "','" & Trim(Taxon) & "','" & Trim(TextNVTBOX.Text) & "'," & Val(RATE) & ",'" & Val(QTY) & "'," & (TPercent) & ",'NONVEG',"
                                If gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0" Then
                                    Zero = (RATE * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Zero) * QTY, "0.00")
                                    SSQL = SSQL & "" & Format(Val(Zero) * QTY, "0.00") & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(ZeroA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Format(Val(ZeroA) * QTY, "0.00") & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    SSQL = SSQL & "" & Format(Val(ZeroB) * QTY, "0.00") & ","
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(ZeroB) * QTY, "0.00")
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1" Then
                                    One = ((RATE + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(One) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(One) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(OneA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(OneA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(OneB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(OneB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2" Then
                                    Two = ((RATE + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Two) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(Two) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(TwoA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(TwoA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(TwoB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(TwoB) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3" Then
                                    Three = ((RATE + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(Three) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(Three) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(GThreeA) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(ThreeA) * QTY & ","
                                ElseIf gdataset.Tables("TAXON").Rows(J).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(J).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    GRDTAXAMOUNT = GRDTAXAMOUNT + Format(Val(GThreeB) * QTY, "0.00")
                                    SSQL = SSQL & "" & Val(ThreeB) * QTY & ","
                                End If


                                SSQL = SSQL & "'" & Trim(gUsername) & "',getdate(),'N')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = SSQL
                            Next
                            GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB

                            '.SetText(6, I, GrdTaxAmt)
                            '.SetText(8, I, GrdTaxAmt + rate)

                        End If

                        ''TAX INSERT END

                        For I = 1 To .DataRowCnt
                            .Col = 2
                            .Row = I
                            If (.Text <> "") Then
                                SSQL = "INSERT INTO PARTY_RESTAURANT_DET(BOOKINGNO,BOOKINGDATE,BOOKINGTYPE,TTYPE,"
                                SSQL = SSQL & " ITEMCODE,ITEMDESC,UOM,QTY,GROUPCODE,MENUCODE,TARIFFCODE,MAXITEMS,"
                                SSQL = SSQL & " FREEZE,ADDUSERID,ADDDATETIME)"
                                SSQL = SSQL & " VALUES(" & TXTBOOKINGNO.Text
                                SSQL = SSQL & ",'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy") & "'"
                                SSQL = SSQL & ",'" & CMBBOOKINGTYPE.Text & "','NONVEG'"
                                .Col = 2
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 3
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 4
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 5
                                .Row = I
                                SSQL = SSQL & "," & Val(.Text) & ""
                                .Col = 6
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 7
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 1
                                .Row = I
                                SSQL = SSQL & ",'" & Trim(.Text) & "'"
                                .Col = 9
                                .Row = I
                                SSQL = SSQL & "," & Val(.Text) & ""

                                SSQL = SSQL & ",'N'"
                                SSQL = SSQL & ",'" & Trim(gUsername) & "'"
                                SSQL = SSQL & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                                ReDim Preserve INSERT(INSERT.Length)
                                INSERT(INSERT.Length - 1) = SSQL
                            End If
                        Next
                    End If
                    SSQL = "UPDATE PARTY_RESTAURANT SET TAXAMOUNT=" & GRDTAXAMOUNT & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND TYPE='NONVEG'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "UPDATE PARTY_RESTAURANT SET TOTALAMOUNT=AMOUNT+TAXAMOUNT WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND TYPE='NONVEG'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "update PARTY_RESTAURANT set category=T.category from Party_TariffHdr T where PARTY_RESTAURANT.ITEMCODE=T.TARIFFCODE   and PARTY_RESTAURANT.bookingno='" & Me.TXTBOOKINGNO.Text & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                    SSQL = "update PARTY_RESTAURANT set ITEMDESC=T.TARIFFDESC from Party_TariffHdr T where PARTY_RESTAURANT.ITEMCODE=T.TARIFFCODE   and PARTY_RESTAURANT.bookingno='" & Me.TXTBOOKINGNO.Text & "'"
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = SSQL
                End With
                SSQL = "update PARTY_RESTAURANT set category=a.category from party_itemmaster a where a.itemcode= PARTY_RESTAURANT.itemcode and PARTY_RESTAURANT.bookingno='" & Me.TXTBOOKINGNO.Text & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = SSQL

                ssqlstring = " update party_restaurant set SERTAX=(select SUM(taxamount) from party_RESTAURANT_TAX where party_restaurant.BOOKINGNO=party_restaurant_tax.BOOKINGNO and party_restaurant.ITEMCODE=party_RESTAURANT_TAX.ITEMCODE AND "
                ssqlstring = ssqlstring & "party_RESTAURANT_TAX.TAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX IN ('SERVICE TAX','CGST','CGST CESS')) )WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " " 'and BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = ssqlstring

                ssqlstring = "update party_restaurant set TAXAMOUNT=(select SUM(taxamount) from party_RESTAURANT_TAX where party_restaurant.BOOKINGNO=party_restaurant_tax.BOOKINGNO and party_restaurant.ITEMCODE=party_RESTAURANT_TAX.ITEMCODE AND "
                ssqlstring = ssqlstring & "party_RESTAURANT_TAX.TAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX IN ('VAT','SGST','SGST CESS')) )WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & "" ' and BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = ssqlstring

                'ssqlstring = "update party_arrangement set SERTAX=(select SUM(taxamount) from party_arrangement_TAX where party_arrangement.BOOKINGNO=party_arrangement_TAX.BOOKINGNO and party_arrangement.ITEMCODE=party_arrangement_TAX.ITEMCODE AND "
                'ssqlstring = ssqlstring & "party_arrangement_TAX.TAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX='SERVICE TAX') )WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & "" ' and BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                'ReDim Preserve INSERT(INSERT.Length)
                'INSERT(INSERT.Length - 1) = ssqlstring

                'ssqlstring = "update party_arrangement set TAXAMOUNT=(select SUM(taxamount) from party_arrangement_TAX where party_arrangement.BOOKINGNO=party_arrangement_TAX.BOOKINGNO and party_arrangement.ITEMCODE=party_arrangement_TAX.ITEMCODE AND "
                'ssqlstring = ssqlstring & "party_arrangement_TAX.TAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX='VAT') )WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & "" '  and BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' "
                'ReDim Preserve INSERT(INSERT.Length)
                'INSERT(INSERT.Length - 1) = ssqlstring
                SSQL = "UPDATE PARTY_ARRANGEMENT SET TAXAMOUNT = (SELECT ISNULL(SUM(party_arrangement_TAX.TAXAMOUNT),0) FROM party_arrangement_TAX WHERE PARTY_ARRANGEMENT.BOOKINGNO = party_arrangement_TAX.BOOKINGNO AND party_arrangement_TAX.ITEMCODE = PARTY_ARRANGEMENT.ITEMCODE AND ISNULL(party_arrangement_TAX.BOOKINGTYPE,'') = ISNULL(PARTY_ARRANGEMENT.BOOKINGTYPE,'') and party_arrangement_TAX.TAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX IN ('VAT','SGST','SGST CESS')) GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''))"
                SSQL = SSQL & " WHERE PARTY_ARRANGEMENT.BOOKINGNO = '" & Trim(TXTBOOKINGNO.Text) & "' AND ISNULL(party_arrangement.BOOKINGTYPE,'') = 'BILLING' "
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = SSQL

                SSQL = "UPDATE PARTY_ARRANGEMENT SET SERTAX = (SELECT ISNULL(SUM(party_arrangement_TAX.TAXAMOUNT),0) FROM party_arrangement_TAX WHERE PARTY_ARRANGEMENT.BOOKINGNO = party_arrangement_TAX.BOOKINGNO AND party_arrangement_TAX.ITEMCODE = PARTY_ARRANGEMENT.ITEMCODE AND ISNULL(party_arrangement_TAX.BOOKINGTYPE,'') = ISNULL(PARTY_ARRANGEMENT.BOOKINGTYPE,'') and party_arrangement_TAX.TAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX IN ('SERVICE TAX','CGST','CGST CESS')) GROUP BY BOOKINGNO,ITEMCODE,ISNULL(BOOKINGTYPE,''))"
                SSQL = SSQL & " WHERE PARTY_ARRANGEMENT.BOOKINGNO = '" & Trim(TXTBOOKINGNO.Text) & "' AND ISNULL(party_arrangement.BOOKINGTYPE,'') = 'BILLING' "
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = SSQL

                GCONNECTION.dataOperation1(2, INSERT)
            End If

            SQLSTRING = "ALTER VIEW PAR_TARIFF AS SELECT A.BOOKINGNO,A.TARIFFCODE,B.CATEGORY,CASE WHEN B.CATEGORY='VEG' THEN C.VEG ELSE C.NONVEG END AS PAX,B.RATE,B.TAXCODE,D.TAXPERCENTAGE,CASE WHEN B.CATEGORY='VEG' THEN ISNULL(C.VEG,0)*ISNULL(B.RATE,0) ELSE ISNULL(C.NONVEG,0)*ISNULL(B.RATE,0) END AS TARIFFAMOUNT FROM PARTY_RESTAURANT A,PARTY_TARIFFHDR B,PARTY_HDR C,ACCOUNTSTAXMASTER D WHERE B.TAXCODE=D.TAXCODE AND A.LOCCODE=C.LOCCODE AND A.BOOKINGTYPE=C.BOOKINGTYPE AND A.BOOKINGNO=C.BOOKINGNO AND A.TARIFFCODE=B.TARIFFCODE AND TTYPE='T' AND A.BOOKINGTYPE='BILLING' AND A.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'  AND A.BOOKINGNO=" & TXTBOOKINGNO.Text & " GROUP BY A.BOOKINGNO,A.TARIFFCODE,C.VEG,B.CATEGORY,C.NONVEG,B.RATE,B.TAXCODE,D.TAXPERCENTAGE"
            GCONNECTION.getDataSet(SQLSTRING, "MAXNO")

            SQLSTRING = "UPDATE PARTY_HDR SET VEGRATE=RATE FROM Party_TariffHdr B WHERE B.CATEGORY='VEG' AND PARTY_HDR.VEGCODE=B.TARIFFCODE AND PARTY_HDR.BOOKINGNO='" & Me.TXTBOOKINGNO.Text & "' AND BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "'    "
            ''AND PARTY_HDR.VEGCODE='" & Trim(TXT_TARIFF.Text) & "'
            GCONNECTION.getDataSet(SQLSTRING, "MAXNO")


            SQLSTRING = "UPDATE PARTY_HDR SET NONVEGRATE=RATE FROM Party_TariffHdr B WHERE B.CATEGORY='NON VEG' AND PARTY_HDR.VEGCODE=B.TARIFFCODE AND PARTY_HDR.BOOKINGNO='" & Me.TXTBOOKINGNO.Text & "'AND BOOKINGTYPE='" & CMBBOOKINGTYPE.Text & "' "
            GCONNECTION.getDataSet(SQLSTRING, "MAXNO")
            If CMBBOOKINGTYPE.Text = "BILLING" Then
                Call cmd_print_Click(cmd_print, e)
            End If

            Me.Cmd_Clear_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Private Sub GridUnLock()
        Dim i, j As Integer
        For i = 1 To 100
            For j = 1 To 6
                sSGrid.Col = j
                sSGrid.Row = i
                sSGrid.Lock = False
            Next j
        Next i
    End Sub
    Private Sub GridColUnLock(ByVal ColNo As Integer)
        Dim i, j As Integer
        For i = 1 To 100
            'For j = 1 To 5
            sSGrid.Col = ColNo
            sSGrid.Row = i
            sSGrid.Lock = False
            'Next j
        Next i
    End Sub
    
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_BookingNo.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT ISNULL(A.BOOKINGNO,0) AS BOOKINGNO,ISNULL(A.partyDATE,'')AS PARTYDATE,A.BOOKINGDATE AS BOOKINGDATE,A.MCODE,A.ASSOCIATENAME AS MEMBERNAME,A.GUESTNAME,B.HALLCODE "
        'gSQLString = "SELECT ISNULL(PARTYDATE,'') AS PARTYDATE,BOOKINGDATE AS BOOKINGDATE,MCODE AS MCODE,ASSOCIATENAME AS MEMBERNAME,ISNULL(BOOKINGNO,0) AS BOOKINGNO,HALLCODEFCODE "

        gSQLString = gSQLString & "  FROM  PARTY_HALLBOOKING_HDR A,PARTY_HALLBOOKING_DET B"
        If Trim(Search) = " " Then
            M_WhereCondition = " WHERE A.LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND A.BOOKINGNO=B.BOOKINGNO"
        Else
            M_WhereCondition = " WHERE A.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'AND A.BOOKINGNO=B.BOOKINGNO"
        End If
        'vform.Field = "PARTYDATE,BOOKINGDATE,MCODE,ASSOCIATENAME,HALLCODE,BOOKINGNO"
        vform.Field = "A.BOOKINGNO,A.PARTYDATE,A.BOOKINGDATE,A.MCODE,A.ASSOCIATENAME,B.HALLCODE"
        '  vform.vFormatstring = "BOOKINGNO|PARTYDATE                  |BOOKING DATE                |MCODE|       MEMBER NAME       |    HALL CODE        "
        'vform.vFormatstring = "PARTYDATE |   BOOKING DATE  |  MEM CODE   |        MEMBER NAME       |    HALL CODE       | BOOKINGNO    "

        vform.vCaption = "HALL RESERVATION HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXTBOOKINGNO.Text = Trim(vform.keyfield & "")
            ' DTPBOOKINGDATE.Text = Trim(vform.keyfield1 & "")
            TXTBOOKINGNO.Select()
            Call TXTBOOKINGNO_Validated(sender, e)
            DTPBOOKINGDATE.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub CMDSUBCODE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_mcodehelp.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT  DISTINCT isnull(TARIFFDESC,'') as TARIFFDESC,isnull(TARIFFCODE,'') as TARIFFCODE,ISNULL(RATE,0) AS RATE,ISNULL(SBFCHARGE,'') AS SBFCHARGE FROM PARTY_VIEW_TARIFFMASTER "
        M_WhereCondition = " where FREEZE <>'y'"
        vform.Field = "TARIFFDESC,TARIFFCODE,RATE,SBFCHARGE"
        vform.vFormatstring = "             Tariff Description            |   Tariff Code   | RATE| SBF CHARGE"
        vform.vCaption = "Tariff Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXT_MENU.Text = Trim(vform.keyfield1 & "")
            'TXT_TARIFFDESC.Text = Trim(vform.keyfield)
            'TXT_MENU.Text = Trim(vform.keyfield2)
            Call Txt_Tariffcode_Validated(TXT_MENU, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub cmd_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_exit.Click, cmd_exit.Click
        Me.Close()
    End Sub

    Private Sub cmd_report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_report.Click
        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New CrptPARTY_VIEW_HALLBOOKINGDETAILS

        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        'If MsgBox("Press OK to BOOKING Bill or FINAL to Annexure........", MsgBoxStyle.OKCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then

        'Call PARTY_VIEW_HALLBOOKINGDETAILS()
        If TXTBOOKINGNO.Text = "" Then
            MessageBox.Show("PLEASE ENTER THE BOOKING NO", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTBOOKINGNO.Focus()
            Exit Sub

        End If
        If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then

            Call PARTYBillingform()
        ElseIf UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then
            Call PARTYBillingformASCA()
        Else
            'Call PARTYBillingform()
            Call PARTYBillingformKGA()
        End If
        'Call PARTYBillingform()
        'Else
        '    Call view_party_billing()

        'End If
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click

    End Sub

    Private Sub Cmd_report22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_report22.Click

    End Sub

    Private Sub Cmd_Add1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add1.Click

    End Sub

    Private Sub SSGRID_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSGRID.Advance

    End Sub

    Private Sub SSGRID_EditChange(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_EditChangeEvent) Handles SSGRID.EditChange

    End Sub

    Private Sub Cmdview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdview.Click

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub SSGRID_ARRANGE_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SSGRID_ARRANGE.LocationChanged

    End Sub

    Private Sub TxtNVOCCUPANCY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNVOCCUPANCY.TextChanged

    End Sub

    Private Sub TXTADVANCE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTADVANCE.TextChanged

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Me.CMBBOOKINGTYPE.Text = "BILLING" Then
            If TXTBOOKINGNO.Text = "" Then
                MessageBox.Show("Enter the Booking No")
                Exit Sub
            End If
            Dim SETT As New SETTLEMENT(TXTBOOKINGNO.Text, DTPPARTYDATE.Value)
            SETT.MdiParent = Me.MdiParent
            SETT.Show()
            SSQL = "SELECT BOOKINGNO ,PARTYDATE ,ACCOUNTCODE +'>'+ACDESC AS ACCODE,TOTALAMOUNT AS DEBIT,CASHAMT  AS CREDIT,BANKAMT ,MEMAMT ,POSTFLAG FROM PARTY_ACC_POST WHERE BOOKINGNO ='" & Me.TXTBOOKINGNO.Text & "'"
            GCONNECTION.getDataSet(SSQL, "ACCTYPE")
            If gdataset.Tables("ACCTYPE").Rows.Count > 0 Then
                SSQL = "SELECT BOOKINGNO ,PARTYDATE ,ACCOUNTCODE +'>'+ACDESC AS ACCODE,ISNULL(SLCODE,'') AS SLCODE,TOTALAMOUNT AS DEBIT,CASHAMT  AS CREDIT,POSTFLAG FROM PARTY_ACC_POST WHERE BOOKINGNO ='" & Me.TXTBOOKINGNO.Text & "'"
            Else
                SSQL = "SELECT A.BOOKINGNO,A.PARTYDATE,(ISNULL(A.ACCODE,'') +'>'+ISNULL(B.ACDESC,''))  AS ACCODE,ISNULL(SLCODE,'') AS SLCODE,SUM(DRAMOUNT)AS DEBIT,SUM(CRAMOUNT)AS CREDIT ,'N' AS POSTFLAG FROM PARTY_DETSUMMARY A LEFT OUTER JOIN ACCOUNTSGLACCOUNTMASTER B ON A.ACCODE=B.ACCODE  WHERE BOOKINGNO='" & Me.TXTBOOKINGNO.Text & "' GROUP BY A.BOOKINGNO,A.PARTYDATE,A.ACCODE,B.ACDESC,SLCODE "
            End If
            Call SETT.GETDATA(SSQL, TXTBOOKINGNO.Text)
        End If
    End Sub

    Private Sub LABELDATE_Click(sender As Object, e As EventArgs) Handles LABELDATE.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub Cmd_SBill_Click(sender As Object, e As EventArgs) Handles Cmd_SBill.Click
        Dim servercode() As String
        Dim i As Integer
        Dim BOOLCHK As Boolean
        BOOLCHK = False
        Dim sqlstring, SSQL, SSQL1, SSQL2, SSQL3, SSQ, SQL1, SSQL4, SSQL5, SSQL6, BillNo, TDATE As String
        Dim PTodate, Pdate As Date
        Dim Viewer As New ReportViwer

        Dim POSdesc(), MemberCode() As String
        Dim sqlstring1 As String
        Dim SQLSTRING2 As String

        SQL1 = "SELECT * FROM party_hdr WHERE BOOKINGNO = " & TXTBOOKINGNO.Text & " AND ISNULL(BOOKINGTYPE,'') = 'BILLING'"
        GCONNECTION.getDataSet(SQL1, "RPT1")
        If gdataset.Tables("RPT1").Rows.Count > 0 Then
            MessageBox.Show("Bill Generated, For Bill Print click of Report Button ", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        End If

        If Mid(gCompName, 1, 5) = "TRADE" Then
            Dim R As New CRPT_PAR_BILLING_TRADE
            If Trim(TXTBOOKINGNO.Text) <> "" Then
                sqlstring = "SELECT * FROM RPT_PARTY_RECEIPT Where BOOKNO='" & TXTBOOKINGNO.Text & "'"
                GCONNECTION.getDataSet(sqlstring, "RPT_PARTY_RECEIPT")

                SQL1 = "SELECT * FROM RPT_PARTY_POSDETAILS_BOOKING Where BOOKINGNO=" & TXTBOOKINGNO.Text & ""
                GCONNECTION.getDataSet(SQL1, "RPT_PARTY_POSDETAILS")

                SSQL5 = "SELECT * FROM RPT_PARTY_HALLDET Where BOOKINGNO=" & TXTBOOKINGNO.Text & ""
                GCONNECTION.getDataSet(SSQL5, "RPT_PARTY_HALLDET")

                SSQL6 = "SELECT bookingno AS MCODE,TAXDESC AS ASSOCIATENAME ,HALLTAXPERC AS TAX, SUM(TAXAMOUNT) AS AMOUNT FROM TAX_DETAILS_BOOKING Where bookingno=" & TXTBOOKINGNO.Text & " GROUP BY bookingno,TAXDESC ,HALLTAXPERC "
                GCONNECTION.getDataSet(SSQL6, "PARTY_PENDINGBILL")
            End If
            Viewer.Report = R

            Call Viewer.GetDetails1(sqlstring, "RPT_PARTY_RECEIPT", R)
            Call Viewer.GetDetails1(SQL1, "RPT_PARTY_POSDETAILS", R)
            Call Viewer.GetDetails1(SSQL5, "RPT_PARTY_HALLDET", R)
            Call Viewer.GetDetails1(SSQL6, "PARTY_PENDINGBILL", R)

            sqlstring = "SELECT ISNULL(BILLNO,'') FROM PARTY_hDR WHERE BOOKINGNO = '" & TXTBOOKINGNO.Text & "' AND BOOKINGTYPE = 'BILLING'"
            GCONNECTION.getDataSet(sqlstring, "Bno")
            If gdataset.Tables("Bno").Rows.Count > 0 Then
                BillNo = gdataset.Tables("Bno").Rows(0).Item(0)
            Else
                BillNo = "Simulated Bill"
            End If

            sqlstring = "SELECT CAST(CONVERT(VARCHAR,PartyTodate,106) AS DATETIME) AS TODATE,CAST(CONVERT(VARCHAR,Partydate,106) AS DATETIME) AS PARTYDATE FROM party_hallbooking_det WHERE BOOKINGNO = '" & TXTBOOKINGNO.Text & "'"
            GCONNECTION.getDataSet(sqlstring, "Bno")
            If gdataset.Tables("Bno").Rows.Count > 0 Then
                PTodate = Format(gdataset.Tables("Bno").Rows(0).Item("TODATE"), "dd.MM.yyyy")
                Pdate = Format(gdataset.Tables("Bno").Rows(0).Item("PARTYDATE"), "dd.MM.yyyy")
                If PTodate = Pdate Then
                    PTodate = "01-JAN-1900"
                End If
            End If

            If PTodate = "01-JAN-1900" Then
                TDATE = ""
            Else
                TDATE = Format(PTodate, "dd.MM.yyyy")
            End If

            Dim TXTOBJ2 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ2 = R.ReportDefinition.ReportObjects("Text31")
            TXTOBJ2.Text = BillNo

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = R.ReportDefinition.ReportObjects("Text23")
            TXTOBJ1.Text = "UserName : " & gUsername

            Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ3 = R.ReportDefinition.ReportObjects("Text24")
            TXTOBJ3.Text = TDATE

            Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ4 = R.ReportDefinition.ReportObjects("Text2")
            If TDATE = "" Then
                TXTOBJ4.Text = ""
            Else
                TXTOBJ4.Text = "To"
            End If

            Viewer.Show()
        Else
            Dim R As New CRPT_PAR_BILLING_CIAL
            If Trim(TXTBOOKINGNO.Text) <> "" Then

                sqlstring = "SELECT * FROM RPT_PARTY_RECEIPT Where BOOKNO='" & TXTBOOKINGNO.Text & "'"
                GCONNECTION.getDataSet(sqlstring, "RPT_PARTY_RECEIPT")

                SQL1 = "SELECT * FROM RPT_PARTY_POSDETAILS_BOOKING Where BOOKINGNO=" & TXTBOOKINGNO.Text & ""
                GCONNECTION.getDataSet(SQL1, "RPT_PARTY_POSDETAILS")

                SSQL5 = "SELECT * FROM RPT_PARTY_HALLDET Where BOOKINGNO=" & TXTBOOKINGNO.Text & ""
                GCONNECTION.getDataSet(SSQL5, "RPT_PARTY_HALLDET")

                SSQL6 = "SELECT bookingno AS MCODE,TAXDESC AS ASSOCIATENAME ,HALLTAXPERC AS TAX, SUM(TAXAMOUNT) AS AMOUNT FROM TAX_DETAILS_BOOKING Where bookingno=" & TXTBOOKINGNO.Text & " GROUP BY bookingno,TAXDESC ,HALLTAXPERC "
                GCONNECTION.getDataSet(SSQL6, "PARTY_PENDINGBILL")
            End If
            Viewer.Report = R

            Call Viewer.GetDetails1(sqlstring, "RPT_PARTY_RECEIPT", R)
            Call Viewer.GetDetails1(SQL1, "RPT_PARTY_POSDETAILS", R)
            Call Viewer.GetDetails1(SSQL5, "RPT_PARTY_HALLDET", R)
            Call Viewer.GetDetails1(SSQL6, "PARTY_PENDINGBILL", R)

            sqlstring = "SELECT ISNULL(BILLNO,'') FROM PARTY_hDR WHERE BOOKINGNO = '" & TXTBOOKINGNO.Text & "' AND BOOKINGTYPE = 'BILLING'"
            GCONNECTION.getDataSet(sqlstring, "Bno")
            If gdataset.Tables("Bno").Rows.Count > 0 Then
                BillNo = gdataset.Tables("Bno").Rows(0).Item(0)
            Else
                BillNo = "Simulated Bill"
            End If

            sqlstring = "SELECT CAST(CONVERT(VARCHAR,PartyTodate,106) AS DATETIME) AS TODATE,CAST(CONVERT(VARCHAR,Partydate,106) AS DATETIME) AS PARTYDATE FROM party_hallbooking_det WHERE BOOKINGNO = '" & TXTBOOKINGNO.Text & "'"
            GCONNECTION.getDataSet(sqlstring, "Bno")
            If gdataset.Tables("Bno").Rows.Count > 0 Then
                PTodate = Format(gdataset.Tables("Bno").Rows(0).Item("TODATE"), "dd.MM.yyyy")
                Pdate = Format(gdataset.Tables("Bno").Rows(0).Item("PARTYDATE"), "dd.MM.yyyy")
                If PTodate = Pdate Then
                    PTodate = "01-JAN-1900"
                End If
            End If

            If PTodate = "01-JAN-1900" Then
                TDATE = ""
            Else
                TDATE = Format(PTodate, "dd.MM.yyyy")
            End If

            Dim TXTOBJ2 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ2 = R.ReportDefinition.ReportObjects("Text31")
            TXTOBJ2.Text = BillNo

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = R.ReportDefinition.ReportObjects("Text23")
            TXTOBJ1.Text = "UserName : " & gUsername

            Dim TXTOBJ3 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ3 = R.ReportDefinition.ReportObjects("Text24")
            TXTOBJ3.Text = TDATE

            Dim TXTOBJ4 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ4 = R.ReportDefinition.ReportObjects("Text11")
            If TDATE = "" Then
                TXTOBJ4.Text = ""
            Else
                TXTOBJ4.Text = "To"
            End If

            Viewer.Show()
        End If
    End Sub

    Private Sub PARTYBilling_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class

