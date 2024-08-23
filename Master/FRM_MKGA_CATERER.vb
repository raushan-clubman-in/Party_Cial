Imports System.Data.SqlClient
Imports System
Imports System.Data
Imports System.IO
Public Class FRM_MKGA_CATERER
    Dim vseqno As Double
    Dim boolchk As Boolean
    Dim sqlstring As String
    Dim gconnection As New GlobalClass
    Dim rs As New Resizer1

    Private Sub Cmd_Clear_Click(sender As Object, e As EventArgs) Handles Cmd_Clear.Click
        txtCode.Text = ""
        txtName.Text = ""
        Txt_Prof.Text = ""
        Txt_Add1.Text = ""
        Txt_Add2.Text = ""
        Txt_City.Text = ""
        Txt_State.Text = ""
        Txt_Pin.Text = ""
        Txt_Cell.Text = ""
        Txt_Email.Text = ""
        Txt_CPerson.Text = ""
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Me.lbl_Freeze.Visible = False
        Me.lbl_Freeze.Text = "Record Freezed  On "
        Me.Cmd_Add.Text = "Add [F7]"
        Cmd_Freeze.Enabled = True
        txtCode.ReadOnly = False
        cmdCodeHelp.Enabled = True
        txtCode.Focus()
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
        'Cmdview.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.Cmd_Add.Enabled = True
                    Me.Cmd_Freeze.Enabled = True
                    'Me.Cmdview.Enabled = True
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
                    'Me.Cmdview.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub Cmd_Exit_Click(sender As Object, e As EventArgs) Handles Cmd_Exit.Click
        Me.Close()
    End Sub

    Private Sub cmdCodeHelp_Click(sender As Object, e As EventArgs) Handles cmdCodeHelp.Click
        Try
            Dim vform As New LIST_OPERATION1
            gSQLString = "SELECT ISNULL(Ccode,'') AS Ccode,ISNULL(CName,'') AS CName FROM Party_CatererMaster "
            M_WhereCondition = " "
            vform.Field = "Ccode,CName"
            ' vform.Frmcalled = "   UOMCODE     | UOM NAME         |                                  "
            vform.vCaption = " Caterer Master Help"
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

    Private Sub Cmd_Add_Click(sender As Object, e As EventArgs) Handles Cmd_Add.Click
        Dim strSQL As String
        If Cmd_Add.Text = "Add [F7]" Then
            Call checkValidation() ''--->Check Validation
            If boolchk = False Then Exit Sub
            strSQL = " INSERT INTO Party_CatererMaster (Ccode,CName,Professionl,Add1,Add2,City,CState,Pincode,Cell,Email,CPerson,Freeze,AddUser,AddDatetime)"
            strSQL = strSQL & " VALUES ( '" & Trim(txtCode.Text) & "','" & Trim(txtName.Text) & "','" & Trim(Txt_Prof.Text) & "','" & Trim(Txt_Add1.Text) & "',"
            strSQL = strSQL & " '" & Trim(Txt_Add2.Text) & "','" & Trim(Txt_City.Text) & "','" & Trim(Txt_State.Text) & "','" & Trim(Txt_Pin.Text) & "',"
            strSQL = strSQL & " '" & Trim(Txt_Cell.Text) & "','" & Trim(Txt_Email.Text) & "','" & Trim(Txt_CPerson.Text) & "',"
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
            strSQL = "UPDATE  Party_CatererMaster "
            strSQL = strSQL & " SET CName='" & Trim(txtName.Text) & "',Professionl='" & Trim(Txt_Prof.Text) & "',Add1='" & Trim(Txt_Add1.Text) & "',"
            strSQL = strSQL & " Add2='" & Trim(Txt_Add2.Text) & "',City='" & Trim(Txt_City.Text) & "',CState='" & Trim(Txt_State.Text) & "',"
            strSQL = strSQL & " Pincode='" & Trim(Txt_Pin.Text) & "',Cell='" & Trim(Txt_Cell.Text) & "',Email='" & Trim(Txt_Email.Text) & "',CPerson='" & Trim(Txt_CPerson.Text) & "',"
            strSQL = strSQL & " UpdUser='" & Trim(gUsername) & "',UpdDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "',freeze='N'"
            strSQL = strSQL & " WHERE Ccode = '" & Trim(txtCode.Text) & "'"
            gconnection.dataOperation(2, strSQL, "PMaster")
            Me.Cmd_Clear_Click(sender, e)
            Cmd_Add.Text = "Add [F7]"
        End If
    End Sub

    Private Sub txtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyCode = Keys.F4 Then
            If cmdCodeHelp.Enabled = True Then
                Search = Trim(txtCode.Text)
                Call cmdCodeHelp_Click(txtCode, e)
            End If
        End If
    End Sub

    Private Sub txtCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCode.KeyPress
        getAlphanumeric(e)
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtCode.Text) <> "" Then
                Call txtCode_Validated(txtCode, e)
                txtName.Focus()
            Else
                Call cmdCodeHelp_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub txtCode_Validated(sender As Object, e As EventArgs) Handles txtCode.Validated
        Dim Fre As String
        If Trim(txtCode.Text) <> "" Then
            Dim ds As New DataSet

            sqlstring = "SELECT * FROM Party_CatererMaster WHERE Ccode='" & Replace(txtCode.Text, "'", "") & "'"
            gconnection.getDataSet(sqlstring, "PMaster")
            If gdataset.Tables("PMaster").Rows.Count > 0 Then
                txtName.Text = (gdataset.Tables("PMaster").Rows(0).Item("CName"))
                Txt_Prof.Text = (gdataset.Tables("PMaster").Rows(0).Item("Professionl"))
                Txt_Add1.Text = (gdataset.Tables("PMaster").Rows(0).Item("Add1"))
                Txt_Add2.Text = (gdataset.Tables("PMaster").Rows(0).Item("Add2"))
                Txt_City.Text = (gdataset.Tables("PMaster").Rows(0).Item("City"))
                Txt_State.Text = (gdataset.Tables("PMaster").Rows(0).Item("CState"))
                Txt_Pin.Text = (gdataset.Tables("PMaster").Rows(0).Item("Pincode"))
                Txt_Cell.Text = (gdataset.Tables("PMaster").Rows(0).Item("Cell"))
                Txt_Email.Text = (gdataset.Tables("PMaster").Rows(0).Item("Email"))
                Txt_CPerson.Text = (gdataset.Tables("PMaster").Rows(0).Item("CPerson"))

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
                Me.txtName.Focus()
            Else
                Me.lbl_Freeze.Visible = False
                Me.lbl_Freeze.Text = "Record Freezed  On "
                Me.Cmd_Add.Text = "Add [F7]"
                txtCode.ReadOnly = False
                txtName.Focus()
            End If
        Else
            txtCode.Text = ""
            txtName.Focus()
        End If
    End Sub

    Private Sub Txt_Prof_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Prof.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Prof.Text) <> "" Then
                Txt_Add1.Focus()
            Else
                Txt_Prof.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_Add1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Add1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Add1.Text) <> "" Then
                Txt_Add2.Focus()
            Else
                Txt_Add1.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_Add2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Add2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Add2.Text) <> "" Then
                Txt_City.Focus()
            Else
                Txt_Add2.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_City_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_City.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_City.Text) <> "" Then
                Txt_State.Focus()
            Else
                Txt_City.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_State_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_State.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_State.Text) <> "" Then
                Txt_Pin.Focus()
            Else
                Txt_State.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_Pin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Pin.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Pin.Text) <> "" Then
                Txt_Cell.Focus()
            Else
                Txt_Pin.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_Cell_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Cell.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Cell.Text) <> "" Then
                Txt_Email.Focus()
            Else
                Txt_Cell.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_Email_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_Email.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_Email.Text) <> "" Then
                Txt_CPerson.Focus()
            Else
                Txt_Email.Focus()
            End If
        End If
    End Sub

    Private Sub Txt_CPerson_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txt_CPerson.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(Txt_CPerson.Text) <> "" Then
                Cmd_Add.Focus()
            Else
                Txt_CPerson.Focus()
            End If
        End If
    End Sub

    Private Sub txtName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtName.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Trim(txtName.Text) <> "" Then
                Txt_Prof.Focus()
            Else
                txtName.Focus()
            End If
        End If
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
        If Trim(txtName.Text) = "" Then
            MessageBox.Show(" Name can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtName.Focus()
            Exit Sub
        End If
        If Trim(Txt_CPerson.Text) = "" Then
            MessageBox.Show(" Contact Person can't be blank ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Txt_CPerson.Focus()
            Exit Sub
        End If
        boolchk = True
    End Sub

    Private Sub Cmd_Freeze_Click(sender As Object, e As EventArgs) Handles Cmd_Freeze.Click
        Call checkValidation() ''-->Check Validation
        If boolchk = False Then Exit Sub
        Dim STATUS As Integer
        If Mid(Me.Cmd_Freeze.Text, 1, 1) = "F" Then
            STATUS = MsgBox("ARE U SURE U WANT FREEZE THE RECORD", MsgBoxStyle.OkCancel, Me.Text)
            If STATUS = 1 Then
                sqlstring = "UPDATE  Party_CatererMaster "
                sqlstring = sqlstring & " SET Freeze= 'Y',UpdUser='" & gUsername & " ', UpdDatetime='" & Format(Now, "dd-MMM-yyyy hh:mm:ss") & "'"
                sqlstring = sqlstring & " WHERE Ccode = '" & Trim(Replace(txtCode.Text, "'", "")) & "'"
                gconnection.dataOperation(3, sqlstring, "CMaster")
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

    Private Sub Cmdbrse_Click(sender As Object, e As EventArgs) Handles Cmdbrse.Click
        Dim VIEW1 As New VIEWHDR
        VIEW1.Show()
        VIEW1.DTGRDHDR.DataSource = Nothing
        VIEW1.DTGRDHDR.Rows.Clear()
        Dim STRQUERY As String
        STRQUERY = "SELECT * FROM Party_CatererMaster"
        gconnection.getDataSet(STRQUERY, "MENUMASTER")
        Call VIEW1.LOADGRID(gdataset.Tables("MENUMASTER"), False, "", "SELECT * FROM Party_CatererMaster", "Ccode", 1, Me.txtCode)
    End Sub

 
    Private Sub FRM_MKGA_CATERER_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackgroundImageLayout = ImageLayout.Stretch
        rs.FindAllControls(Me)
        Me.resizeFormResolution()
        rs.ResizeAllControls(Me)
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

    Private Sub FRM_MKGA_CATERER_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        rs.ResizeAllControls(Me)
    End Sub
End Class