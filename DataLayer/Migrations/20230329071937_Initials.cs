using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brans",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand_name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("brand_id", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("category_id", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ZipCodes",
                columns: table => new
                {
                    zipcode_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zipcode_city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZipCodes", x => x.zipcode_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false, defaultValue: 100),
                    product_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    product_description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    product_price = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    Fk_BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Products_Brans_Fk_BrandId",
                        column: x => x.Fk_BrandId,
                        principalTable: "Brans",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_firstname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    user_lastname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    user_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    user_disable = table.Column<bool>(type: "bit", nullable: false),
                    Fk_ZipCodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_id", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_ZipCodes_Fk_ZipCodeId",
                        column: x => x.Fk_ZipCodeId,
                        principalTable: "ZipCodes",
                        principalColumn: "zipcode_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fk_ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("image_id", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Products_Fk_ProductId",
                        column: x => x.Fk_ProductId,
                        principalTable: "Products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Ordres",
                columns: table => new
                {
                    ordre_id = table.Column<int>(type: "int", nullable: false, defaultValue: 10000),
                    ordre_created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ordre_updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fk_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordres", x => x.ordre_id);
                    table.ForeignKey(
                        name: "FK_Ordres_Users_Fk_UserId",
                        column: x => x.Fk_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Images_Fk_ProductId",
                table: "Images",
                column: "Fk_ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordres_Fk_UserId",
                table: "Ordres",
                column: "Fk_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductsProductId",
                table: "ProductCategory",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrdre_ProductsProductId",
                table: "ProductOrdre",
                column: "ProductsProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_BrandId",
                table: "Products",
                column: "Fk_BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Fk_ZipCodeId",
                table: "Users",
                column: "Fk_ZipCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductOrdre");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Ordres");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brans");

            migrationBuilder.DropTable(
                name: "ZipCodes");
        }
    }
}
