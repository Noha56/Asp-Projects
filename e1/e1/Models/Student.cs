using System.ComponentModel.DataAnnotations;

namespace e1.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }

    }
}
