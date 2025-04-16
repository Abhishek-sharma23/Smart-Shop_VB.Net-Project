Imports System.Media
Imports System.Numerics


Public Class Managdet
    Private Sub Managdet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Manager Details"
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        Button1.Text = "Back"
        Button1.Left = (Me.ClientSize.Width - Button1.Width) / 2

        ListView1.Columns.Clear()
        ListView1.View = View.Details
        ListView1.Columns.Add("MID", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("Manager Name", 150, HorizontalAlignment.Left)
        ListView1.Columns.Add("Phone No.", 120, HorizontalAlignment.Left)
        ListView1.Columns.Add("Password", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("Salary", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("Address", 150, HorizontalAlignment.Left)
        ListView1.Columns.Add("State", 120, HorizontalAlignment.Left)
        ListView1.Columns.Add("City", 120, HorizontalAlignment.Left)


        ListView1.FullRowSelect = True



        ListView1.BorderStyle = BorderStyle.FixedSingle
        ListView1.BackColor = Color.White
        ListView1.ForeColor = Color.Black


        Try
            ListView1.Items.Clear()

            Dim connectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DeLL\source\repos\Abilldb.accdb"

            Using conn As New OleDb.OleDbConnection(connectionString)
                conn.Open()

                Dim query As String = "SELECT * FROM [manager]"

                Using cmd As New OleDb.OleDbCommand(query, conn)
                    Using reader As OleDb.OleDbDataReader = cmd.ExecuteReader()
                        If reader.HasRows Then
                            While reader.Read()
                                Dim item As New ListViewItem(reader("MID").ToString())
                                item.SubItems.Add(reader("MName").ToString())
                                item.SubItems.Add(reader("MPno").ToString())
                                item.SubItems.Add(reader("Password").ToString())
                                item.SubItems.Add(reader("Salary").ToString())
                                item.SubItems.Add(reader("Address").ToString())
                                item.SubItems.Add(reader("State").ToString())
                                item.SubItems.Add(reader("City").ToString())
                                ListView1.Items.Add(item)
                            End While
                        Else
                            MessageBox.Show("No data found in the user table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading user data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        player.PlaySync()

        Adminfm.Show()
        Me.Hide()


    End Sub
End Class