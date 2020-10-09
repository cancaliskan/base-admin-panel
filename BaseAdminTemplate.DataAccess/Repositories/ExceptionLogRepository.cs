using Microsoft.EntityFrameworkCore;

using BaseAdminTemplate.DataAccess.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.DataAccess.Repositories
{
    public sealed class ExceptionLogRepository : Repository<ExceptionLog>, IExceptionLogRepository
    {
        public ExceptionLogRepository(DbContext context) : base(context)
        {
        }
    }
}