using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        // Navigation Property
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
