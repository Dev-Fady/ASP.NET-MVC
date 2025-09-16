using System.ComponentModel.DataAnnotations.Schema;

namespace Q3DotNetAssiut.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public int degree { get; set; }

        [ForeignKey("Course")]
        public int crs_id { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Trainee")]
        public int trainee_id { get; set; }
        public Trainee Trainee { get; set; }
    }
}
