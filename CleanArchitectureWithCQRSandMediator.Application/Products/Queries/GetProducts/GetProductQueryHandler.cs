using AutoMapper;
using CleanArchitectureWithCQRSandMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRSandMediator.Application.Products.Queries.GetProducts
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<ProductVM>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductVM>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProductsAsync();


            //var productList = products.Select(x =>
            //   new int {
            //    Description = x.Description,
            //    Name = x.Name,
            //    ManufactureDate = x.ManufactureDate,
            //    ExpiryDate = x.ExpiryDate, 
            //    Id = x.Id }).ToList();

            var productList = _mapper.Map<List<ProductVM>>(products);

            return productList;
        }
    }
}
