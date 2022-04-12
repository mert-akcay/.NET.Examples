using Identity101.Models.Email;

namespace Identity101.Services.Email;

public interface IEmailService
{
    Task SendMailAsync(MailModel model);
}
