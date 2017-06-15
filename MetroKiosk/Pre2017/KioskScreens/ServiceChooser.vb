Imports System.Text

Public Class ServiceChooser


    Private Sub size1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles size1.MouseDown
        size1Parent.BackColor = Color.RoyalBlue
    End Sub

    Private Sub size1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles size1.MouseUp
        size1Parent.BackColor = Color.CornflowerBlue

    End Sub

    Private Sub size2_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles size2.MouseUp
        size2parent.BackColor = Color.CornflowerBlue
    End Sub

    Private Sub size2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles size2.MouseDown
        size2parent.BackColor = Color.RoyalBlue

    End Sub

    Private Sub Size3_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles size3.MouseDown
        Size3Parent.BackColor = Color.RoyalBlue
    End Sub

    Private Sub Size3_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles size3.MouseUp
        Size3Parent.BackColor = Color.CornflowerBlue
    End Sub

    Private Sub Size4_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles size4.MouseUp
        Size4Parent.BackColor = Color.CornflowerBlue
    End Sub

    Private Sub Size4_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles size4.MouseDown
        Size4Parent.BackColor = Color.RoyalBlue
    End Sub

    Private Sub Size5_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles size5.MouseUp
        size5parent.BackColor = Color.CornflowerBlue
    End Sub

    Private Sub Size5_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles size5.MouseDown
        size5parent.BackColor = Color.RoyalBlue
    End Sub

    Private Sub ServiceChooser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Size = New Size(kioskWelcome.Width, kioskWelcome.Height - 164)
        Dim ScaleFactors As New SizeF(kioskWelcome.Width / 1024, (kioskWelcome.Height - 164) / 604)
        Me.Scale(ScaleFactors)
        size1.ImageLocation = My.Settings.Size1Img
        size2.ImageLocation = My.Settings.Size2Img
        size3.ImageLocation = My.Settings.Size3Img
        size4.ImageLocation = My.Settings.Size4Img
        size5.ImageLocation = My.Settings.Size5Img
        sendnetcommand("STATE#Waiting for size choice")

    End Sub

    Private Sub LoadDeviceChooserWithSizeID(ByVal ChosenSizeID As Integer)

        setting.SizeID = ChosenSizeID
        Select Case ChosenSizeID < 6
            Case ChosenSizeID = 1
                sizename = My.Settings.Size1Text
                sizechan = My.Settings.Size1Channel
                sizeaid = 0
            Case ChosenSizeID = 2
                sizename = My.Settings.Size2Text
                sizechan = My.Settings.Size2Channel
                sizeaid = 1
            Case ChosenSizeID = 3
                sizename = My.Settings.Size3Text
                sizechan = My.Settings.Size3Channel
                sizeaid = 2
            Case ChosenSizeID = 4
                sizename = My.Settings.Size4Text
                sizechan = My.Settings.Size4Channel
                sizeaid = 3
            Case ChosenSizeID = 5
                sizename = My.Settings.Size5Text
                sizechan = My.Settings.Size5Channel
                sizeaid = 4
        End Select



        Me.Hide()
        qwerty.Show()
        sendnetcommand("JSIZE#" + sizename + " (" + sizechan + ")")

    End Sub

    Private Sub size1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles size1.Click
        LoadDeviceChooserWithSizeID(1)
    End Sub

    Private Sub size2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles size2.Click
        LoadDeviceChooserWithSizeID(2)
    End Sub

    Private Sub Size3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles size3.Click
        LoadDeviceChooserWithSizeID(3)
    End Sub

    Private Sub Size4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles size4.Click
        LoadDeviceChooserWithSizeID(4)
    End Sub

    Private Sub size5_Click(sender As Object, e As EventArgs) Handles size5.Click
        LoadDeviceChooserWithSizeID(5)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class