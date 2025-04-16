Imports System.Drawing.Printing
Imports System.IO
Imports System.Drawing
Imports System.Data.OleDb

Module reportbill


    Private WithEvents PD As New PrintDocument
    Private PPD As New PrintPreviewDialog
    Private longpaper As Integer
    Dim totalAmount As String = ""
    Dim cgst As String = ""
    Dim gst As String = ""
    Dim totaldiscount As String = ""

    Private Sub PrintBillReport(billid As Integer)
        Dim billData As New List(Of BillData)()


        Dim modeOfPayment As String = String.Empty
        Dim customerName As String = String.Empty
        Dim customerPhone As String = String.Empty
        Dim cashierName As String = String.Empty

        Dim gstin As String = String.Empty
        Dim city As String = String.Empty
        Dim state As String = String.Empty
        Dim bdate As String = String.Empty
        Dim mob As String = String.Empty
        Dim items As String = String.Empty
        Dim totalqty As String = String.Empty
        Try
            connect()



            Dim billQuery As String = "SELECT * FROM bill WHERE BID = @billid"
            Using cmd As New OleDbCommand(billQuery, conn)
                cmd.Parameters.AddWithValue("@billid", billid)
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        totalAmount = reader("NAmount")
                        gst = reader("TGST")
                        modeOfPayment = reader("Mode").ToString()
                        items = reader("TItem").ToString()
                        totalqty = reader("TQty").ToString()
                        totaldiscount = reader("TDiscount").ToString()
                        custnum = reader("Cphno").ToString()
                        cashierName = reader("Billop").ToString()

                    End If
                End Using
            End Using

            Dim billDataQuery As String = "SELECT * FROM billdata WHERE BID = @billid"
            Using cmd As New OleDbCommand(billDataQuery, conn)
                cmd.Parameters.AddWithValue("@billid", billid)
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim total As String = reader("Tamt")
                        Dim qty As String = reader("Qty")



                        billData.Add(New BillData With {
                .ProductName = reader("PName"),
                .Quantity = qty,
                .Rate = reader("Price"),
                .Amount = total
            })
                    End While
                End Using
            End Using

            changelongpaper(billData.Count)

            GenerateAndPrintBill(billid, billData, totalAmount, gst, modeOfPayment, customerPhone, cashierName, items, totalqty, totaldiscount)

        Catch ex As Exception
            MessageBox.Show("Error during fetching or printing the bill: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        conn.Close()
    End Sub

    Sub changelongpaper(rowcount As Integer)
        longpaper = rowcount * 18 + 605
    End Sub

    Private Sub GenerateAndPrintBill(billid As Integer, billData As List(Of BillData), totalAmount As String, gst As String, modeOfPayment As String, customerPhone As String, cashierName As String, items As String, totalqty As String, totaldiscount As String)
        Try
            Dim printDoc As New PrintDocument()

            printDoc.DefaultPageSettings.PaperSize = New PaperSize("Custom", 315, longpaper)
            printDoc.DefaultPageSettings.Margins = New Margins(10, 10, 10, 10)

            AddHandler printDoc.PrintPage, Sub(previewSender As Object, previewEventArgs As PrintPageEventArgs)
                                               printBillPage(previewSender, previewEventArgs, billData, billid, totalAmount, gst, modeOfPayment, customerPhone, cashierName, items, totalqty, totaldiscount)
                                           End Sub

            PPD.Document = printDoc
            PPD.StartPosition = FormStartPosition.CenterScreen
            PPD.WindowState = FormWindowState.Maximized

            AddHandler PPD.Shown, Sub(previewSender As Object, previewEventArgs As EventArgs)
                                      Dim previewControl As PrintPreviewControl = FindPreviewControl(PPD)
                                      If previewControl IsNot Nothing Then
                                          AddHandler PPD.MouseWheel, Sub(sender, e)
                                                                         Try
                                                                             If e.Delta > 0 Then
                                                                                 previewControl.Zoom += 0.1
                                                                             ElseIf e.Delta < 0 Then
                                                                                 previewControl.Zoom -= 0.1
                                                                             End If

                                                                             If previewControl.Zoom < 0.0 Then
                                                                                 previewControl.Zoom = 0.0
                                                                             End If
                                                                         Catch ex As Exception
                                                                             MessageBox.Show("An error occurred while adjusting zoom: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                         End Try

                                                                     End Sub
                                      End If

                                      Dim printDialog As New PrintDialog()
                                      printDialog.Document = printDoc
                                      printDialog.AllowSomePages = True
                                      printDialog.AllowPrintToFile = False
                                      printDialog.PrinterSettings.DefaultPageSettings.PaperSize = printDoc.DefaultPageSettings.PaperSize

                                      If printDialog.ShowDialog() = DialogResult.OK Then
                                          printDoc.Print()
                                      End If
                                  End Sub

            PPD.ShowDialog()

        Catch ex As Exception
            MessageBox.Show("Error during printing: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function FindPreviewControl(dialog As PrintPreviewDialog) As PrintPreviewControl
        For Each control As Control In dialog.Controls
            If TypeOf control Is PrintPreviewControl Then
                Return DirectCast(control, PrintPreviewControl)
            End If
        Next
        Return Nothing
    End Function
    Private Sub printBillPage(sender As Object, e As PrintPageEventArgs, billData As List(Of BillData), billid As Integer, totalAmount As String, gst As String, modeOfPayment As String, customerPhone As String, cashierName As String, items As String, totalqty As String, totaldiscount As String)
        Dim g As Graphics = e.Graphics
        Dim font As New Font("Arial", 8)
        Dim fonth As New Font("Arial", 7)
        Dim boldFonth As New Font("Times New Roman", 18, FontStyle.Bold)
        Dim boldFont As New Font("Arial", 10, FontStyle.Bold)
        Dim boldFont8 As New Font("Arial", 8, FontStyle.Bold)
        Dim x As Integer = 10
        Dim y As Integer = 10
        Dim lineHeight As Integer = 16
        Dim columnWidths As Integer() = {50, 120, 30, 50, 60}

        g.DrawString("Date: " & DateTime.Now.ToString("dd/MM/yyyy"), fonth, Brushes.Black, x + 1, y)
        g.DrawString("Time: " & DateTime.Now.ToString("hh:mm tt"), fonth, Brushes.Black, x + 220, y)
        y += lineHeight * 1

        Dim textSize As SizeF = g.MeasureString("SMART-SHOP", boldFonth)
        Dim xCenter As Integer = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString("SMART-SHOP", boldFonth, Brushes.Black, xCenter + 5, y)
        y += lineHeight * 2

        textSize = g.MeasureString("AJMER, RAJASTHAN", fonth)
        xCenter = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString("AJMER, RAJASTHAN", fonth, Brushes.Black, xCenter + 5, y)
        y += lineHeight

        textSize = g.MeasureString("-------------------- Have A Nice Day --------------------", font)
        xCenter = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString("-------------------- Have A Nice Day --------------------", font, Brushes.Black, xCenter + 5, y)
        y += lineHeight * 2

        g.DrawString("Bill No: " & billid.ToString(), boldFont, Brushes.Black, x, y)
        y += lineHeight
        g.DrawString("Customer Phone: " & custnum, font, Brushes.Black, x, y)
        y += lineHeight
        g.DrawString("Cashier: " & cashierName, font, Brushes.Black, x, y)
        y += lineHeight

        y += lineHeight * 0.5
        g.DrawString(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", boldFont, Brushes.Black, x, y)
        y += lineHeight

        textSize = g.MeasureString("INVOICE", fonth)
        xCenter = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString("INVOICE", boldFont, Brushes.Black, xCenter, y)
        y += lineHeight

        g.DrawString(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", boldFont, Brushes.Black, x, y)
        y += lineHeight

        g.DrawString("Particulars", boldFont8, Brushes.Black, x + 7, y)
        g.DrawString("Qty", boldFont8, Brushes.Black, x + columnWidths(0) + columnWidths(1) - 3, y)
        g.DrawString("Rate ₹", boldFont8, Brushes.Black, x + columnWidths(0) + columnWidths(1) + columnWidths(2) - 3, y)
        g.DrawString("Total ₹", boldFont8, Brushes.Black, x + columnWidths(0) + columnWidths(1) + columnWidths(2) + columnWidths(3) - 3, y)
        y += lineHeight
        g.DrawString(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", boldFont, Brushes.Black, x, y)
        y += lineHeight

        For Each item In billData

            Dim productName As String = item.ProductName
            Dim productColumnWidth As Integer = columnWidths(1)
            Dim wrappedText As String = WrapText(g, productName, font, productColumnWidth)
            Dim productHeight As Integer = CInt(g.MeasureString(wrappedText, font, productColumnWidth).Height)

            g.DrawString(wrappedText, font, Brushes.Black, x + 7, y)

            g.DrawString(item.Quantity.ToString(), font, Brushes.Black, x + columnWidths(0) - 3 + columnWidths(1), y)

            g.DrawString(item.Rate.ToString(), font, Brushes.Black, x + columnWidths(0) + columnWidths(1) - 3 + columnWidths(2), y)

            g.DrawString(item.Amount.ToString(), font, Brushes.Black, x + columnWidths(0) + columnWidths(1) + columnWidths(2) + columnWidths(3) - 3, y)

            y += Math.Max(lineHeight, productHeight)
        Next

        g.DrawString(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", boldFont, Brushes.Black, x, y)
        y += lineHeight
        g.DrawString("      Items:  " & items & "          QTY:   " & totalqty & "            " & totalAmount, boldFont, Brushes.Black, x, y)
        y += lineHeight
        g.DrawString(" - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", boldFont, Brushes.Black, x, y)
        y += lineHeight

        textSize = g.MeasureString("GST DETAIL", fonth)
        xCenter = (e.PageBounds.Width - textSize.Width) - 130
        g.DrawString("GST DETAIL", boldFont8, Brushes.Black, xCenter, y)

        y += lineHeight

        g.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", font, Brushes.Black, x, y)
        y += lineHeight

        g.DrawString("GST", font, Brushes.Black, x + 70, y)
        x += 180

        g.DrawString("Total Amt", font, Brushes.Black, x, y)
        y += lineHeight
        x = 10
        g.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", font, Brushes.Black, x, y)
        y += lineHeight

        x = 10
        g.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", font, Brushes.Black, x, y)
        y += lineHeight

        g.DrawString(gst, font, Brushes.Black, x + 70, y)
        x += 180

        g.DrawString(totalAmount, font, Brushes.Black, x, y)
        y += lineHeight
        x = 10
        g.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -", font, Brushes.Black, x, y)
        y += lineHeight
        textSize = g.MeasureString("Net Amount: " & totalAmount, boldFont)
        xCenter = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString("Net Amount: " & totalAmount, boldFont, Brushes.Black, xCenter, y)
        y += lineHeight

        textSize = g.MeasureString("YOU SAVED:" & totaldiscount, fonth)
        xCenter = (e.PageBounds.Width - textSize.Width) - 130
        g.DrawString("YOU SAVED: " & totaldiscount, boldFont8, Brushes.Black, xCenter, y)
        y += lineHeight * 1.5

        textSize = g.MeasureString("Mode of Payment: ", fonth)
        xCenter = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString("Mode of Payment: " & modeOfPayment, font, Brushes.Black, xCenter - 20, y)
        y += lineHeight

        textSize = g.MeasureString("Thank you for shopping with us!", font)
        xCenter = (e.PageBounds.Width - textSize.Width) / 2
        g.DrawString("Thank you for shopping with us!", boldFont, Brushes.Black, xCenter - 26, y)
        y += lineHeight
    End Sub

    Private Function WrapText(g As Graphics, text As String, font As Font, maxWidth As Integer) As String
        Dim words As String() = text.Split(" "c)
        Dim wrappedText As String = String.Empty
        Dim currentLine As String = String.Empty

        For Each word As String In words
            Dim testLine As String = If(currentLine = String.Empty, word, currentLine & " " & word)
            If g.MeasureString(testLine, font).Width > maxWidth Then
                wrappedText &= If(wrappedText = String.Empty, currentLine, Environment.NewLine & currentLine)
                currentLine = word
            Else
                currentLine = testLine
            End If
        Next

        wrappedText &= If(wrappedText = String.Empty, currentLine, Environment.NewLine & currentLine)
        Return wrappedText
    End Function

    Public Sub TriggerPrint(billid As Integer)
        PrintBillReport(billid)
    End Sub
End Module

Public Class BillData

    Public Property PGstRate As String
    Public Property ProductName As String
    Public Property Quantity As String
    Public Property Rate As String
    Public Property Amount As String


End Class
