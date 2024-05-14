<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDamage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDamage))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtMaterialCost = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtLaborCost = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtManHour = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbDesc = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dtList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtDateIn = New System.Windows.Forms.DateTimePicker()
        Me.txtEIR = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbLine = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTypeSize = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtContainerNO = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.txtMaterialCost)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtLaborCost)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtManHour)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.cmbDesc)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.dtList)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.dtDateIn)
        Me.Panel1.Controls.Add(Me.txtEIR)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cmbLine)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmbTypeSize)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtContainerNO)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(539, 603)
        Me.Panel1.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gold
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(374, 235)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 25)
        Me.Button1.TabIndex = 31
        Me.Button1.Text = "Add"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'txtMaterialCost
        '
        Me.txtMaterialCost.Location = New System.Drawing.Point(159, 214)
        Me.txtMaterialCost.Name = "txtMaterialCost"
        Me.txtMaterialCost.Size = New System.Drawing.Size(264, 22)
        Me.txtMaterialCost.TabIndex = 30
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(70, 217)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 14)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Material Cost:"
        '
        'txtLaborCost
        '
        Me.txtLaborCost.Location = New System.Drawing.Point(159, 193)
        Me.txtLaborCost.Name = "txtLaborCost"
        Me.txtLaborCost.Size = New System.Drawing.Size(264, 22)
        Me.txtLaborCost.TabIndex = 28
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(87, 196)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(66, 14)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Labor Cost:"
        '
        'txtManHour
        '
        Me.txtManHour.Location = New System.Drawing.Point(159, 172)
        Me.txtManHour.Name = "txtManHour"
        Me.txtManHour.Size = New System.Drawing.Size(264, 22)
        Me.txtManHour.TabIndex = 26
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(90, 175)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 14)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Man Hour:"
        '
        'cmbDesc
        '
        Me.cmbDesc.FormattingEnabled = True
        Me.cmbDesc.Location = New System.Drawing.Point(159, 151)
        Me.cmbDesc.Name = "cmbDesc"
        Me.cmbDesc.Size = New System.Drawing.Size(264, 22)
        Me.cmbDesc.TabIndex = 24
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(117, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 14)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Desc:"
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.Black
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(447, 563)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(80, 32)
        Me.Button5.TabIndex = 22
        Me.Button5.Text = "CLOSE"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Gold
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(370, 563)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(71, 32)
        Me.Button3.TabIndex = 21
        Me.Button3.Text = "SAVE"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'dtList
        '
        Me.dtList.AllowUserToAddRows = False
        Me.dtList.AllowUserToDeleteRows = False
        Me.dtList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6})
        Me.dtList.Location = New System.Drawing.Point(13, 283)
        Me.dtList.Name = "dtList"
        Me.dtList.ReadOnly = True
        Me.dtList.Size = New System.Drawing.Size(514, 274)
        Me.dtList.TabIndex = 20
        '
        'Column1
        '
        Me.Column1.HeaderText = "DESCRIPTION OF REPAIRS"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "MAN HOUR"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "LABOR COST"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "MATERIAL COST"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "E"
        Me.Column5.Image = CType(resources.GetObject("Column5.Image"), System.Drawing.Image)
        Me.Column5.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 25
        '
        'Column6
        '
        Me.Column6.HeaderText = "D"
        Me.Column6.Image = CType(resources.GetObject("Column6.Image"), System.Drawing.Image)
        Me.Column6.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 25
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(98, 105)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 14)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "DATE IN:"
        '
        'dtDateIn
        '
        Me.dtDateIn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDateIn.Location = New System.Drawing.Point(159, 99)
        Me.dtDateIn.Name = "dtDateIn"
        Me.dtDateIn.Size = New System.Drawing.Size(119, 22)
        Me.dtDateIn.TabIndex = 12
        '
        'txtEIR
        '
        Me.txtEIR.Location = New System.Drawing.Point(159, 78)
        Me.txtEIR.Name = "txtEIR"
        Me.txtEIR.Size = New System.Drawing.Size(264, 22)
        Me.txtEIR.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(113, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "EIR #:"
        '
        'cmbLine
        '
        Me.cmbLine.FormattingEnabled = True
        Me.cmbLine.Location = New System.Drawing.Point(159, 57)
        Me.cmbLine.Name = "cmbLine"
        Me.cmbLine.Size = New System.Drawing.Size(264, 22)
        Me.cmbLine.TabIndex = 5
        Me.cmbLine.Text = "KYOWA LINE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(116, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "LINE:"
        '
        'cmbTypeSize
        '
        Me.cmbTypeSize.FormattingEnabled = True
        Me.cmbTypeSize.Location = New System.Drawing.Point(159, 36)
        Me.cmbTypeSize.Name = "cmbTypeSize"
        Me.cmbTypeSize.Size = New System.Drawing.Size(264, 22)
        Me.cmbTypeSize.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(88, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "TYPE/SIZE:"
        '
        'txtContainerNO
        '
        Me.txtContainerNO.Location = New System.Drawing.Point(159, 15)
        Me.txtContainerNO.Name = "txtContainerNO"
        Me.txtContainerNO.Size = New System.Drawing.Size(264, 22)
        Me.txtContainerNO.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(61, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "CONTAINER NO:"
        '
        'frmDamage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 603)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmDamage"
        Me.Text = "frmDamage"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtList As DataGridView
    Friend WithEvents Label7 As Label
    Friend WithEvents dtDateIn As DateTimePicker
    Friend WithEvents txtEIR As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbLine As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTypeSize As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtContainerNO As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents txtMaterialCost As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtLaborCost As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtManHour As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cmbDesc As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewImageColumn
    Friend WithEvents Column6 As DataGridViewImageColumn
End Class
