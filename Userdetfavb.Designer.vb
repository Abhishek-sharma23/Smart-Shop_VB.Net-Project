<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Userdetfavb
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
        ListView1 = New ListView()
        Button1 = New Button()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' ListView1
        ' 
        ListView1.Location = New Point(73, 148)
        ListView1.Name = "ListView1"
        ListView1.Size = New Size(1113, 257)
        ListView1.TabIndex = 5
        ListView1.UseCompatibleStateImageBehavior = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 18F)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(546, 485)
        Button1.Name = "Button1"
        Button1.Size = New Size(214, 91)
        Button1.TabIndex = 4
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Trajan Pro", 24F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(0), CByte(2), CByte(88))
        Label1.Location = New Point(626, 33)
        Label1.Name = "Label1"
        Label1.Size = New Size(164, 51)
        Label1.TabIndex = 3
        Label1.Text = "Label1"
        ' 
        ' Userdetfavb
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1263, 622)
        Controls.Add(ListView1)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Name = "Userdetfavb"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Designed By - Abhishek Sharma"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ListView1 As ListView
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
End Class
