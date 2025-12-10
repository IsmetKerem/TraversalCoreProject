using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}