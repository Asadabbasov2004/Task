var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();

app.MapControllerRoute(
    name: "first",
    pattern: "{controller=Group}/{action=index}"
    );

app.MapControllerRoute(
    name: "first",
    pattern: "{controller=Student}/{action=index}"
    );

app.MapControllerRoute(
    name: "first",
    pattern: "{controller=Teacher}/{action=index}"
    );
app.Run();
