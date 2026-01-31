using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index(int id)
        {
            ViewData["PageTitle"] = "Yorumlar";
            var userId = int.Parse(((ClaimsPrincipal)User).FindFirstValue(ClaimTypes.NameIdentifier));
		
            var values = _commentService.TGetListCommentWithUser(userId);

            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var values=_commentService.TGetByID(id);
            _commentService.TDelete(values);
            return RedirectToAction("Index","Comment", new { area = "Member" });
        }

        [HttpGet]
        public IActionResult EditComment(int id)
        {
            ViewData["PageTitle"] = "Yorum Detayı";

            var userId = int.Parse(((ClaimsPrincipal)User).FindFirstValue(ClaimTypes.NameIdentifier));

            
            var comment = _commentService.TGetListCommentWithUser(userId)
                .FirstOrDefault(c => c.CommentID == id);

            return View(comment); 
        }

        [HttpPost]
        public IActionResult EditComment(Comment comment)
        {
            if (comment != null)
            {

                var existingComment = _commentService.TGetByID(comment.CommentID);

                if (existingComment != null)
                {
                    existingComment.CommentContent = comment.CommentContent;  
                    _commentService.TUpdate(existingComment);
                }
            }

            return RedirectToAction("Index", "Comment", new { area = "Member" });
        }
    }
}