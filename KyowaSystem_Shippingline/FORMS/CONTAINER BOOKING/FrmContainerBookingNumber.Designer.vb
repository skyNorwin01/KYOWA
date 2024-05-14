<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmContainerBookingNumber
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContainerBookingNumber))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbValidityDate = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtValidityDate = New System.Windows.Forms.DateTimePicker()
        Me.CmbLeasing = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtContNo = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.cmbContSize = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtContCount = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.dtContainerListBooking = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.txtValidityDate = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dtContainerListBooking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.txtValidityDate)
        Me.Panel1.Controls.Add(Me.cmbValidityDate)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.dtValidityDate)
        Me.Panel1.Controls.Add(Me.CmbLeasing)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtContNo)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.btnAdd)
        Me.Panel1.Controls.Add(Me.cmbContSize)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtContCount)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.dtContainerListBooking)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(868, 245)
        Me.Panel1.TabIndex = 2
        '
        'cmbValidityDate
        '
        Me.cmbValidityDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbValidityDate.FormattingEnabled = True
        Me.cmbValidityDate.Location = New System.Drawing.Point(715, 2)
        Me.cmbValidityDate.Name = "cmbValidityDate"
        Me.cmbValidityDate.Size = New System.Drawing.Size(110, 22)
        Me.cmbValidityDate.TabIndex = 52
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(639, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 14)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Validity Date"
        '
        'dtValidityDate
        '
        Me.dtValidityDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtValidityDate.Location = New System.Drawing.Point(642, 23)
        Me.dtValidityDate.Name = "dtValidityDate"
        Me.dtValidityDate.Size = New System.Drawing.Size(183, 22)
        Me.dtValidityDate.TabIndex = 50
        Me.dtValidityDate.Visible = False
        '
        'CmbLeasing
        '
        Me.CmbLeasing.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbLeasing.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbLeasing.BackColor = System.Drawing.SystemColors.Info
        Me.CmbLeasing.FormattingEnabled = True
        Me.CmbLeasing.Location = New System.Drawing.Point(13, 23)
        Me.CmbLeasing.Name = "CmbLeasing"
        Me.CmbLeasing.Size = New System.Drawing.Size(191, 22)
        Me.CmbLeasing.TabIndex = 49
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 14)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Leasing Company"
        '
        'txtContNo
        '
        Me.txtContNo.BackColor = System.Drawing.SystemColors.Info
        Me.txtContNo.Location = New System.Drawing.Point(372, 23)
        Me.txtContNo.Name = "txtContNo"
        Me.txtContNo.Size = New System.Drawing.Size(263, 22)
        Me.txtContNo.TabIndex = 47
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(369, 6)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(128, 14)
        Me.Label20.TabIndex = 46
        Me.Label20.Text = "Container Booking No."
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(831, 22)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(29, 23)
        Me.btnAdd.TabIndex = 45
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'cmbContSize
        '
        Me.cmbContSize.BackColor = System.Drawing.SystemColors.Info
        Me.cmbContSize.FormattingEnabled = True
        Me.cmbContSize.Location = New System.Drawing.Point(283, 23)
        Me.cmbContSize.Name = "cmbContSize"
        Me.cmbContSize.Size = New System.Drawing.Size(83, 22)
        Me.cmbContSize.TabIndex = 44
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(280, 6)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 14)
        Me.Label15.TabIndex = 43
        Me.Label15.Text = "Size"
        '
        'txtContCount
        '
        Me.txtContCount.BackColor = System.Drawing.SystemColors.Info
        Me.txtContCount.Location = New System.Drawing.Point(210, 23)
        Me.txtContCount.Name = "txtContCount"
        Me.txtContCount.Size = New System.Drawing.Size(67, 22)
        Me.txtContCount.TabIndex = 42
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(207, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(38, 14)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Count"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.BtnSave)
        Me.Panel2.Location = New System.Drawing.Point(653, 188)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(212, 54)
        Me.Panel2.TabIndex = 40
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.SystemColors.Desktop
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.ImageIndex = 0
        Me.btnCancel.ImageList = Me.ImageList1
        Me.btnCancel.Location = New System.Drawing.Point(99, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(108, 45)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "CLOSE"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8-close-window-100.png")
        Me.ImageList1.Images.SetKeyName(1, "icons8-save-all-100.png")
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.Color.Gold
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSave.ImageIndex = 1
        Me.BtnSave.ImageList = Me.ImageList1
        Me.BtnSave.Location = New System.Drawing.Point(3, 4)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(90, 45)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "SAVE"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'dtContainerListBooking
        '
        Me.dtContainerListBooking.AllowUserToAddRows = False
        Me.dtContainerListBooking.AllowUserToDeleteRows = False
        Me.dtContainerListBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtContainerListBooking.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column1, Me.Column2, Me.Column3, Me.Column6, Me.Column4})
        Me.dtContainerListBooking.Location = New System.Drawing.Point(13, 52)
        Me.dtContainerListBooking.Name = "dtContainerListBooking"
        Me.dtContainerListBooking.ReadOnly = True
        Me.dtContainerListBooking.Size = New System.Drawing.Size(847, 131)
        Me.dtContainerListBooking.TabIndex = 0
        '
        'Column5
        '
        Me.Column5.HeaderText = "LEASING COMPANY"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 200
        '
        'Column1
        '
        Me.Column1.HeaderText = "QTY"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "SIZE"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "CONTAINER BOOKING NO"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 230
        '
        'Column6
        '
        Me.Column6.HeaderText = "VALIDITY DATE"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 120
        '
        'Column4
        '
        Me.Column4.HeaderText = ""
        Me.Column4.Image = CType(resources.GetObject("Column4.Image"), System.Drawing.Image)
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 25
        '
        'txtValidityDate
        '
        Me.txtValidityDate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValidityDate.Location = New System.Drawing.Point(642, 22)
        Me.txtValidityDate.Name = "txtValidityDate"
        Me.txtValidityDate.Size = New System.Drawing.Size(183, 23)
        Me.txtValidityDate.TabIndex = 53
        '
        'FrmContainerBookingNumber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 245)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmContainerBookingNumber"
        Me.Text = "FrmContainerBookingNumber"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dtContainerListBooking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtContainerListBooking As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents BtnSave As Button
    Friend WithEvents txtContNo As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents cmbContSize As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtContCount As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents CmbLeasing As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtValidityDate As DateTimePicker
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewImageColumn
    Friend WithEvents cmbValidityDate As ComboBox
    Friend WithEvents txtValidityDate As TextBox
End Class
