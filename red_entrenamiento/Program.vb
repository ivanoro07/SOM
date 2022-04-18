Imports System

Module Program

    Sub Main(args As String())

        Dim contagod As Integer = 0

        Dim TotalEntradas As Integer = 12
        Dim TotalSalidas As Integer = 1
        Dim TotalCapas As Integer = 3 'cantidad de capas-1
        Dim neuronasporcapa As Integer() = New Integer(TotalCapas) {}
        neuronasporcapa(0) = TotalEntradas
        neuronasporcapa(1) = 5
        neuronasporcapa(2) = 2
        neuronasporcapa(3) = TotalSalidas

        Dim objP As Perceptron = New Perceptron(TotalEntradas, TotalSalidas, TotalCapas, neuronasporcapa)
        Dim MaximosRegistros As Integer = 1 'total registros -2
        Dim entrada As Double()() = New Double(MaximosRegistros)() {}
        Dim salidas As Double()() = New Double(MaximosRegistros)() {}
        Const urlArchivo As String = "C:\Users\ivano\Desktop\SOM\Set entrenamiento\310122.csv"
        Dim ConjuntoEntradas As Integer = LeeDatosArchivo(urlArchivo, entrada, salidas)

        Dim alpha As Double = 0.3
        Dim salidaReal As Double = objP.Procesa(entrada(contagod), salidas(contagod))
        Dim salida1 As Double = 0.1
        Dim salida2 As Double = 0.3
        Dim salida3 As Double = 0.5
        Dim salida4 As Double = 0.7
        Dim salida5 As Double = 0.9
        For epoca As Integer = 0 To ConjuntoEntradas - 1

            If epoca Mod 10 = 0 Then Console.WriteLine("Iteracion: " & epoca)

            Console.WriteLine("epoca:" + Str(epoca))
            Dim salidaesp As Double
            salidaesp = salidas(contagod)(0)
            objP.Procesa(entrada(contagod), salidas(contagod))


            If salidaesp = salida1 Then

                While salidaReal > 0.2
                    salidaReal = objP.Procesa(entrada(contagod), salidas(contagod))
                    objP.Entrena(alpha, entrada(contagod), salidas(contagod))

                End While
            ElseIf salidaesp = salida2 Then

                While salidaReal > 0.4 Or salidaReal < 0.3
                    salidaReal = objP.Procesa(entrada(contagod), salidas(contagod))
                    objP.Entrena(alpha, entrada(contagod), salidas(contagod))
                End While
            ElseIf salidaesp = salida3 Then
                While salidaReal > 0.6 Or salidaReal < 0.49
                    salidaReal = objP.Procesa(entrada(contagod), salidas(contagod))
                    objP.Entrena(alpha, entrada(contagod), salidas(contagod))

                End While
            ElseIf salidaesp = salida4 Then
                While salidaReal > 0.7 Or salidaReal < 0.65
                    salidaReal = objP.Procesa(entrada(contagod), salidas(contagod))
                    objP.Entrena(alpha, entrada(contagod), salidas(contagod))

                End While
            Else
                While salidaReal < 0.85
                    salidaReal = objP.Procesa(entrada(contagod), salidas(contagod))
                    objP.Entrena(alpha, entrada(contagod), salidas(contagod))

                End While
            End If


            contagod += 1


        Next

        Dim MiAr As New System.IO.StreamWriter("C:\Users\ivano\Desktop\SOM\Pesos\pesos.txt") 'ARCHIVO DE PESOS
        Dim ArUmbral As New System.IO.StreamWriter("C:\Users\ivano\Desktop\SOM\Pesos\umbrales.txt") 'ARCHIVO DE UMBRALES


        For capa As Integer = 0 To TotalCapas - 1
            Console.WriteLine("-------------CAPA" + Str(capa + 1) + "->" + Str(capa + 2) + "-------------")
            Console.WriteLine("")
            For inicial As Integer = 0 To neuronasporcapa(0) - 1

                For final As Integer = 0 To neuronasporcapa(1) - 1
                    If (objP.Muestra(capa, inicial, final)) <> 0 Then

                        Console.WriteLine("Peso N[" + Str(inicial + 1) + " ] -> N[" + Str(final + 1) + " ]: " + Str(objP.Muestra(capa, inicial, final)))

                        MiAr.WriteLine(objP.Muestra(capa, inicial, final))

                        Console.WriteLine("")

                    End If
                Next

                If (objP.MuestraUmbral(capa, inicial)) <> 0 Then

                    Console.WriteLine("Umbral de neurona " + Str(inicial + 1) + ": " + Str(objP.MuestraUmbral(capa, inicial)))

                    ArUmbral.WriteLine(objP.MuestraUmbral(capa, inicial))

                    Console.WriteLine("")

                End If

            Next

        Next
        Console.WriteLine("-------------SALIDA-------------")
        Console.WriteLine("Umbral de salida: " + Str(objP.MuestraUmbral(3, 0)))
        ArUmbral.WriteLine(objP.MuestraUmbral(3, 0))
        MiAr.Close()
        ArUmbral.Close()
        Console.ReadKey()
    End Sub
    Private Function LeeDatosArchivo(urlArchivo As String, entrada()() As Double, salida()() As Double) As Integer
        Dim archivo = New System.IO.StreamReader(urlArchivo)
        archivo.ReadLine() REM La línea de título de cada columna de datos
        Dim leelinea As String = ""
        Dim limValores As Integer = 0

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

            Dim valSalida As Double = TraerNumeroCadena(leelinea, ",", 13)

            entrada(limValores) = New Double() {valEntrada1, valEntrada2, valEntrada3, valEntrada4, valEntrada5, valEntrada6, valEntrada7, valEntrada8, valEntrada9, valEntrada10, valEntrada11, valEntrada12}
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