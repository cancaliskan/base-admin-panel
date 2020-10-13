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
                name: "PasswordResets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResets", x => x.Id);
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
                    { new Guid("d48e8c84-05fb-4817-99aa-458b2e5f097c"), new DateTime(2020, 10, 13, 0, 49, 34, 705, DateTimeKind.Local).AddTicks(4374), null, true, new Guid("58a89202-d09f-4d17-bf6e-f22d5aaa8ed7"), new Guid("930a7eb7-3483-498d-b9d3-680f1763f245"), null },
                    { new Guid("28d17d54-4355-4ca5-9fbb-abacf86d1a63"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1618), null, true, new Guid("644c7ce5-7aa4-4ac6-b7b0-354de647dda2"), new Guid("44b0151d-5680-4eb4-a68d-b1a67670a5c7"), null },
                    { new Guid("a7458340-23ae-4acc-8609-c98f7d9ca149"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1473), null, true, new Guid("644c7ce5-7aa4-4ac6-b7b0-354de647dda2"), new Guid("c3d55dc6-2d84-4da9-8842-50395832e12a"), null },
                    { new Guid("8663137a-6f62-46fa-aab4-191401fa3c11"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1339), null, true, new Guid("644c7ce5-7aa4-4ac6-b7b0-354de647dda2"), new Guid("c6bd3bef-b40e-4011-87e7-d2653a14ee84"), null },
                    { new Guid("c384c5e9-3eea-4872-9f90-48abd1f541a7"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1002), null, true, new Guid("644c7ce5-7aa4-4ac6-b7b0-354de647dda2"), new Guid("148b78f5-ac2e-482b-aed1-513a7e28e687"), null },
                    { new Guid("49015186-444f-41d1-9d21-624345f01472"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(743), null, true, new Guid("644c7ce5-7aa4-4ac6-b7b0-354de647dda2"), new Guid("1929c157-9e31-42da-af8a-f0c3b27d0c96"), null },
                    { new Guid("f4dbed84-b5c1-4d0b-a54a-a1a5f5964483"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1141), null, true, new Guid("644c7ce5-7aa4-4ac6-b7b0-354de647dda2"), new Guid("9e993916-5805-4631-9a3a-5a06967e3ce9"), null },
                    { new Guid("453bab10-ef8e-4b26-a428-40e13da04281"), new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(7447), null, true, new Guid("e5d70c31-13b7-4d81-8667-cc66d1db74f2"), new Guid("e081d3e6-974d-45e9-8776-c6c8a4d943a6"), null },
                    { new Guid("dae85a4a-afac-4374-bc0a-a08e4655fa86"), new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(7260), null, true, new Guid("e5d70c31-13b7-4d81-8667-cc66d1db74f2"), new Guid("8d560935-a636-4795-8520-1b58ca0100fd"), null },
                    { new Guid("db163ad8-9890-43c4-b262-e830cd282387"), new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(6000), null, true, new Guid("e5d70c31-13b7-4d81-8667-cc66d1db74f2"), new Guid("2d6ef6d4-ae00-4231-beea-7089e6a07f34"), null },
                    { new Guid("fd8d33f3-45a5-484b-907b-edef83529eba"), new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(5768), null, true, new Guid("e5d70c31-13b7-4d81-8667-cc66d1db74f2"), new Guid("6fccfd9c-43d3-4fb4-8717-5d34999b781c"), null },
                    { new Guid("b43c9c56-1e23-419c-9722-ddebcd923a26"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(593), null, true, new Guid("644c7ce5-7aa4-4ac6-b7b0-354de647dda2"), new Guid("403232fa-852c-41cc-bcb1-aff5e0749d9e"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkRolesPermissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "PermissionId", "RoleId", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("d9e08963-763e-4e0d-8c84-54a922acb4ce"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1025), null, true, new Guid("148b78f5-ac2e-482b-aed1-513a7e28e687"), new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), null },
                    { new Guid("cc0585ab-1d9a-4382-be4a-89feeb806614"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1644), null, true, new Guid("44b0151d-5680-4eb4-a68d-b1a67670a5c7"), new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), null },
                    { new Guid("b12b98d3-9889-4598-bcb9-25b5b14fc755"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1496), null, true, new Guid("c3d55dc6-2d84-4da9-8842-50395832e12a"), new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), null },
                    { new Guid("4b679c9e-1cfc-40c0-a66e-e3591bc19807"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1362), null, true, new Guid("c6bd3bef-b40e-4011-87e7-d2653a14ee84"), new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), null },
                    { new Guid("3a9a663a-04df-46a4-8e06-a33dd8fd9cb8"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(766), null, true, new Guid("1929c157-9e31-42da-af8a-f0c3b27d0c96"), new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), null },
                    { new Guid("65cdb58e-8f1f-4a42-8d12-ce470b187dc5"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1165), null, true, new Guid("9e993916-5805-4631-9a3a-5a06967e3ce9"), new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), null },
                    { new Guid("c469943c-1996-487e-8d14-fdb67a0007af"), new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(7472), null, true, new Guid("e081d3e6-974d-45e9-8776-c6c8a4d943a6"), new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), null },
                    { new Guid("9c16de85-673e-4e28-9eb6-13a8e418480a"), new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(7285), null, true, new Guid("8d560935-a636-4795-8520-1b58ca0100fd"), new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), null },
                    { new Guid("b662eee4-1204-4e85-9319-deef8745d02d"), new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(6023), null, true, new Guid("2d6ef6d4-ae00-4231-beea-7089e6a07f34"), new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), null },
                    { new Guid("1690f59d-8667-448d-b0c8-d647e64e305e"), new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(5830), null, true, new Guid("6fccfd9c-43d3-4fb4-8717-5d34999b781c"), new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), null },
                    { new Guid("1dc39abd-39b0-43f6-9253-78f0f2582d50"), new DateTime(2020, 10, 13, 0, 49, 34, 705, DateTimeKind.Local).AddTicks(6434), null, true, new Guid("930a7eb7-3483-498d-b9d3-680f1763f245"), new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), null },
                    { new Guid("5e5de17b-3449-4002-a349-b82217512918"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(619), null, true, new Guid("403232fa-852c-41cc-bcb1-aff5e0749d9e"), new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), null }
                });

            migrationBuilder.InsertData(
                table: "LinkUsersRoles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsActive", "RoleId", "UpdateDate", "UserId" },
                values: new object[] { new Guid("d19a3427-7d93-49c0-bcec-94e495f9b10e"), new DateTime(2020, 10, 13, 0, 49, 34, 701, DateTimeKind.Local).AddTicks(6601), null, true, new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), null, new Guid("dccc38ad-5cc2-4ad6-b7b7-4d5473504438") });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "ControllerName", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayName", "IsActive", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("58a89202-d09f-4d17-bf6e-f22d5aaa8ed7"), "ExceptionLog", new DateTime(2020, 10, 13, 0, 49, 34, 704, DateTimeKind.Local).AddTicks(869), null, true, "Exception Log", true, null },
                    { new Guid("e5d70c31-13b7-4d81-8667-cc66d1db74f2"), "Role", new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(4682), null, true, "Role Management", true, null },
                    { new Guid("644c7ce5-7aa4-4ac6-b7b0-354de647dda2"), "User", new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(9875), null, true, "User Management", true, null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DisplayInMenu", "DisplayInPermissionTree", "DisplayName", "IsActive", "MethodName", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("44b0151d-5680-4eb4-a68d-b1a67670a5c7"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1586), null, false, false, "Delete", true, "Delete", null },
                    { new Guid("c3d55dc6-2d84-4da9-8842-50395832e12a"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1435), null, true, true, "New", true, "Create", null },
                    { new Guid("c6bd3bef-b40e-4011-87e7-d2653a14ee84"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1299), null, false, true, "Restore", true, "Restore", null },
                    { new Guid("9e993916-5805-4631-9a3a-5a06967e3ce9"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(1100), null, false, true, "Deactivate", true, "Deactivate", null },
                    { new Guid("148b78f5-ac2e-482b-aed1-513a7e28e687"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(956), null, false, true, "Edit", true, "Edit", null },
                    { new Guid("1929c157-9e31-42da-af8a-f0c3b27d0c96"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(698), null, true, true, "Deactivated User List", true, "DeactivatedList", null },
                    { new Guid("6fccfd9c-43d3-4fb4-8717-5d34999b781c"), new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(5612), null, true, true, "List", true, "List", null },
                    { new Guid("e081d3e6-974d-45e9-8776-c6c8a4d943a6"), new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(7374), null, false, true, "Edit", true, "Edit", null },
                    { new Guid("8d560935-a636-4795-8520-1b58ca0100fd"), new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(7173), null, false, false, "Delete", true, "Delete", null },
                    { new Guid("2d6ef6d4-ae00-4231-beea-7089e6a07f34"), new DateTime(2020, 10, 13, 0, 49, 34, 708, DateTimeKind.Local).AddTicks(5954), null, true, true, "New", true, "Create", null },
                    { new Guid("930a7eb7-3483-498d-b9d3-680f1763f245"), new DateTime(2020, 10, 13, 0, 49, 34, 704, DateTimeKind.Local).AddTicks(9671), null, true, true, "List", true, "List", null },
                    { new Guid("403232fa-852c-41cc-bcb1-aff5e0749d9e"), new DateTime(2020, 10, 13, 0, 49, 34, 709, DateTimeKind.Local).AddTicks(530), null, true, true, "Active User List", true, "ActiveList", null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsActive", "Name", "UpdateDate" },
                values: new object[] { new Guid("db8f768e-a9ee-4242-97e3-bb260491e9d4"), new DateTime(2020, 10, 13, 0, 49, 34, 689, DateTimeKind.Local).AddTicks(7484), null, "It has all permissions", true, "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Email", "IsActive", "LastLoginDateTime", "Name", "Password", "Phone", "Surname", "UpdateDate" },
                values: new object[] { new Guid("dccc38ad-5cc2-4ad6-b7b7-4d5473504438"), new DateTime(2020, 10, 13, 0, 49, 34, 701, DateTimeKind.Local).AddTicks(4751), null, "admin", true, null, "admin", "D666+2ai9e6AyaRseO19bA==", null, "admin", null });
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
                name: "PasswordResets");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
