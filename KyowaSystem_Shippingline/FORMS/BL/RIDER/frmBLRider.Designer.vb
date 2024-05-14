<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBLRider
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBLRider))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.lblConsignee = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.lblShipper = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblBlno = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblRefno = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.dtList = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbTypeOfPackages = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSeal = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmbPackingScheme = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbContainerNo = New System.Windows.Forms.ComboBox()
        Me.cmbDescription = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtNetWeight = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMnN = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.dtList)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(987, 582)
        Me.Panel1.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(987, 98)
        Me.Panel3.TabIndex = 101
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel9, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel8, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(987, 96)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(496, 61)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(488, 1)
        Me.Panel9.TabIndex = 8
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(496, 89)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(488, 7)
        Me.Label12.TabIndex = 6
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 89)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(487, 7)
        Me.Label11.TabIndex = 5
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.lblConsignee)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(496, 66)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(488, 20)
        Me.Panel7.TabIndex = 4
        '
        'lblConsignee
        '
        Me.lblConsignee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblConsignee.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsignee.Location = New System.Drawing.Point(0, 0)
        Me.lblConsignee.Name = "lblConsignee"
        Me.lblConsignee.Size = New System.Drawing.Size(488, 20)
        Me.lblConsignee.TabIndex = 0
        Me.lblConsignee.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.lblShipper)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 66)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(487, 20)
        Me.Panel6.TabIndex = 3
        '
        'lblShipper
        '
        Me.lblShipper.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblShipper.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShipper.Location = New System.Drawing.Point(0, 0)
        Me.lblShipper.Name = "lblShipper"
        Me.lblShipper.Size = New System.Drawing.Size(487, 20)
        Me.lblShipper.TabIndex = 0
        Me.lblShipper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblBlno)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(496, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(488, 52)
        Me.Panel5.TabIndex = 2
        '
        'lblBlno
        '
        Me.lblBlno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblBlno.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlno.Location = New System.Drawing.Point(0, 0)
        Me.lblBlno.Name = "lblBlno"
        Me.lblBlno.Size = New System.Drawing.Size(488, 52)
        Me.lblBlno.TabIndex = 0
        Me.lblBlno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.lblRefno)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(487, 52)
        Me.Panel4.TabIndex = 1
        '
        'lblRefno
        '
        Me.lblRefno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblRefno.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefno.Location = New System.Drawing.Point(0, 0)
        Me.lblRefno.Name = "lblRefno"
        Me.lblRefno.Size = New System.Drawing.Size(487, 52)
        Me.lblRefno.TabIndex = 0
        Me.lblRefno.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(3, 61)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(487, 1)
        Me.Panel8.TabIndex = 7
        '
        'dtList
        '
        Me.dtList.AllowUserToAddRows = False
        Me.dtList.AllowUserToDeleteRows = False
        Me.dtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column9, Me.Column4, Me.Column6, Me.Column5, Me.Column7, Me.Column8})
        Me.dtList.Location = New System.Drawing.Point(13, 269)
        Me.dtList.Name = "dtList"
        Me.dtList.ReadOnly = True
        Me.dtList.Size = New System.Drawing.Size(962, 301)
        Me.dtList.TabIndex = 100
        '
        'Column1
        '
        Me.Column1.HeaderText = "MnN"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 80
        '
        'Column2
        '
        Me.Column2.HeaderText = "QTY"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 80
        '
        'Column3
        '
        Me.Column3.HeaderText = "Packaging Scheme"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 135
        '
        'Column9
        '
        Me.Column9.HeaderText = "Type of Package"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.Width = 120
        '
        'Column4
        '
        Me.Column4.HeaderText = "Description of Goods"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 340
        '
        'Column6
        '
        Me.Column6.HeaderText = "NetWeight"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 80
        '
        'Column5
        '
        Me.Column5.HeaderText = "ContainerNo"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        '
        'Column7
        '
        Me.Column7.HeaderText = "SealNo"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'Column8
        '
        Me.Column8.HeaderText = "del"
        Me.Column8.Image = CType(resources.GetObject("Column8.Image"), System.Drawing.Image)
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 40
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmbTypeOfPackages)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txtSeal)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.cmbPackingScheme)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.cmbContainerNo)
        Me.Panel2.Controls.Add(Me.cmbDescription)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.txtNetWeight)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.txtQty)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtMnN)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(13, 120)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(962, 123)
        Me.Panel2.TabIndex = 0
        '
        'cmbTypeOfPackages
        '
        Me.cmbTypeOfPackages.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTypeOfPackages.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTypeOfPackages.BackColor = System.Drawing.SystemColors.Info
        Me.cmbTypeOfPackages.FormattingEnabled = True
        Me.cmbTypeOfPackages.Location = New System.Drawing.Point(328, 21)
        Me.cmbTypeOfPackages.Name = "cmbTypeOfPackages"
        Me.cmbTypeOfPackages.Size = New System.Drawing.Size(103, 22)
        Me.cmbTypeOfPackages.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(327, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 14)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Type of Packages"
        '
        'txtSeal
        '
        Me.txtSeal.BackColor = System.Drawing.Color.White
        Me.txtSeal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSeal.Font = New System.Drawing.Font("Calibri", 11.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeal.Location = New System.Drawing.Point(15, 99)
        Me.txtSeal.Name = "txtSeal"
        Me.txtSeal.ReadOnly = True
        Me.txtSeal.Size = New System.Drawing.Size(335, 19)
        Me.txtSeal.TabIndex = 16
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.ImageIndex = 0
        Me.Button2.ImageList = Me.ImageList1
        Me.Button2.Location = New System.Drawing.Point(821, 63)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(136, 38)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "CLEAR"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8-delete-100.png")
        Me.ImageList1.Images.SetKeyName(1, "icons8-plus-36.png")
        '
        'cmbPackingScheme
        '
        Me.cmbPackingScheme.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbPackingScheme.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPackingScheme.BackColor = System.Drawing.SystemColors.Info
        Me.cmbPackingScheme.FormattingEnabled = True
        Me.cmbPackingScheme.Location = New System.Drawing.Point(213, 21)
        Me.cmbPackingScheme.Name = "cmbPackingScheme"
        Me.cmbPackingScheme.Size = New System.Drawing.Size(116, 22)
        Me.cmbPackingScheme.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 14)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "CONTAINER#"
        '
        'cmbContainerNo
        '
        Me.cmbContainerNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbContainerNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbContainerNo.BackColor = System.Drawing.SystemColors.Info
        Me.cmbContainerNo.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbContainerNo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cmbContainerNo.FormattingEnabled = True
        Me.cmbContainerNo.Location = New System.Drawing.Point(13, 62)
        Me.cmbContainerNo.Name = "cmbContainerNo"
        Me.cmbContainerNo.Size = New System.Drawing.Size(337, 37)
        Me.cmbContainerNo.TabIndex = 6
        '
        'cmbDescription
        '
        Me.cmbDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDescription.BackColor = System.Drawing.SystemColors.Info
        Me.cmbDescription.FormattingEnabled = True
        Me.cmbDescription.Location = New System.Drawing.Point(430, 21)
        Me.cmbDescription.Name = "cmbDescription"
        Me.cmbDescription.Size = New System.Drawing.Size(527, 22)
        Me.cmbDescription.TabIndex = 5
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Gold
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.ImageIndex = 1
        Me.Button3.ImageList = Me.ImageList1
        Me.Button3.Location = New System.Drawing.Point(679, 64)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(136, 38)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "ADD"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'txtNetWeight
        '
        Me.txtNetWeight.BackColor = System.Drawing.SystemColors.Info
        Me.txtNetWeight.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetWeight.Location = New System.Drawing.Point(359, 62)
        Me.txtNetWeight.Name = "txtNetWeight"
        Me.txtNetWeight.Size = New System.Drawing.Size(128, 37)
        Me.txtNetWeight.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(356, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 14)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Net Weight"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(432, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(121, 14)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Description of Goods"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(213, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 14)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Packaging Scheme"
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.SystemColors.Info
        Me.txtQty.Location = New System.Drawing.Point(125, 21)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(89, 22)
        Me.txtQty.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(126, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "QTY"
        '
        'txtMnN
        '
        Me.txtMnN.BackColor = System.Drawing.SystemColors.Info
        Me.txtMnN.Location = New System.Drawing.Point(13, 21)
        Me.txtMnN.Name = "txtMnN"
        Me.txtMnN.Size = New System.Drawing.Size(113, 22)
        Me.txtMnN.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Marks And Numbers"
        '
        'frmBLRider
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 582)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmBLRider"
        Me.Text = "frmBLRider"
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMnN As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNetWeight As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtList As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Button3 As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbContainerNo As ComboBox
    Friend WithEvents cmbDescription As ComboBox
    Friend WithEvents cmbPackingScheme As ComboBox
    Friend WithEvents txtSeal As TextBox
    Friend WithEvents cmbTypeOfPackages As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewImageColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents lblConsignee As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents lblShipper As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents lblBlno As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents lblRefno As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
End Class
