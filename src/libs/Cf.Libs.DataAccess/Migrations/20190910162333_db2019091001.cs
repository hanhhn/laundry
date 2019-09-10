using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cf.Libs.DataAccess.Migrations
{
    public partial class db2019091001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Method",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "Description", "EnableDiscount", "IsDeleted", "ModifiedDate", "ModifyUserId", "Name", "Note", "SortOrder", "Type", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(3965), "system", "Giặt hấp", false, false, null, null, "Giặt hấp", null, 1, "Clean", "180564ac-b2f9-43b6-ac23-5610ebba2694" },
                    { 2, new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4012), "system", "Giặt sấy", false, false, null, null, "Giặt sấy", null, 1, "Clean", "12296aa6-9c73-46f3-98cc-03d6e479984a" },
                    { 3, new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4019), "system", "Chỉ giặt", false, false, null, null, "Chỉ giặt", null, 1, "Clean", "1dc48057-7023-45c5-8698-398f32c13239" },
                    { 4, new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4045), "system", "Chỉ sấy", false, false, null, null, "Chỉ sấy", null, 1, "Dry", "17b14e9c-d4a8-4a6a-b250-d1bbde54edad" },
                    { 5, new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4051), "system", "Comfort", false, false, null, null, "Comfort", null, 1, "Soft", "636a2851-6503-48c5-8853-0e0e31f419a2" },
                    { 6, new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4132), "system", "Downy", false, false, null, null, "Downy", null, 1, "Soft", "5d3a48f0-5ba4-473e-979c-374a9e31269b" },
                    { 7, new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4137), "system", "Ủi hơi nước miển phí", false, false, null, null, "Ủi hơi nước miển phí", null, 1, "Straight", "2327f8d4-4bc8-439c-8ab7-3c29d365b9dd" },
                    { 8, new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4142), "system", "<strong> Phí: </strong> 10.000đ <small>(dưới 5km)</small>", false, false, null, null, "7h - 11h", null, 1, "Delivery", "ff57a7e4-81e7-4c10-ba8e-60b56833d6ce" },
                    { 9, new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4147), "system", "<strong> Phí: </strong> 10.000đ <small>(dưới 5km)</small>", false, false, null, null, "13h - 15h", null, 1, "Delivery", "ce143a7a-d6c5-4f8e-ac96-c729614028b2" },
                    { 10, new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4153), "system", "<strong>10.000đ <small>(dưới 5km)</small>", false, false, null, null, "3kg / 1 lần giặt", null, 1, "Delivery", "bedb4946-47df-4eb3-8e39-73aae2a4c5c7" },
                    { 11, new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4158), "system", "<strong>Miễn phí vận chuyển </strong><small>(dưới 5km)</small>", false, false, null, null, "5kg / 1 lần giặt", null, 1, "Combo", "9cd8c6a8-6700-496e-b9c6-7db2ad9b1419" },
                    { 12, new DateTime(2019, 9, 10, 23, 23, 32, 581, DateTimeKind.Local).AddTicks(4166), "system", "<strong>Miễn phí vận chuyển</strong>", false, false, null, null, "10kg / 1 lần giặt", null, 1, "Combo", "362e4163-3e76-4702-a64b-46f8366d1536" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "IsPublished", "ModifiedDate", "ModifyUserId", "Name", "Note", "Prefix", "SortOrder", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 10, 23, 23, 32, 576, DateTimeKind.Local).AddTicks(791), "system", false, true, null, null, "Huế", null, "", 1, "374a0e33-501a-4291-a19e-b9baa2cfe219" },
                    { 2, new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9488), "system", false, true, null, null, "Đà Nẵng", null, "", 1, "035a81dc-159c-42a2-9a46-4489f12e0eac" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "ModifiedDate", "ModifyUserId", "Name", "Note", "UpdatedToken", "Value" },
                values: new object[] { "bdb73d73-7264-4f5b-8936-0fa1bf361918", new DateTime(2019, 9, 10, 23, 23, 32, 586, DateTimeKind.Local).AddTicks(1774), "system", false, null, null, "Company", null, "ee09ce83-eb94-4776-b3d7-854290847808", "{\"Brand\":\"GIẶT SẠCH\",\"Logo\":\"https://i.imgur.com/1CXl1BP.png\",\"Name\":\"Công Ty TNHH Thương Mại Công Nghệ GIAT SACH\",\"Address\":\"201/2, Lê Văn Việt, Quận 9, Hồ Chí Minh\",\"Email\":\"giatsach.vn@outlook.com\",\"Phone\":\"0866.667.670\",\"Website\":\"giatsach.vn\",\"Copyright\":\"<h4>Copyright © 2019 GiatSach</h4>\",\"Facebook\":\"https://www.facebook.com/giatsach.vn\",\"Instagram\":\"https://www.instagram.com/giatsach.vn\",\"Youtube\":\"https://www.youtube.com/giatsach.vn\",\"AppStore\":\"https://www.facebook.com/giatsach.vn\",\"GooglePlay\":\"https://www.facebook.com/giatsach.vn\",\"GoogleMap\":\" \"}" });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "IsPublished", "ModifiedDate", "ModifyUserId", "Name", "Note", "Prefix", "ProvinceId", "SortOrder", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(6596), "system", false, true, null, null, "Huế", null, "Tp", 1, 1, "fbdb0ec0-59d0-4227-a9c1-b7d43d0f22f6" },
                    { 2, new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9529), "system", false, true, null, null, "Liên Chiểu", null, "Quận", 2, 1, "68d7b0a8-625b-44c1-9eae-b992969beaa0" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Combo", "CreateDate", "CreateUserId", "Description", "Highlight", "Image", "IsDeleted", "ModifiedDate", "ModifyUserId", "Name", "Note", "SortOrder", "Type", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2019, 9, 10, 23, 23, 32, 587, DateTimeKind.Local).AddTicks(2340), "system", "<ul class=\"content\"><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li></ul>", false, null, false, null, null, "Giặt thường 1", null, 1, "Laundry", "4e9fbd58-377a-4539-992f-7a6e23e065c6" },
                    { 2, 11, new DateTime(2019, 9, 10, 23, 23, 32, 587, DateTimeKind.Local).AddTicks(2389), "system", "<ul class=\"content\"><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li></ul>", false, null, false, null, null, "Giặt thường 2", null, 1, "Laundry", "49a3d9dd-a0e9-4d45-837b-a84409058f7c" },
                    { 3, 12, new DateTime(2019, 9, 10, 23, 23, 32, 587, DateTimeKind.Local).AddTicks(2395), "system", "<ul class=\"content\"><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li></ul>", false, null, false, null, null, "Giặt thường 3", null, 1, "Laundry", "164cb6a1-6e66-46d7-8aa4-f6ba9ea4764e" }
                });

            migrationBuilder.InsertData(
                table: "Ward",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "DistrictId", "IsDeleted", "IsPublished", "ModifiedDate", "ModifyUserId", "Name", "Note", "Prefix", "SortOrder", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9272), "system", 1, false, true, null, null, "An Hòa", null, "Phường", 1, "b7d64c8a-d753-4c3b-a41d-22b74f722a39" },
                    { 2, new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9312), "system", 1, false, true, null, null, "Phú Bình", null, "Phường", 1, "99277828-4996-445c-8f24-cb551d92b993" },
                    { 3, new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9317), "system", 1, false, true, null, null, "Phú Hòa", null, "Phường", 1, "4a8e2fe3-19ed-4f45-8715-7126b89d9099" },
                    { 4, new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9321), "system", 1, false, true, null, null, "Phú Thuận", null, "Phường", 1, "54176638-c2d0-43c2-b672-cd42d29f217c" },
                    { 5, new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9335), "system", 1, false, true, null, null, "Tây Lộc", null, "Phường", 1, "84a3b82e-2f98-49aa-a5e1-b73e346bc137" },
                    { 6, new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9546), "system", 2, false, true, null, null, "Hòa Khánh Bắc", null, "Phường", 1, "4572f753-780f-420d-a30c-6e1869322ec8" },
                    { 7, new DateTime(2019, 9, 10, 23, 23, 32, 579, DateTimeKind.Local).AddTicks(9549), "system", 2, false, true, null, null, "Hòa Khánh Nam", null, "Phường", 1, "fad2e22c-d756-407d-8bdb-926b9effa5a2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "bdb73d73-7264-4f5b-8936-0fa1bf361918");

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
        }
    }
}
