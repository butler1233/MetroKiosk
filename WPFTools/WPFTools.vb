Imports System.Runtime.InteropServices
Imports System.IO
Imports System
Imports System.drawing

Module WPFTools

    <DllImport("gdi32")> _
    Private Function DeleteObject(o As IntPtr) As Integer
    End Function

    Public Function ImageToBase64(image As System.Drawing.Image) As String
        Dim ms As New MemoryStream

        With New MemoryStream()
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
            Dim imageBytes() As Byte = ms.ToArray
            Dim base64String As String = Convert.ToBase64String(imageBytes)
            Return base64String
        End With

    End Function

    Public Function BitmapToBitmapSource(source As System.Drawing.Bitmap) As BitmapSource
        Dim ip As IntPtr = source.GetHbitmap()
        Dim bs As BitmapSource
        Try
            bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip, IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions())
        Catch ex As Exception

        Finally
            DeleteObject(ip)
        End Try
        Return bs
    End Function


End Module