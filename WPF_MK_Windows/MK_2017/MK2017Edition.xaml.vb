Imports System.Windows.Forms
Imports System.IO
Imports System.ComponentModel
Imports System.Windows.Media.Animation

Public Class MK2017Edition
    Public SettingsWindow As System.Windows.Forms.Form

    Dim CFLocation, CDLocation, iDeviceLocation, SDLocation, XDLocation, BTLocation As String

    Public Sub SetupWindow(CF As String, CD As String, iDevice As String, SD As String, XD As String, BT As String)
        CFLocation = CF
        CDLocation = CD
        iDeviceLocation = iDevice
        SDLocation = SD
        XDLocation = XD
        BTLocation = BT

        Me.Show()
    End Sub


    Private Sub button_Click(sender As Object, e As RoutedEventArgs) Handles MainMenuButton.Click
        SettingsWindow.WindowState = Forms.FormWindowState.Normal
        SettingsWindow.Activate()
    End Sub

    Private Sub image_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles image.MouseLeftButtonDown
        MainMenuButton.IsEnabled = Not MainMenuButton.IsEnabled
        If MainMenuButton.IsEnabled Then
            MainMenuButton.Visibility = Visibility.Visible
        Else
            MainMenuButton.Visibility = Visibility.Hidden
        End If


    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        DeviceSelectionWorker.WorkerReportsProgress = True
        AddHandler DeviceSelectionWorker.DoWork, AddressOf DeviceWorkerJob
        AddHandler DeviceSelectionWorker.ProgressChanged, AddressOf DeviceWorkerProgress
        AddHandler DeviceSelectionWorker.RunWorkerCompleted, AddressOf DeviceWorkerFinished
        DeviceSelectionWorker.RunWorkerAsync()

    End Sub
    Dim TargetType As String
    Dim TargetFolder As String
    Dim DeviceSelectionWorker As New System.ComponentModel.BackgroundWorker

    Dim ImageList As List(Of String)

    Private Sub DeviceWorkerJob(sender As BackgroundWorker, e As DoWorkEventArgs)
        Dim DriveConnected As Boolean = False
        TargetType = ""
        TargetFolder = ""
        While Not DriveConnected
            Try
                Dim DI As New DirectoryInfo(SDLocation)
                If DI.Exists Then
                    TargetType = "Secure Digital (SD)"
                    TargetFolder = DI.FullName
                    Exit While
                End If
            Catch ex As Exception
                'Doesn't exist. Move along.
            End Try
            Try
                Dim DI As New DirectoryInfo(CFLocation)
                If DI.Exists Then
                    TargetType = "Compact Flash (CF)"
                    TargetFolder = DI.FullName
                    Exit While
                End If
            Catch ex As Exception
                'Doesn't exist. Move along.
            End Try
            Try
                Dim DI As New DirectoryInfo(CDLocation)
                If DI.Exists Then
                    TargetType = "CD/DVD"
                    TargetFolder = DI.FullName
                    Exit While
                End If
            Catch ex As Exception
                'Doesn't exist. Move along.
            End Try
            Try
                Dim DI As New DirectoryInfo(iDeviceLocation)
                If DI.Exists Then
                    TargetType = "Mobile Device"
                    TargetFolder = DI.FullName
                    Exit While
                End If
            Catch ex As Exception
                'Doesn't exist. Move along.
            End Try
            Try
                Dim DI As New DirectoryInfo(XDLocation)
                If DI.Exists Then
                    TargetType = "XD Card"
                    TargetFolder = DI.FullName
                    Exit While
                End If
            Catch ex As Exception
                'Doesn't exist. Move along.
            End Try
            Try
                Dim DI As New DirectoryInfo(BTLocation)
                If DI.EnumerateFiles.Count > 0 Then
                    TargetType = "CD/DVD"
                    TargetFolder = DI.FullName
                    Exit While
                End If
            Catch ex As Exception
                'Doesn't exist. Move along.
            End Try
        End While
        sender.ReportProgress(0, True)


    End Sub

    Public Sub BrowseFolder(SourceFolder As String)
        'For Each folder As String In (New DirectoryInfo(SourceFolder)).EnumerateDirectories("*", SearchOption.AllDirectories)
    End Sub

    Private Sub DeviceWorkerProgress(sender As BackgroundWorker, e As ProgressChangedEventArgs)
        If e.UserState = True Then
            DeviceInfoTitle.Text = TargetType
            DeviceInfoBody.Text = "This is where we start a timer."
            Dim DevInfoSB As Storyboard = DirectCast(FindResource("DeviceInfoShow"), Storyboard)
            DevInfoSB.Begin()
            Dim MediaAnim As Storyboard = DirectCast(FindResource("MediaCardAnimation"), Storyboard)
            MediaAnim.Stop()
        End If
    End Sub

    Private Sub DeviceWorkerFinished(sender As BackgroundWorker, e As AsyncCompletedEventArgs)

    End Sub


End Class
