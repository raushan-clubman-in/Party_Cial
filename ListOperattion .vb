Option Explicit On 
Public Class ListOperattion
    Inherits System.Windows.Forms.Form
    Dim vConn As New GlobalClass
    Dim Loopindex As Long
    Dim i As Integer, vIndex As Long
    Public vCaption As String
    Public Table As String
    Public Field As String
    Dim Fields() As String
    Dim ssql As String
    Public keyfield As String
    Public keyfield1 As String
    Public keyfield2 As String
    Public keyfield3 As String
    Public keyfield4 As String
    Public keyfield5 As String
    Public keyfield6 As String
    Public keyfield7 As String
    Public keyfield8 As String
    Public keyfield9 As String
    Public keyfield10 As String
    Public keyfield11 As String
    Public keyfield12 As String
    Public keyfield13 As String
    Public keyfield14 As String
    Public keyfield15 As String
    Public vFormatstring As String
    Dim FormUnload As Boolean
    Public KeyPos As Integer, KeyPos1 As Integer, KeyPos2 As Integer, Keypos3 As Integer
    Public keypos4 As Integer, Keypos5 As Integer, Keypos6 As Integer, Keypos7 As Integer, Keypos8 As Integer
    Public keypos9 As Integer, Keypos10 As Integer, Keypos11 As Integer, Keypos12 As Integer, Keypos13 As Integer
    Public keypos14 As Integer, Keypos15 As Integer
    Dim vSelect As String
    Public vSamleCol As String
    Dim vColValue As String
    Dim vCode As String
    Dim vLastString As String
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
    Friend WithEvents CbxColumn As System.Windows.Forms.ComboBox
    Friend WithEvents CbxOrderby As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents lblHeading As System.Windows.Forms.Label
    Friend WithEvents POSListoperation As AxMSFlexGridLib.AxMSFlexGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ListOperattion))
        Me.CbxColumn = New System.Windows.Forms.ComboBox
        Me.CbxOrderby = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.lblHeading = New System.Windows.Forms.Label
        Me.POSListoperation = New AxMSFlexGridLib.AxMSFlexGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.POSListoperation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CbxColumn
        '
        Me.CbxColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxColumn.Location = New System.Drawing.Point(168, 40)
        Me.CbxColumn.Name = "CbxColumn"
        Me.CbxColumn.Size = New System.Drawing.Size(178, 21)
        Me.CbxColumn.TabIndex = 4
        '
        'CbxOrderby
        '
        Me.CbxOrderby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxOrderby.Location = New System.Drawing.Point(440, 40)
        Me.CbxOrderby.Name = "CbxOrderby"
        Me.CbxOrderby.Size = New System.Drawing.Size(165, 21)
        Me.CbxOrderby.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(352, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Order by :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Search Field :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(48, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Search Text :"
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSearch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(168, 64)
        Me.txtSearch.MaxLength = 50
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(272, 23)
        Me.txtSearch.TabIndex = 0
        Me.txtSearch.Text = ""
        '
        'lblHeading
        '
        Me.lblHeading.AutoSize = True
        Me.lblHeading.BackColor = System.Drawing.Color.Transparent
        Me.lblHeading.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeading.ForeColor = System.Drawing.Color.Black
        Me.lblHeading.Location = New System.Drawing.Point(280, 0)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.Size = New System.Drawing.Size(85, 19)
        Me.lblHeading.TabIndex = 7
        Me.lblHeading.Text = "lblHeading"
        '
        'POSListoperation
        '
        Me.POSListoperation.Location = New System.Drawing.Point(8, 96)
        Me.POSListoperation.Name = "POSListoperation"
        Me.POSListoperation.OcxState = CType(resources.GetObject("POSListoperation.OcxState"), System.Windows.Forms.AxHost.State)
        Me.POSListoperation.Size = New System.Drawing.Size(648, 288)
        Me.POSListoperation.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(648, 80)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'ListOperattion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(238, Byte), CType(249, Byte), CType(232, Byte))
        Me.ClientSize = New System.Drawing.Size(666, 400)
        Me.Controls.Add(Me.POSListoperation)
        Me.Controls.Add(Me.lblHeading)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CbxOrderby)
        Me.Controls.Add(Me.CbxColumn)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ListOperattion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.POSListoperation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
    Private Sub ListOperattion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormUnload = True
        Fields = Split(Field, ",")
        vSelect = Field
        For i = 0 To UBound(Fields)
            CbxColumn.Items.Add(Trim(Fields(i)))
            CbxOrderby.Items.Add(Trim(Fields(i)))
            FormUnload = False
        Next i
        If Field <> "" Then
            CbxColumn.Text = Trim(Fields(0) & "")
            CbxOrderby.Text = Trim(Fields(0) & "")
        End If
        POSListoperation.FormatString = vFormatstring
        lblHeading.Text = Trim(vCaption)
        If Len(Search) > 0 Then
            Me.txtSearch.Text = Search
            Search = ""
        End If
        Me.Show()
    End Sub
    Private Sub ListOperattion1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If FormUnload = True Then
            Me.Close()
            gSQLString = ""
            vFormatstring = ""
            vCaption = ""
            M_Groupby = ""
            M_WhereCondition = ""
            Search = ""
        End If
    End Sub
    Private Sub POSListoperation_ClickEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles POSListoperation.ClickEvent
        Call getDetails()
    End Sub
    Private Sub ListOperattion1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.Escape Then
            Me.Dispose(True)
        End If
    End Sub
    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            If txtSearch.Text = "" Then
                Call txtSearch_TextChanged(txtSearch, e)
            End If
            Microsoft.VisualBasic.ChrW(0)
            POSListoperation.Focus()
        End If
    End Sub
    Private Sub CbxColumn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CbxColumn.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            CbxOrderby.Focus()
        End If
    End Sub
    Private Sub CbxOrderby_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CbxOrderby.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtSearch.Focus()
        End If
    End Sub
    Private Sub getDetails()
        Dim keycol As Integer
        keycol = POSListoperation.Cols - 1
        keyfield = POSListoperation.get_TextMatrix(POSListoperation.Row, KeyPos)
        keyfield1 = POSListoperation.get_TextMatrix(POSListoperation.Row, KeyPos1)
        keyfield2 = POSListoperation.get_TextMatrix(POSListoperation.Row, KeyPos2)
        keyfield3 = POSListoperation.get_TextMatrix(POSListoperation.Row, Keypos3)
        keyfield4 = POSListoperation.get_TextMatrix(POSListoperation.Row, keypos4)
        keyfield5 = POSListoperation.get_TextMatrix(POSListoperation.Row, Keypos5)
        keyfield6 = POSListoperation.get_TextMatrix(POSListoperation.Row, Keypos6)
        keyfield7 = POSListoperation.get_TextMatrix(POSListoperation.Row, Keypos7)
        keyfield8 = POSListoperation.get_TextMatrix(POSListoperation.Row, Keypos8)
        keyfield9 = POSListoperation.get_TextMatrix(POSListoperation.Row, keypos9)
        keyfield10 = POSListoperation.get_TextMatrix(POSListoperation.Row, Keypos10)
        keyfield11 = POSListoperation.get_TextMatrix(POSListoperation.Row, Keypos11)
        keyfield12 = POSListoperation.get_TextMatrix(POSListoperation.Row, Keypos12)
        keyfield13 = POSListoperation.get_TextMatrix(POSListoperation.Row, Keypos13)
        M_Groupby = ""
        M_WhereCondition = ""
        Me.Hide()
    End Sub
    Private Sub POSListoperation_KeyPressEvent(ByVal sender As Object, ByVal e As AxMSFlexGridLib.DMSFlexGridEvents_KeyPressEvent) Handles POSListoperation.KeyPressEvent
        If e.keyAscii = 13 Then
            Call getDetails()
        End If
    End Sub
    Private Sub txtSearch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        Dim vLen As Integer
        vFormatstring = POSListoperation.FormatString
        POSListoperation.Clear()
        POSListoperation.FormatString = vFormatstring
        Dim ColIndex As Integer
        ssql = ""
        ssql = gSQLString & IIf(Trim(M_WhereCondition) = "", " Where ", M_WhereCondition & " And ")
        If CbxColumn.Text <> "" Then

            vLen = Len(Trim(txtSearch.Text))
            'Changes Done For Not Filtering Space as Char On 16/12/2008
            ssql = ssql & Trim(CbxColumn.Text & "") & " LIKE '" & Trim(txtSearch.Text) & "%'"
            'ssql = ssql & Trim(CbxColumn.Text & "") & " LIKE '" & txtSearch.Text & "%'"
        ElseIf CbxColumn.Text <> "" Then
            MsgBox("Select the SearchField Column as it is mandatory ...", MsgBoxStyle.Information)
            CbxColumn.Focus()
            Exit Sub
        End If
        If vSamleCol = "Y" Then
            ssql = ssql & " Order by SizeCode"
        ElseIf vSamleCol = "P" Then
            ssql = ssql & " Order by docdate,docno"
        Else
            If CbxOrderby.Text <> "" Then
                ssql = ssql & M_Groupby
                ssql = ssql & " order by " & Trim(CbxOrderby.Text)
            End If
        End If
        If ssql <> "" Then
            gdataset = New DataSet
            vConn.getDataSet(ssql, "mytable")
            If gdataset.Tables("MyTable").Rows.Count > 0 Then
                vLastString = Trim(txtSearch.Text & "")
                Loopindex = 1
                POSListoperation.Cols = gdataset.Tables("MyTable").Columns.Count '  It Will count no of feilds                
                vCode = Trim(gdataset.Tables("Mytable").Rows(0).Item(0) & "")
                For vIndex = 0 To gdataset.Tables("Mytable").Rows.Count - 1 ' It will check how many recor are there 
                    If vSamleCol = "Y" Then
                        If vCode = Trim(gdataset.Tables("MyTable").Rows(vIndex).Item(0) & "") Then
                            If gdataset.Tables("Mytable").Rows.Count = 0 Then '      gdataset.EOF Then
                                If Trim(vColValue & "") = "" Then
                                    vColValue = Trim(gdataset.Tables("Mytable").Rows(vIndex).Item(1) & "")
                                Else
                                    vColValue = vColValue & " ! " & Trim(gdataset.Tables("Mytable").Rows(vIndex).Item(1) & "") 'Trim(gdataset(1) & "")
                                End If
                                If gdataset.Tables("Mytable").Rows.Count > 0 Then  'Not gdataset.EOF Then
                                    If vCode <> Trim(gdataset.Tables("Mytable").Rows(vIndex).Item(0) & "") Then
                                        POSListoperation.set_TextMatrix(Loopindex, 0, Trim(vCode & ""))
                                        POSListoperation.set_TextMatrix(Loopindex, 1, Trim(vColValue & ""))
                                        Loopindex = Loopindex + 1
                                        vCode = Trim(gdataset.Tables("Mytable").Rows(vIndex).Item(0) & "")
                                        vColValue = ""
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If POSListoperation.Rows <= Loopindex Then
                            POSListoperation.Rows = POSListoperation.Rows + Loopindex
                        End If
                        For ColIndex = 0 To gdataset.Tables("mytable").Columns.Count - 1
                            POSListoperation.set_TextMatrix(Loopindex, ColIndex, Trim(gdataset.Tables("mytable").Rows(vIndex).Item(ColIndex) & ""))
                        Next ColIndex
                        Loopindex = Loopindex + 1
                    End If
                Next
            Else
                txtSearch.Text = Trim(vLastString & "")
                MsgBox("Specified Record is not available", MsgBoxStyle.Exclamation + MsgBoxStyle.OKOnly, gCompanyname)
                txtSearch.Focus()
            End If
            ssql = ""
        End If
    End Sub
    Private Sub ListOperattion1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose(True)
        End If
    End Sub

    Private Sub POSListoperation_EnterCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles POSListoperation.EnterCell
        POSListoperation.CellBackColor = Color.Red
    End Sub

    Private Sub POSListoperation_LeaveCell(ByVal sender As Object, ByVal e As System.EventArgs) Handles POSListoperation.LeaveCell
        POSListoperation.CellBackColor = Color.White
    End Sub
End Class