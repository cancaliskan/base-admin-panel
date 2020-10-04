using System;
using System.Linq;
using System.Linq.Expressions;

using BaseAdminTemplate.Common.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.Business.Contracts
{
    public interface IPermissionService
    {
        Response<Permission> GetById(Guid id);
        Response<IQueryable<Permission>> GetByCondition(Expression<Func<Permission, bool>> expression);
        Response<IQueryable<Permission>> GetAll();
        Response<IQueryable<Permission>> GetActivePermissions();
        Response<IQueryable<Permission>> GetInActivePermissions();
    }
}