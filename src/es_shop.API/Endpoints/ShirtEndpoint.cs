using MediatR;
using EsShop.API.Configurations;
using EsShop.Application.Shirt.Commands.AddShirt;
using EsShop.Application.Shirt.Commands.UpdateShirt;
using EsShop.Application.Shirt.Queries.GetShirts;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Requests;
using EsShop.Shared.Communications.Responses;
using EsShop.Application.Shirt.Queries.GetShirt;

namespace EsShop.API.Endpoints;

public class ShirtEndpoint : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var shirt = app.MapGroup("api/shirt");
        shirt.MapGet("/", GetShirts)
            .AllowAnonymous();

        shirt.MapGet("/{id}", GetShirt)
           .AllowAnonymous();

        shirt.MapPost("/", CreateShirt)
            .Produces<ShirtResponse>(200)
            .Produces<Error>(404)
            .AllowAnonymous();

        shirt.MapPut("/", UpdateShirt)
            .Produces<ShirtResponse>(200)
            .Produces<Error>(404)
            .AllowAnonymous();

        //.AddEndpointFilter<ValidationFilter<CreateUserRequest>>()
        //.Produces<UserResponse>();

        //user.MapGet("/{id}", GetUserById)
        //.WithName("GetUserById")
        //.Produces<UserResponse>();
    }


    private async Task<IResult> GetShirts(IMediator mediator)
    {
        var result = await mediator.Send(new GetShirtsQuery());
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound(result.Error);
    }
    private async Task<IResult> GetShirt(IMediator mediator, Guid id)
    {
        var result = await mediator.Send(new GetShirtQuery(id));
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound(result.Error);
    }

    private async Task<IResult> CreateShirt(IMediator mediator, ShirtCreateRequest request)
    {
        var result = await mediator.Send(new AddShirtCommand(request));
        return result.IsSuccess
              ? TypedResults.Ok(result.Value)
              : TypedResults.NotFound(result.Error);
    }

    private async Task<IResult> UpdateShirt(IMediator mediator, ShirtUpdateRequest request)
    {
        var result = await mediator.Send(new UpdateShirtCommand(request));
        return result.IsSuccess
              ? TypedResults.Ok(result.Value)
              : TypedResults.NotFound(result.Error);
    }
}
