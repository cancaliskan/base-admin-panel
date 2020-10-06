using Microsoft.EntityFrameworkCore;

using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Repositories
{
    public class ExceptionLogRepository : Repository<ExceptionLog>, IExceptionLogRepository
    {
        public ExceptionLogRepository(DbContext context) : base(context)
        {
        }
    }
}