using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.Controllers;

public class MessageController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}