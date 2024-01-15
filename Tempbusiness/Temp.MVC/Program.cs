using Microsoft.EntityFrameworkCore;
using Temp.DAL.DbContext;
using Temp.DAL.Repository.Implementations;
using Temp.DAL.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IBlogRepsoitory,BlogRepository>();
//builder.Services.AddScoped<I,BlogRepository>();
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());    
builder.Services.AddDbContext<AppDbcontext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
var app = builder.Build();

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
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
