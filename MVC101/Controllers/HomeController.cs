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
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IServiceProvider _serviceProvider;

        public HomeController(ISmsService smsService, IEmailService emailService, IWebHostEnvironment appEnvironment, IServiceProvider serviceProvider)
        {
            _smsService = smsService;
            _emailService = emailService;
            _appEnvironment = appEnvironment;
            _serviceProvider = serviceProvider;
        }

        public IServiceProvider Get_serviceProvider()
        {
            return _serviceProvider;
        }

        public IActionResult Index(IServiceProvider _serviceProvider, int id = 0)
        {
            var result = _smsService.Send(new SmsModel()
            {
                TelefonNo = "12345",
                Mesaj = "home/index çalıştı"
            });

            var fileStream = new FileStream($"{_appEnvironment.WebRootPath}\\files\\aa.zip", FileMode.Open);



            #region Factory Design Pattern

            IEmailService emailService;
            if (id %2 == 0)
            {
                emailService = _serviceProvider.GetService<SendGridEmailService>();
            }
            else
            {
                emailService = _serviceProvider.GetService<OutlookEmailService>();
            }

            #endregion


            emailService.SendMailAsync(new MailModel()
            {
                To = new List<EmailModel>()
                {
                    new EmailModel()
                    {
                        Name ="Wissen",
                        Adress = "akcaymert603@gmail.com"
                    }
                },
                Subject = "Logged in....",
                Body = "🚀 Successful login 🚀 ",
                Attachs = new List<Stream>()
                {
                    fileStream
                }
            });

            fileStream.Close();

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