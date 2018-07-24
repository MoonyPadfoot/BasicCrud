Imports MySql.Data.MySqlClient
Public Class Users
    Dim adpt As New MySqlDataAdapter
    Dim count As Integer
    'Private userName As String = ""
    'Private passWord As String = "" 'for expanded property functions
    'vars should be LCase
    Public Property User  'property instance login
    Public Property Pass 'functs and props should be UCase

    Public Property TId
    Public Property TName
    Public Property TSurname
    Public Property TAge

    Public Function Read() As Integer
        count = 0
        Try
            openCon()
            'query = "SELECT * FROM dbtest.tabletest WHERE testName = '" & Me.User & "' AND testSurname = '" & Me.Pass & "'"
            'query = String.Format("SELECT * FROM dbtest.tabletest WHERE testName ='{0}' AND  testSurname ='{1}'", Me.User, Me.Pass)
            query = "SELECT * FROM dbtest.tabletest WHERE testName = @0 AND testSurname = @1"
            command = New MySqlCommand(query, conn)
            With command.Parameters
                .AddWithValue("@0", Me.User)
                .AddWithValue("@1", Me.Pass)
            End With
            reader = command.ExecuteReader

            If reader.HasRows Then
                While reader.Read              'for adding new account
                    count += 1
                End While
            End If

            If count >= 1 Then
                Return 1
            Else
                Return 2
            End If

        Catch e As Exception
            Return 3
        Finally
            closeCon()
        End Try

    End Function

    Public Function Save() As Boolean
        Try
            openCon()
            query = "INSERT INTO dbtest.tabletest (idtableTest, testName, testSurname, testAge)"
            query &= " VALUES (@0, @1, @2, @3)"
            command = New MySqlCommand(query, conn)

            With command.Parameters
                .AddWithValue("@0", Me.TId)
                .AddWithValue("@1", Me.TName)
                .AddWithValue("@2", Me.TSurname)
                .AddWithValue("@3", Me.TAge)
            End With
            command.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Delete() As Boolean
        Try
            openCon()
            query = "DELETE FROM dbtest.tabletest WHERE idtableTest = @0"
            command = New MySqlCommand(query, conn)
            command.Parameters.AddWithValue("@0", Me.TId)
            command.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function Update() As Boolean
        Try
            openCon()
            query = "UPDATE dbtest.tabletest SET testName = @1, testSurname = @2, testAge = @3 WHERE idtableTest = @0"
            command = New MySqlCommand(query, conn)

            With command.Parameters
                .AddWithValue("@0", Me.TId)
                .AddWithValue("@1", Me.TName)
                .AddWithValue("@2", Me.TSurname)
                .AddWithValue("@3", Me.TAge)
            End With
            command.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub loadDataGrid()
        Try
            openCon()
            query = "SELECT * FROM dbtest.tableTest"
            Dim adpt As New MySqlDataAdapter(query, conn)
            Dim ds As New DataSet()
            ds.Clear()
            adpt.Fill(ds, "tabletest")
            FormGridView.DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
End Class
