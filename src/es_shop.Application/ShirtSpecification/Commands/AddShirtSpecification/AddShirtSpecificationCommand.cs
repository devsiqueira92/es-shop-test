using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Requests;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.ShirtSpecification.Commands.AddShirtSpecification;

public sealed record AddShirtSpecificationCommand(ShirtSpecificationCreateRequest specification) : IRequest<Result<ShirtSpecificationResponse>>;