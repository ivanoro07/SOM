Public Class Reporte
    Public destino As Integer

    Public Sub mostrarDatos(destino As Integer)
        Me.destino = destino
        If destino = 1 Then
            Dim correo As String = "maildelusuario@hotmail.com"
            Dim asunto As String = "Resultados SOM"
            Dim mensaje As String = "Mensaje con el resultado"
            Resultado.enviarEmail(correo, asunto, mensaje)
        Else
            Resultado.imprimir()
        End If



    End Sub
End Class
