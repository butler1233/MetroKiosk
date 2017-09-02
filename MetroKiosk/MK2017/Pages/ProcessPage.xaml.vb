Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Windows.Threading
Imports ImageProcessor.Imaging.Formats

Class ProcessPage

    Dim _Mw As MetroKioskWPF
    ReadOnly _orderName As String
    ReadOnly _orderedData As Dictionary(Of FileInfo, OrderedSizes)
    ReadOnly _disp As Dispatcher
    ReadOnly _orderTime As DateTime = DateTime.Now
    Dim TempFolder As String = "C:\imagetemp\"
    Dim Receipts As New List(Of ReceiptData)

    Public Sub New(ordered As Dictionary(Of FileInfo, OrderedSizes), orderName As String, mainWindow As MetroKioskWPF)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _Mw = mainWindow
        _orderName = orderName
        _orderedData = ordered
        _disp = Me.Dispatcher


        FileNames.Text = ""
        ProcessNames.Text = ""

        OrderNameAndDate.Text = _orderName + vbNewLine + _orderTime.ToString("HH:mm:ss")

        Dim processingThread As New Thread(AddressOf ProcessThread)
        processingThread.Start()
    End Sub

    Private Sub ProcessThread()
        Thread.Sleep(1500)


        Dim usableImages = GetOrderedImages()

        'Resave any PNGs as JPGs if we have any.
        If usableImages.Any(Function(info As FileInfo) info.Extension.ToLower() = ".png") Then
            'We'll have to do the PNG process.
            usableImages = ConvertPNGs(usableImages.Where(Function(info As FileInfo) info.Extension.ToLower() = ".png"), usableImages)
        End If

        'We need to process each size individually
        Dim Size1Entries = GetEntriesForSize(Sizes.s6x4)
        If Size1Entries.Count > 0 Then
            'Process 6x4

            'Now we need to copy the images. But first we need to set ourselves up with some folders.
            Dim NewFolder = My.Settings.StorageTarget + "\o_" + _orderTime.ToString("yyyyMMdd_HHmmss") + "_6x4_" + _orderName + "\"
            Dim imageFolder = NewFolder + "IMAGE\"
            Dim miscFolder = NewFolder + "MISC\"
            'Then we need to make the folder structore.
            System.IO.Directory.CreateDirectory(NewFolder)
            System.IO.Directory.CreateDirectory(imageFolder)
            System.IO.Directory.CreateDirectory(miscFolder)

            Dim RelativeFiles As New Dictionary(Of FileInfo, String)

            'Then we can start the copying.
            CopyImages(usableImages, imageFolder, RelativeFiles, "6x4")

            'Generate the Automrk
            UpdateFilename("")
            UpdateProcess("Generating 6x4 Order Details")
            SetProgress(0)
            Dim magicstring As String = GenerateAutoMrkString(Size1Entries, RelativeFiles, "6x4", My.Settings.Size1Channel)
            WriteAutoMrk(magicstring, miscFolder)

            'asd
            Dim totalPrints As Integer
            For Each entry In Size1Entries
                totalPrints += entry.Value
            Next

            'ReceiptData recording.
            Dim RD As New ReceiptData
            RD.SizeText = "6x4"
            RD.Amount = totalPrints
            RD.PriceLevel = Common.GetPricingLevel(Sizes.s6x4, totalPrints)

            Receipts.Add(RD)
        End If

        'We need to process each size individually
        Dim Size2Entries = GetEntriesForSize(Sizes.s7x5)
        If Size2Entries.Count > 0 Then
            'Process 6x4

            'Now we need to copy the images. But first we need to set ourselves up with some folders.
            Dim NewFolder = My.Settings.StorageTarget + "\o_" + _orderTime.ToString("yyyyMMdd_HHmmss") + "_7x5_" + _orderName + "\"
            Dim imageFolder = NewFolder + "IMAGE\"
            Dim miscFolder = NewFolder + "MISC\"
            'Then we need to make the folder structore.
            System.IO.Directory.CreateDirectory(NewFolder)
            System.IO.Directory.CreateDirectory(imageFolder)
            System.IO.Directory.CreateDirectory(miscFolder)

            Dim RelativeFiles As New Dictionary(Of FileInfo, String)

            'Then we can start the copying.
            CopyImages(usableImages, imageFolder, RelativeFiles, "7x5")

            'Generate the Automrk
            UpdateFilename("")
            UpdateProcess("Generating 7x5 Order Details")
            SetProgress(0)
            Dim magicstring As String = GenerateAutoMrkString(Size2Entries, RelativeFiles, "7x5", My.Settings.Size2Channel)
            WriteAutoMrk(magicstring, miscFolder)

            'asd
            Dim totalPrints As Integer
            For Each entry In Size2Entries
                totalPrints += entry.Value
            Next

            'ReceiptData recording.
            Dim RD As New ReceiptData
            RD.SizeText = "7x5"
            RD.Amount = totalPrints
            RD.PriceLevel = Common.GetPricingLevel(Sizes.s7x5, totalPrints)

            Receipts.Add(RD)
        End If

        'We need to process each size individually
        Dim Size3Entries = GetEntriesForSize(Sizes.s8x6)
        If Size3Entries.Count > 0 Then
            'Process 6x4

            'Now we need to copy the images. But first we need to set ourselves up with some folders.
            Dim NewFolder = My.Settings.StorageTarget + "\o_" + _orderTime.ToString("yyyyMMdd_HHmmss") + "_8x6_" + _orderName + "\"
            Dim imageFolder = NewFolder + "IMAGE\"
            Dim miscFolder = NewFolder + "MISC\"
            'Then we need to make the folder structore.
            System.IO.Directory.CreateDirectory(NewFolder)
            System.IO.Directory.CreateDirectory(imageFolder)
            System.IO.Directory.CreateDirectory(miscFolder)

            Dim RelativeFiles As New Dictionary(Of FileInfo, String)

            'Then we can start the copying.
            CopyImages(usableImages, imageFolder, RelativeFiles, "8x6")

            'Generate the Automrk
            UpdateFilename("")
            UpdateProcess("Generating 8x6 Order Details")
            SetProgress(0)
            Dim magicstring As String = GenerateAutoMrkString(Size3Entries, RelativeFiles, "8x6", My.Settings.Size3Channel)
            WriteAutoMrk(magicstring, miscFolder)

            'asd
            Dim totalPrints As Integer
            For Each entry In Size3Entries
                totalPrints += entry.Value
            Next

            'ReceiptData recording.
            Dim RD As New ReceiptData
            RD.SizeText = "8x6"
            RD.Amount = totalPrints
            RD.PriceLevel = Common.GetPricingLevel(Sizes.s8x6, totalPrints)

            Receipts.Add(RD)
        End If

        'We need to process each size individually
        Dim Size4Entries = GetEntriesForSize(Sizes.s8x10)
        If Size4Entries.Count > 0 Then
            'Process 6x4

            'Now we need to copy the images. But first we need to set ourselves up with some folders.
            Dim NewFolder = My.Settings.StorageTarget + "\o_" + _orderTime.ToString("yyyyMMdd_HHmmss") + "_8x10_" + _orderName + "\"
            Dim imageFolder = NewFolder + "IMAGE\"
            Dim miscFolder = NewFolder + "MISC\"
            'Then we need to make the folder structore.
            System.IO.Directory.CreateDirectory(NewFolder)
            System.IO.Directory.CreateDirectory(imageFolder)
            System.IO.Directory.CreateDirectory(miscFolder)

            Dim RelativeFiles As New Dictionary(Of FileInfo, String)

            'Then we can start the copying.
            CopyImages(usableImages, imageFolder, RelativeFiles, "8x10")

            'Generate the Automrk
            UpdateFilename("")
            UpdateProcess("Generating 8x10 Order Details")
            SetProgress(0)
            Dim magicstring As String = GenerateAutoMrkString(Size4Entries, RelativeFiles, "8x10", My.Settings.Size4Channel)
            WriteAutoMrk(magicstring, miscFolder)

            'asd
            Dim totalPrints As Integer
            For Each entry In Size4Entries
                totalPrints += entry.Value
            Next

            'ReceiptData recording.
            Dim RD As New ReceiptData
            RD.SizeText = "8x10"
            RD.Amount = totalPrints
            RD.PriceLevel = Common.GetPricingLevel(Sizes.s8x10, totalPrints)

            Receipts.Add(RD)
        End If

        'We need to process each size individually
        Dim Size5Entries = GetEntriesForSize(Sizes.s10x12)
        If Size5Entries.Count > 0 Then
            'Process 6x4

            'Now we need to copy the images. But first we need to set ourselves up with some folders.
            Dim NewFolder = My.Settings.StorageTarget + "\o_" + _orderTime.ToString("yyyyMMdd_HHmmss") + "_10x12_" + _orderName + "\"
            Dim imageFolder = NewFolder + "IMAGE\"
            Dim miscFolder = NewFolder + "MISC\"
            'Then we need to make the folder structore.
            System.IO.Directory.CreateDirectory(NewFolder)
            System.IO.Directory.CreateDirectory(imageFolder)
            System.IO.Directory.CreateDirectory(miscFolder)

            Dim RelativeFiles As New Dictionary(Of FileInfo, String)

            'Then we can start the copying.
            CopyImages(usableImages, imageFolder, RelativeFiles, "10x12")

            'Generate the Automrk
            UpdateFilename("")
            UpdateProcess("Generating 10x12 Order Details")
            SetProgress(0)
            Dim magicstring As String = GenerateAutoMrkString(Size5Entries, RelativeFiles, "10x12", My.Settings.Size5Channel)
            WriteAutoMrk(magicstring, miscFolder)

            'asd
            Dim totalPrints As Integer
            For Each entry In Size5Entries
                totalPrints += entry.Value
            Next

            'ReceiptData recording.
            Dim RD As New ReceiptData
            RD.SizeText = "10x12"
            RD.Amount = totalPrints
            RD.PriceLevel = Common.GetPricingLevel(Sizes.s10x12, totalPrints)

            Receipts.Add(RD)
        End If

        'We're done copying,we need to generate the automrk, print and we're done.
        SetProgress(0)
        UpdateProcess("Printing Receipt")
        UpdateFilename("")
        StaticReceiptData.OrderName = _ordername
        StaticReceiptData.OrderTime = _orderTime 
        StaticReceiptData.OrderData = Receipts
        Main.ReceiptPrinter.Print()
        UpdateProcess("Completed.")
        _disp.BeginInvoke(sub() MoveToCompleted )
    End Sub

#Region "Subprocesses"
    
    Private Sub MoveToCompleted()
        Dim CompletePage as new Completed(_Mw)
        _Mw.PushPage(CompletePage)
    End Sub

    Private Sub WriteAutoMrk(Content As String, Folder As String)
        Dim path As String = Folder + "AUTPRINT.MRK"

        ' Create or overwrite the file. 
        Dim fs As FileStream = File.Create(path)

        ' Add text to the file. 
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(Content)
        fs.Write(info, 0, info.Length)
        fs.Close()
    End Sub

    Private Function GetOrderedImages() As List(Of FileInfo)
        UpdateProcess("Collecting Images")
        Dim kvps = _orderedData.Where(Function(pair) pair.Value.i6x4 > 0 Or pair.Value.i7x5 > 0 Or pair.Value.i8x6 > 0 Or pair.Value.i8x10 > 0 Or pair.Value.i10x12 > 0).ToList()
        Dim Fileinfos As New List(Of FileInfo)
        For Each item In kvps
            Fileinfos.Add(item.Key)
        Next
        Return Fileinfos
    End Function

    Private Function GetEntriesForSize(Size As Sizes) As Dictionary(Of FileInfo, Integer)
        Dim kvps As List(Of KeyValuePair(Of FileInfo, OrderedSizes))
        Dim returnable As New Dictionary(Of FileInfo, Integer)

        Select Case Size
            Case Sizes.s6x4
                kvps = _orderedData.Where(Function(pair) pair.Value.i6x4 > 0).ToList()
                For Each item In kvps
                    returnable.Add(item.Key, item.Value.i6x4)
                Next
                Return returnable
            Case Sizes.s7x5
                kvps = _orderedData.Where(Function(pair) pair.Value.i7x5 > 0).ToList()
                For Each item In kvps
                    returnable.Add(item.Key, item.Value.i7x5)
                Next
                Return returnable
            Case Sizes.s8x6
                kvps = _orderedData.Where(Function(pair) pair.Value.i8x6 > 0).ToList()
                For Each item In kvps
                    returnable.Add(item.Key, item.Value.i8x6)
                Next
                Return returnable
            Case Sizes.s8x10
                kvps = _orderedData.Where(Function(pair) pair.Value.i8x10 > 0).ToList()
                For Each item In kvps
                    returnable.Add(item.Key, item.Value.i8x10)
                Next
                Return returnable
            Case Sizes.s10x12
                kvps = _orderedData.Where(Function(pair) pair.Value.i10x12 > 0).ToList()
                For Each item In kvps
                    returnable.Add(item.Key, item.Value.i10x12)
                Next
                Return returnable
        End Select
    End Function

    Private Function GenerateAutoMrkString(Content As Dictionary(Of FileInfo, Integer), RelativeNames As Dictionary(Of FileInfo, String), SizeText As String, PrintChannel As String) As String

        Dim magicstring As String = ""
        'Do the initial bit of the file making

        magicstring = magicstring + "[HDR]" + vbNewLine + "GEN REV=01.00" + vbNewLine + "GEN CRT=""NORITSU KOKI"" -01.00" + vbNewLine + "GEN DTM=" + Date.Now.Year.ToString + ":" + Date.Now.Month.ToString + ":" + Date.Now.Day.ToString + ":" + Date.Now.Hour.ToString + ":" + Date.Now.Minute.ToString + ":" + Date.Now.Second.ToString + "" + vbNewLine + ""
        magicstring = magicstring + "USR NAM="" """ + vbNewLine + "VUQ RGN=BGN" + vbNewLine + "VUQ VNM=""NORITSU KOKI"" -ATR ""QSSPrint""" + vbNewLine + "VUQ VER=01.00" + vbNewLine + "PRT PSL=NML -PSIZE """ + SizeText + """" + vbNewLine + ""
        magicstring = magicstring + "PRT PCH=" + PrintChannel + "" + vbNewLine + "GEN INP=""Other-M""" + vbNewLine + "VUQ RGN=END"

        Dim entryInt = 0
        For Each entry In Content

            Dim RelativeFileName As String = RelativeNames(entry.Key)

            magicstring = magicstring + "" + vbNewLine + "" + vbNewLine + "[JOB]" + vbNewLine + "PRT PID=" + entryInt.ToString + "" + vbNewLine + "PRT TYP=STD" + vbNewLine + "PRT QTY=" + entry.Value.ToString
            magicstring = magicstring + "" + vbNewLine + "IMG FMT=JFIF" + vbNewLine + "<IMG SRC=""..\IMAGE\" + RelativeFileName + """>" + vbNewLine + "CFG DSC="" "" -ATR DTM" + vbNewLine + "VUQ RGN=BGN" + vbNewLine + "VUQ VNM=""NORITSU KOKI"" -ATR ""QSSPrint""" + vbNewLine + "VUQ VER=01.00"
            magicstring = magicstring + "" + vbNewLine + "PRT CVP1=1 -STR ""\\x0e\\xc1\\x0f The Photo Shop, CH62 7HH""" + vbNewLine + "PRT CVP2=0" + vbNewLine + "VUQ RGN=END"

            entryInt += 1
        Next

        Return magicstring

    End Function


    Private Function ConvertPNGs(pngs As IEnumerable(Of FileInfo), usables As List(Of FileInfo)) As List(Of FileInfo)
        UpdateProcess("Converting PNG files")
        'This is the factory we're gonna use.
        Dim factory As New ImageProcessor.ImageFactory(False)
        'And this is the jpeg quality formatter we're gonna use to save it.
        Dim format As New JpegFormat
        format.Quality = 100

        Dim ConvertedFiles As New Dictionary(Of FileInfo, FileInfo) 'Will store the old and new fileinfos so we can sort the references out afterwards.
        SetProgressMax(pngs.Count)
        SetProgress(0)
        Dim Counter As Integer = 0
        For Each item In pngs
            UpdateFilename(item.Name)
            'Generate the new filename by just saving it in it's new place.
            Dim newFileName As String = item.FullName.Replace(item.Extension, ".jpg").Replace(_Mw.SourceFolder.FullName, TempFolder)
            'Load then save the file
            factory.Load(item.FullName).Format(format).Save(newFileName)
            'We should be good. Need to get a new Fileinfo for the new file then add it to the list of changed ones so we can newly refernce it
            Dim NewFileInfo As New FileInfo(newFileName)
            ConvertedFiles.Add(item, NewFileInfo)
            Counter += 1
            SetProgress(Counter)
        Next
        UpdateProcess("Updating References")
        UpdateFilename("")
        'Now we can update the references in the Ordered. The we'll have to also add the new ones and remove the old ones from the usables.
        For Each item In ConvertedFiles
            'Add the new one but with the same ordered data.
            _orderedData.Add(item.Value, _orderedData(item.Key))
            'Remove the old one
            _orderedData.Remove(item.Key)

            'Then do the same for the usables. 
            usables.Add(item.Value)
            usables.Remove(item.Key)
        Next
        'Now we should be done.
        Return usables
    End Function

    Private Sub CopyImages(images As List(Of FileInfo), folder As String, ByRef relativenames As Dictionary(Of FileInfo, String), SizeText As String)
        UpdateProcess("Copying " + SizeText + " Images")
        SetProgressMax(images.Count)
        SetProgress(0)
        Dim Counter As Integer = 0
        For Each file In images
            UpdateFilename(file.Name)
            Dim newfilename As String = file.FullName
            If newfilename.StartsWith(_Mw.SourceFolder.FullName) Then
                newfilename = newfilename.Replace(_Mw.SourceFolder.FullName, folder)
            Else
                newfilename = newfilename.Replace(TempFolder, folder)
            End If
            'Add the folder to the relative.
            relativenames.Add(file, newfilename.Replace(folder, ""))

            'Create the fodler first if we haven't al;ready
            Try
                System.IO.Directory.CreateDirectory(newfilename.Replace(file.Name, ""))
            Catch ex As Exception

            End Try

            System.IO.File.Copy(file.FullName, newfilename)
            Counter += 1
            SetProgress(Counter)
        Next
    End Sub

#End Region


#Region "UI udpating"

    Private Sub UpdateFilename(File As String)
        _disp.BeginInvoke(Sub() FileNames.Text += vbNewLine + File, DispatcherPriority.Render)
    End Sub

    Private Sub UpdateProcess(Proc As String)
        _disp.BeginInvoke(Sub() ProcessNames.Text += vbNewLine + Proc, DispatcherPriority.Render)
    End Sub

    Private Sub SetProgressMax(max As Integer)
        _disp.BeginInvoke(Sub() progbar.Maximum = max, DispatcherPriority.Render)
    End Sub

    Private Sub SetProgress(prog As Integer)
        _disp.BeginInvoke(Sub() progbar.Value = prog, DispatcherPriority.Render)
    End Sub

#End Region
End Class
