
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManyToManyDBApp.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string CourseName { get; set; }

        public IList<StudentCourse> studentCourse { get; set; }
    }
}
