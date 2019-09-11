using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Cf.Libs.DataAccess.Migrations
{
    public partial class _2019091101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "bdb73d73-7264-4f5b-8936-0fa1bf361918");

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ModifyUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdatedToken = table.Column<string>(type: "varchar(50)", nullable: true),
                    Note = table.Column<string>(type: "varchar(300)", nullable: true),
                    UniqueUrl = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    IsPublished = table.Column<bool>(nullable: false),
                    PublishedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Name = table.Column<string>(nullable: true),
                    NewsId = table.Column<string>(nullable: true),
                    PostId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 204, DateTimeKind.Local).AddTicks(9987), "53899ea7-d0d3-4a34-b103-55653f08beff" });

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(2224), "fc17924d-4e0b-4475-9eaa-22110c4ce799" });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 227, DateTimeKind.Local).AddTicks(2372), "3cc3988b-f7b3-4271-b45e-3087308c9796" });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 227, DateTimeKind.Local).AddTicks(2686), "28c3719e-8910-4fd2-9021-142645b1c398" });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 227, DateTimeKind.Local).AddTicks(2698), "4ab45082-5dc7-4cb3-9431-178fe7e54e30" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(374), "338ebc3f-b73d-4484-b7a6-dc9a2338cf55" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(488), "dbc48a7e-dbc6-4664-92df-8f76bddb2767" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(499), "7ee265f6-16bb-49bb-9c01-9f7fe73f911d" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(506), "62c38865-5a0c-4e4e-b76a-08f16d32b93b" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(526), "959f7cf8-4aff-451f-bb66-0a6276dfbc22" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(533), "4985823a-16a4-4db3-89e2-eebdbd7d8ef5" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(540), "a0c23bd2-a722-4597-9591-d84a6e6c2370" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(547), "9ecc386a-d536-43b7-9b57-b6844d027270" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(553), "b8f83845-7be0-41cf-a2d4-9d8845f621e2" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(559), "61196c18-8390-477e-98d1-a58eef7c8c21" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(567), "d3d761f9-d5fd-45b3-93a0-eb1b62f09dab" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(643), "b4911049-46c7-4137-84ea-e0a577b5a43d" });

            migrationBuilder.UpdateData(
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 202, DateTimeKind.Local).AddTicks(3722), "43d4596c-7f65-46d6-8ea1-96c7594b1b7f" });

            migrationBuilder.UpdateData(
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(2174), "0c084a58-51e8-4e08-aa9c-f297d768cf5c" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "ModifiedDate", "ModifyUserId", "Name", "Note", "UpdatedToken", "Value" },
                values: new object[] { "74212e36-3968-4914-a6a6-933182737d12", new DateTime(2019, 9, 11, 20, 50, 21, 225, DateTimeKind.Local).AddTicks(7241), "system", false, null, null, "Company", null, "7cf4eedf-cb0e-45dc-a5c3-6f996375e55b", "{\"Brand\":\"GIẶT SẠCH\",\"Logo\":\"https://i.imgur.com/1CXl1BP.png\",\"Name\":\"Công Ty TNHH Thương Mại Công Nghệ GIAT SACH\",\"Address\":\"201/2, Lê Văn Việt, Quận 9, Hồ Chí Minh\",\"Email\":\"giatsach.vn@outlook.com\",\"Phone\":\"0866.667.670\",\"Website\":\"giatsach.vn\",\"Copyright\":\"<h4>Copyright © 2019 GiatSach</h4>\",\"Facebook\":\"https://www.facebook.com/giatsach.vn\",\"Instagram\":\"https://www.instagram.com/giatsach.vn\",\"Youtube\":\"https://www.youtube.com/giatsach.vn\",\"AppStore\":\"https://www.facebook.com/giatsach.vn\",\"GooglePlay\":\"https://www.facebook.com/giatsach.vn\",\"GoogleMap\":\" \"}" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(1902), "ddb7ddcd-b8c8-4efa-8a10-3b56c8bc0dcf" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(1945), "a6f7cfcd-0d0b-42eb-9716-2ee780b611f4" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(1950), "258003c4-4f34-4e2c-91ba-14e9bf4052a3" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(1954), "91acbe66-b5df-45d7-ae8a-8777e071455e" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(1959), "6051d912-03b5-499b-a490-ca83e55bcb8a" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(2243), "edd06453-e483-4560-b993-3eb367c3de82" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(2247), "2be7f62a-2fa0-40c3-94d2-b9936b8aa5a0" });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_PostId",
                table: "Tag",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "74212e36-3968-4914-a6a6-933182737d12");

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(6596), "fbdb0ec0-59d0-4227-a9c1-b7d43d0f22f6" });

            migrationBuilder.UpdateData(
                table: "District",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9529), "68d7b0a8-625b-44c1-9eae-b992969beaa0" });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 587, DateTimeKind.Local).AddTicks(2340), "4e9fbd58-377a-4539-992f-7a6e23e065c6" });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 587, DateTimeKind.Local).AddTicks(2389), "49a3d9dd-a0e9-4d45-837b-a84409058f7c" });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 587, DateTimeKind.Local).AddTicks(2395), "164cb6a1-6e66-46d7-8aa4-f6ba9ea4764e" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(3965), "180564ac-b2f9-43b6-ac23-5610ebba2694" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4012), "12296aa6-9c73-46f3-98cc-03d6e479984a" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4019), "1dc48057-7023-45c5-8698-398f32c13239" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4045), "17b14e9c-d4a8-4a6a-b250-d1bbde54edad" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4051), "636a2851-6503-48c5-8853-0e0e31f419a2" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4132), "5d3a48f0-5ba4-473e-979c-374a9e31269b" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4137), "2327f8d4-4bc8-439c-8ab7-3c29d365b9dd" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4142), "ff57a7e4-81e7-4c10-ba8e-60b56833d6ce" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4147), "ce143a7a-d6c5-4f8e-ac96-c729614028b2" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4153), "bedb4946-47df-4eb3-8e39-73aae2a4c5c7" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4158), "9cd8c6a8-6700-496e-b9c6-7db2ad9b1419" });

            migrationBuilder.UpdateData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4166), "362e4163-3e76-4702-a64b-46f8366d1536" });

            migrationBuilder.UpdateData(
                table: "Province",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 576, DateTimeKind.Local).AddTicks(791), "374a0e33-501a-4291-a19e-b9baa2cfe219" });

            migrationBuilder.UpdateData(
                table: "Province",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9488), "035a81dc-159c-42a2-9a46-4489f12e0eac" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "ModifiedDate", "ModifyUserId", "Name", "Note", "UpdatedToken", "Value" },
                values: new object[] { "bdb73d73-7264-4f5b-8936-0fa1bf361918", new DateTime(2019, 9, 10, 23, 23, 32, 586, DateTimeKind.Local).AddTicks(1774), "system", false, null, null, "Company", null, "ee09ce83-eb94-4776-b3d7-854290847808", "{\"Brand\":\"GIẶT SẠCH\",\"Logo\":\"https://i.imgur.com/1CXl1BP.png\",\"Name\":\"Công Ty TNHH Thương Mại Công Nghệ GIAT SACH\",\"Address\":\"201/2, Lê Văn Việt, Quận 9, Hồ Chí Minh\",\"Email\":\"giatsach.vn@outlook.com\",\"Phone\":\"0866.667.670\",\"Website\":\"giatsach.vn\",\"Copyright\":\"<h4>Copyright © 2019 GiatSach</h4>\",\"Facebook\":\"https://www.facebook.com/giatsach.vn\",\"Instagram\":\"https://www.instagram.com/giatsach.vn\",\"Youtube\":\"https://www.youtube.com/giatsach.vn\",\"AppStore\":\"https://www.facebook.com/giatsach.vn\",\"GooglePlay\":\"https://www.facebook.com/giatsach.vn\",\"GoogleMap\":\" \"}" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9272), "b7d64c8a-d753-4c3b-a41d-22b74f722a39" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9312), "99277828-4996-445c-8f24-cb551d92b993" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9317), "4a8e2fe3-19ed-4f45-8715-7126b89d9099" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9321), "54176638-c2d0-43c2-b672-cd42d29f217c" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9335), "84a3b82e-2f98-49aa-a5e1-b73e346bc137" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9546), "4572f753-780f-420d-a30c-6e1869322ec8" });

            migrationBuilder.UpdateData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreateDate", "UpdatedToken" },
                values: new object[] { new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9549), "fad2e22c-d756-407d-8bdb-926b9effa5a2" });
        }
    }
}
