Imports System.Data.SqlClient
Imports System.IO
Public Class JournalRegister
    Inherits System.Windows.Forms.Form
    Dim Cmd As New SqlCommand
    Dim con As SqlConnection
    Dim vchk As Boolean
    Dim VCONN As New GlobalClass
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
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents CmdExit As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Dtp_ToVoucherDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GrpBox As System.Windows.Forms.GroupBox
    Friend WithEvents CmdExport As System.Windows.Forms.Button
    Friend WithEvents cmdGExit As System.Windows.Forms.Button
    Friend WithEvents cmdGetDetails As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ssGrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Grp_AccountPosting As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_AccPosting As System.Windows.Forms.Button
    Friend WithEvents GrdAuditTrail As AxFPSpreadADO.AxfpSpread
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMD_POST_EXIT As System.Windows.Forms.Button
    Friend WithEvents CMD_POST As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Dtp_FromVoucherDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents RDO_TARIFF As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(JournalRegister))
        Me.frmbut = New System.Windows.Forms.GroupBox
        Me.cmdGetDetails = New System.Windows.Forms.Button
        Me.CmdExit = New System.Windows.Forms.Button
        Me.CmdClear = New System.Windows.Forms.Button
        Me.CmdView = New System.Windows.Forms.Button
        Me.CmdPrint = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Dtp_ToVoucherDate = New System.Windows.Forms.DateTimePicker
        Me.GrpBox = New System.Windows.Forms.GroupBox
        Me.CmdExport = New System.Windows.Forms.Button
        Me.cmdGExit = New System.Windows.Forms.Button
        Me.cmd_AccPosting = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Dtp_FromVoucherDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.ssGrid = New AxFPSpreadADO.AxfpSpread
        Me.Grp_AccountPosting = New System.Windows.Forms.GroupBox
        Me.GrdAuditTrail = New AxFPSpreadADO.AxfpSpread
        Me.CMD_POST = New System.Windows.Forms.Button
        Me.CMD_POST_EXIT = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.RDO_TARIFF = New System.Windows.Forms.RadioButton
        Me.frmbut.SuspendLayout()
        Me.GrpBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grp_AccountPosting.SuspendLayout()
        CType(Me.GrdAuditTrail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.cmdGetDetails)
        Me.frmbut.Controls.Add(Me.CmdExit)
        Me.frmbut.Controls.Add(Me.CmdClear)
        Me.frmbut.Location = New System.Drawing.Point(280, 320)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(528, 64)
        Me.frmbut.TabIndex = 2
        Me.frmbut.TabStop = False
        '
        'cmdGetDetails
        '
        Me.cmdGetDetails.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.cmdGetDetails.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdGetDetails.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGetDetails.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdGetDetails.Location = New System.Drawing.Point(224, 16)
        Me.cmdGetDetails.Name = "cmdGetDetails"
        Me.cmdGetDetails.Size = New System.Drawing.Size(78, 32)
        Me.cmdGetDetails.TabIndex = 4
        Me.cmdGetDetails.Text = "GetDetails"
        '
        'CmdExit
        '
        Me.CmdExit.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.CmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdExit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdExit.Location = New System.Drawing.Point(368, 16)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.Size = New System.Drawing.Size(78, 32)
        Me.CmdExit.TabIndex = 5
        Me.CmdExit.Text = "Exit [F11]"
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.CmdClear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdClear.Location = New System.Drawing.Point(88, 16)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(74, 32)
        Me.CmdClear.TabIndex = 3
        Me.CmdClear.Text = "Clear [F6]"
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.CmdView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdView.Location = New System.Drawing.Point(56, 16)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(77, 32)
        Me.CmdView.TabIndex = 0
        Me.CmdView.Text = "View [F9]"
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.CmdPrint.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdPrint.Location = New System.Drawing.Point(168, 16)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(77, 32)
        Me.CmdPrint.TabIndex = 1
        Me.CmdPrint.Text = "Print"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(64, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 18)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "FROM"
        '
        'Dtp_ToVoucherDate
        '
        Me.Dtp_ToVoucherDate.CustomFormat = "dd - MMM - yyyy"
        Me.Dtp_ToVoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtp_ToVoucherDate.Location = New System.Drawing.Point(304, 112)
        Me.Dtp_ToVoucherDate.Name = "Dtp_ToVoucherDate"
        Me.Dtp_ToVoucherDate.Size = New System.Drawing.Size(144, 22)
        Me.Dtp_ToVoucherDate.TabIndex = 2
        '
        'GrpBox
        '
        Me.GrpBox.BackColor = System.Drawing.Color.Transparent
        Me.GrpBox.Controls.Add(Me.CmdExport)
        Me.GrpBox.Controls.Add(Me.cmdGExit)
        Me.GrpBox.Controls.Add(Me.CmdPrint)
        Me.GrpBox.Controls.Add(Me.CmdView)
        Me.GrpBox.Controls.Add(Me.cmd_AccPosting)
        Me.GrpBox.Location = New System.Drawing.Point(240, 568)
        Me.GrpBox.Name = "GrpBox"
        Me.GrpBox.Size = New System.Drawing.Size(608, 56)
        Me.GrpBox.TabIndex = 4
        Me.GrpBox.TabStop = False
        '
        'CmdExport
        '
        Me.CmdExport.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.CmdExport.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdExport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdExport.Location = New System.Drawing.Point(280, 16)
        Me.CmdExport.Name = "CmdExport"
        Me.CmdExport.Size = New System.Drawing.Size(78, 32)
        Me.CmdExport.TabIndex = 2
        Me.CmdExport.Text = "Export"
        '
        'cmdGExit
        '
        Me.cmdGExit.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.cmdGExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdGExit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGExit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdGExit.Location = New System.Drawing.Point(488, 16)
        Me.cmdGExit.Name = "cmdGExit"
        Me.cmdGExit.Size = New System.Drawing.Size(78, 32)
        Me.cmdGExit.TabIndex = 3
        Me.cmdGExit.Text = "Exit [F11]"
        '
        'cmd_AccPosting
        '
        Me.cmd_AccPosting.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.cmd_AccPosting.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_AccPosting.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_AccPosting.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmd_AccPosting.Location = New System.Drawing.Point(384, 15)
        Me.cmd_AccPosting.Name = "cmd_AccPosting"
        Me.cmd_AccPosting.Size = New System.Drawing.Size(78, 32)
        Me.cmd_AccPosting.TabIndex = 4
        Me.cmd_AccPosting.Text = "Post To Accounts"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RDO_TARIFF)
        Me.GroupBox1.Controls.Add(Me.Dtp_FromVoucherDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Dtp_ToVoucherDate)
        Me.GroupBox1.Location = New System.Drawing.Point(280, 104)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(528, 160)
        Me.GroupBox1.TabIndex = 126
        Me.GroupBox1.TabStop = False
        '
        'Dtp_FromVoucherDate
        '
        Me.Dtp_FromVoucherDate.CustomFormat = "dd - MMM - yyyy"
        Me.Dtp_FromVoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtp_FromVoucherDate.Location = New System.Drawing.Point(120, 112)
        Me.Dtp_FromVoucherDate.Name = "Dtp_FromVoucherDate"
        Me.Dtp_FromVoucherDate.Size = New System.Drawing.Size(144, 22)
        Me.Dtp_FromVoucherDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(272, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 18)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "TO"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(96, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(353, 31)
        Me.Label10.TabIndex = 123
        Me.Label10.Text = "PARTY JOURNAL REGISTER"
        '
        'ssGrid
        '
        Me.ssGrid.DataSource = Nothing
        Me.ssGrid.Location = New System.Drawing.Point(8, 8)
        Me.ssGrid.Name = "ssGrid"
        Me.ssGrid.OcxState = CType(resources.GetObject("ssGrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssGrid.Size = New System.Drawing.Size(1000, 536)
        Me.ssGrid.TabIndex = 127
        '
        'Grp_AccountPosting
        '
        Me.Grp_AccountPosting.BackColor = System.Drawing.Color.Transparent
        Me.Grp_AccountPosting.Controls.Add(Me.GrdAuditTrail)
        Me.Grp_AccountPosting.Controls.Add(Me.CMD_POST)
        Me.Grp_AccountPosting.Controls.Add(Me.CMD_POST_EXIT)
        Me.Grp_AccountPosting.Controls.Add(Me.Label1)
        Me.Grp_AccountPosting.Location = New System.Drawing.Point(56, 48)
        Me.Grp_AccountPosting.Name = "Grp_AccountPosting"
        Me.Grp_AccountPosting.Size = New System.Drawing.Size(928, 624)
        Me.Grp_AccountPosting.TabIndex = 128
        Me.Grp_AccountPosting.TabStop = False
        '
        'GrdAuditTrail
        '
        Me.GrdAuditTrail.ContainingControl = Me
        Me.GrdAuditTrail.DataSource = Nothing
        Me.GrdAuditTrail.Location = New System.Drawing.Point(13, 96)
        Me.GrdAuditTrail.Name = "GrdAuditTrail"
        Me.GrdAuditTrail.OcxState = CType(resources.GetObject("GrdAuditTrail.OcxState"), System.Windows.Forms.AxHost.State)
        Me.GrdAuditTrail.Size = New System.Drawing.Size(904, 408)
        Me.GrdAuditTrail.TabIndex = 128
        '
        'CMD_POST
        '
        Me.CMD_POST.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.CMD_POST.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CMD_POST.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_POST.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CMD_POST.Location = New System.Drawing.Point(384, 544)
        Me.CMD_POST.Name = "CMD_POST"
        Me.CMD_POST.Size = New System.Drawing.Size(78, 32)
        Me.CMD_POST.TabIndex = 132
        Me.CMD_POST.Text = "POST"
        '
        'CMD_POST_EXIT
        '
        Me.CMD_POST_EXIT.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.CMD_POST_EXIT.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CMD_POST_EXIT.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_POST_EXIT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CMD_POST_EXIT.Location = New System.Drawing.Point(528, 544)
        Me.CMD_POST_EXIT.Name = "CMD_POST_EXIT"
        Me.CMD_POST_EXIT.Size = New System.Drawing.Size(78, 32)
        Me.CMD_POST_EXIT.TabIndex = 130
        Me.CMD_POST_EXIT.Text = "EXIT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(368, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 31)
        Me.Label1.TabIndex = 129
        Me.Label1.Text = "AUDIT TRIAL"
        '
        'RDO_TARIFF
        '
        Me.RDO_TARIFF.Font = New System.Drawing.Font("Courier New", 13.0!, System.Drawing.FontStyle.Bold)
        Me.RDO_TARIFF.Location = New System.Drawing.Point(184, 68)
        Me.RDO_TARIFF.Name = "RDO_TARIFF"
        Me.RDO_TARIFF.Size = New System.Drawing.Size(160, 24)
        Me.RDO_TARIFF.TabIndex = 843
        Me.RDO_TARIFF.Text = "SAILING"
        '
        'JournalRegister
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpBox)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ssGrid)
        Me.Controls.Add(Me.Grp_AccountPosting)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "JournalRegister"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JournalRegister"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.frmbut.ResumeLayout(False)
        Me.GrpBox.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ssGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grp_AccountPosting.ResumeLayout(False)
        CType(Me.GrdAuditTrail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub JournalRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Show()
            Dtp_FromVoucherDate.Focus()
            ssGrid.Visible = False
            GrpBox.Visible = False
            Grp_AccountPosting.Visible = False
            VCONN.openConnection()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Try
            Call ClearOperation()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        Try
            gPrint = False
            Call VIEWOPERATION()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        Try
            gPrint = True
            Call VIEWOPERATION()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub CmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExit.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub JournalRegister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F6 And CmdClear.Visible = True Then
                Me.CmdClear_Click(sender, e)
            End If
            If e.KeyCode = Keys.F11 Then
                Me.CmdExit_Click(sender, e)
            End If
            If e.KeyCode = Keys.F9 And GrpBox.Visible = True Then
                Me.CmdView_Click(sender, e)
            End If
            If e.KeyCode = Keys.Escape Then
                If ssGrid.Visible = True Then
                    ssGrid.Visible = False
                    GrpBox.Visible = False
                    GroupBox1.Visible = True
                    frmbut.Visible = True
                ElseIf Grp_AccountPosting.Visible = True Then
                    Grp_AccountPosting.Visible = False
                    GroupBox1.Visible = True
                    frmbut.Visible = True
                Else
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub Dtp_ToVoucherDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dtp_ToVoucherDate.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                cmdGetDetails.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub ClearOperation()
        Try
            Dtp_FromVoucherDate.Value = Format(Date.Now, "MMMM-yyyy")
            Dtp_ToVoucherDate.Value = Format(Date.Now, "MMMM-yyyy")
            ssGrid.Visible = False
            GrpBox.Visible = False
            Grp_AccountPosting.Visible = False
            Show()
            Dtp_FromVoucherDate.Focus()
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub cmdGetDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGetDetails.Click
        Try
            Dim I As Integer
            Me.Cursor = Cursors.WaitCursor
            With ssGrid
                '.MaxRows = 100
                'For I = 3 To ssGrid.DataRowCnt
                For I = 3 To 100
                    .Row = I
                    .Col = 1
                    .FontBold = False
                    .ForeColor = Color.Black
                    .Col = 2
                    .FontBold = False
                    .ForeColor = Color.Black
                    .Col = 3
                    .FontBold = False
                    .ForeColor = Color.Black
                    .Col = 4
                    .FontBold = False
                    .ForeColor = Color.Black
                    .Col = 5
                    .FontBold = False
                    .ForeColor = Color.Black
                    .Col = 6
                    .FontBold = False
                    .ForeColor = Color.Black
                Next
            End With
            ssGrid.SetActiveCell(1, 1)
            Call GridOperation()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            'MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub GridOperation()
        Try
            Dim vSplit(), ssql As String
            Dim Insert(0) As String
            Dim Sqlstring As String
            Dim vNote As String
            Dim i As Double
            Dim VOUCHERNO As String = ""
            Dim CREDITAMOUNT, DEBITAMOUNT As Double
            Dim GRANDCREDIT, GRANDDEBIT, ROWCOUNT As Double
            Dim VCHKVCHRNO As String
            Dim strsql As String
            If vchk = True Then Exit Sub
            frmbut.Visible = False
            GroupBox1.Visible = False
            Me.Cursor = Cursors.WaitCursor

            strsql = "EXEC PJV_POSTING " & "'" & Format(Dtp_FromVoucherDate.Value, "dd-MMM-yyyy") & "','" & Format(Dtp_ToVoucherDate.Value, "dd-MMM-yyyy") & "','T'"
            VCONN.dataOperation(6, strsql, "ACCOUNTPOSTING")

            Me.Cursor = Cursors.Default

            ssql = "Select VoucherNo,VoucherDate,VoucherType,AccountCode,isnull(AccountCodeDesc,'')AccountCodeDesc,"
            ssql = ssql & " isnull(SlDESC,'') SlDESC ,CreditDebit,isnull(Amount,0)Amount,isnull(Description,'')Description "
            ssql = ssql & " from PURCHASE_Journal_Entry  WHERE "
            ssql = ssql & " isnull(void,'') <>'Y' "
            ssql = ssql & " AND VoucherType = 'PJV'"
            ssql = ssql & " Order by VoucherNo,creditdebit,ROWID"

            VCONN.getDataSet(ssql, "JournalEntry")
            If gdataset.Tables("JournalEntry").Rows.Count > 0 Then
                With ssGrid
                    .ClearRange(1, 3, -1, -1, True)
                    .Visible = True
                    GrpBox.Visible = True
                    Call GridHead()
                    VOUCHERNO = gdataset.Tables("JournalEntry").Rows(0).Item("voucherNo")
                    ROWCOUNT = 3
                    For i = 0 To gdataset.Tables("JournalEntry").Rows.Count - 1
                        If Trim(VOUCHERNO) <> gdataset.Tables("JournalEntry").Rows(i).Item("voucherNo") Then

                            ROWCOUNT = ROWCOUNT + 1
                            .MaxRows = .MaxRows + 1
                            .Row = ROWCOUNT

                            .Col = 5
                            .FontBold = True
                            .ForeColor = Color.DarkSlateGray
                            .Text = "VOUCHER TOTAL"

                            .Col = 6
                            .FontBold = True
                            .ForeColor = Color.DarkSlateGray
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                            .Text = DEBITAMOUNT
                            DEBITAMOUNT = 0

                            .Col = 7
                            .FontBold = True
                            .ForeColor = Color.DarkSlateGray
                            .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                            .Text = CREDITAMOUNT
                            CREDITAMOUNT = 0

                            VOUCHERNO = gdataset.Tables("JournalEntry").Rows(i).Item("voucherNo")
                            ROWCOUNT = ROWCOUNT + 2
                            .MaxRows = .MaxRows + 2
                        End If

                        .Row = ROWCOUNT
                        If gdataset.Tables("JournalEntry").Rows(i).IsNull("voucherno") = False Then
                            .Col = 1
                            .Text = gdataset.Tables("JournalEntry").Rows(i).Item("voucherNo")

                        Else
                            .Text = ""
                        End If


                        If gdataset.Tables("JournalEntry").Rows(i).IsNull("voucherDate") = False Then
                            .Col = 2
                            .Text = gdataset.Tables("JournalEntry").Rows(i).Item("voucherdate")
                        Else
                            .Text = ""
                        End If

                        If gdataset.Tables("JournalEntry").Rows(i).IsNull("AccountCodeDesc") = False Then
                            .Col = 3
                            .Text = gdataset.Tables("JournalEntry").Rows(i).Item("AccountCodeDesc")
                        Else
                            .Text = ""
                        End If

                        If gdataset.Tables("JournalEntry").Rows(i).IsNull("slDesc") = False Then
                            .Col = 4
                            .Text = gdataset.Tables("JournalEntry").Rows(i).Item("slDesc")
                        Else
                            .Text = ""
                        End If

                        If gdataset.Tables("JournalEntry").Rows(i).IsNull("Description") = False Then
                            .Col = 5
                            .Text = gdataset.Tables("JournalEntry").Rows(i).Item("Description")
                            VCHKVCHRNO = gdataset.Tables("JournalEntry").Rows(i).Item("voucherNo")
                        Else
                            .Text = ""
                        End If

                        If gdataset.Tables("JournalEntry").Rows(i).IsNull("CreditDebit") = False Then
                            If Mid(Trim(gdataset.Tables("JournalEntry").Rows(i).Item("CreditDebit")), 1, 1) = "D" Then   ' For Debit 
                                .Col = 6
                                .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                                If gdataset.Tables("JournalEntry").Rows(i).IsNull("Amount") = False Then
                                    .Text = gdataset.Tables("JournalEntry").Rows(i).Item("Amount")
                                    DEBITAMOUNT = DEBITAMOUNT + Val(gdataset.Tables("JournalEntry").Rows(i).Item("Amount"))
                                    GRANDDEBIT = GRANDDEBIT + Val(gdataset.Tables("JournalEntry").Rows(i).Item("Amount"))
                                Else
                                    .Text = 0
                                End If
                            Else
                                .Col = 7
                                .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                                If gdataset.Tables("JournalEntry").Rows(i).IsNull("Amount") = False Then
                                    .Text = gdataset.Tables("JournalEntry").Rows(i).Item("Amount")
                                    CREDITAMOUNT = CREDITAMOUNT + Val(gdataset.Tables("JournalEntry").Rows(i).Item("Amount"))
                                    GRANDCREDIT = GRANDCREDIT + Val(gdataset.Tables("JournalEntry").Rows(i).Item("Amount"))
                                Else
                                    .Text = 0
                                End If
                            End If
                        Else
                            .Text = ""
                        End If

                        ROWCOUNT = ROWCOUNT + 1
                        .MaxRows = .MaxRows + 1
                    Next
                    ROWCOUNT = ROWCOUNT + 1
                    .MaxRows = .MaxRows + 1
                    .Row = ROWCOUNT
                    .Col = 5
                    .FontBold = True
                    .ForeColor = Color.DarkSlateGray
                    .Text = "VOUCHER TOTAL"

                    .Row = ROWCOUNT
                    .Col = 6
                    .FontBold = True
                    .ForeColor = Color.DarkSlateGray
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(DEBITAMOUNT, "0.00")

                    .Row = ROWCOUNT
                    .Col = 7
                    .FontBold = True
                    .ForeColor = Color.DarkSlateGray
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(CREDITAMOUNT, "0.00")

                    ROWCOUNT = ROWCOUNT + 2
                    .MaxRows = .MaxRows + 2
                    .Row = ROWCOUNT
                    .Col = 5
                    .FontBold = True
                    .ForeColor = Color.Red
                    .Text = "GRAND TOTAL"

                    .Row = ROWCOUNT
                    .Col = 6
                    .FontBold = True
                    .ForeColor = Color.Magenta
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(GRANDDEBIT, "0.00")

                    .Row = ROWCOUNT
                    .Col = 7
                    .FontBold = True
                    .ForeColor = Color.Magenta
                    .CellType = FPSpreadADO.CellTypeConstants.CellTypeNumber
                    .Text = Format(GRANDCREDIT, "0.00")
                End With
                ssGrid.Visible = True
            Else
                MsgBox("No Record to View", MsgBoxStyle.Information)
                ssGrid.Visible = False
                frmbut.Visible = True
                GroupBox1.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub GridHead()
        Try
            Dim I As Double
            With ssGrid
                .Visible = True
                .ClearRange(1, 1, -1, -1, True)

                For I = 1 To .MaxRows
                    .Col = 1
                    .FontBold = False
                    .ForeColor = Color.Black
                    .Col = 2
                    .FontBold = False
                    .ForeColor = Color.Black
                    .Col = 3
                    .FontBold = False
                    .ForeColor = Color.Black

                    .Col = 4
                    .FontBold = False
                    .ForeColor = Color.Black
                    .Col = 5
                    .FontBold = False
                    .ForeColor = Color.Black
                    .Col = 6
                    .FontBold = False
                    .ForeColor = Color.Black
                    .Col = 7
                    .FontBold = False
                    .ForeColor = Color.Black
                Next

                .MaxCols = 7
                .Row = 1
                .FontBold = True
                .Col = 1
                .Text = "Voucher No"

                .Row = 1
                .FontBold = True
                .Col = 2
                .Text = "Voucher Date"

                .Row = 1
                .FontBold = True
                .Col = 3
                .Text = "Account Head"

                .Row = 1
                .FontBold = True
                .Col = 4
                .Text = "Sub Ledger"

                .Row = 1
                .FontBold = True
                .Col = 5
                .Text = "Description"

                .Row = 1
                .FontBold = True
                .Col = 6
                .Text = "Debit"

                .Row = 1
                .FontBold = True
                .Col = 7
                .Text = "Credit"
            End With
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub VIEWOPERATION()
        Try
            Dim PAGENO As Integer
            Dim SSQL, STR, VCAPTION As String
            Dim I As Integer
            Dim ROWCOUNT, CREDITAMOUNT, DEBITAMOUNT, GRANDDEBIT, GRANDCREDIT As Double
            CREDITAMOUNT = 0 : DEBITAMOUNT = 0 : GRANDDEBIT = 0 : GRANDCREDIT = 0 : ROWCOUNT = 1 : PAGENO = 1
            Dim VOUCHERNO As String
            Randomize()
            vOutfile = Mid("JRR" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            Dim vcaption1 As String
            vcaption1 = "PURCHASE JOURNAL REGISTER"
            If ssGrid.DataRowCnt > 1 Then
                'Call vconn.printheader(100, vcaption1)
                Filewrite.WriteLine("{0,80}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
                ROWCOUNT = ROWCOUNT + 1
                Filewrite.WriteLine()
                ROWCOUNT = ROWCOUNT + 1
                Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
                ROWCOUNT = ROWCOUNT + 1
                Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(vcaption1), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialyearEnd)
                ROWCOUNT = ROWCOUNT + 1
                Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(vcaption1)), "-"), 1, 30))
                ROWCOUNT = ROWCOUNT + 1
                Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE :" & PAGENO)
                ROWCOUNT = ROWCOUNT + 1
                Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(Dtp_ToVoucherDate.Value, "MMMM-yyyy"), " ", "AMOUNT IN RUPEES")
                ROWCOUNT = ROWCOUNT + 1
                Filewrite.WriteLine(Chr(15) & StrDup(133, "-"))
                ROWCOUNT = ROWCOUNT + 1
                Filewrite.WriteLine("   VOUCHER NO       |VCHR. DATE|      ACCOUNT HEAD       |      SUB LEDGER      |    DEBIT   |   CREDIT   |        DESCRIPTION      |")
                Filewrite.WriteLine(StrDup(133, "-"))
                ROWCOUNT = ROWCOUNT + 2
                ssGrid.Row = 3
                ssGrid.Col = 1
                VOUCHERNO = ssGrid.Text
                For I = 3 To ssGrid.DataRowCnt
                    ssGrid.Row = I
                    ssGrid.Col = 1
                    STR = ssGrid.Text
                    ssGrid.Col = 5
                    VCAPTION = ssGrid.Text
                    If Trim(STR) <> "" Then
                        If Trim(VOUCHERNO) <> Trim(STR) Then
                            Filewrite.WriteLine(Space(80) & StrDup(27, "-"))
                            Filewrite.WriteLine(Space(60) & "VOUCHER TOTAL" & Space(7) & "|" & Space(12 - Len(Mid(Format(DEBITAMOUNT, "0.00"), 1, 12))) & Mid(Format(DEBITAMOUNT, "0.00"), 1, 12) & "|" & Space(12 - Len(Mid(Format(DEBITAMOUNT, "0.00"), 1, 12))) & Mid(Format(DEBITAMOUNT, "0.00"), 1, 12) & "|")
                            Filewrite.WriteLine(Space(80) & StrDup(27, "-"))
                            Filewrite.WriteLine()
                            CREDITAMOUNT = 0 : DEBITAMOUNT = 0
                            ROWCOUNT = ROWCOUNT + 4
                            ssGrid.Row = I
                            ssGrid.Col = 1
                            VOUCHERNO = ssGrid.Text
                        End If
                        ssGrid.Col = 1
                        Filewrite.Write(Mid(ssGrid.Text, 1, 20) & Space(20 - Len(Mid(ssGrid.Text, 1, 20))) & "|")
                        ssGrid.Col = 2
                        Filewrite.Write(Mid(ssGrid.Text, 1, 10) & Space(10 - Len(Mid(ssGrid.Text, 1, 10))) & "|")
                        ssGrid.Col = 3
                        Filewrite.Write(Mid(ssGrid.Text, 1, 25) & Space(25 - Len(Mid(ssGrid.Text, 1, 25))) & "|")
                        ssGrid.Col = 4
                        Filewrite.Write(Mid(ssGrid.Text, 1, 22) & Space(22 - Len(Mid(ssGrid.Text, 1, 22))) & "|")
                        ssGrid.Col = 6
                        DEBITAMOUNT = DEBITAMOUNT + Val(ssGrid.Text)
                        GRANDDEBIT = GRANDDEBIT + Val(ssGrid.Text)
                        Filewrite.Write(Mid(ssGrid.Text, 1, 12) & Space(12 - Len(Mid(ssGrid.Text, 1, 12))) & "|")
                        ssGrid.Col = 7
                        CREDITAMOUNT = CREDITAMOUNT + Val(ssGrid.Text)
                        GRANDCREDIT = GRANDCREDIT + Val(ssGrid.Text)
                        Filewrite.Write(Mid(ssGrid.Text, 1, 12) & Space(12 - Len(Mid(ssGrid.Text, 1, 12))) & "|")
                        ssGrid.Col = 5
                        SSQL = ssGrid.Text
                        If Len(SSQL) < 25 Then
                            Filewrite.WriteLine(Mid(SSQL, 1, 25) & Space(25 - Len(Mid(SSQL, 1, 25))) & "|")
                            ROWCOUNT = ROWCOUNT + 1
                        ElseIf Len(SSQL) > 25 And Len(SSQL) < 50 Then
                            Filewrite.WriteLine(Mid(SSQL, 1, 25) & Space(25 - Len(Mid(SSQL, 1, 25))) & "|")
                            Filewrite.WriteLine(Space(106) & "|" & Mid(SSQL, 26, 23) & Space(25 - Len(Mid(SSQL, 26, 23))) & "|")
                            ROWCOUNT = ROWCOUNT + 2
                        ElseIf Len(SSQL) > 50 And Len(SSQL) < 75 Then
                            Filewrite.WriteLine(Mid(SSQL, 1, 25) & Space(25 - Len(Mid(SSQL, 1, 25))) & "|")
                            Filewrite.WriteLine(Space(106) & "|" & Mid(SSQL, 26, 23) & Space(25 - Len(Mid(SSQL, 26, 23))) & "|")
                            Filewrite.WriteLine(Space(106) & "|" & Mid(SSQL, 49, 23) & Space(25 - Len(Mid(SSQL, 49, 23))) & "|")
                            ROWCOUNT = ROWCOUNT + 3
                        Else
                            Filewrite.WriteLine(Mid(SSQL, 1, 25) & Space(25 - Len(Mid(SSQL, 1, 25))) & "|")
                            Filewrite.WriteLine(Space(106) & "|" & Mid(SSQL, 26, 23) & Space(25 - Len(Mid(SSQL, 26, 23))) & "|")
                            Filewrite.WriteLine(Space(106) & "|" & Mid(SSQL, 49, 23) & Space(25 - Len(Mid(SSQL, 49, 23))) & "|")
                            Filewrite.WriteLine(Space(106) & "|" & Mid(SSQL, 72, 23) & Space(25 - Len(Mid(SSQL, 72, 23))) & "|")
                            ROWCOUNT = ROWCOUNT + 4
                        End If
                        Filewrite.WriteLine()
                        ROWCOUNT = ROWCOUNT + 1
                    End If
                    If ROWCOUNT >= 55 Then
                        Filewrite.WriteLine(StrDup(133, "-"))
                        ROWCOUNT = 0
                        PAGENO = PAGENO + 1
                        Filewrite.WriteLine(Chr(12))
                        Filewrite.WriteLine("{0,80}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
                        ROWCOUNT = ROWCOUNT + 1
                        Filewrite.WriteLine()
                        ROWCOUNT = ROWCOUNT + 1
                        Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
                        ROWCOUNT = ROWCOUNT + 1
                        Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(vcaption1), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialyearEnd)
                        ROWCOUNT = ROWCOUNT + 1
                        Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(vcaption1)), "-"), 1, 30))
                        ROWCOUNT = ROWCOUNT + 1
                        Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE :" & PAGENO)
                        ROWCOUNT = ROWCOUNT + 1
                        Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(Dtp_ToVoucherDate.Value, "MMMM-yyyy"), " ", "AMOUNT IN RUPEES")
                        ROWCOUNT = ROWCOUNT + 1
                        Filewrite.WriteLine(Chr(15) & StrDup(133, "-"))
                        ROWCOUNT = ROWCOUNT + 1
                        Filewrite.WriteLine("   VOUCHER NO       |VCHR. DATE|      ACCOUNT HEAD       |      SUB LEDGER      |    DEBIT   |   CREDIT   |        DESCRIPTION      |")
                        Filewrite.WriteLine(StrDup(133, "-"))
                        ROWCOUNT = ROWCOUNT + 2
                    End If
                Next
            End If
            Filewrite.WriteLine(Space(80) & StrDup(27, "-"))
            Filewrite.WriteLine(Space(60) & "VOUCHER TOTAL" & Space(7) & "|" & Space(12 - Len(Mid(Format(DEBITAMOUNT, "0.00"), 1, 12))) & Mid(Format(DEBITAMOUNT, "0.00"), 1, 12) & "|" & Space(12 - Len(Mid(Format(DEBITAMOUNT, "0.00"), 1, 12))) & Mid(Format(DEBITAMOUNT, "0.00"), 1, 12) & "|")
            ROWCOUNT = ROWCOUNT + 2

            Filewrite.WriteLine(StrDup(133, "-"))
            Filewrite.WriteLine(Space(60) & "GRAND TOTAL  " & Space(7) & "|" & Space(12 - Len(Mid(Format(GRANDDEBIT, "0.00"), 1, 12))) & Mid(Format(GRANDDEBIT, "0.00"), 1, 12) & "|" & Space(12 - Len(Mid(Format(GRANDCREDIT, "0.00"), 1, 12))) & Mid(Format(GRANDCREDIT, "0.00"), 1, 12) & "|")
            Filewrite.WriteLine(StrDup(133, "-"))
            Filewrite.WriteLine()
            ROWCOUNT = ROWCOUNT + 3
            'vconn.printFOOTER()
            Filewrite.Write(Chr(12))
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile(VFilePath)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub cmdGExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGExit.Click
        Try
            ssGrid.Visible = False
            GrpBox.Visible = False
            GroupBox1.Visible = True
            frmbut.Visible = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        'End
    End Sub

    Private Sub CmdExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdExport.Click
        Try
            Call ExportTo(ssGrid)
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub ssGrid_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssGrid.KeyDownEvent
        Try
            If e.keyCode = Keys.F8 Then
                Dim frmSrc As New frmSearch
                frmSrc.farPoint = ssGrid
                frmSrc.ShowDialog(Me)
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub cmd_AccPosting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_AccPosting.Click
        Try
            Dim SQLSTRING, ACCOUNTCODE, SLCODE As String
            Dim CLS_CREDITS, CLS_DEBITS, CUR_CREDITS, CUR_DEBITS, TOT_CREDITS, TOT_DEBITS As Double
            Dim I, ROWCOUNT, J As Integer
            SQLSTRING = "SELECT ISNULL(CLOSED,'') FROM INVENTORY_MONTHCLOSE WHERE MONTHNO=" & Month(Dtp_ToVoucherDate.Value)
            VCONN.getDataSet(SQLSTRING, "MONTHCLOSE")
            If gdataset.Tables("MONTHCLOSE").Rows.Count > 0 Then
                MsgBox("ACCOUNT POSTING ALREADY DONE")
            Else
                SQLSTRING = "select distinct accountcode,ACCOUNTCODEDESC FROM purchase_journal_entry"
                SQLSTRING = SQLSTRING & " WHERE MONTH(VOUCHERDATE)=" & Month(Dtp_ToVoucherDate.Value)
                VCONN.getDataSet(SQLSTRING, "ACCODE")
                ROWCOUNT = 1
                If gdataset.Tables("ACCODE").Rows.Count > 0 Then
                    For I = 0 To gdataset.Tables("ACCODE").Rows.Count - 1
                        With GrdAuditTrail
                            .Row = ROWCOUNT
                            .Col = 1
                            .Text = Trim(gdataset.Tables("ACCODE").Rows(I).Item("AccountCODEDesc"))
                            SQLSTRING = "SELECT DISTINCT SLCODE,SLDESC FROM PURCHASE_JOURNAL_ENTRY WHERE ACCOUNTCODE='"
                            SQLSTRING = SQLSTRING & Trim(gdataset.Tables("ACCODE").Rows(I).Item("AccountCODE")) & "'"
                            VCONN.getDataSet(SQLSTRING, "SLCODE")
                            If gdataset.Tables("SLCODE").Rows.Count > 0 Then
                                For J = 0 To gdataset.Tables("SLCODE").Rows.Count - 1
                                    .Row = ROWCOUNT
                                    .Col = 2
                                    If Trim(gdataset.Tables("SLCODE").Rows(J).Item("sldesc")) <> "" Then
                                        .Text = Trim(gdataset.Tables("SLCODE").Rows(J).Item("sldesc"))
                                    Else
                                        .Text = ""
                                    End If

                                    .Col = 3
                                    If Trim(gdataset.Tables("SLCODE").Rows(J).Item("sldesc")) <> "" Then
                                        SQLSTRING = "SELECT SLCODE,ISNULL(SLDESC,'') SLDESC,isnull(CLDEBITS,0)CLDEBITS,isnull(CLCREDITS,0)CLCREDITS FROM ACCOUNTSSUBLEDGERMASTER WHERE ACCODE = '" & Trim(gdataset.Tables("ACCODE").Rows(I).Item("AccountCODE")) & "' AND ISNULL(FREEZEFLAG,'')<>'Y' and slcode='" & Trim(gdataset.Tables("SLCODE").Rows(J).Item("slCODE")) & "'"
                                        VCONN.getDataSet(SQLSTRING, "Subledger")
                                        If gdataset.Tables("Subledger").Rows.Count > 0 Then
                                            If gdataset.Tables("SUBLEDGER").Rows(0).Item("CLDEBITS") = gdataset.Tables("SUBLEDGER").Rows(0).Item("CLCREDITS") Then
                                                .Text = Format(Val(gdataset.Tables("SUBLEDGER").Rows(0).Item("CLDEBITS")) - Val(gdataset.Tables("SUBLEDGER").Rows(0).Item("CLCREDITS")), "0.00")
                                            ElseIf gdataset.Tables("SUBLEDGER").Rows(0).Item("CLDEBITS") > gdataset.Tables("SUBLEDGER").Rows(0).Item("CLCREDITS") Then
                                                .Text = Format(Val(gdataset.Tables("SUBLEDGER").Rows(0).Item("CLDEBITS")) - Val(gdataset.Tables("SUBLEDGER").Rows(0).Item("CLCREDITS")), "0.00") & " - Dr "
                                            Else
                                                .Text = Format(Val(gdataset.Tables("SUBLEDGER").Rows(0).Item("CLCREDITS")) - Val(gdataset.Tables("SUBLEDGER").Rows(0).Item("CLDEBITS")), "0.00") & " - Cr "
                                            End If
                                            CLS_CREDITS = Val(gdataset.Tables("SUBLEDGER").Rows(0).Item("CLCREDITS"))
                                            CLS_DEBITS = Val(gdataset.Tables("SUBLEDGER").Rows(0).Item("CLDEBITS"))
                                        End If

                                        .Col = 4
                                        SQLSTRING = "SELECT ISNULL(SUM(AMOUNT),0) CREDITAMOUNT FROM PURCHASE_JOURNAL_entry WHERE "
                                        SQLSTRING = SQLSTRING & "ACCOUNTCODE='" & Trim(gdataset.Tables("ACCODE").Rows(I).Item("AccountCODE")) & "' AND ISNULL(VOID,'')<>'Y' and slcode='" & Trim(gdataset.Tables("SLCODE").Rows(J).Item("slCODE")) & "' AND CREDITDEBIT='CREDIT'"
                                        VCONN.getDataSet(SQLSTRING, "PJV_CR_SL")
                                        If gdataset.Tables("PJV_CR_SL").Rows.Count > 0 Then
                                            .Text = Trim(gdataset.Tables("PJV_CR_SL").Rows(0).Item("CREDITAMOUNT"))
                                        Else
                                            .Text = ""
                                        End If
                                        CUR_CREDITS = Val(gdataset.Tables("PJV_CR_SL").Rows(0).Item("CREDITAMOUNT"))
                                        .Col = 5
                                        SQLSTRING = "SELECT ISNULL(SUM(AMOUNT),0) CREDITAMOUNT FROM PURCHASE_JOURNAL_entry WHERE "
                                        SQLSTRING = SQLSTRING & "ACCOUNTCODE='" & Trim(gdataset.Tables("ACCODE").Rows(I).Item("AccountCODE")) & "' AND ISNULL(VOID,'')<>'Y' and slcode='" & Trim(gdataset.Tables("SLCODE").Rows(J).Item("slCODE")) & "' AND CREDITDEBIT='DEBIT'"
                                        VCONN.getDataSet(SQLSTRING, "PJV_DB_SL")
                                        If gdataset.Tables("PJV_DB_SL").Rows.Count > 0 Then
                                            .Text = Trim(gdataset.Tables("PJV_DB_SL").Rows(0).Item("CREDITAMOUNT"))
                                        Else
                                            .Text = ""
                                        End If
                                        CUR_DEBITS = Val(gdataset.Tables("PJV_DB_SL").Rows(0).Item("CREDITAMOUNT"))
                                    Else
                                        SQLSTRING = "Select Accode,isnull(Acdesc,'')Acdesc,isnull(CLDEBITS,0)CLDEBITS,isnull(CLCREDITS,0)CLCREDITS  from AccountsGlAccountMaster  where isnull(freezeflag,'') <> 'Y' AND ACCODE='" & Trim(gdataset.Tables("ACCODE").Rows(I).Item("ACCOUNTCODE")) & "'"
                                        VCONN.getDataSet(SQLSTRING, "ACCOUNTMASTER")
                                        If gdataset.Tables("ACCOUNTMASTER").Rows.Count > 0 Then
                                            If gdataset.Tables("AccountMAster").Rows(0).Item("CLDEBITS") = gdataset.Tables("AccountMAster").Rows(0).Item("CLCREDITS") Then
                                                .Text = Format(Val(gdataset.Tables("AccountMAster").Rows(0).Item("CLDEBITS")) - Val(gdataset.Tables("AccountMAster").Rows(0).Item("CLCREDITS")), "0.00")
                                            ElseIf gdataset.Tables("AccountMAster").Rows(0).Item("CLDEBITS") > gdataset.Tables("AccountMAster").Rows(0).Item("CLCREDITS") Then
                                                .Text = Format(Val(gdataset.Tables("AccountMAster").Rows(0).Item("CLDEBITS")) - Val(gdataset.Tables("AccountMAster").Rows(0).Item("CLCREDITS")), "0.00") & " - Dr "
                                            Else
                                                .Text = Format(Val(gdataset.Tables("AccountMAster").Rows(0).Item("CLCREDITS")) - Val(gdataset.Tables("AccountMAster").Rows(0).Item("CLDEBITS")), "0.00") & " - Cr "
                                            End If
                                            CLS_CREDITS = Val(gdataset.Tables("AccountMAster").Rows(0).Item("CLCREDITS"))
                                            CLS_DEBITS = Val(gdataset.Tables("AccountMAster").Rows(0).Item("CLDEBITS"))
                                        End If
                                        .Col = 4
                                        SQLSTRING = "SELECT ISNULL(SUM(AMOUNT),0) CREDITAMOUNT FROM PURCHASE_JOURNAL_ENTRY WHERE "
                                        SQLSTRING = SQLSTRING & "ACCOUNTCODE='" & Trim(gdataset.Tables("ACCODE").Rows(I).Item("AccountCODE")) & "' AND ISNULL(VOID,'')<>'Y' AND CREDITDEBIT='CREDIT'"
                                        VCONN.getDataSet(SQLSTRING, "PJV_CR_SL")
                                        If gdataset.Tables("PJV_CR_SL").Rows.Count > 0 Then
                                            .Text = Trim(gdataset.Tables("PJV_CR_SL").Rows(0).Item("CREDITAMOUNT"))
                                            CUR_CREDITS = Val(gdataset.Tables("PJV_CR_SL").Rows(0).Item("CREDITAMOUNT"))
                                        Else
                                            .Text = ""
                                            CUR_CREDITS = 0
                                        End If
                                        .Col = 5
                                        SQLSTRING = "SELECT ISNULL(SUM(AMOUNT),0) DEBITAMOUNT FROM PURCHASE_JOURNAL_ENTRY WHERE "
                                        SQLSTRING = SQLSTRING & "ACCOUNTCODE='" & Trim(gdataset.Tables("ACCODE").Rows(I).Item("AccountCODE")) & "' AND ISNULL(VOID,'')<>'Y' AND CREDITDEBIT='DEBIT'"
                                        VCONN.getDataSet(SQLSTRING, "PJV_DB_SL")
                                        If gdataset.Tables("PJV_DB_SL").Rows.Count > 0 Then
                                            .Text = Trim(gdataset.Tables("PJV_DB_SL").Rows(0).Item("DEBITAMOUNT"))
                                            CUR_DEBITS = Val(gdataset.Tables("PJV_DB_SL").Rows(0).Item("DEBITAMOUNT"))
                                        Else
                                            .Text = ""
                                            CUR_DEBITS = 0
                                        End If
                                    End If
                                    TOT_CREDITS = CLS_CREDITS + CUR_CREDITS
                                    TOT_DEBITS = CLS_DEBITS + CUR_DEBITS
                                    .Col = 6
                                    If TOT_DEBITS = TOT_CREDITS Then
                                        .Text = TOT_DEBITS - TOT_CREDITS
                                    ElseIf TOT_DEBITS > TOT_CREDITS Then
                                        .Text = Format(TOT_DEBITS - TOT_CREDITS, "0.00") & " - Dr "
                                    Else
                                        .Text = Format(TOT_CREDITS - TOT_DEBITS, "0.00") & " - Cr "
                                    End If
                                    ROWCOUNT = ROWCOUNT + 1
                                Next J
                            End If
                        End With
                    Next I
                End If
                Grp_AccountPosting.Visible = True
                ssGrid.Visible = False
                GrpBox.Visible = False
                CMD_POST.Visible = True
                CMD_POST_EXIT.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub

    Private Sub CMD_POST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_POST.Click
        Try
            Dim SQLSTRING As String
            Dim STRSQL As String
            Me.Cursor = Cursors.WaitCursor
            STRSQL = "EXEC PJV_POSTING " & "'" & Format(Dtp_FromVoucherDate.Value, "dd-MMM-yyyy") & "','" & Format(Dtp_ToVoucherDate.Value, "dd-MMM-yyyy") & "','P'"
            VCONN.dataOperation(6, STRSQL, "ACCOUNTPOSTING")
            Me.Cursor = Cursors.Default
            MsgBox("ACCOUNT POSTING DONE SUCCESSFULLY", MsgBoxStyle.Exclamation, "SUCCESS")
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub CMD_POST_EXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_POST_EXIT.Click
        Try
            Grp_AccountPosting.Visible = False
            GroupBox1.Visible = True
            frmbut.Visible = True
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Dtp_FromVoucherDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dtp_FromVoucherDate.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                Dtp_ToVoucherDate.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
End Class