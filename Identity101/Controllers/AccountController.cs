using Identity101.Models.Identity;
using Identity101.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity101.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("~/kayit-ol")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost("~/kayit-ol")]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty, "Bir hata oluştu");
            return View(model);
        }

        var user = new ApplicationUser
        {
            UserName = model.UserName,
            Email = model.Email,
            Name = model.Name,
            Surname = model.Surname
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            //TODO: Email gönderme - Aktivasyon
            //TODO: Login olma
            return RedirectToAction("Login");
        }
        var messages = string.Join("\n", result.Errors.Select(e => e.Description));
        ModelState.AddModelError(string.Empty, messages);
        return View(model);

    }

    public IActionResult Login()
    {
        return View();
    }
}
