using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Cf.Libs.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Phone = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: false),
                    Province = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: false),
                    District = table.Column<string>(nullable: true),
                    WardId = table.Column<int>(nullable: false),
                    Ward = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ModifyUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdatedToken = table.Column<string>(type: "varchar(50)", nullable: true),
                    Note = table.Column<string>(type: "varchar(300)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Method",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EnableDiscount = table.Column<bool>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ModifyUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdatedToken = table.Column<string>(type: "varchar(50)", nullable: true),
                    Note = table.Column<string>(type: "varchar(300)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Method", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Price",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ItemId = table.Column<int>(nullable: false),
                    ItemCode = table.Column<string>(nullable: true),
                    Rate = table.Column<decimal>(nullable: false),
                    Tax = table.Column<byte>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    DiscountRate = table.Column<decimal>(nullable: false),
                    Priority = table.Column<byte>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ApplyDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ModifyUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdatedToken = table.Column<string>(type: "varchar(50)", nullable: true),
                    Note = table.Column<string>(type: "varchar(300)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ModifyUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdatedToken = table.Column<string>(type: "varchar(50)", nullable: true),
                    Note = table.Column<string>(type: "varchar(300)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifyUserId = table.Column<string>(nullable: true),
                    UpdatedToken = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ModifyUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdatedToken = table.Column<string>(type: "varchar(50)", nullable: true),
                    Note = table.Column<string>(type: "varchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OrderCode = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: false),
                    ProvinceId = table.Column<int>(nullable: false),
                    ProvinceName = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: false),
                    DistrictName = table.Column<string>(nullable: true),
                    WardId = table.Column<int>(nullable: false),
                    WardName = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    DateOfReceipt = table.Column<DateTime>(nullable: false),
                    HoursOfReceipt = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ModifyUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdatedToken = table.Column<string>(type: "varchar(50)", nullable: true),
                    Note = table.Column<string>(type: "varchar(300)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Highlight = table.Column<bool>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Combo = table.Column<int>(nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ModifyUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdatedToken = table.Column<string>(type: "varchar(50)", nullable: true),
                    Note = table.Column<string>(type: "varchar(300)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Method_Combo",
                        column: x => x.Combo,
                        principalTable: "Method",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ModifyUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdatedToken = table.Column<string>(type: "varchar(50)", nullable: true),
                    Note = table.Column<string>(type: "varchar(300)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.Id);
                    table.ForeignKey(
                        name: "FK_District_Province_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Province",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LastPasswordChanged = table.Column<DateTime>(nullable: false),
                    UserProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    OrderId = table.Column<string>(nullable: true),
                    MethodId = table.Column<int>(nullable: false),
                    MethodName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ModifyUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdatedToken = table.Column<string>(type: "varchar(50)", nullable: true),
                    Note = table.Column<string>(type: "varchar(300)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ward",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    DistrictId = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    CreateUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp", nullable: true),
                    ModifyUserId = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdatedToken = table.Column<string>(type: "varchar(50)", nullable: true),
                    Note = table.Column<string>(type: "varchar(300)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ward_District_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "District",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    RoleId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Combo",
                table: "Item",
                column: "Combo");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AddressId",
                table: "Order",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserProfileId",
                table: "User",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId1",
                table: "UserRole",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_Ward_DistrictId",
                table: "Ward",
                column: "DistrictId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Price");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Ward");

            migrationBuilder.DropTable(
                name: "Method");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
