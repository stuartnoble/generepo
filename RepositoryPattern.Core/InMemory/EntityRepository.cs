using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.Core.InMemory
{
    public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, new()
    {
        private readonly IQueryable<TEntity> _entities;
        private readonly object _lock = new object();

        protected EntityRepository(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException(nameof(entities));
            
            _entities = entities.AsQueryable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }

        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
