using MediatR;
using EsShop.Domain.Entities;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.ShirtSpecification.Commands.AddShirtSpecification;

internal sealed class AddShirtSpecificationHandler : IRequestHandler<AddShirtSpecificationCommand, Result<ShirtSpecificationResponse>>
{
	private readonly IShirtSpecificationRepository _shirtSpecification;
	private readonly IUnitOfWork _unitOfWork;

	public AddShirtSpecificationHandler(IShirtSpecificationRepository shirtSpecification, IUnitOfWork unitOfWork)
	{
		_shirtSpecification = shirtSpecification;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<ShirtSpecificationResponse>> Handle(AddShirtSpecificationCommand request, CancellationToken cancellationToken)
	{
		var newShirt = ShirtSpecificationEntity.Create(request.specification.shirtId, request.specification.colorId, request.specification.fabricId);

		await _shirtSpecification.CreateAsync(newShirt);
		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return new ShirtSpecificationResponse(newShirt.ShirtEntity.Id, newShirt.Id, newShirt.Id, newShirt.Id);

	}
}
