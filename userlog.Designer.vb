<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class userlog
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
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Trajan Pro", 24F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Label1.Location = New Point(461, 40)
        Label1.Name = "Label1"
        Label1.Size = New Size(164, 51)
        Label1.TabIndex = 0
        Label1.Text = "Label1"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Segoe UI", 13.8F)
        TextBox1.Location = New Point(670, 192)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(185, 38)
        TextBox1.TabIndex = 1
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Segoe UI", 13.8F)
        TextBox2.Location = New Point(670, 303)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(185, 38)
        TextBox2.TabIndex = 2
        TextBox2.UseSystemPasswordChar = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 13.8F)
        Label2.ForeColor = Color.Black
        Label2.Location = New Point(364, 199)
        Label2.Name = "Label2"
        Label2.Size = New Size(81, 31)
        Label2.TabIndex = 3
        Label2.Text = "Label2"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 13.8F)
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(364, 306)
        Label3.Name = "Label3"
        Label3.Size = New Size(81, 31)
        Label3.TabIndex = 4
        Label3.Text = "Label3"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 18F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(205, 439)
        Button1.Name = "Button1"
        Button1.Size = New Size(209, 98)
        Button1.TabIndex = 5
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Segoe UI", 18F)
        Button2.ForeColor = Color.White
        Button2.Location = New Point(522, 439)
        Button2.Name = "Button2"
        Button2.Size = New Size(209, 98)
        Button2.TabIndex = 6
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Segoe UI", 18F)
        Button3.ForeColor = Color.White
        Button3.Location = New Point(820, 439)
        Button3.Name = "Button3"
        Button3.Size = New Size(209, 98)
        Button3.TabIndex = 7
        Button3.Text = "Button3"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' userlog
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1263, 622)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(Label1)
        Name = "userlog"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Designed By - Abhishek Sharma"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
End Class
