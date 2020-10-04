using System.Linq;

using BaseAdminTemplate.Common.Contracts;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.Business.Contracts
{
    public interface IExceptionLogService
    {
        Response<IQueryable<ExceptionLog>> GetAll();
        Response<bool> DeleteAll();
    }
}