using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaritoShop.Migrations
{
    /// <inheritdoc />
    public partial class RenameModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_OrdersTable_OrderListModelId",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "PizzaName",
                table: "Pizzas",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "PizzaName",
                table: "OrdersTable",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "OrderListModelId",
                table: "CartItem",
                newName: "AllOrdersId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_OrderListModelId",
                table: "CartItem",
                newName: "IX_CartItem_AllOrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_OrdersTable_AllOrdersId",
                table: "CartItem",
                column: "AllOrdersId",
                principalTable: "OrdersTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_OrdersTable_AllOrdersId",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "Pizzas",
                newName: "PizzaName");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "OrdersTable",
                newName: "PizzaName");

            migrationBuilder.RenameColumn(
                name: "AllOrdersId",
                table: "CartItem",
                newName: "OrderListModelId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_AllOrdersId",
                table: "CartItem",
                newName: "IX_CartItem_OrderListModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_OrdersTable_OrderListModelId",
                table: "CartItem",
                column: "OrderListModelId",
                principalTable: "OrdersTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
