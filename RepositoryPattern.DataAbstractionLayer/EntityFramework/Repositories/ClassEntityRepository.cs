using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern.Core.EntityFramework;
using RepositoryPattern.DataAbstractionLayer.Entities;

namespace RepositoryPattern.DataAbstractionLayer.EntityFramework.Repositories
{
    public class ClassEntityRepository : KeyedEntityRepository<Class, Tuple<int, DateTime>>
    {
        public ClassEntityRepository(IDbContext entityContext) : base(entityContext) { }
    }
}
