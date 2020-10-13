using System;

namespace BaseAdminTemplate.Domain.Entities
{
    public sealed class LinkMenuPermission : BaseEntity
    {
        public Guid MenuId { get; set; }
        public Guid PermissionId { get; set; }
    }
}