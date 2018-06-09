Public Class Form2

#Region "Variables"
    Dim Location1 As String
    Dim FILE_NAME As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Scanner"
    Dim Student As String = FILE_NAME & "\Student"
    Dim StdName As String = Student & "\Student Name.txt"
    Dim StdGrade As String = Student & "\Student Grade.txt"
    Dim StdID As String = Student & "\Student ID.txt"
#End Region

#Region "Timer1"
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label3.Text = TimeOfDay
        Label4.Text = DateTime.Now.ToString("MM/dd/yyyy")
    End Sub
#End Region

#Region "Form2 Load"
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label3.Text = TimeOfDay
        Label4.Text = DateTime.Now.ToString("MM/dd/yyyy")
        Timer1.Enabled = True
        Form3.Show()
        Form3.Close()
    End Sub
#End Region

#Region "Exit"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
#End Region

#Region "Done"
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If ComboBox1.SelectedIndex = 6 Then
            Location1 = InputBox("Type in your Location")
            ListBox6.Items.Add(Location1)
        Else
            ListBox6.Items.Add(ComboBox1.SelectedItem)
        End If
        ListBox1.Items.Add(TextBox1.Text)
        ListBox2.Items.Add(TextBox2.Text)
        ListBox3.Items.Add(TextBox3.Text)
        ListBox4.Items.Add(TextBox4.Text)
        ListBox5.Items.Add(TextBox5.Text)
    End Sub
#End Region

#Region "listBoxRead"
    Private Sub listBoxRead(ByVal listBoxSaved, ByVal fileLocation)
        Dim array() As String
        array = IO.File.ReadAllLines(fileLocation)
        For i = 0 To array.Count - 1
            If array(i) IsNot "" Then
                listBoxSaved.Items.Add(array(i))
            End If
        Next
    End Sub
#End Region

#Region "Search Students Button"
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        For i = 0 To Form3.ListBox6.Items.Count - 1
            If TextBox6.Text = Form3.ListBox6.Items.Item(i) Then
                TextBox1.Text = Form3.ListBox4.Items.Item(i)
                TextBox2.Text = Form3.ListBox5.Items.Item(i)
                TextBox3.Text = Form3.ListBox6.Items.Item(i)
            End If
        Next

    End Sub
#End Region

End Class