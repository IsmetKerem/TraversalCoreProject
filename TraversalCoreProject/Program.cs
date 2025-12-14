using DataAccessLayer.Concrete;
using DataAccessLayer.Abstract;        // Interface'ler (IDal)
using DataAccessLayer.EntityFramework; // Ef...Dal Sınıfları
using BusinessLayer.Abstract;          // Servis Interface'leri (IService)
using BusinessLayer.Concrete;          // Manager Sınıfları
using Microsoft.EntityFrameworkCore;

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

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();