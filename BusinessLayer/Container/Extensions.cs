using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUow;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUow;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
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
        
        
        services.AddScoped<IContactUsService, ContactUsManager>();
        services.AddScoped<IContactUsDal,EfContactUsDal>();
        
        services.AddScoped<IAnnouncementService,AnnouncementManager>();
        services.AddScoped<IAnnouncementDal,EfAnnouncementDal>();

        services.AddScoped<IAccountService, AccountManager>();
        services.AddScoped<IAccountDal,EfAccountDal>();
        
        
        services.AddScoped<IUowDal,UowDal>();
       
        

    }

    public static void CustomerValidator(this IServiceCollection services)
    {
        services.AddTransient<IValidator<AnnouncementAddDto>, AnnouncementValidator>();

    }
}