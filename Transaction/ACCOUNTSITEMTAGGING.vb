Public Class ACCOUNTSITEMTAGGING

    Inherits System.Windows.Forms.Form
    Dim Vconn As New GlobalClass
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Cmdauth As System.Windows.Forms.Button
    Friend WithEvents Cmdbwse As System.Windows.Forms.Button
    Friend WithEvents Cmdview As System.Windows.Forms.Button
    Friend WithEvents Cmd_Freeze As System.Windows.Forms.Button
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents Cmd_Update As System.Windows.Forms.Button
    Friend WithEvents SSMatching As AxFPSpreadADO.AxfpSpread
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ssgrid1 As AxFPSpreadADO.AxfpSpread
    Friend WithEvents cmd_update232 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ACCOUNTSITEMTAGGING))
        Me.ssgrid1 = New AxFPSpreadADO.AxfpSpread()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmd_update232 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdreport = New System.Windows.Forms.Button()
        Me.cmdexit = New System.Windows.Forms.Button()
        Me.Cmdauth = New System.Windows.Forms.Button()
        Me.Cmdbwse = New System.Windows.Forms.Button()
        Me.Cmdview = New System.Windows.Forms.Button()
        Me.Cmd_Freeze = New System.Windows.Forms.Button()
        Me.CmdClear = New System.Windows.Forms.Button()
        Me.Cmd_Update = New System.Windows.Forms.Button()
        CType(Me.ssgrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssgrid1
        '
        Me.ssgrid1.DataSource = Nothing
        Me.ssgrid1.Location = New System.Drawing.Point(179, 115)
        Me.ssgrid1.Name = "ssgrid1"
        Me.ssgrid1.OcxState = CType(resources.GetObject("ssgrid1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid1.Size = New System.Drawing.Size(665, 567)
        Me.ssgrid1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(24, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 40)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Clear"
        '
        'Button2
        '
        Me.Button2.BackgroundImage = CType(resources.GetObject("Button2.BackgroundImage"), System.Drawing.Image)
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(136, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 40)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "View"
        '
        'cmd_update232
        '
        Me.cmd_update232.BackgroundImage = CType(resources.GetObject("cmd_update232.BackgroundImage"), System.Drawing.Image)
        Me.cmd_update232.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_update232.Location = New System.Drawing.Point(240, 8)
        Me.cmd_update232.Name = "cmd_update232"
        Me.cmd_update232.Size = New System.Drawing.Size(88, 40)
        Me.cmd_update232.TabIndex = 1
        Me.cmd_update232.Text = "Update"
        '
        'Button4
        '
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(368, 8)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(88, 40)
        Me.Button4.TabIndex = 1
        Me.Button4.Text = "Exit"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.cmd_update232)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Location = New System.Drawing.Point(326, 625)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 56)
        Me.Panel1.TabIndex = 2
        Me.Panel1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(174, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(311, 29)
        Me.Label3.TabIndex = 815
        Me.Label3.Text = "Banquet Account Tagging"
        '
        'cmdreport
        '
        Me.cmdreport.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdreport.Location = New System.Drawing.Point(886, 669)
        Me.cmdreport.Name = "cmdreport"
        Me.cmdreport.Size = New System.Drawing.Size(144, 65)
        Me.cmdreport.TabIndex = 823
        Me.cmdreport.Text = "REPORT"
        Me.cmdreport.UseVisualStyleBackColor = True
        Me.cmdreport.Visible = False
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.Gainsboro
        Me.cmdexit.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdexit.Location = New System.Drawing.Point(862, 435)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(139, 65)
        Me.cmdexit.TabIndex = 822
        Me.cmdexit.Text = "Exit [F11]"
        Me.cmdexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdexit.UseVisualStyleBackColor = False
        '
        'Cmdauth
        '
        Me.Cmdauth.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdauth.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdauth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdauth.Location = New System.Drawing.Point(286, 679)
        Me.Cmdauth.Name = "Cmdauth"
        Me.Cmdauth.Size = New System.Drawing.Size(144, 65)
        Me.Cmdauth.TabIndex = 821
        Me.Cmdauth.Text = "Authorize"
        Me.Cmdauth.UseVisualStyleBackColor = True
        Me.Cmdauth.Visible = False
        '
        'Cmdbwse
        '
        Me.Cmdbwse.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdbwse.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdbwse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdbwse.Location = New System.Drawing.Point(436, 679)
        Me.Cmdbwse.Name = "Cmdbwse"
        Me.Cmdbwse.Size = New System.Drawing.Size(144, 65)
        Me.Cmdbwse.TabIndex = 820
        Me.Cmdbwse.Text = "Browse"
        Me.Cmdbwse.UseVisualStyleBackColor = True
        Me.Cmdbwse.Visible = False
        '
        'Cmdview
        '
        Me.Cmdview.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmdview.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmdview.Image = CType(resources.GetObject("Cmdview.Image"), System.Drawing.Image)
        Me.Cmdview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmdview.Location = New System.Drawing.Point(736, 679)
        Me.Cmdview.Name = "Cmdview"
        Me.Cmdview.Size = New System.Drawing.Size(144, 65)
        Me.Cmdview.TabIndex = 819
        Me.Cmdview.Text = "View [F9]"
        Me.Cmdview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmdview.UseVisualStyleBackColor = True
        Me.Cmdview.Visible = False
        '
        'Cmd_Freeze
        '
        Me.Cmd_Freeze.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Freeze.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Freeze.Image = CType(resources.GetObject("Cmd_Freeze.Image"), System.Drawing.Image)
        Me.Cmd_Freeze.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Freeze.Location = New System.Drawing.Point(586, 687)
        Me.Cmd_Freeze.Name = "Cmd_Freeze"
        Me.Cmd_Freeze.Size = New System.Drawing.Size(144, 65)
        Me.Cmd_Freeze.TabIndex = 818
        Me.Cmd_Freeze.Text = "Freeze [F8]"
        Me.Cmd_Freeze.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Freeze.UseVisualStyleBackColor = True
        Me.Cmd_Freeze.Visible = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.Gainsboro
        Me.CmdClear.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdClear.Location = New System.Drawing.Point(862, 221)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(139, 65)
        Me.CmdClear.TabIndex = 817
        Me.CmdClear.Text = "Clear [F6]"
        Me.CmdClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdClear.UseVisualStyleBackColor = False
        '
        'Cmd_Update
        '
        Me.Cmd_Update.BackColor = System.Drawing.Color.Gainsboro
        Me.Cmd_Update.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Update.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd_Update.Image = CType(resources.GetObject("Cmd_Update.Image"), System.Drawing.Image)
        Me.Cmd_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Cmd_Update.Location = New System.Drawing.Point(862, 330)
        Me.Cmd_Update.Name = "Cmd_Update"
        Me.Cmd_Update.Size = New System.Drawing.Size(140, 65)
        Me.Cmd_Update.TabIndex = 816
        Me.Cmd_Update.Text = "Update[F7]"
        Me.Cmd_Update.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Cmd_Update.UseVisualStyleBackColor = False
        '
        'ACCOUNTSITEMTAGGING
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.Controls.Add(Me.cmdreport)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.Cmdauth)
        Me.Controls.Add(Me.Cmdbwse)
        Me.Controls.Add(Me.Cmdview)
        Me.Controls.Add(Me.Cmd_Freeze)
        Me.Controls.Add(Me.CmdClear)
        Me.Controls.Add(Me.Cmd_Update)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ssgrid1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "ACCOUNTSITEMTAGGING"
        Me.Text = "ACCOUNTSITEMTAGGING"
        CType(Me.ssgrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub ACCOUNTSITEMTAGGING_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call cmdexit_Click(sender, e)
            Exit Sub
        End If

        If e.KeyCode = Keys.F6 Then
            Call CmdClear_Click(sender, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then 'cmd_Freeze
            Call Cmd_Update_Click(sender, e)
            Exit Sub
        End If
    End Sub

    Private Sub ACCOUNTSITEMTAGGING_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        Me.resizeFormResolution()
        rs.ResizeAllControls(Me)
        Dim i, j As Integer

        'SQLSTRING = "select 'POS'AS SOURCE,a.itemcode,a.itemdesc ,isnull(a.salesacctin,'') as accode,isnull(b.acdesc,'') as acdesc  from itemmaster a left outer join accountsglaccountmaster b on a.salesacctin=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y'  "
        'SQLSTRING = SQLSTRING & "  UNION ALL   "
        SQLSTRING = "SELECT 'TARIFF' AS SOURCE,A.TARIFFCODE AS ITEMCODE,A.TARIFFDESC AS ITEMDESC,ISNULL(A.salesacctin,'') AS ACCODE,isnull(b.acdesc,'') as acdesc FROM party_tariffhdr A left outer join accountsglaccountmaster b on a.salesacctin=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y' "
        SQLSTRING = SQLSTRING & "  UNION ALL   "
        SQLSTRING = SQLSTRING & "SELECT 'ARRANGEMENT'AS SOURCE,A.ARRCODE AS ITEMCODE,A.ARRDESCRIPTION,ISNULL(A.GLACCODE,'') AS ACCODE,isnull(b.acdesc,'') as acdesc  FROM PARTY_ARRANGEMASTER_HDR A left outer join accountsglaccountmaster b on a.GLACCODE=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y' "
        SQLSTRING = SQLSTRING & "  UNION ALL   "
        SQLSTRING = SQLSTRING & "SELECT 'HALL' AS SOURCE,A.HALLTYPECODE AS ITEMCODE,A.HALLTYPEDESC AS ITEMDESC,A.GLACCODE AS ACCODE,isnull(b.acdesc,'') as acdesc  FROM PARTY_HALLMASTER_HDR A left outer join accountsglaccountmaster b on a.GLACCODE=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y' "
        SQLSTRING = SQLSTRING & "  UNION ALL   "
        SQLSTRING = SQLSTRING & "select 'PARTYMENU'AS SOURCE,a.itemcode,a.itemdesc ,isnull(a.GLACCODE,'') as accode,isnull(b.acdesc,'') as acdesc  from PARTY_ITEMMASTER a left outer join accountsglaccountmaster b on a.GLACCODE=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y' order by SOURCE "

        Vconn.getDataSet(SQLSTRING, "acctag")
        If gdataset.Tables("acctag").Rows.Count > 0 Then
            For i = 0 To gdataset.Tables("acctag").Rows.Count - 1
                j = i + 1
                With ssgrid1
                    .Row = j
                    .Col = 1
                    .Text = gdataset.Tables("acctag").Rows(i).Item("SOURCE")
                    .Col = 2
                    .Text = gdataset.Tables("acctag").Rows(i).Item("itemcode")
                    .Col = 3
                    .Text = gdataset.Tables("acctag").Rows(i).Item("itemdesc")
                    .Col = 4
                    .Text = gdataset.Tables("acctag").Rows(i).Item("accode")
                    .Col = 5
                    .Text = gdataset.Tables("acctag").Rows(i).Item("acdesc")
                End With
                ssgrid1.MaxRows = ssgrid1.MaxRows + 1
            Next
        End If
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
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
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        Vconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.cmd_update232.Enabled = False
        'Me.Cmd_Freeze.Enabled = False
        '.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.cmd_update232.Enabled = True
                    'Me.Cmd_Freeze.Enabled = True
                    'Me.Cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.cmd_update232.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.cmd_update232.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.cmd_update232.Enabled = True
                    End If
                End If
                If Right(x) = "D" Then
                    'Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    'Me.Cmd_View.Enabled = True
                End If
            Next
        End If
    End Sub
    Private Sub SSMatching_DblClick(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_DblClickEvent) Handles SSMatching.DblClick



    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub ssgrid1_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles ssgrid1.Advance

    End Sub

    'Private Sub ssgrid1_DblClick(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_DblClickEvent) Handles ssgrid1.DblClick
    '    Dim ssql As String
    '    Dim itemcode, itemdesc As String

    '    With ssgrid1
    '        .Col = 1
    '        .Row = .ActiveRow
    '        itemcode = .Text
    '        .Col = 2
    '        .Row = .ActiveRow
    '        itemdesc = .Text
    '    End With
    '    SQLSTRING = "select a.itemcode,a.itemdesc ,isnull(a.salesacctin,'') as accode,isnull(b.acdesc,'') as acdesc  from itemmaster a left outer join accountsglaccountmaster b on a.salesacctin=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y' order by b.acdesc,a.itemcode "
    '    Vconn.getDataSet(SQLSTRING, "acctag")

    '    If gdataset.Tables("acctag").Rows.Count = 0 Then
    '        Exit Sub
    '    End If
    '    If gdataset.Tables("acctag").Rows.Count > 1 Then
    '        Exit Sub
    '    End If
    'End Sub
    Private Sub ssgrid1_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles ssgrid1.KeyDownEvent
        Dim accode As String
        Dim ssql As String
        Dim ITEMCODE As String
        With ssgrid1
            If e.keyCode = Keys.Enter Then

                'If .ActiveCol = 1 Then
                '    .Col = 1
                '    .Row = .ActiveCol
                '    If Trim(.Text) = "" Then
                '        .Focus()
                '    End If
                'ElseIf .ActiveCol = 2 Then
                '    .Col = 2
                '    .Row = .ActiveCol
                '    If Trim(.Text) = "" Then
                '        .Focus()
                '    End If
                'ElseIf .ActiveCol = 3 Then
                '    .Col = 3
                '    .Row = .ActiveCol
                '    If Trim(.Text) = "" Then
                '        .Focus()
                '    End If

                '  Else
                If .ActiveCol = 4 Then
                    .Col = 4
                    .Row = .ActiveRow
                    If .Text = "" Then
                        Call FillMenu()
                    Else
                        .Col = 1
                        .Row = .ActiveRow
                        ITEMCODE = Trim(.Text)
                        If Trim(ITEMCODE) = "" Then
                            MessageBox.Show("ITEMCODE CODE NOT FOUND ", MyCompanyName, MessageBoxButtons.OK)
                            .ClearRange(1, .ActiveRow, 6, .ActiveRow, True)
                        End If

                        .Col = 4
                        .Row = .ActiveRow
                        accode = Trim(.Text)
                        ssql = " select ISNULL(accode,'')AS ACCODE,ISNULL(acdesc,'')ACDESC from accountsglaccountmaster WHERE category in ('I') and ISNULL(FREEZEFLAG,'') <>'Y' and accode='" & Trim(accode) & " '"
                        Vconn.getDataSet(ssql, "acctag")
                        If gdataset.Tables("acctag").Rows.Count > 0 Then
                            .Col = 4
                            .Row = .ActiveRow
                            .Text = Trim(gdataset.Tables("acctag").Rows(0).Item("ACCODE"))
                            .Col = 5
                            .Row = .ActiveRow
                            .Text = Trim(gdataset.Tables("acctag").Rows(0).Item("ACDESC"))
                            ssgrid1.SetActiveCell(4, ssgrid1.ActiveRow + 1)
                            .Focus()


                        Else
                            MessageBox.Show("ACCOUNT CODE NOT FOUND ", MyCompanyName, MessageBoxButtons.OK)
                            .Text = ""
                            ssgrid1.SetActiveCell(4, ssgrid1.ActiveRow)

                        End If

                    End If
                End If
                If .ActiveCol = 5 Then
                    .Row = .ActiveRow
                    If .Text = "" Then
                        Call FillMenu()
                    Else
                        ssgrid1.SetActiveCell(4, ssgrid1.ActiveRow + 1)
                    End If
                End If
            End If
        End With
        'SSGRID_ARRANGE.ClearRange(1, I, 15, I, True)

        '' '' ''If e.keyCode = Keys.F3 Then
        '' '' ''    ssgrid1.DeleteRows(ssgrid1.ActiveRow, 1)
        '' '' ''    ssgrid1.SetActiveCell(2, ssgrid1.ActiveRow)
        '' '' ''    ssgrid1.Focus()
        '' '' ''End If

    End Sub
    Private Sub FillMenu()
        Dim vform As New LIST_OPERATION1
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = "select accode,acdesc from accountsglaccountmaster "

        'gSQLString = "SELECT DISTINCT I.ITEMCODE,I.ITEMDESC,I.BASERATESTD,I.ITEMTYPECODE,TL.TAXCODE,TL.TAXPERCENTAGE, ISNULL(TL.ACCOUNTCODE,'') "
        'gSQLString = gSQLString & " AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN FROM VIEW_ITEMMASTER AS I INNER "
        'gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE "
        If Trim(Search) = " " Then
            M_WhereCondition = "WHERE   category in ('I') and ISNULL(FREEZEFLAG,'') <>'Y'"
        Else
            'M_WhereCondition = " WHERE (accode LIKE '%" & Search & "%' OR acdesc LIKE '%" & Search & "%')  and  ISNULL(FREEZEFLAG,'') <>'Y' "
            M_WhereCondition = " WHERE category in ('I') and  ISNULL(FREEZEFLAG,'') <>'Y' "

        End If
        vform.Field = "accode,acdesc"
        ' vform.vFormatstring = "ACCODE     |ACDESC                        "
        vform.vCaption = "ACCOUNT CODE HELP"
        ' vform.KeyPos = 0
        'vform.KeyPos1 = 1

        vform.ShowDialog(Me)
        If Trim(vform.keyfield & "") <> "" Then
            With ssgrid1
                .Col = 4
                .Row = .ActiveRow
                .Text = vform.keyfield
                .Col = 5
                .Row = .ActiveRow
                .Text = vform.keyfield1

            End With
        Else
            ssgrid1.SetActiveCell(0, ssgrid1.ActiveRow)
            Exit Sub
        End If
    End Sub


  

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ssgrid1.ClearRange(1, 1, ssgrid1.DataColCnt, ssgrid1.DataRowCnt, False)
        Call ACCOUNTSITEMTAGGING_Load(sender, e)
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Update.Click
        Dim i As Integer
        Dim code As String
        Dim source1, itemcode, desc As String


        With ssgrid1
            For i = 0 To .DataRowCnt
                .Row = i
                .Col = 4
                code = .Text

                If Trim(code) = "" Then
                    MessageBox.Show("SALES ACCOUNT CODE CAN'T BE BLANK", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If
                .Row = i
                .Col = 1
                source1 = .Text
                If Trim(source1) <> "" Then
                    'MessageBox.Show("SOURCE CAN'T BE BLANK", MyCompanyName, MessageBoxButtons.OK)
                    'Exit Sub
                    .Row = i
                    .Col = 2
                    itemcode = .Text
                    If Trim(itemcode) = "" Then
                        MessageBox.Show("ITEM CODE CAN'T BE BLANK", MyCompanyName, MessageBoxButtons.OK)
                        Exit Sub
                    End If
                    .Row = i
                    .Col = 3
                    desc = .Text
                    If Trim(desc) = "" Then
                        MessageBox.Show("ITEM DESCRIPTION CAN'T BE BLANK", MyCompanyName, MessageBoxButtons.OK)
                        Exit Sub
                    End If
                End If
               

            Next i
        End With

        ' Dim i As Integer
        Dim itemcd, acccd, SOURCE, ssql As String
        If ssgrid1.DataRowCnt <= 1 Then
            MsgBox("NO RECORD TO SAVE")
            Exit Sub
        End If
        With ssgrid1
            For i = 0 To ssgrid1.DataRowCnt - 1
                '  ACCD=""
                .Row = i + 1
                .Col = 1
                SOURCE = .Text
                .Col = 2
                itemcd = .Text
                .Col = 4
                acccd = .Text
                ssql = " select ISNULL(accode,'')AS ACCODE,ISNULL(acdesc,'')ACDESC from accountsglaccountmaster WHERE category in ('I') and ISNULL(FREEZEFLAG,'') <>'Y' and accode='" & Trim(acccd) & " '"
                Vconn.getDataSet(ssql, "acctag")
                If gdataset.Tables("acctag").Rows.Count = 0 Then
                    MessageBox.Show("ACCOUNT CODE NOT MATCHING ", MyCompanyName, MessageBoxButtons.OK)
                    Exit Sub
                End If
                If SOURCE = "POS" Then
                    ssql = "update itemmaster set salesacctin='" & acccd & "' where itemcode='" & itemcd & "'"
                    Vconn.dataOperation(6, ssql, "item")
                End If
                If SOURCE = "TARIFF" Then
                    ssql = "update party_tariffhdr set salesacctin='" & acccd & "' where TARIFFCODE='" & itemcd & "'"
                    Vconn.dataOperation(6, ssql, "item")
                End If
                If SOURCE = "ARRANGEMENT" Then
                    ssql = "update PARTY_ARRANGEMASTER_HDR set GLACCODE='" & acccd & "' where ARRCODE='" & itemcd & "'"
                    Vconn.dataOperation(6, ssql, "item")
                End If
                If SOURCE = "HALL" Then
                    ssql = "update PARTY_HALLMASTER_HDR set GLACCODE='" & acccd & "' where HALLTYPECODE='" & itemcd & "'"
                    Vconn.dataOperation(6, ssql, "item")
                End If
                If SOURCE = "PARTYMENU" Then
                    ssql = "update PARTY_ITEMMASTER set GLACCODE='" & acccd & "' where ITEMCODE='" & itemcd & "'"
                    Vconn.dataOperation(6, ssql, "item")
                End If

                SQLSTRING = "select 'PARTYMENU'AS SOURCE,a.itemcode,a.itemdesc ,isnull(a.GLACCODE,'') as accode,isnull(b.acdesc,'') as acdesc  from PARTY_ITEMMASTER a left outer join accountsglaccountmaster b on a.GLACCODE=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y'  "

            Next
        End With
        MessageBox.Show("Record Saved Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        ssgrid1.ClearRange(1, 1, ssgrid1.DataColCnt, ssgrid1.DataRowCnt, False)
        Call ACCOUNTSITEMTAGGING_Load(sender, e)
    End Sub

    Private Sub ssgrid1_LeaveCell(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles ssgrid1.LeaveCell
        Dim ITEMCODE, DESC, SOURCE As String
        'Dim ssql As String
        '' '' ''With ssgrid1
        '' '' ''    If .ActiveCol = 4 Then
        '' '' ''        .Col = 1
        '' '' ''        .Row = .ActiveRow
        '' '' ''        ITEMCODE = Trim(.Text)
        '' '' ''        If Trim(ITEMCODE) = "" Then
        '' '' ''            .ClearRange(1, .ActiveRow, 6, .ActiveRow, True)
        '' '' ''            MessageBox.Show("ITEMCODE CODE NOT FOUND ", MyCompanyName, MessageBoxButtons.OK)
        '' '' ''            Exit Sub
        '' '' ''        End If
        '' '' ''    End If



        '' '' ''End With

        '    If .ActiveCol = 4 Then
        '        .Row = .ActiveRow
        '        If .Text = "" Then
        '            Call FillMenu()
        '        Else
        '            .Col = 4
        '            .Row = .ActiveRow
        '            accode = Trim(.Text)
        '            ssql = " select ISNULL(accode,'')AS ACCODE,ISNULL(acdesc,'')ACDESC from accountsglaccountmaster WHERE category in ('I') and ISNULL(FREEZEFLAG,'') <>'Y' and accode='" & Trim(accode) &
        '            Vconn.getDataSet(ssql, "acctag")
        '            If gdataset.Tables("acctag").Rows.Count > 0 Then
        '                .Col = 4
        '                .Row = .ActiveRow
        '                .Text = gdataset.Tables("acctag").Rows(0).Item("ACCODE")
        '                .Col = 5
        '                .Row = .ActiveRow
        '                .Text = gdataset.Tables("acctag").Rows(0).Item("ACDESC")
        '                ssgrid1.SetActiveCell(4, ssgrid1.ActiveRow + 1)
        '                .Focus()


        '            Else
        '                MessageBox.Show("ACCOUNT CODE NOT FOUND ", MyCompanyName, MessageBoxButtons.OK)
        '                .Text = ""
        '                ssgrid1.SetActiveCell(4, ssgrid1.ActiveRow)

        '            End If

        '        End If
        '    End If
        '    If .ActiveCol = 5 Then
        '        .Row = .ActiveRow
        '        If .Text = "" Then
        '            Call FillMenu()
        '        End If
        '    End If
        'End With
    End Sub

    Private Sub ACCOUNTSITEMTAGGING_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class
