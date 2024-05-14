<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCorrectionAdvice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCorrectionAdvice))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtRefno = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnSaveCs = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbCollect = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbPrepaid = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbNotifyParty = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbConsignee = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbShipper = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbIssuedAt = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbBlNo = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbVia = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbTo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbFrom = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.cmbCurrrency = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.cmbCurrrency)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtRefno)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.btnSaveCs)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmbCollect)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.cmbPrepaid)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.dtList)
        Me.Panel1.Controls.Add(Me.cmbNotifyParty)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cmbConsignee)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cmbShipper)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cmbIssuedAt)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.cmbBlNo)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cmbVia)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbTo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.cmbFrom)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtDate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(463, 491)
        Me.Panel1.TabIndex = 2
        '
        'txtRefno
        '
        Me.txtRefno.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefno.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtRefno.Location = New System.Drawing.Point(359, 8)
        Me.txtRefno.Name = "txtRefno"
        Me.txtRefno.Size = New System.Drawing.Size(92, 33)
        Me.txtRefno.TabIndex = 27
        Me.txtRefno.Text = "04/2021"
        Me.txtRefno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label10.Location = New System.Drawing.Point(325, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 19)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "C/A:"
        '
        'btnSaveCs
        '
        Me.btnSaveCs.BackColor = System.Drawing.Color.Gold
        Me.btnSaveCs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveCs.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveCs.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnSaveCs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveCs.ImageIndex = 1
        Me.btnSaveCs.ImageList = Me.ImageList1
        Me.btnSaveCs.Location = New System.Drawing.Point(243, 441)
        Me.btnSaveCs.Name = "btnSaveCs"
        Me.btnSaveCs.Size = New System.Drawing.Size(101, 45)
        Me.btnSaveCs.TabIndex = 25
        Me.btnSaveCs.Text = "SAVE"
        Me.btnSaveCs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveCs.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8-close-window-100.png")
        Me.ImageList1.Images.SetKeyName(1, "icons8-save-all-100.png")
        Me.ImageList1.Images.SetKeyName(2, "icons8-place-marker-100.png")
        Me.ImageList1.Images.SetKeyName(3, "icons8-euro-100.png")
        Me.ImageList1.Images.SetKeyName(4, "icons8-pass-fail-100.png")
        Me.ImageList1.Images.SetKeyName(5, "icons8-delete-25.png")
        Me.ImageList1.Images.SetKeyName(6, "icons8-delete-100.png")
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImageIndex = 0
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(350, 441)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 45)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "CLOSE"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmbCollect
        '
        Me.cmbCollect.BackColor = System.Drawing.SystemColors.Info
        Me.cmbCollect.FormattingEnabled = True
        Me.cmbCollect.Location = New System.Drawing.Point(129, 413)
        Me.cmbCollect.Name = "cmbCollect"
        Me.cmbCollect.Size = New System.Drawing.Size(322, 22)
        Me.cmbCollect.TabIndex = 24
        Me.cmbCollect.Text = "GUAM"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(23, 416)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 14)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "FREIGHT COLLECT:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPrepaid
        '
        Me.cmbPrepaid.BackColor = System.Drawing.SystemColors.Info
        Me.cmbPrepaid.FormattingEnabled = True
        Me.cmbPrepaid.Location = New System.Drawing.Point(129, 392)
        Me.cmbPrepaid.Name = "cmbPrepaid"
        Me.cmbPrepaid.Size = New System.Drawing.Size(322, 22)
        Me.cmbPrepaid.TabIndex = 22
        Me.cmbPrepaid.Text = "MANILA"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(11, 395)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 14)
        Me.Label12.TabIndex = 21
        Me.Label12.Text = "FREIGHT PREPAID:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtList
        '
        Me.dtList.AllowUserToAddRows = False
        Me.dtList.AllowUserToDeleteRows = False
        Me.dtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.dtList.Location = New System.Drawing.Point(12, 251)
        Me.dtList.Name = "dtList"
        Me.dtList.Size = New System.Drawing.Size(439, 135)
        Me.dtList.TabIndex = 20
        '
        'Column1
        '
        Me.Column1.HeaderText = "SIZE"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "CONTAINER NO"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column3
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = "0"
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column3.HeaderText = "AMOUNT"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 150
        '
        'cmbNotifyParty
        '
        Me.cmbNotifyParty.BackColor = System.Drawing.SystemColors.Info
        Me.cmbNotifyParty.FormattingEnabled = True
        Me.cmbNotifyParty.Location = New System.Drawing.Point(129, 198)
        Me.cmbNotifyParty.Name = "cmbNotifyParty"
        Me.cmbNotifyParty.Size = New System.Drawing.Size(322, 22)
        Me.cmbNotifyParty.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(26, 201)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 14)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "NOTIFY PARTY:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbConsignee
        '
        Me.cmbConsignee.BackColor = System.Drawing.SystemColors.Info
        Me.cmbConsignee.FormattingEnabled = True
        Me.cmbConsignee.Location = New System.Drawing.Point(129, 177)
        Me.cmbConsignee.Name = "cmbConsignee"
        Me.cmbConsignee.Size = New System.Drawing.Size(322, 22)
        Me.cmbConsignee.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(38, 180)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 14)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "CONSIGNEE:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbShipper
        '
        Me.cmbShipper.BackColor = System.Drawing.SystemColors.Info
        Me.cmbShipper.FormattingEnabled = True
        Me.cmbShipper.Location = New System.Drawing.Point(129, 156)
        Me.cmbShipper.Name = "cmbShipper"
        Me.cmbShipper.Size = New System.Drawing.Size(322, 22)
        Me.cmbShipper.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(64, 159)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 14)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "SHIPPER:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbIssuedAt
        '
        Me.cmbIssuedAt.BackColor = System.Drawing.SystemColors.Info
        Me.cmbIssuedAt.FormattingEnabled = True
        Me.cmbIssuedAt.Location = New System.Drawing.Point(129, 128)
        Me.cmbIssuedAt.Name = "cmbIssuedAt"
        Me.cmbIssuedAt.Size = New System.Drawing.Size(322, 22)
        Me.cmbIssuedAt.TabIndex = 11
        Me.cmbIssuedAt.Text = "PHMNL"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(23, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 14)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "ISSUED AT:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbBlNo
        '
        Me.cmbBlNo.BackColor = System.Drawing.SystemColors.Info
        Me.cmbBlNo.Enabled = False
        Me.cmbBlNo.FormattingEnabled = True
        Me.cmbBlNo.Location = New System.Drawing.Point(129, 107)
        Me.cmbBlNo.Name = "cmbBlNo"
        Me.cmbBlNo.Size = New System.Drawing.Size(322, 22)
        Me.cmbBlNo.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(64, 110)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 14)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "B/L NO:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbVia
        '
        Me.cmbVia.BackColor = System.Drawing.SystemColors.Info
        Me.cmbVia.FormattingEnabled = True
        Me.cmbVia.Location = New System.Drawing.Point(129, 86)
        Me.cmbVia.Name = "cmbVia"
        Me.cmbVia.Size = New System.Drawing.Size(322, 22)
        Me.cmbVia.TabIndex = 7
        Me.cmbVia.Text = "BUSAN, KOREA"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(64, 89)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "VIA:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTo
        '
        Me.cmbTo.BackColor = System.Drawing.SystemColors.Info
        Me.cmbTo.FormattingEnabled = True
        Me.cmbTo.Location = New System.Drawing.Point(129, 65)
        Me.cmbTo.Name = "cmbTo"
        Me.cmbTo.Size = New System.Drawing.Size(322, 22)
        Me.cmbTo.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(64, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "TO:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbFrom
        '
        Me.cmbFrom.BackColor = System.Drawing.SystemColors.Info
        Me.cmbFrom.FormattingEnabled = True
        Me.cmbFrom.Location = New System.Drawing.Point(129, 44)
        Me.cmbFrom.Name = "cmbFrom"
        Me.cmbFrom.Size = New System.Drawing.Size(322, 22)
        Me.cmbFrom.TabIndex = 3
        Me.cmbFrom.Text = "MANILA, PHILIPPINES"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(64, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "FROM:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(87, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Date:"
        '
        'dtDate
        '
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(129, 12)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(134, 22)
        Me.dtDate.TabIndex = 0
        '
        'cmbCurrrency
        '
        Me.cmbCurrrency.BackColor = System.Drawing.SystemColors.Info
        Me.cmbCurrrency.FormattingEnabled = True
        Me.cmbCurrrency.Location = New System.Drawing.Point(129, 219)
        Me.cmbCurrrency.Name = "cmbCurrrency"
        Me.cmbCurrrency.Size = New System.Drawing.Size(322, 22)
        Me.cmbCurrrency.TabIndex = 30
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(26, 222)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 14)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "CURRENCY:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmCorrectionAdvice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 491)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmCorrectionAdvice"
        Me.Text = "FrmCorrectionAdvice"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents cmbNotifyParty As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbConsignee As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbShipper As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbIssuedAt As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbBlNo As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbVia As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbTo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbFrom As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dtDate As DateTimePicker
    Friend WithEvents dtList As DataGridView
    Friend WithEvents cmbCollect As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbPrepaid As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents btnSaveCs As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Button1 As Button
    Friend WithEvents txtRefno As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents cmbCurrrency As ComboBox
    Friend WithEvents Label13 As Label
End Class
