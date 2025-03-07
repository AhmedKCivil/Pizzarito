using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Image URL")]
        public string ImageTitle { get; set; }
        
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        //public string StripePriceId { get; set; }
    }
}


