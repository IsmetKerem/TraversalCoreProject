using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers;

public class AdminController : Controller
{
    // GET
    public PartialViewResult PartialHeader()
    {
        return PartialView();
    }

    public PartialViewResult PartialAppBrandDemo()
    {
        return PartialView();
    }
}