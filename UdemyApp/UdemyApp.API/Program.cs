using Microsoft.EntityFrameworkCore;
using UdemyApp.DAL.Context;
using UdemyApp.DAL.Repositories.Implementations;
using UdemyApp.DAL.Repositories.Interfaces;

namespace UdemyApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
          //  builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("myDb1")));
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}