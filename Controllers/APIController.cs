using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureWithCQRSandMediator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class APIController : ControllerBase
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
