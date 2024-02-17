using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RoyalLibrary.Application;

public static class ConfigureServices
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
