using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingBuddy.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "shoppers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstname = table.Column<string>(name: "first_name", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastname = table.Column<string>(name: "last_name", type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppers", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "shopping_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopping_items", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "shopping_list_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    shopperid = table.Column<int>(name: "shopper_id", type: "int", nullable: false),
                    shoppingitemid = table.Column<int>(name: "shopping_item_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopping_list_items", x => x.id);
                    table.ForeignKey(
                        name: "FK_shopping_list_items_shoppers_shopper_id",
                        column: x => x.shopperid,
                        principalTable: "shoppers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shopping_list_items_shopping_items_shopping_item_id",
                        column: x => x.shoppingitemid,
                        principalTable: "shopping_items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "shoppers",
                columns: new[] { "id", "first_name", "image", "last_name" },
                values: new object[,]
                {
                    { 1, "John", "/images/shoppers/john-doe.png", "Doe" },
                    { 2, "Emily", "/images/shoppers/emily-johnson.png", "Johnson" },
                    { 3, "Benjamin", "/images/shoppers/benjamin-smith.png", "Smith" },
                    { 4, "Ava", "/images/shoppers/ava-williams.png", "Williams" },
                    { 5, "Olivia", "/images/shoppers/olivia-davis.png", "Davis" }
                });

            migrationBuilder.InsertData(
                table: "shopping_items",
                columns: new[] { "id", "image", "title" },
                values: new object[,]
                {
                    { 1, "/images/shopping-items/milk.png", "Milk" },
                    { 2, "/images/shopping-items/apple-juice.png", "Apple juice" },
                    { 3, "/images/shopping-items/chocolate.png", "Chocolate" },
                    { 4, "/images/shopping-items/chips.png", "Chips" },
                    { 5, "/images/shopping-items/bread.png", "Bread" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_shopping_list_items_shopper_id",
                table: "shopping_list_items",
                column: "shopper_id");

            migrationBuilder.CreateIndex(
                name: "IX_shopping_list_items_shopping_item_id",
                table: "shopping_list_items",
                column: "shopping_item_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shopping_list_items");

            migrationBuilder.DropTable(
                name: "shoppers");

            migrationBuilder.DropTable(
                name: "shopping_items");
        }
    }
}
