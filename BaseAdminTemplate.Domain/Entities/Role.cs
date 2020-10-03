using System.Collections.Generic;

namespace BaseAdminTemplate.Domain.Entities
{
    public sealed class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public string Description { get; set; }
    }
}