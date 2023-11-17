using FrontToBackMVC_2.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer("Server=DESKTOP-4EOUDP3;database=FrontToBackMVC-2;Trusted_connection=true;Integrated security=true;Encrypt=false");
    
});

var app = builder.Build();


app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Work}/{action=Index}/{id?}"
            );
app.UseStaticFiles();
app.Run();
