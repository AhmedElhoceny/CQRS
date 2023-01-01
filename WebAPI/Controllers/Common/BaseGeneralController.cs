using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Common
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BaseGeneralController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>()!;
    }
}
