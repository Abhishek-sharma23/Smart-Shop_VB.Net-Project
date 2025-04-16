<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UIP
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
        Label1 = New Label()
        Button2 = New Button()
        Button1 = New Button()
        TextBox2 = New TextBox()
        Label3 = New Label()
        TextBox1 = New TextBox()
        Label2 = New Label()
        PictureBox2 = New PictureBox()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Trajan Pro", 28.1999989F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Label1.Location = New Point(495, 54)
        Label1.Name = "Label1"
        Label1.Size = New Size(192, 60)
        Label1.TabIndex = 5
        Label1.Text = "Label1"
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Segoe UI", 18F)
        Button2.ForeColor = Color.White
        Button2.Location = New Point(709, 455)
        Button2.Name = "Button2"
        Button2.Size = New Size(263, 125)
        Button2.TabIndex = 4
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 18F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(276, 455)
        Button1.Name = "Button1"
        Button1.Size = New Size(263, 125)
        Button1.TabIndex = 3
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' TextBox2
        ' 
        TextBox2.Enabled = False
        TextBox2.Font = New Font("Segoe UI", 18F)
        TextBox2.Location = New Point(379, 316)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(180, 47)
        TextBox2.TabIndex = 13
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 18F)
        Label3.Location = New Point(106, 315)
        Label3.Name = "Label3"
        Label3.Size = New Size(104, 41)
        Label3.TabIndex = 12
        Label3.Text = "Label3"
        ' 
        ' TextBox1
        ' 
        TextBox1.Enabled = False
        TextBox1.Font = New Font("Segoe UI", 18F)
        TextBox1.Location = New Point(379, 211)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(180, 47)
        TextBox1.TabIndex = 11
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 18F)
        Label2.Location = New Point(106, 210)
        Label2.Name = "Label2"
        Label2.Size = New Size(104, 41)
        Label2.TabIndex = 10
        Label2.Text = "Label2"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Image = My.Resources.Resources.qr
        PictureBox2.Location = New Point(797, 153)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(354, 278)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 14
        PictureBox2.TabStop = False
        ' 
        ' UIP
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1263, 622)
        Controls.Add(PictureBox2)
        Controls.Add(TextBox2)
        Controls.Add(Label3)
        Controls.Add(TextBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Name = "UIP"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Designed By - Abhishek Sharma"
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
