<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGenerateOnhireUnitsMenu
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtValidity = New System.Windows.Forms.DateTimePicker()
        Me.VALIDITY = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbOnhire = New System.Windows.Forms.ComboBox()
        Me.cmbBookingNo = New System.Windows.Forms.ComboBox()
        Me.cmbCy = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(454, 190)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.dtValidity)
        Me.GroupBox2.Controls.Add(Me.VALIDITY)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cmbOnhire)
        Me.GroupBox2.Controls.Add(Me.cmbBookingNo)
        Me.GroupBox2.Controls.Add(Me.cmbCy)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(430, 166)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "INFO"
        '
        'dtValidity
        '
        Me.dtValidity.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtValidity.Location = New System.Drawing.Point(87, 123)
        Me.dtValidity.Name = "dtValidity"
        Me.dtValidity.Size = New System.Drawing.Size(108, 22)
        Me.dtValidity.TabIndex = 7
        '
        'VALIDITY
        '
        Me.VALIDITY.AutoSize = True
        Me.VALIDITY.Location = New System.Drawing.Point(26, 129)
        Me.VALIDITY.Name = "VALIDITY"
        Me.VALIDITY.Size = New System.Drawing.Size(55, 14)
        Me.VALIDITY.TabIndex = 16
        Me.VALIDITY.Text = "VALIDITY:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(90, 14)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "ON-HIRE UNITS:"
        '
        'cmbOnhire
        '
        Me.cmbOnhire.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbOnhire.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOnhire.FormattingEnabled = True
        Me.cmbOnhire.Location = New System.Drawing.Point(9, 88)
        Me.cmbOnhire.Name = "cmbOnhire"
        Me.cmbOnhire.Size = New System.Drawing.Size(415, 22)
        Me.cmbOnhire.TabIndex = 2
        '
        'cmbBookingNo
        '
        Me.cmbBookingNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbBookingNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBookingNo.FormattingEnabled = True
        Me.cmbBookingNo.Location = New System.Drawing.Point(87, 39)
        Me.cmbBookingNo.Name = "cmbBookingNo"
        Me.cmbBookingNo.Size = New System.Drawing.Size(337, 22)
        Me.cmbBookingNo.TabIndex = 1
        '
        'cmbCy
        '
        Me.cmbCy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCy.FormattingEnabled = True
        Me.cmbCy.Location = New System.Drawing.Point(87, 18)
        Me.cmbCy.Name = "cmbCy"
        Me.cmbCy.Size = New System.Drawing.Size(337, 22)
        Me.cmbCy.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "BOOKING NO:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CY NAME:"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(353, 118)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 32)
        Me.Button2.TabIndex = 12
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
        Me.Button3.Location = New System.Drawing.Point(257, 118)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 32)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "GENERATE"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'FrmGenerateOnhireUnitsMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(454, 190)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmGenerateOnhireUnitsMenu"
        Me.Text = "FrmGenerateOnhireUnits"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtValidity As DateTimePicker
    Friend WithEvents VALIDITY As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbOnhire As ComboBox
    Friend WithEvents cmbBookingNo As ComboBox
    Friend WithEvents cmbCy As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
