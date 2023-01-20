using System.ComponentModel.DataAnnotations;

namespace LaptopsIdentityApp.Models
{
    public class Laptop
    {
        [Key]
        public int Id { get; set; }
        public Brand Manufacture { get; set; }
        public ProcessorT Processor { get; set; }
        public int HDSize { get; set; }
        public int RamSize { get; set; }

        public int Price { get; set; }

        public String Image { get; set; }
    }
    public enum Brand
    {
        HP,Acer,MCBook,Toshiba,Lenovo,Asus,Dell
    }

    public enum ProcessorT
    {
        I3,I5,I7,I9
    }
}
