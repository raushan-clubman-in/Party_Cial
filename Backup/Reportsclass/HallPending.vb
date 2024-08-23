Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class HallPending
    Dim pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Dim dt, DT1 As New DataTable
    Dim ds As New DataSet
    Dim ssql As String
    Dim I, J, SNO As Integer
    Public Function BOOKINGDETAILS(ByVal pageheading() As String, ByVal SQLSTRING As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim HallCode As String
        Dim HALLAMOUNT, RESAMOUNT, ARRAMOUNT, ADVANCE, BALANCE, TOTBALANCE As Double
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1 : pagesize = 1
            dt = gconnection.GetValues(SQLSTRING)
            If dt.Rows.Count > 0 Then
                Filewrite.WriteLine(Chr(15))
                Call PrintHeader(pageheading, mskfromdate, msktodate)
                pagesize = pagesize + 1
                HallCode = ""
                SNO = 1
                HALLAMOUNT = 0 : RESAMOUNT = 0 : ARRAMOUNT = 0 : ADVANCE = 0 : TOTBALANCE = 0
                For I = 0 To dt.Rows.Count - 1
                    BALANCE = 0
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(135, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(pageheading, mskfromdate, msktodate)
                    End If
                    'If HallCode <> Trim(dt.Rows(I).Item("Hallcode")) Then
                    '    Filewrite.WriteLine(Chr(27) + "E" & "HallCode :" & Trim(dt.Rows(I).Item("Hallcode")) & " " & Trim(dt.Rows(I).Item("Halldescription")) & Chr(27) + "F")
                    'End If
                    ssql = Mid(SNO, 1, 5) & Space(5 - Len(Mid(SNO, 1, 5)))
                    ssql = ssql & Space(3) & Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 7) & Space(7 - Len(Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 7)))
                    ssql = ssql & Mid(Format(dt.Rows(I).Item("BOOKINGDATE"), "dd/MM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(dt.Rows(I).Item("BOOKINGDATE"), "dd/MM/yyyy"), 1, 11))) & Space(1)
                    ssql = ssql & Mid(Format(dt.Rows(I).Item("partydate"), "dd/MM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(dt.Rows(I).Item("partydate"), "dd/MM/yyyy"), 1, 11))) & Space(0)
                    ssql = ssql & Mid(dt.Rows(I).Item("MCODE"), 1, 7) & Space(7 - Len(Mid(dt.Rows(I).Item("MCODE"), 1, 7)))
                    ssql = ssql & Mid(dt.Rows(I).Item("MNAME"), 1, 30) & Space(30 - Len(Mid(dt.Rows(I).Item("MNAME"), 1, 30)))
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("hallamount"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("hallamount"), "0.00"), 1, 9) & Space(2)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("ARRMENTAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("ARRMENTAMOUNT"), "0.00"), 1, 9) & Space(2)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("RESTAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("RESTAMOUNT"), "0.00"), 1, 9) & Space(2)
                    ssql = ssql & Space(9 - Len(Mid(Format(ADVANCE_ANOUNT(dt.Rows(I).Item("BOOKINGNO")), "0.00"), 1, 9))) & Mid(Format(ADVANCE_ANOUNT(dt.Rows(I).Item("BOOKINGNO")), "0.00"), 1, 9) & Space(2)
                    HALLAMOUNT = HALLAMOUNT + dt.Rows(I).Item("hallamount")
                    RESAMOUNT = RESAMOUNT + dt.Rows(I).Item("RESTAMOUNT")
                    ARRAMOUNT = ARRAMOUNT + dt.Rows(I).Item("ARRMENTAMOUNT")
                    ADVANCE = ADVANCE + ADVANCE_ANOUNT(dt.Rows(I).Item("BOOKINGNO"))
                    BALANCE = (dt.Rows(I).Item("hallamount") + dt.Rows(I).Item("ARRMENTAMOUNT") + dt.Rows(I).Item("RESTAMOUNT")) - ADVANCE_ANOUNT(dt.Rows(I).Item("BOOKINGNO"))
                    TOTBALANCE = TOTBALANCE + BALANCE
                    ssql = ssql & Space(9 - Len(Mid(Format(BALANCE, "0.00"), 1, 9))) & Mid(Format(BALANCE, "0.00"), 1, 9) & Space(2)
                    Filewrite.WriteLine(ssql)
                    pagesize = pagesize + 1
                    SNO = SNO + 1
                Next
                Filewrite.WriteLine(StrDup(135, "-"))
                ssql = Space(75)
                ssql = ssql & Space(9 - Len(Mid(Format(HALLAMOUNT, "0.00"), 1, 9))) & Mid(Format(HALLAMOUNT, "0.00"), 1, 9) & Space(2)
                ssql = ssql & Space(9 - Len(Mid(Format(ARRAMOUNT, "0.00"), 1, 9))) & Mid(Format(ARRAMOUNT, "0.00"), 1, 9) & Space(2)
                ssql = ssql & Space(9 - Len(Mid(Format(RESAMOUNT, "0.00"), 1, 9))) & Mid(Format(RESAMOUNT, "0.00"), 1, 9) & Space(2)
                ssql = ssql & Space(9 - Len(Mid(Format(ADVANCE, "0.00"), 1, 9))) & Mid(Format(ADVANCE, "0.00"), 1, 9) & Space(2)
                ssql = ssql & Space(9 - Len(Mid(Format(TOTBALANCE, "0.00"), 1, 9))) & Mid(Format(TOTBALANCE, "0.00"), 1, 9) & Space(2)
                Filewrite.WriteLine(ssql)
                Filewrite.WriteLine(StrDup(135, "-") & Chr(12))
                Filewrite.Close()
                If gPrint = False Then
                    OpenTextFile(vOutfile)
                Else
                    PrintTextFile1(VFilePath)
                End If
            Else
                MessageBox.Show("NO RECORDS FOUND TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Function
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
            Filewrite.WriteLine("{0,-5}{1,-10}{2,-11}{3,-11}{4,-7}{5,-30}{6,-9}{7,-9}{8,-9}{9,-9}{10,-9}", "SNO", "BOOKINGNO", "BOOKINGDATE ", "PARTYDATE ", "MCODE", "MNAME", "HALLAMOUNT ", "ARR.AMOUNT ", "RES.AMOUNT ", "  ADVANCE ", " TOTAL_BAL ")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(135, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    Function ADVANCE_ANOUNT(ByVal BILLNO As Integer) As Double
        Dim SQL As String
        SQL = "select isnull(sum(amount),0) as amount from party_receipt where bookingno=" & BILLNO
        DT1 = gconnection.GetValues(SQL)
        If DT1.Rows.Count > 0 Then
            Return DT1.Rows(0).Item("amount")
        Else
            Return 0
        End If
    End Function
End Class
