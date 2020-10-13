using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using BaseAdminTemplate.Business.Contracts;
using BaseAdminTemplate.Business.Helpers;
using BaseAdminTemplate.Common.Contracts;
using BaseAdminTemplate.Common.Helpers;
using BaseAdminTemplate.DataAccess.Helpers;
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
                    return _responseHelper.FailResponse("Geçersiz Id");
                }

                var role = _unitOfWork.RoleRepository.GetById(id);
                if (role == null)
                {
                    return _responseHelper.FailResponse("Role bulunamadı");
                }

                return _responseHelper.SuccessResponse(role, "Rol başarılı olarak döndü");
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
                return _listResponseHelper.SuccessResponse(roles, "Roller başarılı olarak döndü");
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
                    return _listResponseHelper.FailResponse("Role bulunamadı");
                }

                return _listResponseHelper.SuccessResponse(roles, "Roller başarılı olarak döndü");
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
                return _listResponseHelper.SuccessResponse(activeRoles, "Aktif roller başarılı olarak döndü");
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
                return _listResponseHelper.SuccessResponse(inactiveRoles, "Deaktif roller başarılı olarak döndü");
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
                    return _responseHelper.FailResponse("Rol bulunamadı");
                }

                if (IsAdminRole(role.Id))
                {
                    return _responseHelper.FailResponse("Admin rölünü update edemezsiniz");
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
                    return _booleanResponseHelper.FailResponse("Role bulunamadı");
                }

                if (IsAdminRole(id))
                {
                    return _booleanResponseHelper.FailResponse("Admin rölünü deaktif edemezsiniz");
                }

                _unitOfWork.RoleRepository.SoftDelete(id);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("Role geçici olarak silindi");
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
                    return _booleanResponseHelper.FailResponse("Role bulunamadı");
                }

                if (IsAdminRole(id))
                {
                    return _booleanResponseHelper.FailResponse("Admin rölünü silemezsiniz");
                }

                _unitOfWork.RoleRepository.HardDelete(id);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("Rol kalıcı olarak silindi");
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
                    return _booleanResponseHelper.FailResponse("Rol bulunamadı");
                }

                _unitOfWork.RoleRepository.Restore(existRole);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("Rol kurtarıldı");
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
                    return _listPermissionResponseHelper.FailResponse("Rol bulunamadı");
                }

                var permissions = _unitOfWork.RoleRepository.GetPermissions(id);

                return _listPermissionResponseHelper.SuccessResponse(permissions, "Rol yetkileri başarılı olarak döndü");
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
                    return _booleanResponseHelper.FailResponse("Rol bulunamadı");
                }

                var permission = _unitOfWork.PermissionRepository.GetById(permissionId);
                if (permission == null)
                {
                    return _booleanResponseHelper.FailResponse("Yetki bulunamadı");
                }

                var isSuccess = _unitOfWork.LinkRolePermissionRepository.AddPermissionToRole(roleId, permissionId);
                if (isSuccess)
                {
                    _unitOfWork.Complete();
                    return _booleanResponseHelper.SuccessResponse("Role yetki atandı");
                }

                return _booleanResponseHelper.FailResponse("Role yetki atanamadı");
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
                    return _booleanResponseHelper.FailResponse("Rol bulunamadı");
                }

                var permission = _unitOfWork.PermissionRepository.GetById(permissionId);
                if (permission == null)
                {
                    return _booleanResponseHelper.FailResponse("Yetki bulunamadı");
                }

                var isSuccess = _unitOfWork.LinkRolePermissionRepository.RemovePermissionToRole(roleId, permissionId);
                if (isSuccess)
                {
                    _unitOfWork.Complete();
                    return _booleanResponseHelper.SuccessResponse("Yetki rolden kaldırıldı");
                }

                return _booleanResponseHelper.FailResponse("Yetki rolden kaldırılamadı");
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
                    return _booleanResponseHelper.FailResponse("rol bulunamadı");
                }

                var isSuccess = _unitOfWork.LinkRolePermissionRepository.RemoveAllPermissionFromRole(roleId);
                if (isSuccess)
                {
                    _unitOfWork.Complete();
                    return _booleanResponseHelper.SuccessResponse("Rolden tüm yetkiler kaldırıldı");
                }

                return _booleanResponseHelper.FailResponse("Rolden tüm yetkiler kaldırılamadı");
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
                return _responseHelper.FailResponse("Rol ismi zorunlu");
            }

            return _responseHelper.SuccessResponse("");
        }

        private bool IsAdminRole(Guid roleId)
        {
            return roleId == new Guid(ConfigurationParameterHelper.GetConfigurationParameter("AdminRoleId"));
        }
    }
}