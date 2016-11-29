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
        Me.lblUrl1 = New System.Windows.Forms.Label()
        Me.txtLists = New System.Windows.Forms.TextBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Browser
        '
        Me.Browser.Location = New System.Drawing.Point(15, 25)
        Me.Browser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.Browser.Name = "Browser"
        Me.Browser.ScriptErrorsSuppressed = True
        Me.Browser.Size = New System.Drawing.Size(863, 628)
        Me.Browser.TabIndex = 0
        '
        'lblUrl1
        '
        Me.lblUrl1.AutoSize = True
        Me.lblUrl1.Location = New System.Drawing.Point(12, 9)
        Me.lblUrl1.Name = "lblUrl1"
        Me.lblUrl1.Size = New System.Drawing.Size(10, 13)
        Me.lblUrl1.TabIndex = 3
        Me.lblUrl1.Text = "-"
        '
        'txtLists
        '
        Me.txtLists.Location = New System.Drawing.Point(884, 54)
        Me.txtLists.Multiline = True
        Me.txtLists.Name = "txtLists"
        Me.txtLists.Size = New System.Drawing.Size(280, 599)
        Me.txtLists.TabIndex = 6
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(884, 25)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(134, 23)
        Me.btnStart.TabIndex = 9
        Me.btnStart.Text = "Start Insert"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(1030, 25)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(134, 23)
        Me.btnUpdate.TabIndex = 10
        Me.btnUpdate.Text = "Start Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1173, 665)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.Browser)
        Me.Controls.Add(Me.txtLists)
        Me.Controls.Add(Me.lblUrl1)
        Me.Name = "frmMain"
        Me.ShowIcon = False
        Me.Text = "MEB Codes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Browser As WebBrowser
    Friend WithEvents lblUrl1 As Label
    Friend WithEvents txtLists As TextBox
    Friend WithEvents btnStart As Button
    Friend WithEvents btnUpdate As Button
End Class
