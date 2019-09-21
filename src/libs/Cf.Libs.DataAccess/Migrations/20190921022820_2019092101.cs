using Microsoft.EntityFrameworkCore.Migrations;

namespace Cf.Libs.DataAccess.Migrations
{
    public partial class _2019092101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrdeCode",
                table: "Tracking",
                newName: "OrderCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderCode",
                table: "Tracking",
                newName: "OrdeCode");
        }
    }
}
