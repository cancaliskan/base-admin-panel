using System;

namespace BaseAdminTemplate.Domain.Entities
{
    public sealed class LinkUserRole : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}