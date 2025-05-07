using CleanArchitectureWithCQRSandMediator.Domain.Repository;
using CleanArchitectureWithCQRSandMediator.Infrastructure.Data;
using CleanArchitectureWithCQRSandMediator.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureWithCQRSandMediator.Infrastructure
{
    public static class ConfigureServices
    {
        //extension method
        public static IServiceCollection AddInfrastructureServices
        (
                this IServiceCollection services,
                IConfiguration configuration)
        {

            services.AddDbContext<ProductDbContext>(options =>
            
                options.UseSqlite(configuration.GetConnectionString("ProductDb") ?? 
                    throw new InvalidOperationException("connection string not found" ))
            );
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        
        
        }

    }
}
