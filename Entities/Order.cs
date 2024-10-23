using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ApiECommerce.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }


        [Precision(12,2)]
        public decimal Total { get; set; }

        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }

        public ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
