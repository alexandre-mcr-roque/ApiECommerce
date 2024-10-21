﻿// <auto-generated />
using System;
using ApiECommerce.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiECommerce.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiECommerce.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "lanches1.png",
                            Name = "Lanches"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "combos1.png",
                            Name = "Combos"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "naturais1.png",
                            Name = "Naturais"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "refrigerantes1.png",
                            Name = "Bebidas"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "sucos1.png",
                            Name = "Sucos"
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "sobremesas1.png",
                            Name = "Sobremesas"
                        });
                });

            modelBuilder.Entity("ApiECommerce.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Total")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ApiECommerce.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ApiECommerce.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<bool>("BestSeller")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("InStock")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Popular")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Available = true,
                            BestSeller = true,
                            CategoryId = 1,
                            Details = "Pão fofinho, hambúrger de carne bovina temperada, cebola, mostarda e ketchup ",
                            ImageUrl = "hamburger1.jpeg",
                            InStock = 13,
                            Name = "Hamburger padrão",
                            Popular = true,
                            Price = 15m
                        },
                        new
                        {
                            Id = 2,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 1,
                            Details = "Pão fofinho, hambúrguer de carne bovina temperada e queijo por todos os lados.",
                            ImageUrl = "hamburger3.jpeg",
                            InStock = 10,
                            Name = "CheeseBurger padrão",
                            Popular = true,
                            Price = 18m
                        },
                        new
                        {
                            Id = 3,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 1,
                            Details = "Pão fofinho, hambúrger de carne bovina temperada, cebola,alface, mostarda e ketchup ",
                            ImageUrl = "hamburger4.jpeg",
                            InStock = 13,
                            Name = "CheeseSalada padrão",
                            Popular = false,
                            Price = 19m
                        },
                        new
                        {
                            Id = 4,
                            Available = false,
                            BestSeller = false,
                            CategoryId = 2,
                            Details = "Pão fofinho, hambúrguer de carne bovina temperada e queijo, refrigerante e fritas",
                            ImageUrl = "combo1.jpeg",
                            InStock = 10,
                            Name = "Hambúrger, batata fritas, refrigerante ",
                            Popular = true,
                            Price = 25m
                        },
                        new
                        {
                            Id = 5,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 2,
                            Details = "Pão fofinho, hambúrguer de carne bovina ,refrigerante e fritas, cebola, maionese e ketchup",
                            ImageUrl = "combo2.jpeg",
                            InStock = 13,
                            Name = "CheeseBurger, batata fritas , refrigerante",
                            Popular = false,
                            Price = 27m
                        },
                        new
                        {
                            Id = 6,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 2,
                            Details = "Pão fofinho, hambúrguer de carne bovina ,refrigerante e fritas, cebola, maionese e ketchup",
                            ImageUrl = "combo3.jpeg",
                            InStock = 10,
                            Name = "CheeseSalada, batata fritas, refrigerante",
                            Popular = true,
                            Price = 28m
                        },
                        new
                        {
                            Id = 7,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 3,
                            Details = "Pão integral com folhas e tomate",
                            ImageUrl = "lanche_natural1.jpeg",
                            InStock = 13,
                            Name = "Lanche Natural com folhas",
                            Popular = false,
                            Price = 14m
                        },
                        new
                        {
                            Id = 8,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 3,
                            Details = "Pão integral, folhas, tomate e queijo.",
                            ImageUrl = "lanche_natural2.jpeg",
                            InStock = 10,
                            Name = "Lanche Natural e queijo",
                            Popular = true,
                            Price = 15m
                        },
                        new
                        {
                            Id = 9,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 3,
                            Details = "Lanche vegano com ingredientes saudáveis",
                            ImageUrl = "lanche_vegano1.jpeg",
                            InStock = 18,
                            Name = "Lanche Vegano",
                            Popular = false,
                            Price = 25m
                        },
                        new
                        {
                            Id = 10,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 4,
                            Details = "Refrigerante Coca Cola",
                            ImageUrl = "coca_cola1.jpeg",
                            InStock = 7,
                            Name = "Coca-Cola",
                            Popular = true,
                            Price = 21m
                        },
                        new
                        {
                            Id = 11,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 4,
                            Details = "Refrigerante de Guaraná",
                            ImageUrl = "guarana1.jpeg",
                            InStock = 6,
                            Name = "Guaraná",
                            Popular = false,
                            Price = 25m
                        },
                        new
                        {
                            Id = 12,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 4,
                            Details = "Refrigerante Pepsi Cola",
                            ImageUrl = "pepsi1.jpeg",
                            InStock = 6,
                            Name = "Pepsi",
                            Popular = false,
                            Price = 21m
                        },
                        new
                        {
                            Id = 13,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 5,
                            Details = "Suco de laranja saboroso e nutritivo",
                            ImageUrl = "suco_laranja.jpeg",
                            InStock = 10,
                            Name = "Suco de laranja",
                            Popular = false,
                            Price = 11m
                        },
                        new
                        {
                            Id = 14,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 5,
                            Details = "Suco de morango fresquinhos",
                            ImageUrl = "suco_morango1.jpeg",
                            InStock = 13,
                            Name = "Suco de morango",
                            Popular = false,
                            Price = 15m
                        },
                        new
                        {
                            Id = 15,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 5,
                            Details = "Suco de uva natural sem acúcar feito com a fruta",
                            ImageUrl = "suco_uva1.jpeg",
                            InStock = 10,
                            Name = "Suco de uva",
                            Popular = false,
                            Price = 13m
                        },
                        new
                        {
                            Id = 16,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 4,
                            Details = "Água mineral natural fresquinha",
                            ImageUrl = "agua_mineral1.jpeg",
                            InStock = 10,
                            Name = "Água",
                            Popular = false,
                            Price = 5m
                        },
                        new
                        {
                            Id = 17,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 6,
                            Details = "Cookies de Chocolate com pedaços de chocolate",
                            ImageUrl = "cookie1.jpeg",
                            InStock = 10,
                            Name = "Cookies de chocolate",
                            Popular = true,
                            Price = 8m
                        },
                        new
                        {
                            Id = 18,
                            Available = true,
                            BestSeller = true,
                            CategoryId = 6,
                            Details = "Cookies de baunilha saborosos e crocantes",
                            ImageUrl = "cookie2.jpeg",
                            InStock = 13,
                            Name = "Cookies de Baunilha",
                            Popular = false,
                            Price = 8m
                        },
                        new
                        {
                            Id = 19,
                            Available = true,
                            BestSeller = false,
                            CategoryId = 6,
                            Details = "Torta suíca com creme e camadas de doce de leite",
                            ImageUrl = "torta_suica1.jpeg",
                            InStock = 10,
                            Name = "Torta Suíca",
                            Popular = true,
                            Price = 10m
                        });
                });

            modelBuilder.Entity("ApiECommerce.Entities.ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ShoppingCartItems");
                });

            modelBuilder.Entity("ApiECommerce.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ApiECommerce.Entities.Order", b =>
                {
                    b.HasOne("ApiECommerce.Entities.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiECommerce.Entities.OrderDetail", b =>
                {
                    b.HasOne("ApiECommerce.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiECommerce.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ApiECommerce.Entities.Product", b =>
                {
                    b.HasOne("ApiECommerce.Entities.Category", null)
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiECommerce.Entities.ShoppingCartItem", b =>
                {
                    b.HasOne("ApiECommerce.Entities.Product", null)
                        .WithMany("ShoppingCartItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiECommerce.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ApiECommerce.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ApiECommerce.Entities.Product", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("ShoppingCartItems");
                });

            modelBuilder.Entity("ApiECommerce.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
