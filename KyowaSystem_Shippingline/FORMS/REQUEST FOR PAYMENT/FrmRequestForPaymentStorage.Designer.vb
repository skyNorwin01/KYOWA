<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRequestForPaymentStorage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRequestForPaymentStorage))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbRFPSubType = New System.Windows.Forms.ComboBox()
        Me.cmbRFPType = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.rdManagersCheck = New System.Windows.Forms.RadioButton()
        Me.rdCheck = New System.Windows.Forms.RadioButton()
        Me.txtSysref = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtErate = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtDueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbInFavor = New System.Windows.Forms.ComboBox()
        Me.cmbVoyage = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbFeederVessel = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnPrintRfp = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dtList = New System.Windows.Forms.DataGridView()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbUnit = New System.Windows.Forms.ComboBox()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.btnSaveCs = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbContainerNo = New System.Windows.Forms.ComboBox()
        Me.cmbCurrency = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.lblDays = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDays = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbSize = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbShipper = New System.Windows.Forms.ComboBox()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.cmbRFPSubType)
        Me.Panel1.Controls.Add(Me.cmbRFPType)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.txtSysref)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(823, 627)
        Me.Panel1.TabIndex = 3
        '
        'cmbRFPSubType
        '
        Me.cmbRFPSubType.BackColor = System.Drawing.Color.White
        Me.cmbRFPSubType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbRFPSubType.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRFPSubType.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cmbRFPSubType.FormattingEnabled = True
        Me.cmbRFPSubType.Location = New System.Drawing.Point(410, 1)
        Me.cmbRFPSubType.Name = "cmbRFPSubType"
        Me.cmbRFPSubType.Size = New System.Drawing.Size(121, 26)
        Me.cmbRFPSubType.TabIndex = 80
        '
        'cmbRFPType
        '
        Me.cmbRFPType.BackColor = System.Drawing.Color.White
        Me.cmbRFPType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbRFPType.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRFPType.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cmbRFPType.FormattingEnabled = True
        Me.cmbRFPType.Location = New System.Drawing.Point(268, 1)
        Me.cmbRFPType.Name = "cmbRFPType"
        Me.cmbRFPType.Size = New System.Drawing.Size(121, 26)
        Me.cmbRFPType.TabIndex = 79
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.rdManagersCheck)
        Me.Panel5.Controls.Add(Me.rdCheck)
        Me.Panel5.Location = New System.Drawing.Point(612, 1)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(199, 28)
        Me.Panel5.TabIndex = 16
        '
        'rdManagersCheck
        '
        Me.rdManagersCheck.AutoSize = True
        Me.rdManagersCheck.Checked = True
        Me.rdManagersCheck.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdManagersCheck.Location = New System.Drawing.Point(83, 5)
        Me.rdManagersCheck.Name = "rdManagersCheck"
        Me.rdManagersCheck.Size = New System.Drawing.Size(106, 18)
        Me.rdManagersCheck.TabIndex = 1
        Me.rdManagersCheck.TabStop = True
        Me.rdManagersCheck.Text = "Managers Check"
        Me.rdManagersCheck.UseVisualStyleBackColor = True
        '
        'rdCheck
        '
        Me.rdCheck.AutoSize = True
        Me.rdCheck.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdCheck.Location = New System.Drawing.Point(11, 5)
        Me.rdCheck.Name = "rdCheck"
        Me.rdCheck.Size = New System.Drawing.Size(54, 18)
        Me.rdCheck.TabIndex = 0
        Me.rdCheck.Text = "Check"
        Me.rdCheck.UseVisualStyleBackColor = True
        '
        'txtSysref
        '
        Me.txtSysref.BackColor = System.Drawing.Color.White
        Me.txtSysref.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSysref.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSysref.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtSysref.Location = New System.Drawing.Point(68, 5)
        Me.txtSysref.Name = "txtSysref"
        Me.txtSysref.ReadOnly = True
        Me.txtSysref.Size = New System.Drawing.Size(192, 20)
        Me.txtSysref.TabIndex = 76
        Me.txtSysref.Text = "N/A"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 14)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "SYSREF:"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.txtInvoiceNo)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.txtErate)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.dtDueDate)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.cmbInFavor)
        Me.Panel4.Controls.Add(Me.cmbVoyage)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.cmbFeederVessel)
        Me.Panel4.Location = New System.Drawing.Point(12, 28)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(799, 120)
        Me.Panel4.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(32, 80)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 14)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "INVOICE NO:"
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Info
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtInvoiceNo.Location = New System.Drawing.Point(112, 74)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(660, 26)
        Me.txtInvoiceNo.TabIndex = 22
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(640, 49)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(26, 14)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "E.R:"
        Me.Label15.Visible = False
        '
        'txtErate
        '
        Me.txtErate.BackColor = System.Drawing.SystemColors.Info
        Me.txtErate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtErate.Location = New System.Drawing.Point(672, 45)
        Me.txtErate.Name = "txtErate"
        Me.txtErate.Size = New System.Drawing.Size(100, 23)
        Me.txtErate.TabIndex = 18
        Me.txtErate.Text = "1"
        Me.txtErate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtErate.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(45, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 14)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Due Date:"
        '
        'dtDueDate
        '
        Me.dtDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDueDate.Location = New System.Drawing.Point(114, 46)
        Me.dtDueDate.Name = "dtDueDate"
        Me.dtDueDate.Size = New System.Drawing.Size(103, 22)
        Me.dtDueDate.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(238, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 14)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "In favor of:"
        '
        'cmbInFavor
        '
        Me.cmbInFavor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbInFavor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbInFavor.BackColor = System.Drawing.SystemColors.Info
        Me.cmbInFavor.FormattingEnabled = True
        Me.cmbInFavor.Location = New System.Drawing.Point(309, 46)
        Me.cmbInFavor.Name = "cmbInFavor"
        Me.cmbInFavor.Size = New System.Drawing.Size(465, 22)
        Me.cmbInFavor.TabIndex = 3
        '
        'cmbVoyage
        '
        Me.cmbVoyage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbVoyage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVoyage.BackColor = System.Drawing.SystemColors.Info
        Me.cmbVoyage.Font = New System.Drawing.Font("Calibri", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVoyage.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cmbVoyage.FormattingEnabled = True
        Me.cmbVoyage.Location = New System.Drawing.Point(611, 6)
        Me.cmbVoyage.Name = "cmbVoyage"
        Me.cmbVoyage.Size = New System.Drawing.Size(162, 34)
        Me.cmbVoyage.TabIndex = 1
        Me.cmbVoyage.Text = "202N"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(584, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 18)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "V-"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 18)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Feeder Vessel:"
        '
        'cmbFeederVessel
        '
        Me.cmbFeederVessel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbFeederVessel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFeederVessel.Font = New System.Drawing.Font("Calibri", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFeederVessel.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cmbFeederVessel.FormattingEnabled = True
        Me.cmbFeederVessel.Location = New System.Drawing.Point(113, 6)
        Me.cmbFeederVessel.Name = "cmbFeederVessel"
        Me.cmbFeederVessel.Size = New System.Drawing.Size(465, 34)
        Me.cmbFeederVessel.TabIndex = 0
        Me.cmbFeederVessel.Text = "KYOWA FALCON"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.btnPrintRfp)
        Me.Panel3.Controls.Add(Me.dtList)
        Me.Panel3.Location = New System.Drawing.Point(12, 259)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(799, 364)
        Me.Panel3.TabIndex = 1
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.ImageIndex = 9
        Me.Button3.ImageList = Me.ImageList3
        Me.Button3.Location = New System.Drawing.Point(496, 316)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(136, 41)
        Me.Button3.TabIndex = 30
        Me.Button3.Text = "MAINTENANCE"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "icons8-eye-100.png")
        Me.ImageList3.Images.SetKeyName(1, "icons8-upload-to-ftp-100.png")
        Me.ImageList3.Images.SetKeyName(2, "icons8-add-100.png")
        Me.ImageList3.Images.SetKeyName(3, "icons8-search-100.png")
        Me.ImageList3.Images.SetKeyName(4, "icons8-compose-100.png")
        Me.ImageList3.Images.SetKeyName(5, "icons8-delete-bin-100.png")
        Me.ImageList3.Images.SetKeyName(6, "icons8-information-96.png")
        Me.ImageList3.Images.SetKeyName(7, "icons8-print-100 (1).png")
        Me.ImageList3.Images.SetKeyName(8, "icons8-move-stock-100.png")
        Me.ImageList3.Images.SetKeyName(9, "icons8-maintenance-100.png")
        '
        'btnPrintRfp
        '
        Me.btnPrintRfp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintRfp.BackColor = System.Drawing.Color.White
        Me.btnPrintRfp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintRfp.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintRfp.ForeColor = System.Drawing.Color.Black
        Me.btnPrintRfp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintRfp.ImageIndex = 4
        Me.btnPrintRfp.ImageList = Me.ImageList1
        Me.btnPrintRfp.Location = New System.Drawing.Point(638, 316)
        Me.btnPrintRfp.Name = "btnPrintRfp"
        Me.btnPrintRfp.Size = New System.Drawing.Size(151, 41)
        Me.btnPrintRfp.TabIndex = 15
        Me.btnPrintRfp.Text = "GENERATE RFP"
        Me.btnPrintRfp.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrintRfp.UseVisualStyleBackColor = False
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
        'dtList
        '
        Me.dtList.AllowUserToAddRows = False
        Me.dtList.AllowUserToDeleteRows = False
        Me.dtList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column9, Me.Column1, Me.Column4, Me.Column2, Me.Column5, Me.Column7, Me.Column6, Me.Column10, Me.Column8, Me.Column3, Me.Column11, Me.Column12})
        Me.dtList.Location = New System.Drawing.Point(3, 8)
        Me.dtList.Name = "dtList"
        Me.dtList.ReadOnly = True
        Me.dtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtList.Size = New System.Drawing.Size(791, 303)
        Me.dtList.TabIndex = 0
        '
        'Column9
        '
        Me.Column9.Frozen = True
        Me.Column9.HeaderText = "CODE"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 60
        '
        'Column1
        '
        Me.Column1.Frozen = True
        Me.Column1.HeaderText = "Shipper"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 210
        '
        'Column4
        '
        Me.Column4.Frozen = True
        Me.Column4.HeaderText = "Container No."
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 110
        '
        'Column2
        '
        Me.Column2.HeaderText = "Cont Size"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column5.HeaderText = "Amount"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column7.HeaderText = "Total Amount"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 120
        '
        'Column6
        '
        Me.Column6.HeaderText = "Currency"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column10
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column10.HeaderText = "ER"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column8
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column8.HeaderText = "del"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 25
        '
        'Column3
        '
        Me.Column3.HeaderText = "e"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 25
        '
        'Column11
        '
        Me.Column11.HeaderText = "Days"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column12
        '
        Me.Column12.HeaderText = "Unit"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.cmbUnit)
        Me.Panel2.Controls.Add(Me.lblCode)
        Me.Panel2.Controls.Add(Me.btnSaveCs)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtTotalAmount)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.cmbContainerNo)
        Me.Panel2.Controls.Add(Me.cmbCurrency)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtAmount)
        Me.Panel2.Controls.Add(Me.lblDays)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtDays)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.CmbSize)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cmbShipper)
        Me.Panel2.Location = New System.Drawing.Point(12, 142)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(799, 111)
        Me.Panel2.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(578, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 14)
        Me.Label13.TabIndex = 18
        Me.Label13.Text = "UNIT"
        '
        'cmbUnit
        '
        Me.cmbUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUnit.BackColor = System.Drawing.SystemColors.Info
        Me.cmbUnit.FormattingEnabled = True
        Me.cmbUnit.Location = New System.Drawing.Point(581, 25)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(74, 22)
        Me.cmbUnit.TabIndex = 17
        '
        'lblCode
        '
        Me.lblCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCode.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblCode.Location = New System.Drawing.Point(66, 8)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(85, 18)
        Me.lblCode.TabIndex = 16
        Me.lblCode.Text = "CODE"
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
        Me.btnSaveCs.Location = New System.Drawing.Point(672, 11)
        Me.btnSaveCs.Name = "btnSaveCs"
        Me.btnSaveCs.Size = New System.Drawing.Size(101, 45)
        Me.btnSaveCs.TabIndex = 11
        Me.btnSaveCs.Text = "ADD"
        Me.btnSaveCs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveCs.UseVisualStyleBackColor = False
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
        Me.Button1.Location = New System.Drawing.Point(672, 55)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 45)
        Me.Button1.TabIndex = 12
        Me.Button1.TabStop = False
        Me.Button1.Text = "CLEAR"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(466, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 14)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Total Amount"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalAmount.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalAmount.Location = New System.Drawing.Point(469, 74)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.Size = New System.Drawing.Size(186, 23)
        Me.txtTotalAmount.TabIndex = 10
        Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(206, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 14)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Currency"
        '
        'cmbContainerNo
        '
        Me.cmbContainerNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbContainerNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbContainerNo.BackColor = System.Drawing.SystemColors.Info
        Me.cmbContainerNo.FormattingEnabled = True
        Me.cmbContainerNo.Location = New System.Drawing.Point(16, 74)
        Me.cmbContainerNo.Name = "cmbContainerNo"
        Me.cmbContainerNo.Size = New System.Drawing.Size(187, 22)
        Me.cmbContainerNo.TabIndex = 7
        '
        'cmbCurrency
        '
        Me.cmbCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCurrency.BackColor = System.Drawing.SystemColors.Info
        Me.cmbCurrency.FormattingEnabled = True
        Me.cmbCurrency.Location = New System.Drawing.Point(209, 75)
        Me.cmbCurrency.Name = "cmbCurrency"
        Me.cmbCurrency.Size = New System.Drawing.Size(86, 22)
        Me.cmbCurrency.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(300, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Amount"
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.SystemColors.Info
        Me.txtAmount.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.Location = New System.Drawing.Point(301, 74)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(162, 23)
        Me.txtAmount.TabIndex = 9
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDays
        '
        Me.lblDays.AutoSize = True
        Me.lblDays.Location = New System.Drawing.Point(472, 8)
        Me.lblDays.Name = "lblDays"
        Me.lblDays.Size = New System.Drawing.Size(33, 14)
        Me.lblDays.TabIndex = 7
        Me.lblDays.Text = "DAYS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Container No."
        '
        'txtDays
        '
        Me.txtDays.BackColor = System.Drawing.SystemColors.Info
        Me.txtDays.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDays.Location = New System.Drawing.Point(475, 25)
        Me.txtDays.Name = "txtDays"
        Me.txtDays.Size = New System.Drawing.Size(100, 23)
        Me.txtDays.TabIndex = 6
        Me.txtDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(365, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cont. Size"
        '
        'CmbSize
        '
        Me.CmbSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbSize.BackColor = System.Drawing.SystemColors.Info
        Me.CmbSize.FormattingEnabled = True
        Me.CmbSize.Location = New System.Drawing.Point(368, 25)
        Me.CmbSize.Name = "CmbSize"
        Me.CmbSize.Size = New System.Drawing.Size(101, 22)
        Me.CmbSize.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Shipper"
        '
        'cmbShipper
        '
        Me.cmbShipper.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbShipper.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbShipper.BackColor = System.Drawing.SystemColors.Info
        Me.cmbShipper.FormattingEnabled = True
        Me.cmbShipper.Location = New System.Drawing.Point(16, 25)
        Me.cmbShipper.Name = "cmbShipper"
        Me.cmbShipper.Size = New System.Drawing.Size(346, 22)
        Me.cmbShipper.TabIndex = 4
        '
        'ImageList2
        '
        Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList2.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'FrmRequestForPaymentStorage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 627)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmRequestForPaymentStorage"
        Me.Text = "FrmRequestForPaymentStorage"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents rdManagersCheck As RadioButton
    Friend WithEvents rdCheck As RadioButton
    Friend WithEvents txtSysref As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents dtDueDate As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbInFavor As ComboBox
    Friend WithEvents cmbVoyage As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbFeederVessel As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnPrintRfp As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents dtList As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblCode As Label
    Friend WithEvents btnSaveCs As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTotalAmount As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbCurrency As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents lblDays As Label
    Friend WithEvents cmbContainerNo As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDays As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CmbSize As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbShipper As ComboBox
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Label15 As Label
    Friend WithEvents txtErate As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cmbUnit As ComboBox
    Friend WithEvents cmbRFPSubType As ComboBox
    Friend WithEvents cmbRFPType As ComboBox
    Friend WithEvents Button3 As Button
    Friend WithEvents ImageList3 As ImageList
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Label16 As Label
    Friend WithEvents txtInvoiceNo As TextBox
End Class
