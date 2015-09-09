using RepositoryPattern.Core.EntityFramework;
using RepositoryPattern.DataAbstractionLayer.Entities;

namespace RepositoryPattern.DataAbstractionLayer.EntityFramework.Repositories
{
    public class StudentEntityRepository : KeyedEntityRepository<Student, int>
    {
        public StudentEntityRepository(IDbContext entityContext) : base(entityContext) {}
    }
}
