using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace TraversalCoreProject.Controllers;

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
    [HttpGet]

    public IActionResult DestinationDetails(int id)
    {
        ViewBag.id = id;
        var values = _destinationService.TGetByID(id);
        return View(values);
    }
    [HttpPost]

    public IActionResult DestinationDetails(Destination p)
    {
        return View();
    }
}