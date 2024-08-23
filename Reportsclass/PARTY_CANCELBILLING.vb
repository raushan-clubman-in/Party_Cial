Imports System.Data.SqlClient
Imports System.IO
Public Class PARTY_CANCELBILLING
    Dim pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Dim dt, DT1 As New DataTable
    Dim ds As New DataSet
    Dim ssql As String
    Dim I, J, SNO, k As Integer
    Public Function ReportDetails(ByVal Billno As String, ByVal Billtype As String)
        Try
            Dim Arrtaxamount, Arramount, Arrtotalamount, Arrcancelamount As Double
            Dim Restaxamount, Resamount, Restotalamount, Rescancelamount As Double
            Dim Halltaxamount, Hallamount, Halltotalamount, ADVANCE, Totalamount, Hallcancelamount As Double
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath
            pageno = 1 : pagesize = 1
            ssql = "SELECT BOOKINGDATE,PARTYDATE,HALLTYPE,MCODE,MNAME,ASSOCIATENAME,ADVANCE,RECEIPTNO,RECEIPTDATE,"
            ssql = ssql & " HALLCODE,HALLAMOUNT,HALLTAXAMOUNT,HALLCANCELAMOUNT,"
            ssql = ssql & " OCCUPANCY,DESCRIPTION,HALLTAXFLAG,ADDUSERID,ADDDATETIME,FREEZE,HALLDESCRIPTION"
            ssql = ssql & " FROM VIEW_PARTY_HDR "
            ssql = ssql & " WHERE BOOKINGTYPE='" & Billtype & "' AND BOOKINGNO=" & Billno
            dt = gconnection.GetValues(ssql)
            pagesize = 0
            If dt.Rows.Count > 0 Then
                Filewrite.WriteLine(Chr(18) & Chr(27) + "E")
                Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
                Filewrite.WriteLine("|" & Space(30) & Chr(18) & Mid(Trim(Billtype), 1, 10) & Space(10 - Len(Mid(Trim(Billtype), 1, 10))) & Space(38) & "|")
                Filewrite.WriteLine("|" & Space(79) & "|")
                Filewrite.WriteLine("|" & Space(79) & "|")
                Filewrite.Write("|" & Space(2) & "MCODE         :" & Mid(dt.Rows(0).Item("MCODE"), 1, 7) & Space(7 - Len(Mid(dt.Rows(0).Item("MCODE"), 1, 7))))
                Filewrite.WriteLine(Space(11) & "MNAME :" & Mid(dt.Rows(0).Item("MNAME"), 1, 30) & Space(30 - Len(Mid(dt.Rows(0).Item("MNAME"), 1, 30))) & Space(7) & "|")
                Filewrite.WriteLine("|" & Space(79) & "|")
                Filewrite.Write("|" & Space(2) & Trim(Billtype) & " NO    :" & Mid(Billno, 1, 7) & Space(7 - Len(Mid(Billno, 1, 7))))
                Filewrite.WriteLine(Space(11) & Trim(Billtype) & " DATE :" & Mid(Format(dt.Rows(0).Item("bookingdate"), "dd/MM/yyyy"), 1, 10) & Space(10 - Len(Mid(Format(dt.Rows(0).Item("bookingdate"), "dd/MM/yyyy"), 1, 10))) & Space(22) & "|")
                Filewrite.WriteLine("|" & Space(79) & "|")

                Filewrite.Write("|" & Space(2) & "FUNCTION DATE :" & Mid(Format(dt.Rows(0).Item("PARTYDATE"), "dd/MM/yyyy"), 1, 10) & Space(10 - Len(Mid(Format(dt.Rows(0).Item("PARTYDATE"), "dd/MM/yyyy"), 1, 10))))

                Filewrite.WriteLine(Space(8) & "ASSOCIATE MNAME:" & Mid(dt.Rows(0).Item("ASSOCIATENAME"), 1, 27) & Space(27 - Len(Mid(dt.Rows(0).Item("ASSOCIATENAME"), 1, 27))) & Space(1) & "|")
                Filewrite.WriteLine("|" & Space(79) & "|")

                Filewrite.Write("|" & Space(2) & "HALLCODE      :" & Mid(dt.Rows(0).Item("HALLCODE"), 1, 7) & Space(7 - Len(Mid(dt.Rows(0).Item("HALLCODE"), 1, 7))))
                Filewrite.WriteLine(Space(11) & "HALL NAME :" & Mid(dt.Rows(0).Item("HALLDESCRIPTION"), 1, 30) & Space(30 - Len(Mid(dt.Rows(0).Item("HALLDESCRIPTION"), 1, 30))) & Space(3) & "|")
                Filewrite.WriteLine("|" & Space(79) & "|")
                Hallamount = dt.Rows(I).Item("HALLAMOUNT")
                Halltaxamount = dt.Rows(I).Item("HALLTAXAMOUNT")
                ADVANCE = dt.Rows(I).Item("ADVANCE")
                Halltotalamount = Halltaxamount + Hallamount
                Hallcancelamount = dt.Rows(I).Item("Hallcancelamount")
                ssql = "|  HALL AMOUNT :" & Space(9 - Len(Mid(Format(Hallamount, "0.00"), 1, 9))) & Mid(Format(Hallamount, "0.00"), 1, 9)
                ssql = ssql & Space(5) & "TAX AMOUNT :" & Space(9 - Len(Mid(Format(Halltaxamount, "0.00"), 1, 9))) & Mid(Format(Halltaxamount, "0.00"), 1, 8)
                ssql = ssql & Space(5) & "TOTALAMOUNT:" & Space(11 - Len(Mid(Format(Halltotalamount, "0.00"), 1, 11))) & Mid(Format(Halltotalamount, "0.00"), 1, 11) & Space(1) & "|"
                Filewrite.WriteLine(ssql)
                Filewrite.WriteLine("|" & Space(79) & "|")
                ssql = "|" & Space(52) & "CANCEL AMOUNT :" & Space(6) & Space(8 - Len(Mid(Format(Hallcancelamount, "0.00"), 1, 9))) & Mid(Format(Halltaxamount, "0.00"), 1, 8) & Space(1) & "|"
                Filewrite.WriteLine(ssql)
                Filewrite.WriteLine("|" & Space(79) & "|")
                ssql = "SELECT RECEIPTNO,RECEIPTDATE,adddatetime,amount"
                ssql = ssql & " FROM party_receipt "
                ssql = ssql & " WHERE BOOKINGNO=" & Billno
                DT1 = gconnection.GetValues(ssql)
                If DT1.Rows.Count > 0 Then
                    For k = 0 To DT1.Rows.Count - 1
                        ssql = "|" & Space(2) & "RECEIPT NO  :" & Space(13 - Len(Mid(Format(DT1.Rows(k).Item("RECEIPTNO"), ""), 1, 13))) & Mid(DT1.Rows(k).Item("RECEIPTNO"), 1, 13)
                        ssql = ssql & Space(1) & "RECEIPT DATE :" & Space(10 - Len(Mid(Format(DT1.Rows(k).Item("adddatetime"), "dd/MM/yyyy"), 1, 10))) & Mid(Format(DT1.Rows(k).Item("adddatetime"), "dd/MM/yyyy"), 1, 10)
                        ssql = ssql & Space(1) & " RECEIPT     :" & Space(11 - Len(Mid(Format(DT1.Rows(k).Item("amount"), "0.00"), 1, 11))) & Mid(Format(DT1.Rows(k).Item("amount"), "0.00"), 1, 11) & Space(1) & "|"
                        Filewrite.WriteLine(ssql)
                    Next
                End If
                ssql = "|" & Space(54) & " TOTAL RECEIPT    :" & Space(11 - Len(Mid(Format(ADVANCE_ANOUNT(Billno), "0.00"), 1, 11))) & Mid(Format(ADVANCE_ANOUNT(Billno), "0.00"), 1, 11) & Space(1) & "|"
                Filewrite.WriteLine(ssql)

                Filewrite.WriteLine("|" & Space(79) & "|")
                Filewrite.WriteLine("|" & Space(30) & Chr(18) & Mid(dt.Rows(0).Item("HALLTYPE"), 1, 30) & Space(30 - Len(Mid(dt.Rows(0).Item("HALLTYPE"), 1, 30))) & Space(18) & "|")
                Filewrite.WriteLine("|" & Space(79) & "|")
                Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
                'Hallfacility
                pagesize = 13
                Call Hallfacility_Heading()
                ssql = "SELECT ITEMDESCRIPTION,UOM,QTY,BOOKINGTYPE,BOOKINGNO,HALLCODE FROM VIEW_PARTY_HALLFACILITY "
                ssql = ssql & " WHERE BOOKINGTYPE='" & Billtype & "' AND BOOKINGNO=" & Billno
                dt = gconnection.GetValues(ssql)
                SNO = 1
                If dt.Rows.Count > 0 Then
                    For I = 0 To dt.Rows.Count - 1
                        ssql = "|" & Space(2) & Mid(SNO, 1, 4) & Space(4 - Len(Mid(SNO, 1, 4)))
                        ssql = ssql & "|" & Mid(dt.Rows(I).Item("ITEMDESCRIPTION"), 1, 35) & Space(35 - Len(Mid(dt.Rows(I).Item("ITEMDESCRIPTION"), 1, 35)))
                        ssql = ssql & "|" & Mid(dt.Rows(I).Item("UOM"), 1, 10) & Space(10 - Len(Mid(dt.Rows(I).Item("UOM"), 1, 10)))
                        ssql = ssql & "|" & Space(7 - Len(Mid(Format(dt.Rows(I).Item("QTY"), "0"), 1, 10))) & Mid(Format(dt.Rows(I).Item("QTY"), "0"), 1, 10) & Space(18) & "|"
                        Filewrite.WriteLine(ssql)
                        SNO = SNO + 1
                        If pagesize > 55 Then
                            Filewrite.WriteLine("|" & StrDup(79, "-") & "|" & Chr(12))
                            Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
                            Filewrite.WriteLine("|" & Space(30) & Chr(18) & Mid(Trim(Billtype), 1, 10) & Space(10 - Len(Mid(Trim(Billtype), 1, 10))) & Space(38) & "|")
                            pagesize = 0
                            Call Hallfacility_Heading()
                        End If
                        pagesize = pagesize + 1
                    Next
                End If
                'ARRANGEMENT DETAILS
                Call Arrangement_Heading()
                ssql = "  SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,ITEMDESCRIPTION,UOM,QTY,RATE,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,camount "
                ssql = ssql & " FROM VIEW_PARTY_ARRANGEMENT WHERE  BOOKINGTYPE='" & Billtype & "' AND BOOKINGNO=" & Billno
                dt = gconnection.GetValues(ssql)
                SNO = 1
                Arramount = 0
                Arrtaxamount = 0
                Arrtotalamount = 0
                Arrcancelamount = 0
                If dt.Rows.Count > 0 Then
                    For I = 0 To dt.Rows.Count - 1
                        ssql = "|" & Mid(SNO, 1, 4) & Space(4 - Len(Mid(SNO, 1, 4)))
                        ssql = ssql & "|" & Mid(dt.Rows(I).Item("ITEMDESCRIPTION"), 1, 21) & Space(21 - Len(Mid(dt.Rows(I).Item("ITEMDESCRIPTION"), 1, 21)))
                        ssql = ssql & "|" & Mid(dt.Rows(I).Item("UOM"), 1, 5) & Space(5 - Len(Mid(dt.Rows(I).Item("UOM"), 1, 5)))
                        ssql = ssql & "|" & Space(4 - Len(Mid(Format(dt.Rows(I).Item("QTY"), "0"), 1, 4))) & Mid(Format(dt.Rows(I).Item("QTY"), "0"), 1, 4) & Space(1)
                        ssql = ssql & "|" & Space(8 - Len(Mid(Format(dt.Rows(I).Item("Rate"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("Rate"), "0.00"), 1, 8)
                        ssql = ssql & "|" & Space(9 - Len(Mid(Format(dt.Rows(I).Item("taxamount"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("taxamount"), "0.00"), 1, 9)
                        ssql = ssql & "|" & Space(9 - Len(Mid(Format(dt.Rows(I).Item("amount"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("amount"), "0.00"), 1, 9)
                        'ssql = ssql & "|" & Space(11 - Len(Mid(Format(dt.Rows(I).Item("totalamount"), "0.00"), 1, 11))) & Mid(Format(dt.Rows(I).Item("Totalamount"), "0.00"), 1, 11) & "|"
                        ssql = ssql & "|" & Space(11 - Len(Mid(Format(dt.Rows(I).Item("camount"), "0.00"), 1, 11))) & Mid(Format(dt.Rows(I).Item("camount"), "0.00"), 1, 11) & "|"

                        Filewrite.WriteLine(ssql)
                        SNO = SNO + 1
                        Arramount = Arramount + dt.Rows(I).Item("Amount")
                        Arrtaxamount = Arrtaxamount + dt.Rows(I).Item("Taxamount")
                        Arrtotalamount = Arrtotalamount + dt.Rows(I).Item("Totalamount")
                        Arrcancelamount = Arrcancelamount + dt.Rows(I).Item("camount")
                        If pagesize > 55 Then
                            Filewrite.WriteLine("|" & StrDup(79, "-") & "|" & Chr(12))
                            Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
                            Filewrite.WriteLine("|" & Space(30) & Chr(18) & Mid(Trim(Billtype), 1, 10) & Space(10 - Len(Mid(Trim(Billtype), 1, 10))) & Space(38) & "|")
                            pagesize = 0
                            Call Arrangement_Heading()
                        End If
                        pagesize = pagesize + 1
                    Next
                End If
                Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
                ssql = "|" & Space(30) & "TOTAL AMOUNT" & Space(5)
                ssql = ssql & "|" & Space(9 - Len(Mid(Format(Arrtaxamount, "0.00"), 1, 9))) & Mid(Format(Arrtaxamount, "0.00"), 1, 9)
                ssql = ssql & "|" & Space(9 - Len(Mid(Format(Arramount, "0.00"), 1, 9))) & Mid(Format(Arramount, "0.00"), 1, 8)
                ssql = ssql & "|" & Space(11 - Len(Mid(Format(Arrcancelamount, "0.00"), 1, 11))) & Mid(Format(Arrcancelamount, "0.00"), 1, 11) & "|"
                Filewrite.WriteLine(ssql)
                'RESTAURANT ITEM
                Call Restaurant_Heading()
                ssql = " SELECT BOOKINGTYPE,BOOKINGNO,ITEMCODE,ITEMDESCRIPTION,UOM,QTY,RATE,TAXPERC,TAXAMOUNT,ROUNDOFF,AMOUNT,TOTALAMOUNT,CAMOUNT  FROM VIEW_PARTY_RESTAURANT"
                ssql = ssql & " WHERE  BOOKINGTYPE='" & Billtype & "' AND BOOKINGNO=" & Billno
                dt = gconnection.GetValues(ssql)
                Resamount = 0
                Restaxamount = 0
                Restotalamount = 0
                Rescancelamount = 0
                If dt.Rows.Count > 0 Then
                    For I = 0 To dt.Rows.Count - 1
                        ssql = "|" & Mid(SNO, 1, 4) & Space(4 - Len(Mid(SNO, 1, 4)))
                        ssql = ssql & "|" & Mid(dt.Rows(I).Item("ITEMDESCRIPTION"), 1, 21) & Space(21 - Len(Mid(dt.Rows(I).Item("ITEMDESCRIPTION"), 1, 21)))
                        ssql = ssql & "|" & Mid(dt.Rows(I).Item("UOM"), 1, 5) & Space(5 - Len(Mid(dt.Rows(I).Item("UOM"), 1, 5)))
                        ssql = ssql & "|" & Space(4 - Len(Mid(Format(dt.Rows(I).Item("QTY"), "0"), 1, 4))) & Mid(Format(dt.Rows(I).Item("QTY"), "0"), 1, 4) & Space(1)
                        ssql = ssql & "|" & Space(8 - Len(Mid(Format(dt.Rows(I).Item("Rate"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("Rate"), "0.00"), 1, 8)

                        ssql = ssql & "|" & Space(9 - Len(Mid(Format(dt.Rows(I).Item("taxamount"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("taxamount"), "0.00"), 1, 9)

                        ssql = ssql & "|" & Space(9 - Len(Mid(Format(dt.Rows(I).Item("amount"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("amount"), "0.00"), 1, 9)

                        '                        ssql = ssql & "|" & Space(11 - Len(Mid(Format(dt.Rows(I).Item("totalamount"), "0.00"), 1, 11))) & Mid(Format(dt.Rows(I).Item("Totalamount"), "0.00"), 1, 11) & "|"

                        ssql = ssql & "|" & Space(11 - Len(Mid(Format(dt.Rows(I).Item("camount"), "0.00"), 1, 11))) & Mid(Format(dt.Rows(I).Item("camount"), "0.00"), 1, 11) & "|"
                        Filewrite.WriteLine(ssql)
                        SNO = SNO + 1
                        Resamount = Resamount + dt.Rows(I).Item("Amount")
                        Restaxamount = Restaxamount + dt.Rows(I).Item("Taxamount")
                        Restotalamount = Restotalamount + dt.Rows(I).Item("Totalamount")
                        Rescancelamount = Rescancelamount + dt.Rows(I).Item("Camount")
                        If pagesize > 55 Then
                            Filewrite.WriteLine("|" & StrDup(79, "-") & "|" & Chr(12))
                            Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
                            Filewrite.WriteLine("|" & Space(30) & Chr(18) & Mid(Trim(Billtype), 1, 10) & Space(10 - Len(Mid(Trim(Billtype), 1, 10))) & Space(38) & "|")
                            pagesize = 0
                            Call Restaurant_Heading()
                        End If
                        pagesize = pagesize + 1
                    Next
                End If
                Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
                ssql = "|" & Space(30) & "TOTAL AMOUNT" & Space(5)
                ssql = ssql & "|" & Space(9 - Len(Mid(Format(Restaxamount, "0.00"), 1, 9))) & Mid(Format(Restaxamount, "0.00"), 1, 9)
                ssql = ssql & "|" & Space(9 - Len(Mid(Format(Resamount, "0.00"), 1, 9))) & Mid(Format(Resamount, "0.00"), 1, 8)
                ssql = ssql & "|" & Space(11 - Len(Mid(Format(Rescancelamount, "0.00"), 1, 11))) & Mid(Format(Rescancelamount, "0.00"), 1, 11) & "|"
                Filewrite.WriteLine(ssql)
                Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
                'Totalamount = Halltotalamount + Restotalamount + Arrtotalamount
                Totalamount = Hallcancelamount + Rescancelamount + Arrcancelamount

                ssql = "|" & Space(56) & "ADVANCE      :"
                ssql = ssql & Space(9 - Len(Mid(Format(ADVANCE_ANOUNT(Billno), "0.00"), 1, 9))) & Mid(Format(ADVANCE_ANOUNT(Billno), "0.00"), 1, 9) & "|"
                Filewrite.WriteLine(ssql)
                ssql = "|" & Space(49) & "TOTAL CANCEL AMOUNT :"
                ssql = ssql & Space(9 - Len(Mid(Format(Totalamount, "0.00"), 1, 9))) & Mid(Format(Totalamount, "0.00"), 1, 9) & "|"
                Filewrite.WriteLine(ssql)

                ssql = "|" & Space(57) & "RETURN BACK :"
                ssql = ssql & Space(9 - Len(Mid(Format((ADVANCE_ANOUNT(Billno) - Totalamount), "0.00"), 1, 9))) & Mid(Format((ADVANCE_ANOUNT(Billno) - Totalamount), "0.00"), 1, 9) & "|"
                Filewrite.WriteLine(ssql)
                Filewrite.WriteLine("|" & Space(79) & "|")
                Filewrite.WriteLine("|" & Space(2) & "Rupess :" & Mid(ConvertRupees((ADVANCE_ANOUNT(Billno) - Totalamount)), 1, 65) & Space(65 - Len(Mid(ConvertRupees((ADVANCE - Totalamount)), 1, 65))) & Space(4) & "|")
                Filewrite.WriteLine("|" & Space(79) & "|")
                Filewrite.WriteLine("|" & Space(79) & "|")
                Filewrite.WriteLine("|" & Space(79) & "|")
                Filewrite.WriteLine("|       Cashier                                           Accountant            |")
                Filewrite.WriteLine("|" & StrDup(79, "-") & "|" & Chr(12))
                Filewrite.Close()
            End If
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
    Private Sub Hallfacility_Heading()
        Filewrite.WriteLine("|" & Space(30) & Chr(18) & "HALL FACILITY" & Space(35) & "|")
        Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
        Filewrite.WriteLine("| SNO  |         FACILITY                  |   UOM    |  QTY    " & Space(16) & "|")
        Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
        pagesize = pagesize + 4
    End Sub
    Private Sub Arrangement_Heading()
        Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
        Filewrite.WriteLine("|" & Space(30) & Chr(18) & "ARRANGEMENT FACILITY" & Space(28) & "|")
        Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
        Filewrite.WriteLine("|SNO |         FACILITY    | UOM | QTY |   RATE |TAXAMOUNT| AMOUNT  |CANCEL_AMT |")
        Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
        pagesize = pagesize + 4
    End Sub
    Private Sub Restaurant_Heading()
        Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
        Filewrite.WriteLine("|" & Space(30) & Chr(18) & "RESTAURANT ITEM" & Space(33) & "|")
        Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
        Filewrite.WriteLine("|SNO |         FACILITY    | UOM | QTY |   RATE |TAXAMOUNT| AMOUNT  |CANCEL_AMT |")
        Filewrite.WriteLine("|" & StrDup(79, "-") & "|")
        pagesize = pagesize + 4
    End Sub
    Public Function ConvertRupees(ByVal Value As Double) As String
        Dim strText, TempString, TxtArray(5) As String
        Dim locNumber, AbsValue, DecimalValue, NumArray(5), Remain, Loopindex As Double
        NumArray(0) = 7
        NumArray(1) = 5
        NumArray(2) = 3
        NumArray(3) = 2
        TxtArray(0) = " CRORE"
        TxtArray(1) = " LAKH(S)"
        TxtArray(2) = " THOUSAND"
        TxtArray(3) = " HUNDRED"
        AbsValue = Value
        For Loopindex = 0 To 3
            locNumber = (AbsValue - (AbsValue Mod (10 ^ NumArray(Loopindex)))) / (10 ^ NumArray(Loopindex))
            If locNumber > 99 Then
                strText = strText & ConvertRupees(locNumber) & TxtArray(Loopindex)
                AbsValue = AbsValue - (locNumber * (10 ^ NumArray(Loopindex)))
            Else
                If locNumber <> 0 Then
                    If locNumber > 19 Then
                        strText = strText & NumValString(((locNumber - (locNumber Mod 10)) / 10) * 10) & NumValString(locNumber Mod 10) & TxtArray(Loopindex)
                    Else
                        strText = strText & NumValString(locNumber) & TxtArray(Loopindex)
                    End If
                    AbsValue = AbsValue - (locNumber * (10 ^ NumArray(Loopindex)))
                End If
            End If
        Next Loopindex
        If AbsValue <> 0 Then
            If AbsValue > 19 Then
                strText = strText & NumValString(((AbsValue - (AbsValue Mod 10)) / 10) * 10) & NumValString(AbsValue Mod 10) & TxtArray(Loopindex)
            Else
                strText = strText & NumValString(AbsValue)
            End If
        End If
        ConvertRupees = strText
    End Function
    Private Function NumValString(ByVal Value As Double)
        Select Case Value
            Case 1
                NumValString = " ONE"
            Case 2
                NumValString = " TWO"
            Case 3
                NumValString = " THREE"
            Case 4
                NumValString = " FOUR"
            Case 5
                NumValString = " FIVE"
            Case 6
                NumValString = " SIX"
            Case 7
                NumValString = " SEVEN"
            Case 8
                NumValString = " EIGHT"
            Case 9
                NumValString = " NINE"
            Case 10
                NumValString = " TEN"
            Case 11
                NumValString = " ELEVEN"
            Case 12
                NumValString = " TWELVE"
            Case 13
                NumValString = " THIRTEEN"
            Case 14
                NumValString = " FOURTEEN"
            Case 15
                NumValString = " FIFTEEN"
            Case 16
                NumValString = " SIXTEEN"
            Case 17
                NumValString = " SEVENTEEN"
            Case 18
                NumValString = " EIGHTEEN"
            Case 19
                NumValString = " NINETEEN"
            Case 20
                NumValString = " TWENTY"
            Case 30
                NumValString = " THIRTY"
            Case 40
                NumValString = " FOURTY"
            Case 50
                NumValString = " FIFTY"
            Case 60
                NumValString = " SIXTY"
            Case 70
                NumValString = " SEVENTY"
            Case 80
                NumValString = " EIGHTY"
            Case 90
                NumValString = " NINETY"
            Case Else
                NumValString = ""
        End Select
    End Function
    Function ADVANCE_ANOUNT(ByVal BILLNO As Integer) As Double
        ssql = "select isnull(sum(amount),0) as amount from party_receipt where bookingno=" & BILLNO
        DT1 = gconnection.GetValues(ssql)
        If DT1.Rows.Count > 0 Then
            Return DT1.Rows(0).Item("amount")
        Else
            Return 0
        End If
    End Function
End Class
