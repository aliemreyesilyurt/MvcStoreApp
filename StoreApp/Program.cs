using FluentValidation;
using FluentValidation.AspNetCore;
using StoreApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly); //API Support

builder.Services.AddControllersWithViews(options =>
{
    options.ModelMetadataDetailsProviders.Clear();
});

builder.Services
    .AddFluentValidationAutoValidation(options =>
    {
        options.DisableDataAnnotationsValidation = true;
    })
    .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureRepositoryRegistration(); //Repositories Configuration
builder.Services.ConfigureServiceRegistration(); //Services Configuration
builder.Services.ConfigureRouting();
builder.Services.ConfigureIdentity(); //Identity Configuration
builder.Services.ConfigureSession(); //Session Configuration
builder.Services.ConfigureApplicationCookie();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseStaticFiles(); //for wwwroot middleware
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();

    endpoints.MapControllers();
});

app.ConfigureAndCheckMigration();
app.ConfigureLocalization();
app.ConfigureDefaultAdminUser();

app.Run();
