using System;

namespace RepositoryPattern.Core
{
    public abstract class AuditedEntity<T> : KeyedEntity<T>
    {
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}