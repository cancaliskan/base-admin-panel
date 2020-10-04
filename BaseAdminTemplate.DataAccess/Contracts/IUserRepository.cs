using System;
using System.Linq;

using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        Role GetRole(Guid id);
        IQueryable<Permission> GetPermissions(Guid id);
        User Login(User user);
        void ChangePassword(User user, string newPassword);
    }
}