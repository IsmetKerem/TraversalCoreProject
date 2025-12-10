using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfAbout2Dal:GenericRepository<About2>,IAbout2Dal
{
    public EfAbout2Dal (Context context) : base(context)
    {}
    
}