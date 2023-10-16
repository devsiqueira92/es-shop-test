

using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Requests;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Color.Commands.AddColor;

public sealed record AddColorCommand(ColorCreateRequest color) : IRequest<Result<ColorResponse>>;

