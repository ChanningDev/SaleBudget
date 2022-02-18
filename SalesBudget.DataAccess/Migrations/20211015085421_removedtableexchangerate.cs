using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesBudget.DataAccess.Migrations
{
    public partial class removedtableexchangerate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budget_ExchangeRate_ExchangeRateId",
                table: "Budget");

            migrationBuilder.DropTable(
                name: "ExchangeRate");

            migrationBuilder.DropIndex(
                name: "IX_Budget_ExchangeRateId",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Budget");

            migrationBuilder.DropColumn(
                name: "QuantityKg",
                table: "Budget");

            migrationBuilder.RenameColumn(
                name: "TotalImport",
                table: "Budget",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "ExchangeRateId",
                table: "Budget",
                newName: "Quantity");

            migrationBuilder.AlterColumn<string>(
                name: "UnitOfMeasure",
                table: "Budget",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MonthNr",
                table: "Budget",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FreeOfCharge",
                table: "Budget",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Budget",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Budget",
                newName: "TotalImport");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Budget",
                newName: "ExchangeRateId");

            migrationBuilder.AlterColumn<string>(
                name: "UnitOfMeasure",
                table: "Budget",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MonthNr",
                table: "Budget",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FreeOfCharge",
                table: "Budget",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Budget",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "QuantityKg",
                table: "Budget",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "ExchangeRate",
                columns: table => new
                {
                    ExchangeRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyAcronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExRate = table.Column<double>(type: "float", nullable: false),
                    InterCompanyRate = table.Column<double>(type: "float", nullable: false),
                    Scenario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRate", x => x.ExchangeRateId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budget_ExchangeRateId",
                table: "Budget",
                column: "ExchangeRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budget_ExchangeRate_ExchangeRateId",
                table: "Budget",
                column: "ExchangeRateId",
                principalTable: "ExchangeRate",
                principalColumn: "ExchangeRateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
