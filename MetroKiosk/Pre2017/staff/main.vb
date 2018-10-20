Imports System.Net.Sockets
Imports System.Net
Imports System.Threading
Imports System.Text
Imports System.IO
Imports System.Drawing.Printing
Imports SHDocVw

Public Class main

    Private Shared output As String = ""
    Private mscClient As TcpClient
    Private mstrMessage As String
    Private mstrResponse As String
    Private bytesSent() As Byte
    Public curmessage As String
    Public lastmessage As String
    Dim tcpListener As TcpListener = Nothing




    Public Sub createListener()
        ' Create an instance of the TcpListener class. 

        Dim ipAddress As IPAddress = Net.IPAddress.Any
        Try
            ' Set the listener on the local IP address. 
            ' and specify the port.
            tcpListener = New TcpListener(ipAddress, 2102)
            tcpListener.Start()
            curmessage = "[" + My.Computer.Clock.LocalTime.ToLongTimeString + "] listener started up nicely"
        Catch e As Exception
            curmessage = "[" + My.Computer.Clock.LocalTime.ToLongTimeString + "] ERROR - " + e.ToString()
        End Try
        While True
            ' Always use a Sleep call in a while(true) loop 
            ' to avoid locking up your CPU.
            Thread.Sleep(10)
            ' Create a TCP socket. 
            ' If you ran this server on the desktop, you could use 
            ' Socket socket = tcpListener.AcceptSocket() 
            ' for greater flexibility. 
            Dim tcpClient As TcpClient = tcpListener.AcceptTcpClient()
            ' Read the data stream from the client. 
            Dim bytes(255) As Byte
            Dim stream As NetworkStream = tcpClient.GetStream()
            stream.Read(bytes, 0, bytes.Length)
            processMsg(tcpClient, stream, bytes)
        End While

    End Sub

    Public Sub processMsg(ByVal client As TcpClient, ByVal stream As NetworkStream, ByVal bytesReceived() As Byte)
        ' Handle the message received and  
        ' send a response back to the client.
        mstrMessage = Encoding.ASCII.GetString(bytesReceived, 0, bytesReceived.Length)
        mscClient = client
        curmessage = mstrMessage
        Console.Write("New message: " + curmessage)
        If mstrMessage.Equals("Hello") Then
            mstrResponse = "Goodbye"
        Else
            mstrResponse = "What?"
        End If
        bytesSent = Encoding.ASCII.GetBytes(mstrResponse)
        stream.Write(bytesSent, 0, bytesSent.Length)

    End Sub

    Private Sub Worker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        'createListener()

    End Sub

    Private Sub starter()
        addmessage("[" + My.Computer.Clock.LocalTime.ToLongTimeString + "] Attempting to start listener on '*:2102'...")
        Worker.RunWorkerAsync()
    End Sub

    Private Sub Logupdater_Tick(sender As Object, e As EventArgs) Handles Logupdater.Tick

        If curmessage = lastmessage Then

        Else
            addmessage(curmessage)
            lastmessage = curmessage

        End If
    End Sub
    Public Sub addmessage(message As String)
        consolebox.Items.Add(message)
        If message.Substring(0, 1) = "#" Then
            setting.recnetcommand(message)
        End If
    End Sub



    Private Sub LAUNCH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LAUNCH.Click
        kioskWelcome.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        setting.sendlog("Kiosk closed")
        Me.Close()


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.TopMost = False
        kioskWelcome.Focus()
        setting.sendlog("Kiosk Controller hidden.")
    End Sub



    Public Shared Function ts(
 ByVal value As String
) As Single

    End Function
    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FixDestinationFolder()

        If My.Settings.Use2K17 Then
            '_2017_Welcome.Show()

            Dim MK2017 As New MetroKioskWPF
            MK2017.Show()
        Else
            kioskWelcome.Show()
        End If



        Me.WindowState = FormWindowState.Minimized
        starter()
        setting.sendnetcommand("REGCLI")

    End Sub

    Private Sub SettingsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsButton.Click
        settings.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        consolebox.Items.Add("OutOfMemory exception will be thrown during thumbing!")
        My.Settings.DebugMode = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        receipt.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim mk As New MetroKioskWPF
        mk.Show()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        DrawBox(e.Graphics, 0, 0, True)
        DrawBox(e.Graphics, 10, 0, False)
        DrawBox(e.Graphics, 20, 0, True)
        DrawBox(e.Graphics, 30, 0, False)
        DrawBox(e.Graphics, 40, 0, True)
        DrawBox(e.Graphics, 50, 0, False)
        DrawBox(e.Graphics, 60, 0, True)
        DrawBox(e.Graphics, 70, 0, False)
        DrawBox(e.Graphics, 80, 0, True)
        DrawBox(e.Graphics, 90, 0, False)
        DrawBox(e.Graphics, 100, 0, True)
        DrawBox(e.Graphics, 110, 0, False)
        DrawBox(e.Graphics, 120, 0, True)
        DrawBox(e.Graphics, 130, 0, False)
        DrawBox(e.Graphics, 140, 0, True)
        DrawBox(e.Graphics, 150, 0, False)
        DrawBox(e.Graphics, 160, 0, True)
        DrawBox(e.Graphics, 170, 0, False)
        DrawBox(e.Graphics, 180, 0, True)
        DrawBox(e.Graphics, 190, 0, False)
        DrawBox(e.Graphics, 200, 0, True)
        DrawBox(e.Graphics, 0, 10, False)
        DrawBox(e.Graphics, 10, 10, True)
        DrawBox(e.Graphics, 20, 10, False)
        DrawBox(e.Graphics, 30, 10, True)
        DrawBox(e.Graphics, 40, 10, False)
        DrawBox(e.Graphics, 50, 10, True)
        DrawBox(e.Graphics, 60, 10, False)
        DrawBox(e.Graphics, 70, 10, True)
        DrawBox(e.Graphics, 80, 10, False)
        DrawBox(e.Graphics, 90, 10, True)
        DrawBox(e.Graphics, 100, 10, False)
        DrawBox(e.Graphics, 110, 10, True)
        DrawBox(e.Graphics, 120, 10, False)
        DrawBox(e.Graphics, 130, 10, True)
        DrawBox(e.Graphics, 140, 10, False)
        DrawBox(e.Graphics, 150, 10, True)
        DrawBox(e.Graphics, 160, 10, False)
        DrawBox(e.Graphics, 170, 10, True)
        DrawBox(e.Graphics, 180, 10, False)
        DrawBox(e.Graphics, 190, 10, True)
        DrawBox(e.Graphics, 200, 10, False)
        DrawBox(e.Graphics, 0, 20, True)
        DrawBox(e.Graphics, 10, 20, False)
        DrawBox(e.Graphics, 20, 20, True)
        DrawBox(e.Graphics, 30, 20, False)
        DrawBox(e.Graphics, 40, 20, True)
        DrawBox(e.Graphics, 50, 20, False)
        DrawBox(e.Graphics, 60, 20, True)
        DrawBox(e.Graphics, 70, 20, False)
        DrawBox(e.Graphics, 80, 20, True)
        DrawBox(e.Graphics, 90, 20, False)
        DrawBox(e.Graphics, 100, 20, True)
        DrawBox(e.Graphics, 110, 20, False)
        DrawBox(e.Graphics, 120, 20, True)
        DrawBox(e.Graphics, 130, 20, False)
        DrawBox(e.Graphics, 140, 20, True)
        DrawBox(e.Graphics, 150, 20, False)
        DrawBox(e.Graphics, 160, 20, True)
        DrawBox(e.Graphics, 170, 20, False)
        DrawBox(e.Graphics, 180, 20, True)
        DrawBox(e.Graphics, 190, 20, False)
        DrawBox(e.Graphics, 200, 20, True)
        DrawBox(e.Graphics, 0, 30, False)
        DrawBox(e.Graphics, 10, 30, True)
        DrawBox(e.Graphics, 20, 30, False)
        DrawBox(e.Graphics, 30, 30, True)
        DrawBox(e.Graphics, 40, 30, False)
        DrawBox(e.Graphics, 50, 30, True)
        DrawBox(e.Graphics, 60, 30, False)
        DrawBox(e.Graphics, 70, 30, True)
        DrawBox(e.Graphics, 80, 30, False)
        DrawBox(e.Graphics, 90, 30, True)
        DrawBox(e.Graphics, 100, 30, False)
        DrawBox(e.Graphics, 110, 30, True)
        DrawBox(e.Graphics, 120, 30, False)
        DrawBox(e.Graphics, 130, 30, True)
        DrawBox(e.Graphics, 140, 30, False)
        DrawBox(e.Graphics, 150, 30, True)
        DrawBox(e.Graphics, 160, 30, False)
        DrawBox(e.Graphics, 170, 30, True)
        DrawBox(e.Graphics, 180, 30, False)
        DrawBox(e.Graphics, 190, 30, True)
        DrawBox(e.Graphics, 200, 30, False)
        DrawBox(e.Graphics, 0, 40, True)
        DrawBox(e.Graphics, 10, 40, False)
        DrawBox(e.Graphics, 20, 40, True)
        DrawBox(e.Graphics, 30, 40, False)
        DrawBox(e.Graphics, 40, 40, True)
        DrawBox(e.Graphics, 50, 40, False)
        DrawBox(e.Graphics, 60, 40, True)
        DrawBox(e.Graphics, 70, 40, False)
        DrawBox(e.Graphics, 80, 40, True)
        DrawBox(e.Graphics, 90, 40, False)
        DrawBox(e.Graphics, 100, 40, True)
        DrawBox(e.Graphics, 110, 40, False)
        DrawBox(e.Graphics, 120, 40, True)
        DrawBox(e.Graphics, 130, 40, False)
        DrawBox(e.Graphics, 140, 40, True)
        DrawBox(e.Graphics, 150, 40, False)
        DrawBox(e.Graphics, 160, 40, True)
        DrawBox(e.Graphics, 170, 40, False)
        DrawBox(e.Graphics, 180, 40, True)
        DrawBox(e.Graphics, 190, 40, False)
        DrawBox(e.Graphics, 200, 40, True)
        DrawBox(e.Graphics, 0, 50, False)
        DrawBox(e.Graphics, 10, 50, True)
        DrawBox(e.Graphics, 20, 50, False)
        DrawBox(e.Graphics, 30, 50, True)
        DrawBox(e.Graphics, 40, 50, False)
        DrawBox(e.Graphics, 50, 50, True)
        DrawBox(e.Graphics, 60, 50, False)
        DrawBox(e.Graphics, 70, 50, True)
        DrawBox(e.Graphics, 80, 50, False)
        DrawBox(e.Graphics, 90, 50, True)
        DrawBox(e.Graphics, 100, 50, False)
        DrawBox(e.Graphics, 110, 50, True)
        DrawBox(e.Graphics, 120, 50, False)
        DrawBox(e.Graphics, 130, 50, True)
        DrawBox(e.Graphics, 140, 50, False)
        DrawBox(e.Graphics, 150, 50, True)
        DrawBox(e.Graphics, 160, 50, False)
        DrawBox(e.Graphics, 170, 50, True)
        DrawBox(e.Graphics, 180, 50, False)
        DrawBox(e.Graphics, 190, 50, True)
        DrawBox(e.Graphics, 200, 50, False)


    End Sub

    Private Sub DrawBox(ByRef g As Graphics, x As Int32, y As Int32, black As Boolean)
        Dim brush As Brush
        Dim opbrush As Brush
        If black Then
            brush = Brushes.Black
            opbrush = Brushes.White
        Else
            brush = Brushes.White
            opbrush = Brushes.Black
        End If
        Dim rect As Rectangle = New Rectangle(x, y, 10, 10)
        g.FillRectangle(brush, rect)
        g.DrawString($"x{x}" + vbNewLine + $"y{y}", lfont, opbrush, rect)
    End Sub

    Dim lfont As New Font("Arial", 8.0!, FontStyle.Regular)

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ReceiptPrinter.PrintController = New StandardPrintController
        ReceiptPrinter.Print()
    End Sub
    
    

    Private Sub ReceiptPrinter_PrintPage(sender As Object, e As PrintPageEventArgs) Handles ReceiptPrinter.PrintPage
        e.Graphics.PageUnit = GraphicsUnit.Millimeter
        'Useful fonts
        Dim HeaderText As new Font("Arial",16!,FontStyle.Bold)
        Dim OrdernameText As new Font("Gill Sans MT",16!,FontStyle.Regular)
        Dim SizeText As New Font("Segoe UI",32!,FontStyle.Regular)
        Dim SizeTextB As New Font("Segoe UI",36!,FontStyle.Bold)
        Dim SizeInfoText as New Font ("Consolas",12!,FontStyle.Regular)
        Dim Footer as New Font ("Consolas",10!,FontStyle.Regular)
        Dim SizePrice as new Font("Consolas",20!,FontStyle.Regular)

        Dim Centerer as new StringFormat()
        Centerer.Alignment = StringAlignment.Center
        Centerer.LineAlignment = StringAlignment.Far

        Dim CentererT as new StringFormat()
        CentererT.Alignment = StringAlignment.Center
        CentererT.LineAlignment = StringAlignment.Near

        Dim CentererM as new StringFormat()
        CentererM.Alignment = StringAlignment.Center
        CentererM.LineAlignment = StringAlignment.Center

        Dim Righter as new StringFormat()
        Righter.Alignment = StringAlignment.Far
        Righter.LineAlignment = StringAlignment.Far

        Dim RighterT as new StringFormat()
        RighterT.Alignment = StringAlignment.Far
        RighterT.LineAlignment = StringAlignment.Near

        Dim RighterM as new StringFormat()
        RighterM.Alignment = StringAlignment.Far
        RighterM.LineAlignment = StringAlignment.Center

        Dim Lefter as new StringFormat()
        Lefter.Alignment = StringAlignment.Near
        Lefter.LineAlignment = StringAlignment.Center
        
        Dim Quarter as new Pen(Brushes.Black,0.25)

        'Draw the logo
        e.Graphics.DrawImage(my.Resources.ReceiptKioskLogo,New Rectangle(0,0,70,18))

        'Draw header
        e.Graphics.DrawString("Order Receipt",HeaderText,Brushes.Black,new RectangleF(0,18,70,8), Centerer)

        'Draw order name
        e.Graphics.DrawString(OrderName,OrdernameText,Brushes.Black,new RectangleF(0,26,70,7), Centerer)
        Dim TotalPrice As Double = 0
        Dim TotalPrints as Integer = 0
        Dim SourceHeight as Integer = 33
        For each item in OrderData
            e.Graphics.DrawLine(Quarter,new Point(0,SourceHeight), new Point(70,SourceHeight))


            e.Graphics.DrawString(item.SizeText,SizeText,brushes.Black,new PointF(0,SourceHeight))
            e.Graphics.DrawString(item.Amount + " @ " + FormatCurrency(item.PriceLevel,2), SizeInfoText,brushes.Black, new RectangleF(0,SourceHeight,70,15),RighterT)
            Dim tempprice = Convert.ToInt32(item.Amount) * Convert.ToDouble(item.PriceLevel)
            TotalPrice += tempprice
            TotalPrints += Convert.ToInt32(item.Amount)
            e.Graphics.DrawString(FormatCurrency(tempprice,2),SizePrice,Brushes.Black, new RectangleF(0,SourceHeight,70,15), Righter)

            SourceHeight += 15
        Next
        e.Graphics.DrawLine(Quarter,new Point(0,SourceHeight), new Point(70,SourceHeight))
        e.Graphics.DrawLine(Quarter,new Point(0,SourceHeight+18), new Point(70,SourceHeight+18))
        dim TotalRect As New RectangleF(0,SourceHeight,70,17)
        e.Graphics.DrawString(" " + TotalPrints.ToString + vbnewline + " prints", SizeInfoText, Brushes.Black, TotalRect, Lefter)
        e.Graphics.DrawString(FormatCurrency(TotalPrice,2),SizeTextB, Brushes.Black,TotalRect,RighterM)

        dim FooterRect as new RectangleF(0,SourceHeight + 18,70,100)

        dim FooterText as String = "Please retain this receipt for your records." + vbnewline +  "You can also use it to reorder in the near future. " + vbnewline + vbnewline + My.Computer.Name + " | " + OrderTime.ToString("dd/MM/yyyy HH:mm:ss") + " | " + Ordername + vbnewline + vbNewLine + "==============================="
        FooterText += vbNewLine + "The Photo Shop"
        FooterText += vbNewLine + "9 Allport Lane"
        FooterText += vbNewLine + "Bromborough"
        FooterText += vbNewLine + "Wirral"
        FooterText += vbNewLine + "CH62 7HH"
        FooterText += vbNewLine + ""
        FooterText += vbNewLine + "0151 334 7234"
        FooterText += vbNewLine + ""
        FooterText += vbNewLine + "sales@thephotoshopwirral.com"

        e.Graphics.DrawString(FooterText,Footer,Brushes.Black,FooterRect,CentererT)

    End Sub

    Public Sub FixDestinationFolder
        Dim info = new ProcessStartInfo("explorer.exe", my.Settings.StorageTarget)
        info.WindowStyle = ProcessWindowStyle.Hidden
        Dim process = new Diagnostics.Process
        process.StartInfo = info
        process.Start
        Thread.Sleep(1000)
        Dim shellWindows = new SHDocVw.ShellWindows()
        Dim processType as String
        For each ie as InternetExplorer In shellWindows
            processType = System.IO.Path.GetFileNameWithoutExtension(ie.FullName).ToLower()
            if processType.Equals("explorer") And ie.LocationURL.Contains(my.Settings.StorageTarget)
                ie.Quit()
            End If
        Next
    End Sub
End Class
