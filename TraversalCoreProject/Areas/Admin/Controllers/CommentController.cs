using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers;
[Area("Admin")]
[Route("admin/[controller]/[action]")]
public class CommentController : Controller
{
    ICommentService _commentService;
    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }
    public IActionResult Index()
    {
        var values = _commentService.TGetListCommentWithDestination();
        return View(values);
    }
    [Route("/Admin/Comment/DeleteComment/{id}")]
    public IActionResult DeleteComment(int id)
    {
        var values = _commentService.TGetByID(id);
    
        // Güvenlik Önlemi: Eğer ID veritabanında yoksa uygulama çökmesin
        if (values == null)
        {
            return RedirectToAction("Index");
        }

        _commentService.TDelete(values);
        return RedirectToAction("Index");
    }
}