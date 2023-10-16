
using MediatR;
using EsShop.Domain.Entities;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Fabric.Commands.AddFabric;

internal sealed class AddFabricHandler
                      : IRequestHandler<AddFabricCommand, Result<FabricResponse>>
{
    private readonly IFabricRepository _classRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddFabricHandler(IFabricRepository classRepository, IUnitOfWork unitOfWork)
    {
        _classRepository = classRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<Result<FabricResponse>> Handle(AddFabricCommand request, CancellationToken cancellationToken)
    {
        var newFabric = FabricEntity.Create(request.fabric.type);

        await _classRepository.CreateAsync(newFabric);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new FabricResponse(newFabric.Type, newFabric.Id);
    }
}
