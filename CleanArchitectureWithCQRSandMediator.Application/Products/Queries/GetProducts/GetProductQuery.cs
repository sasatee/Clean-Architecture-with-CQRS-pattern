using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureWithCQRSandMediator.Application.Products.Queries.GetProducts
{
    //public class GetProductQuery :IRequest<List<int>>
    //{
    //}

    public record GetProductQuery : IRequest<List<ProductVM>>
    {

    }
}
