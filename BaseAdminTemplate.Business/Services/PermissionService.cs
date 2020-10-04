using System;
using System.Linq;
using System.Linq.Expressions;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Common.Contracts;
using BaseAdminTemplate.Common.Helpers;
using BaseAdminTemplate.DataAccess.UnitOfWork;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.Business.Services
{
    public sealed class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ResponseHelper<Permission> _responseHelper;
        private readonly ResponseHelper<IQueryable<Permission>> _listResponseHelper;
        private readonly ResponseHelper<bool> _booleanResponseHelper;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _responseHelper = new ResponseHelper<Permission>();
            _listResponseHelper = new ResponseHelper<IQueryable<Permission>>();
            _booleanResponseHelper = new ResponseHelper<bool>();
        }

        public Response<Permission> GetById(Guid id)
        {
            try
            {
                if (id.IsEmptyGuid())
                {
                    return _responseHelper.FailResponse("Invalid Id");
                }

                var permission = _unitOfWork.PermissionRepository.GetById(id);
                if (permission == null)
                {
                    return _responseHelper.FailResponse("could not found");
                }

                return _responseHelper.SuccessResponse(permission, "returned successfully");
            }
            catch (Exception e)
            {
                //todo: add log to database
                return _responseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<Permission>> GetByCondition(Expression<Func<Permission, bool>> expression)
        {
            try
            {
                var permissions = _unitOfWork.PermissionRepository.GetByCondition(expression);
                if (permissions == null || !permissions.Any())
                {
                    return _listResponseHelper.FailResponse("could not found");
                }

                return _listResponseHelper.SuccessResponse(permissions, "roles returned successfully");
            }
            catch (Exception e)
            {
                //todo: add log to database
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<Permission>> GetAll()
        {
            try
            {
                var permissions = _unitOfWork.PermissionRepository.GetAll();
                return _listResponseHelper.SuccessResponse(permissions, "returned successfully");
            }
            catch (Exception e)
            {
                //todo: add log to database
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<Permission>> GetActivePermissions()
        {
            try
            {
                var permissions = _unitOfWork.PermissionRepository.GetActiveEntities();
                return _listResponseHelper.SuccessResponse(permissions, "returned successfully");
            }
            catch (Exception e)
            {
                //todo: add log to database
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<Permission>> GetInActivePermissions()
        {
            try
            {
                var permissions = _unitOfWork.PermissionRepository.GetInActiveEntities();
                return _listResponseHelper.SuccessResponse(permissions, "returned successfully");
            }
            catch (Exception e)
            {
                //todo: add log to database
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }
    }
}