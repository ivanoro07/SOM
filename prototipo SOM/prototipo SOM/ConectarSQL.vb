Imports MySql.Data.MySqlClient
Public Class ConectarSQL
    Public Miconexion As New MySqlConnection
    Public Micomando As New MySqlCommand
    Public midataadapter As New MySqlDataAdapter
    Public midataset As New DataSet

    Public Sub New()
        Try
            Miconexion.ConnectionString = "Server = localhost;Uid=root;Pwd=et24"
            Miconexion.open()
            Micomando.connection = Miconexion

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Public Sub EjecutarSQL(sentenciaSQL As String)
        Micomando.commandText = sentenciaSQL
        Micomando.executeNonquery()
    End Sub

    Public Sub Dispose()
        Miconexion.Close()
        Miconexion.Dispose()
        Micomando.Dispose()
    End Sub
End Class
