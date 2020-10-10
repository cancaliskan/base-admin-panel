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
                    { new Guid("8ff2e4f3-9474-4dfb-848a-c5af6fdce5b4"), new DateTime(2020, 10, 10, 3, 16, 20, 866, DateTimeKind.Local).AddTicks(2674), null, true, new Guid("f647b102-25cc-440c-8f55-dab1ead4473d"), new Guid("a52df285-9813-4f2a-928f-be48f59a3274"), null },
                    { new Guid("d14b0d59-eaf4-4f9f-8efc-e4e756acd959"), new DateTime(2020, 10, 10, 3, 16, 20, 866, DateTimeKind.Local).AddTicks(5432), null, true, new Guid("f647b102-25cc-440c-8f55-dab1ead4473d"), new Guid("c37e83f9-30b9-41d1-a486-fb5cc54de5d6"), null },
                    { new Guid("764ea87b-d247-45b4-bf44-38e0ce962d87"), new DateTime(2020, 10, 10, 3, 16, 20, 866, DateTimeKind.Local).AddTicks(6936), null, true, new Guid("f647b102-25cc-440c-8f55-dab1ead4473d"), new Guid("af332496-abbe-4566-b146-bb20ae37cbc8"), null },
                    { new Guid("1d20c6e5-8f7b-439d-9cc1-d92228ae3bc0"), new DateTime(2020, 10, 10, 3, 16, 20, 866, DateTimeKind.Local).AddTicks(7108), null, true, new Guid("f647b102-25cc-440c-8f55-dab1ead4473d"), new Guid("17162112-f447-4043-a05f-45b2ad206c7e"), null },
                    { new Guid("87ea54d0-2313-48c7-a6a1-fb9b9ba93ede"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(4999), null, true, new Guid("9f0559c7-6cc5-4bd1-8ca5-506960855c73"), new Guid("8d33ca87-5573-45c7-ad27-85fd4fa87bba"), null },
                    { new Guid("b6abaa8f-88f2-403e-a28f-c1d15c3c9435"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(5296), null, true, new Guid("9f0559c7-6cc5-4bd1-8ca5-506960855c73"), new Guid("a8db8b70-18ff-4c8f-bf5a-63519159e986"), null },
                    { new Guid("18250d88-396d-4f52-98cd-1bb4f6a4d45c"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(5604), null, true, new Guid("9f0559c7-6cc5-4bd1-8ca5-506960855c73"), new Guid("37eaef25-5359-44d4-a735-61a2c21a3376"), null },
                    { new Guid("1eecb51b-faa1-465d-9325-c20fd4301b29"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(5740), null, true, new Guid("9f0559c7-6cc5-4bd1-8ca5-506960855c73"), new Guid("cb86eec4-0c83-4609-9e3d-3e74942637c6"), null },
                    { new Guid("7a15f561-3236-4748-a283-105f1d1337c9"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(5880), null, true, new Guid("9f0559c7-6cc5-4bd1-8ca5-506960855c73"), new Guid("72b2ed50-98f6-4e41-aab9-d54a61f863fc"), null },
                    { new Guid("e63c619a-7101-4de8-83a0-8f44f99be3a6"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(6077), null, true, new Guid("9f0559c7-6cc5-4bd1-8ca5-506960855c73"), new Guid("3770086e-7e61-4740-be01-1cac6093befc"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "PermissionId", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("5d194576-3443-4e1e-aaeb-b399837de489"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(6100), null, true, new Guid("3770086e-7e61-4740-be01-1cac6093befc"), new Guid("aa70bdf5-74f7-4cf7-b3db-1ab6c68f0937"), null },
                    { new Guid("fe009f06-184b-48d4-9e67-722b906cc14a"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(5958), null, true, new Guid("72b2ed50-98f6-4e41-aab9-d54a61f863fc"), new Guid("aa70bdf5-74f7-4cf7-b3db-1ab6c68f0937"), null },
                    { new Guid("69cc2f68-6104-4751-a297-6fba470cbc4f"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(5629), null, true, new Guid("37eaef25-5359-44d4-a735-61a2c21a3376"), new Guid("aa70bdf5-74f7-4cf7-b3db-1ab6c68f0937"), null },
                    { new Guid("fdec17c9-500f-410b-84b2-ba73f375e508"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(5338), null, true, new Guid("a8db8b70-18ff-4c8f-bf5a-63519159e986"), new Guid("aa70bdf5-74f7-4cf7-b3db-1ab6c68f0937"), null },
                    { new Guid("7917abec-5a0c-4c39-acc1-cfb87a8dd0cc"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(5765), null, true, new Guid("cb86eec4-0c83-4609-9e3d-3e74942637c6"), new Guid("aa70bdf5-74f7-4cf7-b3db-1ab6c68f0937"), null },
                    { new Guid("229a415f-bcc1-41dc-bab2-4b6211548f3d"), new DateTime(2020, 10, 10, 3, 16, 20, 866, DateTimeKind.Local).AddTicks(7131), null, true, new Guid("17162112-f447-4043-a05f-45b2ad206c7e"), new Guid("aa70bdf5-74f7-4cf7-b3db-1ab6c68f0937"), null },
                    { new Guid("998d360d-8c86-4916-8cbb-b032994b1d38"), new DateTime(2020, 10, 10, 3, 16, 20, 866, DateTimeKind.Local).AddTicks(6964), null, true, new Guid("af332496-abbe-4566-b146-bb20ae37cbc8"), new Guid("aa70bdf5-74f7-4cf7-b3db-1ab6c68f0937"), null },
                    { new Guid("082a9090-81b3-4e49-b80e-41ba43fca1f8"), new DateTime(2020, 10, 10, 3, 16, 20, 866, DateTimeKind.Local).AddTicks(5487), null, true, new Guid("c37e83f9-30b9-41d1-a486-fb5cc54de5d6"), new Guid("aa70bdf5-74f7-4cf7-b3db-1ab6c68f0937"), null },
                    { new Guid("939bd41e-ab6f-462e-98e0-a2d38a7647ba"), new DateTime(2020, 10, 10, 3, 16, 20, 866, DateTimeKind.Local).AddTicks(4830), null, true, new Guid("a52df285-9813-4f2a-928f-be48f59a3274"), new Guid("aa70bdf5-74f7-4cf7-b3db-1ab6c68f0937"), null },
                    { new Guid("1d81807b-7a95-40e9-9f48-dcdef96662e1"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(5138), null, true, new Guid("8d33ca87-5573-45c7-ad27-85fd4fa87bba"), new Guid("aa70bdf5-74f7-4cf7-b3db-1ab6c68f0937"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkUsersRoles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "RoleId", "UpdateDate", "UserId" },
                values: new object[] { new Guid("3a4f566f-9470-4ebb-af12-58c79714d578"), new DateTime(2020, 10, 10, 3, 16, 20, 863, DateTimeKind.Local).AddTicks(4596), null, true, new Guid("aa70bdf5-74f7-4cf7-b3db-1ab6c68f0937"), null, new Guid("11a5a9aa-b584-4f44-a8d8-6b8b37277d9e") });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ControllerName", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayName", "IsActive", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("f647b102-25cc-440c-8f55-dab1ead4473d"), "Role", new DateTime(2020, 10, 10, 3, 16, 20, 865, DateTimeKind.Local).AddTicks(1227), null, true, "Role Management", true, null },
                    { new Guid("9f0559c7-6cc5-4bd1-8ca5-506960855c73"), "User", new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(3894), null, true, "User Management", true, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayInPermissionTree", "DisplayName", "IsActive", "MethodName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("3770086e-7e61-4740-be01-1cac6093befc"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(6038), null, true, true, "New", true, "Create", null },
                    { new Guid("72b2ed50-98f6-4e41-aab9-d54a61f863fc"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(5839), null, false, true, "Restore", true, "Restore", null },
                    { new Guid("cb86eec4-0c83-4609-9e3d-3e74942637c6"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(5703), null, false, true, "Deactivate", true, "Deactivate", null },
                    { new Guid("37eaef25-5359-44d4-a735-61a2c21a3376"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(5558), null, false, true, "Edit", true, "Edit", null },
                    { new Guid("a8db8b70-18ff-4c8f-bf5a-63519159e986"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(5250), null, true, true, "Deactivated User List", true, "DeactivatedList", null },
                    { new Guid("c37e83f9-30b9-41d1-a486-fb5cc54de5d6"), new DateTime(2020, 10, 10, 3, 16, 20, 866, DateTimeKind.Local).AddTicks(5291), null, true, true, "New", true, "Create", null },
                    { new Guid("17162112-f447-4043-a05f-45b2ad206c7e"), new DateTime(2020, 10, 10, 3, 16, 20, 866, DateTimeKind.Local).AddTicks(7058), null, false, true, "Edit", true, "Edit", null },
                    { new Guid("af332496-abbe-4566-b146-bb20ae37cbc8"), new DateTime(2020, 10, 10, 3, 16, 20, 866, DateTimeKind.Local).AddTicks(6850), null, false, false, "Delete", true, "Delete", null },
                    { new Guid("a52df285-9813-4f2a-928f-be48f59a3274"), new DateTime(2020, 10, 10, 3, 16, 20, 865, DateTimeKind.Local).AddTicks(8904), null, true, true, "List", true, "List", null },
                    { new Guid("8d33ca87-5573-45c7-ad27-85fd4fa87bba"), new DateTime(2020, 10, 10, 3, 16, 20, 869, DateTimeKind.Local).AddTicks(4908), null, true, true, "Active User List", true, "ActiveList", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdateDate" },
                values: new object[] { new Guid("aa70bdf5-74f7-4cf7-b3db-1ab6c68f0937"), new DateTime(2020, 10, 10, 3, 16, 20, 852, DateTimeKind.Local).AddTicks(5148), null, "It has all permissions", true, "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsActive", "LastLoginDateTime", "Name", "Password", "Phone", "Surname", "UpdateDate" },
                values: new object[] { new Guid("11a5a9aa-b584-4f44-a8d8-6b8b37277d9e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 3, 16, 20, 863, DateTimeKind.Local).AddTicks(2503), "admin", true, null, "admin", "a/UlJadwnbomlQYEeSr7m/Mnf1uPrnNZ+52XZ7ppmnw=", null, "admin", null });
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
