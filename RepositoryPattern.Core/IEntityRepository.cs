using System.Collections.Generic;

namespace RepositoryPattern.Core
{
    public interface IEntityRepository<TEntity>
        where TEntity: class
    {
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
