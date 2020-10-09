using Microsoft.EntityFrameworkCore;

using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Repositories
{
    public sealed class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(DbContext context) : base(context)
        {
        }
    }
}