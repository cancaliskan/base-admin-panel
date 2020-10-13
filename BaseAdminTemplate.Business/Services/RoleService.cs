using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Business.Helpers;
using BaseAdminTemplate.Common.Contracts;
using BaseAdminTemplate.Common.Helpers;
using BaseAdminTemplate.DataAccess.UnitOfWork;
using BaseAdminTemplate.Domain.Entities;

namespace BaseAdminTemplate.Business.Services
{
    public sealed class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ResponseHelper<Role> _responseHelper;
        private readonly ResponseHelper<IQueryable<Role>> _listResponseHelper;
        private readonly ResponseHelper<IQueryable<Permission>> _listPermissionResponseHelper;
        private readonly ResponseHelper<bool> _booleanResponseHelper;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _responseHelper = new ResponseHelper<Role>();
            _listResponseHelper = new ResponseHelper<IQueryable<Role>>();
            _listPermissionResponseHelper = new ResponseHelper<IQueryable<Permission>>();
            _booleanResponseHelper = new ResponseHelper<bool>();
        }

        public Response<Role> GetById(Guid id)
        {
            try
            {
                if (id.IsEmptyGuid())
                {
                    return _responseHelper.FailResponse("Invalid Id");
                }

                var role = _unitOfWork.RoleRepository.GetById(id);
                if (role == null)
                {
                    return _responseHelper.FailResponse("could not found");
                }

                return _responseHelper.SuccessResponse(role, "returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _responseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<Role>> GetAll()
        {
            try
            {
                var roles = _unitOfWork.RoleRepository.GetAll();
                return _listResponseHelper.SuccessResponse(roles, "returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<Role>> GetByCondition(Expression<Func<Role, bool>> expression)
        {
            try
            {
                var roles = _unitOfWork.RoleRepository.GetByCondition(expression);
                if (roles == null || !roles.Any())
                {
                    return _listResponseHelper.FailResponse("could not found");
                }

                return _listResponseHelper.SuccessResponse(roles, "returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<Role>> GetActiveRoles()
        {
            try
            {
                var activeRoles = _unitOfWork.RoleRepository.GetActiveEntities();
                return _listResponseHelper.SuccessResponse(activeRoles, "returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<Role>> GetInActiveRoles()
        {
            try
            {
                var inactiveRoles = _unitOfWork.RoleRepository.GetInActiveEntities();
                return _listResponseHelper.SuccessResponse(inactiveRoles, "returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<Role> Create(Role role)
        {
            try
            {
                var result = ModelValidations(role);
                if (result.IsSucceed)
                {
                    role = _unitOfWork.RoleRepository.Create(role);
                    _unitOfWork.Complete();

                    result.Result = role;
                }

                return result;
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _responseHelper.FailResponse(e.ToString());
            }
        }

        public Response<Role> Update(Role role)
        {
            try
            {
                var existRole = _unitOfWork.RoleRepository.GetById(role.Id);
                if (existRole == null)
                {
                    return _responseHelper.FailResponse("could not found");
                }

                var result = ModelValidations(role);
                if (result.IsSucceed)
                {
                    existRole.Name = role.Name;
                    existRole.Description = role.Description;
                    result.Result = existRole;

                    _unitOfWork.RoleRepository.Update(existRole);
                    _unitOfWork.Complete();
                }

                return result;
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _responseHelper.FailResponse(e.ToString());
            }
        }

        public Response<bool> SoftDelete(Guid id)
        {
            try
            {
                if (IsNotExistRole(id))
                {
                    return _booleanResponseHelper.FailResponse("could not found");
                }

                _unitOfWork.RoleRepository.SoftDelete(id);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("soft delete successful");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<bool> HardDelete(Guid id)
        {
            try
            {
                if (IsNotExistRole(id))
                {
                    return _booleanResponseHelper.FailResponse("could not found");
                }

                _unitOfWork.RoleRepository.HardDelete(id);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("hard delete successful");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<bool> Restore(Guid id)
        {
            try
            {
                var existRole = _unitOfWork.RoleRepository.GetById(id);
                if (existRole == null)
                {
                    return _booleanResponseHelper.FailResponse("could not found");
                }

                _unitOfWork.RoleRepository.Restore(existRole);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("restored successful");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<Permission>> GetPermissions(Guid id)
        {
            try
            {
                if (IsNotExistRole(id))
                {
                    return _listPermissionResponseHelper.FailResponse("could not found");
                }

                var permissions = _unitOfWork.RoleRepository.GetPermissions(id);

                return _listPermissionResponseHelper.SuccessResponse(permissions, "permissions returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listPermissionResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<bool> AddPermissionToRole(Guid roleId, Guid permissionId)
        {
            try
            {
                if (IsNotExistRole(roleId))
                {
                    return _booleanResponseHelper.FailResponse("role could not found");
                }

                var permission = _unitOfWork.PermissionRepository.GetById(permissionId);
                if (permission == null)
                {
                    return _booleanResponseHelper.FailResponse("permission could not found");
                }

                var isSuccess = _unitOfWork.LinkRolePermissionRepository.AddPermissionToRole(roleId, permissionId);
                if (isSuccess)
                {
                    _unitOfWork.Complete();
                    return _booleanResponseHelper.SuccessResponse("permission added to role");
                }

                return _booleanResponseHelper.FailResponse("permission can not added to role");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<bool> RemovePermissionFromRole(Guid roleId, Guid permissionId)
        {
            try
            {
                if (IsNotExistRole(roleId))
                {
                    return _booleanResponseHelper.FailResponse("role could not found");
                }

                var permission = _unitOfWork.PermissionRepository.GetById(permissionId);
                if (permission == null)
                {
                    return _booleanResponseHelper.FailResponse("permission could not found");
                }

                var isSuccess = _unitOfWork.LinkRolePermissionRepository.RemovePermissionToRole(roleId, permissionId);
                if (isSuccess)
                {
                    _unitOfWork.Complete();
                    return _booleanResponseHelper.SuccessResponse("permission removed from role");
                }

                return _booleanResponseHelper.FailResponse("permission can not removed from role");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<bool> RemoveAllPermissionFromRole(Guid roleId)
        {
            try
            {
                if (IsNotExistRole(roleId))
                {
                    return _booleanResponseHelper.FailResponse("role could not found");
                }

                var isSuccess = _unitOfWork.LinkRolePermissionRepository.RemoveAllPermissionFromRole(roleId);
                if (isSuccess)
                {
                    _unitOfWork.Complete();
                    return _booleanResponseHelper.SuccessResponse("all permission removed from role");
                }

                return _booleanResponseHelper.FailResponse("all permission can not removed from role");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        private bool IsNotExistRole(Guid id)
        {
            var existRole = _unitOfWork.RoleRepository.GetById(id);
            return existRole == null;
        }

        private Response<Role> ModelValidations(Role role)
        {
            if (role.Name.IsEmpty())
            {
                return _responseHelper.FailResponse("Role name is mandatory");
            }

            return _responseHelper.SuccessResponse("");
        }
    }
}