using MediatR;
using EsShop.Domain.Errors;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.ShirtSpecification.Queries.GetShirtSpecification;

internal sealed class GetShirtSpecificationImagesHandler : IRequestHandler<GetShirtSpecificationImagesQuery, Result<List<ShirtSpecificationImageResponse>>>
{
	private readonly IShirtSpecificationImageRepository _specificationImageRepository;
	public GetShirtSpecificationImagesHandler(IShirtSpecificationImageRepository specificationImageRepository)
	{
		_specificationImageRepository = specificationImageRepository;
	}
	public async Task<Result<List<ShirtSpecificationImageResponse>>> Handle(GetShirtSpecificationImagesQuery request, CancellationToken cancellationToken)
	{
		var shirts = await _specificationImageRepository.GetAllFromSpecificationAsync(request.id, request.page, request.pageSize);

		if (shirts is null)
			return Result.Failure<List<ShirtSpecificationImageResponse>>(DomainErrors.Generic.NotFound);

		var list = shirts.Select(shirt => new ShirtSpecificationImageResponse(shirt.ShirtSpecificationId, shirt.ImageId)).ToList();

		return list;
	}
}
