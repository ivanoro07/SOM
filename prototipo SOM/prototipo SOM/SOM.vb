Public Class SOM

    Public fiebre As Boolean
    Public gyo As Boolean
    Public diarrea As Boolean
    Public tos As Boolean
    Public dCabeza As Boolean
    Public estornudos As Boolean
    Public dMuscular As Boolean
    Public cansancio As Boolean
    Public nCongestionada As Boolean
    Public nauseas As Boolean
    Public dGarganta As Boolean
    Public sexo As Boolean



    Public objPedido As New Pedido
    Public Sub pedirDatos(respcabez As Boolean, resptos As Boolean, respestornudos As Boolean, respuestamuscular As Boolean, respuestacansancio As Boolean, respuestagarganta As Boolean, respuestacongestion As Boolean, respuestafiebre As Boolean, respnauseas As Boolean, respDiarrea As Boolean, respGYO As Boolean, usuario As String)

        Dim Sql As String
        Dim Conex As New ConectarSQL
        Dim vsexo As Boolean

        fiebre = respuestafiebre
        gyo = respGYO
        diarrea = respDiarrea
        tos = resptos
        dCabeza = respcabez
        estornudos = respestornudos
        dMuscular = respuestamuscular
        cansancio = respuestacansancio
        nCongestionada = respuestacongestion
        nauseas = respnauseas
        dGarganta = respuestagarganta
        Sql = " call SOM.sp_traerSexo('" + usuario + "');"
        Conex.EjecutarSQL(Sql)
        vsexo = Conex.Micomando.ExecuteScalar()
        Conex.Dispose()
        sexo = vsexo

        objPedido.levantarPesos()
    End Sub

    Public Function predecir(usuario As String) As Double
        Dim W As Double(,,)
        Dim U As Double(,)
        Dim A As Double(,)
        Dim i As Integer = 0
        Dim j As Integer = 0

        Dim cont1 As Integer = 0
        Dim cont2 As Integer = 0
        Dim resultado As Double
        Dim TotalEntradas As Integer = 12
        Dim TotalSalidas As Integer = 1
        Dim TotalCapas As Integer = 3
        Dim neuronasporcapa As Integer() = New Integer(TotalCapas) {}
        neuronasporcapa(0) = TotalEntradas
        neuronasporcapa(1) = 5
        neuronasporcapa(2) = 2
        neuronasporcapa(3) = TotalSalidas
        Dim maximoregistros As Integer = 0


        Dim entrada As Double()() = New Double(maximoregistros)() {}
        entrada(0) = New Double() {Convert.ToDouble(sexo), Convert.ToDouble(dCabeza), Convert.ToDouble(tos), Convert.ToDouble(estornudos), Convert.ToDouble(dMuscular), Convert.ToDouble(cansancio), Convert.ToDouble(dGarganta), Convert.ToDouble(nCongestionada), Convert.ToDouble(fiebre), Convert.ToDouble(nauseas), Convert.ToDouble(diarrea), Convert.ToDouble(gyo)}

        W = New Double(TotalCapas, 14, 14) {}
        U = New Double(TotalCapas, 14) {}
        A = New Double(TotalCapas, 14) {}

        For capa As Integer = 1 To TotalCapas

            For p As Integer = 0 To neuronasporcapa(capa) - 1
                U(capa, p) = objPedido.umbrales(cont1)
                cont1 += 1
            Next
        Next
        For capa As Integer = 0 To TotalCapas - 1

            For p As Integer = 0 To neuronasporcapa(capa) - 1
                For k As Integer = 0 To neuronasporcapa(capa + 1) - 1
                    W(capa, p, k) = objPedido.pesos(cont2)
                    cont2 += 1
                Next
            Next
        Next
        For copia As Integer = 0 To TotalEntradas - 1
            A(0, copia) = entrada(0)(copia)
        Next

        For capa As Integer = 1 To TotalCapas

            For neurona As Integer = 0 To neuronasporcapa(capa) - 1
                A(capa, neurona) = 0

                For entra As Integer = 0 To neuronasporcapa(capa - 1) - 1
                    A(capa, neurona) += A(capa - 1, entra) * W(capa - 1, entra, neurona) + 1 * U(capa, neurona)
                Next

                A(capa, neurona) = 1 / (1 + Math.Exp(-A(capa, neurona)))

                If capa = TotalCapas Then

                    resultado = A(capa, neurona)

                End If

            Next
        Next

        Dim conex As New ConectarSQL
        Dim sql As String

        sql = "call SOM.sp_GuardarAnalisis('" + Str(resultado) + "','" + usuario + "','" + Str(Convert.ToInt64(sexo)) + "','" + Str(Convert.ToInt64(dCabeza)) + "','" + Str(Convert.ToInt64(tos)) + "','" + Str(Convert.ToInt64(estornudos)) + "','" + Str(Convert.ToInt64(dMuscular)) + "','" + Str(Convert.ToInt64(cansancio)) + "','" + Str(Convert.ToInt64(dGarganta)) + "','" + Str(Convert.ToInt64(nCongestionada)) + "','" + Str(Convert.ToInt64(fiebre)) + "','" + Str(Convert.ToInt64(nauseas)) + "','" + Str(Convert.ToInt64(diarrea)) + "','" + Str(Convert.ToInt64(gyo)) + "');"
        conex.EjecutarSQL(sql)
        conex.Dispose()

        Return resultado
    End Function
    Public Function levantarIndicadores() As String
        Dim conex As New ConectarSQL
        Dim sql As String
        Dim indicadores As String
        sql = " call SOM.sp_traerIndicadores();"
        conex.EjecutarSQL(sql)
        indicadores = conex.Micomando.ExecuteScalar()
        conex.Dispose()
      
        Return indicadores
    End Function

End Class
