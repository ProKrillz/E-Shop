using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class AdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_Fk_ProductId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_Fk_ProductId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Fk_ProductId",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "user_password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "user_email",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "user_admin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "image_path" },
                values: new object[] { 1, "/Image/Card/dpe.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 100,
                column: "Fk_ImageId",
                value: 1);

            migrationBuilder.InsertData(
                table: "ZipCodes",
                columns: new[] { "zipcode_id", "zipcode_city" },
                values: new object[] { 6400, "Sønderborg" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "user_address", "user_admin", "user_disable", "user_email", "user_firstname", "Fk_ZipCodeId", "user_lastname", "user_password" },
                values: new object[] { new Guid("0a916c32-36a6-42e0-9b05-b46d7e643d56"), "Alsgade 42A", true, false, "admin@admin.dk", "Thomas", 6400, "Damkjær", "linkin" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Fk_ImageId",
                table: "Products",
                column: "Fk_ImageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Images_Fk_ImageId",
                table: "Products",
                column: "Fk_ImageId",
                principalTable: "Images",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Images_Fk_ImageId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Fk_ImageId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0a916c32-36a6-42e0-9b05-b46d7e643d56"));

            migrationBuilder.DeleteData(
                table: "ZipCodes",
                keyColumn: "zipcode_id",
                keyValue: 6400);

            migrationBuilder.DropColumn(
                name: "user_admin",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "user_password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "user_email",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Fk_ProductId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "product_id",
                keyValue: 100,
                column: "Fk_ImageId",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_Fk_ProductId",
                table: "Images",
                column: "Fk_ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_Fk_ProductId",
                table: "Images",
                column: "Fk_ProductId",
                principalTable: "Products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
