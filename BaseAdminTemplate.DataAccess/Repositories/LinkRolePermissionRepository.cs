using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using BaseAdminTemplate.DataAccess.Context;
using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Repositories
{
    public class LinkRolePermissionRepository : Repository<LinkRolePermission>, ILinkRolePermissionRepository
    {
        public ApplicationDbContext ApplicationContext => Context as ApplicationDbContext;

        public LinkRolePermissionRepository(DbContext context) : base(context)
        {
        }

        public bool AddPermissionToRole(Guid roleId, Guid permissionId)
        {
            if (!IsNotExistRoleAndPermission(roleId, permissionId))
            {
                return false;
            }

            var roleAndPermission = new LinkRolePermission()
            {
                RoleId = roleId,
                PermissionId = permissionId
            };

            Create(roleAndPermission);
            return true;
        }

        public bool RemovePermissionToRole(Guid roleId, Guid permissionId)
        {
            if (!IsNotExistRoleAndPermission(roleId, permissionId))
            {
                return false;
            }

            var roleAndPermission = GetByCondition(x => x.RoleId == roleId && x.PermissionId == permissionId && x.IsActive).FirstOrDefault();
            if (roleAndPermission == null)
            {
                return false;
            }

            HardDelete(roleAndPermission.Id);
            return true;
        }

        private bool IsNotExistRoleAndPermission(Guid roleId, Guid permissionId)
        {
            return ApplicationContext.Roles.Any(x => x.Id == roleId && x.IsActive)
                   && ApplicationContext.Permissions.Any(x => x.Id == permissionId && x.IsActive);
        }
    }
}