Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Module GlobalVariables
    Public gvoucherprefix As String
    Public gFinancialYearDateCheck As Boolean = True
    Public gServerDateCheck As Boolean = False
    Public gMaxDateCheck As Boolean = False
    Public chkdatevalidate As Boolean
    Public kotdetails As String
    Public strexcelpath As String
    Public kotupdate As Boolean
    Public MDIParentobj As Object
    Public gSQLString As String
    Public M_Groupby As String
    Public gridviewstatus As String
    Public gridviewHeading(5) As String
    Public rac As Integer
    Public dblMsg As Double
    Public DASH As String
    Dim FocusSetting
    Public MatchTable As DataTable
    Public gridviewPos As String
    Public gCenterlized As String
    Public GbatchNo As Long
    Public gMAINCompanyname As String
    Public strFinancialYearStart, strFinancialYearEnd, sysdate As DateTime
    Public gFinancialEnd As String
    Public vrowcnt As Int16
    Public keyfield As String
    Public M_WhereCondition As String
    Public brows As Boolean
    Public strSqlString As String
    Public gUsername As String
    Public gPrint As Boolean
    Public AppPath As String
    Public SQLSTRING As String
    Public BOOKINGNO As String
    Public gCompanyname As String
    Public gCompanyAddress(10) As String
    Public gDatabase As String
    Public gDivCode As String
    Public gDivName As String
    Public gSeasion As String
    Public gUserCategory As String
    Public wemp1, wemp2, wemp3 As String
    Public Reportsql As String
    Public tables As String
    Public Gheader As String
    Public gCompName As String
    Public gserver, SQL_UserName, SQL_Password, strDataSqlUsr, strDataSqlPwd As String

    Public gdataset As New DataSet
    Public gdreader As SqlDataReader
    Public gadapter As SqlDataAdapter
    Public gcommand As SqlCommand
    Public gfstream As FileStream
    Public gtrans As SqlTransaction
    Public Billstatusbool As Boolean
    Public Accountpostingbool As Boolean
    Public AutoServicebillbool As Boolean
    Public itemtypebool As Boolean
    Public itemmasterbool As Boolean
    Public GroupMasterbool As Boolean
    Public Paymentmodebool As Boolean
    Public POSMastbool As Boolean
    Public RateMastbool As Boolean
    Public UOMRelabool As Boolean
    Public ServerMastbool As Boolean
    Public StewardMastbool As Boolean
    Public TableMastbool As Boolean
    Public Possetupbool As Boolean
    Public UOMMastbool As Boolean
    Public UserAdminbool As Boolean
    Public gFinancalyearStart As String
    Public gFinancialYearEnd As String
    Public gFinancialyearStart As Date
    Public gFinancialyearEnding As Date
    Public subpaymentmodebool As Boolean
    Public posdocumentbool As Boolean
    Public vOutfile, vheader, vLine As String
    Public Filewrite As StreamWriter
    Public VFilePath As String
    Public printfile As String
    Public kotentrybool As Boolean
    Public finalbillbool As Boolean
    Public manualbillbool As Boolean
    Public cashreceiptbool As Boolean
    Public Printername As String
    Public computername As String
    Public Search As String
    Public MyCompanyName As String
    Public PartyCompanyName As String
    Public gShortName As String = "SC"
    Public Address1 As String
    Public Address2 As String
    Public gCity As String
    Public gState As String
    Public gPincode, gphoneno As String
    Public BillPrefix As String
    Public DefaultPayment As String
    Public PrintTaxheading1 As String
    Public PrintTaxheading2 As String
    Public gCreditors As String
    Public gDebitors As String
    Public GmoduleName As String
    '--------------------
    'Public CompanyName, CompanyAddress, ReportTitle, Pageno As String
    'Public ServerName As String = "csc_final"
    Public CORPORATE_TRUE As Boolean
    Public PRINTREP As Boolean
    Public menustatus As String
    Public boolexp1 As Boolean
    Public categorybool As Boolean
    Public corporatebool As Boolean
    Public supscriptionbool As Boolean
    Public masterbool As Boolean
    Public PODdetailsbool As Boolean
    Public photoIDdetailsbool As Boolean
    Public subscriptiontaggingbool As Boolean
    Public statusconversionbool As Boolean
    Public listop As String
    Public ReportTitle, CompanyName, CompanyAddress As String

    Public ServerName As String

    'for version information

    'begin
    Public POS_RATE_GBL, BILLAMT_GBL As Double 'BILL_AMT WITH TAX
    Public Filepath As String
    Public FileSize As Long
    Public dtCreationDate As DateTime
    Public dtLastAccessTime As DateTime
    Public dtLastWriteTime As DateTime
    Public GModule As String = "SpecialParty"
    Public GVerValidate As Boolean = True
    'end
    Public gKotType, gKotPrefix, gPayMode, gTableReq, gWaiterReq As String
    Public pCenterlized, pKotType, pKotPrefix, pPayMode, pTableReq, pWaiterReq, RoundYN As String
    Public gPackPer, gTipsPer, gAdCgsPer, gPartyPer, gRoomPer As Double
    Public pPackPer, pTipsPer, pAdCgsPer, pPartyPer, pRoomPer As Double
    Public RndVal As Double

    Public ClubStateCode, FloodTaxCode As String

End Module
