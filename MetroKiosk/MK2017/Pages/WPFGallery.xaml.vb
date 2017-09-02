Imports System.IO
Imports System.Threading
Imports System.Windows.Controls.Primitives
Imports System.Windows.Media.Animation
Imports System.Windows.Threading

Class WPFGallery

    Dim FilesList As List(Of FileInfo) = Nothing
    Dim UIElementList As New List(Of GalleryControl)
    Dim _Disp As Dispatcher
    Dim _MW As MetroKioskWPF
    Dim _OrderName As String
    Dim ThreadList As New List(Of Thread)

    Public Sub New(MainWindow As MetroKioskWPF, Files As List(Of FileInfo), Name As String)

        ' This call is required by the designer.
        InitializeComponent()

        scrollViewer.Opacity = 0
        MainTranslation.X = 150
        FooterTranslation.Y = 80

        ' Add any initialization after the InitializeComponent() call.
        FilesList = Files

        GalleryContainer.Children.Clear()
        For Each File In Files
            Dim NewControl = New GalleryControl(File, 360, 300, _MW, Me)
            AddHandler NewControl.Adjusted, AddressOf AdjustHandler
            GalleryContainer.Children.Add(NewControl)
            UIElementList.Add(NewControl)
            Ordered(File) = New OrderedSizes
        Next

        SetSelectedSize(MainWindow.SizeID)
        _Disp = Me.Dispatcher
        _MW = MainWindow
        _OrderName = Name


    End Sub



    Dim ImageShowerHiderActive As Boolean = True
    Private Async Sub ImageShowerHider()
        While ImageShowerHiderActive
            If ScrollPositionChanged Then
                ScrollPositionChanged = False

                For Each UIelement In UIElementList
                    _Disp.BeginInvoke(Sub()
                                          Try
                                              UIelement.UpdateImageVisibility()
                                          Catch ex As Exception

                                          End Try

                                      End Sub, DispatcherPriority.Normal)
                Next
                ScrollPositionChanged = False
                Thread.Sleep(50)
            Else
                Thread.Sleep(50)
            End If
        End While
    End Sub

    Private Sub WorkerTasks()
        Thread.Sleep(250 + (New Random().Next(0, 150)))
        Dim StillControlsToDo As Boolean = True
        While StillControlsToDo
            Dim NextControl = ControlHunter()
            If Not NextControl Is Nothing Then
                Try
                    NextControl.StartLoading()
                Catch ex As Exception

                End Try
            Else
                StillControlsToDo = False
            End If
            Thread.Sleep(150)
        End While
        _Disp.BeginInvoke(Sub() _MW.FrameTitle.Text = "Select your pictures.")
    End Sub

    Private Function ControlHunter() As GalleryControl
        Try
            Dim returnable = UIElementList.First(Function(control) (Not (control.Loading Or control.Imageloaded) And control.OnScreen))
            Return returnable
        Catch ex As Exception

        End Try
        Try
            Dim returnable = UIElementList.First(Function(control) Not (control.Loading Or control.Imageloaded))
            Return returnable
        Catch ex As Exception

        End Try
        Return Nothing
    End Function


    Private Sub ScrollViewer_ManipulationBoundaryFeedback(sender As Object, e As Windows.Input.ManipulationBoundaryFeedbackEventArgs)
        e.Handled = True

    End Sub

    Public Sub StartLoaders()
        _Disp.BeginInvoke(Sub()
                              'Animate the page in
                              Dim SB2 As Storyboard = Me.FindResource("AnimateIn")
                              SB2.Begin()

                              Dim asd As New Thread(Sub()
                                                        'Set up threads
                                                        Dim Thread1 As New Thread(AddressOf WorkerTasks)
                                                        Dim Thread2 As New Thread(AddressOf WorkerTasks)
                                                        Thread1.IsBackground = True
                                                        Thread2.IsBackground = True
                                                        ThreadList.Add(Thread2)
                                                        ThreadList.Add(Thread1)
                                                        Thread1.Start()
                                                        Thread2.Start()

                                                        Dim ImageShowerThread As New Thread(AddressOf ImageShowerHider)
                                                        ImageShowerThread.IsBackground = True
                                                        ThreadList.Add(ImageShowerThread)
                                                        ImageShowerThread.Start()
                                                    End Sub)
                              asd.IsBackground = True
                              ThreadList.Add(asd)
                              asd.Start()

                          End Sub, DispatcherPriority.Background)



    End Sub


#Region "SizeSelector"

    Private Sub _6x4Toggle_Click(sender As Object, e As Windows.RoutedEventArgs) Handles _6x4Toggle.Click
        SetSelectedSize(Sizes.s6x4)
    End Sub
    Private Sub _7x5Toggle_Click(sender As Object, e As Windows.RoutedEventArgs) Handles _7x5Toggle.Click
        SetSelectedSize(Sizes.s7x5)
    End Sub
    Private Sub _8x6Toggle_Click(sender As Object, e As Windows.RoutedEventArgs) Handles _8x6Toggle.Click
        SetSelectedSize(Sizes.s8x6)
    End Sub
    Private Sub _8x10Toggle_Click(sender As Object, e As Windows.RoutedEventArgs) Handles _8x10Toggle.Click
        SetSelectedSize(Sizes.s8x10)
    End Sub
    Private Sub _10x12Toggle_Click(sender As Object, e As Windows.RoutedEventArgs) Handles _10x12Toggle.Click
        SetSelectedSize(Sizes.s10x12)
    End Sub

    Private Sub SetSelectedSize(Size As Sizes)
        _6x4Toggle.IsChecked = False
        _7x5Toggle.IsChecked = False
        _8x6Toggle.IsChecked = False
        _8x10Toggle.IsChecked = False
        _10x12Toggle.IsChecked = False
        Select Case (Size)
            Case Sizes.s6x4
                _6x4Toggle.IsChecked = True
            Case Sizes.s7x5
                _7x5Toggle.IsChecked = True
            Case Sizes.s8x6
                _8x6Toggle.IsChecked = True
            Case Sizes.s8x10
                _8x10Toggle.IsChecked = True
            Case Sizes.s10x12
                _10x12Toggle.IsChecked = True
        End Select
        CurrentSize = Size
        UpdateAllCountersWithSize(Size)
    End Sub

    Dim CurrentSize As Sizes

    Private Sub UpdateAllCountersWithSize(Size As Sizes)
        For Each control In UIElementList
            control.SetCounter(GetOrderedAmount(control.Loadable, Size))
        Next
    End Sub

    Private Function RecountSizeTotal(Size As Sizes) As Int32
        Select Case (Size)
            Case Sizes.s6x4
                Return Ordered.Sum(Function(a) a.Value.i6x4)
            Case Sizes.s7x5
                Return Ordered.Sum(Function(a) a.Value.i7x5)
            Case Sizes.s8x6
                Return Ordered.Sum(Function(a) a.Value.i8x6)
            Case Sizes.s8x10
                Return Ordered.Sum(Function(a) a.Value.i8x10)
            Case Sizes.s10x12
                Return Ordered.Sum(Function(a) a.Value.i10x12)
        End Select
    End Function

    Private Function GetSizeButton(Size As Sizes) As ToggleButton
        Select Case (Size)
            Case Sizes.s6x4
                Return _6x4Toggle
            Case Sizes.s7x5
                Return _7x5Toggle
            Case Sizes.s8x6
                Return _8x6Toggle
            Case Sizes.s8x10
                Return _8x10Toggle
            Case Sizes.s10x12
                Return _10x12Toggle

        End Select
    End Function

#End Region

#Region "Order bits"

    Dim Ordered As Dictionary(Of FileInfo, OrderedSizes) = New Dictionary(Of FileInfo, OrderedSizes)

    Private Sub AdjustHandler(Amount As Int32, File As FileInfo, Control As GalleryControl)
        AdjustOrderedAmount(File, CurrentSize, Amount)
        Control.SetCounter(GetOrderedAmount(File, CurrentSize))
        GetSizeButton(CurrentSize).Content = GetSizeButton(CurrentSize).Tag + $" ({RecountSizeTotal(CurrentSize)})"
    End Sub

    Private Function GetOrderedAmount(File As FileInfo, Size As Sizes) As Integer
        Select Case (Size)
            Case Sizes.s6x4
                Return Ordered(File).i6x4
            Case Sizes.s7x5
                Return Ordered(File).i7x5
            Case Sizes.s8x6
                Return Ordered(File).i8x6
            Case Sizes.s8x10
                Return Ordered(File).i8x10
            Case Sizes.s10x12
                Return Ordered(File).i10x12
        End Select
    End Function

    Private Sub AdjustOrderedAmount(File As FileInfo, Size As Sizes, Amount As Integer)
        Select Case (Size)
            Case Sizes.s6x4
                Ordered(File).i6x4 += Amount
                If Ordered(File).i6x4 < 0 Then Ordered(File).i6x4 = 0
            Case Sizes.s7x5
                Ordered(File).i7x5 += Amount
                If Ordered(File).i7x5 < 0 Then Ordered(File).i7x5 = 0
            Case Sizes.s8x6
                Ordered(File).i8x6 += Amount
                If Ordered(File).i8x6 < 0 Then Ordered(File).i8x6 = 0
            Case Sizes.s8x10
                Ordered(File).i8x10 += Amount
                If Ordered(File).i8x10 < 0 Then Ordered(File).i8x10 = 0
            Case Sizes.s10x12
                Ordered(File).i10x12 += Amount
                If Ordered(File).i10x12 < 0 Then Ordered(File).i10x12 = 0
        End Select
    End Sub

    Private Sub scrollViewer_ScrollChanged(sender As Object, e As Windows.Controls.ScrollChangedEventArgs) Handles scrollViewer.ScrollChanged
        ScrollPositionChanged = True
    End Sub

    Dim ScrollPositionChanged As Boolean = False

    Private Sub ScrollUpButton_Click(sender As Object, e As Windows.RoutedEventArgs) Handles ScrollUpButton.Click
        Try
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - ScrollAmt)
        Catch ex As Exception
            scrollViewer.ScrollToTop()
        End Try
    End Sub

    Dim ScrollAmt As Integer = 300

    Private Sub ScrollDownButton_Click(sender As Object, e As Windows.RoutedEventArgs) Handles ScrollDownButton.Click
        Try
            scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset + ScrollAmt)
        Catch ex As Exception
            scrollViewer.ScrollToBottom()
        End Try
    End Sub

    Private Sub AdjustAll(amount As Integer)
        For Each control In UIElementList
            AdjustOrderedAmount(control.Loadable, CurrentSize, amount)
            control.SetCounter(GetOrderedAmount(control.Loadable, CurrentSize))
            GetSizeButton(CurrentSize).Content = GetSizeButton(CurrentSize).Tag + $" ({RecountSizeTotal(CurrentSize)})"
        Next
    End Sub

    Private Sub RemoveAllButton_Click(sender As Object, e As Windows.RoutedEventArgs) Handles RemoveAllButton.Click
        AdjustAll(-1)
    End Sub

    Private Sub AddAllButton_Click(sender As Object, e As Windows.RoutedEventArgs) Handles AddAllButton.Click
        AdjustAll(1)
    End Sub

    Private Sub FinishedButton_Click(sender As Object, e As Windows.RoutedEventArgs) Handles FinishedButton.Click
        FakeNextPage()
    End Sub



    Private Sub FakeNextPage()

        Dim Hold As New Thread(Sub()
                                   Thread.Sleep(420)
                                   _Disp.Invoke(Sub() NextPage())
                               End Sub)
        Hold.Start()
    End Sub

    Private Sub NextPage()

        '
        _MW.ExpandFrame()
        Dim Process As New ProcessPage(Ordered, _OrderName, _MW)
        _MW.PushPage(Process)

        For Each item In ThreadList
            Try
                item.Abort()
            Catch ex As Exception

            End Try
        Next
    End Sub

#End Region

End Class
