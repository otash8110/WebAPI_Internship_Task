using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PhoneChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPhones_Customers_CustomerModelId",
                table: "CustomerPhones");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPhones_CustomerModelId",
                table: "CustomerPhones");

            migrationBuilder.DropColumn(
                name: "CustomerModelId",
                table: "CustomerPhones");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "CustomerPhones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhones_CustomerId",
                table: "CustomerPhones",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPhones_Customers_CustomerId",
                table: "CustomerPhones",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPhones_Customers_CustomerId",
                table: "CustomerPhones");

            migrationBuilder.DropIndex(
                name: "IX_CustomerPhones_CustomerId",
                table: "CustomerPhones");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CustomerPhones");

            migrationBuilder.AddColumn<int>(
                name: "CustomerModelId",
                table: "CustomerPhones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPhones_CustomerModelId",
                table: "CustomerPhones",
                column: "CustomerModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPhones_Customers_CustomerModelId",
                table: "CustomerPhones",
                column: "CustomerModelId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
