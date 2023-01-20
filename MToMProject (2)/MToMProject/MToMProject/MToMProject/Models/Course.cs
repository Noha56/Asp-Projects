using System.ComponentModel.DataAnnotations;

namespace MToMProject.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
