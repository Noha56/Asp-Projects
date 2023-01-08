using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace seedDbApp.Models
{
    public class Mobile
    {
        [Key]
        public int MobileId { get; set; }
        [Column(TypeName="varchar(20)")]
        public String Model { get; set; }
        public decimal Price { get; set; }
    }
}
