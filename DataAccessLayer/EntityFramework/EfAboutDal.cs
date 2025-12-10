using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfAboutDal:GenericRepository<About>,IAboutDal 
{
    public EfAboutDal (Context context) : base(context)
    {}
}