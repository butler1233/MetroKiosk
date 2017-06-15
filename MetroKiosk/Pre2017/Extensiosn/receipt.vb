Imports System.Drawing.Printing

''' <summary>
''' WELCOME TO 2016 BOYS. July 29th that is. 
''' </summary>
Public Module GDIReceipt
    Public Class OrderedService
        Public SizeCT As String
        Public SizeText As String
        Public Quantity As Integer
        Public UnitPrice As Single
        Public Total As Single
    End Class

    Public Class ReceiptData
        Public KioskName As String
        Public OrderName As String
        Public OrderTime As DateTime

        Public Services As New List(Of OrderedService)

        Public ReadOnly Property TotalPrice() As Single
            Get
                Dim value As Single = 0
                For Each os As OrderedService In Services
                    value += os.UnitPrice * os.Quantity
                Next
                Return value
            End Get
        End Property

        Private Sub GDIPrint(sender As FancyPrinter, e As PrintPageEventArgs)
            Dim d As ReceiptData = sender.PrintData
            e.Graphics.PageUnit = GraphicsUnit.Millimeter


        End Sub

        Public Class FancyPrinter
            Inherits PrintDocument
            Public PrintData As ReceiptData
        End Class

        Private Sub PrintReceipt(ReceiptData As ReceiptData)
            Dim printer As New FancyPrinter
            printer.PrintController = New StandardPrintController
            AddHandler printer.PrintPage, AddressOf GDIPrint
            printer.PrintData = ReceiptData
            printer.Print()
        End Sub
    End Class
End Module

Public Class receipt

    Private Sub receipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Try
            kiosk.Text = My.Computer.Name
            order.Text = process.orderid.ToString.Substring(2).Split("_")(0) + vbNewLine + process.orderid.ToString.Substring(2).Split("_")(1)
            infobox.Text = sizename + vbNewLine + totimg.ToString + vbNewLine + FormatCurrency(sizeprice, 2).ToString
            Price.Text = FormatCurrency(totimg * sizeprice, 2).ToString
        Catch ex As Exception
            kiosk.Text = My.Computer.Name
            order.Text = "Order Text Goes Here"
            infobox.Text = "Size" + vbNewLine + "Total" + vbNewLine + "£/print"
            Price.Text = "£Total"
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Me.Focus()
        'PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.FullWindow)

        'Better printer setup
        Dim NoDialogMode As New StandardPrintController
        BetterPrinter.PrintController = NoDialogMode
        BetterPrinter.Print()
        ' Threading.Thread.Sleep(2000)
        Me.Hide()
    End Sub

    Private Sub BetterPrinter_PrintPage(sender As Object, e As PrintPageEventArgs) Handles BetterPrinter.PrintPage
        Dim BitmapMode As New Bitmap(Me.Width, Me.Height)
        Dim BMGraph As Graphics = Graphics.FromImage(BitmapMode)
        BMGraph.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        BMGraph.CopyFromScreen(Me.Location, New Point(0, 0), Me.Size)
        ' SCALE FACTOR FOR ENLARGING THE THING.
        Dim SF As Single = 2
        Dim resized As Bitmap = ResizeImage(BitmapMode, BitmapMode.Width * SF, BitmapMode.Height * SF)
        e.Graphics.PageUnit = GraphicsUnit.Document
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        e.Graphics.DrawImage(resized, New Rectangle(New Point(0, 0), resized.Size), New Rectangle(New Point(0, 0), resized.Size), GraphicsUnit.Pixel)



    End Sub

    Public Overloads Shared Function ResizeImage(bmSource As Drawing.Bitmap, TargetWidth As Int32, TargetHeight As Int32) As Drawing.Bitmap
        Dim bmDest As New Drawing.Bitmap(TargetWidth, TargetHeight, Drawing.Imaging.PixelFormat.Format32bppArgb)

        Dim nSourceAspectRatio = bmSource.Width / bmSource.Height
        Dim nDestAspectRatio = bmDest.Width / bmDest.Height

        Dim NewX = 0
        Dim NewY = 0
        Dim NewWidth = bmDest.Width
        Dim NewHeight = bmDest.Height

        If nDestAspectRatio = nSourceAspectRatio Then
            'same ratio
        ElseIf nDestAspectRatio > nSourceAspectRatio Then
            'Source is taller
            NewWidth = Convert.ToInt32(Math.Floor(nSourceAspectRatio * NewHeight))
            NewX = Convert.ToInt32(Math.Floor((bmDest.Width - NewWidth) / 2))
        Else
            'Source is wider
            NewHeight = Convert.ToInt32(Math.Floor((1 / nSourceAspectRatio) * NewWidth))
            NewY = Convert.ToInt32(Math.Floor((bmDest.Height - NewHeight) / 2))
        End If

        Using grDest = Drawing.Graphics.FromImage(bmDest)
            With grDest
                .CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
                .InterpolationMode = Drawing.Drawing2D.InterpolationMode.NearestNeighbor
                .PixelOffsetMode = Drawing.Drawing2D.PixelOffsetMode.None
                .SmoothingMode = Drawing.Drawing2D.SmoothingMode.None
                .CompositingMode = Drawing.Drawing2D.CompositingMode.SourceCopy

                .DrawImage(bmSource, NewX, NewY, NewWidth, NewHeight)
            End With
        End Using

        Return bmDest
    End Function

    Private Sub orederasd_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub order_Click(sender As Object, e As EventArgs) Handles order.Click

    End Sub

    Private Sub kiosk_Click(sender As Object, e As EventArgs) Handles kiosk.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class