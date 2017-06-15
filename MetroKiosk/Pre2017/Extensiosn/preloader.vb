Public Class preloader
    Dim cool As Integer
    Dim errorshown As Boolean = False

    Private Property val1 As Image.GetThumbnailImageAbort

    Private Property val2 As IntPtr

    Private Sub preloader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sendlog("Preloader starting")
        preworker.RunWorkerAsync()
    End Sub
    Public Sub doID(i As Integer, Optional upd As Boolean = False)
        Try
            If My.Settings.DebugMode Then
                My.Settings.DebugMode = False
                Throw New OutOfMemoryException
            End If



            Dim imageo As Image = System.Drawing.Image.FromFile(setting.images.Item(i))
            Dim imgwidth As Single = 243 / imageo.Width
            Dim imgheight As Single = 142 / imageo.Height
            If (243 / 142) > (imageo.Width / imageo.Height) Then
                'Too wide to fit the ratio
                imgwidth = 243
                imgheight = imageo.Height * (243 / imageo.Width)
            Else
                'too narrow (or just right) for the ratio
                imgheight = 142
                imgwidth = imageo.Width * (142 / imageo.Height)
            End If

            Dim temp As Object = imageo.GetThumbnailImage(Int(imgwidth), Int(imgheight), val1, val2)
            If upd Then
                thumbs(i) = temp
            Else
                thumbs.Add(temp)
            End If

            Threading.Thread.Sleep(20)
            If upd Then
                'Do nothing
            Else
                preworker.ReportProgress(i)
            End If

        Catch ex As OutOfMemoryException
            preworker.ReportProgress(0, "oom2")

            If upd Then
                thumbs(i) = MetroKioskResources.My.Resources.noread
            Else
                thumbs.Add(MetroKioskResources.My.Resources.noread)
            End If
        Catch ex As Exception
            Try
                preworker.ReportProgress(0, "cor")
            Catch exe As Exception

            End Try


            If upd Then
                thumbs(i) = MetroKioskResources.My.Resources.noread
            Else
                thumbs.Add(MetroKioskResources.My.Resources.noread)
            End If
        End Try
    End Sub
    Private Sub preloadimg()
        sendlog("Preloader Started")
        Dim i As Integer = 0
        While i < setting.images.Count
            If preworker.CancellationPending = False Then
                doID(i)
                i = i + 1
                preworker.ReportProgress(i)
            End If
        End While
        sendlog("Preloader Finished")

    End Sub

    Private Sub preworker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles preworker.DoWork
        preloadimg()
    End Sub

    Private Sub preworker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles preworker.ProgressChanged
        If e.UserState = "oom" Then
            'overflowmode()
        ElseIf e.UserState = "oom2" Then
            errorbox("Unreadable Image", "One of the images we found on your device couldn't be read. " + vbNewLine + "We're going to continue, and you can still order prints for that file, but you won't see the preview. ")
        ElseIf e.UserState = "cor" Then
            If errorshown = False Then
                errorbox("Corrupt images found", "Some of the images we found on your device are corrupt, or in a format we cant show." + vbNewLine + "This means they cant be shown. PSD Files should be printable, but can't be displayed. ")
            End If
        Else
            galleryext.perc(e.ProgressPercentage)
        End If

    End Sub

    Public Sub overflowmode()
        preworker.CancelAsync()
        preworker.Dispose()
        Threading.Thread.Sleep(1000)

        galleryext.preprog.Visible = False
        If gallery.Visible = True Then
            gallery.Close()
            overflowhandler.Show()
            errorbox("We're going to take a moment to breathe...", "Due to the large amount of high-quality images on your device, we're going to have to make a few adjustments to how we load the pictures. " + vbNewLine + vbNewLine + "Don't worry, it wont do anything to your images on your device or your prints. It might take a bit of time though. ")
        Else
            Waituntilgallerytimer.Enabled = True
        End If

    End Sub

    Private Sub preloader_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

    End Sub

    Private Sub Waituntilgallerytimer_Tick(sender As Object, e As EventArgs) Handles Waituntilgallerytimer.Tick
        If gallery.Visible = True Then
            gallery.Close()
            overflowhandler.Show()
            errorbox("We're going to take a moment to breathe...", "Due to the large amount of high-quality images on your device, we're going to have to make a few adjustments to how we load the pictures. " + vbNewLine + vbNewLine + "Don't worry, it wont do anything to your images on your device or your prints. It might take a bit of time though. ")
            Waituntilgallerytimer.Enabled = False
        End If
    End Sub
End Class