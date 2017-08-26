Imports System.IO
Imports System.Threading
Imports System.Windows.Controls
Imports System.Windows.Media.Animation

Class NameEntry

    Dim _Files As List(Of FileInfo)
    Dim _MW As MetroKioskWPF
    Dim _Disp As Windows.Threading.Dispatcher

    Public Sub New(MainWindow As MetroKioskWPF, Files As List(Of FileInfo))

        ' This call is required by the designer.
        InitializeComponent()

        _Files = Files
        _MW = MainWindow
        _Disp = Me.Dispatcher
        ' Add any initialization after the InitializeComponent() call.
        _MW.Speak("Now tell us your name")
    End Sub

    Private Sub Press(sender As Button, e As Windows.RoutedEventArgs) Handles button.Click, button1.Click, button2.Click, button3.Click, button4.Click, button5.Click, button6.Click, button7.Click, button8.Click, button9.Click, button10.Click, button11.Click, button12.Click, button13.Click, button14.Click, button15.Click, button16.Click, button17.Click, button18.Click, button19.Click, button20.Click, button21.Click, button22.Click, button23.Click, button24.Click, button25.Click
        Apnd(sender.Content)
    End Sub

    Private Sub Apnd(Chara As String)
        NameBox.Text += Chara
    End Sub

    Private Sub Button_Click(sender As Object, e As Windows.RoutedEventArgs)
        Apnd(" ")
    End Sub

    Private Sub Backspace(sender As Object, e As Windows.RoutedEventArgs) Handles button26_Copy.Click
        If NameBox.Text.Length > 1 Then
            NameBox.Text = NameBox.Text.Substring(0, NameBox.Text.Length - 1)
        ElseIf NameBox.Text.Length = 1 Then
            NameBox.Text = ""
        End If

    End Sub

    Private Sub NextButton_Click(sender As Object, e As Windows.RoutedEventArgs) Handles DoneButton.Click
        NextPage()
    End Sub

    Dim gallery As WPFGallery

    Private Sub NextPage()
        Dim SB As Storyboard = Me.FindResource("LoadingSPiner")
        SB.Begin()
        Dim SB2 As Storyboard = Me.FindResource("AnimatePageOut")
        SB2.Begin()
        _MW.FrameTitle.Text = "Please Wait..."
        Loader.Visibility = Windows.Visibility.Visible
        MainGrid.IsEnabled = False
        Dim Hold As New Thread(Async Sub()
                                   Thread.Sleep(420)
                                   Await _Disp.BeginInvoke(Sub() gallery = New WPFGallery(_MW, _Files, NameBox.Text), Windows.Threading.DispatcherPriority.Background)

                                   _Disp.Invoke(Sub() LoadNext())
                               End Sub)
        Hold.Start()
    End Sub

    Private Sub LoadNext()
        _MW.PushPage(gallery)
        gallery.StartLoaders()
    End Sub
End Class
