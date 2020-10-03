using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using BaseAdminTemplate.DataAccess.Context;
using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Repositories
{
    public sealed class RoleRepository : Repository<Role>, IRoleRepository
    {
        public ApplicationDbContext ApplicationContext => Context as ApplicationDbContext;

        public RoleRepository(DbContext context) : base(context)
        {

        }

        public IQueryable<Permission> GetPermissions(Guid id)
        {
            return GetById(id).Permissions.AsQueryable();
        }
    }
}