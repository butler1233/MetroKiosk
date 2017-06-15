Public Class MetroKioskWPF
    Private Sub Starter_MouseLeftButtonDown(sender As Object, e As Windows.Input.MouseButtonEventArgs) Handles Starter.MouseLeftButtonDown
        'Navigate tjhe frame to the first page. This should get us going.
        Dim WelcomePage As New SelectStorage(Me)
        HostFrame.Navigate(WelcomePage)
    End Sub
End Class
