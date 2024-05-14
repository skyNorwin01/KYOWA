<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGenerateLoadingSequence
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
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtETDMnl = New System.Windows.Forms.DateTimePicker()
        Me.DtETAMnl = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbLoadingSequence = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CmbBookingNo = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbRegno = New System.Windows.Forms.ComboBox()
        Me.cmbRefno = New System.Windows.Forms.ComboBox()
        Me.cmbCargoType = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbVoy = New System.Windows.Forms.ComboBox()
        Me.cmbFV = New System.Windows.Forms.ComboBox()
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
        Me.Panel1.Size = New System.Drawing.Size(286, 465)
        Me.Panel1.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(203, 423)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 32)
        Me.Button2.TabIndex = 10
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
        Me.Button3.Location = New System.Drawing.Point(107, 423)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 32)
        Me.Button3.TabIndex = 9
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
        Me.GroupBox3.Location = New System.Drawing.Point(278, 209)
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
        Me.GroupBox1.Location = New System.Drawing.Point(278, 125)
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
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.dtETDMnl)
        Me.GroupBox2.Controls.Add(Me.DtETAMnl)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.cmbLoadingSequence)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.CmbBookingNo)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cmbRegno)
        Me.GroupBox2.Controls.Add(Me.cmbRefno)
        Me.GroupBox2.Controls.Add(Me.cmbCargoType)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cmbVoy)
        Me.GroupBox2.Controls.Add(Me.cmbFV)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 355)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "INFO"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(-9, 285)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(272, 2)
        Me.Label13.TabIndex = 20
        '
        'dtETDMnl
        '
        Me.dtETDMnl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtETDMnl.Location = New System.Drawing.Point(66, 320)
        Me.dtETDMnl.Name = "dtETDMnl"
        Me.dtETDMnl.Size = New System.Drawing.Size(188, 22)
        Me.dtETDMnl.TabIndex = 8
        '
        'DtETAMnl
        '
        Me.DtETAMnl.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtETAMnl.Location = New System.Drawing.Point(66, 296)
        Me.DtETAMnl.Name = "DtETAMnl"
        Me.DtETAMnl.Size = New System.Drawing.Size(188, 22)
        Me.DtETAMnl.TabIndex = 7
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(4, 326)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 14)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "ETD MNL:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 302)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 14)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "ETA MNL:"
        '
        'cmbLoadingSequence
        '
        Me.cmbLoadingSequence.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbLoadingSequence.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLoadingSequence.FormattingEnabled = True
        Me.cmbLoadingSequence.Location = New System.Drawing.Point(49, 239)
        Me.cmbLoadingSequence.Name = "cmbLoadingSequence"
        Me.cmbLoadingSequence.Size = New System.Drawing.Size(205, 22)
        Me.cmbLoadingSequence.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 222)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(209, 14)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "LOADING SEQUENCE (FEEDER CARRIER)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(140, 14)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "CO-LOADER BOOKING NO."
        '
        'CmbBookingNo
        '
        Me.CmbBookingNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbBookingNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbBookingNo.FormattingEnabled = True
        Me.CmbBookingNo.Location = New System.Drawing.Point(49, 137)
        Me.CmbBookingNo.Name = "CmbBookingNo"
        Me.CmbBookingNo.Size = New System.Drawing.Size(205, 22)
        Me.CmbBookingNo.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 14)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "REG NO."
        '
        'cmbRegno
        '
        Me.cmbRegno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRegno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRegno.FormattingEnabled = True
        Me.cmbRegno.Location = New System.Drawing.Point(49, 88)
        Me.cmbRegno.Name = "cmbRegno"
        Me.cmbRegno.Size = New System.Drawing.Size(205, 22)
        Me.cmbRegno.TabIndex = 2
        '
        'cmbRefno
        '
        Me.cmbRefno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRefno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRefno.FormattingEnabled = True
        Me.cmbRefno.Location = New System.Drawing.Point(49, 187)
        Me.cmbRefno.Name = "cmbRefno"
        Me.cmbRefno.Size = New System.Drawing.Size(69, 22)
        Me.cmbRefno.TabIndex = 4
        '
        'cmbCargoType
        '
        Me.cmbCargoType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCargoType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCargoType.FormattingEnabled = True
        Me.cmbCargoType.Location = New System.Drawing.Point(124, 187)
        Me.cmbCargoType.Name = "cmbCargoType"
        Me.cmbCargoType.Size = New System.Drawing.Size(130, 22)
        Me.cmbCargoType.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "REFNO"
        '
        'cmbVoy
        '
        Me.cmbVoy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbVoy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVoy.FormattingEnabled = True
        Me.cmbVoy.Location = New System.Drawing.Point(49, 39)
        Me.cmbVoy.Name = "cmbVoy"
        Me.cmbVoy.Size = New System.Drawing.Size(205, 22)
        Me.cmbVoy.TabIndex = 1
        '
        'cmbFV
        '
        Me.cmbFV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbFV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFV.FormattingEnabled = True
        Me.cmbFV.Location = New System.Drawing.Point(49, 18)
        Me.cmbFV.Name = "cmbFV"
        Me.cmbFV.Size = New System.Drawing.Size(205, 22)
        Me.cmbFV.TabIndex = 0
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
        Me.Label1.Size = New System.Drawing.Size(28, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "F/V:"
        '
        'FrmGenerateLoadingSequence
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(286, 465)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmGenerateLoadingSequence"
        Me.Text = "FrmGenerateLoadingSequence"
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
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbRegno As ComboBox
    Friend WithEvents cmbRefno As ComboBox
    Friend WithEvents cmbCargoType As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbVoy As ComboBox
    Friend WithEvents cmbFV As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents CmbBookingNo As ComboBox
    Friend WithEvents cmbLoadingSequence As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents dtETDMnl As DateTimePicker
    Friend WithEvents DtETAMnl As DateTimePicker
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
End Class
