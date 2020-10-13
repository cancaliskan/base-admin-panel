using System.ComponentModel;

namespace BaseAdminTemplate.Web.Models.ViewModels
{
    public sealed class ChangePasswordViewModel
    {
        [DisplayName("Old Password")]
        public string OldPassword { get; set; }
        [DisplayName("New Password")]
        public string NewPassword { get; set; }
        [DisplayName("Confirm New Password")]
        public string NewPasswordConfirm { get; set; }
    }
}