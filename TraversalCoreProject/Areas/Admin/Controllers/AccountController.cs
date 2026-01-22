using BusinessLayer.Abstract.AbstractUow;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers;

[Area("Admin")]
public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    // GET
   [HttpGet] 
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(AccountViewModel model)
    {
        var valueSender= _accountService.TGetByID(model.SenderId);
        var valueReceiver= _accountService.TGetByID(model.ReceiverId);
        valueSender.Balance -= model.Amount;
        valueReceiver.Balance += model.Amount;

        List<Account> modifiedAccounts = new List<Account>()
        {
            valueSender,
            valueReceiver
        };
        _accountService.TMultiUpdate(modifiedAccounts);
        return View();
    }
}