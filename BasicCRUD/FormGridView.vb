Public Class FormGridView
    Dim user As New Users
    Dim count As Integer

    Private Sub ButtonHome_Click(sender As Object, e As EventArgs) Handles ButtonHome.Click
        Me.Close()
        FormLogin.Show()
    End Sub

    Private Sub FormGridView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        user.loadDataGrid()

        Me.ButtonUpdate.Enabled = False
        Me.ButtonDelete.Enabled = False
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        If textCheck() = False Then
            Exit Sub
        End If
        user.TId = Me.TextBoxId.Text
        user.TName = Me.TextBoxName.Text
        user.TSurname = Me.TextBoxSurname.Text
        user.TAge = Me.TextBoxAge.Text

        If user.Save() = True Then
            MessageBox.Show("Success", "Save", MessageBoxButtons.OK)
            user.loadDataGrid()
        Else
            MessageBox.Show("Critical Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
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
        If textCheck() = False Then
            Exit Sub
        End If
        user.TId = Me.TextBoxId.Text
        user.TName = Me.TextBoxName.Text
        user.TSurname = Me.TextBoxSurname.Text
        user.TAge = Me.TextBoxAge.Text

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
    End Sub

    Private Sub textClear()
        For Each tb As TextBox In Me.Controls.OfType(Of TextBox)
            tb.Text = vbNullString
        Next
    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        For Each row As DataGridViewRow In Me.DataGridView1.SelectedRows
            TextBoxId.Text = row.Cells(0).Value.ToString
            TextBoxName.Text = row.Cells(1).Value.ToString
            TextBoxSurname.Text = row.Cells(2).Value.ToString
            TextBoxAge.Text = row.Cells(3).Value.ToString
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

End Class