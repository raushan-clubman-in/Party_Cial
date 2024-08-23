Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Public Class GLACCOUNTMASTER_Others
    Inherits System.Windows.Forms.Form
    Dim freezeflag As String
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Txt_AcDesc As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Alias As System.Windows.Forms.TextBox
    Friend WithEvents Rdo_SubLedgerYes As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_SubLedgerNo As System.Windows.Forms.RadioButton
    Friend WithEvents Cmb_AcType As System.Windows.Forms.ComboBox
    Friend WithEvents Rdo_BudgetYes As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_BudgetNo As System.Windows.Forms.RadioButton
    Friend WithEvents Txt_OpeningBalance As System.Windows.Forms.TextBox
    Friend WithEvents Txt_BalanceAsOn As System.Windows.Forms.TextBox
    Friend WithEvents Rdo_OpeningBalanceCredit As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_OpeningBalanceDebit As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_BalanceAsOnCredit As System.Windows.Forms.RadioButton
    Friend WithEvents Rdo_BalanceAsOnDebit As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Txt_AcCode As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_AcCodeHelp As System.Windows.Forms.Button
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents CmdAdd As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents Txt_ProjectedNextYear As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ActualNextYear As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ProjectedCurrentYear As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ActualCurrentYear As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ProjectedLastYear As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ActualLastyear As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdFreeze As System.Windows.Forms.Button
    Friend WithEvents Lbl_Freeze As System.Windows.Forms.Label
    Friend WithEvents Lbl_NextYear As System.Windows.Forms.Label
    Friend WithEvents Lbl_CurrentYear As System.Windows.Forms.Label
    Friend WithEvents Lbl_Lastyear As System.Windows.Forms.Label
    Friend WithEvents Lbl_Projected As System.Windows.Forms.Label
    Friend WithEvents Lbl_Actual As System.Windows.Forms.Label
    Friend WithEvents Lbl_SubGroup As System.Windows.Forms.Label
    Friend WithEvents Cmb_SubGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_Group As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Txt_BankName As System.Windows.Forms.TextBox
    Friend WithEvents Txt_BankAddress As System.Windows.Forms.TextBox
    Friend WithEvents Rad_Bal As System.Windows.Forms.RadioButton
    Friend WithEvents Rad_Pl As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Rad_Lia As System.Windows.Forms.RadioButton
    Friend WithEvents Rad_Asset As System.Windows.Forms.RadioButton
    Friend WithEvents Rad_Exp As System.Windows.Forms.RadioButton
    Friend WithEvents Rad_Income As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents pnlBank As System.Windows.Forms.Panel
    Friend WithEvents Cmb_SubSubGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Lbl_SubSubGroup As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_CellNo As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Txt_PhoneNo As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Txt_Pin As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Txt_State As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txt_City As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Txt_Address3 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Txt_Address2 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Txt_Address1 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Txt_ContactPerson As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Txt_PANNo As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Txt_GRNNo As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Txt_TINNo As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Txt_CSTNo As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Txt_VATNo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Txt_SLName As System.Windows.Forms.TextBox
    Friend WithEvents Cmd_SLCodeHelp As System.Windows.Forms.Button
    Friend WithEvents Txt_SLCode As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ChkNew As System.Windows.Forms.CheckBox
    Friend WithEvents Cmb_SLType1 As System.Windows.Forms.ComboBox
    Friend WithEvents Cmb_SLType As System.Windows.Forms.ComboBox
    Friend WithEvents Lbl_sltype As System.Windows.Forms.Label
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents cmdcrystal As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(GLACCOUNTMASTER_Others))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_AcDesc = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_Alias = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Rdo_SubLedgerYes = New System.Windows.Forms.RadioButton
        Me.Rdo_SubLedgerNo = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Cmb_AcType = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Rdo_BudgetYes = New System.Windows.Forms.RadioButton
        Me.Rdo_BudgetNo = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Txt_OpeningBalance = New System.Windows.Forms.TextBox
        Me.Txt_BalanceAsOn = New System.Windows.Forms.TextBox
        Me.Rdo_OpeningBalanceCredit = New System.Windows.Forms.RadioButton
        Me.Rdo_OpeningBalanceDebit = New System.Windows.Forms.RadioButton
        Me.Rdo_BalanceAsOnCredit = New System.Windows.Forms.RadioButton
        Me.Rdo_BalanceAsOnDebit = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.pnlBank = New System.Windows.Forms.Panel
        Me.Txt_BankAddress = New System.Windows.Forms.TextBox
        Me.Txt_BankName = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.Rad_Bal = New System.Windows.Forms.RadioButton
        Me.Rad_Pl = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Cmb_SLType = New System.Windows.Forms.ComboBox
        Me.Lbl_sltype = New System.Windows.Forms.Label
        Me.Lbl_SubSubGroup = New System.Windows.Forms.Label
        Me.Cmb_SubSubGroup = New System.Windows.Forms.ComboBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Rad_Exp = New System.Windows.Forms.RadioButton
        Me.Rad_Income = New System.Windows.Forms.RadioButton
        Me.Rad_Lia = New System.Windows.Forms.RadioButton
        Me.Rad_Asset = New System.Windows.Forms.RadioButton
        Me.Lbl_SubGroup = New System.Windows.Forms.Label
        Me.Cmb_SubGroup = New System.Windows.Forms.ComboBox
        Me.Cmb_Group = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_AcCode = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Cmd_AcCodeHelp = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Txt_ProjectedNextYear = New System.Windows.Forms.TextBox
        Me.Txt_ActualNextYear = New System.Windows.Forms.TextBox
        Me.Txt_ProjectedCurrentYear = New System.Windows.Forms.TextBox
        Me.Txt_ActualCurrentYear = New System.Windows.Forms.TextBox
        Me.Txt_ProjectedLastYear = New System.Windows.Forms.TextBox
        Me.Txt_ActualLastyear = New System.Windows.Forms.TextBox
        Me.Lbl_NextYear = New System.Windows.Forms.Label
        Me.Lbl_CurrentYear = New System.Windows.Forms.Label
        Me.Lbl_Lastyear = New System.Windows.Forms.Label
        Me.Lbl_Projected = New System.Windows.Forms.Label
        Me.Lbl_Actual = New System.Windows.Forms.Label
        Me.frmbut = New System.Windows.Forms.GroupBox
        Me.cmdcrystal = New System.Windows.Forms.Button
        Me.cmdexport = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.CmdFreeze = New System.Windows.Forms.Button
        Me.CmdAdd = New System.Windows.Forms.Button
        Me.CmdClear = New System.Windows.Forms.Button
        Me.CmdView = New System.Windows.Forms.Button
        Me.Lbl_Freeze = New System.Windows.Forms.Label
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.ChkNew = New System.Windows.Forms.CheckBox
        Me.Txt_CellNo = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.Txt_PhoneNo = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Txt_Pin = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Txt_State = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txt_City = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Txt_Address3 = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Txt_Address2 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Txt_Address1 = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Txt_ContactPerson = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.Txt_PANNo = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Txt_GRNNo = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Txt_TINNo = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Txt_CSTNo = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Txt_VATNo = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Txt_SLName = New System.Windows.Forms.TextBox
        Me.Cmd_SLCodeHelp = New System.Windows.Forms.Button
        Me.Txt_SLCode = New System.Windows.Forms.TextBox
        Me.Cmb_SLType1 = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlBank.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.frmbut.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(288, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(287, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "GL ACCOUNT MASTER"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(136, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ACCOUNT DESCRIPTION  :"
        '
        'Txt_AcDesc
        '
        Me.Txt_AcDesc.BackColor = System.Drawing.Color.Wheat
        Me.Txt_AcDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_AcDesc.Location = New System.Drawing.Point(360, 56)
        Me.Txt_AcDesc.MaxLength = 30
        Me.Txt_AcDesc.Name = "Txt_AcDesc"
        Me.Txt_AcDesc.Size = New System.Drawing.Size(200, 20)
        Me.Txt_AcDesc.TabIndex = 1
        Me.Txt_AcDesc.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(760, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "ALIAS :"
        Me.Label3.Visible = False
        '
        'Txt_Alias
        '
        Me.Txt_Alias.BackColor = System.Drawing.Color.Wheat
        Me.Txt_Alias.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_Alias.Location = New System.Drawing.Point(824, 216)
        Me.Txt_Alias.MaxLength = 10
        Me.Txt_Alias.Name = "Txt_Alias"
        Me.Txt_Alias.Size = New System.Drawing.Size(24, 20)
        Me.Txt_Alias.TabIndex = 2
        Me.Txt_Alias.Text = ""
        Me.Txt_Alias.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(768, 248)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 18)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "SUB LEDGER :"
        Me.Label5.Visible = False
        '
        'Rdo_SubLedgerYes
        '
        Me.Rdo_SubLedgerYes.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_SubLedgerYes.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdo_SubLedgerYes.Location = New System.Drawing.Point(696, 224)
        Me.Rdo_SubLedgerYes.Name = "Rdo_SubLedgerYes"
        Me.Rdo_SubLedgerYes.Size = New System.Drawing.Size(56, 24)
        Me.Rdo_SubLedgerYes.TabIndex = 3
        Me.Rdo_SubLedgerYes.Text = "YES"
        Me.Rdo_SubLedgerYes.Visible = False
        '
        'Rdo_SubLedgerNo
        '
        Me.Rdo_SubLedgerNo.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_SubLedgerNo.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdo_SubLedgerNo.Location = New System.Drawing.Point(696, 264)
        Me.Rdo_SubLedgerNo.Name = "Rdo_SubLedgerNo"
        Me.Rdo_SubLedgerNo.Size = New System.Drawing.Size(48, 24)
        Me.Rdo_SubLedgerNo.TabIndex = 9
        Me.Rdo_SubLedgerNo.Text = "NO"
        Me.Rdo_SubLedgerNo.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(119, 18)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "ACCOUNT TYPE :"
        '
        'Cmb_AcType
        '
        Me.Cmb_AcType.BackColor = System.Drawing.Color.Wheat
        Me.Cmb_AcType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_AcType.Items.AddRange(New Object() {"RECEIVABLE ", "PAYABLE ", "NORMAL ", "CASH ", "BANK "})
        Me.Cmb_AcType.Location = New System.Drawing.Point(144, 32)
        Me.Cmb_AcType.Name = "Cmb_AcType"
        Me.Cmb_AcType.Size = New System.Drawing.Size(176, 21)
        Me.Cmb_AcType.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(80, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 18)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "BUDGET :"
        '
        'Rdo_BudgetYes
        '
        Me.Rdo_BudgetYes.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_BudgetYes.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdo_BudgetYes.Location = New System.Drawing.Point(160, 16)
        Me.Rdo_BudgetYes.Name = "Rdo_BudgetYes"
        Me.Rdo_BudgetYes.Size = New System.Drawing.Size(48, 16)
        Me.Rdo_BudgetYes.TabIndex = 0
        Me.Rdo_BudgetYes.Text = "YES"
        '
        'Rdo_BudgetNo
        '
        Me.Rdo_BudgetNo.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_BudgetNo.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdo_BudgetNo.Location = New System.Drawing.Point(216, 16)
        Me.Rdo_BudgetNo.Name = "Rdo_BudgetNo"
        Me.Rdo_BudgetNo.Size = New System.Drawing.Size(40, 16)
        Me.Rdo_BudgetNo.TabIndex = 14
        Me.Rdo_BudgetNo.Text = "NO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 18)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "OPENING BALANCE :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(132, 18)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "  BALANCE AS ON  :"
        '
        'Txt_OpeningBalance
        '
        Me.Txt_OpeningBalance.Location = New System.Drawing.Point(152, 32)
        Me.Txt_OpeningBalance.MaxLength = 12
        Me.Txt_OpeningBalance.Name = "Txt_OpeningBalance"
        Me.Txt_OpeningBalance.Size = New System.Drawing.Size(120, 20)
        Me.Txt_OpeningBalance.TabIndex = 0
        Me.Txt_OpeningBalance.Text = ""
        Me.Txt_OpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_BalanceAsOn
        '
        Me.Txt_BalanceAsOn.Location = New System.Drawing.Point(152, 64)
        Me.Txt_BalanceAsOn.MaxLength = 8
        Me.Txt_BalanceAsOn.Name = "Txt_BalanceAsOn"
        Me.Txt_BalanceAsOn.ReadOnly = True
        Me.Txt_BalanceAsOn.Size = New System.Drawing.Size(120, 20)
        Me.Txt_BalanceAsOn.TabIndex = 1
        Me.Txt_BalanceAsOn.Text = ""
        Me.Txt_BalanceAsOn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Rdo_OpeningBalanceCredit
        '
        Me.Rdo_OpeningBalanceCredit.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_OpeningBalanceCredit.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdo_OpeningBalanceCredit.Location = New System.Drawing.Point(72, 8)
        Me.Rdo_OpeningBalanceCredit.Name = "Rdo_OpeningBalanceCredit"
        Me.Rdo_OpeningBalanceCredit.Size = New System.Drawing.Size(72, 24)
        Me.Rdo_OpeningBalanceCredit.TabIndex = 30
        Me.Rdo_OpeningBalanceCredit.Text = "CREDIT"
        '
        'Rdo_OpeningBalanceDebit
        '
        Me.Rdo_OpeningBalanceDebit.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_OpeningBalanceDebit.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdo_OpeningBalanceDebit.Location = New System.Drawing.Point(8, 8)
        Me.Rdo_OpeningBalanceDebit.Name = "Rdo_OpeningBalanceDebit"
        Me.Rdo_OpeningBalanceDebit.Size = New System.Drawing.Size(64, 24)
        Me.Rdo_OpeningBalanceDebit.TabIndex = 0
        Me.Rdo_OpeningBalanceDebit.Text = "DEBIT"
        '
        'Rdo_BalanceAsOnCredit
        '
        Me.Rdo_BalanceAsOnCredit.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_BalanceAsOnCredit.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdo_BalanceAsOnCredit.Location = New System.Drawing.Point(72, 8)
        Me.Rdo_BalanceAsOnCredit.Name = "Rdo_BalanceAsOnCredit"
        Me.Rdo_BalanceAsOnCredit.Size = New System.Drawing.Size(72, 24)
        Me.Rdo_BalanceAsOnCredit.TabIndex = 33
        Me.Rdo_BalanceAsOnCredit.Text = "CREDIT"
        '
        'Rdo_BalanceAsOnDebit
        '
        Me.Rdo_BalanceAsOnDebit.BackColor = System.Drawing.Color.Transparent
        Me.Rdo_BalanceAsOnDebit.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdo_BalanceAsOnDebit.Location = New System.Drawing.Point(8, 8)
        Me.Rdo_BalanceAsOnDebit.Name = "Rdo_BalanceAsOnDebit"
        Me.Rdo_BalanceAsOnDebit.Size = New System.Drawing.Size(64, 24)
        Me.Rdo_BalanceAsOnDebit.TabIndex = 0
        Me.Rdo_BalanceAsOnDebit.Text = "DEBIT"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.GroupBox6)
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.Txt_OpeningBalance)
        Me.GroupBox1.Controls.Add(Me.Txt_BalanceAsOn)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(800, 536)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(24, 32)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Rdo_BalanceAsOnDebit)
        Me.GroupBox6.Controls.Add(Me.Rdo_BalanceAsOnCredit)
        Me.GroupBox6.Location = New System.Drawing.Point(272, 56)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(136, 32)
        Me.GroupBox6.TabIndex = 41
        Me.GroupBox6.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Rdo_OpeningBalanceDebit)
        Me.GroupBox5.Controls.Add(Me.Rdo_OpeningBalanceCredit)
        Me.GroupBox5.Location = New System.Drawing.Point(272, 24)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(136, 32)
        Me.GroupBox5.TabIndex = 40
        Me.GroupBox5.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.pnlBank)
        Me.GroupBox2.Controls.Add(Me.GroupBox8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Cmb_AcType)
        Me.GroupBox2.Location = New System.Drawing.Point(744, 280)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(72, 112)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'pnlBank
        '
        Me.pnlBank.Controls.Add(Me.Txt_BankAddress)
        Me.pnlBank.Controls.Add(Me.Txt_BankName)
        Me.pnlBank.Controls.Add(Me.Label11)
        Me.pnlBank.Controls.Add(Me.Label12)
        Me.pnlBank.Location = New System.Drawing.Point(16, 64)
        Me.pnlBank.Name = "pnlBank"
        Me.pnlBank.Size = New System.Drawing.Size(336, 136)
        Me.pnlBank.TabIndex = 20
        '
        'Txt_BankAddress
        '
        Me.Txt_BankAddress.BackColor = System.Drawing.Color.Wheat
        Me.Txt_BankAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_BankAddress.Location = New System.Drawing.Point(128, 40)
        Me.Txt_BankAddress.MaxLength = 300
        Me.Txt_BankAddress.Multiline = True
        Me.Txt_BankAddress.Name = "Txt_BankAddress"
        Me.Txt_BankAddress.Size = New System.Drawing.Size(200, 80)
        Me.Txt_BankAddress.TabIndex = 13
        Me.Txt_BankAddress.Text = ""
        '
        'Txt_BankName
        '
        Me.Txt_BankName.BackColor = System.Drawing.Color.Wheat
        Me.Txt_BankName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_BankName.Location = New System.Drawing.Point(128, 8)
        Me.Txt_BankName.MaxLength = 30
        Me.Txt_BankName.Name = "Txt_BankName"
        Me.Txt_BankName.Size = New System.Drawing.Size(200, 20)
        Me.Txt_BankName.TabIndex = 12
        Me.Txt_BankName.Text = ""
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(0, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(117, 18)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "BANK ADDRESS :"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(0, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 18)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "BANK NAME :"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.Rad_Bal)
        Me.GroupBox8.Controls.Add(Me.Rad_Pl)
        Me.GroupBox8.Enabled = False
        Me.GroupBox8.Location = New System.Drawing.Point(24, 240)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(288, 48)
        Me.GroupBox8.TabIndex = 19
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Type"
        Me.GroupBox8.Visible = False
        '
        'Rad_Bal
        '
        Me.Rad_Bal.Checked = True
        Me.Rad_Bal.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_Bal.Location = New System.Drawing.Point(16, 16)
        Me.Rad_Bal.Name = "Rad_Bal"
        Me.Rad_Bal.Size = New System.Drawing.Size(125, 24)
        Me.Rad_Bal.TabIndex = 17
        Me.Rad_Bal.TabStop = True
        Me.Rad_Bal.Text = "Balance Sheet"
        '
        'Rad_Pl
        '
        Me.Rad_Pl.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_Pl.Location = New System.Drawing.Point(144, 16)
        Me.Rad_Pl.Name = "Rad_Pl"
        Me.Rad_Pl.Size = New System.Drawing.Size(136, 24)
        Me.Rad_Pl.TabIndex = 18
        Me.Rad_Pl.Text = "Profit and Loss"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Cmb_SLType)
        Me.GroupBox3.Controls.Add(Me.Lbl_sltype)
        Me.GroupBox3.Controls.Add(Me.Lbl_SubSubGroup)
        Me.GroupBox3.Controls.Add(Me.Cmb_SubSubGroup)
        Me.GroupBox3.Controls.Add(Me.GroupBox7)
        Me.GroupBox3.Controls.Add(Me.Lbl_SubGroup)
        Me.GroupBox3.Controls.Add(Me.Cmb_SubGroup)
        Me.GroupBox3.Controls.Add(Me.Cmb_Group)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Txt_AcDesc)
        Me.GroupBox3.Controls.Add(Me.Txt_AcCode)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Cmd_AcCodeHelp)
        Me.GroupBox3.Location = New System.Drawing.Point(48, 56)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(744, 128)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'Cmb_SLType
        '
        Me.Cmb_SLType.BackColor = System.Drawing.Color.Wheat
        Me.Cmb_SLType.Items.AddRange(New Object() {"MEMBER", "SUPPLIER", "EMPLOYEE"})
        Me.Cmb_SLType.Location = New System.Drawing.Point(192, 248)
        Me.Cmb_SLType.Name = "Cmb_SLType"
        Me.Cmb_SLType.Size = New System.Drawing.Size(160, 21)
        Me.Cmb_SLType.TabIndex = 26
        Me.Cmb_SLType.Visible = False
        '
        'Lbl_sltype
        '
        Me.Lbl_sltype.AutoSize = True
        Me.Lbl_sltype.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_sltype.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_sltype.Location = New System.Drawing.Point(16, 248)
        Me.Lbl_sltype.Name = "Lbl_sltype"
        Me.Lbl_sltype.Size = New System.Drawing.Size(68, 18)
        Me.Lbl_sltype.TabIndex = 25
        Me.Lbl_sltype.Text = "SL TYPE :"
        Me.Lbl_sltype.Visible = False
        '
        'Lbl_SubSubGroup
        '
        Me.Lbl_SubSubGroup.AutoSize = True
        Me.Lbl_SubSubGroup.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_SubSubGroup.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SubSubGroup.Location = New System.Drawing.Point(10, 216)
        Me.Lbl_SubSubGroup.Name = "Lbl_SubSubGroup"
        Me.Lbl_SubSubGroup.Size = New System.Drawing.Size(123, 18)
        Me.Lbl_SubSubGroup.TabIndex = 24
        Me.Lbl_SubSubGroup.Text = "SUB  SUB GROUP :"
        Me.Lbl_SubSubGroup.Visible = False
        '
        'Cmb_SubSubGroup
        '
        Me.Cmb_SubSubGroup.BackColor = System.Drawing.Color.Wheat
        Me.Cmb_SubSubGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_SubSubGroup.Location = New System.Drawing.Point(192, 216)
        Me.Cmb_SubSubGroup.Name = "Cmb_SubSubGroup"
        Me.Cmb_SubSubGroup.Size = New System.Drawing.Size(176, 21)
        Me.Cmb_SubSubGroup.TabIndex = 23
        Me.Cmb_SubSubGroup.Visible = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Rad_Exp)
        Me.GroupBox7.Controls.Add(Me.Rad_Income)
        Me.GroupBox7.Controls.Add(Me.Rad_Lia)
        Me.GroupBox7.Controls.Add(Me.Rad_Asset)
        Me.GroupBox7.Location = New System.Drawing.Point(8, 272)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(408, 56)
        Me.GroupBox7.TabIndex = 19
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Category"
        Me.GroupBox7.Visible = False
        '
        'Rad_Exp
        '
        Me.Rad_Exp.Enabled = False
        Me.Rad_Exp.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_Exp.Location = New System.Drawing.Point(288, 19)
        Me.Rad_Exp.Name = "Rad_Exp"
        Me.Rad_Exp.Size = New System.Drawing.Size(112, 24)
        Me.Rad_Exp.TabIndex = 22
        Me.Rad_Exp.Text = "Expenditure"
        '
        'Rad_Income
        '
        Me.Rad_Income.Enabled = False
        Me.Rad_Income.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_Income.Location = New System.Drawing.Point(192, 19)
        Me.Rad_Income.Name = "Rad_Income"
        Me.Rad_Income.Size = New System.Drawing.Size(80, 24)
        Me.Rad_Income.TabIndex = 21
        Me.Rad_Income.Text = "Income"
        '
        'Rad_Lia
        '
        Me.Rad_Lia.Enabled = False
        Me.Rad_Lia.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_Lia.Location = New System.Drawing.Point(88, 19)
        Me.Rad_Lia.Name = "Rad_Lia"
        Me.Rad_Lia.Size = New System.Drawing.Size(88, 24)
        Me.Rad_Lia.TabIndex = 20
        Me.Rad_Lia.Text = "Liability"
        '
        'Rad_Asset
        '
        Me.Rad_Asset.Checked = True
        Me.Rad_Asset.Enabled = False
        Me.Rad_Asset.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_Asset.Location = New System.Drawing.Point(5, 18)
        Me.Rad_Asset.Name = "Rad_Asset"
        Me.Rad_Asset.Size = New System.Drawing.Size(67, 24)
        Me.Rad_Asset.TabIndex = 19
        Me.Rad_Asset.TabStop = True
        Me.Rad_Asset.Text = "Asset"
        '
        'Lbl_SubGroup
        '
        Me.Lbl_SubGroup.AutoSize = True
        Me.Lbl_SubGroup.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_SubGroup.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_SubGroup.Location = New System.Drawing.Point(8, 184)
        Me.Lbl_SubGroup.Name = "Lbl_SubGroup"
        Me.Lbl_SubGroup.Size = New System.Drawing.Size(90, 18)
        Me.Lbl_SubGroup.TabIndex = 16
        Me.Lbl_SubGroup.Text = "SUB GROUP :"
        Me.Lbl_SubGroup.Visible = False
        '
        'Cmb_SubGroup
        '
        Me.Cmb_SubGroup.BackColor = System.Drawing.Color.Wheat
        Me.Cmb_SubGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_SubGroup.Location = New System.Drawing.Point(192, 184)
        Me.Cmb_SubGroup.Name = "Cmb_SubGroup"
        Me.Cmb_SubGroup.Size = New System.Drawing.Size(176, 21)
        Me.Cmb_SubGroup.TabIndex = 15
        Me.Cmb_SubGroup.Visible = False
        '
        'Cmb_Group
        '
        Me.Cmb_Group.BackColor = System.Drawing.Color.Wheat
        Me.Cmb_Group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb_Group.Location = New System.Drawing.Point(192, 152)
        Me.Cmb_Group.Name = "Cmb_Group"
        Me.Cmb_Group.Size = New System.Drawing.Size(176, 21)
        Me.Cmb_Group.TabIndex = 13
        Me.Cmb_Group.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 18)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "GROUP :"
        Me.Label4.Visible = False
        '
        'Txt_AcCode
        '
        Me.Txt_AcCode.BackColor = System.Drawing.Color.Wheat
        Me.Txt_AcCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_AcCode.Location = New System.Drawing.Point(360, 24)
        Me.Txt_AcCode.MaxLength = 10
        Me.Txt_AcCode.Name = "Txt_AcCode"
        Me.Txt_AcCode.TabIndex = 0
        Me.Txt_AcCode.Text = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(192, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 18)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "ACCOUNT CODE :"
        '
        'Cmd_AcCodeHelp
        '
        Me.Cmd_AcCodeHelp.Image = CType(resources.GetObject("Cmd_AcCodeHelp.Image"), System.Drawing.Image)
        Me.Cmd_AcCodeHelp.Location = New System.Drawing.Point(464, 24)
        Me.Cmd_AcCodeHelp.Name = "Cmd_AcCodeHelp"
        Me.Cmd_AcCodeHelp.Size = New System.Drawing.Size(23, 21)
        Me.Cmd_AcCodeHelp.TabIndex = 5
        '
        'GroupBox4
        '
        Me.GroupBox4.BackgroundImage = CType(resources.GetObject("GroupBox4.BackgroundImage"), System.Drawing.Image)
        Me.GroupBox4.Controls.Add(Me.Txt_ProjectedNextYear)
        Me.GroupBox4.Controls.Add(Me.Txt_ActualNextYear)
        Me.GroupBox4.Controls.Add(Me.Txt_ProjectedCurrentYear)
        Me.GroupBox4.Controls.Add(Me.Txt_ActualCurrentYear)
        Me.GroupBox4.Controls.Add(Me.Txt_ProjectedLastYear)
        Me.GroupBox4.Controls.Add(Me.Txt_ActualLastyear)
        Me.GroupBox4.Controls.Add(Me.Lbl_NextYear)
        Me.GroupBox4.Controls.Add(Me.Lbl_CurrentYear)
        Me.GroupBox4.Controls.Add(Me.Lbl_Lastyear)
        Me.GroupBox4.Controls.Add(Me.Lbl_Projected)
        Me.GroupBox4.Controls.Add(Me.Lbl_Actual)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Rdo_BudgetYes)
        Me.GroupBox4.Controls.Add(Me.Rdo_BudgetNo)
        Me.GroupBox4.Location = New System.Drawing.Point(800, 392)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(16, 136)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Visible = False
        '
        'Txt_ProjectedNextYear
        '
        Me.Txt_ProjectedNextYear.Location = New System.Drawing.Point(232, 104)
        Me.Txt_ProjectedNextYear.MaxLength = 8
        Me.Txt_ProjectedNextYear.Name = "Txt_ProjectedNextYear"
        Me.Txt_ProjectedNextYear.Size = New System.Drawing.Size(80, 20)
        Me.Txt_ProjectedNextYear.TabIndex = 6
        Me.Txt_ProjectedNextYear.Text = ""
        Me.Txt_ProjectedNextYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_ActualNextYear
        '
        Me.Txt_ActualNextYear.Location = New System.Drawing.Point(144, 104)
        Me.Txt_ActualNextYear.MaxLength = 8
        Me.Txt_ActualNextYear.Name = "Txt_ActualNextYear"
        Me.Txt_ActualNextYear.Size = New System.Drawing.Size(80, 20)
        Me.Txt_ActualNextYear.TabIndex = 5
        Me.Txt_ActualNextYear.Text = ""
        Me.Txt_ActualNextYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_ProjectedCurrentYear
        '
        Me.Txt_ProjectedCurrentYear.Location = New System.Drawing.Point(232, 80)
        Me.Txt_ProjectedCurrentYear.MaxLength = 8
        Me.Txt_ProjectedCurrentYear.Name = "Txt_ProjectedCurrentYear"
        Me.Txt_ProjectedCurrentYear.Size = New System.Drawing.Size(80, 20)
        Me.Txt_ProjectedCurrentYear.TabIndex = 4
        Me.Txt_ProjectedCurrentYear.Text = ""
        Me.Txt_ProjectedCurrentYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_ActualCurrentYear
        '
        Me.Txt_ActualCurrentYear.Location = New System.Drawing.Point(144, 80)
        Me.Txt_ActualCurrentYear.MaxLength = 8
        Me.Txt_ActualCurrentYear.Name = "Txt_ActualCurrentYear"
        Me.Txt_ActualCurrentYear.Size = New System.Drawing.Size(80, 20)
        Me.Txt_ActualCurrentYear.TabIndex = 3
        Me.Txt_ActualCurrentYear.Text = ""
        Me.Txt_ActualCurrentYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_ProjectedLastYear
        '
        Me.Txt_ProjectedLastYear.Location = New System.Drawing.Point(232, 56)
        Me.Txt_ProjectedLastYear.MaxLength = 8
        Me.Txt_ProjectedLastYear.Name = "Txt_ProjectedLastYear"
        Me.Txt_ProjectedLastYear.Size = New System.Drawing.Size(80, 20)
        Me.Txt_ProjectedLastYear.TabIndex = 2
        Me.Txt_ProjectedLastYear.Text = ""
        Me.Txt_ProjectedLastYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Txt_ActualLastyear
        '
        Me.Txt_ActualLastyear.Location = New System.Drawing.Point(144, 56)
        Me.Txt_ActualLastyear.MaxLength = 8
        Me.Txt_ActualLastyear.Name = "Txt_ActualLastyear"
        Me.Txt_ActualLastyear.Size = New System.Drawing.Size(80, 20)
        Me.Txt_ActualLastyear.TabIndex = 1
        Me.Txt_ActualLastyear.Text = ""
        Me.Txt_ActualLastyear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Lbl_NextYear
        '
        Me.Lbl_NextYear.AutoSize = True
        Me.Lbl_NextYear.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_NextYear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_NextYear.Location = New System.Drawing.Point(24, 104)
        Me.Lbl_NextYear.Name = "Lbl_NextYear"
        Me.Lbl_NextYear.Size = New System.Drawing.Size(91, 18)
        Me.Lbl_NextYear.TabIndex = 42
        Me.Lbl_NextYear.Text = "NEXT YEAR :"
        '
        'Lbl_CurrentYear
        '
        Me.Lbl_CurrentYear.AutoSize = True
        Me.Lbl_CurrentYear.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_CurrentYear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_CurrentYear.Location = New System.Drawing.Point(24, 80)
        Me.Lbl_CurrentYear.Name = "Lbl_CurrentYear"
        Me.Lbl_CurrentYear.Size = New System.Drawing.Size(120, 18)
        Me.Lbl_CurrentYear.TabIndex = 41
        Me.Lbl_CurrentYear.Text = "CURRENT YEAR :"
        '
        'Lbl_Lastyear
        '
        Me.Lbl_Lastyear.AutoSize = True
        Me.Lbl_Lastyear.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Lastyear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Lastyear.Location = New System.Drawing.Point(24, 56)
        Me.Lbl_Lastyear.Name = "Lbl_Lastyear"
        Me.Lbl_Lastyear.Size = New System.Drawing.Size(89, 18)
        Me.Lbl_Lastyear.TabIndex = 40
        Me.Lbl_Lastyear.Text = "LAST YEAR :"
        '
        'Lbl_Projected
        '
        Me.Lbl_Projected.AutoSize = True
        Me.Lbl_Projected.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Projected.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Projected.Location = New System.Drawing.Point(232, 40)
        Me.Lbl_Projected.Name = "Lbl_Projected"
        Me.Lbl_Projected.Size = New System.Drawing.Size(73, 16)
        Me.Lbl_Projected.TabIndex = 39
        Me.Lbl_Projected.Text = "PROJECTED"
        '
        'Lbl_Actual
        '
        Me.Lbl_Actual.AutoSize = True
        Me.Lbl_Actual.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Actual.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Actual.Location = New System.Drawing.Point(160, 40)
        Me.Lbl_Actual.Name = "Lbl_Actual"
        Me.Lbl_Actual.Size = New System.Drawing.Size(52, 16)
        Me.Lbl_Actual.TabIndex = 38
        Me.Lbl_Actual.Text = "ACTUAL"
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.cmdcrystal)
        Me.frmbut.Controls.Add(Me.cmdexport)
        Me.frmbut.Controls.Add(Me.cmdexit)
        Me.frmbut.Controls.Add(Me.CmdFreeze)
        Me.frmbut.Controls.Add(Me.CmdAdd)
        Me.frmbut.Controls.Add(Me.CmdClear)
        Me.frmbut.Location = New System.Drawing.Point(64, 344)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(672, 72)
        Me.frmbut.TabIndex = 4
        Me.frmbut.TabStop = False
        '
        'cmdcrystal
        '
        Me.cmdcrystal.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.cmdcrystal.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdcrystal.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcrystal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdcrystal.Location = New System.Drawing.Point(480, 24)
        Me.cmdcrystal.Name = "cmdcrystal"
        Me.cmdcrystal.Size = New System.Drawing.Size(79, 32)
        Me.cmdcrystal.TabIndex = 25
        Me.cmdcrystal.Text = "&View[F12]"
        '
        'cmdexport
        '
        Me.cmdexport.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.cmdexport.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdexport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexport.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdexport.Location = New System.Drawing.Point(376, 24)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(79, 32)
        Me.cmdexport.TabIndex = 23
        Me.cmdexport.Text = "&Export[F10]"
        Me.cmdexport.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.cmdexit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdexit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdexit.Location = New System.Drawing.Point(584, 24)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(78, 32)
        Me.cmdexit.TabIndex = 5
        Me.cmdexit.Text = "&Exit [F11]"
        '
        'CmdFreeze
        '
        Me.CmdFreeze.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.CmdFreeze.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdFreeze.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdFreeze.Location = New System.Drawing.Point(264, 24)
        Me.CmdFreeze.Name = "CmdFreeze"
        Me.CmdFreeze.Size = New System.Drawing.Size(88, 32)
        Me.CmdFreeze.TabIndex = 4
        Me.CmdFreeze.Text = "&Freeze[F8]"
        '
        'CmdAdd
        '
        Me.CmdAdd.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.CmdAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdAdd.Location = New System.Drawing.Point(160, 24)
        Me.CmdAdd.Name = "CmdAdd"
        Me.CmdAdd.Size = New System.Drawing.Size(79, 32)
        Me.CmdAdd.TabIndex = 0
        Me.CmdAdd.Text = "&Add [F7]"
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.CmdClear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdClear.Location = New System.Drawing.Point(48, 24)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(80, 32)
        Me.CmdClear.TabIndex = 3
        Me.CmdClear.Text = "&Clear [F6]"
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.FromArgb(CType(141, Byte), CType(154, Byte), CType(156, Byte))
        Me.CmdView.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdView.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CmdView.Location = New System.Drawing.Point(352, 440)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(79, 32)
        Me.CmdView.TabIndex = 1
        Me.CmdView.Text = "&View[F9]"
        Me.CmdView.Visible = False
        '
        'Lbl_Freeze
        '
        Me.Lbl_Freeze.AutoSize = True
        Me.Lbl_Freeze.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Freeze.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Freeze.ForeColor = System.Drawing.Color.Red
        Me.Lbl_Freeze.Location = New System.Drawing.Point(320, 280)
        Me.Lbl_Freeze.Name = "Lbl_Freeze"
        Me.Lbl_Freeze.Size = New System.Drawing.Size(239, 31)
        Me.Lbl_Freeze.TabIndex = 6
        Me.Lbl_Freeze.Text = "RECORD FREEZED"
        Me.Lbl_Freeze.Visible = False
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox9.Controls.Add(Me.ChkNew)
        Me.GroupBox9.Controls.Add(Me.Txt_CellNo)
        Me.GroupBox9.Controls.Add(Me.Label29)
        Me.GroupBox9.Controls.Add(Me.Txt_PhoneNo)
        Me.GroupBox9.Controls.Add(Me.Label28)
        Me.GroupBox9.Controls.Add(Me.Txt_Pin)
        Me.GroupBox9.Controls.Add(Me.Label27)
        Me.GroupBox9.Controls.Add(Me.Txt_State)
        Me.GroupBox9.Controls.Add(Me.Label26)
        Me.GroupBox9.Controls.Add(Me.txt_City)
        Me.GroupBox9.Controls.Add(Me.Label25)
        Me.GroupBox9.Controls.Add(Me.Txt_Address3)
        Me.GroupBox9.Controls.Add(Me.Label24)
        Me.GroupBox9.Controls.Add(Me.Txt_Address2)
        Me.GroupBox9.Controls.Add(Me.Label23)
        Me.GroupBox9.Controls.Add(Me.Txt_Address1)
        Me.GroupBox9.Controls.Add(Me.Label22)
        Me.GroupBox9.Controls.Add(Me.Txt_ContactPerson)
        Me.GroupBox9.Controls.Add(Me.Label21)
        Me.GroupBox9.Controls.Add(Me.Txt_PANNo)
        Me.GroupBox9.Controls.Add(Me.Label20)
        Me.GroupBox9.Controls.Add(Me.Txt_GRNNo)
        Me.GroupBox9.Controls.Add(Me.Label19)
        Me.GroupBox9.Controls.Add(Me.Txt_TINNo)
        Me.GroupBox9.Controls.Add(Me.Label18)
        Me.GroupBox9.Controls.Add(Me.Txt_CSTNo)
        Me.GroupBox9.Controls.Add(Me.Label17)
        Me.GroupBox9.Controls.Add(Me.Txt_VATNo)
        Me.GroupBox9.Controls.Add(Me.Label16)
        Me.GroupBox9.Controls.Add(Me.Label15)
        Me.GroupBox9.Controls.Add(Me.Label14)
        Me.GroupBox9.Controls.Add(Me.Txt_SLName)
        Me.GroupBox9.Controls.Add(Me.Cmd_SLCodeHelp)
        Me.GroupBox9.Controls.Add(Me.Txt_SLCode)
        Me.GroupBox9.Controls.Add(Me.Cmb_SLType1)
        Me.GroupBox9.Controls.Add(Me.Label13)
        Me.GroupBox9.Location = New System.Drawing.Point(760, 376)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(72, 136)
        Me.GroupBox9.TabIndex = 10
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Subledger"
        Me.GroupBox9.Visible = False
        '
        'ChkNew
        '
        Me.ChkNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkNew.Location = New System.Drawing.Point(24, 16)
        Me.ChkNew.Name = "ChkNew"
        Me.ChkNew.Size = New System.Drawing.Size(224, 24)
        Me.ChkNew.TabIndex = 115
        Me.ChkNew.Text = "NewSublegerCreation"
        '
        'Txt_CellNo
        '
        Me.Txt_CellNo.Location = New System.Drawing.Point(496, 280)
        Me.Txt_CellNo.MaxLength = 10
        Me.Txt_CellNo.Name = "Txt_CellNo"
        Me.Txt_CellNo.Size = New System.Drawing.Size(120, 20)
        Me.Txt_CellNo.TabIndex = 114
        Me.Txt_CellNo.Text = ""
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(408, 280)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(73, 18)
        Me.Label29.TabIndex = 113
        Me.Label29.Text = "CELL NO :"
        '
        'Txt_PhoneNo
        '
        Me.Txt_PhoneNo.Location = New System.Drawing.Point(496, 248)
        Me.Txt_PhoneNo.MaxLength = 10
        Me.Txt_PhoneNo.Name = "Txt_PhoneNo"
        Me.Txt_PhoneNo.Size = New System.Drawing.Size(120, 20)
        Me.Txt_PhoneNo.TabIndex = 112
        Me.Txt_PhoneNo.Text = ""
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(400, 248)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(84, 18)
        Me.Label28.TabIndex = 111
        Me.Label28.Text = "PHONE NO :"
        '
        'Txt_Pin
        '
        Me.Txt_Pin.Location = New System.Drawing.Point(496, 216)
        Me.Txt_Pin.MaxLength = 6
        Me.Txt_Pin.Name = "Txt_Pin"
        Me.Txt_Pin.Size = New System.Drawing.Size(96, 20)
        Me.Txt_Pin.TabIndex = 110
        Me.Txt_Pin.Text = ""
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(448, 216)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(36, 18)
        Me.Label27.TabIndex = 109
        Me.Label27.Text = "PIN :"
        '
        'Txt_State
        '
        Me.Txt_State.Location = New System.Drawing.Point(496, 192)
        Me.Txt_State.MaxLength = 30
        Me.Txt_State.Name = "Txt_State"
        Me.Txt_State.Size = New System.Drawing.Size(120, 20)
        Me.Txt_State.TabIndex = 108
        Me.Txt_State.Text = ""
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(440, 192)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(57, 18)
        Me.Label26.TabIndex = 107
        Me.Label26.Text = "STATE :"
        '
        'txt_City
        '
        Me.txt_City.Location = New System.Drawing.Point(496, 160)
        Me.txt_City.MaxLength = 50
        Me.txt_City.Name = "txt_City"
        Me.txt_City.Size = New System.Drawing.Size(208, 20)
        Me.txt_City.TabIndex = 106
        Me.txt_City.Text = ""
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(448, 160)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(46, 18)
        Me.Label25.TabIndex = 105
        Me.Label25.Text = "CITY :"
        '
        'Txt_Address3
        '
        Me.Txt_Address3.Location = New System.Drawing.Point(496, 128)
        Me.Txt_Address3.MaxLength = 50
        Me.Txt_Address3.Name = "Txt_Address3"
        Me.Txt_Address3.Size = New System.Drawing.Size(208, 20)
        Me.Txt_Address3.TabIndex = 104
        Me.Txt_Address3.Text = ""
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(408, 128)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(85, 18)
        Me.Label24.TabIndex = 103
        Me.Label24.Text = "ADDRESS 3 :"
        '
        'Txt_Address2
        '
        Me.Txt_Address2.Location = New System.Drawing.Point(496, 96)
        Me.Txt_Address2.MaxLength = 50
        Me.Txt_Address2.Name = "Txt_Address2"
        Me.Txt_Address2.Size = New System.Drawing.Size(208, 20)
        Me.Txt_Address2.TabIndex = 102
        Me.Txt_Address2.Text = ""
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(408, 96)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(85, 18)
        Me.Label23.TabIndex = 101
        Me.Label23.Text = "ADDRESS 2 :"
        '
        'Txt_Address1
        '
        Me.Txt_Address1.Location = New System.Drawing.Point(496, 64)
        Me.Txt_Address1.MaxLength = 50
        Me.Txt_Address1.Name = "Txt_Address1"
        Me.Txt_Address1.Size = New System.Drawing.Size(208, 20)
        Me.Txt_Address1.TabIndex = 100
        Me.Txt_Address1.Text = ""
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(408, 64)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(85, 18)
        Me.Label22.TabIndex = 99
        Me.Label22.Text = "ADDRESS 1 :"
        '
        'Txt_ContactPerson
        '
        Me.Txt_ContactPerson.Location = New System.Drawing.Point(496, 24)
        Me.Txt_ContactPerson.MaxLength = 50
        Me.Txt_ContactPerson.Name = "Txt_ContactPerson"
        Me.Txt_ContactPerson.Size = New System.Drawing.Size(232, 20)
        Me.Txt_ContactPerson.TabIndex = 98
        Me.Txt_ContactPerson.Text = ""
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(368, 24)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(137, 18)
        Me.Label21.TabIndex = 97
        Me.Label21.Text = "CONTACT PERSON :"
        '
        'Txt_PANNo
        '
        Me.Txt_PANNo.Location = New System.Drawing.Point(88, 264)
        Me.Txt_PANNo.MaxLength = 15
        Me.Txt_PANNo.Name = "Txt_PANNo"
        Me.Txt_PANNo.Size = New System.Drawing.Size(88, 20)
        Me.Txt_PANNo.TabIndex = 96
        Me.Txt_PANNo.Text = ""
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(8, 264)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 18)
        Me.Label20.TabIndex = 95
        Me.Label20.Text = "PAN NO :"
        '
        'Txt_GRNNo
        '
        Me.Txt_GRNNo.Location = New System.Drawing.Point(88, 232)
        Me.Txt_GRNNo.MaxLength = 15
        Me.Txt_GRNNo.Name = "Txt_GRNNo"
        Me.Txt_GRNNo.Size = New System.Drawing.Size(88, 20)
        Me.Txt_GRNNo.TabIndex = 94
        Me.Txt_GRNNo.Text = ""
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(8, 232)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(66, 18)
        Me.Label19.TabIndex = 93
        Me.Label19.Text = "GRN NO :"
        '
        'Txt_TINNo
        '
        Me.Txt_TINNo.Location = New System.Drawing.Point(88, 200)
        Me.Txt_TINNo.MaxLength = 15
        Me.Txt_TINNo.Name = "Txt_TINNo"
        Me.Txt_TINNo.Size = New System.Drawing.Size(88, 20)
        Me.Txt_TINNo.TabIndex = 92
        Me.Txt_TINNo.Text = ""
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(16, 200)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(60, 18)
        Me.Label18.TabIndex = 91
        Me.Label18.Text = "TIN NO :"
        '
        'Txt_CSTNo
        '
        Me.Txt_CSTNo.Location = New System.Drawing.Point(88, 168)
        Me.Txt_CSTNo.MaxLength = 15
        Me.Txt_CSTNo.Name = "Txt_CSTNo"
        Me.Txt_CSTNo.Size = New System.Drawing.Size(88, 20)
        Me.Txt_CSTNo.TabIndex = 90
        Me.Txt_CSTNo.Text = ""
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(16, 168)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(62, 18)
        Me.Label17.TabIndex = 89
        Me.Label17.Text = "CST NO :"
        '
        'Txt_VATNo
        '
        Me.Txt_VATNo.Location = New System.Drawing.Point(88, 136)
        Me.Txt_VATNo.MaxLength = 15
        Me.Txt_VATNo.Name = "Txt_VATNo"
        Me.Txt_VATNo.Size = New System.Drawing.Size(88, 20)
        Me.Txt_VATNo.TabIndex = 88
        Me.Txt_VATNo.Text = ""
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(16, 136)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 18)
        Me.Label16.TabIndex = 87
        Me.Label16.Text = "VAT NO :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(16, 96)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 18)
        Me.Label15.TabIndex = 85
        Me.Label15.Text = "SL NAME :"
        Me.Label15.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(16, 96)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 18)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "SLCODE :"
        Me.Label14.Visible = False
        '
        'Txt_SLName
        '
        Me.Txt_SLName.BackColor = System.Drawing.Color.Wheat
        Me.Txt_SLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_SLName.Location = New System.Drawing.Point(88, 96)
        Me.Txt_SLName.MaxLength = 30
        Me.Txt_SLName.Name = "Txt_SLName"
        Me.Txt_SLName.Size = New System.Drawing.Size(200, 20)
        Me.Txt_SLName.TabIndex = 86
        Me.Txt_SLName.Text = ""
        Me.Txt_SLName.Visible = False
        '
        'Cmd_SLCodeHelp
        '
        Me.Cmd_SLCodeHelp.Location = New System.Drawing.Point(248, 96)
        Me.Cmd_SLCodeHelp.Name = "Cmd_SLCodeHelp"
        Me.Cmd_SLCodeHelp.Size = New System.Drawing.Size(23, 21)
        Me.Cmd_SLCodeHelp.TabIndex = 84
        Me.Cmd_SLCodeHelp.Visible = False
        '
        'Txt_SLCode
        '
        Me.Txt_SLCode.BackColor = System.Drawing.Color.Wheat
        Me.Txt_SLCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txt_SLCode.Location = New System.Drawing.Point(88, 96)
        Me.Txt_SLCode.MaxLength = 10
        Me.Txt_SLCode.Name = "Txt_SLCode"
        Me.Txt_SLCode.Size = New System.Drawing.Size(160, 20)
        Me.Txt_SLCode.TabIndex = 8
        Me.Txt_SLCode.Text = ""
        Me.Txt_SLCode.Visible = False
        '
        'Cmb_SLType1
        '
        Me.Cmb_SLType1.BackColor = System.Drawing.Color.Wheat
        Me.Cmb_SLType1.Items.AddRange(New Object() {"MEMBER", "SUPPLIER", "EMPLOYEE"})
        Me.Cmb_SLType1.Location = New System.Drawing.Point(88, 56)
        Me.Cmb_SLType1.Name = "Cmb_SLType1"
        Me.Cmb_SLType1.Size = New System.Drawing.Size(160, 21)
        Me.Cmb_SLType1.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 18)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "SL TYPE :"
        '
        'GLACCOUNTMASTER_Others
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(872, 694)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox9)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Lbl_Freeze)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_Alias)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Rdo_SubLedgerNo)
        Me.Controls.Add(Me.Rdo_SubLedgerYes)
        Me.Controls.Add(Me.CmdView)
        Me.KeyPreview = True
        Me.Name = "GLACCOUNTMASTER_Others"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "`"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.pnlBank.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.frmbut.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim vconn As New GlobalClass
    Dim gconnection As New GlobalClass
    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        'If MsgBox("Close this form", MsgBoxStyle.OKCancel + MsgBoxStyle.Question, Me.Text) = MsgBoxResult.OK Then
        'vconn.FreezeStockinHand()

        Me.Close()
        'Else
        'Txt_AcCode.Focus()
        'End If
    End Sub
    Private Sub GLACCOUNTMASTER_Others_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        Try
            pnlBank.Visible = False
            Txt_AcCode.Focus()
            Rdo_SubLedgerNo.Checked = False
            Cmb_AcType.SelectedIndex = 0
            Rdo_SubLedgerNo.Checked = False
            Rdo_BalanceAsOnDebit.Checked = True
            Rdo_OpeningBalanceDebit.Checked = True
            Rdo_BudgetNo.Checked = True
            Txt_AcCode.Enabled = True
            Txt_OpeningBalance.Text = 0
            Txt_BalanceAsOn.Text = 0
            Txt_ActualLastyear.Text = 0
            Txt_ProjectedLastYear.Text = 0
            Txt_ActualCurrentYear.Text = 0
            Txt_ProjectedCurrentYear.Text = 0
            Txt_ActualNextYear.Text = 0
            Txt_ProjectedNextYear.Text = 0
            Dim sqlstring As String
            Dim DR, DR1 As DataRow
            Me.CmdFreeze.Enabled = False
            Cmb_Group.Items.Clear()
            Cmb_SubGroup.Items.Clear()
            Cmb_SubSubGroup.Items.Clear()
            'sqlstring = "select groupdesc from accountsgroupmaster Where Isnull(FreezeFlag,'') <> 'Y' "

            'vconn.UnFreezeStockinHand()

            sqlstring = "select Distinct groupdesc from accountsgroupmaster Where Isnull(FreezeFlag,'') <> 'Y' "
            vconn.getDataSet(sqlstring, "GROUPDESC")
            If gdataset.Tables("GROUPDESC").Rows.Count > 0 Then
                For Each DR In gdataset.Tables("GROUPDESC").Rows
                    Cmb_Group.Items.Add(Trim(DR("GROUPDESC")))
                Next
                Cmb_Group.SelectedIndex = 0
                'sqlstring = "select SUBGROUPDESC from AccountsSubGroupMaster WHERE GROUPDESC ='" & Cmb_Group.Text & "' And Isnull(FreezeFlag,'')<> 'Y' "
                sqlstring = "select Distinct SUBGROUPDESC from AccountsSubGroupMaster WHERE GROUPDESC ='" & Cmb_Group.Text & "' And Isnull(FreezeFlag,'')<> 'Y' "
                vconn.getDataSet(sqlstring, "SUBGROUPDESC")
                If gdataset.Tables("SUBGROUPDESC").Rows.Count > 0 Then
                    For Each DR1 In gdataset.Tables("SUBGROUPDESC").Rows
                        Cmb_SubGroup.Items.Add(Trim(DR1("SUBGROUPDESC")))
                    Next
                    Cmb_SubGroup.SelectedIndex = 0
                    Me.Lbl_SubGroup.Visible = True
                    Cmb_SubGroup.Visible = True
                Else
                    Cmb_SubGroup.Visible = False
                    Me.Lbl_SubGroup.Visible = False
                End If


                'Sub Sub Group
                Cmb_SubSubGroup.Items.Clear()
                sqlstring = "select Distinct SUBSUBGROUPDESC from AccountsSubSubGroupMaster WHERE SUBGROUPDESC ='" & Cmb_SubGroup.Text & "' And Isnull(FreezeFlag,'')<> 'Y' "
                vconn.getDataSet(sqlstring, "SUBGROUPDESC")
                If gdataset.Tables("SUBGROUPDESC").Rows.Count > 0 Then
                    For Each DR1 In gdataset.Tables("SUBGROUPDESC").Rows
                        Cmb_SubSubGroup.Items.Add(Trim(DR1("SUBSUBGROUPDESC")))
                    Next
                    Cmb_SubSubGroup.SelectedIndex = 0
                    Me.Lbl_SubSubGroup.Visible = True
                    Cmb_SubSubGroup.Visible = True
                Else
                    Me.Lbl_SubSubGroup.Visible = False
                    Cmb_SubSubGroup.Visible = False
                End If
            Else
                Me.Lbl_SubSubGroup.Visible = False
                Cmb_SubSubGroup.Visible = False

                Me.Lbl_SubSubGroup.Visible = False
                Cmb_SubSubGroup.Visible = False
            End If
            GroupBox9.Visible = False

            Lbl_sltype.Visible = False
            Cmb_SLType.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Txt_AcCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_AcCode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If (Trim(Txt_AcCode.Text)) <> "" Then
                Txt_AcCode_Validated(Txt_AcCode, e)
            Else
                Call Cmd_AcCodeHelp_Click(sender, e)
            End If
            Txt_AcDesc.Focus()
        End If
    End Sub
    Private Sub Txt_AcCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_AcCode.Validated
        Dim sqlstring As String
        sqlstring = "select * from accountsglaccountmaster where accode = '" & Trim(Txt_AcCode.Text) & "'"
        vconn.getDataSet(sqlstring, "accountsglaccountmaster")
        If gdataset.Tables("accountsglaccountmaster").Rows.Count > 0 Then

            Txt_AcDesc.Text = Trim(UCase(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("acdesc")))

            'If IsDBNull(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("ALIAS")) = False Then
            '    Txt_Alias.Text = Trim(UCase(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("alias")))
            'Else
            '    Me.Txt_Alias.Text = ""
            'End If

            'If IsDBNull(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("Bank")) = False Then
            '    Txt_BankName.Text = Trim(UCase(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("Bank")))
            '    Txt_BankAddress.Text = Trim(UCase(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("BankAddress")))
            'End If

            'If gdataset.Tables("accountsglaccountmaster").Rows(0).Item("subledgerflag") = "Y" Then
            '    Rdo_SubLedgerYes.Checked = True
            '    Rdo_SubLedgerNo.Checked = False
            'Else
            '    Rdo_SubLedgerNo.Checked = True
            '    Rdo_SubLedgerYes.Checked = False
            'End If
            'Cmb_Group.SelectedIndex = Cmb_Group.FindString(Trim(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("groupname")))

            'If IsDBNull(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("subgroup")) = False Then
            '    Cmb_SubGroup.Text = gdataset.Tables("accountsglaccountmaster").Rows(0).Item("subgroup")
            'End If

            'Cmb_SubGroup.SelectedIndex = Cmb_SubGroup.FindString(Trim(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("SubGroup")))

            'If IsDBNull(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("SubSubgroup")) = False Then
            '    Cmb_SubSubGroup.Text = gdataset.Tables("accountsglaccountmaster").Rows(0).Item("SubSubgroup")
            'End If

            'Cmb_AcType.SelectedIndex = Cmb_AcType.FindString(Trim(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("actype")))
            'If gdataset.Tables("accountsglaccountmaster").Rows(0).Item("budgetflag") = "Y" Then
            '    Rdo_BudgetYes.Checked = True
            'Else
            '    Rdo_BudgetNo.Checked = True
            'End If

            'Cmb_SLType.Text = gdataset.Tables("accountsglaccountmaster").Rows(0).Item("sltype")

            'If gdataset.Tables("accountsglaccountmaster").Rows(0).Item("opdebits") <> 0 Then
            '    Txt_OpeningBalance.Text = Format(Val(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("opdebits")), "0.00")
            '    Rdo_OpeningBalanceDebit.Checked = True
            'Else
            '    Txt_OpeningBalance.Text = Format(Val(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("opcredits")), "0.00")
            '    Rdo_OpeningBalanceCredit.Checked = True
            'End If
            'If IsDBNull(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("cldebits")) = False Then
            '    If gdataset.Tables("accountsglaccountmaster").Rows(0).Item("cldebits") <> 0 Then
            '        Txt_BalanceAsOn.Text = Format(Val(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("cldebits")), "0.00")
            '        Rdo_BalanceAsOnDebit.Checked = True
            '    End If
            '    If IsDBNull(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("clCredits")) = False Then
            '        Txt_BalanceAsOn.Text = Format(Val(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("clcredits")), "0.00")
            '        Rdo_BalanceAsOnCredit.Checked = True
            '    End If
            'End If
            If gdataset.Tables("accountsglaccountmaster").Rows(0).Item("freezeflag") = "Y" Then
                Lbl_Freeze.Visible = True
            Else
                Lbl_Freeze.Visible = False
            End If

            'Txt_ActualLastyear.Text = Format(Val(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("Actuallastyear")), "0.00")
            'Txt_ProjectedLastYear.Text = Format(Val(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("ProjectedLastyear")), "0.00")
            'Txt_ActualCurrentYear.Text = Format(Val(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("ActualCurrentyear")), "0.00")
            'Txt_ProjectedCurrentYear.Text = Format(Val(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("ProjectedCurrentyear")), "0.00")
            'Txt_ActualNextYear.Text = Format(Val(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("ActualNextyear")), "0.00")
            'Txt_ProjectedNextYear.Text = Format(Val(gdataset.Tables("accountsglaccountmaster").Rows(0).Item("ProjectedNextYear")), "0.00")
            'If gdataset.Tables("accountsglaccountmaster").Rows(0).IsNull("BsPl") = False Then
            '    If gdataset.Tables("accountsglaccountmaster").Rows(0).Item("BsPl") = "B" Then
            '        Me.Rad_Bal.Checked = True
            '    End If
            '    If gdataset.Tables("accountsglaccountmaster").Rows(0).Item("BsPl") = "P" Then
            '        Me.Rad_Pl.Checked = True
            '    End If
            'End If
            'If gdataset.Tables("accountsglaccountmaster").Rows(0).IsNull("Category") = False Then
            '    If gdataset.Tables("accountsglaccountmaster").Rows(0).Item("Category") = "A" Then
            '        Me.Rad_Asset.Checked = True
            '    End If
            '    If gdataset.Tables("accountsglaccountmaster").Rows(0).Item("Category") = "L" Then
            '        Me.Rad_Lia.Checked = True
            '    End If
            '    If gdataset.Tables("accountsglaccountmaster").Rows(0).Item("Category") = "I" Then
            '        Me.Rad_Income.Checked = True
            '        Me.Rad_Income.Enabled = True
            '    End If
            '    If gdataset.Tables("accountsglaccountmaster").Rows(0).Item("Category") = "E" Then
            '        Me.Rad_Exp.Checked = True
            '        Me.Rad_Exp.Enabled = True
            '    End If
            'End If
            If gdataset.Tables("accountsglaccountmaster").Rows(0).Item("freezeflag") = "Y" Then
                Lbl_Freeze.Visible = True
                CmdAdd.Enabled = False
                CmdFreeze.Text = "&UnFreeze[F8]"
            Else
                Lbl_Freeze.Visible = False
            End If
            Me.CmdFreeze.Enabled = True
            Txt_AcCode.Enabled = False
            Txt_AcDesc.Focus()
            CmdAdd.Text = "&Update[F7]"
        End If
    End Sub
    Private Sub Txt_AcDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_AcDesc.KeyPress
        'getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(Me.Txt_AcDesc.Text) <> "" Then
                Txt_Alias.Focus()
            Else
                Call Cmd_AcCodeHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub Txt_Alias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_Alias.KeyPress
        'getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Rdo_SubLedgerNo.Focus()
        End If
    End Sub
    Private Sub Rdo_SubLedgerYes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_SubLedgerYes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cmb_Group.Focus()
        End If
    End Sub
    Private Sub Rdo_SubLedgerNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_SubLedgerNo.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cmb_Group.Focus()
        End If
    End Sub

    Private Sub Cmb_Group_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cmb_Group.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Cmb_AcType.Focus()
        End If
    End Sub

    Private Sub Cmb_AcType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Cmb_AcType.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Me.Txt_BankName.Enabled = True Then
                Me.Txt_BankName.Focus()
            Else
                Txt_OpeningBalance.Focus()
            End If

        End If
    End Sub

    Private Sub Txt_OpeningBalance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_OpeningBalance.KeyPress
        'getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Rdo_OpeningBalanceDebit.Focus()
        End If
    End Sub
    Private Sub Rdo_OpeningBalanceDebit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_OpeningBalanceDebit.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_BalanceAsOn.Focus()
        End If
    End Sub
    Private Sub Rdo_OpeningBalanceCredit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_OpeningBalanceCredit.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_BalanceAsOn.Focus()
        End If
    End Sub
    Private Sub Txt_BalanceAsOn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_BalanceAsOn.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Rdo_BalanceAsOnDebit.Focus()
        End If
    End Sub
    Private Sub Rdo_BalanceAsOnDebit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_BalanceAsOnDebit.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Rdo_BudgetYes.Focus()
        End If
    End Sub
    Private Sub Rdo_BalanceAsOnCredit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_BalanceAsOnCredit.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Rdo_BudgetYes.Focus()
        End If
    End Sub
    Private Sub Rdo_BudgetYes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Rdo_BudgetYes.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Txt_ActualLastyear.Focus()
        End If
    End Sub
    Private Sub Txt_ActualLastyear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ActualLastyear.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_ProjectedLastYear.Focus()
        End If
    End Sub
    Private Sub Txt_ProjectedLastYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ProjectedLastYear.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_ActualCurrentYear.Focus()
        End If
    End Sub
    Private Sub Txt_ActualCurrentYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ActualCurrentYear.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_ProjectedCurrentYear.Focus()
        End If
    End Sub
    Private Sub Txt_ProjectedCurrentYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ProjectedCurrentYear.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_ActualNextYear.Focus()
        End If
    End Sub
    Private Sub Txt_ActualNextYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ActualNextYear.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            Txt_ProjectedNextYear.Focus()
        End If
    End Sub
    Private Sub Txt_ProjectedNextYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_ProjectedNextYear.KeyPress
        getNumeric(e)
        If Asc(e.KeyChar) = 13 Then
            CmdAdd.Focus()
        End If
    End Sub
    Private Sub CmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAdd.Click
        Dim sqlstring As String
        Dim subledgerflag, budgetflag, Category, BsPl As String
        Dim opdebits, opcredits As Double
        Dim cldebits, clcredits As Double
        If Mevalidate() = False Then Exit Sub

        'If Rad_Bal.Checked = True Then BsPl = "B"
        'If Rad_Pl.Checked = True Then BsPl = "P"

        'If Rdo_SubLedgerYes.Checked = True Then
        '    subledgerflag = "Y"
        'Else
        '    subledgerflag = "N"
        'End If

        'Category = ""

        'If Me.Rad_Asset.Checked = True Then
        '    Category = "A"
        'End If
        'If Me.Rad_Lia.Checked = True Then
        '    Category = "L"
        'End If
        'If Me.Rad_Exp.Checked = True Then
        '    Category = "E"
        'End If
        'If Me.Rad_Income.Checked = True Then
        '    Category = "I"
        'End If

        'If Trim(Category) = "" Then
        '    MsgBox("Pls Choose the category", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, Me.Text)
        '    Me.Rad_Income.Enabled = True
        '    Me.Rad_Exp.Enabled = True
        '    Me.Rad_Income.Focus()
        '    Exit Sub
        'End If

        'If Rdo_OpeningBalanceDebit.Checked = True Then
        '    opdebits = Val(Txt_OpeningBalance.Text)
        '    opcredits = 0.0
        'Else
        '    opcredits = Val(Txt_OpeningBalance.Text)
        '    opdebits = 0.0
        'End If
        'If Rdo_BalanceAsOnDebit.Checked = True Then
        '    cldebits = Val(Txt_BalanceAsOn.Text)
        '    clcredits = 0.0
        'Else
        '    clcredits = Val(Txt_BalanceAsOn.Text)
        '    cldebits = 0.0
        'End If

        'If Rdo_BudgetYes.Checked = True Then
        '    budgetflag = "Y"
        'Else
        '    budgetflag = "N"
        'End If


        'If Rdo_SubLedgerNo.Checked = True Then
        '    Dim SDCSql As String

        '    SDCSql = "Select * from AccountsGlAccountmaster Where Accode = '" & Txt_AcCode.Text & "' and isnull(subledgerflag,'')='Y'"
        '    vconn.getDataSet(SDCSql, "SubLedgerFlag")
        '    If (gdataset.Tables("SubLedgerFlag").Rows.Count > 0) Then
        '        SDCSql = "Select * from JournalEntry Where Accountcode = '" & Txt_AcCode.Text & "' and isnull(slcode,'')<>''"
        '        vconn.getDataSet(SDCSql, "Validation")
        '        If (gdataset.Tables("Validation").Rows.Count <= 0) Then
        '            SDCSql = "Select * from accountssubledgermaster Where Accode = '" & Txt_AcCode.Text & "' and isnull(slcode,'')<>'' and (isnull(opcredits,0)>0 or isnull(opdebits,0)>0)"
        '            vconn.getDataSet(SDCSql, "Validation_asm")
        '            If (gdataset.Tables("Validation_asm").Rows.Count > 0) Then
        '                Rdo_SubLedgerYes.Checked = True
        '                Rdo_SubLedgerNo.Checked = False
        '                MsgBox("Sub Ledger having Transaction......", "Subledger")
        '                Exit Sub
        '            Else
        '                SDCSql = "Select * from accountssubledgermaster Where Accode = '" & Txt_AcCode.Text & "' and isnull(slcode,'')<>''"
        '                vconn.getDataSet(SDCSql, "Validation_asm")
        '                If (gdataset.Tables("Validation_asm").Rows.Count > 0) Then
        '                    sqlstring = "DELETE FROM accountssubledgermaster where accode='" & Trim(Txt_AcCode.Text) & "'"
        '                    vconn.dataOperation(1, sqlstring)
        '                End If
        '            End If
        '        End If
        '    End If
        'End If


        If CmdAdd.Text = "&Add [F7]" Then
            sqlstring = "INSERT INTO accountsglaccountmaster(accode, acdesc, alias, subledgerflag, groupname, "
            sqlstring = sqlstring & " subgroup,subsubgroup, actype, opdebits, opcredits, budgetflag, bank, bankaddress, "
            sqlstring = sqlstring & " actuallastyear, projectedlastyear, actualcurrentyear, projectedcurrentyear, "
            sqlstring = sqlstring & " actualnextyear, projectednextyear,"
            sqlstring = sqlstring & " adduserid, adddatetime, updateuserid, updatedatetime, "
            sqlstring = sqlstring & " freezeflag, "
            sqlstring = sqlstring & " freezeuserid, freezedatetime,Category,BsPl,sltype) "
            sqlstring = sqlstring & " values ('" & Trim(Txt_AcCode.Text) & "' , '" & Trim(Txt_AcDesc.Text) & "', '" & Trim(Txt_Alias.Text) & "', '"
            sqlstring = sqlstring & subledgerflag & "', '" & Trim(Cmb_Group.Text) & "','" & Trim(Cmb_SubGroup.Text) & "','" & Trim(Cmb_SubSubGroup.Text) & "', '" & Trim(Cmb_AcType.Text) & "', "
            sqlstring = sqlstring & opdebits & ", " & opcredits & ",'"
            sqlstring = sqlstring & budgetflag & "' , '" & Me.Txt_BankName.Text & "','" & Me.Txt_BankAddress.Text & "'," & Format(Val(Txt_ActualLastyear.Text), "0.00") & "  , "
            sqlstring = sqlstring & Format(Val(Txt_ProjectedLastYear.Text), "0.00") & "  , "
            sqlstring = sqlstring & Format(Val(Txt_ActualCurrentYear.Text), "0.00") & "  , "
            sqlstring = sqlstring & Format(Val(Txt_ProjectedCurrentYear.Text), "0.00") & "  , "
            sqlstring = sqlstring & Format(Val(Txt_ActualNextYear.Text), "0.00") & "  , "
            sqlstring = sqlstring & Format(Val(Txt_ProjectedNextYear.Text), "0.00") & "  , '"
            sqlstring = sqlstring & gUsername & "','" & Format(DateValue(Now), "dd-MMM-yyyy") & "', '', '', "
            sqlstring = sqlstring & "'N','','','" & Category & "','" & BsPl & "','" & Trim(Cmb_SLType.Text) & "')"
            vconn.dataOperation(1, sqlstring)
            'End If
        Else
            sqlstring = "update accountsglaccountmaster set  acdesc = '" & Trim(Txt_AcDesc.Text) & "',alias = '" & Trim(Txt_Alias.Text) & "',"
            sqlstring = sqlstring & " subledgerflag = '" & subledgerflag & "', groupname= '" & Trim(Cmb_Group.Text) & "', subgroup = '" & Trim(Cmb_SubGroup.Text) & "',SubSubgroup = '" & Trim(Cmb_SubSubGroup.Text) & "', actype='" & Trim(Cmb_AcType.Text) & "', "
            'sqlstring = sqlstring & "opdebits = " & opdebits & ", opcredits= " & opcredits & ", cldebits = " & cldebits & ", clcredits= " & clcredits & ",budgetflag='" & budgetflag & "',bank='',bankaddress='', "
            sqlstring = sqlstring & "opdebits = " & opdebits & ", opcredits= " & opcredits & ",budgetflag='" & budgetflag & "',bank=' " & Me.Txt_BankName.Text & "',bankaddress=' " & Me.Txt_BankAddress.Text & "', "
            sqlstring = sqlstring & " actuallastyear = " & Format(Val(Txt_ActualLastyear.Text), "0.00") & ", "
            sqlstring = sqlstring & " projectedlastyear =" & Format(Val(Txt_ProjectedLastYear.Text), "0.00") & ", "
            sqlstring = sqlstring & "actualcurrentyear = " & Format(Val(Txt_ActualCurrentYear.Text), "0.00") & "  , "
            sqlstring = sqlstring & "projectedcurrentyear =" & Format(Val(Txt_ProjectedCurrentYear.Text), "0.00") & "  , "
            sqlstring = sqlstring & "actualnextyear =" & Format(Val(Txt_ActualNextYear.Text), "0.00") & "  , "
            sqlstring = sqlstring & "projectednextyear =" & Format(Val(Txt_ProjectedNextYear.Text), "0.00") & " , "
            sqlstring = sqlstring & " updateuserid ='" & gUsername & "', updatedatetime = '" & Format(DateValue(Now), "dd-MMM-yyyy") & "'"
            sqlstring = sqlstring & ",freezeflag = 'N', freezeuserid = '', freezedatetime = '',Category='" & Category & "',BsPl='" & BsPl & "',sltype='" & Cmb_SLType.Text & "'"
            sqlstring = sqlstring & " where accode = '" & Trim(Txt_AcCode.Text) & "'"
            vconn.dataOperation(2, sqlstring)
        End If

        Call CmdClear_Click(sender, e)
        Txt_AcCode.Enabled = True
        Txt_AcCode.Focus()
    End Sub
    Private Sub Cmd_AcCodeHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_AcCodeHelp.Click
        Dim vform As New ListOperattion1
        gSQLString = "select accode,acdesc,isnull(category,'A') as category from accountsglaccountmaster"
        M_WhereCondition = ""
        vform.Field = "acdesc,accode,category"
        vform.vFormatstring = "  ACCOUNT CODE | ACCOUNT DESC                            | CATEGORY|"
        vform.vCaption = "GENERAL LEDGER MASTER HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1
        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            Txt_AcCode.Text = Trim(vform.keyfield & "")
            Txt_AcDesc.Text = Trim(vform.keyfield1 & "")
            Txt_AcCode_Validated(sender, e)
            Txt_AcDesc.Focus()
        Else
            Me.Txt_AcCode.Focus()
        End If
        vform.Close()
        vform = Nothing
    End Sub

    Private Sub CmdFreeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdFreeze.Click
        Dim status As Integer
        Dim sqlstring As String
        If Mevalidate() = False Then Exit Sub
        If CmdFreeze.Text = "Freeze[F8]" Then
            status = MsgBox("ARE U SURE U WANT TO FREEZE THE RECORD", MsgBoxStyle.OKCancel, Me.Text)
            If status = 1 Then
                sqlstring = "update accountsglaccountmaster set freezeflag = 'Y',FreezeUserId='" & gUsername & "',FreezeDateTime='" & Format(DateValue(Now), "dd-MMM-yyyy") & "'" & " where accode = '" & Trim(Txt_AcCode.Text) & "'"
                vconn.dataOperation(2, sqlstring)
                Lbl_Freeze.Text = "RECORD FREEZED"
                Lbl_Freeze.Visible = True
                CmdFreeze.Text = "&UnFreeze[F8]"
                Me.CmdAdd.Enabled = False
            Else
                Exit Sub
            End If
        Else
            status = MsgBox("ARE U SURE U WANT TO UNFREEZE THE RECORD", MsgBoxStyle.OKCancel, Me.Text)
            If status = 1 Then
                sqlstring = "update accountsglaccountmaster set freezeflag = 'N',FreezeUserId='',FreezeDateTime='' where accode = '" & Trim(Txt_AcCode.Text) & "'"
                vconn.dataOperation(2, sqlstring)
                Lbl_Freeze.Text = "RECORD UNFREEZED"
                Lbl_Freeze.Visible = False
                CmdFreeze.Text = "&Freeze[F8]"
                Me.CmdAdd.Enabled = True
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        Dim FrReport As New ReportDesigner
        tables = " FROM accountsglaccountmaster"
        Gheader = "GL ACCOUNT MASTER"
        FrReport.SsGridReport.SetText(2, 1, "AcCode")
        FrReport.SsGridReport.SetText(3, 1, 10)
        FrReport.SsGridReport.SetText(4, 1, "AcCode")
        FrReport.SsGridReport.SetText(8, 1, "S")

        FrReport.SsGridReport.SetText(2, 2, "AcDesc")
        FrReport.SsGridReport.SetText(3, 2, 100)
        FrReport.SsGridReport.SetText(4, 2, "AcDesc")
        FrReport.SsGridReport.SetText(8, 2, "S")

        FrReport.SsGridReport.SetText(2, 3, "SubLedgerFlag")
        FrReport.SsGridReport.SetText(3, 3, 1)
        FrReport.SsGridReport.SetText(4, 3, "LedFlg")
        FrReport.SsGridReport.SetText(8, 3, "S")

        FrReport.SsGridReport.SetText(2, 4, "GroupName")
        FrReport.SsGridReport.SetText(3, 4, 30)
        FrReport.SsGridReport.SetText(4, 4, "GroupName")
        FrReport.SsGridReport.SetText(8, 4, "S")

        FrReport.SsGridReport.SetText(2, 5, "SubGroup")
        FrReport.SsGridReport.SetText(3, 5, 30)
        FrReport.SsGridReport.SetText(4, 5, "SubGrp")
        FrReport.SsGridReport.SetText(8, 5, "S")

        FrReport.SsGridReport.SetText(2, 6, "Actype")
        FrReport.SsGridReport.SetText(3, 6, 30)
        FrReport.SsGridReport.SetText(4, 6, "Type")
        FrReport.SsGridReport.SetText(8, 6, "S")

        FrReport.SsGridReport.SetText(2, 7, "BudgetFlag")
        FrReport.SsGridReport.SetText(3, 7, 1)
        FrReport.SsGridReport.SetText(4, 7, "BudFlg")
        FrReport.SsGridReport.SetText(8, 7, "S")

        FrReport.SsGridReport.SetText(2, 8, "Bank")
        FrReport.SsGridReport.SetText(3, 8, 30)
        FrReport.SsGridReport.SetText(4, 8, "Bank")
        FrReport.SsGridReport.SetText(8, 8, "S")

        FrReport.SsGridReport.SetText(2, 9, "BankAddress")
        FrReport.SsGridReport.SetText(3, 9, 30)
        FrReport.SsGridReport.SetText(4, 9, "BankAdd")
        FrReport.SsGridReport.SetText(8, 9, "S")

        FrReport.SsGridReport.SetText(2, 10, "OpDebits")
        FrReport.SsGridReport.SetText(3, 10, 13)
        FrReport.SsGridReport.SetText(4, 10, "OpDeb")
        FrReport.SsGridReport.SetText(8, 10, "N")

        FrReport.SsGridReport.SetText(2, 11, "OpCredits")
        FrReport.SsGridReport.SetText(3, 11, 13)
        FrReport.SsGridReport.SetText(4, 11, "OpCre")
        FrReport.SsGridReport.SetText(8, 11, "N")

        FrReport.SsGridReport.SetText(2, 12, "ClDebits")
        FrReport.SsGridReport.SetText(3, 12, 13)
        FrReport.SsGridReport.SetText(4, 12, "ClDeb")
        FrReport.SsGridReport.SetText(8, 12, "N")

        FrReport.SsGridReport.SetText(2, 13, "ClCredits")
        FrReport.SsGridReport.SetText(3, 13, 13)
        FrReport.SsGridReport.SetText(4, 13, "ClCre")
        FrReport.SsGridReport.SetText(8, 13, "N")

        FrReport.SsGridReport.SetText(2, 14, "ActuallastYear")
        FrReport.SsGridReport.SetText(3, 14, 9)
        FrReport.SsGridReport.SetText(4, 14, "ALstYr")
        FrReport.SsGridReport.SetText(8, 14, "N")

        FrReport.SsGridReport.SetText(2, 15, "ProjectedLastYear")
        FrReport.SsGridReport.SetText(3, 15, 9)
        FrReport.SsGridReport.SetText(4, 15, "PLstYr")
        FrReport.SsGridReport.SetText(8, 15, "N")

        FrReport.SsGridReport.SetText(2, 16, "ActualCurrentYear")
        FrReport.SsGridReport.SetText(3, 16, 9)
        FrReport.SsGridReport.SetText(4, 16, "ACurYr")
        FrReport.SsGridReport.SetText(8, 16, "N")

        FrReport.SsGridReport.SetText(2, 17, "ProjectedCurrentYear")
        FrReport.SsGridReport.SetText(3, 17, 9)
        FrReport.SsGridReport.SetText(4, 17, "PCurYr")
        FrReport.SsGridReport.SetText(8, 17, "N")

        FrReport.SsGridReport.SetText(2, 18, "ActualNextYear")
        FrReport.SsGridReport.SetText(3, 18, 9)
        FrReport.SsGridReport.SetText(4, 18, "ANxtYr")
        FrReport.SsGridReport.SetText(8, 18, "N")

        FrReport.SsGridReport.SetText(2, 19, "ProjectedNextYear")
        FrReport.SsGridReport.SetText(3, 19, 9)
        FrReport.SsGridReport.SetText(4, 19, "PNxtYr")
        FrReport.SsGridReport.SetText(8, 19, "N")

        FrReport.Show()
    End Sub

    Private Function Mevalidate() As Boolean
        Mevalidate = True
        'Modified as on 11 Dec'07 as per Sandeep Sir Knowledge.
        'Mk Kannan
        'Begin
        'If UCase(Trim(Me.Txt_AcCode.Text)) = gDebitors Then
        '        Mevalidate = False
        '        MsgBox("SDRS Is System Defined,Can Not Be Modified Or Deleted", MsgBoxStyle.Information)
        '        Txt_AcCode.Focus()
        '        Exit Function
        'End If
        'If UCase(Trim(Me.Txt_AcCode.Text)) = gCreditors Then
        '        Mevalidate = False
        '        MsgBox("SCRS Is System Defined,Can Not Be Modified Or Deleted", MsgBoxStyle.Information)
        '        Txt_AcCode.Focus()
        '        Exit Function
        'End If
        'End

        If Mid(CmdAdd.Text, 1, 2) = "&U" Then
            Dim SDCSql As String
            Dim opdebits, opcredits As Double

            '    SDCSql = "Select * from AccountsGlAccountmaster Where Accode = '" & Txt_AcCode.Text & "'"
            '    vconn.getDataSet(SDCSql, "SubLedgerFlag")
            '    If (gdataset.Tables("SubLedgerFlag").Rows.Count > 0) Then
            '        If IsDBNull(gdataset.Tables("SubLedgerFlag").Rows(0).Item("opdebits")) = False Then
            '            opdebits = gdataset.Tables("SubLedgerFlag").Rows(0).Item("opdebits")
            '        Else
            '            opdebits = 0
            '        End If
            '        If IsDBNull(gdataset.Tables("SubLedgerFlag").Rows(0).Item("opcredits")) = False Then
            '            opcredits = gdataset.Tables("SubLedgerFlag").Rows(0).Item("opcredits")
            '        Else
            '            opcredits = 0
            '        End If

            '        If Rdo_SubLedgerYes.Checked = True Then
            '            SDCSql = "Select * from JournalEntry Where Accountcode = '" & Txt_AcCode.Text & "'"
            '            vconn.getDataSet(SDCSql, "Validation")
            '            If (gdataset.Tables("Validation").Rows.Count > 0) Or (opdebits - opcredits <> 0) Then
            '                MsgBox("This GL Code having Transaction....")
            '                Mevalidate = False
            '                Exit Function
            '            End If
            '        End If
            '    End If
        End If

        If Trim(Txt_AcCode.Text) = "" Then
            Mevalidate = False
            MsgBox("accode cannot be blank", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, Me.Text)
            Txt_AcCode.Focus()
            Exit Function
        End If
        If Trim(Txt_AcDesc.Text) = "" Then
            Mevalidate = False
            MsgBox("Ac Description cannot be blank", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, Me.Text)
            Txt_AcDesc.Focus()
            Exit Function
        End If
        'If Trim(Txt_Alias.Text) = "" Then
        '    Mevalidate = False
        '    MsgBox("Alias cannot be blank", MsgBoxStyle.OKOnly + MsgBoxStyle.Information, Me.Text)
        '    Txt_Alias.Focus()
        '    Exit Function
        'End If


    End Function

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        Txt_AcCode.Text = ""
        Me.Rad_Bal.Checked = True
        Txt_AcCode.Enabled = True
        Txt_AcDesc.Text = ""
        Txt_Alias.Text = ""
        Txt_OpeningBalance.Text = 0.0
        Txt_BalanceAsOn.Text = 0.0
        Txt_ActualLastyear.Text = 0.0
        Me.CmdAdd.Enabled = True
        Txt_ProjectedLastYear.Text = 0.0
        Txt_ActualCurrentYear.Text = 0.0
        Txt_ProjectedCurrentYear.Text = 0.0
        Txt_ActualNextYear.Text = 0.0
        Txt_ProjectedNextYear.Text = 0.0

        Txt_SLCode.Text = ""
        Txt_SLName.Text = ""
        Txt_VATNo.Text = ""
        Txt_CSTNo.Text = ""
        Txt_TINNo.Text = ""
        Txt_GRNNo.Text = ""
        Txt_PANNo.Text = ""
        Txt_OpeningBalance.Text = 0
        Txt_BalanceAsOn.Text = 0
        Rdo_OpeningBalanceDebit.Checked = True
        Rdo_BalanceAsOnDebit.Checked = True
        Txt_ContactPerson.Text = ""
        Txt_Address1.Text = ""
        Txt_Address2.Text = ""
        Txt_Address3.Text = ""
        txt_City.Text = ""
        Txt_State.Text = ""
        Txt_Pin.Text = ""
        Txt_PhoneNo.Text = ""
        Txt_CellNo.Text = ""

        'Cmb_Group.SelectedIndex = 0
        ''Cmb_SubGroup.Enabled = False
        'Cmb_AcType.SelectedIndex = 0
        Txt_AcCode.Focus()
        Me.CmdFreeze.Enabled = False
        Lbl_Freeze.Visible = False
        Me.CmdAdd.Text = "&Add [F7]"
        Me.Txt_BankAddress.Text = ""
        Me.Txt_BankName.Text = ""
        Me.Rad_Income.Enabled = False
        Me.Rad_Exp.Enabled = False
        '        Me.GroupBox9.Visible = False
        Me.ChkNew.Checked = False

    End Sub

    Private Sub Txt_AcCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_AcCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            Call Cmd_AcCodeHelp_Click(Txt_AcCode, e)
            Exit Sub
        End If
    End Sub
    Private Sub Cmb_Group_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_Group.SelectedIndexChanged
        Dim sqlstring As String
        Dim DR1 As DataRow
        'Sub Group
        Cmb_SubGroup.Items.Clear()
        sqlstring = "select  SUBGROUPDESC from accountssubgroupmaster WHERE GROUPDESC ='" & Trim(Cmb_Group.Text) & "' and isnull(freezeflag,'') <> 'Y'"
        vconn.getDataSet(sqlstring, "SUBGROUPDESC")
        If gdataset.Tables("SUBGROUPDESC").Rows.Count > 0 Then
            For Each DR1 In gdataset.Tables("SUBGROUPDESC").Rows
                Cmb_SubGroup.Visible = True
                If DR1("SUBGROUPDESC") <> "" Then
                    Cmb_SubGroup.Items.Add(Trim(DR1("SUBGROUPDESC")))
                    Cmb_SubGroup.SelectedIndex = 0
                    Cmb_SubGroup.Visible = True
                    Me.Lbl_SubGroup.Visible = True
                Else
                    Cmb_SubGroup.Visible = False
                    Me.Lbl_SubGroup.Visible = False
                End If
            Next
        End If

        'Sub Sub Group
        Cmb_SubSubGroup.Items.Clear()
        sqlstring = "select Distinct SUBSUBGROUPDESC from AccountsSubSubGroupMaster WHERE SUBGROUPDESC ='" & Cmb_SubGroup.Text & "' And Isnull(FreezeFlag,'')<> 'Y' "
        vconn.getDataSet(sqlstring, "SUBGROUPDESC")
        If gdataset.Tables("SUBGROUPDESC").Rows.Count > 0 Then
            For Each DR1 In gdataset.Tables("SUBGROUPDESC").Rows
                Cmb_SubSubGroup.Items.Add(Trim(DR1("SUBSUBGROUPDESC")))
            Next
            Cmb_SubSubGroup.SelectedIndex = 0
            Me.Lbl_SubSubGroup.Visible = True
            Cmb_SubSubGroup.Visible = True
        Else
            Me.Lbl_SubSubGroup.Visible = False
            Cmb_SubSubGroup.Visible = False
        End If

        sqlstring = "select  GroupDesc from AccountsGroupMaster Where Category Like 'I%' and GROUPDESC ='" & Trim(Cmb_Group.Text) & "' and isnull(freezeflag,'') <> 'Y'"
        vconn.getDataSet(sqlstring, "SUBGROUPDESC")
        If gdataset.Tables("SUBGROUPDESC").Rows.Count > 0 Then
            Me.Rad_Pl.Focus()
        Else
            Me.Rad_Bal.Focus()
        End If

        sqlstring = "select Category from AccountsGroupMaster Where GROUPDESC ='" & Trim(Cmb_Group.Text) & "'  and isnull(freezeflag,'') <> 'Y'"
        vconn.getDataSet(sqlstring, "SUBGROUPDESC")
        If gdataset.Tables("SUBGROUPDESC").Rows.Count > 0 Then
            If Trim(gdataset.Tables("SUBGROUPDESC").Rows(0).Item("Category")) = "ASSETS" Or Trim(gdataset.Tables("SUBGROUPDESC").Rows(0).Item("Category")) = "BALANCE SHEET" Then
                Me.Rad_Asset.Checked = True
                Me.Rad_Bal.Checked = True
                Me.Rad_Lia.Checked = False
                Me.Rad_Income.Checked = False
                Me.Rad_Exp.Checked = False
                Me.Rad_Lia.Enabled = False
                Me.Rad_Exp.Enabled = False
                Me.Rad_Asset.Enabled = False
                Me.Rad_Income.Enabled = False

            ElseIf Trim(gdataset.Tables("SUBGROUPDESC").Rows(0).Item("Category")) = "LIABILITIES" Then

                Me.Rad_Asset.Checked = False
                Me.Rad_Lia.Checked = True
                Me.Rad_Bal.Checked = True
                Me.Rad_Income.Checked = False
                Me.Rad_Exp.Checked = False

                Me.Rad_Lia.Enabled = False
                Me.Rad_Exp.Enabled = False
                Me.Rad_Asset.Enabled = False
                Me.Rad_Income.Enabled = False
            Else
                Me.Rad_Asset.Checked = False
                Me.Rad_Lia.Checked = False
                Me.Rad_Income.Checked = False
                Me.Rad_Exp.Checked = False
                Me.Rad_Pl.Checked = True
                Me.Rad_Lia.Enabled = False
                Me.Rad_Asset.Enabled = False
                Me.Rad_Exp.Enabled = True
                Me.Rad_Income.Enabled = True
            End If
        End If
    End Sub

    Private Sub Rdo_BudgetYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo_BudgetYes.CheckedChanged
        Lbl_Actual.Visible = True
        Lbl_Projected.Visible = True
        Lbl_Lastyear.Visible = True
        Lbl_NextYear.Visible = True
        Lbl_CurrentYear.Visible = True
        Txt_ActualLastyear.Visible = True
        Txt_ProjectedLastYear.Visible = True
        Txt_ActualCurrentYear.Visible = True
        Txt_ProjectedCurrentYear.Visible = True
        Txt_ActualNextYear.Visible = True
        Txt_ProjectedNextYear.Visible = True
    End Sub

    Private Sub Rdo_BudgetNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo_BudgetNo.CheckedChanged
        Lbl_Actual.Visible = False
        Lbl_Projected.Visible = False
        Lbl_Lastyear.Visible = False
        Lbl_NextYear.Visible = False
        Lbl_CurrentYear.Visible = False
        Txt_ActualLastyear.Visible = False
        Txt_ProjectedLastYear.Visible = False
        Txt_ActualCurrentYear.Visible = False
        Txt_ProjectedCurrentYear.Visible = False
        Txt_ActualNextYear.Visible = False
        Txt_ProjectedNextYear.Visible = False
    End Sub
    Private Sub GLACCOUNTMASTER_Others_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F6 And CmdClear.Visible Then
            Call Me.CmdClear_Click(sender, e)
        End If
        If e.KeyCode = Keys.F7 And CmdAdd.Visible Then
            Call Me.CmdAdd_Click(sender, e)
        End If
        If (e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape) And cmdexit.Visible Then
            Call Me.cmdexit_Click(sender, e)
        End If
        If e.KeyCode = Keys.F9 And CmdView.Visible Then
            Call Me.CmdView_Click(sender, e)
        End If
        If e.KeyCode = Keys.F8 And CmdFreeze.Visible Then
            Call Me.CmdFreeze_Click(sender, e)
        End If
        If e.KeyCode = Keys.F2 Then
            Me.Txt_AcCode.Focus()
        End If
    End Sub

    Private Sub Cmb_AcType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_AcType.SelectedIndexChanged
        If UCase(Trim(Cmb_AcType.Text)) = "BANK" Then
            'Refer
            'Added as on 18 Jul 07
            'Begin        
            Me.pnlBank.Visible = True
            'End
            Me.Txt_BankAddress.Enabled = True
            Me.Txt_BankName.Enabled = True
            Me.Txt_BankName.Focus()
        Else
            'Refer
            'Added as on 18 Jul 07
            'Begin        
            Me.pnlBank.Visible = False
            'End
            Me.Txt_BankAddress.Enabled = False
            Me.Txt_BankName.Enabled = False
            Me.Txt_OpeningBalance.Focus()
        End If
    End Sub


    Private Sub Txt_BankName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_BankName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.Txt_BankAddress.Focus()
        End If
    End Sub

    Private Sub Txt_BankAddress_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txt_BankAddress.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.Txt_OpeningBalance.Focus()
        End If
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub
    Private Sub Cmb_SubGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_SubGroup.SelectedIndexChanged
        Dim sqlstring As String
        Dim DR1 As DataRow

        'Sub Sub Group
        Cmb_SubSubGroup.Items.Clear()
        sqlstring = "select Distinct SUBSUBGROUPDESC from AccountsSubSubGroupMaster WHERE SUBGROUPDESC ='" & Cmb_SubGroup.Text & "' And Isnull(FreezeFlag,'')<> 'Y' "
        vconn.getDataSet(sqlstring, "SUBGROUPDESC")
        If gdataset.Tables("SUBGROUPDESC").Rows.Count > 0 Then
            For Each DR1 In gdataset.Tables("SUBGROUPDESC").Rows
                Cmb_SubSubGroup.Items.Add(Trim(DR1("SUBSUBGROUPDESC")))
            Next
            Cmb_SubSubGroup.SelectedIndex = 0
            Me.Lbl_SubSubGroup.Visible = True
            Cmb_SubSubGroup.Visible = True
        Else
            Me.Lbl_SubSubGroup.Visible = False
            Cmb_SubSubGroup.Visible = False
        End If
    End Sub
    Private Sub Rdo_SubLedgerYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_SubLedgerYes.Click
        Lbl_sltype.Visible = True
        Cmb_SLType.Visible = True
        'GroupBox9.Visible = True
        Call subledgervalidation()
        Cmb_SLType.Focus()
    End Sub

    Private Sub Cmb_SLType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_SLType1.SelectedIndexChanged
        If Cmb_SLType.Text = "MEMBER" Then
            Txt_SLCode.Text = gDebitors
            Txt_SLName.Text = "SUNDRY DEBTORS"
            MsgBox("Member Control Cannot Be Added,Please Use Membermaster")
            Call Me.CmdClear_Click(sender, e)
            Exit Sub
        ElseIf Cmb_SLType.Text = "SUPPLIER" Then
            Txt_SLCode.Text = gCreditors
            Txt_SLName.Text = "SUNDRY CREDITORS"
        Else
            Txt_SLCode.Text = gCreditors
            Txt_SLName.Text = "SUNDRY CREDITORS"
        End If
    End Sub
    Private Sub subledgervalidation()
        Dim sql1
        sql1 = "select * from accountssubledgermaster where slcode = '" & Trim(Txt_AcCode.Text) & "'"
        vconn.getDataSet(sql1, "accountssubledgermaster")
        If gdataset.Tables("accountssubledgermaster").Rows.Count > 0 Then
            MsgBox("Subleger for This Accountcode Already Created")
            Exit Sub
            ' Call Me.CmdClear_Click(sender, e)
            '            GroupBox9.Visible = False
            '           Txt_AcCode.Text = ""
            '          Txt_AcDesc.Text = ""
            '         Txt_Alias.Text = ""
        End If
    End Sub
    Private Sub ChkNew_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkNew.CheckedChanged
        If ChkNew.Checked = True Then
            '            GroupBox9.Visible = False
            '           Cmb_Group.Focus()
        End If
    End Sub

    Private Sub Rdo_SubLedgerNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Rdo_SubLedgerNo.Click
        '        GroupBox9.Visible = False
        '       Cmb_Group.Focus()
    End Sub
    Private Sub Rdo_SubLedgerYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo_SubLedgerYes.CheckedChanged
        If Rdo_SubLedgerYes.Checked = True Then
            Lbl_sltype.Visible = True
            Cmb_SLType.Visible = True
        Else
            Lbl_sltype.Visible = True
            Cmb_SLType.Visible = True
        End If
    End Sub
    Private Sub Rdo_SubLedgerNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdo_SubLedgerNo.CheckedChanged
        If Rdo_SubLedgerNo.Checked = True Then
            Lbl_sltype.Visible = False
            Cmb_SLType.Visible = False
        Else
            Lbl_sltype.Visible = True
            Cmb_SLType.Visible = True
        End If
    End Sub
    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Try
            Dim sqlstring As String
            Dim _export As New EXPORT
            _export.TABLENAME = "AccountsglaccountMaster"
            sqlstring = "SELECT * FROM AccountsglaccountMaster order by Accode"
            Call _export.export_excel(sqlstring)
            _export.Show()
            Exit Sub
        Catch ex As Exception
            MsgBox("Sorry!, Export to Excel is Terminated Abnormally, Bcoz " & ex.Message.ToString(), MsgBoxStyle.OKOnly, "Error!")
        End Try
    End Sub
    Private Sub print_windows()
        Dim str As String
        Dim Viewer As New ReportViwer

        Dim r As New Rpt_AccountsGlAccountMaster

        str = "SELECT * FROM ACCOUNTSGLACCOUNTMASTER"

        Viewer.ssql = str
        vconn.getDataSet(str, "glacc")
        If gdataset.Tables("glacc").Rows.Count > 0 Then

            Viewer.Report = r
            Viewer.TableName = "ACCOUNTSGLACCOUNTMASTER"

            Dim TXTOBJ11 As TextObject
            TXTOBJ11 = r.ReportDefinition.ReportObjects("TEXT11")
            TXTOBJ11.Text = MyCompanyName

            Dim TXTOBJ18 As TextObject
            TXTOBJ18 = r.ReportDefinition.ReportObjects("TEXT18")
            TXTOBJ18.Text = "User Name : " & gUsername

            Dim TXTOBJ14 As TextObject
            TXTOBJ14 = r.ReportDefinition.ReportObjects("TEXT14")
            TXTOBJ14.Text = "Accounting Period : " & Format(gFinancialyearStart, "dd-MM-yyyy") & " - " & Format(gFinancialyearEnding, "dd-MM-yyyy")
            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End If
    End Sub


    Private Sub cmdcrystal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcrystal.Click
        print_windows()
    End Sub

    Private Sub Txt_AcCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_AcCode.TextChanged

    End Sub

    Private Sub Cmb_SLType_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmb_SLType.SelectedIndexChanged

    End Sub

    Private Sub Txt_OpeningBalance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_OpeningBalance.TextChanged

    End Sub
End Class
