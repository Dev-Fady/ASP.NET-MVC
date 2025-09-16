using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Q3DotNetAssiut.Models.Config
{
    public class TraineeConfiguration : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x => x.Address).IsRequired(false);
            builder.Property(x => x.dept_id).IsRequired();
            builder.Property(x=>x.grade).IsRequired();


            builder.HasOne(x => x.Department)
                .WithMany(d => d.Trainees)
                .HasForeignKey(x => x.dept_id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
