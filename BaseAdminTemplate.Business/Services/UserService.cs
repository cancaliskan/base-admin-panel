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
                    return _responseHelper.FailResponse("Geçersiz kullanıcı kimliği");
                }

                var user = _unitOfWork.UserRepository.GetById(id);
                if (user == null)
                {
                    return _responseHelper.FailResponse("Kullanıcı bulunamadı");
                }

                return _responseHelper.SuccessResponse(user, "Kullanıcı başarılı bir şekilde döndü");
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
                return _listResponseHelper.SuccessResponse(users, "Kullanıcılar başarılı bir şekilde döndü");
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
                    return _listResponseHelper.FailResponse("Kullanıcılar bulunamadı");
                }

                return _listResponseHelper.SuccessResponse(users, "Kullanıcılar başarılı bir şekilde döndü");
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
                return _listResponseHelper.SuccessResponse(activeUsers, "Aktif kullanıcılar başarılı bir şekilde döndü");
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
                return _listResponseHelper.SuccessResponse(activeUsers, "Deaktif kullanıcılar başarılı bir şekilde döndü");
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

                return _responseHelper.SuccessResponse(entity, "Kullanıcı başarılı bir şekilde oluşturuldu");
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
                    return _responseHelper.FailResponse("Kullanıcı bulunamadı");
                }

                if (ModelValidation(entity, out var response))
                {
                    return response;
                }

                _unitOfWork.UserRepository.Update(entity);
                _unitOfWork.Complete();

                return _responseHelper.SuccessResponse(entity, "Kullanıcı başarılı bir şekilde güncellendi");
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
                    return _booleanResponseHelper.FailResponse("Kullanıcı bulunamadı");
                }

                _unitOfWork.UserRepository.SoftDelete(id);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("Kullanıcı geçici olarak silindi");
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
                    return _booleanResponseHelper.FailResponse("Kullanıcı bulunamadı");
                }

                _unitOfWork.UserRepository.HardDelete(id);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("Kullanıcı kalıcı olarak silindi");
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
                    return _booleanResponseHelper.FailResponse("Kullanıcı bulunamadı");
                }

                _unitOfWork.UserRepository.Restore(inactiveUser);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("Kullanıcı başarılı bir şekilde geri yüklendi");
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
                    return _responseHelper.FailResponse("Kullanıcı bulunamadı");
                }

                if (password != CryptoHelper.Decrypt(user.Password))
                {
                    return _responseHelper.FailResponse("Yanlış parola");
                }

                _unitOfWork.UserRepository.Login(user);
                _unitOfWork.Complete();

                return _responseHelper.SuccessResponse(user, "Kullanıcı başarılı olarak döndü");
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
                    return _responseHelper.FailResponse("Kullanıcı bulunamadı");
                }

                if (oldPassword != CryptoHelper.Decrypt(user.Password))
                {
                    return _responseHelper.FailResponse("Parola yanlış");
                }

                if (newPassword.IsNotValidPassword())
                {
                    return _responseHelper.FailResponse("Yeni parola 1 rakam, 1 büyük karakter, 1 küçük karakter içermeli ve minimum 8 karakter olmalıdır");
                }

                _unitOfWork.UserRepository.ChangePassword(user, newPassword);
                _unitOfWork.Complete();

                return _responseHelper.SuccessResponse(user, "Parola başarılı bir şekilde değiştirildi");
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
                    return _responseRoleHelper.FailResponse("Kullanıcı bulunamadı");
                }

                var role = _unitOfWork.UserRepository.GetRole(id);
                if (role != null)
                {
                    return _responseRoleHelper.SuccessResponse(role, "Kullanıcı rolü döndü");
                }

                return _responseRoleHelper.FailResponse("Kullanıcı rolü bulunamadı");
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
                    return _listPermissionResponseHelper.FailResponse("Kullanıcı bulunamadı");
                }

                var permissions = _unitOfWork.UserRepository.GetPermissions(id);
                return _listPermissionResponseHelper.SuccessResponse(permissions, "Kullanıcı yetkileri döndü");
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
                    return _booleanResponseHelper.FailResponse("Kullanıcı bulunamadı");
                }

                var role = _unitOfWork.RoleRepository.GetById(roleId);
                if (role == null)
                {
                    return _booleanResponseHelper.FailResponse("Rol bulunamadı");
                }

                var isSuccess = _unitOfWork.LinkUserRoleRepository.AddRoleToUser(userId, roleId);
                if (isSuccess)
                {
                    _unitOfWork.Complete();
                    return _booleanResponseHelper.SuccessResponse("Kullanıcıya rol atandı");
                }

                return _booleanResponseHelper.FailResponse("Kullanıcıya rol atanamadı");
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
                    return _booleanResponseHelper.FailResponse("Kullanıcı bulunamadı");
                }

                var role = _unitOfWork.RoleRepository.GetById(roleId);
                if (role == null)
                {
                    return _booleanResponseHelper.FailResponse("Rol bulunamadı");
                }

                var isSuccess = _unitOfWork.LinkUserRoleRepository.RemoveRoleFromUser(userId, roleId);
                if (isSuccess)
                {
                    _unitOfWork.Complete();
                    return _booleanResponseHelper.SuccessResponse("Kullanıcı rolü kaldırıldı");
                }

                return _booleanResponseHelper.FailResponse("Kullanıcı rolü kaldırılamadı");
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
                    return _booleanResponseHelper.FailResponse("Bir hata yaşandı");
                }

                linkUserRole.RoleId = roleId;
                _unitOfWork.LinkUserRoleRepository.Update(linkUserRole);
                _unitOfWork.Complete();
                return _booleanResponseHelper.SuccessResponse("Kullanıcı rolü güncellendi");
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
                    return _booleanResponseHelper.FailResponse("Eposta kayıtlı değil");
                }

                var key = CryptoHelper.Encrypt(eMail);
                var resetUrl = "<a href=" + ConfigurationParameterHelper.GetConfigurationParameter("BaseURL") +
                                    "/Account/ResetPassword?key=" +
                                    key + "> Parola sıfırlamak için tıklayın</a>";

                _unitOfWork.PasswordResetRepository.Create(new PasswordReset() { Key = key, UserId = user.Id });
                _unitOfWork.Complete();

                var eMailService = new EmailService();
                eMailService.Send(user.Email, "Parola Sıfırlama", resetUrl);
                return _booleanResponseHelper.SuccessResponse("Paralo sıfırlamak için mail gönderildi. Mail kutunuzu kontrol edin");
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
                    return _booleanResponseHelper.FailResponse("Parola 1 rakam, 1 büyük karakter, 1 küçük karakter içermeli ve minimum 8 karakter olmalıdır");
                }

                _unitOfWork.UserRepository.Update(entity);

                var passwordResetEntity = _unitOfWork.PasswordResetRepository
                                                     .GetByCondition(x => x.UserId == entity.Id 
                                                                          && x.IsActive).FirstOrDefault();
                if (passwordResetEntity == null)
                {
                    return _booleanResponseHelper.FailResponse("Link daha önce kullanıldı");
                }

                passwordResetEntity.IsActive = false;
                _unitOfWork.PasswordResetRepository.Update(passwordResetEntity);
                _unitOfWork.Complete();

                return _booleanResponseHelper.SuccessResponse("Parola güncellendi");
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
                    return _booleanResponseHelper.FailResponse("Geçersiz link");
                }

                if (entity.IsActive == false)
                {
                    return _booleanResponseHelper.FailResponse("Link daha önce kullanıldı");
                }

                return _booleanResponseHelper.SuccessResponse("Geçersiz link");
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
                response = _responseHelper.FailResponse("Email sistemde kayıtlı");
                return true;
            }

            existUserResponse = GetByCondition(x => x.Email == entity.Email && !x.IsActive);
            if (existUserResponse.IsSucceed)
            {
                response = _responseHelper.FailResponse("Email sistemde kayıtlı fakat kullanıcı deaktif");
                return true;
            }

            if (entity.Name.IsEmpty())
            {
                response = _responseHelper.FailResponse("Isim zorunlu alan");
                return true;
            }

            if (entity.Surname.IsEmpty())
            {
                response = _responseHelper.FailResponse("Soyisim zorunlu alan");
                return true;
            }

            if (entity.Password.IsNotValidPassword())
            {
                response = _responseHelper.FailResponse("Parola 1 rakam, 1 büyük karakter, 1 küçük karakter içermeli ve minimum 8 karakter olmalıdır");
                return true;
            }

            if (entity.Email.IsNotEmail())
            {
                response = _responseHelper.FailResponse("Geçersiz email adresi");
                return true;
            }

            if (entity.Phone.IsNotEmpty() && entity.Phone.IsNotPhoneNumber())
            {
                response = _responseHelper.FailResponse("Telefon numarası 11 karakter olmalı ve sadece sayı içermelidir. (Örn: 05321234567)");
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