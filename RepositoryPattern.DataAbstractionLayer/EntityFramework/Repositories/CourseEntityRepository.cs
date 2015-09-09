using System;
using RepositoryPattern.Core.EntityFramework;
using RepositoryPattern.DataAbstractionLayer.Entities;

namespace RepositoryPattern.DataAbstractionLayer.EntityFramework.Repositories
{
    public class CourseEntityRepository : KeyedEntityRepository<Course, int>
    {
        public CourseEntityRepository(IDbContext entityContext) : base(entityContext) {}
    }
}
