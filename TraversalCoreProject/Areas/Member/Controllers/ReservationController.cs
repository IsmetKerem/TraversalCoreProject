using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProject.Areas.Member.Controllers;
[Area("Member")]
public class ReservationController : Controller
{
    IDestinationService _destinationService;
    IReservationService _reservationService;
    private readonly UserManager<AppUser> _userManager;

    public ReservationController(IDestinationService destinationService, IReservationService reservationService, UserManager<AppUser> userManager)
    {
        _destinationService = destinationService;
        _reservationService = reservationService;
        _userManager = userManager;
    }
    // GET
    public async Task<IActionResult> MyCurrentReservation()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        var valuesList = _reservationService.GetListWithReservationByAccepted(values.Id);
        return View(valuesList);
    }

    public async  Task<IActionResult> MyOldReservation()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
        var valuesList = _reservationService.GetListWithReservationByPrevious(values.Id);
        return View(valuesList);
    }

    [HttpGet]
    public async Task<IActionResult> MyApprovalReservation()
    {
        var values = await _userManager.FindByNameAsync(User.Identity.Name);
         var valuesList = _reservationService.GetListWithReservationByWaitApproval(values.Id);
        return View(valuesList);
    }
    public IActionResult NewReservation()
    {
        List<SelectListItem> values = (from x in _destinationService.TGetList()
            select new SelectListItem
            {
                Text = x.City,
                Value = x.DestinationID.ToString()
            }).ToList();
        ViewBag.v = values;
        return View();
    }
    [HttpPost]
    public IActionResult NewReservation(Reservation p)
    {
        p.Status = "Onay Bekliyor";
        p.AppUserId = 3;
        _reservationService.TAdd(p);
        return RedirectToAction("MyCurrentReservation");
    }
}