using System.ComponentModel.DataAnnotations;

namespace TeacherStudentApp.Models
{
    public class Teacher
    {
        [Key]
        public int TId { get; set; }
        public String Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        public IList<TeacherStudent> TeacherStudent { get; set; }

    }
}
