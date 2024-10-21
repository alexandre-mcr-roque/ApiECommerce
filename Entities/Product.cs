using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiECommerce.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Details { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Precision(10,2)]
        public decimal Price { get; set; }

        public bool Popular { get; set; }

        public bool BestSeller { get; set; }

        public int InStock { get; set; }

        public bool Available { get; set; }

        /// <summary>
        /// FK to <seealso cref="Category"/>
        /// </summary>
        public int CategoryId { get; set; }

        [JsonIgnore]
        public ICollection<OrderDetail>? OrderDetails { get; set; }
        
        [JsonIgnore]
        public ICollection<ShoppingCartItem>? ShoppingCartItems { get; set; }
    }
}
