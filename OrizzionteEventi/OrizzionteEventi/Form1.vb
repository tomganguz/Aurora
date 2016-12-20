Public Class Form1
    Public Shared Property ThisMoment As Date
    Dim msg As String
    Dim title As String
    Dim style As MsgBoxStyle
    Private colMDIform As Object

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        End
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label3.Text = Now
    End Sub

    Private Sub SplachScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripTextBox1.Text = "Sei connesso come: " + LoginForm1.utente
    End Sub
    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        End
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form3.Show()
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If LoginForm1.utente = "admin" Then
            Form5.Show()
            Me.Hide()
        Else
            gestutente.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Me.Hide()
        AboutBox1.Show()
    End Sub
End Class