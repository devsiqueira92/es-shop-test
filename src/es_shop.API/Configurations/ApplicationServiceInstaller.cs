using FluentValidation;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using EsShop.Application.Color.Queries.GetColors;

namespace EsShop.API.Configurations;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.AddRouting(option => option.LowercaseUrls = true);
        services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);
        services.AddEndpointsApiExplorer();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<GetColorsQuery>();
        });

        services.AddSwaggerGen();

        services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}