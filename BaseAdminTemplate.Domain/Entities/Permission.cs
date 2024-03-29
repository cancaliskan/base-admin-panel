﻿namespace BaseAdminTemplate.Domain.Entities
{
    public sealed class Permission : BaseEntity
    {
        public string DisplayName { get; set; }
        public string MethodName { get; set; }
        public bool DisplayInMenu { get; set; }
        public bool DisplayInPermissionTree { get; set; }
    }
}