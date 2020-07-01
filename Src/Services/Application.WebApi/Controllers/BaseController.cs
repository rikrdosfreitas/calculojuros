using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebApi.Controllers
{
    [Route("api/"), ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator Mediator;

        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
