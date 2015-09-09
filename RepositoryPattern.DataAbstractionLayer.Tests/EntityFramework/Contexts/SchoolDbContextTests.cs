using NUnit.Framework;
using RepositoryPattern.DataAbstractionLayer.EntityFramework.Contexts;

namespace RepositoryPattern.DataAbstractionLayer.Tests.EntityFramework.Contexts
{
    [TestFixture(Category = "Integration")]
    public class SchoolDbContextTests
    {
        public void Ctor_ReturnsInstance()
        {
            Assert.DoesNotThrow(() => new SchoolDbContext());
        }
    }
}
