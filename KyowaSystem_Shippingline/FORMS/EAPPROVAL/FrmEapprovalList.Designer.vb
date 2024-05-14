<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEapprovalList
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEapprovalList))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSync = New System.Windows.Forms.Button()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSendRequest = New System.Windows.Forms.Button()
        Me.dtList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.btnSync)
        Me.Panel1.Controls.Add(Me.btnSendRequest)
        Me.Panel1.Controls.Add(Me.dtList)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(984, 348)
        Me.Panel1.TabIndex = 2
        '
        'btnSync
        '
        Me.btnSync.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSync.BackColor = System.Drawing.Color.White
        Me.btnSync.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSync.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSync.ImageIndex = 9
        Me.btnSync.ImageList = Me.ImageList3
        Me.btnSync.Location = New System.Drawing.Point(822, 11)
        Me.btnSync.Name = "btnSync"
        Me.btnSync.Size = New System.Drawing.Size(150, 41)
        Me.btnSync.TabIndex = 34
        Me.btnSync.Text = "&SYNC EAPPROVALS"
        Me.btnSync.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSync.UseVisualStyleBackColor = False
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
        Me.ImageList3.Images.SetKeyName(9, "icons8-sync-100 (1).png")
        '
        'btnSendRequest
        '
        Me.btnSendRequest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSendRequest.BackColor = System.Drawing.Color.Gold
        Me.btnSendRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSendRequest.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendRequest.ForeColor = System.Drawing.Color.Black
        Me.btnSendRequest.Location = New System.Drawing.Point(12, 310)
        Me.btnSendRequest.Name = "btnSendRequest"
        Me.btnSendRequest.Size = New System.Drawing.Size(173, 29)
        Me.btnSendRequest.TabIndex = 10
        Me.btnSendRequest.Text = "CREATE REQUEST"
        Me.btnSendRequest.UseVisualStyleBackColor = False
        '
        'dtList
        '
        Me.dtList.AllowUserToAddRows = False
        Me.dtList.AllowUserToDeleteRows = False
        Me.dtList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column9, Me.Column4, Me.Column5, Me.Column10, Me.Column6, Me.Column7, Me.Column11, Me.Column8, Me.Column12})
        Me.dtList.Location = New System.Drawing.Point(12, 58)
        Me.dtList.Name = "dtList"
        Me.dtList.ReadOnly = True
        Me.dtList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtList.Size = New System.Drawing.Size(960, 246)
        Me.dtList.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Sysref"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "Request Date"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 120
        '
        'Column3
        '
        Me.Column3.HeaderText = "Particular"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 330
        '
        'Column9
        '
        Me.Column9.HeaderText = "Urg Lvl"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 70
        '
        'Column4
        '
        Me.Column4.HeaderText = "Checked by"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "Checked by Status"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 200
        '
        'Column10
        '
        Me.Column10.HeaderText = "Note by Checker"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.Width = 150
        '
        'Column6
        '
        Me.Column6.HeaderText = "Signatory"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle4
        Me.Column7.HeaderText = "Signatory Status"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 200
        '
        'Column11
        '
        Me.Column11.HeaderText = "Note by Signatory"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.Width = 150
        '
        'Column8
        '
        Me.Column8.HeaderText = "Requested By"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 120
        '
        'Column12
        '
        Me.Column12.HeaderText = "Status"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.Width = 120
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
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(191, 310)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(243, 29)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "PRINT E-APPROVAL REQUEST"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
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
        Me.ImageList1.Images.SetKeyName(5, "icons8-delete-bin-100.png")
        Me.ImageList1.Images.SetKeyName(6, "icons8-information-96.png")
        Me.ImageList1.Images.SetKeyName(7, "icons8-print-100 (1).png")
        Me.ImageList1.Images.SetKeyName(8, "icons8-move-stock-100.png")
        Me.ImageList1.Images.SetKeyName(9, "icons8-sync-100 (1).png")
        '
        'FrmEapprovalList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 348)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmEapprovalList"
        Me.Text = "FrmEapprovalList"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtList As DataGridView
    Friend WithEvents btnSendRequest As Button
    Friend WithEvents btnSync As Button
    Friend WithEvents ImageList3 As ImageList
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents ImageList1 As ImageList
End Class
