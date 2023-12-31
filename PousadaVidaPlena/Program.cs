using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using PousadaVidaPlena.Data;
using PousadaVidaPlena.Services;
using DinkToPdf.Contracts;
using DinkToPdf;
using Microsoft.AspNetCore.Identity;
using PousadaVidaPlena.Areas.Identity.Data;


var builder = WebApplication.CreateBuilder(args);


// Configurando o DbContext com MySQL e definindo a vers�o do servidor
builder.Services.AddDbContext<PousadaContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("PousadaContext");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddDbContext<AuthDbContext>(options =>
{
    var authConnectionString = builder.Configuration.GetConnectionString("AuthDbContext");
    options.UseMySql(authConnectionString, ServerVersion.AutoDetect(authConnectionString));
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
               .AddEntityFrameworkStores<AuthDbContext>();

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<ReservationService>();
builder.Services.AddScoped<ReservationValidationService>();
builder.Services.AddScoped<ReservationRecordService>();
builder.Services.AddScoped<ReservationAvailabilityService>();




// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// cconfigurao de localizao.
var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
};
app.UseRequestLocalization(localizationOptions);

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
    seedingService.Seed();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


app.Run();