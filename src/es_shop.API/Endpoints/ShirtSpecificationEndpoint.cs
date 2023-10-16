using MediatR;
using EsShop.API.Configurations;
using EsShop.Application.Shirt.Commands.AddShirt;
using EsShop.Application.Shirt.Commands.UpdateShirt;
using EsShop.Application.Shirt.Queries.GetShirts;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Requests;
using EsShop.Shared.Communications.Responses;
using EsShop.Application.Shirt.Queries.GetShirt;
using EsShop.Application.ShirtSpecification.Queries.GetShirtSpecifications;
using EsShop.Application.ShirtSpecification.Queries.GetShirtSpecification;
using EsShop.Application.ShirtSpecification.Commands.AddShirtSpecification;
using EsShop.Application.ShirtSpecification.Commands.UpdateShirtSpecification;
using EsShop.Application.ShirtSpecification.Commands.UploadImage;
using Microsoft.AspNetCore.Mvc;

namespace EsShop.API.Endpoints;

public class ShirtSpecificationEndpoint : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var shirt = app.MapGroup("api/shirt-specification");
        shirt.MapGet("/", GetShirts)
            .AllowAnonymous();

        shirt.MapGet("/{id}", GetShirt)
           .AllowAnonymous();

		shirt.MapPost("/", CreateShirt)
			.Produces<ShirtSpecificationResponse>(200)
			.Produces<Error>(404)
			.AllowAnonymous();

		shirt.MapPost("/upload-image", UploadImage)
		  .Produces<ShirtSpecificationResponse>(200)
		  .Produces<Error>(404)
		  .AllowAnonymous();

		shirt.MapPut("/", UpdateShirt)
            .Produces<ShirtSpecificationResponse>(200)
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
        var result = await mediator.Send(new GetShirtSpecificationsQuery());
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound(result.Error);
    }
    private async Task<IResult> GetShirt(IMediator mediator, Guid id)
    {
        var result = await mediator.Send(new GetShirtSpecificationQuery(id));
        return result.IsSuccess ? TypedResults.Ok(result.Value) : TypedResults.NotFound(result.Error);
    }

	private async Task<IResult> CreateShirt(IMediator mediator, ShirtSpecificationCreateRequest request)
	{
		var result = await mediator.Send(new AddShirtSpecificationCommand(request));
		return result.IsSuccess
			  ? TypedResults.Ok(result.Value)
			  : TypedResults.NotFound(result.Error);
	}


	private async Task<IResult> UpdateShirt(IMediator mediator, UploadImageRequest request)
    {
        var result = await mediator.Send(new UpdateShirtSpecificationCommand(request));
        return result.IsSuccess
              ? TypedResults.Ok(result.Value)
              : TypedResults.NotFound(result.Error);
    }


	private async Task<IResult> UploadImage(IMediator mediator, IFormFileCollection files, Guid id)
	{
		var result = await mediator.Send(new UploadImageCommand(files, id));
		return result.IsSuccess
			  ? TypedResults.Ok(result.Value)
			  : TypedResults.NotFound(result.Error);
	}
}
