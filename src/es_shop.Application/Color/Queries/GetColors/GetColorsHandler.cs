using MediatR;
using EsShop.Domain.Errors;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Color.Queries.GetColors;

internal sealed class GetColorsHandler : IRequestHandler<GetColorsQuery, Result<IList<ColorResponse>>>
{
    private readonly IColorRepository _colorRepository;
    public GetColorsHandler(IColorRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }
    public async Task<Result<IList<ColorResponse>>> Handle(GetColorsQuery request, CancellationToken cancellationToken)
    {
        var colors = await _colorRepository.GetAllAsync(request.page, request.pageSize);

        if (colors is null)
            return Result.Failure<IList<ColorResponse>>(DomainErrors.Generic.NotFound);

        var list = colors.Select(cls => new ColorResponse(cls.Color, cls.Hex, cls.Id)).ToList();
        return list;
    }
}
