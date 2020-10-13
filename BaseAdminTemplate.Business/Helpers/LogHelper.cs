using System;

using BaseAdminTemplate.DataAccess.UnitOfWork;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.Business.Helpers
{
    public static class LogHelper
    {
        public static void AddLog(IUnitOfWork unitOfWork, Exception e, string className, string methodName)
        {
            unitOfWork.ExceptionLogRepository.Create(new ExceptionLog()
            {
                ClassName = className,
                MethodName = methodName,
                Message = e.Message,
                StackTrace = e.StackTrace,
                Exception = e.ToString()
            });
            unitOfWork.Complete();
        }
    }
}