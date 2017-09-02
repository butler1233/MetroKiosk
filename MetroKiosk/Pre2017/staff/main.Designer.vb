<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class main
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
        Me.LAUNCH = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.SettingsButton = New System.Windows.Forms.Button()
        Me.Worker = New System.ComponentModel.BackgroundWorker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.consolebox = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Logupdater = New System.Windows.Forms.Timer(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ReceiptPrinter = New System.Drawing.Printing.PrintDocument()
        Me.SuspendLayout()
        '
        'LAUNCH
        '
        Me.LAUNCH.Location = New System.Drawing.Point(12, 12)
        Me.LAUNCH.Name = "LAUNCH"
        Me.LAUNCH.Size = New System.Drawing.Size(104, 57)
        Me.LAUNCH.TabIndex = 0
        Me.LAUNCH.Text = "Launch Kiosk"
        Me.LAUNCH.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(232, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 57)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Quit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(122, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 57)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "ReHide"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'SettingsButton
        '
        Me.SettingsButton.Location = New System.Drawing.Point(342, 12)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.Size = New System.Drawing.Size(104, 57)
        Me.SettingsButton.TabIndex = 3
        Me.SettingsButton.Text = "Settings"
        Me.SettingsButton.UseVisualStyleBackColor = True
        '
        'Worker
        '
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Listener bound to:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(109, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "'*:2102'"
        '
        'consolebox
        '
        Me.consolebox.BackColor = System.Drawing.SystemColors.Control
        Me.consolebox.FormattingEnabled = True
        Me.consolebox.Location = New System.Drawing.Point(0, 128)
        Me.consolebox.Name = "consolebox"
        Me.consolebox.Size = New System.Drawing.Size(456, 173)
        Me.consolebox.TabIndex = 8
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(0, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Incoming messages:"
        '
        'Logupdater
        '
        Me.Logupdater.Enabled = True
        Me.Logupdater.Interval = 10
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(232, 77)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(104, 45)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Throw OOM Immediately"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(342, 77)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 45)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "PrintReceipt"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(471, 18)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(147, 81)
        Me.Button5.TabIndex = 12
        Me.Button5.Text = "WPF Load: "
        Me.Button5.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(471, 154)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(147, 56)
        Me.Button6.TabIndex = 13
        Me.Button6.Text = "Print test page"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ReceiptPrinter
        '
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(630, 305)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.consolebox)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.SettingsButton)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LAUNCH)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "main"
        Me.Text = "Metro Kiosk           [v 1.42]"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LAUNCH As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SettingsButton As System.Windows.Forms.Button
    Friend WithEvents Worker As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents consolebox As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Logupdater As System.Windows.Forms.Timer
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Button6 As Button
    Friend WithEvents ReceiptPrinter As Printing.PrintDocument
End Class
