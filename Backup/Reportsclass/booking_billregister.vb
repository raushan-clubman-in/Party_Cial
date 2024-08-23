Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Public Class booking_billregister
    Dim pageno, pagesize As Integer
    Dim gconnection As New GlobalClass
    Dim dr As DataRow
    Dim dt, DT1 As New DataTable
    Dim ds As New DataSet
    Dim ssql As String
    Dim I, J, SNO, CNO As Integer
    Public Function BOOKINGDETAILS_ADJUSTED(ByVal pageheading() As String, ByVal SQLSTRING As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal strhead As String)
        Dim PARTYDATE As Date
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath

            Dim TAMOUNT, SAMOUNT As Double

            pageno = 1 : pagesize = 1
            dt = gconnection.GetValues(SQLSTRING)
            If dt.Rows.Count > 0 Then
                Filewrite.WriteLine(Chr(15))
                Call PrintHeader_ADJUSTED(pageheading, mskfromdate, msktodate, strhead)
                pagesize = pagesize + 1
                SNO = 0 : CNO = 0
                TAMOUNT = 0 : SAMOUNT = 0
                For I = 0 To dt.Rows.Count - 1
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(240, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader_ADJUSTED(pageheading, mskfromdate, msktodate, strhead)
                    End If
                    SNO = SNO + 1
                    CNO = CNO + 1
                    ssql = Mid(SNO, 1, 4) & Space(4 - Len(Mid(SNO, 1, 4))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("MCODE"), 1, 10) & Space(10 - Len(Mid(dt.Rows(I).Item("MCODE"), 1, 10))) & Space(1)
                    ssql = ssql & Mid(Format(dt.Rows(I).Item("PARTYDATE"), "dd/MM/yyyy"), 1, 10) & Space(10 - Len(Mid(Format(dt.Rows(I).Item("PARTYDATE"), "dd/MM/yyyy"), 1, 10))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4) & Space(4 - Len(Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("RECEIPTNO"), 1, 20) & Space(20 - Len(Mid(dt.Rows(I).Item("RECEIPTNO"), 1, 20))) & Space(1)
                    ssql = ssql & Mid(Format(dt.Rows(I).Item("RECEIPTDATE"), "dd/MM/yyyy"), 1, 10) & Space(10 - Len(Mid(Format(dt.Rows(I).Item("RECEIPTDATE"), "dd/MM/yyyy"), 1, 10))) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("AMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("AMOUNT"), "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(ssql)
                    SAMOUNT = SAMOUNT + dt.Rows(I).Item("AMOUNT")
                    TAMOUNT = TAMOUNT + dt.Rows(I).Item("AMOUNT")
                    PARTYDATE = Trim(dt.Rows(I).Item("partydate"))
                    pagesize = pagesize + 1
                Next
                If TAMOUNT <> 0 Then
                    Filewrite.WriteLine(StrDup(79, "-"))
                    ssql = Mid(CNO, 1, 4) & Space(4 - Len(Mid(CNO, 1, 4))) & Space(33)
                    ssql = ssql & Space(9 - Len(Mid(Format(TAMOUNT, "0.00"), 1, 9))) & Mid(Format(TAMOUNT, "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(Space(7) & "    Total :" & Space(9) & ssql)
                    Filewrite.WriteLine(StrDup(79, "-"))
                End If
                Filewrite.Write(Chr(12))
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
    Public Function BOOKINGDETAILS_NOTADJUST(ByVal pageheading() As String, ByVal SQLSTRING As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal strhead As String)
        Dim PARTYDATE As Date
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath

            Dim TAMOUNT, SAMOUNT As Double

            pageno = 1 : pagesize = 1
            dt = gconnection.GetValues(SQLSTRING)
            If dt.Rows.Count > 0 Then
                Filewrite.WriteLine(Chr(15))
                Call PrintHeader_NOTADJUST(pageheading, mskfromdate, msktodate, strhead)
                pagesize = pagesize + 1
                SNO = 0 : CNO = 0
                TAMOUNT = 0 : SAMOUNT = 0
                For I = 0 To dt.Rows.Count - 1
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(240, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader_NOTADJUST(pageheading, mskfromdate, msktodate, strhead)
                    End If
                    SNO = SNO + 1
                    CNO = CNO + 1
                    ssql = Mid(SNO, 1, 4) & Space(4 - Len(Mid(SNO, 1, 4))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("MCODE"), 1, 10) & Space(10 - Len(Mid(dt.Rows(I).Item("MCODE"), 1, 10))) & Space(1)
                    ssql = ssql & Mid(Format(dt.Rows(I).Item("PARTYDATE"), "dd/MM/yyyy"), 1, 10) & Space(10 - Len(Mid(Format(dt.Rows(I).Item("PARTYDATE"), "dd/MM/yyyy"), 1, 10))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4) & Space(4 - Len(Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("RECEIPTNO"), 1, 20) & Space(20 - Len(Mid(dt.Rows(I).Item("RECEIPTNO"), 1, 20))) & Space(1)
                    ssql = ssql & Mid(Format(dt.Rows(I).Item("RECEIPTDATE"), "dd/MM/yyyy"), 1, 10) & Space(10 - Len(Mid(Format(dt.Rows(I).Item("RECEIPTDATE"), "dd/MM/yyyy"), 1, 10))) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("AMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("AMOUNT"), "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(ssql)
                    SAMOUNT = SAMOUNT + dt.Rows(I).Item("AMOUNT")
                    TAMOUNT = TAMOUNT + dt.Rows(I).Item("AMOUNT")
                    PARTYDATE = Trim(dt.Rows(I).Item("partydate"))
                    pagesize = pagesize + 1
                Next
                If TAMOUNT <> 0 Then
                    Filewrite.WriteLine(StrDup(79, "-"))
                    ssql = Mid(CNO, 1, 4) & Space(4 - Len(Mid(CNO, 1, 4))) & Space(33)
                    ssql = ssql & Space(9 - Len(Mid(Format(TAMOUNT, "0.00"), 1, 9))) & Mid(Format(TAMOUNT, "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(Space(7) & "    Total :" & Space(9) & ssql)
                    Filewrite.WriteLine(StrDup(79, "-"))
                End If
                Filewrite.Write(Chr(12))
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
    Public Function BOOKINGDETAILS_ACCOUNTS(ByVal pageheading() As String, ByVal SQLSTRING As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal strhead As String)
        Dim PARTYDATE As Date
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath

            Dim TBILAMT, TADVAMT, TBALAMT, TOCCUPANCY, TVENAMT, TDINAMT, TCHIAMT, THABAMT, TSOFAMT, TLIQAMT, TCIGAMT, TJUIAMT, TMUSAMT, TCOLAMT, THALAMT, TARKAMT, TMISAMT, TSTFAMT, TSERAMT, TVAT, TCONT, TGRANDAMT As Double
            Dim SBILAMT, SADVAMT, SBALAMT, SOCCUPANCY, SVENAMT, SDINAMT, SCHIAMT, SHABAMT, SSOFAMT, SLIQAMT, SCIGAMT, SJUIAMT, SMUSAMT, SCOLAMT, SHALAMT, SARKAMT, SMISAMT, SSTFAMT, SSERAMT, SVAT, SCONT, SGRANDAMT As Double

            pageno = 1 : pagesize = 1

            dt = gconnection.GetValues(SQLSTRING)
            If dt.Rows.Count > 0 Then
                Filewrite.WriteLine(Chr(15))
                Call PrintHeader_ACCOUNTS(pageheading, mskfromdate, msktodate, strhead)
                pagesize = pagesize + 1
                SNO = 0 : CNO = 0
                TBILAMT = 0 : TADVAMT = 0 : TBALAMT = 0 : TOCCUPANCY = 0 : TVENAMT = 0 : TDINAMT = 0 : TCHIAMT = 0 : THABAMT = 0 : TSOFAMT = 0 : TLIQAMT = 0 : TCIGAMT = 0 : TJUIAMT = 0 : TMUSAMT = 0 : TCOLAMT = 0 : THALAMT = 0 : TARKAMT = 0 : TMISAMT = 0 : TSTFAMT = 0 : TSERAMT = 0 : TVAT = 0 : TGRANDAMT = 0
                SBILAMT = 0 : SADVAMT = 0 : SBALAMT = 0 : SOCCUPANCY = 0 : SVENAMT = 0 : SDINAMT = 0 : SCHIAMT = 0 : SHABAMT = 0 : SSOFAMT = 0 : SLIQAMT = 0 : SCIGAMT = 0 : SJUIAMT = 0 : SMUSAMT = 0 : SCOLAMT = 0 : SHALAMT = 0 : SARKAMT = 0 : SMISAMT = 0 : SSTFAMT = 0 : SSERAMT = 0 : SVAT = 0 : SGRANDAMT = 0
                For I = 0 To dt.Rows.Count - 1
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(230, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader_ACCOUNTS(pageheading, mskfromdate, msktodate, strhead)
                    End If
                    SNO = SNO + 1
                    CNO = CNO + 1

                    ssql = Mid(SNO, 1, 3) & Space(3 - Len(Mid(SNO, 1, 3))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("MCODE"), 1, 8) & Space(8 - Len(Mid(dt.Rows(I).Item("MCODE"), 1, 8))) & Space(1)
                    ssql = ssql & Mid(Format(dt.Rows(I).Item("PARTYDATE"), "dd/MM/yyyy"), 1, 10) & Space(10 - Len(Mid(Format(dt.Rows(I).Item("PARTYDATE"), "dd/MM/yyyy"), 1, 10))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4) & Space(4 - Len(Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4))) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("BILAMT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("BILAMT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("ADVAMT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("ADVAMT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("BALAMT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("BALAMT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(4 - Len(Mid(Format(dt.Rows(I).Item("OCCUPANCY"), "0"), 1, 4))) & Mid(Format(dt.Rows(I).Item("OCCUPANCY"), "0"), 1, 4) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("VENAMT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("VENAMT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("DINAMT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("DINAMT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("CHIAMT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("CHIAMT"), "0.00"), 1, 9) & Space(1)

                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("HABAMT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("HABAMT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("SOFAMT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("SOFAMT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("LIQAMT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("LIQAMT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("CIGAMT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("CIGAMT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("JUIAMT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("JUIAMT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("MUSAMT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("MUSAMT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("COLAMT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("COLAMT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("HALAMT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("HALAMT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("ARKAMT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("ARKAMT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("MISAMT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("MISAMT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("STFAMT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("STFAMT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("SERAMT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("SERAMT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("VAT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("VAT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(dt.Rows(I).Item("CONT"), "0.00"), 1, 8))) & Mid(Format(dt.Rows(I).Item("CONT"), "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("GRANDAMT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("GRANDAMT"), "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(ssql)

                    SBILAMT = SBILAMT + dt.Rows(I).Item("BILAMT")
                    SADVAMT = SADVAMT + dt.Rows(I).Item("ADVAMT")
                    SBALAMT = SBALAMT + dt.Rows(I).Item("BALAMT")
                    SOCCUPANCY = SOCCUPANCY + dt.Rows(I).Item("OCCUPANCY")
                    SVENAMT = SVENAMT + dt.Rows(I).Item("VENAMT")
                    SDINAMT = SDINAMT + dt.Rows(I).Item("DINAMT")
                    SCHIAMT = SCHIAMT + dt.Rows(I).Item("CHIAMT")
                    SHABAMT = SHABAMT + dt.Rows(I).Item("HABAMT")
                    SSOFAMT = SSOFAMT + dt.Rows(I).Item("SOFAMT")
                    SLIQAMT = SLIQAMT + dt.Rows(I).Item("LIQAMT")
                    SCIGAMT = SCIGAMT + dt.Rows(I).Item("CIGAMT")
                    SJUIAMT = SJUIAMT + dt.Rows(I).Item("JUIAMT")
                    SMUSAMT = SMUSAMT + dt.Rows(I).Item("MUSAMT")
                    SCOLAMT = SCOLAMT + dt.Rows(I).Item("COLAMT")
                    SHALAMT = SHALAMT + dt.Rows(I).Item("HALAMT")
                    SARKAMT = SARKAMT + dt.Rows(I).Item("ARKAMT")
                    SMISAMT = SMISAMT + dt.Rows(I).Item("MISAMT")
                    SSTFAMT = SSTFAMT + dt.Rows(I).Item("STFAMT")
                    SSERAMT = SSERAMT + dt.Rows(I).Item("SERAMT")
                    SVAT = SVAT + dt.Rows(I).Item("VAT")
                    SCONT = SCONT + dt.Rows(I).Item("CONT")

                    SGRANDAMT = SGRANDAMT + dt.Rows(I).Item("GRANDAMT")

                    TBILAMT = TBILAMT + dt.Rows(I).Item("BILAMT")
                    TADVAMT = TADVAMT + dt.Rows(I).Item("ADVAMT")

                    TBALAMT = TBALAMT + dt.Rows(I).Item("BALAMT")
                    TOCCUPANCY = TOCCUPANCY + dt.Rows(I).Item("OCCUPANCY")
                    TVENAMT = TVENAMT + dt.Rows(I).Item("VENAMT")
                    TDINAMT = TDINAMT + dt.Rows(I).Item("DINAMT")
                    TCHIAMT = TCHIAMT + dt.Rows(I).Item("CHIAMT")
                    THABAMT = THABAMT + dt.Rows(I).Item("HABAMT")
                    TSOFAMT = TSOFAMT + dt.Rows(I).Item("SOFAMT")
                    TLIQAMT = TLIQAMT + dt.Rows(I).Item("LIQAMT")
                    TCIGAMT = TCIGAMT + dt.Rows(I).Item("CIGAMT")
                    TJUIAMT = TJUIAMT + dt.Rows(I).Item("JUIAMT")
                    TMUSAMT = TMUSAMT + dt.Rows(I).Item("MUSAMT")
                    TCOLAMT = TCOLAMT + dt.Rows(I).Item("COLAMT")
                    THALAMT = THALAMT + dt.Rows(I).Item("HALAMT")
                    TARKAMT = TARKAMT + dt.Rows(I).Item("ARKAMT")
                    TMISAMT = TMISAMT + dt.Rows(I).Item("MISAMT")
                    TSTFAMT = TSTFAMT + dt.Rows(I).Item("STFAMT")
                    TSERAMT = TSERAMT + dt.Rows(I).Item("SERAMT")
                    TVAT = TVAT + dt.Rows(I).Item("VAT")
                    TCONT = TCONT + dt.Rows(I).Item("CONT")
                    TGRANDAMT = TGRANDAMT + dt.Rows(I).Item("GRANDAMT")


                    PARTYDATE = Trim(dt.Rows(I).Item("partydate"))
                    pagesize = pagesize + 1
                Next
                If TGRANDAMT <> 0 Then
                    Filewrite.WriteLine(StrDup(230, "-"))
                    ssql = Mid(CNO, 1, 3) & Space(3 - Len(Mid(CNO, 1, 3))) & Space(1)

                    ssql = ssql & Space(9 - Len(Mid(Format(TBILAMT, "0.00"), 1, 9))) & Mid(Format(TBILAMT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TADVAMT, "0.00"), 1, 9))) & Mid(Format(TADVAMT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TBALAMT, "0.00"), 1, 9))) & Mid(Format(TBALAMT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(5 - Len(Mid(Format(TOCCUPANCY, "0"), 1, 5))) & Mid(Format(TOCCUPANCY, "0"), 1, 5) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TVENAMT, "0.00"), 1, 9))) & Mid(Format(TVENAMT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TDINAMT, "0.00"), 1, 9))) & Mid(Format(TDINAMT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TCHIAMT, "0.00"), 1, 9))) & Mid(Format(TCHIAMT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(THABAMT, "0.00"), 1, 8))) & Mid(Format(THABAMT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(TSOFAMT, "0.00"), 1, 8))) & Mid(Format(TSOFAMT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(TLIQAMT, "0.00"), 1, 8))) & Mid(Format(TLIQAMT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(TCIGAMT, "0.00"), 1, 8))) & Mid(Format(TCIGAMT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(TJUIAMT, "0.00"), 1, 8))) & Mid(Format(TJUIAMT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(TMUSAMT, "0.00"), 1, 8))) & Mid(Format(TMUSAMT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(TCOLAMT, "0.00"), 1, 8))) & Mid(Format(TCOLAMT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(THALAMT, "0.00"), 1, 8))) & Mid(Format(THALAMT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(TARKAMT, "0.00"), 1, 8))) & Mid(Format(TARKAMT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(TMISAMT, "0.00"), 1, 8))) & Mid(Format(TMISAMT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(TSTFAMT, "0.00"), 1, 8))) & Mid(Format(TSTFAMT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(TSERAMT, "0.00"), 1, 8))) & Mid(Format(TSERAMT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(TVAT, "0.00"), 1, 8))) & Mid(Format(TVAT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(8 - Len(Mid(Format(TCONT, "0.00"), 1, 8))) & Mid(Format(TCONT, "0.00"), 1, 8) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TGRANDAMT, "0.00"), 1, 9))) & Mid(Format(TGRANDAMT, "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(Space(4) & "    Total :" & Space(9) & ssql)
                    Filewrite.WriteLine(StrDup(230, "-"))
                End If
                Filewrite.Write(Chr(12))
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
    Public Function BOOKINGDETAILS_BALANCE(ByVal pageheading() As String, ByVal SQLSTRING As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal strhead As String)
        Dim PARTYDATE As Date
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath

            Dim TBILAMT, TADVAMT, TBALAMT, TOCCUPANCY, TVENAMT, TDINAMT, TCHIAMT, THABAMT, TSOFAMT, TLIQAMT, TCIGAMT, TJUIAMT, TMUSAMT, TCOLAMT, THALAMT, TARKAMT, TMISAMT, TSTFAMT, TSERAMT, TVAT, TCONT, TGRANDAMT As Double
            Dim SBILAMT, SADVAMT, SBALAMT, SOCCUPANCY, SVENAMT, SDINAMT, SCHIAMT, SHABAMT, SSOFAMT, SLIQAMT, SCIGAMT, SJUIAMT, SMUSAMT, SCOLAMT, SHALAMT, SARKAMT, SMISAMT, SSTFAMT, SSERAMT, SVAT, SCONT, SGRANDAMT As Double

            pageno = 1 : pagesize = 1
            dt = gconnection.GetValues(SQLSTRING)
            If dt.Rows.Count > 0 Then
                Filewrite.WriteLine(Chr(15))
                Call PrintHeader_BALANCE(pageheading, mskfromdate, msktodate, strhead)
                pagesize = pagesize + 1
                SNO = 0 : CNO = 0
                TBILAMT = 0 : TADVAMT = 0 : TBALAMT = 0 : TOCCUPANCY = 0 : TVENAMT = 0 : TDINAMT = 0 : TCHIAMT = 0 : THABAMT = 0 : TSOFAMT = 0 : TLIQAMT = 0 : TCIGAMT = 0 : TJUIAMT = 0 : TMUSAMT = 0 : TCOLAMT = 0 : THALAMT = 0 : TARKAMT = 0 : TMISAMT = 0 : TSTFAMT = 0 : TSERAMT = 0 : TVAT = 0 : TGRANDAMT = 0
                SBILAMT = 0 : SADVAMT = 0 : SBALAMT = 0 : SOCCUPANCY = 0 : SVENAMT = 0 : SDINAMT = 0 : SCHIAMT = 0 : SHABAMT = 0 : SSOFAMT = 0 : SLIQAMT = 0 : SCIGAMT = 0 : SJUIAMT = 0 : SMUSAMT = 0 : SCOLAMT = 0 : SHALAMT = 0 : SARKAMT = 0 : SMISAMT = 0 : SSTFAMT = 0 : SSERAMT = 0 : SVAT = 0 : SGRANDAMT = 0
                For I = 0 To dt.Rows.Count - 1
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(78, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader_BALANCE(pageheading, mskfromdate, msktodate, strhead)
                    End If
                    SNO = SNO + 1
                    CNO = CNO + 1
                    ssql = Mid(SNO, 1, 3) & Space(3 - Len(Mid(SNO, 1, 3))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("MCODE"), 1, 8) & Space(8 - Len(Mid(dt.Rows(I).Item("MCODE"), 1, 8))) & Space(1)
                    ssql = ssql & Mid(Format(dt.Rows(I).Item("PARTYDATE"), "dd/MM/yyyy"), 1, 10) & Space(10 - Len(Mid(Format(dt.Rows(I).Item("PARTYDATE"), "dd/MM/yyyy"), 1, 10))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4) & Space(4 - Len(Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4))) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("BILAMT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("BILAMT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("ADVAMT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("ADVAMT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("BALAMT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("BALAMT"), "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(ssql)

                    SBILAMT = SBILAMT + dt.Rows(I).Item("BILAMT")
                    SADVAMT = SADVAMT + dt.Rows(I).Item("ADVAMT")
                    SBALAMT = SBALAMT + dt.Rows(I).Item("BALAMT")
                    SOCCUPANCY = SOCCUPANCY + dt.Rows(I).Item("OCCUPANCY")
                    SVENAMT = SVENAMT + dt.Rows(I).Item("VENAMT")
                    SDINAMT = SDINAMT + dt.Rows(I).Item("DINAMT")
                    SCHIAMT = SCHIAMT + dt.Rows(I).Item("CHIAMT")
                    SHABAMT = SHABAMT + dt.Rows(I).Item("HABAMT")
                    SSOFAMT = SSOFAMT + dt.Rows(I).Item("SOFAMT")
                    SLIQAMT = SLIQAMT + dt.Rows(I).Item("LIQAMT")
                    SCIGAMT = SCIGAMT + dt.Rows(I).Item("CIGAMT")
                    SJUIAMT = SJUIAMT + dt.Rows(I).Item("JUIAMT")
                    SMUSAMT = SMUSAMT + dt.Rows(I).Item("MUSAMT")
                    SCOLAMT = SCOLAMT + dt.Rows(I).Item("COLAMT")
                    SHALAMT = SHALAMT + dt.Rows(I).Item("HALAMT")
                    SARKAMT = SARKAMT + dt.Rows(I).Item("ARKAMT")
                    SMISAMT = SMISAMT + dt.Rows(I).Item("MISAMT")
                    SSTFAMT = SSTFAMT + dt.Rows(I).Item("STFAMT")
                    SSERAMT = SSERAMT + dt.Rows(I).Item("SERAMT")
                    SVAT = SVAT + dt.Rows(I).Item("VAT")
                    SCONT = SCONT + dt.Rows(I).Item("CONT")

                    SGRANDAMT = SGRANDAMT + dt.Rows(I).Item("GRANDAMT")

                    TBILAMT = TBILAMT + dt.Rows(I).Item("BILAMT")
                    TADVAMT = TADVAMT + dt.Rows(I).Item("ADVAMT")

                    TBALAMT = TBALAMT + dt.Rows(I).Item("BALAMT")
                    TOCCUPANCY = TOCCUPANCY + dt.Rows(I).Item("OCCUPANCY")
                    TVENAMT = TVENAMT + dt.Rows(I).Item("VENAMT")
                    TDINAMT = TDINAMT + dt.Rows(I).Item("DINAMT")
                    TCHIAMT = TCHIAMT + dt.Rows(I).Item("CHIAMT")
                    THABAMT = THABAMT + dt.Rows(I).Item("HABAMT")
                    TSOFAMT = TSOFAMT + dt.Rows(I).Item("SOFAMT")
                    TLIQAMT = TLIQAMT + dt.Rows(I).Item("LIQAMT")
                    TCIGAMT = TCIGAMT + dt.Rows(I).Item("CIGAMT")
                    TJUIAMT = TJUIAMT + dt.Rows(I).Item("JUIAMT")
                    TMUSAMT = TMUSAMT + dt.Rows(I).Item("MUSAMT")
                    TCOLAMT = TCOLAMT + dt.Rows(I).Item("COLAMT")
                    THALAMT = THALAMT + dt.Rows(I).Item("HALAMT")
                    TARKAMT = TARKAMT + dt.Rows(I).Item("ARKAMT")
                    TMISAMT = TMISAMT + dt.Rows(I).Item("MISAMT")
                    TSTFAMT = TSTFAMT + dt.Rows(I).Item("STFAMT")
                    TSERAMT = TSERAMT + dt.Rows(I).Item("SERAMT")
                    TVAT = TVAT + dt.Rows(I).Item("VAT")
                    TCONT = TCONT + dt.Rows(I).Item("CONT")
                    TGRANDAMT = TGRANDAMT + dt.Rows(I).Item("GRANDAMT")


                    PARTYDATE = Trim(dt.Rows(I).Item("partydate"))
                    pagesize = pagesize + 1
                Next
                If TGRANDAMT <> 0 Then
                    Filewrite.WriteLine(StrDup(78, "-"))
                    ssql = Mid(CNO, 1, 3) & Space(3 - Len(Mid(CNO, 1, 3))) & Space(1)

                    ssql = ssql & Space(9 - Len(Mid(Format(TBILAMT, "0.00"), 1, 9))) & Mid(Format(TBILAMT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TADVAMT, "0.00"), 1, 9))) & Mid(Format(TADVAMT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TBALAMT, "0.00"), 1, 9))) & Mid(Format(TBALAMT, "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(Space(4) & "    Total :" & Space(9) & ssql)
                    Filewrite.WriteLine(StrDup(78, "-"))
                End If
                Filewrite.Write(Chr(12))
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
    Public Function BOOKINGDETAILS_HALLWISE(ByVal pageheading() As String, ByVal SQLSTRING As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim HallCode As String
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath

            Dim ThallAMOUNT, TTARIFFAMOUNT, TRESTAMOUNT, TARRMENTAMOUNT, TNETAMOUNT, TSBFCHARGE, TNETTAX, TBILLTOTAL, TADVANCE, TNETPAYABLE As Double
            Dim ShallAMOUNT, STARIFFAMOUNT, SRESTAMOUNT, SARRMENTAMOUNT, SNETAMOUNT, SSBFCHARGE, SNETTAX, SBILLTOTAL, SADVANCE, SNETPAYABLE As Double

            pageno = 1 : pagesize = 1
            dt = gconnection.GetValues(SQLSTRING)
            If dt.Rows.Count > 0 Then
                Filewrite.WriteLine(Chr(15))
                Call PrintHeader(pageheading, mskfromdate, msktodate)
                pagesize = pagesize + 1
                HallCode = ""
                SNO = 0 : CNO = 0
                ThallAMOUNT = 0 : TTARIFFAMOUNT = 0 : TRESTAMOUNT = 0 : TARRMENTAMOUNT = 0 : TNETAMOUNT = 0 : TSBFCHARGE = 0 : TNETTAX = 0 : TBILLTOTAL = 0 : TADVANCE = 0 : TNETPAYABLE = 0
                ShallAMOUNT = 0 : STARIFFAMOUNT = 0 : SRESTAMOUNT = 0 : SARRMENTAMOUNT = 0 : SNETAMOUNT = 0 : SSBFCHARGE = 0 : SNETTAX = 0 : SBILLTOTAL = 0 : SADVANCE = 0 : SNETPAYABLE = 0
                For I = 0 To dt.Rows.Count - 1
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(150, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(pageheading, mskfromdate, msktodate)
                    End If
                    If HallCode <> Trim(dt.Rows(I).Item("Hallcode")) Then
                        If ShallAMOUNT + STARIFFAMOUNT + SRESTAMOUNT + SARRMENTAMOUNT + SNETAMOUNT + SSBFCHARGE + SNETTAX + SBILLTOTAL + SADVANCE + SNETPAYABLE <> 0 Then
                            Filewrite.WriteLine(StrDup(150, "-"))
                            ssql = Mid(SNO, 1, 5) & Space(5 - Len(Mid(SNO, 1, 5))) & Space(1)
                            ssql = ssql & Mid(HallCode, 1, 10) & Space(10 - Len(Mid(HallCode, 1, 10))) & Space(1)
                            ssql = ssql & "Sub Total :" & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(ShallAMOUNT, "0.00"), 1, 9))) & Mid(Format(ShallAMOUNT, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(STARIFFAMOUNT, "0.00"), 1, 9))) & Mid(Format(STARIFFAMOUNT, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SRESTAMOUNT, "0.00"), 1, 9))) & Mid(Format(SRESTAMOUNT, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SARRMENTAMOUNT, "0.00"), 1, 9))) & Mid(Format(SARRMENTAMOUNT, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SNETAMOUNT, "0.00"), 1, 9))) & Mid(Format(SNETAMOUNT, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SSBFCHARGE, "0.00"), 1, 9))) & Mid(Format(SSBFCHARGE, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SNETTAX, "0.00"), 1, 9))) & Mid(Format(SNETTAX, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SBILLTOTAL, "0.00"), 1, 9))) & Mid(Format(SBILLTOTAL, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SADVANCE, "0.00"), 1, 9))) & Mid(Format(SADVANCE, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SNETPAYABLE, "0.00"), 1, 9))) & Mid(Format(SNETPAYABLE, "0.00"), 1, 9) & Space(1)
                            Filewrite.WriteLine(Space(19) & ssql)
                            ShallAMOUNT = 0 : STARIFFAMOUNT = 0 : SRESTAMOUNT = 0 : SARRMENTAMOUNT = 0 : SNETAMOUNT = 0 : SSBFCHARGE = 0 : SNETTAX = 0 : SBILLTOTAL = 0 : SADVANCE = 0 : SNETPAYABLE = 0
                            Filewrite.WriteLine(StrDup(150, "-"))
                            pagesize = pagesize + 3
                        End If
                        Filewrite.WriteLine(Chr(27) + "E" & "HallCode :" & Trim(dt.Rows(I).Item("Hallcode")) & " " & Trim(dt.Rows(I).Item("Halldescription")) & Chr(27) + "F")
                        Filewrite.WriteLine()
                        pagesize = pagesize + 2
                        SNO = 0
                    End If
                    SNO = SNO + 1
                    CNO = CNO + 1

                    ssql = Mid(SNO, 1, 5) & Space(5 - Len(Mid(SNO, 1, 5)))
                    ssql = ssql & Space(3) & Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4) & Space(4 - Len(Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4)))
                    '                   ssql = ssql & Mid(Format(dt.Rows(I).Item("BOOKINGDATE"), "dd/MM/yyyy"), 1, 10) & Space(10 - Len(Mid(Format(dt.Rows(I).Item("BOOKINGDATE"), "dd/MM/yyyy"), 1, 10))) & Space(1)
                    ssql = ssql & Mid(Format(dt.Rows(I).Item("partydate"), "dd/MM/yyyy"), 1, 10) & Space(10 - Len(Mid(Format(dt.Rows(I).Item("partydate"), "dd/MM/yyyy"), 1, 10))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("Halltype"), 1, 5) & Space(5 - Len(Mid(dt.Rows(I).Item("Halltype"), 1, 5)))
                    'ssql = ssql & Mid(dt.Rows(I).Item("MCODE"), 1, 7) & Space(7 - Len(Mid(dt.Rows(I).Item("MCODE"), 1, 7)))
                    ssql = ssql & Mid(dt.Rows(I).Item("MNAME"), 1, 20) & Space(20 - Len(Mid(dt.Rows(I).Item("MNAME"), 1, 20)))

                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("HALLAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("HALLAMOUNT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("TARIFFAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("TARIFFAMOUNT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("RESTAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("RESTAMOUNT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("ARRMENTAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("ARRMENTAMOUNT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("NETAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("NETAMOUNT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("SBFCHARGE"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("SBFCHARGE"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("NETTAX"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("NETTAX"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("BILLTOTAL"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("BILLTOTAL"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("ADVANCE"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("ADVANCE"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("NETPAYABLE"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("NETPAYABLE"), "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(ssql)

                    ShallAMOUNT = ShallAMOUNT + dt.Rows(I).Item("HALLAMOUNT")
                    STARIFFAMOUNT = STARIFFAMOUNT + dt.Rows(I).Item("TARIFFAMOUNT")
                    SRESTAMOUNT = SRESTAMOUNT + dt.Rows(I).Item("RESTAMOUNT")
                    SARRMENTAMOUNT = SARRMENTAMOUNT + dt.Rows(I).Item("ARRMENTAMOUNT")
                    SNETAMOUNT = SNETAMOUNT + dt.Rows(I).Item("NETAMOUNT")
                    SSBFCHARGE = SSBFCHARGE + dt.Rows(I).Item("SBFCHARGE")
                    SNETTAX = SNETTAX + dt.Rows(I).Item("NETTAX")
                    SBILLTOTAL = SBILLTOTAL + dt.Rows(I).Item("BILLTOTAL")
                    SADVANCE = SADVANCE + dt.Rows(I).Item("ADVANCE")
                    SNETPAYABLE = SNETPAYABLE + dt.Rows(I).Item("NETPAYABLE")

                    ThallAMOUNT = ThallAMOUNT + dt.Rows(I).Item("HALLAMOUNT")
                    TTARIFFAMOUNT = TTARIFFAMOUNT + dt.Rows(I).Item("TARIFFAMOUNT")
                    TRESTAMOUNT = TRESTAMOUNT + dt.Rows(I).Item("RESTAMOUNT")
                    TARRMENTAMOUNT = TARRMENTAMOUNT + dt.Rows(I).Item("ARRMENTAMOUNT")
                    TNETAMOUNT = TNETAMOUNT + dt.Rows(I).Item("NETAMOUNT")
                    TSBFCHARGE = TSBFCHARGE + dt.Rows(I).Item("SBFCHARGE")
                    TNETTAX = TNETTAX + dt.Rows(I).Item("NETTAX")
                    TBILLTOTAL = TBILLTOTAL + dt.Rows(I).Item("BILLTOTAL")
                    TADVANCE = TADVANCE + dt.Rows(I).Item("ADVANCE")
                    TNETPAYABLE = TNETPAYABLE + dt.Rows(I).Item("NETPAYABLE")

                    '                    STCAMOUNT = STCAMOUNT + dt.Rows(I).Item("CAMOUNT")

                    HallCode = Trim(dt.Rows(I).Item("Hallcode"))
                    pagesize = pagesize + 1
                Next
                If ShallAMOUNT + STARIFFAMOUNT + SRESTAMOUNT + SARRMENTAMOUNT + SNETAMOUNT + SSBFCHARGE + SNETTAX + SBILLTOTAL + SADVANCE + SNETPAYABLE <> 0 Then
                    Filewrite.WriteLine(StrDup(150, "-"))
                    ssql = Mid(SNO, 1, 5) & Space(5 - Len(Mid(SNO, 1, 5))) & Space(1)
                    ssql = ssql & Mid(HallCode, 1, 10) & Space(10 - Len(Mid(HallCode, 1, 10))) & Space(1)
                    ssql = ssql & "Sub Total :" & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(ShallAMOUNT, "0.00"), 1, 9))) & Mid(Format(ShallAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(STARIFFAMOUNT, "0.00"), 1, 9))) & Mid(Format(STARIFFAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SRESTAMOUNT, "0.00"), 1, 9))) & Mid(Format(SRESTAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SARRMENTAMOUNT, "0.00"), 1, 9))) & Mid(Format(SARRMENTAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SNETAMOUNT, "0.00"), 1, 9))) & Mid(Format(SNETAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SSBFCHARGE, "0.00"), 1, 9))) & Mid(Format(SSBFCHARGE, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SNETTAX, "0.00"), 1, 9))) & Mid(Format(SNETTAX, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SBILLTOTAL, "0.00"), 1, 9))) & Mid(Format(SBILLTOTAL, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SADVANCE, "0.00"), 1, 9))) & Mid(Format(SADVANCE, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SNETPAYABLE, "0.00"), 1, 9))) & Mid(Format(SNETPAYABLE, "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(Space(19) & ssql)
                    ShallAMOUNT = 0 : STARIFFAMOUNT = 0 : SRESTAMOUNT = 0 : SARRMENTAMOUNT = 0 : SNETAMOUNT = 0 : SSBFCHARGE = 0 : SNETTAX = 0 : SBILLTOTAL = 0 : SADVANCE = 0 : SNETPAYABLE = 0
                    Filewrite.WriteLine(StrDup(150, "-"))
                    pagesize = pagesize + 3
                End If


                If ThallAMOUNT + TTARIFFAMOUNT + TRESTAMOUNT + TARRMENTAMOUNT + TNETAMOUNT + TSBFCHARGE + TNETTAX + TBILLTOTAL + TADVANCE + TNETPAYABLE <> 0 Then
                    Filewrite.WriteLine(StrDup(150, "="))
                    ssql = Mid(CNO, 1, 5) & Space(5 - Len(Mid(CNO, 1, 5))) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(ThallAMOUNT, "0.00"), 1, 9))) & Mid(Format(ThallAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TTARIFFAMOUNT, "0.00"), 1, 9))) & Mid(Format(TTARIFFAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TRESTAMOUNT, "0.00"), 1, 9))) & Mid(Format(TRESTAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TARRMENTAMOUNT, "0.00"), 1, 9))) & Mid(Format(TARRMENTAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TNETAMOUNT, "0.00"), 1, 9))) & Mid(Format(TNETAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TSBFCHARGE, "0.00"), 1, 9))) & Mid(Format(TSBFCHARGE, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TNETTAX, "0.00"), 1, 9))) & Mid(Format(TNETTAX, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TBILLTOTAL, "0.00"), 1, 9))) & Mid(Format(TBILLTOTAL, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TADVANCE, "0.00"), 1, 9))) & Mid(Format(TADVANCE, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TNETPAYABLE, "0.00"), 1, 9))) & Mid(Format(TNETPAYABLE, "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(Space(7) & "Grand Total : " & Space(21) & ssql)
                    Filewrite.WriteLine(StrDup(150, "="))
                    pagesize = pagesize + 3
                End If
                Filewrite.Write(Chr(12))
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
    Public Function BOOKINGDETAILS_DATEWISE(ByVal pageheading() As String, ByVal SQLSTRING As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim PARTYDATE As Date
        Try
            Call Randomize()
            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath

            Dim ThallAMOUNT, TTARIFFAMOUNT, TRESTAMOUNT, TARRMENTAMOUNT, TNETAMOUNT, TSBFCHARGE, TNETTAX, TBILLTOTAL, TADVANCE, TNETPAYABLE As Double
            Dim ShallAMOUNT, STARIFFAMOUNT, SRESTAMOUNT, SARRMENTAMOUNT, SNETAMOUNT, SSBFCHARGE, SNETTAX, SBILLTOTAL, SADVANCE, SNETPAYABLE As Double

            pageno = 1 : pagesize = 1
            dt = gconnection.GetValues(SQLSTRING)
            If dt.Rows.Count > 0 Then
                Filewrite.WriteLine(Chr(15))
                Call PrintHeader(pageheading, mskfromdate, msktodate)
                pagesize = pagesize + 1
                SNO = 0 : CNO = 0
                ThallAMOUNT = 0 : TTARIFFAMOUNT = 0 : TRESTAMOUNT = 0 : TARRMENTAMOUNT = 0 : TNETAMOUNT = 0 : TSBFCHARGE = 0 : TNETTAX = 0 : TBILLTOTAL = 0 : TADVANCE = 0 : TNETPAYABLE = 0
                ShallAMOUNT = 0 : STARIFFAMOUNT = 0 : SRESTAMOUNT = 0 : SARRMENTAMOUNT = 0 : SNETAMOUNT = 0 : SSBFCHARGE = 0 : SNETTAX = 0 : SBILLTOTAL = 0 : SADVANCE = 0 : SNETPAYABLE = 0
                For I = 0 To dt.Rows.Count - 1
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(150, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader(pageheading, mskfromdate, msktodate)
                    End If
                    If PARTYDATE <> Trim(dt.Rows(I).Item("PARTYDATE")) Then
                        If ShallAMOUNT + STARIFFAMOUNT + SRESTAMOUNT + SARRMENTAMOUNT + SNETAMOUNT + SSBFCHARGE + SNETTAX + SBILLTOTAL + SADVANCE + SNETPAYABLE <> 0 Then
                            Filewrite.WriteLine(StrDup(150, "-"))
                            ssql = Mid(SNO, 1, 4) & Space(4 - Len(Mid(SNO, 1, 4))) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(ShallAMOUNT, "0.00"), 1, 9))) & Mid(Format(ShallAMOUNT, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(STARIFFAMOUNT, "0.00"), 1, 9))) & Mid(Format(STARIFFAMOUNT, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SRESTAMOUNT, "0.00"), 1, 9))) & Mid(Format(SRESTAMOUNT, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SARRMENTAMOUNT, "0.00"), 1, 9))) & Mid(Format(SARRMENTAMOUNT, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SNETAMOUNT, "0.00"), 1, 9))) & Mid(Format(SNETAMOUNT, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SSBFCHARGE, "0.00"), 1, 9))) & Mid(Format(SSBFCHARGE, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SNETTAX, "0.00"), 1, 9))) & Mid(Format(SNETTAX, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SBILLTOTAL, "0.00"), 1, 9))) & Mid(Format(SBILLTOTAL, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SADVANCE, "0.00"), 1, 9))) & Mid(Format(SADVANCE, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SNETPAYABLE, "0.00"), 1, 9))) & Mid(Format(SNETPAYABLE, "0.00"), 1, 9) & Space(1)
                            Filewrite.WriteLine(Space(7) & "Sub Total :" & Space(24) & ssql)

                            ShallAMOUNT = 0 : STARIFFAMOUNT = 0 : SRESTAMOUNT = 0 : SARRMENTAMOUNT = 0 : SNETAMOUNT = 0 : SSBFCHARGE = 0 : SNETTAX = 0 : SBILLTOTAL = 0 : SADVANCE = 0 : SNETPAYABLE = 0
                            Filewrite.WriteLine(StrDup(150, "-"))
                            pagesize = pagesize + 3
                            SNO = 0
                        End If
                        Filewrite.WriteLine(Chr(27) + "E" & "Party Date :" & Format(dt.Rows(I).Item("partydate"), "dd/MM/yyyy") & Chr(27) + "F")
                        Filewrite.WriteLine()
                        pagesize = pagesize + 2
                    End If
                    SNO = SNO + 1
                    CNO = CNO + 1
                    ssql = Mid(SNO, 1, 4) & Space(4 - Len(Mid(SNO, 1, 4))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4) & Space(4 - Len(Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("HALLCODE"), 1, 10) & Space(10 - Len(Mid(dt.Rows(I).Item("HALLCODE"), 1, 10))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("Halltype"), 1, 5) & Space(5 - Len(Mid(dt.Rows(I).Item("Halltype"), 1, 5))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("MNAME"), 1, 20) & Space(20 - Len(Mid(dt.Rows(I).Item("MNAME"), 1, 20))) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("HALLAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("HALLAMOUNT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("TARIFFAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("TARIFFAMOUNT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("RESTAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("RESTAMOUNT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("ARRMENTAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("ARRMENTAMOUNT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("NETAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("NETAMOUNT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("SBFCHARGE"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("SBFCHARGE"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("NETTAX"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("NETTAX"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("BILLTOTAL"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("BILLTOTAL"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("ADVANCE"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("ADVANCE"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("NETPAYABLE"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("NETPAYABLE"), "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(ssql)

                    ShallAMOUNT = ShallAMOUNT + dt.Rows(I).Item("HALLAMOUNT")
                    STARIFFAMOUNT = STARIFFAMOUNT + dt.Rows(I).Item("TARIFFAMOUNT")
                    SRESTAMOUNT = SRESTAMOUNT + dt.Rows(I).Item("RESTAMOUNT")
                    SARRMENTAMOUNT = SARRMENTAMOUNT + dt.Rows(I).Item("ARRMENTAMOUNT")
                    SNETAMOUNT = SNETAMOUNT + dt.Rows(I).Item("NETAMOUNT")
                    SSBFCHARGE = SSBFCHARGE + dt.Rows(I).Item("SBFCHARGE")
                    SNETTAX = SNETTAX + dt.Rows(I).Item("NETTAX")
                    SBILLTOTAL = SBILLTOTAL + dt.Rows(I).Item("BILLTOTAL")
                    SADVANCE = SADVANCE + dt.Rows(I).Item("ADVANCE")
                    SNETPAYABLE = SNETPAYABLE + dt.Rows(I).Item("NETPAYABLE")

                    ThallAMOUNT = ThallAMOUNT + dt.Rows(I).Item("HALLAMOUNT")
                    TTARIFFAMOUNT = TTARIFFAMOUNT + dt.Rows(I).Item("TARIFFAMOUNT")
                    TRESTAMOUNT = TRESTAMOUNT + dt.Rows(I).Item("RESTAMOUNT")
                    TARRMENTAMOUNT = TARRMENTAMOUNT + dt.Rows(I).Item("ARRMENTAMOUNT")
                    TNETAMOUNT = TNETAMOUNT + dt.Rows(I).Item("NETAMOUNT")
                    TSBFCHARGE = TSBFCHARGE + dt.Rows(I).Item("SBFCHARGE")
                    TNETTAX = TNETTAX + dt.Rows(I).Item("NETTAX")
                    TBILLTOTAL = TBILLTOTAL + dt.Rows(I).Item("BILLTOTAL")
                    TADVANCE = TADVANCE + dt.Rows(I).Item("ADVANCE")
                    TNETPAYABLE = TNETPAYABLE + dt.Rows(I).Item("NETPAYABLE")

                    PARTYDATE = Trim(dt.Rows(I).Item("partydate"))
                    pagesize = pagesize + 1
                Next
                If ShallAMOUNT + STARIFFAMOUNT + SRESTAMOUNT + SARRMENTAMOUNT + SNETAMOUNT + SSBFCHARGE + SNETTAX + SBILLTOTAL + SADVANCE + SNETPAYABLE <> 0 Then
                    Filewrite.WriteLine(StrDup(150, "-"))
                    ssql = Mid(SNO, 1, 4) & Space(4 - Len(Mid(SNO, 1, 4))) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(ShallAMOUNT, "0.00"), 1, 9))) & Mid(Format(ShallAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(STARIFFAMOUNT, "0.00"), 1, 9))) & Mid(Format(STARIFFAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SRESTAMOUNT, "0.00"), 1, 9))) & Mid(Format(SRESTAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SARRMENTAMOUNT, "0.00"), 1, 9))) & Mid(Format(SARRMENTAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SNETAMOUNT, "0.00"), 1, 9))) & Mid(Format(SNETAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SSBFCHARGE, "0.00"), 1, 9))) & Mid(Format(SSBFCHARGE, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SNETTAX, "0.00"), 1, 9))) & Mid(Format(SNETTAX, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SBILLTOTAL, "0.00"), 1, 9))) & Mid(Format(SBILLTOTAL, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SADVANCE, "0.00"), 1, 9))) & Mid(Format(SADVANCE, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(SNETPAYABLE, "0.00"), 1, 9))) & Mid(Format(SNETPAYABLE, "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(Space(7) & "Sub Total :" & Space(25) & ssql)
                    Filewrite.WriteLine(StrDup(150, "-"))
                End If


                If ThallAMOUNT + TTARIFFAMOUNT + TRESTAMOUNT + TARRMENTAMOUNT + TNETAMOUNT + TSBFCHARGE + TNETTAX + TBILLTOTAL + TADVANCE + TNETPAYABLE <> 0 Then
                    Filewrite.WriteLine(StrDup(150, "="))
                    ssql = Mid(CNO, 1, 4) & Space(4 - Len(Mid(CNO, 1, 4))) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(ThallAMOUNT, "0.00"), 1, 9))) & Mid(Format(ThallAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TTARIFFAMOUNT, "0.00"), 1, 9))) & Mid(Format(TTARIFFAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TRESTAMOUNT, "0.00"), 1, 9))) & Mid(Format(TRESTAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TARRMENTAMOUNT, "0.00"), 1, 9))) & Mid(Format(TARRMENTAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TNETAMOUNT, "0.00"), 1, 9))) & Mid(Format(TNETAMOUNT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TSBFCHARGE, "0.00"), 1, 9))) & Mid(Format(TSBFCHARGE, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TNETTAX, "0.00"), 1, 9))) & Mid(Format(TNETTAX, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TBILLTOTAL, "0.00"), 1, 9))) & Mid(Format(TBILLTOTAL, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TADVANCE, "0.00"), 1, 9))) & Mid(Format(TADVANCE, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TNETPAYABLE, "0.00"), 1, 9))) & Mid(Format(TNETPAYABLE, "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(Space(7) & "Grand Total : " & Space(22) & ssql)
                    Filewrite.WriteLine(StrDup(150, "="))
                    pagesize = pagesize + 3
                End If
                Filewrite.Write(Chr(12))
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

    Public Function BOOKINGDETAILS1(ByVal pageheading() As String, ByVal SQLSTRING As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim HallCode As String
        Dim TOTAD, TOTAL, TOCAN, TOTBAL As Double
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
                Call PrintHeader1(pageheading, mskfromdate, msktodate)
                pagesize = pagesize + 1
                HallCode = ""
                SNO = 1
                For I = 0 To dt.Rows.Count - 1
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(155, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader1(pageheading, mskfromdate, msktodate)
                    End If
                    If HallCode <> Trim(dt.Rows(I).Item("Hallcode")) Then
                        Filewrite.WriteLine(Chr(27) + "E" & "HallCode :" & Trim(dt.Rows(I).Item("Hallcode")) & " " & Trim(dt.Rows(I).Item("Halldescription")) & Chr(27) + "F")
                    End If
                    ssql = Mid(SNO, 1, 5) & Space(5 - Len(Mid(SNO, 1, 5)))
                    ssql = ssql & Space(3) & Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 7) & Space(7 - Len(Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 7)))
                    'ssql = ssql & Mid(Format(dt.Rows(I).Item("BOOKINGDATE"), "dd/MM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(dt.Rows(I).Item("BOOKINGDATE"), "dd/MM/yyyy"), 1, 11))) & Space(1)
                    ssql = ssql & Mid(Format(dt.Rows(I).Item("partydate"), "dd/MM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(dt.Rows(I).Item("partydate"), "dd/MM/yyyy"), 1, 11))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("Halltype"), 1, 18) & Space(18 - Len(Mid(dt.Rows(I).Item("Halltype"), 1, 18)))
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("FROMTIME"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("FROMTIME"), "0.00"), 1, 9)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("TOTIME"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("TOTIME"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("MCODE"), 1, 7) & Space(7 - Len(Mid(dt.Rows(I).Item("MCODE"), 1, 7)))
                    ssql = ssql & Mid(dt.Rows(I).Item("MNAME"), 1, 30) & Space(30 - Len(Mid(dt.Rows(I).Item("MNAME"), 1, 30)))

                    ssql = ssql & Space(9 - Len(Mid(Format(ADVANCE_ANOUNT(dt.Rows(I).Item("BOOKINGNO")), "0.00"), 1, 9))) & Mid(Format(ADVANCE_ANOUNT(dt.Rows(I).Item("BOOKINGNO")), "0.00"), 1, 9) & Space(2)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("TOTALAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("TOTALAMOUNT"), "0.00"), 1, 9) & Space(2)
                    'ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("ARRAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("ARRAMOUNT"), "0.00"), 1, 9) & Space(2)
                    'ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("RESTAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("RESTAMOUNT"), "0.00"), 1, 9)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("CAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("CAMOUNT"), "0.00"), 1, 9) & Space(2)
                    Dim BAL As Integer
                    If dt.Rows(I).Item("FREEZE") = "Y" Then
                        'BAL = dt.Rows(I).Item("Camount") - dt.Rows(I).Item("ADVANCE")
                        BAL = dt.Rows(I).Item("Camount") - ADVANCE_ANOUNT(dt.Rows(I).Item("BOOKINGNO"))
                        ssql = ssql & Space(9 - Len(Mid(Format(BAL, "0.00"), 1, 9))) & Mid(Format(BAL, "0.00"), 1, 9)
                        TOTBAL = TOTBAL + BAL
                    Else
                        BAL = (dt.Rows(I).Item("TOTALAMOUNT")) - ADVANCE_ANOUNT(dt.Rows(I).Item("BOOKINGNO"))
                        ssql = ssql & Space(9 - Len(Mid(Format(BAL, "0.00"), 1, 9))) & Mid(Format(BAL, "0.00"), 1, 9)
                        TOTBAL = TOTBAL + BAL
                    End If
                    Filewrite.WriteLine(ssql)
                    pagesize = pagesize + 1
                    SNO = SNO + 1
                    TOTAD = TOTAD + Format(ADVANCE_ANOUNT(dt.Rows(I).Item("BOOKINGNO")), "0.00")
                    TOTAL = TOTAL + Format(dt.Rows(I).Item("TOTALAMOUNT"), "0.00")
                    TOCAN = TOCAN + Format(dt.Rows(I).Item("CAMOUNT"), "0.00")
                Next
                Filewrite.WriteLine(StrDup(155, "-"))
                Filewrite.WriteLine("{0,-5}{1,-10}{2,-11}{3,-21}{4,-8}{5,-8}{6,-7}{7,-30}{8,-9}{9,-9}{10,-9}{11,-9}", "", "", "", "TOTAL ", " ", "", "", "", Format(TOTAD, "0.00") & Space(2), Format(TOTAL, "0.00") & Space(2), Format(TOCAN, "0.00") & Space(2), Format(TOTBAL, "0.00"))
                Filewrite.WriteLine(StrDup(155, "-"))
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
            Filewrite.WriteLine("{0,64}{1,-10}", " ", "SUMMARY")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "MMM dd,yyyy") & " " & "To" & " " & Format(msktodate, "MMM dd,yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(150, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("SNO BOOKING  HALLCODE TYPE  MNAME                  HALL     TARIFF RESTAURANT   ARRMNT     NET       SBF     TAX       NET      ADVANCE    BALANCE")
            Filewrite.WriteLine("      NO   PARTY DATE                             AMOUNT    AMOUNT    AMOUNT    AMOUNT   AMOUNT    AMOUNT   AMOUNT    AMOUNT     AMOUNT     AMOUNT")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(150, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    Private Function PrintHeader_ACCOUNTS(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal strhead As String)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.Write(Chr(15))
            Filewrite.WriteLine("{0,80}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            '            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", " ")
            pagesize = pagesize + 1
            'Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", gFinancialyearStart & " TO " & gFinancialyearEnding)

            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,64}{1,-10}", Trim(strhead), " SUMMARY")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "dd-MMM-yyyy") & " " & "To" & " " & Format(msktodate, "dd-MMM-yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(230, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("SNO MCODE   PARTY DATE BILL  BILL AMT   ADVANCE    BALANCE PAXS  VENILLA            CHINEESE   KABAAB     SOFT  LIQUOR     CIGG     JUICE    MUSIC   COLOUR  AC ROOM ROYAL ARK   MISC     STAFF  SERVICE    VAT     CONT    GRAND")
            Filewrite.WriteLine("     NO               NUMBER              AMT      AMOUNT       ICE CREAM  DINING                         DRINK                              SYSTEM    BULBS  CHARGES  CHARGES  CHARGES  BENEFIT    TAX                      TOTAL")
            '            Filewrite.WriteLine("1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(230, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function


    Private Function PrintHeader_ITEMWISE(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal strhead As String)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.Write(Chr(15))
            Filewrite.WriteLine("{0,80}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,64}{1,-10}", Trim(strhead), " SUMMARY")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "dd-MMM-yyyy") & " " & "To" & " " & Format(msktodate, "dd-MMM-yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(131, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("SNO MCODE   PARTY DATE BILL  CHITNO      ITEMCODE  ITEM DESC                          RATE      QTY  TAX AMOUNT    AMOUNT    TOTAL")
            Filewrite.WriteLine("     NO               NUMBER                                                                                                AMOUNT")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(131, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function


    Private Function PrintHeader_BALANCE(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal strhead As String)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.Write(Chr(15))
            Filewrite.WriteLine("{0,80}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            '            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", "ACCOUNTING PERIOD")
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", " ")
            pagesize = pagesize + 1
            'Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", gFinancialyearStart & " TO " & gFinancialyearEnding)

            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,64}{1,-10}", Trim(strhead), " SUMMARY")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "dd-MMM-yyyy") & " " & "To" & " " & Format(msktodate, "dd-MMM-yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(78, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("SNO MCODE   PARTY DATE BILL  BILL AMT   ADVANCE    BALANCE")
            Filewrite.WriteLine("     NO               NUMBER              AMT      AMOUNT")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(78, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function


    Private Function PrintHeader_ADJUSTED(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal strhead As String)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.Write(Chr(15))
            Filewrite.WriteLine("{0,80}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,64}{1,-10}", Trim(strhead), " SUMMARY")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "dd-MMM-yyyy") & " " & "To" & " " & Format(msktodate, "dd-MMM-yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("SNO MEMBERSHIP  PARTY DATE BILL RECEIPT               RECEIPT     AMOUNT")
            Filewrite.WriteLine("      NO                  NO   NUMBER                  DATE        ")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function


    Private Function PrintHeader_NOTADJUST(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal strhead As String)
        Dim I As Integer
        pagesize = 0
        '''*********************************************** PRINT REPORTS HEADING  *********************************'''
        Try
            Filewrite.Write(Chr(15))
            Filewrite.WriteLine("{0,80}{1,15}{2,10}", Chr(14) & Chr(15) & " ", "PRINTED ON : ", Format(Now, "dd/MM/yyyy"))
            pagesize = pagesize + 1
            Filewrite.WriteLine()
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,85}{2,20}", Mid(MyCompanyName, 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}{3,-25}{4,-24}", Mid(Address1, 1, 30), " ", Mid(Trim(Heading(0)), 1, 30), " ", " ")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,-26}{2,-30}", Mid(Address2, 1, 30), " ", Mid(StrDup(Len(Trim(Heading(0))), "-"), 1, 30))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,64}{1,-10}", Trim(strhead), " SUMMARY")
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,124}{1,-10}", " ", "PAGE : " & pageno)
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-30}{1,87}{2,16}", Format(mskfromdate, "dd-MMM-yyyy") & " " & "To" & " " & Format(msktodate, "dd-MMM-yyyy"), " ", "AMOUNT IN RUPEES")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("SNO MEMBERSHIP  PARTY DATE BILL RECEIPT               RECEIPT     AMOUNT")
            Filewrite.WriteLine("      NO                  NO   NUMBER                  DATE        ")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(79, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function

    Private Function PrintHeader1(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
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
            Filewrite.WriteLine(StrDup(155, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-5}{1,-10}{2,-11}{3,-21}{4,-8}{5,-8}{6,-7}{7,-30}{8,-9}{9,-9}{10,-9}{11,-9}", "SNO", "BOOKINGNO", "PARTYDATE ", "FUNCTIONTYPE ", "FROMTIME ", "TOTIME", "MCODE", "MNAME", "ADVANCE ", "TOTALAMOUNT ", "CANCELAMT ", "BALANCE ")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(155, "-"))
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
    Public Function itemwisesale(ByVal pageheading() As String, ByVal SQLSTRING As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
        Dim HallCode As String
        Dim TOTAD, TOTAL, TOCAN, TOTBAL As Double
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
                Call PrintHeader2(pageheading, mskfromdate, msktodate)
                pagesize = pagesize + 1
                HallCode = ""
                SNO = 1
                For I = 0 To dt.Rows.Count - 1
                    If pagesize > 58 Then
                        Filewrite.Write(StrDup(155, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader2(pageheading, mskfromdate, msktodate)
                    End If
                    'If HallCode <> Trim(dt.Rows(I).Item("Hallcode")) Then
                    '    Filewrite.WriteLine(Chr(27) + "E" & "HallCode :" & Trim(dt.Rows(I).Item("Hallcode")) & " " & Trim(dt.Rows(I).Item("Halldescription")) & Chr(27) + "F")
                    'End If
                    ssql = Mid(SNO, 1, 5) & Space(5 - Len(Mid(SNO, 1, 5)))
                    ssql = ssql & Space(3) & Mid(dt.Rows(I).Item("itemcode"), 1, 12) & Space(12 - Len(Mid(dt.Rows(I).Item("itemcode"), 1, 12)))
                    'ssql = ssql & Mid(Format(dt.Rows(I).Item("BOOKINGDATE"), "dd/MM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(dt.Rows(I).Item("BOOKINGDATE"), "dd/MM/yyyy"), 1, 11))) & Space(1)
                    'ssql = ssql & Mid(Format(dt.Rows(I).Item("partydate"), "dd/MM/yyyy"), 1, 11) & Space(11 - Len(Mid(Format(dt.Rows(I).Item("partydate"), "dd/MM/yyyy"), 1, 11))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("itemdescription"), 1, 18) & Space(18 - Len(Mid(dt.Rows(I).Item("itemdescription"), 1, 18)))
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("UOM"), ""), 1, 9))) & Mid(Format(dt.Rows(I).Item("UOM"), ""), 1, 9)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("QTY"), "0"), 1, 9))) & Mid(Format(dt.Rows(I).Item("QTY"), "0"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("RATE"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("RATE"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("Taxamount"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("taxamount"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("Amount"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("amount"), "0.00"), 1, 9) & Space(1)

                    'ssql = ssql & Mid(dt.Rows(I).Item("MCODE"), 1, 7) & Space(7 - Len(Mid(dt.Rows(I).Item("MCODE"), 1, 7)))
                    'ssql = ssql & Mid(dt.Rows(I).Item("MNAME"), 1, 30) & Space(30 - Len(Mid(dt.Rows(I).Item("MNAME"), 1, 30)))
                    'ssql = ssql & Space(9 - Len(Mid(Format(ADVANCE_ANOUNT(dt.Rows(I).Item("BOOKINGNO")), "0.00"), 1, 9))) & Mid(Format(ADVANCE_ANOUNT(dt.Rows(I).Item("BOOKINGNO")), "0.00"), 1, 9) & Space(2)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("TOTALAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("TOTALAMOUNT"), "0.00"), 1, 9) & Space(2)
                    'ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("ARRAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("ARRAMOUNT"), "0.00"), 1, 9) & Space(2)
                    'ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("RESTAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("RESTAMOUNT"), "0.00"), 1, 9)
                    'ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("CAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("CAMOUNT"), "0.00"), 1, 9) & Space(2)
                    'Dim BAL As Integer
                    'If dt.Rows(I).Item("FREEZE") = "Y" Then
                    '    'BAL = dt.Rows(I).Item("Camount") - dt.Rows(I).Item("ADVANCE")
                    '    BAL = dt.Rows(I).Item("Camount") - ADVANCE_ANOUNT(dt.Rows(I).Item("BOOKINGNO"))
                    '    ssql = ssql & Space(9 - Len(Mid(Format(BAL, "0.00"), 1, 9))) & Mid(Format(BAL, "0.00"), 1, 9)
                    '    TOTBAL = TOTBAL + BAL
                    'Else
                    '    BAL = (dt.Rows(I).Item("TOTALAMOUNT")) - ADVANCE_ANOUNT(dt.Rows(I).Item("BOOKINGNO"))
                    '    ssql = ssql & Space(9 - Len(Mid(Format(BAL, "0.00"), 1, 9))) & Mid(Format(BAL, "0.00"), 1, 9)
                    '    TOTBAL = TOTBAL + BAL
                    'End If
                    Filewrite.WriteLine(ssql)
                    pagesize = pagesize + 1
                    SNO = SNO + 1
                    TOTAD = TOTAD + Format(dt.Rows(I).Item("taxamount"), "0.00")
                    TOTAL = TOTAL + Format(dt.Rows(I).Item("AMOUNT"), "0.00")
                    TOCAN = TOCAN + Format(dt.Rows(I).Item("TOTALAMOUNT"), "0.00")
                Next
                Filewrite.WriteLine(StrDup(155, "-") & Chr(12))
                Filewrite.WriteLine("{0,-5}{1,-12}{2,-18}{3,-9}{4,-9}{5,-14}{6,-9}{7,-9}{8,-9}", "", "", "TOTAL ", "", "", "", Format(TOTAD, "0.00") & Space(2), Format(TOTAL, "0.00") & Space(2), Format(TOCAN, "0.00") & Space(2))
                'Filewrite.WriteLine("{0,-5}{1,-10}{2,-11}{3,-21}{4,-8}{5,-8}{6,-7}{7,-30}{8,-9}{9,-9}", "SNO", "ITEMCODE", "ITEMDESCRIPTION ", "UOM", "RATE ", "TAXAMOUNT", "AMOUNT", "TOTALAMOUNT ")

                Filewrite.WriteLine(StrDup(155, "-") & Chr(12))
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
    Private Function PrintHeader2(ByVal Heading() As String, ByVal mskfromdate As Date, ByVal msktodate As Date)
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
            Filewrite.WriteLine(StrDup(155, "-"))
            pagesize = pagesize + 1
            Filewrite.WriteLine("{0,-5}{1,-15}{2,-22}{3,-10}{4,-11}{5,-6}{6,-10}{7,-9}{8,-9}", "SNO", "ITEMCODE", "ITEMDESCRIPTION ", "UOM", "QTY ", "RATE", "TAXAMOUNT", "AMOUNT", "TOTALAMOUNT ")
            pagesize = pagesize + 1
            Filewrite.WriteLine(StrDup(155, "-"))
            pagesize = pagesize + 1
        Catch ex As Exception
            Exit Function
        End Try
    End Function
    Public Function BOOKINGDETAILS_ITEMWISE(ByVal pageheading() As String, ByVal SQLSTRING As String, ByVal mskfromdate As Date, ByVal msktodate As Date, ByVal strhead As String)
        Dim PARTYDATE As Date
        Dim BOOKINGNO As Integer
        Try
            Call Randomize()

            AppPath = Application.StartupPath
            vOutfile = Mid("Ste" & (Rnd() * 800000), 1, 8)
            VFilePath = AppPath & "\Reports\" & vOutfile & ".txt"
            Filewrite = File.AppendText(VFilePath)
            printfile = VFilePath

            Dim TBILAMT, TADVAMT, TBALAMT, TOCCUPANCY, TVENAMT, TDINAMT, TCHIAMT, THABAMT, TSOFAMT, TLIQAMT, TCIGAMT, TJUIAMT, TMUSAMT, TCOLAMT, THALAMT, TARKAMT, TMISAMT, TSTFAMT, TSERAMT, TVAT, TCONT, TGRANDAMT As Double
            Dim SBILAMT, SADVAMT, SBALAMT, SOCCUPANCY, SVENAMT, SDINAMT, SCHIAMT, SHABAMT, SSOFAMT, SLIQAMT, SCIGAMT, SJUIAMT, SMUSAMT, SCOLAMT, SHALAMT, SARKAMT, SMISAMT, SSTFAMT, SSERAMT, SVAT, SCONT, SGRANDAMT As Double

            pageno = 1 : pagesize = 1

            dt = gconnection.GetValues(SQLSTRING)

            If dt.Rows.Count > 0 Then
                Filewrite.WriteLine(Chr(15))
                Call PrintHeader_ITEMWISE(pageheading, mskfromdate, msktodate, strhead)
                pagesize = pagesize + 1
                SNO = 0 : CNO = 0
                TBILAMT = 0 : TADVAMT = 0 : TBALAMT = 0 : TOCCUPANCY = 0 : TVENAMT = 0 : TDINAMT = 0 : TCHIAMT = 0 : THABAMT = 0 : TSOFAMT = 0 : TLIQAMT = 0 : TCIGAMT = 0 : TJUIAMT = 0 : TMUSAMT = 0 : TCOLAMT = 0 : THALAMT = 0 : TARKAMT = 0 : TMISAMT = 0 : TSTFAMT = 0 : TSERAMT = 0 : TVAT = 0 : TGRANDAMT = 0
                SBILAMT = 0 : SADVAMT = 0 : SBALAMT = 0 : SOCCUPANCY = 0 : SVENAMT = 0 : SDINAMT = 0 : SCHIAMT = 0 : SHABAMT = 0 : SSOFAMT = 0 : SLIQAMT = 0 : SCIGAMT = 0 : SJUIAMT = 0 : SMUSAMT = 0 : SCOLAMT = 0 : SHALAMT = 0 : SARKAMT = 0 : SMISAMT = 0 : SSTFAMT = 0 : SSERAMT = 0 : SVAT = 0 : SGRANDAMT = 0
                For I = 0 To dt.Rows.Count - 1
                    If pagesize > 58 Then
                        Filewrite.WriteLine(StrDup(131, "-"))
                        pagesize = pagesize + 1
                        Filewrite.Write(Chr(12))
                        pageno = pageno + 1
                        Call PrintHeader_ITEMWISE(pageheading, mskfromdate, msktodate, strhead)
                    End If

                    If BOOKINGNO <> dt.Rows(I).Item("BOOKINGNO") Then
                        SNO = SNO + 1
                        CNO = CNO + 1
                        If SVENAMT <> 0 Then
                            Filewrite.WriteLine(StrDup(131, "-"))
                            ssql = Space(58)
                            ssql = ssql & Space(9 - Len(Mid(Format(SBILAMT, "0.00"), 1, 9))) & Mid(Format(SBILAMT, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SADVAMT, "0.00"), 1, 9))) & Mid(Format(SADVAMT, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SBALAMT, "0.00"), 1, 9))) & Mid(Format(SBALAMT, "0.00"), 1, 9) & Space(1)
                            ssql = ssql & Space(9 - Len(Mid(Format(SVENAMT, "0.00"), 1, 9))) & Mid(Format(SVENAMT, "0.00"), 1, 9) & Space(1)
                            Filewrite.WriteLine(Space(14) & "Sub Total :" & Space(9) & ssql)
                            Filewrite.WriteLine(StrDup(131, "-"))
                            pagesize = pagesize + 3
                        End If
                        ssql = Mid(SNO, 1, 3) & Space(3 - Len(Mid(SNO, 1, 3))) & Space(1)
                        ssql = ssql & Mid(dt.Rows(I).Item("MCODE"), 1, 8) & Space(8 - Len(Mid(dt.Rows(I).Item("MCODE"), 1, 8))) & Space(1)
                        ssql = ssql & Mid(Format(dt.Rows(I).Item("PARTYDATE"), "dd/MM/yyyy"), 1, 10) & Space(10 - Len(Mid(Format(dt.Rows(I).Item("PARTYDATE"), "dd/MM/yyyy"), 1, 10))) & Space(1)
                        ssql = ssql & Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4) & Space(4 - Len(Mid(dt.Rows(I).Item("BOOKINGNO"), 1, 4))) & Space(1)
                    Else
                        ssql = Space(29)
                    End If

                    ssql = ssql & Mid(dt.Rows(I).Item("CHITNO"), 1, 10) & Space(10 - Len(Mid(dt.Rows(I).Item("CHITNO"), 1, 10))) & Space(1)

                    ssql = ssql & Mid(dt.Rows(I).Item("ITEMCODE"), 1, 10) & Space(10 - Len(Mid(dt.Rows(I).Item("ITEMCODE"), 1, 10))) & Space(1)
                    ssql = ssql & Mid(dt.Rows(I).Item("ITEMDESC"), 1, 30) & Space(30 - Len(Mid(dt.Rows(I).Item("ITEMDESC"), 1, 30))) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("RATE"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("RATE"), "0.00"), 1, 9) & Space(1)

                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("QTY"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("QTY"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("TAXAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("TAXAMOUNT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("AMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("AMOUNT"), "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(dt.Rows(I).Item("TOTALAMOUNT"), "0.00"), 1, 9))) & Mid(Format(dt.Rows(I).Item("TOTALAMOUNT"), "0.00"), 1, 9)

                    Filewrite.WriteLine(ssql)

                    SBILAMT = SBILAMT + dt.Rows(I).Item("QTY")
                    SADVAMT = SADVAMT + dt.Rows(I).Item("TAXAMOUNT")
                    SBALAMT = SBALAMT + dt.Rows(I).Item("AMOUNT")
                    SVENAMT = SVENAMT + dt.Rows(I).Item("TOTALAMOUNT")


                    TBILAMT = TBILAMT + dt.Rows(I).Item("QTY")
                    TADVAMT = TADVAMT + dt.Rows(I).Item("TAXAMOUNT")
                    TBALAMT = TBALAMT + dt.Rows(I).Item("AMOUNT")
                    TVENAMT = TVENAMT + dt.Rows(I).Item("TOTALAMOUNT")

                    TDINAMT = TDINAMT + dt.Rows(I).Item("QTY")

                    PARTYDATE = Trim(dt.Rows(I).Item("partydate"))
                    BOOKINGNO = dt.Rows(I).Item("BOOKINGNO")
                    pagesize = pagesize + 1
                Next
                If TVENAMT <> 0 Then
                    Filewrite.WriteLine(StrDup(131, "-"))
                    ssql = Space(68)
                    ssql = ssql & Space(9 - Len(Mid(Format(TBILAMT, "0.00"), 1, 9))) & Mid(Format(TBILAMT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TADVAMT, "0.00"), 1, 9))) & Mid(Format(TADVAMT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TBALAMT, "0.00"), 1, 9))) & Mid(Format(TBALAMT, "0.00"), 1, 9) & Space(1)
                    ssql = ssql & Space(9 - Len(Mid(Format(TVENAMT, "0.00"), 1, 9))) & Mid(Format(TVENAMT, "0.00"), 1, 9) & Space(1)
                    Filewrite.WriteLine(Space(14) & "    Total :" & Space(9) & ssql)
                    Filewrite.WriteLine(StrDup(131, "-"))
                End If
                Filewrite.Write(Chr(12))
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
End Class
