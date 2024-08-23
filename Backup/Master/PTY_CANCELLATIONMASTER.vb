Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Public Class PTY_CANCELLATIONMASTER
    Inherits System.Windows.Forms.Form
    Dim boolchk, datechk As Boolean
    Dim sqlstring, str, strF As String
    Dim vSeqNo As Double
    Dim vconn As New GlobalClass
    Dim gconnection As New GlobalClass
    Dim Dtfrom_gbl, DtTo_gbl As Date
    Dim First_Total, Second_Total, d As Double
    Dim myconn As SqlConnection
    Dim dr As DataRow
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim FORMLOADED As Boolean
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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Print As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_View As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Public WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents SSGRID As AxFPSpreadADO.AxfpSpread
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Frame2 As System.Windows.Forms.GroupBox
    Friend WithEvents EffFrom1 As System.Windows.Forms.DateTimePicker
    Public WithEvents LBL_EFFTO As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MskTo As System.Windows.Forms.TextBox
    Friend WithEvents mskFrom As System.Windows.Forms.TextBox
    Friend WithEvents CmdTaxSetUpHp As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Grp_Print As System.Windows.Forms.GroupBox
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMD_WINDOWS As System.Windows.Forms.Button
    Friend WithEvents CMD_DOS As System.Windows.Forms.Button
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PTY_CANCELLATIONMASTER))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdexport = New System.Windows.Forms.Button
        Me.Cmd_Clear = New System.Windows.Forms.Button
        Me.Cmd_Print = New System.Windows.Forms.Button
        Me.Cmd_Exit = New System.Windows.Forms.Button
        Me.Cmd_View = New System.Windows.Forms.Button
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.SSGRID = New AxFPSpreadADO.AxfpSpread
        Me.Label9 = New System.Windows.Forms.Label
        Me.Frame2 = New System.Windows.Forms.GroupBox
        Me.EffFrom1 = New System.Windows.Forms.DateTimePicker
        Me.LBL_EFFTO = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.MskTo = New System.Windows.Forms.TextBox
        Me.mskFrom = New System.Windows.Forms.TextBox
        Me.CmdTaxSetUpHp = New System.Windows.Forms.Button
        Me.Grp_Print = New System.Windows.Forms.GroupBox
        Me.CMDEXIT = New System.Windows.Forms.Button
        Me.CMD_WINDOWS = New System.Windows.Forms.Button
        Me.CMD_DOS = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Frame2.SuspendLayout()
        Me.Grp_Print.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmdexport)
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear)
        Me.GroupBox2.Controls.Add(Me.Cmd_Print)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Controls.Add(Me.Cmd_View)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add)
        Me.GroupBox2.Location = New System.Drawing.Point(96, 416)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(760, 56)
        Me.GroupBox2.TabIndex = 526
        Me.GroupBox2.TabStop = False
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdexport.BackgroundImage = CType(resources.GetObject("cmdexport.BackgroundImage"), System.Drawing.Image)
        Me.cmdexport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexport.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.Color.White
        Me.cmdexport.Location = New System.Drawing.Point(512, 16)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(104, 32)
        Me.cmdexport.TabIndex = 545
        Me.cmdexport.Text = "Report[F12]"
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.Location = New System.Drawing.Point(16, 16)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear.TabIndex = 544
        Me.Cmd_Clear.Text = "Clear[F6]"
        '
        'Cmd_Print
        '
        Me.Cmd_Print.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Print.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print.ForeColor = System.Drawing.Color.White
        Me.Cmd_Print.Image = CType(resources.GetObject("Cmd_Print.Image"), System.Drawing.Image)
        Me.Cmd_Print.Location = New System.Drawing.Point(384, 16)
        Me.Cmd_Print.Name = "Cmd_Print"
        Me.Cmd_Print.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Print.TabIndex = 7
        Me.Cmd_Print.Text = "Print[F10]"
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.Location = New System.Drawing.Point(632, 16)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 8
        Me.Cmd_Exit.Text = "Exit[F11]"
        '
        'Cmd_View
        '
        Me.Cmd_View.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_View.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View.ForeColor = System.Drawing.Color.White
        Me.Cmd_View.Image = CType(resources.GetObject("Cmd_View.Image"), System.Drawing.Image)
        Me.Cmd_View.Location = New System.Drawing.Point(264, 16)
        Me.Cmd_View.Name = "Cmd_View"
        Me.Cmd_View.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View.TabIndex = 6
        Me.Cmd_View.Text = " View[F9]"
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.Location = New System.Drawing.Point(144, 16)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add.TabIndex = 4
        Me.Cmd_Add.Text = "Add[F7]"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(272, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(322, 31)
        Me.Label16.TabIndex = 536
        Me.Label16.Text = "CANCELLATION MASTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SSGRID
        '
        Me.SSGRID.DataSource = Nothing
        Me.SSGRID.Location = New System.Drawing.Point(8, 160)
        Me.SSGRID.Name = "SSGRID"
        Me.SSGRID.OcxState = CType(resources.GetObject("SSGRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID.Size = New System.Drawing.Size(952, 200)
        Me.SSGRID.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(152, 376)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label9.Size = New System.Drawing.Size(112, 24)
        Me.Label9.TabIndex = 539
        Me.Label9.Text = "F3 - Delete Row"
        '
        'Frame2
        '
        Me.Frame2.BackColor = System.Drawing.Color.Transparent
        Me.Frame2.Controls.Add(Me.EffFrom1)
        Me.Frame2.Controls.Add(Me.LBL_EFFTO)
        Me.Frame2.Controls.Add(Me.Label1)
        Me.Frame2.Controls.Add(Me.MskTo)
        Me.Frame2.Controls.Add(Me.mskFrom)
        Me.Frame2.Controls.Add(Me.CmdTaxSetUpHp)
        Me.Frame2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Frame2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame2.Location = New System.Drawing.Point(248, 72)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(280, 80)
        Me.Frame2.TabIndex = 540
        Me.Frame2.TabStop = False
        '
        'EffFrom1
        '
        Me.EffFrom1.CustomFormat = "dd/MM/yyyy"
        Me.EffFrom1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EffFrom1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.EffFrom1.Location = New System.Drawing.Point(232, 9)
        Me.EffFrom1.Name = "EffFrom1"
        Me.EffFrom1.Size = New System.Drawing.Size(20, 26)
        Me.EffFrom1.TabIndex = 434
        Me.EffFrom1.Value = New Date(2009, 1, 6, 15, 11, 31, 781)
        '
        'LBL_EFFTO
        '
        Me.LBL_EFFTO.AutoSize = True
        Me.LBL_EFFTO.BackColor = System.Drawing.Color.Transparent
        Me.LBL_EFFTO.Cursor = System.Windows.Forms.Cursors.Default
        Me.LBL_EFFTO.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LBL_EFFTO.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LBL_EFFTO.Location = New System.Drawing.Point(8, 40)
        Me.LBL_EFFTO.Name = "LBL_EFFTO"
        Me.LBL_EFFTO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LBL_EFFTO.Size = New System.Drawing.Size(101, 22)
        Me.LBL_EFFTO.TabIndex = 26
        Me.LBL_EFFTO.Text = "Effective To :"
        Me.LBL_EFFTO.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(9, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(125, 22)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Effective From  :"
        '
        'MskTo
        '
        Me.MskTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MskTo.Location = New System.Drawing.Point(136, 40)
        Me.MskTo.Name = "MskTo"
        Me.MskTo.ReadOnly = True
        Me.MskTo.Size = New System.Drawing.Size(96, 26)
        Me.MskTo.TabIndex = 433
        Me.MskTo.Text = "__/__/____"
        Me.MskTo.Visible = False
        '
        'mskFrom
        '
        Me.mskFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mskFrom.Location = New System.Drawing.Point(136, 10)
        Me.mskFrom.Name = "mskFrom"
        Me.mskFrom.ReadOnly = True
        Me.mskFrom.Size = New System.Drawing.Size(96, 26)
        Me.mskFrom.TabIndex = 431
        Me.mskFrom.Text = "__/__/____"
        '
        'CmdTaxSetUpHp
        '
        Me.CmdTaxSetUpHp.BackgroundImage = CType(resources.GetObject("CmdTaxSetUpHp.BackgroundImage"), System.Drawing.Image)
        Me.CmdTaxSetUpHp.Image = CType(resources.GetObject("CmdTaxSetUpHp.Image"), System.Drawing.Image)
        Me.CmdTaxSetUpHp.Location = New System.Drawing.Point(248, 8)
        Me.CmdTaxSetUpHp.Name = "CmdTaxSetUpHp"
        Me.CmdTaxSetUpHp.Size = New System.Drawing.Size(23, 26)
        Me.CmdTaxSetUpHp.TabIndex = 1
        '
        'Grp_Print
        '
        Me.Grp_Print.BackColor = System.Drawing.Color.Transparent
        Me.Grp_Print.Controls.Add(Me.CMDEXIT)
        Me.Grp_Print.Controls.Add(Me.CMD_WINDOWS)
        Me.Grp_Print.Controls.Add(Me.CMD_DOS)
        Me.Grp_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Print.Location = New System.Drawing.Point(280, 360)
        Me.Grp_Print.Name = "Grp_Print"
        Me.Grp_Print.Size = New System.Drawing.Size(368, 56)
        Me.Grp_Print.TabIndex = 657
        Me.Grp_Print.TabStop = False
        Me.Grp_Print.Visible = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.Location = New System.Drawing.Point(248, 16)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(96, 32)
        Me.CMDEXIT.TabIndex = 2
        Me.CMDEXIT.Text = "EXIT"
        '
        'CMD_WINDOWS
        '
        Me.CMD_WINDOWS.BackColor = System.Drawing.Color.Transparent
        Me.CMD_WINDOWS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_WINDOWS.Location = New System.Drawing.Point(136, 16)
        Me.CMD_WINDOWS.Name = "CMD_WINDOWS"
        Me.CMD_WINDOWS.Size = New System.Drawing.Size(96, 32)
        Me.CMD_WINDOWS.TabIndex = 1
        Me.CMD_WINDOWS.Text = "WINDOWS"
        '
        'CMD_DOS
        '
        Me.CMD_DOS.BackColor = System.Drawing.Color.Transparent
        Me.CMD_DOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_DOS.Location = New System.Drawing.Point(24, 16)
        Me.CMD_DOS.Name = "CMD_DOS"
        Me.CMD_DOS.Size = New System.Drawing.Size(96, 32)
        Me.CMD_DOS.TabIndex = 0
        Me.CMD_DOS.Text = "DOS"
        '
        'PTY_CANCELLATIONMASTER
        '
        Me.AutoScale = False
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.Controls.Add(Me.Grp_Print)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.SSGRID)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PTY_CANCELLATIONMASTER"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancellation Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame2.ResumeLayout(False)
        Me.Grp_Print.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub Checkvalidation()
        boolchk = False
        'If DateDiff(DateInterval.Day, Now, EffFrom1.Value) = 0 Then
        '    sqlstring = " Select * From roomcancellations Where CAncelDate='" & Format(CDate(mskFrom.Text), "dd/MMM/yyyy") & "'"
        '    gconnection.getDataSet(sqlstring, "ROOMCANCELLATIONS")
        '    Cmd_Add.Text = "Add[F7]"
        '    If gdataset.Tables("ROOMCANCELLATIONS").Rows.Count > 0 Then
        '        MsgBox("Transaction Already Taken, Cannot Be Modified", MsgBoxStyle.Critical, "CAnnot Be Updated")
        '        boolchk = False
        '        Exit Sub
        '    End If
        'End If
        Dim LOOPINDEX, AMT As Integer
        Dim vcheck, FROMTIME, TOTIME, TYPE As String
        With SSGRID
            For LOOPINDEX = 1 To SSGRID.DataRowCnt
                .Col = 1
                .Row = LOOPINDEX
                FROMTIME = .Text.ToString

                .Col = 2
                .Row = LOOPINDEX
                TOTIME = .Text.ToString

                .Col = 3
                .Row = LOOPINDEX
                TYPE = .Text.ToString

                .Col = 4
                .Row = LOOPINDEX
                AMT = Val(.Text)

                If FROMTIME <> "" Or TOTIME <> "" Or TYPE <> "" Or Val(AMT) <> 0 Then
                    If Trim(FROMTIME) = "" Then
                        MsgBox("FROM TIME IS EMPTY", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If Trim(TOTIME) = "" Then
                        MsgBox("TO TIME IS EMPTY", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If Trim(TYPE) = "" Then
                        MsgBox("AMOUNT / PERCENTAGE CANNOT BE EMPTY", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    If Val(AMT) < 0 Then
                        MsgBox("AMOUNT CANNOT BE ZERO OR EMPTY", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                End If
            Next
        End With
        boolchk = True
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim i, j, fromtime, totime, amount As Integer
        Dim Cancel_Type As String
        Dim insert(0) As String
        If Mid(Cmd_Add.Text, 1, 1) = "A" Then
            Call Checkvalidation()
            If boolchk = False Then Exit Sub
            sqlstring = " Update PARTY_CANCELLATIONMASTER set Book_ToDate='" & Format(DateAdd(DateInterval.Day, -1, CDate(mskFrom.Text)), "dd/MMM/yyyy") & "' where isnull(Book_ToDate,'')='' "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            With SSGRID
                For i = 1 To SSGRID.DataRowCnt
                    sqlstring = "Insert into PARTY_CANCELLATIONMASTER (CancelFrom, CancelTo, CancelType, Cancel_Amt_Per,Cancel_Amt_head,"
                    sqlstring = sqlstring & "FixedAmount,Book_FromDate, Freeze, Adduser, Adddate,CANCELCODE) Values ("
                    SSGRID.Col = 1
                    SSGRID.Row = i
                    fromtime = Val(SSGRID.Text)
                    sqlstring = sqlstring & Format(fromtime, "0.00") & ","
                    SSGRID.Col = 2
                    SSGRID.Row = i
                    totime = Val(SSGRID.Text)
                    sqlstring = sqlstring & Format(totime, "0.00") & " ,'"
                    SSGRID.Col = 3
                    SSGRID.Row = i
                    Cancel_Type = SSGRID.Text
                    sqlstring = sqlstring & Format(Cancel_Type) & "',"

                    SSGRID.Col = 4
                    SSGRID.Row = i
                    amount = Val(SSGRID.Text)
                    sqlstring = sqlstring & Format(amount, "0.00") & " ,"

                    SSGRID.Col = 5
                    SSGRID.Row = i
                    sqlstring = sqlstring & SSGRID.Text & " ,"
                    SSGRID.Col = 6
                    SSGRID.Row = i
                    sqlstring = sqlstring & SSGRID.Text & " ,"
                    sqlstring = sqlstring & " '" & Format(CDate(mskFrom.Text), "dd/MMM/yyyy") & "', "
                    sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "',"
                    sqlstring = sqlstring & " '" & Format(Now(), "dd/MMM/yyyy") & "','"
                    SSGRID.Col = 7
                    SSGRID.Row = i
                    sqlstring = sqlstring & SSGRID.Text & "')"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring
                Next i
            End With
            gconnection.MoreTrans(insert)
            Call Cmd_Clear_Click(sender, e)
        ElseIf Mid(Cmd_Add.Text, 1, 1) = "U" Then
            Call Checkvalidation()
            If boolchk = False Then Exit Sub
            '----------Delete Operation----------------
            '---------Deletion Starts----------
            If First_Total <> Second_Total Then
                'd = DateDiff(DateInterval.Day, Dtfrom_gbl, CDate(mskFrom.Text))
                'If d <= 0 Then
                '    If MsgBox("From Date Range Exists", MsgBoxStyle.YesNo, "CONTINUE FROM CURRENT DATE") = MsgBoxResult.No Then
                '        Exit Sub
                '    End If
                'End If
                sqlstring = " Update PARTY_CANCELLATIONMASTER set Book_ToDate='" & Format(DateAdd(DateInterval.Day, -1, CDate(mskFrom.Text)), "dd/MMM/yyyy") & "' where isnull(Book_ToDate,'')='' "
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
            Else
                d = DateDiff(DateInterval.Day, Dtfrom_gbl, CDate(mskFrom.Text))
                If d < 0 Then
                    MsgBox("From Date Less Then Existing", MsgBoxStyle.Critical, Me.Name)
                    mskFrom.Text = "__/__/____"
                    Exit Sub
                End If
                sqlstring = " Delete From PARTY_CANCELLATIONMASTER where Book_FromDate='" & Format(Dtfrom_gbl, "dd/MMM/yyyy") & "' and isnull(Book_ToDAte,'')=isnull(Book_ToDAte,'')"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
            End If
            '----------Delete Operation Ends----------------
            With SSGRID
                For i = 1 To SSGRID.DataRowCnt
                    sqlstring = "Insert into PARTY_CANCELLATIONMASTER (CancelFrom, CancelTo, CancelType, Cancel_Amt_Per,Cancel_Amt_head,"
                    sqlstring = sqlstring & "FixedAmount,Book_FromDate, Freeze, Adduser, Adddate,CANCELCODE) Values ("
                    SSGRID.Col = 1
                    SSGRID.Row = i
                    fromtime = Val(SSGRID.Text)
                    sqlstring = sqlstring & Format(fromtime, "0.00") & ","
                    SSGRID.Col = 2
                    SSGRID.Row = i
                    totime = Val(SSGRID.Text)
                    sqlstring = sqlstring & Format(totime, "0.00") & " ,'"
                    SSGRID.Col = 3
                    SSGRID.Row = i
                    Cancel_Type = SSGRID.Text
                    sqlstring = sqlstring & Format(Cancel_Type) & "',"

                    SSGRID.Col = 4
                    SSGRID.Row = i
                    amount = Val(SSGRID.Text)
                    sqlstring = sqlstring & Format(amount, "0.00") & " ,"
                    SSGRID.Col = 5
                    SSGRID.Row = i
                    sqlstring = sqlstring & SSGRID.Text & " ,"
                    SSGRID.Col = 6
                    SSGRID.Row = i
                    sqlstring = sqlstring & SSGRID.Text & " ,"
                    sqlstring = sqlstring & " '" & Format(CDate(mskFrom.Text), "dd/MMM/yyyy") & "', "
                    sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "',"
                    sqlstring = sqlstring & " '" & Format(Now(), "dd/MMM/yyyy") & "','"
                    SSGRID.Col = 7
                    SSGRID.Row = i
                    sqlstring = sqlstring & SSGRID.Text & "')"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring
                Next i
            End With
            gconnection.MoreTrans(insert)
            Call Cmd_Clear_Click(sender, e)
        End If
    End Sub
    Private Sub CMD_FROMDATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            SSGRID.Focus()
            SSGRID.SetActiveCell(1, 1)
        End If
    End Sub
    Private Sub CMD_TODATE_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            SSGRID.SetActiveCell(1, 1)
            SSGRID.Focus()
        End If
    End Sub
    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print.Click
        gPrint = True
        Grp_Print.Visible = True
    End Sub
    Private Sub RoomCancellationMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(sender, e)
        ElseIf e.KeyCode = Keys.F7 Then
            If Cmd_Add.Enabled = True Then
                Call Cmd_Add_Click(sender, e)
            End If
        ElseIf e.KeyCode = Keys.F9 Then
            Call Cmd_View_Click(sender, e)
        ElseIf e.KeyCode = Keys.F10 Then
            Call Cmd_Print_Click(sender, e)
        ElseIf e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(sender, e)
        End If
    End Sub
    Private Sub SSGRID_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID.KeyDownEvent
        Dim i, j, totime, fromtime, amt As Integer
        If e.keyCode = Keys.Enter Then
            i = SSGRID.ActiveRow
            If SSGRID.ActiveCol = 1 Then
                SSGRID.Col = 1
                SSGRID.Row = i
                SSGRID.SetActiveCell(2, i)
            ElseIf SSGRID.ActiveCol = 2 Then
                SSGRID.Col = 1
                SSGRID.Row = i
                fromtime = Val(SSGRID.Text)
                If Val(fromtime) <> 0 Then
                    SSGRID.Col = 2
                    SSGRID.Row = i
                    totime = Val(SSGRID.Text)
                    If Val(SSGRID.Text) = 0 Then
                        MsgBox("To Time Should Not Be Empty", MsgBoxStyle.Information)
                        SSGRID.SetActiveCell(2, i)
                    Else
                        SSGRID.Col = 1
                        SSGRID.Row = i
                        fromtime = Val(SSGRID.Text)
                        If totime <= fromtime Then
                            MsgBox("To Time Should Be Greater Than From Time", MsgBoxStyle.Information)
                            SSGRID.Col = 2
                            SSGRID.Row = i
                            SSGRID.Text = ""
                            SSGRID.SetActiveCell(2, i)
                            SSGRID.Focus()
                        Else
                            SSGRID.SetActiveCell(3, i)
                        End If
                    End If
                Else
                    SSGRID.SetActiveCell(3, i)
                End If

            ElseIf SSGRID.ActiveCol = 3 Then
                SSGRID.Col = 1
                SSGRID.Row = i
                fromtime = Val(SSGRID.Text)
                If Val(fromtime) <> 0 Then
                    SSGRID.Col = 3
                    SSGRID.Row = i
                    If Trim(SSGRID.Text) = "" Then
                        MsgBox("Type Should Not Be Empty", MsgBoxStyle.Information)
                        SSGRID.SetActiveCell(3, i)
                    Else
                        SSGRID.SetActiveCell(4, i)
                    End If
                Else
                    SSGRID.SetActiveCell(4, i)
                End If

            ElseIf SSGRID.ActiveCol = 4 Then
                SSGRID.Col = 1
                SSGRID.Row = i
                fromtime = Val(SSGRID.Text)
                If fromtime <> 0 Then
                    SSGRID.Col = 4
                    SSGRID.Row = i
                    If Trim(SSGRID.Text) < "" Then
                        MsgBox("Amount Should Not Be Empty", MsgBoxStyle.Information)
                        SSGRID.SetActiveCell(4, i)
                        SSGRID.Focus()
                    Else
                        SSGRID.Col = 2
                        SSGRID.Row = i
                        totime = Val(SSGRID.Text)
                        SSGRID.Col = 1
                        SSGRID.Row = i + 1
                        'SSGRID.Text = totime + 1
                        SSGRID.Text = totime
                        SSGRID.SetActiveCell(5, i)
                    End If
                    Call GetTotal()
                Else
                    If i = 1 Then
                        SSGRID.Col = 2
                        SSGRID.Row = i
                        totime = Val(SSGRID.Text)
                        SSGRID.Col = 1
                        SSGRID.Row = i + 1
                        'SSGRID.Text = totime + 1
                        SSGRID.Text = totime
                        SSGRID.SetActiveCell(5, i)
                    Else
                        SSGRID.SetActiveCell(5, i - 1)
                    End If
                    Call GetTotal()
                End If
            ElseIf SSGRID.ActiveCol = 5 Then
                SSGRID.Col = 5
                SSGRID.Row = i
                SSGRID.SetActiveCell(6, i)
                SSGRID.Focus()
            ElseIf SSGRID.ActiveCol = 6 Then
                SSGRID.Col = 6
                SSGRID.Row = i
                SSGRID.SetActiveCell(1, i)
                SSGRID.Focus()
            ElseIf SSGRID.ActiveCol = 7 Then
                SSGRID.Col = 6
                SSGRID.Row = i
                SSGRID.SetActiveCell(1, i + 1)
                SSGRID.Focus()
            End If
        End If
        If e.keyCode = Keys.F3 Then
            SSGRID.DeleteRows(SSGRID.ActiveRow, 1)
            If SSGRID.ActiveRow <> 1 Then
                SSGRID.SetActiveCell(4, SSGRID.ActiveRow - 1)
            Else
                SSGRID.Col = 1
                SSGRID.Row = 1
                SSGRID.Text = "0.00"
                SSGRID.SetActiveCell(2, 1)
            End If


        ElseIf e.keyCode = Keys.Tab Then
            If SSGRID.ActiveCol = 1 Then
                SSGRID.SetActiveCell(SSGRID.ActiveCol, i)
            ElseIf SSGRID.ActiveCol = 2 Then
                SSGRID.SetActiveCell(SSGRID.ActiveCol, i)
            ElseIf SSGRID.ActiveCol = 3 Then
                SSGRID.SetActiveCell(SSGRID.ActiveCol, i)
            ElseIf SSGRID.ActiveCol = 4 Then
                SSGRID.SetActiveCell(SSGRID.ActiveCol, i + 1)
            End If
        End If
    End Sub
    Private Sub CMB_CANCELTYPE_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mskFrom.Focus()
    End Sub
    Private Sub TXTCANCEL_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            mskFrom.Focus()
        End If
    End Sub
    Private Sub CMD_TODATE_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SSGRID.Focus()
            SSGRID.SetActiveCell(2, 1)
        End If
    End Sub
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View.Click
        gPrint = False
        Grp_Print.Visible = True
    End Sub
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
            gconnection.getDataSet(SQLSTRING, "roomcompanymasterhistory")
            If gdataset.Tables("roomcompanymasterhistory").Rows.Count > 0 Then
                Filewrite.WriteLine()
                pagesize = pagesize + 1
                For Each dr In gdataset.Tables("roomcompanymasterhistory").Rows
                    If pagesize > 58 Then
                        Filewrite.WriteLine(StrDup(89, "="))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(heading, mskfromdate, msktodate)
                        Filewrite.WriteLine()
                        pagesize = pagesize + 1
                    End If
                    SSQL = "|" & Space(11 - Len(Mid(Format(dr("CANCELFROM"), "0"), 1, 11))) & Mid(Format(dr("CANCELFROM"), "0"), 1, 11) & "|"
                    SSQL = SSQL & Space(10 - Len(Mid(Format(dr("CANCELTO"), "0"), 1, 10))) & Mid(Format(dr("CANCELTO"), "0"), 1, 10) & "|"
                    SSQL = SSQL & Space(10 - Len(Mid(Format(dr("CANCELTYPE"), ""), 1, 10))) & Mid(Format(dr("CANCELTYPE"), ""), 1, 10) & "|"
                    SSQL = SSQL & Space(10 - Len(Mid(Format(dr("AMT"), "0.00"), 1, 10))) & Mid(Format(dr("AMT"), "0.00"), 1, 10) & "|"
                    SSQL = SSQL & Space(10 - Len(Mid(Format(dr("CANCEL_AMT_HEAD"), "0.00"), 1, 10))) & Mid(Format(dr("CANCEL_AMT_HEAD"), "0.00"), 1, 10) & "|"
                    SSQL = SSQL & Space(10 - Len(Mid(Format(dr("FIXEDAMOUNT"), "0.00"), 1, 10))) & Mid(Format(dr("FIXEDAMOUNT"), "0.00"), 1, 10) & "|"
                    SSQL = SSQL & Mid(Format(dr("fromdate"), "dd/MMM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(dr("fromdate"), "dd/MMM/yyyy"), 1, 11))) & "|"
                    If dr("todate") = "01/01/1900" Then
                        SSQL = SSQL & Mid(Format("", ""), 1, 11) & Space(11 - Len(Mid(Format("", ""), 1, 11))) & "|"
                    Else
                        SSQL = SSQL & Mid(Format(dr("todate"), ""), 1, 11) & Space(11 - Len(Mid(Format(dr("todate"), ""), 1, 11))) & "|"
                    End If

                    Filewrite.WriteLine(SSQL)
                    pagesize = pagesize + 1
                Next
                Filewrite.WriteLine(StrDup(89, "="))
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
            Filewrite.WriteLine(StrDup(89, "="))
            pagesize = pagesize + 1
            Filewrite.WriteLine("|CANCEL FROM|CANCEL TO |TYPE      |AMT/PER   |PER HEAD  |FIXED AMT |EFF FROM   |EFF TO     |")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(89, "="))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
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
        Cmd_View.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_View.Enabled = True
                    Me.Cmd_Print.Enabled = True
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
                If Right(x) = "V" Then
                    Me.Cmd_View.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.Cmd_Print.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub GetTotal()
        Dim LoopIndex As Integer
        Dim vamount, vChargetype As String
        Dim vTotal As Double
        If MskTo.Visible = False Then
            With SSGRID
                If SSGRID.DataRowCnt > 0 Then
                    For LoopIndex = 1 To .DataRowCnt
                        .Col = 3
                        .Row = LoopIndex
                        vChargetype = .Text
                        .Col = 4
                        .Row = LoopIndex
                        vamount = .Text
                        If Trim(vChargetype) <> "" And Val(vamount) <> 0 Then
                            vTotal = vTotal + Val(vamount)
                        End If
                    Next LoopIndex
                    Second_Total = Val(vTotal)
                    If First_Total <> Val(Second_Total) Then
                        Cmd_Add.Enabled = True
                        mskFrom.Enabled = True
                    Else
                        Cmd_Add.Enabled = False
                        mskFrom.Enabled = False
                    End If
                End If
            End With
        End If
        If DateDiff(DateInterval.Day, Now, EffFrom1.Value) > 0 Then
            Cmd_Add.Enabled = True
        ElseIf DateDiff(DateInterval.Day, Now, EffFrom1.Value) < 0 Then
            Cmd_Add.Enabled = False
        ElseIf DateDiff(DateInterval.Day, Now, EffFrom1.Value) = 0 Then
            Cmd_Add.Enabled = True
        End If
    End Sub

    Private Sub CmdTaxSetUpHp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdTaxSetUpHp.Click
        Dim vform As New ListOperattion1
        gSQLString = "Select Book_fromDate, Book_ToDate ,Cancel_Amt_Per from PARTY_CANCELLATIONMASTER "
        If Trim(Search) = "" Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "Book_fromDate, Book_ToDate,Cancel_Amt_Per "
        vform.vFormatstring = " BOOK FROMDATE|   BOOK TODATE     |CANCEL FROM "
        vform.vCaption = " CANCELLATION MASTER HELP "
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.KeyPos2 = 2
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            SSGRID.ClearRange(1, 1, -1, -1, True)
            Cmd_Add.Text = "Add[F7]"
            mskFrom.Text = Format(CDate(vform.keyfield), "dd/MMM/yyyy")
            If vform.keyfield1 <> "" Then
                MskTo.Visible = True
                LBL_EFFTO.Visible = True
                MskTo.Text = Format(CDate(vform.keyfield1), "dd/MMM/yyyy")
                DtTo_gbl = Format(CDate(vform.keyfield1), "dd/MMM/yyyy")
                Cmd_Add.Enabled = True
                mskFrom.Enabled = True
            Else
                MskTo.Visible = False
                LBL_EFFTO.Visible = False
                MskTo.Text = "__/__/____"
                DtTo_gbl = "01/01/1900"
                Cmd_Add.Enabled = False
                mskFrom.Enabled = False
            End If
        End If
        mskFrom.Focus()
        Call mskFrom_Validated(sender, e)
        vform.Close()
        vform = Nothing
    End Sub
    Private Sub mskFrom_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles mskFrom.Validated
        Try
            Dim TAXCODE As String
            Dim i As Integer
            If FORMLOADED = True Then
                If Mid(Cmd_Add.Text, 1, 1) = "A" Then
                    Dim Str As String
                    If IsDate(mskFrom.Text) = False Then
                        mskFrom.Text = "__/__/____"
                        Exit Sub
                    End If
                    First_Total = 0
                    With SSGRID
                        sqlstring = "Select  ISNULL(CANCELCODE,'') AS CANCELCODE,isnull(CANCELFROM,0)as CANCELFROM, isnull(CANCELTO,0)as CANCELTO, isnull(CANCELTYPE,'')as CANCELTYPE, "
                        sqlstring = sqlstring & " isnull(Cancel_Amt_Per,0)as Cancel_Amt_Per,isnull(Cancel_Amt_Head,0)as Cancel_Amt_Head,isnull(FixedAmount,0)as FixedAmount,isnull(BOOK_FROMDATE,'')as BOOK_FROMDATE, isnull(Book_toDate,'')as  Book_toDate, "
                        sqlstring = sqlstring & " isnull(FREEZE,'')AS FREEZE,ISNULL(ADDDATE,'')AS ADDDATE from PARTY_CANCELLATIONMASTER "
                        sqlstring = sqlstring & " where  '" & Format(CDate(mskFrom.Text), "dd/MMM/yyyy") & "'>=BOOK_FROMDATE AND ('" & Format(CDate(mskFrom.Text), "dd/MMM/yyyy") & "' <= Book_toDate OR ISNULL(Book_toDate,'')='')"
                        gconnection.getDataSet(sqlstring, "PTY_CANCELLATIONMASTER")
                        Cmd_Add.Text = "Add[F7]"
                        If gdataset.Tables("PTY_CANCELLATIONMASTER").Rows.Count > 0 Then
                            EffFrom1.Enabled = False
                            CmdTaxSetUpHp.Enabled = False
                            If SSGRID.MaxCols > 1 And SSGRID.Enabled = True Then
                                SSGRID.ClearRange(1, 1, -1, -1, True)
                            End If
                            For i = 0 To gdataset.Tables("PTY_CANCELLATIONMASTER").Rows.Count - 1
                                SSGRID.Col = 1
                                SSGRID.Row = i + 1
                                SSGRID.Text = gdataset.Tables("PTY_CANCELLATIONMASTER").Rows(i).Item("CANCELFROM")
                                SSGRID.Col = 2
                                SSGRID.Row = i + 1
                                SSGRID.Text = gdataset.Tables("PTY_CANCELLATIONMASTER").Rows(i).Item("CANCELTO")
                                SSGRID.Col = 3
                                SSGRID.Row = i + 1
                                SSGRID.Text = gdataset.Tables("PTY_CANCELLATIONMASTER").Rows(i).Item("CANCELTYPE")
                                SSGRID.Col = 4
                                SSGRID.Row = i + 1
                                SSGRID.Text = gdataset.Tables("PTY_CANCELLATIONMASTER").Rows(i).Item("CANCEL_AMT_PER")
                                First_Total = First_Total + Val(SSGRID.Text)
                                SSGRID.Col = 5
                                SSGRID.Row = i + 1
                                SSGRID.Text = gdataset.Tables("PTY_CANCELLATIONMASTER").Rows(i).Item("CANCEL_AMT_HEAD")
                                SSGRID.Col = 6
                                SSGRID.Row = i + 1
                                SSGRID.Text = gdataset.Tables("PTY_CANCELLATIONMASTER").Rows(i).Item("FIXEDAMOUNT")

                                SSGRID.Col = 7
                                SSGRID.Row = i + 1
                                SSGRID.Text = gdataset.Tables("PTY_CANCELLATIONMASTER").Rows(i).Item("CANCELCODE")

                            Next i

                            Dtfrom_gbl = Trim(gdataset.Tables("PTY_CANCELLATIONMASTER").Rows(0).Item("Book_FromDate"))
                            Cmd_Add.Enabled = False
                            mskFrom.Enabled = False
                            If Trim(Format(gdataset.Tables("PTY_CANCELLATIONMASTER").Rows(0).Item("Book_toDate"), "dd/MMM/yyyy")) = "01/Jan/1900" Then
                                MskTo.Visible = False
                                LBL_EFFTO.Visible = False
                            Else
                                MskTo.Visible = True
                                LBL_EFFTO.Visible = True
                                MskTo.Text = Trim(gdataset.Tables("PTY_CANCELLATIONMASTER").Rows(0).Item("Book_toDate"))
                                mskFrom.Text = Trim(gdataset.Tables("PTY_CANCELLATIONMASTER").Rows(0).Item("Book_fromDate"))
                            End If
                            GetTotal()
                            Me.Cmd_Add.Text = "Update [F7]"
                            If gUserCategory <> "S" Then
                                Call GetRights()
                            End If
                        Else
                            Cmd_Add.Text = "Add[F7]"
                        End If
                        'SSGRID.SetActiveCell(1, i + 1)
                        SSGRID.SetActiveCell(4, i)
                    End With
                End If
            End If

            If DateDiff(DateInterval.Day, Now, EffFrom1.Value) > 0 Then
                Cmd_Add.Enabled = True
            ElseIf DateDiff(DateInterval.Day, Now, EffFrom1.Value) < 0 Then
                Cmd_Add.Enabled = False
                'ElseIf DateDiff(DateInterval.Day, Now, EffFrom1.Value) = 0 Then
                '    sqlstring = " Select * From roomcancellations Where CAncelDate='" & Format(CDate(mskFrom.Text), "dd/MMM/yyyy") & "'"
                '    gconnection.getDataSet(sqlstring, "ROOMCANCELLATIONS")
                '    Cmd_Add.Text = "Add[F7]"
                '    If gdataset.Tables("ROOMCANCELLATIONS").Rows.Count > 0 Then
                '        MsgBox("Transaction Already Taken, Cannot Be Modified", MsgBoxStyle.Critical, "CAnnot Be Updated")
                '        Exit Sub
                '    End If
                '    Cmd_Add.Enabled = True
            End If

        Catch
            MsgBox(Err.Description, MsgBoxStyle.Exclamation)
        End Try
    End Sub
    Private Sub EffFrom1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EffFrom1.KeyDown
        mskFrom.Text = Format(EffFrom1.Value, "dd/MM/yyyy")
        mskFrom_Validated(sender, e)
        mskFrom.Focus()
    End Sub
    Private Sub mskFrom_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles mskFrom.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            mskFrom_Validated(sender, e)
        End If
    End Sub
    Private Sub mskFrom_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles mskFrom.KeyPress
        If Asc(e.KeyChar) = 13 Then
            mskFrom_Validated(sender, e)
        End If
    End Sub
    Private Sub EffFrom1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles EffFrom1.Validated
        mskFrom.Text = Format(EffFrom1.Value, "dd/MM/yyyy")
        mskFrom.Focus()
        mskFrom_Validated(sender, e)
    End Sub
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        mskFrom.Text = Format(Now, "dd/MM/yyyy")
        'mskFrom.Text = "__/__/____"
        MskTo.Text = "__/__/____"
        EffFrom1.Value = Format(Now, "dd/MM/yyyy")
        LBL_EFFTO.Visible = False
        MskTo.Visible = False
        SSGRID.ClearRange(1, 1, -1, -1, True)
        Cmd_Add.Text = "Add[F7]"
        SSGRID.Col = 1
        SSGRID.Row = 1
        SSGRID.Text = "0.00"
        EffFrom1.Enabled = True
        CmdTaxSetUpHp.Enabled = True
    End Sub

    Private Sub EffFrom1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EffFrom1.ValueChanged
        mskFrom.Text = Format(EffFrom1.Value, "dd/MM/yyyy")
        mskFrom.Focus()
    End Sub
    Private Sub CMD_WINDOWS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_WINDOWS.Click
        Dim Viewer As New ReportViwer

        Dim r As New RPT_MAS_CANCELLATIONHISTORY
        str = "SELECT * FROM VIEW_PARTY_CANCELLATIONHISTORY"
        Viewer.ssql = str
        gconnection.getDataSet(str, "SESSION")
        If gdataset.Tables("SESSION").Rows.Count > 0 Then
            Viewer.Report = r
            Viewer.TableName = "VIEW_PARTY_CANCELLATIONHISTORY"
            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text1")
            textobj1.Text = MyCompanyName
            Dim TXTOBJ2 As TextObject
            TXTOBJ2 = r.ReportDefinition.ReportObjects("Text3")
            TXTOBJ2.Text = gUsername
            Viewer.Show()
            Grp_Print.Visible = False
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If
    End Sub

    Private Sub CMD_DOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_DOS.Click
        Dim i, j As Integer
        Dim Type() As String
        Dim tablename As String
        Dim typename As String
        Dim heading As String
        heading = "CANCELLATION MASTER"

        str = "SELECT ISNULL(CANCELCODE,'') AS CANCELCODE,ISNULL(CANCELFROM,0)AS CANCELFROM,ISNULL(CANCELTO,0)AS CANCELTO,ISNULL(CANCELTYPE,'')AS CANCELTYPE,ISNULL(CANCEL_AMT_PER,0)AS AMT,ISNULL(CANCEL_AMT_HEAD,0) AS CANCEL_AMT_HEAD,ISNULL(FIXEDAMOUNT,0) AS FIXEDAMOUNT"
        str = str & " ,ISNULL(BOOK_FROMDATE,'')AS FROMDATE,ISNULL(BOOK_TODATE,'')AS TODATE FROM PARTY_CANCELLATIONMASTER "
        Call printdata(str, heading, Format(Now, "dd-MMM-yyyy"), Format(Now, "dd-MMM-yyyy"))
        Grp_Print.Visible = False
    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Grp_Print.Visible = False
    End Sub
    Private Sub PTY_CANCELLATIONMASTER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'GetRights()
        gconnection.FocusSetting(Me)
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        FORMLOADED = False
        Show()
        Dim ScreenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim ScreenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.WindowState = FormWindowState.Normal
        EffFrom1.Value = Format(Now, "dd/MM/yyyy")
        mskFrom.Text = Format(Now, "dd/MM/yyyy")
        MskTo.Text = "__/__/____"
        mskFrom.Focus()
        Dim i As Integer
        Cmd_Add.Text = "Add[F7]"
        FORMLOADED = True
    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Dim sqlstring As String
        Dim _export As New EXPORT
        _export.TABLENAME = "PARTY_CANCELLATIONMASTER"
        sqlstring = " SELECT * FROM PARTY_CANCELLATIONMASTER  "
        Call _export.export_excel(sqlstring)
        _export.Show()
        Exit Sub
    End Sub
End Class
