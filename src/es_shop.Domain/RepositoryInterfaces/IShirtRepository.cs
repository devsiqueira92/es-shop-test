using EsShop.Domain.Entities;
using EsShop.Domain.Shared;

namespace EsShop.Domain.RepositoryInterfaces;

public interface IShirtRepository
{
    Task CreateAsync(ShirtEntity entity, CancellationToken cancellationToken = default);
    void Update(ShirtEntity entity);
    Task<PaginatedResponse<ShirtEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ShirtEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
}