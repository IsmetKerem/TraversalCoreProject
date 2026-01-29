using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class DestinationManager: IDestinationService
{
    IDestinationDal _destinationDal;

    public DestinationManager(IDestinationDal destinationDal)
    {
        _destinationDal = destinationDal;
    }

    public void TAdd(Destination t)
    {
        _destinationDal.Insert(t);
    }

    public void TDelete(Destination t)
    {
        _destinationDal.Delete(t);
    }

    public void TUpdate(Destination t)
    {
        _destinationDal.Update(t);
    }

    public List<Destination> TGetList()
    {
        return _destinationDal.GetList();
    }

    public Destination TGetByID(int id)
    {
        return _destinationDal.GetById(id);
        
       

    }

    public Destination TGetDestinationWithGuide(int id)
    {
        return _destinationDal.GetDestinationWithGuide(id);
    }
}