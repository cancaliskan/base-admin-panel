﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using BaseAdminTemplate.Common.Helpers;
using BaseAdminTemplate.DataAccess.Helpers;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

        public DbSet<LinkMenuPermission> LinkMenusPermissions { get; set; }
        public DbSet<LinkRolePermission> LinkRolesPermissions { get; set; }
        public DbSet<LinkUserRole> LinkUsersRoles { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var webProjectPath = ConfigurationParameterHelper.GetConfigurationParameter("WebProjectPath");
            var controllers = GetWebProjectControllers(webProjectPath).ToList();

            #region Seed Admin Role

            var adminRole = new Role()
            {
                Id = Guid.NewGuid(),
                Name = "Admin",
                CreatedDate = DateTime.Now,
                IsActive = true,
                Description = "It has all permissions"
            };

            modelBuilder.Entity<Role>().HasData(adminRole);

            #endregion

            #region Seed Admin User

            var adminUser = new User()
            {
                Id = Guid.NewGuid(),
                Email = ConfigurationParameterHelper.GetConfigurationParameter("AdminUserEmail"),
                Password = CryptoHelper.Encrypt(ConfigurationParameterHelper.GetConfigurationParameter("AdminUserPassword")),
                Name = ConfigurationParameterHelper.GetConfigurationParameter("AdminUserName"),
                Surname = ConfigurationParameterHelper.GetConfigurationParameter("AdminUserSurname"),
                DeletedDate = DateTime.Now,
                IsActive = true
            };

            modelBuilder.Entity<User>().HasData(adminUser);

            #endregion

            foreach (var controller in controllers)
            {
                #region Seed Menu Item

                var controllerDisplayName = controller.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                    .Cast<DisplayNameAttribute>().SingleOrDefault()?.DisplayName;

                if (!controllerDisplayName.IsNotEmpty()) continue;

                var menu = new Menu
                {
                    Id = Guid.NewGuid(),
                    Name = controllerDisplayName,
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                modelBuilder.Entity<Menu>().HasData(menu);

                #endregion

                var methods = controller.GetMethods().Where(method => method.IsPublic && !method.IsDefined(typeof(NonActionAttribute)) && method.ReturnType == typeof(IActionResult));
                foreach (var method in methods)
                {
                    #region Seed Permission Item

                    var methodDisplayName = method.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                        .Cast<DisplayNameAttribute>().SingleOrDefault()?.DisplayName;

                    if (!methodDisplayName.IsNotEmpty()) continue;

                    var permission = new Permission()
                    {
                        Id = Guid.NewGuid(),
                        Name = methodDisplayName,
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    };

                    modelBuilder.Entity<Permission>().HasData(permission);

                    #endregion

                    #region Seed Link Menu and Permission Item

                    var linkMenuPermission = new LinkMenuPermission()
                    {
                        Id = Guid.NewGuid(),
                        MenuId = menu.Id,
                        PermissionId = permission.Id,
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    };

                    modelBuilder.Entity<LinkMenuPermission>().HasData(linkMenuPermission);

                    #endregion

                    #region Seed Link Role and Permissions Item

                    var linkRolePermission = new LinkRolePermission()
                    {
                        Id = Guid.NewGuid(),
                        RoleId = adminRole.Id,
                        PermissionId = permission.Id,
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    };

                    modelBuilder.Entity<LinkRolePermission>().HasData(linkRolePermission);

                    #endregion
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        private static IEnumerable<Type> GetWebProjectControllers(string webProjectPath)
        {
            Assembly.LoadFile(webProjectPath);
            var assembly = AppDomain.CurrentDomain.GetAssemblies()
                                                  .FirstOrDefault(x => x.FullName != null
                                                                       && x.FullName.Contains("BaseAdminTemplate.Web"));
            if (assembly == null) return null;

            var controllers = assembly.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type));
            return controllers;
        }
    }
}
