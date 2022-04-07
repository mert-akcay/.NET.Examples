using Microsoft.AspNetCore.Mvc;
using MVC101.Models;
using System.Diagnostics;
using MVC101.Services.EmailService;
using MVC101.Services.SmsService;

namespace MVC101.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISmsService _smsService;
        private readonly IEmailService _emailService;

        public HomeController(ISmsService smsService, IEmailService emailService)
        {
            _smsService = smsService;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            var result = _smsService.Send(new SmsModel()
            {
                TelefonNo = "12345",
                Mesaj = "home/index çalıştı"
            });
            _emailService.SendMailAsync(new MailModel()
            {
                To = new List<EmailModel>()
                {
                    new EmailModel()
                    {
                        Name ="Wissen",
                        Adress = "akcaymert603@gmail.com"
                    },
                    new EmailModel()
                    {
                        Name ="Serkan",
                        Adress = "srknozsoz@gmail.com"
                    }
                },
                Subject = "Ah be Serkanım be ahh....",
                Body = ":rocket: Just for you :rocket: "
            });

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}