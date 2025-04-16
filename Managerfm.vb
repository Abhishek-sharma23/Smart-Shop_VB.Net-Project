Public Class Managerfm
    Private Sub Managerfm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        managervc()

        Label1.Text = "Manager Panel"
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        Button1.Text = "User Details"
        Button2.Text = "Generate Bill"
        Button3.Text = "Back"
        Button4.Text = "Close"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        player.PlaySync

        Form1.Show
        Close
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        player.PlaySync()

        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        player.PlaySync

        Userdet.Show
        Hide
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        player.PlaySync()

        exitvc()
        Timer1.Interval = 3000
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Me.Close()
    End Sub
End Class