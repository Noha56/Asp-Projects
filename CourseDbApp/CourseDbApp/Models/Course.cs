using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseDbApp.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName ="varchar(10)")]
        public String CourseName { get; set; }
    }
}
