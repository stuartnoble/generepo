using System.Data.Entity.ModelConfiguration;
using RepositoryPattern.DataAbstractionLayer.Entities;

namespace RepositoryPattern.DataAbstractionLayer.EntityFramework.Mappings
{
    public class StudentEntityTypeConvention : EntityTypeConfiguration<Student>
    {
        public StudentEntityTypeConvention()
        {
            HasKey(s => s.Id);

            Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(s => s.LastName)
                .IsRequired()
                .HasMaxLength(50);

            HasRequired(s => s.Classes);

            ToTable("Students");
        }
    }
}