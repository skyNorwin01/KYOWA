<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAddManualContainer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddManualContainer))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtcontainerno = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSize = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSaveCs = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblSysref = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.lblSysref)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.btnSaveCs)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.cmbSize)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtcontainerno)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(356, 163)
        Me.Panel1.TabIndex = 2
        '
        'txtcontainerno
        '
        Me.txtcontainerno.Location = New System.Drawing.Point(107, 38)
        Me.txtcontainerno.Name = "txtcontainerno"
        Me.txtcontainerno.Size = New System.Drawing.Size(206, 22)
        Me.txtcontainerno.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CONTAINER NO:"
        '
        'cmbSize
        '
        Me.cmbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSize.FormattingEnabled = True
        Me.cmbSize.Location = New System.Drawing.Point(107, 67)
        Me.cmbSize.Name = "cmbSize"
        Me.cmbSize.Size = New System.Drawing.Size(206, 22)
        Me.cmbSize.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 14)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "SIZE:"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8-close-window-100.png")
        Me.ImageList1.Images.SetKeyName(1, "icons8-save-all-100.png")
        Me.ImageList1.Images.SetKeyName(2, "icons8-place-marker-100.png")
        Me.ImageList1.Images.SetKeyName(3, "icons8-euro-100.png")
        Me.ImageList1.Images.SetKeyName(4, "icons8-pass-fail-100.png")
        Me.ImageList1.Images.SetKeyName(5, "icons8-delete-25.png")
        Me.ImageList1.Images.SetKeyName(6, "icons8-delete-100.png")
        '
        'btnSaveCs
        '
        Me.btnSaveCs.BackColor = System.Drawing.Color.Gold
        Me.btnSaveCs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveCs.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveCs.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnSaveCs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSaveCs.ImageIndex = 1
        Me.btnSaveCs.ImageList = Me.ImageList1
        Me.btnSaveCs.Location = New System.Drawing.Point(107, 95)
        Me.btnSaveCs.Name = "btnSaveCs"
        Me.btnSaveCs.Size = New System.Drawing.Size(101, 45)
        Me.btnSaveCs.TabIndex = 27
        Me.btnSaveCs.Text = "SAVE"
        Me.btnSaveCs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSaveCs.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImageIndex = 0
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(214, 95)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 45)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "CLOSE"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblSysref
        '
        Me.lblSysref.AutoSize = True
        Me.lblSysref.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSysref.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblSysref.Location = New System.Drawing.Point(55, 9)
        Me.lblSysref.Name = "lblSysref"
        Me.lblSysref.Size = New System.Drawing.Size(47, 14)
        Me.lblSysref.TabIndex = 30
        Me.lblSysref.Text = "SYSREF:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 14)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "SYSREF:"
        '
        'FrmAddManualContainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 163)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmAddManualContainer"
        Me.Text = "FrmAddManualContainer"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbSize As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtcontainerno As TextBox
    Friend WithEvents btnSaveCs As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Button1 As Button
    Friend WithEvents lblSysref As Label
    Friend WithEvents Label3 As Label
End Class
