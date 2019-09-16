using Microsoft.EntityFrameworkCore.Migrations;

namespace Cf.Libs.DataAccess.Migrations
{
    public partial class db2019091602 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Method_Combo",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_Combo",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Combo",
                table: "Item");

            migrationBuilder.AddColumn<int>(
                name: "MethodId",
                table: "Item",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Item_MethodId",
                table: "Item",
                column: "MethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Method_MethodId",
                table: "Item",
                column: "MethodId",
                principalTable: "Method",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Method_MethodId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_MethodId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "MethodId",
                table: "Item");

            migrationBuilder.AddColumn<int>(
                name: "Combo",
                table: "Item",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_Combo",
                table: "Item",
                column: "Combo");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Method_Combo",
                table: "Item",
                column: "Combo",
                principalTable: "Method",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
