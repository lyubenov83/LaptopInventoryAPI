using System.ComponentModel.DataAnnotations;

namespace LaptopInventoryAPI.Models
{
    public class Laptop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "In Stock")]
        public bool InStock { get; set; }
    }
}
