Imports System.Data
Imports System.Data.OleDb
Imports System.Media
Module Module1
    Public mode As String = ""

    Public conn As New OleDbConnection
    Public player As New SoundPlayer("C:\Users\DeLL\source\repos\ABilling\click\click1.wav")
    Public billid As Integer = 0
    Public userid As String = ""
    Public custnum As String = ""
    Public totalItems As String = ""
    Public totalQuantity As String = ""
    Public Amount As String = ""
    Public totalDiscount As String = ""
    Public gst As String = ""
    Public totalAmount As String = ""

    Public Sub connect()
        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\DeLL\source\repos\Abilldb.accdb"
        Try

            conn.Open()
            If conn.State <> ConnectionState.Open Then
                MsgBox("Not Connected")
            End If
        Catch ex As Exception
            MsgBox("SOMETHING WENT WRONG...")
        End Try

    End Sub
    Public Sub keysound()
        Try
            Dim player1 As New SoundPlayer("C:\Users\DeLL\source\repos\ABilling\click\click1.wav")
            player1.Play()
        Catch ex As Exception
            MessageBox.Show("Error playing sound: " & ex.Message)
        End Try
    End Sub

    Public Sub startfm()
        Try
            Dim player3 As New SoundPlayer("C:\Users\DeLL\source\repos\ABilling\click\start.wav")
            player3.Play()
        Catch ex As Exception
            MessageBox.Show("Error playing sound: " & ex.Message)
        End Try
    End Sub

    Public Sub paymentfm()
        Try
            Dim player4 As New SoundPlayer("C:\Users\DeLL\source\repos\ABilling\click\payment.wav")
            player4.Play()
        Catch ex As Exception
            MessageBox.Show("Error playing sound: " & ex.Message)
        End Try
    End Sub

    Public Sub printbil()
        Try
            Dim player8 As New SoundPlayer("C:\Users\DeLL\source\repos\ABilling\click\printer.wav")
            player8.Play()
        Catch ex As Exception
            MessageBox.Show("Error playing sound: " & ex.Message)
        End Try
    End Sub

    Public Sub collectbil()
        Try
            Dim player10 As New SoundPlayer("C:\Users\DeLL\source\repos\ABilling\click\collect-bill.wav")
            player10.Play()
        Catch ex As Exception
            MessageBox.Show("Error playing sound: " & ex.Message)
        End Try
    End Sub

    Public Sub loginvc()
        Try
            Dim player5 As New SoundPlayer("C:\Users\DeLL\source\repos\ABilling\click\log-in.wav")
            player5.Play()
        Catch ex As Exception
            MessageBox.Show("Error playing sound: " & ex.Message)
        End Try
    End Sub

    Public Sub managervc()
        Try
            Dim player6 As New SoundPlayer("C:\Users\DeLL\source\repos\ABilling\click\Managervc.wav")
            player6.Play()
        Catch ex As Exception
            MessageBox.Show("Error playing sound: " & ex.Message)
        End Try
    End Sub

    Public Sub uservc()
        Try
            Dim player6 As New SoundPlayer("C:\Users\DeLL\source\repos\ABilling\click\uservc.wav")
            player6.Play()
        Catch ex As Exception
            MessageBox.Show("Error playing sound: " & ex.Message)
        End Try
    End Sub

    Public Sub exitvc()
        Try
            Dim player7 As New SoundPlayer("C:\Users\DeLL\source\repos\ABilling\click\Thankyou.wav")
            player7.Play()
        Catch ex As Exception
            MessageBox.Show("Error playing sound: " & ex.Message)
        End Try
    End Sub

    Public Sub adminv()
        Try
            Dim player9 As New SoundPlayer("C:\Users\DeLL\source\repos\ABilling\click\adminvc.wav")
            player9.Play()
        Catch ex As Exception
            MessageBox.Show("Error playing sound: " & ex.Message)
        End Try
    End Sub

End Module