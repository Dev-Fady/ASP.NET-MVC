namespace Q3DotNetAssiut.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MangerName { get; set; }

        public List<Employee>? Employees { get; set; } = new List<Employee>();

        public ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();
        
    }
}
