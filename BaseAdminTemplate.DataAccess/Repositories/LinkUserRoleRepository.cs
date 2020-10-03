using Microsoft.EntityFrameworkCore;

using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Repositories
{
    public class LinkUserRoleRepository : Repository<LinkUserRole>, ILinkUserRoleRepository
    {
        public LinkUserRoleRepository(DbContext context) : base(context)
        {
        }
    }
}