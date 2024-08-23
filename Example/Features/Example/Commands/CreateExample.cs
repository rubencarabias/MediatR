using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Features.Example.Commands;
public class CreateExample : IFeatureModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/examples",
                async (Command command, ISender mediator, CancellationToken cancellationToken) =>
                {
                    var result = await mediator.Send(command, cancellationToken);

                    return result.ToHttpResult();
                })
            .WithName(nameof(CreateExample))
            .WithTags(nameof(Domain.Example))
            .Produces(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status409Conflict);
    }

    public sealed record Command : ICommand<Result>
    {
        public string CommandId { get; set; } = null!;
        public string CommandDes { get; set; } = null!;
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