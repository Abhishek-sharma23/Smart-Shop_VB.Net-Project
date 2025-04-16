Imports System.Media

Public Class Adminfm
    Private Sub Adminfm_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Load
        adminv()

        Label1.Text = "Admin Panel"
        Label1.Left = (ClientSize.Width - Label1.Width) / 2
        Button1.Text = "User Details"
        Button2.Text = "Manager Details"
        Button3.Text = "Stock Management"
        Button4.Text = "Generate Bill"
        Button5.Text = "Back"
        Button6.Text = "Bill Details"
        Button1.BackColor = Color.FromArgb(0, 2, 88)
        Button1.ForeColor = Color.FromArgb(255, 255, 255)
        Button7.Text = "Draft Bills"
        Button8.Text = "Close"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        player.PlaySync()

        Managdet.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        player.PlaySync()

        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        player.PlaySync()

        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        player.PlaySync()

        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        player.PlaySync()

        Userdetfavb.Show()
        Me.Hide()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        player.PlaySync()

        Billdet.Show()
        Me.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        player.PlaySync

        Draftdet.Show
        Hide
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
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