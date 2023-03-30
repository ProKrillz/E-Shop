using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initials3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brans_Fk_BrandId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductOrdre");

            migrationBuilder.RenameTable(
                name: "Brans",
                newName: "Brands");

            migrationBuilder.CreateTable(
                name: "OrdreProduct",
                columns: table => new
                {
                    Fk_OrdreId = table.Column<int>(type: "int", nullable: false),
                    Fk_ProductId = table.Column<int>(type: "int", nullable: false),
                    ordre_product_amount = table.Column<int>(type: "int", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdreProduct", x => new { x.Fk_OrdreId, x.Fk_ProductId });
                    table.ForeignKey(
                        name: "FK_OrdreProduct_Ordres_Fk_OrdreId",
                        column: x => x.Fk_OrdreId,
                        principalTable: "Ordres",
                        principalColumn: "ordre_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdreProduct_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdreProduct_Fk_ProductId",
                table: "OrdreProduct",
                column: "Fk_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_Fk_BrandId",
                table: "Products",
                column: "Fk_BrandId",
                principalTable: "Brands",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_Fk_BrandId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "OrdreProduct");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brans");

            migrationBuilder.CreateTable(
                name: "ProductOrdre",
                columns: table => new
                {
                    OrdresOrdreId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrdre", x => new { x.OrdresOrdreId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_ProductOrdre_Ordres_OrdresOrdreId",
                        column: x => x.OrdresOrdreId,
                        principalTable: "Ordres",
                        principalColumn: "ordre_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrdre_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrdre_ProductsProductId",
                table: "ProductOrdre",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brans_Fk_BrandId",
                table: "Products",
                column: "Fk_BrandId",
                principalTable: "Brans",
                principalColumn: "BrandId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
