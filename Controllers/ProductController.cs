using CleanArchitectureWithCQRSandMediator.Application.Products;
using CleanArchitectureWithCQRSandMediator.Application.Products.Commands.CreateProduct;
using CleanArchitectureWithCQRSandMediator.Application.Products.Commands.DeleteProduct;
using CleanArchitectureWithCQRSandMediator.Application.Products.Commands.UpdateProduct;
using CleanArchitectureWithCQRSandMediator.Application.Products.Queries.GetProductById;
using CleanArchitectureWithCQRSandMediator.Application.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureWithCQRSandMediator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : APIController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await Mediator.Send(new GetProductQuery());
            return Ok(products);
        }



        [HttpGet("{Id}", Name = "GetProductById")]
        public async Task<IActionResult> GetById(int Id)
        {
            var product = await Mediator.Send(new GetProductByIdQuery() { ProductId = Id });
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            var result = await Mediator.Send(command);
            return CreatedAtRoute(
                routeName: "GetProductById",
                routeValues: new { Id = result.Id },
                value: result
            );
        }


        [HttpPut("{Id}", Name = "UpdateProductById")]
        public async Task<IActionResult> Update(int Id,UpdateProductCommand command)
        {

            if(Id != command.Id)
            {
                return BadRequest();    

            }
            await Mediator.Send(command);
            return NoContent();


        }

        [HttpDelete("{id}", Name = "DeleteProductById")]
        public async Task<IActionResult> DeleteById(int id)
        {
           

           var result = await Mediator.Send(new DeleteProductCommand() { Id = id});
         
            return NoContent();

        }
    }

    
}
