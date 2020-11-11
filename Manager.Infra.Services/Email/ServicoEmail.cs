using Manager.Domain.Interfaces.Servicos;
using System;
using System.Net;
using System.Net.Mail;

namespace Manager.Infra.Services.Email
{
    public class ServicoEmail : IServicoEmail
    {
        public void EnviarEmail(string destinatario, string titulo, string corpo)
        {
            string to = "jane@contoso.com";
            string from = "ben@contoso.com";
            string subject = "Using the new SMTP client.";
            string body = @"Using this new feature, you can send an email message from an application very easily.";
            MailMessage message = new MailMessage(from, to, subject, body);
            SmtpClient client = new SmtpClient(server, port);
            // Credentials are necessary if the server requires the client
            // to authenticate before it will send email on the client's behalf.
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            client.Send(message);
        }
    }
}
