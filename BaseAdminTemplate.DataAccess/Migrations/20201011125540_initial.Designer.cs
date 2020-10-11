﻿// <auto-generated />
using System;
using BaseAdminTemplate.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BaseAdminTemplate.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201011125540_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("b7e01eb9-7600-4b8c-ae2b-6ebb6c5cf11f"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(2582),
                            IsActive = true,
                            MenuId = new Guid("1aca29f3-17ad-431f-a6d0-c47c663c7916"),
                            PermissionId = new Guid("18ba41af-ce65-4bff-aff3-5ab07e0963eb")
                        },
                        new
                        {
                            Id = new Guid("d9520054-591f-4d34-81bd-771d4a7a1630"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(5115),
                            IsActive = true,
                            MenuId = new Guid("1aca29f3-17ad-431f-a6d0-c47c663c7916"),
                            PermissionId = new Guid("81ca908a-4a39-47f2-9516-75b572a379ea")
                        },
                        new
                        {
                            Id = new Guid("7d0d67d3-a678-4f12-b403-00a7b223cb74"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(6521),
                            IsActive = true,
                            MenuId = new Guid("1aca29f3-17ad-431f-a6d0-c47c663c7916"),
                            PermissionId = new Guid("58601a31-e483-4423-83d1-c13c26ca1929")
                        },
                        new
                        {
                            Id = new Guid("fb33ab57-aed0-447b-9c2b-42fba351c9ce"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(6795),
                            IsActive = true,
                            MenuId = new Guid("1aca29f3-17ad-431f-a6d0-c47c663c7916"),
                            PermissionId = new Guid("f9c9595b-5081-4e7a-aa1b-45827ea6ce61")
                        },
                        new
                        {
                            Id = new Guid("79d6272f-1c8f-4c5a-b034-da176205bd00"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(1791),
                            IsActive = true,
                            MenuId = new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"),
                            PermissionId = new Guid("380b6d69-6eb3-4522-bb32-208a64f2d3b8")
                        },
                        new
                        {
                            Id = new Guid("7b30bc2e-fec3-4d98-ae12-81b1456825e9"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2057),
                            IsActive = true,
                            MenuId = new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"),
                            PermissionId = new Guid("5938d4ad-c2cf-414b-98a9-a78ffd00c08b")
                        },
                        new
                        {
                            Id = new Guid("22281009-c7a1-4d7c-b4bf-5217f1472b33"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2347),
                            IsActive = true,
                            MenuId = new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"),
                            PermissionId = new Guid("68fc05b8-745b-41ae-b55b-15023d8de19b")
                        },
                        new
                        {
                            Id = new Guid("5ecc3f07-03c7-4445-8e98-980ef4fa5e78"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2484),
                            IsActive = true,
                            MenuId = new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"),
                            PermissionId = new Guid("c8eae4e0-44b9-406c-8356-e5fb610f2abf")
                        },
                        new
                        {
                            Id = new Guid("a1ee0e15-aca7-4ecd-8871-63fda4212c11"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2624),
                            IsActive = true,
                            MenuId = new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"),
                            PermissionId = new Guid("68b3cb77-3716-40bc-99ff-c7f6377383ea")
                        },
                        new
                        {
                            Id = new Guid("95845110-2aa0-43a8-8d41-c139387cdaed"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2822),
                            IsActive = true,
                            MenuId = new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"),
                            PermissionId = new Guid("b92da037-fa04-4e0d-a33b-33e23416ced4")
                        },
                        new
                        {
                            Id = new Guid("56903ca3-48e8-46bb-89d4-ce113a4cdf10"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2970),
                            IsActive = true,
                            MenuId = new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"),
                            PermissionId = new Guid("74d5bbab-0442-4042-8073-68b7831028c2")
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
                            Id = new Guid("b021fc06-459b-410f-9741-91a495edba0c"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(4536),
                            IsActive = true,
                            PermissionId = new Guid("18ba41af-ce65-4bff-aff3-5ab07e0963eb"),
                            RoleId = new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74")
                        },
                        new
                        {
                            Id = new Guid("6e34fbb2-4fc9-4222-b83d-8ec5ed6c1cd8"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(5174),
                            IsActive = true,
                            PermissionId = new Guid("81ca908a-4a39-47f2-9516-75b572a379ea"),
                            RoleId = new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74")
                        },
                        new
                        {
                            Id = new Guid("148a7a4b-e3db-4979-b87c-f5292b0ef9be"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(6645),
                            IsActive = true,
                            PermissionId = new Guid("58601a31-e483-4423-83d1-c13c26ca1929"),
                            RoleId = new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74")
                        },
                        new
                        {
                            Id = new Guid("dee9c44f-14ad-4923-9d05-c3408131508a"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(6818),
                            IsActive = true,
                            PermissionId = new Guid("f9c9595b-5081-4e7a-aa1b-45827ea6ce61"),
                            RoleId = new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74")
                        },
                        new
                        {
                            Id = new Guid("64800300-541a-452f-9dd4-76c65ca25dca"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(1912),
                            IsActive = true,
                            PermissionId = new Guid("380b6d69-6eb3-4522-bb32-208a64f2d3b8"),
                            RoleId = new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74")
                        },
                        new
                        {
                            Id = new Guid("11bcdb79-19d5-453f-aeef-02976a4705a1"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2089),
                            IsActive = true,
                            PermissionId = new Guid("5938d4ad-c2cf-414b-98a9-a78ffd00c08b"),
                            RoleId = new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74")
                        },
                        new
                        {
                            Id = new Guid("257a1719-3323-46c3-8e29-46624cf2fcb5"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2371),
                            IsActive = true,
                            PermissionId = new Guid("68fc05b8-745b-41ae-b55b-15023d8de19b"),
                            RoleId = new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74")
                        },
                        new
                        {
                            Id = new Guid("df4fb3c4-6da2-4ba7-aea6-48cb0ec26f67"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2506),
                            IsActive = true,
                            PermissionId = new Guid("c8eae4e0-44b9-406c-8356-e5fb610f2abf"),
                            RoleId = new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74")
                        },
                        new
                        {
                            Id = new Guid("033e8eca-58d7-4a4d-8b03-855f7f2de953"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2649),
                            IsActive = true,
                            PermissionId = new Guid("68b3cb77-3716-40bc-99ff-c7f6377383ea"),
                            RoleId = new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74")
                        },
                        new
                        {
                            Id = new Guid("207dfc6c-7980-45f1-9c20-3372ab276de3"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2845),
                            IsActive = true,
                            PermissionId = new Guid("b92da037-fa04-4e0d-a33b-33e23416ced4"),
                            RoleId = new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74")
                        },
                        new
                        {
                            Id = new Guid("cd738882-5256-4b21-b786-a8e7c9d8945f"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2992),
                            IsActive = true,
                            PermissionId = new Guid("74d5bbab-0442-4042-8073-68b7831028c2"),
                            RoleId = new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74")
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
                            Id = new Guid("b72a990c-a74a-4733-b2f3-e6267637c20d"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 141, DateTimeKind.Local).AddTicks(5584),
                            IsActive = true,
                            RoleId = new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"),
                            UserId = new Guid("27cd9a2b-63fb-4260-a7e5-9d05dc9544f8")
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
                            Id = new Guid("1aca29f3-17ad-431f-a6d0-c47c663c7916"),
                            ControllerName = "Role",
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 143, DateTimeKind.Local).AddTicks(1431),
                            DisplayInMenu = true,
                            DisplayName = "Role Management",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("51f0502a-a684-4c12-bb76-ea87a8a4f099"),
                            ControllerName = "User",
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(920),
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
                            Id = new Guid("18ba41af-ce65-4bff-aff3-5ab07e0963eb"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 143, DateTimeKind.Local).AddTicks(8892),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "List",
                            IsActive = true,
                            MethodName = "List"
                        },
                        new
                        {
                            Id = new Guid("81ca908a-4a39-47f2-9516-75b572a379ea"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(4997),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "New",
                            IsActive = true,
                            MethodName = "Create"
                        },
                        new
                        {
                            Id = new Guid("58601a31-e483-4423-83d1-c13c26ca1929"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(6438),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = false,
                            DisplayName = "Delete",
                            IsActive = true,
                            MethodName = "Delete"
                        },
                        new
                        {
                            Id = new Guid("f9c9595b-5081-4e7a-aa1b-45827ea6ce61"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 144, DateTimeKind.Local).AddTicks(6746),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = true,
                            DisplayName = "Edit",
                            IsActive = true,
                            MethodName = "Edit"
                        },
                        new
                        {
                            Id = new Guid("380b6d69-6eb3-4522-bb32-208a64f2d3b8"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(1715),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "Active User List",
                            IsActive = true,
                            MethodName = "ActiveList"
                        },
                        new
                        {
                            Id = new Guid("5938d4ad-c2cf-414b-98a9-a78ffd00c08b"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2014),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "Deactivated User List",
                            IsActive = true,
                            MethodName = "DeactivatedList"
                        },
                        new
                        {
                            Id = new Guid("68fc05b8-745b-41ae-b55b-15023d8de19b"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2301),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = true,
                            DisplayName = "Edit",
                            IsActive = true,
                            MethodName = "Edit"
                        },
                        new
                        {
                            Id = new Guid("c8eae4e0-44b9-406c-8356-e5fb610f2abf"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2447),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = true,
                            DisplayName = "Deactivate",
                            IsActive = true,
                            MethodName = "Deactivate"
                        },
                        new
                        {
                            Id = new Guid("68b3cb77-3716-40bc-99ff-c7f6377383ea"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2580),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = true,
                            DisplayName = "Restore",
                            IsActive = true,
                            MethodName = "Restore"
                        },
                        new
                        {
                            Id = new Guid("b92da037-fa04-4e0d-a33b-33e23416ced4"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2781),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "New",
                            IsActive = true,
                            MethodName = "Create"
                        },
                        new
                        {
                            Id = new Guid("74d5bbab-0442-4042-8073-68b7831028c2"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 147, DateTimeKind.Local).AddTicks(2939),
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
                            Id = new Guid("0b3b73a5-8e96-41c2-a256-3ba174fc8d74"),
                            CreatedDate = new DateTime(2020, 10, 11, 15, 55, 40, 130, DateTimeKind.Local).AddTicks(5239),
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
                            Id = new Guid("27cd9a2b-63fb-4260-a7e5-9d05dc9544f8"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedDate = new DateTime(2020, 10, 11, 15, 55, 40, 141, DateTimeKind.Local).AddTicks(3574),
                            Email = "admin",
                            IsActive = true,
                            Name = "admin",
                            Password = "rlcOQQovIUq24L/jH2biiuvfHEFwtm5FTT0BR/cDyv4=",
                            Surname = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}