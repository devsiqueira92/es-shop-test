using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Shirt.Queries.GetShirt;
public record GetShirtQuery(Guid id) : IRequest<Result<ShirtResponse>>;
