Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class msign
    Private Sub msign_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Label1.Text = "Manager Sign up"
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        Label2.Text = "Manager ID"
        Label3.Text = "Manager Name"
        Label4.Text = "Phone No."
        Label5.Text = "Password"
        Label6.Text = "Salary"
        Label7.Text = "Address"
        Label8.Text = "State"
        Label9.Text = "City"
        Button1.Text = "Back"
        Button2.Text = "Sign Up"
        Button3.Text = "Clear"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        player.PlaySync()

        Mlog.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        player.PlaySync()

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        player.PlaySync()

        Try
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Then
                MsgBox("All fields must be filled out before Sign Up.", MsgBoxStyle.Exclamation, "Input Validation")
                Exit Sub
            End If

            Dim str As String
            Call connect()
            Dim rs As New OleDb.OleDbCommand
            str = "insert into manager values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TextBox8.Text & "')"
            rs.CommandText = str
            rs.CommandType = CommandType.Text
            rs.Connection = conn
            rs.ExecuteNonQuery()
            conn.Close()
        Catch ex As Exception
            MessageBox.Show("Error adding product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""

    End Sub

    Private Sub msign_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        keysound()
    End Sub
End Class