﻿using Manager.Domain.Interfaces.Servicos;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Manager.Infra.Services.Email
{
    public class ServicoEmail : IServicoEmail
    {
        public void EnviaEmail(string remetente, string destinatario, string titulo, string corpo)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(remetente, "Manager Tickets");
            email.To.Add(new MailAddress(destinatario));
            //cópia oculta
            email.CC.Add(new MailAddress("xxxxxx@outlook.com.br"));

            email.Subject = titulo;
            email.Body = corpo;
            email.IsBodyHtml = false;

            //teste de anexo
            //MemoryStream ms = new MemoryStream(anexo.file)

            try
            {
                using (var smtp = new SmtpClient())
                {
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("xxxxxxxx@hotmail.com", "xxxxxxxxxx");

                    smtp.Send(email);

                }
            }
            catch
            {
            }
        }

    }
}
