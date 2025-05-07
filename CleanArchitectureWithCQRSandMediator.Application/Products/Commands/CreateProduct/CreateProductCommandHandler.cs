using AutoMapper;
using CleanArchitectureWithCQRSandMediator.Domain.Entity;
using CleanArchitectureWithCQRSandMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRSandMediator.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductVM>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductVM> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var productEntity = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                ExpiryDate = request.ExpiryDate,
                ManufactureDate = request.ManufactureDate,
            };
            var result = await _productRepository.CreateAsync(productEntity);
           return _mapper.Map<ProductVM>(result);

        }
    }
}
