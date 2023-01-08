using System.ComponentModel.DataAnnotations;

namespace Midterm.Models
{
    public class Tv
    {
        [Key]
        public int TvId { get; set; }
        [Required(ErrorMessage ="Model is requred")]
        [MaxLength(25,ErrorMessage ="Maximum 25 characters!")]
        public string Name { get; set; }

        [Display(Name="Refresh Rate (Hz)")]
        [Range(50,60, ErrorMessage="Price from 50 to 60")]
        public int RefreshRate { get; set; }

        public EType Tvtype { get; set; }
        public enum EType { PLASMA,LCD,LED}

        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; } = "10/10/2022:01:00";
    }
}
