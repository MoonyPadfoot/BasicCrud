Public Class FormGridView
    Dim user As New Users
    Dim count As Integer
    Dim flag As String = ""

    Private Sub ButtonHome_Click(sender As Object, e As EventArgs) Handles ButtonHome.Click
        Me.Close()
        FormLogin.Show()
    End Sub

    Private Sub FormGridView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisableObj()
        user.loadDataGrid()

        Me.ButtonUpdate.Enabled = False
        Me.ButtonDelete.Enabled = False
        Me.ButtonSave.Enabled = False
        Me.ButtonReset.Enabled = False

        With ComboBoxCourse
            .Items.Add("BSIT")
            .Items.Add("BSCS")
        End With

    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        If textCheck() = False Then
            Exit Sub
        End If
        user.TId = Me.TextBoxId.Text
        user.TName = Me.TextBoxName.Text
        user.TSurname = Me.TextBoxSurname.Text
        user.TAge = Me.TextBoxAge.Text
        user.TMName = Me.TextBoxMName.Text
        user.TEName = Me.TextBoxEName.Text
        user.TCourse = Me.ComboBoxCourse.Text

        For Each rb In Me.Controls.OfType(Of RadioButton)
            If rb.Checked Then user.TGender = rb.Text
        Next
        If flag = "Add" Then

            If user.Save() = True Then
                MessageBox.Show("Success", "Save", MessageBoxButtons.OK)
                user.loadDataGrid()
            Else
                MessageBox.Show("Critical Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

        ElseIf flag = "Update" Then

            Dim answer As DialogResult = MessageBox.Show("Do You Wish To Update?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If answer = vbYes Then
                If user.Update() = True Then
                    MessageBox.Show("Success", "Update", MessageBoxButtons.OK)
                    user.loadDataGrid()
                    textClear()
                Else
                    MessageBox.Show("Critical Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End If
        End If

    End Sub
    Private Sub ButtonDelete_Click(sender As Object, e As EventArgs) Handles ButtonDelete.Click
        If textCheck() = False Then
            Exit Sub
        End If
        Dim answer As DialogResult = MessageBox.Show("Do You Wish To Continue?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If answer = vbYes Then
            user.TId = Me.TextBoxId.Text

            If user.Delete() = True Then
                MessageBox.Show("Success", "Delete", MessageBoxButtons.OK)
                user.loadDataGrid()
                textClear()
            Else
                MessageBox.Show("Critical Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub ButtonUpdate_Click(sender As Object, e As EventArgs) Handles ButtonUpdate.Click
        flag = "Update"
        EnableObj()
        Me.ButtonSave.Enabled = True
    End Sub

    Private Sub textClear()
        For Each tb As TextBox In Me.Controls.OfType(Of TextBox)
            tb.Text = vbNullString
        Next
        For Each tb As Control In Me.GroupBox1.Controls
            If TypeOf tb Is TextBox Then
                tb.Text = vbNullString
            End If
        Next
        Me.RadioButtonM.Checked = False
        Me.RadioButtonF.Checked = False
        Me.ComboBoxCourse.Text = vbNullString
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged

        For Each row As DataGridViewRow In Me.DataGridView1.SelectedRows
            Me.TextBoxId.Text = row.Cells(0).Value.ToString
            Me.TextBoxName.Text = row.Cells(1).Value.ToString
            Me.TextBoxSurname.Text = row.Cells(2).Value.ToString
            Me.TextBoxAge.Text = row.Cells(3).Value.ToString
            Me.ComboBoxCourse.Text = row.Cells(4).Value.ToString
            For Each rb As RadioButton In Me.Controls.OfType(Of RadioButton)
                If rb.Text = row.Cells(5).Value.ToString Then
                    rb.Checked = True
                End If
            Next
            Me.TextBoxMName.Text = row.Cells(6).Value.ToString
            Me.TextBoxEName.Text = row.Cells(7).Value.ToString
        Next
        Me.ButtonDelete.Enabled = True
        Me.ButtonUpdate.Enabled = True
    End Sub

    Private Function textCheck() As Boolean
        count = 0
        For Each tb As TextBox In Me.Controls.OfType(Of TextBox)
            If tb.Text = vbNullString Then
                count += 1
            End If
        Next

        If count <> 0 Then
            MessageBox.Show("Please Input Required Parameters..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click
        textClear()
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click
        flag = "Add"
        EnableObj()
        Me.ButtonSave.Enabled = True
    End Sub

    Private Sub DisableObj()
        For Each tb As TextBox In Me.Controls.OfType(Of TextBox)
            tb.Enabled = False
        Next
        For Each tb As Control In Me.GroupBox1.Controls
            If TypeOf tb Is TextBox Then
                tb.Enabled = False
            End If
        Next
        Me.RadioButtonM.Enabled = False
        Me.RadioButtonF.Enabled = False
        Me.ComboBoxCourse.Enabled = False
    End Sub
    Private Sub EnableObj()
        For Each tb As TextBox In Me.Controls.OfType(Of TextBox)
            tb.Enabled = True
        Next
        For Each tb As Control In Me.GroupBox1.Controls
            If TypeOf tb Is TextBox Then
                tb.Enabled = True
            End If
        Next
        Me.RadioButtonM.Enabled = True
        Me.RadioButtonF.Enabled = True
        Me.ComboBoxCourse.Enabled = True
    End Sub
End Class