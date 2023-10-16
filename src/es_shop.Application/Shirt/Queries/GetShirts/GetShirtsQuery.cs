using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Shirt.Queries.GetShirts;
public record GetShirtsQuery(int pageSize = 10, int page = 1) : IRequest<Result<IList<ShirtResponse>>>;
