Public Class KioskControl

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Environment.Exit(0)
        
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Process.Start("shutdown.exe", "/s")
    End Sub
    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        Me.Hide()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim assemblies As List(Of System.Reflection.Assembly) = AppDomain.CurrentDomain.GetAssemblies.ToList
        Dim assloop As Integer = 0
        While assloop < assemblies.Count
            Assemblybox.Items.Add((assloop + 1).ToString + ": " + (Split(assemblies(assloop).GetName.ToString, ",")(0).ToString) + " (" + assemblies(assloop).ImageRuntimeVersion + ") | " + assemblies(assloop).Location)
            assloop = assloop + 1
        End While
        Me.Focus()

    End Sub
End Class
