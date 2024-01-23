using BMDataHub_Server;
using BMDataHub_Server.Data;
using DataAccess.Data;
using Buisness.Repository;
using Buisness.Repository.IRepository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Radzen;
using Microsoft.AspNetCore.Identity;
using BMDataHub_Server.Areas.Identity.Data;
using BMDataHub_Server.Service.IService;
using BMDataHub_Server.Service;
using Buisness.ApiService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<ApplicationDBContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<IdentityApplicationDBcontext>();

builder.Services.AddDbContext<IdentityApplicationDBcontext>(options =>
       options.UseSqlServer(
           builder.Configuration.GetConnectionString("IdentityApplicationDBcontextConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityApplicationDBcontext>().AddDefaultTokenProviders().AddDefaultUI();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<DataUpdateService>();
builder.Services.AddScoped<CoursesRepository>();
builder.Services.AddScoped<ApiServices>();
builder.Services.AddScoped<BMDataHub_Server.Helper.ThemeService>();

builder.Services.AddHttpClient();

builder.Services.AddScoped<IContactsRepository, ContactsRepository>();
builder.Services.AddScoped<IAllContactsRepository, AllContactsRepository>();

builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
builder.Services.AddScoped<IFeesRepository, FeesRepository>();
builder.Services.AddScoped<IReceiptImageRepository, ReceiptImagesRepository>();
builder.Services.AddScoped<IFileUpload, FileUpload>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpContextAccessor();

builder.Services.AddRadzenComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider.GetRequiredService<IDbInitializer>;
    services.Invoke().Initialize();
}

app.Run();
app.MapRazorPages();
