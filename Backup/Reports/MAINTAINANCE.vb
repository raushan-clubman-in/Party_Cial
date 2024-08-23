Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Imports System.IO
Public Class MAINTAINANCE
    Inherits System.Windows.Forms.Form
    Dim ssql As String
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CMD_BOOKTO As System.Windows.Forms.Button
    Friend WithEvents TXTBOKNOTO As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_BookingNo As System.Windows.Forms.Button
    Friend WithEvents TXTBOOKINGNO As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_report As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpfrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(MAINTAINANCE))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Button3 = New System.Windows.Forms.Button
        Me.CMD_BOOKTO = New System.Windows.Forms.Button
        Me.TXTBOKNOTO = New System.Windows.Forms.TextBox
        Me.Cmd_BookingNo = New System.Windows.Forms.Button
        Me.TXTBOOKINGNO = New System.Windows.Forms.TextBox
        Me.Cmd_report = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpto = New System.Windows.Forms.DateTimePicker
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(24, 32)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(560, 320)
        Me.TabControl1.TabIndex = 367
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.BackgroundImage = CType(resources.GetObject("TabPage1.BackgroundImage"), System.Drawing.Image)
        Me.TabPage1.Controls.Add(Me.Button3)
        Me.TabPage1.Controls.Add(Me.CMD_BOOKTO)
        Me.TabPage1.Controls.Add(Me.TXTBOKNOTO)
        Me.TabPage1.Controls.Add(Me.Cmd_BookingNo)
        Me.TabPage1.Controls.Add(Me.TXTBOOKINGNO)
        Me.TabPage1.Controls.Add(Me.Cmd_report)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 34)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(552, 282)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "BOKING NOWISE"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.ForestGreen
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(352, 208)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 32)
        Me.Button3.TabIndex = 864
        Me.Button3.Text = "Exit[F11]"
        '
        'CMD_BOOKTO
        '
        Me.CMD_BOOKTO.Image = CType(resources.GetObject("CMD_BOOKTO.Image"), System.Drawing.Image)
        Me.CMD_BOOKTO.Location = New System.Drawing.Point(376, 96)
        Me.CMD_BOOKTO.Name = "CMD_BOOKTO"
        Me.CMD_BOOKTO.Size = New System.Drawing.Size(24, 26)
        Me.CMD_BOOKTO.TabIndex = 863
        '
        'TXTBOKNOTO
        '
        Me.TXTBOKNOTO.BackColor = System.Drawing.Color.Wheat
        Me.TXTBOKNOTO.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TXTBOKNOTO.Location = New System.Drawing.Point(280, 96)
        Me.TXTBOKNOTO.MaxLength = 30
        Me.TXTBOKNOTO.Name = "TXTBOKNOTO"
        Me.TXTBOKNOTO.Size = New System.Drawing.Size(96, 26)
        Me.TXTBOKNOTO.TabIndex = 862
        Me.TXTBOKNOTO.Text = ""
        '
        'Cmd_BookingNo
        '
        Me.Cmd_BookingNo.Image = CType(resources.GetObject("Cmd_BookingNo.Image"), System.Drawing.Image)
        Me.Cmd_BookingNo.Location = New System.Drawing.Point(376, 32)
        Me.Cmd_BookingNo.Name = "Cmd_BookingNo"
        Me.Cmd_BookingNo.Size = New System.Drawing.Size(24, 26)
        Me.Cmd_BookingNo.TabIndex = 861
        '
        'TXTBOOKINGNO
        '
        Me.TXTBOOKINGNO.BackColor = System.Drawing.Color.Wheat
        Me.TXTBOOKINGNO.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold)
        Me.TXTBOOKINGNO.Location = New System.Drawing.Point(280, 32)
        Me.TXTBOOKINGNO.MaxLength = 30
        Me.TXTBOOKINGNO.Name = "TXTBOOKINGNO"
        Me.TXTBOOKINGNO.Size = New System.Drawing.Size(96, 26)
        Me.TXTBOOKINGNO.TabIndex = 860
        Me.TXTBOOKINGNO.Text = ""
        '
        'Cmd_report
        '
        Me.Cmd_report.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_report.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_report.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_report.ForeColor = System.Drawing.Color.White
        Me.Cmd_report.Image = CType(resources.GetObject("Cmd_report.Image"), System.Drawing.Image)
        Me.Cmd_report.Location = New System.Drawing.Point(216, 208)
        Me.Cmd_report.Name = "Cmd_report"
        Me.Cmd_report.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_report.TabIndex = 366
        Me.Cmd_report.Text = "Report[F12]"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(16, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(242, 23)
        Me.Label4.TabIndex = 363
        Me.Label4.Text = "PARTY BOOKINGNO  FROM "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(24, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(231, 23)
        Me.Label1.TabIndex = 365
        Me.Label1.Text = "PARTY  BOOKINGNO TO  "
        '
        'TabPage2
        '
        Me.TabPage2.BackgroundImage = CType(resources.GetObject("TabPage2.BackgroundImage"), System.Drawing.Image)
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.dtpfrom)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.dtpto)
        Me.TabPage2.Location = New System.Drawing.Point(4, 34)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(552, 282)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "DATE WISE"
        Me.TabPage2.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.ForestGreen
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(328, 232)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 32)
        Me.Button2.TabIndex = 371
        Me.Button2.Text = "Exit[F11]"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(200, 232)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 32)
        Me.Button1.TabIndex = 370
        Me.Button1.Text = "Report[F12]"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(32, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(178, 23)
        Me.Label2.TabIndex = 367
        Me.Label2.Text = "PARTY FROM  DATE"
        '
        'dtpfrom
        '
        Me.dtpfrom.CustomFormat = ""
        Me.dtpfrom.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpfrom.Location = New System.Drawing.Point(240, 64)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(112, 27)
        Me.dtpfrom.TabIndex = 366
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(32, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 23)
        Me.Label3.TabIndex = 369
        Me.Label3.Text = "PARTY  TO  DATE"
        '
        'dtpto
        '
        Me.dtpto.CustomFormat = ""
        Me.dtpto.Font = New System.Drawing.Font("Times New Roman", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpto.Location = New System.Drawing.Point(240, 128)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(112, 27)
        Me.dtpto.TabIndex = 368
        '
        'MAINTAINANCE
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(608, 372)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "MAINTAINANCE"
        Me.Text = "MAINTAINANCE"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Cmd_report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_report.Click
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r As New party_man
        If Me.TXTBOOKINGNO.Text <> "" Then
            ssql = " SELECT * FROM PARTY_ARRDETAIL WHERE BOOKINGNO BETWEEN '" & Me.TXTBOOKINGNO.Text & "' AND '" & Me.TXTBOKNOTO.Text & "' ORDER BY PARTYDATE"
        Else
            ssql = " SELECT * FROM PARTY_ARRDETAIL WHERE partydate BETWEEN '" & Format(Me.dtpfrom.Value, "dd-MMM-yyyy") & "' AND '" & Format(Me.dtpto.Value, "dd-MMM-yyyy") & "'  ORDER BY PARTYDATE"

        End If

        Viewer.Report = r

        Call Viewer.GetDetails(ssql, "PARTY_ARRDETAIL", r)
        Viewer.TableName = "PARTY_ARRDETAIL"
        Dim txtobj15 As TextObject
        txtobj15 = r.ReportDefinition.ReportObjects("Text15")
        txtobj15.Text = " FROM BOOKINGNO " & Me.TXTBOOKINGNO.Text & " TO " & Me.TXTBOKNOTO.Text

        Viewer.Show()
    End Sub

    Private Sub Cmd_BookingNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_BookingNo.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(BOOKINGNO,0) AS BOOKINGNO,ISNULL(partyDATE,'')AS PARTYDATE,BOOKINGDATE AS BOOKINGDATE,ASSOCIATENAME AS MEMBERNAME,HALLCODE,MCODE,ISNULL(TARIFFCODE,'') AS TARIFFCODE "
        gSQLString = gSQLString & "  FROM  PARTY_HALLBOOKING_HDR"
        If Trim(Search) = " " Then
            M_WhereCondition = " "
        Else
            M_WhereCondition = " "
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
            'Call TXTBOOKINGNO_Validated(sender, e)
            'DTPBOOKINGDATE.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub CMD_BOOKTO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_BOOKTO.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(BOOKINGNO,0) AS BOOKINGNO,ISNULL(partyDATE,'')AS PARTYDATE,BOOKINGDATE AS BOOKINGDATE,ASSOCIATENAME AS MEMBERNAME,HALLCODE,MCODE,ISNULL(TARIFFCODE,'') AS TARIFFCODE "
        gSQLString = gSQLString & "  FROM  PARTY_HALLBOOKING_HDR"
        If Trim(Search) = " " Then
            M_WhereCondition = " "
        Else
            M_WhereCondition = " "
        End If
        vform.Field = "BOOKINGNO,PARTYDATE,BOOKINGDATE,ASSOCIATENAME,HALLCODE,MCODE,TARIFFCODE"
        vform.vFormatstring = "BOOKINGNO |   PARTYDATE   |  BOOKING DATE  |        MEMBER NAME       |    HALL CODE    |    MEM CODE    |    TARIFF CODE    "
        vform.vCaption = "HALL RESERVATION HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXTBOKNOTO.Text = Trim(vform.keyfield & "")
            'DTPBOOKINGDATE.Text = Trim(vform.keyfield1 & "")
            'Call TXTBOOKINGNO_Validated(sender, e)
            'DTPBOOKINGDATE.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r As New party_man

        ssql = " SELECT * FROM PARTY_ARRDETAIL WHERE partydate BETWEEN '" & Format(Me.dtpfrom.Value, "dd/MMM/yyyy") & "' AND '" & Format(Me.dtpto.Value, "dd/MMM/yyyy") & "'  ORDER BY PARTYDATE"

        Viewer.Report = r

        Call Viewer.GetDetails(ssql, "PARTY_ARRDETAIL", r)
        Viewer.TableName = "PARTY_ARRDETAIL"
        Dim txtobj15 As TextObject
        txtobj15 = r.ReportDefinition.ReportObjects("Text15")
        txtobj15.Text = " FROM PARTYDATE " & Format(Me.dtpfrom.Value, "dd/MMM/yyyy") & " TO " & Format(Me.dtpto.Value, "dd/MMM/yyyy")

        Viewer.Show()
    End Sub

    Private Sub MAINTAINANCE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
    End Sub
End Class
