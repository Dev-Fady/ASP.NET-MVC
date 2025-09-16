using Q3DotNetAssiut.Models;

namespace Q3DotNetAssiut.ViewModel
{
    public class InstructorWithDeptsAndCourses
    {
        public Instructor MyInstructor { get; set; }
        public List<Department> Depts { get; set; }
        public List<Course> Courses { get; set; }
    }
}
