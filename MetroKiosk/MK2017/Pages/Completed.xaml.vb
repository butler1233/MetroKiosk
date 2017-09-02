Imports System.Threading
Imports System.Windows.Threading

Class Completed

    Dim Disp as Dispatcher
    Dim Main as MetroKioskWPF

    Public sub New(MainWindow As MetroKioskWPF  )

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Disp = Me.Dispatcher
        Main = MainWindow

        Dim Magic As new Thread(Sub()
                                    Thread.Sleep(20)
                                    Disp.BeginInvoke(sub() Main.ResetKiosk)
                                End Sub)
        Magic.Start()
    End Sub

End Class
