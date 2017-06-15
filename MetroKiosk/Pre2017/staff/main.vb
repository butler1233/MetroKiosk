Imports System.Net.Sockets
Imports System.Net
Imports System.Threading
Imports System.Text
Imports System.IO

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
        createListener()

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



    Public Shared Function ts( _
 ByVal value As String _
) As Single

    End Function
    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If My.Settings.DebugMode = True Then
            Dim wpfWelcome As New WPF_MK_Windows.WPFWelcome
            wpfWelcome.Show()
        ElseIf My.Settings.Use2K17 Then
            '_2017_Welcome.Show()

            Dim MK2017 As New WPF_MK_Windows.MK2017Edition
            MK2017.SettingsWindow = Me
            MK2017.SetupWindow(My.Settings.StorageCF, My.Settings.StorageCD, My.Settings.StorageiDevice, My.Settings.StorageSD, My.Settings.StorageXD, "C:\b")
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
End Class
