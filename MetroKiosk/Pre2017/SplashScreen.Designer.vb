<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen
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
        Me.BuildDateString = New System.Windows.Forms.Label()
        Me.DeploymentString = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'BuildDateString
        '
        Me.BuildDateString.AutoSize = True
        Me.BuildDateString.BackColor = System.Drawing.Color.Transparent
        Me.BuildDateString.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuildDateString.Location = New System.Drawing.Point(4, 237)
        Me.BuildDateString.Name = "BuildDateString"
        Me.BuildDateString.Size = New System.Drawing.Size(122, 19)
        Me.BuildDateString.TabIndex = 0
        Me.BuildDateString.Text = "15/12/2015 15:06"
        '
        'DeploymentString
        '
        Me.DeploymentString.AutoSize = True
        Me.DeploymentString.BackColor = System.Drawing.Color.Transparent
        Me.DeploymentString.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeploymentString.Location = New System.Drawing.Point(4, 256)
        Me.DeploymentString.Name = "DeploymentString"
        Me.DeploymentString.Size = New System.Drawing.Size(131, 19)
        Me.DeploymentString.TabIndex = 1
        Me.DeploymentString.Text = "Version 2.2015.12.0"
        '
        'SplashScreen
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.MetroKiosk.My.Resources.Resources.splash
        Me.ClientSize = New System.Drawing.Size(496, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.DeploymentString)
        Me.Controls.Add(Me.BuildDateString)
        Me.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BuildDateString As Label
    Friend WithEvents DeploymentString As Label
End Class
