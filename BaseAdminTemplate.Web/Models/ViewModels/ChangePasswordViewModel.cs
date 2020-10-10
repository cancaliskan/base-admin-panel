namespace BaseAdminTemplate.Web.Models.ViewModels
{
    public sealed class ChangePasswordViewModel
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordConfirm { get; set; }
    }
}