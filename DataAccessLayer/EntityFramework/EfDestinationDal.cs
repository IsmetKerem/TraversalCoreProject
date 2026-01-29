using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfDestinationDal:GenericRepository<Destination>,IDestinationDal
{
    private readonly Context _context;
    
    public EfDestinationDal(Context context) : base(context)
    {
        _context = context;
    }

    public Destination GetDestinationWithGuide(int id)
    {
        return _context.Destinations.Where(x=>x.DestinationID==id).Include(x => x.Guide).FirstOrDefault();
    }
}