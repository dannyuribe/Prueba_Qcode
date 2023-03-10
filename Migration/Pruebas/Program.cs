using System.Net;
using System.Net.Mail;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Inicio Programa para enviar Correos");

        SmtpClient cliente = new("smtp.gmail.com",587);
        cliente.UseDefaultCredentials = false;
        cliente.EnableSsl = true;
        cliente.Credentials = new NetworkCredential("dannyuribe.fullstack@gmail.com", "ivescdnpuoevsedc");
        //pass smtp: ivescdnpuoevsedc
        //pass correo: Desarrollo.2023
        // Configurar el correo electrónico
        MailMessage message = new();
        message.From = new MailAddress("dannyuribe.fullstack@gmail.com");
        message.To.Add("danny.uribeh@gmail.com");
        message.Subject = "Código de verificación";
        message.Body = "Su código de verificación es: " + "NYa";

        // Enviar el correo electrónico
        cliente.Send(message);
    }
}