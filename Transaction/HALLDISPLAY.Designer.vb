<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HALLDISPLAY
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HALLDISPLAY))
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CMD_SHOW = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Date_TO = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Date_FROM = New System.Windows.Forms.DateTimePicker()
        Me.DataGrid = New AxFPSpreadADO.AxfpSpread()
        Me.cmd_Clear = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Navy
        Me.Label16.Location = New System.Drawing.Point(226, 69)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(368, 29)
        Me.Label16.TabIndex = 549
        Me.Label16.Text = "PARTY AVAILABILITY STATUS"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.CMD_SHOW)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Date_TO)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Date_FROM)
        Me.GroupBox1.Location = New System.Drawing.Point(192, 115)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(624, 64)
        Me.GroupBox1.TabIndex = 550
        Me.GroupBox1.TabStop = False
        '
        'CMD_SHOW
        '
        Me.CMD_SHOW.BackColor = System.Drawing.Color.Transparent
        Me.CMD_SHOW.BackgroundImage = CType(resources.GetObject("CMD_SHOW.BackgroundImage"), System.Drawing.Image)
        Me.CMD_SHOW.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CMD_SHOW.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMD_SHOW.ForeColor = System.Drawing.Color.White
        Me.CMD_SHOW.Image = CType(resources.GetObject("CMD_SHOW.Image"), System.Drawing.Image)
        Me.CMD_SHOW.Location = New System.Drawing.Point(480, 16)
        Me.CMD_SHOW.Name = "CMD_SHOW"
        Me.CMD_SHOW.Size = New System.Drawing.Size(96, 40)
        Me.CMD_SHOW.TabIndex = 588
        Me.CMD_SHOW.Text = "SHOW [F3]"
        Me.CMD_SHOW.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(320, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 24)
        Me.Label2.TabIndex = 587
        Me.Label2.Text = "TO :"
        '
        'Date_TO
        '
        Me.Date_TO.AllowDrop = True
        Me.Date_TO.CalendarMonthBackground = System.Drawing.SystemColors.InactiveCaption
        Me.Date_TO.CustomFormat = "dd/MM/yyyy"
        Me.Date_TO.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_TO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Date_TO.Location = New System.Drawing.Point(368, 24)
        Me.Date_TO.Name = "Date_TO"
        Me.Date_TO.Size = New System.Drawing.Size(96, 23)
        Me.Date_TO.TabIndex = 1
        Me.Date_TO.Value = New Date(2009, 1, 6, 15, 11, 31, 781)
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Book Antiqua", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(88, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 24)
        Me.Label1.TabIndex = 532
        Me.Label1.Text = "STATUS FROM :"
        '
        'Date_FROM
        '
        Me.Date_FROM.CalendarMonthBackground = System.Drawing.SystemColors.InactiveCaption
        Me.Date_FROM.CustomFormat = "dd/MM/yyyy"
        Me.Date_FROM.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_FROM.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.Date_FROM.Location = New System.Drawing.Point(208, 24)
        Me.Date_FROM.Name = "Date_FROM"
        Me.Date_FROM.Size = New System.Drawing.Size(96, 23)
        Me.Date_FROM.TabIndex = 0
        Me.Date_FROM.Value = New Date(2009, 1, 6, 15, 11, 31, 781)
        '
        'DataGrid
        '
        Me.DataGrid.DataSource = Nothing
        Me.DataGrid.Location = New System.Drawing.Point(182, 201)
        Me.DataGrid.Name = "DataGrid"
        Me.DataGrid.OcxState = CType(resources.GetObject("DataGrid.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DataGrid.Size = New System.Drawing.Size(661, 271)
        Me.DataGrid.TabIndex = 551
        '
        'cmd_Clear
        '
        Me.cmd_Clear.BackgroundImage = CType(resources.GetObject("cmd_Clear.BackgroundImage"), System.Drawing.Image)
        Me.cmd_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.cmd_Clear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmd_Clear.Location = New System.Drawing.Point(861, 114)
        Me.cmd_Clear.Name = "cmd_Clear"
        Me.cmd_Clear.Size = New System.Drawing.Size(133, 65)
        Me.cmd_Clear.TabIndex = 661
        Me.cmd_Clear.Text = "CLEAR[F6]"
        Me.cmd_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmd_Clear.UseVisualStyleBackColor = True
        '
        'HALLDISPLAY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1016, 726)
        Me.Controls.Add(Me.cmd_Clear)
        Me.Controls.Add(Me.DataGrid)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label16)
        Me.Name = "HALLDISPLAY"
        Me.Text = "HALLDISPLAY"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CMD_SHOW As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Date_TO As System.Windows.Forms.DateTimePicker
    Public WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Date_FROM As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGrid As AxFPSpreadADO.AxfpSpread
    Friend WithEvents cmd_Clear As System.Windows.Forms.Button
End Class
