using System.Collections.Generic;

namespace BaseAdminTemplate.Web.Models
{
    public sealed class MenuItemsModel
    {
        public List<ControllerItemsModel> MenuItems { get; set; }
        public string UserName { get; set; }
    }

    public sealed class ControllerItemsModel
    {
        public string DisplayName { get; set; }
        public string ControllerName { get; set; }
        public List<MethodsItemsModel> Methods { get; set; }
    }

    public sealed class MethodsItemsModel
    {
        public string DisplayName { get; set; }
        public string MethodName { get; set; }
    }
}