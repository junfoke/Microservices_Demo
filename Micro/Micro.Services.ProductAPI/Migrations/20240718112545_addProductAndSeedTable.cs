using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Micro.Services.ProductAPI.Migrations
{
    public partial class addProductAndSeedTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", " It’s impossible to stop nibbling on warm pieces of this cheesy,<br/> oniony bread. The sliced loaf fans out for a fun presentation.<br/> It’s one of the best savory appetizers I’ve found.", "https://placehold.co/603x403", "Savory Party Bread", 15.0 },
                    { 2, "Appetizer", " These teriyaki pineapple meatballs appetizer changed so many <br/> times because of my family’s suggestions that it eventually became <br/> a main course. I think the homemade sauce sets these meatballs apart.", "https://placehold.co/602x402", "Teriyaki Pineapple Meatballs", 23.989999999999998 },
                    { 3, "Dessert", " I tasted Biscoff cookie spread at a grocery store one day,<br/> and it was so delicious that I decided to create a no-bake pie with it.<br/> You can make this pie your own by substituting peanut butter or another <br/> kind of spread for the Biscoff spread and then matching toppings. ", "https://placehold.co/601x401", "Cookie Butter Pie", 10.99 },
                    { 4, "Entree", " Recreate fine antipasto with all the favourites,<br/> then share them with a winning double of homemade dips.", "https://placehold.co/600x400", "Antipasto platter", 15.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
