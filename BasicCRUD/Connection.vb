Imports MySql.Data.MySqlClient
Module Connection
    Public conn As MySqlConnection
    Public connString As String
    Public query As String

    Public command As MySqlCommand
    Public reader As MySqlDataReader

    Public Sub openCon()
        Dim DatabaseName As String = "dbtest"
        Dim server As String = "127.0.0.1"
        Dim userName As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"

        Try
            connString = String.Format("server={0};port={1};userid={2};password={3};database={4};SslMode=none", server, port, userName, password, DatabaseName)

            conn = New MySqlConnection(connString)
            conn.Open()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Public Sub closeCon()
        If conn IsNot Nothing Then
            conn.Close()
            conn.Dispose()
        End If

    End Sub
End Module
