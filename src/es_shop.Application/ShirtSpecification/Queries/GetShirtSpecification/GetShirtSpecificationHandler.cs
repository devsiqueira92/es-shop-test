using MediatR;
using EsShop.Domain.Errors;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;
using System.Linq;

namespace EsShop.Application.ShirtSpecification.Queries.GetShirtSpecification;

internal sealed class GetShirtSpecificationHandler : IRequestHandler<GetShirtSpecificationQuery, Result<List<ShirtSpecificationResponse>>>
{
	private readonly IShirtSpecificationRepository _colorRepository;
	public GetShirtSpecificationHandler(IShirtSpecificationRepository colorRepository)
	{
		_colorRepository = colorRepository;
	}
	public async Task<Result<List<ShirtSpecificationResponse>>> Handle(GetShirtSpecificationQuery request, CancellationToken cancellationToken)
	{
		var shirts = await _colorRepository.GetAsync(request.id);

		if (shirts is null)
			return Result.Failure<List<ShirtSpecificationResponse>>(DomainErrors.Generic.NotFound);

		var list = shirts.Select(shirt => new ShirtSpecificationResponse(shirt.ShirtId, shirt.ColorId, shirt.FabricId, shirt.Id)).ToList();

		return list;
	}
}
