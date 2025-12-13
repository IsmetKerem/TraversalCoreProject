using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfFeatureDalDal: GenericRepository<Feature>,IFeatureDal
{
    public EfFeatureDalDal (Context context) : base(context)
    {}
    
}