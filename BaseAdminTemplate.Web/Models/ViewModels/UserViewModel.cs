using System;

namespace BaseAdminTemplate.Web.Models.ViewModels
{
    public sealed class UserViewModel:BaseViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Phone { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public RoleViewModel Role { get; set; }
    }
}