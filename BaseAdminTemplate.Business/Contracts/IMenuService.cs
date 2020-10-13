using System;
using System.Linq;

using BaseAdminTemplate.Common.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.Business.Contracts
{
    public interface IMenuService
    {
        Response<IQueryable<Permission>> GetMenuChildList(Guid parentId);
        Response<IQueryable<Permission>> GetTreeChildList(Guid parentId);
        Response<IQueryable<Menu>> GetActiveMenus();
    }
}