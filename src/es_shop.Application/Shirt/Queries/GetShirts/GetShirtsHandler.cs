using MediatR;
using EsShop.Domain.Errors;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Shirt.Queries.GetShirts;

internal sealed class GetShirtsHandler : IRequestHandler<GetShirtsQuery, Result<IList<ShirtResponse>>>
{
    private readonly IShirtRepository _colorRepository;
    public GetShirtsHandler(IShirtRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }
    public async Task<Result<IList<ShirtResponse>>> Handle(GetShirtsQuery request, CancellationToken cancellationToken)
    {
        var shirts = await _colorRepository.GetAllAsync(request.page, request.pageSize);

        if (shirts is null)
            return Result.Failure<IList<ShirtResponse>>(DomainErrors.Generic.NotFound);

        var list = shirts.Select(cls => new ShirtResponse(cls.Name, cls.Id, cls.Id, cls.Id)).ToList();
        return list;
    }
}
