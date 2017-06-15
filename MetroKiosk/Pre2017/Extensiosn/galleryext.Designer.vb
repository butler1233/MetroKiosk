<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class galleryext
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
        Me.Panel35 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.preprog = New System.Windows.Forms.Label()
        Me.Panel35.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel35
        '
        Me.Panel35.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Panel35.Controls.Add(Me.Label2)
        Me.Panel35.Location = New System.Drawing.Point(257, 3)
        Me.Panel35.Name = "Panel35"
        Me.Panel35.Size = New System.Drawing.Size(248, 48)
        Me.Panel35.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 20.0!)
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(238, 37)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "+1 of everything"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(248, 48)
        Me.Panel1.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Light", 20.0!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "-1 of everything"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.Panel35)
        Me.Panel2.Location = New System.Drawing.Point(3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(506, 56)
        Me.Panel2.TabIndex = 17
        Me.Panel2.Visible = False
        '
        'preprog
        '
        Me.preprog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.preprog.BackColor = System.Drawing.Color.White
        Me.preprog.Font = New System.Drawing.Font("Segoe UI Light", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.preprog.Location = New System.Drawing.Point(532, 10)
        Me.preprog.Name = "preprog"
        Me.preprog.Size = New System.Drawing.Size(480, 26)
        Me.preprog.TabIndex = 18
        Me.preprog.Text = "Label3"
        Me.preprog.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'galleryext
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Magenta
        Me.ClientSize = New System.Drawing.Size(1024, 60)
        Me.Controls.Add(Me.preprog)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(0, 698)
        Me.Name = "galleryext"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "galleryext"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.Panel35.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel35 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents preprog As System.Windows.Forms.Label
End Class
