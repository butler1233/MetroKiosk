Imports System.Windows.Media.Animation
Public Class WPFWelcome
    'The following needs to be on each window.
    Dim controlwindow As New WPF_MK_Windows.KioskControl
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        PSLogo.Source = BitmapToBitmapSource(MetroKioskResources.My.Resources.Kiosklogo)
        Dim BGCol As New SolidColorBrush()
        BGCol.Color = Colors.WhiteSmoke
        GridBG.Fill = BGCol
        Me.RegisterName("BGCol", BGCol)
    End Sub
    Private Sub StaffMode(sender As Object, e As RoutedEventArgs)
        controlwindow.Show()
        controlwindow.Focus()
    End Sub

    'And from here, screen specifics.

End Class
