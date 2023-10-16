using MediatR;
using EsShop.Domain.Errors;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.ShirtSpecification.Queries.GetShirtSpecifications;

internal sealed class GetShirtSpecificationsHandler : IRequestHandler<GetShirtSpecificationsQuery, Result<IList<ShirtResponse>>>
{
	private readonly IShirtSpecificationRepository _colorRepository;
	public GetShirtSpecificationsHandler(IShirtSpecificationRepository colorRepository)
	{
		_colorRepository = colorRepository;
	}
	public async Task<Result<IList<ShirtResponse>>> Handle(GetShirtSpecificationsQuery request, CancellationToken cancellationToken)
	{
		var shirts = await _colorRepository.GetGroupedAsync(request.page, request.pageSize);

		if (shirts is null)
			return Result.Failure<IList<ShirtResponse>>(DomainErrors.Generic.NotFound);

		var list = shirts;
		return new List<ShirtResponse>();
	}
}
