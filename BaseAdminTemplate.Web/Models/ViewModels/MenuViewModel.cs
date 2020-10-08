using System;

namespace BaseAdminTemplate.Web.Models.ViewModels
{
    public sealed class MenuViewModel
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string ControllerName { get; set; }
    }
}