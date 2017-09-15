Imports System.IO
Imports System.Windows.Threading

Class BluetoothLanding

    Dim _Main As MetroKioskWPF
    Dim _Disp As Dispatcher
    Dim _watcher As FileSystemWatcher
    Dim _files As New Dictionary(Of String,Boolean )

    Public Sub New(main As MetroKioskWPF)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _Main = main
        _Disp = Me.Dispatcher
        _watcher = New FileSystemWatcher("C:\bt")
        _watcher.EnableRaisingEvents = True
        _watcher.NotifyFilter = NotifyFilters.FileName Or NotifyFilters.LastWrite Or NotifyFilters.Size Or NotifyFilters.CreationTime
        RecievedImages.Text = ""
        AddHandler _watcher.Created, AddressOf fswChanged
        AddHandler _watcher.Changed, AddressOf fswChanged
        SendTo.Text = "Send images to """+My.Computer.Name+""""
    End Sub

    Public Sub fswChanged (sender As Object, e As FileSystemEventArgs)
        _files(e.FullPath) = true
        _Disp.BeginInvoke(Sub()
                              RecievedImages.Text = _files.Count.ToString+ " images received"
                          End Sub)
    End Sub

    Private Sub FinishedButton_Copy_Click(sender As Object, e As Windows.RoutedEventArgs) Handles FinishedButton_Copy.Click
        _Main.PushPage(New SelectStorage(_Main))
    End Sub

    Private Sub FinishedButton_Click(sender As Object, e As Windows.RoutedEventArgs) Handles FinishedButton.Click
        Dim Files = New List(of FileInfo)
        Dim FOlder = (New DirectoryInfo("C:\bt"))
        Files.AddRange(folder.EnumerateFiles("*.jpg",SearchOption.TopDirectoryOnly))
        Files.AddRange(folder.EnumerateFiles("*.bmp",SearchOption.TopDirectoryOnly))
        Files.AddRange(folder.EnumerateFiles("*.png",SearchOption.TopDirectoryOnly))
        Files.AddRange(folder.EnumerateFiles("*.tif",SearchOption.TopDirectoryOnly))
        Files.AddRange(folder.EnumerateFiles("*.jpeg",SearchOption.TopDirectoryOnly))
        _Main.PushPage(New SizeSelector(_Main, files, "Bluetooth", "C:\bt"))
    End Sub
End Class
