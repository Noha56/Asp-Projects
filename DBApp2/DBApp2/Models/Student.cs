using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBApp2.Models
{
    public class Student
    {

        //?-->optional
        [Key]
        public int Id { get; set; }

        [Column(TypeName="varchar(30)")]
        public String Name { get; set; }
        [Column(TypeName = "varchar(4)")]
        public String Dept { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}
