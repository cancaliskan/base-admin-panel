using System;

namespace BaseAdminTemplate.Domain.Entities
{
    public sealed class LinkRolePermission : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
    }
}