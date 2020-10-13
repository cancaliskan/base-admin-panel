using System.ComponentModel;

namespace BaseAdminTemplate.Web.Models.ViewModels
{
    public sealed class RoleViewModel : BaseViewModel
    {
        [DisplayName("İsim")]
        public string Name { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
    }
}