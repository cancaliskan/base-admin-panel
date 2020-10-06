using System;

using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Contracts
{
    public interface ILinkRolePermissionRepository : IRepository<LinkRolePermission>
    {
        bool AddPermissionToRole(Guid roleId, Guid permissionId);
        bool RemovePermissionToRole(Guid roleId, Guid permissionId);
    }
}