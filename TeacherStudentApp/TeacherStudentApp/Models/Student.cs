using System.ComponentModel.DataAnnotations;

namespace TeacherStudentApp.Models
{
    public class Student
    {
        [Key]
        public int SId { get; set; }
        public string Name { get; set; }
        public String Image { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public IList<TeacherStudent> TeacherStudent { get; set; }
    }
}
