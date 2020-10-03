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
            var linkUserRole = ApplicationContext.LinkUsersRoles.FirstOrDefault(x => x.UserId == id)?.RoleId;
            var role = ApplicationContext.Roles.FirstOrDefault(x => x.Id == linkUserRole);
            return role;
        }

        public IQueryable<Permission> GetPermissions(Guid id)
        {
            var linkUserRole = ApplicationContext.LinkUsersRoles.FirstOrDefault(x => x.UserId == id)?.RoleId;
            var role = ApplicationContext.Roles.FirstOrDefault(x => x.Id == linkUserRole);
            var linkRolePermissionList = ApplicationContext.LinkRolesPermissions.Where(x => x.RoleId == role.Id);

            var permissionList = new List<Permission>();
            foreach (var linkRolePermission in linkRolePermissionList)
            {
                permissionList.Add(ApplicationContext.Permissions.FirstOrDefault(x => x.Id == linkRolePermission.PermissionId));
            }

            return permissionList.AsQueryable();
        }
    }
}