<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChargesTemplates
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtList = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmbTrade = New System.Windows.Forms.ComboBox()
        Me.cmbSubTrade = New System.Windows.Forms.ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.dtList)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(623, 440)
        Me.Panel1.TabIndex = 2
        '
        'dtList
        '
        Me.dtList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtList.Location = New System.Drawing.Point(12, 128)
        Me.dtList.Name = "dtList"
        Me.dtList.Size = New System.Drawing.Size(599, 300)
        Me.dtList.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cmbTrade)
        Me.Panel2.Controls.Add(Me.cmbSubTrade)
        Me.Panel2.Controls.Add(Me.Label34)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(12, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(599, 56)
        Me.Panel2.TabIndex = 0
        '
        'cmbTrade
        '
        Me.cmbTrade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTrade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbTrade.BackColor = System.Drawing.SystemColors.Info
        Me.cmbTrade.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTrade.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cmbTrade.FormattingEnabled = True
        Me.cmbTrade.Location = New System.Drawing.Point(86, 6)
        Me.cmbTrade.Name = "cmbTrade"
        Me.cmbTrade.Size = New System.Drawing.Size(345, 22)
        Me.cmbTrade.TabIndex = 49
        '
        'cmbSubTrade
        '
        Me.cmbSubTrade.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbSubTrade.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbSubTrade.BackColor = System.Drawing.SystemColors.Info
        Me.cmbSubTrade.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSubTrade.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.cmbSubTrade.FormattingEnabled = True
        Me.cmbSubTrade.Location = New System.Drawing.Point(116, 27)
        Me.cmbSubTrade.Name = "cmbSubTrade"
        Me.cmbSubTrade.Size = New System.Drawing.Size(345, 22)
        Me.cmbSubTrade.TabIndex = 50
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(101, 32)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(15, 18)
        Me.Label34.TabIndex = 52
        Me.Label34.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DESTINATION:"
        '
        'FrmChargesTemplates
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(623, 440)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmChargesTemplates"
        Me.Text = "FrmChargesTemplates"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dtList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dtList As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbTrade As ComboBox
    Friend WithEvents cmbSubTrade As ComboBox
    Friend WithEvents Label34 As Label
End Class
