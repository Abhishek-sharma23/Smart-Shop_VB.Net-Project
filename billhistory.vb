Imports System.Data.OleDb
Imports System.Reflection.Emit

Public Class billhistory
    Dim cmd As OleDbCommand
    Dim Reader As OleDbDataReader

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        player.PlaySync()

        Try
            connect()
            Dim str As String
            str = "select * from bill where Cphno = '" & TextBox1.Text & "'"
            Dim da As New OleDbDataAdapter(str, conn)
            Dim dt As New DataTable
            da.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()

        End Try

        Try
            connect()
            Dim str As String
            str = "select count(*) as cnt from bill where Cphno = '" & TextBox1.Text & "'"
            cmd = New OleDbCommand(str, conn)
            Reader = cmd.ExecuteReader
            If Reader.Read Then
                Label1.Text = Reader("cnt").ToString
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        conn.Close()
    End Sub

 

    Private Sub billhistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Text = "Show Data"
        Button2.Text = "Back"
        Label1.Text = "0"
        Label2.Text = "Number Of Times"
        Label3.Text = "Please Enter Number"
        Label4.Text = "Customer Visit History"
        Label4.Left = (ClientSize.Width - Label4.Width) / 2

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        player.PlaySync()

        Me.Hide()
        Billdet.Show()
        Label1.Text = "0"
        TextBox1.Text = " "
        DataGridView1.Columns.Clear()
    End Sub

    Private Sub billhistory_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        keysound()
    End Sub
End Class