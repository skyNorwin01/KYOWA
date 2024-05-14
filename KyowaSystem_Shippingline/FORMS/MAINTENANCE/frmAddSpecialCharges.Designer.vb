<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddSpecialCharges
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dtChargesValues = New System.Windows.Forms.DataGridView()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbSequence = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbCurrency = New System.Windows.Forms.ComboBox()
        Me.cmbSize2 = New System.Windows.Forms.ComboBox()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbParameter2 = New System.Windows.Forms.ComboBox()
        Me.txtQTY = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblSelectedCharges = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbParameter = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFreetime = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cmbCharges = New System.Windows.Forms.ComboBox()
        Me.txtCodeIs = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtCharges = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dtChargesValues, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dtCharges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(971, 540)
        Me.Panel1.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.dtChargesValues)
        Me.Panel3.Controls.Add(Me.cmbCategory)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.cmbSequence)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.cmbCurrency)
        Me.Panel3.Controls.Add(Me.cmbSize2)
        Me.Panel3.Controls.Add(Me.txtAmount)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.cmbParameter2)
        Me.Panel3.Controls.Add(Me.txtQTY)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.LblSelectedCharges)
        Me.Panel3.Location = New System.Drawing.Point(12, 213)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(947, 315)
        Me.Panel3.TabIndex = 3
        '
        'dtChargesValues
        '
        Me.dtChargesValues.AllowUserToAddRows = False
        Me.dtChargesValues.AllowUserToDeleteRows = False
        Me.dtChargesValues.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtChargesValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtChargesValues.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column11, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column10})
        Me.dtChargesValues.Location = New System.Drawing.Point(4, 149)
        Me.dtChargesValues.Name = "dtChargesValues"
        Me.dtChargesValues.ReadOnly = True
        Me.dtChargesValues.Size = New System.Drawing.Size(938, 161)
        Me.dtChargesValues.TabIndex = 2
        '
        'cmbCategory
        '
        Me.cmbCategory.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCategory.BackColor = System.Drawing.SystemColors.HotTrack
        Me.cmbCategory.Font = New System.Drawing.Font("Calibri", 13.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
        Me.cmbCategory.ForeColor = System.Drawing.Color.White
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(782, 121)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(160, 29)
        Me.cmbCategory.TabIndex = 36
        '
        'Label5
        '
        Me.Label5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(938, 33)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "S I Z E :                                                      "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSequence
        '
        Me.cmbSequence.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbSequence.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSequence.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbSequence.ForeColor = System.Drawing.Color.Black
        Me.cmbSequence.FormattingEnabled = True
        Me.cmbSequence.Location = New System.Drawing.Point(4, 85)
        Me.cmbSequence.Name = "cmbSequence"
        Me.cmbSequence.Size = New System.Drawing.Size(162, 22)
        Me.cmbSequence.TabIndex = 32
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(1, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 14)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Sequence"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(58, 71)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 14)
        Me.Label13.TabIndex = 34
        Me.Label13.Text = "(1st, 2nd, 3rd, etc..)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(-1, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(285, 29)
        Me.Label11.TabIndex = 31
        Me.Label11.Text = "*OVER FREETIME CHARGES"
        '
        'cmbCurrency
        '
        Me.cmbCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCurrency.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbCurrency.ForeColor = System.Drawing.Color.Black
        Me.cmbCurrency.FormattingEnabled = True
        Me.cmbCurrency.Location = New System.Drawing.Point(386, 85)
        Me.cmbCurrency.Name = "cmbCurrency"
        Me.cmbCurrency.Size = New System.Drawing.Size(115, 22)
        Me.cmbCurrency.TabIndex = 25
        '
        'cmbSize2
        '
        Me.cmbSize2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbSize2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSize2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbSize2.ForeColor = System.Drawing.Color.Black
        Me.cmbSize2.FormattingEnabled = True
        Me.cmbSize2.Location = New System.Drawing.Point(500, 85)
        Me.cmbSize2.Name = "cmbSize2"
        Me.cmbSize2.Size = New System.Drawing.Size(115, 22)
        Me.cmbSize2.TabIndex = 27
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtAmount.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmount.ForeColor = System.Drawing.Color.Black
        Me.txtAmount.Location = New System.Drawing.Point(616, 85)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(207, 22)
        Me.txtAmount.TabIndex = 30
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(613, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 14)
        Me.Label10.TabIndex = 29
        Me.Label10.Text = "Amount"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(497, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 14)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "SIZE"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(282, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 14)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Parameter"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(383, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 14)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "Currency"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(829, 84)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 23)
        Me.Button1.TabIndex = 22
        Me.Button1.Text = "SAVE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbParameter2
        '
        Me.cmbParameter2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbParameter2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbParameter2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbParameter2.ForeColor = System.Drawing.Color.Black
        Me.cmbParameter2.FormattingEnabled = True
        Me.cmbParameter2.Location = New System.Drawing.Point(285, 85)
        Me.cmbParameter2.Name = "cmbParameter2"
        Me.cmbParameter2.Size = New System.Drawing.Size(102, 22)
        Me.cmbParameter2.TabIndex = 21
        '
        'txtQTY
        '
        Me.txtQTY.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtQTY.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQTY.ForeColor = System.Drawing.Color.Black
        Me.txtQTY.Location = New System.Drawing.Point(172, 85)
        Me.txtQTY.Name = "txtQTY"
        Me.txtQTY.Size = New System.Drawing.Size(111, 22)
        Me.txtQTY.TabIndex = 20
        Me.txtQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(238, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 14)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Nos. of "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(-1, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 29)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "SELECTED CHARGES:"
        '
        'LblSelectedCharges
        '
        Me.LblSelectedCharges.AutoSize = True
        Me.LblSelectedCharges.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LblSelectedCharges.Font = New System.Drawing.Font("Calibri", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelectedCharges.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LblSelectedCharges.Location = New System.Drawing.Point(210, 35)
        Me.LblSelectedCharges.Name = "LblSelectedCharges"
        Me.LblSelectedCharges.Size = New System.Drawing.Size(0, 29)
        Me.LblSelectedCharges.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmbParameter)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txtFreetime)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.cmbCharges)
        Me.Panel2.Controls.Add(Me.txtCodeIs)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.dtCharges)
        Me.Panel2.Location = New System.Drawing.Point(13, 13)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(946, 194)
        Me.Panel2.TabIndex = 0
        '
        'cmbParameter
        '
        Me.cmbParameter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbParameter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbParameter.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbParameter.FormattingEnabled = True
        Me.cmbParameter.Location = New System.Drawing.Point(589, 22)
        Me.cmbParameter.Name = "cmbParameter"
        Me.cmbParameter.Size = New System.Drawing.Size(115, 22)
        Me.cmbParameter.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(589, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 14)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Parameter"
        '
        'txtFreetime
        '
        Me.txtFreetime.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFreetime.Location = New System.Drawing.Point(444, 22)
        Me.txtFreetime.Name = "txtFreetime"
        Me.txtFreetime.Size = New System.Drawing.Size(139, 22)
        Me.txtFreetime.TabIndex = 13
        Me.txtFreetime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(441, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 14)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Freetime"
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(710, 21)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(113, 23)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cmbCharges
        '
        Me.cmbCharges.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCharges.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCharges.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbCharges.FormattingEnabled = True
        Me.cmbCharges.Location = New System.Drawing.Point(126, 22)
        Me.cmbCharges.Name = "cmbCharges"
        Me.cmbCharges.Size = New System.Drawing.Size(312, 22)
        Me.cmbCharges.TabIndex = 10
        '
        'txtCodeIs
        '
        Me.txtCodeIs.BackColor = System.Drawing.SystemColors.HotTrack
        Me.txtCodeIs.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodeIs.ForeColor = System.Drawing.Color.White
        Me.txtCodeIs.Location = New System.Drawing.Point(13, 22)
        Me.txtCodeIs.Name = "txtCodeIs"
        Me.txtCodeIs.Size = New System.Drawing.Size(111, 22)
        Me.txtCodeIs.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Name:"
        '
        'dtCharges
        '
        Me.dtCharges.AllowUserToAddRows = False
        Me.dtCharges.AllowUserToDeleteRows = False
        Me.dtCharges.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtCharges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtCharges.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column8})
        Me.dtCharges.Location = New System.Drawing.Point(3, 54)
        Me.dtCharges.Name = "dtCharges"
        Me.dtCharges.ReadOnly = True
        Me.dtCharges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtCharges.Size = New System.Drawing.Size(938, 135)
        Me.dtCharges.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = "CODE"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "CHARGES NAME"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 300
        '
        'Column3
        '
        Me.Column3.HeaderText = "FREETIME"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "PARAMETER"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column11
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Column11.DefaultCellStyle = DataGridViewCellStyle5
        Me.Column11.HeaderText = "Sequence"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle6
        Me.Column4.HeaderText = "Nos. of"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 80
        '
        'Column5
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle7
        Me.Column5.HeaderText = "Parameter"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "Currency"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "Size"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column10
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column10.DefaultCellStyle = DataGridViewCellStyle8
        Me.Column10.HeaderText = "Amount"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 120
        '
        'frmAddSpecialCharges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 540)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmAddSpecialCharges"
        Me.Text = "frmAddSpecialCharges"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dtChargesValues, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dtCharges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtChargesValues As DataGridView
    Friend WithEvents dtCharges As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LblSelectedCharges As Label
    Friend WithEvents cmbCharges As ComboBox
    Friend WithEvents txtCodeIs As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents cmbParameter As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFreetime As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbCurrency As ComboBox
    Friend WithEvents cmbSize2 As ComboBox
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents cmbParameter2 As ComboBox
    Friend WithEvents txtQTY As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbSequence As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
End Class
