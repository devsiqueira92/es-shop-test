using MediatR;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.ShirtSpecification.Queries.GetShirtSpecification;
public record GetShirtSpecificationImagesQuery(Guid id, int pageSize = 10, int page = 1) : IRequest<Result<List<ShirtSpecificationImageResponse>>>;
