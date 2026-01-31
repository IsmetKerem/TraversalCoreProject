using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace TraversalCoreProject.ViewComponents.MemberLayout;

public class _MemberLayoutLanguages : ViewComponent
{
    private readonly IOptions<RequestLocalizationOptions> _locOptions;

    public _MemberLayoutLanguages(IOptions<RequestLocalizationOptions> locOptions)
    {
        _locOptions = locOptions;
    }
    public IViewComponentResult Invoke()
    {
        var requestCulture = HttpContext.Features.Get<IRequestCultureFeature>();
        var currentCulture = requestCulture?.RequestCulture.UICulture.Name ?? "tr-TR";
        var supportedCultures = _locOptions.Value.SupportedUICultures;

        ViewBag.CurrentCulture = currentCulture;
        ViewBag.SupportedCultures = supportedCultures;
        ViewBag.ReturnUrl = HttpContext.Request.Path + HttpContext.Request.QueryString;

        return View();
    }
}