using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseAdminTemplate.DataAccess.Repositories
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(DbContext context) : base(context)
        {
        }
    }
}