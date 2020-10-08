using System;
using System.Linq;
using System.Linq.Expressions;

using BaseAdminTemplate.Common.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.Business.Contracts
{
    public interface IRoleService
    {
        Response<Role> GetById(Guid id);
        Response<IQueryable<Role>> GetAll();
        Response<IQueryable<Role>> GetByCondition(Expression<Func<Role, bool>> expression);
        Response<IQueryable<Role>> GetActiveRoles();
        Response<IQueryable<Role>> GetInActiveRoles();
        Response<Role> Create(Role role);
        Response<Role> Update(Role role);
        Response<bool> SoftDelete(Guid id);
        Response<bool> HardDelete(Guid id);
        Response<bool> Restore(Guid id);
        Response<IQueryable<Permission>> GetPermissions(Guid id);
        Response<bool> AddPermissionToRole(Guid roleId, Guid permissionId);
        Response<bool> RemovePermissionFromRole(Guid roleId, Guid permissionId);
        Response<bool> RemoveAllPermissionFromRole(Guid roleId);
    }
}