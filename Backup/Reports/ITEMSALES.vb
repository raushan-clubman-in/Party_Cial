Public Class ITEMSALES
    Inherits System.Windows.Forms.Form
    Dim sqlstring As String
    Dim chkbool As Boolean
    Dim vconn As New GlobalClass
    Dim gconnection As New GlobalClass
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
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents CmdClear As System.Windows.Forms.Button
    Friend WithEvents CmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents CmdView As System.Windows.Forms.Button
    Friend WithEvents Chk_roomselection As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Dtpbookfromdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpbooktodate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chklist_member As System.Windows.Forms.CheckedListBox
    Friend WithEvents chklist_category As System.Windows.Forms.CheckedListBox
    Friend WithEvents chklist_item As System.Windows.Forms.CheckedListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ITEMSALES))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.CmdClear = New System.Windows.Forms.Button
        Me.CmdPrint = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.CmdView = New System.Windows.Forms.Button
        Me.Chk_roomselection = New System.Windows.Forms.CheckBox
        Me.chklist_member = New System.Windows.Forms.CheckedListBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Dtpbookfromdate = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtpbooktodate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.chklist_category = New System.Windows.Forms.CheckedListBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.chklist_item = New System.Windows.Forms.CheckedListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.CmdClear)
        Me.GroupBox4.Controls.Add(Me.CmdPrint)
        Me.GroupBox4.Controls.Add(Me.cmdexit)
        Me.GroupBox4.Controls.Add(Me.CmdView)
        Me.GroupBox4.Location = New System.Drawing.Point(56, 552)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(816, 56)
        Me.GroupBox4.TabIndex = 451
        Me.GroupBox4.TabStop = False
        '
        'CmdClear
        '
        Me.CmdClear.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdClear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClear.ForeColor = System.Drawing.Color.White
        Me.CmdClear.Image = CType(resources.GetObject("CmdClear.Image"), System.Drawing.Image)
        Me.CmdClear.Location = New System.Drawing.Point(60, 15)
        Me.CmdClear.Name = "CmdClear"
        Me.CmdClear.Size = New System.Drawing.Size(104, 32)
        Me.CmdClear.TabIndex = 7
        Me.CmdClear.Text = "Clear[F6]"
        '
        'CmdPrint
        '
        Me.CmdPrint.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdPrint.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdPrint.ForeColor = System.Drawing.Color.White
        Me.CmdPrint.Image = CType(resources.GetObject("CmdPrint.Image"), System.Drawing.Image)
        Me.CmdPrint.Location = New System.Drawing.Point(464, 15)
        Me.CmdPrint.Name = "CmdPrint"
        Me.CmdPrint.Size = New System.Drawing.Size(104, 32)
        Me.CmdPrint.TabIndex = 8
        Me.CmdPrint.Text = "Export[F8]"
        '
        'cmdexit
        '
        Me.cmdexit.BackColor = System.Drawing.Color.ForestGreen
        Me.cmdexit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdexit.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdexit.ForeColor = System.Drawing.Color.White
        Me.cmdexit.Image = CType(resources.GetObject("cmdexit.Image"), System.Drawing.Image)
        Me.cmdexit.Location = New System.Drawing.Point(648, 15)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(104, 32)
        Me.cmdexit.TabIndex = 9
        Me.cmdexit.Text = "Exit[F11]"
        '
        'CmdView
        '
        Me.CmdView.BackColor = System.Drawing.Color.ForestGreen
        Me.CmdView.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CmdView.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdView.ForeColor = System.Drawing.Color.White
        Me.CmdView.Image = CType(resources.GetObject("CmdView.Image"), System.Drawing.Image)
        Me.CmdView.Location = New System.Drawing.Point(256, 15)
        Me.CmdView.Name = "CmdView"
        Me.CmdView.Size = New System.Drawing.Size(104, 32)
        Me.CmdView.TabIndex = 6
        Me.CmdView.Text = "View [F9]"
        '
        'Chk_roomselection
        '
        Me.Chk_roomselection.BackColor = System.Drawing.Color.Transparent
        Me.Chk_roomselection.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chk_roomselection.Location = New System.Drawing.Point(336, 40)
        Me.Chk_roomselection.Name = "Chk_roomselection"
        Me.Chk_roomselection.Size = New System.Drawing.Size(192, 24)
        Me.Chk_roomselection.TabIndex = 450
        Me.Chk_roomselection.Text = "SELECT ALL "
        '
        'chklist_member
        '
        Me.chklist_member.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chklist_member.Location = New System.Drawing.Point(336, 88)
        Me.chklist_member.Name = "chklist_member"
        Me.chklist_member.Size = New System.Drawing.Size(264, 382)
        Me.chklist_member.TabIndex = 448
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Dtpbookfromdate)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.dtpbooktodate)
        Me.GroupBox3.Location = New System.Drawing.Point(56, 472)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(816, 64)
        Me.GroupBox3.TabIndex = 453
        Me.GroupBox3.TabStop = False
        '
        'Dtpbookfromdate
        '
        Me.Dtpbookfromdate.CustomFormat = "dd/MM/yyyy"
        Me.Dtpbookfromdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtpbookfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtpbookfromdate.Location = New System.Drawing.Point(224, 23)
        Me.Dtpbookfromdate.Name = "Dtpbookfromdate"
        Me.Dtpbookfromdate.Size = New System.Drawing.Size(120, 26)
        Me.Dtpbookfromdate.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(472, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 22)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "TO DATE :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(104, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(116, 22)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "FROM DATE :"
        '
        'dtpbooktodate
        '
        Me.dtpbooktodate.CustomFormat = "dd/MM/yyyy"
        Me.dtpbooktodate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpbooktodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpbooktodate.Location = New System.Drawing.Point(576, 22)
        Me.dtpbooktodate.Name = "dtpbooktodate"
        Me.dtpbooktodate.Size = New System.Drawing.Size(120, 26)
        Me.dtpbooktodate.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(280, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(277, 25)
        Me.Label3.TabIndex = 454
        Me.Label3.Text = "ITEM WISE SALE REGISTER"
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(56, 40)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(168, 24)
        Me.CheckBox1.TabIndex = 456
        Me.CheckBox1.Text = "SELECT ALL "
        '
        'chklist_category
        '
        Me.chklist_category.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chklist_category.Location = New System.Drawing.Point(56, 88)
        Me.chklist_category.Name = "chklist_category"
        Me.chklist_category.Size = New System.Drawing.Size(256, 382)
        Me.chklist_category.TabIndex = 455
        '
        'CheckBox2
        '
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(616, 40)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(192, 24)
        Me.CheckBox2.TabIndex = 458
        Me.CheckBox2.Text = "SELECT ALL "
        '
        'chklist_item
        '
        Me.chklist_item.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold)
        Me.chklist_item.Location = New System.Drawing.Point(616, 88)
        Me.chklist_item.Name = "chklist_item"
        Me.chklist_item.Size = New System.Drawing.Size(256, 382)
        Me.chklist_item.TabIndex = 457
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(64, Byte), CType(64, Byte))
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(336, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(264, 24)
        Me.Label2.TabIndex = 459
        Me.Label2.Text = "BOOKINGNO ==>MEMBER NAME"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(64, Byte), CType(64, Byte))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(56, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(256, 24)
        Me.Label1.TabIndex = 460
        Me.Label1.Text = "CATEGORY"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(64, Byte), CType(64, Byte))
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(616, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(256, 24)
        Me.Label4.TabIndex = 461
        Me.Label4.Text = "ITEMCODE==>ITEM NAME"
        '
        'ITEMSALES
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.chklist_item)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.chklist_category)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Chk_roomselection)
        Me.Controls.Add(Me.chklist_member)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "ITEMSALES"
        Me.Text = "Itemwise_sale"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ITEMSALES_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        Call Fillmember()
        Call category()
        Call item()
        Dtpbookfromdate.Value = Now.Today
        dtpbooktodate.Value = Now.Today
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        CmdClear_Click(sender, e)
    End Sub
    Private Sub Fillmember()
        Dim i As Integer
        chklist_member.Items.Clear()
        sqlstring = "select isnull(bookingno,'')as bookingno,isnull(associatename,'')as associatename  from party_book_memberwise  group by bookingno,associatename order by bookingno"
        vconn.getDataSet(sqlstring, "bookno")
        If gdataset.Tables("bookno").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("bookno").Rows.Count - 1
                With gdataset.Tables("bookno").Rows(i)
                    chklist_member.Items.Add(Trim(.Item("bookingno") & "=>" & .Item("associatename")))
                End With
            Next i
        End If
        chklist_member.Sorted = True
    End Sub
    Private Sub category()
        Dim i As Integer
        chklist_category.Items.Clear()
        sqlstring = "select distinct isnull(category,'')as category  from party_book_memberwise"
        vconn.getDataSet(sqlstring, "category")
        If gdataset.Tables("category").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("category").Rows.Count - 1
                With gdataset.Tables("category").Rows(i)
                    chklist_category.Items.Add(Trim(.Item("category")))
                End With
            Next i

        End If
        chklist_category.Sorted = True
    End Sub
    Private Sub GetRights()
        Dim i, j, k, x As Integer
        Dim vmain, vsmod, vssmod As Long
        Dim ssql, SQLSTRING As String
        Dim M1 As New MainMenu
        Dim chstr As String
        SQLSTRING = "SELECT * FROM useradmin WHERE USERNAME = '" & Trim(gUsername) & "' AND MAINGROUP='SPECIALPARTY' AND                 MODULENAME LIKE '" & Trim(GmoduleName) & "%' ORDER BY RIGHTS"
        vconn.getDataSet(SQLSTRING, "USER")
        If gdataset.Tables("USER").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("USER").Rows.Count - 1
                With gdataset.Tables("USER").Rows(i)
                    chstr = abcdMINUS(.Item("RIGHTS"))
                End With
            Next
        End If
        Me.CmdView.Enabled = False
        Me.CmdPrint.Enabled = False
        'A-All,S-Save,M-Modify,C-Cancel,D-Delete,V-View,P-Print
        If Len(chstr) > 0 Then
            Dim Right() As Char
            Right = chstr.ToCharArray
            For x = 0 To Right.Length - 1
                If Right(x) = "A" Then
                    Me.CmdView.Enabled = True
                    Me.CmdPrint.Enabled = True
                    Exit Sub
                End If
                If Right(x) = "V" Then
                    Me.CmdView.Enabled = True
                End If
                If Right(x) = "P" Then
                    Me.CmdPrint.Enabled = True
                End If
            Next
        End If
    End Sub

    Private Sub CmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdClear.Click
        'CHBCANCEL.Checked = False

        chklist_member.Items.Clear()
        chklist_item.Items.Clear()
        chklist_category.Items.Clear()

        Chk_roomselection.Checked = False
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        Call Fillmember()
        Call category()
        Call item()
        If gUserCategory <> "S" Then
            Call GetRights()
        End If
        Dtpbookfromdate.Value = Now()
        dtpbooktodate.Value = Now()

    End Sub
    Private Sub item()
        Dim i As Integer
        sqlstring = "select isnull(itemcode,'')as itemcode,isnull(itemdesc,'')as itemdesc from party_book_memberwise group by itemcode,itemdesc order by itemcode,itemdesc "
        vconn.getDataSet(sqlstring, "item")
        If gdataset.Tables("item").Rows.Count - 1 >= 0 Then
            For i = 0 To gdataset.Tables("item").Rows.Count - 1
                With gdataset.Tables("item").Rows(i)
                    chklist_item.Items.Add(Trim(.Item("itemcode") & "==>" & .Item("itemdesc")))
                End With
            Next i
        End If
        chklist_item.Sorted = True
    End Sub

    Private Sub Chk_roomselection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Chk_roomselection.CheckedChanged
        Dim i As Integer
        If Chk_roomselection.Checked = True Then
            For i = 0 To chklist_member.Items.Count - 1
                chklist_member.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklist_member.Items.Count - 1
                chklist_member.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub CmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdView.Click
        'If chklist_member.CheckedItems.Count = 0 Then
        '    MessageBox.Show("Select the item(s)", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If
        'Checkdaterangevalidate(Dtpbookfromdate.Value, dtpbooktodate.Value)
        'If chkdatevalidate = False Then Exit Sub
        'gPrint = False
        Call itemdetails()
    End Sub

    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
        Me.Close()
    End Sub
    Private Sub itemdetails()
        Dim Viewer As New ReportViwer
        Dim i As Integer
        Dim tspilt(), heading(0) As String
        Dim sqlstring As String
        Dim r As New PARTY_ITEMDETAILS

     
            sqlstring = ""

        'sqlstring = "SELECT  ISNULL(ITEMCODE,'') AS ITEMCODE,ISNULL(ITEMDESC,'') AS ITEMDESC,"
        'sqlstring = sqlstring & " ISNULL(QTY,0) AS QTY,ISNULL(RATE,0) AS RATE,	ISNULL(TAXAMOUNT,0) AS TAXAMOUNT,"
        'sqlstring = sqlstring & "ISNULL(AMOUNT,0) AS AMOUNT,ISNULL(TOTALAMOUNT,0) AS TOTALAMOUNT,ISNULL(CATEGORY,'')AS CATEGORY,ISNULL(BOOKINGNO,0)AS BOOKINGNO  from party_book_MEMBERwise WHERE "
        sqlstring = "select * from party_book_MEMBERwise WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,PARTYDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(Dtpbookfromdate.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpbooktodate.Value, "yyyy-MM-dd") & "'"


        If chklist_category.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND CATEGORY IN ("
            For i = 0 To chklist_category.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & chklist_category.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        If chklist_member.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND BOOKINGNO IN ("
            For i = 0 To chklist_member.CheckedItems.Count - 1
                tspilt = Split(chklist_member.CheckedItems(i), "=>")
                If i = 0 Then
                    sqlstring = sqlstring & tspilt(0) & ","
                Else
                    sqlstring = sqlstring & tspilt(0) & ","
                End If
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        If chklist_item.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ITEMCODE in ("
            For i = 0 To chklist_item.CheckedItems.Count - 1
                tspilt = Split(chklist_item.CheckedItems(i), "==>")
                If i = 0 Then
                    sqlstring = sqlstring & " '" & tspilt(0) & "', "
                Else
                    sqlstring = sqlstring & " '" & tspilt(0) & "', "
                End If
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        'sqlstring = sqlstring & " GROUP BY ITEMCODE,ITEMDESC,RATE,TAXAMOUNT,QTY,AMOUNT,TOTALAMOUNT,CATEGORY,BOOKINGNO ORDER BY ITEMDESC"
        sqlstring = sqlstring & " ORDER BY ITEMDESC"

        gconnection.getDataSet(sqlstring, "BOOK")
        If gdataset.Tables("BOOK").Rows.Count > 0 Then


            Call Viewer.GetDetails(sqlstring, "party_book_MEMBERwise", r)
            Viewer.TableName = "party_book_MEMBERwise"

            Dim TXTOBJ1 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ1 = r.ReportDefinition.ReportObjects("Text11")
            TXTOBJ1.Text = MyCompanyName

            Dim TXTOBJ16 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ16 = r.ReportDefinition.ReportObjects("Text50")
            TXTOBJ16.Text = "PERIOD FROM " & Format(Dtpbookfromdate.Value, "dd/MM/yyyy") & "  TO" & " " & Format(dtpbooktodate.Value, "dd/MM/yyyy") & ""

            Dim TXTOBJ5 As CrystalDecisions.CrystalReports.Engine.TextObject
            TXTOBJ5 = r.ReportDefinition.ReportObjects("Text200")
            TXTOBJ5.Text = "UserName : " & gUsername

            'Dim TXTOBJ9 As CrystalDecisions.CrystalReports.Engine.TextObject
            'TXTOBJ9 = r.ReportDefinition.ReportObjects("Text17")
            'TXTOBJ9.Text = "Accounting Period : " & Format(strFinancialYearStart, "dd-MM-yyyy") & " - " & Format(strFinancialYearEnd, "dd-MM-yyyy")

            Viewer.Show()
        Else
            MessageBox.Show("NO RECORDS TO DISPLAY", MyCompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub

    Private Sub CmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrint.Click
        Dim i As Integer
        Dim tspilt(), heading(0) As String
        Dim sqlstring As String
        Dim exp As New exportexcel
        sqlstring = "select * from party_book_MEMBERwise WHERE "
        sqlstring = sqlstring & " CAST(CONVERT(VARCHAR,PARTYDATE,106)AS DATETIME) BETWEEN '"
        sqlstring = sqlstring & Format(Dtpbookfromdate.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpbooktodate.Value, "yyyy-MM-dd") & "'"


        If chklist_category.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND CATEGORY IN ("
            For i = 0 To chklist_category.CheckedItems.Count - 1
                sqlstring = sqlstring & " '" & chklist_category.CheckedItems(i) & "', "
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If

        If chklist_member.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " AND BOOKINGNO IN ("
            For i = 0 To chklist_member.CheckedItems.Count - 1
                tspilt = Split(chklist_member.CheckedItems(i), "=>")
                If i = 0 Then
                    sqlstring = sqlstring & tspilt(0) & ","
                Else
                    sqlstring = sqlstring & tspilt(0) & ","
                End If
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        If chklist_item.CheckedItems.Count <> 0 Then
            sqlstring = sqlstring & " and ITEMCODE in ("
            For i = 0 To chklist_item.CheckedItems.Count - 1
                tspilt = Split(chklist_item.CheckedItems(i), "==>")
                If i = 0 Then
                    sqlstring = sqlstring & " '" & tspilt(0) & "', "
                Else
                    sqlstring = sqlstring & " '" & tspilt(0) & "', "
                End If
            Next
            sqlstring = Mid(sqlstring, 1, Len(sqlstring) - 2)
            sqlstring = sqlstring & ")"
        End If
        'sqlstring = sqlstring & " GROUP BY ITEMCODE,ITEMDESC,RATE,TAXAMOUNT,QTY,AMOUNT,TOTALAMOUNT,CATEGORY,BOOKINGNO ORDER BY ITEMDESC"
        sqlstring = sqlstring & " ORDER BY ITEMDESC"

        gconnection.getDataSet(sqlstring, "BOOK")
        If gdataset.Tables("BOOK").Rows.Count > 0 Then
            exp.Show()
            Call exp.export(sqlstring, "BANQUET BILL REPORT  " & Format(Dtpbookfromdate.Value, "dd-MMM-yyyy") & "   TO   " & Format(dtpbooktodate.Value, "dd-MMM-yyyy"), "")
        Else
            MsgBox("NO SUCH RECORDS FOUND", MsgBoxStyle.Information)
            Exit Sub
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim i As Integer
        If CheckBox1.Checked = True Then
            For i = 0 To chklist_category.Items.Count - 1
                chklist_category.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklist_category.Items.Count - 1
                chklist_category.SetItemChecked(i, False)
            Next
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Dim i As Integer
        If CheckBox2.Checked = True Then
            For i = 0 To chklist_item.Items.Count - 1
                chklist_item.SetItemChecked(i, True)
            Next
        Else
            For i = 0 To chklist_item.Items.Count - 1
                chklist_item.SetItemChecked(i, False)
            Next
        End If
    End Sub
End Class
