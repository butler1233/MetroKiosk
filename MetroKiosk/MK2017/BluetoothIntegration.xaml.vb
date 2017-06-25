Imports System.Threading
Imports System.Windows.Threading
Imports InTheHand.Net


Public Class BluetoothIntegration

    'Dim Listener As BluetoothListener
    'Dim Endpoint As BluetoothEndPoint
    'Dim Client As BluetoothClient
    'Dim Radio As BluetoothRadio
    Dim Disp As Dispatcher

    Private Sub Window_Loaded(sender As Object, e As System.Windows.RoutedEventArgs)
        Disp = Me.Dispatcher
        Dim BTThread As New Thread(AddressOf SetupBT)
        BTThread.Start()
    End Sub

    Private Sub SetupBT()

    End Sub

    Private Sub UpdateStatus(message As String)
        Try
            ' Status.Text = message + " : ADDR-" + Radio.LocalAddress.ToString
        Catch ex As Exception
            Disp.Invoke(Sub() UpdateStatus(message))
        End Try
    End Sub

End Class
