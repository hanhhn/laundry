using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    Note = table.Column<string>(type: "varchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BillDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifyUserId = table.Column<string>(nullable: true),
                    UpdatedToken = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifyUserId = table.Column<string>(nullable: true),
                    UpdatedToken = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifyUserId = table.Column<string>(nullable: true),
                    UpdatedToken = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserId = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifyUserId = table.Column<string>(nullable: true),
                    UpdatedToken = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Method",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Highlight = table.Column<bool>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Delivery = table.Column<int>(nullable: false),
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
                        name: "FK_Item_Method_Delivery",
                        column: x => x.Delivery,
                        principalTable: "Method",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                    { 1, new DateTime(2019, 9, 10, 13, 17, 21, 455, DateTimeKind.Local).AddTicks(3526), "system", "Giặt hấp", false, false, null, null, "Giặt hấp", null, 1, "Clean", "0ce446fb-8efb-42f9-bf00-71736cfb4a7d" },
                    { 2, new DateTime(2019, 9, 10, 13, 17, 21, 455, DateTimeKind.Local).AddTicks(3626), "system", "Giặt sấy", false, false, null, null, "Giặt sấy", null, 1, "Clean", "3d7300fe-5879-4cbd-82f8-22a29f021d9c" },
                    { 3, new DateTime(2019, 9, 10, 13, 17, 21, 455, DateTimeKind.Local).AddTicks(3632), "system", "Chỉ giặt", false, false, null, null, "Chỉ giặt", null, 1, "Clean", "dc2abbfe-14f0-47b8-a677-ff781e68d757" },
                    { 4, new DateTime(2019, 9, 10, 13, 17, 21, 455, DateTimeKind.Local).AddTicks(3642), "system", "Chỉ sấy", false, false, null, null, "Chỉ sấy", null, 1, "Dry", "21297534-2294-4771-a2bd-120b9985941c" },
                    { 5, new DateTime(2019, 9, 10, 13, 17, 21, 455, DateTimeKind.Local).AddTicks(3648), "system", "Comfort", false, false, null, null, "Comfort", null, 1, "Soft", "75c0a624-f84f-4851-9708-2cccf41ac47d" },
                    { 6, new DateTime(2019, 9, 10, 13, 17, 21, 455, DateTimeKind.Local).AddTicks(3651), "system", "Downy", false, false, null, null, "Downy", null, 1, "Soft", "9f15dacf-2695-4f74-9923-7c59e5ba448c" },
                    { 7, new DateTime(2019, 9, 10, 13, 17, 21, 455, DateTimeKind.Local).AddTicks(3655), "system", "Ủi hơi nước miển phí", false, false, null, null, "Ủi hơi nước miển phí", null, 1, "Straight", "83072092-a975-409f-974f-16e1f7aa5a95" },
                    { 8, new DateTime(2019, 9, 10, 13, 17, 21, 455, DateTimeKind.Local).AddTicks(3658), "system", "<strong> Phí: </strong> 10.000đ <small>(dưới 5km)</small>", false, false, null, null, "7h - 11h", null, 1, "Delivery", "569a1ca0-9d41-4d9d-aa8e-83e00851b864" },
                    { 9, new DateTime(2019, 9, 10, 13, 17, 21, 455, DateTimeKind.Local).AddTicks(3661), "system", "<strong> Phí: </strong> 10.000đ <small>(dưới 5km)</small>", false, false, null, null, "13h - 15h", null, 1, "Delivery", "61ce950a-1d6a-463f-8d99-327fa677eb3d" },
                    { 10, new DateTime(2019, 9, 10, 13, 17, 21, 455, DateTimeKind.Local).AddTicks(3664), "system", "<strong>10.000đ <small>(dưới 5km)</small>", false, false, null, null, "3kg / 1 lần giặt", null, 1, "Delivery", "fdf4465a-5d41-4572-810e-7396639d91b8" },
                    { 11, new DateTime(2019, 9, 10, 13, 17, 21, 455, DateTimeKind.Local).AddTicks(3671), "system", "<strong>Miễn phí vận chuyển </strong><small>(dưới 5km)</small>", false, false, null, null, "5kg / 1 lần giặt", null, 1, "Delivery", "8c1814b5-77d9-4009-9e14-841c12b69a9d" },
                    { 12, new DateTime(2019, 9, 10, 13, 17, 21, 455, DateTimeKind.Local).AddTicks(3674), "system", "<strong>Miễn phí vận chuyển</strong>", false, false, null, null, "10kg / 1 lần giặt", null, 1, "Delivery", "7644f17a-68ad-4994-bcfc-0fd123704a36" }
                });

            migrationBuilder.InsertData(
                table: "Province",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "IsPublished", "ModifiedDate", "ModifyUserId", "Name", "Note", "Prefix", "SortOrder", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 10, 13, 17, 21, 452, DateTimeKind.Local).AddTicks(2435), "system", false, true, null, null, "Huế", null, "", 1, "f62dc66f-52bd-43a0-b280-391855ee3fca" },
                    { 2, new DateTime(2019, 9, 10, 13, 17, 21, 454, DateTimeKind.Local).AddTicks(3637), "system", false, true, null, null, "Đà Nẵng", null, "", 1, "9a2b4336-b35a-42f2-a206-de29b4773fbd" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "ModifiedDate", "ModifyUserId", "Name", "Note", "UpdatedToken", "Value" },
                values: new object[] { "5c69194a-7309-48a8-9210-9232d8e0240d", new DateTime(2019, 9, 10, 13, 17, 21, 455, DateTimeKind.Local).AddTicks(9788), "system", false, null, null, "Company", null, "5581b913-d793-493c-8344-ca911c23f5f3", "{\"Brand\":\"GIẶT SẠCH\",\"Logo\":\"https://i.imgur.com/1CXl1BP.png\",\"Name\":\"Công Ty TNHH Thương Mại Công Nghệ GIAT SACH\",\"Address\":\"201/2, Lê Văn Việt, Quận 9, Hồ Chí Minh\",\"Email\":\"giatsach.vn@outlook.com\",\"Phone\":\"0866.667.670\",\"Website\":\"giatsach.vn\",\"Copyright\":\"<h4>Copyright © 2019 GiatSach</h4>\",\"Facebook\":\"https://www.facebook.com/giatsach.vn\",\"Instagram\":\"https://www.instagram.com/giatsach.vn\",\"Youtube\":\"https://www.youtube.com/giatsach.vn\",\"AppStore\":\"https://www.facebook.com/giatsach.vn\",\"GooglePlay\":\"https://www.facebook.com/giatsach.vn\",\"GoogleMap\":\" \"}" });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "IsPublished", "ModifiedDate", "ModifyUserId", "Name", "Note", "Prefix", "ProvinceId", "SortOrder", "UpdatedToken" },
                values: new object[] { 1, new DateTime(2019, 9, 10, 13, 17, 21, 454, DateTimeKind.Local).AddTicks(2209), "system", false, true, null, null, "Huế", null, "Tp", 1, 1, "bfd0d75f-04ad-410c-be5e-3fd194499293" });

            migrationBuilder.InsertData(
                table: "District",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "IsDeleted", "IsPublished", "ModifiedDate", "ModifyUserId", "Name", "Note", "Prefix", "ProvinceId", "SortOrder", "UpdatedToken" },
                values: new object[] { 2, new DateTime(2019, 9, 10, 13, 17, 21, 454, DateTimeKind.Local).AddTicks(3672), "system", false, true, null, null, "Liên Chiểu", null, "Quận", 2, 1, "7a0a25f5-d90d-4a21-b832-dc3e17c22d65" });

            migrationBuilder.InsertData(
                table: "Ward",
                columns: new[] { "Id", "CreateDate", "CreateUserId", "DistrictId", "IsDeleted", "IsPublished", "ModifiedDate", "ModifyUserId", "Name", "Note", "Prefix", "SortOrder", "UpdatedToken" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 9, 10, 13, 17, 21, 454, DateTimeKind.Local).AddTicks(3438), "system", 1, false, true, null, null, "An Hòa", null, "Phường", 1, "6c2608f8-19cf-44a6-a870-a3eed4b5acf7" },
                    { 2, new DateTime(2019, 9, 10, 13, 17, 21, 454, DateTimeKind.Local).AddTicks(3470), "system", 1, false, true, null, null, "Phú Bình", null, "Phường", 1, "0d0992cd-4743-4ffa-abbc-ce9f9f3b8fb8" },
                    { 3, new DateTime(2019, 9, 10, 13, 17, 21, 454, DateTimeKind.Local).AddTicks(3477), "system", 1, false, true, null, null, "Phú Hòa", null, "Phường", 1, "cb505b5a-3690-4390-aaf1-ff7f57623881" },
                    { 4, new DateTime(2019, 9, 10, 13, 17, 21, 454, DateTimeKind.Local).AddTicks(3480), "system", 1, false, true, null, null, "Phú Thuận", null, "Phường", 1, "ff4d087a-8d30-48c6-aab3-18cc7db6ebe2" },
                    { 5, new DateTime(2019, 9, 10, 13, 17, 21, 454, DateTimeKind.Local).AddTicks(3489), "system", 1, false, true, null, null, "Tây Lộc", null, "Phường", 1, "c3ad04e6-ee9b-46cc-9e9a-b5e284073538" },
                    { 6, new DateTime(2019, 9, 10, 13, 17, 21, 454, DateTimeKind.Local).AddTicks(3685), "system", 2, false, true, null, null, "Hòa Khánh Bắc", null, "Phường", 1, "8107539f-fdc8-4dc7-b4d2-89d800dfe405" },
                    { 7, new DateTime(2019, 9, 10, 13, 17, 21, 454, DateTimeKind.Local).AddTicks(3688), "system", 2, false, true, null, null, "Hòa Khánh Nam", null, "Phường", 1, "3ac6dbd5-fd5f-41a9-84d2-b74d7d9057aa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Delivery",
                table: "Item",
                column: "Delivery");

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
                name: "BillDetails");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Invoices");

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
