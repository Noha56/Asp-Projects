using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oneToManyDBApp.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(5)")]

        public String DeptName { get; set; }

    }
}
