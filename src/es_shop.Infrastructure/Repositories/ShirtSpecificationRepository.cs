using Microsoft.EntityFrameworkCore;
using EsShop.Domain.Entities;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Infrastructure.Context;

namespace EsShop.Infrastructure.Repositories;

internal sealed class ShirtSpecificationRepository : IShirtSpecificationRepository
{
    private readonly EsShopContext _context;
    public ShirtSpecificationRepository(EsShopContext context) => _context = context;

    public async Task CreateAsync(ShirtSpecificationEntity entity, CancellationToken cancellationToken = default) =>
        await _context.ShirtSpecifications.AddAsync(entity, cancellationToken);


    public void Update(ShirtSpecificationEntity entity) =>
        _context.ShirtSpecifications.Update(entity);

    public async Task<PaginatedResponse<ShirtSpecificationEntity>> GetAllAsync(int page, int pagesize, CancellationToken cancellationToken = default)
    {
        var query = _context.ShirtSpecifications
                    .AsNoTracking()
                    .Select(d => new ShirtSpecificationEntity
                    {
                        ShirtEntity = d.ShirtEntity,
                        ColorId = d.ColorId,
                        FabricId = d.FabricId,
                        Id = d.Id,
                        IsDeleted = d.IsDeleted,
                    })
                    .OrderBy(status => status.ShirtEntity.Name)
					
					.Where(d => !d.IsDeleted)
                    //.GroupBy(d => d.ColorId).Select(x => new { ColorId = x.Key, Color = x.Count() })
					.Skip((page - 1) * pagesize)
                    .Take(pagesize);

        var items = await query.ToListAsync();
        var count = await _context.ShirtSpecifications.CountAsync();

        return PaginatedResponse<ShirtSpecificationEntity>.ToPagedList(items, count, page, pagesize);
    }

    //public async Task<object> GetGroupedAsync(int page, int pagesize, CancellationToken cancellationToken = default)
    //{
    //    var itemCountQuery = await _context.ShirtSpecifications.ToListAsync();
    //    var totalFabrics = itemCountQuery.GroupBy(g => g.FabricId).Select(g => g.Count());
    //    var totalColors = itemCountQuery.GroupBy(g => g.ColorId).Select(g => g.Count());
    //    return itemCountQuery;
    //}

    public async Task<object> GetGroupedAsync(int page, int pagesize, CancellationToken cancellationToken = default)
	{
		var itemCountQuery = await _context.ShirtSpecifications.ToListAsync();
		return itemCountQuery;
	}

	public async Task<List<ShirtSpecificationEntity>> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.ShirtSpecifications
                    .Where(cls => !cls.IsDeleted && cls.ShirtId == id);

        return await query.ToListAsync(cancellationToken);
    }
}
