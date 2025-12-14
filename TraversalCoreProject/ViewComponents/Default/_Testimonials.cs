using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default;

public class _Testimonials:ViewComponent
{
    private readonly ITestimonialService _testimonialService;

    public _Testimonials(ITestimonialService testimonialService)
    {
        _testimonialService = testimonialService;
    }
    public IViewComponentResult Invoke()
    {
        var values = _testimonialService.TGetList();
        return View(values);
    }
}