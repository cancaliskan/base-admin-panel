using System.ComponentModel;

namespace BaseAdminTemplate.Web.Models.ViewModels
{
    public sealed class ChangePasswordViewModel
    {
        [DisplayName("Eski Parola")]
        public string OldPassword { get; set; }
        [DisplayName("Yeni Parola")]
        public string NewPassword { get; set; }
        [DisplayName("Yeni Parola Onayı")]
        public string NewPasswordConfirm { get; set; }
    }
}