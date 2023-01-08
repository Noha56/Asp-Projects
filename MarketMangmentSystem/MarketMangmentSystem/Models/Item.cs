namespace MarketMangmentSystem.Models
{
    public class Item
    {
        public int Barcode { get; set; }
        public String? Desc { get; set; }
        public float Price { get; set; }

        public String? ImagePath { get; set; }

        public IFormFile? ImageFile { get; set; }
    }
}
