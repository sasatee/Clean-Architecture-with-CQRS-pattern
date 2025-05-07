using CleanArchitectureWithCQRSandMediator.Application.Products.Commands.DeleteProduct;
using CleanArchitectureWithCQRSandMediator.Domain.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRSandMediator.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id cannot is empty")
                .NotNull().WithMessage("Id cannot be null")
                .GreaterThan(0).WithMessage("Id must be greater than 0")
                .MustAsync(async (id, cancellation) => 
                {
                    var productExists = await _productRepository.GetByIdAsync(id);
                    return productExists != null;
                }).WithMessage(x => $"Product with Id {x.Id} does not exist in database.");
        }
    }
}