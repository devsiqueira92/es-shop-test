using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Requests;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Color.Commands.UpdateColor;
public sealed record UpdateColorCommand(ColorUpdateRequest color) : IRequest<Result<ColorResponse>>;
