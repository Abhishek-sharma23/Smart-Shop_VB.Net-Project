Imports System.Data.OleDb

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load, MyBase.Load
        Me.KeyPreview = True
        Button1.Text = "Back"
        Button2.Text = "Add Product"
        Button3.Text = "Update Product"
        Button4.Text = "Delete Product"
        Button5.Text = "Clear"
        Button6.Text = "Close"
        PopulateComboBox()
        showdata()
        Label1.Text = "Product Id"
        Label2.Text = "Product Name"
        Label3.Text = "MRP"
        Label4.Text = "GST"
        Label5.Text = "DISCOUNT"
        Label6.Text = "Quantity"
        Label7.Text = "Category"
        Label8.Text = "Smart-Shop"
        Label8.Left = (ClientSize.Width - Label1.Width) / 2
        Label9.Text = "STOCK DATE"
        TextBox8.Text = Now.Date
        TextBox8.Enabled = False
    End Sub

    Private Sub PopulateComboBox()
        Try
            Call connect()
            Dim query As String = "SELECT categoryname FROM category"
            Dim cmd As New OleDbCommand(query, conn)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            ComboBox1.Items.Clear()
            While reader.Read()
                ComboBox1.Items.Add(reader("categoryname").ToString())
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        player.PlaySync()

        Adminfm.Show()
        Me.Hide()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        player.PlaySync()

        clr()
    End Sub

    Public Sub auto()
        Call connect()
        Dim str As String
        str = "select max(PID) from products"
        Dim da As New OleDb.OleDbDataAdapter(str, conn)
        Dim dt As New DataTable("products")
        da.Fill(dt)
        Dim pro_id As Double

        If IsDBNull(dt.Rows(0).Item(0)) OrElse dt.Rows.Count = 0 Then
            pro_id = 100
        Else
            pro_id = Val(dt.Rows(0).Item(0))
        End If

        TextBox1.Text = pro_id + 1
        conn.Close()

    End Sub

    Public Sub clr()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        ComboBox1.Text = ""
        auto()
    End Sub

    Public Sub showdata()
        Try
            Call connect()
            Dim str As String
            str = "select * from products"
            Dim da As New OleDb.OleDbDataAdapter(str, conn)
            Dim dt As New DataTable("products")
            da.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show("Error loading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
            auto()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        player.PlaySync()

        Try
            If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "" Then
                MsgBox("All fields must be filled out before adding a product.", MsgBoxStyle.Exclamation, "Input Validation")
                Exit Sub
            End If

            Dim str As String
            Call connect()
            Dim rs As New OleDb.OleDbCommand
            str = "insert into products values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TextBox6.Text & "','" & ComboBox1.Text & "','" & TextBox8.Text & "')"
            rs.CommandText = str
            rs.CommandType = CommandType.Text
            rs.Connection = conn
            rs.ExecuteNonQuery()
            conn.Close()
            Call showdata()
            clr()
        Catch ex As Exception
            MessageBox.Show("Error adding product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        player.PlaySync()

        Try
            Dim str As String
            Dim x As Integer
            Dim pid As Integer

            If Integer.TryParse(TextBox1.Text, pid) Then
                If TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Or ComboBox1.Text = "" Then
                    MsgBox("All fields must be filled out before updating a product.", MsgBoxStyle.Exclamation, "Input Validation")
                    Exit Sub
                End If

                str = "SELECT PID FROM products WHERE PID = @PID"
                Call connect()

                Dim checkCmd As New OleDb.OleDbCommand(str, conn)
                checkCmd.Parameters.AddWithValue("@PID", pid)

                Dim reader As OleDb.OleDbDataReader = checkCmd.ExecuteReader()
                If reader.HasRows Then
                    reader.Close()

                    str = "UPDATE products SET PName = @ProductName, Price = @MRP, GST = @GST, Discount = @Discount, Quantity = @Quantity, Category = @Category, STOCKDATE = @StockDate WHERE PID = @PID"
                    Dim updateCmd As New OleDb.OleDbCommand(str, conn)

                    updateCmd.Parameters.AddWithValue("@ProductName", TextBox2.Text)
                    updateCmd.Parameters.AddWithValue("@MRP", Val(TextBox3.Text))
                    updateCmd.Parameters.AddWithValue("@GST", Val(TextBox4.Text))
                    updateCmd.Parameters.AddWithValue("@Discount", Val(TextBox5.Text))
                    updateCmd.Parameters.AddWithValue("@Quantity", Val(TextBox6.Text))
                    updateCmd.Parameters.AddWithValue("@Category", ComboBox1.Text)
                    updateCmd.Parameters.AddWithValue("@StockDate", TextBox8.Text)
                    updateCmd.Parameters.AddWithValue("@PID", pid)

                    x = MsgBox("Do you want to update this product?", MsgBoxStyle.YesNo)
                    If x = 6 Then
                        updateCmd.ExecuteNonQuery()
                        MsgBox("Product updated successfully.")
                    End If

                    conn.Close()
                    Call showdata()
                    clr()
                Else
                    reader.Close()
                    conn.Close()
                    MsgBox("Product ID not found. Please enter a valid Product ID.", MsgBoxStyle.Critical, "Error")
                End If
            Else
                MsgBox("Invalid Product ID. Please select a valid product.", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MessageBox.Show("Error updating product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        player.PlaySync()

        Try
            Dim str As String
            Dim x As Integer
            Dim pid As Integer
            If Integer.TryParse(TextBox1.Text, pid) Then
                str = "DELETE FROM products WHERE PID = @PID"
                Call connect()

                Dim rs As New OleDb.OleDbCommand
                rs.CommandText = str
                rs.CommandType = CommandType.Text
                rs.Connection = conn
                rs.Parameters.AddWithValue("@PID", pid)

                x = MsgBox("Do you want to delete this product?", MsgBoxStyle.YesNo)
                If x = 6 Then
                    rs.ExecuteNonQuery()
                    MsgBox("Product deleted successfully.")
                End If

                conn.Close()
                Call showdata()
            Else
                MsgBox("Invalid Product ID.", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MessageBox.Show("Error deleting product: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Try
            TextBox1.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
            TextBox2.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
            TextBox3.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
            TextBox4.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
            TextBox5.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
            TextBox6.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString
            TextBox8.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString
        Catch ex As Exception
            MessageBox.Show("Error selecting product data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        player.PlaySync()

        exitvc()
        Timer1.Interval = 3000
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Me.Close()
    End Sub

    Private Sub Form2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        keysound()
    End Sub
End Class
