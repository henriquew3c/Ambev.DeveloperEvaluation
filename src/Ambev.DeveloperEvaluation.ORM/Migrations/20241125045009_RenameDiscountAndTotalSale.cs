using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class RenameDiscountAndTotalSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Sales",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Sales",
                newName: "DiscountPercent");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountAmount",
                table: "Sales",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountAmount",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Sales",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "DiscountPercent",
                table: "Sales",
                newName: "Discount");
        }
    }
}
