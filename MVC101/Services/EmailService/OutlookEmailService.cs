using System.Net;
using System.Net.Mail;
using System.Text;
using MVC101.Models;

namespace MVC101.Services.EmailService;

public class OutlookEmailService : IEmailService
{
    public string SenderMail => "wissen.academies@outlook.com";
    public string Password => "123456789123456789abc";
    public string Smtp => "smtp-mail.outlook.com";
    public int SmtpPort => 587;


    public Task SendMailAsync(MailModel model)
    {
        var mail = new MailMessage { From = new MailAddress(this.SenderMail) };

        foreach (var c in model.To)
        {
            mail.To.Add(new MailAddress(c.Adress, c.Name));
        }

        foreach (var cc in model.Cc)
        {
            mail.CC.Add(new MailAddress(cc.Adress, cc.Name));
        }

        foreach (var bcc in model.Bcc)
        {
            mail.Bcc.Add(new MailAddress(bcc.Adress, bcc.Name));
        }

        if (model.Attachs is { Count: > 0 })
        {
            foreach (var modelAttach in model.Attachs)
            {
                var fileStream = modelAttach as FileStream;
                var info = new FileInfo(fileStream.Name);
                mail.Attachments.Add(new Attachment(fileStream,info.Name));
            }
        }


        mail.Subject = model.Subject;
        mail.Body = model.Body;
        mail.IsBodyHtml = true;
        mail.BodyEncoding = Encoding.UTF8;
        mail.SubjectEncoding = Encoding.UTF8;
        mail.HeadersEncoding = Encoding.UTF8;

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        var smtpClient = new SmtpClient(this.Smtp, this.SmtpPort)
        {
            Credentials = new NetworkCredential(userName: this.SenderMail, this.Password),
            EnableSsl = true
        };

        return smtpClient.SendMailAsync(mail);

    }
}