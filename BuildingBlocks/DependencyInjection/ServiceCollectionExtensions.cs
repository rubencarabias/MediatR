using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BuildingBlocks.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddAssemblyServices(this WebApplicationBuilder app, Assembly assembly)
        {
            app.Services
            .AddMediatR(x => x.RegisterServicesFromAssembly(assembly))
            .AddEndpoints(assembly);

            return app;
        }
    }
}
