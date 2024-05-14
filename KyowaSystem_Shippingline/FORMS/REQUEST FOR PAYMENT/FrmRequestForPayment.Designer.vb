<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRequestForPayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRequestForPayment))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbRFPSubType = New System.Windows.Forms.ComboBox()
        Me.cmbRFPType = New System.Windows.Forms.ComboBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.rdManagersCheck = New System.Windows.Forms.RadioButton()
        Me.rdCheck = New System.Windows.Forms.RadioButton()
        Me.txtSysref = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmbVoyage = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
        Me.cmbPOL = New System.Windows.Forms.ComboBox()
        Me.txtErate = New System.Windows.Forms.TextBox()
        Me.cmbPOD = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtDueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbInFavor = New System.Windows.Forms.ComboBox()
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
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.btnSaveCs = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalRate = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCurrency = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbUnit = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNosUnit = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmbSize = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCharges = New System.Windows.Forms.ComboBox()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblInfavorID = New System.Windows.Forms.Label()
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
        Me.Panel1.TabIndex = 2
        '
        'cmbRFPSubType
        '
        Me.cmbRFPSubType.BackColor = System.Drawing.Color.White
        Me.cmbRFPSubType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbRFPSubType.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRFPSubType.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cmbRFPSubType.FormattingEnabled = True
        Me.cmbRFPSubType.Location = New System.Drawing.Point(377, 1)
        Me.cmbRFPSubType.Name = "cmbRFPSubType"
        Me.cmbRFPSubType.Size = New System.Drawing.Size(121, 26)
        Me.cmbRFPSubType.TabIndex = 78
        '
        'cmbRFPType
        '
        Me.cmbRFPType.BackColor = System.Drawing.Color.White
        Me.cmbRFPType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbRFPType.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRFPType.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cmbRFPType.FormattingEnabled = True
        Me.cmbRFPType.Location = New System.Drawing.Point(235, 1)
        Me.cmbRFPType.Name = "cmbRFPType"
        Me.cmbRFPType.Size = New System.Drawing.Size(121, 26)
        Me.cmbRFPType.TabIndex = 77
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
        Me.txtSysref.Location = New System.Drawing.Point(68, 3)
        Me.txtSysref.Name = "txtSysref"
        Me.txtSysref.ReadOnly = True
        Me.txtSysref.Size = New System.Drawing.Size(161, 20)
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
        Me.Panel4.Controls.Add(Me.lblInfavorID)
        Me.Panel4.Controls.Add(Me.cmbVoyage)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.txtInvoiceNo)
        Me.Panel4.Controls.Add(Me.cmbPOL)
        Me.Panel4.Controls.Add(Me.txtErate)
        Me.Panel4.Controls.Add(Me.cmbPOD)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.dtDueDate)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.cmbInFavor)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.cmbFeederVessel)
        Me.Panel4.Location = New System.Drawing.Point(12, 28)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(799, 109)
        Me.Panel4.TabIndex = 2
        '
        'cmbVoyage
        '
        Me.cmbVoyage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbVoyage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVoyage.BackColor = System.Drawing.SystemColors.Info
        Me.cmbVoyage.Font = New System.Drawing.Font("Calibri", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVoyage.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cmbVoyage.FormattingEnabled = True
        Me.cmbVoyage.Location = New System.Drawing.Point(643, 4)
        Me.cmbVoyage.Name = "cmbVoyage"
        Me.cmbVoyage.Size = New System.Drawing.Size(130, 34)
        Me.cmbVoyage.TabIndex = 9
        Me.cmbVoyage.Text = "202N"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(33, 85)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 14)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "INVOICE NO:"
        '
        'txtInvoiceNo
        '
        Me.txtInvoiceNo.BackColor = System.Drawing.SystemColors.Info
        Me.txtInvoiceNo.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceNo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.txtInvoiceNo.Location = New System.Drawing.Point(113, 79)
        Me.txtInvoiceNo.Name = "txtInvoiceNo"
        Me.txtInvoiceNo.Size = New System.Drawing.Size(660, 26)
        Me.txtInvoiceNo.TabIndex = 20
        '
        'cmbPOL
        '
        Me.cmbPOL.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbPOL.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPOL.BackColor = System.Drawing.SystemColors.Info
        Me.cmbPOL.FormattingEnabled = True
        Me.cmbPOL.Location = New System.Drawing.Point(113, 37)
        Me.cmbPOL.Name = "cmbPOL"
        Me.cmbPOL.Size = New System.Drawing.Size(217, 22)
        Me.cmbPOL.TabIndex = 14
        '
        'txtErate
        '
        Me.txtErate.BackColor = System.Drawing.SystemColors.Info
        Me.txtErate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtErate.Location = New System.Drawing.Point(643, 36)
        Me.txtErate.Name = "txtErate"
        Me.txtErate.Size = New System.Drawing.Size(130, 23)
        Me.txtErate.TabIndex = 18
        Me.txtErate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmbPOD
        '
        Me.cmbPOD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbPOD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPOD.BackColor = System.Drawing.SystemColors.Info
        Me.cmbPOD.FormattingEnabled = True
        Me.cmbPOD.Location = New System.Drawing.Point(380, 37)
        Me.cmbPOD.Name = "cmbPOD"
        Me.cmbPOD.Size = New System.Drawing.Size(225, 22)
        Me.cmbPOD.TabIndex = 16
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(618, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(26, 14)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "E.R:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(342, 41)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 14)
        Me.Label14.TabIndex = 17
        Me.Label14.Text = "POD:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(78, 41)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 14)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "POL:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(44, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 14)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Due Date:"
        '
        'dtDueDate
        '
        Me.dtDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDueDate.Location = New System.Drawing.Point(113, 58)
        Me.dtDueDate.Name = "dtDueDate"
        Me.dtDueDate.Size = New System.Drawing.Size(103, 22)
        Me.dtDueDate.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(242, 61)
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
        Me.cmbInFavor.Location = New System.Drawing.Point(380, 58)
        Me.cmbInFavor.Name = "cmbInFavor"
        Me.cmbInFavor.Size = New System.Drawing.Size(393, 22)
        Me.cmbInFavor.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(624, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 18)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "V-"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 12)
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
        Me.cmbFeederVessel.Location = New System.Drawing.Point(113, 4)
        Me.cmbFeederVessel.Name = "cmbFeederVessel"
        Me.cmbFeederVessel.Size = New System.Drawing.Size(492, 34)
        Me.cmbFeederVessel.TabIndex = 0
        Me.cmbFeederVessel.Text = "KYOWA FALCON"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.btnPrintRfp)
        Me.Panel3.Controls.Add(Me.dtList)
        Me.Panel3.Location = New System.Drawing.Point(12, 242)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(799, 382)
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
        Me.Button3.Location = New System.Drawing.Point(501, 336)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(136, 41)
        Me.Button3.TabIndex = 29
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
        Me.btnPrintRfp.BackColor = System.Drawing.Color.White
        Me.btnPrintRfp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintRfp.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintRfp.ForeColor = System.Drawing.Color.Black
        Me.btnPrintRfp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintRfp.ImageIndex = 4
        Me.btnPrintRfp.ImageList = Me.ImageList1
        Me.btnPrintRfp.Location = New System.Drawing.Point(643, 336)
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
        Me.dtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column9, Me.Column1, Me.Column2, Me.Column4, Me.Column5, Me.Column7, Me.Column6, Me.Column3, Me.Column10, Me.Column8, Me.Column11})
        Me.dtList.Location = New System.Drawing.Point(3, 10)
        Me.dtList.Name = "dtList"
        Me.dtList.ReadOnly = True
        Me.dtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtList.Size = New System.Drawing.Size(791, 322)
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
        Me.Column1.HeaderText = "Charges"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 250
        '
        'Column2
        '
        Me.Column2.Frozen = True
        Me.Column2.HeaderText = "Cont Size"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.HeaderText = "Nos. of Unit"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column5.HeaderText = "Rate"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column7.HeaderText = "Total Rate"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Currency"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Unit"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column10
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column10.HeaderText = "ER"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        '
        'Column8
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Red
        Me.Column8.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column8.HeaderText = "del"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 25
        '
        'Column11
        '
        Me.Column11.HeaderText = "e"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 25
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblCode)
        Me.Panel2.Controls.Add(Me.btnSaveCs)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtTotalRate)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.cmbCurrency)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtRate)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.cmbUnit)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtNosUnit)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.CmbSize)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cmbCharges)
        Me.Panel2.Location = New System.Drawing.Point(12, 136)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(799, 111)
        Me.Panel2.TabIndex = 0
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
        Me.lblCode.Text = "Charges"
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
        Me.btnSaveCs.TabIndex = 14
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
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "CLEAR"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(454, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 14)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Total Rate"
        '
        'txtTotalRate
        '
        Me.txtTotalRate.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalRate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRate.Location = New System.Drawing.Point(457, 73)
        Me.txtTotalRate.Name = "txtTotalRate"
        Me.txtTotalRate.Size = New System.Drawing.Size(186, 23)
        Me.txtTotalRate.TabIndex = 12
        Me.txtTotalRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(306, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 14)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Currency"
        '
        'cmbCurrency
        '
        Me.cmbCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCurrency.BackColor = System.Drawing.SystemColors.Info
        Me.cmbCurrency.FormattingEnabled = True
        Me.cmbCurrency.Location = New System.Drawing.Point(309, 73)
        Me.cmbCurrency.Name = "cmbCurrency"
        Me.cmbCurrency.Size = New System.Drawing.Size(142, 22)
        Me.cmbCurrency.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(119, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 14)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Rate"
        '
        'txtRate
        '
        Me.txtRate.BackColor = System.Drawing.SystemColors.Info
        Me.txtRate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRate.Location = New System.Drawing.Point(122, 73)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(181, 23)
        Me.txtRate.TabIndex = 8
        Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(539, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 14)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Unit"
        '
        'cmbUnit
        '
        Me.cmbUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbUnit.BackColor = System.Drawing.SystemColors.Info
        Me.cmbUnit.FormattingEnabled = True
        Me.cmbUnit.Location = New System.Drawing.Point(542, 25)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(101, 22)
        Me.cmbUnit.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Nos. of Unit"
        '
        'txtNosUnit
        '
        Me.txtNosUnit.BackColor = System.Drawing.SystemColors.Info
        Me.txtNosUnit.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNosUnit.Location = New System.Drawing.Point(16, 73)
        Me.txtNosUnit.Name = "txtNosUnit"
        Me.txtNosUnit.Size = New System.Drawing.Size(100, 23)
        Me.txtNosUnit.TabIndex = 4
        Me.txtNosUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(432, 8)
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
        Me.CmbSize.Location = New System.Drawing.Point(435, 25)
        Me.CmbSize.Name = "CmbSize"
        Me.CmbSize.Size = New System.Drawing.Size(101, 22)
        Me.CmbSize.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Charges"
        '
        'cmbCharges
        '
        Me.cmbCharges.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCharges.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCharges.BackColor = System.Drawing.SystemColors.Info
        Me.cmbCharges.FormattingEnabled = True
        Me.cmbCharges.Location = New System.Drawing.Point(16, 25)
        Me.cmbCharges.Name = "cmbCharges"
        Me.cmbCharges.Size = New System.Drawing.Size(413, 22)
        Me.cmbCharges.TabIndex = 0
        '
        'ImageList2
        '
        Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageList2.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblInfavorID
        '
        Me.lblInfavorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInfavorID.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfavorID.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblInfavorID.Location = New System.Drawing.Point(306, 60)
        Me.lblInfavorID.Name = "lblInfavorID"
        Me.lblInfavorID.Size = New System.Drawing.Size(75, 18)
        Me.lblInfavorID.TabIndex = 22
        '
        'FrmRequestForPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(823, 627)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmRequestForPayment"
        Me.Text = "FrmRequestForPayment"
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
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTotalRate As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbCurrency As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtRate As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbUnit As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNosUnit As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents CmbSize As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbCharges As ComboBox
    Friend WithEvents btnPrintRfp As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents dtList As DataGridView
    Friend WithEvents btnSaveCs As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents cmbVoyage As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbFeederVessel As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtSysref As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbInFavor As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents dtDueDate As DateTimePicker
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbPOD As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents cmbPOL As ComboBox
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents lblCode As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtErate As TextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents rdManagersCheck As RadioButton
    Friend WithEvents rdCheck As RadioButton
    Friend WithEvents Button3 As Button
    Friend WithEvents ImageList3 As ImageList
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents cmbRFPSubType As ComboBox
    Friend WithEvents cmbRFPType As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtInvoiceNo As TextBox
    Friend WithEvents lblInfavorID As Label
End Class
