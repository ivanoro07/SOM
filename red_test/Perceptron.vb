Public Class Perceptron
    Private W As Double(,,)
    Private U As Double(,)
    Private A As Double(,)
    Private TotalCapas As Integer
    Private neuronasporcapa As Integer()
    Private TotalEntradas As Integer
    Private TotalSalidas As Integer
    Dim i As Integer = 0
    Dim pesos(i) As Double
    Dim j As Integer = 0
    Dim umbrales(j) As Double
    Dim cont1 As Integer = 0
    Dim cont2 As Integer = 0


    Public Sub New(ByVal TotalEntradas As Integer, ByVal TotalSalidas As Integer, ByVal TotalCapas As Integer, ByVal neuronasporcapa As Integer())
        Me.TotalEntradas = TotalEntradas
        Me.TotalSalidas = TotalSalidas
        Me.TotalCapas = TotalCapas
        Dim maxNeuronas As Integer = 0
        Me.neuronasporcapa = New Integer(TotalCapas) {}

        For capa As Integer = 0 To TotalCapas
            Me.neuronasporcapa(capa) = neuronasporcapa(capa)
            If neuronasporcapa(capa) > maxNeuronas Then maxNeuronas = neuronasporcapa(capa) - 1
        Next

        W = New Double(TotalCapas, maxNeuronas, maxNeuronas) {}
        U = New Double(TotalCapas, maxNeuronas) {}
        A = New Double(TotalCapas, maxNeuronas) {}

        LevantarPesos()
        LevantarUmbrales()

        For capa As Integer = 1 To TotalCapas

            For p As Integer = 0 To neuronasporcapa(capa) - 1
                'Console.WriteLine(prueba)
                U(capa, p) = umbrales(cont1)
                cont1 += 1
            Next
        Next

        For capa As Integer = 0 To TotalCapas - 1

            For p As Integer = 0 To neuronasporcapa(capa) - 1

                For k As Integer = 0 To neuronasporcapa(capa + 1) - 1
                    cont2 += 1
                    W(capa, p, k) = pesos(cont2)
                    ' Console.WriteLine(W(capa, p, k))

                Next
            Next
        Next
    End Sub

    Public Sub LevantarPesos()

        Dim MiAr As New System.IO.StreamReader("C:\Users\ivano\Desktop\SOM\Pesos\pesos.txt")

        While MiAr.Peek() <> -1
            pesos(i) = MiAr.ReadLine()
            'Console.WriteLine(pesos(i))
            i += 1
            ReDim Preserve pesos(i)
        End While

        MiAr.Close()
    End Sub

    Public Sub LevantarUmbrales()

        Dim MiAr2 As New System.IO.StreamReader("C:\Users\ivano\Desktop\SOM\Pesos\umbrales.txt")

        While MiAr2.Peek() <> -1
            umbrales(j) = MiAr2.ReadLine()
            'Console.WriteLine(umbrales(j))
            j += 1
            ReDim Preserve umbrales(j)
        End While

        MiAr2.Close()
    End Sub

    Public Sub Procesa(E As Double(), S As Double())
        For copia As Integer = 0 To TotalEntradas - 1
            A(0, copia) = E(copia)
            Console.WriteLine(" A: " + Str(A(0, copia)))

        Next

        For capa As Integer = 1 To TotalCapas

            For neurona As Integer = 0 To neuronasporcapa(capa) - 1
                A(capa, neurona) = 0

                For entra As Integer = 0 To neuronasporcapa(capa - 1) - 1
                    A(capa, neurona) += A(capa - 1, entra) * W(capa - 1, entra, neurona)
                Next
                A(capa, neurona) += U(capa, neurona)
                A(capa, neurona) = 1 / (1 + Math.Exp(-A(capa, neurona)))

                If capa = TotalCapas Then

                    Console.WriteLine("Entrada: " + Str(E(neurona)) + "   | Salida esperada: " + Str(S(neurona)) + " |  Salida real: " + Str(A(capa, neurona)))

                End If


            Next
        Next



    End Sub



    'Public Function Muestra() As Double
    'Dim resultado As Double = A(3, 0)
    '
    'Return resultado
    'End Function

    Public Sub Muestra(E As Double(), S As Double())


        Console.Write("Salida esperada: ")
        For cont As Integer = 0 To TotalSalidas - 1
            Console.Write(S(cont) & "")
        Next

        Console.Write(" <vs> ")
        For cont As Integer = 0 To TotalSalidas - 1

            'If A(TotalCapas, cont) > U(TotalCapas, cont) Then
            'Console.Write("1")
            'Else
            'Console.Write("0")
            'End If
            Console.Write(A(TotalCapas, cont))
        Next

        Console.WriteLine(" ")

    End Sub

End Class