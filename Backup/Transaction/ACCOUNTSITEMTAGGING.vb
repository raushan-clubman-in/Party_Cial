Public Class ACCOUNTSITEMTAGGING

    Inherits System.Windows.Forms.Form
    Dim Vconn As New GlobalClass
    Friend WithEvents SSMatching As AxFPSpreadADO.AxfpSpread
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
    Friend WithEvents cmd_update As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ACCOUNTSITEMTAGGING))
        Me.ssgrid1 = New AxFPSpreadADO.AxfpSpread
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.cmd_update = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.ssgrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssgrid1
        '
        Me.ssgrid1.DataSource = Nothing
        Me.ssgrid1.Location = New System.Drawing.Point(72, 96)
        Me.ssgrid1.Name = "ssgrid1"
        Me.ssgrid1.OcxState = CType(resources.GetObject("ssgrid1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.ssgrid1.Size = New System.Drawing.Size(816, 432)
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
        'cmd_update
        '
        Me.cmd_update.BackgroundImage = CType(resources.GetObject("cmd_update.BackgroundImage"), System.Drawing.Image)
        Me.cmd_update.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_update.Location = New System.Drawing.Point(240, 8)
        Me.cmd_update.Name = "cmd_update"
        Me.cmd_update.Size = New System.Drawing.Size(88, 40)
        Me.cmd_update.TabIndex = 1
        Me.cmd_update.Text = "Update"
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
        Me.Panel1.Controls.Add(Me.cmd_update)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Location = New System.Drawing.Point(152, 592)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 56)
        Me.Panel1.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(320, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(396, 34)
        Me.Label3.TabIndex = 815
        Me.Label3.Text = "PARTY  ACCOUNT TAGGING"
        '
        'ACCOUNTSITEMTAGGING
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(928, 670)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ssgrid1)
        Me.Name = "ACCOUNTSITEMTAGGING"
        Me.Text = "ACCOUNTSITEMTAGGING"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ssgrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ACCOUNTSITEMTAGGING_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i, j As Integer
        'SQLSTRING = "select 'POS'AS SOURCE,a.itemcode,a.itemdesc ,isnull(a.salesacctin,'') as accode,isnull(b.acdesc,'') as acdesc  from itemmaster a left outer join accountsglaccountmaster b on a.salesacctin=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y'  "
        'SQLSTRING = SQLSTRING & "  UNION ALL   "
        SQLSTRING = SQLSTRING & "SELECT 'TARIFF' AS SOURCE,A.TARIFFCODE AS ITEMCODE,A.TARIFFDESC AS ITEMDESC,ISNULL(A.salesacctin,'') AS ACCODE,isnull(b.acdesc,'') as acdesc FROM party_tariffhdr A left outer join accountsglaccountmaster b on a.salesacctin=b.accode where isnull(a.freeze,'')<>'Y' and isnull(b.freezeflag,'')<>'Y' "
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
        Me.cmd_update.Enabled = False
        'Me.Cmd_Freeze.Enabled = False
        '.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.cmd_update.Enabled = True
                    'Me.Cmd_Freeze.Enabled = True
                    'Me.Cmd_View.Enabled = True
                    Exit Sub
                End If
                If UCase(Mid(Me.cmd_update.Text, 1, 1)) = "A" Then
                    If Right(x) = "S" Then
                        Me.cmd_update.Enabled = True
                    End If
                Else
                    If Right(x) = "M" Then
                        Me.cmd_update.Enabled = True
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
        With ssgrid1
            If .Col = 4 Then
                .Row = .ActiveRow
                If .Text = "" Then
                    Call FillMenu()
                End If
            End If
            If .Col = 5 Then
                .Row = .ActiveRow
                If .Text = "" Then
                    Call FillMenu()
                End If
            End If
        End With
    End Sub
    Private Sub FillMenu()
        Dim vform As New ListOperattion1
        Dim ssql As String
        '''******************************************************** $ FILL THE ITEMCODE,ITEMDESC INTO SSGRID ********** 
        gSQLString = "select accode,acdesc from accountsglaccountmaster "

        'gSQLString = "SELECT DISTINCT I.ITEMCODE,I.ITEMDESC,I.BASERATESTD,I.ITEMTYPECODE,TL.TAXCODE,TL.TAXPERCENTAGE, ISNULL(TL.ACCOUNTCODE,'') "
        'gSQLString = gSQLString & " AS ACCOUNTCODE,ISNULL(I.GROUPCODE,'') AS GROUPCODE,ISNULL(I.OPENFACILITY,'') AS OPENFACILITY,ISNULL(I.SALESACCTIN,'') AS SALESACCTIN FROM VIEW_ITEMMASTER AS I INNER "
        'gSQLString = gSQLString & " JOIN TAXITEMLINK AS TL ON TL.ITEMTYPECODE = I.ITEMTYPECODE "
        If Trim(Search) = " " Then
            M_WhereCondition = "WHERE   category in ('I') and ISNULL(FREEZEFLAG,'') <>'Y'"
        Else
            M_WhereCondition = " WHERE (accode LIKE '%" & Search & "%' OR acdesc LIKE '%" & Search & "%')  and  ISNULL(FREEZEFLAG,'') <>'Y' "
        End If
        vform.Field = "ACDESC,ACCODE"
        vform.vFormatstring = "ACCODE     |ACDESC                        "
        vform.vCaption = "ITEM CODE HELP"
        vform.KeyPos = 0
        vform.KeyPos1 = 1

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


    Private Sub cmd_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_update.Click
        Dim i As Integer
        Dim itemcd, acccd, SOURCE, ssql As String
        If ssgrid1.DataRowCnt <= 1 Then
            MsgBox("NO RECORD TO SAVE")
            Exit Sub
        End If
        With ssgrid1
            For i = 0 To ssgrid1.DataRowCnt - 1
                .Row = i + 1
                .Col = 1
                SOURCE = .Text
                .Col = 2
                itemcd = .Text
                .Col = 4
                acccd = .Text
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ssgrid1.ClearRange(1, 1, ssgrid1.DataColCnt, ssgrid1.DataRowCnt, False)
        Call ACCOUNTSITEMTAGGING_Load(sender, e)
    End Sub
End Class
