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
                            Id = new Guid("17a98bf8-73ea-4471-94b7-d7e0a3054f17"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(3452),
                            IsActive = true,
                            MenuId = new Guid("cb7e987c-b34d-4276-b6cf-faede6451f1b"),
                            PermissionId = new Guid("feb7d98f-fd26-47ac-abaa-17c5fbc5b0b9")
                        },
                        new
                        {
                            Id = new Guid("239c4964-f360-4db5-8f86-f5a74d8ffb8c"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(6390),
                            IsActive = true,
                            MenuId = new Guid("cb7e987c-b34d-4276-b6cf-faede6451f1b"),
                            PermissionId = new Guid("6951a413-f059-4f38-b21d-875e8709e849")
                        },
                        new
                        {
                            Id = new Guid("d12de7ef-821f-45ce-aa37-7d3c7644dff1"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(8218),
                            IsActive = true,
                            MenuId = new Guid("cb7e987c-b34d-4276-b6cf-faede6451f1b"),
                            PermissionId = new Guid("6750146f-4c06-4603-8be3-ae64b1ee1415")
                        },
                        new
                        {
                            Id = new Guid("391ac752-5c87-4c2c-982c-50393d2695f8"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(8393),
                            IsActive = true,
                            MenuId = new Guid("cb7e987c-b34d-4276-b6cf-faede6451f1b"),
                            PermissionId = new Guid("aa693de9-584e-442d-883d-9d4b04c7706c")
                        },
                        new
                        {
                            Id = new Guid("b1617584-014b-49cb-b4ef-4593ea66565e"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(2602),
                            IsActive = true,
                            MenuId = new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"),
                            PermissionId = new Guid("e6d35733-4081-438a-accb-fd8aefb95267")
                        },
                        new
                        {
                            Id = new Guid("512df278-1bc0-4705-a795-b2217c26ee69"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(2877),
                            IsActive = true,
                            MenuId = new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"),
                            PermissionId = new Guid("a1fc75ba-8424-4200-a4da-c6bdd7de9209")
                        },
                        new
                        {
                            Id = new Guid("79b502a6-710d-4764-bb68-5b0b6c9cccf1"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3417),
                            IsActive = true,
                            MenuId = new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"),
                            PermissionId = new Guid("105a7c7e-cc0a-4ff5-a2c7-0865f12109d2")
                        },
                        new
                        {
                            Id = new Guid("21ec4cf1-b3ec-463c-81fe-b2f04d5243f9"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3636),
                            IsActive = true,
                            MenuId = new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"),
                            PermissionId = new Guid("73a195a9-c1e9-4e3a-bd71-a502eba24ac5")
                        },
                        new
                        {
                            Id = new Guid("110dae5a-7329-44d7-b1fc-f1c54b16eef3"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4010),
                            IsActive = true,
                            MenuId = new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"),
                            PermissionId = new Guid("75d46764-9f0d-4394-a2df-41be8cd6a73c")
                        },
                        new
                        {
                            Id = new Guid("883ac054-a8d4-4845-be3c-5d9cb9ed46dd"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4267),
                            IsActive = true,
                            MenuId = new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"),
                            PermissionId = new Guid("1dae0ede-2829-4a79-83ca-ced06cba0725")
                        },
                        new
                        {
                            Id = new Guid("c98f85ce-5058-4ffd-b991-66e8bf06d1fa"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4509),
                            IsActive = true,
                            MenuId = new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"),
                            PermissionId = new Guid("d3be56c5-e577-41fc-bc0d-689a56604d96")
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
                            Id = new Guid("ca59e968-ac78-43ec-834d-c7df1e211e25"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(5653),
                            IsActive = true,
                            PermissionId = new Guid("feb7d98f-fd26-47ac-abaa-17c5fbc5b0b9"),
                            RoleId = new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70")
                        },
                        new
                        {
                            Id = new Guid("4c11f1e6-18dd-497b-99d3-88ab948acb48"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(6448),
                            IsActive = true,
                            PermissionId = new Guid("6951a413-f059-4f38-b21d-875e8709e849"),
                            RoleId = new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70")
                        },
                        new
                        {
                            Id = new Guid("9abdb00c-7e8a-45a3-a8e6-d8dc108b98c2"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(8245),
                            IsActive = true,
                            PermissionId = new Guid("6750146f-4c06-4603-8be3-ae64b1ee1415"),
                            RoleId = new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70")
                        },
                        new
                        {
                            Id = new Guid("1aa4b7ba-39b0-4c9d-bd08-c4ae2d671d92"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(8422),
                            IsActive = true,
                            PermissionId = new Guid("aa693de9-584e-442d-883d-9d4b04c7706c"),
                            RoleId = new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70")
                        },
                        new
                        {
                            Id = new Guid("9c614648-0112-4e0b-bf6b-78d097ce712f"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(2659),
                            IsActive = true,
                            PermissionId = new Guid("e6d35733-4081-438a-accb-fd8aefb95267"),
                            RoleId = new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70")
                        },
                        new
                        {
                            Id = new Guid("37d60fe6-446f-4a15-8c7e-365c3e7442ff"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(2917),
                            IsActive = true,
                            PermissionId = new Guid("a1fc75ba-8424-4200-a4da-c6bdd7de9209"),
                            RoleId = new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70")
                        },
                        new
                        {
                            Id = new Guid("b753c655-a46e-4b9c-a408-bb39e0881afa"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3456),
                            IsActive = true,
                            PermissionId = new Guid("105a7c7e-cc0a-4ff5-a2c7-0865f12109d2"),
                            RoleId = new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70")
                        },
                        new
                        {
                            Id = new Guid("685fc272-6b6d-4e7d-89a7-079eda45d51a"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3674),
                            IsActive = true,
                            PermissionId = new Guid("73a195a9-c1e9-4e3a-bd71-a502eba24ac5"),
                            RoleId = new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70")
                        },
                        new
                        {
                            Id = new Guid("960014a3-0d08-4af8-8319-ae4476b61ef9"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4076),
                            IsActive = true,
                            PermissionId = new Guid("75d46764-9f0d-4394-a2df-41be8cd6a73c"),
                            RoleId = new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70")
                        },
                        new
                        {
                            Id = new Guid("6c0d1a1a-8a6e-41ff-9ea7-78b9d1cd5acd"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4302),
                            IsActive = true,
                            PermissionId = new Guid("1dae0ede-2829-4a79-83ca-ced06cba0725"),
                            RoleId = new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70")
                        },
                        new
                        {
                            Id = new Guid("4d314fda-cfe1-43cc-92b1-1e4415d5a1da"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4546),
                            IsActive = true,
                            PermissionId = new Guid("d3be56c5-e577-41fc-bc0d-689a56604d96"),
                            RoleId = new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70")
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
                            Id = new Guid("1d858670-ad72-4b30-8e1c-5f0d59671435"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 24, DateTimeKind.Local).AddTicks(8937),
                            IsActive = true,
                            RoleId = new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"),
                            UserId = new Guid("4f597ad6-7a81-47a9-93aa-2de0da308ed5")
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
                            Id = new Guid("cb7e987c-b34d-4276-b6cf-faede6451f1b"),
                            ControllerName = "Role",
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 26, DateTimeKind.Local).AddTicks(9607),
                            DisplayInMenu = true,
                            DisplayName = "Role Management",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("a22088c9-b778-451c-926a-cc4cd3800b6a"),
                            ControllerName = "User",
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(1111),
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
                            Id = new Guid("feb7d98f-fd26-47ac-abaa-17c5fbc5b0b9"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 27, DateTimeKind.Local).AddTicks(8963),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "List",
                            IsActive = true,
                            MethodName = "List"
                        },
                        new
                        {
                            Id = new Guid("6951a413-f059-4f38-b21d-875e8709e849"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(6268),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "New",
                            IsActive = true,
                            MethodName = "Create"
                        },
                        new
                        {
                            Id = new Guid("6750146f-4c06-4603-8be3-ae64b1ee1415"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(8116),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = false,
                            DisplayName = "Delete",
                            IsActive = true,
                            MethodName = "Delete"
                        },
                        new
                        {
                            Id = new Guid("aa693de9-584e-442d-883d-9d4b04c7706c"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 28, DateTimeKind.Local).AddTicks(8348),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = true,
                            DisplayName = "Edit",
                            IsActive = true,
                            MethodName = "Edit"
                        },
                        new
                        {
                            Id = new Guid("e6d35733-4081-438a-accb-fd8aefb95267"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(2400),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "Active User List",
                            IsActive = true,
                            MethodName = "ActiveList"
                        },
                        new
                        {
                            Id = new Guid("a1fc75ba-8424-4200-a4da-c6bdd7de9209"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(2812),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "Deactivated User List",
                            IsActive = true,
                            MethodName = "DeactivatedList"
                        },
                        new
                        {
                            Id = new Guid("105a7c7e-cc0a-4ff5-a2c7-0865f12109d2"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3342),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = true,
                            DisplayName = "Edit",
                            IsActive = true,
                            MethodName = "Edit"
                        },
                        new
                        {
                            Id = new Guid("73a195a9-c1e9-4e3a-bd71-a502eba24ac5"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3581),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = true,
                            DisplayName = "Deactivate",
                            IsActive = true,
                            MethodName = "Deactivate"
                        },
                        new
                        {
                            Id = new Guid("75d46764-9f0d-4394-a2df-41be8cd6a73c"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(3792),
                            DisplayInMenu = false,
                            DisplayInPermissionTree = true,
                            DisplayName = "Restore",
                            IsActive = true,
                            MethodName = "Restore"
                        },
                        new
                        {
                            Id = new Guid("1dae0ede-2829-4a79-83ca-ced06cba0725"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4210),
                            DisplayInMenu = true,
                            DisplayInPermissionTree = true,
                            DisplayName = "New",
                            IsActive = true,
                            MethodName = "Create"
                        },
                        new
                        {
                            Id = new Guid("d3be56c5-e577-41fc-bc0d-689a56604d96"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 33, DateTimeKind.Local).AddTicks(4459),
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
                            Id = new Guid("26dbd4c3-19b4-4cf3-9957-65e162544f70"),
                            CreatedDate = new DateTime(2020, 10, 10, 19, 33, 46, 8, DateTimeKind.Local).AddTicks(9680),
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
                            Id = new Guid("4f597ad6-7a81-47a9-93aa-2de0da308ed5"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedDate = new DateTime(2020, 10, 10, 19, 33, 46, 24, DateTimeKind.Local).AddTicks(6365),
                            Email = "admin",
                            IsActive = true,
                            Name = "admin",
                            Password = "yMiyl4uqC9SktM7PAqwM9vUa4s6eKn//+NFcoOg1Jjo=",
                            Surname = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
