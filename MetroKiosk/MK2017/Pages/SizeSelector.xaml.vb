Imports System.IO
Imports System.Threading
Imports System.Windows.Threading

Class SizeSelector

    Dim _Main As MetroKioskWPF
    Dim _Files As List(Of FileInfo)
    Dim _Disktype As String
    Dim _RootFolder As String
    Dim _Disp As Dispatcher

    Public Sub New(MainWindow As MetroKioskWPF, Files As List(Of FileInfo), DiskType As String, RootFolder As String)

        ' This call is required by the designer.
        InitializeComponent()

        _Main = MainWindow
        _Files = Files
        _Disktype = DiskType
        _RootFolder = RootFolder
        _Disp = Me.Dispatcher

        ' Add any initialization after the InitializeComponent() call.
        _Main.Speak("Please tell us what size prints you want. If you want multiple sizes, just pick the one you want the most of.")
    End Sub

    Private Sub NextPage()
        'Check if we actually need to run the user on folders or not.
        Dim Folder As New DirectoryInfo(_RootFolder)
        'We enumerate now.
        If MultiFolders(Folder) Then
            'We need to go to folder select
            Dim Folders As New SelectFolder(_Main, _Files, _Disktype, _RootFolder)
            _Main.PushPage(Folders)
        Else
            Dim Folders As New NameEntry(_Main, _Files)
            _Main.PushPage(Folders)
        End If
    End Sub

    Private Function MultiFolders(Search As DirectoryInfo)
        Dim Folders = Search.EnumerateDirectories()
        If Folders.Count = 1 Then
            Dim isMulti As Boolean = False
            For Each folder In Folders
                If Not isMulti Then
                    isMulti = MultiFolders(folder)
                Else
                    Exit For
                End If
            Next
            Return isMulti
        ElseIf Folders.Count > 1 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub FakeNextPage()
        Dim Hold As New Thread(Sub()
                                   Thread.Sleep(420)
                                   _Disp.Invoke(Sub() NextPage())
                               End Sub)
        Hold.Start()
    End Sub

    Private Sub _6x4Button_Click(sender As Object, e As Windows.RoutedEventArgs) Handles _6x4Button.Click
        _Main.SizeID = 1
        FakeNextPage()
    End Sub

    Private Sub _7x5Button_Click(sender As Object, e As Windows.RoutedEventArgs) Handles _7x5Button.Click
        _Main.SizeID = 2
        FakeNextPage()
    End Sub

    Private Sub _8x6Button_Click(sender As Object, e As Windows.RoutedEventArgs) Handles _8x6Button.Click
        _Main.SizeID = 3
        FakeNextPage()
    End Sub

    Private Sub _10x8Button_Click(sender As Object, e As Windows.RoutedEventArgs) Handles _10x8Button.Click
        _Main.SizeID = 4
        FakeNextPage()
    End Sub

    Private Sub _10x12Button_Click(sender As Object, e As Windows.RoutedEventArgs) Handles _10x12Button.Click
        _Main.SizeID = 5
        FakeNextPage()
    End Sub
End Class
