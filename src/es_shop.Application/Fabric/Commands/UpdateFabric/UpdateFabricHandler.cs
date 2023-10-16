using MediatR;
using EsShop.Domain.Errors;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Fabric.Commands.UpdateFabric;

internal sealed class UpdateFabricHandler : IRequestHandler<UpdateFabricCommand, Result<FabricResponse>>
{
    private readonly IFabricRepository _bloodTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFabricHandler(IFabricRepository bloodTypeRepository, IUnitOfWork unitOfWork)
    {
        _bloodTypeRepository = bloodTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<FabricResponse>> Handle(UpdateFabricCommand request, CancellationToken cancellationToken)
    {
 
        var entityToUpdate = await _bloodTypeRepository.GetAsync(request.fabric.id);
        if (entityToUpdate is null)
            return Result.Failure<FabricResponse>(DomainErrors.Generic.NotFound);

        entityToUpdate.Update(request.fabric.type);

        _bloodTypeRepository.Update(entityToUpdate);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new FabricResponse(entityToUpdate.Type, entityToUpdate.Id);

      
    }
}
