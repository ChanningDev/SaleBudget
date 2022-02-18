using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesBudget.DataAccess.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrenyGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operative = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerGroupCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicensingArea = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "ExchangeRate",
                columns: table => new
                {
                    ExchangeRateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Scenario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrencyAcronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExRate = table.Column<double>(type: "float", nullable: false),
                    InterCompanyRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExchangeRate", x => x.ExchangeRateId);
                });

            migrationBuilder.CreateTable(
                name: "LedgerType",
                columns: table => new
                {
                    LedgerTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LedgerTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Scenario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statutory = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerType", x => x.LedgerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PharmaForm",
                columns: table => new
                {
                    PharmaFormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PharmaFormAcronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PharmaFormName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaForm", x => x.PharmaFormId);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                columns: table => new
                {
                    ProductGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductGroupCode = table.Column<int>(type: "int", nullable: false),
                    ProductGroupAcronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.ProductGroupId);
                });

            migrationBuilder.CreateTable(
                name: "UnToBulk",
                columns: table => new
                {
                    UnToBulkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversionRate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnToBulk", x => x.UnToBulkId);
                });

            migrationBuilder.CreateTable(
                name: "UnToKg",
                columns: table => new
                {
                    UnToKgId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversionRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnToKg", x => x.UnToKgId);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    ShortItem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PharmaFormId = table.Column<int>(type: "int", nullable: false),
                    ProductGroupId = table.Column<int>(type: "int", nullable: false),
                    UnToBulkId = table.Column<int>(type: "int", nullable: false),
                    UnToKgId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemMasterId);
                    table.ForeignKey(
                        name: "FK_Item_PharmaForm_PharmaFormId",
                        column: x => x.PharmaFormId,
                        principalTable: "PharmaForm",
                        principalColumn: "PharmaFormId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroup",
                        principalColumn: "ProductGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_UnToBulk_UnToBulkId",
                        column: x => x.UnToBulkId,
                        principalTable: "UnToBulk",
                        principalColumn: "UnToBulkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_UnToKg_UnToKgId",
                        column: x => x.UnToKgId,
                        principalTable: "UnToKg",
                        principalColumn: "UnToKgId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    BudgetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    FreeOfCharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<float>(type: "real", nullable: false),
                    MonthNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitOfMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityKg = table.Column<float>(type: "real", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    TotalImport = table.Column<float>(type: "real", nullable: false),
                    LastUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramId = table.Column<int>(type: "int", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemMasterId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    LedgerTypeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ExchangeRateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.BudgetId);
                    table.ForeignKey(
                        name: "FK_Budget_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Budget_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Budget_ExchangeRate_ExchangeRateId",
                        column: x => x.ExchangeRateId,
                        principalTable: "ExchangeRate",
                        principalColumn: "ExchangeRateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Budget_Item_ItemMasterId",
                        column: x => x.ItemMasterId,
                        principalTable: "Item",
                        principalColumn: "ItemMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Budget_LedgerType_LedgerTypeId",
                        column: x => x.LedgerTypeId,
                        principalTable: "LedgerType",
                        principalColumn: "LedgerTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budget_CompanyId",
                table: "Budget",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_CustomerId",
                table: "Budget",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_ExchangeRateId",
                table: "Budget",
                column: "ExchangeRateId");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_ItemMasterId",
                table: "Budget",
                column: "ItemMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_LedgerTypeId",
                table: "Budget",
                column: "LedgerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_PharmaFormId",
                table: "Item",
                column: "PharmaFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ProductGroupId",
                table: "Item",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_UnToBulkId",
                table: "Item",
                column: "UnToBulkId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_UnToKgId",
                table: "Item",
                column: "UnToKgId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budget");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "ExchangeRate");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "LedgerType");

            migrationBuilder.DropTable(
                name: "PharmaForm");

            migrationBuilder.DropTable(
                name: "ProductGroup");

            migrationBuilder.DropTable(
                name: "UnToBulk");

            migrationBuilder.DropTable(
                name: "UnToKg");
        }
    }
}
