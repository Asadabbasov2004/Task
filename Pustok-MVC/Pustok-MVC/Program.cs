var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer("Server=DESKTOP-4EOUDP3;database=pustokDb;Trusted_connection=true;Integrated security=true;Encrypt=false");

}) ;

var app = builder.Build();

app.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}"
         );
app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
    );


app.UseStaticFiles();

app.Run();
