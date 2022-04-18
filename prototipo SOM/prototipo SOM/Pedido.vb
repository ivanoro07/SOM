Public Class Pedido

    Public pesos(71) As Double
    Public umbrales(7) As Double
    Public Sub levantarPesos()
        Dim MiAr As New System.IO.StreamReader("C:\Users\ivano\Desktop\SOM\Pesos\pesos.txt")
        Dim i As Integer = 0
        Dim j As Integer = 0


        While MiAr.Peek() <> -1
            pesos(i) = MiAr.ReadLine()

            i += 1
            ReDim Preserve pesos(i)
        End While

        MiAr.Close()
        Dim MiAr2 As New System.IO.StreamReader("C:\Users\ivano\Desktop\SOM\Pesos\umbrales.txt")

        While MiAr2.Peek() <> -1
            umbrales(j) = MiAr2.ReadLine()

            j += 1
            ReDim Preserve umbrales(j)
        End While

        MiAr2.Close()

    End Sub
End Class
