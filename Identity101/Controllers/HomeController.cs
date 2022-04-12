using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity101.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
