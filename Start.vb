Public Class Start
    Private Sub Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        startfm()
        Timer1.Interval = 4000
        Timer1.Start()
        Label1.Text = "Welcome To"
        Label2.Text = "Smart-Shop"
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Form1.Show()
        Me.Close()
    End Sub
End Class