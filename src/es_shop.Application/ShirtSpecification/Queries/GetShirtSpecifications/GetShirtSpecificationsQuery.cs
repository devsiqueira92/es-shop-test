using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.ShirtSpecification.Queries.GetShirtSpecifications;
public record GetShirtSpecificationsQuery(int pageSize = 10, int page = 1) : IRequest<Result<IList<ShirtResponse>>>;
