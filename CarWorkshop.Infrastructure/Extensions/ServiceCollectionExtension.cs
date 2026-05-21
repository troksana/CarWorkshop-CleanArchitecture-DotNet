using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistance;
using CarWorkshop.Infrastructure.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using CarWorkshop.Application.ApplicationUser;


namespace CarWorkshop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarWorkshopDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CarWorkshop")));
            services.AddScoped<IUserContext, UserContext>();
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<CarWorkshopDbContext>(); //komunikacja z baza danych
            services.AddScoped<CarWorkshopSeeder>();

            services.AddScoped<ICarWorkshopRepository, CarWorkshopRepository>();
            services.AddScoped<ICarWorkshopServiceRepository, CarWorkshopServiceRepository>();
        }
    }
}
