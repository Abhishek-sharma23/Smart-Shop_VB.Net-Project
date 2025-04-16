Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class UIP
    Private Sub UIP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Payment Method UPI"
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        Label2.Text = "Bill Operator"
        Label3.Text = "Net Amount"
        Button1.Text = "Print Bill"
        Button2.Text = "Back"

        TextBox1.Text = userid.ToString

        TextBox2.Text = totalAmount.ToString
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        player.PlaySync()

        Payment.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        player.PlaySync()

        Try
            Payment.SaveBill()

        Catch ex As Exception
            MsgBox("BILL NOT SAVED")
        End Try

        Form4.Show()
        Me.Hide()
    End Sub
End Class