using Microsoft.EntityFrameworkCore;
using EsShop.Domain.Entities;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Infrastructure.Context;

namespace EsShop.Infrastructure.Repositories;

internal sealed class ShirtSpecificationImageRepository : IShirtSpecificationImageRepository
{
    private readonly EsShopContext _context;
    public ShirtSpecificationImageRepository(EsShopContext context) => _context = context;

    public async Task CreateAsync(ShirtSpecificationImageEntity entity, CancellationToken cancellationToken = default) =>
        await _context.ShirtSpecificationImage.AddAsync(entity, cancellationToken);


    public void Update(ShirtSpecificationImageEntity entity) =>
        _context.ShirtSpecificationImage.Update(entity);

    public async Task<PaginatedResponse<ShirtSpecificationImageEntity>> GetAllFromSpecificationAsync(Guid id, int page, int pagesize, CancellationToken cancellationToken = default)
    {
        var query = _context.ShirtSpecificationImage
					.AsNoTracking()
                    .Select(d => new ShirtSpecificationImageEntity
                    {
						ShirtSpecificationId = d.ShirtSpecificationId,
                        ImageId = d.ImageId,
                        Id = d.Id,
                        IsDeleted = d.IsDeleted,
                    })
					
					.Where(d => !d.IsDeleted && d.ShirtSpecificationId == id)
					.Skip((page - 1) * pagesize)
                    .Take(pagesize);

        var items = await query.ToListAsync();
        var count = await _context.ShirtSpecifications.CountAsync();

        return PaginatedResponse<ShirtSpecificationImageEntity>.ToPagedList(items, count, page, pagesize);
    }



	public async Task BulkCreateAsync(List<ShirtSpecificationImageEntity> entity, CancellationToken cancellationToken = default)
	{
		await _context.ShirtSpecificationImage.AddRangeAsync(entity);
	}
}
