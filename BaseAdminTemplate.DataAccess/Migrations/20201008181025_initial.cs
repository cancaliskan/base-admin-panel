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
                    { new Guid("7f7c994f-2e44-4b80-8a90-6d67dbb9c547"), new DateTime(2020, 10, 8, 21, 10, 24, 415, DateTimeKind.Local).AddTicks(2858), null, true, new Guid("2460c8db-d314-4641-af03-967be6f30d90"), new Guid("7dda5e32-be88-4518-b6f7-06acb3a1d19e"), null },
                    { new Guid("4f392ad0-edde-4042-b928-22a73600563f"), new DateTime(2020, 10, 8, 21, 10, 24, 415, DateTimeKind.Local).AddTicks(5493), null, true, new Guid("2460c8db-d314-4641-af03-967be6f30d90"), new Guid("e077db56-7019-4565-a4c9-b0162d186edb"), null },
                    { new Guid("d77fe8e2-d45c-4e1b-83ed-6efa7982cda0"), new DateTime(2020, 10, 8, 21, 10, 24, 415, DateTimeKind.Local).AddTicks(6992), null, true, new Guid("2460c8db-d314-4641-af03-967be6f30d90"), new Guid("519f1ec5-4345-4688-8a30-65238bd71787"), null },
                    { new Guid("b2e33423-f04f-4415-aa20-11e67cbdd4d7"), new DateTime(2020, 10, 8, 21, 10, 24, 415, DateTimeKind.Local).AddTicks(7149), null, true, new Guid("2460c8db-d314-4641-af03-967be6f30d90"), new Guid("4a19587e-e893-48c2-ae4e-47e1e7fa18b7"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "PermissionId", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("4db9e1c2-a4c0-4077-b59c-357c089fba7c"), new DateTime(2020, 10, 8, 21, 10, 24, 415, DateTimeKind.Local).AddTicks(4946), null, true, new Guid("7dda5e32-be88-4518-b6f7-06acb3a1d19e"), new Guid("5b4a4f18-a8e3-4b61-838e-0107447ec2e2"), null },
                    { new Guid("cca5ba4b-6dc1-44fb-b63b-7401f63affc0"), new DateTime(2020, 10, 8, 21, 10, 24, 415, DateTimeKind.Local).AddTicks(5549), null, true, new Guid("e077db56-7019-4565-a4c9-b0162d186edb"), new Guid("5b4a4f18-a8e3-4b61-838e-0107447ec2e2"), null },
                    { new Guid("dc93eb59-35ca-43c2-a117-79b3cad70e97"), new DateTime(2020, 10, 8, 21, 10, 24, 415, DateTimeKind.Local).AddTicks(7029), null, true, new Guid("519f1ec5-4345-4688-8a30-65238bd71787"), new Guid("5b4a4f18-a8e3-4b61-838e-0107447ec2e2"), null },
                    { new Guid("3bdce0a1-a4a3-4270-a38f-fdf9d945cd5f"), new DateTime(2020, 10, 8, 21, 10, 24, 415, DateTimeKind.Local).AddTicks(7171), null, true, new Guid("4a19587e-e893-48c2-ae4e-47e1e7fa18b7"), new Guid("5b4a4f18-a8e3-4b61-838e-0107447ec2e2"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkUsersRoles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "RoleId", "UpdateDate", "UserId" },
                values: new object[] { new Guid("3638aee2-494e-42e7-9e48-368abd0e8a5a"), new DateTime(2020, 10, 8, 21, 10, 24, 412, DateTimeKind.Local).AddTicks(5511), null, true, new Guid("5b4a4f18-a8e3-4b61-838e-0107447ec2e2"), null, new Guid("a6b46686-e4cb-47cc-b991-65e133c62e98") });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ControllerName", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayName", "IsActive", "UpdateDate" },
                values: new object[] { new Guid("2460c8db-d314-4641-af03-967be6f30d90"), "Role", new DateTime(2020, 10, 8, 21, 10, 24, 414, DateTimeKind.Local).AddTicks(1859), null, true, "Role Management", true, null });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayName", "IsActive", "MethodName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("7dda5e32-be88-4518-b6f7-06acb3a1d19e"), new DateTime(2020, 10, 8, 21, 10, 24, 414, DateTimeKind.Local).AddTicks(9633), null, true, "List", true, "List", null },
                    { new Guid("e077db56-7019-4565-a4c9-b0162d186edb"), new DateTime(2020, 10, 8, 21, 10, 24, 415, DateTimeKind.Local).AddTicks(5369), null, true, "New", true, "Create", null },
                    { new Guid("519f1ec5-4345-4688-8a30-65238bd71787"), new DateTime(2020, 10, 8, 21, 10, 24, 415, DateTimeKind.Local).AddTicks(6907), null, false, "Delete", true, "Delete", null },
                    { new Guid("4a19587e-e893-48c2-ae4e-47e1e7fa18b7"), new DateTime(2020, 10, 8, 21, 10, 24, 415, DateTimeKind.Local).AddTicks(7116), null, false, "Edit", true, "Edit", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdateDate" },
                values: new object[] { new Guid("5b4a4f18-a8e3-4b61-838e-0107447ec2e2"), new DateTime(2020, 10, 8, 21, 10, 24, 401, DateTimeKind.Local).AddTicks(7031), null, "It has all permissions", true, "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsActive", "LastLoginDateTime", "Name", "Password", "Phone", "Surname", "UpdateDate" },
                values: new object[] { new Guid("a6b46686-e4cb-47cc-b991-65e133c62e98"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 8, 21, 10, 24, 412, DateTimeKind.Local).AddTicks(3523), "admin", true, null, "admin", "pKJA6M0zGMBm7Mv56CTAnL1HALnjgx3DgFEI/1VSBg0=", null, "admin", null });
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
