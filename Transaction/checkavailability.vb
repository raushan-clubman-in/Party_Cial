Imports System.Data.SqlClient
Public Class checkavailability
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents Dtppartydate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmd_hallcodehelp As System.Windows.Forms.Button
    Friend WithEvents txthallcode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Halldescription As System.Windows.Forms.TextBox
    Friend WithEvents GBHALLSTATUS As System.Windows.Forms.GroupBox
    Friend WithEvents SSgrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents showstat12 As System.Windows.Forms.Button
    Friend WithEvents CMd_Exit11 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear11 As System.Windows.Forms.Button
    Friend WithEvents chklist_Rooms As System.Windows.Forms.CheckedListBox
    Friend WithEvents Chk_roomselection As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_purposeselection As System.Windows.Forms.CheckBox
    Friend WithEvents chklist_purpose As System.Windows.Forms.CheckedListBox
    Friend WithEvents chk_location As System.Windows.Forms.CheckBox
    Friend WithEvents chklist_location As System.Windows.Forms.CheckedListBox
    Friend WithEvents Cmd_Excel11 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents CMd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Excel As System.Windows.Forms.Button
    Friend WithEvents Showstat As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(checkavailability))
        Me.Dtppartydate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmd_hallcodehelp = New System.Windows.Forms.Button()
        Me.txthallcode = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Halldescription = New System.Windows.Forms.TextBox()
        Me.showstat12 = New System.Windows.Forms.Button()
        Me.GBHALLSTATUS = New System.Windows.Forms.GroupBox()
        Me.SSgrid = New AxFPSpreadADO.AxfpSpread()
        Me.CMd_Exit11 = New System.Windows.Forms.Button()
        Me.Cmd_Clear11 = New System.Windows.Forms.Button()
        Me.chklist_Rooms = New System.Windows.Forms.CheckedListBox()
        Me.Chk_roomselection = New System.Windows.Forms.CheckBox()
        Me.Chk_purposeselection = New System.Windows.Forms.CheckBox()
        Me.chklist_purpose = New System.Windows.Forms.CheckedListBox()
        Me.chk_location = New System.Windows.Forms.CheckBox()
        Me.chklist_location = New System.Windows.Forms.CheckedListBox()
        Me.Cmd_Excel11 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.CMd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_Excel = New System.Windows.Forms.Button()
        Me.Showstat = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GBHALLSTATUS.SuspendLayout()
        CType(Me.SSgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Dtppartydate
        '
        Me.Dtppartydate.CustomFormat = "dd/MM/yyyy"
        Me.Dtppartydate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtppartydate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtppartydate.Location = New System.Drawing.Point(474, 339)
        Me.Dtppartydate.Name = "Dtppartydate"
        Me.Dtppartydate.Size = New System.Drawing.Size(112, 26)
        Me.Dtppartydate.TabIndex = 365
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(330, 342)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 16)
        Me.Label1.TabIndex = 367
        Me.Label1.Text = "BANQUET DATE"
        '
        'cmd_hallcodehelp
        '
        Me.cmd_hallcodehelp.Image = CType(resources.GetObject("cmd_hallcodehelp.Image"), System.Drawing.Image)
        Me.cmd_hallcodehelp.Location = New System.Drawing.Point(32, 8)
        Me.cmd_hallcodehelp.Name = "cmd_hallcodehelp"
        Me.cmd_hallcodehelp.Size = New System.Drawing.Size(24, 26)
        Me.cmd_hallcodehelp.TabIndex = 364
        '
        'txthallcode
        '
        Me.txthallcode.BackColor = System.Drawing.Color.Wheat
        Me.txthallcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txthallcode.Location = New System.Drawing.Point(8, -184)
        Me.txthallcode.MaxLength = 12
        Me.txthallcode.Name = "txthallcode"
        Me.txthallcode.Size = New System.Drawing.Size(24, 26)
        Me.txthallcode.TabIndex = 363
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.Controls.Add(Me.Halldescription)
        Me.GroupBox1.Controls.Add(Me.txthallcode)
        Me.GroupBox1.Controls.Add(Me.cmd_hallcodehelp)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, -128)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(96, 52)
        Me.GroupBox1.TabIndex = 368
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'Halldescription
        '
        Me.Halldescription.BackColor = System.Drawing.Color.Wheat
        Me.Halldescription.Enabled = False
        Me.Halldescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Halldescription.Location = New System.Drawing.Point(56, 8)
        Me.Halldescription.MaxLength = 50
        Me.Halldescription.Name = "Halldescription"
        Me.Halldescription.Size = New System.Drawing.Size(24, 26)
        Me.Halldescription.TabIndex = 368
        '
        'showstat12
        '
        Me.showstat12.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.showstat12.Font = New System.Drawing.Font("Book Antiqua", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.showstat12.ForeColor = System.Drawing.Color.Blue
        Me.showstat12.Location = New System.Drawing.Point(32, 348)
        Me.showstat12.Name = "showstat12"
        Me.showstat12.Size = New System.Drawing.Size(146, 65)
        Me.showstat12.TabIndex = 370
        Me.showstat12.Text = "Show Status"
        Me.showstat12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.showstat12.Visible = False
        '
        'GBHALLSTATUS
        '
        Me.GBHALLSTATUS.BackColor = System.Drawing.Color.Transparent
        Me.GBHALLSTATUS.Controls.Add(Me.SSgrid)
        Me.GBHALLSTATUS.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GBHALLSTATUS.Location = New System.Drawing.Point(178, 400)
        Me.GBHALLSTATUS.Name = "GBHALLSTATUS"
        Me.GBHALLSTATUS.Size = New System.Drawing.Size(667, 254)
        Me.GBHALLSTATUS.TabIndex = 608
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
        Me.SSgrid.Size = New System.Drawing.Size(655, 238)
        Me.SSgrid.TabIndex = 609
        '
        'CMd_Exit11
        '
        Me.CMd_Exit11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMd_Exit11.Font = New System.Drawing.Font("Book Antiqua", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMd_Exit11.ForeColor = System.Drawing.Color.Blue
        Me.CMd_Exit11.Location = New System.Drawing.Point(621, 348)
        Me.CMd_Exit11.Name = "CMd_Exit11"
        Me.CMd_Exit11.Size = New System.Drawing.Size(146, 65)
        Me.CMd_Exit11.TabIndex = 371
        Me.CMd_Exit11.Text = "Exit"
        Me.CMd_Exit11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMd_Exit11.Visible = False
        '
        'Cmd_Clear11
        '
        Me.Cmd_Clear11.BackColor = System.Drawing.Color.White
        Me.Cmd_Clear11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear11.Font = New System.Drawing.Font("Book Antiqua", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear11.ForeColor = System.Drawing.Color.Blue
        Me.Cmd_Clear11.Image = CType(resources.GetObject("Cmd_Clear11.Image"), System.Drawing.Image)
        Me.Cmd_Clear11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear11.Location = New System.Drawing.Point(661, 51)
        Me.Cmd_Clear11.Name = "Cmd_Clear11"
        Me.Cmd_Clear11.Size = New System.Drawing.Size(146, 65)
        Me.Cmd_Clear11.TabIndex = 609
        Me.Cmd_Clear11.Text = "Clear"
        Me.Cmd_Clear11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear11.UseVisualStyleBackColor = False
        Me.Cmd_Clear11.Visible = False
        '
        'chklist_Rooms
        '
        Me.chklist_Rooms.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_Rooms.Location = New System.Drawing.Point(182, 133)
        Me.chklist_Rooms.Name = "chklist_Rooms"
        Me.chklist_Rooms.Size = New System.Drawing.Size(661, 191)
        Me.chklist_Rooms.TabIndex = 610
        '
        'Chk_roomselection
        '
        Me.Chk_roomselection.BackColor = System.Drawing.Color.Transparent
        Me.Chk_roomselection.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_roomselection.Location = New System.Drawing.Point(184, 105)
        Me.Chk_roomselection.Name = "Chk_roomselection"
        Me.Chk_roomselection.Size = New System.Drawing.Size(128, 24)
        Me.Chk_roomselection.TabIndex = 611
        Me.Chk_roomselection.Text = "SELECT ALL "
        Me.Chk_roomselection.UseVisualStyleBackColor = False
        '
        'Chk_purposeselection
        '
        Me.Chk_purposeselection.BackColor = System.Drawing.Color.Transparent
        Me.Chk_purposeselection.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_purposeselection.Location = New System.Drawing.Point(8, -40)
        Me.Chk_purposeselection.Name = "Chk_purposeselection"
        Me.Chk_purposeselection.Size = New System.Drawing.Size(48, 36)
        Me.Chk_purposeselection.TabIndex = 613
        Me.Chk_purposeselection.Text = "SELECT ALL "
        Me.Chk_purposeselection.UseVisualStyleBackColor = False
        Me.Chk_purposeselection.Visible = False
        '
        'chklist_purpose
        '
        Me.chklist_purpose.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chklist_purpose.Location = New System.Drawing.Point(48, -120)
        Me.chklist_purpose.Name = "chklist_purpose"
        Me.chklist_purpose.Size = New System.Drawing.Size(24, 67)
        Me.chklist_purpose.TabIndex = 612
        Me.chklist_purpose.Visible = False
        '
        'chk_location
        '
        Me.chk_location.BackColor = System.Drawing.Color.Transparent
        Me.chk_location.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chk_location.Location = New System.Drawing.Point(8, -120)
        Me.chk_location.Name = "chk_location"
        Me.chk_location.Size = New System.Drawing.Size(128, 36)
        Me.chk_location.TabIndex = 615
        Me.chk_location.Text = "SELECT ALL "
        Me.chk_location.UseVisualStyleBackColor = False
        Me.chk_location.Visible = False
        '
        'chklist_location
        '
        Me.chklist_location.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chklist_location.Location = New System.Drawing.Point(16, -112)
        Me.chklist_location.Name = "chklist_location"
        Me.chklist_location.Size = New System.Drawing.Size(32, 67)
        Me.chklist_location.TabIndex = 614
        Me.chklist_location.Visible = False
        '
        'Cmd_Excel11
        '
        Me.Cmd_Excel11.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Excel11.Font = New System.Drawing.Font("Book Antiqua", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Excel11.ForeColor = System.Drawing.Color.Blue
        Me.Cmd_Excel11.Location = New System.Drawing.Point(675, 339)
        Me.Cmd_Excel11.Name = "Cmd_Excel11"
        Me.Cmd_Excel11.Size = New System.Drawing.Size(146, 65)
        Me.Cmd_Excel11.TabIndex = 616
        Me.Cmd_Excel11.Text = "Excel"
        Me.Cmd_Excel11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Excel11.Visible = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(179, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(464, 24)
        Me.Label2.TabIndex = 617
        Me.Label2.Text = "BANQUET AVAILABILITY CHECK "
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(862, 127)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(135, 65)
        Me.Cmd_Clear.TabIndex = 864
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'CMd_Exit
        '
        Me.CMd_Exit.BackColor = System.Drawing.Color.Gainsboro
        Me.CMd_Exit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMd_Exit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMd_Exit.Image = CType(resources.GetObject("CMd_Exit.Image"), System.Drawing.Image)
        Me.CMd_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMd_Exit.Location = New System.Drawing.Point(862, 387)
        Me.CMd_Exit.Name = "CMd_Exit"
        Me.CMd_Exit.Size = New System.Drawing.Size(136, 65)
        Me.CMd_Exit.TabIndex = 865
        Me.CMd_Exit.Text = "Exit [F11]"
        Me.CMd_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_Excel
        '
        Me.Cmd_Excel.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_Excel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Excel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Excel.Image = CType(resources.GetObject("Cmd_Excel.Image"), System.Drawing.Image)
        Me.Cmd_Excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Excel.Location = New System.Drawing.Point(862, 300)
        Me.Cmd_Excel.Name = "Cmd_Excel"
        Me.Cmd_Excel.Size = New System.Drawing.Size(135, 65)
        Me.Cmd_Excel.TabIndex = 866
        Me.Cmd_Excel.Text = "Excel[F7]"
        Me.Cmd_Excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Excel.UseVisualStyleBackColor = False
        '
        'Showstat
        '
        Me.Showstat.BackColor = System.Drawing.Color.Gainsboro
        Me.Showstat.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Showstat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Showstat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Showstat.Location = New System.Drawing.Point(862, 208)
        Me.Showstat.Name = "Showstat"
        Me.Showstat.Size = New System.Drawing.Size(135, 65)
        Me.Showstat.TabIndex = 867
        Me.Showstat.Text = "Show Status"
        Me.Showstat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Showstat.UseVisualStyleBackColor = False
        '
        'checkavailability
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.Controls.Add(Me.Showstat)
        Me.Controls.Add(Me.Cmd_Excel)
        Me.Controls.Add(Me.CMd_Exit)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cmd_Excel11)
        Me.Controls.Add(Me.chk_location)
        Me.Controls.Add(Me.chklist_location)
        Me.Controls.Add(Me.Chk_purposeselection)
        Me.Controls.Add(Me.chklist_purpose)
        Me.Controls.Add(Me.Chk_roomselection)
        Me.Controls.Add(Me.chklist_Rooms)
        Me.Controls.Add(Me.Cmd_Clear11)
        Me.Controls.Add(Me.GBHALLSTATUS)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.showstat12)
        Me.Controls.Add(Me.CMd_Exit11)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Dtppartydate)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "checkavailability"
        Me.Text = "Banquet Hall Availability"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GBHALLSTATUS.ResumeLayout(False)
        CType(Me.SSgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim sqlstring, ssql, SSQL2 As String
    Dim gconnection As New GlobalClass
    Dim i As Integer
    Dim DT3 As New DataTable
    Dim tsplit() As String
    Dim rs As New Resizer1

    Private Sub cmd_hallcodehelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_hallcodehelp.Click
        Try
            Dim vform As New ListOperattion1
            gSQLString = "SELECT ISNULL(HALLTYPEDESC,'') AS HALLTYPEDESC,ISNULL(HALLTYPECODE,'') AS HALLTYPECODE FROM PARTY_HALLMASTER_HDR"
            If Trim(Search) = " " Then
                M_WhereCondition = ""
            Else
                M_WhereCondition = ""
            End If
            vform.Field = "HALLTYPEDESC,HALLTYPECODE"
            vform.vFormatstring = "              HALL DESCRIPTION            |         HALL CODE       "
            vform.vCaption = "HALL MASTER HELP"
            vform.KeyPos = 0
            vform.KeyPos1 = 1
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txthallcode.Text = Trim(vform.keyfield1 & "")
                Halldescription.Text = Trim(vform.keyfield & "")
                Dtppartydate.Focus()
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub checkavailability_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        Me.resizeFormResolution()
        rs.ResizeAllControls(Me)

        GBHALLSTATUS.Visible = False
        'Call FillLocation()
        'Call FillPURPOSE()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Call FillhallLocation1()
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
        'Me.Cmd_Add.Enabled = False
        'Me.Cmd_Freeze.Enabled = False
        'Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    'Me.Cmd_Add.Enabled = True
                    'Me.Cmd_Freeze.Enabled = True
                    'Me.Cmd_View.Enabled = True
                    Exit Sub
                End If
                'If UCase(Mid(Me.Cmd_Add.Text, 1, 1)) = "A" Then
                '    If Right(x) = "S" Then
                '        Me.Cmd_Add.Enabled = True
                '    End If
                'Else
                '    If Right(x) = "M" Then
                '        Me.Cmd_Add.Enabled = True
                '    End If
                'End If
                If Right(x) = "D" Then
                    'Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    'Me.Cmd_View.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub FillhallLocation1()
        Dim i As Integer
        chklist_Rooms.Items.Clear()
        sqlstring = "SELECT DISTINCT HALLTYPECODE,HALLTYPEDESC,PCODE,PDESC,LOCCODE,LOCDESC,FROMTIME,TOTIME FROM PARTY_VIEW_HALLMASTER"
        gconnection.getDataSet(sqlstring, "HALL")
        If gdataset.Tables("HALL").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("HALL").Rows.Count - 1
                With gdataset.Tables("HALL").Rows(i)
                    chklist_Rooms.Items.Add(Trim(.Item("HALLTYPECODE") & "-->" & .Item("HALLTYPEDESC") & "-->" & .Item("FROMTIME") & "-->" & .Item("TOTIME") & "-->" & .Item("PCODE") & "-->" & .Item("PDESC") & "-->" & .Item("LOCCODE") & "-->" & .Item("LOCDESC")))
                End With
            Next i
        End If
        chklist_Rooms.Sorted = True
    End Sub
    Private Sub FillLocation()
        Dim i As Integer
        chklist_location.Items.Clear()
        sqlstring = "SELECT DISTINCT LOCCODE,LOCDESC FROM PARTY_HALLMASTER_HDR "
        gconnection.getDataSet(sqlstring, "HALL")
        If gdataset.Tables("HALL").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("HALL").Rows.Count - 1
                With gdataset.Tables("HALL").Rows(i)
                    chklist_location.Items.Add(Trim(.Item("LOCCODE") & "-->" & .Item("LOCDESC")))
                End With
            Next i
        End If
        chklist_location.Sorted = True
    End Sub
    Private Sub FillPURPOSE()
        Dim i As Integer
        chklist_purpose.Items.Clear()
        sqlstring = "SELECT DISTINCT B.PCODE,B.PDESC FROM PARTY_HALLMASTER_DET A INNER JOIN PARTY_PURPOSEMASTER B ON A.PCODE=B.PCODE WHERE ISNULL(A.FREEZE,'')<>'Y'"
        gconnection.getDataSet(sqlstring, "HALL")
        If gdataset.Tables("HALL").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("HALL").Rows.Count - 1
                With gdataset.Tables("HALL").Rows(i)
                    chklist_purpose.Items.Add(Trim(.Item("PCODE") & "-->" & .Item("PDESC")))
                End With
            Next i
        End If
        chklist_purpose.Sorted = True
    End Sub
    Private Sub FillhallLocation()
        Dim i As Integer
        Dim tspilt(), heading(0) As String

        chklist_Rooms.Items.Clear()
        sqlstring = "SELECT DISTINCT A.HALLTYPECODE,A.HALLTYPEDESC FROM PARTY_HALLMASTER_HDR A INNER JOIN PARTY_HALLMASTER_DET B ON A.HALLTYPECODE=B.HALLTYPECODE"
        If chklist_purpose.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " WHERE B.PCODE IN ("
            For i = 0 To chklist_purpose.CheckedItems.Count - 1
                tspilt = Split(chklist_purpose.CheckedItems(i), "-->")
                If i = 0 Then
                    sqlstring = sqlstring & "'" & tspilt(0)
                Else
                    sqlstring = sqlstring & "','" & tspilt(0)
                End If
            Next
            sqlstring = sqlstring & "') "
        End If
        gconnection.getDataSet(sqlstring, "HALL")
        If gdataset.Tables("HALL").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("HALL").Rows.Count - 1
                With gdataset.Tables("HALL").Rows(i)
                    chklist_Rooms.Items.Add(Trim(.Item("HALLTYPECODE") & "-->" & .Item("HALLTYPEDESC")))
                End With
            Next i
        End If
        chklist_Rooms.Sorted = True
    End Sub
    ''''''''''''''''''''''''OLD 
    '''Private Sub Hall_Status()
    '    'PRIVATE SUB STATUSHALL
    '    Dim i, j, k As Integer
    '    SSgrid.Lock = False
    '    Try
    '        Dim dno As Integer
    '        Dim dd, dd1 As Date
    '        Dim dt As New DataTable
    '        Dim II As Integer
    '        Dim tspilt() As String

    '        ssql = " DELETE FROM PARTY_HallStatus"
    '        dt = gconnection.GetValues(ssql)
    '        dd = Dtppartydate.Value

    '        If chklist_Rooms.CheckedItems.Count <> 0 Then
    '            sqlstring = sqlstring & " WHERE B.PCODE IN ("
    '            For II = 0 To chklist_Rooms.CheckedItems.Count - 1
    '                tspilt = Split(chklist_Rooms.CheckedItems(II), "-->")
    '                txthallcode.Text = tspilt(0)
    '                For i = 0 To 6
    '                    If i = 0 Then
    '                        ssql = " SELECT FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET "
    '                        ssql = ssql & " WHERE partydate='" & Mid(Format(Dtppartydate.Value, "dd/MMM/yyyy"), 1, 11) & "'"
    '                        ssql = ssql & " and hallcode='" & txthallcode.Text & "'  and isnull(freeze,'')<>'Y' Order by Totime"
    '                    Else
    '                        dd = dd.AddDays(+1)
    '                        ssql = " SELECT FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET WHERE "
    '                        ssql = ssql & " PARTYDATE='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
    '                        ssql = ssql & " and hallcode='" & txthallcode.Text & "' order by Totime"
    '                    End If
    '                    dt = gconnection.GetValues(ssql)
    '                    If dt.Rows.Count > 0 Then
    '                        ssql = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
    '                        ssql = ssql & " values('" & Trim(txthallcode.Text) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
    '                        gconnection.ExcuteStoreProcedure(ssql)
    '                        For j = 0 To dt.Rows.Count - 1
    '                            For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
    '                                ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='B'"
    '                                ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
    '                                gconnection.ExcuteStoreProcedure(ssql)
    '                            Next
    '                            ssql = ""
    '                        Next
    '                    Else
    '                        If i = 0 Then
    '                            ssql = "Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
    '                            ssql = ssql & " values('" & Trim(txthallcode.Text) & "','" & Mid(Format(Dtppartydate.Value, "dd/MMM/yyyy"), 1, 11) & "')"
    '                        Else
    '                            ssql = "Insert Into PARTY_HallStatus(HALLCODE,Bookingdate)"
    '                            ssql = ssql & " values('" & Trim(txthallcode.Text) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
    '                        End If
    '                        gconnection.ExcuteStoreProcedure(ssql)
    '                    End If
    '                Next
    '            Next
    '        End If


    '        ssql = " SELECT HALLCODE,BOOKINGDATE,B1,B2,B3,B4,B5,B6,B7,B8,B9,B10,B11,B12,B13,B14,B15,B16,B17,B18,B19,B20,B21,B22,"
    '        ssql = ssql & " B23,B24 FROM VIEW_PARTY_STATUSHALL order by HALLCODE,bookingdate"
    '        dt = (gconnection.GetValues(ssql))
    '        SSgrid.SetActiveCell(1, 1)
    '        If dt.Rows.Count > 0 Then
    '            SSgrid.Enabled = True
    '            With SSgrid
    '                For i = 0 To dt.Rows.Count - 1
    '                    .Row = i + 1
    '                    .Col = 1
    '                    .Text = Trim(dt.Rows(i).Item("HALLCODE"))
    '                    .Row = i + 1
    '                    .Col = 2

    '                    For j = 0 To 24
    '                        If j = 0 Then
    '                            .SetActiveCell(j + 2, i + 1)
    '                            .Col = j + 2
    '                            .Row = i + 1
    '                            .BackColor = Color.GreenYellow
    '                            .ForeColor = Color.Blue
    '                            .Text = Format(dt.Rows(i).Item(dt.Columns(j + 1).ColumnName), "dd/MM/yyyy")
    '                        Else
    '                            If dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) <> "" Then
    '                                SSgrid.SetActiveCell(j + 1, i + 1)
    '                                .Col = j + 2
    '                                .Row = i + 1
    '                                .BackColor = Color.Red
    '                                '.Text = dt.Rows(i).Item(dt.Columns(j).ColumnName)
    '                            Else
    '                                SSgrid.SetActiveCell(j + 1, i + 1)
    '                                .Col = j + 2
    '                                .Row = i + 1
    '                                .BackColor = Color.Green
    '                            End If
    '                        End If
    '                    Next
    '                Next
    '                .SetActiveCell(2, 1)
    '            End With
    '        End If
    '        GBHALLSTATUS.Visible = True
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    '**********************>>>>>>>>LOGAN NEWLY CHANGED>>>>>>>>>>>>>>>>>><<<<<<<<<<<<<<<<<<<<<<<<<<
    ''''''''''''START
    Private Sub Hall_Status()
        Dim i, j, k, L As Integer
        Dim ssql, hallcode, PCODE, tspilt() As String
        Try
            Dim dno, ddiff As Integer
            Dim dd, dd1 As Date
            Dim dt As New DataTable
            Dim dt2 As New DataTable
            Dim DT1 As New DataTable
            Dim II As Integer

            ssql = " DELETE FROM PARTY_HallStatus"
            gconnection.GetValues(ssql)

            'gconnection.dataOperation(6, ssql, "DEL")
            'dt = vconn.GetValues(ssql)
            'ddiff = DateDiff(DateInterval.Day, Dtppartydate.Value, dtpbooktodate.Value)

            If chklist_Rooms.CheckedItems.Count <> 0 Then
                'sqlstring = sqlstring & " WHERE B.PCODE IN ("
                'dd = DateAdd(DateInterval.Day, -1, Dtppartydate.Value)
                dd = DateAdd(DateInterval.Day, -1, Dtppartydate.Value)
                For i = 0 To 6
                    dd = dd.AddDays(+1)
                    For II = 0 To chklist_Rooms.CheckedItems.Count - 1
                        tspilt = Split(chklist_Rooms.CheckedItems(II), "-->")
                        hallcode = tspilt(0)
                        PCODE = tspilt(4)
                        ssql = " SELECT FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET WHERE "
                        'ssql = ssql & " PARTYDATE='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                        'ssql = ssql & "  cast(convert(varchar(11),PartyTodate,106)as datetime)>='" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "'"
                        ssql = ssql & "  '" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "' BETWEEN cast(convert(varchar(11),Partydate,106)as datetime) AND cast(convert(varchar(11),PartyTodate,106)as datetime)"
                        ssql = ssql & " and hallcode='" & hallcode & "' and isnull(freeze,'')<>'Y' AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                        dt = gconnection.GetValues(ssql)

                        SSQL2 = "SELECT * FROM party_hallstatusdetails WHERE "
                        'SSQL2 = SSQL2 & " CAST(Convert(varchar(11),PARTYTODATE,106) AS DATETIME)>='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                        SSQL2 = SSQL2 & " '" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "' BETWEEN CAST(Convert(varchar(11),PARTYDATE,106) AS DATETIME) AND CAST(Convert(varchar(11),PARTYTODATE,106) AS DATETIME)"
                        SSQL2 = SSQL2 & " and hallcode='" & hallcode & "'AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                        DT3 = gconnection.GetValues(SSQL2)
                        If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
                            If dt.Rows.Count > 0 Then
                                ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                                ssql = ssql & " BOOKINGDATE='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
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
                            Else
                                ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                                ssql = ssql & " BOOKINGDATE='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
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
                            'If dt.Rows.Count > 0 Then
                            '    ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                            '    ssql = ssql & "CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                            '    ssql = ssql & " and hallcode='" & hallcode & "'"
                            '    dt2 = gconnection.GetValues(ssql)
                            '    If dt2.Rows.Count <= 0 Then
                            '        ssql = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
                            '        ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                            '        gconnection.ExcuteStoreProcedure(ssql)
                            '    End If
                            '    For j = 0 To dt.Rows.Count - 1
                            '        For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                            '            ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='B'"
                            '            ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                            '            ssql = ssql & " and hallcode='" & hallcode & "'"

                            '            gconnection.ExcuteStoreProcedure(ssql)
                            '        Next
                            '        ssql = ""
                            '    Next
                            '    If DT3.Rows.Count > 0 Then
                            '        For j = 0 To dt.Rows.Count - 1
                            '            For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                            '                ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='C'"
                            '                ssql = ssql & " Where Bookingdate='" & Format(dd, "dd/MMM/yyyy") & "'"
                            '                ssql = ssql & " and hallcode='" & hallcode & "'"

                            '                gconnection.ExcuteStoreProcedure(ssql)
                            '            Next
                            '            ssql = ""
                            '        Next
                            '    End If
                            'Else
                            '    ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                            '    ssql = ssql & " CAST(Convert(varchar(11),BOOKINGDATE,106) AS DATETIME)='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                            '    ssql = ssql & " and hallcode='" & hallcode & "'"
                            '    dt2 = gconnection.GetValues(ssql)
                            '    If dt2.Rows.Count <= 0 Then
                            '        ssql = "Insert Into PARTY_HallStatus(HALLCODE,Bookingdate)"
                            '        ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                            '        gconnection.ExcuteStoreProcedure(ssql)
                            '    End If
                            'End If
                            If dt.Rows.Count > 0 Then
                                ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                                ssql = ssql & "  cast(convert(varchar(11),BOOKINGDATE,106)as datetime)='" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "'"
                                ssql = ssql & " and hallcode='" & txthallcode.Text & "'"
                                dt2 = gconnection.GetValues(ssql)
                                If dt2.Rows.Count <= 0 Then
                                    ssql = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
                                    ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "')"
                                    gconnection.ExcuteStoreProcedure(ssql)
                                End If

                                For j = 0 To dt.Rows.Count - 1
                                    For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                        ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='P'"
                                        ssql = ssql & " Where Bookingdate='" & Format(dd, "yyyy-MM-dd") & "' AND HALLCODE='" & Trim(hallcode) & "'"
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
                                ssql = " SELECT FROMTIME,TOTIME,H_Type FROM  PARTY_HALLBOOKING_DET WHERE "
                                ssql = ssql & "  '" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "' BETWEEN cast(convert(varchar(11),Partydate,106)as datetime) AND cast(convert(varchar(11),PartyTodate,106)as datetime)"
                                ssql = ssql & " and hallcode ='" & Trim(txthallcode.Text) & "'AND HALLTYPE = '" & Trim(hallcode) & "' AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                                dt = gconnection.GetValues(ssql)
                                If dt.Rows.Count > 0 Then
                                    ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                                    ssql = ssql & "  cast(convert(varchar(11),BOOKINGDATE,106)as datetime)='" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "'"
                                    ssql = ssql & " and hallcode='" & hallcode & "'"
                                    dt2 = gconnection.GetValues(ssql)
                                    If dt2.Rows.Count <= 0 Then
                                        ssql = " Insert Into PARTY_HallStatus(HALLCODE,Bookingdate) "
                                        ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "')"
                                        gconnection.ExcuteStoreProcedure(ssql)
                                    End If

                                    For j = 0 To dt.Rows.Count - 1
                                        For k = Val(dt.Rows(j).Item("fromtime")) To Val(dt.Rows(j).Item("totime"))
                                            ssql = " Update PARTY_HallStatus set b" & Trim(k) & "='P'"
                                            ssql = ssql & " Where Bookingdate='" & Format(dd, "yyyy-MM-dd") & "' AND HALLCODE='" & Trim(hallcode) & "'"
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
                                    ssql = ssql & " BOOKINGDATE='" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "'"
                                    ssql = ssql & " and hallcode='" & txthallcode.Text & "'"
                                    dt2 = gconnection.GetValues(ssql)
                                    If dt2.Rows.Count <= 0 Then
                                        ssql = "Insert Into PARTY_HallStatus(HALLCODE,Bookingdate)"
                                        ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "yyyy-MM-dd"), 1, 11) & "')"
                                        gconnection.ExcuteStoreProcedure(ssql)
                                    End If
                                End If

                            End If
                        End If
                    Next
                Next
            End If
            ssql = "UPDATE PARTY_HallStatus SET SUPERSET = 'N'"
            gconnection.ExcuteStoreProcedure(ssql)
            ssql = "UPDATE PARTY_HallStatus SET SUPERSET = 'Y' FROM PARTY_HALLMASTER_HDR H,PARTY_HallStatus S WHERE H.halltypecode = S.HALLCODE"
            gconnection.ExcuteStoreProcedure(ssql)

            If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
                ssql = " SELECT HALLCODE,BOOKINGDATE,B1,B2,B3,B4,B5,B6,B7,B8,B9,B10,B11,B12,B13,B14,B15,B16,B17,B18,B19,B20,B21,B22,"
                ssql = ssql & " B23,B24 FROM VIEW_PARTY_STATUSHALL order by bookingdate,HALLCODE"
                dt = (gconnection.GetValues(ssql))
                SSgrid.SetActiveCell(1, 1)
                Dim rowid As Integer
                If dt.Rows.Count > 0 Then
                    SSgrid.Enabled = True
                    rowid = 0
                    With SSgrid
                        For i = 0 To dt.Rows.Count - 1
                            rowid = rowid + 1
                            .Row = rowid
                            .Col = 1
                            .Text = Trim(dt.Rows(i).Item("HALLCODE"))
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
                                    If dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) <> "" Then
                                        SSgrid.SetActiveCell(j + 1, rowid)
                                        .Col = j + 2
                                        .Row = rowid
                                        .BackColor = Color.Red
                                        '.Text = dt.Rows(i).Item(dt.Columns(j).ColumnName)
                                    Else
                                        SSgrid.SetActiveCell(j + 1, rowid)
                                        .Col = j + 2
                                        .Row = rowid
                                        .BackColor = Color.Green
                                    End If
                                End If
                            Next
                        Next
                        .SetActiveCell(2, 1)
                    End With
                End If
                GBHALLSTATUS.Visible = True
            Else
                ssql = " SELECT HALLCODE,BOOKINGDATE,B1,B2,B3,B4,B5,B6,B7,B8,B9,B10,B11,B12,B13,B14,B15,B16,B17,B18,B19,B20,B21,B22,"
                ssql = ssql & " B23,B24,SUPERSET FROM VIEW_PARTY_STATUSHALL order by bookingdate,HALLCODE"
                dt = (gconnection.GetValues(ssql))
                SSgrid.SetActiveCell(1, 1)
                Dim rowid As Integer
                Dim Super As String
                If dt.Rows.Count > 0 Then
                    SSgrid.Enabled = True
                    rowid = 0
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
                                'If j = 0 Then
                                '    .SetActiveCell(j + 2, rowid)
                                '    .Col = j + 2
                                '    .Row = rowid
                                '    .BackColor = Color.Green 'Yellow
                                '    .ForeColor = Color.Blue
                                '    .Text = Format(dt.Rows(i).Item(dt.Columns(j + 1).ColumnName), "dd/MM/yyyy")
                                'Else
                                '    'If dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) <> "" Then
                                '    '    SSgrid.SetActiveCell(j + 1, rowid)
                                '    '    .Col = j + 2
                                '    '    .Row = rowid
                                '    '    .BackColor = Color.Red
                                '    '    '.Text = dt.Rows(i).Item(dt.Columns(j).ColumnName)
                                '    'Else
                                '    '    SSgrid.SetActiveCell(j + 1, rowid)
                                '    '    .Col = j + 2
                                '    '    .Row = rowid
                                '    '    .BackColor = Color.Green
                                '    'End If
                                '    If dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) = "C" Then
                                '        SSgrid.SetActiveCell(j + 1, rowid)
                                '        .Col = j + 2
                                '        .Row = rowid
                                '        .Text = "C"
                                '        .BackColor = Color.Red
                                '        '.Text = dt.Rows(i).Item(dt.Columns(j).ColumnName)
                                '    ElseIf dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) = "B" Then
                                '        SSgrid.SetActiveCell(j + 1, rowid)
                                '        .Col = j + 2
                                '        .Row = rowid
                                '        .Text = "B"
                                '        .BackColor = Color.Blue
                                '    Else

                                '        SSgrid.SetActiveCell(j + 1, rowid)
                                '        .Col = j + 2
                                '        .Row = rowid
                                '        ' .Text = "VA"
                                '        .BackColor = Color.Green
                                '    End If
                                'End If
                                If j = 0 Then
                                    .SetActiveCell(j + 2, rowid)
                                    .Col = j + 2
                                    .Row = rowid
                                    .BackColor = Color.GreenYellow
                                    .ForeColor = Color.Blue
                                    .Text = Format(dt.Rows(i).Item(dt.Columns(j + 1).ColumnName), "dd/MM/yyyy")
                                Else
                                    If dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) = "C" And Super = "N" Then
                                        SSgrid.SetActiveCell(j + 1, rowid)
                                        .Col = j + 2
                                        .Row = rowid
                                        .Text = "C"
                                        .BackColor = Color.Red
                                    ElseIf dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) = "C" And Super = "Y" Then
                                        SSgrid.SetActiveCell(j + 1, rowid)
                                        .Col = j + 2
                                        .Row = rowid
                                        .Text = "C"
                                        .BackColor = Color.Red

                                    ElseIf dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) = "P" And Super = "N" Then
                                        SSgrid.SetActiveCell(j + 1, rowid)
                                        .Col = j + 2
                                        .Row = rowid
                                        .Text = "P"
                                        .BackColor = Color.Blue
                                        '.Text = dt.Rows(i).Item(dt.Columns(j).ColumnName)
                                    ElseIf dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) = "P" And Super = "Y" Then
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
                        .SetActiveCell(2, 1)
                    End With
                End If
                GBHALLSTATUS.Visible = True
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''''''''''''''''''''''''''''''''END 

    ''''****************************RAUSHAN CHANGED ****************************<<<<<<<<<<<<<<<<<<<
    Private Sub Hall_Stat()
        Dim i, j, k, L As Integer
        Dim ssql, hallcode, PCODE, tspilt() As String
        Try
            Dim dno, ddiff As Integer
            Dim dd, dd1 As Date
            Dim dt As New DataTable
            Dim dt2 As New DataTable
            Dim DT1 As New DataTable
            Dim II As Integer

            ssql = " DELETE FROM PARTY_HallStatus"
            gconnection.GetValues(ssql)

            'gconnection.dataOperation(6, ssql, "DEL")
            'dt = vconn.GetValues(ssql)
            'ddiff = DateDiff(DateInterval.Day, Dtppartydate.Value, dtpbooktodate.Value)

            If chklist_Rooms.CheckedItems.Count <> 0 Then
                'sqlstring = sqlstring & " WHERE B.PCODE IN ("
                dd = DateAdd(DateInterval.Day, -1, Dtppartydate.Value)
                For i = 0 To 6
                    dd = dd.AddDays(+1)
                    For II = 0 To chklist_Rooms.CheckedItems.Count - 1
                        tspilt = Split(chklist_Rooms.CheckedItems(II), "-->")
                        hallcode = tspilt(0)
                        PCODE = tspilt(4)
                        ssql = " SELECT FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET WHERE "
                        ssql = ssql & " PARTYDATE='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                        ssql = ssql & " and hallcode='" & hallcode & "' and isnull(freeze,'')<>'Y' AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"
                        'ssql = " SELECT FROMTIME,TOTIME FROM  PARTY_HALLBOOKING_DET WHERE "
                        'ssql = ssql & " PARTYDATE='" & Format(Dtppartydate.Value, "yyyy-MM-dd") & "'"
                        'ssql = ssql & " and hallcode='" & hallcode & "' and isnull(freeze,'')<>'Y' AND HALLTYPE = '" & Trim(PCODE) & "' order by Totime"

                        dt = gconnection.GetValues(ssql)
                        If dt.Rows.Count > 0 Then
                            ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                            ssql = ssql & " BOOKINGDATE='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
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
                        Else
                            ssql = " SELECT * FROM  PARTY_HallStatus WHERE "
                            ssql = ssql & " BOOKINGDATE='" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "'"
                            ssql = ssql & " and hallcode='" & hallcode & "'"
                            dt2 = gconnection.GetValues(ssql)
                            If dt2.Rows.Count <= 0 Then
                                ssql = "Insert Into PARTY_HallStatus(HALLCODE,Bookingdate)"
                                ssql = ssql & " values('" & Trim(hallcode) & "','" & Mid(Format(dd, "dd/MMM/yyyy"), 1, 11) & "')"
                                gconnection.ExcuteStoreProcedure(ssql)
                            End If
                        End If
                    Next
                Next
            End If
            ssql = " SELECT HALLCODE,BOOKINGDATE,B1,B2,B3,B4,B5,B6,B7,B8,B9,B10,B11,B12,B13,B14,B15,B16,B17,B18,B19,B20,B21,B22,"
            ssql = ssql & " B23,B24 FROM VIEW_PARTY_STATUSHALL order by bookingdate,HALLCODE"
            dt = (gconnection.GetValues(ssql))
            SSgrid.SetActiveCell(1, 1)
            Dim rowid As Integer
            If dt.Rows.Count > 0 Then
                SSgrid.Enabled = True
                rowid = 0
                With SSgrid
                    For i = 0 To dt.Rows.Count - 1
                        rowid = rowid + 1
                        .Row = rowid
                        .Col = 1
                        .Text = Trim(dt.Rows(i).Item("HALLCODE"))
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
                                If dt.Rows(i).Item(dt.Columns(j + 1).ColumnName) <> "" Then
                                    SSgrid.SetActiveCell(j + 1, rowid)
                                    .Col = j + 2
                                    .Row = rowid
                                    .BackColor = Color.Red
                                    '.Text = dt.Rows(i).Item(dt.Columns(j).ColumnName)
                                Else
                                    SSgrid.SetActiveCell(j + 1, rowid)
                                    .Col = j + 2
                                    .Row = rowid
                                    .BackColor = Color.Green
                                End If
                            End If
                        Next
                    Next
                    .SetActiveCell(2, 1)
                End With
            End If
            GBHALLSTATUS.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ''''''''''''*******************************<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
    End Sub
  
    Private Sub txthallcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthallcode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txthallcode.Text) <> "" Then
                Call txthallcode_Validated(txthallcode, e)
            Else
                cmd_hallcodehelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txthallcode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txthallcode.Validated
        If Trim(txthallcode.Text) <> "" Then
            sqlstring = "SELECT HALLTYPECODE,HALLTYPEDESC FROM PARTY_HALLMASTER_HDR WHERE HALLTYPECODE='" & Trim(txthallcode.Text) & "'"
            gconnection.getDataSet(sqlstring, "HALL")
            If gdataset.Tables("HALL").Rows.Count > 0 Then
                Halldescription.Text = gdataset.Tables("HALL").Rows(0).Item("HALLTYPEDESC")
                Dtppartydate.Focus()
            Else
                txthallcode.Text = ""
                txthallcode.Focus()
            End If
        End If
    End Sub
 
  
    Private Sub Chk_roomselection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_roomselection.CheckedChanged
        If Chk_roomselection.Checked = True Then
            For i = 0 To chklist_Rooms.Items.Count - 1
                chklist_Rooms.SetItemChecked(i, True)
            Next
        ElseIf Chk_roomselection.Checked = False Then
            For i = 0 To chklist_Rooms.Items.Count - 1
                chklist_Rooms.SetItemChecked(i, False)
            Next
        End If
    End Sub
    Private Sub chk_location_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_location.CheckedChanged
        If chk_location.Checked = True Then
            For i = 0 To chklist_location.Items.Count - 1
                chklist_location.SetItemChecked(i, True)
            Next
        ElseIf chk_location.Checked = False Then
            For i = 0 To chklist_location.Items.Count - 1
                chklist_location.SetItemChecked(i, False)
            Next
        End If
    End Sub
    Private Sub Chk_purposeselection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_purposeselection.CheckedChanged
        If Chk_purposeselection.Checked = True Then
            For i = 0 To chklist_purpose.Items.Count - 1
                chklist_purpose.SetItemChecked(i, True)
            Next
        ElseIf Chk_purposeselection.Checked = False Then
            For i = 0 To chklist_purpose.Items.Count - 1
                chklist_purpose.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub chklist_purpose_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklist_purpose.SelectedIndexChanged
        Call FillhallLocation()
    End Sub
  

    Private Sub checkavailability_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call CMd_Exit_Click(CMd_Exit, e)
            Exit Sub
        End If

        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(sender, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then 'cmd_Freeze
            Call Cmd_Excel_Click(sender, e)
            Exit Sub
        End If
        '' ''If e.KeyCode = Keys.F8 Then
        '' ''    Call CMD_FREEZE_Click(cmd_Freeze3, e)
        '' ''    Exit Sub
        '' ''End If
        '' ''If e.KeyCode = Keys.F9 Then
        '' ''    Call Cmdview_Click(cmd_View, e)
        '' ''    Exit Sub
        '' ''End If

    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        txthallcode.Text = ""
        Halldescription.Text = ""
        Dtppartydate.Text = DateTime.Now
        GBHALLSTATUS.Visible = False
        'Call FillLocation()
        'Call FillhallLocation()
        'Call FillPURPOSE()
        SSgrid.ClearRange(1, 1, -1, -1, True)
        Call FillhallLocation1()
        Chk_roomselection.Checked = False
        Dtppartydate.Focus()
    End Sub

    Private Sub Showstat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Showstat.Click
        SSgrid.Focus()
        If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
            Call Hall_Stat()
        Else
            Call Hall_Status()
        End If
    End Sub

    Private Sub Cmd_Excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Excel.Click, Cmd_Excel11.Click
        Call ExportTo(SSgrid)
    End Sub

    Private Sub CMd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMd_Exit.Click
        Me.Close()
    End Sub

    Private Sub checkavailability_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class
