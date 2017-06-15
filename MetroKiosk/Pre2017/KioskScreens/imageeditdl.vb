Public Class multiorderdl
    Public ID As Integer
    Public filepath As String
    Public dragstartx As Integer
    Public dragstarty As Integer
    Public ctmove As Boolean = False
    Public cbmove As Boolean = False
    Dim boundsrc As RectangleF
    Dim scaleval As Single
    Dim croptangle As Rectangle

    Public fullimg As Image
    Public undostor As Image

    Private Property asd As Image.GetThumbnailImageAbort

    Declare Sub aflib Lib "libaforgeimage.dll" ()

    Private Sub imageedit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width = 1024
        Me.Height = 768
        Dim bounds As Rectangle
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        Me.BackgroundImage = screenshot
        origimg.Image = thumbs(ID)
        Dim exp As Array = Split(images(ID).ToString(), "\", -1, CompareMethod.Text)
        edittitle.Text = exp(exp.Length - 1)


        bigimg.ImageLocation = images(ID)
        ordermoreinit()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub cancelbutton_Click(sender As Object, e As EventArgs) Handles cancelbutton.Click
        Me.Close()
    End Sub

    Private Sub imageeditdl_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub imagelaoder_Tick(sender As Object, e As EventArgs) Handles imageloader.Tick
        imageloader.Enabled = False
        Panel3.Visible = True
        status.Visible = True
        imgsize.Visible = True
        imgbounds.Visible = True

        status.Text = "Loading Image..."
        Threading.Thread.Sleep(10)
        filepath = images(ID)
        Dim image As Image = System.Drawing.Image.FromFile(images(ID))
        boundsrc = image.GetBounds(GraphicsUnit.Pixel)
        imgbounds.Text = boundsrc.Width.ToString + "x" + boundsrc.Height.ToString
        status.Text = "Calculating ratio"
        Threading.Thread.Sleep(10)
        Dim imgratio As Single = boundsrc.Width / boundsrc.Height
        status.Text = "Resizing workspace"
        Threading.Thread.Sleep(10)

        

        'Actualimage starts at 792,443
        actualimage.Width = actualimage.Height * imgratio
        If actualimage.Width > 792 Then
            actualimage.Height = 443 * (792 / actualimage.Width)
            actualimage.Width = 792
        End If

        'Position workspace
        If actualimage.Width < 792 Then
            actualimage.Location = New Point(3 + (792 - actualimage.Width) / 2, actualimage.Location.Y)
        Else
            actualimage.Location = New Point(actualimage.Location.X, 3 + (443 - actualimage.Height) / 2)
        End If
        scaleval = ((actualimage.Width / boundsrc.Width) * 100)
        imgsize.Text = "SR: " + scaleval.ToString
        imgbounds.Text = boundsrc.Width.ToString + "x" + boundsrc.Height.ToString + " (" + Math.Round(scaleval).ToString + "%)"
        'set crophandle position
        croptop.Location = New Point(10, 10)
        cropbot.Location = New Point(actualimage.Width - 58, actualimage.Height - 58)

        fullimg = image

        status.Text = "Setting Image"

        actualimage.BackgroundImage = image.GetThumbnailImage(actualimage.Width, actualimage.Height, asd, New IntPtr)
        movecrops.Enabled = True
    End Sub

    Private Sub redrawStage()
        boundsrc = fullimg.GetBounds(GraphicsUnit.Pixel)
        imgbounds.Text = boundsrc.Width.ToString + "x" + boundsrc.Height.ToString
        status.Text = "Calculating ratio"
        Dim imgratio As Single = boundsrc.Width / boundsrc.Height
        status.Text = "Resizing workspace"

        'Actualimage starts at 792,443
        actualimage.Width = actualimage.Height * imgratio
        If actualimage.Width > 792 Then
            actualimage.Height = 443 * (792 / actualimage.Width)
            actualimage.Width = 792
        ElseIf actualimage.Height < 443 Then
            actualimage.Width = 792 * (443 / actualimage.Height)
            actualimage.Height = 443
        End If

        'Position workspace
        If actualimage.Width < 792 Then
            actualimage.Location = New Point(3 + (792 - actualimage.Width) / 2, 3)
        Else
            actualimage.Location = New Point(3, 3 + (443 - actualimage.Height) / 2)
        End If
        scaleval = ((actualimage.Width / boundsrc.Width) * 100)
        imgsize.Text = "SR: " + scaleval.ToString
        imgbounds.Text = boundsrc.Width.ToString + "x" + boundsrc.Height.ToString + " (" + Math.Round(scaleval).ToString + "%)"
        'set crophandle position
        croptop.Location = New Point(10, 10)
        cropbot.Location = New Point(actualimage.Width - 58, actualimage.Height - 58)

        actualimage.BackgroundImage = fullimg
    End Sub

    Private Sub croptop_MouseDown(sender As Object, e As MouseEventArgs) Handles croptop.MouseDown
        ctmove = True
    End Sub

    Private Sub croptop_MouseUp(sender As Object, e As MouseEventArgs) Handles croptop.MouseUp
        ctmove = False
    End Sub

    Private Sub cropbot_MouseDown(sender As Object, e As MouseEventArgs) Handles cropbot.MouseDown
        cbmove = True

    End Sub

    Private Sub cropbot_MouseUp(sender As Object, e As MouseEventArgs) Handles cropbot.MouseUp
        cbmove = False
    End Sub

    Private Sub movecrops_Tick(sender As Object, e As EventArgs) Handles movecrops.Tick
        'Define the cursor
        Me.Cursor = New Cursor(Cursor.Current.Handle)

        'Set position of crop handles (if being moved)
        If ctmove Then
            croptop.Location = New Drawing.Point(Control.MousePosition.X - 64 - actualimage.Location.X - 16, Control.MousePosition.Y - 99 - actualimage.Location.Y - 16)
        ElseIf cbmove Then
            cropbot.Location = New Drawing.Point(Control.MousePosition.X - 64 - actualimage.Location.X - 32, Control.MousePosition.Y - 99 - actualimage.Location.Y - 32)
        End If

        'set position of crop panels
        croppanel_top.Height = croptop.Location.Y + 16
        croppanel_bottom.Height = (actualimage.Height - cropbot.Location.Y) - 32
        croppanel_left.Width = croptop.Location.X + 16
        croppanel_right.Width = (actualimage.Width - cropbot.Location.X) - 32

        'Set the croptanlge bounds
        croptangle.X = (croptop.Location.X + 16) / (scaleval / 100)
        croptangle.Y = (croptop.Location.Y + 16) / (scaleval / 100)
        croptangle.Width = ((cropbot.Location.X + 32) / (scaleval / 100)) - ((croptop.Location.X + 16) / (scaleval / 100))
        croptangle.Height = ((cropbot.Location.Y + 32) / (scaleval / 100)) - ((croptop.Location.Y + 16) / (scaleval / 100))

        'update cropinfo
        'Using the scale we can work stuff out. Things like X, Y and the new res.
        cropstats.Text = Math.Round(croptangle.X).ToString + ", " + Math.Round(croptangle.Y).ToString + vbNewLine + Math.Round(croptangle.Width).ToString + "x" + Math.Round(croptangle.Height).ToString
    End Sub

    Private Sub crop_Click(sender As Object, e As EventArgs) Handles crop.Click
        cropbot.Visible = True
        croptop.Visible = True
        cropdetail.Visible = True
        croppanel_bottom.Visible = True
        croppanel_left.Visible = True
        croppanel_right.Visible = True
        croppanel_top.Visible = True
    End Sub



    Private Sub applycrop_Click(sender As Object, e As EventArgs) Handles applycrop.Click
        undostor = fullimg
        Dim CropRect As Rectangle = croptangle
        Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
        Using grp = Graphics.FromImage(CropImage)
            grp.DrawImage(fullimg, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)

            fullimg = CropImage
        End Using
        redrawStage()
    End Sub

    Private Sub reset_Click(sender As Object, e As EventArgs) Handles reset.Click
        undostor = fullimg
        fullimg = System.Drawing.Image.FromFile(images(ID))
        redrawStage()

    End Sub

    Private Sub undo_Click(sender As Object, e As EventArgs) Handles undo.Click
        Dim tempimg As Image
        tempimg = undostor
        undostor = fullimg
        fullimg = tempimg
        redrawStage()


    End Sub

    Private Sub rotleft_Click(sender As Object, e As EventArgs) Handles rotleft.Click
        undostor = fullimg
        fullimg.RotateFlip(RotateFlipType.Rotate270FlipNone)
        redrawStage()
    End Sub

    Private Sub rotright_Click(sender As Object, e As EventArgs) Handles rotright.Click
        undostor = fullimg
        fullimg.RotateFlip(RotateFlipType.Rotate90FlipNone)
        redrawStage()
    End Sub

    Private Sub savebutton_Click(sender As Object, e As EventArgs) Handles savebutton.Click
        Dim filename As String = ""
        Try
            filename = "C:\e\edit_" + ID.ToString + ".bmp"
            fullimg.Save(filename, System.Drawing.Imaging.ImageFormat.Bmp)
        Catch ex As Exception
            filename = "C:\e\edit_" + ID.ToString + "_" + TimeOfDay.Second.ToString + ".bmp"
            fullimg.Save(filename, System.Drawing.Imaging.ImageFormat.Bmp)
        End Try

        images(ID) = filename
        preloader.doID(ID, True)
        gallery.navgenerator.Enabled = True
        Me.Close()
    End Sub


    'And now, for the new, multiorder stuff. ayyy lmao


    Private Sub nextpage_Click(sender As Object, e As EventArgs) Handles nextpage.Click
        imagelaoder_Tick(sender, e)
        multiorderpanel.Visible = False

    End Sub

    Private Sub ordermoreinit()
        'Update size names
        siz1label.Text = My.Settings.Size1Text
        size2label.Text = My.Settings.Size2Text
        size3label.Text = My.Settings.Size3Text
        size4label.Text = My.Settings.Size4Text
        size5label.Text = My.Settings.Size5Text

        'Update 'scores'
        ordermorescoreupdate()
    End Sub

    Private Sub ordermorescoreupdate()
        size1count.Text = copies(ID, 0)
        size2count.Text = copies(ID, 1)
        size3count.Text = copies(ID, 2)
        size4count.Text = copies(ID, 3)
        size5count.Text = copies(ID, 4)
    End Sub

    Private Sub ordermore(size As Integer, adj As Integer)
        If adj > 0 Then
            copies(ID, size) = copies(ID, size) + adj
        Else
            If copies(ID, size) = 0 Then
            Else
                copies(ID, size) = copies(ID, size) + adj
            End If
        End If
        ordermorescoreupdate()
    End Sub


    Private Sub minus1_Click(sender As Object, e As EventArgs) Handles minus1.Click
        ordermore(0, -1)
    End Sub

    Private Sub plus1_Click(sender As Object, e As EventArgs) Handles plus1.Click
        ordermore(0, 1)
    End Sub

    Private Sub minus2_Click(sender As Object, e As EventArgs) Handles minus2.Click
        ordermore(1, -1)
    End Sub

    Private Sub plus2_Click(sender As Object, e As EventArgs) Handles plus2.Click
        ordermore(1, 1)
    End Sub

    Private Sub minus3_Click(sender As Object, e As EventArgs) Handles minus3.Click
        ordermore(2, -1)
    End Sub

    Private Sub plus3_Click(sender As Object, e As EventArgs) Handles plus3.Click
        ordermore(2, 1)
    End Sub

    Private Sub minus4_Click(sender As Object, e As EventArgs) Handles minus4.Click
        ordermore(3, -1)
    End Sub

    Private Sub plus4_Click(sender As Object, e As EventArgs) Handles plus4.Click
        ordermore(3, 1)
    End Sub

    Private Sub minus5_Click(sender As Object, e As EventArgs) Handles minus5.Click
        ordermore(4, -1)
    End Sub

    Private Sub plus5_Click(sender As Object, e As EventArgs) Handles plus5.Click
        ordermore(4, 1)
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        gallery.recount()
        Me.Close()
    End Sub

    Private Sub status_Click(sender As Object, e As EventArgs) Handles status.Click

    End Sub
End Class