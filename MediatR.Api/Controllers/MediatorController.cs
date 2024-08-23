using BuildingBlocks.Common;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MediatorController : ControllerBase
    {
        private readonly ISender _mediator;

        public MediatorController(ISender pMediator)
        {
            this._mediator = pMediator;
        }

        [HttpGet("/HelloWorld/{id}/{description}")]
        public async Task<IResult> Get(string id, string description, CancellationToken cancellationToken)
        {
            Command lCommand = new Command()
            {
                CommandId = id,
                CommandDes = description
            };

            var result = await this._mediator.Send(lCommand, cancellationToken);

            return result.ToHttpResult();
        }
        public sealed record Command : ICommand<Result>
        {
            public string CommandId { get; internal set; } = null!;
            public string CommandDes { get; internal set; } = null!;
        }

        internal class Handler() : IRequestHandler<Command, Result>
        {
            public async Task<Result> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.CommandId == "error")
                {
                    return Result.Fail(new Error($"Error -> ID: {request.CommandId} not found"));
                }

                Console.Write(request.CommandDes);

                return Result.Ok();
            }
        }

    }
}
