using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseAdminTemplate.DataAccess.Migrations
{
    public partial class addmigrationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExceptionLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkMenusPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkMenusPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkRolesPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkRolesPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkUsersRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkUsersRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayInMenu = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayInMenu = table.Column<bool>(type: "bit", nullable: false),
                    DisplayInPermissionTree = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoginDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LinkMenusPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "MenuId", "PermissionId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("76baab96-3592-4df0-b769-f62f7555e39f"), new DateTime(2020, 10, 13, 16, 4, 45, 128, DateTimeKind.Local).AddTicks(8846), null, true, new Guid("5fd17086-7645-4c49-8a52-37974b56b0a8"), new Guid("2675806c-1f9b-42de-8eb5-e09f502a51ab"), null },
                    { new Guid("995515b9-7503-4b1f-8582-b1cc4ae685bc"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3982), null, true, new Guid("116253b8-9a6e-4df7-99e2-1205d10dc188"), new Guid("7757797d-bb42-4b06-9857-559a717a0050"), null },
                    { new Guid("649d961a-ce79-4791-a544-7c86fd3fa1c6"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3766), null, true, new Guid("116253b8-9a6e-4df7-99e2-1205d10dc188"), new Guid("9c7a0f97-624d-44ae-adc8-d52a940a5e0c"), null },
                    { new Guid("8e3f227f-1141-4d8c-93c9-477239dd22c9"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3633), null, true, new Guid("116253b8-9a6e-4df7-99e2-1205d10dc188"), new Guid("9841fb9c-6932-4ac5-ae63-3d995976d822"), null },
                    { new Guid("82e7de40-7e6c-4cd7-86e3-b730286bc746"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3252), null, true, new Guid("116253b8-9a6e-4df7-99e2-1205d10dc188"), new Guid("0b3159b2-8982-4f98-8249-01f097a77cc6"), null },
                    { new Guid("c0298f18-c3a7-4fc8-a5ba-86f7dc134377"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(2924), null, true, new Guid("116253b8-9a6e-4df7-99e2-1205d10dc188"), new Guid("6c8e9dcb-cf4b-4e75-a62b-2926ba96c270"), null },
                    { new Guid("018c94ce-9e7d-4a70-bb2b-becfefa0102a"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3493), null, true, new Guid("116253b8-9a6e-4df7-99e2-1205d10dc188"), new Guid("3dacb97a-197b-4a85-b602-c0f90ec20a4e"), null },
                    { new Guid("b657b1ba-545f-4031-a073-b3b7ed1161b6"), new DateTime(2020, 10, 13, 16, 4, 45, 131, DateTimeKind.Local).AddTicks(9548), null, true, new Guid("c99508ca-fb4b-4cdc-aaa3-ddfc6d6ce359"), new Guid("ca5e2dd4-3a1d-463b-a1f8-164bba640e64"), null },
                    { new Guid("ddfd8325-0d64-4c93-86cf-1bb56f268530"), new DateTime(2020, 10, 13, 16, 4, 45, 131, DateTimeKind.Local).AddTicks(9390), null, true, new Guid("c99508ca-fb4b-4cdc-aaa3-ddfc6d6ce359"), new Guid("25b21837-0005-49da-94c5-fcff6f8c6413"), null },
                    { new Guid("a3bdf4dd-3144-4a3a-aae0-db02f0ad08a6"), new DateTime(2020, 10, 13, 16, 4, 45, 131, DateTimeKind.Local).AddTicks(8260), null, true, new Guid("c99508ca-fb4b-4cdc-aaa3-ddfc6d6ce359"), new Guid("c0586433-9b1f-400b-9956-324bd04cfe9f"), null },
                    { new Guid("730cd380-9610-46c2-851f-a9d666a0ef5c"), new DateTime(2020, 10, 13, 16, 4, 45, 131, DateTimeKind.Local).AddTicks(8028), null, true, new Guid("c99508ca-fb4b-4cdc-aaa3-ddfc6d6ce359"), new Guid("3130830d-7fa7-4b36-b560-2fefe8780a15"), null },
                    { new Guid("1bb156ee-7a3b-4fc3-b144-872610b9ef79"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(2772), null, true, new Guid("116253b8-9a6e-4df7-99e2-1205d10dc188"), new Guid("da8dcc35-d6ad-4b9e-aa99-dbb4af419d6d"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "PermissionId", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("21bcd498-8af9-40bb-a4ad-53e9d23712e5"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3332), null, true, new Guid("0b3159b2-8982-4f98-8249-01f097a77cc6"), new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), null },
                    { new Guid("59dd00e6-e581-4449-b5cc-f1bc6c551acb"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(4005), null, true, new Guid("7757797d-bb42-4b06-9857-559a717a0050"), new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), null },
                    { new Guid("95dc93ad-b52f-4d7b-b51b-8f8473e2e5d7"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3789), null, true, new Guid("9c7a0f97-624d-44ae-adc8-d52a940a5e0c"), new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), null },
                    { new Guid("c4a8a4c1-5939-4f8e-baf5-8aadf63e26eb"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3656), null, true, new Guid("9841fb9c-6932-4ac5-ae63-3d995976d822"), new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), null },
                    { new Guid("bdbe20ad-04b7-4834-95d2-01cc8d37ceac"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(2947), null, true, new Guid("6c8e9dcb-cf4b-4e75-a62b-2926ba96c270"), new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), null },
                    { new Guid("77edef01-738f-4dec-92e2-4337387384c2"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3520), null, true, new Guid("3dacb97a-197b-4a85-b602-c0f90ec20a4e"), new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), null },
                    { new Guid("7d033df2-82b6-49dd-9126-395ed9a7e010"), new DateTime(2020, 10, 13, 16, 4, 45, 131, DateTimeKind.Local).AddTicks(9573), null, true, new Guid("ca5e2dd4-3a1d-463b-a1f8-164bba640e64"), new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), null },
                    { new Guid("54071516-f4cd-44e6-a542-fb6666ac87ef"), new DateTime(2020, 10, 13, 16, 4, 45, 131, DateTimeKind.Local).AddTicks(9417), null, true, new Guid("25b21837-0005-49da-94c5-fcff6f8c6413"), new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), null },
                    { new Guid("d90cc3ad-77aa-46c8-a8c2-1ab851d1acec"), new DateTime(2020, 10, 13, 16, 4, 45, 131, DateTimeKind.Local).AddTicks(8286), null, true, new Guid("c0586433-9b1f-400b-9956-324bd04cfe9f"), new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), null },
                    { new Guid("f47d9ee0-4ddf-4dbd-93fe-943ca473a940"), new DateTime(2020, 10, 13, 16, 4, 45, 131, DateTimeKind.Local).AddTicks(8092), null, true, new Guid("3130830d-7fa7-4b36-b560-2fefe8780a15"), new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), null },
                    { new Guid("bb16f0c1-5290-4c26-8f6d-ee28156cf077"), new DateTime(2020, 10, 13, 16, 4, 45, 129, DateTimeKind.Local).AddTicks(806), null, true, new Guid("2675806c-1f9b-42de-8eb5-e09f502a51ab"), new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), null },
                    { new Guid("a5cbe94a-7aa6-4f5e-b078-2e0eb48d1bb5"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(2804), null, true, new Guid("da8dcc35-d6ad-4b9e-aa99-dbb4af419d6d"), new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkUsersRoles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "RoleId", "UpdateDate", "UserId" },
                values: new object[] { new Guid("22715a65-9f0d-446f-bc35-ac7ce6f7d4f4"), new DateTime(2020, 10, 13, 16, 4, 45, 126, DateTimeKind.Local).AddTicks(68), null, true, new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), null, new Guid("23a92a78-1077-4913-ac2d-666c6836406c") });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ControllerName", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayName", "IsActive", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("5fd17086-7645-4c49-8a52-37974b56b0a8"), "ExceptionLog", new DateTime(2020, 10, 13, 16, 4, 45, 127, DateTimeKind.Local).AddTicks(7206), null, true, "Hata Kayıtları", true, null },
                    { new Guid("c99508ca-fb4b-4cdc-aaa3-ddfc6d6ce359"), "Role", new DateTime(2020, 10, 13, 16, 4, 45, 131, DateTimeKind.Local).AddTicks(6720), null, true, "Rol Yönetimi", true, null },
                    { new Guid("116253b8-9a6e-4df7-99e2-1205d10dc188"), "User", new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(2031), null, true, "Kullanıcı Yönetimi", true, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayInPermissionTree", "DisplayName", "IsActive", "MethodName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("7757797d-bb42-4b06-9857-559a717a0050"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3945), null, false, false, "Sil", true, "Delete", null },
                    { new Guid("9c7a0f97-624d-44ae-adc8-d52a940a5e0c"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3728), null, true, true, "Ekle", true, "Create", null },
                    { new Guid("9841fb9c-6932-4ac5-ae63-3d995976d822"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3596), null, false, true, "Kurtar", true, "Restore", null },
                    { new Guid("3dacb97a-197b-4a85-b602-c0f90ec20a4e"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3444), null, false, true, "Deaktif Yap", true, "Deactivate", null },
                    { new Guid("0b3159b2-8982-4f98-8249-01f097a77cc6"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(3202), null, false, true, "Güncelle", true, "Edit", null },
                    { new Guid("6c8e9dcb-cf4b-4e75-a62b-2926ba96c270"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(2885), null, true, true, "Deaktif Kullanıcı Listesi", true, "DeactivatedList", null },
                    { new Guid("3130830d-7fa7-4b36-b560-2fefe8780a15"), new DateTime(2020, 10, 13, 16, 4, 45, 131, DateTimeKind.Local).AddTicks(7889), null, true, true, "Listele", true, "List", null },
                    { new Guid("ca5e2dd4-3a1d-463b-a1f8-164bba640e64"), new DateTime(2020, 10, 13, 16, 4, 45, 131, DateTimeKind.Local).AddTicks(9495), null, false, true, "Güncelle", true, "Edit", null },
                    { new Guid("25b21837-0005-49da-94c5-fcff6f8c6413"), new DateTime(2020, 10, 13, 16, 4, 45, 131, DateTimeKind.Local).AddTicks(9307), null, false, false, "Sil", true, "Delete", null },
                    { new Guid("c0586433-9b1f-400b-9956-324bd04cfe9f"), new DateTime(2020, 10, 13, 16, 4, 45, 131, DateTimeKind.Local).AddTicks(8219), null, true, true, "Ekle", true, "Create", null },
                    { new Guid("2675806c-1f9b-42de-8eb5-e09f502a51ab"), new DateTime(2020, 10, 13, 16, 4, 45, 128, DateTimeKind.Local).AddTicks(5073), null, true, true, "Listele", true, "List", null },
                    { new Guid("da8dcc35-d6ad-4b9e-aa99-dbb4af419d6d"), new DateTime(2020, 10, 13, 16, 4, 45, 132, DateTimeKind.Local).AddTicks(2708), null, true, true, "Aktif Kullanıcı Listesi", true, "ActiveList", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdateDate" },
                values: new object[] { new Guid("3e9113cb-a2e5-4083-90f3-7aa6a26670e9"), new DateTime(2020, 10, 13, 16, 4, 45, 114, DateTimeKind.Local).AddTicks(7189), null, "It has all permissions", true, "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsActive", "LastLoginDateTime", "Name", "Password", "Phone", "Surname", "UpdateDate" },
                values: new object[] { new Guid("23a92a78-1077-4913-ac2d-666c6836406c"), new DateTime(2020, 10, 13, 16, 4, 45, 125, DateTimeKind.Local).AddTicks(8751), null, "admin", true, null, "admin", "D666+2ai9e6AyaRseO19bA==", null, "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExceptionLogs");

            migrationBuilder.DropTable(
                name: "LinkMenusPermissions");

            migrationBuilder.DropTable(
                name: "LinkRolesPermissions");

            migrationBuilder.DropTable(
                name: "LinkUsersRoles");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "PasswordResets");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
