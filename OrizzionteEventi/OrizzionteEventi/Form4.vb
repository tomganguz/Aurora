Public Class Form4
    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.DirectoryExists("c:\Aurora\Rubrica\") = False Then
            My.Computer.FileSystem.CreateDirectory("c:\Aurora\Rubrica\")
        End If
        If (Not System.IO.Directory.Exists("c:\Aurora\Rubrica\" + LoginForm1.utente + "\")) Then
            System.IO.Directory.CreateDirectory("c:\Aurora\Rubrica\" + LoginForm1.utente + "\")
        End If
        If My.Computer.FileSystem.FileExists("c:\Aurora\Rubrica\" + LoginForm1.utente + "\Contatti.txt") = False Then
            Dim scrivi As New IO.StreamWriter("c:\Aurora\Rubrica\" + LoginForm1.utente + "\Contatti.txt")
            scrivi.Close()
        Else
            Dim carica As New IO.StreamReader("c:\Aurora\Rubrica\" + LoginForm1.utente + "\Contatti.txt")
            While carica.peek > -1
                ComboBox1.Items.Add(carica.ReadLine())
            End While
            carica.Close()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = Nothing Then
            MsgBox("Il campo nome è obbligatorio.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
    If TextBox2.Text = Nothing Then
            MsgBox("Il campo cognome è obbligatorio.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
    If TextBox3.Text = Nothing Then
            MsgBox("Il campo telefono è obbligatorio.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        Dim account As String = TextBox1.Text & " " & TextBox2.Text
        Dim scrivi As New IO.StreamWriter("c:\Aurora\Rubrica\" + LoginForm1.utente + "\" + account + ".txt")
        scrivi.WriteLine(textbox1.text)
        scrivi.WriteLine(TextBox2.Text)
        scrivi.WriteLine(textbox3.text)
        scrivi.WriteLine(TextBox4.Text)
        MsgBox("Salvataggio avvenuto con successo!", MsgBoxStyle.Information, "Info")
        scrivi.Close()
    
    ComboBox1.Items.Add(account)
        Dim aggiorna As IO.StreamWriter
        aggiorna = IO.File.AppendText("c:\Aurora\Rubrica\" + LoginForm1.utente + "\Contatti.txt")
        aggiorna.WriteLine(account)
        aggiorna.Close()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim account As String = ComboBox1.SelectedItem.ToString
        Dim leggi As New IO.StreamReader("c:\Aurora\Rubrica\" + LoginForm1.utente + "\" + account + ".txt")
        While leggi.Peek > -1
            TextBox1.Text = leggi.ReadLine()
            TextBox2.Text = leggi.ReadLine()
            TextBox3.Text = leggi.ReadLine()
            TextBox4.Text = leggi.ReadLine()
        End While
        leggi.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim account As String = ComboBox1.SelectedItem.ToString()
        My.Computer.FileSystem.DeleteFile("c:\Aurora\Rubrica\" + LoginForm1.utente + "\" + account + ".txt")
        ComboBox1.Items.Remove(account)
        Dim scrivi As New IO.StreamWriter("c:\Aurora\Rubrica\" + LoginForm1.utente + "\Contatti.txt")
        For x = 0 To ComboBox1.Items.Count - 1
            scrivi.WriteLine(ComboBox1.Items(x))
        Next
        MsgBox("Eliminato con successo!", MsgBoxStyle.Information, "Info")
        scrivi.Close()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub
End Class