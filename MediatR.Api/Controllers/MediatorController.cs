using Microsoft.AspNetCore.Mvc;

namespace MediatR.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MediatorController : ControllerBase
    {
        private readonly ISender _mediator;

        public MediatorController(ISender pMediator)
        {
            this._mediator = pMediator;
        }

        [HttpGet(Name = "HelloWorld")]
        public string Get()
        {
            return "Hola Mundo!";
        }
    }
}
