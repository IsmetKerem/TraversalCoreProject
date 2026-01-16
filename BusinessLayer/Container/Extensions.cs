using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Container;

public static class Extensions
{
    public static void ContainerDependencies(this IServiceCollection services)
    {
        services.AddDbContext<Context>();
        services.AddScoped<IAboutService, AboutManager>();
        //services.AddScoped<IAbout2Service, About2Manager>();
        //services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<IDestinationService, DestinationManager>();
        services.AddScoped<IFeatureService, FeatureManager>();
        //services.AddScoped<IFeature2Service, Feature2Manager>();
        services.AddScoped<IGuideService, GuideManager>();
        //services.AddScoped<INewsletterService, NewsletterManager>();
        services.AddScoped<ISubAboutService, SubAboutManager>();
        services.AddScoped<ITestimonialService, TestimonialManager>();
        services.AddScoped<ICommentService, CommentManager>();
        services.AddScoped<IExcelService, ExcelManager>();
        services.AddScoped<IPdfService, PdfManager>();
        
        // Business katmanındaki servislerin ve managerların kaydı
        services.AddScoped<IReservationService, ReservationManager>();
        services.AddScoped<IAppUserService, AppUserManager>();
    }
}