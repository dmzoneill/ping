Public Class Form1

    Public Function Ping(ByVal host As String) As String
        Try
            Dim a As New System.Net.NetworkInformation.Ping
            Dim b As System.Net.NetworkInformation.PingReply
            Dim txtlog As String = ""
            Dim c As New System.Net.NetworkInformation.PingOptions
            c.DontFragment = True
            c.Ttl = 64
            Dim data As String = "aaaaaaaaaaaaaaaa"
            Dim bt As Byte() = System.Text.Encoding.ASCII.GetBytes(data)
            Dim i As Int16
            For i = 1 To 4
                b = a.Send(host, 2000, bt, c)
                If b.Status = Net.NetworkInformation.IPStatus.Success Then
                    txtlog += "Reply from " & host & " in " & b.RoundtripTime & " ms, ttl " & b.Options.Ttl & vbCrLf
                End If
                If b.Status = Net.NetworkInformation.IPStatus.DestinationHostUnreachable Then
                    txtlog += "Destination Host Unreachable" & vbCrLf
                End If
                If b.Status = Net.NetworkInformation.IPStatus.TimedOut Then
                    txtlog += "Reply timed out" & vbCrLf
                End If
            Next i
            Return txtlog
        Catch ex As Exception
            Return "Ping error"
        End Try
    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim x As String

        x = Ping(TextBox1.Text)
        RichTextBox1.Text = x
    End Sub
End Class
