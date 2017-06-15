<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class overflowhandler
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
        Me.darklay = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.eta = New System.Windows.Forms.Label()
        Me.etalab = New System.Windows.Forms.Label()
        Me.text4 = New System.Windows.Forms.Label()
        Me.tick4 = New System.Windows.Forms.PictureBox()
        Me.text3 = New System.Windows.Forms.Label()
        Me.tick3 = New System.Windows.Forms.PictureBox()
        Me.text2 = New System.Windows.Forms.Label()
        Me.text1 = New System.Windows.Forms.Label()
        Me.tick2 = New System.Windows.Forms.PictureBox()
        Me.tick1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.etaupdater = New System.Windows.Forms.Timer(Me.components)
        Me.worker = New System.ComponentModel.BackgroundWorker()
        Me.debugtext = New System.Windows.Forms.Label()
        Me.darklay.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.tick4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tick3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tick2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tick1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'darklay
        '
        Me.darklay.BackColor = System.Drawing.Color.Transparent
        Me.darklay.BackgroundImage = Global.MetroKioskResources.My.Resources.Resources.darklay
        Me.darklay.Controls.Add(Me.Panel1)
        Me.darklay.Dock = System.Windows.Forms.DockStyle.Fill
        Me.darklay.Location = New System.Drawing.Point(0, 0)
        Me.darklay.Name = "darklay"
        Me.darklay.Size = New System.Drawing.Size(1024, 768)
        Me.darklay.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.MetroKioskResources.My.Resources.Resources.pleasewaitwin
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.debugtext)
        Me.Panel1.Controls.Add(Me.eta)
        Me.Panel1.Controls.Add(Me.etalab)
        Me.Panel1.Controls.Add(Me.text4)
        Me.Panel1.Controls.Add(Me.tick4)
        Me.Panel1.Controls.Add(Me.text3)
        Me.Panel1.Controls.Add(Me.tick3)
        Me.Panel1.Controls.Add(Me.text2)
        Me.Panel1.Controls.Add(Me.text1)
        Me.Panel1.Controls.Add(Me.tick2)
        Me.Panel1.Controls.Add(Me.tick1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 768)
        Me.Panel1.TabIndex = 1
        '
        'eta
        '
        Me.eta.AutoSize = True
        Me.eta.Location = New System.Drawing.Point(342, 518)
        Me.eta.Name = "eta"
        Me.eta.Size = New System.Drawing.Size(74, 15)
        Me.eta.TabIndex = 13
        Me.eta.Text = "calculating..."
        '
        'etalab
        '
        Me.etalab.AutoSize = True
        Me.etalab.Location = New System.Drawing.Point(194, 518)
        Me.etalab.Name = "etalab"
        Me.etalab.Size = New System.Drawing.Size(146, 15)
        Me.etalab.TabIndex = 12
        Me.etalab.Text = "Estimated time remaining:"
        '
        'text4
        '
        Me.text4.AutoSize = True
        Me.text4.Location = New System.Drawing.Point(219, 398)
        Me.text4.Name = "text4"
        Me.text4.Size = New System.Drawing.Size(75, 15)
        Me.text4.TabIndex = 11
        Me.text4.Text = "Almost done"
        '
        'tick4
        '
        Me.tick4.Image = Global.MetroKioskResources.My.Resources.Resources.tick1
        Me.tick4.Location = New System.Drawing.Point(197, 398)
        Me.tick4.Name = "tick4"
        Me.tick4.Size = New System.Drawing.Size(16, 17)
        Me.tick4.TabIndex = 10
        Me.tick4.TabStop = False
        Me.tick4.Visible = False
        '
        'text3
        '
        Me.text3.AutoSize = True
        Me.text3.Location = New System.Drawing.Point(219, 380)
        Me.text3.Name = "text3"
        Me.text3.Size = New System.Drawing.Size(164, 15)
        Me.text3.TabIndex = 9
        Me.text3.Text = "Creating the last few previews"
        '
        'tick3
        '
        Me.tick3.Image = Global.MetroKioskResources.My.Resources.Resources.tick1
        Me.tick3.Location = New System.Drawing.Point(197, 380)
        Me.tick3.Name = "tick3"
        Me.tick3.Size = New System.Drawing.Size(16, 17)
        Me.tick3.TabIndex = 8
        Me.tick3.TabStop = False
        Me.tick3.Visible = False
        '
        'text2
        '
        Me.text2.AutoSize = True
        Me.text2.Location = New System.Drawing.Point(219, 362)
        Me.text2.Name = "text2"
        Me.text2.Size = New System.Drawing.Size(122, 15)
        Me.text2.TabIndex = 6
        Me.text2.Text = "Saving progress so far"
        '
        'text1
        '
        Me.text1.AutoSize = True
        Me.text1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.text1.Location = New System.Drawing.Point(219, 344)
        Me.text1.Name = "text1"
        Me.text1.Size = New System.Drawing.Size(186, 15)
        Me.text1.TabIndex = 5
        Me.text1.Text = "Sorting the last processes image"
        '
        'tick2
        '
        Me.tick2.Image = Global.MetroKioskResources.My.Resources.Resources.tick1
        Me.tick2.Location = New System.Drawing.Point(197, 362)
        Me.tick2.Name = "tick2"
        Me.tick2.Size = New System.Drawing.Size(16, 17)
        Me.tick2.TabIndex = 3
        Me.tick2.TabStop = False
        Me.tick2.Visible = False
        '
        'tick1
        '
        Me.tick1.Image = Global.MetroKioskResources.My.Resources.Resources.tick1
        Me.tick1.Location = New System.Drawing.Point(197, 344)
        Me.tick1.Name = "tick1"
        Me.tick1.Size = New System.Drawing.Size(16, 17)
        Me.tick1.TabIndex = 2
        Me.tick1.TabStop = False
        Me.tick1.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(194, 296)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(603, 44)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "We're just getting your images ready for you. It shouldn't take long. If there is" & _
    " a long time remaining you may want to find something else to do for a bit." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(193, 261)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Preparing Images..."
        '
        'etaupdater
        '
        Me.etaupdater.Enabled = True
        Me.etaupdater.Interval = 500
        '
        'worker
        '
        Me.worker.WorkerReportsProgress = True
        '
        'debugtext
        '
        Me.debugtext.ForeColor = System.Drawing.Color.White
        Me.debugtext.Location = New System.Drawing.Point(755, 743)
        Me.debugtext.Name = "debugtext"
        Me.debugtext.Size = New System.Drawing.Size(257, 16)
        Me.debugtext.TabIndex = 14
        Me.debugtext.Text = "Not even started"
        Me.debugtext.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'overflowhandler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.BackgroundImage = Global.MetroKioskResources.My.Resources.Resources.crop
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.darklay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "overflowhandler"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Overflow Handler"
        Me.TopMost = True
        Me.darklay.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.tick4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tick3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tick2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tick1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents darklay As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents etalab As System.Windows.Forms.Label
    Friend WithEvents text4 As System.Windows.Forms.Label
    Friend WithEvents tick4 As System.Windows.Forms.PictureBox
    Friend WithEvents text3 As System.Windows.Forms.Label
    Friend WithEvents tick3 As System.Windows.Forms.PictureBox
    Friend WithEvents text2 As System.Windows.Forms.Label
    Friend WithEvents text1 As System.Windows.Forms.Label
    Friend WithEvents tick2 As System.Windows.Forms.PictureBox
    Friend WithEvents tick1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents eta As System.Windows.Forms.Label
    Friend WithEvents etaupdater As System.Windows.Forms.Timer
    Friend WithEvents worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents debugtext As System.Windows.Forms.Label
End Class
