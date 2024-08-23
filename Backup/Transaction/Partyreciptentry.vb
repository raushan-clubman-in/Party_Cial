Imports System.Data.SqlClient
Imports System.IO
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Public Class Partyreciptentry
    Inherits System.Windows.Forms.Form
    Dim ssql, ssql1, oldtype, newtype, sqlstring As String
    Dim stype, stype3, stype1(2) As String
    Dim validity As Boolean
    Dim datalist, datalist1 As DataTable
    Dim I As Long
    Dim boolchk As Boolean
    Dim dt, posting As DataTable
    Dim txtobj1 As TextObject
    Dim Fromdate, todate As Date
    Dim MonthsDiff As Integer
    Dim dt1 As Date
    Dim dt2 As Date
    Dim gconnection As New GlobalClass

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
    Friend WithEvents lbl_MemberCode As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents mname As System.Windows.Forms.Label
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents cmdclear As System.Windows.Forms.Button
    Friend WithEvents cmdview As System.Windows.Forms.Button
    Friend WithEvents cmdprint As System.Windows.Forms.Button
    Friend WithEvents cmdadd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txt_Total As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtmembercode As System.Windows.Forms.TextBox
    Friend WithEvents cmdmemberhelp As System.Windows.Forms.Button
    Friend WithEvents membertype As System.Windows.Forms.Label
    Friend WithEvents dtp_premonthfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtp_premonthto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Gbx_details As System.Windows.Forms.GroupBox
    Friend WithEvents txt_bankname As System.Windows.Forms.TextBox
    Friend WithEvents dtp_instrumentdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Txt_instrumentno As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtp_ReceiptsDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ssgrid_Fac As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Cbo_Creditdebit As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_ReceiptsNo As System.Windows.Forms.TextBox
    Friend WithEvents cbo_paymentmode As System.Windows.Forms.ComboBox
    Friend WithEvents Cmd_receiptsNohelp As System.Windows.Forms.Button
    Friend WithEvents cmd_Delete As System.Windows.Forms.Button
    Friend WithEvents lbl_Frez As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents MEBERTYPECODE As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Txt_Bankplace As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Txt_Postage As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Partyreciptentry))
        Me.lbl_MemberCode = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.mname = New System.Windows.Forms.Label
        Me.membertype = New System.Windows.Forms.Label
        Me.cmdexit = New System.Windows.Forms.Button
        Me.cmdclear = New System.Windows.Forms.Button
        Me.cmdview = New System.Windows.Forms.Button
        Me.cmdprint = New System.Windows.Forms.Button
        Me.cmdadd = New System.Windows.Forms.Button
        Me.dtp_premonthfrom = New System.Windows.Forms.DateTimePicker
        Me.dtp_premonthto = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txt_Total = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtmembercode = New System.Windows.Forms.TextBox
        Me.cmdmemberhelp = New System.Windows.Forms.Button
        Me.Gbx_details = New System.Windows.Forms.GroupBox
        Me.Txt_Bankplace = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Cbo_Creditdebit = New System.Windows.Forms.ComboBox
        Me.txt_bankname = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtp_instrumentdate = New System.Windows.Forms.DateTimePicker
        Me.Txt_instrumentno = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.dtp_ReceiptsDate = New System.Windows.Forms.DateTimePicker
        Me.ssgrid_Fac = New AxFPSpreadADO.AxfpSpread
        Me.Txt_ReceiptsNo = New System.Windows.Forms.TextBox
        Me.cbo_paymentmode = New System.Windows.Forms.ComboBox
        Me.Cmd_receiptsNohelp = New System.Windows.Forms.Button
        Me.cmd_Delete = New System.Windows.Forms.Button
        Me.lbl_Frez = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.MEBERTYPECODE = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Txt_Postage = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Gbx_details.SuspendLayout()
        CType(Me.ssgrid_Fac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl_MemberCode
        '
        Me.lbl_MemberCode.BackColor = System.Drawing.Color.Transparent
        Me.lbl_MemberCode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_MemberCode.Location = New System.Drawing.Point(80, 108)
        Me.lbl_MemberCode.Name = "lbl_MemberCode"
        Me.lbl_MemberCode.Size = New System.Drawing.Size(120, 16)
        Me.lbl_MemberCode.TabIndex = 668
        Me.lbl_MemberCode.Text = "Membership No"
        Me.lbl_MemberCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(584, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 22)
        Me.Label3.TabIndex = 671
        Me.Label3.Text = "Member Type"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(414, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 22)
        Me.Label4.TabIndex = 670
        Me.Label4.Text = "Name"
        '
        'mname
        '
        Me.mname.BackColor = System.Drawing.Color.Transparent
        Me.mname.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mname.ForeColor = System.Drawing.Color.Red
        Me.mname.Location = New System.Drawing.Point(472, 104)
        Me.mname.Name = "mname"
        Me.mname.Size = New System.Drawing.Size(440, 24)
        Me.mname.TabIndex = 673
        '
        'membertype
        '
        Me.membertype.BackColor = System.Drawing.Color.Transparent
        Me.membertype.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.membertype.ForeColor = System.Drawing.Color.Red
        Me.membertype.Location = New System.Drawing.Point(696, 71)
        Me.membertype.Name = "membertype"
        Me.membertype.Size = New System.Drawing.Size(248, 24)
        Me.membertype.TabIndex = 672
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.White
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.Location = New System.Drawing.Point(696, 600)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(104, 32)
        Me.cmdexit.TabIndex = 678
        Me.cmdexit.Text = "Exit[F11]"
        '
        'cmdclear
        '
        Me.cmdclear.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdclear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdclear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdclear.ForeColor = System.Drawing.Color.White
        Me.cmdclear.Image = CType(resources.GetObject("cmdclear.Image"), System.Drawing.Image)
        Me.cmdclear.Location = New System.Drawing.Point(584, 600)
        Me.cmdclear.Name = "cmdclear"
        Me.cmdclear.Size = New System.Drawing.Size(104, 32)
        Me.cmdclear.TabIndex = 677
        Me.cmdclear.Text = "Clear[F6]"
        '
        'cmdview
        '
        Me.cmdview.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdview.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdview.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdview.ForeColor = System.Drawing.Color.White
        Me.cmdview.Image = CType(resources.GetObject("cmdview.Image"), System.Drawing.Image)
        Me.cmdview.Location = New System.Drawing.Point(344, 600)
        Me.cmdview.Name = "cmdview"
        Me.cmdview.Size = New System.Drawing.Size(104, 32)
        Me.cmdview.TabIndex = 675
        Me.cmdview.Text = "Print[F9]"
        '
        'cmdprint
        '
        Me.cmdprint.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdprint.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdprint.ForeColor = System.Drawing.Color.White
        Me.cmdprint.Image = CType(resources.GetObject("cmdprint.Image"), System.Drawing.Image)
        Me.cmdprint.Location = New System.Drawing.Point(584, 600)
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(104, 32)
        Me.cmdprint.TabIndex = 676
        Me.cmdprint.Text = "Print[F12]"
        Me.cmdprint.Visible = False
        '
        'cmdadd
        '
        Me.cmdadd.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdadd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdadd.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdadd.ForeColor = System.Drawing.Color.White
        Me.cmdadd.Image = CType(resources.GetObject("cmdadd.Image"), System.Drawing.Image)
        Me.cmdadd.Location = New System.Drawing.Point(232, 600)
        Me.cmdadd.Name = "cmdadd"
        Me.cmdadd.Size = New System.Drawing.Size(104, 32)
        Me.cmdadd.TabIndex = 674
        Me.cmdadd.Text = "Add New[F5]"
        '
        'dtp_premonthfrom
        '
        Me.dtp_premonthfrom.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtp_premonthfrom.CustomFormat = "MM/YYYY"
        Me.dtp_premonthfrom.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_premonthfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtp_premonthfrom.Location = New System.Drawing.Point(208, 144)
        Me.dtp_premonthfrom.Name = "dtp_premonthfrom"
        Me.dtp_premonthfrom.Size = New System.Drawing.Size(112, 26)
        Me.dtp_premonthfrom.TabIndex = 679
        '
        'dtp_premonthto
        '
        Me.dtp_premonthto.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtp_premonthto.CustomFormat = "MMM/yyyy"
        Me.dtp_premonthto.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_premonthto.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtp_premonthto.Location = New System.Drawing.Point(472, 144)
        Me.dtp_premonthto.Name = "dtp_premonthto"
        Me.dtp_premonthto.Size = New System.Drawing.Size(112, 26)
        Me.dtp_premonthto.TabIndex = 680
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 24)
        Me.Label1.TabIndex = 683
        Me.Label1.Text = "Pre. Paid Month From"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(328, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 24)
        Me.Label2.TabIndex = 684
        Me.Label2.Text = "Pre.Paid Month To"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(104, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 22)
        Me.Label7.TabIndex = 687
        Me.Label7.Text = "Receipts No"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(40, 464)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 24)
        Me.Label8.TabIndex = 688
        Me.Label8.Text = "Payment Mode:"
        '
        'txt_Total
        '
        Me.txt_Total.BackColor = System.Drawing.Color.White
        Me.txt_Total.Enabled = False
        Me.txt_Total.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Total.Location = New System.Drawing.Point(832, 456)
        Me.txt_Total.MaxLength = 9
        Me.txt_Total.Name = "txt_Total"
        Me.txt_Total.Size = New System.Drawing.Size(104, 26)
        Me.txt_Total.TabIndex = 690
        Me.txt_Total.Text = ""
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(720, 456)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 24)
        Me.Label9.TabIndex = 691
        Me.Label9.Text = "Total Amount:"
        '
        'txtmembercode
        '
        Me.txtmembercode.BackColor = System.Drawing.Color.White
        Me.txtmembercode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtmembercode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmembercode.Location = New System.Drawing.Point(208, 103)
        Me.txtmembercode.Name = "txtmembercode"
        Me.txtmembercode.Size = New System.Drawing.Size(112, 26)
        Me.txtmembercode.TabIndex = 692
        Me.txtmembercode.Text = ""
        '
        'cmdmemberhelp
        '
        Me.cmdmemberhelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdmemberhelp.Image = CType(resources.GetObject("cmdmemberhelp.Image"), System.Drawing.Image)
        Me.cmdmemberhelp.Location = New System.Drawing.Point(320, 104)
        Me.cmdmemberhelp.Name = "cmdmemberhelp"
        Me.cmdmemberhelp.Size = New System.Drawing.Size(23, 24)
        Me.cmdmemberhelp.TabIndex = 693
        '
        'Gbx_details
        '
        Me.Gbx_details.BackColor = System.Drawing.Color.Transparent
        Me.Gbx_details.Controls.Add(Me.Txt_Bankplace)
        Me.Gbx_details.Controls.Add(Me.Label6)
        Me.Gbx_details.Controls.Add(Me.Label5)
        Me.Gbx_details.Controls.Add(Me.Cbo_Creditdebit)
        Me.Gbx_details.Controls.Add(Me.txt_bankname)
        Me.Gbx_details.Controls.Add(Me.Label13)
        Me.Gbx_details.Controls.Add(Me.dtp_instrumentdate)
        Me.Gbx_details.Controls.Add(Me.Txt_instrumentno)
        Me.Gbx_details.Controls.Add(Me.Label12)
        Me.Gbx_details.Controls.Add(Me.Label11)
        Me.Gbx_details.Controls.Add(Me.Label10)
        Me.Gbx_details.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gbx_details.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Gbx_details.Location = New System.Drawing.Point(40, 496)
        Me.Gbx_details.Name = "Gbx_details"
        Me.Gbx_details.Size = New System.Drawing.Size(872, 96)
        Me.Gbx_details.TabIndex = 694
        Me.Gbx_details.TabStop = False
        Me.Gbx_details.Text = "DETAILS"
        Me.Gbx_details.Visible = False
        '
        'Txt_Bankplace
        '
        Me.Txt_Bankplace.BackColor = System.Drawing.Color.White
        Me.Txt_Bankplace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Bankplace.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Bankplace.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Bankplace.Location = New System.Drawing.Point(600, 56)
        Me.Txt_Bankplace.MaxLength = 50
        Me.Txt_Bankplace.Name = "Txt_Bankplace"
        Me.Txt_Bankplace.Size = New System.Drawing.Size(260, 26)
        Me.Txt_Bankplace.TabIndex = 698
        Me.Txt_Bankplace.Text = ""
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(496, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 22)
        Me.Label6.TabIndex = 697
        Me.Label6.Text = "Bank Place :"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(888, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 24)
        Me.Label5.TabIndex = 696
        Me.Label5.Text = "Credit/Debit"
        Me.Label5.Visible = False
        '
        'Cbo_Creditdebit
        '
        Me.Cbo_Creditdebit.BackColor = System.Drawing.Color.White
        Me.Cbo_Creditdebit.Items.AddRange(New Object() {"DEBIT", "CREDIT"})
        Me.Cbo_Creditdebit.Location = New System.Drawing.Point(976, 24)
        Me.Cbo_Creditdebit.Name = "Cbo_Creditdebit"
        Me.Cbo_Creditdebit.Size = New System.Drawing.Size(136, 22)
        Me.Cbo_Creditdebit.TabIndex = 695
        Me.Cbo_Creditdebit.Visible = False
        '
        'txt_bankname
        '
        Me.txt_bankname.BackColor = System.Drawing.Color.White
        Me.txt_bankname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_bankname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_bankname.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_bankname.Location = New System.Drawing.Point(136, 56)
        Me.txt_bankname.MaxLength = 50
        Me.txt_bankname.Name = "txt_bankname"
        Me.txt_bankname.Size = New System.Drawing.Size(352, 26)
        Me.txt_bankname.TabIndex = 694
        Me.txt_bankname.Text = ""
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 22)
        Me.Label13.TabIndex = 693
        Me.Label13.Text = "Bank Name :"
        '
        'dtp_instrumentdate
        '
        Me.dtp_instrumentdate.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtp_instrumentdate.CustomFormat = "yyyy"
        Me.dtp_instrumentdate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_instrumentdate.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtp_instrumentdate.Location = New System.Drawing.Point(384, 22)
        Me.dtp_instrumentdate.Name = "dtp_instrumentdate"
        Me.dtp_instrumentdate.Size = New System.Drawing.Size(104, 26)
        Me.dtp_instrumentdate.TabIndex = 692
        '
        'Txt_instrumentno
        '
        Me.Txt_instrumentno.BackColor = System.Drawing.Color.White
        Me.Txt_instrumentno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_instrumentno.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_instrumentno.Location = New System.Drawing.Point(136, 25)
        Me.Txt_instrumentno.MaxLength = 20
        Me.Txt_instrumentno.Name = "Txt_instrumentno"
        Me.Txt_instrumentno.Size = New System.Drawing.Size(128, 26)
        Me.Txt_instrumentno.TabIndex = 691
        Me.Txt_instrumentno.Text = ""
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(0, 22)
        Me.Label12.TabIndex = 690
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(264, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 22)
        Me.Label11.TabIndex = 689
        Me.Label11.Text = "Instrument Date:"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(16, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(137, 22)
        Me.Label10.TabIndex = 688
        Me.Label10.Text = "Instrument No:"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(360, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 22)
        Me.Label15.TabIndex = 698
        Me.Label15.Text = "Receipts Date"
        '
        'dtp_ReceiptsDate
        '
        Me.dtp_ReceiptsDate.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtp_ReceiptsDate.CustomFormat = "yyyy"
        Me.dtp_ReceiptsDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_ReceiptsDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtp_ReceiptsDate.Location = New System.Drawing.Point(472, 70)
        Me.dtp_ReceiptsDate.Name = "dtp_ReceiptsDate"
        Me.dtp_ReceiptsDate.Size = New System.Drawing.Size(112, 26)
        Me.dtp_ReceiptsDate.TabIndex = 699
        '
        'ssgrid_Fac
        '
        Me.ssgrid_Fac.DataSource = Nothing
        Me.ssgrid_Fac.Location = New System.Drawing.Point(40, 184)
        Me.ssgrid_Fac.Name = "ssgrid_Fac"
        Me.ssgrid_Fac.OcxState = CType(resources.GetObject("ssgrid_Fac.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid_Fac.Size = New System.Drawing.Size(944, 232)
        Me.ssgrid_Fac.TabIndex = 700
        '
        'Txt_ReceiptsNo
        '
        Me.Txt_ReceiptsNo.BackColor = System.Drawing.Color.Linen
        Me.Txt_ReceiptsNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_ReceiptsNo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_ReceiptsNo.Location = New System.Drawing.Point(208, 70)
        Me.Txt_ReceiptsNo.Name = "Txt_ReceiptsNo"
        Me.Txt_ReceiptsNo.Size = New System.Drawing.Size(112, 26)
        Me.Txt_ReceiptsNo.TabIndex = 707
        Me.Txt_ReceiptsNo.Text = ""
        '
        'cbo_paymentmode
        '
        Me.cbo_paymentmode.BackColor = System.Drawing.Color.White
        Me.cbo_paymentmode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_paymentmode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbo_paymentmode.Location = New System.Drawing.Point(176, 464)
        Me.cbo_paymentmode.Name = "cbo_paymentmode"
        Me.cbo_paymentmode.Size = New System.Drawing.Size(192, 27)
        Me.cbo_paymentmode.TabIndex = 708
        '
        'Cmd_receiptsNohelp
        '
        Me.Cmd_receiptsNohelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_receiptsNohelp.Image = CType(resources.GetObject("Cmd_receiptsNohelp.Image"), System.Drawing.Image)
        Me.Cmd_receiptsNohelp.Location = New System.Drawing.Point(320, 71)
        Me.Cmd_receiptsNohelp.Name = "Cmd_receiptsNohelp"
        Me.Cmd_receiptsNohelp.Size = New System.Drawing.Size(23, 24)
        Me.Cmd_receiptsNohelp.TabIndex = 709
        '
        'cmd_Delete
        '
        Me.cmd_Delete.BackColor = System.Drawing.Color.Transparent
        Me.cmd_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Delete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Delete.ForeColor = System.Drawing.Color.White
        Me.cmd_Delete.Image = CType(resources.GetObject("cmd_Delete.Image"), System.Drawing.Image)
        Me.cmd_Delete.Location = New System.Drawing.Point(464, 600)
        Me.cmd_Delete.Name = "cmd_Delete"
        Me.cmd_Delete.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Delete.TabIndex = 710
        Me.cmd_Delete.Text = "Freeze[F7]"
        '
        'lbl_Frez
        '
        Me.lbl_Frez.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Frez.Font = New System.Drawing.Font("Verdana", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Frez.ForeColor = System.Drawing.Color.Red
        Me.lbl_Frez.Location = New System.Drawing.Point(328, 632)
        Me.lbl_Frez.Name = "lbl_Frez"
        Me.lbl_Frez.Size = New System.Drawing.Size(376, 25)
        Me.lbl_Frez.TabIndex = 711
        Me.lbl_Frez.Text = "Record Freezed  On "
        Me.lbl_Frez.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Frez.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Courier New", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(720, 152)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(237, 20)
        Me.Label17.TabIndex = 712
        Me.Label17.Text = "Press [F3] For Delete Row"
        '
        'MEBERTYPECODE
        '
        Me.MEBERTYPECODE.BackColor = System.Drawing.Color.Transparent
        Me.MEBERTYPECODE.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MEBERTYPECODE.ForeColor = System.Drawing.Color.Red
        Me.MEBERTYPECODE.Location = New System.Drawing.Point(728, 16)
        Me.MEBERTYPECODE.Name = "MEBERTYPECODE"
        Me.MEBERTYPECODE.Size = New System.Drawing.Size(248, 24)
        Me.MEBERTYPECODE.TabIndex = 713
        Me.MEBERTYPECODE.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(40, 416)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(286, 21)
        Me.Label14.TabIndex = 714
        Me.Label14.Text = "Press [F4]or[Enter] For Subscription Help"
        '
        'Txt_Postage
        '
        Me.Txt_Postage.BackColor = System.Drawing.Color.White
        Me.Txt_Postage.Enabled = False
        Me.Txt_Postage.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Postage.Location = New System.Drawing.Point(832, 424)
        Me.Txt_Postage.MaxLength = 9
        Me.Txt_Postage.Name = "Txt_Postage"
        Me.Txt_Postage.Size = New System.Drawing.Size(104, 26)
        Me.Txt_Postage.TabIndex = 715
        Me.Txt_Postage.Text = ""
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(704, 424)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(128, 24)
        Me.Label16.TabIndex = 716
        Me.Label16.Text = "Postage Charge:"
        '
        'Advance_Subscription
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1016, 694)
        Me.ControlBox = False
        Me.Controls.Add(Me.Txt_Postage)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.MEBERTYPECODE)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Txt_ReceiptsNo)
        Me.Controls.Add(Me.txtmembercode)
        Me.Controls.Add(Me.txt_Total)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_Frez)
        Me.Controls.Add(Me.cmd_Delete)
        Me.Controls.Add(Me.Cmd_receiptsNohelp)
        Me.Controls.Add(Me.cbo_paymentmode)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ssgrid_Fac)
        Me.Controls.Add(Me.dtp_ReceiptsDate)
        Me.Controls.Add(Me.Gbx_details)
        Me.Controls.Add(Me.cmdmemberhelp)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtp_premonthto)
        Me.Controls.Add(Me.dtp_premonthfrom)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.cmdclear)
        Me.Controls.Add(Me.cmdview)
        Me.Controls.Add(Me.cmdprint)
        Me.Controls.Add(Me.cmdadd)
        Me.Controls.Add(Me.mname)
        Me.Controls.Add(Me.membertype)
        Me.Controls.Add(Me.lbl_MemberCode)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Advance_Subscription"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Advance_Subscription"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Gbx_details.ResumeLayout(False)
        CType(Me.ssgrid_Fac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub cmdmemberhelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdmemberhelp.Click
        Dim vform As New ListOperattion1
        Try
            gSQLString = "SELECT ISNULL(MCODE,'') AS MCODE,ISNULL(MNAME,'') AS MNAME,ISNULL(Membertype,'') AS Membertype FROM membermaster"
            M_WhereCondition = " "
            listop = ""
            vform.Field = "MCODE,MNAME,MEMBERTYPE"
            vform.vFormatstring = "  Member Code  | Member Name  |Membertype       "
            vform.vCaption = "Member Master Help"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtmembercode.Text = Trim(vform.keyfield & "")
                mname.Text = Trim(vform.keyfield1 & "")
                membertype.Text = Trim(vform.keyfield2 & "")
            End If
            vform.Close()
            vform = Nothing
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'cmdadd.Text = "Update[F5]"
    End Sub

    Private Sub Advance_Subscription_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Paymentmode()
        getReceiptsNo()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Show()
        txtmembercode.Focus()
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='MEMBER' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.cmdadd.Enabled = False
        Me.cmdprint.Enabled = False
        Me.cmdview.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.cmdadd.Enabled = True
                    Me.cmdprint.Enabled = True
                    Me.cmdview.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.cmdadd.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.cmdadd.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.cmdadd.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    'Me.cmd_Delete.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.cmdview.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.cmdprint.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub txtmembercode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmembercode.TextChanged

    End Sub

    Private Sub txtmembercode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmembercode.Validated
        Dim sqlstring, totalamt, totaltax, Taxamount, totaldisc, totalsubs, Totalamount, sqlstring1 As String
        Dim j As Integer
        Try
            If Trim(txtmembercode.Text) <> "" Then
                Txt_Postage.Enabled = True
                sqlstring = "SELECT MCODE,MNAME,membertype,membertypecode FROM MEMBERMASTER WHERE MCODE='" & Trim(txtmembercode.Text) & "'"
                gconnection.getDataSet(sqlstring, "MEMBER")
                If gdataset.Tables("MEMBER").Rows.Count > 0 Then
                    txtmembercode.Text = Trim(gdataset.Tables("MEMBER").Rows(0).Item("MCODE"))
                    mname.Text = Trim(gdataset.Tables("MEMBER").Rows(0).Item("MNAME"))
                    membertype.Text = Trim(gdataset.Tables("MEMBER").Rows(0).Item("membertype"))
                    MEBERTYPECODE.Text = Trim(gdataset.Tables("MEMBER").Rows(0).Item("membertypecode"))
                    sqlstring = "select * from subscriptionreceipts where receiptsno='" & Me.Txt_ReceiptsNo.Text & "'"
                    gconnection.getDataSet(sqlstring, "subs")
                    If gdataset.Tables("subs").Rows.Count > 0 Then
                    Else
                        sqlstring = "select top 1 fromdate,todate,slcode from subscriptionreceipts where slcode='" & Me.txtmembercode.Text & "'and isnull(freeze,'')<>'y' order by todate desc "
                        gconnection.getDataSet(sqlstring, "subs1")
                        If gdataset.Tables("subs1").Rows.Count > 0 Then
                            Me.dtp_premonthfrom.Value = Format(CDate(gdataset.Tables("subs1").Rows(0).Item("fromdate")), "dd-MMM-yyyy")
                            Me.dtp_premonthto.Value = Format(CDate(gdataset.Tables("subs1").Rows(0).Item("todate")), "dd-MMM-yyyy")
                            With ssgrid_Fac
                                For j = 0 To gdataset.Tables("subs1").Rows.Count - 1
                                    .Col = 4
                                    .Row = j + 1
                                    .Text = Format(CDate(gdataset.Tables("subs1").Rows(j).Item("ToDate")), "dd/MM/yyy")
                                    Fromdate = .Text
                                    .Col = 5
                                    .Row = j + 1
                                    .Text = Format(CDate(Fromdate.AddMonths(1)), "dd/MM/yyy")
                                    todate = .Text
                                    MonthsDiff = FormatNumber(((DateDiff(DateInterval.Day, Fromdate, todate) / 7) / 4.33), 2)
                                Next j
                            End With
                        End If
                    End If
                    ssgrid_Fac.ClearRange(1, 1, -1, 1 - 1, True)
                    sqlstring = "select ISNULL(m.membertype,'') as membertype,ISNULL(M.SUBSCODE,'') AS SUBSCODE,t.subtypedesc,ISNULL(S.SUBSDESC,'') AS SUBSDESC,s.subsacctin,ISNULL(S.TOTAL,0) AS TOTAL,ISNULL(S.TAXTOTAL,0)AS TAXTOTAL from membertypedtl m, subcategorymaster t, subscriptionmast s where m.membertype=t.subtypecode and m.subscode=s.subscode and m.membertype=s.subscode and t.subtypecode='" & Trim(MEBERTYPECODE.Text) & "'"
                    gconnection.getDataSet(sqlstring, "SUBS")
                    If gdataset.Tables("SUBS").Rows.Count > 0 Then
                        With ssgrid_Fac
                            For j = 0 To gdataset.Tables("SUBS").Rows.Count - 1
                                .Col = 1
                                .Row = j + 1
                                .Lock = True
                                .Text = gdataset.Tables("SUBS").Rows(j).Item("SUBSCODE")
                                .Col = 2
                                .Row = j + 1
                                .Lock = True
                                .Text = gdataset.Tables("SUBS").Rows(j).Item("SUBSDESC")
                                .Col = 3
                                .Row = j + 1
                                .Lock = True
                                .Text = gdataset.Tables("SUBS").Rows(j).Item("TOTAL")
                                totalsubs = Val(.Text)
                                .Col = 6
                                .Row = j + 1
                                .Lock = True
                                .Text = gdataset.Tables("SUBS").Rows(j).Item("TAXTOTAL")
                                totaltax = Val(.Text)
                                .Col = 7
                                .Row = j + 1
                                totaldisc = Val(.Text)
                                .SetActiveCell(8, j)
                                .Focus()
                                .Col = 8
                                .Row = j + 1
                                .Lock = True
                                .Text = (Val(totalsubs) - Val(totaldisc))
                                totalamt = Val(.Text)
                                .SetText(8, j + 1, totalamt)
                                Totalamount = Format((Val(Totalamount) * Val(MonthsDiff)) + Val(totalamt), "0.00")
                                .Col = 9
                                .Row = j + 1
                                .Lock = True
                                .Text = (Val(Totalamount) + Val(totaltax))
                                Taxamount = Val(.Text)
                                txt_Total.Text = Taxamount
                            Next
                        End With
                    Else
                        MessageBox.Show("This Membership Not in Subcription category")
                        Exit Sub
                    End If
                Else
                    txtmembercode.Text = ""
                    mname.Text = ""
                    membertype.Text = ""
                    txtmembercode.Focus()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtmembercode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtmembercode.LostFocus

    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub cmdclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdclear.Click
        txtmembercode.Text = ""
        mname.Text = ""
        membertype.Text = ""
        Txt_Postage.Text = ""
        dtp_premonthfrom.Text = ""
        dtp_premonthto.Text = ""
        'dtp_monthfrom.Text = ""
        'dtp_monthto.Text = ""
        Txt_Postage.Enabled = True
        cmdadd.Enabled = True
        Txt_instrumentno.Text = ""
        dtp_instrumentdate.Text = ""
        cbo_paymentmode.Text = ""
        Me.lbl_Frez.Visible = False
        Me.lbl_Frez.Text = "Record Freezed  On "
        Me.cmd_Delete.Text = "Freeze[F7]"
        txt_Total.Text = ""
        cbo_paymentmode.Text = ""
        Gbx_details.Visible = False
        txtmembercode.Focus()
        Me.ssgrid_Fac.ClearRange(1, 1, -1, -1, True)
        Call getReceiptsNo()
    End Sub
    Public Sub Paymentmode()
        Dim i As Integer
        Dim sqlstring As String
        sqlstring = "SELECT distinct(PaymentCode) FROM PAYMENTMODEMASTER WHERE isnull(delflag,'')<>'Y'"
        dt = gconnection.GetValues(sqlstring)
        Dim Itration
        For Itration = 0 To (dt.Rows.Count - 1)
            cbo_paymentmode.Items.Add(dt.Rows(Itration).Item("PaymentCode"))
        Next
    End Sub

    Private Sub cbo_paymentmode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If cbo_paymentmode.Text = "CHEQUE" Then
            Gbx_details.Visible = True
        ElseIf cbo_paymentmode.Text = "CARD" Then
            Gbx_details.Visible = True
        Else
            Gbx_details.Visible = False
        End If
    End Sub

    Private Sub cmdadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdadd.Click
        Dim strSQL, SUBSCODE, SUBSDESC, RATE, TAX, DISC, TOTALAMOUNT As String
        Dim FROMDATE, TODATE As Date
        Dim i As Integer
        If cmdadd.Text = "Add New[F5]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            For i = 1 To ssgrid_Fac.DataRowCnt Step 1
                strSQL = "INSERT INTO Subscriptionreceipts(ReceiptsNo,ReceiptsDate,SLCode,Slname,Membertype,PreviousDate_From,PreviousDate_To,FromDate,ToDate,SubsCODE,SubsDESC,SubsAmount,Taxamount,Discount,Amount,Totalamount,PaymentMode,Instrumentno,InstrumentDate,BankName,Bankplace,Freeze,Postage)"
                strSQL = strSQL & " VALUES ( '" & Trim(Txt_ReceiptsNo.Text) & "',Convert(datetime,'" & (dtp_ReceiptsDate.Text) & "',103),'" & Trim(txtmembercode.Text) & "','" & mname.Text & "','" & membertype.Text & "',Convert(datetime,'" & (dtp_premonthfrom.Text) & "',103),Convert(datetime,'" & (dtp_premonthto.Text) & "',103), Convert(datetime,'"
                ssgrid_Fac.Col = 4
                ssgrid_Fac.Row = i
                strSQL = strSQL & Trim(ssgrid_Fac.Text) & "',103),Convert(datetime,'"
                ssgrid_Fac.Col = 5
                ssgrid_Fac.Row = i
                strSQL = strSQL & Trim(ssgrid_Fac.Text) & "',103),'"

                ssgrid_Fac.Col = 1
                ssgrid_Fac.Row = i
                strSQL = strSQL & Trim(ssgrid_Fac.Text) & "','"
                SUBSCODE = Trim(ssgrid_Fac.Text)

                ssgrid_Fac.Col = 2
                ssgrid_Fac.Row = i
                strSQL = strSQL & Trim(ssgrid_Fac.Text) & "','"
                SUBSDESC = Trim(ssgrid_Fac.Text)

                ssgrid_Fac.Col = 3
                ssgrid_Fac.Row = i
                strSQL = strSQL & Val(ssgrid_Fac.Text) & "','"
                RATE = Trim(ssgrid_Fac.Text)

                ssgrid_Fac.Col = 6
                ssgrid_Fac.Row = i
                strSQL = strSQL & Val(ssgrid_Fac.Text) & "','"
                TAX = Trim(ssgrid_Fac.Text)

                ssgrid_Fac.Col = 7
                ssgrid_Fac.Row = i
                strSQL = strSQL & Val(ssgrid_Fac.Text) & "','"
                DISC = Trim(ssgrid_Fac.Text)

                ssgrid_Fac.Col = 8
                ssgrid_Fac.Row = i
                strSQL = strSQL & Val(ssgrid_Fac.Text) & "','"
                TOTALAMOUNT = Trim(ssgrid_Fac.Text)
                strSQL = strSQL & Trim(txt_Total.Text) & "','"
                strSQL = strSQL & Trim(cbo_paymentmode.Text) & "','"
                strSQL = strSQL & Trim(Txt_instrumentno.Text) & "',Convert(datetime,'"
                strSQL = strSQL & Trim(dtp_instrumentdate.Text) & "',103),'"
                strSQL = strSQL & Trim(txt_bankname.Text) & "','" & Trim(Txt_Bankplace.Text) & "','N','" & Val(Txt_Postage.Text) & "')"
                gconnection.dataOperation(1, strSQL, "memdet")
            Next i
            'insert to journalentry
            sqlstring = "Insert into Journalentry"
            sqlstring = sqlstring + "(SLCODE,Voucherno,voucherdate,VoucherCategory,VoucherType,CashBank,AccountCode,AccountcodeDesc,CreditDebit,Amount,InstrumentDate,InstrumentType,Instrumentno,BankName,Bankplace,Void)"
            sqlstring = sqlstring & "  values('" & Trim(txtmembercode.Text) & "','" & Trim(Txt_ReceiptsNo.Text) & "',Convert(datetime,'" & (dtp_ReceiptsDate.Text) & "',103),'BR1','BR1','"
            sqlstring = sqlstring & Trim(cbo_paymentmode.Text) & "','SDRS','SUNDRY DEBTORS','CREDIT','" & Trim(txt_Total.Text) & "',Convert(datetime,'"
            sqlstring = sqlstring & Trim(dtp_instrumentdate.Text) & "',103),'"
            sqlstring = sqlstring & Trim(cbo_paymentmode.Text) & "','"
            sqlstring = sqlstring & Trim(Txt_instrumentno.Text) & "','"
            sqlstring = sqlstring & Trim(txt_bankname.Text) & "','" & Trim(Txt_Bankplace.Text) & "','N')"
            gconnection.dataOperation(1, sqlstring, "Journalentry")
            Call cmdview_Click(sender, e)
            MessageBox.Show("Transaction Completed Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmdclear_Click(sender, e)
        End If
    End Sub

    Public Sub checkValidation()
        boolchk = True
        Dim ssql, type0(0) As String
        Try
            validity = True
            If txtmembercode.Text = "" Then
                MessageBox.Show(" Please Enter Membership No", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                validity = False
                boolchk = False
                Exit Sub
            Else
                boolchk = True
            End If
            If Txt_ReceiptsNo.Text = "" Then
                MessageBox.Show(" Please Enter ReceiptsNo ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                validity = False
                boolchk = False
                Exit Sub
            Else
                boolchk = True
            End If
            If cbo_paymentmode.Text = "" Then
                MessageBox.Show(" Please Select PaymentMode ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                validity = False
                boolchk = False
                Exit Sub
            Else
                boolchk = True
            End If

            If cbo_paymentmode.Text = "CHEQUE" And Txt_instrumentno.Text = "" And txt_bankname.Text = "" Then
                MessageBox.Show(" Please Enter PaymentDetails ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                validity = False
                boolchk = False
                Exit Sub
            ElseIf cbo_paymentmode.Text = "CARD" And Txt_instrumentno.Text = "" And txt_bankname.Text = "" Then
                MessageBox.Show(" Please Enter PaymentDetails ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                validity = False
                boolchk = False
                Exit Sub
            Else
                boolchk = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub getReceiptsNo()
        Dim receiptsno, financalyear As String
        Dim doc As Integer
        sqlstring = "Select ISNULL(MAX(ISNULL(CAST(ISNULL(ReceiptsNo,0) AS NUMERIC),0)),0) + 1  AS  ReceiptsNo FROM Subscriptionreceipts "
        gconnection.getDataSet(sqlstring, "Maxvalues")
        If gdataset.Tables("Maxvalues").Rows.Count > 0 Then
            Txt_ReceiptsNo.Text = gdataset.Tables("Maxvalues").Rows(0).Item("ReceiptsNo")
            'Txt_ReceiptsNo.Text = "SUBSR/" & Trim(receiptsno)
            txtmembercode.Focus()
        End If

    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click

    End Sub

    Private Sub txtmembercode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmembercode.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call cmdmemberhelp_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            Call txtmembercode_Validated(sender, e)
        End If
    End Sub



    Private Sub ssgrid_Fac_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid_Fac.Advance

    End Sub

    Private Sub ssgrid_Fac_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid_Fac.LeaveCell
        'Dim MonthsDiff As Double
        'Dim Fromdate, Todate As Date
        'Dim i, j As Integer
        ''Me.txt_Total.Text = "0.00"
        'With ssgrid_Fac
        '    For i = 1 To .DataRowCnt
        '        .Col = 4
        '        .Row = i
        '        Fromdate = .Text
        '        .Col = 5
        '        .Row = i
        '        Todate = .Text
        '        MonthsDiff = FormatNumber(((DateDiff(DateInterval.Day, Fromdate, Todate) / 7) / 4.33), 2)
        '    Next
        'End With
    End Sub

    Private Sub ssgrid_Fac_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid_Fac.KeyDownEvent
        Dim sqlstring As String
        Dim j As Integer
        Dim ssql, TYPE, name As String
        Dim I As Integer
        If e.keyCode = Keys.F3 Then
            ssgrid_Fac.Row = ssgrid_Fac.ActiveRow
            ssgrid_Fac.ClearRange(1, ssgrid_Fac.ActiveRow, 1, ssgrid_Fac.ActiveRow, True)
            ssgrid_Fac.DeleteRows(ssgrid_Fac.ActiveRow, 1)
            ssgrid_Fac.SetActiveCell(1, ssgrid_Fac.ActiveRow)
            ssgrid_Fac.Focus()
        End If
        'If e.keyCode = Keys.Enter Then
        '    Call Calculate()
        'End If
        If e.keyCode = Keys.Enter Or e.keyCode = Keys.F4 Then
            With ssgrid_Fac
                If .ActiveCol = 1 Then
                    .Col = 1
                    .Row = .ActiveRow
                    TYPE = .Text
                    If Trim(.Text) = "" Then
                        Call Subscription()
                    Else
                        'Call Calculate()
                    End If
                End If
            End With
            Call Calculate()
        End If

    End Sub
    Private Sub Calculate()
        Dim MonthsDiff As Integer
        Dim Fromdate, Todate As Date
        Dim total, totaldisc, totalsubs, Taxamount, totaltax, Totalamount As Integer
        Dim i, j As Integer
        Me.txt_Total.Text = "0.00"
        With ssgrid_Fac
            For i = 1 To .DataRowCnt
                .Col = 3
                .Row = i
                totalsubs = Val(.Text)
                .Col = 4
                .Row = i
                Fromdate = .Text
                .Col = 5
                .Row = i
                Todate = .Text
                MonthsDiff = FormatNumber(((DateDiff(DateInterval.Day, Fromdate, Todate) / 7) / 4.33), 2)
                .Col = 6
                .Row = i
                totaltax = Val(.Text)
                .Col = 7
                .Row = i
                totaldisc = Val(.Text)
                If Val(totalsubs) > 0 Then
                    Totalamount = ((Val(totalsubs) * Val(MonthsDiff)) - Val(totaldisc))
                End If
                .Col = 9
                .Row = i
                .Text = (Val(Totalamount) + Val(totaltax))
                Taxamount = Val(.Text)
                .SetText(8, i, Taxamount)
                Me.txt_Total.Text = Format(Val(Me.txt_Total.Text) + Val(Taxamount), "0.00")
            Next
        End With
    End Sub
    Private Sub Subscription()
        Try
            Dim vform As New ListOperattion1
            Dim ssql As String
            '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
            gSQLString = " SELECT ISNULL(SUBSDESC,'') AS SUBSDESC,ISNULL(SUBSCODE,'') AS SUBSCODE,ISNULL(TOTAL,0) AS AMOUNT,ISNULL(TAXTOTAL,0) AS TAXAMOUNT FROM SUBSCRIPTIONMAST "
            vform.Field = "SUBSCODE,SUBSDESC,TOTAL,TAXTOTAL"
            vform.vFormatstring = "     SUBSCODE                      |      SUBSDESC                      |       AMOUNT        |      TAXAMOUNT        |"
            vform.vCaption = "NAME  HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.Keypos3 = 3
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                With ssgrid_Fac
                    .Col = 1
                    .Row = .ActiveRow
                    .Text = vform.keyfield1
                    .Col = 2
                    .Row = .ActiveRow
                    .Text = vform.keyfield
                    .Col = 3
                    .Row = .ActiveRow
                    .Text = vform.keyfield2
                    .Col = 4
                    .Row = .ActiveRow
                    .Text = Format(CDate(Now.Date), "dd/MM/yyyy")
                    .Col = 5
                    .Row = .ActiveRow
                    .Text = Format(CDate(Now.Date), "dd/MM/yyyy")
                    .Col = 6
                    .Row = .ActiveRow
                    .Text = vform.keyfield3
                End With
            Else
                ssgrid_Fac.SetActiveCell(0, ssgrid_Fac.ActiveRow)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtmembercode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtmembercode.Validating

    End Sub

    Private Sub Txt_ReceiptsNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub cmdview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdview.Click
        sqlstring = "Select ReceiptsNo,ReceiptsDate,PreviousDate_from,PreviousDate_To,FromDate,ToDate,Slcode,Slname,subsCode,Subsdesc,Subsamount,TaxAmount,Discount,Amount,TotalAmount,Paymentmode,Instrumentno,InstrumentDate,Bankname,Membertype,isnull(Freeze,'') as Freeze,AddDateTime from Subscriptionreceipts where ReceiptsNo='" & Trim(Txt_ReceiptsNo.Text) & "'"
        gconnection.getDataSet(sqlstring, "SUBS")
        If gdataset.Tables("SUBS").Rows.Count > 0 Then
            sqlstring = "select * from MM_View_subscriptionreceipts where ReceiptsNo='" & Trim(Txt_ReceiptsNo.Text) & "'"
            Dim Viewer As New ReportViwer
            ''Dim r As New Cry_SubcriptionReceipts
            'txtobj1 = r.ReportDefinition.ReportObjects("Text25")
            ''txtobj1.Text = UCase(SERVICETAXNO)
            'txtobj1 = r.ReportDefinition.ReportObjects("Text14")
            'txtobj1.Text = UCase(MyCompanyName)
            'txtobj1 = r.ReportDefinition.ReportObjects("Text15")
            'txtobj1.Text = UCase(gCompanyAddress(1))
            'txtobj1 = r.ReportDefinition.ReportObjects("Text16")
            'txtobj1.Text = UCase(gCompanyAddress(2))
            'txtobj1 = r.ReportDefinition.ReportObjects("Text17")
            'txtobj1.Text = UCase(gCompanyAddress(3))
            'txtobj1 = r.ReportDefinition.ReportObjects("Text39")
            'txtobj1.Text = UCase(gCompanyAddress(5))
            'txtobj1 = r.ReportDefinition.ReportObjects("Text13")
            'txtobj1.Text = UCase(gUsername)
            'Viewer.ssql = sqlstring
            'Viewer.Report = r
            Viewer.TableName = "MM_View_subscriptionreceipts"
            Viewer.Show()
        Else
            MessageBox.Show("ReceiptNo Does't Belongs To Subcription", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

    End Sub

    Private Sub dtp_premonthto_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_premonthto.ValueChanged

    End Sub
    Private Function GetFirstDayOfMonth()
        'Dim Fromdate, Todate As Date
        'Dim i As Integer
        'With ssgrid_Fac
        '    For i = 1 To .DataRowCnt
        '        .Col = 4
        '        .Row = i
        '        Fromdate = .Text
        '        Fromdate = Fromdate.AddDays(-(Fromdate.Day - 1))
        '        Return Fromdate
        '    Next
        'End With

    End Function

    Private Function GetLastDayOfMonth(ByVal dtDate As DateTime) As DateTime
        Dim dtTo As New DateTime(dtDate.Year, dtDate.Month, 1)
        dtTo = dtTo.AddMonths(1)
        dtTo = dtTo.AddDays(-(dtTo.Day))
        Return dtTo
    End Function

    Private Sub Cmd_receiptsNohelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_receiptsNohelp.Click
        Dim vform As New ListOperattion1
        Try
            gSQLString = "SELECT ISNULL(MCODE,'') AS MCODE,ISNULL(MNAME,'') AS MNAME,ISNULL(Membertype,'') AS Membertype FROM membermaster"
            M_WhereCondition = " "
            listop = ""
            vform.Field = "MCODE,MNAME,MEMBERTYPE"
            vform.vFormatstring = "  Member Code  | Member Name  |Membertype       "
            vform.vCaption = "Member Master Help"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtmembercode.Text = Trim(vform.keyfield & "")
                mname.Text = Trim(vform.keyfield1 & "")
                membertype.Text = Trim(vform.keyfield2 & "")
            End If
            vform.Close()
            vform = Nothing
            If gUserCategory <> "S" Then
                Call GetRights()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        'cmdadd.Text = "Update[F5]"
    End Sub

    Private Sub Txt_ReceiptsNo_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_ReceiptsNo.TextChanged

    End Sub

    Private Sub Txt_ReceiptsNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_ReceiptsNo.Validated
        Dim sqlstring, totalamt, totaltax, totaldisc, totalsubs, Totalamount, sqlstring1 As String
        Dim j As Integer
        'Dim SUBS As New DataTable
        Dim Fromdate As Date
        'Me.txt_Total.Text = "0.00"
        Dim MonthsDiff As Double
        Dim dt1 As Date
        Dim dt2 As Date
        'dtp_premonthfrom.Value = d1
        'dtp_premonthto.Value = d2
        'MonthsDiff = FormatNumber(((DateDiff(DateInterval.Day, dtp_premonthfrom.Value, dtp_premonthto.Value) / 7) / 4.33), 2)
        Try
            If Trim(Txt_ReceiptsNo.Text) <> "" Then
                ssgrid_Fac.ClearRange(1, 1, -1, 1 - 1, True)
                sqlstring = "Select isnull(ReceiptsNo,'') as ReceiptsNo,isnull(ReceiptsDate,'') as ReceiptsDate ,isnull(PreviousDate_from,'') as PreviousDate_from,isnull(PreviousDate_To,'')as PreviousDate_To,isnull(FromDate,'') as FromDate,isnull(ToDate,'') as ToDate,isnull(Slcode,'')as Slcode,isnull(Slname,'') as Slname,isnull(subsCode,'') as subsCode,isnull(Subsdesc,'') as Subsdesc,isnull(Subsamount,0) as Subsamount,isnull(TaxAmount,0) as TaxAmount,isnull(Discount,0)as Discount,isnull(Amount,0) as Amount,isnull(TotalAmount,0) as TotalAmount,isnull(Paymentmode,'') as Paymentmode,isnull(Instrumentno,'')as Instrumentno,isnull(InstrumentDate,'') as InstrumentDate,isnull(Bankname,'') as Bankname,isnull(BankPlace,'') as Bankplace,isnull(Membertype,'') as Membertype,isnull(Freeze,'') as Freeze,AddDateTime,Isnull(Postage,0)as Postage from Subscriptionreceipts where ReceiptsNo='" & Trim(Txt_ReceiptsNo.Text) & "'"
                gconnection.getDataSet(sqlstring, "SUBS")
                If gdataset.Tables("SUBS").Rows.Count > 0 Then
                    txtmembercode.Text = Trim(gdataset.Tables("SUBS").Rows(0).Item("Slcode"))
                    mname.Text = Trim(gdataset.Tables("SUBS").Rows(0).Item("Slname"))
                    membertype.Text = Trim(gdataset.Tables("SUBS").Rows(0).Item("membertype"))
                    With ssgrid_Fac
                        For j = 0 To gdataset.Tables("SUBS").Rows.Count - 1
                            .Col = 1
                            .Row = j + 1
                            .Lock = True
                            .Text = gdataset.Tables("SUBS").Rows(j).Item("SUBSCODE")
                            .Col = 2
                            .Row = j + 1
                            .Lock = True
                            .Text = gdataset.Tables("SUBS").Rows(j).Item("SUBSDESC")
                            .Col = 3
                            .Row = j + 1
                            .Lock = True
                            .Text = gdataset.Tables("SUBS").Rows(j).Item("Subsamount")
                            totalsubs = Val(.Text)
                            .Col = 4
                            .Row = j + 1
                            .Text = Format(CDate(gdataset.Tables("SUBS").Rows(j).Item("FromDate")), "dd/MM/yyy")
                            .Col = 5
                            .Row = j + 1
                            .Text = Format(CDate(gdataset.Tables("SUBS").Rows(j).Item("TODATE")), "dd/MM/yyy")
                            .Col = 6
                            .Row = j + 1
                            .Lock = True
                            .SetActiveCell(7, j)
                            .Focus()
                            .Text = gdataset.Tables("SUBS").Rows(j).Item("TaxAmount")
                            totaltax = Val(.Text)
                            .Col = 7
                            .Row = j + 1
                            .Text = gdataset.Tables("SUBS").Rows(j).Item("Discount")
                            .SetActiveCell(8, j)
                            .Focus()
                            .Col = 8
                            .Row = j + 1
                            .Lock = True
                            .Text = gdataset.Tables("SUBS").Rows(j).Item("Amount")

                        Next
                    End With
                    dtp_premonthfrom.Text = Format(CDate(gdataset.Tables("SUBS").Rows(0).Item("PreviousDate_from")), "dd/MM/yyyy")
                    dtp_premonthto.Text = Format(CDate(gdataset.Tables("SUBS").Rows(0).Item("PreviousDate_To")), "dd/MM/yyyy")
                    txt_Total.Text = Trim(gdataset.Tables("SUBS").Rows(0).Item("TotalAmount"))
                    cbo_paymentmode.Text = Trim(gdataset.Tables("SUBS").Rows(0).Item("Paymentmode"))
                    Txt_instrumentno.Text = Trim(gdataset.Tables("SUBS").Rows(0).Item("Instrumentno"))
                    dtp_instrumentdate.Text = Trim(gdataset.Tables("SUBS").Rows(0).Item("InstrumentDate"))
                    txt_bankname.Text = Trim(gdataset.Tables("SUBS").Rows(0).Item("Bankname"))
                    Txt_Bankplace.Text = Trim(gdataset.Tables("SUBS").Rows(0).Item("Bankplace"))
                    Txt_Postage.Text = Trim(gdataset.Tables("SUBS").Rows(0).Item("Postage"))
                    cmdadd.Enabled = False
                    If gdataset.Tables("SUBS").Rows(0).Item("Freeze") = "Y" Then
                        Me.lbl_Frez.Visible = True
                        Me.lbl_Frez.Text = Me.lbl_Frez.Text & Format(gdataset.Tables("SUBS").Rows(0).Item("AddDateTime"), "dd-MMM-yyyy")
                        Me.cmd_Delete.Text = "UnFreeze[F7]"
                    Else
                        Me.lbl_Frez.Visible = False
                        Me.lbl_Frez.Text = "Record Freezed  On "
                        Me.cmd_Delete.Text = "Freeze[F7]"
                    End If
                    'Me.cmdadd.Text = "Update[F5]"
                Else
                    MessageBox.Show("This Membership Not in Subcription category", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Else
                txtmembercode.Text = ""
                mname.Text = ""
                membertype.Text = ""
                txtmembercode.Focus()
            End If
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Txt_ReceiptsNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_ReceiptsNo.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call Cmd_receiptsNohelp_Click(sender, e)
        ElseIf e.KeyCode = Keys.Enter Then
            Call Txt_ReceiptsNo_Validated(sender, e)
        End If
    End Sub

    Private Sub cbo_paymentmode_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbo_paymentmode.SelectedIndexChanged
        If cbo_paymentmode.Text = "CHEQUE" Then
            Gbx_details.Visible = True
        ElseIf cbo_paymentmode.Text = "CARD" Then
            Gbx_details.Visible = True
        Else
            Gbx_details.Visible = False
        End If
    End Sub

    Private Sub cmd_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Delete.Click
        Call checkValidation()
        'If boolchk = False Then Exit Sub
        If Mid(Me.cmd_Delete.Text, 1, 1) = "F" Then
            sqlstring = "UPDATE  subscriptionreceipts "
            sqlstring = sqlstring & " SET Freeze= 'Y',AddUserId='" & gUsername & " ', AddDatetime='" & Format(Date.Now, "dd-MMM-yyyy hh:mm") & "'"
            sqlstring = sqlstring & " WHERE Receiptsno = '" & Txt_ReceiptsNo.Text & " '"
            gconnection.dataOperation(3, sqlstring, "MemberType")

            MessageBox.Show("Record Freezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmdclear_Click(sender, e)
            cmdadd.Text = "Add New[F5]"
        Else
            sqlstring = "UPDATE  subscriptionreceipts "
            sqlstring = sqlstring & " SET Freeze= 'N',AddUserId='" & gUsername & " ', AddDatetime='" & Format(Date.Now, "dd-MMM-yyyy hh:mm") & "'"
            sqlstring = sqlstring & " WHERE Receiptsno = '" & Txt_ReceiptsNo.Text & " '"
            gconnection.dataOperation(4, sqlstring, "MemberType")

            MessageBox.Show("Record UNFreezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.cmdclear_Click(sender, e)
            cmdadd.Text = "Add New[F5]"
        End If
    End Sub

    Private Sub Advance_Subscription_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try

            If e.KeyCode = Keys.F5 Then
                If cmdadd.Enabled = True Then
                    Call cmdadd_Click(sender, e)
                    Exit Sub
                End If
            ElseIf e.KeyCode = Keys.F4 Then
                If cmdclear.Enabled = True Then
                    Call Subscription()
                    Exit Sub
                End If
            ElseIf e.KeyCode = Keys.F6 Then
                If cmdclear.Enabled = True Then
                    Call cmdclear_Click(sender, e)
                    Exit Sub
                End If
            ElseIf e.KeyCode = Keys.F9 Then
                If cmdview.Enabled = True Then
                    Call cmdview_Click(sender, e)
                    Exit Sub
                End If
            ElseIf e.KeyCode = Keys.F7 Then
                If cmd_Delete.Enabled = True Then
                    Call cmd_Delete_Click(sender, e)
                    Exit Sub
                End If
            ElseIf e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
                If cmdexit.Enabled = True Then
                    Call cmdexit_Click(sender, e)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Txt_instrumentno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_instrumentno.TextChanged

    End Sub

    Private Sub Txt_instrumentno_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_instrumentno.KeyDown
        If e.KeyCode = Keys.Enter Then
            txt_bankname.Focus()
        End If
    End Sub

    Private Sub txt_bankname_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_bankname.TextChanged

    End Sub

    Private Sub txt_bankname_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_bankname.KeyDown
        If e.KeyCode = Keys.Enter Then
            Txt_Bankplace.Focus()
        End If
    End Sub

    Private Sub MEBERTYPECODE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MEBERTYPECODE.Click

    End Sub

    Private Sub membertype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles membertype.Click

    End Sub
End Class
