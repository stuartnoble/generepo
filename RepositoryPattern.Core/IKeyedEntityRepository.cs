namespace RepositoryPattern.Core
{
    public interface IKeyedEntityRepository<TEntity, in TKey> : IEntityRepository<TEntity>
        where TEntity : KeyedEntity<TKey>
    {
        TEntity GetById(TKey id);
    }
}