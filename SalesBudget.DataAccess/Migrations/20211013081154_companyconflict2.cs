using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesBudget.DataAccess.Migrations
{
    public partial class companyconflict2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budget_Budget_FBudgetBudgetId",
                table: "Budget");

            migrationBuilder.DropIndex(
                name: "IX_Budget_FBudgetBudgetId",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "FBudgetBudgetId",
                table: "Budget");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FBudgetBudgetId",
                table: "Budget",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Budget_FBudgetBudgetId",
                table: "Budget",
                column: "FBudgetBudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budget_Budget_FBudgetBudgetId",
                table: "Budget",
                column: "FBudgetBudgetId",
                principalTable: "Budget",
                principalColumn: "BudgetId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
