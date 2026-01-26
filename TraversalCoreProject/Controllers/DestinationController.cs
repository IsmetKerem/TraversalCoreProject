using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace TraversalCoreProject.Controllers;

[AllowAnonymous]
public class DestinationController : Controller
{
    private readonly IDestinationService _destinationService;
    private readonly UserManager<AppUser> _userManager;
    

    public DestinationController(IDestinationService destinationService, UserManager<AppUser> userManager)
    {
        _destinationService = destinationService;
        _userManager = userManager;
    }
    // GET
    public IActionResult Index()
    {
        var values = _destinationService.TGetList();
        return View(values);
    }
    [HttpGet]

    public IActionResult DestinationDetails(int id)
    {
        ViewBag.id = id;
        ViewBag.destID = id;
        var values = _destinationService.TGetByID(id);
        return View(values);
    }
    [HttpPost]

    public IActionResult DestinationDetails(Destination p)
    {
        return View();
    }
}