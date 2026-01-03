using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfAppUserDal:GenericRepository<AppUser>,IAppUserDal
{
    public EfAppUserDal (Context context) : base(context)
    {}
}