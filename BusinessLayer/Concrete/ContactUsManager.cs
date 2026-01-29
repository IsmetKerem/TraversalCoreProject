using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class ContactUsManager:IContactUsService
{
    IContactUsDal _contactUsDal;

    public ContactUsManager(IContactUsDal contactUsDal)
    {
        _contactUsDal = contactUsDal;
    }
    public void TAdd(ContactUs t)
    {
        _contactUsDal.Insert(t);
    }

    public void TDelete(ContactUs t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(ContactUs t)
    {
        throw new NotImplementedException();
    }

    public List<ContactUs> TGetList()
    {
        return _contactUsDal.GetList();
    }

    public ContactUs TGetByID(int id)
    {
        throw new NotImplementedException();
    }

    public List<ContactUs> TGetListContactUsByTrue()
    {
        return _contactUsDal.GetListContactUsByTrue();
    }

    public List<ContactUs> TGetListContactUsByFalse()
    {
       return _contactUsDal.GetListContactUsByFalse();
    }

    public void TContactUsStatusChangeToFale(int id)
    {
        throw new NotImplementedException();
    }
}