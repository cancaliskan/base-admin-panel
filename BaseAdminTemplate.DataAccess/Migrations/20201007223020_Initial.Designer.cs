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
    [Migration("20201007223020_Initial")]
    partial class Initial
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
                            Id = new Guid("689e7882-8f21-4a39-90f4-e00cfbbc63d4"),
                            CreatedDate = new DateTime(2020, 10, 8, 1, 30, 19, 884, DateTimeKind.Local).AddTicks(1121),
                            IsActive = true,
                            MenuId = new Guid("93278a50-4e6f-43df-9293-ae743d792ba4"),
                            PermissionId = new Guid("5a88b83d-c50f-4ad7-a034-7b43ded2a53d")
                        },
                        new
                        {
                            Id = new Guid("897bdda6-8f83-48e9-b16b-a2e9db49a0d0"),
                            CreatedDate = new DateTime(2020, 10, 8, 1, 30, 19, 884, DateTimeKind.Local).AddTicks(3892),
                            IsActive = true,
                            MenuId = new Guid("93278a50-4e6f-43df-9293-ae743d792ba4"),
                            PermissionId = new Guid("faee95e1-5f30-42c1-a521-aa15880c6783")
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
                            Id = new Guid("620f2c25-fb0d-4723-8d3e-93da20e83e07"),
                            CreatedDate = new DateTime(2020, 10, 8, 1, 30, 19, 884, DateTimeKind.Local).AddTicks(3265),
                            IsActive = true,
                            PermissionId = new Guid("5a88b83d-c50f-4ad7-a034-7b43ded2a53d"),
                            RoleId = new Guid("76435ba2-e9c4-4b4d-8e56-194048e8da62")
                        },
                        new
                        {
                            Id = new Guid("021e100c-8a3a-4f68-ac85-ac0e354ce6e6"),
                            CreatedDate = new DateTime(2020, 10, 8, 1, 30, 19, 884, DateTimeKind.Local).AddTicks(3945),
                            IsActive = true,
                            PermissionId = new Guid("faee95e1-5f30-42c1-a521-aa15880c6783"),
                            RoleId = new Guid("76435ba2-e9c4-4b4d-8e56-194048e8da62")
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
                            Id = new Guid("93278a50-4e6f-43df-9293-ae743d792ba4"),
                            ControllerName = "Role",
                            CreatedDate = new DateTime(2020, 10, 8, 1, 30, 19, 882, DateTimeKind.Local).AddTicks(8996),
                            DisplayInMenu = true,
                            DisplayName = "Role Management",
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
                            Id = new Guid("5a88b83d-c50f-4ad7-a034-7b43ded2a53d"),
                            CreatedDate = new DateTime(2020, 10, 8, 1, 30, 19, 883, DateTimeKind.Local).AddTicks(7102),
                            DisplayInMenu = true,
                            DisplayName = "List",
                            IsActive = true,
                            MethodName = "List"
                        },
                        new
                        {
                            Id = new Guid("faee95e1-5f30-42c1-a521-aa15880c6783"),
                            CreatedDate = new DateTime(2020, 10, 8, 1, 30, 19, 884, DateTimeKind.Local).AddTicks(3767),
                            DisplayInMenu = true,
                            DisplayName = "New",
                            IsActive = true,
                            MethodName = "Create"
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
                            Id = new Guid("76435ba2-e9c4-4b4d-8e56-194048e8da62"),
                            CreatedDate = new DateTime(2020, 10, 8, 1, 30, 19, 869, DateTimeKind.Local).AddTicks(4646),
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
                            Id = new Guid("5b6614c1-511e-440c-b3a2-7d6a9ed245c7"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedDate = new DateTime(2020, 10, 8, 1, 30, 19, 881, DateTimeKind.Local).AddTicks(1826),
                            Email = "admin",
                            IsActive = true,
                            Name = "admin",
                            Password = "AeW866vx0XBJHYOTnzfmOjpIhsnbm7KWc/Zsu53tigI=",
                            Surname = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}