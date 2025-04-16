Public Class Billdet
    Private Sub Billdet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Bill Details"
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        Button1.Text = "Back"
        Button2.Text = "Visit Hitory"
        showdata()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        player.PlaySync()

        Adminfm.Show()
        Close()
    End Sub
    Public Sub showdata()
        Try
            Call connect()
            Dim str As String
            str = "select * from bill"
            Dim da As New OleDb.OleDbDataAdapter(str, conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        player.PlaySync()

        Me.Hide()
        billhistory.Show()
    End Sub
End Class