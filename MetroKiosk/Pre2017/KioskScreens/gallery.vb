Public Class gallery
    Public curpage As Integer
    Public maxpage As Integer


    Private Property cool As Image.GetThumbnailImageAbort

    Private Property cool2 As IntPtr
    Dim navenabled As Boolean = True
    Dim navtarget As Integer

    Private Sub gallery_Load(sender As Object, e As EventArgs)
        

        gallerytitle.Text = "Select which images you want..."

        Dim imgtot As Integer = setting.images.Count
        Dim pages As Integer
        If Int(imgtot / 8) = (imgtot / 8) Then
            pages = imgtot / 8
        Else
            pages = Math.Ceiling(imgtot / 8)
        End If
        maxpage = pages
        galleryhead.Text = imgtot.ToString + " images loaded (" + pages.ToString + " pages)"
        turnpage(1)
        grid.Visible = True
        galleryext.Panel2.Visible = True


    End Sub

    Private Sub editimage(imageid As Integer)
        Dim start As Integer = (curpage - 1) * 8
        If start < 0 Then
            start = 0
        End If
        multiorderdl.ID = (imageid - 1) + start
        multiorderdl.Show()


    End Sub

    Private Sub turnpage(page As Integer)
        gridimg_1.Image = MetroKioskResources.My.Resources.loadingtheps
        gridimg_2.Image = MetroKioskResources.My.Resources.loadingtheps
        gridimg_3.Image = MetroKioskResources.My.Resources.loadingtheps
        gridimg_4.Image = MetroKioskResources.My.Resources.loadingtheps
        gridimg_5.Image = MetroKioskResources.My.Resources.loadingtheps
        gridimg_6.Image = MetroKioskResources.My.Resources.loadingtheps
        gridimg_7.Image = MetroKioskResources.My.Resources.loadingtheps
        gridimg_8.Image = MetroKioskResources.My.Resources.loadingtheps
        Threading.Thread.Sleep(20)
        curpage = page
        curpagelabel.Text = page
        If page = 1 Then
            prevpagebg.BackColor = Color.DarkGray
        ElseIf page = maxpage Then
            nextpagebg.BackColor = Color.DarkGray
        ElseIf maxpage = 1 Then
            prevpagebg.BackColor = Color.DarkGray
            nextpagebg.BackColor = Color.DarkGray
        Else
            prevpagebg.BackColor = Color.CornflowerBlue
            nextpagebg.BackColor = Color.CornflowerBlue
        End If
        Dim start As Integer = (page - 1) * 8
        If start < 0 Then
            start = 0
        End If
        openimage(start, 1)
        openimage(start + 1, 2)
        openimage(start + 2, 3)
        openimage(start + 3, 4)
        openimage(start + 4, 5)
        openimage(start + 5, 6)
        openimage(start + 6, 7)
        openimage(start + 7, 8)
        recount()
    End Sub

    Private Function getthumb(index As Integer) As System.Drawing.Image
        If overflowactive Then
            Try
                Return (System.Drawing.Image.FromFile("C:\MKTemp\thumb_" + index.ToString + ".jpg"))
            Catch exa As Exception

                Return MetroKioskResources.My.Resources.noread
            End Try
        Else
            Try
                Return (thumbs(index))
            Catch ex As Exception
                Try
                    Return (System.Drawing.Image.FromFile(images.Item(index)).GetThumbnailImage(243, 142, cool, cool2))
                Catch exa As Exception
                    preloader.overflowmode()
                    Return MetroKioskResources.My.Resources.noread
                End Try

            End Try
        End If

       
    End Function
    Private Sub openimage(imgindex As Integer, gridid As Integer)
        Select Case gridid < 9
            Case gridid = 1
                If imgindex < setting.images.Count Then
                    gridimg_1.Image = getthumb(imgindex)
                    copies_1.Text = copies(imgindex, sizeaid).ToString + " copies"
                    Dim exp As Array = Split(images(imgindex).ToString(), "\", -1, CompareMethod.Text)
                    fn_1.Text = exp(exp.Length - 1)
                Else
                    gridimg_1.Image = MetroKioskResources.My.Resources.nomoreimg
                    copies_1.Text = ""
                    fn_1.Text = ""
                End If
            Case gridid = 2
                If imgindex < setting.images.Count Then
                    gridimg_2.Image = getthumb(imgindex)
                    copies_2.Text = copies(imgindex, sizeaid).ToString + " copies"
                    Dim exp As Array = Split(images(imgindex).ToString(), "\", -1, CompareMethod.Text)
                    fn_2.Text = exp(exp.Length - 1)
                Else
                    gridimg_2.Image = MetroKioskResources.My.Resources.nomoreimg
                    copies_2.Text = ""
                    fn_2.Text = ""
                End If
            Case gridid = 3
                If imgindex < setting.images.Count Then
                    gridimg_3.Image = getthumb(imgindex)
                    copies_3.Text = copies(imgindex, sizeaid).ToString + " copies"
                    Dim exp As Array = Split(images(imgindex).ToString(), "\", -1, CompareMethod.Text)
                    fn_3.Text = exp(exp.Length - 1)
                Else
                    gridimg_3.Image = MetroKioskResources.My.Resources.nomoreimg
                    copies_3.Text = ""
                    fn_3.Text = ""
                End If

            Case gridid = 4
                If imgindex < setting.images.Count Then
                    gridimg_4.Image = getthumb(imgindex)
                    copies_4.Text = copies(imgindex, sizeaid).ToString + " copies"
                    Dim exp As Array = Split(images(imgindex).ToString(), "\", -1, CompareMethod.Text)
                    fn_4.Text = exp(exp.Length - 1)
                Else
                    gridimg_4.Image = MetroKioskResources.My.Resources.nomoreimg
                    copies_4.Text = ""
                    fn_4.Text = ""
                End If

            Case gridid = 5
                If imgindex < setting.images.Count Then
                    gridimg_5.Image = getthumb(imgindex)
                    copies_5.Text = copies(imgindex, sizeaid).ToString + " copies"
                    Dim exp As Array = Split(images(imgindex).ToString(), "\", -1, CompareMethod.Text)
                    fn_5.Text = exp(exp.Length - 1)
                Else
                    gridimg_5.Image = MetroKioskResources.My.Resources.nomoreimg
                    copies_5.Text = ""
                    fn_5.Text = ""
                End If

            Case gridid = 6
                If imgindex < setting.images.Count Then
                    gridimg_6.Image = getthumb(imgindex)
                    copies_6.Text = copies(imgindex, sizeaid).ToString + " copies"
                    Dim exp As Array = Split(images(imgindex).ToString(), "\", -1, CompareMethod.Text)
                    fn_6.Text = exp(exp.Length - 1)
                Else
                    gridimg_6.Image = MetroKioskResources.My.Resources.nomoreimg
                    copies_6.Text = ""
                    fn_6.Text = ""
                End If

            Case gridid = 7
                If imgindex < setting.images.Count Then
                    gridimg_7.Image = getthumb(imgindex)
                    copies_7.Text = copies(imgindex, sizeaid).ToString + " copies"
                    Dim exp As Array = Split(images(imgindex).ToString(), "\", -1, CompareMethod.Text)
                    fn_7.Text = exp(exp.Length - 1)
                Else
                    gridimg_7.Image = MetroKioskResources.My.Resources.nomoreimg
                    copies_7.Text = ""
                    fn_7.Text = ""
                End If

            Case gridid = 8
                If imgindex < setting.images.Count Then
                    gridimg_8.Image = getthumb(imgindex)
                    copies_8.Text = copies(imgindex, sizeaid).ToString + " copies"
                    Dim exp As Array = Split(images(imgindex).ToString(), "\", -1, CompareMethod.Text)
                    fn_8.Text = exp(exp.Length - 1)
                Else
                    gridimg_8.Image = MetroKioskResources.My.Resources.nomoreimg
                    copies_8.Text = ""
                    fn_8.Text = ""
                End If

        End Select

    End Sub

    Public Sub incc(amount As Integer, gridid As Integer)
        Dim start As Integer = (curpage - 1) * 8
        If amount < 1 Then
            If copies(start + (gridid - 1), sizeaid) > 0 Then
                copies(start + (gridid - 1), sizeaid) = copies(start + (gridid - 1), sizeaid) + amount
            Else
                copies(start + (gridid - 1), sizeaid) = 0
            End If
        Else
            copies(start + (gridid - 1), sizeaid) = copies(start + (gridid - 1), sizeaid) + amount
        End If

        updatelabels(start)

        recount()

    End Sub
    Public Sub updatelabels(start)
        Try
            copies_1.Text = copies(start, sizeaid).ToString + " copies"
        Catch ex As Exception
            copies_1.Text = ""
        End Try
        Try
            copies_2.Text = copies(start + 1, sizeaid).ToString + " copies"
        Catch ex As Exception
            copies_2.Text = ""
        End Try
        Try
            copies_3.Text = copies(start + 2, sizeaid).ToString + " copies"
        Catch ex As Exception
            copies_3.Text = ""
        End Try
        Try
            copies_4.Text = copies(start + 3, sizeaid).ToString + " copies"
        Catch ex As Exception
            copies_4.Text = ""
        End Try
        Try
            copies_5.Text = copies(start + 4, sizeaid).ToString + " copies"
        Catch ex As Exception
            copies_5.Text = ""
        End Try
        Try
            copies_6.Text = copies(start + 5, sizeaid).ToString + " copies"
        Catch ex As Exception
            copies_6.Text = ""
        End Try
        Try
            copies_7.Text = copies(start + 6, sizeaid).ToString + " copies"
        Catch ex As Exception
            copies_7.Text = ""
        End Try
        Try
            copies_8.Text = copies(start + 7, sizeaid).ToString + " copies"
        Catch ex As Exception
            copies_8.Text = ""
        End Try
    End Sub
    Private Function recountsub(sizeID) As Single
        Dim cool As Integer = 0
        totimg = 0
        While cool < images.Count
            totimg = totimg + copies(cool, sizeID)
            actotimg = actotimg + copies(cool, sizeID)
            cool = cool + 1

        End While
        If sizeID = 0 Then
            If totimg > My.Settings.PriceBand3Max Then
                sizeprice = My.Settings.Size1Price4
            ElseIf totimg > My.Settings.PriceBand2Max Then
                sizeprice = My.Settings.Size1Price3
            ElseIf totimg > My.Settings.PriceBand1Max Then
                sizeprice = My.Settings.Size1Price2
            Else
                sizeprice = My.Settings.Size1Price1
            End If
        ElseIf sizeID = 1 Then
            If totimg > My.Settings.PriceBand3Max Then
                sizeprice = My.Settings.Size2Price4
            ElseIf totimg > My.Settings.PriceBand2Max Then
                sizeprice = My.Settings.Size2Price3
            ElseIf totimg > My.Settings.PriceBand1Max Then
                sizeprice = My.Settings.Size2Price2
            Else
                sizeprice = My.Settings.Size2Price1
            End If
        ElseIf sizeID = 2 Then
            If totimg > My.Settings.PriceBand3Max Then
                sizeprice = My.Settings.Size3Price4
            ElseIf totimg > My.Settings.PriceBand2Max Then
                sizeprice = My.Settings.Size3Price3
            ElseIf totimg > My.Settings.PriceBand1Max Then
                sizeprice = My.Settings.Size3Price2
            Else
                sizeprice = My.Settings.Size3Price1
            End If
        ElseIf sizeID = 3 Then
            If totimg > My.Settings.PriceBand3Max Then
                sizeprice = My.Settings.Size4Price4
            ElseIf totimg > My.Settings.PriceBand2Max Then
                sizeprice = My.Settings.Size4Price3
            ElseIf totimg > My.Settings.PriceBand1Max Then
                sizeprice = My.Settings.Size4Price2
            Else
                sizeprice = My.Settings.Size4Price1
            End If
        ElseIf sizeID = 4 Then
            If totimg > My.Settings.PriceBand3Max Then
                sizeprice = My.Settings.Size5Price4
            ElseIf totimg > My.Settings.PriceBand2Max Then
                sizeprice = My.Settings.Size5Price3
            ElseIf totimg > My.Settings.PriceBand1Max Then
                sizeprice = My.Settings.Size5Price2
            Else
                sizeprice = My.Settings.Size5Price1
            End If
        End If
        Return totimg * sizeprice
    End Function

    Public Sub recount()
        actotimg = 0
        Dim prices As New ArrayList
        prices.Add(recountsub(0))
        prices.Add(recountsub(1))
        prices.Add(recountsub(2))
        prices.Add(recountsub(3))
        prices.Add(recountsub(4))
        Dim fullprice As Single = prices(0) + prices(1) + prices(2) + prices(3) + prices(4)
        totbar.Text = actotimg.ToString + " prints,"
        sendnetcommand("JCHOSEN#" + actotimg.ToString)
        actotimg = 0
        recountsub(sizeaid)
        totbar.Text = totbar.Text + vbNewLine + actotimg.ToString + " prints " + sizename
        pricebox.Text = "£" + FormatNumber(fullprice).ToString
        sendnetcommand("JPRICE#£" + FormatNumber(fullprice).ToString)
    End Sub
    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles nextpage.MouseDown
        If navenabled = True Then
            If curpage < maxpage Then
                prevpage.Text = "Please Wait..."
                nextpage.Text = "Please Wait..."
                navenabled = False
                navtarget = curpage + 1
                navgenerator.Enabled = True
            End If
        End If

    End Sub

    Private Sub prevpage_Click(sender As Object, e As EventArgs) Handles prevpage.MouseDown
        If navenabled = True Then
            If curpage > 1 Then
                prevpage.Text = "Please Wait..."
                nextpage.Text = "Please Wait..."
                navenabled = False
                navtarget = curpage - 1
                navgenerator.Enabled = True
            End If
        End If

    End Sub

    Private Sub minus_1_Click(sender As Object, e As EventArgs) Handles minus_1.MouseDown
        incc(-1, 1)
    End Sub

    Private Sub plus_1_Click(sender As Object, e As EventArgs) Handles plus_1.MouseDown
        incc(1, 1)
    End Sub

    Private Sub minus_2_Click(sender As Object, e As EventArgs) Handles minus_2.MouseDown
        incc(-1, 2)
    End Sub

    Private Sub plus_2_Click(sender As Object, e As EventArgs) Handles plus_2.MouseDown
        incc(1, 2)
    End Sub

    Private Sub minus_3_Click(sender As Object, e As EventArgs) Handles minus_3.MouseDown
        incc(-1, 3)
    End Sub

    Private Sub plus_3_Click(sender As Object, e As EventArgs) Handles plus_3.MouseDown
        incc(+1, 3)
    End Sub

    Private Sub minus_4_Click(sender As Object, e As EventArgs) Handles minus_4.MouseDown
        incc(-1, 4)
    End Sub

    Private Sub plus_4_Click(sender As Object, e As EventArgs) Handles plus_4.MouseDown
        incc(1, 4)
    End Sub

    Private Sub minus_5_Click(sender As Object, e As EventArgs) Handles minus_5.MouseDown
        incc(-1, 5)
    End Sub

    Private Sub plus_5_Click(sender As Object, e As EventArgs) Handles plus_5.MouseDown
        incc(1, 5)
    End Sub

    Private Sub minus_6_Click(sender As Object, e As EventArgs) Handles minus_6.MouseDown
        incc(-1, 6)
    End Sub

    Private Sub plus_6_Click(sender As Object, e As EventArgs) Handles plus_6.MouseDown
        incc(1, 6)
    End Sub

    Private Sub minus_7_Click(sender As Object, e As EventArgs) Handles minus_7.MouseDown
        incc(-1, 7)
    End Sub

    Private Sub plus_7_Click(sender As Object, e As EventArgs) Handles plus_7.MouseDown
        incc(1, 7)
    End Sub

    Private Sub minus_8_Click(sender As Object, e As EventArgs) Handles minus_8.MouseDown
        incc(-1, 8)
    End Sub

    Private Sub plus_8_Click(sender As Object, e As EventArgs) Handles plus_8.MouseDown
        incc(1, 8)
    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) Handles Label2.MouseDown
        Me.Hide()
        process.Show()
        preloader.Close()
        sendnetcommand("STATE#Gallery Finished")
    End Sub

    Private Sub starter_Tick(sender As Object, e As EventArgs) Handles starter.Tick
        If Not thumbs.Count < 8 Then
            starter.Enabled = False
            gallery_Load(sender, e)
        ElseIf thumbs.Count = images.Count Then
            starter.Enabled = False
            gallery_Load(sender, e)
        ElseIf overflowactive Then
            starter.Enabled = False
            gallery_Load(sender, e)
        End If

    End Sub

    Private Sub gridimg_1_DoubleClick(sender As Object, e As EventArgs) Handles gridimg_1.DoubleClick
        editimage(1)
    End Sub

    Private Sub gridimg_2_DoubleClick(sender As Object, e As EventArgs) Handles gridimg_2.DoubleClick
        editimage(2)
    End Sub

    Private Sub gridimg_3_DoubleClick(sender As Object, e As EventArgs) Handles gridimg_3.DoubleClick
        editimage(3)
    End Sub

    Private Sub gridimg_4_DoubleClick(sender As Object, e As EventArgs) Handles gridimg_4.DoubleClick
        editimage(4)
    End Sub

    Private Sub gridimg_5_DoubleClick(sender As Object, e As EventArgs) Handles gridimg_5.DoubleClick
        editimage(5)
    End Sub

    Private Sub gridimg_6_Click(sender As Object, e As EventArgs) Handles gridimg_6.DoubleClick
        editimage(6)
    End Sub

    Private Sub gridimg_7_DoubleClick(sender As Object, e As EventArgs) Handles gridimg_7.DoubleClick
        editimage(7)
    End Sub

    Private Sub gridimg_8_DoubleClick(sender As Object, e As EventArgs) Handles gridimg_8.DoubleClick
        editimage(8)
    End Sub

    Private Sub navgenerator_Tick(sender As Object, e As EventArgs) Handles navgenerator.Tick
        navgenerator.Enabled = False
        Try
            turnpage(navtarget)
        Catch ex As Exception
            Try
                Console.Write("Apparently there was an exception: " + ex.Message.ToString + "|" + ex.InnerException.Message.ToString)
            Catch exa As Exception
            End Try
        End Try
        navenabled = True
        prevpage.Text = "<  Prev Page"
        nextpage.Text = "Next Page   >"
    End Sub

    Private Sub testdisabled_Tick(sender As Object, e As EventArgs)
        If nextpage.Enabled = True Then
            Console.WriteLine("Nect button is enabled")
        Else
            Console.WriteLine("next button is disabled")
        End If
    End Sub

    Private Sub gallery_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ScaleFactors As New SizeF(kioskWelcome.Width / 1024, (kioskWelcome.Height - 164) / 604)
        Me.Scale(ScaleFactors)
        sendnetcommand("STATE#Gallery screen")
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel35_Paint(sender As Object, e As PaintEventArgs) Handles Panel35.Paint

    End Sub

    Private Sub grid_Paint(sender As Object, e As PaintEventArgs) Handles grid.Paint

    End Sub

    Private Sub Label2_Click_2(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub minus_4_Click_1(sender As Object, e As EventArgs)

    End Sub
End Class