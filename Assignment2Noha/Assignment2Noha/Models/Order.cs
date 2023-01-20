using System.ComponentModel.DataAnnotations;

namespace Assignment2Noha.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yy}")]
        public DateTime OrderDate { get; set; }
        public decimal TotalInvoice { get; set; }
        public IList<ClientOrder> ClientOrders { get; set; }


    }
}
