using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Services.Implementation;
using BlogApp.Business.Services.Interfaces;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Abstraction;
using BlogApp.DAL.Repositories.Implementation;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Authentication;
using BlogApp.Core.Entities;
using BlogApp.Business;
using FluentValidation.AspNetCore;
using BlogApp.Business.DTOs.AppUserDto;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UdemyApp.Business.Profiles;

namespace BlogApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
            builder.Services.AddServices();

            builder.Services.AddControllers().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssembly(typeof(AccountRegisterDtoValidator).Assembly);
            });
            builder.Services.AddAutoMapper(typeof(CategoryMapProfile).Assembly);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                         {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,

                    RequireExpirationTime = true,
                    ValidateActor = true,

                    ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:Key").Value)),
                    LifetimeValidator = (_, expireDate, token, _) => token != null ? expireDate > DateTime.UtcNow : false
                };
            });


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

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
