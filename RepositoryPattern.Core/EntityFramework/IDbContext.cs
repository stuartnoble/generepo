using System.Data.Entity;

namespace RepositoryPattern.Core.EntityFramework
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
