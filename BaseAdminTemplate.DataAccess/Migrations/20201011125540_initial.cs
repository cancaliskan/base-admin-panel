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
                    { new Guid("b7e01eb9-7600-4b8c-ae2b-6ebb6c5cf11f"), new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(2582), null, true, new Guid("1aca29f3-17ad-431f-a6d0-c47c663c7916"), new Guid("18ba41af-ce65-4bff-aff3-5ab07e0963eb"), null },
                    { new Guid("d9520054-591f-4d34-81bd-771d4a7a1630"), new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(5115), null, true, new Guid("1aca29f3-17ad-431f-a6d0-c47c663c7916"), new Guid("81ca908a-4a39-47f2-9516-75b572a379ea"), null },
                    { new Guid("7d0d67d3-a678-4f12-b403-00a7b223cb74"), new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(6521), null, true, new Guid("1aca29f3-17ad-431f-a6d0-c47c663c7916"), new Guid("58601a31-e483-4423-83d1-c13c26ca1929"), null },
                    { new Guid("fb33ab57-aed0-447b-9c2b-42fba351c9ce"), new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(6795), null, true, new Guid("1aca29f3-17ad-431f-a6d0-c47c663c7916"), new Guid("f9c9595b-5081-4e7a-aa1b-45827ea6ce61"), null },
                    { new Guid("79d6272f-1c8f-4c5a-b034-da176205bd00"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(1791), null, true, new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"), new Guid("380b6d69-6eb3-4522-bb32-208a64f2d3b8"), null },
                    { new Guid("7b30bc2e-fec3-4d98-ae12-81b1456825e9"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2057), null, true, new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"), new Guid("5938d4ad-c2cf-414b-98a9-a78ffd00c08b"), null },
                    { new Guid("22281009-c7a1-4d7c-b4bf-5217f1472b33"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2347), null, true, new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"), new Guid("68fc05b8-745b-41ae-b55b-15023d8de19b"), null },
                    { new Guid("5ecc3f07-03c7-4445-8e98-980ef4fa5e78"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2484), null, true, new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"), new Guid("c8eae4e0-44b9-406c-8356-e5fb610f2abf"), null },
                    { new Guid("a1ee0e15-aca7-4ecd-8871-63fda4212c11"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2624), null, true, new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"), new Guid("68b3cb77-3716-40bc-99ff-c7f6377383ea"), null },
                    { new Guid("95845110-2aa0-43a8-8d41-c139387cdaed"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2822), null, true, new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"), new Guid("b92da037-fa04-4e0d-a33b-33e23416ced4"), null },
                    { new Guid("56903ca3-48e8-46bb-89d4-ce113a4cdf10"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2970), null, true, new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"), new Guid("74d5bbab-0442-4042-8073-68b7831028c2"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "PermissionId", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("cd738882-5256-4b21-b786-a8e7c9d8945f"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2992), null, true, new Guid("74d5bbab-0442-4042-8073-68b7831028c2"), new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"), null },
                    { new Guid("207dfc6c-7980-45f1-9c20-3372ab276de3"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2845), null, true, new Guid("b92da037-fa04-4e0d-a33b-33e23416ced4"), new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"), null },
                    { new Guid("033e8eca-58d7-4a4d-8b03-855f7f2de953"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2649), null, true, new Guid("68b3cb77-3716-40bc-99ff-c7f6377383ea"), new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"), null },
                    { new Guid("257a1719-3323-46c3-8e29-46624cf2fcb5"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2371), null, true, new Guid("68fc05b8-745b-41ae-b55b-15023d8de19b"), new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"), null },
                    { new Guid("11bcdb79-19d5-453f-aeef-02976a4705a1"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2089), null, true, new Guid("5938d4ad-c2cf-414b-98a9-a78ffd00c08b"), new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"), null },
                    { new Guid("df4fb3c4-6da2-4ba7-aea6-48cb0ec26f67"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2506), null, true, new Guid("c8eae4e0-44b9-406c-8356-e5fb610f2abf"), new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"), null },
                    { new Guid("dee9c44f-14ad-4923-9d05-c3408131508a"), new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(6818), null, true, new Guid("f9c9595b-5081-4e7a-aa1b-45827ea6ce61"), new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"), null },
                    { new Guid("148a7a4b-e3db-4979-b87c-f5292b0ef9be"), new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(6645), null, true, new Guid("58601a31-e483-4423-83d1-c13c26ca1929"), new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"), null },
                    { new Guid("6e34fbb2-4fc9-4222-b83d-8ec5ed6c1cd8"), new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(5174), null, true, new Guid("81ca908a-4a39-47f2-9516-75b572a379ea"), new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"), null },
                    { new Guid("b021fc06-459b-410f-9741-91a495edba0c"), new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(4536), null, true, new Guid("18ba41af-ce65-4bff-aff3-5ab07e0963eb"), new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"), null },
                    { new Guid("64800300-541a-452f-9dd4-76c65ca25dca"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(1912), null, true, new Guid("380b6d69-6eb3-4522-bb32-208a64f2d3b8"), new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkUsersRoles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "RoleId", "UpdateDate", "UserId" },
                values: new object[] { new Guid("b72a990c-a74a-4733-b2f3-e6267637c20d"), new DateTime(2020, 10, 11, 15, 55, 40, 141, DateTimeKind.Local).AddTicks(5584), null, true, new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"), null, new Guid("27cd9a2b-63fb-4260-a7e5-9d05dc9544f8") });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ControllerName", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayName", "IsActive", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("1aca29f3-17ad-431f-a6d0-c47c663c7916"), "Role", new DateTime(2020, 10, 11, 15, 55, 40, 143, DateTimeKind.Local).AddTicks(1431), null, true, "Role Management", true, null },
                    { new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"), "User", new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(920), null, true, "User Management", true, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayInPermissionTree", "DisplayName", "IsActive", "MethodName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("74d5bbab-0442-4042-8073-68b7831028c2"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2939), null, false, false, "Delete", true, "Delete", null },
                    { new Guid("b92da037-fa04-4e0d-a33b-33e23416ced4"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2781), null, true, true, "New", true, "Create", null },
                    { new Guid("68b3cb77-3716-40bc-99ff-c7f6377383ea"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2580), null, false, true, "Restore", true, "Restore", null },
                    { new Guid("c8eae4e0-44b9-406c-8356-e5fb610f2abf"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2447), null, false, true, "Deactivate", true, "Deactivate", null },
                    { new Guid("68fc05b8-745b-41ae-b55b-15023d8de19b"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2301), null, false, true, "Edit", true, "Edit", null },
                    { new Guid("58601a31-e483-4423-83d1-c13c26ca1929"), new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(6438), null, false, false, "Delete", true, "Delete", null },
                    { new Guid("380b6d69-6eb3-4522-bb32-208a64f2d3b8"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(1715), null, true, true, "Active User List", true, "ActiveList", null },
                    { new Guid("f9c9595b-5081-4e7a-aa1b-45827ea6ce61"), new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(6746), null, false, true, "Edit", true, "Edit", null },
                    { new Guid("81ca908a-4a39-47f2-9516-75b572a379ea"), new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(4997), null, true, true, "New", true, "Create", null },
                    { new Guid("18ba41af-ce65-4bff-aff3-5ab07e0963eb"), new DateTime(2020, 10, 11, 15, 55, 40, 143, DateTimeKind.Local).AddTicks(8892), null, true, true, "List", true, "List", null },
                    { new Guid("5938d4ad-c2cf-414b-98a9-a78ffd00c08b"), new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2014), null, true, true, "Deactivated User List", true, "DeactivatedList", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdateDate" },
                values: new object[] { new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"), new DateTime(2020, 10, 11, 15, 55, 40, 130, DateTimeKind.Local).AddTicks(5239), null, "It has all permissions", true, "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsActive", "LastLoginDateTime", "Name", "Password", "Phone", "Surname", "UpdateDate" },
                values: new object[] { new Guid("27cd9a2b-63fb-4260-a7e5-9d05dc9544f8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 11, 15, 55, 40, 141, DateTimeKind.Local).AddTicks(3574), "admin", true, null, "admin", "rlcOQQovIUq24L/jH2biiuvfHEFwtm5FTT0BR/cDyv4=", null, "admin", null });
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
