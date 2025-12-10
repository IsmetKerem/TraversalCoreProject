using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfSubAboutDal:GenericRepository<SubAbout>,ISubAboutDal
{
    public EfSubAboutDal(Context context) : base(context)
    {}
    
}