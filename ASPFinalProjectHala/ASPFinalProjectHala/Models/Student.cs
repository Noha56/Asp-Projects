using System.ComponentModel.DataAnnotations;

namespace ASPFinalProjectHala.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public Gender StudentGender { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public string Image { get; set; }

        public IList<StudentTeacher> StudentTeachers { get; set; }
    }

    public enum Gender
    {
        Female, Male
    }
}