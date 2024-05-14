<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmContainerInventoryEditRow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmContainerInventoryEditRow))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtSize = New System.Windows.Forms.TextBox()
        Me.mtxtArrivalMnl = New System.Windows.Forms.MaskedTextBox()
        Me.cmbContainerStats = New System.Windows.Forms.ComboBox()
        Me.mtxtReturdToDepot = New System.Windows.Forms.MaskedTextBox()
        Me.cmbRemarks = New System.Windows.Forms.ComboBox()
        Me.mtxtPullout = New System.Windows.Forms.MaskedTextBox()
        Me.cmbReleasetoShipper = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.mtxtPullout)
        Me.Panel1.Controls.Add(Me.cmbReleasetoShipper)
        Me.Panel1.Controls.Add(Me.cmbRemarks)
        Me.Panel1.Controls.Add(Me.mtxtReturdToDepot)
        Me.Panel1.Controls.Add(Me.cmbContainerStats)
        Me.Panel1.Controls.Add(Me.mtxtArrivalMnl)
        Me.Panel1.Controls.Add(Me.txtSize)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1044, 45)
        Me.Panel1.TabIndex = 2
        '
        'txtSize
        '
        Me.txtSize.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtSize.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSize.Location = New System.Drawing.Point(1, 21)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        Me.txtSize.Size = New System.Drawing.Size(74, 23)
        Me.txtSize.TabIndex = 1
        '
        'mtxtArrivalMnl
        '
        Me.mtxtArrivalMnl.Location = New System.Drawing.Point(74, 21)
        Me.mtxtArrivalMnl.Mask = "00/00/0000"
        Me.mtxtArrivalMnl.Name = "mtxtArrivalMnl"
        Me.mtxtArrivalMnl.Size = New System.Drawing.Size(74, 22)
        Me.mtxtArrivalMnl.TabIndex = 3
        Me.mtxtArrivalMnl.ValidatingType = GetType(Date)
        '
        'cmbContainerStats
        '
        Me.cmbContainerStats.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbContainerStats.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbContainerStats.FormattingEnabled = True
        Me.cmbContainerStats.Location = New System.Drawing.Point(147, 21)
        Me.cmbContainerStats.Name = "cmbContainerStats"
        Me.cmbContainerStats.Size = New System.Drawing.Size(283, 22)
        Me.cmbContainerStats.TabIndex = 4
        '
        'mtxtReturdToDepot
        '
        Me.mtxtReturdToDepot.Location = New System.Drawing.Point(429, 21)
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
        Me.cmbRemarks.Location = New System.Drawing.Point(508, 21)
        Me.cmbRemarks.Name = "cmbRemarks"
        Me.cmbRemarks.Size = New System.Drawing.Size(124, 22)
        Me.cmbRemarks.TabIndex = 6
        '
        'mtxtPullout
        '
        Me.mtxtPullout.Location = New System.Drawing.Point(913, 21)
        Me.mtxtPullout.Mask = "00/00/0000"
        Me.mtxtPullout.Name = "mtxtPullout"
        Me.mtxtPullout.Size = New System.Drawing.Size(80, 22)
        Me.mtxtPullout.TabIndex = 8
        Me.mtxtPullout.ValidatingType = GetType(Date)
        '
        'cmbReleasetoShipper
        '
        Me.cmbReleasetoShipper.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbReleasetoShipper.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbReleasetoShipper.FormattingEnabled = True
        Me.cmbReleasetoShipper.Location = New System.Drawing.Point(631, 21)
        Me.cmbReleasetoShipper.Name = "cmbReleasetoShipper"
        Me.cmbReleasetoShipper.Size = New System.Drawing.Size(283, 22)
        Me.cmbReleasetoShipper.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 14)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "SIZE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(71, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 14)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "ARRIVAL MNL"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(154, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 14)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "STATUS OF CONTAINER"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(426, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 14)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "RETRN DEPOT"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(510, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 14)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "REMARKS"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(628, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 14)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "RELEASE TO SHIPPER"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(910, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 14)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "PULL OUT"
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ImageIndex = 0
        Me.btnSave.ImageList = Me.ImageList1
        Me.btnSave.Location = New System.Drawing.Point(1000, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(37, 36)
        Me.btnSave.TabIndex = 16
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8-save-100.png")
        '
        'FrmContainerInventoryEditRow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 45)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmContainerInventoryEditRow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmContainerInventoryEditRow"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents txtSize As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents mtxtPullout As MaskedTextBox
    Friend WithEvents cmbReleasetoShipper As ComboBox
    Friend WithEvents cmbRemarks As ComboBox
    Friend WithEvents mtxtReturdToDepot As MaskedTextBox
    Friend WithEvents cmbContainerStats As ComboBox
    Friend WithEvents mtxtArrivalMnl As MaskedTextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents ImageList1 As ImageList
End Class
