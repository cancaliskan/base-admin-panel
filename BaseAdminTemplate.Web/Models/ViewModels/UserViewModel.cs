using System;
using System.ComponentModel;

namespace BaseAdminTemplate.Web.Models.ViewModels
{
    public sealed class UserViewModel : BaseViewModel
    {
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Surname")]
        public string Surname { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Password")]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        [DisplayName("Last Login Datetime")]
        public DateTime? LastLoginDateTime { get; set; }
        [DisplayName("Role")]
        public RoleViewModel Role { get; set; }
    }
}