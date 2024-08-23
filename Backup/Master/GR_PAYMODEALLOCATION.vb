Imports System.IO
Imports System.Data.SqlClient
Public Class GR_PAYMODEALLOCATION
    Inherits System.Windows.Forms.Form
    Dim sqlstring As String
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbl_GroupList As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents SSGRID As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LAB_LOCDESC As System.Windows.Forms.Label
    Friend WithEvents CMB_LOC As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GR_PAYMODEALLOCATION))
        Me.Label5 = New System.Windows.Forms.Label
        Me.lbl_GroupList = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.frmbut = New System.Windows.Forms.GroupBox
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.Cmd_Print = New System.Windows.Forms.Button
        Me.Cmd_View = New System.Windows.Forms.Button
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.SSGRID = New AxFPSpreadADO.AxfpSpread
        Me.CMB_LOC = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LAB_LOCDESC = New System.Windows.Forms.Label
        Me.frmbut.SuspendLayout()
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(104, 440)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(423, 18)
        Me.Label5.TabIndex = 566
        Me.Label5.Text = "Press F4 to select all / Press ENTER key to navigate"
        '
        'lbl_GroupList
        '
        Me.lbl_GroupList.BackColor = System.Drawing.Color.Transparent
        Me.lbl_GroupList.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_GroupList.ForeColor = System.Drawing.Color.Black
        Me.lbl_GroupList.Location = New System.Drawing.Point(16, 16)
        Me.lbl_GroupList.Name = "lbl_GroupList"
        Me.lbl_GroupList.Size = New System.Drawing.Size(584, 32)
        Me.lbl_GroupList.TabIndex = 564
        Me.lbl_GroupList.Text = "PAYMENT MODE ALLOCATION  MASTER"
        Me.lbl_GroupList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.Cmd_Exit)
        Me.frmbut.Controls.Add(Me.Cmd_Print)
        Me.frmbut.Controls.Add(Me.Cmd_View)
        Me.frmbut.Controls.Add(Me.Cmd_Add)
        Me.frmbut.Controls.Add(Me.Cmd_Clear)
        Me.frmbut.Location = New System.Drawing.Point(88, 376)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(448, 56)
        Me.frmbut.TabIndex = 565
        Me.frmbut.TabStop = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.Location = New System.Drawing.Point(320, 16)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 443
        Me.Cmd_Exit.Text = "Exit[F11]"
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Print.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.ForeColor = System.Drawing.Color.White
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.Location = New System.Drawing.Point(360, 56)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Print.TabIndex = 445
        Me.Cmd_Print.Text = " Print [F10]"
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(240, 56)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 442
        Me.Cmd_View.Text = " View[F9]"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.Location = New System.Drawing.Point(152, 16)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add.TabIndex = 448
        Me.Cmd_Add.Text = "Add [F7]"
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
        Me.Cmd_Clear.TabIndex = 441
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'SSGRID
        '
        Me.SSGRID.DataSource = Nothing
        Me.SSGRID.Location = New System.Drawing.Point(136, 120)
        Me.SSGRID.Name = "SSGRID"
        Me.SSGRID.OcxState = CType(resources.GetObject("SSGRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID.Size = New System.Drawing.Size(352, 240)
        Me.SSGRID.TabIndex = 573
        '
        'CMB_LOC
        '
        Me.CMB_LOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMB_LOC.Items.AddRange(New Object() {"PARTY"})
        Me.CMB_LOC.Location = New System.Drawing.Point(216, 72)
        Me.CMB_LOC.Name = "CMB_LOC"
        Me.CMB_LOC.Size = New System.Drawing.Size(136, 26)
        Me.CMB_LOC.TabIndex = 574
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(112, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 575
        Me.Label1.Text = "LOCATION"
        Me.Label1.Visible = False
        '
        'LAB_LOCDESC
        '
        Me.LAB_LOCDESC.BackColor = System.Drawing.Color.Transparent
        Me.LAB_LOCDESC.Location = New System.Drawing.Point(368, 72)
        Me.LAB_LOCDESC.Name = "LAB_LOCDESC"
        Me.LAB_LOCDESC.Size = New System.Drawing.Size(232, 23)
        Me.LAB_LOCDESC.TabIndex = 576
        '
        'GR_PAYMODEALLOCATION
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(624, 468)
        Me.Controls.Add(Me.LAB_LOCDESC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CMB_LOC)
        Me.Controls.Add(Me.SSGRID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbl_GroupList)
        Me.Controls.Add(Me.frmbut)
        Me.Name = "GR_PAYMODEALLOCATION"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GR_PAYMODEALLOCATION"
        Me.frmbut.ResumeLayout(False)
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub GR_PAYMODEALLOCATION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Me.Cmd_View.Enabled = False
        Me.Cmd_Print.Enabled = False
        Me.Cmd_Clear_Click(sender, e)
        SSGRID.Focus()
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        CMB_LOC.Items.Clear()
        SSGRID.ClearRange(1, 1, 2, 500, False)
        Call FILLDET()
        Call FILLGRID()
    End Sub
    Private Sub FILLDET()
        Dim K As Integer
        sqlstring = "SELECT * FROM gr_locationmaster WHERE ISNULL(FREEZE,'')<>'Y'"
        gconnection.getDataSet(sqlstring, "LOC")
        CMB_LOC.Items.Clear()
        If gdataset.Tables("LOC").Rows.Count > 0 Then
            For K = 0 To gdataset.Tables("LOC").Rows.Count - 1
                CMB_LOC.Items.Add(gdataset.Tables("LOC").Rows(K).Item("LOCCODE"))
            Next
        End If
    End Sub
    Private Sub FILLGRID()
        Dim I As Integer
        SSGRID.ClearRange(1, 1, 2, 500, False)
        sqlstring = " SELECT PAYMENTMODE,ALLOCATE FROM GR_PAYMODEMASTER WHERE LOCCODE='" & CMB_LOC.Text & "' UNION ALL SELECT PaymentCode,'NO' AS  ALLOCATE FROM PAYMENTMODEMASTER WHERE  PAYMENTCODE NOT IN(SELECT PAYMENTMODE FROM GR_PAYMODEMASTER WHERE LOCCODE='" & CMB_LOC.Text & "') "
        gconnection.getDataSet(sqlstring, "PAY")
        If gdataset.Tables("PAY").Rows.Count > 0 Then
            For I = 0 To gdataset.Tables("PAY").Rows.Count - 1
                With SSGRID
                    .Row = I + 1
                    .Col = 1
                    .Text = Trim(gdataset.Tables("PAY").Rows(I).Item("PAYMENTMODE"))
                    .Col = 2
                    .Text = Trim(gdataset.Tables("PAY").Rows(I).Item("ALLOCATE"))
                End With
            Next
            SSGRID.Visible = True
            SSGRID.MaxRows = I
        Else
            SSGRID.Visible = False
        End If
        'If I + 1 > 0 Then

        'Else

        'End If

    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='GR_REG' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_View.Enabled = False
        Me.Cmd_Print.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_View.Enabled = True
                    Me.Cmd_Print.Enabled = True
                    Exit Sub
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.Cmd_Print.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim I As Integer
        Dim PA, AL, strSQL As String
        Dim INSERT(0) As String
        If Me.CMB_LOC.Text <> "" Then
        Else
            MsgBox("LOCATION CANNOT BE BLANK")
            Exit Sub
        End If
        If SSGRID.DataRowCnt > 0 Then
            strSQL = "DELETE FROM GR_PAYMODEMASTER WHERE LOCCODE='" & Me.CMB_LOC.Text & "'"
            ReDim Preserve INSERT(INSERT.Length)
            INSERT(INSERT.Length - 1) = strSQL
            For I = 1 To SSGRID.DataRowCnt
                With SSGRID
                    .Col = 2
                    .Row = I
                    If Trim(.Text) = "YES" Then
                        strSQL = " INSERT INTO GR_PAYMODEMASTER (LOCCODE,PAYMENTMODE,ALLOCATE,adduser,adddatetime,FREEZE )"
                        'card type
                        strSQL = strSQL & " VALUES ('" & Trim(CMB_LOC.Text) & "',"
                        'subcode
                        .Col = 1
                        strSQL = strSQL & " '" & Trim(.Text) & "',"
                        'subtype
                        .Col = 2
                        strSQL = strSQL & "'" & Trim(.Text) & "',"
                        'adduser
                        strSQL = strSQL & "'" & Trim(gUsername) & "',"
                        'adddatetime
                        strSQL = strSQL & "'" & Format(Now, "dd-MMM-yyyy hh:mm") & "',"
                        'freeze
                        strSQL = strSQL & " 'N')"
                        'updateuser
                        'strSQL = strSQL & "'" & Trim(gUsername) & "',"
                        ''updatetime
                        'strSQL = strSQL & "'" & Format(Now, "dd-MMM-yyyy hh:mm") & "')"
                        ReDim Preserve INSERT(INSERT.Length)
                        INSERT(INSERT.Length - 1) = strSQL
                    End If
                End With
            Next I
            gconnection.MoreTrans(INSERT)

        End If
        Call Me.Cmd_Clear_Click(sender, e)
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub SSGRID_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSGRID.Advance

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMB_LOC.SelectedIndexChanged
        sqlstring = " SELECT * FROM gr_locationmaster WHERE LOCCODE='" & CMB_LOC.Text & "'"
        gconnection.getDataSet(sqlstring, "LOC1")
        If gdataset.Tables("LOC1").Rows.Count > 0 Then
            Me.LAB_LOCDESC.Text = gdataset.Tables("LOC1").Rows(0).Item("locdesc")
        End If
        Call Me.FILLGRID()
    End Sub

    Private Sub LAB_LOCDESC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LAB_LOCDESC.Click

    End Sub
End Class
