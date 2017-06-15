Public Class overflowhandler

    Dim step1done As Boolean = False
    Dim step2done As Boolean = False
    Dim step3done As Boolean = False
    Dim step4done As Boolean = False
    Dim calctime As Boolean = False
    Dim origthumbs As Integer
    Dim curstatus As Integer
    Dim ssf As Single = 0
    Dim loop1 As Integer
    Private Property val1 As Image.GetThumbnailImageAbort

    Private Property val2 As IntPtr


    Private Sub overflowhandler_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Dim bounds As Rectangle
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        Me.BackgroundImage = screenshot
        overflowactive = True
        worker.RunWorkerAsync()
        preloader.Close()
        preloader.Dispose()
    End Sub

    Private Sub overflowhandler_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub eta_Click(sender As Object, e As EventArgs) Handles eta.Click
        
    End Sub
    Private Sub sendmsg(msg As String)
        setting.sendlog(msg)
        worker.ReportProgress(0, msg)
    End Sub

    Private Sub worker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles worker.DoWork
        sendmsg("Worker Started")
        loop1 = 0
        sendmsg("//Loop = 0")
        'Remove the last one which might be a bit broken
        thumbs.Remove(thumbs.Count - 1)
        sendmsg("//Thumb removed")
        step1done = True
        sendmsg("//Step1done")
        'Step 1 now done
        sendmsg("Previous thumb removed")
        'Save the thmbnails we have now to the c:\mktemp

        While loop1 < thumbs.Count
            Dim cool As System.Drawing.Image
            cool = thumbs(loop1)
            sendmsg("saved old thumb " + loop1.ToString)
            cool.Save("C:\mktemp\thumb_" + loop1.ToString + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
            'That should do it

            sendmsg("Old thumbnail saved: " + (1 + loop1).ToString + " of " + images.Count.ToString)

            'increment for the next one
            loop1 = loop1 + 1
            sendmsg("loop1 incremented")
        End While
        sendmsg("all thumbs saved")
        step2done = True
        calctime = True
        'Step 2 done

        'This is going to be a long one
        loop1 = thumbs.Count
        origthumbs = thumbs.Count
        thumbs.Clear()
        sendmsg("starting to make new thumbs")
        While loop1 < images.Count
            'Generate the thumbnail
            Try

                Dim temp As System.Drawing.Image = System.Drawing.Image.FromFile(setting.images.Item(loop1)).GetThumbnailImage(243, 142, val1, val2)

                'save it
                temp.Save("C:\mktemp\thumb_" + loop1.ToString + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)

                'report progress
                worker.ReportProgress(loop1)

                'increment
                loop1 = loop1 + 1
                'THIS IS KILLING US APPARENTLY sendmsg("New thumbnail saved: " + (loop1).ToString + " of " + images.Count.ToString)
            Catch ex As Exception
                sendmsg(ex.Message + ": " + (1 + loop1).ToString + " of " + images.Count.ToString)
            End Try




        End While
        step3done = True
        'step 3 done
        sendmsg("done?")

        'what even is step4 
        step4done = True
        'its all ogre now
    End Sub

    Private Sub etaupdater_Tick(sender As Object, e As EventArgs) Handles etaupdater.Tick
        'Update the tickys
        If step4done Then
            text4.Font = New Font(text4.Font, FontStyle.Regular)
            tick4.Visible = True
            tick3.Visible = True
            text3.Font = New Font(text3.Font, FontStyle.Regular)
            text3.Text = "Creating the last few previews"
            etalab.Visible = False
            eta.Visible = False
            tick2.Visible = True
            text2.Font = New Font(text2.Font, FontStyle.Regular)
            tick1.Visible = True
            text1.Font = New Font(text1.Font, FontStyle.Regular)
            overflowactive = True
            gallery.Show()
            galleryext.Visible = True
            galleryext.preprog.Visible = False
            galleryext.Panel2.Visible = True
            Me.Close()
        ElseIf step3done Then
            text4.Font = New Font(text4.Font, FontStyle.Bold)
            tick3.Visible = True
            text3.Font = New Font(text3.Font, FontStyle.Regular)
            text3.Text = "Creating the last few previews"
            etalab.Visible = False
            eta.Visible = False
            tick2.Visible = True
            text2.Font = New Font(text2.Font, FontStyle.Regular)
            tick1.Visible = True
            text1.Font = New Font(text1.Font, FontStyle.Regular)
        ElseIf step2done Then
            text3.Font = New Font(text3.Font, FontStyle.Bold)
            tick2.Visible = True
            text2.Font = New Font(text2.Font, FontStyle.Regular)
            tick1.Visible = True
            text1.Font = New Font(text1.Font, FontStyle.Regular)
        ElseIf step1done Then
            text2.Font = New Font(text2.Font, FontStyle.Bold)
            tick1.Visible = True
            text1.Font = New Font(text1.Font, FontStyle.Regular)
        Else
            text1.Font = New Font(text2.Font, FontStyle.Bold)
        End If

        If calctime Then
            'Update the tiem elapsed so far
            ssf = ssf + 0.5

            'Update the ETA

            Dim secrem As Single = (ssf / (loop1 - origthumbs)) * (images.Count - origthumbs - loop1)
            If secrem = 0 Then
                secrem = 1
            ElseIf secrem = Single.PositiveInfinity Then
                secrem = 1
            ElseIf secrem = Single.NegativeInfinity Then
                secrem = 1
            End If
            Dim iSpan As TimeSpan = TimeSpan.FromSeconds(secrem)

            eta.Text = iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" & _
                                    iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" & _
                                    iSpan.Seconds.ToString.PadLeft(2, "0"c)
        End If
    End Sub

    Private Sub worker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles worker.ProgressChanged
        curstatus = e.ProgressPercentage
        text3.Text = "Creating the last few previews... (" + Math.Round((e.ProgressPercentage / (images.Count - origthumbs - 1)) * 100).ToString + "%)"
        debugtext.Text = e.UserState.ToString
    End Sub

    Private Sub debugtext_DoubleClick(sender As Object, e As EventArgs) Handles debugtext.DoubleClick
        Application.Exit()
    End Sub
End Class