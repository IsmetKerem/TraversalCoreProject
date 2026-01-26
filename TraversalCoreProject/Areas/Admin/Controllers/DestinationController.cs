using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers;

[Area("Admin")]
[Route("admin/[controller]/[action]")]
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
    public IActionResult AddDestination()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddDestination(Destination destination)
    {
        _destinationService.TAdd(destination);
        return RedirectToAction("Index");
    }
    [Route("/Admin/Destination/DeleteDestination/{id}")]
    public IActionResult DeleteDestination(int id)
    {
        var values = _destinationService.TGetByID(id);
        if (values != null)
        {
            _destinationService.TDelete(values);
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("/Admin/Destination/UpdateDestination/{id}")] // id'yi rotaya ekledik
    public IActionResult UpdateDestination(int id)
    {
        var values = _destinationService.TGetByID(id);
        if (values == null) 
        {
            return NotFound(); // Eğer id hatalıysa boş sayfa yerine hata döner
        }
        return View(values);
    }

    [HttpPost]
    [Route("/Admin/Destination/UpdateDestination/{id}")] // Post için de rotayı belirttik
    public IActionResult UpdateDestination(Destination destination)
    {
        _destinationService.TUpdate(destination);
        return RedirectToAction("Index");
    }
}