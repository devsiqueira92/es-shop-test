using EsShop.Domain.Entities;
using EsShop.Domain.Shared;

namespace EsShop.Domain.RepositoryInterfaces;

public interface IShirtSpecificationRepository
{
    Task CreateAsync(ShirtSpecificationEntity entity, CancellationToken cancellationToken = default);
    void Update(ShirtSpecificationEntity entity);
    Task<PaginatedResponse<ShirtSpecificationEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
	Task<object> GetGroupedAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<List<ShirtSpecificationEntity>> GetAsync(Guid id, CancellationToken cancellationToken = default);
}