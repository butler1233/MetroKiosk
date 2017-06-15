Public Class screensavepanel

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Size = New Size(kioskWelcome.Width, kioskWelcome.Height - 93)
        Me.Location = New Point(kioskWelcome.Location.X, kioskWelcome.Location.Y + 93)
    End Sub

    Private Sub screensavepanel_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        Me.Hide()
        setting.sendnetcommand("STARTJOB")
        kioskWelcome.cancel.Visible = True
        StorageDeviceChooser.Show()
        kioskWelcome.WebBrowser1.Visible = False

    End Sub
End Class