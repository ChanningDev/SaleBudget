using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesBudget.DataAccess.Migrations
{
    public partial class MonthlyDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ago",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Apr",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dec",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Feb",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jan",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jul",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Jun",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mar",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "May",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Nov",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Oct",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Sept",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ago",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "Apr",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "Dec",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "Feb",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "Jan",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "Jul",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "Jun",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "Mar",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "May",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "Nov",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "Oct",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "Sept",
                table: "Budget");
        }
    }
}
