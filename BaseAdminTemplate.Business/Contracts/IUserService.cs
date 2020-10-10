using System;
using System.Linq;
using System.Linq.Expressions;

using BaseAdminTemplate.Common.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.Business.Contracts
{
    public interface IUserService
    {
        Response<User> GetById(Guid id);
        Response<IQueryable<User>> GetAll();
        Response<IQueryable<User>> GetByCondition(Expression<Func<User, bool>> expression);
        Response<IQueryable<User>> GetActiveUsers();
        Response<IQueryable<User>> GetInActiveUsers();
        Response<User> Create(User entity);
        Response<User> Update(User entity);
        Response<bool> SoftDelete(Guid id);
        Response<bool> HardDelete(Guid id);
        Response<bool> Restore(Guid id);
        Response<User> Login(string email, string password);
        Response<User> ChangePassword(Guid id, string oldPassword, string newPassword);
        Response<Role> GetRole(Guid id);
        Response<IQueryable<Permission>> GetPermissions(Guid id);
        Response<bool> AddRoleToUser(Guid userId, Guid roleId);
        Response<bool> RemoveRoleFromUser(Guid userId, Guid roleId);
        Response<bool> UpdateRole(Guid userId, Guid roleId);
    }
}