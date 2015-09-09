using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;

namespace RepositoryPattern.Core.EntityFramework
{
    public class EntityDbContext : DbContext, IDbContext
    {
        public EntityDbContext(bool createChildAssociations = true, bool lazyLoadChildAssociations = true)
            : this("name=EntityDbContext", createChildAssociations, lazyLoadChildAssociations)
        {
        }

        public EntityDbContext(string connectionName, bool createChildAssociations = true, bool lazyLoadChildAssociations = true)
            : base(connectionName)
        {
            Configuration.ProxyCreationEnabled = createChildAssociations;
            Configuration.LazyLoadingEnabled = lazyLoadChildAssociations;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null
                               && type.BaseType.IsGenericType
                               && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}