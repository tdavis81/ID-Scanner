Public Class Form1

#Region "Login"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "Teacher" And TextBox2.Text = "password" Then
            Form3.Show()
            Me.Hide()
        Else
            MessageBox.Show("You have entered the wrong username/password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub
#End Region

#Region "Exit"
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()

    End Sub
#End Region

#Region "Form1_Load"
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AcceptButton = Button1
        TextBox1.Select()
    End Sub
#End Region

#Region "Login Student"
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Form2.Show()
        Me.Hide()
    End Sub
#End Region

#Region "Exit Student"
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
#End Region

End Class
