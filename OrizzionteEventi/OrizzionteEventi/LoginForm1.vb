Public Class LoginForm1
    Public Shared utente As String
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.DirectoryExists("c:\Aurora\") = False Then
            My.Computer.FileSystem.CreateDirectory("c:\Aurora\")
            IO.File.SetAttributes("c:\Aurora\", IO.FileAttributes.Hidden)
        End If
        If My.Computer.FileSystem.DirectoryExists("c:\Aurora\Account\") = False Then
            My.Computer.FileSystem.CreateDirectory("c:\Aurora\Account\")
        End If
        If My.Computer.FileSystem.FileExists("c:\Aurora\Account\admin.txt") = False Then
            Dim scrivi As New IO.StreamWriter("c:\Aurora\Account\admin.txt")
            scrivi.WriteLine("admin")
            scrivi.WriteLine("admin")
            scrivi.Close()
        End If
    End Sub
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim account As String = UsernameTextBox.Text
        If My.Computer.FileSystem.FileExists("c:\Aurora\Account\" + account + ".txt") Then
            Dim leggi As New IO.StreamReader("c:\Aurora\Account\" + account + ".txt")
            Dim A As String
            Dim B As String
            While leggi.Peek > -1
                A = leggi.ReadLine()
                B = leggi.ReadLine()
            End While
            leggi.Close()

            If UsernameTextBox.Text = A And PasswordTextBox.Text = B Then
                utente = UsernameTextBox.Text
                Label1.Text = ""
                UsernameTextBox.Text = ""
                PasswordTextBox.Text = ""
                Form1.Show()
                Me.Hide()
            Else
                MsgBox("ACCESSO NEGATO", MsgBoxStyle.Critical, "errore autenticazione")
                UsernameTextBox.Text = ""
                PasswordTextBox.Text = ""
            End If
        Else
            MsgBox("ACCESSO NEGATO", MsgBoxStyle.Critical, "errore autenticazione")
            UsernameTextBox.Text = ""
            PasswordTextBox.Text = ""
        End If
    End Sub
    Private Sub LoginForm1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim account As String = UsernameTextBox.Text
        'Dim scrivi As New IO.StreamWriter("c:\Aurora\Account\" & account + ".txt")
        'scrivi.WriteLine(UsernameTextBox.Text)
        'scrivi.WriteLine(PasswordTextBox.Text)
        'MsgBox("Account creato con successo!", MsgBoxStyle.Information, "Info")
        'scrivi.Close()
        Me.Hide()
        Registrazione.Show()
        UsernameTextBox.Text = ""
        PasswordTextBox.Text = ""
    End Sub
End Class
