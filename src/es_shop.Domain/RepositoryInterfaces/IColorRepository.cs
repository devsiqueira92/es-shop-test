using EsShop.Domain.Entities;
using EsShop.Domain.Shared;

namespace EsShop.Domain.RepositoryInterfaces;

public interface IColorRepository
{
    Task CreateAsync(ColorEntity entity, CancellationToken cancellationToken = default);
    void Update(ColorEntity entity);
    Task<PaginatedResponse<ColorEntity>> GetAllAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ColorEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
}