using Bookstore.Application.DTOs.Mapping;
using Bookstore.Domain.Interfaces;
using Bookstore.Infra.Data.Context;
using Bookstore.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("DATABASE") ?? configuration.GetConnectionString("DefaultConnection");
            service.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            service.AddAutoMapper(typeof(MappingProfile));
            
            service.AddScoped<IUnitOfWork, UnitOfWork>();
            
            return service;
        }
    }
}