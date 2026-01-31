using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.Controllers;

public class InformationController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}