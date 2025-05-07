using CleanArchitectureWithCQRSandMediator.Application.Products.Commands.UpdateProduct;
using CleanArchitectureWithCQRSandMediator.Domain.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRSandMediator.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;

            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id cannot be empty.")
                .NotNull().WithMessage("Id cannot be null.")
                .GreaterThan(0).WithMessage("Id must be greater than 0.")
                .MustAsync(async (id, cancellation) => 
                {
                    var productExists = await _productRepository.GetByIdAsync(id);
                    return productExists != null;
                }).WithMessage(x => $"Product with Id {x.Id} does not exist in database.");

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Product Description is required.")
                .MinimumLength(10).WithMessage("Description must be at least 10 characters.")
                .MaximumLength(2000).WithMessage("Description must not exceed 2000 characters.");

            RuleFor(v => v.ManufactureDate)
                .NotEmpty().WithMessage("Manufacture Date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Manufacture Date cannot be in the future.")
                .GreaterThan(DateTime.UtcNow.AddYears(-100)).WithMessage("Manufacture Date cannot be more than 100 years in the past.");

            RuleFor(v => v.ExpiryDate)
                .NotEmpty().WithMessage("Expiry Date is required.")
                .GreaterThan(v => v.ManufactureDate).WithMessage("Expiry Date must be after the Manufacture Date.")
                .LessThan(v => v.ManufactureDate.AddYears(10)).WithMessage("Expiry Date cannot be more than 10 years after Manufacture Date.");

            // ensure the expiry date is reasonable (custom rule)
            // RuleFor(v => new { v.ManufactureDate, v.ExpiryDate })
            //     .Custom((dates, context) => 
            //     {
            //         var shelfLife = dates.ExpiryDate - dates.ManufactureDate;
            //         if (shelfLife.TotalDays < 1)
            //         {
            //             context.AddFailure("ExpiryDate", "Product must have at least 1 day of shelf life.");
            //         }
            //     });
        }
    }
}