using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseAdminTemplate.DataAccess.Migrations
{
    public partial class Initial : Migration
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
                    { new Guid("6dd7107d-9765-4e52-b00d-a80aef132f70"), new DateTime(2020, 10, 13, 2, 59, 32, 109, DateTimeKind.Local).AddTicks(1018), null, true, new Guid("3da28c59-0674-48a8-a9d5-b049ccf34041"), new Guid("3c9eb0c7-963c-4860-b543-cd60737688c5"), null },
                    { new Guid("2eb2a6d8-da65-48f5-9ee0-1ca5858eb3b6"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(3941), null, true, new Guid("9ad20195-5cac-41b7-8436-ea4237a42cd2"), new Guid("92628df5-0c29-482b-baa2-02992ba67742"), null },
                    { new Guid("0e13c03a-5fc8-40b4-8f84-55fdcbf261da"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(3638), null, true, new Guid("9ad20195-5cac-41b7-8436-ea4237a42cd2"), new Guid("062308e0-f82b-48fb-aa1e-8fd64a1077f6"), null },
                    { new Guid("a6a342d5-5f56-4d66-9e50-27c02750413c"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(3383), null, true, new Guid("9ad20195-5cac-41b7-8436-ea4237a42cd2"), new Guid("715a2eac-7bd6-48da-b9a6-62f933052100"), null },
                    { new Guid("e674010a-f7b5-4e31-8374-e0a8a1fb5646"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(2550), null, true, new Guid("9ad20195-5cac-41b7-8436-ea4237a42cd2"), new Guid("46c434e2-145c-48e7-a740-62cd0a6dabe4"), null },
                    { new Guid("9134537d-103c-4432-a939-c9217fdeca93"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(1952), null, true, new Guid("9ad20195-5cac-41b7-8436-ea4237a42cd2"), new Guid("039bd732-bfd0-4ff8-be9c-e43d842afab7"), null },
                    { new Guid("7719d471-def1-446a-8567-b407a31608f1"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(2846), null, true, new Guid("9ad20195-5cac-41b7-8436-ea4237a42cd2"), new Guid("9833008c-fc4d-4eb3-a939-ab1c53676f5f"), null },
                    { new Guid("a4de9ac9-fd27-4462-a460-d9bcb4c3d308"), new DateTime(2020, 10, 13, 2, 59, 32, 113, DateTimeKind.Local).AddTicks(5001), null, true, new Guid("f0c0b6e4-df49-4a3a-99b2-6e8a68ae4f87"), new Guid("689fb0c7-583d-4ece-b1fe-4c6e861ce8b1"), null },
                    { new Guid("0b145c94-830a-4b32-b451-f345544cc5e7"), new DateTime(2020, 10, 13, 2, 59, 32, 113, DateTimeKind.Local).AddTicks(4580), null, true, new Guid("f0c0b6e4-df49-4a3a-99b2-6e8a68ae4f87"), new Guid("55e7ac34-fee4-460a-8f04-e32bcb1b365a"), null },
                    { new Guid("52f91d25-a4ad-4f3f-b63e-8f8348a3e9db"), new DateTime(2020, 10, 13, 2, 59, 32, 113, DateTimeKind.Local).AddTicks(1198), null, true, new Guid("f0c0b6e4-df49-4a3a-99b2-6e8a68ae4f87"), new Guid("1150c590-9510-44fb-b983-8384625c9eba"), null },
                    { new Guid("3f53d768-7f50-4b37-8d9e-e0b5418afe94"), new DateTime(2020, 10, 13, 2, 59, 32, 113, DateTimeKind.Local).AddTicks(703), null, true, new Guid("f0c0b6e4-df49-4a3a-99b2-6e8a68ae4f87"), new Guid("c0fdd95d-6070-4801-99ff-1c0d450d4443"), null },
                    { new Guid("eb57e394-e3c3-459f-8670-44856bdd1485"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(1654), null, true, new Guid("9ad20195-5cac-41b7-8436-ea4237a42cd2"), new Guid("281f7f51-bd43-407b-82ac-a54a2839dbd6"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "PermissionId", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("85fc675a-374d-4224-b77a-9f23780aa0ee"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(2595), null, true, new Guid("46c434e2-145c-48e7-a740-62cd0a6dabe4"), new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), null },
                    { new Guid("3805f014-c2ee-4827-9003-bbd0245fe297"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(3983), null, true, new Guid("92628df5-0c29-482b-baa2-02992ba67742"), new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), null },
                    { new Guid("0f9021c0-a621-48cc-80f8-983463ae3703"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(3684), null, true, new Guid("062308e0-f82b-48fb-aa1e-8fd64a1077f6"), new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), null },
                    { new Guid("f7372f2d-57d6-417e-ac8f-8e4fd6ff9da5"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(3427), null, true, new Guid("715a2eac-7bd6-48da-b9a6-62f933052100"), new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), null },
                    { new Guid("2be4c772-37a4-487c-8d6f-5b0369d3b8f6"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(1995), null, true, new Guid("039bd732-bfd0-4ff8-be9c-e43d842afab7"), new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), null },
                    { new Guid("4392cd70-3722-478e-89ec-a072e6053c4d"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(2891), null, true, new Guid("9833008c-fc4d-4eb3-a939-ab1c53676f5f"), new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), null },
                    { new Guid("832826bb-8a9f-4825-9f20-be3255cd1f1c"), new DateTime(2020, 10, 13, 2, 59, 32, 113, DateTimeKind.Local).AddTicks(5054), null, true, new Guid("689fb0c7-583d-4ece-b1fe-4c6e861ce8b1"), new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), null },
                    { new Guid("3f8f7728-a3aa-43e7-aa49-5857620b6e87"), new DateTime(2020, 10, 13, 2, 59, 32, 113, DateTimeKind.Local).AddTicks(4658), null, true, new Guid("55e7ac34-fee4-460a-8f04-e32bcb1b365a"), new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), null },
                    { new Guid("5a89a23e-de5c-4f93-aca8-16c0f22652e4"), new DateTime(2020, 10, 13, 2, 59, 32, 113, DateTimeKind.Local).AddTicks(1240), null, true, new Guid("1150c590-9510-44fb-b983-8384625c9eba"), new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), null },
                    { new Guid("8c2aab10-e0ee-40bb-98b8-72fffa723e4d"), new DateTime(2020, 10, 13, 2, 59, 32, 113, DateTimeKind.Local).AddTicks(852), null, true, new Guid("c0fdd95d-6070-4801-99ff-1c0d450d4443"), new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), null },
                    { new Guid("4dd92f80-c998-49c6-bbef-2e038456cd64"), new DateTime(2020, 10, 13, 2, 59, 32, 109, DateTimeKind.Local).AddTicks(4478), null, true, new Guid("3c9eb0c7-963c-4860-b543-cd60737688c5"), new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), null },
                    { new Guid("3d9cd1c2-76f9-419e-98a3-e67bb6941543"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(1708), null, true, new Guid("281f7f51-bd43-407b-82ac-a54a2839dbd6"), new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkUsersRoles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "RoleId", "UpdateDate", "UserId" },
                values: new object[] { new Guid("332166ad-966b-4c60-858a-b761c8c4f667"), new DateTime(2020, 10, 13, 2, 59, 32, 105, DateTimeKind.Local).AddTicks(5321), null, true, new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), null, new Guid("846bbff5-9675-432a-8102-99f6e3762d5d") });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ControllerName", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayName", "IsActive", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("3da28c59-0674-48a8-a9d5-b049ccf34041"), "ExceptionLog", new DateTime(2020, 10, 13, 2, 59, 32, 107, DateTimeKind.Local).AddTicks(7687), null, true, "Hata Kayıtları", true, null },
                    { new Guid("f0c0b6e4-df49-4a3a-99b2-6e8a68ae4f87"), "Role", new DateTime(2020, 10, 13, 2, 59, 32, 112, DateTimeKind.Local).AddTicks(7701), null, true, "Rol Yönetimi", true, null },
                    { new Guid("9ad20195-5cac-41b7-8436-ea4237a42cd2"), "User", new DateTime(2020, 10, 13, 2, 59, 32, 113, DateTimeKind.Local).AddTicks(9814), null, true, "Kullanıcı Yönetimi", true, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayInPermissionTree", "DisplayName", "IsActive", "MethodName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("92628df5-0c29-482b-baa2-02992ba67742"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(3872), null, false, false, "Sil", true, "Delete", null },
                    { new Guid("062308e0-f82b-48fb-aa1e-8fd64a1077f6"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(3576), null, true, true, "Ekle", true, "Create", null },
                    { new Guid("715a2eac-7bd6-48da-b9a6-62f933052100"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(3291), null, false, true, "Kurtar", true, "Restore", null },
                    { new Guid("9833008c-fc4d-4eb3-a939-ab1c53676f5f"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(2760), null, false, true, "Deaktif Yap", true, "Deactivate", null },
                    { new Guid("46c434e2-145c-48e7-a740-62cd0a6dabe4"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(2435), null, false, true, "Güncelle", true, "Edit", null },
                    { new Guid("039bd732-bfd0-4ff8-be9c-e43d842afab7"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(1876), null, true, true, "Deaktif Kullanıcı Listesi", true, "DeactivatedList", null },
                    { new Guid("c0fdd95d-6070-4801-99ff-1c0d450d4443"), new DateTime(2020, 10, 13, 2, 59, 32, 113, DateTimeKind.Local).AddTicks(318), null, true, true, "Listele", true, "List", null },
                    { new Guid("689fb0c7-583d-4ece-b1fe-4c6e861ce8b1"), new DateTime(2020, 10, 13, 2, 59, 32, 113, DateTimeKind.Local).AddTicks(4881), null, false, true, "Güncelle", true, "Edit", null },
                    { new Guid("55e7ac34-fee4-460a-8f04-e32bcb1b365a"), new DateTime(2020, 10, 13, 2, 59, 32, 113, DateTimeKind.Local).AddTicks(4401), null, false, false, "Sil", true, "Delete", null },
                    { new Guid("1150c590-9510-44fb-b983-8384625c9eba"), new DateTime(2020, 10, 13, 2, 59, 32, 113, DateTimeKind.Local).AddTicks(1117), null, true, true, "Ekle", true, "Create", null },
                    { new Guid("3c9eb0c7-963c-4860-b543-cd60737688c5"), new DateTime(2020, 10, 13, 2, 59, 32, 108, DateTimeKind.Local).AddTicks(6385), null, true, true, "Listele", true, "List", null },
                    { new Guid("281f7f51-bd43-407b-82ac-a54a2839dbd6"), new DateTime(2020, 10, 13, 2, 59, 32, 114, DateTimeKind.Local).AddTicks(1479), null, true, true, "Aktif Kullanıcı Listesi", true, "ActiveList", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdateDate" },
                values: new object[] { new Guid("ae65f69f-f797-44c2-bbbb-70f7896cface"), new DateTime(2020, 10, 13, 2, 59, 32, 78, DateTimeKind.Local).AddTicks(8686), null, "It has all permissions", true, "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsActive", "LastLoginDateTime", "Name", "Password", "Phone", "Surname", "UpdateDate" },
                values: new object[] { new Guid("846bbff5-9675-432a-8102-99f6e3762d5d"), new DateTime(2020, 10, 13, 2, 59, 32, 105, DateTimeKind.Local).AddTicks(2836), null, "admin", true, null, "admin", "D666+2ai9e6AyaRseO19bA==", null, "admin", null });
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
