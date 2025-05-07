using CleanArchitectureWithCQRSandMediator.Domain.Entity;
using CleanArchitectureWithCQRSandMediator.Domain.Repository;
using CleanArchitectureWithCQRSandMediator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRSandMediator.Infrastructure.Repository
{

    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;
        public ProductRepository(ProductDbContext context)
        {
            _context = context;
            
        }
        public async Task<Product> CreateAsync(Product product)
        {
           await _context.Products.AddAsync(product);
           await _context.SaveChangesAsync();
           return product;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.Products
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Product product)
        {
            return await _context.Products
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(m => m.Id, product.Id)
                .SetProperty(m=>m.Name, product.Name)   
                .SetProperty(m=>m.ManufactureDate, product.ManufactureDate)
                .SetProperty(m=>m.ExpiryDate, product.ExpiryDate)
                .SetProperty(m=>m.Description, product.Description)
                );
        }
    }
}
