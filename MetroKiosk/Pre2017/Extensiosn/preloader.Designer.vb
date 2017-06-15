<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class preloader
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
        Me.preworker = New System.ComponentModel.BackgroundWorker()
        Me.Waituntilgallerytimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'preworker
        '
        Me.preworker.WorkerReportsProgress = True
        Me.preworker.WorkerSupportsCancellation = True
        '
        'Waituntilgallerytimer
        '
        '
        'preloader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(65, 0)
        Me.ControlBox = False
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "preloader"
        Me.Opacity = 0.0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Preloader"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents preworker As System.ComponentModel.BackgroundWorker
    Friend WithEvents Waituntilgallerytimer As System.Windows.Forms.Timer
End Class
