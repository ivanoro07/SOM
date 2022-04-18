Imports System

Module Program

    Sub Main(args As String())

        Dim TotalEntradas As Integer = 14
        Dim TotalSalidas As Integer = 1
        Dim TotalCapas As Integer = 3
        Dim neuronasporcapa As Integer() = New Integer(TotalCapas) {}
        neuronasporcapa(0) = TotalEntradas
        neuronasporcapa(1) = 5
        neuronasporcapa(2) = 2
        neuronasporcapa(3) = TotalSalidas
        Dim objP As Perceptron = New Perceptron(TotalEntradas, TotalSalidas, TotalCapas, neuronasporcapa)
        Dim MaximosRegistros As Integer = 3 'total registros -2
        Dim entrada As Double()() = New Double(MaximosRegistros)() {}
        Dim salidas As Double()() = New Double(MaximosRegistros)() {}
        Const urlArchivo As String = "C:\Users\ivano\Desktop\red_test\test.csv"
        Dim ConjuntoEntradas As Integer = LeeDatosArchivo(urlArchivo, entrada, salidas)


        For entra As Integer = 0 To ConjuntoEntradas - 1
            objP.Procesa(entrada(entra), salidas(entra))
            ' objP.Muestra(entrada(entra), salidas(entra))
        Next


        Console.ReadKey()
    End Sub
    Private Function LeeDatosArchivo(urlArchivo As String, entrada()() As Double, salida()() As Double) As Integer
        Dim archivo = New System.IO.StreamReader(urlArchivo)
        archivo.ReadLine() REM La línea de título de cada columna de datos
        Dim leelinea As String = ""
        Dim limValores As Integer = 0
        Dim prueba As Double
        Dim prueba2 As Double

        While archivo.Peek() <> -1
            leelinea = archivo.ReadLine()

            Dim valEntrada1 As Double = TraerNumeroCadena(leelinea, ",", 1)
            Dim valEntrada2 As Double = TraerNumeroCadena(leelinea, ",", 2)
            Dim valEntrada3 As Double = TraerNumeroCadena(leelinea, ",", 3)
            Dim valEntrada4 As Double = TraerNumeroCadena(leelinea, ",", 4)
            Dim valEntrada5 As Double = TraerNumeroCadena(leelinea, ",", 5)
            Dim valEntrada6 As Double = TraerNumeroCadena(leelinea, ",", 6)
            Dim valEntrada7 As Double = TraerNumeroCadena(leelinea, ",", 7)
            Dim valEntrada8 As Double = TraerNumeroCadena(leelinea, ",", 8)
            Dim valEntrada9 As Double = TraerNumeroCadena(leelinea, ",", 9)
            Dim valEntrada10 As Double = TraerNumeroCadena(leelinea, ",", 10)
            Dim valEntrada11 As Double = TraerNumeroCadena(leelinea, ",", 11)
            Dim valEntrada12 As Double = TraerNumeroCadena(leelinea, ",", 12)
            Dim valEntrada13 As Double = TraerNumeroCadena(leelinea, ",", 13)
            Dim valEntrada14 As Double = TraerNumeroCadena(leelinea, ",", 14)
            Dim valSalida As Double = TraerNumeroCadena(leelinea, ",", 15)

            entrada(limValores) = New Double() {valEntrada1, valEntrada2, valEntrada3, valEntrada4, valEntrada5, valEntrada6, valEntrada7, valEntrada8, valEntrada9, valEntrada10, valEntrada11, valEntrada12, valEntrada13, valEntrada14}
            salida(limValores) = New Double() {valSalida}

            limValores += 1
        End While
        archivo.Close()
        Return limValores
    End Function

    Private Function TraerNumeroCadena(linea As String, delimitador As Char, numeroToken As Integer) As Double
        Dim numero As String = ""
        Dim numTrae As Integer = 0

        For Each t As Char In linea
            If t <> delimitador Then
                numero = numero & t
            Else
                numTrae = numTrae + 1
                If numTrae = numeroToken Then
                    numero = numero.Trim()
                    If numero = "" Then Return 0
                    Return Val(numero)
                End If
                numero = ""
            End If
        Next
        numero = numero.Trim()
        If numero = "" Then Return 0
        Return Val(numero)


    End Function
End Module