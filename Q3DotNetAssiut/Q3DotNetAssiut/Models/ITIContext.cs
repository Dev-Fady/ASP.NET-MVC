using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Q3DotNetAssiut.Models.Config;
using Q3DotNetAssiut.ViewModel;

namespace Q3DotNetAssiut.Models
{
    public class ITIContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments {  get; set; }

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CrsResult> CrsResults { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        //public DbSet<RegisterUserViewModel> RegisterUserViewModels { get; set; }
        public ITIContext() : base()
        {
        }
        public ITIContext(DbContextOptions<ITIContext> options) :base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer
        //        ("Data Source=.;Initial Catalog=Assiut_DotNet_Q3;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
             typeof(DepartmentConfiguration).Assembly);
        }
    }
}
