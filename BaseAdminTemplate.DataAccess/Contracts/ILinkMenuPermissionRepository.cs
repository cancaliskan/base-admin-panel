using System;

using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Contracts
{
    public interface ILinkMenuPermissionRepository : IRepository<LinkMenuPermission>
    {
        Menu GetParent(Guid permissionId);
    }
}