Public Class Form5
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Form5_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form1.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "admin" Then
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
            If (System.IO.Directory.Exists("c:\Aurora\Rubrica\" + ComboBox1.Text + "\")) Then
                My.Computer.FileSystem.DeleteDirectory("c:\Aurora\Rubrica\" + ComboBox1.Text + "\", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            End If
            If (System.IO.Directory.Exists("c:\Aurora\Calendario\" + ComboBox1.Text + "\")) Then
                My.Computer.FileSystem.DeleteDirectory("c:\Aurora\Calendario\" + ComboBox1.Text + "\", FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
            End If
            My.Computer.FileSystem.DeleteFile("c:\Aurora\Account\" + ComboBox1.Text + ".txt")
            ComboBox1.Items.Remove(ComboBox1.Text)
            Dim scrivi As New IO.StreamWriter("c:\Aurora\Account\all.txt")
            For x = 0 To ComboBox1.Items.Count - 1
                scrivi.WriteLine(ComboBox1.Items(x))
            Next
            scrivi.Close()
            msg = "Profilo eliminato con successo!"
            title = "INFO"
            style = MsgBoxStyle.Information
            MsgBox(msg, style, title)
            ComboBox1.Text = ""
        End If
dfg:
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text <> TextBox2.Text Then
            MsgBox("Password non corrispondono", MsgBoxStyle.Critical, "ERRORE")
            GoTo lol
        End If
        Dim scrivi As New IO.StreamWriter("c:\Aurora\Account\" + ComboBox1.Text + ".txt")
        scrivi.WriteLine(ComboBox1.Text)
        scrivi.WriteLine(TextBox1.Text)
        scrivi.Close()
        MsgBox("Password Cambiata!", MsgBoxStyle.Information, "INFO")
lol:
    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim carica As New IO.StreamReader("c:\Aurora\Account\all.txt")
            While carica.Peek > -1
                ComboBox1.Items.Add(carica.ReadLine())
            End While
            carica.Close()
        Catch err As Exception
            MsgBox("Non ci sono altri utenti!", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class