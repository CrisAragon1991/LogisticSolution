using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticSolution.Migrations
{
    public partial class AddfieldsDeliverySchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "DeliverySchedules",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductQuantity",
                table: "DeliverySchedules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "DeliverySchedules");

            migrationBuilder.DropColumn(
                name: "ProductQuantity",
                table: "DeliverySchedules");
        }
    }
}
