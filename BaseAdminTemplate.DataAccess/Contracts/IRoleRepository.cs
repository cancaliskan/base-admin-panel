using System;
using System.Linq;

using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Contracts
{
    public interface IRoleRepository : IRepository<Role>
    {
        IQueryable<Permission> GetPermissions(Guid id);
    }
}