Public Class Register
    Dim objUsuario As New Usuario()
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Hide()
        Form1.Show()
    End Sub
    Public Sub registro()
        Dim cuenta As String = Strings.Left(txtNombre.Text, 4) + Strings.Left(txtMail1.Text, 4)

        If rb1.Checked Then

            If objUsuario.crearCuenta(cuenta, txtContraseña.Text, txtNombre.Text, True, dtp1.Value, txtMail1.Text, txtMail2.Text) = True Then
                MsgBox("Usuario registrado con exito, su cuenta es: " + cuenta)
                Me.Hide()
                Form1.Show()
            Else
                MsgBox("Error al crear la cuenta")
            End If

        Else
            If objUsuario.crearCuenta(cuenta, txtContraseña.Text, txtNombre.Text, False, dtp1.Value, txtMail1.Text, txtMail2.Text) = True Then
                MsgBox("Usuario registrado con exito, su cuenta es: " + cuenta + " La cuenta es necesaria para el inicio de sesión por lo que deberá recordarla")
                Me.Hide()
                Form1.Show()
            Else
                MsgBox("Error al crear la cuenta")

            End If
        End If

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        registro()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtMail2.Enabled = True
        Else
            txtMail2.Enabled = False
        End If
    End Sub

    Private Sub Register_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Environment.Exit(1)
    End Sub


End Class