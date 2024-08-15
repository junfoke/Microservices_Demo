using Micro.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Micro.Services.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Savory Party Bread",
                Price = 15,
                Description = " It’s impossible to stop nibbling on warm pieces of this cheesy,<br/> oniony bread. The sliced loaf fans out for a fun presentation.<br/> It’s one of the best savory appetizers I’ve found.",
                ImageUrl = "https://www.tasteofhome.com/wp-content/uploads/2018/01/Savory-Party-Bread_EXPS_THMBRDS19_8115_C10_03_5b.jpg",
                CategoryName = "Appetizer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Teriyaki Pineapple Meatballs",
                Price = 23.99,
                Description = " These teriyaki pineapple meatballs appetizer changed so many <br/> times because of my family’s suggestions that it eventually became <br/> a main course. I think the homemade sauce sets these meatballs apart.",
                ImageUrl = "https://butterwithasideofbread.com/wp-content/uploads/2020/02/Pineapple-Teriyaki-Meatballs-28.jpg",
                CategoryName = "Appetizer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Cookie Butter Pie",
                Price = 10.99,
                Description = " I tasted Biscoff cookie spread at a grocery store one day,<br/> and it was so delicious that I decided to create a no-bake pie with it.<br/> You can make this pie your own by substituting peanut butter or another <br/> kind of spread for the Biscoff spread and then matching toppings. ",
                ImageUrl = "https://i.pinimg.com/originals/a5/ca/05/a5ca058985641e5d9f3f1fb958ce109e.jpg",
                CategoryName = "Dessert"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Antipasto platter",
                Price = 15,
                Description = " Recreate fine antipasto with all the favourites,<br/> then share them with a winning double of homemade dips.",
                ImageUrl = "https://www.fifteenspatulas.com/wp-content/uploads/2021/04/Italian-Antipasto-Platter.jpg",
                CategoryName = "Entree"
            });

        }

    }
}
