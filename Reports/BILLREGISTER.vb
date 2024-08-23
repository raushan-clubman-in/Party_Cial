Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Public Class BILLREGISTER
    Inherits System.Windows.Forms.Form
    Dim sqlstring As String
    Dim chkbool As Boolean
    Dim vconn As New GlobalClass
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
    Friend WithEvents CHBCANCEL As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Dtpbookfromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpbooktodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents Chk_roomselection As System.Windows.Forms.CheckBox
    Friend WithEvents chklist_Rooms As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CMBBOOKINGTYPE As System.Windows.Forms.ComboBox
    Friend WithEvents CHK_DATEWISE As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_HALLWISE As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_LOCATIONSELECTION As System.Windows.Forms.CheckBox
    Friend WithEvents CHKLIST_LOCATION As System.Windows.Forms.CheckedListBox
    Friend WithEvents CHK_ACCOUNTS As System.Windows.Forms.CheckBox
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents CHK_ADJUSTED As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_NOTADJUST As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_BALANCE As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_item As System.Windows.Forms.CheckBox
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(BILLREGISTER))
        Me.CHBCANCEL = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Dtpbookfromdate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpbooktodate = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdexport = New System.Windows.Forms.Button
        Me.CmdClear = New System.Windows.Forms.Button
        Me.CmdPrint = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.CmdView = New System.Windows.Forms.Button
        Me.cmdreport = New System.Windows.Forms.Button
        Me.Chk_roomselection = New System.Windows.Forms.CheckBox
        Me.chklist_Rooms = New System.Windows.Forms.CheckedListBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CMBBOOKINGTYPE = New System.Windows.Forms.ComboBox
        Me.CHK_DATEWISE = New System.Windows.Forms.CheckBox
        Me.CHK_HALLWISE = New System.Windows.Forms.CheckBox
        Me.CHK_LOCATIONSELECTION = New System.Windows.Forms.CheckBox
        Me.CHKLIST_LOCATION = New System.Windows.Forms.CheckedListBox
        Me.CHK_ACCOUNTS = New System.Windows.Forms.CheckBox
        Me.CHK_ADJUSTED = New System.Windows.Forms.CheckBox
        Me.CHK_NOTADJUST = New System.Windows.Forms.CheckBox
        Me.CHK_BALANCE = New System.Windows.Forms.CheckBox
        Me.Chk_item = New System.Windows.Forms.CheckBox
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'CHBCANCEL
        '
        Me.CHBCANCEL.BackColor = System.Drawing.Color.Transparent
        Me.CHBCANCEL.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHBCANCEL.Location = New System.Drawing.Point(-8, 360)
        Me.CHBCANCEL.Name = "CHBCANCEL"
        Me.CHBCANCEL.Size = New System.Drawing.Size(136, 24)
        Me.CHBCANCEL.TabIndex = 3
        Me.CHBCANCEL.Text = "HALL CANCEL"
        Me.CHBCANCEL.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Dtpbookfromdate)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.dtpbooktodate)
        Me.GroupBox3.Location = New System.Drawing.Point(160, 448)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(712, 64)
        Me.GroupBox3.TabIndex = 437
        Me.GroupBox3.TabStop = False
        '
        'Dtpbookfromdate
        '
        Me.Dtpbookfromdate.CustomFormat = "dd/MM/yyyy"
        Me.Dtpbookfromdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtpbookfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpbookfromdate.Location = New System.Drawing.Point(168, 23)
        Me.Dtpbookfromdate.Name = "Dtpbookfromdate"
        Me.Dtpbookfromdate.Size = New System.Drawing.Size(120, 26)
        Me.Dtpbookfromdate.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(400, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 22)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "TO DATE :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 22)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "FROM DATE :"
        '
        'dtpbooktodate
        '
        Me.dtpbooktodate.CustomFormat = "dd/MM/yyyy"
        Me.dtpbooktodate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpbooktodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpbooktodate.Location = New System.Drawing.Point(488, 22)
        Me.dtpbooktodate.Name = "dtpbooktodate"
        Me.dtpbooktodate.Size = New System.Drawing.Size(120, 26)
        Me.dtpbooktodate.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(248, 584)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(520, 22)
        Me.Label5.TabIndex = 436
        Me.Label5.Text = "Press F2 to select all / Press ENTER key to navigate"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.cmdexport)
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Controls.Add(Me.CmdPrint)
        Me.GroupBox4.Controls.Add(Me.cmdexit)
        Me.GroupBox4.Controls.Add(Me.CmdView)
        Me.GroupBox4.Controls.Add(Me.cmdreport)
        Me.GroupBox4.Location = New System.Drawing.Point(88, 520)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(848, 56)
        Me.GroupBox4.TabIndex = 435
        Me.GroupBox4.TabStop = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Image = CType(resources.GetObject("cmdexport.Image"), System.Drawing.Image)
        Me.cmdexport.Location = New System.Drawing.Point(464, 16)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(104, 32)
        Me.cmdexport.TabIndex = 10
        Me.cmdexport.Text = "Export [F10]"
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdClear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.White
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.Location = New System.Drawing.Point(40, 15)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(104, 32)
        Me.CmdClear.TabIndex = 7
        Me.CmdClear.Text = "Clear[F6]"
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdPrint.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.White
        Me.CmdPrint.Image = CType(resources.GetObject("CmdPrint.Image"), System.Drawing.Image)
        Me.CmdPrint.Location = New System.Drawing.Point(328, 15)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(104, 32)
        Me.CmdPrint.TabIndex = 8
        Me.CmdPrint.Text = " Print [F8]"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.White
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.Location = New System.Drawing.Point(720, 15)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(104, 32)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "Exit[F11]"
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdView.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.White
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.Location = New System.Drawing.Point(192, 15)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(104, 32)
        Me.CmdView.TabIndex = 6
        Me.CmdView.Text = "View [F9]"
        '
        'cmdreport
        '
        Me.cmdreport.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdreport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdreport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ForeColor = System.Drawing.Color.White
        Me.cmdreport.Image = CType(resources.GetObject("cmdreport.Image"), System.Drawing.Image)
        Me.cmdreport.Location = New System.Drawing.Point(592, 16)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(104, 32)
        Me.cmdreport.TabIndex = 9
        Me.cmdreport.Text = "Report[F11]"
        '
        'Chk_roomselection
        '
        Me.Chk_roomselection.BackColor = System.Drawing.Color.Transparent
        Me.Chk_roomselection.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_roomselection.Location = New System.Drawing.Point(536, 112)
        Me.Chk_roomselection.Name = "Chk_roomselection"
        Me.Chk_roomselection.Size = New System.Drawing.Size(138, 24)
        Me.Chk_roomselection.TabIndex = 432
        Me.Chk_roomselection.Text = "SELECT ALL "
        '
        'chklist_Rooms
        '
        Me.chklist_Rooms.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chklist_Rooms.Location = New System.Drawing.Point(536, 136)
        Me.chklist_Rooms.Name = "chklist_Rooms"
        Me.chklist_Rooms.Size = New System.Drawing.Size(336, 277)
        Me.chklist_Rooms.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(448, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(155, 25)
        Me.Label3.TabIndex = 439
        Me.Label3.Text = "BILLREGISTER"
        '
        'CMBBOOKINGTYPE
        '
        Me.CMBBOOKINGTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBBOOKINGTYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBBOOKINGTYPE.Items.AddRange(New Object() {"BILLING"})
        Me.CMBBOOKINGTYPE.Location = New System.Drawing.Point(360, 79)
        Me.CMBBOOKINGTYPE.Name = "CMBBOOKINGTYPE"
        Me.CMBBOOKINGTYPE.Size = New System.Drawing.Size(335, 28)
        Me.CMBBOOKINGTYPE.TabIndex = 0
        '
        'CHK_DATEWISE
        '
        Me.CHK_DATEWISE.BackColor = System.Drawing.Color.Transparent
        Me.CHK_DATEWISE.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_DATEWISE.Location = New System.Drawing.Point(16, 208)
        Me.CHK_DATEWISE.Name = "CHK_DATEWISE"
        Me.CHK_DATEWISE.Size = New System.Drawing.Size(136, 24)
        Me.CHK_DATEWISE.TabIndex = 440
        Me.CHK_DATEWISE.Text = "DATEWISE"
        Me.CHK_DATEWISE.Visible = False
        '
        'CHK_HALLWISE
        '
        Me.CHK_HALLWISE.BackColor = System.Drawing.Color.Transparent
        Me.CHK_HALLWISE.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_HALLWISE.Location = New System.Drawing.Point(136, 360)
        Me.CHK_HALLWISE.Name = "CHK_HALLWISE"
        Me.CHK_HALLWISE.Size = New System.Drawing.Size(128, 24)
        Me.CHK_HALLWISE.TabIndex = 441
        Me.CHK_HALLWISE.Text = "HALLWISE"
        Me.CHK_HALLWISE.Visible = False
        '
        'CHK_LOCATIONSELECTION
        '
        Me.CHK_LOCATIONSELECTION.BackColor = System.Drawing.Color.Transparent
        Me.CHK_LOCATIONSELECTION.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_LOCATIONSELECTION.Location = New System.Drawing.Point(184, 112)
        Me.CHK_LOCATIONSELECTION.Name = "CHK_LOCATIONSELECTION"
        Me.CHK_LOCATIONSELECTION.Size = New System.Drawing.Size(138, 24)
        Me.CHK_LOCATIONSELECTION.TabIndex = 443
        Me.CHK_LOCATIONSELECTION.Text = "SELECT ALL "
        '
        'CHKLIST_LOCATION
        '
        Me.CHKLIST_LOCATION.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.CHKLIST_LOCATION.Location = New System.Drawing.Point(184, 136)
        Me.CHKLIST_LOCATION.Name = "CHKLIST_LOCATION"
        Me.CHKLIST_LOCATION.Size = New System.Drawing.Size(336, 277)
        Me.CHKLIST_LOCATION.TabIndex = 442
        '
        'CHK_ACCOUNTS
        '
        Me.CHK_ACCOUNTS.BackColor = System.Drawing.Color.Transparent
        Me.CHK_ACCOUNTS.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_ACCOUNTS.Location = New System.Drawing.Point(248, 424)
        Me.CHK_ACCOUNTS.Name = "CHK_ACCOUNTS"
        Me.CHK_ACCOUNTS.Size = New System.Drawing.Size(112, 24)
        Me.CHK_ACCOUNTS.TabIndex = 444
        Me.CHK_ACCOUNTS.Text = "ACCOUNTS"
        '
        'CHK_ADJUSTED
        '
        Me.CHK_ADJUSTED.BackColor = System.Drawing.Color.Transparent
        Me.CHK_ADJUSTED.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_ADJUSTED.Location = New System.Drawing.Point(432, 424)
        Me.CHK_ADJUSTED.Name = "CHK_ADJUSTED"
        Me.CHK_ADJUSTED.Size = New System.Drawing.Size(112, 24)
        Me.CHK_ADJUSTED.TabIndex = 445
        Me.CHK_ADJUSTED.Text = "ADJUSTED"
        '
        'CHK_NOTADJUST
        '
        Me.CHK_NOTADJUST.BackColor = System.Drawing.Color.Transparent
        Me.CHK_NOTADJUST.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_NOTADJUST.Location = New System.Drawing.Point(664, 424)
        Me.CHK_NOTADJUST.Name = "CHK_NOTADJUST"
        Me.CHK_NOTADJUST.Size = New System.Drawing.Size(136, 24)
        Me.CHK_NOTADJUST.TabIndex = 446
        Me.CHK_NOTADJUST.Text = "NOT ADJUST"
        '
        'CHK_BALANCE
        '
        Me.CHK_BALANCE.BackColor = System.Drawing.Color.Transparent
        Me.CHK_BALANCE.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_BALANCE.Location = New System.Drawing.Point(896, 416)
        Me.CHK_BALANCE.Name = "CHK_BALANCE"
        Me.CHK_BALANCE.Size = New System.Drawing.Size(16, 24)
        Me.CHK_BALANCE.TabIndex = 447
        Me.CHK_BALANCE.Text = "BALANCE"
        Me.CHK_BALANCE.Visible = False
        '
        'Chk_item
        '
        Me.Chk_item.BackColor = System.Drawing.Color.Transparent
        Me.Chk_item.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_item.Location = New System.Drawing.Point(8, 256)
        Me.Chk_item.Name = "Chk_item"
        Me.Chk_item.Size = New System.Drawing.Size(112, 24)
        Me.Chk_item.TabIndex = 448
        Me.Chk_item.Text = "ITEMWISE"
        Me.Chk_item.Visible = False
        '
        'BILLREGISTER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(238, Byte), CType(249, Byte), CType(232, Byte))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1024, 613)
        Me.Controls.Add(Me.CHK_BALANCE)
        Me.Controls.Add(Me.CHK_NOTADJUST)
        Me.Controls.Add(Me.CHK_ADJUSTED)
        Me.Controls.Add(Me.CHK_ACCOUNTS)
        Me.Controls.Add(Me.CHK_LOCATIONSELECTION)
        Me.Controls.Add(Me.CHKLIST_LOCATION)
        Me.Controls.Add(Me.CHK_HALLWISE)
        Me.Controls.Add(Me.CMBBOOKINGTYPE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CHBCANCEL)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Chk_roomselection)
        Me.Controls.Add(Me.chklist_Rooms)
        Me.Controls.Add(Me.CHK_DATEWISE)
        Me.Controls.Add(Me.Chk_item)
        Me.KeyPreview = True
        Me.Name = "BILLREGISTER"
        Me.Text = "BILLREGISTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

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
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        CHBCANCEL.Checked = False
        CHK_ACCOUNTS.Checked = False
        CHK_ADJUSTED.Checked = False
        CHK_NOTADJUST.Checked = False
        CMBBOOKINGTYPE.SelectedIndex = 0
        chklist_Rooms.Items.Clear()
        Chk_roomselection.Checked = False
        CHK_LOCATIONSELECTION.Checked = False
        Call FillhallLocation()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Dtpbookfromdate.Value = Now()
        dtpbooktodate.Value = Now()
        CMBBOOKINGTYPE.Focus()
    End Sub
    Private Sub BILLREGISTER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        Call FillLOCATION()
        CMBBOOKINGTYPE.SelectedIndex = 0
        Dtpbookfromdate.Value = Now.Today
        dtpbooktodate.Value = Now.Today
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        CmdClear_Click(sender, e)
    End Sub
    Private Sub FillLOCATION()
        Dim i As Integer
        Dim tspilt() As String
        CHKLIST_LOCATION.Items.Clear()
        sqlstring = "SELECT DISTINCT LOCCODE,LOCDESC FROM PARTY_LOCATIONMASTER "
        vconn.getDataSet(sqlstring, "HALL")
        If gdataset.Tables("HALL").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("HALL").Rows.Count - 1
                With gdataset.Tables("HALL").Rows(i)
                    CHKLIST_LOCATION.Items.Add(Trim(.Item("LOCDESC") & "=>" & .Item("LOCCODE")))
                End With
            Next i
        End If
        CHKLIST_LOCATION.Sorted = True
    End Sub
    Private Sub FillhallLocation()
        Dim i As Integer
        Dim tspilt() As String
        If CHKLIST_LOCATION.SelectedItems.Count <= 0 Then
            CHKLIST_LOCATION.Focus()
        End If
        chklist_Rooms.Items.Clear()
        sqlstring = "SELECT DISTINCT HALLTYPECODE,HALLTYPEDESC FROM PARTY_HALLMASTER_HDR "
        If CHKLIST_LOCATION.CheckedItems.Count > 0 Then
            sqlstring = sqlstring & " WHERE LOCCODE IN ("
            For i = 0 To CHKLIST_LOCATION.CheckedItems.Count - 1
                tspilt = Split(CHKLIST_LOCATION.CheckedItems(i), "=>")
                If i = 0 Then
                    sqlstring = sqlstring & "'" & tspilt(1)
                Else
                    sqlstring = sqlstring & "','" & tspilt(1)
                End If
            Next
            sqlstring = sqlstring & "') "
        End If
        vconn.getDataSet(sqlstring, "HALL")
        If gdataset.Tables("HALL").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("HALL").Rows.Count - 1
                With gdataset.Tables("HALL").Rows(i)
                    chklist_Rooms.Items.Add(Trim(.Item("HALLTYPEDESC") & "=>" & .Item("HALLTYPECODE")))
                End With
            Next i
        End If
        chklist_Rooms.Sorted = True
    End Sub
    Private Sub Hallstatus_HALLWISE()
        Try
            Dim i As Integer
            Dim tspilt(), heading(0) As String
            Dim sqlstring As String
            sqlstring = ""
            sqlstring = "SELECT BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,PARTYDATE,MCODE,ASSOCIATENAME,MNAME,HALLAMOUNT,TARIFFAMOUNT,RESTAMOUNT,ARRMENTAMOUNT,NETAMOUNT,SBFCHARGE,NETTAX,NETAMOUNT+SBFCHARGE+NETTAX AS BILLTOTAL,ADVANCE,NETPAYABLE,HALLCODE,HALLTYPE,HALLDESCRIPTION,FREEZE  FROM  VIEW_PARTY_BILLING "
            If chklist_Rooms.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE HALLCODE IN ("
                For i = 0 To chklist_Rooms.CheckedItems.Count - 1
                    tspilt = Split(chklist_Rooms.CheckedItems(i), "=>")
                    If i = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(1)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(1)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the  Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If CHKLIST_LOCATION.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " and LOCCODE IN ("
                For i = 0 To CHKLIST_LOCATION.CheckedItems.Count - 1
                    tspilt = Split(CHKLIST_LOCATION.CheckedItems(i), "=>")
                    If i = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(1)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(1)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the  Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If CHBCANCEL.Checked = True Then
                sqlstring = sqlstring & " AND ISNULL(FREEZE,'')='Y' "
            Else
                sqlstring = sqlstring & " AND ISNULL(FREEZE,'')<>'Y' "
            End If
            sqlstring = sqlstring & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            sqlstring = sqlstring & "AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY HALLCODE,PARTYDATE"
            heading(0) = "BILL REGISTER-" & Trim(CMBBOOKINGTYPE.Text)
            Dim ObjBillregister As New booking_billregister
            ObjBillregister.BOOKINGDETAILS_HALLWISE(heading, sqlstring, Dtpbookfromdate.Value, dtpbooktodate.Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub Hallstatus_ACCOUNTS()

        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r As New FINALBILLINGREPORT
        Dim Heading(0) As String
        Dim sqlstring, SSQL As String
        sqlstring = "SELECT DISTINCT * FROM FINALBILLINGREPORT WHERE"
        sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
        sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
        'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
        sqlstring = sqlstring & " ORDER BY PARTYDATE"
        Viewer.ssql = sqlstring

        Viewer.Report = r
        Viewer.TableName = "FINALBILLINGREPORT"
        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
        TXTOBJ1.Text = MyCompanyName

        Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
        TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text6")
        TXTOBJ5.Text = "UserName : " & gUsername
        Viewer.Show()
        'Dim Viewer As New ReportViwer
        'Dim r As New RPT_BOOKING_accounts
        ''Try
        'Dim i As Integer
        'Dim tspilt(), heading(0) As String
        'Dim sqlstring As String
        'Dim strhead As String
        'sqlstring = ""
        'sqlstring = "SELECT * FROM  VIEW_PARTY_BILLING_ACCOUNTS "
        'If CHKLIST_LOCATION.CheckedItems.Count <> 0 Then
        '    sqlstring = sqlstring & " WHERE LOCCODE IN ("
        '    For i = 0 To CHKLIST_LOCATION.CheckedItems.Count - 1
        '        tspilt = Split(CHKLIST_LOCATION.CheckedItems(i), "=>")
        '        If i = 0 Then
        '            sqlstring = sqlstring & "'" & tspilt(1)
        '            strhead = tspilt(0)
        '        Else
        '            sqlstring = sqlstring & "','" & tspilt(1)
        '            strhead = strhead & " , " & tspilt(0)
        '        End If
        '    Next
        '    sqlstring = sqlstring & "') "
        'Else
        '    MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If

        'sqlstring = sqlstring & "AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
        'sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
        'sqlstring = sqlstring & " ORDER BY PARTYDATE"

        'Viewer.ssql = sqlstring
        'Viewer.Report = r
        'Viewer.TableName = "VIEW_PARTY_BILLING_ACCOUNTS"
        'Dim textobj1 As TextObject
        'textobj1 = r.ReportDefinition.ReportObjects("Text6")
        'textobj1.Text = MyCompanyName
        'Dim TXTOBJ2 As TextObject
        'TXTOBJ2 = r.ReportDefinition.ReportObjects("Text10")
        'TXTOBJ2.Text = gUsername
        'Viewer.Show()
        'Viewer.Show()

        ''heading(0) = "BILL REGISTER-" & Trim(CMBBOOKINGTYPE.Text)
        ''Dim ObjBillregister As New booking_billregister
        ''ObjBillregister.BOOKINGDETAILS_ACCOUNTS(heading, sqlstring, Dtpbookfromdate.Value, dtpbooktodate.Value, strhead)
        ''Catch ex As Exception
        ''    MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        ''    Exit Sub
        ''End Try
    End Sub

    Private Sub Hallstatus_BALANCE()
        Try
            Dim i As Integer
            Dim tspilt(), heading(0) As String
            Dim sqlstring As String
            Dim strhead As String
            sqlstring = ""
            sqlstring = "SELECT * FROM  PARTY_SUMMARY_SECOND "
            If CHKLIST_LOCATION.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE LOCCODE IN ("
                For i = 0 To CHKLIST_LOCATION.CheckedItems.Count - 1
                    tspilt = Split(CHKLIST_LOCATION.CheckedItems(i), "=>")
                    If i = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(1)
                        strhead = tspilt(0)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(1)
                        strhead = strhead & " , " & tspilt(0)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the  Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            sqlstring = sqlstring & "AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " AND ISNULL(BALAMT,0)<>0 ORDER BY PARTYDATE"
            heading(0) = "SPECIAL PARTY BILL BALANCE REPORT-" & Trim(CMBBOOKINGTYPE.Text)
            Dim ObjBillregister As New booking_billregister
            ObjBillregister.BOOKINGDETAILS_BALANCE(heading, sqlstring, Dtpbookfromdate.Value, dtpbooktodate.Value, strhead)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub
    Private Sub Hallstatus_ADJUSTED()
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r As New PARTY_ACC_POST
        Dim Heading(0) As String
        Dim sqlstring, SSQL As String
        sqlstring = "SELECT DISTINCT * FROM PARTY_ACC_POST WHERE"
        sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
        sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
        'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
        sqlstring = sqlstring & " ORDER BY PARTYDATE"
        Viewer.ssql = sqlstring

        Viewer.Report = r
        Viewer.TableName = "PARTY_ACC_POST"
        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text3")
        TXTOBJ1.Text = MyCompanyName

        'Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
        'TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text10")
        TXTOBJ5.Text = "UserName : " & gUsername
        Viewer.Show()
        'Try
        '    Dim i As Integer
        '    Dim tspilt(), heading(0) As String
        '    Dim sqlstring As String
        '    Dim strhead As String
        '    sqlstring = ""

        '    sqlstring = "SELECT * FROM  PARTY_SUMMARY_ADJSUTED"
        '    If CHKLIST_LOCATION.CheckedItems.Count <> 0 Then
        '        sqlstring = sqlstring & " WHERE LOCCODE IN ("
        '        For i = 0 To CHKLIST_LOCATION.CheckedItems.Count - 1
        '            tspilt = Split(CHKLIST_LOCATION.CheckedItems(i), "=>")
        '            If i = 0 Then
        '                sqlstring = sqlstring & "'" & tspilt(1)
        '                strhead = tspilt(0)
        '            Else
        '                sqlstring = sqlstring & "','" & tspilt(1)
        '                strhead = strhead & " , " & tspilt(0)
        '            End If
        '        Next
        '        sqlstring = sqlstring & "') "
        '    Else
        '        MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '        Exit Sub
        '    End If
        '    sqlstring = sqlstring & "AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
        '    sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
        '    sqlstring = sqlstring & " ORDER BY PARTYDATE"
        '    heading(0) = "ADVANCE ADJUSTED REGISTER-" & Trim(CMBBOOKINGTYPE.Text)
        '    Dim ObjBillregister As New booking_billregister
        '    ObjBillregister.BOOKINGDETAILS_ADJUSTED(heading, sqlstring, Dtpbookfromdate.Value, dtpbooktodate.Value, strhead)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End Try
    End Sub
    Private Sub Hallstatus_NOTADJUST()
        Try
            Dim i As Integer
            Dim tspilt(), heading(0) As String
            Dim sqlstring As String
            Dim strhead As String
            sqlstring = ""
            sqlstring = "SELECT * FROM  PARTY_SUMMARY_NOTADJSUT"
            If CHKLIST_LOCATION.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE LOCCODE IN ("
                For i = 0 To CHKLIST_LOCATION.CheckedItems.Count - 1
                    tspilt = Split(CHKLIST_LOCATION.CheckedItems(i), "=>")
                    If i = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(1)
                        strhead = tspilt(0)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(1)
                        strhead = strhead & " , " & tspilt(0)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the  Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            sqlstring = sqlstring & "AND CAST(Convert(varchar(11),RECEIPTDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY RECEIPTDATE"
            heading(0) = "ADVANCE NOT ADJUST REGISTER-" & Trim(CMBBOOKINGTYPE.Text)
            Dim ObjBillregister As New booking_billregister
            ObjBillregister.BOOKINGDETAILS_NOTADJUST(heading, sqlstring, Dtpbookfromdate.Value, dtpbooktodate.Value, strhead)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Hallstatus_DATEWISE()
        Try
            Dim Viewer As New ReportViwer
            Dim r As New RPT_BOOKING_
            Dim i As Integer
            Dim tspilt(), heading(0) As String
            Dim sqlstring As String
            sqlstring = ""
            sqlstring = "SELECT *  FROM  VIEW_PARTY_BILLING WHERE"
            'sqlstring = "SELECT BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,MCODE,PARTYDATE,ASSOCIATENAME,MNAME,ADVANCE,occupancy  FROM  VIEW_PARTY_BILLING WHERE"

            If CHKLIST_LOCATION.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " LOCCODE IN ("
                For i = 0 To CHKLIST_LOCATION.CheckedItems.Count - 1
                    tspilt = Split(CHKLIST_LOCATION.CheckedItems(i), "=>")
                    If i = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(1)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(1)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the HALL Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If CHBCANCEL.Checked = True Then
                sqlstring = sqlstring & " AND ISNULL(FREEZE,'')='Y' "
            Else
                sqlstring = sqlstring & " AND ISNULL(FREEZE,'')<>'Y' "
            End If
            sqlstring = sqlstring & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            ' sqlstring = sqlstring & "AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & "AND CAST(Convert(varchar(11),BOOKINGDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY BOOKINGNO "

            Viewer.ssql = sqlstring
            Viewer.Report = r
            Viewer.TableName = "VIEW_PARTY_BILLING"
            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text16")
            TXTOBJ1.Text = MyCompanyName

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text11")
            TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text15")
            TXTOBJ5.Text = "UserName : " & gUsername
            Viewer.Show()

            'heading(0) = "BILL REGISTER-" & Trim(CMBBOOKINGTYPE.Text)
            'Dim ObjBillregister As New booking_billregister
            ' ObjBillregister.BOOKINGDETAILS_DATEWISE(heading, sqlstring, Dtpbookfromdate.Value, dtpbooktodate.Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub Hallstatus_ITEMWISE()
        Try
            Dim Viewer As New ReportViwer
            'Dim r As New RPT_BOOKING_itemwise
            Dim r As New PAR_ADDITIONALITEMS

            Dim i As Integer
            Dim tspilt(), heading(0) As String
            Dim sqlstring As String
            Dim strhead As String
            sqlstring = ""
            sqlstring = "SELECT * FROM  PRA_ITEM"
            If CHKLIST_LOCATION.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE LOCCODE IN ("
                For i = 0 To CHKLIST_LOCATION.CheckedItems.Count - 1
                    tspilt = Split(CHKLIST_LOCATION.CheckedItems(i), "=>")
                    If i = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(1)
                        strhead = tspilt(0)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(1)
                        strhead = strhead & " , " & tspilt(0)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            sqlstring = sqlstring & "AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY PARTYDATE,BOOKINGNO,ROWID"
            Viewer.ssql = sqlstring
            Viewer.Report = r

            Viewer.TableName = "PRA_ITEM"
            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text1")
            textobj1.Text = MyCompanyName
            Dim TXTOBJ2 As TextObject
            TXTOBJ2 = r.ReportDefinition.ReportObjects("Text16")
            TXTOBJ2.Text = gUsername
            Dim TXTOBJ3 As TextObject
            TXTOBJ3 = r.ReportDefinition.ReportObjects("Text3")
            TXTOBJ3.Text = " " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            Viewer.Show()
            'heading(0) = "BILL ITEM REGISTER-" & Trim(CMBBOOKINGTYPE.Text)

            'Dim ObjBillregister As New booking_billregister
            'ObjBillregister.BOOKINGDETAILS_ITEMWISE(heading, sqlstring, Dtpbookfromdate.Value, dtpbooktodate.Value, strhead)
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


        If CHK_DATEWISE.Checked = True Then
            Call Hallstatus_DATEWISE()
        ElseIf CHK_HALLWISE.Checked = True Then
            Call Hallstatus_HALLWISE()
        ElseIf CHK_ACCOUNTS.Checked = True Then
            Call Hallstatus_ACCOUNTS()
        ElseIf CHK_ADJUSTED.Checked = True Then
            Call Hallstatus_ADJUSTED()
        ElseIf CHK_NOTADJUST.Checked = True Then
            Call Hallstatus_NOTADJUST()
        End If
    End Sub
    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        If chklist_Rooms.CheckedItems.Count = 0 Then
            MessageBox.Show("Select the  Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Checkdaterangevalidate(Dtpbookfromdate.Value, dtpbooktodate.Value)
        If chkdatevalidate = False Then Exit Sub
        gPrint = False

        'If CHK_DATEWISE.Checked = True Then
        '    Call Hallstatus_DATEWISE()
        'ElseIf CHK_HALLWISE.Checked = True Then
        '    Call Hallstatus_HALLWISE()
        If CHK_ACCOUNTS.Checked = True Then
            Call Hallstatus_ACCOUNTS()
        ElseIf CHK_ADJUSTED.Checked = True Then
            Call Hallstatus_ADJUSTED()
        ElseIf CHK_NOTADJUST.Checked = True Then
            Call Hallstatus_NOTADJUST()
        ElseIf CHK_BALANCE.Checked = True Then
            Call Hallstatus_BALANCE()
        ElseIf Chk_item.Checked = True Then
            Call Hallstatus_ITEMWISE()

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
    Private Sub BILLREGISTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub CMBBOOKINGTYPE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CMBBOOKINGTYPE.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Chk_roomselection.Focus()
        End If
    End Sub
    Private Sub Chk_roomselection_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Chk_roomselection.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            chklist_Rooms.Focus()
        End If
    End Sub
    Private Sub chklist_Rooms_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chklist_Rooms.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            CHBCANCEL.Focus()
        End If
    End Sub
    Private Sub CHBCANCEL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CHBCANCEL.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Dtpbookfromdate.Focus()
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
    Private Sub CHK_DATEWISE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_DATEWISE.CheckedChanged
        If CHK_DATEWISE.Checked = True Then
            CHK_HALLWISE.Checked = False
            CHK_ACCOUNTS.Checked = False
            CHK_ADJUSTED.Checked = False
            CHK_NOTADJUST.Checked = False
        ElseIf CHK_HALLWISE.Checked = True Then
            CHK_ACCOUNTS.Checked = False
            CHK_DATEWISE.Checked = False
            CHK_ADJUSTED.Checked = False
            CHK_NOTADJUST.Checked = False
        ElseIf CHK_ACCOUNTS.Checked = True Then
            CHK_HALLWISE.Checked = False
            CHK_DATEWISE.Checked = False
            CHK_ADJUSTED.Checked = False
            CHK_NOTADJUST.Checked = False
        ElseIf CHK_ADJUSTED.Checked = True Then
            CHK_HALLWISE.Checked = False
            CHK_DATEWISE.Checked = False
            CHK_ACCOUNTS.Checked = False
            CHK_NOTADJUST.Checked = False
        ElseIf CHK_NOTADJUST.Checked = True Then
            CHK_HALLWISE.Checked = False
            CHK_DATEWISE.Checked = False
            CHK_ACCOUNTS.Checked = False
            CHK_ADJUSTED.Checked = False
        End If
    End Sub
    Private Sub CHK_HALLWISE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_HALLWISE.CheckedChanged
        If CHK_DATEWISE.Checked = True Then
            CHK_HALLWISE.Checked = False
            CHK_ACCOUNTS.Checked = False
            CHK_ADJUSTED.Checked = False
            CHK_NOTADJUST.Checked = False
        ElseIf CHK_HALLWISE.Checked = True Then
            CHK_ACCOUNTS.Checked = False
            CHK_DATEWISE.Checked = False
            CHK_ADJUSTED.Checked = False
            CHK_NOTADJUST.Checked = False
        ElseIf CHK_ACCOUNTS.Checked = True Then
            CHK_HALLWISE.Checked = False
            CHK_DATEWISE.Checked = False
            CHK_ADJUSTED.Checked = False
            CHK_NOTADJUST.Checked = False
        ElseIf CHK_ADJUSTED.Checked = True Then
            CHK_HALLWISE.Checked = False
            CHK_DATEWISE.Checked = False
            CHK_ACCOUNTS.Checked = False
            CHK_NOTADJUST.Checked = False
        ElseIf CHK_NOTADJUST.Checked = True Then
            CHK_HALLWISE.Checked = False
            CHK_DATEWISE.Checked = False
            CHK_ACCOUNTS.Checked = False
            CHK_ADJUSTED.Checked = False
        End If
    End Sub
    Private Sub CHK_LOCATIONSELECTION_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_LOCATIONSELECTION.CheckedChanged
        Dim i As Integer
        If CHK_LOCATIONSELECTION.Checked = True Then
            For i = 0 To CHKLIST_LOCATION.Items.Count - 1
                CHKLIST_LOCATION.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To CHKLIST_LOCATION.Items.Count - 1
                CHKLIST_LOCATION.SetItemChecked(i, False)
            Next
        End If
    End Sub
    Private Sub CHKLIST_LOCATION_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKLIST_LOCATION.SelectedValueChanged
        Call FillhallLocation()
    End Sub
    Private Sub CHKLIST_LOCATION_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CHKLIST_LOCATION.DoubleClick
        Call FillhallLocation()
    End Sub
    Private Sub CHK_ACCOUNTS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_ACCOUNTS.CheckedChanged
        If CHK_ACCOUNTS.Checked = True Then
            CHK_HALLWISE.Checked = False
            CHK_ADJUSTED.Checked = False
            CHK_NOTADJUST.Checked = False
        Else
            'ElseIf CHK_HALLWISE.Checked = True Then
            '    CHK_ACCOUNTS.Checked = False
            '    CHK_DATEWISE.Checked = False
            '    CHK_ADJUSTED.Checked = False
            '    CHK_NOTADJUST.Checked = False
            'ElseIf CHK_ACCOUNTS.Checked = True Then
            '    CHK_HALLWISE.Checked = False
            '    CHK_DATEWISE.Checked = False
            '    CHK_ADJUSTED.Checked = False
            '    CHK_NOTADJUST.Checked = False
            'ElseIf CHK_ADJUSTED.Checked = True Then
            '    CHK_HALLWISE.Checked = False
            '    CHK_DATEWISE.Checked = False
            '    CHK_ACCOUNTS.Checked = False
            '    CHK_NOTADJUST.Checked = False
            'ElseIf CHK_NOTADJUST.Checked = True Then
            '    CHK_HALLWISE.Checked = False
            '    CHK_DATEWISE.Checked = False
            '    CHK_ACCOUNTS.Checked = False
            '    CHK_ADJUSTED.Checked = False
        End If
    End Sub
    Private Sub CHK_ADJUSTED_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_ADJUSTED.CheckedChanged
        If CHK_ADJUSTED.Checked = True Then
            'CHK_DATEWISE.Checked = True
            'CHK_HALLWISE.Checked = False
            CHK_ACCOUNTS.Checked = False
            CHK_NOTADJUST.Checked = False
        Else
            'ElseIf CHK_HALLWISE.Checked = True Then
            '    CHK_ACCOUNTS.Checked = False
            '    CHK_DATEWISE.Checked = False
            '    CHK_ADJUSTED.Checked = False
            '    CHK_NOTADJUST.Checked = False
            'ElseIf CHK_ACCOUNTS.Checked = True Then
            '    CHK_HALLWISE.Checked = False
            '    CHK_DATEWISE.Checked = False
            '    CHK_ADJUSTED.Checked = False
            '    CHK_NOTADJUST.Checked = False
            'ElseIf CHK_ADJUSTED.Checked = True Then
            '    CHK_HALLWISE.Checked = False
            '    CHK_DATEWISE.Checked = False
            '    CHK_ACCOUNTS.Checked = False
            '    CHK_NOTADJUST.Checked = False
            'ElseIf CHK_NOTADJUST.Checked = True Then
            '    CHK_HALLWISE.Checked = False
            '    CHK_DATEWISE.Checked = False
            '    CHK_ACCOUNTS.Checked = False
            '    CHK_ADJUSTED.Checked = False
        End If

    End Sub

    Private Sub CHK_NOTADJUST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_NOTADJUST.CheckedChanged
        If CHK_NOTADJUST.Checked = True Then
            CHK_ACCOUNTS.Checked = False
            CHK_ADJUSTED.Checked = False
        Else
            'ElseIf CHK_HALLWISE.Checked = True Then
            '    CHK_ACCOUNTS.Checked = False
            '    CHK_DATEWISE.Checked = False
            '    CHK_ADJUSTED.Checked = False
            '    CHK_NOTADJUST.Checked = False
            'ElseIf CHK_ACCOUNTS.Checked = True Then
            '    CHK_HALLWISE.Checked = False
            '    CHK_DATEWISE.Checked = False
            '    CHK_ADJUSTED.Checked = False
            '    CHK_NOTADJUST.Checked = False
            'ElseIf CHK_ADJUSTED.Checked = True Then
            '    CHK_HALLWISE.Checked = False
            '    CHK_DATEWISE.Checked = False
            '    CHK_ACCOUNTS.Checked = False
            '    CHK_NOTADJUST.Checked = False
            'ElseIf CHK_NOTADJUST.Checked = True Then
            '    CHK_HALLWISE.Checked = False
            '    CHK_DATEWISE.Checked = False
            '    CHK_ACCOUNTS.Checked = False
            '    CHK_ADJUSTED.Checked = False
        End If

    End Sub
    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Dim SSQL, TYPE(), HNAME As String
        Dim I As Integer
        Dim tspilt(), posdesc(), groupcode(), itemcode(), sqlstring, strhead As String
        Dim POSDESC2(), GROUPDESC2() As String
        Dim _export As New EXPORT
        If CHK_BALANCE.Checked = True Then
            _export.TABLENAME = "PARTY_SUMMARY_SECOND"
            sqlstring = ""
            sqlstring = "SELECT * FROM  PARTY_SUMMARY_SECOND WHERE"
            If CHKLIST_LOCATION.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "  LOCCODE IN ("
                For I = 0 To CHKLIST_LOCATION.CheckedItems.Count - 1
                    tspilt = Split(CHKLIST_LOCATION.CheckedItems(I), "=>")
                    If I = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(1)
                        strhead = tspilt(0)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(1)
                        strhead = strhead & " , " & tspilt(0)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            sqlstring = sqlstring & "AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " AND ISNULL(BALAMT,0)<>0 ORDER BY PARTYDATE"
        ElseIf CHK_ADJUSTED.Checked = True Then
            _export.TABLENAME = "PARTY_SUMMARY_ADJSUTED"
            sqlstring = "SELECT * FROM  PARTY_SUMMARY_ADJSUTED"
            If CHKLIST_LOCATION.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE LOCCODE IN ("
                For I = 0 To CHKLIST_LOCATION.CheckedItems.Count - 1
                    tspilt = Split(CHKLIST_LOCATION.CheckedItems(I), "=>")
                    If I = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(1)
                        strhead = tspilt(0)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(1)
                        strhead = strhead & " , " & tspilt(0)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            sqlstring = sqlstring & "AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY PARTYDATE"
        ElseIf CHK_NOTADJUST.Checked = True Then
            _export.TABLENAME = "PARTY_SUMMARY_NOTADJSUT"
            sqlstring = "SELECT * FROM  PARTY_SUMMARY_NOTADJSUT WHERE"
            If CHKLIST_LOCATION.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "  LOCCODE IN ("
                For I = 0 To CHKLIST_LOCATION.CheckedItems.Count - 1
                    tspilt = Split(CHKLIST_LOCATION.CheckedItems(I), "=>")
                    If I = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(1)
                        strhead = tspilt(0)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(1)
                        strhead = strhead & " , " & tspilt(0)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            sqlstring = sqlstring & "AND CAST(Convert(varchar(11),RECEIPTDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY RECEIPTDATE"
        ElseIf CHK_DATEWISE.Checked = True Then
            _export.TABLENAME = "VIEW_PARTY_BILLING"
            'sqlstring = "SELECT BOOKINGTYPE,BOOKINGNO,BOOKINGDATE,MCODE,PARTYDATE,ASSOCIATENAME,MNAME,ADVANCE,occupancy  FROM  VIEW_PARTY_BILLING  WHERE"
            sqlstring = "SELECT  *  FROM  VIEW_PARTY_BILLING  WHERE"

            If CHKLIST_LOCATION.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "  LOCCODE IN ("
                For I = 0 To CHKLIST_LOCATION.CheckedItems.Count - 1
                    tspilt = Split(CHKLIST_LOCATION.CheckedItems(I), "=>")
                    If I = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(1)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(1)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If CHBCANCEL.Checked = True Then
                sqlstring = sqlstring & " AND ISNULL(FREEZE,'')='Y' "
            Else
                sqlstring = sqlstring & " AND ISNULL(FREEZE,'')<>'Y' "
            End If
            sqlstring = sqlstring & "AND CAST(Convert(varchar(11),RECEIPTDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY BOOKINGNO"
            'sqlstring = sqlstring & " AND BOOKINGTYPE='" & Trim(CMBBOOKINGTYPE.Text) & "'"
            '' sqlstring = sqlstring & "AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            ''sqlstring = sqlstring & "AND CAST(Convert(varchar(11),BOOKINGDATE,6) AS DATETIME) BETWEEN "
            'sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            'sqlstring = sqlstring & " ORDER BY BOOKINGNO "
        ElseIf CHK_ACCOUNTS.Checked = True Then
            _export.TABLENAME = "PARTY_SUMMARY_SECOND"
            sqlstring = "SELECT * FROM  PARTY_SUMMARY_SECOND WHERE"
            If CHKLIST_LOCATION.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & "  LOCCODE IN ("
                For I = 0 To CHKLIST_LOCATION.CheckedItems.Count - 1
                    tspilt = Split(CHKLIST_LOCATION.CheckedItems(I), "=>")
                    If I = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(1)
                        strhead = tspilt(0)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(1)
                        strhead = strhead & " , " & tspilt(0)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            sqlstring = sqlstring & "AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY PARTYDATE"
        End If

        vconn.getDataSet(sqlstring, "PARTYBILLING")
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub


    End Sub

    Private Sub Chk_item_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_item.CheckedChanged

    End Sub

    Private Sub CHK_BALANCE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_BALANCE.CheckedChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click

        If CHK_DATEWISE.Checked = True Then
            Call Hallstatusr_DATEWISE()
        ElseIf CHK_HALLWISE.Checked = True Then
            Call Hallstatus_HALLWISE()
        ElseIf CHK_ACCOUNTS.Checked = True Then
            Call Hallstatus_ACCOUNTS()
        ElseIf CHK_ADJUSTED.Checked = True Then
            Call Hallstatus_ADJUSTED()
        ElseIf CHK_NOTADJUST.Checked = True Then
            Call Hallstatus_NOTADJUST()
        ElseIf CHK_BALANCE.Checked = True Then
            Call Hallstatus_BALANCE()
        ElseIf Chk_item.Checked = True Then
            Call Hallstatus_ITEMWISE()
        End If

    End Sub
    Private Sub Hallstatusr_DATEWISE()

    End Sub

End Class
