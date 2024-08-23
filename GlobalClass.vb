Imports System.Data
Imports System.IO
Imports System.data.SqlClient
Public Class GlobalClass
    Public connect As sqlconnection
    Public sqlconnection, sqlconnection1 As String
    Public Myconn As New sqlconnection
    Dim MyTrans As SqlTransaction
    Dim Cmd As New SqlCommand
    Dim DataString As String
    Dim ssql As String
    Public Enum genum
        Add = 1
        Update = 2
        Freeze = 3
        unFreeze = 4
        View = 5
        Delete = 6
    End Enum
    Public Function MoreTransold(ByVal str() As String)
        Dim i As Integer
        Try

            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            ' MyCompanyName = "KGA"
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandTimeout = 999999
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i

            MyTrans.Commit()
            Myconn.Close()
            MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            rac = 1
            dblMsg = 1
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("PLEASE PRESS ENTER AGAIN" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function

    Public Function GetMatching(ByVal VoucherNo As String, ByVal VoucherType As String) As DataTable
        Dim ssql As String
        ssql = "Select AvoucherNo,AVoucherDate,AvoucherType,AdjustedAmount From Matching Where VoucherNo='" & VoucherNo & "' And Isnull(AdjustedAmount,0) > 0 and VoucherType='" & Trim(VoucherType) & "' Order By AvoucherDate "
        If Myconn.State <> ConnectionState.Open Then
            openConnection()
        End If
        Dim Dt As New DataTable
        Dim adp As New SqlClient.SqlDataAdapter(ssql, Myconn)
        adp.SelectCommand.CommandTimeout = 9999999
        adp.Fill(Dt)
        Try
            Return Dt
        Catch ex As Exception
            Dim str As String = ex.Message
            MsgBox(str, Application.ProductName, MessageBoxButtons.OK + MsgBoxStyle.Critical)
            Return Nothing
        Finally
            closeConnection()
        End Try
    End Function
    Public Sub printheader(ByVal col As Integer, ByVal vcaption As String)
        'Filewrite.WriteLine(Space((col - 26) / 2) & Chr(14) & Chr(15) & "THE CALCUTTA SWIMMING CLUB ")
        'Filewrite.WriteLine(Space((col - 14) / 2) & Chr(14) & Chr(15) & "1,STRAND ROAD")
        'Filewrite.WriteLine(Space((col - 14) / 2) & Chr(14) & Chr(15) & "KOLKATA-700001" & Chr(18))
        'Filewrite.WriteLine(Space((col - Len(gMAINCompanyname)) / 2) & Chr(14) & Chr(15) & gMAINCompanyname & Chr(18))
        'Filewrite.WriteLine(Space((col - Len(Trim(gCompanyAddress(0)))) / 2) & Chr(14) & Chr(15) & gCompanyAddress(0) & Chr(18))
        'Filewrite.WriteLine(Space((col - Len(Trim(gCompanyAddress(1)))) / 2) & Chr(14) & Chr(15) & gCompanyAddress(1) & Chr(18))
        Filewrite.WriteLine(Chr(14) & Chr(15) & gMAINCompanyname & Chr(18))
        Filewrite.WriteLine(Chr(14) & Chr(15) & gCompanyAddress(0) & Chr(18))
        Filewrite.WriteLine(Chr(14) & Chr(15) & gCompanyAddress(1) & Chr(18))
        Filewrite.WriteLine()
        Filewrite.WriteLine(Chr(15))
        Filewrite.WriteLine(vcaption)
        vrowcnt = 6
    End Sub
    Public Function Getconnection() As String
        Try
            If Trim(gserver & "") <> "" Then
                sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & strDataSqlUsr & "; pwd=" & strDataSqlPwd & "; Initial Catalog= " & gDatabase & ";"
            Else
                sqlconnection = "Data Source=(local):Persist Security Info=False;User ID=" & strDataSqlUsr & "; pwd=" & strDataSqlPwd & "; Initial Catalog= " & gDatabase & ";"
            End If

            Return sqlconnection
        Catch ex As Exception
            'MessageBox.Show("!! Warning !!Your system is not connected with SERVER, Bcoz " & ex.Message.ToString, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Function
        End Try
    End Function
    Function getvalue(ByVal QryString As String)
        Dim objVariable As Object
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            Cmd.Connection = Myconn
            Cmd.CommandTimeout = 1000000
            Cmd.CommandText = QryString
            Cmd.CommandType = CommandType.Text
            objVariable = Cmd.ExecuteScalar()
            Myconn.Close()
            Return objVariable
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing records : " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            Myconn.Close()
        End Try
    End Function
    Public Function getDataSet(ByVal strSQL As String, ByVal Tabname As String)
        Dim dt As New DataTable
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If

            gadapter = New SqlDataAdapter(strSQL, Myconn)
            gadapter.SelectCommand.CommandTimeout = 1000000
            gadapter.Fill(dt)

            dt.TableName = Tabname
            If gdataset.Tables.Contains(Tabname) = True Then
                gdataset.Tables.Remove(Tabname)
            End If
            gdataset.Tables.Add(dt)
        Catch ex As Exception
            MessageBox.Show("Error in retrieving records :" & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Function getCompanyinfo(ByVal strSQL As String, ByVal Tabname As String)
        Dim dt As New DataTable
        Try
            Call GetfrontConnection()
            gadapter = New SqlDataAdapter(strSQL, Myconn)
            gadapter.SelectCommand.CommandTimeout = 1000000
            gadapter.Fill(dt)
            dt.TableName = Tabname
            If gdataset.Tables.Contains(Tabname) = True Then
                gdataset.Tables.Remove(Tabname)
            End If
            gdataset.Tables.Add(dt)
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Function MoreTrans2(ByVal str() As String)
        Dim i As Integer
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.CommandTimeout = 1000000
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            '  MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function

    Public Function MoreTrans(ByVal str() As String)
        Dim i As Integer
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.CommandTimeout = 1000000
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            MessageBox.Show("Transaction Completed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Sub dataOperation(ByVal genum As Integer, ByVal ssql As String, Optional ByVal Tabname As String = "MyTable")
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            gtrans = Myconn.BeginTransaction
            Select Case genum
                '''****************************** $ Insert record into Database $ **************************'''
            Case 1
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 1000000
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Saved Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Update record into Database $ *************************'''
                Case 2
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 1000000
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Updated Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Freeze record into Database $ **************************'''
                Case 3
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 1000000
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Freezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''***************************** $ UnFreezed record into Database $ ************************'''
                Case 4
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.Transaction = gtrans
                    gcommand.CommandTimeout = 1000000
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
                    MessageBox.Show("Record Unfreezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 5
                    '****************************** $ Always Give Full Select Statement without Any Condition $ *******'''
                    gadapter.SelectCommand.CommandTimeout = 10000000
                    gadapter = New SqlDataAdapter(ssql, Myconn)
                    If gdataset.Tables.Contains(Tabname) = True Then
                        gdataset.Tables.Remove(Tabname)
                    End If
                    gadapter.Fill(gdataset.Tables(Tabname))
                    gtrans.Commit()
                Case 6
                    gcommand = New SqlCommand(ssql, Myconn)
                    gcommand.CommandTimeout = 1000000
                    gcommand.Transaction = gtrans
                    gcommand.ExecuteNonQuery()
                    gtrans.Commit()
            End Select
        Catch ex As Exception
            gtrans.Rollback()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            closeConnection()
        End Try
    End Sub
    Public Sub openConnection()
        Try
            If Trim(gserver & "") <> "" Then
                sqlconnection = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & strDataSqlUsr & "; pwd=" & strDataSqlPwd & "; Initial Catalog= " & gDatabase & ";"
            Else
                sqlconnection = "Data Source= (local);Persist Security Info=False;User ID=" & strDataSqlUsr & "; pwd=" & strDataSqlPwd & "; Initial Catalog= " & gDatabase & ";"
            End If
            Myconn.ConnectionString = sqlconnection
            Myconn.Open()
        Catch ex As Exception
            MessageBox.Show("!! Warning !!Your system is not connected with SERVER", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub GetfrontConnection()
        Try
            If Trim(gserver & "") <> "" Then
                sqlconnection1 = "Data Source=" & gserver & ";Persist Security Info=False;User ID=" & strDataSqlUsr & "; pwd=" & strDataSqlPwd & "; Initial Catalog= MASTER;"
            Else
                sqlconnection1 = "Data Source= (local);Persist Security Info=False;User ID=" & strDataSqlUsr & "; pwd=" & strDataSqlPwd & "; Initial Catalog= MASTER;"
            End If
            Myconn.ConnectionString = sqlconnection1
            Myconn.Open()
        Catch ex As Exception
            MessageBox.Show("!! Warning !!Your system is not connected with SERVER", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
    End Sub
    Public Sub closeConnection()
        Myconn.Close()
    End Sub
    Public Function GetValues(ByVal ssql As String) As DataTable
        Dim Dt As New DataTable
        Dim Sqladapter As New SqlDataAdapter(ssql, Myconn)
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            Sqladapter.SelectCommand.CommandTimeout = 1000000
            Sqladapter.Fill(Dt)
            Return Dt
        Catch ex As Exception
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        Finally
            closeConnection()
        End Try
    End Function
    Public Function ExcuteStoreProcedure(ByVal qry As String)
        Dim i As Integer
        Myconn.ConnectionString = sqlconnection
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.Connection = Myconn
            Cmd.CommandTimeout = 1000000
            Cmd.CommandText = qry
            Cmd.CommandType = CommandType.Text
            Cmd.ExecuteNonQuery()
            MyTrans.Commit()
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function

    Public Function MoreTrans1(ByVal str() As String)
        Dim i As Integer
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Cmd.Transaction = MyTrans
            Cmd.CommandTimeout = 1000000
            Cmd.Connection = Myconn
            For i = 0 To str.Length - 1
                If str(i) Is Nothing = False Then
                    Cmd.CommandText = str(i)
                    Cmd.CommandType = CommandType.Text
                    Cmd.ExecuteNonQuery()
                End If
            Next i
            MyTrans.Commit()
            Myconn.Close()
        Catch ex As Exception
            MyTrans.Rollback()
            Myconn.Close()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Function
        End Try
    End Function
    Public Sub dataOperation1(ByVal genum As Integer, ByVal STR() As String)
        Dim I As Integer
        Try
            If Myconn.State <> ConnectionState.Open Then
                openConnection()
            End If
            MyTrans = Myconn.BeginTransaction()
            Select Case genum
                Case 1
                    Cmd.Transaction = MyTrans
                    Cmd.Connection = Myconn
                    Cmd.CommandTimeout = 1000000
                    For I = 0 To STR.Length - 1
                        If STR(I) Is Nothing = False Then
                            Cmd.CommandText = STR(I)
                            Cmd.CommandType = CommandType.Text
                            Cmd.ExecuteNonQuery()
                        End If
                    Next I
                    MyTrans.Commit()
                    MessageBox.Show("Record Saved Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 2
                    Cmd.Transaction = MyTrans
                    Cmd.CommandTimeout = 1000000
                    Cmd.Connection = Myconn
                    For I = 0 To STR.Length - 1
                        If STR(I) Is Nothing = False Then
                            Cmd.CommandText = STR(I)
                            Cmd.CommandType = CommandType.Text
                            Cmd.ExecuteNonQuery()
                        End If
                    Next I
                    MyTrans.Commit()
                    MessageBox.Show("Record Updated Successfully ", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''**************************** $ Freeze record into Database $ **************************'''
                Case 3
                    Cmd.Transaction = MyTrans
                    Cmd.CommandTimeout = 1000000
                    Cmd.Connection = Myconn
                    For I = 0 To STR.Length - 1
                        If STR(I) Is Nothing = False Then
                            Cmd.CommandText = STR(I)
                            Cmd.CommandType = CommandType.Text
                            Cmd.ExecuteNonQuery()
                        End If
                    Next I
                    MyTrans.Commit()
                    MessageBox.Show("Record Freezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''***************************** $ UnFreezed record into Database $ ************************'''
                Case 4
                    Cmd.Transaction = MyTrans
                    Cmd.CommandTimeout = 1000000
                    Cmd.Connection = Myconn
                    For I = 0 To STR.Length - 1
                        If STR(I) Is Nothing = False Then
                            Cmd.CommandText = STR(I)
                            Cmd.CommandType = CommandType.Text
                            Cmd.ExecuteNonQuery()
                        End If
                    Next I
                    MyTrans.Commit()
                    MessageBox.Show("Record Unfreezed Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Case 5
                    Cmd.Transaction = MyTrans
                    Cmd.CommandTimeout = 1000000
                    Cmd.Connection = Myconn
                    For I = 0 To STR.Length - 1
                        If STR(I) Is Nothing = False Then
                            Cmd.CommandText = STR(I)
                            Cmd.CommandType = CommandType.Text
                            Cmd.ExecuteNonQuery()
                        End If
                    Next I
                    MyTrans.Commit()
                Case 6
                    Cmd.Transaction = MyTrans
                    Cmd.CommandTimeout = 1000000
                    Cmd.Connection = Myconn
                    For I = 0 To STR.Length - 1
                        If STR(I) Is Nothing = False Then
                            Cmd.CommandText = STR(I)
                            Cmd.CommandType = CommandType.Text
                            Cmd.ExecuteNonQuery()
                        End If
                    Next I
                    MyTrans.Commit()
                Case 7
                    Cmd.Transaction = MyTrans
                    Cmd.CommandTimeout = 1000000
                    Cmd.Connection = Myconn
                    For I = 0 To STR.Length - 1
                        If STR(I) Is Nothing = False Then
                            Cmd.CommandText = STR(I)
                            Cmd.CommandType = CommandType.Text
                            Cmd.ExecuteNonQuery()
                        End If
                    Next I
                    MyTrans.Commit()
                    MessageBox.Show("Record Cancelled Successfully", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information)


            End Select


        Catch ex As Exception
            MyTrans.Rollback()
            MessageBox.Show("Error in Retriveing Data as " & ex.Message, MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        Finally
            closeConnection()
        End Try
    End Sub
    Public Function FileInfo(ByVal MyFilePath As String)
        If File.Exists(MyFilePath) Then

            Dim MyFile As New FileInfo(MyFilePath)
            Filepath = MyFilePath
            FileSize = MyFile.Length
            dtCreationDate = MyFile.CreationTime
            dtLastAccessTime = MyFile.LastAccessTime
            dtLastWriteTime = MyFile.LastWriteTime
        End If
    End Function
    Public Sub FocusSetting(ByVal parentCtr As Control)

        Dim ctr As Control

        For Each ctr In parentCtr.Controls

            'ctr.Text &= ctr.Name & vbCrLf

            If TypeOf ctr Is TextBox Or TypeOf ctr Is ListBox Or TypeOf ctr Is ComboBox Then



                AddHandler ctr.GotFocus, AddressOf GotFocusHandling
                AddHandler ctr.LostFocus, AddressOf LostFocusHandling



            End If
            If TypeOf ctr Is Button Then
                AddHandler ctr.GotFocus, AddressOf GotFocusHandlingbtn
                AddHandler ctr.LostFocus, AddressOf LostFocusHandlingbtn

            End If



            If TypeOf ctr Is GroupBox Then 'FOR nested containers



                Dim CTRL As Control



                For Each CTRL In ctr.Controls



                    If TypeOf CTRL Is TextBox Or TypeOf CTRL Is ListBox Or TypeOf CTRL Is ComboBox Then



                        AddHandler CTRL.GotFocus, AddressOf GotFocusHandling



                        AddHandler CTRL.LostFocus, AddressOf LostFocusHandling



                    End If

                    If TypeOf CTRL Is Button Then
                        AddHandler CTRL.GotFocus, AddressOf GotFocusHandlingbtn
                        AddHandler CTRL.LostFocus, AddressOf LostFocusHandlingbtn

                    End If

                Next

            End If



        Next



    End Sub
    'Private Sub FocusSetting(ByVal parentCtr As Control)
    '    Dim ctr As Control
    '    For Each ctr In parentCtr.Controls
    '        ' set Text/List/Combo Boxs only
    '        If TypeOf ctr Is TextBox OrElse TypeOf ctr Is ListBox OrElse TypeOf ctr Is ComboBox Then
    '            AddHandler ctr.GotFocus, AddressOf GotFocusHandling
    '            AddHandler ctr.LostFocus, AddressOf LostFocusHandling
    '        End If
    '    Next
    'End Sub
    Private Sub GotFocusHandling(ByVal sender As Object, ByVal e As System.EventArgs)
        DirectCast(sender, Control).BackColor = Color.White ' gotfocus - change control backcolor to Yellow
    End Sub

    Private Sub LostFocusHandling(ByVal sender As Object, ByVal e As System.EventArgs)
        DirectCast(sender, Control).BackColor = Color.Wheat ' lostfocus - reset control backcolor to sys.win.color
    End Sub
    Private Sub GotFocusHandlingbtn(ByVal sender As Object, ByVal e As System.EventArgs)
        DirectCast(sender, Control).ForeColor = Color.DeepPink ' gotfocus - change control backcolor to Yellow
    End Sub

    Private Sub LostFocusHandlingbtn(ByVal sender As Object, ByVal e As System.EventArgs)
        DirectCast(sender, Control).ForeColor = Color.White  ' lostfocus - reset control backcolor to sys.win.color
    End Sub

End Class
