Imports System.Net
Imports System.Net.Mail

Public Class Resultado

    Public Sub enviarEmail(destino As String, ByVal subject As String, ByVal body As String)
        Dim Email As New MailMessage()

        Try

            'Declaramos nuestro objeto servidor SMTP
            Dim SMTPServer As New SmtpClient

            Email.From = New MailAddress("maildelusuariogmail.com")
            Email.To.Add(New MailAddress(destino))
            Email.Subject = subject
            Email.Body = body

            'Especificamos cual es nuestro servidor SMTP
            SMTPServer.Host = "smtp.gmail.com"
            'Puerto SMTP de nuestro server
            SMTPServer.Port = 587
            'Credenciales de acceso de la cuenta de envio
            SMTPServer.Credentials = New System.Net.NetworkCredential("usuario_correo", "clave_correo")
            'Si nuestro servidor de correo admite SSL
            SMTPServer.EnableSsl = True
            'Enviamos el correo
            SMTPServer.Send(Email)

            'Destruimos el objeto de correo
            Email.Dispose()

            MessageBox.Show("Correo enviado.", "Mail Sender", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Ocurrio un error al enviar el correo: " & ex.Message,
 "Mail Sender", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Sub imprimir()
        PrintDocument1.DocumentName() = "Prediccion"



        Try
            Dim PrintDialog1 As New PrintDialog
            PrintDialog1.Document = PrintDocument1
            PrintDialog1.PrinterSettings.PrinterName = "impresora de salida"
            If PrintDocument1.PrinterSettings.IsValid Then
                PrintDocument1.Print() 'Imprime texto
            Else
                MessageBox.Show("La impresora no es valida")
            End If
            '---------------------------------------------------
        Catch ex As Exception
            MessageBox.Show("Hay un problema de impresión",
            ex.ToString())
        End Try
    End Sub

    Private Sub Resultado_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Environment.Exit(1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim report As New Reporte
        report.destino = 1
        report.mostrarDatos(report.destino)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim report As New Reporte
        report.destino = 2
        report.mostrarDatos(report.destino)

    End Sub

    Private Sub Resultado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If encuesta.valor > 0.1 And encuesta.valor < 0.3 Then
            labelResultado.Text = "Usted tiene covid"
            labelRecomendacion.Text = "Le recomendamos acudir por ayuda medica ante cualquier duda "
        ElseIf encuesta.valor >= 0.3 And encuesta.valor < 0.5 Then
            labelResultado.Text = "Usted tiene alergias"
            labelRecomendacion.Text = "Le recomendamos quedarse en su casa para evitar una visita innecesaria al hospital "
        ElseIf encuesta.valor >= 0.5 And encuesta.valor < 0.7 Then
            labelResultado.Text = "Usted tiene un resfriado"
            labelRecomendacion.Text = "Le recomendamos quedarse en su casa para evitar una visita innecesaria al hospital "
        ElseIf encuesta.valor >= 0.7 And encuesta.valor <= 0.8 Then
            labelResultado.Text = "Usted tiene una gripe"
            labelRecomendacion.Text = "Le recomendamos quedarse en su casa para evitar una visita innecesaria al hospital "
        ElseIf encuesta.valor >= 0.8 And encuesta.valor <= 1 Then
            labelResultado.Text = "Usted tiene Migrañas"
            labelRecomendacion.Text = "Le recomendamos quedarse en su casa para evitar una visita innecesaria al hospital "
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim txtetiqueta1 As String = "Resultados"
        Dim txtetiqueta2 As String = labelResultado.Text
        Dim txtetiqueta3 As String = labelRecomendacion.Text
        e.Graphics.DrawString(txtetiqueta1, New Font("verdana", 11, FontStyle.Bold), New SolidBrush(Color.Black), 1, 9)
        e.Graphics.DrawString(txtetiqueta2, New Font("verdana", 9, FontStyle.Bold), New SolidBrush(Color.Black), 1, 28)
        e.Graphics.DrawString(txtetiqueta3, New Font("verdana", 13, FontStyle.Bold), New SolidBrush(Color.Black), 1, 57)
    End Sub
End Class