Imports System.IO
Imports System.Threading
Imports System.Windows.Threading

Class Completed

    Dim Disp As Dispatcher
    Dim Main As MetroKioskWPF

    Public Sub New(MainWindow As MetroKioskWPF)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Disp = Me.Dispatcher
        Main = MainWindow

        Dim Magic As New Thread(Sub()
                                    Dim files = (New DirectoryInfo("C:\bt").EnumerateFiles())
                                    For each file In files
                                        Try
                                            file.Delete
                                        Catch ex As Exception
                                            'rip
                                        End Try
                                    Next
                                    Thread.Sleep(15000)
                                    Disp.BeginInvoke(Sub() Main.ResetKiosk)
                                End Sub)
        Magic.Start()
    End Sub

End Class
