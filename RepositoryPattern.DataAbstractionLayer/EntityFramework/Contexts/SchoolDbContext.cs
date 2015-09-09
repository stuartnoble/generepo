using System.Data.Entity;
using RepositoryPattern.Core.EntityFramework;
using RepositoryPattern.DataAbstractionLayer.Entities;

namespace RepositoryPattern.DataAbstractionLayer.EntityFramework.Contexts
{
    public class SchoolDbContext : EntityDbContext
    {
        public SchoolDbContext() : base("name=SchoolDbContext") {}

        public IDbSet<Student> Students { get; set; }
        public IDbSet<Course> Courses { get; set; }
        public IDbSet<Class> Classes { get; set; } 
    }
}
