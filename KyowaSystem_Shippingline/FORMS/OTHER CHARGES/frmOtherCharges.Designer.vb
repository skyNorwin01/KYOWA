<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOtherCharges
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
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtER = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dtStorage = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dtTrucking = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtMotherVesselVoyage = New System.Windows.Forms.TextBox()
        Me.txtFeederVesselVoyage = New System.Windows.Forms.TextBox()
        Me.txtBKNo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRefno = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBLNo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtShipper = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbFeederVessel = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMotherVessel = New System.Windows.Forms.ComboBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DataGridViewButtonColumn2 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtStorage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dtTrucking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.txtER)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.cmbCategory)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(988, 554)
        Me.Panel1.TabIndex = 2
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button5.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(113, 507)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(125, 32)
        Me.Button5.TabIndex = 17
        Me.Button5.Text = "MARK AS PAID"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = False
        Me.Button5.Visible = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Gold
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(17, 507)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 32)
        Me.Button3.TabIndex = 16
        Me.Button3.Text = "GENERATE"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        Me.Button3.Visible = False
        '
        'txtER
        '
        Me.txtER.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtER.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtER.Location = New System.Drawing.Point(130, 249)
        Me.txtER.Name = "txtER"
        Me.txtER.Size = New System.Drawing.Size(587, 22)
        Me.txtER.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 252)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 14)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "EXCHANGE RATE:"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 277)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(964, 223)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dtStorage)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(956, 196)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "STORAGE"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dtStorage
        '
        Me.dtStorage.AllowUserToAddRows = False
        Me.dtStorage.AllowUserToDeleteRows = False
        Me.dtStorage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtStorage.ColumnHeadersHeight = 40
        Me.dtStorage.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column9, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column10, Me.Column11})
        Me.dtStorage.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtStorage.Location = New System.Drawing.Point(3, 3)
        Me.dtStorage.Name = "dtStorage"
        Me.dtStorage.Size = New System.Drawing.Size(947, 187)
        Me.dtStorage.TabIndex = 6
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 25
        '
        'Column2
        '
        Me.Column2.HeaderText = "Container NO"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Column3
        '
        Me.Column3.HeaderText = "Size"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.Width = 80
        '
        'Column4
        '
        Me.Column4.HeaderText = "Rate"
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Column9
        '
        Me.Column9.HeaderText = "Currency"
        Me.Column9.Name = "Column9"
        Me.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column9.Width = 60
        '
        'Column5
        '
        Me.Column5.HeaderText = "Gate-in      (YYYY-MM-DD)"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "Start Bill Date (YYYY-MM-DD)"
        Me.Column6.Name = "Column6"
        '
        'Column7
        '
        Me.Column7.HeaderText = "End Bill Date (YYYY-MM-DD)"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "No. of Days"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 80
        '
        'Column10
        '
        Me.Column10.HeaderText = ""
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 60
        '
        'Column11
        '
        Me.Column11.HeaderText = ""
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 60
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dtTrucking)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(956, 196)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TRUCKING"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dtTrucking
        '
        Me.dtTrucking.AllowUserToAddRows = False
        Me.dtTrucking.AllowUserToDeleteRows = False
        Me.dtTrucking.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtTrucking.ColumnHeadersHeight = 40
        Me.dtTrucking.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewComboBoxColumn1, Me.Column12, Me.Column13, Me.DataGridViewButtonColumn1, Me.DataGridViewButtonColumn2})
        Me.dtTrucking.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dtTrucking.Location = New System.Drawing.Point(3, 3)
        Me.dtTrucking.Name = "dtTrucking"
        Me.dtTrucking.Size = New System.Drawing.Size(947, 187)
        Me.dtTrucking.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Pre-Details"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtMotherVesselVoyage)
        Me.Panel2.Controls.Add(Me.txtFeederVesselVoyage)
        Me.Panel2.Controls.Add(Me.txtBKNo)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtRefno)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtBLNo)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtShipper)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.cmbFeederVessel)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cmbMotherVessel)
        Me.Panel2.Location = New System.Drawing.Point(12, 50)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(705, 193)
        Me.Panel2.TabIndex = 5
        '
        'txtMotherVesselVoyage
        '
        Me.txtMotherVesselVoyage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMotherVesselVoyage.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMotherVesselVoyage.Location = New System.Drawing.Point(597, 161)
        Me.txtMotherVesselVoyage.Name = "txtMotherVesselVoyage"
        Me.txtMotherVesselVoyage.ReadOnly = True
        Me.txtMotherVesselVoyage.Size = New System.Drawing.Size(97, 22)
        Me.txtMotherVesselVoyage.TabIndex = 12
        '
        'txtFeederVesselVoyage
        '
        Me.txtFeederVesselVoyage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFeederVesselVoyage.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFeederVesselVoyage.Location = New System.Drawing.Point(597, 140)
        Me.txtFeederVesselVoyage.Name = "txtFeederVesselVoyage"
        Me.txtFeederVesselVoyage.ReadOnly = True
        Me.txtFeederVesselVoyage.Size = New System.Drawing.Size(97, 22)
        Me.txtFeederVesselVoyage.TabIndex = 11
        '
        'txtBKNo
        '
        Me.txtBKNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBKNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBKNo.Location = New System.Drawing.Point(117, 24)
        Me.txtBKNo.Name = "txtBKNo"
        Me.txtBKNo.ReadOnly = True
        Me.txtBKNo.Size = New System.Drawing.Size(577, 22)
        Me.txtBKNo.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(65, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 14)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "BKNO:"
        '
        'txtRefno
        '
        Me.txtRefno.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtRefno.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRefno.Location = New System.Drawing.Point(117, 3)
        Me.txtRefno.Name = "txtRefno"
        Me.txtRefno.ReadOnly = True
        Me.txtRefno.Size = New System.Drawing.Size(577, 22)
        Me.txtRefno.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(65, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "REFNO:"
        '
        'txtBLNo
        '
        Me.txtBLNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBLNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBLNo.Location = New System.Drawing.Point(117, 119)
        Me.txtBLNo.Name = "txtBLNo"
        Me.txtBLNo.ReadOnly = True
        Me.txtBLNo.Size = New System.Drawing.Size(577, 22)
        Me.txtBLNo.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(65, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "B/L NO:"
        '
        'txtShipper
        '
        Me.txtShipper.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtShipper.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtShipper.Location = New System.Drawing.Point(117, 54)
        Me.txtShipper.Multiline = True
        Me.txtShipper.Name = "txtShipper"
        Me.txtShipper.ReadOnly = True
        Me.txtShipper.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtShipper.Size = New System.Drawing.Size(577, 66)
        Me.txtShipper.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(59, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 14)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Shipper:"
        '
        'cmbFeederVessel
        '
        Me.cmbFeederVessel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbFeederVessel.Enabled = False
        Me.cmbFeederVessel.FormattingEnabled = True
        Me.cmbFeederVessel.Location = New System.Drawing.Point(117, 140)
        Me.cmbFeederVessel.Name = "cmbFeederVessel"
        Me.cmbFeederVessel.Size = New System.Drawing.Size(481, 22)
        Me.cmbFeederVessel.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 14)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Mother Vessel:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 143)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 14)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Feeder Vessel:"
        '
        'cmbMotherVessel
        '
        Me.cmbMotherVessel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbMotherVessel.Enabled = False
        Me.cmbMotherVessel.FormattingEnabled = True
        Me.cmbMotherVessel.Location = New System.Drawing.Point(117, 161)
        Me.cmbMotherVessel.Name = "cmbMotherVessel"
        Me.cmbMotherVessel.Size = New System.Drawing.Size(481, 22)
        Me.cmbMotherVessel.TabIndex = 3
        '
        'cmbCategory
        '
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(12, 12)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(246, 22)
        Me.cmbCategory.TabIndex = 0
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.HeaderText = ""
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 25
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Container NO"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DividerWidth = 2
        Me.DataGridViewTextBoxColumn2.HeaderText = "Size"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.Width = 80
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Rate"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.DividerWidth = 2
        Me.DataGridViewComboBoxColumn1.HeaderText = "Currency"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewComboBoxColumn1.Width = 60
        '
        'Column12
        '
        Me.Column12.HeaderText = "Trucking Wait Fee"
        Me.Column12.Name = "Column12"
        '
        'Column13
        '
        Me.Column13.DividerWidth = 2
        Me.Column13.HeaderText = "Currency"
        Me.Column13.Name = "Column13"
        Me.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewButtonColumn1
        '
        Me.DataGridViewButtonColumn1.HeaderText = ""
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.Width = 60
        '
        'DataGridViewButtonColumn2
        '
        Me.DataGridViewButtonColumn2.HeaderText = ""
        Me.DataGridViewButtonColumn2.Name = "DataGridViewButtonColumn2"
        Me.DataGridViewButtonColumn2.Width = 60
        '
        'frmOtherCharges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(988, 554)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmOtherCharges"
        Me.Text = "frmOtherCharges"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dtStorage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dtTrucking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtStorage As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtShipper As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbMotherVessel As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbFeederVessel As ComboBox
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents txtER As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents txtBLNo As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button5 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents txtBKNo As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtRefno As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtMotherVesselVoyage As TextBox
    Friend WithEvents txtFeederVesselVoyage As TextBox
    Friend WithEvents Column1 As DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewComboBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewButtonColumn
    Friend WithEvents Column11 As DataGridViewButtonColumn
    Friend WithEvents dtTrucking As DataGridView
    Friend WithEvents DataGridViewCheckBoxColumn1 As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As DataGridViewComboBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewButtonColumn1 As DataGridViewButtonColumn
    Friend WithEvents DataGridViewButtonColumn2 As DataGridViewButtonColumn
End Class
