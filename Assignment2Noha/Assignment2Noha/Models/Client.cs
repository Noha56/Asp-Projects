using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2Noha.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public Gender ClientGender { get; set; }


        [Required(ErrorMessage = "Please enter your Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string ClientImage { get; set; }
        public IList<ClientOrder> ClientOrders { get; set; }

    }
    public enum Gender { Male, Female }

}
