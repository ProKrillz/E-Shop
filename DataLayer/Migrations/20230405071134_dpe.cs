using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class dpe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sets",
                columns: new[] { "set_id", "set_name", "set_realse" },
                values: new object[] { "POTE", "Power of the Elements", new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "product_id", "product_description", "Fk_BrandId", "Fk_CategoryId", "Fk_ImageId", "Fk_SetId", "product_name", "product_price" },
                values: new object[] { 100, "Starligth rare", 1, 1, 0, "POTE", "Destiny HERO - Destroyer Phoenix Enforcer", 1700.00m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Sets",
                keyColumn: "set_id",
                keyValue: "POTE");
        }
    }
}
