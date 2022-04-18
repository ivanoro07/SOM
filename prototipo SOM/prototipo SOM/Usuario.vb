Public Class Usuario
    Private _Cuenta As String
    Private _Contraseña As String
    Private _Mail As String
    Private _Mail2 As String
    Private _Sexo As Boolean
    Private _FechaNacimiento As Date
    Private _Nombre As String

    Public Property pCuenta As String 'propiedad cuenta
        Get
            Return _Cuenta
        End Get
        Set(value As String)
            _Cuenta = pCuenta
        End Set
    End Property

    Public Property pContraseña As String 'propiedad Contraseña
        Get
            Return _Contraseña
        End Get
        Set(value As String)
            _Contraseña = pContraseña
        End Set
    End Property

    Public Property pMail As String 'propiedad email
        Get
            Return _Mail
        End Get
        Set(value As String)
            _Mail = pMail
        End Set
    End Property
    Public Property pMail2 As String 'propiedad email
        Get
            Return _Mail2
        End Get
        Set(value As String)
            _Mail2 = pMail2
        End Set
    End Property
    Public Property pSexo As String 'propiedad sexo
        Get
            Return _Sexo
        End Get
        Set(value As String)
            _Sexo = pSexo
        End Set
    End Property

    Public Property pfechaNacimiento As String 'propiedad email
        Get
            Return _FechaNacimiento
        End Get
        Set(value As String)
            _FechaNacimiento = pfechaNacimiento
        End Set
    End Property
    Public Property pNombre As String 'propiedad email
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = pNombre
        End Set
    End Property


    Public Function loguear(cuenta As String, contra As String) As Boolean
        If cuenta.Contains("'") Or cuenta.Contains("*") Or cuenta.Contains("{") Or cuenta.Contains("}") Then
            MsgBox("Ingrese un usuario valido")

        Else
            Dim Sql As String
            Dim Conex As New ConectarSQL
            Dim validacion As Integer


            Sql = " call SOM.sp_loguear('" + cuenta + "' , '" + contra + "');"
            Conex.EjecutarSQL(Sql)
            validacion = Conex.Micomando.ExecuteScalar()


            If validacion = 1 Then
                Return True
            Else
                Return False
            End If
            Conex.Dispose()
        End If

    End Function

    Public Function crearCuenta(cuenta As String, contra As String, nombre As String, sexo As Boolean, nacimiento As Date, mail1 As String, mail2 As String) As Boolean
        Dim validacion As Boolean
        Dim valor As Integer
        Dim Sql As String
        Dim Conex As New ConectarSQL
        pCuenta = cuenta
        pContraseña = contra
        pNombre = nombre
        pSexo = sexo
        pfechaNacimiento = nacimiento
        pMail = mail1
        pMail2 = mail2
        nacimiento = nacimiento.ToShortDateString
        If sexo = False Then
            Sql = "call SOM.sp_validar('" + contra + "','" + nombre + "','0','" + cuenta + "','" + Format(nacimiento, "yyyy/MM/dd").ToString + "');"
            Conex.EjecutarSQL(Sql)
            valor = Conex.Micomando.ExecuteScalar()

        Else
            Sql = "call SOM.sp_validar('" + contra + "','" + nombre + "','1','" + cuenta + "','" + Format(nacimiento, "yyyy/MM/dd").ToString + "');"
            Conex.EjecutarSQL(Sql)
            valor = Conex.Micomando.ExecuteScalar()

        End If

        If valor <= 0 Then

            Try

                If mail1.Contains("@") And Register.CheckBox1.Checked = False Then
                    If mail1.Contains("bue.edu.ar") Or mail1.Contains(".com") Then
                        If sexo = False Then

                            Sql = "call SOM.sp_registrar('" + cuenta + "' , '" + contra + "' , '" + nombre + "' , ' " + "0" + "' , '" + Format(nacimiento, "yyyy/MM/dd").ToString + "' , ' " + mail1 + "' , '" + mail2 + " ');"
                            Conex.EjecutarSQL(Sql)
                            Conex.Dispose()
                            validacion = True
                        Else

                            Sql = "call SOM.sp_registrar('" + cuenta + "' , '" + contra + "' , '" + nombre + "' , ' " + "1" + "' , '" + Format(nacimiento, "yyyy/MM/dd").ToString + "' , ' " + mail1 + "' , '" + mail2 + " ');"
                            Conex.EjecutarSQL(Sql)
                            Conex.Dispose()
                            validacion = True
                        End If
                    End If
                Else
                    If mail2.Contains("@") And mail1.Contains("@") And Register.CheckBox1.Checked = True Then
                        If (mail2.Contains(".com") Or mail2.Contains("bue.edu.ar")) And (mail1.Contains(".com") Or mail1.Contains("bue.edu.ar")) Then


                            If pSexo = False Then

                                Sql = "call SOM.sp_registrar('" + cuenta + "' , '" + contra + "' , '" + nombre + "' , ' " + "0" + "' , '" + Format(nacimiento, "yyyy/MM/dd").ToString + "' , ' " + mail1 + "' , '" + mail2 + " ');"
                                Conex.EjecutarSQL(Sql)
                                Conex.Dispose()
                                validacion = True
                            Else

                                Sql = "call SOM.sp_registrar('" + cuenta + "' , '" + contra + "' , '" + nombre + "' , ' " + "1" + "' , '" + Format(nacimiento, "yyyy/MM/dd").ToString + "' , ' " + mail1 + "' , '" + mail2 + " ');"
                                Conex.EjecutarSQL(Sql)
                                Conex.Dispose()
                                validacion = True
                            End If

                        End If
                    Else
                        MsgBox("Ingrese un correo valido")
                    End If

                End If

            Catch ex As Exception
                validacion = False
            End Try
        Else
            MsgBox("Este usuario ya existe")
            validacion = False
        End If
        Return validacion
    End Function


End Class
