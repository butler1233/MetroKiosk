Public Class finished

    Private Sub finished_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sendlog("Finalized. user should remove storage media. Kiosk is about to reset.")
        WPFLoad.EndProcessing()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        sendlog("Kiosk reloading now...")
        System.Windows.Forms.Application.Restart()
    End Sub
End Class