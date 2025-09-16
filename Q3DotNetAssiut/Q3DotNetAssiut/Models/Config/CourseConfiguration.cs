using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Q3DotNetAssiut.Models.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.dept_id).IsRequired();
            builder.Property(x => x.degree).IsRequired();
            builder.Property(x => x.minDegree).IsRequired();
            builder.Property(x => x.hours).IsRequired();


            builder.HasOne(x => x.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(x => x.dept_id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
