using BlogApp.Business.ExternalServices.Implemantation;
using BlogApp.Business.ExternalServices.Interface;
using BlogApp.Business.Services.Implementation;
using BlogApp.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
