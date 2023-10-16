using System.Data;

namespace EsShop.Domain.RepositoryInterfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        //IDbTransaction BeginTransaction();
    }
}
