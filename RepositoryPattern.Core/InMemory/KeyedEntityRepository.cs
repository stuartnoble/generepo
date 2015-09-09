using System.Collections.Generic;
using System.Linq;

namespace RepositoryPattern.Core.InMemory
{
    public abstract class KeyedEntityRepository<TEntity, TKey> : EntityRepository<TEntity>, IKeyedEntityRepository<TEntity, TKey>
        where TEntity : KeyedEntity<TKey>, new()
    {
        private readonly IDictionary<TKey, TEntity> _entityDictionary = new Dictionary<TKey, TEntity>();
        private readonly object _lock = new object();

        public KeyedEntityRepository(IEnumerable<TEntity> entities) : base(entities)
        {
            foreach (var entity in entities.ToList())
            {
                _entityDictionary.Add(entity.Id, entity);
            }
        }

        public TEntity GetById(TKey id)
        {
            lock (_lock)
            {
                TEntity entity = null;
                _entityDictionary.TryGetValue(id, out entity);

                return entity;
            }
        }
    }
}