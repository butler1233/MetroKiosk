Public Class galleryext

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim cool As Integer = 0
        While cool < copies.GetLength(0)
            incc(-1, cool)
            cool = cool + 1
        End While
    End Sub
    Public Sub incc(amount As Integer, gridid As Integer)
        Dim start As Integer = (gallery.curpage - 1) * 8
        If amount < 1 Then
            If copies(gridid, sizeaid) > 0 Then
                copies(gridid, sizeaid) = copies(gridid, sizeaid) + amount
            End If
        Else
            copies(gridid, sizeaid) = copies(gridid, sizeaid) + amount
        End If

        gallery.updatelabels(start)

        gallery.recount()

    End Sub

    Public Sub perc(p As Integer)
        Dim percentage As Integer = Math.Round((p / (images.Count)) * 100)
        Dim pages As Integer = Math.Floor(p / 8)
        If percentage = 100 Then
            pages = Math.Ceiling(p / 8)
        End If
        preprog.Text = p.ToString + "/" + (images.Count).ToString + " (" + percentage.ToString + "%, " + pages.ToString + " pages loaded)"
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim cool As Integer = 0
        While cool < copies.GetLength(0)
            incc(1, cool)
            cool = cool + 1
        End While
    End Sub

    Private Sub galleryext_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        perc(0)
        Me.Location = New Point(0, kioskWelcome.Height - 70)
        Me.Size = New Size(kioskWelcome.Width, 70)
    End Sub
End Class