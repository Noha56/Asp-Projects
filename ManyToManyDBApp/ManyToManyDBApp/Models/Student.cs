using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManyToManyDBApp.Models
{
    public class Student
    {
        [Key]
        public int StId { get; set; }
        [Column(TypeName="varchar(25)")]
        public string StName { get; set; }


        public IList<StudentCourse> studentCourse { get; set; }

    }
}
