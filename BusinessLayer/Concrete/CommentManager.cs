using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class CommentManager:ICommentService
{
    ICommentDal _commentDal;

    public CommentManager(ICommentDal commentDal)
    {
        _commentDal = commentDal;
    }
    public void TAdd(Comment t)
    {
        _commentDal.Insert(t);
        
    }

    public void TDelete(Comment t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(Comment t)
    {
        throw new NotImplementedException();
    }

    public List<Comment> TGetList()
    {
        throw new NotImplementedException();
    }

    public List<Comment> TGetDestinationById(int id)
    {
        return _commentDal.GetListByFilter(x=>x.DestinationID == id);
    }

    public Comment TGetByID(int id)
    {
        throw new NotImplementedException();
    }


}