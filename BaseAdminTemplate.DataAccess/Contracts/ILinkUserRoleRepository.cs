using System;

using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Contracts
{
    public interface ILinkUserRoleRepository : IRepository<LinkUserRole>
    {
        bool AddRoleToUser(Guid userId, Guid roleId);
        bool RemoveRoleFromUser(Guid userId, Guid roleId);
    }
}