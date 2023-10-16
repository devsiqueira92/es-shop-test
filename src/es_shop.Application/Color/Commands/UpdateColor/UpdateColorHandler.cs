using MediatR;
using EsShop.Domain.Errors;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Color.Commands.UpdateColor;

internal sealed class UpdateColorHandler
                      : IRequestHandler<UpdateColorCommand, Result<ColorResponse>>
{
    private readonly IColorRepository _colorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateColorHandler(IColorRepository colorRepository, IUnitOfWork unitOfWork)
    {
        _colorRepository = colorRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<ColorResponse>> Handle(UpdateColorCommand request, CancellationToken cancellationToken)
    {
        var entityToUpdate = await _colorRepository.GetAsync(request.color.id);
        if (entityToUpdate is null)
            return Result.Failure<ColorResponse>(DomainErrors.Generic.NotFound);


        entityToUpdate.Update(request.color.colorName, request.color.hex);

        _colorRepository.Update(entityToUpdate);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new ColorResponse(entityToUpdate.Color, entityToUpdate.Hex, entityToUpdate.Id);
      
    }
}
