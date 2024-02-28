Public Class Form1

    Inherits Form

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form2 As New Form2
        form2.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
