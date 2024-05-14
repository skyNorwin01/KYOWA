<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEApprovalMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEApprovalMenu))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.aPDFMain = New AxAcroPDFLib.AxAcroPDF()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.aPDFSupp = New AxAcroPDFLib.AxAcroPDF()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ChkManualSignOfChecker = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rd2 = New System.Windows.Forms.RadioButton()
        Me.rd1 = New System.Windows.Forms.RadioButton()
        Me.cmbRequestTo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbParticular = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNoteManifest = New System.Windows.Forms.TextBox()
        Me.dtManifest = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSendEManifest = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.DTrfp = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSendRequest = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.aPDFMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.aPDFSupp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dtManifest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DTrfp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.TabControl2)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1013, 520)
        Me.Panel1.TabIndex = 2
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage3)
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Location = New System.Drawing.Point(13, 12)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(549, 508)
        Me.TabControl2.TabIndex = 8
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button4)
        Me.TabPage3.Controls.Add(Me.btnSelect)
        Me.TabPage3.Controls.Add(Me.aPDFMain)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(541, 481)
        Me.TabPage3.TabIndex = 0
        Me.TabPage3.Text = "MAIN"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.Red
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(420, 450)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(118, 29)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "REMOVE"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'btnSelect
        '
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelect.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelect.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.ForeColor = System.Drawing.Color.White
        Me.btnSelect.Location = New System.Drawing.Point(2, 450)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(421, 29)
        Me.btnSelect.TabIndex = 5
        Me.btnSelect.Text = "UPLOAD MAIN (PDF)"
        Me.btnSelect.UseVisualStyleBackColor = False
        '
        'aPDFMain
        '
        Me.aPDFMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.aPDFMain.Enabled = True
        Me.aPDFMain.Location = New System.Drawing.Point(3, 3)
        Me.aPDFMain.Name = "aPDFMain"
        Me.aPDFMain.OcxState = CType(resources.GetObject("aPDFMain.OcxState"), System.Windows.Forms.AxHost.State)
        Me.aPDFMain.Size = New System.Drawing.Size(535, 447)
        Me.aPDFMain.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Button5)
        Me.TabPage4.Controls.Add(Me.Button3)
        Me.TabPage4.Controls.Add(Me.aPDFSupp)
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(541, 481)
        Me.TabPage4.TabIndex = 1
        Me.TabPage4.Text = "SUPPORTING DOCS"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button5.BackColor = System.Drawing.Color.Red
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(421, 450)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(118, 29)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "REMOVE"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(1, 450)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(421, 29)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "UPLOAD SUPPORTING DOCS (PDF)"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'aPDFSupp
        '
        Me.aPDFSupp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.aPDFSupp.Enabled = True
        Me.aPDFSupp.Location = New System.Drawing.Point(1, 1)
        Me.aPDFSupp.Name = "aPDFSupp"
        Me.aPDFSupp.OcxState = CType(resources.GetObject("aPDFSupp.OcxState"), System.Windows.Forms.AxHost.State)
        Me.aPDFSupp.Size = New System.Drawing.Size(535, 450)
        Me.aPDFSupp.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ChkManualSignOfChecker)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.rd2)
        Me.Panel2.Controls.Add(Me.rd1)
        Me.Panel2.Controls.Add(Me.cmbRequestTo)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cmbParticular)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(568, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(442, 115)
        Me.Panel2.TabIndex = 7
        '
        'ChkManualSignOfChecker
        '
        Me.ChkManualSignOfChecker.AutoSize = True
        Me.ChkManualSignOfChecker.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkManualSignOfChecker.Location = New System.Drawing.Point(7, 92)
        Me.ChkManualSignOfChecker.Name = "ChkManualSignOfChecker"
        Me.ChkManualSignOfChecker.Size = New System.Drawing.Size(238, 23)
        Me.ChkManualSignOfChecker.TabIndex = 40
        Me.ChkManualSignOfChecker.Text = "MANUAL SIGNING OF CHECKER"
        Me.ChkManualSignOfChecker.UseVisualStyleBackColor = True
        Me.ChkManualSignOfChecker.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(-1, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(445, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "URGENT LEVEL / OPTION"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rd2
        '
        Me.rd2.AutoSize = True
        Me.rd2.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd2.Location = New System.Drawing.Point(354, 91)
        Me.rd2.Name = "rd2"
        Me.rd2.Size = New System.Drawing.Size(83, 23)
        Me.rd2.TabIndex = 8
        Me.rd2.Text = "URGENT"
        Me.rd2.UseVisualStyleBackColor = True
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.Checked = True
        Me.rd1.Font = New System.Drawing.Font("Calibri", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd1.Location = New System.Drawing.Point(258, 91)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(90, 23)
        Me.rd1.TabIndex = 6
        Me.rd1.TabStop = True
        Me.rd1.Text = "REGULAR"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'cmbRequestTo
        '
        Me.cmbRequestTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbRequestTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbRequestTo.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRequestTo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cmbRequestTo.FormattingEnabled = True
        Me.cmbRequestTo.Location = New System.Drawing.Point(110, 40)
        Me.cmbRequestTo.Name = "cmbRequestTo"
        Me.cmbRequestTo.Size = New System.Drawing.Size(322, 27)
        Me.cmbRequestTo.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 21)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "REQUEST TO"
        '
        'cmbParticular
        '
        Me.cmbParticular.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbParticular.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbParticular.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbParticular.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cmbParticular.FormattingEnabled = True
        Me.cmbParticular.Location = New System.Drawing.Point(110, 3)
        Me.cmbParticular.Name = "cmbParticular"
        Me.cmbParticular.Size = New System.Drawing.Size(322, 31)
        Me.cmbParticular.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 21)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "PARTICULAR"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(568, 133)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(442, 381)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtNoteManifest)
        Me.TabPage1.Controls.Add(Me.dtManifest)
        Me.TabPage1.Controls.Add(Me.btnSendEManifest)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(434, 354)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "MANIFEST"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 14)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "INVOICE/BSNO:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(95, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(332, 22)
        Me.TextBox1.TabIndex = 41
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 197)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 21)
        Me.Label7.TabIndex = 40
        Me.Label7.Text = "Email content"
        '
        'txtNoteManifest
        '
        Me.txtNoteManifest.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNoteManifest.Location = New System.Drawing.Point(6, 216)
        Me.txtNoteManifest.Multiline = True
        Me.txtNoteManifest.Name = "txtNoteManifest"
        Me.txtNoteManifest.Size = New System.Drawing.Size(422, 97)
        Me.txtNoteManifest.TabIndex = 39
        '
        'dtManifest
        '
        Me.dtManifest.AllowUserToAddRows = False
        Me.dtManifest.AllowUserToDeleteRows = False
        Me.dtManifest.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtManifest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtManifest.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.Column4})
        Me.dtManifest.Location = New System.Drawing.Point(6, 27)
        Me.dtManifest.Name = "dtManifest"
        Me.dtManifest.ReadOnly = True
        Me.dtManifest.Size = New System.Drawing.Size(421, 183)
        Me.dtManifest.TabIndex = 37
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "MV"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 250
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "VY"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "DEST"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 150
        '
        'Column4
        '
        Me.Column4.HeaderText = "SYSREF"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'btnSendEManifest
        '
        Me.btnSendEManifest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSendEManifest.BackColor = System.Drawing.Color.Gold
        Me.btnSendEManifest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSendEManifest.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendEManifest.ForeColor = System.Drawing.Color.Black
        Me.btnSendEManifest.Location = New System.Drawing.Point(6, 319)
        Me.btnSendEManifest.Name = "btnSendEManifest"
        Me.btnSendEManifest.Size = New System.Drawing.Size(160, 29)
        Me.btnSendEManifest.TabIndex = 38
        Me.btnSendEManifest.Text = "SEND REQUEST"
        Me.btnSendEManifest.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txtSearch)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.txtNote)
        Me.TabPage2.Controls.Add(Me.DTrfp)
        Me.TabPage2.Controls.Add(Me.btnSendRequest)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(434, 354)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "REQUEST FOR PAYMENT"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 14)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "INVOICE/BSNO:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(95, 3)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(332, 22)
        Me.txtSearch.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 21)
        Me.Label3.TabIndex = 34
        Me.Label3.Text = "Email content"
        '
        'txtNote
        '
        Me.txtNote.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtNote.Location = New System.Drawing.Point(6, 216)
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(422, 97)
        Me.txtNote.TabIndex = 33
        '
        'DTrfp
        '
        Me.DTrfp.AllowUserToAddRows = False
        Me.DTrfp.AllowUserToDeleteRows = False
        Me.DTrfp.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DTrfp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTrfp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.DTrfp.Location = New System.Drawing.Point(6, 27)
        Me.DTrfp.Name = "DTrfp"
        Me.DTrfp.ReadOnly = True
        Me.DTrfp.Size = New System.Drawing.Size(421, 183)
        Me.DTrfp.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "INVOICE/BSNO"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Infavor of"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 250
        '
        'Column3
        '
        Me.Column3.HeaderText = "SERIES"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'btnSendRequest
        '
        Me.btnSendRequest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSendRequest.BackColor = System.Drawing.Color.Gold
        Me.btnSendRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSendRequest.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSendRequest.ForeColor = System.Drawing.Color.Black
        Me.btnSendRequest.Location = New System.Drawing.Point(6, 319)
        Me.btnSendRequest.Name = "btnSendRequest"
        Me.btnSendRequest.Size = New System.Drawing.Size(160, 29)
        Me.btnSendRequest.TabIndex = 9
        Me.btnSendRequest.Text = "SEND REQUEST"
        Me.btnSendRequest.UseVisualStyleBackColor = False
        '
        'FrmEApprovalMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 520)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmEApprovalMenu"
        Me.Text = "FrmEApprovalMenu"
        Me.Panel1.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.aPDFMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.aPDFSupp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dtManifest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DTrfp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbParticular As ComboBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents DTrfp As DataGridView
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSelect As Button
    Friend WithEvents aPDFMain As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents Button3 As Button
    Friend WithEvents aPDFSupp As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents rd2 As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents rd1 As RadioButton
    Friend WithEvents cmbRequestTo As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSendRequest As Button
    Friend WithEvents ChkManualSignOfChecker As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtNote As TextBox
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNoteManifest As TextBox
    Friend WithEvents dtManifest As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents btnSendEManifest As Button
End Class
