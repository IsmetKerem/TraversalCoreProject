using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfCommentDal:GenericRepository<Comment>,ICommentDal
{
    private ICommentDal _commentDalImplementation;
    private readonly Context _context;

    public EfCommentDal(Context context) : base(context)
    {
        _context = context;
    }

    public List<Comment> GetListCommentWithDestination()
    {
        return _context.Comments.Include(x=>x.Destination).ToList();
    }

    public List<Comment> GetListCommentWithDestinationAndUser(int id)
    {
        return _context.Comments.Where(x=>x.DestinationID==id).Include(x => x.AppUser).ToList();
    }

    public List<Comment> GetListCommentWithUser(int userId)
    {
        return _context.Comments.Where(x => x.AppUserID == userId)  
            .Include(x => x.Destination)       
            .Include(x => x.AppUser)           
            .ToList();
    }

    public Comment GetComment(int id)
    {
        return _context.Comments
            .Include(c => c.AppUser)       
            .Include(c => c.Destination)  
            .FirstOrDefault(c => c.CommentID == id);
    }
}