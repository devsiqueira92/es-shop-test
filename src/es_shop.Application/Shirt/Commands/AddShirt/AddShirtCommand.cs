using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Requests;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Shirt.Commands.AddShirt;

public sealed record AddShirtCommand(ShirtCreateRequest shirt) : IRequest<Result<ShirtResponse>>;