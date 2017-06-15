Public Class WPFInvoker

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim FinishWin As New WPF_MK_Windows.WPFWelcome
        FinishWin.Show()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim FinishWin As New WPF_MK_Windows.WPFProcesstoFinish
        FinishWin.Show()
    End Sub
End Class
