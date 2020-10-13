using System;
using System.Linq;
using System.Reflection;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Business.Helpers;
using BaseAdminTemplate.Common.Contracts;
using BaseAdminTemplate.Common.Helpers;
using BaseAdminTemplate.DataAccess.UnitOfWork;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.Business.Services
{
    public sealed class ExceptionLogService : IExceptionLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ResponseHelper<IQueryable<ExceptionLog>> _listResponseHelper;
        private readonly ResponseHelper<bool> _booleanResponseHelper;

        public ExceptionLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _listResponseHelper = new ResponseHelper<IQueryable<ExceptionLog>>();
            _booleanResponseHelper = new ResponseHelper<bool>();
        }

        public Response<IQueryable<ExceptionLog>> GetAll()
        {
            try
            {
                var exceptionLogs = _unitOfWork.ExceptionLogRepository.GetAll();
                return _listResponseHelper.SuccessResponse(exceptionLogs, "Hata kayıtları döndü");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<bool> DeleteAll()
        {
            try
            {
                _unitOfWork.ExceptionLogRepository.HardDeleteAll();
                _unitOfWork.Complete();
                return _booleanResponseHelper.SuccessResponse("Tüm hata kayıtları silindi");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }
    }
}