Public Class FRM_MKGA_HolidayMaster
    Private m_EditingRow As Integer = -1
    Dim TxtVal
    Dim HDate As Date
    Dim chkbool As Boolean
    Dim sqlstring As String
    Dim GConnection As New GlobalClass
    Dim i As Integer
    Dim rs As New Resizer1

    Public Sub ClrGrid()
        DataGridView1.DataSource = Nothing
        DataGridView1.Refresh()
        DataGridView1.Rows.Clear()
        'DataGridView1.Rows.Add()
    End Sub

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        'Call ClrGrid()
        sSGrid.ClearRange(1, 1, -1, -1, True)
        sSGrid.SetActiveCell(1, 1)
        Cmd_Add.Enabled = True
        Call Cmb_YearName_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellLeave
        'If DataGridView1.CurrentCell.ColumnIndex = 0 Then
        '    HDate = DataGridView1.CurrentCell.Value.ToString
        'ElseIf DataGridView1.CurrentCell.ColumnIndex = 1 Then
        '    If IsDBNull(DataGridView1.CurrentCell.Value.ToString) = False Or IsDBNull(DataGridView1.CurrentCell.Value.ToString) <> Nothing Then
        '        TxtVal = DataGridView1.CurrentCell.Value.ToString
        '    End If
        'End If
    End Sub
    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        'Dim i, j As Integer
        'If e.KeyCode = Keys.Enter Then
        '    i = DataGridView1.CurrentRow.Index
        '    j = DataGridView1.CurrentCell.ColumnIndex
        '    If DataGridView1.CurrentCell.ColumnIndex = 0 Then
        '        'DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(j + 1)
        '        DataGridView1.CurrentCell = DataGridView1(1, i)
        '        DataGridView1.BeginEdit(True)
        '        'DataGridView1.Rows(i).Cells(1).Selected = True
        '        'DataGridView1.CurrentCell.Selected = True
        '    ElseIf DataGridView1.CurrentCell.ColumnIndex = 1 Then
        '        DataGridView1.Rows.Add()
        '        DataGridView1.CurrentCell = DataGridView1(0, i + 1)
        '        DataGridView1.BeginEdit(True)
        '    End If
        'End If
        ' ''If e.KeyCode = Keys.Enter Then
        ' ''    If DataGridView1.CurrentCell.ColumnIndex = 0 Then
        ' ''        HDate = DataGridView1.CurrentCell.Value.ToString
        ' ''    ElseIf DataGridView1.CurrentCell.ColumnIndex = 1 Then
        ' ''        TxtVal = DataGridView1.CurrentCell.Value.ToString
        ' ''    End If
        ' ''    If IsDBNull(DataGridView1.CurrentCell.Value.ToString) = True Then
        ' ''        Exit Sub
        ' ''    End If
        ' ''    If DataGridView1.CurrentCell.ColumnIndex = DataGridView1.ColumnCount - 1 Then
        ' ''        If DataGridView1.CurrentCell.RowIndex < DataGridView1.RowCount - 1 Then
        ' ''            DataGridView1.CurrentCell = DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex + 1)
        ' ''        End If
        ' ''    Else
        ' ''        DataGridView1.CurrentCell = DataGridView1.Item(DataGridView1.CurrentCell.ColumnIndex + 1, DataGridView1.CurrentCell.RowIndex)
        ' ''    End If
        ' ''End If
        ' ''If e.KeyCode = Keys.Up Then
        ' ''    If DataGridView1.CurrentCell.ColumnIndex = DataGridView1.ColumnCount - 1 Then
        ' ''        If DataGridView1.CurrentCell.RowIndex < DataGridView1.RowCount - 1 And DataGridView1.CurrentCell.RowIndex <> 0 Then
        ' ''            DataGridView1.CurrentCell = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex - 1)
        ' ''        Else
        ' ''            If DataGridView1.CurrentCell.RowIndex <> 0 Then
        ' ''                DataGridView1.CurrentCell = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex - 1)
        ' ''            End If
        ' ''        End If
        ' ''    Else
        ' ''        If DataGridView1.CurrentCell.RowIndex = 0 Then
        ' ''        Else
        ' ''            DataGridView1.CurrentCell = DataGridView1.Item(DataGridView1.CurrentCell.ColumnIndex, DataGridView1.CurrentCell.RowIndex - 1)
        ' ''        End If
        ' ''    End If
        ' ''End If
        ' ''If e.KeyCode = Keys.Down Then
        ' ''    If DataGridView1.CurrentCell.ColumnIndex = DataGridView1.ColumnCount - 1 Then
        ' ''        If DataGridView1.CurrentCell.RowIndex < DataGridView1.RowCount - 1 Then
        ' ''            DataGridView1.CurrentCell = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex + 1)
        ' ''        End If
        ' ''    Else
        ' ''        If DataGridView1.CurrentCell.RowIndex = DataGridView1.RowCount - 1 Then
        ' ''        Else
        ' ''            DataGridView1.CurrentCell = DataGridView1.Item(DataGridView1.CurrentCell.ColumnIndex, DataGridView1.CurrentCell.RowIndex + 1)
        ' ''        End If
        ' ''    End If
        ' ''End If
        ' ''If e.KeyCode = Keys.Left Then
        ' ''    If DataGridView1.CurrentCell.ColumnIndex = DataGridView1.ColumnCount - 1 Then
        ' ''        If DataGridView1.CurrentCell.RowIndex < DataGridView1.RowCount - 1 Then
        ' ''            DataGridView1.CurrentCell = DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex - 0)
        ' ''        Else
        ' ''            DataGridView1.CurrentCell = DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex - 0)
        ' ''        End If
        ' ''    Else
        ' ''        DataGridView1.CurrentCell = DataGridView1.Item(DataGridView1.CurrentCell.ColumnIndex, DataGridView1.CurrentCell.RowIndex)
        ' ''    End If
        ' ''End If
        ' ''If e.KeyCode = Keys.Right Then
        ' ''    If DataGridView1.CurrentCell.ColumnIndex = DataGridView1.ColumnCount - 1 Then
        ' ''        If DataGridView1.CurrentCell.RowIndex < DataGridView1.RowCount - 1 Then
        ' ''            DataGridView1.CurrentCell = DataGridView1.Item(1, DataGridView1.CurrentCell.RowIndex)
        ' ''        End If
        ' ''    Else
        ' ''        DataGridView1.CurrentCell = DataGridView1.Item(DataGridView1.CurrentCell.ColumnIndex + 1, DataGridView1.CurrentCell.RowIndex)
        ' ''    End If
        ' ''End If
        ' ''e.Handled = True
    End Sub
    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        'If m_EditingRow >= 0 Then
        '    Dim new_row As Integer = m_EditingRow
        '    m_EditingRow = -1
        '    DataGridView1.CurrentCell = _
        '        DataGridView1.Rows(new_row). _
        '            Cells(DataGridView1.CurrentCell.ColumnIndex)
        '    If DataGridView1.CurrentCell.ColumnIndex = DataGridView1.ColumnCount - 1 Then
        '        If DataGridView1.CurrentCell.RowIndex < DataGridView1.RowCount - 1 Then
        '            DataGridView1.CurrentCell = DataGridView1.Item(0, DataGridView1.CurrentCell.RowIndex + 1)
        '        End If
        '    Else
        '        DataGridView1.CurrentCell = DataGridView1.Item(DataGridView1.CurrentCell.ColumnIndex + 1, DataGridView1.CurrentCell.RowIndex)
        '    End If
        'End If
    End Sub
    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        ''m_EditingRow = DataGridView1.CurrentRow.Index
    End Sub

    Private Sub FRM_MKGA_HolidayMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F6 Then
            Call Cmd_Clear_Click(Cmd_Clear, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then
            If Cmd_Add.Enabled = True Then
                Call Cmd_Add_Click(Cmd_Add, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F8 Then
            If Cmd_Freeze.Enabled = True Then
                Call Cmd_Freeze_Click(Cmd_Freeze, e)
                Exit Sub
            End If
        End If
        If e.KeyCode = Keys.F9 Then
            'If Cmd_View.Enabled = True Then
            '    Call Cmd_View_Click(Cmd_View, e)
            '    Exit Sub
            'End If
        End If
        If e.KeyCode = Keys.F12 Then
            Call Cmd_Export_Click(Cmd_Export, e)
            Exit Sub
        End If
        If e.KeyCode = Keys.F11 Or e.KeyCode = Keys.Escape Then
            Call Cmd_Exit_Click(Cmd_Exit, e)
            Exit Sub
        End If
    End Sub
    Private Sub FRM_MKGA_HolidayMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImageLayout = ImageLayout.Stretch
        rs.FindAllControls(Me)
        Me.resizeFormResolution()
        rs.ResizeAllControls(Me)
        Call FillYear()
        Cmb_YearName.Focus()
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

    Private Sub FillYear()
        Try
            Cmb_YearName.Items.Clear()
            'Cmb_YearName.Items.Add("")
            Cmb_YearName.Items.Add(gFinancalyearStart)
            Cmb_YearName.Items.Add(gFinancialYearEnd)
        Catch ex As Exception
            MessageBox.Show(" Check the error :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub sSGrid_KeyDownEvent(sender As Object, e As AxFPSpreadADO._DSpreadEvents_KeyDownEvent) Handles sSGrid.KeyDownEvent
        Dim i, j, K As Integer
        Search = Nothing
        Dim HDesc, HDay As String
        Try
            If e.keyCode = Keys.Enter Then
                i = sSGrid.ActiveRow
                If sSGrid.ActiveCol = 1 Then
                    sSGrid.Col = 1
                    sSGrid.Row = i
                    If Trim(sSGrid.Text) = "" Then
                        MessageBox.Show("Fill Date")
                        sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
                    Else
                        HDay = Format(CDate(sSGrid.Text), "dd-MM-yyyy")
                        If Year(HDay) <> Trim(Cmb_YearName.Text) Then
                            MessageBox.Show("Date Should Be Selected Year Name Only")
                        Else
                            sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                        End If
                    End If
                ElseIf sSGrid.ActiveCol = 2 Then
                    sSGrid.Col = 2
                    sSGrid.Row = i
                    If Trim(sSGrid.Text) <> "" Then
                        sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
                    Else
                        MessageBox.Show("Must Give Description")
                        sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
                    End If
                End If
            ElseIf e.keyCode = Keys.F3 Then
                sSGrid.Col = sSGrid.ActiveCol
                i = sSGrid.ActiveRow
                sSGrid.Row = i
                With sSGrid
                    .Row = .ActiveRow
                    .ClearRange(1, .ActiveRow, 11, .ActiveRow, True)
                    .DeleteRows(.ActiveRow, 1)
                    .SetActiveCell(1, sSGrid.ActiveRow)
                    .Focus()
                End With
            End If
        Catch ex As Exception
            MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try

    End Sub
    Private Sub Cmb_YearName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Cmb_YearName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Cmb_YearName.Text) <> "" Then
                sSGrid.Focus()
            Else
                Cmb_YearName.Focus()
            End If
        End If
    End Sub

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        Dim sql(0) As String
        Dim i As Integer
        Call CheckValidate() '---> Check Validation
        If chkbool = False Then Exit Sub
        If Cmd_Add.Text = "ADD [F7]" Then
            sql(0) = Nothing
            For i = 1 To sSGrid.DataRowCnt
                With sSGrid
                    strSQL = "INSERT INTO PARTY_HOLIDAYMASTER (YEAR_NAME,DATES,DESCRIPTIONS,ADD_USER,ADD_DATE,UPD_USER,VOID,VOIDUSER,AUTHORISED,AUTHORISE_LEVEL1,AUTHORISE_USER1,AUTHORISE_LEVEL2,AUTHORISE_USER2,AUTHORISE_LEVEL3,AUTHORISE_USER3) VALUES ( "
                    strSQL = strSQL & "'" & Trim(Cmb_YearName.Text) & "',"
                    .Row = i
                    .Col = 1
                    strSQL = strSQL & "'" & Format(CDate(.Text), "dd-MMM-yyyy") & "',"
                    .Col = 2
                    strSQL = strSQL & "'" & Trim(.Text) & "',"
                    strSQL = strSQL & "'" & Trim(gUsername) & "',getdate(),'','N','','N','','','','','','')"
                    ReDim Preserve sql(sql.Length)
                    sql(sql.Length - 1) = strSQL
                End With
            Next i
            GConnection.MoreTransold(sql)
            Call Cmd_Clear_Click(sender, e)
        ElseIf Cmd_Add.Text = "UPDATE [F7]" Then
            strSQL = "DELETE FROM PARTY_HOLIDAYMASTER WHERE YEAR_NAME = '" & Trim(Cmb_YearName.Text) & "' "
            sql(0) = strSQL
            For i = 1 To sSGrid.DataRowCnt
                With sSGrid
                    strSQL = "INSERT INTO PARTY_HOLIDAYMASTER (YEAR_NAME,DATES,DESCRIPTIONS,ADD_USER,ADD_DATE,UPD_USER,VOID,VOIDUSER,AUTHORISED,AUTHORISE_LEVEL1,AUTHORISE_USER1,AUTHORISE_LEVEL2,AUTHORISE_USER2,AUTHORISE_LEVEL3,AUTHORISE_USER3) VALUES ( "
                    strSQL = strSQL & "'" & Trim(Cmb_YearName.Text) & "',"
                    .Row = i
                    .Col = 1
                    strSQL = strSQL & "'" & Format(CDate(.Text), "dd-MMM-yyyy") & "',"
                    .Col = 2
                    strSQL = strSQL & "'" & Trim(.Text) & "',"
                    strSQL = strSQL & "'" & Trim(gUsername) & "',getdate(),'','N','','N','','','','','','')"
                    ReDim Preserve sql(sql.Length)
                    sql(sql.Length - 1) = strSQL
                End With
            Next i
            GConnection.MoreTransold(sql)
            Call Cmd_Clear_Click(sender, e)
        End If
    End Sub
    Private Sub CheckValidate()
        chkbool = False
        If Trim(Cmb_YearName.Text) = "" Then
            MessageBox.Show("Year Name Can't be blank", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Cmb_YearName.Focus()
            Exit Sub
        End If
        For I = 1 To sSGrid.DataRowCnt
            With sSGrid
                .Row = I
                .Col = 1
                'HDay = Format(CDate(sSGrid.Text), "dd-MM-yyyy")
                If (.Text) <> "" Then
                    If Year(Format(CDate(.Text), "dd-MM-yyyy")) <> Trim(Cmb_YearName.Text) Then
                        MessageBox.Show("Date Should Be Selected Year Name Only")
                        .SetActiveCell(1, I)
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Date Should Not Blank")
                    .SetActiveCell(1, I)
                    Exit Sub
                End If
                .Col = 2
                If Trim(.Text) = "" Then
                    MessageBox.Show("Description Can't be blank")
                    .SetActiveCell(2, I)
                    Exit Sub
                End If
            End With
        Next
        If sSGrid.DataRowCnt = 0 Then
            MessageBox.Show("Fill the Details of Year Holiday in Grid", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            sSGrid.Focus()
            Exit Sub
        End If
        chkbool = True
    End Sub
    Private Sub Cmb_YearName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Cmb_YearName.SelectedIndexChanged
        Try
            If Trim(Cmb_YearName.Text) <> "" Then
                sSGrid.ClearRange(1, 1, -1, -1, True)
                sqlstring = "SELECT * FROM PARTY_HOLIDAYMASTER WHERE YEAR_NAME = '" & Trim(Cmb_YearName.Text) & "' "
                GConnection.getDataSet(sqlstring, "HoliDay_Master")
                If gdataset.Tables("HoliDay_Master").Rows.Count > 0 Then
                    Cmb_YearName.Text = Trim(gdataset.Tables("HoliDay_Master").Rows(0).Item("YEAR_NAME"))
                    If gdataset.Tables("HoliDay_Master").Rows(0).Item("VOID") = "Y" Then
                        Me.lbl_Freeze.Visible = True
                        Me.lbl_Freeze.Text = ""
                        Me.lbl_Freeze.Text = "Record Void  On " & Format(CDate(gdataset.Tables("HoliDay_Master").Rows(0).Item("VOIDDATE")), "dd-MMM-yyyy")
                        Me.Cmd_Freeze.Text = "UnVoid[F8]"
                        Cmd_Add.Enabled = False
                    Else
                        Me.lbl_Freeze.Visible = False
                        Me.lbl_Freeze.Text = "Record Void  On "
                        Me.Cmd_Freeze.Text = "Void[F8]"
                        Cmd_Add.Enabled = True
                    End If
                    For i = 0 To gdataset.Tables("HoliDay_Master").Rows.Count - 1
                        With sSGrid
                            sSGrid.SetText(1, i + 1, Format(CDate(gdataset.Tables("HoliDay_Master").Rows(i).Item("DATES")), "dd/MM/yy"))
                            sSGrid.SetText(2, i + 1, Trim(gdataset.Tables("HoliDay_Master").Rows(i).Item("DESCRIPTIONS")))
                        End With
                    Next
                    Cmd_Add.Text = "UPDATE [F7]"
                    Cmb_YearName.Focus()
                Else
                    Me.lbl_Freeze.Visible = False
                    Me.lbl_Freeze.Text = "Record Void  On "
                    Me.Cmd_Add.Text = "ADD [F7]"
                    Cmb_YearName.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        Dim STATUS As Integer
        Dim sql(0) As String
        Call CheckValidate()
        If chkbool = False Then Exit Sub
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "V" Then
            STATUS = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If STATUS = 1 Then
                sqlstring = "UPDATE  PARTY_HOLIDAYMASTER "
                sqlstring = sqlstring & " SET VOID= 'Y',VOIDUSER='" & gUsername & " ', VOIDDATE=getdate()"
                sqlstring = sqlstring & " WHERE YEAR_NAME = '" & Trim(Cmb_YearName.Text) & "'"
                sql(0) = sqlstring

                GConnection.MoreTransold(sql)
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "ADD [F7]"
            Else
                Exit Sub
            End If
        Else
            STATUS = MsgBox("ARE U SURE U WANT UNFREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If STATUS = 1 Then
                sqlstring = "UPDATE  PARTY_HOLIDAYMASTER "
                sqlstring = sqlstring & " SET VOID= 'N',VOIDUSER='" & gUsername & " ', VOIDDATE=getdate()"
                sqlstring = sqlstring & " WHERE YEAR_NAME = '" & Trim(Cmb_YearName.Text) & "'"
                sql(0) = sqlstring

                GConnection.MoreTransold(sql)
                Me.Cmd_Clear_Click(sender, e)
                Cmd_Add.Text = "ADD [F7]"
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub Cmd_Export_Click(sender As Object, e As EventArgs) Handles Cmd_Export.Click
        Dim OBJ1 As New VIEWHDR
        sqlstring = "SELECT YEAR_NAME,DATES,DESCRIPTIONS,ADD_USER,CAST(CONVERT(VARCHAR,ADD_DATE,106) AS DATETIME) AS ADD_DATE,UPD_USER,CAST(CONVERT(VARCHAR,ISNULL(UPD_DATE,''),106) AS DATETIME) AS UPD_DATE,ISNULL(VOID,'') AS VOID,ISNULL(VOIDUSER,'') AS VOIDUSER,CAST(CONVERT(VARCHAR,ISNULL(VOIDDATE,''),106) AS DATETIME) AS VOIDDATE FROM PARTY_HOLIDAYMASTER ORDER BY YEAR_NAME,DATES"
        GConnection.getDataSet(sqlstring, "GMS_HOLIDAYMASTER")
        OBJ1.LOADGRID(gdataset.Tables("GMS_HOLIDAYMASTER"), False, "FRM_MKGA_HolidayMaster", "", "TOURNAMENTCODE", 1)
        OBJ1.Show()
    End Sub

    Private Sub sSGrid_LeaveCell(sender As Object, e As AxFPSpreadADO._DSpreadEvents_LeaveCellEvent) Handles sSGrid.LeaveCell
        'Dim i, j, K As Integer
        'Search = Nothing
        'Dim HDesc, HDay As String
        'Try
        '    i = sSGrid.ActiveRow
        '    If sSGrid.ActiveCol = 1 Then
        '        sSGrid.Col = 1
        '        sSGrid.Row = i
        '        If Trim(sSGrid.Text) = "" Then
        '            MessageBox.Show("Fill Date")
        '            sSGrid.SetActiveCell(1, sSGrid.ActiveRow)
        '        Else
        '            HDay = Format(CDate(sSGrid.Text), "dd-MM-yyyy")
        '            If Year(HDay) <> Trim(Cmb_YearName.Text) Then
        '                MessageBox.Show("Date Should Be Selected Year Name Only")
        '            Else
        '                sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
        '            End If
        '        End If
        '    ElseIf sSGrid.ActiveCol = 2 Then
        '        sSGrid.Col = 2
        '        sSGrid.Row = i
        '        If Trim(sSGrid.Text) <> "" Then
        '            sSGrid.SetActiveCell(1, sSGrid.ActiveRow + 1)
        '        Else
        '            MessageBox.Show("Must Give Description")
        '            sSGrid.SetActiveCell(2, sSGrid.ActiveRow)
        '        End If
        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Plz Check Error : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        '    Exit Sub
        'End Try

    End Sub

    Private Sub Cmd_view_Click(sender As Object, e As EventArgs) Handles Cmd_view.Click
        Dim FRM As New ReportDesigner
        If Cmb_YearName.Text.Length > 0 Then
            tables = " FROM PARTY_HOLIDAYMASTER WHERE YEAR_NAME = '" & Trim(Cmb_YearName.Text) & "'"
        Else
            tables = "FROM PARTY_HOLIDAYMASTER "
        End If
        Gheader = "PAYMENT ALLOCATION  DETAILS"
        FRM.DataGridView1.ColumnCount = 2
        FRM.DataGridView1.Columns(0).Name = "COLUMN NAME"
        FRM.DataGridView1.Columns(0).Width = 300
        FRM.DataGridView1.Columns(1).Name = "SIZE"
        FRM.DataGridView1.Columns(1).Width = 100
        Dim ROW As String() = New String() {"YEAR_NAME", "12"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"DATES", "11"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"DESCRIPTIONS", "18"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"VOID", "4"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADD_USER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"ADD_DATE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPD_USER", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        ROW = New String() {"UPD_DATE", "10"}
        FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"UPD_USER", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        'ROW = New String() {"UPD_DATE", "10"}
        'FRM.DataGridView1.Rows.Add(ROW)
        Dim CHK As New DataGridViewCheckBoxColumn()
        FRM.DataGridView1.Columns.Insert(0, CHK)
        CHK.HeaderText = "CHECK"
        CHK.Name = "CHK"
        FRM.ShowDialog(Me)
    End Sub

    Private Sub Cmd_Rpt_Click(sender As Object, e As EventArgs) Handles Cmd_Rpt.Click
    End Sub

    Private Sub FRM_MKGA_HolidayMaster_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class