Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Text = "Admin"
        Button2.Text = "User"
        Button3.Text = "Manager"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        player.PlaySync()

        userlog.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        player.PlaySync()

        adminlog.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        player.PlaySync()

        Mlog.Show()
        Me.Close()
    End Sub


End Class
