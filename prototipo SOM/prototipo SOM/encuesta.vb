Public Class encuesta
    Public valor As Double
    Dim objSom As New SOM
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If MsgBox("Continuar?", vbYesNo) = 6 Then



            Dim contador As Integer = 10
            Dim respuestas(contador) As Boolean
            respuestas(0) = rbDolorC1.Checked
            respuestas(1) = rbTos1.Checked
            respuestas(2) = rbEstornudos1.Checked
            respuestas(3) = rbDolorM1.Checked
            respuestas(4) = rbCansancio1.Checked
            respuestas(5) = rbDolorG1.Checked
            respuestas(6) = rbCongestion1.Checked
            respuestas(7) = rbFiebre1.Checked
            respuestas(8) = rbNauseas1.Checked
            respuestas(9) = rbDiarrea1.Checked
            respuestas(10) = rbGYO1.Checked


            objSom.pedirDatos(respuestas(0), respuestas(1), respuestas(2), respuestas(3), respuestas(4), respuestas(5), respuestas(6), respuestas(7), respuestas(8), respuestas(9), respuestas(10), Form1.txtusuario.Text)
            valor = objSom.predecir(Form1.txtusuario.Text)

            Me.Hide()
            Resultado.Show()
        Else
            Me.Hide()
            Form1.Show()
        End If

    End Sub

    Private Sub encuesta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        objSom.levantarIndicadores()


    End Sub

    Private Sub rbGYO2_CheckedChanged(sender As Object, e As EventArgs) Handles rbGYO2.CheckedChanged
        If rbCansancio1.Checked = True Or rbCansancio2.Checked = True And rbDiarrea1.Checked = True Or rbDiarrea2.Checked = True Then
            Button1.Enabled = True
        End If
    End Sub

    Private Sub rbGYO1_CheckedChanged(sender As Object, e As EventArgs) Handles rbGYO1.CheckedChanged
        If rbCansancio1.Checked = True Or rbCansancio2.Checked = True And rbDiarrea1.Checked = True Or rbDiarrea2.Checked = True Then
            Button1.Enabled = True
        End If
    End Sub

    Private Sub encuesta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Environment.Exit(1)
    End Sub

    Private Sub rbDolorC1_CheckedChanged(sender As Object, e As EventArgs) Handles rbDolorC1.CheckedChanged
        Panel2.Visible = True
    End Sub

    Private Sub rbDolorC2_CheckedChanged(sender As Object, e As EventArgs) Handles rbDolorC2.CheckedChanged
        Panel2.Visible = true
    End Sub

    Private Sub rbTos1_CheckedChanged(sender As Object, e As EventArgs) Handles rbTos1.CheckedChanged
        Panel3.Visible = True
    End Sub

    Private Sub rbTos2_CheckedChanged(sender As Object, e As EventArgs) Handles rbTos2.CheckedChanged
        Panel3.Visible = True
    End Sub

    Private Sub rbEstornudos1_CheckedChanged(sender As Object, e As EventArgs) Handles rbEstornudos1.CheckedChanged
        Panel5.Visible = True
    End Sub

    Private Sub tbEstornudos2_CheckedChanged(sender As Object, e As EventArgs) Handles tbEstornudos2.CheckedChanged
        Panel5.Visible = True
    End Sub

    Private Sub rbDolorM1_CheckedChanged(sender As Object, e As EventArgs) Handles rbDolorM1.CheckedChanged
        Panel7.Visible = True
    End Sub

    Private Sub rbDolorM2_CheckedChanged(sender As Object, e As EventArgs) Handles rbDolorM2.CheckedChanged
        Panel7.Visible = True
    End Sub

    Private Sub rbCansancio1_CheckedChanged(sender As Object, e As EventArgs) Handles rbCansancio1.CheckedChanged
        Panel10.Visible = True
    End Sub

    Private Sub rbCansancio2_CheckedChanged(sender As Object, e As EventArgs) Handles rbCansancio2.CheckedChanged
        Panel10.Visible = True
    End Sub

    Private Sub rbDolorG1_CheckedChanged(sender As Object, e As EventArgs) Handles rbDolorG1.CheckedChanged
        Panel4.Visible = True
    End Sub

    Private Sub rbDolorG2_CheckedChanged(sender As Object, e As EventArgs) Handles rbDolorG2.CheckedChanged
        Panel4.Visible = True
    End Sub

    Private Sub rbCongestion1_CheckedChanged(sender As Object, e As EventArgs) Handles rbCongestion1.CheckedChanged
        Panel8.Visible = True
    End Sub

    Private Sub rbCongestion2_CheckedChanged(sender As Object, e As EventArgs) Handles rbCongestion2.CheckedChanged
        Panel8.Visible = True
    End Sub

    Private Sub rbFiebre1_CheckedChanged(sender As Object, e As EventArgs) Handles rbFiebre1.CheckedChanged
        Panel11.Visible = True
    End Sub

    Private Sub rbFiebre2_CheckedChanged(sender As Object, e As EventArgs) Handles rbFiebre2.CheckedChanged
        Panel11.Visible = True
    End Sub

    Private Sub rbNauseas1_CheckedChanged(sender As Object, e As EventArgs) Handles rbNauseas1.CheckedChanged
        Panel6.Visible = True
    End Sub

    Private Sub rbNauseas2_CheckedChanged(sender As Object, e As EventArgs) Handles rbNauseas2.CheckedChanged
        Panel6.Visible = True
    End Sub

    Private Sub rbDiarrea1_CheckedChanged(sender As Object, e As EventArgs) Handles rbDiarrea1.CheckedChanged
        Panel9.Visible = True
    End Sub

    Private Sub rbDiarrea2_CheckedChanged(sender As Object, e As EventArgs) Handles rbDiarrea2.CheckedChanged
        Panel9.Visible = True
    End Sub

End Class