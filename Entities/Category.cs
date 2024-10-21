using System.ComponentModel.DataAnnotations;

namespace ApiECommerce.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string ImageUrl { get; set; } = null!;

        public ICollection<Product>? Products { get; set; }
    }
}
