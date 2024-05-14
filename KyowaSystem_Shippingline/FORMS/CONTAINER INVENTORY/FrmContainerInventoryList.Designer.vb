<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmContainerInventoryList
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContainerInventoryList))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.cmbFilter = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnGenerateExcel = New System.Windows.Forms.Button()
        Me.dtList = New System.Windows.Forms.DataGridView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.btnGenerateExcel)
        Me.Panel1.Controls.Add(Me.dtList)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(838, 481)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnSearch)
        Me.Panel2.Controls.Add(Me.txtValue)
        Me.Panel2.Controls.Add(Me.cmbFilter)
        Me.Panel2.Location = New System.Drawing.Point(13, 5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(813, 41)
        Me.Panel2.TabIndex = 32
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.BackColor = System.Drawing.Color.White
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.ImageIndex = 3
        Me.btnSearch.ImageList = Me.ImageList2
        Me.btnSearch.Location = New System.Drawing.Point(716, 3)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(92, 34)
        Me.btnSearch.TabIndex = 22
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = False
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
        Me.ImageList2.Images.SetKeyName(5, "icons8-todo-list-100.png")
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(217, 9)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(493, 22)
        Me.txtValue.TabIndex = 1
        '
        'cmbFilter
        '
        Me.cmbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFilter.FormattingEnabled = True
        Me.cmbFilter.Location = New System.Drawing.Point(14, 9)
        Me.cmbFilter.Name = "cmbFilter"
        Me.cmbFilter.Size = New System.Drawing.Size(196, 22)
        Me.cmbFilter.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.ImageIndex = 10
        Me.Button3.ImageList = Me.ImageList3
        Me.Button3.Location = New System.Drawing.Point(430, 435)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(119, 41)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "UPLOAD FILE"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        Me.Button3.Visible = False
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
        Me.ImageList3.Images.SetKeyName(10, "icons8-loading-sign-100.png")
        Me.ImageList3.Images.SetKeyName(11, "icons8-in-progress.gif")
        '
        'btnGenerateExcel
        '
        Me.btnGenerateExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerateExcel.BackColor = System.Drawing.Color.White
        Me.btnGenerateExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateExcel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerateExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerateExcel.ImageIndex = 10
        Me.btnGenerateExcel.ImageList = Me.ImageList3
        Me.btnGenerateExcel.Location = New System.Drawing.Point(555, 435)
        Me.btnGenerateExcel.Name = "btnGenerateExcel"
        Me.btnGenerateExcel.Size = New System.Drawing.Size(271, 41)
        Me.btnGenerateExcel.TabIndex = 30
        Me.btnGenerateExcel.Text = "GENERATE CONTAINER INVENTORY FOR "
        Me.btnGenerateExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerateExcel.UseVisualStyleBackColor = False
        '
        'dtList
        '
        Me.dtList.AllowUserToAddRows = False
        Me.dtList.AllowUserToDeleteRows = False
        Me.dtList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column4, Me.Column6, Me.Column7, Me.Column8, Me.Column5, Me.Column3})
        Me.dtList.Location = New System.Drawing.Point(12, 52)
        Me.dtList.Name = "dtList"
        Me.dtList.Size = New System.Drawing.Size(814, 377)
        Me.dtList.TabIndex = 0
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = "BOOKING NO"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column4
        '
        Me.Column4.HeaderText = "CONTAINER YARD"
        Me.Column4.Name = "Column4"
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column4.Width = 400
        '
        'Column6
        '
        Me.Column6.HeaderText = "CONTAINER YARD"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 400
        '
        'Column7
        '
        Me.Column7.HeaderText = "Nos. of Seal"
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        Me.Column8.HeaderText = "REFNO"
        Me.Column8.Name = "Column8"
        '
        'Column5
        '
        Me.Column5.HeaderText = ""
        Me.Column5.Image = CType(resources.GetObject("Column5.Image"), System.Drawing.Image)
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 25
        '
        'Column3
        '
        Me.Column3.HeaderText = ""
        Me.Column3.Image = CType(resources.GetObject("Column3.Image"), System.Drawing.Image)
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 25
        '
        'FrmContainerInventoryList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 481)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmContainerInventoryList"
        Me.Text = "FrmContainerInventoryList"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtList As DataGridView
    Friend WithEvents Button3 As Button
    Friend WithEvents ImageList3 As ImageList
    Friend WithEvents btnGenerateExcel As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Panel2 As Panel
    Friend WithEvents txtValue As TextBox
    Friend WithEvents cmbFilter As ComboBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewComboBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewImageColumn
    Friend WithEvents Column3 As DataGridViewImageColumn
End Class
