using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesBudget.DataAccess.Migrations
{
    public partial class TotalMonths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalMonths",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalMonths",
                table: "Budget");
        }
    }
}
