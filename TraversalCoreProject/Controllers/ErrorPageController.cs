using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers;

public class ErrorPageController : Controller
{
    // GET
    public IActionResult Error404(int code)
    {
        return View();
    }
}