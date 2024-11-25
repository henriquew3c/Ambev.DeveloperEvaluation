using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerAndBranchAndDatesForStatusSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_UserId",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Sales",
                newName: "CustomerId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Sales",
                newName: "CreateAt");

            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "Sales",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CancellationAt",
                table: "Sales",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedAt",
                table: "Sales",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CancellationAt",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "FinishedAt",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Sales",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Sales",
                newName: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
