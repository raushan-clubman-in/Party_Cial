Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.IO
Public Class party_UOMMaster
    Inherits System.Windows.Forms.Form
    Dim vseqno As Double
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim dr As DataRow
    Dim pageno As Integer
    Dim pagesize As Integer
    Dim i As Integer
    Friend WithEvents cmdhallHelp As System.Windows.Forms.Button
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmd_view As System.Windows.Forms.Button
    Friend WithEvents CMD_FREEZE As System.Windows.Forms.Button
    Friend WithEvents Cmd_Clear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
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
    Friend WithEvents txtUOMDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtUOMCode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_Clear12 As System.Windows.Forms.Button
    Friend WithEvents Cmd_View2 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze22 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Add1 As System.Windows.Forms.Button
    Friend WithEvents Cmd_Exit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents cmdhallHelp1 As System.Windows.Forms.Button
    Friend WithEvents CMD_PRINT As System.Windows.Forms.Button
    Friend WithEvents Grp_Print As System.Windows.Forms.GroupBox
    Friend WithEvents CMDEXIT As System.Windows.Forms.Button
    Friend WithEvents CMD_WINDOWS As System.Windows.Forms.Button
    Friend WithEvents CMD_DOS As System.Windows.Forms.Button
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(party_UOMMaster))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdhallHelp = New System.Windows.Forms.Button()
        Me.txtUOMCode = New System.Windows.Forms.TextBox()
        Me.txtUOMDesc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdhallHelp1 = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Cmd_Clear12 = New System.Windows.Forms.Button()
        Me.Cmd_View2 = New System.Windows.Forms.Button()
        Me.Cmd_Freeze22 = New System.Windows.Forms.Button()
        Me.Cmd_Add1 = New System.Windows.Forms.Button()
        Me.Cmd_Exit = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmdexport = New System.Windows.Forms.Button()
        Me.CMD_PRINT = New System.Windows.Forms.Button()
        Me.lbl_Freeze = New System.Windows.Forms.Label()
        Me.Grp_Print = New System.Windows.Forms.GroupBox()
        Me.CMDEXIT = New System.Windows.Forms.Button()
        Me.CMD_WINDOWS = New System.Windows.Forms.Button()
        Me.CMD_DOS = New System.Windows.Forms.Button()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.Cmd_view = New System.Windows.Forms.Button()
        Me.CMD_FREEZE = New System.Windows.Forms.Button()
        Me.Cmd_Clear = New System.Windows.Forms.Button()
        Me.Cmd_Add = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Grp_Print.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdhallHelp)
        Me.GroupBox1.Controls.Add(Me.txtUOMCode)
        Me.GroupBox1.Controls.Add(Me.txtUOMDesc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(212, 234)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(505, 144)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'cmdhallHelp
        '
        Me.cmdhallHelp.Location = New System.Drawing.Point(338, 24)
        Me.cmdhallHelp.Name = "cmdhallHelp"
        Me.cmdhallHelp.Size = New System.Drawing.Size(40, 23)
        Me.cmdhallHelp.TabIndex = 107
        Me.cmdhallHelp.Text = "?"
        Me.cmdhallHelp.UseVisualStyleBackColor = True
        '
        'txtUOMCode
        '
        Me.txtUOMCode.BackColor = System.Drawing.Color.Wheat
        Me.txtUOMCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUOMCode.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUOMCode.Location = New System.Drawing.Point(272, 24)
        Me.txtUOMCode.MaxLength = 10
        Me.txtUOMCode.Name = "txtUOMCode"
        Me.txtUOMCode.Size = New System.Drawing.Size(64, 26)
        Me.txtUOMCode.TabIndex = 0
        '
        'txtUOMDesc
        '
        Me.txtUOMDesc.BackColor = System.Drawing.Color.Wheat
        Me.txtUOMDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUOMDesc.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUOMDesc.Location = New System.Drawing.Point(272, 64)
        Me.txtUOMDesc.MaxLength = 35
        Me.txtUOMDesc.Name = "txtUOMDesc"
        Me.txtUOMDesc.Size = New System.Drawing.Size(216, 26)
        Me.txtUOMDesc.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(80, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "UOM DESCRIPTION :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 15)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "UOM CODE :"
        '
        'cmdhallHelp1
        '
        Me.cmdhallHelp1.Image = CType(resources.GetObject("cmdhallHelp1.Image"), System.Drawing.Image)
        Me.cmdhallHelp1.Location = New System.Drawing.Point(586, 160)
        Me.cmdhallHelp1.Name = "cmdhallHelp1"
        Me.cmdhallHelp1.Size = New System.Drawing.Size(23, 26)
        Me.cmdhallHelp1.TabIndex = 1
        Me.cmdhallHelp1.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(175, 69)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(178, 29)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "UOM MASTER"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Cmd_Clear12
        '
        Me.Cmd_Clear12.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Clear12.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Clear12.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear12.ForeColor = System.Drawing.Color.White
        Me.Cmd_Clear12.Image = CType(resources.GetObject("Cmd_Clear12.Image"), System.Drawing.Image)
        Me.Cmd_Clear12.Location = New System.Drawing.Point(24, 16)
        Me.Cmd_Clear12.Name = "Cmd_Clear12"
        Me.Cmd_Clear12.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Clear12.TabIndex = 0
        Me.Cmd_Clear12.Text = "Clear[F6]"
        Me.Cmd_Clear12.UseVisualStyleBackColor = False
        '
        'Cmd_View2
        '
        Me.Cmd_View2.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_View2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_View2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_View2.ForeColor = System.Drawing.Color.White
        Me.Cmd_View2.Image = CType(resources.GetObject("Cmd_View2.Image"), System.Drawing.Image)
        Me.Cmd_View2.Location = New System.Drawing.Point(624, 312)
        Me.Cmd_View2.Name = "Cmd_View2"
        Me.Cmd_View2.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_View2.TabIndex = 3
        Me.Cmd_View2.Text = " View[F9]"
        Me.Cmd_View2.UseVisualStyleBackColor = False
        Me.Cmd_View2.Visible = False
        '
        'Cmd_Freeze22
        '
        Me.Cmd_Freeze22.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Freeze22.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Freeze22.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze22.ForeColor = System.Drawing.Color.White
        Me.Cmd_Freeze22.Image = CType(resources.GetObject("Cmd_Freeze22.Image"), System.Drawing.Image)
        Me.Cmd_Freeze22.Location = New System.Drawing.Point(312, 16)
        Me.Cmd_Freeze22.Name = "Cmd_Freeze22"
        Me.Cmd_Freeze22.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Freeze22.TabIndex = 2
        Me.Cmd_Freeze22.Text = "Freeze[F8]"
        Me.Cmd_Freeze22.UseVisualStyleBackColor = False
        '
        'Cmd_Add1
        '
        Me.Cmd_Add1.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add1.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add1.Image = CType(resources.GetObject("Cmd_Add1.Image"), System.Drawing.Image)
        Me.Cmd_Add1.Location = New System.Drawing.Point(168, 16)
        Me.Cmd_Add1.Name = "Cmd_Add1"
        Me.Cmd_Add1.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add1.TabIndex = 1
        Me.Cmd_Add1.Text = "Add [F7]"
        Me.Cmd_Add1.UseVisualStyleBackColor = False
        '
        'Cmd_Exit
        '
        Me.Cmd_Exit.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Exit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Exit.ForeColor = System.Drawing.Color.White
        Me.Cmd_Exit.Image = CType(resources.GetObject("Cmd_Exit.Image"), System.Drawing.Image)
        Me.Cmd_Exit.Location = New System.Drawing.Point(576, 16)
        Me.Cmd_Exit.Name = "Cmd_Exit"
        Me.Cmd_Exit.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Exit.TabIndex = 4
        Me.Cmd_Exit.Text = "Exit[F11]"
        Me.Cmd_Exit.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.cmdexport)
        Me.GroupBox2.Controls.Add(Me.Cmd_Clear12)
        Me.GroupBox2.Controls.Add(Me.Cmd_Freeze22)
        Me.GroupBox2.Controls.Add(Me.Cmd_Add1)
        Me.GroupBox2.Controls.Add(Me.Cmd_Exit)
        Me.GroupBox2.Location = New System.Drawing.Point(80, 480)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(720, 56)
        Me.GroupBox2.TabIndex = 3
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
        Me.cmdexport.Location = New System.Drawing.Point(448, 16)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(104, 32)
        Me.cmdexport.TabIndex = 435
        Me.cmdexport.Text = "Report[F10]"
        Me.cmdexport.UseVisualStyleBackColor = False
        '
        'CMD_PRINT
        '
        Me.CMD_PRINT.BackColor = System.Drawing.Color.ForestGreen
        Me.CMD_PRINT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMD_PRINT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_PRINT.ForeColor = System.Drawing.Color.White
        Me.CMD_PRINT.Image = CType(resources.GetObject("CMD_PRINT.Image"), System.Drawing.Image)
        Me.CMD_PRINT.Location = New System.Drawing.Point(744, 312)
        Me.CMD_PRINT.Name = "CMD_PRINT"
        Me.CMD_PRINT.Size = New System.Drawing.Size(104, 32)
        Me.CMD_PRINT.TabIndex = 5
        Me.CMD_PRINT.Text = "Print[F10]"
        Me.CMD_PRINT.UseVisualStyleBackColor = False
        Me.CMD_PRINT.Visible = False
        '
        'lbl_Freeze
        '
        Me.lbl_Freeze.AutoSize = True
        Me.lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.lbl_Freeze.Location = New System.Drawing.Point(312, 448)
        Me.lbl_Freeze.Name = "lbl_Freeze"
        Me.lbl_Freeze.Size = New System.Drawing.Size(171, 22)
        Me.lbl_Freeze.TabIndex = 78
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.lbl_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_Freeze.Visible = False
        '
        'Grp_Print
        '
        Me.Grp_Print.BackColor = System.Drawing.Color.Transparent
        Me.Grp_Print.Controls.Add(Me.CMDEXIT)
        Me.Grp_Print.Controls.Add(Me.CMD_WINDOWS)
        Me.Grp_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grp_Print.Location = New System.Drawing.Point(224, 384)
        Me.Grp_Print.Name = "Grp_Print"
        Me.Grp_Print.Size = New System.Drawing.Size(368, 56)
        Me.Grp_Print.TabIndex = 663
        Me.Grp_Print.TabStop = False
        Me.Grp_Print.Visible = False
        '
        'CMDEXIT
        '
        Me.CMDEXIT.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMDEXIT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMDEXIT.Location = New System.Drawing.Point(216, 16)
        Me.CMDEXIT.Name = "CMDEXIT"
        Me.CMDEXIT.Size = New System.Drawing.Size(96, 32)
        Me.CMDEXIT.TabIndex = 2
        Me.CMDEXIT.Text = "EXIT"
        Me.CMDEXIT.UseVisualStyleBackColor = False
        '
        'CMD_WINDOWS
        '
        Me.CMD_WINDOWS.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.CMD_WINDOWS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_WINDOWS.Location = New System.Drawing.Point(40, 16)
        Me.CMD_WINDOWS.Name = "CMD_WINDOWS"
        Me.CMD_WINDOWS.Size = New System.Drawing.Size(96, 32)
        Me.CMD_WINDOWS.TabIndex = 1
        Me.CMD_WINDOWS.Text = "WINDOWS"
        Me.CMD_WINDOWS.UseVisualStyleBackColor = False
        '
        'CMD_DOS
        '
        Me.CMD_DOS.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CMD_DOS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_DOS.Location = New System.Drawing.Point(96, 272)
        Me.CMD_DOS.Name = "CMD_DOS"
        Me.CMD_DOS.Size = New System.Drawing.Size(96, 32)
        Me.CMD_DOS.TabIndex = 0
        Me.CMD_DOS.Text = "DOS"
        Me.CMD_DOS.UseVisualStyleBackColor = False
        Me.CMD_DOS.Visible = False
        '
        'cmdreport
        '
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(850, 382)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(144, 65)
        Me.cmdreport.TabIndex = 671
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(850, 583)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 65)
        Me.Button1.TabIndex = 670
        Me.Button1.Text = "Exit [F11]"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Cmdauth
        '
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(850, 517)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(144, 65)
        Me.Cmdauth.TabIndex = 669
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.UseVisualStyleBackColor = True
        '
        'Cmdbwse
        '
        Me.Cmdbwse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbwse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbwse.Location = New System.Drawing.Point(850, 449)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(144, 65)
        Me.Cmdbwse.TabIndex = 668
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.UseVisualStyleBackColor = True
        '
        'Cmd_view
        '
        Me.Cmd_view.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_view.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_view.Image = CType(resources.GetObject("Cmd_view.Image"), System.Drawing.Image)
        Me.Cmd_view.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_view.Location = New System.Drawing.Point(850, 313)
        Me.Cmd_view.Name = "Cmd_view"
        Me.Cmd_view.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_view.TabIndex = 667
        Me.Cmd_view.Text = "View [F9]"
        Me.Cmd_view.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_view.UseVisualStyleBackColor = True
        '
        'CMD_FREEZE
        '
        Me.CMD_FREEZE.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_FREEZE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CMD_FREEZE.Image = CType(resources.GetObject("CMD_FREEZE.Image"), System.Drawing.Image)
        Me.CMD_FREEZE.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMD_FREEZE.Location = New System.Drawing.Point(850, 245)
        Me.CMD_FREEZE.Name = "CMD_FREEZE"
        Me.CMD_FREEZE.Size = New System.Drawing.Size(144, 65)
        Me.CMD_FREEZE.TabIndex = 666
        Me.CMD_FREEZE.Text = "Freeze [F8]"
        Me.CMD_FREEZE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMD_FREEZE.UseVisualStyleBackColor = True
        '
        'Cmd_Clear
        '
        Me.Cmd_Clear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Clear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Clear.Image = CType(resources.GetObject("Cmd_Clear.Image"), System.Drawing.Image)
        Me.Cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Clear.Location = New System.Drawing.Point(858, 103)
        Me.Cmd_Clear.Name = "Cmd_Clear"
        Me.Cmd_Clear.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Clear.TabIndex = 665
        Me.Cmd_Clear.Text = "Clear [F6]"
        Me.Cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Clear.UseVisualStyleBackColor = True
        '
        'Cmd_Add
        '
        Me.Cmd_Add.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Add.Location = New System.Drawing.Point(858, 174)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Add.TabIndex = 664
        Me.Cmd_Add.Text = "Add [F7]"
        Me.Cmd_Add.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Add.UseVisualStyleBackColor = True
        '
        'party_UOMMaster
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1014, 731)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdreport)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbwse)
        Me.Controls.Add(Me.Cmd_view)
        Me.Controls.Add(Me.CMD_FREEZE)
        Me.Controls.Add(Me.Cmd_Clear)
        Me.Controls.Add(Me.Cmd_Add)
        Me.Controls.Add(Me.Grp_Print)
        Me.Controls.Add(Me.lbl_Freeze)
        Me.Controls.Add(Me.cmdhallHelp1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CMD_PRINT)
        Me.Controls.Add(Me.Cmd_View2)
        Me.Controls.Add(Me.CMD_DOS)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.Name = "party_UOMMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UOM MASTER"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Grp_Print.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub txtUOMCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUOMCode.KeyPress
        'getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtUOMCode.Text) <> "" Then
                Call txtUOMCode_Validated(txtUOMCode, e)
                txtUOMDesc.Focus()
            Else
                Call cmdhallHelp_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub txtUOMDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUOMDesc.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If txtUOMDesc.Text <> "" Then
                Cmd_Add.Focus()
            End If
        End If
    End Sub
    Private Sub txtUOMCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUOMCode.Validated
        Dim Fre As String
        If Trim(txtUOMCode.Text) <> "" Then
            Dim ds As New DataSet
            vseqno = GetSeqno(txtUOMCode.Text)
            sqlstring = "SELECT * FROM party_UOMMaster WHERE UOMSeqno=" & Val(vseqno)
            gconnection.getDataSet(sqlstring, "party_UOMMaster")
            If gdataset.Tables("party_UOMMaster").Rows.Count > 0 Then
                txtUOMDesc.Clear()
                txtUOMDesc.Text = gdataset.Tables("party_UOMMaster").Rows(0).Item("UOMDesc")
                If gdataset.Tables("party_UOMMaster").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("party_UOMMaster").Rows(0).Item("AddDateTime")), "dd-MMM-yyyy")
                    Me.CMD_FREEZE.Text = "UnFreeze[F8]"
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.CMD_FREEZE.Text = "Freeze[F8]"
                End If
                Me.Cmd_Add.Text = "Update[F7]"
                If gUserCategory <> "S" Then
                    Call GetRights()
                End If
                Me.txtUOMCode.Enabled = False
                Me.cmdhallHelp.Enabled = False
                Me.txtUOMDesc.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                txtUOMCode.ReadOnly = False
                txtUOMDesc.Focus()
            End If
        Else
            txtUOMCode.Text = ""
            txtUOMDesc.Focus()
        End If
    End Sub

    Private Sub party_UOMMaster_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F8 Then
            Call Cmd_Freeze_Click(Cmd_Freeze22, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then
            Call Cmd_Add_Click(Cmd_Add, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F10 Then
            Call cmdexport_Click(cmdexport, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F9 Then
            Call Cmd_View_Click(Cmd_View2, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub

        End If
    End Sub
    Private Sub party_UOMMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        txtUOMCode.ReadOnly = False
        cmdhallHelp.Enabled = True
        txtUOMCode.Focus()
        UOMMastbool = True
        If gUserCategory <> "S" Then
            Call GetRights()
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
        Me.Cmd_Add1.Enabled = False
        Me.Cmd_Freeze22.Enabled = False
        Cmd_View2.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add1.Enabled = True
                    Me.Cmd_Freeze22.Enabled = True
                    Me.Cmd_View2.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.Cmd_Add1.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.Cmd_Add1.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.Cmd_Add1.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    Me.Cmd_Freeze22.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmd_View2.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub txtUOMCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUOMCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdhallHelp1.Enabled = True Then
                Search = Trim(txtUOMCode.Text)
                Call cmdhallHelp_Click(txtUOMCode, e)
            End If
        End If
    End Sub
    Private Sub party_UOMMaster_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        UOMMastbool = False
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub
    Public Sub checkValidation()
        boolchk = False
        '''********** Check  Store Code Can't be blank *********************'''
        If Trim(txtUOMCode.Text) = "" Then
            MessageBox.Show(" UOM Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUOMCode.Focus()
            Exit Sub
        End If
        '''********** Check  Store desc Can't be blank *********************'''
        If Trim(txtUOMDesc.Text) = "" Then
            MessageBox.Show(" UOM Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtUOMDesc.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub

    Private Sub CMD_PRINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_PRINT.Click
        gPrint = True
        Grp_Print.Visible = True
    End Sub
    Private Sub CMD_WINDOWS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_WINDOWS.Click

    End Sub
    Private Sub CMD_DOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_DOS.Click
        Dim i, j As Integer
        Dim Type() As String
        Dim tablename As String
        Dim typename As String
        Dim heading As String
        Dim str As String
        heading = "UOM MASTER"
        str = "SELECT * from VIEW_PARTY_UOMHISTORY"
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
            Filewrite.WriteLine("SNO UOM CODE  UOM DESCRIPTION       FREEZE ADDUSER         ADDDATETIME")
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
            gconnection.getDataSet(SQLSTRING, "roomcompanymasterhistory")
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
                    SSQL = SSQL & Space(1) & Mid(Format(dr("UOMCODE"), ""), 1, 10) & Space(10 - Len(Mid(Format(dr("UOMCODE"), ""), 1, 10)))
                    SSQL = SSQL & Space(1) & Mid(Format(dr("UOMDESC"), ""), 1, 25) & Space(25 - Len(Mid(Format(dr("UOMDESC"), ""), 1, 25)))
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
        gPrint = False
        Grp_Print.Visible = True
    End Sub

    Private Sub txtUOMCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUOMCode.TextChanged

    End Sub


    Private Sub cmdhallHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdhallHelp.Click
        Dim vform As New LIST_OPERATION1
        gSQLString = "SELECT ISNULL(UOMCODE,'') AS UOMCODE,ISNULL(UOMDESC,'') AS UOMDESC FROM party_UOMMaster"
        If Trim(Search) = " " Then
            M_WhereCondition = ""
        Else
            M_WhereCondition = ""
        End If
        vform.Field = "UOMCODE,UOMDESC"
        vform.vFormatstring = "            UOM CODE                 |                  UOM DESCRIPTION                             "
        vform.vCaption = "UOM MASTER HELP"
        'vform.KeyPos = 0
        'vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            txtUOMCode.Text = Trim(vform.keyfield & "")
            txtUOMCode.Select()
            Call txtUOMCode_Validated(txtUOMCode, e)
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Dim Viewer As New ReportViwer
        Dim STR As String
        Dim r As New RPT_MAS_UOMHISTORY
        STR = "SELECT * FROM VIEW_PARTY_UOMHISTORY"
        Viewer.ssql = STR
        gconnection.getDataSet(STR, "uom")
        If gdataset.Tables("uom").Rows.Count > 0 Then
            Viewer.Report = r
            Viewer.TableName = "VIEW_PARTY_UOMHISTORY"
            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text6")
            textobj1.Text = MyCompanyName
            Dim TXTOBJ2 As TextObject
            TXTOBJ2 = r.ReportDefinition.ReportObjects("Text9")
            TXTOBJ2.Text = gUsername
            Viewer.Show()
            Grp_Print.Visible = False
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub Cmdbwse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbwse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM party_UOMMaster"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "MENUMASTER", "SELECT * FROM party_UOMMaster", "uomcode", 0)

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
            SSQLSTR2 = " SELECT * FROM party_UOMMaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM party_UOMMaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE party_UOMMaster set  ", "uomcode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 0)
                        End If
                    Else
                        MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                    End If
                End If
            End If
        ElseIf USERT = 2 Then
            SSQLSTR2 = " SELECT * FROM party_UOMMaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')='' AND ISNULL(AUTHORISE_USER1,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM party_UOMMaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE party_UOMMaster set  ", "uomcode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            End If
        ElseIf USERT = 3 Then
            SSQLSTR2 = " SELECT * FROM party_UOMMaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''  AND ISNULL(AUTHORISE_USER2,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM party_UOMMaster WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE party_UOMMaster set  ", "uomcode", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                        End If
                    End If
                End If
            Else
                MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
            End If
        End If

    End Sub


    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.txtUOMCode.ReadOnly = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.CMD_FREEZE.Text = "Freeze[F8]"
        Cmd_Add.Text = "Add [F7]"
        txtUOMCode.Enabled = True
        txtUOMCode.ReadOnly = False
        txtUOMDesc.ReadOnly = False
        txtUOMCode.Text = ""
        txtUOMDesc.Text = ""
        cmdhallHelp.Enabled = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        txtUOMCode.Focus()
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() '''--->Check Validation
            If boolchk = False Then Exit Sub

            strSQL = " INSERT INTO party_UOMMaster_LOG (UOMCode,UOMDesc,UOMSeqno,Freeze,AddUser,AddDatetime)"
            strSQL = strSQL & " VALUES ( '" & Trim(txtUOMCode.Text) & "','" & Replace(Trim(txtUOMDesc.Text), "'", "") & "',"
            strSQL = strSQL & "" & Val(vseqno) & ","
            strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            gconnection.dataOperation(6, strSQL, "party_UOMMaster")



            vseqno = GetSeqno(txtUOMCode.Text)
            strSQL = " INSERT INTO party_UOMMaster (UOMCode,UOMDesc,UOMSeqno,Freeze,AddUser,AddDatetime)"
            strSQL = strSQL & " VALUES ( '" & Trim(txtUOMCode.Text) & "','" & Replace(Trim(txtUOMDesc.Text), "'", "") & "',"
            strSQL = strSQL & "" & Val(vseqno) & ","
            strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            gconnection.dataOperation(1, strSQL, "party_UOMMaster")
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
            strSQL = "UPDATE  party_UOMMaster "
            strSQL = strSQL & " SET UOMDesc='" & Replace(Trim(txtUOMDesc.Text), "'", "") & "',"
            strSQL = strSQL & " UPDATEUser='" & Trim(gUsername) & "',UPDATEtime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
            strSQL = strSQL & " WHERE UOMCode = '" & Trim(txtUOMCode.Text) & "'"
            gconnection.dataOperation(2, strSQL, "party_UOMMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Cmd_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_view.Click
        Dim FRM As New ReportDesigner
        If txtUOMCode.Text.Length > 0 Then
            tables = " FROM party_uomMASTER WHERE groupcode ='" & txtUOMCode.Text & "' "
        Else
            tables = "FROM party_uomMASTER "
        End If
        Gheader = "UOM DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"UOMCODE", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UOMDESC", "20"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"FREEZE", "7"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"AddDatetime", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATEUSER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPDATETIME", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

   
   
    Private Sub CMD_FREEZE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMD_FREEZE.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        Dim STRSQL As String
        strSQL = " INSERT INTO party_UOMMaster (UOMCode,UOMDesc,UOMSeqno,Freeze,AddUser,AddDatetime)"
        strSQL = strSQL & " VALUES ( '" & Trim(txtUOMCode.Text) & "','" & Replace(Trim(txtUOMDesc.Text), "'", "") & "',"
        strSQL = strSQL & "" & Val(vseqno) & ","
        strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
        gconnection.dataOperation(6, STRSQL, "party_UOMMaster")

        If Mid(Me.CMD_FREEZE.Text, 1, 1) = "F" Then
            sqlstring = "UPDATE  party_UOMMaster "
            sqlstring = sqlstring & " SET Freeze= 'Y',AddUser='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE UOMCode = '" & Trim(txtUOMCode.Text) & "'"
            gconnection.dataOperation(3, sqlstring, "party_UOMMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add1.Text = "Add [F7]"
        Else
            sqlstring = "UPDATE  party_UOMMaster "
            sqlstring = sqlstring & " SET Freeze= 'N',VOIDUser='" & gUsername & " ', VOIDDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            sqlstring = sqlstring & " WHERE UOMCode = '" & Trim(txtUOMCode.Text) & "'"
            gconnection.dataOperation(4, sqlstring, "party_UOMMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If

    End Sub

    Private Sub txtUOMDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUOMDesc.TextChanged

    End Sub

    Private Sub txtUOMCode_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUOMCode.VisibleChanged

    End Sub
End Class