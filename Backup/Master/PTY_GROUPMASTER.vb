Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Public Class PTY_GROUPMASTER
    Inherits System.Windows.Forms.Form
    Dim gconn As New GlobalClass
    Dim sqlstring As String
    Dim dr As DataRow
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim i As Integer
    Dim boolchk As Boolean
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
    Friend WithEvents lbl_freeze As System.Windows.Forms.Label
    Friend WithEvents cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents grp_StatusConversion4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_Add As System.Windows.Forms.Button
    Friend WithEvents cmd_View As System.Windows.Forms.Button
    Friend WithEvents cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lbl_Caption As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CMD_Groupcode As System.Windows.Forms.Button
    Friend WithEvents txt_groupCode As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Groupdesc As System.Windows.Forms.TextBox
    Friend WithEvents Grp_Print As System.Windows.Forms.GroupBox
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMD_WINDOWS As System.Windows.Forms.Button
    Friend WithEvents CMD_DOS As System.Windows.Forms.Button
    Friend WithEvents cmd_print As System.Windows.Forms.Button
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CMB_TYPE As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PTY_GROUPMASTER))
        Me.lbl_freeze = New System.Windows.Forms.Label
        Me.cmd_Exit = New System.Windows.Forms.Button
        Me.cmd_Freeze = New System.Windows.Forms.Button
        Me.grp_StatusConversion4 = New System.Windows.Forms.GroupBox
        Me.cmd_Add = New System.Windows.Forms.Button
        Me.cmd_View = New System.Windows.Forms.Button
        Me.cmd_Clear = New System.Windows.Forms.Button
        Me.cmdexport = New System.Windows.Forms.Button
        Me.cmd_print = New System.Windows.Forms.Button
        Me.CMD_Groupcode = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_groupCode = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Txt_Groupdesc = New System.Windows.Forms.TextBox
        Me.lbl_Caption = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CMB_TYPE = New System.Windows.Forms.ComboBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Grp_Print = New System.Windows.Forms.GroupBox
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMD_WINDOWS = New System.Windows.Forms.Button
        Me.CMD_DOS = New System.Windows.Forms.Button
        Me.grp_StatusConversion4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Grp_Print.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_freeze
        '
        Me.lbl_freeze.AutoSize = True
        Me.lbl_freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_freeze.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.lbl_freeze.Location = New System.Drawing.Point(336, 408)
        Me.lbl_freeze.Name = "lbl_freeze"
        Me.lbl_freeze.Size = New System.Drawing.Size(160, 26)
        Me.lbl_freeze.TabIndex = 419
        Me.lbl_freeze.Text = "Record Freezed"
        Me.lbl_freeze.Visible = False
        '
        'cmd_Exit
        '
        Me.cmd_Exit.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Exit.BackgroundImage = CType(resources.GetObject("cmd_Exit.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.cmd_Exit.Location = New System.Drawing.Point(600, 16)
        Me.cmd_Exit.Name = "cmd_Exit"
        Me.cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Exit.TabIndex = 9
        Me.cmd_Exit.Text = "Exit[F11]"
        '
        'cmd_Freeze
        '
        Me.cmd_Freeze.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Freeze.BackgroundImage = CType(resources.GetObject("cmd_Freeze.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.cmd_Freeze.Location = New System.Drawing.Point(312, 16)
        Me.cmd_Freeze.Name = "cmd_Freeze"
        Me.cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Freeze.TabIndex = 7
        Me.cmd_Freeze.Text = "Freeze[F8]"
        '
        'grp_StatusConversion4
        '
        Me.grp_StatusConversion4.BackColor = System.Drawing.Color.Transparent
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Add)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_View)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Clear)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Freeze)
        Me.grp_StatusConversion4.Controls.Add(Me.cmd_Exit)
        Me.grp_StatusConversion4.Location = New System.Drawing.Point(80, 440)
        Me.grp_StatusConversion4.Name = "grp_StatusConversion4"
        Me.grp_StatusConversion4.Size = New System.Drawing.Size(736, 64)
        Me.grp_StatusConversion4.TabIndex = 418
        Me.grp_StatusConversion4.TabStop = False
        '
        'cmd_Add
        '
        Me.cmd_Add.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Add.BackgroundImage = CType(resources.GetObject("cmd_Add.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Add.ForeColor = System.Drawing.Color.White
        Me.cmd_Add.Location = New System.Drawing.Point(176, 16)
        Me.cmd_Add.Name = "cmd_Add"
        Me.cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Add.TabIndex = 6
        Me.cmd_Add.Text = "Add[F7]"
        '
        'cmd_View
        '
        Me.cmd_View.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_View.BackgroundImage = CType(resources.GetObject("cmd_View.BackgroundImage"), System.Drawing.Image)
        Me.cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_View.ForeColor = System.Drawing.Color.White
        Me.cmd_View.Location = New System.Drawing.Point(448, 16)
        Me.cmd_View.Name = "cmd_View"
        Me.cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.cmd_View.TabIndex = 8
        Me.cmd_View.Text = "Report [F9]"
        '
        'cmd_Clear
        '
        Me.cmd_Clear.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Clear.BackgroundImage = CType(resources.GetObject("cmd_Clear.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Clear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Clear.ForeColor = System.Drawing.Color.White
        Me.cmd_Clear.Location = New System.Drawing.Point(40, 16)
        Me.cmd_Clear.Name = "cmd_Clear"
        Me.cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Clear.TabIndex = 5
        Me.cmd_Clear.Text = "Clear[F6]"
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdexport.BackgroundImage = CType(resources.GetObject("cmdexport.BackgroundImage"), System.Drawing.Image)
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Location = New System.Drawing.Point(704, 336)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(104, 32)
        Me.cmdexport.TabIndex = 435
        Me.cmdexport.Text = "Report[F12]"
        Me.cmdexport.Visible = False
        '
        'cmd_print
        '
        Me.cmd_print.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_print.BackgroundImage = CType(resources.GetObject("cmd_print.BackgroundImage"), System.Drawing.Image)
        Me.cmd_print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_print.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_print.ForeColor = System.Drawing.Color.White
        Me.cmd_print.Location = New System.Drawing.Point(584, 336)
        Me.cmd_print.Name = "cmd_print"
        Me.cmd_print.Size = New System.Drawing.Size(104, 32)
        Me.cmd_print.TabIndex = 7
        Me.cmd_print.Text = "Print [F10]"
        Me.cmd_print.Visible = False
        '
        'CMD_Groupcode
        '
        Me.CMD_Groupcode.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CMD_Groupcode.Image = CType(resources.GetObject("CMD_Groupcode.Image"), System.Drawing.Image)
        Me.CMD_Groupcode.Location = New System.Drawing.Point(264, 16)
        Me.CMD_Groupcode.Name = "CMD_Groupcode"
        Me.CMD_Groupcode.Size = New System.Drawing.Size(24, 24)
        Me.CMD_Groupcode.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(24, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(125, 22)
        Me.Label14.TabIndex = 426
        Me.Label14.Text = "Sub Group Code"
        '
        'txt_groupCode
        '
        Me.txt_groupCode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txt_groupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_groupCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_groupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_groupCode.Location = New System.Drawing.Point(200, 16)
        Me.txt_groupCode.MaxLength = 6
        Me.txt_groupCode.Name = "txt_groupCode"
        Me.txt_groupCode.Size = New System.Drawing.Size(64, 21)
        Me.txt_groupCode.TabIndex = 1
        Me.txt_groupCode.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(24, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(170, 22)
        Me.Label10.TabIndex = 427
        Me.Label10.Text = "Sub Group Description"
        '
        'Txt_Groupdesc
        '
        Me.Txt_Groupdesc.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_Groupdesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Groupdesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Groupdesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Groupdesc.Location = New System.Drawing.Point(200, 56)
        Me.Txt_Groupdesc.MaxLength = 50
        Me.Txt_Groupdesc.Name = "Txt_Groupdesc"
        Me.Txt_Groupdesc.Size = New System.Drawing.Size(192, 21)
        Me.Txt_Groupdesc.TabIndex = 3
        Me.Txt_Groupdesc.Text = ""
        '
        'lbl_Caption
        '
        Me.lbl_Caption.AutoSize = True
        Me.lbl_Caption.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Caption.Font = New System.Drawing.Font("Arial", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Caption.Location = New System.Drawing.Point(312, 96)
        Me.lbl_Caption.Name = "lbl_Caption"
        Me.lbl_Caption.Size = New System.Drawing.Size(269, 31)
        Me.lbl_Caption.TabIndex = 425
        Me.lbl_Caption.Text = "SUB GROUP MASTER"
        Me.lbl_Caption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CMB_TYPE)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Txt_Groupdesc)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txt_groupCode)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.CMD_Groupcode)
        Me.GroupBox1.Location = New System.Drawing.Point(168, 176)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 160)
        Me.GroupBox1.TabIndex = 429
        Me.GroupBox1.TabStop = False
        '
        'CMB_TYPE
        '
        Me.CMB_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMB_TYPE.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_TYPE.Items.AddRange(New Object() {"NVEG", "VEG"})
        Me.CMB_TYPE.Location = New System.Drawing.Point(200, 104)
        Me.CMB_TYPE.Name = "CMB_TYPE"
        Me.CMB_TYPE.Size = New System.Drawing.Size(136, 28)
        Me.CMB_TYPE.TabIndex = 4
        Me.CMB_TYPE.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(24, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 22)
        Me.Label15.TabIndex = 462
        Me.Label15.Text = "TYPE "
        Me.Label15.Visible = False
        '
        'Grp_Print
        '
        Me.Grp_Print.BackColor = System.Drawing.Color.Transparent
        Me.Grp_Print.Controls.Add(Me.CMDEXIT)
        Me.Grp_Print.Controls.Add(Me.CMD_WINDOWS)
        Me.Grp_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Print.Location = New System.Drawing.Point(264, 344)
        Me.Grp_Print.Name = "Grp_Print"
        Me.Grp_Print.Size = New System.Drawing.Size(368, 56)
        Me.Grp_Print.TabIndex = 662
        Me.Grp_Print.TabStop = False
        Me.Grp_Print.Visible = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.Location = New System.Drawing.Point(216, 16)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(96, 32)
        Me.CMDEXIT.TabIndex = 2
        Me.CMDEXIT.Text = "EXIT"
        '
        'CMD_WINDOWS
        '
        Me.CMD_WINDOWS.BackColor = System.Drawing.Color.Transparent
        Me.CMD_WINDOWS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_WINDOWS.Location = New System.Drawing.Point(64, 16)
        Me.CMD_WINDOWS.Name = "CMD_WINDOWS"
        Me.CMD_WINDOWS.Size = New System.Drawing.Size(96, 32)
        Me.CMD_WINDOWS.TabIndex = 1
        Me.CMD_WINDOWS.Text = "WINDOWS"
        '
        'CMD_DOS
        '
        Me.CMD_DOS.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))
        Me.CMD_DOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_DOS.Location = New System.Drawing.Point(152, 280)
        Me.CMD_DOS.Name = "CMD_DOS"
        Me.CMD_DOS.Size = New System.Drawing.Size(32, 32)
        Me.CMD_DOS.TabIndex = 0
        Me.CMD_DOS.Text = "DOS"
        Me.CMD_DOS.Visible = False
        '
        'PTY_GROUPMASTER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(880, 534)
        Me.Controls.Add(Me.Grp_Print)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbl_Caption)
        Me.Controls.Add(Me.lbl_freeze)
        Me.Controls.Add(Me.grp_StatusConversion4)
        Me.Controls.Add(Me.cmd_print)
        Me.Controls.Add(Me.cmdexport)
        Me.Controls.Add(Me.CMD_DOS)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PTY_GROUPMASTER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GROUPMASTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_StatusConversion4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Grp_Print.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub PTY_GROUPMASTER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Show()
        txt_groupCode.Focus()
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        gconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.cmd_Add.Enabled = False
        ' Me.cmd_Delete.Enabled = False
        Me.cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.cmd_Add.Enabled = True
                    'Me.cmd_Delete.Enabled = True
                    Me.cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.cmd_Add.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.cmd_Add.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.cmd_Add.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    'Me.cmd_Delete.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.cmd_View.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub checkvalidate()
        boolchk = False
        If Trim(txt_groupCode.Text) = "" Then
            MessageBox.Show("Group Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_groupCode.Focus()
            Exit Sub
        End If
        If Trim(Txt_Groupdesc.Text) = "" Then
            MessageBox.Show("Group Description Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_Groupdesc.Focus()
            Exit Sub
        End If
        'If Trim(CMB_TYPE.Text) = "" Then
        '    MessageBox.Show("TYPE Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Txt_Groupdesc.Focus()
        '    Exit Sub
        'End If
        boolchk = True
    End Sub
    Private Sub CMD_Groupcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_Groupcode.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT isnull(GROUPDESC,'') as GROUPDESC,isnull(GROUPCODE,'') as GROUPCODE FROM PARTY_GROUP_MASTER"
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "GROUPDESC,GROUPCODE"
        vform.vFormatstring = "        Group Description    |     Group Code    "
        vform.vCaption = "Group Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_groupCode.Text = Trim(vform.keyfield1 & "")
            Txt_Groupdesc.Text = Trim(vform.keyfield & "")
            cmd_Add.Text = "Update[F7]"
            Txt_Groupdesc.Focus()
            Call txt_groupCode_Validated(txt_groupCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub txt_groupCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_groupCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_groupCode.Text) <> "" Then
                Call txt_groupCode_Validated(txt_groupCode, e)
            ElseIf Trim(txt_groupCode.Text) = "" Then
                Call CMD_Groupcode_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txt_groupCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_groupCode.Validated
        If Trim(txt_groupCode.Text) <> "" Then
            sqlstring = "SELECT ISNULL(GROUPCODE,'')AS GROUPCODE,ISNULL(GROUPDESC,'')AS GROUPDESC,ISNULL(FREEZE,'')AS FREEZE,ISNULL(TYPE,'')AS TYPE FROM PARTY_GROUP_MASTER"
            sqlstring = sqlstring & " WHERE ISNULL(GROUPCODE,'')='" & Trim(txt_groupCode.Text) & "'"
            gconn.getDataSet(sqlstring, "GRP")
            If gdataset.Tables("GRP").Rows.Count > 0 Then
                cmd_Add.Text = "Update[F7]"
                txt_groupCode.Text = gdataset.Tables("GRP").Rows(0).Item("GROUPCODE")
                Txt_Groupdesc.Text = gdataset.Tables("GRP").Rows(0).Item("GROUPDESC")
                CMB_TYPE.Text = gdataset.Tables("GRP").Rows(0).Item("TYPE")
                If gdataset.Tables("GRP").Rows(0).Item("FREEZE") = "Y" Then
                    lbl_freeze.Visible = True
                    cmd_Freeze.Text = "Unfreeze[F8]"
                Else
                    lbl_freeze.Visible = False
                End If
                txt_groupCode.Enabled = False
                CMD_Groupcode.Enabled = False
                Txt_Groupdesc.Focus()
            Else
                'MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                txt_groupCode.Enabled = True
                CMD_Groupcode.Enabled = True
                Txt_Groupdesc.Focus()
            End If
        End If
    End Sub
    Private Sub cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Clear.Click
        txt_groupCode.Enabled = True
        CMD_Groupcode.Enabled = True

        Grp_Print.Visible = False

        lbl_freeze.Visible = False
        txt_groupCode.Text = ""
        Txt_Groupdesc.Text = ""
        CMB_TYPE.Text = ""
        cmd_Add.Text = "Add[F7]"
        txt_groupCode.Focus()
    End Sub
    Private Sub cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Add.Click
        Call checkvalidate()
        If boolchk = False Then Exit Sub
        If Mid(cmd_Add.Text, 1, 1) = "A" Then
            sqlstring = "INSERT INTO PARTY_GROUP_MASTER (groupcode,groupdesc,freeze,adduser,adddate,TYPE) VALUES("
            sqlstring = sqlstring & " '" & Trim(txt_groupCode.Text) & "','" & Trim(Txt_Groupdesc.Text) & "','N',"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "','" & Trim(CMB_TYPE.Text) & "')"
            gconn.dataOperation(1, sqlstring, "GRP")
            Call cmd_Clear_Click(sender, e)
        ElseIf Mid(cmd_Add.Text, 1, 1) = "U" Then
            If lbl_freeze.Visible = True Then
                MsgBox("Freezed Record Cannot Be Updated", MsgBoxStyle.Information)
                Call cmd_Clear_Click(sender, e)
                Exit Sub
            End If
            sqlstring = "UPDATE PARTY_GROUP_MASTER SET GROUPDESC='" & Trim(Txt_Groupdesc.Text) & "',FREEZE='N',"
            sqlstring = sqlstring & " ADDUSER='" & Trim(gUsername) & "',ADDDATE='" & Format(DateTime.Now, "dd/MMM/yyyy") & "',TYPE='" & Trim(CMB_TYPE.Text) & "' "
            sqlstring = sqlstring & " WHERE GROUPCODE='" & Trim(txt_groupCode.Text) & "'"
            gconn.dataOperation(2, sqlstring, "GRP")
            Call cmd_Clear_Click(sender, e)
        End If
    End Sub
    Private Sub cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Freeze.Click
        Call checkvalidate()
        If boolchk = False Then Exit Sub
        If Mid(cmd_Freeze.Text, 1, 1) = "F" Then
            sqlstring = "SELECT ISNULL(GROUPCODE,'')AS GROUPCODE,ISNULL(GROUPDESC,'')AS GROUPDESC FROM PARTY_GROUP_MASTER"
            sqlstring = sqlstring & " WHERE ISNULL(GROUPCODE,'')='" & Trim(txt_groupCode.Text) & "'"
            gconn.getDataSet(sqlstring, "GRP1")
            If gdataset.Tables("GRP1").Rows.Count > 0 Then
                sqlstring = "UPDATE PARTY_GROUP_MASTER SET FREEZE='Y',"
                sqlstring = sqlstring & " ADDUSER='" & Trim(gUsername) & "',ADDDATE='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' "
                sqlstring = sqlstring & " WHERE GROUPCODE='" & Trim(txt_groupCode.Text) & "'"
                gconn.dataOperation(3, sqlstring, "GRP")
                Call cmd_Clear_Click(sender, e)
            End If
        End If
        If Mid(cmd_Freeze.Text, 1, 1) = "U" Then
            sqlstring = "UPDATE PARTY_GROUP_MASTER SET FREEZE='N',"
            sqlstring = sqlstring & " ADDUSER='" & Trim(gUsername) & "',ADDDATE='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' "
            sqlstring = sqlstring & " WHERE GROUPCODE='" & Trim(txt_groupCode.Text) & "'"
            gconn.dataOperation(4, sqlstring, "GRP")
            Call cmd_Clear_Click(sender, e)
        End If
    End Sub

    Private Sub cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_View.Click
        'Dim FrReport As New ReportDesigner
        'tables = " FROM party_group_master"
        'Gheader = "GROUP MASTER"
        'FrReport.SsGridReport.SetText(2, 1, "GROUPCODE")
        'FrReport.SsGridReport.SetText(3, 1, 10)
        'FrReport.SsGridReport.SetText(2, 2, "GROUPDESC")
        'FrReport.SsGridReport.SetText(3, 2, 25)
        'FrReport.SsGridReport.SetText(2, 3, "FREEZE")
        'FrReport.SsGridReport.SetText(3, 3, 6)
        'FrReport.Show()
        gPrint = False
        Grp_Print.Visible = True

    End Sub
    Private Sub Txt_Groupdesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Groupdesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            cmd_Add.Focus()
        End If
    End Sub
    Private Sub PTY_GROUPMASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call cmd_Clear_Click(sender, e)
        ElseIf e.KeyCode = Keys.F7 Then
            Call cmd_Add_Click(sender, e)
        ElseIf e.KeyCode = Keys.F8 Then
            Call cmd_Freeze_Click(sender, e)
        ElseIf e.KeyCode = Keys.F9 Then
            Call cmd_View_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Then
            Call cmd_Exit_Click(sender, e)
        End If
    End Sub
    Private Sub CMD_PRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_print.Click
        gPrint = True
        Grp_Print.Visible = True
    End Sub
    Private Sub CMD_WINDOWS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_WINDOWS.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_MAS_GROUPHISTORY
        STR = "SELECT * FROM VIEW_PARTY_GROUPHISTORY"
        Viewer.ssql = STR
        gconn.getDataSet(STR, "group")
        If gdataset.Tables("group").Rows.Count > 0 Then
            Viewer.Report = r
            Viewer.TableName = "VIEW_PARTY_GROUPHISTORY"
            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text6")
            textobj1.Text = MyCompanyName
            Dim TXTOBJ2 As TextObject
            TXTOBJ2 = r.ReportDefinition.ReportObjects("Text10")
            TXTOBJ2.Text = gUsername
            Viewer.Show()
            Grp_Print.Visible = False
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub
    Private Sub CMD_DOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_DOS.Click
        Dim i, j As Integer
        Dim Type() As String
        Dim tablename As String
        Dim typename As String
        Dim heading As String
        Dim str As String
        heading = "GROUP MASTER"
        str = "SELECT * from VIEW_PARTY_GROUPHISTORY"
        Call printdata(str, heading, Format(Now, "dd-MMM-yyyy"), Format(Now, "dd-MMM-yyyy"))
        Grp_Print.Visible = False
    End Sub
    Private Function PrintHeader(ByVal HEADING As String, ByVal MSKFROMDATE As Date, ByVal MSKTODATE As Date)
        Dim I As Integer
        pagesize = 0
        Try
            Filewrite.WriteLine(Chr(18))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(15) & "PRINTED ON : " & Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Mid(MyCompanyName, 1, 30) & Space(30 - Len(Mid(MyCompanyName, 1, 30))))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(15) & Mid(Trim(HEADING), 1, 20) & Space(20 - Len(Mid(Trim(HEADING), 1, 20))))
            pagesize = pagesize + 1
            Filewrite.WriteLine(Space(40) & "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("SNO GROUPCODE GROUPDESCRIPTION      FREEZE ADDUSER         ADDDATETIME")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    Public Function printdata(ByVal SQLSTRING As String, ByVal heading As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim docdate As Date
        Dim DOCNO As Integer
        Dim boolPosdesc, boolgroupdesc, boolItemcode As Boolean
        Dim GroupDesc, POSdesc, Itemdesc, Itemcode, SSQL, compcode As String
        Dim LocItemcount, LocationTotal, GroupItemcount, GrandItemcount, GroupTotal, GrandTotal As Double
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1
            Call PrintHeader(heading, mskfromdate, msktodate)
            gconn.getDataSet(SQLSTRING, "roomcompanymasterhistory")
            Dim C As Integer
            C = 0
            If gdataset.Tables("roomcompanymasterhistory").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                For Each dr In gdataset.Tables("roomcompanymasterhistory").Rows
                    If pagesize > 58 Then
                        Filewrite.WriteLine(StrDup(79, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(heading, mskfromdate, msktodate)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    C = C + 1
                    SSQL = Space(3 - Len(Mid(Format(C, "0"), 1, 3))) & Mid(Format(C, "0"), 1, 3)
                    SSQL = SSQL & Space(1) & Mid(Format(dr("GROUPCODE"), ""), 1, 10) & Space(10 - Len(Mid(Format(dr("GROUPCODE"), ""), 1, 10)))
                    SSQL = SSQL & Space(1) & Mid(Format(dr("GROUPDESC"), ""), 1, 25) & Space(25 - Len(Mid(Format(dr("GROUPDESC"), ""), 1, 25)))
                    SSQL = SSQL & Space(1) & Mid(Format(dr("FREEZE"), ""), 1, 1) & Space(1 - Len(Mid(Format(dr("FREEZE"), ""), 1, 1)))
                    SSQL = SSQL & Space(1) & Mid(Format(dr("ADDUSER"), ""), 1, 15) & Space(15 - Len(Mid(Format(dr("ADDUSER"), ""), 1, 15)))
                    SSQL = SSQL & Space(1) & Space(11 - Len(Mid(Format(dr("ADDDATE"), ""), 1, 11))) & Mid(Format(dr("ADDDATE"), ""), 1, 11)
                    Filewrite.WriteLine(SSQL)
                    pagesize = pagesize + 1
                Next
                Filewrite.WriteLine(StrDup(79, "-"))
                pagesize = pagesize + 1
            Else
                MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Function
            End If
            Filewrite.Write(Chr(12))
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile(VFilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString & ex.HelpLink)
            Exit Function
        End Try
    End Function

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Grp_Print.Visible = False
    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "VIEW_PARTY_GROUPHISTORY"
        sqlstring = "SELECT * FROM VIEW_PARTY_GROUPHISTORY"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub txt_groupCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_groupCode.TextChanged

    End Sub
End Class
