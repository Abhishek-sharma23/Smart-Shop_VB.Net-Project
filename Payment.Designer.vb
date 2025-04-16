<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payment
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
        Button1 = New Button()
        Button2 = New Button()
        Button3 = New Button()
        Button4 = New Button()
        ListView2 = New ListView()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Trajan Pro", 28.1999989F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Label1.Location = New Point(540, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(192, 60)
        Label1.TabIndex = 0
        Label1.Text = "Label1"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 18F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(168, 227)
        Button1.Name = "Button1"
        Button1.Size = New Size(249, 156)
        Button1.TabIndex = 1
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Segoe UI", 18F)
        Button2.ForeColor = Color.White
        Button2.Location = New Point(527, 227)
        Button2.Name = "Button2"
        Button2.Size = New Size(249, 156)
        Button2.TabIndex = 2
        Button2.Text = "Button2"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.BackColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Segoe UI", 18F)
        Button3.ForeColor = Color.White
        Button3.Location = New Point(891, 227)
        Button3.Name = "Button3"
        Button3.Size = New Size(249, 156)
        Button3.TabIndex = 3
        Button3.Text = "Button3"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Segoe UI", 18F)
        Button4.ForeColor = Color.White
        Button4.Location = New Point(527, 436)
        Button4.Name = "Button4"
        Button4.Size = New Size(249, 156)
        Button4.TabIndex = 4
        Button4.Text = "Button4"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' ListView2
        ' 
        ListView2.Location = New Point(872, 12)
        ListView2.Name = "ListView2"
        ListView2.Size = New Size(321, 115)
        ListView2.TabIndex = 5
        ListView2.UseCompatibleStateImageBehavior = False
        ' 
        ' Payment
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1263, 622)
        Controls.Add(ListView2)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Name = "Payment"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Designed By - Abhishek Sharma"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents ListView2 As ListView
End Class
