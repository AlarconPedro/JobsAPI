using System.Net.Mail;
using System.Net;
using Hangfire;

namespace ApiJob.Servicos;

public class EnviarEmails
{
    public async Task<string> enviaEmail(string body, string tipoTexto)
    {
        string codigoJob = "";
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("financeiro@omegasistemas.com.br");
        mail.Subject = "Verificação de Devedores";
        //mail.Body = "Verificação de Devedores utilizando HangFire !";
        mail.Body = body;
        mail.To.Add("pedrohenriquealarcon@gmail.com");
        mail.To.Add("marcos@omegasistemas.com.br");
        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
        {
            smtp.Credentials = new NetworkCredential("financeiro@omegasistemas.com.br", "EBENEZER");
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            //smtp.Send(mail);
            //smtp.UseDefaultCredentials = false;
            codigoJob = BackgroundJob.Enqueue(() => smtp.Send(mail));
        }
        return $"Job ID: {codigoJob}";
    }
}
