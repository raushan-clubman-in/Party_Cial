Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports System.IO
Public Class FRM_MKGA_Purpose
    Inherits System.Windows.Forms.Form
    Dim vseqno As Double
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Dim rs As New Resizer1

    Private Sub cmdcodeHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCodeHelp.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(PCode,'') AS PCode,ISNULL(PDesc,'') AS PDesc FROM Party_DiscriptionMaster "
            M_WhereCondition = " "
            vform.Field = "PCode,PDesc"
            ' vform.Frmcalled = "   UOMCODE     | UOM NAME         |                                  "
            vform.vCaption = " Purpose Master Help"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                txtCode.Text = Trim(vform.keyfield & "")
                txtCode.Select()
                txtCode_Validated(sender, e)
                Cmd_Add.Text = "Update[F7]"
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try
    End Sub

    Private Sub FRM_MKGA_Purposer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        'If e.KeyCode = Keys.F8 Then
        '    Call Cmd_Freeze_Click(Cmd_Freeze, e)
        '    Exit Sub
        'End If
        'If e.KeyCode = Keys.F7 Then
        '    Call Cmd_Add_Click(Cmd_Add, e)
        '    Exit Sub
        'End If
        'If e.KeyCode = Keys.F9 Then
        '    Call Cmd_View_Click(Cmd_View, e)
        '    Exit Sub
        'End If
        If e.KeyCode = Keys.F8 Then
            If Cmd_Freeze.Enabled = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F7 Then
            If Cmd_Add.Enabled = True Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            If Cmdview.Enabled = True Then
                Call Cmdview_Click(Cmdview, e)
                Exit Sub
            End If
        End If
        'If e.KeyCode = Keys.F10 Then
        '    If cmdexport.Enabled = True Then
        '        Call cmdexport_Click(cmdexport, e)
        '        Exit Sub
        '    End If
        'End If
        'If e.KeyCode = Keys.F12 Then
        '    If cmdreport.Enabled = True Then
        '        Call cmdreport_Click(cmdreport, e)
        '        Exit Sub
        '    End If
        'End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub

    Private Sub FRM_MKGA_Purpose_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rs.FindAllControls(Me)
        Me.resizeFormResolution()
        rs.ResizeAllControls(Me)
        txtCode.ReadOnly = False
        cmdCodeHelp.Enabled = True
        txtCode.Focus()
        UOMMastbool = True
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
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='POS' AND MODULENAME LIKE '" & Trim(GmoduleName) & "%'"
        gconnection.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.Cmd_Add.Enabled = False
        Me.Cmd_Freeze.Enabled = False
        Cmdview.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    Me.Cmdview.Enabled = True
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
                If Right(x) = "D" Then
                    Me.Cmd_Freeze.Enabled = True
                End If
                If Right(x) = "V" Then
                    Me.Cmdview.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub txtCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdCodeHelp.Enabled = True Then
                Search = Trim(txtCode.Text)
                Call cmdcodeHelp_Click(txtCode, e)
            End If
        End If
    End Sub


    Private Sub txtDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesc.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If txtDesc.Text <> "" Then
                Cmd_Add.Focus()
            End If
        End If
    End Sub


    Private Sub txtCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Fre As String
        If Trim(txtCode.Text) <> "" Then
            Dim ds As New DataSet

            sqlstring = "SELECT isnull(PCode,'') as PCode,isnull(PDesc,'') as PDesc,isnull(AddDateTime,'') as AddDateTime,isnull(Freeze,'') as Freeze FROM Party_DiscriptionMaster WHERE PCode='" & Replace(txtCode.Text, "'", "") & "'"
            gconnection.getDataSet(sqlstring, "PMaster")
            If gdataset.Tables("PMaster").Rows.Count > 0 Then
                txtDesc.Clear()
                txtDesc.Text = Replace(gdataset.Tables("PMaster").Rows(0).Item("PDesc"), "", "'")
               

                If gdataset.Tables("PMaster").Rows(0).Item("Freeze") = "Y" Then
                    Me.lbl_Freeze.Visible = True
                    Me.lbl_Freeze.Text = ""
                    Me.lbl_Freeze.Text = "Record Freezed  On " & Format(CDate(gdataset.Tables("PMaster").Rows(0).Item("AddDateTime")), "dd-MMM-yyyy")
                    ' Me.Cmd_Freeze.Text = "UnFreeze[F8]"
                    Me.Cmd_Freeze.Enabled = False
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Freezed  On "
                    Me.Cmd_Freeze.Text = "Freeze[F8]"
                End If
                Me.Cmd_Add.Text = "Update[F7]"
                Me.txtCode.ReadOnly = True
                Me.cmdCodeHelp.Enabled = False
                Me.txtDesc.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                txtCode.ReadOnly = False
                txtDesc.Focus()
            End If
        Else
            txtCode.Text = ""
            txtDesc.Focus()
        End If
    End Sub

    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        Call clearform(Me)
        Me.lbl_Freeze.Visible = False
        Me.txtCode.ReadOnly = False
        'CBO_CATEGORY.Text = ""
        Me.lbl_Freeze.Text = " "
        txtCode.Text = ""
        txtDesc.Text = ""
        Me.Cmd_Freeze.Text = "Freeze[F8]"
        Me.Cmd_Freeze.Enabled = True
        Cmd_Add.Text = "Add [F7]"
        txtCode.Enabled = True
        txtCode.ReadOnly = False
        txtDesc.ReadOnly = False
        cmdCodeHelp.Enabled = True
        txtCode.Focus()
    End Sub
    Public Sub checkValidation()
        boolchk = False
        ''********** Check  Store Code Can't be blank *********************'''
        If Trim(txtCode.Text) = "" Then
            MessageBox.Show(" Code can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtCode.Focus()
            Exit Sub
        End If
        ''********** Check  Store desc Can't be blank *********************'''
        If Trim(txtDesc.Text) = "" Then
            MessageBox.Show(" Description can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDesc.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub


    'Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
    '    Dim sqlstring As String
    '    Dim _export As New EXPORT
    '    _export.TABLENAME = "Uommaster"
    '    sqlstring = "SELECT * FROM Uommaster order by UOMCODE"
    '    Call _export.export_excel(sqlstring)
    '    _export.Show()
    '    Exit Sub
    'End Sub



    'Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click

    '    Dim sqlstring, SSQL As String
    '    Dim Viewer As New ReportViwer
    '    Dim r As New Crptuommaster
    '    Dim POSdesc(), MemberCode() As String
    '    Dim SQLSTRING2 As String
    '    sqlstring = "select * from Uommaster"

    '    Call Viewer.GetDetails(sqlstring, "Uommaster", r)
    '    Viewer.TableName = "Uommaster"
    '    Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    TXTOBJ5 = r.ReportDefinition.ReportObjects("Text9")
    '    TXTOBJ5.Text = gCompanyname

    '    Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
    '    TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
    '    TXTOBJ1.Text = "UserName : " & gUsername
    '    Viewer.Show()
    'End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() ''--->Check Validation
            If boolchk = False Then Exit Sub
            vseqno = GetSeqno(txtCode.Text)
            strSQL = " INSERT INTO Party_DiscriptionMaster (PCode,PDesc,Freeze,AddUser,AddDatetime)"
            strSQL = strSQL & " VALUES ( '" & Trim(txtCode.Text) & "','" & Replace(Trim(txtDesc.Text), "'", "") & "',"
            strSQL = strSQL & "'N','" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            gconnection.dataOperation(1, strSQL, "PMaster")
            Me.Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call checkValidation() ''--->Check Validation
            If boolchk = False Then Exit Sub
            If Mid(Me.Cmd_Add.Text, 1, 1) = "U" Then
                If Me.lbl_Freeze.Visible = True Then
                    MessageBox.Show(" The Frezzed Record Can Not Be Update", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                    boolchk = False
                End If
            End If
            strSQL = "UPDATE  Party_DiscriptionMaster "
            strSQL = strSQL & " SET PDesc='" & Replace(Trim(txtDesc.Text), "'", "") & "',"
            strSQL = strSQL & " UPDATEUSER='" & Trim(gUsername) & "',UPDATETIME='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
            strSQL = strSQL & " WHERE PCode = '" & Trim(txtCode.Text) & "'"
            gconnection.dataOperation(2, strSQL, "UOMMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub Cmd_Freeze_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        Dim STATUS As Integer
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            STATUS = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If STATUS = 1 Then
                sqlstring = "UPDATE  Party_DiscriptionMaster "
                sqlstring = sqlstring & " SET Freeze= 'Y',AddUser='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE PCode = '" & Trim(Replace(txtCode.Text, "'", "")) & "'"
                gconnection.dataOperation(3, sqlstring, "UOMMaster")
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "Add [F7]"
            Else
                Exit Sub
            End If
            'Else
            '    STATUS = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            '    If STATUS = 1 Then
            '        sqlstring = "UPDATE  UOMMaster "
            '        sqlstring = sqlstring & " SET Freeze= 'N',AddUser='" & gUsername & " ', AddDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
            '        sqlstring = sqlstring & " WHERE UOMCode = '" & Trim(txtUOMCode.Text) & "'"
            '        gconnection.dataOperation(4, sqlstring, "UOMMaster")
            '        Me.Cmd_Clear_Click(sender, e)
            '        Cmd_Add.Text = "Add [F7]"
            '    Else
            '        Exit Sub
            '    End If
        End If
    End Sub

    Private Sub Cmdview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdview.Click
        'Dim FRM As New ReportDesigner
        'If txtCode.Text.Length > 0 Then
        '    tables = " FROM UOMMASTER WHERE UOMCODE = '" & Trim(txtUOMCode.Text) & "'"
        'Else
        '    tables = "FROM UOMMASTER "
        'End If
        'Gheader = "UOMMASTER DETAILS"
        'FRM.DataGridView1.ColumnCount = 2
        'FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        'FRM.DataGridView1.Columns(0).Width = 300
        'FRM.DataGridView1.Columns(1).Name = "SIZE"
        'FRM.DataGridView1.Columns(1).Width = 100

        'Dim ROW As String() = New String() {"UOMCODE", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"UOMDESC", "15"}
        'FRM.DataGridView1.Rows.Add(ROW)
        ''ROW = New String() {"GROUPCODE", "15"}
        ''FRM.DataGridView1.Rows.Add(ROW)
        ''ROW = New String() {"GROUPDESC", "15"}
        ''FRM.DataGridView1.Rows.Add(ROW)
        ' ''ROW = New String() {"CATEGORY", "15"}
        ' ''FRM.DataGridView1.Rows.Add(ROW)
        ''ROW = New String() {"SHORTNAME", "15"}
        ''FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"freeze", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"ADDUSER", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"ADDDATETIME", "11"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"UPDATEUSER", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"UPDATETIME", "11"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'Dim CHK As New DataGridViewCheckBoxColumn()
        'FRM.DataGridView1.Columns.Insert(0, CHK)
        'CHK.HeaderText = "CHECK"
        'CHK.Name = "CHK"
        'FRM.ShowDialog(Me)
    End Sub

    Private Sub Cmdbrse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbrse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM Party_DiscriptionMaster"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), True, "", "SELECT * FROM Party_DiscriptionMaster", "PCode", 1, Me.txtCode)
    End Sub

    Private Sub Cmdauth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdauth.Click
        'Dim SSQLSTR, SSQLSTR2 As String
        'SSQLSTR2 = " SELECT * FROM UOMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
        'gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        'If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
        '    gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
        '    gconnection.getDataSet(gSQLString, "AUTHORIZE")
        '    If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
        '        SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
        '        gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
        '        If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
        '            SSQLSTR2 = " SELECT * FROM UOMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
        '            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        '            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
        '                Dim VIEW1 As New AUTHORISATION
        '                VIEW1.Show()
        '                VIEW1.DTAUTH.DataSource = Nothing
        '                VIEW1.DTAUTH.Rows.Clear()
        '                'Dim STRQUERY As String
        '                'STRQUERY = "SELECT * FROM CORPORATEMASTER"
        '                ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
        '                'gconnection.getDataSet(STRQUERY, "authorize")

        '                Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE UOMMASTER set  ", "UOMCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 1)
        '            End If
        '        Else
        '            MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
        '        End If
        '    End If
        'Else
        '    SSQLSTR2 = " SELECT * FROM UOMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''"
        '    gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        '    If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
        '        gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
        '        gconnection.getDataSet(gSQLString, "AUTHORIZE1")
        '        If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
        '            SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
        '            gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
        '            If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
        '                SSQLSTR2 = " SELECT * FROM UOMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''"
        '                gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        '                If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
        '                    Dim VIEW1 As New AUTHORISATION
        '                    VIEW1.Show()
        '                    VIEW1.DTAUTH.DataSource = Nothing
        '                    VIEW1.DTAUTH.Rows.Clear()
        '                    'Dim STRQUERY As String
        '                    'STRQUERY = "SELECT * FROM CORPORATEMASTER"
        '                    ''STRQUERY = "SELECT isnull(MODULENAME,'')as MODULENAME,isnull(FORMNAME,'') as FORMNAME,isnull(FORMTYPE,'')as FORMTYPE,isnull(AUTHORIZELEVEL,'')as AUTHORIZELEVEL,isnull(AUTH1USER1,'')as AUTH1USER1,isnull(AUTH1USER2,'') as AUTH1USER2,isnull(AUTH2USER1,'')as  AUTH2USER1,isnull(AUTH2USER2,'')as AUTH2USER2,isnull(AUTH3USER1,'')as AUTH3USER1,isnull(AUTH3USER2,'') as AUTH3USER2,isnull(void,'') as void,isnull(ADDUSERID,'')as ADDUSERID,isnull(ADDDATETIME,'')as ADDDATETIME FROM authorize"
        '                    'gconnection.getDataSet(STRQUERY, "authorize")

        '                    Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE UOMMASTER set  ", "UOMCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
        '                End If
        '            End If
        '        End If
        '    Else
        '        SSQLSTR2 = " SELECT * FROM UOMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
        '        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        '        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
        '            gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "')"
        '            gconnection.getDataSet(gSQLString, "AUTHORIZE2")
        '            If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
        '                SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='MEMBER APPLICATION' AND FORMNAME='" & GmoduleName & "'"
        '                gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
        '                If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
        '                    SSQLSTR2 = " SELECT * FROM UOMMASTER WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
        '                    gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
        '                    If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
        '                        Dim VIEW1 As New AUTHORISATION
        '                        VIEW1.Show()
        '                        VIEW1.DTAUTH.DataSource = Nothing
        '                        VIEW1.DTAUTH.Rows.Clear()

        '                        Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE UOMMASTER set  ", "UOMCODE", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
        '                    End If
        '                End If
        '            End If
        '        Else
        '            MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub Cmd_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub cmdreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdreport.Click
        'Dim sqlstring As String
        'Dim Viewer As New ReportViwer
        'Dim r As New Crptuommaster
        'sqlstring = "select * from Uommaster"
        'Call Viewer.GetDetails(sqlstring, "Uommaster", r)
        'Viewer.TableName = "Uommaster"
        'Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ5 = r.ReportDefinition.ReportObjects("Text9")
        'TXTOBJ5.Text = gCompanyname

        'Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ1 = r.ReportDefinition.ReportObjects("Text1")
        'TXTOBJ1.Text = "UserName : " & gUsername

        'Dim TXTOBJ6 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ6 = r.ReportDefinition.ReportObjects("Text8")
        'TXTOBJ6.Text = Address1 & Address2

        'Dim TXTOBJ8 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ8 = r.ReportDefinition.ReportObjects("Text6")
        'TXTOBJ8.Text = gCity & "," & gState & "-" & gPincode

        'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
        'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text11")
        'TXTOBJ9.Text = "PhoneNo : " & gphoneno
        'Viewer.Show()
    End Sub

    Private Sub txtCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtCode.Text) <> "" Then
                Call txtCode_Validated(txtCode, e)
                txtDesc.Focus()
            Else
                Call cmdcodeHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub FRM_MKGA_Purpose_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class