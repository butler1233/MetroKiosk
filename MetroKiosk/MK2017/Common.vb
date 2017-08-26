Imports System.Drawing.Imaging
Imports System.IO
Imports System.Windows
Imports System.Windows.Media.Imaging

Public Module Common

    Function MakeImage(MaxWidth As Int32, MaxHeight As Int32, ByRef SourceImage As BitmapImage, SourceFileInfo As FileInfo, ByRef Ratio As Double) As BitmapImage
        'Load the file stream, because we'll need it twice.
        Dim Stream = LoadFileStreamToMemory(SourceFileInfo.FullName)
        Dim ImageData = Image.FromStream(Stream, False, False)
        Dim OriginalDimentions = ImageData.Size
        Dim UseWidthParam As Boolean = True
        If ImageData.Height > ImageData.Width Then UseWidthParam = False

        'Now we're done with that, reset the stream pos, and actually load the image
        Stream.Position = 0

        'Now start the actual load.
        SourceImage = New BitmapImage()
        SourceImage.BeginInit()
        If UseWidthParam Then
            SourceImage.DecodePixelWidth = MaxWidth
            Ratio = MaxWidth / OriginalDimentions.Width
        Else
            SourceImage.DecodePixelHeight = MaxHeight
            Ratio = MaxHeight / OriginalDimentions.Height
        End If

        SourceImage.CacheOption = BitmapCacheOption.OnDemand
        SourceImage.StreamSource = Stream
        SourceImage.EndInit()
        SourceImage.Freeze()
        Return SourceImage
    End Function

    Function LoadFileStreamToMemory(Filename As String) As MemoryStream
        Dim MemSt As New MemoryStream
        Dim FileSt As New FileStream(Filename, FileMode.Open, FileAccess.Read, FileShare.Read)
        FileSt.CopyTo(MemSt)
        FileSt.Close()
        FileSt.Dispose()
        'Reset the stream position ebcause we have literally no idea from here what's gonna happen with the data.
        MemSt.Position = 0
        Return MemSt
    End Function

    Function IsUserVisible(element As FrameworkElement, container As FrameworkElement) As Boolean
        If Not element.IsVisible Then
            Return False
        End If

        Dim bounds As Rect = element.TransformToAncestor(container).TransformBounds(New Rect(0.0, 0.0, element.ActualWidth, element.ActualHeight))
        Dim rect As New Rect(0.0, 0.0, container.ActualWidth, container.ActualHeight)
        Return rect.Contains(bounds.TopLeft) OrElse rect.Contains(bounds.BottomRight)
    End Function


End Module
