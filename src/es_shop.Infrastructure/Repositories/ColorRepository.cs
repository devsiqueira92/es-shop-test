using Microsoft.EntityFrameworkCore;
using EsShop.Domain.Entities;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Domain.Shared;
using EsShop.Infrastructure.Context;

namespace EsShop.Infrastructure.Repositories;

internal sealed class ColorRepository : IColorRepository
{
    private readonly EsShopContext _context;
    public ColorRepository(EsShopContext context) => _context = context;

    public async Task CreateAsync(ColorEntity entity, CancellationToken cancellationToken = default) =>
        await _context.Colors.AddAsync(entity, cancellationToken);


    public void Update(ColorEntity entity) =>
        _context.Colors.Update(entity);

    public async Task<PaginatedResponse<ColorEntity>> GetAllAsync(int page, int pagesize, CancellationToken cancellationToken = default)
    {
        var query = _context.Colors
                    .Select(d => new ColorEntity
                    {
                        Color = d.Color,
                        Hex = d.Hex,
                        Id = d.Id,
                        IsDeleted = d.IsDeleted,
                    })
                    .OrderBy(status => status.Color)
                    .Where(d => !d.IsDeleted)
                    .Skip((page - 1) * pagesize)
                    .Take(pagesize);

        var items = await query.ToListAsync();
        var count = await _context.Colors.CountAsync();

        return PaginatedResponse<ColorEntity>.ToPagedList(items, count, page, pagesize);
    }



    public async Task<ColorEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var query = _context.Colors
                    .Where(cls => !cls.IsDeleted && cls.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }
}
