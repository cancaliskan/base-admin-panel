﻿// <auto-generated />
using System;
using BaseAdminTemplate.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaseAdminTemplate.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.1.20451.13");

            modelBuilder.Entity("BaseAdminTemplate.Domain.Entities.ExceptionLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MethodName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ExceptionLogs");
                });

            modelBuilder.Entity("BaseAdminTemplate.Domain.Entities.LinkMenuPermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("LinkMenusPermissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("01ece755-025e-4079-9c0a-bc574593782c"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(4681),
                            IsActive = true,
                            MenuId = new Guid("b573800a-9317-45cb-86a9-5f099f205d3d"),
                            PermissionId = new Guid("690cb5d0-5264-4530-8b14-ed0a3f74aee1")
                        },
                        new
                        {
                            Id = new Guid("59592d96-ffcc-484a-bcb1-dadcb9d71c22"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(7589),
                            IsActive = true,
                            MenuId = new Guid("b573800a-9317-45cb-86a9-5f099f205d3d"),
                            PermissionId = new Guid("1bd192dc-1dce-4cf8-8f32-53f7b5b10b55")
                        },
                        new
                        {
                            Id = new Guid("f50ec72c-49fc-4d0c-87ce-bf8704a2bfc5"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(9293),
                            IsActive = true,
                            MenuId = new Guid("b573800a-9317-45cb-86a9-5f099f205d3d"),
                            PermissionId = new Guid("0215fc8a-9e25-48fc-a024-6e29381bb04a")
                        },
                        new
                        {
                            Id = new Guid("c553a14a-2092-41b0-811c-d77ab67be852"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(9573),
                            IsActive = true,
                            MenuId = new Guid("b573800a-9317-45cb-86a9-5f099f205d3d"),
                            PermissionId = new Guid("540a0db0-ab34-4126-a451-c93f1d693055")
                        },
                        new
                        {
                            Id = new Guid("34db6b0b-8d41-48b0-a06e-2a893ed39ebb"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 551, DateTimeKind.Local).AddTicks(9909),
                            IsActive = true,
                            MenuId = new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"),
                            PermissionId = new Guid("f4c32e9b-cd4e-4e6f-82fa-c0ff208342a5")
                        },
                        new
                        {
                            Id = new Guid("bf916bae-b5ef-403e-984d-28ad96f614ab"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(189),
                            IsActive = true,
                            MenuId = new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"),
                            PermissionId = new Guid("85fb379e-5b30-46ca-a2c9-3c2ba41bdc92")
                        },
                        new
                        {
                            Id = new Guid("1e3acaff-6045-4e95-b49d-0b2ce5d13a86"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(494),
                            IsActive = true,
                            MenuId = new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"),
                            PermissionId = new Guid("f4a8204f-3547-4ad5-98ea-967a4ec4a85f")
                        },
                        new
                        {
                            Id = new Guid("bf88e466-7cb5-4741-89b4-2b33c1ad56f0"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(643),
                            IsActive = true,
                            MenuId = new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"),
                            PermissionId = new Guid("aa73cd60-326a-47b7-b5c0-8f9d09c2803a")
                        },
                        new
                        {
                            Id = new Guid("683bc7d2-3f58-4fa3-8745-b25c4a3233c6"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(782),
                            IsActive = true,
                            MenuId = new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"),
                            PermissionId = new Guid("41486cf3-50cc-4cdd-88ce-6b9195a1a1d9")
                        },
                        new
                        {
                            Id = new Guid("ae6b5ef9-9193-480d-950e-7efd15c85a24"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(987),
                            IsActive = true,
                            MenuId = new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"),
                            PermissionId = new Guid("8c2f9030-b283-46c0-95ca-80017cd6e308")
                        },
                        new
                        {
                            Id = new Guid("29345a95-7c2c-4c10-845f-323ebf9ded65"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(1143),
                            IsActive = true,
                            MenuId = new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"),
                            PermissionId = new Guid("ece55029-4f02-486c-873d-98c29c95ff39")
                        });
                });

            modelBuilder.Entity("BaseAdminTemplate.Domain.Entities.LinkRolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("LinkRolesPermissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4e85d4c0-7e8d-4d54-82a5-b051fca3ae62"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(6835),
                            IsActive = true,
                            PermissionId = new Guid("690cb5d0-5264-4530-8b14-ed0a3f74aee1"),
                            RoleId = new Guid("3a432956-84ef-4a31-854a-8d05edadc664")
                        },
                        new
                        {
                            Id = new Guid("14c1f778-59ca-4621-84b7-ddf6e719ab5d"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(7658),
                            IsActive = true,
                            PermissionId = new Guid("1bd192dc-1dce-4cf8-8f32-53f7b5b10b55"),
                            RoleId = new Guid("3a432956-84ef-4a31-854a-8d05edadc664")
                        },
                        new
                        {
                            Id = new Guid("3fefe45c-a9fc-4ce7-8f40-1487360b4f8e"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(9420),
                            IsActive = true,
                            PermissionId = new Guid("0215fc8a-9e25-48fc-a024-6e29381bb04a"),
                            RoleId = new Guid("3a432956-84ef-4a31-854a-8d05edadc664")
                        },
                        new
                        {
                            Id = new Guid("7efd2620-24c7-4ad8-b11d-32a7db995e05"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(9597),
                            IsActive = true,
                            PermissionId = new Guid("540a0db0-ab34-4126-a451-c93f1d693055"),
                            RoleId = new Guid("3a432956-84ef-4a31-854a-8d05edadc664")
                        },
                        new
                        {
                            Id = new Guid("e323080b-ba0f-42f4-bfe4-16432ab2ba69"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 551, DateTimeKind.Local).AddTicks(9946),
                            IsActive = true,
                            PermissionId = new Guid("f4c32e9b-cd4e-4e6f-82fa-c0ff208342a5"),
                            RoleId = new Guid("3a432956-84ef-4a31-854a-8d05edadc664")
                        },
                        new
                        {
                            Id = new Guid("0112f3ae-db9d-4b1b-828e-9d18ee4a63ff"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(213),
                            IsActive = true,
                            PermissionId = new Guid("85fb379e-5b30-46ca-a2c9-3c2ba41bdc92"),
                            RoleId = new Guid("3a432956-84ef-4a31-854a-8d05edadc664")
                        },
                        new
                        {
                            Id = new Guid("edc7280f-0609-49a5-8114-61f4c991abad"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(522),
                            IsActive = true,
                            PermissionId = new Guid("f4a8204f-3547-4ad5-98ea-967a4ec4a85f"),
                            RoleId = new Guid("3a432956-84ef-4a31-854a-8d05edadc664")
                        },
                        new
                        {
                            Id = new Guid("ab5a3d0a-9268-4fbd-836c-8ac5a3dab557"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(665),
                            IsActive = true,
                            PermissionId = new Guid("aa73cd60-326a-47b7-b5c0-8f9d09c2803a"),
                            RoleId = new Guid("3a432956-84ef-4a31-854a-8d05edadc664")
                        },
                        new
                        {
                            Id = new Guid("1799269c-3bce-45b1-87f6-26f0eec55dea"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(806),
                            IsActive = true,
                            PermissionId = new Guid("41486cf3-50cc-4cdd-88ce-6b9195a1a1d9"),
                            RoleId = new Guid("3a432956-84ef-4a31-854a-8d05edadc664")
                        },
                        new
                        {
                            Id = new Guid("d467262d-ca20-4940-9edd-9f72ae309bf3"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(1009),
                            IsActive = true,
                            PermissionId = new Guid("8c2f9030-b283-46c0-95ca-80017cd6e308"),
                            RoleId = new Guid("3a432956-84ef-4a31-854a-8d05edadc664")
                        },
                        new
                        {
                            Id = new Guid("5a9c01c4-ceb1-4d3f-8939-2e75eb04fd9e"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(1164),
                            IsActive = true,
                            PermissionId = new Guid("ece55029-4f02-486c-873d-98c29c95ff39"),
                            RoleId = new Guid("3a432956-84ef-4a31-854a-8d05edadc664")
                        });
                });

            modelBuilder.Entity("BaseAdminTemplate.Domain.Entities.LinkUserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("LinkUsersRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d8ca9efc-ed0f-460b-b586-7a115b34aa4b"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 545, DateTimeKind.Local).AddTicks(2261),
                            IsActive = true,
                            RoleId = new Guid("3a432956-84ef-4a31-854a-8d05edadc664"),
                            UserId = new Guid("7ebfa427-e5df-4bcf-90b7-14f10b85e1fa")
                        });
                });

            modelBuilder.Entity("BaseAdminTemplate.Domain.Entities.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ControllerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DisplayInMenu")
                        .HasColumnType("bit");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b573800a-9317-45cb-86a9-5f099f205d3d"),
                            ControllerName = "Role",
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 547, DateTimeKind.Local).AddTicks(1267),
                            DisplayInMenu = true,
                            DisplayName = "Role Management",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("7fb9b831-d912-48cc-b4b3-d297a8fa7237"),
                            ControllerName = "User",
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 551, DateTimeKind.Local).AddTicks(8645),
                            DisplayInMenu = true,
                            DisplayName = "User Management",
                            IsActive = true
                        });
                });

            modelBuilder.Entity("BaseAdminTemplate.Domain.Entities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DisplayInMenu")
                        .HasColumnType("bit");

                    b.Property<bool>("DisplayInPermissionTree")
                        .HasColumnType("bit");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MethodName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("690cb5d0-5264-4530-8b14-ed0a3f74aee1"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(425),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "List",
                            IsActive = true,
                            MethodName = "List"
                        },
                        new
                        {
                            Id = new Guid("1bd192dc-1dce-4cf8-8f32-53f7b5b10b55"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(7452),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "New",
                            IsActive = true,
                            MethodName = "Create"
                        },
                        new
                        {
                            Id = new Guid("0215fc8a-9e25-48fc-a024-6e29381bb04a"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(9211),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = false,
                            DisplayName = "Delete",
                            IsActive = true,
                            MethodName = "Delete"
                        },
                        new
                        {
                            Id = new Guid("540a0db0-ab34-4126-a451-c93f1d693055"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 548, DateTimeKind.Local).AddTicks(9529),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = true,
                            DisplayName = "Edit",
                            IsActive = true,
                            MethodName = "Edit"
                        },
                        new
                        {
                            Id = new Guid("f4c32e9b-cd4e-4e6f-82fa-c0ff208342a5"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 551, DateTimeKind.Local).AddTicks(9811),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "Active User List",
                            IsActive = true,
                            MethodName = "ActiveList"
                        },
                        new
                        {
                            Id = new Guid("85fb379e-5b30-46ca-a2c9-3c2ba41bdc92"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(140),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "Deactivated User List",
                            IsActive = true,
                            MethodName = "DeactivatedList"
                        },
                        new
                        {
                            Id = new Guid("f4a8204f-3547-4ad5-98ea-967a4ec4a85f"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(446),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = true,
                            DisplayName = "Edit",
                            IsActive = true,
                            MethodName = "Edit"
                        },
                        new
                        {
                            Id = new Guid("aa73cd60-326a-47b7-b5c0-8f9d09c2803a"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(603),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = true,
                            DisplayName = "Deactivate",
                            IsActive = true,
                            MethodName = "Deactivate"
                        },
                        new
                        {
                            Id = new Guid("41486cf3-50cc-4cdd-88ce-6b9195a1a1d9"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(741),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = true,
                            DisplayName = "Restore",
                            IsActive = true,
                            MethodName = "Restore"
                        },
                        new
                        {
                            Id = new Guid("8c2f9030-b283-46c0-95ca-80017cd6e308"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(940),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "New",
                            IsActive = true,
                            MethodName = "Create"
                        },
                        new
                        {
                            Id = new Guid("ece55029-4f02-486c-873d-98c29c95ff39"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 552, DateTimeKind.Local).AddTicks(1109),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = false,
                            DisplayName = "Delete",
                            IsActive = true,
                            MethodName = "Delete"
                        });
                });

            modelBuilder.Entity("BaseAdminTemplate.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3a432956-84ef-4a31-854a-8d05edadc664"),
                            CreatedDate = new DateTime(2020, 10, 10, 16, 45, 20, 532, DateTimeKind.Local).AddTicks(3958),
                            Description = "It has all permissions",
                            IsActive = true,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("BaseAdminTemplate.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastLoginDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7ebfa427-e5df-4bcf-90b7-14f10b85e1fa"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedDate = new DateTime(2020, 10, 10, 16, 45, 20, 544, DateTimeKind.Local).AddTicks(9628),
                            Email = "admin",
                            IsActive = true,
                            Name = "admin",
                            Password = "0HrPk1Q4ZjXbzF543So2oVu305DAa72+V9f/A3HtXiM=",
                            Surname = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
