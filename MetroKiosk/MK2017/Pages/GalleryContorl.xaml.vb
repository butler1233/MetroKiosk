Imports System.IO
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Imaging
Imports System.Windows.Threading

Public Class GalleryControl

    Public Loadable As FileInfo = Nothing
    Dim Disp As Dispatcher = Nothing
    Public Imageloaded As Boolean = False
    Public Loading As Boolean = False
    Public OnScreen As Boolean = False

    Dim _Mw As MetroKioskWPF
    Dim _Gp As WPFGallery

    Dim ImgWidth As Double
    Dim ImgHeight As Double

    Public Property LoadingText As String
        Set(value As String)
            LoadingTextBlock.Text = value
        End Set
        Get
            Return LoadingTextBlock.Text
        End Get
    End Property

    Private Sub hideLoadText()
        Dim s As Storyboard = FindResource("HideLoader")
        s.Begin()
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(File As FileInfo, Width As Int16, Height As Int16, MainWindow As MetroKioskWPF, GalleryPage As WPFGallery)

        ' This call is required by the designer.
        InitializeComponent()

        _Mw = MainWindow
        _Gp = GalleryPage

        ' Add any initialization after the InitializeComponent() call.
        Loadable = File
        Disp = Me.Dispatcher
        Filename.Text = File.Name
        ImgWidth = Width
        ImgHeight = Height
        Me.Width = Width
        Me.Height = Height
    End Sub

    Dim permasource As BitmapImage = Nothing

    ''' <summary>
    ''' Must be started from an non-UI thread.
    ''' </summary>
    Public Sub StartLoading()
        Loading = True
        Try
            Disp.BeginInvoke(Sub() LoadingText = "Loading Image")
            Dim Ratio As Double
            permasource = Common.MakeImage(ImgWidth, ImgHeight, Loadable, Ratio)
            Disp.BeginInvoke(Sub()
                                 If Common.IsUserVisible(Me, _Gp.scrollViewer) Then
                                     ImageHolder.Source = permasource
                                 End If


                             End Sub)

            Disp.BeginInvoke(Sub() hideLoadText())
        Catch ex As Exception
            Disp.BeginInvoke(Sub() LoadingText = "Load Failed")

        End Try
        Imageloaded = True
    End Sub

    Private Sub userControl_IsHitTestVisibleChanged(sender As Object, e As Windows.DependencyPropertyChangedEventArgs) Handles userControl.IsHitTestVisibleChanged
        OnScreen = Me.IsHitTestVisible
    End Sub

    Public Event Adjusted(Amount As Int32, File As FileInfo, Control As GalleryControl)

    Private Sub AddButton_Click(sender As Object, e As Windows.RoutedEventArgs) Handles AddButton.Click
        RaiseEvent Adjusted(1, Loadable, Me)
    End Sub

    Private Sub MinusButton_Click(sender As Object, e As Windows.RoutedEventArgs) Handles MinusButton.Click
        RaiseEvent Adjusted(-1, Loadable, Me)
    End Sub

    Dim prevValue As Int32 = 0

    Public Sub SetCounter(Amount As Int32)
        If Amount > 1 Then
            OrderedCountText.Text = $"{Amount} prints"
        Else
            OrderedCountText.Text = "1 print"
        End If

        If Amount < 1 Then
            If Not prevValue = 0 Then
                Dim sb As Storyboard = FindResource("HideMinusAndCount")
                sb.Begin()
            End If
            OrderedCountText.Text = "0 prints"
        Else
            If prevValue = 0 Then
                Dim sb As Storyboard = FindResource("ShowMinusAndCount")
                sb.Begin()
            End If
        End If

        prevValue = Amount

    End Sub

    Public Sub UpdateImageVisibility()
        If Common.IsUserVisible(Me, _Gp.scrollViewer) Then
            'We're visible
            If ImageHolder.Source Is Nothing And Not permasource Is Nothing Then
                ImageHolder.Source = permasource
            End If
        Else
            'We're not visible
            If Not ImageHolder.Source Is Nothing Then
                ImageHolder.Source = Nothing
            End If
        End If

    End Sub
End Class
