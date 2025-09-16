using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Q3DotNetAssiut.Models.Config
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Salary).IsRequired();
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x => x.Address).IsRequired(false);
            builder.Property(x => x.dept_id).IsRequired();

            builder.HasOne(x=>x.Department)
                .WithMany(d=>d.Instructors)
                .HasForeignKey(x=>x.dept_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Course)
               .WithMany(d => d.Instructors)
               .HasForeignKey(x => x.crs_id)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
