using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using BaseAdminTemplate.DataAccess.Context;
using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public ApplicationDbContext ApplicationContext => Context as ApplicationDbContext;

        public UserRepository(DbContext context) : base(context)
        {
        }

        public Role GetRole(Guid id)
        {
            var linkUserRole = ApplicationContext.LinkUsersRoles.AsNoTracking().FirstOrDefault(x => x.UserId == id)?.RoleId;
            var role = ApplicationContext.Roles.AsNoTracking().FirstOrDefault(x => x.Id == linkUserRole);
            return role;
        }

        public IQueryable<Permission> GetPermissions(Guid id)
        {
            var linkUserRole = ApplicationContext.LinkUsersRoles.AsNoTracking().FirstOrDefault(x => x.UserId == id)?.RoleId;
            var role = ApplicationContext.Roles.AsNoTracking().FirstOrDefault(x => x.Id == linkUserRole);
            var linkRolePermissionList = ApplicationContext.LinkRolesPermissions.AsNoTracking().Where(x => x.RoleId == role.Id);

            var permissionList = new List<Permission>();
            foreach (var linkRolePermission in linkRolePermissionList)
            {
                permissionList.Add(ApplicationContext.Permissions.AsNoTracking().FirstOrDefault(x => x.Id == linkRolePermission.PermissionId));
            }

            return permissionList.AsQueryable();
        }

        public User Login(User user)
        {
            user.LastLoginDateTime=DateTime.Now;
            ApplicationContext.Update(user);
            return user;
        }

        public void ChangePassword(User user, string newPassword)
        {
            user.Password = newPassword;
            Update(user);
        }
    }
}