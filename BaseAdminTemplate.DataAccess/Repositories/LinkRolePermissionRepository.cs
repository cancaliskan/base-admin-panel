using Microsoft.EntityFrameworkCore;

using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Repositories
{
    public class LinkRolePermissionRepository : Repository<LinkRolePermission>, ILinkRolePermissionRepository
    {
        public LinkRolePermissionRepository(DbContext context) : base(context)
        {
        }
    }
}