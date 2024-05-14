<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportCargoLoadingMenu
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
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rdFCL = New System.Windows.Forms.RadioButton()
        Me.rdLCL = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtFROM = New System.Windows.Forms.DateTimePicker()
        Me.DtTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdDestination = New System.Windows.Forms.RadioButton()
        Me.rdPrincipal = New System.Windows.Forms.RadioButton()
        Me.rdBilling = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(341, 286)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rdFCL)
        Me.GroupBox6.Controls.Add(Me.rdLCL)
        Me.GroupBox6.Location = New System.Drawing.Point(13, 167)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(316, 48)
        Me.GroupBox6.TabIndex = 8
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "TYPE OF GENERATE"
        '
        'rdFCL
        '
        Me.rdFCL.AutoSize = True
        Me.rdFCL.Checked = True
        Me.rdFCL.Location = New System.Drawing.Point(96, 21)
        Me.rdFCL.Name = "rdFCL"
        Me.rdFCL.Size = New System.Drawing.Size(42, 18)
        Me.rdFCL.TabIndex = 1
        Me.rdFCL.TabStop = True
        Me.rdFCL.Text = "FCL"
        Me.rdFCL.UseVisualStyleBackColor = True
        '
        'rdLCL
        '
        Me.rdLCL.AutoSize = True
        Me.rdLCL.Location = New System.Drawing.Point(179, 21)
        Me.rdLCL.Name = "rdLCL"
        Me.rdLCL.Size = New System.Drawing.Size(41, 18)
        Me.rdLCL.TabIndex = 0
        Me.rdLCL.Text = "LCL"
        Me.rdLCL.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(179, 232)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 32)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "CANCEL"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Gold
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(83, 232)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 32)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "GENERATE"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.DtTo)
        Me.GroupBox1.Controls.Add(Me.dtFROM)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(316, 86)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DATE"
        '
        'dtFROM
        '
        Me.dtFROM.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFROM.Location = New System.Drawing.Point(68, 21)
        Me.dtFROM.Name = "dtFROM"
        Me.dtFROM.Size = New System.Drawing.Size(164, 22)
        Me.dtFROM.TabIndex = 0
        '
        'DtTo
        '
        Me.DtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtTo.Location = New System.Drawing.Point(68, 50)
        Me.DtTo.Name = "DtTo"
        Me.DtTo.Size = New System.Drawing.Size(164, 22)
        Me.DtTo.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "FROM:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "TO:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdBilling)
        Me.GroupBox2.Controls.Add(Me.rdDestination)
        Me.GroupBox2.Controls.Add(Me.rdPrincipal)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 105)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(316, 48)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TYPE OF RATES"
        '
        'rdDestination
        '
        Me.rdDestination.AutoSize = True
        Me.rdDestination.Checked = True
        Me.rdDestination.Location = New System.Drawing.Point(9, 21)
        Me.rdDestination.Name = "rdDestination"
        Me.rdDestination.Size = New System.Drawing.Size(95, 18)
        Me.rdDestination.TabIndex = 1
        Me.rdDestination.TabStop = True
        Me.rdDestination.Text = "DESTINATION"
        Me.rdDestination.UseVisualStyleBackColor = True
        '
        'rdPrincipal
        '
        Me.rdPrincipal.AutoSize = True
        Me.rdPrincipal.Location = New System.Drawing.Point(128, 21)
        Me.rdPrincipal.Name = "rdPrincipal"
        Me.rdPrincipal.Size = New System.Drawing.Size(77, 18)
        Me.rdPrincipal.TabIndex = 0
        Me.rdPrincipal.Text = "PRINCIPAL"
        Me.rdPrincipal.UseVisualStyleBackColor = True
        '
        'rdBilling
        '
        Me.rdBilling.AutoSize = True
        Me.rdBilling.Location = New System.Drawing.Point(232, 21)
        Me.rdBilling.Name = "rdBilling"
        Me.rdBilling.Size = New System.Drawing.Size(66, 18)
        Me.rdBilling.TabIndex = 2
        Me.rdBilling.Text = "BILLING"
        Me.rdBilling.UseVisualStyleBackColor = True
        '
        'FrmImportCargoLoadingMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(341, 286)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmImportCargoLoadingMenu"
        Me.Text = "FrmImportCargoLoadingMenu"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DtTo As DateTimePicker
    Friend WithEvents dtFROM As DateTimePicker
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents rdFCL As RadioButton
    Friend WithEvents rdLCL As RadioButton
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rdBilling As RadioButton
    Friend WithEvents rdDestination As RadioButton
    Friend WithEvents rdPrincipal As RadioButton
End Class
