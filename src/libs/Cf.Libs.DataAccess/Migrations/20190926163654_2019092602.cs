using Microsoft.EntityFrameworkCore.Migrations;

namespace Cf.Libs.DataAccess.Migrations
{
    public partial class _2019092602 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Qty",
                table: "OrderDetail",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "Qty",
                table: "BillDetail",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qty",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<int>(
                name: "Qty",
                table: "BillDetail",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
