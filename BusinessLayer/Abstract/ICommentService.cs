using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface ICommentService:IGenericService<Comment>
{
    List<Comment> TGetDestinationById(int id);
    List<Comment> TGetListCommentWithDestination();
    public List<Comment> TGetListCommentWithDestinationAndUser(int id);
    List<Comment> TGetListCommentWithUser(int userId);  
    public Comment TGetComment(int id);

}