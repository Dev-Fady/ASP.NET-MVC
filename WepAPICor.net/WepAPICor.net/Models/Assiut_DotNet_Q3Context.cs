using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WepAPICor.net.Models
{
    public partial class Assiut_DotNet_Q3Context : IdentityDbContext<ApplicationUser>
    {
        public Assiut_DotNet_Q3Context(DbContextOptions<Assiut_DotNet_Q3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CrsResult> CrsResults { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Department1> Departments1 { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // مهم جدًا علشان ASP.NET Identity يشتغل
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasIndex(e => e.DeptId, "IX_Courses_dept_id");

                entity.Property(e => e.Degree).HasColumnName("degree");
                entity.Property(e => e.DeptId).HasColumnName("dept_id");
                entity.Property(e => e.Hours).HasColumnName("hours");
                entity.Property(e => e.MinDegree).HasColumnName("minDegree");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.Dept).WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<CrsResult>(entity =>
            {
                entity.HasIndex(e => e.CrsId, "IX_CrsResults_crs_id");
                entity.HasIndex(e => e.TraineeId, "IX_CrsResults_trainee_id");

                entity.Property(e => e.CrsId).HasColumnName("crs_id");
                entity.Property(e => e.Degree).HasColumnName("degree");
                entity.Property(e => e.TraineeId).HasColumnName("trainee_id");

                entity.HasOne(d => d.Crs).WithMany(p => p.CrsResults)
                    .HasForeignKey(d => d.CrsId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Trainee).WithMany(p => p.CrsResults)
                    .HasForeignKey(d => d.TraineeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Department1>(entity =>
            {
                entity.ToTable("Departments");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasDefaultValue("");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId, "IX_Employees_DepartmentId");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasDefaultValue("");
                entity.Property(e => e.JopTitle)
                    .IsRequired()
                    .HasDefaultValue("");
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasDefaultValue("");

                entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasIndex(e => e.CrsId, "IX_Instructors_crs_id");
                entity.HasIndex(e => e.DeptId, "IX_Instructors_dept_id");

                entity.Property(e => e.CrsId).HasColumnName("crs_id");
                entity.Property(e => e.DeptId).HasColumnName("dept_id");
                entity.Property(e => e.ImageUrl).IsRequired();
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Crs).WithMany(p => p.Instructors)
                    .HasForeignKey(d => d.CrsId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Dept).WithMany(p => p.Instructors)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Trainee>(entity =>
            {
                entity.HasIndex(e => e.DeptId, "IX_Trainees_dept_id");

                entity.Property(e => e.DeptId).HasColumnName("dept_id");
                entity.Property(e => e.Grade).HasColumnName("grade");
                entity.Property(e => e.ImageUrl).IsRequired();
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Dept).WithMany(p => p.Trainees)
                    .HasForeignKey(d => d.DeptId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
