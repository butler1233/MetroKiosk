Public Class WPFAlert

    Public Sub SetValues(altitle As String, altext As String)
        AlertText.Text = altext
        AlertTitle.Content = altitle
        Me.Title = altitle
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub
End Class
