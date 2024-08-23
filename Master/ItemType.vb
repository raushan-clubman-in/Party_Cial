Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.IO
Public Class ItemType
    Inherits System.Windows.Forms.Form
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim vseqno, vTaxseqno As Double
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
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
    Friend WithEvents cmdItemHelp As System.Windows.Forms.Button
    Friend WithEvents txtItemType As System.Windows.Forms.TextBox
    Friend WithEvents lbl_ItemTypeDesc As System.Windows.Forms.Label
    Friend WithEvents lbl_ItemType As System.Windows.Forms.Label
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ssGrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ItemType))
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ssGrid = New AxFPSpreadADO.AxfpSpread
        Me.cmdItemHelp = New System.Windows.Forms.Button
        Me.txtItemDesc = New System.Windows.Forms.TextBox
        Me.txtItemType = New System.Windows.Forms.TextBox
        Me.lbl_ItemTypeDesc = New System.Windows.Forms.Label
        Me.lbl_ItemType = New System.Windows.Forms.Label
        Me.lbl_Freeze = New System.Windows.Forms.Label
        Me.CmdClear = New System.Windows.Forms.Button
        Me.CmdView = New System.Windows.Forms.Button
        Me.Cmd_Freeze = New System.Windows.Forms.Button
        Me.CmdAdd = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdexport = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(259, 8)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(258, 31)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "ITEM TYPE MASTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackgroundImage = CType(resources.GetObject("GroupBox1.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox1.Controls.Add(Me.ssGrid)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(720, 352)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'ssGrid
        '
        Me.ssGrid.ContainingControl = Me
        Me.ssGrid.DataSource = Nothing
        Me.ssGrid.Location = New System.Drawing.Point(56, 99)
        Me.ssGrid.Name = "ssGrid"
        Me.ssGrid.OcxState = CType(resources.GetObject("ssGrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssGrid.Size = New System.Drawing.Size(616, 240)
        Me.ssGrid.TabIndex = 2
        '
        'cmdItemHelp
        '
        Me.cmdItemHelp.Image = CType(resources.GetObject("cmdItemHelp.Image"), System.Drawing.Image)
        Me.cmdItemHelp.Location = New System.Drawing.Point(552, 64)
        Me.cmdItemHelp.Name = "cmdItemHelp"
        Me.cmdItemHelp.Size = New System.Drawing.Size(23, 26)
        Me.cmdItemHelp.TabIndex = 12
        '
        'txtItemDesc
        '
        Me.txtItemDesc.BackColor = System.Drawing.Color.Wheat
        Me.txtItemDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemDesc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemDesc.ForeColor = System.Drawing.Color.Black
        Me.txtItemDesc.Location = New System.Drawing.Point(328, 104)
        Me.txtItemDesc.MaxLength = 50
        Me.txtItemDesc.Name = "txtItemDesc"
        Me.txtItemDesc.Size = New System.Drawing.Size(280, 26)
        Me.txtItemDesc.TabIndex = 1
        Me.txtItemDesc.Text = ""
        '
        'txtItemType
        '
        Me.txtItemType.BackColor = System.Drawing.Color.Wheat
        Me.txtItemType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtItemType.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemType.ForeColor = System.Drawing.Color.Black
        Me.txtItemType.Location = New System.Drawing.Point(328, 64)
        Me.txtItemType.MaxLength = 15
        Me.txtItemType.Name = "txtItemType"
        Me.txtItemType.Size = New System.Drawing.Size(224, 26)
        Me.txtItemType.TabIndex = 0
        Me.txtItemType.Text = ""
        '
        'lbl_ItemTypeDesc
        '
        Me.lbl_ItemTypeDesc.AutoSize = True
        Me.lbl_ItemTypeDesc.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ItemTypeDesc.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ItemTypeDesc.ForeColor = System.Drawing.Color.Black
        Me.lbl_ItemTypeDesc.Location = New System.Drawing.Point(136, 104)
        Me.lbl_ItemTypeDesc.Name = "lbl_ItemTypeDesc"
        Me.lbl_ItemTypeDesc.Size = New System.Drawing.Size(146, 21)
        Me.lbl_ItemTypeDesc.TabIndex = 14
        Me.lbl_ItemTypeDesc.Text = "ITEM TYPE DESC :"
        '
        'lbl_ItemType
        '
        Me.lbl_ItemType.AutoSize = True
        Me.lbl_ItemType.BackColor = System.Drawing.Color.Transparent
        Me.lbl_ItemType.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ItemType.ForeColor = System.Drawing.Color.Black
        Me.lbl_ItemType.Location = New System.Drawing.Point(136, 64)
        Me.lbl_ItemType.Name = "lbl_ItemType"
        Me.lbl_ItemType.Size = New System.Drawing.Size(101, 21)
        Me.lbl_ItemType.TabIndex = 11
        Me.lbl_ItemType.Text = "ITEM TYPE :"
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(304, 400)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(173, 25)
        Me.lbl_Freeze.TabIndex = 17
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdClear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.White
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.Location = New System.Drawing.Point(48, 448)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(104, 32)
        Me.CmdClear.TabIndex = 4
        Me.CmdClear.Text = "Clear[F6]"
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdView.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.White
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.Location = New System.Drawing.Point(424, 16)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(104, 32)
        Me.CmdView.TabIndex = 7
        Me.CmdView.Text = " View[F9]"
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.Location = New System.Drawing.Point(288, 16)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze.TabIndex = 6
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        '
        'CmdAdd
        '
        Me.CmdAdd.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdAdd.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.ForeColor = System.Drawing.Color.White
        Me.CmdAdd.Image = CType(resources.GetObject("CmdAdd.Image"), System.Drawing.Image)
        Me.CmdAdd.Location = New System.Drawing.Point(192, 448)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(104, 32)
        Me.CmdAdd.TabIndex = 5
        Me.CmdAdd.Text = "Add [F7]"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.White
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.Location = New System.Drawing.Point(592, 448)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(104, 32)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "Exit[F11]"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.CmdView)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze)
        Me.GroupBox2.Location = New System.Drawing.Point(32, 432)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(704, 56)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdexport.BackgroundImage = CType(resources.GetObject("cmdexport.BackgroundImage"), System.Drawing.Image)
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Location = New System.Drawing.Point(544, 392)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(104, 32)
        Me.cmdexport.TabIndex = 435
        Me.cmdexport.Text = "Report[F12]"
        Me.cmdexport.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(576, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 22)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "[F4]"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(96, 488)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(383, 18)
        Me.Label5.TabIndex = 417
        Me.Label5.Text = "Press F4 for HELP / Press ENTER key to navigate"
        '
        'ItemType
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 16)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(238, Byte), CType(249, Byte), CType(232, Byte))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(774, 508)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtItemType)
        Me.Controls.Add(Me.lbl_ItemTypeDesc)
        Me.Controls.Add(Me.txtItemDesc)
        Me.Controls.Add(Me.lbl_ItemType)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.CmdAdd)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdItemHelp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdexport)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "ItemType"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ITEM TYPE MASTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
   
    Private Sub ItemType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        Call FillGrid()
        itemtypebool = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtItemType.Focus()
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
    Private Sub txtItemtype_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemType.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtItemType.Text) <> "" Then
                Call txtItemtype_Validated(txtItemType, e)
                Exit Sub
            Else
                Call cmdItemHelp_Click(sender, e)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txtItemtype_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemType.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdItemHelp.Enabled = True Then
                Search = Trim(txtItemType.Text)
                Call cmdItemHelp_Click(cmdItemHelp, e)
            End If
        End If
    End Sub
    Private Sub txtItemDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemDesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.ssGrid.Focus()
        End If
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

    Private Sub txtItemtype_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemType.Validated
        Try
            If Trim(txtItemType.Text) <> "" Then
                sqlstring = "SELECT * FROM ItemTypeMaster WHERE ItemtypeCode= '" & Trim(txtItemType.Text) & "'"
                gconnection.getDataSet(sqlstring, "ItemTypeMaster")
                If gdataset.Tables("ItemTypeMaster").Rows.Count > 0 Then
                    txtItemType.Clear()
                    txtItemType.Text = Trim(CStr(gdataset.Tables("ItemTypeMaster").Rows(0).Item("ItemtypeCode")))
                    txtItemDesc.Clear()
                    txtItemDesc.Text = Trim(CStr(gdataset.Tables("ItemTypeMaster").Rows(0).Item("ItemTypedesc")))
                    If gdataset.Tables("ItemTypeMaster").Rows(0).Item("Freeze") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("ItemTypeMaster").Rows(0).Item("AddDateTime")), "dd-MMM-yyyy")
                        Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "Record Freezed  On "
                        Me.Cmd_Freeze.Text = "Freeze[F8]"
                    End If
                    Call FillTaxMaster()
                    Me.txtItemType.ReadOnly = True
                    Me.cmdItemHelp.Enabled = False
                    Me.CmdAdd.Text = "Update[F7]"
                    txtItemDesc.Focus()
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.CmdAdd.Text = "Add [F7]"
                    txtItemType.ReadOnly = False
                    txtItemDesc.Focus()
                End If
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
            Else
                txtItemType.Text = ""
                txtItemDesc.Text = ""
                txtItemDesc.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub FillTaxMaster()
        '''*********************************** TO FILL TAX FROM ACCOUNTSTAXMASTER IF ITEMTYPE IS NOT THERE ******************'''
        Try
            Dim j, i, COUNTER As Integer
            sqlstring = " SELECT ItemTypeCode,TaxCode,TaxPercentage,AccountCode,ISNULL(Startingdate,GETDATE()) AS Startingdate,ISNULL(EndingDate,GETDATE()) AS EndingDate FROM TAXITEMLINK WHERE itemtypecode = '" & Trim(txtItemType.Text) & "'"
            gconnection.getDataSet(sqlstring, "TAXITEMLINK")
            If gdataset.Tables("TAXITEMLINK").Rows.Count > 0 Then
                For j = 0 To gdataset.Tables("TAXITEMLINK").Rows.Count - 1
                    For i = 1 To ssGrid.DataRowCnt
                        ssGrid.Row = i
                        ssGrid.Col = 1
                        COUNTER = String.Compare(Trim(ssGrid.Text), Trim(gdataset.Tables("TAXITEMLINK").Rows(j).Item("TaxCode")))
                        If COUNTER = 0 Then
                            ssGrid.Col = 4
                            ssGrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                            ssGrid.SetText(4, i, DateValue(gdataset.Tables("TAXITEMLINK").Rows(j).Item("Startingdate")))
                            ssGrid.Col = 5
                            ssGrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                            ssGrid.SetText(5, i, DateValue(gdataset.Tables("TAXITEMLINK").Rows(j).Item("EndingDate")))
                            ssGrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                            ssGrid.SetText(7, i, "True")
                            ssGrid.SetActiveCell(4, i)
                        End If
                    Next
                Next j
            End If
        Catch ex As Exception
            MessageBox.Show("Handle the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub ItemType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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

    Public Sub FillTaxCode()
        Dim vform As New ListOperattion1
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = "SELECT DISTINCT TaxCode,TaxDesc,TaxPercentage,TypeofTax,Glaccountin,Glaccountdesc FROM ACCOUNTSTAXMASTER"
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = " WHERE TaxCode LIKE '" & Search & "%' AND ISNULL(Freezeflag,'')  <> 'Y'"
        End If
        vform.Field = "TAXCODE,TAXDESC"
        vform.vFormatstring = "  TAXCODE           |                 TAXDESC                         |  TAX PERCENTAGE  |  TAXTYPE  | "
        vform.vCaption = "TAX MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.Keypos3 = 3
        vform.keypos4 = 4
        vform.Keypos5 = 5
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            ssGrid.Col = 1
            ssGrid.Row = ssGrid.ActiveRow
            ssGrid.Text = vform.keyfield
            ssGrid.Col = 2
            ssGrid.Row = ssGrid.ActiveRow
            ssGrid.Text = vform.keyfield1
            ssGrid.Col = 3
            ssGrid.Row = ssGrid.ActiveRow
            ssGrid.Text = vform.keyfield2
            ssGrid.Col = 6
            ssGrid.Row = ssGrid.ActiveRow
            ssGrid.Text = vform.keyfield4
            ssGrid.SetActiveCell(3, ssGrid.ActiveRow)
        Else
            ssGrid.SetActiveCell(0, ssGrid.ActiveRow)
            Exit Sub
        End If
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.ssGrid.ClearRange(1, 1, -1, -1, True)
        Me.CmdAdd.Text = "Add [F7]"
        Call FillGrid()
        txtItemType.ReadOnly = False
        cmdItemHelp.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtItemType.Focus()
    End Sub
    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim strSQL, Insert(0), Update(0), Taxpercent() As String
        Dim vDate As Date
        Dim i, j, COUNTER As Integer
        If Mid(Trim(CmdAdd.Text), 1, 1) = "A" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            For i = 1 To ssGrid.DataRowCnt Step 1
                ssGrid.Col = 7
                ssGrid.Row = i
                If val(ssGrid.Text) = 1 Then
                    COUNTER = COUNTER + 1
                End If
            Next i
            If COUNTER = 0 Then
                vseqno = GetSeqno(txtItemType.Text)
                strSQL = " INSERT INTO ITEMTYPEMASTER (ItemTypeCode,ItemTypeseqno,ItemTypeDesc,AccountCode ,Acctsegno,TaxPercentage ,TaxCode,Freeze ,StartingDate,AddUserin,AddDateTime)"
                strSQL = strSQL & " VALUES ( '" & Trim(txtItemType.Text) & "'," & Val(vseqno) & ",'" & Replace(Trim(txtItemDesc.Text), "'", "") & "',"
                strSQL = strSQL & " '',0,0,'','N','" & Format(Now, "dd-MMM-yyyy ") & "',"
                strSQL = strSQL & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy ") & "')"
                Insert(0) = strSQL
                strSQL = " INSERT INTO TAXITEMLINK(WithEffect,ItemSeqno,ItemTypeCode,TaxCode,TaxSeqno,TaxPercentage,AccountCode ,Startingdate) "
                strSQL = strSQL & " VALUES ( '" & Format(Now, "dd-MMM-yyyy ") & "'," & Val(vseqno) & ",'" & Trim(txtItemType.Text) & "',"
                strSQL = strSQL & " '',0,0,'','" & Format(Now, "dd-MMM-yyyy ") & "')"
                ReDim Preserve Insert(Insert.Length)
                Insert(Insert.Length - 1) = strSQL
            End If
            For i = 1 To ssGrid.DataRowCnt Step 1
                ssGrid.Col = 7
                ssGrid.Row = i
                If Val(ssGrid.Text) = 1 Then
                    vseqno = GetSeqno(txtItemType.Text)
                    strSQL = " INSERT INTO ITEMTYPEMASTER (ItemTypeCode,ItemTypeseqno,ItemTypeDesc,AccountCode ,Acctsegno,TaxPercentage ,TaxCode,Freeze ,StartingDate,EndingDate,AddUserin,AddDateTime)"
                    strSQL = strSQL & " VALUES ( '" & Trim(txtItemType.Text) & "'," & Val(vseqno) & ",'" & Replace(Trim(txtItemDesc.Text), "'", "") & "',"
                    ssGrid.Col = 6
                    ssGrid.Row = i
                    vseqno = GetSeqno(ssGrid.Text)
                    strSQL = strSQL & "'" & Replace(Trim(ssGrid.Text), "'", "") & "'," & Val(vseqno) & ","
                    ssGrid.Col = 3
                    ssGrid.Row = i
                    Taxpercent = Split(ssGrid.Text, "%")
                    strSQL = strSQL & "" & Format(Val(Taxpercent(0)), "0.00") & ","
                    ssGrid.Col = 1
                    ssGrid.Row = i
                    strSQL = strSQL & "'" & Trim(CStr(ssGrid.Text)) & "','N',"
                    ssGrid.Col = 4
                    ssGrid.Row = i
                    ssGrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    If Trim(ssGrid.Text) <> "" Then
                        strSQL = strSQL & "'" & Format(DateValue(ssGrid.Text), "dd-MMM-yyyy") & "',"
                    Else
                        strSQL = strSQL & "NULL,"
                    End If
                    ssGrid.Col = 5
                    ssGrid.Row = i
                    ssGrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    If Trim(ssGrid.Text) <> "" Then
                        strSQL = strSQL & "'" & Format(DateValue(ssGrid.Text), "dd-MMM-yyyy") & "',"
                    Else
                        strSQL = strSQL & "NULL,"
                    End If
                    strSQL = strSQL & "'" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy ") & "')"
                    Insert(0) = strSQL
                End If
            Next i
            For i = 1 To ssGrid.DataRowCnt Step 1
                ssGrid.Col = 7
                ssGrid.Row = i
                If Val(ssGrid.Text) = 1 Then
                    vseqno = GetSeqno(txtItemType.Text)
                    strSQL = "INSERT INTO TAXITEMLINK(WithEffect,ItemSeqno,ItemTypeCode,TaxCode,TaxSeqno,TaxPercentage,AccountCode ,Startingdate,EndingDate) "
                    ssGrid.Col = 4
                    ssGrid.Row = i
                    strSQL = strSQL & " VALUES('" & Format(DateValue(ssGrid.Text), "dd-MMM-yyyy") & "',"
                    strSQL = strSQL & " " & Val(vseqno) & ",'" & Trim(CStr(txtItemType.Text)) & "',"
                    ssGrid.Col = 1
                    ssGrid.Row = i
                    vseqno = GetSeqno(ssGrid.Text)
                    strSQL = strSQL & "'" & Trim(CStr(ssGrid.Text)) & "'," & Val(vseqno) & ","
                    ssGrid.Col = 3
                    ssGrid.Row = i
                    Taxpercent = Split(ssGrid.Text, "%")
                    strSQL = strSQL & "" & Format(Val(Taxpercent(0)), "0.00") & ","
                    ssGrid.Col = 6
                    ssGrid.Row = i
                    strSQL = strSQL & "'" & Replace(Trim(ssGrid.Text), "'", "") & "',"
                    ssGrid.Col = 4
                    ssGrid.Row = i
                    ssGrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    If Trim(ssGrid.Text) <> "" Then
                        strSQL = strSQL & "'" & Format(DateValue(ssGrid.Text), "dd-MMM-yyyy") & "',"
                    Else
                        strSQL = strSQL & "NULL,"
                    End If
                    If Trim(ssGrid.Text) <> "" Then
                        strSQL = strSQL & "'" & Format(DateValue(ssGrid.Text), "dd-MMM-yyyy") & "')"
                    Else
                        strSQL = strSQL & "NULL"
                    End If
                    ReDim Preserve Insert(Insert.Length)
                    Insert(Insert.Length - 1) = strSQL
                End If
            Next i
            strSQL = "UPDATE ITEMTYPEMASTER SET TYPEOFTAX = A.typeoftax FROM ACCOUNTSTAXMASTER A,ITEMTYPEMASTER I WHERE A.TAXCODE = I.TAXCODE AND ISNULL(I.TYPEOFTAX,'') = ''"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = strSQL

            gconnection.MoreTrans(Insert)
            Me.CmdClear_Click(sender, e)
        ElseIf Mid(Trim(CmdAdd.Text), 1, 1) = "U" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.CmdAdd.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    boolchk = False
                    Exit Sub
                End If
            End If
            For i = 1 To ssGrid.DataRowCnt Step 1
                ssGrid.Col = 7
                ssGrid.Row = i
                If Val(ssGrid.Text) = 1 Then
                    COUNTER = COUNTER + 1
                End If
            Next i
            If COUNTER = 0 Then
                vseqno = GetSeqno(txtItemType.Text)
                strSQL = " UPDATE ITEMTYPEMASTER SET ItemTypeDesc = '" & Replace(Trim(txtItemDesc.Text), "'", "") & "',AccountCode= '' ,Acctsegno =0 ,"
                strSQL = strSQL & " TaxPercentage =0 ,TaxCode ='',StartingDate= '" & Format(Now, "dd-MMM-yyyy ") & "',"
                strSQL = strSQL & " AddUserin='" & Trim(gUsername) & "',AddDateTime= '" & Format(Now, "dd-MMM-yyyy ") & "'"
                strSQL = strSQL & " WHERE ITEMTYPECODE = '" & Trim(txtItemType.Text) & "'"
                Update(0) = strSQL
                strSQL = " UPDATE TAXITEMLINK SET WithEffect ='" & Format(Now, "dd-MMM-yyyy ") & "',TaxCode = '',TaxSeqno =0,TaxPercentage=0, "
                strSQL = strSQL & " AccountCode ='' ,Startingdate = '" & Format(Now, "dd-MMM-yyyy ") & "'"
                strSQL = strSQL & " WHERE ITEMTYPECODE = '" & Trim(txtItemType.Text) & "'"
                ReDim Preserve Update(Update.Length)
                Update(Update.Length - 1) = strSQL
            End If
            For i = 1 To ssGrid.DataRowCnt Step 1
                ssGrid.Col = 7
                ssGrid.Row = i
                If Val(ssGrid.Text) = 1 Then
                    strSQL = " UPDATE ITEMTYPEMASTER SET ItemTypedesc='" & Replace(Trim(CStr(txtItemDesc.Text)), "'", "") & "',"
                    ssGrid.Col = 6
                    ssGrid.Row = i
                    vseqno = GetSeqno(ssGrid.Text)
                    strSQL = strSQL & " Accountcode = '" & Replace(Trim(ssGrid.Text), "'", "") & "',Acctsegno = " & Val(vseqno) & ","
                    ssGrid.Col = 3
                    ssGrid.Row = i
                    Taxpercent = Split(ssGrid.Text, "%")
                    strSQL = strSQL & " TaxPercentage = " & Format(Val(Taxpercent(0)), "0.00") & ","
                    ssGrid.Col = 1
                    ssGrid.Row = i
                    strSQL = strSQL & " TaxCode = '" & Trim(CStr(ssGrid.Text)) & "',Freeze = 'N',"
                    ssGrid.Col = 4
                    ssGrid.Row = i
                    ssGrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    If Trim(ssGrid.Text) <> "" Then
                        strSQL = strSQL & " StartingDate = '" & Format(DateValue(ssGrid.Text), "dd-MMM-yyyy") & "',"
                    End If
                    ssGrid.Col = 5
                    ssGrid.Row = i
                    ssGrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    If Trim(ssGrid.Text) <> "" Then
                        strSQL = strSQL & " EndingDate = '" & Format(DateValue(ssGrid.Text), "dd-MMM-yyyy") & "',"
                    End If
                    strSQL = strSQL & " AddUserin = '" & Trim(gUsername) & "' ,AddDateTime = '" & Format(Now, "dd-MMM-yyyy ") & "' "
                    strSQL = strSQL & " WHERE ITEMTYPECODE = '" & Trim(txtItemType.Text) & "'"
                    Update(0) = strSQL
                End If
            Next i
            For i = 1 To ssGrid.DataRowCnt Step 1
                ssGrid.Col = 7
                ssGrid.Row = i
                If Val(ssGrid.Text) = 1 Then
                    strSQL = "UPDATE TAXITEMLINK SET "
                    ssGrid.Col = 4
                    ssGrid.Row = i
                    If Trim(ssGrid.Text) <> "" Then
                        strSQL = strSQL & " WithEffect = '" & Format(DateValue(ssGrid.Text), "dd-MMM-yyyy") & "',"
                    End If
                    ssGrid.Col = 1
                    ssGrid.Row = i
                    vseqno = GetSeqno(ssGrid.Text)
                    strSQL = strSQL & " TaxCode = '" & Trim(CStr(ssGrid.Text)) & "',TaxSeqno = " & Val(vseqno) & ","
                    ssGrid.Col = 3
                    ssGrid.Row = i
                    Taxpercent = Split(ssGrid.Text, "%")
                    strSQL = strSQL & " TaxPercentage = " & Format(Val(Taxpercent(0)), "0.00") & ","
                    ssGrid.Col = 6
                    ssGrid.Row = i
                    strSQL = strSQL & " AccountCode = '" & Replace(Trim(ssGrid.Text), "'", "") & "',"
                    ssGrid.Col = 4
                    ssGrid.Row = i
                    ssGrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    If Trim(ssGrid.Text) <> "" Then
                        strSQL = strSQL & " Startingdate = '" & Format(DateValue(ssGrid.Text), "dd-MMM-yyyy") & "',"
                    End If
                    ssGrid.Col = 5
                    ssGrid.Row = i
                    ssGrid.CellType = FPSpreadADO.CellTypeConstants.CellTypeDate
                    If Trim(ssGrid.Text) <> "" Then
                        strSQL = strSQL & " EndingDate = '" & Format(DateValue(ssGrid.Text), "dd-MMM-yyyy") & "'"
                    Else
                        strSQL = strSQL & " EndingDate = NULL"
                    End If
                    strSQL = strSQL & " WHERE ITEMTYPECODE = '" & Trim(txtItemType.Text) & "'"
                    ReDim Preserve Update(Update.Length)
                    Update(Update.Length - 1) = strSQL
                End If
            Next i
            strSQL = "UPDATE ITEMTYPEMASTER SET TYPEOFTAX = A.typeoftax FROM ACCOUNTSTAXMASTER A,ITEMTYPEMASTER I WHERE A.TAXCODE = I.TAXCODE AND ISNULL(I.TYPEOFTAX,'') = ''"
            ReDim Preserve Update(Update.Length)
            Update(Update.Length - 1) = strSQL

            gconnection.MoreTrans(Update)
            Me.CmdClear_Click(sender, e)
            CmdAdd.Text = "Add [F7]"
        End If
    End Sub
    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            sqlstring = "UPDATE  ITEMTYPEMASTER "
            sqlstring = sqlstring & " SET Freeze= 'Y',AddUserin='" & Trim(gUsername) & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE ItemTypeCode = '" & Trim(txtItemType.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "ITEMTYPEMASTER")
            Me.CmdClear_Click(sender, e)
            CmdAdd.Text = "Add [F7]"
        Else
            sqlstring = "UPDATE  ITEMTYPEMASTER "
            sqlstring = sqlstring & " SET Freeze= 'N',AddUserin='" & Trim(gUsername) & " ', AddDateTime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE ItemTypeCode = '" & Trim(txtItemType.Text) & "'"
            gconnection.dataOperation(4, sqlstring, "ITEMTYPEMASTER")
            Me.CmdClear_Click(sender, e)
            CmdAdd.Text = "Add [F7]"
        End If
    End Sub
    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New CrptITEMTYPEMASTER
        STR = "SELECT * FROM par_ITEMTYPEMASTER"
        Viewer.ssql = STR
        Viewer.Report = r
        Viewer.TableName = "par_ITEMTYPEMASTER"
        Dim textobj1 As TextObject
        textobj1 = r.ReportDefinition.ReportObjects("Text6")
        textobj1.Text = MyCompanyName
        Dim TXTOBJ2 As TextObject
        TXTOBJ2 = r.ReportDefinition.ReportObjects("Text11")
        TXTOBJ2.Text = gUsername
        Viewer.Show()
        '''*****************************************  View  And Print Operation *************************************'''
        'Dim FrReport As New ReportDesigner
        'tables = " FROM ITEMTYPEMASTER"
        'Gheader = "ITEMTYPE MASTER"
        'FrReport.SsGridReport.SetText(2, 1, "ITEMTYPECODE")
        'FrReport.SsGridReport.SetText(3, 1, 10)
        'FrReport.SsGridReport.SetText(2, 2, "ITEMTYPEDESC")
        'FrReport.SsGridReport.SetText(3, 2, 35)
        'FrReport.SsGridReport.SetText(2, 3, "ACCOUNTCODE")
        'FrReport.SsGridReport.SetText(3, 3, 15)
        'FrReport.SsGridReport.SetText(2, 4, "TAXCODE")
        'FrReport.SsGridReport.SetText(3, 4, 15)
        'FrReport.SsGridReport.SetText(2, 5, "TAXPERCENTAGE")
        'FrReport.SsGridReport.SetText(3, 5, 10)
        'FrReport.SsGridReport.SetText(2, 6, "STARTINGDATE")
        'FrReport.SsGridReport.SetText(3, 6, 15)
        'FrReport.SsGridReport.SetText(2, 7, "ENDINGDATE")
        'FrReport.SsGridReport.SetText(3, 7, 15)
        'FrReport.SsGridReport.SetText(2, 8, "FREEZE")
        'FrReport.SsGridReport.SetText(3, 8, 5)
        'FrReport.Show()
    End Sub
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
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
                    MessageBox.Show(" Multiple TAX CODE can't be selected ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    ssGrid.SetActiveCell(7, I)
                    Exit Sub
                End If
            End If
        Next
        boolchk = True
    End Sub

    Private Sub cmdItemHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdItemHelp.Click
        Dim vform As New ListOperattion1
        gSQLString = "SELECT ISNULL(ITEMTYPECODE,'') AS ITEMTYPECODE,ISNULL(ITEMTYPEDESC,'') AS ITEMTYPEDESC FROM ItemTypemaster"
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "ITEMTYPECODE,ITEMTYPEDESC"
        vform.vFormatstring = "                ITEMTYPECODE             |                ITEMTYPE DESCRIPTION                             "
        vform.vCaption = "ITEM TYPE MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txtItemType.Text = Trim(vform.keyfield & "")
            Call txtItemtype_Validated(txtItemType, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub ItemType_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        itemtypebool = False
    End Sub
    Private Sub GridLocking()
        Dim Row, Col As Integer
        ssGrid.Col = 4
        ssGrid.Row = ssGrid.ActiveRow
        For Row = 1 To 100
            For Col = 4 To 5
                ssGrid.Row = Row
                ssGrid.Col = Col
                ssGrid.Lock = True
            Next
        Next
        ssGrid.Row = 1
        For Col = 4 To 5
            ssGrid.Col = Col
            ssGrid.Lock = False
        Next
    End Sub

    Private Sub ssGrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssGrid.KeyDownEvent
        Dim Sqlstring As String
        Dim i, j As Integer
        Try
            If e.keyCode = Keys.Enter Then
                i = ssGrid.ActiveRow
                If ssGrid.ActiveCol = 1 Then
                    ssGrid.Col = 1
                    ssGrid.Row = i
                    If Trim(ssGrid.Text) = "" Then
                        ssGrid.SetActiveCell(0, i)
                        Exit Sub
                    ElseIf Trim(ssGrid.Text) <> "" Then
                        ssGrid.SetActiveCell(3, i)
                        Exit Sub
                    End If
                ElseIf ssGrid.ActiveCol = 2 Then
                    ssGrid.Col = 2
                    ssGrid.Row = i
                    If Trim(ssGrid.Text) = "" Then
                        ssGrid.SetActiveCell(1, i)
                        Exit Sub
                    Else
                        ssGrid.SetActiveCell(3, i)
                        Exit Sub
                    End If
                ElseIf ssGrid.ActiveCol = 3 Then
                    ssGrid.Col = 3
                    ssGrid.Row = i
                    If Trim(ssGrid.Text) = "" Then
                        ssGrid.SetActiveCell(2, i)
                        Exit Sub
                    ElseIf Trim(ssGrid.Text) <> "" Then
                        ssGrid.SetActiveCell(3, i)
                        Exit Sub
                    End If
                ElseIf ssGrid.ActiveCol = 4 Then
                    ssGrid.Col = 4
                    ssGrid.Row = i
                    If Trim(ssGrid.Text) = "" Then
                        ssGrid.SetActiveCell(3, i)
                        Exit Sub
                    ElseIf Trim(ssGrid.Text) <> "" Then
                        ssGrid.SetActiveCell(4, i)
                        Exit Sub
                    End If
                ElseIf ssGrid.ActiveCol = 5 Then
                    ssGrid.Col = 5
                    ssGrid.Row = i
                    If Trim(ssGrid.Text) = "" Then
                        ssGrid.SetActiveCell(4, i)
                        Exit Sub
                    ElseIf Trim(ssGrid.Text) <> "" Then
                        ssGrid.SetActiveCell(3, i + 1)
                        ssGrid.Col = 7
                        ssGrid.Text = True
                    End If
                ElseIf ssGrid.ActiveCol = 7 Then
                    ssGrid.Col = 7
                    ssGrid.Row = i
                    If Trim(ssGrid.Text) = True Then
                        ssGrid.SetActiveCell(3, i + 1)
                        Exit Sub
                    ElseIf Trim(ssGrid.Text) <> "" Then
                        ssGrid.SetActiveCell(3, i + 1)
                        ssGrid.Col = 4
                        ssGrid.Text = ""
                        ssGrid.Col = 5
                        ssGrid.Text = ""
                    End If
                End If
            ElseIf e.keyCode = Keys.F3 Then
                ssGrid.Row = ssGrid.ActiveRow
                ssGrid.ClearRange(1, ssGrid.ActiveRow, 15, ssGrid.ActiveRow, True)
                ssGrid.DeleteRows(ssGrid.ActiveRow, 1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub ssGrid_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssGrid.LeaveCell
        Dim Sqlstring As String
        Dim i, j As Integer
        i = ssGrid.ActiveRow
        If ssGrid.ActiveCol = 1 Then
            ssGrid.Col = 1
            ssGrid.Row = i
            If Trim(ssGrid.Text) = "" Then
                ssGrid.SetActiveCell(1, i)
                Exit Sub
            ElseIf Trim(ssGrid.Text) <> "" Then
                ssGrid.SetActiveCell(4, i)
                Exit Sub
            End If
        ElseIf ssGrid.ActiveCol = 2 Then
            ssGrid.Col = 2
            ssGrid.Row = i
            If Trim(ssGrid.Text) = "" Then
                ssGrid.SetActiveCell(2, i)
                Exit Sub
            Else
                ssGrid.SetActiveCell(4, i)
                Exit Sub
            End If
        ElseIf ssGrid.ActiveCol = 3 Then
            ssGrid.Col = 3
            ssGrid.Row = i
            If Trim(ssGrid.Text) = "" Then
                ssGrid.SetActiveCell(3, i)
                Exit Sub
            ElseIf Trim(ssGrid.Text) <> "" Then
                ssGrid.SetActiveCell(4, i)
                Exit Sub
            End If
        ElseIf ssGrid.ActiveCol = 7 Then
            ssGrid.Col = 7
            ssGrid.Row = i
            If Trim(ssGrid.Text) = True Then
                ssGrid.SetActiveCell(4, i + 1)
                Exit Sub
            ElseIf Trim(ssGrid.Text) <> "" Then
                ssGrid.SetActiveCell(4, i + 1)
                ssGrid.Col = 4
                ssGrid.Text = ""
                ssGrid.Col = 5
                ssGrid.Text = ""
            End If
        End If
    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "ITEMTYPEMASTER"
        sqlstring = "SELECT * FROM ITEMTYPEMASTER"
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class