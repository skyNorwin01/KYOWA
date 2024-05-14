<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSpecialChargesMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtGTotalDiscount = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtGrandTotal = New System.Windows.Forms.TextBox()
        Me.cmbDiscount = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.dtRates = New System.Windows.Forms.DataGridView()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmbContainers = New System.Windows.Forms.ComboBox()
        Me.dtList = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column20 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column21 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtStart = New System.Windows.Forms.DateTimePicker()
        Me.dtContainer = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBLNO = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmberate = New System.Windows.Forms.ComboBox()
        Me.cmbMVVoyage = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbMV = New System.Windows.Forms.ComboBox()
        Me.cmbFVoyage = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFeederVessel = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbConsignee = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dtRates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dtContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.dtRates)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.cmbContainers)
        Me.Panel1.Controls.Add(Me.dtList)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.cmbCategory)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1195, 567)
        Me.Panel1.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Button5)
        Me.Panel3.Controls.Add(Me.txtGTotalDiscount)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.txtGrandTotal)
        Me.Panel3.Controls.Add(Me.cmbDiscount)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Location = New System.Drawing.Point(12, 512)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(957, 44)
        Me.Panel3.TabIndex = 19
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(827, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(125, 32)
        Me.Button5.TabIndex = 15
        Me.Button5.Text = "MARK AS PAID"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = False
        '
        'txtGTotalDiscount
        '
        Me.txtGTotalDiscount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtGTotalDiscount.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGTotalDiscount.Location = New System.Drawing.Point(534, 6)
        Me.txtGTotalDiscount.Name = "txtGTotalDiscount"
        Me.txtGTotalDiscount.ReadOnly = True
        Me.txtGTotalDiscount.Size = New System.Drawing.Size(180, 31)
        Me.txtGTotalDiscount.TabIndex = 14
        Me.txtGTotalDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 14)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "GRAND TOTAL:"
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtGrandTotal.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotal.Location = New System.Drawing.Point(102, 4)
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(180, 31)
        Me.txtGrandTotal.TabIndex = 12
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbDiscount
        '
        Me.cmbDiscount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbDiscount.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDiscount.FormattingEnabled = True
        Me.cmbDiscount.Location = New System.Drawing.Point(454, 12)
        Me.cmbDiscount.Name = "cmbDiscount"
        Me.cmbDiscount.Size = New System.Drawing.Size(54, 23)
        Me.cmbDiscount.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(393, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 14)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "DISCOUNT:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(506, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(21, 19)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "%"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Gold
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(731, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 32)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "GENERATE"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'dtRates
        '
        Me.dtRates.AllowUserToAddRows = False
        Me.dtRates.AllowUserToDeleteRows = False
        Me.dtRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtRates.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column16, Me.Column17, Me.Column18})
        Me.dtRates.Location = New System.Drawing.Point(975, 269)
        Me.dtRates.Name = "dtRates"
        Me.dtRates.ReadOnly = True
        Me.dtRates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtRates.Size = New System.Drawing.Size(208, 241)
        Me.dtRates.TabIndex = 17
        '
        'Column16
        '
        Me.Column16.HeaderText = "Seq"
        Me.Column16.Name = "Column16"
        Me.Column16.ReadOnly = True
        Me.Column16.Width = 30
        '
        'Column17
        '
        Me.Column17.HeaderText = "RATE"
        Me.Column17.Name = "Column17"
        Me.Column17.ReadOnly = True
        Me.Column17.Width = 60
        '
        'Column18
        '
        Me.Column18.HeaderText = "CUR"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Width = 50
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Gold
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(510, 236)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(58, 34)
        Me.Button4.TabIndex = 16
        Me.Button4.Text = "ADD"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = False
        '
        'cmbContainers
        '
        Me.cmbContainers.Font = New System.Drawing.Font("Calibri", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbContainers.FormattingEnabled = True
        Me.cmbContainers.Location = New System.Drawing.Point(12, 236)
        Me.cmbContainers.Name = "cmbContainers"
        Me.cmbContainers.Size = New System.Drawing.Size(492, 34)
        Me.cmbContainers.TabIndex = 15
        '
        'dtList
        '
        Me.dtList.AllowUserToAddRows = False
        Me.dtList.AllowUserToDeleteRows = False
        Me.dtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.Column4, Me.Column5, Me.Column14, Me.Column6, Me.Column15, Me.Column7, Me.Column8, Me.Column9, Me.Column10, Me.Column11, Me.Column12, Me.Column20, Me.Column21, Me.Column22})
        Me.dtList.Location = New System.Drawing.Point(12, 269)
        Me.dtList.Name = "dtList"
        Me.dtList.Size = New System.Drawing.Size(957, 241)
        Me.dtList.TabIndex = 13
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "CONTAINER NO."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "SIZE"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 60
        '
        'Column4
        '
        Me.Column4.HeaderText = "FREETIME"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 70
        '
        'Column5
        '
        Me.Column5.HeaderText = "DEMURRAGE START DATE"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 80
        '
        'Column14
        '
        Me.Column14.HeaderText = "DEMURRAGE END DATE"
        Me.Column14.Name = "Column14"
        Me.Column14.Width = 80
        '
        'Column6
        '
        Me.Column6.HeaderText = "RATES OF DEMURRAGE"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 80
        '
        'Column15
        '
        Me.Column15.HeaderText = "ERATE"
        Me.Column15.Name = "Column15"
        Me.Column15.Width = 60
        '
        'Column7
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column7.HeaderText = "TOTAL PER DAY"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 80
        '
        'Column8
        '
        Me.Column8.HeaderText = "NOS. OF DAY"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 80
        '
        'Column9
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column9.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column9.HeaderText = "TOTAL PER 7 DAYS"
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        Me.Column10.HeaderText = "NOS. OF CONTAINER"
        Me.Column10.Name = "Column10"
        Me.Column10.Width = 80
        '
        'Column11
        '
        Me.Column11.HeaderText = ""
        Me.Column11.Name = "Column11"
        Me.Column11.Width = 50
        '
        'Column12
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column12.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column12.HeaderText = "TOTAL"
        Me.Column12.Name = "Column12"
        '
        'Column20
        '
        Me.Column20.HeaderText = ""
        Me.Column20.Name = "Column20"
        Me.Column20.Width = 50
        '
        'Column21
        '
        Me.Column21.HeaderText = ""
        Me.Column21.Name = "Column21"
        Me.Column21.Width = 40
        '
        'Column22
        '
        Me.Column22.HeaderText = "Series"
        Me.Column22.Name = "Column22"
        Me.Column22.ReadOnly = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 18)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "CATEGORY:"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(1099, 518)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(84, 32)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "CANCEL"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cmbCategory
        '
        Me.cmbCategory.BackColor = System.Drawing.SystemColors.HotTrack
        Me.cmbCategory.Font = New System.Drawing.Font("Calibri", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCategory.ForeColor = System.Drawing.Color.White
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(102, 3)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(383, 41)
        Me.cmbCategory.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.dtTo)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.dtStart)
        Me.Panel2.Controls.Add(Me.dtContainer)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtBLNO)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.cmberate)
        Me.Panel2.Controls.Add(Me.cmbMVVoyage)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cmbMV)
        Me.Panel2.Controls.Add(Me.cmbFVoyage)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cmbFeederVessel)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.cmbConsignee)
        Me.Panel2.Location = New System.Drawing.Point(12, 47)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(957, 183)
        Me.Panel2.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gold
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(845, 178)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 32)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "CALCULATE"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(89, 126)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(116, 22)
        Me.dtTo.TabIndex = 17
        Me.dtTo.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(58, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 14)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "To:"
        Me.Label10.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(45, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 14)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "From:"
        Me.Label9.Visible = False
        '
        'dtStart
        '
        Me.dtStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtStart.Location = New System.Drawing.Point(89, 105)
        Me.dtStart.Name = "dtStart"
        Me.dtStart.Size = New System.Drawing.Size(116, 22)
        Me.dtStart.TabIndex = 15
        Me.dtStart.Visible = False
        '
        'dtContainer
        '
        Me.dtContainer.AllowUserToAddRows = False
        Me.dtContainer.AllowUserToDeleteRows = False
        Me.dtContainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtContainer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column13})
        Me.dtContainer.Location = New System.Drawing.Point(478, 3)
        Me.dtContainer.Name = "dtContainer"
        Me.dtContainer.Size = New System.Drawing.Size(467, 169)
        Me.dtContainer.TabIndex = 1
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 30
        '
        'Column2
        '
        Me.Column2.HeaderText = "CONTAINER NO."
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column3
        '
        Me.Column3.HeaderText = "SIZE"
        Me.Column3.Name = "Column3"
        '
        'Column13
        '
        Me.Column13.HeaderText = "DateDischarged"
        Me.Column13.Name = "Column13"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(42, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 14)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "BLNO:"
        '
        'txtBLNO
        '
        Me.txtBLNO.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBLNO.Location = New System.Drawing.Point(89, 77)
        Me.txtBLNO.Name = "txtBLNO"
        Me.txtBLNO.Size = New System.Drawing.Size(261, 22)
        Me.txtBLNO.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(309, 153)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 14)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "ERATE:"
        Me.Label4.Visible = False
        '
        'cmberate
        '
        Me.cmberate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmberate.FormattingEnabled = True
        Me.cmberate.Location = New System.Drawing.Point(356, 150)
        Me.cmberate.Name = "cmberate"
        Me.cmberate.Size = New System.Drawing.Size(116, 22)
        Me.cmberate.TabIndex = 8
        Me.cmberate.Visible = False
        '
        'cmbMVVoyage
        '
        Me.cmbMVVoyage.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbMVVoyage.FormattingEnabled = True
        Me.cmbMVVoyage.Location = New System.Drawing.Point(356, 56)
        Me.cmbMVVoyage.Name = "cmbMVVoyage"
        Me.cmbMVVoyage.Size = New System.Drawing.Size(116, 22)
        Me.cmbMVVoyage.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 14)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "MOTHER VSL:"
        '
        'cmbMV
        '
        Me.cmbMV.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbMV.FormattingEnabled = True
        Me.cmbMV.Location = New System.Drawing.Point(89, 56)
        Me.cmbMV.Name = "cmbMV"
        Me.cmbMV.Size = New System.Drawing.Size(261, 22)
        Me.cmbMV.TabIndex = 5
        '
        'cmbFVoyage
        '
        Me.cmbFVoyage.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbFVoyage.FormattingEnabled = True
        Me.cmbFVoyage.Location = New System.Drawing.Point(356, 35)
        Me.cmbFVoyage.Name = "cmbFVoyage"
        Me.cmbFVoyage.Size = New System.Drawing.Size(116, 22)
        Me.cmbFVoyage.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "FEEDER VSL:"
        '
        'cmbFeederVessel
        '
        Me.cmbFeederVessel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbFeederVessel.FormattingEnabled = True
        Me.cmbFeederVessel.Location = New System.Drawing.Point(89, 35)
        Me.cmbFeederVessel.Name = "cmbFeederVessel"
        Me.cmbFeederVessel.Size = New System.Drawing.Size(261, 22)
        Me.cmbFeederVessel.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CONSIGNEE:"
        '
        'cmbConsignee
        '
        Me.cmbConsignee.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbConsignee.FormattingEnabled = True
        Me.cmbConsignee.Location = New System.Drawing.Point(89, 14)
        Me.cmbConsignee.Name = "cmbConsignee"
        Me.cmbConsignee.Size = New System.Drawing.Size(383, 22)
        Me.cmbConsignee.TabIndex = 0
        '
        'FrmSpecialChargesMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1195, 567)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmSpecialChargesMenu"
        Me.Text = "FrmSpecialChargesMenu"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dtRates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dtContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtContainer As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents cmberate As ComboBox
    Friend WithEvents cmbMVVoyage As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbMV As ComboBox
    Friend WithEvents cmbFVoyage As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbFeederVessel As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbConsignee As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtBLNO As TextBox
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbDiscount As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents dtStart As DateTimePicker
    Friend WithEvents dtList As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents Column1 As DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewTextBoxColumn
    Friend WithEvents cmbContainers As ComboBox
    Friend WithEvents Button4 As Button
    Friend WithEvents dtRates As DataGridView
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents txtGrandTotal As TextBox
    Friend WithEvents txtGTotalDiscount As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Column20 As DataGridViewButtonColumn
    Friend WithEvents Column21 As DataGridViewButtonColumn
    Friend WithEvents Column22 As DataGridViewTextBoxColumn
End Class
