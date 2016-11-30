<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.Browser = New System.Windows.Forms.WebBrowser()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.lblUrl = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblMiladi = New System.Windows.Forms.Label()
        Me.lblHicri = New System.Windows.Forms.Label()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Browser
        '
        Me.Browser.Location = New System.Drawing.Point(15, 79)
        Me.Browser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Browser.Name = "Browser"
        Me.Browser.Size = New System.Drawing.Size(777, 451)
        Me.Browser.TabIndex = 0
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Location = New System.Drawing.Point(15, 536)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(777, 179)
        Me.dgv.TabIndex = 1
        '
        'lblUrl
        '
        Me.lblUrl.AutoSize = True
        Me.lblUrl.Location = New System.Drawing.Point(12, 60)
        Me.lblUrl.Name = "lblUrl"
        Me.lblUrl.Size = New System.Drawing.Size(18, 13)
        Me.lblUrl.TabIndex = 2
        Me.lblUrl.Text = "url"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Miladi"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Hicri"
        '
        'lblMiladi
        '
        Me.lblMiladi.AutoSize = True
        Me.lblMiladi.Location = New System.Drawing.Point(89, 9)
        Me.lblMiladi.Name = "lblMiladi"
        Me.lblMiladi.Size = New System.Drawing.Size(27, 13)
        Me.lblMiladi.TabIndex = 5
        Me.lblMiladi.Text = "tarih"
        '
        'lblHicri
        '
        Me.lblHicri.AutoSize = True
        Me.lblHicri.Location = New System.Drawing.Point(89, 31)
        Me.lblHicri.Name = "lblHicri"
        Me.lblHicri.Size = New System.Drawing.Size(27, 13)
        Me.lblHicri.TabIndex = 6
        Me.lblHicri.Text = "tarih"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(826, 748)
        Me.Controls.Add(Me.lblHicri)
        Me.Controls.Add(Me.lblMiladi)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblUrl)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Browser)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.ShowIcon = False
        Me.Text = "Namaz Vaktim"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Browser As System.Windows.Forms.WebBrowser
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents lblUrl As System.Windows.Forms.Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblMiladi As Label
    Friend WithEvents lblHicri As Label
End Class
