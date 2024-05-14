<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmGenerateBlMenus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGenerateBlMenus))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.rdPrinting = New System.Windows.Forms.RadioButton()
        Me.rdSending = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.rdNONNego = New System.Windows.Forms.RadioButton()
        Me.rdOBL = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdFSM = New System.Windows.Forms.RadioButton()
        Me.rdWesPac = New System.Windows.Forms.RadioButton()
        Me.rdKyowaNew = New System.Windows.Forms.RadioButton()
        Me.rdKyowaOld = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdUnfreighted = New System.Windows.Forms.RadioButton()
        Me.rdBilling = New System.Windows.Forms.RadioButton()
        Me.rdDestination = New System.Windows.Forms.RadioButton()
        Me.rdPrincipal = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdCyCfs = New System.Windows.Forms.RadioButton()
        Me.rdCfsCfs = New System.Windows.Forms.RadioButton()
        Me.rdCyCy = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdRider = New System.Windows.Forms.RadioButton()
        Me.rdBL = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.GroupBox6)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 500)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.rdPrinting)
        Me.GroupBox6.Controls.Add(Me.rdSending)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 411)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(260, 48)
        Me.GroupBox6.TabIndex = 5
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "TYPE OF GENERATE"
        '
        'rdPrinting
        '
        Me.rdPrinting.AutoSize = True
        Me.rdPrinting.Location = New System.Drawing.Point(106, 21)
        Me.rdPrinting.Name = "rdPrinting"
        Me.rdPrinting.Size = New System.Drawing.Size(76, 18)
        Me.rdPrinting.TabIndex = 1
        Me.rdPrinting.Text = "PRINTING"
        Me.rdPrinting.UseVisualStyleBackColor = True
        '
        'rdSending
        '
        Me.rdSending.AutoSize = True
        Me.rdSending.Checked = True
        Me.rdSending.Location = New System.Drawing.Point(27, 21)
        Me.rdSending.Name = "rdSending"
        Me.rdSending.Size = New System.Drawing.Size(73, 18)
        Me.rdSending.TabIndex = 0
        Me.rdSending.TabStop = True
        Me.rdSending.Text = "SENDING"
        Me.rdSending.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.ImageList = Me.ImageList1
        Me.Button2.Location = New System.Drawing.Point(201, 463)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(71, 32)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "CANCEL"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8-close-window-100.png")
        Me.ImageList1.Images.SetKeyName(1, "icons8-save-all-100.png")
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Gold
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.ImageList = Me.ImageList1
        Me.Button3.Location = New System.Drawing.Point(105, 463)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(90, 32)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "GENERATE"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.rdNONNego)
        Me.GroupBox5.Controls.Add(Me.rdOBL)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 358)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(260, 48)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "FORM TYPE"
        '
        'rdNONNego
        '
        Me.rdNONNego.AutoSize = True
        Me.rdNONNego.Checked = True
        Me.rdNONNego.Location = New System.Drawing.Point(106, 21)
        Me.rdNONNego.Name = "rdNONNego"
        Me.rdNONNego.Size = New System.Drawing.Size(83, 18)
        Me.rdNONNego.TabIndex = 1
        Me.rdNONNego.TabStop = True
        Me.rdNONNego.Text = "NON-NEGO"
        Me.rdNONNego.UseVisualStyleBackColor = True
        '
        'rdOBL
        '
        Me.rdOBL.AutoSize = True
        Me.rdOBL.Location = New System.Drawing.Point(27, 21)
        Me.rdOBL.Name = "rdOBL"
        Me.rdOBL.Size = New System.Drawing.Size(45, 18)
        Me.rdOBL.TabIndex = 0
        Me.rdOBL.Text = "OBL"
        Me.rdOBL.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdFSM)
        Me.GroupBox4.Controls.Add(Me.rdWesPac)
        Me.GroupBox4.Controls.Add(Me.rdKyowaNew)
        Me.GroupBox4.Controls.Add(Me.rdKyowaOld)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 262)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(260, 93)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "FORMS"
        '
        'rdFSM
        '
        Me.rdFSM.AutoSize = True
        Me.rdFSM.Location = New System.Drawing.Point(27, 67)
        Me.rdFSM.Name = "rdFSM"
        Me.rdFSM.Size = New System.Drawing.Size(47, 18)
        Me.rdFSM.TabIndex = 9
        Me.rdFSM.Text = "FSM"
        Me.rdFSM.UseVisualStyleBackColor = True
        '
        'rdWesPac
        '
        Me.rdWesPac.AutoSize = True
        Me.rdWesPac.Location = New System.Drawing.Point(27, 45)
        Me.rdWesPac.Name = "rdWesPac"
        Me.rdWesPac.Size = New System.Drawing.Size(107, 18)
        Me.rdWesPac.TabIndex = 8
        Me.rdWesPac.Text = "Western Pacific"
        Me.rdWesPac.UseVisualStyleBackColor = True
        '
        'rdKyowaNew
        '
        Me.rdKyowaNew.AutoSize = True
        Me.rdKyowaNew.Checked = True
        Me.rdKyowaNew.Location = New System.Drawing.Point(27, 21)
        Me.rdKyowaNew.Name = "rdKyowaNew"
        Me.rdKyowaNew.Size = New System.Drawing.Size(74, 18)
        Me.rdKyowaNew.TabIndex = 7
        Me.rdKyowaNew.TabStop = True
        Me.rdKyowaNew.Text = "Kyowa BL"
        Me.rdKyowaNew.UseVisualStyleBackColor = True
        '
        'rdKyowaOld
        '
        Me.rdKyowaOld.AutoSize = True
        Me.rdKyowaOld.Location = New System.Drawing.Point(164, 14)
        Me.rdKyowaOld.Name = "rdKyowaOld"
        Me.rdKyowaOld.Size = New System.Drawing.Size(91, 18)
        Me.rdKyowaOld.TabIndex = 6
        Me.rdKyowaOld.Text = "Kyowa (OLD)"
        Me.rdKyowaOld.UseVisualStyleBackColor = True
        Me.rdKyowaOld.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdUnfreighted)
        Me.GroupBox3.Controls.Add(Me.rdBilling)
        Me.GroupBox3.Controls.Add(Me.rdDestination)
        Me.GroupBox3.Controls.Add(Me.rdPrincipal)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 140)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(260, 115)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "CHARGES"
        '
        'rdUnfreighted
        '
        Me.rdUnfreighted.AutoSize = True
        Me.rdUnfreighted.Location = New System.Drawing.Point(27, 91)
        Me.rdUnfreighted.Name = "rdUnfreighted"
        Me.rdUnfreighted.Size = New System.Drawing.Size(92, 18)
        Me.rdUnfreighted.TabIndex = 5
        Me.rdUnfreighted.Text = "UnFreighted"
        Me.rdUnfreighted.UseVisualStyleBackColor = True
        '
        'rdBilling
        '
        Me.rdBilling.AutoSize = True
        Me.rdBilling.Location = New System.Drawing.Point(27, 69)
        Me.rdBilling.Name = "rdBilling"
        Me.rdBilling.Size = New System.Drawing.Size(81, 18)
        Me.rdBilling.TabIndex = 4
        Me.rdBilling.Text = "For Billing"
        Me.rdBilling.UseVisualStyleBackColor = True
        '
        'rdDestination
        '
        Me.rdDestination.AutoSize = True
        Me.rdDestination.Location = New System.Drawing.Point(27, 45)
        Me.rdDestination.Name = "rdDestination"
        Me.rdDestination.Size = New System.Drawing.Size(108, 18)
        Me.rdDestination.TabIndex = 3
        Me.rdDestination.Text = "For Destination"
        Me.rdDestination.UseVisualStyleBackColor = True
        '
        'rdPrincipal
        '
        Me.rdPrincipal.AutoSize = True
        Me.rdPrincipal.Checked = True
        Me.rdPrincipal.Location = New System.Drawing.Point(27, 21)
        Me.rdPrincipal.Name = "rdPrincipal"
        Me.rdPrincipal.Size = New System.Drawing.Size(93, 18)
        Me.rdPrincipal.TabIndex = 2
        Me.rdPrincipal.TabStop = True
        Me.rdPrincipal.Text = "For Principal"
        Me.rdPrincipal.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdCyCfs)
        Me.GroupBox2.Controls.Add(Me.rdCfsCfs)
        Me.GroupBox2.Controls.Add(Me.rdCyCy)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(260, 87)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PORT"
        '
        'rdCyCfs
        '
        Me.rdCyCfs.AutoSize = True
        Me.rdCyCfs.Location = New System.Drawing.Point(27, 65)
        Me.rdCyCfs.Name = "rdCyCfs"
        Me.rdCyCfs.Size = New System.Drawing.Size(93, 18)
        Me.rdCyCfs.TabIndex = 3
        Me.rdCyCfs.Text = "CY - CFS - CFS"
        Me.rdCyCfs.UseVisualStyleBackColor = True
        '
        'rdCfsCfs
        '
        Me.rdCfsCfs.AutoSize = True
        Me.rdCfsCfs.Location = New System.Drawing.Point(27, 41)
        Me.rdCfsCfs.Name = "rdCfsCfs"
        Me.rdCfsCfs.Size = New System.Drawing.Size(99, 18)
        Me.rdCfsCfs.TabIndex = 2
        Me.rdCfsCfs.Text = "CFS - CFS - CFS"
        Me.rdCfsCfs.UseVisualStyleBackColor = True
        '
        'rdCyCy
        '
        Me.rdCyCy.AutoSize = True
        Me.rdCyCy.Checked = True
        Me.rdCyCy.Location = New System.Drawing.Point(27, 17)
        Me.rdCyCy.Name = "rdCyCy"
        Me.rdCyCy.Size = New System.Drawing.Size(81, 18)
        Me.rdCyCy.TabIndex = 1
        Me.rdCyCy.TabStop = True
        Me.rdCyCy.Text = "CY - CY - CY"
        Me.rdCyCy.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdRider)
        Me.GroupBox1.Controls.Add(Me.rdBL)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(260, 39)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TYPE"
        '
        'rdRider
        '
        Me.rdRider.AutoSize = True
        Me.rdRider.Location = New System.Drawing.Point(86, 17)
        Me.rdRider.Name = "rdRider"
        Me.rdRider.Size = New System.Drawing.Size(57, 18)
        Me.rdRider.TabIndex = 1
        Me.rdRider.Text = "RIDER"
        Me.rdRider.UseVisualStyleBackColor = True
        '
        'rdBL
        '
        Me.rdBL.AutoSize = True
        Me.rdBL.Checked = True
        Me.rdBL.Location = New System.Drawing.Point(27, 17)
        Me.rdBL.Name = "rdBL"
        Me.rdBL.Size = New System.Drawing.Size(42, 18)
        Me.rdBL.TabIndex = 0
        Me.rdBL.TabStop = True
        Me.rdBL.Text = "B/L"
        Me.rdBL.UseVisualStyleBackColor = True
        '
        'FrmGenerateBlMenus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 500)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmGenerateBlMenus"
        Me.Text = "FrmGenerateBlMenus"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents rdNONNego As RadioButton
    Friend WithEvents rdOBL As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents rdFSM As RadioButton
    Friend WithEvents rdWesPac As RadioButton
    Friend WithEvents rdKyowaNew As RadioButton
    Friend WithEvents rdKyowaOld As RadioButton
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents rdUnfreighted As RadioButton
    Friend WithEvents rdBilling As RadioButton
    Friend WithEvents rdDestination As RadioButton
    Friend WithEvents rdPrincipal As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rdCyCfs As RadioButton
    Friend WithEvents rdCfsCfs As RadioButton
    Friend WithEvents rdCyCy As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rdRider As RadioButton
    Friend WithEvents rdBL As RadioButton
    Friend WithEvents Button2 As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents rdPrinting As RadioButton
    Friend WithEvents rdSending As RadioButton
End Class
