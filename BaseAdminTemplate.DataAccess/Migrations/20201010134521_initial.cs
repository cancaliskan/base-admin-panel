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
                    { new Guid("01ece755-025e-4079-9c0a-bc574593782c"), new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(4681), null, true, new Guid("b573800a-9317-45cb-86a9-5f099f205d3d"), new Guid("690cb5d0-5264-4530-8b14-ed0a3f74aee1"), null },
                    { new Guid("59592d96-ffcc-484a-bcb1-dadcb9d71c22"), new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(7589), null, true, new Guid("b573800a-9317-45cb-86a9-5f099f205d3d"), new Guid("1bd192dc-1dce-4cf8-8f32-53f7b5b10b55"), null },
                    { new Guid("f50ec72c-49fc-4d0c-87ce-bf8704a2bfc5"), new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(9293), null, true, new Guid("b573800a-9317-45cb-86a9-5f099f205d3d"), new Guid("0215fc8a-9e25-48fc-a024-6e29381bb04a"), null },
                    { new Guid("c553a14a-2092-41b0-811c-d77ab67be852"), new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(9573), null, true, new Guid("b573800a-9317-45cb-86a9-5f099f205d3d"), new Guid("540a0db0-ab34-4126-a451-c93f1d693055"), null },
                    { new Guid("34db6b0b-8d41-48b0-a06e-2a893ed39ebb"), new DateTime(2020, 10, 10, 16, 45, 20, 551, DateTimeKind.Local).AddTicks(9909), null, true, new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"), new Guid("f4c32e9b-cd4e-4e6f-82fa-c0ff208342a5"), null },
                    { new Guid("bf916bae-b5ef-403e-984d-28ad96f614ab"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(189), null, true, new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"), new Guid("85fb379e-5b30-46ca-a2c9-3c2ba41bdc92"), null },
                    { new Guid("1e3acaff-6045-4e95-b49d-0b2ce5d13a86"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(494), null, true, new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"), new Guid("f4a8204f-3547-4ad5-98ea-967a4ec4a85f"), null },
                    { new Guid("bf88e466-7cb5-4741-89b4-2b33c1ad56f0"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(643), null, true, new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"), new Guid("aa73cd60-326a-47b7-b5c0-8f9d09c2803a"), null },
                    { new Guid("683bc7d2-3f58-4fa3-8745-b25c4a3233c6"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(782), null, true, new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"), new Guid("41486cf3-50cc-4cdd-88ce-6b9195a1a1d9"), null },
                    { new Guid("ae6b5ef9-9193-480d-950e-7efd15c85a24"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(987), null, true, new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"), new Guid("8c2f9030-b283-46c0-95ca-80017cd6e308"), null },
                    { new Guid("29345a95-7c2c-4c10-845f-323ebf9ded65"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(1143), null, true, new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"), new Guid("ece55029-4f02-486c-873d-98c29c95ff39"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "PermissionId", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("5a9c01c4-ceb1-4d3f-8939-2e75eb04fd9e"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(1164), null, true, new Guid("ece55029-4f02-486c-873d-98c29c95ff39"), new Guid("3a432956-84ef-4a31-854a-8d05edadc664"), null },
                    { new Guid("d467262d-ca20-4940-9edd-9f72ae309bf3"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(1009), null, true, new Guid("8c2f9030-b283-46c0-95ca-80017cd6e308"), new Guid("3a432956-84ef-4a31-854a-8d05edadc664"), null },
                    { new Guid("1799269c-3bce-45b1-87f6-26f0eec55dea"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(806), null, true, new Guid("41486cf3-50cc-4cdd-88ce-6b9195a1a1d9"), new Guid("3a432956-84ef-4a31-854a-8d05edadc664"), null },
                    { new Guid("edc7280f-0609-49a5-8114-61f4c991abad"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(522), null, true, new Guid("f4a8204f-3547-4ad5-98ea-967a4ec4a85f"), new Guid("3a432956-84ef-4a31-854a-8d05edadc664"), null },
                    { new Guid("0112f3ae-db9d-4b1b-828e-9d18ee4a63ff"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(213), null, true, new Guid("85fb379e-5b30-46ca-a2c9-3c2ba41bdc92"), new Guid("3a432956-84ef-4a31-854a-8d05edadc664"), null },
                    { new Guid("ab5a3d0a-9268-4fbd-836c-8ac5a3dab557"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(665), null, true, new Guid("aa73cd60-326a-47b7-b5c0-8f9d09c2803a"), new Guid("3a432956-84ef-4a31-854a-8d05edadc664"), null },
                    { new Guid("7efd2620-24c7-4ad8-b11d-32a7db995e05"), new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(9597), null, true, new Guid("540a0db0-ab34-4126-a451-c93f1d693055"), new Guid("3a432956-84ef-4a31-854a-8d05edadc664"), null },
                    { new Guid("3fefe45c-a9fc-4ce7-8f40-1487360b4f8e"), new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(9420), null, true, new Guid("0215fc8a-9e25-48fc-a024-6e29381bb04a"), new Guid("3a432956-84ef-4a31-854a-8d05edadc664"), null },
                    { new Guid("14c1f778-59ca-4621-84b7-ddf6e719ab5d"), new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(7658), null, true, new Guid("1bd192dc-1dce-4cf8-8f32-53f7b5b10b55"), new Guid("3a432956-84ef-4a31-854a-8d05edadc664"), null },
                    { new Guid("4e85d4c0-7e8d-4d54-82a5-b051fca3ae62"), new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(6835), null, true, new Guid("690cb5d0-5264-4530-8b14-ed0a3f74aee1"), new Guid("3a432956-84ef-4a31-854a-8d05edadc664"), null },
                    { new Guid("e323080b-ba0f-42f4-bfe4-16432ab2ba69"), new DateTime(2020, 10, 10, 16, 45, 20, 551, DateTimeKind.Local).AddTicks(9946), null, true, new Guid("f4c32e9b-cd4e-4e6f-82fa-c0ff208342a5"), new Guid("3a432956-84ef-4a31-854a-8d05edadc664"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkUsersRoles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "RoleId", "UpdateDate", "UserId" },
                values: new object[] { new Guid("d8ca9efc-ed0f-460b-b586-7a115b34aa4b"), new DateTime(2020, 10, 10, 16, 45, 20, 545, DateTimeKind.Local).AddTicks(2261), null, true, new Guid("3a432956-84ef-4a31-854a-8d05edadc664"), null, new Guid("7ebfa427-e5df-4bcf-90b7-14f10b85e1fa") });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ControllerName", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayName", "IsActive", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("b573800a-9317-45cb-86a9-5f099f205d3d"), "Role", new DateTime(2020, 10, 10, 16, 45, 20, 547, DateTimeKind.Local).AddTicks(1267), null, true, "Role Management", true, null },
                    { new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"), "User", new DateTime(2020, 10, 10, 16, 45, 20, 551, DateTimeKind.Local).AddTicks(8645), null, true, "User Management", true, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayInPermissionTree", "DisplayName", "IsActive", "MethodName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("ece55029-4f02-486c-873d-98c29c95ff39"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(1109), null, false, false, "Delete", true, "Delete", null },
                    { new Guid("8c2f9030-b283-46c0-95ca-80017cd6e308"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(940), null, true, true, "New", true, "Create", null },
                    { new Guid("41486cf3-50cc-4cdd-88ce-6b9195a1a1d9"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(741), null, false, true, "Restore", true, "Restore", null },
                    { new Guid("aa73cd60-326a-47b7-b5c0-8f9d09c2803a"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(603), null, false, true, "Deactivate", true, "Deactivate", null },
                    { new Guid("f4a8204f-3547-4ad5-98ea-967a4ec4a85f"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(446), null, false, true, "Edit", true, "Edit", null },
                    { new Guid("0215fc8a-9e25-48fc-a024-6e29381bb04a"), new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(9211), null, false, false, "Delete", true, "Delete", null },
                    { new Guid("f4c32e9b-cd4e-4e6f-82fa-c0ff208342a5"), new DateTime(2020, 10, 10, 16, 45, 20, 551, DateTimeKind.Local).AddTicks(9811), null, true, true, "Active User List", true, "ActiveList", null },
                    { new Guid("540a0db0-ab34-4126-a451-c93f1d693055"), new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(9529), null, false, true, "Edit", true, "Edit", null },
                    { new Guid("1bd192dc-1dce-4cf8-8f32-53f7b5b10b55"), new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(7452), null, true, true, "New", true, "Create", null },
                    { new Guid("690cb5d0-5264-4530-8b14-ed0a3f74aee1"), new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(425), null, true, true, "List", true, "List", null },
                    { new Guid("85fb379e-5b30-46ca-a2c9-3c2ba41bdc92"), new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(140), null, true, true, "Deactivated User List", true, "DeactivatedList", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdateDate" },
                values: new object[] { new Guid("3a432956-84ef-4a31-854a-8d05edadc664"), new DateTime(2020, 10, 10, 16, 45, 20, 532, DateTimeKind.Local).AddTicks(3958), null, "It has all permissions", true, "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsActive", "LastLoginDateTime", "Name", "Password", "Phone", "Surname", "UpdateDate" },
                values: new object[] { new Guid("7ebfa427-e5df-4bcf-90b7-14f10b85e1fa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 16, 45, 20, 544, DateTimeKind.Local).AddTicks(9628), "admin", true, null, "admin", "0HrPk1Q4ZjXbzF543So2oVu305DAa72+V9f/A3HtXiM=", null, "admin", null });
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
