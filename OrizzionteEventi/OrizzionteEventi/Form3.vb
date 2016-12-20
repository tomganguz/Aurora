Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Form4.Show()
    End Sub
    Private Sub Form3_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        End
    End Sub

    Private Sub MonthCalendar1_(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        TextBox2.Text = CStr(Me.MonthCalendar1.SelectionRange.Start)
        Dim delta As String = CStr(Me.MonthCalendar1.SelectionRange.Start)
        delta = Replace(CStr(Me.MonthCalendar1.SelectionRange.Start), "/", "_")
        If My.Computer.FileSystem.FileExists("c:\Aurora\Calendario\" + LoginForm1.utente + "\" + delta + ".txt") Then
            Dim leggi As New IO.StreamReader("c:\Aurora\Calendario\" + LoginForm1.utente + "\" + delta + ".txt")
            While leggi.Peek > -1
                RichTextBox1.Text = leggi.ReadLine()
            End While
            leggi.Close()
        Else
            RichTextBox1.Text = ""
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            MonthCalendar1.SelectionEnd = TextBox2.Text
        Catch errore As Exception
            MsgBox("Valore errato!", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripTextBox1.Text = "Sei connesso come: " + LoginForm1.utente
        If (Not System.IO.Directory.Exists("C:\Aurora\Calendario\")) Then
            System.IO.Directory.CreateDirectory("C:\Aurora\Calendario\")
        End If
        If (Not System.IO.Directory.Exists("C:\Aurora\Calendario\" + LoginForm1.utente + "\")) Then
            System.IO.Directory.CreateDirectory("C:\Aurora\Calendario\" + LoginForm1.utente + "\")
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Not RichTextBox1.Text = "" Then
            Dim data As String = CStr(Me.MonthCalendar1.SelectionRange.Start)
            data = Replace(CStr(Me.MonthCalendar1.SelectionRange.Start), "/", "_")
            Dim scrivi As New IO.StreamWriter("c:\Aurora\Calendario\" + LoginForm1.utente + "\" + data + ".txt")
            scrivi.WriteLine(RichTextBox1.Text)
            scrivi.Close()
        Else
            MsgBox("Nulla da salvare!", MsgBoxStyle.Critical, "ERRORE")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim data As String = CStr(Me.MonthCalendar1.SelectionRange.Start)
        data = Replace(CStr(Me.MonthCalendar1.SelectionRange.Start), "/", "_")
        If My.Computer.FileSystem.FileExists("c:\Aurora\Calendario\" + LoginForm1.utente + "\" + data + ".txt") Then
            My.Computer.FileSystem.DeleteFile("c:\Aurora\Calendario\" + LoginForm1.utente + "\" + data + ".txt")
            MsgBox("attività eliminata", MsgBoxStyle.Information, "INFO")
            RichTextBox1.Text = ""
        Else
            MsgBox("nulla da eliminare", MsgBoxStyle.Critical, "ERRORE")
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Hide()
        Form1.Show()
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Form4.Show()
    End Sub
End Class