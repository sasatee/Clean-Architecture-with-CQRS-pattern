using CleanArchitectureWithCQRSandMediator.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWithCQRSandMediator.Infrastructure.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
            

        }

        public DbSet<Product> Products { get; set; }
    }
}

