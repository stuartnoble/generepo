namespace RepositoryPattern.Core.EntityFramework
{
    public abstract class KeyedEntityRepository<TEntity, TKey> : EntityRepository<TEntity>, IKeyedEntityRepository<TEntity, TKey>
        where TEntity : KeyedEntity<TKey>, new()
    {
        protected KeyedEntityRepository(IDbContext entityContext) : base(entityContext) {}

        public TEntity GetById(TKey id)
        {
            return Entities.Find(id);
        }
    }
}