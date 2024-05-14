<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRequestForPaymentList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRequestForPaymentList))
        Me.dtList = New System.Windows.Forms.DataGridView()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlAdvanceSearch = New System.Windows.Forms.Panel()
        Me.cmbFVoyage = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbFVessel = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbValue = New System.Windows.Forms.ComboBox()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.btnView = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlAdvanceSearch.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtList
        '
        Me.dtList.AllowUserToAddRows = False
        Me.dtList.AllowUserToDeleteRows = False
        Me.dtList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column1, Me.Column2, Me.Column3, Me.Column6, Me.Column4, Me.Column7, Me.Column8, Me.Column9})
        Me.dtList.Location = New System.Drawing.Point(-3, 75)
        Me.dtList.Name = "dtList"
        Me.dtList.ReadOnly = True
        Me.dtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtList.Size = New System.Drawing.Size(1044, 318)
        Me.dtList.TabIndex = 0
        '
        'Column5
        '
        Me.Column5.HeaderText = "REFERENCE"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "SERIES"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "FEEDER VESSEL"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 320
        '
        'Column3
        '
        Me.Column3.HeaderText = "VOYAGE"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column6
        '
        Me.Column6.HeaderText = "In Favor of"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 250
        '
        'Column4
        '
        Me.Column4.HeaderText = "STATUS"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.HeaderText = "RFP TYPE"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column8
        '
        Me.Column8.HeaderText = "RFP SUB TYPE"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column9
        '
        Me.Column9.HeaderText = "Invoice No"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 120
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.pnlAdvanceSearch)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btnView)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.dtList)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1053, 441)
        Me.Panel1.TabIndex = 2
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.ImageIndex = 6
        Me.Button2.ImageList = Me.ImageList4
        Me.Button2.Location = New System.Drawing.Point(926, 395)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(115, 41)
        Me.Button2.TabIndex = 37
        Me.Button2.Text = "SUBMIT RFP"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ImageList4
        '
        Me.ImageList4.ImageStream = CType(resources.GetObject("ImageList4.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList4.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList4.Images.SetKeyName(0, "icons8-eye-100.png")
        Me.ImageList4.Images.SetKeyName(1, "icons8-upload-to-ftp-100.png")
        Me.ImageList4.Images.SetKeyName(2, "icons8-add-100.png")
        Me.ImageList4.Images.SetKeyName(3, "icons8-search-100.png")
        Me.ImageList4.Images.SetKeyName(4, "icons8-compose-100.png")
        Me.ImageList4.Images.SetKeyName(5, "icons8-delete-bin-100.png")
        Me.ImageList4.Images.SetKeyName(6, "icons8-information-96.png")
        Me.ImageList4.Images.SetKeyName(7, "icons8-print-100 (1).png")
        Me.ImageList4.Images.SetKeyName(8, "icons8-move-stock-100.png")
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImageIndex = 7
        Me.Button1.ImageList = Me.ImageList3
        Me.Button1.Location = New System.Drawing.Point(358, 395)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(255, 41)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "PRINT E-APPROVAL REQUEST"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
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
        '
        'pnlAdvanceSearch
        '
        Me.pnlAdvanceSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAdvanceSearch.Controls.Add(Me.cmbFVoyage)
        Me.pnlAdvanceSearch.Controls.Add(Me.Label16)
        Me.pnlAdvanceSearch.Controls.Add(Me.Label14)
        Me.pnlAdvanceSearch.Controls.Add(Me.cmbFVessel)
        Me.pnlAdvanceSearch.Location = New System.Drawing.Point(450, 12)
        Me.pnlAdvanceSearch.Name = "pnlAdvanceSearch"
        Me.pnlAdvanceSearch.Size = New System.Drawing.Size(489, 57)
        Me.pnlAdvanceSearch.TabIndex = 28
        Me.pnlAdvanceSearch.Visible = False
        '
        'cmbFVoyage
        '
        Me.cmbFVoyage.FormattingEnabled = True
        Me.cmbFVoyage.Location = New System.Drawing.Point(396, 18)
        Me.cmbFVoyage.Name = "cmbFVoyage"
        Me.cmbFVoyage.Size = New System.Drawing.Size(87, 22)
        Me.cmbFVoyage.TabIndex = 1
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(380, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(17, 14)
        Me.Label16.TabIndex = 27
        Me.Label16.Text = "V:"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 14)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "FeederVessel:"
        '
        'cmbFVessel
        '
        Me.cmbFVessel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbFVessel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbFVessel.FormattingEnabled = True
        Me.cmbFVessel.Location = New System.Drawing.Point(90, 18)
        Me.cmbFVessel.Name = "cmbFVessel"
        Me.cmbFVessel.Size = New System.Drawing.Size(286, 22)
        Me.cmbFVessel.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.dtTo)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cmbValue)
        Me.Panel2.Controls.Add(Me.cmbCategory)
        Me.Panel2.Controls.Add(Me.btnSearch)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.dtFrom)
        Me.Panel2.Location = New System.Drawing.Point(3, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1038, 57)
        Me.Panel2.TabIndex = 28
        '
        'dtTo
        '
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(158, 23)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(115, 22)
        Me.dtTo.TabIndex = 19
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(449, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 14)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Value"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(278, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 14)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Filter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 14)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Date"
        '
        'cmbValue
        '
        Me.cmbValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbValue.FormattingEnabled = True
        Me.cmbValue.Location = New System.Drawing.Point(449, 23)
        Me.cmbValue.Name = "cmbValue"
        Me.cmbValue.Size = New System.Drawing.Size(481, 22)
        Me.cmbValue.TabIndex = 23
        '
        'cmbCategory
        '
        Me.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(279, 23)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(164, 22)
        Me.cmbCategory.TabIndex = 22
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackColor = System.Drawing.Color.White
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.ImageIndex = 3
        Me.btnSearch.ImageList = Me.ImageList1
        Me.btnSearch.Location = New System.Drawing.Point(941, 11)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(92, 34)
        Me.btnSearch.TabIndex = 21
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8-eye-100.png")
        Me.ImageList1.Images.SetKeyName(1, "icons8-upload-to-ftp-100.png")
        Me.ImageList1.Images.SetKeyName(2, "icons8-add-100.png")
        Me.ImageList1.Images.SetKeyName(3, "icons8-search-100.png")
        Me.ImageList1.Images.SetKeyName(4, "icons8-compose-100.png")
        Me.ImageList1.Images.SetKeyName(5, "icons8-todo-list-100.png")
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(133, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 14)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "To"
        '
        'dtFrom
        '
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFrom.Location = New System.Drawing.Point(13, 23)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.Size = New System.Drawing.Size(115, 22)
        Me.dtFrom.TabIndex = 18
        '
        'btnView
        '
        Me.btnView.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnView.BackColor = System.Drawing.Color.White
        Me.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnView.ImageIndex = 3
        Me.btnView.ImageList = Me.ImageList3
        Me.btnView.Location = New System.Drawing.Point(612, 395)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(93, 41)
        Me.btnView.TabIndex = 27
        Me.btnView.Text = "VIEW"
        Me.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnView.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.ImageIndex = 5
        Me.btnCancel.ImageList = Me.ImageList3
        Me.btnCancel.Location = New System.Drawing.Point(802, 395)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(116, 41)
        Me.btnCancel.TabIndex = 25
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.White
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 4
        Me.btnEdit.ImageList = Me.ImageList3
        Me.btnEdit.Location = New System.Drawing.Point(704, 395)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(99, 41)
        Me.btnEdit.TabIndex = 26
        Me.btnEdit.Text = "EDIT"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "icons8-eye-100.png")
        Me.ImageList2.Images.SetKeyName(1, "icons8-upload-to-ftp-100.png")
        Me.ImageList2.Images.SetKeyName(2, "icons8-add-100.png")
        Me.ImageList2.Images.SetKeyName(3, "icons8-search-100.png")
        Me.ImageList2.Images.SetKeyName(4, "icons8-compose-100.png")
        Me.ImageList2.Images.SetKeyName(5, "icons8-delete-bin-100.png")
        Me.ImageList2.Images.SetKeyName(6, "icons8-information-96.png")
        Me.ImageList2.Images.SetKeyName(7, "icons8-print-100 (1).png")
        Me.ImageList2.Images.SetKeyName(8, "icons8-move-stock-100.png")
        Me.ImageList2.Images.SetKeyName(9, "icons8-sync-100 (1).png")
        '
        'FrmRequestForPaymentList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1053, 441)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmRequestForPaymentList"
        Me.Text = "FrmRequestForPaymentList"
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlAdvanceSearch.ResumeLayout(False)
        Me.pnlAdvanceSearch.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtList As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnView As Button
    Friend WithEvents ImageList3 As ImageList
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pnlAdvanceSearch As Panel
    Friend WithEvents cmbFVoyage As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbFVessel As ComboBox
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbValue As ComboBox
    Friend WithEvents cmbCategory As ComboBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dtFrom As DateTimePicker
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Button2 As Button
    Friend WithEvents ImageList4 As ImageList
End Class
