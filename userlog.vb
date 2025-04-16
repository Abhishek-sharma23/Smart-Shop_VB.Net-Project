Imports System.Data.OleDb

Public Class userlog
    Private Sub userlog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        loginvc()
        Label1.Text = "User Login"
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        Label2.Text = "User ID"
        Label3.Text = "Password"
        Button1.Text = "Back"
        Button2.Text = "Login"
        Button3.Text = "Sign Up"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        player.PlaySync()

        If Len(TextBox1.Text) = 0 Then
            MsgBox("Please Enter The User Name")
            TextBox1.Focus()
        ElseIf Len(TextBox2.Text) = 0 Then
            MsgBox("Please Enter The Password")
            TextBox2.Focus()
        Else
            Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DeLL\source\repos\Abilldb.accdb"
            Dim query As String = "SELECT * FROM [user] WHERE UID = @UserID AND Password = @Password"


            Using connection As New OleDbConnection(connectionString)
                Using command As New OleDbCommand(query, connection)
                    command.Parameters.AddWithValue("UID", TextBox1.Text)
                    command.Parameters.AddWithValue("Password", TextBox2.Text)

                    Try
                        connection.Open()

                        Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())
                        Dim reader As OleDbDataReader = command.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()

                            userid = reader("UName").ToString()

                        End If
                        reader.Close()

                        If result > 0 Then
                            Form3.Show()
                            'MsgBox("Login Successfully Welcome " + userid)
                            uservc()
                            Me.Close()
                        Else
                            MsgBox("Please Enter Correct User ID and Password")
                        End If
                    Catch ex As Exception
                        MsgBox("Error: " & ex.Message)
                    End Try
                End Using
            End Using
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        player.PlaySync()

        usignup.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        player.PlaySync()

        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub userlog_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        keysound()
    End Sub
End Class