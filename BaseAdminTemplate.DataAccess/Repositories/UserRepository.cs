using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public Role GetRole(Guid id)
        {
            return GetById(id).Role;
        }

        public IQueryable<Permission> GetPermissions(Guid id)
        {
            return GetById(id).Role.Permissions.AsQueryable();
        }
    }
}