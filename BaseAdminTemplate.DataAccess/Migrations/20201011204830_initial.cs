using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseAdminTemplate.DataAccess.Migrations
{
    public partial class initial : Migration
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
                    { new Guid("778e6267-6983-47f9-9559-3e840881af64"), new DateTime(2020, 10, 11, 23, 48, 29, 652, DateTimeKind.Local).AddTicks(2253), null, true, new Guid("24cda74c-5c4e-4d20-b726-6f1ecff7c026"), new Guid("172b12f4-1a00-4d9c-afaf-efbf098f4d35"), null },
                    { new Guid("65879978-9a51-42d1-9d97-ea5c11743e2a"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(7529), null, true, new Guid("bb650e90-d95d-4c99-a302-6c7f8fc88e3c"), new Guid("69bf3244-96a4-4d0b-8c5d-4b1f22a3649d"), null },
                    { new Guid("bb4b1c91-bb5d-4bb1-b34b-b88d6057db28"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(7090), null, true, new Guid("bb650e90-d95d-4c99-a302-6c7f8fc88e3c"), new Guid("2809fb83-e3f7-4794-a24c-95ac7bf2019c"), null },
                    { new Guid("f7898737-f26d-4768-bba3-266715e5e032"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(6583), null, true, new Guid("bb650e90-d95d-4c99-a302-6c7f8fc88e3c"), new Guid("3653cd3a-3362-4c03-ad41-b858ef091e3b"), null },
                    { new Guid("0fa5966a-3cae-4a18-9a0c-bddf6d3d2826"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(5881), null, true, new Guid("bb650e90-d95d-4c99-a302-6c7f8fc88e3c"), new Guid("344c4e45-e265-46d5-b281-e5eefe507352"), null },
                    { new Guid("b4f7cdf1-d25c-4930-9bad-f02dc3110f69"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(5147), null, true, new Guid("bb650e90-d95d-4c99-a302-6c7f8fc88e3c"), new Guid("1cc2d977-8d74-474c-ad15-7273c0e2ccbb"), null },
                    { new Guid("d1dbc0cc-f7a2-4e6f-9a58-3fead6cd7d6c"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(6259), null, true, new Guid("bb650e90-d95d-4c99-a302-6c7f8fc88e3c"), new Guid("f31e1296-82a5-48a8-bb43-ad5b10257992"), null },
                    { new Guid("dfcb16b1-86fd-42fa-ad5e-a204e08eedde"), new DateTime(2020, 10, 11, 23, 48, 29, 658, DateTimeKind.Local).AddTicks(6286), null, true, new Guid("a758e699-93bc-4461-abaf-7c8bfebed2df"), new Guid("a50bf3d2-fe25-4472-a08b-ed4e1857875f"), null },
                    { new Guid("4ab6c38d-70bc-4ee2-a3d6-b23d544512dd"), new DateTime(2020, 10, 11, 23, 48, 29, 658, DateTimeKind.Local).AddTicks(5709), null, true, new Guid("a758e699-93bc-4461-abaf-7c8bfebed2df"), new Guid("83bb92d7-67d1-4d60-836d-3eb7d3a8f044"), null },
                    { new Guid("cf963040-aade-4e0d-b1bc-eebeba55fa9f"), new DateTime(2020, 10, 11, 23, 48, 29, 658, DateTimeKind.Local).AddTicks(2398), null, true, new Guid("a758e699-93bc-4461-abaf-7c8bfebed2df"), new Guid("850785ea-257c-42b2-b870-28f780a022bd"), null },
                    { new Guid("8d9da8f2-80c5-425d-9cf5-0a22a73f48c4"), new DateTime(2020, 10, 11, 23, 48, 29, 658, DateTimeKind.Local).AddTicks(2007), null, true, new Guid("a758e699-93bc-4461-abaf-7c8bfebed2df"), new Guid("55b7168f-79ad-4e15-857d-2b741bbd5ad6"), null },
                    { new Guid("8f0381ea-c0e3-46f6-ab18-297660c7e76d"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(4697), null, true, new Guid("bb650e90-d95d-4c99-a302-6c7f8fc88e3c"), new Guid("8b2b8312-25d4-4f36-8353-c627371e3736"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "PermissionId", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("8906d8bd-bbcb-42ac-86c2-ac7304c7f198"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(5964), null, true, new Guid("344c4e45-e265-46d5-b281-e5eefe507352"), new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), null },
                    { new Guid("679d7484-86c0-4d75-a03c-56221c7fff73"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(7591), null, true, new Guid("69bf3244-96a4-4d0b-8c5d-4b1f22a3649d"), new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), null },
                    { new Guid("67b51963-7805-4bb0-9707-5ac89ed97e66"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(7166), null, true, new Guid("2809fb83-e3f7-4794-a24c-95ac7bf2019c"), new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), null },
                    { new Guid("e18816b9-7a21-4752-b365-9118b9d9386a"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(6645), null, true, new Guid("3653cd3a-3362-4c03-ad41-b858ef091e3b"), new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), null },
                    { new Guid("bd5d12c3-0798-4cae-99ea-0041b136e724"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(5212), null, true, new Guid("1cc2d977-8d74-474c-ad15-7273c0e2ccbb"), new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), null },
                    { new Guid("d138d659-1434-4438-a39f-e4072d040ab0"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(6335), null, true, new Guid("f31e1296-82a5-48a8-bb43-ad5b10257992"), new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), null },
                    { new Guid("b549ddb4-3e97-4538-9ea4-9f707689d402"), new DateTime(2020, 10, 11, 23, 48, 29, 658, DateTimeKind.Local).AddTicks(6359), null, true, new Guid("a50bf3d2-fe25-4472-a08b-ed4e1857875f"), new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), null },
                    { new Guid("02ff6bad-500c-4803-b938-8bdc3d8a90bb"), new DateTime(2020, 10, 11, 23, 48, 29, 658, DateTimeKind.Local).AddTicks(5792), null, true, new Guid("83bb92d7-67d1-4d60-836d-3eb7d3a8f044"), new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), null },
                    { new Guid("ac961d1c-49ac-4532-8614-4d105fe855cb"), new DateTime(2020, 10, 11, 23, 48, 29, 658, DateTimeKind.Local).AddTicks(2463), null, true, new Guid("850785ea-257c-42b2-b870-28f780a022bd"), new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), null },
                    { new Guid("91f89cd6-2585-4c1f-adef-9990116a7e8f"), new DateTime(2020, 10, 11, 23, 48, 29, 658, DateTimeKind.Local).AddTicks(2108), null, true, new Guid("55b7168f-79ad-4e15-857d-2b741bbd5ad6"), new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), null },
                    { new Guid("6288f6f3-0fbd-4e7d-adf9-d44b5ee22162"), new DateTime(2020, 10, 11, 23, 48, 29, 652, DateTimeKind.Local).AddTicks(5797), null, true, new Guid("172b12f4-1a00-4d9c-afaf-efbf098f4d35"), new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), null },
                    { new Guid("8e0a1122-b0ef-487a-b4d2-6f26217e6d87"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(4790), null, true, new Guid("8b2b8312-25d4-4f36-8353-c627371e3736"), new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkUsersRoles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "RoleId", "UpdateDate", "UserId" },
                values: new object[] { new Guid("33011507-c68b-4c62-9bff-993349e45c31"), new DateTime(2020, 10, 11, 23, 48, 29, 647, DateTimeKind.Local).AddTicks(3290), null, true, new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), null, new Guid("6f2b5efd-2e83-4b6e-b28b-7be3c58018ac") });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ControllerName", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayName", "IsActive", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("24cda74c-5c4e-4d20-b726-6f1ecff7c026"), "ExceptionLog", new DateTime(2020, 10, 11, 23, 48, 29, 650, DateTimeKind.Local).AddTicks(2440), null, true, "Exception Log", true, null },
                    { new Guid("a758e699-93bc-4461-abaf-7c8bfebed2df"), "Role", new DateTime(2020, 10, 11, 23, 48, 29, 658, DateTimeKind.Local).AddTicks(232), null, true, "Role Management", true, null },
                    { new Guid("bb650e90-d95d-4c99-a302-6c7f8fc88e3c"), "User", new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(3077), null, true, "User Management", true, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayInPermissionTree", "DisplayName", "IsActive", "MethodName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("69bf3244-96a4-4d0b-8c5d-4b1f22a3649d"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(7446), null, false, false, "Delete", true, "Delete", null },
                    { new Guid("2809fb83-e3f7-4794-a24c-95ac7bf2019c"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(6843), null, true, true, "New", true, "Create", null },
                    { new Guid("3653cd3a-3362-4c03-ad41-b858ef091e3b"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(6489), null, false, true, "Restore", true, "Restore", null },
                    { new Guid("f31e1296-82a5-48a8-bb43-ad5b10257992"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(6156), null, false, true, "Deactivate", true, "Deactivate", null },
                    { new Guid("344c4e45-e265-46d5-b281-e5eefe507352"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(5753), null, false, true, "Edit", true, "Edit", null },
                    { new Guid("1cc2d977-8d74-474c-ad15-7273c0e2ccbb"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(4982), null, true, true, "Deactivated User List", true, "DeactivatedList", null },
                    { new Guid("55b7168f-79ad-4e15-857d-2b741bbd5ad6"), new DateTime(2020, 10, 11, 23, 48, 29, 658, DateTimeKind.Local).AddTicks(1783), null, true, true, "List", true, "List", null },
                    { new Guid("a50bf3d2-fe25-4472-a08b-ed4e1857875f"), new DateTime(2020, 10, 11, 23, 48, 29, 658, DateTimeKind.Local).AddTicks(6144), null, false, true, "Edit", true, "Edit", null },
                    { new Guid("83bb92d7-67d1-4d60-836d-3eb7d3a8f044"), new DateTime(2020, 10, 11, 23, 48, 29, 658, DateTimeKind.Local).AddTicks(5454), null, false, false, "Delete", true, "Delete", null },
                    { new Guid("850785ea-257c-42b2-b870-28f780a022bd"), new DateTime(2020, 10, 11, 23, 48, 29, 658, DateTimeKind.Local).AddTicks(2324), null, true, true, "New", true, "Create", null },
                    { new Guid("172b12f4-1a00-4d9c-afaf-efbf098f4d35"), new DateTime(2020, 10, 11, 23, 48, 29, 651, DateTimeKind.Local).AddTicks(5727), null, true, true, "List", true, "List", null },
                    { new Guid("8b2b8312-25d4-4f36-8353-c627371e3736"), new DateTime(2020, 10, 11, 23, 48, 29, 659, DateTimeKind.Local).AddTicks(4556), null, true, true, "Active User List", true, "ActiveList", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdateDate" },
                values: new object[] { new Guid("f436e5a1-7a8c-43c1-b897-b5578369f260"), new DateTime(2020, 10, 11, 23, 48, 29, 627, DateTimeKind.Local).AddTicks(6409), null, "It has all permissions", true, "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsActive", "LastLoginDateTime", "Name", "Password", "Phone", "Surname", "UpdateDate" },
                values: new object[] { new Guid("6f2b5efd-2e83-4b6e-b28b-7be3c58018ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 11, 23, 48, 29, 647, DateTimeKind.Local).AddTicks(684), "admin", true, null, "admin", "Wwlcbhd88rv7mPvoS/02V4SVgun5TXSgyN3kVyVd9FY=", null, "admin", null });
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
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
