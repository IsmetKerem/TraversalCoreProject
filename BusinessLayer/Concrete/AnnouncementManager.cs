using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class AnnouncementManager:IAnnouncementService
{
    private IAnnouncementDal _announcementDal;

    public AnnouncementManager(IAnnouncementDal announcementDal)
    {
        _announcementDal = announcementDal;
    }
    public void TAdd(Announcement t)
    {
        _announcementDal.Insert(t);
    }

    public void TDelete(Announcement t)
    {
        _announcementDal.Delete(t);
    }

    public void TUpdate(Announcement t)
    {
        _announcementDal.Update(t);
    }

    public List<Announcement> TGetList()
    {
        return _announcementDal.GetList();
    }

    public Announcement TGetByID(int id)
    {
        return _announcementDal.GetById(id);
    }
}