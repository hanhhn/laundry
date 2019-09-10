using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cf.Libs.DataAccess.Migrations
{
    public partial class _2019091001 : Migration
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
                keyValue: "294b3061-f1a4-409b-ace2-51aec60fce8c");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Method",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "Description", "EnableDiscount", "IsDeleted", "ModifiedDate", "ModifyUserId", "Name", "Note", "SortOrder", "Type", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(9734), "system", "Giặt hấp", false, false, null, null, "Giặt hấp", null, 1, "Clean", "cabe444e-61fd-4d9d-a59f-23d061f10fc5" },
                    { 2, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(9772), "system", "Giặt sấy", false, false, null, null, "Giặt sấy", null, 1, "Clean", "5afeb209-f680-4fd3-a5fe-1e2c97d1d633" },
                    { 3, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(9782), "system", "Chỉ giặt", false, false, null, null, "Chỉ giặt", null, 1, "Clean", "1a3e923a-2ccc-40bb-962f-852bb9e6e798" },
                    { 4, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(9785), "system", "Chỉ sấy", false, false, null, null, "Chỉ sấy", null, 1, "Dry", "d774970e-a748-4879-a128-3df6d91b6f4c" },
                    { 5, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(9788), "system", "Comfort", false, false, null, null, "Comfort", null, 1, "Soft", "16acfce0-ff3a-441a-8090-38067ba88cb3" },
                    { 6, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(9795), "system", "Downy", false, false, null, null, "Downy", null, 1, "Soft", "4ac1ab02-6f9d-4159-a404-fd63ee70f285" },
                    { 7, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(9798), "system", "Ủi hơi nước miển phí", false, false, null, null, "Ủi hơi nước miển phí", null, 1, "Straight", "23ca4023-add4-482d-aa08-002ceaae5c7b" },
                    { 8, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(9801), "system", "<strong> Phí: </strong> 10.000đ <small>(dưới 5km)</small>", false, false, null, null, "7h - 11h", null, 1, "Delivery", "349520fd-ae93-4c04-81cb-12c4cd20a12f" },
                    { 9, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(9805), "system", "<strong> Phí: </strong> 10.000đ <small>(dưới 5km)</small>", false, false, null, null, "13h - 15h", null, 1, "Delivery", "bf5489e3-97b0-4a7f-88d4-d54417320163" },
                    { 10, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(9811), "system", "<strong>10.000đ <small>(dưới 5km)</small>", false, false, null, null, "3kg / 1 lần giặt", null, 1, "Delivery", "41ca71b2-d494-4075-9d9e-27932012b6e2" },
                    { 11, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(9821), "system", "<strong>Miễn phí vận chuyển </strong><small>(dưới 5km)</small>", false, false, null, null, "5kg / 1 lần giặt", null, 1, "Combo", "0d7a8624-3b46-4500-8255-55e647d200b4" },
                    { 12, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(9824), "system", "<strong>Miễn phí vận chuyển</strong>", false, false, null, null, "10kg / 1 lần giặt", null, 1, "Combo", "5185f7f6-7d20-4043-8a9a-ff0c23855800" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "IsPublished", "ModifiedDate", "ModifyUserId", "Name", "Note", "Prefix", "SortOrder", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 10, 14, 25, 30, 322, DateTimeKind.Local).AddTicks(7244), "system", false, true, null, null, "Huế", null, "", 1, "dbc322a9-c2a7-4822-ac82-c1c5a045914c" },
                    { 2, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(14), "system", false, true, null, null, "Đà Nẵng", null, "", 1, "66e5e27d-d4a0-494f-9779-2d17b063f823" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "ModifiedDate", "ModifyUserId", "Name", "Note", "UpdatedToken", "Value" },
                values: new object[] { "294b3061-f1a4-409b-ace2-51aec60fce8c", new DateTime(2019, 9, 10, 14, 25, 30, 328, DateTimeKind.Local).AddTicks(5441), "system", false, null, null, "Company", null, "b6281892-e895-49fc-ade8-64b1840b50d7", "{\"Brand\":\"GIẶT SẠCH\",\"Logo\":\"https://i.imgur.com/1CXl1BP.png\",\"Name\":\"Công Ty TNHH Thương Mại Công Nghệ GIAT SACH\",\"Address\":\"201/2, Lê Văn Việt, Quận 9, Hồ Chí Minh\",\"Email\":\"giatsach.vn@outlook.com\",\"Phone\":\"0866.667.670\",\"Website\":\"giatsach.vn\",\"Copyright\":\"<h4>Copyright © 2019 GiatSach</h4>\",\"Facebook\":\"https://www.facebook.com/giatsach.vn\",\"Instagram\":\"https://www.instagram.com/giatsach.vn\",\"Youtube\":\"https://www.youtube.com/giatsach.vn\",\"AppStore\":\"https://www.facebook.com/giatsach.vn\",\"GooglePlay\":\"https://www.facebook.com/giatsach.vn\",\"GoogleMap\":\" \"}" });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "IsPublished", "ModifiedDate", "ModifyUserId", "Name", "Note", "Prefix", "ProvinceId", "SortOrder", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 10, 14, 25, 30, 324, DateTimeKind.Local).AddTicks(8654), "system", false, true, null, null, "Huế", null, "Tp", 1, 1, "0681a3a8-2829-4959-9e25-0453077013fa" },
                    { 2, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(47), "system", false, true, null, null, "Liên Chiểu", null, "Quận", 2, 1, "9ee72bc8-3d1a-4a44-bcb0-d06f30c0d6ed" }
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "Combo", "CreateDate", "CreateUserId", "Description", "Highlight", "Image", "IsDeleted", "ModifiedDate", "ModifyUserId", "Name", "Note", "SortOrder", "Type", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2019, 9, 10, 14, 25, 30, 329, DateTimeKind.Local).AddTicks(1623), "system", "<ul class=\"content\"><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li></ul>", false, null, false, null, null, "Giặt thường 1", null, 1, "Laundry", "5ca2798f-bd10-475b-9fe5-12e67687b638" },
                    { 2, 11, new DateTime(2019, 9, 10, 14, 25, 30, 329, DateTimeKind.Local).AddTicks(1664), "system", "<ul class=\"content\"><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li></ul>", false, null, false, null, null, "Giặt thường 2", null, 1, "Laundry", "b92b098a-89f8-4900-a419-3f34d31ed5f8" },
                    { 3, 12, new DateTime(2019, 9, 10, 14, 25, 30, 329, DateTimeKind.Local).AddTicks(1671), "system", "<ul class=\"content\"><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li><li class=\"checked\"><span class=\"icon\"><i class=\"fa fa-check\"></i></span><divclass=\"text\">Unlimited private questions and answers</div></li></ul>", false, null, false, null, null, "Giặt thường 3", null, 1, "Laundry", "677f5aa4-d899-493e-a8b5-35761e30ff66" }
                });

            migrationBuilder.InsertData(
                table: "Ward",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "DistrictId", "IsDeleted", "IsPublished", "ModifiedDate", "ModifyUserId", "Name", "Note", "Prefix", "SortOrder", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 10, 14, 25, 30, 324, DateTimeKind.Local).AddTicks(9848), "system", 1, false, true, null, null, "An Hòa", null, "Phường", 1, "8692a509-0647-48a5-a505-fac6a58913b8" },
                    { 2, new DateTime(2019, 9, 10, 14, 25, 30, 324, DateTimeKind.Local).AddTicks(9880), "system", 1, false, true, null, null, "Phú Bình", null, "Phường", 1, "0c010fa8-25ef-4801-8b2e-470404c50538" },
                    { 3, new DateTime(2019, 9, 10, 14, 25, 30, 324, DateTimeKind.Local).AddTicks(9883), "system", 1, false, true, null, null, "Phú Hòa", null, "Phường", 1, "de6809c0-7298-48a2-aa7e-c3810b9ec5a6" },
                    { 4, new DateTime(2019, 9, 10, 14, 25, 30, 324, DateTimeKind.Local).AddTicks(9893), "system", 1, false, true, null, null, "Phú Thuận", null, "Phường", 1, "b4e6949b-8e22-40b4-8212-47c32f69682e" },
                    { 5, new DateTime(2019, 9, 10, 14, 25, 30, 324, DateTimeKind.Local).AddTicks(9896), "system", 1, false, true, null, null, "Tây Lộc", null, "Phường", 1, "163b8b16-3755-4ce4-a30f-a70623d69e42" },
                    { 6, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(63), "system", 2, false, true, null, null, "Hòa Khánh Bắc", null, "Phường", 1, "9e5ca7bb-9a80-469d-b9a7-f98f7143fdf3" },
                    { 7, new DateTime(2019, 9, 10, 14, 25, 30, 325, DateTimeKind.Local).AddTicks(66), "system", 2, false, true, null, null, "Hòa Khánh Nam", null, "Phường", 1, "eae624bb-cfe7-44e2-b59f-ac8a65f9e04d" }
                });
        }
    }
}
