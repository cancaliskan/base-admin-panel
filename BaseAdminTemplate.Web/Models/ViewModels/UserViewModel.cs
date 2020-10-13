using System;
using System.ComponentModel;

namespace BaseAdminTemplate.Web.Models.ViewModels
{
    public sealed class UserViewModel : BaseViewModel
    {
        [DisplayName("İsim")]
        public string Name { get; set; }
        [DisplayName("Soyisim")]
        public string Surname { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Parola")]
        public string Password { get; set; }
        [DisplayName("Parola Onayı")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Telefon Numarası")]
        public string Phone { get; set; }
        [DisplayName("Son Giriş Tarihi")]
        public DateTime? LastLoginDateTime { get; set; }
        [DisplayName("Rol")]
        public RoleViewModel Role { get; set; }
    }
}