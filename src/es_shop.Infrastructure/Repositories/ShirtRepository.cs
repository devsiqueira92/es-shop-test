using Microsoft.EntityFrameworkCore;
using EsShop.Domain.Entities;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Infrastructure.Context;

namespace EsShop.Infrastructure.Repositories;

internal sealed class ShirtRepository : IShirtRepository
{
    private readonly EsShopContext _context;
    public ShirtRepository(EsShopContext context) => _context = context;

    public async Task CreateAsync(ShirtEntity entity, CancellationToken cancellationToken = default) =>
        await _context.Shirts.AddAsync(entity, cancellationToken);


    public void Update(ShirtEntity entity) =>
        _context.Shirts.Update(entity);

    public async Task<PaginatedResponse<ShirtEntity>> GetAllAsync(int page, int pagesize, CancellationToken cancellationToken = default)
    {
        var query = _context.Shirts
                    .AsNoTracking()
                    .Select(d => new ShirtEntity
                    {
                        Name = d.Name,
						Id = d.Id,
                        IsDeleted = d.IsDeleted,
                    })
                    .OrderBy(status => status.Name)
					
					.Where(d => !d.IsDeleted)
					.Skip((page - 1) * pagesize)
                    .Take(pagesize);

        var items = await query.ToListAsync();
        var count = await _context.Shirts.CountAsync();

        return PaginatedResponse<ShirtEntity>.ToPagedList(items, count, page, pagesize);
    }

    public async Task<ShirtEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.Shirts
                    .Where(cls => !cls.IsDeleted && cls.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }
}
