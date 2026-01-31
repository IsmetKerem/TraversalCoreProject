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
        _commentDal.Delete(t);
    }

    public void TUpdate(Comment t)
    {
        throw new NotImplementedException();
    }

    public List<Comment> TGetList()
    {
        return _commentDal.GetList();
    }

    public List<Comment> TGetDestinationById(int id)
    {
        return _commentDal.GetListByFilter(x=>x.DestinationID == id);
    }

    public List<Comment> TGetListCommentWithDestination()
    {
        return _commentDal.GetListCommentWithDestination();
    }

    public List<Comment> TGetListCommentWithDestinationAndUser(int id)
    {
        return _commentDal.GetListCommentWithDestinationAndUser(id);
    }

    public List<Comment> TGetListCommentWithUser(int userId)
    {
        return _commentDal.GetListCommentWithUser(userId);
    }

    public Comment TGetComment(int id)
    {
        throw new NotImplementedException();
    }

    public Comment TGetByID(int id)
    {
        return _commentDal.GetComment(id);
    }


}