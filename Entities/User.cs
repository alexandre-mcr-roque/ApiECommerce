using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiECommerce.Entities
{
    public class User
    {
        public int Id { get; set; }

        //[Required]
        [StringLength(100)]
        public string? Name { get; set; } = null!;

        [Required]
        [StringLength(150)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Password { get; set; } = null!;

        [StringLength(100)]
        public string? ImageUrl { get; set; }

        [StringLength(100)]
        public string? PhoneNumber { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
