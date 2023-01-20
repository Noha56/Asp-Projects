using System.ComponentModel.DataAnnotations;

namespace ASPFinalProjectHala.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string TeacherEmail { get; }

        public IList<StudentTeacher> StudentTeachers { get; set; }
    }
}
