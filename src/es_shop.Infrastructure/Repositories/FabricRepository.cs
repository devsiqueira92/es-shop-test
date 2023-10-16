using Microsoft.EntityFrameworkCore;
using EsShop.Domain.Entities;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Infrastructure.Context;

namespace EsShop.Infrastructure.Repositories;

internal sealed class FabricRepository : IFabricRepository
{
    private readonly EsShopContext _context;
    public FabricRepository(EsShopContext context) => _context = context;

    public async Task CreateAsync(FabricEntity entity, CancellationToken cancellationToken = default) =>
        await _context.Fabrics.AddAsync(entity, cancellationToken);


    public void Update(FabricEntity entity) =>
        _context.Fabrics.Update(entity);

    public async Task<PaginatedResponse<FabricEntity>> GetAllAsync(int page, int pagesize, CancellationToken cancellationToken = default)
    {
        var query = _context.Fabrics
                    .Select(d => new FabricEntity
                    {
                        Type = d.Type,
                        Id = d.Id,
                        IsDeleted = d.IsDeleted,
                    })
                    .OrderBy(status => status.Type)
                    .Where(d => !d.IsDeleted)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

        var items = await query.ToListAsync();
        var count = await _context.Fabrics.CountAsync();

        return PaginatedResponse<FabricEntity>.ToPagedList(items, count, page, pagesize);
    }

    public async Task<FabricEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.Fabrics
                    .Where(cls => !cls.IsDeleted && cls.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }
}
