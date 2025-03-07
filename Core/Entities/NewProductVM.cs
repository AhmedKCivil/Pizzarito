using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class NewProductVM
    {
        public int Id { get; set; }

        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Name is required")]
        public string ProductName { get; set; }

        [Display(Name = "Price in £")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Product poster URL")]
        [Required(ErrorMessage = "Product poster URL is required")]
        public string ImageTitle { get; set; }
        
        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }
    }
}
