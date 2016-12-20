Public Class Registrazione
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Computer.FileSystem.FileExists("c:\Aurora\Account\all.txt") = False Then
            Dim write As New IO.StreamWriter("c:\Aurora\Account\all.txt")
            write.Close()
        End If
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("Non hai inserito tutte le informazioni", MsgBoxStyle.Critical, "ERRORE")
            GoTo cdm
        End If
        If Not TextBox2.Text = TextBox3.Text Then
            MsgBox("Le password non corrispondono", MsgBoxStyle.Critical, "ERRORE")
            GoTo cdm
        End If
        Dim account As String = TextBox1.Text
        Dim scrivi As New IO.StreamWriter("c:\Aurora\Account\" & account + ".txt")
        scrivi.WriteLine(TextBox1.Text)
        scrivi.WriteLine(TextBox2.Text)
        MsgBox("Account creato con successo!", MsgBoxStyle.Information, "Info")
        scrivi.Close()
        Dim aggiorna As IO.StreamWriter
        aggiorna = IO.File.AppendText("c:\Aurora\Account\all.txt")
        aggiorna.WriteLine(account)
        aggiorna.Close()
        Me.Hide()
        LoginForm1.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
cdm:
    End Sub

    Private Sub Registrazione_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        LoginForm1.Show()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub
End Class