'****************************************** Updated by Avinash 21/07/2006 *********************************************''
Imports System.Data.OleDb
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Public Class PARTYHEADMASTER
    Inherits System.Windows.Forms.Form
    Dim boolchk As Boolean
    Dim vseqno As Double
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtSname As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TXT_GLACCODE As System.Windows.Forms.TextBox
    Friend WithEvents CMD_GLACCODE As System.Windows.Forms.Button
    Friend WithEvents txtpartyheadCode As System.Windows.Forms.TextBox
    Friend WithEvents txtpartyheadDesc As System.Windows.Forms.TextBox
    Friend WithEvents cmdparheadCode As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PARTYHEADMASTER))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CMD_GLACCODE = New System.Windows.Forms.Button
        Me.TXT_GLACCODE = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdparheadCode = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtpartyheadCode = New System.Windows.Forms.TextBox
        Me.txtpartyheadDesc = New System.Windows.Forms.TextBox
        Me.txtSname = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.Cmd_View = New System.Windows.Forms.Button
        Me.Cmd_Freeze = New System.Windows.Forms.Button
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lbl_Freeze = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CMD_GLACCODE)
        Me.GroupBox1.Controls.Add(Me.TXT_GLACCODE)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdparheadCode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtpartyheadCode)
        Me.GroupBox1.Controls.Add(Me.txtpartyheadDesc)
        Me.GroupBox1.Location = New System.Drawing.Point(240, 256)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(592, 160)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'CMD_GLACCODE
        '
        Me.CMD_GLACCODE.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CMD_GLACCODE.Image = CType(resources.GetObject("CMD_GLACCODE.Image"), System.Drawing.Image)
        Me.CMD_GLACCODE.Location = New System.Drawing.Point(352, 96)
        Me.CMD_GLACCODE.Name = "CMD_GLACCODE"
        Me.CMD_GLACCODE.Size = New System.Drawing.Size(24, 24)
        Me.CMD_GLACCODE.TabIndex = 459
        Me.CMD_GLACCODE.Visible = False
        '
        'TXT_GLACCODE
        '
        Me.TXT_GLACCODE.BackColor = System.Drawing.Color.Wheat
        Me.TXT_GLACCODE.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TXT_GLACCODE.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_GLACCODE.Location = New System.Drawing.Point(272, 96)
        Me.TXT_GLACCODE.MaxLength = 7
        Me.TXT_GLACCODE.Name = "TXT_GLACCODE"
        Me.TXT_GLACCODE.Size = New System.Drawing.Size(80, 26)
        Me.TXT_GLACCODE.TabIndex = 458
        Me.TXT_GLACCODE.Text = ""
        Me.TXT_GLACCODE.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(72, 96)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(177, 22)
        Me.Label14.TabIndex = 457
        Me.Label14.Text = "GL ACCOUNT  CODE "
        Me.Label14.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(72, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 21)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "PARTY HEAD CODE "
        '
        'cmdparheadCode
        '
        Me.cmdparheadCode.Image = CType(resources.GetObject("cmdparheadCode.Image"), System.Drawing.Image)
        Me.cmdparheadCode.Location = New System.Drawing.Point(352, 16)
        Me.cmdparheadCode.Name = "cmdparheadCode"
        Me.cmdparheadCode.Size = New System.Drawing.Size(23, 26)
        Me.cmdparheadCode.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(72, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(190, 21)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "PARTY H.DESCRIPTION "
        '
        'txtpartyheadCode
        '
        Me.txtpartyheadCode.BackColor = System.Drawing.Color.Wheat
        Me.txtpartyheadCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpartyheadCode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpartyheadCode.Location = New System.Drawing.Point(272, 16)
        Me.txtpartyheadCode.MaxLength = 6
        Me.txtpartyheadCode.Name = "txtpartyheadCode"
        Me.txtpartyheadCode.Size = New System.Drawing.Size(80, 26)
        Me.txtpartyheadCode.TabIndex = 0
        Me.txtpartyheadCode.Text = ""
        '
        'txtpartyheadDesc
        '
        Me.txtpartyheadDesc.BackColor = System.Drawing.Color.Wheat
        Me.txtpartyheadDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtpartyheadDesc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpartyheadDesc.Location = New System.Drawing.Point(272, 56)
        Me.txtpartyheadDesc.MaxLength = 30
        Me.txtpartyheadDesc.Name = "txtpartyheadDesc"
        Me.txtpartyheadDesc.Size = New System.Drawing.Size(208, 26)
        Me.txtpartyheadDesc.TabIndex = 1
        Me.txtpartyheadDesc.Text = ""
        '
        'txtSname
        '
        Me.txtSname.BackColor = System.Drawing.Color.White
        Me.txtSname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSname.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSname.Location = New System.Drawing.Point(64, 280)
        Me.txtSname.MaxLength = 9
        Me.txtSname.Name = "txtSname"
        Me.txtSname.Size = New System.Drawing.Size(136, 26)
        Me.txtSname.TabIndex = 2
        Me.txtSname.Text = ""
        Me.txtSname.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(80, 248)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 21)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "SHORT NAME :"
        Me.Label3.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label16.Location = New System.Drawing.Point(304, 160)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(355, 31)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "PARTY HEAD TYPE MASTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.Cmd_Clear.TabIndex = 0
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(360, 16)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 3
        Me.Cmd_View.Text = "Crystal[F9]"
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.Location = New System.Drawing.Point(240, 16)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze.TabIndex = 2
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.Location = New System.Drawing.Point(128, 16)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add.TabIndex = 1
        Me.Cmd_Add.Text = "Add [F7]"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.Location = New System.Drawing.Point(472, 16)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 4
        Me.Cmd_Exit.Text = "Exit[F11]"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Location = New System.Drawing.Point(240, 464)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(592, 56)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(448, 432)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(173, 25)
        Me.lbl_Freeze.TabIndex = 15
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(784, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 22)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "[F4]"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(24, 408)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(383, 18)
        Me.Label5.TabIndex = 416
        Me.Label5.Text = "Press F4 for HELP / Press ENTER key to navigate"
        Me.Label5.Visible = False
        '
        'PARTYHEADMASTER
        '
        Me.AutoScale = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(238, Byte), CType(249, Byte), CType(232, Byte))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1000, 560)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtSname)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "PARTYHEADMASTER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GROUP MASTER"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub txtpartyheadCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpartyheadCode.KeyPress
        '  If Asc(e.KeyChar) = 13
        'getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtpartyheadCode.Text) <> "" Then
                Call txtpartyheadCode_Validated(txtpartyheadCode, e)
            Else
                Call cmdparheadCode_Click(cmdparheadCode, e)
            End If
        End If
    End Sub
    Private Sub txtGroupDesc_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtpartyheadDesc.KeyPress
        'getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If txtpartyheadDesc.Text <> "" Then
                txtSname.Focus()
            Else
                txtpartyheadDesc.Focus()
            End If
        End If
    End Sub
    Private Sub txtpartyheadCode_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpartyheadCode.Validated
        If Trim(txtpartyheadCode.Text) <> "" Then
            sqlstring = "SELECT * FROM party_Head_master WHERE Receiptheadcode= '" & Trim(txtpartyheadCode.Text) & "'"
            gconnection.getDataSet(sqlstring, "party_Head_master")
            If gdataset.Tables("party_Head_master").Rows.Count > 0 Then
                txtpartyheadDesc.Clear()
                'txtSname.Clear()
                txtpartyheadDesc.Text = Trim(gdataset.Tables("party_Head_master").Rows(0).Item("Receiptheaddesc"))
                'txtSname.Text = Trim(gdataset.Tables("party_Head_master").Rows(0).Item("ShortName"))
                If gdataset.Tables("party_Head_master").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("party_Head_master").Rows(0).Item("AddDateTime")), "dd-MMM-yyyy")
                    Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Freeze[F8]"
                End If
                Me.cmdparheadCode.Enabled = True
                txtpartyheadCode.Enabled = False
                Me.Cmd_Add.Text = "Update[F7]"
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
                txtpartyheadDesc.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"

                txtpartyheadCode.Enabled = False
                txtpartyheadDesc.Focus()
            End If
        Else
            txtpartyheadCode.Text = ""
            txtpartyheadDesc.Focus()
        End If
    End Sub
    Private Sub GroupMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub GroupMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        GroupMasterbool = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtpartyheadCode.Focus()
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
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
        Me.Cmd_View.Enabled = False
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
    Private Sub cmdparheadCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdparheadCode.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(Receiptheadcode,'') AS Receiptheadcode,ISNULL(Receiptheaddesc,'') AS Receiptheaddesc FROM party_Head_master"
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "Receiptheadcode,Receiptheaddesc"
        vform.vFormatstring = " RECEIPT HEAD CODE   | RECEIPT HEAD DESCRIPTION        "
        vform.vCaption = "PARTY HEAD MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txtpartyheadCode.Text = Trim(vform.keyfield & "")
            txtpartyheadCode.Enabled = False
            txtpartyheadDesc.Focus()
            Call txtpartyheadCode_Validated(txtpartyheadCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txtGroupCode_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtpartyheadCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdparheadCode.Enabled = True Then
                Search = Trim(txtpartyheadCode.Text)
                Call cmdparheadCode_Click(txtpartyheadCode, e)
                Exit Sub
            End If
        End If
    End Sub
    Private Sub txtSname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSname.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Cmd_Add.Focus()
        End If
    End Sub
    Private Sub GroupMaster_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        GroupMasterbool = False
    End Sub
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Cmd_Add.Text = "Add [F7]"

        txtpartyheadCode.Enabled = True
        cmdparheadCode.Enabled = True

        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtpartyheadCode.Focus()
    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            vseqno = GetSeqno(txtpartyheadCode.Text)
            strSQL = " INSERT INTO party_Head_master (Receiptheadcode,RECseqno,Receiptheaddesc,Freeze,AddUserId,AddDateTime)"
            strSQL = strSQL & " VALUES ( '" & Trim(txtpartyheadCode.Text) & "'," & Val(vseqno) & ",'" & Replace(Trim(txtpartyheadDesc.Text), "'", "") & "',"
            'strSQL = strSQL & "'" & Replace(Trim(txtSname.Text), "'", "") & "',"
            strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            gconnection.dataOperation(1, strSQL, "party_Head_master")
            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                End If
            End If
            strSQL = "UPDATE  party_Head_master "
            strSQL = strSQL & " SET Receiptheaddesc='" & Replace(Trim(txtpartyheadDesc.Text), "'", "") & "',"
            'strSQL = strSQL & " ShortName='" & Replace(Trim(txtSname.Text), "'", "") & "',"
            strSQL = strSQL & " AddUserId='" & Trim(gUsername) & "',AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
            strSQL = strSQL & " WHERE Receiptheadcode = '" & Trim(txtpartyheadCode.Text) & "'"
            gconnection.dataOperation(2, strSQL, "party_Head_master")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub
    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            sqlstring = "UPDATE  party_Head_master "
            sqlstring = sqlstring & " SET Freeze= 'Y',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE Receiptheadcode = '" & Trim(txtpartyheadCode.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "party_Head_master")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        Else
            sqlstring = "UPDATE  party_Head_master "
            sqlstring = sqlstring & " SET Freeze= 'N',AddUserId='" & gUsername & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE Receiptheadcode = '" & Trim(txtpartyheadCode.Text) & "'"
            gconnection.dataOperation(4, sqlstring, "party_Head_master")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_HEADMASTER
        STR = "SELECT * FROM PARTY_VIEWHEAD"
        Viewer.ssql = STR
        Viewer.Report = r
        Viewer.TableName = "PARTY_VIEWHEAD"
        Dim textobj1 As TextObject
        textobj1 = r.ReportDefinition.ReportObjects("Text6")
        textobj1.Text = MyCompanyName
        Dim TXTOBJ2 As TextObject
        TXTOBJ2 = r.ReportDefinition.ReportObjects("Text10")
        TXTOBJ2.Text = gUsername
        Viewer.Show()
    End Sub
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  Store Code Can't be blank *********************'''
        If Trim(txtpartyheadCode.Text) = "" Then
            MessageBox.Show(" Party head Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtpartyheadCode.Focus()
            Exit Sub
        End If
        '''********** Check  Store desc Can't be blank *********************'''
        If Trim(txtpartyheadDesc.Text) = "" Then
            MessageBox.Show(" party head Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtpartyheadDesc.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub

    Private Sub txtGroupCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpartyheadCode.TextChanged

    End Sub

    Private Sub txtGroupDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpartyheadDesc.TextChanged

    End Sub

    Private Sub TXT_GLACCODE_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXT_GLACCODE.TextChanged

    End Sub

    Private Sub TXT_GLACCODE_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TXT_GLACCODE.KeyPress
        'If Asc(e.KeyChar) = 13 Then
        '    If Trim(TXT_GLACCODE.Text) = "" Then
        '        Call TXT_GLACCODE_Click(sender, e)
        '    End If
        '    txtItemType.Focus()
        'End If
    End Sub
    Private Sub CMD_GLACCODE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_GLACCODE.Click
        'Dim vform As New ListOperattion1
        'gSQLString = "SELECT ISNULL(ACCODE,'') AS ACCODE,ISNULL(ACDESC,'') AS ACDESC FROM Accountsglaccountmaster  "
        'If Trim(Search) = " " Then
        '    M_WhereCondition = ""
        'Else
        '    M_WhereCondition = " WHERE ISNULL(freezeflag,'') <> 'Y'"
        'End If
        'vform.Field = "ACCODE,ACDESC"
        'vform.vFormatstring = "             ACCOUNT CODE                |              ACCOUNT DESCRIPTION                             "
        'vform.vCaption = "ACCOUNT MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        'vform.ShowDialog(Me)
        'If Trim(vform.keyfield & "") <> "" Then
        '    TXT_GLACCODE.Text = Trim(vform.keyfield & "")
        '    txtItemType.Focus()
        'End If
        'vform.Close()
        'vform = Nothing
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class