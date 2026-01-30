using DataAccessLayer.Concrete;
using DataAccessLayer.Abstract;        // Interface'ler (IDal)
using DataAccessLayer.EntityFramework; // Ef...Dal Sınıfları
using BusinessLayer.Abstract;          // Servis Interface'leri (IService)
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR; // Manager Sınıfları
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using TraversalCoreProject.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProject.Models;


var builder = WebApplication.CreateBuilder(args);
ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug();
});
// appsettings.json içinden connection stringi al
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.CustomerValidator();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/SignIn/";
});

builder.Services.AddControllersWithViews()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());



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
builder.Services.AddScoped<IAppUserDal, EfAppUserDal>();
builder.Services.AddScoped<IReservationDal, EfReservationDal>();
builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<GetDestinationByIDQueryHandler>();
builder.Services.AddScoped<RemoveDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();
builder.Services.AddMediatR(typeof(Program));


// -------------------------------------------------------------------------
// 3. Business Layer (Manager) Bağımlılıkları (IService -> ...Manager)
// -------------------------------------------------------------------------
builder.Services.ContainerDependencies();

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

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var path = Directory.GetCurrentDirectory();
loggerFactory.AddFile($"{path}/Logs/log1.txt");



// Configure the HTTP request pipeline. 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");

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
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();