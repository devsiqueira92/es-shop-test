using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using EsShop.Domain.RepositoryInterfaces;
using EsShop.Infrastructure.Context;

namespace EsShop.Infrastructure;

internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly EsShopContext _dbContext;

    public UnitOfWork(EsShopContext dbContext) => _dbContext = dbContext;

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
