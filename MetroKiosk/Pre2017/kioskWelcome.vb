Public Class kioskWelcome

    Private Sub kioskWelcome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setting.sendlog("Kiosk loaded successfully.")
        Me.WindowState = FormWindowState.Maximized
        screensavepanel.Show()

    End Sub

    Private Sub Logo_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logo.DoubleClick
        main.TopMost = True
        main.WindowState = FormWindowState.Normal
    End Sub


    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        ordercanceldialog.Show()
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        setting.sendnetcommand("STATE#Screensaver")
    End Sub

    Private Sub Logo_Click(sender As Object, e As EventArgs) Handles Logo.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.MouseDown
        sendnetcommand("help")
    End Sub

    Private Sub Label4_Click_1(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class