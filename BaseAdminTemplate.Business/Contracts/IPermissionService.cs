using System;
using System.Linq;

using BaseAdminTemplate.Common.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.Business.Contracts
{
    public interface IPermissionService
    {
        Response<Permission> GetById(Guid id);
        Response<IQueryable<Permission>> GetAll();
        Response<IQueryable<Permission>> GetActivePermissions();
        Response<IQueryable<Permission>> GetInActivePermissions();
        Response<bool> SoftDelete(Guid id);
        Response<bool> HardDelete(Guid id);
    }
}