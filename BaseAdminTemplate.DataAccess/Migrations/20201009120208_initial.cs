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
                    { new Guid("324d41a5-9c02-4b07-8e13-6dfcbd492609"), new DateTime(2020, 10, 9, 15, 2, 7, 454, DateTimeKind.Local).AddTicks(3276), null, true, new Guid("2bb7e44c-4cd0-4761-8f56-24d7e3893295"), new Guid("2f9c5c9d-393d-4138-9ad2-58718e50c5cd"), null },
                    { new Guid("b8f63668-0c4f-418f-b0b4-d5b2e27bedfc"), new DateTime(2020, 10, 9, 15, 2, 7, 454, DateTimeKind.Local).AddTicks(9292), null, true, new Guid("2bb7e44c-4cd0-4761-8f56-24d7e3893295"), new Guid("bb118689-efd1-431a-a8ba-5453ebcf07d4"), null },
                    { new Guid("070f36b7-7cda-42c4-9080-13e8546c0a6a"), new DateTime(2020, 10, 9, 15, 2, 7, 455, DateTimeKind.Local).AddTicks(2289), null, true, new Guid("2bb7e44c-4cd0-4761-8f56-24d7e3893295"), new Guid("b490a309-a261-4852-aadf-40cdf3c86b11"), null },
                    { new Guid("9f49ffc9-7456-42d2-baa7-a6e4d4df8668"), new DateTime(2020, 10, 9, 15, 2, 7, 455, DateTimeKind.Local).AddTicks(2669), null, true, new Guid("2bb7e44c-4cd0-4761-8f56-24d7e3893295"), new Guid("5a967e8a-f359-4ff7-9f1f-7002ce5a5e87"), null },
                    { new Guid("c381cb9c-5c8d-407e-9212-ac13c1cf61dd"), new DateTime(2020, 10, 9, 15, 2, 7, 460, DateTimeKind.Local).AddTicks(4858), null, true, new Guid("af33d2d7-6188-476a-87f3-8426d605833a"), new Guid("e21b015f-52a6-4988-a0d6-187f9b0e4655"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "PermissionId", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("e15f75df-1e26-4907-aeb2-2c28478033cb"), new DateTime(2020, 10, 9, 15, 2, 7, 455, DateTimeKind.Local).AddTicks(2705), null, true, new Guid("5a967e8a-f359-4ff7-9f1f-7002ce5a5e87"), new Guid("1fcae457-b4c7-4833-9ab0-af88610018df"), null },
                    { new Guid("66a8e680-85a9-416f-9eca-56b42320b6fe"), new DateTime(2020, 10, 9, 15, 2, 7, 455, DateTimeKind.Local).AddTicks(2332), null, true, new Guid("b490a309-a261-4852-aadf-40cdf3c86b11"), new Guid("1fcae457-b4c7-4833-9ab0-af88610018df"), null },
                    { new Guid("07849aec-cfa4-4789-96c9-b37a2a412e1f"), new DateTime(2020, 10, 9, 15, 2, 7, 460, DateTimeKind.Local).AddTicks(4919), null, true, new Guid("e21b015f-52a6-4988-a0d6-187f9b0e4655"), new Guid("1fcae457-b4c7-4833-9ab0-af88610018df"), null },
                    { new Guid("d762f33a-efc4-4ee4-b76e-110086c31cd4"), new DateTime(2020, 10, 9, 15, 2, 7, 454, DateTimeKind.Local).AddTicks(7809), null, true, new Guid("2f9c5c9d-393d-4138-9ad2-58718e50c5cd"), new Guid("1fcae457-b4c7-4833-9ab0-af88610018df"), null },
                    { new Guid("0d7d4ab1-9278-4af6-bfed-8dec673358eb"), new DateTime(2020, 10, 9, 15, 2, 7, 454, DateTimeKind.Local).AddTicks(9389), null, true, new Guid("bb118689-efd1-431a-a8ba-5453ebcf07d4"), new Guid("1fcae457-b4c7-4833-9ab0-af88610018df"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkUsersRoles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "RoleId", "UpdateDate", "UserId" },
                values: new object[] { new Guid("5a73323a-8da1-476b-9d05-a37621994b56"), new DateTime(2020, 10, 9, 15, 2, 7, 448, DateTimeKind.Local).AddTicks(7513), null, true, new Guid("1fcae457-b4c7-4833-9ab0-af88610018df"), null, new Guid("1a199235-9590-4bc3-9503-0d539a51d106") });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ControllerName", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayName", "IsActive", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("2bb7e44c-4cd0-4761-8f56-24d7e3893295"), "Role", new DateTime(2020, 10, 9, 15, 2, 7, 451, DateTimeKind.Local).AddTicks(9191), null, true, "Role Management", true, null },
                    { new Guid("af33d2d7-6188-476a-87f3-8426d605833a"), "User", new DateTime(2020, 10, 9, 15, 2, 7, 460, DateTimeKind.Local).AddTicks(2671), null, true, "User Management", true, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayInPermissionTree", "DisplayName", "IsActive", "MethodName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("2f9c5c9d-393d-4138-9ad2-58718e50c5cd"), new DateTime(2020, 10, 9, 15, 2, 7, 453, DateTimeKind.Local).AddTicks(5701), null, true, true, "List", true, "List", null },
                    { new Guid("bb118689-efd1-431a-a8ba-5453ebcf07d4"), new DateTime(2020, 10, 9, 15, 2, 7, 454, DateTimeKind.Local).AddTicks(8980), null, true, true, "New", true, "Create", null },
                    { new Guid("b490a309-a261-4852-aadf-40cdf3c86b11"), new DateTime(2020, 10, 9, 15, 2, 7, 455, DateTimeKind.Local).AddTicks(2160), null, false, false, "Delete", true, "Delete", null },
                    { new Guid("5a967e8a-f359-4ff7-9f1f-7002ce5a5e87"), new DateTime(2020, 10, 9, 15, 2, 7, 455, DateTimeKind.Local).AddTicks(2480), null, false, true, "Edit", true, "Edit", null },
                    { new Guid("e21b015f-52a6-4988-a0d6-187f9b0e4655"), new DateTime(2020, 10, 9, 15, 2, 7, 460, DateTimeKind.Local).AddTicks(4510), null, true, true, "List", true, "List", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdateDate" },
                values: new object[] { new Guid("1fcae457-b4c7-4833-9ab0-af88610018df"), new DateTime(2020, 10, 9, 15, 2, 7, 429, DateTimeKind.Local).AddTicks(418), null, "It has all permissions", true, "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsActive", "LastLoginDateTime", "Name", "Password", "Phone", "Surname", "UpdateDate" },
                values: new object[] { new Guid("1a199235-9590-4bc3-9503-0d539a51d106"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 9, 15, 2, 7, 448, DateTimeKind.Local).AddTicks(4401), "admin", true, null, "admin", "VGLAdIqpnS7UQrjEYXwuKvz/r3MqrlpxNgGo6vbDw3M=", null, "admin", null });
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
