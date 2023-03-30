using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class Initials2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fk_DeliveryId",
                table: "Ordres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Fk_PayementId",
                table: "Ordres",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_product_name",
                table: "Products",
                column: "product_name");

            migrationBuilder.CreateIndex(
                name: "IX_Ordres_Fk_DeliveryId",
                table: "Ordres",
                column: "Fk_DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordres_Fk_PayementId",
                table: "Ordres",
                column: "Fk_PayementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordres_Deliverys_Fk_DeliveryId",
                table: "Ordres",
                column: "Fk_DeliveryId",
                principalTable: "Deliverys",
                principalColumn: "DeliveryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordres_Payments_Fk_PayementId",
                table: "Ordres",
                column: "Fk_PayementId",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordres_Deliverys_Fk_DeliveryId",
                table: "Ordres");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordres_Payments_Fk_PayementId",
                table: "Ordres");

            migrationBuilder.DropTable(
                name: "Deliverys");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Products_product_name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Ordres_Fk_DeliveryId",
                table: "Ordres");

            migrationBuilder.DropIndex(
                name: "IX_Ordres_Fk_PayementId",
                table: "Ordres");

            migrationBuilder.DropColumn(
                name: "Fk_DeliveryId",
                table: "Ordres");

            migrationBuilder.DropColumn(
                name: "Fk_PayementId",
                table: "Ordres");
        }
    }
}
