Imports System.Collections.Concurrent
Imports System.IO
Imports System.Threading
Imports System.Windows.Controls.Primitives
Imports System.Windows.Media.Animation
Imports System.Windows.Threading
Imports ImageProcessor

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

        VisibilityUpdateDelay = New Thread(AddressOf VisibilityUpdateDelayer)

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

        TotalControls = Files.Count
        
    End Sub

    #Region "2018 update"
    'Improved 2018 bits
    Dim ToggleVisibleQueue as new Queue(Of GalleryControl)
    Dim ToggleInvisibleQueue as new Queue(of GalleryControl)

    Dim QueuesUpdating as Boolean = True    'Starts true so the workers don't immediately give up.
    Dim LoadVisibleQueue as new ConcurrentQueue(Of GalleryControl)
    Dim LoadInvisibleQueue as new ConcurrentQueue(Of GalleryControl)

    Dim LastVisibilityUpdateTime as DateTime
    Dim NextVisibilityUpdateTime as DateTime

    Dim VisibilityUpdateDelay as Thread

    Private Sub DelayVisibilityUpdate
        NextVisibilityUpdateTime = now.AddMilliseconds(100)
        if VisibilityUpdateDelay.IsAlive
            Exit sub
        End If
        VisibilityUpdateDelay = new Thread(AddressOf VisibilityUpdateDelayer)
        VisibilityUpdateDelay.Start
    End Sub

    Private Sub VisibilityUpdateDelayer
        While now < NextVisibilityUpdateTime
            Thread.Sleep(50)
            Console.WriteLine("Waiting to update visibilities")
        End While
        _Disp.Invoke(AddressOf UpdateVisible)
    End Sub

    Private Sub UpdateVisible()
        'if (Now - LastVisibilityUpdateTime).TotalSeconds < 0.2
        '    Exit Sub
        'End If
        'LastVisibilityUpdateTime = now
        QueuesUpdating = true
        LoadVisibleQueue = New ConcurrentQueue(Of GalleryControl)()
        LoadInvisibleQueue = New ConcurrentQueue(Of GalleryControl)()
        ToggleVisibleQueue.Clear
        ToggleInvisibleQueue.Clear()
        'Unfortunately involves iterating through everything.
        For each Control As GalleryControl in GalleryContainer.Children
            if IsUserVisible(Control,Me)
                ToggleVisibleQueue.Enqueue(Control)
                LoadVisibleQueue.Enqueue(Control)
            Else 
                ToggleInvisibleQueue.Enqueue(Control)
                LoadInvisibleQueue.Enqueue(Control)
            End If
        Next
        Console.WriteLine($"Toggling {ToggleVisibleQueue.Count } visible, {ToggleInvisibleQueue.Count} invisible")
        ToggleImageVisibility()
        QueuesUpdating = false
    End Sub

    Private Sub ToggleImageVisibility
        'Process the visible ones first as they're most important
        While ToggleVisibleQueue.Count > 0
            Dim item = ToggleVisibleQueue.Dequeue()
            item.ShowImage()
        End While
        
        'Then the rest we can do in the background a bit
        Dim InvisibleToggler = New Thread(
            sub()
                While ToggleInVisibleQueue.Count > 0
                    Dim item = ToggleInVisibleQueue.Dequeue()
                    _Disp.Invoke(
                        Sub()
                            try
                                item.HideImage()
                            Catch ex As Exception

                            End Try
                            
                        End Sub)
                End While
            End Sub)
        InvisibleToggler.Start()
    End Sub

    #End region

    Dim TotalLoaded = 0
    Dim TotalControls = 0

    Private Sub WorkerTasks()
        Dim ProcessingFactory As New ImageFactory()
        Thread.Sleep(100 + (New Random().Next(0, 150)))
        Dim StillControlsToDo As Boolean = True
        While StillControlsToDo
            If LoadVisibleQueue.Count > 0
                Dim item as GalleryControl
                if LoadVisibleQueue.TryDequeue(item)
                    if not Item.Imageloaded
                        item.StartLoading(ProcessingFactory)
                        TotalLoaded += 1
                    End If
                    
                End If
            ElseIf LoadInvisibleQueue.Count > 0
                Dim item as GalleryControl
                if LoadInvisibleQueue.TryDequeue(item)
                    if not Item.Imageloaded
                        item.StartLoading(ProcessingFactory)
                        TotalLoaded += 1
                    End If
                End If
            ElseIf QueuesUpdating = true
                'Do nothing
                Thread.Sleep(50)
            Else 
                StillControlsToDo = false
            End If
            _Disp.Invoke(Sub() _MW.FrameTitle.Text = $"Select your pictures. ({TotalLoaded} of {TotalControls} loaded)")
            'Dim NextControl = ControlHunter()
            'If Not NextControl Is Nothing Then
            '    Try
            '        NextControl.StartLoading()
            '        _Disp.Invoke(function() 
            '                         NextControl.UpdateImageVisibility()
            '                     End function)
            '    Catch ex As Exception

            '    End Try
            'Else
            '    StillControlsToDo = False
            'End If
        End While
        _Disp.Invoke(Sub() _MW.FrameTitle.Text = "Select your pictures.")
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
        _Disp.Invoke(Sub()
                              'Animate the page in
                              Dim SB2 As Storyboard = Me.FindResource("AnimateIn")
                              SB2.Begin()

                              Dim asd As New Thread(
                                  Sub()
                                      'Set up threads
                                      Dim Thread1 As New Thread(AddressOf WorkerTasks)
                                      Dim Thread2 As New Thread(AddressOf WorkerTasks)
                                      Dim Thread3 As New Thread(AddressOf WorkerTasks)
                                      Thread1.IsBackground = True
                                      Thread2.IsBackground = True
                                      Thread3.IsBackground = True
                                      ThreadList.Add(Thread2)
                                      ThreadList.Add(Thread1)
                                      ThreadList.Add(Thread3)
                                      Thread1.Start()
                                      Thread2.Start()
                                      Thread3.Start()
                                    
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
        UpdateRunningTotal()
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
        'ScrollPositionChanged = True
        'UpdateVisible()
        DelayVisibilityUpdate()
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
            UpdateRunningTotal()
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

    Private Sub UpdateRunningTotal()
        'PriceBlock and PriceSubBlock

        Dim TotalPrice As Double = 0
        Dim TotalPrints As Integer = 0
        Dim CurrentSizes = ""
        '6x4
        Dim _6x4Prints as Integer = UIElementList.Sum(Function(asd) GetOrderedAmount(asd.Loadable, Sizes.s6x4))
        If _6x4Prints>0 Then
            TotalPrints += _6x4Prints 
            TotalPrice += GetPricingLevel(Sizes.s6x4, _6x4Prints) * _6x4Prints
            If CurrentSizes = "" Then CurrentSizes = "6x4" Else CurrentSizes="various sizes"
        End If
        '7x5
        Dim _7x5Prints as Integer = UIElementList.Sum(Function(asd) GetOrderedAmount(asd.Loadable, Sizes.s7x5))
        If _7x5Prints>0 Then
            TotalPrints += _7x5Prints 
            TotalPrice += GetPricingLevel(Sizes.s7x5, _7x5Prints) * _7x5Prints
            If CurrentSizes = "" Then CurrentSizes = "7x5" Else CurrentSizes="various sizes"
        End If
        '8x6
        Dim _8x6Prints as Integer = UIElementList.Sum(Function(asd) GetOrderedAmount(asd.Loadable, Sizes.s8x6))
        If _8x6Prints>0 Then
            TotalPrints += _8x6Prints 
            TotalPrice += GetPricingLevel(Sizes.s8x6, _8x6Prints) * _8x6Prints
            If CurrentSizes = "" Then CurrentSizes = "8x6" Else CurrentSizes="various sizes"
        End If
        '8x10
        Dim _8x10Prints as Integer = UIElementList.Sum(Function(asd) GetOrderedAmount(asd.Loadable, Sizes.s8x10))
        If _8x10Prints>0 Then
            TotalPrints += _8x10Prints 
            TotalPrice += GetPricingLevel(Sizes.s8x10, _8x10Prints) * _8x10Prints
            If CurrentSizes = "" Then CurrentSizes = "8x10" Else CurrentSizes="various sizes"
        End If
        '10x12
        Dim _10x12Prints as Integer = UIElementList.Sum(Function(asd) GetOrderedAmount(asd.Loadable, Sizes.s10x12))
        If _10x12Prints>0 Then
            TotalPrints += _10x12Prints 
            TotalPrice += GetPricingLevel(Sizes.s10x12, _10x12Prints) * _10x12Prints
            If CurrentSizes = "" Then CurrentSizes = "10x12" Else CurrentSizes="various sizes"
        End If

        PriceBlock_Copy.Text = FormatCurrency(TotalPrice,2)
        PriceSubBlock.Text = TotalPrints.ToString + " prints, " + CurrentSizes
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
