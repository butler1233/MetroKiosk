Imports System.Runtime.InteropServices
Imports System.IO
Imports System
Imports System.Drawing
Imports System.Windows.Media.Animation
Imports System.Windows.Threading

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
        Dim bs As BitmapSource = Nothing
        Try
            bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip, IntPtr.Zero, Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions())
        Catch ex As Exception

        Finally
            DeleteObject(ip)
        End Try
        Return bs
    End Function

    ''' Background Animation section
    Dim DispatchInit As Boolean = False
    Dim LoadColorActive As Boolean = False
    Dim CDPContext As Object
    Dim CDPColorState As Integer = 0

    Dim colordispatchTimer As New DispatcherTimer()

    Private Sub InitCDP()
        ColorLoadAnimatorRunner()
        If DispatchInit = False Then
            AddHandler colordispatchTimer.Tick, AddressOf ColorLoadAnimatorRunner
            colordispatchTimer.Interval = New TimeSpan(0, 0, 4)
            colordispatchTimer.Start()
        End If
    End Sub

    Public Sub AnimateBG(Context As Object, TargetColor As System.Windows.Media.Color, Seconds As Double)

        Dim BGColorAnimation As New ColorAnimation()
        BGColorAnimation.To = TargetColor
        BGColorAnimation.Duration = TimeSpan.FromSeconds(Seconds)
        Storyboard.SetTargetName(BGColorAnimation, "BGCol")
        Storyboard.SetTargetProperty(BGColorAnimation, New PropertyPath(SolidColorBrush.ColorProperty))
        Dim BGStoryboard As New Storyboard()
        BGStoryboard.Children.Add(BGColorAnimation)
        BGStoryboard.Begin(Context)
    End Sub

    Public Sub StartBGLoadColorAnimation(Context As Object)
        InitCDP()
        CDPContext = Context
        LoadColorActive = True
    End Sub
    Public Sub StopBGLoadColorAnimation()
        LoadColorActive = False
    End Sub

    Private Sub ColorLoadAnimatorRunner()
        If LoadColorActive = True Then
            CDPColorState = CDPColorState + 1
            Select Case CDPColorState
                Case 1
                    AnimateBG(CDPContext, Colors.PaleTurquoise, 4)
                Case 2
                    AnimateBG(CDPContext, Colors.LightGreen, 4)
                Case 3
                    AnimateBG(CDPContext, Colors.LightYellow, 4)
                Case 4
                    AnimateBG(CDPContext, Colors.LightSalmon, 4)
                Case 5
                    AnimateBG(CDPContext, Colors.PaleVioletRed, 4)
                Case 6
                    AnimateBG(CDPContext, Colors.LightPink, 4)
                Case 7
                    AnimateBG(CDPContext, Colors.LightBlue, 4)
                Case Else
                    CDPColorState = 1
                    AnimateBG(CDPContext, Colors.LightBlue, 4)
            End Select
        End If
    End Sub

End Module