Imports System.Windows.Media.Animation
Imports System.Windows.Threading
Imports System.IO
Imports System.Threading

Class SelectStorage

    Dim _Main As MetroKioskWPF
    Dim _Disp As Dispatcher


    Public Sub New(MainWindow As MetroKioskWPF)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _Main = MainWindow
    End Sub

    Private Sub Button_Click(sender As Object, e As Windows.RoutedEventArgs)
        NavigationService.Navigate((New TestPage1))
    End Sub

    Private Sub Button_Click_1(sender As Object, e As Windows.RoutedEventArgs)

    End Sub

    Private Sub Page_Loaded(sender As Object, e As Windows.RoutedEventArgs)
        _Disp = Me.Dispatcher
        _Main.Speak("Please plug in your storage media.")

        'Start the threda
        Dim ts As New ThreadStart(AddressOf ProcessingThread)
        Dim Thread As New Thread(ts)
        Thread.Start()
    End Sub

    Private Sub TriggerTransition(DriveName As String, DriveType As String)
        _Main.Speak("Thanks!")
        DeviceNameTB.Text = DriveName
        DeviceTypeTB.Text = DriveType
        'trigger the anim
        Dim sb As Storyboard = Me.FindResource("TransitionToFoundCard")
        sb.Begin()

    End Sub
    Private Sub ReadyToNext(FilesFound As String)
        _Main.Speak("We found " + FilesFound + " pictures on your media. You can press next to continue..")
        ScanningforimagesTB.Text = FilesFound + " Pictures Found"
        ScanningPB.Visibility = Windows.Visibility.Collapsed
        'trigger the anim
        Dim sb As Storyboard = Me.FindResource("ShowNextButton")
        sb.Begin()

    End Sub

    Dim FoundDisk As Boolean = False
    Dim DiskFolder As String = ""
    Dim DiskType As String = ""
    Dim files As New List(Of FileInfo)

    Private Sub ProcessingThread()
        'Give the page a chance to animate in properly.
        Threading.Thread.Sleep(2000)

        'Find a disk
        While Not FoundDisk
            If (New System.IO.DirectoryInfo(My.Settings.StorageCD + "\").Exists) Then
                FoundDisk = True
                DiskFolder = My.Settings.StorageCD + "\"
                DiskType = "Optical Disk"
            ElseIf (New System.IO.DirectoryInfo(My.Settings.StorageCF + "\").Exists) Then
                FoundDisk = True
                DiskFolder = My.Settings.StorageCF + "\"
                DiskType = "Compact Flash Card"
            ElseIf (New System.IO.DirectoryInfo(My.Settings.StorageiDevice + "\").Exists) Then
                FoundDisk = True
                DiskFolder = My.Settings.StorageiDevice + "\"
                DiskType = "Unknown Device"
            ElseIf (New System.IO.DirectoryInfo(My.Settings.StorageMS + "\").Exists) Then
                FoundDisk = True
                DiskFolder = My.Settings.StorageMS + "\"
                DiskType = "MemoryStick™"
            ElseIf (New System.IO.DirectoryInfo(My.Settings.StorageSD + "\").Exists) Then
                FoundDisk = True
                DiskFolder = My.Settings.StorageSD + "\"
                DiskType = "SecureDigital Card"
            ElseIf (New System.IO.DirectoryInfo(My.Settings.StorageUSB + "\").Exists) Then
                FoundDisk = True
                DiskFolder = My.Settings.StorageUSB + "\"
                DiskType = "USB Device"
            ElseIf (New System.IO.DirectoryInfo(My.Settings.StorageXD + "\").Exists) Then
                FoundDisk = True
                DiskFolder = My.Settings.StorageXD + "\"
                DiskType = "XD Card"
            End If
            Threading.Thread.Sleep(250)
        End While
        'We found the details so we can spit it out.
        Dim DriveName As String = (New DriveInfo(DiskFolder.Substring(0, 1)).VolumeLabel)
        If DriveName="" Then DriveName = "Unnamed device"
        _Disp.Invoke(Sub() TriggerTransition(DriveName, DiskType))

        _Disp.Invoke(Sub() BluetoothButton.Visibility=Windows.Visibility.Collapsed)

        'And now, we enumerate
        Try
            BasicEnum(files,DiskFolder)
        Catch ex As Exception
            StrongAndStableEnum(files,DiskFolder)
        End Try

        'Sort by filename
        files.Sort(Function(x, y) y.LastWriteTime.CompareTo(x.LastWriteTime))
        'We should be okay to report the total now.

        _Disp.Invoke(Sub() ReadyToNext(files.Count.ToString))

    End Sub

    Private Sub NextButton_Click(sender As Object, e As Windows.RoutedEventArgs) Handles NextButton.Click
        Dim Hold As New Thread(Sub()
                                   Thread.Sleep(420)
                                   _Disp.Invoke(Sub() LoadFolderChooser())
                               End Sub)
        Hold.Start()
    End Sub

    Private Sub LoadFolderChooser()
        Dim Folders As New SizeSelector(_Main, files, DiskType, DiskFolder)
        _Main.PushPage(Folders)
    End Sub

    Private Sub BasicEnum(ByRef files As List(Of FileInfo), Folder As string)
        Dim DirInfo As New DirectoryInfo(Folder)

        files.AddRange(DirInfo.EnumerateFiles("*.jpg", SearchOption.AllDirectories))
        files.AddRange(DirInfo.EnumerateFiles("*.bmp", SearchOption.AllDirectories))
        files.AddRange(DirInfo.EnumerateFiles("*.png", SearchOption.AllDirectories))
        files.AddRange(DirInfo.EnumerateFiles("*.tif", SearchOption.AllDirectories))
        files.AddRange(DirInfo.EnumerateFiles("*.jpeg", SearchOption.AllDirectories))
    End Sub

    Private Sub StrongAndStableEnum(ByRef files As List(Of FileInfo), Folder As string)
        Dim Root As New DirectoryInfo(Folder)
        files = SlowEnum(Root)
    End Sub

    Private Function SlowEnum(folder As DirectoryInfo) As List(Of FileInfo)
        'First try to add the files
        Dim Files As New List(Of FileInfo)
        Try
            Files.AddRange(folder.EnumerateFiles("*.jpg",SearchOption.TopDirectoryOnly))
            Files.AddRange(folder.EnumerateFiles("*.bmp",SearchOption.TopDirectoryOnly))
            Files.AddRange(folder.EnumerateFiles("*.png",SearchOption.TopDirectoryOnly))
            Files.AddRange(folder.EnumerateFiles("*.tif",SearchOption.TopDirectoryOnly))
            Files.AddRange(folder.EnumerateFiles("*.jpeg",SearchOption.TopDirectoryOnly))
        Catch ex As Exception

        End Try
        'Now we enumerate the folders
        For each forfolder In folder.EnumerateDirectories()
            Try
                Files.AddRange(SlowEnum(forfolder))
            Catch ex As Exception

            End Try
        Next
        Return Files
        
    End Function

    Private Sub BluetoothButton_Click(sender As Object, e As Windows.RoutedEventArgs) Handles BluetoothButton.Click
        _Main.PushPage(New BluetoothLanding(_Main))
    End Sub
End Class
