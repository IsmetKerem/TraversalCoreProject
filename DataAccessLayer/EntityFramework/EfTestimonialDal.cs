using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfTestimonialDal:GenericRepository<Testimonial>,ITestimonialDal
{
    public EfTestimonialDal(Context context) : base(context)
    {}
    
}