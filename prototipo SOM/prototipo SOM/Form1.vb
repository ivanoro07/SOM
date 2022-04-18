Public Class Form1
    Dim objUsuario As New Usuario()
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Me.Hide()
        Register.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click


        If (objUsuario.loguear(txtusuario.Text, txtContra.Text) = True) Then
            MsgBox("Inicio de sesion exitoso")
            Me.Hide()
            encuesta.Show()
        Else
            MsgBox("Usuario o contraseña incorrecto")
            txtContra.Text = ""
            txtusuario.Text = ""
        End If
    End Sub


End Class
