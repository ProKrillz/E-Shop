using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
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
                name: "Deliverys",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    delivery_option = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverys", x => x.DeliveryId);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("image_id", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    payment_option = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

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
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    product_description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    product_price = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false),
                    Fk_SetId = table.Column<string>(type: "nvarchar(4)", nullable: false),
                    Fk_BrandId = table.Column<int>(type: "int", nullable: false),
                    Fk_ImageId = table.Column<int>(type: "int", nullable: false),
                    Fk_CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_Fk_BrandId",
                        column: x => x.Fk_BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_Fk_CategoryId",
                        column: x => x.Fk_CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Images_Fk_ImageId",
                        column: x => x.Fk_ImageId,
                        principalTable: "Images",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Sets_Fk_SetId",
                        column: x => x.Fk_SetId,
                        principalTable: "Sets",
                        principalColumn: "set_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_firstname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    user_lastname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    user_email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    user_password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    user_disable = table.Column<bool>(type: "bit", nullable: false),
                    user_admin = table.Column<bool>(type: "bit", nullable: false),
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
                name: "Ordres",
                columns: table => new
                {
                    ordre_id = table.Column<int>(type: "int", nullable: false, defaultValue: 10000),
                    ordre_created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    ordre_updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fk_PayementId = table.Column<int>(type: "int", nullable: false),
                    Fk_DeliveryId = table.Column<int>(type: "int", nullable: false),
                    Fk_UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordres", x => x.ordre_id);
                    table.ForeignKey(
                        name: "FK_Ordres_Deliverys_Fk_DeliveryId",
                        column: x => x.Fk_DeliveryId,
                        principalTable: "Deliverys",
                        principalColumn: "DeliveryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordres_Payments_Fk_PayementId",
                        column: x => x.Fk_PayementId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordres_Users_Fk_UserId",
                        column: x => x.Fk_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "Images",
                columns: new[] { "ImageId", "image_path" },
                values: new object[] { 1, "/Image/Card/dpe.jpg" });

            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "set_id", "set_name", "set_realse" },
                values: new object[,]
                {
                    { "LOB", "Legends of blue-eyes white dragon", new DateTime(2002, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "POTE", "Power of the Elements", new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ZipCodes",
                columns: new[] { "zipcode_id", "zipcode_city" },
                values: new object[] { 6400, "Sønderborg" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "product_id", "product_description", "Fk_BrandId", "Fk_CategoryId", "Fk_ImageId", "Fk_SetId", "product_name", "product_price" },
                values: new object[] { 100, "Starligth rare", 1, 1, 1, "POTE", "Destiny HERO - Destroyer Phoenix Enforcer", 1700.00m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "user_address", "user_admin", "user_disable", "user_email", "user_firstname", "Fk_ZipCodeId", "user_lastname", "user_password" },
                values: new object[] { new Guid("0a916c32-36a6-42e0-9b05-b46d7e643d56"), "Alsgade 42A", true, false, "admin@admin.dk", "Thomas", 6400, "Damkjær", "linkin" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdreProduct_Fk_ProductId",
                table: "OrdreProduct",
                column: "Fk_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordres_Fk_DeliveryId",
                table: "Ordres",
                column: "Fk_DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordres_Fk_PayementId",
                table: "Ordres",
                column: "Fk_PayementId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordres_Fk_UserId",
                table: "Ordres",
                column: "Fk_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_BrandId",
                table: "Products",
                column: "Fk_BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_CategoryId",
                table: "Products",
                column: "Fk_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_ImageId",
                table: "Products",
                column: "Fk_ImageId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_SetId",
                table: "Products",
                column: "Fk_SetId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_product_name",
                table: "Products",
                column: "product_name");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Fk_ZipCodeId",
                table: "Users",
                column: "Fk_ZipCodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdreProduct");

            migrationBuilder.DropTable(
                name: "Ordres");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Deliverys");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "ZipCodes");
        }
    }
}
