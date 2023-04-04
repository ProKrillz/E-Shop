using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class test33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.AddColumn<int>(
                name: "Fk_CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fk_ImageId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Fk_SetId",
                table: "Products",
                type: "nvarchar(4)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    set_id = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    set_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    set_realse = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.set_id);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "brand_name" },
                values: new object[] { 1, "Konami" });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryId", "category_name" },
                values: new object[,]
                {
                    { 1, "Single" },
                    { 2, "Booster" },
                    { 3, "Display" }
                });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "set_id", "set_name", "set_realse" },
                values: new object[] { "LOB", "Legends of blue-eyes white dragon", new DateTime(2002, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_CategoryId",
                table: "Products",
                column: "Fk_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_SetId",
                table: "Products",
                column: "Fk_SetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categorys_Fk_CategoryId",
                table: "Products",
                column: "Fk_CategoryId",
                principalTable: "Categorys",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sets_Fk_SetId",
                table: "Products",
                column: "Fk_SetId",
                principalTable: "Sets",
                principalColumn: "set_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categorys_Fk_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sets_Fk_SetId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropIndex(
                name: "IX_Products_Fk_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Fk_SetId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Fk_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Fk_ImageId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Fk_SetId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    CategorysCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.CategorysCategoryId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Categorys_CategorysCategoryId",
                        column: x => x.CategorysCategoryId,
                        principalTable: "Categorys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductsProductId",
                table: "ProductCategory",
                column: "ProductsProductId");
        }
    }
}
