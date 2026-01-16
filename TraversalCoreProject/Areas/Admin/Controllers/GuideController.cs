using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers;
[Area("Admin")]
public class GuideController : Controller
{
    private readonly IGuideService _guideService;

    public GuideController(IGuideService guideService)
    {
        _guideService = guideService;
    }
    // GET
    public IActionResult Index()
    {
        var values = _guideService.TGetList();
        return View(values);
    }
    [HttpGet]
    public IActionResult AddGuide()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddGuide(Guide guide)
    {
        GuideValidator validationRules = new GuideValidator();
        ValidationResult results = validationRules.Validate(guide);
        if (results.IsValid)
        {
            _guideService.TAdd(guide);
            return RedirectToAction("Index");
        }
        else
        {
            foreach (var item in results.Errors )
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }

            return View();
        }
       
    }
    [HttpGet]
    public IActionResult EditGuide(int id)
    {
        var values = _guideService.TGetByID(id);
        return View();
    }
    [HttpPost]
    public IActionResult EditGuide(Guide guide)
    {
        _guideService.TUpdate(guide);
        return RedirectToAction("Index");
    }

    public IActionResult ChangeToTrue(int id)
    {
        _guideService.TChangeToTrueByGuide(id);
        return RedirectToAction("Index");
    }
    public IActionResult ChangeToFalse(int id)
    {
        _guideService.TChangeToFalseByGuide(id);
        return RedirectToAction("Index");
    }

}