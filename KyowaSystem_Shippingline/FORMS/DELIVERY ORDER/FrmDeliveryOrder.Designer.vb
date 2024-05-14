<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDeliveryOrder
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbConsignee = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbMV = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbRegno = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbMasterBL = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtArrivalDate = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cmbVoyage = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cmbVoyage)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.dtArrivalDate)
        Me.Panel1.Controls.Add(Me.cmbMasterBL)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cmbRegno)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbMV)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmbConsignee)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(393, 222)
        Me.Panel1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(53, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CONSIGNEE:"
        '
        'cmbConsignee
        '
        Me.cmbConsignee.FormattingEnabled = True
        Me.cmbConsignee.Location = New System.Drawing.Point(129, 35)
        Me.cmbConsignee.Name = "cmbConsignee"
        Me.cmbConsignee.Size = New System.Drawing.Size(236, 22)
        Me.cmbConsignee.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ARRIVAL IN MANILA:"
        '
        'cmbMV
        '
        Me.cmbMV.FormattingEnabled = True
        Me.cmbMV.Location = New System.Drawing.Point(129, 91)
        Me.cmbMV.Name = "cmbMV"
        Me.cmbMV.Size = New System.Drawing.Size(142, 22)
        Me.cmbMV.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "MOTHER VESSEL:"
        '
        'cmbRegno
        '
        Me.cmbRegno.FormattingEnabled = True
        Me.cmbRegno.Location = New System.Drawing.Point(129, 119)
        Me.cmbRegno.Name = "cmbRegno"
        Me.cmbRegno.Size = New System.Drawing.Size(236, 22)
        Me.cmbRegno.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "REGISTRY NO:"
        '
        'cmbMasterBL
        '
        Me.cmbMasterBL.FormattingEnabled = True
        Me.cmbMasterBL.Location = New System.Drawing.Point(129, 147)
        Me.cmbMasterBL.Name = "cmbMasterBL"
        Me.cmbMasterBL.Size = New System.Drawing.Size(236, 22)
        Me.cmbMasterBL.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(56, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "MASTER BL:"
        '
        'dtArrivalDate
        '
        Me.dtArrivalDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtArrivalDate.Location = New System.Drawing.Point(129, 64)
        Me.dtArrivalDate.Name = "dtArrivalDate"
        Me.dtArrivalDate.Size = New System.Drawing.Size(236, 22)
        Me.dtArrivalDate.TabIndex = 11
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(294, 178)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 32)
        Me.Button2.TabIndex = 13
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
        Me.Button3.Location = New System.Drawing.Point(198, 178)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 32)
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "GENERATE"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'cmbVoyage
        '
        Me.cmbVoyage.FormattingEnabled = True
        Me.cmbVoyage.Location = New System.Drawing.Point(294, 91)
        Me.cmbVoyage.Name = "cmbVoyage"
        Me.cmbVoyage.Size = New System.Drawing.Size(71, 22)
        Me.cmbVoyage.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(276, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 14)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "V-"
        '
        'FrmDeliveryOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 222)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmDeliveryOrder"
        Me.Text = "FrmDeliveryOrder"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtArrivalDate As DateTimePicker
    Friend WithEvents cmbMasterBL As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbRegno As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbMV As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbConsignee As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents cmbVoyage As ComboBox
    Friend WithEvents Label6 As Label
End Class
