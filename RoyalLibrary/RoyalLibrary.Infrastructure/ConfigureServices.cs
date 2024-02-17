using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoyalLibrary.Application.Common.Infrastructure;
using RoyalLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalLibrary.Infrastructure;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddDbContext<ApplicationDbContext>(
            (sp, ob) =>
            {
                ob.UseSqlServer(configuration.GetConnectionString("database"));
            });
    }
}
