using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GuauHouse.Helpers
{
    public class MailService
    {
        IConfiguration Configuration;

        public MailService(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void SendEmail(String nombre, String email, String asunto
            , String mensaje)
        {
            MailMessage mail = new MailMessage();
            String usermail = this.Configuration["correogmailprueba"];
            //String usermail = this.Configuration["usumailproyecto"];
            String passwordmail = this.Configuration["passgmailprueba"];
            //String passwordmail = this.Configuration["passmailproyecto"];
            mail.From = new MailAddress(email);
            mail.To.Add(new MailAddress(usermail));
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;
            String smtpserver = this.Configuration["host"];
            int port = int.Parse(this.Configuration["port"]);
            bool ssl = bool.Parse(this.Configuration["ssl"]);
            bool defaultcredentials = bool.Parse(this.Configuration["defaultcredentials"]);
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = smtpserver;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
            smtpClient.UseDefaultCredentials = defaultcredentials;
            NetworkCredential usercredential = new NetworkCredential(email, passwordmail);
            smtpClient.Credentials = usercredential;
            smtpClient.Send(mail);
        }
    }
}
