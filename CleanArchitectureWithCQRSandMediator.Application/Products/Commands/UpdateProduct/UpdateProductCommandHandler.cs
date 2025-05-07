using AutoMapper;
using CleanArchitectureWithCQRSandMediator.Domain.Entity;
using CleanArchitectureWithCQRSandMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRSandMediator.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
          
        }

       

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var updateProductEntity = new Product()
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                ExpiryDate = request.ExpiryDate,
                ManufactureDate = request.ManufactureDate,
            };
            return await _productRepository.UpdateAsync(request.Id, updateProductEntity);
            
        }
    }
}
