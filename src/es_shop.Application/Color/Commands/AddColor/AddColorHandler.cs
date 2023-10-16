
using MediatR;
using EsShop.Domain.Entities;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Color.Commands.AddColor;

internal sealed class AddColorHandler
                      : IRequestHandler<AddColorCommand, Result<ColorResponse>>
{
    private readonly IColorRepository _colorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddColorHandler(IColorRepository colorRepository, IUnitOfWork unitOfWork)
    {
        _colorRepository = colorRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<Result<ColorResponse>> Handle(AddColorCommand request, CancellationToken cancellationToken)
    {
        var newColor = ColorEntity.Create(request.color.colorName, request.color.hex);

        await _colorRepository.CreateAsync(newColor);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new ColorResponse(newColor.Color, newColor.Hex, newColor.Id);
    }
}
