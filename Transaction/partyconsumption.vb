Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Imports System.IO
Public Class partyconsumption
    Inherits System.Windows.Forms.Form
    Dim DT, DT1 As New DataTable
    Dim DS As New DataSet
    Dim SSQL As String
    Dim GCONNECTION As New GlobalClass
    Dim BOOLCHK As Boolean
    Dim DTPRECDATE As Date
    Dim I, J, K As Integer
    Dim CANCEL As Boolean
    Dim QTY, RATE, TAXAMOUNT, AMOUNT, ROUNDOFF, TAXPER, HALLTAXPERC, CAMOUNT, totalamount As Double
    Dim UOM, ITEMCODE, ITEMDESC, CHITNO As String
    Dim CDAY, pagesize, pageno As Integer
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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents SSGRID1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Cmd_BookingNo As System.Windows.Forms.Button
    Friend WithEvents TXTBOOKINGNO As System.Windows.Forms.TextBox
    Friend WithEvents cmd_mcodehelp As System.Windows.Forms.Button
    Friend WithEvents TXTMCODE As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DTPPARTYDATE As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TXTMNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TXTDESCRIPTION As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents labbooking As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_print As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_report As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents CMB_LOCATION As System.Windows.Forms.ComboBox
    Friend WithEvents lvw_Uom As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents TXT_TOTAL As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(partyconsumption))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.TXT_TOTAL = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.SSGRID1 = New AxFPSpreadADO.AxfpSpread
        Me.Cmd_BookingNo = New System.Windows.Forms.Button
        Me.TXTBOOKINGNO = New System.Windows.Forms.TextBox
        Me.cmd_mcodehelp = New System.Windows.Forms.Button
        Me.TXTMCODE = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DTPPARTYDATE = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.TXTMNAME = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TXTDESCRIPTION = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.labbooking = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmd_print = New System.Windows.Forms.Button
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.Cmd_View = New System.Windows.Forms.Button
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Cmd_report = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label36 = New System.Windows.Forms.Label
        Me.CMB_LOCATION = New System.Windows.Forms.ComboBox
        Me.lvw_Uom = New System.Windows.Forms.ListView
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.GroupBox3.SuspendLayout()
        CType(Me.SSGRID1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.TXT_TOTAL)
        Me.GroupBox3.Controls.Add(Me.Label29)
        Me.GroupBox3.Controls.Add(Me.SSGRID1)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox3.Location = New System.Drawing.Point(32, 192)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(888, 216)
        Me.GroupBox3.TabIndex = 856
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Hall Facility"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(64, Byte))
        Me.Label28.Location = New System.Drawing.Point(584, 192)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(135, 23)
        Me.Label28.TabIndex = 404
        Me.Label28.Text = "TOTAL AMOUNT"
        '
        'TXT_TOTAL
        '
        Me.TXT_TOTAL.BackColor = System.Drawing.Color.Wheat
        Me.TXT_TOTAL.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXT_TOTAL.Location = New System.Drawing.Point(728, 184)
        Me.TXT_TOTAL.MaxLength = 12
        Me.TXT_TOTAL.Name = "TXT_TOTAL"
        Me.TXT_TOTAL.ReadOnly = True
        Me.TXT_TOTAL.Size = New System.Drawing.Size(128, 27)
        Me.TXT_TOTAL.TabIndex = 403
        Me.TXT_TOTAL.Text = ""
        Me.TXT_TOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label29.Location = New System.Drawing.Point(0, -24)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(116, 20)
        Me.Label29.TabIndex = 392
        Me.Label29.Text = "HALL FACILITY"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SSGRID1
        '
        Me.SSGRID1.ContainingControl = Me
        Me.SSGRID1.DataSource = Nothing
        Me.SSGRID1.Location = New System.Drawing.Point(16, 16)
        Me.SSGRID1.Name = "SSGRID1"
        Me.SSGRID1.OcxState = CType(resources.GetObject("SSGRID1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID1.Size = New System.Drawing.Size(848, 169)
        Me.SSGRID1.TabIndex = 21
        '
        'Cmd_BookingNo
        '
        Me.Cmd_BookingNo.Image = CType(resources.GetObject("Cmd_BookingNo.Image"), System.Drawing.Image)
        Me.Cmd_BookingNo.Location = New System.Drawing.Point(640, 48)
        Me.Cmd_BookingNo.Name = "Cmd_BookingNo"
        Me.Cmd_BookingNo.Size = New System.Drawing.Size(24, 26)
        Me.Cmd_BookingNo.TabIndex = 859
        '
        'TXTBOOKINGNO
        '
        Me.TXTBOOKINGNO.BackColor = System.Drawing.Color.Wheat
        Me.TXTBOOKINGNO.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TXTBOOKINGNO.Location = New System.Drawing.Point(536, 48)
        Me.TXTBOOKINGNO.MaxLength = 30
        Me.TXTBOOKINGNO.Name = "TXTBOOKINGNO"
        Me.TXTBOOKINGNO.Size = New System.Drawing.Size(96, 26)
        Me.TXTBOOKINGNO.TabIndex = 858
        Me.TXTBOOKINGNO.Text = ""
        '
        'cmd_mcodehelp
        '
        Me.cmd_mcodehelp.Image = CType(resources.GetObject("cmd_mcodehelp.Image"), System.Drawing.Image)
        Me.cmd_mcodehelp.Location = New System.Drawing.Point(296, 104)
        Me.cmd_mcodehelp.Name = "cmd_mcodehelp"
        Me.cmd_mcodehelp.Size = New System.Drawing.Size(24, 26)
        Me.cmd_mcodehelp.TabIndex = 862
        Me.cmd_mcodehelp.Visible = False
        '
        'TXTMCODE
        '
        Me.TXTMCODE.BackColor = System.Drawing.Color.Wheat
        Me.TXTMCODE.Enabled = False
        Me.TXTMCODE.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXTMCODE.Location = New System.Drawing.Point(184, 104)
        Me.TXTMCODE.MaxLength = 15
        Me.TXTMCODE.Name = "TXTMCODE"
        Me.TXTMCODE.Size = New System.Drawing.Size(104, 27)
        Me.TXTMCODE.TabIndex = 861
        Me.TXTMCODE.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(40, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 23)
        Me.Label4.TabIndex = 866
        Me.Label4.Text = "PARTY  DATE"
        '
        'DTPPARTYDATE
        '
        Me.DTPPARTYDATE.CustomFormat = ""
        Me.DTPPARTYDATE.Enabled = False
        Me.DTPPARTYDATE.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTPPARTYDATE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPPARTYDATE.Location = New System.Drawing.Point(184, 152)
        Me.DTPPARTYDATE.Name = "DTPPARTYDATE"
        Me.DTPPARTYDATE.Size = New System.Drawing.Size(112, 27)
        Me.DTPPARTYDATE.TabIndex = 860
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(40, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(124, 23)
        Me.Label5.TabIndex = 867
        Me.Label5.Text = "MEMBER CODE"
        '
        'TXTMNAME
        '
        Me.TXTMNAME.BackColor = System.Drawing.Color.Wheat
        Me.TXTMNAME.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXTMNAME.Location = New System.Drawing.Point(536, 96)
        Me.TXTMNAME.MaxLength = 50
        Me.TXTMNAME.Name = "TXTMNAME"
        Me.TXTMNAME.Size = New System.Drawing.Size(336, 27)
        Me.TXTMNAME.TabIndex = 863
        Me.TXTMNAME.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(400, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 23)
        Me.Label7.TabIndex = 865
        Me.Label7.Text = "MEMBER NAME"
        '
        'TXTDESCRIPTION
        '
        Me.TXTDESCRIPTION.BackColor = System.Drawing.Color.Wheat
        Me.TXTDESCRIPTION.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.TXTDESCRIPTION.Location = New System.Drawing.Point(536, 144)
        Me.TXTDESCRIPTION.MaxLength = 50
        Me.TXTDESCRIPTION.Name = "TXTDESCRIPTION"
        Me.TXTDESCRIPTION.Size = New System.Drawing.Size(336, 27)
        Me.TXTDESCRIPTION.TabIndex = 864
        Me.TXTDESCRIPTION.Text = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(400, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 23)
        Me.Label8.TabIndex = 868
        Me.Label8.Text = "REMARKS"
        '
        'labbooking
        '
        Me.labbooking.AutoSize = True
        Me.labbooking.BackColor = System.Drawing.Color.Transparent
        Me.labbooking.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.labbooking.Location = New System.Drawing.Point(400, 56)
        Me.labbooking.Name = "labbooking"
        Me.labbooking.Size = New System.Drawing.Size(113, 23)
        Me.labbooking.TabIndex = 870
        Me.labbooking.Text = "BOOKING NO"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.cmd_print)
        Me.GroupBox1.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox1.Controls.Add(Me.Cmd_View)
        Me.GroupBox1.Controls.Add(Me.Cmd_Add)
        Me.GroupBox1.Controls.Add(Me.Cmd_report)
        Me.GroupBox1.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox1.Location = New System.Drawing.Point(80, 416)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 56)
        Me.GroupBox1.TabIndex = 871
        Me.GroupBox1.TabStop = False
        '
        'cmd_print
        '
        Me.cmd_print.BackColor = System.Drawing.Color.ForestGreen
        Me.cmd_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_print.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_print.ForeColor = System.Drawing.Color.White
        Me.cmd_print.Image = CType(resources.GetObject("cmd_print.Image"), System.Drawing.Image)
        Me.cmd_print.Location = New System.Drawing.Point(376, 16)
        Me.cmd_print.Name = "cmd_print"
        Me.cmd_print.Size = New System.Drawing.Size(104, 32)
        Me.cmd_print.TabIndex = 29
        Me.cmd_print.Text = "Print[F10]"
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.Location = New System.Drawing.Point(12, 18)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear.TabIndex = 25
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(256, 16)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 27
        Me.Cmd_View.Text = " View[F9]"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.Location = New System.Drawing.Point(136, 16)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add.TabIndex = 24
        Me.Cmd_Add.Text = "Add [F7]"
        '
        'Cmd_report
        '
        Me.Cmd_report.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_report.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_report.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_report.ForeColor = System.Drawing.Color.White
        Me.Cmd_report.Image = CType(resources.GetObject("Cmd_report.Image"), System.Drawing.Image)
        Me.Cmd_report.Location = New System.Drawing.Point(504, 16)
        Me.Cmd_report.Name = "Cmd_report"
        Me.Cmd_report.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_report.TabIndex = 28
        Me.Cmd_report.Text = "Report[F12]"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.Location = New System.Drawing.Point(640, 16)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 28
        Me.Cmd_Exit.Text = "Exit[F11]"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(248, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(424, 32)
        Me.Label1.TabIndex = 872
        Me.Label1.Text = "PARTY BAR & OTHER CONSUMPTION"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label36.Location = New System.Drawing.Point(40, 56)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(135, 23)
        Me.Label36.TabIndex = 874
        Me.Label36.Text = "BOOKING TYPE"
        '
        'CMB_LOCATION
        '
        Me.CMB_LOCATION.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_LOCATION.Location = New System.Drawing.Point(184, 56)
        Me.CMB_LOCATION.Name = "CMB_LOCATION"
        Me.CMB_LOCATION.Size = New System.Drawing.Size(136, 25)
        Me.CMB_LOCATION.TabIndex = 875
        '
        'lvw_Uom
        '
        Me.lvw_Uom.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader4})
        Me.lvw_Uom.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvw_Uom.FullRowSelect = True
        Me.lvw_Uom.GridLines = True
        Me.lvw_Uom.HoverSelection = True
        Me.lvw_Uom.Location = New System.Drawing.Point(480, 80)
        Me.lvw_Uom.Name = "lvw_Uom"
        Me.lvw_Uom.Size = New System.Drawing.Size(368, 146)
        Me.lvw_Uom.TabIndex = 876
        Me.lvw_Uom.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "UOM Code"
        Me.ColumnHeader2.Width = 161
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "UOM Rate"
        Me.ColumnHeader4.Width = 209
        '
        'partyconsumption
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(936, 484)
        Me.Controls.Add(Me.lvw_Uom)
        Me.Controls.Add(Me.CMB_LOCATION)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.TXTBOOKINGNO)
        Me.Controls.Add(Me.TXTMCODE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TXTMNAME)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TXTDESCRIPTION)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.labbooking)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Cmd_BookingNo)
        Me.Controls.Add(Me.DTPPARTYDATE)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmd_mcodehelp)
        Me.Name = "partyconsumption"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "partyconsumption"
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.SSGRID1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_TOTAL.TextChanged

    End Sub

    Private Sub partyconsumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        clearoperaction()
        Call locationfill()
        lvw_Uom.Visible = False
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


            'SQLSTRING = "SELECT ISNULL(TAXPERCENTAGE,0) AS TAXPERCENTAGE FROM TAXITEMLINK WHERE '" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "' BETWEEN STARTINGDATE  AND ISNULL(ENDINGDATE,'" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "') AND ITEMTYPECODE='VAT12'"
            'GCONNECTION.getDataSet(SQLSTRING, "TAXITEMLINK")
            'If gdataset.Tables("TAXITEMLINK").Rows.Count > 0 Then
            '    PRTAXPERC = gdataset.Tables("TAXITEMLINK").Rows(0).Item("TAXPERCENTAGE")
            'Else
            '    PRTAXPERC = 0
            'End If

            'SQLSTRING = "SELECT ISNULL(TAXPERCENTAGE,0) AS TAXPERCENTAGE FROM TAXITEMLINK WHERE '" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "' BETWEEN STARTINGDATE  AND ISNULL(ENDINGDATE,'" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "') AND ITEMTYPECODE='CNTG'"
            'GCONNECTION.getDataSet(SQLSTRING, "TAXITEMLINK")
            'If gdataset.Tables("TAXITEMLINK").Rows.Count > 0 Then
            '    PRTAXPERCCONT = gdataset.Tables("TAXITEMLINK").Rows(0).Item("TAXPERCENTAGE")
            'Else
            '    PRTAXPERCCONT = 0
            'End If
            ''

            'SQLSTRING = "SELECT ISNULL(TAXPERCENTAGE,0) AS TAXPERCENTAGE FROM TAXITEMLINK WHERE '" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "' BETWEEN STARTINGDATE  AND ISNULL(ENDINGDATE,'" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "') AND ITEMTYPECODE='SERTX'"
            'GCONNECTION.getDataSet(SQLSTRING, "TAXITEMLINK")
            'If gdataset.Tables("TAXITEMLINK").Rows.Count > 0 Then
            '    SERVICETAXPERC = gdataset.Tables("TAXITEMLINK").Rows(0).Item("TAXPERCENTAGE")
            'Else
            '    SERVICETAXPERC = 0
            'End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : CATEGORYFILL " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Private Sub clearoperaction()
        TXTMCODE.Enabled = True
        DTPPARTYDATE.Enabled = True
        Me.TXTBOOKINGNO.ReadOnly = False
        Me.Cmd_BookingNo.Enabled = True
        Cmd_Add.Text = "Add [F7]"
        TXTBOOKINGNO.Text = ""
        TXTMCODE.Text = ""
        TXTMNAME.Text = ""
        TXTDESCRIPTION.Text = ""
        SSGRID1.ClearRange(-1, -1, 1, 1, True)
        Show()
        Cmd_Add.Text = "Add [F7]"
        TXTMCODE.Enabled = False
        TXT_TOTAL.Text = "0.00"
        'DTPPARTYDATE.Enabled = False
    End Sub
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
        Me.Cmd_Add.Enabled = False
        'Me.Cmd_Freeze.Enabled = False
        Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    'Me.Cmd_Freeze.Enabled = True
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
                    'Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Cmd_BookingNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_BookingNo.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(BOOKINGNO,0) AS BOOKINGNO,ISNULL(partyDATE,'')AS PARTYDATE,BOOKINGDATE AS BOOKINGDATE,ASSOCIATENAME AS MEMBERNAME,HALLCODE,MCODE,ISNULL(TARIFFCODE,'') AS TARIFFCODE "
        gSQLString = gSQLString & "  FROM  PARTY_HALLBOOKING_HDR"
        If Trim(Search) = " " Then
            M_WhereCondition = " WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
        Else
            M_WhereCondition = " WHERE LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
        End If
        vform.Field = "BOOKINGNO,PARTYDATE,BOOKINGDATE,ASSOCIATENAME,HALLCODE,MCODE,TARIFFCODE"
        vform.vFormatstring = "BOOKINGNO |   PARTYDATE   |  BOOKING DATE  |        MEMBER NAME       |    HALL CODE    |    MEM CODE    |    TARIFF CODE    "
        vform.vCaption = "HALL RESERVATION HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXTBOOKINGNO.Text = Trim(vform.keyfield & "")
            'DTPBOOKINGDATE.Text = Trim(vform.keyfield1 & "")
            Call TXTBOOKINGNO_Validated(sender, e)
            'DTPBOOKINGDATE.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub TXTBOOKINGNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTBOOKINGNO.TextChanged

    End Sub

    Private Sub TXTBOOKINGNO_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTBOOKINGNO.Validated
        Dim D1, D2 As Date
        'D1 = DTPBOOKINGDATE.Value
        'D2 = DTPPARTYDATE.Value
        'CDAY = DateDiff(DateInterval.Day, D1, D2)

        Try
            If Val(TXTBOOKINGNO.Text) > 0 Then
                SSQL = "SELECT ISNULL(BOOKINGFLAG,'') AS BOOKINGFLAG,ISNULL(BILLINGFLAG,'') AS BILLINGFLAG,"
                SSQL = SSQL & "ISNULL(CANCELFLAG,'') AS CANCELFLAG FROM  PARTY_HALLBOOKING_HDR "
                SSQL = SSQL & "WHERE ISNULL(BOOKINGNO, 0) = " & IIf(TXTBOOKINGNO.Text = "", 0, TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                DT = GCONNECTION.GetValues(SSQL)
            Else
                Exit Sub
            End If

            If DT.Rows.Count > 0 Then
                'If DT.Rows(0).Item("CANCELFLAG") = "Y" Then
                '    CANCEL = True
                'Else
                '    CANCEL = False
                'End If
                'If DT.Rows(0).Item("BOOKINGFLAG") = "Y" Then
                'And Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                '                    Bookingstatus.Visible = True
                '                    Bookingstatus.Text = "BOOKING OVER"

                SSQL = "SELECT ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,"
                SSQL = SSQL & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                SSQL = SSQL & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                SSQL = SSQL & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,"
                SSQL = SSQL & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                SSQL = SSQL & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS POCCUPANCY,ISNULL(P.veg,0) AS veg,ISNULL(P.nonveg,0) AS nonveg,"
                SSQL = SSQL & "ISNULL(P.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                SSQL = SSQL & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,"
                SSQL = SSQL & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG FROM PARTY_HDR P"
                SSQL = SSQL & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO AND P.LOCCODE=H.LOCCODE"
                SSQL = SSQL & " where P.Bookingno=" & Trim(TXTBOOKINGNO.Text) & " AND P.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                'SSQL = SSQL & " AND P.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
                DT = GCONNECTION.GetValues(SSQL)
                '        SSQL = "select isnull(sum(amount),0)as amount from party_receipt where LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and bookingno=" & TXTBOOKINGNO.Text & " and isnull(freeze,'')<>'Y'"
                '        GCONNECTION.getDataSet(SSQL, "rec")
                '        If gdataset.Tables("rec").Rows.Count > 0 Then
                '            TXTRESAMOUNT.Text = gdataset.Tables("rec").Rows(0).Item("Amount")
                '        Else
                '            TXTRESAMOUNT.Text = 0.0
                '        End If
                '        'LABBOOKINGSTATUS.Visible = True
                '        'LABBOOKINGSTATUS.Text = ""
                '        Me.Cmd_Add.Text = "Update[F7]"
                '    ElseIf DT.Rows(0).Item("BILLINGFLAG") = "Y" Then
                '        Bookingstatus.Visible = True
                '        Bookingstatus.Text = "BILLING OVER"

                '        SSQL = "SELECT  ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,"
                '        SSQL = SSQL & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                '        SSQL = SSQL & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                '        SSQL = SSQL & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,"
                '        SSQL = SSQL & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                '        SSQL = SSQL & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS POCCUPANCY,"
                '        SSQL = SSQL & "ISNULL(P.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                '        SSQL = SSQL & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg,"
                '        SSQL = SSQL & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG FROM PARTY_HDR P"
                '        SSQL = SSQL & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO AND P.LOCCODE=H.LOCCODE"
                '        SSQL = SSQL & " where P.Bookingno=" & Trim(TXTBOOKINGNO.Text) & ""
                '        SSQL = SSQL & " AND P.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "' AND H.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"

                '        DT = GCONNECTION.GetValues(SSQL)
                '        SSQL = "select isnull(sum(amount),0)as amount from party_receipt where LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and bookingno=" & TXTBOOKINGNO.Text & " and isnull(freeze,'')<>'Y'"
                '        GCONNECTION.getDataSet(SSQL, "rec")
                '        If gdataset.Tables("rec").Rows.Count > 0 Then
                '            TXTRESAMOUNT.Text = gdataset.Tables("rec").Rows(0).Item("Amount")
                '        Else
                '            TXTRESAMOUNT.Text = 0.0
                '        End If
                '        LABBOOKINGSTATUS.Visible = True
                '        LABBOOKINGSTATUS.Text = ""
                '        Me.Cmd_Add.Text = "Update[F7]"
                '    ElseIf DT.Rows(0).Item("CANCELFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                '        Bookingstatus.Visible = True
                '        Bookingstatus.Text = "CANCEL OVER"
                '        SSQL = "SELECT  ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,"
                '        SSQL = SSQL & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                '        SSQL = SSQL & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                '        SSQL = SSQL & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,"
                '        SSQL = SSQL & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                '        SSQL = SSQL & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS POCCUPANCY,"
                '        SSQL = SSQL & "ISNULL(H.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                '        SSQL = SSQL & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg,"
                '        SSQL = SSQL & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG FROM PARTY_HDR P"
                '        SSQL = SSQL & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO AND P.LOCCODE=H.LOCCODE"
                '        SSQL = SSQL & " where P.Bookingno=" & Trim(TXTBOOKINGNO.Text) & ""
                '        SSQL = SSQL & " AND P.BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'  AND H.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                '        DT = GCONNECTION.GetValues(SSQL)
                '        SSQL = "select isnull(sum(amount),0)as amount from party_receipt where LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and bookingno=" & TXTBOOKINGNO.Text & " and isnull(freeze,'')<>'Y'"
                '        GCONNECTION.getDataSet(SSQL, "rec")
                '        If gdataset.Tables("rec").Rows.Count > 0 Then
                '            TXTRESAMOUNT.Text = gdataset.Tables("rec").Rows(0).Item("Amount")
                '        Else
                '            TXTRESAMOUNT.Text = 0.0
                '        End If
                '        LABBOOKINGSTATUS.Visible = True
                '        LABBOOKINGSTATUS.Text = ""
                '        Me.Cmd_Add.Text = "Update[F7]"
                '    ElseIf DT.Rows(0).Item("CANCELFLAG") <> "Y" And DT.Rows(0).Item("BILLINGFLAG") <> "Y" And Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                '        If DT.Rows(0).Item("BOOKINGFLAG") = "Y" Then
                '            SSQL = "SELECT  ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,"
                '            SSQL = SSQL & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                '            SSQL = SSQL & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                '            SSQL = SSQL & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,"
                '            SSQL = SSQL & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                '            SSQL = SSQL & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS POCCUPANCY,"
                '            SSQL = SSQL & "ISNULL(P.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                '            SSQL = SSQL & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY ,ISNULL(H.veg,0) AS veg ,ISNULL(H.nonveg,0) AS nonveg ,"
                '            SSQL = SSQL & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG FROM PARTY_HDR P"
                '            SSQL = SSQL & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO AND P.LOCCODE=H.LOCCODE"
                '            SSQL = SSQL & " where P.Bookingno=" & Trim(TXTBOOKINGNO.Text) & "  AND P.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                '            SSQL = SSQL & " AND P.BOOKINGTYPE='BOOKING'"
                '            DT = GCONNECTION.GetValues(SSQL)
                '            SSQL = "select isnull(sum(amount),0)as amount from party_receipt where LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and bookingno=" & TXTBOOKINGNO.Text & " and isnull(freeze,'')<>'Y'  AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                '            GCONNECTION.getDataSet(SSQL, "rec")
                '            If gdataset.Tables("rec").Rows.Count > 0 Then
                '                TXTRESAMOUNT.Text = gdataset.Tables("rec").Rows(0).Item("Amount")
                '            Else
                '                TXTRESAMOUNT.Text = 0.0
                '            End If
                '        Else
                '            SSQL = " Select isnull(bookingflag,'') as bookingflag,isnull(billingflag,'') as billingflag,isnull(cancelflag,'') as cancelflag,isnull(h.bookingno,0)as bookingno,isnull(h.bookingdate,'')as bookingdate,isnull(d.hallcode,'')as hallcode,isnull(m.halltypedesc,'')As halldesc,"
                '            SSQL = SSQL & " isnull(h.partydate,'')as partydate,isnull(h.mcode,'')as mcode,isnull(d.halltype,'')as pcode,isnull(m.pdesc,'')as pdesc,"
                '            SSQL = SSQL & " isnull(h.associatename,'')as associatename,isnull(d.hallamount,0)as hallamount,isnull(r.receiptno,'')as receiptno,"
                '            SSQL = SSQL & " isnull(r.receiptdate,'')as receiptdate,isnull(r.amount,0)as rcptamount,"
                '            SSQL = SSQL & " isnull(d.fromtime,0)as fromtime,isnull(d.totime,0)as totime,isnull(h.freeze,'')as freeze,isnull(h.adddatetime,'')As adddatetime,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg  "
                '            SSQL = SSQL & " from party_hallbooking_hdr h "
                '            SSQL = SSQL & " left outer join party_hallbooking_det d on h.bookingno = d.bookingno"
                '            SSQL = SSQL & " left outer join party_receipt r on h.bookingno = r.bookingno AND R.LOCCODE=H.LOCCODE"
                '            SSQL = SSQL & " left outer join party_view_hallmaster m on d.hallcode=m.halltypecode and m.pcode=d.halltype"
                '            SSQL = SSQL & " WHERE H.BOOKINGNO=" & TXTBOOKINGNO.Text & " AND H.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                '            DT = GCONNECTION.GetValues(SSQL)
                '            SSQL = "select isnull(sum(amount),0)as amount from party_receipt where bookingno=" & TXTBOOKINGNO.Text & " and isnull(freeze,'')<>'Y' AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                '            GCONNECTION.getDataSet(SSQL, "rec")
                '            If gdataset.Tables("rec").Rows.Count > 0 Then
                '                TXTRESAMOUNT.Text = gdataset.Tables("rec").Rows(0).Item("Amount")
                '            Else
                '                TXTRESAMOUNT.Text = 0.0
                '            End If
                '        End If
                '    Else
                '        If Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                '            SSQL = " Select  0 AS INVOICENO,isnull(bookingflag,'') as bookingflag,isnull(billingflag,'') as billingflag,isnull(cancelflag,'') as cancelflag,isnull(h.bookingno,0)as bookingno,isnull(h.bookingdate,'')as bookingdate,isnull(d.hallcode,'')as hallcode,isnull(m.halltypedesc,'')As halldesc,"
                '            SSQL = SSQL & " isnull(h.partydate,'')as partydate,isnull(h.mcode,'')as mcode,isnull(d.halltype,'')as pcode,isnull(m.pdesc,'')as pdesc,"
                '            SSQL = SSQL & " isnull(h.associatename,'')as associatename,isnull(d.hallamount,0)as hallamount,isnull(r.receiptno,'')as receiptno,"
                '            SSQL = SSQL & " isnull(r.receiptdate,'')as receiptdate,isnull(r.amount,0)as rcptamount,ISNULL(H.DESCRIPTION,'') AS DESCRIPTION,"
                '            SSQL = SSQL & " isnull(d.fromtime,0)as fromtime,isnull(d.totime,0)as totime,isnull(h.freeze,'')as freeze,isnull(h.adddatetime,'')As adddatetime,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg "
                '            SSQL = SSQL & " from party_hallbooking_hdr h "
                '            SSQL = SSQL & " left outer join party_hallbooking_det d on h.bookingno = d.bookingno"
                '            SSQL = SSQL & " left outer join party_receipt r on h.bookingno = r.bookingno  AND H.LOCCODE=R.LOCCODE"
                '            SSQL = SSQL & " left outer join party_view_hallmaster m on d.hallcode=m.halltypecode and m.pcode=d.halltype"
                '            SSQL = SSQL & " WHERE H.BOOKINGNO=" & TXTBOOKINGNO.Text & " AND H.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                '            DT = GCONNECTION.GetValues(SSQL)

                '            SSQL = "select isnull(sum(amount),0)as amount from party_receipt where LOCCODE='" & Trim(CMB_LOCATION.Text) & "' and bookingno=" & TXTBOOKINGNO.Text & " and isnull(freeze,'')<>'Y'"
                '            GCONNECTION.getDataSet(SSQL, "rec")
                '            If gdataset.Tables("rec").Rows.Count > 0 Then
                '                TXTRESAMOUNT.Text = gdataset.Tables("rec").Rows(0).Item("Amount")
                '            Else
                '                TXTRESAMOUNT.Text = 0.0
                '            End If
                '        ElseIf Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                '            SSQL = "SELECT  ISNULL(INVOICENO,0) AS INVOICENO,ISNULL(P.BOOKINGDATE,'') AS BOOKINGDATE,ISNULL(P.BOOKINGTYPE,'')AS BOOKINGTYPE,"
                '            SSQL = SSQL & "ISNULL(P.PARTYDATE,'') AS PARTYDATE,"
                '            SSQL = SSQL & "ISNULL(P.FROMTIME,0) AS FROMTIME,ISNULL(P.TOTIME,0) AS TOTIME,ISNULL(P.MCODE,'') AS MCODE,"
                '            SSQL = SSQL & "ISNULL(P.ADVANCE,0) AS ADVANCE,ISNULL(P.RECEIPTNO,'') AS RECEIPTNO,ISNULL(P.ASSOCIATENAME,'') AS ASSOCIATENAME,"
                '            SSQL = SSQL & "ISNULL(P.RECEIPTDATE,'') AS RECEIPTDATE,ISNULL(P.HALLCODE,'') AS HALLCODE,"
                '            SSQL = SSQL & "ISNULL(P.HALLAMOUNT,0) AS HALLAMOUNT,ISNULL(P.OCCUPANCY,0) AS POCCUPANCY,"
                '            SSQL = SSQL & "ISNULL(P.DESCRIPTION,'') AS DESCRIPTION,ISNULL(P.HALLTAXFLAG,'') AS HALLTAXFLAG,"
                '            SSQL = SSQL & "ISNULL(P.ADDUSERID,'') AS ADDUSERID,ISNULL(P.ADDDATETIME,'') AS ADDDATETIME,ISNULL(P.FREEZE,'') AS FREEZE,ISNULL(H.BOOKINGFLAG,'')AS BOOKINGFLAG,"
                '            SSQL = SSQL & "ISNULL(H.CANCELFLAG,'')AS CANCELFLAG,ISNULL(H.BILLINGFLAG,'')AS BILLINGFLAG,ISNULL(H.OCCUPANCY,0) AS OCCUPANCY,ISNULL(H.veg,0) AS veg,ISNULL(H.nonveg,0) AS nonveg FROM PARTY_HDR P"
                '            SSQL = SSQL & " LEFT OUTER JOIN PARTY_HALLBOOKING_HDR H ON P.BOOKINGNO=H.BOOKINGNO"
                '            SSQL = SSQL & " WHERE P.BOOKINGNO=" & TXTBOOKINGNO.Text & " AND P.LOCCODE='" & Trim(CMB_LOCATION.Text) & "'"
                '            SSQL = SSQL & " AND P.BOOKINGTYPE='BOOKING'"
                '            DT = GCONNECTION.GetValues(SSQL)
                '        Else
                '            MessageBox.Show("BILLING OVER,YOU CAN'T CANCEL", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                '            Call Cmd_Clear_Click(sender, e)
                '            Exit Sub
                '        End If
                '    End If
            Else
                MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Call Cmd_Clear_Click(sender, e)
                Exit Sub
            End If

            If DT.Rows.Count > 0 Then
                TXTMCODE.Enabled = True
                'TXTHALLCODE.Enabled = True
                DTPPARTYDATE.Enabled = True
                'DTPBOOKINGDATE.Text = Format(DT.Rows(0).Item("BOOKINGDATE"), "dd/MMM/yyyy")
                DTPPARTYDATE.Text = Format(DT.Rows(0).Item("PARTYDATE"), "dd/MMM/yyyy")
                'TXTFROMTIME.Text = DT.Rows(0).Item("FROMTIME")
                'TXTTOTIME.Text = DT.Rows(0).Item("TOTIME")
                TXTMCODE.Text = DT.Rows(0).Item("MCODE")

                'If DT.Rows(0).Item("BOOKINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                '    TxtOCCUPANCY.Text = DT.Rows(0).Item("POCCUPANCY")
                'ElseIf DT.Rows(0).Item("BILLINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                '    TxtOCCUPANCY.Text = DT.Rows(0).Item("POCCUPANCY")
                'ElseIf DT.Rows(0).Item("CANCELFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                '    TxtOCCUPANCY.Text = DT.Rows(0).Item("POCCUPANCY")
                'Else
                '    TxtOCCUPANCY.Text = DT.Rows(0).Item("OCCUPANCY")

                'End If
                'vijay030811
                'If DT.Rows(0).Item("BOOKINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                '    TxtVOCCUPANCY.Text = DT.Rows(0).Item("veg")
                'ElseIf DT.Rows(0).Item("BILLINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                '    TxtVOCCUPANCY.Text = DT.Rows(0).Item("veg")
                'ElseIf DT.Rows(0).Item("CANCELFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                '    TxtVOCCUPANCY.Text = DT.Rows(0).Item("veg")
                'Else
                '    TxtVOCCUPANCY.Text = DT.Rows(0).Item("veg")
                'End If

                'TxtOCCUPANCY.Text = DT.Rows(0).Item("veg")
                'If DT.Rows(0).Item("BOOKINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                '    TxtNVOCCUPANCY.Text = DT.Rows(0).Item("nonveg")
                'ElseIf DT.Rows(0).Item("BILLINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                '    TxtNVOCCUPANCY.Text = DT.Rows(0).Item("nonveg")
                'ElseIf DT.Rows(0).Item("CANCELFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                '    TxtOCCUPANCY.Text = DT.Rows(0).Item("veg")
                'Else
                '    TxtNVOCCUPANCY.Text = DT.Rows(0).Item("nonveg")
                'End If





                'TxtVOCCUPANCY.Text = DT.Rows(0).Item("veg")
                'TxtNVOCCUPANCY.Text = DT.Rows(0).Item("nonveg")

                'If DT.Rows(0).Item("BOOKINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BOOKING" Then
                '    TXTDESCRIPTION.Text = DT.Rows(0).Item("DESCRIPTION")
                'ElseIf DT.Rows(0).Item("BILLINGFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "BILLING" Then
                '    TXTDESCRIPTION.Text = DT.Rows(0).Item("DESCRIPTION")
                'ElseIf DT.Rows(0).Item("CANCELFLAG") = "Y" And Trim(CMBBOOKINGTYPE.Text) = "CANCEL" Then
                '    TXTDESCRIPTION.Text = DT.Rows(0).Item("DESCRIPTION")
                'Else
                TXTDESCRIPTION.Text = DT.Rows(0).Item("DESCRIPTION")
                'End If
                'TXTADVANCE.Text = ADVANCE_ANOUNT()
                'If Mid(Cmd_Add.Text, 1, 1) = "A" And CMBBOOKINGTYPE.Text = "BILLING" Then
                'Else
                '    TXTBILLINGNO.Text = DT.Rows(0).Item("INVOICENO")
                'End If


                'TXTRECEIPTNO.Text = DT.Rows(0).Item("RECEIPTNO")
                TXTMNAME.Text = DT.Rows(0).Item("associatename")

                D1 = DateTime.Now()
                D2 = DTPPARTYDATE.Value
                CDAY = DateDiff(DateInterval.Day, D1, D2)
                'If Format(DT.Rows(0).Item("RECEIPTDATE"), "dd/MM/yyyy") = "01/01/1900" Then
                '    CMDDATEVALE.Text = "C"
                '    RECDATEVALIDATED()
                'Else
                '    CMDDATEVALE.Text = "D"
                '    DTPRECEIPTDATE.Value = Format(DT.Rows(0).Item("RECEIPTDATE"), "dd/MM/yyyy")
                '    DTPRECEIPTDATE.Visible = True
                '    CMBTEMPDATE.Visible = False
                'End If
                'TXTHALLCODE.Text = DT.Rows(0).Item("HALLCODE")
                ''CHBHALLTAX.Checked = IIf(DT.Rows(0).Item("HALLTAXFLAG") = "Y", True, False)
                'TXTHALLRENT.Text = DT.Rows(0).Item("HALLAMOUNT")
                'If DT.Rows(0).Item("FREEZE") = "Y" Then
                '    Me.lbl_Freeze.Visible = True
                '    Me.lbl_Freeze.Text = ""
                '    Me.lbl_Freeze.Text = "THIS BOOKING IS CANCELLED ON:" & Format(CDate(DT.Rows(0).Item("ADDDATETIME")), "dd-MMM-yyyy")
                '    Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                'Else
                '    Me.lbl_Freeze.Visible = False
                '    Me.lbl_Freeze.Text = "Record Freezed  On "
                '    Me.Cmd_Freeze.Text = "Cancel[F8]"
                'End If
                Call TXTMCODE_Validated(TXTMCODE, e)
                'Call TXTHALLCODE_Validated(TXTHALLCODE, e)
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
                'With SSGRID_BOOKING
                '    GBHALLBOOKING.Visible = True
                '    rdo_halldisplay.Checked = True
                '    'If CMBBOOKINGTYPE.SelectedItem = "BOOKING" Then
                '    Dim dt4 As DataTable
                '    SSQL = "Select hallcode,halldesc,occupancy,pcode,pdesc,loccode,locdesc,fromtime,totime,hallamount,HALLTAXPERC,HALLTAXAMOUNT,HALLNETAMOUNT from party_view_hallbookingdetails where (BOOKINGTYPE='BOOKING' OR BOOKINGTYPE='') AND bookingno=" & Trim(TXTBOOKINGNO.Text) & " AND LOCCODE='" & Trim(CMB_LOCATION.Text) & "' group by hallcode,halldesc,occupancy,pcode,pdesc,loccode,locdesc,fromtime,totime,hallamount,HALLTAXPERC,HALLTAXAMOUNT,HALLNETAMOUNT"
                '    dt4 = GCONNECTION.GetValues(SSQL)
                '    For I = 0 To dt4.Rows.Count - 1
                '        .Col = 1
                '        .Row = I + 1
                '        .Text = dt4.Rows(I).Item("HALLCODE")
                '        .Col = 2
                '        .Row = I + 1
                '        .Text = dt4.Rows(I).Item("HALLDESC")
                '        .Col = 3
                '        .Row = I + 1
                '        .Text = dt4.Rows(I).Item("PCODE")
                '        .Col = 4
                '        .Row = I + 1
                '        .Text = dt4.Rows(I).Item("PDESC")
                '        .Col = 5
                '        .Row = I + 1
                '        .Text = dt4.Rows(I).Item("FROMTIME")
                '        .Col = 6
                '        .Row = I + 1
                '        .Text = dt4.Rows(I).Item("TOTIME")
                '        .Col = 7
                '        .Row = I + 1
                '        .Text = dt4.Rows(I).Item("HALLAMOUNT")
                '        .Col = 8
                '        .Row = I + 1
                '        .Text = dt4.Rows(I).Item("HALLTAXPERC")
                '        .Col = 9
                '        .Row = I + 1
                '        .Text = dt4.Rows(I).Item("HALLTAXAMOUNT")
                '        .Col = 10
                '        .Row = I + 1
                '        .Text = dt4.Rows(I).Item("HALLNETAMOUNT")
                '    Next
                '    .SetActiveCell(1, 1)
                '    .Focus()
                '    'End If
                'End With
                'Me.CMBBOOKINGTYPE.Enabled = False
                'Me.TXTBOOKINGNO.ReadOnly = True
                'Me.Cmd_BookingNo.Enabled = False
                'Me.DTPBOOKINGDATE.Focus()
                'Call HALLFACILITY()
                'Call ARRANGEMENT()
                Call restaurant()
                'Call TARIFFITEMSvg()
                'Call TARIFFITEMSnvg()
                'DTPBOOKINGDATE.Focus()
                TXTMCODE.Enabled = False
                'TXTHALLCODE.Enabled = False
                DTPPARTYDATE.Enabled = False
                SSGRID1.Focus()
                SSGRID1.SetActiveCell(1, 1)
            Else
                'Me.lbl_Freeze.Visible = False
                'Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                TXTBOOKINGNO.ReadOnly = False
                MessageBox.Show("HALL BOOKING NO NOT FOUND,PLEASE BOOK THE HALL FIRST.", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                TXTBOOKINGNO.Text = ""
                TXTBOOKINGNO.Focus()
                'DTPBOOKINGDATE.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call Me.clearoperaction()
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
                    'If File.Exists("\\" & gserver & "\Photos\Members\" & Trim(TXTMCODE.Text) & ".Jpg") Then
                    '    Pic_Member.Image = New Bitmap("\\" & gserver & "\Photos\Members\" & Trim(TXTMCODE.Text) & ".Jpg")
                    'ElseIf File.Exists("\\" & gserver & "\Photos\Members\" & Trim(TXTMCODE.Text) & ".BMP") Then
                    '    Pic_Member.Image = New Bitmap("\\" & gserver & "\Photos\Members\" & Trim(TXTMCODE.Text) & ".BMP")
                    'ElseIf File.Exists("\\" & gserver & "\Photos\Image.Jpg") Then
                    '    Pic_Member.Image = New Bitmap("\\" & gserver & "\Photos\Image.Jpg")
                    'ElseIf File.Exists("\\" & gserver & "\Photos\Image.Jpeg") Then
                    '    Pic_Member.Image = New Bitmap("\\" & gserver & "\Photos\Image.Jpeg")
                    'End If

                    'If File.Exists("\\" & gserver & "\Photos\\Members\" & Trim(TXTMCODE.Text) & "-S" & ".Jpg") Then
                    '    Pic_Sign.Image = New Bitmap("\\" & gserver & "\photos\members\" & Trim(TXTMCODE.Text) & "-S" & ".Jpg")
                    'ElseIf File.Exists("\\" & gserver & "\Photos\members\" & Trim(TXTMCODE.Text) & "-S" & ".BMP") Then
                    '    Pic_Sign.Image = New Bitmap("\\" & gserver & "\Photos\members\" & Trim(TXTMCODE.Text) & "-S" & ".BMP")
                    'ElseIf File.Exists("\\" & gserver & "\Photos\Image.Jpg") Then
                    '    Pic_Sign.Image = New Bitmap("\\" & gserver & "\Photos\Image.Jpg")
                    'ElseIf File.Exists("\\" & gserver & "\Photos\Image.Jpeg") Then
                    '    Pic_Sign.Image = New Bitmap("\\" & gserver & "\Photos\Image.Jpeg")
                    'End If

                    ''for spouses
                    'If File.Exists("\\" & gserver & "\Photos\Spouses\" & Trim(TXTMCODE.Text) & "side1" & ".Jpg") Then
                    '    Pic_Spouse.Image = New Bitmap("\\" & gserver & "\Photos\Spouses\" & Trim(TXTMCODE.Text) & "side1" & ".Jpg")
                    'ElseIf File.Exists("\\" & gserver & "\Photos\Spouses\" & Trim(TXTMCODE.Text) & "side1" & ".bmp") Then
                    '    Pic_Spouse.Image = New Bitmap("\\" & gserver & "\Photos\Spouses\" & Trim(TXTMCODE.Text) & "side1" & ".bmp")
                    'ElseIf File.Exists("\\" & gserver & "\Photos\Image.Jpg") Then
                    '    Pic_Spouse.Image = New Bitmap("\\" & gserver & "\Photos\Image.Jpg")
                    'ElseIf File.Exists("\\" & gserver & "\Photos\Image.Jpeg") Then
                    '    Pic_Spouse.Image = New Bitmap("\\" & gserver & "\Photos\Image.Jpeg")
                    'End If

                    'If File.Exists("\\" & gserver & "\Photos\Spouses\" & Trim(TXTMCODE.Text) & "side2" & ".Jpg") Then
                    '    Pic_spousesign.Image = New Bitmap("\\" & gserver & "\Photos\Spouses\" & Trim(TXTMCODE.Text) & "side2" & ".Jpg")
                    'ElseIf File.Exists("\\" & gserver & "\Photos\Spouses\" & Trim(TXTMCODE.Text) & "side2" & ".bmp") Then
                    '    Pic_spousesign.Image = New Bitmap("\\" & gserver & "\Photos\Spouses\" & Trim(TXTMCODE.Text) & "side2" & ".bmp")
                    'ElseIf File.Exists("\\" & gserver & "\Photos\Image.Jpg") Then
                    '    Pic_spousesign.Image = New Bitmap("\\" & gserver & "\Photos\Image.Jpg")
                    'ElseIf File.Exists("\\" & gserver & "\Photos\Image.Jpeg") Then
                    '    Pic_spousesign.Image = New Bitmap("\\" & gserver & "\Photos\Image.Jpeg")
                    'End If

                    TXTMNAME.ReadOnly = True
                    'TxtOCCUPANCY.Focus()
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


    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub SSGRID1_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSGRID1.Advance

    End Sub

    Private Sub SSGRID1_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID1.KeyDownEvent
        Dim ITEMCODE As String
        Dim SQLSTRING As String
        Dim QTY, RATE, AMT As Double
        With SSGRID1
            I = .ActiveRow
            If e.keyCode = Keys.Enter Then
                If .ActiveCol = 1 Then
                    .Col = 1
                    .Row = I
                    ITEMCODE = Trim(.Text)
                    If Trim(ITEMCODE) = "" Then

                        'Call FILLTARIFFITEM()
                        Call fillpos()
                    ElseIf Trim(ITEMCODE) <> "" Then
                        SQLSTRING = "SELECT DISTINCT POSCODE,POSDESC FROM POSMASTER WHERE POSCODE ='" & Trim(ITEMCODE) & "' "
                        GCONNECTION.getDataSet(SQLSTRING, "TITEM")
                        If gdataset.Tables("TITEM").Rows.Count > 0 Then
                            .Col = 1
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("POSCODE")
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
                        'Call FILLTARIFFITEMnv()
                        Call FillMenu()
                    ElseIf Trim(ITEMCODE) <> "" Then
                        'SQLSTRING = "SELECT  distinct itemcode,itemdesc VIEW_PARTY_MENUITEMHELP WHERE TARIFFCODE ='" & Trim(TXT_TARIFF.Text) & "' "
                        SQLSTRING = "SELECT * FROM ITEMMASTER WHERE ITEMCODE ='" & Trim(ITEMCODE) & "' "
                        SQLSTRING = SQLSTRING & " AND ITEMCODE='" & Trim(ITEMCODE) & "'"
                        GCONNECTION.getDataSet(SQLSTRING, "TITEM")
                        If gdataset.Tables("TITEM").Rows.Count > 0 Then
                            .Col = 2
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("ITEMCODE")
                            .Col = 3
                            .Row = I
                            .Text = gdataset.Tables("TITEM").Rows(0).Item("ITEMDESC")
                            '.Col = 4
                            '.Row = I
                            '.Text = gdataset.Tables("TITEM").Rows(0).Item("UOM")
                            '.Col = 6
                            '.Row = I
                            '.Text = gdataset.Tables("TITEM").Rows(0).Item("GROUPCODE")
                            '.Col = 7
                            '.Row = I
                            '.Text = gdataset.Tables("TITEM").Rows(0).Item("MENUCODE")
                            '.Col = 8
                            '.Row = I
                            '.Text = gdataset.Tables("TITEM").Rows(0).Item("TARIFFCODE")
                            '.Col = 9
                            '.Row = I
                            '.Text = gdataset.Tables("TITEM").Rows(0).Item("MAXITEMS")
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
                    End If
                ElseIf .ActiveCol = 3 Then
                    .SetActiveCell(4, I)
                    .Focus()
                ElseIf .ActiveCol = 4 Then

                    .SetActiveCell(5, I)
                    .Focus()
                ElseIf .ActiveCol = 5 Then
                    .SetActiveCell(6, I)
                    .Focus()
                ElseIf .ActiveCol = 6 Then
                    .Row = .ActiveRow
                    .Col = 6
                    .Lock = False
                    If Val(.Text) <> 0 Then
                        .SetActiveCell(7, .Row)
                        Dim tariff, QTY1 As String

                        .GetText(5, .Row, tariff)
                        .GetText(6, .Row, QTY1)
                        .Col = 7
                        .Row = .ActiveRow
                        .Lock = False
                        .Text = Val(tariff) * Val(QTY1)
                    End If


                ElseIf .ActiveCol = 7 Then

                    If Val(.Text) <> 0 Then
                        Call TOTAL()
                        .SetActiveCell(1, I + 1)
                        .Focus()
                        '.Col = 1
                        '.Row = I
                        '.SetText(1, I + 1, tariff)
                    Else
                        .SetActiveCell(5, I)
                        .Focus()
                    End If
                End If
            End If
            If e.keyCode = Keys.F3 Then
                .DeleteRows(I, 1)
                .SetActiveCell(1, I)
                .Focus()
            End If
        End With
    End Sub
    Private Sub restaurant()
        SQLSTRING = " select isnull(BOOKINGNO,'')as BOOKINGNO,isnull(POSCODE,'') as POSCODE,isnull(ITEMCODE,'') as ITEMCODE ,isnull(ITEMDESC,'') asITEMDESC ,isnull(UOM,'') as UOM,isnull(RATE,0) as RATE,QTY,AMOUNT,TOTALAMOUNT from PARTY_BAR_CONSUMPTION where bookingno='" & Me.TXTBOOKINGNO.Text & "'"
        GCONNECTION.getDataSet(SQLSTRING, "consume")
        If gdataset.Tables("consume").Rows.Count > 0 Then
            For I = 0 To gdataset.Tables("consume").Rows.Count - 1
                With SSGRID1
                    .Row = I + 1
                    .Col = 1
                    .Text = gdataset.Tables("consume").Rows(I).Item(1)

                    .Col = 2
                    .Text = gdataset.Tables("consume").Rows(I).Item(2)

                    .Col = 3
                    .Text = gdataset.Tables("consume").Rows(I).Item(3)
                    .Col = 4
                    .Text = gdataset.Tables("consume").Rows(I).Item(4)

                    .Col = 5
                    .Lock = False
                    .Text = Val(gdataset.Tables("consume").Rows(I).Item(5))
                    .Col = 6
                    .Text = Val(gdataset.Tables("consume").Rows(I).Item(6))
                    .Col = 7
                    .Text = Val(gdataset.Tables("consume").Rows(I).Item(7))
                End With
            Next
        End If
        Call TOTAL()

        ' POSCODE, ITEMCODE, ITEMDESC, UOM, RATE, QTY, AMOUNT, totalamount, FREEZE, ADDUSERID, ADDDATETIME)
    End Sub
    Private Sub fillpos()
        Dim vform As New ListOperattion1
        gSQLString = "SELECT DISTINCT poscode,posdesc from posmaster"
        gSQLString = gSQLString & " "
        If Trim(Search) = " " Then
            M_WhereCondition = "  "
        Else
            M_WhereCondition = "  "
        End If
        vform.Field = "POSCODE,POSDESC "
        vform.vFormatstring = "         POSCODE        |POS DESC  "
        vform.vCaption = "POS MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        'vform.KeyPos2 = 2
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            SSGRID1.Row = SSGRID1.ActiveRow
            SSGRID1.Col = 1
            SSGRID1.Text = Trim(vform.keyfield & "")
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub FillMenu()
        Dim vform As New ListOperattion1
        Dim ssql As String
        Dim POSCODE As String
        SSGRID1.GetText(1, SSGRID1.ActiveRow, POSCODE)
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = "SELECT DISTINCT I.ITEMCODE,I.ITEMDESC,I.ITEMTYPECODE,TL.TAXCODE,TL.TAXPERCENTAGE, ISNULL(TL.ACCOUNTCODE,'') "
        gSQLString = gSQLString & " AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN FROM VIEW_ITEMMASTER AS I INNER "
        gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE "

        'gSQLString = "SELECT DISTINCT I.ITEMCODE,I.ITEMDESC,I.BASERATESTD,I.ITEMTYPECODE,TL.TAXCODE,TL.TAXPERCENTAGE, ISNULL(TL.ACCOUNTCODE,'') "
        'gSQLString = gSQLString & " AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN FROM VIEW_ITEMMASTER AS I INNER "
        'gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE "
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = " WHERE (I.ITEMCODE LIKE '%" & Search & "%' OR I.ITEMDESC LIKE '%" & Search & "%') AND '" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "' BETWEEN TL.STARTINGDATE AND ISNULL(TL.ENDINGDATE,'" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "') AND ISNULL(I.FREEZE,'') <>'Y'"
        End If
        vform.Field = "ITEMDESC,ITEMCODE"
        vform.vFormatstring = "ITEMCODE     |ITEM DESCRIPTION                        |  ITEMTYPE  |  TAXCODE  | TAXPERCENTAGE | ACCOUNTCODE |  GROUPCODE  |SALESACCTIN|"
        vform.vCaption = "ITEM CODE HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.keypos4 = 4
        vform.Keypos5 = 5
        vform.Keypos6 = 6
        vform.Keypos7 = 7
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With SSGRID1
                .Col = 2
                .Row = .ActiveRow
                .Text = vform.keyfield
                .Col = 3
                .Row = .ActiveRow
                .Text = vform.keyfield1
                '.Col = 9
                '.Row = .ActiveRow
                '.Text = vform.keyfield2
                '.Col = 10
                '.Row = .ActiveRow
                '.Text = vform.keyfield3
                '.Col = 11
                '.Row = .ActiveRow
                '.Text = vform.keyfield4
                '.Col = 13
                '.Row = .ActiveRow
                '.Text = vform.keyfield5

                '.Col = 14
                '.Row = .ActiveRow
                '.Text = vform.keyfield7

                '.Col = 15
                '.Row = .ActiveRow
                '.Text = vform.keyfield6
            End With
        Else
            SSGRID1.SetActiveCell(0, SSGRID1.ActiveRow)
            Exit Sub
        End If
        If Trim(vform.keyfield) <> "" Then
            '''*********************************************** $ FILL POSCODE INTO SSGRID $ *********************************************'''


            'SQLSTRING = "SELECT POSCODE,POSDESC,SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(vform.keyfield) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(POSCODE) & "'"
            'gconnection.getDataSet(SQLSTRING, "PosMenuLinkVALIDATE")
            'If gdataset.Tables("PosMenuLinkVALIDATE").Rows.Count > 0 Then
            '    SQLSTRING = "SELECT POSCODE,POSDESC,SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(vform.keyfield) & "' AND ISNULL(M.FREEZE,'') <>'Y' AND P.POS='" & Trim(POSCODE) & "' ORDER BY POSCODE"
            'Else
            '    SQLSTRING = "SELECT POSCODE,POSDESC,SALESACCTIN FROM POSMENULINK P INNER Join POSMASTER M On P.POS=M.POSCODE WHERE P.ITEMCODE ='" & Trim(vform.keyfield) & "' AND ISNULL(M.FREEZE,'') <>'Y' ORDER BY POSCODE"
            'End If
            'gconnection.getDataSet(SQLSTRING, "PosMenuLink")

            ''            ssql = "SELECT POSCODE,POSDESC,SALESACCTIN FROM POSMENULINK P INNER JOIN POSMASTER M ON P.POS=M.POSCODE WHERE ITEMCODE='" & vform.keyfield & "'AND ISNULL(M.FREEZE,'')<>'Y' ORDER BY POSCODE"
            ''gconnection.getDataSet(ssql, "PosMenuLink")
            'If gdataset.Tables("PosMenuLink").Rows.Count > 1 Then
            '    '''***************************************** $ SHOW POPUP FOR VARIOUS UOM $ ******************************************************''
            '    'Call FillPosList(gdataset.Tables("PosMenuLink"))
            '    Me.lvw_POSCode.FullRowSelect = True
            '    pnl_POSCode.Top = 50
            '    lvw_POSCode.Focus()
            '    SSGRID1.SetActiveCell(4, SSGRID1.ActiveRow)
            'Else
            '    SSGRID1.Col = 4
            '    SSGRID1.Row = SSGRID1.ActiveRow
            '    SSGRID1.Text = gdataset.Tables("PosMenuLink").Rows(0).Item(0)
            '    If IsDBNull(gdataset.Tables("PosMenuLink").Rows(0).Item(2)) = False Then
            '        If Trim((gdataset.Tables("PosMenuLink").Rows(0).Item(2))) <> "" Then
            '            ssGrid.Col = 14
            '            ssGrid.Row = ssGrid.ActiveRow
            '            ssGrid.Text = gdataset.Tables("PosMenuLink").Rows(0).Item(2)
            '        Else
            '            MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
            '            ssGrid.ClearRange(1, ssGrid.ActiveRow, 15, ssGrid.ActiveRow, True)
            '            ssGrid.SetActiveCell(1, ssGrid.ActiveRow)
            '            Exit Sub
            '        End If
            '    Else
            '        MsgBox("Account Code For The Location  " & gdataset.Tables("PosMenuLink").Rows(0).Item(0) & "  Not Defined,Pls Contact Your System Administrator", MsgBoxStyle.Critical, MyCompanyName)
            '        ssGrid.ClearRange(1, ssGrid.ActiveRow, 15, ssGrid.ActiveRow, True)
            '        ssGrid.SetActiveCell(1, ssGrid.ActiveRow)
            '        Exit Sub
            '    End If
            '    ssGrid.SetActiveCell(5, ssGrid.ActiveRow)
            'End If
            '''************************************************* $ FILL UOM , RATE INTO SSGRID $ **************************************************'''
            gSQLString = "SELECT ISNULL(R.UOM,'') AS UOM, ISNULL(R.ITEMRATE,0) AS ITEMRATE "
            gSQLString = gSQLString & " FROM VIEW_ITEMMASTER AS I INNER JOIN "
            gSQLString = gSQLString & " RATEMASTER AS R ON I.ITEMCODE = R.ITEMCODE "
            gSQLString = gSQLString & "WHERE '" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "' BETWEEN R.STARTINGDATE AND ISNULL(R.ENDINGDATE,'" & Format(DateValue(DTPPARTYDATE.Value), "dd-MMM-yyyy") & "') AND (I.ITEMCODE = '" & Trim(vform.keyfield) & "' ) ORDER BY R.ITEMRATE,R.UOM"
            GCONNECTION.getDataSet(gSQLString, "ITEMRATE")
            If gdataset.Tables("ITEMRATE").Rows.Count > 1 Then
                Call FillUomList(gdataset.Tables("ITEMRATE"))
                If SSGRID1.ActiveCol = 4 Then
                    '''***************************************** $ SHOW POPUP FOR VARIOUS UOM $ ******************************************************''
                    Me.lvw_Uom.FullRowSelect = True
                    'pnl_UOMCode.Top = 50
                    Me.lvw_Uom.Focus()
                    '''***************************************** $ COMPLETE POPUP FOR VARIOUS UOM $ ******************************************************''
                End If
            Else
                SSGRID1.Col = 4
                SSGRID1.Row = SSGRID1.ActiveRow
                SSGRID1.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("UOM")
                SSGRID1.Col = 5
                SSGRID1.Row = SSGRID1.ActiveRow
                'If Val(PACKINGPERCENT) <> 0 Then
                '    ssGrid.Text = Math.Round(Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) + (Val(gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")) * (PACKINGPERCENT / 100)), 0) & ""
                'Else
                SSGRID1.Lock = False
                SSGRID1.Text = gdataset.Tables("ITEMRATE").Rows(0).Item("ITEMRATE")
                'End If
                SSGRID1.SetActiveCell(6, SSGRID1.ActiveRow)
            End If
            '''**************************************************** $ PROMOTIONAL DETAILS OF PARTICULAR ITEMCODE $ **************************************************'''

            gSQLString = "SELECT promitemcode,VIEW_ITEMMASTER.itemdesc,promotional,promuom,promqty,promrate, "
            gSQLString = gSQLString & "posmenulink.pos FROM VIEW_ITEMMASTER INNER JOIN posmenulink on VIEW_ITEMMASTER.itemcode=posmenulink.itemcode "
            gSQLString = gSQLString & "WHERE VIEW_ITEMMASTER.itemcode='" & vform.keyfield & "' "
            GCONNECTION.getDataSet(gSQLString, "Promotional")

            If Trim(gdataset.Tables("Promotional").Rows(0).Item("Promotional")) = "Y" Then

                'Modified on 14 Mar'08
                'Mk Kannan
                'Begin
                gSQLString = "SELECT I.PROMQTY, I.ITEMCODE,I.PROMITEMCODE, IM.ITEMDESC,I.ITEMTYPECODE, P.POSCODE, P.POSDESC,I.STARTINGDATE,I.ENDINGDATE,"
                gSQLString = gSQLString & " I.PROMUOM, I.PROMQTY, I.PROMRATE FROM VIEW_ITEMMASTER AS I INNER JOIN POSMENULINK AS PL ON I.ITEMCODE = PL.ITEMCODE INNER JOIN"
                gSQLString = gSQLString & " POSMASTER AS P ON PL.POS = P.POSCODE "
                gSQLString = gSQLString & " INNER JOIN VIEW_ITEMMASTER AS IM ON IM.ITEMCODE=I.PROMITEMCODE"
                gSQLString = gSQLString & " WHERE (I.PROMOTIONAL = 'Y') AND (I.PROMITEMCODE = '" & gdataset.Tables("Promotional").Rows(0).Item("promitemcode") & "') AND (I.ITEMCODE = '" & vform.keyfield & "') AND ISNULL(I.FREEZE,'') <>'Y' "
                'gSQLString = "SELECT dbo.VIEW_ITEMMASTER.PromQty, dbo.VIEW_ITEMMASTER.ItemCode,dbo.VIEW_ITEMMASTER.PromItemcode, dbo.VIEW_ITEMMASTER.ItemDesc,dbo.VIEW_ITEMMASTER.ItemTypecode, dbo.POSMaster.POSCode, dbo.POSMaster.POSDesc,dbo.VIEW_ITEMMASTER.StartingDate,dbo.VIEW_ITEMMASTER.EndingDate,"
                'gSQLString = gSQLString & " dbo.VIEW_ITEMMASTER.PromUOM, dbo.VIEW_ITEMMASTER.PromQty, dbo.VIEW_ITEMMASTER.PromRate FROM dbo.VIEW_ITEMMASTER INNER JOIN dbo.POSMenulink ON dbo.VIEW_ITEMMASTER.ItemCode = dbo.POSMenulink.ItemCode INNER JOIN"
                'gSQLString = gSQLString & " dbo.POSMaster ON dbo.POSMenulink.Pos = dbo.POSMaster.POSCode WHERE (dbo.VIEW_ITEMMASTER.Promotional = 'Y') AND (dbo.VIEW_ITEMMASTER.PromItemcode = '" & gdataset.Tables("Promotional").Rows(0).Item("promitemcode") & "') AND (dbo.VIEW_ITEMMASTER.itemcode = '" & vform.keyfield & "') "
                'End

                GCONNECTION.getDataSet(gSQLString, "Promotional")
                If gdataset.Tables("Promotional").Rows.Count > 0 Then
                    If MessageBox.Show("Promotional available for this ITEMCODE ", MyCompanyName, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
                        If CDate(gdataset.Tables("Promotional").Rows(0).Item("EndingDate")) <= CDate(Now.Today) And CDate(gdataset.Tables("Promotional").Rows(0).Item("StartingDate")) >= CDate(Now.Today) Then
                            SSGRID1.SetText(2, SSGRID1.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromItemcode")) & "")
                            SSGRID1.SetText(3, SSGRID1.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemDesc")) & "")
                            SSGRID1.SetText(1, SSGRID1.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("POSCode")) & "")
                            SSGRID1.SetText(4, SSGRID1.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromUOM")) & "")
                            SSGRID1.SetText(5, SSGRID1.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("PromQty")) & "")
                            SSGRID1.SetText(6, SSGRID1.ActiveRow + 1, 0.0)
                            SSGRID1.SetText(7, SSGRID1.ActiveRow + 1, 0.0)
                            SSGRID1.SetText(8, SSGRID1.ActiveRow + 1, 0.0)
                            'SSGRID1.SetText(9, SSGRID1.ActiveRow + 1, Trim(gdataset.Tables("Promotional").Rows(0).Item("ItemTypecode")) & "")
                            'Modified on 14 Mar'08
                            'Mk Kannan
                            'Begin
                            'SSGRID1.SetText(11, SSGRID1.ActiveRow + 1, 0.0)
                            'boolPromotional = True
                            'ssGrid.SetText(17, ssGrid.ActiveRow + 1, "Y")
                            'End
                        End If
                    End If
                End If
            End If
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub FillUomList(ByVal UomTable As DataTable)
        Dim lvw As New ListViewItem
        Dim i As Integer
        lvw_Uom.Items.Clear()
        For i = 0 To UomTable.Rows.Count - 1
            lvw = lvw_Uom.Items.Add(UomTable.Rows(i).Item("UOM"))
            lvw.SubItems.Add(UomTable.Rows(i).Item("ITEMRATE"))
        Next i
        lvw_Uom.Visible = True
    End Sub

    Private Sub TXTBOOKINGNO_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTBOOKINGNO.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Call TXTBOOKINGNO_Validated(TXTBOOKINGNO, e)
            'DTPBOOKINGDATE.Focus()
        End If

    End Sub
    Private Sub TOTAL()
        Dim DOT As Double
        With SSGRID1
            For I = 0 To SSGRID1.DataRowCnt - 1
                .Row = I + 1
                .Col = 7
                DOT = DOT + Val(.Text)

            Next
            TXT_TOTAL.Text = Format(DOT, "0.00")
        End With
    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim POSLOCATION, POSITEMCODE, POSITEMUOM As String
        Dim AVGRATE, AVGQUANTITY, dblCalqty As Double
        Dim INSERT(10) As String
        SQLSTRING = " delete from PARTY_BAR_CONSUMPTION where BOOKINGNO='" & Me.TXTBOOKINGNO.Text & "'"
        INSERT(0) = SQLSTRING
        SQLSTRING = " delete from SUBSTORECONSUMPTIONDETAIL where DOCNO='" & Me.TXTBOOKINGNO.Text & "' AND DOCDETAILS='PARTY'"
        INSERT(1) = SQLSTRING

        With SSGRID1
            For I = 0 To SSGRID1.DataRowCnt - 1
                SQLSTRING = "INSERT INTO PARTY_BAR_CONSUMPTION(LOCCODE,BOOKINGNO,PARTYDATE,MCODE,MNAME,REMARKS,POSCODE,ITEMCODE,ITEMDESC,UOM,RATE,QTY,AMOUNT,TOTALAMOUNT,FREEZE,ADDUSERID,ADDDATETIME) "
                SQLSTRING = SQLSTRING & " values('" & Me.CMB_LOCATION.Text & "','" & Me.TXTBOOKINGNO.Text & "','" & Format(Me.DTPPARTYDATE.Value, "dd/MMM/yyyy") & "','" & Me.TXTMCODE.Text & "','" & Me.TXTMNAME.Text & "',"
                SQLSTRING = SQLSTRING & "'" & Me.TXTDESCRIPTION.Text & "',"
                .Row = I + 1
                .Col = 1
                SQLSTRING = SQLSTRING & "'" & .Text & "',"
                .Row = I + 1
                .Col = 2
                SQLSTRING = SQLSTRING & "'" & .Text & "',"
                .Row = I + 1
                .Col = 3
                SQLSTRING = SQLSTRING & "'" & .Text & "',"
                .Col = 4
                SQLSTRING = SQLSTRING & "'" & .Text & "',"
                .Col = 5
                SQLSTRING = SQLSTRING & "'" & Format(Val(.Text), "0.00") & "',"
                .Col = 6
                SQLSTRING = SQLSTRING & "'" & Val(.Text) & "',"
                .Col = 7
                SQLSTRING = SQLSTRING & " '" & Format(Val(.Text), "0.00") & "',"

                SQLSTRING = SQLSTRING & Format(Val(Me.TXT_TOTAL.Text), "0.00") & " ,'N','" & gUsername & "',getdate() " & " )"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = SQLSTRING
                'SQLSTRING = "INSERT INTO PARTY_BAR_CONSUMPTION(LOCCODE,BOOKINGNO,PARTYDATE,MCODE,MNAME,REMARKS,POSCODE,ITEMCODE,ITEMDESC,UOM,RATE,QTY,AMOUNT,TOTALAMOUNT,FREEZE,ADDUSERID,ADDDATETIME) "

                .Row = I + 1
                .Col = 1
                POSLOCATION = Trim(.Text)
                SQLSTRING = "SELECT STOREDESC FROM STOREMASTER WHERE STORECODE='" & POSLOCATION & "' AND ISNULL(FREEZE,'') <> 'Y'"
                GCONNECTION.getDataSet(SQLSTRING, "STOREMASTER1")
                If gdataset.Tables("STOREMASTER1").Rows.Count > 0 Then
                    .Row = I + 1
                    .Col = 2
                    POSITEMCODE = Trim(.Text)
                    .Row = I + 1
                    .Col = 4
                    POSITEMUOM = Trim(.Text)
                    'AVGRATE = CalAverageRate(Trim(ssGrid.Text))
                    'AVGQUANTITY = CalAverageQuantity(Trim(ssGrid.Text))
                    SQLSTRING = "SELECT GITEMCODE,GITEMNAME,GUOM,GQTY,GRATE,GAMOUNT,GDBLAMT,GHIGHRATIO,GGROUPCODE,GSUBGROUPCODE,VOID FROM BOM_DET WHERE"
                    SQLSTRING = SQLSTRING & " ITEMCODE='" & POSITEMCODE & "' AND ITEMUOM='" & POSITEMUOM & "' AND ISNULL(VOID,'') <> 'Y'"
                    GCONNECTION.getDataSet(SQLSTRING, "BOM")
                    If gdataset.Tables("BOM").Rows.Count > 0 Then
                        For K = 0 To gdataset.Tables("BOM").Rows.Count - 1
                            SQLSTRING = "INSERT INTO SUBSTORECONSUMPTIONDETAIL(Docno,Docdetails,Docdate,Storelocationcode,STORELOCATIONNAME,"
                            SQLSTRING = SQLSTRING & " Itemcode,Itemname,Uom,Qty,Rate,Amount,"
                            SQLSTRING = SQLSTRING & " Dblamt,Highratio,Groupcode,Subgroupcode,Void,Adduser,adddatetime,Updateuser,Updatetime)"
                            SQLSTRING = SQLSTRING & " VALUES ('" & Trim(CStr(TXTBOOKINGNO.Text)) & "','PARTY',"
                            SQLSTRING = SQLSTRING & " '" & Format(CDate(Me.DTPPARTYDATE.Value), "dd-MMM-yyyy") & "',"
                            SQLSTRING = SQLSTRING & " '" & Trim(POSLOCATION) & "',"
                            SQLSTRING = SQLSTRING & " '" & Trim(STORELOCATION(POSLOCATION)) & "',"
                            SQLSTRING = SQLSTRING & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & "") & "',"
                            SQLSTRING = SQLSTRING & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMNAME") & "") & "',"
                            SQLSTRING = SQLSTRING & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GUOM") & "") & "',"
                            .Col = 6
                            .Row = I + 1
                            'SSGRID1.GetText(6, I, dblCalqty)
                            dblCalqty = Val(.Text)
                            SQLSTRING = SQLSTRING & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")) & ","
                            AVGRATE = CalAverageRate(Trim(gdataset.Tables("BOM").Rows(K).Item("GITEMCODE") & ""))
                            'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                            SQLSTRING = SQLSTRING & AVGRATE & ","
                            SQLSTRING = SQLSTRING & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GQTY")) * AVGRATE & ","
                            'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                            SQLSTRING = SQLSTRING & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GDBLAMT")) & ","
                            SQLSTRING = SQLSTRING & Val(gdataset.Tables("BOM").Rows(K).Item("GHIGHRATIO")) & ","
                            SQLSTRING = SQLSTRING & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GGROUPCODE") & "") & "',"
                            SQLSTRING = SQLSTRING & " '" & Trim(gdataset.Tables("BOM").Rows(K).Item("GSUBGROUPCODE") & "") & "',"
                            SQLSTRING = SQLSTRING & "'N'," '& Format(Val(AVGQUANTITY), "0.000") & "," & Format(Val(AVGRATE), "0.00") & ","
                            SQLSTRING = SQLSTRING & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                            SQLSTRING = SQLSTRING & " ' ','" & Format(DateTime.Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = SQLSTRING
                        Next K
                    Else
                        SQLSTRING = " SELECT ISNULL(I.ITEMCODE,'') AS ITEMCODE,ISNULL(I.ITEMNAME,'') AS ITEMNAME,ISNULL(I.STOCKUOM,'') AS STOCKUOM, ISNULL(I.PURCHASERATE,0.00) AS PURCHASERATE,"
                        SQLSTRING = SQLSTRING & " ISNULL(O.CONVUOM,'') AS CONVUOM,ISNULL(O.HIGHRATIO,0) AS HIGHRATIO, ISNULL(I.GROUPCODE,'') AS GROUPCODE, "
                        SQLSTRING = SQLSTRING & " ISNULL(I.SUBGROUPCODE,'') AS SUBGROUPCODE FROM INVENTORYITEMMASTER AS I INNER JOIN OPENINGSTOCK AS O ON O.ITEMCODE = I.ITEMCODE "
                        SQLSTRING = SQLSTRING & " WHERE I.ITEMCODE='" & POSITEMCODE & "' AND I.STOCKUOM='" & POSITEMUOM & "' AND ISNULL(FREEZE,'') <> 'Y' and i.storecode='" & POSLOCATION & "'"
                        GCONNECTION.getDataSet(SQLSTRING, "DIRECT_STOCK")
                        If gdataset.Tables("DIRECT_STOCK").Rows.Count > 0 Then
                            SQLSTRING = "INSERT INTO SUBSTORECONSUMPTIONDETAIL(Docno,Docdetails,Docdate,Storelocationcode,STORELOCATIONNAME,"
                            SQLSTRING = SQLSTRING & " Itemcode,Itemname,Uom,Qty,Rate,Amount,"
                            SQLSTRING = SQLSTRING & " Dblamt,Highratio,Groupcode,Subgroupcode,Void,Adduser,adddatetime,Updateuser,Updatetime)"
                            SQLSTRING = SQLSTRING & " VALUES ('" & Trim(CStr(Me.TXTBOOKINGNO.Text)) & "','PARTY',"
                            SQLSTRING = SQLSTRING & " '" & Format(CDate(Me.DTPPARTYDATE.Value), "dd-MMM-yyyy") & "',"
                            SQLSTRING = SQLSTRING & " '" & Trim(POSLOCATION) & "',"
                            SQLSTRING = SQLSTRING & " '" & Trim(STORELOCATION(POSLOCATION)) & "',"
                            SQLSTRING = SQLSTRING & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & "") & "',"
                            SQLSTRING = SQLSTRING & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMNAME") & "") & "',"
                            SQLSTRING = SQLSTRING & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("STOCKUOM") & "") & "',"
                            .Col = 6
                            .Row = I + 1
                            dblCalqty = Val(.Text)
                            SQLSTRING = SQLSTRING & dblCalqty & ","
                            AVGRATE = CalAverageRate(Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("ITEMCODE") & ""))
                            'sqlstring = sqlstring & Val(gdataset.Tables("BOM").Rows(K).Item("GRATE")) & ","
                            SQLSTRING = SQLSTRING & AVGRATE & ","
                            SQLSTRING = SQLSTRING & dblCalqty * AVGRATE & ","
                            'sqlstring = sqlstring & dblCalqty * CDbl(gdataset.Tables("BOM").Rows(K).Item("GAMOUNT")) & ","
                            SQLSTRING = SQLSTRING & dblCalqty * CDbl(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO")) & ","
                            SQLSTRING = SQLSTRING & Val(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("HIGHRATIO")) & ","
                            SQLSTRING = SQLSTRING & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("GROUPCODE") & "") & "',"
                            SQLSTRING = SQLSTRING & " '" & Trim(gdataset.Tables("DIRECT_STOCK").Rows(0).Item("SUBGROUPCODE") & "") & "',"
                            SQLSTRING = SQLSTRING & "'N'," '& Format(Val(AVGQUANTITY), "0.000") & "," & Format(Val(AVGRATE), "0.00") & ","
                            SQLSTRING = SQLSTRING & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd-MMM-yyyy hh:mm:ss") & "',"
                            SQLSTRING = SQLSTRING & " ' ','" & Format(DateTime.Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                            ReDim Preserve INSERT(INSERT.Length)
                            INSERT(INSERT.Length - 1) = SQLSTRING
                        End If
                    End If
                End If
                '******************************************************************************************************
            Next I
        End With
        GCONNECTION.dataOperation1(1, INSERT)
        Call Me.Cmd_Clear_Click(sender, e)
    End Sub

    Private Sub Cmd_report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_report.Click
        Dim CR As New consumerpt
        CR.MdiParent = Me.MdiParent
        CR.Show()
        CR.TXTBOKNOTO.Text = Me.TXTBOOKINGNO.Text
        CR.TXTBOOKINGNO.Text = Me.TXTBOOKINGNO.Text
        Call CR.Cmd_report_Click(sender, e)
        CR.Close()
    End Sub
End Class
