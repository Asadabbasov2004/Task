using First_Api;
using First_Api.DAL;
using First_Api.Entities;
using First_Api.Repositories.Abstraction;
using First_Api.Repositories.Implementation;
using First_Api.Services.Implimentations;
using First_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBrandRepository,BrandRepository>();
builder.Services.AddScoped<IBrandService,BrandService>();
builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
