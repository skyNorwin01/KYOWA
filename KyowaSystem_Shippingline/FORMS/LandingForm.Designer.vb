<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LandingForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LandingForm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnEapproval = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnLogged = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pnlNotify = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.LBLUPDATE = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.btnBookingList = New System.Windows.Forms.Button()
        Me.btnInitialBookingLcl = New System.Windows.Forms.Button()
        Me.btbInitialBookingFcl = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.timerPanelNotif = New System.Windows.Forms.Timer(Me.components)
        Me.cmsUsers = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNotify.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsUsers.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btnEapproval)
        Me.Panel1.Controls.Add(Me.btnLogged)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.pnlNotify)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.btnBookingList)
        Me.Panel1.Controls.Add(Me.btnInitialBookingLcl)
        Me.Panel1.Controls.Add(Me.btbInitialBookingFcl)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(808, 226)
        Me.Panel1.TabIndex = 2
        '
        'btnEapproval
        '
        Me.btnEapproval.BackColor = System.Drawing.Color.White
        Me.btnEapproval.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEapproval.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEapproval.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEapproval.ImageIndex = 8
        Me.btnEapproval.ImageList = Me.ImageList1
        Me.btnEapproval.Location = New System.Drawing.Point(495, 135)
        Me.btnEapproval.Name = "btnEapproval"
        Me.btnEapproval.Size = New System.Drawing.Size(156, 52)
        Me.btnEapproval.TabIndex = 78
        Me.btnEapproval.Text = "E - A p p r o v a l"
        Me.btnEapproval.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEapproval.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8-street-view-100.png")
        Me.ImageList1.Images.SetKeyName(1, "icons8-graph-report-100.png")
        Me.ImageList1.Images.SetKeyName(2, "icons8-truck-100.png")
        Me.ImageList1.Images.SetKeyName(3, "icons8-water-transportation-100.png")
        Me.ImageList1.Images.SetKeyName(4, "icons8-wharf-100 (4).png")
        Me.ImageList1.Images.SetKeyName(5, "icons8-todo-list-100.png")
        Me.ImageList1.Images.SetKeyName(6, "icons8-network-100 (2).png")
        Me.ImageList1.Images.SetKeyName(7, "icons8-semi-truck-100.png")
        Me.ImageList1.Images.SetKeyName(8, "icons8-renewable-energy-100.png")
        '
        'btnLogged
        '
        Me.btnLogged.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogged.AutoSize = True
        Me.btnLogged.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogged.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogged.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogged.ImageIndex = 0
        Me.btnLogged.ImageList = Me.ImageList2
        Me.btnLogged.Location = New System.Drawing.Point(777, 1)
        Me.btnLogged.Name = "btnLogged"
        Me.btnLogged.Size = New System.Drawing.Size(32, 32)
        Me.btnLogged.TabIndex = 14
        Me.btnLogged.UseVisualStyleBackColor = True
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "icons8-contacts-100.png")
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(111, 26)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(100, 96)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 75
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(595, 78)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(27, 35)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 77
        Me.PictureBox2.TabStop = False
        '
        'pnlNotify
        '
        Me.pnlNotify.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlNotify.BackColor = System.Drawing.Color.DimGray
        Me.pnlNotify.Controls.Add(Me.PictureBox5)
        Me.pnlNotify.Controls.Add(Me.LBLUPDATE)
        Me.pnlNotify.Controls.Add(Me.Label5)
        Me.pnlNotify.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlNotify.Location = New System.Drawing.Point(242, 0)
        Me.pnlNotify.Name = "pnlNotify"
        Me.pnlNotify.Size = New System.Drawing.Size(372, 44)
        Me.pnlNotify.TabIndex = 67
        Me.pnlNotify.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(5, 7)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(29, 28)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 2
        Me.PictureBox5.TabStop = False
        '
        'LBLUPDATE
        '
        Me.LBLUPDATE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLUPDATE.ForeColor = System.Drawing.Color.White
        Me.LBLUPDATE.Location = New System.Drawing.Point(40, 3)
        Me.LBLUPDATE.Name = "LBLUPDATE"
        Me.LBLUPDATE.Size = New System.Drawing.Size(295, 34)
        Me.LBLUPDATE.TabIndex = 1
        Me.LBLUPDATE.Text = "An update is available. Would you like to update the application now?"
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Crimson
        Me.Label5.Location = New System.Drawing.Point(351, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "X"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SlateGray
        Me.Label1.Location = New System.Drawing.Point(0, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(810, 53)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "KYOWA LINE"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Britannic Bold", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(213, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(387, 53)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "INHOUSE SYSTEM"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.Font = New System.Drawing.Font("Calibri Light", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Blue
        Me.LinkLabel1.Location = New System.Drawing.Point(0, 202)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(810, 24)
        Me.LinkLabel1.TabIndex = 70
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Read system updates"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnBookingList
        '
        Me.btnBookingList.BackColor = System.Drawing.Color.White
        Me.btnBookingList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBookingList.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBookingList.Location = New System.Drawing.Point(12, 395)
        Me.btnBookingList.Name = "btnBookingList"
        Me.btnBookingList.Size = New System.Drawing.Size(184, 57)
        Me.btnBookingList.TabIndex = 4
        Me.btnBookingList.Text = "BOOKING LIST"
        Me.btnBookingList.UseVisualStyleBackColor = False
        Me.btnBookingList.Visible = False
        '
        'btnInitialBookingLcl
        '
        Me.btnInitialBookingLcl.BackColor = System.Drawing.Color.White
        Me.btnInitialBookingLcl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInitialBookingLcl.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInitialBookingLcl.Location = New System.Drawing.Point(12, 332)
        Me.btnInitialBookingLcl.Name = "btnInitialBookingLcl"
        Me.btnInitialBookingLcl.Size = New System.Drawing.Size(184, 57)
        Me.btnInitialBookingLcl.TabIndex = 3
        Me.btnInitialBookingLcl.Text = "INITIAL BOOKING - LCL"
        Me.btnInitialBookingLcl.UseVisualStyleBackColor = False
        Me.btnInitialBookingLcl.Visible = False
        '
        'btbInitialBookingFcl
        '
        Me.btbInitialBookingFcl.BackColor = System.Drawing.Color.White
        Me.btbInitialBookingFcl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btbInitialBookingFcl.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btbInitialBookingFcl.Location = New System.Drawing.Point(12, 269)
        Me.btbInitialBookingFcl.Name = "btbInitialBookingFcl"
        Me.btbInitialBookingFcl.Size = New System.Drawing.Size(184, 57)
        Me.btbInitialBookingFcl.TabIndex = 2
        Me.btbInitialBookingFcl.Text = "INITIAL BOOKING - FCL"
        Me.btbInitialBookingFcl.UseVisualStyleBackColor = False
        Me.btbInitialBookingFcl.Visible = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.ImageIndex = 3
        Me.Button2.ImageList = Me.ImageList1
        Me.Button2.Location = New System.Drawing.Point(336, 135)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(147, 52)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "E x p o r t"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImageIndex = 4
        Me.Button1.ImageList = Me.ImageList1
        Me.Button1.Location = New System.Drawing.Point(177, 135)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(147, 52)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "I m p o r t"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'timerPanelNotif
        '
        Me.timerPanelNotif.Enabled = True
        '
        'cmsUsers
        '
        Me.cmsUsers.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmsUsers.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoutToolStripMenuItem})
        Me.cmsUsers.Name = "cmsUsers"
        Me.cmsUsers.Size = New System.Drawing.Size(123, 28)
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(122, 24)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'LandingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 226)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "LandingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LandingForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNotify.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsUsers.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnInitialBookingLcl As Button
    Friend WithEvents btbInitialBookingFcl As Button
    Friend WithEvents btnBookingList As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents pnlNotify As Panel
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents LBLUPDATE As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents timerPanelNotif As Timer
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents btnLogged As Button
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents cmsUsers As ContextMenuStrip
    Friend WithEvents LogoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnEapproval As Button
End Class
