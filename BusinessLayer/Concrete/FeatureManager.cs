using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

public class FeatureManager:IFeatureService
{
    IFeatureDal _featureDal;
    public FeatureManager(IFeatureDal featureDal)
    {
        _featureDal = featureDal;
    }

    public void TAdd(Feature t)
    {
        throw new NotImplementedException();
    }

    public void TDelete(Feature t)
    {
        throw new NotImplementedException();
    }

    public void TUpdate(Feature t)
    {
        throw new NotImplementedException();
    }

    public List<Feature> TGetList()
    {
        return _featureDal.GetList();
    }

    public Feature TGetByID(int id)
    {
        throw new NotImplementedException();
    }
}