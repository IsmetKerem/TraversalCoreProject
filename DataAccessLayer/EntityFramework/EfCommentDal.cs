using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfCommentDal:GenericRepository<Comment>,ICommentDal
{
    public EfCommentDal(Context context) : base(context)
    {
        
    }
}