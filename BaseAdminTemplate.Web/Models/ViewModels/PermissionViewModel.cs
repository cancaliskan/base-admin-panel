namespace BaseAdminTemplate.Web.Models.ViewModels
{
    public sealed class PermissionViewModel : BaseViewModel
    {
        public string DisplayName { get; set; }
        public string MethodName { get; set; }
        public bool DisplayInMenu { get; set; }
    }
}