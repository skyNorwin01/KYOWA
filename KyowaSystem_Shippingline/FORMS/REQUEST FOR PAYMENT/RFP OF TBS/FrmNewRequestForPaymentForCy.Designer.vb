<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewRequestForPaymentForCy
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNewRequestForPaymentForCy))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRefno = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBsno = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtPeriod2 = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtPeriod1 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbParticular = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAmount = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbInfavorOf = New System.Windows.Forms.ComboBox()
        Me.cmbCheck = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtDate = New System.Windows.Forms.DateTimePicker()
        Me.cmbFrom = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtDueOn = New System.Windows.Forms.DateTimePicker()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.dtDueOn)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.txtRefno)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtBsno)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.dtPeriod2)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.dtPeriod1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cmbParticular)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.txtAmount)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbInfavorOf)
        Me.Panel1.Controls.Add(Me.cmbCheck)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dtDate)
        Me.Panel1.Controls.Add(Me.cmbFrom)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmbTo)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(410, 323)
        Me.Panel1.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.ImageIndex = 5
        Me.btnCancel.ImageList = Me.ImageList3
        Me.btnCancel.Location = New System.Drawing.Point(282, 270)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(116, 41)
        Me.btnCancel.TabIndex = 30
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = False
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
        'btnEdit
        '
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.BackColor = System.Drawing.Color.White
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEdit.ImageIndex = 4
        Me.btnEdit.ImageList = Me.ImageList3
        Me.btnEdit.Location = New System.Drawing.Point(137, 270)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(146, 41)
        Me.btnEdit.TabIndex = 31
        Me.btnEdit.Text = "SAVE AND PRINT"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(33, 210)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 14)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "REFNO:"
        '
        'txtRefno
        '
        Me.txtRefno.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRefno.Location = New System.Drawing.Point(84, 207)
        Me.txtRefno.Name = "txtRefno"
        Me.txtRefno.Size = New System.Drawing.Size(142, 22)
        Me.txtRefno.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(39, 189)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 14)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "BSNO:"
        '
        'txtBsno
        '
        Me.txtBsno.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBsno.Location = New System.Drawing.Point(84, 186)
        Me.txtBsno.Name = "txtBsno"
        Me.txtBsno.Size = New System.Drawing.Size(142, 22)
        Me.txtBsno.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(236, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(11, 14)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "-"
        '
        'dtPeriod2
        '
        Me.dtPeriod2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPeriod2.Location = New System.Drawing.Point(255, 165)
        Me.dtPeriod2.Name = "dtPeriod2"
        Me.dtPeriod2.Size = New System.Drawing.Size(142, 22)
        Me.dtPeriod2.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(30, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 14)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "PERIOD:"
        '
        'dtPeriod1
        '
        Me.dtPeriod1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPeriod1.Location = New System.Drawing.Point(84, 165)
        Me.dtPeriod1.Name = "dtPeriod1"
        Me.dtPeriod1.Size = New System.Drawing.Size(142, 22)
        Me.dtPeriod1.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 14)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "PARTICULAR:"
        '
        'cmbParticular
        '
        Me.cmbParticular.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbParticular.FormattingEnabled = True
        Me.cmbParticular.Location = New System.Drawing.Point(84, 144)
        Me.cmbParticular.Name = "cmbParticular"
        Me.cmbParticular.Size = New System.Drawing.Size(313, 22)
        Me.cmbParticular.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 14)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "AMOUNT:"
        '
        'txtAmount
        '
        Me.txtAmount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtAmount.Location = New System.Drawing.Point(84, 117)
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(142, 22)
        Me.txtAmount.TabIndex = 9
        Me.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "IN FAVOR OF:"
        '
        'cmbInfavorOf
        '
        Me.cmbInfavorOf.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbInfavorOf.FormattingEnabled = True
        Me.cmbInfavorOf.Location = New System.Drawing.Point(84, 96)
        Me.cmbInfavorOf.Name = "cmbInfavorOf"
        Me.cmbInfavorOf.Size = New System.Drawing.Size(313, 22)
        Me.cmbInfavorOf.TabIndex = 7
        '
        'cmbCheck
        '
        Me.cmbCheck.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbCheck.FormattingEnabled = True
        Me.cmbCheck.Location = New System.Drawing.Point(84, 75)
        Me.cmbCheck.Name = "cmbCheck"
        Me.cmbCheck.Size = New System.Drawing.Size(313, 22)
        Me.cmbCheck.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 14)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "DATE:"
        '
        'dtDate
        '
        Me.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDate.Location = New System.Drawing.Point(84, 12)
        Me.dtDate.Name = "dtDate"
        Me.dtDate.Size = New System.Drawing.Size(142, 22)
        Me.dtDate.TabIndex = 4
        '
        'cmbFrom
        '
        Me.cmbFrom.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbFrom.Enabled = False
        Me.cmbFrom.FormattingEnabled = True
        Me.cmbFrom.Location = New System.Drawing.Point(84, 54)
        Me.cmbFrom.Name = "cmbFrom"
        Me.cmbFrom.Size = New System.Drawing.Size(313, 22)
        Me.cmbFrom.TabIndex = 3
        Me.cmbFrom.Text = "KYOWA SHIPPING LINE CO., LTD"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(41, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "FROM:"
        '
        'cmbTo
        '
        Me.cmbTo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbTo.Enabled = False
        Me.cmbTo.FormattingEnabled = True
        Me.cmbTo.Location = New System.Drawing.Point(84, 33)
        Me.cmbTo.Name = "cmbTo"
        Me.cmbTo.Size = New System.Drawing.Size(313, 22)
        Me.cmbTo.TabIndex = 1
        Me.cmbTo.Text = "ACCOUNTING DEPARTMENT"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TO:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(30, 232)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 14)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "DUE ON:"
        '
        'dtDueOn
        '
        Me.dtDueOn.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtDueOn.Location = New System.Drawing.Point(84, 228)
        Me.dtDueOn.Name = "dtDueOn"
        Me.dtDueOn.Size = New System.Drawing.Size(142, 22)
        Me.dtDueOn.TabIndex = 32
        '
        'FrmNewRequestForPaymentForCy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 323)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmNewRequestForPaymentForCy"
        Me.Text = "FrmNewRequestForPaymentForCy"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents txtRefno As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtBsno As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtPeriod2 As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents dtPeriod1 As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbParticular As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAmount As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbInfavorOf As ComboBox
    Friend WithEvents cmbCheck As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents dtDate As DateTimePicker
    Friend WithEvents cmbFrom As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbTo As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents ImageList3 As ImageList
    Friend WithEvents btnEdit As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents dtDueOn As DateTimePicker
End Class
