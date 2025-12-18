using DataAccessLayer.Concrete;
using DataAccessLayer.Abstract;        // Interface'ler (IDal)
using DataAccessLayer.EntityFramework; // Ef...Dal Sınıfları
using BusinessLayer.Abstract;          // Servis Interface'leri (IService)
using BusinessLayer.Concrete;
using EntityLayer.Concrete; // Manager Sınıfları
using Microsoft.EntityFrameworkCore;
using TraversalCoreProject.Models;

var builder = WebApplication.CreateBuilder(args);

// appsettings.json içinden connection stringi al
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 1. DbContext'i DI container'a ekle
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));

// -------------------------------------------------------------------------
// 2. Data Access Layer (DAL) Bağımlılıkları (Interface -> Ef...Dal)
// -------------------------------------------------------------------------
builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAbout2Dal, EfAbout2Dal>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IDestinationDal, EfDestinationDal>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDalDal>();
builder.Services.AddScoped<IFeature2Dal, EfFeature2Dal>();
builder.Services.AddScoped<IGuideDal, EfGuideDal>();
builder.Services.AddScoped<INewsletterDal, EfNewsletterDal>();
builder.Services.AddScoped<ISubAboutDal, EfSubAboutDal>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<ICommentDal, EfCommentDal>();

// -------------------------------------------------------------------------
// 3. Business Layer (Manager) Bağımlılıkları (IService -> ...Manager)
// -------------------------------------------------------------------------
builder.Services.AddScoped<IAboutService, AboutManager>();
//builder.Services.AddScoped<IAbout2Service, About2Manager>();
//builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IDestinationService, DestinationManager>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();
//builder.Services.AddScoped<IFeature2Service, Feature2Manager>();
//builder.Services.AddScoped<IGuideService, GuideManager>();
//builder.Services.AddScoped<INewsletterService, NewsletterManager>();
builder.Services.AddScoped<ISubAboutService, SubAboutManager>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<Context>();
builder.Services.AddMvc(config =>
{
    var policy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter(policy));
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/SignIn/";
    // HTTP üzerinde çalışırken çerezin reddedilmesini engeller:
    options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    options.Cookie.Name = "TraversalCookie";
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // Önce kim olduğunu kontrol et
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();