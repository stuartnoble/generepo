using System.Data.Entity.ModelConfiguration;
using RepositoryPattern.DataAbstractionLayer.Entities;

namespace RepositoryPattern.DataAbstractionLayer.EntityFramework.Mappings
{
    public class ClassEntityTypeConvention : EntityTypeConfiguration<Class>
    {
        public ClassEntityTypeConvention()
        {
            HasKey(c => new { c.Course.Id, c.StartDateTime });

            Property(c => c.StartDateTime.ToDateTimeUnspecified())
                .IsRequired();

            Property(c => c.EndDateTime.ToDateTimeUnspecified())
                .IsRequired();

            HasRequired(x => x.Course);

            ToTable("Classes");
        }
    }
}