Public Class Form3


#Region "Variables"
    Dim FILE_NAME As String = My.Computer.FileSystem.SpecialDirectories.MyDocuments & "\Scanner"
    Dim Admin As String = FILE_NAME & "\Admin"
    Dim AKelly As String = Admin & "\Mr. Kelly"
    Dim ACristillo As String = Admin & "\Mr. Cristillo"
    Dim Student As String = FILE_NAME & "\Student"
    Dim StdName As String = Student & "\Student Name.txt"
    Dim StdGrade As String = Student & "\Student Grade.txt"
    Dim StdID As String = Student & "\Student ID.txt"
    Dim kellyName As String = AKelly & "\Student Name.txt"
    Dim kellyGrade As String = AKelly & "\Student Grade.txt"
    Dim kellyID As String = AKelly & "\Student ID.txt"
    Dim cristName As String = ACristillo & "\Student Name.txt"
    Dim cristGrade As String = ACristillo & "\Student Grade.txt"
    Dim cristID As String = ACristillo & "\Student ID.txt"
    Dim oldIndex As Integer
#End Region

#Region "Save"
    Private Sub Save()
        If ComboBox1.SelectedIndex = 0 Then
            listBoxPrint(ListBox1, kellyName)
            listBoxPrint(ListBox2, kellyGrade)
            listBoxPrint(ListBox3, kellyID)
        ElseIf ComboBox1.SelectedIndex = 1 Then
            listBoxPrint(ListBox1, cristName)
            listBoxPrint(ListBox2, cristGrade)
            listBoxPrint(ListBox3, cristID)
        End If

        listBoxPrint(ListBox4, StdName)
        listBoxPrint(ListBox5, StdGrade)
        listBoxPrint(ListBox6, StdID)
        MessageBox.Show("Records have been saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
#End Region

#Region "listBoxPrint"
    Private Sub listBoxPrint(ByVal listBoxSaved, ByVal fileLocation)
        Dim array(listBoxSaved.items.count) As String
        For i = 0 To listBoxSaved.Items.Count - 1
            array(i) = listBoxSaved.Items.Item(i)
            IO.File.WriteAllLines(fileLocation, array)
        Next

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

#Region "Creating Files"
    Private Sub CreateFiles()
        'base files
        If IO.File.Exists(FILE_NAME & "\all files created.txt") = False Then
            MkDir(FILE_NAME)
            IO.File.CreateText(FILE_NAME & "\all files created.txt")
        End If
        If IO.File.Exists(Admin & "\all files created.txt") = False Then
            MkDir(Admin)
            IO.File.CreateText(Admin & "\all files created.txt")
        End If
        If IO.File.Exists(Student & "\all files created.txt") = False Then
            MkDir(Student)
            IO.File.CreateText(Student & "\all files created.txt")
        End If
        'teacher folders
        If IO.File.Exists(AKelly & "\all files created.txt") = False Then
            MkDir(AKelly)
            IO.File.CreateText(AKelly & "\all files created.txt")
        End If
        If IO.File.Exists(ACristillo & "\all files created.txt") = False Then
            MkDir(ACristillo)
            IO.File.CreateText(ACristillo & "\all files created.txt")
        End If
    End Sub
#End Region

#Region "Add"
    Private Sub AddStuff(ByVal Name, ByVal Grade, ByVal ID)
        ListBox1.Items.Add(Name)
        ListBox2.Items.Add(Grade)
        ListBox3.Items.Add(ID)
        ListBox4.Items.Add(Name)
        ListBox5.Items.Add(Grade)
        ListBox6.Items.Add(ID)
    End Sub
#End Region

#Region "Remove"
    Private Sub RemoveStuff()
        If ListBox1.SelectedIndex <> -1 And ListBox2.SelectedIndex <> -1 And ListBox3.SelectedIndex <> -1 Then
            oldIndex = ListBox1.SelectedIndex
            If ListBox1.SelectedIndex <> 0 Then
                ListBox1.SelectedIndex = oldIndex - 1
                ListBox2.SelectedIndex = oldIndex - 1
                ListBox3.SelectedIndex = oldIndex - 1
                ListBox4.SelectedIndex = oldIndex - 1
                ListBox5.SelectedIndex = oldIndex - 1
                ListBox6.SelectedIndex = oldIndex - 1
            Else
                ListBox1.SelectedIndex = 0
                ListBox2.SelectedIndex = 0
                ListBox3.SelectedIndex = 0
                ListBox4.SelectedIndex = 0
                ListBox5.SelectedIndex = 0
                ListBox6.SelectedIndex = 0
            End If
            ListBox1.Items.RemoveAt(oldIndex)
            ListBox2.Items.RemoveAt(oldIndex)
            ListBox3.Items.RemoveAt(oldIndex)
            ListBox4.Items.RemoveAt(oldIndex)
            ListBox5.Items.RemoveAt(oldIndex)
            ListBox6.Items.RemoveAt(oldIndex)
        Else
            If ListBox1.SelectedIndex = -1 And ListBox1.Items.Count > 0 Then
                ListBox1.SelectedIndex = 0
                ListBox2.SelectedIndex = 0
                ListBox3.SelectedIndex = 0
                ListBox4.SelectedIndex = 0
                ListBox5.SelectedIndex = 0
                ListBox6.SelectedIndex = 0
                oldIndex = ListBox1.SelectedIndex
                ListBox1.Items.RemoveAt(oldIndex)
                ListBox2.Items.RemoveAt(oldIndex)
                ListBox3.Items.RemoveAt(oldIndex)
                ListBox4.Items.RemoveAt(oldIndex)
                ListBox5.Items.RemoveAt(oldIndex)
                ListBox6.Items.RemoveAt(oldIndex)
            Else
                MessageBox.Show("Nothing left to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
#End Region

#Region "Form Load"
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateFiles()
        AcceptButton = Button1
        TextBox1.Select()
        'If IO.File.Exists(StdName) = True Then
        '    listBoxRead(ListBox1, StdName)
        '    listBoxRead(ListBox2, StdGrade)
        '    listBoxRead(ListBox3, StdID)
        'End If
        ComboBox1.SelectedIndex = 0
        listBoxRead(ListBox4, StdName)
        listBoxRead(ListBox5, StdGrade)
        listBoxRead(ListBox6, StdID)
    End Sub
#End Region

#Region "Makes listboxs the same"
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox2.SelectedIndex = ListBox1.SelectedIndex
        ListBox3.SelectedIndex = ListBox1.SelectedIndex
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox2.SelectedIndex
        ListBox3.SelectedIndex = ListBox2.SelectedIndex
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox3.SelectedIndexChanged
        ListBox2.SelectedIndex = ListBox3.SelectedIndex
        ListBox1.SelectedIndex = ListBox3.SelectedIndex
    End Sub
#End Region

#Region "Add, Remove, Save, Back buttons"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" Then
            AddStuff(TextBox1.Text, TextBox2.Text, TextBox3.Text)
        Else
            MessageBox.Show("You forgot Name, Grade, or ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox1.Select()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RemoveStuff()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Save()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Select()
        Form1.Show()
        Me.Hide()
    End Sub
#End Region

#Region "Selected Teache & Loads Students"
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 0 Then
            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()
            If IO.File.Exists(kellyName) = True Then
                listBoxRead(ListBox1, kellyName)
                listBoxRead(ListBox2, kellyGrade)
                listBoxRead(ListBox3, kellyID)
            End If
        End If
   
        If ComboBox1.SelectedIndex = 1 Then
            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            ListBox3.Items.Clear()
            If IO.File.Exists(cristName) = True Then
                listBoxRead(ListBox1, cristName)
                listBoxRead(ListBox2, cristGrade)
                listBoxRead(ListBox3, cristID)

            End If
        End If

    End Sub
#End Region

End Class