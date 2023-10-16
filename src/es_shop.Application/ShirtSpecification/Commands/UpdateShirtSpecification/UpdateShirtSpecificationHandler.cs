using MediatR;
using EsShop.Domain.Errors;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.ShirtSpecification.Commands.UpdateShirtSpecification;

internal sealed class UpdateShirtSpecificationHandler : IRequestHandler<UpdateShirtSpecificationCommand, Result<ShirtResponse>>
{
	private readonly IShirtSpecificationRepository _shirtRepository;
	private readonly IUnitOfWork _unitOfWork;

	public UpdateShirtSpecificationHandler(IShirtSpecificationRepository shirtRepository, IUnitOfWork unitOfWork)
	{
		_shirtRepository = shirtRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result<ShirtResponse>> Handle(UpdateShirtSpecificationCommand request, CancellationToken cancellationToken)
	{
		var entityToUpdate = await _shirtRepository.GetAsync(request.shirt.shirtSpecificationId);

		if (entityToUpdate is null)
			return Result.Failure<ShirtResponse>(DomainErrors.Generic.NotFound);

		//entityToUpdate.Update(request.shirt.name, request.shirt.colorId, request.shirt.fabricId);

		//_shirtRepository.Update(entityToUpdate);
		//await _unitOfWork.SaveChangesAsync(cancellationToken);

		return new ShirtResponse("", Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
	}
}
