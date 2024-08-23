Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Public Class ReceiptRegister
    Inherits System.Windows.Forms.Form
    Dim sqlstring As String
    Dim chkbool As Boolean
    Dim vconn As New GlobalClass
    Dim gconn As New GlobalClass
    Dim DT As DataTable
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_ToBooking As System.Windows.Forms.TextBox
    Friend WithEvents Txt_FromBooking As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Rdb_Book As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb_Date As System.Windows.Forms.RadioButton
    Dim gconnection As New GlobalClass
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chklist_Rooms As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents Chk_roomselection As System.Windows.Forms.CheckBox
    Friend WithEvents Dtpbookfromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpbooktodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CHBCANCEL As System.Windows.Forms.CheckBox
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents CHK_catering As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_maintanance As System.Windows.Forms.CheckBox
    Friend WithEvents Chk_final As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_BAREXP As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents rece_reg As System.Windows.Forms.CheckBox
    Friend WithEvents ChK_REFUND As System.Windows.Forms.CheckBox
    Friend WithEvents CHK_PENDINGBILL As System.Windows.Forms.CheckBox
    Friend WithEvents rec_sum As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReceiptRegister))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.CmdView = New System.Windows.Forms.Button()
        Me.CmdPrint = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Chk_roomselection = New System.Windows.Forms.CheckBox()
        Me.chklist_Rooms = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Dtpbookfromdate = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpbooktodate = New System.Windows.Forms.DateTimePicker()
        Me.CHBCANCEL = New System.Windows.Forms.CheckBox()
        Me.CHK_catering = New System.Windows.Forms.CheckBox()
        Me.Chk_maintanance = New System.Windows.Forms.CheckBox()
        Me.Chk_final = New System.Windows.Forms.CheckBox()
        Me.CHK_BAREXP = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.rece_reg = New System.Windows.Forms.CheckBox()
        Me.ChK_REFUND = New System.Windows.Forms.CheckBox()
        Me.CHK_PENDINGBILL = New System.Windows.Forms.CheckBox()
        Me.rec_sum = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Txt_ToBooking = New System.Windows.Forms.TextBox()
        Me.Txt_FromBooking = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Rdb_Book = New System.Windows.Forms.RadioButton()
        Me.Rdb_Date = New System.Windows.Forms.RadioButton()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Maroon
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(928, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(176, 24)
        Me.Label2.TabIndex = 429
        Me.Label2.Text = "HALL CODE"
        Me.Label2.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(349, 497)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(331, 16)
        Me.Label5.TabIndex = 428
        Me.Label5.Text = "Press F2 to select all / Press ENTER key to navigate"
        Me.Label5.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.cmdexit)
        Me.GroupBox4.Controls.Add(Me.cmdreport)
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Controls.Add(Me.CmdView)
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(855, 132)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(145, 404)
        Me.GroupBox4.TabIndex = 427
        Me.GroupBox4.TabStop = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.Black
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(5, 270)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(134, 50)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "Exit[F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'cmdreport
        '
        Me.cmdreport.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ForeColor = System.Drawing.Color.Black
        Me.cmdreport.Image = CType(resources.GetObject("cmdreport.Image"), System.Drawing.Image)
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(6, 207)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(134, 50)
        Me.cmdreport.TabIndex = 9
        Me.cmdreport.Text = "Export"
        Me.cmdreport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdreport.UseVisualStyleBackColor = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Gainsboro
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.Black
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(7, 81)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(133, 50)
        Me.CmdClear.TabIndex = 6
        Me.CmdClear.Text = "Clear[F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.Gainsboro
        Me.CmdView.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.Black
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdView.Location = New System.Drawing.Point(7, 144)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(133, 50)
        Me.CmdView.TabIndex = 5
        Me.CmdView.Text = "Report [F9]"
        Me.CmdView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdView.UseVisualStyleBackColor = False
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.DimGray
        Me.CmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdPrint.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.White
        Me.CmdPrint.Image = CType(resources.GetObject("CmdPrint.Image"), System.Drawing.Image)
        Me.CmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdPrint.Location = New System.Drawing.Point(439, 606)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(134, 56)
        Me.CmdPrint.TabIndex = 7
        Me.CmdPrint.Text = " Print [F8]"
        Me.CmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdPrint.UseVisualStyleBackColor = False
        Me.CmdPrint.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(174, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(306, 29)
        Me.Label3.TabIndex = 424
        Me.Label3.Text = "BANQUET BILL DETAILS "
        '
        'Chk_roomselection
        '
        Me.Chk_roomselection.BackColor = System.Drawing.Color.Transparent
        Me.Chk_roomselection.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_roomselection.Location = New System.Drawing.Point(928, 64)
        Me.Chk_roomselection.Name = "Chk_roomselection"
        Me.Chk_roomselection.Size = New System.Drawing.Size(56, 24)
        Me.Chk_roomselection.TabIndex = 0
        Me.Chk_roomselection.Text = "SELECT ALL "
        Me.Chk_roomselection.UseVisualStyleBackColor = False
        Me.Chk_roomselection.Visible = False
        '
        'chklist_Rooms
        '
        Me.chklist_Rooms.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklist_Rooms.Location = New System.Drawing.Point(1006, 120)
        Me.chklist_Rooms.Name = "chklist_Rooms"
        Me.chklist_Rooms.Size = New System.Drawing.Size(98, 327)
        Me.chklist_Rooms.TabIndex = 1
        Me.chklist_Rooms.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Dtpbookfromdate)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.dtpbooktodate)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(199, 204)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(602, 64)
        Me.GroupBox3.TabIndex = 431
        Me.GroupBox3.TabStop = False
        '
        'Dtpbookfromdate
        '
        Me.Dtpbookfromdate.CustomFormat = "dd/MM/yyyy"
        Me.Dtpbookfromdate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtpbookfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpbookfromdate.Location = New System.Drawing.Point(168, 23)
        Me.Dtpbookfromdate.Name = "Dtpbookfromdate"
        Me.Dtpbookfromdate.Size = New System.Drawing.Size(120, 22)
        Me.Dtpbookfromdate.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(294, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "TO DATE :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "FROM DATE :"
        '
        'dtpbooktodate
        '
        Me.dtpbooktodate.CustomFormat = "dd/MM/yyyy"
        Me.dtpbooktodate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpbooktodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpbooktodate.Location = New System.Drawing.Point(382, 22)
        Me.dtpbooktodate.Name = "dtpbooktodate"
        Me.dtpbooktodate.Size = New System.Drawing.Size(120, 22)
        Me.dtpbooktodate.TabIndex = 4
        '
        'CHBCANCEL
        '
        Me.CHBCANCEL.BackColor = System.Drawing.Color.Transparent
        Me.CHBCANCEL.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHBCANCEL.Location = New System.Drawing.Point(600, 416)
        Me.CHBCANCEL.Name = "CHBCANCEL"
        Me.CHBCANCEL.Size = New System.Drawing.Size(168, 24)
        Me.CHBCANCEL.TabIndex = 2
        Me.CHBCANCEL.Text = "HALL CANCEL"
        Me.CHBCANCEL.UseVisualStyleBackColor = False
        Me.CHBCANCEL.Visible = False
        '
        'CHK_catering
        '
        Me.CHK_catering.BackColor = System.Drawing.Color.Transparent
        Me.CHK_catering.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_catering.Location = New System.Drawing.Point(203, 289)
        Me.CHK_catering.Name = "CHK_catering"
        Me.CHK_catering.Size = New System.Drawing.Size(144, 24)
        Me.CHK_catering.TabIndex = 442
        Me.CHK_catering.Text = "BILL DETAILS"
        Me.CHK_catering.UseVisualStyleBackColor = False
        '
        'Chk_maintanance
        '
        Me.Chk_maintanance.BackColor = System.Drawing.Color.Transparent
        Me.Chk_maintanance.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_maintanance.Location = New System.Drawing.Point(248, 416)
        Me.Chk_maintanance.Name = "Chk_maintanance"
        Me.Chk_maintanance.Size = New System.Drawing.Size(232, 24)
        Me.Chk_maintanance.TabIndex = 443
        Me.Chk_maintanance.Text = "MAINTANANCE CHARGE"
        Me.Chk_maintanance.UseVisualStyleBackColor = False
        Me.Chk_maintanance.Visible = False
        '
        'Chk_final
        '
        Me.Chk_final.BackColor = System.Drawing.Color.Transparent
        Me.Chk_final.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_final.Location = New System.Drawing.Point(352, 290)
        Me.Chk_final.Name = "Chk_final"
        Me.Chk_final.Size = New System.Drawing.Size(192, 24)
        Me.Chk_final.TabIndex = 444
        Me.Chk_final.Text = "FINAL BILL REPORT"
        Me.Chk_final.UseVisualStyleBackColor = False
        '
        'CHK_BAREXP
        '
        Me.CHK_BAREXP.BackColor = System.Drawing.Color.Transparent
        Me.CHK_BAREXP.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_BAREXP.Location = New System.Drawing.Point(496, 416)
        Me.CHK_BAREXP.Name = "CHK_BAREXP"
        Me.CHK_BAREXP.Size = New System.Drawing.Size(192, 24)
        Me.CHK_BAREXP.TabIndex = 442
        Me.CHK_BAREXP.Text = "BAR EXPENDITURE"
        Me.CHK_BAREXP.UseVisualStyleBackColor = False
        Me.CHK_BAREXP.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(48, 416)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(184, 24)
        Me.CheckBox1.TabIndex = 445
        Me.CheckBox1.Text = "ADDTIONAL ITEMS"
        Me.CheckBox1.UseVisualStyleBackColor = False
        Me.CheckBox1.Visible = False
        '
        'rece_reg
        '
        Me.rece_reg.BackColor = System.Drawing.Color.Transparent
        Me.rece_reg.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rece_reg.Location = New System.Drawing.Point(596, 346)
        Me.rece_reg.Name = "rece_reg"
        Me.rece_reg.Size = New System.Drawing.Size(192, 24)
        Me.rece_reg.TabIndex = 446
        Me.rece_reg.Text = "RECEIPT REGISTER"
        Me.rece_reg.UseVisualStyleBackColor = False
        '
        'ChK_REFUND
        '
        Me.ChK_REFUND.BackColor = System.Drawing.Color.Transparent
        Me.ChK_REFUND.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChK_REFUND.Location = New System.Drawing.Point(352, 346)
        Me.ChK_REFUND.Name = "ChK_REFUND"
        Me.ChK_REFUND.Size = New System.Drawing.Size(238, 24)
        Me.ChK_REFUND.TabIndex = 447
        Me.ChK_REFUND.Text = "RECEIPT REFUND  REGISTER"
        Me.ChK_REFUND.UseVisualStyleBackColor = False
        '
        'CHK_PENDINGBILL
        '
        Me.CHK_PENDINGBILL.BackColor = System.Drawing.Color.Transparent
        Me.CHK_PENDINGBILL.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHK_PENDINGBILL.Location = New System.Drawing.Point(203, 346)
        Me.CHK_PENDINGBILL.Name = "CHK_PENDINGBILL"
        Me.CHK_PENDINGBILL.Size = New System.Drawing.Size(144, 24)
        Me.CHK_PENDINGBILL.TabIndex = 448
        Me.CHK_PENDINGBILL.Text = "PENDINGBILL"
        Me.CHK_PENDINGBILL.UseVisualStyleBackColor = False
        '
        'rec_sum
        '
        Me.rec_sum.BackColor = System.Drawing.Color.Transparent
        Me.rec_sum.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rec_sum.Location = New System.Drawing.Point(596, 290)
        Me.rec_sum.Name = "rec_sum"
        Me.rec_sum.Size = New System.Drawing.Size(231, 24)
        Me.rec_sum.TabIndex = 449
        Me.rec_sum.Text = "RECEIPT SUMMARY  REGISTER"
        Me.rec_sum.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Txt_ToBooking)
        Me.GroupBox1.Controls.Add(Me.Txt_FromBooking)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(201, 145)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(602, 64)
        Me.GroupBox1.TabIndex = 450
        Me.GroupBox1.TabStop = False
        '
        'Txt_ToBooking
        '
        Me.Txt_ToBooking.Location = New System.Drawing.Point(386, 24)
        Me.Txt_ToBooking.Name = "Txt_ToBooking"
        Me.Txt_ToBooking.Size = New System.Drawing.Size(93, 22)
        Me.Txt_ToBooking.TabIndex = 5
        '
        'Txt_FromBooking
        '
        Me.Txt_FromBooking.Location = New System.Drawing.Point(170, 23)
        Me.Txt_FromBooking.Name = "Txt_FromBooking"
        Me.Txt_FromBooking.Size = New System.Drawing.Size(93, 22)
        Me.Txt_FromBooking.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(294, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "TO Booking :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(56, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "FROM Booking :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Rdb_Book)
        Me.GroupBox2.Controls.Add(Me.Rdb_Date)
        Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(204, 102)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(270, 37)
        Me.GroupBox2.TabIndex = 451
        Me.GroupBox2.TabStop = False
        '
        'Rdb_Book
        '
        Me.Rdb_Book.AutoSize = True
        Me.Rdb_Book.Location = New System.Drawing.Point(137, 12)
        Me.Rdb_Book.Name = "Rdb_Book"
        Me.Rdb_Book.Size = New System.Drawing.Size(130, 20)
        Me.Rdb_Book.TabIndex = 1
        Me.Rdb_Book.TabStop = True
        Me.Rdb_Book.Text = "BookingNo Wise"
        Me.Rdb_Book.UseVisualStyleBackColor = True
        '
        'Rdb_Date
        '
        Me.Rdb_Date.AutoSize = True
        Me.Rdb_Date.Location = New System.Drawing.Point(6, 11)
        Me.Rdb_Date.Name = "Rdb_Date"
        Me.Rdb_Date.Size = New System.Drawing.Size(86, 20)
        Me.Rdb_Date.TabIndex = 0
        Me.Rdb_Date.TabStop = True
        Me.Rdb_Date.Text = "DateWise"
        Me.Rdb_Date.UseVisualStyleBackColor = True
        '
        'ReceiptRegister
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.CmdPrint)
        Me.Controls.Add(Me.rec_sum)
        Me.Controls.Add(Me.CHK_PENDINGBILL)
        Me.Controls.Add(Me.ChK_REFUND)
        Me.Controls.Add(Me.rece_reg)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Chk_final)
        Me.Controls.Add(Me.Chk_maintanance)
        Me.Controls.Add(Me.CHK_catering)
        Me.Controls.Add(Me.CHBCANCEL)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Chk_roomselection)
        Me.Controls.Add(Me.chklist_Rooms)
        Me.Controls.Add(Me.CHK_BAREXP)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "ReceiptRegister"
        Me.Text = "BANQUET BILL  REPORTS"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND                 MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        vconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdView.Enabled = False
        Me.CmdPrint.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdView.Enabled = True
                    Me.CmdPrint.Enabled = True
                    Exit Sub
                End If
                If Right(x) = "V" Then
                    Me.CmdView.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.CmdPrint.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub ReceiptRegister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        Me.resizeFormResolution()
        rs.ResizeAllControls(Me)
        'gconnection.FocusSetting(Me)
        Call FillhallLocation()
        Rdb_Date.Checked = True
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        CmdClear_Click(sender, e)
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
    Private Sub FillhallLocation()
        Dim i As Integer
        chklist_Rooms.Items.Clear()
        sqlstring = "SELECT DISTINCT HALLTYPECODE,HALLTYPEDESC FROM PARTY_HALLMASTER_HDR "
        vconn.getDataSet(sqlstring, "HALL")
        If gdataset.Tables("HALL").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("HALL").Rows.Count - 1
                With gdataset.Tables("HALL").Rows(i)
                    chklist_Rooms.Items.Add(.Item("HALLTYPECODE") & "-->" & .Item("HALLTYPEDESC"))
                End With
            Next i
        End If
        chklist_Rooms.Sorted = True
    End Sub
    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        CHBCANCEL.Checked = False
        Chk_roomselection.Checked = False
        chklist_Rooms.Items.Clear()
        Chk_roomselection.Checked = False
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Rdb_Date.Checked = True
        Call FillhallLocation()
        Dtpbookfromdate.Value = Now.Today
        dtpbooktodate.Value = Now.Today
        Chk_roomselection.Focus()
    End Sub
    Private Sub print_windows()
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r As New RPT_RECEIPTREGISTER
        Dim Heading(0) As String
        Dim sqlstring, SSQL As String

        sqlstring = "SELECT * FROM VW_PARTY_RECEIPT WHERE FREEZE <>'Y'"

        sqlstring = sqlstring & "AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
        sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
        'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
        sqlstring = sqlstring & " ORDER BY PARTYDATE,BOOKINGNO"

        DT = vconn.GetValues(sqlstring)
        If DT.Rows.Count > 0 Then
            Viewer.ssql = sqlstring

            Viewer.Report = r
            Viewer.TableName = "VW_PARTY_RECEIPT"

            Dim textobj1 As TextObject
            textobj1 = r.ReportDefinition.ReportObjects("Text6")
            textobj1.Text = MyCompanyName
            Dim TXTOBJ2 As TextObject
            TXTOBJ2 = r.ReportDefinition.ReportObjects("Text15")
            TXTOBJ2.Text = gUsername
            Dim TXTOBJ3 As TextObject

            TXTOBJ3 = r.ReportDefinition.ReportObjects("Text16")
            TXTOBJ3.Text = " " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""
            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub

    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        'If chklist_Rooms.CheckedItems.Count = 0 Then
        '    MessageBox.Show("Select the Hall Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        Checkdaterangevalidate(Dtpbookfromdate.Value, dtpbooktodate.Value)
        If chkdatevalidate = False Then Exit Sub
        If Rdb_Book.Checked = True Then
            If Val(Txt_FromBooking.Text) > Val(Txt_ToBooking.Text) Then
                MessageBox.Show("From Booking cannot be greater than To Booking", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
        End If
        gPrint = False
        'If MsgBox("Laser PrintOut", MsgBoxStyle.YesNo, "Laser") = MsgBoxResult.Yes Then
        If CHK_catering.Checked = True Then
            'Call cateringbill()
            Call party_book_memberwise()
            'ElseIf CheckBox1.Checked = True Then
            '    Call ADDTIONALITEMS()
        ElseIf rece_reg.Checked = True Then
            Call manitanancecharge()
        ElseIf CHK_PENDINGBILL.Checked = True Then
            Call PENDINGBILL()
        ElseIf ChK_REFUND.Checked = True Then
            Call REFUNDREGISTERREPORT()
        ElseIf Chk_final.Checked = True Then
            Call finallbill()
        ElseIf rec_sum.Checked = True Then
            Call receiptsummary()

            'ElseIf CHK_BAREXP.Checked = True Then
            'Call BARCONSUMPTION()
        Else
            'Call print_windows()
        End If
    End Sub
    Private Sub ADDTIONALITEMS()
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r As New PARTY_ADDITEMS
        Dim Heading(0) As String
        Dim sqlstring, SSQL As String
        sqlstring = "SELECT * FROM PARTY_ADDITEMS1 WHERE"
        sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
        sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
        'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
        sqlstring = sqlstring & " ORDER BY PARTYDATE"
        Viewer.ssql = sqlstring

        Viewer.Report = r
        Viewer.TableName = "PARTY_ADDITEMS1"
        Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
        TXTOBJ1.Text = MyCompanyName

        Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
        TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

        Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ5 = r.ReportDefinition.ReportObjects("Text6")
        TXTOBJ5.Text = "UserName : " & gUsername
        Viewer.Show()

    End Sub

    Private Sub BARCONSUMPTION()
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r As New par_bar_exp
        Dim Heading(0) As String
        Dim sqlstring, SSQL As String
        sqlstring = "SELECT * FROM par_bar_arrangement WHERE"
        sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
        sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
        'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
        sqlstring = sqlstring & " ORDER BY PARTYDATE ASC"
        Viewer.ssql = sqlstring

        Viewer.Report = r
        Viewer.TableName = "par_bar_arrangement"
        Dim TXTOBJ10 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ10 = r.ReportDefinition.ReportObjects("Text10")
        TXTOBJ10.Text = MyCompanyName

        Dim TXTOBJ11 As CrystalDecisions.CrystalReports.Engine.TextObject
        TXTOBJ11 = r.ReportDefinition.ReportObjects("Text11")
        TXTOBJ11.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

        'Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ5 = r.ReportDefinition.ReportObjects("Text6")
        'TXTOBJ5.Text = "UserName : " & gUsername
        Viewer.Show()

    End Sub
    Private Sub REFUNDREGISTERREPORT()
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r
        Dim Heading(0) As String
        Dim sqlstring, SSQL As String
        If PartyCompanyName = "TRADE" Then
            r = New partyreceiptreportREFUND_GUST
        Else
            r = New partyreceiptreportREFUND
        End If


        If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
            sqlstring = "SELECT  * FROM partyreceiptreport_REFUND WHERE"
            sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            sqlstring = sqlstring & " ORDER BY MNAME"
            Viewer.ssql = sqlstring
        Else
            sqlstring = "SELECT  * FROM partyreceiptreport_REFUND WHERE"
            If Rdb_Date.Checked = True Then
                sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
                sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            Else
                sqlstring = sqlstring & " Bookingno BETWEEN '" & Val(Txt_FromBooking.Text) & "' AND '" & Val(Txt_ToBooking.Text) & "' "
            End If
            ''sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            ''sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            ' ''sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            sqlstring = sqlstring & " ORDER BY PARTYDATE,BOOKINGNO"
            Viewer.ssql = sqlstring
        End If
        gconn.getDataSet(sqlstring, "partyreceiptreport_REFUND")
        If gdataset.Tables("partyreceiptreport_REFUND").Rows.Count > 0 Then

            Viewer.Report = r
            Viewer.TableName = "partyreceiptreport_REFUND"
            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
            TXTOBJ1.Text = MyCompanyName

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
            TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text19")
            TXTOBJ5.Text = "UserName : " & gUsername
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text20")
            TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text21")
            TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text22")
            TXTOBJ9.Text = "PhoneNo : " & gphoneno
            Viewer.Show()
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub

    Private Sub party_book_memberwise()
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim Heading(0) As String
        Dim sqlstring, SSQL As String
        Dim r

        If PartyCompanyName = "TRADE" Then
            r = New party_book_memberwise_GUST
        Else
            r = New party_book_memberwise
        End If


        'sqlstring = "SELECT * FROM cateringbillreport WHERE"
        If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
            sqlstring = "SELECT * FROM party_book_memberwise WHERE"
            sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            sqlstring = sqlstring & " ORDER BY ASSOCIATENAME,itemdesc"
            Viewer.ssql = sqlstring

        Else
            sqlstring = "SELECT * FROM party_book_memberwise WHERE"
            If Rdb_Date.Checked = True Then
                sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
                sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            Else
                sqlstring = sqlstring & " Bookingno BETWEEN '" & Val(Txt_FromBooking.Text) & "' AND '" & Val(Txt_ToBooking.Text) & "' "
            End If
            'sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            'sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY PARTYDATE,BOOKINGNO,itemdesc"
            Viewer.ssql = sqlstring

        End If
        gconn.getDataSet(sqlstring, "party_book_memberwise")
        If gdataset.Tables("party_book_memberwise").Rows.Count > 0 Then

            Viewer.Report = r
            Viewer.TableName = "party_book_memberwise"
            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
            TXTOBJ1.Text = MyCompanyName

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
            TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text20")
            TXTOBJ5.Text = "UserName : " & gUsername
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text21")
            TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text22")
            TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text23")
            TXTOBJ9.Text = "PhoneNo : " & gphoneno

            Viewer.Show()
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub manitanancecharge()
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r
        Dim Heading(0) As String
        Dim sqlstring, SSQL As String

        If PartyCompanyName = "TRADE" Then
            r = New partyreceiptreport_gust
        Else
            r = New partyreceiptreport
        End If

        If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
            sqlstring = "SELECT  * FROM partyreceiptreport WHERE"
            sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYRECEIPTDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            sqlstring = sqlstring & " ORDER BY MNAME"
            Viewer.ssql = sqlstring
        Else
            sqlstring = "SELECT  * FROM partyreceiptreport WHERE"
            If Rdb_Date.Checked = True Then
                sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYRECEIPTDATE,6) AS DATETIME) BETWEEN "
                sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            Else
                sqlstring = sqlstring & " Bookingno BETWEEN '" & Val(Txt_FromBooking.Text) & "' AND '" & Val(Txt_ToBooking.Text) & "' "
            End If
            'sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYRECEIPTDATE,6) AS DATETIME) BETWEEN "
            'sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            ''sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            sqlstring = sqlstring & " ORDER BY PARTYDATE,BOOKINGNO"
            Viewer.ssql = sqlstring
        End If
        gconn.getDataSet(sqlstring, "partyreceiptreport")
        If gdataset.Tables("partyreceiptreport").Rows.Count > 0 Then

            Viewer.Report = r
            Viewer.TableName = "partyreceiptreport"
            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
            TXTOBJ1.Text = MyCompanyName

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
            TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text19")
            TXTOBJ5.Text = "UserName : " & gUsername
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text20")
            TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text21")
            TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text22")
            TXTOBJ9.Text = "PhoneNo : " & gphoneno
            Viewer.Show()
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If

    End Sub
    Private Sub finallbill()
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r1

        Dim Heading(0) As String
        Dim sqlstring, SSQL As String
        If PartyCompanyName = "TRADE" Then
            r1 = New totalbanquetreport_GUST_New
        Else
            'r1 = New totalbanquetreport
            r1 = New totalbanquetreport_GUST_New
        End If


        Dim r As New PARTY_BILLDETAILS
        If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
            'sqlstring = "SELECT DISTINCT * FROM PARTY_BILLDETAILS WHERE"
            'sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            'sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            ''sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            'sqlstring = sqlstring & " ORDER BY ASSOCIATENAME"
            'Viewer.ssql = sqlstring
            'CHANGED ON CATHOLIC FOR TAX SEPRATION ON 20JAN13
            sqlstring = "SELECT BOOKINGNO,PARTYDATE,ISNULL(SUM(BARAMOUNT),0)AS BARAMOUNT,ISNULL(SUM(OTHERSAMOUNT),0) AS OTHERSAMOUNT,ISNULL(SUM(CATERINGAMOUNT),0)AS CATERINGAMOUNT,"
            sqlstring = sqlstring & "ISNULL(SUM(BARTAX),0) AS BARTAX,ISNULL(SUM(OTHERSTAX),0)AS OTHERSTAX,ISNULL(SUM(CATERINGTAX),0) AS CATERINGTAX,ISNULL(SUM(BARSERTAX),0)AS BARSERTAX,ISNULL(SUM(OTHERSSERTAX),0)AS OTHERSSERTAX,ISNULL(SUM(CATERINGSERTAX),0)AS CATERINGSERTAX,"
            sqlstring = sqlstring & "ISNULL(discount,0)AS discount,ISNULL(SUM(menuamount),0)AS menuamount,ISNULL(SUM(TOTALAMOUNT),0)AS TOTALAMOUNT,ISNULL(SUM(ITEMTOTAMOUNT),0)AS ITEMTOTAMOUNT,ISNULL(banquethallamount,0) AS banquethallamount,ISNULL(MCODE,'')AS MCODE,ISNULL(ASSOCIATENAME,'')AS ASSOCIATENAME FROM PARTY_BILLDETAILS"
            sqlstring = sqlstring & " WHERE CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            sqlstring = sqlstring & " GROUP BY  BOOKINGNO,MCODE,ASSOCIATENAME,PARTYDATE,DISCOUNT,banquethallamount ORDER BY BOOKINGNO,ASSOCIATENAME"
            'Viewer.ssql = sqlstring

            gconnection.getDataSet(sqlstring, "PARTY_BILLDETAILS")
            If gdataset.Tables("PARTY_BILLDETAILS").Rows.Count > 0 Then

                'Viewer.Report = r
                'Viewer.TableName = "PARTY_BILLDETAILS"
                Viewer.GetDetails(sqlstring, "PARTY_BILLDETAILS", r)
                Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
                TXTOBJ1.Text = MyCompanyName

                Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
                TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

                Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ5 = r.ReportDefinition.ReportObjects("Text13")
                TXTOBJ5.Text = "UserName : " & gUsername
                Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ6 = r.ReportDefinition.ReportObjects("Text12")
                TXTOBJ6.Text = Address1 & Address2

                Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ8 = r.ReportDefinition.ReportObjects("Text28")
                TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

                Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ9 = r.ReportDefinition.ReportObjects("Text29")
                TXTOBJ9.Text = "PhoneNo : " & gphoneno
                Viewer.Show()
            Else
                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                Exit Sub
            End If

        Else

            'SSQL = " EXEC PARTY_BILL ' " & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' ,' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            'gconn.dataOperation(6, SSQL, "RSPOST")

            'sqlstring = "SELECT DISTINCT * FROM totalbanquetreport WHERE"
            'If Rdb_Date.Checked = True Then
            '    sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            '    sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            'Else
            '    sqlstring = sqlstring & " Bookingno BETWEEN '" & Val(Txt_FromBooking.Text) & "' AND '" & Val(Txt_ToBooking.Text) & "' "
            'End If
            ''sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            ''sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            ' ''sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            'sqlstring = sqlstring & " ORDER BY PARTYDATE,BOOKINGNO"

            ''sqlstring = "SELECT BOOKINGNO,PARTYDATE,GUESTNAME,MCODE,ASSOCIATENAME,SUM(HALLAMOUNT) AS HALLAMOUNT,SUM(MENUTOTAL) AS MENUTOTAL,"
            ''sqlstring = sqlstring & "SUM(ARRANGETOTAL) AS ARRANGETOTAL,SUM(SERTAX) AS SERTAX,SUM(LUXTAX) AS LUXTAX FROM VIEW_BNQBILLREPORT WHERE "
            ''If Rdb_Date.Checked = True Then
            ''    sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            ''    sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            ''Else
            ''    sqlstring = sqlstring & " Bookingno BETWEEN '" & Val(Txt_FromBooking.Text) & "' AND '" & Val(Txt_ToBooking.Text) & "' "
            ''End If
            ''sqlstring = sqlstring & " GROUP BY BOOKINGNO,PARTYDATE,GUESTNAME,MCODE,ASSOCIATENAME "

            sqlstring = "SELECT V.BOOKINGNO,V.PARTYDATE,V.GUESTNAME,V.MCODE,V.ASSOCIATENAME,SUM(V.HALLAMOUNT) AS HALLAMOUNT,SUM(MENUTOTAL) AS MENUTOTAL,"
            sqlstring = sqlstring & "SUM(ARRANGETOTAL) AS ARRANGETOTAL,SUM(SERTAX) AS SERTAX,SUM(LUXTAX) AS LUXTAX,BILLNO AS A,SUM(C) AS C,SUM(D) AS D FROM VIEW_BNQBILLREPORT V,PARTY_hDR P WHERE V.BOOKINGNO = P.BOOKINGNO AND "
            If Rdb_Date.Checked = True Then
                sqlstring = sqlstring & " CAST(Convert(varchar(11),V.PARTYDATE,6) AS DATETIME) BETWEEN "
                sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            Else
                sqlstring = sqlstring & " V.Bookingno BETWEEN '" & Val(Txt_FromBooking.Text) & "' AND '" & Val(Txt_ToBooking.Text) & "' "
            End If
            sqlstring = sqlstring & " AND BOOKINGTYPE = 'BILLING' GROUP BY V.BOOKINGNO,V.PARTYDATE,V.GUESTNAME,V.MCODE,V.ASSOCIATENAME,BILLNO  "

            Viewer.ssql = sqlstring
            'End If
            '' gconn.getDataSet(sqlstring, "PARTY_BILLDETAILS")
            gconn.getDataSet(sqlstring, "VIEW_BNQBILLREPORT")


            If gdataset.Tables("VIEW_BNQBILLREPORT").Rows.Count > 0 Then

                Viewer.Report = r1
                Viewer.TableName = "VIEW_BNQBILLREPORT"
                Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ1 = r1.ReportDefinition.ReportObjects("Text1")
                TXTOBJ1.Text = MyCompanyName

                Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ6 = r1.ReportDefinition.ReportObjects("Text21")
                TXTOBJ6.Text = Address1 & Address2

                Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ8 = r1.ReportDefinition.ReportObjects("Text22")
                TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

                Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ9 = r1.ReportDefinition.ReportObjects("Text23")
                TXTOBJ9.Text = "PhoneNo : " & gphoneno


                Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ16 = r1.ReportDefinition.ReportObjects("Text3")
                TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

                Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
                TXTOBJ5 = r1.ReportDefinition.ReportObjects("Text13")
                TXTOBJ5.Text = "UserName : " & gUsername
                Viewer.Show()
            Else
                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If

    End Sub
    Private Sub receiptsummary()
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        'Dim r As New partyfinalbillreportoverall
        Dim r

        If PartyCompanyName = "TRADE" Then
            r = New recsummaryreport_GUST
        Else
            r = New recsummaryreport
        End If

        Dim Heading(0) As String
        Dim sqlstring, SSQL As String

        If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
            sqlstring = "SELECT DISTINCT * FROM party_receiptsummary WHERE"
            sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            sqlstring = sqlstring & " ORDER BY MNAME"
            Viewer.ssql = sqlstring
        Else
            sqlstring = "SELECT DISTINCT * FROM party_receiptsummary WHERE"
            If Rdb_Date.Checked = True Then
                sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
                sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            Else
                sqlstring = sqlstring & " Bookingno BETWEEN '" & Val(Txt_FromBooking.Text) & "' AND '" & Val(Txt_ToBooking.Text) & "' "
            End If
            'sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            'sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY PARTYDATE,BOOKINGNO"
            Viewer.ssql = sqlstring
        End If
        gconn.getDataSet(sqlstring, "party_receiptsummary")
        If gdataset.Tables("party_receiptsummary").Rows.Count > 0 Then
            Viewer.Report = r
            Viewer.TableName = "party_receiptsummary"
            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
            TXTOBJ1.Text = MyCompanyName

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
            TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text13")
            TXTOBJ5.Text = "UserName : " & gUsername
            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text12")
            TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text14")
            TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
            TXTOBJ9.Text = "PhoneNo : " & gphoneno
            Viewer.Show()
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub PENDINGBILL()
        Dim str, MTYPE(), tspilt() As String
        Dim i As Integer
        Dim Viewer As New ReportViwer
        Dim r
        Dim Heading(0) As String
        Dim sqlstring, SSQL As String

        If PartyCompanyName = "TRADE" Then
            r = New PENDINGBILL_GUST
        Else
            r = New PENDINGBILL
        End If

        SSQL = " EXEC PARTY_BILL ' " & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' ,' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
        gconn.dataOperation(6, SSQL, "RSPOST")

        If UCase(Mid(MyCompanyName, 1, 4)) = "CATH" Then
            sqlstring = "SELECT DISTINCT * FROM PARTY_PENDINGBILL WHERE"
            sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            sqlstring = sqlstring & " ORDER BY ASSOCIATENAME"
            Viewer.ssql = sqlstring
        Else
            sqlstring = "SELECT DISTINCT bookingno,bookingdate,partydate,tax,amount,discount,totalamount,itemtotamount,banquethallamount,mcode,associatename,sum(recamount) as recamount,sum(refund)as refund   FROM PARTY_PENDINGBILL WHERE    "
            ' sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            If Rdb_Date.Checked = True Then
                sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
                sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            Else
                sqlstring = sqlstring & " Bookingno BETWEEN '" & Val(Txt_FromBooking.Text) & "' AND '" & Val(Txt_ToBooking.Text) & "' "
            End If
            'sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpbooktodate.Value, "yyyy-MM-dd") & "'"
            'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            sqlstring = sqlstring & " group by  bookingno,bookingdate,partydate,tax,amount,discount,totalamount,itemtotamount,banquethallamount,mcode,associatename ORDER BY PARTYDATE,BOOKINGNO"
            Viewer.ssql = sqlstring
        End If

        gconn.getDataSet(sqlstring, "PARTY_PENDINGBILL")
        If gdataset.Tables("PARTY_PENDINGBILL").Rows.Count > 0 Then

            Viewer.Report = r
            Viewer.TableName = "PARTY_PENDINGBILL"
            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
            TXTOBJ1.Text = MyCompanyName

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text3")
            TXTOBJ16.Text = "Period From  " & Format(Dtpbookfromdate.Value, "dd.MM.yyyy") & "  To " & " " & Format(dtpbooktodate.Value, "dd.MM.yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text13")
            TXTOBJ5.Text = "UserName : " & gUsername

            Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ6 = r.ReportDefinition.ReportObjects("Text19")
            TXTOBJ6.Text = Address1 & Address2

            Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ8 = r.ReportDefinition.ReportObjects("Text20")
            TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

            Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ9 = r.ReportDefinition.ReportObjects("Text21")
            TXTOBJ9.Text = "PhoneNo : " & gphoneno
            Viewer.Show()
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub
    Private Sub Hallstatus()
        Try
            Dim i As Integer
            Dim tspilt(), Heading(0) As String
            Dim sqlstring, SSQL As String
            'sqlstring = "SELECT HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESC,PDESC,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME FROM PARTY_VIEW_BOOKING_DETAILS "
            'sqlstring = "SELECT HALLCODE,ISNULL(HALLDESCRIPTION,''),BOOKINGNO,BOOKINGDATE,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGDETAILS "
            'vijay040811-ISNULL(HALLDESCRIPTION,'')
            sqlstring = "SELECT HALLCODE,HALLDESCRIPTION,BOOKINGNO,BOOKINGDATE,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME FROM VIEW_PARTY_BOOKINGDETAILS "

            If chklist_Rooms.CheckedItems.Count <> 0 Then
                sqlstring = sqlstring & " WHERE ISNULL(BOOKINGTYPE,'')='BOOKING' AND HALLCODE IN ("
                'sqlstring = sqlstring & " WHERE  HALLCODE IN ("

                For i = 0 To chklist_Rooms.CheckedItems.Count - 1
                    tspilt = Split(chklist_Rooms.CheckedItems(i), "-->")
                    If i = 0 Then
                        sqlstring = sqlstring & "'" & tspilt(0)
                    Else
                        sqlstring = sqlstring & "','" & tspilt(0)
                    End If
                Next
                sqlstring = sqlstring & "') "
            Else
                MessageBox.Show("Select the hall Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If CHBCANCEL.Checked = True Then
                sqlstring = sqlstring & " AND ISNULL(FREEZE,'')='Y' "
            End If
            sqlstring = sqlstring & "AND CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " GROUP BY HALLCODE,HALLDESCRIPTION,BOOKINGNO,BOOKINGDATE,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            sqlstring = sqlstring & " ORDER BY HALLCODE,PARTYDATE,FROMTIME,TOTIME,BOOKINGNO"
            Dim Objbookingstatus As New Bookingstatus
            SSQL = "HALL BOOKING STATUS"
            Heading(0) = SSQL
            'insert(0) = strSQL
            Objbookingstatus.BOOKINGDETAILS(Heading, sqlstring, Dtpbookfromdate.Value, dtpbooktodate.Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

    End Sub
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        'If chklist_Rooms.CheckedItems.Count = 0 Then
        '    MessageBox.Show("Select the POS Location(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        Checkdaterangevalidate(Dtpbookfromdate.Value, dtpbooktodate.Value)
        If chkdatevalidate = False Then Exit Sub
        gPrint = True
        Call Hallstatus()
    End Sub
    Private Sub ReceiptRegister_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Dim i As Integer
        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F2 Then
            For i = 0 To chklist_Rooms.Items.Count - 1
                chklist_Rooms.SetItemChecked(i, True)
            Next i
            Chk_roomselection.Checked = True
            Me.Dtpbookfromdate.Focus()
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            Call CmdPrint_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F9 Then
            Call CmdView_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            Call cmdexit_Click(sender, e)
            Exit Sub
        ElseIf e.KeyCode = Keys.Escape Then
            Call cmdexit_Click(sender, e)
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.F Then
            Me.Dtpbookfromdate.Focus()
            Exit Sub
        ElseIf e.Alt = True And e.KeyCode = Keys.T Then
            Me.dtpbooktodate.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub Chk_roomselection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_roomselection.CheckedChanged
        Dim i As Integer
        If Chk_roomselection.Checked = True Then
            For i = 0 To chklist_Rooms.Items.Count - 1
                chklist_Rooms.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklist_Rooms.Items.Count - 1
                chklist_Rooms.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub dtpbooktodate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpbooktodate.ValueChanged

    End Sub

    Private Sub Dtpbookfromdate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtpbookfromdate.ValueChanged

    End Sub

    Private Sub chklist_Rooms_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chklist_Rooms.SelectedIndexChanged

    End Sub
    Private Sub chklist_Rooms_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chklist_Rooms.KeyDown
        If Asc(e.KeyCode) = Keys.Enter Then
            Dtpbookfromdate.Focus()
        End If
    End Sub
    Private Sub Dtpbookfromdate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtpbookfromdate.KeyDown
        If Asc(e.KeyCode) = Keys.Enter Then
            dtpbooktodate.Focus()
        End If
    End Sub
    Private Sub chklist_Rooms_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles chklist_Rooms.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            CHBCANCEL.Focus()
        End If
    End Sub
    Private Sub Dtpbookfromdate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dtpbookfromdate.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            dtpbooktodate.Focus()
        End If
    End Sub
    Private Sub dtpbooktodate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpbooktodate.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            CmdView.Focus()
        End If
    End Sub
    Private Sub CHBCANCEL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CHBCANCEL.KeyPress
        If Asc(e.KeyChar) = Keys.Enter Then
            Dtpbookfromdate.Focus()
        End If
    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        Dim i As Integer
        Dim exp As New exportexcel
        Dim sqlstring, MTYPE(), tspilt() As String

        If CHK_catering.Checked = True Then
            sqlstring = "SELECT * FROM party_book_memberwise WHERE"
            sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY ASSOCIATENAME,itemdesc,BOOKINGNO"

            gconn.getDataSet(sqlstring, "party_book_memberwise")
            If gdataset.Tables("party_book_memberwise").Rows.Count > 0 Then
                exp.Show()
                Call exp.export(sqlstring, "CATERING BILL REPORT  " & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "   TO   " & Format(dtpbooktodate.Value, "dd-MMM-yyyy"), "")
            Else
                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                Exit Sub
            End If


        ElseIf Chk_final.Checked = True Then
            sqlstring = "SELECT DISTINCT * FROM totalbanquetreport WHERE"
            sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY ASSOCIATENAME"

            gconn.getDataSet(sqlstring, "totalbanquetreport")
            If gdataset.Tables("totalbanquetreport").Rows.Count > 0 Then
                exp.Show()
                Call exp.export(sqlstring, "BANQUET BILL REPORT  " & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "   TO   " & Format(dtpbooktodate.Value, "dd-MMM-yyyy"), "")
            Else
                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                Exit Sub
            End If

        ElseIf rece_reg.Checked = True Then
            sqlstring = "SELECT  * FROM partyreceiptreport WHERE"
            sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYRECEIPTDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY MNAME"

            gconn.getDataSet(sqlstring, "partyreceiptreport")
            If gdataset.Tables("partyreceiptreport").Rows.Count > 0 Then
                exp.Show()
                Call exp.export(sqlstring, "RECEIPT REGISTER REPORT  " & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "   TO    " & Format(dtpbooktodate.Value, "dd-MMM-yyyy"), "")
            Else
                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                Exit Sub
            End If

        ElseIf CHK_PENDINGBILL.Checked = True Then
            sqlstring = "SELECT DISTINCT * FROM PARTY_PENDINGBILL WHERE"
            sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY ASSOCIATENAME"

            gconn.getDataSet(sqlstring, "PARTY_PENDINGBILL")
            If gdataset.Tables("PARTY_PENDINGBILL").Rows.Count > 0 Then

                exp.Show()
                Call exp.export(sqlstring, "BANQUET PARTY DUES REPORT   " & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "   TO   " & Format(dtpbooktodate.Value, "dd-MMM-yyyy"), "")

            Else
                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                Exit Sub
            End If
        ElseIf ChK_REFUND.Checked = True Then

            sqlstring = "SELECT  * FROM partyreceiptreport_REFUND WHERE"
            sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            'sqlstring = sqlstring & " GROUP BY HALLCODE,BOOKINGNO,BOOKINGDATE,HALLDESCRIPTION,HALLAMOUNT,MCODE,ASSOCIATENAME,PARTYDATE,FROMTIME,TOTIME"
            sqlstring = sqlstring & " ORDER BY MNAME"

            gconn.getDataSet(sqlstring, "partyreceiptreport_REFUND")
            If gdataset.Tables("partyreceiptreport_REFUND").Rows.Count > 0 Then
                exp.Show()
                Call exp.export(sqlstring, "RECEIPT REFUND REPORT  " & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "   TO   " & Format(dtpbooktodate.Value, "dd-MMM-yyyy"), "")
            Else
                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                Exit Sub
            End If

        Else : rec_sum.Checked = True
            sqlstring = "SELECT DISTINCT * FROM party_receiptsummary WHERE"
            sqlstring = sqlstring & " CAST(Convert(varchar(11),PARTYDATE,6) AS DATETIME) BETWEEN "
            sqlstring = sqlstring & " '" & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "' AND ' " & Format(dtpbooktodate.Value, "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & " ORDER BY MNAME"

            gconn.getDataSet(sqlstring, "party_receiptsummary")
            If gdataset.Tables("party_receiptsummary").Rows.Count > 0 Then
                exp.Show()
                Call exp.export(sqlstring, "BANQUET RECEIPT SUMMARY REPORT  " & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "   TO   " & Format(dtpbooktodate.Value, "dd-MMM-yyyy"), "")
            Else
                MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If


        'Dim servercode() As String
        'Dim i As Integer

        'Dim sqlstring, SSQL As String
        'Dim Viewer As New ReportViwer
        'Dim r As New crptPARTY_BOOKINGDETAILS1

        'Dim POSdesc(), MemberCode() As String
        'Dim SQLSTRING2 As String
        'sqlstring = "SELECT * FROM VIEW_PARTY_BOOKINGDETAILS WHERE"
        'sqlstring = sqlstring & "  BOOKINGDATE BETWEEN '" & Format(Dtpbookfromdate.Value, "dd/MMM/yyyy") & "' and '" & Format(dtpbooktodate.Value, "dd/MMM/yyyy") & "'"
        'sqlstring = sqlstring & " ORDER BY BOOKINGDATE,HALLCODE "
        'Call Viewer.GetDetails(sqlstring, "party_view_hallstatus", r)
        'Viewer.Report = r

        'Viewer.TableName = "party_view_hallstatus"
        'Viewer.Show()
    End Sub

    Private Sub CHK_BAREXP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_BAREXP.CheckedChanged

    End Sub

    Private Sub Chk_maintanance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_maintanance.CheckedChanged

    End Sub

    Private Sub Chk_final_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_final.CheckedChanged
        If Chk_final.Checked = True Then
            CHK_catering.Checked = False
            rece_reg.Checked = False
            ChK_REFUND.Checked = False
            CHK_PENDINGBILL.Checked = False
            rec_sum.Checked = False
        End If
    End Sub

    Private Sub CHK_catering_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_catering.CheckedChanged
        If CHK_catering.Checked = True Then
            Chk_final.Checked = False
            rece_reg.Checked = False
            ChK_REFUND.Checked = False
            CHK_PENDINGBILL.Checked = False
            rec_sum.Checked = False

        End If
    End Sub

    Private Sub rece_reg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rece_reg.CheckedChanged
        If rece_reg.Checked = True Then
            CHK_catering.Checked = False
            Chk_final.Checked = False
            ChK_REFUND.Checked = False
            CHK_PENDINGBILL.Checked = False
            rec_sum.Checked = False

        End If
    End Sub

    Private Sub ChK_REFUND_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChK_REFUND.CheckedChanged
        If ChK_REFUND.Checked = True Then
            CHK_catering.Checked = False
            rece_reg.Checked = False
            Chk_final.Checked = False
            CHK_PENDINGBILL.Checked = False
            rec_sum.Checked = False

        End If
    End Sub

    Private Sub CHK_PENDINGBILL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHK_PENDINGBILL.CheckedChanged
        If CHK_PENDINGBILL.Checked = True Then
            CHK_catering.Checked = False
            rece_reg.Checked = False
            Chk_final.Checked = False
            ChK_REFUND.Checked = False
            rec_sum.Checked = False

        End If
    End Sub

    Private Sub rec_sum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rec_sum.CheckedChanged
        If rec_sum.Checked = True Then
            CHK_catering.Checked = False
            rece_reg.Checked = False
            Chk_final.Checked = False
            ChK_REFUND.Checked = False
            CHK_PENDINGBILL.Checked = False

        End If
    End Sub

    Private Sub Rdb_Date_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Date.CheckedChanged
        GroupBox3.Visible = True
        GroupBox1.Visible = False
        Txt_FromBooking.Text = ""
        Txt_ToBooking.Text = ""
    End Sub

    Private Sub Rdb_Book_CheckedChanged(sender As Object, e As EventArgs) Handles Rdb_Book.CheckedChanged
        GroupBox3.Visible = False
        GroupBox1.Visible = True
        Dtpbookfromdate.Value = Now.Today
        dtpbooktodate.Value = Now.Today
    End Sub

  
    Private Sub ReceiptRegister_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class

