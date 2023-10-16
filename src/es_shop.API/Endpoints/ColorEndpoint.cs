using MediatR;
using EsShop.API.Configurations;
using EsShop.Application.Color.Commands.AddColor;
using EsShop.Application.Color.Commands.UpdateColor;
using EsShop.Application.Color.Queries.GetColors;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Requests;
using EsShop.Shared.Communications.Responses;
using Microsoft.AspNetCore.Mvc;
using EsShop.Application.Color.Queries.GetColor;

namespace EsShop.API.Endpoints;

public class ColorEndpoint : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var color = app.MapGroup("api/color");
        color.MapGet("/", GetColors)
            .AllowAnonymous();

        color.MapGet("/{id}", GetColor)
            .AllowAnonymous();

        color.MapPost("/", CreateColor)
            .Produces<ColorResponse>(200)
            .Produces<Error>(404)
            .AllowAnonymous();

        color.MapPut("/", UpdateColor)
            .Produces<ColorResponse>(200)
            .Produces<Error>(404)
            .AllowAnonymous();
    }


    private async Task<IResult> GetColors(IMediator mediator)
    {
        var result = await mediator.Send(new GetColorsQuery());
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound(result.Error);
    }

    private async Task<IResult> GetColor(IMediator mediator, Guid id)
    {
        var result = await mediator.Send(new GetColorQuery(id));
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound(result.Error);
    }
    private async Task<IResult> CreateColor(IMediator mediator, ColorCreateRequest request)
    {
        var result = await mediator.Send(new AddColorCommand(request));
        return result.IsSuccess
              ? TypedResults.Ok(result.Value)
              : TypedResults.NotFound(result.Error);
    }

    private async Task<IResult> UpdateColor(IMediator mediator, ColorUpdateRequest request)
    {
        var result = await mediator.Send(new UpdateColorCommand(request));
        return result.IsSuccess
              ? TypedResults.Ok(result.Value)
              : TypedResults.NotFound(result.Error);
    }
}
