Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Diagnostics.Eventing
Imports System.Dynamic
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.ApplicationServices
Imports Windows.Win32.System

Public Class Form3
    Dim qry As String
    Dim cmd As New OleDbCommand()
    Dim Reader As OleDbDataReader


    Private Sub Form3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        keysound()
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        userlog.Close()
        Mlog.Close()
        Label1.Text = "BILL GENERATION"
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        Label2.Text = "Product ID"
        Label3.Text = "Product Name"
        Label4.Text = "Price"
        Label5.Text = "Discount"
        Label6.Text = "Quantity"
        Label7.Text = "GST"

        Label10.Text = "Amount"
        Label9.Text = "Net Amount"
        Label8.Text = "Total Discount"
        Label11.Text = "Total Items"
        Label12.Text = "Bill ID"
        Label13.Text = "Customer Phone No."
        Label14.Text = "Bill Operator"
        Label15.Text = "Total GST"

        Button1.Text = "Back"
        Button2.Text = "Clear"
        Button3.Text = "Delete"
        Button5.Text = "Draft"
        Button6.Text = "Payment"
        Button7.Text = "Close"
        TextBox14.Text = userid
        TextBox14.Enabled = False
        LoadDraftBills()

        Call connect()
        Dim str As String
        str = "select max(BID) from bill"
        Dim da As New OleDb.OleDbDataAdapter(str, conn)
        Dim dt As New DataTable("bill")
        da.Fill(dt)
        Dim pro_id As Double

        If IsDBNull(dt.Rows(0).Item(0)) OrElse dt.Rows.Count = 0 Then
            pro_id = 102500
        Else
            pro_id = Val(dt.Rows(0).Item(0))
        End If

        TextBox12.Text = pro_id + 1
        billid = TextBox12.Text

        conn.Close()
        ListView1.Columns.Clear()
        ListView1.View = View.Details
        ListView1.Columns.Add("PID", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("Product Name", 150, HorizontalAlignment.Left)
        ListView1.Columns.Add("Price", 100, HorizontalAlignment.Left)
        ListView1.Columns.Add("Quantity", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("Discount", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("GST", 80, HorizontalAlignment.Left)
        ListView1.Columns.Add("Net Amount", 120, HorizontalAlignment.Left)

        ListView1.FullRowSelect = True


        ListView1.BorderStyle = BorderStyle.FixedSingle
        ListView1.BackColor = Color.White
        ListView1.ForeColor = Color.Black
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            conn.Close()
            If TextBox1.Text = "" Then Exit Sub
            Dim pid As Integer = Val(TextBox1.Text)

            Call connect()
            Dim query As String = "SELECT * FROM products WHERE PID = @PID"
            Dim cmd As New OleDbCommand(query, conn)
            cmd.Parameters.AddWithValue("@PID", pid)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()

                Dim pname As String = reader("PName").ToString()
                Dim price As Double = Val(reader("Price"))
                Dim discount As Double = Val(reader("Discount"))
                Dim gst As Double = Val(reader("GST"))
                Dim avlqty As Double = Val(reader("Quantity"))

                TextBox2.Text = pname
                TextBox3.Text = price.ToString("F2")
                TextBox4.Text = discount.ToString("F2")
                TextBox5.Text = gst.ToString("F2")

                Dim quantity As Integer = 1
                Dim amount As Double = price * quantity
                Dim discountAmount As Double = amount * (discount / 100)
                Dim gstAmount As Double = (amount - discountAmount) * (gst / 100)
                Dim netAmount As Double = amount - discountAmount

                TextBox6.Text = netAmount.ToString("F2")

                If quantity > avlqty Then
                    MessageBox.Show("Insufficient stock. Available quantity: " & avlqty.ToString(), "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                Dim itemExists As Boolean = False
                For Each item As ListViewItem In ListView1.Items
                    If item.SubItems(0).Text = pid.ToString() Then
                        itemExists = True
                        quantity = Integer.Parse(item.SubItems(3).Text) + 1
                        If quantity > avlqty Then
                            MessageBox.Show("Insufficient stock. Available quantity: " & avlqty.ToString(), "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        item.SubItems(3).Text = quantity.ToString()

                        amount = price * quantity
                        discountAmount = amount * (discount / 100)
                        gstAmount = (amount - discountAmount) * (gst / 100)
                        netAmount = amount - discountAmount

                        item.SubItems(6).Text = netAmount.ToString("F2")
                        Exit For
                    End If
                Next

                If Not itemExists Then
                    Dim newItem As New ListViewItem(pid.ToString())
                    newItem.SubItems.Add(pname)
                    newItem.SubItems.Add(price.ToString("F2"))
                    newItem.SubItems.Add(quantity.ToString())
                    newItem.SubItems.Add(discount.ToString("F2"))
                    newItem.SubItems.Add(gst.ToString("F2"))
                    newItem.SubItems.Add(netAmount.ToString("F2"))
                    ListView1.Items.Add(newItem)
                End If

                TextBox1.Clear()
                TextBox1.Focus()
            Else
            End If
            reader.Close()
            conn.Close()

            UpdateTotals()
        Catch ex As Exception
            MessageBox.Show("Error fetching product details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub UpdateTotals()
        Dim totalQuantity, totalAmount, totalDiscount, totalGst, netTotal As Double

        For Each item As ListViewItem In ListView1.Items
            Dim quantity As Double = Val(item.SubItems(3).Text)
            Dim price As Double = Val(item.SubItems(2).Text)
            Dim discount As Double = Val(item.SubItems(4).Text)
            Dim gst As Double = Val(item.SubItems(5).Text)

            Dim amount As Double = price * quantity
            Dim discountAmount As Double = amount * (discount / 100)
            Dim gstAmount As Double = (amount - discountAmount) * (gst / 100)
            Dim netAmount As Double = amount - discountAmount

            totalQuantity += quantity
            totalDiscount += discountAmount
            totalGst += gstAmount
            netTotal += netAmount
        Next

        TextBox7.Text = ListView1.Items.Count.ToString()
        TextBox8.Text = totalQuantity.ToString("F2")
        TextBox9.Text = totalDiscount.ToString("F2")
        TextBox11.Text = totalGst.ToString("F2")
        TextBox10.Text = netTotal.ToString("F2")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        player.PlaySync()

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox13.Text = ""

        ListView1.Items.Clear()
    End Sub
    Public Sub reloaddata()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
        TextBox13.Text = ""

        ListView1.Items.Clear()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        player.PlaySync()

        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        player.PlaySync()

        If TextBox13.Text = "" Then
            MsgBox("Please enter customer number.", MsgBoxStyle.Exclamation, "Input Validation")
            Exit Sub
        End If
        Dim custname = TextBox13.Text
        Dim bid As Integer = TextBox12.Text
        Dim pname = TextBox2.Text
        Dim price As Integer = TextBox3.Text
        Dim boperater = TextBox14.Text
        Dim discount As Integer = TextBox4.Text
        Dim gst As Integer = TextBox5.Text
        Dim amount As Integer = TextBox6.Text
        Dim biquantity As Integer = TextBox7.Text
        Dim total_Item As Integer = TextBox8.Text
        Dim total_dis As Integer = TextBox9.Text
        Dim total_gst As Integer = TextBox11.Text
        Dim net_amount As Integer = TextBox10.Text


        connect()
        Try
            If conn.State = ConnectionState.Closed Then
                connect()
            End If
            For Each itm As ListViewItem In ListView1.Items
                Dim qry As String = "INSERT INTO draftbill (Cphno, BID, PName, Price,Discount, Amount, Quantity, Gst, PID) " &
                                    "VALUES (@phone, @BID, @Pname, @Price, @Dis, @Amt, @Qty, @GST, @Pid)"
                cmd = New OleDbCommand(qry, conn)
                cmd.Parameters.AddWithValue("@Phone", custname)
                cmd.Parameters.AddWithValue("@BID", billid)
                cmd.Parameters.AddWithValue("@Pname", itm.SubItems(1).Text)
                cmd.Parameters.AddWithValue("@Price", itm.SubItems(2).Text)
                cmd.Parameters.AddWithValue("@Dis", itm.SubItems(4).Text)
                cmd.Parameters.AddWithValue("@Amt", itm.SubItems(6).Text)
                cmd.Parameters.AddWithValue("@Qty", itm.SubItems(3).Text)
                cmd.Parameters.AddWithValue("@GST", itm.SubItems(5).Text)
                cmd.Parameters.AddWithValue("@Pid", itm.SubItems(0).Text)


                cmd.ExecuteNonQuery()
            Next

            MessageBox.Show("Draft bill saved successfully.", "Draft Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
            reloaddata()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
        LoadDraftBills()
    End Sub
    Private Sub LoadDraftBills()
        Try
            If conn.State = ConnectionState.Closed Then
                connect()
            End If
            Dim qry As String = "SELECT DISTINCT Cphno FROM draftbill"
            cmd = New OleDbCommand(qry, conn)

            Dim Reader As OleDbDataReader = cmd.ExecuteReader()

            ComboBox1.Items.Clear()

            While Reader.Read()
                Dim customerPhone As String = Reader("Cphno").ToString()
                ComboBox1.Items.Add(customerPhone)
            End While

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Reader IsNot Nothing AndAlso Not Reader.IsClosed Then
                Reader.Close()
            End If
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            If conn.State = ConnectionState.Closed Then
                connect()
            End If
            reloaddata()
            Dim Phone As String = ComboBox1.SelectedItem.ToString()


            Dim qry As String = "SELECT * FROM draftbill WHERE Cphno = @Phone"
            Dim qryDelete As String = "DELETE FROM draftbill WHERE Cphno = @Phone"
            Using cmd As New OleDbCommand(qry, conn)
                cmd.Parameters.AddWithValue("@Phone", Phone)

                Using Reader As OleDbDataReader = cmd.ExecuteReader()
                    ListView1.Items.Clear()
                    Dim totalAmount As Double = 0

                    While Reader.Read()
                        Dim customerPhone As String = Reader("Cphno").ToString()
                        TextBox13.Text = customerPhone
                        Dim itm As New ListViewItem(Reader("PID").ToString())
                        itm.SubItems.Add(Reader("PName").ToString())
                        itm.SubItems.Add(Reader("Price").ToString())
                        itm.SubItems.Add(Reader("Quantity").ToString())
                        itm.SubItems.Add(Convert.ToDouble(Reader("Discount").ToString()))
                        itm.SubItems.Add(Convert.ToDouble(Reader("Gst").ToString()))
                        itm.SubItems.Add(Convert.ToDouble(Reader("Amount").ToString()))
                        ListView1.Items.Add(itm)

                    End While
                End Using
            End Using



            If conn.State = ConnectionState.Closed Then
                connect()
            End If
            Using cmdDelete As New OleDbCommand(qryDelete, conn)
                cmdDelete.Parameters.AddWithValue("@Phone", Phone)
                cmdDelete.ExecuteNonQuery()
            End Using
            ComboBox1.SelectedText = ""
            ComboBox1.Text = ""


            MessageBox.Show("Draft bill loaded successfully.", "Draft Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information)



        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try

        LoadDraftBills()
        UpdateTotals()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        player.PlaySync()
        Payment.SetListViewData(ListView1.Items)

        custnum = TextBox13.Text.ToString
        totalItems = ListView1.Items.Count.ToString()
        totalQuantity = TextBox8.Text.ToString
        totalDiscount = TextBox9.Text.ToString
        totalAmount = TextBox10.Text.ToString
        Amount = Val(totalAmount) + Val(totalDiscount)
        'MsgBox(Amount)
        gst = TextBox11.Text.ToString
        Payment.Show()
        Close()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        player.PlaySync()

        exitvc()
        Timer1.Interval = 3000
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Me.Close()
    End Sub

End Class
