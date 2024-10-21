using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiECommerce.Entities
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        [Precision(10,2)]
        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

        [Precision(10, 2)]
        public decimal Total { get; set; }

        public int ProductId { get; set; }

        public int ClientId { get; set; }
    }
}
