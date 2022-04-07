using MVC101.Models;

namespace MVC101.Services.EmailService;

public interface IEmailService
{
    Task SendMailAsync(MailModel model);
}