using System;

namespace RepositoryPattern.Core
{
    public abstract class KeyedEntity<T>
    {
        public T Id { get; set; }
    }
}
