using EsShop.Domain.Entities;
using EsShop.Domain.Shared;

namespace EsShop.Domain.RepositoryInterfaces;

public interface IFabricRepository
{
    Task CreateAsync(FabricEntity entity, CancellationToken cancellationToken = default);
    void Update(FabricEntity entity);
    Task<PaginatedResponse<FabricEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<FabricEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
}