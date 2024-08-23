Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Public Class PTY_MENUGROUP_MASTER
    Inherits System.Windows.Forms.Form
    Dim gconn As New GlobalClass
    Dim gconnection As New GlobalClass
    Dim i, j As Integer
    Dim dr As DataRow
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim sqlstring As String
    Dim boolchk As Boolean
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Chk_GroupCode As System.Windows.Forms.CheckedListBox
    Friend WithEvents CHK_SELECTALL As System.Windows.Forms.CheckBox
    Friend WithEvents Txt_Menudesc As System.Windows.Forms.TextBox
    Friend WithEvents txt_MenuCode As System.Windows.Forms.TextBox
    Friend WithEvents CMD_Menucode As System.Windows.Forms.Button
    Friend WithEvents CMD_PRINT As System.Windows.Forms.Button
    Friend WithEvents Grp_Print As System.Windows.Forms.GroupBox
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMD_WINDOWS As System.Windows.Forms.Button
    Friend WithEvents CMD_DOS As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PTY_MENUGROUP_MASTER))
        Me.lbl_freeze = New System.Windows.Forms.Label
        Me.cmd_Exit = New System.Windows.Forms.Button
        Me.cmd_Freeze = New System.Windows.Forms.Button
        Me.grp_StatusConversion4 = New System.Windows.Forms.GroupBox
        Me.cmd_Add = New System.Windows.Forms.Button
        Me.cmd_View = New System.Windows.Forms.Button
        Me.cmd_Clear = New System.Windows.Forms.Button
        Me.cmdexport = New System.Windows.Forms.Button
        Me.CMD_PRINT = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Txt_Menudesc = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txt_MenuCode = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CMD_Menucode = New System.Windows.Forms.Button
        Me.Chk_GroupCode = New System.Windows.Forms.CheckedListBox
        Me.CHK_SELECTALL = New System.Windows.Forms.CheckBox
        Me.Grp_Print = New System.Windows.Forms.GroupBox
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMD_WINDOWS = New System.Windows.Forms.Button
        Me.CMD_DOS = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grp_StatusConversion4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Grp_Print.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_freeze
        '
        Me.lbl_freeze.AutoSize = True
        Me.lbl_freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_freeze.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_freeze.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.lbl_freeze.Location = New System.Drawing.Point(648, 176)
        Me.lbl_freeze.Name = "lbl_freeze"
        Me.lbl_freeze.Size = New System.Drawing.Size(160, 26)
        Me.lbl_freeze.TabIndex = 423
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
        Me.cmd_Exit.Location = New System.Drawing.Point(576, 16)
        Me.cmd_Exit.Name = "cmd_Exit"
        Me.cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Exit.TabIndex = 421
        Me.cmd_Exit.Text = "Exit[F11]"
        '
        'cmd_Freeze
        '
        Me.cmd_Freeze.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Freeze.BackgroundImage = CType(resources.GetObject("cmd_Freeze.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.cmd_Freeze.Location = New System.Drawing.Point(320, 16)
        Me.cmd_Freeze.Name = "cmd_Freeze"
        Me.cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Freeze.TabIndex = 420
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
        Me.grp_StatusConversion4.Location = New System.Drawing.Point(104, 504)
        Me.grp_StatusConversion4.Name = "grp_StatusConversion4"
        Me.grp_StatusConversion4.Size = New System.Drawing.Size(712, 64)
        Me.grp_StatusConversion4.TabIndex = 422
        Me.grp_StatusConversion4.TabStop = False
        '
        'cmd_Add
        '
        Me.cmd_Add.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_Add.BackgroundImage = CType(resources.GetObject("cmd_Add.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Add.ForeColor = System.Drawing.Color.White
        Me.cmd_Add.Location = New System.Drawing.Point(184, 16)
        Me.cmd_Add.Name = "cmd_Add"
        Me.cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.cmd_Add.TabIndex = 378
        Me.cmd_Add.Text = "Add[F7]"
        '
        'cmd_View
        '
        Me.cmd_View.BackColor = System.Drawing.SystemColors.Menu
        Me.cmd_View.BackgroundImage = CType(resources.GetObject("cmd_View.BackgroundImage"), System.Drawing.Image)
        Me.cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_View.ForeColor = System.Drawing.Color.White
        Me.cmd_View.Location = New System.Drawing.Point(456, 16)
        Me.cmd_View.Name = "cmd_View"
        Me.cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.cmd_View.TabIndex = 379
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
        Me.cmd_Clear.TabIndex = 381
        Me.cmd_Clear.Text = "Clear[F6]"
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdexport.BackgroundImage = CType(resources.GetObject("cmdexport.BackgroundImage"), System.Drawing.Image)
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Location = New System.Drawing.Point(752, 304)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(104, 32)
        Me.cmdexport.TabIndex = 435
        Me.cmdexport.Text = "Report[F12]"
        Me.cmdexport.Visible = False
        '
        'CMD_PRINT
        '
        Me.CMD_PRINT.BackColor = System.Drawing.SystemColors.Menu
        Me.CMD_PRINT.BackgroundImage = CType(resources.GetObject("CMD_PRINT.BackgroundImage"), System.Drawing.Image)
        Me.CMD_PRINT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMD_PRINT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_PRINT.ForeColor = System.Drawing.Color.White
        Me.CMD_PRINT.Location = New System.Drawing.Point(632, 304)
        Me.CMD_PRINT.Name = "CMD_PRINT"
        Me.CMD_PRINT.Size = New System.Drawing.Size(104, 32)
        Me.CMD_PRINT.TabIndex = 382
        Me.CMD_PRINT.Text = "Print [F10]"
        Me.CMD_PRINT.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Txt_Menudesc)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txt_MenuCode)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.CMD_Menucode)
        Me.GroupBox1.Location = New System.Drawing.Point(232, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 88)
        Me.GroupBox1.TabIndex = 430
        Me.GroupBox1.TabStop = False
        '
        'Txt_Menudesc
        '
        Me.Txt_Menudesc.BackColor = System.Drawing.Color.AntiqueWhite
        Me.Txt_Menudesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txt_Menudesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Menudesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Menudesc.Location = New System.Drawing.Point(200, 56)
        Me.Txt_Menudesc.MaxLength = 50
        Me.Txt_Menudesc.Name = "Txt_Menudesc"
        Me.Txt_Menudesc.Size = New System.Drawing.Size(192, 21)
        Me.Txt_Menudesc.TabIndex = 424
        Me.Txt_Menudesc.Text = ""
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(40, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(95, 21)
        Me.Label14.TabIndex = 426
        Me.Label14.Text = "Group Code"
        '
        'txt_MenuCode
        '
        Me.txt_MenuCode.BackColor = System.Drawing.Color.AntiqueWhite
        Me.txt_MenuCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_MenuCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txt_MenuCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_MenuCode.Location = New System.Drawing.Point(200, 16)
        Me.txt_MenuCode.MaxLength = 10
        Me.txt_MenuCode.Name = "txt_MenuCode"
        Me.txt_MenuCode.Size = New System.Drawing.Size(72, 21)
        Me.txt_MenuCode.TabIndex = 423
        Me.txt_MenuCode.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(40, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(145, 21)
        Me.Label10.TabIndex = 427
        Me.Label10.Text = "Group  Description"
        '
        'CMD_Menucode
        '
        Me.CMD_Menucode.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.CMD_Menucode.Image = CType(resources.GetObject("CMD_Menucode.Image"), System.Drawing.Image)
        Me.CMD_Menucode.Location = New System.Drawing.Point(272, 16)
        Me.CMD_Menucode.Name = "CMD_Menucode"
        Me.CMD_Menucode.Size = New System.Drawing.Size(24, 24)
        Me.CMD_Menucode.TabIndex = 428
        '
        'Chk_GroupCode
        '
        Me.Chk_GroupCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Chk_GroupCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_GroupCode.Location = New System.Drawing.Point(16, 16)
        Me.Chk_GroupCode.Name = "Chk_GroupCode"
        Me.Chk_GroupCode.Size = New System.Drawing.Size(256, 236)
        Me.Chk_GroupCode.TabIndex = 431
        '
        'CHK_SELECTALL
        '
        Me.CHK_SELECTALL.BackColor = System.Drawing.Color.Transparent
        Me.CHK_SELECTALL.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_SELECTALL.Location = New System.Drawing.Point(240, 152)
        Me.CHK_SELECTALL.Name = "CHK_SELECTALL"
        Me.CHK_SELECTALL.Size = New System.Drawing.Size(296, 32)
        Me.CHK_SELECTALL.TabIndex = 432
        Me.CHK_SELECTALL.Text = "SELECT ALL"
        '
        'Grp_Print
        '
        Me.Grp_Print.BackColor = System.Drawing.Color.Transparent
        Me.Grp_Print.Controls.Add(Me.CMDEXIT)
        Me.Grp_Print.Controls.Add(Me.CMD_WINDOWS)
        Me.Grp_Print.Controls.Add(Me.CMD_DOS)
        Me.Grp_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Print.Location = New System.Drawing.Point(216, 440)
        Me.Grp_Print.Name = "Grp_Print"
        Me.Grp_Print.Size = New System.Drawing.Size(424, 56)
        Me.Grp_Print.TabIndex = 664
        Me.Grp_Print.TabStop = False
        Me.Grp_Print.Visible = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.CMDEXIT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.Location = New System.Drawing.Point(248, 16)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(96, 32)
        Me.CMDEXIT.TabIndex = 2
        Me.CMDEXIT.Text = "EXIT"
        '
        'CMD_WINDOWS
        '
        Me.CMD_WINDOWS.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.CMD_WINDOWS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_WINDOWS.Location = New System.Drawing.Point(136, 16)
        Me.CMD_WINDOWS.Name = "CMD_WINDOWS"
        Me.CMD_WINDOWS.Size = New System.Drawing.Size(96, 32)
        Me.CMD_WINDOWS.TabIndex = 1
        Me.CMD_WINDOWS.Text = "WINDOWS"
        '
        'CMD_DOS
        '
        Me.CMD_DOS.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
        Me.CMD_DOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_DOS.Location = New System.Drawing.Point(24, 16)
        Me.CMD_DOS.Name = "CMD_DOS"
        Me.CMD_DOS.Size = New System.Drawing.Size(96, 32)
        Me.CMD_DOS.TabIndex = 0
        Me.CMD_DOS.Text = "DOS"
        Me.CMD_DOS.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(272, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(360, 31)
        Me.Label16.TabIndex = 665
        Me.Label16.Text = "GROUP/SUB GROUP MASTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Chk_GroupCode)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(240, 176)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(280, 256)
        Me.GroupBox2.TabIndex = 666
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sub Groupmaster"
        '
        'PTY_MENUGROUP_MASTER
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(960, 574)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.lbl_freeze)
        Me.Controls.Add(Me.CHK_SELECTALL)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grp_StatusConversion4)
        Me.Controls.Add(Me.cmdexport)
        Me.Controls.Add(Me.CMD_PRINT)
        Me.Controls.Add(Me.Grp_Print)
        Me.KeyPreview = True
        Me.Name = "PTY_MENUGROUP_MASTER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GROUP &SUB-GROUP MASTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.grp_StatusConversion4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Grp_Print.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub checkvalidate()
        boolchk = False
        If Trim(txt_MenuCode.Text) = "" Then
            MessageBox.Show("Menu Code Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            txt_MenuCode.Focus()
            Exit Sub
        End If
        If Trim(Txt_Menudesc.Text) = "" Then
            MessageBox.Show("Menu Description Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Txt_Menudesc.Focus()
            Exit Sub
        End If
        If Chk_GroupCode.CheckedItems.Count = 0 Then
            MessageBox.Show("Group Code Can't be UnChecked", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        boolchk = True
    End Sub
    Private Sub cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Clear.Click
        cmd_Add.Text = "Add[F7]"
        cmd_Freeze.Text = "Freeze[F8]"
        txt_MenuCode.Enabled = True
        CMD_Menucode.Enabled = True
        txt_MenuCode.Text = ""
        Txt_Menudesc.Text = ""
        Chk_GroupCode.Items.Clear()
        Call FILLGROUPCODE()
        txt_MenuCode.Focus()
        Show()
    End Sub
    Private Sub cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub FILLGROUPCODE() 'THIS IS SUB GROUPCODE
        sqlstring = "SELECT isnull(GROUPCODE,'') as GROUPCODE,isnull(GROUPDESC,'') as GROUPDESC FROM PARTY_GROUP_MASTER"
        sqlstring = sqlstring & " WHERE ISNULL(FREEZE,'')<>'Y'"
        gconn.getDataSet(sqlstring, "GRP")
        Chk_GroupCode.Items.Clear()
        If gdataset.Tables("GRP").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("GRP").Rows.Count - 1
                Chk_GroupCode.Items.Add(gdataset.Tables("GRP").Rows(i).Item("GROUPCODE") & "-->" & gdataset.Tables("GRP").Rows(i).Item("GROUPDESC"))
            Next
        End If
    End Sub
    Private Sub CMD_Menucode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_Menucode.Click
        Dim vform As New ListOperattion1 'THIS IS GROUPCODE
        'gSQLString = "SELECT isnull(MENUDESC,'') as  GROUPDESC,isnull(MENUCODE,'') as GROUPCODE FROM party_view_menuhelp "
        gSQLString = "SELECT isnull(GROUPDESC,'') as  GROUPDESC,isnull(GROUPCODE,'') as GROUPCODE FROM party_view_menuhelp "
        M_WhereCondition = " "
        'vform.Field = "MENUDESC,MENUCODE"
        vform.Field = "GROUPDESC,GROUPCODE"
        vform.vFormatstring = "        GROUP Description    |     GROUP Code    "
        vform.vCaption = "Menu Master Help"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txt_MenuCode.Text = Trim(vform.keyfield1 & "")
            Txt_Menudesc.Text = Trim(vform.keyfield)
            Call txt_MenuCode_Validated(txt_MenuCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub txt_MenuCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txt_MenuCode.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txt_MenuCode.Text) <> "" Then
                Call txt_MenuCode_Validated(txt_MenuCode, e)
            Else
                Call CMD_Menucode_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txt_MenuCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txt_MenuCode.Validated
        Dim grp() As String
        If Trim(txt_MenuCode.Text) <> "" Then
            sqlstring = "select isnull(menucode,'')as menucode,isnull(menudesc,'')as menudesc,isnull(m.groupcode,'')as groupcode,"
            sqlstring = sqlstring & " isnull(g.groupdesc,'')as groupdesc,isnull(m.freeze,'')as freeze from party_menugroupmaster m"
            sqlstring = sqlstring & " left outer join party_group_master g "
            sqlstring = sqlstring & " on g.groupcode=m.groupcode WHERE MENUCODE='" & Trim(txt_MenuCode.Text) & "'"
            gconn.getDataSet(sqlstring, "MENU")



            If gdataset.Tables("MENU").Rows.Count > 0 Then
                Call FILLGROUPCODE()
                'For i = 0 To Chk_GroupCode.Items.Count - 1
                '    Chk_GroupCode.SetItemChecked(i, True)
                'Next
                cmd_Add.Text = "Update[F7]"
                txt_MenuCode.Enabled = False
                CMD_Menucode.Enabled = False
                Txt_Menudesc.Text = gdataset.Tables("MENU").Rows(0).Item("MENUDESC")
                For i = 0 To gdataset.Tables("MENU").Rows.Count - 1
                    For j = 0 To Chk_GroupCode.Items.Count - 1
                        grp = Split(Chk_GroupCode.Items(j), "-->")
                        If Trim(gdataset.Tables("MENU").Rows(i).Item("GROUPCODE")) = grp(0) Then
                            Chk_GroupCode.SetItemChecked(j, True)
                            Chk_GroupCode.SelectedItem = gdataset.Tables("MENU").Rows(0).Item("GROUPCODE")
                        End If
                    Next
                Next
                Txt_Menudesc.Focus()
            Else
                Txt_Menudesc.Focus()
            End If
        End If
        sqlstring = "select isnull(menucode,'')as menucode,isnull(menudesc,'')as menudesc,isnull(m.groupcode,'')as groupcode,"
        sqlstring = sqlstring & " isnull(g.groupdesc,'')as groupdesc,isnull(m.freeze,'')as freeze from party_menugroupmaster m"
        sqlstring = sqlstring & " left outer join party_group_master g "
        sqlstring = sqlstring & " on g.groupcode=m.groupcode WHERE MENUCODE='" & Trim(txt_MenuCode.Text) & "'AND M.FREEZE='Y'"
        gconn.getDataSet(sqlstring, "FREEZE")
        If gdataset.Tables("FREEZE").Rows.Count > 0 Then
            cmd_Freeze.Text = "UnFreeze[F8]"
        End If


    End Sub
    Private Sub PTY_MENUGROUP_MASTER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        txt_MenuCode.Text = ""
        Txt_Menudesc.Text = ""
        Chk_GroupCode.Items.Clear()
        Call FILLGROUPCODE()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Show()
        txt_MenuCode.Focus()
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.cmd_Add.Enabled = False
        Me.cmd_Freeze.Enabled = False
        Me.cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.cmd_Add.Enabled = True
                    Me.cmd_Freeze.Enabled = True
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
                    Me.cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.cmd_View.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub CHK_SELECTALL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_SELECTALL.CheckedChanged
        If CHK_SELECTALL.Checked = True Then
            For i = 0 To Chk_GroupCode.Items.Count - 1
                Chk_GroupCode.SetItemChecked(i, True)
            Next
        ElseIf CHK_SELECTALL.Checked = False Then
            For i = 0 To Chk_GroupCode.Items.Count - 1
                Chk_GroupCode.SetItemChecked(i, False)
            Next
        End If
    End Sub
    Private Sub cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Add.Click
        Dim grpcode(), INSERT(0) As String
        If Mid(cmd_Add.Text, 1, 1) = "A" Then
            Call checkvalidate()
            If boolchk = False Then Exit Sub
            For i = 0 To Chk_GroupCode.CheckedItems.Count - 1
                sqlstring = "Insert Into Party_menugroupmaster (menucode,menudesc,groupcode,freeze,adduser,adddate)"
                sqlstring = sqlstring & " Values('" & Trim(txt_MenuCode.Text) & "','" & Trim(Txt_Menudesc.Text) & "',"
                grpcode = Split(Chk_GroupCode.CheckedItems(i), "-->")
                sqlstring = sqlstring & "'" & grpcode(0)
                sqlstring = sqlstring & "','N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "') "
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring
            Next
            gconn.MoreTrans(INSERT)
            Call cmd_Clear_Click(sender, e)
        ElseIf Mid(cmd_Add.Text, 1, 1) = "U" Then

            sqlstring = "SELECT * FROM PARTY_MENUGROUPMASTER WHERE MENUCODE='" & Trim(txt_MenuCode.Text) & "'"
            gconn.getDataSet(sqlstring, "MN")
            If gdataset.Tables("MN").Rows.Count > 0 Then
                Call checkvalidate()
                If boolchk = False Then Exit Sub

                sqlstring = "DELETE FROM PARTY_MENUGROUPMASTER WHERE MENUCODE='" & Trim(txt_MenuCode.Text) & "'"
                ReDim Preserve INSERT(INSERT.Length)
                INSERT(INSERT.Length - 1) = sqlstring

                For i = 0 To Chk_GroupCode.CheckedItems.Count - 1
                    sqlstring = "Insert Into Party_menugroupmaster (menucode,menudesc,groupcode,freeze,adduser,adddate)"
                    sqlstring = sqlstring & " Values('" & Trim(txt_MenuCode.Text) & "','" & Trim(Txt_Menudesc.Text) & "',"
                    grpcode = Split(Chk_GroupCode.CheckedItems(i), "-->")
                    sqlstring = sqlstring & "'" & grpcode(0)
                    sqlstring = sqlstring & "','N','" & Trim(gUsername) & "','" & Format(DateTime.Now, "dd/MMM/yyyy") & "') "
                    ReDim Preserve INSERT(INSERT.Length)
                    INSERT(INSERT.Length - 1) = sqlstring
                Next
                gconn.MoreTrans(INSERT)
                Call cmd_Clear_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub PTY_MENUGROUP_MASTER_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call cmd_Clear_Click(cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then
            Call cmd_Add_Click(cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            Call cmd_Freeze_Click(sender, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 Then
            Call cmd_View_Click(cmd_View, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmd_Exit_Click(cmd_Exit, e)
            Exit Sub
        End If
    End Sub
    Private Sub cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_View.Click
        gPrint = False
        Grp_Print.Visible = True
    End Sub

    Private Sub CMD_PRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_PRINT.Click
        gPrint = True
        Grp_Print.Visible = True
    End Sub
    Private Sub CMD_WINDOWS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_WINDOWS.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_MAS_MENUGROUPHISTORY
        STR = "SELECT * FROM VIEW_PARTY_MENUGROUPHISTORY ORDER BY MENUCODE,GROUPCODE "
        Viewer.ssql = STR
        Viewer.Report = r
        Viewer.TableName = "VIEW_PARTY_MENUGROUPHISTORY"
        Dim textobj1 As TextObject
        textobj1 = r.ReportDefinition.ReportObjects("Text1")
        textobj1.Text = MyCompanyName
        Dim TXTOBJ2 As TextObject
        TXTOBJ2 = r.ReportDefinition.ReportObjects("Text5")
        TXTOBJ2.Text = gUsername
        Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ6 = r.ReportDefinition.ReportObjects("Text13")
        TXTOBJ6.Text = Address1 & Address2

        Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ8 = r.ReportDefinition.ReportObjects("Text14")
        TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ9 = r.ReportDefinition.ReportObjects("Text15")
        TXTOBJ9.Text = "PhoneNo : " & gphoneno
        Viewer.Show()
        Grp_Print.Visible = False
    End Sub
    Private Sub CMD_DOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_DOS.Click
        Dim i, j As Integer
        Dim Type() As String
        Dim tablename As String
        Dim typename As String
        Dim heading As String
        Dim str As String
        heading = "UOM MASTER"
        str = "SELECT * from VIEW_PARTY_MENUGROUPHISTORY ORDER BY MENUCODE,GROUPCODE"
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
            Filewrite.WriteLine("SNO MENU CODE MENU DESCRIPTION      ")
            Filewrite.WriteLine("    GROUP CODE GROUP DESCRIPTION    ")
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
        Dim MENUCODE As String
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

                    If MENUCODE <> dr("MENUCODE") Then
                        C = C + 1
                        SSQL = Space(3 - Len(Mid(Format(C, "0"), 1, 3))) & Mid(Format(C, "0"), 1, 3)
                        SSQL = SSQL & Space(1) & Mid(Format(dr("MENUCODE"), ""), 1, 10) & Space(10 - Len(Mid(Format(dr("MENUCODE"), ""), 1, 10)))
                        SSQL = SSQL & Space(1) & Mid(Format(dr("MENUDESC"), ""), 1, 25) & Space(25 - Len(Mid(Format(dr("MENUDESC"), ""), 1, 25)))
                        Filewrite.WriteLine(SSQL)
                        pagesize = pagesize + 1
                    End If
                    MENUCODE = dr("MENUCODE")
                    SSQL = Space(5)
                    SSQL = SSQL & Space(1) & Mid(Format(dr("GROUPCODE"), ""), 1, 10) & Space(10 - Len(Mid(Format(dr("GROUPCODE"), ""), 1, 10)))
                    SSQL = SSQL & Space(1) & Mid(Format(dr("GROUPDESC"), ""), 1, 25) & Space(25 - Len(Mid(Format(dr("GROUPDESC"), ""), 1, 25)))
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
        _export.TABLENAME = "VIEW_PARTY_MENUGROUPHISTORY"
        sqlstring = "SELECT * FROM VIEW_PARTY_MENUGROUPHISTORY ORDER BY MENUCODE,GROUPCODE "
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_Freeze.Click
        Call checkvalidate()
        If boolchk = False Then Exit Sub
        If Mid(cmd_Freeze.Text, 1, 1) = "F" Then
            sqlstring = "select isnull(MENUcode,'') as MENUcode,isnull(MENUdesc,'') as MENUdesc FROM Party_menugroupmaster"
            sqlstring = sqlstring & " WHERE ISNULL(menucode,'')='" & Trim(txt_MenuCode.Text) & "'"
            gconn.getDataSet(sqlstring, "GRP1")
            If gdataset.Tables("GRP1").Rows.Count > 0 Then
                sqlstring = "UPDATE Party_menugroupmaster SET FREEZE='Y',"
                sqlstring = sqlstring & " ADDUSER='" & Trim(gUsername) & "',ADDDATE='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' "
                sqlstring = sqlstring & " WHERE menucode='" & Trim(txt_MenuCode.Text) & "'"
                gconn.dataOperation(3, sqlstring, "party_menu_master")
                Call cmd_Clear_Click(sender, e)
                cmd_Add.Text = "Add [F7]"
            End If
        End If
        If Mid(cmd_Freeze.Text, 1, 1) = "U" Then
            'ElseIf Mid(cmd_Freeze.Text, 1, 1) = "U" Then
            sqlstring = "UPDATE Party_menugroupmaster SET FREEZE='N',"
            sqlstring = sqlstring & " ADDUSER='" & Trim(gUsername) & "',ADDDATE='" & Format(DateTime.Now, "dd/MMM/yyyy") & "' "
            sqlstring = sqlstring & " WHERE menucode='" & Trim(txt_MenuCode.Text) & "'"
            gconn.dataOperation(4, sqlstring, "party_menu_master")
            Call cmd_Clear_Click(sender, e)
            cmd_Add.Text = "Add [F7]"
        End If
    End Sub



    Private Sub txt_MenuCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_MenuCode.TextChanged

    End Sub
End Class
