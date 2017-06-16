Public NotInheritable Class SplashScreen

    Private Sub SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BuildDateString.Text = IO.File.GetLastWriteTime(System.Windows.Forms.Application.ExecutablePath).ToString("dd/MM/yyyy HH:mm")
        Try
            DeploymentString.Text = "Deployment Ver: " + My.Application.Deployment.CurrentVersion.ToString
        Catch ex As Exception
            DeploymentString.Text = "Not deployed"
        End Try
    End Sub

End Class
