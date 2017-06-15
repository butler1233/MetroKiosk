Imports System.Windows.Media.Animation
Public Class WPFProcesstoFinish
    'The following needs to be on each window.
    Dim controlwindow As New WPF_MK_Windows.KioskControl
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        PSLogo.Source = BitmapToBitmapSource(MetroKioskResources.My.Resources.Kiosklogo)
        Dim BGCol As New SolidColorBrush()
        BGCol.Color = Colors.WhiteSmoke
        GridBG.Fill = BGCol
        Me.RegisterName("BGCol", BGCol)
        StartBGLoadColorAnimation(Me)
    End Sub
    Private Sub StaffMode(sender As Object, e As RoutedEventArgs)
        controlwindow.ShowDialog()
        controlwindow.Focus()

    End Sub

    'And from here, screen specifics.

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        EndProcessing()
    End Sub

    Public Sub EndProcessing()
        AnimateBG(Me, Colors.CornflowerBlue, 3)
        StopBGLoadColorAnimation()
        MainLabel.Content = "All Done."
        SubLabel.Content = "Please take your card out."
    End Sub

End Class
