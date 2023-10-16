using MediatR;
using EsShop.API.Configurations;
using EsShop.Application.Fabric.Commands.AddFabric;
using EsShop.Application.Fabric.Commands.UpdateFabric;
using EsShop.Application.Fabric.Queries.GetFabrics;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Requests;
using EsShop.Shared.Communications.Responses;

namespace EsShop.API.Endpoints;

public class FabricEndpoint : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var fabric = app.MapGroup("api/fabric");
        fabric.MapGet("/", GetFabrics)
            .AllowAnonymous();

        fabric.MapPost("/", CreateFabric)
            .Produces<FabricResponse>(200)
            .Produces<Error>(404)
            .AllowAnonymous();

        fabric.MapPut("/", UpdateFabric)
            .Produces<FabricResponse>(200)
            .Produces<Error>(404)
            .AllowAnonymous();

        //.AddEndpointFilter<ValidationFilter<CreateUserRequest>>()
        //.Produces<UserResponse>();

        //user.MapGet("/{id}", GetUserById)
        //.WithName("GetUserById")
        //.Produces<UserResponse>();
    }


    private async Task<IResult> GetFabrics(IMediator mediator)
    {
        var result = await mediator.Send(new GetFabricsQuery());
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound(result.Error);
    }
    private async Task<IResult> CreateFabric(IMediator mediator, FabricCreateRequest request)
    {
        var result = await mediator.Send(new AddFabricCommand(request));
        return result.IsSuccess
              ? TypedResults.Ok(result.Value)
              : TypedResults.NotFound(result.Error);
    }

    private async Task<IResult> UpdateFabric(IMediator mediator, FabricUpdateRequest request)
    {
        var result = await mediator.Send(new UpdateFabricCommand(request));
        return result.IsSuccess
              ? TypedResults.Ok(result.Value)
              : TypedResults.NotFound(result.Error);
    }
}
