using Identity101.Models.Configuration;
using Identity101.Models.Email;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Identity101.Services.Email;


public class OutlookEmailService : IEmailService
{
    private readonly IConfiguration _config;
    public EmailSettings EmailSettings { get; }

    public OutlookEmailService(IConfiguration config)
    {
        _config = config;
        this.EmailSettings = _config.GetSection("OutlookSettings").Get<EmailSettings>();
        
    }

    


    public Task SendMailAsync(MailModel model)
    {
        var mail = new MailMessage { From = new MailAddress(this.EmailSettings.SenderMail) };

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
                mail.Attachments.Add(new Attachment(fileStream, info.Name));
            }
        }


        mail.Subject = model.Subject;
        mail.Body = model.Body;
        mail.IsBodyHtml = true;
        mail.BodyEncoding = Encoding.UTF8;
        mail.SubjectEncoding = Encoding.UTF8;
        mail.HeadersEncoding = Encoding.UTF8;

        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        var smtpClient = new SmtpClient(this.EmailSettings.Smtp, this.EmailSettings.SmtpPort)
        {
            Credentials = new NetworkCredential(userName: this.EmailSettings.SenderMail, this.EmailSettings.Password),
            EnableSsl = true
        };

        return smtpClient.SendMailAsync(mail);

    }
}
