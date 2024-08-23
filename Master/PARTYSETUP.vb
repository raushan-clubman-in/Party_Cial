Public Class PARTYSETUP
    Dim boolchk As Boolean
    Dim vseqno As String
    Dim sqlstring As String

    Dim gconnection As New GlobalClass

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub PARTYSETUP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cmd_Clear_Click(sender, e)
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

   
    Private Sub SSGRID_Advance(ByVal sender As System.Object, ByVal e As AxFPSpreadADO._DSpreadEvents_AdvanceEvent) Handles SSGRID.Advance

    End Sub
    Private Sub SSGRID_KeyDownEvent(ByVal sender As Object, ByVal e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles SSGRID.KeyDownEvent
        Dim I As Integer
        Dim DEPT, TRANS As String
        Dim DOB As Date
        With SSGRID
            If e.keyCode = Keys.Enter Then
                I = .ActiveRow
                If .ActiveCol = 1 Then
                    .Row = I
                    .Col = 1
                    If Trim(.Text) = "" Then
                        Call fillTrans()
                    Else
                        sqlstring = "SELECT ISNULL(USERNAME,'') AS USERNAME FROM POS_VIEW_USERADMIN"
                        sqlstring = sqlstring & " WHERE USERNAME="
                        .Col = 1
                        .Row = I
                        TRANS = .Text
                        sqlstring = sqlstring & " '" & TRANS & "'"
                        gconnection.getDataSet(sqlstring, "TRANS")
                        If gdataset.Tables("TRANS").Rows.Count > 0 Then
                            .Col = 1
                            .Row = I
                            .Text = gdataset.Tables("TRANS").Rows(0).Item("USERNAME")

                            .SetActiveCell(1, I + 1)
                        Else
                            MsgBox("NO SUCH ITEM FOUND")
                            .Text = ""
                            .SetActiveCell(1, I)
                        End If
                    End If
                End If
            End If
            If e.keyCode = Keys.F3 Then
                .DeleteRows(.ActiveRow, 1)
                .SetActiveCell(1, I)
                .Focus()
            End If
        End With
    End Sub
    'CmdAdd.Text = "Update[F7]"
    Private Sub fillTrans()
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT USERNAME FROM POS_VIEW_USERADMIN"
            M_WhereCondition = " "
            vform.Field = "USERNAME "
            ' vform.Frmcalled = "  USERNAME  | ID        |                                  "
            vform.vCaption = "USER NAME HELP"
            'vform.KeyPos = 0
            'vform.KeyPos1 = 1
            'vform.KeyPos2 = 2
            vform.ShowDialog(Me)
            If Trim(vform.keyfield & "") <> "" Then
                'txtPOSCode.Text = Trim(vform.keyfield & "")
                'txtPOSCode.Select()
                'txtPOSCode_Validated(sender, e)
                'CmdAdd.Text = "Update[F7]"
                With SSGRID
                    .Col = 1
                    .Row = .ActiveRow
                    .Text = Trim(vform.keyfield)
                    .SetActiveCell(1, .ActiveRow + 1)
                    .Focus()
                End With
            End If
            vform.Close()
            vform = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, gCompanyname)
        End Try

    End Sub

    Private Sub cmd_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd_exit.Click
        Me.Close()
    End Sub

    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Dim SQL(0), TTYPE, SALES As String
        Dim I As Integer
        Dim SQL1 As String
        With SSGRID
            For I = 0 To SSGRID.DataRowCnt - 1
                .Row = I + 1
                .Col = 1
                TTYPE = .Text

                sqlstring = "INSERT INTO PARTY_USERCONTROL_LOG(USERNAME,ADDUSER,ADDDATE)"
                sqlstring = sqlstring & " VALUES ('" & Trim(TTYPE) & "',"
                sqlstring = sqlstring & " '" & gUsername & "','" & Format(Now(), "dd/MMM/yyyy HH:mm:ss") & "')"
                ReDim Preserve SQL(SQL.Length)
                SQL(SQL.Length - 1) = sqlstring

            Next I
        End With



        Call CHECKVALIDATE()
        If boolchk = False Then Exit Sub
        SQL1 = "SELECT * FROM PARTYSETUP"
        gconnection.getDataSet(SQL1, "SETUP")
        If gdataset.Tables("SETUP").Rows.Count > 0 Then

            Cmd_Add.Text = "Update[F7]"
        Else
            Cmd_Add.Text = "Add [F7]"
        End If
        If Cmd_Add.Text = "Add [F7]" Then
            sqlstring = "insert INTO PARTYSETUP (menuselection,OUTSIDEITEM,RATEUPDATE,ADDUSER,ADDDATETIME)VALUES('" & ComboBox1.Text & " ','" & ComboBox2.Text & "','" & ComboBox3.Text & "' ,"
            sqlstring = sqlstring & " '" & Trim(gUsername) & "','" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
            ReDim Preserve SQL(SQL.Length)
            SQL(SQL.Length - 1) = sqlstring

            sqlstring = "DELETE FROM  PARTY_USERCONTROL "
            ReDim Preserve SQL(SQL.Length)
            SQL(SQL.Length - 1) = sqlstring


            With SSGRID
                For I = 0 To SSGRID.DataRowCnt - 1
                    .Row = I + 1
                    .Col = 1
                    TTYPE = .Text

                    sqlstring = "INSERT INTO PARTY_USERCONTROL (USERNAME,ADDUSER,ADDDATE)"
                    sqlstring = sqlstring & " VALUES ('" & Trim(TTYPE) & "',"
                    sqlstring = sqlstring & " '" & gUsername & "','" & Format(Now(), "dd/MMM/yyyy HH:mm:ss") & "')"
                    ReDim Preserve SQL(SQL.Length)
                    SQL(SQL.Length - 1) = sqlstring

                Next I
            End With


        ElseIf Cmd_Add.Text = "Update[F7]" Then
            Call CHECKVALIDATE()
            If boolchk = False Then Exit Sub
            sqlstring = "DELETE FROM  PARTY_USERCONTROL "

            ReDim Preserve SQL(SQL.Length)
            SQL(SQL.Length - 1) = sqlstring

            With SSGRID
                For I = 0 To SSGRID.DataRowCnt - 1
                    .Row = I + 1
                    .Col = 1
                    TTYPE = .Text

                    sqlstring = "INSERT INTO PARTY_USERCONTROL (USERNAME,ADDUSER,ADDDATE)"
                    sqlstring = sqlstring & " VALUES ('" & Trim(TTYPE) & "','" & gUsername & "',"
                    sqlstring = sqlstring & " '" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "')"
                    ReDim Preserve SQL(SQL.Length)
                    SQL(SQL.Length - 1) = sqlstring

                Next I
            End With


        End If
        gconnection.MoreTransold(SQL)
        Cmd_Clear_Click(sender, e)
    End Sub
    Private Sub CHECKVALIDATE()
        boolchk = False
        If (ComboBox1.Text = "") Then
            MessageBox.Show("MENU SELECTION CANNOT BE BLANK", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub
        End If
        If (ComboBox2.Text = "") Then
            MessageBox.Show("OUTSIDE ITEM CANNOT BE BLANK", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub

        End If
        If (ComboBox3.Text = "") Then
            MessageBox.Show("HALL OPEN FACILITY CANNOT BE BLANK", MyCompanyName, MessageBoxButtons.OK)
            Exit Sub

        End If
        boolchk = True
    End Sub
    Private Sub FILL()
        Dim SQL As String
        Dim I As Integer
        SQL = "SELECT * FROM PARTYSETUP"
        gconnection.getDataSet(SQL, "SETUP")
        If gdataset.Tables("SETUP").Rows.Count > 0 Then

            Cmd_Add.Text = "Update[F7]"
        Else
            Cmd_Add.Text = "Add [F7]"
        End If

        SQL = "SELECT * FROM PARTYSETUP"
        gconnection.getDataSet(SQL, "SETUP")
        If gdataset.Tables("SETUP").Rows.Count > 0 Then
            ComboBox1.Text = Trim(gdataset.Tables("SETUP").Rows(0).Item("menuselection"))
            ComboBox2.Text = Trim(gdataset.Tables("SETUP").Rows(0).Item("OUTSIDEITEM"))
            ComboBox3.Text = Trim(gdataset.Tables("SETUP").Rows(0).Item("RATEUPDATE"))
            ComboBox1.Enabled = True
            ComboBox2.Enabled = True
            ComboBox3.Enabled = True
          
            SQL = "select * from PARTY_USERCONTROL  "
            gconnection.getDataSet(SQL, "MEM")
            If gdataset.Tables("MEM").Rows.Count > 0 Then
                With SSGRID
                    For I = 0 To gdataset.Tables("MEM").Rows.Count - 1
                        .Col = 1
                        .Row = I + 1
                        .Text = Trim(gdataset.Tables("MEM").Rows(I).Item("USERNAME"))
                    Next
                    .SetActiveCell(1, 1)
                    .Focus()
                End With
            End If

        End If
    End Sub
    Private Sub Cmd_Clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Clear.Click
        SSGRID.ClearRange(1, 1, -1, -1, True)
        Call FILL()
    End Sub

    Private Sub Cmdbwse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmdbwse.Click
        Dim I As Integer
        Dim TTYPE As String
        brows = True
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM PARTY_USERCONTROL"
        gconnection.getDataSet(STRQUERY, "authorize")
        With SSGRID
            For I = 0 To SSGRID.DataRowCnt - 1


                .Row = I + 1
                .Col = 1
                TTYPE = .Text
            Next I
        End With

        Call VIEW1.LOADGRID(gdataset.Tables("authorize"), True, "", "SELECT * FROM PARTY_USERCONTROL", "USERNAME", 1, Me.ComboBox1)

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
            SSQLSTR2 = " SELECT * FROM PARTY_USERCONTROL WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH1USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH1USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE")
                If gdataset.Tables("AUTHORIZE").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND ISNULL(AUTHORIZELEVEL,0)>0 "
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PARTY_USERCONTROL WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER1,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_USERCONTROL set  ", "USERNAME", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 1, 0)
                        End If
                    Else
                        MsgBox("NO AUTHORIZATION REQUIRED FOR THE ENTRY")
                    End If
                End If
            End If
        ElseIf USERT = 2 Then
            SSQLSTR2 = " SELECT * FROM PARTY_USERCONTROL WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')='' AND ISNULL(AUTHORISE_USER1,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH2USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH2USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE1")
                If gdataset.Tables("AUTHORIZE1").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PARTY_USERCONTROL WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER2,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()


                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_USERCONTROL set  ", "USERNAME", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 2, 1)
                        End If
                    End If
                End If
            End If
        ElseIf USERT = 3 Then
            SSQLSTR2 = " SELECT * FROM PARTY_USERCONTROL WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''AND ISNULL(AUTHORISE_USER1,'')<>''  AND ISNULL(AUTHORISE_USER2,'')<>''"
            gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
            If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                gSQLString = "  SELECT * FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' AND '" & gUsername & "' IN(SELECT AUTH3USER1 FROM AUTHORIZE  WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "' UNION ALL SELECT AUTH3USER2 FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "')"
                gconnection.getDataSet(gSQLString, "AUTHORIZE2")
                If gdataset.Tables("AUTHORIZE2").Rows.Count > 0 Then
                    SSQLSTR = "SELECT ISNULL(AUTHORIZELEVEL,0) AS AUTHORIZELEVEL FROM AUTHORIZE WHERE MODULENAME='SPECIALPARTY' AND FORMNAME='" & GmoduleName & "'"
                    gconnection.getDataSet(gSQLString, "AUTHORIZELEVEL")
                    If gdataset.Tables("AUTHORIZELEVEL").Rows.Count > 0 Then
                        SSQLSTR2 = " SELECT * FROM PARTY_USERCONTROL WHERE ISNULL(AUTHORISED,'')<>'Y' AND ISNULL(AUTHORISE_USER3,'')=''"
                        gconnection.getDataSet(SSQLSTR2, "AUTHORIZEL")
                        If gdataset.Tables("AUTHORIZEL").Rows.Count > 0 Then
                            Dim VIEW1 As New AUTHORISATION
                            VIEW1.Show()
                            VIEW1.DTAUTH.DataSource = Nothing
                            VIEW1.DTAUTH.Rows.Clear()
                            Call VIEW1.LOADGRID(gdataset.Tables("AUTHORIZEL"), False, Me, "UPDATE PARTY_USERCONTROL set  ", "USERNAME", gdataset.Tables("AUTHORIZELEVEL").Rows(0).Item("AUTHORIZELEVEL"), 3, 1)
                        End If
                    End If
                End If
            Else
                MsgBox("U R NOT ELIGIBLE TO AUTHORISE IN ANY LEVEL", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    Private Sub Cmd_view_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_view.Click
        Dim FRM As New ReportDesigner
        Dim I As Integer
        Dim TTYPE As String

        With SSGRID
            For I = 0 To SSGRID.DataRowCnt - 1


                .Row = I + 1
                .Col = 1
                TTYPE = .Text
            Next I
        End With

        If TTYPE.Length > 0 Then
            tables = " FROM PARTY_USERCONTROL" ' WHERE PCODE ='" & (TTYPE) & "' "
        Else
            tables = "FROM PARTY_USERCONTROL "
        End If
        Gheader = "USER  DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100

        Dim ROW As String() = New String() {"USERNAME", "8"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADDUSER", "20"}
        FRM.DataGridView1.Rows.Add(ROW)

        ROW = New String() {"ADDDATE", "30"}
        FRM.DataGridView1.Rows.Add(ROW)


        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub
End Class