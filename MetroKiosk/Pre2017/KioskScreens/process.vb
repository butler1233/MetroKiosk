Imports System.IO
Imports System.Text



Public Class process



    Dim cool As Single
    Public orderid As String
    Dim savedprints As New ArrayList
    Private Sub process_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sendnetcommand("STATE#Starting processor")
        'Show the new WPF loader, get rid of this ugly bastard

        WPFLoad.Show()
        Me.WindowState = FormWindowState.Minimized
        WPFLoad.Focus()


        realupdateprogress(0)

        guesstime(actotimg)
        orderid = "o_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + "_" + UserName
        preloader.preworker.CancelAsync()
        galleryext.Visible = False
        BackgroundProcessor.RunWorkerAsync()

    End Sub
    Private Sub updprogress(perc As Single)
        Try
            BackgroundProcessor.ReportProgress(perc)
        Catch e As Exception
            BackgroundProcessor.ReportProgress(50)
        End Try


    End Sub

    Private Sub realupdateprogress(perc As Single)
        Dim base As Single = (sizeaid * 20) + (perc / 5)
        Try
            progress.Width = base * 6.44
        Catch ex As Exception

        End Try
    End Sub

    Private Sub guesstime(imgs As Integer)
        Dim etas As Integer = 420
        etas = etas + (imgs * 10)
        If etas < 3600 Then
            ETA.Text = "about " + Math.Ceiling(etas / 60).ToString + " Minutes"
            sendlog("Kiosk job submitting with ETA: " + "about " + Math.Ceiling(etas / 60).ToString + " Minutes")
        Else
            ETA.Text = "Over an hour"
        End If
    End Sub

    Private Sub createmrk(folder As String)
        sendnetcommand("STATE#Generating DPOF")
        'Lets get the correct channel first
        If sizeaid = 0 Then
            sizechan = My.Settings.Size1Channel
        ElseIf sizeaid = 1 Then
            sizechan = My.Settings.Size2Channel
        ElseIf sizeaid = 2 Then
            sizechan = My.Settings.Size3Channel
        ElseIf sizeaid = 3 Then
            sizechan = My.Settings.Size4Channel
        ElseIf sizeaid = 4 Then
            sizechan = My.Settings.Size5Channel
        End If




        Dim miscfo As String = folder + "\MISC"
        My.Computer.FileSystem.CreateDirectory(miscfo)
        updprogress(2)
        Dim path As String = miscfo + "\AUTPRINT.MRK"
        Dim magicstring As String = ""
        'Do the initial bit of the file making

        magicstring = magicstring + "[HDR]" + vbNewLine + "GEN REV=01.00" + vbNewLine + "GEN CRT=""NORITSU KOKI"" -01.00" + vbNewLine + "GEN DTM=" + Date.Now.Year.ToString + ":" + Date.Now.Month.ToString + ":" + Date.Now.Day.ToString + ":" + Date.Now.Hour.ToString + ":" + Date.Now.Minute.ToString + ":" + Date.Now.Second.ToString + "" + vbNewLine + ""
        magicstring = magicstring + "USR NAM="" """ + vbNewLine + "VUQ RGN=BGN" + vbNewLine + "VUQ VNM=""NORITSU KOKI"" -ATR ""QSSPrint""" + vbNewLine + "VUQ VER=01.00" + vbNewLine + "PRT PSL=NML -PSIZE """ + sizename + """" + vbNewLine + ""
        magicstring = magicstring + "PRT PCH=" + sizechan + "" + vbNewLine + "GEN INP=""Other-M""" + vbNewLine + "VUQ RGN=END"
        updprogress(3)
        'Now to go through the images and add the ones which are wanted
        Dim loopy As Integer = 0
        sendlog("Checking Images for copy requests")
        While loopy < images.Count
            'First, establish if the image has prints
            If copies(loopy, sizeaid) > 0 Then
                'It does, great. Lets queue it to be saved and grab what index it is
                Dim savedindex As Integer
                Dim thisimage As String = Replace(images(loopy), images(loopy).ToString.Substring(0, 3), "")
                savedprints.Add(thisimage)
                savedindex = loopy
                'There, index saved, now lets generate the Autprint for it
                magicstring = magicstring + "" + vbNewLine + "" + vbNewLine + "[JOB]" + vbNewLine + "PRT PID=" + savedindex.ToString + "" + vbNewLine + "PRT TYP=STD" + vbNewLine + "PRT QTY=" + copies(loopy, sizeaid).ToString
                magicstring = magicstring + "" + vbNewLine + "IMG FMT=JFIF" + vbNewLine + "<IMG SRC=""..\IMAGE\" + thisimage + """>" + vbNewLine + "CFG DSC="" "" -ATR DTM" + vbNewLine + "VUQ RGN=BGN" + vbNewLine + "VUQ VNM=""NORITSU KOKI"" -ATR ""QSSPrint""" + vbNewLine + "VUQ VER=01.00"
                magicstring = magicstring + "" + vbNewLine + "PRT CVP1=1 -STR ""\\x0e\\xc1\\x0f The Photo Shop, CH62 7HH""" + vbNewLine + "PRT CVP2=0" + vbNewLine + "VUQ RGN=END"
            Else
                'It doesn't want to be printed. Let's skip it.
                sendlog("Image discarded due to no copies")
            End If

            'And finally increment it.
            loopy = loopy + 1
        End While
        updprogress(5)
        ' Create or overwrite the file. 
        Dim fs As FileStream = File.Create(path)

        ' Add text to the file. 
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(magicstring)
        fs.Write(info, 0, info.Length)
        fs.Close()
        updprogress(10)
        sendnetcommand("STATE#DPOF Generated")
    End Sub

    Private Function sizetotal(size) As Integer
        Dim looprunner As Integer = 0
        Dim sizetot As Integer = 0
        While looprunner < images.Count
            sizetot = sizetot + copies(looprunner, size)
            looprunner = looprunner + 1
        End While
        Return sizetot

    End Function

    Private Sub processOrder(size)
        Dim folder As String = My.Settings.StorageTarget + "\" + orderid + "_" + size.ToString
        sizeaid = size
        If sizetotal(size) > 0 Then
            My.Computer.FileSystem.CreateDirectory(folder)
            'updprogress(1) 'set the bar to 1%
            createmrk(folder) 'create the autprint
            movefiles(folder) 'move the images to where they should be
            BackgroundProcessor.ReportProgress(0, "recpr") 'print 
            sendnetcommand("STATE#Printing reciept")
        Else
            updprogress(100)
        End If
        savedprints.Clear()
    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Dim fakeargs As New System.ComponentModel.DoWorkEventArgs(2)
        'BackgroundProcessor_DoWork(sender, fakeargs)

    End Sub

    Private Sub deletebtfiles()
        sendnetcommand("STATE#Erasing bluetooth data")
        Try
            For Each foundFile As String In My.Computer.FileSystem.GetFiles("C:\b", Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*")

                My.Computer.FileSystem.DeleteFile(foundFile, _
                    Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, _
                    Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
            Next
        Catch ex As Exception

        End Try
        Try
            For Each foundFile As String In My.Computer.FileSystem.GetFiles("C:\e", Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.*")

                My.Computer.FileSystem.DeleteFile(foundFile, _
                    Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs, _
                    Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
            Next
        Catch ex As Exception

        End Try

    End Sub

    Private Sub movefiles(folder As String)
        sendnetcommand("STATE#Transferring files")
        Dim loopy2 As Integer = 0
        'start the loop
        While loopy2 < savedprints.Count
            Try
                My.Computer.FileSystem.CopyFile(images(0).ToString.Substring(0, 3) + savedprints(loopy2), folder + "\IMAGE\" + savedprints(loopy2))
            Catch ex As Exception
                My.Computer.FileSystem.CopyFile("C:\" + savedprints(loopy2), folder + "\IMAGE\" + savedprints(loopy2))
            End Try

            'System.Threading.Thread.Sleep(2)
            updprogress(10 + ((loopy2 / (savedprints.Count - 1)) * 90))
            'System.Threading.Thread.Sleep(10)
            loopy2 = loopy2 + 1
        End While
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        receipt.Show()
        realupdateprogress(100)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Timer1_Tick_1(sender, e)
    End Sub

    Private Sub BackgroundProcessor_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundProcessor.DoWork
        processOrder(0)
        sendlog("6x4 done")
        processOrder(1)
        sendlog("7x5 done")
        processOrder(2)
        sendlog("8x6 done")
        processOrder(3)
        sendlog("10x8 done")
        processOrder(4)
        sendlog("10x12 done")

        deletebtfiles()
        BackgroundProcessor.ReportProgress(100, "done")
        sendlog("async closed")
        sendnetcommand("STATE#Async jobs closed. Kiosk complete")

    End Sub

    Private Sub BackgroundProcessor_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundProcessor.ProgressChanged
        If e.UserState = "done" Then
            Me.Hide()
            finished.Show()
            finished.WindowState = FormWindowState.Minimized
            kioskWelcome.cancel.Visible = False
            WPFLoad.Focus()
            sendnetcommand("STATE#All Done, Remove device")
        ElseIf e.UserState = "recpr" Then
            receipt.Show()
        Else
            realupdateprogress(e.ProgressPercentage)
        End If
    End Sub
End Class