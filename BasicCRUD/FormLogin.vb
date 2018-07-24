Public Class FormLogin
    Dim user As New Users

    Private Sub ButtonLogin_Click(sender As Object, e As EventArgs) Handles ButtonLogin.Click
        user.User = RTrim(Me.TextBoxUser.Text)
        user.Pass = RTrim(Me.TextBoxPass.Text)

        If user.Read() = 1 Then
            LabelValidation.Text = "Success" 'opens new window
            FormGridView.Show()
            Me.Hide()
        ElseIf user.Read() = 2 Then
            LabelValidation.ForeColor = Color.Red
            LabelValidation.Text = "Incorrect username or password"
        Else
            MessageBox.Show("Query Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub
End Class