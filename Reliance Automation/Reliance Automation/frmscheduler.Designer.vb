<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmscheduler
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmscheduler))
        Me.tmrCAN = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblprdline = New System.Windows.Forms.Label()
        Me.lblCanNo = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblLastCanNo = New System.Windows.Forms.Label()
        Me.lbltime = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tmrCAN
        '
        Me.tmrCAN.Interval = 500
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Production Line :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 19)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CAN No:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 19)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "CAN Status :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 19)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Last CAN No : "
        '
        'lblprdline
        '
        Me.lblprdline.AutoSize = True
        Me.lblprdline.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblprdline.Location = New System.Drawing.Point(155, 24)
        Me.lblprdline.Name = "lblprdline"
        Me.lblprdline.Size = New System.Drawing.Size(39, 19)
        Me.lblprdline.TabIndex = 4
        Me.lblprdline.Text = "------"
        '
        'lblCanNo
        '
        Me.lblCanNo.AutoSize = True
        Me.lblCanNo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCanNo.Location = New System.Drawing.Point(155, 64)
        Me.lblCanNo.Name = "lblCanNo"
        Me.lblCanNo.Size = New System.Drawing.Size(39, 19)
        Me.lblCanNo.TabIndex = 5
        Me.lblCanNo.Text = "------"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(155, 101)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 19)
        Me.lblStatus.TabIndex = 6
        Me.lblStatus.Text = "------"
        '
        'lblLastCanNo
        '
        Me.lblLastCanNo.AutoSize = True
        Me.lblLastCanNo.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastCanNo.Location = New System.Drawing.Point(155, 136)
        Me.lblLastCanNo.Name = "lblLastCanNo"
        Me.lblLastCanNo.Size = New System.Drawing.Size(39, 19)
        Me.lblLastCanNo.TabIndex = 7
        Me.lblLastCanNo.Text = "------"
        '
        'lbltime
        '
        Me.lbltime.AutoSize = True
        Me.lbltime.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltime.Location = New System.Drawing.Point(669, 136)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(151, 19)
        Me.lbltime.TabIndex = 8
        Me.lbltime.Text = "Last CAN Scan Time"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(319, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(269, 19)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Stallion Systems and Solutions Pvt Ltd."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.Location = New System.Drawing.Point(207, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 19)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Developed By :"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Image = Global.Reliance_Automation.My.Resources.Resources.exit_button_svg_0
        Me.PictureBox1.Location = New System.Drawing.Point(777, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(51, 41)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 11
        Me.PictureBox1.TabStop = False
        '
        'frmscheduler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.DarkSalmon
        Me.ClientSize = New System.Drawing.Size(829, 185)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lbltime)
        Me.Controls.Add(Me.lblLastCanNo)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.lblCanNo)
        Me.Controls.Add(Me.lblprdline)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmscheduler"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reliance Automation CAN filling Application"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tmrCAN As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblprdline As System.Windows.Forms.Label
    Friend WithEvents lblCanNo As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblLastCanNo As System.Windows.Forms.Label
    Friend WithEvents lbltime As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
