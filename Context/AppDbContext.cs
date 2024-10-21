using ApiECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiECommerce.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Lanches", ImageUrl = "images/lanches1.png" },
                new Category { Id = 2, Name = "Combos", ImageUrl = "images/combos1.png" },
                new Category { Id = 3, Name = "Naturais", ImageUrl = "images/naturais1.png" },
                new Category { Id = 4, Name = "Bebidas", ImageUrl = "images/refrigerantes1.png" },
                new Category { Id = 5, Name = "Sucos", ImageUrl = "images/sucos1.png" },
                new Category { Id = 6, Name = "Sobremesas", ImageUrl = "images/sobremesas1.png" }
                );

            modelBuilder.Entity<Product>().HasData(
               new Product { Id = 1, Name = "Hamburger padrão", ImageUrl = "images/hamburger1.jpeg", CategoryId = 1, Price = 15, InStock = 13, Available = true, BestSeller = true, Popular = true, Details = "Pão fofinho, hambúrger de carne bovina temperada, cebola, mostarda e ketchup " },
               new Product { Id = 2, Name = "CheeseBurger padrão", ImageUrl = "images/hamburger3.jpeg", CategoryId = 1, Price = 18, InStock = 10, Available = true, BestSeller = false, Popular = true, Details = "Pão fofinho, hambúrguer de carne bovina temperada e queijo por todos os lados." },
               new Product { Id = 3, Name = "CheeseSalada padrão", ImageUrl = "images/hamburger4.jpeg", CategoryId = 1, Price = 19, InStock = 13, Available = true, BestSeller = false, Popular = false, Details = "Pão fofinho, hambúrger de carne bovina temperada, cebola,alface, mostarda e ketchup " },
               new Product { Id = 4, Name = "Hambúrger, batata fritas, refrigerante ", ImageUrl = "images/combo1.jpeg", CategoryId = 2, Price = 25, InStock = 10, Available = false, BestSeller = false, Popular = true, Details = "Pão fofinho, hambúrguer de carne bovina temperada e queijo, refrigerante e fritas" },
               new Product { Id = 5, Name = "CheeseBurger, batata fritas , refrigerante", ImageUrl = "images/combo2.jpeg", CategoryId = 2, Price = 27, InStock = 13, Available = true, BestSeller = false, Popular = false, Details = "Pão fofinho, hambúrguer de carne bovina ,refrigerante e fritas, cebola, maionese e ketchup" },
               new Product { Id = 6, Name = "CheeseSalada, batata fritas, refrigerante", ImageUrl = "images/combo3.jpeg", CategoryId = 2, Price = 28, InStock = 10, Available = true, BestSeller = false, Popular = true, Details = "Pão fofinho, hambúrguer de carne bovina ,refrigerante e fritas, cebola, maionese e ketchup" },
               new Product { Id = 7, Name = "Lanche Natural com folhas", ImageUrl = "images/lanche_natural1.jpeg", CategoryId = 3, Price = 14, InStock = 13, Available = true, BestSeller = false, Popular = false, Details = "Pão integral com folhas e tomate" },
               new Product { Id = 8, Name = "Lanche Natural e queijo", ImageUrl = "images/lanche_natural2.jpeg", CategoryId = 3, Price = 15, InStock = 10, Available = true, BestSeller = false, Popular = true, Details = "Pão integral, folhas, tomate e queijo." },
               new Product { Id = 9, Name = "Lanche Vegano", ImageUrl = "images/lanche_vegano1.jpeg", CategoryId = 3, Price = 25, InStock = 18, Available = true, BestSeller = false, Popular = false, Details = "Lanche vegano com ingredientes saudáveis" },
               new Product { Id = 10, Name = "Coca-Cola", ImageUrl = "images/coca_cola1.jpeg", CategoryId = 4, Price = 21, InStock = 7, Available = true, BestSeller = false, Popular = true, Details = "Refrigerante Coca Cola" },
               new Product { Id = 11, Name = "Guaraná", ImageUrl = "images/guarana1.jpeg", CategoryId = 4, Price = 25, InStock = 6, Available = true, BestSeller = false, Popular = false, Details = "Refrigerante de Guaraná" },
               new Product { Id = 12, Name = "Pepsi", ImageUrl = "images/pepsi1.jpeg", CategoryId = 4, Price = 21, InStock = 6, Available = true, BestSeller = false, Popular = false, Details = "Refrigerante Pepsi Cola" },
               new Product { Id = 13, Name = "Suco de laranja", ImageUrl = "images/suco_laranja.jpeg", CategoryId = 5, Price = 11, InStock = 10, Available = true, BestSeller = false, Popular = false, Details = "Suco de laranja saboroso e nutritivo" },
               new Product { Id = 14, Name = "Suco de morango", ImageUrl = "images/suco_morango1.jpeg", CategoryId = 5, Price = 15, InStock = 13, Available = true, BestSeller = false, Popular = false, Details = "Suco de morango fresquinhos" },
               new Product { Id = 15, Name = "Suco de uva", ImageUrl = "images/suco_uva1.jpeg", CategoryId = 5, Price = 13, InStock = 10, Available = true, BestSeller = false, Popular = false, Details = "Suco de uva natural sem acúcar feito com a fruta" },
               new Product { Id = 16, Name = "Água", ImageUrl = "images/agua_mineral1.jpeg", CategoryId = 4, Price = 5, InStock = 10, Available = true, BestSeller = false, Popular = false, Details = "Água mineral natural fresquinha" },
               new Product { Id = 17, Name = "Cookies de chocolate", ImageUrl = "images/cookie1.jpeg", CategoryId = 6, Price = 8, InStock = 10, Available = true, BestSeller = false, Popular = true, Details = "Cookies de Chocolate com pedaços de chocolate" },
               new Product { Id = 18, Name = "Cookies de Baunilha", ImageUrl = "images/cookie2.jpeg", CategoryId = 6, Price = 8, InStock = 13, Available = true, BestSeller = true, Popular = false, Details = "Cookies de baunilha saborosos e crocantes" },
               new Product { Id = 19, Name = "Torta Suíca", ImageUrl = "images/torta_suica1.jpeg", CategoryId = 6, Price = 10, InStock = 10, Available = true, BestSeller = false, Popular = true, Details = "Torta suíca com creme e camadas de doce de leite" }
               );
        }
    }
}
