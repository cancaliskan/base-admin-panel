using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using BaseAdminTemplate.DataAccess.Context;
using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Repositories
{
    public sealed class LinkMenuPermissionRepository : Repository<LinkMenuPermission>, ILinkMenuPermissionRepository
    {
        public ApplicationDbContext ApplicationContext => Context as ApplicationDbContext;

        public LinkMenuPermissionRepository(DbContext context) : base(context)
        {
        }

        public Menu GetParent(Guid permissionId)
        {
            var menuId = GetByCondition(x => x.PermissionId == permissionId).FirstOrDefault().MenuId;
            return ApplicationContext.Menus.FirstOrDefault(x => x.Id == menuId);
        }
    }
}