using System.ComponentModel.DataAnnotations;

namespace WepAPICor.net.DTO
{
    public class EmployeeDto
    {
        public int Id { get; set; }  // ممكن تخليه بس للـ Update

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name must be less than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [Range(1000, 100000, ErrorMessage = "Salary must be between 1000 and 100000")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Job Title is required")]
        [MaxLength(50, ErrorMessage = "Job Title must be less than 50 characters")]
        public string JopTitle { get; set; }

        [Url(ErrorMessage = "ImageUrl must be a valid URL")]
        public string? ImageUrl { get; set; }  // optional

        [Required(ErrorMessage = "DepartmentId is required")]
        public int DepartmentId { get; set; }
    }
}
