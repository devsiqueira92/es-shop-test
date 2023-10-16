using EsShop.API.Middlwares;

namespace EsShop.API.Configurations;

public class MiddlewaresServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<GlobalExceptionHandlingMiddleware>();
    }
}
