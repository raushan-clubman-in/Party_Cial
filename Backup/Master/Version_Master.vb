Imports System.IO
Imports System.Data.SqlClient
Public Class Version_Master
    Inherits System.Windows.Forms.Form
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
    Friend WithEvents lbl_Heading As System.Windows.Forms.Label
    Friend WithEvents frmbut As System.Windows.Forms.GroupBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Cmd_Add As System.Windows.Forms.Button
    Friend WithEvents lbl_sec2 As System.Windows.Forms.Label
    Friend WithEvents lbl_sec1 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txt_ImplementorName As System.Windows.Forms.TextBox
    Friend WithEvents txt_Developername As System.Windows.Forms.TextBox
    Friend WithEvents Txt_DocNo As System.Windows.Forms.TextBox
    Friend WithEvents Txt_ListofChanges As System.Windows.Forms.TextBox
    Friend WithEvents Dtp_DocDate As System.Windows.Forms.DateTimePicker
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Version_Master))
        Me.lbl_Heading = New System.Windows.Forms.Label
        Me.frmbut = New System.Windows.Forms.GroupBox
        Me.Cmd_Add = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Dtp_DocDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Txt_ListofChanges = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_DocNo = New System.Windows.Forms.TextBox
        Me.lbl_sec2 = New System.Windows.Forms.Label
        Me.txt_ImplementorName = New System.Windows.Forms.TextBox
        Me.lbl_sec1 = New System.Windows.Forms.Label
        Me.txt_Developername = New System.Windows.Forms.TextBox
        Me.frmbut.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl_Heading
        '
        Me.lbl_Heading.AutoSize = True
        Me.lbl_Heading.BackColor = System.Drawing.Color.Transparent
        Me.lbl_Heading.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_Heading.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lbl_Heading.Location = New System.Drawing.Point(248, 8)
        Me.lbl_Heading.Name = "lbl_Heading"
        Me.lbl_Heading.Size = New System.Drawing.Size(226, 31)
        Me.lbl_Heading.TabIndex = 5
        Me.lbl_Heading.Text = "Version Information"
        Me.lbl_Heading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmbut
        '
        Me.frmbut.BackColor = System.Drawing.Color.Transparent
        Me.frmbut.Controls.Add(Me.Cmd_Add)
        Me.frmbut.Location = New System.Drawing.Point(200, 384)
        Me.frmbut.Name = "frmbut"
        Me.frmbut.Size = New System.Drawing.Size(168, 56)
        Me.frmbut.TabIndex = 444
        Me.frmbut.TabStop = False
        '
        'Cmd_Add
        '
        Me.Cmd_Add.BackColor = System.Drawing.Color.ForestGreen
        Me.Cmd_Add.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Cmd_Add.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Add.ForeColor = System.Drawing.Color.White
        Me.Cmd_Add.Image = CType(resources.GetObject("Cmd_Add.Image"), System.Drawing.Image)
        Me.Cmd_Add.Location = New System.Drawing.Point(32, 16)
        Me.Cmd_Add.Name = "Cmd_Add"
        Me.Cmd_Add.Size = New System.Drawing.Size(104, 32)
        Me.Cmd_Add.TabIndex = 448
        Me.Cmd_Add.Text = "Save[F7]"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Dtp_DocDate)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Txt_ListofChanges)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Txt_DocNo)
        Me.GroupBox1.Controls.Add(Me.lbl_sec2)
        Me.GroupBox1.Controls.Add(Me.txt_ImplementorName)
        Me.GroupBox1.Controls.Add(Me.lbl_sec1)
        Me.GroupBox1.Controls.Add(Me.txt_Developername)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(680, 328)
        Me.GroupBox1.TabIndex = 450
        Me.GroupBox1.TabStop = False
        '
        'Dtp_DocDate
        '
        Me.Dtp_DocDate.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_DocDate.CalendarMonthBackground = System.Drawing.Color.White
        Me.Dtp_DocDate.CalendarTitleForeColor = System.Drawing.Color.AliceBlue
        Me.Dtp_DocDate.CustomFormat = "dd/MM/yyyy"
        Me.Dtp_DocDate.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dtp_DocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Dtp_DocDate.Location = New System.Drawing.Point(160, 160)
        Me.Dtp_DocDate.Name = "Dtp_DocDate"
        Me.Dtp_DocDate.Size = New System.Drawing.Size(96, 26)
        Me.Dtp_DocDate.TabIndex = 461
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 24)
        Me.Label3.TabIndex = 460
        Me.Label3.Text = "List of Changes :"
        '
        'Txt_ListofChanges
        '
        Me.Txt_ListofChanges.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Txt_ListofChanges.HideSelection = False
        Me.Txt_ListofChanges.Location = New System.Drawing.Point(160, 198)
        Me.Txt_ListofChanges.MaxLength = 2000
        Me.Txt_ListofChanges.Multiline = True
        Me.Txt_ListofChanges.Name = "Txt_ListofChanges"
        Me.Txt_ListofChanges.Size = New System.Drawing.Size(504, 114)
        Me.Txt_ListofChanges.TabIndex = 459
        Me.Txt_ListofChanges.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 160)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 24)
        Me.Label2.TabIndex = 458
        Me.Label2.Text = "Reference Doc Date :"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 24)
        Me.Label1.TabIndex = 456
        Me.Label1.Text = "Reference Doc No. :"
        '
        'Txt_DocNo
        '
        Me.Txt_DocNo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Txt_DocNo.Location = New System.Drawing.Point(160, 120)
        Me.Txt_DocNo.MaxLength = 50
        Me.Txt_DocNo.Name = "Txt_DocNo"
        Me.Txt_DocNo.Size = New System.Drawing.Size(400, 21)
        Me.Txt_DocNo.TabIndex = 455
        Me.Txt_DocNo.Text = ""
        '
        'lbl_sec2
        '
        Me.lbl_sec2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sec2.Location = New System.Drawing.Point(7, 72)
        Me.lbl_sec2.Name = "lbl_sec2"
        Me.lbl_sec2.Size = New System.Drawing.Size(145, 24)
        Me.lbl_sec2.TabIndex = 454
        Me.lbl_sec2.Text = "Implementor Name :"
        '
        'txt_ImplementorName
        '
        Me.txt_ImplementorName.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txt_ImplementorName.Location = New System.Drawing.Point(160, 72)
        Me.txt_ImplementorName.MaxLength = 100
        Me.txt_ImplementorName.Name = "txt_ImplementorName"
        Me.txt_ImplementorName.Size = New System.Drawing.Size(400, 21)
        Me.txt_ImplementorName.TabIndex = 453
        Me.txt_ImplementorName.Text = ""
        '
        'lbl_sec1
        '
        Me.lbl_sec1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_sec1.Location = New System.Drawing.Point(6, 32)
        Me.lbl_sec1.Name = "lbl_sec1"
        Me.lbl_sec1.Size = New System.Drawing.Size(138, 17)
        Me.lbl_sec1.TabIndex = 452
        Me.lbl_sec1.Text = "Developer Name:"
        '
        'txt_Developername
        '
        Me.txt_Developername.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txt_Developername.Location = New System.Drawing.Point(160, 32)
        Me.txt_Developername.MaxLength = 100
        Me.txt_Developername.Name = "txt_Developername"
        Me.txt_Developername.Size = New System.Drawing.Size(400, 21)
        Me.txt_Developername.TabIndex = 451
        Me.txt_Developername.Text = ""
        '
        'Version_Master
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(696, 446)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.frmbut)
        Me.Controls.Add(Me.lbl_Heading)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "Version_Master"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Version Information"
        Me.frmbut.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim sqlstring As String
    Dim boolchk As Boolean
    Dim gconnection As New GlobalClass
    Private Sub Version_Master_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F7 Then
            Call Cmd_Add_Click(sender, e)
            Exit Sub
        End If
    End Sub
    Public Sub checkValidation()
        boolchk = False
        If Trim(txt_Developername.Text) = "" Then
            MsgBox("Developer Name can not be Left Blank", MsgBoxStyle.Exclamation)
            txt_Developername.Focus()
            Exit Sub
        End If
        If Trim(txt_ImplementorName.Text) = "" Then
            MsgBox("Implementor Name can not be Left Blank", MsgBoxStyle.Exclamation)
            txt_ImplementorName.Focus()
            Exit Sub
        End If

        If Trim(Txt_DocNo.Text) = "" Then
            MsgBox("Ref Doc No can not be Left Blank", MsgBoxStyle.Exclamation)
            Txt_DocNo.Focus()
            Exit Sub
        End If

        If Trim(Txt_ListofChanges.Text) = "" Then
            MsgBox("List of Changes can not be Left Blank", MsgBoxStyle.Exclamation)
            Txt_ListofChanges.Focus()
            Exit Sub
        End If

        boolchk = True
    End Sub
    Private Sub Cmd_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cmd_Add.Click
        Call checkValidation()
        Dim strSQL As String
        Dim Insert(0) As String
        If Cmd_Add.Text = "Save[F7]" Then
            If boolchk = False Then Exit Sub
            Dim CHECK As String

            strSQL = " INSERT INTO Master..CLUBMANVERSION (DateofEntry,ClubName,ClubShortName,ModuleName,DateofVersion,SizeofVersion,DeveloperName,ImplementerName,ChangeReference,ChangeRefDate,ListofChanges) "
            strSQL = strSQL & " VALUES (getdate(),'" & MyCompanyName & "','" & gShortName & "','" & GModule & "','" & Format(dtLastWriteTime, "dd/MMM/yyyy hh:mm:ss") & "'," & FileSize & ",'" & txt_Developername.Text & "','" & txt_ImplementorName.Text & "','" & Txt_DocNo.Text & "','" & Format(Dtp_DocDate.Value, "dd/MMM/yyyy") & "','" & Trim(Txt_ListofChanges.Text) & "')"
            ReDim Preserve Insert(Insert.Length)
            Insert(Insert.Length - 1) = strSQL

            gconnection.MoreTrans(Insert)

            Me.Close()
        End If
    End Sub
    Private Sub Version_Master_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        gconnection.FocusSetting(Me)
        'If GVerValidate = True Then
        '    Dim sql As String
        '    sql = "select * FROM Master..CLUBMANVERSION Where ModuleName='SMARTCARD' AND DATEOFVERSION='" & Format(dtCreationDate, "dd/MMM/yyyy hh:mm:ss") & "' AND SizeofVersion=" & FileSize
        '    gconnection.getDataSet(sql, "FileValidate")
        '    If gdataset.Tables("FileValidate").Rows.Count > 0 Then
        '        Me.Close()
        '    End If
        'End If
    End Sub
    Private Sub txt_Developername_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_Developername.KeyDown
        If Trim(txt_Developername.Text) <> "" Then
            If e.KeyCode = Keys.Return Then
                txt_ImplementorName.Focus()
            End If
        End If
    End Sub
    Private Sub txt_ImplementorName_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txt_ImplementorName.KeyDown
        If Trim(txt_ImplementorName.Text) <> "" Then
            If e.KeyCode = Keys.Return Then
                Txt_DocNo.Focus()
            End If
        End If
    End Sub
    Private Sub Dtp_DocDate_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dtp_DocDate.KeyDown
        If e.KeyCode = Keys.Return Then
            Txt_ListofChanges.Focus()
        End If
    End Sub
    Private Sub Txt_ListofChanges_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_ListofChanges.KeyDown
        If Trim(Txt_ListofChanges.Text) <> "" Then
            If e.KeyCode = Keys.Return Then
                Cmd_Add.Focus()
            End If
        End If
    End Sub
    Private Sub Txt_DocNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txt_DocNo.KeyDown
        If e.KeyCode = Keys.Return Then
            Dtp_DocDate.Focus()
        End If
    End Sub

    Private Sub Txt_DocNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_DocNo.TextChanged

    End Sub
End Class