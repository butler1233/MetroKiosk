<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class alertdialog
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cancelbutton = New System.Windows.Forms.Label()
        Me.alerttext = New System.Windows.Forms.Label()
        Me.alerttitle = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.alerttext)
        Me.Panel1.Location = New System.Drawing.Point(2, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(482, 155)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Location = New System.Drawing.Point(0, 97)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(482, 58)
        Me.Panel2.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGray
        Me.Panel4.Controls.Add(Me.cancelbutton)
        Me.Panel4.Location = New System.Drawing.Point(337, 8)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(136, 40)
        Me.Panel4.TabIndex = 6
        '
        'cancelbutton
        '
        Me.cancelbutton.Font = New System.Drawing.Font("Segoe UI Light", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelbutton.ForeColor = System.Drawing.Color.White
        Me.cancelbutton.Location = New System.Drawing.Point(8, 8)
        Me.cancelbutton.Name = "cancelbutton"
        Me.cancelbutton.Size = New System.Drawing.Size(121, 25)
        Me.cancelbutton.TabIndex = 3
        Me.cancelbutton.Text = "Okay"
        Me.cancelbutton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'alerttext
        '
        Me.alerttext.Font = New System.Drawing.Font("Segoe UI Light", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.alerttext.ForeColor = System.Drawing.Color.Black
        Me.alerttext.Location = New System.Drawing.Point(10, 11)
        Me.alerttext.Name = "alerttext"
        Me.alerttext.Size = New System.Drawing.Size(463, 83)
        Me.alerttext.TabIndex = 3
        Me.alerttext.Text = "AlertText"
        Me.alerttext.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'alerttitle
        '
        Me.alerttitle.AutoSize = True
        Me.alerttitle.Font = New System.Drawing.Font("Segoe UI Light", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.alerttitle.ForeColor = System.Drawing.Color.White
        Me.alerttitle.Location = New System.Drawing.Point(1, 2)
        Me.alerttitle.Name = "alerttitle"
        Me.alerttitle.Size = New System.Drawing.Size(51, 25)
        Me.alerttitle.TabIndex = 2
        Me.alerttitle.Text = "Error"
        '
        'alertdialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Tomato
        Me.ClientSize = New System.Drawing.Size(487, 186)
        Me.Controls.Add(Me.alerttitle)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "alertdialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Confirm cancellation"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Shadows WithEvents cancelbutton As System.Windows.Forms.Label
    Friend WithEvents alerttext As System.Windows.Forms.Label
    Friend WithEvents alerttitle As System.Windows.Forms.Label

End Class
