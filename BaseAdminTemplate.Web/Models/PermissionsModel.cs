using System;
using System.Collections.Generic;

namespace BaseAdminTemplate.Web.Models
{
    public sealed class PermissionsModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Child> ChildList { get; set; }
    }

    public sealed class Child
    {
        public Guid ParentId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}