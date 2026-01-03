using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers;
[Area("Admin")]
[Route("admin/[controller]/[action]")]
public class UserController : Controller
{
    private readonly IAppUserService _appUserService;
    public UserController(IAppUserService appUserService)
    {
        _appUserService = appUserService;
    }
    // GET
    public IActionResult Index()
    {
        var values = _appUserService.TGetList();
        return View(values);
    }
    [Route("/Admin/User/DeleteUser/{id}")]
    public IActionResult DeleteUser(int id)
    {
        var values = _appUserService.TGetByID(id);
        _appUserService.TDelete(values);
        return RedirectToAction("Index");
    }
[HttpGet]
    public IActionResult EditUser(int id)
    {
        var values = _appUserService.TGetByID(id);
        return View(values);
    }
    [HttpPost]
    public IActionResult EditUser(AppUser appUser)
    {
        _appUserService.TUpdate(appUser);
        return RedirectToAction("Index");
        
    }

    public IActionResult CommentUser()
    {
        _appUserService.TGetList();
        return View();
    }
    public IActionResult ReservationUser()
    {
        _appUserService.TGetList();
        return View();
    }
}