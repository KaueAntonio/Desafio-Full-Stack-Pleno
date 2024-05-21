using CIoTD.Infrastructure.Data;
using CIoTD.Infrastructure.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CIoTD.Infrastructure.IoC;

public static class InfraModules
{
    public static void AddInfraModules(IServiceCollection services)
    {
        services.AddScoped<IConnection, Connection>();
    }
}
