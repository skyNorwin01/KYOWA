<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOnhireUnitEditRow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOnhireUnitEditRow))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.mtxtContainer = New System.Windows.Forms.TextBox()
        Me.mTxtPullout = New System.Windows.Forms.MaskedTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.cmbContainerStats = New System.Windows.Forms.ComboBox()
        Me.mtxtReturdToDepot = New System.Windows.Forms.MaskedTextBox()
        Me.cmbRemarks = New System.Windows.Forms.ComboBox()
        Me.cmbReleasetoShipper = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBookingNo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbShipper = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.mTxtValidity = New System.Windows.Forms.MaskedTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbOnHireUnits = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtContainer = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbSize = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbCy = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLctOfFV = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8-save-100.png")
        Me.ImageList1.Images.SetKeyName(1, "icons8-close-window-100.png")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.mtxtContainer)
        Me.Panel1.Controls.Add(Me.mTxtPullout)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.txtBookingNo)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.cmbShipper)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.mTxtValidity)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.cmbOnHireUnits)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtContainer)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cmbSize)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.cmbCy)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtLctOfFV)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1092, 105)
        Me.Panel1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImageIndex = 1
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(995, 57)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(84, 36)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "CLOSE"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'mtxtContainer
        '
        Me.mtxtContainer.BackColor = System.Drawing.Color.White
        Me.mtxtContainer.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mtxtContainer.Location = New System.Drawing.Point(576, 25)
        Me.mtxtContainer.Name = "mtxtContainer"
        Me.mtxtContainer.Size = New System.Drawing.Size(137, 23)
        Me.mtxtContainer.TabIndex = 2
        '
        'mTxtPullout
        '
        Me.mTxtPullout.Location = New System.Drawing.Point(742, 68)
        Me.mTxtPullout.Mask = "00/00/0000 00:00"
        Me.mTxtPullout.Name = "mTxtPullout"
        Me.mTxtPullout.Size = New System.Drawing.Size(144, 22)
        Me.mTxtPullout.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtSize)
        Me.Panel2.Controls.Add(Me.cmbContainerStats)
        Me.Panel2.Controls.Add(Me.mtxtReturdToDepot)
        Me.Panel2.Controls.Add(Me.cmbRemarks)
        Me.Panel2.Controls.Add(Me.cmbReleasetoShipper)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Location = New System.Drawing.Point(25, 132)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(902, 68)
        Me.Panel2.TabIndex = 33
        Me.Panel2.Visible = False
        '
        'txtSize
        '
        Me.txtSize.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSize.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSize.Location = New System.Drawing.Point(3, 33)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        Me.txtSize.Size = New System.Drawing.Size(74, 23)
        Me.txtSize.TabIndex = 1
        '
        'cmbContainerStats
        '
        Me.cmbContainerStats.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbContainerStats.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbContainerStats.FormattingEnabled = True
        Me.cmbContainerStats.Location = New System.Drawing.Point(76, 34)
        Me.cmbContainerStats.Name = "cmbContainerStats"
        Me.cmbContainerStats.Size = New System.Drawing.Size(283, 22)
        Me.cmbContainerStats.TabIndex = 4
        '
        'mtxtReturdToDepot
        '
        Me.mtxtReturdToDepot.Location = New System.Drawing.Point(358, 34)
        Me.mtxtReturdToDepot.Mask = "00/00/0000"
        Me.mtxtReturdToDepot.Name = "mtxtReturdToDepot"
        Me.mtxtReturdToDepot.Size = New System.Drawing.Size(80, 22)
        Me.mtxtReturdToDepot.TabIndex = 5
        Me.mtxtReturdToDepot.ValidatingType = GetType(Date)
        '
        'cmbRemarks
        '
        Me.cmbRemarks.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRemarks.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRemarks.FormattingEnabled = True
        Me.cmbRemarks.Location = New System.Drawing.Point(437, 34)
        Me.cmbRemarks.Name = "cmbRemarks"
        Me.cmbRemarks.Size = New System.Drawing.Size(124, 22)
        Me.cmbRemarks.TabIndex = 6
        '
        'cmbReleasetoShipper
        '
        Me.cmbReleasetoShipper.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbReleasetoShipper.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbReleasetoShipper.FormattingEnabled = True
        Me.cmbReleasetoShipper.Location = New System.Drawing.Point(560, 34)
        Me.cmbReleasetoShipper.Name = "cmbReleasetoShipper"
        Me.cmbReleasetoShipper.Size = New System.Drawing.Size(283, 22)
        Me.cmbReleasetoShipper.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 14)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "SIZE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(83, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "STATUS OF CONTAINER"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(355, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 14)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "RETRN DEPOT"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(439, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 14)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "REMARKS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(557, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 14)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "RELEASE TO SHIPPER"
        '
        'txtBookingNo
        '
        Me.txtBookingNo.BackColor = System.Drawing.Color.White
        Me.txtBookingNo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBookingNo.Location = New System.Drawing.Point(712, 25)
        Me.txtBookingNo.Name = "txtBookingNo"
        Me.txtBookingNo.Size = New System.Drawing.Size(224, 23)
        Me.txtBookingNo.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(12, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 14)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "SHIPPER"
        '
        'cmbShipper
        '
        Me.cmbShipper.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbShipper.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbShipper.FormattingEnabled = True
        Me.cmbShipper.Location = New System.Drawing.Point(12, 68)
        Me.cmbShipper.Name = "cmbShipper"
        Me.cmbShipper.Size = New System.Drawing.Size(283, 22)
        Me.cmbShipper.TabIndex = 5
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(933, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 14)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "VALIDITY"
        '
        'mTxtValidity
        '
        Me.mTxtValidity.Location = New System.Drawing.Point(935, 26)
        Me.mTxtValidity.Mask = "00/00/0000 90:00"
        Me.mTxtValidity.Name = "mTxtValidity"
        Me.mTxtValidity.Size = New System.Drawing.Size(144, 22)
        Me.mTxtValidity.TabIndex = 4
        Me.mTxtValidity.ValidatingType = GetType(Date)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(714, 11)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 14)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "BOOKING NO"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(572, 11)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(136, 14)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "CONTAINER e.g(10X20DC)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(294, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(85, 14)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "ON-HIRE UNITS"
        '
        'cmbOnHireUnits
        '
        Me.cmbOnHireUnits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbOnHireUnits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOnHireUnits.FormattingEnabled = True
        Me.cmbOnHireUnits.Location = New System.Drawing.Point(294, 26)
        Me.cmbOnHireUnits.Name = "cmbOnHireUnits"
        Me.cmbOnHireUnits.Size = New System.Drawing.Size(283, 22)
        Me.cmbOnHireUnits.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(518, 53)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 14)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "CONTAINER NO"
        '
        'txtContainer
        '
        Me.txtContainer.BackColor = System.Drawing.Color.White
        Me.txtContainer.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContainer.Location = New System.Drawing.Point(517, 67)
        Me.txtContainer.Name = "txtContainer"
        Me.txtContainer.Size = New System.Drawing.Size(226, 23)
        Me.txtContainer.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(296, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 14)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "SIZE"
        '
        'cmbSize
        '
        Me.cmbSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSize.FormattingEnabled = True
        Me.cmbSize.Location = New System.Drawing.Point(294, 68)
        Me.cmbSize.Name = "cmbSize"
        Me.cmbSize.Size = New System.Drawing.Size(81, 22)
        Me.cmbSize.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 14)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "CY"
        '
        'cmbCy
        '
        Me.cmbCy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCy.FormattingEnabled = True
        Me.cmbCy.Location = New System.Drawing.Point(12, 26)
        Me.cmbCy.Name = "cmbCy"
        Me.cmbCy.Size = New System.Drawing.Size(283, 22)
        Me.cmbCy.TabIndex = 0
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.ImageIndex = 0
        Me.btnSave.ImageList = Me.ImageList1
        Me.btnSave.Location = New System.Drawing.Point(899, 57)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 36)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "SAVE"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(739, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 14)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "PULL OUT"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(371, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "LCT OF FV"
        '
        'txtLctOfFV
        '
        Me.txtLctOfFV.Location = New System.Drawing.Point(374, 68)
        Me.txtLctOfFV.Mask = "00/00/0000 00:00"
        Me.txtLctOfFV.Name = "txtLctOfFV"
        Me.txtLctOfFV.Size = New System.Drawing.Size(144, 22)
        Me.txtLctOfFV.TabIndex = 7
        '
        'FrmOnhireUnitEditRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button1
        Me.ClientSize = New System.Drawing.Size(1092, 105)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmOnhireUnitEditRow"
        Me.Text = "FrmOnhireUnitEditRow"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbReleasetoShipper As ComboBox
    Friend WithEvents cmbRemarks As ComboBox
    Friend WithEvents mtxtReturdToDepot As MaskedTextBox
    Friend WithEvents cmbContainerStats As ComboBox
    Friend WithEvents txtLctOfFV As MaskedTextBox
    Friend WithEvents txtSize As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbSize As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbCy As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbShipper As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents mTxtValidity As MaskedTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtBookingNo As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbOnHireUnits As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtContainer As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents mTxtPullout As MaskedTextBox
    Friend WithEvents mtxtContainer As TextBox
    Friend WithEvents Button1 As Button
End Class
