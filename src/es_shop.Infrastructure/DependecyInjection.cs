
using Microsoft.Extensions.Azure;
using EsShop.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Infrastructure.Repositories;

namespace EsShop.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configurationManager)
    {
        AddContext(services, configurationManager);
        AddBlobService(services, configurationManager);
        AddRepositories(services);
    }


    private static void AddBlobService(IServiceCollection services, IConfiguration configurationManager)
    {
        services.AddAzureClients(builder =>
        {
            builder.AddBlobServiceClient(configurationManager.GetConnectionString("Blobstorage"));
        });
    }
    private static void AddContext(IServiceCollection services, IConfiguration configurationManager)
    {
        services.AddDbContext<EsShopContext>(dbContext =>
        {
            dbContext.UseSqlServer(configurationManager.GetConnectionString("Database"));
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IColorRepository, ColorRepository>()
                .AddScoped<IFabricRepository, FabricRepository>()
                .AddScoped<IShirtRepository, ShirtRepository>()
                .AddScoped<IShirtSpecificationRepository, ShirtSpecificationRepository>()
                .AddScoped<IShirtSpecificationImageRepository, ShirtSpecificationImageRepository>()
                .AddScoped<IAzureBlobStorageHandler, AzureBlobStorageHandler>()
                .AddScoped<IUnitOfWork, UnitOfWork>();
    }
}