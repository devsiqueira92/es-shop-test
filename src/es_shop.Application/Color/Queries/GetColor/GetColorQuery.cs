using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Color.Queries.GetColor;
public record GetColorQuery(Guid id) : IRequest<Result<ColorResponse>>;
