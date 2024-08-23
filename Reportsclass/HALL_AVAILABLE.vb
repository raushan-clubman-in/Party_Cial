Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System
Public Class HALL_AVAILABLE
    Dim pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Dim dt, dt1 As New DataTable
    Dim ds As New DataSet
    Dim ssql As String
    Dim I, J, SNO As Integer
    Public Function BOOKINGDETAILS(ByVal pageheading() As String, ByVal SQLSTRING As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim HallCode As String
        Dim D1, d2 As DateTime
        Dim FDAY, TDAY, DAYS As Integer
        D1 = mskfromdate
        d2 = msktodate
        DAYS = DateDiff(DateInterval.Day, D1, d2)
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1 : pagesize = 1
            pagesize = pagesize + 1
            Filewrite.WriteLine(Chr(15))
            Call PrintHeader(pageheading, mskfromdate, msktodate)
            D1 = mskfromdate
            For I = 0 To DAYS
                If pagesize > 58 Then
                    Filewrite.Write(StrDup(135, "-"))
                    pagesize = pagesize + 1
                    Filewrite.Write(Chr(12))
                    pageno = pageno + 1
                    Call PrintHeader(pageheading, mskfromdate, msktodate)
                End If
                ssql = "DATE :" & Format("dd/MM/yyyy", D1)
                Filewrite.WriteLine(ssql)
                Filewrite.WriteLine("--------------------")
                dt = gconnection.GetValues(SQLSTRING)
                If dt.Rows.Count > 0 Then
                    SNO = 1
                    For J = 0 To dt.Rows.Count - 1
                        If pagesize > 58 Then
                            Filewrite.Write(StrDup(135, "-"))
                            pagesize = pagesize + 1
                            Filewrite.Write(Chr(12))
                            pageno = pageno + 1
                            Call PrintHeader(pageheading, mskfromdate, msktodate)
                        End If
                        Filewrite.Write(Mid(SNO, 1, 5) & Space(5 - Len(Mid(SNO, 1, 5))))
                        Filewrite.Write("")
                        'ssql = " select * from Party_HallBooking_Det where partydate='" & Format(D1, "dd/MMM/yyyy") & "' and hallcode='" & dt.Rows(J).Item("hallcode") & "'"
                        'dt1 = gconnection.GetValues(ssql)

                        'ssql = Mid(SNO, 1, 5) & Space(5 - Len(Mid(SNO, 1, 5)))
                        'ssql = ssql & Mid(Trim(dt.Rows(J).Item("Hallcode")), 1, 10) & Space(10 - Len(Mid(Trim(dt.Rows(J).Item("Hallcode")), 1, 10)))
                        'ssql = ssql & Mid(Trim(dt.Rows(J).Item("Halldescription")), 1, 30) & Space(30 - Len(Mid(Trim(dt.Rows(J).Item("Halldescription")), 1, 30)))
                        'ssql = ssql & Mid(Trim(dt.Rows(J).Item("Halltype")), 1, 10) & Space(10 - Len(Mid(Trim(dt.Rows(J).Item("Halltype")), 1, 10)))
                        'If dt1.Rows.Count = 0 Then
                        '    ssql = ssql & Mid(Trim("AVAILABLE"), 1, 15) & Space(15 - Len(Mid(Trim(" AVAILABLE"), 1, 15)))
                        'Else
                        '    ssql = ssql & Mid(Trim("NOT AVAILABLE"), 1, 15) & Space(15 - Len(Mid(Trim("NOT AVAILABLE"), 1, 15)))
                        'End If
                        Filewrite.WriteLine(ssql)
                        pagesize = pagesize + 1
                        SNO = SNO + 1

                    Next
                Else
                    MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                    Exit Function
                End If
                D1 = CDate(D1).AddDays(1)
            Next
            Filewrite.WriteLine(StrDup(135, "-") & Chr(12))
            Filewrite.Close()
            If gPrint = False Then
                OpenTextFile(vOutfile)
            Else
                PrintTextFile1(VFilePath)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & ex.Source & ex.ToString)
            Exit Function
        End Try
    End Function
    Private Function PrintHeader(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.Write(Chr(15))
            Filewrite.WriteLine("{0,80}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", "01-04-" & gFinancalyearStart & " TO 31-03-" & gFinancialYearEnd)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,64}{1,-10}", " ", "DETAILS")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(135, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-5}{1,-10}{2,-30}{3,-10}{4,-15}", "SNO", "HALLCODE", "DESCRIPTION", "HALLTYPE", "AVAILABILITY")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(135, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
End Class

