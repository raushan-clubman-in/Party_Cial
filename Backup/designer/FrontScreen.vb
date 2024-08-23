Imports System.Data.SqlClient  ' This only for SQL
'Imports System.Data.OleDb   This is for both Oracle and SQL
Public Class FrontScreen
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents txtPassWord As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents AxMSFlexGrid1 As AxMSFlexGridLib.AxMSFlexGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FrontScreen))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.txtPassWord = New System.Windows.Forms.TextBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.AxMSFlexGrid1 = New AxMSFlexGridLib.AxMSFlexGrid
        CType(Me.AxMSFlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(320, 299)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(320, 332)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Pass Word :"
        '
        'txtUserName
        '
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserName.Location = New System.Drawing.Point(408, 296)
        Me.txtUserName.MaxLength = 20
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(104, 22)
        Me.txtUserName.TabIndex = 2
        Me.txtUserName.Text = ""
        '
        'txtPassWord
        '
        Me.txtPassWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassWord.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPassWord.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassWord.Location = New System.Drawing.Point(408, 329)
        Me.txtPassWord.Name = "txtPassWord"
        Me.txtPassWord.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassWord.Size = New System.Drawing.Size(104, 22)
        Me.txtPassWord.TabIndex = 3
        Me.txtPassWord.Text = ""
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(534, 296)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(88, 24)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "OK"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(534, 328)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(88, 24)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(304, 256)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 136)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'AxMSFlexGrid1
        '
        Me.AxMSFlexGrid1.Location = New System.Drawing.Point(528, 168)
        Me.AxMSFlexGrid1.Name = "AxMSFlexGrid1"
        Me.AxMSFlexGrid1.OcxState = CType(resources.GetObject("AxMSFlexGrid1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxMSFlexGrid1.Size = New System.Drawing.Size(8, 8)
        Me.AxMSFlexGrid1.TabIndex = 7
        '
        'FrontScreen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(7, 15)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(226, Byte), CType(226, Byte), CType(226, Byte))
        Me.ClientSize = New System.Drawing.Size(648, 462)
        Me.Controls.Add(Me.AxMSFlexGrid1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtPassWord)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrontScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CLUB POS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.AxMSFlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim con As New SqlConnection
    Dim cmd As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim cs As String
    Private Sub FrontScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '''cs = "Data source=SYSTEM4\SYSTEM4;initial catalog=POSclub;User id=sa"
        '''con = New SqlConnection(cs)
        '''Try
        '''    con.Open()
        '''Catch ex As Exception
        '''    MsgBox(ex.Message)
        '''End Try
        '''cmdOK.Focus()
        '---------------------
        Me.Hide()
        Dim FrontScreen As New FrontScreen
        FrontScreen.Dispose(True)
        Dim Main As New PartyMDI
        Main.Show()
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        'If Trim(txtPassWord.Text & "") <> "" And Trim(txtUserName.Text & "") <> "" Then
        Dim Main As New PartyMDI
        Main.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.Hide()
        Main.Show()
        'Else
        '    MsgBox("Fields cannot be blank", MsgBoxStyle.Information)
        '    txtUserName.Focus()
        'End If
    End Sub
    Private Sub txtUserName_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUserName.LostFocus
        If Trim(txtUserName.Text & "") <> "" Then
            cmd = New SqlCommand("Select USername from UserAdmin ", con)
            dr = cmd.ExecuteReader
            While dr.Read
                If txtUserName.Text = UCase(dr(0)) Then
                    txtPassWord.Focus()
                Else
                    MsgBox("User not found", MsgBoxStyle.Information, "PAR")
                    txtUserName.Text = ""
                    txtUserName.Focus()
                End If
            End While
            dr.Close()
        End If
    End Sub
    Private Sub txtPassWord_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPassWord.LostFocus
        If Trim(txtPassWord.Text & "") <> "" Then
            cmd = New SqlCommand("Select Pass_word from UserAdmin Where UserName='" & Trim(txtUserName.Text) & "'", con)
            dr = cmd.ExecuteReader
            While dr.Read
                If txtPassWord.Text = UCase(dr(0)) Then
                    cmdOK.Focus()
                Else
                    MsgBox("Password not found", MsgBoxStyle.Information, "PAR")
                    txtPassWord.Text = ""
                    txtPassWord.Focus()
                End If
            End While
            dr.Close()
        End If
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        End
    End Sub
    Private Sub txtUserName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserName.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            txtPassWord.Focus()
        End If
    End Sub
    Private Sub txtPassWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassWord.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(13) Then
            cmdOK.Focus()
        End If
    End Sub
End Class