using EsShop.Infrastructure;

namespace EsShop.API.Configurations;

public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
    }
}
