using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaritoShop.Migrations
{
    /// <inheritdoc />
    public partial class RenamedModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas");

            migrationBuilder.RenameTable(
                name: "Pizzas",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "PizzaPrice",
                table: "CartItem",
                newName: "ProductPrice");

            migrationBuilder.RenameColumn(
                name: "PizzaName",
                table: "CartItem",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "PizzaId",
                table: "CartItem",
                newName: "ProductId");

            // ✅ Create the Categories table
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            // ✅ Insert default categories
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
            { 1, "Pizza" },
            { 2, "Dessert" }
                });

            // ✅ Add the CategoryId column **after** creating Categories
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 1); // Set default category to "Pizza" (Id = 1)

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "CartItem",
                newName: "PizzaPrice");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "CartItem",
                newName: "PizzaName");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItem",
                newName: "PizzaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pizzas",
                table: "Pizzas",
                column: "Id");
        }
    }
}
