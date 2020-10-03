using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseAdminTemplate.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { new Guid("ae1e9a74-cb0d-46e3-85a9-c3628ffba9bd"), new DateTime(2020, 10, 3, 21, 11, 16, 202, DateTimeKind.Local).AddTicks(2074), null, true, new Guid("34100b28-fefa-4e27-b8ec-c913c0920cbb"), new Guid("d194873e-dfd7-47aa-90f4-b159039b44c3"), null },
                    { new Guid("c1436f45-9bd2-4f31-9cf9-5f9fd2a8548a"), new DateTime(2020, 10, 3, 21, 11, 16, 205, DateTimeKind.Local).AddTicks(3731), null, true, new Guid("a7a19352-a89e-449f-ac12-31ff7b79ed8b"), new Guid("ca30f026-0457-4aab-909a-aea2b3d56cdf"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "PermissionId", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("1b925fb2-79e4-4200-b47e-c644b4391886"), new DateTime(2020, 10, 3, 21, 11, 16, 202, DateTimeKind.Local).AddTicks(4067), null, true, new Guid("d194873e-dfd7-47aa-90f4-b159039b44c3"), new Guid("afb3f4e5-789d-4057-901d-0abb71bbe2d1"), null },
                    { new Guid("48a9b186-a6e2-430d-9784-d0a0372da748"), new DateTime(2020, 10, 3, 21, 11, 16, 205, DateTimeKind.Local).AddTicks(3792), null, true, new Guid("ca30f026-0457-4aab-909a-aea2b3d56cdf"), new Guid("afb3f4e5-789d-4057-901d-0abb71bbe2d1"), null }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("34100b28-fefa-4e27-b8ec-c913c0920cbb"), new DateTime(2020, 10, 3, 21, 11, 16, 201, DateTimeKind.Local).AddTicks(3500), null, true, "Role Management", null },
                    { new Guid("a7a19352-a89e-449f-ac12-31ff7b79ed8b"), new DateTime(2020, 10, 3, 21, 11, 16, 205, DateTimeKind.Local).AddTicks(2674), null, true, "Test Controller", null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("d194873e-dfd7-47aa-90f4-b159039b44c3"), new DateTime(2020, 10, 3, 21, 11, 16, 201, DateTimeKind.Local).AddTicks(9093), null, true, "Create Role", null },
                    { new Guid("ca30f026-0457-4aab-909a-aea2b3d56cdf"), new DateTime(2020, 10, 3, 21, 11, 16, 205, DateTimeKind.Local).AddTicks(3636), null, true, "Test Controller Method", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdateDate" },
                values: new object[] { new Guid("afb3f4e5-789d-4057-901d-0abb71bbe2d1"), new DateTime(2020, 10, 3, 21, 11, 16, 189, DateTimeKind.Local).AddTicks(1969), null, "It has all permissions", true, "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsActive", "LastLoginDateTime", "Name", "Password", "Phone", "Surname", "UpdateDate" },
                values: new object[] { new Guid("69f7a1be-0d5b-4cbb-8469-2d7c3f6099b4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 3, 21, 11, 16, 200, DateTimeKind.Local).AddTicks(6560), "admin", true, null, "Admin", "KJpqEwxnEmXG63kXp5VTsY5cAxRjeAnWGOqc4ZVMgPw=", null, "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
