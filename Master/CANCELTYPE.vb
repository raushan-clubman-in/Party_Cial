Public Class CANCELTYPE
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtItemType As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ItemTypeDesc As System.Windows.Forms.Label
    Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ItemType As System.Windows.Forms.Label
    Friend WithEvents cmdItemHelp As System.Windows.Forms.Button
    Friend WithEvents ssgrid As AxFPSpreadADO.AxfpSpread
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CANCELTYPE))
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl_Freeze = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.CmdClear = New System.Windows.Forms.Button
        Me.CmdView = New System.Windows.Forms.Button
        Me.Cmd_Freeze = New System.Windows.Forms.Button
        Me.CmdAdd = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtItemType = New System.Windows.Forms.TextBox
        Me.lbl_ItemTypeDesc = New System.Windows.Forms.Label
        Me.txtItemDesc = New System.Windows.Forms.TextBox
        Me.lbl_ItemType = New System.Windows.Forms.Label
        Me.cmdItemHelp = New System.Windows.Forms.Button
        Me.ssgrid = New AxFPSpreadADO.AxfpSpread
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(352, 584)
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
        Me.lbl_Freeze.Location = New System.Drawing.Point(432, 496)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(173, 25)
        Me.lbl_Freeze.TabIndex = 420
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
        Me.Label16.Location = New System.Drawing.Point(416, 80)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(320, 31)
        Me.Label16.TabIndex = 418
        Me.Label16.Text = "CANCEL GROUP MASTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.CmdClear)
        Me.GroupBox2.Controls.Add(Me.CmdView)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Controls.Add(Me.CmdAdd)
        Me.GroupBox2.Controls.Add(Me.cmdexit)
        Me.GroupBox2.Location = New System.Drawing.Point(256, 520)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(576, 56)
        Me.GroupBox2.TabIndex = 421
        Me.GroupBox2.TabStop = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdClear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.White
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.Location = New System.Drawing.Point(8, 12)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(104, 32)
        Me.CmdClear.TabIndex = 5
        Me.CmdClear.Text = "Clear[F6]"
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdView.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.White
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.Location = New System.Drawing.Point(352, 12)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(104, 32)
        Me.CmdView.TabIndex = 8
        Me.CmdView.Text = " View[F9]"
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.Location = New System.Drawing.Point(240, 12)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze.TabIndex = 7
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        '
        'CmdAdd
        '
        Me.CmdAdd.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdAdd.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.ForeColor = System.Drawing.Color.White
        Me.CmdAdd.Image = CType(resources.GetObject("CmdAdd.Image"), System.Drawing.Image)
        Me.CmdAdd.Location = New System.Drawing.Point(128, 12)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(104, 32)
        Me.CmdAdd.TabIndex = 6
        Me.CmdAdd.Text = "Add [F7]"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.White
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.Location = New System.Drawing.Point(464, 12)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(104, 32)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "Exit[F11]"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtItemType)
        Me.GroupBox1.Controls.Add(Me.lbl_ItemTypeDesc)
        Me.GroupBox1.Controls.Add(Me.txtItemDesc)
        Me.GroupBox1.Controls.Add(Me.lbl_ItemType)
        Me.GroupBox1.Controls.Add(Me.cmdItemHelp)
        Me.GroupBox1.Location = New System.Drawing.Point(184, 136)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(720, 352)
        Me.GroupBox1.TabIndex = 419
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(440, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 22)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "[F4]"
        '
        'txtItemType
        '
        Me.txtItemType.BackColor = System.Drawing.Color.Wheat
        Me.txtItemType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemType.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemType.ForeColor = System.Drawing.Color.Black
        Me.txtItemType.Location = New System.Drawing.Point(296, 32)
        Me.txtItemType.MaxLength = 15
        Me.txtItemType.Name = "txtItemType"
        Me.txtItemType.Size = New System.Drawing.Size(120, 26)
        Me.txtItemType.TabIndex = 0
        Me.txtItemType.Text = ""
        '
        'lbl_ItemTypeDesc
        '
        Me.lbl_ItemTypeDesc.AutoSize = True
        Me.lbl_ItemTypeDesc.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ItemTypeDesc.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ItemTypeDesc.ForeColor = System.Drawing.Color.Black
        Me.lbl_ItemTypeDesc.Location = New System.Drawing.Point(104, 72)
        Me.lbl_ItemTypeDesc.Name = "lbl_ItemTypeDesc"
        Me.lbl_ItemTypeDesc.Size = New System.Drawing.Size(146, 21)
        Me.lbl_ItemTypeDesc.TabIndex = 20
        Me.lbl_ItemTypeDesc.Text = "ITEM TYPE DESC :"
        '
        'txtItemDesc
        '
        Me.txtItemDesc.BackColor = System.Drawing.Color.Wheat
        Me.txtItemDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemDesc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemDesc.ForeColor = System.Drawing.Color.Black
        Me.txtItemDesc.Location = New System.Drawing.Point(296, 72)
        Me.txtItemDesc.MaxLength = 50
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(280, 26)
        Me.txtItemDesc.TabIndex = 2
        Me.txtItemDesc.Text = ""
        '
        'lbl_ItemType
        '
        Me.lbl_ItemType.AutoSize = True
        Me.lbl_ItemType.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ItemType.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ItemType.ForeColor = System.Drawing.Color.Black
        Me.lbl_ItemType.Location = New System.Drawing.Point(104, 32)
        Me.lbl_ItemType.Name = "lbl_ItemType"
        Me.lbl_ItemType.Size = New System.Drawing.Size(101, 21)
        Me.lbl_ItemType.TabIndex = 17
        Me.lbl_ItemType.Text = "ITEM TYPE :"
        '
        'cmdItemHelp
        '
        Me.cmdItemHelp.Image = CType(resources.GetObject("cmdItemHelp.Image"), System.Drawing.Image)
        Me.cmdItemHelp.Location = New System.Drawing.Point(416, 32)
        Me.cmdItemHelp.Name = "cmdItemHelp"
        Me.cmdItemHelp.Size = New System.Drawing.Size(23, 26)
        Me.cmdItemHelp.TabIndex = 1
        '
        'ssgrid
        '
        Me.ssgrid.DataSource = Nothing
        Me.ssgrid.Location = New System.Drawing.Point(328, 248)
        Me.ssgrid.Name = "ssgrid"
        Me.ssgrid.OcxState = CType(resources.GetObject("ssgrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid.Size = New System.Drawing.Size(464, 208)
        Me.ssgrid.TabIndex = 423
        '
        'CANCELTYPE
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(238, Byte), CType(249, Byte), CType(232, Byte))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(976, 589)
        Me.Controls.Add(Me.ssgrid)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "CANCELTYPE"
        Me.Text = "CANCELTYPE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ssgrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim vseqno, vTaxseqno As Double
    Dim gconnection As New GlobalClass
    Dim I, K As Integer
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.ssGrid.ClearRange(1, 1, -1, -1, True)
        Me.CmdAdd.Text = "Add [F7]"
        ssGrid.ClearRange(-1, -1, 1, 1, True)
        ssGrid.SetActiveCell(1, 1)
        txtItemDesc.Text = ""
        txtItemType.Text = ""
        txtItemType.ReadOnly = False
        cmdItemHelp.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtItemType.Focus()
    End Sub
    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim strsql, Insert(0) As String
        Dim CPERC As Double
        Dim FDAYS, TDAYS As Integer
        If CmdAdd.Text = "Add [F7]" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            sqlstring = "Insert Into PARTY_GROUPMASTER(ITEMTYPECODE,ITEMDESC,Freeze,Adduserid,Adddatetime)"
            sqlstring = sqlstring & " values('" & Trim(txtItemType.Text) & "','" & txtItemDesc.Text & "',"
            sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "',"
            sqlstring = sqlstring & " '" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            Insert(0) = sqlstring
            With ssGrid
                For I = 1 To ssGrid.DataRowCnt
                    CPERC = 0.0 : FDAYS = 0 : TDAYS = 0
                    .Row = I
                    .Col = 1
                    FDAYS = IIf(Len(Trim(.Text)) > 0, Format(Val(.Text), "0.00"), 0)
                    .Row = I
                    .Col = 2
                    TDAYS = IIf(Len(Trim(.Text)) > 0, Format(Val(.Text), "0.00"), 0)
                    .Row = I
                    .Col = 3
                    CPERC = IIf(Len(Trim(.Text)) > 0, Format(Val(.Text), "0.00"), 0)
                    strsql = ""
                    sqlstring = "Insert Into PARTY_GROUPMASTER_DET(ITEMTYPECODE,ITEMDESC,CANCELPERCENTAGE,FROMDAYS,TODAYS,"
                    sqlstring = sqlstring & "Freeze,Adduserid,Adddatetime)"
                    sqlstring = sqlstring & " values('" & Trim(txtItemType.Text) & "',"
                    sqlstring = sqlstring & " '" & txtItemDesc.Text & "',"
                    sqlstring = sqlstring & " '" & CPERC & "',"
                    sqlstring = sqlstring & " '" & FDAYS & "',"
                    sqlstring = sqlstring & " '" & TDAYS & "',"
                    sqlstring = sqlstring & " 'N'" & ","
                    sqlstring = sqlstring & " '" & Trim(gUsername) & "',"
                    sqlstring = sqlstring & " '" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                Next
            End With
            gconnection.MoreTrans(Insert)
        ElseIf CmdAdd.Text = "Update[F7]" Then
            Call checkValidation()
            If boolchk = False Then Exit Sub
            If Mid(Me.CmdAdd.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                End If
            End If
            sqlstring = "Update PARTY_GROUPMASTER SET ITEMDESC="
            sqlstring = sqlstring & "'" & txtItemDesc.Text & "'"
            sqlstring = sqlstring & ",Freeze='N' "
            sqlstring = sqlstring & ",Adduserid='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " where ITEMTYPECODE='" & Trim(txtItemType.Text) & "'"
            Insert(0) = sqlstring

            strsql = "Delete From PARTY_GROUPMASTER_DET Where ItemTypeCode = '" & Trim(txtItemType.Text) & "'"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = strsql

            With ssgrid
                For I = 1 To ssgrid.DataRowCnt
                    CPERC = 0.0 : FDAYS = 0 : TDAYS = 0
                    .Row = I
                    .Col = 1
                    FDAYS = IIf(Len(Trim(.Text)) > 0, Format(Val(.Text), "0.00"), 0)
                    .Row = I
                    .Col = 2
                    TDAYS = IIf(Len(Trim(.Text)) > 0, Format(Val(.Text), "0.00"), 0)
                    .Row = I
                    .Col = 3
                    CPERC = IIf(Len(Trim(.Text)) > 0, Format(Val(.Text), "0.00"), 0)
                    strsql = ""
                    sqlstring = "Insert Into PARTY_GROUPMASTER_DET(ITEMTYPECODE,ITEMDESC,CANCELPERCENTAGE,FROMDAYS,TODAYS,"
                    sqlstring = sqlstring & "Freeze,Adduserid,Adddatetime)"
                    sqlstring = sqlstring & " values('" & Trim(txtItemType.Text) & "',"
                    sqlstring = sqlstring & " '" & txtItemDesc.Text & "',"
                    sqlstring = sqlstring & " '" & CPERC & "',"
                    sqlstring = sqlstring & " '" & FDAYS & "',"
                    sqlstring = sqlstring & " '" & TDAYS & "',"
                    sqlstring = sqlstring & " 'N'" & ","
                    sqlstring = sqlstring & " '" & Trim(gUsername) & "',"
                    sqlstring = sqlstring & " '" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = sqlstring
                Next
            End With
            gconnection.MoreTrans(Insert)
            CmdAdd.Text = "Add [F7]"
        End If
        Me.CmdClear_Click(sender, e)
    End Sub
    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        Dim Insert(0) As String
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            sqlstring = "UPDATE  PARTY_GROUPMASTER "
            sqlstring = sqlstring & " SET Freeze= 'Y',Adduserid='" & Trim(gUsername) & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE ItemTypeCode = '" & Trim(txtItemType.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "PARTY_GROUPMASTER")
            Insert(0) = sqlstring

            sqlstring = "UPDATE  PARTY_GROUPMASTER_DET "
            sqlstring = sqlstring & " SET Freeze= 'Y',Adduserid='" & Trim(gUsername) & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE ItemTypeCode = '" & Trim(txtItemType.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "PARTY_GROUPMASTER")

            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            gconnection.dataOperation1(3, Insert)
            Me.CmdClear_Click(sender, e)
            CmdAdd.Text = "Add [F7]"
        Else
            sqlstring = "UPDATE  PARTY_GROUPMASTER "
            sqlstring = sqlstring & " SET Freeze= 'N',Adduserid='" & Trim(gUsername) & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE ItemTypeCode = '" & Trim(txtItemType.Text) & "'"
            gconnection.dataOperation(4, sqlstring, "PARTY_GROUPMASTER")
            Insert(0) = sqlstring

            sqlstring = "UPDATE  PARTY_GROUPMASTER_DET "
            sqlstring = sqlstring & " SET Freeze= 'N',Adduserid='" & Trim(gUsername) & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE ItemTypeCode = '" & Trim(txtItemType.Text) & "'"
            gconnection.dataOperation(4, sqlstring, "PARTY_GROUPMASTER")

            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = sqlstring

            gconnection.dataOperation1(3, Insert)
            Me.CmdClear_Click(sender, e)
            CmdAdd.Text = "Add [F7]"
        End If
    End Sub
    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        '''*****************************************  View  And Print Operation *************************************'''
        Dim FrReport As New ReportDesigner
        tables = " FROM PARTY_GROUPMASTER_DET"
        Gheader = "ITEMTYPE MASTER"
        FrReport.SsGridReport.SetText(2, 1, "ITEMTYPECODE")
        FrReport.SsGridReport.SetText(3, 1, 10)
        FrReport.SsGridReport.SetText(2, 2, "ITEMDESC")
        FrReport.SsGridReport.SetText(3, 2, 35)
        FrReport.SsGridReport.SetText(2, 3, "CANCELPERCENTAGE")
        FrReport.SsGridReport.SetText(3, 3, 16)
        FrReport.SsGridReport.SetText(2, 4, "FROMDAYS")
        FrReport.SsGridReport.SetText(3, 4, 8)
        FrReport.SsGridReport.SetText(2, 5, "TODAYS")
        FrReport.SsGridReport.SetText(3, 5, 7)
        FrReport.SsGridReport.SetText(2, 6, "FREEZE")
        FrReport.SsGridReport.SetText(3, 6, 5)
        FrReport.Show()
    End Sub
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Hide()
    End Sub
    Private Sub CANCELTYPE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        itemtypebool = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtItemType.Focus()
    End Sub
    Public Sub checkValidation()
        Dim I, COUNTER As Integer
        boolchk = False
        '''******************************************* CHECK  ITEM TYPE CODE Can't be blank ***************************************'''
        If Trim(txtItemType.Text) = "" Then
            MessageBox.Show(" ITEM TYPE CODE Cannot be Blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtItemType.Focus()
            Exit Sub
        End If
        '''******************************************* CHECK  ITEM DESC Can't be blank ***************************************'''
        If Trim(txtItemDesc.Text) = "" Then
            MessageBox.Show(" ITEM TYPE DESCRIPTION Cannot be Blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtItemDesc.Focus()
            Exit Sub
        End If
        For I = 0 To ssGrid.DataRowCnt
            ssGrid.Col = 7
            ssGrid.Row = I
            If ssGrid.Text = "True" Then
                COUNTER = COUNTER + 1
                If COUNTER >= 2 Then
                    MessageBox.Show(" Multiple CANCEL PERC% CODE can't be selected ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ssGrid.SetActiveCell(7, I)
                    Exit Sub
                End If
            End If
        Next
        boolchk = True
    End Sub
    Private Sub FillGrid()
        Dim j, i As Integer
        i = 1
        sqlstring = " SELECT DISTINCT ISNULL(T.TaxCode,'') AS TaxCode,ISNULL(T.Taxdesc,'')AS Taxdesc,"
        sqlstring = sqlstring & " ISNULL(T.Taxpercentage,0)AS Taxpercentage,ISNULL(Glaccountin,'') AS Glaccountin  "
        sqlstring = sqlstring & " FROM ACCOUNTSTAXMASTER AS T  WHERE  T.Taxpercentage <> 0 AND ISNULL(Freezeflag,'') <> 'Y'"
        gconnection.getDataSet(sqlstring, "ACCOUNTSTAXMASTER")
        If gdataset.Tables("ACCOUNTSTAXMASTER").Rows.Count > 0 Then
            ssGrid.ClearRange(1, 1, -1, -1, True)
            For j = 0 To gdataset.Tables("ACCOUNTSTAXMASTER").Rows.Count - 1
                With ssGrid
                    .Row = i
                    .Col = 1
                    .Text = gdataset.Tables("ACCOUNTSTAXMASTER").Rows(j).Item("TaxCode")
                    .Row = i
                    .Col = 2
                    .Text = gdataset.Tables("ACCOUNTSTAXMASTER").Rows(j).Item("Taxdesc")
                    .Row = i
                    .Col = 3
                    .Text = gdataset.Tables("ACCOUNTSTAXMASTER").Rows(j).Item("Taxpercentage")
                    .Row = i
                    .Col = 6
                    .Text = gdataset.Tables("ACCOUNTSTAXMASTER").Rows(j).Item("Glaccountin")
                    i = i + 1
                End With
            Next
            ssGrid.Focus()
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
        Me.CmdAdd.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        CmdView.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdAdd.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.CmdView.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.CmdAdd.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.CmdAdd.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.CmdAdd.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.CmdView.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub cmdItemHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemHelp.Click
        Try
            Dim vform As New ListOperattion1
            gSQLString = " SELECT ITEMTYPECODE,ITEMTYPEDESC FROM VIEW_PARTY_CANCELGROUPHELP "
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "ITEMTYPECODE,ITEMTYPEDESC"
            vform.vFormatstring = "ITEMTYPECODE  |  ITEMTYPE DESCRIPTION       "
        vform.vCaption = "ITEM TYPE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txtItemType.Text = Trim(vform.keyfield & "")
            Call txtItemType_Validated(txtItemType, e)
        End If
        vform.Close()
            vform = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtItemType_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemType.Validated
        Dim Fre As String
        Try
            If Trim(txtItemType.Text) <> "" Then
                Dim ds As New DataSet
                sqlstring = "SELECT ISNULL(ItemTypeCode,'') AS ItemTypeCode,ISNULL(ItemDesc,'') AS ItemDesc,ISNULL(CANCELPERCENTAGE,0) AS CANCELPERCENTAGE,ISNULL(Freeze,'') AS Freeze,ISNULL(FROMDAYS,0) AS FROMDAYS,ISNULL(TODAYS,0) AS TODAYS,ISNULL(Adduserid,'') AS Adduserid,ISNULL(AddDateTime,'') AS AddDateTime  FROM PARTY_GROUPMASTER_DET"
                sqlstring = sqlstring & " WHERE ITEMTYPECODE='" & txtItemType.Text & "'"
                gconnection.getDataSet(sqlstring, "CANCELPERC")
                If gdataset.Tables("CANCELPERC").Rows.Count > 0 Then
                    txtItemDesc.Clear()
                    txtItemDesc.Text = gdataset.Tables("CANCELPERC").Rows(0).Item("ItemDesc")
                    If gdataset.Tables("CANCELPERC").Rows(0).Item("Freeze") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("CANCELPERC").Rows(0).Item("ADDDATETIME")), "dd-MMM-yyyy")
                        Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_Freeze.Text = "Freeze[F8]"
                    End If
                    Me.CmdAdd.Text = "Update[F7]"
                    If gUserCategory <> "S" Then
                        Call GetRights()
                    End If
                    ssGrid.ClearRange(-1, -1, 1, 1, True)
                    ssGrid.SetActiveCell(1, 1)
                    With ssGrid
                        For I = 0 To gdataset.Tables("CANCELPERC").Rows.Count - 1
                            .Col = 1
                            .Row = I + 1
                            .Text = Val(gdataset.Tables("CANCELPERC").Rows(I).Item("FROMDAYS"))
                            .Col = 2
                            .Row = I + 1
                            .Text = Val(gdataset.Tables("CANCELPERC").Rows(I).Item("TODAYS"))
                            .Col = 3
                            .Row = I + 1
                            .Text = Val(gdataset.Tables("CANCELPERC").Rows(I).Item("CANCELPERCENTAGE"))
                        Next
                        .SetActiveCell(1, 1)
                    End With
                    Me.txtItemType.ReadOnly = True
                    Me.cmdItemHelp.Enabled = False
                    Me.txtItemDesc.Focus()
                End If
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.CmdAdd.Text = "Add [F7]"
                txtItemType.ReadOnly = False
                txtItemDesc.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub txtItemDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemDesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.ssGrid.Focus()
        End If
    End Sub
    Private Sub txtItemType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemType.KeyPress
        'getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            txtItemDesc.Focus()
        End If
    End Sub
    Private Sub txtItemType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemType.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdItemHelp.Enabled = True Then
                Call cmdItemHelp_Click(cmdItemHelp, e)
            End If
        End If
        If e.KeyCode = Keys.Enter Then
            If txtItemType.Text = "" Then
                If cmdItemHelp.Enabled = True Then
                    Call cmdItemHelp_Click(cmdItemHelp, e)
                End If
            End If
        End If
    End Sub

    Private Sub CANCELPERMASTER()
        '''*********************************** TO FILL TAX FROM ACCOUNTSTAXMASTER IF ITEMTYPE IS NOT THERE ******************'''
        Try
            Dim j, i, COUNTER As Integer
            sqlstring = " SELECT ISNULL(ItemTypeCode,'') AS ItemTypeCode,ISNULL(ItemDesc,'') AS ItemDesc,ISNULL(            CANCELPERCENTAGE,0) AS CANCELPERCENTAGE,ISNULL(Freeze,'') AS Freeze,ISNULL(FROMDAYS,0) AS FROMDAYS,ISNULL(TODAYS,0) AS TODAYS,ISNULL(Adduserid,'') AS Adduserid,ISNULL(AddDateTime,'') AS AddDateTime  FROM PARTY_GROUPMASTER"
            sqlstring = sqlstring & " WHERE itemtypecode = '" & Trim(txtItemType.Text) & "'"
            gconnection.getDataSet(sqlstring, "CPERC")
            If gdataset.Tables("CPERC").Rows.Count > 0 Then
                txtItemDesc.Text = gdataset.Tables("CPERC").Rows(j).Item("Itemdesc")
                With ssGrid
                    For j = 0 To gdataset.Tables("CPERC").Rows.Count - 1
                        .Row = i + 1
                        .Col = 1
                        .Text = gdataset.Tables("CPERC").Rows(j).Item("CANCELPERCENTAGE")

                        .Row = i + 1
                        .Col = 2
                        .Text = gdataset.Tables("CPERC").Rows(j).Item("FROMDAYS")

                        .Row = i + 1
                        .Col = 2
                        .Text = gdataset.Tables("CPERC").Rows(j).Item("TOMDAYS")
                        ssGrid.SetActiveCell(1, i + 1)
                    Next
                End With
            End If
        Catch ex As Exception
            MessageBox.Show("Handle the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub ssGrid_KeyDownEvent(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent)
        Try
            If e.keyCode = Keys.Enter Then
                If ssGrid.ActiveCol = 1 Then
                    ssGrid.SetActiveCell(2, ssGrid.ActiveRow)
                ElseIf ssGrid.ActiveCol = 2 Then
                    ssGrid.SetActiveCell(3, ssGrid.ActiveRow)
                ElseIf ssGrid.ActiveCol = 3 Then
                    ssGrid.SetActiveCell(1, ssGrid.ActiveRow + 1)
                End If
            ElseIf e.keyCode = Keys.F3 Then
                ssGrid.Row = ssGrid.ActiveRow
                ssGrid.DeleteRows(ssGrid.ActiveRow, 1)
                If ssGrid.ActiveRow <= 1 Then
                    ssGrid.SetActiveCell(1, ssGrid.ActiveRow)
                Else
                    ssGrid.SetActiveCell(1, ssGrid.ActiveRow - 1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Handle the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub ssGrid_LeaveCell(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent)
        'Try
        '    With ssGrid
        '        If .ActiveCol = 1 Then
        '            .Col = 1
        '            .Row = .ActiveRow
        '            'If Val(.Text) = 0 Then
        '            '    '.SetActiveCell(1, .ActiveRow)
        '            'End If
        '        End If
        '        If .ActiveCol = 2 Then
        '            .Col = 2
        '            .Row = .ActiveRow
        '            'If Val(.Text) = 0 Then
        '            '    '.SetActiveCell(2, .ActiveRow)
        '            'End If
        '        End If
        '        If .ActiveCol = 3 Then
        '            .Col = 3
        '            .Row = .ActiveRow
        '            'If Val(.Text) = 0 Then
        '            '    '.SetActiveCell(3, .ActiveRow)
        '            'End If
        '        End If
        '    End With
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub

    Private Sub txtItemType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemType.TextChanged

    End Sub

    Private Sub txtItemDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemDesc.TextChanged

    End Sub

    Private Sub ssGrid_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent)

    End Sub
    Private Sub CANCELTYPE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(CmdClear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            Call Cmd_Freeze_Click(Cmd_Freeze, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then
            Call CmdAdd_Click(CmdAdd, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 Then
            Call CmdView_Click(CmdView, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmdexit_Click(cmdexit, e)
            Exit Sub
        End If
    End Sub

    Private Sub AxfpSpread1_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid.Advance

    End Sub
    Private Sub ssgrid_KeyDownEvent1(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid.KeyDownEvent
        Try
            If e.keyCode = Keys.Enter Then
                If ssgrid.ActiveCol = 1 Then
                    ssgrid.SetActiveCell(2, ssgrid.ActiveRow)
                ElseIf ssgrid.ActiveCol = 2 Then
                    ssgrid.SetActiveCell(3, ssgrid.ActiveRow)
                ElseIf ssgrid.ActiveCol = 3 Then
                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow + 1)
                End If
            ElseIf e.keyCode = Keys.F3 Then
                ssgrid.Row = ssgrid.ActiveRow
                ssgrid.DeleteRows(ssgrid.ActiveRow, 1)
                If ssgrid.ActiveRow <= 1 Then
                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow)
                Else
                    ssgrid.SetActiveCell(1, ssgrid.ActiveRow - 1)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Handle the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
End Class
