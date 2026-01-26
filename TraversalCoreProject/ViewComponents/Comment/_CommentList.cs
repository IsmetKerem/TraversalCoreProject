using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Comment;

public class _CommentList: ViewComponent
{
    private readonly ICommentService _commentService;
    private readonly Context _context;
    
    public _CommentList(ICommentService commentService, Context context)
    {
        _commentService = commentService;
        _context = context;
    }
    public IViewComponentResult Invoke(int id)
    {
        ViewBag.commentcount = _context.Comments.Where(x=>x.DestinationID==id).Count();
        var values = _commentService.TGetListCommentWithDestinationAndUser(id);
        return View(values);
    }
}