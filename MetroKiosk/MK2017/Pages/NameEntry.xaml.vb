Imports System.Windows.Controls

Class NameEntry
    Private Sub Press(sender As Button, e As Windows.RoutedEventArgs) Handles button.Click, button1.Click, button2.Click, button3.Click, button4.Click, button5.Click, button6.Click, button7.Click, button8.Click, button9.Click, button10.Click, button11.Click, button12.Click, button13.Click, button14.Click, button15.Click, button16.Click, button17.Click, button18.Click, button19.Click, button20.Click, button21.Click, button22.Click, button23.Click, button24.Click, button25.Click
        Apnd(sender.Content)
    End Sub

    Private Sub Apnd(Chara As String)
        NameBox.Text += Chara
    End Sub

    Private Sub Button_Click(sender As Object, e As Windows.RoutedEventArgs)
        Apnd(" ")
    End Sub
End Class
