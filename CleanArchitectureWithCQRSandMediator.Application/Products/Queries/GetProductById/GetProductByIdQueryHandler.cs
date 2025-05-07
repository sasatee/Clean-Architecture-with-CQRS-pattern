using AutoMapper;
using CleanArchitectureWithCQRSandMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRSandMediator.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductVM>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductVM> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
           var blog =  await _productRepository.GetByIdAsync(request.ProductId);
            return _mapper.Map<ProductVM>(blog);
        }
    }
}
