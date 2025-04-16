Imports System.Data.OleDb

Public Class adminlog
    Private Sub adminlog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        loginvc()
        Label1.Text = "User Login"
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        Label2.Text = "User ID"
        Label3.Text = "Password"
        Button1.Text = "Back"
        Button2.Text = "Login"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        player.PlaySync()

        Me.Hide()
        Form1.Show()
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
            Dim query As String = "SELECT * FROM [admin] WHERE AID = @UserID AND Password = @Password"


            Using connection As New OleDbConnection(connectionString)
                Using command As New OleDbCommand(query, connection)
                    command.Parameters.AddWithValue("AID", TextBox1.Text)
                    command.Parameters.AddWithValue("Password", TextBox2.Text)

                    Try
                        connection.Open()

                        Dim result As Integer = Convert.ToInt32(command.ExecuteScalar())
                        Dim reader As OleDbDataReader = command.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()

                            userid = reader("AName").ToString()

                        End If
                        reader.Close()

                        If result > 0 Then
                            Adminfm.Show()
                            'MsgBox("Login Successfully Welcome " + userid)

                            Me.Close()
                        Else
                            MsgBox("Please Enter Correct Admin ID and Password")
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

    Private Sub adminlog_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        keysound()
    End Sub
End Class