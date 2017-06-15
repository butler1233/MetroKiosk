Imports System.Windows.Forms.ListBox
Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic


Module setting
    'WPF Finale
    Public WPFLoad As New WPF_MK_Windows.WPFProcesstoFinish



    'Declarations for globals for current job
    Public SizeID As Integer
    Public UserName As String
    Public UserTel As String
    Public userStorageMedia As String

    Public sizename As String
    Public sizeprice As Single
    Public sizechan As String
    Public sizeaid As Integer
    Public totimg As Integer


    Public overflowactive As Boolean = False
    Public screenindex As Integer
    Public images As New ArrayList
    Public copies(1, 5) As Integer
    Public thumbs As New ArrayList

    Public logaccess As Boolean = True
    Public actotimg As Integer
    Public Sub sendlog(ByVal data As String)
        Dim fullmsg As String
        fullmsg = My.Computer.Name.ToUpper + ": " + data
        If logaccess = True Then
            Connect(fullmsg)
        Else
            main.consolebox.Items.Add(fullmsg)
            main.consolebox.SelectedIndex = main.consolebox.Items.Count - 1

        End If


    End Sub
    Public Sub sendnetcommand(message As String)
        If logaccess = True Then
            Connect("#" + My.Computer.Name + "#" + message + "#")
        Else
            main.consolebox.Items.Add("#" + message)
        End If
    End Sub
    Public Sub recnetcommand(message As String)

    End Sub

    Public Sub errorbox(title As String, text As String, Optional suppress As Boolean = False)
        Dim wpfAlert As New WPF_MK_Windows.WPFAlert
        wpfAlert.SetValues(title, text)

        If suppress Then
            Console.Write("Suppressed error '" + title + "': " + text)
        Else
            wpfAlert.ShowDialog()
        End If


        '     alertdialog.alerttext.Text = text
        '     alertdialog.alerttitle.Text = title
        '     Try
        '         'alertdialog.ShowDialog()
        '     If suppress Then
        '         Console.Write("Suppressed error '" + title + "': " + text)
        '     Else
        '         alertdialog.ShowDialog()
        '     End If
        '
        '     Catch ex As Exception
        '
        '    End Try


    End Sub
    Public Sub Connect(ByVal message As String)
        Dim output As String = ""
        Dim serverip As String = My.Settings.LogmasterIp
        'Try
        '    ' Create a TcpClient. 
        '    ' The client requires a TcpServer that is connected 
        '    ' to the same address specified by the server and port 
        '    ' combination. 
        '    Dim port As Int32 = 2102
        '    Dim client As New TcpClient(serverip, port)
        '    'client.SendTimeout.

        '    ' Translate the passed message into ASCII and store it as a byte array. 
        '    Dim data(255) As [Byte]
        '    data = System.Text.Encoding.ASCII.GetBytes(message)

        '    ' Get a client stream for reading and writing. 
        '    ' Stream stream = client.GetStream(); 
        '    Dim stream As NetworkStream = client.GetStream()

        '    ' Send the message to the connected TcpServer. 
        '    stream.Write(data, 0, data.Length)

        '    Console.Write("Sent: " + message)


        '    ' Buffer to store the response bytes.
        '    data = New [Byte](255) {}

        '    ' String to store the response ASCII representation. 
        '    Dim responseData As String = String.Empty

        '    ' Read the first batch of the TcpServer response bytes. 
        '    Dim bytes As Int32 = stream.Read(data, 0, data.Length)
        '    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes)
        '    output = "Received: " + responseData


        '    ' Close everything.
        '    stream.Close()
        '    client.Close()
        'Catch e As ArgumentNullException
        '    output = "ArgumentNullException: " + e.ToString()
        '    errorbox("Logmaster Error", output)
        'Catch e As SocketException

        '    output = "SocketException: " + e.ToString()
        '    logaccess = False
        '    errorbox("Logmaster Error", "The kiosk was unable to connect to the logmaster. Please ensure the logmaster is running." + vbNewLine + vbNewLine + "The kiosk will continue to function, but will not send log messages out until the kiosk is reloaded. This can simply be done by cancelling an order.")

        '    main.consolebox.Items.Add("Unable to connect to logmaster. Suppressing all attempts until reload")
        'End Try
        logaccess = False

    End Sub
End Module
