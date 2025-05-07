using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRSandMediator.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ProductVM>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
