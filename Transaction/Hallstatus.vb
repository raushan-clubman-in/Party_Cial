Imports System.Data
Imports System.IO
Imports System.Math
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Public Class Hallstatus
    Inherits System.Windows.Forms.Form
    Dim vseqno As Double
    Dim boolchk As Boolean
    Dim sqlstring, ssqlstring As String
    Dim gconnection As New GlobalClass
    Dim i, j, k As Integer
    Dim ssql, INSERT(0) As String
    Dim GrdAmount, GrdTaxAmt As Double
    Dim DT As New DataTable
    Dim QTY, RATE, TAXAMOUNT, AMOUNT, ROUNDOFF, TEXPERC As Double
    Dim Zero, ZeroA, ZeroB, One, OneA, OneB, Two, TwoA, TwoB, Three, ThreeA, ThreeB As Double
    Dim GZero, GZeroA, GZeroB, GOne, GOneA, GOneB, GTwo, GTwoA, GTwoB, GThree, GThreeA, GThreeB, TTAX As Double
    Dim IType, Taxcode, Taxon, ItemTypeCode, ChargeCode, Pos, KStatus As String
    Dim UOM, ITEMCODE, ITEMDESC As String
    Friend WithEvents Btn_Hallres As System.Windows.Forms.Button
    Friend WithEvents Btn_Hallava As System.Windows.Forms.Button
    Friend WithEvents Btn_recdet As System.Windows.Forms.Button
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents cmd_exit As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmd_view As System.Windows.Forms.Button
    Friend WithEvents cmd_freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents btn_rent As System.Windows.Forms.Button
    Friend WithEvents cmd_helpbooingno As System.Windows.Forms.Button
    Friend WithEvents cmd_mcodehelp As System.Windows.Forms.Button
    Friend WithEvents TXT_CELLNO As System.Windows.Forms.TextBox
    Friend WithEvents TXT_EMAIL As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Cmb_GuestType As System.Windows.Forms.ComboBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Cmb_StatusType As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Txt_CityPin As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Txt_Add2 As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Txt_Add1 As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Cmb_DayBasis As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Txt_Others As System.Windows.Forms.TextBox
    Friend WithEvents cmd_Purpose As System.Windows.Forms.Button
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Txt_MemGstNo As System.Windows.Forms.TextBox
    Dim dbldicountAmount
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Txt_StateCode As System.Windows.Forms.TextBox
    Friend WithEvents Chk_FloodTax As System.Windows.Forms.CheckBox
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtmcode As System.Windows.Forms.TextBox
    Friend WithEvents txthallcode As System.Windows.Forms.TextBox
    Friend WithEvents txtmname As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Add1 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear1 As System.Windows.Forms.Button
    Friend WithEvents Cmd_View1 As System.Windows.Forms.Button
    Friend WithEvents cmd_Exit1 As System.Windows.Forms.Button
    Friend WithEvents cmd_mcodehelp2 As System.Windows.Forms.Button
    Friend WithEvents cmd_hallcodehelp As System.Windows.Forms.Button
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents cmd_advance As System.Windows.Forms.Button
    Friend WithEvents TXTBOOKINGNO As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DTPBOOKINGDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Dtppartydate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmd_helpbooingno1 As System.Windows.Forms.Button
    Friend WithEvents TxtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GBHALLBOOKING As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RBCLUBMEMBER As System.Windows.Forms.RadioButton
    Friend WithEvents RBASSOCIATEMEMBER As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SSGRID_BOOKING As AxFPSpreadADO.AxfpSpread
    Friend WithEvents TXTASSOCIATENAME As System.Windows.Forms.TextBox
    Friend WithEvents GBHALLSTATUS As System.Windows.Forms.GroupBox
    Friend WithEvents SSgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents CMDPRINT1 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CMD_VOUCHERNOHELP As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TXTRECAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents Btn_BIRTH1 As System.Windows.Forms.Button
    Friend WithEvents DTPVOUCHERDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TXTVOUCHERNO As System.Windows.Forms.TextBox
    Friend WithEvents CMB_BRITH As System.Windows.Forms.ComboBox
    Friend WithEvents RDBRECEIPTENTRY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBHALLAVAILABLITY As System.Windows.Forms.RadioButton
    Friend WithEvents RDBPARTYBOOKINGTIME As System.Windows.Forms.RadioButton
    Friend WithEvents GRPRECEIPT As System.Windows.Forms.GroupBox
    Friend WithEvents ssgrid_Receipt As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cmd_Status As System.Windows.Forms.Button
    Friend WithEvents grchoice As System.Windows.Forms.GroupBox
    Friend WithEvents Pic_Sign As System.Windows.Forms.PictureBox
    Friend WithEvents Pic_Member As System.Windows.Forms.PictureBox
    Friend WithEvents Pic_spousesign As System.Windows.Forms.PictureBox
    Friend WithEvents Pic_Spouse As System.Windows.Forms.PictureBox
    Friend WithEvents halldescription As System.Windows.Forms.TextBox
    Friend WithEvents TxtOCCUPANCY As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CMB_LOCATION As System.Windows.Forms.ComboBox
    Friend WithEvents LBL_PARTYDAY As System.Windows.Forms.Label
    Friend WithEvents LBL_BOOKDAY As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtVOCCUPANCY As System.Windows.Forms.TextBox
    Friend WithEvents TxtNVOCCUPANCY As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmd_freeze1 As System.Windows.Forms.Button
    Friend WithEvents txt_res As System.Windows.Forms.TextBox
    Friend WithEvents lbl_reson As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TXT_TOTAMT As System.Windows.Forms.TextBox
    Friend WithEvents TXT_DISAMT As System.Windows.Forms.TextBox
    Friend WithEvents TXTB_BAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TXTGUESTNAME As System.Windows.Forms.TextBox
    Friend WithEvents TxtGUESTNAME1 As System.Windows.Forms.TextBox
    Friend WithEvents TXT_DISCOUNT As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Hallstatus))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Chk_FloodTax = New System.Windows.Forms.CheckBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Txt_StateCode = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Txt_MemGstNo = New System.Windows.Forms.TextBox()
        Me.cmd_Purpose = New System.Windows.Forms.Button()
        Me.Cmb_DayBasis = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Txt_CityPin = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Txt_Add2 = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Txt_Add1 = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Cmb_StatusType = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Cmb_GuestType = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TxtNVOCCUPANCY = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TXT_CELLNO = New System.Windows.Forms.TextBox()
        Me.TXT_EMAIL = New System.Windows.Forms.TextBox()
        Me.cmd_helpbooingno = New System.Windows.Forms.Button()
        Me.cmd_mcodehelp = New System.Windows.Forms.Button()
        Me.TXTGUESTNAME = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TxtVOCCUPANCY = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LBL_BOOKDAY = New System.Windows.Forms.Label()
        Me.LBL_PARTYDAY = New System.Windows.Forms.Label()
        Me.TxtOCCUPANCY = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TXTASSOCIATENAME = New System.Windows.Forms.TextBox()
        Me.Dtppartydate = New System.Windows.Forms.DateTimePicker()
        Me.cmd_mcodehelp2 = New System.Windows.Forms.Button()
        Me.txtmcode = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtmname = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmd_helpbooingno1 = New System.Windows.Forms.Button()
        Me.TXTBOOKINGNO = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DTPBOOKINGDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtDescription = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RBASSOCIATEMEMBER = New System.Windows.Forms.RadioButton()
        Me.RBCLUBMEMBER = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.cmd_hallcodehelp = New System.Windows.Forms.Button()
        Me.txthallcode = New System.Windows.Forms.TextBox()
        Me.grchoice = New System.Windows.Forms.GroupBox()
        Me.RDBRECEIPTENTRY = New System.Windows.Forms.RadioButton()
        Me.RDBHALLAVAILABLITY = New System.Windows.Forms.RadioButton()
        Me.RDBPARTYBOOKINGTIME = New System.Windows.Forms.RadioButton()
        Me.TxtGUESTNAME1 = New System.Windows.Forms.TextBox()
        Me.halldescription = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmd_freeze1 = New System.Windows.Forms.Button()
        Me.CMDPRINT1 = New System.Windows.Forms.Button()
        Me.Cmd_Add1 = New System.Windows.Forms.Button()
        Me.Cmd_View1 = New System.Windows.Forms.Button()
        Me.Cmd_Clear1 = New System.Windows.Forms.Button()
        Me.cmd_Exit1 = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.cmd_advance = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GBHALLBOOKING = New System.Windows.Forms.GroupBox()
        Me.SSGRID_BOOKING = New AxFPSpreadADO.AxfpSpread()
        Me.GBHALLSTATUS = New System.Windows.Forms.GroupBox()
        Me.SSgrid = New AxFPSpreadADO.AxfpSpread()
        Me.Cmd_Freeze2 = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CMD_VOUCHERNOHELP = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TXTRECAMOUNT = New System.Windows.Forms.TextBox()
        Me.Btn_BIRTH1 = New System.Windows.Forms.Button()
        Me.DTPVOUCHERDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TXTVOUCHERNO = New System.Windows.Forms.TextBox()
        Me.CMB_BRITH = New System.Windows.Forms.ComboBox()
        Me.GRPRECEIPT = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.ssgrid_Receipt = New AxFPSpreadADO.AxfpSpread()
        Me.cmd_Status = New System.Windows.Forms.Button()
        Me.Pic_Sign = New System.Windows.Forms.PictureBox()
        Me.Pic_Member = New System.Windows.Forms.PictureBox()
        Me.Pic_spousesign = New System.Windows.Forms.PictureBox()
        Me.Pic_Spouse = New System.Windows.Forms.PictureBox()
        Me.CMB_LOCATION = New System.Windows.Forms.ComboBox()
        Me.lbl_reson = New System.Windows.Forms.Label()
        Me.txt_res = New System.Windows.Forms.TextBox()
        Me.TXT_TOTAMT = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TXT_DISAMT = New System.Windows.Forms.TextBox()
        Me.TXTB_BAMOUNT = New System.Windows.Forms.TextBox()
        Me.TXT_DISCOUNT = New System.Windows.Forms.TextBox()
        Me.Btn_Hallres = New System.Windows.Forms.Button()
        Me.Btn_Hallava = New System.Windows.Forms.Button()
        Me.Btn_recdet = New System.Windows.Forms.Button()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.cmd_exit = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmd_view = New System.Windows.Forms.Button()
        Me.cmd_freeze = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.btn_rent = New System.Windows.Forms.Button()
        Me.Txt_Others = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.grchoice.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBHALLBOOKING.SuspendLayout()
        CType(Me.SSGRID_BOOKING, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBHALLSTATUS.SuspendLayout()
        CType(Me.SSgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GRPRECEIPT.SuspendLayout()
        CType(Me.ssgrid_Receipt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Sign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Member, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_spousesign, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Pic_Spouse, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Chk_FloodTax)
        Me.GroupBox1.Controls.Add(Me.Label35)
        Me.GroupBox1.Controls.Add(Me.Txt_StateCode)
        Me.GroupBox1.Controls.Add(Me.Label34)
        Me.GroupBox1.Controls.Add(Me.Txt_MemGstNo)
        Me.GroupBox1.Controls.Add(Me.cmd_Purpose)
        Me.GroupBox1.Controls.Add(Me.Cmb_DayBasis)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Controls.Add(Me.Txt_CityPin)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.Txt_Add2)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Txt_Add1)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.Cmb_StatusType)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.Cmb_GuestType)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.TxtNVOCCUPANCY)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.TXT_CELLNO)
        Me.GroupBox1.Controls.Add(Me.TXT_EMAIL)
        Me.GroupBox1.Controls.Add(Me.cmd_helpbooingno)
        Me.GroupBox1.Controls.Add(Me.cmd_mcodehelp)
        Me.GroupBox1.Controls.Add(Me.TXTGUESTNAME)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.TxtVOCCUPANCY)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.LBL_BOOKDAY)
        Me.GroupBox1.Controls.Add(Me.LBL_PARTYDAY)
        Me.GroupBox1.Controls.Add(Me.TxtOCCUPANCY)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.TXTASSOCIATENAME)
        Me.GroupBox1.Controls.Add(Me.Dtppartydate)
        Me.GroupBox1.Controls.Add(Me.cmd_mcodehelp2)
        Me.GroupBox1.Controls.Add(Me.txtmcode)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtmname)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmd_helpbooingno1)
        Me.GroupBox1.Controls.Add(Me.TXTBOOKINGNO)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.DTPBOOKINGDATE)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.TxtDescription)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(182, 96)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(657, 256)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Chk_FloodTax
        '
        Me.Chk_FloodTax.AutoSize = True
        Me.Chk_FloodTax.Location = New System.Drawing.Point(566, 119)
        Me.Chk_FloodTax.Name = "Chk_FloodTax"
        Me.Chk_FloodTax.Size = New System.Drawing.Size(93, 22)
        Me.Chk_FloodTax.TabIndex = 878
        Me.Chk_FloodTax.Text = "Flood Tax"
        Me.Chk_FloodTax.UseVisualStyleBackColor = True
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(543, 68)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(58, 15)
        Me.Label35.TabIndex = 877
        Me.Label35.Text = "ST CODE"
        '
        'Txt_StateCode
        '
        Me.Txt_StateCode.BackColor = System.Drawing.Color.Wheat
        Me.Txt_StateCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_StateCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_StateCode.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_StateCode.Location = New System.Drawing.Point(604, 66)
        Me.Txt_StateCode.MaxLength = 2
        Me.Txt_StateCode.Name = "Txt_StateCode"
        Me.Txt_StateCode.Size = New System.Drawing.Size(49, 21)
        Me.Txt_StateCode.TabIndex = 876
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(321, 69)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(98, 15)
        Me.Label34.TabIndex = 875
        Me.Label34.Text = "MEM GSTIN NO"
        '
        'Txt_MemGstNo
        '
        Me.Txt_MemGstNo.BackColor = System.Drawing.Color.Wheat
        Me.Txt_MemGstNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_MemGstNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_MemGstNo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_MemGstNo.Location = New System.Drawing.Point(422, 65)
        Me.Txt_MemGstNo.Name = "Txt_MemGstNo"
        Me.Txt_MemGstNo.Size = New System.Drawing.Size(117, 21)
        Me.Txt_MemGstNo.TabIndex = 874
        '
        'cmd_Purpose
        '
        Me.cmd_Purpose.Location = New System.Drawing.Point(621, 36)
        Me.cmd_Purpose.Name = "cmd_Purpose"
        Me.cmd_Purpose.Size = New System.Drawing.Size(34, 24)
        Me.cmd_Purpose.TabIndex = 873
        Me.cmd_Purpose.Text = "?"
        Me.cmd_Purpose.UseVisualStyleBackColor = True
        '
        'Cmb_DayBasis
        '
        Me.Cmb_DayBasis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_DayBasis.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_DayBasis.FormattingEnabled = True
        Me.Cmb_DayBasis.Items.AddRange(New Object() {"Hour", "Day"})
        Me.Cmb_DayBasis.Location = New System.Drawing.Point(525, 225)
        Me.Cmb_DayBasis.Name = "Cmb_DayBasis"
        Me.Cmb_DayBasis.Size = New System.Drawing.Size(122, 23)
        Me.Cmb_DayBasis.TabIndex = 872
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(406, 229)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(111, 15)
        Me.Label33.TabIndex = 871
        Me.Label33.Text = "DAY/HOUR BASIS"
        '
        'Txt_CityPin
        '
        Me.Txt_CityPin.BackColor = System.Drawing.Color.Wheat
        Me.Txt_CityPin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_CityPin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_CityPin.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_CityPin.Location = New System.Drawing.Point(114, 169)
        Me.Txt_CityPin.Name = "Txt_CityPin"
        Me.Txt_CityPin.Size = New System.Drawing.Size(177, 21)
        Me.Txt_CityPin.TabIndex = 870
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(16, 168)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(96, 23)
        Me.Label32.TabIndex = 869
        Me.Label32.Text = "CITY-PIN"
        '
        'Txt_Add2
        '
        Me.Txt_Add2.BackColor = System.Drawing.Color.Wheat
        Me.Txt_Add2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Add2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Add2.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Add2.Location = New System.Drawing.Point(424, 147)
        Me.Txt_Add2.Name = "Txt_Add2"
        Me.Txt_Add2.Size = New System.Drawing.Size(177, 21)
        Me.Txt_Add2.TabIndex = 868
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(319, 147)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(96, 23)
        Me.Label31.TabIndex = 867
        Me.Label31.Text = "ADDRESS2"
        '
        'Txt_Add1
        '
        Me.Txt_Add1.BackColor = System.Drawing.Color.Wheat
        Me.Txt_Add1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Add1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Add1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Add1.Location = New System.Drawing.Point(114, 141)
        Me.Txt_Add1.Name = "Txt_Add1"
        Me.Txt_Add1.Size = New System.Drawing.Size(177, 21)
        Me.Txt_Add1.TabIndex = 866
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(15, 141)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(96, 23)
        Me.Label30.TabIndex = 865
        Me.Label30.Text = "ADDRESS1"
        '
        'Cmb_StatusType
        '
        Me.Cmb_StatusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_StatusType.Enabled = False
        Me.Cmb_StatusType.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_StatusType.FormattingEnabled = True
        Me.Cmb_StatusType.Items.AddRange(New Object() {"PROVISIONAL", "CONFIRMED"})
        Me.Cmb_StatusType.Location = New System.Drawing.Point(424, 119)
        Me.Cmb_StatusType.Name = "Cmb_StatusType"
        Me.Cmb_StatusType.Size = New System.Drawing.Size(133, 23)
        Me.Cmb_StatusType.TabIndex = 864
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(319, 116)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(54, 15)
        Me.Label29.TabIndex = 863
        Me.Label29.Text = "STATUS"
        '
        'Cmb_GuestType
        '
        Me.Cmb_GuestType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_GuestType.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmb_GuestType.FormattingEnabled = True
        Me.Cmb_GuestType.Items.AddRange(New Object() {"OTHERS", "MEMBER"})
        Me.Cmb_GuestType.Location = New System.Drawing.Point(115, 63)
        Me.Cmb_GuestType.Name = "Cmb_GuestType"
        Me.Cmb_GuestType.Size = New System.Drawing.Size(133, 23)
        Me.Cmb_GuestType.TabIndex = 862
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(18, 63)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(79, 15)
        Me.Label27.TabIndex = 861
        Me.Label27.Text = "GUEST TYPE"
        '
        'TxtNVOCCUPANCY
        '
        Me.TxtNVOCCUPANCY.BackColor = System.Drawing.Color.Wheat
        Me.TxtNVOCCUPANCY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNVOCCUPANCY.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNVOCCUPANCY.Location = New System.Drawing.Point(115, 225)
        Me.TxtNVOCCUPANCY.MaxLength = 5
        Me.TxtNVOCCUPANCY.Name = "TxtNVOCCUPANCY"
        Me.TxtNVOCCUPANCY.Size = New System.Drawing.Size(98, 21)
        Me.TxtNVOCCUPANCY.TabIndex = 849
        Me.TxtNVOCCUPANCY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(317, 174)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(47, 15)
        Me.Label26.TabIndex = 859
        Me.Label26.Text = "EMAIL"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(18, 204)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(57, 15)
        Me.Label25.TabIndex = 858
        Me.Label25.Text = "CELL NO"
        '
        'TXT_CELLNO
        '
        Me.TXT_CELLNO.BackColor = System.Drawing.Color.Wheat
        Me.TXT_CELLNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_CELLNO.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_CELLNO.Location = New System.Drawing.Point(115, 196)
        Me.TXT_CELLNO.MaxLength = 10
        Me.TXT_CELLNO.Name = "TXT_CELLNO"
        Me.TXT_CELLNO.Size = New System.Drawing.Size(98, 21)
        Me.TXT_CELLNO.TabIndex = 857
        Me.TXT_CELLNO.WordWrap = False
        '
        'TXT_EMAIL
        '
        Me.TXT_EMAIL.BackColor = System.Drawing.Color.Wheat
        Me.TXT_EMAIL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_EMAIL.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_EMAIL.Location = New System.Drawing.Point(424, 174)
        Me.TXT_EMAIL.MaxLength = 35
        Me.TXT_EMAIL.Name = "TXT_EMAIL"
        Me.TXT_EMAIL.Size = New System.Drawing.Size(222, 21)
        Me.TXT_EMAIL.TabIndex = 856
        Me.TXT_EMAIL.WordWrap = False
        '
        'cmd_helpbooingno
        '
        Me.cmd_helpbooingno.Location = New System.Drawing.Point(213, 8)
        Me.cmd_helpbooingno.Name = "cmd_helpbooingno"
        Me.cmd_helpbooingno.Size = New System.Drawing.Size(40, 26)
        Me.cmd_helpbooingno.TabIndex = 855
        Me.cmd_helpbooingno.Text = "?"
        Me.cmd_helpbooingno.UseVisualStyleBackColor = True
        '
        'cmd_mcodehelp
        '
        Me.cmd_mcodehelp.Location = New System.Drawing.Point(213, 89)
        Me.cmd_mcodehelp.Name = "cmd_mcodehelp"
        Me.cmd_mcodehelp.Size = New System.Drawing.Size(40, 22)
        Me.cmd_mcodehelp.TabIndex = 854
        Me.cmd_mcodehelp.Text = "?"
        Me.cmd_mcodehelp.UseVisualStyleBackColor = True
        '
        'TXTGUESTNAME
        '
        Me.TXTGUESTNAME.BackColor = System.Drawing.Color.Wheat
        Me.TXTGUESTNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTGUESTNAME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTGUESTNAME.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTGUESTNAME.Location = New System.Drawing.Point(114, 114)
        Me.TXTGUESTNAME.Name = "TXTGUESTNAME"
        Me.TXTGUESTNAME.Size = New System.Drawing.Size(177, 21)
        Me.TXTGUESTNAME.TabIndex = 853
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(18, 114)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(96, 23)
        Me.Label24.TabIndex = 852
        Me.Label24.Text = "GUESTNAME"
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(12, 225)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(97, 23)
        Me.Label23.TabIndex = 851
        Me.Label23.Text = "NON.VEG PAXS"
        '
        'TxtVOCCUPANCY
        '
        Me.TxtVOCCUPANCY.BackColor = System.Drawing.Color.Wheat
        Me.TxtVOCCUPANCY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVOCCUPANCY.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVOCCUPANCY.Location = New System.Drawing.Point(296, 225)
        Me.TxtVOCCUPANCY.MaxLength = 5
        Me.TxtVOCCUPANCY.Name = "TxtVOCCUPANCY"
        Me.TxtVOCCUPANCY.Size = New System.Drawing.Size(104, 21)
        Me.TxtVOCCUPANCY.TabIndex = 847
        Me.TxtVOCCUPANCY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(220, 228)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 15)
        Me.Label14.TabIndex = 848
        Me.Label14.Text = "VEG PAXS"
        '
        'LBL_BOOKDAY
        '
        Me.LBL_BOOKDAY.BackColor = System.Drawing.Color.Transparent
        Me.LBL_BOOKDAY.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_BOOKDAY.Location = New System.Drawing.Point(546, 13)
        Me.LBL_BOOKDAY.Name = "LBL_BOOKDAY"
        Me.LBL_BOOKDAY.Size = New System.Drawing.Size(74, 15)
        Me.LBL_BOOKDAY.TabIndex = 846
        Me.LBL_BOOKDAY.Text = "DAY NAME"
        '
        'LBL_PARTYDAY
        '
        Me.LBL_PARTYDAY.BackColor = System.Drawing.Color.Transparent
        Me.LBL_PARTYDAY.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_PARTYDAY.Location = New System.Drawing.Point(243, 44)
        Me.LBL_PARTYDAY.Name = "LBL_PARTYDAY"
        Me.LBL_PARTYDAY.Size = New System.Drawing.Size(74, 15)
        Me.LBL_PARTYDAY.TabIndex = 845
        Me.LBL_PARTYDAY.Text = "DAY NAME"
        '
        'TxtOCCUPANCY
        '
        Me.TxtOCCUPANCY.BackColor = System.Drawing.Color.Wheat
        Me.TxtOCCUPANCY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOCCUPANCY.Enabled = False
        Me.TxtOCCUPANCY.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOCCUPANCY.Location = New System.Drawing.Point(424, 201)
        Me.TxtOCCUPANCY.MaxLength = 5
        Me.TxtOCCUPANCY.Name = "TxtOCCUPANCY"
        Me.TxtOCCUPANCY.Size = New System.Drawing.Size(98, 21)
        Me.TxtOCCUPANCY.TabIndex = 843
        Me.TxtOCCUPANCY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(316, 201)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 15)
        Me.Label17.TabIndex = 844
        Me.Label17.Text = "PAXS"
        '
        'TXTASSOCIATENAME
        '
        Me.TXTASSOCIATENAME.BackColor = System.Drawing.Color.Wheat
        Me.TXTASSOCIATENAME.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTASSOCIATENAME.Location = New System.Drawing.Point(-27, 138)
        Me.TXTASSOCIATENAME.MaxLength = 30
        Me.TXTASSOCIATENAME.Name = "TXTASSOCIATENAME"
        Me.TXTASSOCIATENAME.Size = New System.Drawing.Size(24, 26)
        Me.TXTASSOCIATENAME.TabIndex = 607
        Me.TXTASSOCIATENAME.Visible = False
        '
        'Dtppartydate
        '
        Me.Dtppartydate.CustomFormat = ""
        Me.Dtppartydate.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtppartydate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtppartydate.Location = New System.Drawing.Point(116, 36)
        Me.Dtppartydate.Name = "Dtppartydate"
        Me.Dtppartydate.Size = New System.Drawing.Size(120, 21)
        Me.Dtppartydate.TabIndex = 6
        '
        'cmd_mcodehelp2
        '
        Me.cmd_mcodehelp2.Image = CType(resources.GetObject("cmd_mcodehelp2.Image"), System.Drawing.Image)
        Me.cmd_mcodehelp2.Location = New System.Drawing.Point(232, 86)
        Me.cmd_mcodehelp2.Name = "cmd_mcodehelp2"
        Me.cmd_mcodehelp2.Size = New System.Drawing.Size(24, 26)
        Me.cmd_mcodehelp2.TabIndex = 10
        Me.cmd_mcodehelp2.Visible = False
        '
        'txtmcode
        '
        Me.txtmcode.BackColor = System.Drawing.Color.Wheat
        Me.txtmcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmcode.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmcode.Location = New System.Drawing.Point(115, 89)
        Me.txtmcode.MaxLength = 12
        Me.txtmcode.Name = "txtmcode"
        Me.txtmcode.Size = New System.Drawing.Size(97, 21)
        Me.txtmcode.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 15)
        Me.Label9.TabIndex = 362
        Me.Label9.Text = "MEMBER CODE"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 15)
        Me.Label1.TabIndex = 362
        Me.Label1.Text = "PARTY DATE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(320, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 362
        Me.Label2.Text = "PURPOSE"
        '
        'txtmname
        '
        Me.txtmname.BackColor = System.Drawing.Color.Wheat
        Me.txtmname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtmname.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmname.Location = New System.Drawing.Point(422, 91)
        Me.txtmname.MaxLength = 50
        Me.txtmname.Name = "txtmname"
        Me.txtmname.ReadOnly = True
        Me.txtmname.Size = New System.Drawing.Size(222, 21)
        Me.txtmname.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(317, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 15)
        Me.Label6.TabIndex = 362
        Me.Label6.Text = "MEMBER NAME"
        '
        'cmd_helpbooingno1
        '
        Me.cmd_helpbooingno1.Image = CType(resources.GetObject("cmd_helpbooingno1.Image"), System.Drawing.Image)
        Me.cmd_helpbooingno1.Location = New System.Drawing.Point(231, 16)
        Me.cmd_helpbooingno1.Name = "cmd_helpbooingno1"
        Me.cmd_helpbooingno1.Size = New System.Drawing.Size(24, 26)
        Me.cmd_helpbooingno1.TabIndex = 1
        Me.cmd_helpbooingno1.Visible = False
        '
        'TXTBOOKINGNO
        '
        Me.TXTBOOKINGNO.BackColor = System.Drawing.Color.Wheat
        Me.TXTBOOKINGNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXTBOOKINGNO.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTBOOKINGNO.Location = New System.Drawing.Point(117, 11)
        Me.TXTBOOKINGNO.MaxLength = 10
        Me.TXTBOOKINGNO.Name = "TXTBOOKINGNO"
        Me.TXTBOOKINGNO.Size = New System.Drawing.Size(96, 21)
        Me.TXTBOOKINGNO.TabIndex = 0
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(18, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 15)
        Me.Label11.TabIndex = 362
        Me.Label11.Text = "BOOKING NO"
        '
        'DTPBOOKINGDATE
        '
        Me.DTPBOOKINGDATE.CustomFormat = ""
        Me.DTPBOOKINGDATE.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPBOOKINGDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPBOOKINGDATE.Location = New System.Drawing.Point(422, 11)
        Me.DTPBOOKINGDATE.Name = "DTPBOOKINGDATE"
        Me.DTPBOOKINGDATE.Size = New System.Drawing.Size(120, 21)
        Me.DTPBOOKINGDATE.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(321, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(99, 15)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "BOOKING DATE"
        '
        'TxtDescription
        '
        Me.TxtDescription.BackColor = System.Drawing.Color.Wheat
        Me.TxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDescription.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(422, 38)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(198, 21)
        Me.TxtDescription.TabIndex = 397
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(329, 16)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 18)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "LOCATION"
        Me.Label18.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(6, 247)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 18)
        Me.Label3.TabIndex = 362
        Me.Label3.Text = "ASSOCIATE NAME"
        Me.Label3.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 474)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(46, 15)
        Me.GroupBox3.TabIndex = 606
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(6, 434)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 18)
        Me.Label4.TabIndex = 362
        Me.Label4.Text = "MEMBER TYPE"
        Me.Label4.Visible = False
        '
        'RBASSOCIATEMEMBER
        '
        Me.RBASSOCIATEMEMBER.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RBASSOCIATEMEMBER.Location = New System.Drawing.Point(0, 390)
        Me.RBASSOCIATEMEMBER.Name = "RBASSOCIATEMEMBER"
        Me.RBASSOCIATEMEMBER.Size = New System.Drawing.Size(160, 24)
        Me.RBASSOCIATEMEMBER.TabIndex = 8
        Me.RBASSOCIATEMEMBER.Text = "ASSOCIATE MEMBER"
        Me.RBASSOCIATEMEMBER.Visible = False
        '
        'RBCLUBMEMBER
        '
        Me.RBCLUBMEMBER.Checked = True
        Me.RBCLUBMEMBER.Font = New System.Drawing.Font("Courier New", 10.0!, System.Drawing.FontStyle.Bold)
        Me.RBCLUBMEMBER.Location = New System.Drawing.Point(0, 360)
        Me.RBCLUBMEMBER.Name = "RBCLUBMEMBER"
        Me.RBCLUBMEMBER.Size = New System.Drawing.Size(128, 24)
        Me.RBCLUBMEMBER.TabIndex = 7
        Me.RBCLUBMEMBER.TabStop = True
        Me.RBCLUBMEMBER.Text = "CLUB MEMBER"
        Me.RBCLUBMEMBER.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(12, 306)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 18)
        Me.Label5.TabIndex = 362
        Me.Label5.Text = "HALL CODE"
        Me.Label5.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 332)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 18)
        Me.Label15.TabIndex = 850
        Me.Label15.Text = " NO. PAXS"
        Me.Label15.Visible = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(561, 81)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(188, 15)
        Me.lbl_Freeze.TabIndex = 396
        Me.lbl_Freeze.Text = "THIS  BOOKING IS CANCELLED "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmd_hallcodehelp
        '
        Me.cmd_hallcodehelp.Image = CType(resources.GetObject("cmd_hallcodehelp.Image"), System.Drawing.Image)
        Me.cmd_hallcodehelp.Location = New System.Drawing.Point(136, 241)
        Me.cmd_hallcodehelp.Name = "cmd_hallcodehelp"
        Me.cmd_hallcodehelp.Size = New System.Drawing.Size(24, 26)
        Me.cmd_hallcodehelp.TabIndex = 4
        Me.cmd_hallcodehelp.Visible = False
        '
        'txthallcode
        '
        Me.txthallcode.BackColor = System.Drawing.Color.Wheat
        Me.txthallcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txthallcode.Location = New System.Drawing.Point(111, 259)
        Me.txthallcode.MaxLength = 12
        Me.txthallcode.Name = "txthallcode"
        Me.txthallcode.Size = New System.Drawing.Size(49, 26)
        Me.txthallcode.TabIndex = 3
        Me.txthallcode.Visible = False
        Me.txthallcode.WordWrap = False
        '
        'grchoice
        '
        Me.grchoice.BackColor = System.Drawing.Color.Transparent
        Me.grchoice.Controls.Add(Me.RDBRECEIPTENTRY)
        Me.grchoice.Controls.Add(Me.RDBHALLAVAILABLITY)
        Me.grchoice.Controls.Add(Me.RDBPARTYBOOKINGTIME)
        Me.grchoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.grchoice.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grchoice.Location = New System.Drawing.Point(212, 30)
        Me.grchoice.Name = "grchoice"
        Me.grchoice.Size = New System.Drawing.Size(124, 43)
        Me.grchoice.TabIndex = 842
        Me.grchoice.TabStop = False
        Me.grchoice.Visible = False
        '
        'RDBRECEIPTENTRY
        '
        Me.RDBRECEIPTENTRY.BackColor = System.Drawing.Color.Transparent
        Me.RDBRECEIPTENTRY.Font = New System.Drawing.Font("Courier New", 14.0!, System.Drawing.FontStyle.Bold)
        Me.RDBRECEIPTENTRY.ForeColor = System.Drawing.Color.Teal
        Me.RDBRECEIPTENTRY.Location = New System.Drawing.Point(500, 20)
        Me.RDBRECEIPTENTRY.Name = "RDBRECEIPTENTRY"
        Me.RDBRECEIPTENTRY.Size = New System.Drawing.Size(208, 24)
        Me.RDBRECEIPTENTRY.TabIndex = 612
        Me.RDBRECEIPTENTRY.Text = "RECEIPT DETAILS"
        Me.RDBRECEIPTENTRY.UseVisualStyleBackColor = False
        '
        'RDBHALLAVAILABLITY
        '
        Me.RDBHALLAVAILABLITY.BackColor = System.Drawing.Color.Transparent
        Me.RDBHALLAVAILABLITY.Font = New System.Drawing.Font("Courier New", 14.0!, System.Drawing.FontStyle.Bold)
        Me.RDBHALLAVAILABLITY.ForeColor = System.Drawing.Color.Teal
        Me.RDBHALLAVAILABLITY.Location = New System.Drawing.Point(312, 24)
        Me.RDBHALLAVAILABLITY.Name = "RDBHALLAVAILABLITY"
        Me.RDBHALLAVAILABLITY.Size = New System.Drawing.Size(224, 24)
        Me.RDBHALLAVAILABLITY.TabIndex = 611
        Me.RDBHALLAVAILABLITY.Text = "HALL AVAILABLITY"
        Me.RDBHALLAVAILABLITY.UseVisualStyleBackColor = False
        '
        'RDBPARTYBOOKINGTIME
        '
        Me.RDBPARTYBOOKINGTIME.BackColor = System.Drawing.Color.Transparent
        Me.RDBPARTYBOOKINGTIME.Checked = True
        Me.RDBPARTYBOOKINGTIME.Font = New System.Drawing.Font("Courier New", 14.0!, System.Drawing.FontStyle.Bold)
        Me.RDBPARTYBOOKINGTIME.ForeColor = System.Drawing.Color.Teal
        Me.RDBPARTYBOOKINGTIME.Location = New System.Drawing.Point(8, 24)
        Me.RDBPARTYBOOKINGTIME.Name = "RDBPARTYBOOKINGTIME"
        Me.RDBPARTYBOOKINGTIME.Size = New System.Drawing.Size(288, 24)
        Me.RDBPARTYBOOKINGTIME.TabIndex = 610
        Me.RDBPARTYBOOKINGTIME.TabStop = True
        Me.RDBPARTYBOOKINGTIME.Text = "HALL RESERVATION TIME"
        Me.RDBPARTYBOOKINGTIME.UseVisualStyleBackColor = False
        '
        'TxtGUESTNAME1
        '
        Me.TxtGUESTNAME1.Location = New System.Drawing.Point(0, 0)
        Me.TxtGUESTNAME1.Name = "TxtGUESTNAME1"
        Me.TxtGUESTNAME1.Size = New System.Drawing.Size(100, 20)
        Me.TxtGUESTNAME1.TabIndex = 0
        '
        'halldescription
        '
        Me.halldescription.BackColor = System.Drawing.Color.Wheat
        Me.halldescription.Enabled = False
        Me.halldescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.halldescription.Location = New System.Drawing.Point(16, -48)
        Me.halldescription.MaxLength = 50
        Me.halldescription.Name = "halldescription"
        Me.halldescription.Size = New System.Drawing.Size(304, 26)
        Me.halldescription.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(177, 67)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(383, 29)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = " BANQUET HALL RESERVATION"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmd_freeze1)
        Me.GroupBox2.Controls.Add(Me.CMDPRINT1)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add1)
        Me.GroupBox2.Controls.Add(Me.Cmd_View1)
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear1)
        Me.GroupBox2.Controls.Add(Me.cmd_Exit1)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Cmdbwse)
        Me.GroupBox2.Location = New System.Drawing.Point(96, 685)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(687, 56)
        Me.GroupBox2.TabIndex = 375
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'cmd_freeze1
        '
        Me.cmd_freeze1.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_freeze1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_freeze1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_freeze1.ForeColor = System.Drawing.Color.White
        Me.cmd_freeze1.Image = CType(resources.GetObject("cmd_freeze1.Image"), System.Drawing.Image)
        Me.cmd_freeze1.Location = New System.Drawing.Point(264, 16)
        Me.cmd_freeze1.Name = "cmd_freeze1"
        Me.cmd_freeze1.Size = New System.Drawing.Size(104, 32)
        Me.cmd_freeze1.TabIndex = 851
        Me.cmd_freeze1.Text = "Freeze[F8]"
        Me.cmd_freeze1.UseVisualStyleBackColor = False
        Me.cmd_freeze1.Visible = False
        '
        'CMDPRINT1
        '
        Me.CMDPRINT1.BackColor = System.Drawing.Color.ForestGreen
        Me.CMDPRINT1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMDPRINT1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDPRINT1.ForeColor = System.Drawing.Color.White
        Me.CMDPRINT1.Image = CType(resources.GetObject("CMDPRINT1.Image"), System.Drawing.Image)
        Me.CMDPRINT1.Location = New System.Drawing.Point(496, 16)
        Me.CMDPRINT1.Name = "CMDPRINT1"
        Me.CMDPRINT1.Size = New System.Drawing.Size(104, 32)
        Me.CMDPRINT1.TabIndex = 24
        Me.CMDPRINT1.Text = " Print[F10]"
        Me.CMDPRINT1.UseVisualStyleBackColor = False
        '
        'Cmd_Add1
        '
        Me.Cmd_Add1.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add1.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add1.Image = CType(resources.GetObject("Cmd_Add1.Image"), System.Drawing.Image)
        Me.Cmd_Add1.Location = New System.Drawing.Point(152, 16)
        Me.Cmd_Add1.Name = "Cmd_Add1"
        Me.Cmd_Add1.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add1.TabIndex = 17
        Me.Cmd_Add1.Text = "Add [F7]"
        Me.Cmd_Add1.UseVisualStyleBackColor = False
        '
        'Cmd_View1
        '
        Me.Cmd_View1.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View1.ForeColor = System.Drawing.Color.White
        Me.Cmd_View1.Image = CType(resources.GetObject("Cmd_View1.Image"), System.Drawing.Image)
        Me.Cmd_View1.Location = New System.Drawing.Point(376, 16)
        Me.Cmd_View1.Name = "Cmd_View1"
        Me.Cmd_View1.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View1.TabIndex = 22
        Me.Cmd_View1.Text = " View[F9]"
        Me.Cmd_View1.UseVisualStyleBackColor = False
        '
        'Cmd_Clear1
        '
        Me.Cmd_Clear1.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Clear1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear1.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear1.Image = CType(resources.GetObject("Cmd_Clear1.Image"), System.Drawing.Image)
        Me.Cmd_Clear1.Location = New System.Drawing.Point(40, 16)
        Me.Cmd_Clear1.Name = "Cmd_Clear1"
        Me.Cmd_Clear1.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear1.TabIndex = 18
        Me.Cmd_Clear1.Text = "Clear[F6]"
        Me.Cmd_Clear1.UseVisualStyleBackColor = False
        '
        'cmd_Exit1
        '
        Me.cmd_Exit1.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_Exit1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Exit1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Exit1.ForeColor = System.Drawing.Color.White
        Me.cmd_Exit1.Image = CType(resources.GetObject("cmd_Exit1.Image"), System.Drawing.Image)
        Me.cmd_Exit1.Location = New System.Drawing.Point(608, 16)
        Me.cmd_Exit1.Name = "cmd_Exit1"
        Me.cmd_Exit1.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Exit1.TabIndex = 23
        Me.cmd_Exit1.Text = "Exit[F11]"
        Me.cmd_Exit1.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.Black
        Me.Label20.Location = New System.Drawing.Point(-128, -16)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(384, 16)
        Me.Label20.TabIndex = 839
        Me.Label20.Text = "Press F4 for HELP / Press ENTER key to navigate"
        '
        'Cmdbwse
        '
        Me.Cmdbwse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbwse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbwse.Location = New System.Drawing.Point(290, -1)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(138, 65)
        Me.Cmdbwse.TabIndex = 866
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.UseVisualStyleBackColor = True
        '
        'cmd_advance
        '
        Me.cmd_advance.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_advance.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_advance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_advance.ForeColor = System.Drawing.Color.White
        Me.cmd_advance.Image = CType(resources.GetObject("cmd_advance.Image"), System.Drawing.Image)
        Me.cmd_advance.Location = New System.Drawing.Point(0, 584)
        Me.cmd_advance.Name = "cmd_advance"
        Me.cmd_advance.Size = New System.Drawing.Size(104, 32)
        Me.cmd_advance.TabIndex = 21
        Me.cmd_advance.Text = "Billing[F12]"
        Me.cmd_advance.UseVisualStyleBackColor = False
        Me.cmd_advance.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(992, 328)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(131, 22)
        Me.Label7.TabIndex = 399
        Me.Label7.Text = "DESCRIPTION"
        Me.Label7.Visible = False
        '
        'GBHALLBOOKING
        '
        Me.GBHALLBOOKING.BackColor = System.Drawing.Color.Transparent
        Me.GBHALLBOOKING.Controls.Add(Me.SSGRID_BOOKING)
        Me.GBHALLBOOKING.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBHALLBOOKING.ForeColor = System.Drawing.Color.Black
        Me.GBHALLBOOKING.Location = New System.Drawing.Point(179, 401)
        Me.GBHALLBOOKING.Name = "GBHALLBOOKING"
        Me.GBHALLBOOKING.Size = New System.Drawing.Size(659, 198)
        Me.GBHALLBOOKING.TabIndex = 606
        Me.GBHALLBOOKING.TabStop = False
        Me.GBHALLBOOKING.Text = "HALL BOOKING"
        '
        'SSGRID_BOOKING
        '
        Me.SSGRID_BOOKING.DataSource = Nothing
        Me.SSGRID_BOOKING.Location = New System.Drawing.Point(6, 18)
        Me.SSGRID_BOOKING.Name = "SSGRID_BOOKING"
        Me.SSGRID_BOOKING.OcxState = CType(resources.GetObject("SSGRID_BOOKING.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID_BOOKING.Size = New System.Drawing.Size(639, 175)
        Me.SSGRID_BOOKING.TabIndex = 812
        '
        'GBHALLSTATUS
        '
        Me.GBHALLSTATUS.BackColor = System.Drawing.Color.Transparent
        Me.GBHALLSTATUS.Controls.Add(Me.SSgrid)
        Me.GBHALLSTATUS.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBHALLSTATUS.ForeColor = System.Drawing.Color.Black
        Me.GBHALLSTATUS.Location = New System.Drawing.Point(192, 397)
        Me.GBHALLSTATUS.Name = "GBHALLSTATUS"
        Me.GBHALLSTATUS.Size = New System.Drawing.Size(658, 202)
        Me.GBHALLSTATUS.TabIndex = 607
        Me.GBHALLSTATUS.TabStop = False
        Me.GBHALLSTATUS.Text = "HALL STATUS"
        Me.GBHALLSTATUS.Visible = False
        '
        'SSgrid
        '
        Me.SSgrid.DataSource = Nothing
        Me.SSgrid.Location = New System.Drawing.Point(6, 20)
        Me.SSgrid.Name = "SSgrid"
        Me.SSgrid.OcxState = CType(resources.GetObject("SSgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSgrid.Size = New System.Drawing.Size(646, 171)
        Me.SSgrid.TabIndex = 609
        '
        'Cmd_Freeze2
        '
        Me.Cmd_Freeze2.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze2.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze2.Image = CType(resources.GetObject("Cmd_Freeze2.Image"), System.Drawing.Image)
        Me.Cmd_Freeze2.Location = New System.Drawing.Point(789, 701)
        Me.Cmd_Freeze2.Name = "Cmd_Freeze2"
        Me.Cmd_Freeze2.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze2.TabIndex = 840
        Me.Cmd_Freeze2.Text = "Cancel[F8]"
        Me.Cmd_Freeze2.UseVisualStyleBackColor = False
        Me.Cmd_Freeze2.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.CMD_VOUCHERNOHELP)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.TXTRECAMOUNT)
        Me.GroupBox4.Controls.Add(Me.Btn_BIRTH1)
        Me.GroupBox4.Controls.Add(Me.DTPVOUCHERDATE)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.TXTVOUCHERNO)
        Me.GroupBox4.Controls.Add(Me.CMB_BRITH)
        Me.GroupBox4.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox4.Location = New System.Drawing.Point(32, 656)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(16, 64)
        Me.GroupBox4.TabIndex = 841
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "RECEIPT DETAILS"
        Me.GroupBox4.Visible = False
        '
        'CMD_VOUCHERNOHELP
        '
        Me.CMD_VOUCHERNOHELP.Image = CType(resources.GetObject("CMD_VOUCHERNOHELP.Image"), System.Drawing.Image)
        Me.CMD_VOUCHERNOHELP.Location = New System.Drawing.Point(152, 16)
        Me.CMD_VOUCHERNOHELP.Name = "CMD_VOUCHERNOHELP"
        Me.CMD_VOUCHERNOHELP.Size = New System.Drawing.Size(24, 26)
        Me.CMD_VOUCHERNOHELP.TabIndex = 14
        Me.CMD_VOUCHERNOHELP.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(704, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 18)
        Me.Label13.TabIndex = 608
        Me.Label13.Text = "AMOUNT"
        '
        'TXTRECAMOUNT
        '
        Me.TXTRECAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTRECAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTRECAMOUNT.Location = New System.Drawing.Point(776, 16)
        Me.TXTRECAMOUNT.MaxLength = 8
        Me.TXTRECAMOUNT.Name = "TXTRECAMOUNT"
        Me.TXTRECAMOUNT.Size = New System.Drawing.Size(24, 26)
        Me.TXTRECAMOUNT.TabIndex = 17
        Me.TXTRECAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Btn_BIRTH1
        '
        Me.Btn_BIRTH1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Btn_BIRTH1.Location = New System.Drawing.Point(680, 16)
        Me.Btn_BIRTH1.Name = "Btn_BIRTH1"
        Me.Btn_BIRTH1.Size = New System.Drawing.Size(24, 24)
        Me.Btn_BIRTH1.TabIndex = 16
        Me.Btn_BIRTH1.Text = "C"
        Me.Btn_BIRTH1.UseVisualStyleBackColor = False
        '
        'DTPVOUCHERDATE
        '
        Me.DTPVOUCHERDATE.CustomFormat = "dd/MM/yyyy"
        Me.DTPVOUCHERDATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPVOUCHERDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPVOUCHERDATE.Location = New System.Drawing.Point(648, 16)
        Me.DTPVOUCHERDATE.Name = "DTPVOUCHERDATE"
        Me.DTPVOUCHERDATE.Size = New System.Drawing.Size(32, 26)
        Me.DTPVOUCHERDATE.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(408, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 18)
        Me.Label8.TabIndex = 382
        Me.Label8.Text = "DATE"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(8, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 18)
        Me.Label10.TabIndex = 381
        Me.Label10.Text = "RECEIPT NO"
        '
        'TXTVOUCHERNO
        '
        Me.TXTVOUCHERNO.BackColor = System.Drawing.Color.Wheat
        Me.TXTVOUCHERNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTVOUCHERNO.Location = New System.Drawing.Point(120, 16)
        Me.TXTVOUCHERNO.MaxLength = 25
        Me.TXTVOUCHERNO.Name = "TXTVOUCHERNO"
        Me.TXTVOUCHERNO.Size = New System.Drawing.Size(32, 26)
        Me.TXTVOUCHERNO.TabIndex = 13
        '
        'CMB_BRITH
        '
        Me.CMB_BRITH.Enabled = False
        Me.CMB_BRITH.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_BRITH.Location = New System.Drawing.Point(176, 16)
        Me.CMB_BRITH.Name = "CMB_BRITH"
        Me.CMB_BRITH.Size = New System.Drawing.Size(32, 24)
        Me.CMB_BRITH.TabIndex = 605
        Me.CMB_BRITH.Visible = False
        '
        'GRPRECEIPT
        '
        Me.GRPRECEIPT.BackColor = System.Drawing.Color.Transparent
        Me.GRPRECEIPT.Controls.Add(Me.Label28)
        Me.GRPRECEIPT.Controls.Add(Me.ssgrid_Receipt)
        Me.GRPRECEIPT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GRPRECEIPT.ForeColor = System.Drawing.Color.Black
        Me.GRPRECEIPT.Location = New System.Drawing.Point(179, 405)
        Me.GRPRECEIPT.Name = "GRPRECEIPT"
        Me.GRPRECEIPT.Size = New System.Drawing.Size(659, 194)
        Me.GRPRECEIPT.TabIndex = 843
        Me.GRPRECEIPT.TabStop = False
        Me.GRPRECEIPT.Text = "Receipt Screen"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label28.Location = New System.Drawing.Point(0, -24)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(109, 18)
        Me.Label28.TabIndex = 392
        Me.Label28.Text = "HALL FACILITY"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ssgrid_Receipt
        '
        Me.ssgrid_Receipt.DataSource = Nothing
        Me.ssgrid_Receipt.Location = New System.Drawing.Point(8, 16)
        Me.ssgrid_Receipt.Name = "ssgrid_Receipt"
        Me.ssgrid_Receipt.OcxState = CType(resources.GetObject("ssgrid_Receipt.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid_Receipt.Size = New System.Drawing.Size(642, 169)
        Me.ssgrid_Receipt.TabIndex = 393
        '
        'cmd_Status
        '
        Me.cmd_Status.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_Status.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Status.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Status.ForeColor = System.Drawing.Color.White
        Me.cmd_Status.Image = CType(resources.GetObject("cmd_Status.Image"), System.Drawing.Image)
        Me.cmd_Status.Location = New System.Drawing.Point(0, 616)
        Me.cmd_Status.Name = "cmd_Status"
        Me.cmd_Status.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Status.TabIndex = 844
        Me.cmd_Status.Text = "Status [F8]"
        Me.cmd_Status.UseVisualStyleBackColor = False
        Me.cmd_Status.Visible = False
        '
        'Pic_Sign
        '
        Me.Pic_Sign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_Sign.Location = New System.Drawing.Point(944, 120)
        Me.Pic_Sign.Name = "Pic_Sign"
        Me.Pic_Sign.Size = New System.Drawing.Size(48, 32)
        Me.Pic_Sign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Sign.TabIndex = 846
        Me.Pic_Sign.TabStop = False
        Me.Pic_Sign.Visible = False
        '
        'Pic_Member
        '
        Me.Pic_Member.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_Member.Location = New System.Drawing.Point(944, 32)
        Me.Pic_Member.Name = "Pic_Member"
        Me.Pic_Member.Size = New System.Drawing.Size(48, 88)
        Me.Pic_Member.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Member.TabIndex = 845
        Me.Pic_Member.TabStop = False
        Me.Pic_Member.Visible = False
        '
        'Pic_spousesign
        '
        Me.Pic_spousesign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_spousesign.Location = New System.Drawing.Point(944, 248)
        Me.Pic_spousesign.Name = "Pic_spousesign"
        Me.Pic_spousesign.Size = New System.Drawing.Size(48, 32)
        Me.Pic_spousesign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_spousesign.TabIndex = 848
        Me.Pic_spousesign.TabStop = False
        Me.Pic_spousesign.Visible = False
        '
        'Pic_Spouse
        '
        Me.Pic_Spouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pic_Spouse.Location = New System.Drawing.Point(944, 160)
        Me.Pic_Spouse.Name = "Pic_Spouse"
        Me.Pic_Spouse.Size = New System.Drawing.Size(48, 88)
        Me.Pic_Spouse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Spouse.TabIndex = 847
        Me.Pic_Spouse.TabStop = False
        Me.Pic_Spouse.Visible = False
        '
        'CMB_LOCATION
        '
        Me.CMB_LOCATION.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_LOCATION.Location = New System.Drawing.Point(343, 43)
        Me.CMB_LOCATION.Name = "CMB_LOCATION"
        Me.CMB_LOCATION.Size = New System.Drawing.Size(256, 25)
        Me.CMB_LOCATION.TabIndex = 849
        Me.CMB_LOCATION.Visible = False
        '
        'lbl_reson
        '
        Me.lbl_reson.AutoSize = True
        Me.lbl_reson.BackColor = System.Drawing.Color.Transparent
        Me.lbl_reson.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_reson.Location = New System.Drawing.Point(185, 623)
        Me.lbl_reson.Name = "lbl_reson"
        Me.lbl_reson.Size = New System.Drawing.Size(57, 15)
        Me.lbl_reson.TabIndex = 850
        Me.lbl_reson.Text = "REASON"
        '
        'txt_res
        '
        Me.txt_res.BackColor = System.Drawing.Color.Wheat
        Me.txt_res.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_res.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_res.Location = New System.Drawing.Point(265, 616)
        Me.txt_res.MaxLength = 50
        Me.txt_res.Multiline = True
        Me.txt_res.Name = "txt_res"
        Me.txt_res.Size = New System.Drawing.Size(236, 42)
        Me.txt_res.TabIndex = 851
        '
        'TXT_TOTAMT
        '
        Me.TXT_TOTAMT.BackColor = System.Drawing.Color.Wheat
        Me.TXT_TOTAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_TOTAMT.Location = New System.Drawing.Point(669, 605)
        Me.TXT_TOTAMT.MaxLength = 5
        Me.TXT_TOTAMT.Name = "TXT_TOTAMT"
        Me.TXT_TOTAMT.ReadOnly = True
        Me.TXT_TOTAMT.Size = New System.Drawing.Size(171, 21)
        Me.TXT_TOTAMT.TabIndex = 852
        Me.TXT_TOTAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(533, 613)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 15)
        Me.Label19.TabIndex = 853
        Me.Label19.Text = "AMOUNT       "
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(533, 633)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(130, 15)
        Me.Label21.TabIndex = 854
        Me.Label21.Text = "DISCOUNT(%) /Others"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(533, 656)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(102, 15)
        Me.Label22.TabIndex = 855
        Me.Label22.Text = "TOTAL AMOUNT "
        '
        'TXT_DISAMT
        '
        Me.TXT_DISAMT.BackColor = System.Drawing.Color.Wheat
        Me.TXT_DISAMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DISAMT.Location = New System.Drawing.Point(669, 630)
        Me.TXT_DISAMT.MaxLength = 5
        Me.TXT_DISAMT.Name = "TXT_DISAMT"
        Me.TXT_DISAMT.Size = New System.Drawing.Size(46, 21)
        Me.TXT_DISAMT.TabIndex = 856
        Me.TXT_DISAMT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXTB_BAMOUNT
        '
        Me.TXTB_BAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTB_BAMOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTB_BAMOUNT.Location = New System.Drawing.Point(669, 655)
        Me.TXTB_BAMOUNT.MaxLength = 5
        Me.TXTB_BAMOUNT.Name = "TXTB_BAMOUNT"
        Me.TXTB_BAMOUNT.ReadOnly = True
        Me.TXTB_BAMOUNT.Size = New System.Drawing.Size(168, 21)
        Me.TXTB_BAMOUNT.TabIndex = 857
        Me.TXTB_BAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TXT_DISCOUNT
        '
        Me.TXT_DISCOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXT_DISCOUNT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_DISCOUNT.Location = New System.Drawing.Point(719, 630)
        Me.TXT_DISCOUNT.MaxLength = 5
        Me.TXT_DISCOUNT.Name = "TXT_DISCOUNT"
        Me.TXT_DISCOUNT.ReadOnly = True
        Me.TXT_DISCOUNT.Size = New System.Drawing.Size(59, 21)
        Me.TXT_DISCOUNT.TabIndex = 858
        Me.TXT_DISCOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Btn_Hallres
        '
        Me.Btn_Hallres.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Hallres.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Hallres.Location = New System.Drawing.Point(263, 358)
        Me.Btn_Hallres.Name = "Btn_Hallres"
        Me.Btn_Hallres.Size = New System.Drawing.Size(121, 35)
        Me.Btn_Hallres.TabIndex = 859
        Me.Btn_Hallres.Text = "HALL RESERVATION"
        Me.Btn_Hallres.UseVisualStyleBackColor = False
        '
        'Btn_Hallava
        '
        Me.Btn_Hallava.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Hallava.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Hallava.Location = New System.Drawing.Point(387, 358)
        Me.Btn_Hallava.Name = "Btn_Hallava"
        Me.Btn_Hallava.Size = New System.Drawing.Size(121, 34)
        Me.Btn_Hallava.TabIndex = 860
        Me.Btn_Hallava.Text = "HALL AVAILABLITY"
        Me.Btn_Hallava.UseVisualStyleBackColor = False
        '
        'Btn_recdet
        '
        Me.Btn_recdet.BackColor = System.Drawing.Color.Transparent
        Me.Btn_recdet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_recdet.Location = New System.Drawing.Point(510, 357)
        Me.Btn_recdet.Name = "Btn_recdet"
        Me.Btn_recdet.Size = New System.Drawing.Size(121, 35)
        Me.Btn_recdet.TabIndex = 861
        Me.Btn_recdet.Text = "RECEIPT DETAILS"
        Me.Btn_recdet.UseVisualStyleBackColor = False
        '
        'cmdreport
        '
        Me.cmdreport.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(858, 411)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(138, 65)
        Me.cmdreport.TabIndex = 869
        Me.cmdreport.Text = "CANCEL"
        Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdreport.UseVisualStyleBackColor = False
        Me.cmdreport.Visible = False
        '
        'cmd_exit
        '
        Me.cmd_exit.BackColor = System.Drawing.Color.Gainsboro
        Me.cmd_exit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_exit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_exit.Image = CType(resources.GetObject("cmd_exit.Image"), System.Drawing.Image)
        Me.cmd_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_exit.Location = New System.Drawing.Point(857, 412)
        Me.cmd_exit.Name = "cmd_exit"
        Me.cmd_exit.Size = New System.Drawing.Size(138, 65)
        Me.cmd_exit.TabIndex = 868
        Me.cmd_exit.Text = "Exit [F11]"
        Me.cmd_exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_exit.UseVisualStyleBackColor = False
        '
        'Cmdauth
        '
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(4, 463)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(144, 65)
        Me.Cmdauth.TabIndex = 867
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.UseVisualStyleBackColor = True
        Me.Cmdauth.Visible = False
        '
        'Cmd_view
        '
        Me.Cmd_view.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_view.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_view.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_view.Image = CType(resources.GetObject("Cmd_view.Image"), System.Drawing.Image)
        Me.Cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_view.Location = New System.Drawing.Point(858, 342)
        Me.Cmd_view.Name = "Cmd_view"
        Me.Cmd_view.Size = New System.Drawing.Size(138, 65)
        Me.Cmd_view.TabIndex = 865
        Me.Cmd_view.Text = "Report [F9]"
        Me.Cmd_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_view.UseVisualStyleBackColor = False
        '
        'cmd_freeze
        '
        Me.cmd_freeze.BackColor = System.Drawing.Color.Gainsboro
        Me.cmd_freeze.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_freeze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmd_freeze.Image = CType(resources.GetObject("cmd_freeze.Image"), System.Drawing.Image)
        Me.cmd_freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_freeze.Location = New System.Drawing.Point(858, 274)
        Me.cmd_freeze.Name = "cmd_freeze"
        Me.cmd_freeze.Size = New System.Drawing.Size(138, 65)
        Me.cmd_freeze.TabIndex = 864
        Me.cmd_freeze.Text = "Freeze [F8]"
        Me.cmd_freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_freeze.UseVisualStyleBackColor = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(858, 134)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(138, 65)
        Me.Cmd_Clear.TabIndex = 863
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
        Me.Cmd_Add.Location = New System.Drawing.Point(858, 206)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(138, 65)
        Me.Cmd_Add.TabIndex = 862
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'btn_rent
        '
        Me.btn_rent.BackColor = System.Drawing.Color.Transparent
        Me.btn_rent.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_rent.Location = New System.Drawing.Point(632, 357)
        Me.btn_rent.Name = "btn_rent"
        Me.btn_rent.Size = New System.Drawing.Size(121, 35)
        Me.btn_rent.TabIndex = 870
        Me.btn_rent.Text = "RENT UPDATE"
        Me.btn_rent.UseVisualStyleBackColor = False
        '
        'Txt_Others
        '
        Me.Txt_Others.BackColor = System.Drawing.Color.Wheat
        Me.Txt_Others.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Others.Location = New System.Drawing.Point(781, 630)
        Me.Txt_Others.MaxLength = 5
        Me.Txt_Others.Name = "Txt_Others"
        Me.Txt_Others.ReadOnly = True
        Me.Txt_Others.Size = New System.Drawing.Size(58, 21)
        Me.Txt_Others.TabIndex = 871
        Me.Txt_Others.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Hallstatus
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 17)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1014, 726)
        Me.Controls.Add(Me.Txt_Others)
        Me.Controls.Add(Me.GBHALLSTATUS)
        Me.Controls.Add(Me.GRPRECEIPT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Btn_Hallres)
        Me.Controls.Add(Me.RBASSOCIATEMEMBER)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.RBCLUBMEMBER)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.btn_rent)
        Me.Controls.Add(Me.cmd_exit)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Cmd_view)
        Me.Controls.Add(Me.cmd_freeze)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Btn_recdet)
        Me.Controls.Add(Me.txthallcode)
        Me.Controls.Add(Me.cmd_hallcodehelp)
        Me.Controls.Add(Me.Btn_Hallava)
        Me.Controls.Add(Me.TXT_DISCOUNT)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.TXTB_BAMOUNT)
        Me.Controls.Add(Me.TXT_DISAMT)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TXT_TOTAMT)
        Me.Controls.Add(Me.grchoice)
        Me.Controls.Add(Me.txt_res)
        Me.Controls.Add(Me.lbl_reson)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.halldescription)
        Me.Controls.Add(Me.CMB_LOCATION)
        Me.Controls.Add(Me.Pic_spousesign)
        Me.Controls.Add(Me.Pic_Spouse)
        Me.Controls.Add(Me.Pic_Sign)
        Me.Controls.Add(Me.Pic_Member)
        Me.Controls.Add(Me.cmd_Status)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Cmd_Freeze2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmd_advance)
        Me.Controls.Add(Me.GBHALLBOOKING)
        Me.Controls.Add(Me.cmdreport)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "Hallstatus"
        Me.Text = "HALL RESERVATION CUM RECEIPT"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grchoice.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBHALLBOOKING.ResumeLayout(False)
        CType(Me.SSGRID_BOOKING, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBHALLSTATUS.ResumeLayout(False)
        CType(Me.SSgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GRPRECEIPT.ResumeLayout(False)
        Me.GRPRECEIPT.PerformLayout()
        CType(Me.ssgrid_Receipt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Sign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Member, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_spousesign, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Pic_Spouse, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub hallstatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        Me.resizeFormResolution()
        rs.ResizeAllControls(Me)
        Try
            ' Call Resize_Form()
            Cmd_Clear_Click(sender, e)
            Call locationfill()
            SSGRID_BOOKING.Focus()
            SSGRID_BOOKING.SetActiveCell(1, 1)
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
            If Mid(gCompName, 1, 5) = "TRADE" Then
                Cmb_GuestType.SelectedItem = "OTHERS"
                Label1.Text = "EVENT DATE"
                Cmb_GuestType.Enabled = False
                Label9.Visible = False
                txtmcode.Visible = False
                cmd_mcodehelp.Visible = False
                Label6.Visible = False
                txtmname.Visible = False
                Label23.Visible = False
                TxtNVOCCUPANCY.Visible = False
                Label14.Visible = False
                TxtVOCCUPANCY.Visible = False
                'For i = 1 To 50
                '    With SSGRID_BOOKING
                '        .Row = i
                '        .Col = 5
                '        .Lock = False
                '        .Col = 6
                '        .Lock = False
                '        .Col = 7
                '        .Lock = False
                '    End With
                'Next
                SSGRID_BOOKING.Col = 13
                SSGRID_BOOKING.Row = 0
                SSGRID_BOOKING.Text = "Event ToDate"
            Else
                Cmb_GuestType.Enabled = True
                Label9.Visible = True
                txtmcode.Visible = True
                cmd_mcodehelp.Visible = True
                Label6.Visible = True
                txtmname.Visible = True
                Label23.Visible = True
                TxtNVOCCUPANCY.Visible = True
                Label14.Visible = True
                TxtVOCCUPANCY.Visible = True
                'For i = 1 To 50
                '    With SSGRID_BOOKING
                '        .Row = i
                '        .Col = 5
                '        .Lock = False
                '        .Col = 6
                '        .Lock = False
                '        .Col = 7
                '        .Lock = False
                '    End With
                'Next
            End If

            For i = 1 To 100
                With SSGRID_BOOKING
                    .Col = 8
                    .Row = i
                    .Lock = False
                End With
            Next

            Dtppartydate.Value = Format("dd/MM/yyyy", Now())
            DTPBOOKINGDATE.Value = Format("dd/MM/yyyy", Now())
            Cmb_StatusType.Text = "PROVISIONAL"
            TXTBOOKINGNO.Select()
            'txt_res.Visible = False
            'lbl_reson.Visible = False

        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        ' Call locationfill()
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


    Private Function locationfill()
        Try
            Dim I As Integer
            CMB_LOCATION.Items.Clear()
            sqlstring = "SELECT DISTINCT LOCCODE FROM PARTY_LOCATIONMASTER WHERE ISNULL(LOCCODE,'')<>''"
            gconnection.getDataSet(sqlstring, "PARTY_LOCATIONMASTER")
            If gdataset.Tables("PARTY_LOCATIONMASTER").Rows.Count > 0 Then
                For I = 0 To gdataset.Tables("PARTY_LOCATIONMASTER").Rows.Count - 1
                    CMB_LOCATION.Items.Add(gdataset.Tables("PARTY_LOCATIONMASTER").Rows(I).Item("loccode"))
                Next
                CMB_LOCATION.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CATEGORYFILL " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function




    Private Sub CANCELWINDOWS()
        Dim i, j, K, cnt, cnt1 As Integer
        Dim hallamt, rcamt As Double
        Dim Viewer As New ReportViwer
        Dim r1 As New CANreceipt1
        Dim dt As New DataTable
        Dim BOOKNO As Integer
        sqlstring = "SELECT * FROM partyCANCEL_view Where bookingno=" & TXTBOOKINGNO.Text & ""
        gconnection.getDataSet(sqlstring, "partyCANCEL_view")
        Call Viewer.GetDetails(sqlstring, "partyCANCEL_view", r1)
        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text9")
        TXTOBJ5.Text = MyCompanyName
        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text12")
        TXTOBJ6.Text = Address1 & Address2
        'Dim TXTOBJ7 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ7 = r1.ReportDefinition.ReportObjects("Text13")
        'TXTOBJ7.Text = Address2
        'Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ8 = r1.ReportDefinition.ReportObjects("Text13")
        TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text14")
        TXTOBJ9.Text = gphoneno

        'Dim TXTOBJ10 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ10 = r1.ReportDefinition.ReportObjects("Text16")
        'TXTOBJ10.Text = gphoneno
        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text26")
        TXTOBJ1.Text = "UserName : " & gUsername
        Viewer.Show()

    End Sub
    Private Sub PRINTWINDOWS()
        Dim i, j, K, cnt, cnt1 As Integer
        Dim sql1 As String
        Dim hallamt, rcamt As Double
        Dim Viewer As New ReportViwer
        If Mid(gCompName, 1, 5) = "TRADE" Then
            Dim r1 As New partreceipt1
            Dim dt As New DataTable
            Dim BOOKNO As Integer
            sqlstring = "SELECT * FROM partyreceipt_view Where bookingno=" & TXTBOOKINGNO.Text & ""
            gconnection.getDataSet(sqlstring, "partyreceipt_view")
            sql1 = "SELECT bookingno AS TARIFFCODE,TAXDESC AS TARIFFDESC ,HALLTAXPERC AS CCODE, TAXAMOUNT AS RATE FROM TAX_DETAILS_BOOKING Where bookingno=" & TXTBOOKINGNO.Text & ""
            If gdataset.Tables("partyreceipt_view").Rows.Count > 0 Then
                Viewer.Report = r1
                Call Viewer.GetDetails1(sql1, "VIEW_PARTY_TARIFFHISTORY", r1)
                Call Viewer.GetDetails1(sqlstring, "partyreceipt_view", r1)


                Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject

                TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text9")
                TXTOBJ5.Text = MyCompanyName
                Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text12")
                TXTOBJ6.Text = Address1 & Address2

                Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ8 = r1.ReportDefinition.ReportObjects("Text13")
                TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

                Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text22")
                TXTOBJ9.Text = "PhoneNo : " & gphoneno

                Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text26")
                TXTOBJ1.Text = "UserName : " & gUsername
                Viewer.Show()
            Else
                MsgBox("NO RECORDS FOUND TO DISPLAY  ", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        Else
            Dim r1 As New partreceipt
            Dim dt As New DataTable
            Dim BOOKNO As Integer
            sqlstring = "SELECT * FROM partyreceipt_view Where bookingno=" & TXTBOOKINGNO.Text & ""
            gconnection.getDataSet(sqlstring, "partyreceipt_view")
            sql1 = "SELECT bookingno AS TARIFFCODE,TAXDESC AS TARIFFDESC ,HALLTAXPERC AS CCODE, TAXAMOUNT AS RATE FROM TAX_DETAILS_BOOKING Where bookingno=" & TXTBOOKINGNO.Text & ""
            If gdataset.Tables("partyreceipt_view").Rows.Count > 0 Then
                Viewer.Report = r1
                Call Viewer.GetDetails1(sql1, "VIEW_PARTY_TARIFFHISTORY", r1)
                Call Viewer.GetDetails1(sqlstring, "partyreceipt_view", r1)


                Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject

                TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text9")
                TXTOBJ5.Text = MyCompanyName
                Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text12")
                TXTOBJ6.Text = Address1 & Address2

                Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ8 = r1.ReportDefinition.ReportObjects("Text13")
                TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

                Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text22")
                TXTOBJ9.Text = "PhoneNo : " & gphoneno

                Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text26")
                TXTOBJ1.Text = "UserName : " & gUsername
                Viewer.Show()
            Else
                MsgBox("NO RECORDS FOUND TO DISPLAY  ", MsgBoxStyle.OkOnly)
                Exit Sub
            End If
        End If
        

    End Sub
    Private Sub hallbilling()
        Try
            Dim i, j, K, cnt, cnt1 As Integer
            Dim hallamt, rcamt As Double
            Dim dt As New DataTable
            Dim BOOKNO As Integer
            sqlstring = "SELECT * FROM PARTY_VIEW_HALLBOOKINGDETAILS Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            'sqlstring = "SELECT * FROM PARTY_VIEW_HALLMASTER_DISPLAY Where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"

            gconnection.getDataSet(sqlstring, "HallStatus")

            vOutfile = Mid("out" & (Rnd() * 600000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                cnt = 1 : cnt1 = 1
                Filewrite.WriteLine(Chr(15) & Chr(27) + "E" & gCompanyAddress(0) & Chr(27) + "F")
                Filewrite.WriteLine(Chr(27) + "E" & "HALL RESERVATION" & Chr(27) + "F")
                Filewrite.WriteLine()
                Filewrite.WriteLine()
                'For K = 0 To gdataset.Tables("Hallstatus").Rows.Count - 1
                If BOOKNO <> gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGNO") Then
                    Filewrite.Write("BOOKING NO : " & Space(5 - Len(Mid(gdataset.Tables("HALLSTATUS").Rows(K).Item("BOOKINGNO"), 1, 5))) & Mid(gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGNO"), 1, 5) & Space(10))
                    Filewrite.WriteLine("BOOKING DATE : " & Mid(Format(gdataset.Tables("HALLSTATUS").Rows(K).Item("BOOKINGDATE"), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("BookingDate"), "dd/MMM/yyyy"), 1, 11))))

                    Filewrite.Write("PARTY DATE : " & Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("PARTYDATE"), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(gdataset.Tables("HallStatus").Rows(K).Item("PARTYDate"), "dd/MMM/yyyy"), 1, 11))))
                    If gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGFLAG") = "Y" Then
                        Filewrite.WriteLine(Space(4) & "STATUS : " & Mid("HALL BOOKED", 1, 15) & Space(15 - Len(Mid("HALL BOOKED", 1, 15))))
                    Else
                        Filewrite.WriteLine(Space(21))
                    End If
                    Filewrite.Write("MEMBER CODE :" & Mid(gdataset.Tables("HallStatus").Rows(K).Item("Mcode"), 1, 8) & Space(8 - Len(Mid(gdataset.Tables("HallStatus").Rows(K).Item("Mcode"), 1, 8))))
                    Filewrite.WriteLine(Space(7) & "MEMBER NAME :" & Mid(gdataset.Tables("HallStatus").Rows(K).Item("MNAME"), 1, 25) & Space(25 - Len(Mid(gdataset.Tables("HallStatus").Rows(K).Item("MNAME"), 1, 25))))

                    BOOKNO = gdataset.Tables("Hallstatus").Rows(K).Item("BOOKINGNO")
                End If
                'Next
                Filewrite.WriteLine()
                Filewrite.WriteLine("HALL DETAILS")
                Filewrite.WriteLine(StrDup(85, "-"))
                Filewrite.WriteLine("Sno Hall Details                    Party Type                 Time        Amount ")
                Filewrite.WriteLine("                                                            From   To       (Rs.)")
                Filewrite.WriteLine(StrDup(85, "-"))
                'VIJAY
                'For i = 0 To gdataset.Tables("Hallstatus").Rows.Count - 1
                ssql = Space(3 - Len(Mid(Val(cnt), 1, 3))) & Mid(Val(cnt), 1, 3)
                ssql = ssql & Space(1) & Mid(gdataset.Tables("HallStatus").Rows(i).Item("Hallcode"), 1, 8) & Space(8 - Len(Mid(gdataset.Tables("HallStatus").Rows(i).Item("Hallcode"), 1, 8)))
                ssql = ssql & Space(1) & Mid(gdataset.Tables("HallStatus").Rows(i).Item("HallDesc"), 1, 25) & Space(25 - Len(Mid(gdataset.Tables("HallStatus").Rows(i).Item("HallDesc"), 1, 25)))
                ssql = ssql & Space(1) & Mid(gdataset.Tables("HallStatus").Rows(i).Item("PDesc"), 1, 20) & Space(20 - Len(Mid(gdataset.Tables("HallStatus").Rows(i).Item("PDesc"), 1, 20)))
                ssql = ssql & Space(1) & Mid(gdataset.Tables("HallStatus").Rows(i).Item("fromtime"), 1, 5) & Space(5 - Len(Mid(gdataset.Tables("HallStatus").Rows(i).Item("fromtime"), 1, 5)))
                ssql = ssql & Space(1) & Mid(gdataset.Tables("HallStatus").Rows(i).Item("totime"), 1, 5) & Space(5 - Len(Mid(gdataset.Tables("HallStatus").Rows(i).Item("totime"), 1, 5)))
                ssql = ssql & Space(1) & Space(10 - Len(Mid(gdataset.Tables("HallStatus").Rows(i).Item("Hallamount"), 1, 10))) & Mid(gdataset.Tables("HallStatus").Rows(i).Item("Hallamount"), 1, 10)
                Filewrite.WriteLine(ssql)
                cnt = cnt + 1
                hallamt = Val(hallamt) + gdataset.Tables("HallStatus").Rows(i).Item("Hallamount")
                'Next
                Filewrite.WriteLine(StrDup(85, "="))
                Filewrite.WriteLine(Space(60) & "Total Amount" & Space(10 - Len(Mid(Format(Val(hallamt), "0.00"), 1, 10))) & Mid(Format(Val(hallamt), "0.00"), 1, 10))
                Filewrite.WriteLine(StrDup(85, "="))
                Filewrite.WriteLine()
                If Trim(gdataset.Tables("HallStatus").Rows(j).Item("RECEIPTNO")) <> "" Then
                    Filewrite.WriteLine("RECEIPT DETAILS")
                    Filewrite.WriteLine(StrDup(58, "-"))
                    Filewrite.WriteLine("Sno Receipt No      ReceiptDate Type               Amount")
                    Filewrite.WriteLine(StrDup(58, "-"))
                    'For j = 0 To gdataset.Tables("Hallstatus").Rows.Count - 1
                    ssql = Space(3 - Len(Mid(Val(cnt1), 1, 3))) & Mid(Val(cnt1), 1, 3)
                    ssql = ssql & Space(1) & Mid(gdataset.Tables("HallStatus").Rows(j).Item("RECEIPTNO"), 1, 15) & Space(15 - Len(Mid(gdataset.Tables("HallStatus").Rows(j).Item("RECEIPTNO"), 1, 15)))
                    ssql = ssql & Space(1) & Mid(Format(gdataset.Tables("HallStatus").Rows(j).Item("RECEIPTDATE"), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(gdataset.Tables("HallStatus").Rows(j).Item("RECEIPTDATE"), "dd/MMM/yyyy"), 1, 11)))
                    ssql = ssql & Space(1) & Mid(gdataset.Tables("HallStatus").Rows(j).Item("AMOUNTTYPE"), 1, 15) & Space(15 - Len(Mid(gdataset.Tables("HallStatus").Rows(j).Item("AMOUNTTYPE"), 1, 15)))
                    ssql = ssql & Space(1) & Space(10 - Len(Mid(Format(gdataset.Tables("HallStatus").Rows(j).Item("Ramount"), "0.00"), 1, 10))) & Mid(Format(gdataset.Tables("HallStatus").Rows(j).Item("Ramount"), "0.00"), 1, 10)
                    Filewrite.WriteLine(ssql)
                    rcamt = Val(rcamt) + gdataset.Tables("HallStatus").Rows(j).Item("Ramount")
                    cnt1 = cnt1 + 1
                    'Next j
                    Filewrite.WriteLine(StrDup(58, "="))
                    Filewrite.WriteLine(Space(36) & "Total Amount" & Space(10 - Len(Mid(Format(Val(rcamt), "0.00"), 1, 10))) & Mid(Format(Val(rcamt), "0.00"), 1, 10))
                    Filewrite.WriteLine(StrDup(58, "="))
                End If
                Filewrite.WriteLine()
                Filewrite.WriteLine()
                Filewrite.WriteLine("UserName : " & Mid(gUsername, 1, 15) & Space(15 - Len(Mid(gUsername, 1, 15))) & Space(10) & "PRINTED ON : " & Format(DateTime.Now, "dd/MMM/yyyy"))
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub checkValidation()
        Dim Loc As String
        Try
            boolchk = False
            Dim D1, d2 As DateTime
            Dim FDAY, TDAY, DAYS, CNT, j, k As Integer
            Dim hlcode, pcode, hlcode1, pcode1, Shlcode As String
            D1 = Format(Dtppartydate.Value, "dd/MM/yyyy")
            d2 = Format(DTPBOOKINGDATE.Value, "dd/MM/yyyy")

            If Mid(Cmd_Add.Text, 1, 1) = "A" Then
                Call datevalidation()
            End If

            If DateDiff(DateInterval.Day, D1, d2) > 0 Then
                MessageBox.Show("Party Date cannot be Less than To BookingDate", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Dtppartydate.Focus()
                Exit Sub
            End If

            If DTPVOUCHERDATE.Visible = True Then
                D1 = Format(DTPVOUCHERDATE.Value, "dd/MM/yyyy")
                d2 = Format(DTPBOOKINGDATE.Value, "dd/MM/yyyy")
                If DateDiff(DateInterval.Day, D1, d2) > 0 Then
                    MessageBox.Show(" Receipt Date Cannot Be Less than To BookingDate", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    DTPVOUCHERDATE.Focus()
                    Exit Sub
                End If
            End If
            If Trim(TXT_CELLNO.Text) = "" Then
                MessageBox.Show("MOBILE NO CAN'T BE BLANK", MyCompanyName, MessageBoxButtons.OK)
                Exit Sub
            End If

            If Val(TXT_DISAMT.Text) > 100 Then
                MessageBox.Show("DISCOUNT % CANNOT BE GREATER THAN 100", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                TXT_DISAMT.Focus()
                Exit Sub
            End If
            If Val(TXT_DISAMT.Text) > 0 Then
                'Me.TXT_TOTAMT.Text = 0
                dbldicountAmount = Format((Val(TXT_TOTAMT.Text) * Val(TXT_DISAMT.Text)) / 100, "0.00")
                'SSGRID_BOOKING.GetText(7, i, Taxamt)
                If Me.TXT_TOTAMT.Text < Val(dbldicountAmount) Then
                    MessageBox.Show("DISCOUNT AMOUNT CANNOT BE GREATER THAN TOTAL AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    TXT_DISAMT.Text = ""
                    Exit Sub
                End If

                ' Me.TXTB_BAMOUNT.Text = Val(TXT_TOTAMT.Text) - Format(Val(dbldicountAmount), "0.00")
            End If

            ssql = "SELECT ISNULL(LOCCODE,'')AS LOCCODE FROM party_locationmaster"
            gconnection.getDataSet(ssql, "LOC")
            If gdataset.Tables("LOC").Rows.Count > 0 Then
                Loc = Trim(gdataset.Tables("LOC").Rows(0).Item("LOCCODE"))
            End If
            If Trim(Loc) = "KGA" Or Mid(gCompName, 1, 5) = "TRADE" Or Mid(gCompName, 1, 5) = "CIAL" Then
            Else
                If Val(TxtNVOCCUPANCY.Text) <= 0 Then
                    MessageBox.Show(" Veg Pax's can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TxtNVOCCUPANCY.Focus()
                    Exit Sub
                End If

                If Val(TxtVOCCUPANCY.Text) <= 0 Then
                    MessageBox.Show(" Non veg Pax's can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    TxtVOCCUPANCY.Focus()
                    Exit Sub
                End If

            End If

            If Trim(TxtDescription.Text) = "" Then
                MessageBox.Show("PURPOSE CANNOT BE BLANK", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            'If Trim(Halldescription.Text) = "" Then
            '    MessageBox.Show(" Hall Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Halldescription.Focus()
            '    Exit Sub
            'End If
            If Trim(txtmcode.Text) = "" And Trim(Cmb_GuestType.Text) = "MEMBER" Then
                MessageBox.Show(" Member Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtmcode.Focus()
                Exit Sub
            End If
            ''If RBASSOCIATEMEMBER.Checked = True Then
            ''    If Trim(TXTASSOCIATENAME.Text) = "" Then
            ''        MessageBox.Show(" Associatename  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ''        TXTASSOCIATENAME.Focus()
            ''        Exit Sub
            ''    End If
            ''End If
            With SSGRID_BOOKING
                If .DataRowCnt = 0 Then
                    MessageBox.Show("Hall Details Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                    SSgrid.SetActiveCell(1, 1)
                    SSgrid.Focus()
                    Exit Sub
                End If

            End With

            With SSGRID_BOOKING
                For CNT = 1 To .DataRowCnt
                    .Col = 1
                    .Row = CNT
                    hlcode = Trim(.Text)
                    If Trim(hlcode) = "" Then
                        MessageBox.Show("Hall Code  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        .SetActiveCell(1, CNT)
                        .Focus()
                        Exit Sub
                    End If
                    .Col = 3
                    .Row = CNT
                    pcode = Trim(.Text)
                    If Trim(pcode) = "" Then
                        MessageBox.Show("Purpose  can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        .SetActiveCell(3, CNT)
                        .Focus()
                        Exit Sub
                    End If
                    .Col = 18
                    .Row = CNT
                    Shlcode = Trim(.Text)

                    k = 0
                    For j = 1 To .DataRowCnt
                        .Col = 1
                        .Row = j
                        hlcode1 = Trim(.Text)
                        .Col = 3
                        .Row = j
                        pcode1 = Trim(.Text)
                        If hlcode = hlcode1 And pcode = pcode1 Then
                            k = k + 1
                        End If
                    Next j

                    sqlstring = "select * from VIEW_PARTY_BOOKINGDETAILS WHERE BOOKINGNO <> " & Val(TXTBOOKINGNO.Text) & " and "
                    'sqlstring = sqlstring & " Partydate='" & Format(Dtppartydate.Value, "dd/MMM/yyyy") & "' and hallcode='" & Trim(hlcode) & "' and "
                    If Shlcode <> "" Then
                        sqlstring = sqlstring & " '" & Format(Dtppartydate.Value, "dd/MMM/yyyy") & "' BETWEEN PARTYDATE and PARTYTODATE and (HALLCODE='" & hlcode & "' or HALLCODE='" & Shlcode & "' ) AND STYPE = 'CONFIRMED' and "
                    Else
                        sqlstring = sqlstring & " '" & Format(Dtppartydate.Value, "dd/MMM/yyyy") & "' BETWEEN PARTYDATE and PARTYTODATE and (HALLCODE='" & hlcode & "' or SUPERHALLCODE='" & hlcode & "' ) AND STYPE = 'CONFIRMED' and "
                    End If
                    'sqlstring = sqlstring & " '" & Format(Dtppartydate.Value, "dd/MMM/yyyy") & "' BETWEEN PARTYDATE and PARTYTODATE and (HALLCODE='" & hlcode & "' or HALLCODE='" & Shlcode & "' ) and "
                    sqlstring = sqlstring & " Halltype='" & Trim(pcode) & "' and loccode='" & Trim(CMB_LOCATION.Text) & "'"
                    gconnection.getDataSet(sqlstring, "val")
                    If gdataset.Tables("val").Rows.Count > 0 Then
                        sqlstring = "Already this HallCode & Purpose Combination Booked.." & Trim(gdataset.Tables("val").Rows(0).Item("MCODE")) & " " & Trim(gdataset.Tables("val").Rows(0).Item("MNAME")) & " " & Format(gdataset.Tables("val").Rows(0).Item("BOOKINGNO"), "0")
                        MessageBox.Show(sqlstring, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        .SetActiveCell(1, CNT)
                        .Focus()
                        Exit Sub
                    End If
                    If Val(k) > 1 Then
                        MessageBox.Show("Already this HallCode & Purpose Combination Exists..", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        .SetActiveCell(1, CNT)
                        .Focus()
                        Exit Sub
                    End If
                Next
            End With
            If Mid(gCompName, 1, 5) = "TRADE" Then
                If Trim(Txt_StateCode.Text) = "" Then
                    MessageBox.Show("ST Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Txt_StateCode.Focus()
                    Exit Sub
                End If
                If Trim(Txt_MemGstNo.Text) = "" Then
                    If MessageBox.Show("Mem GSTIN No is blank, Want to Contiue", MyCompanyName, MessageBoxButtons.YesNo) = Forms.DialogResult.No Then
                        Txt_MemGstNo.Focus()
                        Exit Sub
                    End If
                End If
            End If

            boolchk = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub GetRights()
        Try
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

            Me.Cmd_Add1.Enabled = False
            Me.cmd_freeze1.Enabled = False
            Cmd_View1.Enabled = False
            'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
            If Len(chstr) > 0 Then
                Dim Right() As Char
                Right = chstr.ToCharArray
                For x = 0 To Right.Length - 1
                    If Right(x) = "A" Then
                        Me.Cmd_Add1.Enabled = True
                        Me.cmd_freeze1.Enabled = True
                        Me.Cmd_View1.Enabled = True
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
                        Me.cmd_freeze1.Enabled = True
                    End If
                    If Right(x) = "V" Then
                        Me.Cmd_View1.Enabled = True
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub hallstatus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            Call cmd_freeze1_Click(cmd_freeze, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 Then
            Call Cmd_view_Click(Cmd_view, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmd_exit_Click(cmd_exit, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F12 Then
            Call CMDPRINT_Click(cmd_exit, e)
            Exit Sub
        End If

        'If e.KeyCode = Keys.F8 Then
        '    Call cmd_Status_Click(cmd_Exit, e)
        '    Exit Sub
        'End If
        If e.KeyCode = Keys.F2 Then
            TXTBOOKINGNO.Text = ""
            TXTBOOKINGNO.Focus()
            Exit Sub
        End If
        If e.KeyCode = Keys.F10 Or e.KeyCode = Keys.Escape Then
            Call cmd_advance_Click(cmd_advance, e)
            Exit Sub
        End If
    End Sub
    Private Sub cmd_hallcodehelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_hallcodehelp.Click
        Try
            Dim vform As New ListOperattion1
            gSQLString = "SELECT ISNULL(HALLTYPEDESC,'') AS HALLTYPEDESC,ISNULL(HALLTYPECODE,'') AS HALLTYPECODE FROM PARTY_HALLMASTER_HDR"
            If Trim(Search) = " " Then
                M_WhereCondition = " WHERE ISNULL(FREEZE,'')<>'Y' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            Else
                M_WhereCondition = " WHERE ISNULL(FREEZE,'')<>'Y' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            End If
            vform.Field = "HALLTYPEDESC,HALLTYPECODE"
            vform.vFormatstring = "             HALL DESCRIPTION             |       HALL CODE    "
            vform.vCaption = "HALL MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txthallcode.Text = Trim(vform.keyfield1 & "")
                halldescription.Text = Trim(vform.keyfield & "")
                Call txthallcode_Validated(txthallcode, e)
                Dtppartydate.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Private Sub txthallcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthallcode.Validated
    '    Dim Fre As String
    '    If Trim(txthallcode.Text) <> "" Then
    '        Dim ds As New DataSet
    '        sqlstring = "Select hallcode,halldescription,freeze from PARTY_HALLMASTER where hallcode='" & txthallcode.Text & "'"
    '        gconnection.getDataSet(sqlstring, "HallMaster")
    '        If gdataset.Tables("HallMaster").Rows.Count > 0 Then
    '            Halldescription.Clear()
    '            Halldescription.Text = gdataset.Tables("HallMaster").Rows(0).Item("HallDescription")
    '            If gdataset.Tables("HallMaster").Rows(0).Item("Freeze") = "Y" Then
    '                Me.lbl_Freeze.Visible = True
    '                Me.lbl_Freeze.Text = ""
    '                Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("hallMaster").Rows(0).Item("AddDateTime")), "dd-MMM-yyyy")
    '                Me.Cmd_Freeze.Text = "UnFreeze[F8]"
    '            Else
    '                Me.lbl_Freeze.Visible = False
    '                Me.lbl_Freeze.Text = "Record Freezed  On "
    '                Me.Cmd_Freeze.Text = "Freeze[F8]"
    '            End If
    '            Me.Cmd_Add.Text = "Update[F7]"
    '            If gUserCategory <> "S" Then
    '                Call GetRights()
    '            End If
    '            Me.txthallcode.ReadOnly = True
    '            Me.cmd_hallcodehelp.Enabled = False
    '            Me.Halldescription.ReadOnly = True
    '        Else
    '            Me.lbl_Freeze.Visible = False
    '            Me.lbl_Freeze.Text = "Record Freezed  On "
    '            Me.Cmd_Add.Text = "Add [F7]"
    '            txthallcode.ReadOnly = False
    '            Halldescription.ReadOnly = False
    '        End If
    '    Else
    '        txthallcode.Text = ""
    '        txthallcode.Focus()
    '    End If
    'End Sub

    Private Sub txthallcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthallcode.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                If Trim(txthallcode.Text) <> "" Then
                    Call txthallcode_Validated(txthallcode, e)
                Else
                    Call cmd_hallcodehelp_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub dtppartydate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dtppartydate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            ' txtmcode.Focus()
            TxtDescription.Focus()
        End If
    End Sub
    Private Sub Txttotime_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            txtmcode.Focus()
        End If
    End Sub

    Private Sub txtmcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmcode.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                ' If Asc(e.KeyChar) = 13 Then
                If Trim(txtmcode.Text) <> "" Then
                    Call txtmcode_Validated(txtmcode, e)
                Else
                    Call cmd_mcodehelp_Click(sender, e)
                End If
                'End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

        'TxtDescription.Focus()
    End Sub
    'Private Sub TxtDescription_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    '    If Asc(e.KeyChar) = 13 Then
    '        TXTGUESTNAME.Focus()
    '    End If
    'End Sub
    Private Sub TxtGUESTNAME_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            Cmd_Add.Focus()
        End If
    End Sub
    Private Sub txthallcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthallcode.LostFocus
        Try
            Dim dt As New DataTable
            If txthallcode.Text <> "" Then
                sqlstring = "Select halltypedesc from PARTY_VIEW_HALLMASTER where halltypecode='" & txthallcode.Text & "'"
                dt = gconnection.GetValues(sqlstring)
                If dt.Rows.Count > 0 Then
                    halldescription.Text = ""
                    halldescription.Text = dt.Rows(0).Item("HallTypeDesc")
                Else
                    MessageBox.Show("Hall Code Not Found,Please Check", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txthallcode.Text = ""
                    txthallcode.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
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
        'TxtDescription.Focus()
    End Sub
    Private Sub Halldescription_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles halldescription.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtmcode.Focus()
        End If
    End Sub
    Private Sub txtmname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmname.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TXTASSOCIATENAME.Focus()
        End If
    End Sub
    Private Sub txthallcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthallcode.Validated
        Dim CNT As Integer
        Try
            If Trim(txthallcode.Text) <> "" Then
                halldescription.ReadOnly = False
                halldescription.Enabled = True
                sqlstring = "Select * From PARTY_VIEW_HALLMASTER Where halltypecode='" & Trim(txthallcode.Text) & "' "
                gconnection.getDataSet(sqlstring, "HallMaster")
                If gdataset.Tables("HallMaster").Rows.Count > 0 Then
                    If Mid(Cmd_Add1.Text, 1, 1) = "U" Then
                        If MsgBox("WANT TO MODIFY PURPOSE...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Change Update") = MsgBoxResult.No Then
                            Dtppartydate.Focus()
                            Exit Sub
                        End If
                    End If
                    halldescription.Text = ""
                    halldescription.Text = Trim(gdataset.Tables("HallMaster").Rows(0).Item("HAlltypedesc"))
                    With SSGRID_BOOKING
                        For CNT = 0 To gdataset.Tables("HallMaster").Rows.Count - 1
                            .Col = 1
                            .Row = CNT + 1
                            .Text = gdataset.Tables("HallMaster").Rows(CNT).Item("FROMTIME")
                            .Col = 2
                            .Row = CNT + 1
                            .Text = gdataset.Tables("HallMaster").Rows(CNT).Item("TOTIME")
                            .Col = 3
                            .Row = CNT + 1
                            .Text = gdataset.Tables("HallMaster").Rows(CNT).Item("PCODE")
                            .Col = 4
                            .Row = CNT + 1
                            .Text = gdataset.Tables("HallMaster").Rows(CNT).Item("PDESC")
                            .Col = 5
                            .Row = CNT + 1
                            .Text = gdataset.Tables("HallMaster").Rows(CNT).Item("RATE")
                        Next
                    End With
                    halldescription.ReadOnly = True
                    ' '''' Dtppartydate.Focus()
                Else
                    txthallcode.Clear()
                    halldescription.Clear()
                    Dtppartydate.Focus()
                End If
            Else
                halldescription.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtmcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmcode.Validated
        Try
            If Trim(txtmcode.Text) <> "" Then
                txtmname.ReadOnly = False
                txtmname.Enabled = True
                If UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then
                    sqlstring = "Select isnull(mcode,'') as mcode,isnull(mname,'') as mname From MemberMaster Where Mcode='" & Trim(txtmcode.Text) & "' AND ISNULL(FREEZE,'')='' AND isnull(termination,'')<>'Y' "
                    gconnection.getDataSet(sqlstring, "MemberMaster")
                Else
                    sqlstring = "Select isnull(mcode,'') as mcode,isnull(mname,'') as mname,isnull(curentstatus,'') as termination,ISNULL(CONTADD1,'') AS CONTADD1,ISNULL(CONTADD2,'') AS CONTADD2,ISNULL(CONTCITY,'')+' '+ISNULL(CONTPIN,'') as city, ISNULL(CONTEMAIL,'') AS CONTEMAIL,ISNULL(CONTCELL,'') AS CONTCELL  From MemberMaster Where Mcode='" & Trim(txtmcode.Text) & "' AND  ISNULL(CURENTSTATUS,'') IN ('LIVE','ACTIVE') "
                    gconnection.getDataSet(sqlstring, "MemberMaster")
                End If
                If gdataset.Tables("MemberMaster").Rows.Count > 0 Then
                    txtmname.Text = ""
                    txtmname.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("Mname"))
                    TXTGUESTNAME.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("Mname"))
                    Txt_Add1.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("CONTADD1"))
                    Txt_Add2.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("CONTADD2"))
                    Txt_CityPin.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("city"))
                    TXT_EMAIL.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("CONTEMAIL"))
                    TXT_CELLNO.Text = Trim(gdataset.Tables("MemberMaster").Rows(0).Item("CONTCELL"))

                    txtmname.ReadOnly = True
                    '  TxtDescription.Focus()
                    'TxtVOCCUPANCY.Focus()
                    TXTGUESTNAME.Focus()
                Else
                    txtmcode.Clear()
                    txtmname.Clear()
                    txtmcode.Focus()
                End If
            Else
                'If MsgBox("MEMBERSHIP NO. FOUND...", MsgBoxStyle.OKCancel, "RSI") = MsgBoxResult.OK Then
                '    txtmname.Clear()
                '    txtmcode.Focus()
                'End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub cmd_advance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_advance.Click
        Dim objpartybill As New PartyBilling
        objpartybill.Show()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim vform As New ListOperattion1
        Try
            gSQLString = "Select VOUCHERNO,VOUCHERDATE FROM PARTY_RECEIPT "
            M_WhereCondition = " WHERE BILLTYPE='ADVANCE' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            vform.Field = "VOUCHERNO,VOUCHERDATE"
            vform.vFormatstring = " VOUCHERNO        | VOUCHERDATE                  "
            vform.vCaption = "Member Master Help"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXTVOUCHERNO.Text = Trim(vform.keyfield & "")
                TxtDescription.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        TXTVOUCHERNO.ReadOnly = True
    End Sub
    Private Sub DTPVOUCHERDATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            TXTVOUCHERNO.Focus()
        End If
    End Sub
    Public Function Btn_BIRTH1_FUN()
        If Btn_BIRTH1.Text = "C" Then
            CMB_BRITH.Visible = True
            DTPVOUCHERDATE.Value = "01-01-1900"
            DTPVOUCHERDATE.Visible = False
            Btn_BIRTH1.Text = "E"
        ElseIf Btn_BIRTH1.Text = "E" Then
            CMB_BRITH.Visible = False
            DTPVOUCHERDATE.Visible = True
            Btn_BIRTH1.Text = "C"
            DTPVOUCHERDATE.Value = Format(Now(), "dd/MM/yyyy")
        End If
    End Function
    Private Sub Halldescription_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles halldescription.KeyDown
        If e.KeyCode = Keys.F4 Then
            Button1_Click(sender, e)
        End If
    End Sub
    Private Sub TXTVOUCHERNO_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.F4 Then
            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub TXTBOOKINGNO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTBOOKINGNO.KeyDown

    End Sub
    Private Sub TXTBOOKINGNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBOOKINGNO.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            sqlstring = "select * from VIEW_PARTY_BOOKINGDETAILS WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            gconnection.getDataSet(sqlstring, "HallStatus")
            If gdataset.Tables("HallStatus").Rows.Count > 0 Then
                TXTBOOKINGNO_Validated(sender, e)
            Else
                DTPBOOKINGDATE.Focus()
            End If
            ''''' DTPBOOKINGDATE.Focus()
        End If
    End Sub
    Private Sub DTPBOOKINGDATE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DTPBOOKINGDATE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dtppartydate.Focus()
        End If
    End Sub
    Private Sub TXTBOOKINGNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBOOKINGNO.Validated
        Dim Fre As String
        Dim Others As Double
        Try
            If Trim(TXTBOOKINGNO.Text) <> "" Then
                Dim ds As New DataSet
                'sqlstring = "select bookingno,partydate,Hallcode,mcode,bookingdate,Advance,Membertype,"
                'sqlstring = sqlstring & " fromtime, totime, description, freeze,associatename,"
                'sqlstring = sqlstring & " receiptno,receiptdate,adduserid,adddatetime from VIEW_PARTY_BOOKINGDETAILS "
                sqlstring = "select isnull(freereson,'') as freereson,ISNULL(HALLNETAMOUNT,0) AS HALLNETAMOUNT,ISNULL(DISCOUNT,0) AS DISCOUNT,ISNULL(DISCOUNTAMT,0)AS DISCOUNTAMT,ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(CELLNO,0)AS CELLNO,ISNULL(EMAIL,'')AS EMAIL,ISNULL(H_Type,'') AS H_Type,ISNULL(Guest_Type,'') AS Guest_Type,ISNULL(Status_Type,'') AS Status_Type,ISNULL(Address1,'') Address1,ISNULL(Address2,'') AS Address2,ISNULL(CityPin,'') AS CityPin,Isnull(MEMGSTNO,'') as MEMGSTNO,Isnull(STCODE,'') as STCODE,Isnull(FTaxApply,'NO') as FTaxApply from party_hallbooking_hdr WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " "
                gconnection.getDataSet(sqlstring, "HallStatus123")
                If gdataset.Tables("HallStatus123").Rows.Count > 0 Then
                    Me.txt_res.Text = gdataset.Tables("HallStatus123").Rows(0).Item("freereson")
                    Me.TXT_TOTAMT.Text = gdataset.Tables("HallStatus123").Rows(0).Item("HALLNETAMOUNT")
                    Me.TXT_DISAMT.Text = gdataset.Tables("HallStatus123").Rows(0).Item("DISCOUNT")
                    Me.TXT_DISCOUNT.Text = gdataset.Tables("HallStatus123").Rows(0).Item("DISCOUNTAMT")
                    Me.TXTB_BAMOUNT.Text = gdataset.Tables("HallStatus123").Rows(0).Item("TOTALAMOUNT")
                    TXT_CELLNO.Text = gdataset.Tables("HallStatus123").Rows(0).Item("CELLNO")
                    TXT_EMAIL.Text = gdataset.Tables("HallStatus123").Rows(0).Item("EMAIL")
                    Cmb_DayBasis.Text = gdataset.Tables("HallStatus123").Rows(0).Item("H_Type")
                    Cmb_GuestType.Text = gdataset.Tables("HallStatus123").Rows(0).Item("Guest_Type")
                    Cmb_StatusType.Text = gdataset.Tables("HallStatus123").Rows(0).Item("Status_Type")
                    Txt_Add1.Text = gdataset.Tables("HallStatus123").Rows(0).Item("Address1")
                    Txt_Add2.Text = gdataset.Tables("HallStatus123").Rows(0).Item("Address2")
                    Txt_CityPin.Text = gdataset.Tables("HallStatus123").Rows(0).Item("CityPin")
                    Txt_MemGstNo.Text = gdataset.Tables("HallStatus123").Rows(0).Item("MEMGSTNO")
                    Txt_StateCode.Text = gdataset.Tables("HallStatus123").Rows(0).Item("STCODE")
                    If Trim(gdataset.Tables("HallStatus123").Rows(0).Item("FTaxApply")) = "YES" Then
                        Chk_FloodTax.Checked = True
                    Else
                        Chk_FloodTax.Checked = False
                    End If
                End If
                sqlstring = "select * from VIEW_PARTY_BOOKINGDETAILS WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                gconnection.getDataSet(sqlstring, "HallStatus")
                If gdataset.Tables("HallStatus").Rows.Count > 0 Then

                    CMB_LOCATION.Text = gdataset.Tables("HallStatus").Rows(0).Item("LOCcode")
                    txthallcode.Text = gdataset.Tables("HallStatus").Rows(0).Item("Hallcode")
                    halldescription.Text = gdataset.Tables("HallStatus").Rows(0).Item("Halldescription")
                    TxtDescription.Text = gdataset.Tables("HallStatus").Rows(0).Item("description")
                    TxtOCCUPANCY.Text = gdataset.Tables("HallStatus").Rows(0).Item("OCCUPANCY")

                    TxtVOCCUPANCY.Text = gdataset.Tables("HallStatus").Rows(0).Item("veg")
                    TxtNVOCCUPANCY.Text = gdataset.Tables("HallStatus").Rows(0).Item("nonveg")

                    DTPBOOKINGDATE.Value = Format(gdataset.Tables("HallStatus").Rows(0).Item("bookingdate"), "dd/MM/yyyy hh:mm:ss")
                    Dtppartydate.Value = Format(gdataset.Tables("HallStatus").Rows(0).Item("partydate"), "dd/MM/yyyy hh:mm:ss")
                    TXTRECAMOUNT.Text = gdataset.Tables("HallStatus").Rows(0).Item("Advance")
                    TXTVOUCHERNO.Text = gdataset.Tables("HallStatus").Rows(0).Item("receiptno")
                    DTPVOUCHERDATE.Value = Format(gdataset.Tables("HallStatus").Rows(0).Item("receiptdate"), "dd/MM/yyyy hh:mm:ss")
                    TxtDescription.Text = gdataset.Tables("HallStatus").Rows(0).Item("Description")
                    TXTGUESTNAME.Text = gdataset.Tables("HallStatus").Rows(0).Item("GUESTNAME")
                    txtmcode.Text = gdataset.Tables("HallStatus").Rows(0).Item("mcode")
                    txtmname.Text = gdataset.Tables("HallStatus").Rows(0).Item("mname")
                    txt_res.Text = gdataset.Tables("HallStatus").Rows(0).Item("FREERESON")
                    TXTASSOCIATENAME.Text = gdataset.Tables("HallStatus").Rows(0).Item("associatename")
                    If Trim(gdataset.Tables("HallStatus").Rows(0).Item("membertype")) = "C" Then
                        RBCLUBMEMBER.Checked = True
                    Else
                        RBASSOCIATEMEMBER.Checked = True
                    End If
                    If Format(gdataset.Tables("HallStatus").Rows(0).Item("receiptdate"), "dd/MM/yyyy") = "01/01/1900" Then
                        Btn_BIRTH1.Text = "C"
                        Btn_BIRTH1_FUN()
                    Else
                        Btn_BIRTH1.Text = "E"
                        DTPVOUCHERDATE.Visible = True
                        CMB_BRITH.Visible = False
                    End If
                    If gdataset.Tables("HallStatus").Rows(0).Item("FREEZE") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "THIS BOOKING IS FREEZED ON :" & Format(CDate(gdataset.Tables("HallStatus").Rows(0).Item("ADDDATETIME")), "dd-MMM-yyyy")

                        'Me.lbl_Freeze.Text = "THIS BOOKING IS CANCELLED ON :" & Format(CDate(gdataset.Tables("HallStatus").Rows(0).Item("ADDDATETIME")), "dd-MMM-yyyy")
                        Me.cmd_freeze1.Text = "UnFreeze[F8]"
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "THIS BOOKING IS CANCELLED ON :"
                        Me.cmd_freeze1.Text = "Freeze[F8]"
                    End If
                    Me.Cmd_Add.Text = "Update[F7]"
                    ' Call txtmcode_Validated(txtmcode, e)
                    Call txthallcode_Validated(txthallcode, e)

                    Call GridUnLock()
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    Me.TXTBOOKINGNO.ReadOnly = True
                    Me.cmd_helpbooingno1.Enabled = False
                    ''''' Me.DTPBOOKINGDATE.Focus()
                    Dim Deposit As Double
                    ssql = "SELECT ISNULL(SUM(ISNULL(AMOUNT,0)),0) AS SEDAMT FROM party_receipt_DET WHERE BOOKINGNO = " & Trim(TXTBOOKINGNO.Text) & " AND Receiptheaddesc LIKE '%SECURITY DEPOSIT%' AND ISNULL(RECEIPTTYPE,'') <> 'REFUND'"
                    gconnection.getDataSet(ssql, "SEDDEPO")
                    If gdataset.Tables("SEDDEPO").Rows.Count > 0 Then
                        Deposit = gdataset.Tables("SEDDEPO").Rows(0).Item(0)
                    Else
                        Deposit = 0
                    End If
                    Others = 0
                    'sqlstring = "select d.bookingno,d.hallcode,HM.HALLTYPEDESC,d.partydate,d.fromtime,d.totime,d.halltype,p.pdesc,d.hallamount,d.freeze,d.HALLTAXPERC,(isnull(d.HALLTAXAMOUNT,0)+isnull(d.sertax,0))as halltaxamount,d.HALLNETAMOUNT,ISNULL(D.SEDEPOSIT,0)AS SEDEPOSIT,ISNULL(D.TAXCODE,'')AS TAXCODE,ISNULL(D.H_Type,'') AS H_Type,ISNULL(D.PartyTodate,'') AS PartyTodate,ISNULL(D.HKStaff,0) AS HKStaff,ISNULL(D.SecurityStaff,0) AS SecurityStaff,ISNULL(HKStaffAmt,0) AS HKStaffAmt,ISNULL(SecurityStaffAmt,0) AS SecurityStaffAmt,ISNULL(SHallCode,'') AS SHallCode from  PARTY_HALLBOOKING_DET d LEFT OUTER join Party_Purposemaster p on p.pcode=d.halltype LEFT OUTER JOIN PARTY_HALLMASTER_HDR HM ON HM.HALLTYPECODE = D.HALLCODE where bookingno=" & TXTBOOKINGNO.Text & "  "
                    sqlstring = "select d.bookingno,d.hallcode,HM.HALLTYPEDESC,d.partydate,d.fromtime,d.totime,d.halltype,ISNULL(p.pdesc,'') AS pdesc,d.hallamount,d.freeze,d.HALLTAXPERC,(isnull(d.HALLTAXAMOUNT,0)+isnull(d.sertax,0))as halltaxamount,d.HALLNETAMOUNT," & Deposit & " as  SEDEPOSIT,ISNULL(D.TAXCODE,'')AS TAXCODE,ISNULL(D.H_Type,'') AS H_Type,ISNULL(D.PartyTodate,'') AS PartyTodate,ISNULL(D.HKStaff,0) AS HKStaff,ISNULL(D.SecurityStaff,0) AS SecurityStaff,ISNULL(HKStaffAmt,0) AS HKStaffAmt,ISNULL(SecurityStaffAmt,0) AS SecurityStaffAmt,ISNULL(SHallCode,'') AS SHallCode from  PARTY_HALLBOOKING_DET d LEFT OUTER join Party_Purposemaster p on p.pcode=d.halltype LEFT OUTER JOIN PARTY_HALLMASTER_HDR HM ON HM.HALLTYPECODE = D.HALLCODE where bookingno=" & TXTBOOKINGNO.Text & "  "
                    DT = gconnection.GetValues(sqlstring)
                    If DT.Rows.Count > 0 Then
                        SSGRID_BOOKING.ClearRange(-1, -1, 1, 1, True)
                        With SSGRID_BOOKING
                            For i = 0 To DT.Rows.Count - 1
                                .Col = 1
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("HALLCODE")

                                .Col = 2
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("HALLTYPEDESC")

                                .Col = 5
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("fromtime")

                                .Col = 6
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("totime")

                                .Col = 3
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("halltype")

                                .Col = 4
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("pdesc")

                                .Col = 7
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("hallamount")
                                .Col = 8
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("TAXCODE")
                                .Col = 9
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("HALLTAXAMOUNT")
                                .Col = 10
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("HALLNETAMOUNT")
                                .Col = 11
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("SEDEPOSIT")
                                .Col = 12
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("H_Type")
                                .Col = 13
                                .Row = i + 1
                                .Text = Format(DT.Rows(i).Item("PartyTodate"), "dd/MM/yy")
                                If DT.Rows(i).Item("H_Type") = "Day" Then
                                    .Lock = False
                                Else
                                    .Lock = True
                                End If
                                .Col = 14
                                .Row = i + 1
                                .Text = Val(DT.Rows(i).Item("HKStaff"))
                                .Col = 15
                                .Row = i + 1
                                .Text = Val(DT.Rows(i).Item("SecurityStaff"))
                                .Col = 16
                                .Row = i + 1
                                .Text = Val(DT.Rows(i).Item("HKStaffAmt"))
                                Others = Others + Val(DT.Rows(i).Item("HKStaffAmt"))
                                .Col = 17
                                .Row = i + 1
                                .Text = Val(DT.Rows(i).Item("SecurityStaffAmt"))
                                Others = Others + Val(DT.Rows(i).Item("SecurityStaffAmt"))
                                .Col = 18
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("SHallCode")
                            Next
                        End With
                    End If
                    Txt_Others.Text = Format(Others, "0.00")
                    sqlstring = "SELECT * from partyrec_advance WHERE bookno='" & Me.TXTBOOKINGNO.Text & "'"
                    DT = gconnection.GetValues(sqlstring)
                    If DT.Rows.Count > 0 Then
                        Cmb_StatusType.Text = "CONFIRMED"
                    Else
                        Cmb_StatusType.Text = "PROVISIONAL"
                    End If
                    sqlstring = "select isnull(receiptno,'') as receiptno,isnull(receiptdate,'') as receiptdate,"
                    sqlstring = sqlstring & " isnull(amount,0) as amount,isnull(AMOUNTTYPE,'') as amounttype from party_receipt "
                    sqlstring = sqlstring & " where bookingno=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    DT = gconnection.GetValues(sqlstring)
                    If DT.Rows.Count > 0 Then
                        ssgrid_Receipt.ClearRange(-1, -1, 1, 1, True)
                        With ssgrid_Receipt
                            For i = 0 To DT.Rows.Count - 1
                                .Col = 1
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("Receiptno")

                                .Col = 2
                                .Row = i + 1
                                .Text = Format(CDate(Trim(DT.Rows(i).Item("receiptdate"))), "dd/MM/yyyy hh:mm:ss")

                                ''SSgrid.SetText(5, i, DateValue(gdataset.Tables("TAXITEMLINK").Rows(j).Item("EndingDate")))
                                'If Format(DT.Rows(i).Item("receiptdate"), "dd-MM-yyyy") <> "01/01/1900" Then
                                '    .CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                                '    .SetText(2, i + 1, DateValue(DT.Rows(i).Item("receiptdate")))
                                '    .CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                                'Else
                                '    .Text = ""
                                'End If

                                .Col = 3
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("amount")

                                .Col = 4
                                .Row = i + 1
                                .Text = DT.Rows(i).Item("amounttype")
                            Next
                        End With
                    End If
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Add.Text = "Add [F7]"
                    TXTBOOKINGNO.ReadOnly = False
                    ' CMB_LOCATION.Focus()
                End If
            Else
                DTPBOOKINGDATE.Focus()
            End If
            TEMPBOOKINGDETAILS()

        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
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
    Private Sub HallBooking()
        Try
            'Dim dt As New DataTable
            ssql = "SELECT HALLCODE,HALLDESCRIPTION,MCODE,BOOKINGNO,HALLAMOUNT,BOOKINGDATE,"
            ssql = ssql & " FROMTIME,TOTIME,PARTYDATE,RECEIPTNO,RECEIPTDATE,ADDUSERID,ADDDATETIME,"
            ssql = ssql & " ADVANCE  FROM  VIEW_HALLBOOKING	"
            DT = gconnection.GetValues(ssql)
            If DT.Rows.Count > 0 Then
                vOutfile = Mid("out" & (Rnd() * 800000), 1, 8)
                VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
                Filewrite = File.AppendText(VFilePath)
                Filewrite.WriteLine(Chr(15) & Chr(27) + "E" & gCompanyAddress(0) & Chr(27) + "F")
                Filewrite.WriteLine(Chr(27) + "E" & Space(30) & "HALL STATUS" & Chr(27) + "F")
                Filewrite.WriteLine("|" & StrDup(78, "-") & "|")
                ssql = "| HALL CODE    :" & Mid(DT.Rows(0).Item("HALLCODE"), 1, 10)
                ssql = ssql & Space(10 - Len(Mid(DT.Rows(0).Item("HALLCODE"), 1, 10)))
                ssql = ssql & Space(7) & "HALL NAME :" & Mid(DT.Rows(0).Item("description"), 1, 30)
                ssql = ssql & Space(30 - Len(Mid(DT.Rows(0).Item("description"), 1, 30))) & Space(5) & "|"
                Filewrite.WriteLine(ssql)
                Filewrite.WriteLine("|" & StrDup(78, "-") & "|")
                Filewrite.WriteLine("| Description1 :" & Mid(DT.Rows(0).Item("description1"), 1, 50) & Space(50 - Len(Mid(DT.Rows(0).Item("description1"), 1, 50))) & Space(13) & "|")
                Filewrite.WriteLine("|" & Space(78) & "|")
                Filewrite.WriteLine("| Description2 :" & Mid(DT.Rows(0).Item("description2"), 1, 50) & Space(50 - Len(Mid(DT.Rows(0).Item("description2"), 1, 50))) & Space(13) & "|")
                Filewrite.WriteLine("|" & Space(78) & "|")
                Filewrite.WriteLine("| Description3 :" & Mid(DT.Rows(0).Item("description3"), 1, 50) & Space(50 - Len(Mid(DT.Rows(0).Item("description3"), 1, 50))) & Space(13) & "|")
                Filewrite.WriteLine("|" & Space(78) & "|")
                Filewrite.WriteLine("|" & "No Of Persion :" & Mid(Format(DT.Rows(0).Item("noofpersion"), "0"), 1, 10) & Space(10 - Len(Mid(Format(DT.Rows(0).Item("noofpersion"), "0"), 1, 10))) & Space(53) & "|")
                Filewrite.WriteLine("|" & Space(78) & "|")
                Filewrite.WriteLine("|" & "Hall Rent     :" & Mid(Format(DT.Rows(0).Item("hallamount"), "0.00"), 1, 10) & Space(10 - Len(Mid(Format(DT.Rows(0).Item("hallamount"), "0.00"), 1, 10))) & Space(53) & "|")
                Filewrite.WriteLine("|" & Space(78) & "|")
                Filewrite.Write("|" & "TAX %         :" & Mid(Format(DT.Rows(0).Item("taxperc"), "0.00"), 1, 5) & Space(5 - Len(Mid(Format(DT.Rows(0).Item("taxperc"), "0.00"), 1, 5))) & "      Tax Amount:" & Mid(Format(DT.Rows(0).Item("taxamount"), "0.00"), 1, 8) & Space(8 - Len(Mid(Format(DT.Rows(0).Item("taxamount"), "0.00"), 1, 8))))
                Filewrite.WriteLine("    Net Amount :" & Mid(Format(DT.Rows(0).Item("totalamount"), "0.00"), 1, 8) & Space(8 - Len(Mid(Format(DT.Rows(0).Item("totalamount"), "0.00"), 1, 8))) & Space(9) & "|")
                Filewrite.WriteLine("|" & Space(78) & "|")
                Filewrite.WriteLine("|" & Space(78) & "|")
                Filewrite.WriteLine("|" & StrDup(78, "-") & "|")
                Filewrite.WriteLine("|" & Space(78) & "|")
                Filewrite.WriteLine("|" & Space(78) & "|")
                Filewrite.WriteLine("|" & Space(35) & "HALL FACILITY" & Space(30) & "|")
                Filewrite.WriteLine("|" & Space(78) & "|")
                Filewrite.WriteLine("|" & Space(78) & "|")
                ssql = "SELECT * FROM VIEW_PARTY_HALLDETAILS  "
                DT = gconnection.GetValues(ssql)
                If DT.Rows.Count > 0 Then
                    Filewrite.WriteLine("| SNO        FACILITY                                             QTY          |")
                    Filewrite.WriteLine("|" & StrDup(78, "-") & "|")
                    Filewrite.WriteLine("|" & Space(78) & "|")
                    For j = 0 To DT.Rows.Count - 1
                        Filewrite.WriteLine("|  " & Mid((j + 1), 1, 3) & Space(3 - Len(Mid(j, 1, 3))) & Space(7) & "|" & Mid(DT.Rows(j).Item("ITEMDESCRIPTION"), 1, 40) & Space(40 - Len(Mid(DT.Rows(j).Item("ITEMDESCRIPTION"), 1, 40))) & Space(5) & Space(10 - Len(Mid(Format(DT.Rows(j).Item("ITEMDESCRIPTION"), "0"), 1, 10))) & Mid(Format(DT.Rows(j).Item("ITEMDESCRIPTION"), "0"), 1, 10) & Space(10) & "|")
                    Next
                    Filewrite.WriteLine("|" & Space(78) & "|")
                    Filewrite.WriteLine("|" & StrDup(78, "-") & "|")
                    Filewrite.WriteLine("|Note :" & Space(72) & "|")
                    Filewrite.WriteLine("|" & Space(78) & "|")
                    Filewrite.WriteLine("|" & Space(78) & "|")
                    Filewrite.WriteLine("|" & Space(78) & "|")
                    Filewrite.WriteLine("|" & Space(78) & "|")
                    Filewrite.WriteLine("|" & Space(78) & "|")
                    Filewrite.WriteLine("|" & Space(78) & "|")
                    Filewrite.WriteLine("|" & StrDup(78, "-") & "|")
                End If
                Filewrite.Close()
                If PRINTREP = False Then
                    OpenTextFile(vOutfile)
                Else
                    PrintTextFile(vOutfile)
                End If
            Else
                MessageBox.Show("NO RECORDS FOUND TO DISPLAY..")
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DTPVOUCHERDATE_KeyPress1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            TXTRECAMOUNT.Focus()
        End If
    End Sub
    Private Sub TXTRECAMOUNT_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            If GBHALLBOOKING.Visible = True Then
                SSGRID_BOOKING.Focus()
            Else
                SSgrid.Focus()
            End If
        End If
    End Sub
    Private Sub Btn_BIRTH1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Btn_BIRTH1_FUN()
    End Sub
    Private Sub TXTVOUCHERNO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            If CMB_BRITH.Visible = True Then
                Btn_BIRTH1.Focus()
            Else
                DTPVOUCHERDATE.Focus()
            End If
        End If
    End Sub
    'Private Sub SSGRID_BOOKING_KeyDownEvent(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent)
    '    Dim Itemcode As String
    '    Try
    '        If e.keyCode = Keys.Enter Then
    '            With SSGRID_BOOKING
    '                If .ActiveCol = 1 Then
    '                    If Trim(.Text) = "" Then
    '                        .SetActiveCell(1, .ActiveRow)
    '                    Else
    '                        .SetActiveCell(2, .ActiveRow)
    '                    End If
    '                ElseIf .ActiveCol = 2 Then
    '                    If Trim(.Text) = "" Then
    '                        .SetActiveCell(2, .ActiveRow)
    '                    Else
    '                        .SetActiveCell(3, .ActiveRow)
    '                    End If
    '                ElseIf .ActiveCol = 3 Then
    '                    If Trim(.Text) = "" Then
    '                        .SetActiveCell(3, .ActiveRow)
    '                    Else
    '                        .SetActiveCell(4, .ActiveRow)
    '                        .SetActiveCell(1, .ActiveRow + 1)
    '                    End If
    '                End If
    '            End With
    '        End If
    '        If e.keyCode = Keys.F3 Then
    '            With SSGRID_BOOKING
    '                .Row = .ActiveRow
    '                .DeleteRows(.ActiveRow, 1)
    '                If .ActiveRow <= 1 Then
    '                    .SetActiveCell(1, .ActiveRow)
    '                Else
    '                    .SetActiveCell(1, .ActiveRow - 1)
    '                End If
    '            End With
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
    '        Exit Sub
    '    End Try
    'End Sub
    Private Sub RBCLUBMEMBER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RBCLUBMEMBER.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtmcode.Focus()
        End If
    End Sub
    Private Sub RBASSOCIATEMEMBER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RBASSOCIATEMEMBER.KeyPress
        If Asc(e.KeyChar) = 13 Then
            txtmcode.Focus()
        End If
    End Sub
    Private Sub TXTASSOCIATENAME_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            TXTVOUCHERNO.Focus()
        End If
    End Sub
    Private Sub calculate()
        Dim hallcode, hallrate As String
        Dim TAXCODE, ItemTypeCode As String
        Dim HALLTYPE1, FROMTIME, TOTIME As String
        Dim STRSQL As String
        Dim TPercent, RoomPer, PartyPer As Double
        Dim TAXAMOUNT, perc, taxpercent, rate, drate, halltotalamount, dbldicountAmount As Double
        'LOGAN
        For i = 1 To SSGRID_BOOKING.DataRowCnt
            rate = 0
            Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
            GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
            With SSGRID_BOOKING
                .Col = 1
                .Row = i
                hallcode = .Text

                .Col = 3
                .Row = i
                HALLTYPE1 = .Text

                .Col = 5
                .Row = i
                FROMTIME = .Text

                .Col = 6
                .Row = i
                TOTIME = .Text

                .Col = 7
                .Row = i
                rate = Val(.Text)

                If Val(TXT_DISAMT.Text) > 0 Then
                    drate = rate - (rate * Val(TXT_DISAMT.Text) / 100)
                End If

                .Col = 8
                .Row = i
                ChargeCode = .Text

                sqlstring = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode  FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                gconnection.getDataSet(sqlstring, "CODE_CHECK")
                If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                    ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                End If

                sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                gconnection.getDataSet(sqlstring, "TAXON")
                If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                    For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                        IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                        TAXCODE = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                        Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                        TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")

                        STRSQL = "INSERT INTO party_hallbooking_det_TAX (BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,HALLRATE,HALLTAXCODE,CHARGECODE,HALLTAXON,HALLTAXPERC,HALLTAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                        STRSQL = STRSQL & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(hallcode) & "','" & Trim(HALLTYPE1) & "','" & Format(Dtppartydate.Value, "dd-MMM-yyyy") & "','" & Trim(FROMTIME) & "','" & Trim(TOTIME) & "'," & Val(rate) & ",'" & Trim(TAXCODE) & "','" & Trim(ChargeCode) & "','" & Trim(Taxon) & "'," & (TPercent) & ","

                        If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                            If Val(TXT_DISAMT.Text) > 0 Then
                                Zero = (drate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            Else
                                Zero = (rate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            End If
                            GZero = GZero + Zero
                            .SetText(9, i, Zero)
                            .SetText(10, i, Zero + rate)


                            STRSQL = STRSQL & "" & Val(Zero) * 1 & ","
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                            ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroA = GZeroA + ZeroA
                            .SetText(9, i, ZeroA)
                            .SetText(10, i, ZeroA + rate)

                            STRSQL = STRSQL & "" & Val(ZeroA) * 1 & ","
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                            ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GZeroB = GZeroB + ZeroB
                            .SetText(9, i, ZeroB)
                            .SetText(10, i, ZeroB + rate)

                            STRSQL = STRSQL & "" & Val(ZeroB) * 1 & ","
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                            If Val(TXT_DISAMT.Text) > 0 Then
                                One = ((drate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            Else
                                One = ((rate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            End If

                            GOne = GOne + One
                            .SetText(9, i, One)
                            .SetText(10, i, One + rate)

                            STRSQL = STRSQL & "" & Val(One) * 1 & ","
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                            OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneA = GOneA + OneA
                            .SetText(9, i, OneA)
                            .SetText(10, i, OneA + rate)

                            STRSQL = STRSQL & "" & Val(OneA) * 1 & ","
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                            OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GOneB = GOneB + OneB
                            .SetText(9, i, OneB)
                            .SetText(10, i, OneB + rate)

                            STRSQL = STRSQL & "" & Val(OneB) * 1 & ","
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                            If Val(TXT_DISAMT.Text) > 0 Then
                                Two = ((drate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            Else
                                Two = ((rate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            End If

                            GTwo = GTwo + Two
                            .SetText(9, i, Two)
                            .SetText(10, i, Two + rate)

                            STRSQL = STRSQL & "" & Val(Two) * 1 & ","
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                            TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoA = GTwoA + TwoA
                            .SetText(9, i, TwoA)
                            .SetText(10, i, TwoA + rate)

                            STRSQL = STRSQL & "" & Val(TwoA) * 1 & ","
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                            TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GTwoB = GTwoB + TwoB
                            .SetText(9, i, TwoB)
                            .SetText(10, i, TwoB + rate)

                            STRSQL = STRSQL & "" & Val(TwoB) * 1 & ","
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                            If Val(TXT_DISAMT.Text) > 0 Then
                                Three = ((drate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            Else
                                Three = ((rate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            End If

                            GThree = GThree + Three
                            .SetText(9, i, Three)
                            .SetText(10, i, Three + rate)

                            STRSQL = STRSQL & "" & Val(Three) * 1 & ","
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                            ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeA = GThreeA + ThreeA
                            .SetText(9, i, ThreeA)
                            .SetText(10, i, ThreeA + rate)

                            STRSQL = STRSQL & "" & Val(ThreeA) * 1 & ","
                        ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                            ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                            GThreeB = GThreeB + ThreeB
                            .SetText(9, i, ThreeB)
                            .SetText(10, i, ThreeB + rate)

                            STRSQL = STRSQL & "" & Val(ThreeB) * 1 & ","
                        End If
                        STRSQL = STRSQL & "'" & Trim(gUsername) & "',getdate(),'N','')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = STRSQL
                    Next
                    GrdTaxAmt = GZero + GZeroA + GZeroB + GOne + GOneA + GOneB + GTwo + GTwoA + GTwoB + GThree + GThreeA + GThreeB
                    .SetText(9, i, GrdTaxAmt)
                    .SetText(10, i, GrdTaxAmt + rate)

                End If
            End With
        Next

        Dim HKAmt, SPAmt As Double
        HKAmt = 0 : SPAmt = 0
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
            For i = 1 To .DataRowCnt
                .Row = i
                .Col = 16
                HKAmt = HKAmt + Val(.Text)
                .Row = i
                .Col = 17
                SPAmt = SPAmt + Val(.Text)
            Next



            Me.TXT_TOTAMT.Text = Format(Val(Me.TXT_TOTAMT.Text) + Val(halltotalamount), "0.00")
            dbldicountAmount = Format((Val(TXT_TOTAMT.Text) * Val(TXT_DISAMT.Text)) / 100, "0.00")
            'SSGRID_BOOKING.GetText(7, i, Taxamt)
            If Me.TXT_TOTAMT.Text < dbldicountAmount Then
                MessageBox.Show("DISCOUNT AMOUNT CANNOT BE GREATER THAN TOTAL AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            TXT_TOTAMT.Text = Format(Math.Round(TOT_AMT23(SSGRID_BOOKING), 0), "0.00")
            Txt_Others.Text = Format(Val(HKAmt + SPAmt), "0.00")
            Me.TXTB_BAMOUNT.Text = Format(Val(TXT_TOTAMT.Text + HKAmt + SPAmt) - Format(Val(dbldicountAmount)), "0.00")
            '.SetActiveCell(1, .ActiveRow + 1)
            .Focus()
            'Me.TXT_TOTAMT.Text = Format(Val(Me.TXT_TOTAMT.Text) + Val(halltotalamount), "0.00")
            'Next I
        End With

    End Sub

    Private Function TOT_AMT23(ByVal _ssgrid As AxFPSpreadADO.AxfpSpread) As Double
        Dim _Totamount, _taxamount As Double
        _Totamount = 0
        _taxamount = 0
        With _ssgrid
            For i = 1 To .DataRowCnt
                .Col = 10
                .Row = i
                _Totamount = _Totamount + Math.Round(Val(.Text), 2)
            Next i
            Return Math.Round((_Totamount), 2)
        End With
    End Function
    Private Sub FILLHALLDETAILS()
        Dim hallcd, Weekday, ShallCode As String
        'KGA HELP 
        Try
            Weekday = Dtppartydate.Value.DayOfWeek.ToString
            Dim vform As New LIST_OPERATION1
            ssql = "SELECT * FROM PARTY_HOLIDAYMASTER WHERE DATES = '" & Format(Dtppartydate.Value, "dd-MMM-yyyy") & "'"
            gconnection.getDataSet(ssql, "HDay")
            If gdataset.Tables("HDay").Rows.Count > 0 Then
                gSQLString = " SELECT distinct HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,FROMTIME,TOTIME,HoliDayRate as Rate,TAXTYPE,SEDEPOSIT,H_Type,HKStaff,SecurityStaff,HKStaffRate,SPRate,SuperHallCode FROM PARTY_VIEW_HALLMASTER"
            Else
                If Weekday = "Saturday" Or Weekday = "Sunday" Then
                    '.Text = gdataset.Tables("HAL").Rows(CNT).Item("WeekendRate")
                    gSQLString = " SELECT distinct HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,FROMTIME,TOTIME,WeekendRate as Rate,TAXTYPE,SEDEPOSIT,H_Type,HKStaff,SecurityStaff,HKStaffRate,SPRate,SuperHallCode FROM PARTY_VIEW_HALLMASTER"
                Else
                    '.Text = gdataset.Tables("HAL").Rows(CNT).Item("WDayRate")
                    gSQLString = " SELECT distinct HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,FROMTIME,TOTIME,WDayRate as Rate,TAXTYPE,SEDEPOSIT,H_Type,HKStaff,SecurityStaff,HKStaffRate,SPRate,SuperHallCode FROM PARTY_VIEW_HALLMASTER"
                End If
            End If

            'gSQLString = " SELECT distinct HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,FROMTIME,TOTIME,RATE,TAXTYPE,SEDEPOSIT FROM PARTY_VIEW_HALLMASTER"
            If Trim(Search) = "" Then
                M_WhereCondition = " WHERE    ISNULL(FREEZE,'')<>'Y' and H_Type = '" & Trim(Cmb_DayBasis.Text) & "'"
            Else
                M_WhereCondition = " WHERE    ISNULL(FREEZE,'')<>'Y' and H_Type = '" & Trim(Cmb_DayBasis.Text) & "'"
            End If

            vform.Field = "HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,FROMTIME,TOTIME,RATE,TAXTYPE,SEDEPOSIT"
            '   vform.vFormatstring = "           HALLTYPEDESC       |    HALLTYPECODE  |     PURPOSE      |        DESCRIPTION      | FROMTIME | TOTIME |     RATE     "
            vform.vCaption = "HALL DETAILS HELP"
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
                'KGA
                With SSGRID_BOOKING
                    .Col = 1
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield & "")
                    hallcd = Trim(vform.keyfield & "")
                    .Col = 2
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield1)
                    .Col = 3
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield2 & "")
                    .Col = 4
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield3 & "")
                    .Col = 5
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield4 & "")
                    ShallCode = Trim(vform.keyfield14 & "")
                    ssql = "SELECT BOOKINGNO,PARTYDATE,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGDETAILS"
                    If ShallCode <> "" Then
                        ssql = ssql & " WHERE '" & Format(Dtppartydate.Value, "yyyy-MM-dd") & "' BETWEEN CAST(CONVERT(VARCHAR(11),PARTYDATE,106)AS DATETIME) AND CAST(CONVERT(VARCHAR(11),PARTYTODATE,106)AS DATETIME) AND '" & (.Text) & "' BETWEEN FROMTIME AND TOTIME  AND (HALLCODE='" & hallcd & "' or HALLCODE='" & ShallCode & "' ) AND STYPE = 'CONFIRMED' And Bookingno<>" & TXTBOOKINGNO.Text
                    Else
                        ssql = ssql & " WHERE '" & Format(Dtppartydate.Value, "yyyy-MM-dd") & "' BETWEEN CAST(CONVERT(VARCHAR(11),PARTYDATE,106)AS DATETIME) AND CAST(CONVERT(VARCHAR(11),PARTYTODATE,106)AS DATETIME) AND '" & (.Text) & "' BETWEEN FROMTIME AND TOTIME  AND (HALLCODE='" & hallcd & "' or SUPERHALLCODE='" & hallcd & "' ) AND STYPE = 'CONFIRMED' And Bookingno<>" & TXTBOOKINGNO.Text
                    End If
                    DT = gconnection.GetValues(ssql)
                    If DT.Rows.Count > 0 Then
                        MessageBox.Show("ALREAD BOOKED,PLEASE CHECK THE HALLSTATUS", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Me.Cmd_Add.Enabled = False
                    End If

                    .Col = 6
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield5 & "")
                    ssql = "SELECT BOOKINGNO,PARTYDATE,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGDETAILS"
                    'ssql = ssql & " WHERE '" & Format(Dtppartydate.Value, "yyyy-MM-dd") & "' BETWEEN CAST(CONVERT(VARCHAR(11),PARTYDATE,106)AS DATETIME) AND CAST(CONVERT(VARCHAR(11),PARTYTODATE,106)AS DATETIME) AND '" & (.Text) & "' BETWEEN FROMTIME AND TOTIME  AND (HALLCODE='" & hallcd & "' or HALLCODE='" & ShallCode & "' ) And Bookingno<>" & TXTBOOKINGNO.Text
                    If ShallCode <> "" Then
                        ssql = ssql & " WHERE '" & Format(Dtppartydate.Value, "yyyy-MM-dd") & "' BETWEEN CAST(CONVERT(VARCHAR(11),PARTYDATE,106)AS DATETIME) AND CAST(CONVERT(VARCHAR(11),PARTYTODATE,106)AS DATETIME) AND '" & (.Text) & "' BETWEEN FROMTIME AND TOTIME  AND (HALLCODE='" & hallcd & "' or HALLCODE='" & ShallCode & "' ) AND STYPE = 'CONFIRMED' And Bookingno<>" & TXTBOOKINGNO.Text
                    Else
                        ssql = ssql & " WHERE '" & Format(Dtppartydate.Value, "yyyy-MM-dd") & "' BETWEEN CAST(CONVERT(VARCHAR(11),PARTYDATE,106)AS DATETIME) AND CAST(CONVERT(VARCHAR(11),PARTYTODATE,106)AS DATETIME) AND '" & (.Text) & "' BETWEEN FROMTIME AND TOTIME  AND (HALLCODE='" & hallcd & "' or SUPERHALLCODE='" & hallcd & "' ) AND STYPE = 'CONFIRMED' And Bookingno<>" & TXTBOOKINGNO.Text
                    End If
                    DT = gconnection.GetValues(ssql)
                    If DT.Rows.Count > 0 Then
                        MessageBox.Show("ALREAD BOOKED,PLEASE CHECK THE HALLSTATUS", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                        Me.Cmd_Add.Enabled = False
                    End If

                    .Col = 7
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield6 & "")

                    .Col = 8
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield7 & "")

                    '.Col = 9
                    '.Row = .ActiveRow
                    '.Text = Trim(vform.keyfield8 & "")
                    '.Col = 10
                    '.Row = .ActiveRow
                    '.Text = Trim(vform.keyfield9 & "")
                    .Col = 11
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield8 & "")

                    .Col = 12
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield9 & "")

                    .Col = 13
                    .Row = .ActiveRow
                    .Text = Format(Dtppartydate.Value, "dd/MM/yy")
                    If vform.keyfield9 = "Day" Then
                        .Lock = False
                    Else
                        .Lock = True
                    End If

                    .Col = 14
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield10 & "")
                    .Col = 15
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield11 & "")
                    duplicate()
                    ''.SetActiveCell(1, .ActiveRow + 1)
                    '.Focus()
                    .Col = 16
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield10 * vform.keyfield12 & "")
                    .Col = 17
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield11 * vform.keyfield13 & "")
                    .Col = 18
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield14 & "")
                End With
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub
    Private Function HALLSTATUSHELP()
        Dim vform As New ListOperattion1
        If SSGRID_BOOKING.ActiveCol = 4 Then
            gSQLString = " SELECT ISNULL(HALLTYPE,'') AS HALLTYPE,ISNULL(HALLAMOUNT,0) AS HALLAMOUNT FROM PARTY_HALLTYPE"
            If Trim(Search) = "" Then
                M_WhereCondition = ""
            Else
                M_WhereCondition = ""
            End If
            vform.Field = "HALLTYPE,HALLAMOUNT"
            vform.vFormatstring = "ITEMDESCRIPTION      |AMOUNT    "
            vform.vCaption = "HALL DETAILS HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                With SSGRID_BOOKING
                    .Lock = False
                    .Col = 4
                    .Row = .ActiveRow
                    .Text = ""
                    .Text = Trim(vform.keyfield & "")
                    .Lock = True

                    .Col = 5
                    .Row = .ActiveRow
                    .Lock = False
                    .Text = ""
                    .Text = Trim(vform.keyfield1 & "")
                    .Lock = False
                    .SetActiveCell(5, .ActiveRow)
                End With
            End If
            vform.Close()
            vform = Nothing
            Call TEMPBOOKINGDETAILS()
        End If
    End Function
    Private Sub TXTASSOCIATENAME_KeyPress1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTASSOCIATENAME.KeyPress
        If Asc(e.KeyChar) = 13 Then
            RDBPARTYBOOKINGTIME.Focus()
        End If
    End Sub
    Private Sub CHKBOOKINGSCREEN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RDBPARTYBOOKINGTIME.Focus()
    End Sub
    Private Sub CHKBOOKINGSCREEN_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CHKBOOKINGSCREEN_CheckedChanged(sender, e)
    End Sub
    Private Sub CMDPRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDPRINT1.Click
        gPrint = True
        'Call hallbilling()
    End Sub
    Private Sub TEMPBOOKINGDETAILS()
        Try
            Dim _date, TINSERT(0), HALLCODE As String
            Dim ftime, ttime, SNO As Integer
            Dim _row As Integer
            ssql = "DELETE FROM PARTY_TEMPBOOKING WHERE HALLCODE='" & Trim(txthallcode.Text) & "' AND PARTYDATE = '" & Format(Dtppartydate.Value, "dd/MMM/yyyy") & "'"
            ReDim Preserve TINSERT(TINSERT.Length)
            TINSERT(TINSERT.Length - 1) = ssql
            With SSGRID_BOOKING
                _row = .ActiveRow + 1
                '.SetActiveCell(1, 1)
                For i = 1 To .DataRowCnt
                    _date = "" : ftime = 0 : ttime = 0
                    .Col = 1
                    .Row = i
                    HALLCODE = Trim(.Text)

                    .Col = 5
                    .Row = i
                    ftime = Val(.Text)

                    .Col = 6
                    .Row = i
                    ttime = Val(.Text)

                    ssql = "INSERT INTO PARTY_TEMPBOOKING(SNO,HALLCODE,PARTYDATE,FROMTIME,TOTIME)"
                    ssql = ssql & " VALUES(" & i & ",'" & Trim(HALLCODE) & "','" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "'," & ftime & "," & ttime & ")"

                    ReDim Preserve TINSERT(TINSERT.Length)
                    TINSERT(TINSERT.Length - 1) = ssql
                Next
                'gconnection.dataOperation1(5, TINSERT)
                gconnection.MoreTrans1(TINSERT)
            End With
            ''''' DTPBOOKINGDATE.Focus()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Hall_Status()
        'PRIVATE SUB STATUSHALL
        SSgrid.Lock = False
        Dim II As Integer
        Dim SSTR As String
        Try
            Dim dno As Integer
            Dim dd, dd1 As Date
            Dim dt As New DataTable
            Dim dt2 As New DataTable
            Dim dt3 As New DataTable
            Dim SSQL2 As String
            ssql = " DELETE FROM PARTY_HallStatus"
            dt = gconnection.GetValues(ssql)
            dd = Dtppartydate.Value
            Dim hallcode, PCODE As String
            hallcode = (txthallcode.Text)




            For II = 0 To SSGRID_BOOKING.DataRowCnt - 1
                SSGRID_BOOKING.Col = 1
                SSGRID_BOOKING.Row = II + 1
                txthallcode.Text = Trim(SSGRID_BOOKING.Text)
                SSGRID_BOOKING.Col = 3
                SSGRID_BOOKING.Row = II + 1
                PCODE = Trim(SSGRID_BOOKING.Text)

                SSQL2 = "SELECT * FROM party_hallstatusdetails WHERE "
                SSQL2 = SSQL2 & " CAST(Convert(varchar(11),PARTYDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                SSQL2 = SSQL2 & " and hallcode='" & hallcode & "' AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                dt3 = gconnection.GetValues(SSQL2)

                dd = DateAdd(DateInterval.Day, -1, Dtppartydate.Value)
                For i = 0 To 6
                    dd = dd.AddDays(+1)
                    ssql = " SELECT FROMTIME,TOTIME,H_Type FROM  PARTY_HALLBOOKING_DET WHERE "
                    ssql = ssql & "  cast(convert(varchar(11),PARTYDATE,106)as datetime)='" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "'"
                    ssql = ssql & " and hallcode ='" & Trim(txthallcode.Text) & "'AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                    dt = gconnection.GetValues(ssql)
                    If dt.Rows.Count > 0 Then
                        ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                        ssql = ssql & "  cast(convert(varchar(11),BOOKINGDATE,106)as datetime)='" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "'"
                        ssql = ssql & " and hallcode='" & txthallcode.Text & "'"
                        dt2 = gconnection.GetValues(ssql)
                        If dt2.Rows.Count <= 0 Then
                            ssql = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
                            ssql = ssql & " values('" & Trim(txthallcode.Text) & "','" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "')"
                            gconnection.ExcuteStoreProcedure(ssql)
                        End If

                        For j = 0 To dt.Rows.Count - 1
                            For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='P'"
                                ssql = ssql & " Where Bookingdate='" & Format(dd, "yyyy-MM-dd") & "' AND HALLCODE='" & Trim(txthallcode.Text) & "'"
                                gconnection.ExcuteStoreProcedure(ssql)
                            Next
                            ssql = ""
                        Next
                        If dt3.Rows.Count > 0 Then
                            For j = 0 To dt.Rows.Count - 1
                                For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                    ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='C'"
                                    ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                    ssql = ssql & " and hallcode='" & hallcode & "'"

                                    gconnection.ExcuteStoreProcedure(ssql)
                                Next
                                ssql = ""
                            Next
                        End If
                    Else
                        ssql = " SELECT FROMTIME,TOTIME,H_Type FROM  PARTY_HALLBOOKING_DET WHERE "
                        ssql = ssql & "  '" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "' BETWEEN cast(convert(varchar(11),Partydate,106)as datetime) AND cast(convert(varchar(11),PartyTodate,106)as datetime)"
                        ssql = ssql & " and hallcode ='" & Trim(txthallcode.Text) & "'AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                        dt = gconnection.GetValues(ssql)
                        If dt.Rows.Count > 0 Then
                            ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                            ssql = ssql & "  cast(convert(varchar(11),BOOKINGDATE,106)as datetime)='" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "'"
                            ssql = ssql & " and hallcode='" & txthallcode.Text & "'"
                            dt2 = gconnection.GetValues(ssql)
                            If dt2.Rows.Count <= 0 Then
                                ssql = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
                                ssql = ssql & " values('" & Trim(txthallcode.Text) & "','" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "')"
                                gconnection.ExcuteStoreProcedure(ssql)
                            End If

                            For j = 0 To dt.Rows.Count - 1
                                For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                    ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='P'"
                                    ssql = ssql & " Where Bookingdate='" & Format(dd, "yyyy-MM-dd") & "' AND HALLCODE='" & Trim(txthallcode.Text) & "'"
                                    gconnection.ExcuteStoreProcedure(ssql)
                                Next
                                ssql = ""
                            Next
                            If dt3.Rows.Count > 0 Then
                                For j = 0 To dt.Rows.Count - 1
                                    For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                        ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='C'"
                                        ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                        ssql = ssql & " and hallcode='" & hallcode & "'"

                                        gconnection.ExcuteStoreProcedure(ssql)
                                    Next
                                    ssql = ""
                                Next
                            End If
                        Else
                            ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                            ssql = ssql & " BOOKINGDATE='" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "'"
                            ssql = ssql & " and hallcode='" & txthallcode.Text & "'"
                            dt2 = gconnection.GetValues(ssql)
                            If dt2.Rows.Count <= 0 Then
                                ssql = "Insert Into PARTY_HallStatus(HALLCODE,Bookingdate)"
                                ssql = ssql & " values('" & Trim(txthallcode.Text) & "','" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "')"
                                gconnection.ExcuteStoreProcedure(ssql)
                            End If
                        End If
                       
                    End If
                Next
            Next II
            ssql = "UPDATE PARTY_HallStatus SET SUPERSET = ''"
            gconnection.ExcuteStoreProcedure(ssql)
            ssql = "UPDATE PARTY_HallStatus SET SUPERSET = SuperHallCode FROM PARTY_HALLMASTER_HDR H,PARTY_HallStatus S WHERE H.halltypecode = S.HALLCODE"
            gconnection.ExcuteStoreProcedure(ssql)


            ssql = " SELECT HALLCODE,BOOKINGDATE,B1,B2,B3,B4,B5,B6,B7,B8,B9,B10,B11,B12,B13,B14,B15,B16,B17,B18,B19,B20,B21,B22,"
            ssql = ssql & " B23,B24,SUPERSET FROM VIEW_PARTY_STATUSHALL order by bookingdate,HALLCODE"
            dt = (gconnection.GetValues(ssql))
            SSgrid.SetActiveCell(1, 1)
            Dim rowid As Integer
            Dim Super As String
            If dt.Rows.Count > 0 Then
                SSgrid.Enabled = True
                With SSgrid
                    For i = 0 To dt.Rows.Count - 1
                        rowid = rowid + 1
                        .Row = rowid
                        .Col = 1
                        .Text = Trim(dt.Rows(i).Item("HALLCODE"))
                        Super = Trim(dt.Rows(i).Item("SUPERSET"))
                        .Row = rowid
                        .Col = 2
                        For j = 0 To 24
                            If j = 0 Then
                                .SetActiveCell(j + 2, rowid)
                                .Col = j + 2
                                .Row = rowid
                                .BackColor = Color.GreenYellow
                                .ForeColor = Color.Blue
                                .Text = Format(dt.Rows(i).Item(dt.Columns(j + 1).ColumnName), "dd/MM/yyyy")
                            Else
                                If dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) = "C" And Super = "" Then
                                    SSgrid.SetActiveCell(j + 1, rowid)
                                    .Col = j + 2
                                    .Row = rowid
                                    .Text = "C"
                                    .BackColor = Color.Red
                                ElseIf dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) = "C" And Super <> "" Then
                                    SSgrid.SetActiveCell(j + 1, rowid)
                                    .Col = j + 2
                                    .Row = rowid
                                    .Text = "C"
                                    .BackColor = Color.Red

                                ElseIf dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) = "P" And Super = "" Then
                                    SSgrid.SetActiveCell(j + 1, rowid)
                                    .Col = j + 2
                                    .Row = rowid
                                    .Text = "P"
                                    .BackColor = Color.Blue
                                    '.Text = dt.Rows(i).Item(dt.Columns(j).ColumnName)
                                ElseIf dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) = "P" And Super <> "" Then
                                    SSgrid.SetActiveCell(j + 1, rowid)
                                    .Col = j + 2
                                    .Row = rowid
                                    .Text = "P"
                                    .BackColor = Color.Blue
                                Else
                                    SSgrid.SetActiveCell(j + 1, rowid)
                                    .Col = j + 2
                                    .Row = rowid
                                    .BackColor = Color.Green
                                End If
                            End If
                        Next
                    Next
                    'For i = 0 To dt.Rows.Count - 1
                    '    rowid = rowid + 1
                    '    .Row = rowid
                    '    .Col = 1
                    '    .Text = Trim(dt.Rows(i).Item("HALLCODE"))
                    '    .Row = rowid
                    '    .Col = 2
                    '    For j = 0 To 24
                    '        If j = 0 Then
                    '            .SetActiveCell(j + 2, rowid)
                    '            .Col = j + 2
                    '            .Row = rowid
                    '            .BackColor = Color.GreenYellow
                    '            .ForeColor = Color.Blue
                    '            .Text = Format(dt.Rows(i).Item(dt.Columns(j + 1).ColumnName), "dd/MM/yyyy")
                    '        Else
                    '            If dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) <> "" Then
                    '                SSgrid.SetActiveCell(j + 1, rowid)
                    '                .Col = j + 2
                    '                .Row = rowid
                    '                .BackColor = Color.Red
                    '            Else
                    '                SSgrid.SetActiveCell(j + 1, rowid)
                    '                .Col = j + 2
                    '                .Row = rowid
                    '                .BackColor = Color.Green
                    '            End If
                    '        End If
                    '        .MaxRows = rowid + 1
                    '    Next
                    'Next
                    .SetActiveCell(2, 1)
                End With
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub RDBPARTYBOOKINGTIME_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBPARTYBOOKINGTIME.CheckedChanged
        If RDBPARTYBOOKINGTIME.Checked = True Then
            GBHALLBOOKING.Visible = True
            GBHALLSTATUS.Visible = False
            GRPRECEIPT.Visible = False
            SSGRID_BOOKING.Focus()
            'SSGRID_BOOKING.SetActiveCell(1, 1)
        End If
    End Sub
    Private Sub RDBHALLAVAILABLITY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBHALLAVAILABLITY.CheckedChanged
        If RDBHALLAVAILABLITY.Checked = True Then
            GBHALLBOOKING.Visible = False
            GBHALLSTATUS.Visible = True
            GRPRECEIPT.Visible = False
            TXT_DISAMT.Visible = False
            TXT_TOTAMT.Visible = False
            TXTB_BAMOUNT.Visible = False
            SSgrid.Focus()
            Call Hall_Status()
            'SSgrid.SetActiveCell(1, 1)
        End If
    End Sub
    Private Sub RDBRECEIPTENTRY_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RDBRECEIPTENTRY.CheckedChanged
        If RDBRECEIPTENTRY.Checked = True Then
            GBHALLBOOKING.Visible = False
            GBHALLSTATUS.Visible = False
            GRPRECEIPT.Visible = True
            ssgrid_Receipt.Focus()
            'ssgrid_Receipt.SetActiveCell(1, 1)
        End If
        ssgrid_Receipt.Enabled = False
        TXT_DISAMT.Visible = False
        TXT_TOTAMT.Visible = False
        TXTB_BAMOUNT.Visible = False
        sqlstring = "SELECT * from partyrec_advance WHERE bookno='" & Me.TXTBOOKINGNO.Text & "'"
        DT = gconnection.GetValues(sqlstring)
        If DT.Rows.Count > 0 Then
            ssgrid_Receipt.ClearRange(-1, -1, 1, 1, True)
            With ssgrid_Receipt
                For i = 0 To DT.Rows.Count - 1
                    .Col = 1
                    .Row = i + 1
                    .Text = DT.Rows(i).Item("PARTYRECEIPTNO")
                    .Col = 2
                    .Row = i + 1
                    '.Text = Format(DT.Rows(i).Item("PARTYRECEIPTDATE"), "dd/MM/yy")
                    .Text = Format(CDate(Trim(DT.Rows(i).Item("PARTYRECEIPTDATE"))), "dd/MM/yyyy")
                    'DTPVOUCHERDATE.Value = Format(gdataset.Tables("HallStatus").Rows(0).Item("receiptdate"), "dd/MM/yyyy")
                    .Col = 3
                    .Row = i + 1
                    .Text = DT.Rows(i).Item("amount")
                    .Col = 4
                    .Row = i + 1
                    .Text = DT.Rows(i).Item("Receiptheaddesc")
                Next
            End With
        End If
    End Sub
    Private Sub ssgrid_Receipt_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid_Receipt.KeyDownEvent


        'Try
        '    With ssgrid_Receipt
        '        If e.keyCode = Keys.Enter Then
        '            If .ActiveCol = 1 Then
        '                .SetActiveCell(2, .ActiveRow)
        '            ElseIf .ActiveCol = 2 Then
        '                .SetActiveCell(3, .ActiveRow)
        '            ElseIf .ActiveCol = 3 Then
        '                .SetActiveCell(4, .ActiveRow)
        '            ElseIf .ActiveCol = 4 Then
        '                .SetActiveCell(1, .ActiveRow + 1)
        '            End If
        '        ElseIf e.keyCode = Keys.F3 Then
        '            .Row = .ActiveRow
        '            .DeleteRows(.ActiveRow, 1)
        '            If .ActiveRow <= 1 Then
        '                .SetActiveCell(1, .ActiveRow)
        '            Else
        '                .SetActiveCell(1, .ActiveRow - 1)
        '            End If
        '        End If
        '    End With
        'Catch ex As Exception
        '    MessageBox.Show("Handle the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End Try
    End Sub
    Private Sub ssgrid_Receipt_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid_Receipt.LeaveCell
        'With ssgrid_Receipt
        '    If .ActiveCol = 4 Then
        '    End If
        'End With
    End Sub

    Private Sub TxtDescription_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDescription.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtDescription.Text = "" Then
                Call cmd_Purpose_Click(sender, e)
            Else
                Call TxtDescription_Validated(sender, e)
                If Cmb_GuestType.Enabled = True Then
                    Cmb_GuestType.Focus()
                Else
                    TXTGUESTNAME.Focus()
                End If

            End If
        End If
    End Sub
    Private Sub TxtDescription_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDescription.KeyPress
        ' If Asc(e.KeyChar) = 13 Then
        'If TxtDescription.Text = "" Then
        '    TxtDescription.Focus()
        'Else
        '    txtmcode.Focus()
        'End If

        'TXTGUESTNAME.Focus()
        'End If
    End Sub
    Private Sub TxtOCCUPANCY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOCCUPANCY.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            SSGRID_BOOKING.SetActiveCell(1, 1)
            SSGRID_BOOKING.Focus()
        End If
    End Sub
    Private Sub CMB_LOCATION_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMB_LOCATION.SelectedIndexChanged
        Cmd_Clear_Click(sender, e)
        CMB_LOCATION.Focus()
    End Sub
    Private Sub CMB_LOCATION_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMB_LOCATION.KeyPress
        If Asc(e.KeyChar) = 13 Then
            DTPBOOKINGDATE.Focus()
        End If
    End Sub
    Private Sub CMB_LOCATION_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMB_LOCATION.LostFocus
        Dim SQLSTRING As String
        SQLSTRING = "SELECT DISTINCT LOCCODE FROM PARTY_LOCATIONMASTER WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
        gconnection.getDataSet(SQLSTRING, "PARTY_LOCATIONMASTER")
        If gdataset.Tables("PARTY_LOCATIONMASTER").Rows.Count <= 0 Then
            CMB_LOCATION.Focus()
            CMB_LOCATION.BackColor = Color.Red
        Else
            CMB_LOCATION.BackColor = Color.White
        End If
    End Sub
    Private Sub datevalidation()
        Try
            sqlstring = "SELECT SERVERDATE,SERVERTIME FROM VIEW_SERVER_DATETIME "
            gconnection.getDataSet(sqlstring, "SERVERDATE")
            If gdataset.Tables("SERVERDATE").Rows.Count > 0 Then
                If CDate(Format(DTPBOOKINGDATE.Value, "yyyy/MMM/dd")) < CDate(Format(gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE"), "yyyy/MMM/dd")) Then
                    MsgBox("Booking Date should be Greaterthan or equal to Server System Date.......", MsgBoxStyle.OkOnly, "Date Validation")
                    DTPBOOKINGDATE.Value = gdataset.Tables("SERVERDATE").Rows(0).Item("SERVERDATE")
                    Exit Sub
                End If

                If CDate(Format(gFinancialyearEnding, "yyyy/MMM/dd")) < CDate(Format(DTPBOOKINGDATE.Value, "yyyy/MMM/dd")) Then
                    '                    MsgBox("To Date Should be within Financial Year Date.......", MsgBoxStyle.OKOnly, "Date Validation")
                    'DTPBOOKINGDATE.Value = gFinancialyearEnding
                    DTPBOOKINGDATE.Value = Format("dd/MM/yyyy", Now())
                    '                   Exit Sub
                End If

                If CDate(Format(DTPBOOKINGDATE.Value, "yyyy/MMM/dd")) > CDate(Format(Dtppartydate.Value, "yyyy/MMM/dd")) Then
                    MsgBox("Booking Date Should be Less than party Date.......", MsgBoxStyle.OkOnly, "Date Validation")
                    DTPBOOKINGDATE.Value = Format("dd/MM/yyyy", Now())
                    'DTPBOOKINGDATE.Value = gFinancialyearEnding
                    '                 Exit Sub
                    Exit Sub

                End If
                '07072012 changed by logan
                'start 
                'If CDate(Format(DTPBOOKINGDATE.Value, "yyyy/MMM/dd")) < CDate(Format(Now(), "yyyy/MMM/dd")) Then
                '    MsgBox("Booking Date Should be Less than server Date.......", MsgBoxStyle.OKOnly, "Date Validation")
                '    DTPBOOKINGDATE.Value = Format("dd/MM/yyyy", Now())
                '    'DTPBOOKINGDATE.Value = gFinancialyearEnding
                '    '                 Exit Sub
                'End If
                'end 



                'If CDate(Format(DTPBOOKINGDATE.Value, "yyyy/MMM/dd")) < CDate(Format(gFinancialyearStart, "yyyy/MMM/dd")) Then
                '    MsgBox("From Date Should be within Financial Year Date.......", MsgBoxStyle.OKOnly, "Date Validation")
                '    DTPBOOKINGDATE.Value = gFinancialyearStart
                '    '                Exit Sub
                'End If
                'vijay28mar12
                'If CDate(Format(DTPBOOKINGDATE.Value, "yyyy/MMM/dd")) > CDate(Format(Dtppartydate.Value, "yyyy/MMM/dd")) Then
                '    MsgBox("From Date Should be Less Than or Equal to Date.......", MsgBoxStyle.OKOnly, "Date Validation")
                '    DTPBOOKINGDATE.Value = Dtppartydate.Value
                'End If
            End If
        Catch
            MsgBox("Error in date view..." & Err.Description)
        End Try
    End Sub
    Private Sub DTPBOOKINGDATE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPBOOKINGDATE.LostFocus
        Call datevalidation()
    End Sub

    Private Sub Dtppartydate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dtppartydate.LostFocus
        Call datevalidation()
    End Sub

    Private Sub Dtppartydate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtppartydate.ValueChanged
        LBL_PARTYDAY.Text = Format(Dtppartydate.Value, "ddddd")
    End Sub

    Private Sub DTPBOOKINGDATE_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPBOOKINGDATE.ValueChanged
        LBL_BOOKDAY.Text = Format(DTPBOOKINGDATE.Value, "ddddd")
    End Sub
    Private Sub TxtNVOCCUPANCY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNVOCCUPANCY.KeyPress
        '     getNumeric(e)
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
                'MsgBox(" Numbers only ")
            End If
        End If
        'If Asc(e.KeyChar) = 13 Then
        '    SSGRID_BOOKING.SetActiveCell(1, 1)
        '    SSGRID_BOOKING.Focus()
        'End If
        If Asc(e.KeyChar) = 13 Then
            'txtmcode.Focus()
            TxtVOCCUPANCY.Focus()
        End If
    End Sub

    Private Sub TxtVOCCUPANCY_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVOCCUPANCY.KeyPress
        '  getNumeric(e)
        If e.KeyChar <> ChrW(Keys.Back) Then
            If Char.IsNumber(e.KeyChar) Then
            Else
                e.Handled = True
                'MsgBox(" Numbers only ")
            End If
        End If

        If Asc(e.KeyChar) = 13 Then
            SSGRID_BOOKING.SetActiveCell(1, 1)
            SSGRID_BOOKING.Focus()
        End If
    End Sub
    Private Sub TxtVOCCUPANCY_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVOCCUPANCY.LostFocus
        TxtOCCUPANCY.Text = Val(TxtVOCCUPANCY.Text) + Val(TxtNVOCCUPANCY.Text)
    End Sub

    Private Sub TxtNVOCCUPANCY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNVOCCUPANCY.TextChanged

    End Sub

    Private Sub TxtNVOCCUPANCY_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNVOCCUPANCY.LostFocus
        TxtOCCUPANCY.Text = Val(TxtVOCCUPANCY.Text) + Val(TxtNVOCCUPANCY.Text)

    End Sub

    Private Sub TXTBOOKINGNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBOOKINGNO.TextChanged

    End Sub

    Private Sub txtmcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmcode.TextChanged

    End Sub

    Private Sub TxtDescriptiont_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDescription.TextChanged

    End Sub

    Private Sub SSGRID_BOOKING_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSGRID_BOOKING.Advance

    End Sub

    Private Sub ssgrid_Receipt_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid_Receipt.Advance

    End Sub

    Private Sub GRPRECEIPT_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRPRECEIPT.Enter

    End Sub

    Private Sub cmd_freeze1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_freeze1.Click
        Dim Update(0) As String
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If txt_res.Text = "" Then
            MsgBox("PLEASE ENTER THE REASON......", MsgBoxStyle.OkCancel, "Exit")
            txt_res.Focus()
            Exit Sub
        End If

        If Mid(Me.cmd_freeze1.Text, 1, 1) = "F" Then
            'If MsgBox("PLEASE ENTER THE REASON......", MsgBoxStyle.OKCancel, "Exit") = MsgBoxResult.OK Then
            '    lbl_reson.Visible = True
            '    txt_res.Visible = True


            'End If
            sqlstring = "UPDATE  party_hdr "
            sqlstring = sqlstring & " SET Void= 'Y',AddUserid='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "', freereason='" & Trim(txt_res.Text) & "'"
            sqlstring = sqlstring & " WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            sqlstring = "UPDATE  party_hallbooking_hdr "
            sqlstring = sqlstring & " SET Void= 'Y',FREERESON='" & txt_res.Text & "',AddUserid='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "', freereson='" & Trim(txt_res.Text) & "'"
            sqlstring = sqlstring & " WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            sqlstring = "UPDATE  party_hallbooking_det "
            sqlstring = sqlstring & " SET Void= 'Y',AddUserid='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            Dim HRS, AMT, OCC As Integer
            Dim TRATE, CANRATE, CANAMT, CANHEAD, CANFROM, CANTO, HRS1, HRS2, PERC As Double
            ssql = "SELECT H.BOOKINGDATE,H.PARTYDATE,ISNULL(H.TOTALAMOUNT,0) AS TOTALAMOUNT "
            ssql = ssql & " FROM PARTY_HALLBOOKING_HDR H"
            ssql = ssql & " WHERE H.BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & "  "
            ssql = ssql & " GROUP BY H.PARTYDATE,H.BOOKINGDATE,H.TOTALAMOUNT"
            gconnection.getDataSet(ssql, "book")

            ssql = "SELECT BOOKINGDATE,PARTYDATE,ISNULL(OCCUPANCY,0)AS OCCUPANCY,ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT "
            ssql = ssql & " FROM PARTY_HALLBOOKING_HDR "
            ssql = ssql & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' "
            ssql = ssql & " GROUP BY PARTYDATE,BOOKINGDATE,OCCUPANCY,TOTALAMOUNT"
            gconnection.getDataSet(ssql, "TOT")

            If gdataset.Tables("book").Rows.Count > 0 Then
                HRS = DateDiff(DateInterval.Hour, Now(), gdataset.Tables("book").Rows(0).Item("PARTYDATE"))
                AMT = gdataset.Tables("BOOK").Rows(0).Item("TOTALAMOUNT")
            Else
                HRS = DateDiff(DateInterval.Hour, Now(), gdataset.Tables("TOT").Rows(0).Item("PARTYDATE"))
                AMT = gdataset.Tables("TOT").Rows(0).Item("TOTALAMOUNT")
            End If
            ssql = "SELECT ISNULL(CANCELFROM,0)AS CANCELFROM,ISNULL(CANCELTO,0)AS CANCELTO,ISNULL(CANCEL_AMT_PER,0)AS PERAMT,ISNULL(CANCEL_AMT_HEAD,0)AS HEADAMT,ISNULL(FIXEDAMOUNT,0)AS FIXAMT FROM PARTY_CANCELLATIONMASTER WHERE " & Val(HRS) & " BETWEEN CANCELFROM AND CANCELTO "
            gconnection.getDataSet(ssql, "CANCEL")
            If gdataset.Tables("CANCEL").Rows.Count > 0 Then
                PERC = gdataset.Tables("CANCEL").Rows(0).Item("PERAMT")
                CANHEAD = gdataset.Tables("CANCEL").Rows(0).Item("HEADAMT")
                CANRATE = gdataset.Tables("CANCEL").Rows(0).Item("FIXAMT")
                CANFROM = gdataset.Tables("CANCEL").Rows(0).Item("CANCELFROM")
                CANTO = gdataset.Tables("CANCEL").Rows(0).Item("CANCELTO")
                CANAMT = ((((Val(OCC) * TRATE) + (Val(OCC) * Val(CANHEAD)) + Val(CANRATE) + Val(AMT)) * PERC) / 100)
            End If

            'ssql = " UPDATE  PARTY_HDR SET FREEZE='Y',CANCELAMOUNT=" & Val(CANAMT) & ",FROMHRS=" & Val(CANFROM) & ",TOHRS=" & Val(CANTO) & ",CANCELDATE='" & Format(DateTime.Now, "dd/MMM/yyyy hh:mm:ss") & "' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            'insert(insert.Length - 1) = ssql
            'ReDim Preserve insert(insert.Length)

            ssql = " UPDATE  PARTY_HALLBOOKING_HDR SET CANCELFLAG='Y',FREERESON='" & txt_res.Text & "',FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            INSERT(INSERT.Length - 1) = ssql
            ReDim Preserve INSERT(INSERT.Length)

            ssql = " UPDATE  PARTY_HALLBOOKING_DET SET FREEZE='Y',CANCELAMOUNT=" & Val(CANAMT) & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            INSERT(INSERT.Length - 1) = ssql
            ReDim Preserve INSERT(INSERT.Length)

            ssql = " UPDATE PARTY_RECEIPT SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            INSERT(INSERT.Length - 1) = ssql
            ReDim Preserve INSERT(INSERT.Length)


            sqlstring = "UPDATE party_receipt_DET SET Freeze= 'Y' Where  PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "' "
            INSERT(INSERT.Length - 1) = sqlstring
            ReDim Preserve INSERT(INSERT.Length)

            sqlstring = "UPDATE party_receipt_hdr SET Freeze= 'Y',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "' Where  PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "'"
            INSERT(INSERT.Length - 1) = sqlstring
            ReDim Preserve INSERT(INSERT.Length)

            gconnection.dataOperation1(1, INSERT)

            'gconnection.dataOperation1(2, INSERT)

            If MsgBox("Do you want windows print to Annexure........", MsgBoxStyle.OkCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then
                'Call hallbilling()
            Else
                Call CANCELWINDOWS()
            End If


            Call TEMPBOOKINGDETAILS()
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add1.Text = "Add [F7]"

        Else
            sqlstring = "UPDATE  party_hdr "
            sqlstring = sqlstring & " SET Void= 'N',AddUserid='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "' "
            sqlstring = sqlstring & " WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            sqlstring = "UPDATE  party_hallbooking_hdr "
            sqlstring = sqlstring & " SET Void= 'N',FREERESON='" & txt_res.Text & "',AddUserid='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            sqlstring = "UPDATE  party_hallbooking_det "
            sqlstring = sqlstring & " SET Void= 'N',AddUserid='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            sqlstring = "UPDATE party_receipt_DET SET Freeze= 'Y' Where  PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "' "
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            sqlstring = "UPDATE party_receipt_hdr SET Freeze= 'Y',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "' Where  PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            'gconnection.MoreTrans(Update)
            Dim HRS, AMT, OCC As Integer
            Dim TRATE, CANRATE, CANAMT, CANHEAD, CANFROM, CANTO, HRS1, HRS2, PERC As Double
            ssql = "SELECT H.BOOKINGDATE,H.PARTYDATE,ISNULL(H.TOTALAMOUNT,0) AS TOTALAMOUNT "
            ssql = ssql & " FROM PARTY_HALLBOOKING_HDR H"
            ssql = ssql & " WHERE H.BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & "  "
            ssql = ssql & " GROUP BY H.PARTYDATE,H.BOOKINGDATE,H.TOTALAMOUNT"
            gconnection.getDataSet(ssql, "book")

            ssql = "SELECT BOOKINGDATE,PARTYDATE,ISNULL(OCCUPANCY,0)AS OCCUPANCY,ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT "
            ssql = ssql & " FROM PARTY_HALLBOOKING_HDR "
            ssql = ssql & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' "
            ssql = ssql & " GROUP BY PARTYDATE,BOOKINGDATE,OCCUPANCY,TOTALAMOUNT"
            gconnection.getDataSet(ssql, "TOT")

            If gdataset.Tables("book").Rows.Count > 0 Then
                HRS = DateDiff(DateInterval.Hour, gdataset.Tables("book").Rows(0).Item("PARTYDATE"), Now())
                AMT = gdataset.Tables("BOOK").Rows(0).Item("TOTALAMOUNT")
            Else
                HRS = DateDiff(DateInterval.Hour, Now(), gdataset.Tables("TOT").Rows(0).Item("PARTYDATE"))
                AMT = gdataset.Tables("TOT").Rows(0).Item("TOTALAMOUNT")
            End If
            ssql = "SELECT ISNULL(CANCELFROM,0)AS CANCELFROM,ISNULL(CANCELTO,0)AS CANCELTO,ISNULL(CANCEL_AMT_PER,0)AS PERAMT,ISNULL(CANCEL_AMT_HEAD,0)AS HEADAMT,ISNULL(FIXEDAMOUNT,0)AS FIXAMT FROM PARTY_CANCELLATIONMASTER WHERE " & Val(HRS) & " BETWEEN CANCELFROM AND CANCELTO "
            gconnection.getDataSet(ssql, "CANCEL")
            If gdataset.Tables("CANCEL").Rows.Count > 0 Then
                PERC = gdataset.Tables("CANCEL").Rows(0).Item("PERAMT")
                CANHEAD = gdataset.Tables("CANCEL").Rows(0).Item("HEADAMT")
                CANRATE = gdataset.Tables("CANCEL").Rows(0).Item("FIXAMT")
                CANFROM = gdataset.Tables("CANCEL").Rows(0).Item("CANCELFROM")
                CANTO = gdataset.Tables("CANCEL").Rows(0).Item("CANCELTO")
                CANAMT = ((((Val(OCC) * TRATE) + (Val(OCC) * Val(CANHEAD)) + Val(CANRATE) + Val(AMT)) * PERC) / 100)
            End If

            'ssql = " UPDATE  PARTY_HDR SET FREEZE='Y',CANCELAMOUNT=" & Val(CANAMT) & ",FROMHRS=" & Val(CANFROM) & ",TOHRS=" & Val(CANTO) & ",CANCELDATE='" & Format(DateTime.Now, "dd/MMM/yyyy hh:mm:ss") & "' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            'insert(insert.Length - 1) = ssql
            'ReDim Preserve insert(insert.Length)
            ''LOGAN CHANGED ON 03DEC12
            'START
            'ssql = " UPDATE  PARTY_HALLBOOKING_HDR SET CANCELFLAG='Y',FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            'INSERT(INSERT.Length - 1) = ssql
            'ReDim Preserve INSERT(INSERT.Length)

            'ssql = " UPDATE  PARTY_HALLBOOKING_DET SET FREEZE='Y',CANCELAMOUNT=" & Val(CANAMT) & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            'INSERT(INSERT.Length - 1) = ssql
            'ReDim Preserve INSERT(INSERT.Length)

            'ssql = " UPDATE PARTY_RECEIPT SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            'INSERT(INSERT.Length - 1) = ssql
            'ReDim Preserve INSERT(INSERT.Length)
            'gconnection.dataOperation1(1, INSERT)

            'gconnection.dataOperation1(2, insert)

            'END
            If MsgBox("Do you want windows print to Annexure........", MsgBoxStyle.OkCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then
                'Call hallbilling()
            Else
                Call CANCELWINDOWS()
            End If


            Call TEMPBOOKINGDETAILS()
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add1.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Label19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl_reson.Click

    End Sub

    Private Sub SSgrid_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSgrid.Advance

    End Sub

    Private Sub ssgrid_Receipt_ClickEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_ClickEvent) Handles ssgrid_Receipt.ClickEvent
    End Sub

    Private Sub TxtVOCCUPANCY_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtVOCCUPANCY.TextChanged

    End Sub

    Private Sub grchoice_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grchoice.Enter

    End Sub

    Private Sub SSGRID_BOOKING_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles SSGRID_BOOKING.LeaveCell
        'Call calculate()
    End Sub

    Private Sub TXT_DISAMT_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_DISAMT.TextChanged
        Dim i As Integer
        Dim dbldicountAmount, DISCOUNT As Double

        If Val(TXT_DISAMT.Text) >= 0 Then
            'Me.TXT_TOTAMT.Text = 0
            dbldicountAmount = Format((Val(TXT_TOTAMT.Text) * Val(TXT_DISAMT.Text)) / 100, "0.00")
            TXT_DISCOUNT.Text = dbldicountAmount
            'SSGRID_BOOKING.GetText(7, i, Taxamt)
            If Me.TXT_TOTAMT.Text < dbldicountAmount Then
                MessageBox.Show("DISCOUNT AMOUNT CANNOT BE GREATER THAN TOTAL AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Me.TXTB_BAMOUNT.Text = Val(TXT_TOTAMT.Text) - Format(Val(dbldicountAmount), "0.00")
        Else
            dbldicountAmount = Format((Val(TXT_TOTAMT.Text) * Val(TXT_DISAMT.Text)) / 100, "0.00")
            Me.TXTB_BAMOUNT.Text = Val(TXT_TOTAMT.Text) - Format(Val(dbldicountAmount), "0.00")
        End If

    End Sub

    Private Sub TXT_DISAMT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_DISAMT.KeyPress
        Dim i As Integer
        Dim dbldicountAmount, DISCOUNT As Double
        If Asc(e.KeyChar) = 13 Then
            If Val(TXT_DISAMT.Text) > 0 Then
                'Me.TXT_TOTAMT.Text = 0
                dbldicountAmount = Format((Val(TXT_TOTAMT.Text + Txt_Others.Text) * Val(TXT_DISAMT.Text)) / 100, "0.00")
                TXT_DISCOUNT.Text = dbldicountAmount
                'SSGRID_BOOKING.GetText(7, i, Taxamt)
                If Me.TXT_TOTAMT.Text < dbldicountAmount Then
                    MessageBox.Show("DISCOUNT AMOUNT CANNOT BE GREATER THAN TOTAL AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Me.TXTB_BAMOUNT.Text = Val(TXT_TOTAMT.Text + Txt_Others.Text) - Format(Val(dbldicountAmount), "0.00")
            Else
                dbldicountAmount = Format((Val(TXT_TOTAMT.Text + Txt_Others.Text) * Val(TXT_DISAMT.Text)) / 100, "0.00")
                Me.TXTB_BAMOUNT.Text = Val(TXT_TOTAMT.Text + Txt_Others.Text) - Format(Val(dbldicountAmount), "0.00")
            End If
            Call calculate()
        End If
    End Sub

    Private Sub txthallcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthallcode.TextChanged

    End Sub

    Private Sub TXTGUESTNAME_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTGUESTNAME.KeyDown
        If e.KeyCode = Keys.Enter Then
            If (TXTGUESTNAME.Text) = "" Then
                TXTGUESTNAME.Focus()
            Else
                'TXT_CELLNO.Focus()
                If Cmb_StatusType.Enabled = True Then
                    Cmb_StatusType.Focus()
                Else
                    Txt_Add1.Focus()
                End If

            End If
        End If
    End Sub

    Private Sub TXTGUESTNAME_ReadOnlyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTGUESTNAME.ReadOnlyChanged

    End Sub

    Private Sub TXTGUESTCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTGUESTNAME.TextChanged

    End Sub

    Private Sub TXTGUESTCODE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTGUESTNAME.KeyPress
        If Asc(e.KeyChar) = 13 Then
            '  TxtNVOCCUPANCY.Focus()
            If (TXTGUESTNAME.Text) = "" Then
                TXTGUESTNAME.Focus()
            Else
                'TXT_CELLNO.Focus()
                Cmb_StatusType.Focus()
            End If
        End If

    End Sub

    Private Sub SSGRID_BOOKING_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID_BOOKING.KeyDownEvent
        'Private Sub SSGRID_BOOKING_KeyDownEvent1(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID_BOOKING.KeyDownEvent
        Dim PDATE As String
        Dim ITEMCODE, hallcode, WeekDay As String
        Dim d1, d2 As Date
        Dim TAXAMOUNT, perc, taxpercent, rate, halltotalamount, dbldicountAmount As Double
        Dim ftime, CNT, I, HALLTAXAMOUNT As Integer
        Dim time1, time2 As DateTime
        'KGA BOOKING
        Try
            WeekDay = Dtppartydate.Value.DayOfWeek.ToString
            If e.keyCode = Keys.Enter Then
                With SSGRID_BOOKING
                    duplicate()

                    I = .ActiveRow
                    If .ActiveCol = 5 Then
                        .Col = 1
                        .Row = I
                        ssql = " SELECT PARTYDATE,FROMTIME,TOTIME FROM PARTY_TEMPBOOKING "
                        ssql = ssql & " WHERE PARTYDATE = '" & Format(Dtppartydate.Value, "dd/MMM/yyyy") & "' AND " & Math.Round(Val(.Text)) & " BETWEEN FROMTIME AND TOTIME AND SNO<>" & .ActiveRow
                        DT = gconnection.GetValues(ssql)

                        If DT.Rows.Count > 0 Then
                            MessageBox.Show("DATE TIME CAN NOT BE SAME", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            .SetActiveCell(2, I)
                            .Text = ""
                            .Focus()
                        End If

                        If Val(.Text) > 0 Then
                            ssql = "SELECT BOOKINGNO,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGSTATUS"
                            ssql = ssql & " WHERE PARTYDATE='" & Format(Dtppartydate.Value, "dd/MMM/yyyy") & "' AND " & Math.Round(Val(.Text)) & " BETWEEN FROMTIME AND TOTIME  AND HALLCODE='" & txthallcode.Text & "' And Bookingno<>" & TXTBOOKINGNO.Text
                            DT = gconnection.GetValues(ssql)
                            If DT.Rows.Count > 0 Then
                                MessageBox.Show("ALREADY BOOKED,PLEASE CHECK THE HALLSTATUS", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                .Text = ""
                                .Focus()
                            Else
                                .SetActiveCell(3, I)
                            End If
                        Else
                            .SetActiveCell(2, I)
                        End If

                    ElseIf .ActiveCol = 6 Then
                        .Col = 1
                        .Row = I
                        'If Len(.Text) > 0 Then
                        '    PDATE = IIf(Len(.Text) > 0, Format(CDate(.Text), "dd/MMM/yyyy"), "")
                        'Else
                        '    PDATE = ""
                        'End If
                        .Col = 2
                        .Row = I
                        ftime = Val(.Text)

                        .Col = 3
                        .Row = I

                        ssql = " SELECT PARTYDATE,FROMTIME,TOTIME FROM PARTY_TEMPBOOKING "
                        ssql = ssql & " WHERE PARTYDATE='" & Format(Dtppartydate.Value, "dd/MMM/yyyy") & "' AND " & Math.Round(Val(.Text)) & " BETWEEN FROMTIME AND TOTIME AND SNO<>" & .ActiveRow
                        DT = gconnection.GetValues(ssql)

                        If DT.Rows.Count > 0 Then
                            MessageBox.Show("DATE TIME CAN NOT BE SAME", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                            .SetActiveCell(3, I)
                            .Text = ""
                            .Focus()
                        End If

                        If Val(.Text) > 0 Then
                            ssql = "SELECT BOOKINGNO,PARTYDATE,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGSTATUS"
                            ssql = ssql & " WHERE PARTYDATE='" & Format(Dtppartydate.Value, "dd/MMM/yyyy") & "' AND " & Math.Round(Val(.Text)) & " BETWEEN FROMTIME AND TOTIME  AND HALLCODE='" & txthallcode.Text & "' And Bookingno<>" & TXTBOOKINGNO.Text
                            DT = gconnection.GetValues(ssql)
                            If DT.Rows.Count > 0 Then
                                MessageBox.Show("ALREAD BOOKED,PLEASE CHECK THE HALLSTATUS", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                .SetActiveCell(3, I)
                                .Text = ""
                                .Focus()
                            Else
                                If Val(.Text) < ftime Then
                                    MessageBox.Show("ToTime cannot be Less than To Fromtime", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                    .Text = ""
                                    .SetActiveCell(3, I)
                                    .Focus()
                                Else
                                    .SetActiveCell(4, I)
                                End If
                            End If
                        End If
                    ElseIf .ActiveCol = 1 Then
                        .Col = 1
                        .Row = .ActiveRow
                        If Trim(.Text) <> "" Then
                            hallcode = Trim(.Text)
                            ssql = "SELECT * FROM PARTY_VIEW_HALLMASTER WHERE HALLTYPECODE='" & Trim(.Text) & "' and freeze<>'y' and H_Type = '" & Trim(Cmb_DayBasis.Text) & "'"
                            gconnection.getDataSet(ssql, "HAL")
                            If gdataset.Tables("HAL").Rows.Count > 0 Then
                                For CNT = 0 To gdataset.Tables("HAL").Rows.Count - 1
                                    .Col = 2
                                    .Row = I
                                    .Text = gdataset.Tables("HAL").Rows(CNT).Item("HALLTYPEDESC")
                                    .Col = 3
                                    .Row = I
                                    .Text = gdataset.Tables("HAL").Rows(CNT).Item("PCODE")
                                    .Col = 4
                                    .Row = I
                                    .Text = gdataset.Tables("HAL").Rows(CNT).Item("PDESC")
                                    .Col = 5
                                    .Row = I

                                    'EXISTING BOOKING CHECKED
                                    .Text = Format(CDate(gdataset.Tables("HAL").Rows(CNT).Item("FROMTIME")), "HH:mm")
                                    ssql = "SELECT BOOKINGNO,PARTYDATE,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGDETAILS"
                                    ssql = ssql & " WHERE  '" & Format(Dtppartydate.Value, "yyyy-MM-dd") & "' BETWEEN cast(convert(varchar(11),PARTYDATE,106)as datetime) AND cast(convert(varchar(11),PARTYTODATE,106)as datetime) AND '" & (.Text) & "' BETWEEN FROMTIME AND TOTIME  AND HALLCODE='" & hallcode & "' AND SUPERSET <> 'Y' And Bookingno<>" & TXTBOOKINGNO.Text
                                    DT = gconnection.GetValues(ssql)
                                    If DT.Rows.Count > 0 Then
                                        MessageBox.Show("ALREAD BOOKED,PLEASE CHECK THE HALLSTATUS", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                        Me.Cmd_Add1.Enabled = False
                                    End If
                                    .Col = 6
                                    .Row = I
                                    .Text = Format(CDate(gdataset.Tables("HAL").Rows(CNT).Item("totime")), "HH:mm")
                                    ssql = "SELECT BOOKINGNO,PARTYDATE,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGDETAILS"
                                    ssql = ssql & " WHERE  cast(convert(varchar(11),PARTYDATE,106)as datetime)='" & Format(Dtppartydate.Value, "yyyy-MM-dd") & "' AND '" & (.Text) & "' BETWEEN FROMTIME AND TOTIME  AND HALLCODE='" & hallcode & "' AND SUPERSET <> 'Y' And Bookingno<>" & TXTBOOKINGNO.Text
                                    DT = gconnection.GetValues(ssql)
                                    If DT.Rows.Count > 0 Then
                                        MessageBox.Show("ALREAD BOOKED,PLEASE CHECK THE HALLSTATUS", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                                        Me.Cmd_Add1.Enabled = False
                                    End If

                                    .Col = 7
                                    .Row = I
                                    ssql = "SELECT * FROM PARTY_HOLIDAYMASTER WHERE DATES = '" & Format(Dtppartydate.Value, "dd-MMM-yyyy") & "'"
                                    gconnection.getDataSet(ssql, "HDay")
                                    If gdataset.Tables("HDay").Rows.Count > 0 Then
                                        .Text = gdataset.Tables("HAL").Rows(CNT).Item("HoliDayRate")
                                    Else
                                        If WeekDay = "Saturday" Or WeekDay = "Sunday" Then
                                            .Text = gdataset.Tables("HAL").Rows(CNT).Item("WeekendRate")
                                        Else
                                            .Text = gdataset.Tables("HAL").Rows(CNT).Item("WDayRate")
                                        End If
                                    End If

                                    '.Text = gdataset.Tables("HAL").Rows(CNT).Item("RATE")

                                    .Col = 11
                                    .Row = I
                                    .Text = gdataset.Tables("HAL").Rows(CNT).Item("SEDEPOSIT")

                                    .Col = 8
                                    .Row = I
                                    .Text = gdataset.Tables("HAL").Rows(CNT).Item("taxtype")
                                    '    .Col = 9
                                    '    .Row = I
                                    '    .Text = gdataset.Tables("HAL").Rows(CNT).Item("RATE") * gdataset.Tables("tax").Rows(0).Item("perc") / 100
                                    '    '.Col = 7
                                    '    '.Row = I
                                    '    .Col = 10
                                    '    .Row = I
                                    '    .Text = gdataset.Tables("HAL").Rows(CNT).Item("RATE") + (gdataset.Tables("HAL").Rows(CNT).Item("RATE") * gdataset.Tables("tax").Rows(0).Item("perc") / 100)
                                    .Col = 12
                                    .Row = I
                                    .Text = gdataset.Tables("HAL").Rows(CNT).Item("H_Type")
                                    .Col = 13
                                    .Row = I
                                    .Text = Format(Dtppartydate.Value, "dd/MM/yy")
                                    If gdataset.Tables("HAL").Rows(CNT).Item("H_Type") = "Day" Then
                                        .Lock = False
                                    Else
                                        .Lock = True
                                    End If
                                    .Col = 14
                                    .Row = I
                                    .Text = gdataset.Tables("HAL").Rows(CNT).Item("HKStaff")
                                    .Col = 15
                                    .Row = I
                                    .Text = gdataset.Tables("HAL").Rows(CNT).Item("SecurityStaff")
                                    .Col = 16
                                    .Row = I
                                    .Text = gdataset.Tables("HAL").Rows(CNT).Item("HKStaff") * gdataset.Tables("HAL").Rows(CNT).Item("HKStaffRate")
                                    .Col = 17
                                    .Row = I
                                    .Text = gdataset.Tables("HAL").Rows(CNT).Item("SecurityStaff") * gdataset.Tables("HAL").Rows(CNT).Item("SPRate")
                                    .Col = 18
                                    .Row = I
                                    .Text = gdataset.Tables("HAL").Rows(CNT).Item("SuperHallCode")

                                    Call calculate()
                                    duplicate()

                                Next
                                .SetActiveCell(1, I + 1)
                                .Focus()
                            End If
                        Else
                            Call FILLHALLDETAILS()
                            Call calculate()
                            .SetActiveCell(1, I + 1)
                        End If
                    ElseIf .ActiveCol = 8 Then
                        .Col = 8
                        .Row = .ActiveRow
                        If Trim(.Text) = "" Then
                            Call ARRCHGCODEHELP()
                        Else
                            ssql = "SELECT CHARGECODE,CHARGEDESC FROM CHARGEMASTER WHERE ISNULL(FREEZE,'') <> 'Y' AND ISNULL(RATE,0) = 0 AND ISNULL(CHARGECODE,'') ='" & Trim(.Text) & "' AND ISNULL(TAXTYPECODE,'') <> ''"
                            DT = gconnection.GetValues(ssql)
                            If DT.Rows.Count > 0 Then
                                .Col = 8
                                .Row = .ActiveRow
                                .Lock = False
                                .Text = ""
                                .Text = Trim(DT.Rows(0).Item("CHARGECODE"))
                            End If
                        End If
                        Call calculate()
                    ElseIf .ActiveCol = 3 Then
                        .Col = 3
                        .Row = .ActiveRow
                        ssql = "SELECT * FROM PARTY_HOLIDAYMASTER WHERE DATES = '" & Format(Dtppartydate.Value, "dd-MMM-yyyy") & "'"
                        gconnection.getDataSet(ssql, "HDay")
                        If gdataset.Tables("HDay").Rows.Count > 0 Then
                            ssql = " SELECT ISNULL(HALLTYPEdesc,'') AS HALLTYPEdesc,ISNULL(HoliDayRate,0) AS HALLAMOUNT FROM "
                        Else
                            If WeekDay = "Saturday" Or WeekDay = "Sunday" Then
                                '.Text = gdataset.Tables("HAL").Rows(CNT).Item("WeekendRate")
                                ssql = " SELECT ISNULL(HALLTYPEdesc,'') AS HALLTYPEdesc,ISNULL(WeekendRate,0) AS HALLAMOUNT FROM "
                            Else
                                '.Text = gdataset.Tables("HAL").Rows(CNT).Item("WDayRate")
                                ssql = " SELECT ISNULL(HALLTYPEdesc,'') AS HALLTYPEdesc,ISNULL(WDayRate,0) AS HALLAMOUNT FROM "
                            End If
                        End If
                        'ssql = " SELECT ISNULL(HALLTYPEdesc,'') AS HALLTYPEdesc,ISNULL(RATE,0) AS HALLAMOUNT FROM "
                        ssql = ssql & " PARTY_VIEW_HALLMASTER WHERE PCODE='" & Trim(.Text) & "' AND HALLTYPECODE='" & Trim(txthallcode.Text) & "' and freeze<>'y' and H_Type = '" & Trim(Cmb_DayBasis.Text) & "'"
                        DT = gconnection.GetValues(ssql)
                        If DT.Rows.Count = 0 Then
                            .Text = ""
                            HALLSTATUSHELP()
                        Else
                            '.Col = 4
                            '.Row = .ActiveRow
                            '.Text = DT.Rows(0).Item("HALLTYPEDESC")
                            .Col = 5
                            .Row = .ActiveRow
                            .Text = 0
                            .Text = DT.Rows(0).Item("HALLAMOUNT")
                            'Call TEMPBOOKINGDETAILS()
                            .SetActiveCell(1, .ActiveRow + 1)
                        End If
                    ElseIf .ActiveCol = 7 Then
                        Call calculate()
                    ElseIf .ActiveCol = 8 Then
                        Call calculate()
                    End If
                End With
            End If
            If e.keyCode = Keys.F3 Then
                With SSGRID_BOOKING
                    .Row = .ActiveRow
                    .DeleteRows(.ActiveRow, 1)
                    If .ActiveRow <= 1 Then
                        .SetActiveCell(1, .ActiveRow)
                    Else
                        .SetActiveCell(1, .ActiveRow - 1)
                    End If
                    TXT_TOTAMT.Text = Format(Math.Round(TOT_AMT23(SSGRID_BOOKING), 0), "0.00")
                    Me.TXTB_BAMOUNT.Text = Format(Val(TXT_TOTAMT.Text) - Format(Val(dbldicountAmount)), "0.00")
                End With
                'Call TEMPBOOKINGDETAILS()
            End If
            If e.keyCode = Keys.F4 Then
                HALLSTATUSHELP()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try


    End Sub
    Private Function ARRCHGCODEHELP()
        Dim OP As String
        Dim vform As New LIST_OPERATION1
        If SSGRID_BOOKING.ActiveCol = 8 Then
            gSQLString = " SELECT CHARGECODE,CHARGEDESC FROM CHARGEMASTER"
            If Trim(Search) = "" Then
                M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y' AND ISNULL(RATE,0) = 0 AND ISNULL(TAXTYPECODE,'') <> ''"
            Else
                M_WhereCondition = " WHERE ISNULL(FREEZE,'') <> 'Y' AND ISNULL(RATE,0) = 0 AND ISNULL(TAXTYPECODE,'') <> ''"
            End If
            vform.Field = "CHARGECODE,CHARGEDESC"
            ' vform.vFormatstring = "ITEMCODE                      |DESCRIPTION                |UOM              | RATE   "
            vform.vCaption = "CHARGEMASTER HELP"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            'vform.Keypos3 = 3
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                With SSGRID_BOOKING
                    .Col = 8
                    .Text = ""
                    .Lock = False
                    .Text = Trim(vform.keyfield & "")
                End With
            End If
        Else
            'SSGRID_ARRANGE.SetActiveCell(1, SSGRID_ARRANGE.ActiveRow + 1)
            vform.Close()
            vform = Nothing
        End If
    End Function
    Public Sub duplicate()
        Dim scode, sdesc, pcode, pdesc
        Dim c, z, d As Integer
        boolchk = False
        If SSGRID_BOOKING.DataRowCnt > 1 Then
            For i = 1 To SSGRID_BOOKING.DataRowCnt
                SSGRID_BOOKING.Row = i
                SSGRID_BOOKING.Col = 1
                scode = SSGRID_BOOKING.Text

                SSGRID_BOOKING.Row = i
                SSGRID_BOOKING.Col = 3
                pcode = SSGRID_BOOKING.Text

                c = 0
                d = 0
                For j = 1 To SSGRID_BOOKING.DataRowCnt
                    SSGRID_BOOKING.Row = j
                    SSGRID_BOOKING.Col = 1
                    sdesc = SSGRID_BOOKING.Text
                    If scode = sdesc Then
                        c = c + 1
                    End If
                Next j

                For z = 1 To SSGRID_BOOKING.DataRowCnt
                    SSGRID_BOOKING.Row = z
                    SSGRID_BOOKING.Col = 3
                    pdesc = SSGRID_BOOKING.Text
                    If pcode = pdesc Then
                        d = d + 1
                    End If
                Next z

                If c > 1 Then
                    If d > 1 Then
                        If MsgBox("Duplication Session  Not Allowed...." & scode, MsgBoxStyle.OkCancel + MsgBoxStyle.DefaultButton1, "DELETE DUPLICATE") = MsgBoxResult.Ok Then
                            SSGRID_BOOKING.Row = SSGRID_BOOKING.ActiveRow
                            'SSGRID_MENU.ClearRange(1, I, 15, I, True)
                            SSGRID_BOOKING.ClearRange(1, SSGRID_BOOKING.ActiveRow, 15, SSGRID_BOOKING.ActiveRow, True)

                            SSGRID_BOOKING.DeleteRows(SSGRID_BOOKING.ActiveRow, 1)
                            SSGRID_BOOKING.Row = SSGRID_BOOKING.ActiveRow
                            SSGRID_BOOKING.Col = 1
                            SSGRID_BOOKING.Lock = False
                            'SSGRID.Col = 2
                            'SSGRID.Lock = False
                            'SSGRID.Col = 3
                            'SSGRID.Lock = False
                            'SSGRID.Col = 4
                            'SSGRID.Lock = False
                            'SSGRID.Col = 5
                            'SSGRID.Lock = False
                            SSGRID_BOOKING.SetActiveCell(1, SSGRID_BOOKING.ActiveRow - 1)
                        Else
                            SSGRID_BOOKING.SetActiveCell(1, SSGRID_BOOKING.ActiveRow)
                            SSGRID_BOOKING.Focus()
                        End If
                    End If
                End If
            Next
        End If
        boolchk = True
    End Sub

    Private Sub SSGRID_BOOKING_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles SSGRID_BOOKING.Leave

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub txtmname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmname.TextChanged

    End Sub


    Private Sub Btn_Hallres_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Hallres.Click
        'If RDBPARTYBOOKINGTIME.Checked = True Then
        GBHALLBOOKING.Visible = True
        GBHALLSTATUS.Visible = False
        GRPRECEIPT.Visible = False
        SSGRID_BOOKING.Focus()
        'SSGRID_BOOKING.SetActiveCell(1, 1)
        '  End If
    End Sub

    Private Sub Btn_Hallava_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Hallava.Click
        '   If RDBHALLAVAILABLITY.Checked = True Then
        GBHALLBOOKING.Visible = False
        GBHALLSTATUS.Visible = True
        GRPRECEIPT.Visible = False
        ' ''TXT_DISAMT.Visible = False
        ' ''TXT_TOTAMT.Visible = False
        ' ''TXTB_BAMOUNT.Visible = False
        SSgrid.Focus()
        Call Hall_Status()
        ' Call Hall_Status1()
        'SSgrid.SetActiveCell(1, 1)
        '  End If
    End Sub
    Private Sub Hall_Status1()
        'PRIVATE SUB STATUSHALL
        Dim i, j, k, L As Integer
        Dim ssql, hallcode, PCODE, tspilt(), SSQL2 As String
        Try
            Dim dno, ddiff As Integer
            Dim dd, dd1 As Date
            Dim dt As New DataTable
            Dim dt2 As New DataTable
            Dim DT1 As New DataTable
            Dim DT3 As New DataTable
            Dim II As Integer

            ssql = " DELETE FROM PARTY_HallStatus"
            '            gconnection.dataOperation(6, ssql, "DEL")
            gconnection.GetValues(ssql)
            'dt = vconn.GetValues(ssql)
            dd = Dtppartydate.Value

            '  ddiff = DateDiff(DateInterval.Day, Dtpbookfromdate.Value, dtpbooktodate.Value)
            dd = DateAdd(DateInterval.Day, -1, Dtppartydate.Value)

            For i = 0 To ddiff
                dd = dd.AddDays(+1)
                For II = 0 To SSGRID_BOOKING.DataRowCnt - 1
                    'tspilt = Split(chklist_Rooms.CheckedItems(II), "-->")
                    hallcode = tspilt(0)
                    PCODE = tspilt(4)

                    hallcode = Trim(txthallcode.Text)

                    ssql = " SELECT FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET WHERE "
                    ssql = ssql & " CAST(Convert(varchar(11),PARTYDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                    ssql = ssql & " and hallcode='" & hallcode & "' and isnull(freeze,'')<>'Y' AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                    ' End If
                    dt = gconnection.GetValues(ssql)

                    SSQL2 = "SELECT * FROM party_hallstatusdetails WHERE "
                    SSQL2 = SSQL2 & " CAST(Convert(varchar(11),PARTYDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                    SSQL2 = SSQL2 & " and hallcode='" & hallcode & "'AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                    DT3 = gconnection.GetValues(SSQL2)

                    If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
                        If dt.Rows.Count > 0 Then
                            ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                            ssql = ssql & "CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                            ssql = ssql & " and hallcode='" & hallcode & "'"
                            dt2 = gconnection.GetValues(ssql)
                            If dt2.Rows.Count <= 0 Then
                                ssql = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
                                ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                                gconnection.ExcuteStoreProcedure(ssql)
                            End If
                            For j = 0 To dt.Rows.Count - 1
                                For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                    ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='B'"
                                    ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                    ssql = ssql & " and hallcode='" & hallcode & "'"

                                    gconnection.ExcuteStoreProcedure(ssql)
                                Next
                                ssql = ""
                            Next
                            'If DT3.Rows.Count > 0 Then
                            '    For j = 0 To dt.Rows.Count - 1
                            '        For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                            '            ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='C'"
                            '            ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                            '            ssql = ssql & " and hallcode='" & hallcode & "'"

                            '            gconnection.ExcuteStoreProcedure(ssql)
                            '        Next
                            '        ssql = ""
                            '    Next
                            'End If
                        Else
                            ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                            ssql = ssql & " CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                            ssql = ssql & " and hallcode='" & hallcode & "'"
                            dt2 = gconnection.GetValues(ssql)
                            If dt2.Rows.Count <= 0 Then
                                ssql = "Insert Into PARTY_HallStatus(HALLCODE,Bookingdate)"
                                ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                                gconnection.ExcuteStoreProcedure(ssql)
                            End If
                        End If
                        ''FOR ASCA SHOWING THE BOOKED OR CONFORMED 

                    Else
                        If dt.Rows.Count > 0 Then
                            ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                            ssql = ssql & "CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                            ssql = ssql & " and hallcode='" & hallcode & "'"
                            dt2 = gconnection.GetValues(ssql)
                            If dt2.Rows.Count <= 0 Then
                                ssql = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
                                ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                                gconnection.ExcuteStoreProcedure(ssql)
                            End If
                            For j = 0 To dt.Rows.Count - 1
                                For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                    ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='B'"
                                    ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                    ssql = ssql & " and hallcode='" & hallcode & "'"

                                    gconnection.ExcuteStoreProcedure(ssql)
                                Next
                                ssql = ""
                            Next
                            If DT3.Rows.Count > 0 Then
                                For j = 0 To dt.Rows.Count - 1
                                    For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                        ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='C'"
                                        ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                                        ssql = ssql & " and hallcode='" & hallcode & "'"

                                        gconnection.ExcuteStoreProcedure(ssql)
                                    Next
                                    ssql = ""
                                Next
                            End If
                        Else
                            ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                            ssql = ssql & " CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                            ssql = ssql & " and hallcode='" & hallcode & "'"
                            dt2 = gconnection.GetValues(ssql)
                            If dt2.Rows.Count <= 0 Then
                                ssql = "Insert Into PARTY_HallStatus(HALLCODE,Bookingdate)"
                                ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                                gconnection.ExcuteStoreProcedure(ssql)
                            End If
                        End If
                    End If
                Next
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Btn_recdet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_recdet.Click
        ' If RDBRECEIPTENTRY.Checked = True Then
        GBHALLBOOKING.Visible = False
        GBHALLSTATUS.Visible = False
        GRPRECEIPT.Visible = True
        ssgrid_Receipt.Focus()
        'ssgrid_Receipt.SetActiveCell(1, 1)
        'End If
        ' '' ''ssgrid_Receipt.Enabled = False
        ' '' ''TXT_DISAMT.Visible = False
        ' '' ''TXT_TOTAMT.Visible = False
        ' '' ''TXTB_BAMOUNT.Visible = False
        sqlstring = "SELECT * from partyrec_advance WHERE bookno='" & Me.TXTBOOKINGNO.Text & "'"
        DT = gconnection.GetValues(sqlstring)
        If DT.Rows.Count > 0 Then
            ssgrid_Receipt.ClearRange(-1, -1, 1, 1, True)
            With ssgrid_Receipt
                For i = 0 To DT.Rows.Count - 1
                    .Col = 1
                    .Row = i + 1
                    .Text = DT.Rows(i).Item("PARTYRECEIPTNO")
                    .Col = 2
                    .Row = i + 1
                    '.Text = Format(DT.Rows(i).Item("PARTYRECEIPTDATE"), "dd/MM/yy")
                    .Text = Format(CDate(Trim(DT.Rows(i).Item("PARTYRECEIPTDATE"))), "dd/MM/yyyy")
                    'DTPVOUCHERDATE.Value = Format(gdataset.Tables("HallStatus").Rows(0).Item("receiptdate"), "dd/MM/yyyy")
                    .Col = 3
                    .Row = i + 1
                    .Text = DT.Rows(i).Item("amount")
                    .Col = 4
                    .Row = i + 1
                    .Text = DT.Rows(i).Item("Receiptheaddesc")
                Next
            End With
        End If
    End Sub

    Private Sub cmd_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Freeze2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze2.Click

    End Sub

    Private Sub cmd_freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_freeze.Click
        Dim Update(0) As String
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If txt_res.Text = "" Then
            MsgBox("PLEASE ENTER THE REASON......", MsgBoxStyle.OkCancel, "Exit")
            txt_res.Focus()
            Exit Sub
        End If

        If Mid(Me.cmd_freeze.Text, 1, 1) = "F" Then
            'If MsgBox("PLEASE ENTER THE REASON......", MsgBoxStyle.OKCancel, "Exit") = MsgBoxResult.OK Then
            '    lbl_reson.Visible = True
            '    txt_res.Visible = True


            'End If
            sqlstring = "UPDATE  party_hdr "
            sqlstring = sqlstring & " SET Void= 'Y',AddUserid='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "', freereason='" & Trim(txt_res.Text) & "'"
            sqlstring = sqlstring & " WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            sqlstring = "UPDATE  party_hallbooking_hdr "
            sqlstring = sqlstring & " SET Void= 'Y',FREERESON='" & txt_res.Text & "',AddUserid='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "', freereson='" & Trim(txt_res.Text) & "'"
            sqlstring = sqlstring & " WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            sqlstring = "UPDATE  party_hallbooking_det "
            sqlstring = sqlstring & " SET Void= 'Y',AddUserid='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            Dim HRS, AMT, OCC As Integer
            Dim TRATE, CANRATE, CANAMT, CANHEAD, CANFROM, CANTO, HRS1, HRS2, PERC As Double
            ssql = "SELECT H.BOOKINGDATE,H.PARTYDATE,ISNULL(H.TOTALAMOUNT,0) AS TOTALAMOUNT "
            ssql = ssql & " FROM PARTY_HALLBOOKING_HDR H"
            ssql = ssql & " WHERE H.BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & "  "
            ssql = ssql & " GROUP BY H.PARTYDATE,H.BOOKINGDATE,H.TOTALAMOUNT"
            gconnection.getDataSet(ssql, "book")

            ssql = "SELECT BOOKINGDATE,PARTYDATE,ISNULL(OCCUPANCY,0)AS OCCUPANCY,ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT "
            ssql = ssql & " FROM PARTY_HALLBOOKING_HDR "
            ssql = ssql & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' "
            ssql = ssql & " GROUP BY PARTYDATE,BOOKINGDATE,OCCUPANCY,TOTALAMOUNT"
            gconnection.getDataSet(ssql, "TOT")

            If gdataset.Tables("book").Rows.Count > 0 Then
                HRS = DateDiff(DateInterval.Hour, Now(), gdataset.Tables("book").Rows(0).Item("PARTYDATE"))
                AMT = gdataset.Tables("BOOK").Rows(0).Item("TOTALAMOUNT")
            Else
                HRS = DateDiff(DateInterval.Hour, Now(), gdataset.Tables("TOT").Rows(0).Item("PARTYDATE"))
                AMT = gdataset.Tables("TOT").Rows(0).Item("TOTALAMOUNT")
            End If
            ssql = "SELECT ISNULL(CANCELFROM,0)AS CANCELFROM,ISNULL(CANCELTO,0)AS CANCELTO,ISNULL(CANCEL_AMT_PER,0)AS PERAMT,ISNULL(CANCEL_AMT_HEAD,0)AS HEADAMT,ISNULL(FIXEDAMOUNT,0)AS FIXAMT FROM PARTY_CANCELLATIONMASTER WHERE " & Val(HRS) & " BETWEEN CANCELFROM AND CANCELTO "
            gconnection.getDataSet(ssql, "CANCEL")
            If gdataset.Tables("CANCEL").Rows.Count > 0 Then
                PERC = gdataset.Tables("CANCEL").Rows(0).Item("PERAMT")
                CANHEAD = gdataset.Tables("CANCEL").Rows(0).Item("HEADAMT")
                CANRATE = gdataset.Tables("CANCEL").Rows(0).Item("FIXAMT")
                CANFROM = gdataset.Tables("CANCEL").Rows(0).Item("CANCELFROM")
                CANTO = gdataset.Tables("CANCEL").Rows(0).Item("CANCELTO")
                CANAMT = ((((Val(OCC) * TRATE) + (Val(OCC) * Val(CANHEAD)) + Val(CANRATE) + Val(AMT)) * PERC) / 100)
            End If

            'ssql = " UPDATE  PARTY_HDR SET FREEZE='Y',CANCELAMOUNT=" & Val(CANAMT) & ",FROMHRS=" & Val(CANFROM) & ",TOHRS=" & Val(CANTO) & ",CANCELDATE='" & Format(DateTime.Now, "dd/MMM/yyyy hh:mm:ss") & "' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            'insert(insert.Length - 1) = ssql
            'ReDim Preserve insert(insert.Length)

            ssql = " UPDATE  PARTY_HALLBOOKING_HDR SET CANCELFLAG='Y',FREERESON='" & txt_res.Text & "',FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            INSERT(INSERT.Length - 1) = ssql
            ReDim Preserve INSERT(INSERT.Length)

            ssql = " UPDATE  PARTY_HALLBOOKING_DET SET FREEZE='Y',CANCELAMOUNT=" & Val(CANAMT) & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            INSERT(INSERT.Length - 1) = ssql
            ReDim Preserve INSERT(INSERT.Length)

            ssql = " UPDATE PARTY_RECEIPT SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            INSERT(INSERT.Length - 1) = ssql
            ReDim Preserve INSERT(INSERT.Length)


            sqlstring = "UPDATE party_receipt_DET SET Freeze= 'Y' Where  PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "' "
            INSERT(INSERT.Length - 1) = sqlstring
            ReDim Preserve INSERT(INSERT.Length)

            sqlstring = "UPDATE party_receipt_hdr SET Freeze= 'Y',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "' Where  PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "'"
            INSERT(INSERT.Length - 1) = sqlstring
            ReDim Preserve INSERT(INSERT.Length)

            gconnection.dataOperation1(1, INSERT)

            'gconnection.dataOperation1(2, INSERT)

            If MsgBox("Do you want windows print to Annexure........", MsgBoxStyle.OkCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then
                'Call hallbilling()
            Else
                Call CANCELWINDOWS()
            End If


            Call TEMPBOOKINGDETAILS()
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"

        Else
            sqlstring = "UPDATE  party_hdr "
            sqlstring = sqlstring & " SET Void= 'N',AddUserid='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "' "
            sqlstring = sqlstring & " WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            sqlstring = "UPDATE  party_hallbooking_hdr "
            sqlstring = sqlstring & " SET Void= 'N',FREERESON='" & txt_res.Text & "',AddUserid='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            sqlstring = "UPDATE  party_hallbooking_det "
            sqlstring = sqlstring & " SET Void= 'N',AddUserid='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            sqlstring = "UPDATE party_receipt_DET SET Freeze= 'Y' Where  PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "' "
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            sqlstring = "UPDATE party_receipt_hdr SET Freeze= 'Y',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "' Where  PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "'"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = sqlstring

            'gconnection.MoreTrans(Update)
            Dim HRS, AMT, OCC As Integer
            Dim TRATE, CANRATE, CANAMT, CANHEAD, CANFROM, CANTO, HRS1, HRS2, PERC As Double
            ssql = "SELECT H.BOOKINGDATE,H.PARTYDATE,ISNULL(H.TOTALAMOUNT,0) AS TOTALAMOUNT "
            ssql = ssql & " FROM PARTY_HALLBOOKING_HDR H"
            ssql = ssql & " WHERE H.BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & "  "
            ssql = ssql & " GROUP BY H.PARTYDATE,H.BOOKINGDATE,H.TOTALAMOUNT"
            gconnection.getDataSet(ssql, "book")

            ssql = "SELECT BOOKINGDATE,PARTYDATE,ISNULL(OCCUPANCY,0)AS OCCUPANCY,ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT "
            ssql = ssql & " FROM PARTY_HALLBOOKING_HDR "
            ssql = ssql & " WHERE BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' "
            ssql = ssql & " GROUP BY PARTYDATE,BOOKINGDATE,OCCUPANCY,TOTALAMOUNT"
            gconnection.getDataSet(ssql, "TOT")

            If gdataset.Tables("book").Rows.Count > 0 Then
                HRS = DateDiff(DateInterval.Hour, gdataset.Tables("book").Rows(0).Item("PARTYDATE"), Now())
                AMT = gdataset.Tables("BOOK").Rows(0).Item("TOTALAMOUNT")
            Else
                HRS = DateDiff(DateInterval.Hour, Now(), gdataset.Tables("TOT").Rows(0).Item("PARTYDATE"))
                AMT = gdataset.Tables("TOT").Rows(0).Item("TOTALAMOUNT")
            End If
            ssql = "SELECT ISNULL(CANCELFROM,0)AS CANCELFROM,ISNULL(CANCELTO,0)AS CANCELTO,ISNULL(CANCEL_AMT_PER,0)AS PERAMT,ISNULL(CANCEL_AMT_HEAD,0)AS HEADAMT,ISNULL(FIXEDAMOUNT,0)AS FIXAMT FROM PARTY_CANCELLATIONMASTER WHERE " & Val(HRS) & " BETWEEN CANCELFROM AND CANCELTO "
            gconnection.getDataSet(ssql, "CANCEL")
            If gdataset.Tables("CANCEL").Rows.Count > 0 Then
                PERC = gdataset.Tables("CANCEL").Rows(0).Item("PERAMT")
                CANHEAD = gdataset.Tables("CANCEL").Rows(0).Item("HEADAMT")
                CANRATE = gdataset.Tables("CANCEL").Rows(0).Item("FIXAMT")
                CANFROM = gdataset.Tables("CANCEL").Rows(0).Item("CANCELFROM")
                CANTO = gdataset.Tables("CANCEL").Rows(0).Item("CANCELTO")
                CANAMT = ((((Val(OCC) * TRATE) + (Val(OCC) * Val(CANHEAD)) + Val(CANRATE) + Val(AMT)) * PERC) / 100)
            End If

            'ssql = " UPDATE  PARTY_HDR SET FREEZE='Y',CANCELAMOUNT=" & Val(CANAMT) & ",FROMHRS=" & Val(CANFROM) & ",TOHRS=" & Val(CANTO) & ",CANCELDATE='" & Format(DateTime.Now, "dd/MMM/yyyy hh:mm:ss") & "' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            'insert(insert.Length - 1) = ssql
            'ReDim Preserve insert(insert.Length)
            ''LOGAN CHANGED ON 03DEC12
            'START
            'ssql = " UPDATE  PARTY_HALLBOOKING_HDR SET CANCELFLAG='Y',FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            'INSERT(INSERT.Length - 1) = ssql
            'ReDim Preserve INSERT(INSERT.Length)

            'ssql = " UPDATE  PARTY_HALLBOOKING_DET SET FREEZE='Y',CANCELAMOUNT=" & Val(CANAMT) & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            'INSERT(INSERT.Length - 1) = ssql
            'ReDim Preserve INSERT(INSERT.Length)

            'ssql = " UPDATE PARTY_RECEIPT SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            'INSERT(INSERT.Length - 1) = ssql
            'ReDim Preserve INSERT(INSERT.Length)
            'gconnection.dataOperation1(1, INSERT)

            'gconnection.dataOperation1(2, insert)

            'END
            If MsgBox("Do you want windows print to Annexure........", MsgBoxStyle.OkCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then
                'Call hallbilling()
            Else
                Call CANCELWINDOWS()
            End If


            Call TEMPBOOKINGDETAILS()
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Try
            Dim strsql, halltype, insert(0), HALLCODE As String
            Dim RECNO, RECTYPE As String
            Dim RECDATE As Date
            Dim ftime, ttime As String
            Dim PDATE As String
            Dim ITEMCODE As String
            Dim d1, d2 As Date
            Dim TAXAMOUNT, perc, taxpercent, rate, drate, halltotalamount, dbldicountAmount As Double
            Dim vat, stax As Double
            Dim CNT, I As Integer
            Dim time1, time2 As DateTime

            Dim hallrate As String
            Dim TAXCODE, ItemTypeCode As String
            Dim HALLTYPE1, FROMTIME, TOTIME, taxtype As String
            Dim TPercent, RoomPer, PartyPer As Double
            'LOGAN
            '' '' '' ''sqlstring = "SELECT DISTINCT LOCCODE FROM PARTY_LOCATIONMASTER WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            '' '' '' ''gconnection.getDataSet(sqlstring, "PARTY_LOCATIONMASTER")
            '' '' '' ''If gdataset.Tables("PARTY_LOCATIONMASTER").Rows.Count <= 0 Then
            '' '' '' ''    CMB_LOCATION.Focus()
            '' '' '' ''    CMB_LOCATION.BackColor = Color.Red
            '' '' '' ''Else
            '' '' '' ''    CMB_LOCATION.BackColor = Color.White
            '' '' '' ''End If

            Dim hallamount, RECAMOUNT, HALLTAXPERCENTAGE, HALLTAXAMOUNT, HALLNETAMOUNT, SEDEPOSIT As Double
            Dim TAXCODE1 As String

            If Val(TXT_DISAMT.Text) >= 0 Then
                'Me.TXT_TOTAMT.Text = 0
                dbldicountAmount = Format((Val(TXT_TOTAMT.Text) * Val(TXT_DISAMT.Text)) / 100, "0.00")
                TXT_DISCOUNT.Text = dbldicountAmount
                'SSGRID_BOOKING.GetText(7, i, Taxamt)
                If Me.TXT_TOTAMT.Text < dbldicountAmount Then
                    MessageBox.Show("DISCOUNT AMOUNT CANNOT BE GREATER THAN TOTAL AMOUNT", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Me.TXTB_BAMOUNT.Text = Val(TXT_TOTAMT.Text) - Format(Val(dbldicountAmount), "0.00")
            Else
                dbldicountAmount = Format((Val(TXT_TOTAMT.Text) * Val(TXT_DISAMT.Text)) / 100, "0.00")
                Me.TXTB_BAMOUNT.Text = Val(TXT_TOTAMT.Text) - Format(Val(dbldicountAmount), "0.00")
            End If
            Call calculate()
            If Trim(TXTBOOKINGNO.Text) <> "" Then
                sqlstring = "SELECT * FROM PARTY_ACC_POST  where bookingno=" & TXTBOOKINGNO.Text & " AND ISNULL(POSTFLAG,'')='Y' "
                gconnection.getDataSet(sqlstring, "accpost")
                If gdataset.Tables("accpost").Rows.Count > 0 Then
                    MessageBox.Show("ALREADY ACCOUNT POSTING WAS DONE,YOU CANNOT UPDATE THE BILL ", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If
            End If

            If Mid(Cmd_Add.Text, 1, 1) = "A" Then
                Call checkValidation()
                If boolchk = False Then Exit Sub
                strsql = "Insert Into  PARTY_HALLBOOKING_HDR(LOCCODE,bookingno,description,FREERESON,GUESTNAME,Mcode,Associatename,CELLNO,EMAIL,OCCUPANCY,VEG,NONVEG,Guest_Type,Status_Type,Address1,Address2,CityPin,H_Type,Bookingdate,partydate,membertype"
                strsql = strsql & ",Freeze,HALLNETAMOUNT,DISCOUNT,DISCOUNTAMT,TOTALAMOUNT,"
                strsql = strsql & " Adduserid,Adddatetime,MEMGSTNO,STCODE)"
                strsql = strsql & " Values('" & Trim(CMB_LOCATION.Text) & "'," & Trim(TXTBOOKINGNO.Text) & ","
                strsql = strsql & " '" & Trim(TxtDescription.Text) & "',"
                strsql = strsql & " '" & Trim(txt_res.Text) & "',"
                strsql = strsql & " '" & Trim(TXTGUESTNAME.Text) & "',"
                strsql = strsql & "'" & Trim(txtmcode.Text) & "',"
                strsql = strsql & "'" & Trim(txtmname.Text) & "',"
                strsql = strsql & "" & Trim(TXT_CELLNO.Text) & ","
                strsql = strsql & "'" & Trim(TXT_EMAIL.Text) & "',"
                strsql = strsql & "" & Val(TxtOCCUPANCY.Text) & ","
                strsql = strsql & "" & Val(TxtVOCCUPANCY.Text) & ","
                strsql = strsql & "" & Val(TxtNVOCCUPANCY.Text) & ","
                strsql = strsql & "'" & Trim(Cmb_GuestType.Text) & "',"
                strsql = strsql & "'" & Trim(Cmb_StatusType.Text) & "',"
                strsql = strsql & "'" & Trim(Txt_Add1.Text) & "',"
                strsql = strsql & "'" & Trim(Txt_Add2.Text) & "',"
                strsql = strsql & "'" & Trim(Txt_CityPin.Text) & "',"
                strsql = strsql & "'" & Trim(Cmb_DayBasis.Text) & "',"
                strsql = strsql & "'" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                strsql = strsql & "'" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                strsql = strsql & "'" & IIf(RBCLUBMEMBER.Checked = True, "C", "A") & "','N','" & Val(TXT_TOTAMT.Text) & "','" & Val(TXT_DISAMT.Text) & "','" & Val(TXT_DISCOUNT.Text) & "','" & Trim(TXTB_BAMOUNT.Text) & "',"
                strsql = strsql & "'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "','" & Trim(Txt_MemGstNo.Text) & "','" & Trim(Txt_StateCode.Text) & "')"
                insert(0) = strsql
                With SSGRID_BOOKING
                    If .DataRowCnt > 0 Then
                        For I = 1 To .DataRowCnt
                            HALLCODE = "" : UOM = "" : ftime = "00:00" : ttime = "00:00" : QTY = 0 : ssql = "" : halltype = "" : hallamount = 0 : SEDEPOSIT = 0
                            .Row = I
                            .Col = 1
                            HALLCODE = Trim(.Text)
                            .Row = I
                            .Col = 3
                            halltype = Trim(.Text)
                            .Row = I
                            .Col = 5
                            'ftime = IIf(Val(.Text) > 0, Val(.Text), 0)
                            ftime = Trim(.Text)

                            .Row = I
                            .Col = 6
                            ''ttime = IIf(Val(.Text) > 0, Val(.Text), 0)
                            ttime = Trim(.Text)

                            .Row = I
                            .Col = 7
                            hallamount = IIf(Val(.Text) > 0, Val(.Text), 0)

                            .Row = I
                            .Col = 8
                            TAXCODE1 = Trim(.Text)
                            '  IIf(Val(.Text) > 0, Val(.Text), 0)

                            .Row = I
                            .Col = 9
                            HALLTAXAMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)
                            .Row = I
                            .Col = 10
                            HALLNETAMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)
                            .Row = I
                            .Col = 11
                            SEDEPOSIT = IIf(Val(.Text) > 0, Val(.Text), 0)



                            strsql = "INSERT INTO  PARTY_HALLBOOKING_DET(LOCCODE,HALLCODE,BOOKINGNO,PARTYDATE,FROMTIME,TOTIME,"
                            strsql = strsql & "HALLTYPE,HALLAMOUNT,HALLTAXPERC,HALLTAXAMOUNT,HALLNETAMOUNT,TAXCODE,SEDEPOSIT,H_Type,PartyTodate,HKStaff,SecurityStaff,HKStaffAmt,SecurityStaffAmt,SHallCode,FREEZE,ADDUSERID,ADDDATETIME)"
                            strsql = strsql & " values('" & Trim(CMB_LOCATION.Text) & "','" & Trim(HALLCODE) & "'"
                            strsql = strsql & "," & TXTBOOKINGNO.Text
                            strsql = strsql & ",'" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "'"
                            strsql = strsql & ",'" & ftime & "'"
                            strsql = strsql & ",'" & ttime & "'"
                            strsql = strsql & ",'" & halltype & "'"
                            strsql = strsql & "," & hallamount
                            strsql = strsql & "," & HALLTAXPERCENTAGE
                            strsql = strsql & "," & HALLTAXAMOUNT
                            strsql = strsql & "," & HALLNETAMOUNT
                            strsql = strsql & ",'" & TAXCODE1 & "'"
                            strsql = strsql & "," & SEDEPOSIT
                            .Row = I
                            .Col = 12
                            strsql = strsql & ",'" & Trim(.Text) & "'"
                            .Row = I
                            .Col = 13
                            strsql = strsql & ",'" & Format(CDate(.Text), "dd/MMM/yyyy") & "'"
                            .Row = I
                            .Col = 14
                            strsql = strsql & ",'" & Val(.Text) & "'"
                            .Row = I
                            .Col = 15
                            strsql = strsql & ",'" & Val(.Text) & "'"
                            .Row = I
                            .Col = 16
                            strsql = strsql & ",'" & Val(.Text) & "'"
                            .Row = I
                            .Col = 17
                            strsql = strsql & ",'" & Val(.Text) & "'"
                            .Row = I
                            .Col = 18
                            strsql = strsql & ",'" & Trim(.Text) & "'"
                            strsql = strsql & ",'N'"
                            strsql = strsql & ",'" & Trim(gUsername) & "'"
                            strsql = strsql & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = strsql
                        Next
                    End If
                End With

                For I = 1 To SSGRID_BOOKING.DataRowCnt
                    rate = 0
                    vat = 0
                    stax = 0
                    drate = 0

                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    With SSGRID_BOOKING
                        .Col = 1
                        .Row = I
                        HALLCODE = .Text

                        .Col = 3
                        .Row = I
                        HALLTYPE1 = .Text

                        .Col = 5
                        .Row = I
                        FROMTIME = .Text

                        .Col = 6
                        .Row = I
                        TOTIME = .Text

                        .Col = 7
                        .Row = I
                        rate = Val(.Text)
                        If Val(TXT_DISAMT.Text) > 0 Then
                            drate = rate - (rate * Val(TXT_DISAMT.Text) / 100)
                        End If

                        .Col = 8
                        .Row = I
                        ChargeCode = .Text

                        sqlstring = "SELECT ISNULL(TAXTypecode,'') AS TAXTypecode   FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                        gconnection.getDataSet(sqlstring, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If

                        sqlstring = "SELECT ISNULL(typeoftax,'')as typeoftax , isnull(ItemTypeCode,'')as ItemTypeCode, isnull(TaxCode,'')as taxcode , isnull(TAXON,'')as TAXON,isnull(TaxPercentage,0) AS TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        gconnection.getDataSet(sqlstring, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                TTAX = 0
                                IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                                TAXCODE = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")
                                taxtype = gdataset.Tables("TAXON").Rows(j).Item("typeoftax")

                                strsql = "INSERT INTO party_hallbooking_det_TAX (BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,HALLRATE,HALLTAXCODE,CHARGECODE,HALLTAXON,HALLTAXPERC,HALLTAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                                strsql = strsql & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(HALLCODE) & "','" & Trim(HALLTYPE1) & "','" & Format(Dtppartydate.Value, "dd-MMM-yyyy") & "','" & Trim(FROMTIME) & "','" & Trim(TOTIME) & "'," & Val(rate) & ",'" & Trim(TAXCODE) & "','" & Trim(ChargeCode) & "','" & Trim(Taxon) & "'," & (TPercent) & ","

                                If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                    If Val(TXT_DISAMT.Text) > 0 Then
                                        Zero = (drate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    Else
                                        Zero = (rate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    End If

                                    GZero = GZero + Zero
                                    .SetText(9, I, Zero)
                                    .SetText(10, I, Zero + rate)


                                    strsql = strsql & "" & Val(Zero) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    .SetText(9, I, ZeroA)
                                    .SetText(10, I, ZeroA + rate)

                                    strsql = strsql & "" & Val(ZeroA) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    .SetText(9, I, ZeroB)
                                    .SetText(10, I, ZeroB + rate)

                                    strsql = strsql & "" & Val(ZeroB) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                    If Val(TXT_DISAMT.Text) > 0 Then
                                        One = ((drate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    Else
                                        One = ((rate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    End If

                                    GOne = GOne + One
                                    .SetText(9, I, One)
                                    .SetText(10, I, One + rate)

                                    strsql = strsql & "" & Val(One) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    .SetText(9, I, OneA)
                                    .SetText(10, I, OneA + rate)

                                    strsql = strsql & "" & Val(OneA) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    .SetText(9, I, OneB)
                                    .SetText(10, I, OneB + rate)

                                    strsql = strsql & "" & Val(OneB) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                    If Val(TXT_DISAMT.Text) > 0 Then
                                        Two = ((drate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    Else
                                        Two = ((rate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    End If

                                    GTwo = GTwo + Two
                                    .SetText(9, I, Two)
                                    .SetText(10, I, Two + rate)

                                    strsql = strsql & "" & Val(Two) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    .SetText(9, I, TwoA)
                                    .SetText(10, I, TwoA + rate)

                                    strsql = strsql & "" & Val(TwoA) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    .SetText(9, I, TwoB)
                                    .SetText(10, I, TwoB + rate)

                                    strsql = strsql & "" & Val(TwoB) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                    If Val(TXT_DISAMT.Text) > 0 Then
                                        Three = ((drate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    Else
                                        Three = ((rate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    End If

                                    GThree = GThree + Three
                                    .SetText(9, I, Three)
                                    .SetText(10, I, Three + rate)

                                    strsql = strsql & "" & Val(Three) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    .SetText(9, I, ThreeA)
                                    .SetText(10, I, ThreeA + rate)

                                    strsql = strsql & "" & Val(ThreeA) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    .SetText(9, I, ThreeB)
                                    .SetText(10, I, ThreeB + rate)

                                    strsql = strsql & "" & Val(ThreeB) * 1 & ","
                                End If
                                strsql = strsql & "'" & Trim(gUsername) & "',getdate(),'N')"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = strsql
                                'LOGAN CHANGED ON 28JULY 13
                                TTAX = Zero + ZeroA + ZeroB + One + OneA + OneB + Two + TwoA + TwoB + Three + ThreeA + ThreeB
                                If Trim(taxtype) = "VAT" Then
                                    vat = vat + Val(TTAX)
                                ElseIf Trim(taxtype) = "SERVICE TAX" Then
                                    stax = stax + Val(TTAX)
                                End If
                            Next
                        End If
                        '' AS PER RAUSHAN DATED 28FEB2020 IF GST IS THERE TAX APPLICABLE
                        ''If Trim(Txt_MemGstNo.Text) = "" And Trim(Txt_StateCode.Text) = ClubStateCode And FloodTaxCode <> "" Then
                        ''    strsql = "INSERT INTO party_hallbooking_det_TAX (BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,HALLRATE,HALLTAXCODE,CHARGECODE,HALLTAXON,HALLTAXPERC,HALLTAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                        ''    strsql = strsql & " " & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(HALLCODE) & "','" & Trim(HALLTYPE1) & "','" & Format(Dtppartydate.Value, "dd-MMM-yyyy") & "','" & Trim(FROMTIME) & "','" & Trim(TOTIME) & "'," & Val(rate) & ",'" & Trim(FloodTaxCode) & "','" & Trim(ChargeCode) & "','0',1,"
                        ''    strsql = strsql & " " & Val(((rate * 1) / 100)) & ","
                        ''    strsql = strsql & "'" & Trim(gUsername) & "',getdate(),'N')"
                        ''    ReDim Preserve insert(insert.Length)
                        ''    insert(insert.Length - 1) = strsql
                        ''End If
                        If Chk_FloodTax.Checked = True And FloodTaxCode <> "" Then
                            strsql = "INSERT INTO party_hallbooking_det_TAX (BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,HALLRATE,HALLTAXCODE,CHARGECODE,HALLTAXON,HALLTAXPERC,HALLTAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                            strsql = strsql & " " & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(HALLCODE) & "','" & Trim(HALLTYPE1) & "','" & Format(Dtppartydate.Value, "dd-MMM-yyyy") & "','" & Trim(FROMTIME) & "','" & Trim(TOTIME) & "'," & Val(rate) & ",'" & Trim(FloodTaxCode) & "','" & Trim(ChargeCode) & "','0',1,"
                            strsql = strsql & " " & Val(((rate * 1) / 100)) & ","
                            strsql = strsql & "'" & Trim(gUsername) & "',getdate(),'N')"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = strsql
                        End If
                    End With
                    ' ''If Val(vat) > 0 Then
                    ' ''    sqlstring = "UPDATE PARTY_HALLBOOKING_DET SET HALLTAXAMOUNT=" & Val(vat) & " WHERE BOOKINGNO='" & Trim(TXTBOOKINGNO.Text) & "'and HALLCODE='" & Trim(HALLCODE) & "' "
                    ' ''    sqlstring = sqlstring & "AND HALLTYPE='" & Trim(HALLTYPE1) & "'"
                    ' ''    ReDim Preserve insert(insert.Length)
                    ' ''    insert(insert.Length - 1) = sqlstring

                    'else
                    'sqlstring = "UPDATE PARTY_HALLBOOKING_DET SET HALLTAXAMOUNT=0 WHERE BOOKINGNO='" & Trim(TXTBOOKINGNO.Text) & "'and HALLCODE='" & Trim(HALLCODE) & "' "
                    '' ''    sqlstring = sqlstring & "AND HALLTYPE='" & Trim(HALLTYPE1) & "'"
                    '' ''    ReDim Preserve insert(insert.Length)
                    '' ''    insert(insert.Length - 1) = sqlstring

                    ' ''End If
                    '' '' '' '' ''If Val(stax) > 0 Then
                    '' '' '' '' ''    sqlstring = "UPDATE PARTY_HALLBOOKING_DET SET SERTAX=" & Val(stax) & " WHERE BOOKINGNO='" & Trim(TXTBOOKINGNO.Text) & "'and HALLCODE='" & Trim(HALLCODE) & "' "
                    '' '' '' '' ''    sqlstring = sqlstring & "AND HALLTYPE='" & Trim(HALLTYPE1) & "'"
                    '' '' '' '' ''    'ReDim Preserve insert(insert.Length)
                    '' '' '' '' ''    'insert(insert.Length - 1) = ssql
                    '' '' '' '' ''    ReDim Preserve insert(insert.Length)
                    '' '' '' '' ''    insert(insert.Length - 1) = sqlstring
                    '' '' '' '' ''Else
                    '' '' '' '' ''    sqlstring = "UPDATE PARTY_HALLBOOKING_DET SET SERTAX=0 WHERE BOOKINGNO='" & Trim(TXTBOOKINGNO.Text) & "'and HALLCODE='" & Trim(HALLCODE) & "' "
                    '' '' '' '' ''    sqlstring = sqlstring & "AND HALLTYPE='" & Trim(HALLTYPE1) & "'"
                    '' '' '' '' ''    'ReDim Preserve insert(insert.Length)
                    '' '' '' '' ''    'insert(insert.Length - 1) = ssql
                    '' '' '' '' ''    ReDim Preserve insert(insert.Length)
                    '' '' '' '' ''    insert(insert.Length - 1) = sqlstring

                    '' '' '' '' ''End If


                    'UPDATE 

                Next


                ' '' '' '' ''With ssgrid_Receipt
                ' '' '' '' ''    If .DataRowCnt > 0 Then
                ' '' '' '' ''        For i = 1 To .DataRowCnt

                ' '' '' '' ''            RECNO = "" : RECAMOUNT = 0 : RECTYPE = ""
                ' '' '' '' ''            .Row = i
                ' '' '' '' ''            .Col = 1
                ' '' '' '' ''            RECNO = Trim(.Text)

                ' '' '' '' ''            'If RECNO = "" Then
                ' '' '' '' ''            '    MsgBox("Receipt Num1ber is Not Valid...", MsgBoxStyle.OKOnly, "Receipt Number")
                ' '' '' '' ''            '    Exit For
                ' '' '' '' ''            'End If
                ' '' '' '' ''            .Row = i
                ' '' '' '' ''            .Col = 2
                ' '' '' '' ''            RECDATE = Format(CDate(.Text), "dd/MMM/yyyy")
                ' '' '' '' ''            'If IsDate(.Text) = True Then
                ' '' '' '' ''            '    RECDATE = Format(CDate(.Text), "yyyy/MMM/dd")
                ' '' '' '' ''            '    If IsDate(RECDATE) = False Then
                ' '' '' '' ''            '        Exit For
                ' '' '' '' ''            '    End If
                ' '' '' '' ''            'Else
                ' '' '' '' ''            '    MsgBox("Date is Valid...", MsgBoxStyle.OKOnly, "Date")
                ' '' '' '' ''            '    Exit For
                ' '' '' '' ''            '    RECDATE = CDate("01/Jan/1900")
                ' '' '' '' ''            'End If

                ' '' '' '' ''            .Row = i
                ' '' '' '' ''            .Col = 3
                ' '' '' '' ''            RECAMOUNT = Val(.Text)

                ' '' '' '' ''            .Row = i
                ' '' '' '' ''            .Col = 4
                ' '' '' '' ''            RECTYPE = Trim(.Text)

                ' '' '' '' ''            strsql = "INSERT INTO PARTY_RECEIPT(LOCCODE,BOOKINGNO,RECEIPTNO,RECEIPTDATE,AMOUNT,AMOUNTTYPE,"
                ' '' '' '' ''            strsql = strsql & "FREEZE,ADDUSERID,ADDDATETIME)"
                ' '' '' '' ''            strsql = strsql & " values('" & Trim(CMB_LOCATION.Text) & "'," & Trim(TXTBOOKINGNO.Text)
                ' '' '' '' ''            strsql = strsql & ",'" & RECNO & "'"
                ' '' '' '' ''            strsql = strsql & ",'" & Format(CDate(RECDATE), "dd/MMM/yyyy hh:mm:ss") & "'"
                ' '' '' '' ''            strsql = strsql & "," & RECAMOUNT
                ' '' '' '' ''            strsql = strsql & ",'" & RECTYPE & "'"
                ' '' '' '' ''            strsql = strsql & ",'N'"
                ' '' '' '' ''            strsql = strsql & ",'" & Trim(gUsername) & "'"
                ' '' '' '' ''            strsql = strsql & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                ' '' '' '' ''            ReDim Preserve insert(insert.Length)
                ' '' '' '' ''            insert(insert.Length - 1) = strsql
                ' '' '' '' ''        Next
                ' '' '' '' ''    End If
                ' '' '' '' ''End With


                ssqlstring = "update party_hallbooking_det set SERTAX=(select SUM(HALLtaxamount) from party_hallbooking_det_TAX where party_hallbooking_det.BOOKINGNO=party_hallbooking_det_TAX.BOOKINGNO and party_hallbooking_det.HALLCODE =party_hallbooking_det_TAX.HALLCODE  AND "
                ssqlstring = ssqlstring & " party_hallbooking_det_TAX.HALLTAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX IN ('SERVICE TAX','CGST','CGST CESS')) AND party_hallbooking_det.HALLTYPE=party_hallbooking_det_TAX.HALLTYPE )WHERE BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & ""
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = ssqlstring

                ssqlstring = "Update  party_hallbooking_det set HALLTAXAMOUNT=(select SUM(HALLtaxamount) from party_hallbooking_det_TAX where party_hallbooking_det.BOOKINGNO=party_hallbooking_det_TAX.BOOKINGNO and party_hallbooking_det.HALLCODE=party_hallbooking_det_TAX.HALLCODE AND "
                ssqlstring = ssqlstring & "party_hallbooking_det_TAX.HALLTAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX IN ('VAT','SGST','SGST CESS')) AND party_hallbooking_det.HALLTYPE=party_hallbooking_det_TAX.HALLTYPE)WHERE BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & ""
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = ssqlstring

                If Chk_FloodTax.Checked = True Then
                    ssqlstring = "Update  party_hallbooking_hdr set FTaxApply = 'YES' WHERE BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " "
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = ssqlstring
                Else
                    ssqlstring = "Update  party_hallbooking_hdr set FTaxApply = 'NO' WHERE BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " "
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = ssqlstring
                End If

                gconnection.dataOperation1(1, insert)

                If MsgBox("Do you want windows print to Annexure........", MsgBoxStyle.OkCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then
                    'Call hallbilling()
                Else
                    Call PRINTWINDOWS()
                End If


                Call TEMPBOOKINGDETAILS()
                Me.Cmd_Clear_Click(sender, e)
            ElseIf Mid(Cmd_Add.Text, 1, 1) = "U" Then
                Call checkValidation()
                If boolchk = False Then Exit Sub
                If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then

                    'sqlstring = "SELECT   party_hallbooking_det "
                    'sqlstring = sqlstring & " WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
                    If Me.lbl_Freeze.Visible = True Then
                        MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        Exit Sub
                        boolchk = False
                    End If
                End If

                strsql = "Update PARTY_HALLBOOKING_HDR SET "
                strsql = strsql & " LOCcode='" & CMB_LOCATION.Text & "',"
                strsql = strsql & " Mcode='" & txtmcode.Text & "',"
                strsql = strsql & " OCCUPANCY=" & Val(TxtOCCUPANCY.Text) & ","
                'VIJAY 020811
                strsql = strsql & " hallnetamount=" & Val(TXT_TOTAMT.Text) & ","
                strsql = strsql & " discount=" & Val(TXT_DISAMT.Text) & ","
                strsql = strsql & " totalamount=" & Val(TXTB_BAMOUNT.Text) & ","
                strsql = strsql & " VEG=" & Val(TxtVOCCUPANCY.Text) & ","
                strsql = strsql & " NONVEG=" & Val(TxtNVOCCUPANCY.Text) & ","

                strsql = strsql & " partydate='" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "',"
                strsql = strsql & " Bookingdate='" & Format(DTPBOOKINGDATE.Value, "dd/MMM/yyyy hh:mm:ss") & "',"

                'strsql = strsql & " Recamount=" & TXTRECAMOUNT.Text & ","
                'strsql = strsql & " Recno='" & Trim(TXTVOUCHERNO.Text) & "',"
                'strsql = strsql & " Recdate='" & Format(DTPVOUCHERDATE.Value, "dd/MMM/yyyy") & "',"
                strsql = strsql & " DISCOUNTAMT='" & Val(TXT_DISCOUNT.Text) & "',"
                strsql = strsql & " Associatename='" & Trim(txtmname.Text) & "',"
                strsql = strsql & " CELLNO=" & Trim(TXT_CELLNO.Text) & ","
                strsql = strsql & " EMAIL='" & Trim(TXT_EMAIL.Text) & "',"
                strsql = strsql & " Membertype ='" & IIf(RBCLUBMEMBER.Checked = True, "C", "A") & "',"
                strsql = strsql & " Description='" & Trim(TxtDescription.Text) & "',"
                strsql = strsql & " H_Type='" & Trim(Cmb_DayBasis.Text) & "',"
                strsql = strsql & " Guest_Type='" & Trim(Cmb_GuestType.Text) & "',"
                strsql = strsql & " Status_Type='" & Trim(Cmb_StatusType.Text) & "',"
                strsql = strsql & " Address1='" & Trim(Txt_Add1.Text) & "',"
                strsql = strsql & " Address2='" & Trim(Txt_Add2.Text) & "',"
                strsql = strsql & " CityPin='" & Trim(Txt_CityPin.Text) & "',"

                strsql = strsql & " GUESTNAME='" & Trim(TXTGUESTNAME.Text) & "',"
                strsql = strsql & " MEMGSTNO='" & Trim(Txt_MemGstNo.Text) & "',"
                strsql = strsql & " STCODE='" & Trim(Txt_StateCode.Text) & "',"

                strsql = strsql & " FREERESON='" & Trim(txt_res.Text) & "',"
                strsql = strsql & " AddUserID='" & Trim(gUsername) & "',"
                strsql = strsql & " AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N' "
                strsql = strsql & " Where bookingno =" & Trim(TXTBOOKINGNO.Text) & " AND loccode ='" & Trim(CMB_LOCATION.Text) & "'"
                insert(0) = strsql
                With SSGRID_BOOKING
                    If .DataRowCnt > 0 Then
                        strsql = "DELETE FROM  PARTY_HALLBOOKING_DET WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & CMB_LOCATION.Text & "'"
                        ReDim Preserve insert(insert.Length)
                        insert(insert.Length - 1) = strsql
                        For I = 1 To .DataRowCnt
                            HALLCODE = "" : UOM = "" : QTY = 0 : ssql = "" : halltype = "" : hallamount = 0 : SEDEPOSIT = 0
                            .Row = I
                            .Col = 1
                            HALLCODE = Trim(.Text)
                            .Row = I
                            .Col = 3
                            halltype = Trim(.Text)
                            .Row = I
                            .Col = 5
                            'ftime = IIf(Val(.Text) > 0, Val(.Text), 0)
                            ftime = Trim(.Text)
                            .Row = I
                            .Col = 6
                            'ttime = IIf(Val(.Text) > 0, Val(.Text), 0)
                            ttime = Trim(.Text)
                            .Row = I
                            .Col = 7
                            hallamount = IIf(Val(.Text) > 0, Val(.Text), 0)
                            .Row = I
                            .Col = 8
                            TAXCODE1 = Trim(.Text)
                            'IIf(Val(.Text) > 0, Val(.Text), 0)
                            .Row = I
                            .Col = 9
                            HALLTAXAMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)
                            .Row = I
                            .Col = 10
                            HALLNETAMOUNT = IIf(Val(.Text) > 0, Val(.Text), 0)
                            .Row = I
                            .Col = 11
                            SEDEPOSIT = IIf(Val(.Text) > 0, Val(.Text), 0)


                            strsql = "INSERT INTO  PARTY_HALLBOOKING_DET(LOCCODE,HALLCODE,BOOKINGNO,PARTYDATE,FROMTIME,TOTIME,"
                            strsql = strsql & "HALLTYPE,HALLAMOUNT,HALLTAXPERC,HALLTAXAMOUNT,HALLNETAMOUNT,TAXCODE,SEDEPOSIT,H_Type,PartyTodate,HKStaff,SecurityStaff,HKStaffAmt,SecurityStaffAmt,SHallCode,FREEZE,ADDUSERID,ADDDATETIME)"
                            strsql = strsql & " values('" & Trim(CMB_LOCATION.Text) & "','" & Trim(HALLCODE) & "'"
                            strsql = strsql & "," & TXTBOOKINGNO.Text
                            strsql = strsql & ",'" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "'"
                            strsql = strsql & ",'" & ftime & "'"
                            strsql = strsql & ",'" & ttime & "'"
                            strsql = strsql & ",'" & halltype & "'"
                            strsql = strsql & "," & hallamount
                            strsql = strsql & "," & HALLTAXPERCENTAGE
                            strsql = strsql & "," & HALLTAXAMOUNT
                            strsql = strsql & "," & HALLNETAMOUNT
                            strsql = strsql & ",'" & TAXCODE1 & "'"
                            strsql = strsql & "," & SEDEPOSIT
                            .Row = I
                            .Col = 12
                            strsql = strsql & ",'" & Trim(.Text) & "'"
                            .Row = I
                            .Col = 13
                            strsql = strsql & ",'" & Format(CDate(.Text), "dd/MMM/yyyy") & "'"
                            .Row = I
                            .Col = 14
                            strsql = strsql & ",'" & Val(.Text) & "'"
                            .Row = I
                            .Col = 15
                            strsql = strsql & ",'" & Val(.Text) & "'"
                            .Row = I
                            .Col = 16
                            strsql = strsql & ",'" & Val(.Text) & "'"
                            .Row = I
                            .Col = 17
                            strsql = strsql & ",'" & Val(.Text) & "'"
                            .Row = I
                            .Col = 18
                            strsql = strsql & ",'" & Trim(.Text) & "'"
                            strsql = strsql & ",'N'"
                            strsql = strsql & ",'" & Trim(gUsername) & "'"
                            strsql = strsql & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = strsql
                        Next
                    End If
                End With
                sqlstring = "DELETE FROM party_hallbooking_det_TAX WHERE bookingno = '" & Trim(TXTBOOKINGNO.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring

                For I = 1 To SSGRID_BOOKING.DataRowCnt
                    rate = 0

                    vat = 0
                    stax = 0

                    Zero = 0 : ZeroA = 0 : ZeroB = 0 : One = 0 : OneA = 0 : OneB = 0 : Two = 0 : TwoA = 0 : TwoB = 0 : Three = 0 : ThreeA = 0 : ThreeB = 0
                    GZero = 0 : GZeroA = 0 : GZeroB = 0 : GOne = 0 : GOneA = 0 : GOneB = 0 : GTwo = 0 : GTwoA = 0 : GTwoB = 0 : GThree = 0 : GThreeA = 0 : GThreeB = 0
                    With SSGRID_BOOKING
                        .Col = 1
                        .Row = I
                        HALLCODE = .Text

                        .Col = 3
                        .Row = I
                        HALLTYPE1 = .Text

                        .Col = 5
                        .Row = I
                        FROMTIME = .Text

                        .Col = 6
                        .Row = I
                        TOTIME = .Text

                        .Col = 7
                        .Row = I
                        rate = Val(.Text)

                        .Col = 8
                        .Row = I
                        ChargeCode = .Text

                        sqlstring = "SELECT ISNULL(TAXTypecode,'')AS TAXTypecode FROM CHARGEMASTER WHERE CHARGECODE = '" & Trim(ChargeCode) & "' "
                        gconnection.getDataSet(sqlstring, "CODE_CHECK")
                        If gdataset.Tables("CODE_CHECK").Rows.Count - 1 >= 0 Then
                            ItemTypeCode = Trim(gdataset.Tables("CODE_CHECK").Rows(0).Item(0))
                        End If

                        'sqlstring = "SELECT ItemTypeCode,TaxCode,TAXON,TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        sqlstring = "SELECT ISNULL(typeoftax,'')as typeoftax , isnull(ItemTypeCode,'')as ItemTypeCode, isnull(TaxCode,'')as taxcode , isnull(TAXON,'')as TAXON,isnull(TaxPercentage,0) AS TaxPercentage FROM ITEMTYPEMASTER WHERE ItemTypeCode = '" & Trim(ItemTypeCode) & "' ORDER BY TAXON"
                        gconnection.getDataSet(sqlstring, "TAXON")
                        If gdataset.Tables("TAXON").Rows.Count - 1 >= 0 Then
                            For j = 0 To gdataset.Tables("TAXON").Rows.Count - 1
                                IType = Trim(gdataset.Tables("TAXON").Rows(j).Item("ItemTypeCode"))
                                TAXCODE = Trim(gdataset.Tables("TAXON").Rows(j).Item("TaxCode"))
                                Taxon = Trim(gdataset.Tables("TAXON").Rows(j).Item("TAXON"))
                                TPercent = gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")
                                taxtype = gdataset.Tables("TAXON").Rows(j).Item("typeoftax")

                                strsql = "INSERT INTO party_hallbooking_det_TAX (BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,HALLRATE,HALLTAXCODE,CHARGECODE,HALLTAXON,HALLTAXPERC,HALLTAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                                strsql = strsql & "" & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(HALLCODE) & "','" & Trim(HALLTYPE1) & "','" & Format(Dtppartydate.Value, "dd-MMM-yyyy") & "','" & Trim(FROMTIME) & "','" & Trim(TOTIME) & "'," & Val(rate) & ",'" & Trim(TAXCODE) & "','" & Trim(ChargeCode) & "','" & Trim(Taxon) & "'," & (TPercent) & ","

                                If gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0" Then
                                    Zero = (rate * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZero = GZero + Zero
                                    .SetText(9, I, Zero)
                                    .SetText(10, I, Zero + rate)


                                    strsql = strsql & "" & Val(Zero) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0A" Then
                                    ZeroA = (GZero * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroA = GZeroA + ZeroA
                                    .SetText(9, I, ZeroA)
                                    .SetText(10, I, ZeroA + rate)

                                    strsql = strsql & "" & Val(ZeroA) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "0B" Then
                                    ZeroB = ((GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GZeroB = GZeroB + ZeroB
                                    .SetText(9, I, ZeroB)
                                    .SetText(10, I, ZeroB + rate)

                                    strsql = strsql & "" & Val(ZeroB) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1" Then
                                    One = ((rate + GZero + GZeroA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOne = GOne + One
                                    .SetText(9, I, One)
                                    .SetText(10, I, One + rate)

                                    strsql = strsql & "" & Val(One) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1A" Then
                                    OneA = (One * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneA = GOneA + OneA
                                    .SetText(9, I, OneA)
                                    .SetText(10, I, OneA + rate)

                                    strsql = strsql & "" & Val(OneA) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "1B" Then
                                    OneB = ((GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GOneB = GOneB + OneB
                                    .SetText(9, I, OneB)
                                    .SetText(10, I, OneB + rate)

                                    strsql = strsql & "" & Val(OneB) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2" Then
                                    Two = ((rate + GZero + GZeroA + GOne + GOneA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwo = GTwo + Two
                                    .SetText(9, I, Two)
                                    .SetText(10, I, Two + rate)

                                    strsql = strsql & "" & Val(Two) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2A" Then
                                    TwoA = (Two * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoA = GTwoA + TwoA
                                    .SetText(9, I, TwoA)
                                    .SetText(10, I, TwoA + rate)

                                    strsql = strsql & "" & Val(TwoA) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "2B" Then
                                    TwoB = ((GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GTwoB = GTwoB + TwoB
                                    .SetText(9, I, TwoB)
                                    .SetText(10, I, TwoB + rate)

                                    strsql = strsql & "" & Val(TwoB) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3" Then
                                    Three = ((rate + GZero + GZeroA + GOne + GOneA + GTwo + GTwoA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThree = GThree + Three
                                    .SetText(9, I, Three)
                                    .SetText(10, I, Three + rate)

                                    strsql = strsql & "" & Val(Three) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3A" Then
                                    ThreeA = (Three * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeA = GThreeA + ThreeA
                                    .SetText(9, I, ThreeA)
                                    .SetText(10, I, ThreeA + rate)

                                    strsql = strsql & "" & Val(ThreeA) * 1 & ","
                                ElseIf gdataset.Tables("TAXON").Rows(j).Item("TAXON") = "3B" Then
                                    ThreeB = ((GThree + GThreeA) * gdataset.Tables("TAXON").Rows(j).Item("TaxPercentage")) / 100
                                    GThreeB = GThreeB + ThreeB
                                    .SetText(9, I, ThreeB)
                                    .SetText(10, I, ThreeB + rate)

                                    strsql = strsql & "" & Val(ThreeB) * 1 & ","
                                End If
                                strsql = strsql & "'" & Trim(gUsername) & "',getdate(),'N')"
                                ReDim Preserve insert(insert.Length)
                                insert(insert.Length - 1) = strsql

                                TTAX = Zero + ZeroA + ZeroB + One + OneA + OneB + Two + TwoA + TwoB + Three + ThreeA + ThreeB
                                If Trim(taxtype) = "VAT" Then
                                    vat = vat + Val(TTAX)
                                ElseIf Trim(taxtype) = "SERVICE TAX" Then
                                    stax = stax + Val(TTAX)
                                End If

                            Next
                        End If
                        ''If Trim(Txt_MemGstNo.Text) = "" And Trim(Txt_StateCode.Text) = ClubStateCode And FloodTaxCode <> "" Then
                        ''    strsql = "INSERT INTO party_hallbooking_det_TAX (BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,HALLRATE,HALLTAXCODE,CHARGECODE,HALLTAXON,HALLTAXPERC,HALLTAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                        ''    strsql = strsql & " " & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(HALLCODE) & "','" & Trim(HALLTYPE1) & "','" & Format(Dtppartydate.Value, "dd-MMM-yyyy") & "','" & Trim(FROMTIME) & "','" & Trim(TOTIME) & "'," & Val(rate) & ",'" & Trim(FloodTaxCode) & "','" & Trim(ChargeCode) & "','0',1,"
                        ''    strsql = strsql & " " & Val(((rate * 1) / 100)) & ","
                        ''    strsql = strsql & "'" & Trim(gUsername) & "',getdate(),'N')"
                        ''    ReDim Preserve insert(insert.Length)
                        ''    insert(insert.Length - 1) = strsql
                        ''End If
                        If Chk_FloodTax.Checked = True And FloodTaxCode <> "" Then
                            strsql = "INSERT INTO party_hallbooking_det_TAX (BOOKINGNO,HALLCODE,HALLTYPE,PARTYDATE,FROMTIME,TOTIME,HALLRATE,HALLTAXCODE,CHARGECODE,HALLTAXON,HALLTAXPERC,HALLTAXAMOUNT,ADDUSERID,ADDDATETIME,FREEZE) VALUES ( "
                            strsql = strsql & " " & Trim(TXTBOOKINGNO.Text) & ",'" & Trim(HALLCODE) & "','" & Trim(HALLTYPE1) & "','" & Format(Dtppartydate.Value, "dd-MMM-yyyy") & "','" & Trim(FROMTIME) & "','" & Trim(TOTIME) & "'," & Val(rate) & ",'" & Trim(FloodTaxCode) & "','" & Trim(ChargeCode) & "','0',1,"
                            strsql = strsql & " " & Val(((rate * 1) / 100)) & ","
                            strsql = strsql & "'" & Trim(gUsername) & "',getdate(),'N')"
                            ReDim Preserve insert(insert.Length)
                            insert(insert.Length - 1) = strsql
                        End If
                    End With

                    '' ''If Val(vat) > 0 Then
                    '' ''    sqlstring = "UPDATE PARTY_HALLBOOKING_DET SET HALLTAXAMOUNT=" & Val(vat) & " WHERE BOOKINGNO='" & Trim(TXTBOOKINGNO.Text) & "'and HALLCODE='" & Trim(HALLCODE) & "' "
                    '' ''    sqlstring = sqlstring & "AND HALLTYPE='" & Trim(HALLTYPE1) & "'"

                    '' ''    ReDim Preserve insert(insert.Length)
                    '' ''    insert(insert.Length - 1) = sqlstring
                    '  else
                    '' ''    sqlstring = "UPDATE PARTY_HALLBOOKING_DET SET HALLTAXAMOUNT=0  WHERE BOOKINGNO='" & Trim(TXTBOOKINGNO.Text) & "'and HALLCODE='" & Trim(HALLCODE) & "' "
                    '' ''    sqlstring = sqlstring & "AND HALLTYPE='" & Trim(HALLTYPE1) & "'"

                    '' ''    ReDim Preserve insert(insert.Length)
                    '' ''    insert(insert.Length - 1) = sqlstring

                    '' ''End If

                    '' '' '' ''If Val(stax) > 0 Then
                    '' '' '' ''    sqlstring = "UPDATE PARTY_HALLBOOKING_DET SET SERTAX=" & Val(stax) & " WHERE BOOKINGNO='" & Trim(TXTBOOKINGNO.Text) & "'and HALLCODE='" & Trim(HALLCODE) & "' "
                    '' '' '' ''    sqlstring = sqlstring & "AND HALLTYPE='" & Trim(HALLTYPE1) & "'"
                    '' '' '' ''    'ReDim Preserve insert(insert.Length)
                    '' '' '' ''    'insert(insert.Length - 1) = ssql
                    '' '' '' ''    ReDim Preserve insert(insert.Length)
                    '' '' '' ''    insert(insert.Length - 1) = sqlstring
                    '' '' '' ''Else
                    '' '' '' ''    sqlstring = "UPDATE PARTY_HALLBOOKING_DET SET SERTAX=0 WHERE BOOKINGNO='" & Trim(TXTBOOKINGNO.Text) & "'and HALLCODE='" & Trim(HALLCODE) & "' "
                    '' '' '' ''    sqlstring = sqlstring & "AND HALLTYPE='" & Trim(HALLTYPE1) & "'"

                    '' '' '' ''    ReDim Preserve insert(insert.Length)
                    '' '' '' ''    insert(insert.Length - 1) = sqlstring

                    '' '' '' ''End If
                Next


                'With ssgrid_Receipt
                '    strsql = "DELETE FROM  PARTY_RECEIPT WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                '    ReDim Preserve insert(insert.Length)
                '    insert(insert.Length - 1) = strsql

                '    If .DataRowCnt > 0 Then
                '        For i = 1 To .DataRowCnt
                '            RECNO = "" : RECAMOUNT = 0 : RECTYPE = ""
                '            .Row = i
                '            .Col = 1
                '            RECNO = Trim(.Text)

                '            .Row = i
                '            .Col = 2
                '            RECDATE = Format(CDate(.Text), "dd/MMM/yyyy")

                '            .Row = i
                '            .Col = 3
                '            RECAMOUNT = Val(.Text)

                '            .Row = i
                '            .Col = 4
                '            RECTYPE = Trim(.Text)

                '            strsql = "INSERT INTO PARTY_RECEIPT(LOCCODE,BOOKINGNO,RECEIPTNO,RECEIPTDATE,AMOUNT,AMOUNTTYPE,"
                '            strsql = strsql & "FREEZE,ADDUSERID,ADDDATETIME)"
                '            strsql = strsql & " values('" & Trim(CMB_LOCATION.Text) & "'," & Trim(TXTBOOKINGNO.Text)
                '            strsql = strsql & ",'" & RECNO & "'"
                '            strsql = strsql & ",'" & Format(CDate(RECDATE), "dd/MMM/yyyy") & "'"
                '            strsql = strsql & "," & RECAMOUNT
                '            strsql = strsql & ",'" & RECTYPE & "'"
                '            strsql = strsql & ",'N'"
                '            strsql = strsql & ",'" & Trim(gUsername) & "'"
                '            strsql = strsql & ",'" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                '            ReDim Preserve insert(insert.Length)
                '            insert(insert.Length - 1) = strsql
                '        Next
                '    End If
                'End With
                ssql = "UPDATE  PARTY_HDR SET "
                ssql = ssql & "PARTYDATE='" & Format(Dtppartydate.Value, "dd/MMM/yyyy hh:mm:ss") & "'"
                ssql = ssql & ",LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                ssql = ssql & ",MCODE='" & Trim(txtmcode.Text) & "'"
                ssql = ssql & ",ASSOCIATENAME='" & Trim(TXTASSOCIATENAME.Text) & "'"
                ssql = ssql & ",HALLCODE='" & Trim(txthallcode.Text) & "'"
                ssql = ssql & " WHERE BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = ssql
                ssql = "UPDATE  PARTY_HALLFACILITY SET "
                ssql = ssql & "HALLCODE='" & Trim(txthallcode.Text) & "'"
                ssql = ssql & " WHERE BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = ssql

                ssqlstring = "update party_hallbooking_det set SERTAX=(select SUM(HALLtaxamount) from party_hallbooking_det_TAX where party_hallbooking_det.BOOKINGNO=party_hallbooking_det_TAX.BOOKINGNO and party_hallbooking_det.HALLCODE =party_hallbooking_det_TAX.HALLCODE  AND "
                ssqlstring = ssqlstring & " party_hallbooking_det_TAX.HALLTAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX IN ('SERVICE TAX','CGST','CGST CESS')) AND party_hallbooking_det.HALLTYPE=party_hallbooking_det_TAX.HALLTYPE )WHERE BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & ""
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = ssqlstring

                ssqlstring = "Update  party_hallbooking_det set HALLTAXAMOUNT=(select SUM(HALLtaxamount) from party_hallbooking_det_TAX where party_hallbooking_det.BOOKINGNO=party_hallbooking_det_TAX.BOOKINGNO and party_hallbooking_det.HALLCODE=party_hallbooking_det_TAX.HALLCODE AND "
                ssqlstring = ssqlstring & "party_hallbooking_det_TAX.HALLTAXCODE IN (SELECT TAXCODE FROM ITEMTYPEMASTER WHERE TYPEOFTAX IN ('VAT','SGST','SGST CESS')) AND party_hallbooking_det.HALLTYPE=party_hallbooking_det_TAX.HALLTYPE)WHERE BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & ""
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = ssqlstring

                If Chk_FloodTax.Checked = True Then
                    ssqlstring = "Update  party_hallbooking_hdr set FTaxApply = 'YES' WHERE BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " "
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = ssqlstring
                Else
                    ssqlstring = "Update  party_hallbooking_hdr set FTaxApply = 'NO' WHERE BOOKINGNO=" & Trim(TXTBOOKINGNO.Text) & " "
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = ssqlstring
                End If

                gconnection.dataOperation1(2, insert)

                If MsgBox("Do you want windows print to Annexure........", MsgBoxStyle.OkCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then
                    'Call hallbilling()
                Else
                    Call PRINTWINDOWS()
                End If


                Call TEMPBOOKINGDETAILS()
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add1.Text = "Add [F7]"
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Try
            Me.TXTBOOKINGNO.ReadOnly = False
            Me.cmd_helpbooingno1.Enabled = True
            Dtppartydate.Value = Format("dd/MM/yyyy", Now())
            'DTPBOOKINGDATE.Value = Format("dd/MM/yyyy", Now())
            Me.txt_res.Text = ""
            Pic_Member.Image = Nothing
            Pic_Sign.Image = Nothing
            Pic_Spouse.Image = Nothing
            Pic_spousesign.Image = Nothing
            Me.Cmd_Add.Enabled = True
            txtmcode.Text = ""
            TXTASSOCIATENAME.Text = ""
            TXT_DISAMT.Text = ""
            TXT_TOTAMT.Text = ""
            TXTB_BAMOUNT.Text = ""
            TXT_DISCOUNT.Text = ""
            Dtppartydate.Text = ""
            TXTRECAMOUNT.Text = ""
            TXT_CELLNO.Text = ""
            TXT_EMAIL.Text = ""
            Txt_Add1.Text = ""
            Txt_Add2.Text = ""
            Txt_CityPin.Text = ""
            TxtOCCUPANCY.Text = ""
            TxtVOCCUPANCY.Text = ""
            TxtNVOCCUPANCY.Text = ""
            TXTRECAMOUNT.Text = Format(Val(TXTRECAMOUNT.Text), "0")
            txthallcode.Text = ""
            txtmname.Text = ""
            halldescription.Text = ""
            TxtDescription.Text = ""
            TXTGUESTNAME.Text = ""
            TXTVOUCHERNO.Text = ""
            Txt_MemGstNo.Text = ""
            Txt_StateCode.Text = ""
            SSgrid.Lock = False
            SSGRID_BOOKING.ClearRange(1, 1, -1, -1, True)
            ssgrid_Receipt.ClearRange(1, 1, -1, -1, True)
            SSGRID_BOOKING.SetActiveCell(1, 1)
            SSgrid.ClearRange(1, 1, -1, -1, True)
            SSgrid.SetActiveCell(1, 1)
            Me.lbl_Freeze.Visible = False
            Me.txthallcode.ReadOnly = False
            Me.lbl_Freeze.Text = "Record Freezed  On "
            Me.cmd_freeze.Text = "Freeze[F8]"
            Cmd_Add.Text = "Add [F7]"
            txthallcode.Enabled = True
            txthallcode.ReadOnly = False
            txthallcode.ReadOnly = False
            cmd_hallcodehelp.Enabled = True

            If gUserCategory <> "S" Then
                Call GetRights()
            End If

            ssql = "SELECT ISNULL(MAX(isnull(BOOKINGNO,0)),0)+1 AS BOOKINGNO FROM  PARTY_HALLBOOKING_DET WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            DT = gconnection.GetValues(ssql)
            If DT.Rows.Count > 0 Then
                TXTBOOKINGNO.Text = DT.Rows(0).Item(0)
            Else
                CMB_LOCATION.SelectedIndex = 0
                TXTBOOKINGNO.Text = 0
            End If
            Cmb_StatusType.Text = "PROVISIONAL"
            TXTBOOKINGNO.Focus()
            RDBPARTYBOOKINGTIME.Checked = True
            RDBPARTYBOOKINGTIME_CheckedChanged(sender, e)
            TXTBOOKINGNO.Focus()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub btn_rent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rent.Click
        GBHALLBOOKING.Visible = True
        GBHALLSTATUS.Visible = False
        GRPRECEIPT.Visible = False
        Dim II As Integer
        ' SSGRID_BOOKING.Focus()

        ' ''With SSGRID_BOOKING

        ' ''    i = 1
        ' ''    '.ActiveRow = i
        ' ''    ' .Lock = False
        ' ''    SSgrid.Row = .ActiveRow
        ' ''    SSgrid.Col = 7
        ' ''    .Lock = False
        ' ''    .Text = ""
        ' ''    .Focus()

        ' ''End With
        Dim SSQL As String
        SSQL = "SELECT ISNULL(USERNAME,'')AS USERNAME FROM PARTY_USERCONTROL WHERE USERNAME='" & gUsername & "' "
        gconnection.getDataSet(SSQL, "USER")

        If gdataset.Tables("USER").Rows.Count > 0 Then
            ' gUsername = gdataset.Tables("USER").Rows(0).Item("USERNAME")

            For II = 0 To SSGRID_BOOKING.DataRowCnt - 1
                SSGRID_BOOKING.Col = 7
                SSGRID_BOOKING.Row = II + 1
                'txthallcode.Text = Trim(SSGRID_BOOKING.Text)
                SSGRID_BOOKING.Lock = False
                ' SSGRID_BOOKING.Text = ""
                ' SSGRID_BOOKING.SetText(7, II + 1, 0)
                SSGRID_BOOKING.SetActiveCell(7, II + 1)
                SSGRID_BOOKING.Focus()

                TXT_DISAMT.Text = "0.00"
                TXT_DISCOUNT.Text = "0.00"


            Next
        Else
            MessageBox.Show("YOU HAVE NO RIGHTS TO UPDATE THE RENT", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        End If


    End Sub



    Private Sub cmd_helpbooingno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_helpbooingno.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(BOOKINGNO,0) AS BOOKINGNO,ISNULL(partyDATE,'')AS PARTYDATE,BOOKINGDATE AS BOOKINGDATE,ASSOCIATENAME AS MEMBERNAME,HALLCODE,MCODE "
            gSQLString = gSQLString & "  FROM  PARTY_HALLBOOKING_HDR"
            If Trim(Search) = " " Then
                M_WhereCondition = " WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            Else
                M_WhereCondition = " WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
            End If
            vform.Field = "BOOKINGNO,PARTYDATE,BOOKINGDATE,ASSOCIATENAME,HALLCODE,MCODE"
            '    vform.vFormatstring = "BOOKINGNO |   PARTYDATE   |  BOOKING DATE  |        MEMBER NAME       |    HALL CODE    |    MCODE    "
            vform.vCaption = "HALL RESERVATION HELP"
            '   vform.KeyPos = 0
            '  vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TXTBOOKINGNO.Text = Trim(vform.keyfield & "")
                TXTBOOKINGNO.Select()
                'DTPBOOKINGDATE.Text = Trim(vform.keyfield1 & "")
                Call TXTBOOKINGNO_Validated(sender, e)
                DTPBOOKINGDATE.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub cmd_mcodehelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_mcodehelp.Click
        Dim vform As New LIST_OPERATION1
        If UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then
            Try
                gSQLString = "Select isnull(mcode,'') as mcode,isnull(mname,'') as mname From MemberMaster "
                If Trim(Search) = " " Then
                    M_WhereCondition = " Where ISNULL(FREEZE,'')='' AND isnull(termination,'')<>'Y'"
                Else
                    M_WhereCondition = " Where ISNULL(FREEZE,'')='' AND isnull(termination,'')<>'Y'"
                End If
                'M_WhereCondition = " "
                vform.Field = "Mcode,Mname"
                '  vform.vFormatstring = "Member Code  | Member Name                                                 "
                vform.vCaption = "Member Master Help"
                'vform.KeyPos = 0
                'vform.KeyPos1 = 1
                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then
                    txtmcode.Text = Trim(vform.keyfield & "")
                    'txtmname.Text = Trim(vform.keyfield1 & "")
                    'TXTGUESTNAME.Text = Trim(vform.keyfield1 & "")
                    txtmcode.Select()
                    txtmcode_Validated(sender, e)
                    ' TxtOCCUPANCY.Focus()
                    '                TXTASSOCIATENAME.Focus()
                    TxtDescription.Focus()
                    'TxtVOCCUPANCY.Focus()
                    'TxtNVOCCUPANCY.Focus()

                End If
                vform.Close()
                vform = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            Try
                gSQLString = "Select Mcode,Mname From MemberMaster "
                If Trim(Search) = " " Then
                    M_WhereCondition = " WHERE curentstatus in ('ACTIVE','LIVE')"
                    'M_WhereCondition = " WHERE padd1<>'room no'"
                Else
                    M_WhereCondition = " WHERE curentstatus in ('ACTIVE','LIVE')"
                    'M_WhereCondition = " WHERE padd1<>'room no'"
                End If
                'M_WhereCondition = " "
                vform.Field = "Mcode,Mname"
                'vform.vFormatstring = "Member Code  | Member Name                                                 "
                vform.vCaption = "Member Master Help"
                'vform.KeyPos = 0
                'vform.KeyPos1 = 1
                vform.ShowDialog(Me)
                If Trim(vform.keyfield & "") <> "" Then
                    txtmcode.Text = Trim(vform.keyfield & "")
                    txtmcode.Select()
                    '  txtmname.Text = Trim(vform.keyfield1 & "")
                    txtmcode_Validated(sender, e)
                    'TxtOCCUPANCY.Focus()
                    '                TXTASSOCIATENAME.Focus()
                    ' TxtDescription.Focus()
                    TXTGUESTNAME.Focus()
                    'TxtVOCCUPANCY.Focus()
                    'TxtNVOCCUPANCY.Focus()

                End If
                vform.Close()
                vform = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub TXT_CELLNO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_CELLNO.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TXT_CELLNO.Text = "" Then
                TXT_CELLNO.Focus()
            Else
                'TXT_EMAIL.Focus()
                TxtNVOCCUPANCY.Select()
            End If
        End If
    End Sub

    Private Sub TXT_CELLNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_CELLNO.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            'TXT_EMAIL.Focus()
            TxtNVOCCUPANCY.Focus()
        End If
    End Sub

    Private Sub TXT_CELLNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_CELLNO.TextChanged

    End Sub

    Private Sub TXT_EMAIL_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXT_EMAIL.KeyDown
        Dim regexp As Regex
        If e.KeyCode = Keys.Enter Then
            ' gettmail(TXT_EMAIL)
            Dim emailstatus As String
            If Trim(TXT_EMAIL.Text) <> "" Then
                'If regexp.IsMatch(TXT_EMAIL.Text, "^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$") Then
                '    emailstatus = "T"
                '    TXT_EMAIL.ForeColor = Color.Blue
                '    'Return emailstatus
                '    TxtNVOCCUPANCY.Focus()
                'Else
                '    MsgBox(" E-mail Id field is not in correct format", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Validating email ")
                '    TXT_EMAIL.ForeColor = Color.Red
                '    TXT_EMAIL.Select()
                '    emailstatus = "F"
                '    TXT_EMAIL.Focus()
                '    ' Return emailstatus
                '    Exit Sub
                'End If
                TXT_CELLNO.Focus()
            Else
                'TxtNVOCCUPANCY.Select()
                TXT_CELLNO.Focus()
            End If
        End If
    End Sub

    Private Sub TXT_EMAIL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_EMAIL.KeyPress
        Dim regexp As Regex
        If Asc(e.KeyChar) = 13 Then
            Dim emailstatus As String
            If Trim(TXT_EMAIL.Text) <> "" Then
                If regexp.IsMatch(TXT_EMAIL.Text, "^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$") Then
                    emailstatus = "T"
                    TXT_EMAIL.ForeColor = Color.Blue
                    'Return emailstatus
                    'TxtNVOCCUPANCY.Focus()
                    TXT_CELLNO.Focus()
                Else
                    MsgBox(" E-mail Id field is not in correct format", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, " Validating email ")
                    TXT_EMAIL.ForeColor = Color.Red
                    TXT_EMAIL.Select()
                    emailstatus = "F"
                    TXT_EMAIL.Focus()
                    ' Return emailstatus
                    Exit Sub
                End If

            Else
                'TxtNVOCCUPANCY.Select()
                TXT_CELLNO.Focus()
            End If
        End If

    End Sub

    Private Sub TXT_EMAIL_MarginChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXT_EMAIL.MarginChanged

    End Sub

    Private Sub TXT_EMAIL_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_EMAIL.TextChanged

    End Sub

    Private Sub SSGRID_BOOKING_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles SSGRID_BOOKING.Enter

    End Sub

    Private Sub Cmd_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_view.Click
        If MsgBox("Do you want windows print to Annexure........", MsgBoxStyle.OkCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then
            sqlstring = "SELECT * FROM partyCANCEL_view Where bookingno=" & TXTBOOKINGNO.Text & ""
            gconnection.getDataSet(sqlstring, "partyCANCEL_view")
            If gdataset.Tables("partyCANCEL_view").Rows.Count > 0 Then
                Call CANCELWINDOWS()
            Else
                MsgBox("NO RECORDS FOUND TO DISPLAY  ", MsgBoxStyle.Information)
                Exit Sub
            End If
        Else
            Call PRINTWINDOWS()
        End If
    End Sub

    Private Sub Cmdbwse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbwse.Click
        Dim OBJ1 As New VIEWHDR
        Dim ChildSql As String
        '' '' ''sqlstring = "SELECT KOTDETAILS,KOTDATE,MCode,Mname,CARDHOLDERCODE,CARDHOLDERNAME,ServerCode,ServerName,TotalTax,Total,BillAmount,PaymentType,ISNULL(PackAmt,0) AS SERCHARGE,ISNULL(TipsAmt,0) AS TipsAmt,ISNULL(ADCGSAMT,0) AS ADDITIONCGS,ISNULL(PARTYAMT,0) AS PARTAMT,ISNULL(ROOMAMT,0) AS ROOMAMT,ADDUSERID,CAST(CONVERT(VARCHAR,Adddatetime,106) AS DATETIME) AS ADD_DATE,UPDUSERID,CAST(CONVERT(VARCHAR,ISNULL(Upddatetime,''),106) AS DATETIME) AS UPD_DATE,ISNULL(DelFlag,'') AS VOID,ISNULL(DELUSER,'') AS VOIDUSER,CAST(CONVERT(VARCHAR,ISNULL(DELDATETIME,''),106) AS DATETIME) AS VOIDDATE FROM KOT_HDR "
        '' '' ''ChildSql = "SELECT KOTDETAILS,CATEGORY,GROUPCODE,ITEMTYPE,POSCODE,ITEMCODE,ITEMDESC,UOM,QTY,RATE,AMOUNT,TAXAMOUNT,PAYMENTMODE,ISNULL(PACKAMOUNT,0) AS SERCHARGE,ISNULL(TipsAmt,0) AS TipsAmt,ISNULL(ADCGSAMT,0) AS ADDITIONCGS,ISNULL(PARTYAMT,0) AS PARTAMT,ISNULL(ROOMAMT,0) AS ROOMAMT FROM KOT_DET"
        '' '' ''gconnection.getDataSet(sqlstring, "KOT_HDR")
        '' '' ''OBJ1.LOADGRID(gdataset.Tables("KOT_HDR"), True, "FRM_TKGA_SmartKotEntry", ChildSql, "KOTDETAILS", 1)
        '' '' ''OBJ1.Show()

        sqlstring = "SELECT BOOKINGNO,HALLCODE,BOOKINGDATE,PARTYDATE,FROMTIME,TOTIME,HALLAMOUNT,HALLTAXAMOUNT,halltypedesc,sedeposit,MCODE,ASSOCIATENAME,GUESTNAME,DISCOUNTAMT,FREERESON,CCELL,DESCRIPTION,OCCUPANCY,HALLNETAMOUNT,DISCOUNT,TOTALAMOUNT FROM partyreceipt_view "
        ChildSql = "SELECT BOOKINGNO,ISNULL(CELLNO,0)AS CELLNO,ISNULL(EMAIL,'')AS EMAIL FROM PARTY_BOOKING_HDR"
        gconnection.getDataSet(sqlstring, "partyreceipt_view")
        OBJ1.LOADGRID(gdataset.Tables("partyreceipt_view"), True, "hallstatus", ChildSql, "BOOKINGNO", 1)
        OBJ1.Show()
    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click

        Dim STRSQL, ssql, STRS As String
        Dim sql As String
        If Trim(TXTBOOKINGNO.Text) <> "" Then
            sql = "SELECT * FROM PARTY_HALLBOOKING_HDR WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND BOOKINGNO='" & TXTBOOKINGNO.Text & "' AND ISNULL(CANCELFLAG,'')<>'Y'AND ISNULL(FREEZE,'')<>'Y'"
            gconnection.getDataSet(sql, "LOGA")
            If gdataset.Tables("LOG").Rows.Count > 0 Then




                ssql = "delete from canceldetails where bookingno='" & TXTBOOKINGNO.Text & "'"
                INSERT(INSERT.Length - 1) = ssql
                ReDim Preserve INSERT(INSERT.Length)

                ssql = "SELECT * FROM PARTY_HALLBOOKING_HDR WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND BOOKINGNO='" & TXTBOOKINGNO.Text & "' AND  ISNULL(BILLINGFLAG,'')='Y'" ' AND ISNULL(BOOKINGFLAG,'')='Y'"
                gconnection.getDataSet(ssql, "LOG")
                If gdataset.Tables("LOG").Rows.Count > 0 Then
                    MessageBox.Show("ALREADY BILLING WAS DONE YOU CANNOT CANCEL THE PARTY", "BILLING DONE", MessageBoxButtons.OK)
                    Exit Sub
                End If


                sql = "SELECT * FROM PARTY_HALLBOOKING_HDR WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND BOOKINGNO='" & TXTBOOKINGNO.Text & "' AND BOOKINGFLAG IS NULL"
                gconnection.getDataSet(sql, "LOG")

                If gdataset.Tables("LOG").Rows.Count > 0 Then
                    STRSQL = "UPDATE PARTY_HALLBOOKING_HDR SET CANCELFLAG='Y',FREEZE='Y' WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND BOOKINGNO='" & TXTBOOKINGNO.Text & "' AND BOOKINGFLAG IS NULL "

                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = STRSQL

                    gconnection.dataOperation1(6, INSERT)

                    STRSQL = "UPDATE PARTY_HALLBOOKING_DET SET FREEZE='Y' WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND BOOKINGNO='" & TXTBOOKINGNO.Text & "' "
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = STRSQL
                    Dim HRS, AMT, OCC As Integer
                    Dim TRATE, CANRATE, CANAMT, CANHEAD, CANHEAD1, CANFROM, CANTO, HRS1, HRS2, PERC, HALL As Double
                    Dim CANTYPE, BOOKFLAG As String

                    ssql = "SELECT  ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,ISNULL(H.OCCUPANCY,0)AS OCCUPANCY,CAST(CONVERT(VARCHAR(11),H.BOOKINGDATE,106)AS DATETIME)AS BOOKINGDATE,H.PARTYDATE AS PARTYDATE,ISNULL(SUM(D.HALLAMOUNT),0) AS TOTALAMOUNT "
                    ssql = ssql & " FROM PARTY_HALLBOOKING_DET D INNER JOIN PARTY_HALLBOOKING_HDR H ON H.BOOKINGNO=D.BOOKINGNO"
                    ssql = ssql & " WHERE H.LOCCODE='" & Trim(CMB_LOCATION.Text) & "' AND D.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'  AND H.MCODE='" & Trim(txtmcode.Text) & "'AND  D.BOOKINGNO =" & Val(TXTBOOKINGNO.Text) & " AND H.BOOKINGNO=" & Val(TXTBOOKINGNO.Text) & "  "
                    ssql = ssql & " GROUP BY H.OCCUPANCY,CAST(CONVERT(VARCHAR(11),H.BOOKINGDATE,106)AS DATETIME),H.PARTYDATE,H.BOOKINGFLAG"
                    gconnection.getDataSet(ssql, "book")

                    OCC = 0
                    CANAMT = 0
                    CANHEAD1 = 0
                    HALL = Val(gdataset.Tables("BOOK").Rows(0).Item("TOTALAMOUNT"))

                    If gdataset.Tables("book").Rows.Count > 0 Then
                        HRS = DateDiff(DateInterval.Hour, Now(), gdataset.Tables("book").Rows(0).Item("PARTYDATE"))
                        AMT = gdataset.Tables("BOOK").Rows(0).Item("TOTALAMOUNT")
                        OCC = gdataset.Tables("BOOK").Rows(0).Item("OCCUPANCY")
                    End If
                    ssql = "SELECT ISNULL(CANCELTYPE,'')AS CANCELTYPE,ISNULL(CANCELFROM,0)AS CANCELFROM,ISNULL(CANCELTO,0)AS CANCELTO,ISNULL(CANCEL_AMT_PER,0)AS PERAMT,ISNULL(CANCEL_AMT_HEAD,0)AS HEADAMT,ISNULL(FIXEDAMOUNT,0)AS FIXAMT FROM PARTY_CANCELLATIONMASTER WHERE " & Val(HRS) & " BETWEEN CANCELFROM AND CANCELTO "
                    gconnection.getDataSet(ssql, "CANCEL")
                    If gdataset.Tables("CANCEL").Rows.Count > 0 Then
                        CANTYPE = Trim(gdataset.Tables("CANCEL").Rows(0).Item("CANCELTYPE"))
                        PERC = gdataset.Tables("CANCEL").Rows(0).Item("PERAMT")
                        CANHEAD = gdataset.Tables("CANCEL").Rows(0).Item("HEADAMT")
                        CANRATE = gdataset.Tables("CANCEL").Rows(0).Item("FIXAMT")
                        CANFROM = gdataset.Tables("CANCEL").Rows(0).Item("CANCELFROM")
                        CANTO = gdataset.Tables("CANCEL").Rows(0).Item("CANCELTO")

                        If Trim(CANTYPE) = "AMOUNT" Then
                            '''''''CANAMT = ((((Val(OCC) * TRATE) + (Val(OCC) * Val(CANHEAD)) + Val(AMT)) - CANRATE))
                            CANAMT = (((Val(OCC) * Val(CANHEAD)) + CANRATE))
                        ElseIf Trim(CANTYPE) = "PERCENT" Then
                            ''''' CANAMT = ((((Val(OCC) * TRATE) + (Val(OCC) * Val(CANHEAD)) + Val(CANRATE) + Val(AMT)) * PERC) / 100)
                            ''''' CANAMT = ((((Val(OCC) * Val(CANHEAD)) + Val(CANRATE) + Val(AMT)) * PERC) / 100)
                            CANAMT = ((((Val(OCC) * Val(CANHEAD)) + Val(CANRATE)) + Val(HALL)))

                        End If
                        CANHEAD1 = Val(OCC) * Val(CANHEAD)


                    End If
                    ssql = "SELECT * from canceldetails where bookingno= " & Trim(TXTBOOKINGNO.Text) & " "
                    gconnection.getDataSet(ssql, "CANCL")
                    If gdataset.Tables("CANCL").Rows.Count = 0 Then
                        STRS = "INSERT INTO canceldetails(bookingno,bookingdate,partydate,mcode,mname,cantype,percentage,canhead,canrate,canamt,adddate,adduser,CANHAEDAMT)"
                        STRS = STRS & " values(" & Trim(TXTBOOKINGNO.Text) & ",'" & Format(DTPBOOKINGDATE.Value, "dd-MMM-yyyy") & "','" & Format(Dtppartydate.Value, "dd-MMM-yyyy") & "'"
                        STRS = STRS & ",'" & Trim(txtmcode.Text) & "','" & Trim(txtmname.Text) & "','" & CANTYPE & "', " & PERC & " ," & Val(CANHEAD1) & "," & Val(CANRATE) & "," & Val(CANAMT) & ","
                        'STRSQL = STRSQL & "" & Format(Now, "dd-MM-yyyy") & ",'" & Trim(gUsername) & "')"
                        STRS = STRS & "'" & Format(Now, "dd-MMM-yyyy") & "','" & Trim(gUsername) & "'," & CANHEAD & " )"

                        INSERT(INSERT.Length - 1) = STRS
                        ReDim Preserve INSERT(INSERT.Length)

                    End If

                    'ssql = " UPDATE  PARTY_HDR SET FREEZE='Y',CANCELAMOUNT=" & Val(CANAMT) & ",FROMHRS=" & Val(CANFROM) & ",TOHRS=" & Val(CANTO) & ",CANCELDATE='" & Format(DateTime.Now, "dd/MMM/yyyy hh:mm:ss") & "' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    'insert(insert.Length - 1) = ssql
                    'ReDim Preserve insert(insert.Length)

                    ssql = " UPDATE  PARTY_HALLBOOKING_HDR SET CANCELFLAG='Y',FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = ssql
                    ReDim Preserve INSERT(INSERT.Length)

                    ''''If Trim(BOOKFLAG) = "Y" Then
                    ssql = " UPDATE  PARTY_HALLBOOKING_DET SET FREEZE='Y',CANCELAMOUNT=" & Val(CANAMT) & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    INSERT(INSERT.Length - 1) = ssql
                    ReDim Preserve INSERT(INSERT.Length)
                    'Else
                    '    CANAMT = 0
                    '    ssql = " UPDATE  PARTY_HALLBOOKING_DET SET FREEZE='Y',CANCELAMOUNT=" & Val(CANAMT) & " WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    '    INSERT(INSERT.Length - 1) = ssql
                    '    ReDim Preserve INSERT(INSERT.Length)

                    '''End If


                    ''ssql = " UPDATE PARTY_RECEIPT SET FREEZE='Y' WHERE BOOKINGNO=" & TXTBOOKINGNO.Text & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                    ''INSERT(INSERT.Length - 1) = ssql
                    ''ReDim Preserve INSERT(INSERT.Length)


                    sqlstring = "UPDATE party_receipt_DET SET Freeze= 'Y' Where  BOOKINGNO=" & TXTBOOKINGNO.Text & "" ' PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "' "
                    INSERT(INSERT.Length - 1) = sqlstring
                    ReDim Preserve INSERT(INSERT.Length)

                    sqlstring = "UPDATE party_receipt_hdr SET Freeze= 'Y',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "' Where  BOOKINGNO=" & TXTBOOKINGNO.Text & "" ' PARTYRECEIPTNO='" & Trim(TXTVOUCHERNO.Text) & "'"
                    INSERT(INSERT.Length - 1) = sqlstring
                    ReDim Preserve INSERT(INSERT.Length)

                    ' gconnection.dataOperation1(1, INSERT)


                    gconnection.dataOperation1(2, INSERT)

                    MsgBox("PARTY RESERVATION CANCELLED")

                    If MsgBox("Do you want windows print to Annexure........", MsgBoxStyle.OkCancel, "PRINT FORMAT") = MsgBoxResult.Cancel Then
                        'Call hallbilling()
                    Else
                        Call CANCELWINDOWS()
                    End If

                    Me.Cmd_Clear_Click(sender, e)
                    Exit Sub
                    'End If
                Else
                    MsgBox("PARTY CAN NOT BE CANCELLED AS BOOKING HAS ALREADY BEEN DONE")
                End If

            End If
        Else
            Call CANCELWINDOWS()
            Me.Cmd_Clear_Click(sender, e)
            Exit Sub
        End If



    End Sub

    Private Sub SSGRID_BOOKING_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles SSGRID_BOOKING.HandleCreated

    End Sub

    Private Sub Cmb_GuestType_KeyDown(sender As Object, e As KeyEventArgs) Handles Cmb_GuestType.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Cmb_GuestType.Text = "" Then
                Cmb_GuestType.Focus()
            Else
                If Cmb_GuestType.Text = "MEMBER" Then
                    txtmcode.Focus()
                ElseIf Cmb_GuestType.Text = "OTHERS" Then
                    TXTGUESTNAME.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub Cmb_GuestType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_GuestType.SelectedIndexChanged
        If Cmb_GuestType.Text = "MEMBER" Then
            txtmcode.ReadOnly = False
            txtmname.ReadOnly = False
        ElseIf Cmb_GuestType.Text = "OTHERS" Then
            txtmcode.ReadOnly = True
            txtmname.ReadOnly = True
            txtmcode.Text = ""
            txtmname.Text = ""
        End If
    End Sub

    Private Sub Cmb_BookingType_KeyDown(sender As Object, e As KeyEventArgs) Handles Cmb_StatusType.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Cmb_StatusType.Text = "" Then
                Cmb_StatusType.Focus()
            Else
                Txt_Add1.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_Add1_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Add1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt_Add1.Text = "" Then
                Txt_Add1.Focus()
            Else
                Txt_Add2.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_Add2_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Add2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt_Add2.Text = "" Then
                Txt_Add2.Focus()
            Else
                Txt_CityPin.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_CityPin_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_CityPin.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Txt_CityPin.Text = "" Then
                Txt_CityPin.Focus()
            Else
                TXT_EMAIL.Focus()
            End If
        End If
    End Sub

    Private Sub cmd_Purpose_Click(sender As Object, e As EventArgs) Handles cmd_Purpose.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(PCode,'') AS PCode,ISNULL(PDesc,'') AS PDesc FROM Party_DiscriptionMaster "
            M_WhereCondition = " "
            vform.Field = "PCode,PDesc"
            ' vform.Frmcalled = "   UOMCODE     | UOM NAME         |                                  "
            vform.vCaption = " Purpose Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                TxtDescription.Text = Trim(vform.keyfield1 & "")
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub TxtDescription_Validated(sender As Object, e As EventArgs) Handles TxtDescription.Validated
        If Trim(TxtDescription.Text) <> "" Then
            Dim ds As New DataSet
            sqlstring = "SELECT isnull(PCode,'') as PCode,isnull(PDesc,'') as PDesc,isnull(AddDateTime,'') as AddDateTime,isnull(Freeze,'') as Freeze FROM Party_DiscriptionMaster WHERE PDesc='" & Replace(TxtDescription.Text, "'", "") & "'"
            gconnection.getDataSet(sqlstring, "PMaster")
            If gdataset.Tables("PMaster").Rows.Count > 0 Then
                TxtDescription.Clear()
                TxtDescription.Text = Replace(gdataset.Tables("PMaster").Rows(0).Item("PDesc"), "", "'")
            Else
                TxtDescription.Text = ""
                TxtDescription.Focus()
            End If
        Else
            TxtDescription.Text = ""
            TxtDescription.Focus()
        End If
    End Sub

    Private Sub Hallstatus_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub

  
  
End Class
