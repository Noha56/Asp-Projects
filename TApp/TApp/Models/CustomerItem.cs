using System.ComponentModel.DataAnnotations;

namespace TApp.Models
{
    public class CustomerItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }



    }
}
