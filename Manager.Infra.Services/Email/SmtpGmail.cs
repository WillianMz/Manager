using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Manager.Infra.Services.Email
{
    public static void SmtpGmail()
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
