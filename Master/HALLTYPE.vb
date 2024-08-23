Public Class HALLTYPE
    Inherits System.Windows.Forms.Form
    Dim vseqno As Double
    Dim boolchk As Boolean
    Dim sqlstring As String
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TXTHALLAMOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXTHALLTYPE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdhallHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_Halldesc As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(HALLTYPE))
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl_Freeze = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.Cmd_Freeze = New System.Windows.Forms.Button
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.Cmd_View = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TXTHALLAMOUNT = New System.Windows.Forms.TextBox
        Me.TXTHALLTYPE = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdhallHelp = New System.Windows.Forms.Button
        Me.Txt_Halldesc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(328, 405)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(383, 18)
        Me.Label5.TabIndex = 422
        Me.Label5.Text = "Press F4 for HELP / Press ENTER key to navigate"
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(448, 309)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(173, 25)
        Me.lbl_Freeze.TabIndex = 421
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(368, 109)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(289, 31)
        Me.Label16.TabIndex = 419
        Me.Label16.Text = "HALL FUNCTION TYPE"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Location = New System.Drawing.Point(232, 341)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(576, 56)
        Me.GroupBox2.TabIndex = 418
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
        Me.Cmd_Clear.TabIndex = 4
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.Location = New System.Drawing.Point(234, 16)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze.TabIndex = 5
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.Location = New System.Drawing.Point(125, 16)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add.TabIndex = 3
        Me.Cmd_Add.Text = "Add [F7]"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.Location = New System.Drawing.Point(452, 16)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 7
        Me.Cmd_Exit.Text = "Exit[F11]"
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(343, 16)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 6
        Me.Cmd_View.Text = " View[F9]"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TXTHALLAMOUNT)
        Me.GroupBox1.Controls.Add(Me.TXTHALLTYPE)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdhallHelp)
        Me.GroupBox1.Location = New System.Drawing.Point(232, 149)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(584, 144)
        Me.GroupBox1.TabIndex = 420
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(479, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 22)
        Me.Label4.TabIndex = 91
        Me.Label4.Text = "[F4]"
        '
        'TXTHALLAMOUNT
        '
        Me.TXTHALLAMOUNT.BackColor = System.Drawing.Color.Wheat
        Me.TXTHALLAMOUNT.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTHALLAMOUNT.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHALLAMOUNT.Location = New System.Drawing.Point(208, 104)
        Me.TXTHALLAMOUNT.MaxLength = 8
        Me.TXTHALLAMOUNT.Name = "TXTHALLAMOUNT"
        Me.TXTHALLAMOUNT.Size = New System.Drawing.Size(104, 26)
        Me.TXTHALLAMOUNT.TabIndex = 2
        Me.TXTHALLAMOUNT.Text = ""
        '
        'TXTHALLTYPE
        '
        Me.TXTHALLTYPE.BackColor = System.Drawing.Color.Wheat
        Me.TXTHALLTYPE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXTHALLTYPE.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXTHALLTYPE.Location = New System.Drawing.Point(208, 32)
        Me.TXTHALLTYPE.MaxLength = 30
        Me.TXTHALLTYPE.Name = "TXTHALLTYPE"
        Me.TXTHALLTYPE.Size = New System.Drawing.Size(248, 26)
        Me.TXTHALLTYPE.TabIndex = 0
        Me.TXTHALLTYPE.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(88, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 21)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "HALL RENT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(88, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 21)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "HALL TYPE"
        '
        'cmdhallHelp
        '
        Me.cmdhallHelp.Image = CType(resources.GetObject("cmdhallHelp.Image"), System.Drawing.Image)
        Me.cmdhallHelp.Location = New System.Drawing.Point(455, 32)
        Me.cmdhallHelp.Name = "cmdhallHelp"
        Me.cmdhallHelp.Size = New System.Drawing.Size(23, 26)
        Me.cmdhallHelp.TabIndex = 1
        '
        'Txt_Halldesc
        '
        Me.Txt_Halldesc.BackColor = System.Drawing.Color.Wheat
        Me.Txt_Halldesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Halldesc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Halldesc.Location = New System.Drawing.Point(440, 216)
        Me.Txt_Halldesc.MaxLength = 30
        Me.Txt_Halldesc.Name = "Txt_Halldesc"
        Me.Txt_Halldesc.Size = New System.Drawing.Size(248, 26)
        Me.Txt_Halldesc.TabIndex = 423
        Me.Txt_Halldesc.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(320, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 21)
        Me.Label3.TabIndex = 424
        Me.Label3.Text = "HALL DESC"
        '
        'HALLTYPE
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(952, 533)
        Me.Controls.Add(Me.Txt_Halldesc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "HALLTYPE"
        Me.Text = "HALLTYPE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  Store Code Can't be blank *********************'''
        If Trim(TXTHALLTYPE.Text) = "" Then
            MessageBox.Show(" HALL TYPE Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTHALLTYPE.Focus()
            Exit Sub
        End If
        '''********** Check  Store desc Can't be blank *********************'''
        If Val(TXTHALLAMOUNT.Text) = 0 Then
            MessageBox.Show(" Hall Rent can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TXTHALLAMOUNT.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub HALLTYPE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        TXTHALLTYPE.ReadOnly = False
        cmdhallHelp.Enabled = True
        UOMMastbool = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Cmd_Clear_Click(sender, e)
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
        Me.Cmd_Add.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        Cmd_View.Enabled = False
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
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        '' Dim FrReport As New ReportDesigner
        'tables = " FROM PARTY_HALLTYPE"
        'Gheader = " HALL TYPE MASTER "
        'FrReport.SsGridReport.SetText(2, 1, "HALLTYPECODE")
        'FrReport.SsGridReport.SetText(3, 1, 10)
        'FrReport.SsGridReport.SetText(2, 2, "HALLTYPE")
        'FrReport.SsGridReport.SetText(3, 2, 30)
        'FrReport.SsGridReport.SetText(2, 3, "HALLAMOUNT")
        'FrReport.SsGridReport.SetText(3, 3, 15)
        'FrReport.SsGridReport.SetText(2, 4, "FREEZE")
        'FrReport.SsGridReport.SetText(3, 4, 6)
        'FrReport.Show()
    End Sub
    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            sqlstring = "UPDATE  PARTY_HALLTYPE "
            sqlstring = sqlstring & " SET Freeze= 'Y',AddUserID='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE HALLTYPECODE = '" & Trim(TXTHALLTYPE.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "HALLTYPE")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        Else
            sqlstring = "UPDATE  PARTY_HALLTYPE "
            sqlstring = sqlstring & " SET Freeze= 'N',AddUserID='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE HALLTYPECODE = '" & Trim(TXTHALLTYPE.Text) & "'"
            gconnection.dataOperation(4, sqlstring, "HALLTYPE")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If

    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            vseqno = GetSeqno(TXTHALLTYPE.Text)
            strSQL = " INSERT INTO PARTY_HALLTYPE (HALLTYPECODE,HALLTYPE,HALLAMOUNT,Freeze,AddUserID,AddDatetime)"
            strSQL = strSQL & " VALUES ('" & Trim(TXTHALLTYPE.Text) & "','" & Trim(Txt_Halldesc.Text) & "'," & (TXTHALLAMOUNT.Text) & ","
            strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            gconnection.dataOperation(1, strSQL, "HALLTYPE")
            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                    boolchk = False
                End If
            End If
            strSQL = "UPDATE  PARTY_HALLTYPE "
            strSQL = strSQL & " SET HALLTYPE='" & Trim(Txt_Halldesc.Text) & "',HALLAMOUNT=" & Val(TXTHALLAMOUNT.Text) & ","
            strSQL = strSQL & " AddUserID='" & Trim(gUsername) & "',AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
            strSQL = strSQL & " WHERE HALLTYPE = '" & Trim(TXTHALLTYPE.Text) & "'"
            gconnection.dataOperation(2, strSQL, "HALLTYPE")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.TXTHALLTYPE.ReadOnly = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Cmd_Add.Text = "Add [F7]"
        TXTHALLTYPE.Enabled = True
        TXTHALLTYPE.ReadOnly = False
        TXTHALLAMOUNT.ReadOnly = False
        cmdhallHelp.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        TXTHALLAMOUNT.Text = ""
        TXTHALLTYPE.Text = ""
        TXTHALLAMOUNT.Text = Format(Val(TXTHALLAMOUNT.Text), "0.00")
        Show()
        Me.TXTHALLTYPE.Focus()
    End Sub
    Private Sub TXTHALLTYPE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TXTHALLTYPE.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdhallHelp.Enabled = True Then
                Search = Trim(TXTHALLTYPE.Text)
                Call cmdhallHelp_Click(TXTHALLTYPE, e)
            End If
        End If
    End Sub

    Private Sub HALLTYPE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub cmdhallHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdhallHelp.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(HALLTYPE,'') AS HALLTYPE,ISNULL(HALLTYPECODE,'') AS HALLTYPECODE,ISNULL(HALLAMOUNT,0) AS HALLAMOUNT FROM PARTY_HALLTYPE"
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "HALLTYPE,HALLTYPECODE,HALLAMOUNT"
        vform.vFormatstring = " HALL TYPE             |  HALL TYPE CODE     |        AMOUNT     "
        vform.vCaption = "HALL TYPE HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            TXTHALLTYPE.Text = Trim(vform.keyfield1 & "")
            Txt_Halldesc.Text = Trim(vform.keyfield & "")
            Call TXTHALLTYPE_Validated(TXTHALLTYPE, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub TXTHALLTYPE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTHALLTYPE.Validated
        Dim Fre As String
        If Trim(TXTHALLTYPE.Text) <> "" Then
            Dim ds As New DataSet
            vseqno = GetSeqno(TXTHALLTYPE.Text)
            sqlstring = "SELECT * FROM PARTY_HALLTYPE WHERE HALLTYPECODE='" & TXTHALLTYPE.Text & "'"
            gconnection.getDataSet(sqlstring, "HALLTYPE")
            If gdataset.Tables("HALLTYPE").Rows.Count > 0 Then
                TXTHALLAMOUNT.Clear()
                Txt_Halldesc.Text = gdataset.Tables("HALLTYPE").Rows(0).Item("HALLTYPE")
                TXTHALLAMOUNT.Text = gdataset.Tables("HALLTYPE").Rows(0).Item("HALLAMOUNT")
                If gdataset.Tables("HALLTYPE").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("HALLTYPE").Rows(0).Item("AddDateTime")), "dd-MMM-yyyy")
                    Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Freeze[F8]"
                End If
                Me.Cmd_Add.Text = "Update[F7]"
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
                Me.TXTHALLTYPE.ReadOnly = True
                Me.cmdhallHelp.Enabled = False
                Me.TXTHALLAMOUNT.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                TXTHALLTYPE.ReadOnly = False
                TXTHALLAMOUNT.Focus()
            End If
        Else
            TXTHALLTYPE.Text = ""
            TXTHALLAMOUNT.Focus()
        End If
    End Sub
    Private Sub TXTHALLAMOUNT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTHALLAMOUNT.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If TXTHALLAMOUNT.Text <> "" Then
                Cmd_Add.Focus()
            End If
        End If
    End Sub
    Private Sub TXTHALLTYPE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXTHALLTYPE.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(TXTHALLTYPE.Text) <> "" Then
                Call TXTHALLTYPE_Validated(TXTHALLTYPE, e)
                TXTHALLAMOUNT.Focus()
            Else
                Call cmdhallHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub TXTHALLAMOUNT_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TXTHALLAMOUNT.LostFocus
        TXTHALLAMOUNT.Text = Format(Val(TXTHALLAMOUNT.Text), "0.00")
    End Sub
    Private Sub Txt_Halldesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Halldesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Halldesc.Text) <> "" Then
                TXTHALLAMOUNT.Focus()
            Else
                Txt_Halldesc.Focus()
            End If
        End If
    End Sub
End Class
