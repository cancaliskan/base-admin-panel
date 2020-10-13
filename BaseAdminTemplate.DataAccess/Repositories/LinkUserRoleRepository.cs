using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using BaseAdminTemplate.DataAccess.Context;
using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Repositories
{
    public sealed class LinkUserRoleRepository : Repository<LinkUserRole>, ILinkUserRoleRepository
    {
        public ApplicationDbContext ApplicationContext => Context as ApplicationDbContext;

        public LinkUserRoleRepository(DbContext context) : base(context)
        {
        }

        public bool AddRoleToUser(Guid userId, Guid roleId)
        {
            if (!IsNotExistUserAndRole(userId, roleId))
            {
                return false;
            }

            var userAndRole = new LinkUserRole()
            {
                UserId = userId,
                RoleId = roleId
            };

            Create(userAndRole);
            return true;
        }

        public bool RemoveRoleFromUser(Guid userId, Guid roleId)
        {
            if (!IsNotExistUserAndRole(userId, roleId))
            {
                return false;
            }

            var userAndRole = GetByCondition(x => x.UserId == userId && x.RoleId == roleId && x.IsActive).FirstOrDefault();
            if (userAndRole == null)
            {
                return false;
            }

            HardDelete(userAndRole.Id);
            return true;
        }

        private bool IsNotExistUserAndRole(Guid userId, Guid roleId)
        {
            return ApplicationContext.Users.Any(x => x.Id == userId && x.IsActive)
                   && ApplicationContext.Roles.Any(x => x.Id == roleId && x.IsActive);
        }
    }
}