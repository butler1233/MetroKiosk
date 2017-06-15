<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class receipt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(receipt))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.kiosk = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.order = New System.Windows.Forms.Label()
        Me.infoboxasdasd = New System.Windows.Forms.Label()
        Me.infobox = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Price = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BetterPrinter = New System.Drawing.Printing.PrintDocument()
        Me.BorderMarker = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BorderMarker.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(-4, -5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(406, 101)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'kiosk
        '
        Me.kiosk.AutoSize = True
        Me.kiosk.Font = New System.Drawing.Font("Consolas", 16.0!)
        Me.kiosk.Location = New System.Drawing.Point(86, 104)
        Me.kiosk.Name = "kiosk"
        Me.kiosk.Size = New System.Drawing.Size(84, 26)
        Me.kiosk.TabIndex = 1
        Me.kiosk.Text = "Label1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Black", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 30)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Kiosk:"
        '
        'order
        '
        Me.order.Font = New System.Drawing.Font("Segoe UI Black", 16.0!)
        Me.order.Location = New System.Drawing.Point(0, 130)
        Me.order.Name = "order"
        Me.order.Size = New System.Drawing.Size(400, 61)
        Me.order.TabIndex = 3
        Me.order.Text = "Label1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Line2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.order.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'infoboxasdasd
        '
        Me.infoboxasdasd.AutoSize = True
        Me.infoboxasdasd.Font = New System.Drawing.Font("Consolas", 16.0!, System.Drawing.FontStyle.Bold)
        Me.infoboxasdasd.Location = New System.Drawing.Point(76, 224)
        Me.infoboxasdasd.Name = "infoboxasdasd"
        Me.infoboxasdasd.Size = New System.Drawing.Size(120, 78)
        Me.infoboxasdasd.TabIndex = 5
        Me.infoboxasdasd.Text = "Size:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Quantity:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PPP:"
        Me.infoboxasdasd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'infobox
        '
        Me.infobox.AutoSize = True
        Me.infobox.Font = New System.Drawing.Font("Consolas", 16.0!)
        Me.infobox.Location = New System.Drawing.Point(202, 224)
        Me.infobox.Name = "infobox"
        Me.infobox.Size = New System.Drawing.Size(120, 78)
        Me.infobox.TabIndex = 7
        Me.infobox.Text = "Prints:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Quantity:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PPP:"
        Me.infobox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Consolas", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 283)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(376, 134)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "____________________________________" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please retain this receipt for your records" &
    ". " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "You can also use it to reorder in the near future" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Price
        '
        Me.Price.Font = New System.Drawing.Font("Segoe UI Semibold", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Price.Location = New System.Drawing.Point(150, 181)
        Me.Price.Name = "Price"
        Me.Price.Size = New System.Drawing.Size(250, 48)
        Me.Price.TabIndex = 9
        Me.Price.Text = "£99.99"
        Me.Price.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Consolas", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 338)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(378, 258)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "____________________________________" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "The Photo Shop" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9 Allport Lane" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Bromborough" &
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Wirral" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CH62 7HH" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "0151 334 7234" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sales@thephotoshopwirral.com"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'BetterPrinter
        '
        '
        'BorderMarker
        '
        Me.BorderMarker.BackColor = System.Drawing.Color.Red
        Me.BorderMarker.Controls.Add(Me.Panel2)
        Me.BorderMarker.Location = New System.Drawing.Point(0, 0)
        Me.BorderMarker.Name = "BorderMarker"
        Me.BorderMarker.Size = New System.Drawing.Size(10, 10)
        Me.BorderMarker.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel2.BackColor = System.Drawing.Color.Green
        Me.Panel2.Location = New System.Drawing.Point(5, -15)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(20, 40)
        Me.Panel2.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Black", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 191)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 30)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Information:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Red
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(390, 590)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 10)
        Me.Panel1.TabIndex = 12
        '
        'Panel3
        '
        Me.Panel3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel3.BackColor = System.Drawing.Color.Green
        Me.Panel3.Location = New System.Drawing.Point(5, -15)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(20, 40)
        Me.Panel3.TabIndex = 0
        '
        'receipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(400, 600)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.infobox)
        Me.Controls.Add(Me.infoboxasdasd)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BorderMarker)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.order)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.kiosk)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Price)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "receipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Your Receipt"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BorderMarker.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents kiosk As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents order As System.Windows.Forms.Label
    Friend WithEvents infoboxasdasd As System.Windows.Forms.Label
    Friend WithEvents infobox As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Price As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents BetterPrinter As Printing.PrintDocument
    Friend WithEvents BorderMarker As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
End Class
