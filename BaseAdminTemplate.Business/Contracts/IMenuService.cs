using System;
using System.Linq;

using BaseAdminTemplate.Common.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.Business.Contracts
{
    public interface IMenuService
    {
        Response<IQueryable<Permission>> GetChildList(Guid parentId);
    }
}