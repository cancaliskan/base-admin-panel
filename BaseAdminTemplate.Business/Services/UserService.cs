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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ResponseHelper<User> _responseHelper;
        private readonly ResponseHelper<Role> _responseRoleHelper;
        private readonly ResponseHelper<IQueryable<User>> _listResponseHelper;
        private readonly ResponseHelper<IQueryable<Permission>> _listPermissionResponseHelper;
        private readonly ResponseHelper<bool> _booleanResponseHelper;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            _responseHelper = new ResponseHelper<User>();
            _responseRoleHelper = new ResponseHelper<Role>();
            _listResponseHelper = new ResponseHelper<IQueryable<User>>();
            _listPermissionResponseHelper = new ResponseHelper<IQueryable<Permission>>();
            _booleanResponseHelper = new ResponseHelper<bool>();
        }

        public Response<User> GetById(Guid id)
        {
            try
            {
                if (id.IsEmptyGuid())
                {
                    return _responseHelper.FailResponse("Invalid Id");
                }

                var user = _unitOfWork.UserRepository.GetById(id);
                if (user == null)
                {
                    return _responseHelper.FailResponse("could not found");
                }

                return _responseHelper.SuccessResponse(user, "returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _responseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<User>> GetAll()
        {
            try
            {
                var users = _unitOfWork.UserRepository.GetAll();
                return _listResponseHelper.SuccessResponse(users, "returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<User>> GetByCondition(Expression<Func<User, bool>> expression)
        {
            try
            {
                var users = _unitOfWork.UserRepository.GetByCondition(expression);
                if (users == null || !users.Any())
                {
                    return _listResponseHelper.FailResponse("could not found");
                }

                return _listResponseHelper.SuccessResponse(users, "returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<User>> GetActivePermissions()
        {
            try
            {
                var activeUsers = _unitOfWork.UserRepository.GetActiveEntities();
                return _listResponseHelper.SuccessResponse(activeUsers, "returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<User>> GetInActivePermissions()
        {
            try
            {
                var activeUsers = _unitOfWork.UserRepository.GetInActiveEntities();
                return _listResponseHelper.SuccessResponse(activeUsers, "returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<User> Create(User entity)
        {
            try
            {
                if (ModelValidation(entity, out var response))
                {
                    return response;
                }

                entity.Password = CryptoHelper.Encrypt(entity.Password);

                _unitOfWork.UserRepository.Create(entity);
                _unitOfWork.Complete();

                return _responseHelper.SuccessResponse(entity, "created successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _responseHelper.FailResponse(e.ToString());
            }
        }

        public Response<User> Update(User role)
        {
            try
            {
                var existUser = _unitOfWork.UserRepository.GetById(role.Id);
                if (existUser == null)
                {
                    return _responseHelper.FailResponse("could not found");
                }

                if (ModelValidation(role, out var response))
                {
                    return response;
                }

                existUser.Name = role.Name;
                existUser.Surname = role.Surname;
                existUser.Email = role.Password;

                _unitOfWork.UserRepository.Update(existUser);
                _unitOfWork.Complete();

                response.Result = existUser;
                return response;
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
                if (IsNotExistUser(id))
                {
                    return _booleanResponseHelper.FailResponse("could not found");
                }

                _unitOfWork.UserRepository.SoftDelete(id);
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
                if (IsNotExistUser(id))
                {
                    return _booleanResponseHelper.FailResponse("could not found");
                }

                _unitOfWork.UserRepository.HardDelete(id);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("soft delete successful");
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
                var inactiveUser = _unitOfWork.UserRepository.GetByCondition(x => x.Id == id && x.IsActive == false);
                if (inactiveUser == null)
                {
                    return _booleanResponseHelper.FailResponse("could not found");
                }

                _unitOfWork.UserRepository.Restore(id);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("restore successful");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<User> Login(string email, string password)
        {
            try
            {
                var user = _unitOfWork.UserRepository.GetByCondition(x => x.Email == email)?.FirstOrDefault();
                if (user == null)
                {
                    return _responseHelper.FailResponse("could not found");
                }

                if (password != CryptoHelper.Decrypt(user.Password))
                {
                    return _responseHelper.FailResponse("Wrong password");
                }

                _unitOfWork.UserRepository.Login(user);

                return _responseHelper.SuccessResponse(user, "returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _responseHelper.FailResponse(e.ToString());
            }
        }

        public Response<User> ChangePassword(Guid id, string oldPassword, string newPassword)
        {
            try
            {
                var user = _unitOfWork.UserRepository.GetById(id);
                if (user == null)
                {
                    return _responseHelper.FailResponse("could not found");
                }

                if (oldPassword != CryptoHelper.Encrypt(user.Password))
                {
                    return _responseHelper.FailResponse("invalid old password. ");
                }

                if (newPassword.IsNotValidPassword())
                {
                    return _responseHelper.FailResponse("new password is not valid. Password must have 1 big, 1 small, 1 number and be minimum 8 character");
                }

                _unitOfWork.UserRepository.ChangePassword(user, newPassword);
                return _responseHelper.SuccessResponse(user, "password changed successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _responseHelper.FailResponse(e.ToString());
            }
        }

        public Response<Role> GetRole(Guid id)
        {
            try
            {
                if (IsNotExistUser(id))
                {
                    return _responseRoleHelper.FailResponse("user could not found");
                }

                var role = _unitOfWork.UserRepository.GetRole(id);

                return _responseRoleHelper.SuccessResponse(role, "return successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _responseRoleHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<Permission>> GetPermissions(Guid id)
        {
            try
            {
                if (IsNotExistUser(id))
                {
                    return _listPermissionResponseHelper.FailResponse("user could not found");
                }

                var permissions = _unitOfWork.UserRepository.GetPermissions(id);
                return _listPermissionResponseHelper.SuccessResponse(permissions, "permissions returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listPermissionResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<bool> AddRoleToUser(Guid userId, Guid roleId)
        {
            try
            {
                if (IsNotExistUser(userId))
                {
                    return _booleanResponseHelper.FailResponse("user could not found");
                }

                var role = _unitOfWork.RoleRepository.GetById(roleId);
                if (role == null)
                {
                    return _booleanResponseHelper.FailResponse("role could not found");
                }

                var isSuccess = _unitOfWork.LinkUserRoleRepository.AddRoleToUser(userId, roleId);
                if (isSuccess)
                {
                    return _booleanResponseHelper.SuccessResponse("role added to user");
                }

                return _booleanResponseHelper.FailResponse("role can not added to user");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<bool> RemoveRoleFromUser(Guid userId, Guid roleId)
        {
            try
            {
                if (IsNotExistUser(userId))
                {
                    return _booleanResponseHelper.FailResponse("user could not found");
                }

                var role = _unitOfWork.RoleRepository.GetById(roleId);
                if (role == null)
                {
                    return _booleanResponseHelper.FailResponse("role could not found");
                }

                var isSuccess = _unitOfWork.LinkUserRoleRepository.RemoveRoleFromUser(userId, roleId);
                if (isSuccess)
                {
                    return _booleanResponseHelper.SuccessResponse("role added to user");
                }

                return _booleanResponseHelper.FailResponse("role can not removed from user");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        private bool ModelValidation(User entity, out Response<User> response)
        {
            if (entity.Name.IsEmpty())
            {
                response = _responseHelper.FailResponse("Name is mandatory");
                return true;
            }

            if (entity.Surname.IsEmpty())
            {
                response = _responseHelper.FailResponse("Last Name is mandatory");
                return true;
            }

            if (entity.Password.IsNotValidPassword())
            {
                response = _responseHelper.FailResponse("Password must have 1 big, 1 small, 1 number and be minimum 8 character");
                return true;
            }

            if (entity.Email.IsNotEmail())
            {
                response = _responseHelper.FailResponse("Email must be valid");
                return true;
            }

            response = null;
            return false;
        }

        private bool IsNotExistUser(Guid id)
        {
            var existUser = _unitOfWork.UserRepository.GetById(id);
            return existUser == null;
        }
    }
}