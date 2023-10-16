using MediatR;
using EsShop.Domain.Entities;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Shirt.Commands.AddShirt;

internal sealed class AddShirtHandler : IRequestHandler<AddShirtCommand, Result<ShirtResponse>>
{
    private readonly IShirtRepository _bloodTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddShirtHandler(IShirtRepository bloodTypeRepository, IUnitOfWork unitOfWork)
    {
        _bloodTypeRepository = bloodTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<ShirtResponse>> Handle(AddShirtCommand request, CancellationToken cancellationToken)
    {
        var newShirt = ShirtEntity.Create(request.shirt.name, request.shirt.colorId, request.shirt.fabricId);

        await _bloodTypeRepository.CreateAsync(newShirt);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new ShirtResponse(newShirt.Name, newShirt.Id, newShirt.Id, newShirt.Id);
       
    }
}
