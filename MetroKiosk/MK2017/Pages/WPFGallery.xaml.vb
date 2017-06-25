Imports System.IO

Class WPFGallery

    Public Sub New(MainWindow As MetroKioskWPF, Files As List(Of FileInfo), Name As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub ScrollViewer_ManipulationBoundaryFeedback(sender As Object, e As Windows.Input.ManipulationBoundaryFeedbackEventArgs)
        e.Handled = True

    End Sub
End Class
