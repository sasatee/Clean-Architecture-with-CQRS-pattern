using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRSandMediator.Application.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<ProductVM>
    {
        public int ProductId { get; set; }


    }
}
