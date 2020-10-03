using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseAdminTemplate.Domain.Entities
{
    public sealed class Permission : BaseEntity
    {
        public string Name { get; set; }

        //public Guid RoleId { get; set; }
        //public Role Role { get; set; }
    }
}