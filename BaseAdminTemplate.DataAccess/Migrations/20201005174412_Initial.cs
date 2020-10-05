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
                    { new Guid("18c2c536-9581-41af-b7ff-532b8b95fbf8"), new DateTime(2020, 10, 5, 20, 44, 11, 945, DateTimeKind.Local).AddTicks(2315), null, true, new Guid("09cc1d5d-d1d7-4a1b-abe8-94f02c09f0cd"), new Guid("cc1ea787-a23c-47cc-867c-b3805583909b"), null },
                    { new Guid("ec214bf3-02ed-4605-b248-c564429c2b9a"), new DateTime(2020, 10, 5, 20, 44, 11, 948, DateTimeKind.Local).AddTicks(7871), null, true, new Guid("912d0685-231d-468e-b874-ab522af6e31b"), new Guid("3a74d363-4cbe-4407-9fbb-9018fae77322"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "PermissionId", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("eacfea29-ac41-49c6-bb49-16b9e963b39d"), new DateTime(2020, 10, 5, 20, 44, 11, 945, DateTimeKind.Local).AddTicks(5247), null, true, new Guid("cc1ea787-a23c-47cc-867c-b3805583909b"), new Guid("817d1766-491e-40e6-be1c-b0d8b720fc37"), null },
                    { new Guid("066ab727-ee59-42c7-9089-e17b69b8b5fb"), new DateTime(2020, 10, 5, 20, 44, 11, 948, DateTimeKind.Local).AddTicks(7948), null, true, new Guid("3a74d363-4cbe-4407-9fbb-9018fae77322"), new Guid("817d1766-491e-40e6-be1c-b0d8b720fc37"), null }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ControllerName", "CreatedDate", "DeletedDate", "DisplayName", "IsActive", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("09cc1d5d-d1d7-4a1b-abe8-94f02c09f0cd"), "HomeController", new DateTime(2020, 10, 5, 20, 44, 11, 944, DateTimeKind.Local).AddTicks(249), null, "Role Management", true, null },
                    { new Guid("912d0685-231d-468e-b874-ab522af6e31b"), "TestController", new DateTime(2020, 10, 5, 20, 44, 11, 948, DateTimeKind.Local).AddTicks(6371), null, "Test Controller", true, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DisplayName", "IsActive", "MethodName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("cc1ea787-a23c-47cc-867c-b3805583909b"), new DateTime(2020, 10, 5, 20, 44, 11, 944, DateTimeKind.Local).AddTicks(8296), null, "Create Role", true, "Index", null },
                    { new Guid("3a74d363-4cbe-4407-9fbb-9018fae77322"), new DateTime(2020, 10, 5, 20, 44, 11, 948, DateTimeKind.Local).AddTicks(7691), null, "Test Controller Method", true, "Index", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdateDate" },
                values: new object[] { new Guid("817d1766-491e-40e6-be1c-b0d8b720fc37"), new DateTime(2020, 10, 5, 20, 44, 11, 926, DateTimeKind.Local).AddTicks(5390), null, "It has all permissions", true, "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsActive", "LastLoginDateTime", "Name", "Password", "Phone", "Surname", "UpdateDate" },
                values: new object[] { new Guid("5edf61b2-e523-44f0-bf9b-603ed8c25e98"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 5, 20, 44, 11, 943, DateTimeKind.Local).AddTicks(292), "admin", true, null, "admin", "g78ZE/EEv4phlEYtI3unQ7hkwNKqRZFEBnjNoeRPmSc=", null, "admin", null });
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
