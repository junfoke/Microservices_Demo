﻿// <auto-generated />
using Micro.Services.ProductAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Micro.Services.ProductAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Micro.Services.ProductAPI.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryName = "Appetizer",
                            Description = " It’s impossible to stop nibbling on warm pieces of this cheesy,<br/> oniony bread. The sliced loaf fans out for a fun presentation.<br/> It’s one of the best savory appetizers I’ve found.",
                            ImageUrl = "https://placehold.co/603x403",
                            Name = "Savory Party Bread",
                            Price = 15.0
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryName = "Appetizer",
                            Description = " These teriyaki pineapple meatballs appetizer changed so many <br/> times because of my family’s suggestions that it eventually became <br/> a main course. I think the homemade sauce sets these meatballs apart.",
                            ImageUrl = "https://placehold.co/602x402",
                            Name = "Teriyaki Pineapple Meatballs",
                            Price = 23.989999999999998
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryName = "Dessert",
                            Description = " I tasted Biscoff cookie spread at a grocery store one day,<br/> and it was so delicious that I decided to create a no-bake pie with it.<br/> You can make this pie your own by substituting peanut butter or another <br/> kind of spread for the Biscoff spread and then matching toppings. ",
                            ImageUrl = "https://placehold.co/601x401",
                            Name = "Cookie Butter Pie",
                            Price = 10.99
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryName = "Entree",
                            Description = " Recreate fine antipasto with all the favourites,<br/> then share them with a winning double of homemade dips.",
                            ImageUrl = "https://placehold.co/600x400",
                            Name = "Antipasto platter",
                            Price = 15.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
