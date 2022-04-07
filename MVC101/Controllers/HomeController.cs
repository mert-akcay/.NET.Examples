using Microsoft.AspNetCore.Mvc;
using MVC101.Models;
using System.Diagnostics;
using MVC101.Services.SmsService;

namespace MVC101.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISmsService _smsService;

        public HomeController(ISmsService smsService)
        {
            _smsService = smsService;
        }

        public IActionResult Index()
        {
            var result = _smsService.Send(new SmsModel()
            {
                TelefonNo = "12345",
                Mesaj = "home/index çalıştı"
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