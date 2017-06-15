Imports System.Windows.Forms
Imports System.Threading

Public Class ordercanceldialog


    Private Sub continuebutton_Click(sender As Object, e As EventArgs) Handles continuebutton.Click
        Me.Hide()

    End Sub

    Private Sub cancelbutton_Click(sender As Object, e As EventArgs) Handles cancelbutton.Click
        setting.sendlog("User cancelled order, kiosk resetting.")
        Try
            Application.Restart()
        Catch ex As Exception
            errorbox("Cancellation error", "The application was unable to reset;" + vbNewLine + "The contect would not allow it." + vbNewLine + vbNewLine + "The application will now close instead.")
            setting.sendlog("Kiosk failed to reset normally. Just going to quit application instead.")
            Thread.Sleep(3000)
            Application.Exit()
        End Try

    End Sub
End Class
