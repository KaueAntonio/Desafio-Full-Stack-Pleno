using CIoTD.Core.V1.Auth.Interfaces.Repositories;
using CIoTD.Core.V1.Auth.Interfaces.Services;
using CIoTD.Core.V1.Auth.Repositories;
using CIoTD.Core.V1.Auth.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CIoTD.Core.IoC;

public static class CoreModules
{
    public static void AddCoreModules(IServiceCollection services)
    {
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IAuthService, AuthService>();
    }
}
