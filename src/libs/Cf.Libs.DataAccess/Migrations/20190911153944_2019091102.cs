using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cf.Libs.DataAccess.Migrations
{
    public partial class _2019091102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Item",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "74212e36-3968-4914-a6a6-933182737d12");

            migrationBuilder.DeleteData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ward",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "District",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Method",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Province",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "NewsId",
                table: "Tag");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDate",
                table: "Post",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewsId",
                table: "Tag",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedDate",
                table: "Post",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Method",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "Description", "EnableDiscount", "IsDeleted", "ModifiedDate", "ModifyUserId", "Name", "Note", "SortOrder", "Type", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(374), "system", "Giặt hấp", false, false, null, null, "Giặt hấp", null, 1, "Clean", "338ebc3f-b73d-4484-b7a6-dc9a2338cf55" },
                    { 2, new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(488), "system", "Giặt sấy", false, false, null, null, "Giặt sấy", null, 1, "Clean", "dbc48a7e-dbc6-4664-92df-8f76bddb2767" },
                    { 3, new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(499), "system", "Chỉ giặt", false, false, null, null, "Chỉ giặt", null, 1, "Clean", "7ee265f6-16bb-49bb-9c01-9f7fe73f911d" },
                    { 4, new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(506), "system", "Chỉ sấy", false, false, null, null, "Chỉ sấy", null, 1, "Dry", "62c38865-5a0c-4e4e-b76a-08f16d32b93b" },
                    { 5, new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(526), "system", "Comfort", false, false, null, null, "Comfort", null, 1, "Soft", "959f7cf8-4aff-451f-bb66-0a6276dfbc22" },
                    { 6, new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(533), "system", "Downy", false, false, null, null, "Downy", null, 1, "Soft", "4985823a-16a4-4db3-89e2-eebdbd7d8ef5" },
                    { 7, new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(540), "system", "Ủi hơi nước miển phí", false, false, null, null, "Ủi hơi nước miển phí", null, 1, "Straight", "a0c23bd2-a722-4597-9591-d84a6e6c2370" },
                    { 8, new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(547), "system", "<strong> Phí: </strong> 10.000đ <small>(dưới 5km)</small>", false, false, null, null, "7h - 11h", null, 1, "Delivery", "9ecc386a-d536-43b7-9b57-b6844d027270" },
                    { 9, new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(553), "system", "<strong> Phí: </strong> 10.000đ <small>(dưới 5km)</small>", false, false, null, null, "13h - 15h", null, 1, "Delivery", "b8f83845-7be0-41cf-a2d4-9d8845f621e2" },
                    { 10, new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(559), "system", "<strong>10.000đ <small>(dưới 5km)</small>", false, false, null, null, "3kg / 1 lần giặt", null, 1, "Delivery", "61196c18-8390-477e-98d1-a58eef7c8c21" },
                    { 11, new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(567), "system", "<strong>Miễn phí vận chuyển </strong><small>(dưới 5km)</small>", false, false, null, null, "5kg / 1 lần giặt", null, 1, "Combo", "d3d761f9-d5fd-45b3-93a0-eb1b62f09dab" },
                    { 12, new DateTime(2019, 9, 11, 20, 50, 21, 208, DateTimeKind.Local).AddTicks(643), "system", "<strong>Miễn phí vận chuyển</strong>", false, false, null, null, "10kg / 1 lần giặt", null, 1, "Combo", "b4911049-46c7-4137-84ea-e0a577b5a43d" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "IsPublished", "ModifiedDate", "ModifyUserId", "Name", "Note", "Prefix", "SortOrder", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 11, 20, 50, 21, 202, DateTimeKind.Local).AddTicks(3722), "system", false, true, null, null, "Huế", null, "", 1, "43d4596c-7f65-46d6-8ea1-96c7594b1b7f" },
                    { 2, new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(2174), "system", false, true, null, null, "Đà Nẵng", null, "", 1, "0c084a58-51e8-4e08-aa9c-f297d768cf5c" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "ModifiedDate", "ModifyUserId", "Name", "Note", "UpdatedToken", "Value" },
                values: new object[] { "74212e36-3968-4914-a6a6-933182737d12", new DateTime(2019, 9, 11, 20, 50, 21, 225, DateTimeKind.Local).AddTicks(7241), "system", false, null, null, "Company", null, "7cf4eedf-cb0e-45dc-a5c3-6f996375e55b", "{\"Brand\":\"GIẶT SẠCH\",\"Logo\":\"https://i.imgur.com/1CXl1BP.png\",\"Name\":\"Công Ty TNHH Thương Mại Công Nghệ GIAT SACH\",\"Address\":\"201/2, Lê Văn Việt, Quận 9, Hồ Chí Minh\",\"Email\":\"giatsach.vn@outlook.com\",\"Phone\":\"0866.667.670\",\"Website\":\"giatsach.vn\",\"Copyright\":\"<h4>Copyright © 2019 GiatSach</h4>\",\"Facebook\":\"https://www.facebook.com/giatsach.vn\",\"Instagram\":\"https://www.instagram.com/giatsach.vn\",\"Youtube\":\"https://www.youtube.com/giatsach.vn\",\"AppStore\":\"https://www.facebook.com/giatsach.vn\",\"GooglePlay\":\"https://www.facebook.com/giatsach.vn\",\"GoogleMap\":\" \"}" });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "IsPublished", "ModifiedDate", "ModifyUserId", "Name", "Note", "Prefix", "ProvinceId", "SortOrder", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 11, 20, 50, 21, 204, DateTimeKind.Local).AddTicks(9987), "system", false, true, null, null, "Huế", null, "Tp", 1, 1, "53899ea7-d0d3-4a34-b103-55653f08beff" },
                    { 2, new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(2224), "system", false, true, null, null, "Liên Chiểu", null, "Quận", 2, 1, "fc17924d-4e0b-4475-9eaa-22110c4ce799" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Combo", "CreateDate", "CreateUserId", "Description", "Highlight", "Image", "IsDeleted", "ModifiedDate", "ModifyUserId", "Name", "Note", "SortOrder", "Type", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2019, 9, 11, 20, 50, 21, 227, DateTimeKind.Local).AddTicks(2372), "system", "<ul class=\"content\"><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li></ul>", false, null, false, null, null, "Giặt thường 1", null, 1, "Laundry", "3cc3988b-f7b3-4271-b45e-3087308c9796" },
                    { 2, 11, new DateTime(2019, 9, 11, 20, 50, 21, 227, DateTimeKind.Local).AddTicks(2686), "system", "<ul class=\"content\"><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li></ul>", false, null, false, null, null, "Giặt thường 2", null, 1, "Laundry", "28c3719e-8910-4fd2-9021-142645b1c398" },
                    { 3, 12, new DateTime(2019, 9, 11, 20, 50, 21, 227, DateTimeKind.Local).AddTicks(2698), "system", "<ul class=\"content\"><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li></ul>", false, null, false, null, null, "Giặt thường 3", null, 1, "Laundry", "4ab45082-5dc7-4cb3-9431-178fe7e54e30" }
                });

            migrationBuilder.InsertData(
                table: "Ward",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "DistrictId", "IsDeleted", "IsPublished", "ModifiedDate", "ModifyUserId", "Name", "Note", "Prefix", "SortOrder", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(1902), "system", 1, false, true, null, null, "An Hòa", null, "Phường", 1, "ddb7ddcd-b8c8-4efa-8a10-3b56c8bc0dcf" },
                    { 2, new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(1945), "system", 1, false, true, null, null, "Phú Bình", null, "Phường", 1, "a6f7cfcd-0d0b-42eb-9716-2ee780b611f4" },
                    { 3, new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(1950), "system", 1, false, true, null, null, "Phú Hòa", null, "Phường", 1, "258003c4-4f34-4e2c-91ba-14e9bf4052a3" },
                    { 4, new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(1954), "system", 1, false, true, null, null, "Phú Thuận", null, "Phường", 1, "91acbe66-b5df-45d7-ae8a-8777e071455e" },
                    { 5, new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(1959), "system", 1, false, true, null, null, "Tây Lộc", null, "Phường", 1, "6051d912-03b5-499b-a490-ca83e55bcb8a" },
                    { 6, new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(2243), "system", 2, false, true, null, null, "Hòa Khánh Bắc", null, "Phường", 1, "edd06453-e483-4560-b993-3eb367c3de82" },
                    { 7, new DateTime(2019, 9, 11, 20, 50, 21, 205, DateTimeKind.Local).AddTicks(2247), "system", 2, false, true, null, null, "Hòa Khánh Nam", null, "Phường", 1, "2be7f62a-2fa0-40c3-94d2-b9936b8aa5a0" }
                });
        }
    }
}
