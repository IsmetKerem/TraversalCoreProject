using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface ICommentDal:IGenericDal<Comment>
{
    public List<Comment> GetListCommentWithDestination();
    public List<Comment> GetListCommentWithDestinationAndUser(int id);
    public List<Comment> GetListCommentWithUser(int userId);
    public Comment GetComment(int id);
}