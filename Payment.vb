Imports System.Data.OleDb
Imports System.Windows.Forms.ListView
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Payment
    Dim qry As String
    Dim cmd As New OleDbCommand()
    Private Sub Payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        paymentfm()
        ListView2.Visible = "False"
        Label1.Text = "Payment"
        Label1.Left = (Me.ClientSize.Width - Label1.Width) / 2
        Button1.Text = "Cash"
        Button2.Text = "UPI"
        Button3.Text = "Card"
        Button4.Text = "Back"
        ListView2.Columns.Clear()
        ListView2.View = View.Details
        ListView2.Columns.Add("PID", 80, HorizontalAlignment.Left)
        ListView2.Columns.Add("Product Name", 150, HorizontalAlignment.Left)
        ListView2.Columns.Add("Price", 100, HorizontalAlignment.Left)
        ListView2.Columns.Add("Quantity", 80, HorizontalAlignment.Left)
        ListView2.Columns.Add("Discount", 80, HorizontalAlignment.Left)
        ListView2.Columns.Add("GST", 80, HorizontalAlignment.Left)
        ListView2.Columns.Add("Net Amount", 120, HorizontalAlignment.Left)
    End Sub
    Public Sub SetListViewData(listViewItems As ListViewItemCollection)
        ListView2.Items.Clear()

        For Each item As ListViewItem In listViewItems
            ListView2.Items.Add(item.Clone())
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        player.PlaySync()

        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        player.PlaySync()
        mode = "CASH"

        Cash.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        player.PlaySync()
        mode = "UPI"
        UIP.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        player.PlaySync()
        mode = "CARD"

        Card.Show()
        Me.Hide()
    End Sub

    Public Sub SaveBill()
        Try

            InsertBill(billid, userid, custnum, totalItems, totalQuantity, Amount, totalDiscount, gst, totalAmount, mode)

            For Each item As ListViewItem In ListView2.Items
                Dim productID As Integer = Convert.ToInt32(item.SubItems(0).Text)
                Dim productName As String = item.SubItems(1).Text.ToString
                Dim productMRP As String = item.SubItems(2).Text.ToString
                Dim quantity As String = item.SubItems(3).Text
                Dim discount As String = item.SubItems(4).Text
                Dim totalAmountRow As String = item.SubItems(6).Text

                InsertBillData(billid, productID, productName, productMRP, quantity, discount, totalAmountRow)
            Next

        Catch ex As Exception
            MessageBox.Show("Error saving bill: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Public Sub InsertBill(billid As Integer, userid As String, custnum As String, totalItems As String, totalQuantity As String, Amount As String, totalDiscount As String, gst As String, totalAmount As String, mode As String)
        Try
            If conn.State = ConnectionState.Closed Then
                connect()
            End If

            qry = "INSERT INTO bill (BID, Billop, Cphno, TItem,TQty, Amount, TDiscount, TGST, NAmount,Mode) " &
           "VALUES (@bill_id, @userid, @cust_ph, @total_item, @total_qty, @amount, @total_dis, @gst, @netamount,@mode)"
            cmd = New OleDbCommand(qry, conn)
            cmd.Parameters.AddWithValue("@bill_id", Convert.ToInt32(billid))
            cmd.Parameters.AddWithValue("@userid", userid.ToString)
            cmd.Parameters.AddWithValue("@cust_ph", custnum.ToString)
            cmd.Parameters.AddWithValue("@total_item", totalItems.ToString)
            cmd.Parameters.AddWithValue("@total_qty", totalQuantity.ToString)
            cmd.Parameters.AddWithValue("@amount", Amount.ToString)
            cmd.Parameters.AddWithValue("@total_dis", totalDiscount.ToString)
            cmd.Parameters.AddWithValue("@gst", gst.ToString)
            cmd.Parameters.AddWithValue("@netamount", totalAmount.ToString)
            cmd.Parameters.AddWithValue("@mode", mode.ToString)

            cmd.ExecuteNonQuery()

        Catch ex As OleDbException
            MessageBox.Show("MySQL Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("General Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Public Sub InsertBillData(billID As Integer, productID As Integer, productname As String, productMRP As String, quantity As String, discount As String, totalAmount As String)
        Try
            If conn.State = ConnectionState.Closed Then
                connect()
            End If

            qry = "INSERT INTO billdata (BID, PID, PName, Price, Qty,Discount, Tamt) " &
           "VALUES (@BillID, @ProductID, @ProductName, @ProductMRP, @Quantity, @Discount, @TotalAmount)"
            cmd = New OleDbCommand(qry, conn)

            cmd.Parameters.AddWithValue("@BillID", Convert.ToInt32(billID))
            cmd.Parameters.AddWithValue("@ProductID", productID)
            cmd.Parameters.AddWithValue("@ProductName", productname.ToString)
            cmd.Parameters.AddWithValue("@ProductMRP", productMRP.ToString)

            cmd.Parameters.AddWithValue("@Quantity", quantity.ToString)
            cmd.Parameters.AddWithValue("@Discount", discount.ToString)
            cmd.Parameters.AddWithValue("@TotalAmount", totalAmount.ToString)

            cmd.ExecuteNonQuery()
            qry = "UPDATE products SET Quantity = Quantity - @Quantity WHERE PID = @ProductID"
            cmd = New OleDbCommand(qry, conn)
            cmd.Parameters.AddWithValue("@Quantity", quantity)
            cmd.Parameters.AddWithValue("@ProductID", productID)

            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub


End Class