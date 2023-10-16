using MediatR;
using EsShop.Domain.Errors;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Shirt.Commands.UpdateShirt;

internal sealed class UpdateShirtHandler : IRequestHandler<UpdateShirtCommand, Result<ShirtResponse>>
{
    private readonly IShirtRepository _shirtRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateShirtHandler(IShirtRepository shirtRepository, IUnitOfWork unitOfWork)
    {
        _shirtRepository = shirtRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ShirtResponse>> Handle(UpdateShirtCommand request, CancellationToken cancellationToken)
    {
        var entityToUpdate = await _shirtRepository.GetAsync(request.shirt.id);

        if (entityToUpdate is null)
            return Result.Failure<ShirtResponse>(DomainErrors.Generic.NotFound);

        entityToUpdate.Update(request.shirt.name, request.shirt.colorId, request.shirt.fabricId);

        _shirtRepository.Update(entityToUpdate);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new ShirtResponse(entityToUpdate.Name, entityToUpdate.Id, entityToUpdate.Id, entityToUpdate.Id);
    }
}
