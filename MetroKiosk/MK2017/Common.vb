Imports System.Drawing.Imaging
Imports System.IO
Imports System.Windows
Imports System.Windows.Media.Imaging

Public Module Common

    Function MakeImage(MaxWidth As Int32, MaxHeight As Int32, SourceFileInfo As FileInfo, ByRef Ratio As Double) As BitmapImage

        Dim multiplier As Single = 1

        MaxWidth = MaxWidth * multiplier
        MaxHeight = MaxHeight * multiplier


        'Load the file stream, because we'll need it twice.
        Dim Stream = LoadFileStreamToMemory(SourceFileInfo.FullName)
        Dim ImageData = Image.FromStream(Stream, False, False)
        Dim OriginalDimentions = ImageData.Size
        Dim UseWidthParam As Boolean = True
        If ImageData.Height > ImageData.Width Then UseWidthParam = False

        'Now we're done with that, reset the stream pos, and actually load the image
        Stream.Position = 0

        'Now start the actual load.
        Dim SourceImage As New BitmapImage()
        SourceImage.BeginInit()
        If UseWidthParam Then
            SourceImage.DecodePixelWidth = MaxWidth
            Ratio = MaxWidth / OriginalDimentions.Width
        Else
            SourceImage.DecodePixelHeight = MaxHeight
            Ratio = MaxHeight / OriginalDimentions.Height
        End If

        SourceImage.CacheOption = BitmapCacheOption.OnLoad
        SourceImage.StreamSource = Stream
        SourceImage.EndInit()
        SourceImage.Freeze()

        Return SourceImage
    End Function

    Public Function GetPricingLevel(Size As Sizes, Amount As Int32) As Double
        Select Case Size
            Case Sizes.s6x4
                If Amount > My.Settings.PriceBand3Max Then
                    Return My.Settings.Size1Price4
                ElseIf Amount > My.Settings.PriceBand2Max Then
                    Return My.Settings.Size1Price3
                ElseIf Amount > My.Settings.PriceBand1Max Then
                    Return My.Settings.Size1Price2
                Else
                    Return My.Settings.Size1Price1
                End If
            Case Sizes.s7x5
                If Amount > My.Settings.PriceBand3Max Then
                    Return My.Settings.Size2Price4
                ElseIf Amount > My.Settings.PriceBand2Max Then
                    Return My.Settings.Size2Price3
                ElseIf Amount > My.Settings.PriceBand1Max Then
                    Return My.Settings.Size2Price2
                Else
                    Return My.Settings.Size2Price1
                End If
            Case Sizes.s8x6
                If Amount > My.Settings.PriceBand3Max Then
                    Return My.Settings.Size3Price4
                ElseIf Amount > My.Settings.PriceBand2Max Then
                    Return My.Settings.Size3Price3
                ElseIf Amount > My.Settings.PriceBand1Max Then
                    Return My.Settings.Size3Price2
                Else
                    Return My.Settings.Size3Price1
                End If
            Case Sizes.s8x10
                If Amount > My.Settings.PriceBand3Max Then
                    Return My.Settings.Size4Price4
                ElseIf Amount > My.Settings.PriceBand2Max Then
                    Return My.Settings.Size4Price3
                ElseIf Amount > My.Settings.PriceBand1Max Then
                    Return My.Settings.Size4Price2
                Else
                    Return My.Settings.Size4Price1
                End If
            Case Sizes.s10x12
                If Amount > My.Settings.PriceBand3Max Then
                    Return My.Settings.Size5Price4
                ElseIf Amount > My.Settings.PriceBand2Max Then
                    Return My.Settings.Size5Price3
                ElseIf Amount > My.Settings.PriceBand1Max Then
                    Return My.Settings.Size5Price2
                Else
                    Return My.Settings.Size5Price1
                End If
        End Select
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
        Return rect.Contains(bounds.TopLeft) OrElse rect.Contains(bounds.BottomRight)       'Partially Visible
        'Return rect.Contains(bounds)                                                        'Completely visible
    End Function


End Module
