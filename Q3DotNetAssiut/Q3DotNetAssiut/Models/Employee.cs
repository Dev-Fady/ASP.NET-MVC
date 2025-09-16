using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q3DotNetAssiut.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name ="Flull Name")]
        public string? Name { get; set; }
        public int Salary { get; set; }
        public string? JopTitle { get; set; }
        public string? ImageUrl { get; set; }
        public string? Address { get; set; }

        [ForeignKey("Department")]
        [Display(Name= "Department")]
        public int DepartmentId { get; set; }
        public Department?  Department { get; set; }

    }
}
