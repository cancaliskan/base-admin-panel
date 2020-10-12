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
    public sealed class UserService : IUserService
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
                    return _responseHelper.FailResponse("Invalid user Id");
                }

                var user = _unitOfWork.UserRepository.GetById(id);
                if (user == null)
                {
                    return _responseHelper.FailResponse("User could not found");
                }

                return _responseHelper.SuccessResponse(user, "User returned successfully");
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
                return _listResponseHelper.SuccessResponse(users, "Users returned successfully");
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
                    return _listResponseHelper.FailResponse("Users could not found");
                }

                return _listResponseHelper.SuccessResponse(users, "Users returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<User>> GetActiveUsers()
        {
            try
            {
                var activeUsers = _unitOfWork.UserRepository.GetActiveEntities();
                return _listResponseHelper.SuccessResponse(activeUsers, "Users returned successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _listResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<IQueryable<User>> GetInActiveUsers()
        {
            try
            {
                var activeUsers = _unitOfWork.UserRepository.GetInActiveEntities();
                return _listResponseHelper.SuccessResponse(activeUsers, "Users returned successfully");
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

                return _responseHelper.SuccessResponse(entity, "User created successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _responseHelper.FailResponse(e.ToString());
            }
        }

        public Response<User> Update(User entity)
        {
            try
            {
                var user = _unitOfWork.UserRepository.GetById(entity.Id);
                if (user == null)
                {
                    return _responseHelper.FailResponse("User could not found");
                }

                if (ModelValidation(entity, out var response))
                {
                    return response;
                }

                _unitOfWork.UserRepository.Update(entity);
                _unitOfWork.Complete();

                return _responseHelper.SuccessResponse(entity, "User updated successfully");
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
                    return _booleanResponseHelper.FailResponse("User could not found");
                }

                _unitOfWork.UserRepository.SoftDelete(id);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("User soft delete successful");
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
                    return _booleanResponseHelper.FailResponse("User could not found");
                }

                _unitOfWork.UserRepository.HardDelete(id);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("User hard delete successful");
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
                var inactiveUser = _unitOfWork.UserRepository.GetByCondition(x => x.Id == id && x.IsActive == false).FirstOrDefault();
                if (inactiveUser == null)
                {
                    return _booleanResponseHelper.FailResponse("User could not found");
                }

                _unitOfWork.UserRepository.Restore(inactiveUser);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("User restored successful");
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
                    return _responseHelper.FailResponse("User could not found");
                }

                if (password != CryptoHelper.Decrypt(user.Password))
                {
                    return _responseHelper.FailResponse("Wrong password");
                }

                _unitOfWork.UserRepository.Login(user);
                _unitOfWork.Complete();

                return _responseHelper.SuccessResponse(user, "User returned successfully");
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
                    return _responseHelper.FailResponse("User could not found");
                }

                if (oldPassword != CryptoHelper.Decrypt(user.Password))
                {
                    return _responseHelper.FailResponse("Invalid old password. ");
                }

                if (newPassword.IsNotValidPassword())
                {
                    return _responseHelper.FailResponse("New password is not valid. Password must have 1 big, 1 small, 1 number and be minimum 8 character");
                }

                _unitOfWork.UserRepository.ChangePassword(user, newPassword);
                _unitOfWork.Complete();

                return _responseHelper.SuccessResponse(user, "Password changed successfully");
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
                    return _responseRoleHelper.FailResponse("User could not found");
                }

                var role = _unitOfWork.UserRepository.GetRole(id);
                if (role != null)
                {
                    return _responseRoleHelper.SuccessResponse(role, "User role return successfully");
                }

                return _responseRoleHelper.FailResponse("User role could not found");
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
                return _listPermissionResponseHelper.SuccessResponse(permissions, "User permissions returned successfully");
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
                    return _booleanResponseHelper.FailResponse("User user could not found");
                }

                var role = _unitOfWork.RoleRepository.GetById(roleId);
                if (role == null)
                {
                    return _booleanResponseHelper.FailResponse("role could not found");
                }

                var isSuccess = _unitOfWork.LinkUserRoleRepository.AddRoleToUser(userId, roleId);
                if (isSuccess)
                {
                    _unitOfWork.Complete();
                    return _booleanResponseHelper.SuccessResponse("Role added to user");
                }

                return _booleanResponseHelper.FailResponse("Role can not added to user");
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
                    return _booleanResponseHelper.FailResponse("User could not found");
                }

                var role = _unitOfWork.RoleRepository.GetById(roleId);
                if (role == null)
                {
                    return _booleanResponseHelper.FailResponse("Role could not found");
                }

                var isSuccess = _unitOfWork.LinkUserRoleRepository.RemoveRoleFromUser(userId, roleId);
                if (isSuccess)
                {
                    _unitOfWork.Complete();
                    return _booleanResponseHelper.SuccessResponse("Role added to user");
                }

                return _booleanResponseHelper.FailResponse("Role can not removed from user");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<bool> UpdateRole(Guid userId, Guid roleId)
        {
            try
            {
                var linkUserRole = _unitOfWork.LinkUserRoleRepository.GetByCondition(x => x.UserId == userId).FirstOrDefault();
                if (linkUserRole == null)
                {
                    return _booleanResponseHelper.FailResponse("Something went wrong");
                }

                linkUserRole.RoleId = roleId;
                _unitOfWork.LinkUserRoleRepository.Update(linkUserRole);
                _unitOfWork.Complete();
                return _booleanResponseHelper.SuccessResponse("Role updated to user");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<bool> ForgetPassword(string eMail)
        {
            try
            {
                var user = _unitOfWork.UserRepository.GetByCondition(x => x.Email == eMail).FirstOrDefault();
                if (user == null)
                {
                    return _booleanResponseHelper.FailResponse("Email is not registered");
                }

                var key = CryptoHelper.Encrypt(eMail);
                var resetUrl = "<a href=" + ConfigurationParameterHelper.GetConfigurationParameter("BaseURL") +
                                    "/Account/ResetPassword?key=" +
                                    key + "> Click to reset password </a>";

                _unitOfWork.PasswordResetRepository.Create(new PasswordReset() { Key = key, UserId = user.Id });
                _unitOfWork.Complete();

                var eMailService = new EmailService();
                eMailService.Send(user.Email, "Reset Password", resetUrl);
                return _booleanResponseHelper.SuccessResponse("Mail sent successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<bool> ResetPassword(User entity)
        {
            try
            {
                if (entity.Password.IsNotValidPassword())
                {
                    return _booleanResponseHelper.FailResponse("Password must have 1 big, 1 small, 1 number and be minimum 8 character");
                }

                _unitOfWork.UserRepository.Update(entity);

                var passwordResetEntity = _unitOfWork.PasswordResetRepository
                                                     .GetByCondition(x => x.UserId == entity.Id 
                                                                          && x.IsActive).FirstOrDefault();
                if (passwordResetEntity == null)
                {
                    return _booleanResponseHelper.FailResponse("Link used before");
                }

                passwordResetEntity.IsActive = false;
                _unitOfWork.PasswordResetRepository.Update(passwordResetEntity);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("Password updated successfully");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        public Response<bool> IsUsedKey(string key)
        {
            try
            {
                var entity = _unitOfWork.PasswordResetRepository.GetByCondition(x => x.Key == key).FirstOrDefault();
                if (entity == null)
                {
                    return _booleanResponseHelper.FailResponse("Link is not valid");
                }

                if (entity.IsActive == false)
                {
                    return _booleanResponseHelper.FailResponse("Link used before");
                }

                return _booleanResponseHelper.SuccessResponse("Link is valid");
            }
            catch (Exception e)
            {
                LogHelper.AddLog(_unitOfWork, e, GetType().Name, MethodBase.GetCurrentMethod()?.Name);
                return _booleanResponseHelper.FailResponse(e.ToString());
            }
        }

        private bool ModelValidation(User entity, out Response<User> response)
        {
            var existUserResponse = GetByCondition(x => x.Email == entity.Email && x.IsActive);
            if (existUserResponse.IsSucceed)
            {
                response = _responseHelper.FailResponse("Email already exist");
                return true;
            }

            existUserResponse = GetByCondition(x => x.Email == entity.Email && !x.IsActive);
            if (existUserResponse.IsSucceed)
            {
                response = _responseHelper.FailResponse("Email already exist but user deactivated");
                return true;
            }

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

            if (entity.Phone.IsNotEmpty() && entity.Phone.IsNotPhoneNumber())
            {
                response = _responseHelper.FailResponse("Phone must have 11 character and must be number");
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