Imports System.IO
Imports System.Windows.Controls
Imports System.Windows.Media.Animation

Public Class MetroKioskWPF

    Public SizeID As Sizes = Sizes.s6x4
    Public SourceFolder As DirectoryInfo

    Private Sub Starter_MouseLeftButtonDown(sender As Object, e As Windows.Input.MouseButtonEventArgs) Handles Starter.MouseLeftButtonDown
        'Navigate tjhe frame to the first page. This should get us going.
        Dim WelcomePage As New SelectStorage(Me)
        HostFrame.Navigate(WelcomePage)
    End Sub

    Private Sub HostFrame_Navigated(sender As Object, e As Windows.Navigation.NavigationEventArgs) Handles HostFrame.Navigated
        Try
            FrameTitle.Text = DirectCast(HostFrame.Content, Page).Title
        Catch ex As Exception
            FrameTitle.Text = "Please Wait..."
        End Try

    End Sub

    Friend Sub PushPage(Page As Page)
        HostFrame.Navigate(Page)
    End Sub

    Dim SpEng As New Speech.Synthesis.SpeechSynthesizer

    Friend Sub ResetKiosk
        Dim NewKiosk as new MetroKioskWPF()
        NewKiosk.Show()
        Me.Close()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As Windows.RoutedEventArgs)
        'Set up the speaker
        SpEng.SetOutputToDefaultAudioDevice()

    End Sub

    Friend Sub Speak(Words As String)
        SpEng.SpeakAsyncCancelAll()

        If MuteButton.IsChecked Then
            SpEng.SpeakAsync(Words)
        End If


    End Sub

    Friend Sub ExpandFrame()
        Dim sb As Storyboard = FindResource("ExpandFrameAnim")
        sb.Begin()
    End Sub

    Private Sub Button_Click(sender As Object, e As Windows.RoutedEventArgs)
        Dim bi As New BluetoothIntegration
        bi.Show()
    End Sub
End Class
