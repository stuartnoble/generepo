using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern.DataAbstractionLayer.Entities;

namespace RepositoryPattern.DataAbstractionLayer.EntityFramework.Mappings
{
    public class CourseEntityTypeConvention : EntityTypeConfiguration<Course>
    {
        public CourseEntityTypeConvention()
        {
            HasKey(c => c.Id);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(255);

            ToTable("Courses");
        }
    }
}
