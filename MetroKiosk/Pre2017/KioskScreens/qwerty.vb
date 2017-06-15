Public Class qwerty

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.MouseDown
        uname.Text = ""
    End Sub
    Private Sub ltr(letter As String)
        uname.Text = uname.Text + letter
        sendnetcommand("JNAME#" + uname.Text)
    End Sub

    Private Sub q_Click(sender As Object, e As EventArgs) Handles q.MouseDown
        ltr("Q")
    End Sub

    Private Sub w_Click(sender As Object, e As EventArgs) Handles w.MouseDown
        ltr("W")


    End Sub

    Private Sub e_Click(sender As Object, e As EventArgs) Handles e.MouseDown
        ltr("E")
    End Sub

    Private Sub r_Click(sender As Object, e As EventArgs) Handles r.MouseDown
        ltr("R")
    End Sub

    Private Sub t_Click(sender As Object, e As EventArgs) Handles t.MouseDown
        ltr("T")
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.MouseDown
        ltr("Y")
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.MouseDown
        ltr("U")
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.MouseDown
        ltr("I")
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.MouseDown
        ltr("O")
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.MouseDown
        ltr("P")
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.MouseDown
        ltr("A")
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.MouseDown
        ltr("S")
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.MouseDown
        ltr("D")
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.MouseDown
        ltr("F")
    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.MouseDown
        ltr("G")
    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.MouseDown
        ltr("H")
    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.MouseDown
        ltr("J")
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.MouseDown
        ltr("K")
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.MouseDown
        ltr("L")
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.MouseDown
        ltr("Z")
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.MouseDown
        ltr("X")
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.MouseDown
        ltr("C")
    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.MouseDown
        ltr("V")
    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs) Handles Label20.MouseDown
        ltr("B")
    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.MouseDown
        ltr("N")
    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.MouseDown
        ltr("M")
    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.MouseDown
        ltr("-")
    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.MouseDown
        ltr(" ")
    End Sub

    Private Sub Label26_Click(sender As Object, e As EventArgs) Handles Label26.MouseDown
        setting.UserName = uname.Text
        Me.Hide()
        gallery.Show()
    End Sub

    Private Sub qwerty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ScaleFactors As New SizeF(kioskWelcome.Width / 1024, (kioskWelcome.Height - 164) / 604)
        Me.Scale(ScaleFactors)
        Me.Size = New Size(kioskWelcome.Width, kioskWelcome.Height - 164)
        sendnetcommand("STATE#Inserting name")
        sendnetcommand("JNAME#(blank)")
    End Sub
End Class