using System.Data;
using BuildingBlocks.DependencyInjection;

namespace Examples;

public static class ExamplesModule
{
    public static WebApplicationBuilder Install(WebApplicationBuilder builder)
    {
        builder.AddAssemblyServices(typeof(ExamplesModule).Assembly);

        return builder;
    }

}