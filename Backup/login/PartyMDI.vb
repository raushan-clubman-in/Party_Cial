Public Class PartyMDI
    Inherits System.Windows.Forms.Form
    Dim globalclass As New GlobalClass
    Dim gconnection As New GlobalClass
    Dim sqlString As String
#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents submnu_MemberCategory As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_MemberCorporate As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_MemberSubscription As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_MemberMaster As System.Windows.Forms.MenuItem
    Friend WithEvents menu_Master As System.Windows.Forms.MenuItem
    Friend WithEvents menu_Transaction As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_PODdetails As System.Windows.Forms.MenuItem
    Friend WithEvents submnu_StatusConversion As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents submenu_uommaster As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents close_EXIT As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem26 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem27 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem30 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem32 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem33 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem34 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem31 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem35 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem36 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem37 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem38 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem39 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem40 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PartyMDI))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.menu_Master = New System.Windows.Forms.MenuItem
        Me.MenuItem18 = New System.Windows.Forms.MenuItem
        Me.submnu_MemberCategory = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.submnu_MemberCorporate = New System.Windows.Forms.MenuItem
        Me.submenu_uommaster = New System.Windows.Forms.MenuItem
        Me.MenuItem24 = New System.Windows.Forms.MenuItem
        Me.MenuItem25 = New System.Windows.Forms.MenuItem
        Me.submnu_MemberMaster = New System.Windows.Forms.MenuItem
        Me.MenuItem22 = New System.Windows.Forms.MenuItem
        Me.MenuItem32 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem33 = New System.Windows.Forms.MenuItem
        Me.submnu_MemberSubscription = New System.Windows.Forms.MenuItem
        Me.MenuItem36 = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.menu_Transaction = New System.Windows.Forms.MenuItem
        Me.submnu_PODdetails = New System.Windows.Forms.MenuItem
        Me.MenuItem34 = New System.Windows.Forms.MenuItem
        Me.MenuItem31 = New System.Windows.Forms.MenuItem
        Me.MenuItem35 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.MenuItem29 = New System.Windows.Forms.MenuItem
        Me.MenuItem27 = New System.Windows.Forms.MenuItem
        Me.submnu_StatusConversion = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.MenuItem39 = New System.Windows.Forms.MenuItem
        Me.MenuItem38 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem23 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem28 = New System.Windows.Forms.MenuItem
        Me.MenuItem30 = New System.Windows.Forms.MenuItem
        Me.MenuItem37 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.MenuItem17 = New System.Windows.Forms.MenuItem
        Me.close_EXIT = New System.Windows.Forms.MenuItem
        Me.MenuItem26 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem40 = New System.Windows.Forms.MenuItem
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menu_Master, Me.menu_Transaction, Me.MenuItem4, Me.MenuItem14, Me.close_EXIT, Me.MenuItem3})
        '
        'menu_Master
        '
        Me.menu_Master.Index = 0
        Me.menu_Master.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem18, Me.submnu_MemberCategory, Me.MenuItem19, Me.submnu_MemberCorporate, Me.submenu_uommaster, Me.MenuItem24, Me.MenuItem25, Me.submnu_MemberMaster, Me.MenuItem22, Me.MenuItem32, Me.MenuItem6, Me.MenuItem33, Me.submnu_MemberSubscription, Me.MenuItem36, Me.MenuItem21, Me.MenuItem20})
        Me.menu_Master.Text = " &Master                                                 "
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 0
        Me.MenuItem18.Text = "Banquet Hall Session Master"
        '
        'submnu_MemberCategory
        '
        Me.submnu_MemberCategory.Index = 1
        Me.submnu_MemberCategory.Shortcut = System.Windows.Forms.Shortcut.CtrlH
        Me.submnu_MemberCategory.Text = "Banquet Hall Master"
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 2
        Me.MenuItem19.Shortcut = System.Windows.Forms.Shortcut.CtrlM
        Me.MenuItem19.Text = "Banquet Group Master"
        '
        'submnu_MemberCorporate
        '
        Me.submnu_MemberCorporate.Index = 3
        Me.submnu_MemberCorporate.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.submnu_MemberCorporate.Text = "Banquet &Sub Group Master"
        '
        'submenu_uommaster
        '
        Me.submenu_uommaster.Index = 4
        Me.submenu_uommaster.Shortcut = System.Windows.Forms.Shortcut.CtrlU
        Me.submenu_uommaster.Text = "Banquet  &Uom Master"
        '
        'MenuItem24
        '
        Me.MenuItem24.Index = 5
        Me.MenuItem24.Text = "Banquet Group And sub-Group Integration"
        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 6
        Me.MenuItem25.Text = "Banquet Menu Master"
        '
        'submnu_MemberMaster
        '
        Me.submnu_MemberMaster.Index = 7
        Me.submnu_MemberMaster.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Me.submnu_MemberMaster.Text = "Banquet Item Master"
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 8
        Me.MenuItem22.Shortcut = System.Windows.Forms.Shortcut.CtrlL
        Me.MenuItem22.Text = "Banquet Hall Cancellation Master"
        '
        'MenuItem32
        '
        Me.MenuItem32.Index = 9
        Me.MenuItem32.Text = "Banquet Head Receipt Master"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 10
        Me.MenuItem6.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.MenuItem6.Text = "&Arrangement Item  Master "
        Me.MenuItem6.Visible = False
        '
        'MenuItem33
        '
        Me.MenuItem33.Index = 11
        Me.MenuItem33.Text = "Payment Mode Allocation"
        Me.MenuItem33.Visible = False
        '
        'submnu_MemberSubscription
        '
        Me.submnu_MemberSubscription.Index = 12
        Me.submnu_MemberSubscription.Shortcut = System.Windows.Forms.Shortcut.CtrlT
        Me.submnu_MemberSubscription.Text = "&Tax Type Master"
        Me.submnu_MemberSubscription.Visible = False
        '
        'MenuItem36
        '
        Me.MenuItem36.Index = 13
        Me.MenuItem36.Text = "GL acccount Master"
        Me.MenuItem36.Visible = False
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 14
        Me.MenuItem21.Shortcut = System.Windows.Forms.Shortcut.CtrlG
        Me.MenuItem21.Text = "Cate&gory Master"
        Me.MenuItem21.Visible = False
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 15
        Me.MenuItem20.Shortcut = System.Windows.Forms.Shortcut.CtrlL
        Me.MenuItem20.Text = "Banquet Location Master"
        Me.MenuItem20.Visible = False
        '
        'menu_Transaction
        '
        Me.menu_Transaction.Index = 1
        Me.menu_Transaction.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.submnu_PODdetails, Me.MenuItem34, Me.MenuItem31, Me.MenuItem35, Me.MenuItem11, Me.MenuItem29, Me.MenuItem27, Me.submnu_StatusConversion})
        Me.menu_Transaction.Text = "&Transactions                                   "
        '
        'submnu_PODdetails
        '
        Me.submnu_PODdetails.Index = 0
        Me.submnu_PODdetails.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.submnu_PODdetails.Text = "Banquet Hall Reservation"
        '
        'MenuItem34
        '
        Me.MenuItem34.Index = 1
        Me.MenuItem34.Text = "Banquet Receipt Entry"
        '
        'MenuItem31
        '
        Me.MenuItem31.Index = 2
        Me.MenuItem31.Text = "Banquet Menu Booking"
        '
        'MenuItem35
        '
        Me.MenuItem35.Index = 3
        Me.MenuItem35.Text = "Banquet Billing"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 4
        Me.MenuItem11.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.MenuItem11.Text = "Banquet  &Availability Check"
        '
        'MenuItem29
        '
        Me.MenuItem29.Index = 5
        Me.MenuItem29.Text = "Banquet Items Tagging"
        '
        'MenuItem27
        '
        Me.MenuItem27.Index = 6
        Me.MenuItem27.Text = "Consumption entry"
        Me.MenuItem27.Visible = False
        '
        'submnu_StatusConversion
        '
        Me.submnu_StatusConversion.Index = 7
        Me.submnu_StatusConversion.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.submnu_StatusConversion.Text = "CANCEL"
        Me.submnu_StatusConversion.Visible = False
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem8, Me.MenuItem9, Me.MenuItem39, Me.MenuItem38, Me.MenuItem7, Me.MenuItem23, Me.MenuItem10, Me.MenuItem2, Me.MenuItem1, Me.MenuItem12, Me.MenuItem13, Me.MenuItem5, Me.MenuItem28, Me.MenuItem30, Me.MenuItem37, Me.MenuItem40})
        Me.MenuItem4.Text = "&Reports                                  "
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 0
        Me.MenuItem8.Text = "Banquet Availablity List"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 1
        Me.MenuItem9.Text = "Banquet Bill Details"
        '
        'MenuItem39
        '
        Me.MenuItem39.Index = 2
        Me.MenuItem39.Text = "Banquet  Sales LocationWise"
        '
        'MenuItem38
        '
        Me.MenuItem38.Index = 3
        Me.MenuItem38.Text = "Banquet Reservation Details"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 4
        Me.MenuItem7.Text = "Banquet Cancel details"
        '
        'MenuItem23
        '
        Me.MenuItem23.Index = 5
        Me.MenuItem23.Text = "Banquet Itemwise Sales"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 6
        Me.MenuItem10.Text = "Special Party Bill Register"
        Me.MenuItem10.Visible = False
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 7
        Me.MenuItem2.Text = "Special Party Bill Pending"
        Me.MenuItem2.Visible = False
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 8
        Me.MenuItem1.Text = "Item Wise Customer List"
        Me.MenuItem1.Visible = False
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 9
        Me.MenuItem12.Text = "Date Wise Party Register"
        Me.MenuItem12.Visible = False
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 10
        Me.MenuItem13.Text = "Item Wise Sale Register"
        Me.MenuItem13.Visible = False
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 11
        Me.MenuItem5.Text = "Special Party Void Status"
        Me.MenuItem5.Visible = False
        '
        'MenuItem28
        '
        Me.MenuItem28.Index = 12
        Me.MenuItem28.Text = "Party Bar Consumption "
        Me.MenuItem28.Visible = False
        '
        'MenuItem30
        '
        Me.MenuItem30.Index = 13
        Me.MenuItem30.Text = "Party Maintaince Details"
        Me.MenuItem30.Visible = False
        '
        'MenuItem37
        '
        Me.MenuItem37.Index = 14
        Me.MenuItem37.Text = "Party  Groupwise Report"
        Me.MenuItem37.Visible = False
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 3
        Me.MenuItem14.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem15, Me.MenuItem16, Me.MenuItem17})
        Me.MenuItem14.Text = "&Utility                                       "
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 0
        Me.MenuItem15.Shortcut = System.Windows.Forms.Shortcut.F12
        Me.MenuItem15.Text = "Select Company"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 1
        Me.MenuItem16.Text = "Calculator"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 2
        Me.MenuItem17.Text = "Notepad"
        '
        'close_EXIT
        '
        Me.close_EXIT.Index = 4
        Me.close_EXIT.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem26})
        Me.close_EXIT.Text = "&Exit"
        '
        'MenuItem26
        '
        Me.MenuItem26.Index = 0
        Me.MenuItem26.Text = "Close"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 5
        Me.MenuItem3.Text = ""
        '
        'MenuItem40
        '
        Me.MenuItem40.Index = 15
        Me.MenuItem40.Text = "Banquet Menulist"
        '
        'PartyMDI
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1026, 723)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "PartyMDI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BANQUET MODULE"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized

    End Sub

#End Region

    Public Sub Clearfiles()
        AppPath = Application.StartupPath
        Shell("CLEAR.BAT", AppWinStyle.Hide)
    End Sub
    Private Sub Activateuseradmin()
        Dim totmenu As Integer = 0
        Dim i, j, k, ckhmn, ckhmn1 As Integer
        Call menublock()
        For i = 0 To MainMenu1.MenuItems.Count - 2
            ckhmn1 = MainMenu1.MenuItems(i).MenuItems.Count()
            If ckhmn1 <> 0 Then
                For j = 0 To MainMenu1.MenuItems(i).MenuItems.Count() - 1
                    ckhmn = MainMenu1.MenuItems(i).MenuItems(j).MenuItems.Count()
                    If ckhmn <> 0 Then
                        For k = 0 To MainMenu1.MenuItems(i).MenuItems(j).MenuItems.Count() - 1
                            totmenu = totmenu + 1
                        Next
                    Else
                        totmenu = totmenu + 1
                    End If
                Next
            Else
                totmenu = totmenu + 1
            End If
        Next
        gconnection.getDataSet("SELECT COUNT(*) FROM  modulemaster WHERE PackageName='SPECIALPARTY'", "chk")
        If gdataset.Tables("chk").Rows.Count <> totmenu Then
            gconnection.ExcuteStoreProcedure("DELETE FROM modulemaster WHERE PackageName='SPECIALPARTY'")
            Call checkmenulist()
        End If
        If gUserCategory = "S" Or gUserCategory = "A" Then
            Call menuclear()
        Else
            Call relemenu()
        End If
    End Sub
    Sub menuclear()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        vmain = MainMenu1.MenuItems.Count
        For i = 0 To vmain - 2
            vsmod = MainMenu1.MenuItems(i).MenuItems.Count
            If vsmod <> 0 Then
                For j = 0 To vsmod - 1
                    vssmod = MainMenu1.MenuItems(i).MenuItems(j).MenuItems.Count
                    If vssmod <> 0 Then
                        For k = 0 To vssmod - 1
                            MainMenu1.MenuItems(i).MenuItems(j).MenuItems(k).Enabled = True
                        Next
                    Else
                        MainMenu1.MenuItems(i).MenuItems(j).Enabled = True
                    End If
                Next
            Else
                MainMenu1.MenuItems(i).Enabled = True
            End If
        Next
    End Sub
    Sub menublock()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        vmain = MainMenu1.MenuItems.Count
        For i = 0 To vmain - 2
            vsmod = MainMenu1.MenuItems(i).MenuItems.Count
            If vsmod <> 0 Then
                For j = 0 To vsmod - 1
                    vssmod = MainMenu1.MenuItems(i).MenuItems(j).MenuItems.Count
                    If vssmod <> 0 Then
                        For k = 0 To vssmod - 1
                            MainMenu1.MenuItems(i).MenuItems(j).MenuItems(k).Enabled = False
                        Next
                    Else
                        MainMenu1.MenuItems(i).MenuItems(j).Enabled = False
                    End If
                Next
            Else
                MainMenu1.MenuItems(i).Enabled = False
            End If
        Next
    End Sub
    Sub relemenu()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql As String
        Dim ds As New DataSet
        Dim chstr As String
        gconnection.getDataSet("SELECT * FROM USERADMIN WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY'", "user")
        If gdataset.Tables("user").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("user").Rows.Count - 1
                With gdataset.Tables("user").Rows(i)
                    If Trim(.Item("mainmoduleid") & "") <> "" And Trim(.Item("submoduleid") & "") <> "" And Trim(.Item("ssubmoduleid") & "") <> "" Then
                        MainMenu1.MenuItems(Val(.Item("mainmoduleid"))).MenuItems(Val(.Item("submoduleid"))).MenuItems(Val(.Item("ssubmoduleid"))).Enabled = True
                        chstr = abcdMINUS(.Item("rights"))
                    ElseIf Trim(.Item("mainmoduleid") & "") <> "" And Trim(.Item("submoduleid") & "") <> "" Then
                        MainMenu1.MenuItems(Val(.Item("mainmoduleid"))).MenuItems(Val(.Item("submoduleid"))).Enabled = True
                        chstr = abcdMINUS(.Item("rights"))
                    ElseIf Trim(.Item("mainmoduleid") & "") <> "" Then
                        MainMenu1.MenuItems(Val(.Item("mainmoduleid"))).Enabled = True
                        chstr = abcdMINUS(.Item("rights"))
                    End If
                End With
            Next
        End If
    End Sub
    Public Sub checkmenulist()
        Dim i, j, k, x As Integer
        Dim vsql() As String
        Dim vmain, vsmod, vssmod As Long
        x = 0
        ReDim vsql(x)
        vmain = MainMenu1.MenuItems.Count
        If vmain <> 0 Then
            For i = 0 To vmain - 2
                vsmod = MainMenu1.MenuItems(i).MenuItems.Count
                If vsmod <> 0 Then
                    For j = 0 To vsmod - 1
                        vssmod = MainMenu1.MenuItems(i).MenuItems(j).MenuItems.Count
                        If vssmod <> 0 Then
                            For k = 0 To vssmod - 1
                                If MainMenu1.MenuItems(i).MenuItems(j).MenuItems(k).Visible = True Then
                                    vsql(vsql.Length - 1) = "insert into Modulemaster(Mainmoduleid,MainModulename,SubModuleid,SubModulename,SsubModuleid,SsubModuleName,PackageName) values "
                                    vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & " ('" & i & "','" & Trim(MainMenu1.MenuItems(i).Text.Replace("&", "") & "") & "',"
                                    vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'" & j & "','" & Trim(MainMenu1.MenuItems(i).MenuItems(j).Text.Replace("&", "") & "") & "',"
                                    vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'" & k & "','" & Trim(MainMenu1.MenuItems(i).MenuItems(j).MenuItems(k).Text.Replace("&", "") & "") & "','SPECIALPARTY')"
                                    ReDim Preserve vsql(vsql.Length)
                                End If
                            Next
                        Else
                            If MainMenu1.MenuItems(i).MenuItems(j).Visible = True Then
                                vsql(vsql.Length - 1) = "insert into Modulemaster(Mainmoduleid,MainModulename,SubModuleid,SubModulename,SsubModuleid,SsubModuleName,PackageName ) values "
                                vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & " ('" & i & "','" & Trim(MainMenu1.MenuItems(i).Text.Replace("&", "") & "") & "',"
                                vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'" & j & "','" & Trim(MainMenu1.MenuItems(i).MenuItems(j).Text.Replace("&", "") & "") & "',"
                                vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'','','SPECIALPARTY')"
                                ReDim Preserve vsql(vsql.Length)
                            End If
                        End If
                    Next
                Else
                    If MainMenu1.MenuItems(i).Visible = True Then
                        vsql(vsql.Length - 1) = "insert into Modulemaster(Mainmoduleid,MainModulename,SubModuleid,SubModulename,SsubModuleid,SsubModuleName,PackageName) values "
                        vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & " ('" & i & "','" & Trim(MainMenu1.MenuItems(i).Text.Replace("&", "") & "") & "',"
                        vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'','',"
                        vsql(vsql.Length - 1) = vsql(vsql.Length - 1) & "'','','SPECIALPARTY')"
                        ReDim Preserve vsql(vsql.Length)
                    End If
                End If
            Next
            ReDim Preserve vsql(vsql.Length - 2)
            gconnection.MoreTrans1(vsql)
        End If
    End Sub

    Private Sub submnu_MemberCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_MemberCategory.Click
        If UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then
            Dim objhallmst As New ASCA_HALLMASTER
            GModule = "Banquet Hall Master"
            objhallmst.MdiParent = Me
            objhallmst.Show()
        Else
            Dim objhallmst As New PTY_HALLMASTER
            GModule = "Banquet Hall Master"
            objhallmst.MdiParent = Me
            objhallmst.Show()
        End If
    End Sub
    Private Sub submnu_MemberSubscription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_MemberSubscription.Click
        Dim objitemtype As New ItemType
        GmoduleName = "Tax Type Master"
        If supscriptionbool = False And submnu_MemberSubscription.Checked = True Then

            objitemtype.Show()
            objitemtype.MdiParent = Me
            submnu_MemberSubscription.Checked = True
            Exit Sub
        End If
        If submnu_MemberSubscription.Checked = True Then
            Exit Sub
        End If
        objitemtype.Show()
        objitemtype.MdiParent = Me
        submnu_MemberSubscription.Checked = True
    End Sub
    Private Sub submnu_MemberMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_MemberMaster.Click
        Dim objItemmst As New itemmst
        GmoduleName = "Banquet Item Master"
        If masterbool = False And submnu_MemberMaster.Checked = True Then
            objItemmst.Show()
            objItemmst.MdiParent = Me
            submnu_MemberMaster.Checked = True
            Exit Sub
        End If
        If submnu_MemberMaster.Checked = True Then
            Exit Sub
        End If
        objItemmst.Show()
        objItemmst.MdiParent = Me
        submnu_MemberMaster.Checked = True
    End Sub
    Private Sub PartyMDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        AppPath = Application.StartupPath
        'version control
        'begin

        'Dim sql As String
        'sql = "select * FROM Master..CLUBMANVERSION Where ModuleName='" & GModule & "' AND DATEOFVERSION>'" & Format(dtLastWriteTime, "dd/MMM/yyyy hh:mm:ss") & "'"
        'gconnection.getDataSet(sql, "FileValidate")
        'If gdataset.Tables("FileValidate").Rows.Count > 0 Then
        '    MsgBox("You are Using Older Version, Kindly Update New Version with the help of System Admin...", MsgBoxStyle.OKOnly, "Version Change")
        'End If
        'end

        Shell("CLEAR.BAT", AppWinStyle.Hide)
        Call Activateuseradmin()


        Me.Text = "BANQUET MODULE    " & MyCompanyName & " : " & gFinancalyearStart & "-" & gFinancialYearEnd & "          USER NAME    :" & gUsername & "                          DATABASE NAME   :" & gDatabase

        ''Me.Text = MyCompanyName & "                                USER NAME :   " & gUsername
        Call Log_User()

    End Sub
    Public Sub Log_User()
        Dim LStr As String
        LStr = "INSERT INTO LOGING_USER(USERNAME,LOGDATE,LOGTIME,MODULE,TYPE)"
        LStr = LStr & "VALUES('" & gUsername & "','" & Format(Now(), "dd-MMM-yyyy") & "','" & Format(Now(), "T") & "','SMART CARD','LOGIN')"
        gconnection.dataOperation(10, LStr, "LOGING")
    End Sub
    Public Sub LogOut_User()
        Dim LStr As String
        LStr = "INSERT INTO LOGING_USER(USERNAME,LOGDATE,LOGTIME,MODULE,TYPE)"
        LStr = LStr & "VALUES('" & gUsername & "','" & Format(Now(), "dd-MMM-yyyy") & "','" & Format(Now(), "T") & "','SMART CARD','LOGOUT')"
        gconnection.dataOperation(10, LStr, "LOGING")
    End Sub


    Private Sub menu_Master_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles menu_Master.Select
        If categorybool = False Then
            submnu_MemberCategory.Checked = False
        End If
        If corporatebool = False Then
            submnu_MemberCorporate.Checked = False
        End If

        If supscriptionbool = False Then
            submnu_MemberSubscription.Checked = False
        End If

        If masterbool = False Then
            submnu_MemberMaster.Checked = False
        End If
    End Sub
    Private Sub submnu_PODdetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_PODdetails.Click
        Dim objhallstatus As New Hallstatus
        GmoduleName = "Banquet Hall Reservation"
        If PODdetailsbool = False And submnu_PODdetails.Checked = True Then
            objhallstatus.Show()
            objhallstatus.MdiParent = Me
            submnu_PODdetails.Checked = True
            Exit Sub
        End If
        If submnu_PODdetails.Checked = True Then
            Exit Sub
        End If
        objhallstatus.Show()
        objhallstatus.MdiParent = Me
        submnu_PODdetails.Checked = True
    End Sub
    Private Sub submnu_PhotoIddetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim objbooking As New booking
        'If photoIDdetailsbool = False And submnu_PhotoIddetails.Checked = True Then
        '    objbooking.Show()
        '    objbooking.MdiParent = Me
        '    submnu_MemberCategory.Checked = True
        '    Exit Sub
        'End If
        'If submnu_PhotoIddetails.Checked = True Then
        '    Exit Sub
        'End If
        'objbooking.Show()
        'objbooking.MdiParent = Me
        'submnu_PhotoIddetails.Checked = True
    End Sub
    Private Sub submnu_StatusConversion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_StatusConversion.Click
        Dim objbillCANCEL As New PARTYCANCEL
        GmoduleName = "CANCEL"
        If statusconversionbool = False And submnu_StatusConversion.Checked = True Then
            objbillCANCEL.Show()
            objbillCANCEL.StartPosition = 0
            objbillCANCEL.MdiParent = Me
            submnu_StatusConversion.Checked = True
            Exit Sub
        End If
        If submnu_StatusConversion.Checked = True Then
            Exit Sub
        End If
        objbillCANCEL.Show()
        objbillCANCEL.MdiParent = Me
        submnu_StatusConversion.Checked = True
        'Dim objbill As New MemberMaster

    End Sub
    Private Sub SubsubmenuFirstReminderLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        Dim objSubsRepFilter As New HALLMST
        '       Dim ReportFilterObj As New HALLMST
        'RepSqlStr = "First Reminder Letter"
        'ReportTitle = "First Reminder Letter"
        'ReportFilterObj.DLabel.Text = "First Reminder Letter"
        If statusconversionbool = False And submnu_StatusConversion.Checked = True Then
            '          objSubsRepFilter.Show()
            '         objSubsRepFilter.MdiParent = Me
            submnu_StatusConversion.Checked = True
            Exit Sub
        End If
        If submnu_StatusConversion.Checked = True Then
            Exit Sub
        End If
        '    objSubsRepFilter.MdiParent = Me
        submnu_StatusConversion.Checked = True
        '   objSubsRepFilter.Show()
        'Try
        '    Dim ReportFilterObj As New ReportFilter
        '    RepSqlStr = "First Reminder Letter"
        '    ReportFilterObj.MdiParent = Me
        '    ReportFilterObj.DLabel.Text = "First Reminder Letter"
        '    ReportFilterObj.Text = RepSqlStr
        '    ReportFilterObj.Show()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'Dim sqlstring As String = "SELECT dbo.MemberType.TypeDesc, dbo.MemberMaster.Prefix, dbo.MemberMaster.MNAME, dbo.MemberMaster.CONTADD1, dbo.MemberMaster.CONTADD2, "
        'sqlstring = sqlstring & " dbo.MemberMaster.CONTADD3, dbo.MemberMaster.CONTCITY, dbo.MemberMaster.CONTPIN, dbo.MemberMaster.CONTSTATE, "
        'sqlstring = sqlstring & " dbo.SubscriptinSummery.QUTERDATE, dbo.SubscriptinSummery.VRNO, dbo.SubscriptinSummery.ARREAR, dbo.SubscriptinSummery.DUEDATE"
        'sqlstring = sqlstring & " ISNULL((SELECT SUM(REALVALUE-ADJUSTED) FROM OUTSTANDING WHERE  SLCODE=SUBSCRIPTION_SUMMARY_VIEW.MCODE),0) AS Arrear"
        'sqlstring = sqlstring & " FROM         dbo.SubscriptinSummery INNER JOIN"
        'sqlstring = sqlstring & " dbo.MemberMaster ON dbo.SubscriptinSummery.SUBCD = dbo.MemberMaster.MCODE INNER JOIN"
        'sqlstring = sqlstring & " dbo.MemberType ON dbo.MemberMaster.MEMBERTYPECODE = dbo.MemberType.Membertype"
        'sqlstring = sqlstring & " WHERE(dbo.SubscriptinSummery.ARREAR <> 0)"

        'MODIFIED BY SRINIVAS N**************************************************************************************
        ''''Dim sqlstring As String = "SELECT     dbo.MemberType.TypeDesc, dbo.MemberMaster.Prefix, dbo.SUBSCRIPTION_SUMMARY_VIEW.MNAME, dbo.MemberMaster.CONTADD1, "
        ''''sqlstring = sqlstring & " dbo.MemberMaster.CONTADD2, dbo.MemberMaster.CONTADD3, dbo.MemberMaster.CONTCITY, dbo.MemberMaster.CONTPIN, "
        ''''sqlstring = sqlstring & " dbo.MemberMaster.CONTSTATE, dbo.SUBSCRIPTION_SUMMARY_VIEW.QUTERDATE, dbo.SUBSCRIPTION_SUMMARY_VIEW.VRNO,"
        ''''sqlstring = sqlstring & " (SELECT     SUM(REALVALUE - ISNULL(ADJUSTED, 0))"
        ''''sqlstring = sqlstring & " FROM OUTSTANDING"
        ''''sqlstring = sqlstring & " WHERE      SLCODE = SUBSCRIPTION_SUMMARY_VIEW.MCODE) AS ARREAR,"
        ''''sqlstring = sqlstring & " dbo.SUBSCRIPTION_SUMMARY_VIEW.DUEDATE"
        ''''sqlstring = sqlstring & " FROM         dbo.MemberMaster INNER JOIN"
        ''''sqlstring = sqlstring & " dbo.MemberType ON dbo.MemberMaster.MEMBERTYPECODE = dbo.MemberType.Membertype INNER JOIN"
        ''''sqlstring = sqlstring & " dbo.SUBSCRIPTION_SUMMARY_VIEW INNER JOIN"
        ''''sqlstring = sqlstring & " dbo.outstanding ON dbo.SUBSCRIPTION_SUMMARY_VIEW.VRNO = dbo.outstanding.VoucherNo ON "
        ''''sqlstring = sqlstring & " dbo.MemberMaster.MCODE = dbo.SUBSCRIPTION_SUMMARY_VIEW.MCODE"
        ''''sqlstring = sqlstring & " ORDER BY"
        ''''sqlstring = sqlstring & " dbo.SUBSCRIPTION_SUMMARY_VIEW.MNAME"
        '''''**************************************************************************************************************************
        ''''Dim letter As String = "FIRST REMINDER LETTER"
        ''''Dim ReminderLetterObj As New ReminderLetter
        ''''ReminderLetterObj.begin()
        ''''ReminderLetterObj.buttonclick(globalclass.sqlconnection, sqlstring, letter)
    End Sub
    Private Sub SubsubmenuSecondReminderLetter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''Dim objSubsRepFilter As New SubsRepFilter
        ''Dim ReportFilterObj As New ReportFilter
        ''RepSqlStr = "Second Reminder Letter"
        'ReportTitle = "Second Reminder Letter"
        'ReportFilterObj.DLabel.Text = "Second Reminder Letter"
        'If statusconversionbool = False And submnu_StatusConversion.Checked = True Then
        '    objSubsRepFilter.Show()
        '    objSubsRepFilter.MdiParent = Me
        '    submnu_StatusConversion.Checked = True
        '    Exit Sub
        'End If
        'If submnu_StatusConversion.Checked = True Then
        '    Exit Sub
        'End If
        'objSubsRepFilter.Show()
        'objSubsRepFilter.MdiParent = Me
        'submnu_StatusConversion.Checked = True
        '''Dim reminderletter As New ReminderLetter
        ''''Dim sqlstring As String = "SELECT dbo.MemberType.TypeDesc, dbo.MemberMaster.Prefix, dbo.MemberMaster.MNAME, dbo.MemberMaster.CONTADD1, dbo.MemberMaster.CONTADD2, "
        ''''sqlstring = sqlstring & " dbo.MemberMaster.CONTADD3, dbo.MemberMaster.CONTCITY, dbo.MemberMaster.CONTPIN, dbo.MemberMaster.CONTSTATE, "
        ''''sqlstring = sqlstring & " dbo.SubscriptinSummery.QUTERDATE, dbo.SubscriptinSummery.VRNO, dbo.SubscriptinSummery.ARREAR, dbo.SubscriptinSummery.DUEDATE"
        ''''sqlstring = sqlstring & " FROM         dbo.SubscriptinSummery INNER JOIN"
        ''''sqlstring = sqlstring & " dbo.MemberMaster ON dbo.SubscriptinSummery.SUBCD = dbo.MemberMaster.MCODE INNER JOIN"
        ''''sqlstring = sqlstring & " dbo.MemberType ON dbo.MemberMaster.MEMBERTYPECODE = dbo.MemberType.Membertype"
        ''''sqlstring = sqlstring & " WHERE(dbo.SubscriptinSummery.ARREAR <> 0)"
        '''' MODIFIED BY SRINIVAS N******************************************************************************************
        '''Dim sqlstring As String = "SELECT     dbo.MemberType.TypeDesc, dbo.MemberMaster.Prefix, dbo.SUBSCRIPTION_SUMMARY_VIEW.MNAME, dbo.MemberMaster.CONTADD1, "
        '''sqlstring = sqlstring & " dbo.MemberMaster.CONTADD2, dbo.MemberMaster.CONTADD3, dbo.MemberMaster.CONTCITY, dbo.MemberMaster.CONTPIN, "
        '''sqlstring = sqlstring & " dbo.MemberMaster.CONTSTATE, dbo.SUBSCRIPTION_SUMMARY_VIEW.QUTERDATE, dbo.SUBSCRIPTION_SUMMARY_VIEW.VRNO,"
        '''sqlstring = sqlstring & " (SELECT     SUM(REALVALUE - ISNULL(ADJUSTED, 0))"
        '''sqlstring = sqlstring & " FROM OUTSTANDING"
        '''sqlstring = sqlstring & " WHERE      SLCODE = SUBSCRIPTION_SUMMARY_VIEW.MCODE) AS ARREAR,"
        '''sqlstring = sqlstring & " dbo.SUBSCRIPTION_SUMMARY_VIEW.DUEDATE"
        '''sqlstring = sqlstring & " FROM         dbo.MemberMaster INNER JOIN"
        '''sqlstring = sqlstring & " dbo.MemberType ON dbo.MemberMaster.MEMBERTYPECODE = dbo.MemberType.Membertype INNER JOIN"
        '''sqlstring = sqlstring & " dbo.SUBSCRIPTION_SUMMARY_VIEW INNER JOIN"
        '''sqlstring = sqlstring & " dbo.outstanding ON dbo.SUBSCRIPTION_SUMMARY_VIEW.VRNO = dbo.outstanding.VoucherNo ON "
        '''sqlstring = sqlstring & " dbo.MemberMaster.MCODE = dbo.SUBSCRIPTION_SUMMARY_VIEW.MCODE"
        '''sqlstring = sqlstring & " ORDER BY"
        '''sqlstring = sqlstring & " dbo.SUBSCRIPTION_SUMMARY_VIEW.MNAME"
        ''''*************************************************************************************************
        '''Dim letter As String = "SECOND REMINDER LETTER"
        '''reminderletter.begin()
        '''reminderletter.buttonclick(globalclass.sqlconnection, sqlstring, letter)
    End Sub
    Private Sub Subsubmenu_FirstReminderList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim objSubsRepFilter As New SubsRepFilter
        'Dim ReportFilterObj As New ReportFilter
        'RepSqlStr = "First Reminder List"
        'ReportTitle = "First Reminder List"
        'ReportFilterObj.DLabel.Text = "First Reminder List"
        'If statusconversionbool = False And submnu_StatusConversion.Checked = True Then
        '    objSubsRepFilter.Show()
        '    objSubsRepFilter.MdiParent = Me
        '    submnu_StatusConversion.Checked = True
        '    Exit Sub
        'End If
        'If submnu_StatusConversion.Checked = True Then
        '    Exit Sub
        'End If
        'objSubsRepFilter.MdiParent = Me
        'submnu_StatusConversion.Checked = True
        'objSubsRepFilter.Show()
        ''''Dim sqlstring As String = "SELECT     TOP 100 PERCENT dbo.MemberType.TypeDesc, dbo.SubscriptinSummery.QUTERDATE, dbo.MemberMaster.MCODE AS MEMCODE, "
        ''''sqlstring = sqlstring & "  dbo.MemberMaster.Prefix, dbo.MemberMaster.MNAME, dbo.SubscriptinSummery.VRNO, dbo.SubscriptinSummery.DUEDATE, "
        ''''sqlstring = sqlstring & "  dbo.SubscriptinSummery.ARREAR"
        ''''sqlstring = sqlstring & "  FROM         dbo.SubscriptinSummery INNER JOIN "
        ''''sqlstring = sqlstring & "  dbo.MemberMaster ON dbo.SubscriptinSummery.SUBCD = dbo.MemberMaster.MCODE INNER JOIN "
        ''''sqlstring = sqlstring & "  dbo.MemberType ON dbo.MemberMaster.MEMBERTYPECODE = dbo.MemberType.Membertype "
        ''''sqlstring = sqlstring & "  GROUP BY dbo.MemberType.TypeDesc, dbo.SubscriptinSummery.QUTERDATE, dbo.MemberMaster.MCODE, dbo.MemberMaster.Prefix, "
        ''''sqlstring = sqlstring & "  dbo.MemberMaster.MNAME, dbo.SubscriptinSummery.VRNO, dbo.SubscriptinSummery.DUEDATE, dbo.SubscriptinSummery.ARREAR, "
        ''''sqlstring = sqlstring & "  dbo.MemberType.Membertype "
        ''''sqlstring = sqlstring & "  HAVING      (dbo.SubscriptinSummery.ARREAR <> 0) "
        ''''sqlstring = sqlstring & "  ORDER BY dbo.MemberType.Membertype, dbo.MemberMaster.MCODE "
        ''''Dim ReminderList As New ReminderList
        ''''Dim arraystring() As String = {"", " FIRST REMINDER LIST ", "", ""}
        ''''Dim heading() As String = {"M CODE", "M Name", "Bill No", "Due Date", "Amount"}
        ''''ReminderList.begin()
        ''''ReminderList.buttonclick(globalclass.sqlconnection, sqlstring, arraystring, heading)
    End Sub
    Private Sub Subsubmenu_SecondReminderList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Dim ReportFilterObj As New ReportFilter
            'RepSqlStr = "Second Reminder List"
            'ReportFilterObj.MdiParent = Me
            'ReportFilterObj.DLabel.Text = "Second Reminder List"
            'ReportFilterObj.Text = RepSqlStr
            'ReportFilterObj.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        ''''Dim sqlstring As String = "SELECT     TOP 100 PERCENT dbo.MemberType.TypeDesc, dbo.SubscriptinSummery.QUTERDATE, dbo.MemberMaster.MCODE AS MEMCODE, "
        ''''sqlstring = sqlstring & "  dbo.MemberMaster.Prefix, dbo.MemberMaster.MNAME, dbo.SubscriptinSummery.VRNO, dbo.SubscriptinSummery.DUEDATE, "
        ''''sqlstring = sqlstring & " SUM(dbo.SubscriptinSummery.ARREAR+100) AS ARREAR"
        ''''sqlstring = sqlstring & "  FROM         dbo.SubscriptinSummery INNER JOIN "
        ''''sqlstring = sqlstring & "  dbo.MemberMaster ON dbo.SubscriptinSummery.SUBCD = dbo.MemberMaster.MCODE INNER JOIN "
        ''''sqlstring = sqlstring & "  dbo.MemberType ON dbo.MemberMaster.MEMBERTYPECODE = dbo.MemberType.Membertype "
        ''''sqlstring = sqlstring & "  GROUP BY dbo.MemberType.TypeDesc, dbo.SubscriptinSummery.QUTERDATE, dbo.MemberMaster.MCODE, dbo.MemberMaster.Prefix, "
        ''''sqlstring = sqlstring & "  dbo.MemberMaster.MNAME, dbo.SubscriptinSummery.VRNO, dbo.SubscriptinSummery.DUEDATE, dbo.SubscriptinSummery.ARREAR, "
        ''''sqlstring = sqlstring & "  dbo.MemberType.Membertype "
        ''''sqlstring = sqlstring & "  HAVING      (dbo.SubscriptinSummery.ARREAR <> 0) "
        ''''sqlstring = sqlstring & "  ORDER BY dbo.MemberType.Membertype, dbo.MemberMaster.MCODE "
        ''''Dim ReminderList As New ReminderList
        ''''Dim arraystring() As String = {"", " SECOND REMINDER LIST ", "", ""}
        ''''Dim heading() As String = {"M CODE", "M Name", "Bill No", "Due Date", "Amount"}
        ''''ReminderList.begin()
        ''''ReminderList.buttonclick(globalclass.sqlconnection, sqlstring, arraystring, heading)
    End Sub

    Private Sub Submenu_SubscriptionBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ''Dim objSubsRepFilter As New SubsRepFilter
        ''RepSqlStr = "Subscription Bill"
        'If statusconversionbool = False And submnu_StatusConversion.Checked = True Then
        '    objSubsRepFilter.Show()
        '    objSubsRepFilter.MdiParent = Me
        '    submnu_StatusConversion.Checked = True
        '    Exit Sub
        'End If
        'If submnu_StatusConversion.Checked = True Then
        '    Exit Sub
        'End If
        'objSubsRepFilter.Show()
        'objSubsRepFilter.MdiParent = Me
        'submnu_StatusConversion.Checked = True

        'Dim sqlstring = "SELECT   dbo.SUBSCRIPTION_SUMMARY_VIEW.Prefix, dbo.SUBSCRIPTION_SUMMARY_VIEW.MNAME, dbo.SUBSCRIPTION_SUMMARY_VIEW.CONTADD1, "
        'sqlstring = sqlstring & " dbo.SUBSCRIPTION_SUMMARY_VIEW.CONTADD2, dbo.SUBSCRIPTION_SUMMARY_VIEW.CONTADD3, "
        'sqlstring = sqlstring & " dbo.SUBSCRIPTION_SUMMARY_VIEW.CONTCITY, dbo.SUBSCRIPTION_SUMMARY_VIEW.CONTPIN, "
        'sqlstring = sqlstring & " dbo.SUBSCRIPTION_SUMMARY_VIEW.CONTSTATE, dbo.SUBSCRIPTION_SUMMARY_VIEW.VRNO, dbo.SUBSCRIPTION_SUMMARY_VIEW.DUEDATE, "
        'sqlstring = sqlstring & " dbo.SUBSCRIPTION_SUMMARY_VIEW.MCODE, dbo.SUBSCRIPTION_SUMMARY_VIEW.TypeDesc, "
        'sqlstring = sqlstring & " dbo.SUBSCRIPTION_SUMMARY_VIEW.QUTERDATE, dbo.SUBSCRIPTION_POSTING_VIEW.SubsDesc, dbo.SUBSCRIPTION_POSTING_VIEW.Total as Amount, "
        'sqlstring = sqlstring & " dbo.SUBSCRIPTION_SUMMARY_VIEW.TOTAL AS TotalAmount,"
        'sqlstring = sqlstring & " (SELECT SUM(REALVALUE-ISNULL(ADJUSTED,0)) FROM OUTSTANDING WHERE  SLCODE=SUBSCRIPTION_SUMMARY_VIEW.MCODE) AS Arrear "
        'sqlstring = sqlstring & " FROM         dbo.SUBSCRIPTION_POSTING_VIEW ,  dbo.SUBSCRIPTION_SUMMARY_VIEW "
        'sqlstring = sqlstring & " WHERE dbo.SUBSCRIPTION_POSTING_VIEW.SUBCD = dbo.SUBSCRIPTION_SUMMARY_VIEW.MCODE "
        ''sqlstring = sqlstring & " and dbo.SUBSCRIPTION_SUMMARY_VIEW.MCODE = 'A00620'"


        'Dim SubscriptionBillingReport As New SubscriptionBillingReport
        'Dim arraystring() As String = {"1,Strand Road", "Kolkatta - 700001", " SUBSCRIPTION BILL ", "", ""}
        'Dim heading() As String = {"M CODE", "M Name", "Bill No", "Due Date", "Amount"}
        'SubscriptionBillingReport.begin()
        'SubscriptionBillingReport.buttonclick(globalclass.sqlconnection, sqlstring, arraystring, heading)
    End Sub
    Private Sub SubMenu_CorporateList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    'ReportTitle = "Corporate Member List"
        '    'Dim ReportFilterObj As New McodeFilter
        '    'RepSqlStr = "Corporate Member List"
        '    'ReportFilterObj.MdiParent = Me
        '    ''ReportFilterObj.DLabel.Text = " Enter Member Code"
        '    'ReportFilterObj.Text = RepSqlStr
        '    'ReportFilterObj.Show()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


    End Sub
    Private Sub SubMenu_AddressList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim ReportFilterObj As ReportFilter
        'Try
        '    Dim ReportFilterObj As New ReportFilter
        '    RepSqlStr = "AddressList"
        '    ReportFilterObj.MdiParent = Me
        '    ReportFilterObj.DLabel.Text = " Enter Member Code"
        '    ReportFilterObj.Text = RepSqlStr
        '    ReportFilterObj.Show()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        '''************dont delete
        'Dim AddressListReport As New AddressListReport
        'Dim sqlstring As String = "select mcode,mname,contadd1,contadd2,contadd3,contcity,contstate,contcountry,contpin,contphone1 FROM membermaster where membertypecode = '0002'"
        'Dim arraystring() As String = {"", " ADDRESS LIST", "", ""}
        'Dim heading() As String = {"M CODE", "MEMBERNAME / ADDRESS"}
        'AddressListReport.begin()
        'AddressListReport.buttonclick(globalclass.sqlconnection, sqlstring, arraystring, heading)
    End Sub
    Private Sub SubMenu_SpecialAbsenteeList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    Dim ReportFilterObj As New ReportFilter
        '    RepSqlStr = "Special Absentee List"
        '    ReportFilterObj.MdiParent = Me
        '    ReportFilterObj.DLabel.Text = " Enter Member Code"
        '    ReportFilterObj.Text = RepSqlStr
        '    ReportFilterObj.Show()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        '    Dim SPECIALABSENTEELISTREPORT As New SpecialAbsenteeListReport
        '    Dim sqlstring As String = "select * FROM specialabsentee WHERE NEWSTATUS = 'ABSENTEE'"
        '    Dim arraystring() As String = {"", " SPECIAL ABSENTEE LIST", "", ""}
        '    Dim heading() As String = {"M NAME", "FROM ", " TO"}
        '    SPECIALABSENTEELISTREPORT.begin()
        '    SPECIALABSENTEELISTREPORT.buttonclick(globalclass.sqlconnection, sqlstring, arraystring, heading)
    End Sub
    Private Sub SubMenu_SurnamewiseList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    Dim ReportFilterObj As New ReportFilter
        '    RepSqlStr = "Surname Wise List"
        '    ReportFilterObj.MdiParent = Me
        '    ReportFilterObj.Text = RepSqlStr
        '    ReportFilterObj.DLabel.Text = " Enter Values A To Z"
        '    ReportFilterObj.Show()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'Dim NamewiseListReport As New NamewiseListReport
        'Dim sqlstring As String = "select mcode,mname,contadd1,contadd2,contadd3,contcity,contstate,contcountry,contpin,contphone1 FROM membermaster"
        'Dim arraystring() As String = {"", " NAME LIST", "", ""}
        'Dim heading() As String = {"", ""}
        'NamewiseListReport.begin()
        'NamewiseListReport.buttonclick(globalclass.sqlconnection, sqlstring, arraystring, heading)
    End Sub
    Private Sub SubMenu_LockerList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menustatus = "L"
        'Try
        '    Dim ReportFilterObj As New ReportFilter
        '    RepSqlStr = "Locker Number List"
        '    ReportFilterObj.MdiParent = Me
        '    ReportFilterObj.Text = RepSqlStr
        '    ReportFilterObj.DLabel.Text = " Enter Member Code"
        '    ReportFilterObj.Show()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'Dim objReports As New frmReports

        '        objReports.Show()
        '       objReports.MdiParent = Me
    End Sub
    Private Sub SubMenu_CreditAcList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        menustatus = "C"
        'Try
        '    Dim ReportFilterObj As New ReportFilter
        '    RepSqlStr = "Credit AC Number"
        '    ReportFilterObj.MdiParent = Me
        '    ReportFilterObj.DLabel.Text = " Enter Member Code"
        '    ReportFilterObj.Text = RepSqlStr
        '    ReportFilterObj.Show()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'Dim objReports As New frmReports
        'objReports.Show()
        'objReports.MdiParent = Me
    End Sub
    Private Sub SubMenu_MemberStatusList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub SubMenu_AddressStickerList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub submnu_MemberCorporate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submnu_MemberCorporate.Click
        Dim objgroupmst As New PTY_GROUPMASTER
        GmoduleName = "Banquet Sub Group Master"
        objgroupmst.MdiParent = Me
        objgroupmst.Show()
    End Sub
    Private Sub SubmenuSummaryRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim summary As New HALLMST
        Dim sqlstring As String
        sqlstring = "  SELECT     TOP 100 PERCENT dbo.MemberMaster.MCODE, dbo.MemberMaster.MNAME, dbo.MemberType.TypeDesc, dbo.MemberMaster.CurentStatus, "
        sqlstring = sqlstring & "  dbo.SubscriptinSummery.QUTERDATE, dbo.SubscriptinSummery.VRNO, dbo.SubscriptinSummery.TOTAL, dbo.SubscriptinSummery.DUEDATE"
        sqlstring = sqlstring & "  FROM         dbo.MemberType INNER JOIN"
        sqlstring = sqlstring & "  dbo.MemberMaster ON dbo.MemberType.Membertype = dbo.MemberMaster.MEMBERTYPECODE INNER JOIN"
        sqlstring = sqlstring & "  dbo.SubscriptinSummery ON dbo.MemberMaster.MCODE = dbo.SubscriptinSummery.SUBCD"
        sqlstring = sqlstring & "  ORDER BY dbo.MemberMaster.MCODE"
        ' summary.print(sqlstring, globalclass.sqlconnection)
    End Sub
    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim C1 As DataTable
        Dim i As Integer
        Dim S As String
        Dim SA(4) As String
        Dim STR As String
        Dim code As String
        C1 = gconnection.GetValues("SELECT * FROM MEMBERMASTER")
        Try
            For i = 0 To (C1.Rows.Count - 1)
                SA(0) = " "
                SA(1) = " "
                SA(2) = " "
                S = ""
                S = (C1.Rows(i).Item("MNAME")) & "  "
                code = Trim(C1.Rows(i).Item("Mcode"))
                SA = Split(S, " ")
                If i = 2839 Then
                    MsgBox(code)
                End If
                If SA(2) = "" Then
                    STR = "update membermaster set firstname = '" & SA(0) & "',middlename = " & "''" & ",surname = '" & SA(1) & "' where Mcode = '" & code & "'"
                Else
                    STR = "update membermaster set firstname = '" & SA(0) & "',middlename = '" & SA(1) & "',surname = '" & SA(2) & "' where Mcode = '" & code & "'"
                End If
                gconnection.dataOperation(2, STR, "membermaster")
            Next
            MsgBox("Spliting is over")
        Catch ex As Exception
            MsgBox(i)
            MsgBox(ex.Message)
        End Try
        'gconnection.dataOperation(2, sqlString, "membertype")
    End Sub
    Private Sub PartyMDI_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Shell("CLEAR.BAT", AppWinStyle.Hide)
        End
    End Sub
    Private Sub submenu_uommaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles submenu_uommaster.Click
        Dim objuommst As New UOMMaster
        GmoduleName = "Banquet Uom Master"
        If corporatebool = False And submenu_uommaster.Checked = True Then
            objuommst.Show()
            objuommst.MdiParent = Me
            submenu_uommaster.Checked = True
            Exit Sub
        End If
        If submenu_uommaster.Checked = True Then
            Exit Sub
        End If
        objuommst.Show()
        objuommst.MdiParent = Me
        submnu_MemberCorporate.Checked = True
    End Sub
    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        Try
            GmoduleName = "Arrangement Item  Master"
            Dim Objarrmst As New ARRANGEMENT
            Objarrmst.Show()
            Objarrmst.MdiParent = Me
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        GmoduleName = "Banquet Cancel details"
        Dim objparty As New ROOMWISE
        objparty.MdiParent = Me
        objparty.Show()
    End Sub
    'Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
    '    Dim objreceipt As New Receiptentry
    '    objreceipt.MdiParent = Me
    '    objreceipt.Show()
    'End Sub
    Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Purpose Master"
        Dim objHALLTYPE As New HALLTYPE
        objHALLTYPE.MdiParent = Me
        objHALLTYPE.Show()
    End Sub
    Private Sub MenuItem10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
        GmoduleName = "Special Party Bill Register"
        Dim objBillregiser As New BILLREGISTER
        objBillregiser.MdiParent = Me
        objBillregiser.Show()
    End Sub
    Private Sub MenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        GmoduleName = "Purpose Master"
        Dim objBillpending As New BILLPENDING
        objBillpending.MdiParent = Me
        objBillpending.Show()
    End Sub
    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles close_EXIT.Click

        Call LogOut_User()
        GmoduleName = "Close"
        End
        'Me.Hide()
        'End
    End Sub
    Private Sub MenuItem5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GmoduleName = "Purpose Master"
        Dim objCANCELTYPE As New CANCELTYPE
        objCANCELTYPE.MdiParent = Me
        objCANCELTYPE.Show()
    End Sub
    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        GmoduleName = "Banquet Availablity List"
        Dim objAVAILABLE As New HALLAVAILABLITY
        objAVAILABLE.MdiParent = Me
        objAVAILABLE.Show()
    End Sub
    Private Sub MenuItem1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        GmoduleName = "Purpose Master"
        Dim objCUSTOMERREPORT As New CUSTOMERREPORT
        objCUSTOMERREPORT.MdiParent = Me
        objCUSTOMERREPORT.Show()
    End Sub

    Private Sub MenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click
        GmoduleName = "Banquet Availability Check"
        Dim objhallavailstat As New checkavailability
        objhallavailstat.MdiParent = Me
        objhallavailstat.Show()
    End Sub

    Private Sub MenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem12.Click
        GmoduleName = "Purpose Master"
        Dim OBJPARTYDATEWISE As New DATEWISEPARTY_BILLREGISTER
        OBJPARTYDATEWISE.MdiParent = Me
        OBJPARTYDATEWISE.Show()
    End Sub

    Private Sub MenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem13.Click
        GmoduleName = "Purpose Master"
        Dim objitemwisesale As New Itemwise_sale
        objitemwisesale.MdiParent = Me
        objitemwisesale.Show()
    End Sub

    Private Sub MenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
        GmoduleName = "Party Maintaince Details"
        PartyMDI.ActiveForm.Hide()
        GmoduleName = "Select Company"
        Dim SELECTCOMPANY As New CompanyList1
        SELECTCOMPANY.Show()
        'PartyMDI.ActiveForm.Close()
    End Sub

    Private Sub MenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem16.Click
        GmoduleName = "Calculator"
        Shell(Environment.SystemDirectory & "\calc.exe", AppWinStyle.NormalFocus)
    End Sub

    Private Sub MenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem17.Click
        GmoduleName = "NotePad"
        Shell(Environment.SystemDirectory & "\notepad.exe", AppWinStyle.NormalFocus)
    End Sub
    Private Sub MenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem18.Click
        GmoduleName = "Banquet Hall Session Master"
        Dim objitemwisesale As New PTY_PURPOSEMASTER
        objitemwisesale.MdiParent = Me
        objitemwisesale.Show()
    End Sub
    Private Sub MenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem19.Click
        GmoduleName = "Banquet Group Master"
        Dim objitemwisesale As New PTY_MENUMASTER
        objitemwisesale.MdiParent = Me
        objitemwisesale.Show()
    End Sub
    Private Sub MenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem20.Click
        GmoduleName = "Purpose Master"
        Dim objitemwisesale As New PTY_LOCMASTER
        objitemwisesale.MdiParent = Me
        objitemwisesale.Show()
    End Sub
    Private Sub MenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem21.Click
        GmoduleName = "Category Master"
        Dim objitemwisesale As New PTY_CATEGORYMASTER
        objitemwisesale.MdiParent = Me
        objitemwisesale.Show()
    End Sub
    Private Sub MenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem22.Click
        GmoduleName = "Banquet Hall Cancellation Master"
        Dim objitemwisesale As New PTY_CANCELLATIONMASTER
        objitemwisesale.MdiParent = Me
        objitemwisesale.Show()
    End Sub
    Private Sub MenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem24.Click
        GmoduleName = "Banquet Group And sub-Group Integration"
        Dim objitemwisesale As New PTY_MENUGROUP_MASTER
        objitemwisesale.MdiParent = Me
        objitemwisesale.Show()
    End Sub
    Private Sub MenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem25.Click
        GmoduleName = "Banquet Menu Master"
        Dim objitemwisesale As New PTY_TARIFFMASTER
        objitemwisesale.MdiParent = Me
        objitemwisesale.Show()
    End Sub

    Private Sub MenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem26.Click
        Application.Exit()
    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        GmoduleName = "Special Party Void Status"
        Dim objparty As New Voidstatus
        objparty.MdiParent = Me
        objparty.Show()
    End Sub

    Private Sub MenuItem9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
        GmoduleName = "Banquet Bill Details "
        Dim objparty As New ReceiptRegister
        objparty.MdiParent = Me
        objparty.Show()
    End Sub

    Private Sub menu_Master_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Master.Click

    End Sub

    Private Sub MenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem27.Click
        GmoduleName = "Consumption entry"
        Dim OBJCONSUM As New partyconsumption
        OBJCONSUM.MdiParent = Me
        OBJCONSUM.Show()
    End Sub

    Private Sub MenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem28.Click
        GmoduleName = "Party Bar Consumption"
        Dim cr As New consumerpt
        cr.MdiParent = Me
        cr.Show()
    End Sub

    Private Sub MenuItem29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem29.Click
        GmoduleName = "Banquet Items Tagging"
        Dim ACCD As New ACCOUNTSITEMTAGGING
        ACCD.MdiParent = Me
        ACCD.Show()
    End Sub

    Private Sub MenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem30.Click
        GmoduleName = "Party Maintaince Details"
        Dim maint As New MAINTAINANCE
        maint.MdiParent = Me
        maint.Show()
    End Sub

    Private Sub MenuItem31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MenuItem32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem32.Click
        GmoduleName = "Banquet Head Receipt Master"
        Dim rec As New PARTYHEADMASTER
        rec.MdiParent = Me
        rec.Show()
    End Sub

    Private Sub MenuItem33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem33.Click
        GmoduleName = "GR_PAYMODEALLOCATION"
        Dim GR_PAYALLOC As New GR_PAYMODEALLOCATION
        GR_PAYALLOC.MdiParent = Me
        GR_PAYALLOC.Show()
    End Sub

    Private Sub menu_Transaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Transaction.Click

    End Sub

    Private Sub MenuItem34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem34.Click
        GmoduleName = "Banquet Receipt Entry"
        Dim rec1 As New Receiptentry
        rec1.MdiParent = Me
        rec1.Show()
    End Sub

    Private Sub MenuItem31_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem31.Click
        GmoduleName = "Banquet Menu Booking"
        Dim objbillBOOK As New PARTYBOOKING
        If statusconversionbool = False And submnu_StatusConversion.Checked = True Then
            objbillBOOK.Show()
            objbillBOOK.StartPosition = 0
            objbillBOOK.MdiParent = Me
            submnu_StatusConversion.Checked = True
            Exit Sub
        End If
        If submnu_StatusConversion.Checked = True Then
            Exit Sub
        End If
        objbillBOOK.Show()
        objbillBOOK.MdiParent = Me
        submnu_StatusConversion.Checked = True
    End Sub

    Private Sub MenuItem35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem35.Click
        GmoduleName = "Banquet Billing"
        Dim objbill As New PartyBilling
        'GmoduleName = "Tariff Menu / Item / Arrangements Booking and Billing"
        If statusconversionbool = False And submnu_StatusConversion.Checked = True Then
            objbill.Show()
            objbill.StartPosition = 0
            objbill.MdiParent = Me
            submnu_StatusConversion.Checked = True
            Exit Sub
        End If
        If submnu_StatusConversion.Checked = True Then
            Exit Sub
        End If
        objbill.Show()
        objbill.MdiParent = Me
        submnu_StatusConversion.Checked = True
    End Sub

    Private Sub MenuItem36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem36.Click
        Dim GLACCOUNTMASTER As New GLACCOUNTMASTER_Others
        GLACCOUNTMASTER.MdiParent = Me
        GLACCOUNTMASTER.Show()
    End Sub

    Private Sub MenuItem37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem37.Click
        GmoduleName = "Party  Groupwise Report"
        Dim CreditSalesGroupGOLF As New BANQUETREPORT
        CreditSalesGroupGOLF.MdiParent = Me
        CreditSalesGroupGOLF.Show()
    End Sub

    Private Sub MenuItem38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem38.Click
        GmoduleName = "Banquet Reservation Details"
        Dim objparty As New RESERVATION
        objparty.MdiParent = Me
        objparty.Show()
    End Sub

    Private Sub MenuItem39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem39.Click

        If UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then
            GmoduleName = "Banquet Sales LocationWise"
            Dim ITEM As New ITEMWISESALES
            ITEM.MdiParent = Me
            ITEM.Show()
        Else
            MenuItem39.Visible = False
        End If
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        If UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then
            MenuItem39.Visible = True
        Else
            MenuItem39.Visible = False
        End If
    End Sub

    Private Sub MenuItem4_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles MenuItem4.DrawItem
        If UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then
            MenuItem39.Visible = True
        Else
            MenuItem39.Visible = False
        End If
    End Sub


    Private Sub MenuItem4_MeasureItem(ByVal sender As Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles MenuItem4.MeasureItem
        If UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then
            MenuItem39.Visible = True
        Else
            MenuItem39.Visible = False
        End If
    End Sub

    Private Sub MenuItem4_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem4.Popup
        If UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then
            MenuItem39.Visible = True
        Else
            MenuItem39.Visible = False
        End If
    End Sub

    Private Sub MenuItem4_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem4.Select
        If UCase(Mid(MyCompanyName, 1, 4)) = "ANDH" Then
            MenuItem39.Visible = True
        Else
            MenuItem39.Visible = False
        End If
    End Sub

    Private Sub MenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem23.Click
        GmoduleName = "Banquet Itemwisesales"
        Dim objparty As New ITEMSALES
        objparty.MdiParent = Me
        objparty.Show()
    End Sub

    Private Sub MenuItem40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem40.Click
        GmoduleName = "Banquet Menulist"
        Dim ObjItemwisereport As New frmItemwise_new
        ObjItemwisereport.MdiParent = Me
        ObjItemwisereport.Show()
    End Sub
End Class
