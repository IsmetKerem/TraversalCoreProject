using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers;
[AllowAnonymous]
public class LoginController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    
    public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    // GET
    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult>SignUp(UserRegisterViewModel p)
    {
        AppUser appUser = new AppUser()
        {
            Name = p.Name,
            Surname = p.SurName,
            Email = p.Mail,
            Gender = "Belirtilmemiş",
            ImageUrl = "image.jpg",
            UserName = p.UserName
        };
        if (p.Password == p.ConfirmPassword)
        {
            var result = await _userManager.CreateAsync(appUser, p.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
            }
        }
        return View();
    }
    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(UserSignInViewModel p)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(p.UserName,p.Password,false,false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Profile",new {area = "Member"});
            }
            else
            {
                // Giriş başarısızsa nedenini ModelState'e ekleyelim
                ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre.");
                if (result.IsLockedOut) ModelState.AddModelError("", "Hesabınız kilitlendi.");
                if (result.IsNotAllowed) ModelState.AddModelError("", "Giriş izniniz yok (Email onayı gerekebilir).");
            }
        }
        return View();
    }
}