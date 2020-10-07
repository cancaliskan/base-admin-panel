using System.Collections.Generic;

namespace BaseAdminTemplate.Web.Models
{
    public sealed class RoleViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<PermissionViewModel> Permissions { get; set; }
    }
}