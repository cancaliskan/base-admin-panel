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
    [Migration("20201006224730_Initial")]
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
                            Id = new Guid("d934319e-1f51-4e83-9b62-5032fcf0b222"),
                            CreatedDate = new DateTime(2020, 10, 7, 1, 47, 29, 330, DateTimeKind.Local).AddTicks(9964),
                            IsActive = true,
                            MenuId = new Guid("6fe35f09-bfbd-41e9-932a-d8926261abe9"),
                            PermissionId = new Guid("d0a810b5-8fe7-46ae-a87f-a342c62476d4")
                        },
                        new
                        {
                            Id = new Guid("0d8af2b5-d48f-465c-8d2d-1829f2fd1070"),
                            CreatedDate = new DateTime(2020, 10, 7, 1, 47, 29, 331, DateTimeKind.Local).AddTicks(6654),
                            IsActive = true,
                            MenuId = new Guid("6fe35f09-bfbd-41e9-932a-d8926261abe9"),
                            PermissionId = new Guid("9e5afe16-7944-4ed8-a1e6-4cc7f758733e")
                        },
                        new
                        {
                            Id = new Guid("b0d50bcd-ac38-49f3-a969-d06723c77338"),
                            CreatedDate = new DateTime(2020, 10, 7, 1, 47, 29, 338, DateTimeKind.Local).AddTicks(4663),
                            IsActive = true,
                            MenuId = new Guid("341df625-f9b9-40a5-80e2-02005d033546"),
                            PermissionId = new Guid("ce239a4a-b8ee-4b05-b298-8443c6832d6c")
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
                            Id = new Guid("94419d74-3977-4092-8128-aa0758af8000"),
                            CreatedDate = new DateTime(2020, 10, 7, 1, 47, 29, 331, DateTimeKind.Local).AddTicks(5057),
                            IsActive = true,
                            PermissionId = new Guid("d0a810b5-8fe7-46ae-a87f-a342c62476d4"),
                            RoleId = new Guid("8855090b-f9e1-4e99-83ec-c2d9014d04f0")
                        },
                        new
                        {
                            Id = new Guid("0930a7b3-1eab-4737-ac9d-169f575aa925"),
                            CreatedDate = new DateTime(2020, 10, 7, 1, 47, 29, 331, DateTimeKind.Local).AddTicks(6783),
                            IsActive = true,
                            PermissionId = new Guid("9e5afe16-7944-4ed8-a1e6-4cc7f758733e"),
                            RoleId = new Guid("8855090b-f9e1-4e99-83ec-c2d9014d04f0")
                        },
                        new
                        {
                            Id = new Guid("91e328cb-8ff3-43e4-8f5a-c78cbcc6ad16"),
                            CreatedDate = new DateTime(2020, 10, 7, 1, 47, 29, 338, DateTimeKind.Local).AddTicks(4734),
                            IsActive = true,
                            PermissionId = new Guid("ce239a4a-b8ee-4b05-b298-8443c6832d6c"),
                            RoleId = new Guid("8855090b-f9e1-4e99-83ec-c2d9014d04f0")
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
                            Id = new Guid("6fe35f09-bfbd-41e9-932a-d8926261abe9"),
                            ControllerName = "Home",
                            CreatedDate = new DateTime(2020, 10, 7, 1, 47, 29, 328, DateTimeKind.Local).AddTicks(3056),
                            DisplayInMenu = true,
                            DisplayName = "Parent Menu",
                            IsActive = true
                        },
                        new
                        {
                            Id = new Guid("341df625-f9b9-40a5-80e2-02005d033546"),
                            ControllerName = "Test",
                            CreatedDate = new DateTime(2020, 10, 7, 1, 47, 29, 338, DateTimeKind.Local).AddTicks(2121),
                            DisplayInMenu = true,
                            DisplayName = "Parent Menu 2",
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
                            Id = new Guid("d0a810b5-8fe7-46ae-a87f-a342c62476d4"),
                            CreatedDate = new DateTime(2020, 10, 7, 1, 47, 29, 330, DateTimeKind.Local).AddTicks(660),
                            DisplayInMenu = true,
                            DisplayName = "Sub Menu Display",
                            IsActive = true,
                            MethodName = "Index"
                        },
                        new
                        {
                            Id = new Guid("9e5afe16-7944-4ed8-a1e6-4cc7f758733e"),
                            CreatedDate = new DateTime(2020, 10, 7, 1, 47, 29, 331, DateTimeKind.Local).AddTicks(6417),
                            DisplayInMenu = false,
                            DisplayName = "Sub Menu Display",
                            IsActive = true,
                            MethodName = "Privacy"
                        },
                        new
                        {
                            Id = new Guid("ce239a4a-b8ee-4b05-b298-8443c6832d6c"),
                            CreatedDate = new DateTime(2020, 10, 7, 1, 47, 29, 338, DateTimeKind.Local).AddTicks(4380),
                            DisplayInMenu = true,
                            DisplayName = "Sub Menu 2",
                            IsActive = true,
                            MethodName = "Index"
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
                            Id = new Guid("8855090b-f9e1-4e99-83ec-c2d9014d04f0"),
                            CreatedDate = new DateTime(2020, 10, 7, 1, 47, 29, 298, DateTimeKind.Local).AddTicks(5978),
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
                            Id = new Guid("dde2f077-898c-40de-83cf-d4e071a8b51b"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletedDate = new DateTime(2020, 10, 7, 1, 47, 29, 326, DateTimeKind.Local).AddTicks(3166),
                            Email = "admin",
                            IsActive = true,
                            Name = "admin",
                            Password = "k7XZmqyoob/5j4aGkJ0yumMVg8dBky39qyMnhD6gPx0=",
                            Surname = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}