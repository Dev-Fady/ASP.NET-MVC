using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q3DotNetAssiut.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        [UniqueNameAttribute<Course>("Name")]
       
        // client Side 
        //[Remote(action: "CheckName",
        //    controller: "Course",
        //    AdditionalFields = "hours",
        //    ErrorMessage = "Name Must Contain ITI")]
        
        [Remote(action: "CheckUniqueName",
            controller: "Course",
            ErrorMessage = "Name Must be unique")]
        public string? Name { get; set; }

        [Required]
        //[RegularExpression("Alex|Assiut|Sohag")]
        //[RegularExpression("[a-zA-Z]{3,25}")]
        //[RegularExpression(@"\d{3,25}")]
        //[RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="erererer")]
        [Range(100,150)]
        public int degree { get; set; }
        [Range(70, 100)]
        [Required]
        public int minDegree { get; set; }

        [Range(5, 10)]
        [Required]
        public int hours { get; set; }

        [ForeignKey("Department")]
        public int dept_id { get; set; }
        public Department? Department { get; set; }

        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

        public ICollection<CrsResult> CrsResults { get; set; } = new List<CrsResult>();

    }
}
