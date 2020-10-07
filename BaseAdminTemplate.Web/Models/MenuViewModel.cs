using System;

namespace BaseAdminTemplate.Web.Models
{
    public sealed class MenuViewModel
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public string ControllerName { get; set; }
    }
}