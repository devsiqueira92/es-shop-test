using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Requests;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Shirt.Commands.UpdateShirt;

public sealed record UpdateShirtCommand(ShirtUpdateRequest shirt) : IRequest<Result<ShirtResponse>>;