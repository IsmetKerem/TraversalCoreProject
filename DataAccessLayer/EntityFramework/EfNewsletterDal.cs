using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfNewsletterDal:GenericRepository<Newsletter>,INewsletterDal
{
    public EfNewsletterDal (Context context) : base(context)
    {}
    
}