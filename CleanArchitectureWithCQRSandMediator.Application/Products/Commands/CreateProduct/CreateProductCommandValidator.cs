using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRSandMediator.Application.Products.Commands.CreateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {

        public UpdateProductCommandValidator()
        {

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters. ");

            RuleFor(v => v.Description)
             .NotEmpty().WithMessage("Product Description is rquired");

            RuleFor(v => v.ManufactureDate)
                .NotEmpty().WithMessage("Manufacture Date is required")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Manufacture Date cannot be in the future.");

            RuleFor(v => v.ExpiryDate)
                .NotEmpty().WithMessage("Expiry Date is required")
                .GreaterThan(v => v.ManufactureDate).WithMessage("Expiry Date must be after the Manufacture Date.");

        }


    }
}