Imports System.IO
Imports System.Threading
Imports System.Windows.Controls
Imports System.Windows.Media.Animation
Imports System.Windows.Threading

Class SelectFolder

    Dim _Main As MetroKioskWPF
    Dim _Files As List(Of FileInfo)
    Dim _Disp As Dispatcher
    Dim _rootFolder As DirectoryInfo
    Dim _CurrentFolder As DirectoryInfo
    Dim _LastFolder As DirectoryInfo


    Public Sub New(MainWindow As MetroKioskWPF, Files As List(Of FileInfo), DiskType As String, RootFolder As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _Main = MainWindow
        _Files = Files
        _rootFolder = New DirectoryInfo(RootFolder)
        SelectAllButton.Tag = _rootFolder
        ChooseFolderOnYourX.Text = ChooseFolderOnYourX.Text.Replace("<device>", DiskType)
    End Sub

    Private Sub Page_Loaded(sender As Object, e As Windows.RoutedEventArgs)
        _Disp = Me.Dispatcher
        _Main.Speak("Now you can tell us where your pictures are on your media. If you're not sure, or you just want to load everything, press Select All Pictures.")
        Dim ts As New ParameterizedThreadStart(AddressOf ProcessingThread)
        Dim Thread As New Thread(ts)

        Thread.Start(_rootFolder)
    End Sub

    Private Sub LoadFolderUI(Sender As Button, e As EventArgs)
        Dim x As New Thread(AddressOf ProcessingThread)
        x.Start(Sender.Tag)
    End Sub

    Private Sub ProcessingThread(CurrentFolder As DirectoryInfo)

        Dim folders As IEnumerable(Of DirectoryInfo) = (CurrentFolder).EnumerateDirectories()
        _CurrentFolder = CurrentFolder
        _Disp.Invoke(Sub()
                         FolderList.Children.Clear()
                         If Not (_CurrentFolder.FullName = _rootFolder.FullName) Then
                             'Create the last one.
                             Dim btn As New Button
                             btn.Template = Me.FindResource("FolderButton")
                             btn.ApplyTemplate()
                             btn.Content = "   <Back>"
                             AddHandler btn.Click, AddressOf BackFolder
                             FolderList.Children.Add(btn)
                         End If
                         For Each folder In folders
                             Dim btn As New Button
                             btn.Template = Me.FindResource("FolderButton")
                             btn.ApplyTemplate()
                             btn.Content = folder.Name
                             btn.Tag = folder
                             AddHandler btn.Click, AddressOf LoadFolderUI
                             FolderList.Children.Add(btn)
                         Next

                         SelectCurrentFolderText.Text = "Use ""\" + _CurrentFolder.FullName.Replace(_rootFolder.FullName, "") + """"
                         SelectCurrentFolder.Tag = _CurrentFolder
                     End Sub)
    End Sub

    Private Sub BackFolder(Sender As Object, e As EventArgs)
        Dim x As New Thread(AddressOf ProcessingThread)
        x.Start(_CurrentFolder.Parent)
    End Sub

    Private Sub FolderScroller_ManipulationBoundaryFeedback(sender As Object, e As Windows.Input.ManipulationBoundaryFeedbackEventArgs) Handles FolderScroller.ManipulationBoundaryFeedback
        e.Handled = True
    End Sub



    Dim NewFiles As List(Of FileInfo)


    Private Sub NextPage(Folder As DirectoryInfo)
        _Main.SourceFolder = Folder
        Dim SB As Storyboard = Me.FindResource("LoadingSPiner")
        SB.Begin()
        Loader.Visibility = Windows.Visibility.Visible
        Maingrid.IsEnabled = False
        Dim Hold As New Thread(Sub()
                                   If _rootFolder.FullName = Folder.FullName Then
                                       NewFiles = _Files
                                   Else
                                       NewFiles = _Files.Where(Function(File) File.FullName.StartsWith(Folder.FullName)).ToList
                                   End If
                                   _Disp.Invoke(Sub()
                                                    Dim SB2 As Storyboard = Me.FindResource("AnimatePageOut")
                                                    SB2.Begin()
                                                End Sub)
                                   Thread.Sleep(450)
                                   _Disp.Invoke(Sub() LoadNext())
                               End Sub)
        Hold.Start()
    End Sub

    Private Sub LoadNext()
        Dim Folders As New NameEntry(_Main, NewFiles)
        _Main.PushPage(Folders)
    End Sub

    Private Sub SelectAllButton_Click(sender As Object, e As Windows.RoutedEventArgs) Handles SelectAllButton.Click
        NextPage(_rootFolder)
    End Sub

    Private Sub SelectCurrentFolder_Click(sender As Object, e As Windows.RoutedEventArgs) Handles SelectCurrentFolder.Click
        NextPage(_CurrentFolder)
    End Sub
End Class
