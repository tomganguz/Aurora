Public Class Form2
    Dim max As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button2.Text = Int(Rnd() * max) + 1
        Button3.Text = Int(Rnd() * max) + 1
        Button4.Text = Int(Rnd() * max) + 1
        Button5.Text = Int(Rnd() * max) + 1
        Button6.Text = Int(Rnd() * max) + 1
        Button7.Text = Int(Rnd() * max) + 1
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.Text = Int(Rnd() * max) + 1
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.Text = Int(Rnd() * max) + 1
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.Text = Int(Rnd() * max) + 1
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button5.Text = Int(Rnd() * max) + 1
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button6.Text = Int(Rnd() * max) + 1
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Button7.Text = Int(Rnd() * max) + 1
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Button2.Text = ""
        Button3.Text = ""
        Button4.Text = ""
        Button5.Text = ""
        Button6.Text = ""
        Button7.Text = ""
    End Sub

    Private Sub ToolStripTextBox1_TextChanged(sender As Object, e As EventArgs) Handles ToolStripTextBox1.TextChanged
        Try
            max = ToolStripTextBox1.Text
        Catch err As Exception
            If ToolStripTextBox1.Text = "" Then
            Else
                MsgBox("Valore errato!", MsgBoxStyle.Critical, "Error")
            End If
        End Try
    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripTextBox1.Text = 99
    End Sub
    Private Sub Form2_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        End
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Hide()
        Form1.Show()
    End Sub
End Class