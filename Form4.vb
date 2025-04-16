Public Class Form4
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value <> 100 Then
            ProgressBar1.Value = ProgressBar1.Value + 20

        Else
            Timer1.Enabled = False
            Me.Hide()
            collectbil()

            reportbill.TriggerPrint(billid)
            Form3.Show()
        End If


    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ProgressBar1.Maximum = 100
        printbil()
        Timer1.Enabled = True
    End Sub
End Class