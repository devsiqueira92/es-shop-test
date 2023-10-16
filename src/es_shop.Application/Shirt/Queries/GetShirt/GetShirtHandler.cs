using MediatR;
using EsShop.Domain.Errors;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Shirt.Queries.GetShirt;

internal sealed class GetShirtHandler : IRequestHandler<GetShirtQuery, Result<ShirtResponse>>
{
    private readonly IShirtRepository _colorRepository;
    public GetShirtHandler(IShirtRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }
    public async Task<Result<ShirtResponse>> Handle(GetShirtQuery request, CancellationToken cancellationToken)
    {
        var shirts = await _colorRepository.GetAsync(request.id);

        if (shirts is null)
            return Result.Failure<ShirtResponse>(DomainErrors.Generic.NotFound);

        return new ShirtResponse(shirts.Name, shirts.Id, shirts.Id, shirts.Id);
    }
}
