using Microsoft.EntityFrameworkCore;
using Q3DotNetAssiut.Filters;
using Q3DotNetAssiut.Models;
using Q3DotNetAssiut.Models.Repository;
using Microsoft.AspNetCore.Identity;

namespace Q3DotNetAssiut
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // framwork service : already decalre , alraedy register 
            // built in  service : already decalre , need to register 
            // custom Serce
            builder.Services.AddDbContext<ITIContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                option =>
                {
                    option.Password.RequiredLength = 4;
                    option.Password.RequireDigit = false;
                    option.Password.RequireNonAlphanumeric = false;
                    option.Password.RequireUppercase = false;
                })
            .AddEntityFrameworkStores<ITIContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();
           
            // add HandelErrorAttribute to all Controllers
            
            //builder.Services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(new HandelErrorAttribute());
            //});

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            var app = builder.Build();

            #region Built in Middleware
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            // naming confination Route (Defain rout with name , pattern , default)
            app.MapControllerRoute("Route1", "AllEmp",
                new
                {
                    controller = "Employee",
                    action = "Index"
                });
            app.MapControllerRoute("Route2", "AllDept",
               new
               {
                   controller = "Department",
                   action = "GellAllDepartment"
               });
            app.MapControllerRoute("Route3", "Details/{Id:int}/{color?}",
               new
               {
                   controller = "Employee",
                   action = "Details"
               });
            app.MapControllerRoute("Route4", "D/{action}",
              new
              {
                  controller = "Department",
              });
            app.MapControllerRoute("Route5", "D/{action=GellAllDepartment}",
            new
            {
                controller = "Department",
            });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion

            app.Run();
        }
    }
}
