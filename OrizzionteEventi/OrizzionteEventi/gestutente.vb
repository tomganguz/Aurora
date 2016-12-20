Public Class gestutente
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub gestutente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If LoginForm1.utente = "admin" Then
            MsgBox("NON PUOI ELIMINARE ADMIN!", MsgBoxStyle.Critical, "ERRORE")
            GoTo dfg
        End If
        Dim msg As String
        Dim title As String
        Dim style As MsgBoxStyle
        Dim response As MsgBoxResult
        msg = "Vuoi veramente cancellare?"
        style = MsgBoxStyle.DefaultButton2 Or
   MsgBoxStyle.Critical Or MsgBoxStyle.YesNo
        title = "ELIMINAZIONE ACCOUNT"   ' Define title.
        response = MsgBox(msg, style, title)
        If response = MsgBoxResult.Yes Then
            If (System.IO.Directory.Exists("c:\Aurora\Rubrica\" + LoginForm1.utente + "\")) Then
                My.Computer.FileSystem.DeleteDirectory("c:\Aurora\Rubrica\" + LoginForm1.utente + "\", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            End If
            If (System.IO.Directory.Exists("c:\Aurora\Calendario\" + LoginForm1.utente + "\")) Then
                My.Computer.FileSystem.DeleteDirectory("c:\Aurora\Calendario\" + LoginForm1.utente + "\", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            End If
            My.Computer.FileSystem.DeleteFile("c:\Aurora\Account\" + LoginForm1.utente + ".txt")
            msg = "Profilo eliminato con successo!"
            title = "INFO"
            style = MsgBoxStyle.Information
            MsgBox(msg, style, title)
            Me.Hide()
            LoginForm1.Show()
        End If
dfg:
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text <> TextBox2.Text Then
            MsgBox("Password non corrispondono", MsgBoxStyle.Critical, "ERRORE")
            GoTo lol
        End If
        Dim scrivi As New IO.StreamWriter("c:\Aurora\Account\" + LoginForm1.utente + ".txt")
        scrivi.WriteLine(LoginForm1.utente)
        scrivi.WriteLine(TextBox1.Text)
        scrivi.Close()
        MsgBox("Password Cambiata!", MsgBoxStyle.Information, "INFO")
lol:
    End Sub
End Class