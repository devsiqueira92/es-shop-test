using MediatR;
using EsShop.Domain.Errors;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Color.Queries.GetColor;

internal sealed class GetColorHandler : IRequestHandler<GetColorQuery, Result<ColorResponse>>
{
    private readonly IColorRepository _colorRepository;
    public GetColorHandler(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }
    public async Task<Result<ColorResponse>> Handle(GetColorQuery request, CancellationToken cancellationToken)
    {
        var colors = await _colorRepository.GetAsync(request.id);

        if (colors is null)
            return Result.Failure<ColorResponse>(DomainErrors.Generic.NotFound);

        return new ColorResponse(colors.Color, colors.Hex, colors.Id);
    }
}
