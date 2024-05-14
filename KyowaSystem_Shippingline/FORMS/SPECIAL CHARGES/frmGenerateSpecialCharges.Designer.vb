<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenerateSpecialCharges
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBLNo = New System.Windows.Forms.TextBox()
        Me.cmbFeederVessel = New System.Windows.Forms.ComboBox()
        Me.cmbCharges = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cmbVoyage = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblPleaseWait = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblPleaseWait)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(326, 304)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbVoyage)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtBLNo)
        Me.GroupBox2.Controls.Add(Me.cmbFeederVessel)
        Me.GroupBox2.Controls.Add(Me.cmbCharges)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(26, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(279, 133)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "INFO"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 108)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "B/L NO:"
        '
        'txtBLNo
        '
        Me.txtBLNo.Location = New System.Drawing.Point(67, 105)
        Me.txtBLNo.Name = "txtBLNo"
        Me.txtBLNo.Size = New System.Drawing.Size(205, 22)
        Me.txtBLNo.TabIndex = 6
        '
        'cmbFeederVessel
        '
        Me.cmbFeederVessel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbFeederVessel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFeederVessel.FormattingEnabled = True
        Me.cmbFeederVessel.Location = New System.Drawing.Point(67, 39)
        Me.cmbFeederVessel.Name = "cmbFeederVessel"
        Me.cmbFeederVessel.Size = New System.Drawing.Size(205, 22)
        Me.cmbFeederVessel.TabIndex = 5
        '
        'cmbCharges
        '
        Me.cmbCharges.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCharges.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCharges.FormattingEnabled = True
        Me.cmbCharges.Location = New System.Drawing.Point(67, 18)
        Me.cmbCharges.Name = "cmbCharges"
        Me.cmbCharges.Size = New System.Drawing.Size(205, 22)
        Me.cmbCharges.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "FV:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CHARGES:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtTo)
        Me.GroupBox1.Controls.Add(Me.dtFrom)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 163)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(279, 74)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "BOOKING DATE"
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(67, 43)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(205, 22)
        Me.dtTo.TabIndex = 3
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(67, 22)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(205, 22)
        Me.dtFrom.TabIndex = 2
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
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(227, 260)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 32)
        Me.Button2.TabIndex = 13
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
        Me.Button3.Location = New System.Drawing.Point(131, 260)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 32)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "GENERATE"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'cmbVoyage
        '
        Me.cmbVoyage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbVoyage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVoyage.FormattingEnabled = True
        Me.cmbVoyage.Location = New System.Drawing.Point(67, 60)
        Me.cmbVoyage.Name = "cmbVoyage"
        Me.cmbVoyage.Size = New System.Drawing.Size(205, 22)
        Me.cmbVoyage.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "VOTAGE:"
        '
        'lblPleaseWait
        '
        Me.lblPleaseWait.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPleaseWait.Location = New System.Drawing.Point(12, 242)
        Me.lblPleaseWait.Name = "lblPleaseWait"
        Me.lblPleaseWait.Size = New System.Drawing.Size(308, 46)
        Me.lblPleaseWait.TabIndex = 34
        Me.lblPleaseWait.Text = "PLEASE WAIT..."
        Me.lblPleaseWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblPleaseWait.Visible = False
        '
        'frmGenerateSpecialCharges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 304)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmGenerateSpecialCharges"
        Me.Text = "frmGenerateSpecialCharges"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtBLNo As TextBox
    Friend WithEvents cmbFeederVessel As ComboBox
    Friend WithEvents cmbCharges As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents cmbVoyage As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblPleaseWait As Label
End Class
