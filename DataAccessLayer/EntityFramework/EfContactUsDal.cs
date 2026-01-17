using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfContactUsDal:GenericRepository<ContactUs>,IContactUsDal
{
    private readonly Context _context;
    
    public EfContactUsDal (Context context) : base(context)
    {
        _context = context;
    }

    public List<ContactUs> GetListContactUsByTrue()
    {
        var values = _context.ContactUses.Where(x=>x.MessageStatus==true).ToList();
        return values;
    }

    public List<ContactUs> GetListContactUsByFalse()
    {
        var values = _context.ContactUses.Where(x=>x.MessageStatus==false).ToList();
        return values;
    }

    public void ContactUsStatusChangeToFale(int id)
    {
        throw new NotImplementedException();
    }
}