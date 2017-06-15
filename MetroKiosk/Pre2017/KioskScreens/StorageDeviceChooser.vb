Imports System.IO
Imports System.Security
Imports System.Windows.Forms.ListBox

Public Class StorageDeviceChooser
    Dim devicefound As Boolean
    Dim devicemount As String
    Dim deviceimage As System.Drawing.Image
    Dim devicename As String
    Dim images As Int32
    Dim run As Integer
    Dim listy As New ArrayList



    Private Sub StorageDeviceChooser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setting.sendnetcommand("STATE#Waiting for device")
        Me.Size = New Size(kioskWelcome.Width, kioskWelcome.Height - 164)
        If My.Settings.BluetoothEnabled Then
            btbox.Visible = True
        End If
    End Sub

    Private Sub storagetimer_Tick(sender As Object, e As EventArgs) Handles storagetimer.Tick
        'Check for SD
        If My.Computer.FileSystem.GetDriveInfo(My.Settings.StorageSD).IsReady Then
            devicefound = True
            devicemount = My.Settings.StorageSD
            deviceimage = MetroKioskResources.My.Resources.SD
            devicename = "Secure Digital (SD) Card"
        End If
        'Check for XD
        If My.Computer.FileSystem.GetDriveInfo(My.Settings.StorageXD).IsReady Then
            devicefound = True
            devicemount = My.Settings.StorageXD
            deviceimage = MetroKioskResources.My.Resources.XD
            devicename = "xD Picture Card"
        End If
        'Check for MS
        If My.Computer.FileSystem.GetDriveInfo(My.Settings.StorageMS).IsReady Then
            devicefound = True
            devicemount = My.Settings.StorageMS
            deviceimage = MetroKioskResources.My.Resources.MS
            devicename = "Sony MemoryStick"
        End If
        'Check for CF
        If My.Computer.FileSystem.GetDriveInfo(My.Settings.StorageCF).IsReady Then
            devicefound = True
            devicemount = My.Settings.StorageCF
            deviceimage = MetroKioskResources.My.Resources.CF
            devicename = "CompactFlash Card"
        End If
        If My.Computer.FileSystem.GetDriveInfo(My.Settings.StorageUSB).IsReady Then
            devicefound = True
            devicemount = My.Settings.StorageUSB
            deviceimage = MetroKioskResources.My.Resources.USB
            devicename = "USB Device"
        End If
        If My.Computer.FileSystem.GetDriveInfo(My.Settings.StorageiDevice).IsReady Then
            devicefound = True
            devicemount = My.Settings.StorageiDevice
            deviceimage = MetroKioskResources.My.Resources.iphone
            devicename = "iPhone/iPad"
        End If
        If My.Computer.FileSystem.GetDriveInfo(My.Settings.StorageCD).IsReady Then
            devicefound = True
            devicemount = My.Settings.StorageCD
            deviceimage = MetroKioskResources.My.Resources.cd
            devicename = "CD/DVD"
        End If

        If devicefound Then
            Dim totunit As String
            Dim totval As Double
            Dim useunit As String
            Dim useval As Double
            Dim remval As Double
            infopanel.Visible = True
            headtext.Text = "Storage device found"
            storageimage.Image = deviceimage
            Dim cool As System.IO.DriveInfo = My.Computer.FileSystem.GetDriveInfo(devicemount)
            devicetype.Text = devicename
            volname.Text = cool.VolumeLabel
            If cool.TotalSize < 1024 Then
                totunit = "bytes"
                totval = cool.TotalSize
            ElseIf cool.TotalSize < 1048576 Then
                totunit = "KB"
                totval = (cool.TotalSize / 1024)
            ElseIf cool.TotalSize < 1073741824 Then
                totunit = "MB"
                totval = (cool.TotalSize / 1048576)
            Else
                totunit = "GB"
                totval = (cool.TotalSize / 1073741824)
            End If
            volcapacity.Text = Math.Round(totval, 2).ToString + " " + totunit
            remval = (cool.TotalSize - cool.TotalFreeSpace).ToString

            If remval < 1024 Then
                useunit = "bytes"
                useval = remval
            ElseIf remval < 1048576 Then
                useunit = "KB"
                useval = (remval / 1024)
            ElseIf remval < 1073741824 Then
                useunit = "MB"
                useval = (remval / 1048576)
            Else
                useunit = "GB"
                useval = (remval / 1073741824)
            End If
            volused.Text = Math.Round(useval, 2).ToString + " " + useunit
            storagetimer.Enabled = False
            filescanner.RunWorkerAsync()

            sendlog("User attached " + cool.VolumeLabel + " (" + Math.Round(totval, 2).ToString + totunit + " " + devicename + ")")
            sendnetcommand("STATE#Scanning device")
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)
        ServiceChooser.Show()

    End Sub

    Public Sub scandrive(path As String, type As String)
        Dim results As List(Of String) = New List(Of String)
        Dim start As String = path + "\"
        results.Add(start)
        Dim stack As Stack(Of String) = New Stack(Of String)
        Do
            Try
                Debug.WriteLine(start)
                Dim dirs = From d In Directory.EnumerateFiles(start,
                  type, SearchOption.AllDirectories)
                  Select d
                ' multline Lambda - don't really need this
                Array.ForEach(dirs.ToArray(), Sub(d)
                                                  stack.Push(d)
                                              End Sub)
                start = stack.Pop()
                results.Add(start)
            Catch ex As UnauthorizedAccessException
                Console.WriteLine(ex.Message)
                Try
                    start = stack.Pop()
                Catch exa As Exception
                    Console.WriteLine("EXCEPTIONCEPTION")
                End Try
                results.Add(start)
            Catch ex As IOException
                Console.WriteLine(ex.Message)
                Try
                    start = stack.Pop()
                Catch exa As Exception
                    Console.WriteLine("EXCEPTIONCEPTION")
                End Try
                results.Add(start)
            Catch ex As InvalidOperationException
                Console.WriteLine(ex.Message)
            End Try
        Loop Until (stack.Count = 0)
        For Each d In results
            If d = (path + "\") Then
            Else
                Try
                    listy.Add(d)
                Catch ex As Exception
                    Console.Write(ex.Message)
                End Try

                images = listy.Count
                filescanner.ReportProgress(images)
            End If
        Next
    End Sub

    Public Sub finishscan()
        scanimg.Visible = False
        Label7.Visible = False
        If images > 0 Then
            amountoffiles.Text = images
            nextpanel.Visible = True
            sendnetcommand("JLOADED#" + images.ToString)
        Else
            amountoffiles.Text = "No files found"
        End If
        sendlog(images.ToString + " images found on the user's thing.")

        sendlog("#Press continue to move on...")
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles continuebutton.Click
        Dim licount As Integer = 0

        setting.images = listy

        'Lets make a blank 2D array because we now store the amount of copies in arrayception to support multiple size orders (8/4/15)
        ReDim setting.copies(setting.images.Count - 1, 5)

        licount = licount + 1


        setting.userStorageMedia = devicemount
        ServiceChooser.Show()
        preloader.Show()
        galleryext.Show()
        Me.Hide()
        sendlog("#What size prints do you want?")
        sendlog("Progressing to Size Selection")
    End Sub

    Private Sub filescanner_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles filescanner.DoWork

        scandrive(devicemount, "*.jpg")
        scandrive(devicemount, "*.jpeg")
        scandrive(devicemount, "*.png")
        scandrive(devicemount, "*.bmp")
        scandrive(devicemount, "*.tif")
        scandrive(devicemount, "*.tiff")
        scandrive(devicemount, "*.gif")
        scandrive(devicemount, "*.psd")
        listy.Sort()
        Dim count As Integer = listy.Count
        Dim i As Integer
        For i = count - 1 To 1 Step -1
            If (listy(i).ToString() = listy(i - 1).ToString()) Then
                listy.RemoveAt(i)
            End If
        Next i
        listy.Reverse()

        filescanner.ReportProgress(0, "d")
    End Sub

    Private Sub filescanner_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles filescanner.ProgressChanged
        If e.UserState = "d" Then
            finishscan()
            imagetot.Text = listy.Count
            sendnetcommand("STATE#Images scanned")
        Else
            imagetot.Text = e.ProgressPercentage.ToString
        End If
    End Sub

    Private Sub bluetoothinit_Click(sender As Object, e As EventArgs) Handles bluetoothinit.Click
        storagetimer.Enabled = False
        infopanel.Visible = True
        headtext.Text = "Transfer over Bluetooth..."
        storageimage.Image = MetroKioskResources.My.Resources.iphone
        devicetype.Text = devicename
        volname.Text = "Send all images then press next"
        devicemount = "C:\b"
        capacityblock.Visible = False
        btbox.Visible = False

        imagetot.Visible = False
        Label5.Visible = False
        scanimg.Visible = False
        Label7.Visible = False
        btfbox.Visible = True
        sendnetcommand("STATE#Bluetooth mode enabled")
    End Sub

    Private Sub scantimer_Tick(sender As Object, e As EventArgs) Handles scantimer.Tick

    End Sub

    Private Sub btfinish_Click(sender As Object, e As EventArgs) Handles btfinish.Click
        btfbox.Visible = False
        imagetot.Visible = True
        Label5.Visible = True
        scanimg.Visible = True
        Label7.Visible = True

        filescanner.RunWorkerAsync()

    End Sub
End Class