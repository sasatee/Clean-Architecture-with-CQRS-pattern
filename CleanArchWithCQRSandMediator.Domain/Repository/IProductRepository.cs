using CleanArchitectureWithCQRSandMediator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRSandMediator.Domain.Repository
{

    //abstraction repository
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetByIdAsync(int id); 
        Task<Product> CreateAsync(Product product);
        Task<int> UpdateAsync(int id,Product product);
        Task<int> DeleteAsync(int id);

    }
}
