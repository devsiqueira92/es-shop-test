using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.ShirtSpecification.Queries.GetShirtSpecification;
public record GetShirtSpecificationQuery(Guid id) : IRequest<Result<List<ShirtSpecificationResponse>>>;
