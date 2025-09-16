using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Q3DotNetAssiut.Models.Config
{
    public class CrsResultConfiguration : IEntityTypeConfiguration<CrsResult>
    {
        public void Configure(EntityTypeBuilder<CrsResult> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.degree).IsRequired();
            builder.Property(x => x.trainee_id).IsRequired();
            builder.Property(x => x.crs_id).IsRequired();


            builder.HasOne(x => x.Course)
                .WithMany(d => d.CrsResults)
                .HasForeignKey(x => x.crs_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Trainee)
              .WithMany(d => d.CrsResults)
              .HasForeignKey(x => x.trainee_id)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
