Imports System.Windows.Forms

Public Class alertdialog


    Private Sub continuebutton_Click(sender As Object, e As EventArgs)
        Me.Hide()

    End Sub

    Private Sub cancelbutton_Click(sender As Object, e As EventArgs) Handles cancelbutton.Click
        Me.Hide()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub alertdialog_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        setting.sendlog(alerttext.Text)
    End Sub
End Class
