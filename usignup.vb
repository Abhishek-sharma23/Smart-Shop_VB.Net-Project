Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class usignup
    Private Sub usignup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Label1.Text = "User Sign up"
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        Label2.Text = "User ID"
        Label3.Text = "User Name"
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

        userlog.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        player.PlaySync()

        Try
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Or TextBox8.Text = "" Then
                MsgBox("All fields must be filled out before Sign Up.", MsgBoxStyle.Exclamation, "Input Validation")
                Exit Sub
            End If

            Call connect()

            Dim query As String = "INSERT INTO [user] (UID, UName, UPno, [Password], Salary, Address, [State], City) " &
                              "VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "', " &
                              TextBox5.Text & ", '" & TextBox6.Text & "', '" & TextBox7.Text & "', '" & TextBox8.Text & "')"

            Dim cmd As New OleDb.OleDbCommand(query, conn)
            cmd.ExecuteNonQuery()

            MsgBox("User added successfully.", MsgBoxStyle.Information, "Success")

            conn.Close()


        Catch ex As Exception
            MessageBox.Show("Error adding user: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
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

    Private Sub usignup_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        keysound()
    End Sub
End Class