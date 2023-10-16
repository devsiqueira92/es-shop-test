using EsShop.Domain.Entities;
using EsShop.Domain.Shared;

namespace EsShop.Domain.RepositoryInterfaces;

public interface IShirtSpecificationImageRepository
{
	Task CreateAsync(ShirtSpecificationImageEntity entity, CancellationToken cancellationToken = default);
	Task BulkCreateAsync(List<ShirtSpecificationImageEntity> entity, CancellationToken cancellationToken = default);
	void Update(ShirtSpecificationImageEntity entity);
    Task<PaginatedResponse<ShirtSpecificationImageEntity>> GetAllFromSpecificationAsync(Guid id, int page, int pageSize, CancellationToken cancellationToken = default);
}