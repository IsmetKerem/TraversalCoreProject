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

    public async Task<IActionResult> DestinationDetails(int id)
    {
        ViewBag.id = id;
        ViewBag.destID = id;
        var value = await _userManager.FindByNameAsync(User.Identity.Name);
        ViewBag.userID = value.Id;
        var values = _destinationService.TGetDestinationWithGuide(id);
        return View(values);
    }
}