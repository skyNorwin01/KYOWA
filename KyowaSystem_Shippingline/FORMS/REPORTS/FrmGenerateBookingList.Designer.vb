<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGenerateBookingList
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dteETD = New System.Windows.Forms.DateTimePicker()
        Me.dtsETD = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dteETA = New System.Windows.Forms.DateTimePicker()
        Me.dtsETA = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCoLoaderBk = New System.Windows.Forms.TextBox()
        Me.cmbVoy = New System.Windows.Forms.ComboBox()
        Me.cmbMVessel = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 191)
        Me.Panel1.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(201, 149)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 32)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "CANCEL"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Gold
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(105, 149)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 32)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "GENERATE"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dteETD)
        Me.GroupBox3.Controls.Add(Me.dtsETD)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 238)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(260, 74)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "MV ETD"
        Me.GroupBox3.Visible = False
        '
        'dteETD
        '
        Me.dteETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteETD.Location = New System.Drawing.Point(49, 43)
        Me.dteETD.Name = "dteETD"
        Me.dteETD.Size = New System.Drawing.Size(205, 22)
        Me.dteETD.TabIndex = 3
        '
        'dtsETD
        '
        Me.dtsETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtsETD.Location = New System.Drawing.Point(49, 22)
        Me.dtsETD.Name = "dtsETD"
        Me.dtsETD.Size = New System.Drawing.Size(205, 22)
        Me.dtsETD.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 14)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "TO:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 14)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "FROM:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dteETA)
        Me.GroupBox1.Controls.Add(Me.dtsETA)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 158)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 74)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "MV ETA"
        Me.GroupBox1.Visible = False
        '
        'dteETA
        '
        Me.dteETA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dteETA.Location = New System.Drawing.Point(49, 43)
        Me.dteETA.Name = "dteETA"
        Me.dteETA.Size = New System.Drawing.Size(205, 22)
        Me.dteETA.TabIndex = 3
        '
        'dtsETA
        '
        Me.dtsETA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtsETA.Location = New System.Drawing.Point(49, 22)
        Me.dtsETA.Name = "dtsETA"
        Me.dtsETA.Size = New System.Drawing.Size(205, 22)
        Me.dtsETA.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 14)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "TO:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 14)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "FROM:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtCoLoaderBk)
        Me.GroupBox2.Controls.Add(Me.cmbVoy)
        Me.GroupBox2.Controls.Add(Me.cmbMVessel)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 119)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "INFO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "CO-LOADER BOOKING NO."
        '
        'txtCoLoaderBk
        '
        Me.txtCoLoaderBk.Location = New System.Drawing.Point(49, 91)
        Me.txtCoLoaderBk.Name = "txtCoLoaderBk"
        Me.txtCoLoaderBk.Size = New System.Drawing.Size(205, 22)
        Me.txtCoLoaderBk.TabIndex = 6
        '
        'cmbVoy
        '
        Me.cmbVoy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbVoy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVoy.FormattingEnabled = True
        Me.cmbVoy.Location = New System.Drawing.Point(49, 39)
        Me.cmbVoy.Name = "cmbVoy"
        Me.cmbVoy.Size = New System.Drawing.Size(205, 22)
        Me.cmbVoy.TabIndex = 5
        '
        'cmbMVessel
        '
        Me.cmbMVessel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbMVessel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbMVessel.FormattingEnabled = True
        Me.cmbMVessel.Location = New System.Drawing.Point(49, 18)
        Me.cmbMVessel.Name = "cmbMVessel"
        Me.cmbMVessel.Size = New System.Drawing.Size(205, 22)
        Me.cmbMVessel.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "VOY:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MV:"
        '
        'FrmGenerateBookingList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 191)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmGenerateBookingList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmGenerateBookingList"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dteETD As DateTimePicker
    Friend WithEvents dtsETD As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dteETA As DateTimePicker
    Friend WithEvents dtsETA As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbVoy As ComboBox
    Friend WithEvents cmbMVessel As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCoLoaderBk As TextBox
End Class
