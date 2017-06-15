<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StorageDeviceChooser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StorageDeviceChooser))
        Me.headtext = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.storagetimer = New System.Windows.Forms.Timer(Me.components)
        Me.infopanel = New System.Windows.Forms.Panel()
        Me.btfbox = New System.Windows.Forms.Panel()
        Me.btfinish = New System.Windows.Forms.Label()
        Me.capacityblock = New System.Windows.Forms.Panel()
        Me.volused = New System.Windows.Forms.Label()
        Me.volcapacity = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.scanimg = New System.Windows.Forms.PictureBox()
        Me.imagetot = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.volname = New System.Windows.Forms.Label()
        Me.devicetype = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.scantimer = New System.Windows.Forms.Timer(Me.components)
        Me.nextpanel = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.continuebutton = New System.Windows.Forms.Label()
        Me.amountoffiles = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.storageimage = New System.Windows.Forms.PictureBox()
        Me.filescanner = New System.ComponentModel.BackgroundWorker()
        Me.btbox = New System.Windows.Forms.Panel()
        Me.bluetoothinit = New System.Windows.Forms.Label()
        Me.infopanel.SuspendLayout()
        Me.btfbox.SuspendLayout()
        Me.capacityblock.SuspendLayout()
        CType(Me.scanimg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.nextpanel.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.storageimage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.btbox.SuspendLayout()
        Me.SuspendLayout()
        '
        'headtext
        '
        Me.headtext.AutoSize = True
        Me.headtext.Font = New System.Drawing.Font("Segoe UI Light", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.headtext.Location = New System.Drawing.Point(12, 117)
        Me.headtext.Name = "headtext"
        Me.headtext.Size = New System.Drawing.Size(505, 37)
        Me.headtext.TabIndex = 1
        Me.headtext.Text = "Please insert a memory card or USB device."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Light", 22.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 41)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Load Images"
        '
        'storagetimer
        '
        Me.storagetimer.Enabled = True
        '
        'infopanel
        '
        Me.infopanel.Controls.Add(Me.btfbox)
        Me.infopanel.Controls.Add(Me.capacityblock)
        Me.infopanel.Controls.Add(Me.Label7)
        Me.infopanel.Controls.Add(Me.scanimg)
        Me.infopanel.Controls.Add(Me.imagetot)
        Me.infopanel.Controls.Add(Me.Label5)
        Me.infopanel.Controls.Add(Me.volname)
        Me.infopanel.Controls.Add(Me.devicetype)
        Me.infopanel.Font = New System.Drawing.Font("Segoe UI Light", 14.0!)
        Me.infopanel.Location = New System.Drawing.Point(291, 177)
        Me.infopanel.Name = "infopanel"
        Me.infopanel.Size = New System.Drawing.Size(329, 255)
        Me.infopanel.TabIndex = 5
        Me.infopanel.Visible = False
        '
        'btfbox
        '
        Me.btfbox.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btfbox.Controls.Add(Me.btfinish)
        Me.btfbox.Location = New System.Drawing.Point(2, 67)
        Me.btfbox.Name = "btfbox"
        Me.btfbox.Size = New System.Drawing.Size(111, 48)
        Me.btfbox.TabIndex = 12
        Me.btfbox.Visible = False
        '
        'btfinish
        '
        Me.btfinish.AutoSize = True
        Me.btfinish.Font = New System.Drawing.Font("Segoe UI Light", 20.0!)
        Me.btfinish.ForeColor = System.Drawing.Color.White
        Me.btfinish.Location = New System.Drawing.Point(7, 5)
        Me.btfinish.Name = "btfinish"
        Me.btfinish.Size = New System.Drawing.Size(108, 37)
        Me.btfinish.TabIndex = 0
        Me.btfinish.Text = "Next   >"
        '
        'capacityblock
        '
        Me.capacityblock.Controls.Add(Me.volused)
        Me.capacityblock.Controls.Add(Me.volcapacity)
        Me.capacityblock.Controls.Add(Me.Label4)
        Me.capacityblock.Controls.Add(Me.Label1)
        Me.capacityblock.Location = New System.Drawing.Point(1, 66)
        Me.capacityblock.Name = "capacityblock"
        Me.capacityblock.Size = New System.Drawing.Size(241, 49)
        Me.capacityblock.TabIndex = 12
        '
        'volused
        '
        Me.volused.AutoSize = True
        Me.volused.Location = New System.Drawing.Point(104, 25)
        Me.volused.Name = "volused"
        Me.volused.Size = New System.Drawing.Size(84, 25)
        Me.volused.TabIndex = 9
        Me.volused.Text = "Capacity:"
        '
        'volcapacity
        '
        Me.volcapacity.AutoSize = True
        Me.volcapacity.Location = New System.Drawing.Point(82, 0)
        Me.volcapacity.Name = "volcapacity"
        Me.volcapacity.Size = New System.Drawing.Size(84, 25)
        Me.volcapacity.TabIndex = 8
        Me.volcapacity.Text = "Capacity:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 25)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Used Space:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 25)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Capacity:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(143, 200)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 25)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Scanning..."
        '
        'scanimg
        '
        Me.scanimg.BackgroundImage = CType(resources.GetObject("scanimg.BackgroundImage"), System.Drawing.Image)
        Me.scanimg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.scanimg.Location = New System.Drawing.Point(10, 170)
        Me.scanimg.Name = "scanimg"
        Me.scanimg.Size = New System.Drawing.Size(103, 82)
        Me.scanimg.TabIndex = 7
        Me.scanimg.TabStop = False
        '
        'imagetot
        '
        Me.imagetot.Location = New System.Drawing.Point(97, 115)
        Me.imagetot.Name = "imagetot"
        Me.imagetot.Size = New System.Drawing.Size(95, 25)
        Me.imagetot.TabIndex = 7
        Me.imagetot.Text = "Scanning..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 25)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Image files:"
        '
        'volname
        '
        Me.volname.AutoSize = True
        Me.volname.Location = New System.Drawing.Point(4, 40)
        Me.volname.Name = "volname"
        Me.volname.Size = New System.Drawing.Size(125, 25)
        Me.volname.TabIndex = 1
        Me.volname.Text = "Volume Name"
        '
        'devicetype
        '
        Me.devicetype.AutoSize = True
        Me.devicetype.Font = New System.Drawing.Font("Segoe UI Light", 18.0!)
        Me.devicetype.Location = New System.Drawing.Point(4, 4)
        Me.devicetype.Name = "devicetype"
        Me.devicetype.Size = New System.Drawing.Size(135, 32)
        Me.devicetype.TabIndex = 0
        Me.devicetype.Text = "Device Type"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(19, 439)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(601, 134)
        Me.ListBox1.TabIndex = 6
        Me.ListBox1.Visible = False
        '
        'scantimer
        '
        '
        'nextpanel
        '
        Me.nextpanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nextpanel.Controls.Add(Me.Panel2)
        Me.nextpanel.Controls.Add(Me.amountoffiles)
        Me.nextpanel.Controls.Add(Me.Label3)
        Me.nextpanel.Location = New System.Drawing.Point(649, 439)
        Me.nextpanel.Name = "nextpanel"
        Me.nextpanel.Size = New System.Drawing.Size(363, 153)
        Me.nextpanel.TabIndex = 7
        Me.nextpanel.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Panel2.Controls.Add(Me.continuebutton)
        Me.Panel2.Location = New System.Drawing.Point(183, 105)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(180, 48)
        Me.Panel2.TabIndex = 10
        '
        'continuebutton
        '
        Me.continuebutton.AutoSize = True
        Me.continuebutton.Font = New System.Drawing.Font("Segoe UI Light", 20.0!)
        Me.continuebutton.ForeColor = System.Drawing.Color.White
        Me.continuebutton.Location = New System.Drawing.Point(7, 5)
        Me.continuebutton.Name = "continuebutton"
        Me.continuebutton.Size = New System.Drawing.Size(165, 37)
        Me.continuebutton.TabIndex = 0
        Me.continuebutton.Text = "Continue    >"
        '
        'amountoffiles
        '
        Me.amountoffiles.Font = New System.Drawing.Font("Segoe UI Light", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.amountoffiles.Location = New System.Drawing.Point(68, 65)
        Me.amountoffiles.Name = "amountoffiles"
        Me.amountoffiles.Size = New System.Drawing.Size(163, 37)
        Me.amountoffiles.TabIndex = 9
        Me.amountoffiles.Text = "0"
        Me.amountoffiles.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Light", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(225, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 37)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "files found."
        '
        'storageimage
        '
        Me.storageimage.InitialImage = Nothing
        Me.storageimage.Location = New System.Drawing.Point(19, 177)
        Me.storageimage.Name = "storageimage"
        Me.storageimage.Size = New System.Drawing.Size(256, 256)
        Me.storageimage.TabIndex = 4
        Me.storageimage.TabStop = False
        '
        'filescanner
        '
        Me.filescanner.WorkerReportsProgress = True
        '
        'btbox
        '
        Me.btbox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btbox.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btbox.Controls.Add(Me.bluetoothinit)
        Me.btbox.Location = New System.Drawing.Point(19, 538)
        Me.btbox.Name = "btbox"
        Me.btbox.Size = New System.Drawing.Size(306, 48)
        Me.btbox.TabIndex = 11
        Me.btbox.Visible = False
        '
        'bluetoothinit
        '
        Me.bluetoothinit.AutoSize = True
        Me.bluetoothinit.Font = New System.Drawing.Font("Segoe UI Light", 20.0!)
        Me.bluetoothinit.ForeColor = System.Drawing.Color.White
        Me.bluetoothinit.Location = New System.Drawing.Point(7, 5)
        Me.bluetoothinit.Name = "bluetoothinit"
        Me.bluetoothinit.Size = New System.Drawing.Size(294, 37)
        Me.bluetoothinit.TabIndex = 0
        Me.bluetoothinit.Text = "Transfer over Bluetooth..."
        '
        'StorageDeviceChooser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1024, 604)
        Me.Controls.Add(Me.btbox)
        Me.Controls.Add(Me.nextpanel)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.infopanel)
        Me.Controls.Add(Me.storageimage)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.headtext)
        Me.Font = New System.Drawing.Font("Segoe UI Light", 8.25!)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Location = New System.Drawing.Point(0, 93)
        Me.Name = "StorageDeviceChooser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "StorageDeviceChooser"
        Me.TopMost = True
        Me.infopanel.ResumeLayout(False)
        Me.infopanel.PerformLayout()
        Me.btfbox.ResumeLayout(False)
        Me.btfbox.PerformLayout()
        Me.capacityblock.ResumeLayout(False)
        Me.capacityblock.PerformLayout()
        CType(Me.scanimg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.nextpanel.ResumeLayout(False)
        Me.nextpanel.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.storageimage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.btbox.ResumeLayout(False)
        Me.btbox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents headtext As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents storagetimer As System.Windows.Forms.Timer
    Friend WithEvents storageimage As System.Windows.Forms.PictureBox
    Friend WithEvents infopanel As System.Windows.Forms.Panel
    Friend WithEvents volname As System.Windows.Forms.Label
    Friend WithEvents devicetype As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents scantimer As System.Windows.Forms.Timer
    Friend WithEvents imagetot As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents scanimg As System.Windows.Forms.PictureBox
    Friend WithEvents nextpanel As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents continuebutton As System.Windows.Forms.Label
    Friend WithEvents amountoffiles As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents filescanner As System.ComponentModel.BackgroundWorker
    Friend WithEvents btbox As System.Windows.Forms.Panel
    Friend WithEvents bluetoothinit As System.Windows.Forms.Label
    Friend WithEvents capacityblock As System.Windows.Forms.Panel
    Friend WithEvents volused As System.Windows.Forms.Label
    Friend WithEvents volcapacity As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btfbox As System.Windows.Forms.Panel
    Friend WithEvents btfinish As System.Windows.Forms.Label
End Class
