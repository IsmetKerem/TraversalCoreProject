using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.Controllers;
[Area("Member")]
[AllowAnonymous]
public class DestinationController : Controller
{
    private readonly IDestinationService _destinationService;
    public DestinationController(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }
    // GET
    public IActionResult Index()
    {
        var values = _destinationService.TGetList();
        return View(values);
    }
    public IActionResult GetCitiesSearchByName(string searchString)
    {
        ViewData["PageTitle"] = "Tur Rotaları";

        ViewData["CurrentFilter"] = searchString;
        var values = from x in _destinationService.TGetList() select x;
        if (!string.IsNullOrEmpty(searchString))
        {
            values =values.Where(x=>x.City.Contains(searchString));
        }
        return View(values.ToList());
    }
}