using MediatR;
using EsShop.Domain.Errors;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Shared.Communications.Responses;

namespace EsShop.Application.Fabric.Queries.GetFabrics;

internal sealed class GetFabricsHandler : IRequestHandler<GetFabricsQuery, Result<IList<FabricResponse>>>
{
    private readonly IFabricRepository _colorRepository;
    public GetFabricsHandler(IFabricRepository colorRepository)
    {
        _colorRepository = colorRepository;
    }
    public async Task<Result<IList<FabricResponse>>> Handle(GetFabricsQuery request, CancellationToken cancellationToken)
    {
        var fabrics = await _colorRepository.GetAllAsync(request.page, request.pageSize);

        if (fabrics is null)
            return Result.Failure<IList<FabricResponse>>(DomainErrors.Generic.NotFound);

        var list = fabrics.Select(cls => new FabricResponse(cls.Type, cls.Id)).ToList();
        return list;
        
    }
}
