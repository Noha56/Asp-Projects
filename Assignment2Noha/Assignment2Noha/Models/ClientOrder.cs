namespace Assignment2Noha.Models
{
    public class ClientOrder
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }


    }
}
