using System.Runtime.CompilerServices;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers;

public class CommentController : Controller
{

    private readonly ICommentService _commentService;
    private readonly UserManager<AppUser>  _userManager;
    

    public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
    {
        _commentService = commentService;
        _userManager = userManager;
    }
    // GET
    [HttpGet]
    public PartialViewResult AddComment()
    {
        //ViewBag.destId = id;

        //var value = await _userManager.FindByNameAsync(User.Identity.Name);
        //ViewBag.userId = value.Id;
        return PartialView();
    }
    [HttpPost]
    public IActionResult AddComment(Comment comment)
    {
        comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        comment.CommentState = true;
        _commentService.TAdd(comment);
        return RedirectToAction("Index", "Destination");
    }
}
