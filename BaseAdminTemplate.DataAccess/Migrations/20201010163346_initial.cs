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
                    { new Guid("17a98bf8-73ea-4471-94b7-d7e0a3054f17"), new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(3452), null, true, new Guid("cb7e987c-b34d-4276-b6cf-faede6451f1b"), new Guid("feb7d98f-fd26-47ac-abaa-17c5fbc5b0b9"), null },
                    { new Guid("239c4964-f360-4db5-8f86-f5a74d8ffb8c"), new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(6390), null, true, new Guid("cb7e987c-b34d-4276-b6cf-faede6451f1b"), new Guid("6951a413-f059-4f38-b21d-875e8709e849"), null },
                    { new Guid("d12de7ef-821f-45ce-aa37-7d3c7644dff1"), new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(8218), null, true, new Guid("cb7e987c-b34d-4276-b6cf-faede6451f1b"), new Guid("6750146f-4c06-4603-8be3-ae64b1ee1415"), null },
                    { new Guid("391ac752-5c87-4c2c-982c-50393d2695f8"), new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(8393), null, true, new Guid("cb7e987c-b34d-4276-b6cf-faede6451f1b"), new Guid("aa693de9-584e-442d-883d-9d4b04c7706c"), null },
                    { new Guid("b1617584-014b-49cb-b4ef-4593ea66565e"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(2602), null, true, new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"), new Guid("e6d35733-4081-438a-accb-fd8aefb95267"), null },
                    { new Guid("512df278-1bc0-4705-a795-b2217c26ee69"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(2877), null, true, new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"), new Guid("a1fc75ba-8424-4200-a4da-c6bdd7de9209"), null },
                    { new Guid("79b502a6-710d-4764-bb68-5b0b6c9cccf1"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3417), null, true, new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"), new Guid("105a7c7e-cc0a-4ff5-a2c7-0865f12109d2"), null },
                    { new Guid("21ec4cf1-b3ec-463c-81fe-b2f04d5243f9"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3636), null, true, new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"), new Guid("73a195a9-c1e9-4e3a-bd71-a502eba24ac5"), null },
                    { new Guid("110dae5a-7329-44d7-b1fc-f1c54b16eef3"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4010), null, true, new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"), new Guid("75d46764-9f0d-4394-a2df-41be8cd6a73c"), null },
                    { new Guid("883ac054-a8d4-4845-be3c-5d9cb9ed46dd"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4267), null, true, new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"), new Guid("1dae0ede-2829-4a79-83ca-ced06cba0725"), null },
                    { new Guid("c98f85ce-5058-4ffd-b991-66e8bf06d1fa"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4509), null, true, new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"), new Guid("d3be56c5-e577-41fc-bc0d-689a56604d96"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "PermissionId", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("4d314fda-cfe1-43cc-92b1-1e4415d5a1da"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4546), null, true, new Guid("d3be56c5-e577-41fc-bc0d-689a56604d96"), new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"), null },
                    { new Guid("6c0d1a1a-8a6e-41ff-9ea7-78b9d1cd5acd"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4302), null, true, new Guid("1dae0ede-2829-4a79-83ca-ced06cba0725"), new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"), null },
                    { new Guid("960014a3-0d08-4af8-8319-ae4476b61ef9"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4076), null, true, new Guid("75d46764-9f0d-4394-a2df-41be8cd6a73c"), new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"), null },
                    { new Guid("b753c655-a46e-4b9c-a408-bb39e0881afa"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3456), null, true, new Guid("105a7c7e-cc0a-4ff5-a2c7-0865f12109d2"), new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"), null },
                    { new Guid("37d60fe6-446f-4a15-8c7e-365c3e7442ff"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(2917), null, true, new Guid("a1fc75ba-8424-4200-a4da-c6bdd7de9209"), new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"), null },
                    { new Guid("685fc272-6b6d-4e7d-89a7-079eda45d51a"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3674), null, true, new Guid("73a195a9-c1e9-4e3a-bd71-a502eba24ac5"), new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"), null },
                    { new Guid("1aa4b7ba-39b0-4c9d-bd08-c4ae2d671d92"), new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(8422), null, true, new Guid("aa693de9-584e-442d-883d-9d4b04c7706c"), new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"), null },
                    { new Guid("9abdb00c-7e8a-45a3-a8e6-d8dc108b98c2"), new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(8245), null, true, new Guid("6750146f-4c06-4603-8be3-ae64b1ee1415"), new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"), null },
                    { new Guid("4c11f1e6-18dd-497b-99d3-88ab948acb48"), new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(6448), null, true, new Guid("6951a413-f059-4f38-b21d-875e8709e849"), new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"), null },
                    { new Guid("ca59e968-ac78-43ec-834d-c7df1e211e25"), new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(5653), null, true, new Guid("feb7d98f-fd26-47ac-abaa-17c5fbc5b0b9"), new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"), null },
                    { new Guid("9c614648-0112-4e0b-bf6b-78d097ce712f"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(2659), null, true, new Guid("e6d35733-4081-438a-accb-fd8aefb95267"), new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkUsersRoles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "RoleId", "UpdateDate", "UserId" },
                values: new object[] { new Guid("1d858670-ad72-4b30-8e1c-5f0d59671435"), new DateTime(2020, 10, 10, 19, 33, 46, 24, DateTimeKind.Local).AddTicks(8937), null, true, new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"), null, new Guid("4f597ad6-7a81-47a9-93aa-2de0da308ed5") });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ControllerName", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayName", "IsActive", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("cb7e987c-b34d-4276-b6cf-faede6451f1b"), "Role", new DateTime(2020, 10, 10, 19, 33, 46, 26, DateTimeKind.Local).AddTicks(9607), null, true, "Role Management", true, null },
                    { new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"), "User", new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(1111), null, true, "User Management", true, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayInPermissionTree", "DisplayName", "IsActive", "MethodName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("d3be56c5-e577-41fc-bc0d-689a56604d96"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4459), null, false, false, "Delete", true, "Delete", null },
                    { new Guid("1dae0ede-2829-4a79-83ca-ced06cba0725"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4210), null, true, true, "New", true, "Create", null },
                    { new Guid("75d46764-9f0d-4394-a2df-41be8cd6a73c"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3792), null, false, true, "Restore", true, "Restore", null },
                    { new Guid("73a195a9-c1e9-4e3a-bd71-a502eba24ac5"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3581), null, false, true, "Deactivate", true, "Deactivate", null },
                    { new Guid("105a7c7e-cc0a-4ff5-a2c7-0865f12109d2"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3342), null, false, true, "Edit", true, "Edit", null },
                    { new Guid("6750146f-4c06-4603-8be3-ae64b1ee1415"), new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(8116), null, false, false, "Delete", true, "Delete", null },
                    { new Guid("e6d35733-4081-438a-accb-fd8aefb95267"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(2400), null, true, true, "Active User List", true, "ActiveList", null },
                    { new Guid("aa693de9-584e-442d-883d-9d4b04c7706c"), new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(8348), null, false, true, "Edit", true, "Edit", null },
                    { new Guid("6951a413-f059-4f38-b21d-875e8709e849"), new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(6268), null, true, true, "New", true, "Create", null },
                    { new Guid("feb7d98f-fd26-47ac-abaa-17c5fbc5b0b9"), new DateTime(2020, 10, 10, 19, 33, 46, 27, DateTimeKind.Local).AddTicks(8963), null, true, true, "List", true, "List", null },
                    { new Guid("a1fc75ba-8424-4200-a4da-c6bdd7de9209"), new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(2812), null, true, true, "Deactivated User List", true, "DeactivatedList", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdateDate" },
                values: new object[] { new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"), new DateTime(2020, 10, 10, 19, 33, 46, 8, DateTimeKind.Local).AddTicks(9680), null, "It has all permissions", true, "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsActive", "LastLoginDateTime", "Name", "Password", "Phone", "Surname", "UpdateDate" },
                values: new object[] { new Guid("4f597ad6-7a81-47a9-93aa-2de0da308ed5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 19, 33, 46, 24, DateTimeKind.Local).AddTicks(6365), "admin", true, null, "admin", "yMiyl4uqC9SktM7PAqwM9vUa4s6eKn//+NFcoOg1Jjo=", null, "admin", null });
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
