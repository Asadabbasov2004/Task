using Microsoft.EntityFrameworkCore;
using MVC_relation_detail.DAL;

namespace MVC_relation_detail
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer("Server=ASUS-TUF-F17;database=FrontToBackMVC-3;Trusted_connection=true;Integrated security=true;Encrypt=false");

            });
            var app = builder.Build();





            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}"
                );
            app.UseStaticFiles();


            app.Run();
        }
    }
}
