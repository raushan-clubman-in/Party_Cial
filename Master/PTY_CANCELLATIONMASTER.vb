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
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmdview As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Dim FORMLOADED As Boolean
    Dim rs As New Resizer1

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
    Friend WithEvents Cmd_Print3 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents Cmd_View2 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add2 As System.Windows.Forms.Button
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
    Friend WithEvents Cmd_Clear2 As System.Windows.Forms.Button
    Friend WithEvents Grp_Print As System.Windows.Forms.GroupBox
    Friend WithEvents CMDEXIT2 As System.Windows.Forms.Button
    Friend WithEvents CMD_WINDOWS As System.Windows.Forms.Button
    Friend WithEvents CMD_DOS As System.Windows.Forms.Button
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PTY_CANCELLATIONMASTER))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.Cmd_Clear2 = New System.Windows.Forms.Button()
        Me.Cmd_Print3 = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.Cmd_View2 = New System.Windows.Forms.Button()
        Me.Cmd_Add2 = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.SSGRID = New AxFPSpreadADO.AxfpSpread()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Frame2 = New System.Windows.Forms.GroupBox()
        Me.EffFrom1 = New System.Windows.Forms.DateTimePicker()
        Me.LBL_EFFTO = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MskTo = New System.Windows.Forms.TextBox()
        Me.mskFrom = New System.Windows.Forms.TextBox()
        Me.CmdTaxSetUpHp = New System.Windows.Forms.Button()
        Me.Grp_Print = New System.Windows.Forms.GroupBox()
        Me.CMDEXIT2 = New System.Windows.Forms.Button()
        Me.CMD_WINDOWS = New System.Windows.Forms.Button()
        Me.CMD_DOS = New System.Windows.Forms.Button()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.Cmdview = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
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
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear2)
        Me.GroupBox2.Controls.Add(Me.Cmd_Print3)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Controls.Add(Me.Cmd_View2)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add2)
        Me.GroupBox2.Location = New System.Drawing.Point(196, 482)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(617, 56)
        Me.GroupBox2.TabIndex = 526
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
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
        Me.cmdexport.UseVisualStyleBackColor = False
        '
        'Cmd_Clear2
        '
        Me.Cmd_Clear2.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Clear2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear2.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear2.Image = CType(resources.GetObject("Cmd_Clear2.Image"), System.Drawing.Image)
        Me.Cmd_Clear2.Location = New System.Drawing.Point(16, 16)
        Me.Cmd_Clear2.Name = "Cmd_Clear2"
        Me.Cmd_Clear2.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear2.TabIndex = 544
        Me.Cmd_Clear2.Text = "Clear[F6]"
        Me.Cmd_Clear2.UseVisualStyleBackColor = False
        '
        'Cmd_Print3
        '
        Me.Cmd_Print3.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Print3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Print3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Print3.ForeColor = System.Drawing.Color.White
        Me.Cmd_Print3.Image = CType(resources.GetObject("Cmd_Print3.Image"), System.Drawing.Image)
        Me.Cmd_Print3.Location = New System.Drawing.Point(384, 16)
        Me.Cmd_Print3.Name = "Cmd_Print3"
        Me.Cmd_Print3.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Print3.TabIndex = 7
        Me.Cmd_Print3.Text = "Print[F10]"
        Me.Cmd_Print3.UseVisualStyleBackColor = False
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
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'Cmd_View2
        '
        Me.Cmd_View2.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_View2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View2.ForeColor = System.Drawing.Color.White
        Me.Cmd_View2.Image = CType(resources.GetObject("Cmd_View2.Image"), System.Drawing.Image)
        Me.Cmd_View2.Location = New System.Drawing.Point(264, 16)
        Me.Cmd_View2.Name = "Cmd_View2"
        Me.Cmd_View2.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View2.TabIndex = 6
        Me.Cmd_View2.Text = " View[F9]"
        Me.Cmd_View2.UseVisualStyleBackColor = False
        '
        'Cmd_Add2
        '
        Me.Cmd_Add2.BackColor = System.Drawing.Color.Transparent
        Me.Cmd_Add2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add2.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add2.Image = CType(resources.GetObject("Cmd_Add2.Image"), System.Drawing.Image)
        Me.Cmd_Add2.Location = New System.Drawing.Point(144, 16)
        Me.Cmd_Add2.Name = "Cmd_Add2"
        Me.Cmd_Add2.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add2.TabIndex = 4
        Me.Cmd_Add2.Text = "Add[F7]"
        Me.Cmd_Add2.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(178, 75)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(432, 29)
        Me.Label16.TabIndex = 536
        Me.Label16.Text = "BANQUET CANCELLATION MASTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SSGRID
        '
        Me.SSGRID.DataSource = Nothing
        Me.SSGRID.Location = New System.Drawing.Point(183, 206)
        Me.SSGRID.Name = "SSGRID"
        Me.SSGRID.OcxState = CType(resources.GetObject("SSGRID.OcxState"), System.Windows.Forms.AxHost.State)
        Me.SSGRID.Size = New System.Drawing.Size(669, 200)
        Me.SSGRID.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(193, 455)
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
        Me.Frame2.Location = New System.Drawing.Point(460, 24)
        Me.Frame2.Name = "Frame2"
        Me.Frame2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame2.Size = New System.Drawing.Size(280, 80)
        Me.Frame2.TabIndex = 540
        Me.Frame2.TabStop = False
        Me.Frame2.Visible = False
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
        Me.LBL_EFFTO.Size = New System.Drawing.Size(99, 19)
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
        Me.Label1.Size = New System.Drawing.Size(121, 19)
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
        Me.Grp_Print.Controls.Add(Me.CMDEXIT2)
        Me.Grp_Print.Controls.Add(Me.CMD_WINDOWS)
        Me.Grp_Print.Controls.Add(Me.CMD_DOS)
        Me.Grp_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Print.Location = New System.Drawing.Point(340, 420)
        Me.Grp_Print.Name = "Grp_Print"
        Me.Grp_Print.Size = New System.Drawing.Size(368, 56)
        Me.Grp_Print.TabIndex = 657
        Me.Grp_Print.TabStop = False
        Me.Grp_Print.Visible = False
        '
        'CMDEXIT2
        '
        Me.CMDEXIT2.BackColor = System.Drawing.Color.Transparent
        Me.CMDEXIT2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT2.Location = New System.Drawing.Point(248, 16)
        Me.CMDEXIT2.Name = "CMDEXIT2"
        Me.CMDEXIT2.Size = New System.Drawing.Size(96, 32)
        Me.CMDEXIT2.TabIndex = 2
        Me.CMDEXIT2.Text = "EXIT"
        Me.CMDEXIT2.UseVisualStyleBackColor = False
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
        Me.CMD_WINDOWS.UseVisualStyleBackColor = False
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
        Me.CMD_DOS.UseVisualStyleBackColor = False
        '
        'cmdreport
        '
        Me.cmdreport.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.Image = CType(resources.GetObject("cmdreport.Image"), System.Drawing.Image)
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(870, 313)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(133, 65)
        Me.cmdreport.TabIndex = 665
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdreport.UseVisualStyleBackColor = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.Gainsboro
        Me.CMDEXIT.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMDEXIT.Image = CType(resources.GetObject("CMDEXIT.Image"), System.Drawing.Image)
        Me.CMDEXIT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMDEXIT.Location = New System.Drawing.Point(870, 529)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(133, 65)
        Me.CMDEXIT.TabIndex = 664
        Me.CMDEXIT.Text = "Exit [F11]"
        Me.CMDEXIT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'Cmdauth
        '
        Me.Cmdauth.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(871, 456)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(133, 65)
        Me.Cmdauth.TabIndex = 663
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdauth.UseVisualStyleBackColor = False
        '
        'Cmdbwse
        '
        Me.Cmdbwse.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmdbwse.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbwse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbwse.Location = New System.Drawing.Point(870, 384)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(133, 65)
        Me.Cmdbwse.TabIndex = 662
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdbwse.UseVisualStyleBackColor = False
        '
        'Cmdview
        '
        Me.Cmdview.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmdview.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdview.Image = CType(resources.GetObject("Cmdview.Image"), System.Drawing.Image)
        Me.Cmdview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdview.Location = New System.Drawing.Point(870, 242)
        Me.Cmdview.Name = "Cmdview"
        Me.Cmdview.Size = New System.Drawing.Size(133, 65)
        Me.Cmdview.TabIndex = 661
        Me.Cmdview.Text = "View [F9]"
        Me.Cmdview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdview.UseVisualStyleBackColor = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(708, 413)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Freeze.TabIndex = 660
        Me.Cmd_Freeze.Text = "Freeze [F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = True
        Me.Cmd_Freeze.Visible = False
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(871, 93)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(133, 65)
        Me.Cmd_Clear.TabIndex = 659
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(870, 171)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(133, 65)
        Me.Cmd_Add.TabIndex = 658
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(12, 30)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 666
        Me.ComboBox1.Visible = False
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"HALLRENT", "ARRANGEMENT ITEM", "CATERING", "BAR"})
        Me.ComboBox2.Location = New System.Drawing.Point(469, 137)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(177, 21)
        Me.ComboBox2.TabIndex = 667
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(343, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 16)
        Me.Label2.TabIndex = 668
        Me.Label2.Text = "CANCEL TYPE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PTY_CANCELLATIONMASTER
        '
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1024, 760)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.cmdreport)
        Me.Controls.Add(Me.CMDEXIT)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbwse)
        Me.Controls.Add(Me.Cmdview)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Grp_Print)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Frame2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.SSGRID)
        Me.Controls.Add(Me.GroupBox2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "PTY_CANCELLATIONMASTER"
        Me.Text = "Cancellation Master"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.SSGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Frame2.ResumeLayout(False)
        Me.Frame2.PerformLayout()
        Me.Grp_Print.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
        If ComboBox2.Text = "" Then
            MessageBox.Show("CANCELTYPE CANNOT BE BLANK ", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        End If
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
    Private Sub Cmd_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Print3.Click
        gPrint = True
        Grp_Print.Visible = True
    End Sub
    Private Sub RoomCancellationMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(sender, e)
        ElseIf e.KeyCode = Keys.F7 Then
            If Cmd_Add2.Enabled = True Then
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
        Dim head, fixed, pax As Integer
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
                    SSGRID.Text = "0.00"
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
                    SSGRID.Text = "0.00"
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
                        SSGRID.Text = "0.00"
                        SSGRID.SetActiveCell(5, i - 1)
                    End If
                    Call GetTotal()
                End If
            ElseIf SSGRID.ActiveCol = 5 Then
                SSGRID.Col = 5
                SSGRID.Row = i
                head = Val(SSGRID.Text)
                'If Val(head) <> 0 Then
                SSGRID.SetActiveCell(6, i)
                SSGRID.Focus()
                'Else
                '    SSGRID.Text = "0.00"
                '    SSGRID.SetActiveCell(5, i)
                'End If

            ElseIf SSGRID.ActiveCol = 6 Then
                SSGRID.Col = 6
                SSGRID.Row = i
                fixed = Val(SSGRID.Text)
                ' If Val(fixed) <> 0 Then
                SSGRID.SetActiveCell(7, i)
                SSGRID.Focus()
                'Else
                '    SSGRID.Text = "0.00"
                '    SSGRID.SetActiveCell(6, i)

                'End If

            ElseIf SSGRID.ActiveCol = 7 Then
                SSGRID.Col = 6
                SSGRID.Row = i
                pax = Val(SSGRID.Text)
                ' If Val(fixed) <> 0 Then
                SSGRID.SetActiveCell(1, i + 1)
                SSGRID.Focus()
                'Else
                '    SSGRID.Text = "0.00"
                '    SSGRID.SetActiveCell(7, i)
                'End If

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
    Private Sub Cmd_View_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_View2.Click
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
        Me.Cmd_Add2.Enabled = False
        Cmd_View2.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add2.Enabled = True
                    Me.Cmd_View2.Enabled = True
                    Me.Cmd_Print3.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add2.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add2.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add2.Enabled = True
                    End If
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View2.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.Cmd_Print3.Enabled = True
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
                        Cmd_Add2.Enabled = True
                        mskFrom.Enabled = True
                    Else
                        Cmd_Add2.Enabled = False
                        mskFrom.Enabled = False
                    End If
                End If
            End With
        End If
        If DateDiff(DateInterval.Day, Now, EffFrom1.Value) > 0 Then
            Cmd_Add2.Enabled = True
        ElseIf DateDiff(DateInterval.Day, Now, EffFrom1.Value) < 0 Then
            Cmd_Add2.Enabled = False
        ElseIf DateDiff(DateInterval.Day, Now, EffFrom1.Value) = 0 Then
            Cmd_Add2.Enabled = True
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
            Cmd_Add2.Text = "Add[F7]"
            mskFrom.Text = Format(CDate(vform.keyfield), "dd/MMM/yyyy")
            If vform.keyfield1 <> "" Then
                MskTo.Visible = True
                LBL_EFFTO.Visible = True
                MskTo.Text = Format(CDate(vform.keyfield1), "dd/MMM/yyyy")
                DtTo_gbl = Format(CDate(vform.keyfield1), "dd/MMM/yyyy")
                Cmd_Add2.Enabled = True
                mskFrom.Enabled = True
            Else
                MskTo.Visible = False
                LBL_EFFTO.Visible = False
                MskTo.Text = "__/__/____"
                DtTo_gbl = "01/01/1900"
                Cmd_Add2.Enabled = False
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
                If Mid(Cmd_Add2.Text, 1, 1) = "A" Then
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
                        Cmd_Add2.Text = "Add[F7]"
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
                            Cmd_Add2.Enabled = False
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
                            Me.Cmd_Add2.Text = "Update [F7]"
                            If gUserCategory <> "S" Then
                                Call GetRights()
                            End If
                        Else
                            Cmd_Add2.Text = "Add[F7]"
                        End If
                        'SSGRID.SetActiveCell(1, i + 1)
                        SSGRID.SetActiveCell(4, i)
                    End With
                End If
            End If

            If DateDiff(DateInterval.Day, Now, EffFrom1.Value) > 0 Then
                Cmd_Add2.Enabled = True
            ElseIf DateDiff(DateInterval.Day, Now, EffFrom1.Value) < 0 Then
                Cmd_Add2.Enabled = False
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
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text12")
            TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text13")
            TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
            TXTOBJ9.Text = "PhoneNo : " & gphoneno
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

   
    Private Sub PTY_CANCELLATIONMASTER_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        Me.resizeFormResolution()
        rs.ResizeAllControls(Me)
        'GetRights()
        Dim SQL As String

        ' gconnection.FocusSetting(Me)
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


        FORMLOADED = True
        Call FILLDET()
    End Sub
    Public Sub resizeFormResolution()
        Dim T, U As Integer
        Me.ResizeRedraw = True

        T = CInt(Screen.PrimaryScreen.WorkingArea.Size.Height)
        U = CInt(Screen.PrimaryScreen.WorkingArea.Size.Width)
        Me.Location = Screen.PrimaryScreen.WorkingArea.Location
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = Screen.PrimaryScreen.WorkingArea.Size
        If U = 800 Then
            T = T - 20
        End If
        If U = 1280 Then
            T = T - 20
        End If
        If U = 1360 Then
            T = T - 55
        End If
    End Sub



    Private Sub FILLDET()
        Dim SQL As String
        Dim I As Integer
        SQL = "select DISTINCT * from PARTY_CANCELLATIONMASTER  WHERE TYPE='" & Trim(ComboBox2.Text) & "' "
        gconnection.getDataSet(SQL, "MEM")
        If gdataset.Tables("MEM").Rows.Count > 0 Then
            Cmd_Add.Text = "Update[F7]"
        Else

            Cmd_Add.Text = "Add[F7]"

        End If

        SQL = "select * from PARTY_CANCELLATIONMASTER  WHERE TYPE='" & Trim(ComboBox2.Text) & "' "
        gconnection.getDataSet(Sql, "MEM")
        If gdataset.Tables("MEM").Rows.Count > 0 Then
            With SSGRID
                For I = 0 To gdataset.Tables("MEM").Rows.Count - 1
                    .Col = 1
                    .Row = I + 1
                    .Text = Trim(gdataset.Tables("MEM").Rows(I).Item("CANCELFROM"))

                    .Col = 2
                    .Row = I + 1
                    .Text = Trim(gdataset.Tables("MEM").Rows(I).Item("CANCELTO"))

                    .Col = 3
                    .Row = I + 1
                    .Text = Trim(gdataset.Tables("MEM").Rows(I).Item("CANCELTYPE"))

                    .Col = 4
                    .Row = I + 1
                    .Text = Trim(gdataset.Tables("MEM").Rows(I).Item("CANCEL_AMT_PER"))

                    .Col = 5
                    .Row = I + 1
                    .Text = Trim(gdataset.Tables("MEM").Rows(I).Item("CANCEL_AMT_HEAD"))

                    .Col = 6
                    .Row = I + 1
                    .Text = Trim(gdataset.Tables("MEM").Rows(I).Item("FIXEDAMOUNT"))

                    .Col = 7
                    .Row = I + 1
                    .Text = Trim(gdataset.Tables("MEM").Rows(I).Item("CANCELCODE"))

                    '.Col = 8
                    '.Row = I + 1
                    '.Text = Trim(gdataset.Tables("MEM").Rows(I).Item("USERNAME"))

                    '.Col = 9
                    '.Row = I + 1
                    '.Text = Trim(gdataset.Tables("MEM").Rows(I).Item("USERNAME"))

                    '.Col = 10
                    '.Row = I + 1
                    '.Text = Trim(gdataset.Tables("MEM").Rows(I).Item("USERNAME"))


                Next
                .SetActiveCell(1, 1)
                .Focus()
            End With
        End If

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
        Call FILLDET()
    End Sub

    
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim i, j, fromtime, totime, amount As Integer
        Dim HEAD, FIXED As Integer
        Dim Cancel_Type As String
        Dim insert(0) As String
        Call Checkvalidation()
        If boolchk = False Then Exit Sub
        With SSGRID
            For i = 1 To SSGRID.DataRowCnt
                sqlstring = "Insert into PARTY_CANCELLATIONMASTER_log (CancelFrom, CancelTo, CancelType, Cancel_Amt_Per,Cancel_Amt_head,"
                sqlstring = sqlstring & "FixedAmount,Book_FromDate, Freeze, Adduser, Adddate,CANCELCODE,TYPE) Values ("
                SSGRID.Col = 1
                SSGRID.Row = i
                fromtime = Val(SSGRID.Text)
                If Trim(fromtime) <> "" Then
                    fromtime = Val(SSGRID.Text)
                Else
                    fromtime = "0.00"
                End If

                sqlstring = sqlstring & Format(fromtime, "0.00") & ","

                SSGRID.Col = 2
                SSGRID.Row = i
                totime = Val(SSGRID.Text)

                If Trim(totime) <> "" Then
                    totime = Val(SSGRID.Text)
                Else
                    totime = "0.00"
                End If

                sqlstring = sqlstring & Format(totime, "0.00") & " ,'"
                SSGRID.Col = 3
                SSGRID.Row = i
                Cancel_Type = SSGRID.Text

               

                sqlstring = sqlstring & Format(Cancel_Type) & "',"

                SSGRID.Col = 4
                SSGRID.Row = i
                amount = Val(SSGRID.Text)
                If Trim(amount) <> "" Then
                    amount = Val(SSGRID.Text)
                Else
                    amount = "0.00"
                End If

                sqlstring = sqlstring & Format(amount, "0.00") & " ,"

                SSGRID.Col = 5
                SSGRID.Row = i
                HEAD = Val(SSGRID.Text)
                If Trim(HEAD) <> "" Then
                    HEAD = Val(SSGRID.Text)
                Else
                    HEAD = "0.00"
                End If

                sqlstring = sqlstring & Format(HEAD, "0.00") & " ,"
                SSGRID.Col = 6
                SSGRID.Row = i

                FIXED = Val(SSGRID.Text)
                If Trim(FIXED) <> "" Then
                    FIXED = Val(SSGRID.Text)
                Else
                    FIXED = "0.00"
                End If


                sqlstring = sqlstring & Format(FIXED, "0.00") & " ,"
                sqlstring = sqlstring & " '" & Format(CDate(mskFrom.Text), "dd/MMM/yyyy") & "', "
                sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "',"
                sqlstring = sqlstring & " '" & Format(Now(), "dd/MMM/yyyy") & "','"
                SSGRID.Col = 7
                SSGRID.Row = i
                sqlstring = sqlstring & SSGRID.Text & "','" & Trim(ComboBox2.Text) & "')"
                ReDim Preserve insert(insert.Length)
                insert(insert.Length - 1) = sqlstring
            Next i
        End With
        gconnection.MoreTrans2(insert)


        If Mid(Cmd_Add.Text, 1, 1) = "A" Then
            Call Checkvalidation()
            If boolchk = False Then Exit Sub
            sqlstring = " Update PARTY_CANCELLATIONMASTER set Book_ToDate='" & Format(DateAdd(DateInterval.Day, -1, CDate(mskFrom.Text)), "dd/MMM/yyyy") & "' where isnull(Book_ToDate,'')='' "
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring

            With SSGRID
                For i = 1 To SSGRID.DataRowCnt
                    sqlstring = "Insert into PARTY_CANCELLATIONMASTER (CancelFrom, CancelTo, CancelType, Cancel_Amt_Per,Cancel_Amt_head,"
                    sqlstring = sqlstring & "FixedAmount,Book_FromDate, Freeze, Adduser, Adddate,CANCELCODE,TYPE) Values ("
                    SSGRID.Col = 1
                    SSGRID.Row = i
                    fromtime = Val(SSGRID.Text)
                    If Trim(fromtime) <> "" Then
                        fromtime = Val(SSGRID.Text)
                    Else
                        fromtime = "0.00"
                    End If

                    sqlstring = sqlstring & Format(fromtime, "0.00") & ","
                    SSGRID.Col = 2
                    SSGRID.Row = i
                    totime = Val(SSGRID.Text)
                    If Trim(totime) <> "" Then
                        totime = Val(SSGRID.Text)
                    Else
                        totime = "0.00"
                    End If

                    sqlstring = sqlstring & Format(totime, "0.00") & " ,'"
                    SSGRID.Col = 3
                    SSGRID.Row = i
                    Cancel_Type = SSGRID.Text
                    sqlstring = sqlstring & Format(Cancel_Type) & "',"

                    SSGRID.Col = 4
                    SSGRID.Row = i
                    amount = Val(SSGRID.Text)
                    If Trim(amount) <> "" Then
                        amount = Val(SSGRID.Text)
                    Else
                        amount = "0.00"
                    End If

                    sqlstring = sqlstring & Format(amount, "0.00") & " ,"

                    SSGRID.Col = 5
                    SSGRID.Row = i
                    HEAD = Val(SSGRID.Text)
                    If Trim(HEAD) <> "" Then
                        HEAD = Val(SSGRID.Text)
                    Else
                        HEAD = "0.00"
                    End If

                    sqlstring = sqlstring & Format(HEAD, "0.00") & " ,"
                    SSGRID.Col = 6
                    SSGRID.Row = i
                    FIXED = Val(SSGRID.Text)
                    If Trim(FIXED) <> "" Then
                        FIXED = Val(SSGRID.Text)
                    Else
                        FIXED = "0.00"
                    End If


                    sqlstring = sqlstring & Format(FIXED, "0.00") & " ,"
                    sqlstring = sqlstring & " '" & Format(CDate(mskFrom.Text), "dd/MMM/yyyy") & "', "
                    sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "',"
                    sqlstring = sqlstring & " '" & Format(Now(), "dd/MMM/yyyy") & "','"
                    SSGRID.Col = 7
                    SSGRID.Row = i
                    sqlstring = sqlstring & SSGRID.Text & "','" & Trim(ComboBox2.Text) & "')"
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
            ' If First_Total <> Second_Total Then
            'd = DateDiff(DateInterval.Day, Dtfrom_gbl, CDate(mskFrom.Text))
            'If d <= 0 Then
            '    If MsgBox("From Date Range Exists", MsgBoxStyle.YesNo, "CONTINUE FROM CURRENT DATE") = MsgBoxResult.No Then
            '        Exit Sub
            '    End If
            'End If
            'sqlstring = " Update PARTY_CANCELLATIONMASTER set Book_ToDate='" & Format(DateAdd(DateInterval.Day, -1, CDate(mskFrom.Text)), "dd/MMM/yyyy") & "' where isnull(Book_ToDate,'')='' "
            'ReDim Preserve insert(insert.Length)
            'insert(insert.Length - 1) = sqlstring
            ' Else
            d = DateDiff(DateInterval.Day, Dtfrom_gbl, CDate(mskFrom.Text))
            If d < 0 Then
                MsgBox("From Date Less Then Existing", MsgBoxStyle.Critical, Me.Name)
                mskFrom.Text = "__/__/____"
                Exit Sub
            End If
            'sqlstring = " Delete From PARTY_CANCELLATIONMASTER where Book_FromDate='" & Format(Dtfrom_gbl, "dd/MMM/yyyy") & "' and isnull(Book_ToDAte,'')=isnull(Book_ToDAte,'')"
            'ReDim Preserve insert(insert.Length)
            'insert(insert.Length - 1) = sqlstring
            sqlstring = " Delete From PARTY_CANCELLATIONMASTER WHERE TYPE='" & Trim(ComboBox2.Text) & "'"
            ReDim Preserve insert(insert.Length)
            insert(insert.Length - 1) = sqlstring
            ' End If
            '----------Delete Operation Ends----------------
            With SSGRID
                For i = 1 To SSGRID.DataRowCnt
                    sqlstring = "Insert into PARTY_CANCELLATIONMASTER (CancelFrom, CancelTo, CancelType, Cancel_Amt_Per,Cancel_Amt_head,"
                    sqlstring = sqlstring & "FixedAmount,Book_FromDate, Freeze, Adduser, Adddate,CANCELCODE,TYPE) Values ("
                    SSGRID.Col = 1
                    SSGRID.Row = i
                    fromtime = Val(SSGRID.Text)
                    If Trim(fromtime) <> "" Then
                        fromtime = Val(SSGRID.Text)
                    Else
                        fromtime = "0.00"
                    End If

                    sqlstring = sqlstring & Format(fromtime, "0.00") & ","
                    SSGRID.Col = 2
                    SSGRID.Row = i
                    totime = Val(SSGRID.Text)
                    If Trim(totime) <> "" Then
                        totime = Val(SSGRID.Text)
                    Else
                        totime = "0.00"
                    End If

                    sqlstring = sqlstring & Format(totime, "0.00") & " ,'"
                    SSGRID.Col = 3
                    SSGRID.Row = i
                    Cancel_Type = SSGRID.Text
                    sqlstring = sqlstring & Format(Cancel_Type) & "',"

                    SSGRID.Col = 4
                    SSGRID.Row = i
                    amount = Val(SSGRID.Text)
                    If Trim(amount) <> "" Then
                        amount = Val(SSGRID.Text)
                    Else
                        amount = "0.00"
                    End If

                    sqlstring = sqlstring & Format(amount, "0.00") & " ,"
                    SSGRID.Col = 5
                    SSGRID.Row = i
                    HEAD = Val(SSGRID.Text)
                    If Trim(HEAD) <> "" Then
                        HEAD = Val(SSGRID.Text)
                    Else
                        HEAD = "0.00"
                    End If

                    sqlstring = sqlstring & Format(HEAD, "0.00") & " ,"
                    SSGRID.Col = 6
                    SSGRID.Row = i
                    FIXED = Val(SSGRID.Text)
                    If Trim(FIXED) <> "" Then
                        FIXED = Val(SSGRID.Text)
                    Else
                        FIXED = "0.00"
                    End If


                    sqlstring = sqlstring & Format(FIXED, "0.00") & " ,"
                    sqlstring = sqlstring & " '" & Format(CDate(mskFrom.Text), "dd/MMM/yyyy") & "', "
                    sqlstring = sqlstring & " 'N','" & Trim(gUsername) & "',"
                    sqlstring = sqlstring & " '" & Format(Now(), "dd/MMM/yyyy") & "','"
                    SSGRID.Col = 7
                    SSGRID.Row = i
                    sqlstring = sqlstring & SSGRID.Text & "','" & Trim(ComboBox2.Text) & "')"
                    ReDim Preserve insert(insert.Length)
                    insert(insert.Length - 1) = sqlstring
                Next i
            End With
            gconnection.MoreTrans(insert)
            Call Cmd_Clear_Click(sender, e)
        End If
    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
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
            TXTOBJ2.Text = "UserName : " & gUsername

            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text12")
            TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text13")
            TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
            TXTOBJ9.Text = "PhoneNo : " & gphoneno

            Viewer.Show()
            Grp_Print.Visible = False
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Exit Sub
        End If
    End Sub

   
    
    Private Sub Cmdview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdview.Click
        Dim FRM As New ReportDesigner
        'If txt_PCode.Text.Length > 0 Then
        '    tables = " FROM party_purposemaster WHERE PCODE ='" & txt_PCode.Text & "' "
        'Else
        tables = "FROM PARTY_CANCELLATIONMASTER "
        ' End If
        Gheader = "CANCELLATION  DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"CANCELFROM", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"TYPE", "14"}
        FRM.DataGridView1.Rows.Add(ROW)

        ROW = New String() {"CANCELTO", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CANCELTYPE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CANCEL_AMT_PER", "14"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"CANCEL_AMT_HEAD", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"FIXEDAMOUNT", "8"}
        FRM.DataGridView1.Rows.Add(ROW)

        ROW = New String() {"ADDDATE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSER", "15"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"FREEZE", "6"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

    Private Sub Cmdbwse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbwse.Click
        brows = True
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM PARTY_CANCELLATIONMASTER"
        gconnection.getDataSet(STRQUERY, "authorize")

        Call VIEW1.LOADGRID(gdataset.Tables("authorize"), True, "", "SELECT * FROM PARTY_CANCELLATIONMASTER", "hallcode", 1, Me.mskFrom)

    End Sub

    Private Sub Cmdauth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdauth.Click
        Dim SSQLSTR, SSQLSTR2 As String
        Dim USERT As Integer
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 1
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 2
        End If
        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
        gconnection.getDataSet(gSQLString, "AUTHORIZELUSER")
        If gdataset.Tables("AUTHORIZELUSER").Rows.Count > 0 Then
            USERT = 3
        End If
        If USERT = 1 Then
            SSQLSTR2 = " SELECT * FROM PARTY_CANCELLATIONMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PARTY_CANCELLATIONMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_CANCELLATIONMASTER set  ", "CANCELFROM", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 0)
                        End If
                    Else
                        MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                    End If
                End If
            End If
        ElseIf USERT = 2 Then
            SSQLSTR2 = " SELECT * FROM PARTY_PURPOSEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')='' AND ISNULL(AUTHORISE_USER1,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PARTY_PURPOSEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_PURPOSEMASTER set  ", "CANCELFROM", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            End If
        ElseIf USERT = 3 Then
            SSQLSTR2 = " SELECT * FROM PARTY_PURPOSEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''  AND ISNULL(AUTHORISE_USER2,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PARTY_PURPOSEMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_PURPOSEMASTER set  ", "CANCELFROM", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                        End If
                    End If
                End If
            Else
                MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    Private Sub CMDEXIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMDEXIT.Click
        Me.Close()
    End Sub

    Private Sub SSGRID_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSGRID.Advance

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        SSGRID.ClearRange(1, 1, -1, -1, True)
        Call FILLDET()
    End Sub

    Private Sub PTY_CANCELLATIONMASTER_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class
