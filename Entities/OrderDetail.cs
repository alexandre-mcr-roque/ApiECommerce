﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiECommerce.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [Precision(10,2)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Precision(12, 2)]
        public decimal Total { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}