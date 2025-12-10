using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfFeatureDal: GenericRepository<Feature>,IFeature
{
    public EfFeatureDal (Context context) : base(context)
    {}
    
}