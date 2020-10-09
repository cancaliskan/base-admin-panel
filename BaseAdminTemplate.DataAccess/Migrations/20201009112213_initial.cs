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
                    { new Guid("2716bd0e-8def-44f6-80d3-ab90bf605f30"), new DateTime(2020, 10, 9, 14, 22, 12, 784, DateTimeKind.Local).AddTicks(7972), null, true, new Guid("bd2090f9-d3c9-438c-b3ad-7ae9acd119ff"), new Guid("0c3f85c8-1a31-47be-b8be-9a5c2dea62c9"), null },
                    { new Guid("1949a59b-18c6-4339-a728-ec4387ee9294"), new DateTime(2020, 10, 9, 14, 22, 12, 785, DateTimeKind.Local).AddTicks(2521), null, true, new Guid("bd2090f9-d3c9-438c-b3ad-7ae9acd119ff"), new Guid("76e64889-ece8-4523-90ce-f48dc7b72c68"), null },
                    { new Guid("299f9cbd-157f-49a0-aee5-637e6e5aab54"), new DateTime(2020, 10, 9, 14, 22, 12, 786, DateTimeKind.Local).AddTicks(684), null, true, new Guid("bd2090f9-d3c9-438c-b3ad-7ae9acd119ff"), new Guid("d525ac88-a2b0-4dc9-8097-0d0c08ad17ef"), null },
                    { new Guid("7d3c1819-d093-40dd-9b90-8e8a45170600"), new DateTime(2020, 10, 9, 14, 22, 12, 786, DateTimeKind.Local).AddTicks(1206), null, true, new Guid("bd2090f9-d3c9-438c-b3ad-7ae9acd119ff"), new Guid("89b2ba41-9acf-42bf-a3bf-f2249be72f69"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "PermissionId", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("c202cb51-e7d1-4dd4-959e-47614dd8c9d8"), new DateTime(2020, 10, 9, 14, 22, 12, 785, DateTimeKind.Local).AddTicks(1252), null, true, new Guid("0c3f85c8-1a31-47be-b8be-9a5c2dea62c9"), new Guid("f512ab28-fddc-4a7c-8e5f-aebf156e9182"), null },
                    { new Guid("0e6e3a72-493a-4095-ab47-01d626906276"), new DateTime(2020, 10, 9, 14, 22, 12, 785, DateTimeKind.Local).AddTicks(2816), null, true, new Guid("76e64889-ece8-4523-90ce-f48dc7b72c68"), new Guid("f512ab28-fddc-4a7c-8e5f-aebf156e9182"), null },
                    { new Guid("f164315d-96e9-4d42-9504-e46a4377c81d"), new DateTime(2020, 10, 9, 14, 22, 12, 786, DateTimeKind.Local).AddTicks(746), null, true, new Guid("d525ac88-a2b0-4dc9-8097-0d0c08ad17ef"), new Guid("f512ab28-fddc-4a7c-8e5f-aebf156e9182"), null },
                    { new Guid("7bfe7924-4f9c-4f24-a22f-87dafc9c2017"), new DateTime(2020, 10, 9, 14, 22, 12, 786, DateTimeKind.Local).AddTicks(1258), null, true, new Guid("89b2ba41-9acf-42bf-a3bf-f2249be72f69"), new Guid("f512ab28-fddc-4a7c-8e5f-aebf156e9182"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkUsersRoles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "RoleId", "UpdateDate", "UserId" },
                values: new object[] { new Guid("61bc689e-41c2-4622-b82e-9655f80fe3f8"), new DateTime(2020, 10, 9, 14, 22, 12, 780, DateTimeKind.Local).AddTicks(5573), null, true, new Guid("f512ab28-fddc-4a7c-8e5f-aebf156e9182"), null, new Guid("909d3b29-3e2a-42f4-b4ef-1e27658af9db") });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ControllerName", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayName", "IsActive", "UpdateDate" },
                values: new object[] { new Guid("bd2090f9-d3c9-438c-b3ad-7ae9acd119ff"), "Role", new DateTime(2020, 10, 9, 14, 22, 12, 783, DateTimeKind.Local).AddTicks(589), null, true, "Role Management", true, null });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayInPermissionTree", "DisplayName", "IsActive", "MethodName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("0c3f85c8-1a31-47be-b8be-9a5c2dea62c9"), new DateTime(2020, 10, 9, 14, 22, 12, 784, DateTimeKind.Local).AddTicks(2111), null, true, true, "List", true, "List", null },
                    { new Guid("76e64889-ece8-4523-90ce-f48dc7b72c68"), new DateTime(2020, 10, 9, 14, 22, 12, 785, DateTimeKind.Local).AddTicks(2222), null, true, true, "New", true, "Create", null },
                    { new Guid("d525ac88-a2b0-4dc9-8097-0d0c08ad17ef"), new DateTime(2020, 10, 9, 14, 22, 12, 786, DateTimeKind.Local).AddTicks(362), null, false, false, "Delete", true, "Delete", null },
                    { new Guid("89b2ba41-9acf-42bf-a3bf-f2249be72f69"), new DateTime(2020, 10, 9, 14, 22, 12, 786, DateTimeKind.Local).AddTicks(1057), null, false, true, "Edit", true, "Edit", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdateDate" },
                values: new object[] { new Guid("f512ab28-fddc-4a7c-8e5f-aebf156e9182"), new DateTime(2020, 10, 9, 14, 22, 12, 763, DateTimeKind.Local).AddTicks(4060), null, "It has all permissions", true, "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsActive", "LastLoginDateTime", "Name", "Password", "Phone", "Surname", "UpdateDate" },
                values: new object[] { new Guid("909d3b29-3e2a-42f4-b4ef-1e27658af9db"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 9, 14, 22, 12, 780, DateTimeKind.Local).AddTicks(2563), "admin", true, null, "admin", "Zqp5ANxfZWm7EnLxFWg/9RuIWU8ZFy2TYVdVRTXw1Yo=", null, "admin", null });
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
