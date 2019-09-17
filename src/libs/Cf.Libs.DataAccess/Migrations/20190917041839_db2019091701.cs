using Microsoft.EntityFrameworkCore.Migrations;

namespace Cf.Libs.DataAccess.Migrations
{
    public partial class db2019091701 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Method_MethodId",
                table: "Item");

            migrationBuilder.AlterColumn<int>(
                name: "MethodId",
                table: "Item",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Method_MethodId",
                table: "Item",
                column: "MethodId",
                principalTable: "Method",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Method_MethodId",
                table: "Item");

            migrationBuilder.AlterColumn<int>(
                name: "MethodId",
                table: "Item",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Method_MethodId",
                table: "Item",
                column: "MethodId",
                principalTable: "Method",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
