using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BaseAdminTemplate.Common.Helpers;
using Microsoft.EntityFrameworkCore;

using BaseAdminTemplate.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BaseAdminTemplate.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                        .HasMany(role => role.Users)
                        .WithOne(user => user.Role);

            modelBuilder.Entity<Role>()
                        .HasMany(role => role.Permissions)
                        .WithOne(permission => permission.Role);

            modelBuilder.Entity<Menu>()
                        .HasMany(menu => menu.Permissions)
                        .WithOne(permission => permission.Menu);

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            Assembly.LoadFile(Directory.GetParent(Directory.GetCurrentDirectory()) + "\\BaseAdminTemplate.Web\\bin\\Debug\\netcoreapp3.1\\BaseAdminTemplate.Web.dll");
            var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.FullName != null && x.FullName.Contains("BaseAdminTemplate.Web"));
            if (assembly == null) return;
            
            var controllers = assembly.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type));

            Menu menu;
            foreach (var controller in controllers)
            {
                var controllerDisplayName = controller.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                                                           .Cast<DisplayNameAttribute>().SingleOrDefault()?.DisplayName;

                if (!controllerDisplayName.IsNotEmpty()) continue;
                menu = new Menu
                {
                    Id = Guid.NewGuid(),
                    Name = controllerDisplayName
                };

                modelBuilder.Entity<Menu>().HasData(menu);
            };

            var methods = controllers.SelectMany(type => type.GetMethods()).Where(method => method.IsPublic && !method.IsDefined(typeof(NonActionAttribute)) && method.ReturnType == typeof(IActionResult));
            foreach (var method in methods)
            {
                var methodDisplayName = method.GetCustomAttributes(typeof(DisplayNameAttribute), true)
                                                    .Cast<DisplayNameAttribute>().SingleOrDefault()?.DisplayName;
                    
                if (!methodDisplayName.IsNotEmpty()) continue;
                menu = new Menu()
                {
                    Id = Guid.NewGuid(),
                    Name = methodDisplayName
                };

                modelBuilder.Entity<Menu>().HasData(menu);
            }
        }
    }
}
