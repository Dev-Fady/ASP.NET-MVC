using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Q3DotNetAssiut.Models.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Salary).IsRequired();
            builder.Property(x => x.JopTitle).IsRequired();
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x => x.Address).IsRequired(false);
            builder.Property(x=>x.DepartmentId).IsRequired();
        }
    }
}
