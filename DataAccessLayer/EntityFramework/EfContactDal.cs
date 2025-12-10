using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfContactDal:GenericRepository<Contact>,IContactDal
{
    public EfContactDal(Context context) : base(context)
    {
        
    }
}