using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfAnnouncementDal:GenericRepository<Announcement>,IAnnouncementDal
{
    public EfAnnouncementDal (Context context) : base(context)
    {}
}