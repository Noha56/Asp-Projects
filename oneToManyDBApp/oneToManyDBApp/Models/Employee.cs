using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oneToManyDBApp.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Column(TypeName="varchar(25)")]
        public string EmpName { get; set; }
        public decimal Salary { get; set; }
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Department Department { get; set; }  //optinal(عشان نظهر الاسم)


    }
}
