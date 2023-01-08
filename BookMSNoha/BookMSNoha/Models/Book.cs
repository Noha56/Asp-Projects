using System.ComponentModel.DataAnnotations;

namespace BookMSNoha.Models
{
    public class Book
    {
        /*
        a.	Book Id
        b.	Book title
        c.	SerialNumber
        d.	Author name
        e.	Publisher name

         */
        [Required]
        public int BookId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public String BookTitle { get; set; }
        
        [Required]
        public String SerialNumber { get; set; }
        
        [Required]
        [MaxLength(20,ErrorMessage = "Author Name must be less than 20 characters long")]
        [Display(Name = "Author")]
        public String AuthorName { get; set; }
        
        [Required]
        [MaxLength(20, ErrorMessage = "Publisher Name must be less than 20 characters long")]
        [Display(Name = "Publisher")]
        public String PublisherName { get; set; }

    }
}
