Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Public Class ROOMWISE
    Inherits System.Windows.Forms.Form
    Dim sqlstring As String
    Dim chkbool As Boolean
    Dim gconn As New GlobalClass
    Dim vconn As New GlobalClass
    Dim gconnection As New GlobalClass
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chklist_Rooms As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents Chk_roomselection As System.Windows.Forms.CheckBox
    Friend WithEvents Dtpbookfromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpbooktodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CHBCANCEL As System.Windows.Forms.CheckBox
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ROOMWISE))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk_roomselection = New System.Windows.Forms.CheckBox()
        Me.chklist_Rooms = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Dtpbookfromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpbooktodate = New System.Windows.Forms.DateTimePicker()
        Me.CHBCANCEL = New System.Windows.Forms.CheckBox()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gray
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(344, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(336, 24)
        Me.Label2.TabIndex = 429
        Me.Label2.Text = "HALL CODE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(235, 582)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(331, 16)
        Me.Label5.TabIndex = 428
        Me.Label5.Text = "Press F2 to select all / Press ENTER key to navigate"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Controls.Add(Me.cmdexit)
        Me.GroupBox4.Controls.Add(Me.CmdView)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(854, 181)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(143, 355)
        Me.GroupBox4.TabIndex = 427
        Me.GroupBox4.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gainsboro
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(5, 199)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 50)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Export"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Gainsboro
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(4, 54)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(137, 50)
        Me.CmdClear.TabIndex = 6
        Me.CmdClear.Text = "Clear[F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(4, 273)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(137, 50)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "Exit[F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.Gainsboro
        Me.CmdView.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.Black
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(4, 132)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(137, 50)
        Me.CmdView.TabIndex = 5
        Me.CmdView.Text = "Report [F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.Transparent
        Me.CmdPrint.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.Black
        Me.CmdPrint.Image = CType(resources.GetObject("CmdPrint.Image"), System.Drawing.Image)
        Me.CmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdPrint.Location = New System.Drawing.Point(686, 345)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(137, 50)
        Me.CmdPrint.TabIndex = 7
        Me.CmdPrint.Text = " Print [F8]"
        Me.CmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPrint.UseVisualStyleBackColor = False
        Me.CmdPrint.Visible = False
        '
        'cmdreport
        '
        Me.cmdreport.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdreport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ForeColor = System.Drawing.Color.White
        Me.cmdreport.Image = CType(resources.GetObject("cmdreport.Image"), System.Drawing.Image)
        Me.cmdreport.Location = New System.Drawing.Point(840, 568)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(104, 32)
        Me.cmdreport.TabIndex = 9
        Me.cmdreport.Text = "Export[F12]"
        Me.cmdreport.UseVisualStyleBackColor = False
        Me.cmdreport.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(174, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(422, 29)
        Me.Label3.TabIndex = 424
        Me.Label3.Text = "BANQUET HALL  CANCEL DETAILS"
        '
        'Chk_roomselection
        '
        Me.Chk_roomselection.BackColor = System.Drawing.Color.Transparent
        Me.Chk_roomselection.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_roomselection.Location = New System.Drawing.Point(344, 114)
        Me.Chk_roomselection.Name = "Chk_roomselection"
        Me.Chk_roomselection.Size = New System.Drawing.Size(138, 24)
        Me.Chk_roomselection.TabIndex = 0
        Me.Chk_roomselection.Text = "SELECT ALL "
        Me.Chk_roomselection.UseVisualStyleBackColor = False
        '
        'chklist_Rooms
        '
        Me.chklist_Rooms.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_Rooms.Location = New System.Drawing.Point(344, 164)
        Me.chklist_Rooms.Name = "chklist_Rooms"
        Me.chklist_Rooms.Size = New System.Drawing.Size(336, 276)
        Me.chklist_Rooms.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Dtpbookfromdate)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.dtpbooktodate)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(196, 496)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(608, 64)
        Me.GroupBox3.TabIndex = 431
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Party Date"
        '
        'Dtpbookfromdate
        '
        Me.Dtpbookfromdate.CustomFormat = "dd/MM/yyyy"
        Me.Dtpbookfromdate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtpbookfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpbookfromdate.Location = New System.Drawing.Point(168, 23)
        Me.Dtpbookfromdate.Name = "Dtpbookfromdate"
        Me.Dtpbookfromdate.Size = New System.Drawing.Size(120, 22)
        Me.Dtpbookfromdate.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(312, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "TO DATE :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "FROM DATE :"
        '
        'dtpbooktodate
        '
        Me.dtpbooktodate.CustomFormat = "dd/MM/yyyy"
        Me.dtpbooktodate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpbooktodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpbooktodate.Location = New System.Drawing.Point(400, 22)
        Me.dtpbooktodate.Name = "dtpbooktodate"
        Me.dtpbooktodate.Size = New System.Drawing.Size(120, 22)
        Me.dtpbooktodate.TabIndex = 4
        '
        'CHBCANCEL
        '
        Me.CHBCANCEL.BackColor = System.Drawing.Color.Transparent
        Me.CHBCANCEL.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHBCANCEL.Location = New System.Drawing.Point(344, 468)
        Me.CHBCANCEL.Name = "CHBCANCEL"
        Me.CHBCANCEL.Size = New System.Drawing.Size(168, 24)
        Me.CHBCANCEL.TabIndex = 2
        Me.CHBCANCEL.Text = "HALL CANCEL"
        Me.CHBCANCEL.UseVisualStyleBackColor = False
        Me.CHBCANCEL.Visible = False
        '
        'ROOMWISE
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.Controls.Add(Me.CmdPrint)
        Me.Controls.Add(Me.CHBCANCEL)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Chk_roomselection)
        Me.Controls.Add(Me.chklist_Rooms)
        Me.Controls.Add(Me.cmdreport)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "ROOMWISE"
        Me.Text = "BANQUET HALL  CANCEL DETAILS"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND                 MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        vconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdView.Enabled = False
        Me.CmdPrint.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdView.Enabled = True
                    Me.CmdPrint.Enabled = True
                    Exit Sub
                End If
                If Right(x) = "V" Then
                    Me.CmdView.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.CmdPrint.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub ROOMWISE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        Me.resizeFormResolution()
        rs.ResizeAllControls(Me)
        'gconnection.FocusSetting(Me)
        Call FillhallLocation()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        CmdClear_Click(sender, e)
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
    Private Sub FillhallLocation()
        Dim i As Integer
        chklist_Rooms.Items.Clear()
        sqlstring = "SELECT DISTINCT HALLTYPECODE,HALLTYPEDESC FROM PARTY_HALLMASTER_HDR "
        vconn.getDataSet(sqlstring, "HALL")
        If gdataset.Tables("HALL").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("HALL").Rows.Count - 1
                With gdataset.Tables("HALL").Rows(i)
                    chklist_Rooms.Items.Add(.Item("HALLTYPECODE") & "-->" & .Item("HALLTYPEDESC"))
                End With
            Next i
        End If
        chklist_Rooms.Sorted = True
    End Sub
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        CHBCANCEL.Checked = False
        Chk_roomselection.Checked = False
        chklist_Rooms.Items.Clear()
        Chk_roomselection.Checked = False
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Call FillhallLocation()
        Dtpbookfromdate.Value = Now.Today
        dtpbooktodate.Value = Now.Today
        Chk_roomselection.Focus()
    End Sub

    Private Sub CANCELWINDOWS()
        Dim i, j, K, cnt, cnt1 As Integer
        Dim str, MTYPE(), tspilt() As String
        Dim hallamt, rcamt As Double
        Dim Viewer As New ReportViwer
        Dim r1 As New CANbooking
        Dim dt As New DataTable
        Dim BOOKNO As Integer


        sqlstring = "SELECT * FROM partyCANCEL_view Where"
        If chklist_Rooms.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " HALLCODE IN ("
            For i = 0 To chklist_Rooms.CheckedItems.Count - 1
                tspilt = Split(chklist_Rooms.CheckedItems(i), "-->")
                If i = 0 Then
                    sqlstring = sqlstring & "'" & tspilt(0)
                Else
                    sqlstring = sqlstring & "','" & tspilt(0)
                End If
            Next
            sqlstring = sqlstring & "') "
        Else
            MessageBox.Show("Select the hall Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'sqlstring = sqlstring & " AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
        sqlstring = sqlstring & " AND CAST(Convert(varchar(11),CANCELDATE,6) AS DATETIME) BETWEEN "
        sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
        sqlstring = sqlstring & " ORDER BY PARTYDATE"
        Viewer.ssql = sqlstring

        gconn.getDataSet(sqlstring, "PARTY_HALLRESERVATION")
        If gdataset.Tables("PARTY_HALLRESERVATION").Rows.Count > 0 Then

            Viewer.Report = r1
            Viewer.TableName = "partyCANCEL_view"

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text9")
            TXTOBJ5.Text = MyCompanyName

            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text5")
            TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r1.ReportDefinition.ReportObjects("Text6")
            TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text7")
            TXTOBJ9.Text = "PhoneNo : " & gphoneno

            'Dim TXTOBJ7 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ7 = r1.ReportDefinition.ReportObjects("Text13")
            'TXTOBJ7.Text = Address2
            'Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            'Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ8 = r1.ReportDefinition.ReportObjects("Text13")
            'TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text14")
            'TXTOBJ9.Text = gphoneno

            'Dim TXTOBJ10 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ10 = r1.ReportDefinition.ReportObjects("Text16")
            'TXTOBJ10.Text = gphoneno

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r1.ReportDefinition.ReportObjects("Text3")
            TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text26")
            TXTOBJ1.Text = "UserName : " & gUsername
            Viewer.Show()

        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub
    Private Sub CANCELWINDOWS_1()
        Dim i, j, K, cnt, cnt1 As Integer
        Dim str, MTYPE(), tspilt() As String
        Dim hallamt, rcamt As Double
        Dim Viewer As New ReportViwer
        Dim r1 As New Crpt_CancelDetail
        Dim dt As New DataTable
        Dim BOOKNO As Integer

        sqlstring = "DELETE FROM Cancel_Booking "
        gconnection.dataOperation(6, sqlstring, "Del")

        sqlstring = "INSERT INTO Cancel_Booking (BookingNo,BookingDate,PartyDate,CancelDate)"
        'sqlstring = sqlstring & "SELECT BOOKINGNO,BOOKINGDATE,PARTYDATE,CANCELDATE FROM PARTY_hDR WHERE BOOKINGTYPE = 'CANCEL' AND CAST(CONVERT(VARCHAR,CANCELDATE,106) AS DATETIME) BETWEEN '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "' "
        sqlstring = sqlstring & "SELECT BOOKINGNO,BOOKINGDATE,PARTYDATE,CANCELDATE FROM PARTY_hDR WHERE BOOKINGTYPE = 'CANCEL' AND CAST(CONVERT(VARCHAR,PARTYDATE,106) AS DATETIME) BETWEEN '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "' "
        sqlstring = sqlstring & " AND BOOKINGNO IN (SELECT BOOKINGNO FROM party_hallbooking_det WHERE "
        'sqlstring = "SELECT * FROM partyCANCEL_view Where"
        If chklist_Rooms.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " HALLCODE IN ("
            For i = 0 To chklist_Rooms.CheckedItems.Count - 1
                tspilt = Split(chklist_Rooms.CheckedItems(i), "-->")
                If i = 0 Then
                    sqlstring = sqlstring & "'" & tspilt(0)
                Else
                    sqlstring = sqlstring & "','" & tspilt(0)
                End If
            Next
            sqlstring = sqlstring & "')) "
        Else
            MessageBox.Show("Select the hall Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        gconnection.dataOperation(6, sqlstring, "Del1")
        sqlstring = "EXEC Cancel_Proc 'CANCEL'"
        gconnection.dataOperation(6, sqlstring, "Del2")

        sqlstring = " SELECT * FROM Cancel_Booking ORDER BY BookingNo"
        Viewer.ssql = sqlstring

        gconn.getDataSet(sqlstring, "Cancel_Booking")
        If gdataset.Tables("Cancel_Booking").Rows.Count > 0 Then

            Viewer.Report = r1
            Viewer.TableName = "Cancel_Booking"

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text1")
            TXTOBJ5.Text = MyCompanyName

            'Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text5")
            'TXTOBJ6.Text = Address1 & Address2

            'Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ8 = r1.ReportDefinition.ReportObjects("Text6")
            'TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text7")
            'TXTOBJ9.Text = "PhoneNo : " & gphoneno

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r1.ReportDefinition.ReportObjects("Text3")
            TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text13")
            TXTOBJ1.Text = "UserName : " & gUsername

            Viewer.Show()

        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub
    Private Sub print_windows()
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r As New PARTY_VIEW_BOOKDETAILS
        Dim Heading(0) As String
        Dim sqlstring, SSQL As String

        'sqlstring = "SELECT HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESC,PDESC,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME FROM PARTY_VIEW_BOOKING_DETAILS "
        'sqlstring = "SELECT HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME FROM PARTY_VIEW_BOOKING_DETAILS "
        sqlstring = "SELECT * FROM PARTY_VIEW_BOOKDETAILS WHERE"
        If chklist_Rooms.CheckedItems.Count <> 0 Then
            'sqlstring = sqlstring & "WHERE ISNULL(BOOKINGTYPE,'')='BOOKING' AND HALLCODE IN ("
            sqlstring = sqlstring & "   bookingtype in ('booking')and HALLCODE IN ("
            For i = 0 To chklist_Rooms.CheckedItems.Count - 1
                tspilt = Split(chklist_Rooms.CheckedItems(i), "-->")
                If i = 0 Then
                    sqlstring = sqlstring & "'" & tspilt(0)
                Else
                    sqlstring = sqlstring & "','" & tspilt(0)
                End If
            Next
            sqlstring = sqlstring & "') "
        Else
            MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        'If CHBCANCEL.Checked = True Then
        '    sqlstring = sqlstring & " AND ISNULL(FREEZE,'')='Y' "
        'End If
        sqlstring = sqlstring & " AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
        sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
        'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
        sqlstring = sqlstring & " ORDER BY PARTYDATE"
        Viewer.ssql = sqlstring

        Viewer.Report = r
        Viewer.TableName = "PARTY_VIEW_BOOKDETAILS"

        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
        TXTOBJ1.Text = MyCompanyName

        Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
        TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text13")
        TXTOBJ5.Text = "UserName : " & gUsername

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text9")
        'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")
        Viewer.Show()
    End Sub

    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        If chklist_Rooms.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Hall Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Checkdaterangevalidate(Dtpbookfromdate.Value, dtpbooktodate.Value)
        If chkdatevalidate = False Then Exit Sub
        gPrint = False
        Call CANCELWINDOWS_1()
        'If MsgBox("Laser PrintOut", MsgBoxStyle.YesNo, "Laser") = MsgBoxResult.Yes Then
        '    Call CANCELWINDOWS()
        '    'Call print_windows()
        '    'Else
        '    '    Call Hallstatus()
        'End If
    End Sub
    Private Sub Hallstatus()
        Try
            Dim i As Integer
            Dim tspilt(), Heading(0) As String
            Dim sqlstring, SSQL As String
            'sqlstring = "SELECT HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESC,PDESC,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME FROM PARTY_VIEW_BOOKING_DETAILS "
            'sqlstring = "SELECT HALLCODE,ISNULL(HALLDESCRIPTION,''),BOOKINGNO,BOOKINGDATE,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGDETAILS "
            'vijay040811-ISNULL(HALLDESCRIPTION,'')
            sqlstring = "SELECT HALLCODE,HALLDESCRIPTION,BOOKINGNO,BOOKINGDATE,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGDETAILS "

            If chklist_Rooms.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE ISNULL(BOOKINGTYPE,'')='BOOKING' AND HALLCODE IN ("
                'sqlstring = sqlstring & " WHERE  HALLCODE IN ("

                For i = 0 To chklist_Rooms.CheckedItems.Count - 1
                    tspilt = Split(chklist_Rooms.CheckedItems(i), "-->")
                    If i = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(0)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(0)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the  Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If CHBCANCEL.Checked = True Then
                sqlstring = sqlstring & " AND ISNULL(FREEZE,'')='Y' "
            End If
            sqlstring = sqlstring & "AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " GROUP BY HALLCODE,HALLDESCRIPTION,BOOKINGNO,BOOKINGDATE,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            sqlstring = sqlstring & " ORDER BY HALLCODE,PARTYDATE,FROMTIME,TOTIME,BOOKINGNO"
            Dim Objbookingstatus As New Bookingstatus
            SSQL = "HALL BOOKING STATUS"
            Heading(0) = SSQL
            'insert(0) = strSQL
            Objbookingstatus.BOOKINGDETAILS(Heading, sqlstring, Dtpbookfromdate.Value, dtpbooktodate.Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        If chklist_Rooms.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Checkdaterangevalidate(Dtpbookfromdate.Value, dtpbooktodate.Value)
        If chkdatevalidate = False Then Exit Sub
        gPrint = True
        Call Hallstatus()
    End Sub
    Private Sub ROOMWISE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F2 Then
            For i = 0 To chklist_Rooms.Items.Count - 1
                chklist_Rooms.SetItemChecked(i, True)
            Next i
            Chk_roomselection.Checked = True
            Me.Dtpbookfromdate.Focus()
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            Call CmdPrint_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F9 Then
            Call CmdView_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            Call cmdexit_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.Escape Then
            Call cmdexit_Click(sender, e)
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.F Then
            Me.Dtpbookfromdate.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.T Then
            Me.dtpbooktodate.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub Chk_roomselection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_roomselection.CheckedChanged
        Dim i As Integer
        If Chk_roomselection.Checked = True Then
            For i = 0 To chklist_Rooms.Items.Count - 1
                chklist_Rooms.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklist_Rooms.Items.Count - 1
                chklist_Rooms.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub dtpbooktodate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpbooktodate.ValueChanged

    End Sub

    Private Sub Dtpbookfromdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtpbookfromdate.ValueChanged

    End Sub

    Private Sub chklist_Rooms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklist_Rooms.SelectedIndexChanged

    End Sub
    Private Sub chklist_Rooms_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chklist_Rooms.KeyDown
        If Asc(e.KeyCode) = Keys.Enter Then
            Dtpbookfromdate.Focus()
        End If
    End Sub
    Private Sub Dtpbookfromdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpbookfromdate.KeyDown
        If Asc(e.KeyCode) = Keys.Enter Then
            dtpbooktodate.Focus()
        End If
    End Sub
    Private Sub chklist_Rooms_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chklist_Rooms.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            CHBCANCEL.Focus()
        End If
    End Sub
    Private Sub Dtpbookfromdate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dtpbookfromdate.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            dtpbooktodate.Focus()
        End If
    End Sub
    Private Sub dtpbooktodate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpbooktodate.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            CmdView.Focus()
        End If
    End Sub
    Private Sub CHBCANCEL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CHBCANCEL.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Dtpbookfromdate.Focus()
        End If
    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Dim servercode() As String
        Dim i As Integer

        Dim sqlstring, SSQL As String
        Dim Viewer As New ReportViwer
        Dim r As New crptPARTY_BOOKINGDETAILS1

        Dim POSdesc(), MemberCode() As String
        Dim SQLSTRING2 As String
        sqlstring = "SELECT * FROM VIEW_PARTY_BOOKINGDETAILS WHERE"
        sqlstring = sqlstring & "  BOOKINGDATE BETWEEN '" & Format(Dtpbookfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtpbooktodate.Value, "dd/MMM/yyyy") & "'"
        sqlstring = sqlstring & " ORDER BY BOOKINGDATE,HALLCODE "
        Call Viewer.GetDetails(sqlstring, "party_view_hallstatus", r)
        Viewer.Report = r

        Viewer.TableName = "party_view_hallstatus"
        Viewer.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        Dim exp As New exportexcel
        Dim sqlstring, MTYPE(), tspilt() As String

        sqlstring = "SELECT * FROM partyCANCEL_view Where"
        If chklist_Rooms.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " HALLCODE IN ("
            For i = 0 To chklist_Rooms.CheckedItems.Count - 1
                tspilt = Split(chklist_Rooms.CheckedItems(i), "-->")
                If i = 0 Then
                    sqlstring = sqlstring & "'" & tspilt(0)
                Else
                    sqlstring = sqlstring & "','" & tspilt(0)
                End If
            Next
            sqlstring = sqlstring & "') "
        Else
            MessageBox.Show("Select the  Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        sqlstring = sqlstring & " AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
        sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
        sqlstring = sqlstring & " ORDER BY ASSOCIATENAME"

        gconn.getDataSet(sqlstring, "partyCANCEL_view")
        If gdataset.Tables("partyCANCEL_view").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "BANQUET CANCEL REPORT " & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "TO" & Format(dtpbooktodate.Value, "dd-MMM-yyyy"), "")

            'Dim sqlstring As String
            'Dim _export As New EXPORT
            '_export.TABLENAME = "VIEW_PARTY_BOOKINGDETAILS"
            'sqlstring = "select distinct from VIEW_PARTY_BOOKINGDETAILS "
            'Call _export.export_excel(sqlstring)
            '_export.Show()
            'Exit Sub
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub

    Private Sub CHBCANCEL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBCANCEL.CheckedChanged

    End Sub

    Private Sub ROOMWISE_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class

