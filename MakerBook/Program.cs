using MakerBook.Data;
using MakerBook.Helper;
using MakerBook.Helper.Interface;
using MakerBook.Repository;
using MakerBook.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer("Server=tcp:doitlocal.database.windows.net,1433;Initial Catalog=doitlocal;Persist Security Info=False;User ID=doitlocal;Password=ByuIdaho@2022;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICustomerAddressRepository, CustomerAddressRepository>();
builder.Services.AddScoped<IProfessionalRepository, ProfessionalRepository>();
builder.Services.AddScoped<IProfessionalProfileRepository, ProfessionalProfileRepository>();
builder.Services.AddScoped<IProfessionalSocialMediaRepository, ProfessionalSocialMediaRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IServiceAddressRepository, ServiceAddressRepository>();
builder.Services.AddScoped<IServiceImageRepository, ServiceImageRepository>();
builder.Services.AddScoped<ICustomerFavoriteServiceRepository, CustomerFavoriteServiceRepository>();


builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<ISessionHelper, SessionHelper>();
builder.Services.AddScoped<IEmail, Email>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
//pattern: "{controller=Login}/{action=Index}/{id?}");
pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
