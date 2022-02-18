using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesBudget.DataAccess.Migrations
{
    public partial class cambionometabellaitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budget_Item_ItemMasterId",
                table: "Budget");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_PharmaForm_PharmaFormId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_ProductGroup_ProductGroupId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_UnToBulk_UnToBulkId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_UnToKg_UnToKgId",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "ItemMaster");

            migrationBuilder.RenameIndex(
                name: "IX_Item_UnToKgId",
                table: "ItemMaster",
                newName: "IX_ItemMaster_UnToKgId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_UnToBulkId",
                table: "ItemMaster",
                newName: "IX_ItemMaster_UnToBulkId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_ProductGroupId",
                table: "ItemMaster",
                newName: "IX_ItemMaster_ProductGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_PharmaFormId",
                table: "ItemMaster",
                newName: "IX_ItemMaster_PharmaFormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemMaster",
                table: "ItemMaster",
                column: "ItemMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budget_ItemMaster_ItemMasterId",
                table: "Budget",
                column: "ItemMasterId",
                principalTable: "ItemMaster",
                principalColumn: "ItemMasterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMaster_PharmaForm_PharmaFormId",
                table: "ItemMaster",
                column: "PharmaFormId",
                principalTable: "PharmaForm",
                principalColumn: "PharmaFormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMaster_ProductGroup_ProductGroupId",
                table: "ItemMaster",
                column: "ProductGroupId",
                principalTable: "ProductGroup",
                principalColumn: "ProductGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMaster_UnToBulk_UnToBulkId",
                table: "ItemMaster",
                column: "UnToBulkId",
                principalTable: "UnToBulk",
                principalColumn: "UnToBulkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMaster_UnToKg_UnToKgId",
                table: "ItemMaster",
                column: "UnToKgId",
                principalTable: "UnToKg",
                principalColumn: "UnToKgId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budget_ItemMaster_ItemMasterId",
                table: "Budget");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMaster_PharmaForm_PharmaFormId",
                table: "ItemMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMaster_ProductGroup_ProductGroupId",
                table: "ItemMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMaster_UnToBulk_UnToBulkId",
                table: "ItemMaster");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMaster_UnToKg_UnToKgId",
                table: "ItemMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemMaster",
                table: "ItemMaster");

            migrationBuilder.RenameTable(
                name: "ItemMaster",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_ItemMaster_UnToKgId",
                table: "Item",
                newName: "IX_Item_UnToKgId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemMaster_UnToBulkId",
                table: "Item",
                newName: "IX_Item_UnToBulkId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemMaster_ProductGroupId",
                table: "Item",
                newName: "IX_Item_ProductGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemMaster_PharmaFormId",
                table: "Item",
                newName: "IX_Item_PharmaFormId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "ItemMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Budget_Item_ItemMasterId",
                table: "Budget",
                column: "ItemMasterId",
                principalTable: "Item",
                principalColumn: "ItemMasterId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_PharmaForm_PharmaFormId",
                table: "Item",
                column: "PharmaFormId",
                principalTable: "PharmaForm",
                principalColumn: "PharmaFormId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_ProductGroup_ProductGroupId",
                table: "Item",
                column: "ProductGroupId",
                principalTable: "ProductGroup",
                principalColumn: "ProductGroupId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_UnToBulk_UnToBulkId",
                table: "Item",
                column: "UnToBulkId",
                principalTable: "UnToBulk",
                principalColumn: "UnToBulkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_UnToKg_UnToKgId",
                table: "Item",
                column: "UnToKgId",
                principalTable: "UnToKg",
                principalColumn: "UnToKgId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
