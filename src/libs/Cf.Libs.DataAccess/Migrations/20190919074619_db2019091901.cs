using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cf.Libs.DataAccess.Migrations
{
    public partial class db2019091901 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Ward");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Ward");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Ward");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                table: "Ward");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Ward");

            migrationBuilder.DropColumn(
                name: "UpdatedToken",
                table: "Ward");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Province");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "Province");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Province");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                table: "Province");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Province");

            migrationBuilder.DropColumn(
                name: "UpdatedToken",
                table: "Province");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "District");

            migrationBuilder.DropColumn(
                name: "CreateUserId",
                table: "District");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "District");

            migrationBuilder.DropColumn(
                name: "ModifyUserId",
                table: "District");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "District");

            migrationBuilder.DropColumn(
                name: "UpdatedToken",
                table: "District");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Ward",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Ward",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Ward",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyUserId",
                table: "Ward",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Ward",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedToken",
                table: "Ward",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Province",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "Province",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Province",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyUserId",
                table: "Province",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Province",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedToken",
                table: "Province",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "District",
                type: "timestamp",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateUserId",
                table: "District",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "District",
                type: "timestamp",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifyUserId",
                table: "District",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "District",
                type: "varchar(300)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedToken",
                table: "District",
                type: "varchar(50)",
                nullable: true);
        }
    }
}
