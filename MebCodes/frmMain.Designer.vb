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
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.WebBrowser2 = New System.Windows.Forms.WebBrowser()
        Me.WebBrowser3 = New System.Windows.Forms.WebBrowser()
        Me.lblUrl1 = New System.Windows.Forms.Label()
        Me.lblUrl2 = New System.Windows.Forms.Label()
        Me.lblUrl3 = New System.Windows.Forms.Label()
        Me.txtLists = New System.Windows.Forms.TextBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(12, 36)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.Size = New System.Drawing.Size(866, 185)
        Me.WebBrowser1.TabIndex = 0
        '
        'WebBrowser2
        '
        Me.WebBrowser2.Location = New System.Drawing.Point(12, 257)
        Me.WebBrowser2.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser2.Name = "WebBrowser2"
        Me.WebBrowser2.Size = New System.Drawing.Size(866, 185)
        Me.WebBrowser2.TabIndex = 1
        '
        'WebBrowser3
        '
        Me.WebBrowser3.Location = New System.Drawing.Point(12, 468)
        Me.WebBrowser3.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser3.Name = "WebBrowser3"
        Me.WebBrowser3.Size = New System.Drawing.Size(866, 185)
        Me.WebBrowser3.TabIndex = 2
        '
        'lblUrl1
        '
        Me.lblUrl1.AutoSize = True
        Me.lblUrl1.Location = New System.Drawing.Point(12, 20)
        Me.lblUrl1.Name = "lblUrl1"
        Me.lblUrl1.Size = New System.Drawing.Size(389, 13)
        Me.lblUrl1.TabIndex = 3
        Me.lblUrl1.Text = "http://www.meb.gov.tr/baglantilar/okullar/?ILKODU=1&ILCEKODU=&SAYFANO=1"
        '
        'lblUrl2
        '
        Me.lblUrl2.AutoSize = True
        Me.lblUrl2.Location = New System.Drawing.Point(12, 241)
        Me.lblUrl2.Name = "lblUrl2"
        Me.lblUrl2.Size = New System.Drawing.Size(209, 13)
        Me.lblUrl2.TabIndex = 4
        Me.lblUrl2.Text = "http://www.meb.gov.tr/baglantilar/okullar/"
        '
        'lblUrl3
        '
        Me.lblUrl3.AutoSize = True
        Me.lblUrl3.Location = New System.Drawing.Point(12, 452)
        Me.lblUrl3.Name = "lblUrl3"
        Me.lblUrl3.Size = New System.Drawing.Size(209, 13)
        Me.lblUrl3.TabIndex = 5
        Me.lblUrl3.Text = "http://www.meb.gov.tr/baglantilar/okullar/"
        '
        'txtLists
        '
        Me.txtLists.Location = New System.Drawing.Point(884, 74)
        Me.txtLists.Multiline = True
        Me.txtLists.Name = "txtLists"
        Me.txtLists.Size = New System.Drawing.Size(280, 579)
        Me.txtLists.TabIndex = 6
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(884, 36)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 7
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1211, 665)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.txtLists)
        Me.Controls.Add(Me.lblUrl3)
        Me.Controls.Add(Me.lblUrl2)
        Me.Controls.Add(Me.lblUrl1)
        Me.Controls.Add(Me.WebBrowser3)
        Me.Controls.Add(Me.WebBrowser2)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Name = "frmMain"
        Me.ShowIcon = False
        Me.Text = "MEB Codes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents WebBrowser2 As WebBrowser
    Friend WithEvents WebBrowser3 As WebBrowser
    Friend WithEvents lblUrl1 As Label
    Friend WithEvents lblUrl2 As Label
    Friend WithEvents lblUrl3 As Label
    Friend WithEvents txtLists As TextBox
    Friend WithEvents btnNext As Button
End Class
